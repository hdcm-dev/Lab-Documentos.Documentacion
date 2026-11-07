# Folio de veredicto — jurado (ronda 2: revisión del borrador completo)

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-07 |
| Autor | jurado (veredicto de la ronda 2) |
| Corrige | — |

Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas: cabecera y §0 (líneas 1–111, con el Mapa de
carga), §2 (§2.1–§2.3), §3 (§3.1–§3.4), §4, §7, §8 — la fila del jurado del Mapa de carga. Además
cargado entero: Cadena-De-Consecuencias 2.0 (§2 corrida antes de cada elección entre opciones de
este folio). Excepcion-A-Un-Conocimiento 2.1 no se cargó: no hay ficha que votar — el refutador lo
verificó por comando en su cabecera (`ls despacho/ | grep -i ficha` → sin salida) y los cinco
informes r2 declaran no proponer excepciones.

Insumos leídos: folios 001, 002, 011, 012 y 013; pliego operativo (evidencia 002); los cinco
informes de comisión y el del refutador de esta ronda (`despacho/r2-*.md`); las observaciones
compiladas con su adenda (evidencia 015); mi carta (evidencia 018, con la norma y cargas de la
carta 010); el corpus de 15 piezas en `<worktree-guia>/Guides/IA/IA-Model/` en las anclas que los
informes citan. Clase de objeto: corpus documental existente. Lectura P0–P3: la del folio 002.
Conforme a Rule-Mesa §3.5.4, voto cada hallazgo con las cinco funciones objetivo (evidencia,
impacto, costo-beneficio, coherencia histórica, riesgo e irreversibilidad); el fundamento de cada
voto va en una línea. No emito hallazgos ni redacto contenido: donde elijo entre direcciones,
elijo entre lo que el panel escribió, con su motivo. **Ningún tramo de clase C funda parche**: lo
degradado a C por el refutador queda anotado en el motivo del voto y no entra en ninguna
dirección.

---

## 1. Veredicto por hallazgo

El refutador consolidó las filas de comisión en hechos (su §1); voto cada fila para que ninguna
quede sin disposición, y el hecho consolidado hereda una sola dirección. Cuórum: cinco funciones
objetivo por ítem. Ningún PROCEDE de este folio es irreversible en P2/P3 (correcciones aditivas o
de consolidación en documentos versionados): el veto del juez de riesgo no se activa.

| # | Nivel · Ancla | Voto | Motivo (una línea) |
| --- | --- | --- | --- |
| R2-FUN-01 | P2 · E2 | PROCEDE | Nivelado a P2 por R2-REF-02 (la práctica fue uniforme; divergió de la letra, no entre aplicadores); dirección: exención escrita en M3 §6.1 — parche PA-01 |
| R2-FUN-02 | P2 · E1 | PROCEDE | Hecho real (dueño vacío); su sustento «variantes distill del ecosistema» es C sin ancla (R2-REF-01) y no funda: la dirección es la arbitrada en PA-03 |
| R2-FUN-03 | P2 · E2 | PROCEDE | Re-anclado por R2-REF-05: la parte «el TR no define» es C (nadie abrió el negativo); funda la divergencia citable glosario/dueño — parche PA-02 |
| R2-FUN-04 | P2 · E2 | PROCEDE | M3 §2.2 norma «Qwen Team (2025)» y cuatro piezas no lo ejercen; unificación barata y reversible — parche PA-04 |
| R2-FUN-05 | P2 · E2 | PROCEDE | La línea OSAID del glosario afirma lo que la norma no exige; el propio doc 11 §1.2 tiene la forma correcta; vale el hallazgo específico contra el aval genérico (dictamen del refutador) — PA-02 |
| R2-FUN-06 | P2 · E1+E2 | PROCEDE | Foto mínima de M3 §6.2 incompleta justo donde el lab depende del motor; entra a la pasada única de frontmatter (R2-REF-09) — PA-05 |
| R2-FUN-07 | P2 · E2 | PROCEDE | Consolidación del glosario prevista por la regla 4 y no ocurrida; barrido único antes de promover status — PA-02 |
| R2-FUN-08 | P3 · E2 | PROCEDE | Afirmación de industria sin cita en la pieza que enseña a exigirlas; cita o reformulación sin nombre de producto — PA-10 |
| R2-ENT-01 | P2 · E1+E2 | PROCEDE | El hecho procede; su dirección (a) (quitar la fila) no se adopta: la regla 3 manda decidir, no quitar (R2-REF-01), y definir en 11 conserva cobertura al mismo costo — PA-03 |
| R2-ENT-02 | P2 · E2 | PROCEDE | Mismo hecho que R2-FUN-04; dirección única: unificar a la forma normada — PA-04 |
| R2-ENT-03 | P2 · E2 | PROCEDE | Opción (a): agregar los tres bloques protocolo a 04 iguala a la pieza que cumple sin reescribir la regla — PA-07 |
| R2-ENT-04 | P2 · E2 | PROCEDE | Defecto de contenido (≈4,5 es Q4_0, no Q4_K_M): se corrige y se recorre el lab 3 (determinista, segundos), conforme al criterio de R2-REF-07 — PA-07 |
| R2-ENT-05 | P3 · E1 | ARCHIVA | Ancla defectuosa probada por R2-REF-04 (salida que no corresponde al comando); el hecho sobrevive con las anclas sanas de FUN-07/SIS-06/EDI-04 y no se hereda la defectuosa |
| R2-ENT-06 | P3 · E2 | ARCHIVA | Subsumido por R2-REF-03: un solo parche sobre M1 (la regla reescrita de EDI-01 b) deja «dataset» legal sin retocar su fila aparte |
| R2-ENT-07 | P3 · E2 | PROCEDE | owner/traces sin criterio único; entra a la pasada única de frontmatter — PA-05 |
| R2-ENT-08 | P3 · E2 | PROCEDE | Residuo de tubería visible al lector; quitar el paréntesis en ambos `<summary>` — PA-08 |
| R2-ENT-09 | P3 · E2 | PROCEDE | Mismo criterio mecánico de R2-REF-05: la fila del glosario copia la fuente normativa del dueño; Kaplan (2020) entra a Referencias de M1 — PA-02 |
| R2-ENT-10 | P3 · E2 | PROCEDE | Trazabilidad: la sustitución QLoRA→LoRA (default de la fila 1 del lote) y el tramo pendiente se asientan en el cierre, sin tocar el doc 06 — deuda PD-01 |
| R2-ENT-11 | P3 · E2 | PROCEDE | Defecto de forma en salida verificada: errata asentada junto al bloque con condición de recorrida, no se recorre 46 min por una tilde (criterio R2-REF-07) — PA-08 |
| R2-ENT-12 | P3 · E2 | ARCHIVA | Salida real aceptada como tal (dirección preferida de la propia comisión, avalada por el refutador): costo cero hoy, retoque sólo si el lab se recorre por otro motivo |
| R2-INF-01 | P2 · E2 | PROCEDE | Con la refinación de R2-REF-06: el descargo textual entra ya (PA-09); fijar la revisión exige dato observado (caché del verificador o recorrida) — deuda PD-02, nunca un commit inventado |
| R2-INF-02 | P2 · E2 | PROCEDE | Mismo hecho que FUN-06 más el segundo modelo de 08; una sola corrección en la pasada única — PA-05 |
| R2-INF-03 | P2 · E2 | PROCEDE | Es el ancla que el hecho consolidado adopta (R2-REF-05): divergencia citable, declarada sin afirmar negativos no abiertos — PA-02 |
| R2-INF-04 | P2 · E2 | PROCEDE | Consolidado en el hecho «entrenar» (R2-REF-08): M2 §5 anota la salvedad de 6.B igual que la del 09 — PA-11 |
| R2-INF-05 | P3 · E2 | PROCEDE | Divergencia ficha/artefacto sin leer en el documento que enseña a leerla; la nota al pie es material didáctico gratis — PA-10 |
| R2-INF-06 | P3 · E2 | PROCEDE | La frase citante no puede decir otra cosa que el dueño (M2 §4); reformulación de una línea — PA-09 |
| R2-SIS-01 | P2 · E1+E2 | PROCEDE | Mismo hecho «destilación»; dirección: definir en 11 §1 con cita primaria — PA-03 |
| R2-SIS-02 | P2 · E1+E2 | PROCEDE | Declarar el apartamiento en 03/06/08 con eje de partición, no partir: cadena bien corrida y condición de revisión del folio 011 §2 intacta — PA-06 |
| R2-SIS-03 | P2 · E2 | PROCEDE | Tres semánticas en el mismo campo vendido como interfaz de carga; semántica única en M3 y barrido en la pasada única — PA-05 |
| R2-SIS-04 | P2 · E2 | PROCEDE | Mismo hecho que FUN-01 ya nivelado; dirección única: la exención en M3 §6.1 — PA-01 |
| R2-SIS-05 | P2 · E2 | PROCEDE | Consolidado en «entrenar» P2 (R2-REF-08); su capa propia es la salvedad en M2 §5 — PA-11 y deuda PD-01 |
| R2-SIS-06 | P2 · E2 | PROCEDE | Mismo hecho que FUN-07 con ancla sana; barrido único de consolidación — PA-02 |
| R2-SIS-07 | P3 · E2 | PROCEDE | owner de M1 fuera de catálogo; se corrige en la pasada única — PA-05 |
| R2-SIS-08 | P3 · E2 | PROCEDE | Mismo hecho que FUN-04; se adopta además su nota «aunque el PDF liste autores» en M3 §2.2, que evita la próxima divergencia de buena fe — PA-04 |
| R2-SIS-09 | P3 · E2 | PROCEDE | Mismo hecho que FUN-03/INF-03; rige el criterio mecánico de R2-REF-05 — PA-02 |
| R2-EDI-01 | P2 · E1+E2 | PROCEDE | Nivelado a P2 por R2-REF-03 (desvío uniforme, corrección en un solo archivo); dirección (b): reescribir la regla 1 a forma exigible, con su condición de revisión — PA-02 |
| R2-EDI-02 | P2 · E2 | PROCEDE | Nivelado a P2 por R2-REF-08 (divergencia declarada, nada no verificado se afirma; lo retenido es sólo la promoción); es obstáculo con default, no detención — PA-11 y deuda PD-01 |
| R2-EDI-03 | P2 · E2 | PROCEDE | Mismo hecho que FUN-04; unificar a la norma ya votada, no reabrirla — PA-04 |
| R2-EDI-04 | P2 · E2 | PROCEDE | Consolidación del glosario sobre la lista ya compilada en 015 (no se releva de nuevo) más la decisión de «destilación» — PA-02 y PA-03 |
| R2-EDI-05 | P2 · E2 | PROCEDE | Mismo hecho que SIS-02; la declaración de apertura de 07/09 se replica en 03/06/08 — PA-06 |
| R2-EDI-06 | P2 · E2 | PROCEDE | Mismo hecho que FUN-06; el dato sale de verif-02 — PA-05 |
| R2-EDI-07 | P2 · E2 | PROCEDE | Mismo hecho que FUN-01/SIS-04; opción (b): legalizar la práctica citada en lugar de deshacer trabajo verificado — PA-01 |
| R2-EDI-08 | P2 · E2 | PROCEDE | La parte «el TR no los define» es C (R2-REF-05) y no funda; funda la divergencia con el dueño y el tipo de fuente «documentación oficial + fecha» que M3 §2.2 ya tiene — PA-02 |
| R2-EDI-09 | P3 · E2 | PROCEDE | owner en cuatro formas; forma única en M3 §1.1 y pasada única — PA-05 |
| R2-EDI-10 | P3 · E2 | PROCEDE | traces sin criterio declarado; semántica única y barrido en la misma pasada — PA-05 |
| R2-EDI-11 | P3 · E2 | PROCEDE | Divergencias plantilla/práctica (negrita del bloque didáctico de 02, ejemplares de M3 §2.2); entran a la pasada única — PA-05 |
| R2-EDI-12 | P3 · E2 | PROCEDE | Grafías a la consolidación de M1 (PA-02); la errata del jsonl se asienta sin recorrer (PA-08), conforme al criterio de R2-REF-07 |
| R2-REF-01 | P2 · E1+E2 | PROCEDE | Arbitraje correcto: la regla 3 manda decidir; definir en 11 conserva cobertura al mismo costo, con condición de revisión comprobable (si el parche no entra, la fila sale del glosario en el mismo barrido) |
| R2-REF-02 | P2 · E2 | PROCEDE | La re-lectura del pliego es exacta: práctica uniforme contra la letra es P2, no P1; dejarlo P1 bloquearía la promoción por una frase aditiva |
| R2-REF-03 | P2 · E2 | PROCEDE | Un solo parche normativo sobre M1 evita la norma mitad nueva y mitad vieja; el barrido de cientos de ediciones sobre salidas verificadas es la corrección peor que el defecto |
| R2-REF-04 | P3 · E1 | PROCEDE | Re-corrida propia que prueba el ancla defectuosa de ENT-05; en expediente verbatim un E1 defectuoso no se hereda — costo cero |
| R2-REF-05 | P2 · E2 | PROCEDE | Degrada a C los negativos no abiertos y re-ancla el hecho en la divergencia citable; el criterio mecánico (la fila copia la fuente del dueño) evita elegir una quinta fuente en el veredicto |
| R2-REF-06 | P2 · E2 | PROCEDE | Un commit escrito sin observación violaría «no inventar información»; la corrección pasa a tarea de verificación con dueño y el descargo textual entra ya |
| R2-REF-07 | P3 · E2 | PROCEDE | El criterio que reconcilia ENT-04 y ENT-11 (contenido se corrige y recorre; forma se asienta como errata con condición de recorrida) se asienta en M3 §4 — PA-12 |
| R2-REF-08 | P2 · E2 | PROCEDE | Nivel único P2 y las tres capas juntas (pregunta directa a ACT-03, salvedad en M2 §5, deuda con evento en la resolución); la pregunta va por canal directo de la presidencia, no al lote |
| R2-REF-09 | P3 · E2 | PROCEDE | La unidad de aplicación es el documento: un parche normativo en M3 y una sola pasada por los 15 frontmatters, con criterio de verificación mecánico — PA-05 |
| R2-REF-10 | P3 · E1 | PROCEDE | Cerró con corrida propia el hueco de verificación del requisito literal «gráficos mermaid» (13/13 compilan); la compuerta de promoción se asienta en M3 para que no vuelva a quedar sin red — PA-12 |

**Cuenta:** detectados 57 (47 de comisión + 10 del refutador) · PROCEDE 54 · NO PROCEDE 0 ·
ARCHIVA 3 (R2-ENT-05, R2-ENT-06, R2-ENT-12).

**Constancia de homogeneidad** (Rule-Mesa §3.5.4): los votos salieron 5–0 por encima del 80 %; se
marca el ciclo como sospechoso de homogeneidad y consta la causa observable: no hubo NO_PROCEDE
que el refutador deba revisar porque el refutador ya arbitró antes del veredicto — degradó dos P1
a P2 (R2-REF-02, R2-REF-03, R2-REF-08), tumbó un ancla (R2-REF-04), degradó tramos a C
(R2-REF-01, R2-REF-05) y repesó un costo (R2-REF-06) —, las comisiones trabajaron a ciegas y
convergieron cuatro veces de forma independiente sobre los mismos hechos. No es complacencia:
es convergencia con árbitro previo.

---

## 2. Parches aprobados: dirección y clase

Dirección (documento, sección, qué cambiar), no redacción. «Doc» relativo a
`Guides/IA/IA-Model/`. Criterio general de verificación: cada parche se verifica con el comando
del ancla del hallazgo que lo funda (el grep/wc citado debe cambiar de salida en el sentido
corregido), y ningún parche toca salidas verificadas dentro de cercas de código.

| ID | Dirección | Clase | Documentos |
| --- | --- | --- | --- |
| PA-01 | M3 §6.1: asentar la exención — cifra histórica o arquitectónica con cita primaria fechada, exenta; cifra del parque vigente, sólo vía la tabla del 11 — con la condición de revisión de FUN-01 (si una cifra histórica se usa comparativamente contra el parque vigente, vuelve a la tabla) | corrección local | `Convenciones.md` |
| PA-02 | M1, pasada única sobre §5.1–§5.2, §6.1 y §7: (i) reescribir la regla 1 a forma exigible (cursiva en primera aparición y definiciones; en el resto, grafía única — EDI-01 b); (ii) consolidar los ≥14 términos candidatos de la lista de 015 con el dueño que cada observación propone, más las grafías «des-tokenizar» y «no-determinismo» en §6.1; (iii) cada fila del glosario copia la fuente normativa del documento dueño (criterio R2-REF-05; donde el dueño usa documentación oficial, ese tipo de fuente con fecha de consulta), lo que resuelve caché KV, ventana de contexto, inferencia/motor/tokens-por-segundo, recall «(en recuperación ANN)» y las filas de ENT-09, con Kaplan (2020) sumado a §7; (iv) alinear la línea OSAID con la formulación de 11 §1.2 | corrección local | `Marco-De-Referencia.md` |
| PA-03 | Doc 11 §1: sección normativa breve de «destilación» (~15 líneas, dimensionadas por su redactor), con cita primaria (Hinton et al. 2015, ya en M1 §7); condición comprobable: si este parche no entra en la fase de parches, la fila sale del glosario en PA-02 | corrección local | `11-Panorama-Y-Ecosistema-Abierto.md` |
| PA-04 | Unificar la autoría del Qwen3 Technical Report (arXiv:2505.09388) a la forma normada «Qwen Team (2025)» en Referencias y prosa de M1, 03, 06 y 08; en M3 §2.2, agregar la nota de SIS-08 («aunque el PDF liste autores nominales») | unificación transversal | `Marco-De-Referencia.md`, `03-Del-Modelo-Base-Al-Asistente.md`, `06-Ajuste-Fino-Y-Alineacion.md`, `08-Inferencia-Local.md`, `Convenciones.md` |
| PA-05 | Frontmatter en un solo movimiento (R2-REF-09): M3 §1.1 y §7 fijan forma única de `owner` (actor por ID) y semántica única de `traces` (prerrequisitos del grafo + siguiente; los estructurales M1–M3 sólo si M3 lo escribe), más los dos ejemplares de EDI-11; después una sola pasada por las 15 piezas que normaliza `owner` (M1 incluido: ACT-06), `traces` (quitar IAM-08 del doc 10 y ajustar 07/11), completa `entorno_validado` de 02 (motor+versión y etiquetas del lab 2, de verif-02) y de 08 (agregar `qwen3.5:4b`), y pasa a negrita el bloque didáctico de 02; verificación: `grep '^owner:'` devuelve una sola forma y 02/08 declaran motor y modelos | unificación transversal | `Convenciones.md`, `Marco-De-Referencia.md`, `IA-Model-Guide.md`, `Cohesion-Global.md`, `01-Representacion-Del-Lenguaje.md`, `02-Arquitectura-Transformer.md`, `03-Del-Modelo-Base-Al-Asistente.md`, `04-Datos-Y-Corpus.md`, `05-Preentrenamiento-Y-Leyes-De-Escala.md`, `06-Ajuste-Fino-Y-Alineacion.md`, `07-Evaluacion-Y-Metricas.md`, `08-Inferencia-Local.md`, `09-Bases-Vectoriales-Y-RAG.md`, `10-Multimodalidad-Y-Generacion-No-Textual.md`, `11-Panorama-Y-Ecosistema-Abierto.md` |
| PA-06 | Declarar al abrir el apartamiento de extensión en 03, 06 y 08 (motivo: salidas reales transcriptas; eje de partición nombrado), con la misma forma que ya usan 07 y 09; no se parte ninguna pieza en esta ronda | unificación transversal | `03-Del-Modelo-Base-Al-Asistente.md`, `06-Ajuste-Fino-Y-Alineacion.md`, `08-Inferencia-Local.md` |
| PA-07 | Doc 04: agregar los tres bloques «protocolo» a §3.1–§3.3 (opción a de ENT-03); corregir la `respuesta_esperada` de ev-03 a ≈4,85 (o la pregunta a Q4_0) y recorrer el lab 3 (determinista), verificando que el cruce de contaminación no cambie | corrección local | `04-Datos-Y-Corpus.md` |
| PA-08 | Doc 07: quitar «(completa el verificador)» de los dos `<summary>` (líneas 522 y 688); asentar la errata «Dá» como nota junto al bloque de §3.1, con condición de recorrida (criterio R2-REF-07), sin recorrer el lab | corrección local | `07-Evaluacion-Y-Metricas.md` |
| PA-09 | Doc 09: descargo textual en §3.1/§3.2 («estas similitudes valen para esta revisión del modelo; otra revisión puede reordenar un empate fino» — opción b de INF-01); reformular en §1 «cuesta memoria en proporción creciente» a «en proporción al largo del contexto (caché KV, 08)» (INF-06) | corrección local | `09-Bases-Vectoriales-Y-RAG.md` |
| PA-10 | Doc 11: nota al pie en §1.6 que concilie los parámetros de Gemma 4 E4B (total nominal del editor vs lo que reporta el motor — INF-05); en §1.1, cita de editor con fecha de consulta para la frase sobre GPT-5.1 o reformulación sin nombre de producto (FUN-08) | corrección local | `11-Panorama-Y-Ecosistema-Abierto.md` |
| PA-11 | M2 §5: anotar en la fila de 6.B la condición del tramo final («servir en el banco: condicionado a decisión de ACT-03»), con la misma forma que la salvedad ya anotada para los embeddings del 09 | corrección local | `Cohesion-Global.md` |
| PA-12 | M3: una línea en §4 con el criterio de R2-REF-07 (defecto de contenido se corrige y se recorre; defecto de forma se asienta como errata con condición de recorrida); junto a los disparadores de §6.2, la compuerta de promoción de R2-REF-10 (todo diagrama mermaid compila antes de promover o tras editarse) | corrección local | `Convenciones.md` |

**Deuda declarada** (lo que conviene diferir se declara con motivo, no se parchea a medias; no se
aplica en esta fase):

| ID | Qué se difiere | Motivo | Evento de cierre |
| --- | --- | --- | --- |
| PD-01 | Tramo final del lab 6.B («servido en el banco», pasos 5–6) y la promoción de `status`/`confidence` de IAM-06; incluye el asiento de trazabilidad QLoRA→LoRA (ENT-10: sustitución fundada en el default de la fila 1 del lote) | Falta la llave de ACT-03 (crear `taller-qwen`/`taller-qwen-base`, ~1 GB, y borrarlos): es obstáculo con default declarado, no detención (R2-REF-08); la presidencia cursa la pregunta de una línea por canal directo antes del cierre | Respuesta de ACT-03 asentada: con sí, el verificador corre el paso 6, borra y 06 promueve; sin respuesta, rige el default declarado y la salvedad de PA-11 queda vigente |
| PD-02 | Fijación de la revisión (commit) del modelo de embeddings de los labs de 09, registrada en los tres bloques protocolo | Escribir un commit no observado violaría «no inventar información» (R2-REF-06); el dato debe salir de la caché de HF del puesto del verificador o de una recorrida de los tres labs en CPU | Constancia del verificador de 09 con el commit observado (o la recorrida), incorporada a `despacho/` |

---

## 3. Preguntas que sobreviven para el lote del PO

El lote del folio 011 §5 ya se presentó al PO en la fase anterior (folio 012 §3) y no se
re-emite. De las dudas de esta fase: la de ACT-03 (tres veces re-elevada) no va al lote — es
obstáculo por canal directo de la presidencia (R2-REF-08, PD-01); la de [redactor-11] quedó
resuelta como tarea de ACT-06. Sobrevive una sola:

| # | Pregunta | SI NO RESPONDÉS |
| --- | --- | --- |
| 1 | [verificador-02, heredada] ¿Autorizás instalar el cliente `ollama` (versión fija, declarada antes de instalar) en el puesto de verificación, para que el paso 1 del lab de fichas del doc 02 tenga salida real de `ollama show` en lugar de quedar ilustrativo? (regla de la casa: consultar antes de instalar) | No se instala nada; el paso 1 queda «ilustrativo» declarado como está, la verificación sigue por API (`/api/show`) y nada queda bloqueado — prioridad P3 |

---

## 4. Recomendación de cierre

1. **Con los parches PA-01…PA-12 aplicados y verificados, la guía cumple la regla de cierre de la
   clase y el pedido**: tras la nivelación del refutador no queda ningún P0 ni P1 vigente; todo
   P2 tiene parche aprobado o deuda declarada con evento de cierre abrible (PD-01, PD-02); las
   cuatro preguntas del caso siguen respondidas por separado (folio 011 §2–§4) y la única
   divergencia contra el alcance aprobado («servido en el banco») queda asentada como deuda con
   evento, no como silencio.
2. **Ninguna pieza promueve a `status: vigente` antes de**: aplicar PA-02 (consolidación del
   glosario — compuerta que tres comisiones pusieron), verificar los parches con sus comandos de
   ancla, y resolver o asentar PD-01 para IAM-06 (que conserva `confidence: media` mientras
   tanto); la compilación mermaid de PA-12 rige como compuerta desde ya (la corrida de R2-REF-10
   la deja cumplida para este estado).
3. **Rótulo**: con una ronda de estructura y una de revisión, y esta ronda con 54 hallazgos
   procedentes, no hay dos rondas seguidas limpias: si la presidencia cierra tras la fase de
   parches, el cierre es **por decisión** — no es una falta — con lo abierto enumerado: PD-01,
   PD-02, la fila 1 de §3, la habilitación de `/api/embed` del banco (ya en el lote del folio
   012 §2), las primarias pendientes de 11 §1.5 (tarea de ACT-06) y las condiciones de revisión
   de PA-01, PA-02 y PA-03.
4. **Al cuerpo de parches**: sólo se aplica lo votado PROCEDE con clase de corrección local o
   unificación transversal (PA-01…PA-12); PD-01 y PD-02 no se parchean a medias; los tres
   ARCHIVA no generan acción.

Sigue: incorporación de este folio como actuación y despacho del cuerpo de parches con
PA-01…PA-12 · presidencia de la mesa · Cierra con: constancia de parches aplicados y verificados
en `despacho/`.
