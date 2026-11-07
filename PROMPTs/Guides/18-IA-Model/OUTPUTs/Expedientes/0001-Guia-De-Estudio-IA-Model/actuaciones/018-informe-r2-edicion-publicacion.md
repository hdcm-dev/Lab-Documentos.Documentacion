# Informe r2 — Comisión de edición académica, pedagogía y publicación científica (ronda 2)

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-07 |
| Autor | comisión edición-publicación (ronda 2) |
| Corrige | — |

Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas: cabecera y §0 (líneas 1–111, con el Mapa de
carga), la carta (§5.2), §2.2, §3.2, §3.3 y §4 — la fila de comisión del Mapa de carga. Además
cargado: Cadena-De-Consecuencias 2.0 §2 (antes de recomendar entre opciones, en los hallazgos
R2-EDI-01 y R2-EDI-07). Excepcion-A-Un-Conocimiento no se cargó: esta comisión no propone dejar de
seguir ninguna convención que rige.

Competencia (carta de la ronda 1, evidencia 008): edición bibliográfica, académica y de libros;
diseño pedagógico; normas de citado y publicación científica; criterios de evidencia verificable.
No-competencia: la corrección técnica del contenido de IA y la arquitectura de sistemas — nada de
lo hallado acá juzga si una afirmación del dominio es técnicamente cierta; juzga si está citada,
normada, consolidada y enseñable. No emito solicitudes de convocatoria: no encontré señal técnica
fuera de mi lente.

Objeto: las 15 piezas de `<worktree-guia>/Guides/IA/IA-Model/` (M0, M1, M2, M3 y núcleos 01–11),
contrastadas con el pedido (folio 001), el contrato (folio 002), lo aprobado por el jurado
(folio 011) y las observaciones compiladas (evidencia 015, con su adenda). Lectura P0–P3: la del
folio 002. Clase de objeto: corpus documental existente (la de esta ronda).

Insumos leídos: folios 001, 002 y 011; pliego operativo (evidencia 002); evidencia 015 entera;
las 15 piezas del corpus (M0, M1, M2 y M3 enteras; los once temáticos por envoltura, frontmatter,
bloque didáctico, referencias y barridos mecánicos sobre el texto completo); constancias
verif-01…verif-11 (por su lista y lo que la 015 transcribe de ellas). Verificación de citas por
muestreo: web (arXiv:2505.09388 y OSAID 1.0, consultadas 2026-11-07) más contraste de los ~80
identificadores arXiv del corpus contra la literatura del dominio.

Sin BLOQUEO: ningún paso prescripto falló (los barridos, la lectura del corpus y las dos consultas
web cerraron).

---

## 1. Hallazgos

Tope 12; ordenados por nivel. Cada uno con nivel, ancla, impacto y dirección de la corrección (no
su redacción). Comandos corridos desde `<worktree-guia>/Guides/IA/IA-Model/`.

### R2-EDI-01 · P1 · E1+E2 — La regla de forma canónica del glosario está incumplida a escala de corpus

M1 §5.1 regla 1 (E2): «Cada término tiene una sola forma canónica en toda la guía […] nunca ambas
alternándose»; la tabla de §5.2 fija *dataset*, *token*, *embedding*, *chunk*, *checkpoint* en
cursiva. E1 (conteo sobre los once temáticos, prosa y código juntos):
`grep -ho '\*token\*' …` vs `grep -howi 'token' …` → token 32 en cursiva de 298 ocurrencias;
embedding 41/84; chunk 9/42; checkpoint 1/24; y «dataset» plano 67 veces en el doc 04 (su dueño),
29 en el 06, 0 en cursiva en ambos. Parte de las ocurrencias planas es código o campo de API
(exento por M1 §6.2), pero la alternancia en prosa la confirmaron por separado editor-06, editor-10
(«la cursiva de *embedding*/*token* alterna […] 09 la mezcla también») y esta relectura.
**Impacto**: la única regla tipográfica del glosario quedó letra muerta; cada documento nuevo
elegirá su propia grafía y el barrido correctivo crece con cada entrega.
**Dirección** (Cadena-De-Consecuencias §2, cuatro pasos): (a) barrido tipográfico de conjunto — cae
en los once temáticos, pesa cientos de ediciones triviales con riesgo de tocar salidas verificadas
dentro de cercas, y pierde poco más que el tiempo; (b) reescribir la regla 1 a una forma
exigible — cursiva obligatoria sólo en primera aparición y en definiciones; en el resto de la
prosa, grafía libre pero única (sin «data set»/«dataset» alternados) — cae en M1 (un solo archivo),
pesa unas líneas, pierde la uniformidad visual absoluta, y es reversible (endurecer después es
aditivo); el barrido (a) es caro y también reversible pero su costo se paga en artefactos ya
verificados. Se recomienda (b), con condición de revisión: si una ronda posterior mide confusión
real de lectores entre formas, se endurece. La que no sirve es la situación actual: regla dura +
práctica contraria, sin declarar.

### R2-EDI-02 · P1 · E2 — El verbo «entrenar» se entrega por debajo del alcance aprobado, con la verificación pendiente sin cerrar

Folio 011 §4 (E2): «entrenar → doc 06 (QLoRA sobre Qwen ≤1.5B con PEFT/TRL, export GGUF,
**servido en el banco**)». Frontmatter de `06-Ajuste-Fino-Y-Alineacion.md` (E2): `entorno_validado:
"parcial — […] la corrida completa de entrenamiento y el servido en el banco quedan ilustrativos"`,
con `confidence: media`. La duda de redactor-06 a ACT-03 (crear `taller-qwen`/`taller-qwen-base` en
el banco y borrarlos al cerrar; evidencia 015, dudas) sigue sin respuesta y su default («los crea,
corre el paso 6 y los borra») no se ejecutó.
**Impacto**: el laboratorio bandera del verbo más caro del pedido («entrenarlos») se publicaría sin
que nadie lo haya visto correr punta a punta; si la receta no reproduce, el defecto sale a
producción editorial y lo encuentra el lector. La divergencia está declarada con honestidad en el
propio documento — por eso no es P0 (no se afirma nada no verificado) —, pero contra el alcance
aprobado es un hueco.
**Dirección**: antes de pasar ninguna pieza a `status: vigente`, o se corre la verificación
completa del 6.B con el default de la duda ya formulada, o la resolución de cierre asienta la
divergencia respecto del folio 011 §4 como deuda con evento de cierre (la respuesta de ACT-03), no
como silencio.

### R2-EDI-03 · P2 · E2 — El mismo informe técnico se cita de dos maneras, una de ellas contra la norma propia

M3 §2.2 (E2) norma: «Informe técnico de un equipo de modelos | Equipo como autor colectivo […] |
Qwen Team (2025). “Qwen3 Technical Report”. arXiv:2505.09388». Pero
`grep -n 'Yang.*2025' *.md` → 03 (líneas 194 y 737), 08 (50 y 754), 06 (135 y 773) y M1 (§5.2 y
§7) citan ese mismo arXiv:2505.09388 como «Yang, A., et al. (2025)»; el 06 además usa «Qwen Team,
2025» para el Qwen2.5 TR (arXiv:2412.15115) — dos criterios dentro del mismo documento. (La web da
las dos lecturas como defendibles — arXiv lista a An Yang y 59 coautores, consultado 2026-11-07 —
pero la guía ya eligió una en su norma.) Confirma y unifica las observaciones [editor-06] y
[editor-08] de la evidencia 015.
**Impacto**: el lector ve dos entradas distintas para la misma fuente según el documento; cualquier
índice de referencias futuro las contará como dos obras.
**Dirección**: unificar a la forma de M3 §2.2 (autor colectivo) en 03, 06, 08 y M1 — es la norma ya
votada (H-EDI-04 fijó el sistema; M3 fijó el tipo de fuente); tocar M3 en la otra dirección sería
reabrir sin motivo.

### R2-EDI-04 · P2 · E2 — El glosario quedó sin consolidar: los núcleos definen términos que M1 no lista

M1 §5.1 regla 3 (E2): «Entra al glosario el término que algún núcleo usa» (decisión FP-07); regla 4:
«los redactores agregan […]; el mantenedor (ACT-06) consolida». La consolidación no ocurrió:
`grep -ci <término> Marco-De-Referencia.md` → 0 para BPE, SentencePiece, subpalabra, RoPE, GQA,
máscara causal, safetensors, prompt de sistema / system prompt, ASR, códec neuronal, espectrograma,
JSONL, datasheet y procedencia — todos con definición normativa o primer uso en 01, 02, 04, 06, 08
o 10, y todos señalados como candidatos por sus propios redactores y editores en la evidencia 015
([redactor-01], [redactor-04], [redactor-10], [editor-02], [editor-06], [editor-10]: se confirman
en bloque). «Destilación» tiene entrada con dueño 11, pero [redactor-11] declara que el 11 no la
define normativamente: entrada que apunta a una definición que no existe (hueco por la propia regla
FP-07).
**Impacto**: la promesa de M1 («todos los documentos usan estas formas canónicas») es falsa por
omisión; el lector que siga el reenvío de «destilación» no encuentra nada.
**Dirección**: una pasada única de consolidación de ACT-06 sobre la lista ya compilada en la 015
(está completa; no hay que relevarla de nuevo), más resolver «destilación» (definición de ~15
líneas en 11 §1, como su redactor ya dimensionó, o reasignar dueño).

### R2-EDI-05 · P2 · E2 — Tres documentos superan la extensión normada sin declarar el apartamiento

M3 (E2, línea 21): «Cuando un documento temático necesite apartarse de una convención, lo declara
al abrir, con motivo: un apartamiento silencioso se trata como defecto editorial»; §5: extensión
orientativa 350–700 líneas. `wc -l` → 03: 740, 06: 774, 08: 754; `grep -n -i 'apartamiento' *.md`
→ sólo 07 (línea 31) y 09 (línea 29) lo declaran. El 06 salió del redactor con 726 líneas y
declaración razonada en la 015, pero la declaración no está en el documento, y las ediciones de
verificación lo hicieron crecer.
**Impacto**: la convención de profundidad pierde fuerza ejecutiva — si tres de once se apartan en
silencio sin consecuencia, la ronda siguiente no tiene línea de base.
**Dirección**: agregar a 03, 06 y 08 la misma declaración de apertura que ya usan 07 y 09 (motivo:
salidas reales transcriptas), con su eje de partición nombrado; es aditivo y no toca contenido
verificado.

### R2-EDI-06 · P2 · E2 — El doc 02 ancla su laboratorio al banco sin fijar la versión del motor

M3 §6.2 (E2): «Todo documento con ejemplos operables lleva `entorno_validado` con […] **motor y
versión**, modelo y etiqueta, contexto y fecha»; §3 exige versiones fijadas por ejemplo.
`grep -n '0.32.0' 02-Arquitectura-Transformer.md` → sin salida: el frontmatter de IAM-02 dice
«laboratorio 2 verificado por API contra el banco (CTX-03), 2026-11-07» sin número de motor,
mientras 03, 07, 08, 10 y 11 fijan `ollama 0.32.0-rc0`. Confirma [editor-02] (evidencia 015), que
quedó sin aplicar.
**Impacto**: la «foto mínima que permite juzgar si sigue valiendo sin correr nada» (M3 §6.2) está
incompleta justo en el documento cuya ficha de modelo depende de qué claves expone cada versión del
motor (la corrección del verificador-02 al paso 2 nació exactamente de eso).
**Dirección**: completar `entorno_validado` de IAM-02 con motor y versión tomados de la constancia
verif-02; un campo, cero riesgo.

### R2-EDI-07 · P2 · E2 — Cifras de modelos concretos citadas a paper en documentos estables: la práctica contradice la letra de M3 §6.1

M3 §6.1 (E2): «Los documentos estables **no citan cifras ni rankings de modelos concretos** salvo
vía la tabla de referencia del documento 11». Pero 02 §1.6 da los 47 B totales / 13 B activos de
Mixtral 8×7B con cita a Jiang et al. (2024), y 05 declara (evidencia 015, [redactor-05]) «cifras de
modelos concretos sólo históricas y de paper (GPT-3, Chinchilla, LLaMA) con cita autor-año» — ambas
prácticas razonables y bien citadas, ninguna amparada por la letra. [editor-02] elevó la pregunta y
nadie la decidió: se eleva acá como hallazgo. 
**Impacto**: sin la exención escrita, cada revisor futuro decidirá distinto (es la definición de
interpretación divergente; se contiene a P2 porque el inventario actual es chico y está citado).
**Dirección** (Cadena-De-Consecuencias §2): (a) rerutear esas cifras vía la tabla del 11 — cae en
02 y 05, pesa poco, pero pierde exactitud de propósito: la tabla del 11 es capa volátil del parque
*vigente* y Mixtral/GPT-3/Chinchilla son hechos históricos fechados que no caducan con el catálogo;
(b) escribir en M3 §6.1 la exención que la práctica ya usa — «cifra histórica o arquitectónica con
cita a paper fechado queda exenta; cifra del parque vigente, sólo vía la tabla» — cae en M3, pesa
tres líneas, no pierde nada medible y es reversible. Se recomienda (b): legaliza la práctica
existente en lugar de deshacer trabajo citado.

### R2-EDI-08 · P2 · E2 — Fuentes del glosario que no sostienen la definición que se les atribuye

M1 §5.1 regla 2 (E2): «Toda entrada lleva […] fuente verificable»; M3 §2.3: una cita respalda lo
que se afirma. En la tabla de M1 §5.2, «inferencia», «motor de inferencia» y «tokens por segundo»
llevan como fuente «Yang et al. (2025)» (el Qwen3 Technical Report, que usa esos términos pero no
los define: es un informe de una familia de modelos, no la fuente del concepto), y «caché KV» lleva
«Vaswani et al. (2017)», paper que define atención y K/V pero no el *caching* de inferencia
(literatura posterior; el propio corpus cita arXiv:2211.05102, que sí lo trata). Son citas
decorativas: adornan la fila sin respaldarla.
**Impacto**: en una guía cuya restricción dura es «toda afirmación respaldada por evidencia
verificable», el glosario — la pieza más consultada — enseña al lector que la cita es un gesto.
**Dirección**: reatribuir esas cuatro filas a fuentes que definan el término (la de caché KV ya
está en el cuerpo), o asumir en M1 §5.1 que los términos operativos de industria sin paper
fundacional llevan «documentación oficial + fecha de consulta» como tipo de fuente (M3 §2.2 ya
tiene ese tipo).

### R2-EDI-09 · P3 · E2 — `owner` del frontmatter sin criterio único; M1 fuera de catálogo

`Marco-De-Referencia.md` → `owner: Lab-Documentos`; el resto usa actores, pero en dos formas:
«Mantenedor de la guía (ACT-06)» (M0, M2, M3, 01, 06, 09) vs «ACT-06» (02, 03, 05, 08, 10) vs
«Curador de datos (ACT-05)» (04) y «ACT-04» (07). M3 §1.1 pide el bloque normado de la casa y el
actor por su ID. Confirma [M0-raiz] (evidencia 015).
**Impacto**: una consulta mecánica por dueño (`grep '^owner:'`) devuelve cuatro formas.
**Dirección**: fijar en M3 §1.1 la forma única (ID solo, o ID con rótulo) y normalizar los quince.

### R2-EDI-10 · P3 · E2 — `traces` sin criterio declarado: cada documento lista cosas distintas

01, 03, 07, 08, 09 y 10 incluyen IAM-M1/M2/M3 en `traces`; 02, 04, 05 y 06 listan sólo vecinos; 11
agrega IAM-M0. [editor-04] ya lo señaló (prerrequisito+siguiente vs otra cosa) y quedó sin
unificar. **Impacto**: para la doble audiencia declarada (M0 §5: «el frontmatter es la interfaz de
carga» del agente), `traces` es hoy una señal ruidosa. **Dirección**: M3 §1.1 declara qué va en
`traces` (propuesta barata: prerrequisitos del grafo + siguiente de la ruta; los M* no, porque son
apoyo universal) y una pasada lo normaliza.

### R2-EDI-11 · P3 · E2 — Divergencias menores entre plantilla y práctica del aparato

(a) El bloque didáctico del 02 marca sus piezas en cursiva (`*Criterio que forma*:`) donde la
plantilla de M3 §7 y los otros diez documentos usan negrita — `grep -c '\*\*Criterio que forma'
02-…` → 0, contra 4–5 en los demás. (b) El ejemplar de cita de M3 §2.2 usa comillas españolas en el
título («Attention Is All You Need») mientras todas las secciones Referencias reales usan redonda o
cursiva sin comillas y capitalización de oración: el patrón normativo no coincide con la práctica
uniforme del cuerpo. **Impacto**: ruido de imitación para el próximo redactor. **Dirección**:
negrita en el bloque didáctico del 02; actualizar los dos ejemplares de M3 a la forma que el cuerpo
ya usa de manera uniforme.

### R2-EDI-12 · P3 · E2 — Grafías y erratas menores sin asentar

«des-tokenizar» (01 §1.2, acuñamiento sin entrada en M1), «no-determinismo» (03, dos veces, con
guion), la errata «Dá una regla mnemotécnica» dentro de `preguntas.jsonl` transcripto en 07 §3.1
(salida verificada: corregirla implica recorrer el lab o asentar la errata, como [editor-07] midió
bien). Confirma [editor-01], [editor-03] y [editor-07]. **Impacto**: acotado; ninguna confunde el
sentido. **Dirección**: las dos primeras entran en la consolidación de glosario/grafías de
R2-EDI-04 (M1 §6.1 es su lugar natural); la errata del jsonl se asienta como errata declarada junto
al bloque, sin recorrer el laboratorio.

---

## 2. Observaciones de la evidencia 015 de mi competencia: disposición

| Etiqueta | Disposición |
| --- | --- |
| [editor-06] dataset plano vs glosario | **Confirmada**, absorbida y ampliada en R2-EDI-01 |
| [editor-10] cursiva *embedding*/*token* alterna; [editor-01] celdas 110–115 caracteres | La primera **confirmada** en R2-EDI-01; la segunda **descartada como hallazgo** (dentro de tolerancia que el propio editor midió; sin regla violada) |
| [editor-06]/[editor-08] Yang et al. vs Qwen Team | **Confirmada**, R2-EDI-03 |
| [redactor-01]/[redactor-04]/[redactor-10]/[editor-02]/[editor-06]/[editor-10] candidatos a glosario; [M1-marco] «destilación» dueño 11 | **Confirmadas en bloque**, R2-EDI-04 |
| [editor-07]/[editor-09] extensión con apartamiento declarado (07, 09) | **Descartadas como hallazgo**: conformes a M3; el hallazgo es el inverso (03/06/08 sin declarar), R2-EDI-05 |
| [redactor-06] 726 líneas sin declarar en el documento | **Confirmada**, R2-EDI-05 |
| [editor-02] lab 2 sin versión del motor | **Confirmada**, R2-EDI-06 |
| [editor-02] cifras de Mixtral, ¿exentas? | **Elevada**, R2-EDI-07 |
| [M0-raiz] owner de M1 | **Confirmada**, R2-EDI-09 |
| [editor-04] criterio de `traces` | **Confirmada**, R2-EDI-10 |
| [editor-01] «des-tokenizar»; [editor-03] «no-determinismo»; [editor-07] «Dá» | **Confirmadas**, R2-EDI-12 |
| [editor-06] status/confidence del 06 | **Confirmada** como parte de R2-EDI-02 (la promoción depende de cerrar la verificación) |
| [M2-cohesion] marcas VERIFICAR restantes en 06 (2) y 07 (9) | **Resuelta**: `grep -c 'VERIFICAR' *.md` → 0 en las quince piezas (la reparación de la tubería las cerró); sin acción |
| [editor-05]/[editor-03]/[editor-04]/[M0-raiz] enlaces a piezas aún inexistentes | **Resueltas**: las 15 piezas existen y todos los enlaces relativos resuelven (barrido de enlaces `](…​.md)` contra el directorio → cero rotos; guía 16 incluida); las anclas `#3-ejemplos-concretos` apuntan a encabezados reales |
| [M1-marco] seis fuentes agregadas al glosario (Hu, Dettmers, Rafailov, Zheng, Hinton, Ji) | **Confirmadas como válidas**: las seis son canónicas y sus entradas en M1 §7 están bien formadas; muestreo de existencia descripto abajo |
| [editor-11]/[redactor-11] primarias pendientes en 11 §1.5 | **Confirmada la conformidad**: marcadas «primaria pendiente de verificación» con tarea asignada (ACT-06), conforme a M3 §2.3; es compuerta de promoción a `vigente`, no defecto del borrador |

Las observaciones de redactores y verificadores sobre corridas, digests y hechos del dominio no son
de mi competencia y no se tocan acá.

## 3. Lo que revisé y está bien (tres ítems)

1. **El aparato de citado resiste el muestreo.** arXiv:2505.09388 existe y es el «Qwen3 Technical
   Report» (2025) y la OSAID es efectivamente la versión 1.0 con las exigencias sobre pesos, código
   y datos que M1 §5.2 y el doc 11 le atribuyen (ambas consultadas por web el 2026-11-07); los ~80
   identificadores arXiv del corpus corresponden a los papers que los textos nombran (Vaswani,
   Brown, Hoffmann, Lee, Lewis, Holtzman, HNSW, GPTQ/AWQ, vLLM, Mamba, Mixtral, DeepSeek-R1, …),
   sin ninguna cita inventada detectada; cada documento cierra con su sección Referencias completa,
   en autor-año uniforme, con fecha de consulta donde hay fuente web (12 en el doc 11, 10 en el 09).
2. **La estructura cumple lo aprobado, pieza por pieza.** Quince piezas (folio 011 §4), todas con
   frontmatter, índice propio, envoltura con prerrequisitos y Anterior/Siguiente, las seis secciones
   de la plantilla, bloque didáctico de cuatro piezas y mermaid donde corresponde; cero marcas
   VERIFICAR; el grafo de M2 coincide exactamente con las envolturas y con el folio 011 §2, y la
   ruta formativa de M0 es el orden votado, con la alteración del 08 explicada al lector con su
   motivo.
3. **La didáctica forma criterio, no memoria.** Los bloques didácticos muestreados (01, 02, 03, 08,
   11) preguntan por decisiones («¿quién tiene razón?», «¿qué te importa a vos?»), explicitan el
   criterio que forman y reenvían al laboratorio que lo realimenta — exactamente la forma
   H-EDI-07/ARQIA-05 —; el registro para ACT-01 se sostiene (ninguna pieza asume más que terminal y
   programación básica, y las excepciones lo marcan al abrir); los desvíos medidos por los
   verificadores (conteo «tres figuras», empate 0,421, el base que sí responde) quedaron
   incorporados como material didáctico en lugar de barridos bajo la alfombra — criterio editorial
   ejemplar.

## 4. Dudas para quien pidió

| rol | pregunta | por qué | prioridad | default |
| --- | --- | --- | --- | --- |
| presidencia → ACT-03 (operador del banco) | ¿Se autoriza la corrida completa del lab 6.B (crear `taller-qwen`/`taller-qwen-base` en el banco, correr, borrar) antes del cierre editorial? | El alcance aprobado (folio 011 §4) llega «hasta servir el resultado» y hoy ese tramo queda ilustrativo (R2-EDI-02); la duda ya está formulada en la evidencia 015 y sigue sin respuesta | alta | Se publica como borrador con la divergencia asentada como deuda con evento de cierre (la respuesta de ACT-03); ninguna pieza pasa a `vigente` hasta resolverla |

Sigue: incorporación de este informe por la presidencia · presidencia de la mesa
