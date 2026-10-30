# P-LECT de E1-U4c: TEM-04, TEM-05 y TEM-06 por un lector sin contexto

Fecha: 2026-10-27. Lector: una sesión nueva de Claude Code en modo no interactivo (`claude -p --tools ""`), sin
herramientas ni acceso al repositorio, que recibió el texto del tema más el Marco y el Glosario del cuerpo (la ruta
mínima: LD-06 de E1-U4a recomendaba darle más que el tema solo). Una corrida por tema y por ronda, en paralelo. La
consigna fue la misma en las tres rondas (abajo). Después de cada ronda se corrigieron todas las dudas altas y las
medias que eran contradicciones o faltas reales del texto; después de la ronda 3 se corrigieron sus dos altas sin
una ronda más (mismo criterio que E1-U4a).

| Ronda | TEM-04 altas/medias/bajas | TEM-05 | TEM-06 |
| --- | --- | --- | --- |
| 1 | 2 / 8 / 9 | 0 / 12 / 5 | 1 / 14 / 11 |
| 2 | 1 / 13 / 5 | 0 / 10 / 8 | 1 / 11 / 8 |
| 3 | 0 / 12 / 8 | 1 / 9 / 7 | 1 / 9 / 11 |

Las medias no bajan en número porque cada ronda lee un texto más largo y el lector encuentra preguntas nuevas;
muchas las responden documentos que no veía (anexo del esquema, criterios, TEM-03/07). Umbral de cero dudas: rige
para la P-LECT de la compuerta E1-G, no para esta unidad.

## Altas y su corrección

| Ronda | Tema | Duda alta | Corrección |
| --- | --- | --- | --- |
| 1 | TEM-04 | ¿El corpus de guías tiene índice interno (CL-08)? El Marco no lo activa en ESC-SDEI-1 | Se quitó de ESC-SDEI-1: no hay código propio que indexar |
| 1 | TEM-04 | El `llms.txt` del panel, ¿es CL-14 si «sólo existe con sitio»? | Se separó: el `.md` y el `llms.txt` que sirve la ayuda de un producto son parte de la ayuda (CL-06), no canales derivados de un sitio |
| 1 | TEM-06 | ¿Cómo distingo en la salida un aviso de un error? | §4 da la forma de cada línea (`ERROR` / `aviso`), el contador `avisos=n` y qué son los «excluidos» de lychee |
| 2 | TEM-04 | CL-08 «en ESC-SDEI-2 a 4» contradice el Marco | Alineado con el Marco: ESC-SDEI-3 y 4 |
| 2 | TEM-06 | ¿De dónde sale el contrato generado si `docs-guard` no compila? | `PR-6` explica las dos vías (archivo generado en el árbol o `workflow:` en `source.lock`) y que sin ninguna da rojo |
| 3 | TEM-05 | ¿Qué prefijo lleva el `doc_id` de una página de ayuda? | Párrafo antes de las preguntas guía: sale del registro cerrado; un producto sin prefijo lo agrega por PR |
| 3 | TEM-06 | ¿Quién deja `contracts/.generado/openapi.json`? | Igual que la anterior, con el ejemplo de la mini demo |

Hallazgo fuera de los temas (ronda 1, TEM-05): el Marco §6, `PE-01` y `EJR-SDEI-04` decían que el defecto 60/80 está
en el «comentario»; la ficha `RN-LOC-01`, verificada contra el código, dice que es el nombre de una localidad. Se
corrigieron las tres menciones (LD-04 del folio).

## Consigna

Sos un lector sin contexto previo: estudiante de una carrera de sistemas que conoce Git y Markdown pero no este proyecto.
Recibís un tema de una guía de estudio y, como contexto mínimo de la ruta de lectura, el Marco de referencia y el Glosario
del mismo cuerpo (los demás documentos enlazados no los tenés). Leé el TEMA y hacé una prueba de lectura:
lista las dudas que el texto del tema (con Marco y Glosario) NO responde y que te impedirían entenderlo o aplicarlo.
Para cada duda: número, cita breve del pasaje, la duda, gravedad (alta = me impide entender o aplicar el tema; media =
me obliga a adivinar; baja = cosmética) y si la responde otro documento que no tenés (sí/no/no sé).
No marques como duda lo que el texto responde. Al final, una línea: «ALTAS=n MEDIAS=n BAJAS=n». Respondé en castellano.

## Ronda 1, TEM-04: salida del lector

# Prueba de lectura de TEM-SDEI-04 «Doble audiencia»

Leí el tema con el Marco y el Glosario. Encontré **19 dudas** que esos tres textos no responden. Las dos altas son contradicciones con el Marco y pegan justo en lo que el tema promete enseñar: decidir qué canales necesita cada escenario.

| # | Pasaje (cita breve) | Duda | Gravedad | ¿La responde otro doc? |
|---|---|---|---|---|
| 1 | §2, ESC-SDEI-1: «Canales activos: … índice interno» | El índice interno es `CL-08`, pero el Marco (§2.5) no pone `CL-08` entre las clases activas de ESC-SDEI-1 (CL-02, 03, 09, 10, 11, 12). ¿El corpus de guías tiene índice interno o no? Y si no hay código de producto, ¿qué indexaría la ia-db, que es algo «que un agente consulta antes de leer el código»? | alta | no sé |
| 2 | §2, ESC-SDEI-3: «si se sirve `llms.txt` desde el panel, filtrado por el rol»; §3.5: la prueba de concepto sirve `.md` y `llms.txt` | El tema y el Glosario dicen que `llms.txt` es un canal derivado (`CL-14`) que «sólo existe si hay sitio». El Marco dice que «hoy ningún escenario publica sitio» y no pone `CL-14` entre las clases activas de ESC-SDEI-3. ¿El panel cuenta como «sitio»? ¿Ese `llms.txt` es `CL-14` o es otra pieza? | alta | sí (TEM-05, Mapa) |
| 3 | Diagrama: «Índice derivado / agente»; §3.3: «su índice para agentes se deriva del frontmatter» | ¿Este índice es el mismo que el índice interno (`CL-08`, la ia-db del repositorio hermano) o es otro? ¿Dónde queda la salida del script: se commitea, en qué repositorio y con qué nombre? ¿Quién lo corre y cuándo (en la CI, a mano)? ¿Es de clase D? | media | sí (Mapa, `CL-08`) |
| 4 | Tabla §1: «Canal derivado: artefacto que un build genera **de la fuente** … un agregado de todo el contenido» | El Glosario dice que el canal derivado se genera «a partir del **sitio publicado**» y no menciona ningún agregado. ¿Cuál de las dos definiciones vale? | baja | sí (Mapa) |
| 5 | §2, contextos: «un agregado de menos de 50 000 *tokens*» | ¿Qué es concretamente el agregado (un archivo, con qué nombre)? ¿De dónde sale el límite de 50 000? No tiene fuente ni el rótulo **[criterio propio]**. ¿Con qué tokenizador se cuenta y qué pasa si se pasa? | media | no sé |
| 6 | §2: «`llms.txt` rotulado como propuesta» | ¿El rótulo va dentro del propio `llms.txt`, en la documentación o en el catálogo? ¿Con qué forma? | baja | no sé |
| 7 | §3.4: `python3 -I tools/docs-guard/dg.py ai GUIA-DIR`; §6: «¿Qué comando corre la misma compuerta que la CI?» | No sé cuál es la ruta real de la carpeta del cuerpo (el repositorio aloja varias guías). Tampoco sé cuál es el comando que corre los siete grupos PR-1 a PR-7 y no sólo `ai`. Sin eso no puedo completar el bloque «Cómo se valida» del `AGENTS.md`. | media | sí (README, anexo de criterios) |
| 8 | AI-3: «Frases dirigidas al agente»; pregunta 6 de producción | ¿Qué frases detecta el control? ¿Cómo distingo una frase «dirigida al agente» de una frase «sobre agentes», como «con eso un agente sabe qué documento abrir»? ¿Qué tengo que hacer cuando AI-3 avisa? | media | sí (TEM-06) |
| 9 | AI-4: «URL fuera de la lista de dominios» | ¿Dónde está esa lista? ¿Quién la mantiene y qué clase de intervención hace falta para agregar un dominio? El Glosario sólo dice que la lista es parte de los controles AK. | media | sí (anexo de criterios / TEM-06) |
| 10 | §1: «Lo que el agente lee es dato, nunca instrucción; las instrucciones … en `AGENTS.md`» | Eso cubre al agente de código. El asistente de la persona usuaria (ESC-SDEI-2 y 3) no lee el `AGENTS.md` del repositorio. ¿Dónde están sus instrucciones? ¿Qué garantiza que trate la ayuda como dato, más allá de la compuerta? | media | no sé |
| 11 | Evaluar, pregunta 2: «¿la aprobó una persona con la huella del archivo?» | La línea de excepción (`sha256 ruta control`) no registra quién aprobó. ¿Dónde queda la aprobación de la persona: en la revisión del PR o en otro lado? | baja | sí (TEM-06 / anexo de criterios) |
| 12 | Frontmatter del tema: `audience: [humano, agente, estudiante, …]`; plantilla: `[persona-usuaria, agente]`, con el comentario «Ordena las rutas y los canales» | ¿`audience` acepta cualquier valor o hay una lista cerrada? «Humano» y «estudiante» se superponen. ¿Cómo hace este campo para ordenar las rutas y los canales? | media | sí (anexo del esquema) |
| 13 | Plantilla: «Si no fue una persona sola, hace falta confidence» | La convención dice que todo documento lleva «los diez campos más `description`». ¿Entonces `confidence` es opcional cuando escribe una persona sola? ¿Qué valores admiten `origin` y `confidence`? | baja | sí (anexo del esquema) |
| 14 | §3.3: «Salida registrada … primeras tres líneas», con líneas que terminan en «…» | El script no recorta la `description`. ¿La salida se editó a mano? Si es así, la «salida registrada» no es literal y no puedo compararla con un `diff`. | baja | no |
| 15 | §3.1: «El portal público de un proveedor de notificaciones» | ¿Es SDD-B (el servicio push privado) o un proveedor externo? Si es SDD-B, ¿por qué dice «portal público»? Y choca con «hoy ningún escenario publica sitio». | baja | sí (guía de un solo archivo) |
| 16 | §3.4: «Por qué AI-3 sólo avisa lo explica `TEM-06` (regla de bloqueo)» | El Marco ubica la regla de bloqueo en el anexo de criterios, no en TEM-06. ¿Cuál es la referencia que manda? | baja | sí |
| 17 | §5: «pasa por una revisión registrada (`CQ-14`)» | ¿Qué cuenta como revisión «registrada» y dónde se asienta? Tampoco sé qué piden exactamente `CQ-13` y `CQ-05`, más allá de la tabla de versión pobre y buena. | media | sí (anexo de criterios) |
| 18 | §3.2: «Lo decide una persona (clase H)» | En la tabla de actores, ¿quién decide el `AGENTS.md`: el PO (`ACT-SDEI-1`) u otra persona? El Marco aclara que clase H «no siempre» es el PO. | baja | no sé |
| 19 | §1 y §3.2: «ruta «agente» del README» | No sé qué rutas de lectura hay ni qué recorre la ruta «agente», así que no puedo comprobar que el `AGENTS.md` apunte bien. | baja | sí (README §3) |

ALTAS=2 MEDIAS=8 BAJAS=9

## Ronda 1, TEM-05: salida del lector

# Prueba de lectura: TEM-SDEI-05 «Ayuda al usuario final» (con Marco y Glosario)

| # | Pasaje | Duda | Gravedad | ¿La responde otro documento? |
|---|---|---|---|---|
| 1 | «La regla `RN-LOC-01` es el largo del nombre. La pantalla promete 60 caracteres y el campo admite 80» | El Marco §6 dice que el mismo defecto de 60 contra 80 está en «el comentario». ¿El campo afectado es el nombre o el comentario? ¿Son dos defectos distintos o uno solo descrito de dos maneras? | media | no sé (lo aclararía la página DEMO-MU-21 o la ficha) |
| 2 | «una divergencia entre lo que la especificación dice y lo que el producto hace» | Los dos números (60 y 80) salen del producto: uno es el texto de la pantalla y el otro la validación del campo. No sé qué dice la ficha `RN-LOC-01@1.1`. Sin eso no puedo responder la pregunta de la plantilla «¿Cada límite coincide con la regla trazada?» | media | sí (la ficha RN-LOC-01) |
| 3 | «deja la decisión de cuál es el límite correcto a quien le toca: la analista (`ACT-SDEI-2`)» | Según el Marco, la analista decide divergencias «entre lo que la especificación dice y lo que se quiso decir», no entre especificación y producto. Además, el Marco §6 da a entender que una desarrolladora ya va a corregir el código. ¿Quién decide este tipo de divergencia y en qué orden se hace todo? | media | no sé |
| 4 | Diagrama: `-->|"deriva, P"|` | El Glosario define «Deriva» como desactualización, y el tema usa «derivar» como «escribir a partir de la especificación». En el diagrama, «deriva» puede leerse como cualquiera de las dos cosas, y eso choca con «un término, un significado» | media | no |
| 5 | «Toda página de usuario traza a un `RD-`» / `traces: [RD-01, …]` | El Marco dice que un ID se declara como `doc_id` o como encabezado que empieza con el ID, pero el RRD es una tabla. ¿Cómo se declara una fila `RD-nn` para que `traces-resolve` la resuelva? ¿Por qué `RD-01` va sin versión? | media | sí (Esquema §4 y §6) |
| 6 | «Si la regla sube de versión, la traza queda desfasada y la compuerta da rojo» | ¿Cuándo sube MAYOR y cuándo MENOR? El ensayo muestra que también un cambio menor da rojo. ¿Hay algún cambio de la ficha que no obligue a revisar la ayuda? | media | sí (Esquema §4) |
| 7 | «el pull request que la cambia no entra hasta que la página se revisa» | Para que la compuerta vuelva a verde alcanza con cambiar `@1.0` por `@1.1`. ¿Qué garantiza que alguien de verdad revisó el texto? ¿Quién revisa y con qué evidencia? | media | no sé |
| 8 | «`CTX-SDEI-1` con servidor: la ayuda viaja con el binario…» y el filtro del «`.md` y `llms.txt`» | En el Marco, `CTX-SDEI-1` es «con sitio publicado o sin sitio», no «con servidor». El Marco dice además que «hoy ningún escenario publica sitio» y el Glosario que los canales derivados «sólo existen si hay sitio». ¿El `.md` y el `llms.txt` del catálogo de ayuda son esos canales derivados o son otra cosa? | media | no sé (quizá TEM-04) |
| 9 | «es un control que vale la pena tener en la CI de un panel con roles» / Criterios: «La CI detecta el cruce de rol» | ¿Ese control existe en `docs-guard` o es solo una propuesta? Si no existe, ¿cómo cumplo el criterio de calidad? ¿Cómo se arregla un cruce: se quita el enlace, se condiciona por rol, se duplica la página común? | media | no sé |
| 10 | «En un panel con roles se suma el campo `roles` …» | ¿Qué formato tiene (lista, cadena)? ¿Qué significa una página sin `roles`: que es común para todos o que es inválida? | media | sí (Esquema §3) |
| 11 | `doc_id: <PREFIJO-NN>` | Para la ayuda de un producto real, ¿qué prefijo uso? El ejemplo usa `DEMO-MU-`, que parece propio de la demo | media | sí (Esquema §5) |
| 12 | «El caso de uso de la unidad de la pantalla, en el registro del SDD» | El término «unidad» no está definido ni en el Marco ni en el Glosario | baja | sí (probablemente TEM-07 o la guía de un solo archivo) |
| 13 | «Cada traducción declara de qué revisión de la fuente se tradujo (`translation_of`)» | ¿La revisión es un SHA, la versión del documento o `last_review`? ¿Qué control marca la traducción como atrasada y si bloquea o solo avisa? | media | no sé |
| 14 | «la prueba de concepto devuelve 404 a un rol que no alcanza la página» | ¿Por qué 404 y no 403? Supongo que es para no revelar que la página existe, pero el texto no lo dice | baja | no |
| 15 | Ensayo §3.2: los tres comandos son idénticos y el cambio va solo en el comentario | ¿Hay que editar a mano el frontmatter entre corrida y corrida? ¿Desde qué carpeta se ejecuta `tools/docs-guard/dg.py`? | baja | no sé |
| 16 | `traces: [… DEMO-MU-11]` en el frontmatter del tema | El cuerpo del tema nunca menciona `DEMO-MU-11` y no sé qué documento es | baja | sí |
| 17 | «`CQ-01` (corrección), `CQ-03` (actualidad) y `CQ-09` (orientación a la tarea)» | Tengo los nombres, pero no los observables de cada criterio, así que no sé cómo puntuar una página | baja | sí (Criterios de calidad) |

Ninguna duda me impide entender el tema; varias me obligan a adivinar para aplicarlo. Las más importantes son la contradicción entre «nombre» y «comentario» (1), no saber qué dice la ficha (2) y no saber quién decide la divergencia (3).

ALTAS=0 MEDIAS=12 BAJAS=5

## Ronda 1, TEM-06: salida del lector

# Prueba de lectura: TEM-06 Compuertas de calidad y CI

Leí el tema como estudiante con Git y Markdown, sin conocer el proyecto. Para cada duda doy la cita, la duda, la gravedad y si la responde otro documento que no tengo.

## Alta

**1.** «¿El rojo es del cambio, o un aviso que no bloquea?» (§4, leer una corrida)
- **Duda:** Hay controles que dentro de su grupo sólo avisan: AI-3 y AI-4 en `PR-3` y `reflint` en lo heredado en `PR-7`. El texto no muestra cómo aparece un aviso en la salida. El agregador del ensayo sólo dice «verde» o «rojo» por grupo. Con esto no puedo contestar la pregunta guía que el tema mismo me plantea, y leer una corrida es uno de sus dos objetivos.
- **Otro documento:** no sé.

## Medias

**2.** «hoy corre en el paso `avisos`, fuera de los grupos» (§6)
- **Duda:** El paso `avisos` sólo aparece en la plantilla. No figura en el diagrama 1.1, ni en la tabla de grupos, ni en la salida del ensayo. ¿Existe dentro de `docs-guard`? ¿Dónde se ve su resultado?
- **Otro documento:** no sé.

**3.** «Sí, salvo AI-3 y AI-4 en el anexo de referencias, que avisan» frente a «AI-3 […] avisa hasta que su línea de base […] sea 0» y «El carril programado mide la línea de base de AI-3 cada semana, para saber cuándo puede pasar a bloquear»
- **Duda:** Según la tabla, AI-3 avisa sólo en el anexo de referencias y bloquea en el resto. Según §1.2 y §3.4, AI-3 no bloquea en ningún lado todavía. ¿Cuál de las dos lecturas vale?
- **Otro documento:** sí (TEM-04).

**4.** «La regla explica cada excepción de la tabla de grupos.» (§1.2)
- **Duda:** La regla no explica la excepción de AI-4. Tampoco sé qué detecta AI-4: el Marco lista cuatro formas de inyección para cinco códigos. AI-3 («frases dirigidas al agente») no está en esa lista.
- **Otro documento:** sí (TEM-04).

**5.** «AI-3 […] tiene falsos positivos […] (falla 5)»
- **Duda:** La condición 5 se cumple si los falsos positivos «se canalizan por excepciones con huella». ¿Por qué AI-3 no se resuelve ya con excepciones? ¿Lo que le falla es la 5 o la 4?
- **Otro documento:** no sé.

**6.** «bloquea sólo en un cuerpo nuevo, el que declara `corpus_id` en su README»
- **Duda:** ¿Cómo decide el control que un archivo pertenece a un cuerpo nuevo? ¿Busca el README en la misma carpeta, en una carpeta superior o en una lista configurada? Lo necesito para aplicar la decisión de «bloquea acá, avisa allá».
- **Otro documento:** no sé.

**7.** En la plantilla, la condición 4 dice «0 en el cuerpo nuevo» y la decisión dice «bloquea en el cuerpo nuevo cuando la línea de base sea 0»
- **Duda:** Si la línea de base ya es 0 en el cuerpo nuevo, ¿por qué no bloquea ahora? El ejemplo resuelto de la regla se contradice consigo mismo.
- **Otro documento:** no.

**8.** «`url-fecha`: URL sin fecha de consulta» frente a «`reflint` exige año, título en cursiva y fecha de consulta»
- **Duda:** ¿En qué se diferencian `url-fecha` y `reflint`? Parecen detectar el mismo defecto. Si se superponen, el ejemplo no me sirve como modelo de control nuevo.
- **Otro documento:** no sé.

**9.** «Cada paso sigue aunque otro haya fallado, y el último es el agregador» y el fragmento `[Compilado: …, l. 40-51]`
- **Duda:** El fragmento muestra permisos, concurrencia y la guarda `if:`, pero no los pasos ni el agregador, que es lo que el párrafo anuncia. ¿Cómo se agrega un paso que siga ante un fallo y entre al agregador? La pregunta 6 de diseño lo pide.
- **Otro documento:** no sé.

**10.** «`PR-5` contra el SHA de `source.lock`» y «`docs-guard` no baja código»
- **Duda:** PR-5 resuelve contra «el registro generado de los encabezados». ¿Qué papel cumple el SHA de `source.lock` si el código no se descarga?
- **Otro documento:** sí (TEM-05).

**11.** «tiene una guarda `if:` que no corre pull requests que vienen de un fork» y «aprobación obligatoria de las corridas de forks»
- **Duda:** Si el job se salta los forks, aprobar la corrida de un fork da un job omitido. ¿Cómo llega a verde (G3) el pull request de un fork? ¿O los forks nunca se fusionan?
- **Otro documento:** no sé.

**12.** «El repositorio llama `docs-guard.yml` por SHA o etiqueta y pasa la carpeta a verificar» (CTX-SDEI-4)
- **Duda:** No hay ejemplo de la llamada (`uses:`) ni del nombre del parámetro de la carpeta. Para aplicarlo en otro repositorio tendría que adivinar.
- **Otro documento:** no sé.

**13.** «una copia del workflow con huella en su propio runner» (ESC-SDEI-4)
- **Duda:** ¿Quién compara la huella de la copia, y contra qué? ¿Es PR-7 en el repositorio de destino o algún aviso del carril programado?
- **Otro documento:** no sé.

**14.** «Diff del contrato OpenAPI, si la ruta tiene uno» (`PR-6`)
- **Duda:** ¿Contra qué base se calcula el diff? ¿Cualquier diferencia da rojo, o sólo los cambios que rompen la compatibilidad?
- **Otro documento:** sí (probablemente el tema del contrato).

**15.** «sobre el árbol de repositorios» y «Enlaces con red sobre el árbol armado»
- **Duda:** ¿Qué es el «árbol armado»? ¿Qué repositorios se juntan y cómo?
- **Otro documento:** no sé.

## Bajas

**16.** «El carril programado mide la línea de base de AI-3 cada semana»
- **Duda:** Esa medición no está en la tabla de controles del carril programado.
- **Otro documento:** no.

**17.** «[ERROR] …#9-no-existe | Cannot find fragment … 33 Excluded»
- **Duda:** La salida no da la línea, aunque la pregunta guía 1 la pide. Tampoco se explica qué son los 33 excluidos.
- **Otro documento:** no sé.

**18.** «no usa `pull_request_target`, fija cada action por SHA»
- **Duda:** No explica por qué esas prácticas son riesgosas o necesarias. Las acato sin entenderlas.
- **Otro documento:** no.

**19.** «Las anclas al código […] las verifica un workflow aparte»
- **Duda:** No dice cómo se llama ese workflow ni si bloquea.
- **Otro documento:** no sé.

**20.** «`CQ-03`, `CQ-05`, `CQ-11`, `CQ-13` y `CQ-14`»
- **Duda:** No se dice qué es cada criterio. Del Marco sólo deduzco que CQ-13 trata de los diagramas.
- **Otro documento:** sí (anexo de criterios).

**21.** Diagrama 1.1, con los grupos en abanico, frente a «un solo job con un paso por grupo»
- **Duda:** El diagrama sugiere que los grupos corren en paralelo y el texto dice que corren en secuencia.
- **Otro documento:** no.

**22.** El Marco dice que la regla de bloqueo está en el anexo de criterios, pero el tema la define completa.
- **Duda:** ¿Cuál es la fuente si las dos versiones difieren?
- **Otro documento:** sí.

**23.** «efímero», «lychee», «`cancel-in-progress`»
- **Duda:** Son términos o herramientas que el texto no presenta.
- **Otro documento:** no.

**24.** «detalle en `TEM-05`» para `traces-resolve`, y `traces` del frontmatter
- **Duda:** No se entiende por qué un tema llamado «Ayuda al usuario final» tiene el detalle de las trazas. Además, el frontmatter no traza TEM-04 ni TEM-05, aunque el tema depende de ellos.
- **Otro documento:** no.

**25.** «Índices o demos que quedaron atrás de `main` del código»
- **Duda:** ¿Cuánto atraso hace falta para el aviso? ¿Un solo commit alcanza?
- **Otro documento:** no sé.

**26.** «abre o actualiza un único issue»
- **Duda:** ¿Es un issue por control o uno para todo el carril?
- **Otro documento:** no sé.

ALTAS=1 MEDIAS=14 BAJAS=11

## Ronda 2, TEM-04: salida del lector

# Prueba de lectura de TEM-SDEI-04: dudas sin respuesta

Lo leí con el Marco y el Glosario como único contexto. El tema tiene una contradicción que me impide aplicar su objetivo principal (la duda 1) y varias dudas medias, sobre todo alrededor de AI-3, de lo que es un canal y de los valores del frontmatter.

**1.** «Índice interno (`CL-08`) […] Se activa en los escenarios con código propio (`ESC-SDEI-2` a `4`)»
- **Duda:** la tabla de §2 no pone el índice interno entre los canales activos de `ESC-SDEI-2`. Recién aparece en `ESC-SDEI-3` («Lo anterior, más el índice interno»). La tabla 2.5 del Marco tampoco incluye CL-08 en ESC-2. No sé si una app sin roles necesita índice interno, y el tema promete justamente que voy a poder decidir los canales según el escenario.
- **Gravedad:** alta.
- **¿Lo responde otro documento?** No sé.

**2.** Fila `ESC-SDEI-4`: «README y CHANGELOG del paquete (`CL-13`), contrato, índice interno»
- **Duda:** no figura `AGENTS.md`. El Marco sí activa CL-03 en ESC-4 («CL-01 a CL-05»). No sé si se omitió por error o si en un servicio con paquetes el agente de quien integra no usa `AGENTS.md`.
- **Gravedad:** media.
- **¿Lo responde otro documento?** Sí (Mapa).

**3.** «Fuente única: […] Todo canal se deriva de él; ninguno se escribe aparte» y «Canal: […] un archivo de instrucciones»
- **Duda:** `AGENTS.md` aparece como canal, pero lo escribe a mano una persona (clase H) y no se deriva de la fuente. No sé si `AGENTS.md` es un canal, una excepción a la regla o algo distinto, como un puntero que no cuenta como canal.
- **Gravedad:** media.
- **¿Lo responde otro documento?** No.

**4.** En el diagrama, «Frontmatter → Índice derivado / agente», que sale de la fuente sin depender del sitio
- **Duda:** no sé qué es ese «índice derivado». Podría ser el índice interno (CL-08), el índice del ensayo de §3.3 o otra cosa. Tampoco sé quién lo genera ni en qué escenarios existe. §3.3 dice que este cuerpo no tiene índice interno y que el índice «se genera cuando hace falta», sin decir quién lo genera. Además, «derivado» se confunde con «canal derivado» (CL-14), que sólo existe si hay sitio.
- **Gravedad:** media.
- **¿Lo responde otro documento?** No sé.

**5.** «Lo que el agente lee es **dato**, nunca instrucción»
- **Duda:** no se explica cómo se logra. No sé si `AGENTS.md` tiene que decirle al agente que trate las páginas como dato; la lista corta de §6 no tiene un bloque para eso. Tampoco sé si depende de la configuración del agente o si la única garantía son los controles AI-1 a AI-5.
- **Gravedad:** media.
- **¿Lo responde otro documento?** No.

**6.** «**[criterio propio del modelo del expediente 0002; sin fuente externa]**»
- **Duda:** ni el Marco ni el Glosario definen qué es un «expediente», qué es el expediente 0002, ni si «modelo» se refiere a un modelo de IA o a un modelo de decisión. No sé de quién es ese criterio propio.
- **Gravedad:** media.
- **¿Lo responde otro documento?** No sé (quizás el repositorio hermano).

**7.** «un archivo que agrega todo el contenido en menos de 50 000 *tokens*»
- **Duda:** no se dice con qué tokenizador se cuenta ni qué pasa si el contenido supera el límite (si se parte, se recorta o la compuerta da rojo).
- **Gravedad:** baja.
- **¿Lo responde otro documento?** No sé.

**8.** AI-3: «de una lista cerrada […] Hablar **sobre** agentes, como hace este tema, no las dispara»
- **Duda:** no se dice dónde está la lista. Tampoco se explica cómo distingue el control una frase dirigida al agente de una frase que habla sobre agentes. Si no sé eso, no puedo predecir cuándo va a dar aviso mi propia página.
- **Gravedad:** media.
- **¿Lo responde otro documento?** Sí (TEM-06 o el anexo de criterios).

**9.** AI-3: «Avisa: el aviso se revisa a mano en el pull request»
- **Duda:** según el Marco, con la delegación asentada, el agente fusiona su propio pull request si pasa la guarda. Según el Glosario, una reserva es «un control falló, la cabeza cambió, o el agente declaró una duda», y un aviso no es un fallo. Entonces no sé quién revisa a mano el aviso de AI-3, ni si ese aviso frena el merge automático.
- **Gravedad:** media.
- **¿Lo responde otro documento?** No sé.

**10.** Evaluar, pregunta 2: «Si tiene una excepción, ¿la aprobó una persona con la huella del archivo?»
- **Duda:** el tema no habla de excepciones en ningún otro lugar. Por el Glosario sé que una excepción es una línea `sha256 ruta control` en `excepciones.txt`. Pero no sé cómo queda registrado que la aprobó una persona, ni si hay controles que no admiten excepción.
- **Gravedad:** media.
- **¿Lo responde otro documento?** Sí (anexo de criterios o los AK).

**11.** «índices versionados que un agente consulta antes de leer el código»
- **Duda:** no se dice qué contiene el índice interno (¿documentos?, ¿símbolos del código?), en qué formato está ni cómo lo consulta el agente. Para aplicar el tema en ESC-3 y ESC-4 necesitaría saberlo.
- **Gravedad:** media.
- **¿Lo responde otro documento?** Sí (TEM-03 o el Mapa).

**12.** Plantilla: `audience: [persona-usuaria, agente]  # […] Ordena las rutas y los canales`
- **Duda:** no se dice cuáles son los valores válidos. El frontmatter del propio tema usa `humano`, que no aparece en la plantilla. Tampoco se explica cómo `audience` «ordena» los canales: si activa alguno o es sólo informativo.
- **Gravedad:** media.
- **¿Lo responde otro documento?** Sí (anexo del esquema).

**13.** §5, versión buena: «`doc_id` estable y `traces` con versión»
- **Duda:** el frontmatter del propio tema tiene `traces` sin versión (`[MARCO-SDEI, …]`). El Marco permite las dos formas. No sé si la versión es obligatoria para que la pieza sea «buena», o si sólo corresponde cuando el destino es una ficha versionada.
- **Gravedad:** media.
- **¿Lo responde otro documento?** Sí (anexo del esquema).

**14.** «si la escribió un agente, pasa por una revisión registrada (`CQ-14`)»
- **Duda:** no se dice qué cuenta como «revisión registrada» ni quién la hace. Si el agente puede fusionar su propio pull request con la guarda G1–G4, no sé si la compuerta alcanza como revisión o si hace falta una persona.
- **Gravedad:** media.
- **¿Lo responde otro documento?** No sé.

**15.** Fila `ESC-SDEI-2`: «el asistente del usuario que lee la ayuda» y «ayuda con `traces`»
- **Duda:** no se dice en qué formato le llega la ayuda a ese asistente (HTML, `.md`, `llms.txt`). En ESC-3 sí se mencionan `.md` y `llms.txt`. Tampoco se explica qué le aportan las `traces` al agente lector.
- **Gravedad:** media.
- **¿Lo responde otro documento?** Sí (TEM-05).

**16.** Misma fila de ESC-3: «van **filtrados por el rol**» y «que el índice de la ayuda no filtre títulos»
- **Duda:** «filtrar» aparece en dos sentidos opuestos en la misma fila: «restringir» y «dejar escapar». Se entiende por el contexto, pero confunde.
- **Gravedad:** baja.
- **¿Lo responde otro documento?** No.

**17.** «[Salida registrada: …]» y «[Fragmento ilustrativo: el script del ensayo, completo; …]»
- **Duda:** el Marco sólo prevé dos rótulos para los fragmentos: «Compilado» e «Ilustrativo». No sé si «Salida registrada» es un tercer rótulo válido. Tampoco entiendo por qué un script completo que se corrió se rotula como ilustrativo.
- **Gravedad:** baja.
- **¿Lo responde otro documento?** Sí (Patrones de ejemplos).

**18.** La tabla de contextos tiene `CTX-SDEI-1`, `3` y `4`
- **Duda:** no se dice si `CTX-SDEI-2` (con o sin SDD) no cambia nada en la doble audiencia. Además, para `CTX-SDEI-3` sólo se cubre el repositorio hermano y no el repositorio dedicado.
- **Gravedad:** baja.
- **¿Lo responde otro documento?** No.

**19.** Diagrama: «docs-guard AI-1 a AI-5»
- **Duda:** el Glosario también nombra AK-1 a AK-7 como «controles anti-inyección del sistema». El tema no explica cómo se relacionan con AI-1 a AI-5, ni si el fixture permanente (AK-7) forma parte del ensayo de §3.4.
- **Gravedad:** baja.
- **¿Lo responde otro documento?** Sí (anexo de criterios).

ALTAS=1 MEDIAS=13 BAJAS=5

## Ronda 2, TEM-05: salida del lector

# Prueba de lectura de TEM-SDEI-05

**1.** «Una fila `RD-` del registro se traza sin versión»
**Duda:** según el Marco, el registro de IDs se arma con `doc_id` o con encabezados que empiezan con el ID. Pero el RRD es una tabla, y una fila de tabla no es ninguna de las dos cosas. No sé cómo se declara `RD-01` para que `traces-resolve` lo encuentre.
**Gravedad:** media · **¿La responde otro documento?** sí (anexo del esquema, §6)

**2.** «Toda página de usuario traza a un `RD-`» (§1) frente a la fila de `ESC-SDEI-3`: «A qué traza: El caso de uso de la unidad de la pantalla»
**Duda:** en el panel con roles no queda claro si la fila `RD-` también es obligatoria. La tabla de escenarios no la nombra, y la de `ESC-SDEI-2` sí.
**Gravedad:** media · **¿La responde otro documento?** no sé

**3.** «`CTX-SDEI-3`… La traza resuelve contra el SHA de `source.lock`» y «trazan a casos de uso de otro sistema sin un `source.lock`»
**Duda:** no entiendo cómo interviene el SHA cuando se resuelve un ID. ¿`traces-resolve` lee el otro repositorio en ese commit? ¿Dónde se dice cuál es ese repositorio? En el panel con roles, ¿la compuerta lee el registro propio del SDD o sólo las declaraciones con `**Versión:**`?
**Gravedad:** media · **¿La responde otro documento?** sí (anexo del esquema, §4)

**4.** «para la página, el `.md` y el índice» (§2, §4) frente a «`.md` y `llms.txt`» (diagrama)
**Duda:** supongo que «el índice» es el `llms.txt`, pero el Glosario también llama «índice interno» a Ia-db. No sé si es lo mismo o si hay un tercer índice que también hay que filtrar.
**Gravedad:** media · **¿La responde otro documento?** no

**5.** «la decisión de qué ve cada rol se toma **en el servidor y en el build**»
**Duda:** lo del servidor se entiende (el 404). Lo del build no: si todos los roles usan el mismo binario, no sé qué hace el build. ¿Excluye páginas? ¿Genera un índice por rol?
**Gravedad:** media · **¿La responde otro documento?** no sé (`TEM-04` o la prueba de concepto)

**6.** «La página no la esconde ni la decide. La declara»
**Duda:** la plantilla del §6 no tiene un lugar para declarar una divergencia. No sé en qué sección ni con qué forma va: una nota, un aviso o una fila de «Si algo sale mal».
**Gravedad:** media · **¿La responde otro documento?** sí (`DEMO-MU-21`)

**7.** «el pull request que la cambia no entra hasta que la página se revisa»
**Duda:** según el Marco, Desarrollo (`ACT-SDEI-3`) no decide el texto de la ayuda. Entonces, cuando el dev sube la versión de la regla, no sé quién reescribe la página en ese mismo pull request. ¿Un agente propone el cambio? ¿Lo hace el `owner`?
**Gravedad:** media · **¿La responde otro documento?** no sé

**8.** «¿el pull request muestra que alguien releyó el texto contra la regla nueva?»
**Duda:** no hay ningún mecanismo que lo deje en evidencia: ni casilla, ni revisor obligatorio, ni comentario. Como evaluador, no sé qué buscar.
**Gravedad:** media · **¿La responde otro documento?** no sé

**9.** «Se arregla… mostrarlo sólo al rol que lo puede seguir»
**Duda:** no sé si el formato de página permite bloques o enlaces condicionados por rol dentro de una página común, ni con qué sintaxis.
**Gravedad:** media · **¿La responde otro documento?** sí/no sé (la prueba de concepto)

**10.** «se suma el campo `roles` (con los nombres del rol tal como los guarda el producto)»
**Duda:** no hay un ejemplo del campo. No sé si es una lista, ni cómo se marca una página común: ¿se listan todos los roles o se omite el campo? Tampoco sé qué herramienta lo valida contra el esquema.
**Gravedad:** media · **¿La responde otro documento?** sí (anexo del esquema, §3)

**11.** «Cualquier subida, mayor o menor»
**Duda:** no se dice cuándo se sube la versión MAYOR y cuándo la MENOR. Para la ayuda no cambia nada, porque las dos dan rojo, pero sí cambia para quien edita la ficha.
**Gravedad:** baja · **¿La responde otro documento?** sí (anexo del esquema)

**12.** «Es la única pieza del sistema documentador que lee alguien que no forma parte del equipo»
**Duda:** choca con `ESC-SDEI-4`, donde quien integra es externo y lee el README y el contrato (`CL-05`, `CL-13`).
**Gravedad:** baja · **¿La responde otro documento?** no

**13.** «Catálogo de ayuda en el producto» / «arma un catálogo de páginas»
**Duda:** en el Marco y en el Glosario, «catálogo» es el catálogo de clases de pieza (`CL-nn`). Acá nombra otra cosa, y eso va contra «un término, un significado».
**Gravedad:** baja · **¿La responde otro documento?** no

**14.** «`GUIA-DIR` es la carpeta del cuerpo»
**Duda:** el ensayo se presenta como «reproducible», pero no da el nombre real de la carpeta.
**Gravedad:** baja · **¿La responde otro documento?** sí (README)

**15.** «`1  /ayuda/comun/ingresar`… `10  /ayuda/alumno/…`»
**Duda:** no se explica qué significan los números 1 y 10, que parecen orden o peso. Además, la ruta del `GET` (`administrador/habilitar-cuentas`) no lleva el prefijo `/ayuda/`.
**Gravedad:** baja · **¿La responde otro documento?** sí (la prueba de concepto)

**16.** «`doc_id: <PREFIJO-NN>`»
**Duda:** no sé qué prefijo del registro cerrado corresponde a una página de ayuda. El ejemplo usa `DEMO-MU-`, que parece propio de la demo.
**Gravedad:** baja · **¿La responde otro documento?** sí (registro de prefijos)

**17.** «`confidence:` … # Obligatorio si origin no es human»
**Duda:** el Marco dice que todo documento lleva los diez campos. No sé si la ayuda es una excepción o si es una contradicción.
**Gravedad:** baja · **¿La responde otro documento?** sí (anexo del esquema)

**18.** «se sirve la del idioma fuente con un aviso visible»
**Duda:** no se dice cómo se elige el idioma de la sesión ni qué idioma es el fuente; supongo que `es`, por la ruta del ejemplo. Está rotulado como criterio propio.
**Gravedad:** baja · **¿La responde otro documento?** no sé

ALTAS=0 MEDIAS=10 BAJAS=8

## Ronda 2, TEM-06: salida del lector

# Prueba de lectura: TEM-06 Compuertas de calidad y CI

Leí el tema con el Marco y el Glosario. Estas son las dudas que esos tres textos no me responden.

**1.** «Las compuertas documentales de este cuerpo viven en un solo workflow reutilizable, `docs-guard`» (§1) y, en el diagrama, «Semanal o a mano → carril programado».
- **Duda:** No sé si el carril programado es un disparador más de `docs-guard` o un workflow aparte. El Glosario lo ancla en `docs-enlaces-semanal`, un nombre que el tema nunca usa. Tampoco sé en qué repositorio vive ni cómo se dispara «a mano».
- **Gravedad:** media. **¿Lo responde otro documento?** no sé.

**2.** «si alguno da rojo, el cambio no entra» / «**bloquean** el merge si dan rojo» (intro y §1).
- **Duda:** ¿Qué hace efectivo el bloqueo cuando fusiona una persona? Para el agente está la guarda G3. Para un merge humano no se dice si `docs-guard` es un check obligatorio de la protección de rama, ni quién lo configura (¿es un acto H?).
- **Gravedad:** media. **¿Lo responde otro documento?** no sé.

**3.** «`PR-3` Anti-inyección AI-1 a AI-5 (detalle en `TEM-04`)» y «AI-3 busca frases dirigidas al agente» (§1.1, §1.2).
- **Duda:** El Marco enumera cuatro formas (comentarios HTML, caracteres invisibles, HTML oculto y dominios fuera de lista) para cinco códigos. «Frases dirigidas al agente» no aparece entre ellas. No sé qué son AI-1 y AI-5. AI-4 = dominios lo deduzco, pero no está dicho.
- **Gravedad:** media. **¿Lo responde otro documento?** sí (TEM-04).

**4.** «`PR-6` … el contrato versionado contra el que emite el código» frente a «`docs-guard` no baja código» (§1.1 y §2, fila ESC-SDEI-2).
- **Duda:** ¿De dónde sale el contrato «que emite el código» si el job no baja código, no tiene secretos y dura 10 minutos? ¿Compila el proyecto? ¿Lee un `openapi.json` ya generado y commiteado? ¿Cómo sabe que «la ruta tiene uno»: por nombre de archivo, por un parámetro? Sin esto no entiendo cómo funciona PR-6.
- **Gravedad:** alta. **¿Lo responde otro documento?** no sé.

**5.** «Cualquier operación nueva, quitada o cambiada da rojo, rompa o no la compatibilidad» (§1.1).
- **Duda:** Entonces, ¿cómo entra un cambio legítimo de la API? Supongo que actualizando el contrato versionado en el mismo pull request, pero el texto no lo dice ni dice quién lo aprueba.
- **Gravedad:** media. **¿Lo responde otro documento?** no sé.

**6.** «El cuerpo nuevo endurece la compuerta: todo archivo exige frontmatter» (§2, ESC-SDEI-1).
- **Duda:** Fuera de un cuerpo nuevo, ¿qué verifica PR-2? ¿Un archivo sin frontmatter pasa? La tabla de grupos dice «Bloquea: Sí» sin esa distinción, a diferencia de `reflint`.
- **Gravedad:** media. **¿Lo responde otro documento?** sí, probablemente el anexo del esquema.

**7.** «los canaliza por excepciones con huella que aprueba una persona» (§1.2, condición 5).
- **Duda:** ¿Cómo queda registrada esa aprobación? Agregar una línea a `excepciones.txt`, ¿es un acto de clase H? Si un agente la agrega en su propio pull request y lo fusiona con la guarda G1–G4, ¿qué lo impide?
- **Gravedad:** media. **¿Lo responde otro documento?** no sé.

**8.** «su línea de base sobre el corpus que vigila es 0» (§1.2, condición 4) y CTX-SDEI-4 «El repositorio llama `uses: …docs-guard.yml@<SHA>`».
- **Duda:** Si un repositorio nuevo adopta `docs-guard` con enlaces rotos o sin frontmatter, PR-1 y PR-2 tienen línea de base distinta de 0 en ese repositorio. ¿Bloquean igual desde el primer día? ¿Hay que sanear antes de llamarlo? ¿Se puede activar por grupos?
- **Gravedad:** media. **¿Lo responde otro documento?** no sé.

**9.** «`PR-5` contra el registro del SDD» (§2, ESC-SDEI-3).
- **Duda:** PR-5 se definió contra «el registro generado de los encabezados». No se dice cómo lee el registro de un SDD, que tiene otro formato.
- **Gravedad:** baja. **¿Lo responde otro documento?** sí (TEM-05 o TEM-07).

**10.** «pasa `ruta` … y `herramientas-ref` (el mismo SHA)» / «Copia el workflow y anota su SHA-256» (§2, CTX-SDEI-4).
- **Duda:** Fuera de la organización, ¿alcanza con copiar el `.yml`? Las herramientas (`dg.py`, fixtures, `excepciones.txt`, configuración de lychee) ¿se copian, se bajan de Lab-Documentos o se fijan aparte? Dentro de la organización tampoco se explica por qué hay que pasar dos veces el mismo SHA.
- **Gravedad:** media. **¿Lo responde otro documento?** no sé.

**11.** «tiene una guarda `if:` que no corre pull requests que vienen de un fork … Un cambio que llega desde un fork, entonces, no pasa la compuerta» (§2, Seguridad).
- **Duda:** En GitHub, un job que se saltea por `if:` suele contar como éxito para los checks requeridos. ¿Ese PR de fork queda «en verde» para G3 o para la protección de rama? El texto da por hecho que no pasa, pero no explica por qué.
- **Gravedad:** media. **¿Lo responde otro documento?** no.

**12.** «el paso «validar» del documento de proceso» (§3.2).
- **Duda:** ¿Qué es «el documento de proceso»? No está en el Marco ni en el Glosario.
- **Gravedad:** baja. **¿Lo responde otro documento?** sí.

**13.** «`scripts/ci-local.sh todo` … corre la compuerta entera sobre la carpeta del cuerpo» / «si da verde en local, da verde en el pull request» (§3.2, §3.3).
- **Duda:** ¿Cómo le indico a `ci-local.sh` la carpeta, el equivalente de `ruta`? ¿Cómo instalo en local lychee, markdownlint y el parser de mermaid con las mismas versiones y SHA-256 que la CI? Sin eso no puedo reproducir el ensayo ni confiar en la equivalencia.
- **Gravedad:** media. **¿Lo responde otro documento?** no sé.

**14.** «Los controles de `dg.py` escriben…» (§4).
- **Duda:** `dg.py` aparece por primera vez acá, sin presentación. Deduzco que es el script de `tools/docs-guard/`.
- **Gravedad:** baja. **¿Lo responde otro documento?** sí.

**15.** «Un aviso … se cuenta en `avisos=n` … y no cambia su resultado» (§4) frente a «Compuerta pobre: un aviso en la salida que nadie lee» (§5).
- **Duda:** Los avisos del carril PR (AI-3, AI-4 en el anexo, `reflint` heredado, `url-fecha`, `cita-linea`) quedan sólo en el log. ¿Llegan a algún lado, como un comentario en el PR o el issue semanal? Si no, la compuerta descripta cae en la columna «pobre» de su propio criterio.
- **Gravedad:** media. **¿Lo responde otro documento?** no.

**16.** «abierto con la misma cabeza, sin conflictos, CI en verde y sin reserva» (§1, G1–G4).
- **Duda:** Sólo G3 está identificado, por el Glosario. Infiero que el orden de la frase es G1, G2, G3, G4, pero no está dicho.
- **Gravedad:** baja. **¿Lo responde otro documento?** sí.

**17.** El diagrama de §1.2 dice «Sin falsos positivos conocidos».
- **Duda:** La condición 5 del texto admite además «o los canaliza por excepciones con huella». El árbol omite esa rama y lo leo distinto que la lista.
- **Gravedad:** baja. **¿Lo responde otro documento?** no.

**18.** «`CQ-03`, `CQ-05`, `CQ-11`, `CQ-13` y `CQ-14`» (§5).
- **Duda:** Salvo CQ-13 (diagramas, por el Marco), no sé qué exige cada uno.
- **Gravedad:** baja. **¿Lo responde otro documento?** sí (anexo de criterios).

**19.** «Un archivo está en un cuerpo nuevo si … tiene un `README.md` con `corpus_id`» (§1.2).
- **Duda:** Según el Marco, todo cuerpo documental tiene ese README. Entonces, ¿«cuerpo nuevo» significa simplemente «cuerpo» y «heredado» significa «fuera de todo cuerpo»? La palabra «nuevo» confunde.
- **Gravedad:** baja. **¿Lo responde otro documento?** no.

**20.** «abriendo o actualizando un issue» / «abre o actualiza un único issue» (§1, §5).
- **Duda:** ¿En qué repositorio se abre ese issue? ¿Es uno en total o uno por control o por repositorio? ¿Quién lo atiende?
- **Gravedad:** baja. **¿Lo responde otro documento?** no sé.

ALTAS=1 MEDIAS=11 BAJAS=8

## Ronda 3, TEM-04: salida del lector

# Prueba de lectura: TEM-SDEI-04, Doble audiencia

No hay dudas de gravedad alta: el tema se entiende y se puede aplicar. Hay 12 medias y 8 bajas.

| # | Cita | Duda | Gravedad | ¿La responde otro documento? |
|---|---|---|---|---|
| 1 | «El `AGENTS.md` no es un canal de la fuente» (§1) frente a «Canales activos: Markdown con frontmatter y `AGENTS.md`» (§2, ESC-SDEI-1) | El tema define que `AGENTS.md` no es un canal, pero lo pone en la columna de canales activos. El Marco (CTX-SDEI-1) también lo cuenta entre «los canales para agentes». ¿Es canal o no? | media | no |
| 2 | «Índice generado del frontmatter → agente» (diagrama §1); «no se versiona, se genera cuando hace falta» (§3.3) | ¿Este índice es un canal activo en algún escenario o sólo un ensayo? Si no se versiona, ¿quién lo genera, cuándo, y cómo lo encuentra el agente? | media | no sé |
| 3 | «Es la misma información que tomaría un índice interno» (§3.3) | El índice interno se define como algo que el agente consulta «antes de leer el código de un sistema». Entonces indexa código, no frontmatter de documentos. ¿Qué contiene en realidad la ia-db? | media | sí (Mapa, CL-08) |
| 4 | «un archivo que agrega todo el contenido en menos de 50 000 *tokens*» (§2, CTX-SDEI-1 con sitio) | ¿Con qué tokenizador se cuentan? ¿Qué se hace si el contenido no entra: se parte, se recorta o se acepta? | media | no sé |
| 5 | «el asistente del usuario que lee la ayuda» (§2, ESC-SDEI-2) | En ESC-SDEI-2 no se dice por qué canal le llega la ayuda al asistente. El `.md` y el `llms.txt` de la ayuda sólo se mencionan para ESC-SDEI-3. ¿Una app sin roles también los sirve? | media | sí (TEM-05) |
| 6 | «No hay `llms.txt` ni páginas `.md` derivadas» (§2, CTX-SDEI-1 sin sitio) | Leída de forma absoluta, la frase choca con el `llms.txt` de la ayuda en ESC-SDEI-3, que puede existir sin sitio. La tabla de §1 lo aclara, pero esta fila no lo matiza. | baja | no |
| 7 | «Frases dirigidas al agente, de una lista cerrada […] Hablar **sobre** agentes […] no las dispara» (AI-3) | ¿La lista se compara de forma literal o por patrones? ¿Cómo distingue la herramienta entre hablar sobre un agente y dirigirse a uno? | media | sí (`dg.py`, TEM-06) |
| 8 | «Avisa […] si no puede resolverlo, declara una reserva y el merge queda para una persona» (AI-3) | ¿Un aviso cuenta como «éxito» en la guarda G3? ¿Puede un agente fusionar con un aviso de AI-3 pendiente? Y si el pull request lo abre una persona, ¿qué significa «declarar una reserva»? | media | sí (TEM-06 o Cómo decidir) |
| 9 | «AI-5: HTML oculto (`hidden`, `display: none`)» | Este mismo tema contiene esas cadenas como código en línea. ¿La compuerta ignora el código en línea y los bloques de código? Si no los ignora, el tema daría rojo. | media | no sé |
| 10 | «Los controles AI-n son el control AK-1 […] del glosario» (§3.4) | El glosario no enumera AK-1 a AK-7. Sólo dice «excepciones con huella, lista de dominios, fixture permanente», así que no se puede confirmar que AK-1 sean los AI-n ni saber qué son AK-2 a AK-6. | media | sí (TEM-06) |
| 11 | Diagrama: «docs-guard AI-1 a AI-5 → rojo → El PR no entra» | AI-3 sólo avisa y AI-4 tiene una salvedad. El diagrama sugiere que los cinco bloquean. | baja | no |
| 12 | Marco, «Anti-inyección»: «comentarios HTML, caracteres invisibles, HTML oculto, enlaces […] (AI-1 a AI-5)» | Nombra cuatro formas para cinco controles: falta la de frases dirigidas al agente (AI-3). | baja | no |
| 13 | Glosario: «Hay cuatro familias de siglas parecidas» | La tabla que sigue tiene seis filas. | baja | no |
| 14 | `traces: [MARCO-SDEI, MAPA-SDEI, ANX-SDEI-ESQUEMA, ANX-SDEI-CQ, ANX-SDEI-REFERENCIAS]` | El tema depende del Glosario (para AK-1), de TEM-05 y de TEM-06, pero no los traza. ¿Con qué criterio se decide qué va en `traces`? La pregunta guía 3 sólo comprueba que lo trazado exista. | media | sí (anexo del esquema, §4) |
| 15 | `audience: [humano, agente, …]` frente a `audience: [persona-usuaria, agente]` (§6); `doc_type: guia-practica` | ¿`audience` y `doc_type` tienen un vocabulario cerrado? ¿Cuáles son los valores válidos? «Humano» y «persona-usuaria», ¿son lo mismo? | media | sí (anexo del esquema) |
| 16 | «pasa por una revisión registrada (`CQ-14`)» (§5) | ¿Qué cuenta como «registrada»: una aprobación en el pull request, una entrada en una bitácora o un campo del frontmatter? Hace falta saberlo para aplicarlo cuando un agente escribió la pieza. | media | sí (anexo de criterios) |
| 17 | AI-4: «Sí, salvo en el anexo de referencias» | ¿Esa salvedad está fija en la herramienta o es una excepción con huella? ¿AI-4 también revisa los enlaces relativos? | baja | sí (`dg.py`) |
| 18 | `python3 -I tools/docs-guard/dg.py ai GUIA-DIR` | No se explica el flag `-I` ni el subcomando `ai`. Tampoco se dice desde qué carpeta se corre el comando. | baja | sí (TEM-06) |
| 19 | «analizado en la [guía de un solo archivo]» (§3.1) | No se dice qué es ese documento ni qué relación tiene con el cuerpo: si es un antecedente, si sigue vigente o si es otra guía. | baja | sí |
| 20 | «Si no fue una persona sola, hace falta confidence» (§6) frente a «los diez campos más `description`» (Marco) | ¿`confidence` es obligatoria siempre, como uno de los diez campos, o sólo cuando hubo asistencia? | baja | sí (anexo del esquema) |

ALTAS=0 MEDIAS=12 BAJAS=8

## Ronda 3, TEM-05: salida del lector

# Prueba de lectura: TEM-05 Ayuda al usuario final

Leí el tema con el Marco y el Glosario como único contexto. Estas son las dudas que esos tres textos no me responden.

**1.** «`doc_id: <PREFIJO-NN>  # ¿Con qué ID estable la cita el registro…?`» (§6, plantilla)
- **Duda:** ¿Qué prefijo uso para una página de ayuda? El Marco exige «un prefijo del registro cerrado», pero el tema solo muestra `DEMO-MU-21`, que es un prefijo de la demo. No sé si existe uno propio para la ayuda (algo como `AYU-`). Sin ese dato, no puedo asegurar que la compuerta de frontmatter acepte la página, y el tema promete justamente eso.
- **Gravedad:** alta
- **¿Lo responde otro documento?** Sí (anexo del esquema, §5).

**2.** «La fila `RD-` y el caso de uso de la unidad de la pantalla, en el registro del SDD» (§2, `ESC-SDEI-3`)
- **Duda:** En un proyecto con SDD, ¿los casos de uso (`CU-`) también llevan la línea `**Versión:**` que lee `traces-resolve`? ¿O el registro del SDD tiene otro formato? Tampoco sé si `docs-guard` lee ese registro o solo las declaraciones del propio repositorio. La plantilla pide `<RN-o-CU>@<MAYOR.MENOR>`, pero no sé de dónde saco la versión de un `CU-`.
- **Gravedad:** media
- **¿Lo responde otro documento?** No sé (quizá `TEM-07`).

**3.** «trazan a casos de uso de otro sistema sin un `source.lock` […] la compuerta los marca como "no verificables" en lugar de bloquear» (§3.2)
- **Duda:** ¿Con qué criterio decide la compuerta que una traza que no resuelve es «de otro sistema» (y entonces solo avisa) y no un ID inexistente (y entonces da error, como `RN-LOC-99`)? Si me equivoco al tipear un `CU-`, ¿la compuerta me deja pasar con un simple aviso?
- **Gravedad:** media
- **¿Lo responde otro documento?** No sé.

**4.** «Una fila `RD-` del registro se traza sin versión» y «Traza: Ninguna, o el ID sin versión» (§1 y §5)
- **Duda:** ¿La compuerta detecta una página de usuario sin traza a un `RD-`? ¿Y una traza a una regla versionada escrita sin `@versión`? ¿O esas dos son solo criterios de revisión humana? El tema dice que la compuerta automatiza `CQ-03`, pero no aclara si cubre estas omisiones.
- **Gravedad:** media
- **¿Lo responde otro documento?** Sí (anexo del esquema, §4).

**5.** «Toda página de usuario traza a un `RD-`» y «¿Qué fila `RD-` del registro la pide, y quién la aceptó?» (§1 y §4)
- **Duda:** ¿Cómo escribo esa fila? No sé qué columnas exactas lleva, cómo se numera el `RD-nn`, ni cómo se registra la aceptación de la analista. El tema enumera los campos, pero no muestra ninguna fila.
- **Gravedad:** media
- **¿Lo responde otro documento?** Sí (anexo del esquema, §6).

**6.** «`GUIA-DIR` es la carpeta del cuerpo» (§3.2)
- **Duda:** El ensayo se presenta como reproducible, pero no sé cuál es la ruta real de esa carpeta dentro de Lab-Documentos. Tampoco sé si el comando se puede correr desde el repositorio de mi propio proyecto.
- **Gravedad:** media
- **¿Lo responde otro documento?** Sí (README del cuerpo).

**7.** «Sin servidor de ayuda | La ayuda es un `.md` en el repositorio» (§2, contextos)
- **Duda:** En `ESC-SDEI-2` (una app MAUI), si la ayuda es un `.md` en el repositorio, ¿cómo llega a la persona usuaria, que no lee el repositorio? ¿Se empaqueta en la app, se enlaza, o la demo simplemente no lo resuelve?
- **Gravedad:** media
- **¿Lo responde otro documento?** No sé.

**8.** «lo que no es para ningún usuario […] se decide en el build: no se compila en el producto» (§2, confidencialidad)
- **Duda:** ¿Con qué mecanismo se excluye? No sé si es por carpeta, por un campo del frontmatter (`audience`, `roles` vacío) o por configuración del build.
- **Gravedad:** media
- **¿Lo responde otro documento?** Sí (README de la prueba de concepto, probablemente).

**9.** «se suma el campo `roles` […] una página común lista todos los roles» (§3.3 y §6)
- **Duda:** ¿Qué pasa con una página de un panel con roles que no tiene el campo `roles`? ¿Se entrega a todos, a nadie, o la compuerta o el validador la rechazan? Es justamente el riesgo de filtrar contenido que el tema quiere evitar, y el valor por defecto no está dicho.
- **Gravedad:** media
- **¿Lo responde otro documento?** Sí (anexo del esquema, §3).

**10.** «`status: borrador`» en la plantilla, y en Estados «`borrador` → `vigente`; pasar a vigente es acto H»
- **Duda:** ¿Una página de ayuda en `borrador` se entrega igual a la persona usuaria? ¿Tiene que pasar a `vigente` (por decisión del PO) antes de compilarse en el producto?
- **Gravedad:** media
- **¿Lo responde otro documento?** No sé.

**11.** «el número de la izquierda es el orden en la navegación» (§3.3)
- **Duda:** ¿De dónde sale ese orden (1, 10)? La plantilla no tiene ningún campo para fijarlo.
- **Gravedad:** baja
- **¿Lo responde otro documento?** Sí (README de la prueba de concepto).

**12.** «`ID@MAYOR.MENOR` […] Cualquier subida, mayor o menor, deja la traza desfasada» (§1 y §5)
- **Duda:** ¿Cuándo se sube la versión mayor y cuándo la menor? Si las dos producen el mismo rojo, no veo para qué sirve distinguirlas.
- **Gravedad:** baja
- **¿Lo responde otro documento?** Sí (anexo del esquema, §4).

**13.** «`translation_of: es/alumno/enviar-un-trabajo.md@a1b2c3d`» (§3.4)
- **Duda:** Este campo apunta a una ruta, y el Marco dice que «una traza apunta al identificador, no a la ruta». ¿`translation_of` es una excepción o no cuenta como traza? ¿Una traducción tiene su propio `doc_id`?
- **Gravedad:** baja
- **¿Lo responde otro documento?** No sé.

**14.** «`audience: [persona-usuaria]`» (§3.1 y §6)
- **Duda:** ¿`persona-usuaria` es un valor admitido del campo? En el resto del cuerpo aparecen otros valores (`humano`, `estudiante`…).
- **Gravedad:** baja
- **¿Lo responde otro documento?** Sí (anexo del esquema).

**15.** «el README del paquete y la referencia del contrato (`CL-05`, `CL-13`)» (§2, `ESC-SDEI-4`)
- **Duda:** No sé qué clase corresponde a cada pieza. El Glosario solo nombra `CL-06`.
- **Gravedad:** baja
- **¿Lo responde otro documento?** Sí (Mapa, §4).

**16.** «Con una sesión del rol que no corresponde, ¿la página, su `.md` y el índice devuelven nada?» (§4, evaluar 2)
- **Duda:** «devuelven nada» es ambiguo. Por lo que dice §2, entiendo que la página y el `.md` dan 404 y que el índice no la lista, pero la redacción obliga a reconstruirlo.
- **Gravedad:** baja
- **¿Lo responde otro documento?** No.

**17.** «`python3 -I tools/docs-guard/dg.py trazas GUIA-DIR`» (§3.2)
- **Duda:** Si mi proyecto vive en otro repositorio (`CTX-SDEI-4`, copia del workflow), ¿también copio `dg.py` para correrlo localmente, o solo existe dentro de Lab-Documentos?
- **Gravedad:** baja
- **¿Lo responde otro documento?** No sé.

ALTAS=1 MEDIAS=9 BAJAS=7

## Ronda 3, TEM-06: salida del lector

# Prueba de lectura — TEM-SDEI-06 (con Marco y Glosario)

1. **Cita:** «el que emitió el código (`contracts/.generado/openapi.json`, que tiene que dejar un paso previo del mismo job)»
   - **Duda:** `docs-guard` es un workflow reutilizable de un solo job, y el tema dice que «no baja código». ¿Quién agrega ese paso previo? Desde el repositorio que llama al workflow no se pueden meter pasos dentro de ese job. ¿Qué pasa si el archivo generado no está: da rojo o se saltea?
   - **Gravedad:** alta (no puedo aplicar PR-6 en un repositorio con contrato).
   - **¿Lo responde otro documento?:** no sé.

2. **Cita:** «Si el contrato tiene un `source.lock` que nombra otro workflow, la extracción y la comparación las hace ese workflow»
   - **Duda:** el Glosario dice que `source.lock` fija un SHA, no que nombre un workflow. ¿Cómo es ese campo? En ese caso, ¿PR-6 sale verde en `docs-guard`? ¿El resultado del otro workflow entra al agregador o a G3?
   - **Gravedad:** media.
   - **¿Lo responde otro documento?:** no sé.

3. **Cita:** «Lo heredado son las demás guías del repositorio […]: ahí los mismos defectos avisan»
   - **Duda:** leída así, todos los defectos avisan en lo heredado. Pero la tabla de grupos sólo afloja dos cosas: el archivo sin frontmatter (PR-2) y `reflint` (PR-7). Un enlace roto o un AI-1 en una guía vieja, ¿bloquean o avisan?
   - **Gravedad:** media.
   - **¿Lo responde otro documento?:** no.

4. **Cita:** «lo llama sólo sobre una carpeta ya limpia (el parámetro `ruta`)» / «`scripts/ci-local.sh todo <carpeta>`, por defecto la de esta guía»
   - **Duda:** si la compuerta corre sobre `ruta`, ¿cuándo llega a ver lo heredado? En Lab-Documentos, ¿qué `ruta` se pasa: la raíz o cada guía? ¿Hay un `README.md` con `corpus_id` en la raíz que vuelva «nuevo» todo el repositorio?
   - **Gravedad:** media.
   - **¿Lo responde otro documento?:** no sé.

5. **Cita:** «Anti-inyección AI-1 a AI-5 (detalle en `TEM-04`)» / «AI-3 busca frases dirigidas al agente»
   - **Duda:** el Marco enumera cuatro tipos (comentarios HTML, invisibles, HTML oculto, dominios) y no menciona las frases dirigidas al agente. Me falta la tabla número → chequeo: sólo deduzco AI-2, AI-3 y AI-4.
   - **Gravedad:** media.
   - **¿Lo responde otro documento?:** sí (TEM-04).

6. **Cita:** «un fixture permanente con las cinco formas de inyección, que **tiene** que dar rojo en cada corrida»
   - **Duda:** AI-3 sólo avisa, y `url-fecha` también. ¿Qué significa «dar rojo» en el par rojo/verde de un control que sólo avisa? ¿`autoprueba` mira el aviso o el código de salida?
   - **Gravedad:** media.
   - **¿Lo responde otro documento?:** no sé.

7. **Cita:** «`tools/docs-guard/fixtures/<control>/`» / «fixture permanente»
   - **Duda:** los fixtures rojos tienen defectos a propósito. ¿Cómo se evita que PR-1 a PR-4 los encuentren cuando la carpeta revisada los incluye? ¿Se excluyen por ruta o con excepciones con huella?
   - **Gravedad:** media.
   - **¿Lo responde otro documento?:** no sé.

8. **Cita:** «agregarla es de clase H, así que un agente no la agrega en su propio pull request»
   - **Duda:** ¿cuál es el procedimiento? ¿Una persona en un pull request aparte? ¿Puede un agente proponerla en otro pull request y que la persona lo apruebe? ¿El `sha256` es del contenido crudo del archivo?
   - **Gravedad:** media.
   - **¿Lo responde otro documento?:** no sé (quizás «Cómo decidir»).

9. **Cita:** «Copia sólo el `.yml` […] y anota su SHA-256 como pieza fijada» / `runs-on: [self-hosted, i7infra-dev]`
   - **Duda:** el `runs-on` está escrito fijo. Para correr en otro runner, ¿hay que editar la copia? Si se edita, ¿con qué se compara el original para saber que «avanzó»? Además, ¿esa organización tiene que copiar también `docs-enlaces-semanal` para tener carril programado?
   - **Gravedad:** media.
   - **¿Lo responde otro documento?:** no sé.

10. **Cita:** «G3 al menos una corrida de controles y todas en éxito»
    - **Duda:** ¿`docs-guard` corre en todo pull request o sólo si toca `ruta` (filtro `paths`)? Si un pull request no toca docs y el workflow no corre, ¿G3 nunca se cumple?
    - **Gravedad:** media.
    - **¿Lo responde otro documento?:** no sé.

11. **Cita:** «G1 abierto con la misma cabeza»
    - **Duda:** ¿la misma que cuál: la del informe publicado o la de la última corrida verde?
    - **Gravedad:** baja.
    - **¿Lo responde otro documento?:** sí («Cómo decidir»).

12. **Cita:** «`cita-linea` (ruta del workspace sin línea)»
    - **Duda:** ¿qué es una «ruta del workspace» y cómo se le agrega la línea (`ruta:l. n`, `#L12`)?
    - **Gravedad:** baja.
    - **¿Lo responde otro documento?:** no sé.

13. **Cita:** «toda URL de la prosa sin fecha de consulta»
    - **Duda:** ¿qué formato tiene que tener la fecha de consulta para que el control la reconozca?
    - **Gravedad:** baja.
    - **¿Lo responde otro documento?:** sí (Referencias).

14. **Cita:** «`scripts/ci-local.sh todo`» / «su paso `herramientas`»
    - **Duda:** ¿`todo` incluye `herramientas` y `avisos`, o hay que correrlos aparte? ¿Cuál es la lista de pasos posibles? La correspondencia con PR-n (enlaces = PR-1, …) la deduzco sólo por el orden.
    - **Gravedad:** baja.
    - **¿Lo responde otro documento?:** no sé.

15. **Cita:** «comparación de contratos entre líneas de versión» (ESC-SDEI-4)
    - **Duda:** ¿quién la hace, dónde corre y si bloquea?
    - **Gravedad:** baja.
    - **¿Lo responde otro documento?:** no sé.

16. **Cita:** «Esa guarda es higiene, no barrera»
    - **Duda:** viene justo después de hablar de la protección de rama. Por el contexto deduzco que se refiere a la guarda `if:` contra forks, pero el referente es ambiguo.
    - **Gravedad:** baja.
    - **¿Lo responde otro documento?:** no.

17. **Cita:** «AI-4 avisa en el anexo […] (falla la 5: todo hallazgo sería un falso positivo)»
    - **Duda:** la condición 5 admite canalizar los falsos positivos con excepciones con huella. ¿Por qué no se usa eso con el anexo?
    - **Gravedad:** baja.
    - **¿Lo responde otro documento?:** no.

18. **Cita:** «avisa hasta que lo sea» (AI-3)
    - **Duda:** cuando la línea de base llegue a 0, ¿quién decide el paso a bloqueo y qué se cambia (`dg.py`, el agregador)?
    - **Gravedad:** baja.
    - **¿Lo responde otro documento?:** no sé.

19. **Cita:** «se cuenta en `avisos=n` del resumen del grupo»
    - **Duda:** la salida del ensayo no muestra ningún `avisos=n`, así que no sé dónde aparece.
    - **Gravedad:** baja.
    - **¿Lo responde otro documento?:** no.

20. **Cita:** Marco: «PR-1 a PR-7 (…, contrato, referencias)» y «regla de bloqueo del anexo de criterios»
    - **Duda:** el Marco dice que PR-7 es «referencias», pero el tema dice «fijadas y reflint». Además, el Marco ubica la regla de bloqueo en el anexo de criterios y el tema la define acá. ¿Cuál es la fuente canónica?
    - **Gravedad:** baja.
    - **¿Lo responde otro documento?:** sí (Criterios de calidad).

21. **Cita:** «`CQ-03`, `CQ-05`, `CQ-11`, `CQ-13` y `CQ-14`»
    - **Duda:** salvo CQ-13 (diagramas, que aparece en el Marco), no sé qué exige cada uno.
    - **Gravedad:** baja.
    - **¿Lo responde otro documento?:** sí (anexo de criterios).

ALTAS=1 MEDIAS=9 BAJAS=11
