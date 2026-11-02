---
doc_id: BIT-16-C2-TRAZ
doc_type: trazabilidad
title: Trazabilidad de la guía 16 — solicitudes, preguntas de la mesa, propuestas y directivas del PO hacia secciones, piezas y pruebas
status: vigente
origin: agent
owner: redacción de la guía 16 (fase de redacción, ciclo 2)
last_review: 2026-10-28
audience: [redacción, presidencia, relectura integral]
traces: [Crear-IA-Layer-Guide-Reedicion.md (REED-16) §2, §7, §9.1 C2–C3; Mesa/Ciclo-1/06-Plan-De-Redaccion.md §2, §3, §4, §9, §10; Mesa/Ciclo-1/03-Parches.md P-06, P-28; Mesa/I-06-Directiva-Del-PO-Caso-Unico-Y-Medios.md; Mesa/Ciclo-1/07-Dictamen-Presidencia.md; Mesa/Ciclo-2/plan-de-preguntas.md (BIT-16-C2-PREG)]
---

# Trazabilidad de la guía 16 (P-28)

Este archivo es el entregable previo de P-28 (plan de redacción §1 y §9, con los cambios de §10). Reemplaza a la trazabilidad de BIT-16-02 §6 para la redacción. Lleva cada solicitud S-01…S-17, cada pregunta de REED-16 §7, cada propuesta PR-1…PR-22 (con el destino de P-06), las directivas RD-PO-1…4 y MD-1…3 (I-06), y las filas propias de N0b, N1b, N3b y el Anexo F. Para cada una dice a qué sección de la guía va, con qué ejemplo o pieza, con qué prueba o registro R-LLM y en qué estado está hoy.

## Índice

- [0. Convenciones](#0-convenciones)
- [1. Solicitudes S-01…S-17](#1-solicitudes-s-01s-17)
- [2. Preguntas de REED-16 §7](#2-preguntas-de-reed-16-7)
- [3. Propuestas del PO PR-1…PR-22](#3-propuestas-del-po-pr-1pr-22)
- [4. Directivas del PO RD-PO-1…4 y MD-1…3](#4-directivas-del-po-rd-po-14-y-md-13)
- [5. Filas propias: N0b, N1b, N3b y Anexo F](#5-filas-propias-n0b-n1b-n3b-y-anexo-f)
- [6. Trazabilidad inversa: sección → origen (C3)](#6-trazabilidad-inversa-sección--origen-c3)
- [7. Controles C2 y C3](#7-controles-c2-y-c3)

---

## 0. Convenciones

- **Sección:** la numeración vigente de P-07 (plan §2): §0 Índice y objetivos; §1 Mapa conceptual; §2 Por qué ahora; §3 Marco de referencia; §4 La capa de IA en el stack; §5 Hablar con un modelo desde .NET; §6 Estrategias de conocimiento; §7 Agentes, herramientas y orquestación; §8 Operar, evaluar y asegurar; §9 La demo; Anexos A–F. Los destinos de P-06 usaban la numeración anterior a P-07 y acá ya están traducidos.
- **Ejemplo o pieza:** carpeta de `Examples/` (tabla canónica del plan §3 con los cambios de §10.2), paso o pieza de la demo `Demos/MovilidadUrbana.Asistente/` (D1–D6, CTRL-nn), anexo o plan de preguntas. La 11 no existe.
- **Prueba o R-LLM:** `Cableado/` es la suite sin modelo; `ConModelo/` y «R-LLM» son corridas contra el servidor Ollama de prueba, con la cabecera R-LLM-1…5 (modelo@digest, parámetros, N, k/n con intervalo, estimando y criterio escritos antes) y el rótulo de estación de RV-01. «Compuerta» nombra una de §7 y §10.5 del plan. «Lectura» es una verificación manual en la relectura.
- **Estado** (2026-10-28, al empezar la redacción). La guía, `Examples/` y `Demos/` están vacíos, así que nada está escrito todavía. Los estados posibles son:
  - **pendiente**: sin bloqueo; se redacta en el orden del plan §0.2.
  - **bloqueada (motivo)**: espera algo de §10.8.
  - **no ejecutada (rótulo)**: entra a la guía con ese rótulo, por decisión de la mesa.
  - **proceso**: no es contenido de la guía y vive en la bitácora.
  - **descartada (motivo)**.
  - **lista interna**: se usa en la relectura y no se publica.

  Cada fila pasa a «redactada», «compila», «corre» o «verde» cuando la matriz de snippets y las compuertas lo registren, nunca por estar escrita acá (plan §10.7).

---

## 1. Solicitudes S-01…S-17

| Origen | Qué pide (REED-16 §2) | Sección | Ejemplo o pieza | Prueba o R-LLM | Estado |
|---|---|---|---|---|---|
| S-01 | Analizar y describir `INPUTs/AI-Layer.png` | §4 (lectura de la imagen: qué se sostiene con fuentes y qué es simplificación); §6 («Vector DB» en dos capas, N3 P2) | diagrama único redibujado desde la nota de P2-02 en BIT-16-04 §6.2 | compuerta Mermaid; lectura (cada afirmación de la imagen con REF o «simplificación») | pendiente |
| S-02 | Marco teórico y práctico vigente en .NET | §2, §5 (métodos y marcos MEAI / MAF / SK / SDK directo), Anexo D | tabla de paquetes del Anexo D | compuerta de versiones (P-32): registro y `flatcontainer` de nuget.org, `--vulnerable --include-transitive`, 0 NU19xx en el camino por defecto | pendiente |
| S-03 | Guías de estudio, ejemplos y demo | toda la guía (§0 ruta de lectura) | `Examples/01`–`10`, `12`, `13`; `Demos/MovilidadUrbana.Asistente/` | build y test n/n con `sdk:10.0` por el recurso `build`; clon limpio (P-10): cada README corre tal cual | pendiente |
| S-04 | Estrategias y casos de integración | §1 (árbol D1–D6 y tabla ESC × CTX), §3, §4, §6 | `Examples/04`, `05`, `13`; demo D1–D6 | prueba de arquitectura de `Examples/13` (verde + dos rojos); `Cableado/` de la demo | pendiente |
| S-05 | Creación de agentes | §7 (herramienta → agente mínimo → agente de MAF → workflow de MAF → multiagente; MCP como transporte) | `Examples/06` (primer ejercicio), `07`, `08`, `10` | `Examples/06`: cuatro negativas y dos proveedores falsos; `07`: dos dobles de `IAprobador`, D1b, D1h, dos sesiones → 0; `08`: 400/401/403/200; R-LLM con `qwen3.5:4b` | pendiente (§7 se redacta con «workflow» a secas, ELV-01) |
| S-06 | Definiciones | cada sección con el molde «qué es, qué problema resuelve, qué no es» + Anexo C | Anexo C con las entradas de la consulta de definiciones (P2-14) | compuerta C5 ampliada: una definición por término; 0 «agentic workflow», «flujo agéntico», «flujo de trabajo» | pendiente |
| S-07 | Ejemplos y snippets representativos | §5–§8 (cada snippet una vez; §1 y §4 remiten) | `Examples/` según la tabla canónica | `Mesa/Ciclo-2/matriz-snippets.md` (RV-18, RV-19): ninguna fila «compila» sin archivo | pendiente (falta el entregable de P-29) |
| S-08 | Preguntas y respuestas explicativas | cada sección §0–§9 y el Anexo F | `Mesa/Ciclo-2/plan-de-preguntas.md`: 80 de origen, 72 vigentes, más PR-4 y PR-18 | conteo 80 = `conteo-preguntas.sh`; relectura RV-10 (cada respuesta transfiere criterio) | plan listo; respuestas pendientes de redacción |
| S-09 | Demo basada en Lab-E2E.WebBlazor | §9 | `Demos/MovilidadUrbana.Asistente/`: copia literal de `MovilidadUrbana.ApiWeb` en `59399ba` + `Agregado/`; D1–D6; página de chat | `PROCEDENCIA.md` con `diff -r = 0` y build de la copia sola; pruebas de §10.7 (P2-03, P2-04, P2-05, P2-12); `ConModelo/` D1, D2, D3 y D6 con N = 10 | pendiente |
| S-10 | LangGraph en el ecosistema .NET | §7 (N4 P4 y P5; tabla de diferencias «equivalente en capacidades, no en modelo de programación») | snippet de consumo por HTTP | ninguna: rotulado «no ejecutado» (no se levantó `langgraph dev`) | no ejecutada (rótulo) |
| S-11 | Reeditar el prompt sobre Mesa-Evaluadora | — | REED-16 | — | proceso (cumplida en REED-16) |
| S-12 | Composición de la mesa | — | `Mesa/Ciclo-1/00-Convocatoria.md` | — | proceso |
| S-13 | ¿Hace falta un experto más? | — | AH-01, AH-02 (convocatoria del ciclo 1) | — | proceso |
| S-14 | Relectura integral: edición, compresión y coherencia | toda la guía | relectura de REED-16 §10 | compuertas C1–C5, presupuesto ±20 % (`wc -w`), barridos de §6 y §10.4 del plan | pendiente (después de las compuertas) |
| S-15 | Apuntes, borradores, debates de la mesa | — | `Bitacoras/` y borradores en el área de trabajo de redacción | — | proceso |
| S-16 | Rutas de salida | — | guía, `Examples/`, `Demos/` en las rutas del plan §0.1 | compuerta C4 (listado de `Examples/` y `Demos/`, 0 enlaces rotos); sin `bin/` ni `obj/` en el árbol de la guía | proceso (rutas creadas, vacías) |
| S-17 | Probar todo y llevar registro | §8 (dos suites, cabecera R-LLM, R-LLM-1…5), Anexo E (receta del servidor, registros, tabla de cifras) | `Cableado/` y `ConModelo/` de cada ejemplo y de la demo | compuerta R-LLM: `grep -L "modelo@"` = 0 y `grep -L "estimando:"` = 0 en las salidas; build y test n/n | pendiente |

## 2. Preguntas de REED-16 §7

| Origen | Pregunta | Sección | Ejemplo o pieza | Prueba o R-LLM | Estado |
|---|---|---|---|---|---|
| §7.1 | ¿Qué es una capa de IA, qué responsabilidades tiene, qué del diagrama se sostiene? | §1 (principio rector), §3, §4 | `Examples/13`; diagrama único de P2-02 | prueba por reflexión con dos casos rojos (P-30), que reconoce `Agregado/Application` como núcleo | pendiente |
| §7.2 | Abstracciones para no atarse al proveedor; GA, preview y deprecados | §5, Anexo D | `Examples/01`, `02`, `03`, `12` | `Examples/01`: `OptionsValidationException` sin `TimeoutSegundos` y con `Permisos = 0`, 2001 caracteres → 0 llamadas, captura de cuerpo por las dos vías (P2-08); compuerta de versiones | pendiente |
| §7.3 | Pipeline RAG en .NET y cuándo no hace falta | §6 | `Examples/04` (ESC-02, métricas), `05` (`AyudaRag`, vías A y B, comparación pareada); demo D5 con `AyudaContextoFijo` | `Examples/04`: generador falso que reproduce métricas a mano, dimensión 512 frente a 1024 → no arranca; R-LLM con `qwen3-embedding:0.6b`; `Examples/05`: oro pareado con N y criterio escritos antes | bloqueada en parte: la frase comparativa CAG/RAG espera la corrida de `Examples/05` (§10.8); el resto pendiente |
| §7.4 | Qué es un agente, con qué marco; LangGraph | §7 | `Examples/06`, `07`, `08`, `10`; snippet LangGraph | pruebas de S-05; LangGraph «no ejecutado» | pendiente |
| §7.5 | Probar, observar y asegurar | §8 | `Examples/09`; tests de la demo; Anexo E | `Examples/09`: 4.º pedido → 503 con `Retry-After`; las cinco pruebas de P2-06; (a)–(c) de P2-05; `DelegatingHandler` sobre NDJSON fijo (P2-09); `Inconclusive` sin endpoint | bloqueada en parte: la subsección del pipeline espera las cinco pruebas de §10.7 (P2-15); el resto pendiente |
| §7.6 | Integración en Movilidad Urbana sin romper Domain → Application → Infrastructure; demo contra Qwen | §4, §9 | la demo | `PROCEDENCIA.md`; P-30 en verde sobre la demo; `ConModelo/` D1, D2, D3, D6 (N = 10, `qwen3.5:4b`) | pendiente |

## 3. Propuestas del PO PR-1…PR-22

Decisión y destino de P-06, con la numeración de P-07 y los cambios de la ronda 2.

| Origen | Propuesta | Decisión (P-06) | Sección | Ejemplo o pieza | Prueba o R-LLM | Estado |
|---|---|---|---|---|---|---|
| PR-1 | Actor «AI Engineer» | aplicada | §0 (objetivos por actor), §3 (perfil) | N0b PG-6 | lectura | pendiente |
| PR-2 | «Por qué ahora» | aplicada | §2 | N1b; fila nueva de P-33 (razonamiento conmutable) | lectura: todo hito con fecha y fuente (RV-09) | pendiente |
| PR-3 | Tres niveles | aplicar con ajuste | columna «nivel» de la tabla canónica de `Examples/`; §0 (ruta de lectura) | README de cada `Examples/NN` | lectura (la demo no se organiza en niveles) | pendiente |
| PR-4 | «¿Un agente o varios?» | aplicar | §7 (pregunta central); §1 (ramas D5–D6 del árbol) | plan de preguntas §3 | lectura | pendiente |
| PR-5 | Escalera de agentes | aplicada | §7 (llamada única → agente mínimo → agente de MAF → workflow de MAF → multiagente) | `Examples/06` → `07` → `10` | lectura; C5 | pendiente |
| PR-6 | Autoevaluación por escenario | aplicar | Anexo B | tres preguntas por ESC con respuesta y remisión | `grep -c "Autoevaluación por escenario"` ≥ 1; cinco ESC | pendiente |
| PR-7 | Primer agente sobre un sistema externo | **descartada** | — | — | — | descartada (RD-PO-1 caso único; servidor MCP de terceros. PR-20 cumple el objetivo) |
| PR-8 | CAG | aplicada | §6 | N3b; `Examples/05` (contexto fijo frente a RAG) | R-LLM del comparativo (`Examples/05`); con un modelo mayor, sólo en el segundo servidor y por la mesa | pendiente; comparativo bloqueado hasta correr `Examples/05` |
| PR-9 | Mirada de producto | aplicada con ajuste | §3 (métricas por escenario; «falso aceptado» sólo en el sentido 1, «no medido») | N0b §3.1 | `grep -n "falso aceptado"`; umbral sólo con tasa de la tarea (R-LLM-3d) | bloqueada (S1 de N0b §3.1.3: espera que toda aparición posterior a la nota de P-02 dé el sentido 1, §10.1) |
| PR-10 | Datos para la IA | aplicada con ajuste | §3 (marco), §6 (ingesta y fragmentación), §8 (conjuntos de evaluación) | oro de P-22 en `Examples/04` y `05` | oro versionado con su generador; «fuera de alcance» registrado donde falte fuente | pendiente |
| PR-11 | Despliegue visible | aplicada | §8, subsección propia | Anexo E (receta del servidor) | clon limpio con la receta del Anexo E | pendiente |
| PR-12 | Columna vertebral | aplicar | estructura P-07 (toda la guía); §1 como mapa | — | compuerta de encabezados (RV-04); presupuesto ±20 % | pendiente |
| PR-13 | Decisiones de arquitectura | aplicar | Anexo F (D-01…D-11) | N0b §3.4; D-06 (P2-05), D-07 (P2-14), D-11 (P-13, P2-03) | lectura: cada ADR con alternativas, criterio, consecuencia y pieza | pendiente |
| PR-14 | Objetivos de aprendizaje | aplicar | §0 | N0b §3.3.4 | lectura (un bloque por ACT-*) | pendiente |
| PR-15 | Cuatro preocupaciones | aplicar | — (no se publica) | lista interna de la relectura integral | relectura | lista interna |
| PR-16 | Principio rector «el modelo propone; la aplicación ejecuta, autoriza y valida» | aplicar | §1 | comentario en el código de cada ejemplo con herramientas (`06`, `07`, `08`) y de la demo | `grep -l "el modelo propone"` en esas carpetas | pendiente |
| PR-17 | IA sobre una app existente | aplicada | §4 (variante de ESC-04), §9 | demo: copia literal + `Agregado/` (P-17, P2-04) | `PROCEDENCIA.md` (`diff -r = 0`, build de la copia sola) | pendiente |
| PR-18 | ¿Framework o propio? | aplicar | §7 | plan de preguntas §3 (inventario MEAI / MAF; «las anotaciones no son un runtime», criterio propio) | lectura | pendiente |
| PR-19 | Cuadro MEAI / MAF / SK / SDK directo | aplicar | §5, «Métodos y marcos» | Anexo D (estado re-consultado) | compuerta de versiones (P-32) | pendiente |
| PR-20 | Primer ejercicio | aplicar | §7 | `Examples/06-Tool-Calling`: `contar_localidades`, `listar_localidades` | cuatro negativas (provincia fuera de catálogo, CP inválido, localidad inexistente, sesión ajena); dos proveedores falsos; R-LLM `qwen3.5:4b` por OllamaSharp y por `/v1` | pendiente |
| PR-21 | Lista de seguridad para herramientas | aplicada | Anexo B | — | lectura (cruce con CTRL-01…15) | pendiente |
| PR-22 | Anotaciones pareadas SK y MEAI | aplicar con ajuste | §5 y §7 | `Examples/12-Anotaciones-Pareadas` | `dotnet build` con la versión de SK de la compuerta; si SK no tiene GA ese día, se omite y se registra | pendiente |

## 4. Directivas del PO RD-PO-1…4 y MD-1…3

| Origen | Directiva (I-06) | Sección | Ejemplo o pieza | Prueba | Estado |
|---|---|---|---|---|---|
| RD-PO-1 | Movilidad Urbana es el único caso práctico | toda la guía | todos los `Examples/` y la demo | lectura: toda entidad de snippet, pregunta y ejemplo es `Localidad`, `Provincia`, `RespuestaDeEncuesta`, medios, sesiones | pendiente |
| RD-PO-2 | Nada de otros proyectos | toda la guía, `Examples/`, `Demos/` | — | barrido de términos de dominio ajenos + compuerta R-PRIV v2 (`patrones=0 identificadores=0 cabeceras=0`) | pendiente |
| RD-PO-3 | Los dominios inventados también se reemplazan | toda la guía | plan de preguntas (N2 P5, N5 P5 y N5 P7 ya reilustradas; 0 «reclamo» en las respuestas vigentes); reescrituras de N4 de P-26 (3) | barridos `GuessNumber`, `EchoTool`, `GetWeather`, `Comentario` = 0 (plan §6 y §10.4) | plan de preguntas listo; snippets pendientes |
| RD-PO-4 | Barrido mecánico en la relectura | — (relectura) | — | barrido de RD-PO-1…3 antes del cierre | pendiente (relectura integral) |
| MD-1 | Cliente móvil (teléfono por adb remoto, emulador) | §9 (vía móvil) | página de chat de la demo | navegador del emulador sobre la página de chat: ciclo de demo | no ejecutada (rótulo «no ejecutada» hasta el ciclo de demo) |
| MD-2 | Recursos por turnos | — | `<envoltorio-de-turnos>` (`build`, `<recurso-compartido>`, `<recurso-propio>`) | registros de turno en la bitácora | proceso |
| MD-3 | En el teléfono sólo paquetes propios | — | — | inventario de cierre | proceso |

## 5. Filas propias: N0b, N1b, N3b y Anexo F

| Origen | Contenido | Sección | Ejemplo o pieza | Prueba o R-LLM | Estado |
|---|---|---|---|---|---|
| N0b | Producto, datos para la IA, perfil y ADR | §0 (PG-1, PG-6; objetivos), §3 (PG-2, PG-3, PG-4; métricas por escenario), §8 (PG-5; D-09, D-10), Anexo F (PG-7; D-01…D-11) | plan de preguntas; Anexo F | lectura; juez como método sin demo (P-38, P2-11) | pendiente; lo que deriva de N0b §3.1.3 bloqueado (§10.1, fila S1) |
| N1b | Por qué ahora: hitos, línea de tiempo, carriles | §2 | fila nueva de razonamiento conmutable (P-33) con la card de Qwen3.5-4B | lectura: todo hito con fecha y fuente | pendiente |
| N3b | Contexto fijo, CAG, caché de prefijo, ventana | §6 | `Examples/05` (contexto fijo frente a RAG, contexto grande); `Examples/09` (`DelegatingHandler` de `prompt_eval_cached_count`); demo D5 | R-LLM de `Examples/05` (N ≥ 3 por tamaño, dato en la zona descartada); prueba de P-11 (4) con el prompt de 5134 tokens; RV-16 (`grep -n "93"`) | pendiente; frase comparativa bloqueada hasta correr `Examples/05` |
| Anexo F | Registro de decisiones D-01…D-11 | Anexo F | D-06 «Singleton fuera de Development…» (P2-05); D-07 con alternativas renombradas (P2-14); D-11 con `AccionPropuesta(tipo, datos)` y sin `AprobacionPendiente` (P2-03) | (a)–(c) de P2-05 en `Cableado/` de la demo y de `Examples/09` | pendiente |

---

## 6. Trazabilidad inversa: sección → origen (C3)

| Sección | Orígenes que la sostienen | Núcleos | Preguntas del plan (vigentes) |
|---|---|---|---|
| §0 | S-03, S-08, S-16; PR-1, PR-3, PR-14 | N0, N0b | 2 |
| §1 | S-04; §7.1; PR-4 (ramas D5–D6), PR-12, PR-16 | N1, N0 | 1 |
| §2 | S-02; PR-2 | N1b | 7 |
| §3 | S-04, S-06; §7.1; PR-1, PR-9, PR-10 | N0, N0b | 3 |
| §4 | S-01, S-04; §7.1, §7.6; PR-17 | N1, N0b | 5 |
| §5 | S-02, S-06, S-07; §7.2; PR-19, PR-22 | N2, N1 | 9 |
| §6 | S-01, S-04, S-07; §7.3; PR-8, PR-10 | N3b, N3, N1 | 16 |
| §7 | S-05, S-07, S-10; §7.4; PR-4, PR-5, PR-18, PR-20, PR-22 | N4, N1, N6 | 10 + PR-4 y PR-18 |
| §8 | S-07, S-17; §7.5; PR-10, PR-11 | N5, N0b, N2 | 12 |
| §9 | S-09, S-17; §7.6; PR-17; MD-1 | N6, N0b | 6 |
| Anexo A | S-07, S-17 (plantillas comentadas) | N2, N5 | — |
| Anexo B | PR-6, PR-21 | todos | — |
| Anexo C | S-06 | todos | — |
| Anexo D | S-02; §7.2 | todos | — |
| Anexo E | S-17; PR-11 | N5, N6 | — |
| Anexo F | PR-13 | N0b | 1 |

## 7. Controles C2 y C3

Compuertas de REED-16 §9.1 y del plan §7 y §10.5:

| Control | Cómo se verificó hoy | Resultado |
|---|---|---|
| C2: toda S-, §7.n y PR con sección | §1–§3 de este archivo: 17 S, 6 §7.n y 22 PR. Las filas sin sección son S-11, S-12, S-13, S-15 y S-16 (proceso, como en el esqueleto del plan §9), PR-7 (descartada) y PR-15 (lista interna, no se publica) | 0 filas de contenido sin sección |
| C2: `grep '\[C:'` sobre la guía = 0 | la guía no existe todavía | se corre al cerrar. La marca `[C: término de C1-32]` ya no se usa: la presidencia eligió «workflow» a secas (dictamen §5, ELV-01) |
| C3: toda sección con su S- o núcleo | §6 de este archivo: §0–§9 y Anexos A–F con al menos un origen | 0 huérfanas |
| Filas propias de N0b, N1b, N3b y Anexo F (P-28) | §5 de este archivo | 4 de 4 |
| Cuenta de filas | 17 + 6 + 22 + 4 + 3 + 4 | 56 filas de origen |
