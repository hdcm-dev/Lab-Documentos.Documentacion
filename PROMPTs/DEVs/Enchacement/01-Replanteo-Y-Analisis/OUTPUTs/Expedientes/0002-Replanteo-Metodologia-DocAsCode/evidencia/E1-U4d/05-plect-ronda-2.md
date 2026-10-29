# E1-U4d — P-LECT de TEM-07, ronda 2, 2026-10-27
# Lector sin contexto: claude -p sin herramientas; recibe sólo 00-Marco (referencia) y TEM-07 en su estado de la ronda, con la consigna:
#   Prueba de lectura P-LECT. Sos un lector sin contexto: estudiante de sistemas que nunca vio este repositorio ni el proyecto. No uses herramientas ni leas otros archivos: sólo el texto de abajo (dos documentos de una guía: 00-Marco, que fija el vocabulario, y el tema TEM-07). Leé el Marco como referencia y evaluá el TEM-07. Anotá TODAS las dudas concretas sobre TEM-07 que el texto NO responde (términos sin definir en su primer uso, saltos, referencias a cosas que no están, contradicciones, instrucciones ambiguas, ejemplos que no se pueden reproducir). No anotes dudas que el propio texto responde: en ese caso indicá dónde. Formato de salida: una tabla Markdown con columnas | # | Sección de TEM-07 | Duda | ¿La responde el texto? (no / sí, en …) | Gravedad (alta/media/baja) |, y al final una línea «Dudas sin respuesta: N» y otra «Dudas altas sin respuesta: N». Respondé en castellano.

## Evaluación P-LECT de TEM-07

| # | Sección de TEM-07 | Duda | ¿La responde el texto? (no / sí, en …) | Gravedad (alta/media/baja) |
| --- | --- | --- | --- | --- |
| 1 | Frontmatter | `traces` incluye `ANX-SDEI-REFERENCIAS`, `ANX-SDEI-CQ` y `GP-SDEI-INTERVENIR`. ¿Qué documentos son? El Marco no los nombra; sólo se puede suponer que el último es «Cómo intervenir». | no | baja |
| 2 | Estado | ¿Qué es IA.SDD? Aparece por primera vez sin definir. | sí, en §1.4 («Marco SDD y proyecto destino»), pero recién después del primer uso | baja |
| 3 | Estado / §1.4 «Escalón» | Cada escalón tiene «su propia compuerta de cierre». ¿Qué cierra el escalón 1 y el 3? Sólo se dice cómo cierra el 2. | no | baja |
| 4 | §1.1 | Se presentan los tres grados de Böckeler (*spec-first*, *spec-anchored*, *spec-as-source*). ¿En cuál está IA.SDD o el SDD-B? ¿Las reglas del tema cambian según el grado? | no | baja |
| 5 | §1.1 punto 2 vs §2 (CTX-SDEI-2) | Una parte dice que el RRD vive junto a la especificación, «no en un archivo aparte». La otra dice que es «un archivo `doc_type: rrd`». ¿Es un archivo propio o no? ¿`rrd` es un `doc_type` válido? | no | baja |
| 6 | §1.1 punto 3 | ¿Cada escenario resuelve contra un SHA o contra una etiqueta? | sí, en §2 (tabla por escenario, última columna) | — |
| 7 | §1.3 / §1.4 / §2 ESC-SDEI-4 | Las trazas resuelven contra el proyecto destino, no contra el marco. Para el SDD-B (el Marco lo llama «marco SDD»), ¿cuál es el proyecto destino? ¿El marco y el proyecto son el mismo repositorio? | no | media |
| 8 | §1.4 «Cuerpos de la categoría 11» | Acá «cuerpo» quiere decir conjunto de documentos por rol. En el Marco, «Cuerpo documental» es otra cosa (una guía bajo un README con `corpus_id`). ¿Son el mismo concepto o es otro uso de la palabra? | no | baja |
| 9 | §1.4 «Prefijo externo» / §3.1 | Aparece el prefijo `RF`, pero nunca se dice qué es. «Especificación» sólo define NB, CU, RN y ADR. | no | baja |
| 10 | §1.4 «Lección de decisión» | Se define como una decisión «tomada sin la persona responsable», pero el nivel N3 es «consulta a la persona». Además: ¿qué clase de decisiones puede cerrar un agente con N1 o N2, si según el Marco (ACT-SDEI-4) no decide «nada de clase H»? | no | media |
| 11 | §1.4 «Prefijo externo» | ¿Qué significa «fuente fijada»? ¿Cómo sabe `dg.py` que una fuente está fijada, si sólo recibe una carpeta en `--fuente` y ningún SHA? Además, el Marco (§5, Trazas) dice que toda traza que no resuelve da rojo, y acá una externa «sólo avisa». | no | alta |
| 12 | §1.4 «Prefijo externo» | Se dice que `RN` es un prefijo externo. Pero en ESC-SDEI-2 las fichas `RN-LOC-nn` son propias y viven en este repositorio. Esas trazas, ¿son internas o externas? ¿Bloquean o sólo avisan? | no | media |
| 13 | §1.4 «Orquestador» | Se lo define como un agente o una persona. Pero el marco es «un repositorio con … los orquestadores», y en §2.1 se habla de «la norma de cada orquestador». ¿Es un actor o un archivo? | no | baja |
| 14 | §1.4 / §2.1 «Conocimiento compartido» | ¿Dónde está la «base de conocimiento común» del laboratorio? ¿Quién comprueba la huella de cada copia, y cuándo? | no | baja |
| 15 | §1.4 (diagrama) | El nodo `AGENTS.md CL-03` no tiene ninguna flecha. ¿Qué papel cumple en la integración? | no | baja |
| 16 | §2, fila ESC-SDEI-1 | La cita a IA.SDD tiene la forma `IA.SDD@bac7e48, archivo, l. 102`. El Marco (§5, Enlaces) pide `Repo@ancla:corpus_id/doc_id`. ¿Cuál vale? | no | baja |
| 17 | §2, fila ESC-SDEI-2 | Dice que la traza resuelve «contra el SHA fijado en `source.lock`». Pero los IDs `RN-LOC` se declaran en fichas, y ese SHA es el del código. ¿Qué se resuelve contra qué? | no | media |
| 18 | §2 ESC-SDEI-3 / CTX-SDEI-3 / §3.1 | La página de ayuda de Lab-Geometria parece vivir en el mismo repositorio que el SDD. En ese caso CTX-SDEI-3 dice que el ancla es el commit. Entonces, ¿por qué hace falta un SHA fijado y `git archive`? ¿Dónde se guarda ese SHA en ESC-SDEI-3 (no hay `source.lock`) y quién lo actualiza? | no | alta |
| 19 | §2.1 vs Marco §2.5 | La capa A (CL-11) se copia «a la carpeta de conocimiento de cada SDD», Lab-Geometria incluido. Pero en el Marco, CL-11 no figura entre las clases activas de ESC-SDEI-3. | no | media |
| 20 | §2 «Por contexto» | ¿Por qué se tratan tres contextos y no CTX-SDEI-1? | sí, en Marco §3 CTX-SDEI-1 («hoy ningún escenario publica sitio»), aunque TEM-07 no lo dice | — |
| 21 | §2, fila CTX-SDEI-2 | ¿En qué carpeta exacta de Lab-Geometria va el RRD? | no; el texto la declara pendiente del escalón 2 | baja |
| 22 | §2 CTX-SDEI-2 / Pregunta 5 | ¿Quién acepta cada fila del RRD? | sí, en Marco §4 (ACT-SDEI-2, analista) | — |
| 23 | §2 «Una regla que no cambia» | ¿Qué es el «plan de sprint de IA.SDD»? ¿Cómo se ubica en el ciclo, en general, una fase de un SDD que el ciclo no tiene? Hay un solo ejemplo. | no | baja |
| 24 | §2 «La frontera» | «Decide una persona»: ¿cuál? ¿El PO, el analista o quien es responsable del SDD? Además, la diferencia se declara «en el pull request», mientras que §1.3 dice «en la ficha de integración y en el pull request». | no | media |
| 25 | §2, tabla de fronteras, CL-07 | El sistema documentador «cita» la clase y a la vez «aplica el frontmatter y la compuerta». ¿Se editan los archivos de la categoría 11 del SDD? ¿Eso no choca con «no redefine la norma del SDD» (§1.3)? | no | media |
| 26 | §2, tabla de fronteras, CL-03 | No se define qué es la «consolidación de cierre de la categoría 11». Tampoco se dice qué control comprueba que `AGENTS.md` exista. | no | baja |
| 27 | §2, tabla de fronteras | En ESC-SDEI-3 están activas CL-02, CL-04, CL-05 y CL-08, pero no aparecen en la tabla. El criterio «Frontera declarada» (§5) pide decidir para cada clase. | no | media |
| 28 | §2.1, capa A | ¿Qué es «la carpeta de conocimiento de cada SDD»? ¿Cuáles son las «reglas de cada marco que ya lo dicen» que la capa A cita? | no | baja |
| 29 | §2.1, capa B | ¿Quién decide la capa B? | sí, en §2.1 (última línea: la persona responsable de cada SDD) | — |
| 30 | §3.1 | Se dice que CU-08002 es «el contrato de administración de cuentas», pero es un caso de uso. ¿Tiene algo que ver con el «contrato REST» del Marco? | no | baja |
| 31 | §3.1, guion | ¿En qué commit de Lab-Documentos (o sea, con qué versión de `dg.py`) se corrió el ensayo? Sin ese dato, el resultado puede no reproducirse. | no | media |
| 32 | §3.1, rótulo `[Compilado: …]` | El rótulo no da ruta ni líneas, que es la forma que pide el Marco (§5, Ejemplos). ¿Dónde está guardado el guion original? | no | baja |
| 33 | §3.1, salida | El guion imprime `caso X: exit=N`, pero la salida mostrada no trae los códigos de salida y tiene otro formato. ¿Qué código corresponde a rojo y cuál a verde? | no | baja |
| 34 | §3.1 | Sin `_legacy/` quedan 52 IDs repetidos. ¿Por qué no dan rojo? | sí, en §3.1 (caso B en verde; esos repetidos son rótulos que no se trazan) | — |
| 35 | §3.1, caso D | ¿Es válida una traza sin versión (`CU-03`)? | sí, en Marco §1 «Traza» (`traces: [ID]`) | — |
| 36 | §3.1 «Cómo pasa esto a la CI» | El proyecto llama al workflow reutilizable con `uses:`. ¿Cómo agrega el paso de preparar la fuente (`git archive` y borrar `_legacy/`) y cómo se la pasa a `docs-guard.yml`: con un input, con un job previo? No hay ningún fragmento de workflow. El «mismo patrón que la mini demo» tampoco se muestra. | no | alta |
| 37 | §3.1 | Los rótulos `H-01`, `N-01` y `BT-01` entran al registro pero no son prefijos del registro cerrado (Marco §5, Identificadores). ¿Dan aviso? ¿Hay que ignorarlos? | no | baja |
| 38 | §3.2 / Pregunta 4 | Si la pantalla usa un caso de uso de otra unidad, ¿a cuál se traza? La pregunta guía lo plantea, pero el texto no lo resuelve. | no | media |
| 39 | §3.3 | El proyecto tiene que «elegir qué encabezado declara el ID». ¿`dg.py` acepta cualquier encabezado, o sólo `doc_id` y `# ID — …` (Marco §1 «Traza»)? ¿Cómo se hace con Kiro, que pone varios requisitos en un solo `requirements.md`? | no | media |
| 40 | §3.3 | En «la herramienta, que no trae una norma propia», ¿«la herramienta» es Spec Kit o Kiro, o es `dg.py`? | no | baja |
| 41 | §5 «Ancla explícita» | Exige versión (`@MAYOR.MENOR`). Pero el Marco admite `traces: [ID]`, el caso D no lleva versión y el propio frontmatter de TEM-07 tampoco. ¿Una traza sin versión es «pobre»? | no | media |
| 42 | §5 «Decisiones registradas» | ¿Cómo se evalúa este criterio, si la capa A todavía no existe (§2.1)? | no | baja |
| 43 | §6 | «Ficha de integración» choca con «Ficha» del Marco (regla o caso de uso con ID, versión y `ruta#Símbolo@SHA`). ¿Lleva frontmatter y `doc_id`? ¿Cómo se llama el archivo? ¿Qué quiere decir exactamente «junto a» la instancia? | no | media |
| 44 | §6 | ¿Quién completa la ficha de integración y de qué clase (D/P/H) es? Campos como «Norma que no se toca» parecen de clase H. | no | baja |
| 45 | §6, campo «Prefijos que se trazan» | Si los prefijos no están como externos en el registro de prefijos, ¿qué se hace y quién los agrega? | no | baja |
| 46 | §6 | La instancia de ejemplo es la de Lab-Documentos, que es ESC-SDEI-1 y no tiene SDD, así que según la propia ficha «no hace falta». ¿Hay un ejemplo con SDD? | no | baja |
| 47 | Navegación final | No se define qué es la ruta «aprender». | no | baja |

Dudas sin respuesta: 40
Dudas altas sin respuesta: 3
