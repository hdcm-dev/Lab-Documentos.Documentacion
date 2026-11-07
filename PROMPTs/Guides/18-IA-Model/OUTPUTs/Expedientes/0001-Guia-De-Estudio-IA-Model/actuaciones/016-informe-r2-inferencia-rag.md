# Informe de comisión — ronda 2 · inferencia-rag

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-07 |
| Autor | comisión inferencia-rag (ronda 2: revisión del borrador completo) |
| Corrige | — |

Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas: cabecera y §0 (líneas 1–111, con el Mapa de
carga, fila «Sos una comisión»), §2.2, §3.2, §3.3 y §4. Además cargado: Cadena-De-Consecuencias
2.0 §2 (aplicada antes de cada dirección de corrección que elige entre opciones).
Excepcion-A-Un-Conocimiento 2.1 no se cargó: esta comisión no propone apartarse de ninguna
convención que rige.

Cartas: evidencia/016-carta-comision-ronda-2.md (mandato de esta ronda) y
evidencia/006-carta-comision-inferencia-rag.md (competencia: motores de inferencia, Ollama y
modelos Qwen, cuantización, embeddings, bases de datos vectoriales y RAG; no-competencia: teoría
de arquitecturas más allá del ejemplo, entrenamiento, pedagogía editorial). Lectura P0–P3: la del
folio 002 vía el pliego (evidencia/002-pliego-operativo.md §2). Clase de objeto: corpus documental
existente (quince piezas en `Guides/IA/IA-Model/` del repo de la guía), contrastado contra folios
001, 002 y 011, las observaciones compiladas (evidencia/015) y las constancias del verificador
(despacho/verif-02, verif-03, verif-08, verif-09, verif-11).

Documentos revisados a fondo (los de mi competencia): 08, 09, 03, 11 completos; 06 en su tramo
GGUF→Modelfile→banco; 02 en su laboratorio contra el banco; M1 (glosario y catálogos), M2, M3 y M0
en lo que norma u ordena a los anteriores. Verificaciones E1 propias: corrida del script del lab
08-C (salida byte a byte igual a la transcripta), chequeo de resolución de todos los enlaces
relativos `.md` de 03/08/09/11 (todos resuelven, guía 16 incluida), recuento de marcadores
`VERIFICAR` en el cuerpo (cero en los once temáticos), y re-cálculo aritmético de bpw por esquema
y caché KV.

---

## 1. Hallazgos

### R2-INF-01 · P2 · E2 — El modelo de embeddings de IAM-09 no queda fijado por revisión, y dos lecciones didácticas cuelgan de un empate a tres decimales

- **Ancla (E2)**: `09-Bases-Vectoriales-Y-RAG.md` líneas 339–343 (preparación común: fija
  `torch==2.9.1`, `sentence-transformers==5.1.2`, `faiss-cpu==1.12.0`) y líneas 359/514/654: el
  modelo se carga como `SentenceTransformer("sentence-transformers/paraphrase-multilingual-MiniLM-L12-v2")`,
  por nombre del repositorio de Hugging Face, sin `revision`/commit ni huella registrada en los
  protocolos. Contrastar con `Convenciones.md` §3.2 punto 2 (líneas 147–149): «**Versiones
  fijadas**: el modelo con su etiqueta exacta y su digest (…) Nunca “la última”: regla de la
  casa» — para los GGUF del banco la guía cumple con digest; para el modelo de embeddings, el
  nombre de repo HF es exactamente «una etiqueta que el registro puede mover».
- **Impacto**: el documento explota didácticamente un empate 0,421/0,421 entre distractor y pasaje
  correcto (líneas 564–565 y 592–599: «Con `TOP_K=1` este caso habría fallado») y el ranking del
  ejemplo 3 (0,421 vs 0,512). Una actualización del repositorio del modelo —que `pip` y
  `snapshot_download` toman en silencio— puede invertir el orden y dejar la prosa contradicha por
  la salida que el lector obtiene, sin que ninguna versión fijada lo delate. Es la observación que
  [verificador-09] y [editor-09] dejaron para esta ronda: la **confirmo y la elevo** con esta
  forma: el riesgo no se resuelve «confirmando que el empate es estable» (no se puede prometer
  sobre pesos ajenos futuros), se resuelve fijando el eje.
- **Dirección de la corrección** (Cadena-De-Consecuencias §2 corrida: fijar la revisión cae en el
  lector —una línea más de código—, es reversible y conserva la reproducibilidad; el descargo
  textual solo es más barato pero deja la lección expuesta; ambas juntas dominan): (a) fijar la
  revisión del modelo en la preparación común o en la carga (`revision="<commit>"`), registrándola
  en los tres bloques protocolo junto a las versiones de biblioteca; (b) una frase en §3.1/§3.2
  del estilo del descargo que el documento 01 ya usa para tiktoken: «estas similitudes valen para
  esta revisión del modelo; otra revisión puede reordenar un empate fino». Detectabilidad:
  interpretativo. Origen: del borrador (no aguas arriba).

### R2-INF-02 · P2 · E2 — `entorno_validado` incompleto frente a M3 §6.2 en IAM-02 y IAM-08

- **Ancla (E2)**: `Convenciones.md` §6.2 (líneas 250–252): «Todo documento con ejemplos operables
  lleva `entorno_validado` con la foto mínima (…): **motor y versión, modelo y etiqueta**,
  contexto (CTX) y fecha». Contra eso: `02-Arquitectura-Transformer.md` línea 12 —
  `entorno_validado: python 3.11.2 + numpy 1.24.2, CTX-01, 2026-11-07 (laboratorio 1); laboratorio 2
  verificado por API contra el banco (CTX-03), 2026-11-07` — el laboratorio 2 pega contra el banco
  y la foto no trae ni el motor con su versión (ollama 0.32.0-rc0) ni las etiquetas de los modelos
  interrogados. Y `08-Inferencia-Local.md` línea 12 declara sólo `qwen2.5:7b-instruct`, cuando el
  caso de §1.3 (líneas 125–129) ejercita y afirma cifras de `qwen3.5:4b` (cotejadas por el
  verificador: constancia verif-08 §8, log `08-show-qwen35-4b.json`).
- **Impacto**: la foto mínima existe para juzgar vigencia «sin correr nada» (disparador: «cambio
  de versión del motor del banco», M3 §6.2); sin motor/versión en 02, ese disparador no es
  evaluable para su lab 2; sin el segundo modelo en 08, un movimiento de la etiqueta `qwen3.5:4b`
  no dispara revisión del caso de §1.3. Confirma [editor-02] y [editor-08].
- **Dirección**: completar ambos campos (02: motor+versión y etiquetas del lab 2; 08: agregar
  `qwen3.5:4b` como segundo modelo ejercitado). Aditivo, un archivo cada uno. Detectabilidad:
  enumerable. Origen: del borrador.

### R2-INF-03 · P2 · E2 — Fuentes del glosario de M1 que no sostienen las definiciones de los términos de inferencia, y que divergen de las del documento dueño

- **Ancla (E2)**: `Marco-De-Referencia.md` §5.2, líneas 183–192: «inferencia», «motor de
  inferencia (…) (llama.cpp, Ollama, vLLM)» y «tokens por segundo» llevan como fuente «Yang et al.
  (2025)» (el Qwen3 Technical Report, un informe de familia de modelos, no una fuente que defina
  el software de servicio ni la métrica); «caché KV» lleva sólo «Vaswani et al. (2017)» (el paper
  introduce atención y K/V, no la caché de servicio); «*recall*» lleva «Malkov y Yashunin (2020)».
  El documento dueño (IAM-08) ancla esas mismas definiciones en otras fuentes: motor de inferencia
  → ggml-org/Ollama/Kwon et al. 2023 (líneas 68–70), caché KV → Vaswani **y Pope et al. 2023**
  (líneas 176–179), tokens/s → Ollama (s. f.) (líneas 194–196). La regla 2 del propio glosario
  (M1 §5.1) exige «definición en español, **con fuente** (…) las definiciones normativas viven en
  el documento dueño; el glosario (…) reenvía»: hoy el glosario reenvía con una fuente distinta y
  más débil que la del dueño.
- **Impacto**: el mismo hecho con dos fuentes distintas en dos piezas (el defecto que el mandato 2
  de la carta nombra); un lector o agente que verifique la cita del glosario contra el Qwen3 TR no
  va a encontrar la definición que se le atribuye, y la credibilidad del aparato de citado (EM-09)
  se paga justo en el marco de referencia.
- **Dirección**: alinear la columna fuente del glosario con la fuente que usa el documento dueño
  (inferencia/motor → Kwon et al. 2023 o la documentación oficial del motor; tokens/s → Ollama
  s. f.; caché KV → Vaswani + Pope et al. 2023; *recall* puede quedar en Malkov si se lee como
  recall de ANN, que es el uso del dueño — declararlo «(en recuperación ANN)»). No abrí el Qwen3
  TR para certificar que *no* contenga una definición equivalente: el hallazgo se funda en la
  divergencia citable entre glosario y dueño, no en el contenido del TR. Detectabilidad:
  interpretativo. Origen: del borrador (M1).

### R2-INF-04 · P3 · E2 — El mapa de laboratorios anuncia «servido en el banco» operable para 6.B, pero su tramo final quedó [Ilustrativo] condicionado a una decisión de ACT-03 que sigue abierta

- **Ancla (E2)**: folio 011 §4 («entrenar → doc 06 (QLoRA (…) export GGUF, **servido en el
  banco**)») y `Cohesion-Global.md` §5 línea 207 («Labs 6.A (…), 6.B (receta LoRA de HF al
  banco); DPO **[ilustrativo]**» — marca el ilustrativo de DPO pero no la condición de 6.B),
  contra `06-Ajuste-Fino-Y-Alineacion.md` líneas 553 y ss.: el paso 6 (crear `taller-qwen`/
  `taller-qwen-base` y comparar vía `/api/chat`) está marcado «**[Ilustrativo — no verificado en
  el banco]**», con motivo correcto (crear modelos en el banco es decisión de ACT-03), y el
  frontmatter declara `entorno_validado: parcial`. La duda de [redactor-06] a ACT-03 (crear ~1 GB
  y borrarlo al cierre; default declarado) sigue sin respuesta asentada.
- **Impacto**: acotado — el documento declara todo correctamente; lo que desentona es el mapa (M2
  §5 y la promesa del folio) leído solo, y el `status: borrador`/`confidence: media` de 06 que
  [editor-06] dejó pendiente de esta ronda. No hay rodeo del paso: el bloqueo del tramo está
  declarado, no silenciado.
- **Dirección**: o se resuelve la duda con su default (ACT-03 autoriza; el verificador corre el
  paso 6 y borra; `entorno_validado` pasa a completo) o M2 §5 anota la condición en la fila de 6.B
  igual que anota «DPO [ilustrativo]». Elevo la duda en §4 de este informe. Detectabilidad:
  enumerable. Origen: aguas arriba parcial (la condición nace del mandato de la corrida de
  verificación, no del redactor).

### R2-INF-05 · P3 · E2 — IAM-11: los parámetros de Gemma 4 E4B difieren entre §1.5 y §1.6 sin nota que lo concilie

- **Ancla (E2)**: `11-Panorama-Y-Ecosistema-Abierto.md` línea 168 (§1.5: «E4B: **8B totales** /
  4,5B efectivos», fuente: ficha HF del editor) contra línea 205 (§1.6: «`gemma4:e4b-it-qat` (…)
  **7,5B** (4,5B efectivos)», fuente: `/api/tags` del banco). Mismo modelo, dos cifras de
  parámetros totales en el mismo documento, cada una correcta para su fuente (lo declarado por el
  editor vs. el `parameter_size` que reporta el motor), sin la frase que explique la diferencia.
- **Impacto**: menor pero ubicado en el peor lugar: el documento que enseña a «confrontar ficha y
  artefacto» (lab 11.A paso 4) deja una divergencia ficha/artefacto sin leer en sus propias
  tablas; un lector formado por ese mismo laboratorio la va a encontrar y no tiene respuesta.
- **Dirección**: una nota al pie de §1.6 («el motor reporta N efectivo de tensores cargados; la
  ficha declara el total nominal del editor — la diferencia es esperable y así se lee») o igualar
  la celda citando ambas fuentes. Es, de paso, material didáctico gratis. Detectabilidad:
  enumerable. Origen: del borrador.

### R2-INF-06 · P3 · E2 — El mismo hecho de memoria contado distinto: IAM-09 dice «proporción creciente», IAM-08 (dueño) dice «crece linealmente»

- **Ancla (E2)**: `09-Bases-Vectoriales-Y-RAG.md` líneas 55–57 («la ventana de contexto es finita,
  **cuesta memoria en proporción creciente** (08-Inferencia-Local.md)») contra
  `08-Inferencia-Local.md` líneas 176–179 (caché KV: «**crece linealmente** con la ventana
  ocupada»). «Proporción creciente» admite la lectura superlineal, que el dueño desmiente para la
  memoria (lo cuadrático es el cómputo de atención del prefill, materia de 02, no lo que 09 está
  citando).
- **Impacto**: claridad; el reenvío apunta al 08, que corrige la impresión, pero el principio de
  frontera (M2 §4: el mismo hecho vive una sola vez y los demás lo citan sin desviarlo) pide que
  la frase citante no diga otra cosa que el dueño.
- **Dirección**: «cuesta memoria en proporción al largo del contexto» o directamente «cuesta
  memoria (caché KV, 08)». Detectabilidad: interpretativo. Origen: del borrador.

---

## 2. Disposición de las observaciones de evidencia/015 que tocan mi competencia

| Etiqueta | Disposición |
| --- | --- |
| [M3-convenciones] paso 0 parametrizado (H-IR-03) | **Confirmada**: la forma `${OLLAMA_HOST:-http://localhost:11434}` es idéntica en M3 §3.3, 08 (que la enseña), 02, 03, 09 y 11 (que la citan/corren). Sin fuga de hosts reales en los seis (verificado por grep). |
| [redactor-02] qwen3.5:4b híbrido (ssm.*, full_attention_interval 4) | **Confirmada** como lectura de ficha; verif-02 la cotejó contra el banco. Coherente con el descargo de 08-C («para arquitecturas híbridas (…) la estimación de caché no se extrapola»). Sin acción. |
| [redactor-03] / [verificador-03] (base responde pregunta suelta; bar a T=1,5; top_p) | **Confirmadas**: el texto de 03 incorpora las tres correcciones medidas y el protocolo las declara. |
| [redactor-08] / [verificador-08] (CLI por API, pull ilustrativo, prefill ~8×, caché no descontado, bpw 4,92≈4,85) | **Confirmadas**: todas reflejadas en el texto de 08; mi corrida propia del 08-C reproduce la salida byte a byte. |
| [redactor-09] / [verificador-09] / [editor-09] (camino alternativo, corpus transcripto, empate 0,421) | **Confirmadas**; el empate se **eleva** como R2-INF-01 (fijación de revisión del modelo, no «confirmar estabilidad»). El apartamiento de extensión (870 líneas) está declarado al abrir con eje de partición conforme a M3 §5: lo doy por conforme; partir hoy sería retrabajo contra la condición de revisión del folio 011 §2, que se evalúa sobre el patrón de la casa, no sobre 170 líneas de salidas verificadas. |
| [editor-02] motor sin versión en entorno_validado de 02 | **Confirmada** → R2-INF-02. |
| [editor-08] qwen3.5:4b fuera de la foto de 08 | **Confirmada** → R2-INF-02. |
| [editor-08] PEFT/TRL sin expandir en 08 §2 | **Descartada con motivo**: son nombres propios de bibliotecas (no siglas del dominio del glosario); su dueño (06) las presenta con nombre completo, y 08 las menciona dentro de una cadena que remite explícitamente a 06. La regla de siglas de M1 §5.1 apunta a RAG/LoRA/MoE y afines. |
| [editor-08] / [editor-06] «Yang et al.» vs «Qwen Team» para el Qwen3 TR | Fuera de mi competencia (criterio de citado editorial). **Señal para la comisión de edición**, con ubicación: M3 §2.2 (línea 107) fija «Qwen Team (2025)» para informes técnicos; 03 (línea 737), 06 (línea 773), 08 (línea 754) y M1 (línea 275) citan «Yang, A., et al. (2025)»; 11 (línea 576) y M3 cumplen su propia regla. Mi R2-INF-03 es independiente de cómo se resuelva esa autoría. |
| [redactor-06] duda ACT-03 (taller-qwen en el banco) | **Elevada** → §4, duda 1, y R2-INF-04. |
| [redactor-11] / [verificador-11] / [editor-11] (tabla §1.6 contra el banco; primarias de prensa pendientes) | **Confirmadas**: las once filas quedaron cotejadas (constancia verif-11), las filas sin primaria están marcadas en §1.5, §5, Referencias y en el `entorno_validado`; tarea de ACT-06 declarada. Sin acción para esta ronda. |
| [M2-cohesion] marcas VERIFICAR en IAM-06 (2) e IAM-07 (9) | **Descartada por superada**: grep de hoy sobre los once temáticos da **cero** marcas; la adenda de 015 (reparación de la tubería de 06 y 07) las cerró. Queda sólo el tramo [Ilustrativo] declarado de 6.B (R2-INF-04). |
| [M0-raiz] confirmar cierre de 06/07 antes de `status: vigente` | Para 06: **parcial**, ver R2-INF-04 (promoción de status condicionada a la duda 1 o a asentar la condición). Para 07: fuera de mi competencia; su verificación consta en verif-07 y la comisión que lo cubre debe ratificarla. |

## 3. Lo que revisé y está bien (tope tres)

1. **El aparato cuantitativo de 08 es exacto y reproducible**: corrí el lab 08-C en mi puesto y la
   salida coincide byte a byte con la transcripta; la aritmética de bloques GGML (Q4_0 = 18 B/32 =
   4,5 bpw; Q8_0 = 8,5; Q6_K = 6,5625), la caché KV de qwen2.5:7b (2·28·4·128·2 = 56 KiB/token;
   0,44/1,75 GiB a 8K/32K) y los casos de §1.3–§1.5 cierran contra las constantes del banco que
   verif-08 cotejó. El GQA está bien explicado y bien citado (Ainslie et al., 2023).
2. **El muestreo y las dos APIs en 03 están contados como son**: fórmula de temperatura correcta,
   top_p/top_k según Holtzman, defaults de Ollama (top_p 0,9 / top_k 40) correctos, contratos
   NDJSON y SSE `/v1` con `delta` y `[DONE]` exactos; y las citas muestreadas de mi dominio
   (Holtzman 1904.09751, Lewis 2005.11401, Reimers 1908.10084, MTEB 2210.07316, HNSW 1603.09320,
   FAISS 1702.08734, PagedAttention 2309.06180, GPTQ/AWQ, QLoRA 2305.14314, k-bit 2212.09720,
   Qwen3 Embedding 2506.05176) tienen identificadores correctos y dicen lo que el texto les
   atribuye.
3. **La cohesión operativa de mi dominio se cumple**: todos los enlaces relativos de 03/08/09/11
   resuelven (corrida propia), el paso 0 vive una sola vez (08) y los demás lo citan, la frontera
   EM-05 (servicio→08, calidad→07) y la de embeddings (concepto→01, aplicado→09) se respetan sin
   duplicación, y el camino alternativo de embeddings (sentence-transformers, eje declarado no
   fijo, frontera marcada en el código del lab 2) instancia fielmente el obstáculo del folio 011
   §5 con el error real del banco transcripto y verificado.

## 4. Dudas

| # | Rol · Pregunta · Por qué · Prioridad · Default |
| --- | --- |
| 1 | ACT-03 (operador del banco) · ¿Autorizás crear `taller-qwen` y `taller-qwen-base` (~1 GB en total) en el banco para que el verificador corra el paso 6 del lab 6.B, borrándolos al cierre? · Es lo único que separa el tramo final de 6.B de «operable» como lo anuncia el folio 011 §4, y la promoción de `status` de IAM-06 depende de eso (R2-INF-04); reitera la duda [redactor-06] aún sin respuesta asentada · P2 · Si no respondés: el tramo queda [Ilustrativo] declarado, M2 §5 anota la condición en la fila de 6.B y IAM-06 conserva `entorno_validado: parcial`; nada más queda bloqueado |

(La pregunta sobre habilitar `/api/embed` ya está cursada por fuera del lote — folio 011 §5 — y no
se duplica.)

Sin fichas de excepción. BLOQUEO: ninguno — ningún paso prescripto de mi revisión falló.
