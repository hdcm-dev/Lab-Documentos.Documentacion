---
doc_id: BIT-16-C1R2-CON-{estación-2}-ollama
doc_type: consulta-dirigida
title: Consulta dirigida MI-03, PC-07 y PC-08 — segundo servidor de prueba (estación de laboratorio de 15 vCPU)
status: entregada
origin: agent
owner: Operación y entrega (consulta dirigida, autorizada por el dictamen §4)
last_review: 2026-10-28
audience: [jurado de la ronda 2, redacción de §12 y del Anexo E, presidencia]
traces: [Mesa/Ciclo-1/07-Dictamen-Presidencia.md §3.3 y §4, Mesa/Ciclo-1/01-Consolidado.md C1-42, C1-44, C1-51 y §6 PC-07, PC-08, Mesa/Ciclo-1/Informe-AH-02-evaluacion-llm-rag.md AH-02--01, 04-Integracion.md §5 MI-03 y Parche P-37, Sondeo-Entorno.md §R.6]
---

# Consulta dirigida MI-03, PC-07 y PC-08

Dictamen §3.3 (las preguntas C se resuelven antes de votar) y §4 (se autoriza un Ollama en contenedor en el equipo de respaldo, medido con el mismo `sondeo.py`, sin escribir su dirección, registrado como segundo servidor de prueba). Evidencia cruda en `Ronda-2/evidencia-{estación-2}-ollama/` (su `README.md` tiene comandos, versiones y digests). Todas las cifras son E1 de esta consulta, 2026-10-28, salvo las de la estación de 4 núcleos, que salen de `Sondeo-Entorno.md` §R.6 (`Sondeo-Evidencia/2026-10-28/cifras-2026-10-28.md`).

**Rótulo de toda cifra nueva:** medido en la estación de laboratorio de 15 vCPU (CPU de escritorio sin GPU, contenedor limitado a 14 CPU / 34 GiB, Ollama 0.40.11, misma imagen por digest que la estación de 4 núcleos), 2026-10-28. Una corrida por condición salvo que se diga N. La pared es segundos de reloj por llamada HTTP.

## 0. El servidor

| Dato | Estación de 4 núcleos (estación 1) | Estación de 15 vCPU (estación 2) |
|---|---|---|
| Imagen | `ollama/ollama@sha256:dea72d1e2227…` (0.40.11) | la misma, por digest |
| Límite del contenedor | 4 CPU / 5 GB | 14 CPU / 34 GiB |
| RAM del anfitrión | 30 GB, 11 GB disponibles al medir (`free -g`, 13:13) | 38 GB, 36 GB disponibles antes de cargar |
| `OLLAMA_MAX_LOADED_MODELS` | 2 | 1 |
| Modelos | `qwen3.5:4b@d8b0f5e9760c`, `qwen3-embedding:0.6b@ac6da0dfba84`, `qwen2.5:0.5b@a8b0c5157701` | los mismos tres con los mismos digests, más `qwen3.5:35b-a3b@72aac7c28be8` |

El endpoint queda sólo en `{dir-de-trabajo}/{estación-2}-endpoint.txt` (fuera del workspace, modo 600), para la redacción. Ningún archivo de la bitácora lo contiene: `grep` de `100.` y de `11434` sobre la evidencia da 0.

## 1. MI-03 — ¿Hace falta un Ollama fuera de estación 1, y para qué?

**Pregunta** (C1-51, C1-42; BIT-16-04 §5 MI-03 y Parche P-37). ¿Qué cubre un segundo servidor que estación 1 no cubre, medido antes con `sondeo.py`?

**Respuesta.** Sí. El segundo servidor cubre tres de los cuatro puntos de MI-03 con cifras: el modelo mayor (PC-07), el juez (PC-08) y la lectura de prompts largos. La concurrencia **no se midió** en esta consulta y queda «no medido». El sondeo idéntico da en la estación de 15 vCPU los mismos resultados de capacidad que en estación 1 y paredes entre 1,5 y 5,7 veces menores.

**Evidencia** (E1; `sondeo/salidas/`, script copiado byte a byte, sha256 `4d8f45e5…2826e` igual al original):

| Operación (fuente) | estación 1 (§R.6) | 15 vCPU (esta consulta) |
|---|---|---|
| chat corto 4b en frío, 52 tok (`02-chat.jsonl` l. 3) | 18,90 s; generación 7,4 tok/s | 9,46 s (3,86 s de carga); generación 11,4 tok/s |
| herramienta «bicicleta» 4b, N = 10 (`04-tools.jsonl` l. 12–21) | 10/10; mediana 4,68 s; suma 76,72 s | 10/10; mediana 3,20 s; suma 39,68 s |
| herramienta «a pie» 4b, N = 10 (`05-tools-apie.jsonl` l. 12–21) | 10/10; mediana 4,75 s; suma 63,55 s | 10/10; mediana 3,08 s; suma 39,01 s |
| herramienta «a pie» 0.5b, N = 10 (`05-tools-apie.jsonl` l. 1–10) | 0/10 | 0/10 |
| herramienta 4b con razonamiento por defecto, N = 5 (`06-tools-razonando.jsonl`) | 5/5; mediana 24,22 s | 5/5; mediana 12,0 s |
| embedding 1024, `/api/embed` y `/v1/embeddings` (`03-embed.jsonl`) | 1024; 0,13 s caliente | 1024; 0,86 s y 0,95 s (no se investigó por qué es más lento) |
| lectura del prompt del 4b | mediana ≈ 19 tok/s (13,2–21,9) | 107,5–110,3 tok/s (N = 3, 3503 tokens, `pc07/01-largo-4b.jsonl`) |

La capacidad no cambia de servidor: mismas tasas de acierto con la misma semilla (10/10, 10/10, 0/10, 5/5). La mejora está en la lectura del prompt (unas 5,7 veces), que en estación 1 es el cuello de botella (§R.6). La generación mejora menos (unas 1,5 veces), porque depende más del ancho de banda de memoria que de los núcleos.

**Consecuencia para los ítems del jurado.**

- **C1-51 (MI-03):** la propuesta queda respaldada con datos, con las condiciones de Operación (O): contenedor propio **bajo demanda**, dirección sólo por variable, versión, digest y límites registrados (§0), y medido antes con `sondeo.py` (hecho). Cubre P-03 (juez, §3) y P-07 (modelo mayor, §2). La concurrencia y el contexto grande en estación 1 siguen como dice P-37: se miden allí con su rótulo o quedan «no medido». **Riesgo que pondera Operación:** el equipo es el respaldo de contingencia de la estación caída. Con `OLLAMA_KEEP_ALIVE=10m` el modelo se descarga solo a los 10 minutos sin uso; el contenedor queda arriba **sólo** porque la consulta pide dejar el endpoint para la redacción. P-37 dice «se apaga al terminar». La presidencia decide cuándo se apaga (`docker stop <ollama-estación-2>`; el volumen conserva los modelos).
- **C1-42:** la frase de P-37 sigue siendo correcta en estación 1 («no se midió en estación 1; el contenedor está limitado a 4 CPU / 5 GB»), y ahora se le puede sumar un hecho medido: el MoE `qwen3.5:35b-a3b` ocupa **21 GiB cargado** (§2), más de cuatro veces el límite de 5 GB del contenedor y más que los 11 GB disponibles en el anfitrión de estación 1 al medir. Para ese modelo la causa queda medida: es la memoria, no la CPU. Para un denso de 7–9B (`qwen3.5:9b`) sigue sin medirse.
- **Guía (dictamen §4):** se nombra sólo como «una estación de laboratorio con más núcleos». Toda cifra de este servidor lleva el rótulo de arriba y no se mezcla con la tabla de §R.6 sin la columna «servidor».

## 2. PC-07 — ¿Hay memoria para `qwen3.5:35b-a3b` y cuál es su pared frente al 4b?

**Pregunta** (Abogado → Operación; C1-42, C1-51). ¿estación 2 tiene memoria para `qwen3.5:35b-a3b` (22 GB q4_K_M) y cuál es su pared por operación frente al 4b?

**Respuesta.** Hay memoria: cargado ocupa 21 GiB del contenedor (62–64 % de 34 GiB) y deja unos 15 GB disponibles en el anfitrión. Acierta lo mismo que el 4b en las dos sondas de herramientas (10/10 y 10/10), pero es **más lento en todo**: unas 4,2 veces en cada llamada a herramienta (13,3 s frente a 3,2 s), unas 1,5 veces en la lectura de un prompt de 3503 tokens (51 s frente a 34 s) y unas 3,3 veces en la generación (3,6 frente a 12 tok/s). La carga en frío tarda 23–24 s, frente a 3–4 s del 4b. Que tenga 3B parámetros activos no lo hace tan rápido como el 4b en esta CPU.

**Evidencia.**

- **Etiqueta y tamaño, E4 + E1.** https://ollama.com/library/qwen3.5/tags, bajada el 2026-10-28T12:12-03:00 (`ollama-library-qwen3.5-tags-2026-10-28.html`): `qwen3.5:35b-a3b` «22GB • 256K context window • Text, Image input • 3 weeks ago». La página le asigna el id `154688af885e`, y `72aac7c28be8` a `35b-a3b-q4_K_M`. El registro, en cambio, sirve **el mismo manifiesto** para `35b-a3b`, `35b-a3b-q4_K_M` y `35b` (sha256 `72aac7c28be8…`; `01-registro-manifiestos.txt`, 13:13). Capas: pesos 21 166 758 176 B y proyector de visión 902 822 400 B. Lo bajado (`ollama list`) es `72aac7c28be8`, 22 GB, en 1023 s (`00-bajadas.txt`). `/api/show`: `qwen35moe`, 34,66 · 10⁹ parámetros, Q4_K_M, `context_length` 262 144, capacidades `completion, vision, tools, thinking` (`sondeo/salidas/01-info.jsonl`). La diferencia de id es de la página, no del registro, y no cambia lo que se mide.
- **Memoria, E1** (`pc07/02-memoria-4b.txt`, `04-memoria-35b-chat.txt`, `08-memoria-35b-largo.txt`):

| Estado | Contenedor (`docker stats`) | Anfitrión: usado / disponible (MB) | `ollama ps` |
|---|---|---|---|
| 4b cargado, `num_ctx` 8192 | 4,65 GiB | 6151 / 33 018 | 3,4 GB, 100 % CPU |
| 35b-a3b cargado, `num_ctx` 4096 | 21,05 GiB | 23 114 / 16 056 | 21 GB, 100 % CPU |
| 35b-a3b cargado, `num_ctx` 8192 | 21,83 GiB | 23 978 / 15 191 | 21 GB, 100 % CPU |

Uso de intercambio: 8–40 MB, o sea nada. Pasar de 4096 a 8192 de contexto suma unos 0,8 GiB.

- **Pared por operación, E1, mismo servidor y mismas sondas** (`pc07/resumen-salida.txt`, generado por `pc07/resumen.py`):

| Operación | Modelo | N | Éxitos | 1.ª llamada s (incluye carga o recarga) | Siguientes s (mediana; rango) | Suma s |
|---|---|---|---|---|---|---|
| herramienta «bicicleta» | 4b | 10 | 10 | 9,25 | 3,20; 2,83–5,09 | 39,7 |
| herramienta «bicicleta» | 35b-a3b | 10 | 10 | 18,49 | 13,32; 13,21–13,56 | 138,7 |
| herramienta «a pie» | 4b | 10 | 10 | 11,64 | 3,07; 2,83–3,35 | 39,0 |
| herramienta «a pie» | 35b-a3b | 10 | 10 | 19,35 | 13,92; 12,77–14,67 | 142,9 |
| prompt de 3503 tok, 14 de salida | 4b | 3 | — | 36,35 | 33,69; 33,58–33,80 | 103,7 |
| prompt de 3503 tok, 14 de salida | 35b-a3b | 3 | — | 72,35 | 51,23; 50,20–52,25 | 174,8 |

Lectura: 4b 107,5–110,3 tok/s; 35b-a3b 72,8–76,6 tok/s. Generación: 4b 11,0–13,2 tok/s; 35b-a3b 3,6–3,7 tok/s. Chat corto en frío: 4b 9,46 s (carga 3,86 s); 35b-a3b 48,78 s (carga 23,96 s, 77 tokens a 3,35 tok/s). Las respuestas a la pregunta del prompt largo son idénticas en los dos modelos («El código postal de una localidad lleva 4 dígitos.»). Herramientas: T 0,7, semillas 1..10, `reasoning_effort: none`, igual que AD-S1 y §R.4.

- **Lo que no se midió:** calidad del 35b-a3b en D1–D6, comparativo CAG/RAG de P-07, contexto mayor que 8192, razonamiento encendido, visión. Las paredes son de un anfitrión no reservado (sin otra carga visible: `load average` 0,00 antes de empezar); las series no se intercalaron.

**Consecuencia para los ítems del jurado.**

- **C1-42 / C1-51 (propuesta del abogado):** el MoE es **viable** en el segundo servidor para el comparativo de P-07 y como contraste de calidad. **No sirve como modelo por defecto**: una suite de 10 herramientas pasa de unos 40 s a unos 140 s, y una operación .NET con dos llamadas, de unos 7 s a unos 27 s de mediana (estimación con estas paredes, no medida punta a punta). En estación 1 no entra: 21 GiB cargado frente a un contenedor de 5 GB. El jurado puede votar la opción del abogado (MoE en vez de un denso ≥ 7B) sabiendo que en memoria cabe y que en tiempo cuesta unas 4 veces lo del 4b por llamada a herramienta.
- **C1-41 / C1-50 (MI-02):** las sondas de herramientas no separan el 35b-a3b del 4b (10/10 en las dos). No hay evidencia para cambiar el modelo por defecto, que sigue siendo `qwen3.5:4b`. La comparación de familia queda como estaba: «la familia qwen3.5 con *tools*».
- **N3b §3.7 y P-07:** si el comparativo se corre con el MoE, presupuestar unos 51 s por cada 3500 tokens de prompt sin caché y 3,6 tok/s de salida. Con `num_ctx` 8192 la memoria sigue holgada.

## 3. PC-08 — Costo en tiempo del juez y de los evaluadores de Quality con `qwen3.5:4b`

**Pregunta** (AH-02 → Operación; C1-44, C1-51). ¿Cuál es el costo en tiempo del juez y de los evaluadores de `Microsoft.Extensions.AI.Evaluation.Quality` con `qwen3.5:4b`? AH-02--01 lo marcó como «estimación sobre E1 ajeno; no medido».

**Respuesta.** Medido en la estación de 15 vCPU: **unos 34 s por evaluación** (media de 28; mediana por evaluador entre 5 s y 45 s). Un caso con los siete evaluadores tarda unos 4,5 min (270,7 s para C1), y los 4 casos × 7, 950 s. **Medido en estación 1** (un caso, C1 × 7, N = 1): **1285 s**, o sea 21,4 min para un solo caso, unas 4,75 veces lo del segundo servidor. Relevance, Groundedness y Completeness tardan 134, 139 y 188 s (media 154 s), y Retrieval, 438 s. El diseño de AH-02--01 (10–20 casos × 2 adaptadores × 3 evaluadores, N = 1) cuesta **35–69 min** en el segundo servidor (medido por evaluación × n) y **unas 2,6–5,1 horas** en estación 1 (154 s × n), o sea 3,4–6,8 turnos de 45 min. La estimación de AH-02 («supera con holgura los 45 min») queda **confirmada con medición**. Con el razonamiento por defecto, el juez **no da puntaje**: seis de siete evaluadores dan *Inconclusive* por cortarse en el límite de 800 tokens.

**Evidencia** (E1, R-LLM; `pc08/`).

- **Montaje.** Sonda .NET (`SondaEval-Program.cs`) con `RelevanceEvaluator`, `CoherenceEvaluator`, `FluencyEvaluator`, `GroundednessEvaluator`, `RetrievalEvaluator`, `CompletenessEvaluator` y `EquivalenceEvaluator` de Quality 10.11.0, con `qwen3.5:4b@d8b0f5e9760c` como juez por `OllamaApiClient` de OllamaSharp 5.5.0. Un `DelegatingChatClient` mide cada llamada al juez y le pone `Reasoning = None` (o lo deja por defecto con `RAZONAR=1`). Corpus: los requisitos de `EncuestaPolicy` y `LocalidadPolicy` del caso base (Lab-E2E.WebBlazor `59399ba`, 2026-10-27), con los valores de `EncuestaRules` y `LocalidadRules`. Cuatro casos con respuesta escrita a mano: C1 edad (correcta), C2 código postal (correcta), C3 distancia (**incorrecta**: «hasta 1000 km», cuando la regla dice 0–500) y C4 no respondible (abstención). Cada evaluador hace **una** llamada al juez por evaluación (28 llamadas para 28 evaluaciones). Los evaluadores fijan T 0, `MaxOutputTokens` 800 (Retrieval, 1600; Equivalence, sin límite) y formato texto, y su rúbrica pide razonar paso a paso. Por eso el juez escribe 290–525 tokens **aunque el razonamiento del modelo esté apagado**.
- **Costo por evaluador** (`pc08/costo-salida.txt`, de `costo.py`; razonamiento apagado, N = 4 por evaluador):

| Evaluador | tok de entrada (mediana) | tok de salida (mediana) | Pared medida en 15 vCPU, s (mediana; rango; N = 4) | estación 1 **medido**, C1, s (N = 1) | estación 1 estimado por tasas, C1, s (central; pesimista) |
|---|---|---|---|---|---|
| Relevance | 992 | 391 | 36,1; 34,3–38,1 | 134,0 | 96; 119 |
| Coherence | 1336 | 494 | 43,0; 40,8–51,5 | 196,9 | 131; 162 |
| Fluency | 970 | 332 | 31,9; 26,9–42,5 | 131,3 | 89; 112 |
| Groundedness | 1276 | 336 | 33,6; 26,4–40,4 | 139,0 | 111; 141 |
| Retrieval | 3606 | 470 | 44,7; 41,4–69,5 | 438,4 | 244; 327 |
| Completeness | 1408 | 364 | 36,1; 28,4–36,8 | 188,4 | 119; 151 |
| Equivalence | 896 | 2 | 5,0; 4,3–8,0 | 57,3 | 48; 68 |

Totales medidos: 28 evaluaciones en 950,4 s en el segundo servidor; C1 × 7 en 270,7 s en el segundo servidor y **1285,3 s en estación 1** (`pc08/eval-{estación-1}.jsonl`, 2026-10-28T13:19–13:40, turno `<recurso-compartido>` exclusivo; anfitrión no reservado: los demás contenedores de estación 1 seguían corriendo). La estimación por tasas (`tokens_entrada / lectura + tokens_salida / generación`, con 19 tok/s de lectura y 7,4 de generación de §R.6) da 837 s para C1 y **subestima la medición un 35 %**: estación 1 queda por encima incluso del caso pesimista (13,2 tok/s de lectura). Una explicación posible, no verificada: el prompt de rúbrica se lee en estación 1 más lento que los 19 tok/s de §R.6. Las cifras de estación 1 de esta consulta son las **medidas**, no las estimadas (las estimadas quedan en `pc08/costo-salida.txt` como historia). Diseño de AH-02--01 (media por evaluación de Relevance, Groundedness y Completeness: 34,7 s en el segundo servidor, N = 12; **154 s en estación 1**, N = 3):

| Diseño | Evaluaciones | 15 vCPU (34,7 s × n) | estación 1 (154 s × n) |
|---|---|---|---|
| 10 casos × 2 adaptadores × 3 evaluadores, N = 1 | 60 | 35 min | 154 min (3,4 turnos de 45 min) |
| 10 × 2 × 3, N = 3 | 180 | 104 min | 462 min (10,3 turnos) |
| 20 × 2 × 3, N = 1 | 120 | 69 min | 308 min (6,8 turnos) |
| 20 × 2 × 3, N = 3 | 360 | 208 min | 924 min (20,5 turnos) |

- **Razonamiento por defecto** (`eval-{estación-2}-razonando.jsonl`, caso C1 × 7): Relevance, Coherence, Fluency, Groundedness y Completeness llegan a 800 tokens de salida con `finish_reason` `length` (unos 65–66 s cada una) y dan *Inconclusive*. Retrieval también termina en `length`, y sólo Equivalence da puntaje (5). Total: 403,7 s para 7 evaluaciones sin ningún puntaje útil salvo uno. **Condición dura:** el juez con qwen3.5 se corre con el razonamiento apagado.
- **Hallazgo nuevo: Retrieval se corta por la ventana de 4096.** En C3 y C4, Retrieval termina en `length` con 3604 + 492 y 3609 + 487 tokens, o sea exactamente 4096: el `num_ctx` por defecto con que el servidor carga el modelo (`ollama ps`: 4096). El resultado es *Inconclusive*. En C1 y C2 entró por poco (3603 + 454 y 3608 + 445). Con sólo tres fragmentos cortos, el prompt de rúbrica de Retrieval ya ocupa unos 3600 tokens. Con más fragmentos, o fragmentos más largos, no entra. El evaluador no fija `num_ctx`, así que hay que fijarlo en el cliente (vinculado a C1-66/MI-18, M10 y PC-06).
- **Calidad del juez (anécdota, N = 1 por celda; no es tasa).** C3, la respuesta incorrecta: Completeness 1 y Equivalence 1 la detectan, Groundedness da 3, y Relevance y Coherence dan 4 («Good»). C2, la respuesta correcta: Relevance le da 2 («Poor»), un falso negativo. C4, la abstención correcta: Equivalence 1 frente a la verdad «No está en los requisitos cargados». Esto coincide con la advertencia oficial que cita AH-02 (F-Q: «can be especially poor when a smaller / local model is used»), pero no la mide: hacen falta anotaciones humanas y k/n con intervalo.
- **estación 1, mismo caso.** Los puntajes de C1 coinciden con los del segundo servidor en los 7 evaluadores: 4, 4, 3, 5, 5, 5 y 5. Retrieval entra en estación 1 con 3603 + 401 tokens, dentro de 4096. Con T 0, el servidor no cambia el juicio en este caso; sólo cambia el tiempo.

**Consecuencia para los ítems del jurado.**

- **C1-44 (MI-16):** respalda la posición B (AH-02--01). En estación 1 el juez no cabe en un turno: un solo caso con los siete evaluadores tarda 21 min (medido), y 10 casos × 2 × 3 con N = 1, unos 154 min. En la guía se enseña como **método**, se cita la advertencia oficial y en estación 1 se declara «no medido». En el segundo servidor se puede correr 10 × 2 × 3 con N = 1 en unos 35 min, y el acuerdo con anotaciones humanas se informa como k/n con intervalo, nunca como compuerta (posición C de Formal, compatible). Condiciones nuevas, medidas: (1) razonamiento apagado; (2) `num_ctx` fijado en el cliente, al menos 8192 si se usa Retrieval; (3) Retrieval es el evaluador más caro (unas 3600 tokens de entrada con tres fragmentos), así que conviene dejarlo fuera de un diseño mínimo o correrlo sólo en el segundo servidor.
- **C1-51 (MI-03):** P-03 pasa de «puede no caber en 45 min» a «no cabe en estación 1 (medido: 21 min por caso con siete evaluadores); en el segundo servidor, 10 × 2 × 3 cabe en un turno (35 min, medido por evaluación)».
- **AH-02--01:** su marca «[estimación sobre E1 ajeno; no medido]» se reemplaza por estas mediciones en los dos servidores, cada una con su rótulo.
- **Sondeo-Entorno §R.6:** estimar paredes de estación 1 con «tokens / 19 tok/s» subestimó un 35 % con prompts de rúbrica de unos 1000–3600 tokens. Toda cifra de estación 1 que la guía cite sale de una medición, no de esa fórmula.
- **Anexo E / §R.6:** las filas de esta consulta entran con la columna «servidor» y el rótulo de arriba. No reemplazan las de estación 1.

## 4. Registro y limpieza

- Bitácora: nota fechada agregada al final de `Sondeo-Entorno.md`, «segundo servidor de prueba (estación de laboratorio de 15 vCPU)» (sólo agregado).
- Intermedios en `{dir-de-trabajo}/{estación-2}-ollama/`. `bin/obj` se borran al terminar. El contenedor `<ollama-estación-2>` y su volumen quedan arriba en el equipo de respaldo hasta que la presidencia disponga (§1).
- Sin commit ni push.

---

Nota de cola (2026-10-28): turno `<recurso-compartido>` pedido a las 12:19:30 para «PC-08 juez Quality 1 caso x 7 evaluadores en estación 1», concedido a las 13:19 (antes lo tenían las consultas de PC-14 y PC-06) y liberado a las 13:40. Comando: `<envoltorio-de-turnos> <recurso-compartido> {estación-2}-ollama "…" 45 -- docker run --rm --network host -e OLLAMA_ENDPOINT -e OLLAMA_MODEL=qwen3.5:4b -e CASOS=C1-edad -v <volumen-nuget>:/root/.nuget/packages -v $PWD:/w -w /w mcr.microsoft.com/dotnet/sdk:10.0 dotnet bin/Release/net10.0/SondaEval.dll`.
