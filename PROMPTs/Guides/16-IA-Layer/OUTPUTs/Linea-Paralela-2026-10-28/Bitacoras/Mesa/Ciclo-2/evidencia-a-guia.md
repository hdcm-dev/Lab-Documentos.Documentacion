---
doc_id: BIT-16-C2-EVID
doc_type: mapa-de-evidencia
title: Evidencia de la bitácora → destino en la guía (P-08)
status: vigente
origin: agent
owner: redacción del ciclo 2 (entregable previo de 06-Plan §1); la actualiza la fase de compuertas
last_review: 2026-10-28
audience: [redacción, constructores de Examples/ y de la demo, fase de compuertas, relectura integral]
traces: [Mesa/Ciclo-1/03-Parches.md P-08; Mesa/Ciclo-1/06-Plan-De-Redaccion.md §1, §2 (Anexos D y E), §6 (RV-01, RV-08, RV-09, RV-10), §10.2, §10.3; Mesa/Ciclo-1/07-Dictamen-Presidencia.md §2, §4, §5; Nucleos/*; 04-Integracion.md §1; Sondeo-Entorno.md §R; Mesa/Ciclo-1/evidencia-*; Mesa/Ciclo-1/aplicacion/; Mesa/Ciclo-1/Ronda-2/Consulta-*.md y evidencia-*; Mesa/Ciclo-2/matriz-snippets.md]
---

# Evidencia de la bitácora → destino en la guía (P-08)

La guía no cita la bitácora (REED-16 §11, RV-08). Toda evidencia que hoy sólo vive acá tiene uno de cuatro destinos (P-08):

- **(a) ejemplo:** una carpeta de `Examples/` que la reproduce. Se cuenta también la demo (`Demos/MovilidadUrbana.Asistente/`, `tests/Cableado/` o `tests/ConModelo/`), porque la guía la cita igual que a un ejemplo (§9); la matriz de snippets marca esa lectura **[a ratificar por la presidencia]**.
- **(b) R-LLM del Anexo E:** registro con cabecera R-LLM-4 (06-Plan §10.3) y rótulo de estación (RV-01 ampliada: «estación de laboratorio de 4 núcleos» o «estación de laboratorio de 15 vCPU», nunca juntas sin decir cuál es cuál). La tabla de cifras del Anexo E sale de `Sondeo-Entorno.md` §R.6.
- **(c) fuente E4 del Anexo D:** entrada `REF-nnn` con URL canónica, versión o `ms.date` y fecha ISO de consulta (P-31). Las versiones de paquetes las regenera la compuerta de versiones el día de publicar (P-32): la evidencia de hoy sólo dice que existe la fila.
- **(d) se omite**, con su motivo.

Reglas de lectura: una medición del servidor dado de baja, si la guía la nombra, va en pasado y con fecha (RV-09); una cifra va con el rótulo de RV-01 y su estimando (RV-17); ningún id de esta tabla entra a la guía (RV-08). Donde una fila tiene dos destinos, el primero es el que sostiene la afirmación de la guía. La columna «Archivo» nombra la carpeta o el anexo; el archivo exacto lo completa la fase de compuertas.

## 1. Núcleos

| # | Id de bitácora | Qué es | Destino | Archivo | Motivo / nota |
|---|---|---|---|---|---|
| E-001 | N1 E00 | lectura de `INPUTs/AI-Layer.png` | d | — | la lectura entra como texto de §4 (qué se sostiene y qué es simplificación); no hay medición que reproducir |
| E-002 | N1 E01 | compilación de los snippets con SDK 11 rc | d | — | no vale como evidencia de .NET 10 (P-29); la reemplaza la compilación de S-01…S-07 en `Examples/` |
| E-003 | N1 E02 | nuget.org: versiones, fechas, dependencias | c | Anexo D, tabla de paquetes | se regenera el día de publicar (P-32) |
| E-004 | N1 E03 | compilación con `sdk:10.0` y reflexión de `ChatOptions`, `TryGetResult`, `AsAIAgent` | d | — | fuentes perdidas con la estación caída; la reemplazan `01`, `03`, `04`, `07` (matriz S-01…S-07) |
| E-005 | N1b E1 | fechas de v1 en arXiv (Attention, RAG, GPT-3, InstructGPT, ReAct, Toolformer…) | c | Anexo D (§2 de la guía) | cada hito con fecha y fuente |
| E-006 | N1b E2 | primeras versiones en nuget.org (hitos .NET) | c | Anexo D (§2) | re-corrida idéntica en R8 de verificación (E-086) |
| E-007 | N0b B-E1…B-E9 | arXiv, Crossref, PDFs de Microsoft y NIST, libro de Huyen, ACL Anthology, ADR | c | Anexo D (§0, §3, Anexo F) | sólo citas; B-E3 (paquetes de Evaluation) va con la compuerta de versiones |
| E-008 | N2 E1 | plantillas `aichatweb` y `mcpserver` | d | — | absorbida por V-E2 (E-013) |
| E-009 | N2 E2, E3 | registro y nuspec de nuget.org (deprecación de `Microsoft.Extensions.AI.Ollama`, dependencias) | c | Anexo D | la deprecación es la fila «paquetes deprecados fuera de todo camino» de §5 |
| E-010 | N2 E3b | sonda contra un `IChatClient` falso (salida «Semaforos / 1») | d | — | dominio ajeno (RD-PO-3) y doble perdido; la reemplaza `09` (matriz S-42) |
| E-011 | N2 E4 | reflexión de `FunctionInvokingChatClient` y `GetResponseAsync<T>` | d | — | la re-corrió R9 de verificación (E-087), que va a `06` |
| E-012 | N2 V-E1 | snippets 4.1–4.7 pegados tal cual, `0 Error(s)` | d | — | compilación de historia; la reemplaza la matriz (S-08…S-16) |
| E-013 | N2 V-E2 | `.nupkg` de las plantillas y los cuatro comandos en `sdk:10.0` | a | README de `01` y de `08` (matriz S-17), si entran | si la redacción no los incluye, pasa a (d) «plantilla preview no usada» |
| E-014 | N2 V-E3 | nuget.org de 19 paquetes | c | Anexo D | — |
| E-015 | N3 E1 | reflexión de MEVD y búsqueda determinista | a | `04`, `05` | la reproducen los generadores y buscadores falsos de `Cableado/` |
| E-016 | N3 E2 | «el servidor no hace embeddings» | d | — | historia del servidor dado de baja; hoy hay `qwen3-embedding:0.6b` (Sondeo §R.3) |
| E-017 | N3 E3 | recall@k y MRR de dos modelos de embeddings en otra estación | d | — | historia y corpus parafraseado; lo reemplazan la sonda S-R de AH-02 (E-064) y `04` |
| E-018 | N3 E4 | EF Core y SqliteVec en el mismo proceso | a | `04` o `05` (variante SqliteVec rotulada preview) | sólo si la variante se construye; si no, (d) «preview fuera del camino por defecto» (P-32) |
| E-019 | N3 E5 | un 7B citó una regla y la contradijo | d | — | servidor dado de baja; el principio (citar ≠ estar fundamentado) entra como criterio sin cifra |
| E-020 | N3 V1 | snippets 4.1–4.8 compilados y 4.1–4.4 corridos con generador determinista; SqliteVec rechaza `CosineSimilarity` | a | `04` (S-18, S-19) | el `NotSupportedException` se reproduce en la variante SqliteVec si se construye |
| E-021 | N3 V2 | registro de nuget.org (conectores `Legacy` de SK) | c | Anexo D | — |
| E-022 | N3 V3 | tokenizador `gpt-5` exige `O200kBase` | d | — | el tokenizador no entra (P-20: el token es del modelo) |
| E-023 | N3b X1 | reflexión de `UsageDetails`, `ChatOptions`, OllamaSharp y OpenAI (sin campo de cacheados en OllamaSharp) | a | `09` (handler de P2-09, matriz S-26, B-05) | — |
| E-024 | N3b X2, X3, X4a | estado del servidor dado de baja; caché con un modelo híbrido contaminada por otra carga; timeout de 900 s | d | — | historia (RV-09); no sostienen nada del entorno vigente |
| E-025 | N3b X4b | caché de prefijo en 0.32.0-rc0 con `qwen2.5:0.5b` («93 veces menos») | d | — | otra versión y modelo denso; la cifra está prohibida sin modelo y rótulo (P-19, RV-16); la reemplazan S4 de Experto IA (E-068) y O5 (E-081) |
| E-026 | N3b fuentes G1–G24 | paper de CAG, docs de proveedores, código de llama.cpp/Ollama | c | Anexo D (§6) | — |
| E-027 | N4 E01, E03, E04 | nuget.org, protocolo MCP en el SDK, renombres de tipos | c | Anexo D | versiones de protocolo junto a la especificación MCP 2026-07-28 |
| E-028 | N4 E02 | `compilecheck`: workflow sin modelo (`checkpoint: True / output: ALOH`), `BindAsExecutor` | a | `10` (S-30) | la trampa `BindExecutor` se reproduce compilando |
| E-029 | N4 E05, E06 | estado de repos (AutoGen archivado, SK → MAF) y LangGraph en PyPI/npm/NuGet | c | Anexo D (§7) | E06 lo actualiza E-B6 (E-053) |
| E-030 | N4 E07 | lectura de `MovilidadUrbana.Web` (servicios y entidad) | d | — | la reemplaza la lectura de la ApiWeb en `59399ba` (E-076) |
| E-031 | N4 V01 | compilación independiente y persona en el bucle (`42 found`) | a | `10` (S-31) | — |
| E-032 | N4 V02, V03 | registros, repos y páginas oficiales | c | Anexo D (§7) | esquema `Thread` de `langgraph_sdk` para el snippet «no ejecutado» |
| E-033 | N5 E1–E7 | sonda con `FakeChatClient`: caché y spans, contrato, evaluador propio, reporte en disco, instrumentos de MEAI | a | `09` (S-42…S-47) | el orden de E2 (caché por fuera) queda reemplazado por la rama A (P2-06) |
| E-034 | N5 V2, V3, R2, R3 | orden telemetría/caché | d | — | lo reemplaza PC-02 (E-094) |
| E-035 | N5 V4 | `UseDistributedCache()` sin DI lanza | d | — | el snippet que lo mostraba no entra (S-40) |
| E-036 | N5 V5, V6, R6, R7 | contrato, juez falso, valores por defecto de `FunctionInvokingChatClient`, `[Experimental]` en evaluadores, `EnableSensitiveData` por variable | a | `09` (S-43, S-45, S-47) | los valores por defecto los usa `06` (CTRL-05) |
| E-037 | N5 V8, V10, R1, R4, R5 | convenciones GenAI, OWASP, páginas y versiones | c | Anexo D (§8) | — |
| E-038 | N6 E1 | sonda de integración con servicio simplificado | d | — | la reemplazan E5 y K1 (E-039, E-070), que usan el dominio copiado |
| E-039 | N6 E5 | snippets 4.1–4.6 sin `NoWarn` contra el dominio de `8fb4c3a` | a | `06`, `07`, `08`, `05` (S-50…S-55) | — |
| E-040 | N6 E2 | reflexión de MEAI (`AddChatClient` Singleton por defecto, aprobación) | a | `07`, `09` | — |
| E-041 | N6 E3 | dependencias de EF Core Sqlite, SqliteVec, MCP | c | Anexo D | — |
| E-042 | N6 E4 | lectura del caso base en `8fb4c3a` | d | — | la reemplaza `59399ba` (EA-1, E-043) |

## 2. Integración (04-Integracion §1)

| # | Id de bitácora | Qué es | Destino | Archivo | Motivo / nota |
|---|---|---|---|---|---|
| E-043 | EA-1 | fidelidad del caso base: `8fb4c3a` → `59399ba` sin diff de código | a | demo, `PROCEDENCIA.md` | — |
| E-044 | EA-2 / EA-3 | copia literal y prueba de capas por `grep` | a | demo (`diff -r = 0`) y `13` | el `grep` lo reemplaza la reflexión con casos rojos (P-30; da falso negativo con una mutación, R4) |
| E-045 | EA-4 | reflexión de MAF/MEAI/OllamaSharp (`AIContextProvider`, `Reasoning`, `Think`) | a | `05` (vía C con doble, B-11) | — |
| E-046 | EA-5 | tres vías con dobles; corpus de 12 enunciados por reflexión | a | `05` (B-11, S-20) | — |
| E-047 | EA-6 | vías A y B contra el 4b; embeddings 1024 desde .NET | d (vías); a (dimensión) | `04` (dimensión) | las vías las reemplaza la réplica de PC-10 (E-097); EA-6 no sostiene «A por defecto» (P-24, P2-13) |
| E-048 | E-B1 | tool calling .NET por OllamaSharp y `/v1`, validación del argumento | a + b | `06`; Anexo E | la tasa entra sólo con R-LLM-4 y N del registro; «piedra» del 0.5b es existencia |
| E-049 | E-B2 / E-B2b | `GetResponseAsync<LocalidadPropuesta>`; captura HTTP (`think:false`, `format`, `response_format`) | a + b | `03` y `01` (captura); Anexo E | forma ≠ validez se enseña con el invariante de `03`, no con la tasa |
| E-050 | E-B3 | agente MAF: sesión y `ToolApprovalRequestContent`; 0 ejecuciones tras el rechazo | a + b | `07`; Anexo E | — |
| E-051 | E-B4 | similitud frente a conteo exacto | a | `04` (contraejemplo: RAG no cuenta) | — |
| E-052 | E-B5 | expresiones coloquiales → medios por embeddings (la similitud siempre devuelve algo) | a | `04` (consulta con y sin instrucción, con S1 de E-067) | — |
| E-053 | E-B6 | LangGraph sin paquete oficial en NuGet; PyPI y npm | c | Anexo D (§7) | — |
| E-054 | X0 | 24 paquetes en nuget.org | c | Anexo D | — |
| E-055 | X1 | `sourceName` distinto → 0 spans; Singleton + herramienta Scoped | a | `09` (CTRL-08, B-13) | — |
| E-056 | X2 | escrituras propuestas por el 4b (N = 10) | d | — | la repite la comparación 2b/4b con el mismo guion (`x2.py`) y R-LLM completo (E-098) |
| E-057 | X3 | truncado silencioso en 0.40.11 (2050 sin `num_ctx`, 4098 con 8192) | b + a | Anexo E (regla de ventana); `09` (decorador «contexto truncado», S-16) | — |
| E-058 | X4 | variables `OLLAMA_*` del contenedor | b | Anexo E (receta: `NUM_PARALLEL`, `MAX_LOADED_MODELS`, `KEEP_ALIVE`, sin `CONTEXT_LENGTH`) | sin host ni nombre de contenedor |
| E-059 | X5 | caso base: NUnit en 7 proyectos de test; la MAUI no consume ApiWeb | c + d | Anexo D (fila NUnit; el caso base usa 4.3.2) | lo de la MAUI se omite: la vía móvil no se ejecuta en este ciclo |
| E-059b | `criterio-D1-D6-qwen3.5-2b-vs-4b.md` | criterio escrito antes de la comparación | b | Anexo E, registro de la comparación (E-098) | es el «criterio previo» de R-LLM-4 |

## 3. Sondeo del entorno

| # | Id de bitácora | Qué es | Destino | Archivo | Motivo / nota |
|---|---|---|---|---|---|
| E-060 | Sondeo §1–§8 | mediciones del servidor dado de baja | d | — | historia (RV-09); si la guía las nombra, en pasado y con fecha |
| E-061 | Sondeo §R.0, §R.1 | condiciones (4 núcleos, sin GPU, contexto 4096 al cargar), modelos, digests, `capabilities`, parámetros del Modelfile | b | Anexo E (rótulo y receta: `ollama list` contra el digest) | sin host; el Modelfile del 4b sostiene P-33 |
| E-062 | Sondeo §R.2, §R.3 | chat por modelo (N = 1) y embeddings 1024 por las dos rutas | b + a | Anexo E (tabla de cifras); `04` (dimensión) | N = 1: existencia, sin tasa |
| E-063 | Sondeo §R.4 | tool calling 2 pedidos × 2 modelos × N = 10; Ollama no hace cumplir el `enum` | b + a | Anexo E; `06` (negativa «piedra») | — |
| E-063b | Sondeo §R.5 | consecuencias para la guía | d | — | criterio ya absorbido por el plan |
| E-063c | Sondeo §R.6 y `Sondeo-Evidencia/2026-10-28/cifras*.{py,md}` | tabla única de cifras (28 filas + 5 de P2-10 con columna «servidor») | b | Anexo E, tabla de cifras | fuente de toda latencia de la guía (P-21) |
| E-063d | Sondeo §R.7 y `Ronda-2/evidencia-{estación-2}-ollama/sondeo/` | segundo servidor de prueba: imagen por digest, límites 14 CPU / 34 GiB, modelos | b | Anexo E, con el rótulo «estación de laboratorio de 15 vCPU» | sin dirección ni nombre de equipo |

## 4. Mesa, ciclo 1 (ronda 1)

| # | Id de bitácora | Qué es | Destino | Archivo | Motivo / nota |
|---|---|---|---|---|---|
| E-064 | AH-02 c1: S-R | recuperación con los 12 enunciados reales (hit@1 5/6, hit@3 6/6; no respondibles puntúan más alto) | a | `04` (oro con no respondibles, métricas de P-22; pendiente P-05) | la cifra de hoy no entra: `04` la vuelve a medir como tasa de la tarea (R-LLM-3d) |
| E-065 | AH-02 c1: S-I | intervalos de Wilson de tasas de la integración | d | — | aritmética sobre tasas que no entran a la guía |
| E-066 | AH-02 c1: S-N, F-Q | Evaluation en nuget.org; advertencia oficial de `RetrievalEvaluator`/`GroundednessEvaluator` (modelos chicos o locales; ajustados con GPT-4o) | c | Anexo D (§8, juez) | la advertencia es obligatoria en §8 (P-38) |
| E-067 | Experto IA: S1 | embeddings con y sin instrucción en la consulta | a | `04` (consulta con y sin instrucción) | — |
| E-068 | Experto IA: S2, S3, S4, S5 | tokenizadores difieren 16 %; truncado con el 4b se come el dato; `prompt_eval_cached_count` existe y el reuso es parcial; presupuesto = `num_ctx` − salida | b | Anexo E (regla de ventana; caché de prefijo sin cifra de patrón) | sostiene P-19 y P-20; S3 se repite en `05` (pendiente P-08) |
| E-069 | Experto IA: fuentes | ficha del modelo de embeddings (MRL 32–1024) y docs | c | Anexo D | — |
| E-070 | Implementador K1 | snippets de N6 literales: 11 `using` faltantes | a | todas las carpetas (RV-19) | — |
| E-071 | Implementador K2–K6 | recompilación de sondas de la bitácora | d | — | las reemplaza la compilación de `Examples/` |
| E-072 | Implementador K7 | CS0182 al pasar la dimensión al atributo | a | `04` (definición en tiempo de ejecución, B-09) | el error no se muestra; se muestra la forma que compila |
| E-073 | Implementador K8, K9 | `num_ctx` por `AdditionalProperties` o `RawRepresentationFactory`; `InputTokenCount` con y sin `num_ctx` contra el 0.5b | a + b | `01` (num_ctx por pedido); Anexo E | — |
| E-074 | Implementador K10 | el contenedor del SDK no llega a `localhost` del anfitrión | d | — | no se cita; su consecuencia es la red compartida de la receta del Anexo E, que verifica la compuerta de clon limpio |
| E-075 | Senior .NET c1: S-sonda1, S-sonda2, S-sonda3 | spans según el orden, `AddChatClient` Scoped, `[Experimental]` en lo que se enseña, dónde se fija `num_ctx` | a | `09`, `01`; compilación sin `NoWarn` en todas | — |
| E-076 | Senior .NET c1: S-sonda4, S-caso-base-lectura | agregados por medio con el `ValueConverter` del caso base; cierre de compilación de la copia | a | demo (D4, B-14; `PROCEDENCIA.md`) | — |
| E-077 | Senior .NET c1: S-nuget, S-ollama-openai-compat | versiones; `num_ctx` no viaja por `/v1` | c | Anexo D (tabla de paquetes; doc de compatibilidad de Ollama) | — |
| E-078 | CAT-OP O1, O2 | versiones y deprecaciones; cadencia de MAF | c | Anexo D | — |
| E-079 | CAT-OP O3 | `prompt_eval_count` con caché; 1469 tokens en 111,7 s; cola serializa | b | Anexo E (tabla de cifras) | sostiene «timeout sin valor por defecto en código» (P-11) |
| E-080 | CAT-OP O4 | `ValidateScopes = false` con Singleton: la herramienta no falla | a | `09` (B-13) | la forma (a)–(c) de P2-05 la reemplaza como prueba |
| E-081 | CAT-OP O5 | contexto fijo de ~1540 tokens: 71,7 s → 26,0 s (reuso parcial) | b | Anexo E | sostiene P-19 sin cifra de patrón |
| E-082 | CAT-OP E4 | docs de *Background responses* y de *Scope validation* | c | Anexo D | DI overview, ms.date 2026-01-26 (D-06) |
| E-083 | CAT-formal F-S1 | `LocalidadRules` copiada: CP con dígitos no ASCII válido, nombre de 61 válido; `CosineSimilarity` frente a `CosineDistance` | a | demo `Cableado/` (reglas heredadas de P-16); `04` (puntaje e inversión con SqliteVec) | — |
| E-084 | CAT-formal F-X3a, F-X3b | truncado entre la mitad y la ventana | b | Anexo E (regla de ventana) | — |
| E-085 | CAT-formal F-W | intervalos de Wilson | d | — | aritmética sobre tasas que no entran |
| E-086 | Verificación R1, R2, R3, R8, R11 | versiones, deprecaciones, soporte de .NET 10 (LTS, fin 2028-11-14), hitos de N1b, paquetes de N5 (`Aspire.Hosting.Ollama` 404) | c | Anexo D | — |
| E-087 | Verificación R9 | valores por defecto de MEAI (`MaximumIterationsPerRequest` 40, errores 3) | a | `06` (CTRL-05 por configuración) | — |
| E-088 | Verificación R4 | mutación que la prueba por `grep` no detecta | a | `13` (caso rojo) | — |
| E-089 | Verificación R5, R6, R10 | re-corridas idénticas de EA-5, X1 y `compilecheck` | d | — | reproducciones; las reemplazan `05`, `09` y `10` |
| E-090 | Verificación R7 | versión y tres digests del servidor de prueba | b | Anexo E (receta: `ollama list` contra el digest) | — |
| E-091 | Verificación G1, G2, G3; AH-01 c1 `sonda-rpriv-y-snippets`; didáctica; requisitos; edición bibliográfica | conteos, enlaces y R-PRIV sobre la bitácora | d | — | son compuertas de proceso, no contenido |
| E-092 | Arquitectura c1: S1–S3; `cockburn-cita.txt` | carpetas de ApiWeb y su cierre; cita de Cockburn | a + c | demo (`PROCEDENCIA.md`); Anexo D (puerto y adaptador) | — |
| E-093 | Abogado del diablo: AD-S1, AD-S2, AD-W1, AD-W2, AD-W3 | herramientas con 2b y 4b; límites del contenedor (4 CPU / 5 GB); etiquetas de qwen3.5; ficha del 35B-A3B; OWASP LLM06 | d (AD-S1); b (AD-S2); c (AD-W1…W3) | Anexo E (rótulo); Anexo D | AD-S1 la reemplaza la comparación D1–D6 (E-098); AD-W1 dice q4_K_M para el 2b y lo servido es Q8_0 (RV-24: rige el digest) |
| E-093b | AH-01 c1: `fuentes-consultadas.md` | OWASP LLM 2025 y Agentic 2026, MCP 2026-07-28, playbook de Microsoft | c | Anexo D (§7, §8) | — |

## 5. Mesa, ciclo 1, ronda 2 (consultas dirigidas que la guía cita)

| # | Id de bitácora | Qué es | Destino | Archivo | Motivo / nota |
|---|---|---|---|---|---|
| E-094 | Operación PC-02 (`PC02-*`) | doble capa: doble conteo (48 frente a 24); rama A: acierto con 0 spans y contador en 1 | a | `09` (pruebas (1)–(4) de P2-06, S-39) | la doble capa sólo como descartada (RV-03) |
| E-095 | Operación PC-06 (`PC06-*`, `PC06-fuente-ollama-v0.40.11.txt`) | sin `num_ctx` recarga con 4096 y trunca a 2050 (5 de 5 con el 0.5b); recarga del 4b al alternar `num_ctx` | b + a + c | Anexo E (filas 2, 2r y 3 de §R.6); `09` (prueba de P-11 (4) con el prompt de 5134 tokens); Anexo D (`server/routes.go`, `server/sched.go` en v0.40.11) | — |
| E-096 | AH-02 formal PC-10 (`evidencia-AH-02-formal/`) | 6 pedidos × semillas 1..8; heterogeneidad entre pedidos; R-LLM-1…5 | b + c | Anexo E (frase de la tensión 1, §10.2 §6); Anexo D (Bowyer et al. arXiv:2503.01747v3; Miller arXiv:2411.00640v1; Modelfile `seed`) | la frase entra tal cual (D-R2-5); nunca Wilson sobre K·m |
| E-097 | (réplica de EA-6 dentro de E-096) | vía B buscó en 12 de 16 corridas en un pedido | b | Anexo E | forma parte del mismo registro |
| E-098 | Comparación 2b/4b (`evidencia-comparacion-2b-4b/`) | D1, D3, D3-T, D6 con N = 10 por pedido y modelo; Wilson; pares discordantes | b | Anexo E (rótulo de §10.2 §0.4, tal cual) | 2b siempre con Q8_0, 2,68 GB y digest (RV-24); la guía no dice que el 2b sea más rápido |
| E-099 | Definiciones: E-DEF-1 | con el mismo código, el guion del modelo cambia el orden de las herramientas o anula su uso | a | `06` o `07` (propuesta: dos guiones en `Cableado/`) | sostiene la definición de agente de §7; si no se construye, pasa a (d) «se enseña con la definición y la fuente» |
| E-100 | Definiciones: `raw/` y `fuentes-sha256.txt` | Anthropic, LangGraph, MAF Overview y Looping, .NET tool calling | c | Anexo D (§7 y Anexo C), con sus hashes | — |
| E-101 | AH-01 R2: R, D1 | reflexión de la aprobación; integridad de `ApprovalRequiredAIFunction` (forjada, sesión serializada alterada ejecutó 77 en lugar de 7, `RequestId` no secreto) | a | `07` (D1b, D1h, dos sesiones; contrato A1–A5) | — |
| E-102 | AH-01 R2: D2 | Singleton/Scoped × `ValidateScopes` × dos sesiones concurrentes | a | `09` y demo (B-13, prueba (a)–(c) de P2-05) | D-06 con el título de P2-05 |
| E-103 | AH-01 R2: D3 | `GetResponseAsync<AccionPropuesta>` acepta `tipo = 5` e `id = -1` | a | demo `Cableado/` (B-02) y `03` | el caso «id de otra sesión» es prueba nueva, no medida |
| E-104 | AH-01 R2: A | ApiWeb real: id débil elegido por el cliente, 404 entre sesiones, ids globales | a | demo `tests/Cableado/` (propuesta: dos clientes con el mismo id débil) | sostiene RV-20; si la prueba no se construye, la frase se apoya en la lectura de `Sessions/` y queda rotulada como lectura de código |
| E-105 | AH-01 R2: L | inyección por `Localidad.Nombre`: 0/10 bajas, Wilson [0; 0,28]; repitió el texto 10/10; lo señaló 3/10 | b + a | Anexo E; demo `ConModelo/` (CTRL-14, B-15) | estimando «este pedido»; «el control sigue siendo» la ausencia de herramientas de escritura |
| E-106 | AH-01 R2: fuentes S-CMS1, S-AR1 | ResDAC *Cell Size Suppression Policy* (01/26/2024); Ley 25.326 arts. 2 y 28 (InfoLEG) | c | Anexo D (§8, CTRL-07) | ResDAC como práctica, no como norma |
| E-107 | Senior .NET R2: `R2-cuerpo-*` | servidor falso que registra cuerpo: credenciales por pedido viajan en el cuerpo; `TopK` y `MaxOutputTokens` por vía | a | `01` (B-06, S-10) | la captura que se publique pasa la compuerta con `cabeceras=0` |
| E-108 | Senior .NET R2: `R2-real-*` | `prompt_eval_cached_count` por `IChatClient` y por `/v1`; `MaxOutputTokens = 3` → 57 salidos | b + a | Anexo E; `01` (corrida por `/v1`) y `09` (handler) | — |
| E-109 | Senior .NET R2: `R2-mcp-*` | `AllowedHosts`, `RequireAuthorization`, `Origin`; una sola `AIFunction` → `McpServerTool.Create` | a | `08` (B-07, S-33) | `08` puede partir de `R2-mcp-Program.cs` |
| E-110 | Senior .NET R2: `R2-reflex-*`, `R2-nuget-*`, `R2-ollama-openai-compat-campos.txt`, `R2-mcp-spec-transports-origin.txt` | reflexión de OllamaSharp/MCP; versiones; campos de `/v1`; advertencia de Streamable HTTP (2025-06-18) | a + c | `08`, `01`; Anexo D (docs de compatibilidad con OpenAI de Ollama; MCP 2026-07-28 con la 2025-06-18 como antecedente) | — |
| E-111 | Segundo servidor, PC-07 (`evidencia-{estación-2}-ollama/pc07/`, `01-registro-manifiestos.txt`, `ollama-library-qwen3.5-tags-2026-10-28.html`) | 35b-a3b: 21 GiB cargado; herramientas 13,3 s frente a 3,2 s del 4b | b + c | Anexo E (fila 5 de §R.6, estación de 15 vCPU); Anexo D (biblioteca de Ollama) | el 35b-a3b no es candidato por defecto |
| E-112 | Segundo servidor, PC-08 (`evidencia-{estación-2}-ollama/pc08/`) | costo del juez: 1285 s por caso en la estación de 4 núcleos; unos 34 s por evaluación en la de 15 vCPU; razonamiento por defecto da `Inconclusive` | b | Anexo E (filas 4 y 4b de §R.6, con el rótulo de cada estación) | sin juez en la demo; «no medido» como calidad |
| E-113 | Segundo servidor: `00-bajadas.txt`, `memoria.sh` | duración de las bajadas y memoria del anfitrión | d | — | operativo; la memoria del 35b ya entra por E-111 |
| E-114 | Aprobaciones de ronda 2: `P2-06v2-*`, `P206v2-*` | contador por los dos métodos de lectura de caché, regla (a) por scope, `EnableCaching` | a | `09` (pruebas (2b) y (4), B-04) | — |
| E-115 | Aprobaciones de ronda 2: `rpriv-v2-*`, `V-rpriv-*`, `sinteticos-prueba.txt` | diseño de la compuerta R-PRIV v2 | d | — | compuerta de proceso |

## 6. Aplicación del ciclo 1 y de la ronda 2

| # | Id de bitácora | Qué es | Destino | Archivo | Motivo / nota |
|---|---|---|---|---|---|
| E-116 | `aplicacion/sonda-limitador/` | `AddRateLimiter`: 1–3 en 200, el 4.º en 503 con `Retry-After: 30` | a | `09` (S-41) y demo | — |
| E-117 | `aplicacion/sonda-opciones/` | validación de `OpcionesDeIA` al arrancar | a | `01` (B-01) | — |
| E-118 | `aplicacion/qwen3.5-4b-card-l835-838.txt` | preajuste «Instruct (or non-thinking) mode for general tasks» de la ficha del modelo | c | Anexo D (§2 y §5, P-33) | URL y fecha de consulta |
| E-119 | `aplicacion/conteo-preguntas*`, `verificaciones-2026-10-28.txt`, `verificar-ciclo-1.sh`, `rpriv*` | conteo de preguntas y verificación de la aplicación | d | — | proceso; el conteo lo usa `plan-de-preguntas.md` |
| E-120 | `Ronda-2/aplicacion/verificar-pc06*`, `verificar-p2-10*` | comprobación de las filas nuevas de §R.6 | d | — | verifican filas que ya entran por E-063c |
| E-121 | `Ronda-2/aplicacion/rpriv*`, `verificaciones-2026-10-28.txt`, `verificar-ronda-2.sh` | compuerta R-PRIV v2 y verificación de la ronda | d | — | proceso |

## 7. Conteos (2026-10-28)

- **Filas: 126** (E-001…E-121, más E-059b, E-063b, E-063c, E-063d y E-093b). **Sin destino: 0.**
- **Por destino principal** (la primera letra de la columna): (a) ejemplo o demo **45**; (b) R-LLM del Anexo E **21**; (c) fuente del Anexo D **26**; (d) se omite **34**.
- **Filas con destino doble** (la evidencia sostiene una afirmación y además la reproduce un ejemplo, o se cita como fuente): 17.
- **Propuestas que dependen de que se construya la pieza** (si no se construye, pasan a (d) con el motivo escrito en la fila): E-013, E-018, E-099, E-104.
- **A ratificar por la presidencia:** que la demo cuente como destino (a) (misma marca que en la matriz de snippets).
