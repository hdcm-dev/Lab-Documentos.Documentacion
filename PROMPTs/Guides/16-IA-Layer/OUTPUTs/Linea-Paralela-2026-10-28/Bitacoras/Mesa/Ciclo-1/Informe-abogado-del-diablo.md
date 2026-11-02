---
doc_id: BIT-16-C1-INF-abogado-del-diablo
titulo: Informe del abogado del diablo — ciclo 1
especialista: abogado del diablo (núcleo permanente, REED-16 §8, §9.2 paso 3)
fecha: 2026-10-28
maquina: estación 1
objeto: Nucleos/N0b…N6 (con notas del 2026-10-28), 04-Integracion.md (MI-01…MI-24), 00…03
entra_despues_de: los doce informes ya escritos del ciclo 1 (leídos, como pide el despacho)
---

# Informe del abogado del diablo — ciclo 1

> **Mandato.** Atacar la recomendación dominante de cada núcleo y de BIT-16-04, buscar la alternativa más fuerte y la evidencia que la sostendría, y atacar también los consensos del panel. Esquema de hallazgo M§8; evidencia y severidades de BIT-16-00 §3. Entro después del resto: leí los doce `Informe-*.md` del ciclo.
>
> **Cómo leer este informe.** Cada hallazgo dice qué recomendación ataco, cuál es la alternativa más fuerte que encontré y qué evidencia la sostiene. Que un ataque falle también es un resultado: lo que sobrevivió va en §3. El abogado del diablo no decide: le da al jurado la mejor versión del «no».

## Índice

- [0. Evidencia producida](#0-evidencia-producida)
- [1. Mapa de recomendaciones dominantes y consensos atacados](#1-mapa-de-recomendaciones-dominantes-y-consensos-atacados)
- [2. Hallazgos](#2-hallazgos)
- [3. Lo que revisé y está bien (ataques que fallaron)](#3-lo-que-revisé-y-está-bien-ataques-que-fallaron)
- [4. Posición sobre los MI de mi mandato](#4-posición-sobre-los-mi-de-mi-mandato)
- [5. Solicitudes de convocatoria](#5-solicitudes-de-convocatoria)

## 0. Evidencia producida

Todo está en [`evidencia-abogado-del-diablo/`](evidencia-abogado-del-diablo/).

| Id | Qué | Nivel | Archivo |
|---|---|---|---|
| AD-S1 | Sonda R-LLM: misma sonda de herramientas del sondeo del 2026-10-28 (`sondeo.py`, copiado sin cambios), variantes «bici» y «a pie», N = 10, T 0,7, seeds 1..10, `reasoning_effort: none`, con `qwen3.5:2b` (bajado para la sonda y **borrado al terminar**) y `qwen3.5:4b` en la misma ventana. Criterio escrito antes: una sola `tool_call`, nombre correcto y `medio` igual al esperado. Por turno de `<recurso-compartido>`, endpoint sólo por variable | E1 | `correr.sh`, `sondeo.py`, `salidas/02-info.jsonl`, `03-tools-bici.jsonl`, `04-tools-apie.jsonl`, `05-ps.jsonl`, `01-pull-resumen.txt`, `06-rm.txt`, `07-list-final.txt`, `09-turno.log` |
| AD-S2 | Límites del contenedor del Ollama propio (estación 1): memoria y CPU asignadas | E1 | `salidas/08-limites-contenedor.txt` |
| AD-W1 | Etiquetas de `qwen3.5` en la biblioteca de Ollama (https://ollama.com/library/qwen3.5/tags, consultada el 2026-10-28): existen `0.8b`, `2b` (`q4_K_M` 1,9 GB), `4b` (`q4_K_M` 3,3 GB), `9b` (`q4_K_M` 6,6 GB), `27b`, `35b-a3b` (`q4_K_M` 22 GB) y `122b-a10b`, todas con *tools* y 256K de ventana | E4 | — (cita) |
| AD-W2 | Ficha de `Qwen/Qwen3.5-35B-A3B` (https://huggingface.co/Qwen/Qwen3.5-35B-A3B, consultada el 2026-10-28): «35B in total», «3B activated», 256 expertos (8 enrutados + 1 compartido), licencia apache-2.0 | E4 | — (cita) |
| AD-W3 | OWASP LLM06:2025 Excessive Agency (https://genai.owasp.org/llmrisk/llm062025-excessive-agency/, consultada el 2026-10-28): «Limit the extensions that LLM agents are allowed to call to only the minimum necessary»; «Limit the functions that are implemented in LLM extensions to the minimum necessary»; y, recién después, «Utilise human-in-the-loop control to require a human to approve high-impact actions before they are taken» | E4 | — (cita) |

El resto de la evidencia que cito es de la bitácora, con ubicación.

## 1. Mapa de recomendaciones dominantes y consensos atacados

| Recomendación dominante | Dónde | Consenso del panel | Mi ataque |
|---|---|---|---|
| «Todo pasa por RAG» (la imagen) | N1, N3; tensión 1 | Ya desmontado por la integración | Falló: §3, ítem 1 |
| Escrituras por herramienta con aprobación integrada (agente MAF) | N4, N6 C5; R-C02; §6.2 | Unánime en MI-14; ARQUIT-02 y SENIOR-04 piden **más** contrato para sostenerlo | ABOGAD-01 |
| «`qwen3.5:4b` alcanza para la demo» | Tensión 4; MI-02 | Unánime (cinco propuestas, una abstención) | ABOGAD-02 |
| RAG y búsqueda semántica dentro de la demo sobre 12 enunciados | MI-07, MI-08; N6 C4 | Unánime en MI-07; MI-08 con condiciones | ABOGAD-03 |
| Tres vías de recuperación, «A por defecto» | MI-01; tensión 1 | Mayoría a favor, con matices | ABOGAD-04 |
| Demo como banco de todo lo que la guía enseña | §6.2; M1–M12 | El panel **suma** controles y piezas, nadie resta | ABOGAD-05 |
| «Sincrónico con streaming» como respuesta a la latencia | CAT-OP-01; MI-24; MI-20 | Sin oposición | ABOGAD-06 |
| «Contexto fijo por defecto» | N3b; MI-07 | Unánime | Falló: §3, ítem 2 |
| «Copia literal de ApiWeb» | Tensión 7; MI-05 | A favor, con condiciones de inventario | Falló: §3, ítem 3 |

## 2. Hallazgos

### ABOGAD-01 · La demo no necesita herramientas de escritura: la alternativa «el modelo propone, la persona ejecuta» elimina el problema que el panel quiere resolver con más contrato

```yaml
id: ABOGAD-01
especialista: abogado del diablo
capa_origen: núcleo   # N6 §1.3 C5 y §4.4; heredado por BIT-16-04 R-C02, §6.2 (TOOLS, AGT) y MI-14
ubicación: "04-Integracion.md §3.2 R-C02, §5 MI-14, §6.2 nodos TOOLS y AGT, §6.3 M3; Nucleos/N6-Caso-Movilidad-Urbana.md §1.3 fila C5 (l. 65, l. 80), §4.4 (l. 270–283), Anexo A D6 (l. 475)"
severidad: S2
nivel_evidencia: E1 + E4
confianza: 0.75
```

**Qué ataco.** La recomendación dominante es que las escrituras del asistente (alta y baja) sean **herramientas** que el modelo invoca, envueltas en `ApprovalRequiredAIFunction` y corridas por un agente de MAF con `AgentSession` (N6 C5, §4.4; BIT-16-04 R-C02 para ESC-04). El panel no la discute: la refuerza. ARQUIT-02 pide un puerto con acciones pendientes, una operación para resolverlas y un ADR sobre el estado de la conversación. SENIOR-04 pide un almacén de sesiones serializadas con vencimiento, un endpoint de aprobación por id y SSE.

**La alternativa más fuerte.** El patrón que la integración ya eligió para ESC-03, generalizado: **el modelo no recibe ninguna herramienta que escriba.** Ante «Borrá Resistencia» o «Agregá Goya…», el adaptador pide una salida estructurada en lenguaje del dominio (por ejemplo `AccionPropuesta { Tipo = Baja | Alta, Localidad, Argumentos }`) con `GetResponseAsync<T>`. La UI la muestra y, si la persona confirma, ejecuta el `DELETE` o el `POST` del **controller copiado de ApiWeb**, con sus reglas. La aprobación deja de ser un estado del agente entre dos peticiones y pasa a ser lo que ya es en cualquier aplicación web: un botón que dispara la operación normal.

**Evidencia que la sostiene.**
- E1, X2 D6 (`Integracion-Evidencia/C-operacion-demo/X2-escrituras-qwen3.5-4b.jsonl`): con una herramienta de baja disponible, el 4b la llama **10 de 10** veces sin preguntar, aunque la descripción dice «No se puede deshacer». El riesgo nace de *ofrecer* la herramienta. La aprobación lo contiene, pero la alternativa no lo crea.
- E4, OWASP LLM06:2025 (AD-W3): las dos primeras mitigaciones son «Limit the extensions … to only the minimum necessary» y «Limit the functions … to the minimum necessary». La aprobación humana viene **después**. Hoy la demo arranca por la tercera y se saltea las dos primeras.
- E1, E-B2 (`B-abstracciones-agentes/sonda/salidas/01-b1-b2.jsonl`): la salida estructurada con el 4b da forma válida 13/13 y validez de dominio 11/13. La pieza que la alternativa necesita ya está medida y es la misma que usa ESC-03.
- E1, E-B3: la aprobación integrada se probó con **N = 3**, en un mismo proceso y en un mismo método (lo señala SENIOR-04). Nunca se probó a través de dos peticiones HTTP, que es el caso de la demo.
- E2, ARQUIT-02 y SENIOR-04: el costo de sostener la recomendación es un contrato de puerto nuevo, un ADR, un almacén de sesiones, SSE y un endpoint de aprobación. La alternativa no necesita ninguna de esas piezas: el `DELETE /api/v1/localidades/{id}` ya existe en la copia.
- E1, X0 y BIT-16-04 P-13: «MAF publica una estable por semana». Sin escrituras por herramienta, el camino por defecto de la demo puede no depender de `Microsoft.Agents.AI`. MAF queda en `Examples/07`, donde vale la regla «subir cuesta poco» (MI-09).

**Lo que la alternativa no cubre, dicho sin rodeos.** No enseña `ApprovalRequiredAIFunction` dentro de la demo. Eso es una pérdida didáctica real para ESC-04, que se compensa con `Examples/07` (diff 4.1 → 4.2, MI-09). Si el jurado considera que ESC-04 tiene que estar en la demo, la alternativa admite un término medio: el agente puede tener herramientas **de lectura** (D4, D7) y las escrituras se proponen siempre por salida estructurada.

**Impacto si no se corrige.** La demo se lleva su pieza más cara de construir (estado de aprobación entre peticiones), menos probada (N = 3, en proceso) y más volátil (MAF semanal), para un escenario donde un formulario con confirmación resuelve lo mismo con menos superficie de ataque.

**Propuesta.** Votar MI-14 como «otra» (§4): el alta y la baja se confirman siempre, **por diseño estructural** (propuesta tipada + operación normal) y no por `ApprovalRequiredAIFunction` en la demo. `ApprovalRequiredAIFunction` + `AsAIAgent` se enseña en `Examples/07`. ARQUIT-02 y SENIOR-04 se re-evalúan contra esta alternativa antes de aprobar su contrato. Pido a AH-01 que evalúe la alternativa desde la seguridad (§5).

### ABOGAD-02 · «`qwen3.5:4b` alcanza» se eligió por disponibilidad y contra un solo rival; el conjunto de candidatos nunca incluyó el 2b ni un MoE de 3B activos, y «alcanza» se midió en el primer turno, no punta a punta

```yaml
id: ABOGAD-02
especialista: abogado del diablo
capa_origen: integración   # tensión 4 y MI-02; nace en el laboratorio (sondeo §R) y en Reanudar.md §3
ubicación: "04-Integracion.md §2 tensión 4, §5 MI-02 y MI-03; Sondeo-Entorno.md §R.1–R.5; Reanudar.md §3 fila 1; Nucleos/N3b-CAG-Y-Estrategias-De-Conocimiento.md nota de integración («≥ 7B no corre en estación 1»)"
severidad: S2
nivel_evidencia: E1 + E4
confianza: 0.7
```

**Qué ataco.** El consenso más firme del panel: `qwen3.5:4b` es el modelo de la guía (experto IA, implementador, QA: «propuesta»). La alternativa votable de MI-02 es «modelo mayor en estación 2». Las dos opciones dejan afuera las alternativas más fuertes.

**De dónde salió el 4b.** `Reanudar.md` §3: había que «bajar un modelo mayor (`docker exec … ollama pull qwen3.5:4b`)». Es el modelo que se bajó, no uno que se eligió. Toda la evidencia comparativa (E-B1, Sondeo §R.4) lo enfrenta sólo con `qwen2.5:0.5b`, que es un humo de conectividad de otra familia y otra generación. Que el 4b gane 10/10 contra 0/10 separa «sirve» de «no sirve», pero no dice que sea el adecuado.

**Lo que «alcanza» no midió.**
- E1, EA-6 (`A-arquitectura/exp-capas/salida-real.txt`): la tasa citada (5/5 en la elección de herramienta) es del **primer turno**. La única corrida punta a punta de la vía B con `UseFunctionInvocation` («¿Cuántos dígitos lleva el código postal…?», 44 s) **no recuperó** y contestó de memoria, con «suelen tener 5 dígitos» entre las opciones. La vía A tardó 96,5 s en una corrida (N = 1).
- E1, X2: la pared del **primer** turno va de 12,9 s a 75,6 s; después el bucle de herramientas agrega al menos otra llamada (CAT-OP-05). EXPERT-03 mide la lectura del prompt en 18–20 tok/s.
- E1, X2 D1: el 4b inventa el CP 10/10 sin decirlo. Es un modo de falla del modelo, que hoy se contiene con controles (M2, M3), pero nadie midió si un modelo distinto lo tiene.

**Las alternativas que faltan.**
- E4, AD-W1: existe `qwen3.5:2b` (`q4_K_M` 1,9 GB), con *tools* y de la misma familia. Si alcanza en las operaciones de la demo, puede bajar la latencia en un entorno donde la latencia es el problema dominante (EXPERT-03, CAT-OP-01). E1, AD-S1: en la misma sonda que decidió MI-02 empata con el 4b (ver «Resultado de AD-S1»).
- E4, AD-W2: existe `qwen3.5:35b-a3b`, un MoE con «3B activated» de 35B totales, también con *tools*. En CPU, el costo por token depende principalmente de los parámetros activos. Es la candidata natural para el pedido a estación 2 de MI-03, en vez de un denso ≥ 7B, que en CPU es más lento por token. **No medido**: es una hipótesis que la sonda de MI-03 tiene que confirmar o refutar, no una afirmación.
- E1, AD-S2: el contenedor del Ollama propio en estación 1 tiene **5 GiB** de memoria y 4 CPU asignados. Por eso no entran ni el `9b` (`q4_K_M` 6,6 GB) ni el `35b-a3b` (22 GB). «≥ 7B no corre en estación 1» es un límite de configuración del contenedor, no del hardware (coincide con CAT-OP-05, que lo dedujo de X4). El anfitrión tiene 30 GB.

**Resultado de AD-S1** (E1, R-LLM; 2026-10-28 10:20–10:35 -03; Ollama propio en contenedor (estación 1); `qwen3.5:2b@0689d44085e0…` con 1.881.825.088 parámetros, `qwen3.5:4b@d8b0f5e9760c…` con 4.205.751.296; `/v1/chat/completions`, T 0,7, seeds 1..10, `max_tokens` 300, `reasoning_effort: none`; orden de corrida: 2b bici, 2b a pie, 4b bici, 4b a pie; el 2b se borró al terminar, `salidas/06-rm.txt` y `07-list-final.txt`).

| Modelo | «bici» → `bicicleta` | «a pie» → `caminata` (el sinónimo que separó al 4b del 0.5b) | Pared corrida 1 (en frío) | Pared corridas 2–10 |
|---|---|---|---|---|
| `qwen3.5:2b` | **10/10** | **10/10** | 40,0 s / 16,9 s | bici 8,0–16,2 s; a pie 4,0–4,6 s |
| `qwen3.5:4b` | 10/10 | 10/10 | 46,2 s / 37,0 s | bici 6,1–7,1 s; a pie 6,5–11,0 s |

Lectura, dentro de lo que N = 10 permite:
- **La prueba que decidió MI-02 no separa al 2b del 4b.** El sinónimo «a pie», que dio 10/10 frente a 0/10 contra el 0.5b (Sondeo §R.4), lo resuelve igual el 2b. Con esta sonda, la evidencia de MI-02 respalda «la familia qwen3.5 con *tools*», no «el 4b».
- **Las paredes no permiten concluir sobre latencia.** El 2b fue más rápido con «a pie» y más lento con «bici», y las corridas no se intercalaron. El anfitrión no estaba reservado para la medición, así que la diferencia puede ser ruido de la máquina. No afirmo que el 2b sea más rápido: afirmo que la comparación está por hacer.
- **Lo que esta sonda no mide** es justo lo que importa para la demo: salida estructurada válida para el dominio (E-B2), no inventar el CP (X2 D1) y el bucle completo. Es el criterio punta a punta que pide la propuesta.

**Impacto si no se corrige.** La guía fija como «el modelo» uno que se eligió por estar a mano. El lector hereda una latencia de decenas de segundos por turno sin saber que había otra opción en la misma familia, y el pedido a estación 2 se gasta en el candidato menos prometedor para CPU.

**Propuesta.**
1. MI-02 queda como **provisional**: `qwen3.5:4b` es el modelo de trabajo, y la elección se cierra con un criterio de aceptación escrito antes, **punta a punta** por la vía .NET, sobre D1–D6 (no sólo sobre la elección de herramienta del primer turno), con la pared por operación como segunda métrica.
2. Candidatos de la comparación: `qwen3.5:2b` y `qwen3.5:4b` en estación 1 (entran en 5 GiB). Si se aprueba MI-03, `qwen3.5:35b-a3b` en estación 2 en lugar de un denso ≥ 7B.
3. Reescribir «≥ 7B no corre en estación 1» como «el contenedor de estación 1 tiene 5 GiB; no se probó con más memoria».
4. Si el 4b sigue ganando, la guía lo dice con el dato. El ataque no pretende que pierda: pretende que gane una comparación.

### ABOGAD-03 · La demo mete RAG y búsqueda semántica en un caso que, según su propio árbol de decisión, no los necesita

```yaml
id: ABOGAD-03
especialista: abogado del diablo
capa_origen: integración   # MI-07, MI-08, R-C16, RA-6; nace en N6 C4 y en el marco (ESC-02)
ubicación: "04-Integracion.md §6.3 (nodo D3 «cabe (los 12 *Policy) → Escalón 0»), §5 MI-07 y MI-08, §3.1 RA-6 y R-C16; 03-Marco-De-Referencia.md §4.1 («La fila N6 se completa … con los escenarios que la demo efectivamente cubre»); Nucleos/N6 Anexo A D5"
severidad: S3
nivel_evidencia: E1 + E2
confianza: 0.7
```

**Qué ataco.** El consenso unánime sobre MI-07 (`IAyuda` con `AyudaContextoFijo` por defecto y `AyudaRag` como variante **dentro de la demo**) y el consenso con condiciones sobre MI-08 (ESC-02 = «buscar el requisito por significado» sobre los 12 enunciados).

**La contradicción.** El árbol de §6.3 es explícito: para los 12 `*Policy`, «cabe» → escalón 0. La propia integración dice que RAG sobre ellos «es didáctico» (tensión 3). La demo, entonces, arma un pipeline de RAG para un corpus donde su propio criterio dice que no va, y le busca un escenario (ESC-02) que el caso no tiene: R-C16 tuvo que **descartar** el candidato original («buscar localidades por descripción») porque era un antipatrón (N6 P2).

**Evidencia.**
- E1, EA-6: el corpus son 12 enunciados. EXPERT (MI-07) lo estima en unos 250 tokens, frente a una ventana cargada de 4096. Indexarlo tardó 17,1 s. El top-3 es un cuarto del corpus.
- E1, AH-02--03: con el corpus real, el puntaje de similitud de dos preguntas no respondibles (0,445; 0,383) supera al de una respondible bien recuperada (0,363). En la comparación pareada de MI-07, `AyudaRag` sólo puede empatar o perder.
- E1, E-B5: «en avión» → `moto` (0,641). La similitud siempre devuelve algo.
- E2, `03-Marco-De-Referencia.md` §4.1: la fila N6 «se completa … con los escenarios que la demo **efectivamente cubre**». El marco no obliga a que la demo cubra ESC-02. La columna ESC-02 queda cubierta por N3. El argumento de Requisitos («sin candidato queda un hueco») no se sostiene en el texto del marco.

**La alternativa más fuerte.** La demo tiene **sólo** el escalón 0 (`AyudaContextoFijo`) y lo justifica con el árbol. RAG y ESC-02 se enseñan en `Examples/04–05` con el corpus sintético rotulado de N3b (que ya se mantiene, C-12), **dimensionado para que no quepa** en la ventana configurada. Es el único lugar del material donde el árbol dice «RAG», y el comparativo muestra una diferencia en vez de un empate. El puerto `IAyuda` puede quedar con un solo adaptador en la demo, y el segundo en el ejemplo. La lección de D-01 (cambiar de adaptador sin tocar Application) ya la muestran `IExtractorDeLocalidad` y el selector de proveedor.

**Impacto si no se corrige.** La guía enseña con una mano «con 12 enunciados no hace falta RAG» y con la otra le arma RAG a esos 12 enunciados en la demo. Un lector apurado copia la demo, no el árbol. Además, P-05 y P-06 consumen turnos de `<recurso-compartido>` para medir algo cuyo resultado ya se conoce.

**Propuesta.** MI-07 y MI-08: «alternativa» (§4). La demo declara en su README por qué no tiene RAG, con el nodo D3 del árbol como cita. El RAG medido va a `Examples/05` con un corpus que no cabe en la ventana.

### ABOGAD-04 · La vía C nunca corrió contra un modelo, y «A por defecto» es la regla para un caso que la demo no tiene

```yaml
id: ABOGAD-04
especialista: abogado del diablo
capa_origen: integración   # tensión 1 (RA-1), MI-01
ubicación: "04-Integracion.md §2 tensión 1, §5 MI-01, §6.3 (nodos D4/VA/VB/VC); Integracion-Evidencia/A-arquitectura/exp-capas/salida-fake.txt l. 27; salida-real.txt"
severidad: S3
nivel_evidencia: E1
confianza: 0.8
```

**Qué ataco.** MI-01: tres vías con orden A → B → C y la regla «A por defecto». El panel la aprueba (arquitectura, experto IA) o la reubica (didáctica: C en §6). Nadie pregunta si la vía C tiene evidencia para entrar como vía.

**Evidencia.**
- E1, `salida-fake.txt` l. 27: «Vía C (AIContextProvider de MAF) → (guion) respuesta sin herramientas». La vía C corrió sólo con un doble que sigue un guion. EA-6 (la corrida real) cubre sólo A y B. EA-4 es reflexión: prueba que el tipo existe, no que funcione con el 4b.
- E1, EA-6: la vía A se midió con N = 1 (lo señala CAT-FO-02), en 96,5 s.
- E2, §6.3: «A por defecto» aplica cuando «toda pregunta necesita el corpus». El asistente de la demo mezcla conteos (D4), ayuda (D5) y acciones (D1, D6). Por el mismo árbol, la demo no está nunca en el caso A. Y si se aplica ABOGAD-03, la ayuda de la demo es escalón 0 y ninguna vía de recuperación entra en la demo.
- E1, X0 y P-13: `AIContextProvider` vive en MAF, que publica una estable por semana. Es la pieza de API más volátil de las tres.

**La alternativa más fuerte.** La alternativa votable de MI-01 («enseñar A y B y mencionar C en una línea»), con un ajuste: C se menciona en §6, como «la misma recuperación dentro del agente», donde la ubica didáctica. Así no se enseña como vía de igual rango algo que no se ejecutó. Si un constructor de `Examples/07` la corre con R-LLM, puede subir de rango en la relectura.

**Impacto si no se corrige.** La guía presenta tres vías equivalentes cuando una no tiene evidencia de comportamiento, y da como regla por defecto la de un caso que su propia demo no ejerce.

**Propuesta.** MI-01: «alternativa». El respaldo de la regla se reescribe como criterio de diseño (EA-5), como ya pidió CAT-FO-02, y no con EA-6.

### ABOGAD-05 · El panel sólo suma: la demo acumula piezas hasta contradecir CTX-PROTO, y la alternativa «demo mínima + ejemplos» resuelve varios hallazgos de otros a la vez

```yaml
id: ABOGAD-05
especialista: abogado del diablo
capa_origen: integración   # §6.2 y tensión 6; amplificado por los informes del ciclo 1
ubicación: "04-Integracion.md §6.2 (diagrama), §6.3 M1–M12, §5 MI-11, MI-13, MI-20; 03-Marco-De-Referencia.md §2 fila CTX-PROTO (l. 50); Nucleos/N6 Anexo A D7; informes del ciclo 1 citados abajo"
severidad: S2
nivel_evidencia: E2
confianza: 0.65
```

**Qué ataco.** Un consenso implícito del panel: cada especialista encontró algo que falta y propuso **agregarlo a la demo**. Ninguno propuso sacar algo.

**Evidencia (E2: lectura de los informes y de §6.2).** Hoy la demo tiene, según §6.2 y §6.3: cuatro controllers nuevos, página Blazor, servidor MCP HTTP, cuatro puertos de IA, dos adaptadores de ayuda, recuperación con tres vías, agente MAF con aprobación, selector de proveedor, pipeline con OTel, caché y limitador, y 12 controles mínimos con dos suites. Los informes del ciclo proponen sumar, entre otros: M13 (MCP en loopback, `AllowedHosts`, M7 extendido) y M14 (prueba adversarial) (AH-01--05, --06); contrato de puerto con acciones pendientes y un ADR del estado de la conversación (ARQUIT-02); almacén de sesiones, endpoint de aprobación y SSE (SENIOR-04); medición de abstención (AH-02--03); streaming con cancelación (CAT-OP-01); un D-11 (ARQUIT, MI-23).

Frente a eso, `03-Marco-De-Referencia.md` §2 define CTX-PROTO, que es el contexto declarado de la demo: «Se tolera no determinismo y falta de observabilidad; el objetivo es aprender si el escenario vale la pena». Y el entorno es frágil: P-01 sola ocupa dos turnos de 45 min (CAT-OP-05), y el trabajo del 26 y el 27 se perdió con un disco (`Reanudar.md` §1).

**La alternativa más fuerte.** Una **demo mínima** que recorre D1–D6 con: extracción tipada con confirmación (D1–D3), herramienta de lectura de agregados (D4), ayuda por contexto fijo (D5) y baja por propuesta confirmada (D6, ABOGAD-01). Todo lo demás, en `Examples/`, cada pieza con su prueba: MCP (D7) en `Examples/08`, el agente con aprobación en `07`, RAG en `05`, el selector de proveedor en `01` y `06`. Con esa partición desaparecen, sin trabajo extra:
- AH-01--05: sin MCP HTTP en la demo, M13 no hace falta allí (se mantiene en `Examples/08`).
- ARQUIT-02 y SENIOR-04: sin aprobación entre peticiones, no hace falta el almacén de sesiones.
- SENIOR-06 frente a MI-13: el selector `/v1` deja de dejar inaplicable `num_ctx` (M10) en la demo, porque vive en los ejemplos (es la alternativa que votó el senior .NET).

**Lo que la alternativa pierde.** I-04 pide que la demo «muestre las capas, no sólo que funcione», y la demo mínima muestra menos capas a la vez. El jurado tiene que pesar eso contra el costo de construir y probar en este entorno todo lo que se acumuló.

**Propuesta.** Antes de aprobar parches que agreguen piezas a la demo, el jurado decide su perímetro: «demo mínima D1–D6 + ejemplos» frente a «demo integral». Los parches de AH-01--05, ARQUIT-02, SENIOR-04 y MI-13 se condicionan a esa decisión. MI-11: «otra» (§4).

### ABOGAD-06 · «Sincrónico con streaming» no resuelve la espera que se ve en pantalla: en el bucle de herramientas no hay texto para transmitir

```yaml
id: ABOGAD-06
especialista: abogado del diablo
capa_origen: integración   # MI-24 y MI-20, con la resolución propuesta en CAT-OP-01
ubicación: "04-Integracion.md §5 MI-20 y MI-24, §3.2 R-C19; Informe-CAT-operacion-entrega-rendimiento.md CAT-OP-01; Nucleos/N6 §1.3 C1 («POST /api/v1/asistente (streaming)»)"
severidad: S3
nivel_evidencia: E1
confianza: 0.6
```

**Qué ataco.** La resolución que CAT-OP-01 propone para MI-24 («la demo es sincrónica con streaming en la página de chat … y con cancelación») y el consenso sobre MI-20 (página de chat Blazor como vía móvil por el emulador).

**Evidencia.**
- E1, X2: en las tres operaciones de escritura, el primer turno no produce texto: produce una `tool_call` (D1, D6) o una pregunta corta. La pared de ese turno va de 12,9 s a 75,6 s. En ese tiempo el streaming no tiene nada que mostrar. En las operaciones con herramientas, recién después de la segunda llamada (EA-6 R5: 27,9 s y 44,4 s en total) aparece texto.
- E1, EXPERT-03: la lectura del prompt va a 18–20 tok/s y domina cuando hay contexto. El streaming adelanta la generación, no la lectura.
- E1, X2 (`usage.prompt_tokens_details.cached_tokens`): con el prefijo cacheado (572 de 576 tokens), la pared del primer turno baja de 75,6 s a unos 14 s. La palanca que más pesa es la caché del prefijo estable, no el streaming.

**La alternativa más fuerte.** Para la pantalla chica (I-06), la superficie principal no es un chat libre sino los endpoints «desde texto» de ESC-03 con una sola llamada estructurada (sin bucle), con un indicador de progreso por etapa («leyendo», «proponiendo») emitido desde el servidor. El chat queda como segunda superficie. Si se mantiene el chat, el streaming tiene que transmitir **eventos de etapa** (herramienta pedida, herramienta ejecutada), no sólo tokens, y el prefijo estable va primero para que la caché trabaje (lo que N3b §3.4 ya dice sobre el orden).

**Impacto si no se corrige.** La guía promete que el streaming resuelve la espera, y en el emulador el lector mira una pantalla quieta durante decenas de segundos en justo los pasos que la demo quiere lucir (D1, D6).

**Propuesta.** MI-24 y MI-20: «otra» (§4). La regla de M10 que pide CAT-OP-01 (timeout mayor que la peor pared más la cola) se mantiene, y se le suma que la medición de la pared separe primer turno, bucle y generación.

## 3. Lo que revisé y está bien (ataques que fallaron)

1. **«Todo pasa por RAG» está bien desmontado.** Intenté sostener la imagen (RAG entre el LLM y los agentes) como estrategia por defecto. No se sostiene: E-B4 muestra que el top-k no cuenta (3 de 4 en el top-3, la herramienta da 4), y E-B5 que la similitud siempre devuelve algo. La tensión 1 resolvió con E1 lo que muchos materiales repiten de memoria.
2. **«Contexto fijo por defecto» sobrevive.** Lo ataqué por costo: unos 250 tokens en cada pregunta, aunque no los necesite, a 18–20 tok/s. Falla, porque X2 muestra que el prefijo estable se cachea (572 de 576 tokens desde la segunda llamada) y la pared cae de 75,6 s a unos 14 s. Con el orden «lo estable primero» de N3b §3.4, el costo marginal es chico. Queda la reserva de CAT-OP-07 (reuso parcial con este modelo), que no invierte la conclusión.
3. **«Copia literal de ApiWeb + agregado» sobrevive.** La alternativa más fuerte que encontré es que la demo sea un parche (rama o `git diff`) sobre `MovilidadUrbana.ApiWeb` en su propio repositorio: el diff sería literalmente PR-17. Falla por autocontención: la guía y su demo tienen que correr desde un clon limpio de Lab-Documentos sin depender de otro repositorio. La copia con `PROCEDENCIA` y `diff` es la mejor forma de mantener esa propiedad. Las condiciones de inventario de ARQUIT-05 y SENIOR-07 no cambian esta conclusión.

## 4. Posición sobre los MI de mi mandato

Mi mandato toca las recomendaciones dominantes. Sobre los MI de mecánica (nombres, OTel, dimensión, `num_ctx`, juez) no opino.

| MI | Posición | Fundamento |
|---|---|---|
| MI-01 | alternativa | La vía C sólo corrió con un doble (`salida-fake.txt` l. 27) y «A por defecto» no aplica al asistente de la demo, que mezcla tipos de pregunta (ABOGAD-04). A y B se enseñan; C se menciona en §6 como «la misma recuperación dentro del agente» |
| MI-02 | otra | `qwen3.5:4b` provisional. La elección se cierra con una comparación punta a punta, con criterio escrito antes, sobre D1–D6, con `qwen3.5:2b` como rival en estación 1: en la sonda que decidió MI-02 empata 10/10 y 10/10 con el 4b (AD-S1) y la pared como segunda métrica (ABOGAD-02) |
| MI-03 | otra | Sí al pedido a estación 2, pero con candidato MoE (`qwen3.5:35b-a3b`, 3B activos, AD-W2) en lugar de un denso ≥ 7B. Antes, reescribir «≥ 7B no corre en estación 1»: es el límite de 5 GiB del contenedor (AD-S2) |
| MI-05 | propuesta | El ataque (parche sobre el repositorio del caso base) falla por autocontención (§3, ítem 3). Con las condiciones de inventario de ARQUIT-05 y SENIOR-07 |
| MI-07 | alternativa | Sólo escalón 0 en la demo; RAG únicamente en `Examples/05`, con un corpus que no quepa en la ventana. El árbol de §6.3 manda escalón 0 para los 12 `*Policy`, y la comparación pareada sólo puede empatar o perder (ABOGAD-03) |
| MI-08 | alternativa | ESC-02 sin candidato en la demo: el marco §4.1 completa la fila N6 con «los escenarios que la demo efectivamente cubre», y la columna ESC-02 queda en N3 y `Examples/04` (ABOGAD-03) |
| MI-09 | propuesta | Es el lugar natural del agente con aprobación si sale de la demo (ABOGAD-01). El diff 4.1 → 4.2 sostiene la regla «subir cuesta poco» |
| MI-11 | otra | M1–M12 sí como composición, pero el perímetro de la demo se decide antes (ABOGAD-05). Con la demo mínima, M3 se cumple por diseño (propuesta + operación normal) y M13 de AH-01 se aplica en `Examples/08`, no en la demo |
| MI-12 | propuesta | El ataque no encontró una alternativa mejor: GA por defecto es coherente con CTX-PROTO y con la volatilidad medida. Con ABOGAD-01, la demo puede incluso no depender de MAF |
| MI-13 | alternativa | Sólo en los ejemplos 01 y 06, como votó el senior .NET (SENIOR-06): en la demo, el selector `/v1` deja inaplicable `num_ctx` (M10). Es una pieza menos en el perímetro (ABOGAD-05) |
| MI-14 | otra | Toda escritura se confirma, sí, pero por diseño estructural: el modelo no recibe herramientas que escriban. Propone una acción tipada y la persona ejecuta la operación normal. `ApprovalRequiredAIFunction` va a `Examples/07` (ABOGAD-01; OWASP LLM06, AD-W3) |
| MI-20 | otra | La página Blazor sí, pero no como superficie principal para la pantalla chica. Lo principal son los endpoints «desde texto» con progreso por etapa; el streaming del chat transmite eventos de etapa, no sólo tokens (ABOGAD-06) |
| MI-24 | otra | La parte «sincrónico o en segundo plano»: sincrónico, pero la espera se ataca con caché del prefijo y eventos de etapa, no con el streaming de tokens (ABOGAD-06). Sobre el umbral de C2 no opino |

## 5. Solicitudes de convocatoria

- **S-ABOGAD-1 → AH-01 (seguridad).** Evaluar la alternativa de ABOGAD-01 («el modelo propone una `AccionPropuesta` tipada y la persona ejecuta la operación normal») frente a `ApprovalRequiredAIFunction`. Puntos: un id inyectado en la propuesta (inyección indirecta que cambia *qué* se borra), la confirmación desde la UI y la autorización de la operación normal.
- **S-ABOGAD-2 → CAT-OP (operación y rendimiento).** Confirmar si estación 2 tiene memoria para `qwen3.5:35b-a3b` (22 GB en `q4_K_M`) y estimar su pared por operación frente al 4b, antes de que MI-03 se apruebe con un denso ≥ 7B.
- **S-ABOGAD-3 → presidencia.** El perímetro de la demo (ABOGAD-05) condiciona parches de cuatro especialistas. Pido que se vote antes que esos parches, para no aprobar piezas que la decisión de perímetro deje sin lugar.
