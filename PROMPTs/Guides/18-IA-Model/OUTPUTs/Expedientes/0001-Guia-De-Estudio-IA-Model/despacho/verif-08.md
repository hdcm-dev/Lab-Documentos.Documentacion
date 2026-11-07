# Constancia de verificación técnica — 08-Inferencia-Local.md

Verificador técnico · 2026-11-07 · banco Ollama 0.32.0-rc0 (CTX-03, URL del despacho; en el
documento figura como `$OLLAMA_HOST`/localhost). Cliente local sin `ollama` CLI: los subcomandos
de consola se verificaron por su equivalente exacto de API (`/api/show`, `/api/ps`), y el
documento se ajustó para que cada salida pegada sea la salida real del comando transcripto.
Evidencia cruda en `../evidencia/local/` (fuera del versionado).

## Corridas

### 1. Lab 08-A paso 0 — verificación de acceso — VERIFICADO
- Comando: el del documento (`curl -s "$OLLAMA_HOST/api/tags" >/dev/null && ...`).
- Log: `08-paso0.log` — SHA-256 `f8eeadd26f13e1bde95500387fb965429311c1c39084091c3edec7f687480f5b`
- Extracto: `banco accesible`. `/api/version` devolvió `0.32.0-rc0`, igual al front matter.

### 2. Lab 08-A paso 1 — inventario — VERIFICADO
- Comando: el del documento (curl /api/tags | json.tool | grep).
- Logs: `08-paso1.log` `2aa41a04333cbd90a122c00474403fb602a3ca61c9b611bd4336f8061417a3bb`;
  JSON completo `08-tags-full.log` `63ed65dd1f0af0429b3540e61dadf65839cd0887f204f97e08e9660501582faf`
- Extracto: 11 modelos; entre ellos `qwen2.5:7b-instruct` 7.6B Q4_K_M. Salida real recortada
  pegada en el documento.

### 3. Lab 08-A paso 2 — `ollama pull` — ILUSTRATIVO
- No se corrió: la carta prohíbe descargar modelos al banco y el CLI no está en el cliente; un
  pull con etiqueta movida en el registro descargaría un blob nuevo al servidor. Marcado en el
  documento `**[Ilustrativo — no verificado en el banco]**` con el motivo (en CTX-03 los modelos
  los administra ACT-03; el modelo ya está en el inventario del paso 1).

### 4. Lab 08-A paso 3 — interrogar el GGUF — CORREGIDO (comando) y VERIFICADO
- El documento prescribía sólo `ollama show` (CLI, no disponible en los medios). Se corrigió el
  comando a su equivalente `/api/show` con filtro python (misma información, corre con `curl`
  desde cualquier máquina), dejando el CLI mencionado como atajo. Salida real recortada pegada.
- Log: `08-paso3-show.log` `19f152f1d74f5ea4b428bd6e5eaacca3dcbec963a609f3f8556ab4da8b049d7d`
  (JSON completo: `08-show-qwen25-7b.json` `17149cb096f988673f99b5dfada96d7226321034d0bf50d2e49b0dc93b36a49e`)
- Extracto: `general.parameter_count: 7615616512`, Q4_K_M, apache-2.0, head_count 28,
  head_count_kv 4, block_count 28, context_length 32768, embedding_length 3584.

### 5. Lab 08-A paso 4 — servir y comprobar — CORREGIDO (comando `ollama ps` → `/api/ps`) y VERIFICADO
- Generación corrida tal cual; `ollama ps` sustituido por `curl /api/ps` (CLI anotado en
  comentario). Salida real recortada pegada (se elidió el arreglo `context`).
- Logs: `08-paso4-generate.log` `e3f2970f38fc4da682032463320e18b49676addd0830bf1ea53f33e6fe7e41e1`;
  `08-paso4-ps.log` `2b96aca21d402cc0b38bbb9581a4271b82df69deb817517ca7b07d3df51abb76`
- Extracto: respuesta «París»; load_duration 34,2 s de 35,2 s totales (primera carga);
  `/api/ps`: size 6915411148 (6,44 GiB) > 4,36 GiB de archivo; expires_at +24 h. Confirma el
  «Resultado esperado» del paso (carga inicial lenta, memoria mayor que el archivo).

### 6. Lab 08-B — tokens/s — VERIFICADO (cifra M3 fundada)
- Comando del documento, tres corridas (modelo ya cargado; ninguna incluyó carga).
- Log: `08b-tres-corridas.log` `b7ea3e0a85ebdff800da2da9049e031cbc3986f80da4051c397fcc521dfccca1`
- Extracto: decode 7,5 / 7,5 / 7,5 tokens/s — mediana **7,5 tokens/s**; prefill 62,6 / 62,2 /
  66,5; TTFT 0,78–0,84 s. Protocolo completado en el documento (cifra, digest
  `845dbda0ea48…697e`, fecha).
- Dos correcciones de texto fundadas en la corrida: (a) «prefill entre uno y dos órdenes de
  magnitud más rápido» no se cumplió en CPU (~8×) → reescrito con la cifra medida y la brecha
  mayor reservada a GPU; (b) «prompt_eval_* sólo cuentan lo no cacheado» → en las tres corridas
  con prompt idéntico `prompt_eval_count` fue 52 siempre (el caché no descontó) → suavizado a
  «pueden descontar la parte cacheada».

### 7. Lab 08-C — estimador de memoria — VERIFICADO
- Script corrido byte a byte como está en el documento (python 3.11.2, CPU x86-64, sin red).
- Log: `08c-estimador.log` `b874c2f0873c511a0b0964630e3e2fa1cb6981d27ca03a647ef88dce4c215c37`
- La salida coincide EXACTAMENTE con la transcripta en el documento (bpw 4.92/4.87; F16 14.19 →
  Q2_K 2.33 GiB; KV 56 KiB/token, 0.11/0.44/1.75 GiB; total 5.8 GiB).
- Constantes cotejadas contra el banco el 2026-11-07: parameter_count 7615616512 ✓, archivo
  4683087332 B = 4,36 GiB ✓, block_count 28 ✓, head_count_kv 4 ✓, embedding_length 3584 ✓;
  qwen3-coder:30b: 18556700761 B = 17,28 GiB ✓, parameter_size 30.5B ✓. Marcador VERIFICAR del
  protocolo reemplazado por la constancia del cotejo.

### 8. Afirmaciones ancladas con comando asociado
- §1.3 «Un caso» (`ollama show qwen3.5:4b`): cotejado vía `/api/show`
  (`08-show-qwen35-4b.json` `d2e28ff3ce847c79b86840515fd20c0537b7e00857c615bc3315926299c3c7bc`):
  parameter_count 4205751296 ✓, Q4_K_M ✓, general.license apache-2.0 ✓, arquitectura completa
  presente ✓. Texto intacto.
- §1.5 «Un caso» qwen2.5:7b (28 capas, 4 KV, dim 128, 56 KiB/token, 0,44/1,75 GiB): metadatos
  cotejados contra el banco y aritmética reproducida por el 08-C ✓.
- §1.4 «Un caso» (14,19 GiB F16 / 4,36 GiB Q4_K_M): ambas cifras reproducidas (cálculo y
  /api/tags) ✓.
- bpw de bloque (Q4_0 18 B/32 = 4,5; Q8_0 34 B/32 = 8,5; Q6_K 210 B/256 = 6,5625): aritmética
  verificada; la estructura de bloque queda anclada a la espec. GGUF citada.
- Endpoints nombrados (§1.2 tabla y labs): `/api/generate`, `/api/chat`, `/api/tags`, `/api/ps`
  ejercitados u observados en el banco ✓ (`/api/chat` no lo usa este documento).
- Diagrama mermaid: validado con `tools/medios/mermaid.sh` (ok).

## Resumen
- Verificados: 7 (paso 0, paso 1, paso 3, paso 4, 08-B, 08-C, casos §1.3/§1.4/§1.5)
- Corregidos: 4 (comando paso 3, comando paso 4, «órdenes de magnitud» 08-B, nota de caché 08-B)
- Ilustrativos: 1 (paso 2, `ollama pull` contra el banco)
- BLOQUEO: 0

## Dudas para el PO
Sin dudas.
