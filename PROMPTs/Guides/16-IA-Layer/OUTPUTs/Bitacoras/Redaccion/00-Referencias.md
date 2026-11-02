---
doc_id: BIT-16-RED-00-REF
doc_type: registro-de-referencias
title: Registro único de referencias (Anexo D de la guía 16)
status: vigente para la redacción
origin: agent (preparación de la redacción)
last_review: 2026-10-27
audience: [redactores, relectura integral]
traces: [BIT-16-04 v3 §C Anexo D, BIT-16-N0b §7, BIT-16-N1 §7, BIT-16-N1b §7, BIT-16-N2 §7, BIT-16-N3 §7, BIT-16-N3b §7, BIT-16-N4 §7, BIT-16-N5 §7, BIT-16-N6 §7, Sondeo-Entorno, Mesa/I-01]
---

# Registro único de referencias (Anexo D)

Este registro es la fuente del Anexo D de la guía. Cada entrada sale de una fuente que **un dossier ya verificó** (su tabla de fuentes o su verificación adversarial) o del sondeo del entorno (`Sondeo-Entorno.md`, evidencia E1). No se agregó ninguna fuente nueva ni se volvió a consultar ninguna URL en esta preparación: la fecha de «consultado» es la que registró el dossier. Cuando dos dossiers verificaron la misma URL, la entrada es una sola y lleva la fecha más reciente.

## Índice

- [Reglas de uso](#reglas-de-uso)
- [1. Marco, producto y diseño de la interacción](#1-marco-producto-y-diseño-de-la-interacción)
- [2. Fundamentos y «por qué ahora»](#2-fundamentos-y-por-qué-ahora)
- [3. Microsoft.Extensions.AI y adaptadores](#3-microsoftextensionsai-y-adaptadores)
- [4. Estrategias de conocimiento y cachés](#4-estrategias-de-conocimiento-y-cachés)
- [5. RAG, embeddings y almacenes vectoriales](#5-rag-embeddings-y-almacenes-vectoriales)
- [6. Agentes, workflows y MCP](#6-agentes-workflows-y-mcp)
- [7. Marcos comparados: Semantic Kernel, AutoGen, LangGraph](#7-marcos-comparados-semantic-kernel-autogen-langgraph)
- [8. Pruebas y evaluación](#8-pruebas-y-evaluación)
- [9. Seguridad](#9-seguridad)
- [10. Operación, observabilidad y despliegue](#10-operación-observabilidad-y-despliegue)
- [11. Decisiones de arquitectura](#11-decisiones-de-arquitectura)
- [12. Caso base y registros de paquetes](#12-caso-base-y-registros-de-paquetes)
- [Pendientes: fuentes que el plan cita y ningún dossier verificó](#pendientes-fuentes-que-el-plan-cita-y-ningún-dossier-verificó)
- [Correspondencia (no va a la guía)](#correspondencia-no-va-a-la-guía)

## Reglas de uso

- **Forma** (plan §C, Anexo D; H-045, H2-045): `[REF-nn] Autor u organización, «Título», URL, versión o fecha de publicación, consultado AAAA-MM-DD`. En el cuerpo de la guía la cita va como `[REF-nn]` al final de la oración que respalda.
- **IDs estables.** Los números no se reasignan durante la redacción. El Anexo D publica sólo las entradas que la guía cita, en orden de número; los huecos que dejen las no citadas se aceptan (criterio de esta preparación, para que una remisión escrita en una sección no cambie de destino cuando otra sección deja de citar algo).
- **Fecha de la página.** «ms.date» es la fecha de la página de Microsoft Learn; «act.» es su última actualización visible; para papers, la fecha de la v1 en arXiv cuando el dossier la registró.
- **Sin título registrado.** La mayoría de las tablas de fuentes de los dossiers anotan la URL y lo que respalda, no el título literal. En esos casos la entrada no inventa un título: pone `[sin título registrado: <lo que respalda, según el dossier>]`. Lo mismo con autores o iniciales que el dossier no anotó. La entrada **se puede citar** (la fuente está verificada), pero antes del cierre (relectura integral, edición del Anexo D) alguien tiene que abrir la URL y copiar el título exacto; hasta entonces el Anexo D lleva el corchete y no un título de memoria. Para un repositorio o un archivo de código, el nombre del repositorio o la ruta del archivo hacen de título.
- **No va a la guía**: la sección «Correspondencia», los IDs de dossier (F, G, H, B, E) y cualquier nombre interno de turno o de máquina (R-PO-2, H2-045).

## 1. Marco, producto y diseño de la interacción

- [REF-01] Amershi, Weld, Vorvoreanu, Fourney, Nushi, Collisson, Suh, Iqbal, Bennett, Inkpen, Teevan, Kikin-Gil, Horvitz, «Guidelines for Human-AI Interaction», https://www.microsoft.com/en-us/research/wp-content/uploads/2019/01/Guidelines-for-Human-AI-Interaction-camera-ready.pdf (DOI 10.1145/3290605.3300233), CHI 2019, 2019-05-02, consultado 2026-10-26
- [REF-02] Microsoft, «HAX Toolkit» [sin título registrado: página de las pautas de N0b B01], https://www.microsoft.com/en-us/haxtoolkit/ai-guidelines/, sin fecha visible, consultado 2026-10-26
- [REF-03] Google PAIR, «People + AI Guidebook» (capítulos «User Needs + Defining Success» y «Data Collection + Evaluation»), https://pair.withgoogle.com/guidebook/chapters, sin fecha visible en los capítulos, consultado 2026-10-26
- [REF-04] Microsoft, «Microsoft Responsible AI Standard, v2 — General Requirements», https://blogs.microsoft.com/wp-content/uploads/prod/sites/5/2022/06/Microsoft-Responsible-AI-Standard-v2-General-Requirements-3.pdf, junio de 2022, consultado 2026-10-26
- [REF-05] NIST, «AI RMF 1.0», NIST AI 100-1, https://nvlpubs.nist.gov/nistpubs/ai/NIST.AI.100-1.pdf (DOI 10.6028/NIST.AI.100-1), 2023-01-26, consultado 2026-10-26
- [REF-06] NIST, «AI RMF: Generative AI Profile», NIST AI 600-1, https://nvlpubs.nist.gov/nistpubs/ai/NIST.AI.600-1.pdf (DOI 10.6028/NIST.AI.600-1), julio de 2024, consultado 2026-10-26
- [REF-07] Latent Space, «The Rise of the AI Engineer», https://www.latent.space/p/ai-engineer, 2023-06-30, consultado 2026-10-26
- [REF-08] Huyen, Chip, «AI Engineering: Building Applications with Foundation Models» (O'Reilly Media, 2025; repositorio y resúmenes de capítulos de la autora), https://github.com/chiphuyen/aie-book, 2025, consultado 2026-10-26
- [REF-09] Microsoft Learn, «Microsoft Certified: Azure AI Apps and Agents Developer Associate» (examen AI-103), https://learn.microsoft.com/en-us/credentials/certifications/azure-ai-apps-and-agents-developer-associate/, act. 2026-08-11, consultado 2026-10-26
- [REF-10] Microsoft Learn, «Azure AI Engineer Associate» (AI-102, retirada), https://learn.microsoft.com/en-us/credentials/certifications/azure-ai-engineer/, act. 2026-06-30, consultado 2026-10-26

## 2. Fundamentos y «por qué ahora»

- [REF-11] Microsoft Learn, «How Generative AI and LLMs work», https://learn.microsoft.com/en-us/dotnet/ai/conceptual/how-genai-and-llms-work, ms.date 2026-03-04, consultado 2026-10-25
- [REF-12] Microsoft Learn, «Understanding tokens», https://learn.microsoft.com/en-us/dotnet/ai/conceptual/understanding-tokens, ms.date 2026-03-04, consultado 2026-10-25
- [REF-13] Microsoft Learn, «Prompt engineering concepts», https://learn.microsoft.com/en-us/dotnet/ai/conceptual/prompt-engineering-dotnet, ms.date 2026-03-04, consultado 2026-10-25
- [REF-14] Microsoft Learn, «Azure OpenAI built-in connector reference» (Logic Apps; semántica de temperatura y top-p), https://learn.microsoft.com/azure/logic-apps/connectors/built-in/reference/openai, ms.date 2025-03-22, act. 2026-03-06, consultado 2026-10-25
- [REF-15] Ji et al., «Survey of Hallucination in Natural Language Generation», https://arxiv.org/abs/2202.03629, ACM Computing Surveys, 2022, consultado 2026-10-25
- [REF-16] Microsoft Learn, «Groundedness detection in Azure AI Content Safety», https://learn.microsoft.com/azure/ai-services/content-safety/concepts/groundedness, ms.date 2025-11-21, act. 2026-06-05, consultado 2026-10-25
- [REF-17] Vaswani et al., «Attention Is All You Need», https://arxiv.org/abs/1706.03762, v1 2017-06-12, consultado 2026-10-26
- [REF-18] Brown et al., «Language Models are Few-Shot Learners», https://arxiv.org/abs/2005.14165, v1 2020-05-28, consultado 2026-10-26
- [REF-19] Ouyang et al., «Training language models to follow instructions with human feedback», https://arxiv.org/abs/2203.02155, v1 2022-03-04, consultado 2026-10-26
- [REF-20] OpenAI, «ChatGPT: Optimizing Language Models for Dialogue», https://openai.com/blog/chatgpt/ (leída por instantánea de la Wayback Machine de 2022-12; el sitio responde 403 a clientes automáticos), 2022-11-30, consultado 2026-10-26
- [REF-21] Yao et al., «ReAct: Synergizing Reasoning and Acting in Language Models», https://arxiv.org/abs/2210.03629, ICLR 2023, v1 2022-10-06, consultado 2026-10-26
- [REF-22] Schick et al., «Toolformer: Language Models Can Teach Themselves to Use Tools», https://arxiv.org/abs/2302.04761, v1 2023-02-09, consultado 2026-10-26
- [REF-23] OpenAI (Eleti, Harris, Kilpatrick), «Function calling and other API updates», https://openai.com/index/function-calling-and-other-api-updates/ (leída por Wayback, instantánea de 2023-07), 2023-06-13, consultado 2026-10-26
- [REF-24] OpenAI, «Introducing Structured Outputs in the API», https://openai.com/index/introducing-structured-outputs-in-the-api/ (leída por Wayback, instantánea 20240806180746), 2024-08-06, consultado 2026-10-26
- [REF-25] Anthropic, «Introducing 100K Context Windows», https://www.anthropic.com/news/100k-context-windows, 2023-05-11, consultado 2026-10-26
- [REF-26] OpenAI, «New models and developer products announced at DevDay», https://openai.com/blog/new-models-and-developer-products-announced-at-devday (leída por Wayback, 2023-12), 2023-11-06, consultado 2026-10-26
- [REF-27] Anthropic, «Introducing Claude 2.1», https://www.anthropic.com/news/claude-2-1, 2023-11-21, consultado 2026-10-26
- [REF-28] Google, «Our next-generation model: Gemini 1.5», https://blog.google/technology/ai/google-gemini-next-generation-model-february-2024/, 2024-02-15, consultado 2026-10-26
- [REF-29] Meta, «Meta and Microsoft Introduce the Next Generation of Llama», https://about.fb.com/news/2023/07/llama-2/, 2023-07-18, consultado 2026-10-26
- [REF-30] Touvron et al., «Llama 2: Open Foundation and Fine-Tuned Chat Models», https://arxiv.org/abs/2307.09288, v1 2023-07-18, consultado 2026-10-26
- [REF-31] Qwen Team, «Qwen2.5: A Party of Foundation Models!», https://qwenlm.github.io/blog/qwen2.5/, 2024-09-19, consultado 2026-10-26
- [REF-32] Qwen Team, «Qwen2.5 Technical Report», https://arxiv.org/abs/2412.15115, v1 2024-12-19, consultado 2026-10-26
- [REF-33] Qwen Team, «Qwen3: Think Deeper, Act Faster», https://qwenlm.github.io/blog/qwen3/, 2025-04-29, consultado 2026-10-26
- [REF-34] Ollama, «Release v0.0.1» (repositorio ollama/ollama), https://github.com/ollama/ollama/releases/tag/v0.0.1, 2023-07-08, consultado 2026-10-26
- [REF-35] Ollama, «Tool support», https://ollama.com/blog/tool-support, 2024-07-25, consultado 2026-10-26
- [REF-36] Ollama, «Structured outputs», https://ollama.com/blog/structured-outputs, 2024-12-06, consultado 2026-10-26
- [REF-37] Anthropic, «Introducing the Model Context Protocol», https://www.anthropic.com/news/model-context-protocol, 2024-11-25, consultado 2026-10-26
- [REF-38] Model Context Protocol, «schema/» (versiones publicadas de la especificación: 2024-11-05, 2025-03-26, 2025-06-18, 2025-11-25, 2026-07-28 y draft), https://github.com/modelcontextprotocol/modelcontextprotocol/tree/main/schema, rama main, consultado 2026-10-26
- [REF-39] Microsoft DevBlogs (Semantic Kernel; Bolanos, M.), «Say hello to Semantic Kernel V1.0.1», https://devblogs.microsoft.com/semantic-kernel/semantic-kernel-v1-0-1-has-arrived-to-help-you-build-agents/, 2023-12-19, consultado 2026-10-26
- [REF-40] Microsoft DevBlogs (.NET; Quintanilla, L.), «Introducing Microsoft.Extensions.AI Preview – Unified AI Building Blocks for .NET», https://devblogs.microsoft.com/dotnet/introducing-microsoft-extensions-ai-preview/, 2024-10-08, consultado 2026-10-26
- [REF-41] Microsoft Developer Blog, «Microsoft partners with Anthropic to create official C# SDK for Model Context Protocol», https://developer.microsoft.com/blog/microsoft-partners-with-anthropic-to-create-official-c-sdk-for-model-context-protocol/, 2025-04-02, consultado 2026-10-26
- [REF-42] Microsoft DevBlogs (.NET), «AI and Vector Data Extensions are now Generally Available (GA)», https://devblogs.microsoft.com/dotnet/ai-vector-data-dotnet-extensions-ga/, 2025-05-21, consultado 2026-10-26
- [REF-43] Microsoft DevBlogs (Agent Framework; Henry, S.), «Microsoft Agent Framework Version 1.0», https://devblogs.microsoft.com/agent-framework/microsoft-agent-framework-version-1-0/, 2026-04-03, consultado 2026-10-26

## 3. Microsoft.Extensions.AI y adaptadores

- [REF-44] Microsoft Learn, «Microsoft.Extensions.AI libraries», https://learn.microsoft.com/en-us/dotnet/ai/microsoft-extensions-ai, ms.date 2026-09-14, consultado 2026-10-25
- [REF-45] Microsoft Learn, «Use the IChatClient interface», https://learn.microsoft.com/en-us/dotnet/ai/ichatclient, ms.date 2026-03-13, act. 2026-08-19, consultado 2026-10-25
- [REF-46] Microsoft Learn (API), «ChatOptions Class» (Microsoft.Extensions.AI.Abstractions v10.10.1), https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.ai.chatoptions, act. 2026-10-16, consultado 2026-10-25
- [REF-47] Microsoft Learn, «Quickstart – Request a response with structured output», https://learn.microsoft.com/en-us/dotnet/ai/quickstarts/structured-output, ms.date 2026-03-04, consultado 2026-10-25
- [REF-48] Microsoft Learn, [sin título registrado: tabla de decisión M.E.AI, MEDI, MEVD, MCP, MAF y Foundry; «MEAI alone isn't an agent framework»], https://learn.microsoft.com/en-us/dotnet/ai/dotnet-ai-ecosystem, ms.date 2026-04-15, consultado 2026-10-25
- [REF-49] dotnet/extensions, «Microsoft.Extensions.AI.OpenAI/README.md», https://github.com/dotnet/extensions/blob/main/src/Libraries/Microsoft.Extensions.AI.OpenAI/README.md, rama main, consultado 2026-10-25
- [REF-50] awaescher, «OllamaSharp» (README del repositorio), https://github.com/awaescher/OllamaSharp, rama principal (paquete 5.5.0 vigente al consultar), consultado 2026-10-25
- [REF-51] Ollama, [sin título registrado: compatibilidad con la API de OpenAI en /v1; tools sin tool_choice; reasoning_effort], https://docs.ollama.com/api/openai-compatibility, sin fecha visible, consultado 2026-10-25
- [REF-52] Ollama, [sin título registrado: parámetro think de /api/chat], https://docs.ollama.com/capabilities/thinking, sin fecha visible, consultado 2026-10-25/26 (sondeo del entorno)
- [REF-53] Ollama, [sin título registrado: format de /api/chat para salida estructurada], https://docs.ollama.com/capabilities/structured-outputs, sin fecha visible, consultado 2026-10-25/26 (sondeo del entorno)
- [REF-54] Ollama, [sin título registrado: referencia de /api/chat: prompt_eval_duration, prompt_eval_cached_count, keep_alive, num_ctx, think], https://docs.ollama.com/api/chat, sin fecha visible, consultado 2026-10-26
- [REF-55] Ollama, [sin título registrado: FAQ; contexto por defecto 4096, OLLAMA_CONTEXT_LENGTH, num_ctx, keep_alive, OLLAMA_NUM_PARALLEL], https://docs.ollama.com/faq, sin fecha visible, consultado 2026-10-26
- [REF-56] Ollama, [sin título registrado: contexto por defecto según VRAM], https://docs.ollama.com/context-length, sin fecha visible, consultado 2026-10-26
- [REF-57] Microsoft Learn, [sin título registrado: «Azure AI Inference beta SDK retired on August 26, 2026»; migrar a OpenAI/v1], https://learn.microsoft.com/en-us/azure/foundry-classic/foundry-models/supported-languages, act. 2026-10-19, consultado 2026-10-25
- [REF-58] Microsoft Learn, [sin título registrado: ciclo de vida de versiones de la API de Azure OpenAI; v1 con el cliente OpenAI estándar], https://learn.microsoft.com/en-us/azure/foundry/openai/api-version-lifecycle (antes en …/azure/ai-foundry/openai/api-version-lifecycle), ms.date 2026-05-13, consultado 2026-10-25
- [REF-59] Microsoft DevBlogs (.NET), [sin título registrado: anuncio de la plantilla aichatweb, preview 1], https://devblogs.microsoft.com/dotnet/announcing-dotnet-ai-template-preview1, 2025-03-06, consultado 2026-10-25
- [REF-60] GitHub Changelog, [sin título registrado: retiro de GitHub Models el 2026-07-30], https://github.blog/changelog/2026-07-30-github-models-is-now-retired/, 2026-07-30, consultado 2026-10-25
- [REF-61] dotnet/extensions, «Release v10.8.4» (plantilla sin proveedor por defecto), https://github.com/dotnet/extensions/releases/tag/v10.8.4, v10.8.4, consultado 2026-10-25
- [REF-62] dotnet/extensions, «UsageDetails.cs» (CachedInputTokenCount), https://github.com/dotnet/extensions/blob/25f07afa51034e37b334210642d7dc5f191c142d/src/Libraries/Microsoft.Extensions.AI.Abstractions/UsageDetails.cs, commit 25f07afa (el que trae el paquete 10.11.0), consultado 2026-10-26
- [REF-63] dotnet/extensions, «OpenAIChatClient.cs» y «OpenAIResponsesChatClient.cs» (mapeo de tokens cacheados; RawRepresentationFactory), https://github.com/dotnet/extensions/blob/25f07afa51034e37b334210642d7dc5f191c142d/src/Libraries/Microsoft.Extensions.AI.OpenAI/OpenAIChatClient.cs, commit 25f07afa, consultado 2026-10-26
- [REF-64] dotnet/extensions, «ChatOptions.cs» (comentario de RawRepresentationFactory), https://github.com/dotnet/extensions/blob/25f07afa51034e37b334210642d7dc5f191c142d/src/Libraries/Microsoft.Extensions.AI.Abstractions/ChatCompletion/ChatOptions.cs, commit 25f07afa, consultado 2026-10-26
- [REF-65] awaescher, «AbstractionMapper.cs» (OllamaSharp: uso sin tokens cacheados; duraciones en AdditionalProperties), https://github.com/awaescher/OllamaSharp/blob/135abcc3e31ac6a1ec535ff4c891e11ed1328df4/src/OllamaSharp/MicrosoftAi/AbstractionMapper.cs, commit 135abcc3, consultado 2026-10-26
- [REF-66] Microsoft Learn (API), «UsageDetails.CachedInputTokenCount» [sin título registrado: resumen y observación de la propiedad], https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.ai.usagedetails.cachedinputtokencount, act. 2026-10-16, consultado 2026-10-26

## 4. Estrategias de conocimiento y cachés

- [REF-67] Chan, Chen, Cheng, Huang, [sin título registrado: artículo que define CAG; fases, ecuaciones (1)–(2), tablas 1–3, Limitations], https://arxiv.org/abs/2412.15605 (DOI 10.1145/3701716.3715490), v2, consultado 2026-10-26
- [REF-68] hhhuang, «CAG» (implementación de referencia; kvcache.py; licencia MIT), https://github.com/hhhuang/CAG, rama main, último push 2025-05-26, consultado 2026-10-26
- [REF-69] Microsoft Learn (API), «DistributedCachingChatClient» [sin título registrado: referencia de la clase], https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.ai.distributedcachingchatclient, act. 2026-10-16, consultado 2026-10-26
- [REF-70] OpenAI, [sin título registrado: guía de prompt caching de la API], https://developers.openai.com/api/docs/guides/prompt-caching (redirigida desde platform.openai.com), sin fecha visible, consultado 2026-10-26
- [REF-71] Microsoft Learn, [sin título registrado: prompt caching de Azure OpenAI en Foundry], https://learn.microsoft.com/en-us/azure/foundry/openai/how-to/prompt-caching, ms.date 2026-08-11, consultado 2026-10-26
- [REF-72] Anthropic, [sin título registrado: prompt caching de la API de Claude], https://platform.claude.com/docs/en/build-with-claude/prompt-caching, sin fecha visible, consultado 2026-10-26
- [REF-73] ollama/ollama, «llm/llama_server.go» (cache_prompt; -c y -np; truncado), https://github.com/ollama/ollama/blob/v0.32.0-rc0/llm/llama_server.go, etiqueta v0.32.0-rc0, consultado 2026-10-26
- [REF-74] ollama/ollama, «releases/latest» (API de GitHub: última versión publicada v0.40.11), https://api.github.com/repos/ollama/ollama/releases/latest, 2026-10-24, consultado 2026-10-26
- [REF-75] ggml-org/llama.cpp, «tools/server/README.md» (cache_prompt, --cache-reuse, --ctx-checkpoints), https://github.com/ggml-org/llama.cpp/blob/master/tools/server/README.md, rama master (no la versión que trae Ollama 0.32), consultado 2026-10-26
- [REF-76] Hsieh et al., «RULER» [sin título registrado completo: ventana efectiva menor que la declarada], https://arxiv.org/abs/2404.06654, consultado 2026-10-26
- [REF-77] Leng et al., [sin título registrado: pocos modelos sostienen precisión arriba de 64k], https://arxiv.org/abs/2411.03538, consultado 2026-10-26
- [REF-78] Eyuboglu et al., «Cartridges» [sin título registrado completo: caché KV entrenada por corpus], https://arxiv.org/abs/2506.06266, consultado 2026-10-26
- [REF-79] [sin autores ni título registrados: ACC e híbrido CAG-RAG], https://arxiv.org/abs/2505.08261, consultado 2026-10-26
- [REF-80] Li et al., [sin título registrado: Self-Route; LC frente a RAG], https://arxiv.org/abs/2407.16833, EMNLP 2024 Industry, consultado 2026-10-26
- [REF-81] [sin autores ni título registrados: economía de guardar y reutilizar cachés KV], https://arxiv.org/abs/2503.14647, consultado 2026-10-26
- [REF-82] [sin autores registrados], «TurboRAG» [sin título registrado completo: caché KV precalculada por fragmento], https://arxiv.org/abs/2410.07590, consultado 2026-10-26
- [REF-83] [sin autores registrados], «Cache-Craft» [sin título registrado completo: gestión de cachés de fragmentos en RAG], https://arxiv.org/abs/2502.15734, consultado 2026-10-26
- [REF-84] Liu et al., «Lost in the Middle» [sin título registrado completo: peor uso de la información en el medio de contextos largos], https://arxiv.org/abs/2307.03172, 2023, consultado 2026-10-25

## 5. RAG, embeddings y almacenes vectoriales

- [REF-85] Lewis et al., «Retrieval-Augmented Generation for Knowledge-Intensive NLP Tasks», https://arxiv.org/abs/2005.11401, NeurIPS 2020, v1 2020-05-22, consultado 2026-10-26
- [REF-86] Microsoft Learn, «Integrate Your Data into AI Apps with RAG», https://learn.microsoft.com/en-us/dotnet/ai/conceptual/rag, ms.date 2026-09-14, consultado 2026-10-25
- [REF-87] Microsoft Learn, «How Embeddings Extend Your AI Model's Reach», https://learn.microsoft.com/en-us/dotnet/ai/conceptual/embeddings, ms.date 2026-03-04, consultado 2026-10-25
- [REF-88] Microsoft Learn, «Use the IEmbeddingGenerator interface», https://learn.microsoft.com/en-us/dotnet/ai/iembeddinggenerator, ms.date 2025-12-11, consultado 2026-10-25
- [REF-89] Microsoft Learn, «Vector databases for .NET AI apps», https://learn.microsoft.com/en-us/dotnet/ai/vector-stores/overview, ms.date 2026-02-28, act. 2026-07-23, consultado 2026-10-25
- [REF-90] Microsoft Learn, [sin título registrado: capacidades de Microsoft.Extensions.VectorData; relación con EF Core], https://learn.microsoft.com/en-us/dotnet/ai/conceptual/mevd-library, ms.date 2026-04-15, consultado 2026-10-25
- [REF-91] Microsoft Learn, [sin título registrado: atributos y definición del modelo de datos vectoriales], https://learn.microsoft.com/en-us/dotnet/ai/vector-stores/define-your-data-model, ms.date 2026-03-24, consultado 2026-10-25
- [REF-92] Microsoft Learn, [sin título registrado: SearchAsync, Top/Skip/Filter, búsqueda híbrida], https://learn.microsoft.com/en-us/dotnet/ai/vector-stores/vector-search, ms.date 2026-02-28, consultado 2026-10-25
- [REF-93] Microsoft Learn, [sin título registrado: ingesta manual a un almacén vectorial], https://learn.microsoft.com/en-us/dotnet/ai/vector-stores/how-to/vector-store-data-ingestion, ms.date 2026-02-28, consultado 2026-10-25
- [REF-94] Microsoft Learn, [sin título registrado: componentes de Microsoft.Extensions.DataIngestion; chunker, writer y pipeline], https://learn.microsoft.com/en-us/dotnet/ai/conceptual/data-ingestion, ms.date 2025-12-02, act. 2026-07-21, consultado 2026-10-25
- [REF-95] Microsoft Learn, [sin título registrado: propósito de MEDI y sus bases], https://learn.microsoft.com/en-us/dotnet/ai/conceptual/medi-library, ms.date 2026-04-15, consultado 2026-10-25
- [REF-96] Microsoft Learn (Semantic Kernel), [sin título registrado: tabla de conectores de almacenes vectoriales], https://learn.microsoft.com/en-us/semantic-kernel/concepts/vector-store-connectors/out-of-the-box-connectors/, ms.date 2024-07-08, act. 2026-10-07, consultado 2026-10-25
- [REF-97] Microsoft Learn (Semantic Kernel), [sin título registrado: conector SqliteVec], https://learn.microsoft.com/en-us/semantic-kernel/concepts/vector-store-connectors/out-of-the-box-connectors/sqlite-connector, act. 2026-07-27, consultado 2026-10-25
- [REF-98] CommunityToolkit, «CommunityToolkit/AI» (README: conectores CommunityToolkit.VectorData.*, licencia MIT), https://github.com/CommunityToolkit/AI, rama principal, consultado 2026-10-25
- [REF-99] microsoft/semantic-kernel, «Migrate VectorStoreRAG and Concepts samples to CommunityToolkit.VectorData packages» (PR #14170), https://github.com/microsoft/semantic-kernel/pull/14170, fusionado 2026-07-24, consultado 2026-10-25
- [REF-100] Microsoft Learn (EF Core), [sin título registrado: búsqueda vectorial en el proveedor SQL Server], https://learn.microsoft.com/en-us/ef/core/providers/sql-server/vector-search, ms.date 2026-06-09, consultado 2026-10-25
- [REF-101] Microsoft Learn (EF Core), [sin título registrado: novedades de EF Core 11], https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-11.0/whatsnew, ms.date 2026-08-03, consultado 2026-10-25
- [REF-102] Ollama, [sin título registrado: embeddings; /api/embed; vectores L2-normalizados], https://docs.ollama.com/capabilities/embeddings, sin fecha visible, consultado 2026-10-25
- [REF-103] Ollama, [sin título registrado: referencia de /api/embed], https://docs.ollama.com/api/embed, sin fecha visible, consultado 2026-10-25
- [REF-104] Ollama, [sin título registrado: catálogo de modelos de embeddings], https://ollama.com/search?c=embedding, sin fecha visible, consultado 2026-10-25
- [REF-105] Ollama, «qwen3-embedding» (biblioteca de modelos), https://ollama.com/library/qwen3-embedding, sin fecha visible, consultado 2026-10-25
- [REF-106] Qwen, «Qwen3-Embedding-0.6B» (tarjeta del modelo), https://huggingface.co/Qwen/Qwen3-Embedding-0.6B, sin fecha visible, consultado 2026-10-25
- [REF-107] Ollama, «nomic-embed-text» (biblioteca de modelos), https://ollama.com/library/nomic-embed-text, sin fecha visible, consultado 2026-10-25
- [REF-108] nomic-ai, «nomic-embed-text-v1.5» (tarjeta del modelo), https://huggingface.co/nomic-ai/nomic-embed-text-v1.5, sin fecha visible, consultado 2026-10-25
- [REF-109] Microsoft Learn (Azure AI Search), [sin título registrado: técnicas de fragmentación; 512 tokens con 25 % de solapamiento], https://learn.microsoft.com/en-us/azure/search/vector-search-how-to-chunk-documents, ms.date 2026-06-08, consultado 2026-10-25
- [REF-110] Microsoft Learn (Azure AI Search), [sin título registrado: fórmula de RRF en búsqueda híbrida, k = 60], https://learn.microsoft.com/en-us/azure/search/hybrid-search-ranking, ms.date 2026-06-08, consultado 2026-10-25
- [REF-111] Cormack, Clarke, Büttcher, [sin título registrado: paper original de RRF], http://cormack.uwaterloo.ca/cormack/cormacksigir09-rrf.pdf (redirigida desde plg.uwaterloo.ca), SIGIR 2009, consultado 2026-10-26
- [REF-112] asg017, «sqlite-vec», https://github.com/asg017/sqlite-vec, «pre-v1», consultado 2026-10-25
- [REF-113] Microsoft Azure Architecture Center, «Design and develop a RAG solution», https://learn.microsoft.com/en-us/azure/architecture/ai-ml/guide/rag/rag-solution-design-and-evaluation-guide, ms.date 2025-12-17, act. 2026-07-02, consultado 2026-10-26
- [REF-114] Microsoft Azure Architecture Center, «Develop a RAG Solution on Azure - Preparation Phase», https://learn.microsoft.com/en-us/azure/architecture/ai-ml/guide/rag/rag-preparation-phase, ms.date 2025-10-10, act. 2026-07-02, consultado 2026-10-26

## 6. Agentes, workflows y MCP

- [REF-115] Anthropic (Erik S. y Barry Zhang), «Building effective agents», https://www.anthropic.com/engineering/building-effective-agents (hoy redirige a https://www.anthropic.com/research/building-effective-agents), 2024-12-19, consultado 2026-10-26
- [REF-116] Microsoft Learn, «Agents – .NET», https://learn.microsoft.com/en-us/dotnet/ai/conceptual/agents, ms.date 2025-12-10, consultado 2026-10-25
- [REF-117] Microsoft Learn, «Microsoft Agent Framework Overview», https://learn.microsoft.com/en-us/agent-framework/overview/, ms.date 2026-07-29, consultado 2026-10-25
- [REF-118] Microsoft Learn, «Agent Framework – Ollama provider», https://learn.microsoft.com/en-us/agent-framework/integrations/by-component/model-providers/ollama, ms.date 2026-10-15, consultado 2026-10-25
- [REF-119] Microsoft Learn (Agent Framework), [sin título registrado: índice de proveedores de modelos; cualquier IChatClient respalda un ChatClientAgent], https://learn.microsoft.com/en-us/agent-framework/integrations/by-component/model-providers/, ms.date 2026-09-29, consultado 2026-10-25
- [REF-120] microsoft/agent-framework, «Releases» (dotnet-1.26.0 del 2026-10-23), https://github.com/microsoft/agent-framework/releases, dotnet-1.26.0, consultado 2026-10-25
- [REF-121] Microsoft Learn, [sin título registrado: quickstart de function calling; UseFunctionInvocation, AIFunctionFactory.Create, ChatOptions.Tools], https://learn.microsoft.com/en-us/dotnet/ai/quickstarts/use-function-calling, ms.date 2026-03-04, consultado 2026-10-25
- [REF-122] Microsoft Learn (Agent Framework), [sin título registrado: aprobación de herramientas; ApprovalRequiredAIFunction, ToolApprovalRequestContent, CreateResponse], https://learn.microsoft.com/en-us/agent-framework/agents/tools/tool-approval, ms.date 2026-10-15, consultado 2026-10-25
- [REF-123] Microsoft Learn (Agent Framework), [sin título registrado: tipos de herramientas y matriz por proveedor], https://learn.microsoft.com/en-us/agent-framework/agents/tools/, ms.date 2026-09-29, consultado 2026-10-25
- [REF-124] Microsoft Learn (Agent Framework), [sin título registrado: definición de workflow; en .NET, sólo grafo], https://learn.microsoft.com/en-us/agent-framework/concepts/workflows/, ms.date 2026-07-30, consultado 2026-10-25
- [REF-125] Microsoft Learn (Agent Framework), [sin título registrado: WorkflowBuilder, InProcessExecution, supersteps], https://learn.microsoft.com/en-us/agent-framework/concepts/workflows/builder-and-execution, ms.date 2026-10-15, consultado 2026-10-25
- [REF-126] Microsoft Learn (Agent Framework), [sin título registrado: Executor y [MessageHandler]], https://learn.microsoft.com/en-us/agent-framework/concepts/workflows/executors, ms.date 2026-08-11, consultado 2026-10-25
- [REF-127] Microsoft Learn (Agent Framework), [sin título registrado: checkpoints de workflows], https://learn.microsoft.com/en-us/agent-framework/workflows/checkpoints, ms.date 2026-09-16, consultado 2026-10-25
- [REF-128] Microsoft Learn (Agent Framework), [sin título registrado: human-in-the-loop; RequestPort], https://learn.microsoft.com/en-us/agent-framework/workflows/human-in-the-loop, ms.date 2026-07-16, consultado 2026-10-25
- [REF-129] Microsoft Learn (Agent Framework), [sin título registrado: capacidades de los workflows], https://learn.microsoft.com/en-us/agent-framework/workflows/, ms.date 2026-07-29, consultado 2026-10-25
- [REF-130] modelcontextprotocol, «csharp-sdk» (README del SDK C# oficial), https://github.com/modelcontextprotocol/csharp-sdk, rama main, consultado 2026-10-25
- [REF-131] Model Context Protocol (SDK C#), [sin título registrado: getting started v2; AddMcpServer, WithHttpTransport, MapMcp, McpClient], https://csharp.sdk.modelcontextprotocol.io/v2/concepts/getting-started.html, v2 (corresponde al paquete 2.3.0), consultado 2026-10-25
- [REF-132] modelcontextprotocol/csharp-sdk, «docs/concepts/getting-started.md» (McpClientTool : AIFunction; AllowedHosts y CORS), https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/concepts/getting-started.md, rama main, consultado 2026-10-25
- [REF-133] modelcontextprotocol/csharp-sdk, «docs/concepts/tools/tools.md» (WithTools<T>(); parámetros resueltos por DI), https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/concepts/tools/tools.md, rama main, consultado 2026-10-25
- [REF-134] modelcontextprotocol/csharp-sdk, «docs/concepts/stateless/stateless.md» (HttpServerSessionMode.Stateless), https://github.com/modelcontextprotocol/csharp-sdk/blob/main/docs/concepts/stateless/stateless.md, rama main, consultado 2026-10-25
- [REF-135] Microsoft Learn, [sin título registrado: quickstart de servidor MCP; plantilla mcpserver], https://learn.microsoft.com/en-us/dotnet/ai/quickstarts/build-mcp-server, ms.date 2026-03-04, consultado 2026-10-25

## 7. Marcos comparados: Semantic Kernel, AutoGen, LangGraph

- [REF-136] microsoft, «semantic-kernel» (README: «Semantic Kernel is now Microsoft Agent Framework!»), https://github.com/microsoft/semantic-kernel, rama main, consultado 2026-10-25
- [REF-137] Microsoft DevBlogs (Agent Framework), [sin título registrado: política de soporte de SK y recomendación para proyectos nuevos], https://devblogs.microsoft.com/agent-framework/semantic-kernel-and-microsoft-agent-framework/, 2025-10-07, consultado 2026-10-25
- [REF-138] Microsoft Learn, [sin título registrado: documentación de Semantic Kernel], https://learn.microsoft.com/en-us/semantic-kernel/, sin fecha registrada, consultado 2026-10-25
- [REF-139] Microsoft Learn (Semantic Kernel), [sin título registrado: ChatCompletionAgent, Kernel, ChatHistoryAgentThread], https://learn.microsoft.com/en-us/semantic-kernel/frameworks/agent/agent-types/chat-completion-agent, sin fecha registrada, consultado 2026-10-25
- [REF-140] Microsoft Learn (Agent Framework), [sin título registrado: guía de migración desde Semantic Kernel], https://learn.microsoft.com/en-us/agent-framework/migration-guide/from-semantic-kernel/, ms.date 2026-04-01, consultado 2026-10-25
- [REF-141] microsoft, «autogen» (README: «Project archived and no longer maintained»), https://github.com/microsoft/autogen, texto vigente desde el commit del 2026-10-16, consultado 2026-10-25
- [REF-142] LangChain, [sin título registrado: definición de LangGraph], https://docs.langchain.com/oss/python/langgraph/overview, sin fecha registrada, consultado 2026-10-25
- [REF-143] LangChain, [sin título registrado: persistencia de LangGraph; checkpointer, thread_id], https://docs.langchain.com/oss/python/langgraph/persistence, sin fecha registrada, consultado 2026-10-25
- [REF-144] LangChain, [sin título registrado: changelog de LangSmith, semana «October 13-17, 2025»; renombre de LangGraph Platform a LangSmith Deployment], https://docs.langchain.com/langsmith/changelog, 2025-10, consultado 2026-10-25
- [REF-145] LangChain, [sin título registrado: LangSmith Deployment como servicio gestionado], https://www.langchain.com/langsmith/deployment, sin fecha registrada, consultado 2026-10-25
- [REF-146] LangChain, [sin título registrado: referencia de la API del Agent Server; threads, runs, X-Api-Key], https://docs.langchain.com/langsmith/server-api-ref, sin fecha registrada, consultado 2026-10-25
- [REF-147] langchain-ai/langgraph, «libs/sdk-py/langgraph_sdk/_async» (rutas REST del SDK oficial), https://github.com/langchain-ai/langgraph/tree/main/libs/sdk-py/langgraph_sdk/_async, rama main, consultado 2026-10-25
- [REF-148] Python Package Index, «langgraph» (metadatos JSON), https://pypi.org/pypi/langgraph/json, 1.2.17, consultado 2026-10-25
- [REF-149] npm, «@langchain/langgraph» (registro), https://registry.npmjs.org/@langchain/langgraph, 1.5.2, consultado 2026-10-25
- [REF-150] tryAGI, «LangChain» (LangChain .NET comunitario, README), https://github.com/tryAGI/LangChain, 0.17.1, consultado 2026-10-25

## 8. Pruebas y evaluación

- [REF-151] Microsoft Learn, [sin título registrado: bibliotecas Microsoft.Extensions.AI.Evaluation y sus evaluadores], https://learn.microsoft.com/en-us/dotnet/ai/evaluation/libraries, ms.date 2026-04-09, consultado 2026-10-25
- [REF-152] Microsoft Learn, [sin título registrado: evaluación con reporte; DiskBasedReportingConfiguration, caché de 14 días, tendencias en lugar de compuerta], https://learn.microsoft.com/en-us/dotnet/ai/evaluation/evaluate-with-reporting, ms.date 2026-04-09, consultado 2026-10-25
- [REF-153] Microsoft Learn, [sin título registrado: quickstart de evaluación con CoherenceEvaluator], https://learn.microsoft.com/en-us/dotnet/ai/evaluation/evaluate-ai-response, ms.date 2026-04-09, consultado 2026-10-25
- [REF-154] Microsoft Learn, [sin título registrado: evaluadores de Safety; requieren Azure y un proyecto de Foundry], https://learn.microsoft.com/en-us/dotnet/ai/evaluation/evaluate-safety, ms.date 2026-04-09, consultado 2026-10-25
- [REF-155] Es, James, Espinosa-Anke, Schockaert, «Ragas: Automated Evaluation of Retrieval Augmented Generation», https://arxiv.org/abs/2309.15217 (ACL Anthology 2024.eacl-demo.16), 2023-09-26, consultado 2026-10-26
- [REF-156] Saad-Falcon, Khattab, Potts, Zaharia, «ARES: An Automated Evaluation Framework for Retrieval-Augmented Generation Systems», https://arxiv.org/abs/2311.09476 (ACL Anthology 2024.naacl-long.20), 2023-11-16, consultado 2026-10-26
- [REF-157] Yu, Gan, Zhang, Tong, Liu, Liu, «Evaluation of Retrieval-Augmented Generation: A Survey», https://arxiv.org/abs/2405.07437 (DOI 10.1007/978-981-96-1024-2_8), 2024-05-13, consultado 2026-10-26
- [REF-158] Zheng, Chiang, Sheng, Zhuang et al., «Judging LLM-as-a-Judge with MT-Bench and Chatbot Arena», https://arxiv.org/abs/2306.05685, NeurIPS 36, consultado 2026-10-26
- [REF-159] Microsoft Learn (API), «String.GetHashCode» [sin título registrado: Remarks; el hash puede cambiar entre corridas], https://learn.microsoft.com/en-us/dotnet/api/system.string.gethashcode, sin fecha registrada, consultado 2026-10-25

## 9. Seguridad

- [REF-160] OWASP GenAI Security Project, «LLM01:2025 Prompt Injection», https://genai.owasp.org/llmrisk/llm01-prompt-injection/, 2025, consultado 2026-10-25
- [REF-161] OWASP GenAI Security Project, [sin título registrado: lista LLM01–LLM10:2025], https://genai.owasp.org/llm-top-10/, 2025, consultado 2026-10-25
- [REF-162] OWASP GenAI Security Project, «LLM06:2025 Excessive Agency», https://genai.owasp.org/llmrisk/llm062025-excessive-agency/, 2025, consultado 2026-10-25
- [REF-163] OWASP GenAI Security Project, «LLM08:2025 Vector and Embedding Weaknesses», https://genai.owasp.org/llmrisk/llm082025-vector-and-embedding-weaknesses/, 2025, consultado 2026-10-25
- [REF-164] OWASP GenAI Security Project, «OWASP Top 10 For Agentic Applications 2026» (título del PDF oficial, genai.owasp.org/download/52117/, «Version 2026 December 2025»; nombres ASI01–ASI10 confirmados contra el PDF), https://genai.owasp.org/resource/owasp-top-10-for-agentic-applications-for-2026/, 2025-12-09, consultado 2026-10-25
- [REF-165] Greshake et al., «Not what you've signed up for…» [sin título registrado completo: inyección indirecta en aplicaciones reales], https://arxiv.org/abs/2302.12173, 2023, consultado 2026-10-25
- [REF-166] Hines et al., «Defending Against Indirect Prompt Injection Attacks With Spotlighting», https://arxiv.org/abs/2403.14720, 2024, consultado 2026-10-25
- [REF-167] Microsoft Learn (ASP.NET Core), [sin título registrado: Secret Manager; no cifra; Key Vault], https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets, ms.date 2026-05-13, consultado 2026-10-25

## 10. Operación, observabilidad y despliegue

- [REF-168] OpenTelemetry, [sin título registrado: convenciones semánticas GenAI, estado Development; aviso de mudanza de repositorio], https://opentelemetry.io/docs/specs/semconv/gen-ai/, sin fecha registrada, consultado 2026-10-25
- [REF-169] open-telemetry, «semantic-conventions-genai» (README, docs/gen-ai/client-inference.md, gen-ai-spans.md, gen-ai-agent-spans.md), https://github.com/open-telemetry/semantic-conventions-genai, rama main al 2026-10-21, consultado 2026-10-25
- [REF-170] open-telemetry, «semantic-conventions — docs/gen-ai/gen-ai-spans.md» (OTEL_SEMCONV_STABILITY_OPT_IN=gen_ai_latest_experimental), https://raw.githubusercontent.com/open-telemetry/semantic-conventions/v1.37.0/docs/gen-ai/gen-ai-spans.md, v1.37.0, consultado 2026-10-25
- [REF-171] open-telemetry, «semantic-conventions» (etiqueta v1.41.0, docs/gen-ai/gen-ai-metrics.md: los nombres de métricas que emite M.E.AI 10.11.0; etiqueta v1.37.0, docs/registry/attributes/gen-ai.md: gen_ai.system deprecado), https://github.com/open-telemetry/semantic-conventions, v1.41.0 y v1.37.0, consultado 2026-10-25
- [REF-172] OpenTelemetry (blog), [sin título registrado: observabilidad GenAI; spans invoke_agent, chat, execute_tool], https://opentelemetry.io/blog/2026/genai-observability/, 2026, consultado 2026-10-25
- [REF-173] Microsoft Learn (API), «OpenTelemetryChatClient.EnableSensitiveData» [sin título registrado: default false; OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT], https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.ai.opentelemetrychatclient.enablesensitivedata, sin fecha registrada, consultado 2026-10-25
- [REF-174] Aspire, [sin título registrado: dashboard; visualizador GenAI], https://aspire.dev/dashboard/explore/, sin fecha registrada, consultado 2026-10-25
- [REF-175] Aspire, [sin título registrado: integración de hosting de Ollama, CommunityToolkit.Aspire.Hosting.Ollama], https://aspire.dev/integrations/ai/ollama/ollama-host/, sin fecha registrada, consultado 2026-10-25
- [REF-176] Aspire, [sin título registrado: integración de cliente CommunityToolkit.Aspire.OllamaSharp], https://aspire.dev/integrations/ai/ollama/ollama-connect/, sin fecha registrada, consultado 2026-10-25
- [REF-177] Microsoft DevBlogs (Aspire), [sin título registrado: mejoras del dashboard, exportación y telemetría], https://devblogs.microsoft.com/aspire/aspire-dashboard-improvements-export-and-telemetry/, 2026-03-31, consultado 2026-10-25
- [REF-178] Microsoft Learn, [sin título registrado: qué es Foundry Local; plataformas, catálogo], https://learn.microsoft.com/en-us/azure/foundry-local/what-is-foundry-local, ms.date 2026-05-15, consultado 2026-10-25
- [REF-179] Microsoft DevBlogs (Foundry), [sin título registrado: GA de Foundry Local], https://devblogs.microsoft.com/foundry/foundry-local-ga/, 2026-04-09, consultado 2026-10-25
- [REF-180] ONNX Runtime, [sin título registrado: ONNX Runtime GenAI, API C#, «in preview»], https://onnxruntime.ai/docs/genai/, sin fecha registrada, consultado 2026-10-25
- [REF-181] Hugging Face (Transformers), [sin título registrado: definición de cuantización], https://huggingface.co/docs/transformers/main/en/quantization/overview, rama main, consultado 2026-10-25

## 11. Decisiones de arquitectura

- [REF-182] Microsoft Learn, «Common web application architectures», https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures, ms.date 2021-12-12, act. 2026-07-08, consultado 2026-10-25
- [REF-183] Cockburn, A., «Hexagonal Architecture», https://alistair.cockburn.us/hexagonal-architecture/, 2005-09-04, consultado 2026-10-25
- [REF-184] Nygard, M., «Documenting Architecture Decisions», https://www.cognitect.com/blog/2011/11/15/documenting-architecture-decisions, 2011-11-15, consultado 2026-10-26
- [REF-185] Microsoft, Azure Well-Architected Framework, «Maintain an architecture decision record (ADR)», https://learn.microsoft.com/en-us/azure/well-architected/architect-role/architecture-decision-record, ms.date 2026-04-10, consultado 2026-10-26

## 12. Caso base y registros de paquetes

- [REF-186] hdcm-dev, «Lab-E2E.WebBlazor» (caso base Movilidad Urbana: src/MovilidadUrbana.ApiWeb/, src/MovilidadUrbana.Web/ y su ia-db), https://github.com/hdcm-dev/Lab-E2E.WebBlazor, commit 8fb4c3a, consultado 2026-10-25
- [REF-187] NuGet, [sin título registrado: API de contenido de paquetes, versiones publicadas], https://api.nuget.org/v3-flatcontainer/{id}/index.json, consulta por paquete, consultado 2026-10-27 (re-verificación de la construcción; los dossiers la consultaron el 2026-10-25/26)
- [REF-188] NuGet, [sin título registrado: API de registro; fechas, deprecaciones y paquete alternativo], https://api.nuget.org/v3/registration5-gz-semver2/{id}/index.json, consulta por paquete, consultado 2026-10-26
- [REF-189] NuGet, [sin título registrado: búsqueda de paquetes, q=langgraph y q=graphlang], https://azuresearch-usnc.nuget.org/query?q=langgraph, consulta del día, consultado 2026-10-25
- [REF-190] arXiv, [sin título registrado: API de exportación; fechas de v1 y resúmenes], https://export.arxiv.org/api/query?id_list={id}, consulta por id, consultado 2026-10-26
- [REF-191] GitHub, [sin título registrado: REST API de repositorios; estado de archivado y fechas], https://api.github.com/repos/{owner}/{repo}, consulta por repositorio, consultado 2026-10-25
- [REF-192] dotnet/extensions, «ChatClientBuilder.cs» (método `Build`: «apply the factories in reverse order, so that the first factory added is the outermost»), https://github.com/dotnet/extensions/blob/25f07afa51034e37b334210642d7dc5f191c142d/src/Libraries/Microsoft.Extensions.AI/ChatCompletion/ChatClientBuilder.cs, commit 25f07afa (el que trae el paquete 10.11.0), consultado 2026-10-27 (agregada por la redacción de §5, verificada con curl sobre el archivo crudo; convalidada por la presidencia el 2026-10-27 tras comprobar de nuevo la cita en la línea 47 del archivo crudo)
- [REF-193] microsoft/aspire, «Extensions.cs» (plantilla aspire-servicedefaults; `ConfigureHttpClientDefaults`: «// Turn on resilience by default» y `http.AddStandardResilienceHandler();`), https://github.com/microsoft/aspire/blob/c89352703f78ae46de90fbf751ed8b52b77b89bf/src/Aspire.ProjectTemplates/templates/aspire-servicedefaults/Extensions.cs, etiqueta v13.6.4 (commit c8935270), consultado 2026-10-27 (agregada por la redacción de §12, verificada con curl sobre el archivo crudo, líneas 29-36; pendiente de convalidación)
- [REF-194] dotnet/extensions, «HttpStandardResilienceOptions.cs» (Microsoft.Extensions.Http.Resilience; orden «Bulkhead -> Total Request Timeout -> Retry -> Circuit Breaker -> Attempt Timeout» y `AttemptTimeout` «using custom Timeout of 10 seconds», `Timeout = TimeSpan.FromSeconds(10)`), https://github.com/dotnet/extensions/blob/25f07afa51034e37b334210642d7dc5f191c142d/src/Libraries/Microsoft.Extensions.Http.Resilience/Resilience/HttpStandardResilienceOptions.cs, etiqueta v10.11.0 (commit 25f07afa), consultado 2026-10-27 (agregada por la redacción de §12, verificada con curl sobre el archivo crudo, líneas 16-18 y 85-95; pendiente de convalidación)
- [REF-195] dotnet/extensions, «HttpRetryStrategyOptions.cs» (Microsoft.Extensions.Http.Resilience; «By default, the options are configured to handle only transient failures», que incluyen `HttpRequestException` y `TimeoutRejectedException`), https://github.com/dotnet/extensions/blob/25f07afa51034e37b334210642d7dc5f191c142d/src/Libraries/Microsoft.Extensions.Http.Resilience/Polly/HttpRetryStrategyOptions.cs, etiqueta v10.11.0 (commit 25f07afa), consultado 2026-10-27 (agregada por la redacción de §12, verificada con curl sobre el archivo crudo, líneas 22-29; pendiente de convalidación)
- [REF-196] Model Context Protocol, «Transports» (especificación, «Security Warning» de Streamable HTTP: «Servers MUST validate the Origin header on all incoming connections to prevent DNS rebinding attacks»; «When running locally, servers SHOULD bind only to localhost (127.0.0.1) rather than all network interfaces (0.0.0.0)»; «Servers SHOULD implement proper authentication for all connections»), https://modelcontextprotocol.io/specification/2025-06-18/basic/transports, versión 2025-06-18, consultado 2026-10-27 (agregada por la redacción de §11, verificada con curl sobre la página publicada y extracción del texto el 2026-10-27; pendiente de convalidación por la presidencia)
- [REF-197] Model Context Protocol, «Streamable HTTP» (especificación, «Security & Endpoint»: mantiene el MUST de validar `Origin` y agrega «If the Origin header is present and invalid, servers MUST respond with HTTP 403 Forbidden»), https://modelcontextprotocol.io/specification/2026-07-28/basic/transports/streamable-http, versión 2026-07-28, consultado 2026-10-27 (agregada por la redacción de §11, verificada con curl sobre la página publicada y extracción del texto el 2026-10-27; pendiente de convalidación por la presidencia). En la 2026-07-28 la ruta `basic/transports` sirve la página «Overview»; el texto está en esta subpágina
- [REF-198] Model Context Protocol, «Tools» (especificación: «For trust & safety and security, clients MUST consider tool annotations to be untrusted unless they come from trusted servers»; «there SHOULD always be a human in the loop with the ability to deny tool invocations»; «Security Considerations», «Clients SHOULD: […] Validate tool results before passing to LLM»), https://modelcontextprotocol.io/specification/2025-06-18/server/tools, versión 2025-06-18, consultado 2026-10-27 (agregada por la redacción de §11, verificada con curl sobre la página publicada y extracción del texto el 2026-10-27; pendiente de convalidación por la presidencia). La frase de las anotaciones y la del humano en el circuito siguen iguales en la 2026-07-28 (`…/specification/2026-07-28/server/tools`)
- [REF-199] Model Context Protocol, «Authorization» (especificación: «Authorization is OPTIONAL for MCP implementations»; «Implementations using an HTTP-based transport SHOULD conform to this specification»; se basa en «OAuth 2.1 IETF DRAFT (draft-ietf-oauth-v2-1-13)», RFC 8414, RFC 7591 y RFC 9728), https://modelcontextprotocol.io/specification/2025-06-18/basic/authorization, versión 2025-06-18, consultado 2026-10-27 (agregada por la redacción de §11, verificada con curl sobre la página publicada y extracción del texto el 2026-10-27; pendiente de convalidación por la presidencia)
- [REF-200] NuGet, [sin título registrado: manifiestos .nuspec de `Microsoft.EntityFrameworkCore.Sqlite` 10.0.14 y de `CommunityToolkit.VectorData.SqliteVec` 1.0.3-preview; el primero declara «<dependency id="SQLitePCLRaw.bundle_e_sqlite3" version="2.1.13" exclude="Build,Analyzers" />» y el segundo «<dependency id="SQLitePCLRaw.bundle_e_sqlite3" version="3.0.3" exclude="Build,Analyzers" />»], https://api.nuget.org/v3-flatcontainer/microsoft.entityframeworkcore.sqlite/10.0.14/microsoft.entityframeworkcore.sqlite.nuspec y https://api.nuget.org/v3-flatcontainer/communitytoolkit.vectordata.sqlitevec/1.0.3-preview/communitytoolkit.vectordata.sqlitevec.nuspec, versiones 10.0.14 y 1.0.3-preview, consultado 2026-10-27 (agregada por la redacción de §14, verificada con curl sobre los dos manifiestos; pendiente de convalidación por la presidencia)
- [REF-201] Microsoft Learn (NuGet), «Central Package Management» (`ManagePackageVersionsCentrally`; «In each project file, define <PackageReference /> elements without the Version attribute. The version will be resolved from the corresponding <PackageVersion /> entry in Directory.Packages.props»; *transitive pinning* con `CentralPackageTransitivePinningEnabled`: «Note that downgrades are not allowed when transitive pinning a package. If you attempt to pin a package to a lower version than the one requested by your dependencies, restore will raise a NU1109 error»), https://learn.microsoft.com/en-us/nuget/consume-packages/central-package-management, ms.date 2025-08-22, consultado 2026-10-27 (agregada por la redacción del Anexo A, verificada con curl sobre la página publicada y extracción del texto el 2026-10-27; pendiente de convalidación por la presidencia)

## Pendientes: fuentes que el plan cita y ningún dossier verificó

Estas fuentes aparecen en el plan v3 o en sus anexos, pero no están en la tabla de fuentes de ningún dossier ni en el sondeo. **No tienen número REF** y no se citan hasta que un despacho las verifique contra la fuente primaria y las agregue acá (regla 1 de la carta).

| Fuente | Dónde la usa el plan | Qué pasa | Qué hace falta |
|---|---|---|---|
| Especificación MCP 2025-06-18, «Transports» y «Tools» (`modelcontextprotocol.io/specification/2025-06-18/basic/transports` y `…/server/tools`) | §11.5, §E.2 fila 13, Anexo B (MUST validar `Origin`; lo que anuncia un servidor ajeno es no confiable) | La leyó el especialista AH-01 en el ciclo 2 (Mesa, E1, 2026-10-26), no un dossier. AH-01 pidió confirmar si hay una revisión posterior; N4 E03 registra que `specification/latest` redirige a la 2026-07-28 | Leer las dos páginas en la 2026-07-28 (y en la 2025-06-18) y registrar si el texto se mantiene; recién entonces dar número |
| Autorización MCP (la que define la especificación) | §11.5: «a leer en la fuente primaria antes de redactar cualquier mecanismo (H-013)» | El plan ya prohíbe nombrar un mecanismo sin fuente | Igual que arriba, o §11.5 no nombra ninguno |
| Últimas versiones de NUnit 5.0.0, NUnit3TestAdapter 6.3.1 y Microsoft.NET.Test.Sdk 18.11.0 «al 2026-10-26» | Anexo F (fila de pruebas fieles al caso base) | Vienen del informe del senior .NET de la mesa, no de un dossier ni de DEP-02 | Consultar REF-187 por esos tres ids antes de escribir la fila con esas cifras; si no, la fila dice «no son las últimas» sin número |
| Aspire 13 («.NET Aspire» → «Aspire», `aspire.dev/whats-new/aspire-13/`) | §12.7 | N5 F09 la leyó «vía resultado de búsqueda» y la respaldó con un artículo de Visual Studio Magazine (fuente secundaria) | Leer la página primaria antes de citar el renombre |

## Correspondencia (no va a la guía)

IDs de dossier por referencia. «N0b B03» se lee «fuente B03 de la tabla de fuentes del dossier N0b». «Sondeo» es `Sondeo-Entorno.md`; «I-01 E-PO-n», la evidencia ejecutada del insumo I-01.

| REF | IDs en los dossiers |
|---|---|
| REF-01 | N0b B01 |
| REF-02 | N0b B01 (HAX) |
| REF-03 | N0b B02 |
| REF-04 | N0b B04 |
| REF-05 | N0b B05, B06 |
| REF-06 | N0b B07 |
| REF-07 | N0b B14 |
| REF-08 | N0b B15, B16 |
| REF-09 | N0b B17 |
| REF-10 | N0b B18 |
| REF-11 | N1 F03 |
| REF-12 | N1 F04 (segunda URL), N6 F17 |
| REF-13 | N1 F13 |
| REF-14 | N1 F15 |
| REF-15 | N1 F18 |
| REF-16 | N1 F19 |
| REF-17 | N1b H01 |
| REF-18 | N1b H02 |
| REF-19 | N1b H03 |
| REF-20 | N1b H04 |
| REF-21 | N1b H06 |
| REF-22 | N1b H07 |
| REF-23 | N1b H08 |
| REF-24 | N1b H09 |
| REF-25 | N1b H10a |
| REF-26 | N1b H10b |
| REF-27 | N1b H10c |
| REF-28 | N1b H10d |
| REF-29 | N1b H11 |
| REF-30 | N1b H12 |
| REF-31 | N1b H13 |
| REF-32 | N1b H13b |
| REF-33 | N1b H13c |
| REF-34 | N1b H14 |
| REF-35 | N1b H15 |
| REF-36 | N1b H16 |
| REF-37 | N1b H17 |
| REF-38 | N1b H18; N4 E03 (cadenas de versión en la DLL y redirección de `latest`) |
| REF-39 | N1b H19 |
| REF-40 | N1b H20 |
| REF-41 | N1b H21 |
| REF-42 | N1b H22 |
| REF-43 | N1b H23, N2 F11, N4 F02 |
| REF-44 | N1 F04 (primera URL), N2 F1, N5 F04 |
| REF-45 | N1 F05, N2 F2, N5 F05, N6 F06 |
| REF-46 | N1 F14 |
| REF-47 | N1 F10, N2 F5, N6 F07 |
| REF-48 | N2 F3 |
| REF-49 | N2 F6 |
| REF-50 | N2 F7, N3 F24 |
| REF-51 | N2 F9; Sondeo §2, §3, §4 |
| REF-52 | Sondeo §2 |
| REF-53 | Sondeo §4 |
| REF-54 | N3b G16 |
| REF-55 | N3b G13, N5 F17 |
| REF-56 | N3b G13 (segunda URL), N5 F18 |
| REF-57 | N2 F8 |
| REF-58 | N2 F10 |
| REF-59 | N2 F13 |
| REF-60 | N2 F14 (primera URL) |
| REF-61 | N2 F14 (segunda URL) |
| REF-62 | N3b G4 |
| REF-63 | N3b G7, G7b |
| REF-64 | N3b G8 |
| REF-65 | N3b G9 |
| REF-66 | N3b G6 |
| REF-67 | N3b G1 |
| REF-68 | N3b G2 |
| REF-69 | N3b G5, N5 F16 |
| REF-70 | N3b G10 |
| REF-71 | N3b G11 |
| REF-72 | N3b G12 |
| REF-73 | N3b G14 |
| REF-74 | N3b G14b |
| REF-75 | N3b G15 |
| REF-76 | N3b G17 |
| REF-77 | N3b G18 |
| REF-78 | N3b G19 |
| REF-79 | N3b G20 |
| REF-80 | N3b G21 |
| REF-81 | N3b G22 |
| REF-82 | N3b G23 |
| REF-83 | N3b G24 |
| REF-84 | N3 F29, N5 F22 |
| REF-85 | N1 F01, N1b H05, N3 F28 |
| REF-86 | N1 F08, N3 F9, N6 F09 |
| REF-87 | N1 F06 |
| REF-88 | N1 F07, N2 F4, N3 F10 |
| REF-89 | N1 F09, N3 F2, N6 F10 |
| REF-90 | N3 F3 |
| REF-91 | N3 F4 |
| REF-92 | N3 F5 |
| REF-93 | N3 F6 |
| REF-94 | N3 F7 |
| REF-95 | N3 F8 |
| REF-96 | N3 F11 |
| REF-97 | N3 F12 |
| REF-98 | N3 F13 |
| REF-99 | N3 F14 |
| REF-100 | N3 F16 |
| REF-101 | N3 F17 |
| REF-102 | N3 F18; Sondeo §5 |
| REF-103 | N3 F19 |
| REF-104 | N3 F20 |
| REF-105 | N3 F21 |
| REF-106 | N3 F33 |
| REF-107 | N3 F22; Sondeo §5 |
| REF-108 | N3 F23; Sondeo §5 |
| REF-109 | N3 F26 |
| REF-110 | N3 F32 |
| REF-111 | N3 F30 |
| REF-112 | N3 F31 |
| REF-113 | N0b B08 |
| REF-114 | N0b B09 |
| REF-115 | N0b B03, N1 F02, N4 F21 |
| REF-116 | N1 F11 |
| REF-117 | N1 F17, N4 F01, N6 F08 |
| REF-118 | N1 F17b, N4 F23 (primera URL), N6 F11 |
| REF-119 | N4 F23 (segunda URL) |
| REF-120 | N1 F23 |
| REF-121 | N4 F04 |
| REF-122 | N4 F06, N6 F12 |
| REF-123 | N4 F22 |
| REF-124 | N4 F07 |
| REF-125 | N4 F08 |
| REF-126 | N4 F10 |
| REF-127 | N4 F09 |
| REF-128 | N4 F11 |
| REF-129 | N4 F12 |
| REF-130 | N4 F19, N6 F14 (segunda URL) |
| REF-131 | N6 F14 (primera URL) |
| REF-132 | N4 F20 |
| REF-133 | N6 F18 |
| REF-134 | N6 F18b |
| REF-135 | N6 F16 |
| REF-136 | N1 F22, N4 F03 |
| REF-137 | N2 F12, N4 F26 |
| REF-138 | N4 F24 |
| REF-139 | N4 F25 |
| REF-140 | N4 F29 |
| REF-141 | N4 F27; N4 E05 |
| REF-142 | N4 F13 |
| REF-143 | N4 F14 |
| REF-144 | N4 F15 |
| REF-145 | N4 F16 |
| REF-146 | N4 F17 |
| REF-147 | N4 F18; N4 E06 |
| REF-148 | N4 F32 (PyPI); N4 E06 |
| REF-149 | N4 F32 (npm); N4 E06 |
| REF-150 | N4 F28 |
| REF-151 | N3 F25, N5 F07 |
| REF-152 | N5 F08 |
| REF-153 | N5 F08b |
| REF-154 | N5 F12 |
| REF-155 | N0b B10 |
| REF-156 | N0b B11 |
| REF-157 | N0b B12 |
| REF-158 | N0b B13 |
| REF-159 | N6 F19 |
| REF-160 | N1 F16, N5 F13 |
| REF-161 | N5 F14 |
| REF-162 | N6 F13 |
| REF-163 | N3 F27 |
| REF-164 | N5 F15 (página oficial); N5 V10 (PDF oficial). Los tres sitios secundarios de N5 F15 no se citan |
| REF-165 | N5 F20 |
| REF-166 | N5 F21 |
| REF-167 | N5 F26 |
| REF-168 | N5 F01 (primera URL) |
| REF-169 | N5 F01 (segunda URL), F02, F03 |
| REF-170 | N5 F27 |
| REF-171 | N5 V8, V9 (verificación adversarial) |
| REF-172 | N5 F28 (primera URL) |
| REF-173 | N5 F06 |
| REF-174 | N5 F10 |
| REF-175 | N5 F11 |
| REF-176 | N5 F11b |
| REF-177 | N5 F28 (segunda URL) |
| REF-178 | N5 F23 |
| REF-179 | N5 F24 |
| REF-180 | N5 F25 |
| REF-181 | N5 F19 |
| REF-182 | N1 F12 |
| REF-183 | N1 F20 |
| REF-184 | N0b B19 |
| REF-185 | N0b B20 |
| REF-186 | N1 F21; N6 F01–F05 |
| REF-187 | N0b B-NuGet, N2 F15, N3 F1, N4 F30, N5 E0, N6 F15; I-01 E-PO-4; `Evidencia/Arnes/dep-02-versiones-nuget.txt` (2026-10-27) |
| REF-188 | N1b H24, N2 F15, N3 F1, F15, N4 F30, N5 E0, N6 F15 |
| REF-189 | N4 F32 (búsqueda NuGet); I-01 E-PO-3 |
| REF-190 | N1b H25, N3b G3 |
| REF-191 | N4 F31; N5 E0 (repo `semantic-conventions-genai`) |
| REF-192 | ninguno: verificada por la redacción de §5 (2026-10-27) |
| REF-193 | ninguno: verificada por la redacción de §12 (2026-10-27); el hallazgo venía de la mesa del ciclo 1 sobre la plantilla 13.6.4 |
| REF-194 | ninguno: verificada por la redacción de §12 (2026-10-27) |
| REF-195 | ninguno: verificada por la redacción de §12 (2026-10-27) |
| REF-196 | ninguno: verificada por la redacción de §11 (2026-10-27) |
| REF-197 | ninguno: verificada por la redacción de §11 (2026-10-27) |
| REF-198 | ninguno: verificada por la redacción de §11 (2026-10-27) |
| REF-199 | ninguno: verificada por la redacción de §11 (2026-10-27) |
| REF-200 | ninguno: verificada por la redacción de §14 (2026-10-27) |
| REF-201 | ninguno: verificada por la redacción del Anexo A (2026-10-27) |

**Fuentes de los dossiers que no entran al registro, con motivo.** Las que los propios dossiers declaran «vistas y no usadas como respaldo» (N0b: artículos de terceros sobre AI-102/AI-103 y el resumen de aigl.blog; N4: Visual Studio Magazine, InfoQ, atlan.com, blckalpaca.at y el espejo de mintlify); los tres sitios secundarios con nombres ASI de N5 F15 (giskard.ai, f5.com, promptfoo.dev), reemplazados por el PDF oficial; N1 F15 en su URL vieja, que redirige a otra referencia; N2 F14 en el espejo newreleases.io, que la verificación reemplazó; la página de NuGet de M.E.AI de N4 F05 (la versión sale de REF-187); `embeddinggemma` del sondeo (la guía no usa ese modelo); y las evidencias ejecutadas de cada dossier (E1–E7, V1–V11, X1–X4b), que no son referencias bibliográficas: la guía las cita como «medido en el laboratorio» con su registro, no con un REF.
