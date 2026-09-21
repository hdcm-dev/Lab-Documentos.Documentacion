# Bitácora de editores 00 — Contrato de entrada de la mesa

**Fecha:** 2026-09-19
**Presidente:** el agente que recibió el pedido (no vota)
**Norma de forma:** `IA.SDD/Conocimiento/Knowledge-Mesa-De-Expertos-A-Pedido.md` 1.2, §5.1
**Prompt de origen:** `PROMPTs/Guides/06-Arquitectura/02-Edición-Arquitecture-Guide.md`

```text
PEDIDO (literal, 2026-09-19, Product Owner, canal: conversación de Claude Code):
«hacé una mesa con espacialistas variso, un editor de libros, un academico relacionado con
pedagoai, podes traer a un agente que personifique a martin fowler, y alguien especialista en
.net c#, en la que tomaria a `LAB/Lab-Documentos/Guides/Arquitectura/Dot-NET-Arquitectura-Guide.md`
y lo reeditaria, agregaría ejemplos claros con snipped de código que haya definiciones,
explicacion, snipped , asociación del código con las definiciones y los conceptos, no me
quedaría solo en la alegoría iría en la materialización del concepto mediante el código,»
+ Reglas del prompt (secciones jerárquicas con índices; definiciones, explicaciones, ejemplos,
  mermaid cuando haga falta; autocontenido, no delta; snippets representativos; preguntas guía
  con respuestas formadoras de criterio; descomposición conceptual por núcleos con documento
  de cohesión; bitácora en OUTPUTs/Bitacora-Editores; no inventar; toda afirmación con evidencia)
+ Profile: /IA/IA.Prompts/PromptFramework/Profiles/Study-Guide-Documentation.md
  (RuleSet-Study-Guide: Rule-Evidences, Rule-Narrative-Voice, Rule-Dual-Audience, …)

CLASE DE OBJETO: corpus documental existente (Mesa-Rules.md tal cual; E1 = compuerta mecánica,
  enlace que no resuelve, comando con su salida)
OBJETO: Guides/Arquitectura/Dot-NET-Arquitectura-Guide.md v2.0.2, repo hdcm-dev/Lab-Documentos,
  commit dbdf9dd (main), sha256 2fe29a12ff087e99…
OBJETIVO: que cada concepto de la guía esté materializado en código —definición, explicación,
  snippet y la asociación explícita entre el snippet y el concepto—, sin quedarse en la alegoría,
  con preguntas guía que formen criterio.
PREGUNTAS DEL CASO:
  Q1 ¿Qué definiciones/conceptos de la guía carecen de snippet o de asociación explícita
     código↔concepto, y cuáles la tienen pero débil (el código está, la asociación no)?
  Q2 ¿Qué secciones se sostienen sólo en alegoría o en prosa y necesitan materialización?
  Q3 ¿Las preguntas guía existentes forman criterio (permiten decidir en qué caso aplica cada
     concepto) o sólo comprueban lectura? ¿Dónde faltan?
  Q4 ¿La estructura (índice, jerarquía, diagramas mermaid, autocontención) cumple las Reglas?
  Q5 ¿Qué afirmaciones no están respaldadas por evidencia verificable (Rule-Evidences)?
  Q6 (Fowler) ¿Los patrones citados (Transaction Script, Service Layer, Domain Model, Repository,
     Unit of Work, CQS/CQRS, Anemic Domain Model) están descritos y ejemplificados con fidelidad
     a la fuente?
  Q7 (.NET/C#) ¿El código propuesto o existente es correcto, idiomático (C# 12/13, .NET 10),
     compila, y los snippets nuevos pueden materializarse en el laboratorio o en Variantes/?
RESTRICCIONES DURAS: no inventar; toda afirmación con fuente o comando; términos de la
  literatura en inglés (Business Rule, Entity, Value Object, Invariant, Use Case, Repository,
  Unit of Work, Factory Method…), dominio en español; patrón como sufijo en inglés;
  ItemPedido (no Linea); código nuevo que se muestre como [Compilado] debe compilar con
  SDK 10.0.400 sin advertencias, con captura; lo demás marcado [Fragmento ilustrativo: motivo].
DECISIONES CERRADAS: la escalera §9.2 y sus escenarios E-A…E-D; el laboratorio L00–L24 y sus
  capturas no se regeneran (las variantes van en Examples/…/Variantes/); §0.4 presenta el precio
  obligatorio como decisión de esa tienda; IUnitOfWork con la firma de DbContext.
FUERA DE ALCANCE: otras guías del repo; cambiar el problema conductor; MediatR/CQRS como
  adopción; regenerar capturas L*.
MEDIOS: lectura del archivo; grep/awk sobre el árbol; compilación en contenedor
  mcr.microsoft.com/dotnet/sdk:10.0 (SDK 10.0.400). Sin observar: render visual del markdown
  en un cliente concreto.
EXPEDIENTE: PROMPTs/Guides/06-Arquitectura/OUTPUTs/Bitacora-Editores/ (no cumple la condición de
  Expediente-Rules §1: carpeta con informes verbatim y punto de continuación)
QUIÉN APLICA: la mesa (editor + especialista .NET), verificación cruzada; la reintegración es el
  PR sobre hdcm-dev/Lab-Documentos.
PRESUPUESTO: tope 12 hallazgos por comisión; 1 ciclo + refutación; segundo ciclo sólo si el
  refutador tumba ≥ 3 hallazgos P0/P1.
```

## Despacho verificado

| Dato pasado al panel | Comando | Salida |
|---|---|---|
| Versión y commit del objeto | `git log --oneline -1` | `dbdf9dd Merge pull request #7 …` |
| Extensión | `wc -l` | 2126 líneas |
| Capítulos `##` / secciones `###` | `grep -c '^## '` / `grep -c '^### '` | 16 / 71 |
| Bloques de código C# / totales | `grep -c '^```csharp'` / `grep -c '^```'`÷2 | 23 / 56 |
| Diagramas mermaid | `grep -c '^```mermaid'` | 7 |
| Marcas `[Compilado]` / `[Fragmento ilustrativo]` / `Salida registrada` | `grep -c` | 13 / 10 / 18 |
| «**Respuesta:**» / «Pregunta de cierre» / «Criterio de esta guía» | `grep -c` | 43 / 7 / 10 |
| Viñetas de definición en las cinco secciones «n.1 Definiciones» | `awk` sobre `- **X.**` | 49 |
| Términos del glosario (Anexo D) | `awk` filas de tabla | 81 |
| Referencias (Anexo E) | `grep -c '<a id="ref-'` | 38 |
| Enlaces internos | `grep -o '](#…)'` | 114 (todos resuelven, verificado en PR #7) |
| Secciones `###` sin ningún bloque de código | script python | 45 de 71 (lista en `01-Base-Mecanica.md`) |
