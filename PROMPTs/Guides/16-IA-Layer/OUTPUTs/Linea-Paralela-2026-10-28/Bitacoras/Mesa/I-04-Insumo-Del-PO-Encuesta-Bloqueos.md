# I-04 — Insumo del PO: encuesta «¿Cuál es tu mayor bloqueo para llevar un sistema con IA a producción?»

> **Tipo**: insumo para la mesa. El PO lo entregó el 2026-10-26.
> **Pieza**: [I-04-Encuesta-Bloqueos-Produccion.png](I-04-Encuesta-Bloqueos-Produccion.png), captura de una encuesta abierta en una red social. La plataforma no figura en la captura y no se infiere.
> **Destinatarios**: especialistas de contenido (didáctica sobre todo) y el plan de integración.
> **Relación**: continúa [I-02](I-02-Insumo-Del-PO-Recorrido-AI-Engineer.md) e [I-03](I-03-Insumo-Del-PO-Temario-AI-Engineering.md); por el tema, probablemente forme parte del mismo material, pero eso **no está verificado**.

---

## 1. Transcripción

| Opción | Votos |
|---|---|
| Arquitectura del sistema | 51 % |
| Datos, chunking, retrieval | 18 % |
| Evaluación en producción | 15 % |
| El equipo no tiene el perfil | 16 % |

242 votos; la encuesta seguía abierta («6d left») cuando se tomó la captura.

---

## 2. Clasificación

**Es una señal de audiencia, no evidencia.** Es una muestra autoseleccionada de quienes siguen a quien publicó, con cuatro opciones cerradas, y la captura se tomó con la encuesta abierta. No mide a la industria y **no funda ninguna afirmación de la guía**: no se cita ni se reproducen sus porcentajes como dato. Sirve para lo mismo que I-02 e I-03, es decir, para saber qué preocupa al lector probable y decidir dónde poner el énfasis.

---

## 3. Lectura para la guía

Lectura de la presidencia, **criterio propio**:

| Señal | Cruce con lo que ya hay | Qué sugiere |
|---|---|---|
| La **arquitectura del sistema** es el bloqueo más elegido, con diferencia | Es el centro del pedido del PO: la capa de IA como parte del stack (N1, imagen de entrada) y su ubicación como puerto en Application con adaptadores en Infrastructure | Confirma que el eje de la guía es arquitectónico. La guía tiene que dar decisiones de diseño explícitas: dónde vive cada pieza, qué depende de qué, qué se puede reemplazar, cómo se prueba. Un catálogo de librerías no alcanza. Refuerza PR-12 (columna vertebral) y pide que la demo **muestre** las capas, no sólo que funcione |
| **Datos, chunking, retrieval** aparece como bloqueo propio | N3, y PR-10 de I-03 | Justifica que N3 trate la ingesta y la fragmentación con el mismo peso que la búsqueda vectorial, con criterios de elección y no sólo con código |
| **Evaluación en producción** | N5 (Microsoft.Extensions.AI.Evaluation, observabilidad), AH-02 propuesto en la fundación | Respalda convocar AH-02 (evaluación de sistemas LLM y RAG) y que la demo traiga pruebas y evaluación, no sólo el chat (PR-3 nivel avanzado, PR-11) |
| **El equipo no tiene el perfil** | PR-1 (actor «AI Engineer»), I-02 | Sostiene que el marco N0 nombre las competencias que la guía forma, y que la guía declare al principio qué sabe el lector al terminar y qué no |

---

## 4. Propuestas de la presidencia a la mesa

| ID | Propuesta | Núcleo | Esfuerzo |
|---|---|---|---|
| PR-13 | Hacer explícitas las **decisiones de arquitectura** de la capa de IA como sección propia, en forma de registro de decisiones con alternativas, criterio y consecuencias: dónde vive el `IChatClient`, puerto y adaptador, herramientas como casos de uso, almacén vectorial frente a la base existente, sincrónico o en segundo plano, local o en la nube. Cada decisión se ilustra con la demo | N1, N6 | medio |
| PR-14 | Que la guía abra con los **objetivos de aprendizaje**: qué competencias forma, por actor del marco N0. Así el lector que «no tiene el perfil» sabe qué gana y en qué orden | N0, plan | bajo |
| PR-15 | Usar las cuatro preocupaciones (arquitectura, datos y recuperación, evaluación, perfil del equipo) como **comprobación de cobertura** en la relectura integral de la mesa: cada una tiene que tener una sección, un ejemplo y preguntas guía que la respondan. Es una lista de control interna; no se publica como dato | Mesa | bajo |

---

## 5. Lo que la mesa decide

1. Qué propuestas PR-13 a PR-15 se aplican.
2. Si la señal de evaluación alcanza para convocar a AH-02 (evaluación de sistemas LLM y RAG) en el panel.
3. Registrar lo que se descarta, con su motivo.
