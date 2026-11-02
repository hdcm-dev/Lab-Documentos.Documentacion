using MovilidadUrbana.ApiWeb.Application.Encuestas;

namespace MovilidadUrbana.Ejemplos.Orquestacion.Application.Encuesta;

/// <summary>Cuatro encuestas ficticias: una completa y una que falla en cada paso.</summary>
public static class EncuestasDeEjemplo
{
    public static IReadOnlyList<(string Nombre, Func<EncuestaModel> Crear)> Todas { get; } =
    [
        ("completa", () => Completa()),
        ("falla el paso 1 (edad 15)", () => { var e = Completa(); e.Edad = 15; return e; }),
        ("falla el paso 2 (sin medios)", () => { var e = Completa(); e.AlternarMedio("colectivo", false); e.AlternarMedio("bicicleta", false); return e; }),
        ("falla el paso 3 (0 minutos)", () => { var e = Completa(); e.Minutos = 0; return e; }),
    ];

    public static EncuestaModel Completa()
    {
        var e = new EncuestaModel
        {
            Nombre = "Persona de Prueba",
            Edad = 34,
            Localidad = "Corrientes",
            Frecuencia = "diaria",
            Distancia = 5.5,
            Minutos = 25,
            Motivo = "trabajo",
        };
        e.AlternarMedio("colectivo", true);
        e.AlternarMedio("bicicleta", true);
        return e;
    }
}
