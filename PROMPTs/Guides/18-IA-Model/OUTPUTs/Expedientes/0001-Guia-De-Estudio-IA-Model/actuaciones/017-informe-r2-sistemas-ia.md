# Informe ronda 2 — Comisión de arquitectura de sistemas IA y análisis de sistemas (sistemas-ia)

Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas: cabecera y §0 (líneas 1–111, con el Mapa de
carga), la carta (evidencia 016, con la competencia de la carta de ronda 1, evidencia 007), §2.2,
§3.2, §3.3 y §4. Además cargado: Cadena-De-Consecuencias 2.0 §2 (corrida antes de cada
recomendación entre opciones de este informe). Excepcion-A-Un-Conocimiento no se cargó: esta
comisión no propone apartarse de ninguna convención que rige.

Competencia (carta de ronda 1): análisis de sistemas, arquitectura de soluciones con modelos IA,
descomposición en núcleos conceptuales y documento de cohesión global. No-competencia: contenido
interno de cada tema, estilo editorial, veredictos de evidencia — lo que cayó ahí va como señal al
final, no como hallazgo.

Objeto revisado: las 15 piezas de `<worktree-guia>/Guides/IA/IA-Model/` (M0 `IA-Model-Guide.md`,
M1 `Marco-De-Referencia.md`, M2 `Cohesion-Global.md`, M3 `Convenciones.md`, temáticos 01–11),
contrastadas contra el folio 001 (pedido), el folio 002 (contrato), el folio 011 (alcance
aprobado: §2 temario y dependencias, §3 marco, §4 estructura y mapa de laboratorios) y las
observaciones compiladas de evidencia/015 (con su adenda). Lectura P0–P3: la del folio 002.
Ningún paso prescripto falló: sin BLOQUEO.

Método mecánico de esta comisión (comandos corridos el 2026-11-07, cwd
`<worktree-guia>/Guides/IA/IA-Model/`):

- Enlaces relativos: script Python que extrae todo `](ruta)` fuera de cercas de código y verifica
  existencia → **0 enlaces rotos en las 15 piezas**.
- Marcadores pendientes: `grep -c 'VERIFICAR' *.md | grep -v ':0'` → sin salida (0 marcadores).
- Fugas de host: `grep -nE '/vm/|/home/|192\.168\.|10\.[0-9]+\.|100\.[0-9]+\.' *.md` → sin salida.
- Extensión: `wc -l *.md` → 01: 568 · 02: 643 · 03: 740 · 04: 596 · 05: 624 · 06: 774 · 07: 867 ·
  08: 754 · 09: 870 · 10: 607 · 11: 586.
- Envolturas y frontmatter: lectura de las 11 cabeceras (doc_id, owner, traces,
  entorno_validado, «Antes de leer», «Anterior/Siguiente»).

## Hallazgos

### R2-SIS-01 · P2 · E1+E2 · enumerable — «destilación» tiene dueño (doc 11) que no la trata: el glosario viola su propia regla de corte

- **Ancla E1**: `grep -il 'destilaci' *.md` → sólo `Marco-De-Referencia.md`; `grep -ni
  'destilaci' 11-Panorama-Y-Ecosistema-Abierto.md` → sin salida (rc=1).
- **Ancla E2**: M1 §5.2 línea 179 (fila «destilación … Dueño: 11»); M1 §5.1 regla 2 («las
  definiciones normativas extensas viven una sola vez, en el documento dueño») y regla 3
  («entra al glosario el término que algún núcleo usa; un término sin núcleo que lo use señala o
  un hueco del temario o un descarte, y se decide, no se acumula», decisión FP-07).
- **Qué falla**: ningún núcleo usa ni define el término; la entrada apunta a un dueño vacío. El
  lector que consulta el glosario y sigue el reenvío no encuentra nada.
- **Observaciones de 015**: confirma [M1-marco] (hueco por la regla FP-07) y [redactor-11] (la
  sección faltante es un agregado de ~15 líneas en 11 §1, fuera del alcance que ese redactor
  recibió).
- **Impacto**: defecto de cohesión puntual; mancha la regla «cada contenido con un solo dueño»
  que M2 §7 declara invariante.
- **Dirección**: decidir, como la regla 3 manda — o el doc 11 incorpora la definición normativa
  (~15 líneas, aditivo, ya dimensionado) o la fila sale del glosario. Cadena §2: la primera cae
  en el doc 11 (costo mínimo, reversible) y conserva un término canónico del dominio que el
  informe 008 de la ronda 1 listó en el núcleo de panorama; la segunda pierde esa entrada. Se
  recomienda incorporarla.

### R2-SIS-02 · P2 · E1+E2 · enumerable — Tres temáticos superan la extensión orientativa sin el apartamiento declarado que M3 exige

- **Ancla E1**: `wc -l` → 03: 740 · 06: 774 · 08: 754 (orientativo 350–700, M3 §5);
  `grep -ni 'apartamiento' 03-… 06-… 08-…` → sin salida; en 07 (867) y 09 (870) el apartamiento
  sí está declarado al abrir (09 línea 29; 07 en su envoltura).
- **Ancla E2**: M3 líneas 20–21: «Cuando un documento temático necesite apartarse de una
  convención, lo declara al abrir, con motivo: un apartamiento silencioso se trata como defecto
  editorial».
- **Qué falla**: 03, 06 y 08 están en el mismo caso que 07 y 09 (exceso que viene de salidas de
  laboratorio transcriptas) pero sin la declaración; el 06 además creció de 726 a 774 líneas en
  la reparación de la tubería y la observación original ([redactor-06], «3% sobre el tope») quedó
  desactualizada.
- **Observaciones de 015**: confirma [editor-03] (740 del 03), actualiza [redactor-06]; para 07 y
  09 confirma [redactor-07], [editor-07], [redactor-09] y [editor-09]: sus apartamientos están
  declarados y conformes.
- **Impacto**: dos reglas distintas conviviendo para el mismo hecho; la condición de revisión del
  veredicto (folio 011 §2: «si en la ronda 2 un documento supera el patrón … se parte por el eje
  que el grafo declara») queda sin tratamiento uniforme.
- **Dirección** (Cadena §2 corrida sobre partir ahora vs. declarar y aceptar): declarar el
  apartamiento con motivo y eje de partición en 03, 06 y 08 y aceptar los cinco excesos en esta
  ronda. Dónde cae cada opción: partir cae en toda la tubería (nueva pieza, M2 §2/§5, M0 §2–§3,
  traces y enlaces de los hermanos); declarar cae en tres envolturas (tres líneas). Qué pierde la
  alternativa: declarar pospone la homogeneidad del patrón; partir pierde la estabilidad del
  temario aprobado de 15 piezas. Reversibilidad: declarar es reversible y el propio M2 §7 fija
  «ante la duda, se publica entero y se parte después». Condición de revisión comprobable: si en
  el próximo ciclo editorial alguno vuelve a crecer, se parte por el eje declarado.

### R2-SIS-03 · P2 · E2 · enumerable — `traces` con tres semánticas conviviendo; M0 lo declara «interfaz de carga» para agentes

- **Ancla E2**: M3 §7 línea 287 (plantilla: `traces: [<doc_id de los prerrequisitos y del
  siguiente>]`) contra M3 §1.1 línea 54 (`traces: [doc_id relacionados]`); y los frontmatters:
  02 `[IAM-01, IAM-03]`, 04 `[IAM-03, IAM-05]`, 05, 06 — mínimo de plantilla; 01, 03, 07, 08, 09
  agregan IAM-M1/M2/M3; 10 agrega `IAM-08` (que no es ni prerrequisito ni siguiente ni anterior
  suyo); 11 agrega `IAM-M0`. M0 §5 (líneas 155–157) vende `traces` como «la interfaz de carga»
  del agente y «el grafo … dice qué cargar antes de qué».
- **Qué falla**: tres criterios en el mismo campo (mínimo de plantilla; mínimo + estructurales;
  entradas sueltas sin criterio como IAM-08 en el doc 10). Para el lector humano es invisible;
  para el agente que carga por `traces` produce grafos de carga distintos según el documento.
- **Observaciones de 015**: confirma [editor-04] (su lectura «prerrequisito+siguiente está bien»
  es la de la plantilla M3 §7, pero la unificación que pide sigue pendiente) y [M0-raiz] (doc 11
  con IAM-M0: coherente con M0, pero fuera de la semántica declarada).
- **Impacto**: acotado hoy; crece con cada consumidor automático del frontmatter (la casa declara
  doble audiencia).
- **Dirección**: fijar una sola semántica en M3 (§1.1 y §7 diciendo lo mismo) y barrer los once
  frontmatters en un solo cambio. Cadena §2: la semántica de la plantilla (prerrequisitos +
  siguiente) es la que el grafo de M2 ya garantiza derivable; permitir además los estructurales
  M1–M3 es aditivo si se escribe; lo que no puede quedar es la entrada sin criterio (IAM-08 en el
  10). Elección técnica dentro de las restricciones: la mesa la resuelve sola.

### R2-SIS-04 · P2 · E2 · interpretativo — M3 §6.1 prohíbe lo que 02 y 05 hacen: falta la exención de cifra histórica anclada a paper

- **Ancla E2**: M3 §6.1 líneas 243–245: «Los documentos estables **no citan cifras ni rankings de
  modelos concretos** salvo vía la tabla de referencia del documento 11»; contra 02 línea 195
  (Mixtral 8×7B: parámetros totales/activos, con cita Jiang et al. 2024, línea 631) y 05 líneas
  154–162 (GPT-3 175B/300B tokens, Chinchilla 70B/1,4T, LLaMA, con autor-año).
- **Qué falla**: la letra de M3 no distingue cifra del parque vigente (volátil, el riesgo que
  ARQIA-02/FP-05 atacaron) de cifra histórica fijada en un paper (estable por naturaleza: el
  contraste GPT-3/Chinchilla ES el contenido formativo del 05). Los redactores operaron con esa
  exención implícita ([redactor-05]: «cifras … sólo históricas y de paper … con cita autor-año»)
  que ninguna pieza normativa asienta.
- **Observaciones de 015**: confirma [editor-02] (que elevó exactamente esta decisión a la mesa)
  y la convención declarada de [redactor-05].
- **Impacto**: cada futuro redactor o mantenedor rehace la interpretación; un barrido literal de
  M3 §6.1 obligaría a vaciar secciones formativas correctas.
- **Dirección** (Cadena §2): asentar la exención en M3 §6.1 — una línea aditiva: la cifra
  histórica anclada a paper con autor-año no es «parque vigente» y no pasa por la tabla del 11 —
  antes que purgar 02 y 05. Dónde cae: una línea en M3, reversible; la alternativa cae en el
  lector del 05, que pierde las leyes de escala con sus números. La capa volátil sigue intacta:
  ninguna de esas cifras caduca por evento de mercado.

### R2-SIS-05 · P2 · E2 · enumerable — El tramo «servido en el banco» del alcance aprobado quedó ilustrativo y M2 §5 no lo refleja

- **Ancla E2**: folio 011 §4, PREGUNTA 4: «entrenar → doc 06 (QLoRA sobre Qwen ≤1.5B con
  PEFT/TRL, export GGUF, **servido en el banco**…)»; contra 06 línea 340 («los pasos 5–6 (servir
  en el banco) quedan ilustrativos»), línea 561 («[Ilustrativo — no verificado en el banco] —
  crear modelos en el banco compartido es decisión…») y su `entorno_validado` («parcial»); y
  contra M2 §5 («Labs 6.A …, 6.B (receta LoRA de HF al banco)») que lista 6.B sin la salvedad
  que sí anota para los embeddings del 09.
- **Qué falla**: el único verbo del pedido cuyo cierre operable aprobado no quedó ejercitado
  punta a punta es «entrenar»: el default de la duda de [redactor-06] (ACT-03: crear
  `taller-qwen`/`taller-qwen-base`, correr el paso 6 y borrarlos) no se ejecutó, y el mapa de
  cohesión presenta el laboratorio como si llegara al banco.
- **Observaciones de 015**: eleva la duda de [redactor-06] (sigue abierta); confirma la lectura
  de [M0-raiz] sobre el `entorno_validado` parcial del 06 (el del 07 sí quedó cerrado: labs
  corridos completos, 0 marcadores VERIFICAR en todo el corpus).
- **Impacto**: pérdida acotada — el lector puede correr los pasos 5–6 contra su propia
  instalación; pero el estado publicado difiere del alcance aprobado sin asiento en el mapa.
- **Dirección**: ejecutar el default ya declarado de la duda (crear, correr, borrar; es el
  «SI NO RESPONDÉS» que rige) o asentar la decisión de ACT-03; mientras tanto, M2 §5 anota la
  salvedad del 6.B igual que hace con el camino alternativo del 09. No duplicar la pregunta al
  PO: ya viaja en 015.

### R2-SIS-06 · P2 · E2 · enumerable — Consolidación del glosario pendiente: ≥14 términos con definición normativa en los núcleos sin entrada en M1

- **Ancla E2**: M1 §5.1 regla 3 (regla de corte: «entra al glosario el término que algún núcleo
  usa») y regla 4 («los redactores … agregan entradas conforme a las reglas 1–3; el mantenedor
  (ACT-06) consolida»); contra la lista enumerada en 015: BPE, subpalabra, SentencePiece
  [redactor-01]; corpus, procedencia, JSONL, datasheet [redactor-04]; RoPE, GQA/MQA, máscara
  causal [editor-02]; system prompt, safetensors [editor-06]; encoder de visión/ViT, códec
  neuronal, ASR, espectrograma [redactor-10], [editor-10].
- **Qué falla**: los redactores cumplieron su mitad (definir en el dueño y declarar el candidato);
  la consolidación de ACT-06 no ocurrió antes de esta ronda. El glosario — vendido por M0 §4 como
  el lugar «no entiendo un término» — no cubre términos que el cuerpo define normativamente.
- **Impacto**: hueco acotado y enumerable; ninguna definición falta en el cuerpo (autocontención
  intacta), falta el índice de entrada.
- **Dirección**: un solo barrido de consolidación contra las etiquetas citadas, con dueño el que
  cada observación ya propone, antes de promover ninguna pieza a `status: vigente`.

### R2-SIS-07 · P3 · E2 · enumerable — `owner` de M1 fuera de la norma de M3 §1.1

- **Ancla E2**: M1 línea 8 (`owner: Lab-Documentos`) contra M3 §1.1 línea 51 (`owner: <actor
  responsable, por su ID de M1>`); las otras 14 piezas usan ACT-06/ACT-05/ACT-04.
- **Observaciones de 015**: confirma [M0-raiz] (lo detectó y no corrigió por ser pieza ajena).
- **Dirección**: `owner: Mantenedor de la guía (ACT-06)`; corrección de un campo.

### R2-SIS-08 · P3 · E2 · enumerable — El mismo informe técnico con dos autorías dentro del corpus, una de ellas la que M3 norma

- **Ancla E2**: M3 §2.2 línea 107 norma el informe técnico con equipo colectivo («Qwen Team
  (2025). Qwen3 Technical Report. arXiv:2505.09388») y 11 línea 576 lo cita así; pero M1 §7 línea
  275 y 06 líneas 135/773 citan «Yang, A., et al. (2025)» para el mismo arXiv:2505.09388 (ídem
  Bai et al. (2025) para Qwen2.5-VL en M1 línea 252, también informe de equipo).
- **Observaciones de 015**: confirma [editor-06] y [editor-08] (que lo dejaron a la ronda 2).
- **Impacto**: mismo hecho contado distinto en dos piezas estructurales; el lector no puede saber
  si son dos fuentes.
- **Dirección**: una sola forma y barrido. Elección técnica dentro de las restricciones (la mesa
  la resuelve sola); nota de esta comisión para esa elección: el PDF del informe lista autores
  nominales, así que si se mantiene la norma del equipo colectivo conviene decirlo en M3 §2.2
  («aunque el PDF liste autores») para que el próximo redactor no vuelva a divergir de buena fe.

### R2-SIS-09 · P3 · E2 · interpretativo — Fuentes del glosario que no fundan la definición que acompañan

- **Ancla E2**: M1 §5.2 — «caché KV … Vaswani et al. (2017)» (línea 187: el paper define la
  atención con claves/valores, pero no describe el cacheo de K/V en inferencia, que es una
  optimización posterior de servicio); «inferencia», «motor de inferencia» y «tokens por
  segundo» con fuente «Yang et al. (2025)» (líneas 183, 184, 188: un informe de modelo no es
  fuente de esas nociones de arquitectura de servicio). La carta manda que una cita que no
  resiste degrada lo que la usa.
- **Impacto**: bajo — las definiciones de una línea son correctas; la fuente es de conveniencia.
- **Dirección**: fuente apta para el bloque de inferencia/servicio (p. ej. Pope, R., et al.
  (2022). Efficiently scaling transformer inference. arXiv:2211.05102) o la marca honesta
  «criterio de esta guía» que M3 §2.3 ya prevé.

## Lo que revisé y está bien (hasta tres)

1. **La columna vertebral de la cohesión cierra entera**: el grafo de M2 §2 (mermaid y tabla), los
   prerrequisitos declarados en las once envolturas, el temario del folio 011 §2 y la ruta
   formativa publicada en M0 §3 coinciden uno a uno (01:—, 02:01, 03:02, 04:03, 05:04, 06:05,
   07:03+06, 08:02+03, 09:01+08, 10:02+03, 11:05–10); el grafo es acíclico, 11 es el único
   sumidero, la cadena Anterior/Siguiente sigue la ruta (03→08→04) tal como M2 la documenta; y
   los 0 enlaces rotos sobre las 15 piezas cierran lo que [editor-05], [editor-03], [M0-raiz] y
   [editor-11] dejaron pendiente de la elaboración en paralelo (los doc_id IAM-M0/M2/M3 que
   [M1-marco] asumió quedaron exactamente ésos). Confirmo [M2-cohesion] en sus cinco puntos.
2. **Higiene de repositorio público y disciplina del banco**: 0 rutas de host, IPs o credenciales
   en el corpus (grep sobre las 15 piezas); el banco aparece siempre como `$OLLAMA_HOST` /
   `http://localhost:11434`; 0 marcadores VERIFICAR residuales (lo que cierra el pendiente que
   [M2-cohesion] anotó sobre IAM-07 e IAM-06).
3. **Las fronteras de M2 §4 operan en el cuerpo**: el paso 0 se enseña una vez (08 §, H-IR-03) y
   las otras diez piezas lo citan sin duplicarlo; los laboratorios tienen dueño único y los
   ajenos se citan por enlace; el camino alternativo de embeddings del 09 (obstáculo del folio
   011 §5) está declarado coherente en 09, M2 §5 y M2 §6 fila 8; y el muestreo de referencias de
   M1 §7 (identificadores arXiv de Vaswani 2017, Brown 2020, Hoffmann 2022, Hu 2022, Dettmers
   2023, Rafailov 2023, Lewis 2020, Zheng 2023, Jiang 2024, OSAID 1.0) dio consistente con los
   identificadores canónicos conocidos; también verifiqué que la regla de siglas de M1 §5.1
   regla 5 sí procede de ARQIA-03 (informe 008, dirección de la corrección), descartando mi
   propia sospecha de trazabilidad errada.

## Señales fuera de mi competencia (solicitud, no hallazgo)

- Estilo editorial: «*dataset*» en cursiva canónica de M1 contra el uso plano en 04/06/07
  ([editor-06]); cursivas alternadas de *embedding*/*token* ([editor-10]); grafías
  «des-tokenizar» y «no-determinismo» ([editor-01], [editor-03]). Para la comisión editorial.
- Veredicto de evidencia: estabilidad del empate 0,421/0,421 del lab 2 del 09 entre versiones de
  la biblioteca ([editor-09], [verificador-09]). Para quien juzgue evidencia.

## Dudas para quien pidió

Sin dudas nuevas: las dos que tocan mi revisión ya viajan — el lote del folio 012 y la duda de
[redactor-06] a ACT-03 (elevada acá como parte de R2-SIS-05, con su default ya declarado). No se
duplican.
