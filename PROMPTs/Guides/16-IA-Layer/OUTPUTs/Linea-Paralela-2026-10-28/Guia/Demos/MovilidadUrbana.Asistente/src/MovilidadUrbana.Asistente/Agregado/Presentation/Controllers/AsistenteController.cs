using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Options;
using MovilidadUrbana.ApiWeb.Application.Abstractions;
using MovilidadUrbana.ApiWeb.Controllers;
using MovilidadUrbana.Asistente.Application.Abstractions;
using MovilidadUrbana.Asistente.Application.Encuestas;
using MovilidadUrbana.Asistente.Application.Localidades;
using MovilidadUrbana.Asistente.Infrastructure.AI;
using MovilidadUrbana.Asistente.Presentation.Contracts;

namespace MovilidadUrbana.Asistente.Presentation.Controllers;

/// <summary>
/// Entradas HTTP de la capa de IA. Ninguna escribe: devuelven eventos o propuestas. La sesión es la del
/// encabezado <c>X-Sesion-Id</c> (middleware copiado). Todas pasan por el límite de concurrencia del modelo
/// y rechazan con 400 un texto más largo que <c>AI:LargoMaximoDeEntrada</c>, antes de llamar al modelo.
/// </summary>
[ApiController]
[Route("api/v1")]
[Produces("application/json")]
[EnableRateLimiting(LimitadorDelModelo.Politica)]
public sealed class AsistenteController(IOptions<OpcionesDeIA> opciones, ISessionContext sesion, ILogger<AsistenteController> logger) : ControllerBase
{
    public const string EncabezadoDeConversacion = "X-Conversacion-Id";

    /// <summary>Un turno de conversación. La respuesta es un arreglo JSON de eventos que llega a medida que se produce.</summary>
    [HttpPost("asistente")]
    [ProducesResponseType<IAsyncEnumerable<EventoDto>>(StatusCodes.Status200OK)]
    [ProducesResponseType<ValidationProblemDetails>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
    public ActionResult<IAsyncEnumerable<EventoDto>> Conversar(
        PedidoAlAsistente pedido, [FromServices] IAsistenteDeMovilidad asistente, CancellationToken cancellationToken)
    {
        var errores = ValidarTexto(pedido.Texto);
        var conversacionId = string.IsNullOrWhiteSpace(pedido.ConversacionId) ? Guid.NewGuid().ToString("n") : pedido.ConversacionId.Trim();
        if (conversacionId.Length > 64) errores["conversacionId"] = "El identificador de conversación admite hasta 64 caracteres.";
        if (errores.Count > 0) return BadRequest(ValidationProblems.De(errores));

        Response.Headers[EncabezadoDeConversacion] = conversacionId;
        return Ok(Eventos(asistente.ConversarAsync(sesion.Id, conversacionId, pedido.Texto!, cancellationToken)));
    }

    /// <summary>ESC-03: propone un alta desde texto libre. No guarda: el alta es POST /api/v1/localidades.</summary>
    [HttpPost("localidades/desde-texto")]
    [ProducesResponseType<PropuestaDeAltaDto>(StatusCodes.Status200OK)]
    [ProducesResponseType<ValidationProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PropuestaDeAltaDto>> ProponerAlta(
        PedidoDesdeTexto pedido, [FromServices] ProponerLocalidadDesdeTexto proponer, CancellationToken cancellationToken)
    {
        var errores = ValidarTexto(pedido.Texto);
        if (errores.Count > 0) return BadRequest(ValidationProblems.De(errores));
        var r = await proponer.ProponerAsync(pedido.Texto!, cancellationToken);
        return Ok(new PropuestaDeAltaDto(r.Accion is not null, r.Accion is null ? null : AccionDto.De(r.Accion), r.MotivoDeDescarte));
    }

    /// <summary>ESC-03: normaliza el paso 2 de la encuesta desde texto libre. No registra la encuesta.</summary>
    [HttpPost("encuestas/pasos/2/desde-texto")]
    [ProducesResponseType<PropuestaDePaso2Dto>(StatusCodes.Status200OK)]
    [ProducesResponseType<ValidationProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PropuestaDePaso2Dto>> ProponerPaso2(
        PedidoDesdeTexto pedido, [FromServices] ProponerPaso2DesdeTexto proponer, CancellationToken cancellationToken)
    {
        var errores = ValidarTexto(pedido.Texto);
        if (errores.Count > 0) return BadRequest(ValidationProblems.De(errores));
        return Ok(PropuestaDePaso2Dto.De(await proponer.ProponerAsync(pedido.Texto!, cancellationToken)));
    }

    private Dictionary<string, string> ValidarTexto(string? texto)
    {
        var errores = new Dictionary<string, string>();
        var maximo = opciones.Value.LargoMaximoDeEntrada;
        if (string.IsNullOrWhiteSpace(texto)) errores["texto"] = "Escribí el pedido.";
        else if (texto.Length > maximo) errores["texto"] = $"El pedido admite hasta {maximo} caracteres.";
        return errores;
    }

    public const string FallaDelModelo = "No se pudo completar el pedido: el servidor del modelo no respondió.";

    // Si el modelo falla a mitad de la respuesta, ya se mandaron eventos: se cierra con un evento «error»
    // en lugar de cortar la conexión. El registro lleva el tipo de la excepción, nunca el texto de la persona.
    private async IAsyncEnumerable<EventoDto> Eventos(IAsyncEnumerable<Application.Asistente.EventoDelAsistente> eventos)
    {
        await using var e = eventos.GetAsyncEnumerator();
        while (true)
        {
            EventoDto dto;
            var ultimo = false;
            try
            {
                if (!await e.MoveNextAsync()) yield break;
                dto = EventoDto.De(e.Current);
            }
            catch (Exception ex) when (ex is not OperationCanceledException)
            {
                logger.LogWarning("El asistente no pudo completar el pedido: {Tipo}", ex.GetType().Name);
                dto = new EventoDto("error", null, FallaDelModelo, null, null);
                ultimo = true;
            }
            yield return dto;
            if (ultimo) yield break;
        }
    }
}
