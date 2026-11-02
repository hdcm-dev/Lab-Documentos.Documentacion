# 01 · Convocatoria de la mesa — prompt 02 de la guía 16

**Etapa:** planificación · **Fecha:** 2026-11-01 · **Autor:** presidencia de la mesa · **Marco:** Knowledge-Mesa-De-Expertos-A-Pedido (F1), Knowledge-Mesa-Consulta-A-Un-Tercero (F2), Rule-Expediente (F7), resumidos en `Relevamiento/R5-Marco.md`.

## Índice

- [1. Objeto y límites](#1-objeto-y-límites)
- [2. Criterio de reclutamiento](#2-criterio-de-reclutamiento)
- [3. Especialistas planificadores](#3-especialistas-planificadores)
- [4. Núcleo permanente y refutador](#4-núcleo-permanente-y-refutador)
- [5. Jurado de cinco funciones](#5-jurado-de-cinco-funciones)
- [6. Consulta a un tercero](#6-consulta-a-un-tercero)
- [7. Expedientes](#7-expedientes)
- [8. Cobertura núcleo ↔ especialista](#8-cobertura-núcleo--especialista)
- [9. Qué no hace esta convocatoria](#9-qué-no-hace-esta-convocatoria)

## 1. Objeto y límites

Planificar la reedición de la guía `Dot-Net-Integration-AI-Layer-Guide` (0.11.0, en revisión) como libro unificado, autocontenido y no delta; la coherencia texto ↔ Examples 01–17 ↔ demo; la sección inicial de fundamentos; el Conocimiento de especificación (hoy vacío); y su aplicación en dos casos de uso: Lab-Geometria (público) y un servicio privado de notificaciones (citado sólo en abstracto). Núcleos N-01…N-10 en `Nucleos/`, cohesión en `Nucleos/00-Cohesion.md`.

Esta etapa entrega **plan**, no aplica: no se editan guía, Examples, demo, Conocimiento ni repos de los casos de uso (carta común; F1 §4 «Quién aplica»). Rige el reparto de `00-Coordinacion-Entre-Sesiones.md`.

## 2. Criterio de reclutamiento

1. **Roles pedidos por nombre** en el prompt 02 entran todos (F1 §3.1: el pedido por nombre manda).
2. **Roles que piden los núcleos** (campo «especialidades que requiere» de cada N-xx) se suman cuando ningún rol pedido los cubre.
3. **Techo**: la mesa pide 8–14 planificadores. Para no superarlo, las seis intervenciones editoriales se agrupan en dos comisiones (propuesta de R5 §4.3): contenido + académica; estilo + ortotipografía + diseño editorial + pruebas. Cada comisión declara las intervenciones que cubre y las ejecuta en fases sucesivas de la ronda tipo libro (N-04).
4. **Composición final la vota el jurado** (F1 §2.1 paso 4), no la presidencia: esta lista es la propuesta que se le somete, con descartes motivados (§3, última tabla).
5. **Público/privado**: ningún especialista lleva a repos públicos nombres, rutas, hosts ni cifras del caso privado; su informe sobre N-07 va al expediente privado, y a la bitácora sólo en abstracto.

## 3. Especialistas planificadores

| # | Rol | Perfil | Núcleos | Entrega | Origen |
|---|---|---|---|---|---|
| E-01 | Analista de sistemas / ingeniería de requisitos | Requisitos con Id, criterio de aceptación y trazabilidad a prueba; lectura de casos de uso | N-01, N-05, N-06, N-07 | Matriz de requisitos del prompt → núcleos; plantilla de especificación (campos, Id, aceptación) del Conocimiento; requisitos de cada caso de uso | Pedido |
| E-02 | Arquitecto de aplicaciones móviles MAUI .NET | Apps híbridas, puente JSON-RPC, offline-first; conoce el libro MAUI de la sesión FC | N-02, N-03, N-05 | Puntos de contacto guía ↔ libro MAUI (se referencian, no se redefinen); capítulo móvil del plan; frontera de la arquitectura de referencia | Pedido |
| E-03 | Arquitecto .NET / Microsoft.Extensions.AI | `IChatClient`, middleware, herramientas tipadas, Agent Framework, MCP | N-01, N-03, N-05, N-06 | Inventario de deriva texto ↔ Examples/demo (descripción vs. decisión, F1 §3.3); fundamentos técnicos; arquitectura y contratos del Conocimiento | Núcleos |
| E-04 | Arquitecto de software (arc42, C4, ADR) | Vistas, ADR, mermaid de arquitectura | N-05, N-01 | Estructura del Conocimiento (§0–§n de R5 §7) mapeada a arc42/C4; tratamiento de I-5 / ADR-01 | Núcleos |
| E-05 | Analista de decisiones y criterios | Matrices de decisión, criterios simplicidad/practicidad/escalabilidad, costo de cumplir | N-01, N-05, N-07 | Tabla P-n con criterio y prioridad al chocar; árbol «¿necesita capa de IA?»; dictamen sobre I-5 / ADR-01 | Pedido |
| E-06 | Especialista en documentación técnica de usuario y de sistemas | Manuales, guías de estudio, docs-as-code | N-02, N-03 | Arquitectura del libro unificado: partes, capítulos, rutas de lectura por perfil, anexos; separación libro ↔ Conocimiento | Pedido |
| E-07 | Comisión editorial A: edición de contenido y edición académica | Académico en edición de libros y material bibliográfico | N-02, N-04, N-03 | Plan de la ronda tipo libro (fases 1–2): estructura argumental, no delta, aparato académico (citas, glosario, referencias fechadas) | Pedido |
| E-08 | Comisión editorial B: corrección de estilo, ortotipográfica, diseño editorial y corrección de pruebas | Corrector y diseñador editorial; mermaid («1 · Texto», sin URL, validado) | N-04, N-02 | Plan de la ronda (fases 3–6): hoja de estilo, convenciones tipográficas, numeración de tablas/figuras, lista de pruebas finales | Pedido |
| E-09 | Experto en revisión bibliográfica | Estado del arte, verificación de fuentes primarias, fechas de consulta | N-03, N-08 | Lista de referencias a actualizar/sumar/marcar NO VERIFICADO (MCP 2026-07-28, Agent Framework, EU AI Act art. 50, OWASP, arc42/C4/ADR, casos de industria) | Pedido |
| E-10 | Especialista en seguridad de IA (OWASP LLM / Agentic) | Inyección de prompt, herramientas de sólo lectura, confirmación humana, aislamiento por inquilino | N-05, N-07, N-06 | Sección de riesgos y controles del Conocimiento; riesgos de cada caso de uso (envío masivo irreversible, datos personales) | Núcleos |
| E-11 | Investigador que ensaya y prueba / evaluación | Pruebas ejecutables, compuertas de `tools/`, ensayos contra modelos locales con turno del gestor | N-01, N-06, N-09 | Plan de verificación: qué Example/demo se corre, con qué compuerta, qué modelo y turno; criterios de evaluación (p. ej. Ragas) y marcas NO EJECUTADO | Pedido |
| E-12 | Especialista del dominio Geometría (arquitecto .NET/Blazor + didáctica) | Conoce Lab-Geometria; regla «el alumno construye; no resolver por él» | N-06 | Diseño del caso de uso Geometría aplicando el Conocimiento; candidatos a enriquecer ejemplos y guía; borrador del expediente 0002 | Núcleos |
| E-13 | Especialista en forma de conocimientos y perfil Study-Guide | Rule/Forma-De-Conocimiento, perfil Study-Guide-Documentation y su RuleSet | N-05, N-02, N-10 | Cabecera y forma del Conocimiento (regla/razón/evidencia); conformidad del libro con el RuleSet; registro de excepciones | Núcleos |
| E-14 | Lector sin contexto | Desarrollador .NET que nunca vio la guía | N-02, N-03, N-05 | Prueba de autocontención: qué no se entiende sin historia; rutas de lectura que fallan | Núcleo permanente F6 |

Descartes y fusiones (para que el jurado los vote):

| Rol considerado | Decisión | Motivo |
|---|---|---|
| Seis comisiones editoriales separadas | Fusionadas en E-07 y E-08 | Techo de 14; las intervenciones son fases sucesivas de N-04 |
| Arquitecto «de aplicaciones con capa de IA» (N-03) | Absorbido por E-03 | Mismo saber; evita doble lectura del código |
| Diseño editorial / diagramación mermaid aparte | Dentro de E-08 | Validación mecánica con la herramienta de mermaid del workspace |
| Especialista propio del caso privado | Lo cubren E-01, E-05, E-10 en privado | Evita un rol que sólo produciría material no publicable; la norma del repo privado la aplica quien abra su expediente |
| Coordinador de infraestructura (N-09) | Lo cubre E-11 | N-09 es medio de prueba, no objeto de la mesa |
| Gobernanza (N-10) | Presidencia + E-13 | Es marco de la mesa, no comisión |

## 4. Núcleo permanente y refutador

Por F6 §3.4.1 siempre están: requisitos (E-01), verificación (E-11), lector sin contexto (E-14) y **refutador**, que entra último, ataca la lectura dominante y el objetivo contra el pedido literal (¿qué se dio por fijo sin pedirlo?, ¿solución más chica?) y revisa los `NO_PROCEDE` si hay homogeneidad (>80 % de 5-0). El refutador no es planificador ni vota.

## 5. Jurado de cinco funciones

El jurado es distinto de las comisiones: quien informa no juzga su propio hallazgo. Quórum 5, mayoría simple entre `PROCEDE`, `NO_PROCEDE` (con motivo) e `INSUFICIENTE`; empate → `INSUFICIENTE`, segundo empate → escalada (F6 §3.5.4). Vota además la composición de §3.

| Función | Perfil del jurado | Qué mira |
|---|---|---|
| Evidencia | Investigador metodólogo (perfil de E-11, otra instancia) | Toda afirmación con ancla verificable (`[archivo:líneas]`, `[Rn]`, ensayo fechado); nada inventado |
| Impacto | Analista de sistemas sénior (perfil de E-01, otra instancia) | Qué cambia para el lector y para los casos de uso; prioridad P0–P3 |
| Costo-beneficio | Analista de decisiones (perfil de E-05, otra instancia) | Simplicidad, practicidad y escalabilidad pedidas; «¿cuánto cuesta cumplir?» |
| Coherencia histórica | Editor académico (perfil de E-07, otra instancia) | Continuidad con la 0.11.0, la mesa de recuperación (`Mesa/Recuperacion-2026-10-28/05-Cierre.md`), ADR vigentes y el libro MAUI |
| Riesgo (veto acotado) | Especialista en seguridad de IA (perfil de E-10, otra instancia) | Irreversibilidad y fuga público/privado; veto sólo si irreversible **y** P2/P3, y convierte en escalada |

## 6. Consulta a un tercero

F2 exige que el PO fije destinatario, canal y límites; el prompt 02 nombra la consulta pero no esos datos. **No se abre** en esta etapa. Los especialistas anotan dudas en formato F2 (`rol · pregunta · por qué · prioridad · qué hago si no contesta`); si al cierre de la planificación quedan dudas sin respuesta en el árbol, van al lote de preguntas del cierre con `SI NO RESPONDÉS`, incluyendo la de quién sería el tercero.

## 7. Expedientes

Criterio F7 §1: se abre si el caso atraviesa más de un repositorio o más de una corrida. Aquí se cumple.

| Expediente | Dónde | Objeto | Cuándo | Aviso |
|---|---|---|---|---|
| Registro de la mesa | `OUTPUTs/Bitacoras/Prompt-02/` (LDD) | Toda la mesa del prompt 02 (precedente: `Bitacoras/Mesa/Recuperacion-2026-10-28/`) | Ya abierto | — |
| **0002** de Lab-Geometria | `SDD/Expedientes/0002-…` (repo público) | Aplicación del Conocimiento de especificación al diseño de una capa de IA en Geometría (caso de uso, carpeta `ai-layer`) | Al pasar a diseño del caso (N-06), no en esta etapa | Una línea a FC y DAC antes de crearlo, en `00-Coordinacion-Entre-Sesiones.md` |
| Correlativo del servicio privado | Repo privado, según su norma en `Prompts/` | Mismo objeto, caso privado (N-07) | Al pasar a diseño de N-07; número = último en main + 1, verificado ese día | Aviso previo; en esta bitácora sólo «<privado>, expediente correlativo» |

Los expedientes de casos de uso se citan mutuamente con el registro de LDD (F7 §1). No se abre expediente en LD: la guía es el objeto, y su registro vive en LDD.

## 8. Cobertura núcleo ↔ especialista

| Núcleo | Especialistas |
|---|---|
| N-01 Coherencia texto ↔ ejemplos y demo | E-01, E-03, E-04, E-05, E-11 |
| N-02 Libro unificado | E-02, E-06, E-07, E-08, E-13, E-14 |
| N-03 Fundamentos | E-02, E-03, E-06, E-07, E-09, E-14 |
| N-04 Ronda tipo libro | E-07, E-08 |
| N-05 Conocimiento de especificación | E-01, E-02, E-03, E-04, E-05, E-10, E-13, E-14 |
| N-06 Caso Geometría | E-01, E-03, E-10, E-11, E-12 |
| N-07 Caso privado | E-01, E-05, E-10 (informes en privado) |
| N-08 Referencias e industria | E-09 |
| N-09 Infraestructura de pruebas | E-11 |
| N-10 Gobernanza | E-13 y presidencia |

Todo núcleo tiene al menos un especialista; ninguno queda sólo con la presidencia salvo N-10, que es marco.

## 9. Qué no hace esta convocatoria

- No despacha cartas: cada carta sale del esqueleto de F1 §5.2 y se archiva antes del despacho (paso siguiente).
- No edita guía, Examples, demo, Conocimiento ni repos de casos de uso.
- No crea expedientes en Lab-Geometria ni en el repo privado: los propone con su condición de apertura.
