# Criterio previo · R-01

Plan de recuperación, B-11 (§2 y §4.3). Caso único: Movilidad Urbana. Escrito el 2026-10-29, antes de cualquier turno con modelo.

| Campo | Valor |
|---|---|
| Pieza | 01 Chat y streaming (ConModelo + `01-cancelacion`) |
| Estación | **estación 1** (única) |
| Destino en la guía | §5 |
| Prioridad (§4.3.3) | lección (§5) |
| N | 2 entradas (v1); cancelación: 10 semillas sobre 1 entrada |
| Pedidos previstos | 12 |

**Hipótesis.** Con el 4b vigente, la respuesta en streaming no es vacía y la cancelación corta el flujo sin dejar la llamada colgada.

**Oráculo.** `no-vacia.jq` sobre las entradas v1; para la cancelación, `01-cancelacion` del arnés (corte observado antes del fin del flujo y sin excepción no controlada).

**Umbral de lectura.** v1: se informa k/2 tal cual, sin tasa. Cancelación: k/10 con Clopper-Pearson 95 %; la lección se sostiene si el límite inferior es > 0,5.

**Estimando.** v1: «N entradas distintas» (2). Cancelación: «una entrada, N semillas» (10).

## Reglas comunes (fijadas antes del primer pedido; este archivo no se edita después)

- **Estación única (M-D):** se mide entera en la **estación 1**. No se parte entre estaciones; un turno que no entra se parte en la misma estación; un reintento es una corrida nueva con criterio nuevo; si la estación cae, lo que falta queda «no medido».
- **Precondición por turno:** versión de Ollama y `/api/tags` leídos dentro del turno; digest del 4b `d8b0f5e9760c`. Si no coinciden: «no medido» (el `2a654d98e6fb` de la base es otro artefacto y no se acepta).
- **Ventana:** `num_ctx=8192` cargado dentro del turno; `/api/ps` registrado (REC-08). `keep_alive: 0` al cerrar.
- **Registros:** fuera del árbol, en `$RLLM_DIR`; columna `servidor` = `estacion-1` (un único valor por corrida, verificable con `jq`).
- **Fallas del entorno** (timeout, red, recarga a mitad): «no medido», sin reintento silencioso.
- **N no se recorta.** Si no entra en los turnos asignados, la corrida queda «no medido».
- **Lectura:** `verificar.sh tasa` (Clopper-Pearson 95 %) con la etiqueta del estimando; `compuerta-intervalos.py` y `recalcular-oraculos.sh` en 0 discrepancias.
