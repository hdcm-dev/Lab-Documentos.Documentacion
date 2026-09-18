# Ciclo 2 — Informe del especialista en Seguridad

- **Objeto:** `Guides/Arquitectura/Dot-NET-Arquitectura-Guide.md` v2.0.0 y `Dot-NET-Arquitectura-Lab/` (capturas, `lab.sh`, `MyProject/`).
- **Mandato (acotado por el jurado del ciclo 1):** §6.5 (autenticación con `DelegatingHandler`, configuración de Blazor WebAssembly en `wwwroot`), filas del Anexo C sobre seguridad o vulnerabilidades, y la exposición de trazas de error en §5.6. No se opina sobre arquitectura ni redacción general.
- **Marco:** `IA.Prompts/Base/Mesa-Evaluadora.md` §3 (evidencia y severidad) y §4.1.4 (mandato).
- **Método:** lectura de las secciones del mandato, contraste con `capturas/L20-regla-sin-traducir.txt`, `capturas/L24-evaluar-dependencia.txt`, `aserciones.log`, `MyProject/src/Backend/MyProject.WebAPI/Program.cs` y con las fuentes externas citadas por la guía (consultadas el 2026-09-18). Trabajo a ciegas respecto de los demás informes del ciclo.

Las líneas citadas corresponden al archivo de la guía (`sed -n`), no a la numeración de la sección.

---

## 1. Hallazgos

### H-SEG-01 — «esa página» de §5.6 no está nombrada ni explicada; el lector no puede saber qué es lo que «no debe habilitarse»

- **Ubicación:** §5.6, línea 713.
- **Evidencia:** E2.
- **Severidad:** S3.
- **Confianza:** 0,85.

**Cita literal (línea 713):**

> El 500 de L20 muestra la traza completa porque la API corre en el entorno `Development`; en producción esa página no debe habilitarse ([Microsoft, 2026e](#ref-microsoft-2026e)).

**Contradicción/omisión.** El `Program.cs` del laboratorio (`MyProject/src/Backend/MyProject.WebAPI/Program.cs`) no contiene ninguna llamada que habilite «esa página»: no hay `UseDeveloperExceptionPage()`. La habilita implícitamente `WebApplication.CreateBuilder` cuando el entorno es `Development`. La fuente citada lo dice así: «ASP.NET Core apps enable the developer exception page by default when both: Running in the `Development` environment [and] The app was created with the current templates, that is, by using `WebApplication.CreateBuilder`» y «Don't enable the Developer Exception Page unless the app is running in the `Development` environment. Don't share detailed exception information publicly when the app runs in production» (https://learn.microsoft.com/en-us/aspnet/core/fundamentals/error-handling-api?view=aspnetcore-10.0, sección *Developer Exception Page*).

Para el lector destinatario (sin conocimientos previos, que «prueba comandos y entiende sus resultados»), la frase deja tres huecos: (a) qué componente produce la traza (tiene nombre: *Developer Exception Page*); (b) cómo se «habilita» o deshabilita si el código no lo menciona (por el valor de `ASPNETCORE_ENVIRONMENT`, que `lab.sh` línea 58 fija en `Development`); (c) qué es exactamente lo que se filtraría. Sobre (c), la captura `L20-regla-sin-traducir.txt` muestra rutas absolutas del sistema de archivos (`/tmp/work/MyProject/src/Backend/MyProject.Domain/Productos/Producto.cs:line 20`), nombres de espacios de nombres y clases internas, y la fuente dice que la página puede incluir además «Query string parameters, Cookies, Headers».

La afirmación de la guía es verdadera; el hallazgo es que, tal como está, no es verificable ni accionable por el lector: no puede comprobar dónde se habilita ni qué debe cambiar.

**Reemplazar (línea 713):**

> *Salidas registradas: `capturas/L19-json-mal-formado.txt`, `capturas/L20-regla-sin-traducir.txt`, `capturas/L21-regla-traducida.txt`, SDK 10.0.400.* El 500 de L20 muestra la traza completa porque la API corre en el entorno `Development`; en producción esa página no debe habilitarse ([Microsoft, 2026e](#ref-microsoft-2026e)). La traducción vive en el borde, en la WebAPI:

**por:**

> *Salidas registradas: `capturas/L19-json-mal-formado.txt`, `capturas/L20-regla-sin-traducir.txt`, `capturas/L21-regla-traducida.txt`, SDK 10.0.400.* El 500 de L20 trae la traza completa porque la produce la *página de excepciones del desarrollador* (`DeveloperExceptionPageMiddleware`), que `WebApplication.CreateBuilder` activa por sí sola cuando la variable de entorno `ASPNETCORE_ENVIRONMENT` vale `Development`; el `Program.cs` del laboratorio no la nombra, y el laboratorio arranca la API con ese valor (L13: `Hosting environment: Development`). Esa traza expone rutas del sistema de archivos, nombres de clases internas y, según el caso, cabeceras y cookies de la petición, por lo que no debe estar activa fuera de `Development`: alcanza con no fijar ese valor en producción, y Microsoft indica no compartir públicamente el detalle de las excepciones ([Microsoft, 2026e](#ref-microsoft-2026e)). Con el manejador de L21 la excepción del dominio ya no llega a esa página. La traducción vive en el borde, en la WebAPI:

Nota para el cuerpo auditor: la frase «L13: `Hosting environment: Development`» está respaldada por `aserciones.log` línea 36 (`PASS L13 entorno Development`) y por `capturas/L13-arranque.txt`.

---

### H-SEG-02 — El `AuthorizationMessageHandler` ilustrativo agrega el token a *toda* petición, sin importar el destino, y su nombre colisiona con la clase del framework que existe justamente para evitarlo

- **Ubicación:** §6.5, línea 826 (viñeta «Autenticación») y fragmento líneas 829–845.
- **Evidencia:** E3 (contraejemplo) + E2 (fuente externa).
- **Severidad:** S3.
- **Confianza:** 0,8.

**Cita literal (línea 826):**

> Un `DelegatingHandler` es un eslabón de la cadena de `HttpClient` que agrega el encabezado `Authorization` a cada petición.

y el fragmento (líneas 837–842) agrega `Bearer {token}` a todo `HttpRequestMessage` sin inspeccionar `request.RequestUri`.

**Contraejemplo.** Un `HttpClient` configurado con ese handler que, además de `/api/productos`, descargue un recurso de un tercero (`https://cdn.ejemplo.com/logo.png`, o una URL que llegue en datos de la API), enviará el token portador al tercero. Un token portador (*bearer*) sirve a quien lo posea; con él el tercero puede llamar a la API en nombre del usuario mientras el token siga vigente. La guía dice que el tema «queda fuera», pero el fragmento igual queda como modelo a copiar, y el PO pidió que «una persona sin conocimientos» lo entienda: el riesgo no es visible para ese lector.

**Fuente.** Blazor WebAssembly trae una clase con el mismo nombre, `Microsoft.AspNetCore.Components.WebAssembly.Authentication.AuthorizationMessageHandler`, cuyo `ConfigureHandler(authorizedUrls: …)` existe para acotar esto: «The access token is only attached if at least one of the authorized URLs is a base of the request URI», y el derivado `BaseAddressAuthorizationMessageHandler` viene «preconfigured with the app's base address as an authorized URL. **Access tokens are only added when the request URI is within the app's base URI.**» (https://learn.microsoft.com/en-us/aspnet/core/blazor/security/webassembly/additional-scenarios?view=aspnetcore-10.0, secciones *Custom AuthorizationMessageHandler class* y *Configure AuthorizationMessageHandler*). Además, si el lector pega la clase en un proyecto WASM que ya referencia ese paquete, tendrá dos tipos con el mismo nombre simple; el fragmento no está compilado (la guía lo declara), así que ese choque no fue probado en el laboratorio.

**Reemplazar (línea 826):**

> - **Autenticación.** Un `DelegatingHandler` es un eslabón de la cadena de `HttpClient` que agrega el encabezado `Authorization` a cada petición. Qué emite el token y cómo se valida es tema de seguridad y queda fuera de esta guía.

**por:**

> - **Autenticación.** Un `DelegatingHandler` es un eslabón de la cadena por la que pasa cada petición de `HttpClient` antes de salir; el de este ejemplo agrega el encabezado `Authorization` con un token portador (*bearer*). Un token portador sirve a quien lo tenga, así que el handler debe agregarlo solo a las peticiones dirigidas a la API propia y nunca a otros orígenes; en Blazor WebAssembly el framework ya provee `AuthorizationMessageHandler` y `BaseAddressAuthorizationMessageHandler`, que lo agregan únicamente cuando la URL de la petición está bajo una lista de URLs autorizadas ([Microsoft, 2026i](#ref-microsoft-2026i)). Qué emite el token y cómo se valida es tema de seguridad y queda fuera de esta guía.

**Reemplazar (fragmento, líneas 831–845)** el nombre de la clase y la condición:

> ```csharp
> public class AuthorizationMessageHandler : DelegatingHandler
> {
>     private readonly Func<Task<string?>> _obtenerToken;
>
>     public AuthorizationMessageHandler(Func<Task<string?>> obtenerToken) => _obtenerToken = obtenerToken;
>
>     protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
>     {
>         var token = await _obtenerToken();
>         if (!string.IsNullOrEmpty(token))
>             request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
>         return await base.SendAsync(request, ct);
>     }
> }
> ```

**por:**

> ```csharp
> public class TokenDeApiHandler : DelegatingHandler
> {
>     private readonly Func<Task<string?>> _obtenerToken;
>     private readonly Uri _baseDeLaApi; // solo a esta URL se le envía el token
>
>     public TokenDeApiHandler(Func<Task<string?>> obtenerToken, Uri baseDeLaApi)
>         => (_obtenerToken, _baseDeLaApi) = (obtenerToken, baseDeLaApi);
>
>     protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
>     {
>         var token = await _obtenerToken();
>         if (!string.IsNullOrEmpty(token) && _baseDeLaApi.IsBaseOf(request.RequestUri!))
>             request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
>         return await base.SendAsync(request, ct);
>     }
> }
> ```

Y agregar en el Anexo E:

> `<a id="ref-microsoft-2026i"></a>Microsoft. (2026i). *ASP.NET Core Blazor WebAssembly additional security scenarios*. https://learn.microsoft.com/en-us/aspnet/core/blazor/security/webassembly/additional-scenarios?view=aspnetcore-10.0 (consultado el 2026-09-18).`

Observación: el fragmento sigue marcado como «no compilado en el laboratorio», como el original; `Uri.IsBaseOf` es API pública de `System` y `request.RequestUri` es no nulo cuando el `HttpClient` tiene `BaseAddress` o la petición usa URL absoluta. Si el cuerpo auditor prefiere no tocar el código, el reemplazo de la viñeta ya deja la advertencia correcta y con fuente; el cambio de nombre (`TokenDeApiHandler`) es lo mínimo para no colisionar con la clase del framework.

---

### H-SEG-03 — La vulnerabilidad de AutoMapper se cita sin decir qué es ni qué versiones afecta; «corregida en versiones de esa rama» es impreciso y la fila del Anexo C sugiere que solo afecta a 14.0.0

- **Ubicación:** §9.4, línea 1137; tabla §9.4, línea 1143; Anexo C, línea 1223.
- **Evidencia:** E2 (cita del aviso externo).
- **Severidad:** S3.
- **Confianza:** 0,9.

**Citas literales:**

- Línea 1137: «… y la vulnerabilidad está corregida en versiones de esa rama.»
- Línea 1143: «| ¿Vulnerabilidades conocidas? | Alta en 14.0.0 (L24) | Ninguna agregada |»
- Línea 1223: «| AutoMapper | 14.0.0 MIT con vulnerabilidad alta GHSA-rvv3-g6hj-g44x; desde 15.0.0 RPL-1.5 o comercial | …»

**Fuente (https://github.com/advisories/GHSA-rvv3-g6hj-g44x, consultada el 2026-09-18):** título «AutoMapper Vulnerable to Denial of Service (DoS) via Uncontrolled Recursion», CVE-2026-32933, severidad High (CVSS 7.5); versiones afectadas «< 15.1.1» y «>= 16.0.0, < 16.1.1»; corregida en 15.1.1 y 16.1.1. Mecanismo: mapeo recursivo sin límite de profundidad; un objeto anidado (~25 000 niveles) provoca `StackOverflowException`, que no se puede capturar, y el proceso termina.

**Por qué importa.** (a) «Alta en 14.0.0» y la fila del Anexo C dan a entender que la falla es propia de 14.0.0; afecta a *toda* versión anterior a 15.1.1 (incluidas 15.0.0 y 15.1.0, ya con licencia dual) y a 16.0.0–16.1.0. Quien lea la tabla y elija «15.0.0 porque tiene licencia dual y está corregida» adopta una versión vulnerable. (b) El lector destinatario debe «entender los resultados»: `dotnet list package --vulnerable` (L24) imprime solo `High` y la URL; qué significa esa falla (un cliente puede tumbar el proceso con un JSON anidado) es lo que la guía debe explicar. La captura L24 respalda el nivel `High` (`warning NU1903 … known high severity vulnerability`), no el alcance de versiones, que solo está en el aviso.

**Reemplazar (línea 1137):**

> La versión 14.0.0 es la última con licencia MIT; desde la 15.0.0 la licencia es dual, RPL-1.5 o comercial ([Bogard, 2025](#ref-bogard-2025)), y la vulnerabilidad está corregida en versiones de esa rama.

**por:**

> La versión 14.0.0 es la última con licencia MIT; desde la 15.0.0 la licencia es dual, RPL-1.5 o comercial ([Bogard, 2025](#ref-bogard-2025)). La vulnerabilidad informada (GHSA-rvv3-g6hj-g44x, CVE-2026-32933, severidad alta) es una denegación de servicio: el mapeo recurre sin límite de profundidad y un objeto anidado unas 25 000 veces desborda la pila y termina el proceso. Afecta a toda versión anterior a 15.1.1 y a las 16.0.0–16.1.0; está corregida en 15.1.1 y 16.1.1 ([GitHub, 2026](#ref-github-2026)), es decir, solo en versiones con licencia dual.

**Reemplazar (línea 1143):**

> | ¿Vulnerabilidades conocidas? | Alta en 14.0.0 (L24) | Ninguna agregada |

**por:**

> | ¿Vulnerabilidades conocidas? | Alta (DoS) en toda versión < 15.1.1 y en 16.0.0–16.1.0; corregida en 15.1.1 y 16.1.1 (L24) | Ninguna agregada |

**Reemplazar (línea 1223):**

> | AutoMapper | 14.0.0 MIT con vulnerabilidad alta GHSA-rvv3-g6hj-g44x; desde 15.0.0 RPL-1.5 o comercial | [Bogard, 2025](#ref-bogard-2025); [GitHub, 2026](#ref-github-2026); L24 |

**por:**

> | AutoMapper | 14.0.0 es la última MIT; GHSA-rvv3-g6hj-g44x (CVE-2026-32933, alta, DoS) afecta a < 15.1.1 y 16.0.0–16.1.0, corregida en 15.1.1 y 16.1.1; desde 15.0.0 RPL-1.5 o comercial | [Bogard, 2025](#ref-bogard-2025); [GitHub, 2026](#ref-github-2026); L24 |

---

## 2. Revisado y correcto

1. **§6.5, línea 824 (configuración de Blazor WebAssembly).** «…`wwwroot/appsettings.json`, un archivo que se descarga al navegador: quien usa la aplicación puede leerlo y modificarlo, así que no debe contener secretos». Coincide con la fuente citada, que en tres advertencias repite: «Configuration and settings files in the web root (`wwwroot` folder) are visible to users on the client, and users can tamper with the data. **Don't store app secrets, credentials, or any other sensitive data in any web root file.**» (https://learn.microsoft.com/en-us/aspnet/core/blazor/fundamentals/configuration?view=aspnetcore-10.0). La carga desde `wwwroot/appsettings.json` también está en la fuente. Correcto y con fuente.
2. **§5.6, tabla L20 y captura.** La fila L20 («`500` con la traza de `DomainException: El precio debe ser mayor a cero.`», productor «Nadie tradujo la regla») coincide con `capturas/L20-regla-sin-traducir.txt` (`HTTP/1.1 500 Internal Server Error`, `Content-Type: text/plain`, traza que empieza en `MyProject.Domain.Common.DomainException`), con `aserciones.log` líneas 54–55 y con el `Program.cs` de L20 (`lab.sh` líneas 540–553: sin `UseExceptionHandler`). La atribución al entorno `Development` está verificada por `lab.sh` línea 58 (`ASPNETCORE_ENVIRONMENT=Development`) y por la fuente [Microsoft, 2026e]. Que la respuesta sea texto plano y no HTML también es lo documentado para peticiones sin `Accept: text/html`.
3. **§9.4 y Anexo C, fila de AutoMapper, nivel de severidad.** «vulnerabilidad alta» y la salida de `dotnet list package --vulnerable` reproducida en la guía coinciden con `capturas/L24-evaluar-dependencia.txt` (`warning NU1903: Package 'AutoMapper' 14.0.0 has a known high severity vulnerability` y la tabla con `High`) y con el aviso (High, CVSS 7.5). En §6.5 y en el resto de la guía no hay afirmaciones sobre JWT, Identity ni validación de tokens: la guía dice explícitamente que eso queda fuera, y no afirma nada falso al respecto.

---

## 3. Solicitudes de convocatoria (fuera de mandato)

1. **§2.6, línea 306 y 314 (`--no-https`) y §5.5/`Program.cs` (`GetConnectionString("MyProject") ?? "Data Source=myproject.db"`).** Están fuera de mi mandato acotado. La guía ya aclara que `--no-https` es para no configurar certificados en el laboratorio; si el jurado considera que el lector destinatario puede copiar el esqueleto a un despliegue real, convendría que Operación y entrega (o el propio jurado) decida si hace falta una línea que diga que en producción la API va detrás de HTTPS. No emito hallazgo.

---

## 4. Resumen

| Id | Ubicación | Evidencia | Severidad | Confianza |
| --- | --- | --- | --- | --- |
| H-SEG-01 | §5.6, línea 713 | E2 | S3 | 0,85 |
| H-SEG-02 | §6.5, línea 826 y fragmento 831–845 | E3 + E2 | S3 | 0,8 |
| H-SEG-03 | §9.4 líneas 1137 y 1143; Anexo C línea 1223 | E2 | S3 | 0,9 |

Ninguna de las tres reabre DC-1..DC-4 ni DA-1..DA-4: son precisiones de advertencias de seguridad y de alcance de una vulnerabilidad, con texto de reemplazo y fuente.
