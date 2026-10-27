| Campo | Valor |
| --- | --- |
| Ángulo | I6 — Apps empresariales y de campo: sin red, actualización al iniciar sesión o al abrir |
| Fecha de consulta | 2026-10-25 (todas las fuentes, salvo que se diga otra cosa) |
| Autor | Investigador I6 (comisión en caliente, expediente 0001) |
| Insumos de contexto | Folios 003 (P1–P11), 004 (actualización al iniciar sesión, manifiesto), 005 (encuestas, P13), 006 (actualización forzada) |

# I6 — Plataformas empresariales offline y la actualización al iniciar sesión

## Índice

1. [Alcance del ángulo](#1-alcance-del-ángulo)
2. [Qué se usa](#2-qué-se-usa)
3. [Cómo resuelven lo específico](#3-cómo-resuelven-lo-específico)
   - 3.1 Momento de actualización
   - 3.2 Versionado de lo descargado y compatibilidad con la app instalada
   - 3.3 Datos tomados con una versión vieja
   - 3.4 Permisos y capacidades fijados por el manifiesto
   - 3.5 Tiendas y forzado del cascarón
4. [Opiniones de desarrolladores](#4-opiniones-de-desarrolladores)
5. [Lecciones aplicables a P1–P13](#5-lecciones-aplicables-a-p1p13)
6. [Fuentes](#6-fuentes)

Convenciones: **HECHO** = documentación oficial, nota de versión o anuncio del proveedor. **OPINIÓN** = foro, issue, blog o comentario, con autor y fecha. **NO VERIFICADO** = no se pudo leer la fuente primaria (se dice por qué). **[criterio propio]** = inferencia de este investigador, no de una fuente. Las citas en inglés van textuales; el resto es traducción propia.

---

## 1. Alcance del ángulo

El ángulo cubre las plataformas empresariales que hacen, a escala industrial, lo que el PO describe en los folios 004–006:
un **cliente nativo genérico** (el «cascarón», publicado en la tienda) que **baja del servidor la definición de la app**
(pantallas, reglas, metadatos), **opera completo sin red** sobre una base local y **sincroniza** cuando hay conexión.

Productos relevados: Microsoft Power Apps (canvas, model-driven y *wrap*), Dynamics 365 Field Service, SAP Mobile
Services / Mobile Development Kit (MDK), Salesforce Field Service mobile, ServiceNow Mobile y, como contraste
web, las PWA con service worker (ciclo `waiting`/`skipWaiting`, Workbox, Angular). Se suman tres datos de apoyo que
aparecieron en la búsqueda y responden directo a P13 y al forzado: ServiceMax Go (PTC), Oracle Field Service y ODK
(sólo el manejo de versiones de formulario; el relevamiento de apps de encuestas es del ángulo I1).

Fuera de alcance: código, ensayos en el g42, compilación.

**Límites de acceso** (afectan qué quedó HECHO y qué NO VERIFICADO):

- `developer.salesforce.com/docs/...` devolvió **403** a WebFetch y a `curl` (2026-10-25). Lo de Salesforce que viene
  de esa sede se tomó del extracto del buscador y va marcado. La nota de ayuda `help.salesforce.com` 000353214 sí se leyó.
- `support.ptc.com` / `supporttest.ptc.com` devolvieron **522** (servidor caído). ServiceMax queda NO VERIFICADO.
  *[Verificador, 2026-10-25: `support.ptc.com` sigue en 522, pero el espejo `supporttest.ptc.com` respondió 200 para r24.2 y r25.2; con él se verificó [27] y parte de [28]. Ver correcciones en el texto.]*
- `community.sap.com` devolvió **403**. Los hilos de la comunidad SAP quedan NO VERIFICADOS.

---

## 2. Qué se usa

| Nombre | Qué actualiza sin tienda | Cómo trabaja sin red | Cómo fuerza o programa la actualización | Versión / estado vigente | Fuente |
| --- | --- | --- | --- | --- | --- |
| **Power Apps — canvas offline** (cliente «Power Apps» de la tienda) | La app canvas publicada (pantallas y fórmulas Power Fx). El cliente de la tienda es el mismo para todas las apps. | *Offline-first*: base local transaccional; la **sincronización inicial** se dispara **al abrir la app**; luego *delta sync* cada 5 min con red; ícono de estado (pendientes, error). | Publicar no empuja: el usuario ve el aviso «A new version of this app is available» y **tiene que refrescar**; «there is currently no functionality to automatically refresh». Forzar = patrón casero (comparar versión al iniciar). | Doc. 2024-05-31; limitaciones 2026-06-17; corrección de 2024 «metadata updates without the need to close the Player app» | [1] [2] [4] [7] [8] |
| **Power Apps wrap** (app nativa con marca propia que envuelve apps canvas) | **Los cambios publicados de las apps canvas**: «downloaded automatically by existing, released versions of your mobile app». | Igual que canvas offline (mismo motor). | Re-envolver y redistribuir **sólo** para íconos, colores, agregar o quitar apps, y **«at least monthly»** para seguir la plataforma. | FAQ ms.date 2026-06-12 | [6] |
| **Power Apps model-driven / Dynamics 365 Field Service mobile** | Definición de la app y perfil offline (qué tablas, filtros, intervalos) desde Dataverse. | *Offline-first* por defecto; la **primera sincronización arranca al iniciar sesión** («When a user logs into the offline-enabled application, the first sync will start»); intervalos por tabla de 5 min a 1 día; limpieza diaria; la subida de cambios es inmediata si hay red o queda local. | Inicia la sincronización sólo con la app activa y conectada (en Android e iOS, una vez iniciada puede terminar en segundo plano [9]); el 2026-10-06 se publicaron en la hoja de ruta la subida en segundo plano con avisos de pendientes [11] y una base offline más nativa [12] (en desarrollo, GA estimada nov-2026). | Doc. FS 2026-10-19; blog 2023-11-06; hojas de ruta RM573241 y RM573240 (publicadas 2026-10-06) | [3] [5] [9] [10] [11] [12] |
| **SAP MDK** (cliente genérico «SAP Mobile Services Client» de la tienda, o cliente con marca propia) | **Metadatos de la app** (páginas, acciones, reglas JS) como *bundle* desplegado en Mobile Services. | Almacén *Offline OData*: `InitializeOffline` baja los datos; `UploadOffline`/`DownloadOffline` sincronizan; los rechazos van a `ErrorArchive`. | El cliente consulta **al lanzarse y tras el código de acceso, al volver de segundo plano y cada 20–25 min**. Sin manejador, aplica solo. `OnWillUpdate` permite **aceptar o postergar**; `OnDidUpdate` reabre almacenes; si falla, **vuelve a la versión anterior**. | Página «App Update» (SAP Help, «Last update: July 20, 2026»). «Clientes 26.x en 2026»: NO VERIFICADO (la página sólo lista notas del SDK Android 26.8.4 en su navegación; no dice la versión vigente del cliente MDK) | [13] [14] |
| **Salesforce Field Service mobile** | Metadatos de la org (diseños, LWC, configuración) y datos por *briefcase*. | *Priming* (pre-carga) de registros y metadatos; caché local durable con cambios hechos sin red; *priming* «best effort» (NO VERIFICADO: la frase no está en [18]; vendría de [19], con 403). Las citas de agenda del horizonte configurado «are pulled down and synced **at login**». | Tiempos de caché configurables: «Record Data Cache Time» (frecuencia de *priming*) y una caché de metadatos **en días** («org metadata, such as layouts»). Versión mínima de la app nativa: objeto `MobileSecurityPolicy` (`MinimumAppVersion`), con licencia adicional — NO VERIFICADO (403 en [21]); según el extracto del buscador, `MinimumAppVersion` es un *tipo de política* del objeto, que exige el add-on «Enhanced Mobile App Security» y se describe para la **app móvil Salesforce**, no para la app Field Service: su aplicación a Field Service no está demostrada. | Nota de ayuda publicada 2026-07-14 | [18] [19] [21] |
| **ServiceNow Mobile** (Agent / Field Service) | Metadatos de la app móvil (lanzadores, barra de navegación, propiedades); las propiedades «after authentication». | Caché offline descargable (también programada por horario de trabajo, sólo Wi-Fi); **expira (48 h por defecto en la doc. Brazil)**; *Outbox* para cambios; al sincronizar **borra la caché**. | Refresco de metadatos **manual** (tirar hacia abajo) cuando el administrador lo indica; `clientRefresh` refresca pantallas ya visitadas. | Releases Brazil y Zurich | [23] [24] [25] [26] |
| **ServiceMax Go** (PTC) | *Configuration Sync* (objetos, campos, transacciones SFM, búsquedas, checklists) separada de *Data Sync*; la Config Sync «preserves the synchronized and yet-to-be synchronized data» [28]. | Sincronización bidireccional por Sync Gateway, programada con red; almacén offline seguro [28]. «Sincronización completa en el primer ingreso o al cambiar de usuario»: NO VERIFICADO (lo leído sólo exige *Initial or Config Sync* si cambia el perfil o los datos del usuario [28]). | **Versión mínima de la app** por plataforma en Mobile Console: el técnico debe salir y volver a ingresar para tomarla; con versión vieja ve una alerta de no cumplimiento que **puede descartar y seguir trabajando**; si la sesión vence, **no puede volver a ingresar** sin actualizar [27]. | r24.2 y r25.2 (espejo `supporttest.ptc.com`) | [27] [28] |
| **Oracle Field Service** | — (relevado sólo por el forzado del cascarón). | — | **Al iniciar sesión** compara la versión instalada con la de la tienda; las 6 versiones mayores más recientes siguen; las anteriores quedan **bloqueadas** hasta actualizar. | Doc. vigente | [29] |
| **PWA con service worker** (Workbox / Angular SW) | Todo el contenido web cacheado (HTML, JS, WASM). | Precaché + estrategias de caché. | El SW nuevo queda en **`waiting`** hasta que se cierren todas las pestañas; `skipWaiting()` lo activa ya; patrón recomendado: **avisar y recargar** con consentimiento, o aplicar en la próxima visita. | Workbox doc. 2021-12-07; web.dev 2016-09-29; MDN 2024-05-13 | [30] [31] [32] [33] [34] |

---

## 3. Cómo resuelven lo específico

### 3.1 Momento de actualización

| Producto | Al abrir | Al iniciar sesión | En segundo plano / periódico | Forzado |
| --- | --- | --- | --- | --- |
| Power Apps canvas | Sí: la sincronización inicial de **datos** se dispara al abrir; si no terminó, se reintenta en cada apertura [1]. La **app** nueva se toma al refrescar (aviso) [8]. | — | *Delta sync* cada 5 min sólo con la app en primer plano y pantalla desbloqueada [1] [4] [5]. | No nativo para el contenido; «no functionality to automatically refresh» [8]. |
| D365 Field Service | — | **Sí**: primera sincronización al loguear [10]. | Intervalos por tabla; limpieza diaria [9] [10]. | — |
| SAP MDK | **Sí**: «After the client is launched and user has entered the passcode» [13]. | El pedido es tras el código de acceso, no tras el login (la página no menciona el login) [13]. | Al volver de segundo plano y cada 20–25 min en primer plano [13]. | Sin `OnWillUpdate`, se aplica sin preguntar; con él, el usuario puede postergar y se repregunta en el próximo ciclo [13]. |
| Salesforce FS | — | **Sí**: el horizonte de agenda se baja «at login» [18]. | Por tiempo de caché (minutos para datos, días para metadatos) [18]. | Para el cascarón: `MinimumAppVersion` [21] (NO VERIFICADO en detalle). |
| ServiceNow | — | Las propiedades móviles llegan «after authentication» [26]. | Caché programada [23]. | Refresco de metadatos manual «when instructed by your administrator» [25]. |
| ServiceMax Go | — | Bloqueo de versión mínima **al ingresar** [27]. | *Config Sync* + *Data Sync*; datos por calendario con red [28]. | Versión mínima; alerta descartable para la sesión en curso [27]. |
| Oracle FS | — | **Sí**: chequeo de versión del cascarón al loguear [29]. | — | Bloqueo por antigüedad (más de 6 versiones mayores) [29]. |
| PWA | Sí: el chequeo lo dispara la navegación [32]; se activa en la próxima carga sin pestañas abiertas [30]. | — | Eventos funcionales chequean si pasaron 24 h [32]. | `skipWaiting()` + recarga; riesgo documentado [32] [34]. |

**Lectura.** La señal del PO (folio 004) se confirma en la industria con matices:
el **login** es el momento elegido para lo **pesado e inicial** (primera sincronización en D365 FS [10], horizonte de agenda
en Salesforce [18], chequeo de versión mínima del cascarón en Oracle [29] y ServiceMax [27]); el **abrir/reanudar** es el
momento del **contenido** (SAP MDK [13], PWA [30]); y siete de los ocho productos de la tabla (todos menos Oracle FS, relevado sólo por el cascarón) tienen algún ciclo **periódico** o programado (conteo del verificador sobre la tabla de 3.1).

### 3.2 Versionado de lo descargado y compatibilidad con la app instalada

- **SAP MDK es el caso documentado de incompatibilidad cascarón ↔ contenido.** SAP advierte, para su app genérica
  de tienda: «The existing metadata is not guaranteed to work with a new version of the Asset Manager mobile app if one
  is released», y recomienda **desactivar la actualización automática de la tienda** en los equipos [15]. Sobre el
  cliente genérico: las actualizaciones de la tienda «forces them to reonboard and possibly have metadata incompatibility
  issues»; la alternativa es un **cliente con marca propia** que la empresa controla [16]. *[Verificador: ambas citas de
  [15] y [16] se refieren al cliente de tienda de **SAP Service and Asset Manager** (SSAM), no al cliente genérico «SAP
  Mobile Services Client»; la extensión al cliente genérico es inferencia.]* Componentes de la actualización que lista
  SAP: metadatos, *add-on* de backend (MAIF), Cloud Connector y cliente MDK [15]; **no es un orden obligatorio**: el
  texto dice que el Cloud Connector y el cliente MDK «can be upgraded independent of the SAP Service and Asset Manager»,
  y que las dos versiones de la app pueden correr en paralelo para un despliegue gradual [15].
- **Comparación de versión y vuelta atrás** (HECHO, SAP): el cliente no hace nada si la versión del servidor es «igual
  o más vieja»; si el *bundle* nuevo no carga, o si `OnDidUpdate` falla o se rechaza, «the app is rolled back to the
  previous version» [13].
- **Esquema de metadatos vs. versión del cliente** (NO VERIFICADO — hilo de la comunidad SAP con 403; dato del extracto
  del buscador [17]): un proyecto con esquema de metadatos MDK 23.4 no se aplicaba sobre un cliente genérico 6.3.7; la
  respuesta aceptada propone bajar el esquema o compilar un cliente propio con el SDK 23.4.0.
- **Power Apps** separa en el *wrap* lo que exige re-envolver (íconos, colores, conjunto de apps) de lo que viaja solo
  (cambios publicados de las apps) y fija una cadencia del cascarón: «rewrap and redistribute your mobile app at least
  monthly» [6]. La FAQ remite a *Power Apps for Makers: Get App Versions* para que los clientes que ya distribuyeron una
  app envuelta «ensure users receive the latest published changes» sin re-envolver [6]; no dice que sirva para
  consultar la versión vigente desde el equipo (la afirmación previa iba más allá de la fuente).
- **PWA**: la regla del ciclo de vida es «only one version of your site running at once» [32]. Angular advierte que activar
  una versión sin recargar puede mezclar el cascarón con piezas cargadas en diferido de otra versión, y define un evento
  de **estado irrecuperable** cuando una pieza ya no existe ni en caché ni en el servidor [34].

### 3.3 Datos tomados con una versión vieja (P13)

Ninguno de los productos empresariales documenta, en lo leído, una **migración de las capturas pendientes** cuando
cambia la definición. Lo que sí documentan (ServiceMax agregado por el verificador):

| Producto | Qué dice | Fuente |
| --- | --- | --- |
| Power Apps canvas (offline integrado) | La tabla oficial compara el offline integrado con `LoadData/SaveData`: «Automatically handles schema changes — Yes» para el integrado, «No» para el casero. No explica el mecanismo. | [2] |
| SAP MDK | `OnWillUpdate` sirve para **cerrar almacenes offline o guardar datos no guardados** antes de aplicar; el usuario puede **postergar** la actualización (el ejemplo «in the middle of a transaction» está en el tutorial [14], no en [13]); `OnDidUpdate` reabre e inicializa el almacén. | [13] [14] |
| ServiceMax Go | La *Config Sync* (definiciones) «preserves the synchronized and yet-to-be synchronized data»; recomienda sincronizar datos antes. Un *Record Type* nuevo exige reiniciar la app. | [28] (FAQ r25.2) |
| SAP MDK | Cerrar sesión o reiniciar el cliente **borra todos los almacenes offline** (nota de versión 3.0 SP01, NO VERIFICADO: blog SAP con 403; dato del extracto del buscador). | [17] |
| D365 FS | Conflictos **por registro, no por campo** (la doc. dice «at the table level, not the field level» y lo explica como registro completo); por defecto «offline changes win»; con detección activa gana el servidor y el técnico ve error de sincronización. Datos que dejan de cumplir el filtro del perfil se **eliminan del equipo** tras sincronizar. | [9] |
| ServiceNow | Si la caché vence sin sincronizar: «you lose all the data that you saved to the cache» (Zurich) [24]; la doc. Brazil dice que los cambios no sincronizados en 48 h pasan al *Outbox* y suben «at the user's next log out» [23]. Las dos releases no dicen lo mismo. | [23] [24] |
| ODK (encuestas) | Central acepta envíos de **toda combinación formulario+versión publicada** y no borrada; publicar exige **cambiar la versión**; los envíos anteriores se conservan; el tipo de dato de un campo publicado no se puede cambiar (excepción: siempre se puede pasar a texto) [41]. *[Verificador: la frase «toda combinación formulario+versión» no está en [41]; es de LN en el foro [43].]* En Collect, «Exactly match server» borra formularios que ya no están, pero «filled instances … will still be editable». | [41] [42] [43] |

**Lectura.** El patrón común (ODK lo hace explícito) es **etiquetar cada captura con la versión de la definición** y que
el servidor **acepte versiones anteriores publicadas**; en las plataformas cerradas el equivalente es que el motor de
sincronización trabaja contra el **esquema de datos del servidor**, no contra la pantalla, y las pantallas pueden cambiar
sin tocar lo capturado [2] [criterio propio sobre la lectura de [2]]. El punto débil reiterado es **qué pasa al cerrar
sesión o al vencer la caché** con pendientes: SAP borra almacenes al cerrar sesión [17] (NO VERIFICADO, 403), ServiceNow pierde lo no
sincronizado al vencer [24].

### 3.4 Permisos y capacidades fijados por el manifiesto (P12)

- **SAP MDK**: las capacidades nativas fuera del conjunto estándar requieren **cliente propio**: «Custom extension controls
  cannot be added to a nonbranded client», y las extensiones que ya trae el cliente de tienda no se pueden quitar [16]
  (texto referido al cliente de tienda de SSAM). Los *plugins* NativeScript se agregan al cliente con marca propia:
  el tutorial de geolocalización enseña «How to add a NativeScript plugin to your branded MDK client», y el de mapas
  pide compilar el cliente propio «when accessing the Google Maps on Android device», mientras en iOS usa el cliente de
  tienda [16] (verificado por el verificador el 2026-10-25: el requisito no es igual en las dos plataformas).
- **Salesforce**: las capacidades del dispositivo llegan a los componentes web por un módulo de la plataforma
  (`lightning/mobileCapabilities`) y el componente **pregunta antes de usar**: llamar `isAvailable()` antes de escanear;
  en escritorio el componente se muestra sin error pero el escaneo falla (extracto del buscador sobre la doc. de
  Salesforce con 403) [20].
- **Power Apps wrap**: lo que cambia el paquete nativo (íconos, colores, conjunto de apps) exige re-envolver y
  redistribuir [6]. La FAQ no trata permisos del sistema operativo.

**Lectura** *[criterio propio; la parte de Salesforce descansa en [20], NO VERIFICADO, y la FAQ de wrap [6] no trata permisos]*. Las tres plataformas resuelven la frontera igual: **el cascarón trae un catálogo cerrado de capacidades**;
el contenido descargado las **descubre en tiempo de ejecución** y degrada si faltan; **sumar una capacidad nueva es un
release del cascarón** por tienda (o por MDM, como SAP [16] y wrap [6]).

### 3.5 Tiendas y forzado del cascarón

- No se encontró en este ángulo ningún rechazo de tienda documentado para estos productos. Con fuente leída, hay
  clientes de tienda que bajan definiciones del servidor en SAP (cliente SSAM y SAP Mobile Services Client en App Store
  / Play [14] [16]), Oracle FS (compara con «the respective app stores» [29]) y Power Apps wrap (distribución por
  Intune, Google Play o Apple Business Manager [6]); para el resto no se verificó la distribución. Ausencia de
  evidencia, no evidencia de ausencia.
- El **forzado del cascarón** se hace **al iniciar sesión** contra una versión mínima (Oracle [29], ServiceMax [27];
  Salesforce `MinimumAppVersion` [21] NO VERIFICADO y descrito para la app Salesforce, no para Field Service).
  ServiceMax distingue el ingreso nuevo (bloqueo) de la sesión en curso (aviso descartable) [27] — verificado en el
  espejo r25.2; que sea «la forma de no cortar el trabajo sin red» es **[criterio propio]**.
- El **forzado del contenido**, en los cuatro casos citados: SAP, **sin manejador `OnWillUpdate`, aplica la versión
  nueva sin preguntar** (forzado de hecho) y con manejador permite postergar [13]; Power Apps sólo avisa y el usuario
  refresca [8]; Workbox y Angular recomiendan pedir confirmación antes de recargar [30] [34]. *[Verificador: antes
  decía «casi nunca es duro»; el comportamiento por defecto de SAP lo contradice.]*

---

## 4. Opiniones de desarrolladores

Señal cualitativa, no estadística. Las tablas tienen **16 filas** (3 + 9 + 4; el texto decía «15»: corregido por el
verificador), de 9 referencias en 8 sedes (GitHub w3c/ServiceWorker, lista w3.org, dev.to, Hacker News, dos blogs de
Power Apps, Trailblazer Community y foro de ODK con dos hilos); una fila (Lindner) no tiene año visible. No hubo resultados de
Reddit en las búsquedas hechas.

### 4.1 A favor (del patrón «contenido actualizable + operar sin red»)

| Fuente | Autor | Fecha | Postura | Cita | Tema |
| --- | --- | --- | --- | --- | --- |
| [38] HN «Downsides of Offline First» | aboodman | 2021-10-01 (hilo) | A favor con condición: tratar lo local como caché | «it can be deleted at anytime (by browser, or even by user!)» | Almacenamiento local: el servidor es la fuente de verdad |
| [43] Foro ODK | LN | 2021-04-20 | A favor del versionado explícito | «Central will accept submissions for any combination of `form_id` and `version` that it has published» | Capturas con versión vieja |
| [44] Foro ODK | LN | 2019-12-02 | La actualización es fluida si se cambia la versión | «as long as the new form version has a different `version` specified in the form definition» | Versionado de la definición |

### 4.2 En contra o con advertencias

| Fuente | Autor | Fecha | Postura | Cita | Tema |
| --- | --- | --- | --- | --- | --- |
| [36] lista w3.org (issue #1389) | Jan Tošovský, **citando** el artículo de Redfin Engineering «How to fix the refresh button when using service workers» (Approach 1) | 2019-02-19 | En contra de `skipWaiting` a ciegas | «The worst thing about blindly calling skipWaiting() is that it appears to work perfectly at first» | Forzar la versión nueva |
| [35] w3c/ServiceWorker #1238 | dfabulich | 2017-11-30 | Crítica al diseño | «Surprisingly, the `v2` Service Worker doesn't activate when the last client refreshes» | Activación al reabrir |
| [35] ídem | garygreen | 2019-08-06 | Reporte de falla del atajo | «completely freezes my browser and goes into endless loop» | Bucle de recarga |
| [35] ídem | signorpipo | 2024-02-28 | El atajo es «risky» con dos pestañas | (resumen: el SW cuenta un solo cliente y se activa con la otra pestaña en la versión vieja) | Dos versiones a la vez |
| [37] dev.to | Tom VanAntwerp | 2019-03-19 | Advertencia | «people were still seeing the old version» | SW viejo que sobrevive al deploy |
| [38] HN | thamer | 2021-10-01 (hilo) | En contra de lógica de fusión en equipos que no se actualizan | «you have bugs in this code running on devices you can never update, this can be a huge mess» | Clientes desactualizados |
| [38] HN | JamesSwift | 2021-10-01 (hilo) | Advertencia | «conflict resolution is a universal problem and is either the most difficult or second most difficult problem» | Conflictos |
| [40] joyofpowerapps | Joy H. Kirkwood | 2021-06-02 | Escéptica (era previa al offline integrado) | «Closing the app and dismissing it from active use can result in data loss» | Pérdida de pendientes |
| [44] Foro ODK | Saad | 2019-11-27/29 | Reporte de falla | «this auto-updated form does NOT work properly when I try to fill it and SAVE AS FINALIZED» | Misma versión, definición distinta |

### 4.3 Matices

| Fuente | Autor | Fecha | Postura | Cita | Tema |
| --- | --- | --- | --- | --- | --- |
| [39] forwardforever | Timo Pertilä | 2025-07-07 | Simple en teoría, difícil en la práctica | «In theory, making an app that can be used offline is really simple. In practice, it's not always so simple.» | Offline en Power Apps |
| [39] ídem | Timo Pertilä | 2025-07-07 | Queja de diagnóstico | «The most annoying aspect of offline support is the nonsensical error messages.» | Observabilidad de la sincronización |
| [38] HN | josephg | 2021-10-01 (hilo) | Los sistemas distribuidos migran lento (ejemplo: git y su hash); la capa base (CRDT) tiene que ser correcta | «we need to prioritise correctness so you can deploy this stuff and forget about it» | Protocolo de sincronización |
| [22] Trailblazer Community | Heiko Lindner | 17-ago (año no visible; pregunta del 12-ago) | Práctica de campo | «sometimes you have to logout and re-login again to see page layout changes» | Metadatos que se toman al reingresar |

NO VERIFICADO (no contados): un hilo de la comunidad Power Apps «Forcing app updates to mobile users» (redirige a la
portada de la comunidad) donde, según el buscador, se propone guardar la versión en una fuente de datos y compararla al
iniciar; y un hilo de Esri Community sobre Survey123 donde personal de Esri diría que cambiar el tipo de un campo obliga
a republicar y los envíos en «Sent» ya no se pueden reenviar (autor no identificado).

---

## 5. Lecciones aplicables a P1–P13

| Pregunta | Lección | Fuente |
| --- | --- | --- |
| **P1** modelo de contenido | Las plataformas de campo combinan **definición como datos/metadatos** (Power Apps, MDK, ServiceNow, ServiceMax) con un **cliente genérico nativo**; ninguna baja código nativo nuevo **[criterio propio: ninguna fuente leída lo afirma; es lo que se infiere de que las capacidades nativas nuevas exijan cliente propio [16]]**. MDK sí baja **reglas JS** dentro del *bundle*, o sea un híbrido de datos + código interpretado. Para la encuesta (folio 005), la definición de la encuesta como dato versionado es el caso más documentado (ODK). | [13] [6] [41] |
| **P2** canal | Elementos con respaldo: comparación de versión que ignora iguales o anteriores; evento previo con **postergación**; evento posterior con **vuelta atrás automática**; chequeo al abrir, al reanudar y periódico. | [13] |
| **P3** contrato cascarón–contenido | La incompatibilidad metadatos ↔ cliente es un riesgo real y documentado por SAP (para el cliente de tienda de SSAM); su mitigación es **controlar el cliente** (marca propia, o apagar la autoactualización de tienda) y poder correr dos versiones de la app en paralelo [15]. **[criterio propio]**: declarar en el manifiesto de contenido la versión mínima de cascarón y del contrato (ya en el borrador como `minShellVersion`) tiene el mismo papel. | [15] [16] [17] |
| **P4** entrada | El login es el momento elegido para la **primera sincronización** y para el **chequeo de versión mínima del cascarón**; ServiceMax deja trabajar la sesión en curso y bloquea sólo el ingreso nuevo. | [10] [18] [27] [29] |
| **P5** sin red, outbox | Patrones con respaldo: estado visible de pendientes y errores; subida inmediata si hay red; conflictos por registro con política configurable; cola de errores (`ErrorArchive`). Riesgos documentados: **perder pendientes al cerrar sesión o al vencer la caché**. **[criterio propio]**: el framework no debería borrar la base local al cerrar sesión con pendientes. | [1] [9] [14] [17] [24] |
| **P6/P8** compuertas | Lección indirecta: SAP y Angular documentan fallas por mezcla de versiones; **[criterio propio]** una prueba de compuerta útil es «contenido N sobre cascarón mínimo declarado». | [15] [34] |
| **P7** líneas de versión | Al menos tres líneas independientes en la industria: **cascarón** (tienda, con versión mínima), **definición/contenido** (servidor) y **perfil de datos** (qué se baja). Power Apps fija además una cadencia del cascarón (mensual). | [6] [9] [13] [29] |
| **P10** guía | El ciclo `waiting` / próxima apertura de las PWA es un buen ejemplo didáctico de «aplicar en el próximo arranque» y de por qué no conviven dos versiones. | [30] [32] |
| **P11** demo | **[criterio propio]**: el escenario mínimo que ejercita lo relevado: abrir sin red con encuestas pendientes, publicar una versión nueva, reabrir con red y ver el aviso «actualizar/postergar» y la subida de los pendientes etiquetados con la versión vieja. | [13] [43] |
| **P12** capacidades | Catálogo cerrado en el cascarón; sumar capacidad = release del cascarón propio [16]. Que el contenido pregunte `isAvailable()` y degrade viene de [20], NO VERIFICADO (403). | [16] [20] |
| **P13** encuestas con versión vieja | Etiquetar cada respuesta con la versión de la definición; el servidor acepta versiones publicadas anteriores; **nunca** reutilizar una etiqueta de versión con contenido distinto; no cambiar el tipo de un campo publicado (salvo a texto). Si llega una versión nueva con una encuesta a medias: **postergar** (MDK) y no aplicar en medio de la captura. Actualizar la definición sin tocar lo pendiente: ServiceMax documenta que la *Config Sync* preserva los datos aún no sincronizados. | [13] [14] [28] [41] [43] [44] |
| **Forzado (folio 006)** | Contenido: la práctica documentada es **aplicar al abrir sin preguntar (SAP por defecto) o permitir postergar** (SAP con `OnWillUpdate` [13] [14], Workbox/Angular [30] [34]); «nunca en medio de una transacción» es lo que el tutorial de SAP pone como ejemplo de postergación [14], no una regla de todos. Cascarón: bloqueo **al iniciar sesión** por versión mínima (Oracle, ServiceMax) con tolerancia para la sesión en curso. Sin red no se puede forzar: **[criterio propio]** la encuesta en curso debe poder terminarse y quedar en cola. | [8] [13] [27] [29] [30] |

---

## 6. Fuentes

Fecha de consulta de todas: 2026-10-25.

1. Microsoft Learn — «Work with canvas apps offline». ms.date 2024-05-31. https://learn.microsoft.com/en-us/power-apps/mobile/canvas-mobile-offline-working — HECHO.
2. Microsoft Learn — «Mobile offline for canvas apps overview». ms.date 2024-06-05. https://learn.microsoft.com/en-us/power-apps/mobile/canvas-mobile-offline-overview — HECHO.
3. Microsoft Learn — «Mobile offline for model-driven apps overview». ms.date 2024-05-29 (actualizado 2026-09-18). https://learn.microsoft.com/en-us/power-apps/mobile/mobile-offline-overview — HECHO.
4. Microsoft Learn — «Mobile offline limitations for canvas apps». ms.date 2026-06-17. https://learn.microsoft.com/en-us/power-apps/mobile/limitations-canvas-apps — HECHO.
5. Microsoft Learn — «Sync data offline in the background». ms.date 2025-06-24. https://learn.microsoft.com/en-us/power-apps/mobile/sync-data-offline-background — HECHO.
6. Microsoft Learn — «Frequently asked questions for wrap». ms.date 2026-06-12. https://learn.microsoft.com/en-us/power-apps/maker/common/wrap/faq — HECHO.
7. Microsoft Learn — «Power Apps version 24073 - Release Notes». ms.date 2024-07-12; despliegue 2024-08-05. https://learn.microsoft.com/en-us/power-platform/released-versions/powerapps-studio-players/3.24073 — HECHO.
8. Microsoft Power Platform Community — artículo KA-24799 (refresco manual de apps canvas tras publicar). Sin fecha visible. https://community.powerplatform.com/article/KA-24799 — HECHO (artículo de soporte del proveedor). *Nota del verificador: el artículo no dice si se refiere al reproductor web o al cliente móvil, y es anterior o no fechado respecto de la corrección de [7] («metadata updates without the need to close the Player app»).*
9. Microsoft Learn — «Configure offline data synchronization» (Dynamics 365 Field Service). ms.date 2026-10-19. https://learn.microsoft.com/en-us/dynamics365/field-service/mobile/offline-data-sync — HECHO.
10. Microsoft Dynamics 365 Blog — Jonathan Baker, «Best Practices for Offline Mode in the Field Service mobile app – Part 1». 2023-11-06. https://www.microsoft.com/en-us/dynamics-365/blog/?p=187773 — HECHO (blog oficial del proveedor).
11. Hoja de ruta Microsoft 365 RM573241, «Dynamics 365 Field Service: Enhance mobile offline up-sync», publicada 2026-10-06, en desarrollo, GA estimada nov-2026; espejo https://mc.merill.net/message/RM573241 — HECHO (anuncio; estimación, no disponible).
12. Hoja de ruta Microsoft 365 RM573240, «Dynamics 365 Field Service: Modernize the mobile offline foundation» (sincronización nativa, filas relacionadas en la primera sincronización, carga de recursos de la app), publicada 2026-10-06, en desarrollo, GA estimada nov-2026; espejo https://mc.merill.net/message/RM573240 — HECHO (abierta por el verificador el 2026-10-25; antes NO VERIFICADO).
13. SAP Help — «App Update» (SAP Mobile Services, MDK). «Last update: July 20, 2026». https://help.sap.com/doc/f53c64b93e5140918d676b927a3cd65b/Cloud/en-US/docs-en/guides/features/app-update/mdk/app-update.html — HECHO.
14. SAP Developers — tutorial «cp-mobile-dev-kit-offline-app». Sin fecha. https://developers.sap.com/tutorials/cp-mobile-dev-kit-offline-app — HECHO.
15. SAP Learning — «Upgrading SAP Service and Asset Manager». https://learning.sap.com/courses/implementing-sap-service-and-asset-manager/upgrading-sap-service-and-asset-manager — HECHO.
16. SAP Learning — «Client Branding» (SAP Service and Asset Manager). https://learning.sap.com/courses/implementing-sap-service-and-asset-manager/client-branding — HECHO. Tutoriales de extensiones (mapas, geolocalización) citados desde el extracto del buscador: https://developers.sap.com/tutorials/cp-mobile-dev-kit-map-extension.html , https://developers.sap.com/tutorials/cp-mobile-dev-kit-nativescript-geolocation.html (Jitendra Kansal) — HECHO (leídos por el verificador el 2026-10-25; antes NO VERIFICADO).
17. SAP Community — hilo «SAP MDK App update failed with MDK version 23.4» https://community.sap.com/t5/technology-q-a/sap-mdk-app-update-failed-with-mdk-version-23-4/qaq-p/12669454 y blog «What's new in Mobile development kit client 3.0 SP01» (2019-06-06) https://community.sap.com/t5/technology-blog-posts-by-sap/what-s-new-in-mobile-development-kit-client-3-0-sp01/ba-p/13399678 — NO VERIFICADO (403; contenido tomado del extracto del buscador).
18. Salesforce Help — «Salesforce Field Service app for iOS and Android performance considerations» (000353214). Publicado 2026-07-14. https://help.salesforce.com/s/articleView?id=000353214&language=en_US&type=1 — HECHO (no contiene «best effort»).
19. Salesforce Developers — «What Happens When Something Isn't Primed (Preloaded)». https://developer.salesforce.com/docs/atlas.en-us.mobile_offline.meta/mobile_offline/offline_not_primed.htm — NO VERIFICADO (403; extracto del buscador).
20. Salesforce Developers — «Scan Barcodes on a Mobile Device» (Field Service, `lightning/mobileCapabilities`). https://developer.salesforce.com/docs/atlas.en-us.field_service_dev.meta/field_service_dev/fsl_dev_mobile_lwc_barcode_scanner.htm — NO VERIFICADO (403; extracto del buscador).
21. Salesforce Developers — objeto `MobileSecurityPolicy` (`MinimumAppVersion`). https://developer.salesforce.com/docs/atlas.en-us.object_reference.meta/api/sforce_api_objects_mobilesecuritypolicy.htm — NO VERIFICADO (403; extracto del buscador: política de la app Salesforce con el add-on Enhanced Mobile App Security, API 50.0+).
22. Trailblazer Community — hilo de Simbil Nessek, respuesta de Heiko Lindner (17-ago, año no visible). https://trailhead.salesforce.com/trailblazer-community/feed/0D5KX00000pOwMt0AK — OPINIÓN.
23. ServiceNow Docs — «Offline mode» (release Brazil). https://www.servicenow.com/docs/r/mobile/mobile-offline-mode.html — HECHO.
24. ServiceNow Docs — «Offline mode for mobile» (release Zurich). https://www.servicenow.com/docs/r/zurich/mobile/offline-end-user.html — HECHO.
25. ServiceNow Docs — «Refresh mobile app meta-data» (release Brazil). https://www.servicenow.com/docs/r/mobile/metadata-refresh.html — HECHO.
26. ServiceNow Docs — «Turn on or turn off automatic app refresh» (release Brazil). https://www.servicenow.com/docs/r/mobile/enable-disable-auto-app-refresh.html — HECHO.
27. PTC ServiceMax — «Managing Login Settings» / «Global Settings Manager» (r25.2). https://support.ptc.com/help/servicemaxcore/en/articles/go/managing-login-settings.html (522) — HECHO vía espejo: https://supporttest.ptc.com/help/servicemaxcore/r25.2/en/articles/go/go-global-settings-manag.html y https://supporttest.ptc.com/help/servicemaxcore/r24.2/en/articles/go/go-console-login-settings.html (leídos 2026-10-25).
28. PTC ServiceMax — «Sync Operations», «Frequently Asked Questions for Go», «Important Considerations». https://support.ptc.com/help/servicemaxcore/en/articles/go/go-tech-sync-operations.html (522) — HECHO vía espejo r25.2: https://supporttest.ptc.com/help/servicemaxcore/r25.2/en/articles/go/go-tech-sync-operations.html , .../go/go-faq.html , .../go/go-important-considerations.html. La «sincronización completa al primer ingreso o al cambiar de usuario» sigue NO VERIFICADA.
29. Oracle — «Prompt Mobile Application Users to Upgrade Mobile Application from Previous Versions» (Oracle Field Service). https://docs.oracle.com/en/cloud/saas/field-service/famai/c-prompt-to-upgrade-from-a-previous-version.html — HECHO.
30. Chrome for Developers — «Handling service worker updates with immediacy» (Workbox). Última actualización 2021-12-07. https://developer.chrome.com/docs/workbox/handling-service-worker-updates — HECHO.
31. Chrome for Developers — «workbox-window». Última actualización 2019-02-24. https://developer.chrome.com/docs/workbox/modules/workbox-window — HECHO.
32. web.dev — Jake Archibald, «The service worker lifecycle». Última actualización 2016-09-29. https://web.dev/articles/service-worker-lifecycle — HECHO.
33. MDN — «ServiceWorkerGlobalScope: skipWaiting() method». Modificado 2024-05-13. https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerGlobalScope/skipWaiting — HECHO.
34. Angular — «Communicating with the Service Worker». https://angular.dev/ecosystem/service-workers/communications — HECHO.
35. GitHub w3c/ServiceWorker issue #1238, «Provide a way to skipWaiting when the last tab refreshes» (abierto por dfabulich, 2017-11-30; comentarios de garygreen 2019-08-06 y signorpipo 2024-02-28). https://github.com/w3c/ServiceWorker/issues/1238 — OPINIÓN.
36. Lista public-webapps-github (w3.org), Jan Tošovský, comentario en w3c/ServiceWorker #1389, 2019-02-19. https://lists.w3.org/Archives/Public/public-webapps-github/2019Feb/0799.html — OPINIÓN. La frase citada es una cita que Tošovský toma de Redfin Engineering, https://redfin.engineering/how-to-fix-the-refresh-button-when-using-service-workers-a8e27af6df68 (artículo no abierto por el verificador).
37. DEV Community — Tom VanAntwerp, «I broke the refresh button: dealing with a rogue service worker», 2019-03-19. https://dev.to/tvanantwerp/i-broke-the-refresh-button-dealing-with-a-rogue-service-worker-m2m — OPINIÓN.
38. Hacker News — «Downsides of Offline First» (enviado por typingmonkey, 2021-10-01; comentarios de aboodman, thamer, JamesSwift, josephg). https://news.ycombinator.com/item?id=28717848 — OPINIÓN.
39. Forward Forever — Timo Pertilä, «Canvas Power Apps and offline use – building in practice», 2025-07-07. https://forwardforever.com/canvas-power-apps-and-offline-use-building-in-practice/ — OPINIÓN.
40. Joy of Power Apps — Joy H. Kirkwood, «An honest guide to canvas app offline (part 2)», 2021-06-02. https://joyofpowerapps.com/2021/06/02/an-honest-guide-to-canvas-app-offline-part-2/ — OPINIÓN (anterior al offline integrado de [2]).
41. ODK Docs — «Managing Forms in Central». https://docs.getodk.org/central-forms/ — HECHO.
42. ODK Docs — «Collect settings» (modo de actualización de formularios). https://docs.getodk.org/collect-settings/ — HECHO.
43. ODK Forum — «Can you still send data from old versions of forms to ODK Central?» (pregunta de BeccaHandley, respuesta de LN, 2021-04-20). https://forum.getodk.org/t/can-you-still-send-data-from-old-versions-of-forms-to-odk-central/33257 — OPINIÓN (no verificado si LN es del equipo ODK).
44. ODK Forum — «Updating an existing form in Collect is not seamless» (Saad, 2019-11-27; LN, 2019-12-02). https://forum.opendatakit.org/t/updating-an-existing-form-in-collect-is-not-seamless/23552 — OPINIÓN.

---

## Verificación de fuentes

| Campo | Valor |
| --- | --- |
| Fecha | 2026-10-25 |
| Verificador | Verificador adversarial (expediente 0001), con `curl`, WebFetch y WebSearch |
| Referencias revisadas | **44 de 44** intentadas. Abiertas y cotejadas: 40 (1–16, 18, 22–44, con 27–28 por el espejo `supporttest.ptc.com` y los dos tutoriales de [16]). Inaccesibles: 4 (17 y la parte comunitaria: 403 de `community.sap.com`; 19, 20, 21: 403 de `developer.salesforce.com`, también por el endpoint `get_document_content`). |
| Citas textuales de opinión cotejadas | 16 de 16 filas: enlaces existen, autores y fechas coinciden (HN: usuarios y fechas desde el HTML; ODK: `datePublished`). |
| Correcciones | **24** |
| Quedan NO VERIFICADO | 8 afirmaciones (ver abajo) |

**Correcciones (antes → después):**

1. [12] RM573240: NO VERIFICADO → HECHO (página abierta; publicada 2026-10-06). [11] también lleva fecha de publicación 2026-10-06.
2. [13] SAP «App Update»: «sin fecha visible» → «Last update: July 20, 2026».
3. SAP MDK «clientes 26.x en 2026» (sin respaldo en [13]/[14]) → NO VERIFICADO.
4. Salesforce *priming* «best effort» atribuido a [18] → la frase no está en [18]; NO VERIFICADO (vendría de [19]).
5. Salesforce `MinimumAppVersion` presentado sin marca en §2 y §3.5 → NO VERIFICADO, y el extracto lo describe para la app Salesforce con Enhanced Mobile App Security, no para la app Field Service.
6. ServiceMax [27]: NO VERIFICADO → HECHO por espejo r24.2/r25.2; se agrega que el técnico debe reingresar para tomar la configuración.
7. ServiceMax [28]: NO VERIFICADO → HECHO en lo de sincronización bidireccional y Config/Data Sync; «sincronización completa al primer ingreso o al cambiar de usuario» queda NO VERIFICADO.
8. D365 FS: «sincroniza sólo con la app activa» → se agrega que, iniciada, puede terminar en segundo plano en Android/iOS [9].
9. §3.1 «casi todos agregan un ciclo periódico» → conteo explícito (7 de 8 filas).
10. §3.2 citas de [15]/[16] atribuidas al «cliente genérico» → son del cliente de tienda de SSAM.
11. §3.2 «orden de actualización que publica SAP» → no es orden: Cloud Connector y cliente se actualizan de forma independiente; dos versiones pueden correr en paralelo.
12. §3.2 «la versión vigente se consulta con *Get App Versions*» → la FAQ sólo remite ahí para que los usuarios reciban lo publicado sin re-envolver.
13. §3.3 SAP «postergar si está en medio de una transacción» citado a [13] → el ejemplo está en el tutorial [14].
14. §3.3 ODK: la frase «toda combinación formulario+versión» no está en la doc. [41]; es de LN en [43]. Se agrega la excepción «siempre se puede pasar a texto».
15. §3.4 tutoriales de extensiones SAP: NO VERIFICADO → HECHO; el cliente propio para mapas se pide en Android, en iOS el tutorial usa el cliente de tienda.
16. §3.4 «Lectura: las tres plataformas resuelven igual» → marcada **[criterio propio]** (Salesforce NO VERIFICADO; la FAQ de wrap no trata permisos).
17. §3.5 «todos son clientes publicados en Google Play y App Store» → sólo los que tienen fuente leída (SAP, Oracle, Power Apps wrap).
18. §3.5 «el forzado del contenido casi nunca es duro» → contradicho por [13]: sin `OnWillUpdate`, SAP aplica la versión nueva sin preguntar.
19. §3.5 «es la forma de no cortar el trabajo sin red» (ServiceMax) → marcada **[criterio propio]**.
20. §4 «Conté 15 opiniones» → las tablas tienen 16 filas en 9 referencias.
21. §4 [36] Tošovský: la frase citada no es suya, la cita del artículo de Redfin Engineering (Approach 1) → atribución corregida.
22. §4 [38] josephg: postura «las migraciones de capa base son lentas» → «los sistemas distribuidos migran lento; la capa base debe ser correcta», más fiel al comentario.
23. §5 P1 «ninguna baja código nativo nuevo» (sin fuente) → **[criterio propio]**. P3 «publicar un orden de actualización» → «poder correr dos versiones en paralelo» [15].
24. §5 P12 `isAvailable()` sin marca → NO VERIFICADO; fila «Forzado»: «nunca en medio de una transacción» pasa a ejemplo del tutorial [14], no regla general; P13 suma que la Config Sync de ServiceMax preserva lo pendiente [28].

Nota agregada sin cambiar la clasificación: [8] KA-24799 no dice si habla del reproductor web o del móvil, ni su fecha frente a la corrección de [7].

**Quedan NO VERIFICADO (8):** [17] hilo SAP MDK 23.4 y nota 3.0 SP01 (borrado de almacenes al cerrar sesión) — 403; [19] *priming* «best effort» — 403; [20] `isAvailable()` / `lightning/mobileCapabilities` — 403; [21] `MinimumAppVersion` y su alcance — 403; versión «26.x» del cliente MDK; ServiceMax «sincronización completa al primer ingreso o al cambiar de usuario»; el artículo de Redfin que cita Tošovský (no abierto); y los dos hilos ya marcados al final de §4 (comunidad Power Apps y Esri), que no se reintentaron.
