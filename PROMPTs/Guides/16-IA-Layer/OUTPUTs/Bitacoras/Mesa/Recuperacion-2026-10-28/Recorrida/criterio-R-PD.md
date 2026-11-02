# Criterio previo · R-PD

Plan de recuperación, B-11 (§2 y §4.3). Caso único: Movilidad Urbana. Escrito el 2026-10-29, antes de cualquier turno con modelo.

| Campo | Valor |
|---|---|
| Pieza | Demo `MovilidadUrbana.Asistente` (humos PD-2, PD-3 con «CP 34», PD-6; `demo.sh embeddings`) |
| Estación | **estación 2** (única) |
| Destino en la guía | §14, PD-2/3/6 |
| Prioridad (§4.3.3) | garantía |
| N | 3 humos; 9 entradas (v1) |
| Pedidos previstos | 12 |

**Hipótesis.** PD-2 cita, PD-3 da los habitantes del servicio (incluido «CP 34»), PD-6 no ejecuta un pedido sin confirmar; la vía embeddings recupera.

**Oráculo.** `demo-pd2-cita.jq`, `demo-pd3-habitantes.jq`, `demo-pd6-pedido.jq`; `recuperacion-top3.jq` para `demo.sh embeddings`.

**Umbral de lectura.** humos: pasa / falla cada uno (PD-6 es garantía: falla ⇒ se informa como falla, sin reintento silencioso); embeddings: k/9 con Clopper-Pearson 95 %.

**Estimando.** humos: «una entrada» c/u; embeddings: «N entradas distintas» (9).

**Nota.** Digest del embedding esperado: `ac6da0dfba84`.

## Reglas comunes (fijadas antes del primer pedido; este archivo no se edita después)

- **Estación única (M-D):** se mide entera en la **estación 2**. No se parte entre estaciones; un turno que no entra se parte en la misma estación; un reintento es una corrida nueva con criterio nuevo; si la estación cae, lo que falta queda «no medido».
- **Precondición por turno:** versión de Ollama y `/api/tags` leídos dentro del turno; digest del 4b `d8b0f5e9760c` y del embedding `ac6da0dfba84`. Si no coinciden: «no medido» (el `2a654d98e6fb` de la base es otro artefacto y no se acepta).
- **Ventana:** `num_ctx=8192` cargado dentro del turno; `/api/ps` registrado (REC-08). `keep_alive: 0` al cerrar.
- **Registros:** fuera del árbol, en `$RLLM_DIR`; columna `servidor` = `estacion-2` (un único valor por corrida, verificable con `jq`).
- **Fallas del entorno** (timeout, red, recarga a mitad): «no medido», sin reintento silencioso.
- **N no se recorta.** Si no entra en los turnos asignados, la corrida queda «no medido».
- **Lectura:** `verificar.sh tasa` (Clopper-Pearson 95 %) con la etiqueta del estimando; `compuerta-intervalos.py` y `recalcular-oraculos.sh` en 0 discrepancias.
