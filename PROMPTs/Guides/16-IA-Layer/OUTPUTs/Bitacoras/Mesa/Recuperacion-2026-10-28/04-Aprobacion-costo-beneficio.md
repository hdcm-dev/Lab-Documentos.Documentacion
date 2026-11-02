---
doc_id: BIT-16-REC-04-CB
doc_type: aprobacion
title: Aprobación del plan de recuperación — juez de costo-beneficio (mesa de recuperación, 2026-10-28)
status: MEJORAR_PLAN
origin: agent (jurado, costo-beneficio)
last_review: 2026-10-28
---

# Aprobación del plan de recuperación: costo-beneficio

**Qué reviso.** [`03-Plan-De-Recuperacion.md`](03-Plan-De-Recuperacion.md) frente a [`01-Matriz.md`](01-Matriz.md) y las cinco boletas `02-Voto-*.md`. Esta carpeta se escribe sólo con roles: «base», «insumo», «estación 1», «estación 2».

**Veredicto: MEJORAR_PLAN.** El plan es fiel al conteo. Los ganadores, los empates (ninguno), el veto (REC-06, que cae sobre B y coincide con la ganadora) y las perdedoras registradas coinciden con las boletas. Lo verifiqué ítem por ítem en los casos divididos: REC-07 C (3 a 2), REC-18 A (4 a 1), REC-21 C (4 a 1), REC-23 A (3 a 2) y REC-35 A (4 a 1). El orden de los bloques es el más barato posible. Integra sin modelo (B-01 a B-10), hace una sola fase con modelo (B-11), rellena las cifras con un marcador que tiene compuerta (B-12) y relee una sola vez sobre la guía final (B-14). Así, cada turno de modelo se paga una sola vez y nada se relee dos veces. También tiene la foto previa (B-00), el arranque condicionado al sha256 de la 0.10.1 y las deudas declaradas (DEU-01 a DEU-07), que acotan el costo sin perder contenido.

Hay **siete enmiendas** que el jurado dejó por escrito como condición y el plan no recoge, o recoge al revés. Todas son baratas: una línea o un paso cada una. Si no se aplican, el costo de B-11 y de la relectura sube mucho, porque habría que re-correr o defender cifras contaminadas. Por eso no apruebo sin ellas. Ninguna toca una decisión de REED-16 §12, así que no hay motivo para escalar.

---

## 1. Enmiendas obligatorias (antes de B-00)

| # | Paso del plan | Qué dice hoy | Qué tiene que decir | Quién lo pidió | Por qué es costo-beneficio |
|---|---|---|---|---|---|
| M-1 | B-01 1.5 (y 1.7, B-11 prep. 4) | `OLLAMA_SERVIDOR` y `RLLM_MAQUINA` «se leen del entorno **con defecto**» | **Sin valor por defecto en la fase con modelo**: si falta cualquiera de los dos, `verificar.sh fase …` y `demo.sh` (modos con modelo) abortan con rc ≠ 0. Para `--fake` y `build` se admite un defecto neutro (`sin-servidor`). Verificación nueva en 1.5: `verificar.sh fase lan` sin las variables → rc ≠ 0. | Evidencia (enmienda «obligatoria»), riesgo, AH-02 | Un defecto reproduce la contaminación «compartido». Una corrida mal rotulada se tira y se paga dos veces. La guarda es una línea. |
| M-2 | B-06 6.9 | `tool_choice`: «el cliente lo envía; **el servidor no lo honra** según [REF-51]» | «el cliente envía `tool_choice`; la documentación de `/v1` no lo lista [REF-51]; que el servidor lo cumpla no está medido». Además, hay que alinear las otras frases «/v1 no admite» / «sin tool_choice» de la 0.10.1 (el abogado del diablo cita l. 1000, 1027, 1279, 1300, 2107 y 3625; se ubican por texto con `grep -n`, como pide §0.2.6). | Abogado del diablo, coherencia, costo-beneficio, impacto | El texto actual afirma algo que nadie midió. La relectura lo marcaría y saldría un parche. Corregirlo acá cuesta una frase. |
| M-3 | B-08 8.1 (demo, REC-13) | prueba de 4 simultáneos «verde 10 veces seguidas», sin salida | Sumar la **caída a C**: si la prueba determinista con barrera no sale verde 10 de 10 dentro del bloque B-08, el limitador no se porta. §12.3 recomienda la entrada HTTP sólo como prosa, y la deuda queda declarada (DEU-08 nueva). | Costo-beneficio, impacto (condición de su voto A) | Una prueba que falla a veces cuesta más que la deuda, y le da al lector una señal falsa. |
| M-4 | B-06 6.6 / B-07 7.2 (REC-21 C) | fila del 4b y frase del tokenizador | Agregar a la frase sobre `GuardaDeTruncado` que **la calibración es por modelo** y que **la estimación se verifica con el modelo de la llamada** (el ejemplo es el 5.114 → 2.050 del 4b, con `⟦REC-02:DEP-03⟧`). Sin pieza nueva. | Coherencia (condición de su C), evidencia (condición para pasar a C) | Es la condición con la que la C sumó la mayoría. Cuesta una oración y evita reabrir el ítem en la relectura. |
| M-5 | B-11, R-15 (REC-18) | «advertencia de familia», sin piso de interpretables | El criterio previo de R-15 fija una **fracción mínima de evaluaciones interpretables** (la presidencia elige el valor antes del sha256). Si no se alcanza, el resultado es «no medido». La guía declara que el juez y el modelo evaluado son de la misma familia y no presenta el acuerdo como validación. | Evidencia | R-15 es la corrida más cara (unos 30 min en la estación 2). Sin el piso puede repetir el 0/52 y dejar una cifra vacía que después hay que defender. |
| M-6 | B-11, R-16 (REC-23) y B-09 9.8 | cita del «repitió el texto» del insumo, rotulada | El criterio previo de R-16 incluye el oráculo «la respuesta reproduce el texto inyectado». Si la re-corrida lo observa con la base, **esa** medición reemplaza la cita del insumo en §11.2/§11.7. Si no, queda la cita rotulada como existencia (A). El texto inyectado es sintético y pasa el barrido. | Coherencia y evidencia (minoría C ampliada), impacto (condición de su A), riesgo | El oráculo no agrega llamadas, porque se lee de las mismas 60. Es la diferencia entre trasladar un dato y medirlo. |
| M-7 | B-03 3.1 (REC-22) | portar el lector | Condición: el `DelegatingHandler` **no persiste cuerpos completos**. Registra sólo `prompt_eval_cached_count` y los campos de R-LLM, y lo que capture pasa por la compuerta «cabeceras=0» (1.10). Después de portar: rebuild completo y `ArnesTests`. | Riesgo (condición de su A) | `_Comun` lo comparten los 17 ejemplos. Una captura completa con credenciales en disco no se revierte después de un commit. |

## 2. Ajustes menores (se aplican sin otra vuelta del jurado)

1. **B-06, primer paso nuevo 6.0:** reescribir el rótulo modelo de §0.4 (l. ~163) con el formato «estación N, Ollama x.y.z, digest, fecha, estimando», con `⟦REC-02:…⟧` donde haga falta. Alinear también §0.3 (l. ~139) con los papeles EMB-A/EMB-B (impacto, notas 1 y REC-05). Es la plantilla que el resto de la guía imita, y ponerla primero ahorra correcciones sueltas en B-12.
2. **B-01 1.5:** el plan dice «los 17 `ejemplo.json`» y el voto de riesgo dice 12. La operación tiene que listar los archivos realmente afectados con `grep -l` antes del cambio y anotar la lista en `04-Aplicacion.md`. Así la verificación compara contra una lista y no contra un número.
3. **B-11, R-06:** reescribir la celda N («16 (oro v2 sin la nueva no respondible ≠ calibración)»), que hoy es ambigua. Debe quedar «N de evaluación = oro v2 completo; N de calibración = 10, disjunto del oro». Si no, el criterio previo hereda la ambigüedad y la corrida no se puede auditar.
4. **B-11, presupuesto:** antes del primer turno, sumar las llamadas previstas por estación. A ojo, la estación 2 pide unas 180 llamadas o más (R-07, R-08, R-11 a R-13, R-15, R-16, R-D3 y R-PD), es decir, dos o tres turnos de 45 min con el R-LLM-5. Ese total se anota en `04-Aplicacion.md`. Si supera el cupo, el orden de prioridad es: primero las corridas que sostienen garantías (R-PD con PD-6, R-D9, R-16, R-15), después las de lección (R-06, R-08), y al final las de existencia (R-13, R-17). Lo que no entra queda «no medido» y no se recorta N (como dice prep. 6).

## 3. Lo que apruebo tal cual

- **Orden B-00 a B-15** y sus dependencias. Es el que minimiza las re-corridas y las relecturas.
- **El lote R-PRIV (REC-06, REC-07 C, REC-33) completo antes de B-11.** Cuesta re-verificar con `--fake` y `ArnesTests`. Una fuga en un repo público no tiene costo acotado. El cambio del 2026-10-28 en el entorno convierte el nombre del recurso en un dato vigente.
- **REC-35 en B-03**, antes de B-11. Así `paquetes_hash` cambia una sola vez y la fase con modelo registra el definitivo, como pidieron evidencia e impacto.
- **Pruebas primero en REC-17 y REC-27**, y **verificar antes de construir en REC-14 (8.4)**. Sólo se paga el endurecimiento si falla la prueba.
- **REC-15 B y REC-19 A**: no se recalcula en masa ni se importa la tabla 2b/4b. Es el mayor ahorro del plan.
- **Marcador `⟦REC-02:<id>⟧` con compuerta `grep -c` = 0.** Separa la redacción de la medición sin que una cifra quede huérfana.
- **Deudas DEU-01 a DEU-07** tal como están, más la DEU-08 que agrega M-3.

## 4. Condición de cierre de esta aprobación

La presidencia aplica M-1 a M-7 y los cuatro ajustes de §2 sobre `03-Plan-De-Recuperacion.md`. La sección nueva es «§0.4 Enmiendas del juez de costo-beneficio», con referencia a este archivo. Con eso, el plan queda **aprobado** desde costo-beneficio sin otra votación: ninguna enmienda cambia una opción ganadora, todas son condiciones que el jurado ya dejó escritas o precisiones de verificación.
