# Constancia de verificación técnica — Documento 06 (Ajuste fino y alineación)

- **Documento**: `Guides/IA/IA-Model/06-Ajuste-Fino-Y-Alineacion.md` (worktree guía)
- **Verificador**: técnico adversarial, fase de elaboración, expediente 0001
- **Fecha**: 2026-11-07
- **Entorno**: Python 3.11.2, CTX-01 (8 núcleos x86-64 **compartidos** con otras cargas: el
  proceso de entrenamiento dispuso de ~1,1–1,3 núcleos efectivos, relación user/real medida);
  venv propio con las versiones fijadas del documento: torch 2.15.0+cpu, transformers 5.22.2,
  trl 1.17.1, peft 0.21.2, datasets 5.1.0, accelerate 1.15.0; llama.cpp v0.9.0 (clon superficial
  de la etiqueta) con venv aparte para la conversión. Banco Ollama 0.32.0-rc0 accesible
  (`/api/tags` OK); al banco **no** se le creó ningún modelo (prohibido por la carta; además es
  decisión del operador ACT-03 según el propio documento).

Alcance de esta corrida: los 2 bloques VERIFICAR pendientes del laboratorio 6.B (log de
`trainer.train()` y comparación base/ajustado servida), más la recorrida de la cadena que los
rodea (dataset 6.A, cuenta de parámetros, fusión, GGUF, plantilla del paso 5).

## 1. Lab 6.A — dataset (recorrido de control) — VERIFICADO

- **Comando**: `python construye_dataset.py && python valida_dataset.py taller_sft.jsonl`
  (scripts literales del documento; los 15 pares no transcriptos los sembré yo en la misma forma)
- **Salida**: `taller_sft.jsonl: 20 ejemplos escritos` / `20 ejemplos leídos; 0 errores` —
  idéntica a la del documento.
- **Log**: `evidencia/local/verif-06-dataset.log`
  SHA-256 `eb99ae0c6b80520220f9c3b9a702f694bc40fc1414069e618488f431ec19aa68`
  (dataset sembrado: `verif-06-taller_sft.jsonl`,
  SHA-256 `59286950c91418bd5a56858da2e00116170ac3918e3fd9a04aab77e67f8e1b22`)

## 2. `cuenta_lora.py` (protocolo M3) — VERIFICADO

- **Salida real**: `por capa: 45056 · total en 24 capas: 1,081,344` · `0.2189%` — idéntica al
  documento. Contrastada además contra el adaptador real entrenado: `adapter_config.json` con
  r=8, alpha=16, targets {q,k,v,o}_proj; `adapter_model.safetensors` de 4.350.392 bytes ≈
  1.081.344 × 4 bytes (float32) + cabeceras ✔.
- **Corrección aplicada**: §1.3 decía «unas decenas de MB» para el adaptador; el del propio
  laboratorio pesa 4,4 MB. Quedó «de unos MB a unas decenas de MB (… medido, 4,4 MB)» y el nodo
  del mermaid de §1.5 acompaña.

## 3. Lab 6.B paso 2 — `entrena_lora.py` — VERIFICADO EN VERSIÓN REDUCIDA (bloque VERIFICAR 1)

- **Corrida completa, literal del documento** (9 pasos, batch 2 × accum 4, 3 épocas): cortada por
  el tope de ~10 min de la carta. En 10m0s reales (11m24s de CPU: ~1,1 núcleos efectivos) no
  completó ni el primer paso de optimización (tqdm quedó en 0/9).
  Log: `evidencia/local/verif-06-entrena-completa-cortada.log`
  SHA-256 `a52d82e555167c04d02a1df7ecb17905642d7152455382f9ba20c901a9959f5d`
- **Corrida reducida** (mismo script con `max_steps=3`, batch 1, accum 1, `logging_steps=1`;
  script archivado como `verif-06-entrena_lora_reducido.py`,
  SHA-256 `7e77238357c54666827c5f0828fe7d7524e7fd2f5f858c3e00f442c26b6065ba`): completó en
  6m43s (train_runtime 380,3 s), loss por paso 4,481 / 5,221 / 4,618, train_loss 4,773, y guardó
  el adaptador en `salida-lora/final`.
  Log: `evidencia/local/verif-06-entrena-reducida.log`
  SHA-256 `4cdf67b32253ee93a0c539a75829994170f56831e38abf42086e71dab68ec994`
- **Extracto mínimo**:
  ```text
  {'loss': '4.481', ... 'epoch': '0.05'}
  {'loss': '5.221', ... 'epoch': '0.1'}
  {'loss': '4.618', ... 'epoch': '0.15'}
  {'train_runtime': '380.3', 'train_loss': '4.773', 'epoch': '0.15'}
  ```
- **En el documento**: el bloque VERIFICAR se reemplazó por la salida real de la corrida
  reducida con su protocolo; la corrida completa quedó marcada
  `**[Ilustrativo — no verificado en el banco]**` con el motivo (excede el tope; ~127 s por
  micro-lote de 1 ejemplo medidos en este CTX-01 compartido).
- **Veredicto**: verificado con corrida reducida; corrida completa ilustrativa.

## 4. Lab 6.B pasos 3–4 — fusión y GGUF — VERIFICADOS (con corrección al texto)

- **Paso 3** (`fusiona.py`, literal): corrió en 18,1 s; `taller-qwen-fusionado/model.safetensors`
  de 988.097.824 bytes. Prueba funcional: el modelo fusionado carga y genera texto coherente con
  decodificación voraz (40 tokens, 1m02s).
  Logs: `verif-06-fusiona.log` SHA-256 `9384db34224f31f6de776aac99c56a582b9dfa72963724e626250e1be31f99b9`;
  `verif-06-smoke-fusionado.log` SHA-256 `5eadac9657f91e038d4a8456dfba74dbf7f2c7fd5329ea5adf7ce421f1f48754`
- **Paso 4, primer intento (falla real, documentada)**: `pip install -r llama.cpp/requirements.txt`
  degradó el venv fijado (torch 2.15.0→2.11.0, transformers 5.22.2→4.57.6) y la conversión cortó
  con `AttributeError: 'list' object has no attribute 'keys'` — el tokenizador reguardado por
  transformers 5.22.2 escribe `extra_special_tokens` como lista y el 4.57.6 de los requisitos no
  la lee. Log: `verif-06-convierte-fallo-tokenizador.log`
  SHA-256 `d33c70f43558b8ed4c110c5ea7b27f64db8d2a01ea40fa8ecbb181c1a1d8f6de`
- **Arreglo verificado** (del texto, no del banco): venv aparte para los requisitos de llama.cpp
  y copiar al directorio fusionado los archivos del tokenizador del snapshot original del base.
  Con eso: `Model successfully exported`, 28,5 s, `taller-qwen-0.5b-q8_0.gguf` de 531.067.904
  bytes (~506 MiB ✔ el «~500 MB» del documento).
  Logs: `verif-06-convierte-ok.log` SHA-256 `10e6318acc10d672daa408b61ea5c3763df7b3104c9dc2cdabeef100052ec74d`;
  `verif-06-gguf-tamano.log` SHA-256 `e015bf8f2f54064ad58cc6a86b22e86be07c884f690040ea2d5a272a3d60ade9`
- **En el documento**: ambos tropiezos quedaron advertidos en el paso 4 con su remedio.
- **Veredicto**: corregido (texto) y verificado.

## 5. Lab 6.B pasos 5–6 — servir y comparar (bloque VERIFICAR 2) — ILUSTRATIVO

- **Motivo**: `ollama create` sube un modelo al banco compartido; la carta lo prohíbe y el propio
  documento lo reserva al operador (ACT-03). No se rodeó con otro camino que midiera otra cosa:
  la comparación servida queda sin correr.
- **Lo sí verificado alrededor**: paso 0 (`/api/tags` → «banco accesible»); la afirmación anclada
  del paso 5 sobre la plantilla — `POST /api/show {"model":"qwen2.5:7b-instruct"}` devuelve la
  TEMPLATE ChatML (`<|im_start|>/<|im_end|>`) ✔; hallazgo adicional asentado en el texto: ese
  modelfile trae TEMPLATE y SYSTEM pero **ningún** `PARAMETER stop` (los cortes los resuelve la
  plantilla), así que el comentario del Modelfile del documento se corrigió.
  Evidencia: `verif-06-show-qwen25-7b-instruct.json`
  SHA-256 `17149cb096f988673f99b5dfada96d7226321034d0bf50d2e49b0dc93b36a49e`
- **En el documento**: el bloque VERIFICAR se reemplazó por la marca
  `**[Ilustrativo — no verificado en el banco]**` con el motivo y el inventario de lo que sí
  quedó verificado de la cadena.

## Resumen

- Verificados: 4 (dataset 6.A, cuenta de parámetros + adaptador real, entrenamiento en versión
  reducida, fusión + conversión GGUF + plantilla del banco) · Corregidos: 3 pasajes de texto
  (peso del adaptador §1.3/§1.5, advertencias del paso 4, comentario del Modelfile del paso 5) ·
  Ilustrativos: 2 (corrida completa de entrenamiento — excede el tope —; servido y comparación
  en el banco — modelo nuevo en el banco es del operador) · BLOQUEO: 0
- Nota de entorno: el frontmatter `entorno_validado` del documento quedó actualizado.
- Dudas para el PO: sin dudas. (Sugerencia operativa, no duda: si alguna vez se habilita un
  banco propio para la guía, los pasos 5–6 quedan a una corrida de distancia — el GGUF ya probó
  construirse.)

> Nota: `evidencia/local/` no está versionada (gitignored); sus logs no se publican y se identifican por su huella SHA-256.
