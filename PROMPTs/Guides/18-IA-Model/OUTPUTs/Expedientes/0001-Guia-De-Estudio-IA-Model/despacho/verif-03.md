# Constancia de verificación técnica — Núcleo 03 (Del modelo base al asistente)

- **Documento**: `Guides/IA/IA-Model/03-Del-Modelo-Base-Al-Asistente.md` (worktree guía)
- **Fecha**: 2026-11-07 · **Banco**: `$OLLAMA_HOST` (CTX-03), ollama 0.32.0-rc0 (`/api/version`)
- **Evidencia cruda**: `evidencia/local/verif03-*` (fuera del versionado)
- **Modelos**: `qwen2.5:7b-instruct` (digest `845dbda0ea48…b697e`) y `qwen2.5-coder:3b-base`
  (digest `b71a053ff1b3…c0731`) — digests completos cotejados contra la tabla de §3 del
  documento: **coinciden** (`verif03-digests.txt`, sha256 `945cd24ed7be…`).

## Corridas

| # | Ejemplo | Comando | Log (sha256) | Veredicto |
| --- | --- | --- | --- | --- |
| 0 | Paso 0 banco | `curl -s $OLLAMA_HOST/api/tags` (tal como está escrito) | `verif03-paso0.txt` f8eeadd26f13e1bde95500387fb965429311c1c39084091c3edec7f687480f5b | verificado — «banco accesible» |
| 1 | Lab 03-A paso 1 (base, prompt original «¿Cuál es la capital de Francia?») | `/api/generate` raw, T=0, num_predict 60 | `verif03-labA-paso1-base.json` c36f1f0b6c48791ffba811f0a244160a30d64885254b3f7b3a05ffc0a91805de | **FALLÓ la predicción del texto**: el base respondió « La capital de Francia es París.» (done_reason stop, 10 tokens) — no «continúa como documento» |
| 2 | Lab 03-A paso 1 (variantes de prompt) | tres encuadres contra el base | `verif03-labA-paso1-variantes.txt` 416d4ec27714b0178644cb7a259bbcbcdfe7a004990665eacfb4a93404997a90 | «1. ¿Cuál…?» (cuestionario) produce la continuación esperada: preguntas 2–5 y hoja de respuestas |
| 3 | Lab 03-A paso 1 **corregido** (base «1. ¿Cuál…?», num_predict 80; instruct misma entrada) | según documento editado | base en log #2 (variante 1); `verif03-labA-paso1-instruct.json` ecd7dde23c2876f065612a01c8f6eb908d16ae2e1b498d19c35f99417be21dca | **corregido** — salidas reales pegadas; §1.1 reescrito con la advertencia de la prueba ingenua |
| 4 | Lab 03-A paso 2 (prompt original «ciudad de Argentina») | 4+6+6 corridas, T 0 y 1,5, también top_p 1/top_k 0 | `verif03-labA-paso2-temperatura.txt` ae8e65b5…, `-extra15.txt` 21f1e1d1…, `-topp1.txt` 21f1e1d1… | **FALLÓ la predicción**: «Buenos Aires» las 16 veces, incluso a T=1,5 con núcleo completo — respuesta dominante |
| 5 | Lab 03-A paso 2 **corregido** («Inventá un nombre para un bar») | for T in 0 0 1.5 1.5 | `verif03-labA-paso2-final.txt` ab4aca454772b6dac00d0dc7dc0d7bfcc950f4091cd4802b5c5c131367ab7588 (exploración en `-prompts-alt.txt` 46423e35…) | **corregido** — T=0 reproduce «Café del Suspiro»; T=1,5 varía; el hallazgo de la respuesta dominante quedó incorporado al texto como contraejemplo medido |
| 6 | Lab 03-A paso 3 (top_p 0,1 vs 1 a T=1,5) | 3 corridas por valor | `verif03-labA-paso3-topp.txt` 40bbe7d23f6902a68adf5f7d27faa37eb37ffaf00d7be270c5744832358edee6 | verificado — top_p 0,1 colapsa en «Café del Suspiro» ×3; top_p 1 varía e incluye un candidato degenerado («Rogues' Havenバー») |
| 7 | Lab 03-B paso 1 (zero-shot) | `/api/chat`, T=0, tal como está escrito | `verif03-labB-paso1-zeroshot.json` 2bbbb01e405e5481474d3c6ffd402abaafe61705f838a57c6884cbeb04214a00 | verificado — prosa («Este mensaje se clasifica como una queja o reclamo…») |
| 8 | Lab 03-B paso 2 (few-shot) | `/api/chat` con system + 3 ejemplos, tal como está escrito | `verif03-labB-paso2-fewshot.json` b90bbd0b46e7210039cc46c24bb1bee2f5af6f335cd4bae1447cf6adf42ffbb3 | verificado — salida exacta `reclamo` |
| 9 | Lab 03-C paso 1 (streaming NDJSON nativo) | tal como está escrito | `verif03-labC-paso1-ndjson.raw` 2d63f777…, salida 2681ffbe… | verificado — NDJSON por fragmento, `done:true` final con `eval_count` 95 |
| 10 | Lab 03-C paso 2 (streaming SSE `/v1/chat/completions`) | tal como está escrito | `verif03-labC-paso2-sse.raw` d94dbfd9…, salida a02fdc57… | verificado — eventos `data:`, `delta.content`, cierre `[DONE]` |

## Afirmaciones ancladas verificadas con comando

- Motor «ollama 0.32.0-rc0» (§3): `GET /api/version` → `{"version":"0.32.0-rc0"}`
  (`verif03-version.json` e8fb5dcc…). Coincide.
- Digests de la tabla de §3: coinciden carácter por carácter con `/api/tags`.
- Flags/endpoints del texto: `raw`, `num_predict`, `options.temperature/top_p` por pedido,
  streaming default NDJSON en la API nativa, contadores en el fragmento final, capa `/v1` SSE con
  `delta` y `[DONE]` — todos observados en las corridas de arriba.
- Cifra con protocolo (M3): el documento no afirma cifras propias fuera de las salidas de los
  labs; los tres bloques «protocolo» quedaron completados (parámetros, semilla, CTX-03, fecha).
  La cifra de InstructGPT (1,3B preferido sobre un base 100× mayor) está anclada a Ouyang et al.
  2022 sin comando asociado: no corresponde corrida.

## Resumen

- Verificados sin cambio: 6 (paso 0, 03-A paso 3, 03-B pasos 1–2, 03-C pasos 1–2)
- Corregidos (comando y/o texto, con salida real pegada): 2 (03-A paso 1 y paso 2)
- Ilustrativos: 0 · Bloqueados: 0
- Ediciones al documento: §1.1 «Cómo se aplica» reescrito; lab 03-A pasos 1–3 con prompts
  corregidos y salidas reales; labs 03-B/03-C con salidas reales; protocolos completados;
  front matter `entorno_validado` actualizado. Ninguna salida pegada contiene rutas de host ni
  datos personales; el banco figura como `$OLLAMA_HOST`/`localhost`.
