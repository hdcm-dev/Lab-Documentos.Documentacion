# E1 · Matriz afirmación ↔ artefacto

Etapa E1 del plan integrado (`../05-Plan-Integrado.md` §5; C-1.1: la matriz vive en la bitácora y el libro sólo recibe el Anexo E.1 actualizado). Guía 0.11.0, sha256 `c8defd8324497c4279a3dfd57ce5d2757326ad966813a9f9797d0196d9b7ce3d`, sin cambios en esta etapa.

## Índice

1. [Definiciones y marcas](#1-definiciones-y-marcas)
2. [Método](#2-método)
3. [Matriz por ejemplo (Anexo E.1)](#3-matriz-por-ejemplo-anexo-e1)
4. [Matriz de afirmaciones de los bloques de ejemplos](#4-matriz-de-afirmaciones-de-los-bloques-de-ejemplos)
5. [Resumen y cobertura](#5-resumen-y-cobertura)

## 1. Definiciones y marcas

- **Afirmación sobre un ejemplo:** oración de la guía que dice qué hace, qué devolvió o qué midió un ejemplo de `Examples/01…17` (o la demo, cuando se la cita desde un ejemplo).
- **Artefacto:** archivo o comando que permite comprobarla: el código y `tools/verificar.sh build` (garantías de código y salidas `--fake`), o un registro R-LLM archivado en `Bitacoras/Evidencia/`.
- **Marcas:** `CÓDIGO (build)` comprobado por el build de esta etapa (561/561, rc 0); `VERIFICADO (registro)` hay registro archivado de esa corrida; `HISTORIA` corrida del servidor retirado, con su registro en `Evidencia/R-LLM/` (la guía ya la rotula «Historia»); `NO EJECUTADO (declarado)` la guía lo declara así; `NO VERIFICADO` sin artefacto. «Hereda» = la oración remite al rótulo anterior («con el mismo rótulo»).

## 2. Método

Extracción automática (`{dir-de-trabajo}/scripts/matriz.py`) de las oraciones con «Observado», IC95, `k/n`, «pasa», «no ejecutado» o «no medido» dentro de cada bloque «**NN · …**» de la guía; búsqueda del registro por ejemplo, estación y fecha; corrección manual de una fila (l. 2226, salida del guion). El texto de cada fila está recortado a 170 caracteres. Las cifras de prosa fuera de los bloques las controla `tools/comparar-ac9.py cifras` (E11); los bloques de código contra sus archivos, `comparar-ac9.py bloques` (57 bloques, 0 diferencias en esta etapa).

## 3. Matriz por ejemplo (Anexo E.1)

| Ejemplo | Afirmación de E.1 (servidor y modelo) | Artefacto | Comando | Resultado E1 | Marca |
|---|---|---|---|---|---|
| 01 | servidor de chat, `qwen3.5:4b`; conducta | `Examples/01-…`; `Evidencia/R-LLM-2026-10-28/estacion-1/R-01` | `verificar.sh build` | 11/11, `--fake --verificar` rc 0 | CÓDIGO (build) + VERIFICADO (registro) |
| 02 | segundo servidor, vigente `qwen3.5:4b`; dos adaptadores | `Examples/02-…`; `Evidencia/R-LLM-2026-10-28/estacion-1/R-02` | ídem | 18/18 | CÓDIGO (build) + VERIFICADO (registro) |
| 03 | servidor de chat; conducta y tasas de la extensión | `Examples/03-…`; `Evidencia/R-LLM-2026-10-28/estacion-1/R-03` | ídem | 25/25 (tras el renombre) | CÓDIGO (build) + VERIFICADO (registro) |
| 04 | servidor de chat; conducta y tasa de la extensión | `Examples/04-…`; `…/estacion-1/R-04` | ídem | 124/124 | CÓDIGO (build) + VERIFICADO (registro) |
| 05 | segundo servidor, vigente `qwen3.5:4b`; duraciones | `Examples/05-…`; `…/PV-02/corrida-2026-11-01` | ídem | 15/15 | CÓDIGO (build) + VERIFICADO (registro PV-02) |
| 06 | servidor de embeddings, `qwen3-embedding:0.6b` | `Examples/06-…`; `…/estacion-1/R-06` | ídem | 24/24 | CÓDIGO (build) + VERIFICADO (registro) |
| 07 | servidor de chat; embeddings previos; tasas | `Examples/07-…`; `Evidencia/07-…`, `Evidencia/R-LLM/07-…` | ídem | 23/23 | CÓDIGO (build) + HISTORIA |
| 08 | servidor de chat, `qwen3.5:4b` (herramientas) | `E1/Evidencia/T-qwen/08-…` | `verificar.sh correr 08-… --con-modelo` ×5 | 65/65; T-qwen 5/5 | VERIFICADO (E1) |
| 09 | servidor de chat (herramientas) | `E1/Evidencia/T-qwen/09-…` | ídem ×5 | 10/10; T-qwen 5/5 | VERIFICADO (E1) |
| 10 | sin modelo | `Examples/10-…` | `verificar.sh build` | 11/11 | CÓDIGO (build) |
| 11 | servidor de chat (herramientas, aprobación) | `E1/Evidencia/T-qwen/11-…` | `correr 11-… --con-modelo` ×5 | 13/13; T-qwen 5/5 | VERIFICADO (E1) |
| 12 | servidor de chat; conducta | `E1/Evidencia/T-qwen/12-…` | ídem ×5 | 27/27; 5 corridas rc 0, oráculo 2/2 por variante; **sin herramientas ofrecidas** | VERIFICADO (E1) |
| 13 | servidor de chat, del lado cliente MCP | `E1/Evidencia/T-qwen/13-…`, `E1/Evidencia/T-3/` | ídem ×5; T-3 | 28/28; T-qwen 5/5; protocolo 2026-07-28 | VERIFICADO (E1) |
| 14 | sin modelo | `Examples/14-…` | `verificar.sh build` | 17/17 | CÓDIGO (build) |
| 15 | segundo servidor; `qwen3.5:4b` LLM juez no calibrado | `Examples/15-…`; `Evidencia/15-…` | ídem | 37/37; la corrida 2026-10-29 «no medido (41/52 < 45/52)» declarada en el texto | CÓDIGO (build) + NO VERIFICADO (juez, declarado por el libro) |
| 16 | servidor de chat; tasa sobre un texto de ataque | `E1/Evidencia/T-qwen/16-…` | `correr 16-… --con-modelo` ×5 | 15/15; T-qwen 5/5 | VERIFICADO (E1) |
| 17 | servidor de chat; conducta | `Examples/17-…`; `…/estacion-1/R-17` | `verificar.sh build` | 25/25 | CÓDIGO (build) + VERIFICADO (registro) |
| `_Comun` | capa única, guion, registro | `Examples/_Comun/…Pruebas` | ídem | 73/73 | CÓDIGO (build) |

Todas las corridas «VERIFICADO (E1)» tienen el rótulo de `Ensayos.md` §1. Las filas con registro de la estación 1 o 2 del 2026-10-29 remiten a `Bitacoras/Evidencia/R-LLM-2026-10-28/`.

## 4. Matriz de afirmaciones de los bloques de ejemplos

| Línea (0.11.0) | Ej. | Afirmación (recortada) | Artefacto (relativo a `Bitacoras/Evidencia/` o a la guía) | Marca |
|---|---|---|---|---|
| 1107 | 01 | Observado en el laboratorio: `qwen3.5:4b` (digest `d8b0f5e9760c`), Ollama 0.40.11, estación 1, servidor compartido, `num_ctx` 8.192, 2026-10-29; 2 entradas distintas, … | R-LLM-2026-10-28/estacion-1/R-01 | VERIFICADO (registro) |
| 1113 | 01 | Observado en el laboratorio: `qwen3.5:4b` (digest `2a654d98e6fb`), Ollama 0.32.0-rc0, sólo CPU, servidor compartido, 2026-10-27; estímulo del mismo autor. | R-LLM/01-Chat-Y-Streaming.fake.jsonl, R-LLM/01-Chat-Y-Streaming.fake.reverificacion.jsonl | HISTORIA |
| 1166 | 02 | Observado: `qwen2.5:0.5b` (`a8b0c5157701`), Ollama 0.40.11, segundo servidor, 2026-10-27. | R-LLM/02-Cambio-De-Adaptador.modelo.jsonl, R-LLM/02-Cambio-De-Adaptador.fake.jsonl | HISTORIA |
| 1242 | 03 | Observado: `qwen3.5:4b` (`2a654d98e6fb`), Ollama 0.32.0-rc0, sólo CPU, servidor compartido, 2026-10-27; estímulo del mismo autor. | R-LLM/03-Salida-Estructurada.fake.jsonl, R-LLM/03-Salida-Estructurada.fake-ext.jsonl | HISTORIA |
| 1260 | 03 | oráculo: pasa | Examples/03-Salida-Estructurada · `verificar.sh build` | CÓDIGO (build) |
| 1263 | 03 | En la extensión de medición, con el mismo rótulo, las ocho decisiones pasaron el oráculo, IC95 [0,631; 1]; las ocho respuestas fueron JSON válido; y en los cuatro pedi… | R-LLM/03-Salida-Estructurada.fake.jsonl, R-LLM/03-Salida-Estructurada.fake-ext.jsonl | HISTORIA (hereda el rótulo previo) |
| 1299 | 04 | Observado con el rótulo de 03; estímulo del mismo autor. | R-LLM/04-Normalizacion-Contra-Catalogo.modelo.jsonl, R-LLM/04-Normalizacion-Contra-Catalogo.modelo-ext.jsonl | HISTORIA |
| 1308 | 04 | En la extensión, con el mismo rótulo, 7 de 8 expresiones terminaron con la clave esperada, IC95 [0,473; 0,997]. | R-LLM/04-Normalizacion-Contra-Catalogo.modelo.jsonl, R-LLM/04-Normalizacion-Contra-Catalogo.modelo-ext.jsonl | HISTORIA (hereda el rótulo previo) |
| 1310 | 04 | Observado: `qwen3.5:4b`, servidor compartido, 2026-10-27; humo de la demo: dejó `habitantes` en `null`. | R-LLM/04-Normalizacion-Contra-Catalogo.modelo.jsonl, R-LLM/04-Normalizacion-Contra-Catalogo.modelo-ext.jsonl | HISTORIA |
| 1534 | 05 | Observado en el laboratorio: `qwen2.5:0.5b` (digest `a8b0c5157701`), Ollama 0.40.11, Ollama propio, 2026-10-27; estímulo del mismo autor. | R-LLM/05-Contexto-Completo-Con-Prefijo.calentamiento.fake.corrida-4.jsonl, R-LLM/05-Contexto-Completo-Con-Prefijo.modelo.corrida-4.jsonl | HISTORIA |
| 1539 | 05 | \| p02 \| 23.872,8 \| 487,3 \| pasa \| | R-LLM/05-Contexto-Completo-Con-Prefijo.calentamiento.fake.corrida-4.jsonl, R-LLM/05-Contexto-Completo-Con-Prefijo.modelo.corrida-4.jsonl | HISTORIA (hereda el rótulo previo) |
| 1540 | 05 | \| p03 \| 22.215,8 \| 384,7 \| pasa \| | R-LLM/05-Contexto-Completo-Con-Prefijo.calentamiento.fake.corrida-4.jsonl, R-LLM/05-Contexto-Completo-Con-Prefijo.modelo.corrida-4.jsonl | HISTORIA (hereda el rótulo previo) |
| 1541 | 05 | \| p04 \| 19.384,3 \| 436,1 \| pasa \| | R-LLM/05-Contexto-Completo-Con-Prefijo.calentamiento.fake.corrida-4.jsonl, R-LLM/05-Contexto-Completo-Con-Prefijo.modelo.corrida-4.jsonl | HISTORIA (hereda el rótulo previo) |
| 1542 | 05 | \| p05 \| 19.872,0 \| 475,5 \| pasa \| | R-LLM/05-Contexto-Completo-Con-Prefijo.calentamiento.fake.corrida-4.jsonl, R-LLM/05-Contexto-Completo-Con-Prefijo.modelo.corrida-4.jsonl | HISTORIA (hereda el rótulo previo) |
| 1543 | 05 | \| p06 \| 21.840,6 \| 468,3 \| pasa \| | R-LLM/05-Contexto-Completo-Con-Prefijo.calentamiento.fake.corrida-4.jsonl, R-LLM/05-Contexto-Completo-Con-Prefijo.modelo.corrida-4.jsonl | HISTORIA (hereda el rótulo previo) |
| 1560 | 05 | par p02: pasa (con/sin = 0.022) | Examples/05-Contexto-Completo-Con-Prefijo · `verificar.sh build` | CÓDIGO (build) |
| 1789 | 06 | Observado en el laboratorio: `qwen3-embedding:0.6b` (digest `ac6da0dfba84`), Ollama 0.40.11, Ollama propio, 2026-10-27; estímulo del mismo autor. | R-LLM/06-Embeddings-Y-Busqueda-Semantica.modelo.jsonl, R-LLM/06-Embeddings-Y-Busqueda-Semantica.fake.reverificacion.jsonl | HISTORIA |
| 1793 | 06 | modelo sin-instruccion           hit@1 10/12 = 0.833   hit@3 12/12 = 1.000   MRR 0.889 | R-LLM/06-Embeddings-Y-Busqueda-Semantica.modelo.jsonl, R-LLM/06-Embeddings-Y-Busqueda-Semantica.fake.reverificacion.jsonl | HISTORIA (hereda el rótulo previo) |
| 1795 | 06 | léxica                           hit@1  7/12 = 0.583   hit@3  8/12 = 0.667   MRR 0.679 | R-LLM/06-Embeddings-Y-Busqueda-Semantica.modelo.jsonl, R-LLM/06-Embeddings-Y-Busqueda-Semantica.fake.reverificacion.jsonl | HISTORIA (hereda el rótulo previo) |
| 1796 | 06 | azar (permutación con semilla)   hit@1  1/12 = 0.083   hit@3  3/12 = 0.250   MRR 0.259 | R-LLM/06-Embeddings-Y-Busqueda-Semantica.modelo.jsonl, R-LLM/06-Embeddings-Y-Busqueda-Semantica.fake.reverificacion.jsonl | HISTORIA (hereda el rótulo previo) |
| 1803 | 06 | Generador estable FNV-1a: no ejecutado contra un modelo de embeddings. | Examples/06-Embeddings-Y-Busqueda-Semantica/README.md | NO EJECUTADO (declarado) |
| 1889 | 07 | Observado en el laboratorio: `qwen3.5:4b` (digest `2a654d98e6fb`), Ollama 0.32.0-rc0, sólo CPU, servidor compartido, 2026-10-27; embeddings con el rótulo de 06; estímu… | R-LLM/07-RAG-Con-Citas.fake.jsonl, R-LLM/07-RAG-Con-Citas.modelo.jsonl | HISTORIA |
| 1903 | 07 | Con el mismo rótulo: afirmación correcta 7/7, IC95 [0,590; 1]; cita válida en las cinco sin valor verificable 5/5, IC95 [0,478; 1]; | R-LLM/07-RAG-Con-Citas.fake.jsonl, R-LLM/07-RAG-Con-Citas.modelo.jsonl | HISTORIA (hereda el rótulo previo) |
| 1903 | 07 | «No sé» exacto 0/4, IC95 [0; 0,602]; | R-LLM/07-RAG-Con-Citas.fake.jsonl, R-LLM/07-RAG-Con-Citas.modelo.jsonl | HISTORIA (hereda el rótulo previo) |
| 1903 | 07 | «cita y contradice» (nombre de la métrica en el registro), que cuenta una cita válida con un valor que el literal citado no fija, 1/12, IC95 [0,002; 0,385] (r09: cita … | R-LLM/07-RAG-Con-Citas.fake.jsonl, R-LLM/07-RAG-Con-Citas.modelo.jsonl | HISTORIA (hereda el rótulo previo) |
| 1913 | 07 | Observado: `qwen3.5:4b`, servidor compartido, 2026-10-27; humo de la demo, con embeddings precalculados de `qwen3-embedding:0.6b`. | R-LLM/07-RAG-Con-Citas.fake.jsonl, R-LLM/07-RAG-Con-Citas.modelo.jsonl | HISTORIA |
| 2212 | 08 | Observado: `qwen3.5:4b`, servidor compartido, 2026-10-27; estímulo del mismo autor. | R-LLM/08-Primera-Herramienta-Solo-Lectura.fake-ext.jsonl, R-LLM/08-Primera-Herramienta-Solo-Lectura.fake.jsonl | HISTORIA |
| 2218 | 08 | En la extensión, con el mismo rótulo, el modelo invocó la herramienta con argumentos válidos en las 4 entradas legítimas, IC95 [0,398; 1]. | R-LLM/08-Primera-Herramienta-Solo-Lectura.fake-ext.jsonl, R-LLM/08-Primera-Herramienta-Solo-Lectura.fake.jsonl | HISTORIA (hereda el rótulo previo) |
| 2218 | 08 | El oráculo «no inventa» dio 6 de 8, IC95 [0,349; 0,968], y sus dos fallas no son invenciones: en una el modelo sumó dos conteos que devolvieron las herramientas, en ot… | R-LLM/08-Primera-Herramienta-Solo-Lectura.fake-ext.jsonl, R-LLM/08-Primera-Herramienta-Solo-Lectura.fake.jsonl | HISTORIA (hereda el rótulo previo) |
| 2226 | 08 | oráculo no-inventa: pasa | Examples/08-Primera-Herramienta-Solo-Lectura · `verificar.sh build` | CÓDIGO (build) — salida del guion |
| 2273 | 09 | Observado: `qwen3.5:4b`, servidor compartido, 2026-10-27; estímulo del mismo autor. | R-LLM/09-Caso-De-Uso-Como-Herramienta.modelo.jsonl, R-LLM/09-Caso-De-Uso-Como-Herramienta.fake.jsonl | HISTORIA |
| 2281 | 09 | llamadas al modelo: 2 · oráculo alta-con-aprobacion (esperado rechazo): pasa | R-LLM/09-Caso-De-Uso-Como-Herramienta.modelo.jsonl, R-LLM/09-Caso-De-Uso-Como-Herramienta.fake.jsonl | HISTORIA (hereda el rótulo previo) |
| 2339 | 10 | oráculo workflow-igual-funcion (esperado completa[1,2,1]): pasa | Examples/10-Workflow-Y-Contraejemplo · `verificar.sh build` | CÓDIGO (build) |
| 2366 | 11 | Qué mirar: cada petición arma el agente de nuevo, y lo único que pasa de una a otra es `estado`, la `AgentSession` serializada. | Examples/11-Agente-Con-Aprobacion · `verificar.sh build` | CÓDIGO (build) |
| 2368 | 11 | Observado: `qwen3.5:4b`, servidor compartido, 2026-10-27; estímulo del mismo autor. | R-LLM/11-Agente-Con-Aprobacion.fake.jsonl, R-LLM/11-Agente-Con-Aprobacion.modelo.jsonl | HISTORIA |
| 2377 | 11 | llamadas al modelo: 2 · oráculo agente-con-aprobacion (esperado baja): pasa | R-LLM/11-Agente-Con-Aprobacion.fake.jsonl, R-LLM/11-Agente-Con-Aprobacion.modelo.jsonl | HISTORIA (hereda el rótulo previo) |
| 2421 | 12 | oráculo porcentajes-del-servicio: pasa | Examples/12-Uno-O-Varios-Agentes · `verificar.sh build` | CÓDIGO (build) |
| 2427 | 12 | oráculo porcentajes-del-servicio: pasa | Examples/12-Uno-O-Varios-Agentes · `verificar.sh build` | CÓDIGO (build) |
| 2436 | 12 | Observado: `qwen3.5:4b`, servidor compartido, 2026-10-27; estímulo del mismo autor. | R-LLM/12-Uno-O-Varios-Agentes.modelo.jsonl, R-LLM/12-Uno-O-Varios-Agentes.fake.jsonl | HISTORIA |
| 2478 | 13 | Observado: `qwen3.5:4b`, servidor compartido, 2026-10-27; estímulo del mismo autor. | R-LLM/13-Servidor-Y-Cliente-MCP.fake.jsonl, R-LLM/13-Servidor-Y-Cliente-MCP.modelo.jsonl | HISTORIA |
| 2486 | 13 | oráculo mcp-sesion-fija: pasa | R-LLM/13-Servidor-Y-Cliente-MCP.fake.jsonl, R-LLM/13-Servidor-Y-Cliente-MCP.modelo.jsonl | HISTORIA (hereda el rótulo previo) |
| 2729 | 14 | oráculo anotaciones-coinciden: pasa | Examples/14-Anotaciones-SK-vs-MEAI · `verificar.sh build` | CÓDIGO (build) |
| 2736 | 14 | oráculo anotaciones-coinciden: pasa | Examples/14-Anotaciones-SK-vs-MEAI · `verificar.sh build` | CÓDIGO (build) |
| 3042 | 15 | Observado: `qwen2.5:0.5b`, Ollama propio, 2026-10-27; estímulo del mismo autor. | R-LLM/15-Pruebas-Y-Evaluacion.fake.jsonl, R-LLM/15-Pruebas-Y-Evaluacion.modelo.jsonl | HISTORIA |
| 3060 | 15 | deterministas sobre las 16 de 07: pasan 12/16 (coinciden con 07: 16/16) | Examples/15-Pruebas-Y-Evaluacion · `verificar.sh build` | CÓDIGO (build) |
| 3061 | 15 | deterministas sobre la calibración: detectan 5/5 perturbaciones y aceptan 5/5 correctas | Examples/15-Pruebas-Y-Evaluacion · `verificar.sh build` | CÓDIGO (build) |
| 3062 | 15 | llamadas al juez: 52 · salidas interpretables: 51/52 | Examples/15-Pruebas-Y-Evaluacion · `verificar.sh build` | CÓDIGO (build) |
| 3063 | 15 | acuerdo juez-oráculo determinista (16 salidas de 07): 15/16 (excluidas 0) | Examples/15-Pruebas-Y-Evaluacion · `verificar.sh build` | CÓDIGO (build) |
| 3064 | 15 | acuerdo juez-anotador (10 de calibración, mismo origen que las 16): 9/10 (excluidas 0) | Examples/15-Pruebas-Y-Evaluacion · `verificar.sh build` | CÓDIGO (build) |
| 3065 | 15 | juez: no descartado (9/10 ≥ 8); con 10 casos no queda validado | Examples/15-Pruebas-Y-Evaluacion · `verificar.sh build` | CÓDIGO (build) |
| 3070 | 15 | Probá otro LLM juez exportando `OLLAMA_PROPIO_MODEL` y corriendo `tools/verificar.sh correr 15-Pruebas-Y-Evaluacion --con-modelo`: el arnés pasa la variable al contene… | Examples/15-Pruebas-Y-Evaluacion · `verificar.sh build` | CÓDIGO (build) |
| 3319 | 16 | Observado: `qwen3.5:4b`, servidor compartido, 2026-10-27; estímulo del mismo autor. | R-LLM/16-Inyeccion-Indirecta.fake.jsonl, R-LLM/16-Inyeccion-Indirecta.interrumpida-1.jsonl | HISTORIA |
| 3368 | 13 | Observado: `qwen3.5:4b`, servidor compartido, 2026-10-27; humo de la demo: | R-LLM/13-Servidor-Y-Cliente-MCP.fake.jsonl, R-LLM/13-Servidor-Y-Cliente-MCP.modelo.jsonl | HISTORIA |
| 3371 | 13 | pd6-01 (demo-pd6-pedido): pasa Eliminar la localidad «Resistencia» (Chaco), id 2, de tu sesión. | R-LLM/13-Servidor-Y-Cliente-MCP.fake.jsonl, R-LLM/13-Servidor-Y-Cliente-MCP.modelo.jsonl | HISTORIA (hereda el rótulo previo) |
| 3582 | 17 | `Examples/17-Observabilidad-Y-Pipeline/Infrastructure/PipelineObservado.cs` | Examples/17-Observabilidad-Y-Pipeline · `verificar.sh build` | CÓDIGO (build) |
| 3620 | 17 | Observado: `qwen3.5:4b`, servidor compartido, 2026-10-27; estímulo del mismo autor. | R-LLM/17-Observabilidad-Y-Pipeline.fake.jsonl, R-LLM/17-Observabilidad-Y-Pipeline.modelo.jsonl | HISTORIA |


## 5. Resumen y cobertura

| Marca | Filas §4 |
|---|---|
| HISTORIA (con registro archivado del servidor retirado) | 37 |
| CÓDIGO (build) — salida `--fake` o garantía de código | 17 |
| VERIFICADO (registro) | 1 |
| NO EJECUTADO (declarado) | 1 |
| NO VERIFICADO | 0 |

- **Cobertura:** 56 de 56 afirmaciones de los bloques y 18 de 18 filas de E.1 tienen artefacto o marca: 100 % (criterio de aceptación de E1).
- **Lo que esta matriz no cubre:** las cifras de prosa fuera de los bloques (las cubre `comparar-ac9.py cifras` en E11) y la demo PD-1…PD-6 (fuera de `Examples/`; su cierre es el de §14.3 y `demo.sh`).
- **Hallazgos para E3:** las 37 filas HISTORIA son las que D-10 a manda al anexo «Procedencia»; la afirmación vigente de 05 en presente con el 0.5b (l. 1486) es CL-06 de `Cambios-Al-Libro.md`; 12 no ofrece herramientas al modelo (`Ensayos.md` §4).
