# Informe de comisión — ronda 2 · Fundamentos, arquitecturas y panorama de modelos

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-07 |
| Autor | comisión fundamentos-panorama (ronda 2) |
| Corrige | — |

Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas: cabecera y §0 (líneas 1–111, con el Mapa de
carga), §2.2, §3.2, §3.3, §4 y §5.2 (la carta). Además cargado: Cadena-De-Consecuencias 2.0 §2
(corrida antes de las dos recomendaciones entre opciones, hallazgos 01 y 02); el pliego operativo
(evidencia/002) como condensación de Escalas-De-Juicio 1.2, Expediente 1.0, Mesa 1.1 y
Detencion-Y-Lote 1.1. No propongo excepciones a ninguna convención que rige: no hay ficha.

Insumos: las 15 piezas del borrador en `<worktree-guia>/Guides/IA/IA-Model/` (leídas enteras:
M0, M1, M2, M3, 01, 02, 03, 10, 11; barridas por comando: 04–09 en lo que cruza mi competencia);
folios 001, 002 y 011; observaciones compiladas (evidencia/015, con su adenda); constancias del
verificador citadas por las observaciones. Clase de objeto: corpus documental existente. Lectura
P0–P3: la del folio 002. Competencia: NLP, LLM, arquitecturas transformer y variantes, modelos
generativos y multimodales, taxonomía de modelos open source, tendencias y estándares de la
industria. No-competencia: entrenamiento y ajuste, operación local de inferencia, decisiones
editoriales o pedagógicas.

Cláusula de bloqueo: ningún paso prescripto falló. La verificación por muestreo de citas corrió
con web al alcance (ver anclas). Sin BLOQUEO.

---

## 1. Verificación por muestreo de citas (método)

Muestreo sobre los documentos de mi dominio (01, 02, 03, 10, 11, M1): todos los identificadores
arXiv/DOI cotejados coinciden con el trabajo que el texto afirma, incluidas las afirmaciones
ancladas en contenido del paper (InstructGPT: modelo de 1,3 B preferido al base de 175 B —
Ouyang et al. 2022; Mixtral 47 B totales / 13 B activos — Jiang et al. 2024; Whisper 680 000
horas — Radford et al. 2023; GQA y el par `head_count`/`head_count_kv` — Ainslie et al. 2023).
Verificación en vivo (2026-11-07) de tres identificadores sensibles:

```text
$ for id in 2305.13245 2607.02770 2505.09388; do curl -s "https://arxiv.org/abs/$id" | grep -oE '<title>[^<]+' | head -1; done
<title>[2305.13245] GQA: Training Generalized Multi-Query Transformer Models from Multi-Head Checkpoints
<title>[2607.02770] Gemma 4 Technical Report
<title>[2505.09388] Qwen3 Technical Report
```

Las filas de §1.5 del doc 11 con fuente de prensa (Muse, GLM-5, Kimi K3) están correctamente
marcadas «primaria pendiente de verificación» en el propio documento, con la tarea asignada a
ACT-06: no se cuentan como defecto. Lo que no resistió el muestreo está en los hallazgos 03, 05
y 08.

---

## 2. Hallazgos

### R2-FUN-01 · P1 · E2 — M3 §6.1 prohíbe lo que 02 y 05 ya hacen: cifras históricas de modelos con cita primaria

- **Documento**: `Convenciones.md` §6.1 (y `02-Arquitectura-Transformer.md` §1.6,
  `05-Preentrenamiento-Y-Leyes-De-Escala.md`).
- **Ancla E2**: M3 §6.1: «Los documentos estables **no citan cifras ni rankings de modelos
  concretos** salvo vía la tabla de referencia del documento 11 (§6.3)» — sin excepción escrita.
  Contra eso, 02 §1.6: «Mixtral 8×7B lo mostró en el ecosistema abierto: 47 B de parámetros
  totales con unos 13 B activos por token (Jiang et al., 2024)», y el doc 05 cita cifras de
  GPT-3/Chinchilla/LLaMA «sólo históricas y de paper» declarándolas «conforme a M3 §6.3»
  (observación [redactor-05]) — una conformidad que la letra de §6.1/§6.3 no otorga.
- **Marcas**: aguas arriba (origen: folio 011, FP-04/FP-05/ARQIA-02, que fundan la regla por
  vigencia, no por prohibición de lo histórico); interpretativo.
- **Confirma** las observaciones [editor-02] («la mesa debe decidir si un hecho arquitectónico
  citado queda exento») y la lectura divergente de [redactor-05]: dos redactores ya aplicaron la
  norma de dos maneras — la definición de P1 del pliego.
- **Impacto si no se corrige**: cada ronda editorial futura rehace la misma discusión, y un
  barrido literal de M3 §6.1 obligaría a mutilar secciones verificadas de 02 y 05 cuyo contenido
  no caduca.
- **Cadena de consecuencias §2** (dos opciones): **(A)** asentar en M3 §6.1 la exención — cifra
  histórica o arquitectónica con cita primaria de paper, no comparativa del parque vigente — cae
  en M3 (una cláusula), peso una frase, no pierde nada medible, reversible quitándola. **(B)**
  reencaminar esas cifras vía la tabla del doc 11 — cae en 11 (cargaría la capa volátil con datos
  que no caducan, contra su propio propósito §1.1) y en 02/05 (retrabajo de secciones con salida
  verificada). A es reversible y barata; B es retrabajo que degrada la capa volátil.
- **Dirección**: opción A; condición de revisión comprobable: si una «cifra histórica» aparece
  usada comparativamente contra el parque vigente en una revisión de la capa volátil, esa cifra
  vuelve a canalizarse por la tabla de 11 §1.6.

### R2-FUN-02 · P2 · E1 — «destilación» tiene dueño 11 en el glosario y el doc 11 no la define

- **Documento**: `Marco-De-Referencia.md` §5.2 (fila «destilación», dueño 11) y
  `11-Panorama-Y-Ecosistema-Abierto.md`.
- **Ancla E1**: `grep -n -i 'destilaci' <worktree-guia>/Guides/IA/IA-Model/*.md` → una sola
  ocurrencia, la fila del glosario de M1 (línea 179); en el doc 11, cero. La regla 2 del glosario
  (M1 §5.1) exige que la definición normativa viva en el documento dueño.
- **Marcas**: de la corrida (la asignación de dueño la hizo M1 en esta fase); enumerable.
- **Confirma** [M1-marco] («si el redactor del 11 no la define, es hueco por la regla FP-07») y
  [redactor-11] («quedó sin sección normativa propia… agregado de ~15 líneas»).
- **Impacto**: término del glosario cuyo reenvío cae al vacío; el lector que llega por la ruta de
  consulta no encuentra la definición prometida.
- **Cadena de consecuencias §2**: **(A)** sección normativa breve en 11 §1 (~15 líneas, medidas
  por el propio redactor; la destilación aparece en el panorama como práctica de publicación —
  variantes «distill» del ecosistema) — cae en 11, aditiva, reversible. **(B)** reasignar el dueño
  a 06 (la destilación como técnica de entrenamiento) — cae en M1 (una celda) más una definición
  en 06, territorio de otra comisión. Pesos equivalentes; A no cruza fronteras de competencia y
  respeta la asignación ya votada del glosario.
- **Dirección**: opción A; si la comisión de entrenamiento la reclama normativa para su cadena,
  se muda con reenvío (una sola decisión, no dos definiciones).

### R2-FUN-03 · P2 · E2 — Fuentes del glosario que no dicen lo que la definición afirma

- **Documento**: `Marco-De-Referencia.md` §5.2.
- **Ancla E2**: tres grupos de filas: (a) «caché KV … Vaswani et al. (2017)» (línea 187) —
  Vaswani et al. 2017 no trata la caché de claves/valores de inferencia; el mecanismo se describe
  en la literatura de decodificación incremental (p. ej. Shazeer, 2019, arXiv:1911.02150, que el
  propio doc 02 ya cita); (b) «ventana de contexto … Vaswani et al. (2017)» (línea 151, y doc 01
  §1.5 repite el anclaje) — el paper no define una ventana compartida entrada/salida; eso es
  propiedad del uso autoregresivo decoder-only (Brown et al., 2020); (c) «inferencia», «motor de
  inferencia» y «tokens por segundo» ancladas a «Yang et al. (2025)» (líneas 183–188) — el Qwen3
  Technical Report no es fuente que defina términos genéricos de servicio.
- **Marcas**: de la corrida; enumerable.
- **Impacto**: la regla 2 del glosario («definición con fuente») queda cumplida de nombre: un
  lector que abra la fuente no encuentra la definición, y la restricción dura del pedido («toda
  afirmación respaldada por evidencia verificable») se erosiona justo en la pieza que norma al
  resto.
- **Dirección**: reanclar — caché KV a Shazeer (2019) o a la documentación del motor con fecha de
  consulta; ventana de contexto a Brown et al. (2020) o sin cita de paper (definición operativa de
  esta guía, declarada como tal según M3 §2.3); los tres términos de servicio a documentación
  oficial de motor (llama.cpp/vLLM/Ollama) con fecha de consulta, conforme a M3 §2.2.

### R2-FUN-04 · P2 · E2 — El mismo informe técnico citado con dos autorías, contra el patrón que M3 §2.2 norma

- **Documento**: `Marco-De-Referencia.md`, `03-…`, `06-…`, `08-…` contra `Convenciones.md` §2.2 y
  `11-…`.
- **Ancla E2**: M3 §2.2, fila «Informe técnico de un equipo de modelos»: «Equipo como autor
  colectivo … Qwen Team (2025). “Qwen3 Technical Report”. arXiv:2505.09388» — es el ejemplo
  normado. Contra eso, M1 línea 275, 03 línea 737, 06 línea 773 y 08 línea 754 citan el mismo
  arXiv:2505.09388 como «Yang, A., et al. (2025)»; 11 y el propio M3 lo citan «Qwen Team (2025)».
  La forma «Yang, A., et al.» no es falsa (arXiv lista autores individuales), pero M3 declara el
  control y cuatro documentos no lo ejercen.
- **Marcas**: de la corrida; enumerable.
- **Confirma** [editor-06] y [editor-08] (la adenda pidió «unificar criterio en la ronda 2»).
- **Impacto**: el lector de la lista de referencias no puede saber que cuatro documentos citan la
  misma fuente; el control de M3 §2.2 queda como letra muerta en más de un tercio del cuerpo.
- **Dirección**: barrido de unificación a la forma de M3 §2.2 (autor colectivo) en M1, 03, 06 y
  08; filtro «descripción o control» del uso: el control existe y se decide ejercerlo, no
  reescribirlo en silencio.

### R2-FUN-05 · P2 · E2 — M1 enuncia mal la OSAID: «libertades sobre … datos» no es lo que la norma exige

- **Documento**: `Marco-De-Referencia.md` §5.2 contra `11-Panorama-Y-Ecosistema-Abierto.md` §1.2.
- **Ancla E2**: M1 línea 200: «Según la OSAID 1.0, exige libertades sobre pesos, código **y**
  datos». La OSAID 1.0 (OSI, 2024, la fuente que la propia fila cita) no exige liberar los datos:
  exige «información suficientemente detallada sobre los datos de entrenamiento» — exactamente
  como lo dice el doc 11 §1.2 («información suficientemente detallada sobre los datos de
  entrenamiento (OSI, 2024)»). El mismo estándar contado distinto en dos piezas, y la forma del
  glosario — la de una línea, la que los demás citan — es la incorrecta.
- **Marcas**: de la corrida; enumerable.
- **Impacto**: la distinción pesos abiertos / open source es decisión central del caso (FP-06);
  un lector que aplique la línea del glosario clasificaría mal: con la lectura «exige los datos»,
  prácticamente ningún sistema calificaría jamás y el matiz real de la OSAID (datos descriptos,
  no liberados) se pierde.
- **Dirección**: alinear la definición breve del glosario con la formulación de 11 §1.2.

### R2-FUN-06 · P2 · E1+E2 — El doc 02 corre contra el banco sin declarar la versión del motor

- **Documento**: `02-Arquitectura-Transformer.md` (§3.2 y frontmatter).
- **Ancla E1**: `grep -n '0.32.0' <worktree-guia>/Guides/IA/IA-Model/02-Arquitectura-Transformer.md`
  → sin salida (rc=1): ninguna mención de la versión del motor en todo el documento, aunque el
  laboratorio 2 pega contra el banco y transcribe sus fichas. **E2**: M3 §3.2 punto 2 («la
  herramienta con su número … nunca “la última”») y §6.2 (`entorno_validado` lleva «motor y
  versión»); el frontmatter de 02 dice sólo «laboratorio 2 verificado por API contra el banco
  (CTX-03)». Los documentos hermanos (03, 10, 11) sí la declaran (ollama 0.32.0-rc0).
- **Marcas**: de la corrida; enumerable.
- **Confirma** [editor-02] (segunda observación de su lista).
- **Impacto**: las claves de ficha que el lab 2 enseña a leer dependen de cómo el motor expone
  `/api/show`; sin versión declarada, una divergencia futura no puede diagnosticarse con el
  propio método que M3 §3.2 punto 5 exige.
- **Dirección**: asentar «ollama 0.32.0-rc0» en el encabezado de §3.2 y en `entorno_validado`,
  igual que los hermanos.

### R2-FUN-07 · P2 · E2 — El glosario cerró la fase sin consolidar los candidatos que los núcleos ya usan con definición propia

- **Documento**: `Marco-De-Referencia.md` §5.2.
- **Ancla E2**: regla 3 del glosario (M1 §5.1): «Entra al glosario el término que algún núcleo
  usa»; regla 4: «los redactores agregan entradas … el mantenedor (ACT-06) consolida». Los
  redactores declararon los candidatos y los definieron en sus núcleos, y la tabla no los tiene
  (verificado: `grep -n 'BPE\|SentencePiece\|subpalabra' Marco-De-Referencia.md` → sin salida;
  ídem RoPE, GQA/MQA, máscara causal): BPE, subpalabra, SentencePiece (doc 01, [redactor-01]);
  RoPE/codificación de posición, GQA/MQA, máscara causal (doc 02, [editor-02]); encoder de
  visión/ViT, códec neuronal, ASR, espectrograma (doc 10, [redactor-10], [editor-10]); «system
  prompt», safetensors ([editor-06]); corpus, procedencia, JSONL, datasheet (doc 04,
  [redactor-04]); el verbo «des-tokenizar» sin forma fijada ([editor-01]).
- **Marcas**: de la corrida; enumerable.
- **Confirma** las siete observaciones citadas; la consolidación prevista por la regla 4 no
  ocurrió antes del cierre de la fase de elaboración.
- **Impacto**: términos con definición normativa en un dueño que el índice común no sabe ubicar;
  la promesa de M1 («todos los documentos usan estas formas canónicas») queda parcial y el
  siguiente redactor vuelve a acuñar formas propias.
- **Dirección**: un solo barrido de consolidación de ACT-06 sobre la lista de arriba antes de
  promover ninguna pieza a `status: vigente`; los términos de dominios ajenos al mío (corpus,
  JSONL, safetensors) entran al barrido con el dueño que sus comisiones confirmen.

### R2-FUN-08 · P3 · E2 — Afirmación de industria sin fuente ni marca en el doc 11

- **Documento**: `11-Panorama-Y-Ecosistema-Abierto.md` §1.1.
- **Ancla E2**: «GPT-5.1, del mismo editor, falla la primera: sólo existe detrás de una API» —
  afirmación sobre un producto concreto y vigente, sin cita y sin la marca que las filas de §1.5
  sí llevan. M3 §2.3: «Toda afirmación de industria o academia lleva su cita».
- **Marcas**: de la corrida; enumerable.
- **Impacto**: menor (la frase es ilustrativa y verosímil), pero está en la pieza que enseña a
  exigir fuentes, y es de la capa volátil: sin fecha ni fuente no hay disparador de revisión que
  la alcance.
- **Dirección**: cita de editor con fecha de consulta, o reformular sin nombre de producto («los
  modelos frontera del mismo editor sólo existen detrás de una API»).

---

## 3. Observaciones de evidencia/015 de mi competencia: disposición

| Observación | Disposición |
| --- | --- |
| [redactor-02] híbrido atención/SSM de `qwen3.5:4b` tratado como lectura de ficha en 02 §1.7 | **Confirmada como correcta**: interpretación declarada, claves confirmadas por [verificador-02]; el criterio («reconocer el híbrido, no dominar los SSM») es el adecuado para ACT-01 |
| [verificador-02] correcciones al lab 2 (digest por `/api/tags`, patrón `ssm\.`, aclaración `clip.*`) | **Confirmadas**: incorporadas al documento tal como se describen |
| [editor-02] Mixtral §1.6 vs M3 §6.1 | **Elevada** como R2-FUN-01 |
| [editor-02] lab 2 sin versión del motor | **Confirmada** como R2-FUN-06 |
| [editor-02] RoPE/GQA/máscara causal sin entrada en el glosario | **Confirmada**, consolidada en R2-FUN-07 |
| [M1-marco] seis fuentes agregadas al glosario (Hu 2022, Dettmers 2023, Rafailov 2023, Zheng 2023, Hinton 2015, Ji 2023) | **Confirmadas como correctas**: las seis son canónicas del dominio y sus identificadores coinciden con el trabajo citado |
| [M1-marco] «destilación» dueño 11 | **Confirmada** como R2-FUN-02 |
| [redactor-11] destilación ~15 líneas; filas de §1.5 con primaria pendiente | **Confirmadas**: la primera es R2-FUN-02; la segunda está bien resuelta (marcada en el documento, tarea de ACT-06) |
| [editor-06]/[editor-08] Yang et al. vs Qwen Team | **Confirmada** como R2-FUN-04 |
| [redactor-01] BPE/subpalabra/SentencePiece candidatos | **Confirmada**, en R2-FUN-07 |
| [redactor-10]/[editor-10] ViT/códec neuronal/ASR/espectrograma candidatos; lab 10-A «tres figuras» explotado didácticamente | **Confirmadas**: los términos en R2-FUN-07; el tratamiento del conteo frágil es correcto y está bien no generalizado |
| [editor-01] descargo de versión en el bloque didáctico 2 de 01 | **Descartada**: el bloque ya declara «con o200k_base y tiktoken 0.9.0» en línea; el descargo pedido existe |
| [M0-raiz] verificar que el grafo de M2 coincida con la ruta de M0 §3 | **Confirmada como cerrada**: M2 §2 (grafo y tabla), folio 011 §2 y M0 §3 declaran la misma ruta M0→M1→01→02→03→08→04→05→06→07→09→10→11 |
| [M2-cohesion] marcas VERIFICAR pendientes en 06 (2) y 07 (9) | **Confirmada como cerrada**: `grep -c VERIFICAR *.md` → 0 en las 15 piezas (la reparación de la tubería las cerró) |

Fuera de mi competencia, sin hallazgo: la grafía «*dataset*» en cursiva vs. plano ([editor-06]),
el owner del frontmatter de M1 ([M0-raiz]) y los apartamientos de extensión de 07/09 — son
decisiones editoriales; la señal ya está ubicada en las observaciones citadas para la comisión de
edición y publicación.

---

## 4. Lo que revisé y está bien (tres ítems)

1. **El aparato de citas de 01, 02, 03 y 10**: todos los identificadores muestreados existen y
   dicen lo que el texto afirma (incluida la verificación en vivo de arXiv 2305.13245, 2505.09388
   y 2607.02770), y las afirmaciones cuantitativas ancladas en papers (InstructGPT 1,3 B vs
   175 B; Mixtral 47 B/13 B; Whisper 680 000 h; RoPE como estándar de facto con Su et al. 2024)
   son fieles a la fuente.
2. **La cohesión estructural del panorama**: grafo de M2, temario del folio 011 §2, envolturas de
   los once temáticos y ruta de M0 §3 coinciden sin divergencia; la frontera capa
   estable/volátil se cumple en los documentos de mi dominio (ninguna cifra del parque vigente
   fuera de la tabla de 11 §1.6; el único roce es el caso histórico de R2-FUN-01).
3. **El tratamiento de lo post-corte de conocimiento en el doc 11**: las familias de 2026 llevan
   fuente por fila, fecha de corte visible, y lo no confirmable en primaria está marcado
   «primaria pendiente de verificación» con dueño (ACT-06) — exactamente la disciplina que la
   guía predica; la distinción pesos abiertos / OSAID en 11 §1.2 es correcta y operativa (el
   defecto es sólo la línea del glosario, R2-FUN-05).

---

## 5. Resumen de hallazgos

| ID | Nivel | Ancla | Documento | Título |
| --- | --- | --- | --- | --- |
| R2-FUN-01 | P1 | E2 | Convenciones.md §6.1 | M3 prohíbe las cifras históricas con cita que 02 y 05 ya usan: interpretación divergente entre redactores |
| R2-FUN-02 | P2 | E1 | Marco-De-Referencia.md §5.2 / 11 | «destilación» con dueño 11 y sin definición en el doc 11 |
| R2-FUN-03 | P2 | E2 | Marco-De-Referencia.md §5.2 | Fuentes del glosario que no dicen lo que la definición afirma (caché KV, ventana de contexto, términos de servicio) |
| R2-FUN-04 | P2 | E2 | M1/03/06/08 vs Convenciones.md §2.2 | Qwen3 TR citado con dos autorías contra el patrón normado |
| R2-FUN-05 | P2 | E2 | Marco-De-Referencia.md §5.2 | La línea OSAID del glosario exige «datos» donde la norma exige información sobre los datos |
| R2-FUN-06 | P2 | E1+E2 | 02-Arquitectura-Transformer.md | El doc 02 corre contra el banco sin declarar la versión del motor |
| R2-FUN-07 | P2 | E2 | Marco-De-Referencia.md §5.2 | Candidatos de glosario declarados por los redactores sin consolidar al cierre de fase |
| R2-FUN-08 | P3 | E2 | 11-Panorama-Y-Ecosistema-Abierto.md §1.1 | Afirmación de industria (GPT-5.1) sin fuente ni marca en la capa volátil |

Dudas para quien pidió: ninguna — los ocho hallazgos tienen dirección de corrección decidible por
la mesa dentro de las restricciones dadas.
