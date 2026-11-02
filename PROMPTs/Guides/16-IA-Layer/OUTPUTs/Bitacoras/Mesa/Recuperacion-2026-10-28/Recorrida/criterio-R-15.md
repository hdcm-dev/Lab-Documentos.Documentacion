# Criterio previo · R-15

Plan de recuperación, B-11 (§2 y §4.3). Caso único: Movilidad Urbana. Escrito el 2026-10-29, antes de cualquier turno con modelo.

| Campo | Valor |
|---|---|
| Pieza | 15 Juez (`15-juez`), 4b, razonamiento apagado, `num_ctx` ≥ 8192 |
| Estación | **estación 2** (única) |
| Destino en la guía | §10.6 |
| Prioridad (§4.3.3) | garantía |
| N | 52 evaluaciones (≈ 34 s c/u, ≈ 30 min; DECI-29) |
| Pedidos previstos | 52 |

**Hipótesis.** El juez de la misma familia acuerda con las etiquetas de referencia; el acuerdo NO es validación (familia común, M-G).

**Oráculo.** `acuerdo-del-juez.jq`; evaluación interpretable = veredicto parseable dentro del formato pedido.

**Umbral de lectura.** **Fracción mínima de evaluaciones interpretables: 45/52 (≥ 0,865).** Si no se alcanza, R-15 es «no medido» y §10.6 lo dice así. Acuerdo: k/interpretables con Clopper-Pearson 95 %, siempre con la advertencia «el acuerdo con un juez de la misma familia no es validación».

**Estimando.** «N entradas distintas» (52).

## Reglas comunes (fijadas antes del primer pedido; este archivo no se edita después)

- **Estación única (M-D):** se mide entera en la **estación 2**. No se parte entre estaciones; un turno que no entra se parte en la misma estación; un reintento es una corrida nueva con criterio nuevo; si la estación cae, lo que falta queda «no medido».
- **Precondición por turno:** versión de Ollama y `/api/tags` leídos dentro del turno; digest del 4b `d8b0f5e9760c`. Si no coinciden: «no medido» (el `2a654d98e6fb` de la base es otro artefacto y no se acepta).
- **Ventana:** `num_ctx=8192` cargado dentro del turno; `/api/ps` registrado (REC-08). `keep_alive: 0` al cerrar.
- **Registros:** fuera del árbol, en `$RLLM_DIR`; columna `servidor` = `estacion-2` (un único valor por corrida, verificable con `jq`).
- **Fallas del entorno** (timeout, red, recarga a mitad): «no medido», sin reintento silencioso.
- **N no se recorta.** Si no entra en los turnos asignados, la corrida queda «no medido».
- **Lectura:** `verificar.sh tasa` (Clopper-Pearson 95 %) con la etiqueta del estimando; `compuerta-intervalos.py` y `recalcular-oraculos.sh` en 0 discrepancias.
