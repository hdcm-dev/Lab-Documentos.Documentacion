# I1 — Apps de relevamiento y encuestas en campo, offline-first

| Campo | Valor |
| --- | --- |
| Ángulo | I1 — recolección de datos y encuestas en campo (ODK, KoboToolbox/Enketo, SurveyCTO, CommCare, ArcGIS Survey123 y Field Maps, Magpi) |
| Expediente | 0001-Framework-Concept-Maui-Autoactualizable (preguntas P1–P13, folios 003 a 006) |
| Fecha de consulta de todas las fuentes | 2026-10-25 |
| Método | WebSearch / WebFetch; páginas de Esri, Dimagi y Hacker News leídas también con `curl` (API REST de Confluence, JSON-LD de Esri Community, API de Algolia de HN); versiones vigentes por la API de releases de GitHub |
| Convención | **HECHO** = documentación oficial, anuncio del proveedor, código o release. **OPINIÓN** = foro, HN, issue, blog: autor, fecha, enlace y cita; señal cualitativa, no estadística. **NO VERIFICADO** = no se pudo leer la fuente primaria; va el motivo. **[criterio propio]** = inferencia del investigador, no de una fuente |

## Índice

1. [Alcance del ángulo](#1-alcance-del-ángulo)
2. [Qué se usa](#2-qué-se-usa)
3. [Cómo resuelven lo específico](#3-cómo-resuelven-lo-específico)
   - 3.1 [Momento de actualización](#31-momento-de-actualización)
   - 3.2 [Versionado de lo descargado y compatibilidad con la app instalada](#32-versionado-de-lo-descargado-y-compatibilidad-con-la-app-instalada)
   - 3.3 [Datos tomados con una versión vieja de la definición](#33-datos-tomados-con-una-versión-vieja-de-la-definición)
   - 3.4 [Actualización forzada](#34-actualización-forzada)
   - 3.5 [Permisos, capacidades y cuándo sí hay que pasar por la tienda](#35-permisos-capacidades-y-cuándo-sí-hay-que-pasar-por-la-tienda)
   - 3.6 [Tiendas: reglas y problemas](#36-tiendas-reglas-y-problemas)
4. [Opiniones de desarrolladores](#4-opiniones-de-desarrolladores)
5. [Lecciones aplicables a P1–P13](#5-lecciones-aplicables-a-p1p13)
6. [Fuentes](#6-fuentes)

---

## 1. Alcance del ángulo

Es el ángulo más cercano al escenario de la encuesta del PO (folio 005). Estas plataformas tienen exactamente la forma
que el PO describe: una **app instalada desde la tienda** (ODK Collect, KoboCollect, SurveyCTO Collect, CommCare,
Survey123 field app) que es un **motor genérico**, y **formularios que llegan desde el servidor como datos**
(XForms generado desde XLSForm, o la «aplicación» de CommCare), sin pasar por la tienda. El encuestador baja el
formulario con red, trabaja sin red y envía cuando la recupera.

Qué se investigó: (a) cómo se publica y versiona el formulario sin tocar la app; (b) cuándo y cómo baja al
dispositivo (al abrir, periódico, al iniciar sesión, forzado); (c) qué pasa con borradores y envíos hechos con una
versión vieja (P13); (d) cuándo sí hay que actualizar la app por la tienda; (e) qué opinan quienes las usan.

Qué **no** cubre: el canal de código (WASM, OTA de JavaScript), que es de otros ángulos (I2, I3). Estas plataformas
no descargan código de pantallas: descargan **definiciones** que un motor ya instalado interpreta. Esa diferencia
es la lección central para P1 (§5).

---

## 2. Qué se usa

Tabla de productos (todo HECHO salvo marca expresa).

| Nombre | Qué actualiza sin tienda | Cómo trabaja sin red | Cómo fuerza o programa la actualización | Versión / estado vigente | Fuente |
| --- | --- | --- | --- | --- | --- |
| **ODK Collect + ODK Central** | Definición del formulario (XForm desde XLSForm) y sus adjuntos (CSV, medios); cada publicación exige cambiar `version` | Formularios bajados quedan en el dispositivo; los finalizados se encolan y salen con auto-send «if the device can connect»; desde 2024.3, *Entities* creadas/actualizadas sin red | Modo de actualización de formularios: *Manual* (por defecto), *Previously downloaded forms only* (con descarga automática opcional) o *Exactly match server*; frecuencia configurable; el QR de App User de Central configura «exactly match» por defecto desde Central v1.1. No hay bloqueo de versión vieja | Collect v2026.3.5 y Central v2026.3.1 (ambos 2026-09-28; última estable; hay pre-release de Collect v2026.4.0-beta.1 del 2026-10-16) | [1] [2] [4] [13] [14] [17] |
| **KoboToolbox (KoboCollect + Enketo/web forms)** | Definición redeployada («REDEPLOY») | KoboCollect: «Once you have downloaded the form(s) in the app, you do not need an internet connection»; web forms: app cacheada con Service Workers, formulario y datos en IndexedDB | KoboCollect: manual o «automatically at a set frequency»; web: banner «Refresh this page to load the updated version» | KoboCollect v2025.2.3 (2025-09-08) como última release **estable** en GitHub; hay pre-releases posteriores (v2025.3.3, 2025-12-25; v2026.2.2, 2026-10-23); lo publicado en Play no se verificó; kpi 2.026.37c (2026-10-20); Enketo 7.6.4 (2026-08-13) | [17] [18] [19] [24] |
| **SurveyCTO** | Definición del formulario; versión = entero con igual cantidad de dígitos | App SurveyCTO Collect con formularios bajados; conserva versiones viejas para envíos empezados. La propia documentación dice «SurveyCTO was originally based on the Open Data Kit (ODK) open source platform» ([25]) | Descarga automática opcional (chequeo «hourly» con la opción activada), pero «won't be installed until the user confirms»; web: «whenever a web user begins a new submission, they will always use the latest version» | NO VERIFICADO (no se consultó página de release) | [25] [26] |
| **CommCare (Dimagi)** | La «aplicación» (formularios, flujos de casos, multimedia) como *build* publicado en CommCare HQ; separada del programa CommCare | App completa en el teléfono; sincroniza con HQ | *Auto Update Frequency* diaria/semanal: chequea **tras el login**, baja en segundo plano y **aplica en el próximo login**; *Prompt updates to app* y *to CommCare*: Off / On / **Forced** | commcare-android 2.65.0 (2026-10-20) | [17] [28] [29] [30] |
| **ArcGIS Survey123 (field app)** | Encuesta (XLSForm de Survey123 Connect o del diseñador web) | Encuestas bajadas no requieren login al abrir; *Outbox* sin vencimiento | Notificación de actualizaciones en la galería (field app 3.9.148, 2020-04-02); el chequeo se dispara al reabrir la app, al cerrar y volver a iniciar sesión o al tirar hacia abajo la galería | Archivo de novedades con release de julio 2026 | [33] [34] [35] |
| **ArcGIS Field Maps** | Formulario del mapa web | *Offline map areas* | Agregar un campo exige **borrar o recrear** el área offline y volver a bajarla | Artículo de soporte publicado 2022-05-02, última publicación 2022-12-27 (sigue en línea) | [40] |
| **Magpi** | Formularios | Captura sin red, envío con red | Según resumen de buscador: suscriptores pagos reciben cambios «automatically synchronized»; los gratuitos hacen «pull to refresh»; al iniciar sesión baja todos los formularios del usuario | **NO VERIFICADO**: support.magpi.com no resolvió DNS al consultar | [41] |

---

## 3. Cómo resuelven lo específico

### 3.1 Momento de actualización

| Momento | Quién lo usa | Detalle | Fuente |
| --- | --- | --- | --- |
| Manual, a pedido del usuario | ODK (por defecto), KoboCollect, SurveyCTO, CommCare, Survey123 | «Get Blank Form» / «Update App» / tirar la galería (Survey123: [33] [34]; [35] sólo describe la barra de actualizaciones de la galería) | [1] [26] [29] [33] [34] |
| Periódico, en segundo plano | ODK (*Automatic update frequency*), KoboCollect, CommCare (diario/semanal) | ODK: «Specifies how frequently Collect should check for updates»; sólo con los modos automáticos. KoboCollect: «automatically at a set frequency» | [1] [18] [29] |
| **Al iniciar sesión** | CommCare; Survey123 | CommCare: «The app checks for updates in the background immediately after the user logs in … The updates are applied the next time the user logs in. … If the app can't contact the server, it will try again on a future login.» Survey123: la solución de Esri para el bug 000144445 dice que el chequeo se fuerza al «Sign out and sign back into» o al cerrar y reabrir la app | [29] [34] |
| Al abrir la app / el formulario | Survey123 (al reabrir la app; el aviso al abrir la encuesta directamente falla sin ese chequeo previo: bug 000144445, estado «Duplicate») ; Kobo web forms (banner al cargar) | Ver bug: «Before trying any of these options, the prompt will not appear» | [18] [34] |
| Espejo exacto del servidor | ODK *Exactly match server* (Collect v1.28, 2020); por defecto con el QR de App User desde Central v1.1 (2020-12-23) | «Collect will automatically download and update forms based on what's on the server»; los formularios que ya no están en el servidor se borran del dispositivo | [1] [12] [13] |
| Forzado | CommCare *Forced* | §3.4 | [28] |

Dato que confirma la señal del PO del folio 004 («se actualizan internamente al iniciar un logueo nuevo»): **CommCare
y Survey123 atan el chequeo al inicio de sesión** (HECHO, [29] [34]). CommCare además **separa bajar de aplicar**:
baja después del login y aplica en el siguiente, de modo que la sesión en curso no cambia de definición a mitad de
trabajo ([29]).

### 3.2 Versionado de lo descargado y compatibilidad con la app instalada

**Tres líneas de versión, separadas** (HECHO):

1. **Versión de la definición.** En XForms es el atributo `orx:version` de la raíz de la instancia: «Form version which
   can contain any string value. Like meta nodes this information is used as a processing cue for the server receiving
   the submission» ([5]). XLSForm lo pone en la hoja `settings`, con la convención «yyyymmddrr» ([6]). ODK Central
   no publica si no cambió: «the `version` must change in order for data collection clients to understand that they
   should update» ([2]). SurveyCTO: «a single whole number, and its number of digits has to stay the same» ([26]).
2. **Versión del motor** (la app de la tienda). CommCare lo dice explícito: «Updating the software means updating the
   entire CommCare program, while updating the application means updating the content specific to your project»
   ([30]).
3. **Versión de la plataforma de servidor** (Central, HQ), que puede exigir un motor mínimo ([14]).

**Compatibilidad definición ↔ motor** (HECHO):

- CommCare: «If an application on HQ is moved to a higher Minor or Major version number (1.2 -> 1.3, for instance), an
  application's resource files won't be able to be downloaded by an older version of CommCare» ([30]). El ajuste
  *CommCare Version* de HQ «can be set to the latest version that is installed on devices», para que HQ no permita
  armar apps incompatibles ([31]). Y una advertencia: «Unfortunately we have no mechanism to prevent devices from
  performing upgrades from incompatible versions» ([31]).
- ODK: con Central v2024.3, «Once you upgrade, use of Entities will require ODK Collect v2024.3 or later» ([14]): una
  capacidad nueva del modelo de definición obliga a actualizar el motor por la tienda.
- Survey123: el pedido de «minimum field app version» (2017) quedó «Implemented» por un mecanismo indirecto:
  `pulldata('@property','appversion')` para leer la versión de la app y usarla en un `constraint` ([36]). Es decir,
  **la propia definición se protege** contra motores viejos.

**Publicación, prueba y reversión en el servidor** (HECHO):

- ODK Central: borradores (*Drafts*) que se prueban sin tocar el formulario vivo; al publicar, el borrador «becomes the
  version in use»; los envíos de prueba «will never export with your final data» ([2]). Un tipo de dato publicado no se
  puede cambiar: «Once a field is defined in a published Form version, the field's Data Type cannot be changed» ([2]).
- CommCare: cada *build* es una versión; se marca *Released*; el dispositivo baja por defecto «the latest starred
  version», o «Latest version» (desde 2.30) o «Latest saved state» (desde 2.34) ([32]). [criterio propio] Elegir qué
  build está «released» funciona como canal y como rollback del lado servidor.
- ODK Aggregate (histórico): «does not accept changes to a form definition unless the version string is different»
  (mensaje de yanokwa, 2017-07-07, citando las guías) ([16]).

### 3.3 Datos tomados con una versión vieja de la definición

Es la P13. Las plataformas resuelven **tres casos distintos** que conviene no mezclar.

**(a) Envío finalizado con versión vieja → servidor.** ODK Central acepta envíos de **cualquier versión publicada**
mientras el formulario no se borre. OPINIÓN autorizada en el foro (LN, 2021-04-20): «Central will accept submissions
for any combination of `form_id` and `version` that it has published» y, si se borra el formulario, «Central will not
accept submissions created for version 1» ([7]). La documentación oficial dice lo que pasa en el servidor: «all the
previous submissions remain unchanged, and will export along with all your data», pero «by default, only the current
Form definition will be used in exports» ([2]). **NO VERIFICADO en documentación oficial** la regla de aceptación por
versión: sólo consta en el foro ([7]); hay una cita de un PR enlazado en el mismo hilo: «Central only accepts
submissions for form versions that it is aware of». Lo llenado con el formulario de prueba del borrador falla al enviar una vez publicado el borrador («Could not find the resource»): hilo
de 2022 ([10]); no quedó atrapado: LN indica reconfigurar Collect con el QR de un App User del formulario publicado,
lo que «should allow you to send those submissions» si el borrador era la versión que se publicó (OPINIÓN, LN, 2022-02-22).

Survey123 trabaja contra una capa de entidades (feature service): el envío viejo entra **si el esquema de la capa no
perdió campos**. OPINIÓN de ZacharySutherby (foro Esri, 2022-05-17): «if the schema has changed and fields that existed
before no longer exist then an error will be returned and require manual extraction of the data» ([38]).

**(b) Borrador (en curso) cuando llega la nueva definición.**

| Plataforma | Qué pasa | Tipo | Fuente |
| --- | --- | --- | --- |
| SurveyCTO | Mantiene las versiones viejas en el dispositivo: «older versions of your form are kept to support users who had already begun submissions with those earlier versions»; ofrece **«Reload with updated form»** (opción de administración) para migrar la instancia a la definición nueva | HECHO | [26] |
| ODK Collect | El borrador queda **atado a la versión con la que se empezó**; migrarlo «it's not functionality that's currently available» (LN, 2025-03-24, hilo convertido en *Idea*). Las ediciones de envíos «use the version of the form that was active when the form was originally filled, NOT the latest one» | OPINIÓN (LN) + HECHO (docs) | [3] [8] |
| KoboCollect | Igual que ODK: un usuario pregunta cómo pasar un borrador a la versión corregida (deen, 2024-05-07) y el hilo sigue sin solución en 2025 | OPINIÓN | [20] |
| Kobo web forms (Enketo) | Al detectar versión nueva con datos ya cargados, el usuario elige «either discard the data already entered or load it into the new version of the form» | HECHO | [18] |
| Survey123 | Con el esquema intacto, los registros del *Outbox* siguen y se abren con el formulario nuevo: «When you update the survey in the field app, the new form will be honored (readonly->editable) and the records will stay» (Shwu-jingJeng, 2020-07-29) | OPINIÓN | [37] |

**(c) Unificar datos de varias versiones.** Kobo: «Changing choice names or labels» puede «make data inconsistent across
form versions» ([18]); los registros viejos «will still hold the structure of the `version 1`» y la salida que se
ofrece es editarlos en el servidor (Kal_Lam, 2021-07-22; 2024-02-23) ([21] [22]). SurveyCTO: «be careful about
removing fields, renaming fields, or changing groups» ([26]). ODK: renombrar un campo equivale a borrarlo y crear otro
(resumen del foro; [7]).

**Regla operativa que repiten las plataformas** [criterio propio, a partir de [2] [26] [38]]: los cambios **aditivos**
(agregar preguntas, aflojar restricciones, corregir textos) conviven; los **destructivos** (borrar o renombrar campos,
cambiar tipos) rompen la unión de datos o el envío.

### 3.4 Actualización forzada

| Plataforma | ¿Puede forzar? | Cómo | Sin red | Fuente |
| --- | --- | --- | --- | --- |
| CommCare | **Sí** | *Forced*: «Mobile workers will not be able to continue using CommCare unless they are operating on the latest version»; aplica tanto a la app (definiciones) como al programa CommCare | El aviso llega «Under ideal conditions (proper internet connectivity and optimal battery percentage) … once the current session has expired and the user tries to login again» | [28] |
| ODK | No bloquea | Sólo descarga automática o *Exactly match server*; en 2020 un usuario pidió un error para versiones viejas y el hilo no lo resolvió | — | [1] [11] |
| KoboToolbox | No bloquea | La doc pide «make sure all data collectors update»; si no, «some users may continue submitting data with an outdated version» | Bajar la actualización «requires an internet connection» | [18] [19] |
| SurveyCTO | No bloquea en móvil | Baja sola pero se instala cuando el usuario confirma; en web, siempre la última | — | [26] |
| Survey123 | Indirecto | `constraint` con `pulldata('@property','appversion')` impide enviar con una app vieja | — | [36] |

Lo que confirma el folio 006: **no se puede forzar lo que no se puede bajar**. CommCare, la única de las revisadas que fuerza, lo
condiciona a conectividad y a un nuevo login ([28]).

### 3.5 Permisos, capacidades y cuándo sí hay que pasar por la tienda

Ninguna de las fuentes leídas trata el manifiesto de permisos de forma explícita. Lo que sí documentan (HECHO):

- **Una capacidad nueva del modelo** (tipo de pregunta, función, *Entities*) exige un motor nuevo: Central 2024.3 →
  Collect 2024.3 ([14]); Collect 1.4.9 trajo «XPath 3.1 math functions (exp, log, sin, cos, etc.)»; para usarlas «you will need the 1.4.9
  versions of ODK Briefcase, ODK FormUploader and ODK Validate» (anuncio de Mitch_S, abril de 2016, migrado al foro
  actual con fecha 2020-03-14; [50]); Survey123: según el pedido de 2017, apps
  incompatibles terminaban en «lost or uncollected data, or survey submission failure» ([36]).
- **Una actualización de la app de tienda puede perder datos locales**: un usuario de Survey123 en iPad encontró que
  tras la actualización «all of my drafts were missing» y los recuperó con *Settings → Advanced → Fix database*
  (JessicaCelis, 2017-05-17, OPINIÓN) ([39]); y borrar la app borra la base: «If the Survey123 app is deleted the
  database will also be deleted and the data will be lost» ([38]).
- CommCare: si un dispositivo salta desde una versión del programa cuya compatibilidad de actualización ya se retiró,
  «data will not be able to be recovered» y no hay «mechanism to prevent» ese salto; recomienda actualizar en cuanto
  se anuncia el retiro y, para instalaciones ya incompatibles, «Submit and Reinstall» o un «Intermediate Upgrade»
  (APK intermedio instalado aparte) ([31]).

[criterio propio] Para P12: en estas plataformas el **motor** trae de fábrica todas las capacidades de dispositivo
que una definición puede pedir (cámara, GPS, código de barras, audio); la definición sólo las **usa**. Cuando una
definición pide algo que el motor no conoce, el comportamiento documentado es exigir una versión mínima del motor
([14] [30] [31] [36]). Eso es el patrón de «capacidades declaradas por el cascarón y descubiertas por el contenido».

### 3.6 Tiendas: reglas y problemas

No se encontró ningún rechazo de tienda a estas apps por descargar formularios. [criterio propio] Encaja con las
reglas: la definición es dato interpretado por el motor ya revisado.

- Google Play: una app «may not modify, replace, or update itself using any method other than Google Play's update
  mechanism», y «This restriction does not apply to code that runs in a virtual machine or an interpreter» con el
  ejemplo «(such as JavaScript in a webview or browser)» ([42]).
- Apple 2.5.2: las apps no pueden «download, install, or execute code which introduces or changes features or
  functionality of the app»; 4.7 admite «HTML5 and JavaScript mini apps», con 4.7.2 («may not extend or expose native
  platform APIs or technologies to the software without prior permission from Apple») y 4.7.3 sobre permisos ([43]).
  La lectura de estas reglas para WASM descargado es de otros ángulos.

---

## 4. Opiniones de desarrolladores

Conteo: 24 opiniones, contadas a mano en los hilos citados (foros de ODK, KoboToolbox y Esri, y comentarios de Hacker
News por la API de Algolia con las consultas «ODK Collect», «KoboToolbox», «CommCare Dimagi», «Survey123»,
«XLSForm»). No es una muestra: se eligieron por pertinencia al tema. Reddit: dos búsquedas (`reddit KoboToolbox vs ODK
vs SurveyCTO`, `reddit r/gis Survey123 offline`) **no devolvieron ningún hilo de Reddit**. No se verificó el cargo de
ningún autor; sólo yanokwa se presenta en su propio comentario como «founder and CEO at ODK».

### 4.1 A favor del modelo (motor de tienda + definiciones desde el servidor)

| Fuente | Autor | Fecha | Postura | Cita | Tema |
| --- | --- | --- | --- | --- | --- |
| [44] HN | yanokwa (se presenta como CEO de ODK) | 2022-05-26 | a favor | «ODK is basically the Land Cruiser of mobile data collection apps. It's designed to be very reliable in challenging settings» | confiabilidad sin red |
| [45] HN | not_the_nsa | 2018-05-27 | a favor | «ODK works really well for us»; ~12k registros «in ca 2k hours of logged survey work» | uso real en campo |
| [47] HN | amind | 2018-05-27 | a favor | «the logged data gets pushed up to a server as soon as possible. The latter point was really useful for us» | sincronización temprana |
| [15] Foro ODK | mathieubossaert | 2026-03-02 | a favor | «you can update the form version without any fear. Even if people do have unset submissions from older version» | versiones viejas aceptadas |
| [12] Foro ODK | issa | 2019-11-06 | a favor de forzar | «insecurity around what exactly is happening on devices in the field» | control central de versiones |
| [12] Foro ODK | adam.butler | 2019-11-13 | a favor de forzar | sobre un proyecto de polio que aclara que no es de ODK: «the single biggest problem is with people accidentally using out of date hardware» (o hardware con software desactualizado) | dispositivos desactualizados en campo |

### 4.2 En contra o problemas reportados

| Fuente | Autor | Fecha | Postura | Cita | Tema |
| --- | --- | --- | --- | --- | --- |
| [46] HN | jasonkostempski | 2018-05-27 | en contra | «It's relatively easy to make a native app with forms that save to a data file for syncing when online»; teme «losing an full days work due to a little accident or data killing software update»; XForms «a dead standard» | app propia vs ODK; actualizaciones que matan datos |
| [11] Foro ODK | Marco | 2020-05-18 | problema | «a lot of our users will not do it» (activar la descarga automática) | no se puede forzar |
| [8] Foro ODK | Cheikh_ibrahima_Fall | 2025-03-24 | problema | en los primeros días de campo los formularios se actualizan seguido; pide completar borradores con la versión nueva | borradores atados a versión vieja |
| [20] Foro Kobo | deen | 2024-05-07 | problema | pregunta «if there is a way I could update that one to the current version» | borrador con error ya corregido |
| [20] Foro Kobo | thadeouspascal | 2025-08-20 | problema | «I hope the kobo team can come up with a solution for this issue?» | ídem, sin solución |
| [9] Foro ODK | Saad | 2019-11-27 | problema | la actualización «should be managing auto-delete of old form and installation of new form» | actualizar no es transparente |
| [23] Foro Kobo | javila92 | 2022-12-06 | problema | «the browser tabs automatically refresh and then is not available anymore for offline submission» | web offline frágil |
| [39] Foro Esri | JessicaCelis | 2017-05-17 | problema | tras actualizar la app «all of my drafts were missing … You can imagine my horror» | actualización de tienda vs datos locales |
| [36] Idea Esri | BradenBurkholder | 2017-07-25 | problema | versiones de app incompatibles terminan en «lost or uncollected data, or survey submission failure» | versión mínima del motor |
| [48] HN | nrjames | 2015-12-04 | problema | el Ministerio de Salud exigió datos «encrypted on the device and during sync (not just over https)» | cifrado local |
| [49] HN | shaka-bear-tree | 2026-08-09 | crítica | XLSForm existe, «but nothing I could find that is easy for humans and machines to grok» | formato de la definición |

### 4.3 Matices

| Fuente | Autor | Fecha | Postura | Cita | Tema |
| --- | --- | --- | --- | --- | --- |
| [9] Foro ODK | LN | 2019-12-02 | matiz | «it looks like you have used the same version label but changed the form»; propone fecha + dos dígitos | disciplina de versión |
| [8] Foro ODK | LN | 2025-03-24 | matiz | migrar borradores «it's not functionality that's currently available»; caso: una pregunta que se vuelve obligatoria sin salida | límites del motor |
| [12] Foro ODK | seadowg | 2020-05-05 | matiz | «Our plan is for this to be opt in so we don't mess with any existing workflows» | forzar sólo si se elige |
| [12] Foro ODK | amalm | 2020-05-05 | matiz | «This setting should be hide-able from the admin settings panel»; si no, se cambia «when someone plays with it» | proteger la configuración |
| [38] Foro Esri | ZacharySutherby | 2022-05-17 | matiz | el Outbox «has no expiration time», pero si cambia el esquema hay «manual extraction of the data» | P13 del lado servidor |
| [37] Foro Esri | Shwu-jingJeng | 2020-07-29 | matiz | «you should not need to worry about the data lost when you update the form without changing your schema» | P13, cambio sin esquema |
| [37] Foro Esri | PaulG | 2021-05-18 | problema/matiz | «How do I update the schema of items already in the outbox?» | Outbox con definición vieja |

---

## 5. Lecciones aplicables a P1–P13

| Pregunta | Lección | Fuente |
| --- | --- | --- |
| **P1** modelo de contenido | Las plataformas revisadas en este ángulo (ODK, Kobo, SurveyCTO, CommCare, Survey123, Field Maps; Magpi sin verificar) usan **B (definición como datos)** sobre un motor que viaja en la tienda. El costo documentado: cada capacidad nueva del lenguaje de definición exige motor nuevo por tienda. [criterio propio] Para la encuesta del PO, B cubre el «si la encuesta cambia o se arregla»; A (WASM) agrega poder cambiar el motor sin tienda. Esto apoya **C**: el motor de encuestas en el contenido Blazor actualizable y las encuestas como datos versionados | [2] [14] [30] |
| **P2** canal | Patrones probados: borrador → publicar con versión obligatoria (Central); *builds* numerados con uno marcado *released* y destino elegible (CommCare: starred / latest / saved state); espejo exacto del servidor que borra lo retirado (ODK). Retención: Central sigue aceptando envíos de toda versión publicada mientras el formulario exista | [2] [7] [12] [32] |
| **P3** contrato cascarón–contenido | Declarar la **versión mínima del motor** que necesita cada definición y validarla antes de aplicar (CommCare *CommCare Version*, Survey123 `appversion`, Central → Collect 2024.3) | [14] [31] [36] |
| **P4** entrada | Atar el chequeo de actualizaciones al **login** (CommCare, Survey123) y **aplicar en el login siguiente** para no cambiar la definición en mitad de la sesión (CommCare). ODK usa un QR de App User como autenticación sin contraseña y configuración del dispositivo a la vez | [4] [29] [34] |
| **P5** sin red | Cola de salida que envía al volver la red (auto-send ODK, Outbox Survey123 sin vencimiento); borrar la app borra la base local. Para datos editados por varios sin red (ODK *Entities*), versión base incremental, conflictos marcados en el servidor y resueltos por el administrador, no por el encuestador (resumen de foro, **NO VERIFICADO** fuera del buscador) | [1] [14] [38] |
| **P6, P8, P9, P11** | Este ángulo no aporta fuentes sobre PR, pruebas, firma iOS o alcance de la demo. [criterio propio] El borrador de Central con envíos de prueba descartables es un modelo de «staging» de definiciones que la demo puede imitar | [2] |
| **P7** líneas de versión | Al menos tres líneas independientes: **definición** (p. ej. `yyyymmddrr`), **motor/cascarón**, **servidor**; más la regla «cada cambio publicado cambia la versión» | [2] [5] [6] [30] |
| **P10** guía | El escenario del PO coincide con un caso real y documentado: sirve como escenario guía (encuestador, coordinador que publica, servidor). [criterio propio] | — |
| **P12** capacidades del manifiesto | [criterio propio] El motor declara de antemano las capacidades de dispositivo; la definición las usa; si pide una que el motor no tiene, se exige motor mínimo y se deriva a la tienda. Apple 4.7.2/4.7.3 limita exponer APIs nativas y permisos a software descargado | [14] [36] [43] |
| **P13** encuestas con versión vieja | (1) Cada respuesta lleva la versión de la definición con la que se tomó ([5]); (2) el servidor acepta toda versión publicada y no borrada ([7]); (3) borradores: o se terminan con su versión (ODK, Kobo), o se migran a pedido si el cambio es compatible (SurveyCTO «Reload with updated form», Enketo «load it into the new version», Survey123 con esquema intacto); (4) cambios aditivos sí, destructivos no (o con migración en el servidor) | [2] [5] [7] [8] [18] [26] [37] [38] |
| **Forzado (folio 006)** | Sólo CommCare bloquea («Forced»), y lo hace al reloguear y con red. ODK, Kobo y SurveyCTO no bloquean; en el foro de ODK un usuario lo pidió (Marco, 2020-05-18, [11]); para Kobo y SurveyCTO no se buscaron pedidos. [criterio propio] Forzar el **contenido** al iniciar es posible sólo con red; sin red, dejar trabajar con la versión instalada y marcar las respuestas con su versión (P13) | [11] [18] [26] [28] |

---

## 6. Fuentes

Todas consultadas el 2026-10-25.

1. ODK Docs, «Collect settings» (Form management: *Blank form update mode*, *Automatic download*, *Hide old form versions*, *Auto send*). https://docs.getodk.org/collect-settings/ — sin fecha visible. HECHO.
2. ODK Docs, «Managing Forms in Central» (Updating Forms to a New Version, Drafts, Attachments). https://docs.getodk.org/central-forms/ — sin fecha visible. HECHO.
3. ODK Docs, «Managing forms in Collect». https://docs.getodk.org/collect-forms/ — sin fecha visible. HECHO.
4. ODK Docs, «Importing and exporting settings» (QR, `form_update_mode`, App Users). https://docs.getodk.org/collect-import-export/ — © 2026 Get ODK Inc. HECHO.
5. ODK XForms Specification (atributo `orx:version`). https://getodk.github.io/xforms-spec/ HECHO.
6. XLSForm, hoja `settings`, columna `version`. https://xlsform.org/en/ HECHO.
7. Foro ODK, «Can you still send data from old versions of forms to ODK Central?», BeccaHandley, aurdipas, LN, mathieubossaert, 2021-04-20/29. https://forum.getodk.org/t/can-you-still-send-data-from-old-versions-of-forms-to-odk-central/33257 OPINIÓN.
8. Foro ODK, «Open a draft with an updated version of the form», Cheikh_ibrahima_Fall y LN, 2025-03-24. https://forum.getodk.org/t/open-a-draft-with-an-updated-version-of-the-form/54287 OPINIÓN.
9. Foro ODK, «Updating an existing form in Collect is not seamless», Saad, Grzesiek2010, LN, 2019-11-27 a 2019-12-02. https://forum.getodk.org/t/updating-an-existing-form-in-collect-is-not-seamless/23552 OPINIÓN.
10. Foro ODK, «After publishing draft, unable to send finalized forms collected with draft version», sannirukayat, mathieubossaert, LN, 2022-02. https://forum.getodk.org/t/after-publishing-draft-unable-to-send-finalized-forms-collected-with-draft-version/36697 OPINIÓN.
11. Foro ODK, «How to force form update», Marco y seadowg, 2020-05-18. https://forum.getodk.org/t/how-to-force-form-update/26553 OPINIÓN.
12. Foro ODK, «Have Collect exactly match the forms on Central», LN, issa, seadowg, adam.butler, amalm, tomsmyth, 2019-11-04 a 2020-09-24. https://forum.getodk.org/t/have-collect-exactly-match-the-forms-on-central/23101 OPINIÓN (con anuncio de release de Collect v1.28).
13. Foro ODK, anuncio «ODK Central v1.1», Matthew_White, 2020-12-23. https://forum.getodk.org/t/odk-central-v1-1/31766 HECHO (anuncio del proveedor).
14. Foro ODK, anuncio «ODK Central v2024.3 - Offline Entities, submission deletes, and faster form uploads», Sadiq_Khoja, 2024-12-17. https://forum.getodk.org/t/odk-central-v2024-3-offline-entities-submission-deletes-and-faster-form-uploads/51515 HECHO (anuncio). Lo de conflictos y «base version» sale sólo del resumen del buscador sobre https://forum.getodk.org/t/form-spec-proposal-support-entity-updates-from-multiple-offline-clients/47890 y https://forum.getodk.org/t/collect-and-central-out-of-sync-because-of-multiple-entity-processing/58074: NO VERIFICADO (no se leyeron).
15. Foro ODK, «How do I update forms in ODK Central?», Matthew_White, Xiphware (2018-11), mathieubossaert y Maria2050 (2026-03-02). https://forum.getodk.org/t/how-do-i-update-forms-in-odk-central/16026 OPINIÓN.
16. Foro ODK, «How is version used across the ecosystem?», yanokwa, 2017-07-07. https://forum.getodk.org/t/how-is-version-used-across-the-ecosystem/8964 OPINIÓN (cita guías de Aggregate).
17. GitHub, releases más recientes por API: getodk/collect v2026.3.5 (2026-09-28), getodk/central v2026.3.1 (2026-09-28), kobotoolbox/collect v2025.2.3 (2025-09-08), kobotoolbox/kpi 2.026.37c (2026-10-20), enketo/enketo 7.6.4 (2026-08-13), dimagi/commcare-android commcare_2.65.0 (2026-10-20). https://github.com/getodk/collect/releases/tag/v2026.3.5 · https://github.com/getodk/central/releases/tag/v2026.3.1 · https://github.com/kobotoolbox/collect/releases/tag/v2025.2.3 · https://github.com/kobotoolbox/kpi/releases/tag/2.026.37c · https://github.com/enketo/enketo/releases/tag/7.6.4 · https://github.com/dimagi/commcare-android/releases/tag/commcare_2.65.0 HECHO.
18. KoboToolbox Support, «Deploying forms for data collection», última actualización 2026-09-08. https://support.kobotoolbox.org/deploy_form_new_project.html HECHO.
19. KoboToolbox Support, «Collecting data using KoboCollect», última actualización 2026-07-17. https://support.kobotoolbox.org/data_collection_kobocollect.html HECHO.
20. Foro KoboToolbox, «How to update a partially saved form in the Draft to incorporate the new changes in the new version deployed», deen (2024-05-07), Kal_Lam, data1_btd_co, Luc133, thadeouspascal (2025-08-20). https://community.kobotoolbox.org/t/how-to-update-a-partially-saved-form-in-the-draft-to-incorporate-the-new-changes-in-the-new-version-deployed/53198 OPINIÓN.
21. Foro KoboToolbox, «Submission form old and new», sengkrisna, Kal_Lam, wroos (2021-07), elvis_pooplogg (2024-02-28). https://community.kobotoolbox.org/t/submission-form-old-and-new/20837 OPINIÓN.
22. Foro KoboToolbox, «Updates to forms saved in Kobocollect», respuesta de Kal_Lam, 2024-02-23. https://community.kobotoolbox.org/t/updates-to-forms-saved-in-kobocollect/50612/2 OPINIÓN.
23. Foro KoboToolbox, «Enketo web form automatically refreshes and the forms are lost in the field», javila92 y Kal_Lam, 2022-12-06. https://community.kobotoolbox.org/t/enketo-web-form-automatically-refreshes-and-the-forms-are-lost-in-the-field/36160 OPINIÓN.
24. Enketo, «Frequently Asked Questions» (Service Workers, IndexedDB, iOS). https://enketo.org/faq/ HECHO. El cambio de caché en Enketo Express 2.0.0 (marzo 2020) se verificó en el blog: Martijn van de Rijdt, «Important Enketo Express Updates - 03/2020», 30 Mar 2020, https://blog.enketo.org/Enketo-Express-mar-2020-update/ — Chrome dejaba de soportar «a caching technology Enketo has been using since 2012» (enlaza a la retirada de AppCache) y Enketo Express «has switched to this technology in version 2.0.0 in March 2020»; el post no nombra Service Workers: eso lo dice la FAQ.
25. SurveyCTO Docs, «SurveyCTO high-level overview» («SurveyCTO was originally based on the Open Data Kit (ODK) open source platform»). https://docs.surveycto.com/01-getting-started/01-overview/01.high-level-overview.html — © 2026 Dobility, Inc. HECHO (agregada en la verificación).
26. SurveyCTO Docs, «Updating forms». https://docs.surveycto.com/02-designing-forms/01-core-concepts/10.updating.html — sin fecha visible. HECHO.
27. SurveyCTO Support, «Update a form instance with the new form definition». https://support.surveycto.com/hc/en-us/articles/19365067051667 — NO VERIFICADO: devolvió 403 (Cloudflare); lo que se sabe de «Reload with updated form» se apoya en [26].
28. Dimagi Confluence, «Manage Application Versions», actualizada 2024-09-13 (leída por API REST). https://dimagi.atlassian.net/wiki/spaces/commcarepublic/pages/2143957917/Manage+Application+Versions HECHO.
29. Dimagi Confluence, «Ways to Update an Application», actualizada 2025-06-04. https://dimagi.atlassian.net/wiki/spaces/commcarepublic/pages/2411495485/Ways+to+Update+an+Application HECHO.
30. Dimagi Confluence, «Update Your Application», actualizada 2024-06-20. https://dimagi.atlassian.net/wiki/spaces/commcarepublic/pages/2143957871 HECHO.
31. Dimagi Confluence, «CommCare Mobile Support Compatibility Map», actualizada 2025-12-05. https://dimagi.atlassian.net/wiki/spaces/commcarepublic/pages/2143955661/CommCare+Mobile+Support+Compatibility+Map HECHO.
32. Dimagi Confluence, «Control Application Version During Updates», actualizada 2024-04-27 (archivada). https://dimagi.atlassian.net/wiki/spaces/commcarepublic/pages/2143954269 HECHO.
33. Esri, «What's new in Survey123» (archivo PDF), entrada «Update April 2, 2020», Survey123 field app 3.9.148. https://doc.arcgis.com/en/survey123/get-started/pdf/whatsnewarchive.pdf HECHO. El post del blog de marzo 2020 que, según el buscador, enumera «al iniciar la app, al iniciar sesión un usuario nuevo y al abrir una encuesta» devolvió 403: NO VERIFICADO (https://www.esri.com/arcgis-blog/products/product/announcements/whats-new-in-survey123-for-arcgis-march-2020).
34. Esri Support, BUG-000144445, «After updating a survey, the ArcGIS Survey123 field app does not automatically prompt…», versión 3.13, Android 7.x, estado *Duplicate*. https://support.esri.com/en-us/bug/after-updating-a-survey-the-arcgis-survey123-field-app-bug-000144445 HECHO.
35. Esri, «Quick reference» del field app de Survey123. https://doc.arcgis.com/en/survey123/capture/field-app/quickreferencegetanswers.htm HECHO.
36. Esri Community, idea «Minimum field app version requirement», BradenBurkholder, 2017-07-25, estado *Implemented*, comentario de JamesTedrick. https://community.esri.com/t5/arcgis-survey123-ideas/minimum-field-app-version-requirement/idi-p/922208 OPINIÓN (estado de la idea: HECHO del sitio).
37. Esri Community, «Survey123 Form Change With Items in your Survey123 Outbox», CN (2020-06-29), Shwu-jingJeng (2020-07-29), PaulG (2021-05-18). https://community.esri.com/en/discussion/739280/survey123-form-change-with-items-in-your-survey123-outbox OPINIÓN.
38. Esri Community, «Offline Inbox/Send Folder Storage Time», GIS_Fox y ZacharySutherby, 2022-05-17. https://community.esri.com/t5/arcgis-survey123-questions/offline-inbox-send-folder-storage-time/td-p/1174865 OPINIÓN.
39. Esri Community, «Recovering Data after Survey123 Update», JessicaCelis (2017-05-17), JohnHasthorpe (2017-05-19). https://community.esri.com/t5/arcgis-survey123-questions/recovering-data-after-survey123-update/td-p/833084 OPINIÓN.
40. Esri Support, artículo 000027616 (agregar un campo a un formulario de Field Maps con área offline: «Click Delete or Recreate on the offline map area … download the offline map area again»). https://support.esri.com/en-us/knowledge-base/000027616 HECHO.
41. Magpi, «Android user guide». https://support.magpi.com/support/solutions/articles/4863-android-user-guide — NO VERIFICADO: el dominio no resolvió DNS; contenido sólo por resumen del buscador.
42. Google Play Console Help, política de abuso de dispositivo y red. https://support.google.com/googleplay/android-developer/answer/16273414 HECHO.
43. Apple, «App Review Guidelines», 2.5.2 y 4.7 (4.7.2, 4.7.3). https://developer.apple.com/app-store/review/guidelines/ HECHO.
44. Hacker News, comentario de yanokwa, 2022-05-26. https://news.ycombinator.com/item?id=31520984 OPINIÓN.
45. Hacker News, comentario de not_the_nsa, 2018-05-27, en «ODKCollect: Android app for forms, designed for use in challenging environments». https://news.ycombinator.com/item?id=17165822 OPINIÓN.
46. Hacker News, comentario de jasonkostempski, 2018-05-27 (mismo hilo). https://news.ycombinator.com/item?id=17165399 OPINIÓN.
47. Hacker News, comentario de amind, 2018-05-27 (respuesta a [46]). https://news.ycombinator.com/item?id=17166366 OPINIÓN.
48. Hacker News, comentario de nrjames, 2015-12-04. https://news.ycombinator.com/item?id=10675574 OPINIÓN.
49. Hacker News, comentario de shaka-bear-tree, 2026-08-09. https://news.ycombinator.com/item?id=49235582 OPINIÓN.
50. Foro ODK, «ODK Collect, ODK Briefcase, ODK FormUploader, ODK Validate v1.4.9 now available», Mitch_S; anuncio de abril de 2016 migrado al foro (metadato 2020-03-14). https://forum.getodk.org/t/odk-collect-odk-briefcase-odk-formuploader-odk-validate-v1-4-9-now-available/5478 HECHO (anuncio del proveedor; agregada en la verificación).

---

## Verificación de fuentes

| Campo | Valor |
| --- | --- |
| Fecha | 2026-10-25 |
| Rol | Verificador adversarial: abrir cada fuente de HECHO y cada OPINIÓN, buscar la cita textual, el autor y la fecha |
| Método | `curl` sobre las páginas oficiales (texto plano), API de releases de GitHub, API de Algolia de HN (`/items/{id}`: autor, fecha, texto), JSON de Discourse (`/t/{id}.json`) y, cuando el foro de ODK limitó la tasa, `/raw/{id}` por WebFetch; API REST de Confluence de Dimagi (título, `version.when`, estado); fechas de Esri Community desde `dateCreated` del HTML |
| Fuentes revisadas | **50** (las 49 del dossier, con [17] como una sola entrada de seis releases, más [50] agregada; [25] pasó de reservada a fuente nueva) |
| Citas de opinión cotejadas | 24 de 24: enlace, autor, fecha y texto coinciden salvo la de adam.butler |

**Correcciones (antes → después)**

1. §4.1, [12] adam.butler: «using out of date» **formularios** → la cita sigue «out of date **hardware**» y habla de un proyecto de polio que el autor aclara que no es de ODK; se reescribió la fila.
2. §3.3 (a), [10]: «datos atrapados en un dispositivo que había quedado en el borrador» → el hilo da salida (reconfigurar con el QR de un App User del formulario publicado, LN 2022-02-22); se reescribió.
3. §3.5, [31]: «CommCare desaconseja saltos de versión del programa y recomienda avanzar por escalones» → la página dice que saltar desde una versión sin compatibilidad pierde datos sin mecanismo que lo impida, recomienda actualizar en cuanto se anuncia el retiro y ofrece «Submit and Reinstall» o «Intermediate Upgrade»; se reescribió con citas.
4. §3.5: Collect 1.4.9 «anuncio de 2017 … NO VERIFICADO» → verificado en el foro ([50]): abril de 2016 (metadato de migración 2020-03-14) y lo que exige son Briefcase, FormUploader y Validate 1.4.9.
5. §2 SurveyCTO: «Que derive de ODK … NO VERIFICADO» → HECHO por la documentación propia ([25]).
6. §2 SurveyCTO: «web siempre usa la última» → cita textual de [26] («whenever a web user begins a new submission…») y se agregó que el chequeo automático es «hourly».
7. §2 KoboCollect: v2025.2.3 es la última release **estable** en GitHub; hay pre-releases posteriores (v2025.3.3, v2026.2.2 del 2026-10-23). Igual para ODK Collect (v2026.4.0-beta.1). Se aclaró.
8. §2 Field Maps: «Artículo de soporte vigente» → fechas reales del artículo 000027616 (2022-05-02 / 2022-12-27).
9. §3.1 fila «Manual»: «tirar la galería» citaba [35], que no lo dice → se cita [33] y [34].
10. §3.1 fila «Periódico»: la frecuencia automática de KoboCollect está en [18], no en [19] → corregida la fuente.
11. [24]: el cambio de caché de Enketo Express 2.0.0 (marzo 2020) pasó de NO VERIFICADO a verificado en el blog, con la salvedad de que el post no nombra Service Workers.
12. §4 conteo: «La mayoría de los autores no tiene cargo verificado» (generalización) → «No se verificó el cargo de ningún autor».
13. §3.4: «CommCare, la única que fuerza» → «la única de las revisadas».
14. §5 P1: «Toda la familia de relevamiento usa B» → acotado a las plataformas revisadas.
15. §5 Forzado: «los usuarios lo piden (2020)» se apoyaba en un solo hilo de ODK → acotado a ese hilo; para Kobo y SurveyCTO no se buscaron pedidos.

**Confirmado sin cambios (muestra de lo cotejado):** versiones y fechas de GitHub de Central, kpi, Enketo y commcare-android; las seis citas de HN (autor, fecha y texto); ODK Docs [1]–[4] (modos de actualización, auto send, «NOT the latest one», `form_update_mode`); `orx:version` [5]; «yyyymmddrr» [6]; LN en [7], [8] (el hilo está en la categoría *Ideas*) y [9]; Marco y seadowg [11]; issa, seadowg, amalm y la v1.28 en [12]; Central v1.1 [13] (Matthew_White, 2020-12-23); Central v2024.3 [14] (Sadiq_Khoja, 2024-12-17); mathieubossaert [15]; yanokwa [16]; Kobo [18] (actualizada 2026-09-08) y [19] (2026-07-17); hilos de Kobo [20]–[23]; Dimagi [28]–[32] (fechas de `version.when` coinciden; [32] figura *archived*); Esri [33] (entrada de julio 2026 presente, 3.9.148 del 2020-04-02), [34] (estado *Duplicate*, versión 3.13, Android 7.x), [36]–[39] (autores, fechas y citas); Google Play [42]; Apple 2.5.2, 4.7, 4.7.2 y 4.7.3 [43].

**Siguen NO VERIFICADAS (5):** [27] SurveyCTO Support (403 de Cloudflare, otra vez); [41] Magpi (`support.magpi.com` sigue sin resolver DNS), por lo que la fila de Magpi queda entera sin verificar; el post del blog de Esri de marzo 2020 en [33] (403, no se reintentó por otra vía); lo de conflictos y «base version» de *Entities* en [14] (no se leyeron los dos hilos); versión vigente de SurveyCTO.
