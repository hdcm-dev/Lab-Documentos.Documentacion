---
doc_id: BIT-16-C2-INF-requisitos
doc_type: informe-de-rol
title: Relectura integral (ciclo 2) — informe de Requisitos
status: vigente
origin: agent
owner: Requisitos (núcleo permanente de la mesa)
last_review: 2026-10-28
audience: [relator, jurado, presidencia]
traces: [Crear-IA-Layer-Guide.md; Crear-IA-Layer-Guide-Reedicion.md (REED-16) §2, §7, §8.1, §10; Mesa/Ciclo-1/06-Plan-De-Redaccion.md §2, §6 (RV-04), §10; Mesa/Ciclo-2/plan-de-preguntas.md; Mesa/Ciclo-2/trazabilidad.md; Profile Study-Guide-Documentation]
---

# Relectura integral (ciclo 2) — informe de Requisitos

**Mandato.** ¿Cada solicitud S-01…S-17 y cada pregunta de REED-16 §7 está respondida en la guía terminada? ¿Cada sección declara escenario y contexto? ¿El pedido literal del PO está cubierto? Lectura a ciegas, sin otros informes del ciclo.

**Objeto leído.** La guía completa (4116 líneas, sha256 `dcba3177…bb730325`), el README de la demo y la estructura de `Examples/`. Evidencia: `evidencia-requisitos/01-cobertura.md` (matriz S × sección, §7 × sección, pedido literal) y `evidencia-requisitos/02-barridos.txt` (barridos B1–B10, reproducibles con `grep`).

## Índice

1. [Resultado](#1-resultado)
2. [Hallazgos](#2-hallazgos)
3. [Revisado y bien](#3-revisado-y-bien)

## 1. Resultado

Las diez solicitudes de contenido (S-01…S-10) y S-16, S-17 tienen sección; S-11…S-15 son de proceso. De las seis preguntas de REED-16 §7, cinco están cubiertas y la §7.1 queda **parcial** (la lectura de la imagen). Los nueve capítulos §1–§9 declaran escenario y contexto en su encabezado, y los cinco de tema traen «Aplicación por escenario» con los cinco ESC. Lo que falla está en el **detalle** que el Profile y RV-04 piden: preguntas y criterios que no dicen en qué ESC/CTX aplican, y escenarios nombrados de dos maneras.

## 2. Hallazgos

### REQUIS-01 · 23 preguntas guía sin el rótulo de escenario y contexto (S2, coherencia)

- **Ubicación.** §4.9.1–§4.9.5 (l. 868–884), §7.13.1–§7.13.12 (l. 2579–2612), §9.9.1–§9.9.6 (l. 3470–3485).
- **Evidencia (E2 + E1).** B3: §1.5, §2.6, §3.9, §5.9, §6.11 y §8.13 rotulan las 50 preguntas con *(ESC; CTX)*; §4.9 (0/5), §7.13 (0/12) y §9.9 (0/6), ninguna. El plan de preguntas (vinculante, P-09) asignó ESC/CTX a cada una y la guía los perdió. REED-16 §5.2: «recomendación sin el escenario o contexto donde aplica» es S2; el pedido del PO exige que las preguntas «sirvan al lector para identificar en qué caso se aplica».
- **Propuesta.** Agregar, en la línea de cada pregunta, el rótulo con el formato de §5.9 (cursiva entre paréntesis), con los valores del plan de preguntas:
  - 4.9.1 *(todos los ESC; CTX-PROTO y CTX-PROD)* · 4.9.2 *(ESC-01, ESC-03; todos los contextos)* · 4.9.3 *(ESC-01, ESC-03; todos los contextos)* · 4.9.4 *(ESC-01, ESC-04; CTX-PROTO)* · 4.9.5 *(ESC-03, ESC-04; todos los contextos)*.
  - 7.13.1 *(ESC-01, ESC-04)* · 7.13.2 *(ESC-04; CTX-LOCAL)* · 7.13.3 *(ESC-04; CTX-PROD)* · 7.13.4 *(ESC-04; CTX-LOCAL y CTX-PROD)* · 7.13.5 *(ESC-04)* · 7.13.6 *(ESC-04; CTX-SENS)* · 7.13.7 *(ESC-04; CTX-PROD)* · 7.13.8 *(ESC-04)* · 7.13.9 *(ESC-05; CTX-PROTO y CTX-PROD)* · 7.13.10 *(ESC-04)* · 7.13.11 *(ESC-04; CTX-PROTO y CTX-PROD)* · 7.13.12 *(transversal)*.
  - 9.9.1 *(ESC-01, ESC-03, ESC-04; CTX-LOCAL × CTX-PROTO)* · 9.9.2 *(ESC-01; CTX-LOCAL × CTX-PROTO)* · 9.9.3 *(ESC-03; CTX-LOCAL × CTX-PROTO)* · 9.9.4 *(ESC-03, ESC-04; CTX-LOCAL × CTX-PROTO)* · 9.9.5 *(ESC-01, ESC-04; CTX-LOCAL × CTX-PROTO)* · 9.9.6 *(todos los ESC; CTX-NUBE × CTX-SENS)*.
  - En §4.9 los encabezados son `####`: el rótulo va como primera línea en cursiva del párrafo de respuesta, para no romper las anclas del índice.

### REQUIS-02 · Los criterios de calidad no dicen dónde aplican (S2, coherencia)

- **Ubicación.** §4.10 (l. 888), §5.10 (l. 1296), §6.12 (l. 1811), §7.11 (l. 2539), §8.14 (l. 3184).
- **Evidencia (E2 + E1).** B5: 0 menciones de ESC o CTX en el encabezado de los cinco bloques. RV-04 (plan §6): «cada criterio nombra el ESC y el CTX». §3.10 de la propia guía: «toda recomendación que no vale para todos nombra su ESC y su CTX». Varios criterios son sólo de CTX-LOCAL con Ollama (`num_ctx`, `prompt_eval_count`, `/v1`) y se leen como universales.
- **Propuesta.** Una línea de alcance debajo de cada encabezado, con lo que la guía ya sostiene:
  - §4.10: «*Alcance:* ESC-01…ESC-05 en todo contexto; la excepción de CTX-PROTO (inyectar `IChatClient` en un servicio, como deuda declarada) está en §4.9.1.»
  - §5.10: «*Alcance:* ESC-01, ESC-03 y ESC-04. Los criterios 4 (`num_ctx`) y la fila de `/v1` de la tabla son de CTX-LOCAL con Ollama; en CTX-NUBE rige el resto.»
  - §6.12: «*Alcance:* ESC-01 y ESC-02. `num_ctx`, `prompt_eval_count` y el corpus grande sin `num_ctx` son de CTX-LOCAL con Ollama; el orden del prefijo vale también en CTX-NUBE (§6.4.2); qué se indexa es de CTX-SENS (§6.11.9).»
  - §7.11: «*Alcance:* ESC-04 (criterios 4, 5, 6 y 8) y ESC-05 (criterio 5 y los antipatrones de MCP); para ESC-01 rigen los criterios 1, 2 y 7. En CTX-PROD, los almacenes de aprobaciones y de checkpoints pasan a ser persistentes y frontera de confianza (§7.12).»
  - §8.14: «*Alcance:* los CTRL de §8.3.1 valen para la demo en CTX-LOCAL × CTX-PROTO con CTX-SENS; lo que cambia en CTX-PROD está en §8.3.2.»

### REQUIS-03 · Los escenarios se nombran de dos maneras (S3, coherencia)

- **Ubicación.** §4.8 l. 863; encabezado de §5 l. 904; encabezado de §6 l. 1324 y §6.10 l. 1754–1756; encabezado de §7 l. 1835 y §7.12 l. 2571–2575; encabezado de §9 l. 3211.
- **Evidencia (E2 + E4).** B6: 15 apariciones con nombres que no son los de §3.2 («acción con aprobación», «integración con terceros», «extracción a estructura», «búsqueda por significado», «consulta de datos», «acción con herramientas», «acciones con confirmación»). El Profile pide los ejes «definidos y nombrados de forma estable» y «los mismos escenarios en toda la guía»; REED-16 §10 pide «el marco de referencia usado igual en todas las secciones». No es sólo forma: «ESC-04 (acción con aprobación)» reduce el escenario a uno de sus dos mecanismos (la demo lo cumple sin aprobación integrada, con `AccionPropuesta`).
- **Propuesta.** Reemplazar por los nombres de §3.2: ESC-01 «asistente sobre datos propios», ESC-02 «búsqueda semántica», ESC-03 «extracción estructurada», ESC-04 «agentes y herramientas», ESC-05 «exposición por MCP». Texto exacto del encabezado de §7: «El escenario principal es ESC-04 (agentes y herramientas). ESC-01 (asistente sobre datos propios) aparece en el primer ejercicio y ESC-05 (exposición por MCP) en MCP.» Si la mesa quiere conservar el matiz, va como aclaración después del nombre canónico: «ESC-04 (agentes y herramientas), con escrituras confirmadas».

### REQUIS-04 · La lectura de la imagen deja sin ubicar la mayoría de sus cajas (S2, evidencia)

- **Ubicación.** §4.2.2 (l. 604–612).
- **Evidencia (E2 + E1).** S-01 y REED-16 §7.1 piden decir «qué del diagrama se sostiene con fuentes y qué es simplificación». §4.2.1 describe 24 rótulos, pero §4.2.2 sólo trata AI Layer, Vector DB y Monitoring & Logging (B8: 0 menciones de Third-Party Integrations, Auth Service, Cache (Redis), Docker, Kubernetes, Cloud, Mobile App, API Gateway, Microservices, NoSQL, Object y File Storage). Varias de esas cajas la guía sí las trata en otro lugar y el lector no lo puede ver desde la imagen: Third-Party Integrations es ESC-05 (§7.8), Auth Service es justo lo que falta para CTX-PROD (§8.3.2), Cache es `IDistributedCache` (en memoria en `Examples/09` y la demo, B10).
- **Propuesta.** Agregar al final de §4.2.2 esta tabla (sólo con lo que la guía ya sostiene; lo demás, fuera de alcance según §0.2):

  | Caja de la imagen | Dónde la trata la guía | Qué se sostiene o qué queda afuera |
  |---|---|---|
  | Third-Party Integrations | ESC-05, §7.8 | el servidor MCP es otro adaptador de entrada sobre los mismos casos de uso |
  | Auth Service | §3.3, §8.3.2 | el aislamiento por `SessionId` no es control de acceso; la autenticación real falta para CTX-PROD |
  | Business Logic | §4.3.2, §4.5 | casos de uso y reglas del núcleo; las herramientas vuelven a ellos |
  | LLM / RAG Pipeline / AI Services & Agents | §5, §6, §7 | progresión de capacidades, no flujo obligatorio |
  | SQL DB | §9.3 | EF Core SQLite del caso base |
  | Vector DB | §6.6.3 | almacén vectorial por MEVD, en memoria; es persistencia, no capa de IA |
  | Cache (Redis) | §8.5 | caché de respuestas sobre `IDistributedCache`, en memoria en los ejemplos; Redis no se usó |
  | Docker | Anexo E.2, §8.12 | servidor de modelos y ejemplos en contenedor |
  | Monitoring & Logging | §8.5 | telemetría GenAI con OpenTelemetry |
  | Kubernetes, Cloud | §8.12.4, §0.2 | varias instancias y nube: no implementado; CTX-NUBE fuera de foco |
  | Mobile App, Admin Panel, API Gateway, Microservices, NoSQL DB, Object y File Storage | — | fuera del alcance de esta guía (§0.2) |

### REQUIS-05 · §0 y el Anexo F quedaron sin las preguntas guía que el plan les asignó (S3, coherencia)

- **Ubicación.** §0 (l. 42–231); Anexo F (l. 4081–4116).
- **Evidencia (E2 + E1).** Plan de redacción §2, §0: «Preguntas previstas: N0b PG-1, PG-6»; plan de preguntas §4: «Toda sección con al menos una pregunta: §0 2 … Anexo F 1». B7: §0 tiene cinco subsecciones sin preguntas; el Anexo F no tiene ninguna; 0 coincidencias de PG-1 («¿por dónde empiezo?»), PG-6 («AI Engineer») y PG-7 («¿para qué un registro de decisiones?»). El contenido de PG-1 y PG-6 está disperso en prosa (§1.5.1, §3.4, §3.6), sin la forma pregunta → criterio que pide el PO.
- **Propuesta.** (a) Agregar «§0.6 Preguntas guía» (y su entrada en el índice) con dos preguntas, sólo con fuentes que ya están en el Anexo D:
  - «**0.6.1 Me piden "ponerle IA" a la app. ¿Por dónde empiezo?** *(todos los ESC; CTX-PROTO → CTX-PROD)* Por el problema, no por el modelo: las cuatro preguntas de §3.6 [REF-029] [REF-030]. Si la tarea tiene una regla determinista, es código (§1.5.1). Si pasa el filtro, el éxito se fija antes de construir: métrica, tipos de error, umbral y costo del error (§3.7) [REF-031] [REF-032]. En Movilidad Urbana, contar respuestas por medio es una consulta; convertir «voy en bondi y a veces en bici» en medios del catálogo sí lo pasa. **Criterio:** sin métrica y umbral escritos antes, después no hay forma de decidir si seguir.»
  - «**0.6.2 ¿Qué es un "AI Engineer"? ¿Lo contrato o lo soy?** *(todos; ACT-DEV)* En esta guía es una faceta de ACT-DEV: quien construye sobre modelos ya entrenados y se hace cargo de los datos y las evaluaciones del producto [REF-036] [REF-037] (§3.4). Lo que cambia frente al desarrollo clásico es que el resultado no es determinista, y evaluar pasa a ser trabajo diario (§8.4). **Criterio:** si el equipo ya escribe pruebas, el salto es aprender a separar invariantes de tasas.»
  - (b) En el Anexo F, una pregunta con criterio propio y sin fuente nueva: «**¿Para qué un registro de decisiones si el código ya muestra la decisión?** *(transversal; ACT-ARQ)* El código muestra lo elegido, no lo descartado ni por qué. En una capa de IA pesa más, porque varias decisiones dependen de piezas que cambian (MAF publicó una versión estable por semana entre septiembre y octubre de 2026, §7.11; `gen_ai.*` está en *Development*, §8.11): cuando cambien, la decisión dice qué revisar. **Criterio** (de esta guía): toda decisión registra alternativas, criterio y consecuencias negativas, y no se reescribe.» Si la mesa quiere citar a Nygard o la guía de Microsoft sobre ADR, primero tienen que entrar al Anexo D con URL y fecha.

### REQUIS-06 · La guía no muestra la demo funcionando (S3, edición)

- **Ubicación.** §9.5 (l. 3314) o §9.8 (l. 3449).
- **Evidencia (E2 + E1).** REED-16 §7.6 pregunta «qué muestra la demo funcionando contra Qwen». La guía lo responde con tablas, pero las cinco capturas del recorrido (`Demos/MovilidadUrbana.Asistente/docs/capturas/*.png`) sólo están en el README de la demo; la guía tiene 0 enlaces a ellas (B9). Quien lee la guía no ve el aviso de CTRL-12, el formulario precargado de D1 ni la baja propuesta de D6.
- **Propuesta.** Al final de §9.5, este párrafo: «**Cómo se ve.** Las capturas de una corrida del recorrido (Chromium de escritorio, 2026-10-28; muestran cómo se ve cada paso, no qué tan seguido sale así) están en el README de la demo, sección [«La página en uso»](Demos/MovilidadUrbana.Asistente/README.md#la-página-en-uso): el aviso y el alta propuesta de D1 con el CP «34» marcado, el dato exacto de D4, la fuente de D5 y la baja de D6 antes y después del clic.» Opcional: incrustar la de D6 sin confirmar, `![D6: la baja propuesta, sin confirmar](Demos/MovilidadUrbana.Asistente/docs/capturas/05-baja-propuesta-sin-confirmar.png)`, que ilustra la invariante central de la guía.

## 3. Revisado y bien

1. **LangGraph (S-10) responde lo que el PO preguntó y forma criterio.** §7.10.2 dice qué es, que no hay versión oficial para .NET con la búsqueda fechada en nuget.org [REF-107], qué ocupa su lugar (equivalente en capacidades, no en modelo de programación, con tabla), las tres vías si el grafo ya existe, y rotula «no ejecutado» el pedido HTTP. §7.13.10–§7.13.11 cierran con el criterio de operación.
2. **Marco de referencia en todos los capítulos.** §1–§9 abren con «Escenario y contexto» (B1); §4–§8 traen «Aplicación por escenario» con los cinco ESC (B2); §1.3 da la entrada «estoy en ESC-xx con CTX-yy → sección → pieza», y §3.5 confirma que ninguna fila ni columna queda vacía.
3. **La demo (S-09) es trazable al caso base y a cada escenario.** §9.1 y §9.3 separan copia literal (commit fijo, `diff -r` = 0, copia sola compilada) de agregado; la tabla D1–D6 de §9.5 da por paso el CASO, el ESC, la prueba sin modelo y la tasa con su estimando; la deuda heredada de §9.3.3 muestra los dos caminos sin igualarlos.
