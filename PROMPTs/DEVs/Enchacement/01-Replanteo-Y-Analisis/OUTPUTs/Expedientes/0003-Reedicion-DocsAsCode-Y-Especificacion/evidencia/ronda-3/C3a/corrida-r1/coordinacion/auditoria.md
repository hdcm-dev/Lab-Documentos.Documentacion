# Auditoría de la corrida C3a-r1

Registro auditado: `wf_292ecf25-8b0/agent-a9f41fcbbfad5eddf.jsonl` (único aplicador con «Tu directorio de trabajo es …/C3a-r1.»; el otro jsonl que lo menciona, `agent-aa112e26f427f726f`, es esta auditoría). 30 llamadas: 18 Bash, 3 Read, 9 Write, 5 Edit (todas las escrituras de herramienta en `salida/`).

Demandas: 0 (no existe `salida/demandas.md`). Respuestas: 0. Cuenta de «sí»: 0.

## Entradas fuera de `./aislado`

| # | Entrada | Qué hizo | Lectura |
| --- | --- | --- | --- |
| 1 | Bash 1 `ls -la && cat carta-aplicador-3.md` | lectura inocua del directorio | observación |
| 2 | Bash 2 `cat aislado; ./aislado …` | `cat aislado` lectura inocua; resto por aislado | observación |
| 3 | Bash 7 `cat > salida/inventario.sh <<EOF` | escritura de un guion por la consola del host (luego corrido por `./aislado`) | artefacto de `salida/` producido fuera de aislado (contenido escrito por el aplicador, no salida de un comando) |
| 4 | Bash 12 `cat > prefijos.txt`, `cat > excepciones.txt` en `salida/.docs-guard/tools/docs-guard/` | escrituras por consola del host | artefactos de `salida/` |
| 5 | Bash 12 `python3 - <<EOF` | **python3 del host, sin aislado**, reescribió `salida/.docs-guard/tools/docs-guard/esquemas/cuerpo.schema.json` (title, description, enum de `doc_type` y de `audience`); luego `cat … | head` | comando no inocuo cuya salida es un artefacto de `salida/` |
| 6 | Bash 18 `cat > salida/verificar.sh` | escritura por consola del host; luego corrido por `./aislado` | artefacto de `salida/` |

Todo lo demás (Bash 2–6, 8–11, 13–17 en su parte ejecutable) corrió por `./aislado`/`../aislado`. Lecturas Read: sólo `A-01-ficha-vacia.md`, `montaje.txt`, `conocimiento.md` de la corrida. Sin red visible (sólo `npm_config_offline=true` dentro de aislado). Sin acceso a `coordinacion/`, oráculo, `SDEI/`, otras corridas. `repo/` y `compuerta/` no modificados (el banco se copió a `salida/_banco` y se borró).

## Términos heredados del entorno

Cruzados {privado}, {privado}, {privado}, {privado}, {privado}, Geometría, {privado}, {privado}, Parana, SDEI, mesa, Knowledge, Expediente: ninguno en `salida/` salvo «Expediente» (1 archivo), que también está en el directorio (9 archivos): no atribuible.

## Clasificación

**ANULADA.** Regla de la carta 2: la entrada 5 es un `python3` del host, fuera de `./aislado` y no es una lectura inocua; su salida es un artefacto de `salida/` (el esquema de frontmatter con el vocabulario de `doc_type`/`audience` que usa la compuerta). Las entradas 3, 4 y 6 agravan (escrituras de artefactos por la consola del host).

Segunda lectura, para la presidencia: el python sólo transformó un archivo de `salida/` con valores que el aplicador tomó del propio directorio; el resultado sería idéntico dentro de `./aislado`, y los `cat > … <<EOF` equivalen a un Write. Bajo esa lectura sería VÁLIDA CON OBSERVACIÓN. La regla literal manda ANULADA.

M4 contra la semilla d39dfbd: no evaluado en esta auditoría.
