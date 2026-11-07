# Constancia de verificación técnica — Documento 11 (Panorama y ecosistema abierto)

Verificador técnico · 2026-11-07 · banco: Ollama real (en los textos: `localhost` / `$OLLAMA_HOST`),
motor `0.32.0-rc0`. Evidencia cruda en `../evidencia/local/`.

## 1. Inventario de §1.6 (afirmación anclada con comando: `/api/tags` + `/api/version`)

- Comando: `curl -s $OLLAMA_HOST/api/version` y `curl -s $OLLAMA_HOST/api/tags` (resumen name/digest/params/quant).
- Log: `evidencia/local/verif-11-tags.log` — SHA-256 `2e56b41564578f265b7a292571a5c0c428f49b8fc278660fd744eb8a32136412`.
- Extracto: `{"version":"0.32.0-rc0"}`; 11 modelos; p. ej. `qwen3.5:4b d8b0f5e9760c 4.2B Q4_K_M`,
  `qwen3.5:35b-a3b 72aac7c28be8 34.7B Q4_K_M`, `gpt-oss:20b f38aa0c53da5 20.9B MXFP4`,
  `gemma4:e4b-it-qat ee6656371218 7.5B Q4_0`, `qwen2.5-coder:3b-base b71a053ff1b3 3.1B Q4_K_M`.
- Cotejo: las **11 filas** de la tabla §1.6 (etiqueta, digest-prefijo, parámetros, cuantización)
  coinciden una a una con el banco; la versión del motor citada en §1.6 y en Referencias coincide.
- Veredicto: **verificado**.

## 2. Laboratorio 11.A, paso 4 (`/api/show` de `qwen3.5:35b-a3b`)

- Corrida original: log `evidencia/local/verif-11a-show.log` — SHA-256
  `aa4de1a4140037c0dbd514e749a4dca9b4993743741f318581436e08ce61bc82`. El comando corría, pero el
  campo `license` arranca con sangría y los primeros 60 caracteres eran casi todos espacios: la
  línea `licencia  :` salía visualmente vacía.
- Arreglo de comando (dentro del mandato): `(d.get('license') or '')[:60]` →
  `' '.join((d.get('license') or '').split())[:60]` (normaliza whitespace antes de recortar).
- Corrida corregida: log `evidencia/local/verif-11a-show-corregido.log` — SHA-256
  `27eae14223ce352c0848b690180ad413a5306ed6b109c29a49d511aa11f6f396`.
- Extracto: `familia: qwen35moe · parámetros: 34.7B · cuant.: Q4_K_M · licencia: Apache License Version 2.0, January 2004 http://www.apache.o`
- Salida pegada en el documento (reemplaza el `<!-- VERIFICAR -->`), con dos líneas de lectura.
- Veredicto: **corregido** (comando) y verificado contra el banco.

## 3. Laboratorio 11.B, paso 4 (humo `/api/generate` sobre 3 modelos)

- Comando: el bucle `for m in qwen3.5:4b qwen2.5:14b-instruct gpt-oss:20b` del documento, literal
  (temperature 0.3, seed 42, stream false).
- Log: `evidencia/local/verif-11b-humo.log` — SHA-256
  `89a189cca1b7bc2325f667cde37fdbb67901882e463d05a305061d8e58eee737`.
- Extracto: los tres modelos resumen en español sin omitir el punto resolutivo;
  `qwen3.5:4b → 9.8 tok/s`, `qwen2.5:14b-instruct → 4.1 tok/s`, `gpt-oss:20b → 9.2 tok/s` (CPU).
- Salida pegada en el documento (reemplaza el `<!-- VERIFICAR -->`), con una lectura didáctica
  (MoE: activos mandan la velocidad) y la aclaración de que son velocidades del banco.
- Veredicto: **verificado** (comando literal del documento, sin cambios).

## 4. Licencias por artefacto (afirmaciones de §1.3/§1.6 con comando asociado)

- Comando: `/api/show` sobre `qwen2.5-coder:3b-base`, `qwen2.5-coder:7b`, `gemma4:e4b-it-qat`,
  `gpt-oss:20b`, imprimiendo los primeros 100 caracteres del `license` embebido.
- Log: `evidencia/local/verif-11-licencias.log` — SHA-256
  `484768519ce4bd729a52cbacdb6eab0c8059746606857ebc06d00921a63062c8`.
- Extracto: `3b-base → "Qwen RESEARCH LICENSE AGREEMENT … Release Date: September 19, 2024"`;
  `7b / gemma4 / gpt-oss → "Apache License Version 2.0"`.
- Cotejo: confirma la regla «la licencia es por artefacto» con el ejemplo exacto del texto
  (3B Research vs. 7B Apache, Hui et al. 2024) y las celdas de licencia de §1.6 para esas filas.
- Veredicto: **verificado**.

## 5. Diagrama mermaid de §1.7

- Validado y renderizado con `tools/medios/mermaid.sh`. Compilaba, pero los `\n` de las etiquetas
  se renderizaban **literales** en los nodos («definidas\n¿texto…»). Corregido a `<br/>`;
  re-render verificado limpio (corridas `out/mermaid/20261107-093051` y `20261107-093159` del
  workspace, fuera del versionado).
- Veredicto: **corregido**.

## 6. No operables en el banco

- Tabla §1.5 (fichas HF, prensa): afirmaciones documentales sin comando; las filas sin fuente
  primaria ya están marcadas «primaria pendiente de verificación» en el propio documento y en §5.
  Fuera del alcance del banco; no se tocan.
- No hay bloques «protocolo» (M3) en este documento: las únicas cifras medidas (digests,
  cuantizaciones, versión del motor) quedaron verificadas en el punto 1.

## Resumen

- Verificados: 3 (inventario §1.6; licencias por artefacto; humo 11.B — ver punto 3)
- Corregidos: 2 (comando del 11.A paso 4; mermaid §1.7)
- Ilustrativos: 0
- BLOQUEO: 0
