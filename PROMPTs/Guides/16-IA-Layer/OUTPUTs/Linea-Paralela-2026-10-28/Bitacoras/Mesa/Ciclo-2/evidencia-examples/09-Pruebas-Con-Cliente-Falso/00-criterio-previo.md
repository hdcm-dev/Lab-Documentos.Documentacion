# Ejemplo 09 · criterio previo de `ConModelo/` (escrito antes de correr, 2026-10-28)

Rige R-LLM-1…5 (06-Plan §10.3). Estimando: **este pedido** en las tres pruebas (la unidad es la semilla). Semillas declaradas: s = 1..m, una por corrida. Ninguna tasa tiene umbral ni se compara con otra.

| Prueba | Estación | Invariantes (fallan ante una violación, R-LLM-3b) | Tasas o existencia (sin umbral) |
|---|---|---|---|
| `ContextoTruncadoConModeloTests` (P-11 (4), P-08, P2-09) | estación de 15 vCPU (prompt largo; la consigna lo permite) | con `NumCtx` 8192, `InputTokenCount` L supera 4096; con `num_ctx` 4096 y largo esperado L, `ContextoTruncadoException` en cada semilla; `CachedInputTokenCount` = `null` por OllamaSharp 5.5.0; el handler lee `prompt_eval_count` = L | existencia: con 8192 responde «3001» (k de n). N = 3 semillas por tamaño |
| `PipelineConModeloTests` (P-02, CTRL-08) | estación de 4 núcleos | sin excepción; 0 escrituras; el segundo pedido igual es acierto (0 spans, contador +1, mismo texto); herramienta pedida ∈ lista cerrada | pidió la herramienta; la respuesta nombra 1 (`\b1\b|\buna\b`); tokens cacheados > 0 en el último `/api/chat`. m = 10 |
| `SalidaEstructuradaConModeloTests` (P-02, S-43) | estación de 4 núcleos | sin excepción; veredicto de `MedioEnCatalogoEvaluator` = verificación directa | deserializó; medios ⊆ catálogo; exactamente {colectivo, bicicleta} + «diaria». m = 10 |
| `EvaluacionConJuezTests` (S-45) | no se corre (sólo bajo demanda de la mesa) | — | «no medido» |

Parámetros: `qwen3.5:4b` (provisional), T 0,7, top_p 0,8, top_k 20, presence 1,5, `think` false, `num_ctx` 8192, ruta `/api/chat` por OllamaSharp 5.5.0. El digest se lee del servidor y va en la cabecera de cada salida.
