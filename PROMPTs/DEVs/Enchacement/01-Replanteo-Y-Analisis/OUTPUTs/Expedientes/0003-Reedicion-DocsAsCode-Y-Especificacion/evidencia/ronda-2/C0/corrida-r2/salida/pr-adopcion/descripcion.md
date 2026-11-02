# Descripción del pull request de adopción — informe de línea de base (A-08)

Propuesta en borrador del aplicador. Línea de base medida con `scripts/ci-local.sh` y `tools/docs-guard/dg.py` del
repositorio leído (SHA: pendiente; huella del árbol `117ee288…3a62`), una corrida por control y por carpeta, antes de
activar cualquier bloqueo nuevo. La carpeta por defecto de la compuerta (cuerpo `SDEI`) no se pudo leer: su línea de
base queda pendiente. `tools/docs-guard/excepciones.txt` no cambia (una sola excepción vigente, `AGENTS.md` AI-3).

| Control | Carpeta | Resultado | Errores y avisos | Bloquea o avisa (tabla existente; lo heredado avisa) |
| --- | --- | --- | --- | --- |
| PR-1 fuera-del-repo | `Guides` | verde | errores=0 avisos=0 | según la tabla; línea de base 0 en esta carpeta |
| PR-1 fuera-del-repo | `Concepts` | verde | errores=0 avisos=0 | según la tabla; línea de base 0 en esta carpeta |
| PR-1 fuera-del-repo | `AGENTS.md` | verde | errores=0 avisos=0 | según la tabla; línea de base 0 en esta carpeta |
| PR-1 fuera-del-repo | `README.md` | verde | errores=0 avisos=0 | según la tabla; línea de base 0 en esta carpeta |
| PR-2 esquema | `Guides` | ROJO | errores=309 avisos=30 | avisa (línea de base ≠ 0) |
| PR-2 esquema | `Concepts` | ROJO | errores=16 avisos=0 | avisa (línea de base ≠ 0) |
| PR-2 esquema | `AGENTS.md` | verde | errores=0 avisos=0 | según la tabla; línea de base 0 en esta carpeta |
| PR-2 esquema | `README.md` | ROJO | errores=2 avisos=0 | avisa (línea de base ≠ 0) |
| PR-3 anti-inyeccion | `Guides` | ROJO | errores=824 avisos=100 | avisa (línea de base ≠ 0) |
| PR-3 anti-inyeccion | `Concepts` | ROJO | errores=108 avisos=0 | avisa (línea de base ≠ 0) |
| PR-3 anti-inyeccion | `AGENTS.md` | verde | errores=0 avisos=1 | según la tabla; línea de base 0 en esta carpeta |
| PR-3 anti-inyeccion | `README.md` | verde | errores=0 avisos=0 | según la tabla; línea de base 0 en esta carpeta |
| PR-4 mermaid-arroba | `Guides` | verde | errores=0 avisos=0 | según la tabla; línea de base 0 en esta carpeta |
| PR-4 mermaid-arroba | `Concepts` | verde | errores=0 avisos=0 | según la tabla; línea de base 0 en esta carpeta |
| PR-4 mermaid-arroba | `AGENTS.md` | verde | errores=0 avisos=0 | según la tabla; línea de base 0 en esta carpeta |
| PR-4 mermaid-arroba | `README.md` | verde | errores=0 avisos=0 | según la tabla; línea de base 0 en esta carpeta |
| PR-5 traces-resolve | `Guides` | ROJO | errores=1404 avisos=0 | avisa (línea de base ≠ 0) |
| PR-5 traces-resolve | `Concepts` | ROJO | errores=4 avisos=0 | avisa (línea de base ≠ 0) |
| PR-5 traces-resolve | `AGENTS.md` | ROJO | errores=6 avisos=0 | avisa (línea de base ≠ 0) |
| PR-5 traces-resolve | `README.md` | ROJO | errores=1 avisos=0 | avisa (línea de base ≠ 0) |
| PR-6 contratos | `Guides` | verde | errores=0 avisos=0 | según la tabla; línea de base 0 en esta carpeta |
| PR-6 contratos | `Concepts` | verde | errores=0 avisos=0 | según la tabla; línea de base 0 en esta carpeta |
| PR-6 contratos | `AGENTS.md` | verde | errores=0 avisos=0 | según la tabla; línea de base 0 en esta carpeta |
| PR-6 contratos | `README.md` | verde | errores=0 avisos=0 | según la tabla; línea de base 0 en esta carpeta |
| PR-7 fijadas | `Guides` | verde | errores=0 avisos=0 | según la tabla; línea de base 0 en esta carpeta |
| PR-7 fijadas | `Concepts` | verde | errores=0 avisos=0 | según la tabla; línea de base 0 en esta carpeta |
| PR-7 fijadas | `AGENTS.md` | verde | errores=0 avisos=0 | según la tabla; línea de base 0 en esta carpeta |
| PR-7 fijadas | `README.md` | verde | errores=0 avisos=0 | según la tabla; línea de base 0 en esta carpeta |
| PR-7 reflint | `Guides` | verde | errores=0 avisos=0 | avisa (heredado) |
| PR-7 reflint | `Concepts` | verde | errores=0 avisos=0 | avisa (heredado) |
| PR-7 reflint | `AGENTS.md` | verde | errores=0 avisos=0 | según la tabla; línea de base 0 en esta carpeta |
| PR-7 reflint | `README.md` | verde | errores=0 avisos=0 | según la tabla; línea de base 0 en esta carpeta |
| PR-7 url-fecha | `Guides` | verde | errores=0 avisos=854 | avisa (heredado) |
| PR-7 url-fecha | `Concepts` | verde | errores=0 avisos=93 | avisa (heredado) |
| PR-7 url-fecha | `AGENTS.md` | verde | errores=0 avisos=0 | según la tabla; línea de base 0 en esta carpeta |
| PR-7 url-fecha | `README.md` | verde | errores=0 avisos=0 | según la tabla; línea de base 0 en esta carpeta |

Saneamiento aparte (clase P, no entra en este PR): 56 IDs declarados más de una vez (606 hallazgos `id-duplicado` sobre
la raíz) y 18 prefijos en uso fuera del registro cerrado. PR-1 `enlaces` con lychee y PR-4 `estructura` no se midieron:
sus herramientas se descargan de la red y esta corrida fue sin red.
