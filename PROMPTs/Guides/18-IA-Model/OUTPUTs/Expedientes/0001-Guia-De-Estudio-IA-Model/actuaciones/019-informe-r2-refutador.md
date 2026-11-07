# Informe del refutador — ronda 2 (revisión del borrador completo)

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-07 |
| Autor | refutador (ronda 2) |
| Corrige | — |

Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas: cabecera y §0 (líneas 1–111, con el Mapa de
carga, fila «Sos el refutador»); del resto del cuerpo rige lo condensado en el pliego operativo
(evidencia/002). Además cargado entero en lo que gobierna este acto: Cadena-De-Consecuencias 2.0
(§2 corrida antes de cada recomendación entre opciones; §3 para distinguir obstáculo de
detención). Excepcion-A-Un-Conocimiento 2.1 no se cargó: no hay ficha que juzgar — verificado por
comando: `ls despacho/ | grep -i ficha` → sin salida (rc=1), y los cinco informes r2 declaran no
proponer excepciones. El punto (d) de mi carta (evidencia/017) queda sin materia.

Insumos: los cinco informes r2 (`despacho/r2-*.md`), únicos que este rol lee del panel; las 15
piezas del borrador en `<worktree-guia>/Guides/IA/IA-Model/` (lectura dirigida por los hallazgos,
con re-corrida propia de las anclas que ataco); folios 001, 002 y 011; pliego operativo. Lectura
P0–P3: la del folio 002. Clase de objeto: corpus documental existente. Comandos corridos el
2026-11-07 con cwd `<worktree-guia>/Guides/IA/IA-Model/` salvo indicación. Tope: 12 hallazgos;
emito 10. Sin BLOQUEO: ningún paso prescripto de mi revisión falló.

Prefijo de familia de este informe: `R2-REF-`.

---

## 1. Consolidación previa: 39 filas de comisión son ~17 hechos

Las cinco comisiones trabajaron a ciegas y convergieron: de sus 39 hallazgos, 22 son copias de
hechos que otra comisión también trae. El jurado debe votar hechos consolidados, no filas. Mapa
(el resto de las filas es único y va directo a veredicto):

| Hecho | Filas que lo traen | Divergencia a resolver |
| --- | --- | --- |
| «destilación» con dueño vacío | FUN-02, ENT-01, SIS-01, EDI-04 (parcial) | **Dirección opuesta** → R2-REF-01 |
| Exención de cifras históricas en M3 §6.1 | FUN-01, SIS-04, EDI-07 | **Nivel** (P1 vs P2) → R2-REF-02 |
| Forma canónica del glosario incumplida | EDI-01, ENT-06 | **Nivel y parche** → R2-REF-03 |
| Fuentes del glosario que no fundan | FUN-03, INF-03, SIS-09, EDI-08 | **Anclaje y fuente destino** → R2-REF-05 |
| Qwen3 TR con dos autorías | FUN-04, ENT-02, SIS-08, EDI-03 | Sólo nivel (P2/P2/P3/P2); dirección única |
| Glosario sin consolidar (≥14 términos) | FUN-07, ENT-05, SIS-06, EDI-04 | Ancla de ENT-05 → R2-REF-04 |
| «entrenar» bajo el alcance del folio 011 §4 | EDI-02, SIS-05, INF-04, ENT-10 | **Nivel** (P1…P3) y vía → R2-REF-08 |
| `entorno_validado` incompleto (02, 08) | FUN-06, INF-02, EDI-06 | Ninguna; una sola corrección |
| Apartamiento de extensión sin declarar (03/06/08) | SIS-02, EDI-05 | Ninguna |
| `owner` / `traces` sin criterio único | ENT-07, SIS-03, SIS-07, EDI-09, EDI-10 | **Unidad de aplicación** → R2-REF-09 |

---

## 2. Hallazgos

### R2-REF-01 · P2 · E1+E2 · interpretativo — «destilación»: cuatro informes, una dirección contradictoria y un sustento sin ancla

- **Ancla E2**: ENT-01 recomienda «(a) quitar la entrada … la que cumple la regla 3 tal como está
  escrita, con el estado actual del corpus (cero usos), es (a)»; FUN-02, SIS-01 y EDI-04
  recomiendan lo contrario (definir en 11 §1, ~15 líneas). Pero la regla 3 (M1 §5.1) no manda
  quitar: manda **decidir** («señala o un hueco del temario o un descarte, y se decide, no se
  acumula») — leerla como mandato de remoción es agregarle lo que no dice.
- **Ancla E1**: el sustento de FUN-02 («la destilación aparece en el panorama como práctica de
  publicación — variantes “distill” del ecosistema») no está en el corpus:
  `grep -ric 'distill' *.md | grep -v ':0'` → sólo `Marco-De-Referencia.md:2`; en el doc 11,
  cero. Si es afirmación sobre el ecosistema real, es de industria y va con fuente (mi carta,
  norma del folio 002); como está, es C y no funda.
- **Cadena §2 (dos opciones)**: **quitar** cae en M1 (una línea, reversible) pero pierde un
  «término asociado» que el pedido nombra como clase y que el informe 008 de la ronda 1 listó en
  el núcleo de panorama; **definir en 11** cae en el doc 11 (~15 líneas medidas por su propio
  redactor, aditivo, reversible, y de paso ancla las variantes «-distill» que el parque abierto
  real publica — eso sí, con su cita al incorporarse). Ambas baratas y reversibles; la segunda
  conserva cobertura que la primera paga.
- **Dirección**: definir en 11 §1, con cita primaria (Hinton et al. 2015 ya está en M1 §7).
  Condición de revisión comprobable: si el parche de 11 no entra en esta fase de parches, la fila
  sale del glosario en el mismo barrido de consolidación (no queda una tercera ronda apuntando al
  vacío).

### R2-REF-02 · P2 · E2 · interpretativo — El P1 de FUN-01 no resiste la definición del pliego: la práctica no divergió, divergió de la letra

- **Ancla E2**: FUN-01 funda su P1 en «dos redactores ya aplicaron la norma de dos maneras — la
  definición de P1 del pliego». Pero su propia evidencia muestra lo contrario: 02 §1.6 y el doc
  05 hicieron **lo mismo** (cifra histórica con cita primaria de paper); ninguna pieza reencaminó
  esas cifras vía la tabla del 11. La divergencia es entre la letra de M3 §6.1 (re-leída:
  «no citan cifras ni rankings de modelos concretos salvo vía la tabla», sin excepción) y una
  práctica **uniforme** — eso es P2 del pliego («pérdida acotada … sin romper el objetivo»), como
  lo nivelaron SIS-04 y EDI-07 por separado.
- **Impacto de no unificar**: un P1 detiene el avance del objeto (pliego §2); dejarlo P1 bloquea
  la promoción del corpus por un defecto cuya corrección es una frase aditiva en M3.
- **Dirección**: nivel único P2; dirección única la convergente de los tres informes (exención
  escrita en M3 §6.1: cifra histórica o arquitectónica con cita primaria fechada, exenta; cifra
  del parque vigente, sólo vía la tabla del 11), con la condición de revisión que FUN-01 ya
  redactó. Cae en M3, una pieza, reversible: la unidad de aplicación se respeta.

### R2-REF-03 · P2 · E2 · interpretativo — Glosario tipográfico: dos parches distintos sobre la misma regla dejarían la norma mitad nueva y mitad vieja

- **Ancla E2**: ENT-06 propone «cambiar la forma canónica del glosario a “dataset” sin cursiva
  (una línea en M1)»; EDI-01 propone reescribir la regla 1 entera («cursiva obligatoria sólo en
  primera aparición y en definiciones»). Si el jurado vota las dos filas como vienen, M1 §5.1–§5.2
  recibe dos ediciones de alcance distinto sobre el mismo punto en la misma fase: una fila
  retocada término a término **y** una regla general que la vuelve redundante — el documento
  normativo queda mitad bajo un criterio y mitad bajo otro, el defecto que mi carta manda cazar.
- **Nivel**: EDI-01 lo trae P1, ENT-06 P3, sobre el mismo hecho de fondo (la alternancia en
  prosa). El P1 exige interpretación divergente entre aplicadores o retrabajo del conjunto: la
  práctica actual es uniforme en su desvío (plano domina en todos los dueños) y la corrección
  elegida cae en un solo archivo — P2.
- **Cadena §2**: el barrido tipográfico (opción (a) de EDI-01) cae en los once temáticos con
  cientos de ediciones sobre piezas con salidas verificadas dentro de cercas — es la corrección
  peor que el defecto. La opción (b) de EDI-01 cae en M1, subsume ENT-06 (dataset queda legal sin
  tocar su fila) y es reversible (endurecer después es aditivo).
- **Dirección**: un solo parche — EDI-01 (b) — y ENT-06 se archiva como subsumido, no se vota
  aparte. Condición de revisión: la que EDI-01 ya declaró.

### R2-REF-04 · P3 · E1 · enumerable — El ancla de ENT-05 está mal construida: el comando citado no puede producir la salida que reporta

- **Ancla E1 (re-corrida propia)**:
  `grep -n 'safetensors\|JSONL\|datasheet\|prompt de sistema' Marco-De-Referencia.md` → **sin
  salida (rc=1)**. ENT-05 reporta para ese mismo comando «sólo una mención incidental de
  “procedencia” en ACT-05» — imposible: «procedencia» no está en el patrón (aparece con otro
  comando: `grep -c 'procedencia' Marco-De-Referencia.md` → 1). La salida transcripta no es la
  del comando transcripto.
- **Impacto**: la conclusión de ENT-05 sobrevive — la traen con ancla sana FUN-07, SIS-06 y
  EDI-04 —, pero una salida que no corresponde a su comando no funda por sí sola (pliego §3.4,
  regla 2: la afirmación de no-colisión vale por el comando **con su salida**). En un expediente
  verbatim, la fila queda citándose a futuro con un E1 defectuoso.
- **Dirección**: ENT-05 se consolida bajo EDI-04/SIS-06 (cuyas anclas re-verifiqué y resisten) y
  su ancla no se hereda; costo cero.

### R2-REF-05 · P2 · E2 · interpretativo — Fuentes del glosario: tres de los cuatro informes afirman lo que una fuente **no** contiene sin haberla abierto; el hallazgo se re-ancla en la forma de INF-03

- **Ancla E2**: FUN-03 («el Qwen3 Technical Report no es fuente que defina términos genéricos de
  servicio»), SIS-09 y EDI-08 («usa esos términos pero no los define») afirman ausencias dentro
  de un paper. Mi carta: una cita que muestra dónde está una palabra no muestra dónde no está —
  y ninguno de los tres declara haber abierto el TR para ese negativo; sin eso, esa parte es C.
  INF-03 lo escribió con el anclaje correcto y lo declaró: «No abrí el Qwen3 TR … el hallazgo se
  funda en la divergencia citable entre glosario y dueño». Esa divergencia es E2 pura (M1 §5.2
  líneas 183–192 contra 08 líneas 68–70/176–179/194–196) y alcanza para fundar la corrección.
- **Divergencia de parche**: los cuatro proponen fuentes de reemplazo distintas para «caché KV»
  (Shazeer 2019 — FUN; Vaswani + Pope et al. 2023 — INF; Pope et al. 2022, arXiv:2211.05102 —
  SIS; «la que ya está en el cuerpo» — EDI). Elegir una cuarta fuente en el veredicto repetiría
  el defecto (glosario con fuente propia distinta de la del dueño).
- **Dirección**: el hallazgo consolidado se vota con el ancla de INF-03; el criterio de parche es
  mecánico, no bibliográfico: **cada fila del glosario copia la fuente normativa del documento
  dueño** (regla 2 de M1 §5.1: el glosario reenvía, no re-funda), y donde el dueño usa
  documentación oficial, la fila lleva ese tipo de fuente con fecha de consulta (M3 §2.2 ya lo
  tiene). Cae en M1, una pieza, reversible.

### R2-REF-06 · P2 · E2 · interpretativo — INF-01 subestima el costo de su propia corrección: fijar la revisión del modelo de embeddings no es «una línea más de código»

- **Ancla E2**: INF-01 pesa la opción como «fijar la revisión cae en el lector — una línea más de
  código — … registrándola en los tres bloques protocolo». Pero los protocolos de las corridas
  verificadas de 09 **no registraron** revisión ni huella del modelo (lo dice el propio INF-01), y
  la preparación común de 09 (líneas 335–343) fija bibliotecas, no pesos. Un
  `revision="<commit>"` escrito hoy sólo es verdadero si (i) el commit se recupera del entorno de
  la corrida verificada (la caché de HF del puesto del verificador, si persiste), o (ii) se fija
  el commit vigente y **se recorren los tres laboratorios** para re-verificar que las salidas
  transcriptas —incluido el empate 0,421/0,421 que el texto explota didácticamente— valen para
  esa revisión. Escribir un commit sin (i) ni (ii) viola la restricción dura «no inventar
  información»: sería un dato de reproducibilidad que nadie observó.
- **Cadena §2**: (i) cae en el verificador (minutos, si la caché persiste; se asienta cuál
  commit era); (ii) cae en el banco de trabajo del verificador (las corridas de 09 son locales en
  CPU: acotado, pero no «una línea»). Sin medio para saber si la caché persiste desde acá, el
  paso 2 de (i) queda **sin medir** y lo asiento: lo mediría el verificador con
  `ls` de su caché de HF; a quien despacha el parche le toca pedirlo.
- **Dirección**: la corrección de INF-01 procede, pero como tarea de verificación con dueño (el
  verificador de 09), no como parche de texto; el descargo textual (su opción b) sí es parche de
  texto inmediato y puede entrar ya.

### R2-REF-07 · P3 · E2 · interpretativo — Dos varas para recorrer una corrida verificada (ENT-04 vs ENT-11), ambas bien decididas, ninguna asentada

- **Ancla E2**: ENT-04 manda corregir la `respuesta_esperada` de ev-03 y «recorrer el laboratorio
  3 — determinista, segundos»; ENT-11 manda **no** recorrer el lab 07-B por la errata «Dá»
  («recorrer 46+ minutos … por una tilde pesa más que lo que compra»). Verifiqué ambas medidas de
  costo y las dos son correctas (leí `solapamiento.py` de 04 §3.3: puro CPU, sin banco; la cifra
  4,5 vs 4,85/«mezcla Q4_K/Q6_K» está en 04:391 contra 08:159 y 08:548 tal como ENT-04 la cita).
  Lo que falta es el criterio que las reconcilia, que ninguna pieza normativa asienta: **defecto
  de contenido se corrige y se recorre; defecto de forma se asienta como errata con condición de
  recorrida**.
- **Impacto**: sin asentarlo, la próxima errata o cifra divergente re-litiga la decisión desde
  cero, con el riesgo de que alguien «corrija» un jsonl transcripto sin recorrer y la salida
  publicada deje de ser real.
- **Dirección**: una línea en M3 §4 (o en la resolución de cierre) con ese criterio; ambos
  hallazgos de ENT proceden tal como vienen.

### R2-REF-08 · P2 · E2 · enumerable — «Entrenar» bajo el alcance aprobado: cuatro niveles para un solo hecho, y una pregunta que ya se formuló tres veces sin cursarse una

- **Ancla E2**: el mismo hecho (folio 011 §4 «servido en el banco» vs 06 `entorno_validado:
  parcial` con pasos 5–6 ilustrativos declarados) viene como P1 (EDI-02), P2 (SIS-05), P3
  (INF-04) y P3 (ENT-10). Refuto el P1: la definición del pliego pide que el objeto no pueda
  avanzar — acá la divergencia está declarada en el propio documento, nada no verificado se
  afirma (lo reconoce EDI-02 al negar el P0), y lo único retenido es la **promoción** de 06 a
  `vigente`, que es exactamente el default ya declarado. Pérdida acotada con evento de cierre:
  P2, la lectura de SIS-05.
- **Y es un obstáculo, no una detención** (Cadena §3): la decisión está tomada y fundada (el
  default de la duda de [redactor-06]: crear `taller-qwen`/`taller-qwen-base`, correr el paso 6,
  borrar); lo que falta es la llave de ACT-03. Tres comisiones la re-elevaron como duda (ENT §4,
  INF §4, EDI §4) — viajando por tercera vez en lugar de cursarse: «archivar un obstáculo como
  escalada entierra … algo que se resolvía preguntando».
- **Dirección**: un solo hecho P2 en el veredicto; la presidencia cursa la pregunta de una línea
  a ACT-03 **en el momento** y antes del cierre; con sí → el verificador corre y borra, 06
  promueve; sin respuesta → rige el default, M2 §5 anota la salvedad en la fila de 6.B (la forma
  de INF-04) y la resolución asienta la deuda con su evento de cierre (la forma de ENT-10). Las
  tres direcciones parciales son la misma corrección en tres capas; se aplican juntas o la
  cohesión queda a medias.

### R2-REF-09 · P3 · E2 · enumerable — Frontmatter en tres olas de parche: la unidad de aplicación es el documento, no el campo

- **Ancla E2**: sobre los mismos 15 frontmatters caen, como filas separadas: `owner` (EDI-09,
  SIS-07, ENT-07), `traces` (SIS-03, EDI-10, ENT-07), `entorno_validado` (FUN-06, INF-02,
  EDI-06), más los ejemplares de M3 que EDI-11 retoca. Votadas y aplicadas como vienen, son
  hasta tres pasadas sucesivas de edición sobre los mismos archivos, con M3 §1.1 retocado dos
  veces — entre pasada y pasada, el corpus queda con frontmatters mitad normalizados, el estado
  que mi carta manda evitar.
- **Dirección**: un solo parche normativo en M3 §1.1 (forma única de `owner`, semántica única de
  `traces`, y los dos ejemplares de EDI-11), y **una sola pasada** por documento que normalice
  los tres campos juntos (incluyendo completar `entorno_validado` de 02 y 08 con los datos de
  verif-02/verif-08). Mismo contenido que las nueve filas; la diferencia es que se vota como un
  parche con un criterio de verificación («`grep '^owner:'` devuelve una sola forma; `traces`
  cumple la semántica fijada; 02 y 08 declaran motor+versión y sus dos modelos»).

### R2-REF-10 · P3 · E1 · enumerable — Lo que las cinco comisiones pasaron por alto contra el pedido literal: nadie validó que los «gráficos mermaid» compilen

- **Ancla**: el pedido (folio 001, Reglas) nombra «gráficos mermaid» como requisito literal. Las
  cinco comisiones verificaron enlaces, marcadores, fugas y citas; ninguna —ni ninguna constancia
  verif-01…verif-11, que mencionan mermaid sólo como contenido— compiló un diagrama. Un bloque
  mermaid inválido se publica como texto de error para el lector: habría sido un defecto del
  entregable literal sin red.
- **E1 (corrida propia, 2026-11-07)**: rendericé los diagramas de las 15 piezas con la
  herramienta de medios de la casa (mermaid-cli 11.4.2 en contenedor efímero):
  **13 diagramas en 15 archivos; 13/13 compilan y renderizan sin «Unsupported markdown»**
  (01×1, 02×1, 03×1, 04×1, 05×1, 06×2, 07×1, 08×1, 09×1, 10×1, 11×1, M2×1; M0, M1 y M3 no llevan
  — conforme al «cuando sea necesario» del pedido).
- **Impacto**: hoy, ninguno — el hueco era de verificación, no del producto, y esta corrida lo
  cierra para este estado del corpus.
- **Dirección**: asentar la compilación de mermaid como compuerta de promoción (una línea en el
  plan de cierre o junto a los disparadores de M3 §6.2): un diagrama editado en una revisión
  futura vuelve a quedar sin red si no se norma.

---

## 3. Dictamen sobre el resto (lo que resiste tal como viene)

Sin divergencia que arbitrar y con ancla que re-verifiqué o que es citable por sí misma, proceden
tal como vienen y sólo consolidan copias: Qwen3 TR con dos autorías (votar una fila; dirección
única: la forma normada de M3 §2.2, con la nota de SIS-08 — «aunque el PDF liste autores» — que
evita la próxima divergencia de buena fe); apartamientos de extensión sin declarar en 03/06/08
(SIS-02/EDI-05: declarar, no partir — la cadena de SIS-02 está bien corrida y la condición de
revisión del folio 011 §2 queda intacta); FUN-05 (OSAID en M1: re-leí M1 línea 200 y la cita es
fiel; nótese que el ítem 1 de «está bien» de EDI — «la OSAID … con las exigencias sobre pesos,
código y datos que M1 §5.2 … le atribuye» — avala de pasada la línea defectuosa que FUN-05
corrige: vale el hallazgo específico contra el aval genérico); consolidación del glosario
(FUN-07/SIS-06/EDI-04, con R2-REF-04 sobre el ancla de ENT-05); R2-ENT-03 (bloques protocolo de
04: la opción (a) iguala a la pieza que cumple; (b) sólo por decisión expresa); R2-ENT-04 y
R2-ENT-11 con el criterio de R2-REF-07; R2-ENT-08, R2-ENT-09, R2-ENT-12 (su dirección de aceptar
la salida real es la lectura correcta del costo); R2-INF-05 y R2-INF-06 (la nota didáctica de
INF-05 es ganancia neta); R2-FUN-08; R2-EDI-11 y R2-EDI-12 dentro de las pasadas únicas de
R2-REF-09 y de la consolidación de glosario.

## 4. Lo que revisé y está bien (tres ítems)

1. **La cobertura del panel cierra sin hueco y sin complacencia**: entre las cinco comisiones,
   las 15 piezas tienen lectura a fondo declarada al menos una vez (01–03/10–11/M1 por
   fundamentos-panorama; 04–07/M1–M3 por entrenamiento-métricas; 03/08/09/11/M0–M3 por
   inferencia-rag; las 15 por sistemas-ia y edición-publicación), cada informe declara su alcance
   no mirado, y toda observación de evidencia/015 que cae en alguna competencia tiene disposición
   explícita (confirmada, elevada, descartada con motivo o superada) — ninguna quedó sin dueño.
2. **Las anclas verbatim muestreadas resisten**: re-leí en el corpus M1 líneas 179/187/200, M3
   §2.2 (línea de «Qwen Team (2025)») y §6.1, 04 líneas 389–391, 08 líneas 159/548, la
   preparación común de 09 (335–343) y el script del lab 3 de 04 — las diez citas muestreadas de
   los informes son fieles al archivo y línea que declaran, y las medidas de costo de ENT-04,
   ENT-11 y SIS-02 son correctas en el lugar donde caen. La única salida que no corresponde a su
   comando es la de ENT-05 (R2-REF-04).
3. **El trato de lo declarado-no-silenciado es uniforme y correcto en las cinco comisiones**:
   nadie pidió rehacer lo que el corpus declara honestamente (el tramo ilustrativo de 6.B, los
   apartamientos declarados de 07/09, las primarias pendientes de 11 §1.5 con dueño ACT-06), y
   las cinco distinguieron defecto de deuda declarada — exactamente la disciplina que la clase de
   objeto pide.

## 5. Dudas para quien pidió

Sin dudas nuevas. La única abierta del panel (ACT-03 / lab 6.B) no es una detención sino un
obstáculo con default ya declarado: va por canal directo de la presidencia, no al lote
(R2-REF-08); las demás filas del lote del folio 012 no se tocan.

Sigue: consolidación de la ronda 2 y veredicto del jurado sobre los hechos consolidados de §1 ·
presidencia de la mesa · Cierra con: folio `informe` del jurado de la ronda 2.
