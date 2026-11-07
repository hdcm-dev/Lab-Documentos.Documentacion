# Constancia de parches — lote «local 07-Evaluacion-Y-Metricas.md»

| Campo | Valor |
| --- | --- |
| Tipo | constancia |
| Fecha | 2026-11-07 |
| Autor | cuerpo de parches (lote 06: doc 07) |
| Carta de mandato | evidencia/019-carta-cuerpo-de-parches.md |
| Folio fuente | despacho/r2-jurado-veredicto.md §2 |

## PA-08 — `07-Evaluacion-Y-Metricas.md` — APLICADO

Hallazgos que lo fundan: R2-ENT-08 (residuo de tubería en los `<summary>`) y R2-ENT-11 (errata
«Dá» en salida/entrada verificada; criterio R2-REF-07).

Qué se cambió, en una sola pasada sobre el documento:

1. **Dos `<summary>`** (antes líneas 522 y 688; tras el parche, 529 y 695): se quitó el
   paréntesis «(completa el verificador)», quedando `<summary>Protocolo de la corrida</summary>`
   en ambos. No se tocó ninguna línea del contenido de los `<details>` (las cifras y condiciones
   verificadas quedan byte a byte como estaban).
2. **Errata «Dá» de §3.1**: NO se editó el bloque `preguntas.jsonl` (es la entrada exacta de la
   corrida verificada del lab 07-B). Se asentó la errata como nota en blockquote inmediatamente
   después del bloque (líneas 397–402), con la grafía correcta («Da», imperativo monosílabo sin
   tilde) y la condición de recorrida: se corrige la próxima vez que el lab se recorra por otro
   motivo (criterio R2-REF-07). El lab no se recorrió, conforme a la dirección votada.

Verificación (comando del ancla):

- `grep -n "completa el verificador" 07-Evaluacion-Y-Metricas.md` → sin salida (antes: 2).
- `grep -c "<summary>Protocolo de la corrida</summary>" 07-Evaluacion-Y-Metricas.md` → 2.
- `grep -n "Errata asentada" 07-Evaluacion-Y-Metricas.md` → 1 aparición, junto al bloque de §3.1.

Salidas verificadas y marcas del verificador: intactas (el único texto quitado era el rótulo del
`<summary>`, fuera de cercas de código; el jsonl con la errata quedó sin tocar).

Parches devueltos: ninguno. Observaciones fuera de la dirección votada: ninguna.
