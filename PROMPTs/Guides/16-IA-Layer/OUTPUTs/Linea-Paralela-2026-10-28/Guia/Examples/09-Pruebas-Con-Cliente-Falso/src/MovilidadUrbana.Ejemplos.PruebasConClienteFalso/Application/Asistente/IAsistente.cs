namespace MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Application.Asistente;

/// <summary>Puerto del asistente: texto de la persona → texto de respuesta. Sin tipos de Microsoft.Extensions.AI.</summary>
public interface IAsistente
{
    Task<string> PreguntarAsync(string texto, CancellationToken cancellationToken = default);
}

/// <summary>El texto supera <c>AI:LargoMaximoDeEntrada</c>: se rechaza antes de llamar al modelo.</summary>
public sealed class EntradaDemasiadoLargaException(int largo, int maximo)
    : Exception($"La entrada tiene {largo} caracteres; el máximo es {maximo}.")
{
    public int Largo { get; } = largo;
    public int Maximo { get; } = maximo;
}
