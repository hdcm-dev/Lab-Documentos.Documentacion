# Panel · senior .NET · relectura integral de la guía 0.11.0

Rol: corrección del código citado contra Examples/ y Demos/, APIs de M.E.AI 10.11.0, OllamaSharp 5.5.0, MAF 1.26.0, ModelContextProtocol 2.3.0 y .NET 10. Trabajo a ciegas (sin leer otros paneles). La guía no se editó.

Alcance revisado: §4.4, §5.1–§5.7, §8.2–§8.9, §9.3–§9.8, §10.2–§10.7, §12.1–§12.3, Anexo F; cotejo de llamadas citadas con Examples/08, 09, 11, 12, 13, 14 y la demo. La fidelidad textual de los bloques la cubre AC-9 (57 bloques, 0 diferencias) y la compilación el build 561/561; no repito eso.

Sin hallazgos en: firmas de `UseFunctionInvocation`/`UseLogging`/`ConfigureOptions`, orden del pipeline (la primera capa es la de afuera), `ApprovalRequiredAIFunction` y `ToolApprovalRequestContent` en M.E.AI sin MAF, `AsAIAgent`/`CreateSessionAsync`/`SerializeSessionAsync`, `McpClientTool` como `AIFunction`, renombres de §9.8, versiones del Anexo F contra los dos `Directory.Packages.props`, intervalos Clopper-Pearson citados (4/4, 6/8, 6/10, 8/10, 10/10) y p = 0,070 para 7 contra 1.

## senior-dotnet-01 · mayor · §10.6 (ancla s10-6), párrafo «Lo que vio el laboratorio después»
- Problema: la frase «su repetición, con criterio propio, no había cerrado al escribir esta sección» quedó vieja: R-15b cerró.
- Evidencia: 00-Preparacion §4: 41/52 interpretables, 0,788, IC95 [0,653; 0,889], `qwen3.5:4b`@`d8b0f5e9760c`, estación 2, Ollama 0.40.11, 2026-10-29; umbral del criterio ≥ 45/52; no cumple, «no medido».
- Propuesta: reemplazar por «su repetición del 2026-10-29 dio 41/52 salidas interpretables, por debajo del mínimo fijado antes de correr (45/52): no medido», con el rótulo R-LLM y la advertencia de juez de la misma familia. No dar el 0,788 como tasa del juez.

## senior-dotnet-02 · mayor · §5.4 (ancla s5-4), «Ventana y truncado», y §5.7 (ancla s5-7), viñeta «num_ctx recorta en silencio»
- Problema: «el mismo prompt midió 5.114 tokens con qwen3.5:4b y 5.134 con qwen2.5:0.5b» convive, en el mismo párrafo, con «el servidor contó 5.397 tokens del prompt» para qwen3.5:4b, y §5.7 da 5.714 con qwen2.5:0.5b. Un lector .NET lee cuatro cuentas del «mismo» prompt que no cierran entre sí; la diferencia de tokenizador (20 tokens) queda chica frente a la de composición (283 y 580).
- Evidencia: textos citados en s5-4 y s5-7; son tres registros distintos (línea archivada 2026-10-28; estación 2 2026-10-29; segundo servidor 2026-10-27).
- Propuesta: decir explícito que 5.114/5.134 es otro estímulo (o quitar «el mismo prompt» si no lo es) y que la comparación de tokenizadores vale sólo dentro de ese par; no sumar cifras nuevas.

## senior-dotnet-03 · menor · §10.6 (ancla s10-6), primer párrafo del laboratorio
- Problema: «en la corrida del 2026-10-29 (estación 2), juez y generador fueron el mismo qwen3.5:4b» no dice que esa corrida es la que quedó «no medido»; leída sola sugiere un resultado.
- Evidencia: s10-6 junto con 00-Preparacion §4.
- Propuesta: añadir «(corrida no medida, ver abajo)» o remitir al párrafo corregido en senior-dotnet-01.
