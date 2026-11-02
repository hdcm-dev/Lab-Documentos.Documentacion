---
doc_id: BIT-16-MESA-C3-02-DID
doc_type: informe-de-especialista
title: Ciclo 3 · Informe de didáctica
version: v1
status: para la consolidación
origin: agent (especialista en didáctica, pedido del PO)
last_review: 2026-10-26
traces: [BIT-16-04 v2, BIT-16-MESA-C2-02-DID, BIT-16-MESA-C2-06, BIT-16-MESA-C2-08, BIT-16-MESA-C2-09, I-02 PR-3, M§8]
---

# Ciclo 3 · Didáctica

**Objeto**: `../../../04-Plan-De-Integracion.md`, ESTRUCTURA APROBADA v2. Las líneas citadas (l. n) son de ese archivo.
**Mandato**: RV-05 (OA y §15), criterio de dificultad B/I/A, RV-01 (casos integradores) y el recorte de la demo visto desde el aprendizaje («¿qué se pierde si un paso sale?»).
**A ciegas**: no leí ningún informe del ciclo 3. Leí `Ciclo-2/08-Cierre.md`, `Ciclo-2/09-Respuestas-De-La-Presidencia.md`, `Ciclo-2/06-Aprobacion.md`, mi informe del ciclo 2 (H-DID2-01…07, para no repetirlos) y las filas H2-036, H2-037, H2-039, H2-054 y RV-01 de la consolidación y los veredictos.
**DEP-14**: `<gestor-de-turnos> estado` (2026-10-26) no lista `[recurso-modelo-propio]`, y `PROTOCOLO.md` y `<gestor-de-turnos>` no lo nombran (0 ocurrencias). El pedido sigue pendiente: rige **EMB-C** (plan §E.5, TURNO-3; §F.6).

## 1. Posiciones sobre la agenda

### 1.1 Criterio de dificultad B/I/A: **enmendar**

El criterio del cuerpo auditor (l. 656) no reproduce la columna que dice justificar (H-DID3-01). Propongo que **el nivel sea el que PR-3 le da al tema** (I-02, tabla §4: básico = chat, streaming, salida estructurada, primera herramienta; intermedio = agente o herramientas sobre los casos de uso, con aprobación; avanzado = RAG operable con ingesta, citas, evaluación y observabilidad, más workflow o multiagente). Para los temas que PR-3 no nombra (05, 13, 14) se usa una regla residual: **I**, salvo que el ejemplo introduzca MAF o un juez LLM, y entonces **A**. Se saca el disparador «toca persistencia o sesión»: §0.3 (l. 380) da por sabidos EF Core con SQLite y la inyección de dependencias, así que no aumentan la dificultad *de IA* para el lector declarado. Con esta regla cambian dos celdas: **08 I → B** (PR-3: «primera herramienta») y **17 I → A** (PR-3: «observabilidad»). Quedan dos desvíos que se declaran en §D, fila PR-3 (c): **06 I** (PR-3 lo pone dentro de «RAG operable»; 06 aísla la recuperación, §7.5) y **11 A** (PR-3 lo pone en intermedio; 11 suma MAF y estado entre dos peticiones). Costo: dos celdas y ~50 palabras de §D, que no llegan a la guía.

### 1.2 RV-05 (OA y §15): **(a) 26 OA**, con una enmienda condicional

Fundirlo en (b) deja un OA-S2 con cuatro decisiones («qué herramientas piden aprobación, cuáles no se montan…, qué datos llegan a qué modelo y dónde se filtra por permiso», l. 130). Un solo ítem de §15 no puede observar cuatro conductas, y el ítem «sigue al verbo» (H2-037, l. 526) sólo funciona si el OA tiene uno. El ahorro de (b) es un ítem (~90 palabras, E3). **Enmienda**: si se aprueba CTX-EXISTENTE (§1.6), se agrega **OA-A6**: «Dado un cambio de la capa de IA sobre una aplicación existente de Movilidad Urbana, clasificar cada pieza tocada en agregado, modificado a causa de la IA o modificado por otro motivo, y decir qué regla del caso base conserva» (§14.1, §14.4; demo, tabla de delta). Hoy §14 entero no figura en ningún OA (H-DID3-02). Con la enmienda quedan 27 OA.

### 1.3 RV-01 (casos integradores): **(c) tres casos**, con (b) como repliegue

Los 26 ítems son uno por OA y atómicos. Ninguno evalúa la **composición** que enseña la tesis (subir por dos escaleras con un criterio de salto, l. 48) ni la demo (§14, sin OA). Propongo tres casos integradores, cada uno con al menos dos OA de escaleras o actores distintos y sin OA nuevo (cumple el criterio de inclusión, sentido 1): (1) ESC-03, alta desde texto de punta a punta: OA-D2 + OA-A5 + OA-D5; (2) ESC-02, ayuda: OA-D3 + OA-D4 + OA-S3, donde se elige el escalón y dónde se filtra por permiso; (3) CTX-EXISTENTE, sumar la capa al caso base: OA-0.2 + OA-A1 (+ OA-A6 si se aprueba). Costo: ~300 palabras. **Entra en el tope del Cierre** (≤ 3.000, l. 370) si los ítems promedian ≤ 100 palabras: 26 × 100 + 300 = 2.900 (E3, estimado; `tools/contar.sh` lo confirma en la relectura S-14). Si no entra, se pasa a (b) y se mantiene sólo el caso 3. Dato para RV-04: hoy las fichas de §C suman **51** preguntas guía (2+3+5+5+5+4+5+5+5+5+3+1+3, §2–§14, l. 403–521), no las 58 que menciona la pregunta abierta de l. 370.

### 1.4 Recorte de la demo (H2-054, habilitado por la respuesta 1 de la presidencia): **sacar PD-2, PD-4 y PD-7**; PD-2 se reemplaza por una ayuda en el escalón 0

Para cada paso me pregunté qué **composición en un host** aporta que su ejemplo hermano no tenga (respuesta 1: un paso sale si «sólo repite la lección de un ejemplo sin agregar integración»):

| Paso | Qué aporta que el hermano no tiene | Qué se pierde si sale | Posición |
|---|---|---|---|
| PD-1 | El puente cookie → `SessionContext` en el circuito Blazor y las herramientas por circuito (§F.5, ADR-12); PR-20 (e): la demo empieza por la lectura | La sesión del circuito, que ningún ejemplo ejercita (08 es una consola) | **Queda** |
| PD-2 | `IAyuda` con almacén e ingesta dentro del host | Ver un RAG cableado con DI en una app real; ADR-05 remite a 07 | **Sale o se reemplaza** (H-DID3-04) |
| PD-3 | El puerto propio `IExtractorDeLocalidad` y `AltaDesdeTextoService`: es la única pieza de OA-A5 (l. 117) y la secuencia de §A.4 | OA-A5 se queda sin ejemplo | **Queda** |
| PD-4 | El mismo patrón que PD-3 sobre otro agregado | Una segunda instancia (transferencia) y parte de la tensión T6, que ya aparece con `Habitantes` | **Sale**. Además saca de la demo una pieza que depende de P-12 (entradas sintéticas con edad, distancia y minutos) |
| PD-5 | El mismo caso de uso de alta alcanzado desde el escalón 0 (PD-3) y desde el 1 (herramienta con aprobación) en la misma app | El contraste de escalones sobre una misma regla, que es la tesis hecha visible | **Queda** |
| PD-6 | Lo destructivo (§A.4 punto 4), el id resuelto dentro de la sesión y el pedido pendiente en el circuito (ADR-12, OA-S4) | La baja con estado en el host; 11 lo muestra con `AgentSession` en consola | **Queda** |
| PD-7 | `MapMcp` en el mismo host, con sesión fija | Nada que 13 no tenga: 13 ya es servidor HTTP con `MapMcp`, sólo loopback, y prueba el aislamiento MCP ↔ API (l. 672). PD-7 no llama al modelo | **Sale**. `Mcp_HostYOrigenAjenos_Rechaza` pasa a 13 |

Ningún OA se queda sin ejemplo: OA-D2 conserva 03, 04 y PD-3; OA-D4, 06 y 07; OA-D8, 13; OA-D5, 08, 09, PD-1 y PD-5; OA-D6 y OA-S4, 11 y PD-6. La demo cubre ESC-01, ESC-03 y ESC-04; ESC-02 y ESC-05 se cubren con 05–07 y 13 (respuesta 1). Ahorro de turno: dos humos K (160 s). El ahorro grande es de construcción: un puerto, un servicio, un controller, `Mcp/` y su validación de Host y `Origin` en `Program.cs`, el servicio `ollama-embed` del compose (si PD-2 se reemplaza) y una dependencia menos de DEP-15. Cascada que hay que rehacer: §0.5, §3.5, §14.3, §F.1 (tabla y «recorre los cinco escenarios», l. 790), §F.2 (filas `Mcp/`, `EncuestaDesdeTextoService`, `IExtractorDeEncuesta`), §A.4 punto 6, §E.5 TURNO-1, AC-3b (lista cerrada), columna «Ejemplo / paso» de OA-D4 y OA-D8, y la fila DEP-15 de §G.3.

### 1.5 H2-056 (fusiones): **F1 no · F2 no · F3 sí, sin renumerar**

- **F1 (01 + 02): no.** Choca con el contrato por ejemplo: `ejemplo.json` declara **un** `recurso` (l. 638), 01 es `<recurso-compartido>` (TURNO-1) y 02 es `[recurso-modelo-propio]` (TURNO-3), y ninguna fase pide un segundo recurso (l. 636). Fusionar obliga a partir el ejemplo en dos fases o a pasar el primer ejemplo de la guía al modelo de 0,5B. La papeleta (l. 764) no dice ninguna de las dos cosas (H-DID3-05). Además, 01 es el primer contacto del lector y conviene que sea mínimo.
- **F2 (06 + 07): no.** 06 es la única pieza que mide la recuperación sola contra las líneas base, que es la lección de §7.5 («medir la recuperación antes que la respuesta»). La propia papeleta reconoce ese costo.
- **F3 (14 opcional): sí, sin renumerar.** 14 ya está fuera de la secuencia principal (X-001, l. 673) y no llama al modelo. F3 ratifica su estado y no ahorra llamadas. Como no se fusiona nada, la renumeración de §E.3 no hace falta.

### 1.6 Par CTX-NUEVA / CTX-EXISTENTE (respuesta 2): **a favor, con dos condiciones didácticas**

(1) Ningún ejemplo corre en CTX-NUEVA: `_Comun` copia el dominio de `8fb4c3a` (l. 580), así que todo lo ejecutado es CTX-EXISTENTE. Las tablas «Aplicación por escenario» tienen que marcar las celdas de CTX-NUEVA como «explicado, sin ejemplo», para que el lector no busque un ejemplo que no existe. (2) El par necesita un OA que lo evalúe: OA-A6 (§1.2) o, como mínimo, el caso integrador 3 (§1.3). Si no, el vocabulario nuevo entra a §2 sin una conducta que observar.

## 2. Hallazgos nuevos

### H-DID3-01 · El criterio B/I/A no reproduce la columna que dice justificar, y PR-3 tiene desvíos sin declarar

```json
{
  "id": "H-DID3-01",
  "ubicación": "§E.2, l. 656 (criterio) y l. 660–676 (columna Dificultad); §D fila PR-3 (c), l. 550",
  "afirmación": "Aplicado al pie de la letra, el criterio del cuerpo auditor contradice la columna en 01 (introduce modelo, prompt y contexto: da I, figura B), 05 (un concepto, el contexto completo con prefijo estable, y sólo M.E.AI: da B, figura I), 06 (embedding con M.E.AI: da B, figura I) y 07 (sin MAF, juez, oráculo de seguridad ni cruce de escaleras: da I, figura A). Además, «oráculo de seguridad» no está definido (08, 09 y 13 tienen invariantes de sesión, aprobación o lista permitida), y MCP, telemetría y evaluación no son términos de §3.0, así que el criterio no es computable para 13, 15 y 17. §D afirma que 07 es A y 06 es I «por ese criterio», y eso es falso. Frente a PR-3 hay tres desvíos sin declarar: 08 (primera herramienta, básico en PR-3) figura I; 11 (agente con aprobación, intermedio) figura A; 17 (observabilidad, avanzado) figura I.",
  "evidencia": "E2: cotejo de l. 656 con los conceptos y paquetes de cada fila de l. 660–676 y con los 12 términos de §3.0 (l. 408); I-02 §4, fila PR-3",
  "severidad": "S3",
  "dirección": "Enmendar como en §1.1: nivel de PR-3 por tema, regla residual (I, o A con MAF o juez), sin el disparador de persistencia o sesión; 08 → B, 17 → A; desvíos de 06 y 11 declarados en §D"
}
```

### H-DID3-02 · El criterio de inclusión «en los dos sentidos» falla en unas veinte subsecciones, y la demo no tiene OA

```json
{
  "id": "H-DID3-02",
  "ubicación": "§A.3, l. 100–132 (columna «§» y lista de subsecciones de contexto) frente a las fichas de §C, l. 374–529",
  "afirmación": "Fuera de toda columna «§» y de la lista de contexto (§4.2, §12.7, §12.8, §12.9) quedan §2.1–§2.3, §3.0, §3.3–§3.5, §4.1, §4.3, §4.6, §5.8, §8.10, §10.8, §11.7, §11.8, §12.10 y §14.1–§14.6. §4.1 ya estaba en la lista de H2-036 y el parche no la cubrió. §14, la demo que el PO pidió de forma explícita, no tiene ningún OA, así que §15 no tiene ningún ítem sobre ella. El script prescrito («falla si alguna no está en ninguna») falla en su primera corrida.",
  "evidencia": "E1: lectura de la columna «§» de las 26 filas (l. 103–128), de la lista de l. 132 y de los títulos de subsección de las fichas de §C",
  "severidad": "S2",
  "dirección": "Una regla de clase: las subsecciones «Decisión en curso» y «Qué decisión toca» son remisiones a §13 y quedan exentas, con motivo. Asignaciones: §2.1–§2.3 → OA-0.1/OA-A2; §3.3–§3.5 → OA-0.3; §4.3 → OA-0.2; §11.7 → OA-S2 (su ejemplo es 16); §3.0 y §4.1 → lista de contexto (vocabulario). §14 → OA-A6 (§1.2) o el caso integrador 3 (§1.3). Costo: celdas de la tabla; ~90 palabras en §15 si entra OA-A6"
}
```

### H-DID3-03 · OA-S1 no se practica antes de §15

```json
{
  "id": "H-DID3-03",
  "ubicación": "§A.3, fila OA-S1 (l. 124); §C, §11, preguntas guía (l. 492)",
  "afirmación": "OA-S1 («nombrar los riesgos OWASP que aplican y su control mínimo en código») no tiene ejemplo («—») ni pregunta guía: las cinco de §11 están atadas a OA-O1, OA-S2, OA-S2, OA-O2 y OA-D8. Es el único OA que aparece por primera vez en la autoevaluación, que así evalúa una conducta que la guía nunca hizo practicar. El criterio de inclusión controla ejemplo → OA y sección → OA, pero no OA → práctica.",
  "evidencia": "E1: l. 124 y l. 492; recuento de los OA citados en las preguntas guía de §2–§14",
  "severidad": "S3",
  "dirección": "Atar «Indexo texto que no escribí yo: ¿qué riesgo nuevo agrego?» a OA-S1 + OA-S2 (0 palabras) o cerrar §11.1 con la ficha de riesgo del Anexo A llena para 16. Agregar al script de inclusión el sentido OA → al menos un ejemplo o una pregunta guía antes de §15"
}
```

### H-DID3-04 · PD-2 enseña en la demo el contraejemplo de la tesis, y bajo EMB-C ni siquiera corre

```json
{
  "id": "H-DID3-04",
  "ubicación": "§F.1, fila PD-2 (l. 797); §A.1, nota de pasos que suben de más; §E.5, TURNO-3 (l. 752)",
  "afirmación": "El único paso de la escalera de conocimiento de la demo está declarado como «sube más de lo necesario: con este corpus alcanzaría el 0» (N3b P6). Con DEP-14 sin resolver (el gestor no lista `[recurso-modelo-propio]` el 2026-10-26), rige EMB-C y PD-2 queda «no ejecutado contra un modelo de embeddings». El lector ve la aplicación integrada hacer lo contrario de la tesis («se sube un escalón cuando el de abajo no alcanza»), y además sin evidencia. Después de la respuesta 1 de la presidencia, ESC-02 no necesita estar en la demo: lo cubren 05, 06 y 07.",
  "evidencia": "E1: l. 797, l. 752, `<gestor-de-turnos> estado`; E2: respuesta 1 de `Ciclo-2/09-Respuestas-De-La-Presidencia.md`",
  "severidad": "S2",
  "dirección": "Opción recomendada: reemplazar PD-2 por la ayuda en el escalón 0 (contexto fijo con los 12 literales de *Policy, ~250 tokens, clase K, mismo `IAyuda`). Así la demo muestra el escalón más bajo que resuelve el caso (OA-0.3), sin embeddings ni `ollama-embed`, y ADR-05 remite a 07. Alternativa: PD-2 sale y ESC-02 queda en 05–07. En los dos casos se borra la nota de §A.1 sobre PD-2"
}
```

### H-DID3-05 · La papeleta F1 declara un costo nulo que el contrato por ejemplo no admite

```json
{
  "id": "H-DID3-05",
  "ubicación": "§E.5, papeleta de H2-056, F1 (l. 764), frente a §E.1, contrato por ejemplo (l. 638) y orden global de pedido (l. 636)",
  "afirmación": "F1 promete «ahorro de un proyecto y 0 llamadas», pero el ejemplo fusionado necesitaría dos recursos (`<recurso-compartido>` para 01 y `[recurso-modelo-propio]` para 02), y `ejemplo.json` admite uno solo. Además, ninguna fase pide un segundo recurso. Para que F1 funcione hay que partir el ejemplo en dos fases (el ahorro de proyecto desaparece a efectos del arnés) o pasar 01 al modelo de 0,5B del Ollama propio, que, bajo EMB-C, ni siquiera corre. El jurado votaría F1 sin ver ese costo.",
  "evidencia": "E1: l. 636, l. 638, l. 660–661 (columna Turno de 01 y 02), l. 764",
  "severidad": "S3",
  "dirección": "Votar F1 «no» (§1.5) o, si se mantiene, reescribir la papeleta con el costo real: dos manifiestos o 01 en TURNO-3"
}
```

### H-DID3-06 · El orden de TURNO-2 no sigue el valor para el aprendizaje: con 4 h, OA-O3 se queda sin evidencia real

```json
{
  "id": "H-DID3-06",
  "ubicación": "§E.5, TURNO-2 (l. 738–750) y «Qué entra según el tope» (l. 754)",
  "afirmación": "Con el tope vigente de 4 h corren 13, 17, 12 y la extensión de 03. 13 y 17 van primeros, y sus conductas (OA-D8 y OA-O1) ya son observables con `--fake`: sus oráculos son deterministas (listado sólo de lectura, `borrar_todo` sin montar, spans sin mensajes, aciertos de caché fuera de la telemetría). En cambio, 15 queda afuera, y es la única evidencia ejecutada de OA-O3 («leer un puntaje de LLM juez: decir si está calibrado»). El ítem de §15 de OA-O3 le pediría al lector leer un puntaje que la guía nunca mostró.",
  "evidencia": "E1: l. 672, l. 676 (columna sin servidor de 13 y 17), l. 674, l. 754; E3: con 15a (10 llamadas M, objeción de J3 en `Ciclo-2/06-Aprobacion.md` §2.4), 12 + 15a = 800 + 1.200 = 2.000 s, el margen exacto de 4 h; con t = 131,4 s (objeción de J1, §2.1) no entra",
  "severidad": "S3",
  "dirección": "Ordenar TURNO-2 por «OA sin evidencia observable en `--fake`»: 12, 15a, extensión de 03, y después 13 y 17. Si 15a no entra en el tope votado, reformular el ítem de OA-O3 sobre puntajes guionados rotulados «escrito para el ejemplo» y decirlo en OA-O3"
}
```

## 3. Revisado y bien

- El tipo de ítem de §15 sigue al verbo del OA (H2-037, l. 526), con un criterio que el lector verifica solo (OA-D1: `grep` de 02 + `--fake`).
- El orden de §8 quedó corregido (H2-035): la variante «un-agente» de 12 es un workflow sin `AsAIAgent` en §8.6, y «dos-agentes» va en §8.8, después de §8.7 (l. 459, l. 671).
- Demostración frente a medición (l. 709–711): la guía no publica tasas de un ejemplo de demostración, coherente con OA que piden decidir y no afirmar diferencias.
