using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Options;
using MovilidadUrbana.ApiWeb.Application.Abstractions;
using MovilidadUrbana.Ejemplos.AgenteConAprobacion.Application.Asistente;
using MovilidadUrbana.Ejemplos.AgenteConAprobacion.Infrastructure.AI.Aprobaciones;

namespace MovilidadUrbana.Ejemplos.AgenteConAprobacion.Infrastructure.AI;

/// <summary>
/// Agente de MAF con las escrituras envueltas en <see cref="ApprovalRequiredAIFunction"/> y el contrato de
/// aprobación A1–A5: almacén sólo en el servidor (A1); id aleatorio atado a sesión y conversación (A2);
/// un solo uso y vencimiento (A3); la entidad se vuelve a leer al ejecutar (A4); pruebas de aprobación
/// forjada, de sesión alterada y de dos sesiones (A5, en Cableado/).
/// </summary>
public sealed class AsistenteConAprobacion(
    IChatClient chat,
    HerramientasDeLocalidades herramientas,
    AutorizacionDeEscritura autorizacion,
    AlmacenDeAprobaciones aprobaciones,
    AlmacenDeConversaciones conversaciones,
    ISessionContext sesionActual,
    TimeProvider reloj,
    IOptions<OpcionesDeIA> opciones) : IAsistenteConAprobacion
{
    private readonly OpcionesDeIA _ia = opciones.Value;

    public async Task<RespuestaDelAsistente> ConversarAsync(string sessionId, string conversacionId, string texto, CancellationToken ct = default)
    {
        ValidarIdentidad(sessionId, conversacionId);
        if (texto.Length > _ia.LargoMaximoDeEntrada) // CTRL-15: antes de llamar al modelo
            return new($"El pedido supera los {_ia.LargoMaximoDeEntrada} caracteres.", null);
        if (aprobaciones.HayPendiente(sessionId, conversacionId))
            return new("Hay una acción esperando tu aprobación; aprobala o rechazala antes de seguir.", null);

        var agente = CrearAgente();
        AgentSession sesion = conversaciones.Leer(sessionId, conversacionId) is { } estado
            ? await agente.DeserializeSessionAsync(estado, cancellationToken: ct)
            : await agente.CreateSessionAsync(ct);

        AgentResponse respuesta = await agente.RunAsync(texto, sesion, OpcionesDeEjecucion(), ct);
        return await CerrarTurnoAsync(agente, sesion, respuesta, sessionId, conversacionId, ct);
    }

    public async Task<RespuestaDelAsistente> ResolverAsync(string sessionId, string conversacionId, string idDeAprobacion, bool aprobado, CancellationToken ct = default)
    {
        ValidarIdentidad(sessionId, conversacionId);
        // A2 y A3: existe, es de esta sesión y conversación, no venció; y se consume.
        if (aprobaciones.Tomar(idDeAprobacion, sessionId, conversacionId) is not { } guardada)
            return new("No hay ninguna aprobación vigente con ese id en esta conversación.", null);
        if (conversaciones.Leer(sessionId, conversacionId) is not { } estado)
            return new("La conversación venció.", null);

        var agente = CrearAgente();
        AgentSession sesion = await agente.DeserializeSessionAsync(estado, cancellationToken: ct);

        // La respuesta se arma con la llamada que guardó el servidor, nunca con datos del cliente.
        var decision = new ToolApprovalResponseContent(guardada.RequestId, aprobado, guardada.Llamada);
        if (aprobado) autorizacion.Habilitar(guardada.Llamada.Name, guardada.ClaveDeArgumentos);
        try
        {
            AgentResponse respuesta = await agente.RunAsync(new ChatMessage(ChatRole.User, [decision]), sesion, OpcionesDeEjecucion(), ct);
            return await CerrarTurnoAsync(agente, sesion, respuesta, sessionId, conversacionId, ct);
        }
        finally
        {
            autorizacion.Revocar();
        }
    }

    private AIAgent CrearAgente() =>
        chat.AsAIAgent(instructions: Instrucciones.DelAsistente, name: "AsistenteDeLocalidades", tools: herramientas.Catalogo());

    private ChatClientAgentRunOptions OpcionesDeEjecucion() => new(FabricaDeOpcionesDeChat.Crear(_ia));

    /// <summary>
    /// Si el modelo pidió una escritura, la registra como pendiente y corta el turno. Si lo pedido no se puede
    /// mostrar (id que no existe en esta sesión, argumentos inválidos), lo rechaza sin preguntarle a la persona.
    /// </summary>
    private async Task<RespuestaDelAsistente> CerrarTurnoAsync(
        AIAgent agente, AgentSession sesion, AgentResponse respuesta, string sessionId, string conversacionId, CancellationToken ct)
    {
        for (int rechazos = 0; ; rechazos++)
        {
            var pedidos = respuesta.Messages.SelectMany(m => m.Contents).OfType<ToolApprovalRequestContent>().ToList();
            if (pedidos.Count == 0)
            {
                await GuardarAsync(agente, sesion, sessionId, conversacionId, ct);
                return new(respuesta.Text, null);
            }

            // Una aprobación por vez: si el modelo pidió varias, las demás quedan sin respuesta y MAF las rechaza.
            var pedido = pedidos[0];
            var llamada = (FunctionCallContent)pedido.ToolCall;
            if (await herramientas.DescribirAsync(llamada, ct) is { } descripcion)
            {
                var vigencia = TimeSpan.FromMinutes(_ia.Aprobaciones.VencimientoDeAprobacionMinutos);
                var id = aprobaciones.Registrar(sessionId, conversacionId, pedido.RequestId, llamada, vigencia);
                await GuardarAsync(agente, sesion, sessionId, conversacionId, ct);
                return new(respuesta.Text, new AprobacionPendiente(id, llamada.Name, descripcion, reloj.GetUtcNow() + vigencia));
            }

            if (rechazos >= _ia.Herramientas.MaximoDeIteraciones)
            {
                await GuardarAsync(agente, sesion, sessionId, conversacionId, ct);
                return new("No pude armar una acción válida para ese pedido.", null);
            }
            var rechazo = pedidos.Select(p => (AIContent)p.CreateResponse(false, "No existe en esta sesión o los datos no son válidos.")).ToList();
            respuesta = await agente.RunAsync(new ChatMessage(ChatRole.User, rechazo), sesion, OpcionesDeEjecucion(), ct);
        }
    }

    private async Task GuardarAsync(AIAgent agente, AgentSession sesion, string sessionId, string conversacionId, CancellationToken ct)
    {
        var estado = await agente.SerializeSessionAsync(sesion, cancellationToken: ct);
        conversaciones.Guardar(sessionId, conversacionId, estado, TimeSpan.FromMinutes(_ia.Aprobaciones.VencimientoDeConversacionMinutos));
    }

    private void ValidarIdentidad(string sessionId, string conversacionId)
    {
        // El repositorio filtra por la sesión del ámbito: la clave del almacén tiene que ser la misma.
        if (sessionId != sesionActual.Id) throw new InvalidOperationException("La sesión no coincide con la del ámbito.");
        if (string.IsNullOrWhiteSpace(conversacionId) || conversacionId.Length > 64)
            throw new ArgumentException("ConversacionId inválido.", nameof(conversacionId));
    }
}
