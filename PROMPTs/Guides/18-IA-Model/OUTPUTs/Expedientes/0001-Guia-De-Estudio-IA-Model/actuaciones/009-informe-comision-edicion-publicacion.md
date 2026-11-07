# Informe — Comisión de Edición académica, pedagogía y publicación científica

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-07 |
| Autor | Comisión de Edición académica, pedagogía y publicación científica (ad hoc) |
| Corrige | — |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | cabecera y §0 (líneas 1–111), la carta (instancia de §5.2), §2.2, §3.2, §3.3, §4 (§3.4 cargada por venir en la misma unidad de lectura de §3) |
| Otros documentos cargados | Cadena-De-Consecuencias 2.0 §2 (antes de recomendar entre opciones); pliego operativo (evidencia/002); Profile Study-Guide-Documentation; RuleSet-Study-Guide (las nueve Rules que lista); ia-db/README.md e ia-db/indexes/10_Convenciones-y-Glosario.md del repo destino |

Clase de objeto: diseño de una norma o decisión (temario y marco de la guía); clase descartada: corpus
documental. Rige para esta comisión la fila «Diseño de una norma o decisión» de §2.2: fuentes externas
con autor y año o norma con número, sin cláusulas inventadas; si no hay certeza del apartado, la fuente
se cita sin apartado. Trabajé a ciegas: no leí informes de otras comisiones. Las rutas de archivos del
caso van relativas al expediente o al repo destino (`Lab-Documentos/`).

---

## 1. Hallazgos sobre el enunciado y el objetivo

Lectura de niveles: la de la carta (P0 viola restricción dura; P1 retrabajo del conjunto o ejemplo
inviable; P2 pérdida acotada; P3 claridad). Anclas E1–E4/C según el pliego §2.

### H-EDI-01 · P1 · E1 — «Ollama» entra fijo al objetivo sin origen en el pedido

Lo que la carta da por fijo sin origen, mi primer hallazgo. La carta manda ejemplos «operables en un
entorno local con Ollama/modelos Qwen cuando aplique»; el pedido nombra «modelos de qween» corriendo
(contexto, un hecho), pero no nombra Ollama en ninguna parte. Afirmación de no colisión de término,
anclada en E1 (pliego §2, regla de anclaje 2):

```text
$ grep -in 'ollama' actuaciones/001-presentacion-pedido-guia-de-estudio-ia-model.md
(sin salida; código de retorno 1)
```

- Impacto si no se corrige: el temario ata todos los ejemplos a una herramienta que quien pidió no mandó;
  si el entorno real del PO fuese otro (llama.cpp, vLLM, transformers), el retrabajo es de todos los
  núcleos con ejemplos.
- Dirección de la corrección: tratar «Ollama» como agregado marcado (§3.1 de la norma: lo que no tiene
  origen es agregado y sale marcado a quien pidió); el marco de referencia declara el entorno de ejemplos
  como decisión propuesta, no como dato del pedido. Va también como duda al cierre.

### H-EDI-02 · P1 · E2 — El pedido manda a la vez un archivo único y un cuerpo multi-documento

«Elaborar una guía en `/LAB/Lab-Documentos/Lab-Documentos/Guides/IA/IA-Model/IA-Model-Guide.md`»
(folio 001, bloque testimonio, sección «Solicitudes») contra «documentando cada uno [núcleo] en un
documento Markdown independiente. Mantén además un documento de cohesión global» (mismo folio, sección
«Reglas») y el Profile («Los ejes se definen una sola vez, en documentos propios», «README | Tabla de
contenido de todo lo generado»). Dos cláusulas del propio pedido piden formas documentales
incompatibles si la primera se lee como «todo en un archivo».

- Impacto: la estructura documental entera depende de esta lectura; elegir mal es retrabajo total
  (re-seccionado, re-anclado de citas internas, re-indexado).
- Dirección: leer la ruta pedida como **portada-índice** del cuerpo (la lectura que menos agrega: respeta
  el literal de la ruta y las Reglas a la vez); los núcleos en documentos hermanos bajo
  `Guides/IA/IA-Model/`. Cadena de consecuencias corrida en §4 de este informe.

### H-EDI-03 · P1 · E2 — Exhaustividad enciclopédica contra audiencia principiante, sin niveles de lectura

«toda los conceptos relacionadas que hacen al conocimiento de la tematica» y «debe servir de consulta y
tambien de referencia» (folio 001, «Contexto» y «Solicitudes») contra «un estudiante que aun no conoce
del tema» (folio 001, «Objetivo»). Romper la audiencia principiante es restricción dura (carta, lectura
de P0): un temario que intente la exhaustividad en orden enciclopédico la rompe; uno que la recorte
rompe «toda los conceptos». La tensión se resuelve sólo con niveles de lectura declarados, que ni el
pedido ni la carta fijan.

- Impacto: sin esto, cada comisión de dominio escribirá a una profundidad distinta y el conjunto no
  servirá ni de iniciación ni de referencia; retrabajo del conjunto.
- Dirección: el marco de referencia declara **dos rutas de lectura** sobre los mismos documentos —
  itinerario formativo secuencial (con prerrequisitos declarados por documento) y acceso de referencia
  por mapa conceptual/glosario—, y cada documento abre con «qué necesitás haber leído antes». Es la
  segmentación y el señalamiento que la investigación en aprendizaje multimedia sostiene (Mayer, 2021;
  fuente en §5).

### H-EDI-04 · P2 · E2+E4 — Evidencia verificable exigida sin norma de citado declarada

«Toda afirmación debe estar respaldada por evidencia verificable» (folio 001, «Reglas») y rige
`Rule-Evidences.md` (RuleSet-Study-Guide; el Profile la cita en «Trazable»), pero ninguna pieza fija
**cómo se cita**: formato de referencia, qué exige cada tipo de fuente (paper, doc oficial, norma), ni
cómo se marca el criterio propio. La casa ya tiene aparato: frontmatter `origin`/`confidence` («no son
decorativos: son el mecanismo por el cual un lector distingue lo verificado de lo inferido», ia-db
índice 10 §1.1) y marcas de procedencia [F]/[C]/[E]/[V].

- Impacto: citación heterogénea entre núcleos escritos por comisiones distintas; pérdida acotada
  (se corrige en edición, pero a costo creciente).
- Dirección: el marco de referencia incluye un `Convenciones.md` que fija: sistema autor-año en prosa
  (estilo APA 7.ª ed., 2020) con lista de referencias por documento; norma con número para estándares
  (p. ej. ISO 690:2021 como respaldo del formato bibliográfico); URL y fecha de consulta para docs
  oficiales de herramientas; y las marcas de la casa. Mini-cadena en §4.

### H-EDI-05 · P2 · E1+E2 — El destino es una carpeta de material importado y el pedido no prevé la integración al índice de la casa

`Guides/IA/` figura en la ia-db del destino como **material importado (IMP)**, «sin frontmatter»
(índice 10, tabla de siglas y §1.2). Verificado sobre el clon de trabajo del repo destino:

```text
$ ls Lab-Documentos/Guides/IA/
Claude-Guide.md  Dot-Net-Integration-AI-Layer-Guide  references  SDD-Guide
```

El pedido manda la guía a `Guides/IA/IA-Model/` (subcarpeta propia: bien) pero no dice nada de
frontmatter normado ni de la fila que la guía necesita en `ia-db/indexes/` (rige Indexing 2.1 por el
contrato de entrada).

- Impacto: la guía nueva heredaría de hecho el estado «importado sin convenciones» de su carpeta madre;
  el corpus queda con una guía propia invisible para su propio punto de entrada.
- Dirección: los documentos de la guía llevan el frontmatter normado de la casa (doc_id, doc_type,
  origin, confidence, last_review, audience, traces — ia-db 10 §1.1) y el plan incluye, como tarea de
  publicación, el alta en la ia-db. No es motivo para mover la ruta: la ruta es literal del pedido.

### H-EDI-06 · P2 · E4 — Dominio volátil sin política de vigencia

El objeto de la guía (modelos, herramientas, familias Qwen) se renueva en ciclos de meses: la familia
Qwen3 es de mayo de 2025 (Qwen Team, 2025; §5) y sucedió a Qwen2.5 (Qwen Team, 2024) en menos de un
año. El bloque de frontmatter normado de la casa «no prevé `version`; la vigencia se lee en
`last_review`» (ia-db 10 §1.1), y guías de la casa con laboratorio ya usan campos como
`entorno_validado`/`sdk_validado` (ia-db 10 §1.2, «Campos extra»). El pedido no prevé nada de esto.

- Impacto: ejemplos que dejan de reproducirse sin que nadie lo detecte; la guía «de referencia» miente
  en silencio.
- Dirección: todo documento con ejemplo operable declara versiones fijadas (modelo con su etiqueta
  exacta, herramienta con su número) y fecha/entorno de validación; el README declara la política de
  revisión (qué dispara un `last_review`). Coherente con la regla de la casa «versiones fijas, nunca
  "la última"».

### H-EDI-07 · P2 · E2 — El patrón didáctico «pregunta → respuesta → realimentación» queda sin forma normada

El pedido pide «preguntas guías formadoras de conceptos que formen criterio articuladas con respuestas
explicativas y que realimenten el texto y ejemplos» (folio 001, «Solicitudes»). El Profile normaliza
«Preguntas guía» como sección 4 del documento temático, pero sin respuestas ni realimentación: el
pedido exige más que el Profile y nadie fijó la forma.

- Impacto: cada comisión resolverá el patrón de forma distinta (preguntas sueltas, quiz al final,
  respuestas inline), y la promesa pedagógica distintiva del pedido se diluye; pérdida acotada.
- Dirección: la plantilla de documento temático (anexo del marco) norma un **bloque didáctico** fijo:
  pregunta → criterio que forma (explícito) → respuesta explicativa → reenvío a la sección o ejemplo
  que la realimenta. El alineamiento objetivo–actividad–evaluación es el «alineamiento constructivo»
  de Biggs y Tang (2011; §5).

### H-EDI-08 · P3 · E2 — Erratas del pedido que piden grafía normalizada en el contrato

«qween», «open sorce», «borrado» (por «borrador»), «a aquien a un estudiante» (folio 001, testimonio).
El testimonio no se toca (es literal con huella); pero sin grafías normalizadas asentadas, «qween»
puede filtrarse a títulos o nombres de archivo.

- Impacto: claridad y prolijidad editorial.
- Dirección: el contrato de entrada o el marco fijan la tabla de normalización (Qwen, open source,
  borrador) y la convención ya vigente en la casa de patrón en inglés / dominio en español para la
  terminología técnica (transformer, embedding, fine-tuning se usan en inglés con definición en
  español en el glosario).

### Solicitud de convocatoria (no es hallazgo de esta comisión)

Señal: «incluya ejemplos los pasos necesarios para montar modelos, descargarlos, **entrenarlos**»
(folio 001, «Contexto»). Si «entrenarlos» se lee como entrenamiento desde cero, su viabilidad como
ejemplo práctico operable en un entorno local es una cuestión de corrección técnica de IA (¿qué es
operable localmente: pretraining, fine-tuning, cuantización?) que excede la competencia de esta
comisión. Pido que la comisión técnica competente en entrenamiento acote qué variantes de
«entrenar» son ejemplificables localmente, porque de eso depende si el núcleo correspondiente promete
un ejemplo inviable (P1 por la lectura de la carta).

---

## 2. Núcleos conceptuales del dominio editorial-pedagógico

Son los núcleos **transversales** que la guía debe cubrir desde mi dominio; no reemplazan a los núcleos
técnicos de contenido (NLP, arquitecturas, entrenamiento…), los estructuran. Cada uno es núcleo y no
fragmento porque agrupa decisiones que se toman juntas o se pagan juntas, y porque el pedido o el
Profile lo exigen como unidad.

### N-ED1. Marco de referencia y navegación

- **Qué agrupa**: escenarios, contextos y actores del dominio; mapa conceptual con tablas de entrada
  («estoy acá → qué leo»); README con ruta de lectura; las dos rutas de lectura de H-EDI-03.
- **Por qué es núcleo**: el Profile lo manda definir antes que las piezas («Diseñar el mapa antes de
  escribir las piezas») y todo documento temático lo referencia; fragmentarlo es repetir vocabulario
  divergente en cada tema.
- **Dependencias**: ninguno lo precede; todos los demás núcleos (editoriales y técnicos) dependen de él.
- **Definiciones imprescindibles**: escenario, contexto, actor (las del Profile); itinerario formativo;
  documento de referencia vs documento formativo; prerrequisito.
- **Ejemplos prácticos candidatos**: (1) tabla de entrada «quiero correr un modelo local hoy → qué
  documentos y en qué orden»; (2) recorrido completo del actor «estudiante iniciante» desde el README
  hasta su primer modelo respondiendo (si el entorno local queda aprobado, cierre medible: una
  inferencia local reproducida); (3) mapa conceptual en Mermaid del dominio completo con los núcleos
  técnicos como nodos.
- **Cuadros comparativos candidatos**: ruta formativa vs ruta de referencia (qué lee cada una, qué se
  salta); matriz escenario × documento.
- **Preguntas guía (criterio que forman)**: «¿En qué escenario estoy y qué actor soy?» (forma el
  criterio de autoubicación: saber qué decisión me toca y cuál no — eje Actores del Profile);
  «¿Qué necesito haber leído antes de este documento?» (criterio de prerrequisito: distinguir no
  entender por falta de base de no entender por mala explicación).

### N-ED2. Progresión pedagógica y formación de criterio

- **Qué agrupa**: el orden del itinerario; objetivos de aprendizaje por documento graduados de recordar
  a evaluar/crear (taxonomía revisada de Bloom: Anderson y Krathwohl, 2001); el bloque didáctico de
  H-EDI-07; la autoevaluación.
- **Por qué es núcleo**: «formar criterio» es el objetivo literal del pedido («transferir experiencia
  teorica-práctica») y del Profile («criterio para intervenir»); las decisiones de progresión se toman
  sobre el temario entero, no tema por tema.
- **Dependencias**: depende de N-ED1 (los itinerarios ordenan sus escenarios); condiciona a todos los
  núcleos técnicos (les fija profundidad por nivel).
- **Definiciones imprescindibles**: objetivo de aprendizaje; criterio (capacidad de elegir, producir y
  evaluar artefactos del dominio, por el Profile); pregunta guía; alineamiento constructivo (objetivo ↔
  actividad ↔ evaluación; Biggs y Tang, 2011).
- **Ejemplos prácticos candidatos**: (1) bloque didáctico completo resuelto sobre un tema técnico (p.
  ej. «¿por qué dos corridas del mismo prompt dan respuestas distintas?» → criterio: distinguir
  parámetros de muestreo de defectos del modelo — operable localmente si el entorno queda aprobado,
  variando un solo parámetro entre dos corridas); (2) lista de autoevaluación de cierre de itinerario
  («puedo explicar X sin releer»); (3) el mismo concepto explicado en nivel iniciante y en nivel
  referencia, lado a lado, como patrón para los autores.
- **Cuadros comparativos candidatos**: niveles de objetivo (reconocer / aplicar / evaluar) × núcleo
  técnico, con el documento que cubre cada celda.
- **Preguntas guía (criterio)**: «Después de este documento, ¿qué puedo decidir que antes no?» (forma
  el criterio de progreso real vs lectura pasiva); «¿Esta pregunta guía tiene su respuesta y su reenvío
  al texto?» (criterio editorial de completitud del bloque didáctico).

### N-ED3. Aparato de evidencia y citación

- **Qué agrupa**: norma de citado (H-EDI-04); tipología de fuentes del dominio (paper con autor y año,
  informe técnico de un equipo de modelos, documentación oficial de herramienta con URL y fecha de
  consulta, norma con número); marcas de procedencia y `origin`/`confidence`; qué es «criterio propio
  declarado».
- **Por qué es núcleo**: «no inventar información» y «evidencia verificable» son restricciones duras
  del pedido; la forma de cumplirlas debe ser una sola para todo el cuerpo.
- **Dependencias**: depende de N-ED1 (vive en Convenciones del marco); condiciona la redacción de todos
  los núcleos.
- **Definiciones imprescindibles**: afirmación respaldada vs criterio propio; fuente primaria vs
  secundaria en IA (paper/technical report vs blog de divulgación); fecha de consulta; reproducibilidad
  de una cita (que otro llegue a la misma fuente).
- **Ejemplos prácticos candidatos**: (1) una afirmación técnica citada de las tres formas (paper,
  doc oficial, norma) como patrón; (2) detección de una afirmación sin respaldo en un borrador y su
  corrección (ejercicio editorial); (3) ficha de referencia completa del informe técnico de la familia
  de modelos usada en los ejemplos (p. ej. Qwen Team, 2025).
- **Cuadros comparativos candidatos**: tipos de fuente × qué exige su cita × cuándo vence; autor-año
  vs numérico (qué gana el lector en cada uno).
- **Preguntas guía (criterio)**: «¿Esta afirmación la podría verificar un lector con lo que la cita le
  da?» (forma el criterio de verificabilidad); «¿Esto es un hecho de la industria o nuestro criterio?»
  (criterio de honestidad epistémica, el que `origin`/`confidence` materializa).

### N-ED4. Estructura documental y cohesión

- **Qué agrupa**: la plantilla única de documento temático (las seis secciones del Profile más el
  bloque didáctico); el documento de cohesión global (dependencias, referencias y vínculos entre
  núcleos — literal de las Reglas del pedido); índices por documento; glosario terminológico
  español/inglés; nomenclatura de archivos y doc_id.
- **Por qué es núcleo**: el pedido lo exige como regla («organizados en secciones jerárquicas…
  autocontenida y no delta… índices»; «documento de cohesión global») y la consistencia estructural es
  indivisible: una plantilla a medias es peor que ninguna.
- **Dependencias**: depende de N-ED1 y N-ED3; es el molde donde los núcleos técnicos vierten contenido.
- **Definiciones imprescindibles**: documento autocontenido y no delta; documento de cohesión; doc_id y
  traces (frontmatter de la casa); glosario cruzado.
- **Ejemplos prácticos candidatos**: (1) plantilla comentada del documento temático con las preguntas
  que guían cada campo (el Profile la pide como anexo); (2) el documento de cohesión global arrancado
  con los núcleos técnicos que las comisiones de dominio propongan, con sus dependencias en Mermaid;
  (3) entrada de glosario modelo: término en inglés, definición en español, fuente, documentos que lo
  usan.
- **Cuadros comparativos candidatos**: estructura de esta guía vs las cuatro guías estructuradas de la
  casa (DT/IS/OEP/REST) — qué convenciones hereda y cuáles no.
- **Preguntas guía (criterio)**: «¿Puedo leer este documento sin haber leído ningún otro y saber a
  dónde ir cuando me falte base?» (forma el criterio de autocontención con reenvío, que no es
  aislamiento); «¿Cada dependencia entre núcleos está en el documento de cohesión y en los `traces`?»
  (criterio de trazabilidad estructural).

### N-ED5. Reproducibilidad editorial de los ejemplos prácticos

- **Qué agrupa**: la convención de ejemplo operable: entorno declarado, versiones fijadas, comando
  transcripto, salida esperada capturada, qué hacer si difiere; separación entre ejemplo ilustrativo
  (se lee) y ejemplo operable (se corre).
- **Por qué es núcleo**: el pedido hace de los ejemplos el vehículo de la «experiencia
  teorica-práctica»; un ejemplo que no reproduce enseña lo contrario de lo que afirma. La validación
  técnica de cada ejemplo es de las comisiones técnicas; la **forma** que garantiza que sea seguible y
  verificable es editorial.
- **Dependencias**: depende de N-ED4 (la plantilla lo norma) y de H-EDI-01/la solicitud de
  convocatoria (qué entorno y qué operaciones quedan aprobados); los núcleos técnicos lo instancian.
- **Definiciones imprescindibles**: ejemplo operable; entorno de referencia; salida esperada; versión
  fijada (regla de la casa: nunca «la última»).
- **Ejemplos prácticos candidatos**: (1) el patrón de ejemplo operable resuelto sobre la descarga y
  primera inferencia de un modelo abierto pequeño en el entorno que se apruebe, con salida esperada y
  variantes de fallo frecuentes; (2) el mismo ejemplo con la versión del modelo deliberadamente
  distinta, mostrando cómo se detecta y reporta la divergencia; (3) checklist editorial de aceptación
  de un ejemplo antes de publicarlo (¿entorno? ¿versiones? ¿salida? ¿fecha?).
- **Cuadros comparativos candidatos**: ejemplo ilustrativo vs operable (qué exige cada uno); matriz
  ejemplo × entorno (local CPU / local GPU / remoto) con lo que cambia.
- **Preguntas guía (criterio)**: «¿Qué tendría que fallar para que yo me dé cuenta de que este ejemplo
  envejeció?» (forma el criterio de vigencia activa, ligado a N-ED6); «¿La salida que obtuve difiere de
  la esperada por el entorno, por la versión o por el azar del muestreo?» (criterio de diagnóstico de
  divergencia — la tercera causa la definen los núcleos técnicos).

### N-ED6. Ciclo de vida y publicación

- **Qué agrupa**: estados del documento (borrador/vigente/obsoleto, como la casa); `last_review` y qué
  lo dispara; política de actualización ante releases de modelos; integración y alta en la ia-db del
  destino; qué se versiona y qué no.
- **Por qué es núcleo**: «material de consulta y también de referencia» (pedido) sólo se sostiene con
  vigencia gestionada (H-EDI-06); las decisiones de publicación afectan al cuerpo entero.
- **Dependencias**: depende de N-ED3 y N-ED4; cierra el ciclo que N-ED1 abre.
- **Definiciones imprescindibles**: vigencia; obsolescencia declarada vs silenciosa; revisión
  disparada por evento (release de la familia de modelos usada) vs por calendario.
- **Ejemplos prácticos candidatos**: (1) simulacro editorial: sale una versión nueva de la familia de
  modelos usada en los ejemplos — qué documentos se revisan, en qué orden, qué cambia en frontmatter;
  (2) alta de la guía en `ia-db/indexes/` con su fila de navegación; (3) marcado de un documento como
  obsoleto con su reemplazo trazado.
- **Cuadros comparativos candidatos**: disparadores de revisión × documentos afectados; estados del
  documento y qué puede citar cada uno.
- **Preguntas guía (criterio)**: «¿Quién y cuándo vuelve a mirar este documento?» (forma el criterio de
  mantenibilidad: una guía sin dueño de revisión es una foto, no una referencia); «¿Un lector de dentro
  de un año puede saber si esto sigue valiendo sin correr nada?» (criterio de vigencia legible —
  `last_review` + versiones fijadas).

---

## 3. Propuesta de escenarios, contextos y actores (desde el dominio editorial-pedagógico)

Instancia de los tres ejes del Profile para esta temática; las comisiones técnicas afinarán los
escenarios de su dominio.

**Escenarios** (situaciones típicas):

| Escenario | Qué hace el lector ahí |
| --- | --- |
| Primer contacto | Nunca vio el tema; necesita el itinerario formativo desde cero |
| Montar y probar un modelo local | Quiere un modelo respondiendo en su máquina, con pasos verificables |
| Elegir modelo o arquitectura para un caso | Compara familias, tamaños, arquitecturas; necesita cuadros y criterios |
| Evaluar resultados | Midió o quiere medir; necesita métricas y su lectura |
| Consulta puntual de referencia | Ya recorrió la guía; entra por el mapa o el glosario a un dato preciso |

**Contextos** (donde cambian las respuestas): equipo local modesto (CPU o GPU chica) vs equipo con GPU
dedicada vs servicio remoto; sólo inferencia vs ajuste fino (si la comisión técnica lo valida como
operable); lector humano vs agente de IA (doble audiencia del RuleSet); español como lengua de la guía
con terminología técnica en inglés.

**Actores**: estudiante iniciante (recorre el itinerario; no decide arquitectura); practicante
avanzado (opera ejemplos, compara, decide para su caso); docente o tutor (usa preguntas guía y
autoevaluaciones; decide orden); agente de IA lector (consume estructura y frontmatter; no decide);
mantenedor de la guía (decide vigencia y revisión — actor que el Profile no trae y esta temática
volátil exige).

---

## 4. Cadenas de consecuencias corridas (Cadena-De-Consecuencias 2.0 §2, los cuatro pasos)

**Decisión: forma documental (H-EDI-02).**
- Opción A, archivo único: cae en el lector y en el agente que cargan todo para leer una parte; pesa:
  una guía monolítica comparable de la casa mide 2 944 líneas (`wc -l
  Lab-Documentos/Guides/Dot-NET-Arquitectura-Guide/Dot-NET-Arquitectura-Guide.md` → `2944`) y este
  temario es más ancho; pierde la alternativa: nada (la ruta pedida sobrevive como portada). Viola la
  regla de núcleos del propio pedido. Reversible: dividir después obliga a re-anclar toda referencia
  interna (caro).
- Opción B, cuerpo multi-documento con portada-índice en la ruta pedida: cae en quien navega (más
  archivos); pesa: el costo es el README/mapa que el Profile exige de todos modos; pierde la
  alternativa: la lectura «un solo archivo» del literal. Reversible: concatenar documentos es barato.
- Recomendación: **B**, decidida por los pasos 3 y 4 (reversible y satisface las dos cláusulas del
  pedido); condición de revisión: que quien pidió conteste la duda 1 en contrario.

**Decisión: sistema de citado (H-EDI-04).**
- Autor-año (APA 7.ª): cae en la prosa (citas legibles para el principiante: «(Vaswani et al., 2017)»
  dice algo); pierde la numérica: compacidad. Reversible: convertir a numérico es mecánico.
- Numérico (ISO 690:2021, sistema numérico): cae en el lector iniciante, que debe saltar a la lista
  para saber qué fuente es; pierde la autor-año: nada que un principiante note. Reversible: ídem.
- Recomendación: **autor-año**, decidida por el paso 1 (dónde cae el costo: en la audiencia que la
  restricción dura protege); ambas reversibles; condición de revisión: una convención de citado
  preexistente de la casa que esta comisión no haya visto (no la encontré en ia-db índice 10).

---

## 5. Fuentes externas

| Fuente | Qué funda | Referencia |
| --- | --- | --- |
| Anderson, L. W. y Krathwohl, D. R. (2001). *A Taxonomy for Learning, Teaching, and Assessing: A Revision of Bloom's Taxonomy of Educational Objectives*. Longman | Graduación de objetivos de aprendizaje (N-ED2) | Libro, autor y año |
| Biggs, J. y Tang, C. (2011). *Teaching for Quality Learning at University* (4.ª ed.). Open University Press | Alineamiento constructivo objetivo–actividad–evaluación (N-ED2, H-EDI-07) | Libro, autor y año |
| Mayer, R. E. (2021). *Multimedia Learning* (3.ª ed.). Cambridge University Press | Principios de segmentación y señalización que sostienen núcleos, niveles y gráficos (H-EDI-03) | Libro, autor y año; sin apartado: no estoy segura del capítulo exacto |
| American Psychological Association (2020). *Publication Manual* (7.ª ed.) | Sistema autor-año propuesto (N-ED3, H-EDI-04) | Manual, edición y año |
| ISO 690:2021, *Information and documentation — Guidelines for bibliographic references and citations to information resources* | Formato de referencias bibliográficas (N-ED3) | Norma con número |
| Vaswani, A. et al. (2017). «Attention Is All You Need». arXiv:1706.03762 | Patrón de cita canónica de paper del dominio (ejemplo N-ED3) | Paper, autor y año |
| Qwen Team (2025). «Qwen3 Technical Report». arXiv:2505.09388 | Volatilidad del dominio y ficha de referencia de la familia de modelos (H-EDI-06, N-ED3); título, autores (An Yang et al.) y fecha (14-05-2025) verificados en arxiv.org el 2026-11-07 | Informe técnico, autor colectivo y año |
| Qwen Team (2024). «Qwen2.5 Technical Report». arXiv:2412.15115 | Ciclo de sucesión de la familia (H-EDI-06); sin verificación web en esta corrida: si el identificador no resuelve, se cita por título y equipo | Informe técnico |
| Documentación oficial de Ollama, https://docs.ollama.com | Existencia de documentación oficial para el entorno local propuesto, si se aprueba (H-EDI-01, N-ED5); consultada el 2026-11-07 (la portada confirma ejecución local de modelos; no nombra Qwen en portada) | Doc oficial con URL y fecha |

---

## 6. Lo que revisé y está bien (hasta tres)

1. La estrategia de descomposición por núcleos de las Reglas del pedido y el Enfoque del Profile
   («mapa antes que piezas», documentos propios por eje) son coherentes entre sí: no hay contradicción
   que arbitrar ahí.
2. La exigencia «evidencia verificable / no inventar» del pedido es ejecutable con el aparato que la
   casa ya tiene (Rule-Evidences, frontmatter `origin`/`confidence`, marcas de procedencia): no exige
   inventar maquinaria nueva.
3. La doble audiencia humano+agente del RuleSet-Study-Guide es compatible con «consulta y referencia»
   del pedido: la misma estructura normada que sirve al agente sirve al acceso de referencia humano.

---

## 7. Dudas para quien pidió

| Rol | Pregunta | Por qué | Prioridad | Qué hago si no contesta |
| --- | --- | --- | --- | --- |
| Comisión de Edición | ¿La guía es un cuerpo multi-documento con portada-índice en `Guides/IA/IA-Model/IA-Model-Guide.md`, o un archivo único? | El pedido manda las dos cosas (H-EDI-02) | Alta | Rige la portada-índice multi-documento (lectura que menos agrega; cadena §4) y queda declarado como lectura elegida |
| Comisión de Edición | ¿Ollama queda fijado como entorno de los ejemplos operables? | El pedido no lo nombra (H-EDI-01); atar los ejemplos a una herramienta no pedida es un agregado | Alta | Lo trato como propuesta marcada: los ejemplos declaran entorno y versión, y el marco lo asienta como decisión propuesta pendiente de ratificación |
| Comisión de Edición | ¿Sistema de citado autor-año (APA 7.ª) o numérico (ISO 690)? | Consistencia editorial de todo el cuerpo (H-EDI-04) | Baja | Rige autor-año con lista de referencias por documento (cadena §4) |

Sin bloqueos: ningún paso prescripto falló.

Sigue: consolidación de informes de comisiones · presidencia de la mesa
