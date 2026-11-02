using MovilidadUrbana.ApiWeb.Infrastructure.Sessions;

namespace MovilidadUrbana.Asistente.Presentation.Sesion;

/// <summary>
/// Sesión por cookie para la página de chat. Adaptado de <c>Sessions/SessionMiddleware.cs</c> de
/// MovilidadUrbana.Web (desvío declarado en PROCEDENCIA.md): la ApiWeb copiada identifica la sesión por el
/// encabezado <c>X-Sesion-Id</c>, que elige el cliente; la página usa un identificador que asigna el
/// servidor (el <c>Guid</c> provisorio de <see cref="SessionContext"/>) y lo guarda en una cookie HttpOnly.
/// Corre sólo fuera de <c>/api</c>.
/// </summary>
public sealed class CookieDeSesionMiddleware(RequestDelegate siguiente)
{
    public const string NombreDeLaCookie = "sesion-movilidad";

    public async Task InvokeAsync(HttpContext context, SessionContext session)
    {
        var id = context.Request.Cookies[NombreDeLaCookie];

        // La cookie se emite sólo al pedir un documento: si se emitiera también en los pedidos de css y js,
        // que el navegador lanza en paralelo, la primera visita generaría varios identificadores.
        if (!SessionContext.IsValid(id) && EsUnDocumento(context.Request))
        {
            id = session.Id;
            context.Response.Cookies.Append(NombreDeLaCookie, id, new CookieOptions
            {
                HttpOnly = true,
                IsEssential = true,
                SameSite = SameSiteMode.Lax,
                Path = "/",
                MaxAge = TimeSpan.FromDays(1)
            });
        }

        session.Set(id ?? string.Empty);
        await siguiente(context);
    }

    private static bool EsUnDocumento(HttpRequest peticion) =>
        HttpMethods.IsGet(peticion.Method) &&
        !peticion.Path.StartsWithSegments("/_framework") &&
        !peticion.Path.StartsWithSegments("/_blazor") &&
        !Path.HasExtension(peticion.Path.Value);
}
