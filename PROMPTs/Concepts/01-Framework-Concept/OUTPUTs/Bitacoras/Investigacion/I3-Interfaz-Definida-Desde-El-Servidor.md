# I3 — Interfaz definida desde el servidor (server-driven UI) y formularios dinámicos

| Campo | Valor |
| --- | --- |
| Ángulo | I3 de la investigación pedida por el PO el 2026-10-25 |
| Fecha de consulta de todas las fuentes | 2026-10-25 |
| Investigador | Comisión de investigación I3 |
| Expediente | 0001-Framework-Concept-Maui-Autoactualizable (folios 003–006: P1–P13) |

## Índice

1. [Alcance del ángulo](#1-alcance-del-ángulo)
2. [Qué se usa](#2-qué-se-usa)
3. [Cómo resuelven lo específico](#3-cómo-resuelven-lo-específico)
   - 3.1 Momento de actualización
   - 3.2 Versionado de lo descargado y compatibilidad con la app instalada
   - 3.3 Datos tomados con una versión vieja
   - 3.4 Permisos y capacidades fijados por el manifiesto
   - 3.5 Tiendas: reglas y roces
   - 3.6 Cuándo eligen SDUI y cuándo contenido web
4. [Opiniones de desarrolladores](#4-opiniones-de-desarrolladores)
5. [Lecciones aplicables a P1–P13](#5-lecciones-aplicables-a-p1p13)
6. [Fuentes](#6-fuentes)

Convención: **HECHO** = documentación oficial, anuncio o publicación técnica del propio proveedor, ficha de paquete. **OPINIÓN** = foros, Hacker News, charlas, blogs de terceros o de proveedores que venden la técnica. **NO VERIFICADO** = no se pudo leer la fuente primaria; se dice el motivo. **[criterio propio]** = inferencia de esta comisión, no de una fuente.

---

## 1. Alcance del ángulo

**Definición.** *Server-driven UI* (SDUI, «interfaz definida desde el servidor»): el cliente nativo trae un catálogo fijo de componentes y un renderizador genérico; el servidor manda, en datos (JSON o GraphQL), qué componentes mostrar, en qué orden, con qué datos y qué acciones ejecutan. Lo que cambia sin tienda es la **composición**, no el código: un componente nuevo exige una versión nueva del cliente [F12, F31].

**Pariente cercano: formularios dinámicos.** Un estándar declara el formulario como datos (JSON Schema + esquema de interfaz en JSON Forms; tarjetas en Adaptive Cards; XLSForm/XForms en ODK; JSON de SurveyJS) y una biblioteca lo dibuja. Es SDUI acotado a la captura de datos.

**Por qué importa al caso.** Es la opción **B** de P1 («UI por datos») frente a la opción **A** (WASM/Blazor descargado). El escenario del PO (encuestas en campo, folio 005) es exactamente el terreno de los formularios dinámicos: ODK actualiza la *definición* de la encuesta sin tienda (HECHO, F21, F22). [Verificación: KoboToolbox y «desde hace años» no tienen fuente en este dossier → NO VERIFICADO.]

**Fuera de este ángulo:** actualizaciones de código web por canal propio (Capacitor Live Updates, Expo Updates, CodePush), estrategias de sincronización y outbox, compilación iOS. Sólo se tocan cuando una fuente de SDUI los compara.

**Límites de la investigación.** Los artículos de Airbnb (Medium), Lyft (eng.lyft.com, Medium) y DoorDash devolvieron HTTP 403 al lector automático y a `curl`; sus detalles salen de InfoQ y de extractos del buscador, y van marcados. No se buscó en Reddit con acceso directo (el buscador no devolvió hilos de r/androiddev o r/iOSProgramming sobre SDUI).

---

## 2. Qué se usa

| Nombre | Qué actualiza sin tienda | Cómo trabaja sin red | Cómo fuerza o programa la actualización | Versión / estado vigente | Fuente |
| --- | --- | --- | --- | --- | --- |
| **Airbnb Ghost Platform (GP)** | Pantalla completa: *layout*, orden de secciones, datos y acciones, «controlled by a single backend response» para web, iOS y Android | NO VERIFICADO (InfoQ no lo trata; el artículo primario no se pudo leer) | Cada respuesta del servidor define la pantalla; no hay paso de «actualización» separado | Publicado 2021-06-29; InfoQ lo llamó «relatively young project» con «wide adoption within Airbnb». Estado actual NO VERIFICADO | F1 (vía F2), F2 |
| **Lyft (Bikes & Scooters)** | Flujos de bicicletas y monopatines con componentes y acciones «semánticos» | NO VERIFICADO | NO VERIFICADO | Post de Hartwell y Miko (autores confirmados por el buscador); fecha 2023-03-09 NO VERIFICADA (403; el hilo F4 es del 2023-03-10); «~año y medio» de migración NO VERIFICADO (LinkedIn no consultado). En F4 el coautor *ahartwell* habla de «semantic components and actions» | F3 (sólo título/autores), F4 |
| **DoorDash — componentes SDUI genéricos** | Componentes de UI desacoplados de los modelos de datos; meta: «rely more on backend releases» | NO VERIFICADO | NO VERIFICADO | Post de Ashwin Kachhara, 2021-08-24 (autor y fecha confirmados por el buscador; el post sigue en 403). Equipo «Server Driven UI Platform» con SDK web, Android, iOS: NO VERIFICADO (avisos de empleo no abiertos) | F7 (extracto del buscador) |
| **Shopify Shop App — Store Screen** | Qué secciones y *layout* ve cada tienda de comerciante | No tratado en el artículo; sólo menciona caché del encabezado | Experimentos «whenever we deem necessary»; arreglos por backend en vez de esperar la publicación semanal | 2022-11-22 | F5 |
| **Duolingo — tienda dentro de la app** | Instrucciones de UI de la tienda | Cachea localmente «every data model response» y la configuración de UI | Cliente demasiado viejo: el servidor manda sólo datos («partial response») y el cliente usa su UI cacheada | 2024-11-08 | F8 |
| **Careem AppEngine** | *Layouts* desde el backend | No tratado; menciona «graceful degradation» ante fallas | Sin «additional app releases» | 2025-03-22 | F9 |
| **Reddit — feeds** | El servidor manda «the exact UI elements the client app would render» (GraphQL) | No tratado | No tratado | 2023-09-18; *home feed* 12 % más rápido | F10 |
| **Netflix (charla QCon 2024)** | Pantallas e intersticiales por SDUI | «harder to support offline apps»; se puede empaquetar el JSON como respaldo de flujos críticos | Viejas versiones siguen siendo un problema «until we can somehow completely deprecate those old versions» | Charla QCon London 2024, publicada 2024-12-26 | F11 |
| **Spotify HubFramework** (iOS) | Vistas por componentes con JSON del backend (Browse, Running, Genre Pages) | No tratado | No tratado | **DEPRECADO**: repositorio GitHub archivado, descripción «DEPRECATED», README «being phased out at Spotify»; último *release* CocoaPods 2.0.10, mayo 2017 (verificado de primera mano) | F13 |
| **Microsoft Adaptive Cards** (estándar abierto) | Tarjetas declarativas JSON (texto, entradas, acciones) dibujadas por el *host* | El renderizador es local; el JSON de la tarjeta lo trae el *host* | Versión de esquema en la tarjeta; `requires` + `fallback` por elemento (desde 1.2) | Docs MS Learn actualizadas 2025-12-11. En .NET: `AdaptiveCards.Rendering.Html` 2.7.3 (2021-11-23); `AdaptiveCardsBlazor` 2.0.0 (2019-12-15, sin actualizar) | F14, F15, F16 |
| **JSON Forms** (EclipseSource) | Formularios desde JSON Schema + UI Schema | Biblioteca local; la definición puede viajar como datos | No es su asunto (lo resuelve la app) | Soporte «off the shelf» para React, Angular y Vue; el sitio oficial muestra v3.8.0 vigente y 3.9.0-alpha.1 en preparación (corregido en verificación: antes «3.7/3.8 NO VERIFICADA») | F18 |
| **Orbyss.Blazor.JsonForms** (.NET) | Formularios Blazor desde JSON Schema: «A fully .NET-native implementation of the JsonForms.io standard» (cita corregida en verificación); UI la pone la app | Igual que arriba | — | 1.1.5, 2026-06-05; net8.0 y net10.0; MIT; 2,8 mil descargas | F17 |
| **SurveyJS** | Encuestas desde JSON | Guía oficial: respuestas a almacenamiento local y sincronización al evento `online` | No tratado (la guía no versiona definiciones) | Integración con Blazor **mediante componentes React**, no componentes Blazor nativos | F19, F20 |
| **ODK (Collect + Central) / XLSForm** | Definición del formulario de campo (XLSForm → XForm) | Collect opera sin red; envía al reconectar | Collect: modos «Manual», «Previously downloaded forms only», «Exactly match server», con frecuencia de chequeo configurable. Central: la versión **debe cambiar** para que los clientes actualicen | Docs vigentes (consulta 2026-10-25) | F21, F22, F25 |

**Lectura de la tabla [criterio propio].** Las publicaciones de las grandes (Airbnb, Lyft, DoorDash, Shopify, Reddit, Duolingo, Careem) son apps **siempre conectadas** y casi ninguna documenta el uso sin red. Entre las fuentes de este dossier, el único caso documentado de «definición por datos + sin red + sincronización + versión vieja» es el de las encuestas de campo (ODK).

---

## 3. Cómo resuelven lo específico

### 3.1 Momento de actualización

- **SDUI clásico: no hay «momento»; cada pedido trae la UI.** Airbnb: «Everything from the screen's layout … is controlled by a single backend response» (HECHO, F1 vía F2). Consecuencia: sin red no hay pantalla, salvo caché.
- **Caché y descarga anticipada.** Duolingo cachea la configuración de UI y los modelos (HECHO, F8). En HN, *ruckstar* (2021-09-01): «the UI can be fetched remotely ahead of time in the background and stored on disk» (OPINIÓN, F29).
- **Encuestas de campo (ODK Collect): actualización programada o manual.** «Exactly match server: Collect will automatically download and update forms based on what's on the server»; «Specifies how frequently Collect should check for updates» (HECHO, F22). Hay también un modo en que el encuestador, por defecto, sólo recibe una notificación («Previously downloaded forms only»: «Enumerators will receive a notification when one or more forms on the device have an update available»); ese modo admite además una descarga automática opcional. «Exactly match server» también borra del dispositivo los formularios que no están en el servidor (HECHO, F22; matiz agregado en verificación).
- **Forzar.** Ninguna fuente de SDUI describe un «forzar al abrir»: en SDUI, el servidor simplemente responde con la UI nueva. En ODK, forzar es el modo «Exactly match server» fijado por quien administra el dispositivo (HECHO, F22); un usuario del foro de ODK sostiene que muchos encuestadores no activan la descarga automática (OPINIÓN, foro, vía buscador; NO VERIFICADO el hilo exacto).

### 3.2 Versionado de lo descargado y compatibilidad con la app instalada

Es un costo citado por varias de las fuentes de este dossier (F5, F8, F11, F31) [criterio propio: «el más citado» se retiró en verificación porque no hubo conteo]. Cuatro mecanismos documentados:

| Mecanismo | Quién | Cómo | Fuente |
| --- | --- | --- | --- |
| *Layout* por defecto en el cliente | Shopify | «this default layout would be rendered if the client receives a new layout type it does not understand» | F5 (HECHO) |
| Respuesta parcial por versión | Duolingo | Cliente demasiado viejo para la respuesta nueva → el servidor manda sólo el modelo de datos; el cliente usa su UI cacheada | F8 (HECHO) |
| Versión de esquema + `requires` + `fallback` | Adaptive Cards | `requires`: «features that the item requires with corresponding minimum version. When a feature is missing or of insufficient version, fallback is triggered»; `fallback` puede ser otro elemento o `"drop"` | F14 (HECHO) |
| Componentes «retrocompatibles desde el backend» | Airbnb | Extracto: secciones, *layouts* y acciones compartidos y «backward compatible» | F1 (extracto del buscador; NO VERIFICADO de primera mano: 403) |

Problemas reportados:
- Netflix (Luu): «complicated backwards compatibility concern» con apps que el usuario no actualiza (OPINIÓN de un ingeniero en charla, F11).
- Nativeblocks (proveedor de SDUI): el servidor debe «keep track of different app versions» (OPINIÓN con interés comercial, F31).
- DoorDash: versiones nuevas de componentes con identificadores distintos hacían que versiones viejas de la app **omitieran vistas enteras** — NO VERIFICADO: llega por un resumen de terceros que cita a DoorDash; el post primario dio 403.
- DoorDash 2021, sobre su intento SDUI anterior: arreglo heterogéneo de componentes «prone to deserialization errors» (extracto del buscador del post F7; NO VERIFICADO de primera mano).
- Formularios: ODK Central exige que la versión cambie: «the version must change in order for data collection clients to understand that they should update» (HECHO, F21). XLSForm recomienda la forma `yyyymmddrr` (HECHO, F25).

### 3.3 Datos tomados con una versión vieja

Ninguna publicación de SDUI de las grandes lo trata (son apps en línea). Lo documentado viene de ODK:

- **El servidor acepta envíos de versiones viejas publicadas.** LN, en el foro oficial de ODK (2021-04-20): «Central will accept submissions built from versions 1, 2, 3»; si el formulario se borra, «Central will not accept submissions created for version 1» (testimonio en el foro del proyecto; rol de LN no declarado en la página → se trata como OPINIÓN autorizada, F23). Un usuario cita un PR de GitHub: «Central only accepts submissions for form versions that it is aware of» (F23).
- **Los envíos viejos se conservan; la exportación usa la versión actual por defecto.** «all the previous submissions remain unchanged»; «by default, only the current Form definition will be used in exports» (HECHO, F21).
- **Los borradores no migran a la versión nueva.** LN (2025-03-24): «it's not functionality that's currently available» (F24).
- **Coexistencia en el dispositivo.** Collect puede ocultar versiones viejas: «only the most recently downloaded will be displayed» (HECHO, F22) — la versión vieja sigue para terminar lo empezado.
- Reportes de usuarios (vía buscador; hilos no abiertos uno a uno → NO VERIFICADO el texto exacto): envíos de la v1 llegan con las preguntas nuevas obligatorias en blanco; borradores viejos que fallan al finalizar tras actualizar; parches a mano del número de versión dentro de los XML no enviados.
- SurveyJS guarda respuestas locales y sincroniza, pero su guía no trata el versionado de las definiciones de encuesta (F19; paráfrasis de esta comisión, no cita: corregido en verificación, antes iba entre comillas como si fuera texto de la fuente).

### 3.4 Permisos y capacidades fijados por el manifiesto

- SDUI **no agrega capacidades**: sólo compone lo que el cliente ya trae. Nativeblocks: los componentes nuevos siguen necesitando una publicación normal (OPINIÓN de proveedor, F31). Un blog de Android citado por el buscador dice que SDUI «struggles with … heavy hardware integrations» (OPINIÓN, NO VERIFICADO el autor).
- **Negociación de capacidades: Adaptive Cards es el ejemplo estándar.** El *host* configura el renderizador con HostConfig (p. ej. `supportsInteractivity`: «Control whether interactive `Action`s are allowed to be invoke») y la tarjeta declara qué `requires`; si falta, `fallback` (HECHO, F14, F33; HostConfig verificado de primera mano en verificación). NO VERIFICADO: cómo publica el *host* la lista de *features* contra la que se evalúa `requires` — HostConfig no la trae y la página de esquema no lo dice.
- Ninguna fuente de SDUI consultada habla de permisos de Android/iOS (cámara, ubicación) explícitamente. **[criterio propio]** El patrón `requires`/`fallback` se traslada directo a P12: el contenido declara la capacidad que necesita; el cascarón publica las que tiene; si falta, se degrada o se pide actualizar desde la tienda.

### 3.5 Tiendas: reglas y roces

- **Apple 2.5.2 (HECHO, F26):** las apps no pueden «download, install, or execute code which introduces or changes features or functionality of the app». **4.7 (HECHO, F26):** se permite software no embebido, «specifically HTML5 and JavaScript mini apps and mini games … You are responsible for all such software».
- **Google Play (HECHO, F27):** una app no puede «modify, replace, or update itself using any method other than Google Play's update mechanism», con excepción de «code that runs in a virtual machine or an interpreter» con acceso indirecto a las API de Android, como «JavaScript in a webview or browser».
- **Si SDUI cuenta como «código» es discusión, no regla.** *ruckstar* (HN, 2021-09-01): «Downloading remote code from a server is different than downloading UI configuration»; *joshribakoff* (HN, 2021-09-02): «Whether it downloads code or not is separate from whether you significantly alter the UI»; *rektide* (HN, 2021-07-02): «your template system has to be ultimately technically unintersting» (OPINIONES, F28, F29). NO VERIFICADO: ningún documento de Apple ni de Google consultado nombra al SDUI.
- No se encontró ningún rechazo de tienda documentado por SDUI en las fuentes consultadas.

### 3.6 Cuándo eligen SDUI y cuándo contenido web

- **Thoughtworks Radar** (Trial mar-2022 → Assess oct-2022 → Trial abr-2026): usarlo en «highly dynamic areas of an application», no para toda la UI; advierte de «horrendous, overly configurable messes» y del «god-protocol» (OPINIÓN de consultora, F12).
- **Shopify 2017 (HECHO, F6):** nativo para lo central («Core parts of the app that are used most are native») y, como pauta, para lo de carga intensiva de datos («A feature that is data-entry intensive or has high information density is also a good candidate for a native implementation»); vistas web para lo secundario (configuración, reportes), porque tienen más desarrolladores web que móviles.
- **Netflix (Luu, F11):** SDUI «hyper-specific»; las WebViews son «complicated for us to maintain».
- **Hacker News:** *bob1029* (2021-09-02): «If I had to do it all again from zero today I'd use pure HTML solution»; *krzyzanowskim* (2021-09-01): «web app won't integrate like native components can»; *mamcx* (2021-07-02): «WebView in android is SLOOOOOOOOOWWWWWW»; *slumpt_* (2021-07-02): depende de «your discipline and care in maintaining … your web client» (OPINIONES, F28, F29).
- **[criterio propio]** En nuestro stack la frontera se corre: el contenido Blazor descargado (opción A) *es* contenido web dentro de un cascarón, con la misma flexibilidad de «HTML puro» que reclama *bob1029*, y el SDUI cabría *dentro* de ese contenido como un renderizador de definiciones (JSON Schema/Formly-like) escrito en Blazor.

---

## 4. Opiniones de desarrolladores

Conteo (filas de las tablas 4.1–4.3): **33 citas**: 26 de 4 hilos de Hacker News (F4, F28, F29, F30), 3 del foro de ODK, 1 charla, 2 entradas del Radar de Thoughtworks y 1 blog de proveedor. Por grupo: 10 a favor, 8 en contra, 15 matices. Es señal cualitativa, **no** estadística: los hilos tienen pocos comentarios y se eligieron los sustantivos.

Advertencias de la verificación: (a) el hilo F29 discute el post de judo.app (proveedor de SDUI) y lo envió *krzyzanowskim*; *ruckstar* lo defiende en siete comentarios — la afiliación de ambos con Judo es NO VERIFICADA, pero sus tres citas «a favor» deben leerse con esa posibilidad; (b) la fila de *cataton1a* es el texto de quien envió el enlace, no un comentario de terceros; (c) *ahartwell* es coautor del post de Lyft (lo declara: «Coauthor here»). Descontando (b), quedan 9 opiniones a favor.

### 4.1 A favor

| Fuente | Autor | Fecha | Postura | Cita | Tema |
| --- | --- | --- | --- | --- | --- |
| HN F28 | whoevercares | 2021-07-02 | a favor | «Without such abstraction to generate the UI, the velocity will be terrible with a small UI front-end team.» | escala de equipos |
| HN F28 | adamsvystun | 2021-07-02 | a favor | «You get full performance because you are doing everything natively.» | rendimiento |
| HN F29 | spyspy | 2021-09-01 | a favor con reservas | «It allowed us to add features like "From The Archive" in a few days without a formal app store release.» (también: «a weird DSL») | sin tienda |
| HN F29 | ruckstar | 2021-09-01 | a favor | «Native apps have a different release cycle which brings unique challenges.» | ciclo de tienda |
| HN F29 | ruckstar | 2021-09-01 | a favor | «the UI can be fetched remotely ahead of time in the background and stored on disk.» | sin red |
| HN F29 | ruckstar | 2021-09-01 | a favor | «Downloading remote code from a server is different than downloading UI configuration.» | tienda |
| HN F29 | Zanfa | 2021-09-02 | a favor | «a sane approach to SDUI gives you native UI performance.» | rendimiento |
| HN F29 | krzyzanowskim | 2021-09-01 | a favor (vs. web) | «web app won't integrate like native components can.» | SDUI vs web |
| HN F4 | ahartwell (coautor Lyft) | 2023-03-10 | a favor con costo | la migración fue dolorosa, pero «it's been a huge boon to our productivity» | productividad |
| HN F30 | cataton1a (quien envió el enlace; es su resumen del post de DoorDash, no una opinión independiente; vínculo con DoorDash NO VERIFICADO) | 2021-08-24 | a favor (promocional) | «Learn how Generic server driven UI enabled faster iterations and more experimentation on the DoorDash platform» (cita completada en verificación) | A/B |

### 4.2 En contra

| Fuente | Autor | Fecha | Postura | Cita | Tema |
| --- | --- | --- | --- | --- | --- |
| HN F28 | bosswipe | 2021-07-02 | en contra | «SDUI is the opposite of that, it's tight coupling between all the clients and the backend» | acoplamiento |
| HN F28 | mamcx | 2021-07-02 | en contra (de WebView) | «WebView in android is SLOOOOOOOOOWWWWWW» | web |
| HN F28 | rektide | 2021-07-02 | en contra / tienda | «your template system has to be ultimately technically unintersting» | tienda |
| HN F29 | hitekker | 2021-09-03 | en contra | «For better or for worse, SDUI the buzzword disrespects mobile engineering.» | oficio |
| HN F29 | chacham15 | 2021-09-01 | en contra / tienda | «They like to be in control of what your app experience is.» | tienda |
| HN F29 | bob1029 | 2021-09-02 | en contra (prefiere web) | «If I had to do it all again from zero today I'd use pure HTML solution.» | SDUI vs web |
| HN F29 | syysilma | 2021-09-01 | en contra | «can't imagine this is good for people on slow / no connection.» | sin red |
| Radar F12 | Thoughtworks | oct-2022 | en contra (Assess) | «we've experienced some horrendous, overly configurable messes that didn't actually deliver on the promised benefits» | complejidad |

### 4.3 Matices

| Fuente | Autor | Fecha | Postura | Cita | Tema |
| --- | --- | --- | --- | --- | --- |
| HN F28 | wonnage | 2021-07-02 | matiz | «It's weird that clients have no idea what a page is supposed to look like until the server tells them.» | carga |
| HN F28 | madeofpalk | 2021-07-02 | matiz | «You would basically end up implementing the exact same thing anyway» | web |
| HN F28 | slumpt_ | 2021-07-02 | matiz | «It's entirely a function of your discipline and care in maintaining and building out your web client.» | web |
| HN F28 | alexashka | 2021-07-02 | matiz | «The absence of any mention of UI tooling to make it easy to view, edit, diff» | herramientas |
| HN F28 | polskibus | 2021-07-02 | matiz | «It's good when your requirements are fairly stable, each view falls into a well known category.» | alcance |
| HN F28 | ShabbyDoo | 2021-07-02 | matiz | «How often is the UI spec modified in practice compared to the frequency of UI changes?» | versionado |
| HN F28 | spoonjim | 2021-07-02 | matiz (sin fuente) | «Companies of AirBnb's size have a backchannel with Apple and don't necessarily have to play by the rules» | tienda |
| HN F29 | joshribakoff | 2021-09-02 | matiz | «Whether it downloads code or not is separate from whether you significantly alter the UI.» | tienda |
| HN F29 | manmal | 2021-09-01 | matiz | «Apple tolerates this usually.» | tienda |
| Charla F11 | Christopher Luu (Netflix) | 2024 (pub. 2024-12-26) | matiz | SDUI es «harder to debug», «harder to support offline apps»; debe ser «hyper-specific» | depuración, sin red |
| Radar F12 | Thoughtworks | abr-2026 | matiz (Trial) | usar en «highly dynamic areas of an application»; evitar el «god-protocol» | alcance |
| Blog F31 | Nativeblocks (proveedor) | 2024-09-21 | matiz (interés comercial) | «users in offline or poor network conditions may experience blank screens or broken layouts» | sin red |
| Foro ODK F24 | Cheikh_ibrahima_Fall | 2025-03-24 | pide función | «It would be interesting to have that functionality.» (completar borrador viejo con la versión nueva) | datos con versión vieja |
| Foro ODK F24 | LN | 2025-03-24 | estado | «it's not functionality that's currently available» | datos con versión vieja |
| Foro ODK F23 | LN | 2021-04-20 | estado | «Central will accept submissions built from versions 1, 2, 3.» | datos con versión vieja |

Sin poder citar: el episodio de The Pragmatic Engineer con Reddit (2025-04-23) tiene un tramo titulado «Why server-driven UI isn't taking off, and why Lauren still thinks it could work» (F32); la página no trae transcripción → NO VERIFICADO qué se concluyó.

---

## 5. Lecciones aplicables a P1–P13

| Pregunta | Lección | Fuente |
| --- | --- | --- |
| **P1** modelo A/B/C | Thoughtworks recomienda SDUI en «highly dynamic areas of an application», no para toda la UI (OPINIÓN de consultora). [Corregido en verificación: decía «la industria usa», generalización sin conteo; «las grandes lo construyeron con inversión fuerte y equipos de plataforma» queda NO VERIFICADO: F7 está en 403 y el equipo de DoorDash sale de avisos de empleo no abiertos] | F12, F7 |
| P1 | Para el escenario de encuestas, el antecedente probado es **definición por datos** (XLSForm/ODK), con versión explícita, sin red y sincronización | F21, F22, F25 |
| P1 **[criterio propio]** | Un **C** natural en nuestro stack: el contenido Blazor descargado (A) trae el renderizador de encuestas, y la **definición de la encuesta** viaja como datos (B) con su propia versión. Arreglar un texto o una pregunta no exige bajar código; un tipo de pregunta nuevo sí | — |
| **P2** canal | Versión obligatoria y que cambie en cada publicación; ODK la exige; XLSForm sugiere `yyyymmddrr` | F21, F25 |
| P2 | Borradores/publicación en dos pasos: ODK Central prueba en *Draft* y publica; los envíos de prueba se borran al publicar | F21 |
| **P3** contrato cascarón-contenido | Patrón `requires` (capacidad + versión mínima) + `fallback` (otro elemento o `drop`) es el estándar más documentado para que un *host* viejo no se rompa con contenido nuevo | F14 |
| P3 | Alternativas reportadas: *layout* por defecto ante lo desconocido (Shopify); respuesta parcial con UI cacheada para clientes viejos (Duolingo) | F5, F8 |
| P3 | Riesgo citado: identificadores de componentes que cambian hacen desaparecer vistas en clientes viejos (DoorDash, NO VERIFICADO de primera mano) | F7 |
| P4 entrada | Este ángulo no aporta | — |
| **P5** sin red | SDUI de pantalla completa es «harder to support offline apps»; la salida conocida es cachear o empaquetar el JSON como respaldo | F11, F8 |
| P5 | SurveyJS: respuestas en local y sincronización al evento `online`; sin versionar la definición | F19 |
| P6 PR | Este ángulo no aporta salvo F11 (pruebas abajo) | — |
| **P7** líneas de versión | La definición de la encuesta tiene **su propia línea** de versión (ODK: `version` por formulario, independiente de la versión de Collect) | F21, F22, F25 |
| P7 **[criterio propio]** | Tres líneas, no dos: cascarón (tienda), contenido (canal propio), definiciones (datos) | — |
| **P8** pruebas | Netflix: cargas de ejemplo generadas por el servidor permiten pruebas de captura de pantalla sin montaje punta a punta | F11 |
| P8 **[criterio propio]** | Compuerta: cada definición nueva se valida contra el esquema y se renderiza con el renderizador de la versión mínima soportada. SurveyJS ofrece validación de esquema en servidor (anunciada en Creator 2.5.10, vía buscador; NO VERIFICADO) | — |
| P9 iOS | Apple 2.5.2 prohíbe código que cambie funcionalidad; 4.7 admite mini apps HTML5/JS. Ninguna fuente de Apple nombra el SDUI: su estatus es opinión de foros | F26, F28, F29 |
| P10 guía | Escenarios de campo con versión vieja (ODK) son buen material didáctico: el problema está documentado con casos reales de usuarios | F23, F24 |
| P11 demo | **[criterio propio, sobre los tres paquetes revisados, no un censo de NuGet]** En .NET/Blazor no se encontró un estándar maduro y mantenido: `AdaptiveCardsBlazor` sin cambios desde 2019; `Orbyss.Blazor.JsonForms` es joven (2,8 mil descargas); SurveyJS entra por componentes React | F16, F17, F20 |
| P11 **[criterio propio]** | Para la demo alcanza un renderizador mínimo propio en Blazor sobre una definición JSON versionada, antes que adoptar una biblioteca | — |
| **P12** capacidades | SDUI no suma capacidades: lo nuevo nativo va por tienda. Adaptive Cards modela la negociación (*host* declara, tarjeta `requires`, `fallback`) | F14, F31 |
| **P13** encuestas con versión vieja | ODK: el servidor acepta envíos de toda versión publicada y no borrada; conserva los viejos; exporta con la actual por defecto; los borradores **no** migran a la versión nueva; el dispositivo conserva la versión vieja oculta | F21, F22, F23, F24 |
| P13 **[criterio propio]** | Cada respuesta guarda `id` + `versión` de la definición con que se tomó; el servidor nunca borra una versión con respuestas pendientes; terminar un borrador con su versión original | — |
| **Forzada** (folio 006) | ODK «Exactly match server» con chequeo periódico es el equivalente de «forzar» para definiciones (ojo: también borra del dispositivo lo que no está en el servidor); sin red no se puede forzar, se trabaja con lo último bajado [esto último, criterio propio] | F22 |

---

## 6. Fuentes

Todas consultadas el 2026-10-25.

1. Brooks, Ryan. «A Deep Dive into Airbnb's Server-Driven UI System». Airbnb Tech Blog (Medium), 2021-06-29. https://medium.com/airbnb-engineering/a-deep-dive-into-airbnbs-server-driven-ui-system-842244c5f5 — HTTP 403; contenido sólo vía F2 y extractos del buscador.
2. De Simone, Sergio. «Airbnb's Server-Driven UI Platform». InfoQ, 2021-07-15. https://www.infoq.com/news/2021/07/airbnb-server-driven-ui/
3. Hartwell, Alex; Miko, Tim. «The Journey to Server Driven UI At Lyft Bikes and Scooters». Lyft Engineering, fecha NO VERIFICADA (el dossier decía 2023-03-09; el hilo F4 es del 2023-03-10). https://eng.lyft.com/the-journey-to-server-driven-ui-at-lyft-bikes-and-scooters-c19264a0378e — HTTP 403 también en la verificación; autores vía buscador.
4. Hacker News, hilo del post de Lyft, 2023-03-10. https://news.ycombinator.com/item?id=35095149
5. Narayanan, Ashwin. «Implementing Server-Driven UI Architecture on the Shop App». Shopify Engineering, 2022-11-22. https://shopify.engineering/server-driven-ui-in-shop-app
6. Muzi, David. «Building Shopify Mobile with Native and Web Technology». Shopify Engineering, 2017-09-29. https://shopify.engineering/building-shopify-mobile-with-native-and-web-technology
7. Kachhara, Ashwin. «Improving Development Velocity with Generic, Server-Driven UI Components». DoorDash Engineering, 2021-08-24. https://careersatdoordash.com/blog/improving-development-velocity-with-generic-server-driven-ui-components/ — HTTP 403; contenido vía extractos del buscador.
8. Zhu, Michelle. «How server-driven UI keeps our shop fresh». Duolingo Blog, 2024-11-08. https://blog.duolingo.com/server-driven-ui/
9. Careem Engineering. «How server-driven UI is revolutionizing mobile app experiences» (AppEngine), 2025-03-22. https://engineering.careem.com/posts/app-engine-server-driven-ui
10. Gancarz, Rafał. «Reddit feeds and server-driven UI». InfoQ, 2023-09-18. https://www.infoq.com/news/2023/09/reddit-feed-server-driven-ui
11. Luu, Christopher (Netflix). «Server-Driven UI for Mobile and beyond». QCon London 2024; InfoQ, 2024-12-26. https://www.infoq.com/presentations/server-ui-mobile/
12. Thoughtworks Technology Radar. «Server-driven UI» (mar-2022 Trial, oct-2022 Assess, abr-2026 Trial, vol. 34). https://www.thoughtworks.com/radar/techniques/server-driven-ui
13. Spotify. HubFramework (repositorio GitHub marcado «DEPRECATED»; CocoaPods 2.0.10, mayo 2017). https://cocoapods.org/pods/HubFramework y https://github.com/spotify/HubFramework (archivado; README «Deprecated»).
14. Microsoft Learn. «FactSet Element — Adaptive Cards» (propiedades `fallback`, `requires`), ms.date 2025-12-11. https://learn.microsoft.com/en-us/adaptive-cards/schema-explorer/fact-set
15. NuGet. AdaptiveCards.Rendering.Html 2.7.3, 2021-11-23. https://www.nuget.org/packages/AdaptiveCards.Rendering.Html
16. NuGet. AdaptiveCardsBlazor 2.0.0, 2019-12-15. https://www.nuget.org/packages/AdaptiveCardsBlazor
17. NuGet. Orbyss.Blazor.JsonForms 1.1.5, 2026-06-05. https://www.nuget.org/packages/Orbyss.Blazor.JsonForms
18. EclipseSource. JSON Forms (enlaces React/Angular/Vue). https://jsonforms.io — el sitio oficial muestra v3.8.0 vigente y 3.9.0-alpha.1 (verificado el 2026-10-25).
19. SurveyJS. «Capture Data Anytime, Anywhere: Leveraging SurveyJS Functionality Offline» (sin fecha visible). https://surveyjs.io/stay-updated/blog/offline-form-builder
20. SurveyJS. «Blazor form builder» (sin fecha visible). https://surveyjs.io/stay-updated/blog/blazor-form-builder
21. ODK Docs. «Managing Forms in Central». https://docs.getodk.org/central-forms/
22. ODK Docs. «Collect settings» (modos de actualización de formularios). https://docs.getodk.org/collect-settings/
23. ODK Forum. «Can you still send data from old versions of forms to ODK Central», 2021-04-20/29. https://forum.getodk.org/t/can-you-still-send-data-from-old-versions-of-forms-to-odk-central/33257
24. ODK Forum. «Open a draft with an updated version of the form», 2025-03-24. https://forum.getodk.org/t/open-a-draft-with-an-updated-version-of-the-form/54287
25. XLSForm.org. Especificación, hoja *settings*, campo `version`. https://xlsform.org/en/
26. Apple. App Store Review Guidelines, 2.5.2 y 4.7. https://developer.apple.com/app-store/review/guidelines/
27. Google Play. Política «Device and Network Abuse». https://support.google.com/googleplay/android-developer/answer/9888379
28. Hacker News. «Airbnb's Server-Driven UI System», 2021-07-02. https://news.ycombinator.com/item?id=27707423
29. Hacker News. «What Is Server-Driven UI?» (judo.app), 2021-09-01. https://news.ycombinator.com/item?id=28381168
30. Hacker News. «Improving Development Velocity with Generic, Server-Driven UI Components», 2021-08-24. https://news.ycombinator.com/item?id=28292488
31. Nativeblocks (proveedor de SDUI). «Server-driven UI pros and cons», 2024-09-21. https://nativeblocks.io/blog/server-driven-ui-pros-cons/
32. Orosz, Gergely. «Building Reddit's iOS and Android app» (The Pragmatic Engineer, pódcast), 2025-04-23. https://newsletter.pragmaticengineer.com/p/building-reddits-ios-and-android
33. Microsoft Learn. «HostConfig for Adaptive Cards» (`supportsInteractivity`), ms.date 2020-08-05. https://learn.microsoft.com/en-us/adaptive-cards/rendering-cards/host-config — agregada en la verificación.

---

## Verificación de fuentes

**Fecha:** 2026-10-25. **Verificador:** verificador adversarial del ángulo I3.

**Método.** Se abrió cada fuente citada. Las 26 citas de Hacker News se comprobaron contra el texto completo de los hilos (API de HN en Algolia: autor, fecha y texto literal). Las páginas oficiales y los blogs se leyeron con el lector web. Los datos de NuGet salieron de la API del registro (versiones, fechas, descargas). El estado de HubFramework salió de la API de GitHub.

**Revisadas: 31 de 33 fuentes** abiertas con éxito (F2, F4–F6, F8–F33, más F13 en GitHub). Tres siguen en HTTP 403 también en la verificación (F1 Airbnb, F3 Lyft, F7 DoorDash), y el Archivo de Internet no estaba disponible (429 / bloqueado). De F1 y F7 se confirmaron por buscador el autor, la fecha y los extractos ya marcados como tales.

**Opiniones:** las 33 filas de §4 tienen enlace válido. Las 26 citas de HN son textuales y coinciden en autor y día. Las 7 restantes (foro de ODK ×3, Luu, Thoughtworks ×2, Nativeblocks) coinciden en autor, fecha y texto. No se eliminó ninguna opinión.

**Correcciones (antes → después):**

1. §1: «la industria de encuestas en campo (ODK, KoboToolbox) … desde hace años» → sólo ODK, con fuente; KoboToolbox y «desde hace años» → NO VERIFICADO (sin fuente).
2. §2 JSON Forms: «versión 3.7/3.8 NO VERIFICADA» → v3.8.0 vigente y 3.9.0-alpha.1, según el sitio oficial.
3. §2 Orbyss: cita «following the JsonForms.io standard» (no figura en la fuente) → «A fully .NET-native implementation of the JsonForms.io standard».
4. §2 Spotify HubFramework: «vía buscador» → verificado de primera mano (repositorio archivado, «DEPRECATED»).
5. §2 y F3 Lyft: fecha 2023-03-09 y «~año y medio» de migración → NO VERIFICADO (403; LinkedIn sin abrir).
6. §2 DoorDash: equipo «Server Driven UI Platform» → NO VERIFICADO; autor y fecha confirmados por el buscador.
7. §3.1 ODK: «Previously downloaded forms only = sólo notificación» → notificación por defecto, con descarga automática opcional; además se agrega que «Exactly match server» borra los formularios ausentes del servidor.
8. §3.2: «Es el costo más citado» (sin conteo) → «citado por F5, F8, F11, F31».
9. §3.3 SurveyJS: «does not discuss versioning of survey definitions» iba entre comillas como cita, pero no es texto de la fuente → paráfrasis sin comillas.
10. §3.4 Adaptive Cards: HostConfig «por extracto del buscador» → verificado (F33, `supportsInteractivity`). El vínculo «el host declara las *features* que evalúa `requires`» → NO VERIFICADO.
11. §3.6 Shopify 2017: «nativo … para la carga de datos» (no lo afirma así) → cita literal de la pauta («data-entry intensive … good candidate for a native implementation»).
12. §4.1 cataton1a: presentada como opinión independiente → es el texto de quien envió el enlace (promocional); cita completada.
13. §4: se agregan advertencias sobre posible afiliación con Judo (*krzyzanowskim*, *ruckstar*; NO VERIFICADA) y sobre la coautoría declarada de *ahartwell*.
14. §5 P1: «La industria usa SDUI en…» (generalización) → «Thoughtworks recomienda…»; «las grandes lo construyeron con inversión fuerte…» → NO VERIFICADO.
15. §5 P11: «no hay un estándar maduro» → marcado criterio propio sobre tres paquetes, no un censo.
16. §5 Forzada y §2 «Lectura de la tabla»: se acota el alcance («entre las fuentes de este dossier»; «sin red no se puede forzar» = criterio propio).

**Confirmado sin cambios (muestra):** Apple 2.5.2 y 4.7, y Google Play «Device and Network Abuse» (citas literales). En ODK: Central (versión obligatoria, envíos previos intactos, exportación con la versión actual, envíos de prueba borrados al publicar), XLSForm `yyyymmddrr` y los dos hilos del foro (LN 2021-04-20 y 2025-03-24; Cheikh_ibrahima_Fall 2025-03-24). También Adaptive Cards (`requires`/`fallback`/`"drop"`, versión 1.2, ms.date 2025-12-11), NuGet (AdaptiveCards.Rendering.Html 2.7.3 del 2021-11-23; AdaptiveCardsBlazor 2.0.0 del 2019-12-15; Orbyss 1.1.5 del 2026-06-05, net8.0/net10.0, MIT, 2.777 descargas), Shopify 2022, Duolingo, Careem, Reddit/InfoQ (12 %), Netflix/Luu (las seis citas, intersticiales y pruebas de captura), Thoughtworks (Trial mar-2022 → Assess oct-2022 → Trial abr-2026), Nativeblocks (autor «Alex», 2024-09-21) y Pragmatic Engineer (2025-04-23, tramo a las 54:30, sin transcripción).

**Quedan NO VERIFICADAS: 11.** (1) Airbnb «backward compatible» (F1 en 403; sólo extracto del buscador). (2) Airbnb, uso sin red. (3) Lyft, fecha del post. (4) Lyft, «~año y medio». (5) DoorDash, vistas omitidas en versiones viejas (resumen de terceros). (6) DoorDash, «prone to deserialization errors» (el buscador no lo devuelve). (7) DoorDash, equipo de plataforma SDUI. (8) Foro de ODK: encuestadores que no activan la descarga automática. (9) Blog de Android sobre «heavy hardware integrations». (10) SurveyJS Creator 2.5.10, validación de esquema en servidor. (11) Mecanismo de *features* del *host* para `requires`. Se suman, como reportes de usuarios ya marcados, los hilos de ODK de §3.3 sin abrir uno a uno, y la conclusión del pódcast F32.
