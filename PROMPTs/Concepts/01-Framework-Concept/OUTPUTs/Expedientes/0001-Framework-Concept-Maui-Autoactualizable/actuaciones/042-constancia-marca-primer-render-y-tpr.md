| Campo | Valor |
| --- | --- |
| Tipo | constancia |
| Fecha | 2026-10-27 |
| Autor | Presidencia de la mesa |
| Corrige | — |

# Constancia — la marca `primer-render` y la nueva medición del TPR

El folio 040 dejó dos pendientes ligados: el TPR en el teléfono de gama media (PO) y el `primer-render` que no llegó en
5 arranques en frío sin canal (mantenedor de la demo). El 2026-10-27 el PO aprobó arreglar la marca, volver a medir y
probar en el moto g42 si estaba libre.

## Hecho

- **Causa.** La pantalla del emulador estaba apagada durante la medición del cierre. Con la pantalla apagada a
  propósito, el registro es idéntico al del cierre: `LaunchState: UNKNOWN`, «Activity pause timeout», ningún pedido
  del WebView y «sin Listo a los 10 s». Al encender la pantalla, el mismo proceso carga el contenido y registra la
  marca. La marca y su camino en el contenido estaban bien.
- **Arreglo** (PR en `hdcm-dev/Lab-Documentos`, `Concepts/Framework-Concept/Demo/`):
  - `scripts/guion.sh tpr` comprueba la pantalla y el bloqueo, y guarda el `LaunchState` de cada corrida;
  - `FrameworkConcept.Tools tpr` calcula el TPR por proceso, desde el inicio del proceso hasta la marca, y explica las
    corridas sin marca;
  - el cascarón deja escrito a los 10 s si el WebView no pidió el contenido;
  - `Gate.Tests/Medicion/LectorDeTprTests.cs` agrega 4 pruebas.

  `ci-local.sh` en verde (`rc=0`: Core 211, Update 102, Gate 56, APK arm64 0/0).
- **Emulador** `fc-android-emu-hpdev`, APK Release x64 sin depuración: 5/5 corridas `COLD` con marca; TPR máximo
  **12 451 ms** (9 641–12 451). No juzga el umbral. Se desinstaló la app, el emulador quedó en la pantalla de inicio y
  se liberó su reserva.
- **Moto g42.** NO MEDIDO. El candado de escenarios estuvo tomado por otra sesión de mayor prioridad durante todo el
  intento: de 12:16 a 14:20 (-03), con un `flock -n` por minuto en los últimos 45 minutos. El teléfono no se tocó.
- Registros en `../../../Ensayos/E03-Red-Y-Autenticacion/P1-TPR-EN-EMULADOR.md` §«Causa y nueva medición».

## Pendientes abiertos que siguen

- **TPR en el moto g42** (PO). La condición de revisión (2) de P1 sigue **abierta**, sin número nuevo. Para medir:
  APK Release arm64 y `scripts/guion.sh tpr` con el candado del teléfono tomado.
- Se cierra el pendiente «`primer-render` en arranque en frío sin canal».
- Siguen los del folio 040: volúmenes `fc-demo-keystore` y `fc-npm` (PO) y NO VERIFICADO del anexo §6 (mantenedor de la
  guía).

## Pase

Archivo. El expediente sigue ARCHIVADO.
