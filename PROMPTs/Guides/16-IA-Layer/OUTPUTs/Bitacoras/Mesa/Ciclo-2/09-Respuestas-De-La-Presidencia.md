# Ciclo 2 · 09 — Respuestas de la presidencia y pedidos a dueños externos

> **Fecha**: 2026-10-26. **Origen**: el cierre del ciclo 2 (`08-Cierre.md`) dejó dos preguntas que el contrato alcanza para responder sin escalar al PO, y un pedido (PAR2-25) cuyo dueño está fuera del perímetro de la mesa. Estas respuestas son **insumo vinculante del ciclo 3**. El ciclo 3 puede objetarlas con evidencia E1 o E2, pero no las reabre por preferencia.

---

## 1. ¿La demo sola tiene que recorrer los cinco escenarios? (H2-055, §G.4 P-03)

**Respuesta: no.**

**Evidencia (E2).** El prompt del PO, §Solicitudes, párr. 1, pide «ejemplos, snipped de código, preguntas y respuestas explicativas. y una demo basada en lo que se menciona en el contexto `Lab-E2E.WebBlazor`», y §Objetivos pide «guías de estudios, ejemplos y demostración práctica». El pedido pone ejemplos y demo uno al lado del otro y no le exige a la demo cobertura total de escenarios. Los escenarios ESC-01…05 los fija el marco N0 para **toda la guía** (BIT-16-03 §1: «cada documento explica qué aporta el tema en cada escenario»), no para una pieza en particular.

**Consecuencia.** La cobertura de ESC-01…05 se comprueba sobre el conjunto guía + ejemplos + demo. La demo incluye sólo los escenarios que se integran de forma natural en `MovilidadUrbana.Asistente`. Un paso PD-n que sólo repite la lección de un ejemplo sin agregar integración (H2-054) puede salir de la demo si su escenario queda cubierto por el ejemplo hermano. Esto **habilita** el recorte de alcance que el ciclo 3 tiene que votar (H2-054, H2-056), pero no lo decide: la decisión es del jurado.

---

## 2. ¿PR-17 abre un escenario nuevo en el marco N0? (I-05 §5.2)

**Respuesta: no abre un escenario. Abre un par de contextos.**

**Evidencia (E2).** El marco N0 define (BIT-16-03 §2): «Un contexto es una **variante que cambia la respuesta correcta dentro de un mismo escenario**. Se definen en pares; cada par es un eje independiente de los otros». «Sumar la capa de IA a una aplicación existente» no es un «para qué» nuevo: el asistente, la búsqueda, la extracción, los agentes y MCP siguen siendo los mismos. Lo que cambia es la respuesta correcta dentro de cada uno, porque hay reglas, sesión, capas y contratos previos que respetar. Encaja en la definición de contexto, no en la de escenario (BIT-16-03 §1: «para qué se pone una capa de IA»).

**Consecuencia.** Se propone agregar al marco N0 el par **CTX-NUEVA / CTX-EXISTENTE** («aplicación nueva» frente a «aplicación existente con capas, reglas y sesión propias»). La demo y PR-17 viven en CTX-EXISTENTE × CTX-LOCAL × CTX-PROTO.

El cambio va en la capa de origen (`03-Marco-De-Referencia.md` §2 y la §2 de la guía). Como toca el vocabulario estable de la guía, el **ciclo 3 lo vota como parche**: la presidencia lo propone, no lo aplica.

---

## 3. Pedido PAR2-25 al gestor de recursos (DEP-14)

Enviado por la presidencia al dueño del gestor (`<gestor-de-turnos>/`) el 2026-10-26, con el texto completo de PAR2-25. Además del pedido de la mesa, se le encargó **montar el Ollama propio (EMB-B)**: en una segunda máquina del laboratorio y no en la de la corrida, porque esta está al límite de RAM según la medición del propio gestor; alcanzable sólo por la red privada del laboratorio; con `qwen3-embedding:0.6b` y el modelo chico de chat de TURNO-3; verificando que exista la etiqueta de imagen que cita el plan (`ollama/ollama:0.40.11`).

**Estado al lanzar el ciclo 3: pendiente.** El ciclo 3 no lo espera:
- Si el gestor lo cumple antes del cierre del ciclo 3, la presidencia registra el resultado del criterio verificable en `Ciclo-3/08-Cierre.md` y rige EMB-B.
- Si no, rige EMB-C según el propio plan (§F.6, AC-3b).

Las direcciones de red del Ollama propio **no se escriben en la bitácora** (R-PRIV); el plan usa la variable de entorno.
