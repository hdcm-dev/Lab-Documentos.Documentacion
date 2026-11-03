| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-03 |
| Autor | Comisión C-DIDACTICA |
| Corrige | — |

Incorporado verbatim desde la ruta de trabajo del rol. Lleva marcas de redacción S2 por orden del jurado (folio 011, R-Q2), registradas en el folio 012. Lo que sigue a esta línea, hasta el pase, es la pieza.

---
doc_type: informe
title: Informe de la comisión C-DIDACTICA, expediente 0004 (Docs as Code dentro de una capa de IA)
status: borrador
origin: ia-generated
confidence: media
owner: comisión C-DIDACTICA de la mesa conjunta del expediente 0004
last_review: 2026-11-03
audience: [mesa conjunta del expediente 0004, refutador, jurado, PO]
---

# Informe de la comisión C-DIDACTICA

**Secciones de `Knowledge-Mesa-De-Expertos-A-Pedido.md` leídas:** §0, §2.2, §3.2, §3.3 y §4. Clase de objeto
tomada: **diseño de una norma o decisión** (§2.2): cito fuentes externas con autor y año o norma con número, no
invento cláusulas, y cierro respondiendo cada pregunta del pedido.

**Mandato.** Docencia universitaria en ingeniería de software: cómo convertir Lab-Geometria y `{servicio-privado}`
en material de estudio de la capa de IA, qué tiene que ver funcionando un estudiante y en qué orden.
**No-competencia:** no opino sobre seguridad, arquitectura ni operación salvo cuando condicionan qué se puede
enseñar.

**Clases de ancla** (§3.2): `E1` = lo medí con un comando en esta comisión; `E2` = lo leí en el repo; `C` = lo
tomo de un folio de las partes sin verificar (sólo funda preguntas). Severidad P0–P3.

**Verificaciones hechas contra los repos** (E1, sin modificar nada):

| Afirmación de las partes | Comprobación | Resultado |
| --- | --- | --- |
| DocsAsCode aplicó K 1.4 en Lab-Geometria por PR #248 a #250, expediente `0003-DocsAsCode` | `git log --all` y `git ls-tree origin/main SDD/Expedientes/` | Confirmado: los tres merges y la carpeta están en `origin/main`. **El clon local de `main` está atrasado** (último commit del 2026-11-02; `origin/main` del 2026-11-03) y no muestra el 0003: quien prepare material desde el clon sin `fetch` enseña un estado viejo |
| Capa de IA: banco, criterio previo, corrida con sumas y resumen recalculable en `ai-layer/ensayos/` | `git ls-tree -r origin/main` | Confirmado: `Criterio-R-LLM.md`, `banco.json`, `pistas.py`, `resumir.py`, `corrida-2026-11-01/` con `SHA256SUMS`, `registro-A.jsonl`, `registro-B.jsonl`. `Resultado.md` declara el criterio fijado por commit antes de correr y el recálculo sin modelo |
| Actuaciones 009 y 010 del `EXP0002` y `REQ-IA-18` | `ls` de actuaciones y `grep REQ-IA-18 ai-layer/*.md`; búsqueda en la rama `feat/capa-ia-pendientes-geo` | **No están en el repo**: el `EXP0002` llega hasta la 008 y `REQ-IA-18` no aparece. Coincide con lo que la parte declara («borradores fuera de los repos»): todo lo que dependa de `DEC-GEO` es `C` para mí |
| `REQ-IA-14` (juez sólo con concordancia ≥ 80 % con el docente) y `REQ-IA-15` (sin servidor, degradado) | `grep` en `ai-layer/01-Especificacion-V1-Pistas.md` | Confirmado (E2), con su prueba `NoModelEndpoint_StartsDegraded` |
| docs-guard exige `origin` y `confidence`, y AI-1 a AI-5 | `grep` en `tools/docs-guard/esquemas/cuerpo.schema.json` y `README.md` de Lab-Documentos | Confirmado (E2); AI-3 sólo avisa |
| Guía 16 trata RAG en el capítulo 8 (§8.4, §8.6) | Índice de encabezados de la guía | Confirmado (E2): §8.4 «Consulta, filtros, contexto y citas», §8.6 «Riesgos de la recuperación» |
| Resultado del ensayo ciego «ocho corridas válidas, ninguna pasa» (`EXP3/208`) | Búsqueda del folio 208 | No lo localicé con la ruta citada: queda `C` |

## 1. Cómo resuelve la industria esta cuestión, desde la docencia

1. **Se enseña por alineación constructiva.** Primero se escribe qué tiene que poder hacer el estudiante, después
   la tarea que lo obliga a hacerlo y por último la evaluación que lo verifica (Biggs, 1996, *Higher Education*
   32; Biggs y Tang, *Teaching for Quality Learning at University*). Los verbos se gradúan con la taxonomía
   revisada de Bloom (Anderson y Krathwohl, 2001): reconocer un artefacto, ejecutarlo, analizar una corrida,
   evaluar una decisión, crear un control. **Es la misma regla que las dos sesiones aplicaron a los modelos**
   («banco, rúbrica y oráculo antes de correr»). En la cátedra se aplica al estudiante.
2. **Una tarea compleja se enseña entera, de lo simple a lo complejo, y no por piezas sueltas.** El modelo 4C/ID
   (van Merriënboer, 1997; van Merriënboer y Kirschner, *Ten Steps to Complex Learning*, 2007) pide clases de
   tareas completas de complejidad creciente, con andamiaje que se retira. La aprendiz cognitiva (Collins, Brown
   y Newman, 1989) pide **ver al experto trabajar** (modelado), después hacerlo con ayuda y por último solo. El
   andamiaje viene de Wood, Bruner y Ross (1976). Con ejemplos resueltos se aprende más que resolviendo desde
   cero mientras el alumno es novato (Sweller y Cooper, 1985), y la ayuda conviene retirarla de a poco (Renkl y
   Atkinson, 2003). Esto descarta enseñar «la capa de IA» como una lista de temas: hay que enseñarla como un ciclo
   completo que se repite, cada vez más difícil.
3. **La carga cognitiva manda el orden** (Sweller, 1988, *Cognitive Science* 12). No se presentan juntos el
   modelo, las herramientas, la recuperación, la identidad y la evaluación estadística. Se agrega **una variable
   por escalón**. Es el mismo principio que el filtro «el peritaje cambia una sola variable» de §3.3.
4. **Qué contenidos pide la disciplina.** *Computer Science Curricula 2023* (ACM, IEEE-CS y AAAI, 2023) trata
   juntas la ingeniería de software y la IA, con la ética y la seguridad repartidas en todas las áreas. El
   *SWEBOK Guide* v4.0 (IEEE Computer Society, 2024) mantiene la calidad, las pruebas y la gestión de
   configuración como áreas de conocimiento. Del lado profesional, la bibliografía de ingeniería de sistemas
   con ML coincide en el núcleo que hay que enseñar:
   - la deuda técnica oculta en todo lo que rodea al modelo (Sculley et al., 2015, NeurIPS);
   - una lista de pruebas de preparación para producción (Breck et al., 2017, «The ML Test Score», IEEE Big Data);
   - la documentación estandarizada de modelos y datos (Mitchell et al., 2019; Gebru et al., 2021, «Datasheets
     for Datasets», *Communications of the ACM* 64(12));
   - la evaluación holística y versionada de modelos de lenguaje (Liang et al., «HELM», 2022);
   - los límites del juez automático (Zheng et al., 2023, «Judging LLM-as-a-Judge», NeurIPS);
   - las pruebas de comportamiento por capacidad (Ribeiro et al., 2020, «CheckList», ACL);
   - la inyección indirecta por contenido recuperado (Greshake et al., 2023, AISec);
   - la recuperación aumentada (Lewis et al., 2020, NeurIPS).

   Los textos de cátedra más usados lo presentan como ingeniería de sistemas y no como uso de modelos (Huyen,
   *Designing Machine Learning Systems*, O'Reilly, 2022; Huyen, *AI Engineering*, O'Reilly, 2025).
5. **Docs as Code se enseña como práctica de entrega continua**, no como redacción: la documentación vive en el
   repo, pasa por PR y por CI (Gentle, *Docs Like Code*, 2017; Humble y Farley, *Continuous Delivery*, 2010). Se
   organiza por función del texto: tutorial, guía práctica, referencia y explicación (Procida, marco Diátaxis).
   **En la industria, Docs as Code entra a la capa de IA por tres puertas:**
   - el prompt, la evaluación y la ficha del modelo son artefactos versionados que pasan por PR;
   - el corpus que lee la IA es un producto con control de entrega;
   - lo que la IA escribe es un borrador que pasa por revisión.

   Un curso enseña esas tres puertas en ese orden.
6. **La retroalimentación tiene que ser correcta antes que abundante.** Una retroalimentación errónea perjudica
   más que su ausencia (Hattie y Timperley, 2007; Shute, 2008). Esto respalda la tesis de la lente didáctica de
   Geometría («una pista falsa daña más que una vaga») y la vuelve **criterio de puesta en uso con estudiantes**:
   para el estudiante, una pista falsa es un P0, no una media que baja.
7. **La integridad académica y el uso declarado de IA.** Las universidades piden hoy declarar el uso de IA en los
   trabajos. El campo `origin` (`human`, `ia-assisted`, `ia-generated`) es la versión verificable por máquina de
   esa declaración, y se enseña como tal. No cito una política institucional concreta: no verifiqué ninguna.

## 2. Lo que coincide, lo que falta y lo que sobra

### 2.1 Coincide con la práctica docente e industrial

| Práctica | Evidencia | Ancla |
| --- | --- | --- |
| Criterio fijado antes de correr, con commit; recálculo sin modelo | `ai-layer/ensayos/Resultado.md` y `Criterio-R-LLM.md` en `origin/main` de Lab-Geometria | E2 |
| Corrida rotulada con modelo, digest, opciones, k/n e IC95 de Clopper-Pearson | `Resultado.md` §1 y §2 (`qwen3.5:4b`, 0/30 [0,000; 0,116] de fuga) | E2 |
| Sumas de verificación de la evidencia cruda | `corrida-2026-11-01/SHA256SUMS` | E2 |
| Capa apagada por defecto, con prueba | `REQ-IA-15`, `NoModelEndpoint_StartsDegraded` | E2 |
| El juez sólo vale si concuerda con el docente | `REQ-IA-14` (umbral 80 %) | E2 |
| Procedencia declarada en el frontmatter | esquema de docs-guard (`origin`, `confidence` obligatorio si no es humano) | E2 |
| Par rojo/verde de cada control; «avisa» antes de «bloquea» | PR #248 a #250 de Lab-Geometria (fusionados) | E2 de los merges; el contenido del par, `C` |
| «Pasar el filtro no es enseñar»; dos pistas falsas que pasan el filtro | posición de la Capa de IA, `DEC-GEO` | `C` (fuera del repo) |
| ADR con «deja de valer si» (Nygard, 2011) | `ai-layer/03-ADR.md` existe; el campo, según la posición | E2 del archivo; el campo, `C` |

### 2.2 Falta

- **P1. No hay resultados de aprendizaje.** Ningún artefacto de los dos proyectos dice qué tiene que poder hacer un
  estudiante con él. Hay especificación, ADR, banco y expediente, que son material de experto. Sin resultados de
  aprendizaje no hay alineación constructiva, y la cátedra no puede evaluar al alumno con las mismas reglas con
  que se evaluó al modelo. (E2: el `ai-layer/README.md` y los cinco documentos son especificación, no guía de
  laboratorio.)
- **P1. La utilidad didáctica la midió un juez, no un docente.** La posición informa puntajes de utilidad «juez, no
  docente» (4,5 la plantilla; 2,4 `qwen3.5:4b`). `REQ-IA-14` exige una concordancia con el docente que no se midió.
  Para mi mandato, **no existe todavía evidencia de que las pistas enseñen**: existe evidencia de que no filtran
  el valor. (E2 de `REQ-IA-14`; los puntajes, `C`.)
- **P1. Ninguno de los dos casos tiene recuperación de documentos.** Geometría es A0 sin herramientas.
  `{servicio-privado}` usa herramientas de lectura sobre cifras. La pregunta del PO («cómo se integra Docs as Code
  dentro de la capa de IA») tiene su respuesta más clara en RAG con filtro por `delivery`, y eso sólo está en la
  guía 16, capítulo 8 (E2). **El estudiante no puede ver funcionando la puerta 2** (el corpus como producto que
  lee la IA) en ninguno de los dos proyectos.
- **P1. `{servicio-privado}` no es reproducible por estudiantes.** Es privado, sus modelos van por código y su
  evidencia queda en su repo. Didácticamente sirve como **caso de estudio narrado** (como un caso de Harvard), no
  como laboratorio. La lección de Goodhart (M-1 que premiaba un validador flojo) y la atribución falsa ([redactado S2: ejemplo con cifra del producto privado]) son de las mejores del material, pero hay que publicarlas como folio genérico
  dentro de Lab-Geometria o de la guía 16, con los números y sin topología. Si no, se pierden. (`C`.)
- **P2. Choque de nombres entre métricas.** Geometría llama M1 a M5 a fuga cruda, fuga filtrada, forma, rechazo y
  latencia (`Resultado.md`, E2). `{servicio-privado}` llama M-1 y M-4 a respaldo y rechazo con otra definición
  (`C`). Para un estudiante que estudia los dos casos, «M4 rechazo» significa dos cosas distintas. La propuesta
  de la Capa de IA («la métrica es un documento con versión») lo resuelve si el identificador lleva el caso
  (`GEO-M4`, `SP-M4`).
- **P2. El material vigente está fuera del repo.** Las actuaciones 009 y 010 y `REQ-IA-18` no existen en ninguna
  rama (E1). Lo más didáctico de la jornada, la decisión provisional que la evidencia corrige, no se puede
  asignar como lectura hasta que se foliee.
- **P3. El clon local está atrasado respecto de `origin/main`** (E1): una cátedra que prepara desde el clon enseña
  el estado anterior a #248–#250.

### 2.3 Sobra para el estudiante, no para el proyecto

- **El ensayo con aplicador ciego y su coordinador** son investigación sobre si un conocimiento sirve para un
  agente. Sirven para un seminario de posgrado o un trabajo final, no para el núcleo de grado: suman una variable
  (el aislamiento del agente) que no ayuda a aprender la capa.
- **Las trece familias de controles y la mecánica completa de expedientes y folios.** Al estudiante le alcanza con
  tres controles que vea fallar y pasar. El resto es carga extrínseca (Sweller, 1988). El expediente se enseña
  **como lectura de un caso**, no como forma que el alumno tenga que reproducir.
- **La doble nomenclatura de severidades y estados** («avisa/bloquea», P0–P3, «provisional/definitivo», «borrador
  ensayado, no probado»). Para enseñar conviene una sola: avisa/bloquea en la compuerta y P0–P3 en hallazgos.

## 3. Respuestas propias

### 3.1 Qué ve funcionando el estudiante, y en qué orden

Cada escalón agrega **una** variable, se hace sobre Lab-Geometria y termina con algo que el estudiante **ve fallar y
pasar**. `{servicio-privado}` entra sólo como caso narrado.

| # | Escalón (variable nueva) | Qué ve funcionando | Resultado de aprendizaje (verbo de Bloom) | Fuente en el repo |
| --- | --- | --- | --- | --- |
| 1 | Docs as Code sin IA | Un PR con frontmatter roto queda en rojo; se corrige y queda en verde; un control en «avisa» deja pasar un main con una contradicción | **Aplicar** una compuerta y **explicar** avisa contra bloquea | PR #248–#250 y expediente `0003-DocsAsCode` |
| 2 | El modelo detrás de un puerto, apagado | Sin servidor configurado, la app arranca degradada y sirve la plantilla; la prueba `NoModelEndpoint_StartsDegraded` pasa | **Explicar** por qué fusionar no es poner en uso | `REQ-IA-15`, ADR |
| 3 | El prompt como código | El estudiante cambia una regla del prompt; la prueba prompt = ficha queda en rojo hasta que actualiza la ficha | **Aplicar** la trazabilidad prompt ↔ documento | Prompt en `Infrastructure/AI`, ficha en `ai-layer/01` |
| 4 | La evaluación versionada | Corre `python3 -I resumir.py corrida-2026-11-01/registro-*.jsonl` y obtiene **los mismos números** que `Resultado.md`; verifica `SHA256SUMS` | **Analizar** una corrida: k/n, IC95, por qué 0/30 no prueba 0 % | `ai-layer/ensayos/` |
| 5 | El filtro no es la calidad | Lee las dos pistas geométricamente falsas que pasaron el filtro y escribe el caso que las detecta (o explica por qué no lo hay) | **Evaluar**: distinguir un control de seguridad de uno de corrección | `DEC-GEO`, hoy `C`: falta foliarlo |
| 6 | Docente contra juez | Puntúa 10 pistas con la rúbrica, compara con el juez y calcula la concordancia de `REQ-IA-14` | **Evaluar** la validez de una métrica automática | `REQ-IA-14`; banco |
| 7 | Herramientas e identidad (caso narrado) | Lee el caso de Goodhart en M-1 y la regla R2 [redactado S2: defecto de seguridad abierto del validador, informado al responsable]; escribe el caso trampa | **Evaluar** una métrica y **crear** un caso negativo | Folio genérico de `{servicio-privado}` por publicar |
| 8 | El corpus que lee la IA (RAG con `delivery`) | Construye un índice por audiencia, siembra un canario restringido y ve que la prueba negativa queda en rojo con el índice global y en verde con el filtrado | **Crear** un control de entrega antes del índice | Guía 16 cap. 8; **no existe en ninguno de los dos proyectos**: es el trabajo práctico integrador |
| 9 | Lo que la IA escribe | Un borrador `origin: ia-generated` no puede fusionarse sin `revisado_por: humano`; el estudiante es el humano | **Evaluar** un borrador y firmar | Esquema de docs-guard más el campo propuesto |

El orden no es negociable en dos puntos: **la evaluación (4) va antes que la calidad (5 y 6)**, porque sin saber
leer k/n el alumno no puede juzgar el filtro, y **RAG (8) va al final**, porque junta las variables de todos los
escalones anteriores.

### 3.2 Las siete preguntas de DocsAsCode

1. **¿Dónde vive el filtro por `delivery`?** En el sistema documentador, que es la fuente de verdad y genera un
   corpus por audiencia. La capa de IA **verifica** con la prueba negativa y no filtra por su cuenta. Lo enseño
   así porque es el único diseño que el estudiante puede probar en dos lugares y razonar en uno solo: si la capa
   filtra, hay dos fuentes de verdad y el alumno no sabe a cuál corregir.
2. **¿Qué identidad usa la capa para recuperar?** La del usuario final, siempre. El agente y el servicio sólo
   pueden reducir ese alcance. Se prueba con un caso trampa por audiencia («mostrame lo de otra audiencia») y con
   la prueba de que ningún argumento que ejecutó una herramienta trae un identificador que el usuario no tenga. En
   la cátedra es el escalón 7.
3. **¿Lo que escribe un agente cuenta como fuente antes de la aprobación humana?** No. Va como `origin:
   ia-generated` y `revisado_por: ninguno | agente-independiente`, y no entra a ningún índice ni a ninguna puesta
   en uso hasta `revisado_por: humano`. Las plantillas «definitivas» de Geometría, redactadas por un agente y con
   una falsa (`C`), son el ejemplo que lo enseña.
4. **¿`AGENTS.md` y equivalentes son documentación o configuración?** Son configuración que se documenta: viven en
   el repo con frontmatter y vigencia, y un cambio en ellos tiene el mismo efecto que un cambio en el prompt, con
   la misma prueba de igualdad entre el archivo y su ficha. Para el estudiante: un archivo que cambia la conducta
   de un programa es código, aunque esté escrito en prosa.
5. **¿Qué bloquea desde el principio?** Desde mi mandato, lo que perjudica al estudiante si pasa una sola vez:
   - la prueba negativa de no publicación y el canario de contexto;
   - la prueba prompt = ficha;
   - la capa apagada sin configuración;
   - **la pista falsa conocida**: todo caso del banco con una pista marcada falsa por el docente tiene que fallar
     la compuerta de puesta en uso con estudiantes. No bloquea la fusión, porque main despliega con la capa
     apagada.
6. **¿Cómo se ensaya con aplicador ciego cuando el resultado son respuestas de un modelo?** Para lo que tiene
   oráculo determinista (fuga, forma, cifras respaldadas) el aplicador ciego no hace falta: alcanza con el banco y
   el recálculo sin modelo. Para la utilidad didáctica el oráculo es **un docente con rúbrica**, y el umbral es el
   de la Capa de IA, que sostengo: media ≥ 4/5, por encima de la plantilla y **cero pistas falsas**. El ciego se
   reserva para el agente que especifica con el Conocimiento. Un juez automático sólo reemplaza al docente
   después de medir la concordancia ≥ 80 % de `REQ-IA-14` (Zheng et al., 2023, sobre los sesgos del juez).
7. **¿Los cuatro P0 de K 1.4 se cierran antes de integrar la capa?** Se integra sobre el borrador, rotulado, **y no
   se usa como material de estudio obligatorio hasta cerrarlos**. Enseñar un conocimiento con cuatro P0 abiertos
   como si fuera la norma es enseñar el error (Shute, 2008). En la cátedra se puede usar como caso: «este
   conocimiento no pasó su ensayo, y así se ve por qué».

### 3.3 Las preguntas de la Capa de IA que tocan mi mandato

- **1. ¿La ficha de capacidad es un `doc_type` nuevo?** Sí, con esquema en docs-guard. Un formato libre no se puede
  dar como plantilla de trabajo práctico ni corregir con lista de cotejo. Campos mínimos para enseñar: los de
  Mitchell et al. (2019) que sí aplican (uso previsto, límites, evaluación) más «deja de valer si».
- **3. ¿Una corrida rotulada es documento o evidencia?** Las dos cosas, separadas. Los registros crudos con
  SHA-256 son evidencia inmutable. El resumen rotulado es documento con frontmatter y se regenera desde la
  evidencia. Así lo tiene hoy `ai-layer/ensayos/` (E2), y es lo que hace posible el escalón 4.
- **4. ¿Cómo se firma la revisión humana cuando el PO delegó en mesas?** Para material de estudio la firma humana
  es la del **docente responsable** y no se delega. Mientras no esté, D-23 queda «Parcial», declarado. Un
  «revisor independiente no humano» no cumple D-23: es un buen segundo control, pero no es lo que D-23 pide.
- **5. ¿El nombre del modelo en un repo público junto a la decisión de un producto privado?** En el material de
  estudio, el modelo se nombra del lado de Geometría y el caso de `{servicio-privado}` va con modelos por código.
  Al estudiante no le hace falta saber qué modelo usó el producto privado para aprender la lección de Goodhart.
- **6. ¿AIL-n en docs-guard o en la guía 16?** Fuera de mi mandato, salvo una condición didáctica: se pueda correr
  en local con un comando y con su par rojo/verde, para que entre al escalón 3.
- Las preguntas 2 y 7 quedan fuera de mi mandato.

## 4. Lo que revisé y está bien

- `ai-layer/ensayos/` en `origin/main` de Lab-Geometria es un **ejemplo resuelto** de evaluación versionada, listo
  para usar en clase: criterio con commit previo, banco con huella, registros crudos con `SHA256SUMS`, resumen
  recalculable sin modelo y rótulo completo (E2). No conozco un material público de cátedra que lo muestre tan
  completo a esta escala.
- `REQ-IA-14` y `REQ-IA-15` están escritos con su prueba o su umbral y sirven tal cual como enunciados de trabajo
  práctico (E2).
- El esquema de docs-guard ya tiene la declaración de procedencia (`origin`, `confidence`) que la docencia
  necesita para el uso declarado de IA (E2).
- La guía 16 ya cubre RAG con filtros y riesgos de recuperación (§8.4, §8.6): el escalón 8 tiene texto de base
  aunque no tenga caso (E2).
- Los tres PR de DocsAsCode en Lab-Geometria están fusionados en `origin/main` y el expediente `0003-DocsAsCode`
  existe (E1): el escalón 1 tiene material real.
- Las dos posiciones declaran honestamente lo que no saben (RAG sin experiencia, numeración de ISO/IEC 42001 sin
  verificar, folios fuera del repo). Eso es justo la conducta que hay que enseñar.

## Fuentes externas

- ACM, IEEE-CS y AAAI (2023). *Computer Science Curricula 2023 (CS2023)*.
- IEEE Computer Society (2024). *Guide to the Software Engineering Body of Knowledge (SWEBOK Guide)*, versión 4.0.
- Anderson, L. W. y Krathwohl, D. R. (eds.) (2001). *A Taxonomy for Learning, Teaching, and Assessing*. Longman.
- Biggs, J. (1996). «Enhancing teaching through constructive alignment». *Higher Education*, 32.
- Biggs, J. y Tang, C. *Teaching for Quality Learning at University*. Open University Press.
- Collins, A., Brown, J. S. y Newman, S. E. (1989). «Cognitive apprenticeship: teaching the crafts of reading,
  writing, and mathematics». En Resnick (ed.), *Knowing, Learning, and Instruction*.
- van Merriënboer, J. J. G. (1997). *Training Complex Cognitive Skills*. Educational Technology Publications.
- van Merriënboer, J. J. G. y Kirschner, P. A. (2007). *Ten Steps to Complex Learning*. Erlbaum.
- Sweller, J. (1988). «Cognitive load during problem solving: effects on learning». *Cognitive Science*, 12.
- Sweller, J. y Cooper, G. A. (1985). «The use of worked examples as a substitute for problem solving in learning
  algebra». *Cognition and Instruction*, 2.
- Renkl, A. y Atkinson, R. K. (2003). «Structuring the transition from example study to problem solving».
  *Educational Psychologist*, 38.
- Wood, D., Bruner, J. S. y Ross, G. (1976). «The role of tutoring in problem solving». *Journal of Child Psychology
  and Psychiatry*, 17(2).
- Hattie, J. y Timperley, H. (2007). «The power of feedback». *Review of Educational Research*, 77(1).
- Shute, V. J. (2008). «Focus on formative feedback». *Review of Educational Research*, 78(1).
- Gentle, A. (2017). *Docs Like Code*. Lulu Press.
- Humble, J. y Farley, D. (2010). *Continuous Delivery*. Addison-Wesley.
- Procida, D. *Diátaxis*, marco de documentación técnica.
- Sculley, D. et al. (2015). «Hidden Technical Debt in Machine Learning Systems». NeurIPS.
- Breck, E. et al. (2017). «The ML Test Score: A Rubric for ML Production Readiness and Technical Debt Reduction».
  IEEE International Conference on Big Data.
- Mitchell, M. et al. (2019). «Model Cards for Model Reporting». FAT* 2019.
- Gebru, T. et al. (2021). «Datasheets for Datasets». *Communications of the ACM*, 64(12).
- Ribeiro, M. T. et al. (2020). «Beyond Accuracy: Behavioral Testing of NLP Models with CheckList». ACL.
- Liang, P. et al. (2022). «Holistic Evaluation of Language Models». arXiv; publicado en TMLR en 2023.
- Zheng, L. et al. (2023). «Judging LLM-as-a-Judge with MT-Bench and Chatbot Arena». NeurIPS.
- Greshake, K. et al. (2023). «Not what you've signed up for: Compromising Real-World LLM-Integrated Applications
  with Indirect Prompt Injection». AISec '23.
- Lewis, P. et al. (2020). «Retrieval-Augmented Generation for Knowledge-Intensive NLP Tasks». NeurIPS.
- Huyen, C. (2022). *Designing Machine Learning Systems*. O'Reilly.
- Huyen, C. (2025). *AI Engineering*. O'Reilly.
- Nygard, M. (2011). «Documenting Architecture Decisions».

Sigue: incorporar el informe siguiente · presidencia de la mesa
