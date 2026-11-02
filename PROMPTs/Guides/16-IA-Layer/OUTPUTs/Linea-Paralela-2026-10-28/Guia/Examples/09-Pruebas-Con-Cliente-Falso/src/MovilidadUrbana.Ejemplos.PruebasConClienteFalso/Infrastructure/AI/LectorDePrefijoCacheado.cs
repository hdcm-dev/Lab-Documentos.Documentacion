using System.Text;
using System.Text.Json.Nodes;

namespace MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Infrastructure.AI;

/// <summary>
/// Lo que informó el servidor en la última línea de <c>/api/chat</c>. OllamaSharp 5.5.0 no expone
/// <c>prompt_eval_cached_count</c> (<c>Usage.CachedInputTokenCount</c> queda <c>null</c>); este registro lo trae.
/// </summary>
public sealed class LecturaDelServidor
{
    public int? TokensDeEntrada { get; internal set; }
    public int? TokensCacheados { get; internal set; }
}

/// <summary>
/// <c>DelegatingHandler</c> del <c>HttpClient</c> del proveedor. Deja pasar la respuesta NDJSON de
/// <c>/api/chat</c> tal cual (también en streaming) y, al ver la línea final (<c>"done": true</c>), copia
/// <c>prompt_eval_count</c> y <c>prompt_eval_cached_count</c> en la <see cref="LecturaDelServidor"/> del flujo
/// actual. Quien quiere la lectura la abre con <see cref="Abrir"/> antes de llamar al cliente de chat.
/// </summary>
public sealed class LectorDePrefijoCacheado : DelegatingHandler
{
    private static readonly AsyncLocal<LecturaDelServidor?> Actual = new();

    /// <summary>Abre una lectura para los pedidos que siguen en este flujo asíncrono.</summary>
    public static LecturaDelServidor Abrir() => Actual.Value = new LecturaDelServidor();

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var respuesta = await base.SendAsync(request, cancellationToken);
        if (Actual.Value is not { } lectura
            || request.RequestUri?.AbsolutePath.EndsWith("/api/chat", StringComparison.Ordinal) != true
            || !respuesta.IsSuccessStatusCode)
            return respuesta;

        var original = respuesta.Content;
        var flujo = new FlujoQueLeeLaLineaFinal(await original.ReadAsStreamAsync(cancellationToken), lectura);
        var nuevo = new StreamContent(flujo);
        foreach (var encabezado in original.Headers) nuevo.Headers.TryAddWithoutValidation(encabezado.Key, encabezado.Value);
        respuesta.Content = nuevo;
        return respuesta;
    }

    /// <summary>Pasa los bytes sin tocarlos y mira cada línea completa.</summary>
    private sealed class FlujoQueLeeLaLineaFinal(Stream interno, LecturaDelServidor lectura) : Stream
    {
        private readonly MemoryStream _linea = new();

        public override async ValueTask<int> ReadAsync(Memory<byte> buffer, CancellationToken cancellationToken = default)
        {
            int n = await interno.ReadAsync(buffer, cancellationToken);
            Mirar(buffer.Span[..n], fin: n == 0);
            return n;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int n = interno.Read(buffer, offset, count);
            Mirar(buffer.AsSpan(offset, n), fin: n == 0);
            return n;
        }

        private void Mirar(ReadOnlySpan<byte> bytes, bool fin)
        {
            foreach (var b in bytes)
            {
                if (b == (byte)'\n') { Procesar(); continue; }
                _linea.WriteByte(b);
            }
            if (fin) Procesar();
        }

        private void Procesar()
        {
            if (_linea.Length == 0) return;
            var texto = Encoding.UTF8.GetString(_linea.GetBuffer(), 0, (int)_linea.Length);
            _linea.SetLength(0);
            if (!texto.Contains("\"done\"", StringComparison.Ordinal)) return;
            try
            {
                if (JsonNode.Parse(texto) is JsonObject linea && linea["done"]?.GetValue<bool>() == true)
                {
                    lectura.TokensDeEntrada = (int?)linea["prompt_eval_count"];
                    lectura.TokensCacheados = (int?)linea["prompt_eval_cached_count"];
                }
            }
            catch (System.Text.Json.JsonException) { /* una línea que no es JSON no es la final */ }
        }

        public override bool CanRead => true;
        public override bool CanSeek => false;
        public override bool CanWrite => false;
        public override long Length => throw new NotSupportedException();
        public override long Position { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        public override void Flush() { }
        public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
        public override void SetLength(long value) => throw new NotSupportedException();
        public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();
        protected override void Dispose(bool disposing) { if (disposing) { interno.Dispose(); _linea.Dispose(); } base.Dispose(disposing); }
    }
}
