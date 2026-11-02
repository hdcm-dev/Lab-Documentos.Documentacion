# Criterio previo · R-07

Plan de recuperación, B-11 (§2 y §4.3). Caso único: Movilidad Urbana. Escrito el 2026-10-29, antes de cualquier turno con modelo.

| Campo | Valor |
|---|---|
| Pieza | 07 RAG con citas + estabilidad + vía embeddings (oro v2) |
| Estación | **estación 2** (única) |
| Destino en la guía | §7, §10 |
| Prioridad (§4.3.3) | lección |
| N | 17 (oro v2); estabilidad según `ejemplo.json` |
| Pedidos previstos | ≈ 34 (17 RAG + 17 embeddings) + estabilidad |

**Hipótesis.** Las respuestas citan documentos recuperados y no inventan; la estabilidad (`--estabilidad`) se sostiene en la estación 2 sin el timeout de 300 s.

**Oráculo.** `rag-con-citas.jq`, `no-inventa.jq`; estabilidad según `ejemplo.json` (TURNO-1, pesimista 240 s).

**Umbral de lectura.** k/17 con Clopper-Pearson 95 %; estabilidad: pasa / no medido.

**Estimando.** «N entradas distintas» (17).

**Nota.** Digest del embedding esperado: `ac6da0dfba84`.

## Reglas comunes (fijadas antes del primer pedido; este archivo no se edita después)

- **Estación única (M-D):** se mide entera en la **estación 2**. No se parte entre estaciones; un turno que no entra se parte en la misma estación; un reintento es una corrida nueva con criterio nuevo; si la estación cae, lo que falta queda «no medido».
- **Precondición por turno:** versión de Ollama y `/api/tags` leídos dentro del turno; digest del 4b `d8b0f5e9760c` y del embedding `ac6da0dfba84`. Si no coinciden: «no medido» (el `2a654d98e6fb` de la base es otro artefacto y no se acepta).
- **Ventana:** `num_ctx=8192` cargado dentro del turno; `/api/ps` registrado (REC-08). `keep_alive: 0` al cerrar.
- **Registros:** fuera del árbol, en `$RLLM_DIR`; columna `servidor` = `estacion-2` (un único valor por corrida, verificable con `jq`).
- **Fallas del entorno** (timeout, red, recarga a mitad): «no medido», sin reintento silencioso.
- **N no se recorta.** Si no entra en los turnos asignados, la corrida queda «no medido».
- **Lectura:** `verificar.sh tasa` (Clopper-Pearson 95 %) con la etiqueta del estimando; `compuerta-intervalos.py` y `recalcular-oraculos.sh` en 0 discrepancias.
