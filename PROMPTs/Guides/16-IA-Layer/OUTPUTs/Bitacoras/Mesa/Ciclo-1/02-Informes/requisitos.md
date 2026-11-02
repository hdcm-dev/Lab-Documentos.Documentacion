---
doc_id: BIT-16-M1-INF-REQ
doc_type: informe-de-especialista
rol: Requisitos (núcleo permanente, M§4.1.1)
objeto: BIT-16-04 v0 (04-Plan-De-Integracion.md, 762 líneas)
ciclo: 1
modo: a ciegas (no se leyeron otros informes ni el resto de Mesa/Ciclo-1/)
fecha: 2026-10-26
---

# Informe de Requisitos — Ciclo 1 sobre el plan de integración v0

**Mandato.** ¿Cada solicitud del PO (S-01…S-17 de la reedición, preguntas de REED-16 §7, insumos I-01…I-06) está cubierta de forma unívoca y verificable? Trazabilidad pedido → sección/ejemplo; huecos y ambigüedades.

**Fuentes contrastadas.** Prompt de origen; reedición (REED-16 §2, §7, §9.1, §15); BIT-16-02 §5–§7; Profile Study-Guide-Documentation; insumos I-01 a I-06; N6 P6.

## Índice

- [1. Hallazgos](#1-hallazgos)
- [2. Posición sobre PR-1 a PR-22](#2-posición-sobre-pr-1-a-pr-22)
- [3. Revisado y bien](#3-revisado-y-bien)
- [4. Solicitudes de convocatoria](#4-solicitudes-de-convocatoria)

---

## 1. Hallazgos

### REQ-01 · S2 · E1/E2 · confianza 0,90 — La trazabilidad solicitud → sección quedó desfasada con el índice nuevo

- **Ubicación**: BIT-16-04 §C (índice §0–§15, siete partes), contrastado con BIT-16-02 §6 (l. 136-160) y §7, y con REED-16 §9.1 C2 (l. 356).
- **Afirmación**: el plan reordena la guía en §0–§15, pero no trae ninguna tabla S-xx → sección, y no actualiza la de BIT-16-02 §6. Esa tabla sigue apuntando a la numeración vieja: S-05 → §6, S-09 → §8, S-10 → §6. En el plan esas secciones son ahora §8, §14 y §9. La compuerta C2 se corre «sobre la tabla de trazabilidad de BIT-16-02», así que hoy verificaría contra destinos que ya no existen. Tampoco hay traza para los pedidos de los insumos que no son PR: I-01 §5 (puntos 1 a 5), I-03 §6.1, I-04 §5.2, I-05 §5.2-3 y RD-PO-1 a RD-PO-4.
- **Evidencia**: E1: `grep -c "S-[01][0-9]" 04-Plan-De-Integracion.md` → 0. E2: BIT-16-02 l. 146 «| S-05 | Creación de agentes | N4 | §6 |» y l. 150 «| S-09 | … | §8; `Demos/` |», frente al plan §C, donde «§8 Herramientas, agentes y orquestación» y «§14 Movilidad Urbana con capa de IA: la demo».
- **Impacto**: C2 y C3 corren contra un mapa obsoleto. La relectura integral no puede probar que no queden solicitudes sin sección. Cada especialista reconstruye la traza a su manera, y eso es retrabajo e interpretación divergente.
- **Dirección**: armar en la capa de origen (BIT-16-02 §6/§7, M§1.1) una matriz única y vigente. Filas: S-01…S-17, preguntas Q1–Q6 de REED-16 §7, Q-PO-1…3, RD-PO-1…4 y los «lo que la mesa decide» de cada insumo. Columnas: sección del índice nuevo, ejemplo o paso de demo, y criterio verificable (AC o compuerta). El plan remite a esa matriz en vez de duplicarla.

### REQ-02 · S2 · E2 · confianza 0,85 — «Probar todo» puede cerrarse sin una sola corrida contra el modelo

- **Ubicación**: BIT-16-04 §F.10 AC-3 (l. 692); §F.8 `ConModelo/` (l. 678); §F.6 plan C (l. 665).
- **Afirmación**: AC-3 da por cumplido «`ConModelo/` verde **o saltada con mensaje**». Con el plan C, D5 «se informa como no ejecutado contra un modelo». El plan no distingue lo que vale para la CI (saltar sin red es correcto) de lo que hace falta para el cierre. Tal como está, los ocho AC pasan aunque ninguna prueba haya tocado Qwen. Eso deja sin verificación S-17 («probar todo… usando la API local con el modelo Qwen») y la pregunta 6 de REED-16 §7 («¿qué muestra la demo funcionando contra Qwen?»).
- **Evidencia**: E2: l. 692 «`ConModelo/` verde o saltada con mensaje; cada D1–D7 con registro R-LLM y tasa en N=5»; REED-16 l. 90 (S-17) y l. 258 (pregunta 6).
- **Impacto**: la guía podría afirmar en §14.5 resultados contra el modelo que no se midieron, o callarlos sin que ninguna compuerta lo detecte. Es un requisito del PO sin criterio de aceptación que lo distinga del incumplimiento.
- **Dirección**: separar dos criterios. Uno de CI: puede saltar, con mensaje. Otro de cierre: cada D1–D7 y cada ejemplo con modelo tiene al menos un registro R-LLM ejecutado, con su tasa. Lo que no se pudo ejecutar va a `deuda_declarada`, con motivo, y a escalada tipo 2 si la causa es la falta de acceso.

### REQ-03 · S2 · E2 · confianza 0,85 — PR-3 y PR-20 figuran como «A» pero el plan las implementa con cambios no declarados

- **Ubicación**: BIT-16-04 §D, filas PR-3 (l. 481) y PR-20 (l. 498); §F.4 fila `agregar_localidad` (l. 648); §E.2 `05` (l. 545).
- **Afirmación**:
  - PR-3 pide, en el nivel intermedio, «aprobación humana para lo que escribe» y que «la demo de N6 se vuelva el hilo que recorre los tres niveles». El plan la marca **A**. Sin embargo, §F.4 deja `agregar_localidad` (escritura) «sin aprobación en la demo» y §E.4 cubre el nivel avanzado con ejemplos separados. Esos son dos apartamientos.
  - PR-20 enumera cuatro negativas («provincia fuera de catálogo, código postal inválido, localidad inexistente, sesión ajena») y también figura como **A**. `05` sólo prueba tres, porque sus herramientas de lectura no reciben código postal.
  - BIT-16-02 §5 ya había fijado «confirmación antes de escribir» como control mínimo aun en prototipo.
- **Evidencia**: E2: I-02 l. 65 «con aprobación humana para lo que escribe»; plan l. 648 «sin aprobación en la demo (**[criterio propio]** de N6 P6)»; BIT-16-02 l. 132 «(p. ej., confirmación antes de escribir)»; I-05 l. 65 (las cuatro negativas) frente al plan l. 545.
- **Impacto**: el jurado vota PR-3 y PR-20 como adoptadas sin cambios, sin ver los desvíos. Eso incumple «registrar lo que se descarta, con su motivo» (I-02 §5.4; I-05 §5.4) y deja una tensión de BIT-16-02 §5 resuelta en sentido contrario sin decirlo.
- **Dirección**: reclasificar PR-3 y PR-20 como **AC** y nombrar cada desvío con su fundamento. Para PR-3, resolver explícitamente la contradicción con BIT-16-02 §5 en la capa de origen: o la escritura validada lleva confirmación, o se corrige la regla de tensión. Para PR-20, ubicar la negativa de código postal en un ejemplo concreto (por ejemplo `06`) o declararla fuera del primer ejercicio.

### REQ-04 · S2 · E2 · confianza 0,75 — «Sumar IA a una app existente sin reescribirla» (PR-17) no tiene criterio verificable

- **Ubicación**: BIT-16-04 §D PR-17 (l. 495); §F.1 (l. 577); §F.2 (l. 593, 595, 597); §F.10.
- **Afirmación**: el encuadre central de la demo es que «reimplementa el dominio mínimo de MovilidadUrbana.ApiWeb y le **suma** la capa de IA sin reescribir sus casos de uso». Pero la misma §F.2 cambia piezas del caso base: endurece las reglas de `Domain/` (H1–H5), sube EF Core de 10.0.11 a 10.0.14, agrega `ResultadosDeEncuestaService`, omite la excepción del controller y reduce los controllers a una «copia mínima». Ningún AC de §F.10 mide la diferencia entre la copia y el commit `8fb4c3a`. Sin ese criterio, «sin reescribir» es una afirmación de la guía sin evidencia (R-PO-7).
- **Evidencia**: E2: l. 577 «le **suma** la capa de IA sin reescribir sus casos de uso»; l. 593 «**endurecimiento declarado** de las reglas»; l. 597 «EF Core Sqlite **10.0.14** (el caso base fija 10.0.11; se declara)»; F.10 sin criterio de procedencia.
- **Impacto**: §14.1 («lo que se copia y lo que es nuevo») se redactaría sin control. El lector no puede distinguir lo que exige sumar IA de lo que cambió por otros motivos, y la tesis de PR-17 queda sin evidencia.
- **Dirección**: agregar un criterio E1 de procedencia. Para cada archivo copiado, la diferencia contra `8fb4c3a` es nula o figura en una lista cerrada de desvíos declarados, cada uno con su motivo (T2, H1–H6, versión). §14.1 se escribe desde esa lista.

### REQ-05 · S3 · E2 · confianza 0,70 — Corpus escritos para el ejemplo frente a RD-PO-1/3, y barrido RD-PO-4 con alcance incompleto

- **Ubicación**: BIT-16-04 §E.1 «Dominio» (l. 509); `12` (l. 557, «70 artículos, semilla 7»); `17` (l. 567); §F.10 AC-8 (l. 697).
- **Afirmación**: I-06 fija que el caso se toma «de su ia-db y de su código» y, si una idea no encaja, ofrece dos salidas: reformular o dejarla «como explicación conceptual sin ejemplo». El plan abre una tercera vía, contenido sintético rotulado (un reglamento de 70 artículos y un documento malicioso), y no la somete a la mesa: no figura en §G.4. Además, AC-8 está entre los criterios de la demo y no declara alcance. RD-PO-2 y RD-PO-4 alcanzan también a la guía, a `Examples/` y a la bitácora.
- **Evidencia**: E2: I-06 l. 14 «tomado de su ia-db y de su código (sólo lectura)»; l. 16 «la mesa decide si se reformula o se deja como explicación conceptual sin ejemplo»; plan l. 509 «el reglamento sintético de `12`, el documento malicioso de `17`… se rotula».
- **Impacto**: la interpretación de una directiva vinculante queda tomada por un solo autor. Un barrido limitado a la demo no detecta dominio ajeno en la guía ni en los ejemplos.
- **Dirección**: llevar a §G.4 la pregunta de si un contenido rotulado «escrito para el ejemplo», con valores de `Catalogos`, cumple RD-PO-1/3, y registrar la decisión. Declarar el alcance de AC-8 (guía, `Examples/`, `Demos/` y bitácora) y enlazarlo con la relectura integral.

### REQ-06 · S3 · E2 · confianza 0,80 — Un objetivo del arquitecto no está en su ruta de lectura

- **Ubicación**: BIT-16-04 §A.3, fila ACT-ARQ (l. 98), frente a §C §0.2 (l. 315).
- **Afirmación**: OA-A3 («elegir la estrategia de conocimiento y el almacén») remite a «§6, §7», pero la ruta de ACT-ARQ en §0.2 es «§1–§4, §6, §9, §13» y no incluye §7, donde se enseñan `VectorStore` y los conectores (§7.3). El mismo plan dice que la columna de secciones de §A.3 es «la ruta de lectura por rol». Las dos fuentes de la misma traza se contradicen.
- **Evidencia**: E2: l. 98 «OA-A3 elegir la estrategia de conocimiento y el almacén … | … §6, §7»; l. 315 «ACT-ARQ §1–§4, §6, §9, §13»; l. 102 «la columna de secciones como **ruta de lectura por rol**».
- **Impacto**: el arquitecto que sigue su ruta llega a D-05 (§13.6) sin haber leído las alternativas de almacén. Es la falla de «definición antes del uso» que el propio plan quiere evitar (§A.2).
- **Dirección**: derivar §0.2 mecánicamente de la columna de §A.3, para que haya una sola fuente, y comprobar que todo OA esté dentro de la ruta de su actor.

### REQ-07 · S3 · E2 · confianza 0,70 — Dos piezas pedidas sin especificación: el criterio de elección entre anotaciones y los anexos por tema

- **Ubicación**: BIT-16-04 §B.4 (l. 249-256) y §9.3 (l. 401); patrón de §C, paso 6 (l. 307); Anexos A (l. 463).
- **Afirmación**: hay dos piezas pedidas que el plan nombra pero no especifica.
  - I-01 §5.3 pide «un cuadro comparativo de las familias de anotaciones **con el criterio de elección**». El cuadro de §B.4 no tiene columna de criterio («cuándo conviene / cuándo no»), y §9.3 sólo lo referencia.
  - El Profile exige que cada documento temático cierre con «plantilla comentada, **con las preguntas que guían cada campo**». El plan aplica el patrón de §4 a §12, pero el Anexo A sólo trae plantillas que corresponden a §4, §5, §7/§10, §8 y §13. No hay plantilla para §6 (estrategias de conocimiento), §9 (métodos y marcos), §11 (la lista del Anexo B es otra pieza) ni §12. En ningún lugar se piden las preguntas por campo.
- **Evidencia**: E2: I-01 l. 90 «Un cuadro comparativo de las familias de anotaciones (§4) con el criterio de elección»; Profile, «Estructura de cada documento temático», punto 6; plan l. 307 «anexo (plantilla en el Anexo A)» y l. 463.
- **Impacto**: Q-PO-3 se respondería con un inventario y no con criterio (R-PO-3). Cuatro secciones temáticas quedarían sin la pieza 6 del Profile, que es restricción dura.
- **Dirección**: agregar a §B.4 una columna de criterio de elección con su fuente. Asignar una plantilla del Anexo A a cada sección de §4 a §12, o declarar con motivo cuál no la lleva, y fijar que cada plantilla traiga sus preguntas por campo.

---

## 2. Posición sobre PR-1 a PR-22

| PR | Posición | Fundamento (desde Requisitos) |
|---|---|---|
| PR-1 | apoya_con_cambios | La faceta de ACT-DEV cubre el pedido sin crear un actor sin decisiones propias. Hace falta que §2.3 diga explícitamente qué decide y qué no, como pide PR-1, para que sea verificable. |
| PR-2 | apoya_con_cambios | Cubierta en §4.1. Queda abierta R-07: un hito sin fuente primaria incumple «cada hito con fuente». La alternativa de §G R-07 (nombrar sólo el modelo con su digest) es la que cumple. |
| PR-3 | apoya_con_cambios | Ver REQ-03: hay que reclasificarla como AC y declarar los dos desvíos (escritura sin aprobación; nivel avanzado fuera de la demo). |
| PR-4 | apoya | Destino unívoco: §8.10 y `Examples/14`, con números del laboratorio. Es verificable. |
| PR-6 | apoya | §15 con remisión a la sección, por escenario y por actor. Cumple. |
| PR-7 | se_opone | RD-PO-1 (I-06) es vinculante: el único caso es Movilidad Urbana. La intención didáctica queda cubierta por PR-20. |
| PR-8 | apoya_con_cambios | La investigación complementaria (N3b) se hizo antes de redactar, como pide I-03 §6.1. Hay que precisar en la matriz de REQ-01 qué parte de CAG va como texto y cuál como ejemplo (`12`). |
| PR-9 | apoya | Destino §2.4-§2.5, con fuentes de N0b. |
| PR-10 | apoya | El destino en subsecciones (§7.7, §10.7, §12.9) es explícito, y el entrenamiento queda fuera de alcance de forma consistente con BIT-16-00. |
| PR-11 | apoya | §12 visible. El despliegue real se trata conceptualmente, consistente con `fuera_de_alcance`. |
| PR-12 | apoya_con_cambios | La columna vertebral está bien fundada, pero obliga a rehacer la trazabilidad (REQ-01). |
| PR-13 | apoya | §13 con D-01 a D-10, y lo que no se decide figura con su motivo (§13.12). |
| PR-14 | apoya_con_cambios | Los 19 OA están mapeados. Falta coherencia con las rutas de §0.2 (REQ-06). |
| PR-15 | apoya_con_cambios | Como lista interna, bien. Pero «perfil del equipo» no tiene un ejemplo asignado, aunque PR-15 exige sección, ejemplo y preguntas, y conviene sumar a la lista S-01…S-17 y RD-PO-1…4. |
| PR-16 | apoya | Principio con forma operativa verificable en el código (§A.4, cinco puntos). |
| PR-17 | apoya_con_cambios | El encuadre de la demo es razonable, pero «sin reescribir» necesita un criterio E1 de procedencia (REQ-04). |
| PR-18 | apoya | Pregunta guía en §9.6, y explícitamente no se construye un marco (evita el disparador 3). |
| PR-19 | apoya_con_cambios | La fila «LangGraph por HTTP» está bien. El cuadro debe traer la columna «cuándo conviene / cuándo no» con fuente, y lo mismo el de anotaciones (REQ-07). |
| PR-20 | apoya_con_cambios | Mantener las cuatro negativas de I-05, o declarar dónde va la de código postal (REQ-03). |
| PR-21 | apoya | Anexo B anclado en OWASP 2025 y Agentic 2026, con el caso `Nombre`/`Edad`. |
| PR-22 | apoya | `Examples/08` con criterio verificable sobre los metadatos de los dos esquemas. |

PR-5 no entra en mi mandato: el orden de la escalera es materia del experto en IA y del abogado del diablo. Desde Requisitos sólo constato que el apartamiento está declarado y sometido (§G P-01), como pide I-02 §5.4.

---

## 3. Revisado y bien

1. Cada pregunta del PO de I-01 (Q-PO-1 a Q-PO-3) tiene una pregunta guía literal en §9 y la aclaración de nombres tiene subsección propia (§9.5). El pedido de I-01 §5.4 sobre ejemplos de `[MessageHandler]` (`13`, con la trampa `CS0534`) y de LangGraph por HTTP (snippet marcado «no ejecutado», P-09) queda resuelto de forma unívoca.
2. La tabla §D trata las 22 propuestas, cada una con adopción, impacto y fundamento. PR-7 NA está correctamente fundada en una directiva vinculante (RD-PO-1), y PR-18 evita explícitamente el cambio de alcance (I-05 §5.3).
3. Las preguntas 1 a 5 de REED-16 §7 tienen sección de destino: imagen en §1; GA, preview y deprecados en §5.8 y el Anexo F; RAG y cuándo no en §6-§7; agentes y LangGraph en §8-§9; prueba, observación y seguridad en §10-§12. Los 19 OA de N0b §3.3.4 están mapeados: 2 + 6 + 4 + 4 + 3 = 19.

---

## 4. Solicitudes de convocatoria

- **AH-01 Seguridad LLM**: juzgar si `agregar_localidad` sin confirmación es aceptable en CTX-PROTO, frente a BIT-16-02 §5 («confirmación antes de escribir») y PR-3. Desde Requisitos sólo señalo la falta de declaración (REQ-03); el juicio de fondo es de AH-01.
- **Senior .NET**: §F.5 dice que la sesión llega «por la cookie del circuito (página Blazor) y la resuelve `SessionHeaderMiddleware`», un middleware de encabezado. Hay que verificar que el mecanismo de sesión de la página Blazor sea viable como está descrito.
- **Verificación/QA**: §E.1 hace depender `num_ctx` de una vía no verificada (§G D-03) y la presenta como regla «siempre». Hay que evaluar si D-03 debe resolverse antes de construir `01`-`17`.
- **Presidencia o convocatoria**: I-04 §5.2 pide decidir si la señal de evaluación alcanza para convocar a AH-02. El plan no lo registra: hay que confirmar que conste en `00-Convocatoria.md`.
