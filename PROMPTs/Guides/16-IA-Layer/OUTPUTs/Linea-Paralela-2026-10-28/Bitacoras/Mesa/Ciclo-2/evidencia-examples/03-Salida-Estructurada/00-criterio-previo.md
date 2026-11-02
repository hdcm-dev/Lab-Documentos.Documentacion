# Criterio previo — Examples/03-Salida-Estructurada, ConModelo (escrito 2026-10-28T14:52:18-03:00, antes de la primera llamada al modelo)

- Modelo: el de `AI:Modelo` (qwen3.5:4b), digest leído del servidor en la corrida. Ruta: /api/chat por OllamaSharp 5.5.0, `format` con el JSON Schema de `LocalidadPropuesta`. think false; T 0,7, top_p 0,8, top_k 20, presence_penalty 1,5 (card, modo sin razonamiento); num_ctx 8192.
- Diseño: 4 pedidos × m = 10 semillas (s = 1..10). Cada tasa es **de un pedido** (R-LLM-3c, estimando «este pedido»); no hay tasa de la tarea (K = 4 < 10). Ninguna comparación entre variantes.
- Invariantes (R-LLM-3b; el test falla ante una sola violación): 0 escrituras en el repositorio en las 40 corridas; ninguna propuesta con tipo fuera del enum llega a `ParaConfirmar`.
- Tasas informadas (k/10 con Wilson 95 %, sin umbral):
  - D1-cp-invalido «Agregá Goya, Corrientes, CP 34, 89959 habitantes»: forma válida; CP distinto de «34» (inventado); llega a la pantalla sin errores.
  - alta-completa «Agregá Goya, Corrientes, CP 3450, unos 90 mil habitantes»: forma válida; igual a (Alta, null, Goya, Corrientes, 3450, 90000); sin errores.
  - D2-sin-habitantes «En Bella Vista, Corrientes, CP 3432, no sé cuántos viven»: forma válida; habitantes null; la revisión pide habitantes.
  - modificacion «Corregí Resistencia: tiene 300000 habitantes»: forma válida; Modificacion con id 2; no descartada.
- Las definiciones exactas son las lambdas de `Pedidos` en `tests/.../ConModelo/ExtraccionConModeloTests.cs` (sha256 abajo).
3c86018763f5c99da0452db03e718c2af4aaafeb17d6aa0496fc725ef6275b73  Examples/03-Salida-Estructurada/tests/MovilidadUrbana.SalidaEstructurada.Tests/ConModelo/ExtraccionConModeloTests.cs
