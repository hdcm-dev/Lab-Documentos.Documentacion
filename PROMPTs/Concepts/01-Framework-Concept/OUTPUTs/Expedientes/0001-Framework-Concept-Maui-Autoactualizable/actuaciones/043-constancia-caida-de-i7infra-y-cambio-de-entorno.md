| Campo | Valor |
| --- | --- |
| Tipo | constancia |
| Fecha | 2026-10-28 |
| Autor | Presidencia de la mesa |
| Corrige | — |

# Constancia — caída de i7infra y cambio de entorno

El 2026-10-28 a las 00:50 (-03) dejó de funcionar i7infra, la máquina donde corrían el runner, los volúmenes de la
demo y el candado de escenarios. La máquina principal pasa a ser hpdev. Esta constancia deja asentado qué cambió para
los pendientes del expediente.

## Hecho

- **Trabajo.** No se perdió nada del expediente. El último acto fue la constancia 042 (2026-10-27, 14:22), y la guía,
  la demo y el expediente están publicados en `hdcm-dev/Lab-Documentos` y `hdcm-dev/Lab-Documentos.Documentacion`.
- **Runner.** El trabajo de `i7infra-runner-dev` lo toma `hpdev-runner-dev` (organización `hdcm-dev`). Tiene las
  mismas etiquetas que el anterior más `hpdev`, así que los workflows no cambian. El 2026-10-28 corrieron en hpdev los
  jobs `alcance` y `fw-ok` de `framework-concept-demo`, con `fw-ok` en verde, y `docs-guard` de Lab-Documentos. En esas
  corridas los jobs `compuerta` y `apk` se saltaron, porque los PR no tocaban `Demo/`. La única corrida del día con
  `compuerta` y `apk` en verde fue entera en `i7infra-runner-dev`, antes de la caída. **NO VERIFICADO:** que
  `hpdev-runner-dev` pase la compuerta y construya el APK de la demo.
- **Keystore de la demo.** El volumen `fc-demo-keystore` estaba en i7infra y se perdió. Guardaba el `debug.keystore`
  del SDK de Android con que `scripts/guion.sh apk` firma el APK de depuración. Si el volumen no existe, `guion.sh apk`
  lo crea y el SDK genera otra clave. Lo único que se pierde es poder instalar un APK nuevo encima de uno firmado con
  la clave vieja. No queda ninguno instalado: los folios 041 y 042 retiraron la demo del g42 y del emulador. El volumen
  `fc-npm` también se perdió, pero era caché y se vuelve a crear solo.
- **Candado de escenarios.** El candado `escenarios.lock` (`flock`), que reservaba el moto g42 entre sesiones, vivía en
  i7infra. En hpdev no hay ninguno.
- **Emulador.** `fc-android-emu-hpdev` ya estaba en hpdev y sigue ahí, detenido, con su volumen
  `fc-android-emu-hpdev-home`. Al encenderlo para medir hay que dejar la pantalla prendida (folio 042).
- **PR #14 de Lab-Documentos** (`cierre/0001-tpr-emulador`, del folio 040). Decía que el TPR en el emulador «no se
  obtuvo». La corrección del folio 042 (`2d42377`) ya está en `main`, en los cuatro archivos que tocaba el PR: la nueva
  medición en `01-Actualizacion-Sin-Tienda.md`, `99-Anexos.md` y `Demo/README.md`, y en `Developer-Guide.md` la causa y
  cómo medir. Fusionar #14 devolvería la afirmación vieja, y en esos cuatro archivos da conflicto. El 2026-10-28 se
  cerró sin fusionar y se borró su rama. Lo único que aportaba y `main` no tenía, el enlace a `P1-TPR-EN-EMULADOR.md`
  en la tabla de enlaces del anexo, va en el PR #29 junto con la fila del folio 042, que la guía cita y no enlazaba.

## Pendientes abiertos que siguen

- **TPR en el moto g42** (PO). La condición de revisión (2) de P1 sigue abierta. Antes de tocar el teléfono hay que
  definir un candado en hpdev y avisar al PO.
- **Compuerta y APK de la demo en `hpdev-runner-dev`** (mantenedor de la demo). Sigue sin verificar. La primera corrida
  que toque `Demo/` lo muestra.
- **NO VERIFICADO del anexo §6** (mantenedor de la guía). La fila «Corrida del workflow con `run_id` en
  `i7infra-runner-dev`» ya no se puede cumplir tal como está escrita: pasa a `hpdev-runner-dev`. El glosario del anexo
  (término «Runner») también nombra el runner viejo. El resto de la tabla no depende de i7infra.
- Se cierra el pendiente «decidir si se borran los volúmenes `fc-demo-keystore` y `fc-npm`» (folio 040): los volúmenes
  ya no existen y `guion.sh` los vuelve a crear.

## Pase

Archivo. El expediente sigue ARCHIVADO.
