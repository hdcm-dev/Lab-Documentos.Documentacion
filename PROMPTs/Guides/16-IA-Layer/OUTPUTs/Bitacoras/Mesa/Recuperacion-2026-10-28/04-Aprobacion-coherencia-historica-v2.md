---
doc_id: BIT-16-REC-04-COH-V2
doc_type: aprobacion-de-plan
title: Aprobación del plan de recuperación, vuelta 2 · juez de coherencia histórica (2026-10-28)
status: APROBAR
origin: agent (jurado, coherencia histórica)
last_review: 2026-10-29
---

# Aprobación del plan, vuelta 2 · coherencia histórica

**Objeto.** La vuelta 2 de [`03-Plan-De-Recuperacion.md`](03-Plan-De-Recuperacion.md): el §4 y las filas marcadas «[V2 …]». La cotejé con mi aprobación de la vuelta 1 ([`04-Aprobacion-coherencia-historica.md`](04-Aprobacion-coherencia-historica.md), M-1…M-9 y tres menores), con mi boleta [`02-Voto-coherencia-historica.md`](02-Voto-coherencia-historica.md) y con la base. Hice dos chequeos sin modelo: el sha256 de la 0.10.1 en la ruta canónica (`ee1e6ae2…0a16f`, coincide con B-00 0.3) y la lectura de `Examples/_Comun/.../AI/GuardaDeTruncado.cs`. Re-verificados el 2026-10-29 sobre el plan vigente: sha256 igual, `CaracteresPorToken` estática y `Estimar` sin `ModelId`, 7 apariciones de `tool_choice`, 19 `ejemplo.json`, y la línea de versión de B-13 y el `status` sin cambios.

**Decisión: APROBAR.** Las nueve mejoras que pedí están incorporadas. Ninguna contradice lo que votó el jurado y ninguna introduce una opción nueva. Nada toca REED-16 §12, así que no hay nada que escalar. Las observaciones de abajo se aplican en el paso indicado y no hacen falta otra vuelta.

## Correspondencia de mis mejoras con la vuelta 2

| Mía (v1) | Vuelta 2 | Estado | Comentario |
|---|---|---|---|
| M-1 · variables sin defecto | M-A (B-01 1.5 reescrito) | cumplida | Rige en todos los modos con modelo, también en `demo.sh embeddings`. El defecto neutro queda sólo para `build` y `--fake`. M-K extiende la regla a la versión y los digests esperados. |
| M-2 · `tool_choice` | M-B (6.9 reescrito y paso 6.12) | cumplida | La redacción es la de la enmienda. Las menciones se alinean por bloque y la ficha de REF-51 no se toca. Ver la observación O-3. |
| M-3 · calibración por modelo | M-F (6.6 reescrito, prueba en `_Comun`, DEU-09) | cumplida | La frase y la verificación están, y la salida por deuda queda declarada. Ver la observación O-1, que anticipa el resultado. |
| M-4 · fracción mínima, juez de la misma familia | M-G | cumplida, con un faltante menor | Ver la observación O-2. |
| M-5 · existencia, oráculo, texto sintético | M-H, y M-L para el caso análogo | cumplida | |
| M-6 · caída a REC-13 C | M-E y DEU-08 | cumplida | Ajusta además ADR-09, §14.1 y el Anexo B. |
| M-7 · una sola estación | M-D | cumplida | Más fuerte que lo que pedí: reintento y partición en la misma estación, y «no medido» si la estación se cae. Las R-DG y R-E5 quedan exentas y se informan por estación. |
| M-8 · plantilla §0.4 y §0.3 por papel | M-J (6.0, 6.0b, 6.13 y compuerta 10.16/12.3) | cumplida | La compuerta de los cinco patrones con rótulo de historia es la verificación mecánica de mi condición 2. |
| M-9 · lector sin cuerpos | M-I | cumplida | |
| Menor · número de `ejemplo.json` | m-1 | cumplida | La lista sale de `grep -rl`: 19 archivos en la 0.10.1. |
| Menor · `status` | m-4 | cumplida a medias | Ver la observación O-4. |
| Menor · REC-35 | §0.3, B-03 | sin cambio | Sigue antes de B-11. Acepto la A, como ya dije. |

## Coherencia histórica de lo nuevo

- **M-K.** Separa bien la historia de la medición: el digest de la base (`2a654d98e6fb`) es otro artefacto y nunca se acepta como equivalente del vigente (`d8b0f5e9760c`). Esto es coherente con el `Inventario-entorno.md` y con mi voto en REC-15 B.
- **m-2.** Mantener el nombre de fase `lan` como nombre histórico del rol respeta las capturas fijadas por hash (REC-33). Es lo mismo que fundamentó mi voto en REC-07 C.
- **§4.3 punto 3.** La prioridad es garantías, después lecciones y por último existencia. Lo que no entra queda «no medido» y nunca se recorta N. Es la regla de la base de no inventar, aplicada al presupuesto.

## Observaciones (no bloquean; se aplican en el paso indicado)

- **O-1 · M-F, resultado previsible (B-03).** Hoy `GuardaDeTruncado` **no recibe el modelo**. `CaracteresPorToken` es una propiedad estática global, leída de `RLLM_CARACTERES_POR_TOKEN` con defecto 4.0, y `Estimar(mensajes, options)` no consulta `ChatOptions.ModelId`. La prueba de M-F va a dar rojo tal como está el código. Entonces hay dos caminos:
  - Corregir la pieza única. Por ejemplo, la calibración se resuelve por `options.ModelId` con una tabla por modelo, sin agregar el detector que lanza.
  - Abrir DEU-09.

  La fila 6.6 del §2 escribe la frase en afirmativo («estima con el modelo de la llamada»). Por la precedencia del §4 manda M-F: si se abrió DEU-09, la frase dice «no lo hace todavía». B-06 tiene que leer el resultado de B-03 en `04-Aplicacion.md` antes de escribirla.
- **O-2 · M-G (B-09 9.7).** Mi M-4 también pedía declarar que la base ya pedía un juez de **otra familia** (§14.6) y que eso sigue pendiente. M-G sólo dice «misma familia, el acuerdo no es validación». Hay que sumar en §10.6 o §14.6 una oración que remita a esa decisión de la base como pendiente. Así no parece que la base nunca lo planteó. La 0.10.1 ya lo dice en §14.6 (l. ~3979: «falta uno de otra familia»): basta remitir ahí desde §10.6.
- **O-3 · M-B (6.12).** La compuerta busca `tool_choice`. Las frases del tipo «`/v1` no admite …» que no nombran el término no aparecen en ese `grep`. Hay que sumar `grep -nE '/v1.{0,40}(no admite|no tiene|ignora|rechaza)' $DOC` a la lista anotada. Re-verificado el 2026-10-29: hoy ese patrón sólo encuentra la l. 1000, que también nombra `tool_choice`. La compuerta extra no agrega trabajo; cubre frases que la redacción de B-06…B-10 pudiera introducir.
- **O-4 · Estado del plan.** El encabezado dice «aprobado al incorporar §4» y el §4.0 declara el plan «aprobado» antes de que existan estas aprobaciones de la vuelta 2. Eso contradice m-4, que pide «votado; Vuelta 2 consolidada» hasta cerrar. Es la misma anticipación que señalé en la vuelta 1. Corresponde corregirlo cuando cierren las cinco `04-Aprobacion-*-v2.md`: recién entonces pasa a «aprobado; pendiente de aplicar», y a «aplicado» al cerrar B-15.
- **O-5 · B-13, línea de versión.** «re-mide lo observado en los dos servidores de laboratorio vigentes» tiene que admitir el caso «no medido» (M-D 5, §4.3 3). Propongo: «… re-mide en los dos servidores de laboratorio vigentes lo que la fase con modelo alcanzó; lo demás queda rotulado como historia o "no medido"».

## Mis tres condiciones de la boleta, en la vuelta 2

1. **Procedencia pieza por pieza y ninguna tasa del insumo como vigente.** Se cumple: §0.2.3, §3, M-H, M-L y M-M.
2. **Cifras de servidores retirados como historia, fechadas, y la columna «servidor» por rol.** Se cumple, ahora con compuerta mecánica: M-J, M-D y M-K.
3. **Bitácora sólo por agregado y R-PRIV limitado a REC-33.** Se cumple: §0.2.2 y m-2.

Desde la coherencia histórica, el plan queda **aprobado** para aplicar. O-1 a O-5 se anotan en `04-Aplicacion.md` cuando se ejecuta el paso que tocan.
