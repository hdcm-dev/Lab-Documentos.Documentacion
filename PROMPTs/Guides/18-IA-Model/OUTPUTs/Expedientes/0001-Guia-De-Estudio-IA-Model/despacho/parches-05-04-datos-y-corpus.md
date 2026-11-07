# Constancia de parches — lote 05 «local 04-Datos-Y-Corpus.md» (PA-07)

| Campo | Valor |
| --- | --- |
| Tipo | constancia |
| Fecha | 2026-11-07 |
| Autor | cuerpo de parches (lote 05) |
| Mandato | evidencia/019-carta-cuerpo-de-parches.md |
| Folio del jurado | despacho/r2-jurado-veredicto.md (R2-ENT-03 y R2-ENT-04 → PA-07) |

## PA-07 — `Guides/IA/IA-Model/04-Datos-Y-Corpus.md` — APLICADO

### Hallazgo R2-ENT-04 — `respuesta_esperada` de ev-03 (≈4,5 es Q4_0, no Q4_K_M)

- **Qué cambié**: en el heredoc de `mini-eval.jsonl` (§3.3), la `respuesta_esperada` de ev-03
  pasó de «Alrededor de 4,5 bits por peso.» a «Alrededor de 4,85 bits por peso.» (línea 413 del
  documento parcheado). Se eligió corregir la cifra, no la pregunta: 4,85 es la que afirma el
  documento dueño de la cuantización (08, líneas 159 y 548), y la pregunta sobre Q4_K_M conserva
  su valor didáctico.
- **Recorrida (criterio R2-REF-07: defecto de contenido se corrige y se recorre)**: recorrí los
  tres laboratorios en un entorno que coincide con el `entorno_validado` declarado
  (Python 3.11.2, CPU x86-64, CTX-01, sin red), con el heredoc corregido, el 2026-11-07:
  - Lab 1: `ejemplos válidos: 12 / errores: 0`; sobre `roto.jsonl`: `12 / 2` con los dos
    mensajes transcriptos — idéntico a lo publicado.
  - Lab 2: `12 de entrada / 10 únicos`, ds-005 y ds-006 duplican a ds-001 — idéntico.
  - Lab 3: `ds-001 ~ ds-007: Jaccard 0.68` y `ds-012 solapa con ev-01: Jaccard 1.00` — idéntico.
  - **El cruce de contaminación no cambia**: la única captura sigue siendo ds-012 ~ ev-01
    (1,00); el ev-03 corregido no produce ningún solapamiento nuevo (ev-03 no participa de las
    capturas esperadas, como pedía la dirección). Ninguna salida publicada quedó tocada.

### Hallazgo R2-ENT-03 — cifras propias de §3.1–§3.3 sin bloque «protocolo» (M3 §4, opción a)

- **Qué cambié**: agregué un bloque `<details><summary>Protocolo de la cifra</summary>…` por
  laboratorio, con la forma de M3 §4 y el estilo ya usado por los documentos 05 y 06 para
  corridas deterministas (campos no aplicables omitidos declarándolo):
  - §3.1 (líneas 306–316): cifra 12 válidos / 0 errores (y 12/2 sobre `roto.jsonl`), entrada,
    herramienta, semilla no aplica, CTX-01, fecha 2026-11-07.
  - §3.2 (líneas 377–387): cifra 12 de entrada / 10 únicos, ídem.
  - §3.3 (líneas 469–480): cifras Jaccard 0,68 y 1,00, parámetros (n=3, umbrales 0,5 y 0,35),
    entradas, ídem.
  Los campos llevan los valores de la recorrida de hoy; `grep -c '<summary>Protocolo'` sobre el
  documento devuelve ahora 3.

### No tocado

- Las cuatro salidas publicadas de los laboratorios (bloques «Salida esperada (corrida real,
  2026-11-07, Python 3.11.2)») quedan textualmente como estaban: la recorrida las reprodujo
  exactamente, así que no hubo nada que reescribir en salidas verificadas.
- Frontmatter (`entorno_validado`, `last_review`): sin cambio — la recorrida es del mismo día y
  el mismo entorno que los declarados.

### Observaciones (exceden la dirección votada; no aplicadas)

- Ninguna. El documento no contiene otras menciones de «4,5 bits» ni referencias a la cifra
  vieja fuera del heredoc corregido.
