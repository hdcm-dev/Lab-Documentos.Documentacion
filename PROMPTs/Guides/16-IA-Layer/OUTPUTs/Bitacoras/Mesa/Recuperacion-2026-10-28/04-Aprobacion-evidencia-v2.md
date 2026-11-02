---
doc_id: BIT-16-REC-04-EVID-V2
doc_type: aprobacion-de-plan
title: Aprobación del plan de recuperación, vuelta 2 — juez de evidencia (mesa de recuperación, 2026-10-28)
status: APROBAR
origin: agent (juez de evidencia)
last_review: 2026-10-29
---

# Aprobación del plan de recuperación, vuelta 2: juez de evidencia

**Decisión: APROBAR.** Las diez mejoras que pedí en la vuelta 1 (`04-Aprobacion-evidencia.md`, M-1 a M-10) están en el §4 del plan como texto del paso, con su verificación mecánica, y la regla de precedencia (§4 manda sobre §0–§2) cubre las filas del §2 que no se reescribieron. No hay nada que escalar por REED-16 §12: nada toca una decisión del PO, la base sigue siendo la línea restaurada y el insumo sigue siendo de sólo lectura. Dejo cinco notas menores (§3) que no bloquean y se resuelven dentro de su bloque, anotándolas en `04-Aplicacion.md`.

## 1. Correspondencia de mis pedidos con la vuelta 2

| Pedido (v1) | Dónde quedó | Juicio |
|---|---|---|
| M-1 · variables sin defecto en los modos con modelo | **M-A** (§4.1) y fila 1.5 marcada [V2 M-A]: `${OLLAMA_SERVIDOR:?}`, `${RLLM_MAQUINA:?}`, `${RLLM_MAQUINA_PROPIO:?}` en `fase`, `extension`, `estabilidad`, `embeddings` y `demo.sh embeddings`. Sólo `build` y `--fake` aceptan `sin-servidor` con rótulo «guion». Verificación: rc ≠ 0 sin llamada HTTP, casos en `ArnesTests` por variable y modo. | Cumplido. Cubre el `RLLM_MAQUINA_PROPIO:-propio-local` que sigue en `tools/verificar.sh` l. 305 (lo confirmé con `grep`). |
| M-2 · digest y versión dentro del turno en la fase compartida | **M-K** (§4.2), paso nuevo 1.7b: `/api/version` y `/api/tags` dentro del turno, fila `servidor-compartido` en `turnos.jsonl`, variables esperadas sin defecto, `2a654d98e6fb` nunca equivalente. Prueba en seco con otro digest → rc ≠ 0. | Cumplido. El digest esperado `d8b0f5e9760c` coincide con el de las dos estaciones en `Inventario-entorno.md` l. 23–24. |
| M-3 · compuerta de intervalos con n/n, lista y positivo | **M-C** y fila 1.9 [V2 M-C]: n = lo que reconoce la compuerta, lista con línea y registro de origen en `04-Aplicacion.md`, cifra alterada → rc 1; «365/365» sólo en 2.3 (AC-3b). | Cumplido. Las cifras aproximadas de la fila (~16 y ~25) no comprometen nada, porque el criterio es el n medido. |
| M-4 · regla de estación | **M-D** (§4.1) y §4.3 punto 1: tasas y pareados enteros en una estación, reintento y partición en la misma, estimando con sha256 antes del primer pedido, caída = «no medido» sin completar en la otra; R-DG y R-E5 exentas y declaradas. Verificación con `jq`: un solo `servidor` por corrida. | Cumplido, con un punto más de lo que pedí (5: no completar en la otra estación). |
| M-5 · fracción mínima en R-15 y «no es validación» | **M-G** y §4.3 punto 5: fracción en `criterio-15.md` con sha256 antes del turno; §10.6 con `grep 'no es validación'` ≥ 1. | Cumplido. |
| M-6 · rama de caída de REC-13 | **M-E** y fila 8.1 [V2 M-E]: si no sale 10/10, REC-13 C y DEU-08 (§4.4), con efectos en §12.3, ADR-09, §14.1 y Anexo B, y `grep LimitadorDelModelo` = 0 si hubo caída. | Cumplido. |
| M-7 · rebuild completo y lector sin cuerpos | **M-I**: prueba de que ningún archivo nuevo en `RLLM_DIR` contiene el cuerpo, `compuerta-cabeceras.sh` rc 0, rebuild n/n y `ArnesTests` en 3.5. | Cumplido. |
| M-8 · plantilla del rótulo y compuerta de servidores retirados | **M-J**: pasos 6.0, 6.0b, 6.13 y compuerta en 10.16 y 12.3 sobre cinco patrones, con 0 apariciones sin rótulo y `diff` entre la forma de §0.4 y la de 12.1. | Cumplido, y más amplio que mi pedido (suma «Ollama propio» y «servidor compartido»). |
| M-9 · rótulo «existencia, otra composición» para el 6/10 y X2/D6 | **M-L** (§4.2) y criterio E2: rótulo obligatorio y preferencia por R-03/R-08 si miden lo mismo con la composición de la base. | Cumplido (ver nota 3.2). |
| M-10 · texto inyectado sintético y barrido | **M-H**: oráculo en `criterio-16.md`, preferencia por R-16, inyecciones citadas sintéticas y barrido = 0 en §11.2 y §11.7. | Cumplido. |

## 2. Qué re-verifiqué en esta vuelta (sin modelo)

| Verificación | Resultado |
|---|---|
| sha256 de la 0.10.1 | `ee1e6ae2…0a16f`: sin cambios desde la vuelta 1. Nadie tocó la guía entre vueltas. |
| Conteos que cita M-B y M-J (`grep` sobre la 0.10.1) | `tool_choice`: 7 líneas, en 1000, 1027, 1279, 1300, 2107, 3625 y 4666, que son justo las que lista M-B. `2a654d98e6fb`: 13. «servidor compartido»: 53 líneas (58 apariciones). «Ollama propio»: 28 líneas (30 apariciones). `0.32.0`: 17 líneas (18 apariciones; en la vuelta 1 yo escribí 18, porque contaba apariciones). `TOPE_LAN_S`: 0 en la guía (vive en `tools/`, y lo cubre el renombre de 1.5). |
| Versión y digests vigentes que usa el plan | 0.40.11 y `d8b0f5e9760c` en las dos estaciones (`Inventario-entorno.md` l. 23–24). |
| Origen de cada enmienda (columna «Origen» del §4) | Cada M-A…M-M remite a pedidos existentes en los cinco `04-Aprobacion-*.md`. Los míos están todos. |
| R-PRIV del plan v2 | 0 IPs del laboratorio, 0 rangos `100.x`, 0 nombres de equipos, 0 recursos del gestor, 0 rutas del home, 0 usuarios. Sólo aparece `127.0.0.1` (nota 3.1). |

### 2.1 Re-verificación independiente (2026-10-29, sin modelo)

Volví a correr las comprobaciones contra el estado actual. El plan no cambió después de esta aprobación: el plan es de las 21:09 y esta aprobación, de las 21:11.

| Verificación | Resultado |
|---|---|
| sha256 de la 0.10.1 | `ee1e6ae2…0a16f`, 5128 líneas: sin cambios. |
| `grep -c` sobre la 0.10.1 | `tool_choice` 7 (l. 1000, 1027, 1279, 1300, 2107, 3625, 4666), `2a654d98e6fb` 13, «servidor compartido» 53, «Ollama propio» 28, `0.32.0` 17, `TOPE_LAN_S` 0, `127.0.0.1` 2. Coinciden con M-B y M-J. «no es validación» y `LimitadorDelModelo` dan 0: es lo que se espera antes de aplicar M-G y M-E. |
| `tools/verificar.sh` l. 305 | Sigue `RLLM_MAQUINA="${RLLM_MAQUINA_PROPIO:-propio-local}"`. M-A lo cubre. |
| `Inventario-entorno.md` l. 23–24 | 0.40.11 y `qwen3.5:4b@d8b0f5e9760c` en las dos estaciones. Es lo que usa M-K. |
| R-PRIV del plan (`grep` de IPs, `100.x`, home, usuario, nombres de equipos y recursos, «clave de cabeceras por pedido») | Sólo `127.0.0.1` en la fila 9.11 (nota 3.1). |
| Árbol de la guía | 0 `bin/`, 0 `obj/`, 0 `*.db`. |

## 3. Notas menores (no bloquean; se anotan en `04-Aplicacion.md`)

1. **Loopback y el barrido ampliado (fila 9.11).** El plan escribe «publicar sólo a la interfaz del bridge o a 127.0.0.1», y la 0.10.1 ya trae 2 apariciones de `127.0.0.1`. No es una dirección del laboratorio, pero R-PRIV ampliado dice «cero IPs», y un barrido literal la va a marcar. En B-09 hay dos caminos: escribir «loopback» o `localhost`, o declarar `127.0.0.1` como excepción genérica del barrido, con la excepción escrita en el README de `Compuertas/`. Lo que no puede pasar es que el barrido dé rojo y se ignore sin dejarlo escrito.
2. **Fila 9.2 sin marca [V2].** Sigue rotulando el 6/10 del enum como «estación 1, 0.40.11, 2026-10-28». La precedencia del §4 (M-L) lo corrige, porque el rótulo final es «existencia, otra composición (modelo, vía)». Pero quien aplique B-09 tiene que leer M-L junto con la fila. Sugiero sumar «[V2 M-L]» al aplicarla.
3. **Forma de 6.0 frente a 12.1.** 6.0 pone `⟦REC-02:F4-servidores⟧` en el lugar de la versión. Es un marcador de tabla, no una versión. El `diff` que pide M-J compara formas, no valores. En B-12 la versión que reemplace a ese marcador tiene que ser la de `/api/version` registrada en el turno (M-K), no la de la tabla F.4 copiada a mano.
4. **Conteos de 6.13.** Sirven como referencia, pero la compuerta tiene que trabajar sobre líneas (`grep -n`) y clasificar cada línea, no comparar contra un número fijo. Así es como lo escribe M-J, y así queda.
5. **Redacción de §4.0 sobre las condiciones de voto.** El §4.0 dice que «evidencia y riesgo no pusieron condición de voto». No es exacto: mi vuelta 1 dice «con esos diez cambios lo apruebo sin otra vuelta», y riesgo dejó la misma fórmula, con una salvedad: que M-3 no cambie la ganadora de REC-13 por una causa distinta de la caída prevista. M-E sólo aplica la caída que estaba prevista, así que la salvedad no se activa y la conclusión de §4.0 («aprobado») se sostiene igual. Sugiero corregir la frase cuando se escriba `04-Aplicacion.md`, para que la procedencia de la aprobación quede bien.

## 4. Lo que apruebo

El plan de recuperación en su vuelta 2, con el §4 incluido, para aplicarlo desde B-00. Mis aprobaciones de la vuelta 1 (§3 de `04-Aprobacion-evidencia.md`) siguen en pie. Esta aprobación no vale para ninguna cifra: cada número que llegue a la guía va a salir de B-11, con su criterio previo, en una sola estación vigente, o va a quedar «no medido» o «historia».
