# Examples/06-Tool-Calling — criterio previo de las pruebas contra el modelo

Escrito el 2026-10-28T15:19:20-03:00, antes de pedir el turno de modelo y antes de la primera corrida. Rige R-LLM-1…5 (06-Plan §10.3).
Estación: la 2 (rótulo de RV-01 ampliada «estación de laboratorio con más núcleos»), porque la cola de
la estación 1 superaba 20 min al momento de planificar (ex02 con turno hasta 15:47 y dos en espera). Si se corre en la 1, se rotula así.

| Prueba | Modelo | Estimando | N | Tipo de aserción (R-LLM-3) | Criterio |
|---|---|---|---|---|---|
| HerramientasConModeloTests(ollama) | qwen3.5:4b (appsettings), muestreo «Instruct non-thinking general», think false, num_ctx 8192, /api/chat, bucle 3/2 | este pedido | 2 pedidos × 10 semillas (1..10) | (b) invariantes + (c) tasas de un pedido | invariantes en 20/20: 0 escrituras; toda herramienta pedida ∈ {contar_localidades_por_provincia, listar_localidades}; ejecuciones ≤ 3; sin excepción. Tasas informadas sin umbral: «Chaco» → pidió herramienta con provincia que normaliza a Chaco; respuesta con «1»/«una». «Misiones» → pidió alguna herramienta; respuesta dice «catálogo»/«no es/está/figura…»; respuesta afirma un conteo (\b\d+\s+localidad) |
| HerramientasConModeloTests(openai-compatible) | ídem por /v1 (sin num_ctx ni top_k) | este pedido | 2 pedidos × 10 semillas (1..10) | ídem | ídem |
| Program (dotnet run) | qwen3.5:4b, vía nativa | existencia | 1 corrida, 2 preguntas | (a) existencia | se guarda la salida tal cual |

Las dos vías **no se comparan** (no hay afirmación «difiere»; R-LLM-3e exigiría ≥ 6 pares discordantes en un sentido).
tool_choice por /v1 (pendiente P-11, opcional): no medido en este ejemplo.
Presupuesto (R-LLM-5): 40 pedidos × 2–4 llamadas; en la estación 2 unos 5–10 s por llamada → 10–25 min.
