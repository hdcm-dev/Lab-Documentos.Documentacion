# C2, ronda 4 (brazo B): cifras de la métrica e

El oráculo es privado; aquí va sólo su huella, `4ba0816d7db3998e49041a40d74f7ab3ec42beff6fa5abd31a4b3bbe29cf2c43`.
*n* y umbral: heredadas 25 · 3; audiencia 16 · 2. Clase H: 5. Conocimiento 1.4.

| Medida | r1 (válida con observación) | r2 (válida con observación; lectura alternativa anulada, a juicio de la presidencia) |
| --- | --- | --- |
| M1 | 18/18, pasa | 18/18, pasa |
| M2 heredadas | 10 > 3, no pasa | 9 > 3, no pasa |
| M2 audiencia | 15 > 2, no pasa | 11 > 2, no pasa |
| M3 | 4/5 (la fila H de API sin default), no pasa | 5/5, 0 decididas: pasa |
| M4 | 0, pasa (7 citas con la línea desplazada) | 0, pasa (3 citas desplazadas) |
| M5 | 1, no pasa | 1, no pasa |
| M6 | verde con el rojo visto, pasa | verde con el rojo visto, pasa |
| Corrida | **no pasa** | **no pasa** |
| Demandas «sí» | 0 | 0 |

M7 (concordancia de juicio por fila entre r1 y r2): heredadas 20/25 (80 %), audiencia 12/16 (75 %), total 32/41 (78 %).

Frente a la ronda 3, con una sola corrida válida (6 · 12 · M3 4/5): las heredadas suben a 9–10, la audiencia queda en
11–15 y M3 pasa por primera vez, en r2. El veredicto no depende de las filas discutibles: con lectura indulgente, las
heredadas quedan en 9 y 7.

Defectos del conocimiento 1.4, genéricos:

- P0: K4-01, con el repo del código ausente la regla de audiencias deja todo «pendiente»; K4-02, la fila H de
  exposición de API admite el default «pendiente».
- P1: K4-03 a K4-09, sobre la adopción del registro de IDs del proyecto, las ubicaciones en el repo no recibido, la
  visibilidad tomada del índice, la prohibición de transcribir valores privados, las colisiones internas de IDs, los
  patrones de zonas, versiones y controles, y las preguntas de filtro único, punto de uso y homónimos.
- P2: K4-10, el criterio de la clase de conocimiento compartido.

Fuera del conocimiento: la autoprueba se dio por «sin red» aunque la imagen trae las herramientas; falta fijar el lugar
de los auxiliares; el autochequeo de citas no detecta desplazamientos de línea.
