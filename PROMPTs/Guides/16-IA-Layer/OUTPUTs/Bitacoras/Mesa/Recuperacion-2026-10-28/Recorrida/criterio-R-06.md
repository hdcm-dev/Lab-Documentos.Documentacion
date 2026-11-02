# Criterio previo · R-06

Plan de recuperación, B-11 (§2 y §4.3). Caso único: Movilidad Urbana. Escrito el 2026-10-29, antes de cualquier turno con modelo.

| Campo | Valor |
|---|---|
| Pieza | 06 Embeddings y búsqueda semántica (evaluación, calibración aparte, determinismo) |
| Estación | **estación 1** (única) |
| Destino en la guía | §6, §7 |
| Prioridad (§4.3.3) | lección |
| N | evaluación 17 (oro v2); calibración 10; determinismo 2 corridas idénticas |
| Pedidos previstos | 61 pedidos de embedding (17+10+2×17), ninguno del 4b |

**Hipótesis.** Con el embedding vigente, top-3 recupera el documento del oro; la calibración no se mezcla con la evaluación; dos corridas idénticas dan los mismos vectores.

**Oráculo.** `recuperacion-top3.jq` sobre el oro v2 completo; calibración con `oro/calibracion.v1.json` (10 casos, disjuntos del oro); determinismo: igualdad de vectores o de ranking entre las dos corridas.

**Umbral de lectura.** evaluación: k/17 con Clopper-Pearson 95 %; determinismo: «idéntico» o «no idéntico», sin tasa.

**Estimando.** evaluación: «N entradas distintas» (17); determinismo: «una entrada, 2 corridas».

**Nota.** Digest del embedding esperado: `ac6da0dfba84`.

## Reglas comunes (fijadas antes del primer pedido; este archivo no se edita después)

- **Estación única (M-D):** se mide entera en la **estación 1**. No se parte entre estaciones; un turno que no entra se parte en la misma estación; un reintento es una corrida nueva con criterio nuevo; si la estación cae, lo que falta queda «no medido».
- **Precondición por turno:** versión de Ollama y `/api/tags` leídos dentro del turno; digest del 4b `d8b0f5e9760c` y del embedding `ac6da0dfba84`. Si no coinciden: «no medido» (el `2a654d98e6fb` de la base es otro artefacto y no se acepta).
- **Ventana:** `num_ctx=8192` cargado dentro del turno; `/api/ps` registrado (REC-08). `keep_alive: 0` al cerrar.
- **Registros:** fuera del árbol, en `$RLLM_DIR`; columna `servidor` = `estacion-1` (un único valor por corrida, verificable con `jq`).
- **Fallas del entorno** (timeout, red, recarga a mitad): «no medido», sin reintento silencioso.
- **N no se recorta.** Si no entra en los turnos asignados, la corrida queda «no medido».
- **Lectura:** `verificar.sh tasa` (Clopper-Pearson 95 %) con la etiqueta del estimando; `compuerta-intervalos.py` y `recalcular-oraculos.sh` en 0 discrepancias.
