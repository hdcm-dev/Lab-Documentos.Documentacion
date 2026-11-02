# Examples/10-Workflow — criterio previo de ConModelo (escrito antes de correr)

Fecha: 2026-10-28. Redactado antes de la primera corrida contra el modelo (R-LLM-3, P2-13). Modelo: `qwen3.5:4b` (provisional), vía nativa (OllamaSharp 5.5.0 → `/api/chat`), razonamiento apagado, preajuste de la model card (T 0,7, top_p 0,8, top_k 20, presence 1,5), `num_ctx` 8192. Semillas s = 1..10, una por corrida (R-LLM-2). Estación por defecto: la de 4 núcleos; la de 15 vCPU sólo si la cola supera 20 min.

## Prueba 1 — `WorkflowDeAltaConModeloTests` (workflow con un paso con modelo + persona en el bucle)

Pedidos (redactados antes): P1 «Agregá Goya, Corrientes, CP 34, 89959 habitantes» (el CP es inválido) y P2 «Agregá Goya, Corrientes, CP 3450, 89959 habitantes». Persona simulada «cuidadosa»: confirma sólo si la propuesta coincide exactamente con los datos del texto (Goya, Corrientes, 3450, 89959); si no, responde que no.

**Invariantes (R-LLM-3b; la prueba falla ante una sola violación):**
1. El camino es uno de dos, fijados por código: `extraer > revisar > rechazo` o `extraer > revisar > confirmar-alta > registrar`.
2. Exactamente 1 llamada al modelo por corrida, sin herramientas ofrecidas.
3. Escrituras = 1 sólo si el resultado es «Registrada», que exige una confirmación afirmativa; si no, 0.
4. Sin excepción.

**Tasas de este pedido (R-LLM-3c; m = 10; se informan sin umbral):**
- P1: propuesta con CP «34» (respeta el dato); rechazada por la revisión en código; llegó a la persona con un CP de 4 dígitos que no está en el texto (inventado: la revisión no lo puede detectar y el control es la persona).
- P2: propuesta exacta; registrada.

## Prueba 2 — `SecuencialConModeloTests` (BuildSequential extractor → redactor, expuesto con AsAIAgent)

Pedido: P2. **Invariantes:** exactamente 2 llamadas al modelo por corrida, en el orden extractor → redactor; sin herramientas; sin excepción. **Tasas de este pedido (m = 10):** la línea del extractor contiene «3450»; el texto del redactor nombra «Goya» y «Corrientes»; el texto del redactor contiene «3450».

Ninguna comparación entre pedidos ni entre pruebas (no son variantes pareadas). Con N = 10 por pedido, en texto verbal sólo existencia (RV-17).
