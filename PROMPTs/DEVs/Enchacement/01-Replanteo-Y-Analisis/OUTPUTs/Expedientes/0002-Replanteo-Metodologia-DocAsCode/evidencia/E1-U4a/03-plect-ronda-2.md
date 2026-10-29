# E1-U4a — P-LECT parcial, ronda 2 (README, 00-Marco, 01-Mapa), 2026-10-27
# Lector sin contexto: una sesión nueva de Claude Code en modo no interactivo (claude -p), sin herramientas ni otros archivos; recibe sólo el texto de los tres documentos y la consigna de la primera línea de la entrada.
# Consigna:
#   Prueba de lectura P-LECT. Sos un lector sin contexto: estudiante de sistemas que nunca vio este repositorio ni el proyecto. No uses herramientas ni leas otros archivos: sólo el texto de abajo (tres documentos: README, 00-Marco, 01-Mapa de una guía). Recorré la ruta «aprender» hasta donde llega con estos tres documentos. Anotá TODAS las dudas concretas que el texto NO responde (términos sin definir en su primer uso, saltos, referencias a cosas que no están, contradicciones, instrucciones ambiguas). No anotes dudas que el propio texto responde más adelante: en ese caso indicá dónde. Formato de salida: una tabla Markdown con columnas | # | Documento y sección | Duda | ¿La responde el texto? (no / sí, en …) | Gravedad (alta/media/baja) |, y al final una línea «Dudas sin respuesta: N». Respondé en castellano.

Recorrí la ruta «aprender» en el orden README → 00 Marco → 01 Mapa. Ahí se corta: lo que sigue (temas, guía de un solo archivo, anexos) no está entre los tres documentos.

| # | Documento y sección | Duda | ¿La responde el texto? | Gravedad |
| --- | --- | --- | --- | --- |
| 1 | README, frontmatter | ¿Qué significan `origin: ia-assisted`, `confidence: media`, `owner` y `audience`? En `audience` se mezclan valores que parecen solaparse (`humano`/`estudiante`). ¿`confidence` tiene algún efecto? | no (todo se remite al anexo del esquema, que no está) | baja |
| 2 | README, tabla inicial | ¿Qué son los «grupos PR-1 a PR-7»? | sí, en Marco §1 (Compuerta) | baja |
| 3 | README, tabla inicial | ¿Qué hace `scripts/ci-local.sh`, qué necesita instalado y cómo se lee su salida? | no | baja |
| 4 | README §1 | «canales» aparece en la definición de sistema documentador sin estar definido | sí, en Marco §3 (CTX-SDEI-1), aunque sólo con ejemplos y sin definición general | baja |
| 5 | README §1 | ¿Qué control usa cada herramienta (lychee, markdownlint, DocFX)? DocFX no vuelve a aparecer | no | baja |
| 6 | README §2 (OBJ-SDEI-02) | ¿Cuáles son los «diez campos más `description`», cuáles son obligatorios y qué valores aceptan? Se pueden adivinar contando el frontmatter del Marco, pero no se dice | no | alta |
| 7 | README §2 (OBJ-SDEI-02) | ¿Qué control rechaza un frontmatter incompleto, y bloquea o sólo avisa? | no (el Marco §1 nombra PR-2 «frontmatter», pero la regla de bloqueo queda en un anexo ausente) | media |
| 8 | README §2 (OBJ-SDEI-03) | ¿Qué es la «escala anclada» y qué hace «firme» a una decisión? | no | media |
| 9 | README §2 (OBJ-SDEI-05) | ¿Qué es «Dado/Cuando/Entonces» y quién acepta el requerimiento? | sí, en Marco §1 (Requerimiento documental) y §4 (`ACT-SDEI-2`) | baja |
| 10 | README §2 (OBJ-SDEI-01) | ¿Cuáles son los «cuatro escenarios» y las «clases de pieza»? | sí, en Marco §2 y §2.5, y en Mapa §4 | baja |
| 11 | README §3 | El diagrama de la ruta aprender (temas → Ejercicios) no muestra el tutorial de la mini demo. La tabla lo incluye. El recorrido provisorio lo saca y agrega Glosario y Cómo decidir. ¿Cuál de los tres recorridos vale? | no | media |
| 12 | README §3, recorrido provisorio | `TEM-07` no tiene sección equivalente en la guía de un solo archivo. ¿Qué leo para ese tema? | no | media |
| 13 | README §3, recorrido provisorio | Las secciones se solapan: §1.4 va a TEM-01 y TEM-04, §5.3 a TEM-04 y TEM-05, §7.7 a TEM-05 y TEM-06. Además quedan secciones sin asignar (§6.1, §6.5…). ¿Leo la guía en su orden o en el orden de los temas? ¿Salteo lo que no está asignado? | no | media |
| 14 | README §3 | ¿Qué es la «mini demo de `Examples/`»? | sí, en README §4 (tutorial de MovilidadUrbana, en redacción) y Marco §6 | baja |
| 15 | README §4 | Los ejemplos «ayuda por rol» y «lanzar la prueba de concepto», ¿forman parte de la ruta aprender? | no | baja |
| 16 | README §4 | No se explica qué es «APA 7» | no | baja |
| 17 | README §4 | `DOC-SDT-0001` y `GP-SDEI-LANZAR` usan prefijos (`DOC-`, `GP-`) y tipos («nota de estudio», «guía práctica») que no se explican. ¿`SDT` es otro cuerpo? | no | baja |
| 18 | README §4 / Marco §2 | El caso de industria de la guía es un proveedor de notificaciones push (OneSignal) y `ESC-SDEI-4` es «un servicio de notificaciones push» privado (SDD-B). ¿Son el mismo sistema? | no | baja |
| 19 | README §5 | El árbol de carpetas no muestra `Sistema-Documentador-Tecnico-Guide.md`, que sí se enlaza en la raíz del cuerpo | no | baja |
| 20 | README §5 | Si en un cuerpo nuevo «un archivo sin frontmatter lo pone en rojo», ¿cómo sabe la compuerta que los `README.md` de ejemplos están exceptuados? | no | baja |
| 21 | README §5 | ¿Qué es una «referencia mal formada»? | no | baja |
| 22 | README §5 | La sexta sección de cada tema se llama «anexo». ¿Es lo mismo que los anexos de `99-Anexos/`? | no | baja |
| 23 | README §6 | ¿Qué es «la revisión del escalón»? | no | media |
| 24 | README §6–§7 | Se rotula «[criterio propio del plan de implementación]» antes de presentar el plan, y el rótulo no coincide con la convención del Marco §5 («[criterio propio]»). ¿Qué es el plan de implementación? | no | baja |
| 25 | README §6 | Dice que el cuerpo «reemplaza» a la guía de un solo archivo, pero esa guía sigue dentro del cuerpo, en `borrador` y no en `obsoleto`. ¿Está reemplazada o no? | no | media |
| 26 | README §6 | ¿Quién es «la persona responsable del producto» si el «producto» es una guía? | sí, en Marco §4 (`ACT-SDEI-1`, PO) | baja |
| 27 | README §6 | ¿Qué es una «etiqueta anotada»? | no | baja |
| 28 | README §6 | ¿Cómo se escribe exactamente una cita «por `corpus_id/doc_id`»? | sí, en Marco §5, fila Enlaces (`Repo@ancla:corpus_id/doc_id`) | baja |
| 29 | README §7 | No se explican «expediente 0002», D27/D28/D09/D29, «Profile de guía de estudio» ni «unidad E1-U4a» | no | baja |
| 30 | README §7 | ¿Qué es un «repositorio hermano»? | sí, en Marco §1 | baja |
| 31 | Marco §1, Compuerta | En PR-4 «estructura», ¿qué estructura se verifica? En PR-6 «contrato», ¿es el contrato de frontmatter o el contrato REST? | no | media |
| 32 | Marco §1, Compuerta | ¿Qué es «el workflow» `docs-guard`? | sí, en Marco §3 (CTX-SDEI-4: archivo `docs-guard.yml`, organización de GitHub), sin explicar más | baja |
| 33 | Marco §1, Anti-inyección | Hay cinco códigos (AI-1 a AI-5) y cuatro ítems, sin correspondencia. ¿Qué es AI-3, del que se excluye `AGENTS.md` (Mapa §4, CL-03), y por qué «por huella»? ¿Qué «lista» de dominios? | no | media |
| 34 | Marco §1, Traza | «Si el identificador cambia de versión»: ¿dónde se declara la versión de un identificador? El frontmatter no tiene campo `version` fuera del README. ¿Quién la sube? | no | alta |
| 35 | Marco §1 y §5, Traza | «Resolver contra el registro»: ¿qué registro? ¿El de prefijos, el «registro de IDs» de §2.5 o el del SDD? | no | alta |
| 36 | Marco §1 (Ficha) y §6 paso 2 | ¿Cómo cita una ficha el «símbolo» del código y cómo detecta el aviso programado que ese método cambió, si la traza apunta a un ID y no al código? | no | alta |
| 37 | Marco §1, Carril programado | ¿Cómo se detecta un «ancla atrasada»? | no | baja |
| 38 | Marco §1, Guarda de merge | ¿Dónde y en qué forma se «asienta por escrito» la delegación? ¿Cómo declara un agente una «reserva»? | no | media |
| 39 | Marco §1 vs. §4 | La guarda de merge deja que el agente fusione su propio pull request. Pero `ACT-SDEI-4` «no aprueba su propio trabajo» y la regla dice «quien verifica no es quien redactó». ¿Fusionar no cuenta como aprobar? | no | alta |
| 40 | Marco §4 (`ACT-SDEI-1`) | Sin delegación asentada, ¿quién fusiona? Y si el pull request de clase P lo abrió una persona y no un agente, ¿quién lo fusiona? | no | media |
| 41 | Marco §2 | Las fases 1a–5 se nombran pero no se explican | sí, se remiten a TEM-02 y, mientras tanto, a la guía de un solo archivo §8 (README §3) | baja |
| 42 | Marco §2 | ¿Qué cátedra y qué laboratorio? | no | baja |
| 43 | Marco §2, ESC-SDEI-1 | «Una etiqueta por compuerta»: ¿una etiqueta de Git por cada corrida de la compuerta, por cada grupo PR-n o por cada versión aprobada? | no | media |
| 44 | Marco §2 vs. Mapa §4 | ESC-SDEI-1 dice que Lab-Documentos «aloja varias guías», pero CL-10 dice que la guía vive en un «repositorio dedicado». ¿En cuál de los dos vive? | no | media |
| 45 | Marco §2, ESC-SDEI-2 | No se explica «MAUI». El repositorio se llama «WebBlazor». ¿Es app MAUI o web Blazor? | no | baja |
| 46 | Marco §2–§3 / Mapa §3 | ¿Qué formato tiene `source.lock` y quién lo actualiza? ¿Cuándo se usa `source.lock` y cuándo `base_commit`? | no | media |
| 47 | Marco §1, §2.5 vs. §3 | El escenario «fija contra qué se ancla la versión» (ESC-2: SHA en `source.lock`). Pero CTX-SDEI-3 dice que en el mismo repositorio el ancla es el commit. ¿Cuál prevalece? | no | media |
| 48 | Marco §2.5 vs. §3 | CTX-SDEI-2 «cruza los cuatro» escenarios, pero §2.5 fija clases y registro por escenario (ESC-2 no tiene CL-01). Una app sin roles con SDD, ¿activa CL-01? | no | media |
| 49 | Marco §2.5 | ¿Por qué las fichas son «provisionales» y hasta cuándo? | no | baja |
| 50 | Marco §2, ESC-SDEI-3 | ¿Qué es «la unidad que la contiene»? | no | media |
| 51 | Marco §2, ESC-SDEI-4 | ¿SDD-B es el alias del servicio o de su marco SDD? El texto dice las dos cosas | no | baja |
| 52 | Marco §2.5 | ¿Qué significa la confidencialidad «en el build y en los secretos»? | no | baja |
| 53 | Marco §3 / Mapa §3, CTX-SDEI-1 | «Ningún escenario publica sitio», pero un escenario es un tipo de sistema: ¿quiere decir ningún repositorio? No se define `llms.txt` ni por qué va «rotulado como propuesta» | no | baja |
| 54 | Marco §3, CTX-SDEI-3 | ¿Qué diferencia hay entre «repositorio hermano» y «repositorio dedicado»? | no | media |
| 55 | Marco §3, CTX-SDEI-4 | ¿Qué es un «workflow reutilizable»? ¿Quién comprueba la huella de la copia, y cuándo? | no | baja |
| 56 | Marco §4 (`ACT-SDEI-2`) | Si la analista no decide la clase de una pieza ya catalogada, ¿quién la decide? | no | baja |
| 57 | Marco §4 vs. Mapa §5 | ¿Quien estudia también evalúa con los criterios de calidad? El Marco dice que sí, el Mapa sólo se lo asigna a quien enseña | no | baja |
| 58 | Marco §5, Identificadores | La forma es «prefijo-guion-sufijo», pero hay IDs como `OBJ-SDEI-01`, `ANX-SDEI-ESQUEMA` y `DOC-SDT-0001`. ¿`SDEI` forma parte del prefijo o del sufijo? | no | baja |
| 59 | Marco §5 vs. README §5 | ¿Qué significa «[Compilado: …]»? El árbol en texto del README no tiene rótulo y es ASCII, aunque la convención dice «nunca ASCII». ¿Es una excepción? | no | baja |
| 60 | Marco §6 | La desarrolladora «va a corregir el código», pero en el paso 3 la analista todavía tiene que decidir si vale 60 u 80. ¿Qué se hace primero? ¿Quién fusiona el pull request del agente? | no | media |
| 61 | Mapa §1 | El diagrama no tiene entrada para quien sólo conoce su contexto | no | baja |
| 62 | Mapa §2, ESC-SDEI-1 | Dice «`docs-guard` completo», pero enumera cinco de los siete grupos (faltan trazas y contrato) | no | baja |
| 63 | Mapa §2 / §4 (CL-05) | Si el diff del contrato OpenAPI bloquea, ¿cómo pasa un cambio de API legítimo? | no | media |
| 64 | Mapa §2, ESC-SDEI-3 | ¿Qué significan «el cambio supera una norma del proyecto» y «cruce de rol en las pruebas de acceso»? | no | baja |
| 65 | Mapa §2, ESC-SDEI-4 | ¿Qué son las «copias fijadas de conocimiento»? | sí, en Mapa §4 (CL-11, «copiado con huella») y Marco §3 (CTX-SDEI-4, huella) | baja |
| 66 | Mapa §3, fila «mismo repositorio» | ¿Por qué un cambio de código hace que la traza «ya no resuelva», si la traza apunta a un ID y no al código? Es justo lo que pide OBJ-SDEI-04 | no | alta |
| 67 | Mapa §3, CTX-SDEI-2 | `RN-` se usa en el registro del SDD y también en las fichas propias (`RN-LOC-`). ¿Pueden chocar? | no | baja |
| 68 | Mapa §4 y §7 (pregunta 3) | ¿Qué es un «expediente» y quién decide abrir una clase nueva? | no | media |
| 69 | Mapa §4, CL-08 | No se definen «ia-db» ni `base_tag` | no | baja |
| 70 | Mapa §4, CL-11 | ¿Cuál es la «base de conocimiento común»? | no | baja |
| 71 | Mapa §4, CL-13 | ¿Qué es una «entrada en el pull request»? ¿Una entrada de CHANGELOG obligatoria? | no | baja |
| 72 | Mapa §4 | El encabezado dice «bloquea salvo indicación». ¿Vale también en carpetas heredadas? | sí, en README §5 (en carpetas sin `corpus_id` las mismas faltas sólo avisan) | baja |
| 73 | Mapa §5, `ACT-SDEI-5` | «Empiezo por… Ejercicios», pero la ruta aprender deja los Ejercicios para el final | no | baja |
| 74 | Mapa §5 vs. Marco §4 | El Mapa le asigna la documentación técnica a `ACT-SDEI-3`, pero el Marco no la incluye en lo que decide y CL-07 es de clase P. ¿Quién elige las herramientas, si no es la analista? | no | baja |

Las dudas más graves (alta) están todas en el mismo lugar: cómo funcionan las trazas (versión de un identificador, qué registro, cómo se cita el código y por qué un cambio de código rompe una traza). Ese mecanismo sostiene los objetivos OBJ-SDEI-02 y OBJ-SDEI-04, y los tres documentos no lo explican. La otra duda alta es la contradicción entre la guarda de merge y la regla de que nadie aprueba su propio trabajo.

Dudas sin respuesta: 62
