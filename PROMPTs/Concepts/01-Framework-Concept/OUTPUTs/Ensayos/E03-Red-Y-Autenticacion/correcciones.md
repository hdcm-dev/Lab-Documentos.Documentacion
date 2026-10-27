# E03 — Correcciones del incremento (corrector)

Corrector del incremento red + autenticación, 2026-10-27 (UTC). Demo:
`LAB/Lab-Documentos/Lab-Documentos/Concepts/Framework-Concept/Demo` (sin versionar; respaldo previo a las correcciones
en `~/fc-work/demo/e03/respaldo-corrector/`, fuera del repositorio). Sin commits ni push.

Diseño actualizado: `DISENO-RED-Y-AUTENTICACION.md` §3.2, §3.3, §3.4, §3.5, §3.7, §3.8, §5 y la sección nueva §12.
El contrato del puente **no cambia** (P3): `SesionInformada` mantiene su forma y `ISesionDelUsuario` es interna del
cascarón. Por eso no se tocaron `contrato.json` ni la instantánea de la compuerta.

## Compuerta

`scripts/ci-local.sh` completo, `rc=0`, dos veces: antes del recorrido y al final (con el último cambio de la pantalla
de ingreso). Log final: `~/fc-work/demo/e03/corrector-ci-final.log`.

| Paso | Resultado |
| --- | --- |
| 1. Build sin MAUI, avisos como error | 0 avisos, 0 errores |
| 2. Core.Tests | 211 / 211 (antes 202; 9 casos nuevos o cambiados) |
| 3. Update.Tests | 102 / 102 |
| 4. Gate.Tests | 52 / 52 (contrato sin cambios) |
| 5. Publish del contenido | correcto |
| 6. APK android-arm64 | correcto |

APK del recorrido: Debug `android-x64`, modo Oidc, sha256 `ca4279888a8756225a91948d50477899f3b786e8fa521c6564dfa2bc8e48a3b4`
(copia en `~/fc-work/demo/e03/corrector/app-x64.apk`). Las capturas `i1`, `j1`–`j5`, `l1`, `l2`, `m1`, `n1`
y `n2` son de un APK anterior que sólo difiere en mostrar el motivo en la pantalla de ingreso: sha256
`2e473200ed61140a857b348ec0ca0203bbf158de53235e9384f48af9a1d304f2`.
Logcat del recorrido: `local/logcat/corrector.txt`.

## P0 — El reingreso entraba solo por la sesión SSO del emisor (H-2)

- **Corrección:** `FlujoOidc.UrlDeAutorizacion` agrega `prompt=login` (`ParametrosDeSesion.PromptDelIngreso`) a todo
  ingreso interactivo (`src/FrameworkConcept.Core/Auth/Oidc.cs`). No se agregó `end_session`: se mantiene la revocación
  RFC 7009 del cierre.
- **Prueba:** `FlujoOidcTests.LaUrlDeAutorizacionLlevaLoQuePideLaRfc` exige `prompt=login`.
- **Emulador:**
  - `j2`: cerrar sesión **con** red revoca (HTTP 200), y la sesión SSO de la app desaparece de `fc-keycloak`
    (`local/logcat/j2-sesiones-sso-tras-cierre-con-red.txt`). Así queda respondido lo que H-2 dejaba sin verificar.
  - `j3`: cerrar sesión **sin** red deja viva la sesión SSO (`local/logcat/j3-sesiones-sso-tras-cierre-sin-red.txt`,
    sesión `L3hY9Wkd`). Es el escenario de H-2.
  - `j4`: con esa sesión SSO viva, «Ingresar con tu cuenta» muestra el formulario y espera más de 30 s sin entrar.
  - `j5`: en un proceso nuevo y con la sesión SSO viva, Keycloak muestra «Please re-authenticate to continue» y pide la
    clave.
  - `n2`: lo mismo después de quitar el bloqueo de pantalla con el desbloqueo activado (equivale a la Revocada de h3).

## P1 — Red caída durante el ingreso: `Ingresando` para siempre (H-4)

- **Corrección:** `FallasDelEmisor.EsFalla(ex, ct)` (`Core/Auth/Oidc.cs`) trata como falla toda excepción salvo
  `ExcepcionDeAutenticacion` y la cancelación que pidió quien llama. Se usa en los tres `catch` de
  `SesionDelUsuario` (ingreso, renovación y revocación al cerrar). `ClienteDelReceptor` reintenta ante cualquier falla
  de transporte, no sólo `HttpRequestException`, `TaskCanceledException` o `IOException`.
- **Pruebas:** `FlujoOidcTests.WebExceptionEsUnaFallaDelEmisor`, `TodaExcepcionQueNoEsDeAutenticacionEsFalla` (5
  tipos), `LaExcepcionDeAutenticacionNoEsFalla`, `LaCancelacionPedidaNoEsFalla` y
  `IngresandoMasFallaVuelveAlEstadoPrevio`.
- **Emulador (`l1`, `l2`):** en frío, tocar «Ingresar» y activar el modo avión en el mismo comando. Queda
  `Ingresando --IngresoFallido--> SinCuenta` 0,1 s después de la falla, el botón deshabilitado con «Sin conexión» y sin
  rueda. Al volver la red, `EnLinea` y el botón se habilita sin tocar la app.
- **No verificado:** en este intento la falla del ingreso llegó como `HttpRequestException`. La variante con
  `WebException` del informe no se reprodujo en el ingreso, aunque en el mismo segundo la salud falló con
  `WebException`. Esa variante la cubre la prueba unitaria y el `catch` general.

## P1 — ANR al volver del navegador (H-3)

- **Corrección:** en `SesionDelUsuario.IngresarAsync`, la vuelta de `WebAuthenticator` se espera con
  `ConfigureAwait(false)`. El canje, las tres escrituras de configuración y el aviso del cambio ya no corren en el hilo
  principal mientras Android le devuelve el foco a la actividad. Se registran «volvió el navegador (hilo principal: …)»
  y «canje N ms, escrituras M ms».
- **Medición (7 ingresos, logcat):**

  | Ingreso | Canje (ms) | Escrituras (ms) |
  | --- | --- | --- |
  | 00:26:52 | 2121 | 2270 |
  | 00:28:45 | 310 | 995 |
  | 00:36:00 | 926 | 26 |
  | 00:42:52 | 1195 | 2286 |
  | 00:46:32 | 707 | 569 |
  | 00:51:58 | 811 | 2176 |
  | 00:53:46 | 1371 | 1522 |

  Todas con «hilo principal: False». Antes, esos 1,3 a 4,4 s corrían en el hilo principal, que tiene un plazo de 5 s
  para el `FocusEvent`.
- **Resultado:** 7 reingresos (4 con formulario completo y 3 con «re-authenticate») y **ningún ANR nuevo**. El único
  registro sigue siendo el de H-3: `dumpsys window lastanr` da «ANR time: Oct 26, 2026 11:41:28 PM» y en `/data/anr`
  sólo está `anr_2026-10-26-23-41-29-101`.
- **No verificado:** la causa. Que el trabajo en el hilo principal explique el ANR es una hipótesis compatible con lo
  medido. Antes el ANR salió 1 vez en 6 ingresos; 7 sin ANR no lo descartan del todo.

## P1 — Una huella nueva no invalida la clave (H-1): decisión de mesa

- **Decisión:** se mantiene P4 (huella, rostro, PIN o patrón, `BIOMETRIC_STRONG | DEVICE_CREDENTIAL`). Queda como
  **apartamiento declarado del borrador §4**, asentado en DISENO §3.4 y §12 y en el INFORME §5.
- **Fundamentos:**
  - Android sólo invalida por enrolamiento las claves exclusivamente biométricas.
  - Quien enrola una huella ya pasó por el PIN o patrón del teléfono, que también abre la clave.
  - Una clave sólo biométrica deja afuera a quien no tiene huella ni rostro, contra P4 y D-03 = T1.
  - Se conserva la invalidación al quitar el bloqueo de pantalla (`n1`).
- **Alternativa no implementada:** dos claves (una biométrica invalidable y otra de credencial).
- **Aviso al PO:** la decisión contradice un texto suyo (el borrador §4).

## P1 — `Vencida` y `Revocada` abrían la entrada sin prueba local

- **Corrección:** en frío, la entrada exige una prueba local.
  - `TransicionesDeSesion.AlArrancar(hayIdentidad, desbloqueoActivado)` devuelve `Bloqueada` o `SinCuenta`, nunca
    `Vencida`.
  - Si el refresh sellado venció, se decide después del desbloqueo (`DesbloquearAsync` → `SesionVencida`).
  - Si quitaron el bloqueo de pantalla, `SinCuenta` (antes `Revocada`).
  - `Bloqueada` + `ClaveInvalidada` → `SinCuenta` (antes `Revocada`).
  - En `SinCuenta` la identidad se olvida en memoria, así que `ObtenerDuenoAsync` no da dueño. Las filas pendientes
    conservan el suyo.
  - `Vencida` y `Revocada` con la entrada abierta quedan sólo dentro del proceso donde hubo ingreso o desbloqueo.
  - La pantalla de ingreso muestra el motivo también en `SinCuenta`.
- **Pruebas:** `TransicionesDeSesionTests`:
  - `ArranqueConIdentidadSinDesbloqueoPideLaCuenta`;
  - `EnFrioNuncaSeAbreLaEntradaSinPruebaLocal`, que recorre las cuatro combinaciones contra `EvaluadorDeAcciones`;
  - la fila `Bloqueada + ClaveInvalidada → SinCuenta`.
- **Emulador:**
  - `i1`/`i2`: con identidad guardada y sin desbloqueo, el arranque en frío da `SinCuenta`. La pantalla propia tapa el
    contenido y dice «Tu sesión venció: ingresá con tu cuenta. Lo pendiente se conserva y sale con ella.» Antes quedaba
    `Vencida`, con la entrada abierta.
  - `m1`: con el desbloqueo activado da `Bloqueada`, y el PIN lleva a `Activa`.
  - `n1`: después de quitar el PIN da `SinCuenta` (antes `Revocada`, h2).
- **Consecuencia aceptada:** sin desbloqueo activado, un arranque en frío sin red no deja trabajar hasta volver a
  ingresar (D-03 = T1: sin seguridad del teléfono se pide la cuenta).

## P1 — Carrera entre el dueño de la fila y el token

- **Corrección:**
  - `ISesionDelUsuario.ObtenerAccessTokenParaAsync(dueno, ct)` valida `PuedeEnviarFilaDe(dueno)` y obtiene el token,
    renovándolo si hace falta, bajo el mismo semáforo que toman `IngresarAsync` (al cambiar la identidad),
    `CerrarAsync` y la renovación.
  - El sincronizador lo pide justo antes de cada envío. Si da null, la fila no sale ni suma un intento.
  - `ClienteDelReceptor` pone ese token en el pedido y `ManejadorDeSesion` lo respeta.
  - Con cuenta, un pedido sin token no sale a la red: se contesta 401 local y la fila se reintenta.
  - `InformarNoAutorizadoAsync(tokenRechazado)` sólo renueva si el rechazado es el token actual de la sesión.
- **Emulador (`o1`):** en línea y con la sesión `Activa`, se registró una encuesta y salió al primer intento
  (`aa7d289c…` → 201, dueño `encuestador`). Es la regresión del envío.
- **No ensayado:** la carrera misma (una pasada con varias filas mientras cambia la sesión). Está corregida en el
  código, pero no hay prueba automática: el sincronizador es del cascarón MAUI y no tiene proyecto de pruebas.

## P1 — El receptor dejaba que otra identidad modificara una respuesta ajena

- **Corrección** (`tools/FrameworkConcept.Receptor/RecepcionDeRespuestas.cs`, `AutenticacionDelReceptor.cs`):
  - si la clave existe y su dueño no es el `sub` del token, 403: ni reenvío ni modificación;
  - el dueño se conserva siempre;
  - `If-Match: *` ya no coincide: modificar exige la versión;
  - con `--oidc-emisor`, `GET /respuestas` y `GET /respuestas/{clave}` exigen token y devuelven sólo las del `sub` (una
    ajena da 404);
  - `guion.sh respuestas` lee `salida/receptor/respuestas.json` en modo Oidc.
- **Ensayo (`k1-receptor-otra-identidad.txt`, con tokens reales de `encuestador` y `supervisora`):**

  | Pedido | Resultado |
  | --- | --- |
  | A crea | 201 |
  | GET sin token | 401 |
  | B lista | 0 respuestas |
  | B lee la de A | 404 |
  | B con `If-Match: *` | 403 |
  | B con la versión correcta | 403 |
  | A con `*` | 412 |
  | A con `"1"` | 200, versión 2 |

  La respuesta de A quedó intacta y a su nombre.
- **Efecto lateral:** al reimportar el realm, los `sub` de Keycloak cambiaron. Las respuestas viejas del almacén quedan
  con el `sub` anterior y ya nadie las puede modificar.

## Limpieza

- `fc-demo-receptor` y `fc-keycloak`: bajados (`guion.sh parar`, `keycloak.sh parar`). Sigue `fc-android-emu`, que es
  ajeno a este tramo.
- `bin/`, `obj/` y `.aspnet/` de la demo: borrados con el contenedor de compilación. `salida/` se conserva: no se
  versiona.
- Emulador `fc-android-emu-hpdev`:
  - la app quedó detenida (`am force-stop`) y el foco en el escritorio;
  - **sin PIN ni huella**: el PIN `1234` se puso para `m1` y se quitó en `n1`;
  - los datos de la app no se borraron.
- Fuera del repositorio, en `~/fc-work/demo/e03/`:
  - el respaldo previo a las correcciones (`respaldo-corrector/`);
  - los ayudantes de adb y de tokens (`corrector/`);
  - el APK evaluado (`corrector/app-x64.apk`);
  - los logs de compuerta: `corrector-ci*.log` y `corrector-apk*.log`.
