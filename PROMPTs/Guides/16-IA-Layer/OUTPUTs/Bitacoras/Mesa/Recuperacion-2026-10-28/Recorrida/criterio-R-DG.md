# Criterio previo · R-DG

Plan de recuperación, B-11 (§2 y §4.3). Escrito el 2026-10-29, antes de cualquier turno con modelo.

| Campo | Valor |
|---|---|
| Qué | digests y versión de ambas estaciones (`digest-4b`, `F4-servidores`) |
| Estación | estación 1 y estación 2, **informadas por separado** (exenta de la regla de estación única, M-D) |
| Destino en la guía | F.4, §4.2, §5.7 (llena `⟦REC-02:digest-4b⟧` y `⟦REC-02:F4-servidores⟧`) |
| N | 1 lectura por estación (`/api/version`, `/api/tags`, `/api/ps`); ninguna inferencia |

**Hipótesis.** Cada estación sirve el 4b con digest `d8b0f5e9760c` y el embedding con `ac6da0dfba84`; se registra la versión de Ollama de cada una.

**Oráculo.** Comparación literal contra los valores esperados que fija la presidencia por variable (`OLLAMA_VERSION_ESPERADA`, `DIGEST_4B_ESPERADO`, `DIGEST_EMB_ESPERADO`), sin defecto.

**Umbral de lectura.** coincide / no coincide por estación y por modelo; versión tal cual. Si alguna no coincide, las corridas de esa estación son «no medido» hasta que coincida.

**Estimando.** Descriptivo, por estación; nunca se agregan las dos estaciones.

## Reglas comunes

- Turnos cortos, uno por estación (el recurso de cada estación lo fija la presidencia); el endpoint de la estación 2 se lee dentro del turno y no se escribe.
- Registro fuera del árbol; columna `servidor` = `estacion-1` / `estacion-2` por fila.
- Una falla de red es «no medido» para esa estación, sin reintento silencioso.
- Estación 2: nunca emuladores ni KVM.
