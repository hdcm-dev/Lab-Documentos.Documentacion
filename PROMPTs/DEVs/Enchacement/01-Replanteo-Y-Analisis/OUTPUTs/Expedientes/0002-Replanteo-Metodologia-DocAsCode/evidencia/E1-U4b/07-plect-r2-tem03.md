# P-LECT ronda 2, TEM-SDEI-03 (lector: sesión nueva de Claude Code, no interactiva, sin herramientas, que recibió sólo el texto del tema)

# Prueba de lectura P-LECT: TEM-SDEI-03, Topología de repositorios y versionado

| ID | Sección | Pasaje | Duda | Gravedad | ¿En un documento enlazado? |
| --- | --- | --- | --- | --- | --- |
| D-01 | Introducción | «la fase 3 (diseño) asigna la clase de una pieza, y con la clase vienen su topología y su ancla» | ¿Qué es una «clase»? ¿Cada clase define su topología o solo la sugiere? Con este texto no puedo pasar de la clase a la topología. | media | sí |
| D-02 | Definición (y todo el tema) | «para que la compuerta la lea»; «la compuerta verifica el SHA» | No se define «compuerta». Supongo que es un control de CI (¿`docs-guard`?), pero no sé qué es, dónde corre ni quién la configura. | media | sí |
| D-03 | Definición, tabla de topologías | «Repositorio hermano … Lab-Documentos.Documentacion» / «Repositorio dedicado … Lab-Documentos» | El ejemplo de repositorio hermano corresponde a un repositorio dedicado, no a uno de código. ¿Un repositorio dedicado también tiene hermano? ¿El hermano solo existe si hay código? | media | no |
| D-04 | Definición | «guarda índices, expedientes y bitácoras»; «cada índice de la ia-db» | Se usan sin definir «expediente», «bitácora», «índice para agentes» e «ia-db». | media | sí |
| D-05 | Definición, tabla de anclas | «Versión del cuerpo … y una etiqueta anotada por compuerta» | ¿«Por compuerta» quiere decir una etiqueta cada vez que la compuerta da verde? ¿Qué cuenta como cambio mayor, menor o de parche en una guía de estudio? | media | sí |
| D-06 | Definición, tabla de anclas | «Etiqueta … Qué la verifica: … el CHANGELOG de esa versión» | ¿La compuerta comprueba que el CHANGELOG exista, o el CHANGELOG solo sirve a las personas? | baja | sí |
| D-07 | Definición, dónde se escribe el ancla | «En la cabecera de cada índice … Líneas `base_commit: <SHA>`» | ¿«Cabecera» es el frontmatter YAML o una tabla en el cuerpo? (En Fuentes se habla de «la tabla de anclas»). | media | sí |
| D-08 | Definición y ejemplo `source.lock` | «Líneas `repo:` y `sha:`», pero el ejemplo también trae `comparar:` y `rutas:` | ¿`comparar` y `rutas` son obligatorias? ¿`rutas` limita la medición de deriva, la resolución de anclas o las dos? ¿Qué hay en las líneas 1–3? | media | sí |
| D-09 | Cuándo SHA y cuándo etiqueta | «La etiqueta se agrega cuando existe una que contiene exactamente el código» | En una pieza anclada con `source.lock`, ¿dónde se escribe la etiqueta? La forma de `source.lock` no tiene un campo para la etiqueta, y `base_tag` solo se menciona para índices. | media | no |
| D-10 | Aplicación por escenario | ESC-SDEI-3 «Etiqueta y SHA»; ESC-SDEI-4 «Mismo repositorio … Etiqueta por línea» | Esto contradice la regla «mismo repositorio → ancla: el commit». ¿Cuándo lleva etiqueta o SHA una pieza que está en el repositorio del código? ¿Dónde se escriben? ¿A qué piezas del escenario se aplica cada ancla? No puedo completar el campo «Ancla» de la plantilla para esos escenarios. | **alta** | no |
| D-11 | Definición, traza | «`@1.1` dice contra qué versión de la ficha vale»; «la ficha sube la versión cuando cambia lo que promete» | Las fichas usan MAYOR.MENOR. ¿Qué cambio sube la menor y cuál la mayor? ¿Hay parche? ¿Cualquier subida deja en rojo las trazas, incluso un cambio menor compatible? | media | sí |
| D-12 | Definición, traza | «los identificadores de este cuerpo llevan su `corpus_id`» | ¿Dónde se declara el `corpus_id` y cómo se elige? ¿Hay reglas de forma? | media | sí |
| D-13 | Ejemplo `source.lock` | «las fichas de reglas resuelven sus anclas `ruta#Símbolo@SHA`» | Aparece una sintaxis nueva sin explicar. ¿Dónde se escribe? ¿Qué cuenta como «Símbolo»? ¿Cómo la resuelve la compuerta? | media | sí |
| D-14 | Ejemplo `source.lock` | «el workflow de la demo mide la deriva y sólo avisa» | ¿Cómo se mide la deriva: commits de atraso, cambios en `rutas`? ¿Qué necesita un proyecto para armar ese aviso? | media | sí |
| D-15 | La regla para ubicar una pieza | Diagrama, rama «del producto, pero formativa, de demostración o de varios productos» | ¿Adónde va una pieza que habla del producto, no cambia en el mismo pull request y no es formativa, ni de demostración, ni de varios productos? El diagrama no cubre ese caso. | media | no |
| D-16 | Regla y plantilla del Anexo | «¿Cambia en el mismo pull request…? No en esta demo: el código vive en otro repositorio» | La respuesta usa la topología para justificar la topología. ¿Con qué criterio se decide si una pieza «tiene que» cambiar con el código sin saber antes dónde vive? | media | no |
| D-17 | Aplicación por escenario | `ESC-SDEI-1..4`, `CTX-SDEI-1..4` | ¿Dónde se definen los escenarios y contextos? ¿Cómo sé cuál se aplica a mi proyecto? | media | sí |
| D-18 | Aplicación por escenario | «con un sello por página» | ¿Qué es el «sello» y qué datos lleva? | baja | sí |
| D-19 | Aplicación por escenario | «fuera de la organización del runner … se copia con su huella (SHA-256)» | ¿Qué es «el runner»? ¿Dónde se registra la huella de la copia? | baja | sí |
| D-20 | Adopciones públicas | «P4 … P5 … P6» | La numeración supone que existen P1–P3. ¿Cuáles son y dónde están? | baja | sí |
| D-21 | Adopciones y escenarios | P5 «una rama por versión» y P6 «copias versionadas»; ESC-SDEI-4 «una línea de documentación por línea de versión» | ¿Con qué criterio se elige entre ramas y copias versionadas? ¿Cuál de las dos es la «línea» de ESC-SDEI-4? | media | no |
| D-22 | Ensayo reproducible | «Precondición: un clon de Lab-Documentos y Python 3» | El script está en `Lab-Documentos.Documentacion` (expediente 0002), así que también hace falta ese repositorio. ¿Cómo se lo obtiene y desde dónde se corre? | media | no |
| D-23 | Ensayo reproducible, caso 3 | «errores=3 … trazas=3 resueltas=0» | Se muestra un solo error. ¿De dónde salen los tres errores y la tercera traza? (La salida está recortada). | baja | no |
| D-24 | Ensayo y Criterios | «PR-5 traces-resolve» | ¿Qué es «PR-5»: un número de control o de regla? ¿Hay un catálogo de controles? | baja | sí |
| D-25 | Criterios y Fuentes | «Existencia de `source.lock` o `base_commit`; bloquea» y «Ningún índice … declara todavía `base_commit`» | Si ningún índice declara `base_commit`, ¿la compuerta hoy bloquea esos índices o el control todavía no se aplica? | media | sí |
| D-26 | Anexo, plantilla | «Trazas: RD-01, RN-LOC-01@1.1 …»; «CL-06» | ¿Qué es `RD-01` y por qué va sin versión? ¿Es válida una traza sin `@` cuando la ficha no tiene versión? | baja | sí |
| D-27 | Fuentes, observación sobre la compuerta | «Hasta que se corrija, toda página lleva al menos una traza» | Si una página no depende de ninguna ficha, ¿qué traza se le pone? ¿Vale una traza a su propio cuerpo (por ejemplo, `MARCO-SDEI`)? | media | sí |
| D-28 | Definición y escenarios | «carpeta como `docs/` o `SDD/`»; «`CTX-SDEI-2` con SDD» | No se define «SDD». | baja | sí |
| D-29 | Definición, tabla de topologías | «Artefacto del build … ancla: el commit que la emite» | Si otro repositorio consume el artefacto (por ejemplo, el `openapi.json` que usa la demo), ¿qué ancla lleva y dónde se registra? | baja | no |

Total: 29 dudas; altas: 1; medias: 19; bajas: 9
