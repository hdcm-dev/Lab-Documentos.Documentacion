# Cobertura de solicitudes, preguntas de REED-16 §7 y pedido literal del PO

Relectura integral, ciclo 2, rol Requisitos, 2026-10-28. Guía leída de punta a punta (4116 líneas, sha256 en `02-barridos.txt`). Estado: **cubierta** (la guía responde con sección, pieza y evidencia), **parcial** (responde una parte; el hallazgo dice cuál falta), **proceso** (la cumple la mesa, no la guía).

## 1. Solicitudes S-01…S-17

| S | Pedido | Dónde lo responde la guía | Estado | Hallazgo |
|---|---|---|---|---|
| S-01 | Analizar y describir `AI-Layer.png` | §4.2.1 (tabla de franjas), §4.2.2 (se sostiene / simplifica), §4.5 (diagrama de trabajo) | parcial: de 24 rótulos de la imagen (4 + 5 + 3 + 3 + 5 + 4, tabla de §4.2.1), §4.2.2 lee AI Layer, Vector DB y Monitoring; Third-Party Integrations, Auth Service, Cache (Redis), Docker, Mobile App y las demás no se ubican (B8) | REQUIS-04 |
| S-02 | Marco teórico y práctico vigente en .NET | §2 (hitos con fuente primaria), §5.8 (MEAI/MAF/SK/SDK), §5.7 y Anexo D.2 (estado en nuget.org con fecha) | cubierta | — |
| S-03 | Guías, ejemplos y demo | toda la guía; Anexo E.1 (12 ejemplos + demo) | cubierta | — |
| S-04 | Estrategias y casos de integración | §1 (árbol y tabla ESC × CTX), §3, §4.7, §6.2, §7.2 | cubierta | — |
| S-05 | Creación de agentes | §7.1–§7.9 (herramienta → agente mínimo → agente de MAF → workflow → multiagente; MCP) | cubierta | — |
| S-06 | Definiciones | molde «qué es / qué resuelve / qué no es» en §2.1, §3.1, §4.1, §4.3, §5.1, §6.1, §7.1, §8.1, §9.1; Anexo C | cubierta | — |
| S-07 | Ejemplos y snippets | cada snippet con «Compila en…» y líneas; `Examples/` y demo | cubierta | — |
| S-08 | Preguntas y respuestas explicativas | 73 preguntas en §1–§9 + Anexo B.1 | parcial: 23 sin rótulo ESC/CTX (B3–B4); §0 y Anexo F sin las preguntas que el plan les asignó (B7) | REQUIS-01, REQUIS-05 |
| S-09 | Demo basada en Lab-E2E.WebBlazor | §9 (copia literal de `MovilidadUrbana.ApiWeb` + piezas de `MovilidadUrbana.Web`, D1–D6, página Blazor) | cubierta en contenido; la guía no muestra ni enlaza las capturas de la demo (B9) | REQUIS-06 |
| S-10 | LangGraph en .NET | §7.10.2, §7.13.10, §7.13.11; tabla de capacidades vs. modelo de programación; pedido HTTP rotulado «no ejecutado» | cubierta | — |
| S-11…S-13, S-15 | Mesa: reedición, composición, experto extra, apuntes | — | proceso | — |
| S-14 | Relectura integral | este ciclo | proceso | — |
| S-16 | Rutas de salida | guía, `Examples/`, `Demos/` en las rutas pedidas | cubierta | — |
| S-17 | Probar todo y llevar registro | §8.4, Anexo A.4, E.4, E.5; rótulos «no medido», «no ejecutado», «corrida sólo con un doble» | cubierta | — |

## 2. Preguntas de REED-16 §7

| § | Pregunta | Dónde | Estado | Hallazgo |
|---|---|---|---|---|
| 7.1 | ¿Qué es una capa de IA? ¿Qué del diagrama se sostiene con fuentes y qué es simplificación? | §1.1, §4.3.4, §4.2.2 | parcial: «se sostiene» tiene una sola afirmación (REF-039) y «simplifica» tres; el resto de las cajas no tiene lectura | REQUIS-04 |
| 7.2 | Abstracciones sin atarse al proveedor; GA, preview, deprecados | §5.1, §5.7, §5.8, §8.11, Anexo D.2 | cubierta | — |
| 7.3 | Pipeline RAG (ingesta, chunking, embeddings, almacén, recuperación) y cuándo no hace falta | §6.2, §6.6, §6.8, §6.9, §6.11.6 | cubierta; el chunking se responde con criterio y fuente y se rotula «no ejecutado» (§6.6.1) | — |
| 7.4 | Agente vs. llamada con herramientas; marco; LangGraph | §7.1.2, §7.13.1, §7.10 | cubierta | — |
| 7.5 | Probar, observar, asegurar | §8 completa | cubierta | — |
| 7.6 | Integración sin romper Domain → Application → Infrastructure; qué muestra la demo contra Qwen | §4.5, §4.6, §9.3, §9.5 | cubierta en tablas; sin las capturas | REQUIS-06 |

## 3. ¿Cada sección declara escenario y contexto?

- Bloque «Escenario y contexto» en §1–§9 (B1). §0 y los anexos no lo llevan; en §0 es razonable (índice), en los anexos también (consulta).
- Bloque «Aplicación por escenario» con los cinco ESC en §4.8, §5.2, §6.10, §7.12, §8.2 (B2).
- **Falla**: los criterios de calidad de §4.10, §5.10, §6.12, §7.11 y §8.14 no nombran ESC ni CTX (B5; RV-04 lo exige: «cada criterio nombra el ESC y el CTX»). REQUIS-02.
- **Falla**: las preguntas de §4.9, §7.13 y §9.9 no llevan el rótulo que sí llevan las de §1.5, §2.6, §3.9, §5.9, §6.11 y §8.13 (B3). REQUIS-01.
- **Falla**: cinco secciones nombran los escenarios con rótulos distintos de los de §3.2 (B6). REQUIS-03.

## 4. Pedido literal del PO

| Pedido | Estado |
|---|---|
| Analizar y describir la imagen | parcial (REQUIS-04) |
| Estrategias y casos de integración en .NET | cubierto |
| Creación de agentes | cubierto |
| Definiciones | cubierto |
| Ejemplos y snippets | cubierto |
| Preguntas y respuestas | cubierto con fallas de rótulo (REQUIS-01, REQUIS-05) |
| Demo basada en Lab-E2E.WebBlazor | cubierto (REQUIS-06 es de presentación) |
| LangGraph en .NET | cubierto |
| Probar con la API local con Qwen | cubierto (Anexo E.5) |
