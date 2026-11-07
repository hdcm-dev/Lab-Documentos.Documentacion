# Folio de composición — voto del jurado (ronda de estructura)

**Rol:** Jurado (composición del panel)
**Fecha:** 2026-11-07
**Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas:** cabecera y §0 (líneas 1–111, incluido el Mapa de carga), §2 (§2.1–§2.3), §3 (§3.1–§3.4), §4, §7, §8
**Rule-Mesa 1.1 §3.4 leída:** sí (§3.4.1–§3.4.5: núcleo permanente, catálogo variable por señal, trabajo a ciegas, ad hoc con carta de mandato, techo de cinco variables o ad hoc, descarte con motivo, empate convoca)
**Caso:** 0001-guia-de-estudio-ia-model — diseño del temario, marco de referencia y estructura de una guía de estudio sobre modelos de IA. Clase de objeto: diseño de una norma o decisión.
**Pedido de origen:** `PROMPTs/Guides/18-IA-Model/01-Crear-Study.Guide.md` (leído entero).

---

## 1. Problema de cupo y cómo lo resuelvo

El catálogo propuesto por la presidencia trae **ocho** comisiones; el techo de `Rule-Mesa` §3.4.5 es
**núcleo más cinco** entre variables y ad hoc por ciclo. El pedido además **manda** incluir analistas en
sistemas y arquitectos de sistema y modelos IA, editores de material bibliográfico/académico/de libros y
publicadores científicos: esos roles **no se descartan**; si no caben como variables, entran ad hoc con
carta de mandato. Resuelvo el cupo por **fusión temática** (afinidad y dependencia fuerte entre señales,
como pide la regla de descomposición del propio pedido), sin ningún descarte de rol mandado y sin
descarte de señal del dominio: toda señal del pedido queda cubierta por alguna convocada.

Resultado: **tres comisiones variables + dos ad hoc = cinco**, dentro del techo.

## 2. Convocadas — comisiones variables (catálogo, por señal)

### V1 — Comisión Fundamentos, arquitecturas y panorama de modelos
*(fusión de las propuestas 1 «Fundamentos NLP/LLM y arquitecturas» y 5 «Panorama de modelos, multimodales y tendencias»)*
- **Mandato (una línea):** proponer y defender el mapa conceptual del temario: de NLP y tokens a transformers, arquitecturas, familias de modelos (incluidos multimodales) y el panorama/tendencias que los ordena.
- **Competencia:** NLP, LLM, arquitecturas (transformer y variantes), modelos generativos y multimodales, taxonomía de modelos open source, tendencias y estándares de la industria.
- **No-competencia:** procedimientos de entrenamiento/ajuste, operación local de inferencia, decisiones editoriales o pedagógicas.
- **Señal (citas del pedido):** «conceptos como transformers, que operan», «entender las arquitecturas que hay», «modelos multimodales», «Es importante basarse en las tendencias del mercado y los estandares de la industria».
- **Motivo de la fusión:** para la ronda de estructura, fundamentos y panorama responden la misma pregunta —qué conceptos existen y en qué orden se presentan—; separados duplicarían el mismo mapa (dos fuentes para la misma competencia, prohibido por `Rule-Mesa` §3.4.2).

### V2 — Comisión Entrenamiento, ajuste fino y métricas
*(propuesta 2, sin cambios)*
- **Mandato (una línea):** definir qué lugar y qué profundidad tienen en el temario el entrenamiento, el ajuste fino y las métricas de evaluación, con progresión apta para quien nunca vio el tema.
- **Competencia:** preentrenamiento, fine-tuning, datasets, métricas de evaluación de modelos.
- **No-competencia:** despliegue e inferencia local, edición del material, arquitectura de sistemas.
- **Señal (citas del pedido):** «entrenarlos», «metricas».

### V3 — Comisión Inferencia local, RAG y bases vectoriales
*(fusión de las propuestas 3 «Inferencia y despliegue local» y 4 «RAG y bases vectoriales»)*
- **Mandato (una línea):** estructurar el tramo práctico de la guía —montar, descargar y correr modelos (Qwen con Ollama), motor de inferencia, embeddings, bases vectoriales y RAG— como eje de ejemplos ejecutables.
- **Competencia:** motores de inferencia, Ollama, modelos Qwen, cuantización, embeddings, bases de datos vectoriales, RAG.
- **No-competencia:** teoría de arquitecturas más allá de lo que el ejemplo necesita, entrenamiento, pedagogía editorial.
- **Señal (citas del pedido):** «los pasos necesarios para montar modelos, descargarlos», «motor de inferencia», «base de datos vectoriales», «Actualmente tenemos corriendo diferentes modelos de qween».
- **Motivo de la fusión:** ambas viven en el mismo entorno práctico del equipo (modelos locales con Ollama); el RAG es el caso de uso que da sentido a la base vectorial en una guía introductoria, y separadas se pisarían en los mismos ejemplos.

## 3. Convocadas — ad hoc con carta de mandato (roles mandados por el pedido)

Los roles que siguen no tienen señal de catálogo en `Rule-Mesa` §3.4.2 aplicable a este objeto como
especialidad propia, pero el pedido los **manda** («inclui analistas en sistemas y arquitectos de sistema
y modelos IA, editores de material bibliograficos, académicos y de libros, y tambien publicadores
cientificos»). No se descartan: entran **ad hoc con carta de mandato** (`Rule-Mesa` §3.4.4), con señal
citada, competencia, no-competencia, tope de hallazgos y condición de disolución en la carta que emita la
presidencia.

### A1 — Comisión Arquitectura de sistemas IA y análisis de sistemas
- **Mandato (una línea):** verificar que el temario integre la vista de sistema (componentes, flujos, dependencias entre modelo, motor, datos y aplicación) y que los núcleos conceptuales tengan cohesión e integración como exige el pedido.
- **Competencia:** análisis de sistemas, arquitectura de soluciones con modelos IA, descomposición en núcleos conceptuales y documento de cohesión global.
- **No-competencia:** contenido interno de cada tema (eso es de V1–V3), estilo editorial, veredictos de evidencia.
- **Señal (cita del pedido):** «inclui analistas en sistemas y arquitectos de sistema y modelos IA» (rol mandado); «Identifica y agrupa las ideas… formando núcleos conceptuales coherentes… Mantén además un documento de cohesión global».

### A2 — Comisión Edición académica, pedagogía y publicación científica
*(fusión de las propuestas 7 «Edición académica y pedagogía» y 8 «Publicación científica y evidencia»; ambos roles mandados quedan dentro, ninguno se descarta)*
- **Mandato (una línea):** juzgar la estructura como material didáctico y de referencia —progresión para quien no sabe nada, preguntas guía formadoras de criterio, índice, autocontención— y fijar el marco de evidencia: qué tipo de fuente verificable respalda cada clase de afirmación de la guía.
- **Competencia:** edición de material bibliográfico, académico y de libros; diseño pedagógico; normas de citado y publicación científica; criterios de evidencia verificable.
- **No-competencia:** corrección técnica del contenido de IA (eso es de V1–V3), arquitectura de sistemas.
- **Señal (citas del pedido):** «editores de material bibliograficos, académicos y de libros», «publicadores cientificos» (roles mandados); «preguntas guías formadoras de conceptos que formen criterio articuladas con respuestas explicativas»; «Toda afirmación debe estar respaldada por evidencia verificable»; «No inventar información».
- **Motivo de la fusión:** en la **ronda de estructura** ambos roles juzgan el mismo artefacto (el esqueleto de la guía) con la misma pregunta de fondo —¿esta estructura produce un material que enseña y que se puede citar?—; todavía no hay contenido que verificar afirmación por afirmación. La carta nombra las dos competencias y las dos no se diluyen: si en la ronda de contenidos el volumen de verificación de evidencia lo exige, recomiendo **desdoblarlas** en dos comisiones para ese ciclo (la fusión rige para esta ronda, no para el proceso).

## 4. Núcleo permanente (no cuenta contra el techo)

- **Refutador** — entra último, ataca la lectura dominante y, por tratarse del diseño de una norma/decisión, ataca sobre todo el costo de aplicar la estructura propuesta (anti-patrón «refutador que sólo ataca la evidencia», norma §7).
- **Jurado** — este rol: compone el panel y vota el veredicto; no emite hallazgos y no entra en el denominador de rendimiento (norma §4, «Criterio de corte»).

## 5. Roles mandados que quedan fuera del panel de comisiones (asignación explícita a otra fase)

El pedido manda incluirlos en el **proceso**; no emiten hallazgos, así que no ocupan cupo del panel y se
asignan explícitamente:

- **Bitacorista** (rol mandado: «bitacoristas para que ayuden ante consulta de avances e historial por parte de los subagentes») — **fuera del panel**, asignado a la **fase de registro de cada ronda**: la presidencia despacha un agente bitacorista por fase que mantiene las bitácoras en `OUTPUTs/Bitacoras` y responde consultas de avance e historial. No vota ni emite hallazgos.
- **Entrevistador** — fuera del panel, **fase de cierre**: destila las dudas que sobrevivan a la mesa para elevarlas al PO en lote (la composición del panel nunca se le eleva, norma §3.1).
- **Secretaría** — fuera del panel, incorporación de folios y cuenta de piezas al cierre, bajo la presidencia.

## 6. Descartes

**Ninguna comisión se descarta.** Las ocho propuestas quedan cubiertas así: 1 y 5 fusionadas en V1; 2 = V2;
3 y 4 fusionadas en V3; 6 = A1; 7 y 8 fusionadas en A2. Ningún rol mandado por el pedido sale del proceso.
No hay señales postergadas para el ciclo siguiente: todas las señales citadas tienen comisión asignada en
esta ronda.

## 7. Empates

No hubo empates. Si en la consolidación surge una solicitud de convocatoria con señal nueva, rige «empate
convoca» (`Rule-Mesa` §3.4.5) y la ronda única de convocatoria en caliente (`Rule-Mesa` §3.4.3).

## 8. Voto

**APRUEBO** la composición para la ronda de estructura: núcleo permanente (refutador, jurado) + tres
variables (V1, V2, V3) + dos ad hoc con carta de mandato (A1, A2) = cinco, dentro del techo de
`Rule-Mesa` §3.4.5. Bitacorista, entrevistador y secretaría quedan asignados fuera del panel como declara
el §5 de este folio. Condición: las cartas de A1 y A2 salen con señal citada, única pregunta, competencia,
no-competencia, tope de hallazgos y condición de disolución (`Rule-Mesa` §3.4.4); un ad hoc sin carta no
emite hallazgos válidos.
