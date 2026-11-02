# E10 · F4 — Corrección ortotipográfica (2026-11-02)

## 1. Criterios
RAE/ASALE, *Ortografía* 2010, y DPD: comillas angulares de primer nivel y “inglesas” en el segundo; cursiva para los extranjerismos no adaptados; números (coma decimal, % con espacio); siglas sin -s de plural en la prosa española; meses en minúscula; puntos suspensivos. Barrido por script de la prosa (sin bloques de código ni `código`) del libro, del Conocimiento y de Examples/*/README.md.

## 2. Resultado del barrido
- % sin espacio, meses en mayúscula, «...» (tres puntos), comillas inglesas de primer nivel: 0.
- Siglas con -s: 5, todas dentro de títulos o citas en inglés (REF-…, l. 1857, 4403). Se dejan.
- Comillas rectas en prosa: 7. Son JSON o código literal (frontmatter l. 12, README de Examples, README 02), más los tres casos corregidos.
- Punto antes de «»»: 26, todos en cadenas literales (mensajes de las reglas, «No sé.», «Borrá Resistencia.»). La cadena se cita completa, así que se dejan.
- Separador de miles con punto en cifras de 4 dígitos (p. ej. 3.096 ms, 1.670): es el uso de la casa en todo el libro (incluido contar.sh). La *Ortografía* 2010 recomienda no separar los números de 4 cifras y usar un espacio fino a partir de 5. No se cambia porque afecta a cientos de cifras; queda como pendiente.

## 3. Cambios
1. Libro l. 1854: antes `«without becoming "agentic"»` → después `«without becoming “agentic”»` (comillas de segundo nivel).
2. Libro l. 4402: antes «(los patrones secuencial, concurrente, handoff, group chat y Magentic…» → después «…concurrente, *handoff*, *group chat* y Magentic…» (cursiva, como en l. 1702 y 1721).
3. Conocimiento l. 346: antes `en la jerga del proyecto, "cascarón")` → después `en la jerga del proyecto, «cascarón»)`. Es el pendiente 1 de F3. Se mantiene la forma del acta y sólo se cambia el tipo de comilla.
4. README 07 l. 77–79: antes `[0,590; 1,000]`, `[0,478; 1,000]`, `[0,000; 0,602]` → después `[0,590; 1]`, `[0,478; 1]`, `[0; 0,602]`. Unifica el formato con el libro y los otros README (pendiente 2 de F3).

sha256 del libro: `a1d2f567363f867282ed2cac0b71ef544150a81e599df21e860defca8cc9be03` (antes `8e208c61…`).

## 4. Compuertas (después)
| Compuerta | rc | Resultado |
|---|---|---|
| `tools/contar.sh` | 0 | 59.334/60.000 (sin variación) |
| `verificar-markdown.py guia <libro>` · ejemplos · arbol | 0 · 0 · 0 | — |
| `compuerta-referencias.sh` | 0 | 0 rotas en 21 archivos |
| `compuerta-intervalos.py <libro> Bitacoras/Evidencia/R-LLM` | 0 | 28/28; 21/21 |
| `compuerta-cabeceras.sh Bitacoras/Evidencia` | 0 | 0 en 2 cuerpos |
| `compuerta-rpriv.sh` libro, Examples, Conocimientos | 0 | 0 hallazgos |
| `mermaid.sh` / docs-guard | — | no corresponde: no se tocó ningún mermaid |

## 5. Pendientes (P2/P3)
1. Separador de miles en cifras de 4 dígitos (uso de la casa contra la *Ortografía* 2010). Si se cambia, tiene que ser una decisión de criterio y aplicarse en todo el libro; no se cambia en una fase.
2. Cursiva irregular de algunos anglicismos técnicos: *pipeline* aparece 4 veces en cursiva y 21 en redonda; *streaming*, 1 y 12; *embeddings*, 1 y 50; rollback y outbox, 0 y 1. Hay que definir una convención (cursiva en la definición o primera mención y redonda después, o léxico técnico siempre en redonda) y aplicarla de forma uniforme. F5 o la mesa B.
3. README 16 l. 24: `Borrar "Corrientes"` con comillas rectas dentro de «». Es la salida literal de ServidorDeAprobaciones, así que es evidencia y no se toca.

## 6. Mensajes ajenos
Ninguno.
