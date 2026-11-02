# Criterio previo · R-02

Plan de recuperación, B-11 (§2 y §4.3). Caso único: Movilidad Urbana. Escrito el 2026-10-29, antes de cualquier turno con modelo.

| Campo | Valor |
|---|---|
| Pieza | 02 Cambio de adaptador (ConModelo + captura de cuerpo `/v1`, `02-max-tokens`) |
| Estación | **estación 1** (única) |
| Destino en la guía | §5.6 |
| Prioridad (§4.3.3) | lección (§5) |
| N | 1 entrada (v1); max-tokens: 10 semillas |
| Pedidos previstos | 11 |

**Hipótesis.** El cuerpo que sale por `/v1` lleva el tope `MaxOutputTokens=3` y el servidor lo respeta (eval_count ≤ 3).

**Oráculo.** `dos-adaptadores.jq` sobre la entrada v1; `02-max-tokens`: cuerpo capturado contiene el tope y `eval_count` ≤ 3.

**Umbral de lectura.** max-tokens: k/10 con Clopper-Pearson 95 %; se afirma «lo respeta» sólo con 10/10; con menos, se informa k/10 sin afirmar.

**Estimando.** v1: «una entrada» (1). max-tokens: «una entrada, N semillas» (10).

## Reglas comunes (fijadas antes del primer pedido; este archivo no se edita después)

- **Estación única (M-D):** se mide entera en la **estación 1**. No se parte entre estaciones; un turno que no entra se parte en la misma estación; un reintento es una corrida nueva con criterio nuevo; si la estación cae, lo que falta queda «no medido».
- **Precondición por turno:** versión de Ollama y `/api/tags` leídos dentro del turno; digest del 4b `d8b0f5e9760c`. Si no coinciden: «no medido» (el `2a654d98e6fb` de la base es otro artefacto y no se acepta).
- **Ventana:** `num_ctx=8192` cargado dentro del turno; `/api/ps` registrado (REC-08). `keep_alive: 0` al cerrar.
- **Registros:** fuera del árbol, en `$RLLM_DIR`; columna `servidor` = `estacion-1` (un único valor por corrida, verificable con `jq`).
- **Fallas del entorno** (timeout, red, recarga a mitad): «no medido», sin reintento silencioso.
- **N no se recorta.** Si no entra en los turnos asignados, la corrida queda «no medido».
- **Lectura:** `verificar.sh tasa` (Clopper-Pearson 95 %) con la etiqueta del estimando; `compuerta-intervalos.py` y `recalcular-oraculos.sh` en 0 discrepancias.
