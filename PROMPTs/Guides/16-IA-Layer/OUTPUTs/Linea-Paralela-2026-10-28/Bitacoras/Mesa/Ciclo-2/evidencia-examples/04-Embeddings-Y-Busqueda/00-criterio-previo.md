# Examples/04 — criterio escrito antes de correr contra el modelo

Escrito el 2026-10-28 15:09 -0300, después de Cableado 13/13 y **antes** de la primera llamada de ConModelo.

- **Modelo:** `qwen3-embedding:0.6b` (digest leído de `/api/tags` en la corrida), vía nativa `/api/embed` por OllamaSharp 5.5.0. Estación 1 («estación de laboratorio de 4 núcleos»), recurso `<recurso-compartido>`.
- **Oro:** `oro/oro-requisitos.json` v1 (generado por `GeneradorDeOro.cs`, caso base `59399ba`), sha256 aaf3d78775c20089. Evaluación: K = 12 respondibles (una con dos relevantes) + 10 no respondibles. Calibración aparte: 5 + 5.
- **Corpus:** los 12 enunciados de `LocalidadPolicy` y `EncuestaPolicy`, indexados como «Entidad — campo: enunciado».
- **Formatos (comparación pareada, mismas consultas, mismo digest):** (a) con instrucción `Instruct: <tarea en inglés>\nQuery:<consulta>` (model card); (b) sin instrucción. El documento nunca lleva instrucción.
- **k = 3.** Métricas de P-22: hit@1, hit@3, recall@3, MRR@3 sobre las respondibles; abstención correcta sobre las no respondibles.
- **Umbral de abstención:** por formato, calibrado sólo con el conjunto de calibración: punto medio entre la peor mejor-similitud de las respondibles y la mejor mejor-similitud de las no respondibles. Se aplica sin tocar a la evaluación. Se informan también las abstenciones indebidas en respondibles.
- **Estimando:** «la tarea» (la unidad es la consulta). hit@1, hit@3 y abstención como j/K con Wilson 95 % sobre las consultas; recall@3 y MRR@3 como promedios con la tabla por consulta. Nunca Wilson sobre K·m.
- **m = 3 repeticiones por consulta y formato**, por el generador sin caché. Los embeddings no muestrean (sin semilla ni temperatura): se mide si los vectores se repiten. Si se repiten, m no agrega información y se declara.
- **Comparación (R-LLM-3e):** «difiere» sólo con ≥ 6 pares discordantes todos en el mismo sentido; si no, «no separado con este N».
- **Invariantes (fallan ante una violación):** dimensión 1024 declarada → arranca, y cada vector mide 1024; dimensión 512 declarada → no arranca, con mensaje que nombra modelo, 512 y 1024.
- **Sin umbral de aprobación para las tasas:** se informan, no se aprueban. No se cambia ni el oro, ni la instrucción, ni el k después de ver resultados; si se cambiara, sería otra corrida, rotulada.
- **Existencia (n = 1 por par):** coseno de «colectivo»/«ómnibus», «colectivo»/«bicicleta», «en avión»/«Moto», «en avión»/«Tren».
