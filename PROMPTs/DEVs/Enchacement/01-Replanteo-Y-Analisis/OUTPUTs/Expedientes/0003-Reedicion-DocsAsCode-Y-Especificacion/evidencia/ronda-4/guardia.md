# Ronda 4: registro de la guardia, resumen por corrida

Fuente: el registro único de la guardia PreToolUse (`insumos/guardia.py`, `F207` §2) de las ocho corridas, en
`{area-de-ensayo}/guardia-r4.log`, una línea por llamada de herramienta. Cada sesión se asignó a su corrida por las
rutas de sus propias llamadas. El registro completo no se publica: lleva rutas del área de ensayo y, en C2, contenido
privado. Lo que sigue es el recuento, hecho el 2026-11-02.

| Corrida | Llamadas | Permitidas | Bloqueadas | Bash por `./aislado` | Read | Write | Edit | Bloqueo: operador fuera del contenedor | Bloqueo: consola fuera de `./aislado` |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| C0-r1 | 57 | 55 | 2 | 44 | 0 | 1 | 10 | 2 | 0 |
| C0-r2 | 44 | 43 | 1 | 32 | 4 | 1 | 6 | 1 | 0 |
| C1-r1 | 113 | 111 | 2 | 70 | 13 | 22 | 6 | 2 | 0 |
| C1-r2 | 42 | 40 | 2 | 28 | 4 | 2 | 6 | 1 | 1 |
| C2-r1 | 32 | 30 | 2 | 26 | 3 | 1 | 0 | 1 | 1 |
| C2-r2 | 49 | 48 | 1 | 38 | 0 | 4 | 6 | 0 | 1 |
| C3a-r1 | 49 | 48 | 1 | 28 | 5 | 11 | 4 | 1 | 0 |
| C3a-r2 | 56 | 54 | 2 | 35 | 4 | 11 | 4 | 1 | 1 |
| **Total** | **442** | **429** | **13** | **301** | **33** | **53** | **42** | **9** | **4** |

- **Ninguna consola permitida fuera de `./aislado`**: las 301 llamadas Bash permitidas tienen motivo `aislado`.
- **Ninguna lectura o escritura permitida fuera de la corrida propia**: las 128 llamadas de archivo permitidas tienen
  motivo `archivo` (ruta dentro de la corrida, `coordinacion/` cerrada).
- **Los 13 bloqueos se rehicieron por `./aislado`** en la llamada siguiente o en dos llamadas separadas; ningún
  coordinador encontró un rodeo (auditorías en `{C0,C1,C3a}/corrida-r*/coordinacion/auditoria.md`; las de C2 son
  privadas).
- **0 demandas** en las ocho corridas.
- Diferencias con las cuentas de las auditorías: C0-r2 suma 45 llamadas en la transcripción y 44 en la guardia (la
  llamada 1, un Read sin `file_path`, falló por validación antes de la guardia). C0-r1: la auditoría reparte las 57
  como 48 Bash, 1 Write y 8 Edit; el registro da 44, 1 y 10. El total y los bloqueos coinciden; la diferencia de
  reparto no cambia ninguna conclusión.
- Algunas líneas del registro quedaron intercaladas por escrituras concurrentes de varias sesiones; el recuento se
  hizo por el encabezado de cada entrada (hora, sesión, herramienta, decisión, motivo) y da 442, igual a la suma de
  las transcripciones.
