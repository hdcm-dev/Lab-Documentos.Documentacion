# Actuación 058: Dictamen final sobre la economía de datos OTA y las situaciones de uso con equipos compartidos

| Campo | Valor |
|---|---|
| Tipo | dictamen |
| Fecha | 2026-11-01 |
| Autor | Mesa de experiencia de usuario, flujo y datos |
| Sigue a | 054–057 |

Marcas que uso: **[NV]** no verificado en la fuente primaria; **[MEDIR]** pendiente de medir en el g42, en el servidor o en m4dev; **[OBS]** observado en una fuente pública; **[SUP]** supuesto que falta validar.

## Lo que planteó el PO

1. **Arranque y AOT.** Bajar el tiempo de arranque compilando el contenido con AOT, recortando el runtime y abriendo la base en paralelo es una mejora de rendimiento, no un cambio de la estrategia de actualización. El framework tiene que funcionar en Android y en iOS. iOS tiene restricciones, así que hay que probar en el emulador de iOS de m4dev, coordinando el turno con las sesiones de GDA.Core.APP y Runner Arc.
2. **Qué tipo de app es y qué se descarga.** Es una app híbrida: un cascarón .NET MAUI instalado desde la tienda o por MDM, y adentro un contenido Blazor WebAssembly que se actualiza por OTA, por fuera de la tienda. No es una OTA del sistema operativo. Lo que se descarga es un ZIP firmado de unos 3,8 MB (9,8 MB descomprimido) con el runtime Mono compilado a wasm, los ensamblados IL de la app en formato Webcil y el ICU. No es «un binario listo»: es IL que interpreta el runtime wasm dentro del WebView. En iOS, aunque el contenido se compile con AOT, sigue siendo **wasm** dentro de WKWebView y nunca código nativo descargado. Esa es la vía que admitiría la regla 4.7 de Apple **[NV]**.
3. **Economía de datos.** Investigar qué política recomiendan las plataformas y la industria.
4. **Caso de uso.** Inspectores y encuestadores llegan a la oficina, toman un móvil cualquiera del pool, se loguean (ahí se detecta la actualización) y salen a campo, muchas veces sin red. Hay dos variantes: el equipo se apaga cada noche, o queda prendido y al día siguiente se lo dan a otro empleado. No se puede depender de que el usuario cierre la sesión. El PO propuso que el bloqueo use el desbloqueo que tenga configurado el teléfono. Pidió estudiar qué hacen Mercado Pago, Mercado Libre y Nueva BNA, que instaló en el g42.

## Economía de datos: política propuesta

### Principios

1. El arranque no espera la red (P2).
2. Lo caro se paga en Wi-Fi y no en campo. La ventana preferida es la pantalla de login en la oficina.
3. Se baja lo que cambió y no todo, cuando la medición lo justifique.
4. Se respeta lo que pidieron el usuario o la organización: ahorro de datos, modo de datos bajos y MDM.

### Reglas (P-DATOS)

| # | Regla | Valor | Fase |
|---|---|---|---|
| D1 | Clases de red | **LIBRE**: `NET_CAPABILITY_NOT_METERED` en Android; en iOS, ni `isExpensive` ni `isConstrained`. **MEDIDA**: red celular o Wi-Fi compartido desde otro teléfono, sin restricción. **RESTRINGIDA**: ahorro de datos `ENABLED`, modo de datos bajos de iOS, roaming (sin `NOT_ROAMING`) o MDM `soloWifi`. **SIN RED**. Necesita código de plataforma, porque `Connectivity` de MAUI no informa si la red es medida. | 1 |
| D2 | Consulta del canal | Siempre y en cualquier red. Es un JSON firmado de menos de 2 KB, con `ETag` y respuesta 304 si no cambió. Lleva `emitido` y `expira` (24 h): una respuesta vencida no vale como «no hay nada nuevo». Al arrancar se le suma un jitter de ±30 s. | 1 |
| D3 | Cuándo se consulta | Al arrancar en frío (sin bloquear), al volver al frente después de 15 min, **cuando aparece la pantalla de login** y cuando vuelve la red. | 1 |
| D4 | Consulta en el login | En paralelo con la autenticación, con una espera adicional de **2 s** como máximo. | 1 |
| D5 | Activación | Si hay una versión verificada en staging, se activa en el **arranque en frío** o **al mostrarse el formulario de login, antes de que el usuario escriba las credenciales**. Nunca se recarga con trabajo en curso. | 1 |
| D6 | Opcional en LIBRE | Se baja dentro del proceso, con la app al frente. En el login se baja solo si `tamaño / throughput medido ≤ 8 s`, con un botón «Seguir sin actualizar» visible desde el segundo 2. | 1 |
| D7 | Opcional en MEDIDA | Solo si pesa ≤ `maxDeltaCelularBytes` (1 MB, configurable por canal). En BYOD, solo en LIBRE. | 1 |
| D8 | Opcional en RESTRINGIDA | No se baja. | 1 |
| D9 | Obligatoria | Se baja en cualquier red. **Bloquea solo el login de una sesión nueva, nunca una sesión vigente.** En el pool no se le pide confirmación al encuestador, porque los datos los paga la organización: en RESTRINGIDA se ve una línea informativa. En BYOD se avisa el tamaño real con «Descargar ahora / Esperar Wi-Fi». | 1 |
| D10 | Envíos rechazados por versión | El envío del outbox queda retenido, no se pierde, con el aviso «Se enviará cuando actualices». | 1 |
| D11 | Verificación | Tamaño, sha256 y firma sobre el archivo completo. El manifiesto lleva un `contentVersion` que solo crece y un piso `minVersionSegura` para que no se pueda bajar de versión. El rollback solo vuelve a la versión instalada antes. | 1 |
| D12 | Clave de firma | Fuera de línea o en un HSM, nunca en la CI común. La clave pública va fija en el cascarón, con una de reemplazo ya incluida. Rotarla exige publicar un cascarón nuevo. | 1 |
| D13 | Retención | Una sola versión candidata en staging. La anterior se conserva hasta **2 cargas y 24 h**, lo que ocurra último. Para lo opcional se exigen **50 MB libres**. Nunca se borra el outbox para hacer lugar. | 1 |
| D14 | Batería | Sin carga y por debajo del 20 % no se baja lo opcional (`Battery` de MAUI). En el pool, la obligatoria se pospone al login. | 1 |
| D15 | Reintentos | Backoff exponencial de 1 min a 6 h, con jitter completo. | 1 |
| D16 | Telemetría | Va por una cola técnica aparte, sin identificar al usuario: id seudónimo del equipo, versión, bytes por clase de red, si fue delta o completo, reanudaciones, y la **versión con la que el equipo sale a campo** (la del primer envío del día). | 1 |
| D17 | Delta por manifiesto de hashes | Manifiesto propio, comparado por sha256 y no derivado de `blazor.boot.json`, porque el fingerprinting de .NET 9+ cambia los nombres. Los archivos copiados del área activa se vuelven a verificar. Si el delta supera el 50–60 % del ZIP, se baja el ZIP completo. **Depende de la medición con y sin AOT**: con AOT, el código queda dentro de `dotnet.native.wasm` y el delta pierde casi todo su valor. | 2 |
| D18 | Versiones separadas `runtimeVersion` / `contentVersion` | Descartadas por ahora. Solo valen sin relink ni AOT, y en ese caso se calculan por hash, no se declaran a mano. | 2 |
| D19 | Transporte comprimido | `.br` servido como blob opaco (`application/octet-stream`, sin `Content-Encoding`) y descomprimido en el cliente. | 2 |
| D20 | Reanudación | `Range` + `If-Range` (ETag) para archivos de 1 MB o más. Lo parcial queda en el almacenamiento privado. Si el servidor contesta 200 en lugar de 206, se reinicia la descarga sin error. | 2 |
| D21 | Descarga de fondo | WorkManager (`UNMETERED`, batería no baja) y `URLSession` de fondo discrecional. Se activa si más del 20 % de los equipos sale a campo con la versión vieja. | 2 |
| D22 | MDM | Respetar el `wifiOnly` de la tienda y leer una configuración administrada `soloWifi` y `modoPool` **[NV en MAUI]**. | 2 |
| — | Presupuesto diario de datos medidos | **Descartado.** Una sola descarga completa lo agota, y D7 ya limita el gasto. Queda solo la telemetría. | — |

### Fuentes de esta sección

- Android, ahorro de datos y red medida: https://developer.android.com/develop/connectivity/network-ops/data-saver. WorkManager y `NET_CAPABILITY_NOT_METERED` son conocidos **[NV]**.
- iOS, `allowsExpensiveNetworkAccess` y `allowsConstrainedNetworkAccess`: https://developer.apple.com/documentation/foundation/urlsessionconfiguration/allowsexpensivenetworkaccess y https://www.hackingwithswift.com/example-code/networking/how-to-support-low-data-mode-networking-using-allowsconstrainednetworkaccess
- Expo, diff de bundles: https://docs.expo.dev/eas-update/bundle-diffing/ y https://expo.dev/blog/ship-smaller-ota-updates-bundle-diffing-comes-to-ota-updates-in-sdk-55
- Delta por manifiesto: https://capawesome.io/docs/cloud/live-updates/advanced/delta-updates/ y https://capgo.app/docs/live-updates/differentials/
- MDM: https://googleapis.dev/ruby/google-api-client/v0.37.1/Google/Apis/AndroidenterpriseV1/Policy.html y https://docs.citrix.com/en-us/citrix-endpoint-management/policies/app-auto-update-policy.html
- `Range` / 206: RFC 9110 §14.

## Situaciones de uso

### Modelo de sesión

| Concepto | Pool (equipo compartido) | BYOD (teléfono personal) |
|---|---|---|
| Sesión de jornada | Vence a las N horas desde el login (**10 h** por defecto en el pool) o a una hora de corte configurable, lo que ocurra primero. No vence por cambio de fecha, para no romper los turnos nocturnos. | Vigencia configurable, más larga. |
| Bloqueo local | Al volver de segundo plano o por inactividad, **10 min** por defecto (configurable). | 5 min. |
| Retomar la propia sesión | **PIN de la app, personal, de 6 dígitos.** Se crea en el login en línea y destraba una clave del Keystore. A los 5 errores se pide login con red. Biometría prohibida. | **Desbloqueo del teléfono** (patrón, PIN o biometría), como pidió el PO. Si el equipo no tiene bloqueo configurado (`isDeviceSecure()` en false), no se ofrece. |
| Cambio de usuario | Login completo con formulario y con red. | Igual. |
| Token de envío | Alcance solo POST al outbox y solo para los ítems ya encolados de ese usuario. Atado al equipo (clave del Keystore, tipo DPoP), con **72 h** de vida, revocable y borrado cuando el outbox queda vacío. No permite leer datos ni renovar la sesión. | Igual. |

**Apartamiento de lo que propuso el PO.** En el pool, el patrón del equipo lo conoce todo el personal: Beto podría tocar «Desbloquear» en lugar de «¿No sos Ana?» y entrar a la sesión de Ana. Dos de los tres jurados rechazaron el desbloqueo del teléfono para el pool, y el tercero pidió el PIN de la app como opción. Por eso la mesa lo restringe a BYOD y **lo eleva al PO**.

### Catálogo

| # | Situación | Comportamiento | Por qué |
|---|---|---|---|
| S1 | Ana entrega el equipo y Beto lo recibe | Beto ve «Sesión de Ana P.» y toca «¿No sos Ana?». Se hace login con red. **Antes** de mostrar el inicio de Beto se limpian las cookies del WebView, localStorage, Cache Storage, el service worker, las bases IndexedDB nombradas por usuario, las notificaciones y el portapapeles. El outbox de Ana queda cifrado con su clave y se envía con su token. Un formulario a medio cargar queda como **borrador aislado de Ana**. | Ocultar no es aislar. Los datos de las personas encuestadas no se pueden volver a pedir. |
| S2 | El equipo se apaga cada noche | Al día siguiente hay arranque en frío: se activa lo que esté en staging, la jornada ya venció por las N horas y se pide login. | El arranque en frío es el momento natural. No hace falta código de cierre. |
| S3 | El equipo queda prendido con la app abierta | Al volver al frente se evalúa la jornada. Si venció, va al login, y en la pantalla de login se activa lo que haya en staging. `FLAG_SECURE` en Android y una tapa en iOS evitan que la miniatura de recientes muestre datos. | Android casi nunca mata el proceso. |
| S4 | El usuario desliza la app de recientes | No se toma como señal de nada. En el próximo arranque, si la sesión sigue vigente, se pide el PIN de la app (pool) o el desbloqueo del teléfono (BYOD). Si venció, login. **[MEDIR] g42** | `onDestroy` no está garantizado, y MIUI hace force stop. |
| S5 | Cerrar sesión con pendientes | Mensaje: «Tenés 3 envíos pendientes. Se mandan solos cuando haya red; no se muestran a otros usuarios de esta app.». Si llevan más de 3 días, se avisa al supervisor. El supervisor ve los rechazos de Ana. Nunca se borran en silencio. | Patrón de SafetyCulture, sin la fuga de Survey123. |
| S6 | Primer login del día con versión nueva | Si ya está en staging, se activa al mostrarse el formulario. Si no, en LIBRE se baja si entra en 8 s y, si no, en segundo plano. La obligatoria se espera con progreso. | El login con Wi-Fi en la oficina es la ventana barata. |
| S7 | Sin red al salir a campo | Arranca con lo instalado. Se retoma solo la sesión vigente del mismo usuario (con PIN o desbloqueo). Un usuario nuevo ve «Necesitás conexión para iniciar sesión; probá con el Wi-Fi de la oficina». Lo que carga va al outbox. | No se puede identificar a alguien nuevo sin red. |
| S8 | Red móvil | Opcional solo si pesa ≤ 1 MB. Obligatoria sin preguntar en el pool. La consulta del canal sigue (304). | Política D7 y D9. |
| S9 | Obligatoria detectada en campo | No se corta la jornada. Se aplica en el próximo login o arranque en frío. Los envíos rechazados quedan retenidos. | La obligatoria nunca bloquea una sesión vigente. |
| S10 | Descarga cortada | La versión activa nunca se toca. Fase 1: se reintenta desde cero. Fase 2: se reanuda con `Range`. Si una versión nueva arranca mal, rollback. | Staging separado. |
| S11 | Batería baja | Lo opcional se suspende. En el pool, la obligatoria se pospone al login. | D14. |
| S12 | BYOD | Un solo usuario y desbloqueo del teléfono. Solo LIBRE. Cifrado y borrado al cerrar sesión **iguales** que en el pool. | En el teléfono conviven otras apps. |
| S13 | Equipo perdido o entregado sin cerrar sesión | Cierre de sesión remoto y borrado remoto, que viajan en la consulta firmada. Antes del borrado, lo pendiente se exporta al servidor si hay red. Se revocan los tokens. Una sola sesión por usuario, pero entrar en otro equipo cierra la anterior y no revoca su token de envío. | Precedentes de Mercado Pago y del BCRA A 7325 **[NV]**. El vencimiento de la jornada protege aunque el equipo no vuelva a conectarse. |
| S14 | Poco espacio | Por debajo de 50 MB no se baja lo opcional. Primero se protege el outbox. | D13. |
| S15 | Reinicio o hora alterada | Si `elapsedRealtime` es menor que el guardado o cambió `BOOT_COUNT`, hubo reinicio. Entonces se exige retomar con PIN o desbloqueo y se valida la hora: tiene que ser mayor o igual que la última hora del servidor y menor que esa hora más 10 h. Si no cumple, se pasa a **modo solo carga** (al outbox del mismo usuario) hasta tener red. | Así no se deja trabado todo el día a un encuestador cuyo teléfono se quedó sin batería en campo. |
| S16 | Equipo en carga toda la noche con la app abierta | La jornada vence por las N horas. El siguiente que lo toma ve el login, no el bloqueo de Ana. | Vencimiento por horas. |
| S17 | Dos encuestadores intercambian equipos en campo, sin red | No se permite: «Iniciá sesión en tu equipo o con red». | No hay identidad sin red. |

### Flujos

```
ARRANQUE EN FRÍO
  ¿staging verificado? ─sí─► activar ─┐
        │no                           ▼
        └──────────────► cargar activa   (en paralelo: consulta, sin esperar)
                              │
             ¿sesión? ─no / vencida─► LOGIN
                     └─vigente──────► BLOQUEO (PIN app | teléfono en BYOD)
                                        └─ «¿No sos X?» ─► LOGIN
```

```
PANTALLA DE LOGIN
  aparece formulario ─► ¿staging listo? ─sí─► recarga limpia (sin credenciales aún)
        ▼
  credenciales ─► autenticación ∥ consulta (≤2 s extra)
     ├─ nada / opcional MEDIDA/RESTR ──────────────► INICIO (programar)
     ├─ opcional LIBRE ─ ¿entra en 8 s? ─sí─► bajar ─► recarga ─► INICIO
     │                                   └no──► INICIO (sigue al frente)
     └─ OBLIGATORIA ─► bajar con progreso ─► INICIO
                       (BYOD MEDIDA/RESTR: aviso de tamaño · «Esperar Wi-Fi» = sin sesión nueva)
```

```
VUELTA AL FRENTE
  ¿jornada vencida? ─sí─► LOGIN
  ¿> 10 min (pool) / 5 min (BYOD)? ─sí─► BLOQUEO
  ¿> 15 min? ─sí─► consulta sin bloquear
  ¿versión lista y momento tranquilo? ─► «La versión X está lista · Reiniciar ahora / Más tarde»
```

## Lo que hacen las apps de referencia

| Tema | Mercado Pago | Mercado Libre | BNA+ | Marca |
|---|---|---|---|---|
| Arranque | El equipo de Performance ordenó por prioridad las inicializaciones obligatorias: mejora del p90 de hasta 24 % | Hasta 16 % | — | **[NV]** (resumen del artículo, que devolvió 403) |
| Bloqueo propio de la app | El blog recomienda un bloqueo independiente del teléfono | — | Biometría opcional desde el menú | **[OBS]** |
| Nuevo login tras un bloqueo preventivo | Reconocimiento facial validado en el servidor | — | Hay reclamos de usuarios trabados en la biometría | **[OBS]** / **[NV]** |
| Tiempo de bloqueo al volver de segundo plano | Sin documentación pública | Sin documentación pública | Sin documentación pública | **[SUP]**: las bancarias piden algo, Mercado Libre casi nunca |
| Sesiones y dispositivos | «Dispositivos conectados» o «Central de seguridad», con cierre remoto | — | — | **[OBS]** |
| Actualización | In-app update de Play más versión mínima | Server Driven UI: la pantalla cambia sin pasar por la tienda | Reemplazo por una app nueva, con migración por turnos | **[SUP]** / **[OBS]** / **[OBS]** |
| Sin conexión | Pantalla «sin conexión», quizá con algo en caché | — | Casi no sirve sin red | **[SUP]** |

**Lectura.** Estas apps suponen un usuario por teléfono, así que **no sirven de modelo para el pool ni para el trabajo offline-first con outbox**. Para eso valen Microsoft Entra en modo de dispositivo compartido (cambio de usuario detectado al volver al frente, la app limpia sus propios datos), Managed Home Screen (PIN de sesión y cierre por inactividad con aviso), SafetyCulture (aviso de pendientes al cerrar sesión) y Field Maps (datos aislados por cuenta). De las bancarias se toman el bloqueo propio, el cierre remoto y una sesión por usuario. De Mercado Libre, el arranque con pocas tareas núcleo y lo que se aplica en el próximo arranque.

### Plan de estudio en el g42

**Reglas del estudio:**
- No se inicia sesión en las cuentas del PO.
- No se tocan sus datos, su configuración de seguridad ni sus apps de producción.
- Solo se observa lo que se ve antes del login, o con la sesión que ya esté abierta, sin operar.
- Capturas sin datos personales.
- Acceso por adb remoto, sin desinstalar ni borrar datos de ninguna app.

| # | Qué observar o medir | Cómo | Apps |
|---|---|---|---|
| E1 | Tiempo de arranque en frío y en caliente, y duración del splash | `am start -W` (TotalTime) después de `am force-stop`; 5 corridas; mediana | Mercado Pago, Mercado Libre, BNA+ |
| E2 | Qué muestra la pantalla de login o de bienvenida: métodos (usuario, QR, biometría) y mensajes | Captura; sin escribir nada | las tres |
| E3 | Bloqueo al volver de segundo plano | Cronómetro con 0, 1, 5 y 15 min en segundo plano; anotar si pide algo y qué. Solo si ya hay una sesión abierta, sin desbloquearla. | las tres |
| E4 | Qué pasa al deslizar la app de recientes | Comprobar si el proceso sigue vivo con `pidof` y qué se ve al reabrir | las tres y nuestra demo |
| E5 | Avisos de actualización | Ver si aparece la pantalla de Play, una pantalla propia o nada; revisar la versión instalada con `dumpsys package` | las tres |
| E6 | Modo avión | Qué se ve al abrir sin red y si hay algo en caché | las tres |
| E7 | Datos consumidos en un arranque | `dumpsys netstats` por UID, antes y después | las tres |
| E8 | Si la miniatura de recientes está tapada (`FLAG_SECURE`) | Captura de recientes | las tres y nuestra demo |
| E9 | `BOOT_COUNT` y comportamiento después de reiniciar | Solo con nuestra demo | demo |

## Qué cambia en la norma y en la demo

**Norma (guía del Framework Concept):**
- Agregar P-DATOS con las reglas D1 a D16 como fase 1 y D17 a D22 como fase 2 condicionada.
- Corregir la redacción de la obligatoria: «bloquea solo el login de una sesión nueva».
- La activación pasa al arranque en frío **y a la pantalla de login antes de las credenciales**.
- Agregar el modelo de sesión pool/BYOD, la jornada por horas y «¿No sos X?».
- Agregar outbox por usuario cifrado, el token de envío, la protección contra bajar de versión (`contentVersion` creciente y `minVersionSegura`), la vigencia del JSON del canal y la custodia de la clave de firma.
- Agregar el catálogo S1–S17.
- Aclarar la cuestión del AOT: compilar el contenido a wasm es compatible con iOS, pero puede anular el delta.

**Demo:**
- Clases de red con código de plataforma.
- Consulta en paralelo con el login, más la activación en el formulario.
- Descarga con tope de 8 s.
- Bases IndexedDB nombradas por usuario y limpieza al cambiar de usuario.
- Pantalla de bloqueo con «¿No sos X?» y PIN de la app detrás de `modoPool`.
- `FLAG_SECURE`.
- Detección de reinicio.
- Telemetría de bytes y de la versión con que el equipo sale a campo.

**Mediciones:**
- Delta real con y sin AOT, y con `WasmNativeRelink=false`.
- Si el servidor responde 206.
- Las mediciones E1–E9 del g42.

**iOS en m4dev**, cuando las sesiones de GDA.Core.APP y Runner Arc cedan el turno:
- WKWebView con el contenido wasm servido por `WKURLSchemeHandler`.
- Modo de datos bajos.
- `URLSession` de fondo.

## Lo que decide el PO

- En el pool, el patrón del teléfono lo sabe todo el personal. ¿Aceptás que para retomar la sesión se use un PIN propio de la app y que el desbloqueo del teléfono quede para teléfonos personales?
- Hoy, ¿los equipos del pool tienen algún bloqueo configurado? ¿Quién lo conoce?
- ¿La jornada vence a las 10 h desde el login o a una hora de corte fija? ¿Hay turnos que cruzan la medianoche?
- ¿El bloqueo en el pool a los 10 min te parece bien, o preferís 5 como hoy?
- ¿Te sirve que la versión nueva se active al aparecer la pantalla de login, antes de escribir la clave?
- ¿Alcanza con un tope de 8 s para bajar en el login, con el botón «Seguir sin actualizar»?
- En el pool, ¿los datos móviles los paga la organización? ¿Puede la obligatoria bajar sin preguntarle al encuestador?
- ¿Querés un nivel que, ante una falla grave, frene también la carga local y no solo los envíos?
- ¿Priorizamos el AOT para el arranque aunque cada versión pese el ZIP completo, o primero medimos el delta?
- ¿Aceptás un token de envío de 72 h, atado al equipo, para que los pendientes de Ana salgan aunque ella ya no tenga el equipo?
- ¿Hay MDM en los equipos del pool, o la configuración llega solo por el canal?

## Fuentes

- https://developer.android.com/develop/connectivity/network-ops/data-saver
- https://developer.android.com/guide/components/activities/process-lifecycle
- https://developer.android.com/guide/components/activities/recents
- https://developer.apple.com/documentation/foundation/urlsessionconfiguration/allowsexpensivenetworkaccess
- https://www.hackingwithswift.com/example-code/networking/how-to-support-low-data-mode-networking-using-allowsconstrainednetworkaccess
- https://docs.expo.dev/eas-update/bundle-diffing/
- https://expo.dev/blog/ship-smaller-ota-updates-bundle-diffing-comes-to-ota-updates-in-sdk-55
- https://capawesome.io/docs/cloud/live-updates/advanced/delta-updates/
- https://capgo.app/docs/live-updates/differentials/
- https://googleapis.dev/ruby/google-api-client/v0.37.1/Google/Apis/AndroidenterpriseV1/Policy.html
- https://docs.citrix.com/en-us/citrix-endpoint-management/policies/app-auto-update-policy.html
- https://help.swif.ai/en/articles/12568890-introducing-the-android-software-update-policy
- https://learn.microsoft.com/en-us/entra/msal/android/shared-devices
- https://techcommunity.microsoft.com/blog/intunecustomersuccess/updates-to-the-managed-home-screen-experience/3974412
- https://community.esri.com/t5/arcgis-survey123-questions/problems-using-survey123-on-a-shared-device/m-p/1102054
- https://doc.arcgis.com/en/survey123/get-started/faqgetanswers.htm
- https://support.esri.com/en-us/bug/when-deleting-an-offline-area-in-arcgis-field-maps-the-bug-000171917
- https://help.safetyculture.com/en-US/000034/
- https://docs.getodk.org/collect-filling-forms/
- https://medium.com/mercadolibre-tech/how-we-improved-our-android-apps-performance-by-up-to-24-6799d7056ed1 **[NV]**
- https://medium.com/turo-engineering/how-we-reduced-our-android-startup-time-by-77-650cc113c3dc
- https://medium.com/crunchyroll/mobile-feature-flags-remote-configuration-and-a-b-tests-at-crunchyroll-5077d73152ca
- https://www.mercadopago.com.mx/blog/proteger-apps-financieras-perder-celular
- https://www.mercadopago.com.mx/blog/reportar-bloquear-cuenta-digital-otro-dispositivo
- https://bna.com.ar/Personas/BNAMas/PreguntasFrecuentesBNAmas
- https://www.bna.com.ar/Personas/nuevabnamas
- https://www.bcra.gob.ar/archivos/Pdfs/comytexord/A7325.pdf **[NV en el texto]**
- https://www.thoughtworks.com/es-es/radar/techniques/server-driven-ui
- RFC 9110 §14 (pedidos por rango)