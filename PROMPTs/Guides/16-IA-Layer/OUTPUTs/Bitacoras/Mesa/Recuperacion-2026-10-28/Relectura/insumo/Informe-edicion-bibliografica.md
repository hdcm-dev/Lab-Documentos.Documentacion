---
doc_id: BIT-16-C1-INF-edicion-bibliografica
doc_type: informe-de-especialista
title: Informe del especialista en edición de material bibliográfico — ciclo 1
status: emitido (a ciegas)
origin: agent
confidence: 0.8
owner: especialista «Edición de material bibliográfico» (REED-16 §8.2)
last_review: 2026-10-28
audience: [relator, jurado, cuerpo-auditor, presidencia]
traces: [REED-16 §8.2, §9.1 C5, §9.2 paso 3, §10, §11; BIT-16-00 §3; BIT-16-02 §7, §9; BIT-16-03 §5; BIT-16-04 §3–§5, §8; Nucleos/N0b…N6; Profile Study-Guide-Documentation; Rule-Narrative-Voice; M§8]
---

# Informe — Edición de material bibliográfico (ciclo 1)

**Mandato** (REED-16 §8.2): jerarquía e índices, autocontención, voz única, aparato de referencias con versión y fecha, compresión del texto y glosario unívoco (chequeo C5 de §9.1). **No juzgo corrección técnica**: donde una cuestión de forma esconde una de fondo, emito una solicitud de convocatoria.

**Objeto leído**: la fundación (`00`–`03`), el cuaderno de integración (`04-Integracion.md`) y los nueve registros de `Nucleos/`, incluidas sus notas del 2026-10-28. No leí otros informes de `Mesa/Ciclo-1/`. Como la guía todavía no existe, leo los registros como lo que son: el material del que se va a redactar. Los hallazgos apuntan a lo que, si no se corrige antes de redactar, termina en la guía.

**Evidencia propia**: [`evidencia-edicion-bibliografica/`](evidencia-edicion-bibliografica/) (scripts, salidas y su README). Las rutas son relativas a `OUTPUTs/Bitacoras/`.

## Índice

- [1. Hallazgos](#1-hallazgos)
- [2. Lo que revisé y está bien](#2-lo-que-revisé-y-está-bien)
- [3. Posición sobre los criterios MI de BIT-16-04 §5](#3-posición-sobre-los-criterios-mi-de-bit-16-04-5)
- [4. Solicitudes de convocatoria](#4-solicitudes-de-convocatoria)

---

## 1. Hallazgos

Ordenados por severidad (escala de BIT-16-00 §3).

### EDICIO-01 — La estructura prevista de la guía no tiene quién la vote y perdió dos piezas del Profile

- **Capa de origen**: integración. **Ubicación**: `04-Integracion.md` §8 (l. 363–381) frente a §5 (l. 156) y §3.2 R-C20 (l. 118); `02-Cohesion-Global.md` §6 (l. 153) y §7 (l. 173, 176); `03-Marco-De-Referencia.md` §5 (l. 114).
- **Severidad**: S2. **Evidencia**: E2. **Confianza**: 0,85.
- **Afirmación**: la estructura de la guía depende de decisiones que el cuaderno manda a la mesa y que, por su propia regla, la mesa no vota. Además, la tabla ajustada se quedó sin el mapa conceptual y sin la sección de métodos y marcos.
- **Evidencia**:
  - §8 dice: «La integración propone estos ajustes, **a ratificar por la mesa** junto con PR-12 […], PR-13 […] y PR-14». En cambio, §5 dice: «Lo que no está acá ya no requiere voto», y entre MI-01 y MI-24 no hay ningún ítem que cubra la tabla de §8 ni PR-12, PR-13 o PR-14. R-C20 (l. 118) dice de PR-13 y PR-14: «No se votan acá». El Anexo F existe sólo «si la mesa aplica PR-13» (l. 381).
  - `02` §7 tenía la columna «Pieza del Profile», con el **mapa conceptual** en §3 y **métodos y marcos** en §6. `02` §6 manda S-10 (LangGraph) a «§6 (métodos y marcos)» y `03` §5 fija que el mapa conceptual se arma como tabla «estoy en ESC-xx con CTX-yy → …». La tabla de `04` §8 cambia esa columna por «Ajuste de la integración», y ninguna de las dos piezas aparece en `04` (`grep -i 'mapa conceptual\|métodos y marcos' 04-Integracion.md` = 0).
  - Tres secciones juntan dos núcleos (§1 N1+N1b, §2 N0+N0b, §5 N3b+N3), y la tabla no dice si cada una lleva un solo recorrido del Profile (Definición → Aplicación por escenario → Ejemplos → Preguntas guía → Criterios → Anexo) o dos seguidos.
- **Impacto si no se corrige**: el redactor arranca sin índice aprobado. Si elige uno, decide en lugar de la mesa. Si no lo hace, S-10 y el mapa conceptual se quedan sin sección, y eso rompe C2 y C4 de §9.1.
- **Propuesta de dirección**: que el consolidado del ciclo 1 sume un ítem votable con la tabla de `04` §8 y PR-12, PR-13 y PR-14. La tabla vuelve a tener la columna «Pieza del Profile» (README/§0, resumen ejecutivo, marco, mapa conceptual, documento temático, métodos y marcos, anexos), y cada sección que junta núcleos declara su recorrido interno, que recomiendo único. **Verificación**: toda pieza del Profile tiene §, y la trazabilidad de `02` §6 resuelve S-10 en una sección que existe.

### EDICIO-02 — La autocontención no dice adónde va la evidencia ejecutada en la bitácora

- **Capa de origen**: integración. **Ubicación**: REED-16 §11 (l. 429); `04-Integracion.md` §8, fila E (l. 380); `Nucleos/N6` Anexo B (l. 480–500); `Integracion-Evidencia/`.
- **Severidad**: S2. **Evidencia**: E2 y E1 (listado). **Confianza**: 0,8.
- **Afirmación**: la guía no puede citar la bitácora, pero muchas afirmaciones que va a heredar sólo tienen respaldo en experimentos que viven en la bitácora, y ningún registro dice qué experimento pasa a qué ejemplo.
- **Evidencia**: REED-16 §11 dice: «La guía no referencia la bitácora (es autocontenida) y sí referencia `Examples/` y `Demos/`». Algunas afirmaciones que `04` §3 da por resueltas se apoyan sólo en `Integracion-Evidencia/`:
  - X2 D1 («ante "CP 34" el 4b inventa "34000"/"3400"/"34089" 10/10»).
  - X3 (truncado a contexto/2 + 2 sin error).
  - X1 [A] (nombres OTel distintos → 0 spans).
  - E-B3 (aprobación ejecutada).
  - EA-3 (prueba de arquitectura).

  La lista de ejemplos de N6 Anexo B (01–11) no tiene ninguno para X3, X1 [A] ni EA-3. La fila E de `04` §8 sólo promete «Registros R-LLM de `Examples/` y de `ConModelo/`». Además, la columna «Fuente del patrón» de Anexo B cita ids de bitácora (`[F07]`, `[F10]`, «N4 §G3»).
- **Impacto si no se corrige**: el redactor se queda con dos salidas, y las dos son defectos. Puede afirmar el dato sin respaldo citable (S1 según BIT-16-00) o enlazar la bitácora (contra DC y REED-16 §11).
- **Propuesta de dirección**: antes de redactar, una tabla «evidencia de bitácora → destino en la guía», con cuatro destinos posibles: ejemplo `Examples/NN` que la reproduce, entrada del Anexo E, fuente E4 del Anexo D, o «se omite de la guía». Cada dato medido que la guía conserve tiene que tener un destino reproducible. **Verificación**: un `grep` sobre la guía de rutas e ids de bitácora (`Bitacoras/`, `Integracion-Evidencia`, `E-B[0-9]`, `EA-[0-9]`, `\bX[0-9]\b`, `MI-[0-9]`, `R-C[0-9]`, `RA-[0-9]`) da 0, y todo número medido cita un ejemplo o una referencia.

### EDICIO-03 — El cuerpo de los núcleos conserva texto que la integración ya reemplazó, y no hay versión vigente consolidada

- **Capa de origen**: integración (la regla «sólo agregado» dejó el cuerpo sin marcar). **Ubicación**: cuerpos de `Nucleos/N1`, `N2`, `N3`, `N5` y `N6` (antes de la primera nota `## 2026-10-28`); `04-Integracion.md` §3.2 C-12 = R-C18 (compuerta RD-PO-4, l. 116) y §4.
- **Severidad**: S2. **Evidencia**: E1. **Confianza**: 0,8.
- **Afirmación**: lo vigente de cada núcleo está repartido entre un cuerpo desactualizado y dos notas al final. La única compuerta prevista mira términos de dominio ajeno, no los reemplazos técnicos.
- **Evidencia**: `evidencia-edicion-bibliografica/terminos-reemplazados-salida.txt`. Siguen en el cuerpo:
  - `IAsistenteDeEncuesta` (N1: 6; RA-5 lo reemplaza por `IExtractorDeEncuesta`) e `Infrastructure/Ai` (N1: 1).
  - `[VectorStoreVector(384)]` (N6: 1; R-C12: «El 384 sale de los snippets»).
  - `MSTest` (N5: 1; R-C15: NUnit).
  - `Experimental.Microsoft.Extensions.AI` (N5: 9; R-C06 manda reformular).
  - `reclamo` (N2: 8; N5: 4), `Articulo` (N3: 2) y `Movie` (N1: 2), todos en R-C18.

  La compuerta de `04` (l. 116) agarra los de dominio ajeno pero no `IAsistenteDeEncuesta`, `384`, `MSTest` ni el nombre OTel por defecto.
- **Impacto si no se corrige**: quien redacte desde el cuerpo copia nombres, dimensiones o marcos de prueba que ya se descartaron. En la guía eso es una contradicción entre secciones o con `Examples/` (S1).
- **Propuesta de dirección**: que la redacción parta de una lista de reemplazos sacada de `04` §3 (todo «X → Y» resuelto) y que esa lista sea una compuerta mecánica sobre la guía, `Examples/` y `Demos/`, igual que RD-PO-4. Hay una alternativa más cara: una «hoja de vigencia» por núcleo (párrafo → vigente o reemplazado por RA-/R-C-), agregada como nota fechada. **Verificación**: el `grep` de la lista de reemplazos sobre la guía da 0, salvo las menciones explícitas «se llama distinto en la doc de…».

### EDICIO-04 — El aparato de referencias no tiene espacio de nombres único: el Anexo D no sale de juntar las nueve tablas

- **Capa de origen**: núcleo (cada registro armó su tabla); se propaga a la integración. **Ubicación**: §7 «Tabla de fuentes» de los nueve núcleos; `04-Integracion.md` §8, fila D (l. 379).
- **Severidad**: S3 (aparato no unívoco). **Evidencia**: E1. **Confianza**: 0,9.
- **Afirmación**: el mismo id nombra fuentes distintas, la misma fuente tiene ids distintos, y los metadatos de versión y fecha de una misma página no coinciden entre núcleos.
- **Evidencia** (`fuentes-salida.txt`, `formato-citas-salida.txt`):
  - **41 ids** se repiten en más de un núcleo con contenido distinto. `F10`, por ejemplo, es *structured output* en N1, el ciclo de vida de Azure OpenAI en N2, `IEmbeddingGenerator` en N3, los executors de MAF en N4, el dashboard de Aspire en N5 y vector stores en N6.
  - **21 URLs** aparecen con ids distintos: `…/dotnet/ai/ichatclient` es N1:F05, N2:F2, N5:F05 y N6:F06, y `…/agent-framework/overview/` es N1:F17, N4:F01 y N6:F08.
  - Hay dos formatos de id (`F1` en N2/N3/N3b, `F01` en el resto) y tres estilos de cita: `` `F05` `` (N1, N1b, N5), `[F06]` (N2, N3, N3b, N4, N6) y `(B19)` (N0b).
  - La misma página tiene metadatos distintos: `ichatclient` figura con «act. 2026-08-19» en N1 y N2, sin esa fecha en N5 F05, y «vía N2 F2», sin fecha propia, en N6 F06.
  - N1 escribe sus fechas con guion no separable U+2011 (27 fechas, p. ej. `2026‑03‑04`, `19‑dic‑2024`), y un `grep` de fechas ISO no las encuentra.
  - N0b B03 registra que `anthropic.com/engineering/building-effective-agents` hoy redirige a `/research/…`, pero N1 F02 y N4 F21 citan la URL vieja.
- **Impacto si no se corrige**: una cita como «[F10]» en la guía no se puede resolver, el lector no tiene manera de saber qué versión de una página se consultó, y la compuerta «versiones de la guía = las citadas» (§9.1) no se puede correr.
- **Propuesta de dirección**: antes de redactar, un catálogo único de referencias, agregado como registro nuevo de la bitácora. Cada entrada lleva id estable `REF-nnn`, URL canónica después de la redirección, título, versión o `ms.date`, fecha de consulta en ISO ASCII y núcleos que la usan, más una tabla de equivalencias `núcleo:id → REF-nnn`. En la guía, un solo estilo de cita (`[REF-nnn]`) que resuelve en el Anexo D. Si una página se consultó dos veces con datos distintos, va una entrada con la consulta más reciente y se anota la diferencia. **Verificación**: `fuentes.py` aplicado al catálogo da 0 ids repetidos y 0 URLs con dos ids; toda cita `[REF-…]` de la guía existe en el Anexo D; el `grep -P '\x{2011}'` de la guía da 0.

### EDICIO-05 — Glosario C5 no unívoco: «contexto», «workflow» y «agente» tienen más de un sentido, y «orquestación» y «capa de IA» no tienen definición

- **Capa de origen**: núcleo (definiciones locales); integración (el Anexo C no recoge la lista de C5). **Ubicación**: `Nucleos/N0b` l. 222–303; `Nucleos/N3b` l. 65–67 y §2.6 (l. 118); `Nucleos/N4` §2.2 (l. 70), §2.5, §2.9 (l. 104), §2.15; `Nucleos/N1` §2.4, §2.5, §2.13; `Nucleos/N3` §2.6; `04-Integracion.md` RA-9 (l. 94) y §8, fila C (l. 378); REED-16 §9.1 C5 (l. 359).
- **Severidad**: S3 (término usado con dos sentidos). **Evidencia**: E2 y E1 (conteos). **Confianza**: 0,85.
- **Afirmación**: varios términos de la lista de C5 cambian de sentido entre núcleos, y a veces dentro del mismo párrafo. El Anexo C previsto no se compromete con la lista de C5.
- **Evidencia**:
  - **contexto**: tiene al menos cuatro sentidos. Es el eje del marco (`CTX-*`), la ventana de tokens, el texto armado para el modelo («contexto fijo», N3 §4.4 «armado del contexto», `AIContextProvider`) y el campo de las decisiones de N0b («**Contexto**:»). En N0b l. 240 conviven en una línea: «**Contexto**: […] (CTX-LOCAL)». En N3b l. 65 se habla de «contexto por defecto de Ollama» (ventana) y en l. 67, de «por contexto: CTX-LOCAL × CTX-PROTO».
  - **workflow**: N1 §2.13/P6 y N4 §2.15 lo usan en el sentido de Anthropic (camino fijado por código). N4 §2.5 lo define como el grafo de MAF, que «coordina código, agentes». Por eso N4 l. 70 dice del agente «no es un workflow» y l. 104 dice que «un workflow puede exponerse como agente con `AsAIAgent()`».
  - **agente**: tiene tres definiciones con alcances distintos: N1 §2.13 (operativa, «criterio propio»), N4 §2.2 («en Microsoft Agent Framework») y N6 §2 (`AIAgent`).
  - **herramienta**: aparece también como *tool calling*, *function calling* (N1b: 12 de cada uno) y «caso de uso como herramienta» (N6).
  - **chunk / fragmento**: N3 usa los dos (49 y 34 veces).
  - **prompt**: aparece como «system prompt» (N1, N5), «mensaje de sistema» (N3b) e «instrucciones» (N1 §2.5).
  - **ventana**: N3b §2.6 habla de «declarada y efectiva»; `04` RA-9, de «declarada, nativa, configurada».
  - **orquestación** y **capa de IA** no tienen entrada de definición en ningún núcleo; sólo aparecen en títulos (`grep` de encabezados de §2).
  - La fila C de `04` §8 promete «Definiciones únicas de CAG, ventana declarada/nativa/configurada, vías A/B/C» y no nombra los diez términos de C5.
- **Impacto si no se corrige**: el lector ve que «agente no es un workflow» y, dos párrafos después, que un workflow es un agente. Además, en §2 de la guía «contexto» va a nombrar tanto los ejes del marco como la ventana del modelo.
- **Propuesta de dirección**: fijar el Anexo C antes de redactar, como tabla con término preferido, definición única, sentidos excluidos y la palabra que reemplaza a cada uno. Por ejemplo:
  - «ventana de contexto» siempre completa;
  - los ejes `CTX-*` como «contexto de uso»;
  - el campo de las decisiones como «situación»;
  - el grafo de MAF como *workflow* de MAF, y el sentido de Anthropic como «flujo fijo»;
  - «fragmento (*chunk*)» y «llamada a herramientas (*tool calling*)» en su primera aparición.

  Los diez términos de C5 tienen que estar, con «orquestación» y «capa de IA» definidos. **Verificación**: chequeo C5 por `grep` de cada término y de sus variantes excluidas; cada término de C5 se define una vez en el cuerpo y una en el Anexo C. Que la definición de agente y la de *workflow* sean correctas lo decide el experto en IA (ver §4).

### EDICIO-06 — Identificadores internos que chocan entre sí y con la escala del contrato; seis núcleos sin `doc_id`

- **Capa de origen**: núcleo e integración. **Ubicación**: `04-Integracion.md` l. 94, 117, 210, 357 (G1); l. 92–93 (C4); l. 75 y 108 (T4, T1); `Nucleos/N1` l. 46 y `Nucleos/N4` l. 27, 131 (G1/G2); `Nucleos/N6` l. 91–116 y `N1b` l. 3 (`E1` como experimento); encabezado de N1, N1b, N2, N3, N4 y N5; REED-16 §11 (l. 429).
- **Severidad**: S3. **Evidencia**: E2 y E1. **Confianza**: 0,85.
- **Afirmación**: los prefijos cortos se reusan con sentidos incompatibles. Algunos coinciden con la escala del contrato. Además, los ids de documento que cita `04` no existen en seis registros.
- **Evidencia**:
  - **G1** tiene cinco sentidos: grupo «Modelo» en N1, grupo «El modelo pide, la app ejecuta» en N4, el paper de CAG en N3b, la pauta de Amershi en N0b y la sección 1 de la guía en el mermaid de `04` (l. 210). Dentro de `04`, l. 94 («paper G1») y l. 117/357 («verificar G1, G2 y G9») son cosas distintas.
  - **E1**, que en el contrato es el nivel de evidencia, en N6 es un experimento («[E1 §[2]]»), y N1b también lo usa así («`E1`…`E3`, §8»).
  - **C** es un nivel de evidencia; **C1–C5** son los chequeos de §9.1; **C1–C8** son los casos de N6 («el conjunto de oro de C4»), y **C-1…C-13** son contradicciones.
  - **T1** es una prueba abierta de N6 y **T4** es la tensión 4.
  - **Frontmatter**: N1, N1b, N2, N3, N4 y N5 empiezan directamente en `#`, sin frontmatter. Sin embargo, `04` cita en `traces` «BIT-16-N1, BIT-16-N1b, … BIT-16-N5», y REED-16 §11 exige «Toda la bitácora lleva frontmatter con `doc_id` estable».
- **Impacto si no se corrige**: ahora, el jurado lee «G1» o «E1» y tiene que adivinar a qué se refiere. Más adelante, cualquier id de este tipo que llegue a la guía no se puede resolver, porque la guía es autocontenida.
- **Propuesta de dirección**: para la guía, un esquema de ids propio y declarado en §0 que conserve los que ya son estables (`ESC-`, `CTX-`, `ACT-`, `D-nn`) y renombre el resto con prefijos que no choquen (casos de la demo `CASO-n`, controles `CTRL-nn`, referencias `REF-nnn`). La regla: ningún id de bitácora en la guía (se verifica con el `grep` de EDICIO-02). Para la bitácora, una nota fechada en cada uno de los seis registros, con frontmatter mínimo con `doc_id`. Como el frontmatter va arriba del archivo y no al final, la presidencia tiene que decidir si eso se admite como excepción a «sólo agregado» o si se resuelve con una tabla de `doc_id` en el README.

### EDICIO-07 — Sin presupuesto de compresión: definiciones, snippets y fuentes repetidos en 106 mil palabras de insumo

- **Capa de origen**: integración (falta la regla) y guía (donde se aplica). **Ubicación**: `Nucleos/*` §2 y §4; `04-Integracion.md` §8; REED-16 §10 (S-14); Rule-Narrative-Voice, «Validación».
- **Severidad**: S3 (párrafo redundante). **Evidencia**: E1 (`wc -w`) y E2. **Confianza**: 0,75.
- **Afirmación**: no hay techo de extensión por sección ni una regla de «una definición, un lugar». El insumo repite contenido entre núcleos.
- **Evidencia**: `wc -w` da 106 052 palabras en los nueve núcleos, `03` y `04`. Las repeticiones:
  - **RAG**, definido en N1 §2.12, N3 §2.1 y N6 §2.
  - **Agente**, en N1 §2.13, N4 §2.2 y N6 §2.
  - **Ventana de contexto**, en N1 §2.4, N3b §2.6 y N5 §2.10.
  - **Salida estructurada**, en N1 §2.7, N2 §2.6 y N6 §2.
  - **SK/MAF**, en N2 §2.10 y N4 §2.10–2.12.
  - **Snippets**: los de N1 §4.1 (llamada mínima), §4.4 (embeddings) y §4.6 (agente mínimo) se repiten en N2 §4.1/§4.6 y N4 §4.2.
  - **Fuentes**: 21 URLs se citan dos a cuatro veces (EDICIO-04).

  N1 alimenta a la vez §1 y §3 de la guía (mermaid de `04` §6.1). Los núcleos usan además tres moldes de definición: «Qué es / Problema / Qué no es» (N1, N5), «Qué es / Qué problema resuelve / Qué no es» (N2, N3, N4) y párrafos en negrita (N6), aunque el Profile fija uno solo.
- **Impacto si no se corrige**: la guía integra por suma, y el lector encuentra tres definiciones de RAG con matices distintos. La relectura de S-14 tendría que comprimir después lo que conviene no escribir de entrada.
- **Propuesta de dirección**: que el índice aprobado (EDICIO-01) traiga un presupuesto orientativo de palabras por sección y tres reglas:
  - cada término se define una vez, en la sección donde se enseña, con copia en el Anexo C; las demás secciones remiten;
  - cada snippet aparece una vez; §1 y §3 remiten a §4–§6;
  - un solo molde de definición, el del Profile (qué es, qué problema resuelve, qué no es).

  **Verificación**: `wc -w` por sección dentro del presupuesto (±20 %), y un `grep` de encabezados de definición que no muestre ningún término de C5 definido dos veces en el cuerpo.

---

## 2. Lo que revisé y está bien

1. **Anclas e índices de la bitácora**: los 15 registros (nueve núcleos, `00`–`04` y README) tienen **0 enlaces internos rotos** (`anclas-salida.txt`, 134 enlaces en total), y cada índice lleva a sus encabezados reales. Es la base que §9.1 pide para la guía.
2. **Fecha de consulta en todas las fuentes**: en los nueve núcleos, toda fila de fuente tiene fecha de consulta, propia o de la tabla (`filas_sin_fecha=0`, `fuentes-salida.txt`), y la mayoría de las páginas de Microsoft Learn registran su `ms.date`. El defecto es de unificación (EDICIO-04), no de falta de datos.
3. **Marcas de estatus epistémico uniformes**: los nueve núcleos usan la misma convención, **[criterio propio]** (10 a 19 por núcleo) y **[no verificado]** (7 a 13), y no queda ninguna marca `[C:` sin resolver. A eso se suma la unificación de nombres de código de `04` §3.3 (I-1…I-10). Ese es el trabajo de univocidad que C5 pide, ya hecho para variables, clases y herramientas.

---

## 3. Posición sobre los criterios MI de BIT-16-04 §5

Sólo me pronuncio sobre los que tocan estructura, voz única o compresión. Los demás son técnicos y no entran en mi mandato.

| MI | Posición | Fundamento |
|---|---|---|
| MI-09 | **propuesta** (reescribir los genéricos de N4 con Movilidad Urbana) | Voz única y caso único: con un solo dominio en todos los snippets, el lector no tiene que aprender vocabulario ajeno (`GuessNumber`, `GetWeather`) que después no reaparece. La alternativa, «conceptual sin ejemplo», deja secciones de N4 con una forma distinta a la del resto, sin el paso «Ejemplos» del Profile. Sobre el diff 4.1 → 4.2 no opino: es didáctica. |
| MI-10 | **propuesta** (organizar por mecanismo, con el ecosistema como columna) | Jerarquía y compresión: un eje único (herramienta → agente → *workflow* → MCP) da un solo recorrido del Profile por mecanismo. Organizar por ecosistema repetiría la estructura tres veces (MEAI, MAF, LangGraph) con definiciones duplicadas (EDICIO-07). Aplicarlo exige resolver antes el doble sentido de *workflow* (EDICIO-05). |
| MI-19 | **alternativa** (conceptual sin ejemplo) | Coherencia interna: un campo `Comentario` hipotético choca con la promesa de que la demo es «copia literal de ApiWeb verificable por `diff`» (MI-05). Introduce una entidad del dominio que existe sólo en la guía, y el lector no tiene cómo distinguirla de las reales sin una advertencia que se repetiría en cada aparición. |
| MI-23 | **otra**: dentro de D-06, como consecuencia | Aparato estable: D-06 ya es «Herramientas: sobre casos de uso, con aprobación, con alcance por petición» (N0b l. 265), y el ciclo de vida del cliente es justamente lo que hace posible el «alcance por petición». Meterlo dentro de D-06 mantiene la numeración D-01…D-10 del Anexo F y evita un D-11 que la integración ya cita como cerrado. |

---

## 4. Solicitudes de convocatoria

1. **Experto en IA**, sobre `Nucleos/N4` §2.2 (l. 70) frente a §2.9 (l. 104): más allá del nombre (EDICIO-05), hay que decidir si «un agente no es un workflow» sigue siendo correcto cuando MAF permite exponer un *workflow* como `AIAgent`, y qué definición de agente adopta la guía entre N1 §2.13, N4 §2.2 y N6 §2. No es materia de forma.
2. **Verificación/QA y AH-01 (R-PRIV)**, sobre `OUTPUTs/Reanudar.md` §5 y §3: el archivo, que está en el repositorio público de documentación, contiene la dirección de la tailnet de una máquina del PO dentro de un comando `rsync`, y rutas del home (`{dir-de-trabajo}`). No las transcribo. Pido que se corra la compuerta R-PRIV de §9.1 sobre `OUTPUTs/` entero, no sólo sobre la guía, antes de cualquier commit.
3. **Didáctica**, sobre el recorrido interno de las secciones que juntan dos núcleos (§1, §2 y §5 de `04` §8; EDICIO-01). Decidir si el lector recorre una sola vez «Definición → … → Criterios» o dos veces seguidas es una decisión de progresión, no de edición. Yo recomiendo un solo recorrido por compresión, pero la decisión le corresponde a didáctica.
