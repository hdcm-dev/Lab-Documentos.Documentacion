# Constancia de parches — lote 04: `11-Panorama-Y-Ecosistema-Abierto.md`

| Campo | Valor |
| --- | --- |
| Tipo | constancia de aplicación |
| Fecha | 2026-11-07 |
| Autor | cuerpo de parches (lote 04) |
| Documento intervenido | `Guides/IA/IA-Model/11-Panorama-Y-Ecosistema-Abierto.md` (único del lote; aplicado entero) |

Insumos: carta de mandato (evidencia 019), folio del jurado (`despacho/r2-jurado-veredicto.md`
§2, filas PA-03 y PA-10), informes `r2-fundamentos-panorama.md` (R2-FUN-08),
`r2-inferencia-rag.md` (R2-INF-05) y `r2-refutador.md` (R2-REF-01), y `Convenciones.md`
(§1.3, §2.1–§2.3, §6.1). Ningún parche toca salidas verificadas dentro de cercas de código ni
marcas del verificador: los tres cambios son prosa, una celda de tabla fuera de cerca y entradas
de Referencias.

## PA-03 — sección normativa de «destilación» en §1

- **Hallazgos que funda**: R2-FUN-02, R2-ENT-01, R2-SIS-01, R2-EDI-04 (dirección arbitrada por
  R2-REF-01: definir en 11 §1, no quitar la fila del glosario).
- **Qué cambió**: nueva subsección `### 1.8 Destilación: de dónde salen las variantes chicas del
  parque` (líneas 255–274), con el patrón de voz del propio §1 (definición / **Cómo se aplica** /
  **Un caso**), ~18 líneas: definición alineada con la fila del glosario de M1 §5.2, cita
  primaria (Hinton et al., 2015, la misma de M1 §7), lectura de las variantes «distill» del
  parque con las reglas de §1.1 y §1.3, y el caso real de las variantes destiladas de
  DeepSeek-R1 con su cita primaria (DeepSeek-AI, 2025, arXiv:2501.12948) — la cita al
  incorporarse que R2-REF-01 exige para ese sustento.
- **Referencias**: agregadas «DeepSeek-AI. (2025) … arXiv:2501.12948» (líneas 589–590) y
  «Hinton, G., Vinyals, O., y Dean, J. (2015) … arXiv:1503.02531» (líneas 596–597), en orden
  alfabético (M3 §2.1: lista completa por documento).
- **Ubicación**: se numeró 1.8 (tras §1.7) y no entre §1.5 y §1.6, para no renumerar §1.6, que
  todo el cuerpo cita como «la tabla de §1.6» (M3 §6.3); el índice del documento no cambia (sólo
  lista secciones de nivel 2).
- **Verificación (comando del ancla)**: `grep -ni 'destilaci' 11-Panorama-Y-Ecosistema-Abierto.md`
  pasó de sin salida (rc=1) a tres líneas (255, 257, 273); el reenvío de la fila del glosario ya
  no apunta al vacío. **El parche entró: la condición de R2-REF-01/PA-03 queda del lado «la fila
  permanece» — el aplicador de PA-02 no debe sacarla.**

## PA-10 — nota al pie de Gemma 4 E4B en §1.6 y frase de GPT-5.1 en §1.1

- **Hallazgos que funda**: R2-INF-05 (nota al pie) y R2-FUN-08 (frase sin fuente).
- **Qué cambió (R2-INF-05)**: marcador `[^gemma-e4b]` en la celda de parámetros de la fila
  `gemma4:e4b-it-qat` (línea 206) y nota al pie tras el párrafo de cierre de §1.6 (líneas
  220–224): concilia el total nominal del editor de §1.5 (8B) con lo que reporta el motor (7,5B,
  tamaño efectivo de los tensores cargados), declara la diferencia como esperable y la ata al
  contraste ficha/artefacto del laboratorio 11.A paso 4 — la redacción sigue la dirección textual
  del hallazgo.
- **Qué cambió (R2-FUN-08)**: en §1.1, «GPT-5.1, del mismo editor, falla la primera: sólo existe
  detrás de una API» → «Los modelos frontera del mismo editor fallan la primera: sólo existen
  detrás de una API» (líneas 63–64). De las dos opciones votadas se eligió la reformulación sin
  nombre de producto: no agrega a la capa volátil una afirmación de producto que exigiría fuente
  fechada y disparador de revisión propios.
- **Verificación (comandos del ancla)**: `grep -n 'GPT-5' *.md` → sin salida en todo el corpus
  (rc=1); `grep -n 'gemma-e4b' 11-…` → marcador y nota presentes (206, 220).

## Devueltos

Ninguno: ningún parche del lote toca salidas verificadas ni marcas del verificador.

## Observaciones (no aplicadas; exceden la dirección votada)

1. La nota al pie usa sintaxis GFM (`[^id]`), primera del corpus: si la mesa prefiere prohibirla
   o normarla, es una línea en M3 §1.3 — decisión editorial que no está en la dirección de PA-10.
2. El título de §1.8 queda fuera del relato «cuatro lecturas de la tabla» de §1.5; si una ronda
   futura renumera §1 por otro motivo, la posición natural de la destilación es entre §1.5 y
   §1.6. No se hizo acá para no romper las citas transversales a §1.6.

Sigue: verificación de los comandos de ancla por quien consolide la fase de parches · presidencia.
