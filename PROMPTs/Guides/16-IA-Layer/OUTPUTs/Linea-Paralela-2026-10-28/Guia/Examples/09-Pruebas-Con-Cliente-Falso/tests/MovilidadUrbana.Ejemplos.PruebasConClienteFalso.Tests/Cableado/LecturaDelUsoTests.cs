using System.Net;
using System.Text;
using Microsoft.Extensions.AI;
using MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Infrastructure.AI;
using NUnit.Framework;
using OllamaSharp;

namespace MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Tests.Cableado;

/// <summary>
/// Lo que informa el servidor sobre el contexto: el reuso del prefijo (<c>prompt_eval_cached_count</c>) y el
/// contexto truncado (<c>InputTokenCount</c> menor que el esperado). Sin modelo: un NDJSON fijo y un cliente falso.
/// </summary>
[TestFixture, Category("Cableado")]
public sealed class LecturaDelUsoTests
{
    /// <summary>Las líneas que manda /api/chat en streaming: fragmentos y la línea final con los conteos.</summary>
    private const string NdjsonFijo =
        "{\"model\":\"modelo-falso\",\"created_at\":\"2026-10-28T12:00:00Z\",\"message\":{\"role\":\"assistant\",\"content\":\"Hay \"},\"done\":false}\n" +
        "{\"model\":\"modelo-falso\",\"created_at\":\"2026-10-28T12:00:00Z\",\"message\":{\"role\":\"assistant\",\"content\":\"1.\"},\"done\":false}\n" +
        "{\"model\":\"modelo-falso\",\"created_at\":\"2026-10-28T12:00:01Z\",\"message\":{\"role\":\"assistant\",\"content\":\"\"},\"done\":true,\"done_reason\":\"stop\"," +
        "\"total_duration\":1000,\"load_duration\":10,\"prompt_eval_count\":710,\"prompt_eval_cached_count\":706,\"prompt_eval_duration\":100,\"eval_count\":2,\"eval_duration\":50}\n";

    [Test]
    public async Task ElHandlerLeePromptEvalCachedCount_QueOllamaSharpNoExpone()
    {
        var (chat, servidor) = ClienteContraServidorFalso(NdjsonFijo);
        var lectura = LectorDePrefijoCacheado.Abrir();

        var r = await chat.GetResponseAsync("¿Cuántas localidades hay cargadas en Corrientes?");

        Assert.Multiple(() =>
        {
            Assert.That(servidor.Rutas, Is.EqualTo(new[] { "/api/chat" }));
            Assert.That(r.Text, Is.EqualTo("Hay 1."));
            Assert.That(r.Usage?.InputTokenCount, Is.EqualTo(710));
            Assert.That(r.Usage?.CachedInputTokenCount, Is.Null, "OllamaSharp 5.5.0 no lo expone");
            Assert.That(lectura.TokensDeEntrada, Is.EqualTo(710));
            Assert.That(lectura.TokensCacheados, Is.EqualTo(706), "el handler sí");
        });
    }

    [Test]
    public async Task ElHandlerTambienLeePorStreaming_SinCambiarLosFragmentos()
    {
        var (chat, _) = ClienteContraServidorFalso(NdjsonFijo);
        var lectura = LectorDePrefijoCacheado.Abrir();

        var texto = new StringBuilder();
        await foreach (var u in chat.GetStreamingResponseAsync("¿Cuántas localidades hay cargadas en Corrientes?")) texto.Append(u.Text);

        Assert.That(texto.ToString(), Is.EqualTo("Hay 1."));
        Assert.That(lectura.TokensCacheados, Is.EqualTo(706));
    }

    [Test]
    public async Task SinElCampoEnLaLineaFinal_LaLecturaQuedaNula()
    {
        var (chat, _) = ClienteContraServidorFalso(NdjsonFijo.Replace("\"prompt_eval_cached_count\":706,", ""));
        var lectura = LectorDePrefijoCacheado.Abrir();

        await chat.GetResponseAsync("Hola");

        Assert.That((lectura.TokensDeEntrada, lectura.TokensCacheados), Is.EqualTo(((int?)710, (int?)null)));
    }

    /// <summary>InputTokenCount menor que el esperado → «contexto truncado», no una respuesta válida.</summary>
    [Test]
    public async Task InputTokenCountMenorQueElEsperado_EsContextoTruncado()
    {
        var falso = new ClienteGuionado { Responder = _ => "3001", TokensDeEntrada = 2050 };
        IChatClient chat = new DetectorDeContextoTruncado(falso);
        var opciones = DetectorDeContextoTruncado.FijarLargoEsperado(new ChatOptions(), 5134);

        var ex = await Assert.ThrowsAsync<ContextoTruncadoException>(() => chat.GetResponseAsync("planilla", opciones));

        Assert.Multiple(() =>
        {
            Assert.That(ex!.Message, Does.StartWith("contexto truncado"));
            Assert.That((ex.Esperado, ex.Recibido), Is.EqualTo((5134L, 2050L)));
            Assert.That(falso.UltimasOpciones?.AdditionalProperties?.ContainsKey(DetectorDeContextoTruncado.ClaveDelLargoEsperado),
                Is.False, "el largo esperado no llega al proveedor");
        });
    }

    [Test]
    public async Task InputTokenCountMenorQueElEsperado_PorStreaming_TambienEsContextoTruncado()
    {
        IChatClient chat = new DetectorDeContextoTruncado(new ClienteGuionado { Responder = _ => "3001", TokensDeEntrada = 2050 });
        var opciones = DetectorDeContextoTruncado.FijarLargoEsperado(new ChatOptions(), 5134);

        await Assert.ThrowsAsync<ContextoTruncadoException>(async () =>
        {
            await foreach (var _ in chat.GetStreamingResponseAsync("planilla", opciones)) { }
        });
    }

    [TestCase(5134L)]
    [TestCase(null)]
    public async Task ConElLargoCompletoOSinLargoEsperado_LaRespuestaPasa(long? esperado)
    {
        IChatClient chat = new DetectorDeContextoTruncado(new ClienteGuionado { Responder = _ => "3001", TokensDeEntrada = 5134 });
        var opciones = esperado is long e ? DetectorDeContextoTruncado.FijarLargoEsperado(new ChatOptions(), e) : new ChatOptions();

        Assert.That((await chat.GetResponseAsync("planilla", opciones)).Text, Is.EqualTo("3001"));
    }

    private static (IChatClient Chat, ServidorFalso Servidor) ClienteContraServidorFalso(string ndjson)
    {
        var servidor = new ServidorFalso(ndjson);
        var http = new HttpClient(new LectorDePrefijoCacheado { InnerHandler = servidor }) { BaseAddress = new Uri("http://servidor-falso") };
        return (new OllamaApiClient(http, "modelo-falso"), servidor);
    }

    private sealed class ServidorFalso(string ndjson) : HttpMessageHandler
    {
        public List<string> Rutas { get; } = [];

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Rutas.Add(request.RequestUri!.AbsolutePath);
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ndjson, Encoding.UTF8, "application/x-ndjson"),
            });
        }
    }
}
