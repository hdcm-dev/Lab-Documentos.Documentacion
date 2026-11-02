---
doc_id: BIT-16-C1-04-aprobacion-costo-beneficio
doc_type: aprobacion-de-parches
title: Aprobación del juez de costo-beneficio — ciclo 1, vuelta 1
status: entregado
origin: agent
owner: juez de costo-beneficio (REED-16 §9.6; M§5.5)
last_review: 2026-10-28
audience: [presidencia, aplicación, cuerpo-auditor]
traces: [Mesa/Ciclo-1/03-Parches.md, Mesa/Ciclo-1/02-Voto-costo-beneficio.md, Mesa/Ciclo-1/02-Revision-Homogeneidad.md, REED-16 §9.1, §9.6, §12, §13; M§5.5; BIT-16-00 R-PRIV, R-LLM; BIT-16-04]
---

# Aprobación del juez de costo-beneficio (ciclo 1, vuelta 1)

**Qué decido.** Por cada parche de 03-Parches: `APLICAR`, `MEJORAR_PLAN`, `NO_APLICAR` o `ESCALAR` (M§5.5), con el chequeo obligatorio de capa: ¿el parche corrige donde nació el defecto? Mido el costo como en mi voto de la ronda 1: texto, código a compilar y mantener, **tiempo de modelo en estación 1** (13–58 s por llamada del 4b, lectura del prompt a ~18–20 tok/s, turnos de 45 min, un hueco de concurrencia) y riesgo para el equipo de respaldo de contingencia. El beneficio es el daño que se evita.

**Rutas.** Relativas a `OUTPUTs/` (R-PRIV: sin rutas del home, direcciones, puertos, usuarios ni hostnames).

## 0. Verificaciones propias (E1, 2026-10-28)

| Qué | Resultado |
|---|---|
| Digest de `ollama/ollama:0.40.11` que cita P-10 | API de Docker Hub (`hub.docker.com/v2/repositories/ollama/ollama/tags/0.40.11`), consultada 2026-10-28T11:27-03:00: `sha256:dea72d1e…e322d8`, publicado 2026-10-24T17:09:46Z. **Coincide** con P-10. |
| N ≥ 96 de P-02 (ancho ≤ 0,2 con p≈0,5) | Ancho de Wilson 95 %: N=92 → 0,2002; N=93 → 0,1992; N=96 → 0,1962. El 96 sale de la aproximación normal y es **conservador** frente a Wilson (alcanza con 93). Está rotulado «criterio propio»: no lo corrijo. |
| Wilson del 2/10 de X2 D1 | [0,057; 0,51]. **Coincide** con P-02. |
| 2/10 (P-02) frente a 10/10 (P-35) en X2 D1 | No se contradicen: BIT-16-04 R-C02 dice que el 4b inventó el CP 10/10 («34000», «3400», «34089») y que sólo «3400» pasa `LocalidadRules`. 10/10 = inventó; 2/10 = inventó y pasó las reglas (sentido 1 de P-02). |
| Segunda ronda de C1-48, C1-38, C1-40/C1-62, C1-55/C1-56 | No hay archivo de segunda ronda en `Mesa/Ciclo-1/`. Los parches condicionados se aprueban con la regla del §1. |
| Núcleos alcanzados por P-34 | 9 registros en `Nucleos/` (N0b, N1, N1b, N2, N3, N3b, N4, N5, N6). Coincide. |

## 1. Regla para los parches condicionados

El cuerpo auditor diseñó las dos ramas de cada parche condicionado (03-Parches §0.3). Lo que falta es el voto, no el plan, así que `MEJORAR_PLAN` no corresponde. Tampoco `ESCALAR`: todavía no hubo dos rondas sin mayoría (REED-16 §12, fila 6).

Decido **`APLICAR` en dos tiempos**: la **parte común** se aplica en esta vuelta; la **rama** se aplica tal cual está diseñada apenas la segunda ronda dé mayoría ≥ 3 sobre la opción. Si la segunda ronda empata, eso sí es disparador de §12 tipo 6 y pasa a `Escaladas.md`. Mientras tanto, ninguna pieza de rama entra a `Demos/` ni a la redacción. Vale para P-05, P-13 (rama), P-17, P-22 (parte de la demo), P-23 y P-35.

## 2. Decisiones

| Parche | Decisión | Capa correcta | Fundamento (costo-beneficio) |
|---|---|---|---|
| P-01 | APLICAR | sí | Sigue siendo la mejor relación del ciclo: S1 irreversible apenas haya commit y el arreglo es mecánico (30 líneas, un script de 4 patrones con salida guardada). Corrijo mi voto de la ronda 1: con el número acotado, la redacción in situ de las rutas cuesta lo mismo que excluir del commit y no depende de que alguien se acuerde en cada commit. Prefiero la rama in situ; la rama de exclusión queda válida si la presidencia rechaza la excepción. Corrige en `Reanudar.md` y en los registros donde nació la fuga, y pone la compuerta en el pedido (REED-16 §9.1), que es donde faltaba. |
| P-02 | APLICAR | sí | Sólo texto, cero modelo. Nace en N0b (dos definiciones del mismo nombre) y se corrige ahí antes de propagarse a R-C20 y MI-24. El «no medido» evita gastar turnos en un umbral que 2/10 no sostiene. Es S1: la sección que deriva de N0b no se redacta antes de verificarlo (P-34). |
| P-03 | APLICAR | sí | Un snippet y una prueba con cliente falso lento; PC-02 también es con doble y cuesta minutos. Nace en N5 §4.2 y se corrige ahí. Deja votado qué pasa si PC-02 falla (pedido de 02-Revision-Homogeneidad §3.5) y mete la clave de caché con `SessionId`: las dos cosas evitan una escalada y una fuga entre sesiones sin costo extra. La rama A/B la elige el jurado de aprobación sólo si PC-02 falla, según el texto del parche. |
| P-04 | APLICAR | sí | Cinco tablas sobre la plantilla de N3b, con `grep` como compuerta. Son unas horas de texto, sin modelo. Si no se hace ahora, la redacción contextualiza sección por sección, y eso cuesta más. |
| P-05 | APLICAR (dos tiempos, §1) | sí | La tabla D1–D7 → ESC → CTX → afirmación E1 es texto y es justo lo que pidió evidencia para la segunda ronda de C1-48, así que va antes. La columna «en la demo» espera la mayoría. La regla «entra a la demo sólo si una afirmación E1 lo necesita» es el filtro más barato contra piezas que después se tiran. |
| P-06 | APLICAR | sí | Las 22 PR quedan sin hueco (7 aplicadas, 2 con ajuste, 10 a aplicar, 2 con ajuste, 1 descartada). Los destinos existen en P-07 y P-29. Para PR-22, la frase «si SK no tiene GA se omite y se registra» se resuelve con la compuerta de versiones de P-32 el día de publicar, sin consultar antes. |
| P-07 | APLICAR | sí | Decidir la estructura antes de redactar cuesta una tabla; reordenar una guía redactada cuesta semanas. El presupuesto total da 40 200 palabras, frente a 106 052 de insumo: comprime y el ±20 % no autoriza recortar evidencia. Las reglas «un término, una definición» y «cada snippet una vez» bajan el costo de la relectura de §10. |
| P-08 | APLICAR | sí | Es la variante barata que voté (tabla de destino + `grep` mecánico). No pide la hoja de vigencia por núcleo. |
| P-09 | APLICAR | sí | Un plan de 80 filas antes de redactar evita conciliar respuestas después; el choque N6 P6 con MI-14 ya existe y lo resuelve P-35. |
| P-10 | APLICAR | sí | Digest verificado (§0). Sin receta, el lector no corre nada de la guía. **Condición de costo**: la corrida de punta a punta con `pull` (~3,3 GB) y el clon limpio de `Examples/01` van **una sola vez**, en la compuerta final, cuando `Examples/01` exista; no se repiten por parche. Hoy se aplica el texto de la receta y la compuerta de REED-16 §9.1. Que el servidor de la receta se llame `ollama` dentro de la red `ia-guia` no es dato de infraestructura del PO: es la red del lector. |
| P-11 | APLICAR | sí | Snippet sobre un mecanismo con E1 (K8) y valores con fundamento medido (300 s = 1,8 × 168 s). Lo que falla sin él es inmediato: con 100 s por defecto, una sola llamada de 2943 tokens corta. La prueba de `num_ctx` (truncado con 4096) se corre con el modelo de humo, que es barato. |
| P-12 | APLICAR | sí | Texto sobre un patrón que la sonda S2 ya compiló y una prueba con cliente falso en las dos configuraciones. Toma la corrección de 02-Revision-Homogeneidad §3.4: «pierde la sesión sin error», no «mezcla sesiones», con PC-11 abierta. Sin D-11: conserva la numeración. |
| P-13 | APLICAR (parte firme ya; rama según P-35, §1) | sí | El ADR del estado de la conversación es texto y hace falta en cualquier perímetro. El contrato de aprobación entre peticiones (rama A) es lo caro, y sólo entra si P-35 sale A. La prueba de 404 entre sesiones es con doble. |
| P-14 | APLICAR | sí | Las API de streaming ya están verificadas (S3 de SENIOR); salida sin `MarkupString` es trivial; la vía móvil queda «no ejecutada» sin costo en este ciclo. La prueba de dos pestañas se corre con el medio web del laboratorio, sin emuladores. |
| P-15 | APLICAR | sí | Mover nodos y flechas y un caso de uso chico sin persistencia. Nace en N1/N4/N6 y se corrige ahí antes del diagrama integrado. |
| P-16 | APLICAR | sí | Texto con E1 de `git show` y tres pruebas de comportamiento heredado sin modelo. Corrige donde nació (corpus C4, N3, N6), sin tocar el caso base: lo que no cumple el código queda como deuda heredada, que es lo barato y verdadero. |
| P-17 | APLICAR (dos tiempos, §1) | sí | Responde la objeción de 02-Revision-Homogeneidad §3.2 con una carpeta concreta fuera del árbol copiado, así el `diff -r` = 0 sigue siendo comprobable. `dotnet build` de la copia sola es barato con el recurso `build`. La rama B queda diseñada y sólo cambia una frase. |
| P-18 | APLICAR | sí | Un puerto de lectura y una consulta, probados con SQLite en memoria. Si no, D4 no funciona (`GroupBy` sin traducir) y además expone campos personales. Daño alto, costo bajo. |
| P-19 | APLICAR | sí | Corrige texto con mediciones que ya existen (O3b, O5), en N3b y N5, que es donde nació el 93×. Cero modelo; PC-04 se responde leyendo el cliente. |
| P-20 | APLICAR | sí | La regla MI-18 y la prueba con cliente falso son baratas. **Condición de costo** para P-08 con `qwen3.5:4b`: `num_predict` mínimo (sólo interesa `prompt_eval_count`) y planificado en **un** turno. A ~19 tok/s, 3 corridas × (2050 + 3074 + 4098 tokens conservados) son ~24 min: entra en un turno de 45 min. Si no entra, se corre 4096 con N = 3 y el resto queda «no medido con el modelo de chat», con el 0.5b como evidencia del mecanismo. |
| P-21 | APLICAR | sí | Se recalcula desde los `.jsonl` que ya están, sin modelo. Corrige en el laboratorio (`Sondeo-Entorno`), donde nacieron las cifras mal derivadas. |
| P-22 | APLICAR (definiciones y oro ya; candidato en la demo según P-05, §1) | sí | Definiciones: texto. Oro y abstención con embeddings: deterministas con el digest fijo y baratos. Lo que se suma a la demo espera el perímetro, como dice el propio parche. |
| P-23 | APLICAR (dos tiempos, §1) | sí | La parte común (contexto fijo por defecto, sin conclusión comparativa hasta correr el oro) es gratis. Desde mi función prefiero la rama B (la comparación en `Examples/05`, pagada una vez), pero la elige la segunda ronda. Si sale A, la comparación pareada consume ~25–70 s por pregunta y por vía: se planifica en turnos y no en cada corrida de la demo. |
| P-24 | APLICAR | sí | La corrección más barata del ciclo: la guía dice menos y las garantías pasan a `Cableado/`, determinista. Resuelve el lugar de la vía C con la mayoría de 3 que 02-Revision-Homogeneidad §3.5 pedía cerrar. |
| P-25 | APLICAR | sí | Una plantilla y un `Inconclusive` visible. Evita el verde falso del CI sin `OLLAMA_ENDPOINT`, sin costo de modelo. |
| P-26 | APLICAR | sí | Dos líneas de snippet y una prueba de 0 ejecuciones con un doble; diff mínimo en `Examples/07`; LangGraph «no ejecutado» (no dispara AH-03 ni trae Python al entorno). Corrige en N4, donde nació, y deja en I-01 sólo una nota de una línea. |
| P-27 | APLICAR | sí | Los controles se prueban con dobles o configuración. La cota de 40 líneas propias y el pase de lo caro a la lista CTX-PROD con motivo es exactamente el corte de costo que pedía la tensión 6. M13 sigue al servidor MCP, con lo que deja de depender del perímetro. |
| P-28 | APLICAR | sí | Notas y tablas. La errata de citas (§5 por §6, §6 por §7) nació en REED-16 y se corrige ahí con nota. SUP-08 cierra con R3, que ya existe. |
| P-29 | APLICAR | sí | Compilar los snippets hay que hacerlo igual; la matriz cuesta poco. Observación S4 para la redacción, no bloqueante: la tabla salta de 10 a 12 (sin 11) y, si PR-22 se omite, también faltará la 12. Renumerar es gratis mientras `Examples/` no existe, pero hoy ya la citan P-06, P-30 y P-44; queda para la relectura integral (§10), con los cuatro parches a la vista. |
| P-30 | APLICAR | sí | Un test NUnit chico, sin modelo, con caso rojo. Descarta el `grep` con dos agujeros conocidos: no se enseña una herramienta rota. |
| P-31 | APLICAR | sí | Costo medio de texto, pero el catálogo y el glosario se necesitan igual. Unificar ids ahora es más barato que conciliarlos al cerrar. La definición de agente y workflow es una consulta al Experto IA, sin modelo. |
| P-32 | APLICAR | sí | `R2-deprec.py` ya existe. Sacar SqlServer del camino por defecto es más barato que mantener una excepción por los dos GHSA; la compuerta se corre una vez, el día de publicar. |
| P-33 | APLICAR | sí | Texto y una fila en N1b con la card ya leída. PC-05 se cierra con un cliente HTTP falso, sin modelo. |
| P-34 | APLICAR | sí | Es la versión liviana que voté, con la precisión de 02-Revision-Homogeneidad §2.3: bloquea sólo las secciones de N0b y N5 §4.2 mientras P-02 y P-03 no estén verificados. Nueve notas cortas. Corrige en REED-16 §6.2 y en los registros, que es donde está la regla. |
| P-35 | APLICAR (dos tiempos, §1) | sí | La parte común (toda escritura del modelo se confirma; M3 invariante en `Cableado/`; N6 P6 reescrito) es texto y una prueba con doble, y vale para las dos ramas. Desde mi función sigo prefiriendo la rama B (menos contrato, menos almacén, menos M13), pero la elige la segunda ronda con PC-13 cerrada (consulta E3 a AH-01, barata). |
| P-36 | APLICAR | sí | Rótulo «provisional» y criterio escrito antes de correr: gratis y verdadero. Que la comparación D1–D6 no bloquee publicar es lo que voté; ahorra varios turnos de estación 1. |
| P-37 | APLICAR | sí | Cambiar «no corre» por «no se midió» es gratis y verdadero. Levantar el Ollama propio en el equipo de respaldo sólo para dos pruebas, bajo demanda, con apagado registrado, acota el riesgo sobre el respaldo de contingencia. No es §12 fila 4: no se toca el servidor de IA del PO, se levanta un contenedor propio y reversible. Condición: ese turno lo autoriza la presidencia y no se superpone con un uso de contingencia del equipo. |
| P-38 | APLICAR | sí | La demo sin juez ahorra 10–20 casos × dos modelos × corrida con un IC de ±0,17–0,22, y la documentación oficial advierte desempeño pobre con modelos chicos. Enseñar el método con «no medido» no cuesta nada. |
| P-39 | APLICAR | sí | Un selector en la demo dejaría inaplicables M10 y MI-18 por `/v1`; en `Examples/01` y `06` se muestra lo mismo con menos superficie. |
| P-40 | APLICAR | sí | No investigar: MI-24 (a) ya está resuelta. Los eventos de etapa reusan el SSE de P-13 y se prueban con cliente falso. |
| P-41 | APLICAR | sí | Sin costo: confirma lo que ya está y evita un puerto que filtraría MEAI. |
| P-42 | APLICAR | sí | Una constante; sin ella, 0 spans (R6). El mejor beneficio por línea del lote. |
| P-43 | APLICAR | sí | Unas líneas al arrancar y una prueba con generador falso; evita el peor fallo, el silencioso. |
| P-44 | APLICAR | sí | Registra el `NO_PROCEDE` material (02-Revision-Homogeneidad §2.1). Conceptual hasta PC-14: no inventa dominio y saca `Examples/11`, que era una pieza más. |

## 3. Resumen

| Resultado | Parches |
|---|---|
| `APLICAR` | P-01…P-04, P-06…P-12, P-14…P-16, P-18…P-21, P-24…P-34, P-36…P-44 |
| `APLICAR` en dos tiempos (parte común ya; rama tras la segunda ronda) | P-05, P-13 (rama), P-17, P-22 (parte de la demo), P-23, P-35 |
| `MEJORAR_PLAN` | ninguno |
| `NO_APLICAR` | ninguno |
| `ESCALAR` | ninguno (sólo pasaría a §12 tipo 6 si la segunda ronda empata) |

**Capa.** Los 44 parches corrigen en la capa donde nació el defecto. Los que tocan el pedido (P-01, P-10, P-28, P-32, P-34) lo hacen porque la falla es del pedido (compuerta ausente o cita errada). Los de la guía, `Examples/` y `Demos/` son reglas vinculantes porque esas capas todavía no existen.

**Presupuesto de modelo de lo aprobado.** Consumen turnos de estación 1 sólo: P-10 (una corrida limpia, en la compuerta final), P-11 (truncado con el modelo de humo), P-20 (un turno, con la condición de arriba), P-22 (embeddings), P-23 rama A si gana, P-25 (registro R-LLM) y P-36 si sobra turno. P-37 usa el equipo de respaldo con autorización de la presidencia. Todo lo demás es texto, compilación o dobles. Pido que 05-Aplicacion registre los turnos reales de cada uno.

**Condiciones que acompañan la aprobación** (no son cambios de diseño):

1. P-10: corrida de punta a punta una sola vez, al existir `Examples/01`.
2. P-20: P-08 en un turno con `num_predict` mínimo; si no entra, 4096 con N = 3 y el resto «no medido».
3. P-37: turno en el equipo de respaldo autorizado por la presidencia y sin superponerse con un uso de contingencia.
4. P-29: la numeración de `Examples/` (sin 11, quizá sin 12) se revisa en la relectura integral.
