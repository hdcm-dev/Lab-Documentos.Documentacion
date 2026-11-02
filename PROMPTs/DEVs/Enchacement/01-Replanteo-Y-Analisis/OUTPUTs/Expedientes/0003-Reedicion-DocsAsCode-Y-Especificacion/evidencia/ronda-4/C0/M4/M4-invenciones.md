# M4 (invenciones) — caso C0, ronda 4

Corridas: `corridas-r4/C0-r1` y `corridas-r4/C0-r2`. Rutas relativas a cada corrida.

## Método
1. `citas.py <corrida> <salida.json>`: extrae toda cita `archivo:línea[-línea]` de `salida/` (excluye `salida/inventario/`, que son salidas crudas de grep) y comprueba que el archivo exista en `repo/` (o en la corrida) y que el rango esté dentro del archivo. Si la cita va seguida de «texto», verifica que el texto (normalizado: espacios y `**`) esté en las líneas citadas.
2. Muestra de 20 citas releídas a mano (contenido de la línea vs. lo que la ficha afirma).

## Resultado automático
| Corrida | Citas | OK | Archivo inexistente | Línea fuera | Texto citado ausente |
|---|---|---|---|---|---|
| C0-r1 | 66 | 65 | 0 | 0 | 0 |
| C0-r2 | 65 | 65 | 0 | 0 | 0 |

La única no-OK de r1 es `pagina-rota.md:1` en `salida/verif/par-rojo-verde.txt:7`: es un artefacto propio del par rojo/verde, no una cita al repo (no cuenta).

## Muestra manual (20)
| # | Corrida | Cita | Afirmación | Veredicto |
|---|---|---|---|---|
| 1 | r1 | `repo/LD/AGENTS.md:45-46` | «leídas en GitHub, sin sitio publicado» | Sostiene |
| 2 | r1 | `repo/LD/AGENTS.md:110` | alias SDD-B del servicio push privado | Sostiene |
| 3 | r1 | `repo/LD/tools/docs-guard/prefijos.txt:27` | `RD` registrado, prefijo del RRD | Sostiene |
| 4 | r1 | `repo/LD/.github/workflows/docs-guard.yml:75` | organización nombrada en `repository:` | Sostiene |
| 5 | r1 | `repo/LD/AGENTS.md:51` | `Guides/` heredado | Sostiene |
| 6 | r1 | `repo/LD/CHANGELOG.md:12-14` | RD-01, RD-21, RD-27 | Sostiene |
| 7 | r1 | `repo/LD/CHANGELOG.md:36` | etiqueta `sdei-v2.0.0-borrador` | Sostiene |
| 8 | r1 | `repo/LD/tools/docs-guard/excepciones.txt:7` | excepción AI-3 con huella para `AGENTS.md` | Sostiene |
| 9 | r1 | `docs-enlaces-semanal.yml:17-19` + semanal.sh | cron lunes 06:17, frescura 365 días | Sostiene (365 está en `semanal.sh`/`dg.py`, no en el yml citado: ancla incompleta, menor) |
| 10 | r1 | `repo/LD/AGENTS.md:107` | cambiar `AGENTS.md` es clase H | Débil: la línea es otra fila de la tabla P/H; la fila pertinente es la 105 (desvío de ancla, contenido real) |
| 11 | r1 | `repo/LD/AGENTS.md:31` | «nombra "Cómo intervenir"» | **NO SOSTIENE**: la línea 31 está vacía y `AGENTS.md` no contiene «intervenir». El hecho existe en `README.md`/`CHANGELOG.md`, pero el ancla es inventada |
| 12 | r2 | `repo/LD/README.md:16-17` | corpus de guías en Markdown, leído en GitHub | Sostiene |
| 13 | r2 | `repo/LD/tools/docs-guard/arbol.tsv:7-10` | hermanos `.Documentacion`, E2E, Geometria | Sostiene |
| 14 | r2 | `repo/LD/CHANGELOG.md:340-343` | delegación exp. 0001, PO, folio 007 | Sostiene |
| 15 | r2 | `repo/LD/CHANGELOG.md:160` | `DOC-SDT-0001 status: obsoleto` | Sostiene |
| 16 | r2 | `repo/LD/CHANGELOG.md:533` | «Eliminado» | Sostiene |
| 17 | r2 | `repo/LD/.github/workflows/docs-guard.yml:60` | runner autoalojado (etiqueta aliada) | Sostiene |
| 18 | r2 | `cuerpo.schema.json` (23 líneas) | diez campos más description, enum doc_type/audience | Sostiene |
| 19 | r2 | `repo/LD/tools/docs-guard/prefijos.txt:30` | `RD` en uso, del RRD | **NO SOSTIENE**: la línea 30 es `GP`; `RD` está en la 27 (ancla desplazada) |
| 20 | r2 | `prefijos.txt:8-40`, §1 fila 7 | «40 prefijos registrados» | **NO SOSTIENE**: el registro tiene 30 prefijos (21 internos + 9 externos, que la propia ficha enumera); 40 es el número de líneas del archivo. Cifra inventada/confundida |

Hallazgo extra de r2 (fuera de la muestra numerada): `repo/LD/AGENTS.md:53` para «lo heredado (`Guides/`) avisa» (D-08): la línea 53 es `scripts/ci-local.sh`; la pertinente es la 51. Desvío de ancla.

## Invenciones por corrida
- **C0-r1: 1** — ancla fabricada `repo/LD/AGENTS.md:31` («Cómo intervenir», CL-12). Desvío menor: `AGENTS.md:107` (fila contigua), 365 días citado a un yml que no lo dice.
- **C0-r2: 1** — cifra «40 prefijos registrados» (son 30). Desvíos de ancla con contenido real: `prefijos.txt:30` (RD está en 27) y `AGENTS.md:53` (es 51).
- Ninguna corrida cita archivos inexistentes ni líneas fuera de rango; ningún texto entre «» difiere de la línea citada.
