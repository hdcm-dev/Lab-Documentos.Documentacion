---
doc_id: BIT-16-C1R2-CON-definiciones
doc_type: consulta-dirigida
title: Consulta dirigida P-31 / D-7 — definición de agente, workflow, herramienta y orquestación
status: entregada
origin: agent
owner: Experto en IA + Edición bibliográfica (consulta dirigida de la presidencia)
last_review: 2026-10-28
audience: [jurado de la ronda 2, redacción de §7 y del Anexo C]
traces: [Mesa/Ciclo-1/07-Dictamen-Presidencia.md §3.3, Mesa/Ciclo-1/05-Aplicacion.md D-7, Mesa/Ciclo-1/06-Plan-De-Redaccion.md l. 52 y l. 295, Mesa/Ciclo-1/01-Consolidado.md C1-32 y C1-58, Mesa/Ciclo-1/Informe-edicion-bibliografica.md EDICIO-05 y §4.1, Nucleos/N1 §2.13, Nucleos/N4 §2.1, §2.2, §2.5, §2.9, §2.15, Nucleos/N6 §2, Nucleos/N0b D-07]
---

# Consulta dirigida P-31 / D-7: agente, workflow, herramienta y orquestación

Dictamen §3.3: las preguntas C se resuelven como consulta dirigida antes de votar. Esta consulta cierra la deuda **D-7** (`05-Aplicacion.md` l. 255: «§7 de la guía no se redacta sin ella») y la solicitud de EDICIO al Experto IA que quedó sin respuesta (`Informe-edicion-bibliografica.md` §4.1; `01-Consolidado.md` C1-32 y l. 700).

Evidencia cruda en `Ronda-2/evidencia-definiciones/`:

- `raw/`: texto de cada fuente bajado el 2026-10-28 (`fuentes-fechas.txt` con `ms.date` o `datePublished`/`dateModified`; `fuentes-sha256.txt` con el hash del HTML original).
- `E-DEF-1/`: experimento determinista (sin modelo), con `Program.cs`, `Definiciones.csproj` y `salida.txt` (comando y salida).

## 1. Fuentes vigentes consultadas (2026-10-28)

| Id local | Fuente | URL | Versión o fecha | Lo que se usa |
|---|---|---|---|---|
| D-F1 | Microsoft Agent Framework, *Overview* | https://learn.microsoft.com/en-us/agent-framework/overview/ | `ms.date` 2026-10-23 | Tabla «When to use agents vs workflows»; «If you can write a function to handle the task, do that instead of using an AI agent»; *Workflows*: «Functional and graph-based workflows that connect agents and functions through explicit execution paths» |
| D-F2 | MAF, *Workflows* (concepto) | https://learn.microsoft.com/en-us/agent-framework/concepts/workflows/ | `ms.date` 2026-07-30 | «define explicit, inspectable execution paths for coordinating code, agents, state, events, and human input»; .NET sólo `WorkflowBuilder`; «Compatible workflows can be exposed through the standard agent interface with `AsAIAgent()`» |
| D-F3 | MAF, *Agent concepts* | https://learn.microsoft.com/en-us/agent-framework/concepts/agents/ | `ms.date` 2026-09-24 | «An Agent Framework agent combines an agent abstraction, a model or remote-agent connection, instructions, tools, middleware, context providers, and session state behind a consistent run interface»; «All agent implementations share the `AIAgent` abstraction […] chat-client agents, custom agents, and remote-agent proxies» |
| D-F4 | MAF, *Agent Executor* | https://learn.microsoft.com/en-us/agent-framework/concepts/workflows/advanced/agent-executor | `ms.date` 2026-10-23 | «When you add an AI agent to a workflow, it needs to be wrapped in an executor»; `AIAgentHostExecutor`, `AgentWorkflowBuilder.BuildSequential` |
| D-F5 | MAF, *Workflow orchestrations* | https://learn.microsoft.com/en-us/agent-framework/workflows/orchestrations/ | `ms.date` 2026-02-12 | Handoff: «Agents transfer control to each other based on context»; Magentic: «A manager agent dynamically coordinates specialized agents» |
| D-F6 | MAF, *Looping* | https://learn.microsoft.com/en-us/agent-framework/agents/looping | `ms.date` 2026-07-30 | «Always bound autonomous loops»; `LoopAgent`, máximo por defecto 10 (experimental) |
| D-F7 | Anthropic, *Building effective agents* | https://www.anthropic.com/engineering/building-effective-agents (redirige a `/research/building-effective-agents`) | publicado 2024-12-19 (`datePublished`), firma «Erik S» y Barry Zhang | «Workflows are systems where LLMs and tools are orchestrated through predefined code paths. Agents […] are systems where LLMs dynamically direct their own processes and tool usage»; «typically just LLMs using tools based on environmental feedback in a loop»; «stopping conditions (such as a maximum number of iterations)»; el paraguas «agentic systems» |
| D-F8 | LangChain, *Workflows and agents* (LangGraph, Python) | https://docs.langchain.com/oss/python/langgraph/workflows-agents | `dateModified` 2026-10-28T14:17Z | «Workflows have predetermined code paths and are designed to operate in a certain order. Agents are dynamic and define their own processes and tool usage»; «Agents are typically implemented as an LLM performing actions using tools» |
| D-F9 | .NET AI, *Agents* (concepto) | https://learn.microsoft.com/en-us/dotnet/ai/conceptual/agents | `ms.date` 2025-12-10 | «Workflows define the sequence of steps required to achieve an objective»; «Workflows don't require agents»; «agentic workflows» (es el tercer sentido de *workflow*, ver P-31.3) |
| D-F10 | .NET AI, *AI tool calling* | https://learn.microsoft.com/en-us/dotnet/ai/conceptual/calling-tools | `ms.date` 2026-03-03 | «lets you describe available tools to an AI model so the model can request that your application invoke them»; «The model decides which functions, if any, to call»; «Continue invoking requested functions until the model provides a final response» |

**Deriva detectada respecto de los núcleos (E2):** N4 F01 registra la *Overview* con `ms.date` 2026-07-29, y hoy figura 2026-10-23. La página nueva suma «Harness Agent» como cuarta área y dice «Functional and graph-based workflows». Lo que afirma N4 §2.5 sigue valiendo para .NET, porque D-F2 dice que «Python additionally provides an experimental functional workflow API». Lo que cambia es la fila del catálogo REF, que tiene que llevar la fecha nueva.

## 2. Experimento E-DEF-1: quién decide el próximo paso

**Diseño.** No usa modelo (no hace falta R-LLM). Un `IChatClient` «guionado» hace de modelo y devuelve pedidos de herramienta en el orden que dicta un guion. Paquetes: `Microsoft.Agents.AI` 1.26.0, `Microsoft.Agents.AI.Workflows` 1.26.0, `Microsoft.Extensions.AI` 10.11.0. Se compiló y corrió en `mcr.microsoft.com/dotnet/sdk:10.0` (SDK 10.0.403) con el turno «build».

- **Parte 1.** Es el mismo código de agente (`AsAIAgent` con dos herramientas, `contar_encuestas` y `listar_localidades`), corrido con tres guiones del «modelo».
- **Parte 2.** Es un workflow de MAF (`AgentWorkflowBuilder.BuildSequential`) de dos pasos-agente, expuesto con `AsAIAgent()`.

**Salida** (`E-DEF-1/salida.txt`):

```
PARTE 1 - agente (AsAIAgent sobre IChatClient), mismo código:
  guion A: herramienta:contar_encuestas > herramienta:listar_localidades  | respuesta: listo (modelo)
  guion B: herramienta:listar_localidades > herramienta:contar_encuestas  | respuesta: listo (modelo)
  guion C:   | respuesta: listo (modelo)
PARTE 2 - workflow de MAF (BuildSequential) expuesto con AsAIAgent():
  tipo expuesto: WorkflowHostAgent es AIAgent = True
  codigo (paso1, paso2), corrida 1: modelo-llamado:paso-1 > modelo-llamado:paso-2
  codigo (paso1, paso2), corrida 2: modelo-llamado:paso-1 > modelo-llamado:paso-2
  codigo (paso2, paso1):            modelo-llamado:paso-2 > modelo-llamado:paso-1
```

**Lectura (E1):**

1. En el agente, con el código fijo, el orden de las herramientas (A frente a B) y hasta su uso (C: ninguna) los decide la salida del modelo.
2. En el workflow, el orden cambia sólo cuando cambia el código del grafo.
3. `AsAIAgent()` sobre un workflow devuelve un `WorkflowHostAgent`, que **es** un `AIAgent`. La interfaz es la misma, pero quien decide el orden no cambió.

La contradicción aparente entre N4 l. 70 y l. 104 es entonces una confusión entre **concepto** (quién decide) y **tipo de .NET** (qué interfaz se implementa).

## 3. Preguntas y respuestas

### P-31.1 — ¿Sigue siendo correcto «un agente no es un workflow» si MAF expone un workflow como `AIAgent`?

**Respuesta.** Sí, como afirmación sobre el concepto, y no, como afirmación sobre tipos.

- `AIAgent` es una **interfaz común de ejecución**: D-F3 dice que la implementan los chat-client agents, los custom agents y los «remote-agent proxies», y D-F2 dice que también los workflows compatibles.
- Que un workflow se presente como `AIAgent` no lo convierte en agente en el sentido de la guía. El orden de sus pasos sigue fijado por el grafo (E-DEF-1, parte 2).
- La frase de N4 §2.9 l. 104 queda bien si se reescribe así: «un workflow de MAF puede exponerse con la interfaz `AIAgent` mediante `AsAIAgent()`; quien lo llama no ve la diferencia, pero el orden de los pasos sigue en el grafo».

**Evidencia:** E1 (E-DEF-1) y E2 (N4 l. 70 frente a l. 104; D-F2, D-F3).

### P-31.2 — ¿Qué definición de agente adopta la guía (N1 §2.13, N4 §2.2 o N6 §2)?

**Respuesta.** Ninguna de las tres tal como está. La guía adopta una definición **por quién decide el próximo paso**, que es la que comparten D-F7 (Anthropic), D-F8 (LangGraph) y la tabla de D-F1 (MAF). Las de N4 §2.2 y N6 §2 pasan a ser la entrada calificada «agente de MAF (`AIAgent`)».

- **N1 §2.13** («LLM + herramientas + bucle + estado/memoria») acierta en tres elementos, pero mete *estado/memoria* como condición definitoria. Ninguna de las fuentes la exige. Anthropic dice «typically just LLMs using tools based on environmental feedback in a loop» (D-F7), y la memoria aparece en el *augmented LLM*, que es el bloque base, no el agente. En MAF la sesión es una **pieza** que se combina (D-F3), y el agente mínimo de E-DEF-1 funciona sin memoria entre conversaciones. Falta además la **condición de corte**, que las tres familias de fuentes piden (D-F6, D-F7; `MaximumIterationsPerRequest` en N4 §2.1).
- **N4 §2.2** y **N6 §2** definen el componente de MAF, no el concepto. Sirven como entrada calificada.
- **Consecuencia conceptual:** el bucle de `FunctionInvokingChatClient` ya es un agente en el sentido de la guía, porque el modelo decide qué herramientas pedir y cuándo terminar (D-F10; E-DEF-1, guiones A, B y C). `AsAIAgent` le suma sesión, aprobación integrada y la interfaz común (N4 §2.2–§2.4). Por eso N4 §2.1 «no es un agente por sí mismo» se precisa así: «un pedido de herramienta aislado no es un agente; el bucle que devuelve resultados hasta que el modelo termina, sí».

**Evidencia:** E1 (E-DEF-1) y E2 (N1 l. 154, N4 l. 66–73, N6 l. 146; D-F1, D-F3, D-F6, D-F7, D-F8, D-F10).

### P-31.3 — ¿Qué es *workflow* en la guía, si hay tres sentidos en las fuentes?

**Respuesta.** Las fuentes vigentes usan tres sentidos:

| Sentido | Fuente | Qué nombra |
|---|---|---|
| (a) camino fijado por código | D-F7, D-F8, tabla de D-F1 | arquitectura opuesta a agente: el código decide el orden |
| (b) workflow de MAF | D-F2, D-F4, D-F5 | API de grafo (`WorkflowBuilder`, executors, aristas, supersteps) que puede tener **agentes como nodos** y, en handoff, group chat o Magentic, delegar en un modelo la elección del siguiente paso |
| (c) proceso de negocio | D-F9 | «the sequence of steps required to achieve an objective», con «agentic workflows» como agentes dentro del proceso |

La guía adopta **(a)** como *workflow* a secas y **(b)** siempre calificado como «workflow de MAF». El sentido (c) se nombra «proceso» y la expresión «agentic workflow» no se usa.

Fundamentos:

- (a) es el sentido del criterio central del Profile («cuándo **no** usar agentes», N4 G7; N0b D-07). Lo usan las tres familias de fuentes, incluida la propia MAF en su tabla de D-F1.
- (b) no es siempre (a). En handoff y Magentic quien elige el siguiente agente es un modelo (D-F5), así que un workflow de MAF puede ser agéntico en su propio nivel. Llamarlo *workflow* a secas reabre la contradicción de EDICIO-05.

**Diferencia con la propuesta de EDICIO-05.** EDICIO proponía reservar *workflow* para el grafo de MAF y llamar «flujo fijo» al sentido de Anthropic. Recomiendo lo contrario por tres razones:

1. Dejar *workflow* para el grafo pierde la palabra que usan Anthropic, LangGraph y la tabla de MAF justo para la decisión que la guía enseña.
2. C5 lista «workflow» como término del glosario (REED-16 l. 363).
3. D-07 ya dice «workflow de MAF» (N0b l. 295).

Es materia de opción y la decide el jurado (dictamen §3.4). La alternativa de EDICIO queda abajo como opción B.

**Evidencia:** E2 (D-F1, D-F2, D-F5, D-F7, D-F8, D-F9; EDICIO-05; REED-16 l. 363; N0b l. 295). La elección del término es **[criterio propio]**.

### P-31.4 — ¿Cómo se relacionan con *herramienta* y *orquestación*?

**Respuesta.**

- **Herramienta** es lo que el modelo puede **pedir** y la aplicación **ejecuta** (D-F10). Es el mecanismo mínimo sin el que no hay agente.
- **Orquestación** es la decisión de **qué paso sigue y cuándo se termina**. Se resuelve de dos maneras, y esas dos maneras **son** la distinción entre agente y workflow: la decide el modelo (agente) o la decide el código (workflow).
- La distinción vale **por nivel** y los niveles se anidan. Un workflow puede tener agentes como pasos (D-F4, E-DEF-1 parte 2). Un workflow de MAF puede delegar la elección del siguiente paso en un modelo (D-F5). Un workflow puede presentarse con la interfaz de un agente (D-F2, E-DEF-1).
- **MCP no es un cuarto nivel de orquestación**: es el transporte estándar de herramientas entre procesos (N4 §2.14, «Qué no es»; `McpClientTool` hereda de `AIFunction`). Esto afecta el eje de MI-10 (C1-58).
- «Nivel de orquestación» (D-07) es el escalón elegido entre llamada única, agente mínimo, agente de MAF, workflow de MAF y orquestación multiagente.

**Evidencia:** E1 (E-DEF-1) y E2 (D-F2, D-F4, D-F5, D-F10; N4 §2.14; N0b D-07).

### P-31.5 — Texto exacto del glosario (Anexo C) y frase de §7

**Respuesta.** El texto propuesto está en §4 (opción A, recomendada) con la variante de EDICIO (opción B). La frase de §7 está en §5. Usan el molde único del Profile (qué es / qué problema resuelve / qué no es), con sentidos excluidos y su reemplazo (EDICIO-05). Los ids `D-Fn` de esta consulta no entran a la guía: en la guía van como `REF-nnn` (P-31, RV-08).

**Evidencia:** E2 y E1 (los mismos que P-31.1 a P-31.4).

## 4. Texto propuesto para el Anexo C (opción A, recomendada)

> **Agente.**
> *Qué es:* un sistema en el que el modelo decide, en un bucle, qué herramienta pedir a continuación y cuándo terminar, a partir de los resultados que la aplicación le devuelve. La aplicación ejecuta cada pedido y fija un límite de iteraciones.
> *Qué problema resuelve:* tareas abiertas o conversacionales cuyos pasos no se conocen de antemano.
> *Qué no es:*
> - No es cualquier llamada a un modelo.
> - No es un workflow.
> - No exige memoria entre conversaciones.
> - No es lo mismo que el tipo `AIAgent`, que es una interfaz que también implementan los workflows de MAF.
>
> *En .NET:* el agente mínimo es un `IChatClient` con `UseFunctionInvocation()`. El agente de MAF (`AsAIAgent`) le suma sesión, aprobación de herramientas y la interfaz `AIAgent`.
> *Sentidos excluidos:* el tipo de MAF se escribe «agente de MAF (`AIAgent`)»; «agéntico» no se usa como sinónimo.

> **Workflow.**
> *Qué es:* un sistema que usa un modelo en al menos un paso y en el que el código fija de antemano el orden de los pasos (llamadas al modelo, herramientas, funciones o agentes) y cuándo termina. El modelo produce el contenido de un paso, pero no elige el siguiente.
> *Qué problema resuelve:* procesos con pasos conocidos, donde importan el orden explícito, la auditoría y la pausa y reanudación.
> *Qué no es:* no es un agente. Tampoco es sinónimo de «workflow de MAF». Sin ningún paso con modelo, no es un workflow: es código.
> *Sentidos excluidos:* la API de grafo se escribe «workflow de MAF». La secuencia de pasos de negocio se escribe «proceso». «Agentic workflow» y «flujo agéntico» no se usan.

> **Workflow de MAF.**
> *Qué es:* un grafo dirigido de *executors* unidos por aristas, armado con `WorkflowBuilder`. En .NET existe sólo la API de grafo. Se ejecuta por supersteps con checkpoints en sus bordes. Puede tener agentes como nodos (los envuelve un executor de agente) y puede exponerse con la interfaz `AIAgent` mediante `AsAIAgent()`.
> *Qué problema resuelve:* implementar workflows con estado, pausa con intervención humana (`RequestPort`) y reanudación.
> *Qué no es:* no siempre es un workflow en el sentido de esta guía. En las orquestaciones *handoff*, *group chat* y *Magentic*, quien elige el siguiente paso es un modelo, así que a ese nivel la orquestación es de agente.

> **Herramienta.**
> *Qué es:* una función de la aplicación descrita al modelo por nombre, descripción y esquema de parámetros. El modelo puede pedir que se invoque, y la aplicación la ejecuta y le devuelve el resultado.
> *Qué problema resuelve:* darle al modelo datos y acciones del sistema, como los casos de uso, sin que los invente ni toque el sistema directamente.
> *Qué no es:* el modelo no la ejecuta, y una herramienta sola no es un agente.
> *En .NET:* `AIFunction`. Las que llegan por MCP son `McpClientTool`, que hereda de `AIFunction`.
> *Sentidos excluidos:* el mecanismo se escribe «llamada a herramientas (*tool calling*)» en la primera aparición y después «llamada a herramientas». «Function calling» va sólo entre paréntesis, como sinónimo de las fuentes.

> **Orquestación.**
> *Qué es:* la decisión de qué paso sigue (una llamada al modelo, una herramienta, una función o un agente) y cuándo se termina. La toma el modelo (agente) o el código (workflow). Las dos formas se anidan por niveles.
> *Qué problema resuelve:* nombrar qué parte del sistema controla el orden, y por lo tanto dónde van los límites, la auditoría y la aprobación.
> *Qué no es:* no es un producto ni un tipo. «Orquestación multiagente» es un workflow de MAF con agentes como pasos. El «nivel de orquestación» (D-07) es el escalón elegido entre llamada única, agente mínimo, agente de MAF, workflow de MAF y orquestación multiagente.

**Opción B (EDICIO-05).** *Workflow* nombra sólo el grafo de MAF, y el sentido (a) pasa a «flujo fijo». Con B hay que reescribir la entrada «Workflow» de arriba como «Flujo fijo» y las referencias de N0b D-07, N1 §2.13 y N4 §2.15. Además, la tabla «agents vs workflows» de MAF y el texto de Anthropic y LangGraph quedan citados con una palabra distinta de la que usa la guía. Por eso no la recomiendo.

## 5. Frase propuesta para §7

> En esta sección, *agente* y *workflow* no nombran productos, sino quién decide el próximo paso. En un agente lo elige el modelo, dentro de un límite que pone el código. En un workflow lo fija el código. Las dos formas se anidan: un workflow puede tener agentes como pasos, y Agent Framework puede exponer un workflow con la misma interfaz `AIAgent` que un agente. Quien lo llama no ve la diferencia, pero el orden de los pasos sigue escrito en el grafo. Antes de elegir cualquiera de los dos vale la regla de Microsoft: si podés escribir la función, escribila.

Fuentes para la redacción: D-F1 (regla «If you can write a function…» y tabla), D-F2 (`AsAIAgent()`), D-F4 (agentes como nodos), D-F7 y D-F8 (la distinción) y E-DEF-1 como ejemplo reproducible, que puede alojarse en `Examples/10-Workflow` si el jurado lo quiere ejecutable.

## 6. Consecuencias para los ítems del jurado

| Ítem | Consecuencia |
|---|---|
| **C1-32 / P-31 (Anexo C)** | La deuda D-7 queda respondida con el texto de §4. Se vota la **opción A o la B** (dictamen §3.4). El chequeo C5 suma `grep` de los sentidos excluidos: `agentic workflow`, `flujo agéntico`, `flujo de trabajo`, «workflow» junto a `WorkflowBuilder` sin «de MAF», y «agente» junto a `AIAgent` sin «de MAF». |
| **C1-58 / MI-10 (eje por mecanismo)** | El eje «herramienta → agente → workflow → MCP» mezcla niveles de orquestación con un transporte. Propuesta compatible: «herramienta → agente → workflow (de MAF), y MCP como transporte de herramientas», en línea con N4 §2.14 y con la condición de Arquitectura (MCP como adaptador de entrada, C1-16). La condición de Edición en C1-58 («antes, resolver el doble sentido de workflow») queda cumplida con esta consulta. |
| **N0b D-07 (nivel de orquestación)** | Las alternativas se nombran «llamada única → agente mínimo (`IChatClient` + `UseFunctionInvocation`) → agente de MAF (`AsAIAgent`) → workflow de MAF → orquestación multiagente». La decisión no cambia. CASO-8 (la encuesta de tres pasos) se queda como **código** (un proceso sin modelo), y es contraejemplo de «workflow de MAF». No es un workflow en el sentido de la guía, porque no tiene pasos con modelo. |
| **N4 §2.1, §2.2, §2.5, §2.9** | Para la redacción, no in situ, porque la bitácora es sólo agregado. §2.1: «un pedido aislado no es un agente; el bucle sí». §2.2 pasa a «Agente de MAF (`AIAgent`)». §2.5 pasa a «Workflow de MAF». §2.9 se reescribe como en P-31.1. |
| **N1 §2.13** | Sale «estado/memoria» como elemento definitorio y entra «condición de corte». La sesión pasa a «pieza que MAF suma» (D-F3). |
| **N6 §2 «Agente»** | Se renombra «Agente de MAF». El *qué no es* se mantiene. |
| **Catálogo REF (EDICIO-04)** | La fila de la *Overview* de MAF se actualiza a `ms.date` 2026-10-23 (antes 2026-07-29). Entran D-F3, D-F4, D-F5, D-F6, D-F9 y D-F10 con sus fechas de §1. La de Anthropic conserva 2024-12-19 y anota la URL canónica `/research/`. |
| **§7 de la guía (plan l. 122–129, l. 295)** | Queda desbloqueada: la frase de §5 abre la sección y la distinción organiza el recorrido por mecanismo. |

## 7. Límites

- Se consultó la página Python de LangGraph (D-F8), porque no hay SDK oficial para .NET (N4 §2.13). La distinción no depende del lenguaje.
- No se corrió un R-LLM: la definición no depende de cómo se comporte un modelo concreto, y E-DEF-1 aísla justamente quién decide el orden. Si el jurado lo pide, la misma parte 1 corre con `qwen3.5:4b` cambiando sólo el `IChatClient`.
- «Agente de MAF», «workflow de MAF», «agente mínimo» y «proceso» como reemplazos son **[criterio propio]** editorial, fundado en las fuentes de §1.
