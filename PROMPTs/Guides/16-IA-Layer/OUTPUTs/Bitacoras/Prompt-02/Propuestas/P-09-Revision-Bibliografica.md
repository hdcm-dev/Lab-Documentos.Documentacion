# P-09 · Propuesta del experto en revisión bibliográfica (N-03, N-08)

> Mesa del prompt 02 de la guía 16. Etapa: planificación (no se edita la guía, los ejemplos, la demo ni el Conocimiento). Trabajo a ciegas respecto de las demás propuestas. Fecha: 2026-11-01. Fuentes leídas: `../Nucleos/00-Cohesion.md`, `N-03`, `N-08`, `../Relevamiento/R6-Industria.md`, `../00-Coordinacion-Entre-Sesiones.md` y la guía 0.11.0 (§0, §1, §3.0–§3.2, Anexo D, Anexo F).

## Índice

1. [Definiciones](#1-definiciones)
2. [Hallazgos de partida (con evidencia)](#2-hallazgos-de-partida-con-evidencia)
3. [N-03 · Fundamentos del framework](#3-n-03--fundamentos-del-framework)
4. [N-08 · Referencias y casos de industria](#4-n-08--referencias-y-casos-de-industria)
5. [Ensayos y verificaciones](#5-ensayos-y-verificaciones)
6. [Entregables y criterios de aceptación](#6-entregables-y-criterios-de-aceptación)
7. [Riesgos y qué no hacer](#7-riesgos-y-qué-no-hacer)
8. [Conflictos previsibles con otros núcleos](#8-conflictos-previsibles-con-otros-núcleos)

## 1. Definiciones

- **Fundamento**: enunciado normativo que justifica decisiones en varias partes de la guía y que, si se quita, obliga a reescribir más de un capítulo. Se distingue de **arquitectura** (cómo se materializa: capas, puertos, adaptadores) y de **tecnología** (M.E.AI, MCP, MAF).
- **Fuente primaria**: el documento del autor u organismo que establece lo afirmado (especificación, documentación oficial, artículo del equipo que construyó el sistema). **Secundaria**: quien lo resume.
- **Estado de una referencia**: `MANTENER`, `ACTUALIZAR` (cambió versión/URL/contenido), `SUMAR`, `RETIRAR`, `NO VERIFICADO` (sin lectura primaria; no se cita como hecho).
- **Caso de industria**: relato público de un equipo sobre un sistema en producción, con autor y fecha, que enseña una decisión transferible a un concepto de la guía.

## 2. Hallazgos de partida (con evidencia)

| # | Hallazgo | Evidencia |
|---|---|---|
| H1 | El principio rector ya existe y está bien fundado: «El modelo propone; la aplicación ejecuta, autoriza y valida», criterio de la guía apoyado en OWASP. | Guía §1 (línea ~227), reiterado en §11 y §14 |
| H2 | Las «dos escaleras» (saber / hacer) son criterio de la guía con [REF-115], [REF-117]. | Guía §3.2 |
| H3 | La Parte II se titula «Fundamentos» pero trata de arquitectura y M.E.AI: colisión de nombre con la sección pedida. | Guía, encabezado `# Parte II · Fundamentos` |
| H4 | La pregunta 1 de N-08 está parcialmente respondida: la guía ya cita la spec MCP 2026-07-28 ([REF-38], [REF-197]) y el Anexo F registra que el SDK C# 2.3.0 negocia `2026-07-28` (corrida de 13, 2026-10-29). Quedan citas de 2025-06-18 ([REF-196], [REF-199]). | Anexo F, fila «Especificación MCP»; Anexo D.6 |
| H5 | Anexo D ya tiene un formato normativo (`[REF-nn]` estable, «consultado AAAA-MM-DD», ms.date) y números no correlativos hasta ~REF-199. | Anexo D, preámbulo |
| H6 | R6: cuatro ítems sin lectura primaria (ISO/IEC 42001 403, OWASP Agentic desde secundarias, cronograma EU AI Act desde FLI, Uber 404). | R6 §9 |
| H7 | MAF declara «si podés escribir una función, no uses un agente» y el Harness Agent; la guía no cita el Harness. | R6 F2 |

## 3. N-03 · Fundamentos del framework

### 3.1 Estructura recomendada

**Recomendada (A): capítulo corto «Fundamentos del framework» en la Parte I, entre §1 y §2**, con 6–8 principios cerrados en formato fijo:

```text
P-n · Enunciado (una línea, imperativo)
Razón: por qué (2–3 líneas)
Fuente: interna (§/ADR de la guía) + externa ([REF-nn]) o «criterio de la guía»
Se ve en: ejemplo o paso de la demo (ruta)
Anti-patrón: qué lo viola
```

Lista candidata (sólo lo que la 0.11.0 ya sostiene; nada nuevo):

| Id | Principio | Fuente interna | Fuente externa |
|---|---|---|---|
| P-1 | El modelo propone; la aplicación ejecuta, autoriza y valida | §1, §11, ADR-08 | OWASP LLM05/LLM06 [REF-160], [REF-162] |
| P-2 | El dominio depende de un contrato (puerto), no del proveedor | §1, §4 | M.E.AI Abstractions (R6 F1), puertos y adaptadores [REF-182/183] |
| P-3 | Mínima agencia: función antes que agente; subir de escalón sólo si el de abajo no alcanza | §3.2, §8 | MAF overview (R6 F2), [REF-115], [REF-117] |
| P-4 | Saber y hacer son ejes independientes (dos escaleras) | §3.2 | criterio de la guía |
| P-5 | Toda afirmación sobre el modelo se mide: evaluación como compuerta | §10 | M.E.AI.Evaluation (F4); Shopify (F20) |
| P-6 | Lo observado se rotula (modelo, estación, fecha) y lo no medido se declara | §0 Evidencia | criterio de la guía |
| P-7 | El contexto es un recurso con presupuesto (prefijo estable, ventana) | §6, §5.5 | [REF-54], [REF-71]; Copilot (F22) |
| P-8 (condicional) | Transparencia hacia la persona usuaria: avisar que hay una IA | §2.4 (verificar) | EU AI Act Art. 50 (F12, **sólo tras leer EUR-Lex**) |

Se incluye un mermaid `flowchart` principio → capa/escalera → capítulo (etiquetas «1 · Texto», sin URLs, validado con la herramienta mermaid del workspace).

**Alternativa B: Parte 0 «Fundamentos»** antes del «Cómo usar». Descartada: §0 es instrucción de lectura; los principios necesitan el vocabulario de §1.
**Alternativa C: sólo redistribuir en §1.** Descartada: no cumple el pedido explícito de «sección inicial».

### 3.2 Decisiones y criterio

- **D-03.1 Renombrar la Parte II** a «Arquitectura y plataforma» (o similar, lo decide N-02). Criterio: un término, un significado (Anexo C).
- **D-03.2 Una sola lista de principios** compartida por el libro y el Conocimiento (N-05): el libro los narra, el Conocimiento los enuncia como reglas con su razón y evidencia (convención acordada con FC en la coordinación). Criterio: no duplicar definiciones; el Conocimiento referencia `P-n`.
- **D-03.3 La regla de MAF entra como parte de P-3, no como principio propio.** Criterio: es un caso del principio de mínima agencia; citarla como fuente externa.
- **D-03.4 Cada principio con fuente externa o la marca «criterio de la guía».** Criterio: perfil Study-Guide y R0 «no inventar».

### 3.3 Respaldo de industria

Nygard/ADR para trazar principio→ADR (F18); OWASP LLM Top 10 2025 (F8); MAF overview (F2); Microsoft.Extensions.AI (F1); arc42 §4 «Estrategia de solución» como lugar canónico de los principios en una especificación (F16).

## 4. N-08 · Referencias y casos de industria

### 4.1 Estructura recomendada

**Recomendada: conservar el Anexo D como única lista y agregar dos piezas:**

1. **D.13 Casos de industria** (fichas cortas): autor, fecha, URL, consultado, qué enseña, concepto/§ vinculado. Los casos no se dispersan en el cuerpo: el cuerpo cita `[REF-nn]` donde aplique y la ficha vive en el anexo.
2. **Tabla de cambios de referencias** en la bitácora (no en la guía; la guía no es delta): `REF-nn | estado | motivo | fecha de consulta | secciones afectadas`.

Alternativas: (B) capítulo «Estado del arte» en el cuerpo — descartada por inflar y envejecer rápido; (C) archivo de referencias aparte (bib/YAML) — más escalable pero rompe autocontención y requiere herramienta; se deja como evolución si el libro unificado (N-02) lo pide.

### 4.2 Plan de cambios por referencia (propuesto, a verificar en el ensayo E-2)

| Referencia | Estado | Acción | Secciones |
|---|---|---|---|
| MCP spec 2025-06-18 ([REF-196], [REF-199]) | ACTUALIZAR | Repuntar a 2026-07-28 si la sección equivalente existe; si no, mantener con nota de versión | §8 (MCP), §11.x lado servidor, Anexo F |
| MCP Versioning (F5) | SUMAR | Versión por solicitud, `server/discover`, deprecación ≥12 meses | Capítulo MCP, Anexo F |
| MAF overview (F2) | ACTUALIZAR | Agregar Harness Agent y la regla de funciones | §8, §9, P-3 |
| Semantic Kernel README (F3) | MANTENER/ACTUALIZAR | Texto «SK is now MAF» como señal | §9, Anexo F |
| OTel GenAI (F7) | ACTUALIZAR | Atributos citados desde el repo `semantic-conventions-genai` | §12, Anexo F |
| NIST AI RMF página (F10) | SUMAR | «being revised» como señal de obsolescencia | Anexo F, §2.4 |
| EU AI Act (F12) | SUMAR condicionado | Citar EUR-Lex (Reglamento (UE) 2024/1689) Art. 50; FLI sólo como secundaria | §2.4 / UX |
| Ragas (F14) | SUMAR | Vocabulario de métricas RAG junto a F4 | §10 |
| arc42, C4, adr.github.io (F16–F18) | SUMAR | Base del Conocimiento de especificación | Conocimiento (N-05), §13 |
| ISO/IEC 42001 (F11) | NO VERIFICADO | No citar hasta lectura primaria (página de ISO o resumen oficial) | — |
| OWASP Agentic 2026 (F9) | NO VERIFICADO (nombres) | Leer el PDF oficial antes de citar ASI01–10 | §8, §11 |

### 4.3 Casos de industria (máximo 5 en el libro)

| Caso | Fecha | Enseña | Concepto/§ |
|---|---|---|---|
| LinkedIn (F19) | 2024-04-25 | salida estructurada con parser defensivo; el último 15 % cuesta | §5 salida tipada, §10 |
| Shopify Sidekick (F20) | 2025-08-26 | calibrar el juez contra humanos (Kappa); instrucciones just-in-time; no multiagente temprano | §10, §8, P-3, P-5 |
| Anthropic multi-agente (F21) | 2025-06-13 | rúbrica de juez de una llamada; trazas sin leer contenido | §10, §12 |
| GitHub Copilot (F22) | 2023/2024 | presupuesto de contexto (histórico) | §6, P-7 |
| eShopSupport (F24) | repo | caso .NET comparable a la demo | §14, Anexo G |

Uber (F23) queda fuera mientras no haya lectura primaria (404). Criterio de selección: fuente primaria leída + vínculo a un concepto existente + aporta algo que la guía no tiene.

### 4.4 Decisiones y criterio

- **D-08.1** No reescribir el capítulo MCP entero: el SDK 2.3.0 ya negocia 2026-07-28 (H4); basta actualizar citas y explicar el cambio de handshake a versión por solicitud si los ejemplos lo exponen. Criterio: el código es la verdad; cambio mínimo.
- **D-08.2** Fecha de consulta única por ronda (la del ensayo E-2) para las referencias tocadas; las no tocadas conservan la suya.
- **D-08.3** Numeración: nuevas referencias desde el primer número libre (≥ REF-200, a confirmar con E-1); nunca renumerar.
- **D-08.4** Lo no verificado no entra al cuerpo; si se menciona, con «no verificado» literal (convención de §0).

## 5. Ensayos y verificaciones

| Id | Qué | Cómo | Se aprueba si |
|---|---|---|---|
| E-1 | Inventario del Anexo D | script que extrae `[REF-nn]`, URL y «consultado» del anexo y del cuerpo | 0 citas en el cuerpo sin entrada; 0 entradas sin cita; lista de números libres |
| E-2 | Enlaces vivos | HEAD/GET de cada URL con registro de código HTTP (no exige modelo ni turno) | 0 enlaces rotos sin marca; 403 registrados como «acceso restringido» con fuente alternativa |
| E-3 | Lectura primaria de los 4 pendientes | EUR-Lex Art. 50; PDF OWASP Agentic; ISO 42001 (página pública); Uber blog | cada uno pasa a `SUMAR` con cita literal o queda `NO VERIFICADO` |
| E-4 | Spec MCP 2026-07-28 vs ejemplos 13–17 | comparar las secciones citadas con 2025-06-18 y la línea `mcp-negociacion` | lista de párrafos a cambiar ≤ lo necesario |
| E-5 | Prueba de lector (N-03) | un rol sin contexto lee sólo el capítulo de fundamentos y enuncia los principios | enuncia ≥ 6/8 correctamente |
| E-6 | Trazabilidad de principios | grep de `P-n` y de sus fuentes | cada P-n con ≥1 § interna y fuente externa o «criterio de la guía»; ningún principio definido en dos lugares |

## 6. Entregables y criterios de aceptación

Todos en la bitácora durante la planificación; la aplicación a la guía la hace la fase de integración.

| Entregable | Ruta | Aceptación |
|---|---|---|
| Lista cerrada de principios con fuentes | `Prompt-02/Fundamentos/Principios.md` | 6–8 P-n, formato de §3.1, E-6 en verde |
| Mapa mermaid principios↔capas↔capítulos | mismo archivo | valida con la herramienta mermaid del workspace |
| Tabla de cambios de referencias | `Prompt-02/Referencias/Cambios-Anexo-D.md` | cada fila con estado, fecha de consulta y § afectadas |
| Registro de enlaces (E-2) | `Prompt-02/Referencias/Enlaces-AAAA-MM-DD.tsv` | 100 % de URLs con código HTTP |
| Fichas de casos (borrador de D.13) | `Prompt-02/Referencias/Casos-De-Industria.md` | ≤5 casos, cada uno con fuente primaria leída y § vinculada |
| Pendientes de verificación | `Prompt-02/Referencias/No-Verificado.md` | 4 ítems de H6 resueltos o justificados |

## 7. Riesgos y qué no hacer

- Inflar el capítulo de fundamentos con resúmenes: límite orientativo ~1 página por principio, sin repetir §3/§4.
- Citar listas (ASI01–10, cifras de Uber, fechas del AI Act) desde secundarias como hechos.
- Renumerar `[REF-nn]` o crear un segundo anexo de versiones (el Anexo F es único).
- Reescribir MCP «a la última spec» sin comprobar el código de 13–17.
- Nombrar en público el caso privado o la infraestructura; los casos de industria son sólo públicos.
- Tocar archivos comunes o rutas de FC/DAC; las fechas de consulta van en la bitácora pública con roles, no con hosts.

## 8. Conflictos previsibles con otros núcleos

- **N-02**: ubicación del capítulo de fundamentos y el renombre de la Parte II; también dónde van los casos (D.13 vs capítulo).
- **N-05**: lista única de P-n vs principios propios del Conocimiento; arc42/C4/ADR como esqueleto del Conocimiento (lo propongo como fuente, N-05 decide forma).
- **N-01**: si E-4 detecta que un ejemplo MCP expone el handshake, el cambio de texto pasa a N-01.
- **N-04**: la revisión tipo libro verifica citas; E-1/E-2 deberían ser compuertas reutilizables suyas (posible script en `tools/`, que es territorio de la guía pero se aplica en integración).
- **N-09**: ninguno de mis ensayos necesita modelo ni turno; si E-4 requiere correr 13, sí.
- **N-06/N-07**: los casos de uso propios no son «casos de industria»; no mezclar en D.13.
