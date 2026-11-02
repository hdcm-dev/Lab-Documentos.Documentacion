---
doc_id: EXP0003-F340
doc_type: informe
title: Informe de la comisión CA-4 (arquitectura .NET) — audiencias y ayuda en el punto de uso con políticas, claims, OpenAPI por documento, recursos y anclas, en ASP.NET Core/Blazor, .NET MAUI y paquetes NuGet, con sus controles de CI
status: vigente
origin: agent
confidence: alta en lo que se cita de Microsoft Learn (páginas reabiertas el 2026-11-01, con su fecha de actualización) y en las citas al cuerpo SDEI (00171bd), a K 1.2 y a la prueba de concepto de ayuda por rol, leídas el mismo día; media en las propuestas, rotuladas «criterio propio» donde ninguna fuente las sostiene; ninguna corrida nueva de código
owner: comisión CA-4 (arquitectura .NET) del ciclo 3 de la mesa de la reedición DocsAsCode (expediente 0003)
last_review: 2026-11-01
audience: [presidencia, análisis de decisiones, refutador, jurado del ciclo 3, PO]
traces: [EXP0003-F300, EXP0003-F099, EXP0003-F204]
---

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-01 |
| Autor | Comisión CA-4, a ciegas: no leyó ningún informe de otra comisión (`mesa/31x`–`37x`) |
| Corrige | — |

| Cabecera de comisión | Valor |
| --- | --- |
| Rol | Arquitecto .NET (ASP.NET Core/Blazor, .NET MAUI, servicios y SDK NuGet): cómo se implementan y se verifican las audiencias y la ayuda en el punto de uso |
| Preguntas a cargo (`F300` §7) | A-06, A-09, A-11, A-15; B-02, B-03, B-11, B-12. Se contestan además, más corto, las demás A-nn y B-nn desde esta especialidad (la carta lo pidió) |
| No-competencia | Retórica de la audiencia (CA-5), redacción del microtexto y su estado del arte de UX (CA-6, CA-8), modelo formal de acceso (CA-3). Donde toco eso, lo marco como entrada para esas comisiones, no como hallazgo |
| Norma | `Knowledge-Mesa-De-Expertos-A-Pedido` 3.1 (base de conocimiento del PO) |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | Líneas 1–111 (§0 con el «Mapa de carga»); §2.1 (pasos 2 y 5); §5.1 («LECTURA P0–P3»); §5.2. `Escalas-De-Juicio` §3.3 (clase de ancla). `Mesa-Consulta-A-Un-Tercero`: no cargada, no hay tercero en este encargo |
| Insumos leídos | `F300` entero; `SDEI/TEM-05` entero; `SDEI/TEM-04` §3.4–§3.5; `SDEI/TEM-06` l. 43–96, 149–160; `SDEI/00-Marco.md` §2.5 y §4; `SDEI/99-Anexos/Glosario.md`; `SDEI/99-Anexos/Como-Decidir.md` §2–§4; `SDEI/99-Anexos/Esquema-Frontmatter-Y-Prefijos.md` l. 46, 64; `tools/docs-guard/esquemas/ayuda.schema.json`; la prueba de ayuda por rol (`README.md`, `Web/Program.cs`, `Web/HelpCatalog.cs`, `Web/Components/AyudaContextual.razor`, `Web/AyudaDemo.Web.csproj`); la mini demo (`docs/fichas/RN-LOC-01.md`, `source.lock`); `K` §2.3, §3.2 (D-01, D-13), §5.2; `F099` §5.2 (tabla del libro); `F204` §2, §3, §9 |
| Medios propios | Lectura con `sed`/`grep`; 15 consultas a Microsoft Learn y una búsqueda web, todas el 2026-11-01 (§2) |

**Convención de citas.** Como en `F300`: `SDEI/` = la carpeta del cuerpo en `LD` `00171bd`; `K` = el conocimiento en
curso 1.2; `PAR/` = `SDEI/Examples/Prueba-Ayuda-Por-Rol/`; `MU/` = `SDEI/Examples/MovilidadUrbana-Mini-Demo/`;
`dg/` = `tools/docs-guard/` de `LD`. El servicio del caso es `{servicio-privado}`. Una fuente de Microsoft Learn se
cita como **ML-nn** (tabla de §2, con URL y fecha). Lo que es opinión de esta comisión lleva **[criterio propio]**.

**LECTURA P0–P3** (la de `MEP` §5.1, leída para este caso): **P0**, lo que haría que la documentación restringida se
entregue a quien no corresponde o que impide cumplir el pedido del PO; **P1**, lo que haría que dos implementadores
.NET construyan cosas distintas o que obliga a rehacer; **P2**, una pérdida acotada (un control que falta, un
ejemplo que no cubre); **P3**, claridad.

## Índice

1. [Recomendación en una página](#1-recomendación-en-una-página)
2. [Fuentes consultadas hoy](#2-fuentes-consultadas-hoy)
3. [Hallazgos sobre el objeto](#3-hallazgos-sobre-el-objeto)
4. [Eje A — audiencias](#4-eje-a--audiencias)
5. [Eje B — paneles, portales y formularios](#5-eje-b--paneles-portales-y-formularios)
6. [Propuesta concreta](#6-propuesta-concreta)
7. [Puntuación de la hipótesis y de las alternativas](#7-puntuación-de-la-hipótesis-y-de-las-alternativas)
8. [Riesgos](#8-riesgos)
9. [Qué rehacer: pieza → cambio → motivo → costo → orden](#9-qué-rehacer-pieza--cambio--motivo--costo--orden)
10. [Lo que revisé y está bien](#10-lo-que-revisé-y-está-bien)
11. [Lo no verificado, incidencias y barrido](#11-lo-no-verificado-incidencias-y-barrido)

## 1. Recomendación en una página

1. **La audiencia se resuelve en el servidor como una autorización sobre un recurso, no como un filtro de menú.** En
   ASP.NET Core eso tiene nombre: política (rol o *claim*) para el nivel de acceso, y **autorización basada en
   recursos** para el alcance (aplicación o inquilino), porque el atributo `[Authorize]` se evalúa antes de cargar el
   recurso y no alcanza (ML-03). La página de ayuda, su `.md`, su `llms.txt` y el texto de un campo son el recurso.
2. **La matriz de audiencias sirve si es ejecutable.** Cada fila nombra la política del producto que la hace cumplir
   y de ella salen pruebas de integración negativas (`WebApplicationFactory`, ML-11): por cada pieza restringida y
   cada audiencia que no la alcanza, `404` en la página, el `.md` y el índice. Una tabla que nadie ejecuta es
   visibilidad, no acceso (`SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:48`).
3. **La documentación de API restringida no se sirve con Swagger o Scalar en producción.** Microsoft Learn lo dice
   como práctica de seguridad: las interfaces de OpenAPI «should only be enabled in development environments»
   (ML-07). Lo que sí da la plataforma: varios documentos OpenAPI por **audiencia** («Audiences, such as public and
   internal APIs», ML-01), el endpoint del documento detrás de una política (`MapOpenApi().RequireAuthorization`,
   ML-01) y la generación en el build por documento (ML-01). La trampa: **un endpoint sin nombre de grupo entra en
   todos los documentos** (ML-01); hace falta un control.
4. **Lo que viaja en un paquete (app MAUI, Blazor WebAssembly, paquete NuGet) es público para quien lo tiene.** Learn:
   el contenido autorizado en un cliente «is usually supplied by a secure, authorized web API call to a server API and
   never stored in the app» (ML-09). La ayuda por perfil de la app móvil se baja autorizada y se guarda en caché; en el
   paquete va sólo lo de la audiencia más baja de la app.
5. **El microtexto de un formulario ya tiene fuente única en .NET:** el modelo con anotaciones de datos alimenta la
   validación del formulario Blazor (ML-05), el esquema OpenAPI (`[Description]`, `[Range]`, `[MaxLength]`,
   `[Required]`, ML-04) y la etiqueta, la descripción y el marcador (`[Display(Name, Description, Prompt,
   ResourceType)]`, ML-06; componente `DisplayName` en .NET 11, ML-08). **La traza no va en el recurso:** va en la
   ficha de la regla, con las anclas de nivel 2 que la mini demo ya tiene y que ya dan rojo cuando el texto y la
   regla se separan (`MU/docs/fichas/RN-LOC-01.md:59`).
6. **Sobre la hipótesis de la presidencia:** la sostengo con dos cambios. (a) La matriz no inventa un modelo de acceso:
   cada fila apunta a la política, al documento OpenAPI o al *feed* que la hace cumplir, y de ella salen las pruebas
   negativas. (b) El microtexto no es un canal de `CL-06` con traza en el recurso: es texto del producto, con la regla
   como fuente y la traza en la ficha. Puntaje en §7.

## 2. Fuentes consultadas hoy

Todas abiertas el 2026-11-01. «Act.» es el `updated_at` que la página declaraba ese día.

| Id | Fuente | Act. | Lo que dice, en lo que importa | URL |
| --- | --- | --- | --- | --- |
| ML-01 | Microsoft Learn, *Generate OpenAPI documents* (ASP.NET Core 10) | 2026-10-29 | «generate multiple OpenAPI documents … for different: Audiences, such as public and internal APIs»; `ShouldInclude` decide qué endpoint entra en cada documento, por defecto por `GroupName`; «Any endpoint that hasn't been assigned a group name is included in all OpenAPI documents»; `app.MapOpenApi().RequireAuthorization("ApiTesterPolicy")`; generación en el build con `--document-name` | https://learn.microsoft.com/en-us/aspnet/core/fundamentals/openapi/aspnetcore-openapi |
| ML-02 | Microsoft Learn, *Serve static files in ASP.NET Core apps* | 2026-10-31 | Con el *middleware* de archivos estáticos antes de la autorización, «No authorization checks are performed on the static files»; para servir con autorización, carpeta fuera del *web root* después de `UseAuthorization`, o una acción con `[Authorize]` que devuelve el archivo | https://learn.microsoft.com/en-us/aspnet/core/fundamentals/static-files |
| ML-03 | Microsoft Learn, *Resource-based authorization in ASP.NET Core* | 2026-10-31 | «Attribute evaluation occurs before data binding and before execution of any method that loads a resource. Declarative authorization with an `[Authorize]` attribute doesn't suffice»; `IAuthorizationService.AuthorizeAsync(user, resource, policy)`; `AuthorizationHandler<TRequirement, TResource>` | https://learn.microsoft.com/en-us/aspnet/core/security/authorization/resource-based |
| ML-04 | Microsoft Learn, *Include OpenAPI metadata* | 2026-10-31 | `[Description]` → `description` del esquema; `[Required]` → `required`; `[Range]` → `minimum`/`maximum`; `[MaxLength]` → `maxLength`. En Minimal APIs los atributos «set the metadata in the generated schema but validation must be performed explicitly» | https://learn.microsoft.com/en-us/aspnet/core/fundamentals/openapi/include-metadata |
| ML-05 | Microsoft Learn, *ASP.NET Core Blazor forms validation* | 2026-10-29 | Anotaciones de datos y `DataAnnotationsValidator`; mensajes por campo con `ValidationMessage<TValue>` y resumen con `ValidationSummary`; `ErrorMessage` en el atributo; `AddValidation` (.NET 10) con generador de fuentes | https://learn.microsoft.com/en-us/aspnet/core/blazor/forms/validation |
| ML-06 | Microsoft Learn, *DisplayAttribute Class* (.NET 10) | 2026-05-27 | `Description`: «used to display a description in the UI»; `Prompt`: «used to set the watermark for prompts in the UI»; `ResourceType`: el tipo que contiene los recursos de `ShortName`, `Name`, `Prompt` y `Description` | https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.displayattribute |
| ML-07 | Microsoft Learn, *Use the generated OpenAPI documents* | 2026-10-29 | «As a security best practice on limiting information disclosure, OpenAPI user interfaces (Swagger UI, ReDoc, Scalar) should only be enabled in development environments»; Scalar con `MapScalarApiReference`; *lint* con Spectral sobre el documento generado en el build | https://learn.microsoft.com/en-us/aspnet/core/fundamentals/openapi/using-openapi-documents |
| ML-08 | Microsoft Learn, *What's new in ASP.NET Core 11* | 2026-10-26 | Componente `DisplayName` que lee `[Display]` (recomendado, admite tipo de recurso) o `[DisplayName]`; validación en el cliente para formularios de SSR estático: «The .NET model remains the single source of truth for validation rules»; localización de mensajes con claves `{DeclaringType}_{MemberName}_{AttributeType}_Error` | https://learn.microsoft.com/en-us/aspnet/core/release-notes/aspnetcore-11 |
| ML-09 | Microsoft Learn, *ASP.NET Core Blazor authentication and authorization* | 2026-10-31 | «client-side authentication checks can be bypassed because all client-side code can be modified by users»; `AuthorizeView` sólo decide qué se muestra; el contenido autorizado en un cliente «is usually supplied by a secure, authorized web API call to a server API and never stored in the app» | https://learn.microsoft.com/en-us/aspnet/core/blazor/security/ |
| ML-10 | Microsoft Learn, *Policy-based authorization in ASP.NET Core* | 2026-10-31 | Una política es «a set of one or more authorization requirements»; política de reserva (*fallback*) que exige usuario autenticado, «secure-by-default»; los archivos estáticos servidos antes del *middleware* de autorización no quedan protegidos | https://learn.microsoft.com/en-us/aspnet/core/security/authorization/policies |
| ML-11 | Microsoft Learn, *Integration tests in ASP.NET Core* | 2026-10-31 | `WebApplicationFactory<TEntryPoint>` levanta la app en `TestServer`; un `TestAuthHandler` en `ConfigureTestServices` prueba autenticación y autorización; `AllowAutoRedirect = false` para afirmar el código de estado | https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests |
| ML-12 | Microsoft Learn, *Build accessible apps with semantic properties – .NET MAUI* | 2026-07-16 | `SemanticProperties.Hint` da contexto adicional; en Android no poner `Description` en un `Entry` (rompe TalkBack) y `Hint` «conflicts with the `Entry.Placeholder` property on Android, which both map to the same platform property»; localizar las descripciones de accesibilidad | https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/accessibility |
| ML-13 | Microsoft Learn, *File system helpers – .NET MAUI* | 2026-03-18 | `OpenAppPackageFileAsync` abre, sólo lectura, lo empaquetado como `MauiAsset` (`Resources/Raw`); `CacheDirectory` para datos que el sistema puede borrar; `AppDataDirectory` se respalda (Auto Backup en Android, iCloud en iOS) | https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/storage/file-system-helpers |
| ML-14 | Microsoft Learn, *NuGet pack and restore as MSBuild targets* | 2026-07-20 | `PackageReadmeFile`, sólo Markdown; `pack` copia `.dll`, `.xml` y otras salidas al paquete | https://learn.microsoft.com/en-us/nuget/reference/msbuild-targets |
| ML-15 | Microsoft Learn, *XML API documentation comments* (C#) | 2026-01-20 | `GenerateDocumentationFile` produce el XML; el compilador emite CS1591 por cada miembro público sin comentario; DocFX y otros generan la referencia | https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/ |
| ML-16 | Microsoft Learn, *Manage developer accounts using groups – Azure API Management* | 2026-06-25 | «groups are used to manage the visibility of products to developers in the developer portal»; grupos fijos Administrators, Developers, Guests y grupos propios, por ejemplo por socio | https://learn.microsoft.com/en-us/azure/api-management/api-management-howto-create-groups |
| ML-17 | Microsoft Learn, *Markdown reference for Microsoft Learn* (guía de contribución) | 2024-03-05 | Los comentarios HTML se publican: «Do not put private or sensitive information in HTML comments … they are exposed in the HTML underneath»; *includes* que se reemplazan en el build | https://learn.microsoft.com/en-us/contribute/content/markdown-reference |

**Caso comercial a la vista: Microsoft Learn mismo.** Las fuentes de sus páginas, leídas hoy (ML-01, ML-05, ML-10),
llevan bloques `::: moniker range="aspnetcore-10.0 …"` dentro de un mismo Markdown: una fuente única con
publicación condicional por **versión del producto**. Es visibilidad, no acceso: todas las variantes son públicas, y
la propia guía advierte que un comentario HTML oculto se publica igual (ML-17). Sirve de contraejemplo práctico de
«ocultar no es no entregar».

## 3. Hallazgos sobre el objeto

| Id | Nivel | Ancla | Hallazgo | Impacto si no se corrige | Dirección |
| --- | --- | --- | --- | --- | --- |
| H-01 | P1 | E2 | Hay **dos campos sin vínculo** para lo que el PO llama audiencia: `audience` (tipo de lector del cuerpo: `humano`, `desarrollo`, `persona-usuaria`…, `K`:438-444) y `roles` de la ayuda (rol del producto, `dg/esquemas/ayuda.schema.json`, patrón `^[A-Z][A-Za-z]+$`). Ninguno admite **alcance**, **superficie** ni **nivel de acceso** | Dos implementadores ponen el alcance en lugares distintos (un rol `AdminAppX`, un campo nuevo, una carpeta) | Un solo identificador de audiencia en el frontmatter (`audiencias`), resuelto por la matriz a rol, alcance, superficie y acceso (§6.2) |
| H-02 | P1 | E2 + ML-07 | `F300` A-07 propone «Swagger/Scalar detrás de autorización» como mecanismo. Learn lo desaconseja en producción como práctica contra la divulgación de información (ML-07) | Se adopta como norma algo que la documentación oficial de la plataforma recomienda no hacer | Reformular: documento OpenAPI por audiencia, generado en el build, entregado por el canal restringido (endpoint con política, portal con grupos, paquete privado); la interfaz interactiva sólo en desarrollo (§4, A-07) |
| H-03 | P1 | E3 | Contraejemplo: un servicio con dos documentos OpenAPI (`publico`, `integradores`) y un endpoint nuevo agregado sin `WithGroupName` aparece **en los dos** (ML-01). `PR-6` compara un solo `contracts/openapi.json` (`SDEI/TEM-06-Compuertas-Y-CI.md:95`) y no lo detecta | Fuga de un endpoint restringido al documento público, sin rojo en ningún carril | Control C-API-1 (§6.4): todo endpoint declara grupo; el documento público ⊆ lista de la matriz |
| H-04 | P1 | E2 + ML-09 | `SDEI/00-Marco.md:112` dice que lo del paquete es visible para quien instala, pero ni `TEM-05` ni `K` D-13 dicen **qué** puede ir en el paquete de una app con varios perfiles | La app móvil del caso empaqueta la ayuda de todos los perfiles «para que ande sin red» | Regla: en el paquete, sólo la audiencia mínima de esa superficie; el resto, bajado con autorización y en caché (§4, A-09) |
| H-05 | P1 | E2 | `SDEI/00-Marco.md:153`: Desarrollo (`ACT-SDEI-3`) **no decide** «El texto de la ayuda al usuario final». Si el microtexto vive en un atributo `[Display(Description = "…")]` literal, lo escribe y lo cambia quien escribe el código | Choque de actores en el eje B: el texto de campo queda sin dueño documental | El texto va en un archivo de recursos con dueño documental (`ResourceType`, ML-06); el código sólo nombra la clave (§5, B-02) |
| H-06 | P2 | E2 | `K` D-13 (l. 274) dice que «el texto localizado en archivos de recursos no se ancla», pero la mini demo **ya ancla el símbolo que muestra el texto de ayuda**: fila `muestra` de `MU/docs/fichas/RN-LOC-01.md:59` (`LocalidadPolicy.RequisitoDelNombre` contiene `LargoMaximoDelNombre`), y esa ficha dio rojo en su 1.0 (`:64-67`) | El conocimiento ignora el mecanismo que ya resuelve B-03 y B-05 | Nombrar el rol de ancla `muestra` como el control del microtexto (§5, B-03) |
| H-07 | P2 | E2 | `SDEI/TEM-06-Compuertas-Y-CI.md:159` pone el cruce de rol y el 404 en «pruebas del producto», pero no dice cómo la compuerta sabe que esas pruebas existen y corrieron; para `PR-6` sí lo dice (línea `workflow:` del `source.lock`, `:95`) | Las pruebas de acceso pueden no existir y la compuerta da verde igual | Mismo mecanismo que `PR-6`: la matriz nombra el workflow del producto y la guarda G3 lo exige en verde (§6.4) |
| H-08 | P2 | E2 | La prueba de concepto compara un rol con igualdad (`PAR/Web/Program.cs:40`, `PAR/Web/HelpCatalog.cs:66`): sin jerarquía ni alcance | Como ejemplo de la forma de `{servicio-privado}` (raíz ⊃ administrador de aplicación) no alcanza | Extenderla (A-15, B-12) |
| H-09 | P3 | ML-04 | En Minimal APIs las anotaciones sólo describen el esquema; validar es aparte (ML-04). La ayuda y el contrato pueden prometer un límite que la API no aplica: la misma especie que el 60/80 de `RN-LOC-01` | Divergencia de fondo silenciosa entre ayuda, contrato y comportamiento | Mencionarlo en el capítulo de ayuda; la fila de ancla `verifica` lo cubre |

## 4. Eje A — audiencias

### A-06 Acceso vs. visibilidad: dónde se hace cumplir y cómo se prueba

**Estado del arte (.NET).** ASP.NET Core da cuatro puntos de cumplimiento, y cada nivel de acceso del PO cae en uno:

| Nivel de acceso | Dónde se hace cumplir en .NET | Fuente |
| --- | --- | --- |
| Público | Contenido estático o endpoint con `AllowAnonymous` | ML-02, ML-10 |
| Autenticado en el producto | Política de reserva que exige usuario autenticado («secure-by-default»); la ayuda **fuera** del *web root* o embebida, nunca en `wwwroot` servido antes de `UseAuthorization` | ML-10, ML-02 |
| Restringido por rol, alcance, invitación o credencial | Política con nombre (rol o *claim*, p. ej. `perfil=integrador`) **y**, para el alcance, autorización basada en recursos: el manejador compara el alcance de la página con el *claim* de aplicación o inquilino del usuario | ML-10, ML-03 |
| Interno | No se compila en el producto (decisión de build), como ya dice el cuerpo | `SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:103-105` |

**Cómo se prueba que no se entrega.** Con pruebas de integración en `TestServer` (`WebApplicationFactory`) y un
manejador de autenticación de prueba que fija los *claims* de cada audiencia (ML-11). Por cada par (audiencia,
pieza que no le corresponde): `GET` a la página, al `.md` y al `llms.txt` → `404`, y el título de la pieza **no**
aparece en el cuerpo de ninguna respuesta. Es lo que la prueba de concepto ya muestra a mano
(`SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:170-177`), llevado a una prueba que corre en cada PR. **El 404 en vez de
403** es de `TEM-05` (l. 106); en .NET exige que la comprobación sea imperativa (`AuthorizeAsync` con el recurso,
ML-03) y que el resultado fallido devuelva `NotFound` en lugar del `Forbid` por defecto **[criterio propio]**.

**Qué cubre el cuerpo.** El principio (`SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:48`, `:103-109`) y el caso
(`PAR/Web/Program.cs:34-55`). **Qué no:** el alcance (H-01), la jerarquía (H-08), y que la prueba negativa sea un
artefacto exigido (H-07).

### A-09 Varias superficies del mismo producto

**Una sola fuente, salidas por superficie, y el filtro siempre en el servidor.** Panel web, app móvil, servicio y SDK
leen el mismo catálogo (las páginas con frontmatter), pero cada superficie tiene su **canal** y su **límite de
confidencialidad**:

| Superficie | Canal | Qué puede viajar con ella | Fuente |
| --- | --- | --- | --- |
| Panel Blazor (SSR) | Página, `.md`, `llms.txt`, ayuda contextual por pantalla | Todo, filtrado por el servidor en cada pedido | ML-09 (SSR para garantizar la autorización) |
| Blazor WebAssembly | Igual que el panel, pero el contenido llega por API autorizada | Nada restringido en el *bundle* | ML-09 |
| App .NET MAUI | `MauiAsset` en el paquete; API de ayuda autorizada; caché | En el paquete, sólo la audiencia mínima de la app (lo que cualquier instalación puede leer, ML-13; `SDEI/00-Marco.md:112`). La ayuda por perfil se baja con el token del usuario y se guarda en `CacheDirectory` | ML-13, ML-09 |
| Servicio y API | Documento OpenAPI por audiencia | Lo que la matriz declara para cada documento | ML-01, ML-07 |
| SDK NuGet | `README` del paquete (`PackageReadmeFile`), XML de documentación junto al `.dll` | Todo lo que va en el paquete es de quien puede restaurarlo: un *feed* privado es el nivel de acceso | ML-14, ML-15 |

**Fuera de línea por perfil** **[criterio propio, con apoyo de ML-13]**: la ayuda del perfil se baja autorizada y se
escribe en `CacheDirectory`, no en `AppDataDirectory`: la primera la puede borrar el sistema, pero no es necesaria
para operar; la segunda se respalda en la nube del dispositivo (ML-13). Al cambiar de perfil o cerrar sesión se borra.
La versión de la ayuda en caché es la del servidor que la entregó, con su `ID@versión`; la app muestra la de su
paquete si no hay red.

### A-11 Controles verificables en CI

Ver la tabla completa en §6.4. En resumen: dos controles nuevos en `docs-guard` (vocabulario de audiencias y cruce de
audiencia o alcance en enlaces, éste portado del validador de `PAR/Web/HelpCatalog.cs:103-121`), y cuatro en el
carril del producto exigidos por la guarda (entrega negativa, documento OpenAPI público, interfaz de API en
producción, fuga por paquete).

### A-15 Demo o ejemplo

**Extender `Prueba-Ayuda-Por-Rol`**, no armar otro: ya es .NET 10 Blazor SSR, ya embebe la ayuda como recurso
(`PAR/Web/AyudaDemo.Web.csproj:12`), ya filtra página, `.md` y `llms.txt` con el mismo catálogo
(`PAR/Web/Program.cs:34-55`) y ya está en lo público. Lo que se suma:

| Agregado | Para qué pregunta | Costo |
| --- | --- | --- |
| *Claims* `rol` (Raiz, AdminApp, Usuario) y `app` (dos aplicaciones ficticias) | A-05, A-08 | Bajo |
| Manejador `AuthorizationHandler<AyudaRequirement, HelpPage>` que resuelve rol y alcance contra la matriz | A-06, A-08 | Bajo |
| Una Minimal API con dos documentos OpenAPI (`publico`, `integradores`), el segundo con `RequireAuthorization`, generados en el build | A-07 | Medio |
| Un proyecto de pruebas con `WebApplicationFactory` generado desde la matriz | A-06, A-11 | Medio |
| Un endpoint `/ayuda/api/{perfil}` con el JSON de la ayuda del perfil, y un cliente de prueba que simula la app móvil (la app MAUI real queda opcional: exige *workloads* y, para iOS, runner Mac, `K` D-09) | A-09 | Medio |
| El formulario de B-12 | Eje B | Medio |

### Las demás preguntas del eje A, desde .NET

- **A-01, A-02.** Para la implementación, la audiencia es un **conjunto de atributos del sujeto** contra **atributos
  del recurso**: es la forma de una política con requisitos (ML-10) y de un manejador con recurso (ML-03). Dimensiones
  que se hacen cumplir en el servidor: rol, alcance, nivel de acceso. Dimensiones que eligen el **canal** pero no
  protegen: superficie, idioma, lector humano o agente. Esa partición es la que sirve en código **[criterio propio]**.
- **A-03.** `audience` hoy es tipo de lector; el rol del producto vive en `roles` (H-01). Propongo que la fila
  «Audiencias» de `SDEI/00-Marco.md:108` quede como **ejemplo por escenario** y que la decisión se tome en la matriz.
- **A-04.** La doble audiencia es una dimensión (lector). Para el código no cambia nada: el agente del usuario recibe
  lo mismo que el usuario, por el mismo filtro (`SDEI/TEM-04-Doble-Audiencia.md:196-201`).
- **A-05.** ASP.NET Core no trae herencia de roles **[sin verificar hoy en la página de roles; no la abrí]**. La
  matriz declara `hereda: [AdminApp]` para Raiz y el generador **expande** la jerarquía a listas explícitas antes de
  servir y de probar: así la prueba compara conjuntos y no depende de una herencia en tiempo de ejecución
  **[criterio propio]**. El enlace que cruza niveles se detecta con el validador de `PAR` generalizado (C-AUD-2).
- **A-07.** Tres modos de exposición, y la elección es de una persona (clase H): (1) no se publica (interno, se
  excluye del build con `--document-name`, ML-01); (2) el documento JSON detrás de una política (ML-01), sin
  interfaz interactiva en producción (ML-07); (3) un portal con grupos (por ejemplo Azure API Management, donde los
  grupos manejan la visibilidad de productos por desarrollador o por socio, ML-16) o un paquete privado. Swagger o
  Scalar «detrás de autorización» en producción **no** va como opción recomendada (H-02).
- **A-08.** El alcance es un atributo del recurso (`alcance: app` en la página) y del usuario (*claim* `app`); se
  compara en el manejador con recurso (ML-03). El cruce de alcance se detecta como el cruce de rol, con el par
  (rol, alcance) en lugar del rol solo.
- **A-10.** El `llms.txt` y los `.md` crudos de cada audiencia salen del mismo catálogo y del mismo manejador
  (`PAR/Web/Program.cs:34-55` ya lo hace por rol). Un asistente dentro del producto llama a la API de ayuda **con el
  token del usuario**, nunca con una credencial de servicio que vea todo **[criterio propio]**.
- **A-12.** Decisión nueva en `K` (D-18), no ampliación de D-13: D-13 elige la **forma** de la ayuda; D-18 fija
  **quién ve qué y dónde se hace cumplir**, y afecta también la API y el SDK, que no son ayuda.
- **A-13, A-14.** En §9.

## 5. Eje B — paneles, portales y formularios

### B-02 Fuente única entre especificación, validación y texto de ayuda

**Sí, y .NET ya lo trae.** Un mismo modelo C# alimenta cinco salidas:

| Salida | Mecanismo | Fuente |
| --- | --- | --- |
| Validación del formulario Blazor y su mensaje por campo | Anotaciones (`[Required]`, `[Range]`, `[MaxLength]`), `DataAnnotationsValidator`, `ValidationMessage`, `ErrorMessage` | ML-05 |
| Validación en el navegador en SSR estático (.NET 11) | Metadatos que el servidor emite desde el modelo: «single source of truth» | ML-08 |
| Etiqueta, texto de ayuda y marcador | `[Display(Name, Description, Prompt, ResourceType)]`; componente `DisplayName` (.NET 11) | ML-06, ML-08 |
| Contrato para integradores | `[Description]` → `description`; `[Range]` → `minimum`/`maximum`; `[MaxLength]` → `maxLength`; `[Required]` → `required` | ML-04 |
| App MAUI | El mismo modelo en una biblioteca compartida; el texto va a `SemanticProperties.Hint` o a `Entry.Placeholder`, **no a los dos con valores distintos** en Android | ML-12 |

**Derivar o generar.** Los **límites** (3, 60) se derivan del código: el texto los interpola desde las constantes
(`string.Format(textos["NombreLocalidad.Ayuda"], Min, Max)`), así que no pueden quedar atrás. La **redacción** la
escribe una persona en el archivo de recursos, en la voz del usuario. Eso respeta «derivar no es generar»
(`SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:44`) y la frontera de actores (H-05) **[criterio propio]**. Lo que se pierde si
se **genera** desde el esquema (`description` de OpenAPI → ayuda): el texto queda en la voz del contrato, que es la
del integrador, no la del usuario.

### B-03 Traza `ID@versión` del texto de campo

**No en el recurso: en la ficha de la regla.** El `.resx` no tiene frontmatter. Propongo que la ficha de la regla lleve
una tabla de **campos**, con tres filas de ancla de nivel 2 ya existentes en el cuerpo (`MU/docs/fichas/RN-LOC-01.md:55-62`):

| Rol | Ancla | Afirma |
| --- | --- | --- |
| muestra | `Modelos/Localidad.cs#Localidad.Nombre@SHA` | contiene `ResourceType = typeof(TextosCampos)` y `Description = "NombreLocalidad.Ayuda"` |
| valida | `Modelos/Localidad.cs#Localidad.Nombre@SHA` | contiene `LargoMaximoDelNombre` |
| muestra | `Recursos/TextosCampos.resx#NombreLocalidad.Ayuda@SHA` | contiene `{1}` (el máximo se interpola, no se escribe) |

La fila `RD-` del registro y la página de ayuda siguen trazando a `RN-LOC-01@1.1` como hoy; el **texto de campo**
queda trazado porque la ficha ancla la clave y el control da rojo si el código deja de usarla o si el límite se
escribe a mano. El ancla de un `.resx` por nombre de clave **no existe hoy** en `dg/` **[criterio propio; requiere
expediente de herramienta]**.

### B-11 Implementación en .NET

1. **Modelo compartido** (biblioteca .NET) con anotaciones y `[Display(ResourceType = …)]`; el `.resx` neutro con su
   dueño documental (`CODEOWNERS` sobre la carpeta de recursos) **[criterio propio]**.
2. **Por audiencia:** el texto de un campo que cambia según el rol o el alcance se resuelve en el servidor con un
   servicio `IAyudaDeCampo.Obtener(claveCampo, ClaimsPrincipal)` que usa el mismo manejador de recursos que las
   páginas (ML-03); las claves por audiencia (`NombreLocalidad.Ayuda.Raiz`) caen a la neutra si no existen
   **[criterio propio]**.
3. **Panel Blazor:** SSR para lo restringido (ML-09); `ValidationMessage` para el mensaje (ML-05); el texto de ayuda
   asociado al control con `aria-describedby` (la mecánica y WCAG son de CA-8).
4. **App MAUI:** en el paquete, sólo los textos de la audiencia mínima; los de perfil, por la API de ayuda y en caché
   (A-09). `Hint` y `Placeholder` con el mismo valor en Android (ML-12).
5. **API:** las mismas anotaciones describen el esquema; en Minimal APIs la validación se activa aparte (ML-04, ML-05
   `AddValidation`).

### B-12 Demo o ejemplo

En la `PAR` extendida (A-15): un formulario «Alta de aplicación» con un campo cuyo máximo es distinto para Raiz y
para AdminApp, su ficha `RN-APP-01` con versión y filas de campo, la página de ayuda que traza a `RN-APP-01@1.0`, y un
par rojo/verde: el rojo sube el máximo en el código sin tocar la ficha → la fila `valida` falla; otro rojo escribe
el número a mano en el `.resx` → la fila `muestra` del recurso falla.

### Las demás preguntas del eje B, desde .NET

- **B-01.** Mecanismos de la plataforma: etiqueta (`[Display(Name)]`), descripción (`Description`), marcador
  (`Prompt`), mensaje (`ErrorMessage`, `ValidationMessage`), resumen (`ValidationSummary`), en MAUI `Hint`,
  `Placeholder` y `SemanticScreenReader.Announce` (ML-05, ML-06, ML-12). Qué recomienda o desaconseja la industria
  (marcador en vez de etiqueta, etc.) es de CA-8.
- **B-04.** Desde el código: el microtexto **no** es una página `CL-06`; es parte de la interfaz con su regla como
  fuente. Propongo una variante de `CL-06` con ancla en la ficha («ayuda de campo»), no una clase nueva: la clase nueva
  no trae un control que la variante no tenga **[criterio propio]**.
- **B-05.** Las filas `muestra` y `valida` de la ficha (B-03) son el control: bloquean en el workflow que baja el
  código por SHA (`SDEI/TEM-06-Compuertas-Y-CI.md:158`). Campo obligatorio no anunciado: control C-CAMPO-2 (§6.4).
- **B-06.** Por idioma: `.resx` por cultura; la localización de mensajes por convención de claves llega en .NET 11
  (ML-08). La traducción atrasada se detecta comparando, por clave, la huella del texto neutro con la que declara la
  traducción **[criterio propio; el control no existe, como ya dice `SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:192`]**.
- **B-07.** Identificador de contexto: la prueba de concepto ya usa un tema por pantalla
  (`PAR/Web/Components/AyudaContextual.razor`, parámetro `Tema` → `Catalog.ByTopic`) y no dibuja nada si el rol no
  alcanza la página. Es el patrón: la pantalla nombra el tema, el catálogo resuelve página y audiencia. El vínculo
  pantalla → tema se versiona en el código; un control comprueba que todo `Tema` usado existe en el catálogo
  **[criterio propio]**. El portal de desarrolladores es la salida de A-07.
- **B-08.** Plataformas de guía en producto: fuera de mi especialidad (CA-6). Desde .NET: si se usan, el texto vive
  en su editor y no pasa por el filtro del servidor; la audiencia la decide su segmentación, no la política del
  producto.
- **B-09.** De CA-8. Dato .NET: MAUI pide no poner `Description` en un `Entry` en Android (ML-12).
- **B-10.** Un asistente en el formulario recibe el texto de ayuda **por la misma API y con el token del usuario**
  (A-10); el texto de ayuda pasa por la anti-inyección AI-1 a AI-5 porque es Markdown o recurso del repositorio
  (`SDEI/TEM-04-Doble-Audiencia.md:159-190`). Los `.resx` hoy no los recorre `docs-guard` **[criterio propio:
  ampliar AI-2 a `.resx`]**.

## 6. Propuesta concreta

### 6.1 Definición (para el código)

**Audiencia** (en el sistema documentador): conjunto nombrado de lectores que reciben las mismas piezas por los
mismos canales, definido por los atributos que el producto **hace cumplir** (rol con su jerarquía, alcance, nivel de
acceso) y por los que **eligen el canal** (superficie, lector humano o agente, idioma). Toda audiencia nombra **dónde
se hace cumplir** con un punto verificable del producto. La definición conceptual y su fuente académica son de CA-1 y
CA-5; ésta es la forma que la implementación necesita **[criterio propio]**.

### 6.2 Artefacto: la matriz de audiencias (A-12 de `K`)

Archivo versionado `docs/_gobierno/audiencias.yml` (o tabla con `doc_type` propio), leído por la compuerta y por el
producto. Ejemplo para la forma de `{servicio-privado}`:

```yaml
# [Fragmento ilustrativo: forma de {servicio-privado}; nombres ficticios]
audiencias:
  - id: panel-raiz
    superficie: panel
    rol: Raiz
    hereda: [panel-admin-app]
    alcance: todas
    acceso: restringido-rol
    cumple: { politica: "doc:panel-raiz", recurso: AyudaRequirement }
  - id: panel-admin-app
    superficie: panel
    rol: AdminApp
    alcance: app              # se compara con el claim "app" del usuario
    acceso: restringido-rol
    cumple: { politica: "doc:panel-admin", recurso: AyudaRequirement }
  - id: movil-usuario
    superficie: movil
    rol: Usuario
    alcance: app
    acceso: autenticado
    paquete: minima           # sólo esta audiencia puede ir en el paquete de la app
    cumple: { politica: "doc:movil" }
  - id: integrador
    superficie: api
    acceso: restringido-credencial
    cumple: { openapi: integradores, politica: "api:integrador" }
    expone: { decide: ACT-SDEI-1, clase: H }
  - id: publico
    superficie: [api, sitio]
    acceso: publico
    cumple: { openapi: publico }
pruebas: { workflow: ayuda-acceso.yml }   # H-07: la guarda lo exige en verde
```

**Frontmatter de una página de ayuda** (cambia `ayuda.schema.json`): `audiencias: [panel-admin-app]` reemplaza a
`roles`; `alcance` no va en la página (lo trae la audiencia), salvo una página propia de una aplicación, que declara
`alcance_valor: <app>`.

### 6.3 Dónde se hace cumplir, por canal

| Canal | Punto en .NET | Prueba |
| --- | --- | --- |
| Página, `.md`, `llms.txt` | Manejador con recurso (ML-03) en el *middleware* de ayuda (`PAR/Web/Program.cs:34-55` generalizado) | C-AUD-3 |
| Texto de campo por audiencia | El mismo manejador, en `IAyudaDeCampo` | C-AUD-3 |
| Documento OpenAPI | `AddOpenApi(nombre)`, `ShouldInclude`, `MapOpenApi().RequireAuthorization(...)` (ML-01) | C-API-1, C-API-2 |
| Paquete móvil o WebAssembly | Lo que entra como `MauiAsset` o recurso embebido | C-AUD-5 |
| Paquete NuGet | Visibilidad del *feed* | Ninguna en CI: es configuración del *feed*, clase H |

### 6.4 Controles en CI, con su condición de bloqueo

| Control | Carril | Qué detecta | Bloquea | Par rojo/verde |
| --- | --- | --- | --- | --- |
| C-AUD-1 vocabulario | `docs-guard` `PR-2` | Página con `audiencias` fuera de la matriz, o sin `audiencias` | Sí | Página con `audiencias: [inexistente]` / con una válida |
| C-AUD-2 cruce de audiencia o alcance | `docs-guard` (nuevo, portado de `PAR/Web/HelpCatalog.cs:103-121`) | Enlace desde una página a otra que alguno de sus lectores no alcanza, tras expandir la jerarquía | Sí | El defecto no plantado que ya encontró la prueba (`SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:179-183`) / el enlace quitado |
| C-AUD-3 entrega negativa | Producto, workflow nombrado en la matriz, exigido por G3 | Por cada (audiencia, pieza no permitida): página, `.md` y `llms.txt` ≠ 404, o título presente en la respuesta | Sí | Quitar el filtro del *middleware* / restaurarlo |
| C-AUD-4 interfaz de API en producción | Producto (prueba con el entorno `Production` en `WebApplicationFactory`) | `/swagger` o `/scalar` responden en producción (ML-07) | Sí | Mapear la interfaz fuera del `if (IsDevelopment())` / dentro |
| C-AUD-5 fuga por paquete | Producto (lista del paquete armado) | Un archivo de ayuda en `MauiAsset` o embebido en WebAssembly cuya audiencia no es la `paquete: minima` | Sí | Copiar una página de `panel-raiz` a `Resources/Raw` / quitarla |
| C-API-1 grupo obligatorio | Producto, sobre los documentos generados en el build (ML-01) | Endpoint sin nombre de grupo, u operación del documento `publico` fuera de la lista de la matriz | Sí | Endpoint nuevo sin `WithGroupName` (H-03) / con grupo |
| C-API-2 contrato por documento | `PR-6` ampliado | Diff de cada documento OpenAPI de la matriz, no de uno solo | Sí | Como `PR-6` hoy |
| C-CAMPO-1 anclas del campo | Workflow del producto (como el de `MU`) | Filas `muestra` y `valida` de la ficha (B-03) | Sí | Subir el máximo en el código sin tocar la ficha / tocar la ficha |
| C-CAMPO-2 campo con regla sin ayuda | Producto (reflexión sobre los modelos de formulario) | Propiedad con atributo de validación y sin `Display.Description`, sin excepción con huella | Avisa hasta línea de base 0 (`SDEI/TEM-06-Compuertas-Y-CI.md:107`) | Quitar `Description` / ponerla |
| C-CAMPO-3 traducción atrasada | `docs-guard` o producto | Clave cuya huella neutra cambió después de la traducción | Avisa | Cambiar el texto neutro / actualizar la huella |

## 7. Puntuación de la hipótesis y de las alternativas

Escala, pesos y filtros de `SDEI/99-Anexos/Como-Decidir.md:49-87` (K1–K3, K5–K7 pesan 0,15; K4, 0,10). Ninguna
alternativa cae en los filtros F1–F8. Cada celda cita su observable.

### 7.1 Forma de la decisión de audiencias (§6 puntos 1–4 de `F300`)

| K | H — Matriz de audiencias y acceso (presidencia) | A1 — Matriz ejecutable (esta comisión) | A2 — Sólo campos `roles` + `alcance` en D-13 |
| --- | --- | --- | --- |
| K1 | 3: decisión, tabla y un control | 3: decisión, tabla, generador de pruebas | 4: un campo |
| K2 | 3: el control de cruce de alcance no existe; sin medir | 4: el patrón de 404 está medido en copia (`PAR`, `SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:170-177`) y las pruebas negativas son mecánica documentada (ML-11) | 3: sin medir |
| K3 | 4: una tabla por sistema | 4: una tabla por sistema; las pruebas salen de ella | 3: cada sistema adapta su filtro |
| K4 | 4: un PR mecánico | 3: suma un proyecto de pruebas | 5: menos de una hora |
| K5 | 4: nombra `llms.txt` como canal, sin verificación propia | 5: página, `.md` y `llms.txt` probados con el mismo par | 3: sirve bien al humano |
| K6 | 4: compatible; agrega D-18 | 4: compatible; reusa `workflow:` de `PR-6` y el patrón de `PAR` | 5: reusa `roles` tal cual |
| K7 | 4: el cruce de enlaces se detecta en el PR; la entrega, no | 5: la entrega indebida da rojo en el PR | 3: se detecta a mano |
| **Ponderado** | **3,70** | **4,05** | **3,65** |

Margen A1 sobre H: 0,35. **No corrí la sensibilidad de ±10 %**: la decisión queda **CON REVISIÓN**, con esta condición
comprobable: si la prueba negativa de la `PAR` extendida corre en el carril del producto en menos de lo que tarda hoy
`docs-guard`, A1; si no, H y C-AUD-3 pasa a carril programado. A1 no reemplaza a H: le suma el punto (a) de §1.6.

### 7.2 Clase y control del microtexto (§6 punto 5 de `F300`)

| K | H5 — Canal de `CL-06` con traza en el recurso | B1 — La regla es la fuente; traza en la ficha con anclas de nivel 2 (esta comisión) | B2 — Generar el texto desde el esquema (OpenAPI o JSON Schema) |
| --- | --- | --- | --- |
| K1 | 3: canal, convención de traza en el recurso, control de desfase | 4: filas de ficha; el ancla por clave de `.resx` es la única pieza nueva | 4: un generador |
| K2 | 3: la traza en el recurso no existe en `dg/`; sin medir | 4: el rol `muestra` está medido en `MU` y dio rojo en la 1.0 (`MU/docs/fichas/RN-LOC-01.md:59`, `:64-67`) | 3: sin medir |
| K3 | 4: configuración por sistema | 4: configuración por sistema | 5: un parámetro |
| K4 | 4: PR mecánico | 4: PR mecánico | 4: PR mecánico |
| K5 | 3: sirve al usuario; el agente no ve el recurso | 4: el mismo atributo da la descripción del contrato al integrador (ML-04) | 4: idem |
| K6 | 4: compatible | 5: reusa las anclas de nivel 2 tal cual | 2: choca con «derivar no es generar» (`SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:44`) |
| K7 | 4: traza desfasada en el PR; los números escritos a mano, no | 5: límite interpolado y anclas: rojo determinista en el PR | 5: determinista |
| **Ponderado** | **3,55** | **4,30** | **3,85** |

Margen B1 sobre B2: 0,45; B1 sobre H5: 0,75. Sin sensibilidad corrida: **CON REVISIÓN**, condición: que el expediente de
herramienta pueda anclar una clave de `.resx` por nombre.

## 8. Riesgos

| Riesgo | Dónde | Mitigación |
| --- | --- | --- |
| Creer que el filtro de UI protege (`AuthorizeView`, menú) | Panel | ML-09: sólo decide qué se muestra; C-AUD-3 |
| Ayuda restringida en el *web root* | Panel | ML-02: no hay autorización sobre estáticos servidos antes; embebida o fuera del *web root* |
| Endpoint sin grupo filtrado al documento público | API | ML-01; C-API-1 |
| Interfaz de API abierta en producción | API | ML-07; C-AUD-4 |
| Ayuda de todos los perfiles en el paquete móvil | MAUI | ML-13, ML-09; C-AUD-5 |
| Ayuda de perfil respaldada en la nube del dispositivo | MAUI | ML-13: `CacheDirectory`, no `AppDataDirectory` |
| Credencial de servicio del asistente que ve todo | Asistente en producto | Token del usuario (A-10) |
| `Hint` y `Placeholder` distintos en Android | MAUI | ML-12 |
| Desarrollo redacta el microtexto | Formularios | H-05; `.resx` con dueño documental |
| Contrato que promete un límite que la API no valida | API | ML-04; fila `valida` |
| Falsos rojos de la jerarquía | Compuerta | Expandirla antes de comparar (A-05) |

## 9. Qué rehacer: pieza → cambio → motivo → costo → orden

| Pieza | Cambio | Motivo | Costo | Orden |
| --- | --- | --- | --- | --- |
| `K` D-18 (nueva) | «Matriz de audiencias»: filas con rol, jerarquía, alcance, superficie, canal, acceso y `cumple`; exposición de API clase H | H-01, A-12 | Medio | 1 |
| `K` D-01 | El inventario de autorización (l. 262) suma: *claims* de alcance, documentos OpenAPI y sus grupos, `MauiAsset`, *feeds* | Insumo de D-18 | Bajo | 2 |
| `K` D-13 | Remite a D-18 para quién ve qué; corrige «el texto en recursos no se ancla» (H-06) | H-06 | Bajo | 2 |
| `K` §2.3 | La fila «Audiencias» pasa a ejemplo; la confidencialidad suma «paquete: sólo la audiencia mínima» | H-04 | Bajo | 3 |
| `K` A-01, A-03 | A-01 lista la matriz; A-03 suma el vocabulario de `audiencias` y deja `audience` como tipo de lector | H-01 | Bajo | 3 |
| `SDEI/00-Marco.md` §2.5 y §4 | §2.5: audiencias como ejemplo y regla del paquete; §4: el dueño del microtexto (H-05) | H-04, H-05 | Bajo | 4 |
| `SDEI/TEM-04` | §3.5 suma el asistente con el token del usuario y AI-2 sobre `.resx` | B-10, A-10 | Bajo | 5 |
| `SDEI/TEM-05` | Audiencia en lugar de rol; alcance; superficies y paquete; ayuda de campo con anclas `muestra`/`valida`; API restringida sin interfaz en producción | Eje A y B | Alto | 4 |
| `SDEI/TEM-06` | C-AUD-1, C-AUD-2 en `docs-guard`; C-AUD-3 a C-AUD-5, C-API-1/2, C-CAMPO-1..3 en el carril del producto con `workflow:` exigido | A-11, H-03, H-07 | Medio | 5 |
| `SDEI/99-Anexos/Glosario.md` | Altas: audiencia, alcance, superficie, nivel de acceso, matriz de audiencias, ayuda de campo; «Rol» remite a audiencia | A-01 | Bajo | 4 |
| `SDEI/Examples/` | Extender `Prueba-Ayuda-Por-Rol` (A-15, B-12) | Ejemplo público | Alto | 6 |
| Libro (`F099` §5.2) | Parte III: cap. 7 «Audiencias» (con la doble audiencia como dimensión), cap. 8 «Ayuda al usuario final y en el formulario», capítulo nuevo «Documentación de API y SDK por audiencia»; cap. 14 rehecho con la `PAR` extendida | A-13 | Alto | 7 |
| Oráculos y criterio de caso (`F204`) | Una fila de audiencia por caso donde el repo tenga más de un rol, alcance o documento OpenAPI (C2 por la forma de `{servicio-privado}`); se re-sellan | A-14 | Medio | después de `K` 1.3 |

## 10. Lo que revisé y está bien

1. **La ayuda de la prueba de concepto no se sirve como archivo estático:** va embebida en el ensamblado
   (`PAR/Web/AyudaDemo.Web.csproj:12`) y la entrega un *middleware* con el mismo filtro para el `.md` y el `llms.txt`
   (`PAR/Web/Program.cs:34-55`). Es lo que Learn pide para no exponer archivos sin autorización (ML-02).
2. **El cuerpo pone la decisión en el servidor y lo interno en el build**, con 404 y no 403
   (`SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:103-109`); coincide con ML-09 y ML-10.
3. **La mini demo baja el contrato sólo en desarrollo** (`MU/source.lock:9`, `ASPNETCORE_ENVIRONMENT=Development`),
   coherente con la práctica de ML-07.

## 11. Lo no verificado, incidencias y barrido

- **Sin verificar hoy:** herencia de roles en ASP.NET Core (no abrí la página de roles; la propuesta no depende de
  ella); cómo se comporta `IStringLocalizer` con una clave ausente (lo busqué en la página de localización de Blazor
  y no lo encontré); el elemento de comentario de un `.resx` como lugar de traza (no lo uso).
- **Sensibilidad de §7:** no corrida. Las dos decisiones quedan CON REVISIÓN.
- **Lectura de §6 de `F300`:** `F300` §7 dice que las comisiones no reciben la propuesta de §6 antes de entregar; la
  carta de esta comisión la transcribió y pidió puntuarla, y por eso la puntúo. Lo asiento como incidencia para la
  presidencia.
- **Mensajes de otras sesiones** durante el trabajo: ninguno.
- **Barrido de lo privado:** el servicio va como `{servicio-privado}`; no hay nombres de máquina ni rutas absolutas
  del sistema de archivos; las rutas son relativas a `LD` o por alias (`SDEI/`, `PAR/`, `MU/`, `dg/`, `K`).
