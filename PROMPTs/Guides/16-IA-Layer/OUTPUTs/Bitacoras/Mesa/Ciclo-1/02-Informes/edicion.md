---
doc_id: BIT-16-M1-INF-EDICION
doc_type: informe-de-especialista
title: Informe del especialista en edición de material bibliográfico — Ciclo 1
status: entregado a la relatoría
origin: agent (especialista de la mesa, a ciegas)
confidence: 0.8
last_review: 2026-10-26
audience: [relatoría, jurado, presidencia]
traces: [BIT-16-04, REED-16, BIT-16-00, BIT-16-02, Profile Study-Guide-Documentation, Rule-Dual-Audience, Rule-Documentation, Rule-Markdown, Mesa/I-02..I-06]
---

# Informe — Edición de material bibliográfico (Ciclo 1)

Objeto revisado: `Bitacoras/04-Plan-De-Integracion.md` (v0, 763 líneas). Mandato: estructura editorial (jerarquía, índices, autocontención, terminología y voz, citas y fuentes, glosario, anexos, extensión, navegabilidad). No opino sobre técnica. Trabajé a ciegas: no leí otros informes ni el resto de `Mesa/Ciclo-1/`.

Las líneas citadas son las de `04-Plan-De-Integracion.md` salvo indicación.

## Índice

- [1. Hallazgos](#1-hallazgos)
- [2. Posición sobre las propuestas PR](#2-posición-sobre-las-propuestas-pr)
- [3. Lo que revisé y está bien](#3-lo-que-revisé-y-está-bien)
- [4. Solicitudes de convocatoria](#4-solicitudes-de-convocatoria)

## 1. Hallazgos

### ED-01 · El patrón de seis pasos no tiene traducción a la jerarquía de encabezados — S2 · E2 · confianza 0.8

- **Ubicación**: §C, l. 300–309 (patrón), y todas las fichas §4–§12 (p. ej., l. 352, 361, 392, 401).
- **Afirmación**: el plan declara que §4 a §12 siguen el patrón del Profile (Definición → Aplicación por escenario → Ejemplos → Preguntas guía → Criterios de calidad → Decisión/anexo), «que se declara una vez en §0.4 y no se repite» (l. 300), pero las subsecciones que lista para cada sección son **temáticas** (§8.1…§8.11, §5.1…§5.9) y ninguna corresponde a un paso del patrón. No queda dicho en qué nivel de encabezado va cada paso, si los temas cuelgan de «Definición» o se intercalan, ni dónde caen las preguntas guía y los criterios de calidad de una sección de once subsecciones. §9 entra en el rango §4–§12 pero es la pieza «métodos y marcos» del Profile, que tiene otra forma (en qué consiste cada enfoque, en qué se diferencian, criterios para elegir).
- **Evidencia (E2)**: Profile, §Estructura: «Todos los documentos temáticos siguen el mismo patrón, para que el lector aprenda una sola forma de leer»; Rule-Dual-Audience: «Encabezados y anclas predecibles: los documentos del mismo tipo comparten las mismas secciones».
- **Impacto**: cada redactor resuelve la jerarquía a su modo; la guía pierde las anclas predecibles, el índice no muestra el patrón y el lector no puede saltar a «Preguntas guía» de una sección. Es la estructura de nueve secciones de un archivo único.
- **Dirección**: fijar en el plan una plantilla de encabezados con niveles (qué es H2, qué es H3, dónde viven las subsecciones temáticas), aplicarla a una sección de muestra y decidir explícitamente si §9 sigue el patrón temático o el de métodos y marcos.

### ED-02 · Términos con dos sentidos y sinónimos sin término canónico — S3 · E2 · confianza 0.85

- **Ubicación**: §B.3 l. 216 y §D l. 486 (CAG); §B.4 l. 253 frente a §B.3 l. 222–224 (agente/workflow); todo el documento (sinónimos); Anexo C l. 465.
- **Afirmación**: (a) **CAG** se usa en dos sentidos: «el CAG del paper» (caché KV persistida) y el «CAG de servicio» (prefijo estable + caché del servidor). (b) **agente**: la escalera separa «2 · Workflow · camino fijo en código» de «3 · Agente · el modelo dirige el bucle», pero la tabla de §B.4 llama al workflow «Agente como grafo (workflow)». (c) Sinónimos sin canónico: *tool calling* (7 apariciones), *function calling* (2) y «llamada con herramientas» (2); «salida tipada» (8) y «salida estructurada» (7). El glosario previsto (Anexo C) no incluye *tool calling*, *salida estructurada*, *puerto*, *adaptador*, *escalón* ni *propuesta*, que el plan usa como vocabulario del marco.
- **Evidencia (E2)**: REED-16 §9.1, C5: «*agente*, *herramienta*, *orquestación*, *workflow*, *RAG*, *embedding*… con un solo sentido»; Rule-Dual-Audience: «los sinónimos se registran como alias del término canónico».
- **Impacto**: el lector que aprendió en §3 que un workflow no es un agente lee en §9 que es un «agente como grafo»; C5 no puede pasar con CAG en dos sentidos.
- **Dirección**: un término canónico por concepto con sus alias declarados en el Anexo C; nombre distinto para la variante de CAG que sí usa la guía (o CAG reservado al del paper); renombrar la fila de §B.4 sin «agente»; ampliar la lista del glosario al vocabulario del marco (§B).

### ED-03 · Colisión de identificadores y jerga de la bitácora en títulos de la guía — S3 · E2 · confianza 0.85

- **Ubicación**: §C l. 441 (ADR «D-01…D-10»), §G.3 l. 731–738 (dependencias «D-01…D-07»), §F.1 l. 579–587 (pasos «D1–D7»), §E.1 l. 533 («N6 D5»); §C l. 421 («§11.7 Escenario construido E3»), l. 450 («§14.4 … (T1–T7)»), l. 593 («huecos H1–H5»).
- **Afirmación**: «D-0n» nombra a la vez una decisión de arquitectura, una dependencia del plan y (sin guion) un paso de la demo. «E3» es un nivel de evidencia del marco, un experimento de N5, otro de N3 y un escenario de AH-01, y el plan lo pone en el **título** de una sección de la guía. T1–T7, H1–H5 y C1–C8 son IDs de la bitácora que aparecen en títulos y tablas previstos para la guía sin que la guía los defina.
- **Evidencia (E2)**: R-PO-2 «autocontenidos, no delta»; Rule-Dual-Audience: «IDs estables con prefijo (`RF-`, `RNF-`, `ADR-`, …)»; REED-16 §11: «La guía no referencia la bitácora».
- **Impacto**: el lector encuentra códigos que sólo resuelve quien leyó la bitácora; las referencias cruzadas «D-03» son ambiguas incluso dentro de la mesa.
- **Dirección**: esquema de IDs propio de la guía, con prefijo por tipo (decisión, paso de la demo, tensión) y definido en la guía; los IDs de la bitácora (E-n, F-n, T-n, H-n) no aparecen en el texto del lector salvo que la guía los defina; quitar el nivel de evidencia de los títulos.

### ED-04 · La misma tabla, diagrama o pregunta vive en dos o tres lugares — S3 · E2 · confianza 0.8

- **Ubicación**: tabla/diagrama capas ↔ .NET en §1 (l. 327), §3.1 (l. 342) y §14.2 (l. 450); escaleras en §3.2 (l. 342–343) y §8 (l. 394); ecosistemas en §9.2 (l. 401, 403); `timeline` + tabla de hitos en §4.1 (l. 354); preguntas repetidas: N4 P1 y N6 P7 en §8 (l. 396), N6 P9 en §2 (l. 337) y §14 (l. 454), conjunto de evaluación en §7 (l. 385) y §10 (l. 416) con §7.5 y §10.7 sobre lo mismo, «¿Quién puede ver qué fragmento?» en §7 y §11 (l. 385, 425); §15 reformula todas las preguntas guía (l. 460).
- **Afirmación**: el plan reparte copias de las mismas piezas; en algunos casos lo resuelve con «remite a», en otros duplica (dos preguntas de distinta fuente con la misma intención en la misma sección; el diagrama de las escaleras en §3 y en §8; la tabla y el `timeline` como dos versiones del mismo contenido).
- **Evidencia (E2)**: REED-16 §10, Compresión: «sin repeticiones entre secciones ni mermaid que duplique la prosa»; Rule-Markdown: «sin diagramas redundantes»; Rule-Documentation: «Un dato vive en un solo documento; el resto lo referencia».
- **Impacto**: en un archivo único, cada copia es una divergencia potencial en la relectura y extensión sin información nueva.
- **Dirección**: asignar a cada tabla, diagrama y pregunta una sola «casa» en el índice y que el resto remita por ancla; fusionar preguntas con la misma intención; definir qué aporta §15 que no sea la repetición de las preguntas (ver PR-6).

### ED-05 · Guía única sin presupuesto de extensión — S3 · E2 · confianza 0.7

- **Ubicación**: §C completo (l. 296–469); §A.2 l. 69.
- **Afirmación**: el plan prevé en un solo archivo 16 secciones (§0–§15), 7 anexos, alrededor de 90 preguntas guía con respuesta explicativa (conteo sobre las fichas de §C) más una por cada una de las diez ADR, unos veinte diagramas y 17 ejemplos con su salida, sin estimar extensión por parte ni fijar un criterio de selección de preguntas (cuáles van al cuerpo y cuáles a la autoevaluación o a un anexo).
- **Evidencia (E2)**: DC-01 (un solo `.md`); Rule-Documentation: «Adecuar la profundidad al tema: ni superficial ni innecesariamente extensa»; SUP-07: «compresión» incluye economía del texto.
- **Impacto**: sin tope, la relectura integral (S-14) no tiene contra qué medir la compresión, y la guía corre riesgo de volverse enciclopédica, contra el criterio «formativo, no enciclopédico» del Profile.
- **Dirección**: presupuesto orientativo por parte y un criterio explícito para elegir las preguntas guía de cada sección (por ejemplo, las que cambian una decisión del lector); que la relectura lo verifique.

### ED-06 · Régimen de citas, aparato de referencias y versiones sin definir — S3 · E2 · confianza 0.75

- **Ubicación**: §C Anexos D, F y G (l. 466–469) y Anexo A (l. 463, `Directory.Packages.props` comentado); §5.8 (l. 361); §E.1 (l. 513–527); §A.1 l. 52 («N4 F21 = N0b B03»); §1 (l. 323–325, presentación de la imagen).
- **Afirmación**: (a) El plan no fija cómo se cita en el cuerpo (marca numerada, enlace en línea, ID de referencia) ni cómo se consolidan fuentes que cada dossier numera por su cuenta: la misma fuente es F21 en N4 y B03 en N0b. (b) Las versiones de paquetes aparecen en §5.8, en el Anexo A, en el Anexo F y en el Anexo D, sin decir cuál es la fuente única. (c) §1 «presenta la imagen» de entrada, que lleva la marca de su autor, sin decir si se reproduce o se describe ni con qué crédito; los insumos I-02/I-03 piden no nombrar al autor del curso, lo que deja abierto cómo se acredita la figura.
- **Evidencia (E2)**: R-EVID (fuente «con versión y fecha de consulta»); Rule-Documentation: «Un dato vive en un solo documento»; REED-16 §1.1: «con la marca LIDR en el ángulo superior derecho».
- **Impacto**: referencias duplicadas o con IDs distintos en el Anexo D; versiones que divergen entre secciones (lo que AC-6 intenta atrapar en código, no en el texto); figura sin crédito o con un crédito que choca con la regla de los insumos.
- **Dirección**: definir el formato de cita en el cuerpo y un ID de referencia único de la guía, con tabla de correspondencia desde los IDs de los dossiers en la bitácora; declarar una sola tabla de versiones en la guía y que las demás remitan; decidir el tratamiento de la imagen (reproducción o descripción) y su línea de crédito.

### ED-07 · Rutas de lectura por actor en dos lugares que no coinciden — S3 · E2 · confianza 0.85

- **Ubicación**: §A.3 l. 94–102 frente a §C §0.2 l. 315; §A.2 l. 69 frente al diagrama de l. 71–82.
- **Afirmación**: l. 102 dice que la columna de secciones de la tabla de objetivos **es** la ruta de lectura por rol, y §0.2 da otras rutas. No coinciden: ACT-ARQ tiene OA-A3 en «§6, §7», pero su ruta (§1–§4, §6, §9, §13) no incluye §7; los objetivos de «Todos» (OA-0.1 en §2.4, OA-0.2 en §4.3) no están en la ruta de ACT-OPS (§5, §10, §12). Además, «la guía tiene siete partes» (l. 69) y el diagrama dibuja ocho nodos (Parte 0 a VI más Cierre).
- **Evidencia (E2)**: citas literales de l. 99, 102 y 315; Profile, §Objetivos: README con «la ruta de lectura sugerida».
- **Impacto**: llevado a la guía es una contradicción entre §0.1 y §0.2 (S1 en la escala de REED-16 §5.2); el lector de un rol omite secciones que su propio objetivo exige.
- **Dirección**: una sola fuente de la ruta por rol (o derivar §0.2 de la tabla) y un chequeo mecánico de que toda sección citada por un objetivo esté en la ruta de ese actor; contar las partes de la misma forma en el texto y en el diagrama.

## 2. Posición sobre las propuestas PR

| PR | Posición | Fundamento |
|---|---|---|
| PR-2 | apoya_con_cambios | El alcance reducido es correcto para una guía única; pero tabla y `timeline` del mismo contenido son dos versiones (ED-04): elegir una como canónica. |
| PR-3 | apoya | Los niveles dan navegabilidad entre secciones y `Examples/`; §0.5 como mapa único es la forma correcta. |
| PR-6 | apoya_con_cambios | La autoevaluación cierra el recorrido, pero «reformular las preguntas guía» duplica ~90 preguntas (ED-04, ED-05): conviene que sean casos integradores que crucen secciones y remitan, no copias. |
| PR-9 | apoya | Versión corta coherente con la extensión de una guía única. |
| PR-10 | apoya | Como subsecciones evita una sección más y respeta la jerarquía. |
| PR-12 | apoya_con_cambios | La columna con marco y mapa adelante respeta el «general → particular» del Profile; corregir el conteo de partes (ED-07) y fijar la plantilla de encabezados (ED-01). |
| PR-13 | apoya_con_cambios | Sección propia sí; los ADR necesitan prefijo propio (`ADR-`) para no colisionar con dependencias y pasos de la demo (ED-03). |
| PR-14 | apoya_con_cambios | Objetivos al abrir sí; la tabla y las rutas de lectura deben ser una sola fuente (ED-07). |
| PR-15 | apoya | Lista de control interna, no publicada: correcto para un insumo no citable. |
| PR-19 | apoya_con_cambios | I-05 pide integrarlo con el cuadro de anotaciones; el plan los deja en §9.1, §9.3 y §B.4 por separado. Un cuadro integrado (o remisiones explícitas) evita la triple casa. |
| PR-21 | apoya | Un anexo de lista de verificación es la forma editorial correcta; §11 remite. |

## 3. Lo que revisé y está bien

1. La autocontención frente a la bitácora está prevista: la guía muestra las salidas en §14.5 «sin remitir a la bitácora» (l. 699) y referencia `Examples/` y `Demos/` por ruta relativa.
2. Los insumos no citables (I-02, I-03, I-04) se usan como forma y no como fuente (l. 55, PR-15 «interna, no se publica»), y lo que es criterio propio se marca **[criterio propio]** de forma consistente.
3. El principio rector tiene una sola casa (§A.4) y §B.2 remite a ella en lugar de repetirlo.

## 4. Solicitudes de convocatoria

- **Requisitos**: la trazabilidad de BIT-16-02 §6 y §7 usa la numeración vieja (S-05 → §6, S-09 → §8) y la guía ahora tiene otra (§8, §14); hay que actualizarla en la capa de origen. REED-16 §6.3 y §11 nombran el cuaderno `04-Integracion.md` y el archivo existente es `04-Plan-De-Integracion.md`.
- **Didáctica**: si las ~90 preguntas guía y su distribución sirven al lector principal, y qué función didáctica tiene §15 frente a las preguntas de cada sección (insumo para ED-05 y PR-6).
