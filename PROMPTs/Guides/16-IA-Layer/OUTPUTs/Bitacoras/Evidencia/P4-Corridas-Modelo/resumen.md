# P4 — corridas pendientes contra el modelo (2026-10-27, 14:40–15:08 -03)

Índice de la evidencia. Nada se commiteó. Los registros R-LLM de las sondas están en `../Sondas/`, con sus oráculos (`../Sondas/oraculos/`) y su fuente (`../Sondas/fuente/`). Las extensiones están en `../R-LLM/*.modelo-ext.jsonl`.

## Tope de `<recurso-compartido>` (medidor con el registro del gestor)

| Momento | Usado | Restante |
|---|---|---|
| antes de empezar | 7.795 s | 6.605 s |
| antes de 03 ext. (después de DEP-09 y DEP-13) | 8.071 s | 6.329 s |
| antes de 04 ext. | 8.281 s | 6.119 s |
| antes de 08 ext. | 8.433 s | 5.967 s |
| después de 08 ext. | 9.153 s | **5.247 s** |

Todas entraron enteras por la regla de cola: el pesimista total era 80 + 400 + 160 + 640 + 640 + 3.200 = 5.120 s, contra 6.605 s. No hizo falta aplicar la línea de corte. La carga en frío no se gastó porque `/api/ps` ya listaba el modelo.

## Consumo por corrida (gestor, `turnos-gestor.p4.tsv`)

| Corrida | Recurso | Turno (s) | Pesimista (s) | Llamadas |
|---|---|---|---|---|
| compilar las sondas | build | 23 | — | — |
| DEP-03 | [recurso-modelo-propio] | 107 | 220 | 3 |
| DEP-09 | <recurso-compartido> | 59 | 400 | 2 |
| DEP-13 | <recurso-compartido> | 217 | 160 | 2 |
| recompilar 03/04/08 en seco | build | 20 | — | — |
| 03 ext. (M = 8) | <recurso-compartido> | 210 | 640 | 8 |
| 04 ext. (M = 8) | <recurso-compartido> | 152 | 640 | 8 |
| 08 ext. (M = 8) | <recurso-compartido> | 720 | 3.200 | 14 |
| **Total `<recurso-compartido>`** | | **1.358** | 5.040 | |

## Resultados (recalculados desde el registro: 365/365 en `R-LLM/`, 4/4 en `Sondas/`; 0 `truncado_posible`)

- **DEP-03** (`dep03.log`): con la capa única (`AddOllamaOption(OllamaOption.NumCtx, 8192)` por `ConfigureOptions`, que compila con M.E.AI 10.11.0) el servidor procesa **5.714** tokens. Sin la opción procesa **2.050**: recorta en silencio (Ollama 0.40.11, `qwen2.5:0.5b`). Oráculo `dep03-num-ctx`: pasa. Calibración: **2,33 caracteres por token** medidos, frente a los 4,0 de la guarda (la guarda subestima el p por un factor 1,7 con este estímulo numérico). Prompt en frío 12,64 ms/token, repetido 0,010 ms/token. Umbral propuesto para `RLLM_UMBRAL_MS_POR_TOKEN`: ≈ 1,7 ms/token (media geométrica entre el frío mínimo de 05 y DEP-03, ~10,2, y el cacheado máximo de 05, 0,28). La media de DEP-03 solo, 0,35, queda demasiado cerca del cacheado de 05. P-L: 76,6 s con 5.714 tokens en frío (pesimista 110 s). Desvío: el prompt quedó en 5.714 tokens y no en ~4.700, y se hizo una tercera llamada (la repetida) para calibrar el umbral.
- **DEP-09** (`dep09.log`): una entrada (e02 de 09) en dos peticiones. El pedido se guarda en el servidor y la segunda petición trae sólo el id y la decisión. Alta ejecutada = la que se mostró. `Garantias.AprobacionAlterada` se cumple. Oráculo `alta-con-aprobacion`: pasa. Clase H: 29,6 s y 25,2 s (pesimista 200 s por llamada).
- **DEP-13** (`dep13.log`, `../Sondas/dep13-p-por-pieza.tsv`): las dos llamadas se pensaron K, pero midieron p = 646 y 645. Son de clase **M** y el oráculo `dep13-clase-k` dio falla en las dos. Tiempos: 91,7 s y 123,1 s, dentro del pesimista M (135 s). La fórmula `p/9,4 + s/4` predice 87,5 s y 88,4 s; la segunda llamada fue un 39 % más lenta (carga ajena: 6,9 tok/s de prompt y 2,7 tok/s de salida). No se repitió con un prompt más corto. Para K se usan las llamadas reales ya registradas: con p ≤ 500, el máximo es 54 s (01), 33 s (04) y 31 s (03), pero 07 llega a 111,5 s y 17 a 207,8 s, por encima del pesimista K de 80 s. En H, 16 llega a 424 s, por encima de 200 s. Los pesimistas por clase no acotan la cola bajo carga, aunque los totales por pieza quedan muy por debajo de su pesimista.
- **03 ext.** (`ext-03.log`): 8/8 pasan el oráculo, IC95 [0,631; 1]. JSON válido 8/8; propuso habitantes sin el dato 0/4.
- **04 ext.** (`ext-04.log`): 7/8 válidas con normalización correcta, IC95 [0,473; 0,997].
- **08 ext.** (`ext-08.log`): herramienta invocada con argumentos válidos 4/4 legítimas; negativas sin invención 3/4; oráculo no-inventa 6/8; 0 «sin cifra» y 0 excluidas. **Las dos fallas son falsos positivos del oráculo**, no conducta del modelo. xl04 suma dos conteos de 1 y responde «2», que es correcto, pero el oráculo sólo admite cifras devueltas tal cual. xn03 se niega bien, pero repite el nombre de la sesión, «ejemplo-08-b», y el oráculo lee ese «08» como el conteo 8. Mientras no se corrija el oráculo, esas tasas no se citan.

## Reverificación tras el corte de sesión (2026-10-27, 15:56 -03)

Sin llamar a ningún modelo y sin repetir corridas válidas. Detalle en `reverificacion-p4.log`.

- `tools/recalcular-oraculos.sh` sobre `R-LLM/*.modelo-ext.jsonl`: «24 de 24 entradas coinciden», rc 0. Sobre todo `R-LLM/*.jsonl`: «365 de 365», rc 0. Sobre `Sondas/*.jsonl`, con los oráculos de `Sondas/oraculos/` junto a los de `tools/oraculos/`: «4 de 4», rc 0.
- `truncado_posible = true`: 0 en los seis registros (tres extensiones, tres sondas). El `entradas_hash` de cada extensión coincide con el SHA-256 de su `entradas.ext*.v1.json` y con `ejemplo.json` (03 `d8155a89…`, 04 `65dbc4f6…`, 08 `e80e56aa…`).
- AC-7 sobre `R-LLM`, `Sondas` y `P4-Corridas-Modelo`: 0 coincidencias en 57 registros, rc 0. AC-8: «0 coincidencias fuera de excepciones», rc 0.
- El medidor sigue en 9.153 s usados y **5.247 s** restantes de `<recurso-compartido>`: nada consumió el compartido después de 08 ext. El gestor (`turnos-gestor.p4.tsv`) y `turnos.jsonl` coinciden tramo por tramo.
- **DEP-13, clase K sin repetir la sonda.** Las llamadas K reales de las extensiones calibran la clase. 03 ext.: 8 llamadas, p 132–144, s 41–49, total de 23 a 27 s, con un máximo de 27 s por la fórmula. 04 ext.: 8 llamadas, p 103–110, s 24–34, total de 16 a 20 s, con un máximo de 20 s por la fórmula. Ninguna pasa el pesimista K de 80 s y la fórmula AJ-02 acierta sin carga. Las dos llamadas de la sonda quedan como medición de clase M. Desvío frente al plan: p sale de los registros reales, no de `--fake`, y la clase K sale de las extensiones, no de DEP-13. §E.5 no se recalcula en el plan porque no quedan corridas que presupuestar. Las cifras sirven de insumo para §14.6 y el Anexo E.
- En 08 ext., 2 de las 14 llamadas pasan los 80 s (máximo 86 s). Son de clase M (p 502–640) y quedan dentro de su pesimista.
