namespace MovilidadUrbana.Ejemplos.PruebasConClienteFalso.Application.Abstractions;

/// <summary>
/// Versión de los datos de cada sesión. La caché de respuestas la suma a su clave: una escritura confirmada
/// la incrementa y la próxima pregunta igual ya no acierta. Sólo ve las escrituras que pasan por los casos de
/// uso que la incrementan; un cambio hecho por otro proceso o directo en la base no la mueve.
/// </summary>
public interface IVersionesDeDatos
{
    long Leer(string sesion);

    void Incrementar(string sesion);
}
