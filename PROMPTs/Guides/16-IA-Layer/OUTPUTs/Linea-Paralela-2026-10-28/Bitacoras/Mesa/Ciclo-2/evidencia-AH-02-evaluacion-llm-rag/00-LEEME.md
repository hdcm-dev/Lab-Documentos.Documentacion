# Evidencia de AH-02 (relectura integral, ciclo 2), 2026-10-28

| Archivo | Qué es | Nivel |
|---|---|---|
| `01-wilson-check.py`, `01-wilson-check-salida.txt` | recálculo de los 93 intervalos de Wilson de la guía (z = 1,959964) | E1, script propio |
| `02-aserciones-conmodelo.txt` | todas las aserciones de `ConModelo/` de `Examples/` y la demo | E1, lectura de código |
| `03-cableado-dependiente-del-orden.txt` | la prueba del 503 de `Examples/09` frente a la de la demo, y los umbrales de reloj de `Cableado/` | E1, lectura de código |
| `04-juez-tal-cual-estacion-4-nucleos.txt` | `EvaluacionConJuezTests` de `Examples/09` corrida **sin cambios** con `CONMODELO_JUEZ=1` (salida de `dotnet test`, sin trazas de pila) | E1, corrida |
| `05-juez-resultado-almacen.txt` | extracto del resultado que dejó esa corrida en el almacén del informe | E1, corrida |
| `06-juez-composicion-del-ejemplo.txt` | cómo arma el ejemplo el cliente del juez y qué genera la respuesta evaluada | E1, lectura de código |

**Corrida del juez.** Copia de `Examples/09-Pruebas-Con-Cliente-Falso` en el área de trabajo de la mesa; `dotnet build` con el recurso `build` en `mcr.microsoft.com/dotnet/sdk:10.0` (0 advertencias, 0 errores); `dotnet test --no-build --filter "FullyQualifiedName~EvaluacionConJuezTests"` con `CONMODELO_JUEZ=1`, turno `<recurso-compartido>` exclusivo (estación de laboratorio de 4 núcleos, Ollama 0.40.11, `qwen3.5:4b@d8b0f5e9760c`), 2026-10-28, 5 min 45 s. El turno anterior en la estación con más núcleos no llegó al servidor (timeout de conexión) y no midió nada. Endpoints sólo por variable; en las salidas, reemplazados por `<endpoint>` / `<ip>`.

**Resultado.** La prueba terminó **Passed** («Test Run Successful») con: «Medio en catálogo» Unacceptable porque la respuesta evaluada no era JSON; Relevance Inconclusive («Failed to parse score», 800 tokens de salida: el límite del evaluador); Coherence y Groundedness sin puntaje por el `HttpClient.Timeout` de 300 s. Ningún puntaje útil y la prueba en verde. N = 1 caso: existencia.
