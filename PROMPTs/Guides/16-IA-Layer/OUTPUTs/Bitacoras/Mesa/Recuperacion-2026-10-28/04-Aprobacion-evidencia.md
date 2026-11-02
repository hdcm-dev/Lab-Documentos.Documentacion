---
doc_id: BIT-16-REC-04-EVID
doc_type: aprobacion-de-plan
title: Aprobación del plan de recuperación — juez de evidencia (mesa de recuperación, 2026-10-28)
status: MEJORAR_PLAN
origin: agent (juez de evidencia)
last_review: 2026-10-28
---

# Aprobación del plan de recuperación: juez de evidencia

**Decisión: MEJORAR_PLAN.** No hay nada que escalar por REED-16 §12. El plan respeta la decisión del PO: la base es la línea restaurada y el insumo se lee sin modificarlo. Los conteos del jurado están bien transcriptos. Pero hay tres puntos en los que el plan dejaría evidencia contaminada o una verificación que no puede dar verde con honestidad (M-1 a M-3). Además, seis condiciones que los votos dejaron por escrito no llegaron al plan (M-4 a M-9). Con esos diez cambios lo apruebo sin otra vuelta. Basta con que la presidencia los incorpore y lo anote en `04-Aplicacion.md`.

## 1. Qué verifiqué (sin modelo)

| Verificación | Resultado |
|---|---|
| Conteo de los cinco `02-Voto-*.md` frente a la tabla §0.3 | **Coincide.** REC-07: C gana 3 a 2 (coherencia, impacto y riesgo contra costo-beneficio y evidencia). REC-18: A 4/1 (coherencia votó C). REC-21: C 4/1 (evidencia votó A). REC-23: A 3/2 (coherencia y evidencia votaron C). REC-35: A 4/1 (coherencia votó B). REC-15: B 5/0. El resto, A 5/0. Hubo un solo veto, el de riesgo sobre REC-06 B, y coincide con la ganadora. |
| sha256 de `$DOC` (paso 0.3) | `ee1e6ae2…0a16f`: **coincide** con el plan. |
| Orígenes del insumo que cita el plan (1.9, 2.1, 2.6, 2.11, 3.1, B-04, B-05, 8.1, 8.2) | **Existen todos.** `intervalos.py`, `07-Dictamen-Presidencia.md`, `Sondeo-Entorno.md`, `Sondeo-Evidencia/2026-10-28/`, PC-06 (`Ronda-2/Consulta-operacion-telemetria.md`, turno de la estación 1), `LectorDePrefijoCacheado.cs` y `LecturaDelUsoTests.cs`, `CuerpoDelPedidoTests.cs`, `ProveedorTests.cs`, `CicloDeVidaDelClienteTests.cs`, `ConcurrenciaTests.cs`, `TrampasDeExecutorsTests.cs`, `AprobacionTests.cs`, `ConexionMcp.cs`, `ToolsListTests.cs`, `AgentesTests.cs`, `EvaluacionConJuezTests.cs`, `SalidaEstructuradaYEvaluacionTests.cs`, `CasosRojosTests.cs`, `ReglaDeCapas.cs` y `LimitadorDelModelo.cs`. |
| Herramientas de la base que cita el plan | `verificar.sh`, `recalcular-oraculos.sh`, `verificar-markdown.py`, `compuerta-ac7/ac8.sh` y `diff-dominio.sh` están en `tools/`. `demo.sh` y `diff-base.sh`, en `Demos/MovilidadUrbana.Asistente/tools/`. `contar.sh` falta, y el plan lo repone en 1.8. |
| Cifras de base que cita el plan | 443 pruebas (`06-Construccion.md` AC-2), 365/365 de AC-3b (`07-Redaccion.md` l. 203) y recarga de 10,5 a 16,1 s con N=5 en la estación 1 (PC-06): **tienen fuente.** Las 29 líneas «Observado» y las 13 menciones del digest viejo salen de `Inventario-entorno.md` y las reproduje (`grep`). |
| R-PRIV del propio plan | `grep` de IPs, `100.x`, nombres de equipos y recursos del gestor, rutas del home y usuario: **0.** |

## 2. Mejoras que pido

### Las que cambian la validez de la evidencia (bloqueantes para B-11)

- **M-1 · REC-07, enmienda de AH-02 (paso 1.5).** El plan dice «`OLLAMA_SERVIDOR` y `RLLM_MAQUINA` se leen del entorno **con defecto**». Lo dejé escrito como condición obligatoria en mi voto, y riesgo la hizo suya en el voto ganador C: en la fase con modelo esas dos variables van **sin valor por defecto**, y si faltan, la fase aborta. Si hubiera un defecto, una re-corrida podría quedar rotulada con un servidor que no es, sin aviso, que es justo la contaminación que motivó REC-07. `RLLM_MAQUINA_PROPIO:-propio-local` (verificar.sh l. 305) es la misma clase y va igual. **Verificación nueva:** `verificar.sh fase lan --fake` y `verificar.sh extension 03 --fake` sin esas variables tienen que dar rc ≠ 0 con un mensaje. `ArnesTests` tiene que tener un caso para cada una. El defecto queda permitido sólo en `build` y en `--fake` con el rótulo `guion`.
- **M-2 · REC-02, precondición mecánica del chat (B-01, paso nuevo 1.7b).** La fase «compartida» del arnés (`num_ctx_compartido`, verificar.sh l. 264–284) **no comprueba ni la versión ni el digest del modelo de chat**. Sólo la fase propia lo hace (l. 51–53 y 285–301). El paso 3 de la preparación de B-11 («digest del 4b `d8b0f5e9760c`; si no coincide, no medido») queda así como un control manual. `Inventario-entorno.md` muestra que el 4b de la base (`2a654d98e6fb`) es otro artefacto, así que este control es el que separa historia de medición. Pido llevarlo al arnés: comparar contra `/api/version` y `/api/tags` dentro del turno, escribir una fila `servidor-compartido` en `turnos.jsonl` y, si algo no coincide, devolver rc ≠ 0 y marcar «no medido». Verificación: en seco, con un `tags` guionado que trae otro digest, tiene que abortar.
- **M-3 · REC-19, verificación del paso 1.9.** «Sobre 0.10.1 = 365/365 coinciden» mezcla dos cosas. 365 es el agregado de AC-3b (entradas de `R-LLM/` frente a los oráculos, `07-Redaccion.md` l. 203), no la cantidad de cifras «k/m [IC]» de la guía. En la 0.10.1 conté 6 intervalos entre corchetes y unas 20 formas «k de M». Si se exige 365, la compuerta no puede dar verde con honestidad. Pido: (a) que la compuerta liste qué cifras reconoce en la 0.10.1, con su `n`, y que ese `n` se anote en `04-Aplicacion.md`; (b) que el criterio sea `n/n` coinciden; (c) un positivo de prueba, una copia de la guía con una cifra alterada que dé rc 1. El «365/365» de 2.3 sí es correcto, porque es AC-3b, y queda como está.

### Condiciones de los votos que no llegaron al plan

- **M-4 · REC-02, condiciones de AH-02 que suscribimos evidencia y riesgo (preparación de B-11).** El plan sólo dice «nunca se mezcla en una cifra sin la columna servidor». Pido escribir, como regla y no como ejemplo: cada tasa se mide **entera en una sola estación**; **ningún pareado cruza estaciones**; un reintento después de «no medido» corre en la misma estación, con criterio nuevo; y el estimando queda en el criterio previo, con su sha256, **antes del primer pedido**, no sólo antes del turno. R-DG y R-E5 corren en las dos estaciones y no son tasas, así que quedan exentas. Hay que declararlo.
- **M-5 · REC-18, corrida R-15.** Falta la **fracción mínima de interpretables** dentro de `criterio-15.md`; si no se alcanza, la corrida es «no medido» (el 0/52 de la base muestra que hace falta). Falta también la frase de que el acuerdo con un juez de la misma familia **no se presenta como validación**, en §10.6 (paso 9.7) y no sólo como «advertencia de familia».
- **M-6 · REC-13, paso 8.1.** Costo-beneficio e impacto votaron A con una condición: si la prueba de 4 simultáneos no sale determinista, se cae a C (prosa con la recomendación, sin limitador portado). Hoy el plan pide «verde 10 veces seguidas», pero no dice qué pasa si no sale. Hay que agregar la rama de caída y anotarla como deuda si se toma.
- **M-7 · REC-22, pasos 3.1 y 3.5 (condición de riesgo).** Después de portar el lector a `_Comun`, que comparten todos los ejemplos, se hace un rebuild completo (443/443 o el `n/n` declarado) y `ArnesTests`, no sólo el build de la copia. Además, el lector **no guarda cuerpos completos en disco**, sólo el conteo. Pido una prueba que lo verifique, porque si los guardara la compuerta de cabeceras (1.10) tendría material privado que barrer.
- **M-8 · Plantilla del rótulo, §0.4 l. 163 (nota 1 de impacto e `Inventario-entorno.md`).** La plantilla que el lector imita en toda la guía dice hoy `qwen3.5:4b` (digest `2a654d98e6fb`), «Ollama 0.32.0-rc0» y «servidor compartido, 2026-10-27». Ningún bloque la toca: B-06 empieza en §2. Pido un paso 6.0 que la reescriba con `⟦REC-02:digest-4b⟧` y el rol de estación. Pido además ampliar la compuerta de 12.3: no alcanza con contar «Observado». También hay que contar las 13 menciones de `2a654d98e6fb` y las 18 de `0.32.0`, y cada una tiene que quedar rotulada «historia» o reemplazada (`grep -n` con contexto, 0 sin rótulo).
- **M-9 · REC-29 y REC-20, pasos 9.2, 9.3 y 9.9 (criterio E2).** El 6/10 del enum se midió con el 0.5b. X2 y D6 vienen de otra composición del insumo. Recalcularlos con Clopper-Pearson está bien, pero el rótulo tiene que decir **«existencia, otra composición (modelo, vía)»** y no apoyar una tasa de la tarea de la guía. Si R-03 o R-08 los observan con la composición de la base, se prefiere esa cifra, como pidió impacto en REC-23.
- **M-10 · REC-23, paso 9.8 (condición de riesgo).** El texto inyectado que se cite en la guía es **sintético** y pasa el barrido ampliado antes de entrar.

## 3. Lo que apruebo tal como está

- El orden B-00 → B-15 y sus dependencias: integrar, medir y después releer.
- El marcador `⟦REC-02:…⟧` con su compuerta, que evita que se escriba una cifra antes de medirla.
- El criterio previo con sha256 y «caída = no medido» sin reintento silencioso.
- El registro de procedencia con sha256 de origen y destino.
- Las condicionales DEU-01, DEU-02 y DEU-03: primero la prueba, después el cambio.
- La copia previa fuera del árbol (B-00 0.1, T1 de riesgo).
- Que las capturas fijadas por hash no se toquen (2.3).
- El reparto de estaciones de la tabla de corridas: cada pieza va a una sola estación, cosa que M-4 sólo hace explícita.
