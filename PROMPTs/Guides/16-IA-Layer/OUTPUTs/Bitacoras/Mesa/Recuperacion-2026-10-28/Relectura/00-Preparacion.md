# B-14 · Relectura integral: preparación (presidencia)

Fecha: 2026-10-29, de 23:26 a 23:36. Plan: [`../03-Plan-De-Recuperacion.md`](../03-Plan-De-Recuperacion.md), B-14 (REC-03, REC-04), con el §4 Vuelta 2. Bitácora de aplicación: [`../04-Aplicacion.md`](../04-Aplicacion.md), sección «B-14 · Relectura integral». Esta preparación **no editó la guía**.

## 1. Foto

| Qué | Valor |
|---|---|
| sha256 de la guía (`$DOC`) antes | `eeede578a6b34e2f2f46124c0f36b1a11a8caf85fb2d4010b17a831011defa18` (igual al cierre de B-13) |
| `contar.sh` | total 58.820 sobre un tope de 44.330 (133 %), `wc -w` 73.299, 5.235 líneas |
| Foto tgz (guía + `Bitacoras/`) | `$FOTOS/relectura-pre-b14-2026-10-29-2326.tgz`, 1.412 entradas, sha256 `830016cbafbaddd53e28f6b324b494b64493f7daa0d29d3418b5f7b36698090a` |
| sha256 de la guía después | el mismo (`eeede578…fa18`) |

## 2. Insumo REC-04

Los 13 `Informe-*.md` de `$INSUMO/Bitacoras/Mesa/Ciclo-1/` se copiaron pieza por pieza a [`insumo/`](insumo/README.md). El sha256 de origen de cada uno coincide con el planificado en `Procedencia.md` §4. A las copias se les aplicaron las redacciones RPRI-18 (roles y marcadores, ningún otro cambio). El barrido ampliado sobre cada copia dio **0** en las siete clases. Registro en [`../Procedencia.md`](../Procedencia.md) §6, filas PI-01…PI-13, con el sha256 de origen y de destino y la operación «copiar como insumo». [`insumo/README.md`](insumo/README.md) explica que son insumo y no hallazgos de esta mesa, y cómo se traduce la numeración: tabla DECI-30 en `../Inventario-decisiones.md` §4.

| ID | Informe | Líneas redactadas |
|---|---|---|
| PI-01 | abogado-del-diablo | 15 |
| PI-02 | AH-01-seguridad-llm | 7 |
| PI-03 | AH-02-evaluacion-llm-rag | 11 |
| PI-04 | arquitectura | 0 (idéntico) |
| PI-05 | CAT-formal-matematico | 1 |
| PI-06 | CAT-operacion-entrega-rendimiento | 31 |
| PI-07 | didactica | 0 (idéntico) |
| PI-08 | edicion-bibliografica | 1 |
| PI-09 | experto-ia | 12 |
| PI-10 | implementador-desarrollador | 6 |
| PI-11 | requisitos | 3 |
| PI-12 | senior-dotnet | 1 |
| PI-13 | verificacion-qa | 12 |

**Nota.** La compuerta R-PRIV del repo (`tools/compuerta-rpriv.sh`) da 2 en «ip-privada» sobre el insumo. Los dos son la cadena de versión `10.11.0.0`, un falso positivo conocido (RPRI-19), y quedaron como están.

## 3. Compuertas mecánicas de línea base (0.11.0)

Corrieron sobre copias en `$TRABAJO/rec-b14/`: `texto/` para las compuertas de texto y `guia/` para la compilación, esta última con el turno `build` de 23:29 a 23:34. Salidas en [`compuertas-base/`](compuertas-base/), con las rutas reemplazadas por marcadores.

| Compuerta | Resultado | ¿Pasa? |
|---|---|---|
| AC-5 `diff-dominio.sh` | rc 0, «idénticos» | sí |
| AC-6 (paquetes) | build: familias en una sola versión, previews sólo las de la excepción (`Azure.AI.OpenAI 2.9.0-beta.1`); demo: sin previews | sí |
| `verificar.sh build` · `demo.sh pruebas` | 561/561 (18 proyectos, 0 fallas) · 79/79; R-PRIV del build 0 | sí |
| AC-7 | rc 0: 0 coincidencias, 40 de 40 positivos (árbol); 19 registros del build revisados, 0 | sí |
| AC-8 | rc 0: 0 fuera de excepciones (2 exceptuadas), 5/5 positivos, lista 11/11 | sí |
| AC-9 bloques | 57 bloques, 0 diferencias | sí |
| AC-10 `diff-base.sh` (caso base 8fb4c3a) | rc 0: 27 iguales, 17 distintos, 59 nuevos, 0 quitados; todo cambio está en la tabla de delta | sí |
| `verificar-markdown.py guia` · `arbol` | rc 0: 229 encabezados, 282 anclas, 1.620 enlaces internos, 180 REF definidas = citadas, 110 rutas (4 exceptuadas) · rc 0 (20 .md) | sí |
| Barrido R-PRIV ampliado sobre la guía | rc 1: 1 línea en «turnos» y 1 en «identificadores», las dos en `Examples/15-…/entradas/salidas-07.v1.json`. Es el valor histórico declarado desde B-01 (D-B13-2) | sí, con la excepción declarada |
| Compuerta R-PRIV del repo (`compuerta-rpriv.sh`) | 0 hallazgos (patrones 4, lista 40, históricos 1) | sí |
| Conteo REC-21 (`contar.sh`) | total 58.820, 133 % del tope de 44.330. Es informativo: no tiene umbral de corte. Las Partes 0, II y V y los Anexos son los más pasados (148 %, 130 %, 134 % y 192 %) | se informa; insumo para la relectura |
| `compuerta-intervalos.py` (registros R-LLM de la bitácora) | rc 0: 67 figuras reconocidas, 67 en el mapa; 40 de 40 filas coinciden | sí |
| `compuerta-cabeceras.sh` | sobre los registros del build: rc 0, «0 en 4 cuerpos capturados». Sobre el árbol de la guía: rc 2, «ningún cuerpo capturado» (el árbol no guarda capturas; D-B03-2) | sí |
| `grep -c '⟦REC-02:' $DOC` | 0 | sí |
| M-J (cinco patrones) · M-B `tool_choice` · M-G «no es validación» | 39 líneas (igual que en B-13) · 7 · 2 | sin cambio |
| Repo | `find $GUIA \( -name bin -o -name obj -o -name '*.db' \)` vacío; volúmenes temporales borrados; sha256 de la guía sin cambio | sí |

## 4. R-15b (juez, estación 2)

**Terminó** durante esta preparación. `rc=0`, en 2.995 s. El turno de la estación 2 (`b11-r15b`) se liberó a las 23:33:51.

| Campo | Valor |
|---|---|
| Criterio | `../Recorrida/criterio-R-15b.md`, sha256 `3f573a4ebbac83009f226e69af66d6129bebcc37191332a453b8365f550aebaf` (lo vuelvo a calcular ahora y coincide con el anotado en D-B11-R15-1) |
| Precondición | Ollama 0.40.11, digest del 4b `d8b0f5e9760c`, coincide; `num_ctx` 8192 cargado (`/api/ps`) |
| Estación única (M-D) | 64 llamadas, todas con máquina `estacion-2`, `turno_id` `b11-r15b` y digest `d8b0f5e9760c` |
| Llamadas al juez | 52 |
| **Interpretables** | **41/52 = 0,788, IC95 Clopper-Pearson [0,653; 0,889]** (`qwen3.5:4b`@`d8b0f5e9760c`, estación 2, Ollama 0.40.11, 2026-10-29, estimando «52 entradas distintas») |
| Umbral del criterio | ≥ 45/52 interpretables |
| **¿Cumple?** | **No.** 41 < 45. Por su criterio, **R-15b = «no medido»** |
| Acuerdo (no se lee, porque no cumplió la fracción mínima) | la consola informa juez–oráculo 6/16 y juez–anotador 4/10, y «juez no calibrado». Lo dejo sólo como rastro, sin interpretarlo como tasa |
| Cierre | `/api/ps` antes del cierre: el 4b cargado; después de `keep_alive 0`: **vacío** |
| Registros | `$TRABAJO/rec02/registros/estacion-2/R-15b/`: `15-Pruebas-Y-Evaluacion.jsonl` sha256 `e2a286e153faf574f4ad07e26c1094cfd7717da413ad587a6b462326c36f683b`, `consola.txt` `bf184a09eff6666b6a271bf482ea258bde1100fc5c30b9ec2c314a0d5794035f` |

**Para el panel (no se editó la guía).** §10.6 dice hoy «no está medida», y sigue siendo verdad por criterio. La relectura puede precisarlo así: «corrida del 2026-10-29: 41/52 salidas interpretables, por debajo del mínimo fijado (45/52); no medido», siempre con la advertencia de familia de M-G. Además quedan pendientes el `estado` de 15 y volver a correr `re5.py` (D-B11-RE5-1), que suma las 52 llamadas de R-15b.

## 5. Siguiente

Panel completo de B-14 punto 2 sobre la 0.11.0: los 8 especialistas, el abogado del diablo y el jurado de 5. Cada lector usa `insumo/` con DECI-30 y las compuertas de línea base de arriba. Las salidas van a `Relectura/`.
