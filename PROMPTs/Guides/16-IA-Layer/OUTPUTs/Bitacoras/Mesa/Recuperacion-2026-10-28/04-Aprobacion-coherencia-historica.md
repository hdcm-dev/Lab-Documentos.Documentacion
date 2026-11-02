---
doc_id: BIT-16-REC-04-COH
doc_type: aprobacion-de-plan
title: Aprobación del plan de recuperación · juez de coherencia histórica (2026-10-28)
status: MEJORAR_PLAN
origin: agent (jurado, coherencia histórica)
last_review: 2026-10-28
---

# Aprobación del plan · coherencia histórica

**Objeto.** [`03-Plan-De-Recuperacion.md`](03-Plan-De-Recuperacion.md), cotejado con [`01-Matriz.md`](01-Matriz.md), las cinco boletas `02-Voto-*.md` y los paneles que esas boletas citan como enmienda (abogado del diablo y AH-02).

**Decisión: MEJORAR_PLAN.** No hay nada que escalar por REED-16 §12. El plan respeta la decisión del PO: la base es la línea restaurada y el insumo es de sólo lectura (§0.2.1, §0.2.3, Procedencia). El orden integrar → medir → releer (B-01…B-14) es el mismo que la base ya seguía. Las cifras de los servidores retirados quedan como historia hasta B-12, con el marcador `⟦REC-02:…⟧`. El conteo de la tabla §0.3 coincide con las boletas: REC-07 C 3/2, REC-18 A 4/1, REC-21 C 4/1, REC-23 A 3/2, REC-35 A 4/1, el veto único sobre REC-06 B y ningún empate.

Aun así, el plan transcribe la **letra de la opción ganadora** de la matriz y deja afuera **enmiendas y condiciones** que la mayoría del jurado votó junto con esa opción. En tres casos el resultado contradice lo votado. Hay que corregirlo antes de aplicar.

## Mejoras obligatorias (contradicen lo votado)

| # | Ítem / paso | Qué dice el plan | Qué votó el jurado | Corrección |
|---|---|---|---|---|
| M-1 | REC-07, B-01 1.5 y B-11 prep. 4 | `OLLAMA_SERVIDOR` y `RLLM_MAQUINA` «se leen del entorno **con defecto**» | Evidencia lo puso como condición obligatoria («sin ella la evidencia de REC-02 queda contaminada»). Riesgo lo hizo suyo y AH-02 es quien lo propuso: en la fase con modelo van **sin valor por defecto** y, si faltan, la fase aborta. | 1.5: el defecto (neutro, nunca «compartido») vale sólo para `--fake` y `build`. En `fase`, `extension`, `estabilidad`, `embeddings` y `demo.sh` con modelo, si falta cualquiera de las dos el arnés aborta con rc ≠ 0. Verificación nueva en 1.5 o 1.7: `verificar.sh fase lan` sin `OLLAMA_SERVIDOR` → rc ≠ 0 con mensaje. En B-11 prep. 4: «sin defecto; aborta si falta». |
| M-2 | REC-10, B-06 6.9 | `tool_choice`: «el cliente lo envía; **el servidor no lo honra** según [REF-51]» | Coherencia histórica, costo-beneficio e impacto adoptaron la enmienda del abogado del diablo. La frase de la matriz afirma más de lo que dice REF-51 y más de lo que midió el insumo, que deja el cumplimiento como «no medido». | Redacción: «el cliente envía `tool_choice`; la documentación de `/v1` no lo lista [REF-51]; que el servidor lo cumpla no está medido». Sumar un paso que **alinee las demás menciones** de «/v1 no admite» o «sin tool_choice» (el abogado cita l. 1000, 1027, 1279, 1300, 2107 y 3625 de la 0.10.1), ubicadas por texto con `grep -n`, en B-06, B-07 y B-09 según la sección. |
| M-3 | REC-21 C, B-06 6.6 y B-07 7.2 | Fila del 4b y frase del tokenizador, «sin el detector que lanza» | La C ganó con dos condiciones: la de mi boleta y la de evidencia, que pasa de A a C «siempre que se le sume» lo mismo. Las dos piden **declarar que la calibración de caracteres por token es por modelo** y **verificar que `GuardaDeTruncado` estime con el modelo de la llamada**. Son precisiones de la guarda de la base, no una pieza nueva. | 6.6: agregar la frase de calibración por modelo. Agregar en B-04 o B-05, donde viva `GuardaDeTruncado`, una verificación sin modelo: la guarda usa la calibración del modelo configurado en la llamada y no una constante del 0.5b. Si no la usa, corregirla en esa pieza única, sin agregar un detector. R-D3 registra la estimación de la guarda junto al conteo real. |

## Mejoras de completitud (condiciones votadas que el plan omite)

| # | Ítem / paso | Condición omitida | Dónde va |
|---|---|---|---|
| M-4 | REC-18, B-11 R-15 | AH-02 y evidencia piden fijar en el criterio previo la **fracción mínima de interpretables**. Si no se alcanza, el resultado es «no medido», no «aprobado». El plan sólo dice «advertencia de familia». | B-11 prep. 1, para R-15, y §10.6 en B-12. Declarar además que el juez es de la misma familia y que el acuerdo no valida al juez (la base ya pedía otra familia, §14.6: queda pendiente y declarado). |
| M-5 | REC-23 A, B-11 R-16 y B-09 9.8 | Impacto pidió citar la observación del insumo **como existencia, no como tasa**, y preferir la medición vigente si R-16 la reproduce. Riesgo pidió que el texto inyectado citado sea **sintético** y pase el barrido. Coherencia y evidencia (minoría C) pidieron el oráculo «reproduce el texto inyectado» en el criterio previo. Eso es compatible con A y no tiene costo extra. | R-16: oráculo «reproduce el texto inyectado» declarado en el criterio. 9.8: rótulo «existencia, otra composición sin escritura, insumo» y reemplazo por la cifra de R-16 si aparece. Texto sintético. |
| M-6 | REC-13, B-08 8.1 | Costo-beneficio e impacto condicionaron A: si la prueba determinista no sale en un tiempo razonable, **cae a C**, porque prefieren eso antes que una prueba que falla a veces. | 8.1: rama explícita. Si no se logra «verde 10 veces seguidas» con barrera, se aplica REC-13 C, se anota en `04-Aplicacion.md` y se ajustan 9.12 y 10.3. |
| M-7 | REC-02, B-11 «Lectura» | Evidencia y riesgo, con AH-02: **cada tasa se mide entera en una sola estación**, ningún pareado cruza estaciones y el estimando se declara antes de la primera llamada. El plan sólo prohíbe mezclar «sin la columna servidor», que es más débil. | Reemplazar por: «Ninguna tasa ni pareado combina corridas de las dos estaciones. La columna "servidor" es obligatoria y no habilita la mezcla.» Las R-DG y R-E5, que corren en las dos estaciones, se informan por estación. |
| M-8 | REC-01, REC-05 e impacto, nota 1 | Impacto (y evidencia en REC-01) pidió reescribir **primero** el rótulo modelo de §0.4 (l. ~163 de la 0.10.1), que es la plantilla que el lector imita, y alinear §0.3 (l. ~139) con EMB-A/EMB-B por papel. B-06 no tiene esos pasos. | Paso 6.0 en B-06: §0.4, rótulo modelo con «estación N, Ollama x.y.z, digest, fecha, estimando» (`⟦REC-02:…⟧` donde falte la cifra). Paso 6.0b: §0.3 alineado con 7.3 y 10.9. |
| M-9 | REC-22, B-03 3.1 | Riesgo condicionó el portado: el lector **no guarda cuerpos completos en disco**, y se hace rebuild completo con ArnesTests. | 3.1, verificación: la prueba confirma que sólo se registra el conteo. 3.5: `verificar.sh build` n/n completo, más ArnesTests. |

## Observaciones menores (no bloquean)

- **B-01 1.5** dice «los 17 `ejemplo.json`», pero el panel de operación y la boleta de riesgo cuentan **12 más la demo** con el nombre del recurso. Hay que dejar que el mapa exacto decida y anotar el número real en `04-Aplicacion.md`.
- **Encabezado del plan.** `status: aprobado por el jurado` adelanta esta instancia. Debería decir «votado por el jurado; en aprobación» hasta que cierren las aprobaciones `04-Aprobacion-*.md`.
- **Historia de REC-35.** Mi boleta votó B (minoría). Acepto la A con la condición de evidencia, impacto y riesgo: un solo cambio de `paquetes_hash`, antes de B-11. El plan la cumple, porque 3.4 va en B-03, antes de la fase con modelo.

## Lo que el plan ya cumple de mis condiciones

1. Procedencia pieza por pieza, con DECI-30, y ninguna tasa del insumo como vigente sin re-corrida (§0.2.3, REC-15 B sin la tabla 2b/4b, REC-19 sin recalcular la guía en masa).
2. Cifras de servidores retirados rotuladas como historia, con fecha, y columna «servidor» por rol (§0.2.7, B-11 prep. 4, B-12 12.3).
3. Bitácora sólo por agregado y fechada, con las ediciones R-PRIV limitadas al dictamen REC-33 (§0.2.2, B-02 2.1 y 2.3).

Con M-1 a M-9 incorporados, el plan queda aprobado desde la coherencia histórica, sin otra vuelta del jurado: son condiciones que ya se votaron, no opciones nuevas.
