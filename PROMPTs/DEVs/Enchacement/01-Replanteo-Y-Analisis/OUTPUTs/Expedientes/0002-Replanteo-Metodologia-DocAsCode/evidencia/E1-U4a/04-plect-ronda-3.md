# E1-U4a — P-LECT parcial, ronda 3 (README, 00-Marco, 01-Mapa), 2026-10-27
# Lector sin contexto: una sesión nueva de Claude Code en modo no interactivo (claude -p), sin herramientas ni otros archivos; recibe sólo el texto de los tres documentos y la consigna de la primera línea de la entrada.
# Consigna:
#   Prueba de lectura P-LECT. Sos un lector sin contexto: estudiante de sistemas que nunca vio este repositorio ni el proyecto. No uses herramientas ni leas otros archivos: sólo el texto de abajo (tres documentos: README, 00-Marco, 01-Mapa de una guía). Recorré la ruta «aprender» hasta donde llega con estos tres documentos. Anotá TODAS las dudas concretas que el texto NO responde (términos sin definir en su primer uso, saltos, referencias a cosas que no están, contradicciones, instrucciones ambiguas). No anotes dudas que el propio texto responde más adelante: en ese caso indicá dónde. Formato de salida: una tabla Markdown con columnas | # | Documento y sección | Duda | ¿La responde el texto? (no / sí, en …) | Gravedad (alta/media/baja) |, y al final una línea «Dudas sin respuesta: N». Respondé en castellano.

Con estos tres documentos, la ruta «aprender» llega hasta el final del Mapa. El paso siguiente es la guía de un solo archivo (o los temas, que todavía no existen) y no está entre lo que recibí.

| # | Documento y sección | Duda | ¿La responde el texto? (no / sí, en …) | Gravedad (alta/media/baja) |
| --- | --- | --- | --- | --- |
| 1 | README, frontmatter | ¿Qué significan `origin: ia-assisted`, `confidence: media` y `doc_type`, y qué valores admiten? | no (sólo remite al anexo del esquema) | baja |
| 2 | README, frontmatter | ¿Qué es `po` en `audience`? | sí, en Marco §4 (`ACT-SDEI-1`) | baja |
| 3 | README, tabla inicial | ¿Qué es un «cuerpo» (`corpus_id`)? | sí, en Marco §1 («Cuerpo documental») y README §5 | baja |
| 4 | README, tabla inicial | «Grupos PR-1 a PR-7»: ¿qué número le toca a cada grupo? ¿«PR» quiere decir pull request? | no (Marco §1 da siete nombres en orden, pero no los numera) | baja |
| 5 | README, tabla inicial | ¿Qué corre `scripts/ci-local.sh`, qué necesita instalado y si equivale a `docs-guard`? | no | media |
| 6 | README §1 | «Canales» aparece en la definición de sistema documentador y nunca se define | no (Marco CTX-SDEI-1 los usa sin definirlos y remite al Glosario) | media |
| 7 | README §1 | ¿Qué es una «pieza»? | sí, en Marco §1 («Clase de pieza») y Mapa §4 | baja |
| 8 | README §1 | lychee, markdownlint y DocFX: ¿qué control usa cada uno? DocFX no vuelve a aparecer | no | baja |
| 9 | README §2, OBJ-01 | ¿Cuáles son los «cuatro escenarios del marco»? | sí, en Marco §2 y §2.5 | baja |
| 10 | README §2, OBJ-02 | ¿Qué control rechaza un frontmatter incompleto? | sí, en Marco §1 (Compuerta, grupo «frontmatter») y README §5 | baja |
| 11 | README §2, OBJ-03 | «Escala anclada» y «decisión firme» no se definen: el objetivo usa conceptos que sólo nombra la tabla §4 | no | media |
| 12 | README §2, OBJ-05 | ¿Qué es Dado/Cuando/Entonces y quién acepta el requerimiento? | sí, en Marco §1 («Requerimiento documental») y §4 (`ACT-SDEI-2`) | baja |
| 13 | README §3, diagrama | En el diagrama, la ruta aprender va de TEM a Ejercicios sin el tutorial de la mini demo, y la tabla sí lo incluye | no | baja |
| 14 | README §3 | ¿`AGENTS.md` existe? El diagrama lo da «en redacción», pero la ruta agente empieza ahí y en Mapa CL-03 el control exige que exista en la raíz de cada repositorio | no (contradicción) | media |
| 15 | README §3, diagrama | «Plantilla del anexo»: ningún anexo de §4 es una plantilla, y Mapa CL-12 dice «plantilla en el cuerpo». ¿Dónde está? | no | baja |
| 16 | README §3 | El orden provisional omite el tutorial y agrega Glosario y Cómo decidir. ¿El tutorial se saltea mientras tanto? | no | media |
| 17 | README §3 | Las correspondencias se solapan: §1.4 cae en TEM-01 (§1–§4) y en TEM-04; §7.7 cae en TEM-05 (§7) y en TEM-06 | no | media |
| 18 | README §3 | TEM-07 (SDD) no tiene secciones asignadas, y §6.1 tampoco aparece. ¿Cómo se cubre ese tema en la ruta provisional? | no | alta |
| 19 | README §3 y Mapa, cierre | ¿La guía de un solo archivo se lee de corrido o en el orden de los temas (§1–§4, §8, §6.2…)? El Mapa remite al «orden que da el README», y el README no lo aclara | no | alta |
| 20 | README §4 | «SHA» se usa en todo el cuerpo y nunca se define | no | baja |
| 21 | README §4 | La guía de un solo archivo tiene `doc_id` `DOC-SDT-0001`, con sufijo SDT y no SDEI, aunque «está dentro del cuerpo». ¿Por qué? | no | baja |
| 22 | README §4 | ¿Por qué el ejemplo de ayuda por rol no tiene `doc_id` ni estado? | sí, en README §5 (los README de ejemplos no llevan frontmatter) | baja |
| 23 | README §4 / Marco §2 | Blazor, MAUI y devcontainer no se explican | no | baja |
| 24 | README §5, árbol | El árbol no muestra `Sistema-Documentador-Tecnico-Guide.md`, aunque esa guía está dentro del cuerpo | no | baja |
| 25 | README §5 | ¿Qué cuenta como «referencia mal formada»? | no | baja |
| 26 | README §5 | El bloque `text` del árbol no lleva rótulo de origen, y Marco §5 lo exige para todo fragmento | no (contradicción) | baja |
| 27 | README §6 | ¿Qué es «la revisión del escalón»? | no | media |
| 28 | README §6 | El rótulo «[criterio propio del plan de implementación]» no coincide con «[criterio propio]» de Marco §5, y el plan no se explica | no (§7 sólo lo nombra) | baja |
| 29 | README §6 | «Una persona pasa cada documento a vigente»: ¿es el PO, como dice Marco §4, u otra persona? | no | media |
| 30 | README §6 | El cuerpo «reemplaza» a la guía de un solo archivo, pero esa guía sigue dentro del cuerpo, en borrador, y es lectura obligada de la ruta | no (contradicción) | media |
| 31 | README §6 | SemVer y «etiqueta anotada» no se definen | no | baja |
| 32 | README §6 | Estado `obsoleto`, «ir al reemplazo que indica»: ¿qué campo indica el reemplazo? | no | baja |
| 33 | README §6 | ¿Con qué formato exacto se cita `corpus_id/doc_id`? | sí, en Marco §5 («Enlaces») | baja |
| 34 | README §7 | No se explica qué son DocAsCode, un «expediente», las decisiones D27/D28/D09/D29, la «unidad E1-U4a» ni el «Profile de guía de estudio» | no (Mapa CL-09 sólo dice dónde viven los expedientes) | media |
| 35 | README §7 | ¿Qué es el repositorio hermano? | sí, en Marco §1 | baja |
| 36 | Marco, introducción | Dice que cada eje «se define acá y en ningún otro lugar», pero el catálogo CL está en el Mapa y README §1 define «sistema documentador» | no (contradicción) | baja |
| 37 | Marco §1, Clase de pieza | ¿Qué es `AGENTS.md` y qué contiene? | no | media |
| 38 | Marco §1, Contexto | ¿Qué es un runner? | sí, en Marco §1 (última fila) | baja |
| 39 | Marco §1, Compuerta | El grupo «contrato», ¿es el contrato REST o el «contrato de frontmatter» del que habla el README? | no | media |
| 40 | Marco §1, Anti-inyección | Hay cuatro tipos para cinco códigos (AI-1 a AI-5). ¿Cuál es cada uno, qué «lista» de dominios se usa y cuáles bloquean o avisan? | no | media |
| 41 | Marco §1, Traza | Se usa «la ficha» antes de definirla | sí, en la fila siguiente («Ficha») | baja |
| 42 | Marco §1, Traza | Con `traces: [ID]` sin versión, ¿cómo se detecta que el ID cambió de versión? | no | media |
| 43 | Marco §1, Traza | `traces-resolve` aparece sin explicar qué es ni a qué grupo PR pertenece | no | baja |
| 44 | Marco §1, Traza | Las trazas usan MAYOR.MENOR y el README usa SemVer de tres números. ¿Cuándo sube cada parte? | no | baja |
| 45 | Marco §1, Ficha | «Quien cambia el código sube su versión»: ¿siempre, aunque la regla no cambie? Mapa §3 dice que una persona decide si la regla cambió | no | media |
| 46 | Marco §1 | La sigla RRD no se expande | no (se infiere) | baja |
| 47 | Marco §1, Guarda de merge | ¿Cómo y dónde se declara una reserva? ¿En qué archivo se asienta la delegación? | no | media |
| 48 | Marco §2 | ¿Qué cátedra? ¿Los repositorios `Lab-*` son accesibles para quien estudia? | no | baja |
| 49 | Marco, ESC-SDEI-1 | ¿Qué significa «una etiqueta por compuerta»? | no | media |
| 50 | Marco, ESC-SDEI-2 | `source.lock`: ¿qué formato tiene, dónde vive y quién lo escribe? | no | media |
| 51 | Marco, ESC-SDEI-3 | ¿Qué es «la unidad» que contiene una pantalla? | no | media |
| 52 | Marco §2.5 | ¿Por qué CL-13 (README) no está activa en ESC-SDEI-1, si el cuerpo tiene README? | no | baja |
| 53 | Marco §3 | «Un contexto cambia una sola respuesta», pero CTX-SDEI-1 cambia los canales y además la compuerta | no | baja |
| 54 | Marco, CTX-SDEI-1 | No se explica `llms.txt` ni por qué va «rotulado como propuesta» (Mapa §3) | no | baja |
| 55 | Marco, CTX-SDEI-2 | `docs/_requisitos.md` «del árbol que se documenta»: en el caso de §6 (la demo está en `Examples/` y la app en otro repositorio), ¿en qué repositorio va? | no | media |
| 56 | Marco, CTX-SDEI-3 | ¿En qué se diferencia el repositorio hermano del dedicado? ¿Cuándo se usa `source.lock` y cuándo `base_commit`? | no | media |
| 57 | Marco, CTX-SDEI-4 | ¿Quién verifica la huella de la copia, y contra qué original? | no | baja |
| 58 | Marco §4, ACT-SDEI-1 | «Lo fusiona el agente» se dice sin condición. Sin delegación asentada, ¿quién fusiona? | no | media |
| 59 | Marco §4 | Un pull request de clase D lo produce un generador, no un agente. ¿Quién lo abre y quién lo fusiona? | no | media |
| 60 | Marco §4 | «Quien verifica no es quien redactó»: en un pull request que redacta una persona, ¿quién verifica? | no | media |
| 61 | Marco §4 / Mapa §4 y §7 | ¿Quién decide la clase de una pieza o abre una clase nueva «por expediente»? Mapa §7 lo pregunta y no lo responde | no | media |
| 62 | Marco §4, ACT-SDEI-5 | Según el Marco, estudiante y docente evalúan; según Mapa §5, sólo quien enseña | no (contradicción) | baja |
| 63 | Marco §4 | Si el pull request del agente modifica `docs-guard`, ¿sigue valiendo la guarda? | no | baja |
| 64 | Marco §5, Frontmatter | ¿Cuáles son los diez campos? Se pueden contar en los ejemplos, pero no se listan | no (remite al anexo) | baja |
| 65 | Marco §6 | La ayuda del caso «vive en la mini demo», pero el tutorial está en redacción. ¿Esa ayuda ya existe? | no | media |
| 66 | Marco §6, paso 2 | ¿Cómo detecta el aviso programado que «el método cambió»? | no | media |
| 67 | Marco §6 | ¿El límite correcto es 60 u 80? | sí, en el paso 3 (lo decide `ACT-SDEI-2`) | baja |
| 68 | Marco §6, paso 3 | Una divergencia es «especificación contra intención», pero el proyecto no tiene SDD. ¿Divergencia entre qué? | no | baja |
| 69 | Mapa §1, diagrama | La situación de OBJ-04 (cambio de código) está en §3, al que el diagrama sólo llega como ajuste. No hay entrada «sé mi problema» | no | media |
| 70 | Mapa §2, ESC-SDEI-1 | «`docs-guard` completo» enumera cinco controles y omite trazas y contrato. ¿«Esquema» es lo mismo que frontmatter? | no | baja |
| 71 | Mapa §2, ESC-SDEI-3 | ¿Qué es el «cruce de rol en las pruebas de acceso»? ¿Qué es «superar una norma del proyecto»? | no | baja |
| 72 | Mapa §2, ESC-SDEI-4 / §4, CL-11 | ¿Qué es la «base de conocimiento común» y qué conocimiento se copia? | no | media |
| 73 | Mapa §3, CTX-SDEI-2 | El prefijo `CU-` no se define | no (se infiere «caso de uso») | baja |
| 74 | Mapa §3, fila «mismo repositorio» | `traces-resolve` da rojo hasta que la página se revisa. ¿Quién la revisa en ese pull request, si Desarrollo no decide el texto de la ayuda (Marco §4)? | no | alta |
| 75 | Mapa §3, fila «mismo repositorio» | Si quien cambia el código no sube la versión de la ficha, ¿algo lo detecta? Todo el mecanismo depende de ese paso manual | no | alta |
| 76 | Mapa §3, fila «otro repositorio» | El anexo que se aplica es un ejercicio (`EJR-SDEI-04`). ¿El procedimiento está sólo en un ejercicio? | no | baja |
| 77 | Mapa §3, CTX-SDEI-4 | Remite a Cómo decidir. ¿Qué hay que decidir ahí? | no | baja |
| 78 | Mapa §4, CL-03 | ¿Qué significa «excluido del aviso AI-3 por huella»? | no | media |
| 79 | Mapa §4, CL-08 | ¿Qué son «ia-db» y `base_tag`? | no | baja |
| 80 | Mapa §4, CL-13 | «Entrada en el pull request»: ¿cada pull request necesita una entrada de CHANGELOG? | no | baja |

Dudas sin respuesta: 68
