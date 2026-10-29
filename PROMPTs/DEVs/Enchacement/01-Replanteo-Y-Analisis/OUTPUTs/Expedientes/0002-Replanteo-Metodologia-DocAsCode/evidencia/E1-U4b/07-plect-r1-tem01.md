# P-LECT ronda 1, TEM-SDEI-01 (lector: sesión nueva de Claude Code, no interactiva, sin herramientas, que recibió sólo el texto del tema)

# P-LECT — Tema 01: Qué es un sistema documentador

| ID | Sección | Cita breve | Duda | Gravedad | ¿Respuesta en un doc. enlazado? |
| --- | --- | --- | --- | --- | --- |
| D-01 | Definición / Arquitectura de referencia | «El catálogo de las catorce clases está en el Mapa» | El texto nombra sólo algunas clases. CL-12 y CL-13 aparecen en la tabla de escenarios sin decir qué son. CL-04 y CL-14 no aparecen nunca. Sin el catálogo no puedo llenar la columna «Clase» de la plantilla. | alta | Sí |
| D-02 | Qué es | «piezas documentales, fuentes de verdad, repositorios, anclas de versión, compuertas, canales y actores» | «Canal» es uno de los componentes de la definición, pero no se define. Tampoco tiene columna en la plantilla. ¿Los canales se inventarían o no? | media | No |
| D-03 | Qué es (tabla de términos) | «`docs-guard`, grupos PR-1 a PR-7» | ¿Qué son los grupos PR-1 a PR-7? ¿Qué controla cada uno? | media | Sí |
| D-04 | Qué es (tabla de términos) | «Clase de pieza… fija… quién interviene» | Si la clase CL-nn ya fija D/P/H, ¿por qué la plantilla tiene una columna «Intervención» aparte? ¿Dos piezas de la misma clase pueden tener distinta intervención? | baja | Sí |
| D-05 | Qué es (tabla de términos) | «si la pieza y la fuente discrepan, manda la fuente» | Si siempre manda la fuente, ¿qué decide el actor de «Decide si discrepa» y de la pregunta guía 4? Parece que hay dos reglas distintas. | media | No |
| D-06 | Caso OneSignal | Columna «Clase» con valores «P» y «D» | En la plantilla «Clase» es CL-nn; acá la misma columna lleva D/P/H. ¿Es la intervención con otro nombre? ¿Qué CL-nn corresponde a cada fila? | media | No |
| D-07 | Arquitectura de referencia | «Conocimiento compartido CL-11 → copia con huella» | ¿Qué es el «conocimiento compartido»? ¿Qué es la «huella» (¿un hash?), cómo se calcula y quién la verifica? | media | Sí |
| D-08 | Arquitectura de referencia | «Índice para agentes, expedientes y bitácoras» | No se definen «expediente» ni «bitácora». Las bitácoras no tienen clase asignada. | media | Sí |
| D-09 | Arquitectura de referencia | «AGENTS.md CL-03» / «Índice para agentes CL-08» / `llms.txt` | ¿En qué se diferencian estas tres piezas orientadas a agentes? | baja | Sí |
| D-10 | Tabla de componentes | «asienta por escrito la delegación del merge… No necesita aprobar cada pull request de clase D o P sin reserva» | ¿Quién hace el merge de las piezas P? ¿Dónde y cómo se escribe la delegación? ¿Qué significa «sin reserva»? | media | Sí |
| D-11 | Aplicación por escenario | Columna «Fuente generada»: «OpenAPI y comentarios XML» | Los comentarios XML se escriben a mano. ¿Qué significa «generada» acá y cómo se relaciona con «fuente de verdad»? | media | No |
| D-12 | Aplicación por escenario (ESC-SDEI-1) | «CL-10, CL-12, CL-02» | ¿Qué son los «requerimientos» (CL-02) de un cuerpo de guías que no documenta un producto? ¿Qué es CL-12? | media | Sí |
| D-13 | Aplicación por escenario (ESC-SDEI-3) | «La confidencialidad: el rol se decide en el servidor» | ¿Qué consecuencia tiene esto para la documentación? ¿Afecta qué ayuda se publica o cómo se sirve? | baja | Sí |
| D-14 | Contextos (CTX-SDEI-4) | «Fuera de la organización del runner, la compuerta se copia con su huella» | ¿Qué es la «organización del runner»? ¿Una organización de GitHub? ¿Cómo sé si estoy adentro o afuera? | media | Sí |
| D-15 | Adopciones públicas | «P3. La CI revisa la prosa con un linter» — evidencia: `.vale.ini` | Que exista un archivo de configuración no prueba que la CI lo ejecute. Lo mismo pasa con P1: un commit en `content/` no prueba que el cambio entró por pull request. ¿Cómo se verificó la parte de la práctica que dice «en la CI» o «por PR»? | media | No |
| D-16 | Ensayo de inventario | «Precondición: un clon de Lab-Documentos y Python 3» | No se da la URL del repositorio ni el contenido del script. Tampoco se dice cuál es «el parser que usa la compuerta». ¿El script sirve para otro proyecto o sólo para Lab-Documentos? Sin esto no puedo cumplir el criterio «Inventario reproducible». | media | No |
| D-17 | Ensayo de inventario (lectura) | «el cuerpo de estudio (`indice`, `marco-de-referencia`, `mapa`, `anexo`) es CL-10» | `guia-practica` (5), `study-note` y `anexo-referencias` quedan sin clase. Además, el tipo `tema` (el de este mismo documento) no aparece en la salida. ¿Los temas no existían en `080f158`, o el script no los cuenta? | media | No |
| D-18 | Ensayo de inventario (lectura) | «la `rrd` y las dos `ficha`… (CL-02 y fichas de reglas)» | ¿Qué es una «rrd»? ¿Qué clase CL-nn tienen las fichas de reglas? | media | Sí |
| D-19 | Ensayo de inventario (lectura) | «Cuatro workflows… dos bloquean… y uno sólo avisa por semana» | La cuenta da tres. ¿Qué hace `framework-concept-demo.yml`? ¿Bloquea, avisa o no controla documentación? | media | No |
| D-20 | Un cambio de punta a punta | «`traces: [RN-LOC-01@1.1]`» | ¿Qué es `@1.1`? ¿La versión de la ficha? ¿Cómo convive con el anclaje `@SHA` del código? | baja | Sí |
| D-21 | Un cambio de punta a punta (paso 3) | «Si el código cambia, un agente propone actualizar la ficha… la compuerta corre» | No se dice qué detecta el cambio ni qué control se pone en rojo. ¿Algún control detectaría que la ayuda dice 60 y el código 80? Es justo lo que pide la pregunta guía 3 y lo que el tema promete («lo compruebe en cada cambio»). | alta | Sí |
| D-22 | Un cambio de punta a punta (paso 4) | «la pantalla promete 60… el campo admite 80» | Los dos valores están en el código. ¿Qué número dice la ficha? En este caso, ¿cuál es la fuente de verdad: la ficha, la pantalla o el campo? | media | No |
| D-23 | Criterios de calidad | «`CQ-01`, `CQ-11`» | No se dice qué afirma cada criterio. Sin eso no puedo aplicar la comprobación. | media | Sí |
| D-24 | Criterios de calidad | «Diff del contrato en la CI» | ¿Contra qué se compara el contrato? ¿Contra el commit anterior o contra la versión publicada? ¿Rojo ante cualquier diferencia? | baja | No |
| D-25 | Anexo (plantilla) | Control: «traces-resolve» | ¿Qué es `traces-resolve`? ¿Una compuerta de `docs-guard`? ¿Qué verifica? | media | Sí |
| D-26 | Anexo (plantilla) | «Escenario: <ESC-SDEI-n> · … · Commit: <SHA>» | ¿Qué pongo si mi proyecto no encaja en ninguno de los cuatro escenarios, o encaja en varios? Con varios repositorios, ¿el SHA de cuál? | media | No |
| D-27 | Anexo (campo Pieza) | «Si dos archivos siempre cambian juntos, ¿son una sola pieza?» | La pregunta queda sin respuesta. No hay un criterio de granularidad para cortar piezas. | media | No |
| D-28 | Anexo (campo Clase) | «Si no encaja en ninguna, ¿quién abre una clase nueva?» | El catálogo es «categoría cerrada». ¿Quién la abre y con qué procedimiento? | media | Sí |
| D-29 | Anexo (campo Ancla) | «¿Contra qué commit, SHA fijado o etiqueta vale?» | Para piezas que no dependen del código (cuerpo de guías, ESC-SDEI-1, «todo es prosa»), ¿cuál es el ancla? | media | Sí |
| D-30 | Anexo (campo Decide si discrepa) | «¿Qué actor del Marco…?» / ejemplo «Analista» | Sólo se conocen ACT-SDEI-2 (analista) y ACT-SDEI-4 (agente). Sin la lista completa de actores no puedo llenar la columna. ¿Va el nombre del rol o el ID? | media | Sí |
| D-31 | Arquitectura de referencia | «Código y comentarios XML» | ¿La arquitectura supone un stack concreto (¿.NET?)? ¿Cuál es el equivalente en otros lenguajes? | baja | No |
| D-32 | Aplicación por escenario (ESC-SDEI-1) | «Que la guía misma tenga contrato (frontmatter)» | ¿Qué campos del frontmatter son obligatorios? ¿Cuáles valida la compuerta? | baja | Sí |

Total: 32 dudas; altas: 2; medias: 23; bajas: 7
