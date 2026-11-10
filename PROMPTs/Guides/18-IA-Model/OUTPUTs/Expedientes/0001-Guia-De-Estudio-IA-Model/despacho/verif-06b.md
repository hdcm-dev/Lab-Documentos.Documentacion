# Constancia de verificación técnica — Documento 06, tramo final del lab 6.B (cierre de PD-01)

- **Documento**: `Guides/IA/IA-Model/06-Ajuste-Fino-Y-Alineacion.md` (`<worktree-guia>`)
- **Verificador**: técnico, corredor PD-01 del folio 022, expediente 0001
- **Fecha**: 2026-11-10
- **Autorización**: folio 022 §3.2 — el PO autorizó crear `taller-qwen` y `taller-qwen-base` en el
  banco con borrado obligatorio al terminar; ambos borrados y comprobados (ver §6).
- **Entorno**: CTX-01 **compartido** con otras cargas; sin `python3-venv` ni `pip` en el puesto,
  así que todo corrió en contenedores Docker dentro del área de trabajo (`<area-agentes>`):
  imagen `python:3.11-slim` (Python 3.11.18) con las versiones fijas del documento instaladas y
  verificadas — torch 2.15.0+cpu, transformers 5.22.2, trl 1.17.1, peft 0.21.2, datasets 5.1.0,
  accelerate 1.15.0 — y una segunda imagen aparte con los requisitos de llama.cpp v0.9.0 (clon
  superficial de la etiqueta), el equivalente del «venv aparte» de verif-06. Banco
  `$OLLAMA_HOST`, ollama 0.32.0-rc0; todas las llamadas por API, sin cliente `ollama` (fila 2 del
  folio 021 §5 sigue en su default).

Alcance: los pasos 2 (reintento de la completa), 3–4 (fusión y GGUF, incluido el base), 5 (crear
por API) y 6 (comparación servida) del lab 6.B, con edición del documento 06 y de
Cohesion-Global §5.

## 1. Dataset 6.A (recorrido de control) — VERIFICADO

- Scripts literales; los 15 pares no transcriptos sembrados en la misma forma (semilla de datos
  propia de esta corrida; el dataset va en la evidencia).
- Salida: `taller_sft.jsonl: 20 ejemplos escritos` / `20 ejemplos leídos; 0 errores`.
- Log: `evidencia/local/verif-06b-dataset.log`
  SHA-256 `a4609b8693fd0d4513ad22b98bfb93508b1c1bf62c2c1b65d1738953ff5ac32a`
  (dataset: `verif-06b-taller_sft.jsonl`
  SHA-256 `314bc7124fce2320eee262a021fcfa96c3ec5dd35354c9245623d82963b3f2f1`)

## 2. Paso 2 — corrida completa intentada, cortada por costo medido; reducida corrida entera

- **Completa, literal** (9 pasos, batch 2 × accum 4, 3 épocas): lanzada; el primer paso de
  optimización midió **1.525,65 s/it** (tqdm `1/9 [25:25<3:23:25]`), proyección ~229 min > tope
  de 150 min → cortada tras ese primer paso, apartamiento declarado en el documento.
  Log: `verif-06b-entrena-completa-cortada.log`
  SHA-256 `033bbfaf5a9f756ef651250a276dbf36cfb48de2b5d2c28095564a48eaf80bbe`
- **Reducida** (receta de verif-06: `max_steps=3`, batch 1, accum 1, `logging_steps=1`; script
  archivado `verif-06b-entrena_lora_reducido.py`
  SHA-256 `c073c56c432cdc5dccedddb6be47b56bdc0f01854c2f862b326d4298853d51ba`): completó en
  10m51s (train_runtime 600,2 s), loss 4,481 / 4,232 / 4,285, train_loss 4,333, adaptador en
  `salida-lora/final`. (El primer paso reproduce el 4,481 de verif-06 — misma semilla y primer
  ejemplo transcripto; los siguientes difieren porque los pares sembrados difieren.)
  Log: `verif-06b-entrena-reducida.log`
  SHA-256 `fa9e702eec168b3e2a990e606a0469f98e80bf9fcd7f17af12fe50fe58d5d35c`

## 3. Pasos 3–4 — fusión y GGUF (ajustado y base) — VERIFICADOS

- Fusión literal (37,9 s): `taller-qwen-fusionado/model.safetensors` de 988.097.824 bytes, igual
  a verif-06. Remedio del tokenizador aplicado (copia de `tokenizer_config.json`,
  `tokenizer.json`, `vocab.json`, `merges.txt` del snapshot base).
  Logs: `verif-06b-fusiona.log`
  SHA-256 `0462886c29be58691edeb9e80495b5c745631d1029c705f8bc2f968aa77715cc`;
  `verif-06b-remedio-tokenizador.log`
  SHA-256 `5ae0821d6511a1110042de7deba818036bdd117ab9ca478a510c6e08aa412f97`
- Conversión q8_0 en la imagen aparte: `Model successfully exported` para los dos —
  `taller-qwen-0.5b-q8_0.gguf` 531.067.904 bytes (idéntico a verif-06) y
  `taller-qwen-base-0.5b-q8_0.gguf` 531.067.968 bytes (snapshot base sin ajustar).
  Log: `verif-06b-convierte.log`
  SHA-256 `fc89e42bbe794768e770520d56c287e37dca188c46519e4fccf386dac867e917`

## 4. Paso 5 — creación en el banco por API — VERIFICADO

- Por cada GGUF: `POST $OLLAMA_HOST/api/blobs/sha256:<digest>` → `201`;
  `POST /api/create` con `model`, `files` (digest) y `template`/`system` copiados del
  `POST /api/show` de `qwen2.5:7b-instruct` → `{"status":"success"}`. `GET /api/tags` listó
  `taller-qwen:latest` y `taller-qwen-base:latest`.
- Digests: ajustado `64cefdfdd5510764ebd56db0c97de4fc57316c637ae0335ce8f847b9ed6bd40c`;
  base `828c97e9e07e9d9d53216962420867b59d666a30bfa874ec162f43801ac3fd8b`.
- Logs: `verif-06b-sube-modelos.log`
  SHA-256 `e4a896a7c466ecb9c122df267db1f99d9ffccf0af925c9faa626ff9b43cd79fe`;
  plantilla: `verif-06b-show-qwen25-7b-instruct.json`
  SHA-256 `17149cb096f988673f99b5dfada96d7226321034d0bf50d2e49b0dc93b36a49e` (idéntica a la de
  verif-06: TEMPLATE ChatML + SYSTEM, sin `PARAMETER stop`).

## 5. Paso 6 — comparación servida — VERIFICADA (con la aclaración del entrenamiento reducido)

- Literal del documento: `/api/chat`, temperature 0, seed 42, misma pregunta a los dos modelos.
  Ambos respondieron; las respuestas (cinco y siete puntos de lista) difieren en redacción, no en
  conducta: con 3 micro-pasos de entrenamiento el estilo del taller no se impone, tal como el
  propio paso 2 anticipa. La cadena técnica entera quedó servida y comparada; el contraste de
  estilo queda declarado como dependiente de la corrida completa.
- Log: `verif-06b-compara.log`
  SHA-256 `6d2fa5235eaef055d88e162d39ba7a99accc9e8c9a7067201065726fc2cc3249`

## 6. Limpieza del banco — CUMPLIDA

- `DELETE /api/delete` de `taller-qwen` → `200` y de `taller-qwen-base` → `200`; `GET /api/tags`
  posterior: 12 modelos (el inventario previo del folio 022 §2), **ningún** resto `taller`.
- Log: `verif-06b-limpieza.log`
  SHA-256 `441bcc7a9b5492a9d0b3c3373b55d92bb96291f68e6ba2bf4397aeba03bf6bfe`

## 7. Qué cambió en los documentos

En `06-Ajuste-Fino-Y-Alineacion.md`: el estado de verificación de §3.2 (pasos 0–6 corridos, con
la autorización y el borrado declarados); el bloque de la corrida completa del paso 2 (de
«[Ilustrativo — no verificado en el banco]» a apartamiento declarado con el primer paso medido,
1.525,7 s → ~229 min proyectados) y la salida real nueva de la reducida con su protocolo
(2026-11-10); el párrafo de proyección de costo; la nota del paso 5 con el procedimiento por API
verificado; el bloque ilustrativo del paso 6 reemplazado por la salida real servida con su
protocolo M3 y la aclaración sobre el entrenamiento reducido; frontmatter — `entorno_validado`
refleja la corrida del 2026-11-10, `confidence: alta`, `last_review: 2026-11-10`, `status` sigue
`borrador` (promoverlo es del PO). En `Cohesion-Global.md` §5: la condición de ACT-03 sobre el
tramo final de 6.B consta como dada (folio 022), corrida y cerrada. El reenvío del bloque
didáctico al paso 6 y el anexo §6 quedan coherentes sin cambio.

## Resumen

Verificados: 6 (dataset de control, costo de la completa medido + reducida entera, fusión,
GGUF ×2, creación por API, comparación servida) · Apartamientos declarados: 1 (entrenamiento
reducido en lugar de la completa, por costo medido sobre el tope) · BLOQUEO: 0 · Banco limpio:
sí, comprobado por `/api/tags`.

> Nota: `evidencia/local/` no está versionada (gitignored); sus archivos se identifican por su
> huella SHA-256. Esta corrida usó contenedores en lugar de venvs porque el puesto no trae
> `python3-venv` ni `pip` y la carta prohíbe instalar en el host; las versiones de Python de las
> bibliotecas quedaron idénticas a las fijadas por el documento.
