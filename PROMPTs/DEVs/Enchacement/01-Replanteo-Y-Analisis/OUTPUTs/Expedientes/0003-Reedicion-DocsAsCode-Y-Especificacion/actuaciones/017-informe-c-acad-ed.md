---
doc_id: EXP0003-F017
doc_type: informe
title: Informe de la comisión ad hoc de edición bibliográfica y de libros — el libro DocsAsCode como obra de consulta
status: vigente
origin: agent
confidence: alta en lo medido (comandos del 2026-11-01 con su salida); media en las posiciones, rotuladas «criterio propio» donde no hay fuente
owner: comisión C-ACAD-ED (ad hoc, carta de mandato; se disuelve al veredicto) de la mesa de la reedición DocsAsCode
last_review: 2026-11-01
audience: [presidencia, refutador, análisis de decisiones, jurado de veredicto, editores, PO]
traces: [TP:28, TP:38, TP:42-56, TP:58-67, TP:73, TP:79, TP:96-98, DB-R02-02, DAC0003-N2, DB-R02-N6]
---

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-01 |
| Autor | Comisión C-ACAD-ED, silla ad hoc «edición bibliográfica y de libros», titular: académico en edición de material bibliográfico y libros. A ciegas |
| Corrige | — |

| Cabecera de comisión | Valor |
| --- | --- |
| Rol | Ad hoc (Rule-Mesa §3.4.4, carta de mandato). Pregunta única: ¿el libro funciona como obra de consulta: estructura, aparato crítico, índices, glosario, citación y ejemplos? |
| Preguntas a cargo | P-01, P-02, P-03, P-05, P-06, P-07, P-08, P-10, P-19, P-20 (contrato de entrada `DB-R02-02` §7) |
| No-competencia | Contenido técnico de las compuertas y de la demo; editar (editan los editores, fuera del panel). Lo que encontré ahí va como solicitud de convocatoria (§9) |
| Norma | `IA.Knowledge.Base/Knowledges/Knowledge-Mesa-De-Expertos-A-Pedido.md` 3.1 |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | Líneas 1-111 (cabecera y §0 con el Mapa de carga), fila «Sos una comisión» (l. 106); §2.1 pasos 2 y 5; §3.2; §4 (encabezado); §5.2 (l. 375-415) |
| Otros documentos cargados | `Cadena-De-Consecuencias` 2.0 §2 y §3; `Mesa-Consulta-A-Un-Tercero` 2.0 (versión verificada; no hay tercero en esta comisión); `Rule-Escalas-De-Juicio` §3.3 (clases de ancla) |
| Insumos leídos | Prompt 02 entero (105 líneas, clon principal, sin versionar: no está en el worktree de LDD); contrato de entrada `02-Propuesta-De-Panel.md` entero; `Nucleo-N2.md` entero; `Nucleo-N6.md` entero; `Nucleo-N1.md` §2, §4, §7, §8; `Nucleo-N7.md` §3.2-§3.4 y tabla H. Del cuerpo SDEI (worktree de LD, `0bed863`): `README.md`, `99-Anexos/Referencias.md` §1, `Glosario.md` entero, `Ejercicios.md` entero, `Examples/Lanzar-Example.md` entero, `TEM-01` l. 166-186, `TEM-04` l. 100-112, la guía obsoleta l. 1-30 y 91-172, `tools/docs-guard/prefijos.txt`. No leí informes de otras comisiones |
| Medios propios | `git`, `grep`, `wc`, `python3 -I`, `curl` de sólo lectura sobre un portal público; `dg.py` sobre una copia `git archive` en el scratchpad (nada en los repos); WebFetch y WebSearch (§8) |

Convenciones de este folio: `SDEI/` abrevia `Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/` de
Lab-Documentos en `0bed863`; `TP:n` es la línea n del prompt 02; `{dir-de-trabajo}` reemplaza las rutas locales.

## Índice

1. [Definiciones y lectura de este informe](#1-definiciones-y-lectura-de-este-informe)
2. [Lectura del objetivo desde la edición](#2-lectura-del-objetivo-desde-la-edición)
3. [Hallazgos](#3-hallazgos)
4. [Dictamen por pregunta](#4-dictamen-por-pregunta)
5. [Cadena de consecuencias de las posiciones](#5-cadena-de-consecuencias-de-las-posiciones)
6. [Ensayos corridos](#6-ensayos-corridos)
7. [Lo que revisé y está bien](#7-lo-que-revisé-y-está-bien)
8. [Fuentes externas](#8-fuentes-externas)
9. [Solicitudes de convocatoria](#9-solicitudes-de-convocatoria)
10. [Excepciones a conocimientos](#10-excepciones-a-conocimientos)
11. [Lo no verificado](#11-lo-no-verificado)
12. [Incidencias del encargo](#12-incidencias-del-encargo)

---

## 1. Definiciones y lectura de este informe

### 1.1 Definiciones

| Término | Definición en este informe | Fuente |
| --- | --- | --- |
| **Obra de consulta** | Libro que se lee por entradas y no sólo de corrido: el lector llega por el índice, el glosario o una referencia cruzada, lee una sección y sale con una respuesta que no depende de lo que no leyó | Criterio propio; en línea con la regla de secciones autocontenidas (`Rule-Markdown`, citada en N2 §2.2) y con `TP:79` («autocontenida») |
| **Aparato crítico** | Lo que permite al lector comprobar el texto: citas y bibliografía, marcas de procedencia de los ejemplos, fechas de consulta, notas de estado (HISTÓRICO, NO VERIFICADO) y la correspondencia con las fuentes | Criterio propio |
| **Edición de lectura** | Texto que reúne y ordena otros textos que siguen siendo la fuente; declara de qué estado de esas fuentes es copia | Criterio propio, sobre N2 D-N2-1 A |
| **Colofón** | Bloque final (o de portada) que declara edición, fecha y base de la edición; acá, el SHA de las fuentes del que sale el libro | Criterio propio; análogo editorial del «ancla de versión» del glosario del cuerpo (`SDEI/99-Anexos/Glosario.md`, fila «Ancla de versión») |
| **Corrección de pruebas** | Sexta intervención de `TP:67`: errores de la versión diagramada, o sea **del libro tal como se ve dibujado**, no del fuente | `TP:67` |

### 1.2 Lectura P0–P3 aplicada

La del contrato de entrada §8. En esta silla, **P1** es un defecto que hace que dos lectores lleguen a respuestas
distintas al consultar el libro, o que el libro no se pueda consultar entero; **P2**, una pieza del aparato crítico
que no se puede comprobar; **P3**, forma.

## 2. Lectura del objetivo desde la edición

El objetivo del contrato (§4) pide un libro «autocontenido, no delta y con índice que abre con sus fundamentos y suma
referencias y casos de la industria» y «revisado como libro en seis intervenciones». Tres cosas que da por fijas sin
origen, desde esta silla:

| Lo que el objetivo da por fijo | Por qué no es fijo | Hallazgo |
| --- | --- | --- |
| Que un único `.md` se puede leer entero donde vive | Las fuentes suman 354 008 bytes; la estimación de N2 lleva el libro a la zona del límite de render documentado de GitHub | H01 |
| Que el libro tiene nombre | El archivo pedido es `DocsAsCode-Developer-Guide.md` (`TP:48`); «DocsAsCode» tiene 0 apariciones en el cuerpo | H03 |
| Que una «edición de lectura» puede seguir a sus fuentes | Nada declara de qué estado de las fuentes es copia el libro | H11 |

El pedido me asigna además «consultar y crear ejemplos y material de consulta» (`TP:73`). Lo trato en H09 y P-03; no
redacto ejemplos: eso es de los editores.

## 3. Hallazgos

Tope: 12. Anclas según `Rule-Escalas-De-Juicio` §3.3.

| Id | Nivel | Ancla con cita | Hallazgo | Impacto si no se corrige | Dirección de la corrección |
| --- | --- | --- | --- | --- | --- |
| H01 | P1 | E1: `cat` de los Markdown vigentes de SDEI \| `wc -c -w` → `54558 354008`; libro MAUI 204 170 bytes / 29 644 palabras (6,9 B/palabra; N2 §13 E10 para las palabras). Estimación N2 §11: 50 000-59 000 palabras → **≈ 345-407 KB**. GitHub documenta para el render en modo crudo «Markdown content must be 400 KB or less» (§8, F5); para la vista web no hay cifra oficial (C, §11) | El libro único puede quedar en el borde, o por encima, del límite de render de GitHub. Hoy nadie lo mide: N2 §12.3 deja el render «NO VERIFICADO» | Un lector abre el libro y la página se corta o no se dibuja: la obra no se puede consultar entera; el defecto aparece después del merge | La corrección de pruebas incluye **render del archivo completo en la vista de GitHub** en el PR del libro, con captura; tope de tamaño declarado antes de redactar (p. ej. 350 KB **[criterio propio]**). Si se pasa, el libro se parte en dos archivos (cuerpo y tomo de anexos A-J), práctica común de obras en tomos |
| H02 | P1 | E1: `curl` del 2026-11-01 (§6, ensayo 2): `create-user.md` → `200 text/markdown`, **834** líneas (la guía obsoleta dice 920, l. 125); `openapi: 3.1.0` en la línea 60 (igual); `generator` = Mintlify (igual); `llms.txt` → 200, 159 líneas con `.md` (la guía y `TEM-04:107` dicen «170 páginas»). E1: `grep -ci 'onesignal' Referencias.md` → 0 (la única entrada afín es el repositorio de Mintlify, l. 152) | El caso de industria del libro (18.1 en N2) descansa en cifras del 2026-09-16 que ya cambiaron y en una fuente sin entrada bibliográfica | El libro afirma cifras falsas a la fecha de publicación y viola su propia norma de citación (`00-Marco.md:165`) | Reverificar antes de redactar 18.1, con fecha nueva y método de conteo declarado; una entrada APA del portal; las cifras, como datos fechados («al 2026-11-01») y no como rasgos del caso (P-07) |
| H03 | P1 | E1: conteo en SDEI sin la guía obsoleta: «DocsAsCode» 0, «DocAsCode» 10 (todas como nombre del expediente), «docs as code» 5, «sistema documentador» 75, «framework» 1. E2: `TP:48` (archivo `DocsAsCode-Developer-Guide.md`) y `TP:52` («los fundamentos que hemos basado el framework»); H1 del README: «Sistema de documentación e integración — guía de estudio» | La obra va a tener un título que no aparece en su texto, y tres nombres para el objeto (el método, el cuerpo SDEI y el «framework») | El lector que busca el título dentro del libro no lo encuentra; el agente que busca «DocsAsCode» en el cuerpo vuelve vacío. Dos lectores nombran distinto la misma cosa | Portada con título, subtítulo y equivalencias declaradas en una línea («DocsAsCode: el método; SDEI: este cuerpo; sistema documentador: lo que el método construye»), y la entrada correspondiente en el glosario. El nombre del archivo lo fija el pedido y no se discute |
| H04 | P1 | E1: `git merge-base --is-ancestor 080f158 HEAD` y `fe10086` → no ancestros; `e3841b6` (PR #19) y `6878568` (PR #25) sí. `git diff --stat 080f158 e3841b6` → 3 archivos, todos fuera de SDEI y de `tools/` (`Guides/Despliegue/…`, `Guides/Testing/…`); ídem `fe10086 6878568`. E2: siete citas a `080f158` en `TEM-01:218,343`, `TEM-02:218,342`, `TEM-03:162,221`, `TEM-07:187,200` | Las citas por commit del aparato crítico apuntan a objetos que un clon nuevo no tiene (N1-17 lo midió; yo verifiqué la no-ascendencia y la equivalencia de contenido) | Una cita que no se puede abrir no es cita: el lector no puede comprobar la salida del ensayo, y el guion de `TEM-07:200` no corre | Citar «PR #n, merge `<sha nuevo>`»; dejar constancia, en la entrada o en el anexo de ensayos, de que el merge nuevo difiere del viejo sólo fuera del cuerpo (P-10) |
| H05 | P1 | E2: `SDEI/Examples/Lanzar-Example.md:15` («# Tool-Prompt»), `:18` y `:35` (ruta absoluta del espacio de trabajo), `:51`, `:59` (`@devcontainers/cli@latest`), `:92` (`cloudflared:latest`), `:101` (túneles del usuario); `:5` (`description`: «Tool-prompt») frente a `doc_type: guia-practica` (`:3`) | Es otro género textual: instrucciones imperativas a un agente, con rutas del entorno de quien lo escribió y versiones sin fijar | Copiado íntegro al libro (N2 §8.6), el capítulo 14.3 cambia de voz, publica datos del entorno y da un procedimiento que no se reproduce igual mañana | Separar género y contenido (P-06): el procedimiento, reescrito con versiones fijas y sin datos del entorno, en la fuente y en 14.3; el tool-prompt, al repositorio hermano |
| H06 | P2 | E1: anclas definidas en `Referencias.md` 51; anclas citadas fuera del anexo 48; definidas y nunca citadas: `ref-apa-2020`, `ref-carroll-1990`, `ref-khan-2022`; citadas sin definir: 0 (§6, ensayo 1) | Tres entradas de bibliografía sin cita; APA 7, la norma que el cuerpo adopta (`Referencias.md:36`), pide correspondencia en los dos sentidos (§8, F3, no verificado en fuente primaria) | Una bibliografía que no corresponde al texto no le dice al lector qué sostiene qué | Citar las tres donde corresponden (APA 7 en la norma de citación, Carroll 1990 junto a van der Meij y Carroll 1995) o sacarlas; en el libro, un chequeo mecánico de correspondencia en la ronda académica |
| H07 | P2 | E1: glosario de `SDEI/99-Anexos/Glosario.md` §2 con 33 términos; orden roto en dos pares: «Ancla de versión» > «Agente de IA», «Escenario» > «Escala anclada» (script de orden con normalización sin tildes, §6, ensayo 3). E2: «Fuente de verdad» 0 apariciones en el glosario aunque `TEM-01:52` dice que está | El glosario no funciona todavía como puerta de entrada de una obra de consulta: no está en orden alfabético, le faltan términos que el cuerpo usa y su columna «Alias» mezcla equivalentes en inglés y sinónimos en castellano | El lector que busca por orden no encuentra; el anexo A del libro (N2 §10.1) hereda los defectos | Anexo A alfabético (orden de la Ortografía académica, §8, F6), con columnas separadas «Equivalente en inglés» y «Sección donde se define», y completo contra los términos definidos en el cuerpo (N2 E9 dice 98; no lo medí) |
| H08 | P2 | E2: N6 §5 punto 3: «Para castellano, ninguna de las dos aplica directamente». E1: Microsoft publica guías de estilo de localización, entre ellas **Spanish (Neutral)**, Spanish (Mexico), Spanish (Spain) y Spanish (US), sin variante rioplatense (§8, F1); `aka.ms/spanish-neutral-styleguide` → 200, PDF de 838 849 bytes | La hipótesis de N6 sobre la guía de estilo de segundo nivel queda refutada en parte: sí hay una guía de la industria en castellano para documentación técnica | La ronda de estilo arranca sin base externa en la lengua del libro, o con una en inglés que no resuelve ortotipografía castellana | Ver P-05: tres niveles, con la norma académica para ortografía y ortotipografía |
| H09 | P2 | E1: `dg.py trazas` sobre la copia (§6, ensayo 4): `trazas=123 resueltas=114`, 9 avisos `traza-no-verificable`, todos de `Examples/Prueba-Ayuda-Por-Rol` (p. ej. `Web/Ayuda/es/comun/ingresar.md:1: CU-00022@1.1`). E2: `00-Marco.md` define cuatro escenarios; el ejemplo de `ESC-SDEI-3` es esa prueba (N1-21, que verifiqué en la mitad de las trazas) | Una obra de consulta organizada por escenarios tiene un escenario sin ejemplo verificable | Quien consulta el libro por `ESC-SDEI-3` encuentra un ejemplo cuyas trazas no resuelven, contra la regla que el mismo libro enseña | El libro lo declara en el capítulo 14 como límite, y el deseable E-05 (ejemplos de Geometría) es la vía para llenarlo; no se inventa un ejemplo |
| H10 | P2 | E2: N2 §6.1 recomienda «edición de lectura» con precedencia de la fuente; ninguna pieza del diseño (N2 §7-§10) dice **contra qué SHA** de las fuentes vale el libro. E2: el glosario del cuerpo define «Ancla de versión: el dato que dice contra qué estado del código vale una pieza» | El libro sería la única pieza del cuerpo sin ancla de versión hacia aquello de lo que deriva | La deriva libro ↔ fuente queda invisible: la corrección doble depende sólo de la disciplina de cada PR | Colofón con edición, fecha y SHA de las fuentes; el anexo I (correspondencia) se regenera contra ese SHA. Es aplicar al libro la regla que el libro enseña |
| H11 | P3 | E1: 21 bloques mermaid en las fuentes vigentes; 17 llevan pie «*Diagrama: …*» sin número; 4 (en `Examples/MovilidadUrbana-Mini-Demo/`) no llevan pie (§6, ensayo 5) | Figuras sin numerar ni lista; al unir, no se pueden citar por número | En una obra de consulta, «ver la figura» sin número obliga a buscar | Numeración «Figura c.n» con pie, como fija N2 §7.4; los cuatro sin pie, con pie |
| H12 | P3 | E2: `Ejercicios.md` §1: cinco ejercicios, uno por objetivo `OBJ-SDEI-01..05`; ninguno ejercita `TEM-04` (doble audiencia) | Una parte del libro sin ejercicio con clave | Quien estudia por la ruta «aprender» no comprueba esa parte | Deseable para la edición: un ejercicio con clave por parte del libro; no bloquea |

## 4. Dictamen por pregunta

Una posición por pregunta, sin «depende». Criterios: simplicidad, practicidad, escalabilidad (`TP:73`), más fuente
única y paso por la compuerta (los del contrato §6.3).

### 4.1 P-01 — Relación libro ↔ documentos fuente

- **Posición: A (edición de lectura; manda la fuente; corrección doble en el mismo PR), con un agregado: colofón con
  el SHA de las fuentes (H10).**
- Fundamento: B obliga a depreciar 30 documentos y re-apuntar trazas (N2 §6.1) y deja a la ruta «agente» sin
  documentos chicos; C impide las seis intervenciones que pide `TP:50`, `:58-67`, porque un texto generado no se
  corrige: se regenera. A es la única que deja editar el libro como libro. Su punto débil es la deriva; el colofón la
  vuelve medible con el mismo concepto que el cuerpo ya enseña (ancla de versión), sin herramienta nueva.
- Fuente externa: Google, *documentation best practices*: «A small set of fresh and accurate docs is better than a large
  assembly of "documentation" in various states of disrepair» (§8, F7). Es el riesgo de A sin ancla.
- Riesgo: con A, dos textos dicen lo mismo; si un PR corrige sólo uno, el colofón queda viejo y nadie lo ve si no hay
  quien compare. Cuánto pesa: **sin medir** (no hay serie histórica de PR del libro).
- Evidencia que la sostendría: en el PR del libro, el anexo I generado contra el SHA del colofón, y un PR de prueba que
  toca una fuente y muestra que el colofón queda atrás (prueba roja/verde de la regla).

### 4.2 P-02 — `doc_id` del libro

- **Posición: `DOC-SDEI-GUIA`, `doc_type: guia-de-estudio`.**
- Fundamento: pasa la compuerta sin tocar archivos comunes (E1, §6, ensayo 4: `esquema` verde, `trazas` verde
  `ids-duplicados=0`, `ai` verde). Cierra el hueco que el contrato marcaba («el `doc_id` exacto no se ensayó»). El
  prefijo `DOC` es «documento temático por tipo de documentación» (`tools/docs-guard/prefijos.txt:11`) y el libro es,
  editorialmente, una *guía*, que es lo que dice su nombre de archivo («Developer-Guide»). `LIB` sólo agrega precisión
  semántica a costa de un PR común coordinado con la otra sesión.
- Fuente externa: no hay norma de la industria sobre prefijos de ID internos; la decisión es de casa.
- Riesgo: `DOC-SDT-0001` (la guía obsoleta) usa el mismo prefijo; mientras conviva, dos `DOC-` del mismo tema.
  Desaparece al archivarla (P-08).
- Evidencia: el ensayo 4 de §6, repetible.

### 4.3 P-03 — Partes, orden y anexos

- **Posición: la arquitectura de N2 §7 (prólogo, partes I-VI, capítulos 1-18, anexos A-J, orden TEM-01→07), con cinco
  ajustes de obra de consulta:**
  1. **Portada y colofón** con título, subtítulo, equivalencias de nombre (H03), edición, fecha y SHA de las fuentes
     (H10), y una línea «Cómo citar este libro» con su forma APA 7 (la norma de casa).
  2. **Anexo A como glosario-índice**: alfabético, con equivalente en inglés y sección donde se define (H07). Con eso no
     hace falta índice analítico aparte: ISO 999 orienta índices para libros e informes, también digitales (§8, F4),
     pero un único Markdown se busca con el navegador; el valor que agrega un índice analítico —sinónimos y conceptos
     que no están literales— lo da la columna de alias del glosario **[criterio propio]**.
  3. **Rótulo de forma por capítulo, no por parte**: una línea al abrir cada capítulo con su forma Diátaxis (§8, F8).
     Las partes de N2 mezclan formas (la V tiene tutorial, procedimiento y referencia); rotular la parte mentiría.
  4. **Herramientas, dentro del anexo B**, como sección «Software» con la versión que fija la CI (la norma de
     `Referencias.md:38` ya lo exige), no como anexo nuevo: un anexo menos que mantener.
  5. **Plan de tomos**: si H01 se confirma, el corte natural es cuerpo (prólogo y partes I-VI) y tomo de anexos A-J.
- La sección «de la explicación al conocimiento» (N3 §7) entra como capítulo 17.x o anexo, no en la Parte I: los
  fundamentos (`TP:52`) son del método, no del conocimiento derivado **[criterio propio]**.
- Riesgo: más piezas de portada que mantener. Mitigación: colofón y anexo I se regeneran juntos.
- Evidencia: render completo del libro (H01) y una P-LECT por el glosario (el lector sin contexto entra por el anexo A
  y llega a la definición sin otra ayuda).

### 4.4 P-05 — Guía de estilo de base para estilo y ortotipografía

- **Posición: una alternativa nueva, en tres niveles con precedencia declarada:**
  1. Convenciones del cuerpo (`00-Marco.md` §5) y la regla de voz narrativa: mandan.
  2. Para ortografía y ortotipografía: la **Ortografía de la lengua española** de RAE y ASALE (2010) (§8, F6). Es la
     norma de la lengua del libro; Google y Microsoft en inglés no resuelven tildes, comillas latinas, mayúsculas de
     títulos ni signos de apertura.
  3. Para estilo de documentación técnica: la **Microsoft Spanish (Neutral) Style Guide** como consulta (§8, F1), y
     Google en inglés sólo para lo que no depende de la lengua (procedimientos, código en línea, listas).
- Fundamento: la precedencia «Refer to project-specific guidelines first, then this guide, and finally third-party
  references» (Google, §8, F2) es la misma que propongo; Write the Docs aconseja partir de una guía existente (§8,
  F9). La refutación de N6 está en H08.
- Riesgo: la guía de Microsoft es «neutral», no rioplatense; donde choque con el voseo del cuerpo (`00-Marco.md:171`)
  manda el nivel 1, y eso se declara.
- Evidencia: la lista de decisiones de estilo de la ronda 3 cita para cada una su nivel.

### 4.5 P-06 — Cómo entra `Lanzar-Example`

- **Posición: reescrito, no íntegro; y separado en dos piezas.** El procedimiento (objetivo, prerrequisitos, pasos,
  resultado, validaciones, errores, como pide `Rule-Documentation`, N2 §8.6) se reescribe **en la fuente** con
  versiones fijas y sin datos del entorno, y de ahí pasa a 14.3. El tool-prompt (línea de invocación, rutas, túneles
  ajenos) se mueve al repositorio hermano, donde el Mapa ubica los prompts (N1-32).
- Fundamento: H05. Con P-01 A la reescritura en la fuente no es opcional: el libro no puede corregir lo que la fuente
  sigue diciendo.
- Riesgo: el tool-prompt movido deja de estar al lado de la prueba; mitigación, un enlace permanente desde 14.3.
- Evidencia: la compuerta sin el aviso `cita-linea` sobre ese archivo y las versiones fijadas visibles en el
  procedimiento.

### 4.6 P-07 — El caso del portal de notificaciones

- **Posición: reverificado antes de redactar 18.1**, con entrada APA y fecha nueva; las cifras como datos fechados.
  «HISTÓRICO» sólo para lo que no se pueda volver a medir; excluirlo, no.
- Fundamento: la reverificación cuesta minutos y la hice en la parte que más pesa (E1, H02): el patrón del caso
  (Markdown servido como fuente, OpenAPI 3.1 embebido, Mintlify como generador, `llms.txt`) **sigue en pie**; las
  cifras (920 líneas, 170 páginas) **no**. Marcar HISTÓRICO un caso que sigue vivo le resta valor de consulta; excluirlo
  borra el único caso que muestra prosa y referencia generada en un mismo sitio.
- Riesgo: el portal cambia de nuevo; por eso el libro no apoya el argumento en cifras sino en el patrón, y las cifras
  van con «al AAAA-MM-DD».
- Evidencia: la corrida del ensayo 2 (§6), repetida por el perito con método de conteo declarado y su salida en el
  anexo J.

### 4.7 P-08 — Archivo de la guía obsoleta y versión del cuerpo

- **Posición: el libro viaja dentro de la `2.0.0` (hoy `2.0.0-borrador`, `SDEI/README.md:22`), y la guía obsoleta se
  archiva en el mismo cambio que publica el libro.**
- Fundamento: E1: `git tag -l` en LD sólo da `docs-guard-v1.0.0`; la `2.0.0` del cuerpo nunca se etiquetó, así que no
  hay una edición publicada que la `2.1.0` vendría a suceder. En términos editoriales, el libro es parte de la primera
  edición del cuerpo, no una reedición. El README fija el orden: documentos a `vigente`, después `2.0.0` con etiqueta
  anotada (`SDEI/README.md`, §6). Archivar en el mismo cambio cumple «no delta» (`TP:79`): el libro no puede convivir
  con una guía cuya tabla de destinos es, por definición, un delta.
- Precondición: antes de archivar, absorber lo que la obsoleta no trasladó (N2 §9.3) y re-apuntar las remisiones
  (`TEM-01:170`, `TEM-04:105`; N1-19).
- Riesgo: un cambio más grande. Reversible: archivar es mover a un archivo inmutable, no borrar.
- Evidencia: `grep` de enlaces a `Sistema-Documentador-Tecnico-Guide.md` en 0 fuera del archivo histórico, en el PR.

### 4.8 P-10 — Citación de los commits fuera de `main`

- **Posición: «PR #n, merge `<sha nuevo>`», con una nota en el anexo de ensayos que diga que el merge nuevo difiere del
  viejo sólo fuera del cuerpo.**
- Fundamento: H04. El SHA nuevo se abre desde cualquier clon; el número de PR da al lector humano el contexto y
  sobrevive a otra reescritura; la URL de `refs/pull` depende del alojamiento y no está en el clon. La convención del
  cuerpo pide fuentes en Git «por versión publicada o por commit, nunca por la rama principal» (`Referencias.md:39`):
  el SHA nuevo la cumple; el número de PR solo, no.
- Riesgo: si la salida citada dependiera de los tres archivos que cambiaron, el ensayo no sería el mismo. Medido: los
  tres están fuera de SDEI y de `tools/` (H04), así que no depende.
- Evidencia: `git diff --stat <viejo> <nuevo>` en la nota, y el guion de `TEM-07:200` corriendo desde un clon nuevo.

### 4.9 P-19 — ¿Sitio publicado?

- **Posición: no en esta edición.** El libro se publica donde vive (GitHub) y el ensayo MkDocs queda informativo en el
  PR del libro, con slug compatible con GitHub (N7 H4).
- Fundamento: E1 de N7 (LD no tiene generador; el ensayo compila); Material for MkDocs anuncia fin de vida el
  2027-05-05 (N6 §3.6, tomado como hipótesis; no lo volví a abrir). Atar la primera edición a una herramienta con fecha
  de fin no es simple ni escalable.
- Condición para revisarla (comprobable): si el render completo del libro en GitHub falla (H01) **y** partir en tomos no
  alcanza, el sitio pasa a ser la vía y se reabre la pregunta.
- Evidencia: la captura del render completo en el PR del libro.

### 4.10 P-20 — Dibujado de mermaid: control local o CI

- **Posición editorial: el dibujado es parte obligatoria de la corrección de pruebas del libro, con su salida
  registrada en el PR.** Dónde corre (local o CI) es contenido técnico de la compuerta, fuera de mi competencia: lo
  derivo (§9).
- Fundamento: `TP:67` define la corrección de pruebas sobre «la versión diagramada»; un diagrama que parsea pero se
  dibuja mal es exactamente un error de prueba. El defecto apareció dos veces en dos libros (N2 §3.2; N7 §3.2).
- Evidencia: salida de `tools/medios/mermaid.sh` sobre el libro completo, sin «Unsupported markdown», adjunta al PR.

## 5. Cadena de consecuencias de las posiciones

`Cadena-De-Consecuencias` §2, los cuatro pasos, para las posiciones que eligen entre opciones.

| Pregunta | Opción | ¿Dónde cae? | ¿Cuánto pesa ahí? | ¿Qué pierde la alternativa? | ¿Reversible? |
| --- | --- | --- | --- | --- | --- |
| P-01 | A + colofón | Cada PR que toque fuente o libro | Sin medir (no hay serie de PR del libro); se mediría contando PR con desfase de colofón | B pierde los documentos chicos y re-apunta trazas; C pierde las seis intervenciones | Sí: pasar de A a B después es posible; de B a A, no sin resucitar 30 documentos. Se toma A |
| P-02 | `DOC-SDEI-GUIA` | `prefijos.txt` (no se toca) | 0 archivos comunes; compuerta verde (E1) | `LIB` cuesta un PR común coordinado | Sí: renombrar el `doc_id` es un PR |
| P-05 | Tres niveles | La ronda de estilo | Una lista de decisiones con nivel | Sin base castellana, la ortotipografía queda a juicio de cada editor | Sí |
| P-06 | Reescribir y separar | La fuente y LDD | 1 archivo reescrito, 1 movido | Íntegro publica datos del entorno y versiones `latest` | Sí |
| P-07 | Reverificar | Capítulo 18.1 | Minutos (ensayo 2) | HISTÓRICO resta vigencia a un caso vivo; excluir pierde el único caso de prosa + referencia generada | Sí |
| P-08 | 2.0.0 y archivo junto | El PR del libro | Mayor tamaño de PR | `2.1.0` versionaría una edición que nunca salió; archivar después deja un delta publicado | Sí: archivar es mover |
| P-10 | PR + SHA nuevo | 7 citas en 4 temas | 7 líneas | Sólo PR no se abre en un clon; `refs/pull` depende del alojamiento | Sí |
| P-19 | Sin sitio | El PR del libro | 0 piezas nuevas | El sitio suma herramienta con fin de vida anunciado | Sí, con la condición de §4.9 |

## 6. Ensayos corridos

Todos el 2026-11-01, de sólo lectura sobre el worktree de LD en `0bed863` o sobre una copia en el scratchpad.

| # | Comando (abreviado) | Salida |
| --- | --- | --- |
| 1 | `grep -o '<a id="ref-…"'` en `Referencias.md` frente a `grep -rhoE '#ref-[a-z0-9-]+'` en SDEI | 51 definidas; 48 citadas; definidas sin cita: `ref-apa-2020`, `ref-carroll-1990`, `ref-khan-2022`; citadas sin definir: ninguna |
| 2 | `curl` a `documentation.onesignal.com/reference/create-user.md`, a la misma página HTML y a `/llms.txt` (18:38 UTC) | `200 text/markdown; charset=utf-8`, 834 líneas, `# Create user` en l. 5, `openapi: 3.1.0` en l. 60; `name="generator" content="Mintlify"`; `llms.txt` 200, `grep -c '\.md'` = 159 |
| 3 | `python3 -I` con orden por clave sin tildes sobre la primera columna de `Glosario.md` §2 | «fuera de orden: Ancla de versión > Agente de IA»; «fuera de orden: Escenario > Escala anclada» |
| 4 | `git archive HEAD` a `{dir-de-trabajo}/ens-p02`; libro de prueba con `doc_id: DOC-SDEI-GUIA`, `doc_type: guia-de-estudio`, `description`, encabezado `` #### 3.2.1 Corpus de guías (`ESC-SDEI-1`) `` y una cita a `Referencias.md#ref-aghajani-2020`; `python3 -I tools/docs-guard/dg.py {esquema,trazas,ai}` | `PR-2 esquema: verde (errores=0 avisos=0) archivos-con-frontmatter=42`; `PR-5 traces-resolve: verde (errores=0 avisos=9) trazas=123 resueltas=114 ids-duplicados=0`; `PR-3 anti-inyeccion: verde (errores=0 avisos=28)` |
| 5 | `awk` sobre cada bloque mermaid de las fuentes vigentes: línea siguiente al cierre | 21 bloques; 17 con «*Diagrama: …*»; 4 sin pie (`MovilidadUrbana-Mini-Demo/README.md`, `docs/_requisitos.md`, `docs/ayuda/alta-de-localidad.md`, `docs/tecnica/arquitectura.md`) |
| 6 | `wc -c -w` de las fuentes vigentes concatenadas; `wc -c` del libro MAUI | `54558 354008`; `204170` |
| 7 | `git merge-base --is-ancestor` y `git diff --stat` entre `080f158`/`e3841b6` y `fe10086`/`6878568` | Los viejos no son ancestros de `HEAD`; los nuevos sí; 3 archivos distintos, todos fuera de SDEI y de `tools/` |
| 8 | `git tag -l` en LD | `docs-guard-v1.0.0` (ninguna etiqueta del cuerpo) |
| 9 | `curl -L` a `aka.ms/spanish-neutral-styleguide` | `200`, `spa-neu-StyleGuide.pdf`, 838 849 bytes |

La copia del ensayo 4 vive en el scratchpad de la sesión, fuera de todo repositorio.

## 7. Lo que revisé y está bien

1. **La norma de citación** (`Referencias.md` §1): APA 7 en castellano, fecha de consulta siempre, software con
   versión, Git por commit, marca de verificación V/P y procedencia de las fechas declarada. Es un aparato crítico
   mejor que el de muchos libros técnicos; ninguna cita apunta a un ancla inexistente (ensayo 1).
2. **Objetivos y ejercicios con clave** (`README.md` §2, `Ejercicios.md`): cada objetivo es observable, tiene su
   ejercicio, su ejemplo trabajado previo y su clave. Es la estructura correcta de un libro de estudio.
3. **El mapa fuente → capítulo de N2 §8**: cada sección de cada fuente tiene destino y tratamiento, y lo excluido está
   nombrado (§9.3). Es la base del anexo I y lo que hace posible una edición no delta.

## 8. Fuentes externas

| # | Fuente | Qué sostiene | Consulta |
| --- | --- | --- | --- |
| F1 | Microsoft. *Microsoft Localization Style Guides*. https://learn.microsoft.com/en-us/globalization/reference/microsoft-style-guides | Lista «Spanish (Neutral)», «Spanish (Mexico)», «Spanish (Spain)», «Spanish (US)»; no hay variante rioplatense | WebFetch, 2026-11-01 |
| F2 | Google. *Google developer documentation style guide*. https://developers.google.com/style | «Refer to project-specific guidelines first, then this guide, and finally third-party references» | WebFetch, 2026-11-01 |
| F3 | American Psychological Association (2020). *Publication manual* (7.ª ed.), y https://apastyle.apa.org/style-grammar-guidelines/references/works-included | Correspondencia texto ↔ lista de referencias en los dos sentidos | **[no verificado en fuente primaria]**: la página devolvió cuerpo vacío a WebFetch; la regla sale del resumen del buscador del 2026-11-01. Se cita el manual sin apartado |
| F4 | ISO 999:1996, *Information and documentation — Guidelines for the content, organization and presentation of indexes*. https://committee.iso.org/standard/5446.html | Alcance: índices de libros, informes y también material no impreso y digital; «last reviewed and confirmed in 2020»; a reemplazar por ISO/FDIS 999 | WebFetch, 2026-11-01 (`iso.org` dio 403; la página de comité respondió) |
| F5 | GitHub. *REST API endpoints for Markdown*. https://docs.github.com/en/rest/markdown/markdown | «Markdown content must be 400 KB or less» (modo crudo) | WebFetch, 2026-11-01 |
| F6 | Real Academia Española y Asociación de Academias de la Lengua Española (2010). *Ortografía de la lengua española*. Espasa. https://rae.es/obras-academicas/ortografia/ortografia-2010 | Norma ortográfica y ortotipográfica del castellano | **[no verificado en fuente primaria]**: la página dio 403 a WebFetch; datos de la ficha por el buscador del 2026-11-01. La obra se cita por su título y año, sin apartado |
| F7 | Google. *Documentation best practices*. https://google.github.io/styleguide/docguide/best_practices.html | «A small set of fresh and accurate docs is better…» | Tomado de N6 §3.4 (abierto por N6 el 2026-11-01); no lo volví a abrir |
| F8 | Diátaxis. https://diataxis.fr/ | Cuatro formas de documentación | Tomado de N6 §3.1; ya está en `Referencias.md` (`ref-procida-sf`) |
| F9 | Write the Docs. *Style guides*. https://www.writethedocs.org/guide/writing/style-guides/ | «Working from an existing style guide can also help you figure out which things matter in your style guide» | WebFetch, 2026-11-01 |

## 9. Solicitudes de convocatoria

| Señal | Ubicación | A quién |
| --- | --- | --- |
| ¿El dibujado de mermaid corre en la CI (PR-4) o como control local? | P-20; N7 H3; `ci-local.sh:14` | Verificación (núcleo permanente) |
| ¿Hay un límite de tamaño para la vista web de un Markdown en GitHub, y cuál? | H01 | Peritos: render real de un archivo de prueba de 350, 400 y 450 KB en un repositorio de ensayo |
| Las cifras del portal con método de conteo declarado | H02, P-07 | Perito de la fase de ensayos |

## 10. Excepciones a conocimientos

Ninguna. No propongo dejar de seguir una convención que rige.

## 11. Lo no verificado

- El límite de la **vista web** de GitHub para Markdown: no hay cifra oficial en lo que abrí; las del buscador (≈ 500 KB)
  son de usuarios (clase C). H01 se apoya en la cifra documentada del API y en el tamaño medido.
- La cantidad de términos definidos en el cuerpo (98, N2 E9): no la medí.
- F3 y F6, en fuente primaria (§8).
- La estimación de tamaño usa la densidad del libro MAUI; el libro SDEI real puede quedar por debajo.

## 12. Incidencias del encargo

- La ruta del prompt que da la carta (`…/dac-LDD/PROMPTs/Guides/14-…/02-Ajuste-Coherencia-Reedicion-Documentacion.md`)
  no existe en el worktree de LDD; lo leí, sólo lectura, del clon principal, como ya registraron N2 y N6.
- No llegó ningún mensaje de otra sesión ni texto a mitad de turno que cambiara el encargo.
- No escribí en ningún repositorio; el único archivo escrito fuera del scratchpad es este folio. No nombré proyectos
  privados; el proveedor del caso de industria es una empresa pública que el cuerpo ya nombra.
