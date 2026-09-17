# 02 — Guía de estudio: Informe de solución (arquitectura, despliegue y requisitos)

> **Propósito**: cómo escribir **un informe que describe una solución de software** en términos
> de arquitectura, despliegue y resolución de requisitos funcionales y no funcionales; el modelo
> formal está en la plantilla del anexo. Cubre `Guides/Documentacion-Informe-Despliegue/`
> (30 documentos, ≈5 400 líneas, 22 diagramas Mermaid).
> **Fuente primaria**: `Guides/Documentacion-Informe-Despliegue/README.md` (`GUIA-INDICE`,
> `last_review` 2026-07-21).

## En una pantalla

- Responde al pedido «necesitamos un documento que nos permita comprender el enfoque general de
  la solución». Dos objetivos: **formar criterio de redacción** (toda la guía) y ofrecer **un
  modelo formal de documento** (`99-Anexos/Plantilla-del-Informe.md`, `ANEXO-PLANTILLA`).
- Es hermana de [Documentación técnica](01_Documentacion-Tecnica.md): no reescribe SAD, SRS,
  Deployment Guide ni ADR; enseña a **componerlos** en un informe único y los referencia.
- Dominio de ejemplo: **sistema de gestión de audiencias** distribuido en el borde (grabación por
  terminal, operación con el centro caído, subida diferida de videos). Tecnologías: .NET 10,
  ASP.NET Core, Blazor, Worker Services, PostgreSQL.
- Correcciones de fondo que la investigación impuso (README §Estado): **ISO/IEC 25010:2023** tiene
  nueve características (renombró *Usability* → *Interaction Capability*, *Portability* →
  *Flexibility*, agregó *Safety*); **arc42 y C4 son marcos con licencia CC, no normas**; la única
  definición de «arquitectura de solución» citada como fuente es la de TOGAF.

## Marco de referencia (`00-Marco-de-Referencia/`)

| Eje | Valores | Archivo |
|---|---|---|
| Escenarios `ESC-` | `ESC-1` solución en diseño · `ESC-2` solución construida · `ESC-3` en evolución o migración · `ESC-4` evaluación de una solución ajena | `Escenarios.md` |
| Contextos `CTX-` | `CTX-1` monolito desplegable único · `CTX-2` cliente-servidor distribuido · `CTX-3` sistema distribuido en el borde · `CTX-4` servicios distribuidos en infraestructura controlada | `Contextos.md` |
| Actores `ACT-` | `ACT-01` arquitecto de la solución · `02` desarrollador/líder técnico · `03` solicitante técnico · `04` responsable de despliegue y operación · `05` analista de requisitos/PO · `06` patrocinador o decisor · `07` redactor técnico · `08` auditor/calidad | `Actores.md` (+ matriz, «el error de actor más común», ficha de audiencia) |
| Convenciones | Identificadores, frontmatter, estructura, **niveles de autoridad**, estilo | `Convenciones.md` |

## Mapa conceptual (`01-Mapa-Conceptual/Mapa-Conceptual.md`, 106 líneas)

Tres tablas de entrada —por escenario, por contexto, por **parte del informe**— más los cruces.
Entrada para «escribir un informe ahora»: escenario + contexto propios → plantilla comentada.

## Las cinco familias

| Familia | Pregunta | Documentos (`doc_id`) |
|---|---|---|
| 10 Naturaleza `FAM-NAT` | ¿Qué es y para quién? | `TEM-QUE-ES` (síntesis transversal orientada a una decisión; lugar en el catálogo) · `TEM-ESTANDARES` (42010, 4+1, arc42, C4, TOGAF; qué es norma y qué es marco; mapa parte del informe ↔ referente) · `TEM-AUDIENCIA` (qué decisión habilita, estratificación por lector) |
| 20 Arquitectura `FAM-ARQ` | ¿Cómo está organizada? | `TEM-COMPONENTES` (componentes y límites, **no** la estructura de carpetas) · `TEM-VISTAS` (vistas por concern, niveles de zoom C4) · `TEM-DECISIONES` (narrar trade-offs; cuándo referenciar un ADR) |
| 30 Despliegue `FAM-DESP` | ¿Dónde corre, cómo se instala y opera? | `TEM-TOPOLOGIA` (nodos, artefactos, entornos, diagrama de despliegue) · `TEM-DISTRIBUCION` (empaquetado e instalación en .NET) · `TEM-OPERACION` (operación degradada, recuperación, trabajo diferido) |
| 40 Requisitos `FAM-REQ` | ¿Resuelve lo que debe? | `TEM-RF` (trazabilidad requisito → mecanismo sin re-listar el SRS) · `TEM-RNF` (atributos de ISO/IEC 25010:2023, medibles) |
| 50 Redacción `FAM-RED` | ¿Con qué criterio se escribe? | `TEM-ESTRUCTURA` (orden de secciones, estratificación, trazabilidad a los marcos) · `TEM-CRITERIO` (qué preguntarse por sección, voz, frases de referencia) · `TEM-ERRORES` (antipatrones con síntoma y corrección) |

Cada familia tiene `README.md`. En un sistema en el borde (`CTX-3`), el despliegue y los RNF son
los tramos de mayor rendimiento (README §Tramo 3).

## La plantilla del informe (`99-Anexos/Plantilla-del-Informe.md`)

Frontmatter del informe + 13 secciones con preguntas guía, más una lista de verificación propia:

1 Resumen ejecutivo · 2 Introducción y alcance · 3 Contexto y objetivos · 4 Visión general de la
arquitectura · 5 Vista de componentes · 6 Vistas y comportamiento · 7 Vista de despliegue ·
8 Operación y resiliencia · 9 Resolución de RF · 10 Resolución de RNF · 11 Decisiones y
trade-offs · 12 Riesgos y pendientes · 13 Anexos del informe.

## Anexos

| Archivo | `doc_id` | Contenido |
|---|---|---|
| `Plantilla-del-Informe.md` | `ANEXO-PLANTILLA` | El modelo formal (arriba) |
| `Glosario.md` | `ANEXO-GLOSARIO` | Término, definición, alias **y fuente** |
| `Lista-de-Verificacion.md` | `ANEXO-CHECK` | Revisión por sección, escenario y contexto (para evaluar informes ajenos) |
| `Referencias.md` | `ANEXO-REFERENCIAS` | 30 fuentes en cinco niveles: `N-xx` normativas, `G-xx` marcos y guías, `O-xx` obras, `F-xx` convenciones, `P-xx` evidencia de plataformas; §6 linaje y supersesiones; §7 no verificadas. Todas verificadas el 2026-07-21; las ISO contra sus PDF de muestra (portada, prólogo, alcance, índice) |
| `Pendientes.md` | `ANEXO-PENDIENTES` | Estado por bloque; fuentes sin verificar (`N-07` UML cl. 19, `G-04` SAD de RUP, `N-02` cifra «seis procesos, 37 actividades», `F-02` draft resumable upload); convenciones sin fijar; extensiones posibles: vista de seguridad, vista de datos, costos y capacidad, presentación oral del informe |

## Rutas de lectura

Tramo 1 marco y mapa (obligatorio) → 2 familia 10 (la distinción norma/marco ordena todo) →
3 familias 20/30/40 → 4 familia 50 y anexos. Por rol: arquitecto que escribe (`ACT-01`) tramo 1 →
10 → plantilla → 20/30/40 → 50; responsable de despliegue (`ACT-04`) tramo 1 → 30; evaluador
(`ACT-03`, `ACT-08`) mapa → `TEM-QUE-ES` → lista de verificación → criterios de calidad de cada
tema; analista (`ACT-05`) tramo 1 → 40 → `TEM-RNF` → plantilla.
