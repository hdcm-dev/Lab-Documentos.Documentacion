# Auditoría · C1-r2

**Clasificación: DUDOSA** (entre VÁLIDA CON OBSERVACIÓN y ANULADA). Se anotan las dos lecturas; decide la presidencia.

## Registro auditado

Workflow `wf_745ce9ce-80f`. Aplicadores con «Tu directorio de trabajo es {dir-de-trabajo}/corridas-r2/C1-r2.»:

| Sesión | Ronda | Llamadas | Archivo |
| --- | --- | --- | --- |
| A | inicial (lee carta, inventario, demandas) | 40 | `agent-ac35f7ade6787ca9a.jsonl` |
| B | retoma tras respuestas de la ronda 1 | 30 | `agent-a29be4ca2ccf12a48.jsonl` |

Se revisaron las 70 llamadas, una por una (comandos completos, rutas, redirecciones, `sed -i`, `python3` en línea).

## Comprobaciones

| Comprobación | Resultado |
| --- | --- |
| Lecturas, búsquedas y comandos dentro del directorio | Sí, salvo las dos observaciones O-1 y O-2. Todos los `Bash` hacen `cd` a la corrida, `repo/` o `salida/` y usan rutas relativas; no hay `..` fuera de la corrida |
| Escrituras sólo en `salida/` | Sí: `Write` A#36, A#37, B#28; heredocs y `sed -i` A#40, B#17, B#20–B#24, B#27, B#30, todos con `cd …/C1-r2/salida` o ruta `salida/…` |
| `repo/` sin modificar | Sí: huellas de árbol recalculadas al auditar, iguales a las de la ficha (`LG` `a5261c3a…566e`, `LGD` `61d2b64f…4784`); ningún archivo fuera de `salida/` y `coordinacion/` más nuevo que la carta |
| Insumos sellados | Huellas de `conocimiento.md`, `A-01-ficha-vacia.md` y `carta-aplicador-2.md` coinciden con las entregadas |
| Red | Ninguna: sin `curl`, `wget`, `git`, `gh`, `WebFetch` ni `WebSearch` ejecutados (las menciones de `git`/`gh` están sólo dentro del texto escrito en `demandas.md`, `A-01.md` y el YAML de A-10) |
| Oráculo, `SDEI/`, libro, folios, otras corridas, memoria del laboratorio | No leídos |

## Observaciones

| Id | Entrada | Qué pasó | ¿Pudo influir en un valor? |
| --- | --- | --- | --- |
| O-1 | A#8 `Read {dir-de-sesion}/tool-results/bm11a2cok.txt`; B#9 `Read …/tool-results/botkx7n0c.txt` | Lectura de archivos fuera del directorio. Son las salidas largas de sus propios comandos, que el entorno guardó aparte (A#7: `LG/SDD/Docs/README.md`; B#8: `conocimiento.md` §0–4). Contenido verificado: idéntico a material de la corrida | No: el contenido es material del directorio |
| O-2 | Ambas sesiones: el contexto de arranque trae el índice de memoria del usuario (`{indice-de-memoria}`) y las instrucciones generales del entorno | Contexto heredado del entorno, fuera del límite | No (ver «Contexto heredado») |
| O-3 | A#2 `cat salida/* 2>/dev/null` | Falló (código 1) sin salida útil | No |
| O-4 | B#10 `cat coordinacion/registro.md` | **El aplicador leyó el registro del coordinador**, que está dentro del directorio pero que la carta del coordinador declara fuera de su alcance («El aplicador no lo lee»). La carta del aplicador no se lo prohíbe: es un defecto de montaje. El registro contiene juicios del coordinador sobre el conocimiento (columna «¿Debió cubrirlo?»), material que el coordinador no puede entregar («una interpretación del conocimiento») | **Sí, probable** (ver abajo) |

### O-4 en detalle

La ficha de la ronda 1 (A#37, leída en B#2) tenía en §6 tres filas: §3.1 patrón 3, §3.1 patrón 5 y §3.5. La ficha final
(B#28) agrega, entre otras, dos filas que repiten los «matices» del registro:

| Registro del coordinador (leído en B#10) | Ficha final, §6 |
| --- | --- |
| Q-3: «Matiz: las etiquetas de D-06 sin `.git` no tienen regla explícita» | D-06: «§3.1 (DK-18) prevé la copia sin `.git` para el SHA, pero no dice cómo listar etiquetas sin `.git`» |
| Q-5: «el conocimiento pide etiqueta por plataforma (`:250`) sin decir cómo se determina la plataforma de una etiqueta existente» | D-09: «"Etiqueta de runner por plataforma (Linux; Mac para iOS)": no dice cómo determinar la plataforma de una etiqueta autohospedada existente» |

Las dos filas de §6 alimentan el diagnóstico de lo que el conocimiento no resolvió (M5/M7). Pudieron surgir solas de la
lectura del conocimiento (las dos lagunas están en `conocimiento.md:229-230` y `:250`, que el aplicador releyó en B#8 y
B#10), pero el orden de los hechos y la redacción paralela no permiten descartarlo.

- **Lectura VÁLIDA CON OBSERVACIÓN:** el registro está dentro del directorio de la corrida; la tabla de clasificación sólo
  anula por material de fuera del directorio. Ningún valor de §1–§5 cambia por el registro: SHA «pendiente» más huella
  ya estaba en la ronda 1 (A#37), y las filas D-06/D-09 de §2 se apoyan en `repo/` y `respuestas.md`.
- **Lectura ANULADA:** el registro es un canal no autorizado entre coordinador y aplicador; trajo interpretaciones del
  conocimiento que el coordinador tiene prohibido entregar, y dos filas de §6 de la ficha las reproducen. Equivale a
  un valor que sale de material no entregable.

## Contexto heredado del entorno

Las dos sesiones recibieron el índice de memoria del usuario y las instrucciones generales. **Ningún valor de
`salida/A-01.md` sale de ese contexto.** Se cotejaron los términos que coinciden con la memoria:

| Término en la salida | Origen comprobado en el directorio |
| --- | --- |
| «público de consulta» (D-14) | `repo/LG/README.md:3` |
| «Product Owner» / «PO» (D-11, §4) | `repo/LG/AGENTS.md:59`, `:65`; `repo/LGD/README.md:5`, `:19` |
| `Lab-Geometria.Documentacion` (A-05) | `repo/LGD/README.md:1` |
| etiqueta del runner propio | `repo/LG/.github/workflows/e2e.yml:69`, `:149`; en la ficha va por alias `{etiqueta-runner}` |
| obligatoriedad del check por plan u organización (Q-4, D-10) | `conocimiento.md:181` |

La única cifra que viene del entorno es la «Fecha» de la cabecera (2026-11-01, reloj del sistema), que es la fecha de
aplicación y no material.

## Demandas

1 ronda de 3; 5 demandas (Q-1…Q-5); 1 respuesta con material (Q-5, parcial); 4 «no disponible» completas y 1 parcial;
**sí**: 1 (Q-3); **dudoso**: 1 (Q-5). La ficha cerró con «pendiente» y sin abrir una segunda ronda.

## Recomendación para el montaje

Dejar `coordinacion/` fuera del directorio del aplicador (o sin permiso de lectura para él) en las próximas corridas.
