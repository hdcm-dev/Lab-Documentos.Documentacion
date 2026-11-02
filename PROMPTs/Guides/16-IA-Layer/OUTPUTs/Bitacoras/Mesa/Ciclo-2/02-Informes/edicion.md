---
doc_id: BIT-16-MESA-C2-02-EDICION
doc_type: informe-de-especialista
title: Ciclo 2 · Informe de Edición de material bibliográfico
version: v1
status: entregado a la presidencia
origin: agent (especialista de edición, pedido del PO, E4)
last_review: 2026-10-26
traces: [BIT-16-04 v1, BIT-16-04 v0, Mesa/Ciclo-1/02-Informes/edicion.md, Mesa/Ciclo-1/07-Aplicacion-Y-Verificacion.md, Mesa/Ciclo-1/08-Cierre.md, REED-16 §11, Profile Study-Guide-Documentation, Rule-Markdown, Rule-Dual-Audience, M§3, M§8]
---

# Ciclo 2 · Edición de material bibliográfico

**Objeto**: `../../../04-Plan-De-Integracion.md` (v1, ESTRUCTURA APROBADA v1). Lo leí entero, con la v0 al lado para los puntos que cambiaron. Leí el ciclo 1 (el informe de edición ED-01…ED-07, la consolidación, los parches PAR-05, PAR-24 y la aplicación AJ-01…AJ-08) para no repetir lo que ya se corrigió. No leí los informes de este ciclo.

**Mandato**: estructura editorial de la v1: jerarquía, IDs, términos canónicos (la colisión «nivel A/B»), régimen de citas, presupuesto de extensión y navegabilidad de una guía en un solo archivo.

Las líneas («l.») son las de la v1 al 2026-10-26 (1003 líneas). Los conteos se hicieron con `grep`/`wc` sobre ese archivo.

## Índice

- [1. Hallazgos](#1-hallazgos)
- [2. Revisado y bien](#2-revisado-y-bien)
- [3. Solicitudes de convocatoria](#3-solicitudes-de-convocatoria)
- [4. Sobre los pendientes que me tocan](#4-sobre-los-pendientes-que-me-tocan)

## 1. Hallazgos

### ED2-01 · La aplicación del ciclo 1 dejó una contradicción y dos residuos — S1 · E2 · confianza 0.9

- **Ubicación**: §C §5 (l. 417) frente a §C Anexo F (l. 526) y §G.4 P-02 (l. 880); §A.3 (l. 95 y l. 97); encabezado (l. 16) frente a §H (l. 900).
- **Afirmación**: (a) el Anexo F dice «§5.8 desaparece como subsección: queda una remisión», pero la ficha de §5 tiene «§5.8 Decisión en curso: ADR-02» y P-02 ubica ahí el anticipo de ADR-02. La frase del Anexo F se escribió con la numeración de la v0, donde §5.8 era «Paquetes vigentes y obsoletos» (v0 l. 361). La renumeración pasó §5.9 a §5.8 y AJ-06 corrigió P-02, pero no esta frase. (b) §A.3 tiene dos párrafos de lectores seguidos: «**Lector principal**… Lectores secundarios: ACT-ARQ, ACT-OPS y ACT-SEC» y «**Lectores**: … y además **el lector que viene de Semantic Kernel**». El primero quedó del texto anterior y está incompleto. (c) El encabezado dice que la v1 resulta de «PAR-01…PAR-24 … más los ajustes AJ-01…AJ-08», y la fila v1 de §H dice «PAR-01…PAR-23» y no nombra los AJ.
- **Evidencia (E2)**: l. 417 «§5.8 Decisión en curso: ADR-02»; l. 526 «§5.8 desaparece como subsección»; l. 880 «anticipos de ADR-01 y ADR-02 en §4.6 y §5.8»; v0 l. 361 «§5.8 Paquetes vigentes y obsoletos … §5.9 Decisión en curso: D-02». M§3, coherencia: «no hay dos afirmaciones que no puedan ser ambas verdaderas». El cierre del ciclo 1 declara `contradicciones: 0`.
- **Impacto si no se corrige**: quien redacta el Anexo F puede borrar el anticipo de ADR-02 que pide §A.2 (I-04), o dejar las dos versiones. El registro de versiones no muestra los ajustes que nadie votó.
- **Propuesta de dirección**: que la frase del Anexo F nombre lo que de verdad desaparece (la lista de paquetes de §5, no §5.8); un solo párrafo de lectores en §A.3; que §H registre PAR-24 y AJ-01…AJ-08. Y una verificación mecánica que falte hoy: que toda remisión «§N.k» del plan apunte a una subsección que la ficha de §N declara con ese mismo número y tema.

### ED2-02 · «Nivel» tiene seis sentidos y las letras A/B/C, cinco series: T-A/T-B/T-C resuelve una sola colisión — S2 · E2 + E3 · confianza 0.85

- **Ubicación**: §E.2 (l. 623 y columnas «Nivel» y «Turno»), §E.5 (l. 664–672), §F.10 AC-3b (l. 818), §F.6 (l. 786–788), §F.9 («plan B»), §C §4.4 (l. 407), §C §13.8 (l. 497), plantilla de §C (l. 336), filas 05 y 12 de §E.2.
- **Afirmación**: la propuesta del cierre (pasar el turno a T-A, T-B, T-C) separa la dificultad del turno, pero «nivel» se usa en el plan con seis sentidos: (1) dificultad del ejemplo (B, I, A); (2) prioridad de turno (A, B, C); (3) nivel de encabezado («nivel 2», «nivel 3»); (4) «Dos niveles de contrato» (§4.4); (5) «ADR-07 **Nivel** de orquestación (escalera −1…3)», que es el *escalón*, término canónico del Anexo C; (6) el nivel de evidencia C del marco, que el cierre usa en «preguntas de nivel C». Las letras A/B/C nombran además el plan de embeddings (§F.6, el mismo de ESC-001), las variantes (A)/(B) de 05 y 12, los anexos A–G de la guía y las secciones A–H del plan.
- **Evidencia (E2 + E3)**: l. 623 «El **nivel** (B básico, I intermedio, A avanzado)»; l. 664 «Nivel de turno»; l. 818 «cada ejemplo de nivel A de §E.5»; l. 497 «ADR-07 Nivel de orquestación»; l. 787 «**B (por defecto)**». Contraejemplo construido: `10-Workflow-Y-Contraejemplo` tiene **Nivel A** (avanzado) y **Turno C** (sin modelo). Si alguien lee AC-3b con el «nivel» de la tabla que acaba de leer, entiende que 10 necesita un registro R-LLM, y 10 no llama al modelo. `02-Cambio-De-Adaptador` es «Nivel B» (básico) y «Turno B» (si queda presupuesto): la misma letra con dos sentidos en la misma fila. `05` compara «con (B) y sin (A)», es de turno C y corre en el Ollama propio, que es el «plan B». Con T-A/T-B/T-C, 05 sigue mezclando B de variante y B de plan, y ADR-07 sigue llamando «nivel» al escalón.
- **Impacto si no se corrige**: el control C5 (un término, un sentido) no pasa. AC-3b se puede leer de dos maneras. La guía hereda a ADR-07 y a §4.4 con «nivel» en el título, junto a un rótulo de nivel en cada ejemplo.
- **Propuesta de dirección**: que «nivel» tenga un solo sentido en la guía, la dificultad, escrita con palabras (básico, intermedio, avanzado) y no con letras. La prioridad de turno es interna de construcción: nunca llega a la guía, con un prefijo propio sin letras sueltas (p. ej. T1–T3). El plan de embeddings con prefijo (p. ej. EMB-A…EMB-C), las variantes de 05, 12 y 16 con un nombre que diga qué cambia («con prefijo reutilizado» o «un agente»), ADR-07 como «Escalón de orquestación» y §4.4 como «Dos contratos». Que el Anexo C registre «nivel» con su único sentido y que la verificación de C5 busque `\b[Nn]ivel` y las letras sueltas entre paréntesis.

### ED2-03 · Las remisiones a secciones del plan (§A–§H) dentro de las fichas chocan con los anexos A–G de la guía — S2 · E2 · confianza 0.85

- **Ubicación**: tabla de OA de §A.3 (l. 104, l. 120), que es «la única fuente» y abre la Parte 0; fichas de §C §0, §2, §5, §12, §14, Anexo A; tabla «Una casa por pieza» (l. 356). Son unas 30 remisiones `§[A-H]` entre l. 330 y l. 530.
- **Afirmación**: las fichas de §C describen contenido de la guía, pero remiten a secciones del plan con letras que en la guía son anexos. «demo §F.9» (OA-O2) en la guía apunta al Anexo F, *Versiones*, no a cómo se corre la demo. «la tabla de objetivos de §A.3» (§0.1) apunta al Anexo A, *Plantillas*. «la plantilla de encabezados de §C» (§0.4) apunta al Anexo C, *Glosario*. «tabla de §E.2» (§0.5), «variables canónicas (§E.1)» (§5.5 y Anexo A §12) y «presupuesto de §E.5» (§14.6) apuntan al Anexo E, *Laboratorio*. «Remiten: §B.5» (l. 356) es una remisión de la guía a una sección del plan.
- **Evidencia (E2)**: l. 120 «OA-O2 … | §5.5, §5.7, §12.5 | demo §F.9»; l. 366 «§0.1 … la tabla de objetivos de §A.3, la única fuente»; l. 370 «(tabla de §E.2)»; l. 417 «§5.5 Registro en DI y variables canónicas (§E.1)»; l. 521 «variables canónicas de §E.1»; l. 506 «presupuesto de §E.5». REED-16 §11 (l. 429): «La guía no referencia la bitácora». La v1 no tiene ninguna regla para traducir esas remisiones.
- **Impacto si no se corrige**: si la tabla de OA se copia tal cual, como manda §A.3, el lector de ACT-OPS va al anexo de versiones a buscar cómo se corre la demo. Cada redactor resuelve a su modo a dónde va «§E.1» (al Anexo E, a §5.5 o a §12.5), y la casa única de las variables queda sin definir en la guía.
- **Propuesta de dirección**: separar en el plan las dos clases de remisión, con un prefijo explícito para las del plan («plan §E.1») y el destino en la guía para todo contenido que pasa a la guía (p. ej. «variables canónicas: casa §5.5, remiten §12.5 y Anexo E»). Una compuerta de redacción: `grep -nE "§[A-H](\.|\b)"` sobre la guía da 0, y la guía nombra los anexos sólo como «Anexo X».

### ED2-04 · Régimen de IDs y citas: [R-nn] choca con los riesgos R-0n, falta la cita en el cuerpo y no se puede citar una cifra del laboratorio — S3 · E2 + E4 · confianza 0.8

- **Ubicación**: §C Anexo D (l. 524); §G.2 R-01…R-08 (l. 843–854); fichas §4.1 (l. 407) y §12.4 (l. 486); §F.10 AC-9 (l. 824); §C §12.7 y §5.7; §D (l. 537) frente al changelog.
- **Afirmación**: (a) la guía numera sus referencias `[R-nn]` (Anexo D), y el plan llama R-01…R-08 a sus riesgos y los cita dentro de fichas que pasan a la guía: «sin hito: R-07» (§4.1) y «servidor ajeno: R-04» (§12.4). En la guía, «R-04» es una referencia bibliográfica. Conviven además R-PRIV, R-LLM, R-HOST y R-EVID. (b) PAR-05 fijó la forma de la entrada del Anexo D, pero no **cómo se cita en el cuerpo** (marca, enlace, posición), que era la parte (a) de la dirección de ED-06. (c) AC-9 admite cifras de dossiers «no re-ejecutadas», y §12.7 y §5.7 las usan (474,7 s de N3b X3; 11–24 s de Sondeo §8). Pero la guía no puede referenciar la bitácora, y el plan no dice cómo se respalda en la guía una cifra que sólo existe en un dossier. (d) No hay una lista de qué familias de ID llegan al lector (OA-, ADR-, PD-, ESC-, CTX-, ACT-, R-nn) y cuáles no (H-, X-, PAR-, AJ-, DEP-, SUP-, P-, Nn §, T1–T7). La única verificación es ad hoc (PAR-11 sobre §13–§14). El mismo ítem se escribe PR-1 en §D y PR-01 en el changelog: un `grep "PR-1"` toma también PR-10…PR-19.
- **Evidencia (E2 + E4)**: l. 524 «forma única `[R-nn] Autor…` … El ID `R-nn` es de la guía»; l. 407 «sin hito: R-07»; l. 486 «(… R-04)»; l. 824 «cada cifra que viene de un dossier lleva su estado (re-ejecutada en la construcción / no re-ejecutada)»; REED-16 §11 l. 429; ED-06 del ciclo 1, dirección (a) «definir el formato de cita en el cuerpo». Rule-Dual-Audience: «IDs estables con prefijo».
- **Impacto si no se corrige**: referencias ambiguas en la guía. Cifras del laboratorio sin fuente visible o con una remisión prohibida a la bitácora. Verificaciones por `grep` que cuentan mal.
- **Propuesta de dirección**: un prefijo de referencia que no se use en otra serie (p. ej. `[REF-nn]`), o renombrar los riesgos (RSG-nn). Fijar la marca de cita en el cuerpo y una regla para las cifras no re-ejecutadas: o se re-ejecutan y se citan como evidencia de `Examples/` o `Demos/`, o no entran en la guía. Una tabla de familias de ID «llega o no llega al lector», con un `grep` de compuerta sobre la guía. Una sola grafía por ID.

### ED2-05 · Un archivo de ~44.000 palabras sin tabla de contenido, con anclas que dependen del orden y con seis secciones fuera de la plantilla — S3 · E2 + E3 + E4 · confianza 0.75

- **Ubicación**: §C Parte 0 (l. 363–372); plantilla de encabezados (l. 334–343); «Una casa por pieza» (l. 349); fichas de §1–§3 y §13–§15; ficha de §8 (l. 448).
- **Afirmación**: (a) la Parte 0 es «README del Profile», pero no incluye la **tabla de contenido** de la guía, que es lo que el Profile define como README. §0.5 es el mapa de `Examples/` y de la demo, no de la guía. (b) Toda la deduplicación se apoya en «remisión por ancla», y el plan no fija un régimen de anclas. La plantilla repite los mismos títulos de nivel 3 («Aplicación por escenario», «Ejemplos», «Preguntas guía», «Criterios de calidad y antipatrones», «Qué decisión toca y plantilla») en ocho secciones, y en Markdown estilo GitHub los títulos repetidos se desambiguan por orden de aparición. (c) La plantilla cubre §4–§8 y §10–§12, y §9 es excepción declarada. §1–§3, §13, §14 y §15 no tienen forma declarada, aunque sus fichas listan preguntas guía, escenarios y diagramas. Tampoco se fija en qué nivel de encabezado van las Partes ni los agrupadores «Escalón 1/2/3» de §8.
- **Evidencia (E2 + E3 + E4)**: Profile, piezas: «README | Tabla de contenido de todo lo generado, con la ruta de lectura sugerida»; Rule-Markdown l. 11–12: «Encabezados jerárquicos sin saltar niveles ni títulos vacíos» y «tabla de contenidos cuando el tamaño lo justifique»; Rule-Dual-Audience l. 23: «Encabezados y anclas predecibles». Contraejemplo construido: con la plantilla aplicada, el ancla de las preguntas guía de §5 es `#preguntas-guía-1` y la de §12 es `#preguntas-guía-7`. Si se inserta una subsección temática nueva con ese título, o si §4 pierde la suya, se corren todas las anclas que siguen, y las remisiones de «Una casa por pieza» y de §15 («remisión a la sección») quedan rotas sin que nada falle. Con `## §N Título`, el ancla depende del título completo, que cambia en la redacción.
- **Impacto si no se corrige**: el lector de un solo archivo no tiene desde dónde saltar. Las remisiones, que el ciclo 1 eligió como mecanismo para no duplicar, se rompen en silencio. Seis secciones se redactan sin forma común.
- **Propuesta de dirección**: una §0.0 con la tabla de contenido de la guía (Partes, §N y anexos), generada y no escrita a mano. Anclas explícitas y estables por pieza (un id corto por sección y por bloque de la plantilla), declaradas en §0.4. Una verificación mecánica de que toda remisión resuelve a un ancla existente. Forma declarada (plantilla, variante o excepción fundada) para §1–§3 y §13–§15, y el nivel de las Partes y de los agrupadores de §8.

### ED2-06 · El presupuesto no tiene regla de conteo y la Parte 0 no entra en su tope — S3 · E3 · confianza 0.65

- **Ubicación**: §C, presupuesto de extensión (l. 361); ficha de la Parte 0 (l. 363–372); tabla de OA (l. 103–127).
- **Afirmación**: (a) el tope excluye «código ni tablas de versiones» y no dice si cuentan las demás tablas, el mermaid, los recuadros ni las respuestas de las preguntas guía. La relectura S-14, que recorta si una parte pasa su tope en más de 15 %, no tiene una medida reproducible. (b) La Parte 0 (≤ 1.200; con el 15 %, 1.380) debe contener la tabla de 25 OA, que §A.3 manda copiar como «la única fuente», las rutas por actor, los prerrequisitos, «el caso Movilidad Urbana en una página», cómo leer cada sección y la evidencia, y el mapa de 17 ejemplos y 7 pasos de la demo.
- **Evidencia (E3)**: `sed -n '/^| OA-0.1/,/^| OA-SK1/p' | tr '|' ' ' | wc -w` da **551 palabras** sólo en las filas de OA. Un mapa de 24 filas, aun en tres columnas, son ~280 palabras. «En una página» son ~400 palabras. Las rutas y §0.4 en el plan ya suman ~250. Total estimado: ~1.480, que pasa los 1.380 con la tabla de OA contada. Si las tablas no cuentan, el tope es holgado y no mide nada.
- **Impacto si no se corrige**: el primer recorte de S-14 cae sobre la Parte 0, la de orientación, o se registra «motivo» por sistema y el presupuesto deja de servir como límite.
- **Propuesta de dirección**: una regla de conteo ejecutable (qué se cuenta y con qué script) y un tope de la Parte 0 coherente con lo que se le asigna, o pasar el mapa de ejemplos al Anexo E y dejar en §0.5 una remisión. Pregunta para la mesa: ¿alcanzan 4.500 palabras para la Parte VI, con 12 ADR de seis campos cada uno (alternativas con fuente, criterio, decisión, consecuencias, confianza, cuándo deja de valer) más las seis subsecciones de §14?

### ED2-07 · El glosario no cubre el vocabulario que la guía define y los títulos usan alias — S3 · E2 · confianza 0.8

- **Ubicación**: §C Anexo C (l. 523); §0.3 (l. 368); §3.0 y §4.2 (fichas de §3 y §4); §B.3 diagrama K1 (l. 242); §C §6 propósito (l. 426); §C §8.2 (l. 448); §C §13.8 (l. 497); §C §5 escenarios (l. 418).
- **Afirmación**: (a) el Anexo C, que es la fuente del control C5, no incluye términos que la guía promete definir: *puerto*, *adaptador* y *raíz de composición* (§0.3(b) promete explicarlos en §4.3, y la tesis gira sobre ellos), *modelo* (el primero de los doce de §3.0), *token*, *temperatura*, *alucinación* y *grounding* (§4.2), *MCP*, *oráculo*, *línea base*, *entrada distinta*, *spotlighting* y *nivel*. La dirección de ED-02 (sumar el vocabulario del marco: puerto, adaptador, propuesta) quedó a medias. (b) Los títulos usan alias en lugar del término canónico: «§8.2 **Tool calling**: el modelo pide» (canónico: *llamada con herramientas*), «ADR-07 **Nivel** de orquestación» (canónico: *escalón*), el escalón 1 del diagrama de §B.3 como «**prefijo cacheado** («CAG de servicio»)» (canónico: *prefijo estable*; AJ-05 lo corrigió en §A.2, no en §B.3) y el propósito de §6 con «**CAG** en su versión de servicio».
- **Evidencia (E2)**: l. 523 (lista completa del glosario: no figura ninguno de los términos de (a)); l. 368 «qué se explica en la guía: puerto, adaptador y raíz de composición (§4.3)»; l. 448 «§8.2 Tool calling»; l. 242 «prefijo cacheado»; l. 426 «CAG en su versión de servicio». Conteo en la v1: *tool calling* 5, *llamada con herramientas* 6; *salida tipada* 7, *salida estructurada* 7. REED-16 §9.1, C5; Rule-Dual-Audience: «los sinónimos se registran como alias del término canónico».
- **Impacto si no se corrige**: C5 se verifica contra una lista que no tiene los términos de la tesis. Los títulos, que son lo que se ve en la tabla de contenido, enseñan el alias.
- **Propuesta de dirección**: que el glosario sea un superconjunto de §3.0, §4.2 y del vocabulario del marco (§B), con la sección donde se define cada término. Que títulos y definiciones usen siempre el canónico, con el alias sólo en el glosario y en la primera mención. Una verificación de C5 que busque los alias en los títulos.

## 2. Revisado y bien

- **Renumeración de ejemplos**: la tabla v1↔v0 de §E.3 coincide con las 12 anotaciones «(v0 nn)» de §E.2. La columna «Turno» de §E.2 coincide con las listas de §E.5 (A, B y C) en los 17 ejemplos.
- **Rutas de lectura (ED-07 del ciclo 1)**: comprobé por actor que la ruta de §0.2 contiene la sección de cada OA del actor (ACT-ARQ, ACT-OPS, ACT-SEC, SK) y que los OA de «Todos» caen en el tronco común. La ruta ya no contradice la tabla.
- **Casa única y plantilla (ED-01, ED-04, ED-06(b))**: hay una plantilla de encabezados con la excepción de §9 declarada y una sección de muestra (§5). La tabla «Una casa por pieza» asigna dueño a cada tabla y diagrama repetidos. El Anexo F es la única tabla de versiones y §E.1 lo dice. El presupuesto suma bien: 43.700.

## 3. Solicitudes de convocatoria

- **Didáctica**: si la mesa saca el mapa de ejemplos de la Parte 0 (ED2-06) o fija una forma para §1–§3 y §13–§15 (ED2-05), conviene que didáctica decida qué orientación necesita el lector antes de §1.

## 4. Sobre los pendientes que me tocan

- **Colisión «nivel A/B»**: ver ED2-02. La propuesta T-A/T-B/T-C es necesaria y no alcanza: deja cinco de los seis sentidos de «nivel» y cuatro de las cinco series de letras.
- **AJ-05 y AJ-06**: AJ-06 dejó sin corregir la frase de §5.8 del Anexo F (ED2-01). AJ-05 corrigió «CAG» en §A.2, pero no en §B.3 ni en el propósito de §6 (ED2-07). Los OA asignados por AJ-05 y AJ-08 son materia de didáctica; no los juzgo.
