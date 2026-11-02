# Evidencia de CAT-OP (Operación y entrega + Rendimiento y costo), ciclo 1

Corridas del 2026-10-28 en estación 1. Endpoint del modelo sólo por `OLLAMA_ENDPOINT` (R-PRIV): no figura en ningún archivo. Corridas contra el modelo con turno exclusivo `<recurso-compartido>` (dueño `cat-op`) y compilación con turno `build`. Intermedios en `{dir-de-trabajo}/cat-op/`, sin bin/obj.

| Id | Qué | Nivel | Archivos | Resultado clave |
|---|---|---|---|---|
| O1 | Re-consulta de las 24 versiones de X0 en nuget.org (09:57 -03) | E1 | `O1-nuget-recheck.tsv` | Sin cambios respecto de X0 (08:56) |
| O2 | Deprecaciones en el registro de NuGet y cadencia de MAF estable | E1 | `O2-nuget-deprecaciones.txt` | `Microsoft.Extensions.AI.Ollama`: 14 versiones deprecadas, alternativa `OllamaSharp`. `Microsoft.Agents.AI`: 1.19.0 (08-22) … 1.26.0 (10-23), 7 estables en 62 días |
| O3 | Sonda HTTP `/api/chat`: caché de prefijo, velocidad de `prompt_eval`, cola con `OLLAMA_NUM_PARALLEL=1` | E1 (R-LLM) | `O3-sonda-operacion.py`, `O3-salida.jsonl`, `O3-stderr.txt` | (a) `prompt_eval_count` informa el largo total también cuando hay caché (1787/1787/1787; 1469/1469/1469). (b) `qwen3.5:4b`, 1469 tokens sin caché: **111,7 s**, unos 13 tok/s de `prompt_eval`, con el modelo ya cargado. Repetición idéntica: 0,7 s. (c) Dos pedidos simultáneos de 40 tokens: 9,2 s y 17,4 s; el segundo espera al primero |
| O4 | X1 [B] repetido con `ValidateScopes=false` (P-10), por el recurso `build` | E1 | `O4-Program.cs`, `O4-diff-respecto-de-X1.txt`, `O4-salida.txt` | Cliente Singleton sin validación: la herramienta **no falla**, ve el `SessionContext` raíz `(vacío)` en las dos sesiones. Con Scoped, cada sesión ve el suyo |
| O5 | Reuso del prefijo de un contexto fijo largo (unos 1540 tokens) cuando cambia la pregunta o se intercala otro pedido | E1 (R-LLM) | `O5-sonda-desalojo.py`, `O5-salida.jsonl`, `O5-stderr.txt` | En frío: 71,7 s. Mismo sistema y otra pregunta: 26,0 s. Pedido distinto intercalado y vuelta: 27,6 s. **El reuso es parcial (de 70 a 25 s), no de 70 a menos de 1 s**, salvo que el prompt sea idéntico (O3b) |

Parámetros R-LLM de O3 y O5: `qwen3.5:4b@d8b0f5e9760c…` y `qwen2.5:0.5b@a8b0c5157701…` (digests de Sondeo §R.1), Ollama 0.40.11, `temperature 0`, `seed 1`, `num_ctx 4096`, `think:false` en el 4b, `num_predict` 8 o 40, `stream:false`. N = 1 a 3 por condición. Criterio escrito antes de correr: O3a es éxito si `prompt_eval_count` es igual en las tres repeticiones; O3c es «serializa» si la pared del segundo pedido es al menos 1,5 veces la del primero; O5 es «reuso pleno» si la pared de ayuda-2 es menor que el 10 % de la de ayuda-1. **Son mediciones de una sola estación CPU-only en banco exclusivo. Describen a estación 1, no al patrón.** La velocidad de `prompt_eval` del 4b varió entre corridas: 13,2 tok/s en O3b y 21,9 tok/s en O5, con N = 1 cada una.

Fuentes E4 consultadas el 2026-10-28:

- Agent Framework, *Background responses*. https://learn.microsoft.com/en-us/agent-framework/agents/background-responses (ms.date 2026-09-24). Dice: «Currently, only agents that use the OpenAI Responses API support background responses».
- .NET DI, *Scope validation*. https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection/overview (ms.date 2026-01-26). Dice: «When an app runs in the development environment and calls CreateApplicationBuilder … the default service provider performs checks…». También dice que un servicio Scoped resuelto desde la raíz queda «effectively promoted to singleton».
