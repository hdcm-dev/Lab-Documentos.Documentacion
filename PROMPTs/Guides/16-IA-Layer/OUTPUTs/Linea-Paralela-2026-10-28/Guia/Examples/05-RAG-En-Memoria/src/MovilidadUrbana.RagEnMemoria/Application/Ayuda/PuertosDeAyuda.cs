namespace MovilidadUrbana.RagEnMemoria.Application.Ayuda;

// Puertos del núcleo. No exponen tipos de Microsoft.Extensions.AI ni de Microsoft.Extensions.VectorData:
// los adaptadores de Infrastructure los implementan con IChatClient, IEmbeddingGenerator y el almacén.

/// <summary>Un requisito recuperado, con su puntaje (similitud coseno: mayor es mejor).</summary>
public sealed record FragmentoRecuperado(string Fuente, string Tema, string Texto, double Puntaje);

/// <summary>Búsqueda por significado sobre los requisitos.</summary>
public interface IBuscadorDeRequisitos
{
    Task<IReadOnlyList<FragmentoRecuperado>> BuscarAsync(string consulta, int k, CancellationToken cancellationToken);
}

/// <summary>Lo que devuelve una estrategia de ayuda, con lo que hace falta para evaluarla.</summary>
public sealed record RespuestaDeAyuda(
    string Texto,
    IReadOnlyList<string> FuentesCitadas,
    IReadOnlyList<FragmentoRecuperado> FragmentosEnElPrompt,
    long? TokensDeEntrada,
    long? TokensDeSalida);

/// <summary>ESC-01: preguntas sobre los requisitos del dominio. Dos adaptadores: contexto fijo y RAG.</summary>
public interface IAyuda
{
    Task<RespuestaDeAyuda> ResponderAsync(string pregunta, long? semilla, CancellationToken cancellationToken);
}

/// <summary>Lee las citas «[Fuente]» de una respuesta, sólo las que existen en el corpus, en orden de aparición.</summary>
public static class Citas
{
    public static IReadOnlyList<string> Leer(string texto) =>
        RequisitosDelDominio.Todos
            .Select(r => (r.Fuente, Posicion: texto.IndexOf($"[{r.Fuente}]", StringComparison.Ordinal)))
            .Where(x => x.Posicion >= 0)
            .OrderBy(x => x.Posicion)
            .Select(x => x.Fuente)
            .ToList();
}
