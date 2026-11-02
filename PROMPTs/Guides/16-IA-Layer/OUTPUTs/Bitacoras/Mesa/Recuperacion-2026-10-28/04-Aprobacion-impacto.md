---
doc_id: BIT-16-REC-04-IMPACTO
doc_type: aprobacion-de-plan
title: Aprobación del plan de recuperación — juez de impacto (mesa de recuperación, 2026-10-28)
status: MEJORAR_PLAN
origin: agent (jurado, juez de impacto)
last_review: 2026-10-28
---

# Aprobación del plan · juez de impacto (2026-10-28)

**Qué revisé.** [`03-Plan-De-Recuperacion.md`](03-Plan-De-Recuperacion.md) frente a [`01-Matriz.md`](01-Matriz.md) y a las cinco boletas `02-Voto-*.md`, incluidas las condiciones y enmiendas que cada boleta dejó escritas. Mi criterio es el mismo de mi voto: qué le llega al lector de la guía, es decir, al que copia los ejemplos, al que reproduce lo rotulado como medido, al que busca un término y al que llega al repo público.

**Comprobaciones hechas.** El sha256 de la guía coincide con el que fija B-00 0.3 (`ee1e6ae2…0a16f`, 0.10.1). Las ganadoras de la tabla §0.3 del plan coinciden con las boletas: REC-07 C (3 a 2), REC-21 C (4 a 1), REC-15 B (5 a 0), REC-23 A (3 a 2) y el veto de riesgo sobre REC-06 B. Las líneas 139 y 163 de la guía se leyeron sobre la 0.10.1.

## Decisión: MEJORAR_PLAN

El plan es sólido y está bien ordenado. Integra primero, mide después y relee al final. Usa el marcador `⟦REC-02:…⟧` con compuerta en 0 y deja «no medido» cuando el entorno falla. No hay nada que escalar, porque ningún punto cae en REED-16 §12: todo se corrige dentro de la mesa. Sin embargo, el plan omite o contradice **tres enmiendas que el jurado dejó escritas como condición** y deja sin tratar **la plantilla de rótulo que el lector imita en toda la guía**. Si se aplica tal como está, el lector recibe justo lo que el jurado votó evitar.

### Correcciones obligatorias (bloquean la aplicación)

| # | Dónde | Defecto | Corrección |
|---|---|---|---|
| M-1 | B-06 6.9 (y 9.x donde aplique) | La frase de `tool_choice` quedó como en la opción A sin enmendar: «el cliente lo envía; el servidor no lo honra según [REF-51]». El abogado del diablo, coherencia histórica y yo pedimos la enmienda, porque REF-51 es documentación y el insumo dejó el cumplimiento como no medido. Así, el lector recibe como hecho algo que nadie midió. | Redactar: «el cliente envía `tool_choice`; la documentación de `/v1` no lo lista [REF-51]; que el servidor lo cumpla no está medido». Alinear también las demás líneas que dicen «/v1 no admite» (la matriz y el abogado del diablo citan l. ~1000, 1027, 1279, 1300, 2107 y la que sigue). Ubicarlas por `grep -n 'tool_choice'`. |
| M-2 | B-01 1.5 y B-11 prep. 4 | El plan dice que `OLLAMA_SERVIDOR` y `RLLM_MAQUINA` «se leen del entorno **con defecto**». Evidencia la declaró obligatoria y riesgo la hizo suya: en la fase con modelo van **sin** defecto y la fase aborta si faltan. Con un defecto, una cifra puede salir rotulada con un servidor que no es el que la midió, y el lector no tiene cómo detectarlo. | En 1.5: con defecto neutro sólo para `--fake` y cableado; en `fase` y en toda corrida con modelo, sin defecto y con `rc ≠ 0` y mensaje si faltan. Sumar esa verificación al paso 1.5 (análoga a la de `RLLM_DIR` en 1.7) y citarla en B-11 prep. 4. |
| M-3 | B-06 (nuevo 6.0), antes de 6.1 | La plantilla de rótulo de §0.4 (l. 163: «Observado en el laboratorio: `qwen3.5:4b` (digest `2a654d98e6fb`), Ollama 0.32.0-rc0, … servidor compartido, 2026-10-27») no figura en ningún bloque. Es el modelo que el lector copia en toda la guía (nota 1 de mi boleta), y hoy remite a un artefacto y a un servidor retirados. B-12 12.3 limpia las 29 apariciones, pero no la plantilla. | Paso 6.0: reescribir el ejemplo de rótulo de §0.4 con la forma vigente («estación N, Ollama x.y.z, digest, fecha, estimando»), con `⟦REC-02:digest-4b⟧` y `⟦REC-02:F4-servidores⟧` donde vaya la cifra. Que la forma corta coincida con la que usa B-12 12.1. |
| M-4 | B-06 (nuevo 6.0 bis) | §0.3 (l. 139) le pide al lector «el Ollama propio (`OLLAMA_PROPIO_ENDPOINT`)», un servidor retirado. Mi boleta lo pidió en REC-05, y REC-07 C cambia los papeles a «modelo-compartido / modelo-propio». En la guía hay 28 menciones de «Ollama propio» y el plan sólo trata `TOPE_LAN_S` en los `.md` de forma genérica («se tratan en B-06…B-10»), sin un paso que lo haga. | Paso explícito: l. 139 y cada mención de «Ollama propio» o «servidor compartido» en presente pasan a **papel** (servidor aparte para embeddings y juez; el mismo del chat), o a historia si describen una medición pasada. El nombre de la variable `OLLAMA_PROPIO_ENDPOINT` se mantiene si el código lo usa, con una línea que lo explique como papel. `grep -n 'TOPE_LAN_S\|Ollama propio\|servidor compartido' $DOC` sin usos en presente al cerrar B-10. Registrarlo como compuerta en 10.16. |

### Precisiones (no bloquean, pero se aplican en el mismo bloque)

| # | Dónde | Qué agregar | Por qué (boleta) |
|---|---|---|---|
| P-1 | B-08 8.1 | Salida de REC-13: si la prueba de 4 simultáneos no queda determinista (10 de 10 sin depender del orden), se cae a REC-13 C (prosa + capa del cliente) y la demo no porta el limitador. Anotarlo como DEU-08. | Impacto y costo-beneficio condicionaron A a eso: una prueba que falla a veces le hace más daño al lector que la recomendación sola. |
| P-2 | B-11 criterio previo + R-15 | El criterio previo de R-15 fija una **fracción mínima de evaluaciones interpretables**. Si no se alcanza, «no medido». La guía declara que el juez es de la misma familia que el modelo evaluado y no presenta el acuerdo como validación. | Evidencia (REC-18). Sin esto, puede repetirse el 0/52 que no midió nada. |
| P-3 | B-11 «Lectura» | Regla explícita: cada tasa se mide entera en una sola estación, ningún pareado cruza estaciones y el estimando se fija en el criterio antes de la primera llamada. | Evidencia y riesgo (REC-02). La tabla de corridas ya asigna estación por pieza, pero la regla no está escrita. |
| P-4 | B-03 3.1 / 3.5 | Después de portar el lector de prefijo: rebuild completo (n/n) y `ArnesTests` en el cierre de B-03, y comprobar que el lector **no** guarda cuerpos completos en disco. | Riesgo (REC-22): `_Comun` lo comparten todos los ejemplos. |
| P-5 | B-06 6.6 / B-07 7.2 | En REC-21 C, sumar a la frase del tokenizador la calibración por modelo y la verificación con el modelo de la llamada, como precisiones de `GuardaDeTruncado` (sin una segunda guarda). | Coherencia histórica (REC-21). |
| P-6 | B-07 7.1 | Que §5.7 y §6.3 digan lo mismo sobre `estado_cache`. Del insumo entra sólo la existencia (tokens cacheados > 0) y la cifra de tiempo sale de R-05. | Mi boleta (REC-22). |
| P-7 | B-09 9.8 | El texto inyectado que se cite es sintético y pasa el barrido. Si R-16 lo observa con la base, se usa esa medición y la del insumo queda como historia. | Riesgo e impacto (REC-23). |

## Lo que apruebo sin cambios

- El orden B-00…B-15 y sus dependencias, con la relectura sobre la 0.11.0 ya re-corrida (REC-03) y los informes del insumo usados como insumo, sin tratarlos como hallazgos (REC-04).
- El lote R-PRIV completo (REC-06, con el veto respetado) y REC-07 C con la verificación por `--fake` y ArnesTests.
- REC-15 B sin la tabla 2b/4b del insumo, y la alternativa 7b quitada o rotulada.
- Las deudas DEU-01…DEU-07 declaradas, y que la publicación de la demo, el commit y el paso a «publicada» queden en manos del PO (B-15).

## Condición de aprobación

Con M-1…M-4 incorporados al plan (texto del paso, no sólo una nota), mi voto pasa a **APROBAR** sin otra revisión. P-1…P-7 se aplican dentro de sus bloques y se anotan en `04-Aplicacion.md`.
