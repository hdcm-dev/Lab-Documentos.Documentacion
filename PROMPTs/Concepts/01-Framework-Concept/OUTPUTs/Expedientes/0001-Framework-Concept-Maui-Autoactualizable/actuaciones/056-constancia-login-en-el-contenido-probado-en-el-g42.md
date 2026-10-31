| Campo | Valor |
| --- | --- |
| Tipo | constancia |
| Fecha | 2026-10-31 |
| Autor | Presidencia de la mesa |
| Sigue a | 054, 055 |

# Constancia — login en el contenido y login tradicional, probados en el g42

## Hecho

- **Lo fusionado en Lab-Documentos (decisiones del PO del 2026-10-30):**
  - #37: la cara del ingreso y del desbloqueo es la puerta de sesión del contenido (`-p:FcPantallasDeSesion`).
  - #38: login tradicional con formulario propio (`auth.signInWithPassword`; el cascarón canjea y descarta la clave), `auth.lock` y botón «Bloquear», puente 1.2.0, diseño de la mesa de UX con el ojito y corrección de las páginas que tocaban datos antes de la sesión.
  - #39: documentación para desarrolladores al día, revisada por una mesa de especialistas.
- **Prueba en el moto g42 (2026-10-31, 06:54–06:55), operada por adb con la reserva libre y los dos candados tomados**, con la versión compilada desde `main` (#39):
  1. **Login con el formulario:** `encuestador` entró. Canje 1 625 ms y escrituras 183 ms; bitácora: `Ingresando --IngresoExitoso--> Activa`. Captura `E05/g42-02-sesion-activa.png`: barra de sesión con «Bloquear» y «Cerrar sesión», y el ofrecimiento de la seguridad del teléfono.
  2. **«Bloquear» sin la seguridad activada:** abrió el diálogo del sistema. El foco de la ventana pasó a `BiometricPrompt`; la captura sale vacía porque Android protege esa pantalla.
  3. **Cancelar el diálogo:** la app mostró «Cancelaste el desbloqueo» y quedó en `Activa`, sin bloquearse. Captura `E05/g42-03-cancelado.png`.
- **Lo que no se probó:** el desbloqueo completo con el patrón del g42, porque el patrón es del PO y la sesión no lo conoce ni debe conocerlo. Tampoco con el modo avión. El ciclo completo con un PIN de prueba en el emulador `fc-android-emu-hpdev` no corrió: el gestor de turnos no admitió el emulador porque el host estaba con carga 25 sobre 8 núcleos.
- **Ajuste de texto anotado:** al cancelar la *activación*, la banda dice «Cancelaste el desbloqueo». Debería decir «Cancelaste la activación».

## Pendientes

- Ciclo completo de desbloqueo (patrón o PIN de prueba, también sin red), en el emulador cuando el host lo admita, o en el g42 con el PO.
- Las 17 confirmaciones del dictamen 055.

## Pase

Archivo. El expediente sigue ARCHIVADO.
