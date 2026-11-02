// Pegado literal de N6 §4.1–§4.4 (BIT-16 Nucleos/N6). Sólo se agregan los using y el «andamiaje»
// mínimo (clase contenedora y variables libres como parámetros) que el snippet da por supuestos.
using System.ComponentModel;
using System.Text;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using CommunityToolkit.VectorData.InMemory;
using MovilidadUrbana.ApiWeb.Application;
using MovilidadUrbana.ApiWeb.Application.Encuestas;
using MovilidadUrbana.ApiWeb.Application.Localidades;
using MovilidadUrbana.ApiWeb.Domain;

namespace SnippetsN6;

// ---- §4.1 (literal) ----
public sealed class HerramientasDeLocalidad(LocalidadService service)
{
    [Description("Da de alta una localidad. Devuelve el resultado de la validación del dominio.")]
    public async Task<object> AgregarAsync(
        [Description("Nombre de la localidad")] string nombre,
        [Description("Una de: Buenos Aires, Chaco, Córdoba, Corrientes, Entre Ríos, Mendoza, Santa Fe")] string provincia,
        [Description("Código postal de 4 dígitos")] string codigoPostal,
        [Description("Cantidad de habitantes, entero ≥ 1")] int habitantes)
    {
        Result r = await service.SaveAsync(new LocalidadModel
            { Nombre = nombre, Provincia = provincia, CodigoPostal = codigoPostal, Habitantes = habitantes });
        return new { r.IsSuccess, r.Message, r.Errors };   // el modelo lee los errores y puede corregir
    }

    public IList<AITool> Crear() => [AIFunctionFactory.Create(AgregarAsync, "agregar_localidad")];
}

public static class Andamiaje
{
    public static async Task S41(IChatClient innerClient, HerramientasDeLocalidad herramientas, string pedidoDelUsuario)
    {
        // ---- §4.1 segunda parte (literal) ----
        IChatClient chat = innerClient.AsBuilder().UseFunctionInvocation().Build();
        var options = new ChatOptions { Tools = herramientas.Crear() };
        ChatResponse resp = await chat.GetResponseAsync(pedidoDelUsuario, options);
    }

    public static async Task S42(IChatClient chat, string textoDelUsuario, EncuestaService encuestaService)
    {
        // ---- §4.2 (literal) ----
        ChatResponse<EncuestaPaso2Propuesta> r = await chat.GetResponseAsync<EncuestaPaso2Propuesta>(
            $"Extraé los medios de transporte y la frecuencia. Medios válidos: " +
            $"{string.Join(", ", Catalogos.Medios.Select(m => m.Clave))}. Frecuencias válidas: " +
            $"{string.Join(", ", Catalogos.Frecuencias.Select(f => f.Clave))}.\nTexto: {textoDelUsuario}");

        var desconocidos = r.Result.Medios.Where(m => !Catalogos.Medios.Any(c => c.Clave == m)).ToList();
        var model = new EncuestaModel { Frecuencia = r.Result.Frecuencia };
        foreach (var m in r.Result.Medios.Except(desconocidos)) model.AlternarMedio(m, elegido: true);
        var errores = new Dictionary<string, string>(encuestaService.ValidarPaso(2, model));
        if (desconocidos.Count > 0) errores["medios"] = $"Medios fuera del catálogo: {string.Join(", ", desconocidos)}";
    }

    public static async Task S43(IEmbeddingGenerator<string, Embedding<float>> embeddings, string pregunta, StringBuilder contexto)
    {
        // ---- §4.3 (literal) ----
        var store = new InMemoryVectorStore(new() { EmbeddingGenerator = embeddings });
        var col = store.GetCollection<string, Fragmento>("ayuda");
        await col.EnsureCollectionExistsAsync();
        await col.UpsertAsync([
            new() { Id = "loc-cp",   Fuente = "LocalidadPolicy.RequisitoDelCodigoPostal", Texto = LocalidadPolicy.RequisitoDelCodigoPostal, Embedding = "Código postal: " + LocalidadPolicy.RequisitoDelCodigoPostal },
            new() { Id = "enc-edad", Fuente = "EncuestaPolicy.RequisitoDeLaEdad",        Texto = EncuestaPolicy.RequisitoDeLaEdad,        Embedding = "Edad: " + EncuestaPolicy.RequisitoDeLaEdad },
        ]);
        await foreach (var hit in col.SearchAsync(pregunta, top: 3))
            contexto.AppendLine($"[{hit.Record.Fuente}] {hit.Record.Texto}");
    }

    public static async Task S44(IChatClient chatClient, LocalidadService localidadService, bool aprobado)
    {
        // ---- §4.4 (literal) ----
        AIFunction baja = new ApprovalRequiredAIFunction(
            AIFunctionFactory.Create((int id) => localidadService.DeleteAsync(id), "eliminar_localidad",
                "Elimina una localidad por Id. Requiere aprobación de la persona."));

        AIAgent agente = chatClient.AsAIAgent(instructions: "Asistente del ABM de localidades.", tools: [baja]);
        AgentSession session = await agente.CreateSessionAsync();
        AgentResponse resp = await agente.RunAsync("Borrá Resistencia", session);

        var pedido = resp.Messages.SelectMany(m => m.Contents).OfType<ToolApprovalRequestContent>().FirstOrDefault();
        if (pedido is not null)
            resp = await agente.RunAsync(new ChatMessage(ChatRole.User, [pedido.CreateResponse(aprobado)]), session);
    }
}

// ---- §4.2 tipo (literal) ----
public sealed record EncuestaPaso2Propuesta(string[] Medios, string Frecuencia);

// ---- §4.3 tipo (literal) ----
public sealed class Fragmento
{
    [VectorStoreKey] public string Id { get; set; } = "";
    [VectorStoreData] public string Fuente { get; set; } = "";
    [VectorStoreData] public string Texto { get; set; } = "";
    [VectorStoreVector(384)] public string Embedding { get; set; } = "";
}
