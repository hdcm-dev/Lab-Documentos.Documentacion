# P-LECT ronda 3, TEM-SDEI-02 (lector: sesión nueva de Claude Code, no interactiva, sin herramientas, que recibió sólo el texto del tema)

# Prueba P-LECT: TEM-SDEI-02, «El ciclo documental»

Encontré 31 dudas que el texto no responde. Tres bloquean aplicar el tema: cómo se asigna la clase D/P/H, qué comprueba `traces-resolve` y qué estado toma una página `vigente` que vuelve al ciclo. La mayoría de las dudas medias son de ubicación y de responsables: dónde vive el RRD o la delegación, quién decide a qué fase vuelve una pieza y quién la pasa a `obsoleto`.

| ID | Sección | Cita | Duda | Gravedad | ¿En un enlace? |
| --- | --- | --- | --- | --- | --- |
| D-01 | Definición: tabla de fases (5m) | «Propone la corrección (vuelve a 1a o a 4)» | El agente propone a qué fase vuelve la pieza, pero no se dice quién lo confirma. Tampoco se dice qué pasa si cambian a la vez la necesidad de la audiencia y lo que dice la fuente. | media | no |
| D-02 | Definición: clases de intervención | «**D**… **P**… **H**, sólo la decide una persona» | No se dice cómo se determina qué clase de intervención tiene un cambio o una pieza, ni quién la asigna, ni en qué fase. Sin eso no se puede saber si un agente puede fusionar en la fase 5. | alta | sí (Marco) |
| D-03 | Definición: clases de intervención | «nadie declaró una duda que devuelva el merge a una persona» | No se dice cómo, dónde ni quién declara una «reserva» (¿un comentario en el PR, una etiqueta, un campo?). | media | sí |
| D-04 | Tabla de fases (1b) frente a Aplicación por escenario | «Acepta, rechaza o difiere cada fila (`ACT-SDEI-2`)» | La tabla ata la fase 1b al actor `ACT-SDEI-2` (Analista, según la cláusula de ejemplo). Los escenarios dicen que decide la persona docente o el PO. ¿La tabla vale sólo para un escenario, o `ACT-SDEI-2` es otra cosa? | media | no |
| D-05 | Tabla de fases (1a y 2) | «Inventario hecho por comando» | No se dice qué comando, ni qué contiene el inventario. Además, el inventario de pantallas y endpoints es entrada de 1a y a la vez salida de 2: ¿de dónde sale el de 1a? | media | sí |
| D-06 | Tabla de fases (2) y escenarios | «fichas de reglas ancladas al SHA» / `RN-LOC-01@1.1` | No se explica qué es una ficha de regla, su formato ni cómo se ancla. Tampoco cómo se relaciona el anclaje al SHA con la versión `@1.1` que se cita en `traces`. | media | sí |
| D-07 | Tabla de fases (2) | «Decide las divergencias entre lo que la regla dice y lo que se quiso» | No queda claro si «la regla» es el código o la especificación. Tampoco se dice dónde queda registrada la decisión sobre la divergencia. | media | no |
| D-08 | Tabla de fases (2) y ejemplo RD-01 | «cada número coincide con el de la ficha; instrumento: `traces-resolve`» | No se dice qué comprueba `traces-resolve`. Si sólo resuelve que los IDs existen, no puede verificar que los números coinciden, y el ejemplo modelo de criterio comprobable no lo sería (afecta a la pregunta guía 3). | alta | sí |
| D-09 | Tabla de fases (3) | «decisión de arquitectura propuesta» | No se dice si hace falta siempre o sólo en algunos casos, qué formato tiene (¿un ADR?) ni dónde se guarda. | media | sí |
| D-10 | Tabla de fases (4) | «Grupos PR-1 a PR-7 de `docs-guard`» | Sólo se ve qué hace PR-2 (el esquema). No se sabe qué verifican los otros grupos. | baja | sí |
| D-11 | Tabla de fases (5) | «Merge; anclas fijadas» | No se dice qué es «fijar un ancla», quién lo hace ni con qué. | media | sí |
| D-12 | Tabla de fases y ensayo | «compuerta», «`docs-guard`», «guarda de merge» | No queda clara la relación entre los tres términos: ¿son el mismo control o controles distintos? | media | sí (Tema 01) |
| D-13 | Tabla de fases (5) | «Pasa a `vigente`, etiqueta, publica» | No se dice qué se etiqueta (¿un tag de git, un release?) ni dónde se publica. | baja | sí |
| D-14 | El RRD | «Junto a la especificación de la unidad de entrega» / «el RRD lo referencia» | Con un marco de especificación, no se dice con qué nombre ni con qué formato vive el RRD. Cuando la documentación es una función del producto, no se dice dónde vive el RRD que «referencia». | media | sí |
| D-15 | El RRD frente a `CTX-SDEI-3` | «`docs/_requisitos.md` del árbol que documenta» | Si la pieza está en otro repositorio, no se dice en cuál va el RRD: ¿el del código o el de la documentación? | media | no |
| D-16 | Estados del documento | «Un documento `obsoleto` dice cuál lo reemplaza» | No se dice quién pasa un documento a `obsoleto` (¿es un acto H?) ni en qué campo indica su reemplazo. La plantilla no tiene ese campo. | media | sí (esquema) |
| D-17 | Estados del documento y la vuelta por deriva | «vuelve a **4**: se corrige el texto…» | Si una página `vigente` vuelve a 4 o a 1a, no se dice si pasa otra vez a `borrador`. Tampoco si hace falta otro PR propio de clase H para volver a `vigente`. | alta | no |
| D-18 | Qué no es | «un cambio chico recorre 1a a 5 en un solo pull request» | Esto parece contradecir que «pasar a `vigente` es… en un pull request propio». ¿Un cambio chico termina en `borrador`? | media | no |
| D-19 | Estados del documento | «avisa cuando `last_review` tiene más de un año» | No se dice quién actualiza `last_review`, ni cuándo. Tampoco si una corrección en la fase 4 lo renueva. | media | no |
| D-20 | Cláusulas con criterio | «La metodología misma se escribe como cláusulas» | No se dice si un proyecto está obligado a escribir cláusulas, en qué fase se escriben ni quién las aprueba. | media | no |
| D-21 | Ejemplo de cláusula frente a la plantilla del Anexo | `id`: `CLA-1b-01` frente a `### CLA-01` | El ejemplo tiene un campo `id` que la plantilla no tiene, y los dos usan formatos de ID distintos. ¿Cuál es el correcto? | baja | no |
| D-22 | Ejemplo: delegación | «Delegar una decisión de clase H también es un acto H» | No se dice si se puede delegar la decisión de 1b en un agente. Tampoco si un grupo («la mesa») cumple la condición de la plantilla «¿es una persona?». | media | sí |
| D-23 | Ejemplo: delegación | «la delegación del merge está escrita en el `CHANGELOG.md`» | El texto dice dónde está la delegación del merge, pero no dónde quedó escrita la delegación del PO a la mesa para decidir en 1b. | media | sí (mini demo) |
| D-24 | Pregunta guía 4 frente a `CTX-SDEI-3` | «el pull request del código no ve la página» | Si la pieza está en el mismo repositorio que el código, no se dice si la compuerta del PR (fase 5) detecta la deriva o si sólo la detecta 5m. Hace falta para responder la pregunta 4. | media | no |
| D-25 | Ensayo reproducible | «Precondición: Python 3, un clon de Lab-Documentos y el script» | Falta la URL o el host de los dos repositorios. El script es `.sh`, así que también hace falta bash. No se dice si hay que hacer checkout de `080f158` para obtener la misma salida. | media | no |
| D-26 | Ejemplo y Fuentes | «expediente 0002 de DocAsCode», «La mesa» | No se dice qué es un «expediente» ni qué es DocAsCode. | baja | sí |
| D-27 | Criterios de calidad | «Toda página responde a una fila del RRD» | No se dice si la referencia generada (clase D) también necesita su fila `RD-`. | baja | no |
| D-28 | Tabla de fases (5m) | «Carril programado semanal» | No se dice qué es un «carril» ni dónde se configura. | baja | sí |
| D-29 | Ejemplo RD-01 | `traces: [RD-01, RN-LOC-01@1.1, …]` | No se explica por qué `RD-01` va sin versión y las reglas van con versión, ni cuándo se versiona un ID. | baja | sí (esquema) |
| D-30 | Anexo: plantilla | `doc_id: <PREFIJO-NN>` | No se dice qué prefijo corresponde a un documento `doc_type: rrd`. | baja | sí (esquema) |
| D-31 | Qué problema resuelve frente a la tabla de fases | «lo que el agente propone (1a, 2, 4)» | La tabla también muestra al agente en la fase 3 (redacta la decisión) y en la 5 (fusiona). ¿Se omitieron a propósito? | baja | no |

Total: 31 dudas; altas: 3; medias: 19; bajas: 9
