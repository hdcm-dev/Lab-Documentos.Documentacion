# I-02 — Insumo del PO: índice de un curso «AI Engineer 2026» como material guía

> **Tipo**: insumo para la mesa. El PO lo entregó el 2026-10-26 como «más material guía, para que propongas a la mesa».
> **Pieza**: [I-02-Indice-Curso-AI-Engineer.png](I-02-Indice-Curso-AI-Engineer.png), captura del índice de un curso en línea. Sólo se ven los títulos; no hay contenido.
> **Destinatarios**: especialistas de contenido (didáctica, edición bibliográfica, IA, arquitectura, senior .NET, desarrollo) y el plan de integración.
> **Núcleos afectados**: N0 (actores, escenarios), N1 (mapa conceptual), N4 (arquitecturas de agentes), N6 (demo y ejemplos), estructura general de la guía.

---

## Índice

- [1. Cómo se clasifica este insumo](#1-cómo-se-clasifica-este-insumo)
- [2. Transcripción del índice](#2-transcripción-del-índice)
- [3. Qué se lee en el índice](#3-qué-se-lee-en-el-índice)
- [4. Propuestas de la presidencia a la mesa](#4-propuestas-de-la-presidencia-a-la-mesa)
- [5. Lo que la mesa decide](#5-lo-que-la-mesa-decide)

---

## 1. Cómo se clasifica este insumo

**Es fuente de forma y de cobertura, no de contenido.** Muestra un recorrido de aprendizaje que el mercado ofrece hoy sobre el tema, y por eso permite ver qué espera encontrar el lector y en qué orden. **No es fuente citable** y no tiene nivel de evidencia E1–E4: no funda ninguna afirmación técnica de la guía. La guía no nombra el curso ni a su autor, no copia sus títulos y no arma tablas de equivalencias con él (regla de la presidencia: un modelo del PO aporta forma, no contenido).

Por los títulos, lo más probable es que provenga del mismo origen que la imagen de entrada `AI-Layer.png` (LIDR), pero eso **no está verificado** y no hace falta verificarlo para usarlo como insumo de forma.

---

## 2. Transcripción del índice

| Bloque | Títulos, en el orden de la captura |
|---|---|
| Curso «AI Engineer 2026» | 0. Presentación · 1. ¿Qué es un AI Engineer? · 2. Evolución de los LLMs · 3. ¿Qué son los Agentes IA? · 4. Una primera demo sencilla: agente para interactuar con GitHub · 5. Arquitecturas de agentes · 6. Demo intermedia: agente que interactúa con bases de datos · 7. Demo avanzada: diseña sistemas RAG listos para producción · 8. Encuesta: ¿de verdad necesitás 5 agentes o basta con uno bien diseñado? · 9. [Grabación] Arquitectura multi-agente: de 0 a AI Engineer · Repositorio de código · 8. Plus: AI Assessment 2026 |
| «¿Querés convertirte en AI Engineer?» | 1. ¿Qué es un AI Engineer? · 2. La demanda de AI Engineers y la situación del mercado · 3. Conocimientos y habilidades del AI Engineer |

**Segunda captura del PO, misma fecha (no quedó en disco; se transcribe).** Muestra el mismo índice del curso (0 a 8) como secciones desplegables. El punto 9, «[Grabación] Arquitectura multi-agente: de 0 a AI Engineer», trae este aviso: «esta grabación simula exactamente lo que sucedió en el evento en directo […] verás las preguntas, demo e interacción con el público tal y como sucedió en directo». Lo único nuevo que aporta: el tramo multi-agente se dictó como **sesión en vivo con demo y preguntas del público**, no como texto. Para la guía refuerza L-8 y L-9: el multi-agente se entiende mejor con una demo comentada y preguntas de la audiencia, que en nuestro formato equivalen a un recorrido guiado de la demo y a preguntas guía con respuesta explicativa.

---

## 3. Qué se lee en el índice

Lectura de la presidencia. Es **criterio propio**: el índice sólo muestra títulos.

| ID | Rasgo del recorrido | Qué sugiere para la guía |
|---|---|---|
| L-1 | **Rol antes que tecnología**: abre con «¿qué es un AI Engineer?» y cierra con conocimientos y habilidades | El marco N0 tiene actores (desarrollador, arquitecto, operación, seguridad, usuario final), pero no nombra el rol emergente que integra IA en aplicaciones. Hay que decidir si es un actor propio o una faceta del desarrollador .NET |
| L-2 | **Contexto histórico breve** («evolución de los LLMs») antes de los agentes | Hoy N1 define los LLM, pero no los sitúa. Un tramo corto y con fuentes (del modelo de chat al uso de herramientas, a la salida estructurada y a los agentes) explica por qué el tema existe ahora |
| L-3 | **Demos en escalera** (sencilla → intermedia → avanzada), intercaladas con la teoría y no al final | Coincide con el Profile: de lo general a lo particular, con ejemplos concretos en cada tema. Sugiere organizar Examples/ y Demos/ como **niveles de complejidad creciente** atados a las secciones, no como un anexo suelto |
| L-4 | **La primera demo es un agente que actúa sobre un sistema externo conocido** (GitHub) | El primer agente que construye el lector tiene que ser chico y sobre algo familiar. En nuestro caso, el equivalente natural es MCP o las herramientas sobre la API de Movilidad Urbana. Cambia el sistema, el patrón es el mismo |
| L-5 | **Agente sobre base de datos** como nivel intermedio | Corresponde a ESC-04 con los casos de uso de Application como herramientas, y a la extracción estructurada (ESC-03). Abre preguntas de seguridad: agencia excesiva y consultas generadas por el modelo (AH-01) |
| L-6 | **«RAG listo para producción»** como nivel avanzado | La guía tiene que separar el RAG de juguete del RAG operable: ingesta, evaluación de recuperación, citas, inyección indirecta, observabilidad (N3 + N5). Justifica que la demo final incluya evaluación y pruebas, no sólo el chat |
| L-7 | **Una pregunta de criterio explícita**: «¿de verdad necesitás 5 agentes o basta con uno bien diseñado?» | Es exactamente una pregunta guía formadora de criterio, en el sentido del Profile. Ya hay respaldo en N4 (Anthropic, «Building effective agents»: empezar por lo más simple, workflows antes que agentes autónomos). Merece una sección o pregunta guía central, no una nota al pie |
| L-8 | **Multi-agente como cierre**, no como punto de partida | Ordena el recorrido: un agente con herramientas → workflows y orquestación → multi-agente. Coincide con la progresión de Agent Framework (agente → workflow → orquestaciones ya armadas) |
| L-9 | **Autoevaluación** («AI Assessment») | El Profile pide preguntas guía y criterios de calidad. Una autoevaluación final (preguntas con respuesta explicativa, por escenario) cerraría el recorrido sin agregar material nuevo |

---

## 4. Propuestas de la presidencia a la mesa

La mesa las vota hallazgo por hallazgo; ninguna es vinculante por venir del PO.

| ID | Propuesta | Núcleo | Nivel de esfuerzo |
|---|---|---|---|
| PR-1 | Agregar al marco N0 el actor **«AI Engineer / desarrollador que integra IA»**, o declarar explícitamente que el desarrollador .NET asume ese rol. Definirlo por responsabilidades (qué decide y qué no) y no por título de mercado | N0 | bajo |
| PR-2 | Abrir la guía con un tramo breve **«por qué ahora»**: evolución de las capacidades de los LLM que hicieron posible la capa de IA (uso de herramientas, salida estructurada, ventanas de contexto, modelos locales). Cada hito con fuente primaria; sin cifras de mercado no verificables | N1 | medio |
| PR-3 | Organizar ejemplos y demo en **tres niveles** atados a las secciones: **básico** (chat, streaming, salida estructurada, primera herramienta), **intermedio** (agente con herramientas sobre los casos de uso y la base de Movilidad Urbana, con aprobación humana para lo que escribe) y **avanzado** (RAG operable con ingesta, citas, evaluación y observabilidad, más un workflow o multi-agente). La demo de N6 se vuelve el hilo que recorre los tres niveles | N6, plan | medio |
| PR-4 | Hacer de **«¿un agente o varios?»** una pregunta guía central, con criterio de decisión: cuándo alcanza una llamada, una cadena (workflow) o un agente con herramientas, y cuándo se justifican varios agentes. Respaldo: N4 (patrones de Anthropic, orquestaciones de Agent Framework) | N4 | bajo |
| PR-5 | Ordenar el bloque de agentes como **escalera de complejidad**: herramienta → agente → workflow → orquestación multi-agente, con el costo que suma cada escalón (latencia, tokens, puntos de falla, pruebas) | N4 | bajo |
| PR-6 | Cerrar con una **autoevaluación** por escenario: preguntas con respuesta explicativa, que remiten a la sección correspondiente | Anexos | bajo |
| PR-7 | Revisar si el **primer agente** de la guía (el más sencillo) debe actuar sobre un sistema familiar para el lector y externo a la demo (p. ej. el repositorio local por git o un servidor MCP de ejemplo), para que el patrón se entienda antes de mezclarlo con el dominio | N4, N6 | medio |

---

## 5. Lo que la mesa decide

1. Qué propuestas PR-1 a PR-7 se aplican, y cómo cambian el índice de la guía y la especificación de Examples/ y Demos/.
2. Si PR-3 (tres niveles) cabe en el alcance realizable de la demo, o si el nivel avanzado se cubre con ejemplos separados.
3. Cómo se combina con el insumo [I-01](I-01-Insumos-Del-PO-Agentes-LangGraph-Anotaciones.md): la escalera de PR-5 es un candidato natural para el eje del marco conceptual de N4 que pide I-01.
4. Registrar lo que se descarta, con su motivo.
