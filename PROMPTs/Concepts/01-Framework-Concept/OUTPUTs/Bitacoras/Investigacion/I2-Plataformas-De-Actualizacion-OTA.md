| Campo | Valor |
| --- | --- |
| Tipo | dossier de investigación (ángulo I2) |
| Fecha | 2026-10-25 (fecha de consulta de todas las fuentes) |
| Autor | Investigador I2 |
| Expediente | 0001-Framework-Concept-Maui-Autoactualizable |
| Pedido | PO, 2026-10-25: «investigar qué se está usando en la industria … ver qué opiniones hay de desarrolladores» |

# I2 — Plataformas de actualización over-the-air (OTA) para apps híbridas y JS

## Índice

1. Alcance del ángulo
2. Qué se usa (tabla de productos y patrones)
3. Cómo resuelven lo específico
   - 3.1 Momento de actualización
   - 3.2 Versionado de lo descargado y compatibilidad con la app instalada
   - 3.3 Datos tomados con una versión vieja
   - 3.4 Permisos y capacidades fijados por el manifiesto
   - 3.5 Firma e integridad
   - 3.6 Rollback
   - 3.7 Rechazos y advertencias de las tiendas
   - 3.8 ¿Existe algo equivalente para .NET MAUI?
4. Opiniones de desarrolladores
5. Lecciones aplicables a P1–P13
6. Fuentes numeradas

Convenciones: **HECHO** = documentación oficial, anuncio del proveedor o código. **OPINIÓN** = foros, issues, blogs,
comentarios; señal cualitativa, no estadística. **NO VERIFICADO** = no se pudo confirmar, con el motivo.
**[criterio propio]** = inferencia del investigador, no de la fuente. Las referencias `[n]` remiten a §6.
Las citas de proveedores sobre sí mismos (Capgo, Capawesome, Bitrise, Revopush, Shorebird) son HECHO en cuanto a lo
que el producto declara hacer, y material interesado en cuanto a comparaciones y cumplimiento de tiendas.

---

## 1. Alcance del ángulo

Plataformas comerciales y libres que actualizan la capa interpretada (JS/HTML/CSS, o Dart en Shorebird) de una app
móvil sin pasar por la tienda: Expo EAS Update, el retiro de Microsoft App Center/CodePush y sus sucesores, las
Live Updates de Capacitor (Ionic Appflow, Capgo, Capawesome), Shorebird para Flutter y la búsqueda de un equivalente
para .NET MAUI. Para cada uno se relevó qué actualiza, cómo se ata a la versión nativa, rollback, firma,
actualización forzada y casos de rechazo de Apple/Google. Queda fuera: las colas de sincronización de datos
(ángulos de offline), el In-App Updates de Play para el cascarón (lo trata la comisión del folio 006) y la UI por
datos (server-driven UI).

## 2. Qué se usa

| Nombre | Qué actualiza sin tienda | Cómo trabaja sin red | Cómo fuerza o programa la actualización | Versión / estado vigente (2026-10-25) | Fuente |
| --- | --- | --- | --- | --- | --- |
| **Expo EAS Update** (`expo-updates`) | Sólo el bundle JS y los assets; el build contiene «some native code that cannot be changed with an update» [1] | Arranca con el último update descargado o con el embebido en el build; `fallbackToCacheTimeout` (0 por defecto, máx. 300000 ms) es cuánto espera al iniciar antes de usar la caché | `checkAutomatically`: `ON_LOAD` (defecto), `ON_ERROR_RECOVERY`, `WIFI_ONLY`, `NEVER`; API `checkForUpdateAsync`/`fetchUpdateAsync`/`reloadAsync`; descarga en segundo plano con `expo-background-task`. Actualización crítica: «no first-class support», se arma a mano | Activo; protocolo abierto (Expo Updates v1) para servidor propio | [1][2][3][4][5][6] |
| **Microsoft App Center CodePush** | JS/assets de React Native y Cordova | Bundle instalado o el del binario | `mandatoryInstallMode` (IMMEDIATE por defecto para obligatorias), `ON_NEXT_RESTART`, `ON_NEXT_RESUME`, `minimumBackgroundDuration` | **Retirado el 2025-03-31**; repos `react-native-code-push` y `code-push-server` archivados el 2025-05-20; `cordova-plugin-code-push` archivado el 2022-10-12 | [7][8][9][10][11] |
| **code-push-server** (standalone de Microsoft) | Lo mismo que CodePush, alojado por uno | Igual | Igual | Publicado «as is», sin soporte, archivado (MIT, forkeable) | [7][9] |
| **Bitrise CodePush** | JS de React Native/Expo | NO VERIFICADO (no documentado en la fuente leída) | Compatible con el modelo CodePush (fork) | Activo; gratis hasta 100.000 MAU con plan Bitrise (dicho por el proveedor) | [12] |
| **Revopush** | JS de React Native; SDK «CodePush-compatible» | NO VERIFICADO | NO VERIFICADO (la página no trata rollback, obligatorias ni firma) | Activo; página actualizada 2026-08-23 | [13] |
| **Otros sucesores RN** (AppZung, AppsOnAir, Appcircle, Stallion, Codemagic CodePush, hot-updater, xprem) | JS de React Native | NO VERIFICADO | NO VERIFICADO | Existen según la comparativa de Bitrise del 2026-10-06; sólo se verificó el repo de **hot-updater** (self-hosted, adaptadores de almacenamiento y firma) | [12][14] |
| **Ionic Appflow Live Updates** | HTML, CSS y JS («binary compatible changes») | NO VERIFICADO en la fuente | NO VERIFICADO en la fuente leída | Sin ventas a clientes nuevos desde 2025-02-11; acceso hasta **2027-12-31** | [15][16][17] |
| **Capgo** (`@capgo/capacitor-updater`) | Capa web («JavaScript bundle changes»); «does not download or install native executable code» | No tratado en [18]; el README del plugin dice que `setChannel()` «now stores channel assignments locally on the device instead of in the cloud. This provides better offline support» [21] | `autoUpdate`: `atBackground` (defecto), `atInstall`, `onLaunch`, `always`, `onlyDownload`; demoras combinables `date`, `background`, `nativeVersion`, `kill` | Activo; plugin MPL-2.0, backend auto-alojable, Capacitor 8 | [18][19][20][21] |
| **Capawesome Cloud Live Updates** | «only modifies the web layer (HTML, CSS, JavaScript, and assets)» | Descarga en segundo plano, aplica al próximo inicio; offline no tratado | Estrategias «background, always-latest, or a fully custom strategy»; restricción por versionCode mín./máx./equivalente | Activo; se presenta como reemplazo recomendado de Appflow (afirmación del proveedor) | [22][23][24] |
| **Shorebird** (Flutter) | Código Dart; **no** assets, **no** código nativo, **no** cambio de motor Flutter | Corre la última patch válida o la release base | Por defecto revisa en un hilo de fondo al iniciar y aplica en el siguiente inicio; `auto_update: false` + `shorebird_code_push` para controlarlo; para forzar: «check for updates as part of a login screen, or other launch gate» | Activo; requiere Flutter ≥ 3.27.0 (el rollback, ≥ 3.27.4 [29]) | [25][26][27][28][29] |
| **.NET MAUI** | **No se encontró** un producto OTA de contenido para MAUI/Blazor Hybrid (ver §3.8) | — | Hay paquetes para el cascarón: In-App Updates de Play (`Oscore.Maui.Android.InAppUpdates`), aviso de versión de tienda (`Plugin.Maui.LatestVersion`), instalador de APK (`GeneralUpdate.Maui`) | — | [30][31] |

## 3. Cómo resuelven lo específico

### 3.1 Momento de actualización

- **Al abrir, sin bloquear (comportamiento por defecto en 3 de los 4 productos con docs leídas sobre el momento: Expo, Shorebird y, aplicando al pasar a segundo plano, Capgo; Capawesome aplica al próximo inicio).** Expo revisa en el arranque en frío y
  «does not block loading the app», de modo que el usuario ve la versión nueva en un arranque posterior [3]. Shorebird
  igual: hilo de fondo al iniciar, efecto en el próximo inicio; «the patch cannot be hot-swapped into memory
  dynamically on that launch» [26][27]. Capgo por defecto aplica cuando la app pasa a segundo plano [20].
- **Al abrir, esperando un tiempo acotado.** Expo `fallbackToCacheTimeout`: espera hasta N ms (máx. 5 min) a que
  llegue el update antes de arrancar con la caché; si tarda más, lo descargado se aplica en el siguiente inicio [2].
  Capgo `onLaunch` aplica inmediatamente en arranque en frío, con splash retenido si `launchAutoHide: false`;
  `atInstall` aplica inmediato sólo tras una instalación nueva o una actualización de tienda, y si no se comporta
  como `atBackground` [20].
- **Segundo plano.** Expo con `expo-background-task` (descarga segura; recargar en segundo plano es
  «experimental») [3]. Capawesome «download silently while the app is in use» [22].
- **Al iniciar sesión.** Shorebird lo propone textualmente como forma de forzar: «check for updates as part of a
  login screen, or other launch gate» [27]. Es el mismo patrón que el PO describe en el folio 004.
- **Forzado.** CodePush tenía el concepto nativo de update *mandatory* con `IMMEDIATE` y diálogo que el usuario no
  puede ignorar [11]. Expo no tiene «first-class support» para críticas; se arma con la API [3]. Capgo `always`
  aplica aun en uso activo [20]. Shorebird: sólo con la API desde la app [27].
- **Límite práctico (OPINIÓN de un equipo en producción).** Kikoff: «Code push adoption ≈ user cold-start
  frequency. That's the floor.» [32].

### 3.2 Versionado de lo descargado y compatibilidad con la app instalada

- **Expo:** `runtimeVersion` es la propiedad que «guarantees compatibility between a build's native code and an
  update»; políticas `appVersion` (riesgo de desajuste si no se sube la versión) y `fingerprint` (cambia ante
  cualquier cambio que afecte lo nativo; más builds) [1]. El protocolo exige que el cliente envíe
  `expo-runtime-version` y el servidor responda el update más reciente para ese runtime [5].
- **Capgo:** canales, bloqueo de saltos de versión mayor, flag `--fail-on-incompatible`, y demora `nativeVersion`
  (no aplica hasta que el binario instalado sea ≥ cierta versión) [18][20].
- **Capawesome:** canales versionados y restricciones de versionCode mínimo, máximo y equivalente (`--android-eq`)
  [23][24].
- **Appflow:** sólo cambios «binary compatible»; sumar o quitar un plugin exige binario nuevo [17].
- **CodePush:** cada update apunta a una versión del binario y el cliente ignora los que no coinciden: «we ignore
  updates having binary version mismatch (because the update is not targeting to the binary version of currently
  installed app)»; `handleBinaryVersionMismatchCallback` permite avisar al usuario [11]. (El nombre de opción
  `targetBinaryVersion` sigue NO VERIFICADO: no figura en [11].)
- **Shorebird:** las patches se emiten contra una release concreta; chequea automáticamente cambios nativos y de
  assets antes de crear la patch [25].
- **Falla documentada (OPINIÓN):** un issue de GitHub (tommyshellberg, 2026-08-06) describe que `eas update` empaqueta desde el árbol local y no
  desde el commit, un bundle llegó a un binario con otra capa nativa y el dispositivo cayó al embebido; propone un
  chequeo de compatibilidad antes de publicar [33].

### 3.3 Datos tomados con una versión vieja

Ninguna de las plataformas leídas trata la compatibilidad de **datos** creados con una versión anterior del
contenido. La única mención es una advertencia de Expo: el rollback automático no se hace si el contenido ya se
mostró, porque «this can be dangerous if your new update has modified persistent state in a non-backwards
compatible way»; la misma página pone de ejemplo «data stored in AsyncStorage or on the device's file system» [6]. **[criterio propio]** Es un hueco de la industria OTA, no una solución: P13 (encuestas tomadas con la
definición vieja) tiene que resolverse en la capa de datos del framework (versión de la definición dentro de cada
respuesta), no en el canal de actualización.

### 3.4 Permisos y capacidades fijados por el manifiesto

Las cinco plataformas cuya documentación se leyó declaran el mismo límite: lo nativo (plugins, configuración del proyecto Android/iOS, y por
extensión los permisos) sólo cambia con un binario por la tienda — Expo [1], Appflow [17], Capgo [18][21],
Capawesome [22], Shorebird [25]. Kikoff lo resume: «if your change is in `lib/`, it's patchable. If it's in `ios/` or
`android/`, it isn't.» [32]. Ninguna documenta un mecanismo de descubrimiento de capacidades por el contenido; el
mecanismo de defensa que documentan es de versión (runtimeVersion, versionCode, nativeVersion). **[criterio propio]**
Para P12 eso sugiere atar el contenido a una «versión de puente/capacidades» del cascarón, al estilo de
`runtimeVersion`, y no sólo a la versión de la app.

Apple, guía 4.7.2 (para software no embebido como «HTML5 and JavaScript mini apps»): «Your app may not extend or
expose native platform APIs or technologies to the software without prior permission from Apple.» [34]. **[criterio
propio]** La 4.7 apunta a mini apps ofrecidas dentro de una app; si alcanza al contenido propio del mismo
desarrollador que usa el puente HybridWebView es NO VERIFICADO (ninguna fuente leída lo aplica a ese caso).

### 3.5 Firma e integridad

| Producto | Firma | Fuente |
| --- | --- | --- |
| Expo | Certificado X.509 embebido; RSA PKCS#1 v1.5 + SHA-256 (`rsa-v1_5-sha256`); el cliente verifica antes de aplicar; sólo planes Production/Enterprise de EAS (en servidor propio el protocolo lo prevé con `expo-expect-signature`/`expo-signature`) | [2][5][35] |
| Shorebird | Opcional; clave pública RSA embebida en la release; patch sin firma válida se rechaza al arrancar y cae a la última verificada | [28] |
| Capawesome | RSA 2048/3072/4096; canales protegidos que sólo aceptan bundles firmados; en todos los planes | [22][24] |
| Capgo | Cifrado híbrido RSA+AES con checksum firmado; la propia página es inconsistente sobre los algoritmos (RSA-2048/AES-128-CBC vs RSA-4096/AES-256-GCM) | [36] |
| CodePush | NO VERIFICADO (no se leyó la doc de code signing) | — |

### 3.6 Rollback

- **Expo:** republicar un update anterior o volver al embebido (`eas update:rollback`); además recuperación ante error
  fatal JS: si pasaron más de 10 s desde el primer render no se captura; el rollback a un update anterior sólo se
  intenta si el evento «content appeared» no se disparó (si ya se disparó, sólo espera un update nuevo) [4][6].
- **CodePush:** si el bundle nuevo no llama a `notifyAppReady`, en el siguiente reinicio se revierte; `sync` saltea
  updates que ya fallaron [11].
- **Shorebird:** el servidor informa patches retiradas; el dispositivo las borra y vuelve a la anterior en el próximo
  inicio [29]. Kikoff observa que la app «is still running the bad bundle» hasta reiniciar [32].
- **Capgo/Capawesome:** `notifyAppReady()` / rollback automático al último bundle sano [21][22] (la página [18]
  menciona `notifyAppReady` pero no describe el rollback automático; lo hace el README del plugin [21]).

### 3.7 Rechazos y advertencias de las tiendas

**HECHO (reglas):**
- Apple DPLA 3.3.1(B): «an Application may not download or install executable code. Interpreted code may be
  downloaded to an Application but only so long as such code: (a) does not change the primary purpose … (b) does not
  bypass signing, sandbox, or other security features of the OS; and (c) … does not create a store or storefront»
  [37].
- Apple guía 2.5.2: no «download, install, or execute code which introduces or changes features or functionality of
  the app» [34].
- Google Play: la app «may not modify, replace, or update itself using any method other than Google Play's update
  mechanism»; «This restriction does not apply to code that runs in a virtual machine or an interpreter where either
  provides indirect access to Android APIs (such as JavaScript in a webview or browser)» [38].

**Casos documentados:**
- **Marzo de 2017**, Apple envía avisos citando 3.3.2 del DPLA y 2.5.2 a apps con frameworks de «hot code push»; la
  prensa lo atribuye a JSPatch y Rollout.io (acceso a APIs nativas privadas) [39][40]. En el foro de Meteor los
  desarrolladores interpretan que no alcanza a JS/HTML en Cordova (OPINIÓN, ver §4).
- **Junio de 2018**, expo/expo #1865: app Expo rechazada por 2.5.2 (y DPLA 3.3.2); el 2018-06-30 Apple precisó
  «remotely sourced code such as the 2 MB …»; pasó la revisión el 2018-07-15 deshabilitando OTA
  (`updates.enabled: false`). Contexto: según el mantenedor, esa app estaba «designed to compile and execute code
  remotely», no era un caso típico. En 2019 otro equipo dice que fue aceptado tras
  apelar «noting that we use expo». El mantenedor: «we don't have any other reports of Expo apps getting rejected
  with the same message» [41].
- **NO VERIFICADO:** no se encontraron casos documentados recientes (2024–2026) de rechazo por usar EAS Update,
  Capgo, Capawesome o Shorebird. Motivo: búsqueda en GitHub/HN/web sin resultados; Reddit no fue accesible.
- **Reconocimiento del proveedor (HECHO en cuanto a lo que declara Capgo):** el README del plugin admite que «A
  reviewer can still misread the binary or the launch UI and reject the build», que en iOS llega como guía 2.5.2,
  que «It is rare», y recomienda «do not mention updates, live updates, or remote updates anywhere in the app» [21].
  No da casos ni cifras.
- **Advertencia de UX (HECHO, doc CodePush):** en `handleBinaryVersionMismatchCallback` (avisar que hay un binario
  nuevo), «Be cautious to use Alerts within this callback if you are developing iOS application», citando la regla
  de Apple de no forzar acciones del usuario [11].

### 3.8 ¿Existe algo equivalente para .NET MAUI?

- **No se encontró** un servicio ni librería OTA de contenido para MAUI/Blazor Hybrid (dos búsquedas extendidas,
  2026-10-25) [30][31]. **NO VERIFICADO** como ausencia absoluta: una búsqueda negativa no prueba inexistencia.
- CodePush tuvo clientes para React Native y Cordova [9][10]; no se encontró cliente para Xamarin/MAUI (NO
  VERIFICADO como afirmación oficial).
- Las piezas para armarlo están en MAUI (HECHO): `HybridWebView.HybridRoot` sirve contenido desde los raw assets
  (`Resources/Raw/wwwroot`), y el evento `WebResourceRequested` permite «supplying local responses»; en iOS/Mac
  Catalyst no se interceptan `http`/`https`, sí esquemas propios; en Android es al revés: se intercepta HTTPS pero
  «Android does not support custom schemes» [42]. **[criterio propio]** El esquema de URL del contenido servido
  tiene que elegirse por plataforma. **[criterio propio]** Ese es el punto de
  enganche para servir el contenido descargado, equivalente al «embedded bundle + downloaded update» de Expo.
- **[criterio propio, NO VERIFICADO ante Apple]** Blazor WASM descarga ensamblados .NET que corre un runtime
  WebAssembly dentro de WebKit. Si Apple lo trata como «interpreted code» del DPLA 3.3.1(B) no está documentado;
  ninguna fuente lo resuelve. Es el principal riesgo de política propio de nuestro stack frente a JS puro.

## 4. Opiniones de desarrolladores

Conteo: 26 opiniones (9 a favor, 8 en contra, 9 matices; recontado tras la verificación, ver al final), contadas en estas tablas y tomadas de: hilo HN «Show HN:
Shorebird 1.0» (9), hilo HN de 2014 «Apple allows hot code push for JS downloaded and run by WebKit» (2), otros
comentarios sueltos de HN (6), issue microsoft/react-native-code-push #2675 (4), issue expo/expo #1865 (1), foro de
Meteor (3), blog de Kikoff (1). La clasificación a favor / en contra / matiz es del investigador. Es una muestra elegida por relevancia, no
representativa. Reddit no fue accesible (NO VERIFICADO).

### A favor

| Fuente | Autor | Fecha | Postura | Cita | Tema |
| --- | --- | --- | --- | --- | --- |
| HN 39975422 [43] | eseidel (fundador de Shorebird) | 2024-04-09 | A favor (interesado) | «We've seen 1000s of releases in the last year, and not had a single complaint about rejections.» | tiendas |
| HN 39974702 [43] | eseidel (fundador de Shorebird) | 2024-04-08 | A favor (interesado) | «code push is ubiquitous because so many apps need the ability to fix bugs» | utilidad |
| HN 39976607 [43] | realusername | 2024-04-09 | A favor | «The review process is mostly there to not circumvent their payment process.» | tiendas |
| HN 8402532 [44] | brianchu | 2014-10-02 | A favor | «this form of code push is routinely implemented in native apps too» | práctica |
| HN 9610269 [45] | sportanova | 2015-05-27 | A favor | «It's allowed - there's an explicit exception for downloading code and executing it via WebKit» | tiendas |
| HN 36880467 [46] | jameside (Expo) | 2023-07-26 | A favor (interesado) | «The ability to write and run your own update server is a part of Expo Updates and it is not going to be removed.» | autoalojamiento |
| HN 46485946 [47] | tcoff91 | 2026-01-04 | A favor | «You can self-host your own EAS Updates server.» | autoalojamiento |
| HN 36887842 [46] | frankcalise | 2023-07-27 | A favor | «Preview PRs on release channels via EAS Updates, also amazing.» | canales |
| GitHub #2675 [49] | joshuapinter | 2025-03-07 | A favor (migración) | «we just switched from App Center to» Revopush … «Thanks for making this change painless!» | sucesores |

### En contra

| Fuente | Autor | Fecha | Postura | Cita | Tema |
| --- | --- | --- | --- | --- | --- |
| HN 39976378 [43] | pritambarhate | 2024-04-09 | En contra | «This service is straight up lying when it says that Remote Code Push is implemented as per Apple's guidelines.» | tiendas |
| HN 39974945 [43] | 00deadbeef | 2024-04-08 | En contra | «I've heard of people having apps rejected for including Expo's OTA update feature.» | tiendas (de oídas) |
| HN 39974572 [43] | dr_kiszonka | 2024-04-08 | En contra | «Wouldn't this allow you to remotely inject malware into an app?» | seguridad |
| HN 39973623 [43] | lxgr | 2024-04-08 | En contra | «just doesn't sound like a great idea, even if it might technically pass the various app stores' review guidelines.» | seguridad |
| HN 39974423 [43] | maartenh | 2024-04-08 | En contra | «surprising to me that the app store gatekeepers don't force all app changes through their vetting process!» | tiendas |
| HN 46167140 [50] | LoganDark | 2025-12-05 | En contra | «Be careful with this. If Apple finds out for instance, your app will still be taken down.» | tiendas |
| GitHub #2675 [49] | highRPM | 2024-08-02 | En contra (dependencia del proveedor) | «When are you going to provide an independent code push?» | retiro de CodePush |
| expo #1865 [41] | terribleben (Expo) | 2018-06-13 | Cautela | «I find it likely that Apple will reject anything that claims to perform remote code execution.» (sobre una app diseñada para compilar y ejecutar código remoto) | tiendas |

### Matices

| Fuente | Autor | Fecha | Postura | Cita | Tema |
| --- | --- | --- | --- | --- | --- |
| HN 39974071 [43] | lxgr | 2024-04-08 | Matiz | «app stores do content moderation at the business level; what apps technically do is up to their developers» | tiendas |
| Foro Meteor [40] | wesleyfsmith | 2017-03-08 | Matiz | «this only is relevant for native calls, not loading in js/html» | rechazos 2017 |
| Foro Meteor [40] | markoshust | 2017-03-10 | Matiz | apps bien «as long as you don't change the base behavior of the app» | alcance |
| Foro Meteor [40] | sashko | 2017-03-08 | Matiz | «usually doesn't have anything to do with JavaScript hot code push» | rechazos 2017 |
| HN 8403630 [44] | rubyn00bie | 2014-10-02 | Matiz | «it's not really hot code push. It's loading a web view.» | definición |
| GitHub #2675 [49] | glncy | 2024-04-03 | Matiz (lo construyó él) | «Because of retirement, I just developed a package for custom server and cli.» | autoalojamiento |
| GitHub #2675 [49] | vagnerlandio | 2024-03-18 | Matiz | «Can we have our own server to store builds and continue using codepush» | autoalojamiento |
| HN 50219082 [48] | quikoa | 2026-10-24 | Matiz (escéptico) | Cita del artículo «Apple does let apps download JavaScript updates like this, which is how tools like Expo Updates work, as long as the update doesn’t change what the app is» y responde: «But there is no way for Apple to verify […] right?» | tiendas |
| Blog Kikoff [32] | Karthic Thangarasu | 2026-05-07 | Matiz (producción) | «Code push adoption ≈ user cold-start frequency. That's the floor.» | momento |

**Lectura cualitativa [criterio propio]:** las objeciones recurrentes son dos — cumplimiento de Apple (con
afirmaciones de oídas, sin casos recientes verificables) y seguridad del canal (inyección remota), que las
plataformas contestan con firma de bundles. La otra señal fuerte es la **dependencia del proveedor**: el retiro de
CodePush empujó a varios a autoalojar o a armar su propio servidor.

## 5. Lecciones aplicables a P1–P13

- **P1 (qué se actualiza).** Los cinco productos OTA leídos actualizan sólo la capa interpretada y deja lo nativo a la tienda
  [1][17][18][22][25]. Ningún producto ofrece «UI por datos»; eso es ortogonal. **[criterio propio]** Para la encuesta,
  la definición como datos (B) evita el riesgo de política de §3.8 sobre código descargado; el código de pantallas (A)
  queda en la zona que la industria resuelve con OTA y Apple tolera para JS en WebKit.
- **P2 (canal).** Modelo de referencia: Expo Updates v1, protocolo abierto con manifiesto (`id`, `createdAt`,
  `runtimeVersion`, `launchAsset`, `assets` con `hash`), directivas como `rollBackToEmbedded` y firma opcional por
  cabeceras [5]. Canales/ramas, rollout gradual, rollback por republicación o al embebido [1][4]. Firma RSA
  verificada en el cliente con clave embebida en el cascarón [28][35]. **Lección del retiro de CodePush:** un canal
  propio y autoalojable evita depender de un servicio que se apaga [7][8][49].
- **P3 (compatibilidad cascarón–contenido).** Usar una clave de compatibilidad explícita tipo `runtimeVersion`, no la
  versión de marketing; Expo advierte el desajuste con `appVersion` y ofrece `fingerprint` [1]. Rangos mín./máx. como
  Capawesome [24] o demora `nativeVersion` como Capgo [20]. Validar antes de publicar (falla de [33]).
- **P5 (sin red).** Patrón común: siempre hay un bundle embebido en el cascarón y la última versión descargada; nunca
  se bloquea el arranque por falta de red, o se bloquea con un tope (`fallbackToCacheTimeout`) [2][3].
- **P6/P8 (compuertas).** Canal de preview/«gated» antes de estable, promoción por telemetría de crashes (Kikoff)
  [32]; recuperación automática en los primeros segundos (Expo) [6]; `notifyAppReady` como señal de «arrancó bien»
  [11].
- **P7 (líneas de versión).** Expo y Shorebird (los dos leídos con ese detalle) separan al menos tres: versión del binario, clave de compatibilidad
  (runtimeVersion/versionCode) y id del update/patch [1][5][29].
- **P11 (demo).** **[criterio propio]** Una demo mínima creíble replica: bundle embebido + descarga + verificación de
  firma + aplicación en el próximo inicio + rollback al embebido.
- **P12 (capacidades).** Ninguno de los productos leídos resuelve el descubrimiento de capacidades; los que lo tratan lo reducen a «cambio nativo
  = binario nuevo» y atan el contenido a una versión nativa [1][17][25]. Apple 4.7.2 sobre exponer APIs nativas a
  software no embebido es un punto a revisar (NO VERIFICADO su alcance para contenido propio) [34].
- **P13 (datos con versión vieja).** Hueco de la industria OTA (§3.3); la única pista es el cuidado de Expo con el
  estado persistente [6]. Se resuelve fuera del canal **[criterio propio]**.
- **Actualización forzada (folio 006).** Contenido: forzable por el canal propio — CodePush `mandatory` + `IMMEDIATE`
  [11], Capgo `always`/`onLaunch` [20], Shorebird en la pantalla de login [27]; Expo sin soporte de primera clase
  [3]. Sin red no se fuerza lo que no se puede bajar: Expo documenta que cae a la caché o al embebido [2]; en Shorebird arranca con «the last known good patch» o la release [28] (para el resto, NO VERIFICADO). Cascarón: sólo la tienda. Cuidado
  con diálogos en iOS [11]. El momento «al iniciar sesión» del PO tiene respaldo documental explícito en Shorebird
  [27].
- **P4, P9, P10.** Sin aporte directo de este ángulo.

## 6. Fuentes numeradas

Fecha de consulta de todas: 2026-10-25.

1. Expo — «Runtime versions and updates». https://docs.expo.dev/eas-update/runtime-versions/ (sin fecha visible).
2. Expo — «app.json / app.config.js», sección `updates`. https://docs.expo.dev/versions/latest/config/app/
3. Expo — «Download updates». https://docs.expo.dev/eas-update/download-updates/
4. Expo — «Rollbacks». https://docs.expo.dev/eas-update/rollbacks/
5. Expo — «Expo Updates v1» (especificación técnica). https://docs.expo.dev/technical-specs/expo-updates-1/
6. Expo — «Error recovery». https://docs.expo.dev/eas-update/error-recovery/
7. Microsoft — «Visual Studio App Center Retirement», actualizado 2026-04-15. https://learn.microsoft.com/en-us/appcenter/retirement
8. Microsoft — repo `microsoft/react-native-code-push` (archivado 2025-05-20). https://github.com/microsoft/react-native-code-push
9. Microsoft — repo `microsoft/code-push-server` (archivado 2025-05-20). https://github.com/microsoft/code-push-server
10. Microsoft — repo `microsoft/cordova-plugin-code-push` (archivado 2022-10-12). https://github.com/microsoft/cordova-plugin-code-push
11. Microsoft — «API Reference for the React Native plugin», docs/api-js.md. https://github.com/microsoft/react-native-code-push/blob/master/docs/api-js.md
12. Bitrise, Dan Žďárek — «10 CodePush Alternatives in 2026», 2026-10-06 (act. 2026-10-19); declara ser proveedor. https://bitrise.io/blog/post/codepush-alternatives
13. Revopush — «App Center CodePush Alternatives for React Native», act. 2026-08-23. https://revopush.org/react-native-codepush-alternative
14. gronxb — repo `hot-updater`. https://github.com/gronxb/hot-updater
15. The Ionic Team — «Important announcement: the future of Ionic's commercial products», 2025-02-11. https://ionic.io/blog/important-announcement-the-future-of-ionics-commercial-products
16. Ionic — Appflow docs (aviso «Sales of Appflow Enterprise plans have been discontinued»). https://ionic.io/docs/appflow
17. Ionic — «Live Updates» (Appflow Deploy). https://ionic.io/docs/appflow/deploy/intro
18. Capgo — «Live Updates». https://capgo.app/docs/live-updates/
19. Capgo — «Migrate from AppFlow to Capgo». https://capgo.app/docs/upgrade/from-appflow-to-capgo/ (sólo vía resultado de búsqueda; no leído completo).
20. Capgo — «Update Behavior». https://capgo.app/docs/live-updates/update-behavior/
21. Cap-go — repo `capacitor-updater` (MPL-2.0). https://github.com/Cap-go/capacitor-updater
22. Capawesome — «Cloud Live Updates». https://capawesome.io/cloud/live-updates/
23. Capawesome, Robin Genz — «How to restrict Capacitor Live Updates to native versions», datePublished 2024-05-06 (la página se declara obsoleta y remite a best practices). https://capawesome.io/blog/how-to-restrict-capacitor-live-updates-to-native-versions
24. Capawesome — «2025 October update» (versionCode equivalente) y best practices. https://capawesome.io/blog/2025-october-update · https://capawesome.io/docs/cloud/live-updates/guides/best-practices/
25. Shorebird — «Code Push» overview. https://docs.shorebird.dev/code-push/
26. Shorebird — documentación (portada). https://docs.shorebird.dev/
27. Shorebird — «Update strategies». https://docs.shorebird.dev/code-push/update-strategies/
28. Shorebird — «Patch signing». https://docs.shorebird.dev/code-push/guides/patch-signing/
29. Shorebird — «Rollback». https://docs.shorebird.dev/code-push/rollback/
30. oscoreio — `Maui.Android.InAppUpdates`. https://github.com/oscoreio/Maui.Android.InAppUpdates · `Plugin.Maui.LatestVersion` https://www.nuget.org/packages/Plugin.Maui.LatestVersion
31. GeneralLibrary — `GeneralUpdate.Maui`. https://github.com/GeneralLibrary/GeneralUpdate.Maui
32. Kikoff, Karthic Thangarasu — «Shorebird in Anger: A Production Flutter Code Push Integration», 2026-05-07. https://about.kikoff.com/build/shorebird-in-anger-a-production-flutter-code-push-integration
33. tommyshellberg/emberglow — issue #399 «OTA safety: runtimeVersion is a hand-maintained string». https://github.com/tommyshellberg/emberglow/issues/399 (abierto por tommyshellberg el 2026-08-06; verificado por la API de GitHub).
34. Apple — «App Store Review Guidelines» (2.5.2, 4.7, 4.7.2). https://developer.apple.com/app-store/review/guidelines/
35. Expo — «Code signing». https://docs.expo.dev/eas-update/code-signing/
36. Capgo — «End-to-end encryption». https://capgo.app/docs/live-updates/encryption/
37. Apple — «Apple Developer Program License Agreement», §3.3.1(B) «Executable Code». https://developer.apple.com/support/terms/apple-developer-program-license-agreement/
38. Google — Play Console Help, política «Device and Network Abuse». https://support.google.com/googleplay/android-developer/answer/9888379
39. Silicon UK, Roland Moore-Colyer — «Apple Clamps Down On iOS Apps Using Hot Code Push SDKs», 2017-03-09. https://www.silicon.co.uk/mobility/apple-hot-code-push-206922
40. Meteor Forums — «Apple starts rejecting apps with "hot code push" features», 2017-03-08. https://forums.meteor.com/t/apple-starts-rejecting-apps-with-hot-code-push-features/34597
41. expo/expo — issue #1865 «AppStore: Binary Rejected», 2018-06-13. https://github.com/expo/expo/issues/1865
42. Microsoft — «HybridWebView - .NET MAUI», 2026-07-08. https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/hybridwebview?view=net-maui-10.0
43. Hacker News — «Show HN: Shorebird 1.0, Flutter Code Push», 2024-04-08. https://news.ycombinator.com/item?id=39973150 (comentarios vía API de Algolia).
44. Hacker News — «Apple allows hot code push for JS downloaded and run by WebKit» (yaliceme), 2014-10-02. https://news.ycombinator.com/item?id=8402184 (el id 8402532 es el comentario de brianchu, no el hilo).
45. Hacker News — comentario 9610269 en «Mobile app startups are failing like it's 1999». https://news.ycombinator.com/item?id=9610269
46. Hacker News — «Expo – Open-source platform for making universal apps…», 2023-07-26. https://news.ycombinator.com/item?id=36871651 (el id 36880467 es el comentario de jameside, no el hilo).
47. Hacker News — comentario 46485946 en «Swift on Android…». https://news.ycombinator.com/item?id=46485946
48. Hacker News — comentario 50219082 en «How Block Blast harvests its players for ad money». https://news.ycombinator.com/item?id=50219082
49. microsoft/react-native-code-push — issue #2675 «[Discussion] Visual Studio App Center Retirement». https://github.com/microsoft/react-native-code-push/issues/2675
50. Hacker News — comentario 46167140 en «Show HN: HCB Mobile…». https://news.ycombinator.com/item?id=46167140

## Verificación de fuentes

Verificador adversarial, 2026-10-25. Se abrieron directamente 46 de las 50 fuentes (páginas oficiales con
WebFetch/curl; comentarios de HN por la API de Algolia y de Firebase; issues y repos de GitHub por la API de
GitHub). No se reabrieron: [19] (Capgo, migración desde Appflow; ya declarada «vía buscador»), [24] best practices
de Capawesome (sí se abrió el «2025 October update»), [30] parcialmente (repo sí, NuGet de `Oscore…` no) y [12]
para lo no tabulado. Se cotejaron las 26 opiniones (autor, fecha UTC, texto) contra el original.

Correcciones (antes → después):

1. Expo [1]: «native code can't change through an update» no es textual → «some native code that cannot be changed
   with an update».
2. Expo [6]: «rolling back after content has appeared could be unsafe if the broken update changed persistent
   state» no existe en la página → «this can be dangerous if your new update has modified persistent state in a
   non-backwards compatible way» (+ ejemplo de AsyncStorage/archivos).
3. Expo [6]: «recuperación dentro de los 10 s del primer render, sólo si el contenido no apareció» → precisado: los
   errores después de 10 s no se capturan; si «content appeared» ya se disparó no hay rollback, sólo espera de un
   update nuevo.
4. Shorebird [27]: «check for updates during a login screen or another launch gate» no es textual → «check for
   updates as part of a login screen, or other launch gate» (en §2 y §3.1). Se agregó que el rollback exige Flutter
   ≥ 3.27.4 [29].
5. Capgo [20]: «`onLaunch`/`atInstall` aplica inmediatamente en arranque en frío» → sólo `onLaunch`; `atInstall`
   aplica inmediato sólo tras instalación nueva o actualización de tienda, si no se comporta como `atBackground`.
6. Capgo: rollback automático atribuido a [18], que no lo describe → [21] (README del plugin). Offline: de «NO
   VERIFICADO, vía buscador» → leído en [21] (`setChannel()` guarda el canal en el dispositivo «for better offline
   support»).
7. CodePush [11]: «`targetBinaryVersion` … NO VERIFICADO» → la doc sí dice que se ignoran updates con «binary
   version mismatch»; sólo el nombre de opción queda NO VERIFICADO.
8. CodePush [11], advertencia de alertas: estaba generalizada a «al chequear updates» → se acota a
   `handleBinaryVersionMismatchCallback`, con cita textual.
9. §3.7: se agregó que el README de Capgo [21] admite rechazos por 2.5.2 («It is rare») y aconseja no mencionar
   actualizaciones en la app; matiza la frase «no se encontraron casos recientes».
10. expo #1865 [41]: se precisaron fechas (mensaje de Apple 2018-06-30, aprobación 2018-07-15) y el contexto que dio
    el mantenedor (la app estaba diseñada para compilar y ejecutar código remoto); también en la cita de
    terribleben.
11. HybridWebView [42]: se agregó la restricción simétrica de Android («Android does not support custom schemes»).
12. Opinión quikoa (HN 50219082): la cita no es suya sino del artículo que él cita, y su postura es escéptica («But
    there is no way for Apple to verify … right?») → movida de «A favor» a «Matices» con la cita correcta. Conteo:
    10/8/8 → 9/8/9 (total 26 sin cambios).
13. eseidel (HN 39974702): faltaba marcarlo como interesado (fundador de Shorebird) → «A favor (interesado)».
14. Fuentes [44] y [46]: las URL apuntaban a comentarios, no a los hilos → 8402184 y 36871651.
15. Fuente [33]: fecha NO VERIFICADA → 2026-08-06 (API de GitHub). Fuente [39]: «2017-03, vía buscador» →
    2017-03-09, Roland Moore-Colyer, leída. Fuente [23]: autor Robin Genz, publicada 2024-05-06, obsoleta.
16. Generalizaciones sin conteo: «patrón dominante», «Todas las plataformas», «Toda la industria OTA», «La industria
    separa», «todos lo reducen», «todas caen a la caché» → acotadas a los productos leídos, con cuántos y cuáles; lo
    no documentado para el resto queda NO VERIFICADO.

Confirmado sin cambios (muestra): fecha de retiro de App Center (2025-03-31) y la página actualizada 2026-04-15 [7];
archivo de `react-native-code-push` y `code-push-server` el 2025-05-20, «as is», MIT [8][9]; archivo de
`cordova-plugin-code-push` el 2022-10-12 [10]; `mandatoryInstallMode` IMMEDIATE por defecto, `notifyAppReady`,
`minimumBackgroundDuration` [11]; Bitrise (Dan Žďárek, 2026-10-06/19, declara ser proveedor, 100.000 MAU con plan
Bitrise) [12]; Revopush actualizada 2026-08-23 [13]; hot-updater autoalojable con adaptadores de firma [14]; Ionic
2025-02-11 y acceso hasta 2027-12-31 [15][16]; Appflow «binary compatible changes (HTML, CSS, and JS)» [17];
`fallbackToCacheTimeout` 0/300000, `checkAutomatically` y `rsa-v1_5-sha256` [2]; «no first-class support» y recarga
en segundo plano «experimental» [3]; `eas update:rollback` [4]; protocolo (`expo-runtime-version`,
`rollBackToEmbedded`, `expo-expect-signature`) [5]; firma sólo en Production/Enterprise [35]; Capgo
inconsistente en algoritmos [36]; Capawesome (capa web, RSA 2048/3072/4096, todos los planes, «the recommended way
off Appflow») [22]; Shorebird (sin assets/nativo/motor, chequeo de diferencias nativas y de assets, firma con
rechazo al arranque) [25][27][28][29]; Kikoff (autor, fecha y las tres citas) [32]; Apple 2.5.2 y 4.7.2 [34] y DPLA
3.3.1(B) [37]; Google Play [38]; Meteor (autores, fechas y citas) [40]; HybridWebView `ms.date` 2026-07-08 [42];
los 25 comentarios restantes (autor, fecha y texto).

Sigue NO VERIFICADO: nombre de opción `targetBinaryVersion`; firma en CodePush; comportamiento sin red de Bitrise,
Revopush, Appflow y Capawesome; casos recientes (2024–2026) de rechazo; trato de Apple a Blazor WASM como «interpreted
code»; ausencia de un OTA para MAUI (una búsqueda extendida adicional del verificador tampoco encontró uno); Reddit
no accesible.
