# Evidencia de AH-02 (Evaluación de sistemas LLM y RAG), ciclo 1, 2026-10-28

| Archivo | Qué es | Nivel |
|---|---|---|
| `sonda_recuperacion.py` + `salida-recuperacion.txt` | Recuperación por embeddings con `qwen3-embedding:0.6b` (`ac6da0dfba84…`) contra el Ollama propio en contenedor (estación 1), por `/api/embed`, coseno, top-5. Dos corpus (A = paráfrasis de N3 E3; B = los 12 enunciados de `*Policy` tal como los imprime EA-6 `salida-real.txt`), las 8 preguntas de N3 E3 más 3 no respondibles, dos repeticiones. Turno `<recurso-compartido>` (dueño AH-02, 2026-10-28T12:56Z). Endpoint sólo por variable de entorno | E1 |
| `intervalos.py` + `salida-intervalos.txt` | Intervalos de Wilson al 95 % de las tasas que sostienen decisiones en BIT-16-04 (cálculo, sin modelo) | E1 (cálculo) |
| `nuget-eval.txt` | Versiones de `Microsoft.Extensions.AI.Evaluation*` en la API de nuget.org (flatcontainer), 2026-10-28T12:57Z | E1 |

Fuentes oficiales leídas el 2026-10-28 (E4):
- https://learn.microsoft.com/en-us/dotnet/ai/evaluation/libraries (ms.date 2026-04-09; updated_at 2026-09-10).
- https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.ai.evaluation.quality.retrievalevaluator y …groundednessevaluator (updated_at 2026-10-16): «can be especially poor when a smaller / local model is used»; «tested against (and tuned to work well with) … GPT-4o»; puntaje 1–5.

Intermedios en `{dir-de-trabajo}/AH-02/` (sin bin/obj: no hubo compilación .NET).
