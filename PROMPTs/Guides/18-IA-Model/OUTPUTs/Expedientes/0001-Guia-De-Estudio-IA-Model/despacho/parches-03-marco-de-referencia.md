# Constancia del cuerpo de parches — lote «local Marco-De-Referencia.md» (PA-02)

Fecha: 2026-11-07 · Carta de mandato: `evidencia/019-carta-cuerpo-de-parches.md` · Folio del
jurado: `despacho/r2-jurado-veredicto.md` · Documento intervenido: una sola pieza,
`Guides/IA/IA-Model/Marco-De-Referencia.md` (M1), entera en una pasada. No se tocaron salidas
verificadas ni marcas del verificador (M1 no contiene cercas con salidas verificadas). No se
hicieron commits.

## PA-02 (i) — Regla 1 del glosario reescrita a forma exigible (R2-EDI-01, dirección b)

- **Dónde**: M1 §5.1, regla 1 (líneas 122–131 del archivo parcheado).
- **Qué**: la regla pasa de «término inglés en cursiva … nunca ambas alternándose» (letra
  incumplible a escala de corpus) a la forma exigible votada: cursiva obligatoria sólo en la
  primera aparición por documento y en las definiciones (tabla del glosario y definición
  normativa del dueño); en el resto de la prosa, grafía sin marca obligatoria pero única;
  código, salidas transcriptas y campos de API exentos (§6.2). Se asentó la condición de
  revisión de R2-EDI-01: si una ronda posterior mide confusión real de lectores, se endurece a
  cursiva en toda aparición (endurecer es aditivo).

## PA-02 (ii) — Consolidación de los candidatos de la 015 y las dos grafías

16 entradas nuevas en §5.2, cada una con el dueño que su observación propone y la fuente
normativa copiada del documento dueño (criterio R2-REF-05):

| Entrada | Dueño | Fuente copiada del dueño | Línea |
| --- | --- | --- | --- |
| BPE | 01 | Sennrich et al. (2016) — 01 §1.2 | 155 |
| subpalabra | 01 | Sennrich et al. (2016) — 01 §1.2 | 156 |
| SentencePiece | 01 | Kudo y Richardson (2018) — 01 §1.2 | 157 |
| máscara causal | 02 | Brown et al. (2020) — 02 §1.4 (la sección que la define) | 165 |
| codificación de posición (con RoPE) | 02 | Vaswani et al. (2017); Su et al. (2024) — 02 §1.5 | 166 |
| GQA / MQA | 02 | Shazeer (2019); Ainslie et al. (2023) — 02 §1.7 | 167 |
| *prompt* de sistema | 03 | Brown et al. (2020) — 03 §1.5 (las tres zonas del prompt) | 173 |
| corpus | 04 | Gao et al. (2020); Penedo et al. (2024) — 04 §1.1 | 177 |
| procedencia | 04 | Gebru et al. (2021) — 04 §1.4 | 181 |
| JSONL | 04 | JSON Lines (s. f.) — 04 §1.3 | 182 |
| *datasheet* | 04 | Gebru et al. (2021) — 04 §1.4 | 183 |
| *safetensors* | 06 | Hugging Face (s. f.), documentación oficial con fecha de consulta (tipo de fuente de M3 §2.2; el dueño lo define inline sin cita propia). URL comprobada viva el 2026-11-07 | 193 |
| encoder de visión (ViT) | 10 | Dosovitskiy et al. (2021) — 10 §1.1 | 216 |
| espectrograma | 10 | Radford et al. (2023) — 10 §1.2 | 217 |
| ASR | 10 | Radford et al. (2023) — 10 §1.2 | 218 |
| códec neuronal | 10 | Défossez et al. (2022) — 10 §1.2 | 219 |

Grafías en §6.1 (líneas 246–247): «des-tokenizar» (verbo de la guía, forma única con guion,
asentada como grafía y no como entrada del glosario — [editor-01]) y «no-determinismo»
(sustantivo con guion, la forma del doc 03 — [editor-03], R2-EDI-12).

## PA-02 (iii) — La fila copia la fuente normativa del dueño (R2-REF-05, ENT-09, FUN-03, INF-03, SIS-09, EDI-08)

- **pérdida** → Bengio et al. (2003) (dueño 05 §1.2) — línea 185.
- **perplejidad** → Jelinek et al. (1977) (dueño 05 §1.3) — línea 186.
- **leyes de escala** → Kaplan et al. (2020) (dueño 05 §1.5); Kaplan sumado a §7 — línea 188.
- **motor de inferencia** → ggml-org (s. f.-b); Ollama (s. f.); Kwon et al. (2023) (dueño 08
  §1.2) — línea 202.
- **GGUF** → ggml-org (s. f.-a): re-etiquetado por el desdoblamiento -a/-b que el dueño 08 ya
  usa — línea 204.
- **caché KV** → Vaswani et al. (2017); Pope et al. (2023) (dueño 08 §1.5) — línea 205.
- **tokens por segundo** → Ollama (s. f.) (dueño 08 §1.5) — línea 206.
- ***recall*** → equivalente declarado «— (en recuperación ANN)» y «búsqueda aproximada» en la
  definición; la fuente queda Malkov y Yashunin (2020), que es la del dueño 09, conforme a la
  lectura de INF-03 — línea 210.
- **inferencia**: sin cambio — la fila ya copia la fuente del dueño (08 §1.1 define inferencia
  con Qwen Team, 2025); resuelta por el criterio mecánico, no por edición.
- **ventana de contexto**: sin cambio — el dueño (01 §1.5) funda la definición en Vaswani et
  al. (2017), que es lo que la fila ya dice; el negativo de FUN-03(b) quedó degradado a C por
  R2-REF-05 y no funda edición.
- **ajuste fino**: sin cambio — el dueño (06 §1.1) cita hoy Hu et al. (2022) para la definición
  genérica; la fila lo copia. Ver observación 2.
- **checkpoint**: sin cambio — la definición del dueño (05 §1.4) no lleva cita propia y la
  dirección de ENT-09 enumera sólo Bengio/Jelinek/Kaplan. Ver observación 3.

§7 Referencias: altas en orden alfabético de Ainslie 2023, Bengio 2003, Défossez 2022,
Dosovitskiy 2021, Gao 2020, Gebru 2021, ggml-org s. f.-b, Hugging Face s. f., Jelinek 1977,
JSON Lines s. f., Kaplan 2020, Kudo y Richardson 2018, Kwon 2023, Ollama s. f., Penedo 2024,
Pope 2023, Radford 2023, Shazeer 2019 y Su 2024 — todas copiadas textuales de las listas de
referencias de los documentos dueños (01, 02, 04, 05, 08, 10), salvo la de safetensors (ver
arriba).

## PA-02 (iv) — Línea OSAID alineada con 11 §1.2 (R2-FUN-05)

- **Dónde**: fila «*open source* (aplicado a modelos)», línea 222.
- **Qué**: «exige libertades sobre pesos, código **y** datos» → «exige pesos con licencia
  aprobada, código del pipeline **e** información suficientemente detallada sobre los datos de
  entrenamiento», la formulación del documento 11 §1.2 (OSI, 2024).

## Verificación

- Ancla de R2-FUN-07: `grep -n 'BPE\|SentencePiece\|subpalabra' Marco-De-Referencia.md` pasa de
  sin salida a 4 líneas (155–157 y la referencia de Kudo); ídem RoPE, GQA/MQA, máscara causal.
- Kaplan (2020) figura en §7 (ancla de R2-ENT-09).
- Toda fuente nombrada en la tabla de §5.2 tiene entrada en §7 (barrido de nombres contra la
  lista; sin huérfanas).
- La fila «destilación» (dueño 11, Hinton et al. 2015) queda intacta: su suerte depende de
  PA-03; si ese parche no entra, la condición del jurado (R2-REF-01) manda sacarla en el mismo
  barrido — lo asienta quien cierre el lote de PA-03, no éste.

## Observaciones (exceden la dirección votada; no aplicadas)

1. **§6.2, lista de siglas**: la enumeración «(RAG, LoRA, DPO, RLHF, MoE, VLM, ANN, HNSW, SFT)»
   no incluye las siglas que esta consolidación suma (BPE, RoPE, GQA, MQA, ViT, ASR). Es lista
   ejemplificativa y §6.2 está fuera del alcance de la pasada (§5.1–§5.2, §6.1, §7); completar
   la enumeración sería coherencia barata si otra ronda toca §6.2.
2. **«ajuste fino» (fila de ENT-09)**: el defecto de fondo vive en el dueño — 06 §1.1 cita Hu
   et al. (2022), el paper de LoRA, para la definición genérica de *fine-tuning*. El criterio
   mecánico (copiar la fuente del dueño) deja la fila como está; elegir acá una «fuente de la
   técnica general» distinta repetiría el defecto que R2-REF-05 señala (glosario con fuente
   propia divergente del dueño). La corrección correcta es en 06 §1.1, documento fuera de este
   lote.
3. **«checkpoint»**: conserva Hoffmann et al. (2022) aunque la definición del dueño (05 §1.4)
   no lleva cita; si una ronda posterior dota de cita a 05 §1.4, la fila debe copiarla.
4. **«MoE»**: la fila cita Fedus et al. (2022); el dueño (02 §1.6) cita «Shazeer et al., 2017;
   Fedus et al., 2022». Es subconjunto de la fuente del dueño, no divergencia del tipo INF-03,
   y la fila no está en la lista votada: queda anotado por si otra pasada uniforma.
