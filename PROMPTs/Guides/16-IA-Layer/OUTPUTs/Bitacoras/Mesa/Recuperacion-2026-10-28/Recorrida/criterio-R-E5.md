# Criterio previo · R-E5

Plan de recuperación, B-11 (§2 y §4.3). Escrito el 2026-10-29, antes de cualquier turno con modelo.

| Campo | Valor |
|---|---|
| Qué | tiempos reales por llamada y por estación (`E5-presupuesto`) |
| Estación | estación 1 y estación 2, **informadas por separado** (exenta de la regla de estación única, M-D) |
| Destino en la guía | §E.5 (llena `⟦REC-02:E5-presupuesto⟧`) |
| N | todas las llamadas de las corridas anteriores (sin pedidos propios) |

**Hipótesis.** La mediana real por llamada del 4b en cada estación permite recalcular el presupuesto de §E.5 (R-LLM-5 dio ≈ 27 s en la estación 2).

**Oráculo.** Comparación literal contra los valores esperados que fija la presidencia por variable (`OLLAMA_VERSION_ESPERADA`, `DIGEST_4B_ESPERADO`, `DIGEST_EMB_ESPERADO`), sin defecto.

**Umbral de lectura.** mediana, p90 y máximo de `duracion_reloj_ms` por estación y por clase; sin agregar estaciones.

**Estimando.** Descriptivo, por estación; nunca se agregan las dos estaciones.

## Reglas comunes

- Turnos cortos, uno por estación (el recurso de cada estación lo fija la presidencia); el endpoint de la estación 2 se lee dentro del turno y no se escribe.
- Registro fuera del árbol; columna `servidor` = `estacion-1` / `estacion-2` por fila.
- Una falla de red es «no medido» para esa estación, sin reintento silencioso.
- Estación 2: nunca emuladores ni KVM.
