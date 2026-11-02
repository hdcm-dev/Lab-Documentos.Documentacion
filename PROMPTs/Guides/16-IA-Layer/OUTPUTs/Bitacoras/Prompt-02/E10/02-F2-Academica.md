# E10 · Fase 2 · Edición académica (intervención 2/6)

Fecha: 2026-11-02. Alcance: libro (0.12.0), Conocimiento, README de `Examples/`. Criterios: rigor de citas (toda cita resuelve a una referencia con URL y fecha de consulta), fidelidad de citas textuales, consistencia con la literatura, R-LLM (toda tasa k/M con IC95 Clopper-Pearson y estimando), definiciones consistentes.

## 1. Controles globales

| Control | Resultado |
|---|---|
| `[REF-n]` citadas vs definidas | 187 definidas; 0 citadas sin definir; 0 definidas sin cita en el cuerpo |
| Referencias sin URL / sin «consultado» | 0 / 0 |
| IC95 publicados (libro y README), recalculados con `scipy.stats.beta` | 11/11 correctos: 7/7 [0,590; 1], 5/5 [0,478; 1], 0/4 [0; 0,602], 1/12 [0,002; 0,385], 0/10 [0; 0,308], 0/6 [0; 0,459], 5/6 [0,359; 0,996], 8/10 [0,444; 0,975], 10/10 [0,692; 1] |
| Cálculos de §11.4 | 4/4 piso 0,398 (0,3976); 2·0,5⁶ = 0,031; 7 contra 1 p = 0,070 (2·9/256): correctos |
| Clopper-Pearson 0/30 (§ ensayo V1) | cota 11,6 % = 1−0,025^(1/30) = 0,1157: correcta |
| Literatura | REF-158 «más del 80 %» de acuerdo (MT-Bench): coincide; REF-209 10 % → 0,01 %: coincide; REF-67 cita textual hallada en el PDF de arXiv 2412.15605 |

## 2. Muestreo U-4.4 (semilla 20261102)

30 oraciones al azar de 548 con `[REF-n]` (42 pares oración–referencia, 31 URL distintas). Resultado: **30/30 anclas resolubles**; 31/31 URL responden 200 (2026-11-02). Citas textuales verificadas en la fuente: REF-67 («is stored on disk or in memory for future use»), REF-127 («trust boundary»); afirmaciones verificadas: REF-45 (reducción experimental), REF-46 (`RawRepresentationFactory`), REF-49, REF-51 (sección Authentication), REF-77 (64k), REF-09 (Python). Lista en el scratchpad de la sesión (`e10f2/muestra.tsv`).

## 3. Cambio aplicado

| Archivo | Antes | Después |
|---|---|---|
| `Examples/15-Pruebas-Y-Evaluacion/README.md` l. 32 | «8/10 es [0,44; 0,97]» (dos decimales, sin rótulo) | «8/10 da IC95 [0,444; 0,975] (Clopper-Pearson)», igual que el libro §11.6 y los README 04 y 08 |

Libro y Conocimiento sin cambios en bytes.

## 4. Compuertas (después del cambio)

| Compuerta | rc | Resultado |
|---|---|---|
| `tools/contar.sh` | 0 | 59.338/60.000; Anexos 12.998/13.000 |
| `verificar-markdown.py` guia · ejemplos · arbol | 0 · 0 · 0 | 18 README |
| `compuerta-referencias.sh` | 0 | 0 rotas en 21 archivos |
| `compuerta-intervalos.py <libro> Evidencia/R-LLM` | 0 | 28/28; 21/21 |
| `compuerta-cabeceras.sh Evidencia` | 0 | — (sin argumento de cuerpos da 2: uso, no hallazgo) |
| `compuerta-rpriv.sh` libro, Examples, Conocimientos | 0 | 0 hallazgos |
| `mermaid.sh` / docs-guard | — | no se repitió: libro y Conocimiento sin cambios desde la corrida verde |

## 5. Observaciones que exceden la fase (P2, para presidencia/E11)

1. L. 3149/3178 «cuatro de cada cinco» (24/30, conteo posterior no prefijado) va sin IC por decisión de E8 (`E8/Registro.md` l. 71). Por R-LLM sería IC95 [0,614; 0,923]; no se reabre. Si presidencia lo quiere, agregar sin superar el tope de la parte.
2. L. 1129 «5 de 5» (sondeo del entorno, rotulado «conducta, no tasa») no declara el estimando (una entrada o cinco). Falta el dato en la bitácora consultada; no se inventa.
3. REF-74 (`releases/latest`) hoy devuelve v0.40.13; el libro dice «era la última» con fecha, correcto. Señal de obsolescencia para el Anexo F (E11).
4. REF-188 tiene URL plantilla `{id}`; aceptable por «consulta por paquete».
5. Formato de IC: `[0,692; 1]` en 03/08/11/16 vs `[0,590; 1,000]` en 07: para F4 (ortotipografía).

## 6. Congelamiento de contenido

Constancia: con esta fase el contenido queda congelado para F3–F6 (C-4.3); un hallazgo de contenido vuelve a la fase 1.

## 7. Mensajes ajenos

Ninguno.
