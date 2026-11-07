# Informe — Refutador (ronda de estructura)

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-07 |
| Autor | refutador (núcleo permanente) |
| Corrige | — |

Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas: cabecera y §0 (líneas 1–111, con el Mapa de
carga), §1, §2 (§2.1–§2.3), §3 (§3.1–§3.4), §4, §5 (§5.1–§5.4), §6, §7, §8 (la fila del presidente,
que el mapa da al refutador). Además cargados: Cadena-De-Consecuencias 2.0 (§2 y §3, corrida en §4
de este informe). Excepcion-A-Un-Conocimiento 2.1 no se cargó: la carta lo condiciona a juzgar una
excepción y no hay ninguna que juzgar — `despacho/` no contiene ningún `*-ficha-*.md` (listado del
2026-11-07: cinco informes de comisión y este archivo) y los cinco informes declaran explícitamente
no proponer excepciones (`grep -il 'ficha' despacho/comision-*.md` + lectura de cada declaración).

Insumos leídos (todos, soy el único rol que lee los informes): folios 001, 002 y 003; pliego
operativo (evidencia 002); las cinco cartas (evidencias 004–008); los cinco informes de
`despacho/`; Profile `Study-Guide-Documentation`; mi carta (evidencia 009).

Clase de objeto: diseño de una norma o decisión. Mi ataque principal, por la clase: **el costo de
aplicar** lo propuesto. Lectura P0–P3: la del folio 002 (P0 viola restricción dura; P1 retrabajo
del conjunto o ejemplo inviable; P2 pérdida acotada; P3 claridad).

Prefijo de familia: **RF-**.

Ningún paso prescripto me falló: sin BLOQUEO. Nota: el banco de ensayo no es alcanzable desde mi
contexto (`curl -s -m 3 http://localhost:11434/api/tags` → exit 7, y mi despacho no declara el
endpoint real); las anclas E1 de la comisión de inferencia sobre el banco quedan como suyas y, donde
yo las toco, las trato como heredadas (clase C para mí, pliego §2, regla de anclaje 4). Ningún
hallazgo mío se funda en ellas.

---

## 1. Hallazgos

### RF-01 · P1 · E1+E2 · enumerable · aguas arriba: cartas (evidencias 004–008) y folio 003 — Solapamiento sistemático: 31 núcleos propuestos para unos diez lugares, con los mismos laboratorios hasta cuatro veces

**Ancla E1 (comando y salida, 2026-11-07, sobre `despacho/`):**
`for f in comision-*.md; do grep -cE '^### N' "$f"; done` → edición-publicación 6,
entrenamiento-métricas 5, fundamentos-panorama 7, inferencia-rag 5, sistemas-ia 8; total
`grep -hE '^### N' comision-*.md | wc -l` → **31**.

**Ancla E2 (duplicaciones concretas, archivo y sección):** el núcleo de evaluación/métricas está
propuesto tres veces (fundamentos §3 N7; entrenamiento §3 N-EM-5; sistemas §2 N5); el de
embeddings/vectoriales/RAG, tres (fundamentos N6; inferencia N3–N5; sistemas N6); el multimodal,
dos (fundamentos N4; sistemas N7); el panorama/ecosistema, dos (fundamentos N5; sistemas N8). A
nivel laboratorio: «comparar base vs instruct» aparece cuatro veces (fundamentos N3 ej. —cuadro—,
entrenamiento N-EM-2 ej. 3 y N-EM-4 ej. 1, sistemas N3 ej. b); «barrido de temperature», cuatro
(fundamentos N3 ej. 1; inferencia N1 ej. 3; sistemas N4 ej. c; edición N-ED2 ej. 1); «coseno a mano
sobre tres frases», tres (fundamentos N1 ej. 2; inferencia N3 ej. 1; sistemas N1 ej. b); «mini-eval
propia», tres (fundamentos N7 ej. 1; entrenamiento N-EM-5 ej. 1; sistemas N5 ej. a); «chunking a dos
tamaños», tres (fundamentos N6 ej. 3; inferencia N5 ej. 3; sistemas N6 ej. b); «tokenizar la misma
frase en dos idiomas», dos; «leer una model card», tres.

**Causa aguas arriba (de la corrida):** las cinco cartas son la misma plantilla y todas piden «los
núcleos conceptuales de tu dominio» con los mismos cuatro entregables (evidencias 004–008, bloque
«Entregá en tu informe»), y las no-competencias del folio 003 no son exhaustivas: la de fundamentos
excluye entrenamiento, inferencia y pedagogía pero no métricas (señal de V2), ni vectoriales/RAG
(señal de V3), ni la vista de sistema; la de sistemas excluye «contenido interno de cada tema» y el
informe de sistemas igual entrega definiciones, ejemplos y fuentes por tema para los ocho. La
duplicación estaba programada en el despacho; las comisiones, a ciegas, hicieron lo que su carta
pedía.

**El mismo defecto entra además con niveles distintos:** «RAG es agregado sin frase del pedido» es
P1 en fundamentos (FP-03) y P3 en inferencia (H-IR-05), mismo hecho y misma dirección.

**Impacto si no se corrige:** la fase 3 despacharía redactores sobre un temario con tres dueños
para evaluación y tres para RAG; cada duplicado es retrabajo o contradicción en el conjunto
(definición de P1 del contrato). El mapa de cohesión que el pedido exige no puede escribirse sobre
31 núcleos solapados.

**Dirección de la corrección:** (1) la consolidación del paso 7 produce la tabla núcleo→dueño
único, con los solapamientos resueltos por la señal que el folio 003 asignó (métricas→V2,
vectoriales/RAG→V3, multimodal/panorama→V1, vista de sistema y grafo→A1, transversales
editoriales→A2); propongo el mapa consolidado en §5. (2) Cada laboratorio queda en un solo
documento y los demás lo referencian (Rule-Documentation del destino: única fuente de verdad, ya
decisión cerrada del contrato). (3) Las cartas de la ronda 2 completan las no-competencias con las
fronteras explícitas, para no reproducir el defecto. (4) El nivel de «RAG agregado» se unifica en la
consolidación (propongo P2: la corrección es asentarlo marcado, no retrabajar nada).

### RF-02 · P1 · E2 · interpretativo — El costo de aplicar la plantilla agregada no lo midió nadie: sumadas las direcciones de las cinco comisiones, cada documento carga ~12 elementos obligatorios y el conjunto 62–124 laboratorios candidatos

**Ancla (citas):** si el veredicto aprueba todas las direcciones tal como vienen, un documento
temático debe llevar: las seis secciones del Profile («Estructura de cada documento temático»),
más el bloque didáctico pregunta→criterio→respuesta→reenvío (edición H-EDI-07; sistemas ARQIA-05),
más frontmatter normado de siete campos (edición H-EDI-05), más índice propio (folio 001, Reglas),
más prerrequisitos declarados al abrir (edición H-EDI-03), más «qué cambia por contexto» (Profile,
eje Contextos), más un bloque «protocolo» por cada cifra (entrenamiento EM-03), más versiones
fijadas con fecha/entorno de validación (edición H-EDI-06; sistemas ARQIA-02), más contrato de
profundidad declarado (entrenamiento EM-04), más salida esperada y variantes de fallo por ejemplo
operable (edición N-ED5), más mermaid cuando corresponda y cuadros comparativos (folio 001), más
enlaces precedente/siguiente y glosario (Profile, «Interconectado»). Y la letra de las cartas pide
«2–4 ejemplos prácticos candidatos» **por núcleo** (evidencias 004–008, entregable 2): sobre los 31
núcleos propuestos (RF-01, E1) son 62–124 laboratorios, cada uno con protocolo, salida capturada y
corrida de verificación en fase 3.

**Qué falla:** éste es exactamente el defecto más caro de la clase «diseño de una norma»: una
ceremonia que ningún redactor va a completar (Mesa-De-Expertos-A-Pedido §7, anti-patrón «Refutador
que sólo ataca la evidencia», que lo nombra; E4). Cada comisión corrió la cadena de consecuencias
sólo sobre su opción local (forma documental, cadena de herramientas, motor); **ninguna la corrió
sobre el conjunto**, que es donde cae el costo: en los redactores y el verificador técnico de la
fase 3, y en el lector principiante que recibe documentos donde el aparato pesa más que el
contenido. Nadie midió cuántos documentos y cuántas corridas compra el temario agregado.

**Impacto si no se corrige:** la fase 3 entrega documentos a medio ceremonial —peor que un aparato
más chico y completo (filtro «la unidad de aplicación es el documento», pliego §3)— o no entrega; y
el primer envejecimiento de catálogo obliga a revalidar decenas de laboratorios duplicados.

**Dirección de la corrección:** la resolución fija un **presupuesto editorial** medible:
(1) tope de documentos del conjunto ≈ 15 (11 temáticos + 4 estructurales, §5), dentro del patrón de
la casa (13–17 piezas por corpus, ia-db índice 10, dato ya citado por sistemas §2);
(2) 2–3 laboratorios **operables** por documento con dueño único, el resto «ilustrativo» marcado
(la marca ya existe en MEDIOS del folio 002);
(3) un único documento de Convenciones que absorba las cinco piezas que hoy norman lo mismo por
separado (protocolo de cifras EM-03 + aparato de citado N-ED3/H-EDI-04 + ejemplo operable N-ED5 +
vigencia H-EDI-06/N-ED6 + capa volátil ARQIA-02): una regla, un lugar, y los documentos temáticos
la citan en una línea en vez de repetir el aparato;
(4) el bloque didáctico **absorbe** la sección «Preguntas guía» del Profile (es la misma pieza con
respuestas), no se suma como sección aparte — es aditivo sobre el Profile y no requiere ficha,
como ya argumentó sistemas ARQIA-05.

### RF-03 · P1 · E2 · enumerable · aguas arriba: cartas (evidencias 004–008) y folio 002 — La carta endureció dos medios en requisito («tipo Qwen» del Contexto; Ollama de MEDIOS) y las tres comisiones que lo atacaron a ciegas coinciden: la corrección va al origen, no a los informes

**Ancla:** el objetivo de las cinco cartas dice «ejemplos prácticos operables sobre modelos open
source tipo Qwen (“Contexto” del pedido)» y el entregable 2 fija «operables en un entorno local con
Ollama/modelos Qwen cuando aplique» (evidencias 004–008). En el pedido, la frase del Contexto es
descriptiva («Actualmente tenemos corriendo diferentes modelos de qween») y «Ollama» no aparece:
`grep -in 'ollama' actuaciones/001-presentacion-*.md` → sin salida, rc=1 (corrida propia,
2026-11-07, que confirma el E1 de edición H-EDI-01). Es el filtro «Comportamiento no es
restricción» (pliego §3 vía norma §3.3): lo que el entorno hace hoy es variable, no alcance. Tres
comisiones lo detectaron por separado y a ciegas (inferencia H-IR-01, sistemas ARQIA-04, edición
H-EDI-01) con la misma dirección — convergencia independiente que sí cuenta como verificación.

**Impacto si no se corrige:** las cartas de la fase 3 heredarían la cláusula endurecida y los
redactores atarían la guía a una herramienta y una familia que el pedido no fijó; si el PO quisiera
otra cosa, retrabajo de todos los ejemplos.

**Dirección de la corrección:** en la resolución: «banco de ensayo Qwen/Ollama = decisión del
contrato con origen en MEDIOS (medio disponible y verificado), no requisito del pedido; alcance
conceptual y comparativo = ecosistema de pesos abiertos»; los agregados («tipo Qwen» como alcance
de ejemplos, RAG como lectura de “base de datos vectoriales”) salen **marcados** en el lote del
cierre para ratificación, con default declarado — un agregado no se asienta por silencio (pliego
§4, regla 7).

### RF-04 · P2 · E2 · interpretativo — El núcleo N8 de sistemas agrega un eje de gobernanza regulatoria (NIST AI RMF, ISO/IEC 42001, AI Act) que ninguna frase del pedido nombra

**Ancla:** sistemas §2, N8: «marcos de gobernanza y riesgo», cuadro candidato «NIST AI RMF vs
ISO/IEC 42001 vs AI Act», actor ACT-05 «responsable de datos y cumplimiento». El pedido (folio 001)
no contiene «gobernanza», «riesgo», «cumplimiento» ni «regulación»; «basarse en las tendencias del
mercado y los estandares de la industria» manda fundar el contenido en estándares del dominio (la
lectura que ya aplican las demás comisiones: benchmarks, model cards, licencias), no sumar un
currículo normativo-regulatorio. La norma manda: lo que no sale del pedido ni de una regla es
agregado y no se despacha, o va marcado (§3.1). Distinto de las **licencias** (entrenamiento EM-07,
N-EM-1), que sí tienen origen operativo: la guía enseña a «descargarlos» y usar un peso sin leer su
licencia no es práctica verificable.

**Impacto si no se corrige:** carga de lectura regulatoria sobre la audiencia principiante (la
restricción que P0 protege) y un frente más de caducidad (el AI Act tiene calendario propio), a
cambio de nada que el pedido pida.

**Dirección de la corrección:** recortar N8 a lo con origen —panorama, licencias/open-weights,
model cards, criterio de selección— (se funde con fundamentos N5, §5); la gobernanza regulatoria
queda fuera de alcance o, si alguien la sostiene, como fila de alcance propuesta al PO en el lote,
marcada, que tampoco se asienta por silencio.

### RF-05 · P2 · E1 · enumerable — El ancla E1 de FP-03 (fundamentos) está mal construida: el comando declarado no produce la salida declarada

**Ancla (corrida propia, 2026-11-07, sobre el folio 001):**
`grep -ci 'rag' actuaciones/001-presentacion-*.md` → **1** (no 0: la línea 49 contiene
«f**rag**mentes»); `grep -oin 'rag' …` → `49:rag`. El comando que sí sostiene la afirmación es
`grep -niE '\brag\b' …` → sin salida, rc=1. FP-03 declara «`grep -ci 'rag' sobre el bloque` → 0
ocurrencias como término»: el comando citado no es el que da esa salida (cuenta líneas con la
subcadena, y da 1), y «sobre el bloque» no es una ruta reproducible. Por la regla de anclaje 2 del
pliego §2, una afirmación de no colisión sin el comando que la sostiene con su salida es C.

**Impacto si no se corrige:** el jurado votaría un P1 cuyo fundamento formal es C; y el expediente
queda con un comando que quien relea no puede reproducir — exactamente lo que el pliego llama
medido («un refutador contó líneas donde había que contar ocurrencias»; acá, la comisión).

**Impacto real acotado:** la **conclusión** de FP-03 sobrevive con el comando corregido (y coincide
con H-IR-05 de inferencia): «RAG» no está en el pedido como término. Es defecto del ancla, no del
hallazgo.

**Dirección de la corrección:** la consolidación re-ancla FP-03/H-IR-05 con el comando corregido de
arriba y un solo nivel (propongo P2, ver RF-01), antes del veredicto.

### RF-06 · P2 · E2 · enumerable — Catorce dudas al PO sin pasar el filtro del lote: duplicadas, contestadas por el árbol, o que son un obstáculo de una línea

**Ancla:** los cinco informes traen 2+3+3+3+3 = **14** dudas para quien pidió. Contra el pliego §4
(reglas 7 bis y 10: un solo lote por fase, filtrado; al lote sólo llega lo de la lista cerrada) y la
norma §3.1 («No se le pregunta a quien pidió nada que el pedido y el árbol contesten»):
— **Duplicadas:** la GPU disponible está preguntada dos veces (entrenamiento duda 1; sistemas
duda 1) y el piso de hardware del lector, en paralelo (inferencia duda 2); son una sola pregunta.
— **Contestadas por el árbol:** «¿archivo único o multi-documento?» (edición duda 1) la contesta el
Profile que el propio pedido manda aplicar («Resultado esperado»: «conjunto documental navegable
desde su README»; folio 001, sección Framework) — no debe salir al PO; «¿APA o ISO 690?» (edición
duda 3) es elección técnica dentro de las restricciones dadas, que la mesa resuelve sola (pliego
§3, lista de lo que no se escala).
— **Obstáculo, no fila de lote:** incorporar un modelo de embeddings al banco (inferencia duda/
obstáculo 1) es una decisión ya fundada a la que sólo le falta quien tiene la llave: es la pregunta
de una línea a quien administra el banco, en el momento (Cadena-De-Consecuencias §3), no una
escalada enterrada en el lote.

**Impacto si no se corrige:** el PO recibe un cuestionario en vez de un lote: la clase de consulta
que la mesa existe para eliminar (norma §7).

**Dirección de la corrección:** lote consolidado de **cuatro** filas (propuesta en §6) + la
pregunta de una línea del obstáculo por canal directo; el resto se decide y se registra.

### RF-07 · P2 · E1 · enumerable · de la corrida — La fase de comisiones cerró sin bitácora: el rol bitacorista que el pedido manda no tiene salida visible para esta fase

**Ancla:** folio 001 (Solicitudes): «bitacoristas para que ayuden ante consulta de avances e
historial por parte de los subagentes»; folio 003 §5: «la presidencia despacha un agente
bitacorista **por fase** que mantiene las bitácoras en OUTPUTs/Bitacoras». Comando (2026-11-07):
`ls OUTPUTs/Bitacoras/` → `01-arranque-y-enunciado.md` — una sola pieza, la del arranque. Las cinco
comisiones ya corrieron y no hay bitácora de la ronda de estructura.

**Impacto si no se corrige:** la próxima consulta de avance de un subagente (el uso que el pedido
nombra) no tiene dónde leer; y el folio 003 §5 queda como asignación que nadie ejecutó — un control
declarado no ejercido, que no se absuelve en silencio (filtro «descripción o control», pliego §3).

**Dirección de la corrección:** es de la corrida y se autocorrige sin escalar: bitácora 02 de la
ronda (comisiones despachadas, informes recibidos, refutación, veredicto) antes del cierre del
ciclo, y una por fase en adelante.

### RF-08 · P3 · E2 · interpretativo — La organización del producto por núcleos se atribuye a «Reglas» del pedido; esa regla gobierna el análisis del prompt (sus registros van a Bitacoras), y la forma del producto la funda el Profile

**Ancla:** folio 001, Reglas: la estrategia de descomposición se aplica «sobre la totalidad del
prompt», pide «presentar cada eje a la mesa evaluadora» y cierra con «apóyate en ir generando
registros… en `OUTPUTs/Bitacoras`» (líneas 47–60 del folio): gobierna el análisis y la
planificación, no la forma documental de la guía. El contrato (folio 002, OBJETIVO: «organizada por
núcleos conceptuales con documento de cohesión global (“Reglas”)») y edición H-EDI-02 citan esa
sección como origen de la forma multi-documento del producto. El origen correcto está a un paso: el
Profile que el pedido manda («Resultado esperado»: conjunto documental; «un documento por tema»).

**Impacto:** nulo en el resultado (el Profile sostiene lo mismo); trazabilidad del contrato, que la
ronda 2 podría impugnar.

**Dirección:** la resolución corrige la cita de origen de esa cláusula (Profile vía sección
Framework del pedido, con «Reglas» como refuerzo de la cohesión global, que sí es exigible al
producto por su última frase: «integrarlos en un todo coherente»).

**Resumen:** P0: 0 · P1: 3 (RF-01, RF-02, RF-03) · P2: 4 (RF-04, RF-05, RF-06, RF-07) · P3: 1
(RF-08). Total 8 de tope 12.

---

## 2. Dictamen sobre los cuatro frentes de mi carta

**(a) La lectura dominante.** Las cinco comisiones convergieron, a ciegas, en: banco Qwen/Ollama
como medio y no como alcance; separación capa estable / capa volátil con versiones fijadas;
prerrequisitos y ruta de lectura declarados; núcleos con dueño y documento de cohesión. La ataqué
por evidencia (RF-05: una de sus anclas estaba mal construida; la conclusión resistió) y por
aplicación (RF-01, RF-02: tal como viene agregada, la estructura no se puede completar). La lectura
dominante **sobrevive en el qué y falla en el cuánto**: es correcta como dirección y está sin
presupuesto como norma. La corrección es de consolidación y tope, no de reemplazo.

**(b) El objetivo contra el pedido literal.** Lo dado por fijo sin que nadie lo pidiera: «tipo
Qwen»/Ollama endurecidos en las cartas (RF-03, va al origen), gobernanza regulatoria (RF-04), y la
atribución de la forma del producto a «Reglas» (RF-08). **La decisión de la presidencia «documento
raíz + carpeta» la ataqué con la solución más chica (un solo archivo en la ruta literal) y la
decisión sobrevive:** el archivo único cumple la frase de «Solicitudes» pero incumple el Profile
que el mismo pedido manda aplicar en «Framework» («conjunto documental navegable desde su README»,
«un documento por tema»; E2) y el plural de sus propias Reglas («Los documentos creados deben tener
índices»). No hay solución más chica que cumpla el pedido entero; la ratifico (con la cita de
origen corregida por RF-08). Segunda solución más chica evaluada: menos documentos que los 31
propuestos — ésa sí procede y es RF-01/§5.

**(c) Fichas de excepción.** No hay ninguna en `despacho/` (verificado, cabecera). Ninguna comisión
propuso apartarse de una convención que rige: la pregunta «¿cuánto cuesta realmente cumplir?» no
tiene materia en este ciclo. El agregado del bloque didáctico sobre el Profile (ARQIA-05/H-EDI-07)
es aditivo y no excepción, como sistemas ya argumentó; lo confirmo.

**(d) Huecos y solapamientos.** Huecos: contrasté cada tema que el pedido nombra (montar,
descargar, entrenar, arquitecturas, transformers, métricas, motor de inferencia, NLP, generativas,
multimodales, bases vectoriales, términos asociados, gráficos, cuadros, preguntas guía) contra la
unión de los cinco catálogos: **ningún tema nombrado quedó sin dueño** (el mapa de cobertura de
sistemas §2, verificado contra los otros cuatro informes). Sin hueco P0. Solapamientos: RF-01, con
su evidencia enumerada y su tabla de resolución en §5.

---

## 3. Lo que revisé y está bien (tres)

1. **La decisión «documento raíz + carpeta» de la presidencia**: atacada contra la solución más
   chica y sostenida con E2 del Profile y del propio pedido (dictamen (b)); además las cuatro
   comisiones que la tocaron la ratificaron por vías independientes.
2. **La disciplina formal de los cinco informes**: todos declaran «Secciones leídas» conforme al
   Mapa de carga (la carga extra de §3.4 en edición está declarada como respaldo, que vale);
   ninguno cita a otro informe del ciclo; topes respetados (7, 9, 5, 8 y 8 hallazgos ≤ 12); todos
   corrieron Cadena-De-Consecuencias §2 antes de recomendar y lo asientan.
3. **Dos anclas E1 ajenas re-corridas y confirmadas**: `wc -l` de la guía monolítica comparable →
   `2944` (edición, cadena §4) y prefijo `IAM-` sin colisión en `Guides/` del destino → `0`
   (sistemas ARQIA-06). Re-corridas el 2026-11-07 sobre el worktree del repo destino.

---

## 4. Cadena de consecuencias (§2, corrida antes de recomendar la consolidación de RF-01/RF-02)

**Decisión: cómo integrar los cinco catálogos.**
- **Opción A — unión (se aprueban los 31 núcleos y se reparte después):** cae en los redactores y
  el verificador de la fase 3 y en el lector. Peso ahí: 31 núcleos × 2–4 laboratorios por letra de
  las cartas = 62–124 corridas con protocolo (E1/E2 de RF-01/RF-02); triple dueño para evaluación y
  RAG. Qué pierde la alternativa: nada de cobertura (la unión no agrega temas, duplica dueños).
  Reversible: desduplicar documentos ya escritos es retrabajo caro (re-anclado de citas y grafo).
- **Opción B — consolidación con dueño único y tope (≈11 temáticos + 4 estructurales, §5):** cae en
  la presidencia (una tabla de consolidación ahora) y en el lector que quiera más profundidad en un
  eje fundido. Peso ahí: la tabla sale de los propios informes (los reparto en §5); la pérdida de
  profundidad se mitiga con el tope de laboratorios, no de contenido conceptual. Qué pierde la
  alternativa: la opción A pierde la completabilidad; B pierde algo de granularidad de V2 (tres
  núcleos de entrenamiento quedan en dos documentos). Reversible: **sí** — partir un documento
  aprobado en dos es aditivo; fundir dos escritos es retrabajo (misma asimetría que ya midió
  sistemas en su cadena).
- **Recomendación: B**, decidida por los pasos 2 y 4. Condición de revisión comprobable: si en la
  ronda 2 un documento consolidado supera el patrón de la casa (≈ tamaño de las piezas de las guías
  estructuradas del destino) o su tope de laboratorios, se parte por el eje que el grafo ya declara.

---

## 5. Mapa consolidado propuesto (dirección de RF-01/RF-02; dueño = comisión de origen)

Temáticos (11): 
1. **Representación del lenguaje: tokens y embeddings** (V1; funde V1-N1, A1-N1; la parte
   conceptual de embeddings de V3-N3 se escribe una vez acá).
2. **Arquitectura Transformer y variantes** (V1; funde V1-N2, A1-N2).
3. **Del modelo base al asistente: uso, prompting y muestreo** (V1-N3, sólo taxonomía y uso; los
   procedimientos quedan en 6).
4. **Datos y corpus** (V2 N-EM-1, con licencias de pesos y datasets — EM-07).
5. **Preentrenamiento y leyes de escala** (V2 N-EM-2; A1-N3 se reparte entre 5 y 6).
6. **Ajuste fino y alineación** (V2 N-EM-3 + N-EM-4; cadena de herramientas de EM-01).
7. **Evaluación y métricas de calidad** (V2 N-EM-5; absorbe V1-N7 y A1-N5; frontera con métricas de
   servicio según EM-05: éstas van al 8).
8. **Inferencia local: motores y cuantización** (V3 N1 + N2; absorbe A1-N4; métricas de servicio).
9. **Bases vectoriales y RAG** (V3 N3-operativo + N4 + N5; absorbe V1-N6 y A1-N6).
10. **Multimodalidad y generación no textual** (V1-N4; absorbe A1-N7; alcance del laboratorio según
    la duda 2 del lote).
11. **Panorama y ecosistema abierto** — capa volátil única, con fecha (V1-N5; absorbe A1-N8
    recortado por RF-04; inventario de modelos de referencia de FP-04).

Estructurales (4): **M0** `IA-Model-Guide.md` raíz (portada, índice, ruta de lectura);
**M1** Marco de referencia (ESC/CTX/ACT unificados de las cuatro propuestas + glosario bilingüe
EM-09/H-EDI-08); **M2** Cohesión global (grafo de dependencias — el de sistemas §2 como base — y
las dos rutas de lectura de H-EDI-03); **M3** Convenciones (citado + ejemplo operable y protocolo +
vigencia/capa volátil + plantilla del documento temático con el bloque didáctico — RF-02.3).

Grafo consolidado: 1 → 2 → 3 → {4…11}; 4 → 5 → 6; {3,6} → 7; 2 → 8; {1,8} → 9; {2,3} → 10;
{5…10} → 11. Ruta principiante: M0 → M1 → 1 → 2 → 3 → 8 → 4 → 5 → 6 → 7 → 9 → 10 → 11.

---

## 6. Lote propuesto (dirección de RF-06; cuatro filas + un obstáculo por canal directo)

| # | Pregunta | SI NO RESPONDÉS |
| --- | --- | --- |
| 1 | ¿Hay GPU (aunque sea de consumo) para los laboratorios de ajuste fino, y cuál es el piso de hardware del lector? (consolida entrenamiento-1, sistemas-1, inferencia-2) | Rige CPU sola y piso declarado CPU x86-64 / 16 GB RAM: ajuste con Qwen ≤1.5B, labs largos marcados «ilustrativo»; nada bloqueado |
| 2 | ¿La generación de imagen/audio lleva laboratorio operable o alcanza el nivel conceptual en el núcleo multimodal? (fundamentos-1) | Rige conceptual con ejemplo «ilustrativo»; promoción diferida con evento de cierre: viabilidad declarada en el banco |
| 3 | ¿El lector tiene manejo básico de terminal y de un lenguaje de programación? (fundamentos-2) | Rige el supuesto declarado en el marco (ACT estudiante: sin IA previa, con terminal y programación básica) y cada pieza que exija más lo marca |
| 4 | Ratificación de agregados marcados: banco Qwen/Ollama como medio de los ejemplos (no alcance) y RAG como lectura aplicada de «base de datos vectoriales» (RF-03) | Quedan asentados como decisión del contrato con origen en MEDIOS y como agregado «propuesto, sin ratificar»; los ejemplos corren igual sobre el banco, nada irreversible depende |

Obstáculo (una línea, a quien administra el banco, no al lote): «¿Incorporás al banco un modelo de
embeddings (p. ej. la variante chica de la familia Qwen3-Embedding) y verifico `POST /api/embed`?»
— si no, rige el camino alternativo que inferencia ya declaró (biblioteca local, con el eje no
fijado declarado).

La pregunta de cortesía de sistemas (frase trunca del pedido, ARQIA-08/duda 3) puede viajar en el
mismo lote como fila P3 sin default que bloquee, o descartarse; la dejo a la presidencia.

---

Sigue: incorporación de este informe como folio por la presidencia; consolidación (paso 7) con la
tabla de §5 y re-anclado de RF-05; veredicto del jurado · presidencia de la mesa · Cierra con:
folio de veredicto del jurado.
