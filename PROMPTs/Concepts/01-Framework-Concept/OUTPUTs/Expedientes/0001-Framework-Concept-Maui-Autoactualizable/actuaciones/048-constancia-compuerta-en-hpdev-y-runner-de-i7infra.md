| Campo | Valor |
| --- | --- |
| Tipo | constancia |
| Fecha | 2026-10-29 |
| Autor | Presidencia de la mesa |
| Corrige | 046 (frase sobre los jobs tomados por `i7infra-runner-dev`) |

# Constancia — la compuerta corrió en hpdev; el runner de i7infra toma jobs

## Hecho

- **Compuerta y APK en hpdev.** El PR #34 de Lab-Documentos tocó `Demo/` y disparó el workflow completo
  `framework-concept-demo` (run `40847315104`, 2026-10-29, de 09:08 a 09:14 UTC). Según el `runner_name` de la API de
  jobs, `alcance`, `compuerta` y `apk` corrieron en `hpdev-runner-dev` y terminaron en verde. Es la primera vez que la
  compuerta y el APK de la demo corren en hpdev. Se cierra el pendiente que abrió la 043 («NO VERIFICADO: que
  `hpdev-runner-dev` pase la compuerta y construya el APK de la demo»). El entorno de ese runner se verificó: SDK
  10.0.403, maui-android 10.0.110, sin `docker.sock` ni KVM.
- **El runner de i7infra toma jobs.** En esa misma corrida, `fw-ok` corrió en `i7infra-runner-dev`, igual que el
  `docs-guard` del PR (run `40847315032`). Antes, en el PR #34 de Lab-Documentos.Documentacion, el job `verificar` también
  había corrido ahí (run `40846896758`). Los tres son controles livianos y salieron en verde. Esto corrige la 046, que
  decía que desde la vuelta de i7infra ese runner no había tomado ningún job: era cierto cuando se escribió, pero dejó de
  serlo después. Mientras el PO no lo pare, para saber dónde corrió un job hay que leer `runner_name`.
- **La ia-db queda para el reindexado único.** El índice `ia-db/indexes/12_Framework-Concept.md` todavía cita los IDs
  sin el prefijo `FC-`. Por acuerdo con la sesión del expediente 0002, no se toca acá: entra en su reindexado único, que
  renueva el `base_commit` del manifiesto. La lista de cambios ya se le pasó.

## Pendientes abiertos que siguen

- **Parar `i7infra-runner-dev`** (PO).
- **TPR en el g42 por su definición** (PO): hace falta que la marca viaje por el puente (folio 047).
- **Reindexado de la ia-db** (sesión del expediente 0002).
- **Historia del repositorio público** (PO): decidir si se reescribe para borrar los datos redactados en 044 y 045.

## Pase

Archivo. El expediente sigue ARCHIVADO.
