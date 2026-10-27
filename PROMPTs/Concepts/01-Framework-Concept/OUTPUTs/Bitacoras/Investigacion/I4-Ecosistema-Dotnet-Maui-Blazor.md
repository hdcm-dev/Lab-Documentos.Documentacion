| Campo | Valor |
| --- | --- |
| Tipo | dossier de investigación (ángulo I4) |
| Fecha | 2026-10-25 (todas las consultas web de este dossier: 2026-10-25) |
| Autor | Investigador I4 |
| Expediente | 0001-Framework-Concept-Maui-Autoactualizable |
| Preguntas que alimenta | P1–P13 (folios 003 a 006) |

# I4 — Ecosistema .NET: MAUI Blazor Hybrid, HybridWebView y actualización de contenido sin tienda

## Índice

- [0. Convenciones del dossier](#0-convenciones-del-dossier)
- [1. Alcance del ángulo](#1-alcance-del-ángulo)
- [2. Qué se usa](#2-qué-se-usa)
- [3. Cómo resuelven lo específico](#3-cómo-resuelven-lo-específico)
  - [3.1 Momento de actualización](#31-momento-de-actualización)
  - [3.2 Versionado de lo descargado y compatibilidad con la app instalada](#32-versionado-de-lo-descargado-y-compatibilidad-con-la-app-instalada)
  - [3.3 Datos tomados con versión vieja](#33-datos-tomados-con-versión-vieja)
  - [3.4 Permisos y capacidades fijados por el manifiesto](#34-permisos-y-capacidades-fijados-por-el-manifiesto)
  - [3.5 Tiendas: reglas, rechazos y problemas](#35-tiendas-reglas-rechazos-y-problemas)
  - [3.6 Blazor WebAssembly dentro de un WebView móvil](#36-blazor-webassembly-dentro-de-un-webview-móvil)
  - [3.7 Estado y percepción de la plataforma](#37-estado-y-percepción-de-la-plataforma)
- [4. Opiniones de desarrolladores](#4-opiniones-de-desarrolladores)
- [5. Lecciones aplicables a P1–P13](#5-lecciones-aplicables-a-p1p13)
- [6. Fuentes](#6-fuentes)

## 0. Convenciones del dossier

- **HECHO**: documentación oficial, anuncio del proveedor, código o metadatos de un registro (NuGet, GitHub API). Se cita con número de fuente `[n]`.
- **OPINIÓN**: posts, foros, issues, comentarios, notas de prensa con juicio. Van con autor, fecha, enlace y cita textual breve. Son señal cualitativa, **no estadística**.
- **NO VERIFICADO**: lo que no pude confirmar, con motivo.
- **CRITERIO PROPIO**: inferencia del investigador, marcada así.
- Glosario mínimo:
  - **Cascarón**: la app nativa instalada desde la tienda (binario .NET MAUI + AndroidManifest.xml / Info.plist).
  - **Contenido**: lo que se descarga del servidor propio y corre dentro del WebView (en nuestro caso, una publicación Blazor WebAssembly).
  - **Blazor Hybrid (BlazorWebView)**: los componentes Razor corren en el proceso .NET nativo y pintan en un WebView; **no** usa WebAssembly [3].
  - **HybridWebView**: control de MAUI (desde .NET 9) que aloja HTML/JS/CSS y lo comunica con C# [1].

## 1. Alcance del ángulo

Este ángulo responde, sólo para el ecosistema .NET:

1. Qué ofrece hoy (.NET 9/10, con mirada a .NET 11) la plataforma oficial para alojar contenido web en una app MAUI y si trae un mecanismo propio para actualizarlo sin tienda.
2. Qué productos de terceros del ecosistema .NET resuelven la actualización de contenido sin tienda, cómo trabajan sin red y cómo fuerzan la actualización.
3. Qué issues abiertos de `dotnet/maui` y `dotnet/aspnetcore` afectan el patrón (permisos, interceptación de pedidos, carga desde almacenamiento local).
4. Qué se sabe de Blazor WebAssembly dentro de un WebView móvil (modelo de ejecución, tamaño, arranque, memoria).
5. Alternativas en .NET (MAUI + sitio remoto, Uno, Avalonia) y su postura respecto de actualizaciones sin tienda.
6. Qué opina la comunidad .NET sobre MAUI Hybrid en producción y sobre actualizaciones dinámicas.

Fuera de este ángulo: patrones de otras plataformas (Capacitor, Expo, CodePush, Flutter), salvo cuando la comunidad .NET los nombra como comparación.

Límite de medios declarado: **Reddit (r/dotnet, r/Blazor, r/dotnetMAUI) no se pudo leer**: WebFetch lo rechaza («unable to fetch from www.reddit.com») y `curl` a `old.reddit.com/.../search.json` devolvió HTTP 403; el buscador web no devolvió hilos de Reddit en cuatro búsquedas. Todo lo que se diga de Reddit queda **NO VERIFICADO**. Como sustituto se relevó Hacker News (API Algolia), Stack Overflow (API StackExchange), GitHub (API de issues y discusiones) y Microsoft Q&A.

## 2. Qué se usa

| Nombre | Qué actualiza sin tienda | Cómo trabaja sin red | Cómo fuerza o programa la actualización | Versión / estado vigente | Fuente |
| --- | --- | --- | --- | --- | --- |
| **BlazorWebView** (Blazor Hybrid, oficial) | **Ningún código .NET**: los `.razor` se compilan en el binario y el `wwwroot` va empaquetado. «After the app is built, the .NET code Web View content sources can't change.» [22] — la misma página aclara que el contenido que corre **dentro** del WebView sí «can come not only from the app but also from external sources» (p. ej. CDN) [22]. No trae mecanismo de actualización | Total: todo está en el paquete | No aplica (sólo tienda) | MAUI 10.0.120 (NuGet, 2026-10-21) | [3][4][22] |
| **HybridWebView** (oficial, desde .NET 9) | Nada por sí mismo: `HybridRoot` apunta a los *raw assets* del paquete (`Resources/Raw/wwwroot`). Desde .NET 10, el evento `WebResourceRequested` permite responder cada pedido con un stream propio (p. ej. archivos descargados a `AppDataDirectory`) | Lo que sirva el manejador del evento | No trae mecanismo; lo construye el equipo | .NET 10: `InvokeJavaScriptAsync` sin retorno, `WebViewInitializing/Initialized`, `WebResourceRequested`. .NET 11: interop JS→.NET apta para trimming completo/NativeAOT si se registra con metadatos JSON generados (`JsonSerializerContext`) [1] | [1][2] |
| **Shiny.AppDeviceBridge** (tercero, MIT, Allan Ritchie) | Un *zip* de cualquier web estática (Blazor WebAssembly, React, Vue) servido desde el zip por un servidor HTTP *loopback*, actualizable desde un servidor propio de releases firmados | Trae un zip base compilado en la app; «Offline or server down: the newer of the bundled and installed builds is served»; si el chequeo tarda más de 5 s (`CheckTimeout`) muestra lo instalado | Al iniciar consulta al servidor. Por debajo de `minimumVersion` la actualización es obligatoria y se instala antes de mostrar la app; si hay una más nueva se baja en segundo plano y se aplica en el próximo arranque o con `POST /_bridge/host/apply-update`. `minimumHostVersion` saltea releases que necesitan un cascarón más nuevo | Anuncio 2026-09-18 «available today in beta»; repo creado 2026-09-15; NuGet `Shiny.AppDeviceBridge.WebView` 1.0.0 publicado 2026-09-30 y 2.1.0 el 2026-10-15 (1.0.0 → 2.1.0 en 15 días; 1 581 descargas totales al 2026-10-25) | [5][6][7] |
| **Plugin.Maui.AppUpdate** (tercero, MIT) | Nada de contenido: gestiona la actualización **del cascarón** | — | Android: Play In-App Updates inmediato (bloqueante) o flexible. iOS: sólo consulta la versión en App Store y abre la ficha. Política remota JSON por HTTPS: versión mínima, prioridad (obligatoria / recomendada / ninguna), posponer, ventana de mantenimiento | 1.0.7 (2026-09-11), net10.0-android36 / ios26, ~1 000 descargas | [8] |
| **Oscore.Maui.Android.InAppUpdates** (tercero) | Cascarón, sólo Android | — | Flujo flexible o inmediato según prioridad (por defecto: prioridad 1–3 flexible, 4–5 inmediato); «You cannot see the popup dialog while developing or if you distribute it manually» (recomienda probar con *Internal App Sharing* de Play) | 1.5.1 (2025-11-21) | [9] |
| **CommunityToolkit.Datasync** (Microsoft/comunidad) | Datos, no contenido | Cliente con almacenamiento local (*offline storage*) y sincronización con servidor ASP.NET Core | No aplica | Client 10.1.2 (NuGet, 2026-07-06) | [10][38] |
| **MAUI + WebView apuntando a un sitio remoto** | Todo, al publicar en el servidor web | Nada salvo lo que cachee el WebView. **NO VERIFICADO**: que los *service workers* en WebView Android dependan de APIs que MAUI no expone — ni [11] ni [12] lo tratan (la página [11] no menciona *service workers*) | Inmediato al recargar | Patrón, no producto | [11][12] |
| **Uno Platform / Avalonia** | **NO VERIFICADO**: no encontré mecanismo de actualización OTA documentado en ninguno de los dos | — | — | Uno 6.6 anunciado 2026-08-07 [14] (NuGet `Uno.WinUI` vigente 6.7.135); Avalonia 12.0.0 publicado en NuGet 2026-04-07, vigente 12.1.4 ([13] sólo cita 11.3); Avalonia MAUI backend en preview desde 2026-03-16 | [13][14][15][39] |
| **`dotnet/maui` PR #39289 «web-first MAUI playground and JavaScript SDK»** (Matt Leibow, Microsoft) | No es OTA: propone `Microsoft.Maui.Controls.HybridWebApps` (.NET 11) para apps web dentro de MAUI con SDK npm `@maui/api` | El texto dice «Offline uses the same UI/bridge» | Declara pendiente «installed signed Release/NativeAOT/update certification» | Borrador abierto (2026-10-09), sin publicar | [16] |
| **App Center CodePush** (histórico) | Nunca soportó Xamarin/MAUI (sólo React Native/Cordova, según SO 2016) | — | — | App Center retirado el 2025-03-31 (sólo Analytics & Diagnostics se extendió hasta el 2026-06-30) | [17][18] |

**Lectura (CRITERIO PROPIO):** en el ecosistema .NET no hay mecanismo oficial de actualización de contenido sin tienda. Lo que existe son **piezas** (HybridWebView + `WebResourceRequested` en .NET 10) y **un** producto de tercero muy reciente (Shiny.AppDeviceBridge) que implementa justo el patrón del borrador: zip base empaquetado, servidor de releases firmados, versión mínima obligatoria, versión mínima de cascarón. El caso del g42 (Blazor WASM descargado dentro de HybridWebView) está en la misma familia técnica que Shiny.

## 3. Cómo resuelven lo específico

### 3.1 Momento de actualización

- **Oficial (MAUI):** no define momento porque no actualiza contenido. Para el cascarón, la discusión `dotnet/maui#24201` (2024-08-12, categoría Q&A, marcada «Unanswered», sin respuesta de Microsoft) sólo tiene dos intervenciones de la comunidad: jarlem propone comparar la versión instalada con la del servidor, mandar a la tienda y bloquear la app si no actualiza; ewerspej considera buena UX avisar y llevar a la ficha «(in In-App Updates are not implemented)» — es un condicional (léase «si no hay In-App Updates»), **no** una afirmación de que MAUI no los tenga [19].
- **Shiny.AppDeviceBridge (HECHO, documentación del proveedor):** tres casos al **abrir** la app [5][6]:
  1. versión instalada < `minimumVersion` → descarga obligatoria **antes** de mostrar la app;
  2. hay una versión más nueva → descarga en **segundo plano**, se aplica en el **próximo arranque** o cuando la página la pide (`apply-update`);
  3. sin red o servidor caído → arranca con la más nueva entre la empaquetada y la instalada.
  Matiz del README [6]: con `BlockOnRequiredUpdateFailure = false` (valor por defecto) «a required download that fails midway is treated as offline», es decir, la obligatoria **no** bloquea si la descarga falla; y `ApplyOptionalUpdatesImmediately` (por defecto `false`) permite aplicar una opcional apenas llega.
  No encontré en Shiny un disparo «al iniciar sesión» (**NO VERIFICADO**: ni el anuncio ni el README lo mencionan).
- **Plugin.Maui.AppUpdate (cascarón):** obligatoria / recomendada (posponible hasta 2 veces, 3 días por defecto) / mantenimiento, decidido por un JSON remoto [8].
- **Segundo plano:** Shiny corre trabajos en `background.js` (motor Jint, 25 s y 64 MB por llamada) y advierte que el SO decide cuándo: «at best every 15 minutes on Android», menos predecible en iOS [5].

### 3.2 Versionado de lo descargado y compatibilidad con la app instalada

- **Shiny (HECHO):** cada release es un zip versionado con un JSON lateral (`channel`, `minimumHostVersion`, `platforms`, `downloadUrl` para CDN); `app.json` lleva `minimumVersion`. Firma ECDSA P‑256 verificada contra una clave pública compilada en el binario; luego app id, versión mayor a la instalada, compatibilidad de cascarón, tamaño y SHA‑256. «Old releases are never reinstalled»: **no hay rollback** [5][6]. Que un release roto se corrija publicando uno más nuevo y subiendo la versión mínima es **CRITERIO PROPIO** (el README no lo dice). Con el proveedor de GitHub, «GitHub releases are not signed» (sólo se verifica el SHA‑256 cuando GitHub lo informa) [6].
- **MAUI oficial:** sin modelo de versionado de contenido. La documentación de BlazorWebView recomienda URIs versionadas (`image.png?v=2`) para invalidar caché de estáticos locales [12] (sólo caché, no canal).
- **Ciclo de vida del cascarón (HECHO):** la política de soporte de MAUI es distinta de la de .NET: «A major version of .NET MAUI receives support for a minimum of 6 months after a successor … ships». **MAUI 10 termina soporte el 2027-05-11** (aunque .NET 10 sea LTS) [20]. .NET 11: Microsoft dice «General availability is expected in November 2026» [21]; la .NET Conf 2026 (10–13 de noviembre) «celebrate[s] the launch of .NET 11» [21]. **NO VERIFICADO** el día exacto de GA (2026-11-10): ninguna fuente oficial ni las notas de InfoQ citadas lo fijan. Consecuencia (CRITERIO PROPIO): el cascarón va a tener que pasar por la tienda al menos una vez al año para seguir en una versión soportada, y el contrato contenido↔cascarón debe sobrevivir ese salto.
- **WebView del sistema (HECHO):** BlazorWebView/HybridWebView usan el WebView instalado; en Android se actualiza por Play Store y en iOS con el sistema. Microsoft recomienda leer la versión por `navigator.userAgent` y pedir al usuario que actualice si no alcanza [22]. Es una **tercera línea de versión** que el contenido no controla.

### 3.3 Datos tomados con versión vieja

- **No encontré fuente** del ecosistema .NET que trate qué pasa con datos capturados con una versión vieja del contenido cuando llega otra (**NO VERIFICADO** por ausencia: ni Shiny [5][6], ni la documentación MAUI [1][3], ni los hilos relevados lo tratan). El README de Shiny dice que las preferencias se guardan por app id y los archivos en «named roots», pero no qué hace la actualización con el trabajo en curso [6].
- **Piezas disponibles (HECHO):** CommunityToolkit.Datasync ofrece almacenamiento local + sincronización [10][38]; `maui.dataforms` permite definir formularios en JSON, que «could have just as easily been a response from an API call» [23] — pero es una **prueba de concepto** («proof of concept library», sin paquete NuGet, último push 2023-10-22) [23].
- **Criterio propio:** como Shiny aplica la versión nueva «en el próximo arranque» y la obligatoria «antes de mostrar la app», cualquier encuesta a medio llenar o sin sincronizar queda en manos del diseño propio: hay que versionar la definición de la encuesta junto a cada respuesta guardada (P13).

### 3.4 Permisos y capacidades fijados por el manifiesto

- **HECHO (Shiny):** las capacidades nativas («bridges») van en el binario y pasan revisión normal; cada bridge exige sus permisos en el manifiesto y sus descripciones de uso. «On Apple platforms a missing usage description crashes the app when the page asks.» Si la plataforma no tiene una capacidad, el bridge responde `501` y `GET /_bridge/host` la informa como no soportada; varios bridges (p. ej. calendario/contactos) responden `403 access_denied` hasta que se concede el acceso, y el simulador puede devolver `501 not_supported` o `403 access_denied` [5][6]. Recomienda: «Keep native capabilities in the binary (bridges ship with the app), ship a complete baseline, and use `minimumHostVersion`» [6].
- **HECHO (MAUI, issues abiertos):**
  - `dotnet/maui#25784` (2024-11-12, abierto, Backlog): con HybridWebView en .NET 9 no hay forma de interceptar los pedidos de permiso del WebView en Android (el método de .NET 8 da `InvalidCastException`) [24a].
  - `dotnet/maui#30847` (2025-07-25, abierto, `p/0`, hito .NET 10 SR13, autor Matt Leibow): define cómo HybridWebView debe gestionar permisos de cámara/micrófono en Android [24b].
  - `dotnet/maui#28202` (2025-03-05, abierto, Beth Massi): agrupa pedidos de personalización de BlazorWebView y HybridWebView; la interceptación de pedidos quedó hecha, la de permisos y la navegación por URL (`#24821`) siguen abiertas [24c].
  - `dotnet/maui#29454` (2025-05-12): `<select>` no deja elegir en HybridWebView Android; **cerrado como resuelto el 2026-10-17** [25].
  - `dotnet/maui#27249` (2025-01-21): HybridWebView no funciona en API 23 (Android 6.0); **cerrado «not planned» el 2026-10-22** [25].
- **Criterio propio:** para el escenario de la encuesta, si la encuesta pide foto o GPS desde el contenido web, el camino más estable hoy en MAUI es que el contenido **llame al cascarón** (puente C#) y que el cascarón use `Permissions`/`MediaPicker`/`Geolocation` de MAUI, en vez de depender de los permisos del WebView, cuyo manejo en HybridWebView Android está abierto.

### 3.5 Tiendas: reglas, rechazos y problemas

- **Apple, App Review Guidelines 2.5.2 (HECHO, texto literal):** las apps no pueden «download, install, or execute code which introduces or changes features or functionality of the app» [26].
- **Apple, Developer Program License Agreement 3.3.1(B) (HECHO, texto literal):** «Interpreted code may be downloaded to an Application but only so long as such code: (a) does not change the primary purpose of the Application … (b) does not bypass signing, sandbox, or other security features of the OS» [27].
- **Google Play, política de abuso de dispositivo y red (HECHO, texto literal):** la app no puede actualizarse por otro medio que Play ni bajar código ejecutable (dex, JAR, .so); «This restriction does not apply to code that runs in a virtual machine or an interpreter where either provides indirect access to Android APIs (such as JavaScript in a webview or browser)» [28].
- **Apple, App Review Guidelines 4.7 y 4.7.2 (HECHO, texto literal, «Last Updated: October 16, 2026»):** 4.7 admite software no embebido en el binario, «specifically HTML5 and JavaScript mini apps and mini games…», y 4.7.2 exige: «Your app may not extend or expose native platform APIs or technologies to the software without prior permission from Apple» [26]. **NO VERIFICADO** si 4.7/4.7.2 alcanza al contenido propio de la app (4.7 habla de mini apps y juegos); si alcanzara, un puente que expone capacidades nativas al contenido descargado requeriría permiso previo de Apple. Ninguna fuente .NET relevada lo discute.
- **Google Play, continuación del mismo párrafo (HECHO):** «Apps or third-party code, like SDKs, with interpreted languages (JavaScript, Python, Lua, etc.) loaded at run time (for example, not packaged with the app) must not allow potential violations of Google Play policies» [28].
- **Blazor WebAssembly es IL interpretado (HECHO):** «Without enabling AOT compilation, Blazor WebAssembly apps run on the browser using a .NET Intermediate Language (IL) interpreter implemented in WebAssembly» [29]. La misma página agrega, en otro párrafo, «with partial just-in-time (JIT) runtime support, informally referred to as the Jiterpreter» [29].
- **Interpretación de Shiny (OPINIÓN de proveedor):** cita 2.5.2 y 3.3.1(B) como base para permitir el patrón «as long as updates don't change the app's primary purpose»; su argumento parte de que «The downloaded content is HTML and JavaScript» [5][6] — no argumenta sobre WebAssembly, aunque su README dice servir «Blazor WebAssembly, React, Vue» [6].
- **NO VERIFICADO:** que Apple o Google acepten explícitamente **WebAssembly** (y DLL .NET interpretadas por un runtime WASM) dentro del WebView como «código interpretado». Ninguna de las dos políticas nombra WebAssembly; el ejemplo de Google es JavaScript. No encontré casos de rechazo ni de aprobación documentados para MAUI con Blazor WASM descargado. **Criterio propio:** la lectura de Shiny es razonable pero es la de un proveedor interesado; el borrador debe tratar AOT-WASM (código compilado a .wasm) con más cautela que IL interpretado.
- **Problemas de tienda reportados en .NET (OPINIÓN):** migrar de UWP a MAUI Blazor Hybrid en Microsoft Store obliga a empaquetar a mano (`makeappx`) [30]; publicar un APK de MAUI quedó roto «in the recent version of Visual Studio» (el AAB sí funciona) según holecekp, 2026-05-26 [31].

### 3.6 Blazor WebAssembly dentro de un WebView móvil

- **Modelo (HECHO):** Blazor Hybrid y Blazor WASM son modelos distintos. En Hybrid «Components don't run in the browser, and WebAssembly isn't involved» [3]. Nuestro caso (WASM descargado dentro de HybridWebView) es **WASM corriendo en el motor del WebView**, no Blazor Hybrid. Una respuesta aceptada de Stack Overflow (ToolmakerSteve, 2023-06-05) afirma que «Maui Blazor is compatible with webassembly blazor», que es impreciso frente a la documentación [32].
- **Memoria (HECHO):** para navegadores móviles, «especially Safari on iOS, decreasing the maximum memory for the app with the MSBuild property `EmccMaximumHeapSize` may be required» [33]. WKWebView usa el mismo motor (CRITERIO PROPIO: el riesgo aplica).
- **Tamaño y arranque:** **NO VERIFICADO** para WebView móvil: no encontré mediciones publicadas de Blazor WASM .NET 10 dentro de un WebView Android/iOS. Hay reportes sueltos en navegador (issue `dotnet/aspnetcore#64009`, regresión de descarga en .NET 10 RC1; `dotnet/runtime#123591`, arranque) que no son benchmarks controlados [34]. **Lo único medido es nuestro g42** (fuera de este ángulo).
- **Seguridad (HECHO, Microsoft):** el código dentro del WebView es **no confiable**; evitar contenido de terceros, usar TLS, CSP y Subresource Integrity, validar todo lo que llega por el puente y no guardar credenciales ni tokens en el contexto del WebView [22]. Microsoft incluso sugiere bajar el contenido externo, verificarlo y **empaquetarlo** en `wwwroot` [22]: la postura oficial es lo opuesto a la actualización dinámica.
- **Interceptación (HECHO):** `WebResourceRequested` «MUST be synchronous» y debe devolver respuesta si `Handled = true`; para contenido asíncrono se pasa un `Task<Stream>` [1][2]. Hubo una prueba de CI de esta función que fallaba de forma recurrente porque dependía de un servicio externo (beeceptor.com), no por la función en sí (`#35935`, abierta 2026-06-16 por un bot, cerrada «not planned» 2026-08-14) [24d].

### 3.7 Estado y percepción de la plataforma

- **HECHO:** el foco de MAUI en .NET 10 es «improve product quality» [2]. .NET 11 RC2 con *go-live license* (InfoQ, Almir Vuk, 2026-10-19; NuGet 11.0.0-rc.2 del 2026-10-13); GA «expected in November 2026» sin día oficial (ver §3.2) [21][4].
- **HECHO:** Avalonia publicó el 2026-03-16 (Tim Miller) la primera preview de un backend de Avalonia para .NET MAUI que dibuja los controles y lleva apps MAUI a Linux y WebAssembly [15]. **NO VERIFICADO** «sin fork de MAUI»: el post no lo dice.
- **OPINIÓN (prensa):** The Register (Tim Anderson, 2026-03-23) afirma adopción limitada de MAUI, regresiones en .NET 10 y poco uso interno en Microsoft (Teams con Electron, Office con React Native) [35].
- **OPINIÓN (comunidad):** discusión `dotnet/maui#34171` «How are things in 2026?» (2026-02-21 a 2026-10-19): hay respuestas críticas (regresiones de .NET 10, el SR9 en Android, pedidos de hotfixes) y otras positivas (molesmoke, holecekp en marzo); un mantenedor responde que la IA aumentó el throughput (ver §4). Recuento: la cabecera de GitHub informa «18 comments · 63 replies» (81 intervenciones); en el HTML servido se ven 57 bloques de respuesta. **No se clasificaron por postura**, así que no se afirma proporción alguna [31].

## 4. Opiniones de desarrolladores

Recuento declarado: **25 opiniones** en las tres tablas (10 Hacker News, 8 GitHub, 4 Stack Overflow, 1 Microsoft Q&A, 1 prensa, 1 proveedor). Son las que encontré con las búsquedas descritas en §1 (HN: cuatro consultas Algolia sobre comentarios; SO: cinco consultas a la API; GitHub: búsqueda de issues y dos discusiones leídas). No representan a la comunidad; Reddit no se pudo leer (NO VERIFICADO).

### 4.1 A favor (de MAUI Blazor Hybrid o del patrón)

| Fuente | Autor | Fecha | Postura | Cita | Tema |
| --- | --- | --- | --- | --- | --- |
| HN [36a] | randyburden | 2026-02-25 | A favor | «I'd still make the same call today. … a .NET MAUI Blazor Hybrid app that's published to the app stores» | Producción |
| HN [36b] | jabart | 2025-10-05 | A favor | «MAUI Blazor Hybrid is great if you won't want to learn XAML» | Elección de UI |
| HN [36c] | noveltyaccount | 2026-05-24 | A favor con reparo | «Much leaner than Electron. Pretty clunky though last time I tried» | Arquitectura |
| HN [36d] | hahn-kev | 2025-10-05 | A favor con reparo | «we use MAUI Blazor as we also want to run on a server. We're finding iOS to be difficult to target» | Web + móvil |
| HN [36e] | sltr | 2025-08-09 | A favor (contextual) | «we have a Blazor MAUI hybrid desktop app because it also has to run on the web» | Web + escritorio |
| GitHub #24201 [19] | ewerspej | 2025-04-25 | A favor de avisar y llevar a la tienda | «It's quite a good UX actually if the app notifies you about this» | Forzar actualización |
| Blog proveedor [5] | Allan Ritchie (Shiny) | 2026-09-18 | A favor de OTA | Titula «Ship Your App on Your Schedule»; cita 2.5.2 y 3.3.1(B) como permiso | Actualización sin tienda |
| SO [32b] | NSS | 2022-02-18 | A favor de web remota | WebView a sitio remoto: «would immediately show any changes … as soon as you publish it» | Alternativa remota |

### 4.2 En contra

| Fuente | Autor | Fecha | Postura | Cita | Tema |
| --- | --- | --- | --- | --- | --- |
| HN [36f] | holbrad | 2025-10-05 | En contra | «Certainly wouldn't recommend MAUI. Even using it as a simple shell with for Blazor Hybrid was noticeably harder than WPF» | MAUI como cascarón |
| HN [36g] | debugnik | 2025-08-12 | En contra | «many projects use it as just a glorified webview for Blazor. I expect it to eventually go into a silent maintenance mode» | Futuro de MAUI |
| HN [36h] | pjmlp | 2025-10-28 | En contra | «I give zero value to Blazor Hybrid, from my point of view it doesn't exist» | Blazor Hybrid |
| HN [36i] | ElectricalUnion | 2026-05-04 | En contra | Microsoft «rugpulls … (WinForms, WPF, UWP, WinUI 3, MAUI, Blazor Hybrid, WebView2 …)» | Riesgo de abandono |
| GitHub #34171 [31] | Xynratron | 2026-03-03 | En contra | «MAUI is a great Idea, but not a solution for an Enterprise» | Churn anual |
| GitHub #34171 [31] | holecekp | 2026-04-11 | En contra (prudencia) | «I recommend caution when upgrading MAUI to .NET 10» | Regresiones |
| GitHub #24201 [19] | jarlem | 2024-08-13 | Reparo de UX | «Not the greatest user experience, but if you wanna do it» (bloquear la app hasta actualizar) | Forzar actualización |
| Prensa [35] | Tim Anderson (The Register) | 2026-03-23 | Escéptico | Cita a un dev: «constant regressions and other bugs that make it difficult to use in production» | Estabilidad |
| GitHub #25804 [37] | jonmdev | 2024-11-12 | Crítico | Lista de fallas de HybridWebView 9.0 GA, entre ellas «Permissions requests cannot be caught in Android» | HybridWebView |

### 4.3 Matices

| Fuente | Autor | Fecha | Postura | Cita | Tema |
| --- | --- | --- | --- | --- | --- |
| HN [36j] | r0x0r007 | 2025-11-12 | Matiz | «The best 'mobile platform' for me was blazor hybrid, but then again - if it's already blazor why not go full web» | Web vs híbrido |
| SO [32] | ToolmakerSteve | 2023-06-05 | Matiz (respuesta aceptada) | «It is self-contained in the app bundle … any update requires the app itself to be updated» | Blazor Hybrid no se actualiza sin tienda |
| SO [32c] | valdetero | 2016-11-09 | Matiz | «Xamarin's code is the binary. Also, if your code is in the App Store, you should be updating through the store» | Xamarin sin tienda |
| SO [32c] | Jon Douglas | 2016-11-09 | Matiz | Compara con Cordova: «they have mechanisms to inject content via pulling from a server-side service» | Patrón contenido web |
| GitHub #34171 [31] | holecekp | 2026-03-01 | Matiz | «MAUI is great and I would definitely recommend it» (y luego reporta regresiones) | Producción |
| GitHub #34171 [31] | molesmoke | 2026-07-03 | Matiz positivo | «Things are getting better and better with MAUI I think» | Tendencia |
| GitHub #34171 [31] | jfversluis (Microsoft) | 2026-08-21 | Respuesta del equipo | «Through the use of AI we have a MUCH higher throughput» | Proceso del equipo |
| MS Q&A [30] | Jignesh Desai | 2025-10-06 | Queja de tienda | «Why does publishing a MAUI app to the Store have to be so complicated?» | Microsoft Store |

## 5. Lecciones aplicables a P1–P13

| Pregunta | Lección | Fuente | Tipo |
| --- | --- | --- | --- |
| **P1** modelo A/B/C | El ecosistema oficial no actualiza código de pantallas sin tienda: BlazorWebView compila los componentes en el binario. La opción A (WASM empaquetado descargable) sólo existe vía HybridWebView + interceptación propia o un tercero (Shiny). La opción B (UI por datos) tiene un antecedente comunitario sólo como prueba de concepto (`maui.dataforms`, sin NuGet, inactivo desde 2023) y no depende de la interpretación de tiendas sobre WASM | [3][1][5][23] | HECHO + CRITERIO PROPIO |
| **P1** riesgo de tienda | Apple 3.3.1(B) y Google Play eximen código interpretado / JS en WebView; ninguna nombra WebAssembly. Apple 4.7.2 prohíbe exponer APIs nativas a software descargado sin permiso previo (alcance sobre contenido propio: NO VERIFICADO). Para el escenario de encuestas, la opción B (definición como datos) evita la discusión; A queda sujeta a interpretación | [26][27][28][29] | HECHO + NO VERIFICADO (aceptación de WASM; alcance de 4.7.2) |
| **P2** canal | El único precedente .NET (Shiny) usa: zip base empaquetado, firma ECDSA P‑256 con clave pública en el binario, SHA‑256 y tamaño, `minimumVersion`, `minimumHostVersion`, `channel`, sin rollback («Old releases are never reinstalled»; corregir subiendo la mínima es CRITERIO PROPIO). Sirve como tabla diferencial contra D‑02 | [5][6] | HECHO (proveedor) + CRITERIO PROPIO |
| **P2** seguridad | Microsoft: contenido del WebView no confiable, TLS + CSP + SRI, validar el puente | [22] | HECHO |
| **P3** cascarón y puente | En .NET 10 el puente oficial es `InvokeDotNet`/`InvokeJavaScriptAsync` y la carga desde almacenamiento local es vía `WebResourceRequested` (síncrono). En .NET 11 la interop admite trimming/NativeAOT con `JsonSerializerContext`. Shiny publica capacidades como HTTP en `/_bridge` y responde `501` si faltan | [1][2][5] | HECHO |
| **P3** versión del contrato | Tres líneas de versión fuera del contenido: cascarón (tienda), WebView del sistema (Play/iOS) y MAUI con soporte de 18 meses (MAUI 10 hasta 2027-05-11) | [20][22] | HECHO |
| **P5** sin red | Patrón de Shiny: siempre arranca con lo mejor que tenga local; timeout de chequeo 5 s. Datos: Datasync existe como pieza .NET | [6][10] | HECHO |
| **P6/P8** compuertas | La comunidad reporta regresiones entre service releases de MAUI 10 (SR9) y pide hotfixes; conviene fijar versión de MAUI en el PR y probar en dispositivo real antes de subirla | [31] | OPINIÓN → CRITERIO PROPIO |
| **P7** líneas de versión | Shiny separa versión de contenido y versión mínima de cascarón; Plugin.Maui.AppUpdate separa versión mínima de cascarón con prioridad obligatoria/recomendada | [5][8] | HECHO |
| **P9** iOS | En iOS no hay actualización in-app del cascarón: sólo abrir la ficha de App Store (Plugin.Maui.AppUpdate). WebAssembly en WKWebView puede requerir bajar `EmccMaximumHeapSize` | [8][33] | HECHO |
| **P11** demo | Interceptar con `WebResourceRequested` para servir desde `AppDataDirectory` es el camino oficial más corto en .NET 10; tener en cuenta que el manejador es síncrono | [1][2] | HECHO |
| **P12** capacidades | Las capacidades van en el binario; pedirlas desde el contenido requiere que el cascarón las tenga declaradas. Manejo de permisos de WebView en HybridWebView Android: abierto (#25784, #30847). Shiny: `501` si falta, `403` si se niega; en Apple falta de descripción de uso = crash | [6][24a][24b] | HECHO |
| **P13** encuestas con versión vieja | Sin fuente .NET que lo resuelva; Shiny aplica la nueva versión al próximo arranque o antes de mostrar si es obligatoria, sin decir qué pasa con el trabajo en curso | [5][6] | NO VERIFICADO (ausencia) + CRITERIO PROPIO: guardar la versión de la definición con cada respuesta y no forzar mientras haya pendientes sin sincronizar |
| **Forzado** (folio 006) | Contenido: forzable por el canal propio (Shiny `minimumVersion`). Cascarón: Android Play In-App inmediato; iOS sólo bloquear y abrir la ficha. Dos comentarios de la comunidad con matices distintos sobre bloquear la app (jarlem lo ve como mala UX; ewerspej, buena UX si avisa) — no es una medición | [5][8][19] | HECHO + OPINIÓN |
| **P4, P10** | Sin aporte específico de este ángulo | — | — |

## 6. Fuentes

Todas consultadas el 2026-10-25.

1. Microsoft Learn, «HybridWebView — .NET MAUI» (view net-maui-10.0), autor David Ortinau, ms.date 2026-07-08. https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/hybridwebview?view=net-maui-10.0
2. Microsoft Learn, «What's new in .NET MAUI for .NET 10», ms.date 2026-08-14. https://learn.microsoft.com/en-us/dotnet/maui/whats-new/dotnet-10?view=net-maui-10.0
3. Microsoft Learn, «ASP.NET Core Blazor Hybrid» (aspnetcore-10.0), ms.date 2025-11-11. https://learn.microsoft.com/en-us/aspnet/core/blazor/hybrid/?view=aspnetcore-10.0
4. NuGet, Microsoft.Maui.Controls (10.0.120 publicado 2026-10-21; 11.0.0-rc.2). https://api.nuget.org/v3-flatcontainer/microsoft.maui.controls/index.json
5. Allan Ritchie, «Introducing Shiny.AppDeviceBridge — Ship Your App on Your Schedule…», shinylib.net, 2026-09-18. https://shinylib.net/blog/2026/09/appdevicebridge/
6. shinyorg/appdevicebridge, README (MIT). https://github.com/shinyorg/appdevicebridge
7. NuGet, Shiny.AppDeviceBridge.WebView (2.1.0, 2026-10-15; 1 581 descargas). https://api.nuget.org/v3-flatcontainer/shiny.appdevicebridge.webview/index.json
8. NuGet, Plugin.Maui.AppUpdate 1.0.7 (2026-09-11), repo nuvyntralabs. https://www.nuget.org/packages/Plugin.Maui.AppUpdate/
9. NuGet, Oscore.Maui.Android.InAppUpdates (vigente 1.5.1, 2025-11-21; README del paquete). https://www-1.nuget.org/packages/Oscore.Maui.Android.InAppUpdates
10. NuGet, CommunityToolkit.Datasync.Client 10.1.2 (2026-07-06); documentación https://communitytoolkit.github.io/Datasync/ («The server is based on ASP.NET Core»). https://api.nuget.org/v3/registration5-gz-semver2/communitytoolkit.datasync.client/index.json
11. Microsoft Learn, «WebView — .NET MAUI». https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/webview
12. Microsoft Learn, «Host a Blazor web app in a .NET MAUI app using BlazorWebView» (net-maui-10.0), ms.date 2026-09-02. https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/blazorwebview?view=net-maui-10.0
13. Marius Bughiu, «MAUI vs Avalonia vs Uno Platform: which should you pick in 2026?», startdebugging.net, 2026-05-27 (cita Avalonia 11.3 y Uno 6; no trata OTA). https://startdebugging.net/2026/05/maui-vs-avalonia-vs-uno-in-2026/
14. InfoQ, Edin Kapić, «Uno Platform 6.6 Adds Native AOT, Vulkan Rendering, and Broader Accessibility Support», 2026-08-07 (no trata OTA). https://infoq.com/news/2026/08/uno-platform-6-6
15. Avalonia UI, «MAUI Avalonia Preview 1» (Tim Miller, 2026-03-16). https://avaloniaui.net/blog/maui-avalonia-preview-1
16. dotnet/maui PR #39289, «Add a portable web-first MAUI playground and JavaScript SDK», Matt Leibow, 2026-10-09 (borrador). https://github.com/dotnet/maui/pull/39289
17. Microsoft Learn, «Visual Studio App Center Retirement» (retiro 2025-03-31; Analytics & Diagnostics hasta 2026-06-30), ms.date 2026-04-15. https://learn.microsoft.com/en-us/appcenter/retirement
18. Stack Overflow, «Xamarin - Updating The App Without App Store», 2016-11-09 (respuestas de Jon Douglas y valdetero). https://stackoverflow.com/questions/40516982
19. dotnet/maui Discussion #24201, «How to enable auto-update for … .MAUI Blazor App?», 2024-08-12 (jarlem 2024-08-13; ewerspej 2025-04-25). https://github.com/dotnet/maui/discussions/24201
20. Microsoft, «.NET MAUI Support Policy». https://dotnet.microsoft.com/en-us/platform/support/policy/maui
21. InfoQ, Almir Vuk, «.NET 11 Release Candidate 2: Go-Live License and Updates across Libraries, F#, MAUI, and WinForms», 2026-10-19 (no da fecha de GA). https://infoq.com/news/2026/10/dotnet-11-rc-2 · Microsoft Learn, «What's new in .NET 11», ms.date 2026-10-13 («General availability is expected in November 2026»). https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-11/overview · .NET, «Events» (.NET Conf 2026, 10–13 nov). https://dotnet.microsoft.com/en-us/platform/community/events · (La nota InfoQ de Preview 6, Edin Kapić, 2026-07-29, https://www.infoq.com/news/2026/07/net-maui-11-preview-6/, tampoco da fecha de GA.)
22. Microsoft Learn, «ASP.NET Core Blazor Hybrid security considerations» (aspnetcore-10.0), ms.date 2025-11-11. https://learn.microsoft.com/en-us/aspnet/core/blazor/hybrid/security/security-considerations?view=aspnetcore-10.0
23. rjygraham/maui.dataforms (GitHub; «proof of concept library», sin NuGet; último push 2023-10-22). https://github.com/rjygraham/maui.dataforms
24. Issues de dotnet/maui (estado al 2026-10-25 vía API de GitHub):
    - 24a. #25784, jonmdev, 2024-11-12, abierto. https://github.com/dotnet/maui/issues/25784
    - 24b. #30847, mattleibow, 2025-07-25, abierto, p/0, hito .NET 10 SR13. https://github.com/dotnet/maui/issues/30847
    - 24c. #28202, BethMassi, 2025-03-05, abierto. https://github.com/dotnet/maui/issues/28202 · #24821 https://github.com/dotnet/maui/issues/24821
    - 24d. #35935, github-actions[bot] (etiqueta ci-scan), 2026-06-16, cerrado «not planned» 2026-08-14. https://github.com/dotnet/maui/issues/35935
25. dotnet/maui #29454 (select en Android, 2025-05-12, cerrado completado 2026-10-17) y #27249 (API 23, 2025-01-21, cerrado «not planned» 2026-10-22). https://github.com/dotnet/maui/issues/29454 · https://github.com/dotnet/maui/issues/27249
26. Apple, «App Review Guidelines», 2.5.2, 4.7 y 4.7.2 (Last Updated: October 16, 2026). https://developer.apple.com/app-store/review/guidelines/
27. Apple, «Apple Developer Program License Agreement», 3.3.1(B). https://developer.apple.com/support/terms/apple-developer-program-license-agreement/
28. Google Play Console Help, «Device and Network Abuse». https://support.google.com/googleplay/android-developer/answer/9888379
29. Microsoft Learn, «ASP.NET Core Blazor WebAssembly build tools and AOT compilation», ms.date 2025-11-11. https://learn.microsoft.com/en-us/aspnet/core/blazor/webassembly-build-tools-and-aot?view=aspnetcore-10.0
30. Microsoft Q&A 5576550, Jignesh Desai, 2025-10-06. https://learn.microsoft.com/en-us/answers/questions/5576550/
31. dotnet/maui Discussion #34171, «How are things in 2026?», Mimisss, 2026-02-21 (respuestas hasta 2026-10-19; cabecera: 18 comments · 63 replies). https://github.com/dotnet/maui/discussions/34171
32. Stack Overflow 76408615, Chris M, 2023-06-05; respuesta aceptada de ToolmakerSteve (id 76409465). https://stackoverflow.com/questions/76408615
    - 32b. Stack Overflow 70782998, magnus, 2022-01-20; respuesta de NSS 2022-02-18. https://stackoverflow.com/questions/70782998
    - 32c. ver [18].
33. Microsoft Learn, «Blazor WebAssembly runtime performance» (aspnetcore-10.0), sección «Heap size for some mobile device browsers». https://learn.microsoft.com/en-us/aspnet/core/blazor/performance/webassembly-runtime-performance?view=aspnetcore-10.0
34. dotnet/aspnetcore #64009 y dotnet/runtime #123591 (reportes de descarga/arranque WASM). https://github.com/dotnet/aspnetcore/issues/64009 · https://github.com/dotnet/runtime/issues/123591
35. Tim Anderson, «Avalonia bolts Linux and WebAssembly onto .NET MAUI», The Register, 2026-03-23 (la cita es de una respuesta en una discusión de GitHub que el artículo recoge). https://www.theregister.com/2026/03/23/maui_linux_avalonia
36. Hacker News (comentarios, vía API Algolia):
    - 36a. randyburden, 2026-02-25. https://news.ycombinator.com/item?id=47146669
    - 36b. jabart, 2025-10-05. https://news.ycombinator.com/item?id=45481734
    - 36c. noveltyaccount, 2026-05-24. https://news.ycombinator.com/item?id=48257500
    - 36d. hahn-kev, 2025-10-05. https://news.ycombinator.com/item?id=45481583
    - 36e. sltr, 2025-08-09. https://news.ycombinator.com/item?id=44849841
    - 36f. holbrad, 2025-10-05. https://news.ycombinator.com/item?id=45484892
    - 36g. debugnik, 2025-08-12. https://news.ycombinator.com/item?id=44875029
    - 36h. pjmlp, 2025-10-28. https://news.ycombinator.com/item?id=45730678
    - 36i. ElectricalUnion, 2026-05-04. https://news.ycombinator.com/item?id=48003825
    - 36j. r0x0r007, 2025-11-12. https://news.ycombinator.com/item?id=45897204
37. dotnet/maui #25804, «Full list of bugs and issues with new .NET 9 HybridWebView», jonmdev, 2024-11-12, cerrado «not planned» por Eilon 2024-12-20. https://github.com/dotnet/maui/issues/25804
38. .NET Foundation, «Community Datasync Toolkit» («cross platform client-server toolkit for providing offline storage for cloud-based SQL and NoSQL data»). https://dotnetfoundation.org/projects/project-detail/community-datasync-toolkit
39. NuGet, Avalonia (12.0.0 publicado 2026-04-07; vigente 12.1.4) y Uno.WinUI (vigente 6.7.135), consultados por la API de búsqueda de NuGet. https://www.nuget.org/packages/Avalonia · https://www.nuget.org/packages/Uno.WinUI

## Verificación de fuentes

| Campo | Valor |
| --- | --- |
| Fecha | 2026-10-25 |
| Verificador | Verificador adversarial de I4 |
| Método | Apertura de cada fuente: API de GitHub (issues/PR), HTML de las discusiones #24201 y #34171, API Algolia de HN (texto, autor y fecha de los 10 comentarios), API StackExchange (respuestas y fechas), API de NuGet (versiones, fechas, descargas), HTML de Microsoft Learn (texto y `ms.date`), páginas de Apple y Google Play (texto literal), README de Shiny por la API de GitHub, WebFetch para blogs y prensa |
| Fuentes revisadas | 53 (las 37 numeradas abiertas una por una, contando por separado los 10 comentarios de HN, los 5 issues de [24], los 2 de [25], los 2 de [34], las 2 preguntas de SO [32]/[32b] y los 3 enlaces de [21]) |
| Citas de opinión verificadas | 25 de 25 ubicadas, con autor y fecha coincidentes; 1 reordenada (36a: el «…» invertía el orden del original) |
| Correcciones | 23 |
| NO VERIFICADO | 10 (6 que ya declaraba el dossier + 4 nuevas) |

**Correcciones (antes → después):**

1. §2 BlazorWebView: cita «After the app is built…» atribuida a [3][4][24] → es de [22] (seguridad) y la misma página dice que el contenido del WebView puede venir de fuentes externas; «Nada por diseño» → «ningún código .NET».
2. §2 HybridWebView .NET 11: «interop con generador de código» → trimming/NativeAOT con metadatos JSON generados (`JsonSerializerContext`), según [1].
3. §2 Shiny: «1.0.0 → 2.1.0 en menos de un mes» sin fecha de 1.0.0 → 1.0.0 del 2026-09-30, 2.1.0 del 2026-10-15; repo creado 2026-09-15.
4. §2 Oscore: «sólo flujo inmediato», «1.4.1 (2025-07-17)» → flexible o inmediato según prioridad; vigente 1.5.1 (2025-11-21).
5. §2 WebView remoto: afirmación sobre service workers sin fuente → NO VERIFICADO.
6. §2 Uno/Avalonia: «Avalonia 11.3/12», «Uno 6.6» → Avalonia 12.0.0 (2026-04-07), vigente 12.1.4; Uno 6.6 anunciado 2026-08-07, vigente 6.7.135 (fuente [39] agregada).
7. §2 App Center: «retirado el 2025-03-31» → se agrega que Analytics & Diagnostics se extendió hasta 2026-06-30.
8. §3.1 #24201: «concluye… "In-App Updates are not implemented"» → la discusión está sin responder, sin intervención de Microsoft; la frase es un condicional de ewerspej, no un hecho sobre MAUI.
9. §3.1 Shiny: se omitía que, por defecto (`BlockOnRequiredUpdateFailure = false`), una descarga obligatoria fallida se trata como sin red → agregado.
10. §3.2 Shiny: «un release roto se corrige subiendo la versión mínima» presentado como HECHO → CRITERIO PROPIO (el README no lo dice).
11. §3.2, §3.7 y [21]: «.NET 11 GA el 2026-11-10» → Microsoft: «expected in November 2026»; día exacto NO VERIFICADO (ninguna de las dos notas de InfoQ da fecha de GA).
12. §3.3 y §5 P1: `maui.dataforms` como «precedente» → prueba de concepto, sin NuGet, inactiva desde 2023-10-22.
13. §3.4 Shiny: cita «keeping native capabilities in the binary and using `minimumHostVersion`» no textual → cita literal del README.
14. §3.4 Shiny: «un permiso denegado se simula como 403» → los bridges reales responden `403 access_denied` hasta conceder acceso; el simulador puede devolver `501`/`403`.
15. §3.4: #29454 y #27249 presentados sin estado → cerrados el 2026-10-17 (resuelto) y el 2026-10-22 («not planned»).
16. §3.5: faltaba Apple 4.7/4.7.2 («may not extend or expose native platform APIs… without prior permission from Apple»), pertinente al puente → agregado, alcance NO VERIFICADO.
17. §3.5: faltaba la continuación de la política de Google sobre lenguajes interpretados cargados en tiempo de ejecución y la mención del Jiterpreter en [29] → agregadas; se aclara que la lectura de Shiny se apoya en «HTML and JavaScript», no en WASM.
18. §3.5: «publicar APK roto en .NET 10» → holecekp (2026-05-26) dice «in the recent version of Visual Studio»; no menciona .NET 10.
19. §3.6 #35935: «falla de forma recurrente sobre esta función, cerrada 2026-06» → la prueba fallaba por depender de beeceptor.com; abierta 2026-06-16 por un bot, cerrada «not planned» 2026-08-14.
20. §3.7 Avalonia: «sin fork de MAUI» → el post no lo dice; NO VERIFICADO.
21. §3.7 #34171: «la mayoría de las respuestas visibles son críticas», «~45 intervenciones» → generalización sin conteo eliminada; cabecera de GitHub: 18 comentarios + 63 respuestas, 57 bloques en el HTML; no clasificadas por postura. Fin del hilo: 2026-10-19, no 2026-10-15.
22. §4.1 HN 36a: el orden de la cita con «…» invertía el original → reordenada.
23. §5 «Forzado»: «Comunidad dividida (jarlem vs ewerspej)» → dos comentarios con matices distintos, sin valor de medición.

**NO VERIFICADO (estado final):** Reddit (no legible); OTA en Uno/Avalonia; disparo «al iniciar sesión» en Shiny; aceptación de WASM por las tiendas; tamaño/arranque de Blazor WASM en WebView móvil; P13 (por ausencia); service workers en WebView Android bajo MAUI; día exacto de GA de .NET 11; alcance de Apple 4.7.2 sobre contenido propio; «sin fork» del backend Avalonia.

**Confirmado sin cambios (muestra):** textos literales de Apple 2.5.2 y DPLA 3.3.1(B), Google Play «virtual machine or an interpreter…», `WebResourceRequested` «MUST be synchronous» y `Task<Stream>`, `HybridRoot` → `Resources/Raw/wwwroot`, «improve product quality», `EmccMaximumHeapSize`, política de soporte de MAUI y fin de MAUI 10 el 2027-05-11, MAUI 10.0.120 del 2026-10-21, estado y metadatos de #25784/#30847/#28202/#24821/#25804 y del PR #39289 (borrador, `HybridWebApps`, `@maui/api`, «Offline uses the same UI/bridge», certificación pendiente), reglas de actualización de Shiny, Plugin.Maui.AppUpdate (1.0.7, 996 descargas, políticas), las 10 citas de HN, las 4 de SO, la de MS Q&A, las 5 de #34171 y la de The Register.
