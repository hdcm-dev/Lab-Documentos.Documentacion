---
doc_id: BIT-16-MESA-C1-06
doc_type: aprobacion
title: Ciclo 1 · Mesa de decisión sobre los parches (M§5.5)
version: v1
status: cerrado
origin: agent (secretaría; transcribe las decisiones)
last_review: 2026-10-26
traces: [BIT-16-MESA-C1-05, M§5.5]
---

# Ciclo 1 · Aprobación de los parches

Resultados posibles (M§5.5): `APLICAR`, `MEJORAR_PLAN`, `NO_APLICAR`, `ESCALAR`. Conteo: A aplicar · M mejorar plan · N no aplicar · E escalar, sobre los cinco jueces. Decide la mayoría.

## Decisiones

| Parche | Sección | Capa | Resultado | Conteo | Objeciones | Chequeo de capa de origen |
|---|---|---|---|---|---|---|
| PAR-01 | §A.1 Tesis | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR-02 | §A.2, §A.3, §C Parte 0, §15 | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR-03 | §A.4, §B.2, §F.3 | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR-04 | §B.3, §B.4, §C §8, §G.4 P-01 | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR-05 | §C preámbulo y Anexos | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR-06 | §C §1–§3 | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR-07 | §C §4–§5 | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR-08 | §C §6–§7 | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR-09 | §C §9 | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR-10 | §C §10–§12, Anexo B | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR-11 | §C §13–§14 | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR-12 | §D | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR-13 | §E.1 | plan | **APLICAR** | A4-M1-N0-E0 | ver §2 | correcta |
| PAR-14 | §E.2–§E.4 | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR-15 | §E.5 (nueva) | plan | **APLICAR** | A3-M2-N0-E0 | ver §2 | correcta |
| PAR-16 | §F.1–§F.2 | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR-17 | §F.4–§F.5 | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR-18 | §F.6–§F.7 | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR-19 | §F.8–§F.10 | plan | **APLICAR** | A4-M1-N0-E0 | ver §2 | correcta |
| PAR-20 | §G | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR-21 | BIT-16-02 §5 y §6; REED-16 | capa de origen (cohesión y reedición) | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR-22 | N6 (nota) | capa de origen (dossier N6) | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR-23 | N0b (nota) | capa de origen (dossier N0b) | **APLICAR** | A5-M0-N0-E0 | — | correcta |
| PAR-24 | §H y frontmatter | plan | **APLICAR** | A5-M0-N0-E0 | — | correcta |

Resumen: 24 de 24 `APLICAR`; 21 por unanimidad (A5), 3 por mayoría con votos `MEJORAR_PLAN` en minoría (PAR-13, PAR-15, PAR-19). Ningún `NO_APLICAR` (no hay deuda declarada por rechazo) ni `ESCALAR`. Proporción unánime: 21/24 = 88 %, también por encima del 80 % (M§9): se suma a la sospecha de homogeneidad registrada en `04-Veredictos.md`.

Chequeo obligatorio de capa de origen (M§5.5): los tres jueces que lo explicitaron (impacto, evidencia, costo-beneficio) lo dan por correcto en los 24 parches. Los defectos que nacieron en BIT-16-02, REED-16, N6 y N0b se corrigen ahí (PAR-21, PAR-22, PAR-23) y el plan sólo remite. Ningún ítem activa un disparador de M§6: P-12 queda dentro de la facultad que RD-PO-3 le da a la mesa; P-13 evita sumar un secreto; SUP-09 concreta SUP-06 sin reabrirlo.

## 2. Objeciones minoritarias (texto de los votos `MEJORAR_PLAN`)

Las objeciones no cambian el resultado (`APLICAR` por mayoría). Como cada una señala un defecto que el propio parche introduce y se arregla con una línea, la secretaría las aplicó como **ajustes declarados**, reversibles y sujetos a ratificación en el ciclo 2: AJ-01 (PAR-13), AJ-02 y AJ-03 (PAR-15), AJ-04 (PAR-19). Detalle en `07-Aplicacion-Y-Verificacion.md` §2.

### PAR-13 · juez de impacto (MEJORAR_PLAN)

> El hallazgo es válido y casi todo el parche es correcto: transitive pinning, una sola capa de opciones, la entrada distinta como unidad, el esquema R-LLM sin endpoint ni host. La objeción concreta es que el parche introduce un riesgo nuevo sobre R-04. La regla dice que en el servidor compartido OLLAMA_NUM_CTX tiene que ser igual al context_length leído de /api/ps (65.536), pero el default del código cuando falta la variable es 8192, y verificar.sh --con-modelo sólo envuelve dotnet test en <gestor-de-turnos>: nadie lee /api/ps. Si alguien corre con modelo contra <recurso-compartido> sin la variable, cada llamada sale con num_ctx 8192, Ollama recarga qwen3.5:4b, perjudica a los demás clientes y se pierde la caché (justo lo que R-04 prohíbe). La guarda de truncado no lo evita. Pedido: que verificar.sh --con-modelo lea context_length de /api/ps dentro del turno y exporte OLLAMA_NUM_CTX; si eso falla, que aborte sin llamar al modelo. Y que el default 8192 se declare sólo para el servidor propio o para el lector en su máquina, con un rechazo explícito cuando servidor=compartido y la variable no viene del arnés. Agregar a la verificación una prueba de cableado que compruebe ese rechazo.

### PAR-15 · juez de evidencia (MEJORAR_PLAN)

> El hallazgo H-021 es válido, pero el parche declara como «medido» un rango que la evidencia contradice. Escribe «llamadas medidas de 11 a 200 s» y fija 200 s como pesimista. Lo medido es otra cosa. N3b X3 registra 474,7 s y 395,9 s por llamada con qwen3.5:4b y un prefijo de 4.441 tokens (9,4 tok/s), confirmado contra run1.jsonl. Sondeo §0/§2 registra 68,8 s, un GetResponseAsync que pasó los 600 s sin primer byte y un timeout de 300 s. […] A 9,4 tok/s de prompt, cualquier llamada con más de unos 1.900 tokens de entrada supera 200 s, y eso alcanza a 07 (contexto top-k más instrucciones) y a 11 (esquemas de herramientas más historial en dos peticiones). Las horas del nivel A (8,0 h pesimista) y el tope de 4 h quedan subestimados por construcción. Objeción concreta: (1) reemplazar el rango por «respuestas cortas de 11 a 24 s con razonamiento apagado (Sondeo §8); 474,7 s con un prefijo de 4.441 tokens (N3b X3); bajo carga, más de 600 s sin respuesta (Sondeo §0)»; (2) estimar t por ejemplo a partir de los tokens de prompt previstos (t ≈ p/9,4 + s/4, más la carga) […]; (3) recalcular las horas de A y B y la línea de corte con esos t, conservando DEP-13 como recalibración.

El mismo juez señaló «dos imprecisiones menores que se corrigen al aplicar (en PAR-10 y PAR-17)» sin detallarlas. La secretaría corrigió en PAR-10 el mismo rango «11 a 200 s» en §12.7 (AJ-02). En PAR-17 no identificó ninguna imprecisión verificable y lo deja como pregunta para el ciclo 2.

### PAR-15 · juez de costo-beneficio (MEJORAR_PLAN)

> El hallazgo H-021 vale y el presupuesto es imprescindible. Objeción concreta: la línea de corte no alcanza para respetar el tope en el escenario pesimista que el propio parche calcula. El nivel A da 8,0 h pesimistas contra un tope de 4 h. El orden de recorte […] ahorra unas 24 llamadas, unas 1,3 h a 200 s, y A queda en unas 6,7 h, por encima del tope. La salida «o hay acta» no puede ser el camino previsto. Corrección: (a) extender el orden de recorte hasta que A pesimista quede ≤ 4 h, o (b) definir una prioridad dentro de A, con PD-1…PD-6 y 07/08/09 primero, por la que lo que exceda el tope pasa a «no ejecutado contra el modelo», sin cifras y como deuda, igual que el nivel B. Además, la verificación (2) debe recalcular las horas de A después del recorte con el t que dé DEP-13.

### PAR-19 · juez de impacto (MEJORAR_PLAN)

> El hallazgo es válido y casi todo el parche es correcto (AC-3a/3b, AC-4 con toda escritura, AC-7 sobre todo lo que se escribe, listas fuera del repo, AC-9 y AC-10). La objeción concreta es que la celda de AC-8 se contradice: el patrón de texto incluye incidentes (la forma con s opcional) y dos oraciones después dice que «incidente» como palabra común no entra al patrón de texto. […] Pedido: elegir una sola regla. Propuesta: mantener incidentes en el patrón, porque es un dominio ajeno, borrar la oración que lo excluye, y listar como excepciones con motivo las ocurrencias que nombran la prohibición […]. «Línea» sigue fuera del patrón de texto y queda sólo como identificador de código.

Las objeciones se transcriben sin el preámbulo común de cada juez (su función objetivo y el recuento de sus votos), marcando los cortes con […].
