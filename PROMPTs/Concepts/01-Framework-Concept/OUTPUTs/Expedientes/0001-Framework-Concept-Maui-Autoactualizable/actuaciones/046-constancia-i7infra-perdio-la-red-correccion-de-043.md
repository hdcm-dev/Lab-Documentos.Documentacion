| Campo | Valor |
| --- | --- |
| Tipo | constancia |
| Fecha | 2026-10-28 |
| Autor | Presidencia de la mesa |
| Corrige | 043 (causa de la «caída», runner y volúmenes) |

# Constancia — i7infra perdió la red: corrección de la 043 y recuperación de contenidos

La noche del 2026-10-28 i7infra volvió a ser accesible. El PO pidió revisar qué se había avanzado ahí sobre el
Framework Concept e integrarlo en hpdev, que sigue siendo la máquina principal. Una mesa de recuperación revisó i7infra
en modo lectura, con verificación adversarial. Esta constancia corrige lo que la 043 asentó sin poder comprobarlo y deja
registrado qué se recuperó.

## Correcciones a la constancia 043

- **i7infra no dejó de funcionar.** El 2026-10-28 a las 00:50 (-03) se le cortó la red, pero la máquina siguió encendida:
  arrancó el 12-10 y no se reinició desde entonces (16 días de uptime el 28 a la noche). Volvió a ser accesible el mismo 28 a la noche. La decisión de trabajar desde
  hpdev no cambia, e i7infra queda de sólo lectura para esta línea.
- **Runner.** `i7infra-runner-dev` volvió a registrarse el 28 a las 17:03 (-03) y, después de un corte, otra vez a las
  18:39, con las mismas etiquetas que `hpdev-runner-dev`. Por eso, un job `[self-hosted, i7infra-dev]` puede caer en
  cualquiera de los dos. Según el `runner_name` de la API de jobs, el 28 corrieron 11 jobs en `i7infra-runner-dev`, todos
  antes del corte (de 00:19 a 00:48), entre ellos la compuerta y el APK de la demo. Todos los posteriores corrieron en
  `hpdev-runner-dev`, y desde que i7infra volvió no tomó ninguno. La compuerta y el APK siguen sin correr en hpdev. Para
  que una corrida pruebe hpdev, hay que leer ese campo.
- **Volúmenes.** `fc-demo-keystore` y `fc-npm` no se perdieron con la caída: los borró la sesión FC el 2026-10-27 a las
  12:14 (-03), por decisión del PO tomada ese mismo día. El folio 040 los daba como pendientes de esa decisión. El cierre
  del pendiente de los volúmenes no cambia. El volumen `fc-nuget` que hoy aparece en i7infra lo recreó el intento del 28
  a las 00:15 (ver abajo); el folio 040 no está mal.
- **Último acto.** No fue la constancia 042. Entre las 00:13 y las 00:21 del 28, en i7infra, hubo un intento de medir el
  TPR en el g42: se compiló una APK Release arm64 (26 991 621 B, `sha256 8389bafc…6a0c1e`, sin avisos ni errores). La
  espera del candado del teléfono terminó cortada a las 03:49 sin haberlo tomado, y su registro de medición quedó vacío.
  Ese intento no produjo ningún dato.

## Hecho

- **No había trabajo sin publicar.** En i7infra no hay commits de FC fuera de GitHub. Sus worktrees están limpios y
  apuntan a commits que `main` ya tiene. Los archivos sueltos de sus clones principales son borradores del 25 y 26 que
  `main` supera, o versiones sin redactar de lo que se publicó redactado (folios 039, 044 y 045). Esos no se publican.
- **Se recupera al repositorio** `Ensayos/E03-Red-Y-Autenticacion/local/logcat/h-anr-dropbox.txt`, que cita
  `E03/INFORME.md` y no estaba en el repositorio. La entrega de la redacción S2 lo listó entre el material excluido (196 KB).
  Se revierte esa exclusión porque es la única fuente de una cita vigente y no tiene datos sensibles: es un volcado del
  emulador que sólo nombra paquetes del sistema y `com.frameworkconcept.demo`, sin IP ni rutas del anfitrión (las únicas
  rutas son internas del emulador: `/data/app`, `/apex`).
- **Respaldo privado.** Los 19 registros crudos de `E02/correcciones-evidencia/`, el `ci-local-final.log` de E03, la APK
  x64 del corrector de E03 que fija `P1-TPR-EN-EMULADOR.md`, las respuestas del receptor de E03 y los guiones de medición
  del g42 se copiaron a la carpeta privada de rescate de hpdev, fuera de los repositorios, con sus sha256. Las APK y los
  paquetes de E01 ya estaban respaldados con los mismos hashes.
- **Pérdida asentada.** Los registros de la carpeta de trabajo de la demo que citan `E02/INFORME.md` y `rojos-auth.md`
  no existen en ninguna de las dos máquinas. Esa evidencia se perdió. Los textos históricos no se reescriben.
- **IDs propios.** El cambio a IDs `FC-` (Lab-Documentos #33, merge `0989a15`) no tenía constancia y queda asentado acá.
  Los IDs del Framework Concept chocaban con los del cuerpo SDEI y de otras guías del repositorio.

## Pase

Archivo. El expediente sigue ARCHIVADO.
