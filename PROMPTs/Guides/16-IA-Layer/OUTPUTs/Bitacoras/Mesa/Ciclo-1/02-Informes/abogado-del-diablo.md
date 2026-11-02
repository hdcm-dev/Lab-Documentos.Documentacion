---
doc_id: BIT-16-MESA-C1-INF-ABOGADO
doc_type: informe-de-especialista
title: Informe del abogado del diablo sobre el plan de integración v0 y el consenso del panel — ciclo 1
rol: Abogado del diablo (núcleo permanente, M§4.1.1)
objeto: Bitacoras/04-Plan-De-Integracion.md (v0) y los once informes de Mesa/Ciclo-1/02-Informes/
modo: después de leer al resto (como pide M§4.1.1)
fecha: 2026-10-26
---

# Abogado del diablo — ciclo 1

**Mandato**: atacar la propuesta dominante (BIT-16-04 v0) y el consenso del panel. Busqué supuestos que nadie examinó, sobrealcance, elecciones tomadas por costumbre, propuestas que el panel apoya sin evidencia y lo que nadie miró. Las reglas de evidencia son las mismas (M§3): E1–E4 fundan, C sólo pregunta.

**Qué leí**: el plan completo y los once informes (arquitectura, desarrollo, didáctica, edición, IA, senior .NET, QA, requisitos, implementador ingenuo, AH-01 y AH-02). Contrasté contra N1 §2.14 y P3, N4 §1, §2.9, §2.15 y §4.7, N6 P1–P6, N3b, el Sondeo-Entorno §0, el contrato (objetivo, DC-01, DC-06, fuera de alcance) e I-05 e I-06. Las líneas citadas son las del plan v0.

**Dónde está el consenso.** El panel coincide en tres cosas: el reorden de PR-5 (arquitectura, didáctica, IA y senior .NET lo apoyan), PR-22 (seis especialistas lo apoyan y nadie se opone) y la tesis con su principio rector, que nadie discute. También coincide en corregir la estadística (IA-03, QA-02, AH-02 H-01, desarrollo H2), pero esa corrección ya está bien argumentada y no la repito. Ataco lo que el consenso dejó en pie sin revisar.

## Hallazgos

### DA-01 · S2 · E2 · confianza 0,85 — La escalera de agencia no es monótona en su propio eje: el escalón 4 contradice la fuente que justifica el reorden

- **Ubicación**: §B.3 (l. 219–226 y la tabla de l. 238–241), §E.4 `14` (l. 564), §G.4 P-01 (l. 744); también l. 207 y l. 230 («dos escaleras ortogonales» y la arista `K3 -. usa .-> G1`).
- **Afirmación**: el plan ordena la escalera de agencia por **autonomía** («cuánto decide el modelo»), y para eso usa la distinción de Anthropic entre workflows (caminos de código predefinidos) y agentes (el modelo dirige su proceso). Pero en esa misma fuente, una cadena fija de LLM (*prompt chaining*) o un par generador + evaluador **son workflows**. N4 los mapea a `BuildSequential`. El ejemplo `14`, que el plan pone en el escalón 4 «Multiagente» (por encima del agente), es justamente `BuildSequential(redactor, revisor)`: un camino fijo en código. Por el criterio del plan, ese ejemplo va en el escalón 2. El escalón 4 mezcla dos dimensiones distintas, autonomía y cantidad de agentes. Por eso la escalera deja de ser monótona en el único eje que declara. El panel apoyó el reorden mirando sólo el par workflow/agente (2↔3) y nadie revisó la cima. Hay un segundo problema en el mismo diagrama: el plan dice que las dos escaleras son «ortogonales», pero dibuja que el escalón 3 de conocimiento **usa** el escalón 1 de agencia. Entonces no son independientes: K3 exige G≥1.
- **Evidencia (E2)**:
  - Plan l. 241: «Propuesto: herramienta → workflow → agente → multiagente | Cuánto decide el modelo (autonomía)».
  - Plan l. 564: «orquestación secuencial de dos agentes (`BuildSequential`: redactor … + revisor …)».
  - N4 l. 136: «workflows = LLMs y herramientas orquestados por caminos de código predefinidos; agentes = el LLM dirige su propio proceso [F21]».
  - N4 l. 138: «Prompt chaining: secuencia fija de pasos LLM» [F21].
  - N4 l. 146: «chaining → `AddEdge` en cadena o `BuildSequential`».
  - N4 l. 29: la fila «G3. Workflow (grafo)» incluye las «orquestaciones prearmadas (secuencial, concurrente, handoff, group chat, Magentic)».
  - Plan l. 207: «las dos preguntas … son independientes»; l. 230: `K3 -. usa .-> G1`.
- **Impacto si no se corrige**: la pregunta que el plan pone en el centro de la Parte IV («¿un agente o varios?», PR-4) queda atada a un escalón «más autónomo» que el agente. Así, el lector se lleva que varios agentes son siempre más autonomía y más riesgo que uno, y eso es falso para una cadena secuencial. Además, el `14` enseña a mostrar un workflow como si fuera el escalón más alto. Cuando el lector detecte la contradicción en §3 o §8, el marco conceptual entero pierde crédito, y ese marco es lo que la guía repite en todas sus partes (l. 145).
- **Dirección**: dejar la escalera de autonomía en −1…3 y tratar «uno o varios agentes» como una **dimensión aparte** que cruza los escalones 2 y 3: secuencial y concurrente caen en el 2, y handoff, Magentic o agentes como herramientas, en el 3. Esa dimensión tiene su propia pregunta (PR-4) y su propio costo. Reemplazar «ortogonales» por «independientes salvo el RAG agéntico, que necesita herramientas», y declararlo en §3.2. Revisar el escalón asignado a `14`, a D-07 y a OA-D6.

### DA-02 · S2 · E2 · confianza 0,8 — La tesis promete «se demuestra que mejora», pero ni la demo ni los ejemplos lo demuestran nunca, y la demo sube escalones que el plan mismo declara innecesarios

- **Ubicación**: §A.1 tesis (l. 43) y respaldo (l. 52); §B.3 (l. 234); §F.1 D5 y D6 (l. 585–586); §E.4 `14`; §D PR-8 (l. 486).
- **Afirmación**: la tesis dice que se sube un escalón «sólo cuando se demuestra que mejora el resultado». La fuente que el plan cita dice menos: «only increasing complexity **when needed**». El plan, además, no tiene ningún lugar donde se demuestre una mejora entre dos escalones con el caso:
  - D5 hace RAG sobre un corpus que el plan ubica en el escalón 0 (l. 234) y rotula «didáctico: con este corpus alcanzaría el 0» (l. 585).
  - D6 usa un agente para una aprobación que es un mecanismo de M.E.AI (IA-07).
  - `14` compara uno o varios agentes con una propiedad que se cumple por construcción (IA-05, QA-04, AH01-H1).
  - `12` es la única comparación entre escalones. Usa un corpus sintético, y su calidad no se puede medir con lo disponible (QA, PR-8; IA-06).

  Con N=5, el panel ya mostró que ninguna diferencia es concluyente (QA-03). El resultado es que la guía **enuncia** un criterio y **muestra** su contrario: sube por cobertura del temario, no por necesidad. I-06 da la salida que el plan nunca evalúa: lo que no encaja en el dominio puede quedar «como explicación conceptual sin ejemplo».
- **Evidencia (E2 + E4)**:
  - Plan l. 43: «se sube un escalón sólo cuando se demuestra que mejora el resultado».
  - Plan l. 52: «Anthropic … "only increasing complexity when needed"».
  - Plan l. 585: «conocimiento 2 (didáctico: con este corpus alcanzaría el 0)».
  - N6 P3: «Con 12 enunciados, el corpus cabe entero en el prompt y RAG es, sobre todo, didáctico … Ese umbral **no se midió**».
  - N6 P1: «Si la app sólo tuviera formularios y la gente estuviera cómoda con ellos, la capa de IA sería costo sin beneficio».
  - I-06 RD-PO-3: «la mesa decide si se reformula o se deja como explicación conceptual sin ejemplo».
- **Impacto si no se corrige**: el lector copia la demo, no la nota al pie. Aprende a poner RAG, agente y multiagente en una app de ABM porque «así lo hace la guía», que es el sobrediseño que la tesis dice combatir. Además, la tesis afirma algo («se demuestra») que su propio laboratorio no puede sostener (R-PO-7).
- **Dirección**: dos opciones, a elección de la mesa.
  - (a) Bajar la tesis a lo que dice la fuente: «sólo cuando hace falta, con un criterio de salto explícito» (los de N3b §3.3 y N4 §6.1).
  - (b) Sostener «se demuestra», pero entonces la demo necesita al menos un paso que compare dos escalones con una métrica determinista. Ejemplos: llamadas y tokens entre el escalón 0 y el 2 para la ayuda, o la aprobación con `UseFunctionInvocation` solo frente a un agente.

  En las dos opciones, cada paso de la demo que está por encima del escalón necesario lo dice **en el código y en el README del paso**, no sólo en el plan. Y la mesa decide, escalón por escalón, si alguno pasa a explicación conceptual (RD-PO-3) en lugar de forzarlo sobre el caso.

### DA-03 · S2 · E2 + E4 · confianza 0,8 — El «cambio de proveedor» nunca cambia de proveedor

- **Ubicación**: §E.2 `02-Cambio-De-Proveedor` (l. 542); §C §5.6 (l. 361); §C §14 (l. 448, «diciendo qué cambiaría en CTX-NUBE»); D-02 en §13.3.
- **Afirmación**: `02` corre los dos adaptadores (OllamaSharp y SDK OpenAI contra `/v1`) contra **el mismo servidor Ollama y el mismo modelo**. Lo que demuestra es un cambio de **biblioteca cliente**. No demuestra un cambio de proveedor. Su criterio de prueba (`ChatClientMetadata` distinto y un `grep`) tampoco puede fallar por diferencias entre proveedores. Ningún especialista lo notó: ARQ-06 ataca dónde se configuran las opciones de Ollama, pero no que el experimento tenga el proveedor constante. Las diferencias que hacen que un cambio de proveedor **no** sea trivial están en el mismo plan, y todas son de Ollama:
  - no tiene `tool_choice` (l. 532);
  - `num_ctx` existe sólo en Ollama (l. 531);
  - el razonamiento viene encendido por defecto en `qwen3.5:4b` (l. 361);
  - los mínimos y descuentos de *prompt caching* sólo existen en la nube (l. 373, l. 486).

  DC-06 cierra que el código sea agnóstico y que las pruebas se hagan contra Ollama. Entonces la guía sólo puede **afirmar** que el proveedor es intercambiable, no **mostrarlo**.
- **Evidencia (E2 + E4)**:
  - Plan l. 542: «Mismo código de Application contra dos adaptadores: OllamaSharp y SDK OpenAI contra `/v1`».
  - Plan l. 361: «§5.6 Cambiar de proveedor sin tocar Application (OllamaSharp ↔ SDK OpenAI contra `/v1`)».
  - Contrato DC-06: «Código agnóstico del proveedor de modelos; las pruebas se hacen contra Ollama con Qwen».
  - Contrato, fuera de alcance: «Despliegue productivo real (Kubernetes, nube)».
- **Impacto si no se corrige**: el lector sale convencido de que pasar a la nube es cambiar una línea en `Program.cs`. Cuando lo haga, se va a encontrar con conducta distinta en herramientas, razonamiento y caché, que la guía conocía y presentó como resuelta. D-02 y OA-D1 («`IChatClient` y cambio de proveedor») quedarían respaldados por un experimento que no los prueba.
- **Dirección**:
  - Renombrar `02` y §5.6 a «cambio de adaptador sobre el mismo servidor».
  - Escribir en §5.6 y en D-02 que el cambio a otro proveedor **no se ejecutó**, y sumar una tabla de diferencias conocidas con su fuente: las de N3b §2.3 y del Sondeo.
  - Que la presidencia decida si se pide al PO una credencial de un proveedor en la nube para una corrida mínima, o si se declara la limitación (ver solicitudes).

### DA-04 · S2 · E2 + E3 · confianza 0,75 — Nadie sumó el costo del consenso: las correcciones del panel chocan con R-04 y con el presupuesto de turnos que el plan no tiene

- **Ubicación**: §E.1 (l. 529–534); §G.2 R-01, R-02 y R-04 (l. 719–722); §G.4 P-10 (l. 753); y las propuestas de IA-04, AH-02 H-05, IA-02, IA-07, H3 de desarrollo, ARQ-02, H-SN-01, AH-02 H-03 y H-06.
- **Afirmación**: desarrollo H1 ya estimó entre 3 y 10 horas de turno exclusivo para el plan **tal como está** (unas 300 llamadas). Sobre eso, el panel suma, sin estimar:
  - conjuntos de paráfrasis por capacidad (IA-03, QA-02, AH-02 H-01);
  - líneas base de azar (AH-02 H-03);
  - varias consultas no respondibles (AH-02 H-06);
  - calibración del juez con casos anotados (AH-02 H-05);
  - al menos cinco sondas previas (IA-02, IA-07, H3, ARQ-02, H-SN-01).

  Dos de esas correcciones **violan reglas que el mismo plan adopta**:
  - Un juez distinto del generador (IA-04: «otra familia o tamaño del servidor») obliga a cambiar el modelo residente del servidor compartido. Eso es lo que R-04 prohíbe y lo que el Sondeo identifica como el cuello de botella.
  - Un 7B «para calidad» en `12` tiene el mismo problema.

  P-10 sólo prevé recortar «si hay que recortar», o sea, después. La pregunta del despacho («¿cabe en una guía única?») no la responde nadie con números.
- **Evidencia (E2)**:
  - Sondeo §0: «el cuello de botella es **la cola y el cambio de modelo** … Conviene que los ejemplos y la demo usen **un solo modelo**, el que ya está residente».
  - Sondeo §1: los otros modelos «no se midieron porque cargarlos le quitaba el servidor a los demás agentes».
  - Plan l. 722: «no cambiar de modelo en la LAN».
  - IA-04, Dirección: «Usar un juez distinto del generador. Puede ser otra familia o tamaño del servidor».
  - Desarrollo H1: «entre 3 y 10 horas de turno exclusivo»; protocolo: «<recurso-compartido> (cupo 1 …, ttl 45)».
  - Plan l. 753: «Si hay que recortar: fusionar …».
- **Contraejemplo (E3)**: el ciclo 2 adopta todas las correcciones del panel. Al construir `15` con un juez de otra familia, el servidor descarga `qwen3.5:4b`. Las corridas `ConModelo/` de la demo que otro constructor tiene en curso pasan el timeout de 600 s (el mismo patrón del Sondeo l. 194). El cierre queda bloqueado por AC-3, o las pruebas se saltean con mensaje y caemos en QA-01.
- **Impacto si no se corrige**: el ciclo 2 aprueba un plan más correcto que no se puede ejecutar, y el recorte se hace a la fuerza y sin criterio cuando se acaban los turnos.
- **Dirección**: fijar **ahora** una línea de corte, con el criterio de si la lección depende de la conducta del modelo. Cada ejemplo queda en una de tres clases:
  - (a) Corrida contra el modelo obligatoria para cerrar: la lección **es** la conducta del modelo (`03`/`04` invención, `05` tool calling, `11` RAG, `17` inyección).
  - (b) Sólo cableado, porque la lección es de código: `02`, `08`, `13`, `16`.
  - (c) Conceptual o anexo: la parte de calidad de `12`, y `14` mientras no mida algo que dependa de la cantidad de agentes.

  Toda corrección del panel que exija cambiar de modelo en el servidor compartido se rechaza o se declara «no ejecutada» (R-04). El presupuesto en horas de turno se calcula con las cifras de desarrollo H1 antes de votar el resto.

### DA-05 · S3 · E2 · confianza 0,7 — PR-22, §9.7 y parte de §9 sirven a un lector que el contrato no declara; el panel los apoyó por unanimidad sin preguntar quién los necesita

- **Ubicación**: §A.3 (l. 90 y la tabla de l. 94–100); §C §9.3 y §9.7 (l. 401); §E.3 `08` (l. 553); §D PR-22 (l. 500); también §12.7 Aspire y §4.1 (12 hitos).
- **Afirmación**: el lector principal es «un desarrollador .NET sin experiencia previa en IA». Un ejemplo de migración `[KernelFunction]` → `[Description]` y una subsección «Migrar desde Semantic Kernel y AutoGen» sólo le sirven a quien **ya tiene** código de SK. Ninguno de los 19 objetivos de §A.3 cubre la migración: OA-A4 habla de «elegir marco», no de migrar. Seis especialistas apoyan PR-22 porque compila y es verificable (senior .NET, QA, IA, ingenuo, requisitos, didáctica). Nadie preguntó si le hace falta al lector. Lo mismo vale, en menor grado, para §12.7 (Aspire, con el snippet sin compilar) y para los 12 hitos de §4.1. Todo eso suma a una guía que edición ya mostró sin presupuesto de extensión (ED-05: alrededor de 90 preguntas, 16 secciones y 7 anexos).
- **Evidencia (E2)**:
  - Contrato, objetivo: «Que un desarrollador .NET sin experiencia previa en IA entienda…».
  - Plan l. 97–101: no hay ningún OA de migración.
  - Plan l. 401: «§9.7 Migrar desde Semantic Kernel y AutoGen».
  - I-05 C-1: SK es «la forma anterior»; «La guía enseña primero `[Description]` + `AIFunctionFactory`».
  - Profile: «formativo, no enciclopédico».
- **Impacto si no se corrige**: el lector principal paga carga cognitiva y extensión por un caso que no es el suyo, en la Parte IV, que ya es la más cargada (H-DID-06). Además, un ejemplo numerado le da a la migración el mismo peso que a la primera herramienta.
- **Dirección**: fijar un criterio de inclusión. Cada pieza de la guía mapea a un OA del lector principal o a un lector secundario **declarado** en §A.3, como «equipo con código SK heredado» con su ruta. Con ese criterio, `08` y §9.7 pasan a un anexo o a una ruta «si venís de SK», no a la secuencia numerada. Si la mesa quiere conservarlos en el cuerpo, que declare el lector y su objetivo.

### DA-06 · S3 · E2 · confianza 0,7 — La guía generaliza a partir de un solo modelo de 4B en CPU: lo que es conducta de este laboratorio se enseña como si fuera de la capa de IA

- **Ubicación**: §E.1 «Modelo de chat» (l. 529); §C §5.7 (l. 361); §C §14.5 (l. 450); §G.2 R-07 y R-08.
- **Afirmación**: toda afirmación del plan sobre conducta del modelo sale de un único modelo (`qwen3.5:4b`), en un servidor compartido y sin GPU, sobre una release candidate de Ollama. El plan dice explícitamente que es «el único que pasó» las pruebas. Varias lecciones que el plan pone en la **primera sección con código** son propiedades de esa combinación y no de una capa de IA: razonamiento encendido por defecto, `Text` vacío con presupuesto chico, ausencia de `tool_choice`, truncado silencioso a 4096 y latencias de minutos. Las tasas de §14.5 van a ser de ese modelo en esa máquina. El panel discutió dónde va §5.7 (H-DID-06) y la estadística (QA, AH-02), pero no el **alcance** de lo que se puede generalizar. Encima, el modelo que se usa ni siquiera tiene un hito con fuente (R-07).
- **Evidencia (E2)**:
  - Plan l. 529: «Es el único que pasó chat, tools y salida estructurada por las dos vías .NET en tiempos razonables».
  - Sondeo §0: versión «0.32.0-rc0 … una **release candidate**», `size_vram: 0`, «latencias bajo carga, no de banco exclusivo».
  - Plan l. 725: «Qwen3.5 sin hito con fuente en N1b».
- **Impacto si no se corrige**: el lector toma «apagá el razonamiento» o «Ollama no tiene `tool_choice`» como reglas de la capa de IA, y una tasa medida en CPU como la confiabilidad típica de un asistente. Por otro lado, el lector que use un modelo en la nube descarta toda la guía por «lenta» o «frágil».
- **Dirección**: separar en el patrón de cada sección dos cosas: «contrato de la abstracción», que vale para cualquier proveedor, y «conducta observada en el laboratorio», con el modelo, la versión del servidor y el hardware. Rotular con ese alcance cada cifra y cada advertencia de proveedor. Mover §5.7 a un recuadro «en este laboratorio». Y que §14.5 diga para qué conclusiones **no** alcanzan sus tasas.

### DA-07 · S3 · E2 · confianza 0,65 — La tesis define «capa de IA» por un estilo de arquitectura y excluye el caso en que su propia fuente dice que alcanza con `IChatClient`

- **Ubicación**: §A.1 tesis (l. 43) y tabla de respaldo (l. 49–50); §F.2 y §F.3 (`IAsistenteDeMovilidad`, l. 596 y l. 613); ARQ-01 (que agrega otra capa más).
- **Afirmación**: la tesis no dice «conviene», dice que una capa de IA **es** «un conjunto de adaptadores de `Infrastructure` detrás de puertos de `Application`». Su respaldo para los dos niveles de puerto es un **criterio propio de N1**. Y el mismo N1 marca la excepción: en un chat genérico, `IChatClient` puede ser el puerto. El plan crea igual cuatro puertos propios, `IAsistenteDeMovilidad` (un chat) entre ellos. Arquitectura (ARQ-01) propone sumar un caso de uso orquestador por encima. Nadie preguntó si esa ceremonia es necesaria para el lector principal en un caso cuyas capas son carpetas de un único ensamblado. Parece una elección tomada por costumbre (Clean Architecture) y convertida en definición.
- **Evidencia (E2)**:
  - Plan l. 43: «es un conjunto de adaptadores de `Infrastructure` detrás de puertos de `Application`».
  - Plan l. 50: «N1 §2.14 **[criterio propio de N1]**».
  - N1 P3: «Si el prompt y el tipo de respuesta son detalles de la funcionalidad (lo habitual), conviene un puerto de aplicación propio. Si la app es un chat genérico, `IChatClient` puede ser el puerto **[criterio propio]**».
  - N1 §2.14: «las capas son **carpetas** de un único ensamblado».
- **Impacto si no se corrige**: el glosario (C5) le da a «capa de IA» un sentido que excluye diseños válidos, como `IChatClient` inyectado en un caso de uso. El lector aprende la forma, pero no el criterio para decidir cuándo la necesita, que es lo que pide R-PO-3. Además, cada puerto suma un adaptador, un registro en DI y un doble de prueba en `Cableado/`.
- **Dirección**: enunciar la tesis como criterio y no como definición. Por ejemplo: la decisión de usar IA queda detrás de un contrato del caso de uso **cuando** el prompt y el tipo de respuesta son detalle de la funcionalidad. Enseñar en §4.4 cuándo alcanza con `IChatClient` como puerto (N1 P3) y aplicarlo en la demo al chat de D4. Así el lector ve los dos lados de la decisión.

## Posición sobre las propuestas PR (sólo donde el ataque cambia algo)

| PR | Posición | Fundamento |
|---|---|---|
| PR-5 | apoya_con_cambios | El reorden workflow → agente está bien para los escalones −1 a 3 (N4 l. 136, F21). El escalón 4 «multiagente» rompe el eje: en F21 y en N4 l. 146, una cadena secuencial es un workflow. Hay que separar autonomía y cantidad de agentes (DA-01) |
| PR-4 | apoya_con_cambios | La pregunta es buena, pero no es un escalón: cruza los escalones 2 y 3 (DA-01). Hoy ningún ejemplo la contesta con algo que dependa de la cantidad de agentes (IA-05, QA-04). Si no se rediseña `14`, la pregunta se trata en forma conceptual (DA-04) |
| PR-22 | se_opone | Como ejemplo numerado de la secuencia principal, no. No hay ningún OA que lo pida y el lector principal no tiene código SK (DA-05). Que compile (N4 V01) prueba que se **puede** hacer, no que haga **falta**. Puede ir a un anexo o a una ruta «si venís de SK» |
| PR-3 | apoya_con_cambios | Tres niveles, sí, con una línea de corte decidida antes de construir: con modelo obligatorio, sólo cableado o conceptual (DA-04) |
| PR-8 | apoya_con_cambios | Bien la distinción entre el CAG de servicio y el del paper. Pero `12` es la única comparación entre escalones de todo el plan, y su parte de calidad no se puede ejecutar (DA-02, DA-04). Se declara como «tiempos, sí; calidad, no medida» |
| PR-17 | apoya_con_cambios | Encuadre correcto. Pero la demo sobre una app existente sube escalones que el mismo plan declara innecesarios (D5). Cada paso por encima del necesario lo tiene que decir en el código (DA-02) |
| PR-2 | apoya_con_cambios | El alcance reducido es correcto, y los 12 hitos son candidatos al presupuesto de extensión (DA-05). Qwen3.5 no tiene fuente (R-07), y el alcance de las conclusiones que salen de ese modelo hay que declararlo (DA-06) |
| PR-16 | apoya | El principio sobrevive al ataque: sus invariantes se prueban en código (cero bajas sin aprobación, nunca un CP inválido) y no dependen del modelo |
| PR-7 | se_opone | Coincido con el NA: RD-PO-1 es vinculante |

## Revisado y bien (sobrevive al ataque)

1. **Escalón −1 y carril del dato exacto** (l. 228–229, 243). Es la única parte del marco que enseña a **no** subir, con un caso concreto del dominio (contar localidades → herramienta) y una fuente (MAF F01). Lo intenté atacar por el lado de la autonomía y no cae.
2. **Separación entre `Cableado/` y `ConModelo/`, con las invariantes de seguridad como aserciones de código** (§F.8, AC-4). Los ataques de DA-02 y DA-04 no la tocan: es lo que permite cortar alcance sin perder lo que el código garantiza.
3. **Los rechazos bien fundados**: PR-7 por RD-PO-1, y no levantar `langgraph dev` en Python (P-09) por DC-07. Son los únicos lugares donde el plan dice que no a algo que suma alcance, y lo hace con una regla dura.

## Solicitudes de convocatoria

- **Presidencia**: decidir si se pide al PO una credencial de un proveedor en la nube para una corrida mínima de `02` (DA-03), o si se declara en la guía que el cambio de proveedor no se ejecutó. No es una decisión técnica: tiene costo y toca R-PRIV.
- **Gestor de recursos / operación**: el presupuesto en horas de turno `<recurso-compartido>` del plan **más** las correcciones del ciclo 1, antes de que el jurado vote las correcciones que agregan corridas (DA-04).
- **Jurado**: tratar DA-01 junto con P-01. El voto sobre el reorden de PR-5 no cierra la cuestión de la cima de la escalera.
