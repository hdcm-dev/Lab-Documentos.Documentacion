# I5 — Opiniones y experiencias de desarrolladores

| Campo | Valor |
| --- | --- |
| Ángulo | I5 — opiniones y experiencias de desarrolladores sobre actualización sin tienda, revisión de tiendas, actualización forzada, sin red y sincronización, apps envueltas |
| Expediente | 0001-Framework-Concept-Maui-Autoactualizable (preguntas P1–P13, folios 003 a 006) |
| Fecha de consulta de todas las fuentes | 2026-10-25 |
| Medios | WebSearch y WebFetch. Sin teléfono y sin compilar nada |
| Autor | Investigador del ángulo I5 |

## Índice

1. [Alcance del ángulo](#1-alcance-del-ángulo)
2. [Qué se usa](#2-qué-se-usa)
3. [Cómo resuelven lo específico](#3-cómo-resuelven-lo-específico)
4. [Opiniones de desarrolladores](#4-opiniones-de-desarrolladores)
5. [Lecciones aplicables a P1–P13](#5-lecciones-aplicables-a-p1p13)
6. [Fuentes](#6-fuentes)

Convenciones del dossier:

- **HECHO**: documentación oficial, anuncio del proveedor o código, con la fuente entre corchetes ([n] remite a §6).
- **OPINIÓN**: publicación de una persona (foro, Hacker News, issue, blog), con usuario, fecha, enlace y cita textual breve en su idioma original. Es señal cualitativa, no estadística.
- **NO VERIFICADO**: no se pudo confirmar en la fuente primaria. Se dice por qué.
- **CRITERIO PROPIO**: lectura del investigador, no de las fuentes.

---

## 1. Alcance del ángulo

El ángulo junta lo que **dicen y cuentan los desarrolladores** sobre cinco temas que tocan a la app de encuestas del Product Owner (folio 005):

1. Actualizaciones por aire (OTA) y sus riesgos: apps rotas, vuelta atrás, usuarios con versiones distintas.
2. Revisión de la App Store y la pauta 2.5.2: rechazos reales por descargar código, y el caso de WebAssembly.
3. Actualización forzada: experiencia de uso, pantallas de «actualizá», In-App Updates de Google Play.
4. Sin red primero y sincronización: cola de salida (outbox), conflictos, idempotencia. Se suma un caso del dominio: las herramientas de encuestas en campo ODK y KoboToolbox, porque ya resolvieron P13 en producción.
5. Apps «envueltas» (un sitio dentro de una WebView) rechazadas por la pauta 4.2.

**Límites de la búsqueda (declarados):**

- **Reddit y Stack Overflow no se pudieron leer.** WebSearch respondió «domains are not accessible to our user agent» para `reddit.com` y `stackoverflow.com`, y WebFetch dijo «unable to fetch from www.reddit.com». Las comunidades r/reactnative, r/FlutterDev, r/iOSProgramming, r/androiddev y r/dotnet quedan **NO VERIFICADAS**. Las reemplazan Hacker News, los foros de Apple, los issues y discusiones de GitHub, los foros de ODK y KoboToolbox, y blogs.
- WebFetch resume las páginas con un modelo y limita las citas largas. Las citas de este dossier son las que ese paso devolvió como textuales. Para usarlas en la guía hay que volver a abrir el enlace.
- Hacker News muestra a veces fechas relativas («45 days ago»). En esos casos se da la fecha aproximada calculada desde el 2026-10-25 y se marca «aprox.».
- No se contó nada como encuesta. Las tablas no dicen qué opina «la mayoría».

---

## 2. Qué se usa

Productos y patrones que aparecen en las experiencias relevadas. El detalle técnico de cada producto es de otros ángulos. Acá va lo que hace falta para leer las opiniones.

| Nombre | Qué actualiza sin tienda | Cómo trabaja sin red | Cómo fuerza o programa la actualización | Versión o estado vigente | Fuente |
| --- | --- | --- | --- | --- | --- |
| Expo EAS Update (React Native) | JavaScript y recursos. Lo nativo exige otra compilación: «If it touches native code, it needs a new build» | La app corre con la última actualización guardada en el teléfono | Por defecto «downloads in the background and applies on the next cold start». La API permite aplicar antes. Canales, preview y despliegue gradual | Vigente. Página de runtime versions: «Last updated on July 03, 2026» | HECHO [1][2] |
| Microsoft CodePush (App Center) | JavaScript de React Native | Paquete guardado | SDK cliente | **Retirado** el 2025-03-31 (README: «CodePush, along with other App Center features, was also retired on March 31, 2025»). Repositorio del servidor archivado; no acepta contribuciones ni issues. *Verificación: la API de GitHub da `archived: true` y último push el 2025-05-20; la fecha exacta del archivado no está expuesta. La cita «as is» no figura en el README: se quitó* | HECHO [3] |
| Ionic Appflow Live Updates (Capacitor) | Web (HTML, CSS, JS) | Paquete guardado | — | Sin ventas nuevas (anuncio del 2025-02-11). Usuarios de Appflow: acceso «through December 31, 2027». Capacitor sigue abierto | HECHO [4] |
| Capgo `capacitor-updater` (Capacitor) | Web (JS, HTML, CSS) | Paquete guardado. Vuelve al paquete integrado si falla | Modos `atBackground` (aplica al pasar a segundo plano), `onlyDownload`, `always`, `onLaunch`. Exige `notifyAppReady()` en cada arranque o vuelve atrás a los 10 s | `@latest` para Capacitor 8; líneas `lts-v7` a `lts-v4` para las anteriores. En iOS, mínimo 8.51.22 (README) | HECHO [5] |
| Shorebird (Flutter) | Código Dart. El fundador: «We had to build a new toolchain for Dart and a custom interpreter (for store compliance)» (corregido: decía «motor de Flutter modificado», que la fuente no dice) | Parche guardado | CLI propio | 1.0 en abril de 2024 | HECHO del anuncio [6] |
| Google Play In-App Updates | **El cascarón** (APK/AAB), por la tienda | No aplica: necesita Play | Flujo flexible (en segundo plano) o inmediato (pantalla completa, «require the user to update and restart») | Android 5.0 o superior. Sólo teléfonos, tabletas y ChromeOS | HECHO [7] |
| ODK Collect y Central (encuestas en campo) | **La definición del formulario** (datos, no código) | Completo: el formulario y las respuestas viven en el teléfono | Modos «Manual», «Previously downloaded forms only» (avisa) y «Exactly match server» (baja y borra lo que no está en el servidor), con frecuencia configurable | Vigente (documentación «© 2026 Get ODK Inc.») | HECHO [8][9] |
| KoboToolbox / KoboCollect | Definición del formulario | Completo | Avisar a los encuestadores o, con red, usar el modo «Exactly match server» con frecuencia automática (advierte que gasta batería). Sin red la app no distingue versiones | Vigente | OPINIÓN de Kal_Lam, del Core Team del foro [10] (corregido: decía «El usuario actualiza», y el mismo mensaje da la opción automática) |
| Patrón «versión mínima desde el servidor» | Nada: bloquea y manda a la tienda | No puede forzar sin red | Comparación de versión al abrir o al volver al frente | Patrón | OPINIÓN [11][12] |

---

## 3. Cómo resuelven lo específico

### 3.1 Momento de actualización

- **Al abrir, aplicada en el arranque siguiente.** Es el comportamiento por defecto de Expo (HECHO [2]). El blog de Mason Roy cuenta el lado malo: si la actualización rompe el arranque, el arreglo no llega, porque «the app never runs long enough to fetch it» (OPINIÓN [13]).
- **En segundo plano y aplicada al pasar a segundo plano.** Es el modo `atBackground` de Capgo (HECHO [5]).
- **Al iniciar sesión.** No aparece como modo de ningún producto relevado. En ODK, el momento es periódico o lo decide el usuario (HECHO [8]). La única mención encontrada en la verificación es una OPINIÓN de parte interesada sin fuente: «Large games ship their lua scripts down when you log in, etc.» (eseidel, fundador de Shorebird, 2024-04-09, [19], comentario 39975422). Como práctica de la industria para apps como la del PO (folio 004) sigue **NO VERIFICADO**.
- **Forzado.** Para el cascarón, sólo Android tiene un flujo de tienda (HECHO [7]). En iOS, un participante del foro de Apple lo dice así: «you can't force users to update. If nothing else, your upgrade will be blocked if there's no network connectivity when your app runs» (QuinceyMorris, ago-2018, OPINIÓN [11]; en ese hilo habla de las actualizaciones de la tienda, es decir, del cascarón). Para el contenido, el README de Capgo **recomienda no forzar en la App Store**: «don't enable the `Force update` scenario» y «Do not tell the user the app is updating» (HECHO de la documentación del proveedor [5]). Verificación: el README funda la recomendación de no forzar en una pauta que cita como «Apps must not force users to rate the app, review the app, download other apps, or other similar actions…»; la versión vigente de Apple (3.2.2 (x), «Last Updated: October 16, 2026») dice «or other store-related actions». Que esa pauta alcance a forzar una actualización de contenido es lectura del proveedor, no texto de Apple.

### 3.2 Versionado de lo descargado y compatibilidad con la app instalada

- Expo llama «runtime version» a la garantía de compatibilidad entre el código nativo instalado y la actualización: «Runtime versions are a property that guarantees compatibility between a build's native code and an update». La política `fingerprint` la sube «whenever anything that may impact the native runtime changes». La política `appVersion` depende de que alguien se acuerde de subir la versión (HECHO [1]).
- El blog oficial de Expo la llama «your compatibility firewall» y recomienda probar en un canal de preview antes de producción (HECHO del proveedor, autora de marketing [2]).
- La falla típica, contada por un desarrollador: «you ship JS that calls a native module the build doesn't have, and the app crashes on launch» (Mason Roy, OPINIÓN [13]).
- Equivale al `minShellVersion` del borrador (Framework-APP.md §3). CRITERIO PROPIO.

### 3.3 Datos tomados con una versión vieja (P13)

Las herramientas de encuestas en campo ya tienen este problema en producción:

- **ODK Central exige cambiar la versión** para publicar una definición nueva: «the `version` must change in order for data collection clients to understand that they should update». Las respuestas anteriores no se tocan: «all the previous submissions remain unchanged». El tipo de un campo publicado no se puede cambiar, salvo a texto. Y advierte: «Changing a form definition while it is in use will likely complicate analysis and may significantly impact results» (HECHO [9]).
- **Lo que pasa en la práctica**, contado en el foro de ODK: «the answers filled with previous versions still save but leave the new questions blank» (Marco, 2020-05-18, OPINIÓN [14]). El mismo usuario pide «showing an error on old versions» y nadie le da una forma de hacerlo.
- **KoboToolbox:** un moderador dice que sin red la app «cannot distinguish a form whether it's using the old version or the updated version», que igual se puede enviar la respuesta vieja, y que «the server too does not restrict this» (Kal_Lam, 2024-08-17, OPINIÓN [10]). Recomienda cerrar el formulario antes de salir a campo y avisar a los encuestadores por teléfono o SMS.

### 3.4 Permisos y capacidades fijados por el manifiesto (P12)

- Lo nativo no viaja por aire: lo dicen Expo (HECHO [1][2]) y el anuncio de Shorebird, que se limita a lo que corre en su intérprete (HECHO [6]).
- Apple prohíbe que una actualización «introduces or changes features or functionality of the app» (pauta 2.5.2, HECHO [15]). En el issue #1865 de Expo, Apple rechazó una app por «hidden features» cargadas con JavaScript remoto (HECHO del texto de rechazo citado por el autor del issue [16]). Matiz de la verificación: antes de ese mensaje, un mantenedor de Expo (terribleben, 2018-06-13) leyó el código y dijo que la app «is designed to compile and execute code remotely»; el caso no es una app de formularios común.
- CRITERIO PROPIO: si el contenido nuevo pide una capacidad que el cascarón no declaró, el problema es doble. Técnicamente, la capacidad no existe. Ante la tienda, parece una función escondida.

### 3.5 Rechazos y problemas con las tiendas

| Caso | Qué pasó | Clase |
| --- | --- | --- |
| Rollout.io, marzo de 2017 | Apple empieza a rechazar apps con parcheo en caliente. El CEO y cofundador de Rollout, Erez Rusovsky, en su blog citado por 9to5Mac: «Our platform has been used by hundreds of developers to improve the quality of their apps». *Corregido: la cita anterior («life saver for hundreds of apps», atribuida al «CEO (adjunct)» y a [17]) no está en el hilo [17] ni en 9to5Mac, mjtsai ni TechCrunch: NO VERIFICADA y retirada* | HECHO del evento [17]; cita OPINIÓN [33] |
| Expo, issue #1865, junio de 2018 | Rechazo 2.5.2 y apelación denegada. Pasó al desactivar OTA (`updates.enabled: false`). Otro usuario (AndyMoreland, 2019-04-24/25) pasó apelando; reconstruye de memoria lo que escribió a Apple: «we only use it for minor bug fixes» | HECHO del issue [16] |
| Expo, discusión #16286, 2022-03-28 | Un mantenedor (hirbod): «There have been cases where Apple rejected apps with activated expo-updates, but these are rare…» | OPINIÓN [25] |
| Shorebird, abril de 2024 | El fundador (eseidel): «We've seen 1000s of releases in the last year, and not had a single complaint about rejections» | OPINIÓN de parte interesada [19] |
| Capgo | Versiones viejas del plugin fueron rechazadas por 2.5.2 por un selector de `autoSplashscreen`. El arreglo fue actualizar el plugin | HECHO del README [5] |
| Pauta 4.2, foro de Apple, noviembre de 2025 | ahomag: «My app has been rejected for the 10th time for the same reason». Era una app web en WebView (después hizo nativa la pantalla principal y quedaron 2-3 pantallas en WebView). App Review sólo respondió ofreciendo una consulta | OPINIÓN [20] |
| WebAssembly | No se encontró ninguna resolución de Apple que nombre WebAssembly. La fuente más citada es un proveedor de OTA por WASM (Patch), que admite que la última palabra la tiene Apple | NO VERIFICADO: sin fuente primaria ni caso de rechazo o aprobación documentado. Verificación: la página [21] se abrió; dice «no WebAssembly OTA tool — Patch included — has CodePush's enforcement history yet» y «Apple, not any vendor, gets the final word on that reading» [21] |

Google Play prohíbe que una app se actualice «using any method other than Google Play's update mechanism», salvo el código que corre en una máquina virtual o un intérprete con acceso indirecto a las API de Android, «such as JavaScript in a webview or browser» (HECHO [22]). Apple, en cambio, sólo permite expresamente software fuera del binario para «HTML5 and JavaScript mini apps and mini games» y casos similares (pauta 4.7, HECHO [15]).

---

## 4. Opiniones de desarrolladores

Las filas son opiniones, no hechos. Lo que se contó: **43 opiniones**, una por fila, de 38 autores distintos, sacadas de 17 hilos o páginas. Es la cantidad que este ángulo citó, **no una muestra**.

### 4.1 A favor (de la OTA, el forzado o lo híbrido)

| Fuente | Autor | Fecha | Postura | Cita | Tema |
| --- | --- | --- | --- | --- | --- |
| [23] HN 49647401 | spiderice | 2026-09-10 | A favor | «Nobody is talking about the real advantage of RN: Being able to release to the App Store without having to go through a review.» | OTA |
| [23] | tcoff91 | 2026-09-10 | A favor | «Being able to ship hotfixes instantly to our users has saved our asses multiple times.» | OTA |
| [23] | sebmellen | 2026-09-11 | A favor | «We have clients that often require quick changes for compliance reasons... That's not easy without OTA.» | OTA |
| [17] HN 13817557 | Nexxxeh | 2017-03-08 | A favor | «live patching allowed companies to fix or mitigate security problems faster than Apples» | 2.5.2 |
| [17] | mikeash | 2017-03-08 | A favor (crítico de Apple) | «Apple's review process is really quick and adds approximately nothing in terms of security.» | 2.5.2 |
| [19] HN 39973150 (comentario 39975422) | eseidel (fundador de Shorebird) | 2024-04-09 | A favor (parte interesada) | «Self-updating seems to be pretty well established practice.» | OTA / 2.5.2 |
| [24] HN 41146779 | kevingadd (corregido: decía «kg») | 2024-08-03 | A favor (descriptivo) | «nearly 100% of them pull down new interpreted code on a regular basis on mobile.» (sobre juegos de servicio continuo) | OTA |
| [24] | nox101 | 2024-08-04 | A favor | «They update every time the server updates the page. No review required.» (sobre apps WebView) | Híbridas |
| [11] Foro Apple 107576 | iway | 2023-10 | A favor | «We can use over the air updates to force upgrade application code without having to install a new App Store version.» | Forzado |
| [25] Foro GitHub Expo #16286 | jeffcad | 2022-03-27 | A favor (tranquiliza) | «I wouldn't worry about your account being blocked.» | 2.5.2 |
| [26] HN 40228866 | pragmar | 2024-05-01 | A favor | Blazor Hybrid es «pretty great, seems better in every way except routing and some aspnet functionality is lost» | Blazor Hybrid |
| [26] | pragmar | 2024-05-01 | A favor | «Faster app startups, and feels generally more responsive.» | Blazor Hybrid |

### 4.2 En contra

| Fuente | Autor | Fecha | Postura | Cita | Tema |
| --- | --- | --- | --- | --- | --- |
| [17] HN 13817557 | eeeeeeeeeeeee | 2017-03-08 | En contra | «what you end up doing is effectively destroying the security protections Apple puts in place» | 2.5.2 |
| [17] | lloeki | 2017-03-08 | En contra | «As a security-conscious user, live patching is awful.» | OTA |
| [17] | HappyTypist | 2017-03-08 | En contra | «you can't remotely modify how native apps work, even if you do it through a JS delivery mechanism.» | 2.5.2 |
| [17] | macspoofing | 2017-03-08 | En contra | «you clearly and blatantly circumvented a core policy, and what happened to you was absolutely predictable.» | 2.5.2 |
| [23] HN 49647401 | apitman | 2026-09-11 | En contra | «I think updating js without review is also against policy.» (responde en una rama sobre WebAssembly, donde antes dijo «I am fairly certain this is against Apple's policies») | 2.5.2 / WASM |
| [23] | myko | 2026-09-11 | En contra | «Doesn't seem like a grey area at all, pretty clear it is against the policy.» | 2.5.2 |
| [19] HN 39973150 | pritambarhate | 2024-04-09 | En contra | «This service is straight up lying when it says that Remote Code Push is implemented as per Apple's guidelines.» | 2.5.2 |
| [19] | dr_kiszonka | 2024-04-08 | En contra (pregunta) | «Wouldn't this allow you to remotely inject malware into an app?» | Seguridad OTA |
| [19] | lxgr | 2024-04-08 | En contra | Cargar lógica en tiempo de ejecución «just doesn't sound like a great idea» | OTA |
| [27] HN 46167140 | LoganDark | 2025-12-05 | En contra | «Be careful with this. If Apple finds out for instance, your app will still be taken down.» | 2.5.2 |
| [27] | LoganDark | 2025-12-05 | En contra | «by sidestepping the review process you'd better be confident you don't ever ship anything that wouldn't pass.» | 2.5.2 |
| [28] HN 29043216 | dfabulich | 2021-10-29 | En contra (de envolver) | «Your app is clearly a web clipping.» (su reconstrucción del argumento de los revisores: «Their argument basically went like this») | 4.2 |
| [28] | dfabulich | 2021-10-30 | En contra | «As long as your app is, literally, a repackaged website, I really can't imagine how you'd argue your way out of a rejection.» | 4.2 |
| [20] Foro Apple 806726 | darkpaw | 2025-11 | En contra (de envolver) | «Write those pages as native pages inside your app rather than merely views onto a web page.» | 4.2 |
| [12] Lendable | Rob Walker | 2026-05-14 | En contra (del forzado simple) | La versión mínima es «a blunt instrument that lacks the nuance required for modern app management» | Forzado |
| [11] Foro Apple 107576 | QuinceyMorris | 2018-08 | En contra (de poder forzar) | «you can't force users to update. If nothing else, your upgrade will be blocked if there's no network connectivity when your app runs.» | Forzado / sin red |
| [29] HN 45730421 | pjmlp | 2025-10-28 | En contra | «I give zero value to Blazor Hybrid, from my point of view it doesn't exist.» | Blazor Hybrid |

### 4.3 Matices

| Fuente | Autor | Fecha | Postura | Cita | Tema |
| --- | --- | --- | --- | --- | --- |
| [13] dev.to | Mason Roy | 2026-09-30 | Matiz | «Rollback isn't a button.» y «rollback won't save the users already affected.» | Vuelta atrás |
| [16] GitHub Expo #1865 | AndyMoreland | 2019-04-24 y 25 | Matiz | «Our app was accepted after we filed an appeal noting that we use expo.» Lo que dice haber escrito, de memoria: «we only use it for minor bug fixes» (corregido: la cita anterior no era textual) | 2.5.2 |
| [25] GitHub Expo #16286 | hirbod | 2022-03-28 | Matiz | «There have been cases where Apple rejected apps with activated expo-updates, but these are rare…» (la oración sigue) | 2.5.2 |
| [23] HN 49647401 | whstl | 2026-09-10 | Matiz técnico | «you generally can't download and execute new compiled native code on iOS, due to iOS code-signing/executable-memory restrictions.» | Límite nativo |
| [24] HN 41146779 | j45 | 2024-08-04 | Matiz | «Review is for sizeable changes that are black and white across some lines, and also keeping malicious apps out.» | Revisión |
| [24] | layer8 | 2024-08-04 | Matiz (descriptivo) | Sobre cómo **esconder funciones a la revisión**: «1–3 could be replaced by having the app check its own app store listing.» y «any update check (is there a newer version available?) can double as a “is this version still in app review?” check» (corregido: estaba clasificado como propuesta de forzado; responde a waiwai933, que describe activar funciones «secretas» por número de build) | Evasión de revisión |
| [30] Blog | Saagar Jha | 2020-11-08 | Matiz (crítico de la regla) | 2.5.2 «does not distinguish between user and developer code» | 2.5.2 |
| [28] HN 29043216 | fulafel | 2021-10-30 | Matiz | Una PWA con funciones sin red y notificaciones podría cumplir la 4.2 (paráfrasis del resumen) | 4.2 |
| [12] Lendable | Rob Walker | 2026-05-14 | Matiz (propuesta) | «Only app versions requiring a critical fix are subjected to a forced server update.» | Forzado dirigido |
| [31] HN 45333021 | cyberax | 2025-09-23 | Matiz | «Just ignore the conflicts. The last change wins.» y «impossible conflicts are impossible to solve automatically anyway and require business processes around them.» | Conflictos |
| [31] | cyberax | 2025-09-23 | Matiz (contexto) | «Public app used by professionals in the field, often with poor or no connectivity.» | Campo |
| [31] | kobieps | 2025-09-23 | Matiz | «in my experience last-write-wins is sufficient for 95% of use cases» | Conflictos |
| [32] HN 28717848 | LAC-Tech | 2021-10 | En contra de LWW | «Last write wins is not handling data sync, it's washing your hands of it.» | Conflictos |
| [32] | lazide | 2021-10 | Matiz | «At least an API server can clearly reject the client and give an error message.» | Clientes viejos |

Los «95%» de kobieps son su percepción, no una medición.

---

## 5. Lecciones aplicables a P1–P13

| Pregunta | Lección | Fuente | Clase |
| --- | --- | --- | --- |
| P1 (modelo de contenido) | Las herramientas de encuestas en campo actualizan la **definición del formulario como datos**, no como código (ODK, Kobo) | [8][9][10] | HECHO |
| P1 | Para la encuesta, la definición como datos (opción B) evita la discusión de la 2.5.2 sobre código que «changes features», y deja la opción A para el resto de las pantallas | [15][16][17] | CRITERIO PROPIO |
| P2 (canal) | Probar en un canal previo, desplegar de a poco y volver atrás reponiendo una versión buena que el teléfono ya tiene guardada | [2][13] | HECHO del proveedor + OPINIÓN |
| P2 | Que el contenido nuevo confirme que arrancó bien (`notifyAppReady`), y si no lo hace a tiempo, se vuelva al anterior. Protege del caso «arranca, se rompe y nunca baja el arreglo» | [5][13] | HECHO [5] + OPINIÓN [13] |
| P2 | Los servicios de terceros se cierran: CodePush retirado en 2025, Appflow termina en 2027. Es un argumento a favor del servidor propio que ya plantea el borrador | [3][4] | HECHO; la consecuencia es CRITERIO PROPIO |
| P3 (cascarón y contrato) | Una versión de compatibilidad entre cascarón y contenido, calculada de lo nativo (fingerprint) mejor que a mano, porque a mano se olvida | [1] | HECHO |
| P5 (sin red) | Cada operación de la cola de salida lleva una clave de idempotencia que el servidor recuerda | Blogs técnicos, ver motivo | NO VERIFICADO: sólo blogs de proveedores en la búsqueda, sin fuente primaria leída |
| P5 | Conflictos: la experiencia de campo dice que algunos no se resuelven automáticamente y piden un proceso de negocio y una bitácora de auditoría. LWW tiene defensores y detractores | [31][32] | OPINIÓN |
| P5 | Las respuestas de una encuesta se agregan y no se editan entre usuarios, así que casi no generan conflictos. La complejidad está en la versión de la definición (P13), no en la fusión | — | CRITERIO PROPIO |
| P6–P8 (PR y pruebas) | La falla de producción más contada es contenido que llama algo que el cascarón instalado no tiene. Conviene una compuerta que lo detecte antes de publicar | [1][13] | HECHO + OPINIÓN |
| P10 (guía) | Las historias de falla (bucle de cierre al arrancar, rechazo 2.5.2, encuestas con preguntas en blanco) enseñan el porqué de cada regla | [13][14][16] | CRITERIO PROPIO |
| P12 (manifiesto) | Lo nativo y los permisos no viajan por aire. Una capacidad que el contenido «enciende» y la revisión no vio puede leerse como «hidden features» | [1][15][16] | HECHO |
| P13 (encuestas con versión vieja) | La versión de la definición es obligatoria y viaja con cada respuesta. El servidor acepta respuestas de versiones viejas sin tocarlas. Un campo publicado no cambia de tipo | [9] | HECHO |
| P13 | Si la respuesta vieja se abre con la definición nueva, las preguntas nuevas quedan en blanco, y sin red la app no distingue versiones. Hace falta decidir explícitamente qué pasa con las respuestas en curso | [10][14] | OPINIÓN |
| Forzado (folio 006) | Contenido: forzable sólo si hay red. Cascarón: Android tiene el flujo inmediato de Play; iOS sólo puede bloquear y mandar a la tienda | [7][11] | HECHO [7] + OPINIÓN [11] |
| Forzado | Forzar a todos castiga a quien no lo necesita. Conviene que el servidor decida por versión y por condición | [12] | OPINIÓN |
| Forzado vs revisión | Un chequeo de versión con el servidor es también el mecanismo que se usa para esconder funciones a la revisión; la decisión por versión debe limitarse a forzar o avisar, no a encender capacidades | [24] | CRITERIO PROPIO, a partir de OPINIÓN (layer8, waiwai933) |
| Forzado vs 2.5.2 | Hay tensión: el README de Capgo recomienda no forzar ni anunciar la actualización en iOS. La pantalla «actualizando contenido» del borrador debe pasar por esta lente | [5] | HECHO del proveedor; la tensión es CRITERIO PROPIO |
| Forzado vs encuesta | No forzar una actualización que descarte o invalide encuestas tomadas sin sincronizar. Primero sincronizar, después actualizar | [10][14] | CRITERIO PROPIO, a partir de OPINIÓN |
| 4.2 (envolver) | Una app que es sólo una WebView de un sitio se rechaza. Un cascarón con contenido local que funciona sin red y usa el dispositivo está en mejor posición | [15][20][28] | HECHO [15] + OPINIÓN |
| 4.2 | Se dice que un revisor pone el teléfono en modo avión para probar | Blogs de consultoras | NO VERIFICADO: afirmación secundaria sin fuente de Apple |
| 4.2 | Se cuenta que una app Cordova se aprobó tras agregar una interfaz local y una pantalla de inicio | Resumen de búsqueda | NO VERIFICADO: el hilo 113837 abierto con WebFetch no lo contiene |
| WebAssembly / Blazor WASM descargado | No hay resolución pública de Apple sobre WASM descargado. El contenido Blazor WASM descargado de la demo del g42 queda en zona gris en iOS | [21] | NO VERIFICADO para Apple; la zona gris es CRITERIO PROPIO |
| Login (folio 004) | No apareció ningún producto con «actualizar al iniciar sesión» como modo de actualización. Única mención: eseidel, sin fuente, sobre juegos que bajan scripts Lua «when you log in» | [19] | NO VERIFICADO como práctica; la mención es OPINIÓN de parte interesada |

---

## 6. Fuentes

Todas consultadas el 2026-10-25.

1. Expo — «Runtime versions», docs.expo.dev, modificada el 2026-07-03. https://docs.expo.dev/eas-update/runtime-versions/
2. Expo (Ishika Chakraborty, Marketing) — «5 OTA Update best practices every mobile team should know», 2026-02-24. https://expo.dev/blog/5-ota-update-best-practices-every-mobile-team-should-know
3. Microsoft — repositorio `microsoft/code-push-server`, archivado (último push 2025-05-20; README «Archiving this repository»). https://github.com/microsoft/code-push-server
4. Ionic (The Ionic Team) — «Important Announcement: The Future of Ionic's Commercial Products», 2025-02-11. https://ionic.io/blog/important-announcement-the-future-of-ionics-commercial-products (abierta en la verificación)
5. Capgo — README de `Cap-go/capacitor-updater`. https://github.com/Cap-go/capacitor-updater
6. Shorebird — repositorio `shorebirdtech/shorebird`, y anuncio de 1.0 en Hacker News del 2024-04-08 (ver [19]; el texto del anuncio es la fuente del intérprete propio). https://github.com/shorebirdtech/shorebird
7. Android Developers — «In-app updates». https://developer.android.com/guide/playcore/in-app-updates
8. ODK — «Collect settings», © 2026. https://docs.getodk.org/collect-settings/
9. ODK — «Central forms», © 2026. https://docs.getodk.org/central-forms/
10. KoboToolbox Community — «Restricting user to sumbit data when they are not on the live version in Kobocollect App», raushan.jha (2024-08-16) y Kal_Lam, Core Team (2024-08-17). https://community.kobotoolbox.org/t/restricting-user-to-sumbit-data-when-they-are-not-on-the-live-version-in-kobocollect-app/57150
11. Apple Developer Forums — «Best practice to force upgrade app», 2018-08 a 2023-10. https://developer.apple.com/forums/thread/107576
12. Rob Walker (Lendable) — «A Better Forced Update Approach», 2026-05-14. https://careers.lendable.com/blog/articles/a-better-forced-update-approach
13. Mason Roy — «Expo OTA Updates Are a Loaded Gun. Here's the Safety.», dev.to, 2026-09-30 (`datePublished` de la página). https://dev.to/mason_roy/expo-ota-updates-are-a-loaded-gun-heres-the-safety-1c1k
14. ODK Forum — «How to force form update», Marco y seadowg, 2020-05-18. https://forum.getodk.org/t/how-to-force-form-update/26553
15. Apple — «App Review Guidelines» (2.5.2, 2.5.6, 3.2.2, 4.2, 4.2.2, 4.7), «Last Updated: October 16, 2026». https://developer.apple.com/app-store/review/guidelines/
16. GitHub expo/expo — issue #1865 «AppStore: Binary Rejected», bushev, 2018-06-13 a 2019. https://github.com/expo/expo/issues/1865
17. Hacker News — «Apple starts rejecting apps with "hot code push" features», 2017-03-08. https://news.ycombinator.com/item?id=13817557
18. (Sin uso: la discusión #16286 de Expo se cita como [25].)
19. Hacker News — «Show HN: Shorebird 1.0, Flutter Code Push», eseidel, 2024-04-08. https://news.ycombinator.com/item?id=39973150 (comentario de 00deadbeef y respuesta: https://news.ycombinator.com/item?id=39974945)
20. Apple Developer Forums — «Guideline 4.2 - Design - Minimum Functionality», ahomag, 2025-11. https://developer.apple.com/forums/thread/806726
21. Patch (proveedor) — «Does Apple Allow OTA Updates on iOS? Guideline 2.5.2». https://patchrelease.com/blog/what-apple-allows-ota-updates (abierta en la verificación; parte interesada)
22. Google Play — Política de abuso de dispositivos y redes. https://support.google.com/googleplay/android-developer/answer/9888379
23. Hacker News — hilo «Shopify is moving from React Native back to Swift and Kotlin» (historia 49643982, 2026-09-10), comentario de spiderice, 2026-09-10. https://news.ycombinator.com/item?id=49647401
24. Hacker News — «Techniques used by developers to bypass App Store review», 2024-08-03 (comentarios del 2024-08-03 y 04). https://news.ycombinator.com/item?id=41146779
25. GitHub expo/expo — discusión #16286 «[expo-updates] Concerns about bypassing Google/Apple app review», MPBogdan, 2022-02-13. https://github.com/expo/expo/discussions/16286
26. Hacker News — pathartl y pragmar en «Xamarin has reached End of Support», 2024-05-01 (el enlace es el comentario de pathartl; la historia es 40226863; título del hilo no verificado). https://news.ycombinator.com/item?id=40228866
27. Hacker News — LoganDark, rahimnathwani y otros en «Show HN: HCB Mobile – financial app built by 17 y/o, processing $6M/month» (historia 46130260), 2025-12-05. https://news.ycombinator.com/item?id=46167140
28. Hacker News — dfabulich y otros en «Publish your PWA to the iOS App Store», 2021-10-29. https://news.ycombinator.com/item?id=29043216 (comentario de dfabulich; la historia es https://news.ycombinator.com/item?id=29040793)
29. Hacker News — aryonoco y pjmlp en «Rust cross-platform GPUI components» (historia 45719004), 2025-10-28. https://news.ycombinator.com/item?id=45730421
30. Saagar Jha — «Fixing Section 2.5.2», 2020-11-08. https://saagarjha.com/blog/2020/11/08/fixing-section-2-5-2/
31. Hacker News — «Why haven't local-first apps become popular?», 2025-09-22. https://news.ycombinator.com/item?id=45333021
32. Hacker News — «Downsides of Offline First», 2021-10-01 (artículo: https://rxdb.info/downsides-of-offline-first.html). https://news.ycombinator.com/item?id=28717848

33. 9to5Mac (Chance Miller) — «Rollout hot code push policy shift», 2017-03-08, cita del blog de Erez Rusovsky, CEO de Rollout. https://9to5mac.com/2017/03/08/rollout-hot-code-push-policy-shift/ (agregada en la verificación)

**Consultadas y no utilizables:** reddit.com y stackoverflow.com (bloqueadas para el agente de usuario, ver §1).

---

## Verificación de fuentes

| Campo | Valor |
| --- | --- |
| Fecha | 2026-10-25 |
| Rol | Verificador adversarial |
| Medios | Hacker News por la API pública de Algolia (`hn.algolia.com/api/v1/items/<id>`, texto completo de cada comentario con autor y hora UTC); foros Discourse de ODK y KoboToolbox por su JSON; issue #1865 de Expo por la API de GitHub; README de Capgo, CodePush y Shorebird en crudo; páginas de Expo, Ionic, Android, ODK, Apple (pautas), Google Play, Lendable, dev.to, Patch y Saagar Jha descargadas y buscadas por texto exacto; foros de Apple y discusión #16286 de Expo con WebFetch (bloquean la descarga directa) |
| Revisado | 31 fuentes usadas (de [1] a [32], sin [18]) y las 43 opiniones de §4, una por una; además las afirmaciones de HECHO de §2, §3 y §5 que remiten a esas fuentes |

**Resultado de las opiniones.** Las 43 citas de §4 existen, en el enlace dado y con el autor dado. Las textuales coinciden con la fuente salvo las corregidas abajo. Las fechas «aprox.» se reemplazaron por la fecha exacta (UTC) que da la API de Hacker News, por lo que la nota de §1 sobre fechas relativas ya no aplica a las filas de §4.

**Correcciones (antes → después):**

1. CodePush [3]: «archivado el 2025-05-20, "as is"» → archivado (API de GitHub: `archived: true`, último push 2025-05-20; la fecha exacta del archivado no está expuesta). «as is» no figura en el README y se quitó.
2. Ionic [4]: «fecha no visible», leída sólo por el resumen → anuncio del 2025-02-11, abierto; acceso de Appflow «through December 31, 2027» confirmado.
3. Capgo [5]: «Línea 8.x para Capacitor 8» → `@latest` para Capacitor 8 y mínimo 8.51.22 en iOS, como dice el README.
4. Shorebird [6]: «motor de Flutter modificado» → «a new toolchain for Dart and a custom interpreter» (texto del anuncio en [19]).
5. KoboToolbox [10], §2: «El usuario actualiza» → el mismo mensaje de Kal_Lam ofrece también «Exactly match server» con frecuencia automática, con red.
6. Rollout [17], §3.5: la cita «Our current product has been a life saver for hundreds of apps», del «CEO (adjunct)», **no está** en el hilo [17] ni en 9to5Mac, mjtsai ni TechCrunch → retirada como NO VERIFICADA y reemplazada por la cita de Erez Rusovsky que trae 9to5Mac [33].
7. AndyMoreland [16]: «only for minor OTA bug fixes» presentada como cita → no es textual; lo textual es «Our app was accepted after we filed an appeal noting that we use expo.» y, reconstruido de memoria por él, «we only use it for minor bug fixes».
8. Autor en [24]: «kg» → kevingadd.
9. layer8 [24]: clasificado como propuesta de **forzado** → es la descripción de una técnica para **esconder funciones a la revisión** (responde a waiwai933). Se reclasificó el tema y se agregó una lección en §5 marcada CRITERIO PROPIO.
10. whstl [23]: ~2026-09-11 → 2026-09-10 (23:46 UTC).
11. dfabulich [28]: «lo que le dijeron los revisores» → es su reconstrucción («Their argument basically went like this»).
12. Mason Roy [13]: «año no visible» → 2026-09-30 (`datePublished`).
13. Pautas de Apple [15]: «fecha no visible» → «Last Updated: October 16, 2026».
14. §3.1, Capgo y el forzado: se agregó que el README cita la pauta como «or other similar actions» y la versión vigente (3.2.2 (x)) dice «or other store-related actions»; aplicar esa pauta al forzado de contenido es lectura del proveedor.
15. §3.4, issue #1865: se agregó que el mantenedor de Expo leyó el código y dijo que esa app «is designed to compile and execute code remotely»; el rechazo por «hidden features» no es el de una app de formularios típica.
16. §3.1 y §5, «al iniciar sesión»: «no tiene respaldo» → se encontró una única mención, OPINIÓN de parte interesada y sin fuente (eseidel: juegos que bajan scripts Lua «when you log in»). Sigue NO VERIFICADO como práctica.
17. [28] y [26]: los enlaces apuntan a comentarios, no a la historia → se agregó el id de la historia ([28]: 29040793; [26]: 40226863).
18. Fechas aproximadas → exactas en 13 filas de §4 (spiderice, tcoff91, sebmellen, apitman, myko, whstl, LoganDark ×2, pjmlp, kevingadd, nox101, j45, layer8) y en las fuentes [23], [27], [29] (con el título de su hilo).

**Confirmado sin cambios (muestra de lo más cargado):** retiro de CodePush el 2025-03-31; Expo «downloads in the background and applies on the next cold start», «If it touches native code, it needs a new build», «your compatibility firewall», autora y fecha (2026-02-24) de [2]; texto de runtime versions [1]; Capgo `atBackground`, `onlyDownload`, `onLaunch`, `notifyAppReady` con 10 s por defecto, «Do not tell the user the app is updating» y el rechazo por `autoSplashscreen`; In-App Updates (Android 5.0, teléfonos, tabletas y ChromeOS, «require the user to update and restart»); ODK (los tres modos, «the version must change…», «all the previous submissions remain unchanged», cambio de tipo sólo a texto, «complicate analysis»); Google Play «any method other than Google Play's update mechanism» y la excepción de JavaScript en WebView; Apple 2.5.2, 4.2 y 4.7; Lendable (autor, 2026-05-14, ambas citas); Saagar Jha (2020-11-08, cita); foros de Apple 107576 y 806726 (autores, mes y citas); discusión #16286 (jeffcad 2022-03-27, hirbod 2022-03-28); hilos de ODK y Kobo (autores, fechas, citas; ninguno tiene más de 3 mensajes).

**Generalizaciones sin conteo:** no se encontraron en el texto del investigador. Las afirmaciones cuantitativas son de terceros y están atribuidas («nearly 100%» de kevingadd, «95%» de kobieps, «1000s of releases» de eseidel, «It is rare» del README de Capgo): son percepciones, no mediciones. El conteo de §4 (43 opiniones, 38 autores, 17 páginas) se recontó y coincide.

**Quedan NO VERIFICADAS (9):** la cita original de Rollout (retirada); el título del hilo de [26]; la fecha exacta del archivado de CodePush; y las seis que ya declaraba el dossier: Reddit y Stack Overflow (no leídos), WebAssembly ante Apple, el revisor en modo avión, la app Cordova aprobada, la clave de idempotencia en la cola de salida y «actualizar al iniciar sesión» como práctica.

