---
doc_id: BIT-16-C1-EVI-edicion-bibliografica
doc_type: evidencia
title: Evidencia del informe de edición de material bibliográfico (ciclo 1)
status: hecho
origin: agent
owner: especialista «Edición de material bibliográfico» (panel del ciclo 1)
last_review: 2026-10-28
traces: [BIT-16-C1-INF-edicion-bibliografica]
---

# Evidencia — edición de material bibliográfico (ciclo 1)

Corridas del 2026-10-28 en estación 1, con `python3 -I` y `grep`, desde `OUTPUTs/Bitacoras/`. Nada de esto toca el modelo ni la red.

| Archivo | Qué mide | Comando |
|---|---|---|
| `anclas.py` → `anclas-salida.txt` | Enlaces internos `(#…)` de cada registro contra los encabezados reales (slug estilo GitHub, sin bloques de código) | `python3 -I Mesa/Ciclo-1/evidencia-edicion-bibliografica/anclas.py Nucleos/*.md 0*.md README.md` |
| `fuentes.py` → `fuentes-salida.txt` | Tablas de fuentes (§7) de los nueve núcleos: prefijos, formato de id, fecha por tabla o por fila, ids repetidos entre núcleos, misma URL con ids distintos | `python3 -I Mesa/Ciclo-1/evidencia-edicion-bibliografica/fuentes.py Nucleos/*.md` |
| `formato-citas-salida.txt` | Fechas con guion no separable U+2011 frente a fechas ISO ASCII; estilo de cita (`` `F05` ``, `[F06]`, `(B19)`) por núcleo | `grep -o -P '\d{2,4}\x{2011}…'` y `grep -o -E` por estilo (ver cabecera del archivo) |
| `terminos-reemplazados-salida.txt` | Términos que BIT-16-04 reemplazó y que siguen en el **cuerpo** de cada núcleo (líneas anteriores a la primera nota `## 2026-10-28`) | `awk '/^## 2026-10-28/{exit} {print}' <núcleo> \| grep -c -E '<término>'` |

Limitaciones: `fuentes.py` reconoce filas cuyo id es letra + dígitos y toma la primera URL de la fila; la columna «sin versión ni fecha» es heurística (busca `ms.date`, números de versión, fechas o `commit`). En `terminos-reemplazados-salida.txt` no todo acierto es un defecto: `nomic-embed-text` en N3 es un catálogo de modelos y `OLLAMA_MODEL_NAME` en N6 puede quedar como diferencia; el informe sólo cita los aciertos que BIT-16-04 da por reemplazados.
