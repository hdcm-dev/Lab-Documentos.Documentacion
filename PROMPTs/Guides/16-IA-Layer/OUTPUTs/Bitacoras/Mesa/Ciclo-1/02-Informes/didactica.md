---
doc_id: BIT-16-M1-INF-DID
doc_type: informe-de-especialista
title: Informe del especialista en didáctica — Ciclo 1, sobre BIT-16-04 v0
origin: agent (especialista en didáctica, pedido por el PO; DC-02)
last_review: 2026-10-26
objeto: OUTPUTs/Bitacoras/04-Plan-De-Integracion.md (v0)
modo: a ciegas (no se leyeron informes de otros especialistas)
---

# Informe de didáctica — Ciclo 1

**Mandato**: ¿el recorrido forma criterio? Progresión de lo general a lo particular, carga cognitiva, prerrequisitos, objetivos de aprendizaje, preguntas guía formadoras, autoevaluación y ejemplos en escalera. No opino sobre la corrección técnica del código.

**Contraste usado**: Profile `Study-Guide-Documentation` (estructura de cada documento temático; «formativo, no enciclopédico»; «de lo general a lo particular»), R-PO-3 de la reedición, objetivo del contrato (BIT-16-00 l. 51–55: «un desarrollador .NET sin experiencia previa en IA»), N0b §3.3.4 (los 19 objetivos), I-02 (L-3, L-7, L-8, L-9; PR-1..PR-7), I-03 (PR-8..PR-12), I-04 (PR-13..PR-15), I-05 (A-4; PR-16..PR-22), I-06.

Las líneas citadas son de `04-Plan-De-Integracion.md` v0.

## Índice

- [1. Hallazgos](#1-hallazgos)
- [2. Posición sobre las propuestas PR](#2-posición-sobre-las-propuestas-pr)
- [3. Revisado y bien](#3-revisado-y-bien)
- [4. Solicitudes de convocatoria](#4-solicitudes-de-convocatoria)

---

## 1. Hallazgos

### H-DID-01 · Términos y escalones que se usan antes de definirse (S2, E2, confianza 0,8)

- **Ubicación**: §A.2 (l. 64), §C Parte I §1 y §3 (l. 323–345), §4.2 (l. 352), §0.3 (l. 316), Anexo C (l. 465).
- **Afirmación**: el plan asegura que la combinación propuesta cumple «definición antes del uso», pero la Parte I ya usa el vocabulario y los escalones que recién se definen en la Parte II y siguientes.
- **Evidencia (E2)**: l. 64, «Definición antes del uso (SUP-07, compresión) | … | Sí». Pero §3 (l. 342) pide armar la «Tabla por escenario: ESC-xx × CTX-yy → escalón de cada escalera → sección» y ubicar D1–D7 «en las escaleras», cuyos escalones son «Contexto completo con prefijo cacheado («CAG de servicio»)», «RAG agéntico» y «UseFunctionInvocation» (l. 213–225). El vocabulario mínimo (LLM, token, ventana, salida estructurada, embedding…) llega recién en §4.2 (l. 352), y el glosario está en el Anexo C (l. 465). Además, §0.3 (l. 316) lista lo que el lector necesita **instalado** (Docker, Ollama), pero ningún prerrequisito **de conocimiento**, aunque la tesis (l. 43) da por sabidos puerto, adaptador y raíz de composición.
- **Impacto si no se corrige**: el lector principal, que no tiene experiencia en IA, se cruza con el mapa —la pieza que tiene que organizarle todo lo demás— cuando todavía no puede leerlo. O lo saltea, o lo memoriza sin entenderlo, y la línea de orientación de cada sección («estás en el escalón X de la escalera Y», l. 145) se le vuelve opaca.
- **Dirección**: que el lector tenga, antes del mapa, una definición operativa de cada término que el mapa usa. Que la Parte I presente las escaleras en una versión que se pueda leer sin las Partes III y IV, y que se retome completa cuando ya se conocen los escalones. Y que §0 declare los prerrequisitos de .NET que la guía da por sabidos.

### H-DID-02 · La escalera de ejemplos y la de la demo no siguen el orden de lectura (S2, E2, confianza 0,85)

- **Ubicación**: §C §6 (l. 375), §7 (l. 384), §8 (l. 395); §E.2–§E.4; §F.1 (tabla D1–D7, l. 579–587).
- **Afirmación**: los ejemplos están numerados y clasificados por complejidad técnica, no por el orden en que el lector los encuentra. La demo, por su parte, empieza por una escritura.
- **Evidencia (E2)**: según las secciones, el lector ve los ejemplos en este orden: 01–04 (§5), **12** (§6), 10–11 (§7) y recién después **05** «Primera herramienta» (§8.3), 06, 07, 09, 13, 14; 08 aparece en §9 y 15–17 en la Parte V. El 05 es del nivel básico, y PR-3 pone «primera herramienta» en el básico (I-02 l. 65), pero se hace después de los intermedios. El 12 (§6) incluye la variante «C RAG top-k» con MEVD e InMemory (l. 557) antes de que §7 enseñe embeddings y `VectorStore`, y además es el ejemplo más caro de montar (Ollama propio, `num_ctx` explícito). En la demo, D1 es «C2 + herramienta `agregar_localidad` | agencia 1» (una escritura), antes que D2 y D3 (agencia 0) y que D4 (lectura). Eso va contra PR-20, que el plan adopta: «Primer ejercicio de sólo lectura» (l. 498).
- **Impacto si no se corrige**: la promesa de I-02 L-3 (demos en escalera, intercaladas con la teoría) no se cumple en la práctica. El lector salta de básico a intermedio y vuelve a básico, y su primer contacto con herramientas en la demo es la escritura, que es justamente lo que PR-20 quería dejar para después.
- **Dirección**: que el orden de lectura y el orden de la escalera coincidan. Cada ejemplo tendría que usar sólo conceptos ya enseñados en su sección o en las anteriores, y la demo, recorrerse de menor a mayor escalón, empezando por la lectura. Si un ejemplo comparativo necesita conceptos posteriores, que se mueva o que se parta.

### H-DID-03 · Los objetivos de aprendizaje no se alinean con la autoevaluación y dejan huecos (S2, E2, confianza 0,75)

- **Ubicación**: §A.3 (l. 92–102), §C §15 (l. 458–460), §D PR-4 (l. 482).
- **Afirmación**: los 19 objetivos se adoptan con la «revisión de didáctica pendiente» (l. 92). Al revisarlos, encuentro tres problemas: la autoevaluación no se arma desde ellos, falta el objetivo de la pregunta que el plan declara central, y dos objetivos no se pueden observar.
- **Evidencia (E2)**:
  - §15 se agrupa «por ESC-01…05 y por actor» (l. 459) y sale de «las preguntas guía de §2–§14» (l. 460). No hay ninguna relación entre objetivo e ítem de autoevaluación.
  - PR-4 se adopta como «pregunta central» (l. 482), pero OA-D6 sólo dice «elegir entre herramienta, agente y workflow» (l. 97): ningún objetivo cubre la decisión de usar varios agentes. La escalera de conocimiento con CAG (§6) no tiene objetivo para ACT-DEV (OA-A3 es de ACT-ARQ), y MCP (§8.9) no tiene ninguno.
  - OA-O1 («saber qué cambia al activar `EnableSensitiveData`») y OA-O3 («leer… como tendencia… y conocer sus sesgos», N0b l. 206 y 208) usan verbos de los que no sale ninguna conducta verificable. N0b Q-R2 (l. 361) exige objetivos observables.
- **Impacto si no se corrige**: el lector «sin el perfil» (I-04) no tiene cómo comprobar que alcanzó lo que se le promete en §0.1, y la pregunta que el plan pone en el centro de la Parte IV no queda entre lo que se promete enseñar.
- **Dirección**: que cada objetivo tenga al menos un ítem de autoevaluación que lo verifique, y cada ítem, el objetivo que verifica. Que los temas centrales (uno o varios agentes, la escalera de conocimiento, MCP) tengan su objetivo. Y que todo objetivo se formule como una conducta que el lector pueda demostrar.

### H-DID-04 · Las rutas de lectura por actor se saltean los prerrequisitos y no cubren sus propios objetivos (S3, E2, confianza 0,8)

- **Ubicación**: §C §0.2 (l. 315) frente a §A.3 (l. 98–101) y l. 145.
- **Afirmación**: las rutas de los lectores secundarios no pasan por las secciones donde se enseñan sus objetivos, y tampoco por el mapa ni por el vocabulario que cada sección da por leídos.
- **Evidencia (E2)**: la ruta de ACT-ARQ es «§1–§4, §6, §9, §13» (l. 315), pero OA-A3 remite a «§6, §7» (l. 98): §7 no está en la ruta. Además, ACT-ARQ lee en §13 las decisiones D-06 y D-07 sin haber pasado por §8, la sección que las enseña (§8.11, l. 392). Las rutas de ACT-OPS («§5, §10, §12») y de ACT-SEC («§2, §7.6, §8.5, §11») no incluyen §3 (el mapa) ni §4 (el vocabulario), aunque «cada sección temática se ubica en él con una línea al empezar» (l. 145).
- **Impacto si no se corrige**: el lector que sigue la ruta de su rol llega a secciones que suponen un marco y un vocabulario que nunca leyó, y se saltea el lugar donde se enseña lo que esa misma tabla le promete.
- **Dirección**: que la ruta de cada actor contenga las secciones de todos sus objetivos y el tronco común (marco, mapa y vocabulario mínimo) que esas secciones presuponen. Que la correspondencia entre rutas y objetivos se pueda verificar mecánicamente.

### H-DID-05 · Demasiadas preguntas guía, con duplicados y con preguntas que no forman criterio (S3, E2, confianza 0,75)

- **Ubicación**: §C, la línea «Preguntas guía» de §1 a §14.
- **Afirmación**: las preguntas guía se arman sumando por sección las de los dossiers (por ID), no diseñándolas a partir de los objetivos. El resultado es un volumen alto, preguntas repetidas y chequeos fácticos mezclados con preguntas de decisión.
- **Evidencia (E2)**:
  - **Volumen**: hay unas 93 preguntas en §1–§14, más «una pregunta por ADR» (l. 445). Por sección: 13 en §8 (l. 396), 11 en §7 (l. 385), 10 en §5 (l. 365) y en §9 (l. 405), 9 en §6 (l. 376).
  - **Duplicados**: en §8 aparecen «¿Cuándo alcanza con tool calling y cuándo necesito un agente?» (N4 P1) y «¿Necesito un agente o alcanza con `UseFunctionInvocation`?» (N6 P7). Local o nube se pregunta en §2 (N6 P9), §5 (N1b P4), §12 (N5 P9) y §14 (N6 P9 otra vez). «¿Quién puede ver qué fragmento?» está en §7 y en §11, y el conjunto de evaluación sin usuarios, en §7 y en §10.
  - **Preguntas que no forman criterio**: varias son de estado de un paquete o se responden con sí o no, y envejecen rápido: «¿`Microsoft.Extensions.AI.Ollama` sigue sirviendo?» (N2 P4), «¿Y AutoGen?» (N4 P7), «¿Puedo confiar en que `gen_ai.*` no cambie?» (N5 P3). R-PO-3 pide preguntas «formadoras de criterio, que le permitan al lector identificar en qué caso se aplica cada concepto».
- **Impacto si no se corrige**: las preguntas centrales (la de PR-4, por ejemplo) se diluyen entre muchas otras, la autoevaluación hereda los duplicados y la guía se acerca a lo «enciclopédico» que el Profile descarta.
- **Dirección**: un conjunto acotado de preguntas por sección, cada una atada a un objetivo y a una decisión del lector. Cada pregunta, en un solo lugar (los demás remiten). Los chequeos de estado de un paquete, en el anexo de versiones y no como preguntas guía.

### H-DID-06 · Carga concentrada en §8 y en el primer contacto con el código (§5) (S3, E2, confianza 0,65)

- **Ubicación**: §C §8 (l. 389–396), §5 (l. 358–365), Anexo F (l. 468).
- **Afirmación**: la escalera de agencia, que es el principio que organiza la Parte IV, se comprime en una sola sección muy cargada. Y la primera sección con código suma detalles de un proveedor en particular y del estado de los paquetes.
- **Evidencia (E2)**: §8 junta los escalones 1 a 4, MCP y la decisión «¿uno o varios?» en 11 subsecciones (§8.1–§8.11), con 6 ejemplos (`05`, `06`, `07`, `09`, `13`, `14`), 4 pasos de demo (D1, D4, D6, D7) y 13 preguntas, mientras que la escalera de conocimiento ocupa dos secciones (§6 y §7). §5 tiene 9 subsecciones, 4 ejemplos y 10 preguntas, e incluye §5.7 «Lo que Ollama no te dice» y §5.8 «Paquetes vigentes y obsoletos», que se superpone con el Anexo F «Versiones verificadas y señales de obsolescencia» (l. 468).
- **Impacto si no se corrige**: el lector principal recibe juntos, en su primera sección con código, el concepto (`IChatClient`) y un montón de excepciones de proveedor. En §8 tiene que sostener cinco niveles de autonomía en una sola unidad, sin un cierre entre escalón y escalón.
- **Dirección**: que cada escalón de agencia tenga su unidad, con cierre propio (ejemplo y pregunta), y que la simetría entre las dos escaleras se vea en la estructura. Que en §5 las particularidades del proveedor y el estado de los paquetes no compitan con el concepto: van a advertencias en el lugar donde se usan o al anexo que ya existe.

### H-DID-07 · El escalón 2 (workflow) sólo tiene contraejemplo (S3, E2, confianza 0,7)

- **Ubicación**: §B.3 (l. 243), §E.4 `13` (l. 563), §F.1 (l. 579–587).
- **Afirmación**: para formar un concepto hacen falta ejemplos y contraejemplos. Al workflow el plan le da sólo el contraejemplo.
- **Evidencia (E2)**: «la encuesta de tres pasos es el **contraejemplo**: parece un workflow (escalón 2) y es una función (escalón −1)» (l. 243). El ejemplo `13` muestra la encuesta «como workflow… **y** como función, para mostrar por qué la función gana» (l. 563). En la demo no hay ningún paso en «agencia 2»: D1 y D4 están en el 1, D2 y D3 en el 0, D6 en el 3 (l. 581–587).
- **Impacto si no se corrige**: el lector aprende cuándo **no** usar un workflow, pero no ve en el caso ninguna situación en la que sí corresponda. Va a llegar a la decisión «¿agente o workflow?» (N4 P3, §8) sin un caso positivo con el cual comparar, y esa decisión es justamente la que el plan elige como eje de la escalera (P-01).
- **Dirección**: que el escalón 2 tenga una instancia positiva dentro de Movilidad Urbana, o, si el caso no la tiene, que se lo diga explícitamente y el escalón se enseñe en forma conceptual, como prevé RD-PO-3 para lo que no encaja en el dominio. No le toca a didáctica proponer cuál sería el caso: ver la solicitud SC-2.

---

## 2. Posición sobre las propuestas PR

| PR | Posición | Fundamento (didáctico) |
|---|---|---|
| PR-1 | apoya | Definir el *AI Engineer* como faceta de ACT-DEV, por sus decisiones, ubica al lector sin sumar un actor más que aprender. |
| PR-2 | apoya_con_cambios | §4.1 es mejor lugar que §1 (P-11), pero los hitos (uso de herramientas, salida estructurada, ventanas) aparecen antes del vocabulario de §4.2: el vocabulario mínimo tiene que estar disponible antes que la línea de tiempo (H-DID-01). |
| PR-3 | apoya_con_cambios | Tres niveles, sí. Pero el nivel tiene que coincidir con el orden de lectura, y la primera herramienta tiene que estar de verdad en el básico (H-DID-02). |
| PR-4 | apoya_con_cambios | Es una pregunta formadora. Le falta su objetivo de aprendizaje y un solo lugar de tratamiento, sin las variantes duplicadas que hoy tiene §8 (H-DID-03, H-DID-05). |
| PR-5 | apoya_con_cambios | Apoyo el reorden por autonomía que hace el plan: da un criterio monótono (cuánto decide el modelo y cuánto cuesta equivocarse) que forma más criterio que el orden por artefactos. Con dos condiciones: el escalón 2 necesita una instancia positiva (H-DID-07) y cada escalón, su unidad (H-DID-06). |
| PR-6 | apoya_con_cambios | La autoevaluación tiene que construirse desde los objetivos, con su respuesta explicativa y la remisión a la sección; no alcanza con reformular las preguntas guía (H-DID-03). |
| PR-7 | se_opone | De acuerdo con el NA del plan: I-06 (RD-PO-1) lo impide, y lo que PR-7 buscaba (ver el patrón chico antes de mezclarlo con el dominio) lo cubre PR-20 sobre catálogos que el lector ya conoce. |
| PR-8 | apoya_con_cambios | La escalera de conocimiento con CAG está bien como estructura. El ejemplo comparativo `12` no puede depender de RAG antes de §7, y DEV necesita un objetivo para esta escalera (H-DID-02, H-DID-03). |
| PR-9 | apoya | La versión corta (cuatro preguntas y la definición de éxito) es una buena entrada de criterio antes de la técnica. |
| PR-12 | apoya_con_cambios | Marco y mapa primero, como pide el Profile, pero con un vocabulario operativo previo y un mapa que se pueda leer sin las partes que vienen después (H-DID-01). |
| PR-13 | apoya | Poner las ADR después de los temas, con anticipos (P-02), respeta el orden «conocer las alternativas antes de elegir». |
| PR-14 | apoya_con_cambios | Objetivos al abrir, sí, pero observables, completos y alineados con §15 (H-DID-03), y con rutas de lectura que los cubran (H-DID-04). |
| PR-15 | apoya | Como lista de control interna de la relectura no afecta al lector y le sirve a la cobertura. |
| PR-16 | apoya | Un principio corto que se repite y se ve en el código es un ancla didáctica estable para toda la guía. |
| PR-17 | apoya | Partir de una aplicación que ya existe le da al lector un punto de partida conocido. Como encuadre de la demo, y no como escenario nuevo, no agrega una dimensión más al marco. |
| PR-18 | apoya | Como pregunta guía, enseña a decidir; construir un marco propio no forma criterio y cambia el alcance. |
| PR-20 | apoya_con_cambios | Bien el primer ejercicio de sólo lectura con pruebas negativas, pero tiene que ser de verdad el primero, también en la demo (hoy D1 es una escritura) (H-DID-02). |
| PR-22 | apoya | El ejemplo pareado (antes y después) es aprendizaje por contraste; en §9.3, después de §8, el lector ya conoce la forma vigente. |

PR-10, PR-11, PR-19 y PR-21 tocan cobertura y seguridad, que no son de mi mandato: no tomo posición.

---

## 3. Revisado y bien

1. **Patrón interno único** (l. 300–307): las secciones temáticas siguen los seis pasos del Profile, y se declara una sola vez en §0.4. El lector aprende una sola forma de leer.
2. **Orientación en cada sección** (l. 145): la línea «estás en el escalón X de la escalera Y, en la capa Z» es un buen dispositivo para ubicarse. Funciona, siempre que el mapa sea legible cuando el lector llega a él (H-DID-01).
3. **Escalón −1 y carril del dato exacto** (l. 228–229, 243): incluir la opción sin modelo y el caso «contar localidades → herramienta, nunca RAG» como contraejemplos explícitos forma criterio de verdad, porque enseña cuándo **no** subir un escalón.

---

## 4. Solicitudes de convocatoria

- **SC-1 (edición bibliográfica)**: revisar la superposición entre §5.8 y el Anexo F, y la ubicación del glosario (Anexo C) respecto de los términos que la Parte I usa. Es jerarquía y autocontención, no didáctica.
- **SC-2 (IA y arquitectura)**: confirmar que la asignación de escalones a D1–D7 y a los ejemplos es técnicamente coherente (por ejemplo, D1 en agencia 1 y D6 en agencia 3), y decir si en Movilidad Urbana existe una instancia positiva del escalón 2 (workflow). La escalera didáctica depende de esa clasificación y no me toca juzgarla.
