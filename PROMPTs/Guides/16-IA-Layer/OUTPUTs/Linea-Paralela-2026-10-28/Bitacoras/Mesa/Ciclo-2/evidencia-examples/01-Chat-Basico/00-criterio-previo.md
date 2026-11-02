# Examples/01-Chat-Basico — criterio previo de las pruebas contra el modelo

Escrito el 2026-10-28T14:53:13-03:00, antes de pedir el turno de modelo. Rige R-LLM-1…5 (06-Plan §10.3).
Estación: la 1 (rótulo «estación de laboratorio de 4 núcleos»; recurso <recurso-compartido>), salvo que se diga otra cosa en la salida.

| Prueba | Modelo | Estimando | N | Tipo de aserción (R-LLM-3) | Criterio |
|---|---|---|---|---|---|
| ChatConModeloTests | qwen3.5:4b (appsettings), muestreo «Instruct non-thinking general», think false, num_ctx 8192, /api/chat | este pedido | 1 pedido × 10 semillas (1..10) | (b) invariantes por corrida + (c) tasa de un pedido | invariantes: texto no vacío, FinishReason stop, InputTokenCount > 0 en 10/10; tasa «nombra 4 dígitos» (regex \b4\b o «cuatro»): falla si k < 8 (umbral elegido, no medido) |
| MaxOutputTokensConModeloTests | qwen3.5:4b, MaxOutputTokens 3 | este pedido | 3 semillas por vía | nativa (b) invariante; /v1 (a) existencia | nativa: salida ≤ 3 en 3/3; /v1: salida > 3 en al menos 1 de 3 |
| NumCtxConModeloTests | qwen2.5:0.5b (modelo de humo), prompt de 240 líneas (~6000 tokens), MaxOutputTokens 3 | este pedido | 3 semillas por tamaño + 1 de referencia (16384) | (b) invariantes | (a) entrada(8192) > 4096 en 3/3; (b) entrada(4096) ≤ 4096 en 3/3; (c) entrada(8192) = entrada(16384) en 3/3 |
| Program (dotnet run) | qwen3.5:4b | existencia | 1 corrida, 2 vueltas | (a) existencia | la segunda vuelta viaja con el historial; se guarda la salida tal cual |

Presupuesto estimado (R-LLM-5, tabla §R.6): 4b ~10–20 s por llamada corta (≈ 16 llamadas + recargas), 0.5b ~70–100 s por lectura de ~6000 tokens sin caché (7 llamadas, con reuso de prefijo dentro de cada tamaño). Total estimado 15–25 min, dentro de un turno de 45 min.
