using Microsoft.Extensions.AI;
using Microsoft.Extensions.Options;
using MovilidadUrbana.Ejemplos.ChatBasico.Configuracion;

namespace MovilidadUrbana.Ejemplos.ChatBasico.Conversacion;

/// <summary>
/// Una conversación con el modelo sobre la encuesta de Movilidad Urbana. El historial es
/// explícito: el servicio no guarda estado en el servidor, lo manda entero en cada pedido.
/// </summary>
public sealed class AsistenteDeMovilidad(IChatClient chat, IOptions<OpcionesDeIA> opciones)
{
    // Los requisitos, tal como los enuncia la política del caso base (LocalidadPolicy).
    public const string InstruccionesDelSistema =
        "Sos el asistente de la encuesta de Movilidad Urbana. Respondé en español, en una o dos oraciones. " +
        "Requisitos para cargar una localidad: " +
        "nombre: entre 3 y 60 caracteres, único por provincia; " +
        "provincia: una de las provincias del catálogo (Buenos Aires, Chaco, Córdoba, Corrientes, Entre Ríos, Mendoza, Santa Fe); " +
        "código postal: 4 dígitos; " +
        "habitantes: un número entero de 1 en adelante.";

    private readonly List<ChatMessage> _historial = [new(ChatRole.System, InstruccionesDelSistema)];

    public IReadOnlyList<ChatMessage> Historial => _historial;

    public async Task<ChatResponse> PreguntarAsync(string texto, CancellationToken ct = default)
    {
        var ia = opciones.Value;
        if (texto.Length > ia.LargoMaximoDeEntrada)
            throw new EntradaDemasiadoLargaException(texto.Length, ia.LargoMaximoDeEntrada); // antes de llamar al modelo

        _historial.Add(new(ChatRole.User, texto));
        ChatResponse respuesta = await chat.GetResponseAsync(_historial, FabricaDeOpcionesDeChat.Crear(ia), ct);
        _historial.AddMessages(respuesta);
        return respuesta;
    }
}

public sealed class EntradaDemasiadoLargaException(int largo, int maximo)
    : Exception($"La entrada tiene {largo} caracteres; el máximo es {maximo}.")
{
    public int Largo { get; } = largo;
    public int Maximo { get; } = maximo;
}
