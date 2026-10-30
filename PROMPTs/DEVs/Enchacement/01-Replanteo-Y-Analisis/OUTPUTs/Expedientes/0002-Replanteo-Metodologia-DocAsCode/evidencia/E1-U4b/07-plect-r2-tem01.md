# P-LECT ronda 2, TEM-SDEI-01 (lector: sesión nueva de Claude Code, no interactiva, sin herramientas, que recibió sólo el texto del tema)

# Prueba de lectura P-LECT — TEM-SDEI-01

Leí el tema completo sin abrir los documentos enlazados. Anoté solo las dudas que el texto no resuelve y que traban entender el tema, llenar la plantilla del Anexo o responder las preguntas guía.

| id | Sección | Cita breve | Duda | Gravedad | ¿En un enlazado? |
| --- | --- | --- | --- | --- | --- |
| D-01 | Definición › Qué es (tabla de términos) | «`docs-guard`, grupos PR-1 a PR-7» | ¿Qué son los grupos PR-1 a PR-7? ¿Qué revisa cada uno? Sin eso no sé qué poner en la columna «Control». | media | sí |
| D-02 | Definición › Qué es / Ejemplos (OneSignal) | «sólo una persona (H)» · «Guías y conceptos… Los escriben personas · P» · «aceptar una decisión de arquitectura es H» | ¿D/P/H clasifica la pieza o el acto? Si una persona escribe la pieza y otra la aprueba, ¿es P o H? Una pieza CL-01 que propone un agente pero acepta una persona, ¿qué valor lleva? La plantilla pide un solo valor por fila. | alta | sí (parcial) |
| D-03 | Arquitectura (tabla de componentes) | «asienta por escrito la delegación del merge» · «No necesita aprobar cada pull request de clase D o P sin reserva» | ¿Quién hace el merge de las piezas D y P? ¿Qué es la «delegación del merge»? ¿Qué quiere decir «sin reserva»? | media | sí (Marco, actores) |
| D-04 | Definición › Qué es | «…compuertas, canales y actores…» | «Canal» aparece entre los componentes pero no se define. Solo se infiere de CL-14 y de la wiki («puede ser un canal»). | baja | sí |
| D-05 | Qué problema resuelve / Aplicación por escenario | «Contra qué versión del código vale» · ESC-SDEI-1 «Fuente generada: Ninguna» | En el escenario de corpus de guías no hay código. ¿Contra qué se ancla una pieza ahí? | media | sí (tema 03) |
| D-06 | Arquitectura / Contextos | «copia con huella» · «la compuerta se copia con su huella» | ¿Qué es una «huella»: un hash, un SHA de origen, una entrada en un lock? ¿Quién la verifica? | media | sí (Glosario) |
| D-07 | Arquitectura de referencia | «Repositorio hermano .Documentacion» | ¿Hermano de cuál: del de código o del de guías? (el ensayo sugiere Lab-Documentos). ¿Los tres repositorios son obligatorios o son solo el caso de esta guía? | media | sí (tema 03) |
| D-08 | Arquitectura (catálogo de clases) | «CL-08 Índice interno para agentes (ia-db)» · «CL-12 Proceso «Cómo intervenir»» · «CL-02 … (RRD)» | Varias clases figuran solo por nombre. ¿Qué contiene una RRD, un ia-db o el proceso «Cómo intervenir»? Sin eso no puedo decidir si una pieza mía encaja. | media | sí (Mapa) |
| D-09 | Aplicación por escenario › Contextos | «`CTX-SDEI-4` organización del runner» | ¿Qué es «la organización del runner»: la organización de GitHub dueña del workflow? ¿Qué significa en la práctica «llamarse» frente a «copiarse»? | media | sí |
| D-10 | Aplicación por escenario / Anexo | «Escenario: <ESC-SDEI-n>» | ¿Qué hago si mi proyecto mezcla escenarios o no encaja en ninguno de los cuatro? La plantilla pide uno solo. | media | sí (Marco) |
| D-11 | Ejemplos › OneSignal | columna «Clase» con valores P/D | En esta tabla «Clase» lleva D/P, pero en la plantilla «Clase» es CL-nn y D/P/H va en «Intervención». ¿Es el mismo concepto con otro nombre? | baja | no |
| D-12 | Ensayo de inventario | «el cuerpo de estudio (`indice`, `marco-de-referencia`, `mapa`, `anexo`) es CL-10» | `guia-practica` (5), `study-note` (1), `anexo-referencias` (1) y `verificar.sh` quedan sin clase. Además falta el `doc_type: tema`, que es el de este mismo documento. ¿El commit `080f158` es anterior a los temas? | media | no |
| D-13 | Ensayo de inventario | «Cuatro workflows ejecutan controles: dos bloquean… y uno sólo avisa» | Se describen tres de los cuatro. ¿Qué hace `framework-concept-demo.yml`? | media | no |
| D-14 | Ensayo de inventario / Cambio recorrido | «dos bloquean en cada pull request (… el de la mini demo)» · «El workflow de la mini demo… **avisa**» | El workflow de la mini demo aparece una vez como bloqueante y otra como aviso. ¿Hace las dos cosas según el disparador? | media | no |
| D-15 | Ensayo de inventario | «Precondición: un clon de Lab-Documentos y Python 3» · «el mismo parser que usa la compuerta» | El script vive en Lab-Documentos.Documentacion. ¿Hace falta clonar también ese repositorio? ¿Cuál es el parser? Así como está, no puedo reproducir el ensayo. | media | no |
| D-16 | Cambio recorrido / Anexo | «la página que traza a la versión anterior queda en rojo» · «Control: traces-resolve» | ¿Qué control pone la página en rojo? ¿Es `traces-resolve`? Ese nombre aparece solo en la plantilla y nunca se explica. | media | sí |
| D-17 | Términos / Cambio recorrido | «si la pieza y la fuente discrepan, manda la fuente» · «la decide la analista (`ACT-SDEI-2`)» | Si siempre manda la fuente, ¿cuándo hace falta alguien que decida? ¿La fuente de una regla es el código o la ficha? Falta la distinción entre discrepar con la fuente y que la fuente esté equivocada. | media | sí (parcial) |
| D-18 | Criterios de calidad | «Diff del contrato en la CI» | ¿Diff contra qué: el contrato versionado frente al emitido en el build? ¿Falla si difieren? | baja | no |
| D-19 | Criterios de calidad | «Toda clase activa tiene un control» | ¿Cómo sé qué clases están «activas» en mi proyecto? ¿Las fija el escenario o el inventario? | media | sí (Mapa) |
| D-20 | Anexo (plantilla) | «Commit: <SHA>» | Con piezas repartidas en dos o tres repositorios, ¿de cuál es el commit? ¿Va uno por repositorio? | media | no |
| D-21 | Anexo (plantilla) | «Se llena una fila por pieza» · «¿son una sola pieza?» | ¿Las 12 páginas de ayuda son 12 filas o una? La granularidad queda planteada como pregunta, sin criterio. | media | no |
| D-22 | Anexo (guía de campos) | «¿quién abre una clase nueva?» | Las clases son una «categoría cerrada», pero se admite abrir una nueva. ¿Quién la abre y cómo? | baja | sí (Mapa) |
| D-23 | Cambio recorrido | «Cuando alguien actualiza el SHA fijado» | ¿Quién actualiza el SHA y cuándo: a mano, por un agente, por cada aviso? | baja | sí (tema 03) |
| D-24 | Cambio recorrido | «`traces: [RN-LOC-01@1.1]`» · «subir su versión» | ¿Qué esquema de versión siguen las fichas? ¿Qué cambio obliga a subir la versión? | baja | sí |

Total: 24 dudas; altas: 1; medias: 17; bajas: 6
