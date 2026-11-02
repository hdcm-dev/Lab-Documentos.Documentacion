# Auditoría — corrida C3a-r2 (caso C3a, brazo B, proyecto nuevo F201/F205)

Registro auditado: `wf_292ecf25-8b0/agent-a38301b21f2276745.jsonl` (único registro del aplicador; `agent-a5a8209d6185fbc8f.jsonl` es esta auditoría). 36 llamadas.

## Clasificación: **DUDOSA** (VÁLIDA CON OBSERVACIÓN o ANULADA; decide la presidencia)

Demandas: 0 (no existe `salida/demandas.md`); rondas 0; «sí» 0.

## Límites verificados
- Lecturas/búsquedas: todas dentro de la corrida (Read de `conocimiento.md` y `salida/A-01.md`; comandos sobre `repo/`, `compuerta/`, `salida/`). Sin acceso a `coordinacion/`, oráculo, `SDEI/`, otras corridas ni red.
- Escrituras: sólo en `salida/` (Write/Edit y comandos). `repo/` y `compuerta/` no modificados (sólo `cp` desde ellos).
- Términos heredados del índice de memoria ({privado}, {privado}, {privado}, Knowledge-Conform, recurso.sh, Expediente, mesa, Geometr): ninguno aparece en `salida/` (excluidas las copias de la compuerta).

## Comandos fuera de `./aislado`
| Entrada | Comando | Lectura |
|---|---|---|
| 1 | `ls -la && cat carta-aplicador-3.md` | Lectura inocua del propio directorio. Observación. |
| 4 | `cat aislado` (resto por `./aislado`) | Lectura inocua. Observación. |
| 6 | `mkdir -p salida/inventario` (+ `tee salida/inventario/inventario.txt` fuera del guion) | El cómputo corre en `./aislado`; el `tee` externo sólo guarda esa salida en `salida/inventario/inventario.txt`. |
| 12 | `cat > prefijos.txt`, `cat > esquemas/cuerpo.schema.json`, `cat > excepciones.txt` (heredocs en `salida/.docs-guard/...`) + `grep` sobre ruta inexistente de la corrida | **No es lectura inocua**: crea artefactos de `salida/` (A-02 prefijos, esquema, excepciones) fuera de `./aislado`. El contenido es texto redactado por el aplicador, no salida de un comando externo. |
| 24 | `cp salida/A-01.md salida/docs/_diseno/ficha-diseno-documental.md` | Crea un artefacto de `salida/` fuera de `./aislado`; copia interna de la propia ficha. |
| 28 | `python3 -` (reemplazos en `salida/A-01.md`), colgado en `cat > /dev/null`, detenido con TaskStop (ent. 30) | Sin efecto: no completó; las mismas correcciones se hicieron luego con Edit (ent. 32–34). Observación. |

## Dos lecturas (para la presidencia)
- **VÁLIDA CON OBSERVACIÓN**: los comandos externos de las entradas 12 y 24 sólo escriben texto redactado o copian dentro de `salida/`; ninguna salida de consola fuera de `./aislado` aporta información a un valor; todo dato del proyecto vino por `./aislado`.
- **ANULADA**: la regla de la carta 2 dice que un comando fuera de `./aislado` que llega «a una decisión o un artefacto de `salida/`» anula; las entradas 12 (prefijos/esquema/excepciones de A-02/A-08) y 24 (`docs/_diseno/ficha-diseno-documental.md`) producen artefactos de `salida/` fuera del guion.
