# E1-U4a — P-LECT parcial, ronda 1 (README, 00-Marco, 01-Mapa), 2026-10-27
# Lector sin contexto: una sesión nueva de Claude Code en modo no interactivo (claude -p), sin herramientas ni otros archivos; recibe sólo el texto de los tres documentos y la consigna de la primera línea de la entrada.
# Consigna:
#   Prueba de lectura P-LECT. Sos un lector sin contexto: estudiante de sistemas que nunca vio este repositorio ni el proyecto. No uses herramientas ni leas otros archivos: sólo el texto de abajo (tres documentos: README, 00-Marco, 01-Mapa de una guía). Recorré la ruta «aprender» hasta donde llega con estos tres documentos. Anotá TODAS las dudas concretas que el texto NO responde (términos sin definir en su primer uso, saltos, referencias a cosas que no están, contradicciones, instrucciones ambiguas). No anotes dudas que el propio texto responde más adelante: en ese caso indicá dónde. Formato de salida: una tabla Markdown con columnas | # | Documento y sección | Duda | ¿La responde el texto? (no / sí, en …) | Gravedad (alta/media/baja) |, y al final una línea «Dudas sin respuesta: N». Respondé en castellano.

**Prueba P-LECT: ruta «aprender» leyendo sólo README, 00-Marco y 01-Mapa**

La ruta sigue README → Marco → Mapa y ahí se corta. El pie del Mapa manda a los temas, que todavía no existen. El README propone un recorrido provisorio, pero no dice en qué orden leerlo.

| # | Documento y sección | Duda | ¿La responde el texto? (no / sí, en …) | Gravedad (alta/media/baja) |
| --- | --- | --- | --- | --- |
| 1 | README, frontmatter | ¿Qué significan `origin: ia-assisted`, `confidence: media`, los valores de `audience` (`po`, `desarrollo`…) y `traces`? | no (Marco §5 da la sintaxis de `traces`; los vocabularios están en un anexo que no tengo) | baja |
| 2 | README, tabla inicial y §1 | ¿Qué es un «cuerpo» (`corpus_id`)? Se usa desde la primera línea y nunca se define. Se adivina que es «el conjunto de documentos de la guía». | no | media |
| 3 | README, tabla inicial («Compuerta») | ¿Qué es una «compuerta»? Aparece en la definición de sistema documentador (§1) y en todo el texto («entra por la compuerta», «da rojo»). No está en Marco §1 Definiciones, aunque el Marco dice que define cada eje «acá y en ningún otro lugar». | no (se infiere que es el chequeo de CI del pull request) | alta |
| 4 | README, tabla inicial | ¿Qué controla cada grupo de «PR-1 a PR-7»? ¿Cómo se relacionan con los controles que nombra el Mapa §2 (esquema, enlaces, anti-inyección, mermaid, referencias: son cinco), con `traces-resolve` y con «aviso AI-3»? | no | alta |
| 5 | README, tabla inicial | `scripts/ci-local.sh` «desde la raíz del repositorio»: ¿qué repositorio? ¿Qué necesito instalado? ¿Qué devuelve? | no | media |
| 6 | README §1 | «anclas de versión» | sí, en Marco §1 (Ancla de versión) | — |
| 7 | README §1 | «canales»: no se define. | no (Marco CTX-SDEI-1 da ejemplos de canales para agentes, sin definición) | baja |
| 8 | README §1 | lychee, markdownlint, mermaid, DocFX: ¿qué control implementa cada una? | no | baja |
| 9 | README §2, OBJ-SDEI-01 | ¿Cuáles son los cuatro escenarios y qué clases de pieza activa cada uno? | sí, en Marco §2 y §2.5, y Mapa §4 | — |
| 10 | README §2, OBJ-SDEI-02 | ¿Qué control rechaza una página según el campo que le falte? Con estos tres documentos el objetivo no se puede cumplir. | no | media |
| 11 | README §2, OBJ-SDEI-03 | «escala anclada» y «decisión firme»: no se definen. Sólo aparecen nombradas en la tabla de §4 (anexo Cómo decidir). | no | media |
| 12 | README §2, OBJ-SDEI-05 | ¿Qué es un «requerimiento documental»? Se usa en Marco §4, en CL-02 y en Mapa §3 (que da las columnas de la tabla), pero nunca se define. El objetivo depende de esto. | no | alta |
| 13 | README §2, OBJ-SDEI-05 | ¿Qué es un criterio «Dado/Cuando/Entonces» y cómo se escribe? | no | media |
| 14 | README §2, OBJ-SDEI-05 | ¿Quién acepta un requerimiento documental? | sí, en Marco §4 (`ACT-SDEI-2` Analista) | — |
| 15 | README §2, OBJ-SDEI-04 | El objetivo pide encontrar en el Mapa qué aplicar cuando «un cambio de código deja desactualizada una página». La introducción del Mapa da ese caso como ejemplo, pero ninguna fila lo trata. Lo más cercano es Mapa §3 CTX-SDEI-3 y el caso de Marco §6. | no | alta |
| 16 | README §3, tabla de rutas | «tutorial de la mini demo»: no figura en la tabla de contenido ni en el diagrama. ¿Es el «Ejemplo: ayuda por rol», la guía «Lanzar» u otra cosa? | no | alta |
| 17 | README §3, último párrafo | La ruta provisoria («Marco, Mapa, anexos y guía de un solo archivo») no tiene orden. ¿La guía va antes o después del Mapa? ¿Qué anexos leo y en qué orden? ¿Qué sección de la guía corresponde a cada TEM? (§4 dice que «se reparten», pero no cómo) | no | alta |
| 18 | README §3, diagrama y tabla | El diagrama no muestra la mini demo y tiene una flecha TEM → Anexos que la tabla no tiene. El texto dice que «las tres parten de este README», pero la ruta agente arranca en `AGENTS.md`. | no | baja |
| 19 | README §3, ruta intervenir | «plantilla del anexo»: ¿qué anexo? Ninguno de la tabla de §4 es una plantilla. | no | baja |
| 20 | README §4 y Mapa §2 | ¿Cuáles son «los diez campos más `description`»? Mapa §2 habla de «frontmatter de diez campos», sin `description`: ¿son 10 u 11? | no (se infiere contando el frontmatter de 00-Marco: 10 + `description`) | baja |
| 21 | README §4, guía de un solo archivo | Su `doc_id` es `DOC-SDT-0001`, con otro prefijo y otra sigla (SDT y no SDEI). ¿Es parte del cuerpo? ¿Pasa la compuerta? ¿`DOC-` está en el registro cerrado de prefijos? | no | media |
| 22 | README §4 | «el caso OneSignal» frente al servicio push privado que el Marco llama **SDD-B**: ¿son el mismo caso? Si lo son, ¿nombrarlo rompe la convención de repositorios privados? | no | baja |
| 23 | README §4 y §5 | El «Ejemplo: ayuda por rol» tiene `doc_id` y estado «—», pero §5 dice que un archivo sin frontmatter pone la carpeta en rojo. ¿Está exento? ¿Por qué? | no | media |
| 24 | README §4, Lanzar | «devcontainer» no se explica. «publicarlo»: ¿dónde? | no | baja |
| 25 | README §5, árbol | El árbol no muestra `Sistema-Documentador-Tecnico-Guide.md`, `AGENTS.md` ni `scripts/`. ¿Dónde está la raíz del repositorio respecto de esta carpeta? | no | baja |
| 26 | README §5 y §6 | «cuerpo nuevo», ¿por oposición a qué? ¿Qué le pasa a una carpeta que no lo es? La versión es 2.0.0: ¿qué fue la 1.x? | no | media |
| 27 | README §6 | Hay un problema de orden. Pasar a vigente es un pull request propio por persona, y la versión se fija en 2.0.0 «cuando el cuerpo completo pase su compuerta». ¿La compuerta pasa con todo en borrador? ¿Se pasa a vigente antes o después de 2.0.0? ¿Quién fija la versión? | no | media |
| 28 | README §6 | ¿Cómo se cita por `corpus_id/doc_id`? | sí, en Marco §5 (Enlaces: `Repo@ancla:corpus_id/doc_id`) | — |
| 29 | README §7 | No se explican «expediente 0002», «DocAsCode» (¿proyecto, repo, equipo?), las decisiones D27/D28/D09/D29, el «Profile de guía de estudio» ni la «unidad E1-U4a». ¿El estudiante puede acceder a ellos? | no | baja |
| 30 | README §7 y Marco CTX-SDEI-3 | ¿Qué es un «repositorio hermano»? Se usa sin definir. | no | media |
| 31 | README §4 y Marco ESC-SDEI-3 | ¿Qué es SDD? | sí, en README §4 (fila TEM-07) y Marco ESC-SDEI-3 | — |
| 32 | Marco §1, Contexto | «runner» no se define. | no | baja |
| 33 | Marco §2 | «sistema real del laboratorio»: ¿qué laboratorio? | no | baja |
| 34 | Marco §2 | ¿Cuáles son las «fases del ciclo» del tronco común? No se enumeran en ningún lado. | no | media |
| 35 | Marco §2 y §5 | ¿Qué significa una traza? ¿«Deriva de», «documenta a», «depende de»? §5 sólo da la sintaxis. | no | alta |
| 36 | Marco ESC-SDEI-1 | «una etiqueta por compuerta»: ¿cada vez que pasa la compuerta, en cada pull request o en cada versión? | no | baja |
| 37 | Marco ESC-SDEI-1, Mapa CL-10 y README §5 | Contradicción: el ejemplo es «este repositorio, Lab-Documentos»; CL-10 dice «Repositorio dedicado»; el árbol muestra una carpeta dentro de un repo con más cosas. ¿Cuál es? | no | media |
| 38 | Marco ESC-SDEI-1 y README §4/§5 | «sin código propio que documentar», pero `Examples/` tiene una prueba de concepto ejecutable en Blazor. | no | media |
| 39 | Marco ESC-SDEI-2 | «MAUI» no se explica. `source.lock`: ¿qué formato tiene y quién lo actualiza? | no | baja |
| 40 | Marco ESC-SDEI-3 | «caso de uso de la unidad»: ¿qué es una «unidad»? | no | media |
| 41 | Marco ESC-SDEI-4 | El alias «SDD-B» se confunde con SDD (desarrollo guiado por especificación). ¿Es casual? ¿Qué significa la B? | no | baja |
| 42 | Marco §2.5 | ESC-SDEI-1 no activa CL-03 (`AGENTS.md`). Pero la ruta agente arranca en el `AGENTS.md` de la raíz, y CL-03 dice «raíz de cada repositorio». | no | media |
| 43 | Marco §2.5 | «CL-02 a CL-07 (sin CL-01)» es redundante. ¿Quería decir otra cosa? | no | baja |
| 44 | Marco §2.5 y §6 | ¿Qué es una «ficha»? ¿Qué significan RN y LOC en `RN-LOC-nn`? ¿Por qué es «provisional» y hasta cuándo? | no | media |
| 45 | Marco §2.5, Confidencialidad | ESC-SDEI-2: «lo que viaja en el paquete», ¿qué paquete, si es una app? | no | baja |
| 46 | Marco CTX-SDEI-1 y Mapa CL-08 | No se explican `llms.txt`, «índice interno», «ia-db» ni `base_tag`. | no | baja |
| 47 | Marco CTX-SDEI-3 y Mapa §3 | «aviso programado» o «carril programado»: ¿qué es, dónde corre, quién lo recibe? | no | media |
| 48 | Marco CTX-SDEI-3 | El título nombra tres topologías, pero hermano y dedicado tienen la misma ancla. ¿En qué se diferencian? | no | baja |
| 49 | Marco CTX-SDEI-4 | «huella», ¿de qué? «organización», ¿de GitHub? ¿Cuál? | no (Mapa CL-11 sugiere SHA-256) | media |
| 50 | Marco CTX-SDEI-4 y §5 | La etiqueta `i7infra-dev` parece el nombre de un host, y §5 prohíbe hosts en lo versionado. | no | baja |
| 51 | Marco §4, ACT-SDEI-1 | No se explican «asentar la delegación del merge», «sin reserva» ni «lo fusiona la guarda». ¿Qué es la guarda? En definitiva, ¿quién fusiona un pull request? | no | alta |
| 52 | Marco §1, §4 y §6 | H es «sólo la decide una persona», y la tabla asigna lo H al PO. Pero en §6 la divergencia la decide el Analista. ¿H es cualquier persona o sólo el PO? | no | media |
| 53 | Marco §5, Trazas | `ID@MAYOR.MENOR`: ¿cómo tiene versión un identificador y dónde se declara? | no | media |
| 54 | Marco §5, Ejemplos | `[Compilado: …]`: ¿significa que el fragmento se compiló, o que se copió del código? | no | baja |
| 55 | Marco §5, Idioma | «rioplatense neutro» parece contradictorio: ¿voseo sí o no? | no | baja |
| 56 | Marco §6 | ¿Qué cambió la desarrolladora? ¿De 60 a 80? ¿Lo erróneo es la pantalla o el campo? | no | media |
| 57 | Marco §6 | «la ayuda de la demostración vive en otro repositorio»: ¿qué demostración? El único ejemplo del cuerpo es «ayuda por rol», que sería ESC-SDEI-3, no ESC-SDEI-2. | no | media |
| 58 | Marco §6 | «el símbolo cambió»: ¿qué símbolo? | no | baja |
| 59 | Mapa, intro y §1 | El Mapa está pensado para quien llega con una situación. ¿Cómo lo usa en la ruta «aprender» quien no tiene ninguna? ¿Lo lee entero? | no | media |
| 60 | Mapa, intro | Promete «el tema que lo explica», pero los temas no existen. | sí, en Mapa §1 (usar la columna «Anexo») | — |
| 61 | Mapa §2, §4 | «anti-inyección»: ¿inyección de qué? ¿Instrucciones dirigidas a agentes? | no | media |
| 62 | Mapa §2 | `traces-resolve` y «cruce de rol en las pruebas de acceso» son nombres de controles sin definir. | no | baja |
| 63 | Mapa §2, ESC-SDEI-3 | «si el cambio supera una norma del proyecto»: ¿qué es «superar» una norma? | no | baja |
| 64 | Mapa §3, CTX-SDEI-2 | Prefijos `CU-` y `RN-`: no se explican. | no | baja |
| 65 | Mapa §3 | ¿Por qué el anexo para «tiene SDD» es Ejercicios, y para CTX-SDEI-4 es Cómo decidir? | no | baja |
| 66 | Mapa §4, CL-03 | ¿Qué es el «aviso AI-3»? | no | media |
| 67 | Mapa §4, CL-11 | «Base de conocimiento común»: ¿qué es y dónde está? | no | baja |
| 68 | Mapa §4 y §7 | El catálogo es «cerrado», pero se abre una clase nueva «por expediente». ¿Quién decide abrirla? (pregunta guía 3) | no | baja |
| 69 | Mapa §4, CL-13 | Control «Entrada en el pull request»: ¿exige una entrada de CHANGELOG en cada pull request? | no | baja |
| 70 | Mapa §5, ACT-SDEI-5, y Marco §4 | Al estudiante se lo manda de vuelta al README §3 (es circular) y a Criterios de calidad, que la ruta «aprender» no incluye. Además, ¿«evaluar la guía» es tarea del estudiante? | no | media |
| 71 | Mapa, pie | «Siguiente: los temas», pero no existen y el README no dice en qué punto entra la guía de un solo archivo. La ruta queda sin salida (ver #17). | no | alta |

Dudas sin respuesta: 65
