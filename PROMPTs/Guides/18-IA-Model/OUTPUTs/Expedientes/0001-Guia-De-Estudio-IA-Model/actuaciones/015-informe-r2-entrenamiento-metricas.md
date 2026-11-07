# Informe de ronda 2 — Comisión de Entrenamiento, ajuste fino y métricas

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-07 |
| Autor | comisión entrenamiento-metricas (ronda 2) |
| Corrige | — |

Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas: cabecera y §0 (líneas 1–111, con el Mapa de
carga), §2.2, §3.2, §3.3, §4 y §5.2 — la fila de comisión del Mapa de carga. Además cargado:
Cadena-De-Consecuencias 2.0, §2 (aplicado antes de cada dirección que elige entre opciones).
Excepcion-A-Un-Conocimiento no se cargó: esta comisión no propone apartarse de ninguna convención.

Competencia (carta de la ronda 1, evidencia 005): preentrenamiento, fine-tuning, datasets,
alineación y métricas de evaluación. No-competencia: despliegue e inferencia local, edición del
material, arquitectura de sistemas. Objeto de esta ronda: el corpus de 15 piezas en
`<worktree-guia>/Guides/IA/IA-Model/`, contrastado contra folios 001, 002 y 011. Lectura P0–P3: la
del folio 002 (pliego, evidencia 002 §2). Insumos leídos: folios 001, 002, 011; pliego operativo;
observaciones compiladas (evidencia 015, con su adenda); constancias verif-04, verif-05, verif-06 y
verif-07; y, del corpus, lectura completa de 04, 05, 06, 07, M1, M2 y M3 más barridos mecánicos
sobre las 15 piezas (comandos citados por hallazgo).

Alcance declarado no mirado: los documentos 01, 02, 03, 08, 09, 10, 11 y M0 sólo se tocaron por
barrido (grep) y por sus fronteras con mi dominio; su revisión de fondo es de las otras comisiones.

---

## 1. Hallazgos

Ninguno P0 ni P1: el corpus de mi dominio cumple el alcance del folio 011 §2 y las decisiones
EM-01…EM-09 están implementadas donde el veredicto las mandó. Los doce hallazgos son P2/P3.

### R2-ENT-01 · P2 · E1+E2 · «destilación» en el glosario sin que ningún núcleo la use ni la defina

- **Evidencia**: M1 §5.2 (`Marco-De-Referencia.md`, línea 179): «destilación | *distillation* |
  … | Hinton et al. (2015) | **11**». Comando:
  `grep -rn -i 'destilaci' Guides/IA/IA-Model/*.md | grep -v Marco-De-Referencia` → sin salida
  (rc 1): ningún documento del cuerpo, incluido el dueño declarado (doc 11), usa ni define el
  término. La regla 3 del propio glosario (M1 §5.1, decisión FP-07): «Entra al glosario el término
  que algún núcleo usa. Un término sin núcleo que lo use señala o un hueco del temario o un
  descarte, y se decide, no se acumula».
- **Impacto si no se corrige**: el glosario reenvía a una definición normativa que no existe; el
  lector que busca «destilación» llega al doc 11 y no encuentra nada — incumplimiento de la propia
  regla FP-07 aprobada por el jurado, anticipado por las observaciones [M1-marco] y [redactor-11].
- **Dirección** (Cadena-De-Consecuencias §2 corrida): (a) quitar la entrada del glosario — cae en
  M1, una línea, reversible; pierde cobertura de un «término asociado» que el informe 008 listó;
  (b) agregar la sección normativa breve en 11 §1 — cae en el doc 11, ~15 líneas según su propio
  redactor, reversible y aditiva. Ambas reversibles y baratas; la que cumple la regla 3 tal como
  está escrita, con el estado actual del corpus (cero usos), es (a); (b) sólo si la mesa juzga que
  es hueco del temario y no descarte. Decide la mesa, no esta comisión.
- Resuelve las observaciones [M1-marco] (destilación/FP-07) y [redactor-11] (sección normativa
  faltante): **confirmadas y elevadas**.

### R2-ENT-02 · P2 · E2 · La cita del Qwen3 Technical Report contradice la convención que M3 fija

- **Evidencia**: M3 §2.2 (`Convenciones.md`, línea 107) fija para «informe técnico de un equipo de
  modelos»: «Equipo como autor colectivo … Qwen Team (2025). “Qwen3 Technical Report”.
  arXiv:2505.09388» — el ejemplo normativo es exactamente este informe. Pero 03 (línea 737),
  06 (línea 773), 08 (línea 754) y M1 (línea 275) lo citan «Yang, A., et al. (2025)», y 11 lo cita
  «Qwen Team, 2025» (línea 206): el mismo identificador con dos autorías dentro del cuerpo.
- **Impacto**: la convención editorial queda contradicha por cuatro de sus piezas desde el día uno;
  todo redactor futuro hereda el criterio doble.
- **Dirección** (Cadena §2): unificar a «Qwen Team (2025)» cuesta cuatro líneas de Referencias y
  tres menciones en prosa, reversible; cambiar M3 para aceptar autor nominal cuesta reescribir la
  fila normativa y revalidar el doc 11 que ya cumple. La primera es la que iguala las piezas a la
  convención vigente; cualquier otra exige E2 de por qué la convención no sirve.
- Resuelve [editor-06] y [editor-08] (autoría inconsistente): **confirmadas**.

### R2-ENT-03 · P2 · E2 · M3 §4 (EM-03) aplicado de forma divergente: doc 04 publica cifras propias sin bloque «protocolo»

- **Evidencia**: M3 §4: «Ninguna cifra medida entra al cuerpo suelta. Toda métrica que el texto
  afirme como resultado propio … lleva al lado su bloque “protocolo”». Doc 04 §3.1–§3.3 publica
  salidas de corridas propias (12 válidos / 0 errores; Jaccard 0,68; Jaccard 1,00) sin ningún
  bloque `<details>` («grep -c '<summary>Protocolo' 04-Datos-Y-Corpus.md» → 0), mientras que 05
  y 06 llevan protocolo hasta para corridas deterministas equivalentes (06 §3.1: «20 ejemplos
  válidos, 0 errores de formato» con bloque completo; 05 §3.1 y §3.2 ídem).
- **Impacto**: dos lecturas vigentes de EM-03 entre hermanos; el lector y el mantenedor no saben
  cuál rige para la próxima cifra.
- **Dirección** (Cadena §2): (a) agregar los tres bloques a 04 — cae en el doc 04, minutos,
  reversible, cumple M3 §4 tal como está escrito; (b) asentar en M3 §4 la exención «conteo
  determinista sin modelo, entorno en frontmatter» — cae en M3 y absuelve también los conteos de
  09. (a) es la salida que iguala a la pieza que cumple; (b) sólo con decisión de la mesa, porque
  reescribe la regla para describir la práctica.
- Resuelve [editor-04] (lectura a ratificar): **confirmada y elevada**.

### R2-ENT-04 · P2 · E2 · El mismo hecho contado distinto: bits por peso de Q4_K_M en 04 vs 08

- **Evidencia**: doc 04 §3.3 (`mini-eval.jsonl`, ev-03): «¿Cuántos bits usa el formato de
  cuantización Q4_K_M por peso…?» → «Alrededor de 4,5 bits por peso» (línea 391). Doc 08:
  «Q4_0 son 4,5 bpw exactos» y «("Q4_K_M", 4.85, "aprox.: mezcla Q4_K/Q6_K")» (líneas 159 y 548),
  con 4,92 bpw efectivos medidos contra el banco (verif-08 / [redactor-08]).
- **Impacto**: el lab 3 de 04 enseña como «respuesta esperada» la cifra que el dueño de la
  cuantización (08, frontera EM-05/folio 011) desmiente; ~4,5 es Q4_0, no Q4_K_M. Contradicción
  entre piezas del tipo que el mandato 2 de la carta pide cazar; pérdida acotada (dato dentro de
  un mini-benchmark didáctico).
- **Dirección**: corregir la `respuesta_esperada` de ev-03 a «≈4,85» (o cambiar la pregunta a
  Q4_0) y recorrer el laboratorio 3 — determinista, segundos; verificar que el cruce de
  contaminación no cambie (ev-03 no participa de las capturas esperadas).

### R2-ENT-05 · P2 · E1 · Glosario sin consolidar: términos con definición normativa en mi dominio ausentes de M1

- **Evidencia**: comando `grep -n 'safetensors\|JSONL\|datasheet\|prompt de sistema' Marco-De-Referencia.md`
  → sólo una mención incidental de «procedencia» en ACT-05; ninguna entrada de glosario. Con
  definición normativa ya escrita en el cuerpo: corpus, procedencia, *datasheet*, JSONL (04 §1),
  safetensors (06 §1.5), «prompt de sistema» (transversal, sin dueño). Los redactores los
  declararon candidatos ([redactor-04], [editor-06]) y no tocaron M1 porque sus cartas lo
  prohibían; la regla 4 del glosario asigna la consolidación a ACT-06 y esta ronda es la compuerta
  previa a `status: vigente`.
- **Impacto**: términos usados decenas de veces sin forma canónica fijada (riesgo de que otro
  documento acuñe otra forma, el defecto que EM-09 vino a evitar).
- **Dirección**: consolidar las entradas candidatas en M1 §5.2 con dueño 04/06 según la tabla de
  fronteras de M2 §4, antes de promover status.
- Resuelve [redactor-04] y [editor-06] (candidatos a glosario): **confirmadas y elevadas**.

### R2-ENT-06 · P3 · E1 · Forma canónica «*dataset*» (cursiva) incumplida de hecho en todo el dominio

- **Evidencia**: M1 §5.2 fija «*dataset*» en cursiva; comando
  `grep -c '\bdataset\b' 04… 06… 07…` → 58 / 21 / 2 usos planos, y
  `grep -c '\*dataset\*' …` → 0 / 0 / 0. [editor-10] documenta la misma alternancia para
  *embedding*/*token*.
- **Impacto**: claridad/consistencia; la regla 1 del glosario queda letra muerta.
- **Dirección** (Cadena §2): cambiar la forma canónica del glosario a «dataset» sin cursiva (una
  línea en M1, reversible) pesa menos que un barrido de 80+ usos en tres documentos verificados;
  lo que se pierde (la marca tipográfica de anglicismo) lo cubre el «equivalente» de la tabla. El
  barrido de cursivas de *embedding*/*token* es de conjunto y de otra comisión su mitad.
- Resuelve [editor-06] (dataset) y toca [editor-10]: **confirmadas**.

### R2-ENT-07 · P3 · E2 · Frontmatter fuera de la plantilla de M3 en piezas de mi dominio

- **Evidencia**: M3 §1.1 exige `owner: <actor responsable, por su ID de M1>`. En el corpus
  conviven tres formatos — `owner: ACT-06` (02, 03, 05, 08, 10), `owner: Mantenedor de la guía
  (ACT-06)` (01, 06, 09, 11, M2, M3, M0), `owner: ACT-04` (07), `owner: Curador de datos (ACT-05)`
  (04) — y M1 declara `owner: Lab-Documentos`, que no es un actor del catálogo
  (`grep -n '^owner:' *.md`). Además, la plantilla de M3 §7 fija
  `traces: [<doc_id de los prerrequisitos y del siguiente>]` y el doc 07 lleva
  `traces: [IAM-03, IAM-06, IAM-09, IAM-M1, IAM-M2, IAM-M3]` — suma los tres estructurales, que
  ningún hermano incluye; [editor-04] ya pedía unificar el criterio.
- **Impacto**: claridad; el campo pierde valor mecánico (no se puede filtrar por actor).
- **Dirección**: normalizar `owner` a un único formato con el ID (el que decida la mesa), corregir
  M1 a su actor responsable (ACT-06 es quien decide vigencia), y recortar `traces` de 07 a
  prerrequisitos+siguiente o asentar en M3 la variante ampliada.
- Resuelve [M0-raiz] (owner de M1) y [editor-04] (traces): **confirmadas**.

### R2-ENT-08 · P3 · E2 · Residuo de tubería en doc 07: «(completa el verificador)» con los campos ya completados

- **Evidencia**: doc 07, líneas 522 y 688: `<summary>Protocolo de la corrida (completa el
  verificador)</summary>`; la constancia verif-07 declara los 9/9 bloques resueltos y los campos
  del protocolo están llenos (cifras, duraciones observadas, fechas).
- **Impacto**: claridad; el lector publicado leería una instrucción interna de la tubería.
- **Dirección**: quitar el paréntesis en ambos `<summary>`.

### R2-ENT-09 · P3 · E2 · Fuentes del glosario desalineadas con las citas normativas de los dueños

- **Evidencia**: M1 §5.2 cita Hoffmann et al. (2022) como fuente de pérdida, perplejidad,
  *checkpoint* y leyes de escala; el dueño (doc 05) funda pérdida en Bengio et al. (2003),
  perplejidad en Jelinek et al. (1977) y las leyes de escala en Kaplan et al. (2020) —
  Kaplan ni figura en las Referencias de M1. «Ajuste fino» cita Hu et al. (2022), el paper de
  LoRA, como fuente de la definición general; el doc 06 §1.1 arrastra la misma cita para la
  definición genérica de *fine-tuning*.
- **Impacto**: muestreo de citas del mandato 1 — las citas existen y son reales, pero en estos
  casos no son la fuente de lo que la entrada afirma; un lector que verifique llega a un paper que
  define otra cosa.
- **Dirección**: alinear la columna «Fuente» con la cita normativa del documento dueño (Bengio /
  Jelinek / Kaplan; para ajuste fino, una fuente de la técnica general — p. ej. la que el dueño
  elija de su propia lista — y dejar Hu 2022 para LoRA), y sumar Kaplan (2020) a las Referencias
  de M1.

### R2-ENT-10 · P3 · E2 · La respuesta cerrada de PREGUNTA 4 (folio 011 §4) y lo entregado por el doc 06 difieren sin constancia que los concilie

- **Evidencia**: folio 011 §4: «entrenar → doc 06 (**QLoRA** sobre Qwen ≤1.5B con PEFT/TRL, export
  GGUF, **servido en el banco**)». Lo entregado: lab 6.B = **LoRA** sobre Qwen2.5-**0.5B** en
  CTX-01 (QLoRA sólo como variante CTX-02, doc 06 §3.2), y los pasos 5–6 (servir y comparar en el
  banco) quedaron `[Ilustrativo — no verificado en el banco]` (verif-06 §5). Ambas desviaciones
  están fundadas — el default de la fila 1 del lote (CPU sola; QLoRA «no aporta» sin GPU, con cita
  a Dettmers 2023) y la prohibición de la carta de verificación de crear modelos en el banco — y
  declaradas en el documento, pero ninguna pieza del expediente concilia la respuesta cerrada del
  jurado con el estado final.
- **Impacto**: trazabilidad; el cierre contaría una respuesta de PREGUNTA 4 que el corpus ya no
  cumple a la letra.
- **Dirección**: constancia o renglón de deuda en el cierre que asiente la sustitución
  QLoRA→LoRA (por el default de la fila 1) y el estado «servido en el banco: pendiente de ACT-03»
  con su evento de cierre (la respuesta a la duda de [redactor-06]); no tocar el doc 06.

### R2-ENT-11 · P3 · E2 · Errata «Dá» en `preguntas.jsonl` del doc 07, congelada en una corrida verificada

- **Evidencia**: doc 07 §3.1, línea 394: «"Dá una regla mnemotécnica…"» — «da» no lleva tilde
  (monosílabo sin tilde diacrítica aplicable). El archivo es transcripción literal de la corrida
  verificada del lab 07-B (~46 min de generación según verif-07): corregirlo exige recorrer o
  asentar la errata ([editor-07]).
- **Impacto**: claridad; cero efecto sobre las cifras.
- **Dirección** (Cadena §2): asentar la errata (constancia en el cierre o nota al pie del lab) —
  recorrer 46+ minutos de banco compartido por una tilde pesa más que lo que compra; dejar la
  condición de revisión: se corrige el archivo la próxima vez que el lab se recorra por otro
  motivo.
- Resuelve [editor-07]: **confirmada**, con esta dirección.

### R2-ENT-12 · P3 · E2 · Primera fila desalineada en la tabla impresa de IAM-05-L2

- **Evidencia**: doc 05 §3.2, salida verificada: la fila `0.001B` imprime `1.20e+14 FLOPs` con un
  ancho distinto del resto (el `fmt()` del script sólo abrevia desde EFLOPs); verif-05 confirma
  que es salida real byte a byte.
- **Impacto**: estética de una salida real; ninguna cifra queda ambigua.
- **Dirección** (Cadena §2): aceptarla como salida real (costo cero) o retocar `fmt()` y recorrer
  (determinista, ~1 s, pero obliga a re-verificar y re-archivar el log). Preferencia de esta
  comisión: aceptarla; si la mesa pide prolijidad, el retoque es trivial y reversible.
- Resuelve [editor-05] (tabla): **confirmada**, con esta dirección.

---

## 2. Observaciones de la evidencia 015 de mi competencia: disposición

| Observación | Disposición |
| --- | --- |
| [M2-cohesion] marcas `<!-- VERIFICAR -->` en IAM-07 (9) e IAM-06 (2) | **Superada**: `grep -c VERIFICAR *.md` → 0 en las 15 piezas; verif-06 y verif-07 las resolvieron (9/9 y 2/2) |
| [M0-raiz] entorno_validado de 06 y 07 pendiente del verificador | **Parcialmente superada**: 07 quedó completo (labs corridos enteros, verif-07); 06 queda «parcial» declarado y honesto — ver R2-ENT-10 y la duda a ACT-03 |
| [editor-06] status/confidence de 06 (borrador/media): promover si se ratifica | **Confirmada como decisión de cierre**: con `entorno_validado` parcial, confidence media es coherente; promover sólo si ACT-03 habilita los pasos 5–6 o la mesa acepta el estado parcial como definitivo |
| [redactor-04] umbrales Jaccard 0,5/0,35 como criterio de guía, no constante de industria | **Confirmada y conforme**: declarado así en 04 §3.3, cumple M3 §2.3 |
| [editor-05] «perplejidad inicial exactamente V» | **Confirmada y conforme**: fundada y verificada (21,0 medido) |
| [editor-05] tabla desalineada de IAM-05-L2 | **Confirmada** → R2-ENT-12 |
| [editor-04] conteos sin bloque protocolo en 04 | **Confirmada y elevada** → R2-ENT-03 |
| [editor-04] criterio de `traces` | **Confirmada** → R2-ENT-07 |
| [editor-06] «dataset» plano vs glosario; autoría Qwen3; «prompt de sistema» y «safetensors» sin entrada | **Confirmadas** → R2-ENT-06, R2-ENT-02, R2-ENT-05 |
| [editor-07] «Dá» sin corregir; extensión de 07 con apartamiento declarado | **Confirmadas**: la errata → R2-ENT-11; el apartamiento de extensión es conforme a M3 §5 (declarado al abrir, causa medible: corredores transcriptos) — sin hallazgo |
| [M1-marco] «destilación» dueña del 11 — hueco FP-07 si el 11 no la define | **Confirmada y elevada** → R2-ENT-01 |
| [M1-marco] seis fuentes agregadas al glosario (Hu, Dettmers, Rafailov, Zheng, Hinton, Ji) | **Confirmadas**: existen y corresponden al término (verificación por identificador arXiv); la desalineación de otras fuentes del glosario → R2-ENT-09 |
| [redactor-06] duda ACT-03 (crear taller-qwen en el banco) | **Confirmada, sigue abierta** → sección 4 |
| [redactor-05]/[verificador-05]/[verificador-04] corridas reales, logs con SHA-256 | **Confirmadas y conformes** (constancias verif-04/verif-05 contrastadas) |

---

## 3. Lo que revisé y está bien (tres ítems)

1. **Las citas de 04, 05, 06 y 07, por muestreo amplio (~25 entradas), existen y dicen lo que el
   texto afirma**: identificadores arXiv correctos (LoRA 2106.09685, QLoRA 2305.14314, DPO
   2305.18290, LIMA 2305.11206, Zheng 2306.05685, GSM1k 2405.00332, Sainz 2310.18018, Lee
   2107.06499, Carlini 2012.07805, Longpre 2310.16787, Kaplan 2001.08361, Chinchilla 2203.15556,
   Qwen2.5 2412.15115, entre otras) y afirmaciones fieles a la fuente: 18 billones de tokens de
   Qwen2.5, LIMA 1.000 ejemplos/65B, Chinchilla 70B/1,4T frente a un modelo 4× mayor, GPT-3
   175B/300B tokens, caída de hasta 13 puntos en GSM1k, acuerdo >80 % del juez en MT-Bench,
   memorización ~10× menor con deduplicación, >70 % de licencias mal etiquetadas en Longpre, CC
   BY-NC de los datos de Alpaca, licencias Qwen2.5 (3B y 72B propias, resto Apache-2.0).
2. **Las fronteras de mi dominio están implementadas con enlace cruzado en ambos lados y sin
   duplicación**: EM-01/EM-02 (la cadena HF→GGUF→Ollama vive sólo en 06 §1.5, la demo juguete sólo
   en 05), EM-05 (calidad en 07, servicio reenviado a 08 y viceversa), EM-06 (contaminación de
   benchmarks como §1.5 de primera clase en 07, higiene de corpus en 04), EM-07 (práctica de
   licencias en 04 §1.4, panorama en 11), EM-08 (04 núcleo propio); dueño único de laboratorios
   respetado (los hermanos citan 6.A/6.B, 07-A/07-B, labs 1–3 de 04 sin copiarlos).
3. **La cadena de verificación de 04–07 cierra**: salidas pegadas idénticas a corridas reales
   (verif-04 «bit a bit», verif-05 «byte a byte», verif-07 9/9 con digests cotejados contra el
   banco), cero marcadores VERIFICAR residuales en el corpus, paso 0 citado y parametrizado
   (`${OLLAMA_HOST:-http://localhost:11434}`) y ninguna ruta de host ni dato personal en las
   piezas de mi dominio.

---

## 4. Dudas para quien pidió

Una sola, heredada y aún abierta (no se duplica: es la misma de [redactor-06], que esta ronda
confirma como el único bloqueo real para cerrar el estado del doc 06):

| Rol | Pregunta | Por qué | Prioridad | Default |
| --- | --- | --- | --- | --- |
| ACT-03 (operador del banco) | ¿Autoriza crear los modelos de prueba del lab 6.B (`taller-qwen` y `taller-qwen-base`, ~1 GB total) en el banco para verificar los pasos 5–6 y borrarlos al cerrar la corrida? | Es lo único que mantiene al laboratorio central de «entrenar» con sus pasos finales en `[Ilustrativo]` y al doc 06 en `entorno_validado: parcial` / `confidence: media` | P2 | Los pasos 5–6 quedan ilustrativos con su motivo declarado, el doc 06 no promueve confidence, y el evento de cierre queda asentado como deuda (R2-ENT-10); nada bloqueado |

Sigue: consolidación de la ronda 2 · presidencia de la mesa
