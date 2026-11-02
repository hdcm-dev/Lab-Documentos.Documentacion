# Criterio previo · R-08

Plan de recuperación, B-11 (§2 y §4.3). Caso único: Movilidad Urbana. Escrito el 2026-10-29, antes de cualquier turno con modelo.

| Campo | Valor |
|---|---|
| Pieza | 08 Primera herramienta de sólo lectura (v1 + extensión + `fuera-de-catalogo`) |
| Estación | **estación 2** (única) |
| Destino en la guía | §7, §8 |
| Prioridad (§4.3.3) | lección |
| N | 2 (v1) + 8 (extensión) + 10 semillas (`fuera-de-catalogo`) |
| Pedidos previstos | 20 (más vueltas de herramienta) |

**Hipótesis.** La herramienta se usa para responder y, fuera de catálogo, el modelo no inventa una localidad.

**Oráculo.** `afirma-sin-herramienta.jq`, `no-inventa.jq`; `fuera-de-catalogo`: no devuelve una localidad que no exista.

**Umbral de lectura.** v1+extensión: k/10, Clopper-Pearson 95 %; fuera-de-catálogo: k/10, Clopper-Pearson 95 %; no se suman. Si mide lo de X2/D6, reemplaza la cita del insumo (M-L).

**Estimando.** v1+extensión: «N entradas distintas» (10); fuera-de-catálogo: «una entrada, N semillas» (10).

## Reglas comunes (fijadas antes del primer pedido; este archivo no se edita después)

- **Estación única (M-D):** se mide entera en la **estación 2**. No se parte entre estaciones; un turno que no entra se parte en la misma estación; un reintento es una corrida nueva con criterio nuevo; si la estación cae, lo que falta queda «no medido».
- **Precondición por turno:** versión de Ollama y `/api/tags` leídos dentro del turno; digest del 4b `d8b0f5e9760c`. Si no coinciden: «no medido» (el `2a654d98e6fb` de la base es otro artefacto y no se acepta).
- **Ventana:** `num_ctx=8192` cargado dentro del turno; `/api/ps` registrado (REC-08). `keep_alive: 0` al cerrar.
- **Registros:** fuera del árbol, en `$RLLM_DIR`; columna `servidor` = `estacion-2` (un único valor por corrida, verificable con `jq`).
- **Fallas del entorno** (timeout, red, recarga a mitad): «no medido», sin reintento silencioso.
- **N no se recorta.** Si no entra en los turnos asignados, la corrida queda «no medido».
- **Lectura:** `verificar.sh tasa` (Clopper-Pearson 95 %) con la etiqueta del estimando; `compuerta-intervalos.py` y `recalcular-oraculos.sh` en 0 discrepancias.
