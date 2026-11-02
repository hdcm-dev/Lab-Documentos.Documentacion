using Microsoft.Extensions.AI;
using Microsoft.SemanticKernel;
using MovilidadUrbana.ApiWeb.Infrastructure.Sessions;
using MovilidadUrbana.Ejemplos.AnotacionesPareadas.Application.Resultados;
using MovilidadUrbana.Ejemplos.AnotacionesPareadas.Infrastructure.AI.AgentFramework;
using MovilidadUrbana.Ejemplos.AnotacionesPareadas.Infrastructure.AI.SemanticKernel;
using MovilidadUrbana.Ejemplos.AnotacionesPareadas.Infrastructure.Persistence;
using MovilidadUrbana.Ejemplos.AnotacionesPareadas.SinModelo;

namespace MovilidadUrbana.Ejemplos.AnotacionesPareadas.Tests.Cableado;

/// <summary>Arma las dos variantes sobre el mismo caso de uso y el mismo almacén (una sesión).</summary>
internal sealed class Armado
{
    public RespuestasEnMemoria Almacen { get; }
    public ResultadosDeEncuestaPlugin Plugin { get; }
    public HerramientasDeResultados Herramientas { get; }
    public ClienteGuionado Chat { get; }
    public Kernel Kernel { get; }
    public KernelFunction FuncionSk => Kernel.Plugins[AgenteDeSemanticKernel.NombreDelPlugin]["resultados_por_medio"];
    public AIFunction FuncionMaf => Herramientas.ComoAIFunction();

    public Armado(bool usarNombreOfrecido = true, bool conInvocacionDeFunciones = true)
    {
        var sesion = new SessionContext();
        sesion.Set("sesion-a");
        Almacen = new RespuestasEnMemoria(sesion);
        var consulta = new ConsultaDeResultadosPorMedio(Almacen);
        Plugin = new ResultadosDeEncuestaPlugin(consulta);
        Herramientas = new HerramientasDeResultados(consulta);
        Chat = new ClienteGuionado(
            HerramientasDeResultados.ResultadosPorMedio,
            new Dictionary<string, object?> { ["localidad"] = "Corrientes" },
            usarNombreOfrecido);
        Kernel = AgenteDeSemanticKernel.CrearKernel(Chat, Plugin, conInvocacionDeFunciones);
    }
}
