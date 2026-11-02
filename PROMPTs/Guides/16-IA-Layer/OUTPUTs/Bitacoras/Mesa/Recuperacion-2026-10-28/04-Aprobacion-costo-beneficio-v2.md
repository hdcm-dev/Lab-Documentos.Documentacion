---
doc_id: BIT-16-REC-04-CB-V2
doc_type: aprobacion
title: Aprobación del plan de recuperación, vuelta 2 — juez de costo-beneficio (mesa de recuperación, 2026-10-28)
status: APROBAR
origin: agent (jurado, costo-beneficio)
last_review: 2026-10-29
---

# Aprobación del plan de recuperación, vuelta 2: costo-beneficio

**Qué reviso.** La vuelta 2 de [`03-Plan-De-Recuperacion.md`](03-Plan-De-Recuperacion.md): el §4 consolidado y las filas del §2 marcadas «[V2 …]». Lo comparo contra mi vuelta 1, [`04-Aprobacion-costo-beneficio.md`](04-Aprobacion-costo-beneficio.md), que pedía M-1 a M-7 y cuatro ajustes menores. Esta carpeta se escribe sólo con roles.

**Re-verificación del 2026-10-29.** Volví a leer el plan entero (sin cambios desde la vuelta 2) y cotejé contra la base las cifras con las que se dimensiona el trabajo:

| Dato del plan | Medido sobre la base | Resultado |
|---|---|---|
| sha256 de la 0.10.1 (B-00 0.3) | `ee1e6ae23001b7fb…` | coincide |
| `tool_choice`: 7 apariciones (M-B) | 7 | coincide |
| «Ollama propio» 28, «servidor compartido» 53, `2a654d98e6fb` 13, `0.32.0` 17 (M-J) | 28, 53, 13, 17 | coincide |
| `TOPE_LAN_S` en la guía | 0 (vive sólo en los scripts) | coherente con 1.5 |
| bin/ obj/ *.db en la guía | ninguno | limpio |
| barrido R-PRIV del plan (IPs, rangos, hosts, home, usuarios, recursos) | 0; sólo aparece el loopback genérico en 9.11, que no es dato del laboratorio y el barrido no lo marca | limpio |

**Veredicto: APROBAR.** Las siete enmiendas y los cuatro ajustes están en el texto de los pasos, no sólo en una nota. Lo que la vuelta 2 agregó por pedido de otros jueces tiene un costo acotado y no reordena los bloques. El orden integrar → una sola fase con modelo → rellenar → releer una vez sigue intacto. Nada toca REED-16 §12, así que no hay motivo para escalar.

## 1. Cotejo de mis condiciones de la vuelta 1

| Mía (v1) | En la v2 | Estado |
|---|---|---|
| M-1, variables sin defecto en los modos con modelo | M-A, fila 1.5 [V2 M-A], §4.3.2; se extiende con M-K (versión y digests esperados sin defecto) | cubierta y ampliada |
| M-2, `tool_choice` «no medido» y alineación de todas las menciones | M-B, fila 6.9 [V2 M-B], paso 6.12 con `grep -n`, alineación en B-09 y B-10 | cubierta |
| M-3, caída a REC-13 C si la prueba no da 10/10, más DEU-08 | M-E, fila 8.1 [V2 M-E], DEU-08 en §4.4 | cubierta |
| M-4, calibración por modelo y estimación con el modelo de la llamada | fila 6.6 [V2 M-F], más una prueba sin modelo en `_Comun` (M-F) con salida a DEU-09 | cubierta y ampliada |
| M-5, fracción mínima de interpretables en R-15 | M-G, con la compuerta `no es validación` en §10.6 | cubierta |
| M-6, oráculo «reproduce el texto inyectado» en R-16 | M-H | cubierta |
| M-7, el lector no persiste cuerpos; rebuild y `ArnesTests` | M-I, con una prueba explícita | cubierta |
| Ajuste 1, plantilla de §0.4 primero y §0.3 por papeles | M-J, pasos 6.0 y 6.0b | cubierto |
| Ajuste 2, `ejemplo.json` por `grep -l` | m-1, fila 1.5 (19 archivos, lista real anotada) | cubierto |
| Ajuste 3, celda N de R-06 | fila R-06 [V2]: oro v2 completo (17) y 10 de calibración disjuntos | cubierto |
| Ajuste 4, presupuesto y prioridad antes del primer turno | §4.3.3, con el orden garantías → lecciones → existencia y «nunca se recorta N» | cubierto |

## 2. Lo que agrega la vuelta 2 y cuánto cuesta

- **M-D, regla de estación única.** Cuesta cero llamadas. Evita la única forma cara de error que quedaba: un pareado que cruza estaciones y obliga a re-correr todo. Es la mejor relación de la vuelta.
- **M-K, precondición de digest en la fase compartida.** Son unas veinte líneas de `verificar.sh` y un caso en `ArnesTests`. Impide medir contra un artefacto distinto del rotulado. Aprobada.
- **M-J, paso 6.13 (111 menciones de servidores retirados, conteo confirmado).** Es la enmienda más laboriosa. Se acepta por tres razones: se reparte en B-06, B-07, B-09 y B-10, dentro de bloques que ya abren esas secciones; la ubicación la da el `grep` y la compuerta de 10.16 sólo exige el rótulo de historia, no reescribir cada párrafo; y sin ella la relectura de B-14 marcaría las mismas menciones una por una, que cuesta más.
- **M-F, prueba de `GuardaDeTruncado`.** Si falla, la salida está acotada: DEU-09 y la frase «no lo hace todavía». No puede alargar B-03 sin límite.
- **M-L y M-M.** Son rótulos y una remisión. No agregan llamadas: si R-03, R-05 o R-08 ya miden lo mismo, se usa esa cifra.

## 3. Observaciones (no bloquean; se anotan en `04-Aplicacion.md` al aplicar)

1. **§4.0, conteo de condiciones.** Dice que evidencia y riesgo «no pusieron condición de voto». No es exacto: evidencia aprueba «con esos diez cambios» y riesgo pone una salvedad sobre REC-13. La unión A–M cubre las dos y la caída de M-E es justamente la prevista, así que la conclusión se mantiene. Corregir la frase al aplicar, sin otra vuelta.
2. **M-G, valor de la fracción mínima.** La presidencia lo fija antes del sha256 de `criterio-15.md`; anotarlo junto al presupuesto de §4.3.3. Si R-15 queda «no medido», sus ≈ 30 min de la estación 2 se reasignan a la siguiente corrida de garantía y R-15 no se repite en el mismo turno.
3. **Una sola suma de presupuesto.** B-11 prep. 6 y §4.3.3 hablan del presupuesto; rige el §4, pero `04-Aplicacion.md` debe llevar una sola cifra por estación. Además, el ≈ 27 s por llamada viene de R-LLM-5, medido contra el servidor retirado: es estimación de planificación, y la primera corrida R-DG/R-E5 de cada estación la corrige antes de pedir el segundo turno.
4. **Digest esperado del 4b.** M-K lo fija en uno solo para las dos estaciones. Si R-DG muestra que la estación 2 sirve otro digest con la misma etiqueta, no es falla del plan: esa estación queda «no medido» hasta que la presidencia fije su propio `DIGEST_4B_ESPERADO`. Nunca se acepta el de la otra estación como equivalente.
5. **B-12 12.3, «29 menciones Observado».** En la 0.10.1 hay 38 líneas con «Observado» (no todas del servidor retirado). La compuerta «cero Observado sin rótulo de servidor» ya es por `grep`, así que el número es sólo orientativo: la lista real va a `04-Aplicacion.md`, como en m-1.

## 4. Condición de cierre

Ninguna. Desde costo-beneficio, el plan queda **aprobado** tal como está en la vuelta 2. Las observaciones del §3 se aplican dentro de sus bloques y se registran en `04-Aplicacion.md`. Los otros cuatro jueces de la vuelta 2 también votaron APROBAR.
