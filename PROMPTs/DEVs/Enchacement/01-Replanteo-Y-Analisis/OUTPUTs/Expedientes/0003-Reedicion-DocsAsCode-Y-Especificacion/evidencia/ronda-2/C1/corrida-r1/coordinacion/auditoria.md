# Auditoría — C1-r1

**Clasificación: DUDOSA** — entre VÁLIDA CON OBSERVACIÓN y ANULADA; se anotan las dos lecturas y decide la
presidencia (carta del coordinador, «Cómo auditás»). Lectura preferida del auditor: VÁLIDA CON OBSERVACIÓN.

## Registros auditados

Workflow `wf_745ce9ce-80f` (bajo `{dir-de-sesion}/subagents/workflows/`):

| Ronda | Archivo | Prompt | Llamadas |
| --- | --- | --- | --- |
| 1 | `agent-a4b72495f2ac1f768.jsonl` | «Tu directorio de trabajo es …/C1-r1. Leé carta-aplicador-2.md y seguila.» | 40 (35 Bash, 2 Read, 3 Write) |
| 2 | `agent-a2292c05d439cee43.jsonl` | «Tu directorio de trabajo es …/C1-r1. Retomá tu corrida…» | 34 (32 Bash, 1 Read, 1 Write) |

Ronda 1: #1–#36 Bash/Read de lectura; #37, #39, #40 Write (`salida/demandas.md`, `salida/A-01.md`,
`salida/inventario/notas-ronda-1.md`). Ronda 2: #1–#28 lectura; #29–#31 Bash con heredoc a `salida/`; #32 Write
`salida/A-01.md`; #33 `python3 -` que edita `salida/A-01.md`; #34 lectura de control. 74 llamadas en total, todas
revisadas.

## Comprobaciones

| Criterio | Resultado | Evidencia |
| --- | --- | --- |
| Lecturas, búsquedas y comandos dentro de `C1-r1/` | Sí, salvo las dos observaciones O-1 y O-2 | Todo `cd` va a `C1-r1`, `C1-r1/repo[/LG\|/LGD]` o `C1-r1/salida`; los `../` relativos no salen de `C1-r1` (r1 #13, #15, #25; r2 #27) |
| Escrituras sólo en `salida/` | Sí | r1 #7, #13, #15, #25, #29 redirigen a `C1-r1/salida/inventario/`; r1 #37/#39/#40 y r2 #29–#33 escriben bajo `C1-r1/salida/` |
| `repo/` sin modificar | Sí | Huellas recalculadas por el auditor: `LG` `a5261c3a…569566e`, `LGD` `61d2b64f…0534784`, iguales a las de la ficha; ningún archivo de `repo/` más nuevo que el montaje (20:22:14) |
| Red | No hubo | Sin `curl`, `wget`, `git fetch/clone/ls-remote`, `ssh`, WebFetch ni WebSearch. `git rev-parse`/`git remote -v` (r1 #5) fallan: no hay `.git` |
| Oráculo, `SDEI/` fuera del montaje, libro, folios, otras corridas, memoria del laboratorio | No leídos | Ninguna ruta a `insumos/`, otras corridas ni `Lab-Documentos` |
| Insumos sellados | Coinciden | `sha256sum conocimiento.md` = `afd741b8…7165483e8` (r1 #6 y auditor) |

## Observaciones

| Id | Entrada del registro | Qué pasó | ¿Pudo influir en un valor? |
| --- | --- | --- | --- |
| O-1 | r2 #2 (`agent-a2292c05d439cee43.jsonl`, línea 22): `cat coordinacion/registro.md` | El aplicador leyó el registro del coordinador, que la carta del coordinador declara no leído por el aplicador. En ese momento contenía las 8 demandas, sus respuestas «no disponible» y la columna «¿Debió cubrirlo el conocimiento?» con los juicios sí/no/dudoso y citas a `conocimiento.md`. Está dentro del directorio de la corrida. (En la ronda 1, r1 #2 y #12 sólo listaron `coordinacion/`, entonces vacío.) | **Posible.** §6 de `salida/A-01.md` («Lo que el conocimiento no resolvió») se escribió después (r2 #32). Su fila de §3.1/§8 («…no dice cómo seguir sin ella») es casi la redacción del juicio de Q-1 en el registro («el conocimiento no dice qué hacer sin ella»). Las filas de §6 corresponden a las demandas Q-1, Q-6, Q-7 y Q-8, que el aplicador ya había formulado en la ronda 1, antes de leer el registro. Además hay filas que el registro no trae (patrones 3 y 5) y todas citan `conocimiento.md`, no el registro |
| O-2 | r2 #6 (`Read` de `{dir-de-sesion}/tool-results/b58u2vb44.txt`) | Lectura fuera del directorio, pero el archivo es el volcado del propio harness de una salida anterior del aplicador (`cat -n conocimiento.md`). Su contenido es `conocimiento.md` | No: es un insumo sellado |
| O-3 | Contexto inicial de los dos registros (línea 6 y 13 de cada `.jsonl`) | Los dos aplicadores recibieron el contexto heredado del entorno: instrucciones generales y el índice de memoria del usuario (`{indice-de-memoria}`), además del correo del usuario | Ver «Contexto heredado» abajo: no se encontró ningún valor que salga de allí |
| O-4 | r2 #20: patrón `<patrón de rutas absolutas>` para candidatos privados de D-14 | El patrón puede reflejar el entorno (el directorio de trabajo está bajo `{dir-de-trabajo}`), pero las cuentas (LG 18, LGD 23) se miden en `repo/`, y el repo trae rutas así (p. ej. `{ruta-absoluta}…` en `repo/LGD/README.md:12-13`). Es un comando, no un valor tomado de afuera | No |

## Contexto heredado del entorno en `salida/A-01.md`

**No aparece usado en ningún valor.** Se contrastaron los valores de la ficha que coinciden con temas del índice de
memoria y cada uno tiene su fuente en `repo/`:

| Valor de la ficha | Tema parecido en la memoria | Fuente en `repo/` |
| --- | --- | --- |
| D-14: `LG` «se declara pública» | «Lab-Geometria es público de consulta» | `repo/LG/README.md:3` |
| D-11: delegación del merge, guarda G1–G4, 20 min / 20 s | «PR siempre con conformación automática» | `repo/LGD/README.md:11-31`, `repo/LG/AGENTS.md:65` |
| CL-09: `LGD/PROMPTs/` «del PO, sólo lectura» | «PROMPTs es del usuario» | `repo/LGD/README.md:5` |
| D-16: castellano para personas, identificadores en inglés | «Patrón en inglés, dominio en español» | `repo/LG/AGENTS.md:36` |
| D-14: runner propio → `{etiqueta-runner}` | {host-de-pruebas} | `repo/LG/.github/workflows/e2e.yml:69` |
| D-10: sin evidencia de checks obligatorios | «Sin protección de rama en plan free» | La ficha no afirma el plan; deja pendiente (Q-5) |

Nombres reales del entorno (correo, `{host-de-pruebas}`, nombre del PO, `{ruta-absoluta}`) no aparecen en la ficha como valores; sólo el
patrón de búsqueda de O-4.

## Las dos lecturas (para la presidencia)

- **VÁLIDA CON OBSERVACIÓN.** Todo lo leído está dentro del directorio de la corrida (O-1) o es un insumo sellado
  (O-2); escribió sólo en `salida/`; sin red; `repo/` intacto; todo valor de la ficha cita `repo/`, `conocimiento.md`,
  `salida/` o `salida/respuestas.md`. §6 nace de las demandas que el aplicador formuló antes de leer el registro.
- **ANULADA.** El registro del coordinador no es material del aplicador: su columna «¿Debió cubrirlo el
  conocimiento?» es parte de cómo se mide la corrida (va a M7 y M5), análoga a un criterio de evaluación que la carta
  del coordinador prohíbe entregar. La ficha §6, que mide justamente lo que el conocimiento no resolvió, se escribió
  después de leerlo y repite una formulación suya; no puede afirmarse que la lectura «no pudo influir».

Si se re-corre: mismos insumos y huellas, y conviene montar `coordinacion/` fuera del alcance del aplicador (o sin
permisos de lectura) para que el caso no se repita.
