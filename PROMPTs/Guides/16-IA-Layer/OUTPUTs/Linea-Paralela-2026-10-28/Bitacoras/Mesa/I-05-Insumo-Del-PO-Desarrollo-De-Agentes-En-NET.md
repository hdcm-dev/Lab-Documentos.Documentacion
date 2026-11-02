# I-05 — Insumo del PO: borrador «Desarrollo de agentes de IA en .NET»

> **Tipo**: insumo para la mesa. El PO lo pegó el 2026-10-26.
> **Pieza**: borrador técnico de nueve secciones, sin autor ni fuentes. **No se transcribe**: sus ejemplos y su arquitectura de referencia provienen de **otro proyecto, privado y ajeno a esta guía** (aclaración del PO, 2026-10-26). De él se toman sólo las **ideas generales**, reformuladas acá sin ningún dato de ese proyecto.
> **Destinatarios**: especialistas de contenido, AH-01 (seguridad LLM), arquitectura y el plan de integración.
> **Núcleos afectados**: N4 (principal), N1, N2, N5, N6. Relación directa con [I-01](I-01-Insumos-Del-PO-Agentes-LangGraph-Anotaciones.md) (anotaciones).

---

## Índice

- [1. Clasificación y regla de no mezcla](#1-clasificación-y-regla-de-no-mezcla)
- [2. Ideas generales que aporta](#2-ideas-generales-que-aporta)
- [3. Contraste con la evidencia de los dossiers](#3-contraste-con-la-evidencia-de-los-dossiers)
- [4. Propuestas de la presidencia a la mesa](#4-propuestas-de-la-presidencia-a-la-mesa)
- [5. Lo que la mesa decide](#5-lo-que-la-mesa-decide)
- [6. Evidencia](#6-evidencia)

---

## 1. Clasificación y regla de no mezcla

- **Regla de no mezcla (PO, 2026-10-26, vinculante).** El dominio de los ejemplos que trae el borrador pertenece a otro proyecto privado del PO. **Nada de ese proyecto entra a la guía, a los ejemplos, a la demo ni a esta bitácora**: ni su dominio, ni su arquitectura, ni su stack concreto, ni sus nombres. **El único caso práctico de la guía es Movilidad Urbana** (Lab-E2E.WebBlazor). Toda idea de este insumo se ilustra **exclusivamente** con Movilidad Urbana.
- **Clasificación.** El borrador es material técnico **sujeto a verificación**, no fuente citable. Lo que coincide con fuentes primarias ya verificadas entra **citando la fuente primaria**; lo que contradice la evidencia se corrige; lo que no tiene fuente queda como criterio propio declarado o se descarta.

---

## 2. Ideas generales que aporta

| ID | Idea, reformulada sin datos del borrador | ¿Ya cubierta? | Cómo se ilustra con Movilidad Urbana |
|---|---|---|---|
| A-1 | **Principio rector**: el modelo decide qué herramienta *solicitar*; el código de la aplicación ejecuta la operación real y valida identidad, permisos y datos | En esencia sí: N4 G1 («el modelo pide, la app ejecuta») y N5 (OWASP). El borrador lo formula como principio, y eso es didácticamente valioso | Las herramientas son casos de uso de `Application` (p. ej. alta de localidad, consulta de resultados de la encuesta); las reglas de dominio (`LocalidadRules`, `EncuestaRules`) validan siempre, diga lo que diga el modelo |
| A-2 | **Incorporar la capa de IA a una aplicación existente**, no sólo en un proyecto nuevo: el agente entra detrás de la autenticación/autorización que la app ya tiene, usa herramientas tipadas sobre los servicios existentes y **no accede directo a la base** | Parcial: N6 diseña la demo, pero no la plantea como «sumar IA a una app que ya existe» | **MovilidadUrbana.ApiWeb ya es una app existente**: API REST `/api/v1` con aislamiento por sesión (`X-Sesion-Id`) y capas Domain/Application/Infrastructure. El escenario es agregarle la capa de IA sin reescribirla, propagando la sesión a cada herramienta |
| A-3 | **¿Usar un framework de agentes o construir uno propio?** Las anotaciones, por sí solas, no constituyen un runtime de agentes | No cubierta | Pregunta guía general; el inventario de lo que resuelven M.E.AI/MAF se muestra con las herramientas de Movilidad Urbana |
| A-4 | **Primer ejercicio chico**: un agente de una sola responsabilidad, con una o dos herramientas de **sólo lectura**, probado con errores, argumentos inválidos y permisos insuficientes | Coincide con I-02 PR-7 y con N4 («empezar simple»). Las **pruebas negativas** no estaban explícitas | Herramientas de sólo lectura sobre localidades y resultados de la encuesta; casos negativos: provincia fuera del catálogo, código postal mal formado, localidad inexistente, sesión ajena |
| A-5 | **Lista de seguridad para herramientas**: identidad en el servidor, autorización por operación, minimizar los datos que recibe cada herramienta, validar argumentos y resultados, registrar, confirmación humana para lo sensible, resistencia a instrucciones que llegan en documentos | Sí: N5 (OWASP LLM01, LLM06, `ApprovalRequiredAIFunction`). El borrador la ordena como lista, útil como anexo | La encuesta guarda `Nombre` y `Edad`: datos personales que una herramienta no debería devolver sin necesidad |
| A-6 | El **SDK de OpenAI para .NET** como opción sin framework, con control explícito del bucle | Parcial: N2 lo trata como proveedor detrás de `IChatClient` | Mismo ejemplo de chat de Movilidad Urbana, con el bucle de herramientas escrito a mano |

---

## 3. Contraste con la evidencia de los dossiers

| ID | Afirmación del borrador (en términos generales) | Veredicto | Evidencia |
|---|---|---|---|
| C-1 | Presenta **Semantic Kernel con `[KernelFunction]`** como el camino más relevante para exponer métodos C# con anotaciones | **Desactualizado como recomendación.** El README de SK presenta a Agent Framework como sucesor; Microsoft recomienda MAF para proyectos nuevos desde su GA (2026-04); la guía oficial de migración reemplaza `[KernelFunction]` por `[Description]` opcional con `AIFunctionFactory`. SK sigue vigente (1.81.0) para lo existente. La guía enseña primero `[Description]` + `AIFunctionFactory` y muestra `[KernelFunction]` como la forma anterior | N4 §2 y tabla de verificación; I-01 §4 |
| C-2 | Un plugin de ejemplo con `[KernelFunction]` + `[Description]` «no crea por sí solo un agente completo» | Correcto para SK. El ejemplo del borrador **no se usa**; la comparación se arma con una herramienta de Movilidad Urbana (PR-22) | N4 §2 |
| C-3 | MAF como framework de agentes y flujos; enlaces a la doc y al repo; «evaluar su API antes de decidir» | Correcto, con URLs vigentes. Omite que **ya es estable** (1.0 el 2026-04-02; hoy `Microsoft.Agents.AI` 1.26.0) | N4; E-PO-9 |
| C-4 | El SDK de OpenAI permite integrar sin framework de agentes | Correcto (`OpenAI` 2.14.0). Matiz: con un servidor compatible (el `/v1` de Ollama) sirve el mismo SDK, y se puede adaptar a `IChatClient` con `Microsoft.Extensions.AI.OpenAI` para no atar Application a un proveedor | N2 §2; E-PO-9 |
| C-5 | Tabla de conceptos: `[Description]`, `[KernelFunction]`, JSON Schema, DI, middleware, MCP, workflows, function calling | Correcta en general. Le faltan `AIFunctionFactory`/`AIFunction` (la pieza que convierte un método anotado en herramienta en M.E.AI/MAF) y `[MessageHandler]` (workflows) | N2, N4; I-01 |
| C-6 | El agente usa servicios de negocio, sin acceso directo e irrestricto a la base | **Se sostiene**; coincide con N6 y con OWASP (agencia excesiva) | N5, N6 |
| C-7 | Camino «framework propio» por atributos y convenciones | **Sin evidencia de costos ni casos**: entra como criterio propio declarado, junto al inventario verificable de lo que M.E.AI/MAF ya resuelven (`AIFunctionFactory`: descubrimiento por reflexión y esquema JSON; `FunctionInvokingChatClient`: bucle; middleware: políticas; aprobación humana; MCP) | N2, N4 |

---

## 4. Propuestas de la presidencia a la mesa

Continúan la numeración de I-02 a I-04. Todas se ilustran **sólo** con Movilidad Urbana.

| ID | Propuesta | Núcleo | Esfuerzo |
|---|---|---|---|
| PR-16 | Elevar a **principio rector** de la guía: «el modelo propone qué herramienta usar; la aplicación ejecuta, autoriza y valida». Que aparezca en el mapa conceptual y que cada ejemplo con herramientas lo muestre en el código | N1, N4, N5 | bajo |
| PR-17 | Escenario **«sumar la capa de IA a una aplicación existente»**, materializado en **MovilidadUrbana.ApiWeb**: la capa de IA se agrega sin reescribir la app, el agente queda detrás del aislamiento por sesión (`X-Sesion-Id`) y sus herramientas son los casos de uso existentes. Diagrama mermaid propio, basado en la ia-db de Lab-E2E | N1, N6 (marco N0: escenario nuevo o variante de ESC-04) | medio |
| PR-18 | Pregunta guía **«¿integrar un framework de agentes o construir uno propio?»**, con el inventario verificable de lo que ya resuelven M.E.AI y MAF y la conclusión «las anotaciones no son un runtime», declarada como criterio propio | N4 | medio |
| PR-19 | Cuadro comparativo **M.E.AI / MAF / Semantic Kernel / SDK de OpenAI directo**, con estado verificado y cuándo conviene cada uno. Se integra con el cuadro de familias de anotaciones de I-01 y con la comparación de métodos y marcos que pide el Profile | N2, N4 | bajo |
| PR-20 | **Primer ejercicio** (nivel básico de PR-3): agente de una sola responsabilidad con una o dos herramientas de **sólo lectura** sobre localidades y encuesta, con **pruebas negativas** (provincia fuera de catálogo, código postal inválido, localidad inexistente, sesión ajena). La sesión de Movilidad Urbana hace de identidad mínima para probar el aislamiento | N4, N6 | medio |
| PR-21 | Anexo **«lista de verificación de seguridad para herramientas de agentes»**, anclada en OWASP LLM Top 10 2025 (N5), con el caso de los datos personales de la encuesta (`Nombre`, `Edad`) | N5, anexos | bajo |
| PR-22 | Ejemplo pareado de anotaciones: **la misma herramienta de Movilidad Urbana** con `[KernelFunction]` (SK) y con `[Description]` + `AIFunctionFactory` (M.E.AI/MAF), compilados los dos, para mostrar la migración | Examples | bajo |

---

## 5. Lo que la mesa decide

1. Qué propuestas PR-16 a PR-22 se aplican.
2. Si PR-17 abre un escenario nuevo en el marco N0 o es una variante de ESC-04, y cómo entra a la demo sin ampliar demasiado su alcance.
3. La pregunta «¿integrar o construir un framework propio?» se trata como **pregunta guía para el lector** (PR-18). Construir un framework propio en la guía o en la demo sería **cambio de alcance** (M§6, disparador 3). Por defecto no se construye: se enseña a decidir.
4. Registrar lo que se descarta, con su motivo.

---

## 6. Evidencia

| ID | Comando | Resultado |
|---|---|---|
| E-PO-9 | `curl -L -w '%{http_code}'` a learn.microsoft.com/en-us/agent-framework/, github.com/microsoft/agent-framework, learn.microsoft.com/en-us/semantic-kernel/, github.com/openai/openai-dotnet; `api.nuget.org/v3-flatcontainer/openai/index.json` | 200 en las cuatro URLs; `OpenAI` última estable 2.14.0 (2026-10-26) |
| E-PO-10 | `grep -n "KernelFunction" Nucleos/N4-*.md` | N4:467 (MAF recomendado para proyectos nuevos tras la GA), N4:637 (migración `[KernelFunction]` → `[Description]` opcional, confirmada) |
