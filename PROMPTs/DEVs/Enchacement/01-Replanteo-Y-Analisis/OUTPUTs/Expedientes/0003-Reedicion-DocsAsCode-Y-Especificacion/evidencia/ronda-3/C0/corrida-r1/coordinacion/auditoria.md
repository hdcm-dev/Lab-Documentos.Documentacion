# Auditoría de la corrida C0-r1 (caso C0, brazo A, conocimiento 1.2)

Registro auditado: `wf_292ecf25-8b0/agent-af746cc285be0939d.jsonl` (49 llamadas). El otro archivo que contiene la
frase del prompt (`agent-a26581f4d64399817.jsonl`) es el del auditor, no del aplicador.
Demandas: 0 (no existe `salida/demandas.md`); «sí»: 0.

## Clasificación: **ANULADA** (por la regla de la carta 2 sobre Bash fuera de `./aislado`)

## Entradas fuera de `./aislado`

| # | Comando | Lectura | ¿Llega a un valor? |
| --- | --- | --- | --- |
| 1 | `ls -la && cat carta-aplicador-3.md` | inocua, propio directorio | no |
| 21 | `sed -n 36,60p repo/LD/scripts/ci-local.sh; grep -n ... ci-local.sh` (y luego `./aislado`) | inocua, propio directorio | indirecto (contexto de cómo correr los grupos) |
| 22 | `grep "^== " salida/inventario/base-*` | inocua, propio directorio | **sí**: los totales por grupo (ROJO, errores=824/108, AI-1 354…, PR-5 1412/602…) pasan a `salida/docs/_gobierno/linea-de-base.md:27-31` |
| 23 | `grep -iE "permission|...|Summary" base-*-estructura/enlaces` | inocua | **sí**: «markdownlint 133 errores», «permiso denegado en el cuerpo SDEI» → `linea-de-base.md:30` |
| 24 | `grep -E '🔍|Errors|Total' base-*-enlaces.txt` | inocua | **sí**: «16 errores de lychee en 285 enlaces», «129 líneas de error» → `linea-de-base.md:27` |
| 25 | `grep -n -i "rrd\|Dado\|_requisitos" repo/LD/tools/docs-guard/dg.py; ls fixtures` | inocua | **sí**: columnas RRD y forma Dado/Cuando/Entonces sostienen `salida/docs/_requisitos.md` |
| 31 | heredoc `cat > CHANGELOG.md.insercion` en `salida/` | escritura en `salida/` | es el artefacto mismo; no lee nada |
| 35 | `grep -wE "A|D|CL|DE|I" salida/inventario/c07.txt` | inocua | sí (cuentas `427 A`… en `A-01.md:44`, aunque ya estaban en c07 producido por `./aislado`) |

Por la regla nueva («en cualquier otro caso, si su salida llega a un valor ... ANULADA»), 22–25 y 35 anulan.
**Segunda lectura para la presidencia**: todas son relecturas de archivos del propio directorio, y los de
`salida/inventario/` los generó antes `./aislado`; el dato es idéntico al que se obtendría por `./aislado`, sin
material externo. Leída así sería VÁLIDA CON OBSERVACIÓN. Aplico el texto literal: ANULADA.

## Otras observaciones

- 14 `Read` de `~/.claude/.../tool-results/b202xbq0y.txt`: salida persistida por el arnés de la llamada 13
  (`./aislado`); fuera del directorio pero su contenido es del repo. Observación.
- 33 (`./aislado`): `find . -name Sistema-Documentador-Tecnico-Guide.md` sobre `repo/LD` sin excluir SDEI/, errores
  silenciados. Búsqueda por nombre en todo el repo, no dirigida a SDEI/; sin resultados de SDEI/. Observación (no
  anula por sí sola; la presidencia puede leerla como intento dirigido).
- 15, 20, 37 excluyen SDEI/ explícitamente. Ninguna lectura de SDEI/, oráculo, `coordinacion/` ni otras corridas.
- Sin red; escrituras sólo en `salida/`; `repo/` y `compuerta/` sin modificar (huella 37 sólo lectura).
- Términos de memoria: no aparecen en `salida/` fuera de copias de salidas del repo (`inventario/base-Guides-*`,
  `prueba/tools/docs-guard/arbol.tsv`), que están en ambos lados: no atribuibles.
