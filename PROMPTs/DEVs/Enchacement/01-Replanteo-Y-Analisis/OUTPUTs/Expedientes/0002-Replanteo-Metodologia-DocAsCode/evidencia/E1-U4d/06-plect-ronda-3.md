# E1-U4d — P-LECT de TEM-07, ronda 3, 2026-10-27
# Lector sin contexto: claude -p sin herramientas; recibe sólo 00-Marco (referencia) y TEM-07 en su estado de la ronda, con la consigna:
#   Prueba de lectura P-LECT. Sos un lector sin contexto: estudiante de sistemas que nunca vio este repositorio ni el proyecto. No uses herramientas ni leas otros archivos: sólo el texto de abajo (dos documentos de una guía: 00-Marco, que fija el vocabulario, y el tema TEM-07). Leé el Marco como referencia y evaluá el TEM-07. Anotá TODAS las dudas concretas sobre TEM-07 que el texto NO responde (términos sin definir en su primer uso, saltos, referencias a cosas que no están, contradicciones, instrucciones ambiguas, ejemplos que no se pueden reproducir). No anotes dudas que el propio texto responde: en ese caso indicá dónde. Formato de salida: una tabla Markdown con columnas | # | Sección de TEM-07 | Duda | ¿La responde el texto? (no / sí, en …) | Gravedad (alta/media/baja) |, y al final una línea «Dudas sin respuesta: N» y otra «Dudas altas sin respuesta: N». Respondé en castellano.

| # | Sección de TEM-07 | Duda | ¿La responde el texto? (no / sí, en …) | Gravedad (alta/media/baja) |
| --- | --- | --- | --- | --- |
| 1 | Introducción, «Estado» | La primera vez que aparece «IA.SDD» no se explica qué es. | sí, en §1.4 («Marco SDD y proyecto destino»), aunque recién más adelante | baja |
| 2 | «Estado» y §1.4 (Escalón) | Cada escalón tiene «su propia compuerta de cierre». En el Marco, «compuerta» es un control de la CI que se corre en cada PR. ¿Acá significa lo mismo o es un hito de etapa? El texto usa el mismo término para dos cosas distintas. | no | media |
| 3 | §1.1 | «Anillo "evaluar" de su radar» (Thoughtworks): no se explica qué es el radar ni qué implica estar en ese anillo. | no | baja |
| 4 | §1.1 punto 2 vs. §2 (tabla de contextos, CTX-SDEI-2) | §1.1 dice que el RRD vive junto a la especificación, «no en un archivo aparte». §2 dice que va «como un archivo `doc_type: rrd`». ¿Es un archivo propio o no? | no (se contradicen) | media |
| 5 | §1.1 punto 3 | ¿Cada escenario resuelve contra un SHA o contra una etiqueta? | sí, en la tabla de §2 (ESC-3: SHA; ESC-4: etiqueta) | baja |
| 6 | §1.2 y §3.1 | `CU-08002` es un caso de uso, pero §3.1 lo llama «contrato de administración de cuentas». ¿Es un caso de uso o un contrato, que en el Marco es otra clase de pieza (contrato REST)? | no | baja |
| 7 | §1.3 («rige la del SDD dentro de su repositorio»), frontera de §2 y §2.1 | En ESC-3, el marco (IA.SDD) y el proyecto destino (Lab-Geometria) están en repositorios distintos. ¿Cuál es «su repositorio»? ¿Quién es «la persona responsable de cada SDD»: el PO de Lab-Geometria o quien mantiene IA.SDD? | no | media |
| 8 | §1.4 («Cuerpos de la categoría 11») | En el Marco, «cuerpo» es un cuerpo documental con `corpus_id`. ¿Estos «cuerpos» lo son, o es otro uso de la misma palabra? | no | baja |
| 9 | §1.4 (CL-11) y §2.1 (capa A) | ¿Qué es y dónde está «la base de conocimiento común del laboratorio»? ¿Qué es «la carpeta de conocimiento de cada SDD»? No se da repositorio ni ruta. | no | media |
| 10 | §1.4 (CL-11) | CL-11 «se activa» en ESC-3 cuando llegue la capa A, pero la tabla §2.5 del Marco no la incluye. ¿Quién actualiza el Marco y en qué momento? | no | baja |
| 11 | §1.4 (Lección de decisión) | Se define como algo que se resolvió «sin que la persona responsable tuviera que decidirla», pero incluye el nivel N3, que es una «consulta a la persona». Además, la «mesa de agentes» de N2 no se explica: ¿quiénes la forman y cómo se decide? | no (contradicción) | media |
| 12 | §1.4 (Prefijo externo) y §3.1 | Se habla de un «registro cerrado» de prefijos, pero `H-01`, `N-01` y `BT-01` entran al registro de IDs. ¿El registro acepta cualquier prefijo? Si un proyecto usa un prefijo nuevo (por ejemplo `REQ-`), ¿hay que agregarlo al registro de prefijos del cuerpo? ¿Quién lo agrega? | no | media |
| 13 | §1.4 (Prefijo externo) y §3.1 (tabla «Cómo pasa esto a la CI», fila «mismo repositorio») | En Lab-Geometria no habrá `source.lock` ni `--fuente`. Según la regla del prefijo externo, una traza `CU-` que no resuelve sólo da un aviso («no verificable»). Eso contradice §1.2, donde la compuerta «da rojo cuando esa versión deja de existir». En el caso previsto para el escalón 2, ¿sale rojo o sólo aviso? | no | alta |
| 14 | §1.4 (Prefijo externo) | La regla «no verificable → aviso», ¿vale sólo cuando el ID no aparece, o también cuando la versión está desfasada? | no | media |
| 15 | §1.4 (Prefijo externo) vs. §3.1 | El registro propio es «el del repositorio» (§1.4) o el que se arma con `--raiz` (§3.1)? Y cuando busca el `source.lock` «más arriba», ¿hasta qué carpeta sube? | no | baja |
| 16 | §1.4 (diagrama) | La leyenda dice que las flechas llenas son «dependencias», pero `lee`, `verifica` y `pide` son acciones. Además, `AGENTS.md CL-03` no tiene ninguna flecha. ¿Qué quiere mostrar? | no | baja |
| 17 | §2 (frontera) y tabla por escenario | CL-02, CL-04, CL-05, CL-08 y CL-10 aparecen sin nombre, y el catálogo está en el Mapa, que no se incluye. No se puede comprobar que «no tienen par en el SDD o salen del build». | no (el Marco remite al Mapa) | media |
| 18 | §2, fila ESC-SDEI-2 | «Trazas de nivel 1» y «anclas de nivel 2» no se definen ni en TEM-07 ni en el Marco. También se confunden con los niveles N1/N2 de las lecciones. ¿Qué control verifica `ruta#Símbolo@SHA`? | no | media |
| 19 | §2, fila ESC-SDEI-4 | Si una página vale para varias líneas de versión, ¿contra qué etiqueta resuelve? | no | baja |
| 20 | §2, CTX-SDEI-2 | «La carpeta exacta la fija el escalón 2»: hasta entonces, ¿dónde va el RRD? ¿`doc_type: rrd` es un valor válido del esquema? | no | baja |
| 21 | §2 («Una regla que no cambia») | No se explica qué es «el plan de sprint de IA.SDD». | no | baja |
| 22 | §2 («La frontera…») | Si el SDD y el sistema documentador «dicen cosas distintas», ¿eso es una divergencia entre especificación e intención (la decide la analista) o un cambio de norma (lo decide el PO)? Falta un criterio para clasificar el caso. | no | media |
| 23 | §2, tabla de clases, fila CL-03 | No se explica qué es «la consolidación de cierre de la categoría 11». | no | baja |
| 24 | §2, tabla de clases, fila CL-07, y escalón 2 | Cuando la compuerta corra en Lab-Geometria, ¿qué archivos revisa el control de frontmatter: todo `SDD/Docs` o sólo las piezas del documentador? Los documentos del SDD que no tienen frontmatter, ¿dan rojo? | no | alta |
| 25 | §2 (cita a IA.SDD) | La cita entre repositorios no usa la forma `Repo@ancla:corpus_id/doc_id` que pide el Marco (§5, Enlaces). ¿Es una excepción o un error? | no | baja |
| 26 | §2 / CTX-SDEI-4 | ¿Lab-Geometria está dentro de la organización del runner? | sí, se infiere: las dos URL son de `hdcm-dev` y CTX-4 sólo deja afuera al SDD-B | baja |
| 27 | §3.1 (guion) | El ensayo usó `dg.py` en el SHA `080f158`, pero el guion corre con el estado actual del clon de Lab-Documentos y no lo fija a ese SHA. Así no se puede reproducir el ensayo con exactitud. | no | alta |
| 28 | §3.1 | El rótulo `[Compilado: guion del ensayo…]` no da ruta ni líneas, como pide el Marco. ¿El guion está guardado en algún archivo? | no | baja |
| 29 | §3.1 | Las cifras 829/355 y 715/52 (IDs y repetidos) no salen del guion. ¿Cómo se obtienen? | no | media |
| 30 | §3.1 (salida) | La salida muestra «caso A  ERROR…», pero el guion imprime «caso A: exit=N». No se muestran los códigos de salida. ¿Qué código corresponde a rojo y cuál a verde? | no | baja |
| 31 | §3.1 | Los IDs repetidos que ninguna página traza, ¿hacen fallar la compuerta? | sí, en la salida del caso B (`avisos=0`) | baja |
| 32 | §3.1 (tabla de CI) | ¿Dónde está `mini-demo-movilidad.yml`? No se da la ruta. | no | baja |
| 33 | §3.2 | ¿Cómo «cita a la API» el caso de uso del front: con una traza, con un enlace o de otra forma? | no | baja |
| 34 | §3.3 | En un `requirements.md` con varios encabezados, ¿dónde va la `**Versión:**` de cada requisito y cómo la asocia `dg.py` a su ID? | no | media |
| 35 | §3.3 | ¿«La persona responsable del proyecto» es el PO (ACT-SDEI-1)? En «la herramienta, que no trae una norma propia», ¿«la herramienta» es `dg.py` o Spec Kit/Kiro? | no | baja |
| 36 | §4, pregunta 5 | ¿Quién acepta cada fila del RRD? | sí, en el Marco §4 (ACT-SDEI-2, analista) | baja |
| 37 | §5, «Ancla explícita» | «Documento de estructura» no se define. El criterio pide «fuente fijada a un SHA», pero ESC-4 resuelve contra una etiqueta. | no | baja |
| 38 | §6 | La hoja de integración se llama «ficha», término que el Marco reserva para reglas y casos de uso. Además, ¿quién la completa y de qué clase es (P o H)? Varios de sus campos son decisiones H. | no | media |
| 39 | Frontmatter (`traces`) | ¿`GP-SDEI-INTERVENIR` es la plantilla `Examples/Como-Intervenir.md`? El texto nunca vincula el ID con el archivo. | no | baja |

Dudas sin respuesta: 34
Dudas altas sin respuesta: 3
