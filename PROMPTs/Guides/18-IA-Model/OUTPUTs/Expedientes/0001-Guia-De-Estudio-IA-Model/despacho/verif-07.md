# Constancia de verificación — Documento 07 (Evaluación y métricas de calidad)

Verificador técnico · fecha de la corrida: 2026-11-07 · banco: Ollama 0.32.0-rc0 (CTX-03, sólo
CPU; en los textos versionados figura como `localhost` / `$OLLAMA_HOST`). Bloques VERIFICAR
resueltos: 9/9. Evidencia cruda en `../evidencia/local/` (fuera del versionado).

## Verificaciones previas (M3 y afirmaciones ancladas)

| Ítem | Comando | Resultado | Veredicto |
| --- | --- | --- | --- |
| Motor del banco | `GET /api/version` | `0.32.0-rc0` — coincide con §3 y el front matter | verificado |
| Digest `qwen2.5:7b-instruct` | `GET /api/tags` | `845dbda0ea48…b697e` — coincide con la tabla de §3 | verificado |
| Digest `qwen3.5:4b` | `GET /api/tags` | `d8b0f5e9760c…38c04` — coincide | verificado |
| Digest `qwen2.5:14b-instruct` (juez) | `GET /api/tags` | `7cdf5a0187d5…b22f6` — coincide | verificado |
| Paso 0 (banco accesible) | bloque `curl` de §3 tal cual | `banco accesible` | verificado |

## Ejemplo §1.2 — perplejidad a mano (CTX-01, stdlib)

- Comando: `python3 -I perplejidad.py` (transcripción literal del bloque del documento; Python 3.11.2)
- Salida: `modelo A: perplejidad = 2.80` / `modelo B: perplejidad = 6.45` — idéntica a la pegada
- Log: `evidencia/local/07-perplejidad.out` · SHA-256 `746d9d61dd8dd8bc5034318548c89fd9bf98ada3f8b41f727d60644d7021635f`
- Veredicto: **verificado** (sin cambios)

## Lab 07-A — mini-eval (bloques VERIFICAR 1–4)

- Comando: `python3 mini_eval.py qwen2.5:7b-instruct qwen3.5:4b` (script y `casos.jsonl`
  transcriptos literales del documento; `OLLAMA_HOST` apuntando al banco)
- Cifra: **10/10 ambos modelos** (coincidencia exacta, temperatura 0); tabla completa pegada en §3.2
- Duración: 28m53s de pared — el corredor alterna modelos por caso y el banco mantenía un solo
  modelo residente (recarga por pedido). Supera el tope orientativo de ~10 min, pero se dejó
  terminar por ser el laboratorio central del documento; quedó declarado en el texto
  («Duración» del lab y campo «Duración observada» del protocolo).
- Log: `evidencia/local/07a-mini-eval.log` · SHA-256 `a58053c6aa7aab369649d8e8a8f04e6a3ec72d38f62df6846964f5d43b3b2319`
- Extracto: `qwen2.5:7b-instruct 10/10 = 100%` / `qwen3.5:4b 10/10 = 100%`
- Veredicto: **verificado** (salida real pegada; se agregó al texto la lectura del empate 10/10 y
  la duración observada — ajustes de texto, no de comando)
- Nota: el paso 3 («romper el eval» con temperature 1) y la variante de fallo 0/10 no se
  corrieron: son ejercicios del lector sin salida pegada en el documento.

## Lab 07-B — LLM-juez (bloques VERIFICAR 5–9)

- Comandos: `python3 juez.py` (fase 1) y `python3 juez.py --juzgar` (fase 2), script y
  `preguntas.jsonl` transcriptos literales del documento
- Fase 1 (generación de pares): 13:29:05Z → terminó ~14:15Z (~46 min) — `qwen3.5:4b` es un
  modelo con razonamiento y en CPU estira cada consigna abierta; salida: «6 pares guardados en
  respuestas.json…», pegada en §3.3. El tope de ~10 min se superó; se dejó terminar por ser el
  laboratorio central restante, y la demora quedó declarada en el texto (aviso del paso 2,
  «Duración» del lab, campo «Duración observada» del protocolo).
  - Log: `evidencia/local/07b-fase1-generar.log` · SHA-256 `e4e861ec7c8e2c58caca750a0ff37307798027e603f4a63e3a03907db04d3dc7`
  - Pares: `evidencia/local/07b-respuestas.json` · SHA-256 `8536c041fc40f19197ab7bed339fbf9099c2bb0ae231dd67ffdd97f629403069`
- Paso 3 (juicio humano previo, mismo criterio de la rúbrica): 1→B, 2→A, 3→A, 4→B, 5→A, 6→B.
  Observación: en el par 1 la respuesta A degenera a chino a mitad de frase (temperatura 0,
  pregunta en español) — material didáctico real para «mirá las fallas una por una».
- Fase 2 (doble pasada del juez 14B): 14:21:46Z → 14:24:54Z (3m08s). Cifra: **consistencia 5/6**
  (par 2 = `EMPATE (sesgo de posición)`); veredictos consistentes 3×`qwen3.5:4b`,
  2×`qwen2.5:7b-instruct`. Acuerdo juez-humano sobre los 5 pares consistentes: **5/5** — por el
  criterio de lectura del documento, juez delegable para esta tarea y esta rúbrica.
  - Log: `evidencia/local/07b-fase2-juzgar.log` · SHA-256 `66a9b5a38173658206f8ac6ae8ad508f8215fb640235b92bb46b7b98f4afb016`
- Veredicto: **verificado** (tabla real pegada; ajustes de texto: aviso de tiempos del paso 2,
  «Duración» del encabezado, lectura del empate del par 2 y los dos campos del protocolo).
  El acuerdo 5/5 no se publicó en el documento: su protocolo declara a propósito que el contraste
  es el ejercicio del lector.

## Resumen

| Clase | n | Detalle |
| --- | --- | --- |
| Verificados | 9 | los 9 bloques VERIFICAR: salida 07-A, 4 campos de protocolo 07-A, salidas fase 1 y 2 de 07-B, 4 campos de protocolo 07-B (más el ejemplo de perplejidad de §1.2 y las 5 verificaciones de banco/digests, ya sin marcador) |
| Corregidos | 0 | ningún comando falló; sólo ajustes de texto por tiempos medidos (declarados arriba) |
| Ilustrativos | 0 | — |
| BLOQUEOS | 0 | — |

Motor confirmado `0.32.0-rc0`; los tres digests de §3 coinciden con `GET /api/tags` del banco.
Ningún modelo nuevo descargado; datos de prueba sembrados sólo por el verificador; en el texto
versionado el banco figura como `localhost`/`$OLLAMA_HOST`.
