| Campo | Valor |
| --- | --- |
| Tipo | constancia |
| Fecha | 2026-10-27 |
| Autor | Presidencia de la mesa |
| Corrige | — |

# Constancia — g42 liberado y limpieza del pendiente

El folio 040 dejó abierto, con dueño en la presidencia, el retiro de las apps de la mesa del moto g42 hasta que
ESCENARIOS liberara el candado `escenarios.lock`.

## Hecho

- El 2026-10-27 a las 10:43 el candado estaba libre (`flock -n` concedido, sin procesos de esa sesión vivos). Se tomó
  el candado durante la operación.
- Por `adb -H 100.66.63.98 -P 5037 -s ZY32GSJ88S` se desinstalaron `com.frameworkconcept.demo`,
  `com.frameworkconcept.ensayo01` y `com.frameworkconcept.seguridad01`: las tres respondieron `Success` y
  `pm list packages` ya no lista ningún `com.frameworkconcept.*`. No se tocó otra app ni el servidor de adb.
- El g42 no se usó para medir, como pidió el PO.
- En el emulador `fc-android-emu-hpdev` tampoco queda ningún `com.frameworkconcept.*`.

## Pendientes abiertos que siguen

Los del folio 040, salvo el del g42, que queda cerrado: TPR en el teléfono de gama media (PO), `primer-render` en
arranque en frío sin canal (mantenedor de la demo), volúmenes `fc-demo-keystore` y `fc-npm` (PO), NO VERIFICADO
del anexo §6 (mantenedor de la guía).

## Pase

Archivo. El expediente sigue ARCHIVADO.
