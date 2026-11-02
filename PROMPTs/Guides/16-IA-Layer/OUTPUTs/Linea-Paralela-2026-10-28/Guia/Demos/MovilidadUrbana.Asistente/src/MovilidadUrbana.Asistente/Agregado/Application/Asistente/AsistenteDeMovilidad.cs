using System.Runtime.CompilerServices;
using System.Text;
using MovilidadUrbana.ApiWeb.Application.Abstractions;
using MovilidadUrbana.ApiWeb.Domain;
using MovilidadUrbana.Asistente.Application.Abstractions;
using MovilidadUrbana.Asistente.Application.Ayuda;
using MovilidadUrbana.Asistente.Application.Encuestas;
using MovilidadUrbana.Asistente.Application.Localidades;

namespace MovilidadUrbana.Asistente.Application.Asistente;

/// <summary>
/// Orquesta un turno: el modelo interpreta el pedido y propone; la aplicación decide qué hacer con eso.
/// Las consultas y la ayuda devuelven texto; el alta y la baja devuelven una <see cref="AccionPropuesta"/>
/// validada que la persona confirma con la operación normal de la API. Ninguna rama escribe.
/// Es núcleo: los pasos con modelo llegan por puertos.
/// </summary>
public sealed class AsistenteDeMovilidad(
    IClasificadorDePedido clasificador,
    ProponerLocalidadDesdeTexto proponerAlta,
    ProponerBajaDesdeTexto proponerBaja,
    ProponerPaso2DesdeTexto proponerPaso2,
    IConsultaConHerramientas consulta,
    IAyuda ayuda,
    IHistorialDeConversacion historial,
    ISessionContext sesion) : IAsistenteDeMovilidad
{
    public async IAsyncEnumerable<EventoDelAsistente> ConversarAsync(
        string sessionId, string conversacionId, string texto,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        // Las herramientas leen la sesión del ámbito; el historial, la del pedido. Tienen que ser la misma.
        if (!string.Equals(sessionId, sesion.Id, StringComparison.Ordinal))
            throw new InvalidOperationException("La sesión del pedido no coincide con la sesión del ámbito.");

        var previos = historial.Leer(sessionId, conversacionId);
        var respuesta = new StringBuilder();
        IReadOnlyList<string> fuentes = [];

        yield return new EtapaIniciada("interpretar");
        var intencion = await clasificador.ClasificarAsync(texto, cancellationToken);

        switch (intencion)
        {
            case IntencionDelPedido.Consulta:
                yield return new EtapaIniciada("consultar-datos");
                await foreach (var trozo in consulta.ResponderAsync(previos, texto, cancellationToken))
                {
                    respuesta.Append(trozo);
                    yield return new TextoParcial(trozo);
                }
                break;

            case IntencionDelPedido.Ayuda:
                yield return new EtapaIniciada("leer-requisitos");
                await foreach (var trozo in ayuda.ResponderAsync(previos, texto, cancellationToken))
                {
                    respuesta.Append(trozo);
                    yield return new TextoParcial(trozo);
                }
                fuentes = RequisitosDelDominio.FuentesCitadas(respuesta.ToString());
                break;

            case IntencionDelPedido.Alta:
            {
                yield return new EtapaIniciada("proponer-alta");
                var resultado = await proponerAlta.ProponerAsync(texto, cancellationToken);
                foreach (var evento in Presentar(resultado, respuesta)) yield return evento;
                break;
            }

            case IntencionDelPedido.Baja:
            {
                yield return new EtapaIniciada("proponer-baja");
                var resultado = await proponerBaja.ProponerAsync(texto, cancellationToken);
                foreach (var evento in Presentar(resultado, respuesta)) yield return evento;
                break;
            }

            case IntencionDelPedido.Encuesta:
            {
                yield return new EtapaIniciada("normalizar-encuesta");
                var paso2 = await proponerPaso2.ProponerAsync(texto, cancellationToken);
                var linea = paso2 is null ? AvisosDelAsistente.SinInterpretacion : Describir(paso2);
                respuesta.Append(linea);
                yield return new TextoParcial(linea);
                break;
            }

            default:
                respuesta.Append(AvisosDelAsistente.FueraDeAlcance);
                yield return new TextoParcial(AvisosDelAsistente.FueraDeAlcance);
                break;
        }

        historial.Agregar(sessionId, conversacionId,
            new TurnoDeConversacion(RolDelTurno.Persona, texto),
            new TurnoDeConversacion(RolDelTurno.Asistente, respuesta.ToString()));

        yield return new Final(fuentes);
    }

    private static IEnumerable<EventoDelAsistente> Presentar(ResultadoDePropuesta resultado, StringBuilder respuesta)
    {
        if (resultado.Accion is not { } accion)
        {
            var motivo = resultado.MotivoDeDescarte ?? AvisosDelAsistente.SinInterpretacion;
            respuesta.Append(motivo);
            yield return new TextoParcial(motivo);
            yield break;
        }

        var aviso = accion.Tipo == TipoDeAccion.Baja
            ? "Preparé la baja. No se borró nada: confirmala vos si es la localidad correcta."
            : accion.Datos.Errores.Count == 0
                ? "Preparé el alta con los datos del pedido. No se guardó nada: revisalos y confirmá con «Guardar»."
                : "Preparé el alta, pero hay datos que no pasan los requisitos. Corregilos en el formulario antes de guardar.";
        respuesta.Append(aviso);
        yield return new TextoParcial(aviso);
        yield return accion;
    }

    private static string Describir(PropuestaDePaso2 p)
    {
        var medios = p.Medios.Count == 0 ? "ninguno reconocido" : string.Join(", ", p.Medios.Select(Catalogos.EtiquetaDeMedio));
        var frecuencia = string.IsNullOrEmpty(p.Frecuencia) ? "sin reconocer" : Catalogos.EtiquetaDeFrecuencia(p.Frecuencia);
        var texto = $"Paso 2 de la encuesta, según tu texto. Medios: {medios}. Frecuencia: {frecuencia}.";
        return p.Errores.Count == 0
            ? texto + " Pasa la validación del paso 2."
            : texto + " No pasa la validación: " + string.Join(" ", p.Errores.Values);
    }
}
