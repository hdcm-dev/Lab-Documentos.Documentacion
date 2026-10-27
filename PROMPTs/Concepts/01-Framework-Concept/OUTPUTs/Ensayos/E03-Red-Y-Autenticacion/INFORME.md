# E03 — Red y autenticación con el sistema operativo (incremento A4, folio 038)

Fecha: 2026-10-26. Tramo: integrador del incremento. Pedido del PO: folio 038 («manejo de autentificación usando los
mecanismos configurados en el sistema operativo, manejo de red (detección de corte de internet, notificación al
usuario que no hay red, y reconexión automática) con bloqueo de acciones que requieren internet»). Diseño que rige:
P4 del dictamen de la ronda 2 (folio 035) y el borrador del PO `Framework-APP.md` §4, §6 y §7, bajados a
`DISENO-RED-Y-AUTENTICACION.md` en la raíz de la demo
(`LAB/Lab-Documentos/Lab-Documentos/Concepts/Framework-Concept/Demo/`).

Este tramo retoma un intento anterior que se cortó por el límite de sesión, a mitad del recorrido. De ese intento se
conservaron:

- la compuerta en verde de las 19:12, con el mismo código que se evaluó acá;
- la semilla regenerada (contenido `1.0.0+5d5c2b4`);
- el APK x64 instalado a las 19:26;
- el paso a), con capturas `a0`–`a5`.

En esta sesión se hicieron:

- los pasos b) a h) del recorrido;
- una corrida nueva de `ci-local.sh` completo, que terminó con `rc=0`;
- este informe.

No hubo que arreglar nada para integrar: las ramas de red y de autenticación compilaron juntas y la compuerta pasó
sin cambios. Los defectos encontrados en el recorrido se informan en el §5 y **no se corrigieron**. El APK evaluado
tenía que seguir siendo el de las capturas, y dos de los defectos piden una decisión de la mesa.

## 1. Hipótesis

H1. Las ramas de red y de autenticación compilan juntas y la compuerta local (`ci-local.sh`) queda en verde, con el
contrato del puente 1.1.0 clasificado como MENOR (P3).

H2. Autenticación con los mecanismos del sistema operativo (P4, borrador §4) en un teléfono real de la plataforma:

- primer ingreso con OIDC code + PKCE en el navegador del sistema (RFC 8252);
- oferta de usar la seguridad del teléfono;
- desbloqueo con huella o con PIN sin pedir cuenta;
- cerrar sesión pide cuenta y no pierde pendientes;
- quitar el bloqueo de pantalla invalida la clave y obliga a reingresar con cuenta.

H3. Manejo de red (borrador §6 y §7):

- el corte se detecta y se avisa;
- la acción `SoloEnLinea` se deshabilita con su motivo;
- la `Encolable` queda pendiente;
- «sin acceso al servidor» se distingue de «sin conexión»;
- al volver el servidor, la app pasa sola a «En línea» y el outbox se vacía sin intervención (reconexión automática);
- el Receptor registra el dueño de cada fila.

## 2. Entorno exacto

| Pieza | Valor |
| --- | --- |
| Máquina | i7infra (Debian, kernel 6.12.111), sin dotnet ni adb en el host |
| Compilación | imagen `fc-demo-build` por `scripts/contenedor.sh`, volumen NuGet `fc-nuget` |
| Dispositivo | `fc-android-emu-hpdev`: Android 13 (API 33), x86_64, Google APIs, KVM; WebView 155.0.8059.43; pantalla 540×1200 |
| adb | `docker exec adb-contenedor adb -H 203.0.113.20 -P 5042 -s emulator-5554` (nunca `connect` ni `kill-server`) |
| Huella simulada | `ssh 203.0.113.20 'docker exec fc-android-emu-hpdev adb -s emulator-5554 emu finger touch 1'` (ver §6, desvío) |
| Bloqueo de pantalla | PIN `1234` (`locksettings`), huella 1 enrolada en Ajustes; CA de demostración como CA de usuario (para Chrome) |
| Emisor | `fc-keycloak` (Keycloak 26.7.5 por digest), `https://203.0.113.10:8443/realms/fc-demo`; access 5 min, sesión SSO 30 min sin uso |
| Receptor | `fc-demo-receptor`, `https://0.0.0.0:8099`, `--oidc-emisor` del realm `fc-demo` (valida firma, audiencia, vencimiento y emisor) |
| APK | Debug `android-x64`, `com.frameworkconcept.demo` 1.0.0, puente 1.1.0, contenido `1.0.0+5d5c2b4`; `FcCanalUrl=https://203.0.113.10:8099`, `FcOidcAutoridad` = el emisor de arriba; sha256 `440dd8616c919062c4b84c88660b2610146b81010142fffc1f620fef12225251` (instalado = compilado) |
| Commit corto | `5d5c2b4` (HEAD de Lab-Documentos; la demo no está versionada todavía) |

## 3. Pasos reproducibles

```bash
# (1) compuerta, desde la raíz de la demo
scripts/ci-local.sh                                  # 0..6: base, build, Core, Update, Gate, publish, APK arm64
src/FrameworkConcept.Content/Testing/probar-en-navegador.sh <capturas>   # contenido headless, puente simulado

# (2) emisor, receptor y APK
infra/keycloak/keycloak.sh certificado && infra/keycloak/keycloak.sh levantar
FC_OIDC_EMISOR=https://203.0.113.10:8443/realms/fc-demo scripts/guion.sh servir
FC_RID=android-x64 FC_URL_CANAL=https://203.0.113.10:8099 \
  FC_OIDC_EMISOR=https://203.0.113.10:8443/realms/fc-demo scripts/guion.sh apk
scripts/guion.sh instalar -H 203.0.113.20 -P 5042 -s emulator-5554    # con FC_ADB_CONTENEDOR=adb-contenedor

# (3) recorrido (adb como en §2)
#  a  abrir → «Ingresar con tu cuenta» → Keycloak (encuestador / demo-encuestador) → «Sí, usarla» → diálogo del sistema
#  b  am force-stop; abrir → diálogo del sistema → emu finger touch 1
#  c  am force-stop; abrir → «Use PIN» → input text 1234
#  d  cmd connectivity airplane-mode enable; tomar y registrar una encuesta; tocar «Enviar ahora»
#  e  docker stop fc-demo-receptor; cmd connectivity airplane-mode disable
#  f  scripts/guion.sh servir (sin tocar la app)
#  g  modo avión; otra encuesta; «Cerrar sesión» → confirmar; sin modo avión; «Ingresar con tu cuenta»
#  h  «Sí, usarla» con huella; am force-stop; locksettings clear --old 1234; abrir; «Ingresar de nuevo»
```

Cada paso dejó una captura (`exec-out screencap -p`) en `local/` y su `.txt` de tres líneas en esta carpeta. El
logcat filtrado por la etiqueta `FC` está en `local/logcat/`. Las ventanas del sistema (BiometricPrompt) son seguras:
su captura sale negra, y lo que mostraban se comprobó con `uiautomator dump` (`local/logcat/*-ui.xml`).

## 4. Resultados

### 4.1 Compuerta (H1)

| Paso de `ci-local.sh` | Resultado |
| --- | --- |
| 1. Build sin MAUI, avisos como error | 0 avisos, 0 errores |
| 2. Core.Tests | 202 / 202 |
| 3. Update.Tests | 102 / 102 |
| 4. Gate.Tests | 52 / 52 |
| 5. Publish del contenido y empaquetado | correcto |
| 6. APK android-arm64 | correcto |
| Salida | `rc=0` (`local/logcat/ci-local-final.log`, 2026-10-26 ~21:00 hora local) |

Contenido en Chromium headless con el puente simulado: 76 de 76 comprobaciones, incluidas las de sesión y red. Los
rojos provocados antes del verde (P8) son de los constructores: `rojos-red.md` (máquina de red y política de
acciones) y `rojos-auth.md` (máquina de sesión, outbox con dueño, PKCE). La base del PR con `contrato.json` 1.0.0
clasifica el contrato 1.1.0 como MENOR (corrida del arquitecto, registrada en el README de la demo).

**H1 se cumple.**

### 4.2 Autenticación (H2)

| Paso | Capturas | Qué se vio | Tiempos |
| --- | --- | --- | --- |
| a | `a0`–`a5` | Pantalla propia «Ingresar con tu cuenta». El login abre una Chrome Custom Tab con el formulario de `fc-keycloak` y candado válido. Vuelve por `com.frameworkconcept.demo://callback` en `Activa`. Ofrece «¿Usar la seguridad del teléfono…?». Al aceptar aparece el diálogo del sistema y el refresh queda sellado con la clave del Keystore | arranque en frío `TotalTime` 3,5 s; navegador → `Activa` 51 s (incluye tipear) |
| (b0) | `b0-sesion-vencida` | Antes del paso b la app se reabrió 52 min después del ingreso y estaba **`Vencida`**. Es lo esperado (realm: 30 min sin uso): muestra la banda «Tu sesión venció: ingresá para enviar lo pendiente» y se sigue trabajando local. Se reingresó y se aceptó la oferta con la **huella** (23:26:19Z) | — |
| b | `b1`, `b2` | `am force-stop` y abrir: `Bloqueada`. La pantalla propia «Desbloquear» abre sola el BiometricPrompt («Touch the fingerprint sensor» / «Use PIN»). Con `emu finger touch 1` entra como `encuestador` sin cuenta ni navegador | `Bloqueada` a los 11,4 s del arranque y diálogo a los 25,3 s; huella → app con foco 6,9 s medidos desde el host; el refresh renueva el access en 2,2 s |
| c | `c1`, `c2` | Reabrir y «Use PIN»: campo de PIN del sistema; `1234` → `Activa`. La misma clave del Keystore se abre con huella y con PIN (`BIOMETRIC_STRONG \| DEVICE_CREDENTIAL`) | diálogo a los 35,3 s del arranque; PIN → app 6,7 s desde el host |
| g | `g1`, `g2`, `g3` | Sin red, encuesta pendiente (`bcb21b59…`), «Cerrar sesión». La confirmación dice que lo pendiente se conserva. Queda `SinCuenta` con «pendientes conservados 1» y vuelve a pedir cuenta (sin red, «Ingresar con tu cuenta» está deshabilitado con «Sin conexión»). Con red, el outbox **no** envía mientras no hay sesión. Al reingresar como `encuestador` la fila sale sola | reingreso → fila enviada 0,7 s |
| h | `h1`, `h2`, `h3` | Desbloqueo activado con huella. Quitar el PIN (`locksettings clear`) deja las huellas en 0. Al reabrir queda **`Revocada`** con «La seguridad del teléfono cambió: ingresá de nuevo con tu cuenta». Se reingresa con cuenta y, sin bloqueo de pantalla, **no** se ofrece el desbloqueo: aparece la banda «Este teléfono no tiene bloqueo de pantalla…» (D-03 = T1) | `Revocada` detectado en el arranque en frío, sin red |

**H2 se cumple**, con los hallazgos H-2 (reingreso sin clave por la sesión SSO viva), H-3 (ANR) y H-4 (ingreso colgado
si se cae la red) del §5. Sobre el A10 (huella nueva): ver H-1.

### 4.3 Red (H3)

| Paso | Capturas | Qué se vio | Tiempos |
| --- | --- | --- | --- |
| d | `d1`, `d2` | Modo avión: banda «Sin conexión. Lo que hagas se guarda y se envía cuando vuelva.» y pie «Sin red: se guarda y se envía después». Se registra una encuesta completa (Encolable) que queda pendiente con su clave de envío; «Por enviar: 1». «Enviar ahora» (SoloEnLinea) queda deshabilitado con el motivo «Sin conexión», y un toque no genera ninguna línea `FC` | aviso en el mismo segundo del corte (23:29:09.457Z, señal del sistema, sin esperar la salud) |
| e | `e1` | Vuelve la red con el Receptor caído: banda «Sin acceso al servidor. Hay red pero el servidor no responde. Reintentando…». «Enviar ahora» deshabilitado con «El servidor no responde» | `RedSinServidor` al instante; salud falla a +0,1 s, +15 s, +35 s (backoff) |
| f | `f1` | Se levanta el Receptor sin tocar la app: pasa sola a «En línea», «Por enviar: 0». El Receptor registra `→ 201 dueño encuestador (0b278ed9-…)` y `/respuestas` guarda `dueno` y `usuario` | Receptor listo 23:33:15 → `EnLinea` 23:33:21.657Z (**6,4 s**, R4 pide ≤ 60 s) → fila enviada a +0,57 s |
| g (red) | `g2`, `g3` | Al sacar el modo avión con el Receptor arriba, la app pasa a `EnLinea` | **1,7 s** (R2 pide ≤ 10 s) |

Respuestas en el Receptor (`local/logcat/respuestas-g.json`):

| Clave | Registrada (app) | Recibida | Dueño |
| --- | --- | --- | --- |
| `f3702b58ed19425a8ac838384d7088da` (Ana Prueba) | 23:31:24Z, sin red | 23:33:22Z, al volver el servidor | `encuestador` (`0b278ed9-d37e-45a5-a8f8-4504d440b1ab`) |
| `bcb21b59d8d2493097a81f369fe7e725` (Bruno Pendiente) | 23:39:19Z, sin red, antes de cerrar sesión | 23:41:28Z, al reingresar | `encuestador` (el mismo `sub`) |

**H3 se cumple**, salvo lo no verificado del §7 (R0 y R5).

## 5. Hallazgos para la mesa

**H-1 (del constructor de autenticación, A10; decisión de diseño).** Con `BIOMETRIC_STRONG | DEVICE_CREDENTIAL`,
enrolar otra huella **no** invalida la clave. P4 pide aceptar PIN o patrón, y el borrador §4 pide invalidar la
clave cuando se enrola una huella nueva. En Android las dos cosas no van juntas: `setInvalidatedByBiometricEnrollment`
sólo actúa sobre claves exclusivamente biométricas. La mesa tiene que elegir. Detalle en
`~/fc-work/demo/e03/auth/emulador/a10-huella-nueva-no-invalida.txt` (fuera del repositorio).

> **Decisión de mesa (corrector, 2026-10-27):** se mantiene P4 (huella, rostro, PIN o patrón). Que enrolar una huella
> nueva no invalide la clave queda como **apartamiento declarado del borrador §4** (DISENO §3.4 y §12). Fundamentos:
> quien enrola una huella ya pasó por el PIN o patrón, que también abre la clave; una clave sólo biométrica dejaría
> afuera a quien no tiene huella ni rostro (P4, D-03 = T1). Se conserva la invalidación al quitar el bloqueo de
> pantalla. **Se avisa al PO**: contradice un texto suyo.

**H-2 (seguridad, P4).** Cerrar sesión sin red no termina la sesión SSO del emisor. Después, «Ingresar con tu
cuenta» vuelve en 8 a 12 s **sin mostrar el formulario**: se vio tres veces (23:41:16Z, 23:47:22Z y 23:57:54Z, sin
teclear nada). Pasa lo mismo después de `Revocada` por cambio del bloqueo de pantalla (h3). Mientras viva la sesión
SSO del emisor (30 min sin uso), ese «reingreso con cuenta» no vuelve a autenticar a la persona. DISENO §3.8 dice
«intenta el `end_session` del emisor si hay red (sin red, no espera)». El código (`CerrarAsync`) revoca el refresh
token y no llama al `end_session` del navegador. Opciones para la mesa:

- pedir `prompt=login` (o `max_age=0`) en el reingreso que sigue a un `Cierre` o a una `Revocada`;
- reintentar el `end_session` pendiente al volver `EnLinea`;
- las dos.

No verificado: si el cierre **con** red sí termina la sesión SSO.

**H-3 (defecto, ANR).** Al volver del navegador en el reingreso de las 23:41, Android mostró «Framework Concept isn't
responding»:

- WindowManager: «Waited 5002ms for FocusEvent», en el mismo milisegundo en que se loguea «ingresó encuestador»;
- entre «app: reanudada» e «ingresó» pasaron 6,6 s, contra 0,4–1,6 s en los otros ingresos del día;
- «Wait» cierra el diálogo y vuelve a aparecer; hubo que cerrar la app (`g4-anr-tras-volver-del-navegador`);
- en el volcado (`local/logcat/h-anr-dropbox.txt`) el hilo `main` ya estaba libre en `Looper.pollOnce`;
- se vio 1 vez en 3 reingresos por SSO y 1 vez en 6 ingresos del día.

**Causa no determinada.** Hay que medir el canje (`CanjearAsync`) y las escrituras posteriores al
`InvokeOnMainThreadAsync` de `SesionDelUsuario.IngresarAsync`.

**H-4 (defecto, red durante el ingreso).** Si la red se cae mientras se descubre el emisor, la sesión queda en
`Ingresando` para siempre: «Completá el ingreso en el navegador…» con la rueda girando y el navegador sin abrir.

- Visto a las 23:49:26Z: `red: llamada fallida (emisor WebException)` y nunca `IngresoFallido`.
- Causa, leída en el código: `ManejadorDeRed` re-lanza la excepción original y en Android la conexión fallida llegó
  como `System.Net.WebException`. El `catch` de `SesionDelUsuario.IngresarAsync`
  (`src/FrameworkConcept.Shell/Auth/SesionDelUsuario.cs`, línea 252) filtra sólo `HttpRequestException`,
  `IOException`, `FormatException`, `ErrorDelEmisorException` y `TaskCanceledException`.
- Arreglo propuesto: sumar `WebException` al filtro, o tratar como falla de ingreso toda excepción que no sea
  `ExcepcionDeAutenticacion`. Más una prueba de la transición `Ingresando` + falla de red → estado anterior.
- Sólo se salió con `am force-stop`, que arranca en `Vencida`.
- Mismo patrón, no observado en el recorrido: el `catch` de la renovación (línea 181) y el de la revocación al cerrar
  sesión (línea 338) tampoco filtran `WebException`. Si la red se cae justo en esos momentos, la excepción se escapa.
  No verificado.

**H-5 (entorno, hipótesis).** Durante H-4 el wifi virtual del emulador empezó a caerse cada 10 a 20 s
(`CTRL-EVENT-BEACON-LOSS` y `DISCONNECTED reason=4`), sin modo avión ni cambios de ajustes. Lo observado:

- el contenedor del emulador estaba en 298 % de CPU y 6,85 de 7 GiB;
- la primera caída fue 0,7 s después de que apareciera la rueda de `IngresoPage`;
- con `am force-stop` la CPU bajó a 27 % y el wifi no se volvió a caer.

Hipótesis: el render por software de la rueda indefinida satura el host del emulador. No se probó aislado.
`svc wifi disable` no sirve como alternativa porque el emulador no tiene datos móviles.

**H-6 (menor, visual).** En `EnLinea` la etiqueta fija «En línea» no tiene fondo: con la página desplazada se pinta
sobre el contenido (`f1`). En `RedSinServidor`, el pie parte en dos renglones y la pastilla «Por enviar: 1» queda
deformada como un óvalo alto (`e1`).

**H-7 (observación, rendimiento en el emulador).** Del arranque en frío a la pantalla «Desbloquear» pasaron entre
14 y 35 s, contra el `TotalTime` de 3,5–4,4 s de la actividad. La parte grande es la carga del contenido
(`puente Listo` a los 23–38 s) con el emulador cargado. No es el TPR de P11 (que se mide en el teléfono de medida) y
no se perfiló.

**H-8 (menor, higiene).** Al arrancar, el Receptor deja en la raíz de la demo
`.aspnet/DataProtection-Keys/key-*.xml` (el llavero de ASP.NET; se vio a las 19:17:53 de la sesión anterior), y
`.gitignore` no lo excluye. Se borró a mano. Hay que sumarlo al `.gitignore` o fijar el directorio de claves del
Receptor dentro de `salida/`.

## 6. Desvíos del paso prescripto

- `adb -s emulator-5554 emu finger touch 1` **por el mismo servidor adb** no anda: la consola del emulador escucha
  sólo dentro de su contenedor. Salida: «error: could not connect to TCP port 5554: Connection refused». Se resolvió
  con `ssh 203.0.113.20 'docker exec fc-android-emu-hpdev adb -s emulator-5554 emu finger touch 1'`, que actúa sobre
  el mismo emulador exclusivo.
- Paso a): la oferta se aceptó con el PIN en el modo credencial del diálogo. La huella se enroló después, porque el
  A11 del constructor había quitado el bloqueo y con él las huellas (`a0`). En el reingreso previo a b) la oferta se
  aceptó con huella.
- Paso b): el primer intento quedó cancelado porque la pantalla del emulador se apagó. Se subió
  `screen_off_timeout` a 30 min y se repitió.
- Paso h): el primer reingreso quedó colgado (H-4 y H-5). Se cerró la app, se esperó a que el wifi se estabilizara y
  se repitió.

## 7. No verificado

- **R0** (APK sin `FcOidcAutoridad`, regresión de A3 en modo Dispositivo): no se corrió en el emulador en este tramo.
  Lo cubren sólo las pruebas de Core (`PropiedadDelOutboxTests`, modo Dispositivo).
- **R5** (`EnLineaMedida`, «Datos móviles»): el emulador no tiene red de datos móviles («Active default network:
  none» con el wifi apagado). Sólo lo cubren `TransicionesDeRedTests` y `EvaluadorDeAccionesTests`.
- **A7** (otra cuenta no ve ni envía filas ajenas) y **A9** (revocación desde el emisor): no se repitieron acá. Los
  corrió el constructor de autenticación (`a7-supervisora-no-ve-ajenas`, `a9-revocada-por-el-emisor`, en
  `~/fc-work/demo/e03/auth/emulador/`, fuera del repositorio).
- La causa de H-3 y de H-5.
- Si el cierre de sesión con red termina la sesión SSO (H-2).
- Nada se probó en un teléfono físico: el moto g42 quedó reservado para otra sesión del PO.

## 8. Estado al terminar

- Emulador: app cerrada (`am force-stop`) y en el escritorio. **Sin PIN ni huella**: se quitaron en el paso h y no
  se volvieron a poner. La CA de demostración sigue como CA de usuario y queda la línea de comandos de Chrome de la
  preparación. Los datos de la app no se borraron (`pm clear` no se corrió), para la revisión.
- `fc-demo-receptor` y `fc-keycloak`: bajados (`guion.sh parar`, `keycloak.sh parar`). Sigue corriendo
  `fc-android-emu`, de un tramo anterior y ajeno a este recorrido: no se tocó.
- `.aspnet/` borrado (H-8). `salida/` se conserva (canal, receptor, `keycloak/admin.txt`; no se versiona).
- `bin/` y `obj/` de la demo: borrados. El APK x64 evaluado se copió antes a
  `~/fc-work/demo/e03/integ/com.frameworkconcept.demo-x64.apk`.

## 9. Correcciones posteriores (corrector del incremento, 2026-10-27)

Detalle: `correcciones.md`. Compuerta otra vez en verde: Core 211/211, Update 102/102, Gate 52/52, contenido y APK.
El contrato del puente no cambia.

| Hallazgo | Estado después de corregir | Evidencia |
| --- | --- | --- |
| H-2 (P0) | `prompt=login`: con la sesión SSO viva, el reingreso pide la clave. Se verificó que el cierre **con** red sí termina la sesión SSO | `j2`–`j5`, `n2` |
| H-4 | Toda falla del emisor vuelve el ingreso al estado previo. Corte en pleno ingreso → `SinCuenta` en 0,1 s; vuelve la red → botón habilitado | `l1`, `l2` |
| H-3 | El trabajo posterior al navegador sale del hilo principal. 7 reingresos sin ANR nuevo; causa no demostrada | logcat `corrector.txt`; tabla en `correcciones.md` |
| H-1 | Decisión de mesa: se mantiene P4; apartamiento declarado del borrador §4 | §5 H-1 |
| Entrada sin prueba local | En frío: `Bloqueada` o `SinCuenta`, nunca `Vencida`/`Revocada` con la entrada abierta | `i1`, `i2`, `m1`, `n1` |
| Carrera dueño/token | Token por fila bajo el cerrojo de la identidad; con cuenta, nada sale sin token. Ensayado sólo el envío normal | `o1` |
| Receptor | 403 a otra identidad, sin `If-Match: *`, `GET` con token y filtrado por dueño | `k1-receptor-otra-identidad.txt` |

Cambia lo que el §4.2 describe para b0 y h: con este APK, ni la reapertura en frío sin desbloqueo ni el bloqueo quitado
dejan trabajar sin volver a ingresar.

