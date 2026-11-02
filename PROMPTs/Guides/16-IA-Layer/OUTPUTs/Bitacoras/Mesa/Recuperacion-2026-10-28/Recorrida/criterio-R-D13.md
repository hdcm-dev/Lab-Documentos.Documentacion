# Criterio previo · R-D13

Plan de recuperación, B-11 (§2 y §4.3). Caso único: Movilidad Urbana. Escrito el 2026-10-29, antes de cualquier turno con modelo.

| Campo | Valor |
|---|---|
| Pieza | Sonda DEP-13 (clase K del presupuesto) |
| Estación | **estación 1** (única) |
| Destino en la guía | — (E.5) |
| Prioridad (§4.3.3) | existencia |
| N | según `Sondas/`: 2 entradas (`k01`, `k02`), 1 llamada c/u |
| Pedidos previstos | 2 |

**Hipótesis.** Una llamada de clase K (p ≤ 500, sin herramientas) entra en su pesimista de 80 s en la estación 1.

**Oráculo.** `dep13-clase-k.jq` (de `Sondas/oraculos/`).

**Umbral de lectura.** k/2 tal cual, sin tasa; alimenta R-E5.

**Estimando.** «N entradas distintas» (2).

## Reglas comunes (fijadas antes del primer pedido; este archivo no se edita después)

- **Estación única (M-D):** se mide entera en la **estación 1**. No se parte entre estaciones; un turno que no entra se parte en la misma estación; un reintento es una corrida nueva con criterio nuevo; si la estación cae, lo que falta queda «no medido».
- **Precondición por turno:** versión de Ollama y `/api/tags` leídos dentro del turno; digest del 4b `d8b0f5e9760c`. Si no coinciden: «no medido» (el `2a654d98e6fb` de la base es otro artefacto y no se acepta).
- **Ventana:** `num_ctx=8192` cargado dentro del turno; `/api/ps` registrado (REC-08). `keep_alive: 0` al cerrar.
- **Registros:** fuera del árbol, en `$RLLM_DIR`; columna `servidor` = `estacion-1` (un único valor por corrida, verificable con `jq`).
- **Fallas del entorno** (timeout, red, recarga a mitad): «no medido», sin reintento silencioso.
- **N no se recorta.** Si no entra en los turnos asignados, la corrida queda «no medido».
- **Lectura:** `verificar.sh tasa` (Clopper-Pearson 95 %) con la etiqueta del estimando; `compuerta-intervalos.py` y `recalcular-oraculos.sh` en 0 discrepancias.
