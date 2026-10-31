| Campo | Valor |
| --- | --- |
| Tipo | constancia |
| Fecha | 2026-10-31 |
| Autor | Presidencia de la mesa |
| Sigue a | 056 |
| Cierra | El pendiente «ciclo completo de desbloqueo» de la 056 |

# Constancia — desbloqueo local probado de punta a punta, también sin red

## Hecho

- **Dónde.** Emulador `fc-android-emu-hpdev` (Android 13, API 33), con turno de `recurso.sh emu levantar`. Las sesiones GDA.Core.APP y MovPark VT liberaron los dos lugares, que tenían ocupados. APK x64 compilado desde `main` (Lab-Documentos #39). El PIN de prueba `1234` se puso con `locksettings` y se quitó al terminar. No se usó la credencial del PO.
- **Ciclo (16:50–16:59), operado por adb**, con la bitácora `FC` como evidencia:
  1. Formulario con un campo vacío: aparece la validación «Escribí tu clave» y no se llama a la sesión.
  2. Ingreso de `encuestador` con el formulario: canje 2 010 ms, `Ingresando --IngresoExitoso--> Activa`.
  3. «Bloquear» sin la seguridad activada: abre `BiometricPrompt`. Con el PIN, `desbloqueo con la seguridad del teléfono activado` y `Activa --Bloquear--> Bloqueada`. Aparece la pantalla «Desbloqueá la app».
  4. **Modo avión** (`airplane_mode_on = 1`): `red: SinRed`.
  5. «Desbloquear» sin red: `BiometricPrompt`, PIN, `Bloqueada --DesbloqueoExitoso--> Activa`. La renovación del token falla en segundo plano sin frenar la entrada, como fija P4, y la app opera con la banda «Sin conexión. Lo que hagas se guarda y se envía cuando vuelva».
  6. Bloquear otra vez y cancelar el diálogo: no hay `DesbloqueoExitoso`, así que la app sigue bloqueada.
- **Capturas:** `Ensayos/E05-Login-En-El-Contenido/emu-01` a `emu-05`. Las del diálogo del sistema salen vacías porque Android protege esa ventana.
- **Junto con la 056 (g42 físico):** quedan probados el login en el contenido, el login tradicional, el diseño de la mesa de UX, el bloqueo, el desbloqueo local y el trabajo sin conexión. El desbloqueo con el patrón del g42 no se probó, porque es una credencial del PO. El mecanismo es el mismo (`DEVICE_CREDENTIAL`).

## Cierre del montaje

Se bajaron el emulador (turno liberado), los dos túneles efímeros, Keycloak y el receptor de la demo. La app se desinstaló del g42.

## Pendientes

- Las 17 confirmaciones del dictamen 055.

## Pase

Archivo. El expediente sigue ARCHIVADO.
