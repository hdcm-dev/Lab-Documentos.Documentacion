# R6 · Relevamiento de industria y estándares

Fecha de consulta de todas las fichas: 2026-11-01 (salvo indicación). Método: lectura web directa (WebFetch) de la fuente primaria; cuando sólo hubo fuente secundaria o la primaria dio error, se marca. Cotejo con el Anexo D de la guía 0.11.0 por URL exacta o por dominio/documento.

Leyenda «Guía»: **CITA** (la URL o el documento está en la guía) · **PARCIAL** (cita otra página del mismo cuerpo) · **NO** (no lo cita).

## Índice

1. Plataforma .NET (M.E.AI, MAF, SK, Evaluation)
2. MCP (especificación y SDK C#)
3. Observabilidad (OpenTelemetry GenAI)
4. Seguridad y riesgo (OWASP LLM, OWASP Agentic, NIST, ISO 42001, EU AI Act)
5. Evaluación (LLM-as-judge, RAG)
6. Especificación de arquitectura (arc42, C4, ADR)
7. Casos públicos
8. Síntesis para la guía y el Conocimiento
9. Brechas y lo no verificado

## 1 · Plataforma .NET

### F1 · Microsoft.Extensions.AI libraries
- Autor: Microsoft Learn (.NET docs). URL: https://learn.microsoft.com/en-us/dotnet/ai/microsoft-extensions-ai (ms.date 2026-09-14).
- Afirma: `Microsoft.Extensions.AI.Abstractions` trae `IChatClient` e `IEmbeddingGenerator<TInput,TEmbedding>`; `IImageGenerator` es experimental. `Microsoft.Extensions.AI` agrega invocación automática de funciones, telemetría (`UseOpenTelemetry`) y caché mediante patrones de DI y middleware. Las bibliotecas proveedoras referencian sólo Abstractions; las apps, el paquete completo. Muestra de referencia: eShopSupport.
- Sirve para: guía, capítulos de abstracción/puerto y pipeline de middleware; Conocimiento, regla «el dominio depende de Abstractions, no del proveedor».
- Guía: **CITA**.

### F2 · Microsoft Agent Framework Overview
- Autor: Microsoft Learn. URL: https://learn.microsoft.com/en-us/agent-framework/overview/ (ms.date 2026-10-23).
- Afirma: cuatro áreas (Agents, Harness Agent, Workflows, Integrations); bloques: model clients, agent session, context providers, middleware, clientes MCP. Tabla «agente vs workflow» y la regla «If you can write a function to handle the task, do that instead of using an AI agent». MAF es sucesor directo de Semantic Kernel y AutoGen, por los mismos equipos. Go en preview. Responsabilidad propia de mitigaciones de IA responsable.
- Sirve para: guía, capítulo de agentes y orquestación (criterio de decisión); Conocimiento, regla de mínima agencia. Novedad no presente en la guía: «Harness Agent» (planificación, compactación de contexto, aprobación de herramientas).
- Guía: **CITA** (overview y páginas de workflows); el Harness Agent **NO**.

### F3 · Semantic Kernel (README)
- Autor: Microsoft (GitHub). URL: https://github.com/microsoft/semantic-kernel
- Afirma: «Semantic Kernel is now Microsoft Agent Framework!»; MAF 1.0 descrito como production-ready, APIs estables, soporte a largo plazo; remite a guía de migración. No declara explícitamente modo mantenimiento.
- Sirve para: Anexo F (señales de obsolescencia); ADR de elección de marco.
- Guía: **CITA**.

### F4 · Microsoft.Extensions.AI.Evaluation libraries
- Autor: Microsoft Learn. URL: https://learn.microsoft.com/en-us/dotnet/ai/evaluation/libraries (ms.date 2026-04-09).
- Afirma: paquetes Evaluation, .NLP (BLEU, GLEU, F1, sin LLM), .Quality (evaluadores que usan un LLM: Relevance, Completeness, Retrieval, Fluency, Coherence, Equivalence, Groundedness, IntentResolution, TaskAdherence, ToolCallAccuracy), .Safety (servicio de Foundry), .Reporting (caché de respuestas y reportes; herramienta `dotnet aieval`). Integra con MSTest/xUnit/NUnit y CI.
- Sirve para: guía, capítulo de evaluación (LLM-as-judge concreto en .NET); Conocimiento, compuerta de calidad en CI.
- Guía: **CITA**.

## 2 · MCP

### F5 · MCP Versioning
- Autor: Model Context Protocol (modelcontextprotocol.io). URL: https://modelcontextprotocol.io/specification/versioning
- Afirma: versiones por fecha `YYYY-MM-DD`; versión **current 2026-07-28**. Cada solicitud declara la versión en `_meta` (`io.modelcontextprotocol/protocolVersion`) y, en Streamable HTTP, en el encabezado `MCP-Protocol-Version`; `server/discover` obligatorio; las revisiones `2025-11-25` y anteriores son «handshake-based» (compatibilidad documentada). Política de deprecación: ≥12 meses (90 días por excepción).
- Sirve para: guía, capítulo MCP y Anexo F (la guía cita mayormente 2025-06-18; conviene revisar si los ejemplos de handshake siguen siendo la referencia).
- Guía: **PARCIAL** (cita 2025-06-18 y la página de streamable-http de 2026-07-28, no la de versionado).

### F6 · MCP C# SDK
- Autor: modelcontextprotocol, «maintained in collaboration with Microsoft». URL: https://github.com/modelcontextprotocol/csharp-sdk
- Afirma: paquetes `ModelContextProtocol.Core`, `ModelContextProtocol` (hosting + DI), `ModelContextProtocol.AspNetCore` (servidores HTTP); extensiones Apps, Skills, Tasks. La página leída no muestra número de versión.
- Sirve para: guía, capítulo MCP (selección de paquete según rol).
- Guía: **CITA**.

## 3 · Observabilidad

### F7 · OpenTelemetry GenAI semantic conventions
- Autor: OpenTelemetry. URLs: https://opentelemetry.io/docs/specs/semconv/gen-ai/ y https://github.com/open-telemetry/semantic-conventions-genai
- Afirma: la página de opentelemetry.io marca todas las secciones como «Moved» al repositorio `semantic-conventions-genai` (spans, metrics, events, agent spans, MCP, proveedores OpenAI/Anthropic/Bedrock/Azure AI Inference). El repo: Apache-2.0, definiciones YAML en `model/`, docs generadas en `docs/`, implementaciones de referencia; schema URL aún «TODO». No se pudo leer el nivel de madurez en lo consultado.
- Sirve para: guía, capítulo de observabilidad (los nombres de atributos deben citarse del repo nuevo); Anexo F (señal: mudanza de repositorio).
- Guía: **CITA** (ambas URLs).

## 4 · Seguridad, riesgo y regulación

### F8 · OWASP Top 10 for LLM Applications 2025
- Autor: OWASP GenAI Security Project. URL: https://genai.owasp.org/llm-top-10/
- Afirma: LLM01 Prompt Injection, LLM02 Sensitive Information Disclosure, LLM03 Supply Chain, LLM04 Data and Model Poisoning, LLM05 Improper Output Handling, LLM06 Excessive Agency, LLM07 System Prompt Leakage, LLM08 Vector and Embedding Weaknesses, LLM09 Misinformation, LLM10 Unbounded Consumption.
- Sirve para: guía §11.1 (OA-S1); Conocimiento, matriz riesgo→control.
- Guía: **CITA**.

### F9 · OWASP Top 10 for Agentic Applications 2026
- Autor: OWASP GenAI Security Project. URL: https://genai.owasp.org/resource/owasp-top-10-for-agentic-applications-for-2026/ — publicado 2025-12-09.
- Afirma (lista tomada de fuentes **secundarias**: kratikal.com, cycode.com, humansecurity.com; la página primaria remite al PDF): ASI01 Agent Goal Hijack, ASI02 Tool Misuse & Exploitation, ASI03 Identity & Privilege Abuse, ASI04 Agentic Supply Chain, ASI05 Unexpected Code Execution, ASI06 Memory & Context Poisoning, ASI07 Insecure Inter-Agent Communication, ASI08 Cascading Failures, ASI09 Human-Agent Trust Exploitation, ASI10 Rogue Agents.
- Sirve para: guía, capítulo de agentes/seguridad; Conocimiento, controles de herramientas (mínima agencia, aprobación). Verificar contra el PDF antes de citar los nombres.
- Guía: **CITA** (la página del recurso).

### F10 · NIST AI RMF y perfil GenAI
- Autor: NIST. URL: https://www.nist.gov/itl/ai-risk-management-framework
- Afirma: AI RMF 1.0 del 2023-01-26, uso voluntario; funciones Govern, Map, Measure, Manage; NIST-AI-600-1 (perfil GenAI) del 2024-07-26; el 2026-04-07 salió una nota conceptual de un perfil para infraestructura crítica; AI RMF 1.0 «being revised» en el marco del White House AI Action Plan (sin fecha).
- Sirve para: guía, capítulo de gobierno/riesgo; Anexo F (revisión anunciada como señal de obsolescencia).
- Guía: **CITA** (los PDF 100-1 y 600-1); la página con la revisión anunciada **NO**.

### F11 · ISO/IEC 42001:2023
- Autor: ISO/IEC. URL: https://www.iso.org/standard/42001 (y /standard/81230.html).
- **No verificado**: ambas respondieron HTTP 403. No se registra contenido; queda pendiente lectura por otra vía antes de citarla.
- Sirve para: guía, capítulo de gobierno (sistema de gestión de IA) si se verifica.
- Guía: **NO**.

### F12 · EU AI Act — cronograma de aplicación
- Autor: Future of Life Institute (artificialintelligenceact.eu), fuente **secundaria** de referencia; el texto primario es EUR-Lex (no leído en esta ronda). URL: https://artificialintelligenceact.eu/implementation-timeline/
- Afirma: prohibiciones y alfabetización en IA desde 2025-02-02; reglas GPAI (Cap. V) desde 2025-08-02; resto del Acta, incluido el Art. 50 (transparencia), desde 2026-08-02; sistemas generativos ya en el mercado antes de esa fecha: Art. 50(2) al 2026-12-02; alto riesgo Anexo III 2027-12-02 y Anexo I 2028-08-02 (postergaciones respecto del texto original).
- Pertinente al desarrollador: Art. 50 (avisar que se interactúa con una IA; marcar contenido sintético) aplica a un asistente conversacional como la demo.
- Sirve para: guía, capítulo de gobierno/UX (transparencia); Conocimiento, requisito no funcional «aviso de IA».
- Guía: **NO**.

## 5 · Evaluación

### F13 · LLM-as-a-judge (MT-Bench/Chatbot Arena)
- arXiv 2306.05685 — ya en la guía (**CITA**). No releído en esta ronda.

### F14 · Métricas de RAG (Ragas)
- Autor: Ragas (docs). URL: https://docs.ragas.io/en/stable/concepts/metrics/available_metrics/
- Afirma: lista Faithfulness, Context Precision, Context Recall, Response Relevancy (las definiciones están en subpáginas no leídas).
- Sirve para: guía, capítulo de evaluación RAG, como vocabulario de métricas complementario a F4 (Groundedness, Retrieval).
- Guía: **NO**. (La guía sí cita la guía de diseño y evaluación de RAG de Azure Architecture Center.)

### F15 · Ver F4 (evaluadores LLM-based y NLP en .NET) y F20 (Shopify: calibración del juez con humanos).

## 6 · Especificación de arquitectura

### F16 · arc42
- Autor: arc42 (Starke, Hruschka). URL: https://arc42.org/overview
- Afirma: 12 secciones: 1 Introducción y metas, 2 Restricciones, 3 Contexto y alcance, 4 Estrategia de solución, 5 Vista de bloques, 6 Vista de ejecución, 7 Vista de despliegue, 8 Conceptos transversales, 9 Decisiones, 10 Requisitos de calidad, 11 Riesgos y deuda técnica, 12 Glosario.
- Sirve para: **Conocimiento de especificación** (esqueleto: la capa de IA como bloque de §5, prompts/evaluación/observabilidad como §8, escenarios de calidad §10 con métricas de F4).
- Guía: **NO**.

### F17 · C4 model
- Autor: Simon Brown. URL: https://c4model.com/
- Afirma: niveles Software system, Container, Component, Code (diagramas de contexto, contenedor, componente, código) y suplementarios: landscape, dynamic, deployment.
- Sirve para: Conocimiento de especificación (diagramas mermaid por nivel; la capa de IA como contenedor/componente).
- Guía: **NO**.

### F18 · ADR (adr.github.io)
- Autor: ADR GitHub organization. URL: https://adr.github.io/
- Afirma: AD = elección de diseño justificada sobre un requisito arquitectónicamente significativo (ASR); ADR registra una AD con razón, compromisos y consecuencias; el conjunto es el decision log; base en Zdun et al. (Y-statements); remite a Nygard (2011) y MADR.
- Sirve para: Conocimiento de especificación (ADR por decisión de proveedor, marco, MCP, almacenamiento vectorial).
- Guía: **PARCIAL** (cita Nygard en cognitect.com y la guía ADR del Azure Well-Architected; no adr.github.io).

## 7 · Casos públicos

### F19 · LinkedIn — «Musings on building a Generative AI product»
- Juan Pablo Bottaro y Karthik R., 2024-04-25. URL: https://www.linkedin.com/blog/engineering/generative-ai/musings-on-building-a-generative-ai-product
- Afirma: pipeline RAG fijo routing→retrieval→generation; modelos chicos para ruteo/recuperación y grandes para generación; APIs internas envueltas como «skills» con descripción y esquema; streaming y asincronía punta a punta; equipo horizontal de prompts/evaluación; ~10 % de salidas YAML mal formadas, bajado a ~0,01 % con parser defensivo y pistas en el prompt; 80 %→95 % de calidad costó mucho más que el prototipo.
- Sirve para: guía, salida estructurada y evaluación; Conocimiento, separación por etapas.
- Guía: **NO**.

### F20 · Shopify — «Building production-ready agentic systems: Lessons from Shopify Sidekick»
- Andrew McNamara (con Ben Lafferty y Michael Garner), 2025-08-26. URL: https://shopify.engineering/building-production-ready-agentic-systems
- Afirma: bucle agéntico; problema con >50 herramientas y prompt sobrecargado; instrucciones «just-in-time» devueltas con la herramienta (preservan prompt caching); evaluación con ground truth sets de conversaciones reales etiquetadas por ≥3 expertos; acuerdo interanotador como techo; juez de Kappa 0,02→0,61 (humano 0,69); simulador de comerciante antes de liberar; no multiagente temprano.
- Sirve para: guía, capítulos de herramientas y evaluación; Conocimiento, regla «calibrar el juez contra humanos».
- Guía: **NO**.

### F21 · Anthropic — «How we built our multi-agent research system»
- Anthropic Engineering, 2025-06-13. URL: https://www.anthropic.com/engineering/multi-agent-research-system
- Afirma: patrón orquestador-trabajadores con subagentes paralelos y un CitationAgent; juez LLM con rúbrica (exactitud, citas, completitud, fuentes, eficiencia de herramientas), una sola llamada 0,0–1,0 + pass/fail como lo más consistente; pruebas humanas siguen necesarias; trazas completas en producción sin leer contenidos.
- Sirve para: guía, agentes y evaluación; observabilidad con privacidad.
- Guía: **PARCIAL** (cita «Building effective agents», no este).

### F22 · GitHub Copilot — «How GitHub Copilot is getting better at understanding your code»
- Johan Rosenkilde, 2023-05-17 (act. 2024-02-07). URL: https://github.blog/ai-and-ml/github-copilot/how-github-copilot-is-getting-better-at-understanding-your-code/
- Afirma: prompt construido en segundo plano por una «prompt library» que selecciona, rankea y ensambla contexto; neighboring tabs (+~5 % aceptación relativa); fill-in-the-middle (+~10 %); recuperación experimental por embeddings; ventana ~6000 caracteres obliga a priorizar.
- Sirve para: guía, ingeniería de contexto/presupuesto de tokens.
- Guía: **NO**. Antigüedad: anterior a 2025; usar como caso histórico.

### F23 · Uber — «Navigating the LLM Landscape: Uber's Innovation with GenAI Gateway»
- Roopansh Bansal y Tse-Chi Wang, 2024-07-11. URL: https://www.uber.com/blog/genai-gateway/ (la lectura directa dio 404; datos tomados de fragmentos de búsqueda y de InfoQ https://www.infoq.com/news/2024/09/uber-genai-gateway-llm-openai — **secundario**).
- Afirma: servicio Go que envuelve proveedores externos y modelos propios con interfaz espejo de OpenAI; redactor de PII antes de salir a terceros; ~30 equipos, 16 M consultas/mes.
- Sirve para: guía, patrón gateway/puerta de enlace y PII. Verificar texto completo antes de citar cifras.
- Guía: **NO**.

### F24 · Microsoft eShopSupport (muestra de referencia)
- dotnet (GitHub, MIT). URL: https://github.com/dotnet/eShopSupport
- Afirma: sistema de tickets con .NET Aspire; clasificación, sentimiento, resumen, datos sintéticos, chatbot; modelos locales pequeños en desarrollo; evaluación con Q&A fundamentado.
- Sirve para: guía, caso .NET comparable a la demo (Aspire + evaluación).
- Guía: **NO** (la guía no la nombra; F1 sí la recomienda).

Casos intentados y no leídos: DoorDash (careersatdoordash.com, 403). Quedan 6 casos verificados (F19–F24, F23 con reserva).

## 8 · Síntesis para la guía y el Conocimiento

| Tema | Fuente | Destino |
|---|---|---|
| Puerto `IChatClient` + middleware | F1 | Guía (núcleo) y Conocimiento (regla de dependencia) |
| Agente vs workflow; «si es función, no agente» | F2, F20 | Guía agentes; Conocimiento, criterio de decisión |
| SK→MAF | F3 | Anexo F |
| Versión MCP 2026-07-28 sin handshake | F5 | Capítulo MCP, Anexo F (revisar) |
| OTel GenAI mudado de repo | F7 | Observabilidad, Anexo F |
| Matriz OWASP LLM + Agentic | F8, F9 | §11 y Conocimiento |
| Gobierno: NIST, (ISO), AI Act Art. 50 | F10–F12 | Capítulo de gobierno; requisito de transparencia |
| Evaluación: evaluadores .NET, juez calibrado, métricas RAG | F4, F14, F20, F21 | Capítulo evaluación; escenarios de calidad |
| Plantilla de especificación | F16–F18 | Conocimiento de especificación (arc42 + C4 + ADR) |

Propuesta para el Conocimiento (a decidir en mesa): estructurar la especificación de una capa de IA con secciones arc42 (contexto, bloques, conceptos transversales, calidad, riesgos), diagramas C4 en mermaid y un decision log ADR, con riesgos mapeados a OWASP y escenarios de calidad medidos con evaluadores.

## 9 · Brechas y no verificado

- ISO/IEC 42001: sin lectura (403).
- OWASP Agentic: nombres ASI01–ASI10 de fuentes secundarias; falta leer el PDF.
- EU AI Act: cronograma de fuente secundaria; falta EUR-Lex.
- Uber: sin lectura directa (404).
- OTel GenAI: nivel de madurez y nombres de atributos no leídos en esta ronda.
- MCP C# SDK: versión vigente no visible; consultar NuGet.
