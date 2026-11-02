# I-01 — Insumos del PO: LangGraph en .NET, el cruce con Microsoft Graph y los agentes con anotaciones

> **Tipo**: insumo para la mesa (conversación de la presidencia con el PO, 2026-10-26).
> **Destinatarios**: especialistas de contenido (IA, senior .NET, arquitectura, didáctica, edición bibliográfica) y el plan de integración.
> **Pedido del PO**: que los especialistas de contenido tomen estos tres temas y **estructuren con ellos el marco conceptual** que la guía tiene que desarrollar. La mesa decide la estructura; este documento aporta las preguntas y la evidencia, no la estructura final.
> **Núcleos afectados**: N4 (principal), N2, N1 (mapa conceptual), N6 (demo), N0 (escenarios ESC-04 y ESC-05).

---

## Índice

- [1. Las tres preguntas del PO](#1-las-tres-preguntas-del-po)
- [2. Pregunta 1: ¿existe un LangGraph oficial para .NET?](#2-pregunta-1-existe-un-langgraph-oficial-para-net)
- [3. Pregunta 2: el resumen de Google que mezcla «GraphLang» y Microsoft Graph](#3-pregunta-2-el-resumen-de-google-que-mezcla-graphlang-y-microsoft-graph)
- [4. Pregunta 3: ¿qué hay para crear agentes con anotaciones en .NET?](#4-pregunta-3-qué-hay-para-crear-agentes-con-anotaciones-en-net)
- [5. Lo que se le pide a la mesa](#5-lo-que-se-le-pide-a-la-mesa)
- [6. Evidencia](#6-evidencia)

---

## 1. Las tres preguntas del PO

| ID | Pregunta, en palabras del PO | Qué revela para la guía |
|---|---|---|
| Q-PO-1 | «¿Segura que no existe un LangGraph oficial para .NET? ¿O algo parecido?» | El lector llega con el nombre LangGraph y busca su equivalente. La guía tiene que contestar la pregunta tal como la trae el lector, no sólo presentar lo que existe en .NET |
| Q-PO-2 | Trae un resumen de Google: «GraphLang en .NET suele hacer referencia a […] Microsoft Graph SDK para .NET o la adaptación de […] LangGraph en el ecosistema .NET» | El lector va a encontrar respuestas de buscador que mezclan productos sin relación. La guía tiene que anticipar esa confusión |
| Q-PO-3 | «¿Qué es lo que hay para crear agentes con anotaciones en .NET?» | El lector piensa en un modelo por atributos, como en otros frameworks. La guía tiene que mostrar qué se anota y qué no |

---

## 2. Pregunta 1: ¿existe un LangGraph oficial para .NET?

**Respuesta verificada: no.** El dossier N4 §2.13, ya verificado de forma adversarial, lo había concluido. La presidencia lo volvió a medir de forma independiente el 2026-10-26 (§6, E-PO-1 y E-PO-2):

- LangGraph es de LangChain Inc. y se publica sólo para Python (`langgraph` 1.2.17) y JS/TS (`@langchain/langgraph` 1.5.2).
- NuGet: la búsqueda «langgraph» da 6 paquetes, todos de autores individuales: `LangGraph.Agent.Templates`, `SemanticKernel.Graph`, `Flowgine`, `Nexttag.Ai.Graph`, `RunAgent` y `HexaEight.Activate`. LangChain no tiene ningún paquete publicado en NuGet.
- La organización `langchain-ai` en GitHub tiene 267 repositorios y ninguno es un SDK ni un port para .NET. El único escrito en C# es un acelerador de facturación de Azure Marketplace, archivado.

**«Algo parecido» sí existe, por tres vías distintas:**

| Vía | Qué es | Relación con LangGraph |
|---|---|---|
| Workflows de Microsoft Agent Framework (`Microsoft.Agents.AI.Workflows` 1.26.0, estable) | Grafo con estado: executors y aristas condicionales, fan-out/fan-in, supersteps al estilo Pregel, checkpoints, human-in-the-loop y orquestaciones ya armadas | Equivalente funcional: mismo modelo, otro proveedor (Microsoft, no LangChain). Que «es el LangGraph de .NET» es **criterio propio**, y se declara como tal |
| Consumir LangGraph por HTTP | El grafo corre en Python (`langgraph dev`, o LangSmith Deployment, ex LangGraph Platform) y .NET lo llama por la API REST (threads, runs) con `HttpClient` | Es LangGraph real, pero no hay cliente .NET oficial |
| Ports y paquetes de la comunidad | LangChain .NET (tryAGI, sin componente de grafo), `SharpGraph` («LangGraph for .NET», 3 estrellas), los paquetes de NuGet de arriba | No son oficiales; no se evaluó ni su calidad ni su mantenimiento |

> **2026-10-28 — Parche P-26 (ciclo 1):** la frase "mismo modelo" se corrige en N4 y en la guía; ver BIT-16-04 tensión 5.


---

## 3. Pregunta 2: el resumen de Google que mezcla «GraphLang» y Microsoft Graph

| Elemento del resumen | Qué es en realidad | Evidencia |
|---|---|---|
| «GraphLang» | No existe como producto ni como paquete. Parece «LangGraph» con las palabras invertidas | NuGet `q=graphlang` → 0 resultados (E-PO-3) |
| «Microsoft Graph SDK para .NET» | `Microsoft.Graph` 6.9.0: el cliente para llamar a Office 365, Azure AD y otros servicios de Microsoft (correos, usuarios, calendarios). «Graph» es el grafo de datos de Microsoft 365. **No tiene relación con IA ni con agentes** | Descripción del `.nuspec` en NuGet: «Microsoft Graph Client Library allows you to call Office 365, Azure AD and other Microsoft services…» (E-PO-4) |
| «La adaptación de LangGraph en el ecosistema .NET» | Son las vías de la tabla del §2: adaptaciones de la comunidad o el equivalente de Microsoft. No es un port de LangChain | §2 |

**Lectura para la guía**: es una confusión que el lector va a tener. Tiene sentido una aclaración explícita que separe LangGraph, los workflows de Agent Framework y Microsoft Graph (lugar y forma: los decide la mesa). Una sola aclaración evita que el lector instale `Microsoft.Graph` creyendo que orquesta agentes.

---

## 4. Pregunta 3: ¿qué hay para crear agentes con anotaciones en .NET?

**Respuesta**: en .NET el agente se construye por código (o se declara en YAML); los atributos de C# marcan **las piezas**, no al agente. No existe un atributo `[Agent]` que convierta una clase en agente. Hay cuatro familias de anotaciones:

| Familia | Atributos | Qué marcan | Estado | Fuente |
|---|---|---|---|---|
| Microsoft.Extensions.AI y Agent Framework | `[Description]` (`System.ComponentModel`) en el método y en sus parámetros | Herramientas: `AIFunctionFactory.Create` arma con eso el esquema JSON que recibe el modelo; `chatClient.AsAIAgent(instructions, tools: [...])` crea el agente | Vigente (M.E.AI 10.11.0, MAF 1.26.0) | N4 §4, N2 |
| Semantic Kernel | `[KernelFunction]` + `[Description]` | Funciones de plugins | Anterior. La guía oficial de migración a Agent Framework pasa de `[KernelFunction]` a `[Description]` opcional. SK sigue recibiendo versiones (1.81.0) | N4 §2, tabla de verificación |
| Workflows de Agent Framework | `[MessageHandler]` en una clase `partial` derivada de `Executor` | Los nodos del grafo y los mensajes tipados que manejan | Vigente. **Trampa verificada**: necesita el paquete `Microsoft.Agents.AI.Workflows.Generators` (generador de código fuente); sin él, la compilación falla con `CS0534`, y la documentación oficial no lo nombra | N4 §2, E02/V01 |
| MCP (`ModelContextProtocol`) | `[McpServerToolType]`/`[McpServerTool]`, `[McpServerPromptType]`/`[McpServerPrompt]`, `[McpServerResourceType]`/`[McpServerResource]` | Herramientas, prompts y recursos que se exponen a agentes **externos** | Vigente | N4 §4; árbol del repo `modelcontextprotocol/csharp-sdk` (E-PO-5) |

Complementos que no son anotaciones, pero sirven para la comparación:

- `ApprovalRequiredAIFunction`, que envuelve una herramienta sensible para pedir aprobación humana.
- `Microsoft.Agents.AI.Workflows.Declarative`, que define agentes y workflows en YAML (estable desde la 1.9.0).

---

## 5. Lo que se le pide a la mesa

Los especialistas de contenido deliberan y deciden, con evidencia:

1. **Estructura del marco conceptual de N4 (y su reflejo en el mapa conceptual de N1).** Hay que ubicar en un modelo único y estable:
   - **las formas de construir un agente en .NET**: por código, con herramientas anotadas, como grafo (workflow) y en forma declarativa (YAML);
   - **los ecosistemas**: Microsoft (M.E.AI → Agent Framework, con SK como antecesor), LangChain (LangGraph, fuera de .NET) y la comunidad;
   - **el papel de las anotaciones** en cada uno.

   La mesa elige el eje de organización: por mecanismo, por ecosistema o por escenario del marco N0. Tiene que fundamentar la elección con criterio didáctico.
2. **Una pregunta guía por cada pregunta del PO (Q-PO-1 a Q-PO-3)**, con respuesta explicativa que forme criterio: cuándo conviene cada vía, y qué no es lo que parece.
3. **Un cuadro comparativo de las familias de anotaciones** (§4) con el criterio de elección, y la aclaración de nombres (§3).
4. **Si la demo y los ejemplos cubren lo necesario**: la familia 1 (casos de uso como herramientas) y la 4 (servidor MCP) ya están en el diseño de N6. La mesa evalúa si hace falta un ejemplo de workflow con `[MessageHandler]` (incluida la trampa del generador) y uno de consumo de LangGraph por HTTP. Este último se marcaría como no ejecutado, salvo que se levante un servidor LangGraph local.
5. Registrar cualquier apartamiento respecto de esta propuesta, con su motivo.

---

## 6. Evidencia

Medida por la presidencia el 2026-10-26, independiente de la verificación de N4:

| ID | Comando | Resultado |
|---|---|---|
| E-PO-1 | `curl "https://azuresearch-usnc.nuget.org/query?q=langgraph&prerelease=true&take=50"` | `totalHits 6`: LangGraph.Agent.Templates 1.0.0 (Prasanna Ruwangana), SemanticKernel.Graph 25.10.301 (Kallebe Lins), Flowgine 0.2.1, Nexttag.Ai.Graph 0.3.0 (Jonathan Schenker), RunAgent 0.1.48, HexaEight.Activate 1.0.81. Con `q=owner:langchain`: `totalHits 0` |
| E-PO-2 | `curl "https://api.github.com/orgs/langchain-ai/repos?per_page=100&page={1,2,3}"` | 267 repos. Con lenguaje C# o con dotnet/csharp/net en el nombre: `LangChain-Commercial-Marketplace-Meters-Accelerator` (C#, archivado) y `net-mocks` (TypeScript) |
| E-PO-3 | NuGet `q=graphlang`, `q=langgraphsharp`, `q=langgraph.net` | 0, 0 y 2 (Flowgine, Nexttag.Ai.Graph) |
| E-PO-4 | `curl https://api.nuget.org/v3-flatcontainer/microsoft.graph/6.9.0/microsoft.graph.nuspec` | `<description>Microsoft Graph Client Library allows you to call Office 365, Azure AD and other Microsoft services through a single unified developer experience.` |
| E-PO-5 | `curl "https://api.github.com/repos/modelcontextprotocol/csharp-sdk/git/trees/main?recursive=1"` | En `src/ModelContextProtocol.Core/Server/` están `McpServerToolAttribute`, `McpServerToolTypeAttribute`, `McpServerPromptAttribute`, `McpServerPromptTypeAttribute`, `McpServerResourceAttribute`, `McpServerResourceTypeAttribute` (además de `McpHeaderAttribute` y `McpMetaAttribute`) |
| E-PO-6 | `curl https://api.nuget.org/v3-flatcontainer/microsoft.agents.ai.workflows/index.json` | Últimas estables: 1.24.0, 1.25.0, **1.26.0** |
