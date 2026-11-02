---
doc_id: BIT-16-03
doc_type: marco-de-referencia
title: Marco de referencia (N0) — escenarios, contextos y actores de una capa de IA en apps .NET
status: vigente
origin: agent
confidence: 0.8
owner: presidencia de la mesa (secretaría; sin voto)
last_review: 2026-10-25
audience: [mesa-evaluadora, redactores]
traces: [PROFILE-STUDY-GUIDE §Enfoque, BIT-16-01 N0, BIT-16-02, REED-16 §6]
---

# Bitácora 03 — Marco de referencia (N0)

El Profile pide fijar, antes de escribir los temas, el vocabulario que reaparece en toda la guía: **escenarios** (para qué se pone una capa de IA en la aplicación), **contextos** (qué variante cambia las respuestas dentro de un escenario) y **actores** (quién decide qué). Se definen una sola vez acá y en la §2 de la guía; los núcleos los citan por ID. Un núcleo que no se cruza con ningún escenario ni contexto está mal delimitado, y las matrices de §4 lo comprueban.

Este documento es definición, no afirmación técnica: no lleva fuentes externas salvo donde nombra un mecanismo. Los ejemplos sobre Movilidad Urbana son **candidatos** para la demo, con el dominio tomado de la ia-db de Lab-E2E.WebBlazor (índice `02_Dominio-Y-Reglas.md`, commit `8fb4c3a`); qué escenarios entran en la demo se decide en la fase de plan (BIT-16-02 §6).

## Índice

- [1. Escenarios](#1-escenarios)
- [2. Contextos](#2-contextos)
- [3. Actores](#3-actores)
- [4. Matrices de cruce](#4-matrices-de-cruce)
- [5. Uso en la guía](#5-uso-en-la-guía)

## 1. Escenarios

Un escenario es una **necesidad de la aplicación que un modelo puede atender**, definida por lo que entra, lo que sale y lo que el modelo tiene permitido hacer. Lo que cambia entre escenarios es la estrategia de integración (N1) y el riesgo dominante (N5).

| ID | Escenario | Entra → sale | Qué puede hacer el modelo | Candidato en Movilidad Urbana | Riesgo dominante |
|---|---|---|---|---|---|
| ESC-01 | **Asistente conversacional sobre datos propios** | Pregunta en lenguaje natural → respuesta en lenguaje natural fundada en datos de la aplicación | Leer (por recuperación o por herramientas de sólo lectura) | «¿Qué medio de transporte declararon más las personas que respondieron la encuesta?» | Respuesta inventada (alucinación) o con datos de otra sesión |
| ESC-02 | **Búsqueda semántica** | Consulta libre → lista ordenada de elementos propios por similitud de significado | Nada: sólo se usan embeddings; no hay generación | Buscar localidades o respuestas por descripción, no por coincidencia exacta de texto | Recuperación irrelevante que parece buena |
| ESC-03 | **Extracción y clasificación estructurada** | Texto libre → objeto tipado validado | Proponer datos; la aplicación valida y decide | Una frase libre con nombre, provincia, código postal y habitantes de una localidad → `LocalidadModel` validado por `LocalidadRules` (los datos del ejemplo se eligen en N6, sintéticos) | Salida que no respeta el esquema o viola reglas del dominio |
| ESC-04 | **Automatización con agentes y herramientas** | Objetivo → secuencia de acciones sobre la aplicación | Decidir qué herramienta invocar y con qué argumentos; puede escribir | Asistente que da de alta, modifica o consulta localidades invocando los casos de uso | Agencia excesiva: acción no pedida o inducida por texto externo |
| ESC-05 | **Exposición de capacidades por MCP** | Cliente MCP externo (un IDE, otro agente) → herramientas y recursos de la aplicación | El modelo del **cliente** decide; la aplicación expone | Servidor MCP que publica consultas sobre localidades y encuesta | Exposición pública de operaciones o datos sin control de acceso |

**Criterio de delimitación.** El resumen de documentos y la generación de texto libre no son escenarios aparte: son ESC-01 sin datos propios, y la guía los trata como el caso más simple de N2. La extracción (ESC-03) se separa de ESC-04 aunque ambas usen salida estructurada, porque en ESC-03 **la aplicación** decide y en ESC-04 decide el modelo. ESC-05 se separa de ESC-04 porque invierte el sentido: la aplicación no consume un modelo, sirve a uno ajeno.

## 2. Contextos

Un contexto es una **variante que cambia la respuesta correcta dentro de un mismo escenario**. Se definen en pares; cada par es un eje independiente de los otros.

| ID | Contexto | Qué cambia en las respuestas |
|---|---|---|
| CTX-LOCAL | **Modelo local** (Ollama en la propia infraestructura; en esta guía, Qwen en el servidor Ollama de la LAN del laboratorio) | Sin costo por token ni salida de datos; capacidad y ventana de contexto acotadas por el hardware; calidad de *tool calling* dependiente del modelo elegido **[C: verificar soporte de herramientas de Qwen en Ollama en N2]**. |
| CTX-NUBE | **Modelo en la nube** (proveedor gestionado accesible por API) | Mejor calidad y escala disponibles; costo por token, latencia de red, datos que salen de la organización, cuotas. |
| CTX-PROTO | **Prototipo** (demo, prueba de concepto, laboratorio) | Se tolera no determinismo y falta de observabilidad; el objetivo es aprender si el escenario vale la pena. |
| CTX-PROD | **Producción** | Exige evaluación, observabilidad, límites de costo, controles de seguridad y un plan cuando el modelo falla o cambia de versión. |
| CTX-PUB | **Datos públicos o no sensibles** | La recuperación y el registro de prompts pueden ser amplios. |
| CTX-SENS | **Datos sensibles o personales** (en el caso base: `Nombre` y `Edad` de `RespuestaDeEncuesta`) | Minimización de lo que entra al contexto, aislamiento por sesión o usuario, registro sin datos personales, restricción de proveedores. |

Las combinaciones no son todas iguales: CTX-NUBE × CTX-SENS es la que más condiciona el diseño; CTX-LOCAL × CTX-PROTO es la de esta guía y su demo. La guía lo declara en cada recomendación que no valga para todas.

## 3. Actores

Un actor es un **rol con decisiones propias**. Una persona puede ocupar varios; la guía le dice a cada uno qué le toca decidir y qué no.

| ID | Actor | Decide | No decide | Necesita de la guía |
|---|---|---|---|---|
| ACT-DEV | **Desarrollador .NET** | Cómo implementar el escenario con las abstracciones elegidas; cómo describir herramientas; cómo probar. | Qué escenarios se habilitan, qué proveedor se usa en producción, qué datos pueden entrar al contexto. | Snippets correctos y vigentes, preguntas guía para elegir la estrategia más simple, pruebas que funcionen con salidas no deterministas. |
| ACT-ARQ | **Arquitecto / líder técnico** | Dónde vive la capa de IA en la solución; qué abstracción y qué marco de agentes se adoptan; qué escenarios se construyen y con qué estrategia. | La operación diaria del modelo; las políticas de datos de la organización. | Criterios para elegir entre alternativas por escenario y contexto, y sus consecuencias. |
| ACT-OPS | **Operador / DevOps** | Cómo se sirve el modelo (local o gestionado), configuración y secretos, observabilidad, límites de costo, resiliencia. | La lógica de los casos de uso; qué pregunta responde el asistente. | Qué medir, cómo trazar una llamada, qué cambia al pasar de prototipo a producción. |
| ACT-SEC | **Responsable de datos y seguridad** | Qué datos pueden llegar a un modelo y a cuál; qué acciones puede ejecutar un agente sin confirmación humana; requisitos de registro y retención. | Cómo se implementa cada control en código. | El mapa de riesgos de una app con LLM, la mitigación mínima de cada uno y cómo verificarla. |
| ACT-USR | **Usuario final** | Qué pide y si confirma una acción propuesta por el asistente. | Nada del diseño. | No es lector de la guía; es el actor cuyos datos y acciones la guía protege. Aparece en los escenarios y en las preguntas sobre confirmación humana y transparencia. |

**Actor descartado como separado:** *proveedor del modelo*. No toma decisiones dentro de la organización; sus restricciones (cuotas, retención, términos) se tratan como propiedades de CTX-NUBE.

## 4. Matrices de cruce

### 4.1 Núcleo × escenario

`●` central; `○` aplica con matices; `—` no aplica.

| Núcleo | ESC-01 Asistente | ESC-02 Búsqueda | ESC-03 Extracción | ESC-04 Agentes | ESC-05 MCP |
|---|---|---|---|---|---|
| N1 La capa en el stack | ● | ● | ● | ● | ● |
| N2 Abstracciones y proveedores | ● | ○ (sólo embeddings) | ● (salida estructurada) | ● (*tool calling*) | ○ |
| N3 RAG | ● | ● | — | ○ (recuperación como herramienta) | ○ (recursos) |
| N4 Agentes y orquestación | ○ (si usa herramientas) | — | — | ● | ● |
| N5 Operación, calidad, seguridad | ● | ○ | ● | ● | ● |
| N6 Caso Movilidad Urbana | candidato | candidato | candidato | candidato | candidato |

Ninguna fila ni columna queda vacía. La fila N6 se completa en la fase de plan con los escenarios que la demo efectivamente cubre.

> **2026-10-28 — Parche P-05 (ciclo 1).** Mapa del recorrido de la demo y perímetro. Asignación de REQUIS-03, a ratificar en la segunda ronda de C1-48. Todas las filas son CTX-LOCAL × CTX-PROTO, salvo donde se indica otra cosa.
>
> | Paso | Pedido | Caso | ESC | CTX extra | Afirmación de la guía que lo necesita como E1 | En la demo (rama A, mínima) | Si no, dónde |
> |---|---|---|---|---|---|---|---|
> | D1 | «Agregá Goya, Corrientes, CP 34…» | C2 | ESC-03 → ESC-04 | — | «La forma no es validez: el dominio rechaza lo que el modelo inventa» (§4) | sí | — |
> | D2 | «En Bella Vista no sé cuántos viven» | C2 | ESC-03 | — | «Extracción tipada que no pasa las reglas; la UI pide el dato» (§4) | sí | — |
> | D3 | «Voy en bondi y a veces en bici…» | C3 | ESC-03 | — | «Normalizar a catálogo; un medio inventado se rechaza» (§4, M2) | sí | — |
> | D4 | «¿Qué medio usa más la gente?» | C1 | ESC-01 | CTX-SENS | «El dato exacto lo calcula un caso de uso; agregados sin nombres» (§6, M7) | sí | — |
> | D5 | «¿Cuántos dígitos lleva el código postal?» | C4 | ESC-01 (+ ESC-02 si P-22 entra a la demo) | — | «Con 12 enunciados alcanza el contexto fijo» (§5) | sí, como escalón 0 | la variante RAG, en `Examples/05` (P-23) |
> | D6 | «Borrá Resistencia» | C5 | ESC-04 | — | «Ninguna escritura sin confirmación» (M3) | sí; la forma depende de P-35 | — |
> | D7 | Un cliente MCP lista localidades | C6 | ESC-05 | — | «MCP es otro adaptador de entrada» (§6) | no (rama A); sí (rama B) | `Examples/08` con M13 (P-27) |
>
> **Regla de perímetro, común a las cinco posiciones:** una pieza entra a la demo sólo si figura en la columna «afirmación… como E1» de esta tabla. Toda pieza que entra lleva los controles M1–M14 que le corresponden (P-27). En la rama A, las piezas que no entran (selector de proveedor, `AyudaRag`, servidor MCP HTTP, página de streaming de tokens) van a `Examples/` con su número.
> **Rama B**, sólo si la segunda ronda la adopta: D7 y el servidor MCP HTTP entran a la demo con M13 completo; el resto queda igual.
>
> **Estado (aplicación del ciclo 1):** el mapeo D1–D7 → caso → ESC → CTX y la regla de perímetro son firmes. La columna «En la demo» es la rama A con mayoría actual y se ratifica o reemplaza en la segunda ronda de C1-48 (02-Revision-Homogeneidad §3.1); hasta entonces es provisional.

> **2026-10-28 — Parche P2-02 (ciclo 1, ronda 2).** Fila N6, lo que la demo cubre de verdad. ESC-01: sí (D4 con agregados, CTX-SENS; D5 con contexto fijo). ESC-02: no; `Examples/04`. ESC-03: sí (D1, D2, D3). ESC-04: sí, como propuesta tipada que la persona confirma con la operación normal, sin herramientas que escriban (D1 alta, D6 baja; P2-03). ESC-05: no; `Examples/08`. Ninguna celda queda en «candidato».



### 4.2 Núcleo × contexto

Las celdas son el temario que cada núcleo debe verificar, no afirmaciones.

| Núcleo | CTX-LOCAL / CTX-NUBE | CTX-PROTO / CTX-PROD | CTX-PUB / CTX-SENS |
|---|---|---|---|
| N2 | mismo código, distinto registro del cliente; capacidades que dependen del modelo | configuración por entorno | qué se envía al proveedor |
| N3 | modelo de embeddings local o gestionado; almacén embebido o dedicado | almacén en memoria frente a persistente | qué se indexa y con qué filtros por sesión/usuario |
| N4 | calidad del *tool calling* según modelo | confirmación humana, límites de iteraciones | herramientas de escritura sobre datos personales |
| N5 | costo y latencia; modelo en contenedor frente a servicio | evaluación y observabilidad obligatorias en producción | registro de prompts sin datos personales; amenazas OWASP |
| N6 | CTX-LOCAL (Qwen) | CTX-PROTO | CTX-SENS parcial (encuesta con nombre y edad) |

### 4.3 Actor × núcleo

| Actor | Lidera | Aplica | Verifica |
|---|---|---|---|
| ACT-DEV | — | N2, N3, N4 | sus pruebas (N5) y la demo (N6) |
| ACT-ARQ | N1, N4 (elección de marco), N6 | — | coherencia entre núcleos |
| ACT-OPS | N5 (operación) | N2 (registro y configuración del cliente) | observabilidad y costo |
| ACT-SEC | N5 (seguridad) | — | herramientas de N4, datos de N3, demo |
| ACT-USR | — | — | — (destinatario de los controles) |

## 5. Uso en la guía

- La §2 de la guía reproduce, editadas, las tablas de §1–§3 y es su única definición; el resto usa IDs o nombres cortos.
- Cada sección temática tiene una subsección «Aplicación por escenario» que recorre ESC-01…ESC-05 y dice qué cambia por contexto, con la matriz §4.1 como control de completitud.
- El mapa conceptual de la guía (N1) se organiza como tabla «estoy en ESC-xx con CTX-yy → qué estrategia y qué capítulo».
- El anexo de listas de verificación se organiza por actor (ACT-DEV, ACT-ARQ, ACT-OPS, ACT-SEC).
- La demo (N6) se narra como un recorrido por los escenarios elegidos, en CTX-LOCAL × CTX-PROTO, señalando qué cambiaría en CTX-NUBE, CTX-PROD y CTX-SENS.

## 2026-10-28 — Reparación de integración (BIT-16-04)

> Nota agregada en la fase de integración ([`04-Integracion.md`](04-Integracion.md)). **Sólo agregado**: no se modificó nada de lo anterior. Los IDs entre paréntesis (RA-*, T*, C-*, R-C*, I-*, MI-*) remiten a las resoluciones de BIT-16-04; la evidencia nueva está en `Integracion-Evidencia/`. Lo marcado MI-nn es criterio propio que vota la mesa en el ciclo 1.

- **§1, fila ESC-02** (R-C16 = C-7). El candidato «buscar localidades o respuestas por descripción» contradice N6 P2 (búsqueda semántica sobre la tabla de localidades es antipatrón) y N6 §1.1.2 (la encuesta no tiene texto libre). Además, E-B5 midió que mapear expresiones coloquiales a `Medios` por embeddings acierta 4/7 y que «en avión» devuelve `moto` sin forma de rechazar. **Candidato nuevo**: buscar el **requisito por significado** sobre los 12 enunciados de `LocalidadPolicy` y `EncuestaPolicy` («¿qué piden de la edad?» → el enunciado de la edad), sin generación, medido con recall@k/MRR (N3 P5). Las localidades se siguen buscando por campo exacto, con herramienta (ESC-01). A ratificar en la mesa (MI-08).
- **ESC-04 y PR-17** (RA-4). «Sumar IA a una app existente» (MovilidadUrbana.ApiWeb) se propone como **variante de ESC-04**, no como escenario nuevo: no cambia lo que el modelo puede hacer, sólo cómo se agrega (MI-05).
- **ESC-03** (R-C02). En la demo, el alta desde texto no escribe: devuelve la propuesta normalizada con sus errores y la persona confirma (MI-14).

> **2026-10-28 — Ciclo 1 de la mesa: convención de ids en estas notas.** «Parche P-nn (ciclo 1)» es un parche de `Mesa/Ciclo-1/03-Parches.md`, aplicado según `Mesa/Ciclo-1/05-Aplicacion.md`; «P-nn» sin calificar dentro de un texto de parche también es un parche. Los pendientes de BIT-16-04 §7 se citan como «pendiente P-nn de BIT-16-04». El plan vinculante de redacción es `Mesa/Ciclo-1/06-Plan-De-Redaccion.md`.

> **2026-10-28 — Parche P-28 (ciclo 1).** Cierre de las marcas `[C:]` de este registro. Cada marca queda en una de tres situaciones: «resuelta en <registro y sección>», «sigue abierta: <qué falta>» o «superada por <decisión>».
>
> | Marca | Situación |
> |---|---|
> | l. 48 (CTX-LOCAL, soporte de herramientas de Qwen en Ollama) | **resuelta en** `Sondeo-Entorno.md` §R.4 y BIT-16-04 tensión 4; «el servidor Ollama de la LAN del laboratorio» queda **superado por** el entorno vigente (RV-01: en la guía, «el servidor Ollama de prueba») |
