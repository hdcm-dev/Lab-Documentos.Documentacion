# Verificación independiente del cierre de la etapa 4 (2026-11-02)

> Verificador adversarial de `../E10/07-Cierre-Correcciones.md`. No me apoyé en el informe del corrector: comprobé los archivos y volví a correr las compuertas. No arreglé nada. Sin commit, push ni PR. No toqué archivos comunes. Sin turno de modelo, sin emuladores ni KVM. Mensajes ajenos a mitad de turno: ninguno. `{guía}` = carpeta de la guía 16 en LD; `{trabajo}` = carpeta de trabajo propia, fuera de los repos.

## 1. Veredicto

**Las cuatro correcciones están aplicadas y son correctas. Todas las compuertas dan rc 0.** Las huellas del registro coinciden. Quedan tres observaciones menores, ninguna introducida por las correcciones (§4).

## 2. Correcciones, comprobadas

| # | Comprobación | Resultado |
|---|---|---|
| 1 | README 08, l. 41 | Dice «se corrió con su criterio fijado antes… “Límites declarados”, corrida vigente». ok |
| 2 | `salidas-07.v2.json` frente a la copia de la `v1` en `E10/Evidencia-07/` (`diff` línea a línea) | Sólo cambian 3 líneas: `version`, `turno_id` (recurso → `<recurso>`) y `registro` (ruta absoluta a la bitácora → nombre de archivo). Las salidas son idénticas byte a byte. sha256 `5a8951ec…e32a`, igual al de `ejemplo.json`. ok |
| 2 | La `v1` salió del árbol | No queda ninguna `salidas-07.v1.json` en `{guía}`, y el sha de la `v1` (`89b1b15db48b`) no aparece en ningún archivo. Ver la obs. 1 |
| 2 | `CongeladorDeSalidas.cs` | `Path.GetFileName` + `Enmascarar` (regex `fecha-…-pid-n`), `Version = "v2"`. ok |
| 2 | Anexo H, l. 4432 | Fila ampliada con «(y estímulo de 15)». Anexos 13.000/13.000. ok |
| 3 | Libro l. 3091 y 3157 | Lo que dicen es verdad hoy. `5f07b12` es `origin/main` de Lab-Geometria, así que los enlaces resuelven. `g16/ai-layer-v1` existe sólo en local (`b4832d4`), sin remoto, con la carpeta `ai-layer` y el expediente 0002. ok |
| 3 | `compuerta-referencias.excepciones` | Tiene la línea `g16/ai-layer-v1` con su motivo. Es un archivo de la guía. ok |
| 4 | `Ejecucion/E10.md` | Tiene la sección «Fase 4 (ortotipografía), 2026-11-02» (l. 17). ok |

## 3. Compuertas, corridas de nuevo

| Compuerta | rc | Resultado |
|---|---|---|
| `tools/verificar.sh build`: turno `build` pedido por `[gestor-de-turnos]` (dueño `g16-verif-cierre-e4`), concedido y liberado; registros, volumen y etiqueta propios en `{trabajo}` | 0 | 208 s. 18 proyectos de prueba, todos «Passed!», 0 fallas; 15: 37/37. La consola de 15 lee las salidas con sha256 `5a8951ecbb34`. R-PRIV del build: 0 |
| `tools/recalcular-oraculos.sh` sobre mi registro `--fake` de 15 | 0 | 26/26 |
| `tools/contar.sh` | 0 | 59.385 / 60.000; Anexos 13.000 / 13.000 |
| `verificar-markdown.py guia` · `arbol` Examples/Conocimientos/Demos · `ejemplos` | 0 · 0/0/0 · 0 | 82 rutas, 4 exceptuadas |
| `compuerta-referencias.sh` | 0 | 0 rotas en 21 archivos |
| `compuerta-intervalos.py` (libro + R-LLM-2026-10-28 + mapa) | 0 | 28/28; 21/21 |
| `compuerta-rpriv.sh {guía}` con las listas de E11 | 0 | 0 hallazgos (historicos=1) |
| ídem **sin** `r-priv.historicos` | 0 | 0 hallazgos (historicos=0): la `v2` pasa sin excepción |
| Filtro U-7.1 (`grep -rniIF -f r-priv.lista`, incluidos `bin/` y `obj/`) | — | 0. El nombre del recurso de turnos tampoco aparece en `{guía}` |
| Rutas: `grep` de `Bitacoras`, `OUTPUTs`, `Documentacion/PROMPTs`, `/home/`, `/vm/`, nombres de equipos, IPs privadas y del tailnet, servicio de notificaciones | — | 0 (la única coincidencia de patrón numérico es «M.E.AI 10.11.0.» en `CableadoTests.cs:384`, que es una versión, no una IP) |
| `tools/medios/mermaid.sh` libro | 0 | ok |

Huellas (coinciden con el registro): libro `ffdfcf46705a…b046`; README 08 `04d5ea134b32…`; README 15 `55f68bcfabd2…`; `ejemplo.json` de 15 `15f72e329c52…`; `CongeladorDeSalidas.cs` `ff4d03a5276e…`; `salidas-07.v2.json` `5a8951ecbb34…e32a`.

## 4. Observaciones (no son fallas de las correcciones; no se arreglan acá)

1. **Referencia colgante a la `v1`.** El campo `nota` de `Examples/15-…/entradas/calibracion.v1.json` (l. 5) dice «… (corrida válida, entradas/salidas-07.v1.json)», un archivo que ya no está en el árbol. El contenido sigue siendo cierto (el estímulo es el mismo), pero la compuerta de referencias no revisa JSON. Para editarlo hace falta una `calibracion.v2` con otro sha. Propuesta: aclararlo en el README de 15 o dejarlo para una `v2` futura.
2. **Ejemplos que remiten a la bitácora** (la regla dice que no deben hacerlo). Estas menciones no traen ruta. Ya estaban antes de las correcciones y las verificaciones 4-1…4-3 no las señalaron:
   - `Examples/_Comun/…/AI/LectorDePrefijoCacheado.cs` l. 1 y `Examples/_Comun/…Pruebas/LecturaDelUsoTests.cs` l. 1: «procedencia en la bitácora de la recuperación».
   - `Examples/06-…/ejemplo.json` l. 2: «ver la bitácora de aplicación».
   - `Conocimientos/knowledge-…Specification.md` l. 572: «bitácora del prompt 02 de la guía 16, etapa E7».
   
   Son de bajo riesgo porque no dan rutas ni nombres. Igual conviene redactarlos como procedencia neutra («registro de trabajo no publicado; ver Anexo H»), con el mismo criterio que la `v2`. El de `ejemplo.json` de 06 se puede editar libremente: no tiene sha fijado.
3. `r-priv.historicos` de E11 tiene una entrada que ya no hace falta. Lo confirmé corriendo sin ese archivo: 0 hallazgos. Está fuera del repo; se puede retirar.
