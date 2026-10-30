# P-LECT ronda 2, TEM-SDEI-02 (lector: sesión nueva de Claude Code, no interactiva, sin herramientas, que recibió sólo el texto del tema)

# Prueba P-LECT: TEM-SDEI-02, el ciclo documental

Encontré 31 dudas que el texto no responde: dos bloquean (D-02, D-08) y 22 obligan a adivinar. Las dos graves vienen de contradicciones o huecos del propio documento, no de enlaces que no pude abrir. Hay otras tres contradicciones internas que conviene corregir sin importar lo que digan los enlaces: D-01, D-15 y D-19.

| ID | Sección | Cita | Duda | Gravedad | ¿En un enlace? |
| --- | --- | --- | --- | --- | --- |
| D-01 | Definición › Qué es (diagrama) | `F5m -->\|"cambió la fuente o venció el plazo"\| F1a` | En el diagrama, el retorno va siempre a 1a. El párrafo siguiente dice que si sólo cambió la fuente se vuelve a 4. ¿Cuál vale? | media | no |
| D-02 | Ejemplos › Una fila del RRD | «Si el código cambia, el aviso de deriva devuelve la pieza a 1a.» | Contradice la regla de la Definición: si cambia el código pero el requerimiento sigue igual, se vuelve a 4. Así no puedo responder la pregunta guía 4. | alta | no |
| D-03 | Definición › Qué es | «cuando su fuente cambia o vence su plazo de revisión» | Si sólo venció `last_review` y no cambió nada, ¿a qué fase vuelve? Los dos criterios (necesidad o fuente) no cubren ese caso. | media | no |
| D-04 | Tabla de fases, 5m | «Prioriza el aviso» / «Propone la corrección (vuelve a 1a o a 4)» | ¿Quién decide si una deriva es de necesidad (1a) o de fuente (4)? ¿Lo propone el agente y lo confirma la persona? | media | no |
| D-05 | Definición, clases de intervención | «nadie declaró una duda que devuelva el merge a una persona» | ¿Cómo y dónde se declara una reserva (etiqueta, comentario, campo)? ¿Quién puede declararla? | media | sí |
| D-06 | Definición, clases de intervención | «una clase de intervención, quién la puede cambiar» | ¿Dónde se declara si un cambio es D, P o H: por pieza, por archivo, por campo? Sin eso no sé qué puede fusionar el agente en la fase 5. | media | sí |
| D-07 | Tabla de fases, 1b, y Aplicación por escenario | «Acepta, rechaza o difiere cada fila (`ACT-SDEI-2`)» / «Docente…», «PO» | La tabla de fases fija a `ACT-SDEI-2` (Analista, según la cláusula de ejemplo). La de escenarios nombra a docente o PO. ¿`ACT-SDEI-2` es un rol genérico o siempre es el analista? | media | sí |
| D-08 | Ejemplos y tabla de fases, 5 | «por delegación del PO» / «con la delegación asentada» | ¿Se puede delegar una decisión H? ¿A quién (¿también a un agente?), dónde se asienta y qué la hace válida? Sin esto no puedo responder las preguntas guía 2 y 5. | alta | sí (en parte) |
| D-09 | Ejemplos › Una fila del RRD | «la tomó la mesa del expediente» | ¿Qué es «la mesa del expediente»? ¿Una persona, un grupo? La plantilla pregunta «¿es una persona?». | baja | no |
| D-10 | Tabla de fases, 2 | «Inventario hecho por comando» | ¿Qué comando, y qué produce? | media | sí |
| D-11 | Tabla de fases, 2 y 5; escenario 2 | «fichas de reglas», «ancladas al SHA», «anclas fijadas» | ¿Qué formato tiene una ficha? ¿Qué es un ancla, quién la fija en la fase 5 y cómo? | media | sí |
| D-12 | Ejemplos; Anexo (`Fuente`) | `RN-LOC-01@1.1` / «ID@versión» | ¿Quién sube la versión de una ficha y cuándo? ¿Qué pasa con las páginas que citan la versión anterior? | media | sí |
| D-13 | Tabla de fases, 3 | «decisión de arquitectura propuesta» | ¿Hace falta una decisión de arquitectura por cada pieza, o sólo en ciertos casos? ¿Dónde queda escrita? | media | sí |
| D-14 | Tabla de fases, 5 | «Pasa a `vigente`, etiqueta, publica» | ¿«Etiqueta» quiere decir un tag de git? ¿Qué significa «publica» cuando no hay sitio? | baja | sí |
| D-15 | Estados / Qué no es | «en un pull request propio» / «recorre 1a a 5 en un solo pull request» | Si `vigente` exige su propio pull request, un cambio chico no cierra el ciclo en un solo PR. ¿Se queda en `borrador` después del merge? | media | no |
| D-16 | Estados del documento | `borrador` → `vigente` → `obsoleto` | Si edito un documento `vigente`, ¿vuelve a `borrador`? ¿Hace falta un nuevo acto H? | media | sí |
| D-17 | RRD, tabla de ubicación | «Junto a la especificación de la unidad de entrega» | ¿Con qué nombre de archivo y en qué formato? ¿Se usa la misma plantilla? | media | sí |
| D-18 | RRD, tabla de ubicación, fila 3 | «el RRD lo referencia» | En ese caso, ¿el RRD sigue existiendo como archivo propio? ¿Dónde vive? ¿La fila tiene igual Criterio y Decisión? | media | no |
| D-19 | RRD; Aplicación por escenario | «marco … guiado por especificación (`CTX-SDEI-2`)» / «`CTX-SDEI-2` sin SDD» | Primero se identifica `CTX-SDEI-2` con tener marco de especificación, después aparece «`CTX-SDEI-2` sin SDD». ¿Qué denota `CTX-SDEI-2`? | media | sí |
| D-20 | Ejemplos, RD-01 | Audiencia «persona usuaria» | No aparece en la lista `audience` que muestra el documento. ¿Es un valor válido del vocabulario? | media | sí |
| D-21 | Ejemplos, RD-01 | «cada número coincide con el de la ficha; instrumento: `traces-resolve`» | ¿`traces-resolve` compara números, o sólo resuelve trazas? ¿Puede ser instrumento una revisión humana? La pregunta guía 3 parece decir que no; la plantilla de cláusula, que sí. | media | no |
| D-22 | Ejemplos › Una cláusula | `obliga`: «…y quién la tomó» / instrumento `rrd-decision` | El instrumento no comprueba «quién la tomó» (el ensayo dice que la compuerta no lo lee). ¿Una cláusula así está bien formada? | media | no |
| D-23 | Cláusulas con criterio; Anexo | «La metodología misma se escribe como cláusulas» | Un proyecto que sólo adopta el ciclo, ¿está obligado a escribir cláusulas, o es sólo para quien redacta la metodología? ¿La sección de cláusulas de la plantilla es obligatoria? | media | no |
| D-24 | Anexo / Ejemplos | `### CLA-01` vs. `id: CLA-1b-01` | La plantilla no tiene fila `id` y numera `CLA-01`; el ejemplo usa `CLA-1b-01`. ¿Qué formato de identificador va? | baja | no |
| D-25 | Ejemplos › Ensayo | «Precondición: un clon de Lab-Documentos y Python 3» | El script está en Lab-Documentos.Documentacion, que la precondición no menciona. ¿Hacen falta los dos clones? ¿Dónde se ejecuta? | media | no |
| D-26 | Anexo, plantilla | `pendiente \| <quién, AAAA-MM-DD; …>` | Si la fila está `pendiente`, nadie decidió todavía. ¿Qué se pone en «Decide y fecha»? | baja | no |
| D-27 | Tabla de fases, 1b | «Filas … `diferido`» | ¿Quién vuelve a evaluar una fila diferida, y cuándo? | baja | no |
| D-28 | Criterios de calidad | «Toda página responde a una fila del RRD» | ¿Vale también para la referencia generada (D)? ¿Hay un control que lo exija, o sólo la revisión? | media | sí |
| D-29 | Preguntas guía, 2 | «¿Quién decide en la fase 1b de tu proyecto? ¿Está escrito?» | El texto no dice dónde debería estar escrito: en el RRD, en una cláusula, en CODEOWNERS, en el Marco. | media | no |
| D-30 | Anexo, plantilla | `confidence: <…, si origin no es human>` | Si `origin` es `human`, ¿se omite el campo o se deja vacío? | baja | sí |
| D-31 | Tabla de fases, 4 | «Grupos PR-1 a PR-7 de `docs-guard`» | Sólo se explica PR-2. ¿Qué es `docs-guard`, cómo se ejecuta fuera del ensayo y qué cubre cada grupo? | baja | sí |

Total: 31 dudas; altas: 2; medias: 22; bajas: 7
