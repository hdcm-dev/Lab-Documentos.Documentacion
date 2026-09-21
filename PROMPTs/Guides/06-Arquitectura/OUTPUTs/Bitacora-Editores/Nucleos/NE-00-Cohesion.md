# NE-00 — Cohesión de los núcleos de la reedición

**Fecha:** 2026-09-19 · **Pedido:** `02-Edición-Arquitecture-Guide.md` · **Objeto:** guía v2.0.2 @ dbdf9dd

La descomposición se hace sobre el **pedido**, no sobre la guía: la guía ya está segmentada en núcleos NC-01…NC-10 (`OUTPUTs/Nucleos/`) desde la v2.0.1, y esa segmentación sigue vigente. El pedido de reedición agrupa cinco ideas con dependencia fuerte entre sí:

| Núcleo | Idea del pedido | Depende de | Alimenta a |
|---|---|---|---|
| NE-01 Materialización | «definición, explicación, snippet, asociación del código con las definiciones y los conceptos; no quedarse en la alegoría» | NC-03 (objetos por capa), NC-04, NC-05 | NE-02, NE-05 |
| NE-02 Criterio | «preguntas guía acompañadas de respuestas explicativas formadoras de criterio: en qué caso aplica cada concepto» | NE-01 (una pregunta de criterio se responde con código) | NE-04 |
| NE-03 Fidelidad | «no inventar; toda afirmación con evidencia» + comisión Fowler: fidelidad de los patrones a su fuente | NC-10, Anexo E | NE-01 (un snippet que contradice la fuente no materializa el concepto: lo deforma) |
| NE-04 Forma | «secciones jerárquicas con índices; mermaid cuando haga falta; autocontenido, no delta» | Rule-Markdown, Rule-Dual-Audience, Rule-Narrative-Voice | Integración |
| NE-05 Compilabilidad | Todo snippet nuevo mostrado como `[Compilado]` compila con SDK 10.0.400 y deja captura; lo demás se marca ilustrativo | §0.5 de la guía; `Examples/…/Variantes/` | NE-01 (sin esto la materialización es alegoría con sintaxis de C#) |

## Relaciones y contradicciones previsibles

- **NE-01 ↔ NE-04:** materializar cada definición con un snippet engorda las secciones «Definiciones». Regla de resolución: el snippet de una definición es **mínimo (3–8 líneas)** y apunta con `[Compilado: ruta]` al archivo completo; la explicación larga sigue en la sección temática.
- **NE-01 ↔ NE-05:** un snippet nuevo que no se compila entra como `[Fragmento ilustrativo: motivo]`; se prefiere derivarlo de un archivo existente del laboratorio o de `Variantes/` para que sea `[Compilado]`.
- **NE-03 ↔ NE-01:** si el ejemplo más claro contradice la fuente (p. ej. un Repository con lógica de negocio «para simplificar»), gana la fuente; el ejemplo se rehace.
- **NE-02 ↔ NE-04:** las preguntas guía intermedias se agregan sólo en secciones con más de un concepto decisorio; no se agrega una por sección para cumplir con la forma.

## Trazabilidad a las comisiones

| Comisión | Núcleos que juzga | No le corresponde |
|---|---|---|
| Editor de libros técnicos | NE-04, NE-01 (forma de la asociación) | Fidelidad de patrones, corrección de C# |
| Académico en pedagogía | NE-02, NE-01 (progresión y carga cognitiva) | Corrección técnica, forma editorial |
| Martin Fowler (personificado) | NE-03, NE-01 (que el código encarne el patrón) | Forma editorial, pedagogía |
| Especialista .NET/C# | NE-05, NE-01 (idiomaticidad, compilación) | Fidelidad histórica de los patrones, pedagogía |
| Refutador | Todos, por aplicación | — |

## Integración

Después del ciclo 1 y la refutación, el presidente consolida raíces comunes por núcleo (`02-Ciclo1-Consolidacion.md`), el plan de parches se ordena por núcleo (NE-05 antes de NE-01: primero se compila, después se cita), y la verificación se hace por documento entero (filtro «la unidad de aplicación es el documento»).
