---
doc_id: BIT-16-C1-04-coherencia-historica
doc_type: aprobacion-de-parches
title: Aprobación del juez de coherencia histórica — ciclo 1, vuelta 1
status: entregado
origin: agent
owner: juez de coherencia histórica (REED-16 §9.6; M§5.5)
last_review: 2026-10-28
audience: [presidencia, cuerpo-auditor, aplicación]
traces: [BIT-16-C1-03, BIT-16-C1-02-coherencia-historica, Mesa/Ciclo-1/02-Revision-Homogeneidad.md, BIT-16-00 (R-*, DC-01…DC-08, SUP-01…SUP-08), BIT-16-02, BIT-16-03, BIT-16-04 (tensiones 1–8, RA-*, R-C*, MI-*), Mesa/I-06, REED-16 §6.2, §9, §11, §12, §14]
---

# Aprobación de coherencia histórica (ciclo 1, vuelta 1)

**Qué juzgo.** Si aplicar cada parche rompe algo ya cerrado (DC, restricciones duras del contrato, I-06, marco de referencia de BIT-16-03, SUP y resoluciones de BIT-16-04), si las reaperturas que hace quedan registradas como tales y con su evidencia, y el chequeo obligatorio de M§5.5: **¿corrige en la capa donde nació el defecto?** No vuelvo a votar el fondo técnico: los ítems ya tienen veredicto del jurado (02-Voto-*) y la revisión por homogeneidad fijó qué parte es firme y qué parte va a segunda ronda.

**Regla para los parches condicionados** (P-05, P-13, P-17, P-22, P-23, P-27 en M13, P-35). El cuerpo auditor dejó las dos ramas escritas (03-Parches §0.3). Apruebo la parte común ahora y **las dos ramas como textos coherentes con lo cerrado**: la que salga de la segunda ronda se aplica sin otra vuelta. Si alguna rama rompiera algo cerrado lo digo en su fila; no pasó en ninguna.

**Escaladas.** Ningún parche dispara REED-16 §12. El único riesgo de fila 7 que había marcado en el voto (reemplazar `OLLAMA_ENDPOINT`, DC-06) no se materializa: P-11 conserva las tres variables de I-1.

## Resumen

| Decisión | Parches |
|---|---|
| APLICAR | P-01, P-02, P-03, P-04, P-05, P-06, P-07, P-08, P-09, P-10, P-11, P-12, P-13, P-14, P-15, P-16, P-17, P-18, P-19, P-20, P-21, P-22, P-23, P-24, P-25, P-26, P-29, P-30, P-31, P-32, P-33, P-34, P-35, P-36, P-37, P-38, P-39, P-40, P-41, P-42, P-43, P-44 |
| MEJORAR_PLAN | P-27, P-28 |
| NO_APLICAR | — |
| ESCALAR | — |

Capa: los 44 corrigen en la capa de origen. En P-28 la capa es la correcta (pedido) pero el alcance es corto.

## Decisiones

| Parche | Decisión | Capa correcta | Fundamento (coherencia histórica) |
|---|---|---|---|
| P-01 | APLICAR | sí | R-PRIV es restricción dura y le gana a la convención «sólo agregado» (mi voto C1-01). La fuga nació en `Reanudar.md` (que no es registro de bitácora: in situ) y en los registros que copiaron rutas absolutas (in situ con nota, sujeto al dictamen de la presidencia, con rama alternativa escrita). La compuerta incompleta nació en REED-16 §9.1 y se repara ahí. Cubre el pedido de la homogeneidad §3.6 (comando fijo, alcance con `Mesa/`, salida guardada). La reversión «lo redactado no se restaura» es la única coherente. Observación para la presidencia (no condiciona): la convención del 2026-10-28 del README que mete un hostname en el nombre del servidor es la raíz de C1-39; RV-01 lo resuelve para la guía, y en la bitácora es dictamen suyo. |
| P-02 | APLICAR | sí | Nace en N0b §3.1.3 y se corrige ahí antes de propagar a R-C20 y MI-24. Separa los tres sentidos sin borrar el de R-C20 (pasa a métrica de producto CTX-PROD, no medida): no contradice lo resuelto, lo desambigua. «No medido» y umbral diferido es lo que exige R-PO-6 y BIT-16-04 §1. |
| P-03 | APLICAR | sí | La parte S1 (cola acotada, 503, literal → `OLLAMA_MODEL`) aplica R-C11 y la tensión 6 sobre N5 §4.2, que es donde nació. La reapertura de R-C07 la votaron 4 de 5 y queda registrada como nota con su evidencia (SENIOR-01, E1); M8 neutral mientras tanto no afirma más de lo medido. La condición de riesgo (clave con `SessionId`) entró explícita, como pidió la homogeneidad §3.5. Como el parche deja la rama de fallo de PC-02 a este jurado, dejo mi elección escrita ahora: **rama A sólo si una prueba de `Cableado/` muestra que el `Counter` cuenta el acierto de caché** (así se conserva la propiedad que R-C07 aseguraba); sin esa prueba, rama B (R-C07). |
| P-04 | APLICAR | sí | Cumple R-PROF y BIT-16-03 («un núcleo que no se cruza con ningún escenario está mal delimitado»). El defecto nació en los núcleos y se repara en ellos, por nota fechada. |
| P-05 | APLICAR | sí | Completa lo que N6 l. 573 delegó y la integración no hizo. El mapeo ESC/CTX es firme; la columna «en la demo» sigue la segunda ronda. Las dos ramas respetan SUP-05 y DC-05 (web Blazor + API y réplica de la temática): la rama mínima recorta piezas de IA, no la topología. La regla «entra sólo si figura como E1» es compatible con el criterio de corte de la tensión 6. |
| P-06 | APLICAR | sí | Corrige la incoherencia de BIT-16-04 §5 con su propio criterio. Descartar PR-7 es coherente con RD-PO-1 (caso único) y con C1-27; I-02 no es vinculante y la mesa registra el motivo (R-AUTO). |
| P-07 | APLICAR | sí | Restituye lo que exige DC-01 (mapa conceptual, métodos y marcos y anexos dentro del único `.md`) y el orden de la tensión 1 (agentes después de recuperación). La vía C en la sección de agentes sigue la mayoría de 3 de C1-49. |
| P-08 | APLICAR | sí | R-PO-2 y la convención del 2026-10-28 (el servidor dado de baja es historia). RV-08 coincide con REED-16 §11 («la guía no referencia la bitácora»). |
| P-09 | APLICAR | sí | R-PO-3; corre después de las decisiones del ciclo, como pedí en el voto. N6 P6 se reescribe según P-35, que es lo que contradecía R-C02. |
| P-10 | APLICAR | sí | Coherente con DC-06 (el defecto de la demo sigue siendo `localhost:11434`; la red de Docker es la receta del lector) y con R-HOST (`sdk:10.0`). No nombra ningún anfitrión del laboratorio ni toca modelos ajenos. |
| P-11 | APLICAR | sí | Se cumple la condición de mi voto C1-11: `OLLAMA_ENDPOINT`, `OLLAMA_MODEL` y `OLLAMA_EMBEDDING_MODEL` se conservan (DC-06, R-C11, I-1); no hay segunda convención. `num_ctx` por configuración es R-C08. |
| P-12 | APLICAR | sí | Dentro de D-06 (C1-46 B, R-C20/PR-13 mantiene D-01…D-10). El título y el fundamento ya dicen «pierde la sesión sin error» y dejan el cruce como PC-11, como pidió la homogeneidad §3.4. |
| P-13 | APLICAR | sí | La parte firme (estado de la conversación) es consecuencia de R-C02 y E-B3, y un ADR nuevo no está prohibido. Las ramas A/B quedan atadas a P-35. Ajuste editorial no sustantivo para la aplicación: «D-07 bis» no sigue el esquema `D-nn` que P-31 conserva y D-07 es otro objeto (nivel de orquestación); conviene numerarlo D-11. |
| P-14 | APLICAR | sí | SUP-05, DC-05 y R-C19; la salida codificada aplica R-C03 (LLM05). Lo que se toma de `MovilidadUrbana.Web` queda declarado en PROCEDENCIA; la vía móvil «no ejecutada» es coherente con que en este ciclo no se usan teléfonos ni emuladores (MD-1/MD-2 en la fase de demo). |
| P-15 | APLICAR | sí | No contradice D-01 (c)/RA-2. La condición de mi voto C1-16 (la invariante de EA-3 se mantiene o se redefine explícitamente con MI-04) queda cumplida por P-30, que lo lista como derivado y define reglas para Presentación con herramientas y MCP. Completa R-C02 con el caso de uso «desde texto» (C1-18). |
| P-16 | APLICAR | sí | Cumple la condición de mi voto C1-17: corrige el enunciado en N6, N3 y el corpus (donde nació la sobreafirmación) y **no** toca las `*Policy`/`*Rules` copiadas; lo no verificado queda como deuda heredada. |
| P-17 | APLICAR | sí | La rama con mayoría pone la normalización en un archivo **fuera del árbol copiado**, invocada por el adaptador dentro de la función .NET antes del caso de uso. Eso resuelve la objeción de mi voto C1-38 (el `diff -r` = 0 sigue valiendo) y conserva R-C03 y la tensión 7. La rama B es mi voto original. Las dos son coherentes. |
| P-18 | APLICAR | sí | Concreta la tensión 3 sin contradecirla; el puerto vive en `Agregado/` y no toca `IEncuestaRepository` copiado; CTX-SENS de BIT-16-03. |
| P-19 | APLICAR | sí | Nace en N3b/N5 y se corrige ahí. La convención del 2026-10-28 impide citar cifras de otro modelo; «reuso parcial» matiza RA-9 (a) sin revertirlo. |
| P-20 | APLICAR | sí | Refina R-C08 con E1 nuevo y no lo revierte: la obligación de fijar `num_ctx` y comparar el largo queda (mi voto C1-22 y C1-66). |
| P-21 | APLICAR | sí | La cifra mal derivada nació en el sondeo (laboratorio) y se recalcula ahí desde los crudos; rótulo según RV-01 (sin hostname). |
| P-22 | APLICAR | sí | Da definición a lo que R-C16 decidió sin definir; corrige en N3, donde nació el «recall@k» que era hit@k. Cambiar el candidato de ESC-02 es coherente porque BIT-16-03 los declara candidatos. La parte de demo queda supeditada a P-05. |
| P-23 | APLICAR | sí | Las dos ramas mantienen RA-6 = R-C13 y C-9 (contexto fijo por defecto, RAG como variante); sólo cambia dónde vive la variante. La regla «no se suma pieza que el perímetro votado no tenga» es la de la homogeneidad §3.1. |
| P-24 | APLICAR | sí | Elimina la incoherencia interna con BIT-16-04 §1 (N chico no da cifras para citar) y funda «A por defecto» en diseño, como resolvió la tensión 1 (mi voto C1-43). |
| P-25 | APLICAR | sí | R-LLM es restricción dura; prohibir el verde silencioso aplica R-PO-7 y C-3 = R-C10. |
| P-26 | APLICAR | sí | La aprobación cableada en `true` contradecía R-C02 y E-B3; los reemplazos de dominio cumplen RD-PO-3 (C-12/R-C18); la equivalencia acotada es la de la tensión 5. La nota en I-01 es de una línea y I-01 no es vinculante. Corrige en N4, donde nacieron los fragmentos. |
| P-27 | MEJORAR_PLAN | sí | El criterio de corte es el de la tensión 6 con «pocas líneas» cuantificado: coherente. Pero la tensión 6 enumera **«pruebas adversariales»** en la lista CTX-PROD «sin implementar», y M14 las implementa en `Cableado/`. El parche reemplaza la tabla M1–M12 y no toca esa fila: quedan dos afirmaciones contradictorias en BIT-16-04 (chequeo C1 de REED-16 §9.1). Era la condición de mi voto C1-28/C1-59. |
| P-28 | MEJORAR_PLAN | sí | La capa es la correcta (el pedido), pero el corrimiento de anclas no está sólo en la fila C2. Contra el índice de BIT-16-02 (§4 vínculos, §5 tensiones, §6 trazabilidad, §7 estructura, §8 orden), REED-16 cita mal también: l. 242 y §9.1 C1 «tensiones de BIT-16-02 §4» (son §5); §9.2 y §14 «orden de BIT-16-02 §7» (es §8); §11 fila «Guía final» «estructura de BIT-16-02 §6» (es §7, y desde el ciclo 1 rige P-07). Arreglar sólo C2 deja al lector de §11 y §14 apuntando a la sección equivocada. |
| P-29 | APLICAR | sí | SUP-03, R-HOST y DC-07; R-PO-7 impide rotular «ejecutado» lo que no compiló en `Examples/`. Sacar la 11 es coherente con P-44. |
| P-30 | APLICAR | sí | Redefine de forma explícita la invariante de EA-3 junto con MI-04 (condición de mi voto C1-16/C1-52) y cierra el falso negativo del `grep` sin cambiar lo resuelto. |
| P-31 | APLICAR | sí | R-PO-2 y DC-01 (Anexo C dentro del único `.md`). Conserva ESC-, CTX-, ACT- y D-nn del marco fijado una vez (R-PROF); los ids internos no pasan a la guía. |
| P-32 | APLICAR | sí | Es la tensión 8 y R-EVID; chequear DC-08 por contenido no la reabre. La elección de SQLite como camino por defecto no contradice nada cerrado. |
| P-33 | APLICAR | sí | Coherente con la tensión 4 (razonamiento apagado) y RA-9 (c)/I-8; declarar el muestreo usado es R-LLM. Corrige en N1/N1b, donde nació. |
| P-34 | APLICAR | sí | Coincide con mi lectura de C1-36: no bloquea redactar lo aprobado; bloquea las secciones con S1 abierto, declarar validado un núcleo y el cierre (REED-16 §6.2 y §13). |
| P-35 | APLICAR | sí | La parte común (toda escritura que nace del modelo se confirma; ESC-03 nunca escribe; N6 P6 reescrito) es R-C02, 02 §5 y N0b PG-2/D-08. Las dos ramas mantienen ESC-04 como «acción propuesta que la persona confirma» (ACT-USR de BIT-16-03); si gana B, la aplicación registra en R-C02 que se reabre con PC-13 como evidencia (E3). No es DC: no escala. |
| P-36 | APLICAR | sí | Cumple C1-41 B: el 4b sigue por defecto (tensión 4) con rótulo provisional (R-PO-7). Que la comparación D1–D6 no bloquee publicar es aceptable porque el rótulo impide afirmar lo que no se comparó. |
| P-37 | APLICAR | sí | La causa «no medida» es R-PO-6; la vía es la mesa (R-AUTO, R-C09 ya lo había previsto) y no REED-16 §12 fila 4, que se refiere al servidor dado de baja. Corrige en el sondeo y en la integración, donde nació la frase. |
| P-38 | APLICAR | sí | Es la alternativa que adoptó el jurado (homogeneidad §3.3). Reabre R-C09 en el punto «juez en `tests/ConModelo/` de la demo», y la nota va justamente a R-C09; el protocolo queda como método enseñado e informado como k/n con intervalo, que es lo que yo pedía conservar. En la aplicación, la nota en R-C09 tiene que decir que reemplaza esa parte. |
| P-39 | APLICAR | sí | Mantiene R-C08 «cerrado para estación 1» en la demo; DC-06 (agnóstico) queda cumplido con los ejemplos 01 y 06 y la prueba de R-C14. |
| P-40 | APLICAR | sí | R-C20 lo dejó afuera por falta de fuente y ahora la hay; segundo plano en CTX-PROD es coherente con la tensión 6. |
| P-41 | APLICAR | sí | Es RA-3 con EA-5; no reabre nada. |
| P-42 | APLICAR | sí | Es R-C06 con X1 [A]; vale en cualquier orden del pipeline de P-03. |
| P-43 | APLICAR | sí | Es R-C12 (dimensión por configuración, validada al arrancar). |
| P-44 | APLICAR | sí | RD-PO-3 (vinculante): `Comentario` es dominio inventado. La variante con `Localidad.Nombre` queda supeditada a AH-01 y, si no, la explicación conceptual que prevé RD-PO-3. |

## Mejoras pedidas (vuelta 2)

### P-27

Agregar al texto exacto de la nota en la tensión 6 una línea así:

> En la lista CTX-PROD de la tensión 6, «pruebas adversariales» pasa a «pruebas adversariales más allá de M14 (corpus de ataques, tasa con N grande, otros canales de inyección)». M14 sale de esa lista porque pasa el criterio de corte con daño observado (X2 D6, baja sin confirmar 10/10) y costo bajo con cliente falso.

Y sumar a la verificación: `grep` de «pruebas adversariales» en la nota vigente de BIT-16-04 con el calificativo nuevo.

### P-28

Ampliar la nota de REED-16 a todas las anclas corridas, con una tabla de correspondencia, y ponerla en §9.1 con remisiones de una línea en §6.3, §9.2, §11 y §14:

| Dónde (REED-16) | Cita | Sección real de BIT-16-02 | Vigente desde el ciclo 1 |
|---|---|---|---|
| §6.3 (l. 242), §9.1 C1 | tensiones §4 | §5 | BIT-16-04 (tensiones 1–8) |
| §9.1 C2 | trazabilidad §5 | §6 | BIT-16-04 §8 (P-28) |
| §9.2, §14 punto 5 | orden §7 | §8 | sin cambio |
| §11 fila «Guía final» | estructura §6 | §7 | BIT-16-04 §8 (P-07) |

Verificación sumada: cada cita a «BIT-16-02 §» de REED-16 tiene su fila en la tabla.

## Observaciones para la presidencia (no son decisiones)

1. **Rama de fallo de PC-02 (P-03).** Dejé mi elección escrita arriba para que no vuelva como escalada de tipo 6.
2. **Reaperturas que este lote registra como notas**, todas de resoluciones de integración y con evidencia nueva: R-C07 (P-03), R-C04 (P-12), R-C08 en su enunciado (P-20), R-C09 en el juez de la demo (P-38), tensión 4 en el rótulo (P-36) y tensión 6 en la fila de pruebas adversariales (P-27, una vez mejorado). Ninguna toca una DC.
3. **Naming de D-07 bis (P-13):** ajuste editorial en la aplicación, no requiere otra vuelta.
