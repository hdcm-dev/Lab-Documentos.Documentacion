# Evidencia del experto en IA — mesa ciclo 1 (2026-10-28)

Sondas contra **el Ollama propio en contenedor (estación 1)**, por `OLLAMA_ENDPOINT` (R-PRIV: el valor no se escribe), con turno del recurso `<recurso-compartido>` (`<envoltorio-de-turnos>`, etiqueta `experto-ia`). Script: `sonda_experto.py`. Salidas: `salidas/*.jsonl`. Fuentes web consultadas: `fuentes.txt`.

## Criterios de éxito escritos ANTES de correr (R-LLM)

- **S1 (embeddings con instrucción).** Determinista: N = 1 por consulta y variante; mismo catálogo y mismas 8 consultas que E-B5. Se compara aciertos top-1 sobre las 7 con clave esperada. Lectura fijada antes: si alguna variante con instrucción supera en ≥ 2 aciertos a la variante sin instrucción, la conclusión de T3 («se descarta normalizar con embeddings», apoyada en 4/7) se apoyó en un uso incompleto del modelo; si no, T3 queda reforzada. En cualquier caso «en avión» debe seguir devolviendo un medio (la similitud siempre devuelve algo).
- **S2 (tokenizador).** Mismo texto en español por `/api/generate` con `raw: true`; se lee `prompt_eval_count`. Éxito de la sonda: ambos valores > 0. Lectura: si difieren en > 10 %, los conteos hechos con el tokenizador de Qwen 2.5 no se pueden citar como tokens de `qwen3.5:4b`.
- **S3 (truncado con el 4b).** Una corrida (N = 1, `temperature` 0, `think` false) sin `num_ctx`, prompt de 240 líneas (~7.000 tokens con el tokenizador de Qwen 2.5) con el dato pedido **sólo en la primera línea** («TREN»). Éxito de la sonda: HTTP 200 y `prompt_eval_count` leído. Lectura: `prompt_eval_count` < tokens esperados ⇒ el truncado silencioso de X3 vale también para el modelo propuesto; si además la respuesta no es «tren», el truncado se comió el dato (X3 no lo podía mostrar porque todas sus líneas decían «colectivo»).
- **S4 (caché de prefijo con el 4b en 0.40.11).** Tres pedidos `/api/chat` con `num_ctx` 4096 explícito, `think` false, prefijo de ~1.500 tokens en el mensaje de sistema: A frío, B mismo prefijo y otra pregunta, C prefijo alterado en el primer carácter. N = 1 por caso (se mide tiempo, no tasa). Lectura fijada antes: si `prompt_eval_s` de B es < 20 % del de A y el de C vuelve a ≥ 80 % del de A, la caché de prefijo funciona con el modelo híbrido en esta versión; si B ≈ A, no se reutiliza y el escalón 1 de N3b («prefijo cacheado») no tiene soporte medido con el modelo propuesto. La respuesta correcta es 1 (persona 7: 7 % 7 + 1) y 6 (persona 12).
- **S5 (¿el presupuesto de prompt es `num_ctx` o `num_ctx`/2?).** Una corrida con `num_ctx` 4096 explícito y un prompt de 120 líneas (~2.900 tokens, entre 2.050 y 4.096), con el dato sólo en la primera línea. Lectura fijada antes: si `prompt_eval_count` ≈ largo completo y la respuesta es «tren», el recorte a `num_ctx`/2 + 2 de X3/S3 ocurre sólo **al desbordar** `num_ctx` y no es el presupuesto de prompt; si sale ≈ 2.050, el presupuesto efectivo es la mitad.

## Resultados (corridas del 2026-10-28, 09:52–10:08 -03, turno exclusivo de `<recurso-compartido>`)

| Sonda | Resultado | Lectura contra el criterio fijado antes |
|---|---|---|
| S1 | Sin instrucción 4/7 (igual que E-B5); instrucción en inglés 5/7; en español 3/7. «en avión» → `moto`, `tren`, `tren`. Normas de los vectores = 1,0 | Ninguna variante mejora ≥ 2: **T3 queda reforzada**. La instrucción sí corre los puntajes absolutos (p. ej. «en el ferrocarril» 0,788 → 0,608): un umbral fijo no es portable entre formatos de consulta |
| S2 | Mismo texto (1.132 caracteres): `qwen2.5:0.5b` 270 tokens (4,19 c/t); `qwen3.5:4b` 226 (5,01 c/t) | Difieren 16 % (> 10 %): los conteos con el tokenizador de Qwen 2.5 no son tokens de `qwen3.5:4b` |
| S3 | Sin `num_ctx`: `prompt_eval_count` 2050, `done_reason` stop, respuesta «colectivo» (lo correcto era «tren»), 100 s, HTTP 200 | El truncado silencioso vale para el modelo propuesto **y se come el dato** del principio |
| S4 | A frío 1.466 tokens, 77,8 s de prompt; B mismo prefijo: `prompt_eval_cached_count` 954, 33,6 s (43 % de A); C prefijo alterado: cached 0, 124,6 s | Reutilización **parcial** (no se cumple < 20 %). En 0.40.11 el campo `prompt_eval_cached_count` existe. Respuestas correctas (1, 6, 1) |
| S5 | `num_ctx` 4096, prompt de 2.943 tokens: entra completo, respuesta «TREN», 167 s de prompt | El recorte a `num_ctx`/2 + 2 ocurre **sólo al desbordar**; el presupuesto de prompt es `num_ctx` menos la salida |

Throughput de procesamiento del prompt de `qwen3.5:4b` en estación 1 (CPU): 1.466/77,8 ≈ 18,8 tok/s; 2.943/167,4 ≈ 17,6 tok/s; 2.050/~100 ≈ 20 tok/s.
