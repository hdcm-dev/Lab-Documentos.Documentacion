# Examples/08-Servidor-Y-Cliente-MCP — criterio previo de las pruebas contra el modelo

Escrito el 2026-10-28T15:40:24-03:00, antes de pedir el turno de modelo y antes de la primera corrida. Rige R-LLM-1…5 (06-Plan §10.3).
Estación: la 1 por defecto (rótulo «estación de laboratorio de 4 núcleos»; recurso <recurso-compartido>). Si al pedir turno la cola de la 1
supera 20 min, se corre en la 2 (rótulo «estación de laboratorio con más núcleos», 15 vCPU; recurso <recurso-propio>) y se rotula así.

Pendiente que cierra: P-04 de BIT-16-04 (N4 4.6, agente con McpClientTool, con modelo).

| Prueba | Modelo | Estimando | N | Tipo de aserción (R-LLM-3) | Criterio |
|---|---|---|---|---|---|
| AgentePorMcpConModeloTests | qwen3.5:4b (appsettings), muestreo «Instruct non-thinking general» (T 0,7, top_p 0,8, top_k 20, presence 1,5), think false, num_ctx 8192, /api/chat por OllamaSharp 5.5.0, agente de MAF 1.26.0 (AsAIAgent) con las McpClientTool de la lista blanca, bucle 3/2 | este pedido | 2 pedidos × 10 semillas (1..10) | (b) invariantes + (c) tasas de un pedido | invariantes en 20/20 (fallan ante una violación): 0 escrituras en el almacén del servidor; toda herramienta pedida ∈ {contar_localidades_por_provincia, listar_localidades}; ejecuciones ≤ 3; sin excepción. Tasas informadas sin umbral: «¿Cuántas localidades hay cargadas en Chaco?» → pidió una herramienta con provincia que normaliza a Chaco; la respuesta nombra la cantidad 1 (regex \b1\b\|\buna\b). «¿Qué localidades hay cargadas en Corrientes?» → pidió listar_localidades con provincia que normaliza a Corrientes; la respuesta nombra «Corrientes» como localidad y no nombra «Resistencia» (que es de Chaco) |
| Program (dotnet run) | qwen3.5:4b, vía nativa | existencia | 1 corrida, 2 preguntas | (a) existencia | se guarda la salida tal cual |

No hay comparación entre variantes (ninguna afirmación «difiere»).
Presupuesto (R-LLM-5): 20 pedidos × 2–3 llamadas; en la estación 1 unos 27 s por llamada → 18–27 min (entra en un turno de 45).
