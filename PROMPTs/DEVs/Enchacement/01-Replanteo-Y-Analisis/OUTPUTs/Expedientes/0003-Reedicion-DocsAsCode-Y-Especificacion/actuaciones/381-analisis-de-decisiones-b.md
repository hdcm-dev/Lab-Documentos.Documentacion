---
doc_id: EXP0003-F381
doc_type: analisis
title: Análisis de decisiones B del ciclo 3 — matriz por pregunta A-01 a A-15 y B-01 a B-12 sobre los nueve informes de comisión, sensibilidad a pesos, firmeza R-06 e impacto en cuerpo, conocimiento, libro, ensayos y orden de PR
status: borrador
origin: agent
confidence: alta en lo citado de F300 y de los informes F310 a F376 (leídos el 2026-11-02) y en las cuatro fuentes reabiertas hoy (§9); media en los puntajes de celda, que son juicio de esta silla con su observable; baja donde se rotula «sin verificar»
owner: presidencia de la reedición DocsAsCode (expediente 0003), silla AD-B del ciclo 3
last_review: 2026-11-02
audience: [refutador, jurado del ciclo 3, presidencia, comisiones CA-1 a CA-9, PO]
traces: [EXP0003-F099, EXP0003-F204, EXP0003-F300, EXP0003-F310, EXP0003-F320, EXP0003-F330, EXP0003-F340, EXP0003-F350, EXP0003-F360, EXP0003-F370, EXP0003-F374, EXP0003-F376]
---

| Campo | Valor |
| --- | --- |
| Tipo | analisis |
| Fecha | 2026-11-02 (la carta dice «HOY 2026-11-01»; el reloj de la sesión dio 2026-11-02, después del corte de energía; las fuentes se reabrieron el 2026-11-02) |
| Autor | Silla AD-B, a ciegas respecto de AD-A (no se leyó `F380`). Consolida, no vota ni emite hallazgos (`MEP`, paso 6 bis) |
| Corrige | — |

**Convención.** Como `F300`: `SDEI/`, `K`, `F0nn`–`F3nn`, `PoC-R` = `SDEI/Examples/Prueba-Ayuda-Por-Rol/`,
`DG` = `docs-guard`, `{servicio-privado}`, `{dir-de-trabajo}`. Comisiones: CA-1 `F310`, CA-2 `F320`, CA-3 `F330`,
CA-4 `F340`, CA-5 `F350`, CA-6 `F360`, CA-7 `F370`, CA-8 `F374`, CA-9 `F376`. La carta habla de «siete informes»;
el patrón `3[1-7][0-9]-informe-*` abarca **nueve** (hay dos en la década 370): se leyeron los nueve.

## Índice

1. [Método](#1-método)
2. [Tablero](#2-tablero)
3. [Eje A, pregunta por pregunta](#3-eje-a-pregunta-por-pregunta)
4. [Eje B, pregunta por pregunta](#4-eje-b-pregunta-por-pregunta)
5. [La hipótesis de F300 §6 a la luz del tablero](#5-la-hipótesis-de-f300-6-a-la-luz-del-tablero)
6. [Discrepancias entre comisiones que van al jurado](#6-discrepancias-entre-comisiones-que-van-al-jurado)
7. [Impacto: qué rehacer](#7-impacto-qué-rehacer)
8. [Orden de PR](#8-orden-de-pr)
9. [Fuentes externas](#9-fuentes-externas)
10. [Lo no verificado e incidencias](#10-lo-no-verificado-e-incidencias)
11. [Barrido de lo privado](#11-barrido-de-lo-privado)

---

## 1. Método

**Criterios** (los siete de la carta), con escala anclada 1–5 **[criterio propio, fijada antes de puntuar]**:

| K | Criterio | 5 | 3 | 1 |
| --- | --- | --- | --- | --- |
| V | Validez | Responde el pedido literal (E-01 a E-10) y coincide con norma o con dos o más fuentes de práctica | Responde en parte, o sin fuente aplicable | Contradice el pedido o una norma citada |
| CI | Verificabilidad en CI | Par rojo/verde determinista, ya medido o análogo a uno medido (anclas `muestra` de la mini demo, 404 de `PoC-R`) | Par propuesto sin medir, o sólo en pruebas del producto | Sin control posible; se revisa a mano |
| S | Simplicidad | Reusa piezas existentes; ≤ 1 pieza nueva | 2–3 piezas nuevas | > 3 piezas o herramienta nueva |
| C | Costo de adopción | Un PR mecánico | Migración o herramienta acotada (expediente de herramienta) | *Toolchain* o proveedor nuevo |
| SEG | Seguridad | Cumplimiento en servidor/build; nada restringido sale; *deny by default* | Visibilidad con control declarativo | Confunde visibilidad con acceso o amplía al agente |
| COM | Compatibilidad con el cuerpo vigente | Reusa tal cual (`TEM-05` §3.3, anclas de nivel 2, `topic`) | Compatible con cambio de forma | Choca con una regla vigente (p. ej. «derivar no es generar», `TEM-05:44`) |
| PE | Practicidad y escalabilidad para el PO | Se aplica a `{servicio-privado}` y a un proyecto chico sin rehacer | Sirve a uno de los dos | Sólo sirve con un proveedor o rehace por proyecto |

**Pesos:** 1/7 cada uno (razón insuficiente, como `DEC` §4). **Sensibilidad:** cada peso ×1,1 y ×0,9 de a uno,
renormalizado (14 vectores); se cuentan las inversiones del ganador. **Firmeza (R-06 de `F099` §4):** FIRME si la
ventaja en **puntos de celda** (suma de celdas del ganador menos la del segundo) es ≥ 3 **y** no hay inversiones; si
no, CON REVISIÓN con condición comprobable. Cálculo: `calc.py` y `celdas.py` en `{dir-de-trabajo}` (Python 3, sin
dependencias); huellas al cierre de §10. **Filtro de pedido:** una alternativa que no cubre E-01 a E-05 (alcance,
superficies, API restringida) puede puntuar, pero no gana (como CA-6 con su CA6-B y CA-3 con su S-2).

**Lo que no hice:** no medí nada en un repositorio; los observables de celda remiten a lo medido por las comisiones
(p. ej. el ensayo de CA-3 sobre `PoC-R`, `F330` §7; las anclas de la mini demo citadas por CA-4, `F340` §5).

## 2. Tablero

Celdas en orden V · CI · S · C · SEG · COM · PE. «Pts» = suma de celdas.

| Pregunta | Ganador (origen) | Pts | Segundo | Pts | Ventaja | Inversiones ±10 % | Firmeza |
| --- | --- | --- | --- | --- | --- | --- | --- |
| A-01 | a1 dos términos: audiencia + regla de entrega (CA-1, CA-5; CA-2, CA-3 por la forma) | 31 | a2 audiencia que incluye acceso (CA-9, H) | 23 | +8 | 0/14 | FIRME |
| A-02 | b1 dos planos: orientación y entrega (CA-1, CA-3, CA-4, CA-5) | 29 | b2 fila plana (H, CA-6, CA-9) | 25 | +4 | 0/14 | FIRME |
| A-03 | c1 decisión nueva; Marco «Audiencias típicas» (todas) | 29 | c2 ampliar D-01/D-13 | 24 | +5 | 0/14 | FIRME |
| A-04 | d1 lector = dimensión; `TEM-04` sigue como tema de canales (CA-1, CA-5, CA-7, CA-9) | 30 | d2 absorber en «Audiencias» (CA-2) / d3 sin cambio | 27 | +3 | 0/14 | FIRME |
| A-05 | e1 jerarquía declarada una vez y expandida en build (CA-1, CA-3, CA-4, CA-9) | 33 | e2 jerarquía en ejecución / e3 roles planos | 25 | +8 | 0/14 | FIRME |
| A-06 | f1 cuatro niveles + punto de cumplimiento + pruebas negativas del producto (CA-3, CA-4) | 28 | f2 sólo controles de declaración | 26 | +2 | 0/14 | **CON REVISIÓN** |
| A-07 | g1 documento OpenAPI por exposición, UI sólo en desarrollo, ensanchar = H (CA-2, CA-3, CA-4) | 29 | g2 Swagger/Scalar detrás de auth | 24 | +5 | 0/14 | FIRME |
| A-08 | h1 tipo de alcance en el repo, valores en el producto (CA-2, CA-3, CA-9) | 31 | h2 valores en la tabla (H) | 21 | +10 | 0/14 | FIRME |
| A-09 | i1 una fuente; paquete instalable sólo `publico` (CA-2, CA-3, CA-4) | 31 | i2 paquete con `autenticado` (CA-6, CA-7, CA-9) | 27 | +4 | 0/14 | FIRME |
| A-10 | j1 filtro único para todos los canales (CA-7, CA-3, CA-4) | 28 | j2 sin canales para agentes en lo no público (CA-7 X2) | 28 | 0 | 7/14 | **CON REVISIÓN** |
| A-11 | k1 controles en dos carriles, en dos escalones (CA-6 + CA-3/CA-4) | 30 | k2 todo en una entrega | 26 | +4 | 0/14 | FIRME |
| A-12 | l1 D-18 «Audiencias y entrega»: registro fuente, matriz derivada (CA-1, CA-3, CA-5) | 29 | l2 D-18 tabla única con acceso (H, CA-4, CA-6) | 26 | +3 | 0/14 | FIRME |
| A-12b | m1 campo nuevo `audiencias` (entrega); `audience` queda de orientación (CA-3, CA-4) | 31 | m2 migrar `audience` a IDs (CA-1) | 24 | +7 | 0/14 | FIRME |
| A-13 | n2 Parte III con tres capítulos (CA-1, CA-5) | 27 | n1 cuatro capítulos (CA-6, CA-9) | 26 | +1 | 0/14 | **CON REVISIÓN** |
| A-14 | o1 re-sellar sólo casos con roles/superficies/API; criterio sin cambio (todas) | 29 | o3 D-18 fuera de la ronda 3 | 26 | +3 | 0/14 | FIRME |
| A-15 | p1 extender `PoC-R` (todas) | 31 | p2 ejemplo nuevo | 21 | +10 | 0/14 | FIRME |
| B-01 | q1 escalera de capas con vocabulario cerrado (CA-6, CA-8) | 30 | q2 guía en prosa | 26 | +4 | 0/14 | FIRME |
| B-02 | r1 números interpolados desde la regla; prosa escrita (todas) | 31 | r2 generar desde el esquema | 24 | +7 | 0/14 | FIRME |
| B-03 | s1 traza desde la ficha, anclas `muestra`/`valida` a la clave (CA-1, CA-4) | 30 | s2 catálogo YAML (CA-6, CA-8) / s3 `<comment>` (CA-9, H) | 26 | +4 | 0/14 | FIRME |
| B-04 | t1 canal «punto de uso» de `CL-06` (todas) | 33 | t3 código de interfaz fuera del sistema | 23 | +10 | 0/14 | FIRME |
| B-04b | u1 sección nueva de `TEM-05` (CA-8, CA-9) | 29 | u2 tema nuevo (CA-6) | 27 | +2 | 0/14 | **CON REVISIÓN** |
| B-05 | v1 anclas `muestra`/`valida` + campo con regla sin ayuda (CA-4, CA-1) | 31 | v3 sólo traza con versión | 29 | +2 | 0/14 | **CON REVISIÓN** |
| B-06 | w1 variante sólo si el texto cambia, con motivo; resuelta en servidor (CA-1, CA-5, CA-6, CA-8) | 30 | w2 variantes libres | 22 | +8 | 0/14 | FIRME |
| B-07 | x1 ID de contexto estable en el frontmatter + resolvedor en servidor (CA-1, CA-4, CA-6, CA-8, CA-9) | 32 | x2 archivo de mapa aparte (CA-2) | 29 | +3 | 0/14 | FIRME |
| B-08 | y1 plataforma sólo como canal que «dirige», fuera de lo normativo (CA-6, CA-9, CA-2) | 30 | y3 prohibirlas | 27 | +3 | 0/14 | FIRME |
| B-09 | z1 `aria-describedby` probado en pruebas de interfaz; `DG` sólo exige etiqueta y error (CA-8, CA-9) | 28 | z2 sólo guía | 25 | +3 | 0/14 | FIRME |
| B-10 | aa3 nada obligatorio (agregado de la presidencia) | 29 | aa1 regla condicional de asistente (CA-7) | 28 | +1 | 0/14 | **CON REVISIÓN** |
| B-11 | bb1 anotaciones + `[Display]` + `.resx` + localizador por audiencia en servidor (CA-4, CA-8, CA-9) | 31 | bb2 FluentValidation como fuente | 24 | +7 | 0/14 | FIRME |
| B-12 | cc1 formulario en `PoC-R` extendida (CA-1, CA-2, CA-3, CA-4, CA-6, CA-9) | 29 | cc2 en la mini demo (CA-8) | 28 | +1 | 0/14 | **CON REVISIÓN** |

Resultado: **22 FIRME y 7 CON REVISIÓN** (A-06, A-10, A-13, B-04b, B-05, B-10, B-12). La única inversión con
±10 % es A-10, que ya es empate.

## 3. Eje A, pregunta por pregunta

### A-01 Definición y término — FIRME (+8)

| Alt. | Qué es | Origen | V | CI | S | C | SEG | COM | PE |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| a1 | «Audiencia» = categoría de lectores para la que se escribe (ISO/IEC/IEEE 26514, 3.1.7, adaptada, según `F310` §4); aparte, **regla de entrega**: quién recibe, con qué nivel y dónde se hace cumplir | CA-1, CA-5; CA-2 («exposición») y CA-3 («orientación/acceso») por la forma | 5 | 4 | 4 | 4 | 5 | 5 | 4 |
| a2 | Audiencia como conjunto de atributos que incluye el acceso | CA-9 `F376` §4; hipótesis `F300` §6.1 | 3 | 3 | 4 | 4 | 2 | 3 | 4 |

Observables: SEG de a2 = 2 porque CA-3 (`F330` CA3-01) muestra que un campo de orientación leído como control
«parece» proteger y se publica igual (CWE-200); COM de a1 = 5 porque formaliza los dos planos que el cuerpo ya
tiene (`audience` vs `roles`, `F350` H-02). **Recomendación:** a1. Glosario: Audiencia, Regla de entrega, Lector,
Audiencia invocada, *Persona* («explica, no filtra»), Rol («coordenada de la audiencia»), Actor (≠ audiencia).
El nombre del segundo plano: «regla de entrega» (dos comisiones); «exposición» queda como término de la API (A-07).

### A-02 Dimensiones — FIRME (+4)

b1 (dos planos): **orientación** = tarea y experiencia (ISO 26514 6.2.2–6.2.3 y DITA `@job`, según `F310`),
pericia opcional y marcada como agregado (`F350` H-08), lector humano/agente; **entrega** = rol, alcance (tipo),
superficie, nivel de acceso; **derivadas**: jerarquía (inclusión entre roles), punto de cumplimiento (nivel ×
superficie), canal (superficie × lector), idioma (de la sesión; nunca amplía acceso, `F330` §4).
Obligatoriedad: nivel, siempre; rol, si hay más de uno; alcance, si un mismo rol administra cosas distintas;
superficie, si hay más de una. b2 (fila plana) pierde en V/CI/SEG: mezcla lo que protege con lo que orienta.

### A-03 Relación con rol, persona y escenario — FIRME (+5)

c1, unánime en las nueve comisiones: decisión nueva; la fila «Audiencias» de `SDEI/00-Marco.md` §2.5 pasa a
«Audiencias típicas» (valor por defecto, como las clases activas) y **«agente» sale de esa fila** a la dimensión
lector (`F370` §4). La audiencia se inventaría desde el inventario de autorización de D-01. c2 (ampliar D-01/D-13)
cuesta menos pero no cubre E-04/E-05 (filtro de pedido).

### A-04 Doble audiencia — FIRME (+3)

d1: el lector humano/agente es dimensión de orientación y canal, **nunca de acceso** (`F330` CA3-04; `F370` §1);
`TEM-04` sigue como tema propio (canales para agentes, anti-inyección) con nombre nuevo. d2 (absorberlo en el
capítulo de audiencias, CA-2) pierde COM: el contenido de `TEM-04` §3.4 no cabe en una dimensión. d3 (no tocar)
deja el término ambiguo (`F350` H-04). **Nombre del tema y del capítulo:** tres propuestas («Canales para personas
y agentes», «Lectura por agentes», «Lectores humanos y agentes»); no lo puntúo: va al jurado (§6, D-1).

### A-05 Jerarquía de privilegio — FIRME (+8)

e1: la jerarquía se declara una vez en el registro (`incluye`/`hereda`), el build la **expande** a listas
explícitas, el servidor compara conjuntos; herencia vertical, no horizontal (el raíz no hereda alcances,
`F330` §4); enlace hacia arriba = rojo, hacia abajo = verde; **ampliar la jerarquía es H con reserva**
(`F330` CA3-10). e2 (evaluar herencia en ejecución) agrega lógica en el punto de cumplimiento; e3 (roles planos
repetidos) obliga a editar páginas al sumar un nivel (`F310` H08).

### A-06 Acceso frente a visibilidad — CON REVISIÓN (+2)

| Alt. | Qué es | V | CI | S | C | SEG | COM | PE |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| f1 | Niveles `publico` · `producto` · `restringido` · `interno`, cada uno con punto de cumplimiento (build · servidor · servidor/portal con concesión de una persona · build y repo privado); 404 indistinguible; cabeceras de caché privadas; prueba negativa audiencia × canal × pieza en el carril del producto, más controles de declaración en `DG` (CA-3 §4, CA-4 §6.4) | 5 | 4 | 3 | 3 | 5 | 4 | 4 |
| f2 | Sólo controles de declaración en `DG` | 3 | 4 | 4 | 4 | 2 | 5 | 4 |
| f3 | Delegar en el RBAC de un portal comercial | 3 | 2 | 3 | 2 | 3 | 2 | 3 |

Gana f1 por 2 puntos: no alcanza R-06. **Condición comprobable:** f1 pasa a firme si, en `PoC-R` extendida, la
prueba negativa (CA-4 C-AUD-3 / CA-3 PP-1) da **rojo al quitar el filtro del *middleware* y verde al reponerlo**,
y la de caché (PP-3) da rojo con la respuesta actual (CA-3 midió hoy la falta de `Cache-Control` y `Vary`,
`F330` §7, sondas 1 y 5). Si la prueba no corre en el carril del producto, rige f1 con la prueba en carril
programado (salida que propone CA-4 §7.1). Nota: f2 sola repite el «control declarado y no ejercido» (`F330` §5.5).

### A-07 Documentación de API restringida — FIRME (+5)

g1: un documento OpenAPI **por exposición**, generado en el build; lo restringido servido sólo con política o por
portal con grupos; interfaz interactiva sólo en desarrollo; control «endpoint sin grupo» porque un endpoint sin
nombre de grupo entra en todos los documentos (verificado hoy, §9 [ML-OA]); marca de exposición por operación y
por esquema con inclusión monótona (`F320` CA2-C1/C2). **Clase de decisión:** H, de una persona, para que exista
documentación restringida y para quién, **y H por cada cambio que ensancha** (CA-2 CA2-C2b, CA-3 CA3-10); angostar
es P con aviso en el `CHANGELOG`. La decisión H se escribe con las tres respuestas de CA-3 CA3-09 (qué se
restringe, qué ya es público por el paquete, qué control del servidor protege cada operación): restringir la
documentación no protege la API. g2 (Swagger/Scalar detrás de autorización en producción) pierde SEG y CI; g3
(portal comercial como fuente) pierde CI y COM.

### A-08 Alcance por inquilino o aplicación — FIRME (+10)

h1: en el repo sólo el **tipo** de alcance (`global` · `por-aplicacion` · `propio`); los valores son datos del
producto (escribirlos en el repo es divulgación, `F330` CA3-05); contenido **genérico** (sin alcance) vs
**instanciado** (plantilla que el servidor llena con la misma autorización que el dato, `F320` A-08). El cruce de
alcance en ejecución es **prueba del producto** (CA-2, CA-3 PP-2); en `DG`, sólo el control de literales de
inquilino, **en aviso** (tiene falsos positivos, `F330` AC-6). Discrepancia: CA-9 lo quiere bloqueante
(`F376` `scope-cross`) → §6, D-3.

### A-09 Varias superficies — FIRME (+4)

i1: una fuente, salidas por superficie; **lo que viaja en un paquete instalable es `publico`**; lo demás se pide al
servidor con sesión y se guarda en caché no respaldada (`F340` §8). i2 admite `autenticado` sin rol en el paquete
(CA-6, CA-7, CA-9): pierde SEG porque el paquete se desempaca sin autenticar (`F330` CA3-06; `F340` §1.4).
El segundo servicio del paquete del PO es **otra superficie del mismo producto**, no otro escenario (`F320` A-09).

### A-10 Agente por audiencia — CON REVISIÓN (empate, 7/14 inversiones)

| Alt. | Qué es | V | CI | S | C | SEG | COM | PE |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| j1 | Filtro único en el servidor para HTML, `.md`, `llms.txt`, búsqueda, MCP y asistente; `llms.txt` por audiencia (por sesión si no es público); asistente con el token del usuario; índices filtrados antes de buscar (CA-7 §3) | 5 | 4 | 3 | 3 | 5 | 4 | 4 |
| j2 | Sin canales para agentes en lo no público (CA-7 X2) | 3 | 5 | 5 | 5 | 5 | 2 | 3 |
| j3 | Audiencia «agente» con acceso propio (lo que sugiere hoy la fila del Marco) | 1 | 3 | 4 | 4 | 1 | 2 | 3 |

j3 queda descartada por SEG (OWASP LLM06 y la regla de Copilot citadas por `F370` §1; no reabiertas por mí:
**sin verificar** por AD-B). Entre j1 y j2 hay empate: j1 es lo que `PoC-R` ya hace por rol (COM), j2 es más
simple. **Recomendación:** j1 como regla cuando hay canal para agentes, y j2 como opción declarada
(`canal_agente: ninguno`) en D-12/D-18. `llms.txt` no es control de acceso (verificado hoy: la propuesta no trata
autenticación, §9 [LLMS]). **Condición comprobable:** firme si el control de equivalencia de canales (`F370` AG-3:
para cada audiencia, piezas de HTML = `.md` = `llms.txt`) corre con su par en `PoC-R` extendida.

### A-11 Controles en CI — FIRME (+4)

k1 (dos carriles, dos escalones). **Escalón 1** en `DG`, una pieza o un control cada uno: vocabulario de
audiencias (página sin `audiencias` o con ID fuera del registro = rojo, *deny by default*); cruce de entrega con
jerarquía expandida (porta el validador de `PoC-R`); índice sin fuga (`llms.txt`, mapa del sitio, búsqueda);
paquete sin fuga; contexto resuelve. **Escalón 2:** anclas a recursos (`.resx`/JSON Schema), campo con regla sin
ayuda (aviso), traducción atrasada (aviso), y en el **carril del producto** la matriz de entrega negativa, caché,
cruce de alcance en ejecución, endpoint sin grupo, UI de API en producción, asistente. **Guarda de merge:**
ampliación de acceso → reserva H (G4). k2 (todo junto) pierde S y C; k3 (sólo `DG`) pierde SEG: prueba
declaraciones, no entrega (`F330` §5.5). Los nombres de control difieren entre comisiones (C-AUD-n, AC-n, AG-n,
CA2-Cn, `mt-*`, `ctx-*`): se unifican en `TEM-06` con un solo prefijo (§6, D-6).

### A-12 Ficha A-01 y oráculos — FIRME (+3) y A-12b — FIRME (+7)

l1: **D-18 «Audiencias y entrega»** con un **registro de audiencias** como artefacto (fuente única del acceso) y
la vista «matriz audiencia × pieza» **derivada** (clase D), no escrita a mano (`F330` §5.2). D-13 suma «en el punto
de uso» y remite a D-18; D-01 inventaría también *claims* de alcance, documentos OpenAPI, grupos y recursos
empaquetados (`F340` §9); D-12 remite a la regla de A-10. l2 (tabla única con acceso como columna) pierde SEG por
las dos fuentes del acceso; l3 (sólo D-13) no cubre la API, que no es ayuda (`F340` A-12).

m1 sobre el campo: **`audiencias`** (entrega, la lee el servidor) es campo nuevo; `audience` queda de orientación
y lo heredado avisa; `reader` se separa de `audience` con valor por defecto «ambos». m2 (migrar `audience` en los
283 archivos que contó CA-1) cuesta un PR grande en un repositorio con varias sesiones conviviendo
(`F310` §8 R5). Oráculos: §7.4.

### A-13 Libro — CON REVISIÓN (+1)

n2: Parte III «Audiencias y canales» con 7 «Audiencias» (nuevo), 8 tema de lectores/agentes (ex-7), 9 «Ayuda al
usuario final: páginas y punto de uso» (ex-8). n1 separa 10 «Ayuda en el punto de uso: pantallas, campos y
portales». n3 suma un capítulo de API por exposición (CA-2, CA-4). **Regla que propongo:** el libro sigue al cuerpo
—un capítulo por tema, como el lote L3 de `F099` §5.2 (caps. 7–8 = `TEM-04`, `TEM-05`)—, así que el número de
capítulos lo decide B-04b. **Condición comprobable:** si `TEM-05` absorbe el punto de uso (B-04b u1), n2; si se
escribe tema nuevo, n1. La API restringida va como sección de 7 (exposición) y caso en cap. 18, no capítulo
propio, salvo que el jurado acepte n3. Partes IV–VI corren 1 o 2 números.

### A-14 Ensayos — FIRME (+3)

o1: los oráculos de los casos cuyo repositorio tiene más de un rol, alcance, superficie o documento OpenAPI llevan
fila D-18 (y la de no-fuga por `llms.txt` de CA-7 y la de microtexto de CA-8, si el jurado las acepta) y **se
re-sellan**; *n*, umbrales y criterio de caso de `F204` **no cambian**. Por O-4 (`F204` §7) un oráculo sólo se
corrige por error: esto no es corrección sino **versión nueva por decisión nueva**, con huella nueva en el folio
de la ronda 3. o3 (dejar D-18 fuera de la medición de la ronda 3) es barato, pero mide un conocimiento que ya no es
el vigente. o2 (re-sellar todos) re-sella sin motivo los casos sin roles. Qué casos: CA-4 señala C2 por la forma
de `{servicio-privado}` (`F340` §9); **los demás no los medí** y los mide la presidencia.

### A-15 Demo — FIRME (+10)

p1, unánime: extender `PoC-R` (ya sirve página, `.md`, `llms.txt`, `topic`, dos idiomas y 404 por rol). Suma:
tres roles en jerarquía, dos alcances, una salida empaquetada (cliente simulado; la app MAUI real, opcional por
*workloads* y runner Mac, `F340` A-15), una API con dos documentos (uno con política), las pruebas negativas, el
formulario de B-12, y la corrección de CA3-02 (caché) y CA3-03 («Visible para» no se muestra al lector).

## 4. Eje B, pregunta por pregunta

**Respuesta directa al PO (E-08 a E-10).** Sí: docs as code se integra con los formularios. Lo que se usa hoy en
la industria es una escalera de microtexto (etiqueta, pista, ayuda desplegable, mensaje de validación, enlace
contextual, recorrido, centro de ayuda), atada a la pantalla por un **identificador de contexto**; las plataformas
de adopción digital ponen ese contenido en su propio editor y segmentan por atributos que manda el cliente
(visibilidad, no acceso). Lo que este cuerpo aporta y la industria no trae: la **traza `ID@versión` del texto a la
regla** y un **rojo en el PR** cuando el número que promete la ayuda no es el que hace cumplir el código (el 60/80
de `RN-LOC-01`, `TEM-05:127-135`). Fuentes: §9 y los informes `F360`, `F374`, `F376`.

### B-01 Mecanismos — FIRME (+4)

q1: vocabulario cerrado de capas (fusión de CA-6 y CA-8): `etiqueta` · `pista` · `ayuda-ampliada` · `ejemplo` ·
`error.<regla>` · `resumen-error` · `descripcion-seccion` · `recorrido`. Reglas: etiqueta siempre visible; pista
de una oración, para la mayoría, sin enlaces; el marcador no reemplaza etiqueta ni pista; el error dice qué pasó y
cómo arreglarlo; lo que no cabe en una oración va al tema por ID de contexto (GOV.UK, verificado hoy §9 [GOVUK]).
En móvil, la pista es texto visible, no *tooltip* (`F376` S10). Avisos de estilo, no bloqueos.

### B-02 Fuente única — FIRME (+7)

r1, unánime: **los números se interpolan desde la regla; la prosa la escribe una persona** en la voz del usuario.
r2 (generar el texto desde `description` del esquema) choca con «derivar no es generar» (`TEM-05:44`) y deja el
texto en la voz del integrador (`F340` B-02). r3 (copia manual) es el estado en que nació el 60/80.

### B-03 Traza del texto de campo — FIRME (+4)

| Alt. | Qué es | Origen | V | CI | S | C | SEG | COM | PE |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| s1 | La traza va **de la ficha al texto**: filas `muestra`/`valida` de la ficha de la regla anclan la clave del `.resx` (o el puntero de JSON Schema) y afirman que contiene el parámetro, no el número | CA-1 §B-03, CA-4 §5 | 5 | 4 | 4 | 4 | 4 | 5 | 4 |
| s2 | Catálogo de microtexto (`doc_type: microtexto`) con traza por entrada; el build emite los recursos | CA-6 §5.3, CA-8 §B-03 | 5 | 5 | 2 | 2 | 5 | 4 | 3 |
| s3 | `<comment>trace: …</comment>` en el `.resx` | CA-9 B-11.2; hipótesis `F300` §6.5 | 3 | 3 | 5 | 5 | 3 | 3 | 4 |

s1 reusa el ancla de nivel 2 que ya dio rojo en la mini demo (`F340` §7.2). Falta una pieza de herramienta: el
resolvedor de `DG` por clave de `.resx` (expediente de herramienta). s2 es mejor en CI y SEG (audiencia por
entrada) pero suma `doc_type`, emisor y migración; s3 es frágil (las herramientas de traducción editan el
comentario, `F374` B-03). **Recomendación:** s1 por defecto; s2 como **opción de D-13** para proyectos con muchas
variantes por audiencia o idioma. D-13 queda: «microtexto: ninguno · en recursos sin traza (aviso) · anclado desde
la ficha · catálogo». Con s1, el «no se ancla» de D-13 (`K`, línea de D-13) se reemplaza.

### B-04 Clase de pieza — FIRME (+10); B-04b dónde se escribe en el cuerpo — CON REVISIÓN (+2)

t1, unánime: canal «punto de uso» de `CL-06`, no clase nueva; vive con el código de la interfaz (mismo PR que la
regla, D-05); su ancla es la ficha (B-03); su control, B-05; la tabla «Qué pide cada campo» de la página de ayuda
pasa a derivarse de la misma fuente (`F350` H-06). u1 (sección nueva de `TEM-05`) gana por COM; u2 (tema nuevo) por
V. **Condición comprobable:** si la sección redactada supera 200 líneas **[umbral de criterio propio]**, se separa
en tema nuevo y el libro pasa a n1 (A-13).

### B-05 Control de desfase — CON REVISIÓN (+2)

v1: filas `muestra`/`valida` (traza desfasada y valor que no contiene el parámetro) bloquean en lo nuevo; «campo con
regla sin ayuda» avisa hasta línea de base 0 (`F340` C-CAMPO-2); límite declarado: una regla escrita como `if` en un
servicio no se ve y la cubre la prueba Dado/Cuando/Entonces de la ficha (`F374` B-05). v3 (sólo traza con versión,
como `PR-5`) ya funciona; v2 (comparar números por reflexión, CA-9 `rule-text-drift`) es complemento del producto.
**Condición comprobable:** firme cuando `DG` resuelva un ancla `ruta.resx#Clave@SHA` y el par 60/80 trasladado dé
rojo/verde; hasta entonces rige v3 en `DG` y v2 en el carril del producto.

### B-06 Por audiencia y por idioma — FIRME (+8)

w1: una variante por audiencia sólo si el texto cambia y con la dimensión que la justifica (`varia_por`, CA-6);
**etiqueta y mensaje de error iguales para todas las audiencias** (la ayuda entre pares, `F350` B-06); el alcance
cambia **parámetros**, no texto (CA-8); la variante se elige en el servidor, nunca todas al cliente (`F330` §4);
traducción con huella de la fuente, control común a páginas y microtexto, **aviso**. Discrepancia menor con CA-6
(«el alcance cambia el texto») → resuelta por parámetro.

### B-07 Paneles y portales — FIRME (+3)

x1: el **ID de contexto** es el contrato pantalla↔ayuda: estable (`ctx.<unidad>.<pantalla>[.<campo>]`), renombre
sólo con alias; declarado en el frontmatter que `PoC-R` ya usa (`topic`); un resolvedor del servidor traduce
`ctx + audiencia + idioma → pieza` o 404; el enlace no se dibuja si la audiencia no alcanza (como
`AyudaContextual`); controles «contexto resuelve» (bloquea) y «contexto huérfano» (aviso). El portal de
desarrolladores es **otra superficie** con su propio punto de cumplimiento: el enlace profundo desde el panel no
transfiere permiso (`F376` B-07). Cada servicio del paquete publica su catálogo con prefijo de unidad. x2 (archivo
`_contexto.yaml` aparte, CA-2) agrega una pieza; x3 (*widget* por URL) no tiene traza.

### B-08 Plataformas de guía en producto — FIRME (+3)

y1: no son fuente de ayuda **normativa**; se admiten como canal que **dirige**, fuera del repo, con dos condiciones
verificables: sin números ni condiciones de una regla, y sólo para niveles `publico`/`producto`; se declaran como
ubicación externa vigilada por el carril programado. Ganan autoría sin despliegue, recorridos y analítica; pierden
PR, traza y versión, y segmentan con atributos que manda el cliente (Appcues `identify()`, `F376` S3): visibilidad,
no acceso. Recorridos con traza: biblioteca en código que toma el texto del mismo catálogo (`F360` B-08;
licencia a revisar). y3 (prohibir) pierde PE.

### B-09 Accesibilidad — FIRME (+3)

z1: pista y error asociados con `aria-describedby`; WCAG 2.2 3.3.2 (nivel A, verificado hoy §9 [WCAG]), 3.3.1 y
3.3.3, y la asociación programática por 1.3.1 (`F374` B-09). Se verifica en **pruebas de interfaz** (componente o
extremo a extremo), no en `DG`; `DG` sólo exige que todo campo con regla tenga etiqueta y entrada de error. MAUI:
texto visible y `SemanticProperties.Hint` igual a `Placeholder` en Android (`F340`, `F360` S-28).

### B-10 Agente que asiste en el formulario — CON REVISIÓN (+1)

aa3 (no exigir nada) gana por un punto porque B-10 es agregado de la presidencia (`F300` §3). **Recomendación:**
regla **condicional** (aa1) que rige sólo si el proyecto tiene asistente: usa la misma pieza filtrada por el
servidor con el token del usuario, cita `ID@versión`, **sugiere y no envía** (trifecta, `F370` B-10), y AI-1…AI-5
corren también sobre los recursos de microtexto. El campo `assistant_use` por pieza (CA-7) no lo adopto: agrega una
decisión H por pieza sin control que la use. **Condición comprobable:** pasa a regla general si en `PoC-R` se monta
un asistente y la prueba del marcador sembrado (`F330` PP-4) da rojo/verde.

### B-11 .NET — FIRME (+7)

bb1: modelo compartido con anotaciones y `[Display(Name, Prompt, Description, ResourceType)]` + `ErrorMessage…`
contra `.resx` con dueño documental; texto por audiencia con un localizador decorado (`Clave.{audiencia}` → `Clave`)
en el servidor; alcance por **autorización basada en recursos**; SSR para lo restringido; en MAUI/WebAssembly sólo
lo público en el ensamblado; OpenAPI por documento (A-07). FluentValidation (bb2) es alternativa admisible, no
norma.

### B-12 Demo — CON REVISIÓN (+1)

cc1: el formulario va en `PoC-R` extendida («Alta de aplicación», dos audiencias con máximos distintos, ficha con
versión, par rojo/verde al cambiar la constante y al escribir el número a mano en el recurso, `F340` B-12). cc2
(mini demo, CA-8) tiene a favor el 60/80 ya real. **Condición comprobable:** si el resolvedor `.resx` de `DG`
(B-05) no está antes del lote de `Examples/`, el par rojo/verde se hace en la mini demo contra el `maxLength` del
contrato OpenAPI, como propone CA-8.

## 5. La hipótesis de F300 §6 a la luz del tablero

| Punto de §6 | Lectura de AD-B | Por |
| --- | --- | --- |
| 1 Matriz con acceso en la fila | Enmendada: dos planos; acceso por regla de entrega; sin valores de alcance; lector no es acceso | A-01, A-02, A-08, A-10 |
| 2 Tabla versionada | Sí, como **registro** fuente; la matriz es vista derivada | A-12 |
| 3 Cruce de alcance en `DG` | Partido: cruce entre declaraciones en `DG`; cruce en ejecución, prueba del producto | A-08, A-11 |
| 4 Exposición de API como H | Sí, y también H por cada cambio que ensancha | A-07 |
| 5 Ayuda de campo como canal de `CL-06` | Sí; la traza **no** en el recurso sino desde la ficha | B-03, B-04 |

## 6. Discrepancias entre comisiones que van al jurado

| Id | Tema | Posiciones | Lectura de AD-B |
| --- | --- | --- | --- |
| D-1 | Nombre de `TEM-04` y del capítulo | CA-1, CA-5, CA-7 (tres nombres); CA-6 y CA-9 mantienen «Doble audiencia» | Sin puntuar; cualquier nombre que diga «lector», no «audiencia» |
| D-2 | Campo de entrega | CA-1/CA-5: `audience` pasa a IDs; CA-3/CA-4/CA-6: campo nuevo `audiencias` | m1 (campo nuevo), A-12b |
| D-3 | Control de alcance en `DG` | CA-9 bloquea; CA-3 avisa; CA-2 lo deja al producto | Aviso en `DG` + prueba del producto |
| D-4 | Paquete móvil | CA-2/CA-3/CA-4: sólo `publico`; CA-6/CA-7/CA-9 admiten `autenticado` | Sólo `publico` (A-09) |
| D-5 | Traza del microtexto | Ficha (CA-1, CA-4) · catálogo (CA-6, CA-8) · comentario del recurso (CA-9, hipótesis) | Ficha por defecto, catálogo como opción (B-03) |
| D-6 | Nombres de controles | Seis familias de prefijos distintas | Unificar en `TEM-06` con un prefijo |
| D-7 | Demo del eje B | `PoC-R` (seis comisiones) vs mini demo (CA-8) | `PoC-R`, con revisión (B-12) |
| D-8 | Capítulo de API | CA-2, CA-4 lo piden; los demás no | Sección, no capítulo (A-13) |
| D-9 | Pericia como dimensión | Sólo CA-5, marcada agregado | Opcional, no obligatoria |
| D-10 | Pesos de CA-4/CA-5/CA-6 | Usaron K1–K7 de `Como-Decidir`; esta silla usa los siete de la carta | Los tableros no se suman (R-06) |

## 7. Impacto: qué rehacer

### 7.1 Cuerpo SDEI

| Pieza | Cambio | Por |
| --- | --- | --- |
| `99-Anexos/Glosario.md` | Audiencia, Regla de entrega, Nivel de acceso, Punto de cumplimiento, Alcance, Superficie, Lector, *Persona*, Microtexto, Capa, ID de contexto; «Rol» y «Doble audiencia» remiten | A-01, B-01 |
| `99-Anexos/Esquema-Frontmatter-Y-Prefijos.md` | Campo `audiencias`; `reader`; `alcance` (tipo); `superficie`; formato `ctx.*` en `topic`; prefijo `AUD-` | A-12b, B-07 |
| `00-Marco.md` §2.5 | «Audiencias típicas»; «agente» sale a lector; Confidencialidad con niveles y regla del paquete; fila «Punto de uso» | A-03, A-09 |
| `00-Marco.md` §4 | Quién decide ampliar acceso (H); Desarrollo decide clave y ubicación del microtexto, no su letra | A-05, A-07, B-04 |
| `TEM-04` | Renombre (D-1); lector hereda la audiencia; filtro único; `llms.txt` no es control; MCP; AI-n sobre recursos | A-04, A-10, B-10 |
| `TEM-05` | `roles` → `audiencias`; jerarquía; alcance genérico/instanciado; superficies; sección «Ayuda en el punto de uso» (capas, ficha→clave, ID de contexto, accesibilidad, plataformas); la tabla «Qué pide cada campo» se deriva | A-05–A-09, B-01–B-09 |
| `TEM-06` | Controles del escalón 1 y 2 con prefijo único, condición de bloqueo y par; carril del producto exigido por la guarda | A-11, B-05 |
| `Examples/` | `PoC-R` extendida (A-15, B-12) | A-15 |
| `99-Anexos/Referencias.md` | Fuentes académicas de CA-5 e industria de CA-6/CA-8/CA-9, reverificadas al redactar | §9 |

### 7.2 Conocimiento `K` (1.3)

D-18 nueva «Audiencias y entrega» (registro, matriz derivada, exposición de API con su ficha H); D-01 inventario
ampliado; D-12 remite al filtro único y admite `canal_agente: ninguno`; D-13 suma «punto de uso» y las cuatro
opciones de microtexto, quita «no se ancla»; §2.3 «Audiencias típicas»; A-01 con sección de audiencias y
decisiones H; A-03 vocabulario `audiencias` cerrado al registro, `reader` aparte; D-10 con los controles nuevos
en «avisa» hasta que exista la herramienta.

### 7.3 Libro (`F099` §5.2)

1.5 «Dos audiencias» → «Audiencias, entrega y canales»; Parte III según A-13 (7 nuevo, 8, 9 y quizá 10);
cap. 3.2 con la fila reescrita; cap. 14 con `PoC-R` extendida; cap. 18 con normas (ISO 26514, DITA) y casos de
centros de ayuda segmentados y guía en producto; anexos A, C y G. El lote L3 crece y la redacción de la Parte III
sigue suspendida hasta `F399` (`F300` §10).

### 7.4 Ensayos

**Ronda 3 nueva: no.** La ronda 3 que ya está en preparación (`F204` §9.2) se sella con `K` 1.3 y con los
oráculos de los casos afectados re-sellados (versión nueva por decisión nueva, no corrección por O-4); fichas de
caso: se re-sellan sólo si citan D-01/D-13/D-18; *n*, umbrales y criterio de caso sin cambio. Las re-corridas de C0
con la 1.1 (`F204` §9.3) no se tocan.

## 8. Orden de PR

| # | PR | Contenido | Depende de |
| --- | --- | --- | --- |
| 1 | Cuerpo normativo (coherencia) | Glosario, Esquema, Marco, `TEM-04`, `TEM-05`, `TEM-06` con los controles declarados y su estado | `F399` |
| 2 | Herramienta (expediente propio) | `DG`: vocabulario, cruce de entrega, índice y paquete sin fuga, contexto resuelve; resolvedor `.resx`/JSON Schema; *fixtures* rojo/verde | 1 |
| 3 | Conocimiento `K` 1.3 | §7.2, citando las líneas del PR 1 | 1 |
| 4 | Sellos de la ronda 3 | Oráculos re-sellados, en el folio de la ronda 3 | 3 |
| 5 | `Examples/` | `PoC-R` extendida (sin esperar a 2 si se aplica la condición de B-12) | 1, idealmente 2 |
| 6 | Libro, lote L3 y renumeración | Parte III y capítulos afectados | 1, 5 |

La ronda 3 corre después del 4; no espera al 2 ni al 5.

## 9. Fuentes externas

Reabiertas por AD-B el 2026-11-02:

| Id | Fuente | Qué se comprobó |
| --- | --- | --- |
| [WCAG] | W3C, *Understanding SC 3.3.2: Labels or Instructions* (WCAG 2.2), https://www.w3.org/WAI/WCAG22/Understanding/labels-or-instructions.html | Nivel A; «Labels or instructions are provided when content requires user input» |
| [GOVUK] | GOV.UK Design System, *Text input*, https://design-system.service.gov.uk/components/text-input/ | Pista «relevant to the majority of users», una oración corta; «Do not include links within hint text»; «Do not use placeholder text in place of a label, or for hints or examples» |
| [ML-OA] | Microsoft Learn, *Generate OpenAPI documents* (ASP.NET Core, act. 2026-10-29), https://learn.microsoft.com/en-us/aspnet/core/fundamentals/openapi/aspnetcore-openapi | «The OpenAPI endpoint doesn't enable authorization checks by default»; `.RequireAuthorization(…)`; documentos para «Audiences, such as public and internal APIs»; por defecto incluye «endpoints without a group name» |
| [LLMS] | llmstxt.org, https://llmstxt.org/ | No trata autenticación ni control de acceso; el archivo puede ir en la raíz o en un subcamino |

Todo lo demás de industria, norma o academia que cita este folio viene de los informes, con la verificación que
cada uno declara; **AD-B no lo reabrió** y lo rotula **sin verificar por AD-B** (ISO 26514, DITA, NIST SP 800-162,
OWASP, Mintlify, Redocly, Backstage, Pendo, Appcues, Zendesk, MadCap Flare, Microsoft 365 Copilot, MAUI y las
referencias académicas de CA-5). Las que sus propias comisiones rotularon «sin verificar» (p. ej. Salesforce,
WalkMe, Intercom, Flare en `F376`) siguen así y no se usan como fundamento de una celda.

## 10. Lo no verificado e incidencias

- No se leyó `F380` ni la refutación. No se midió en repositorios; qué casos de la ronda 3 tienen roles lo mide la
  presidencia.
- Los puntajes son juicio de esta silla; la escala de §1 es **[criterio propio]**, como el umbral de 200 líneas de
  B-04b.
- Corte de energía previo a la redacción; la fecha del folio es 2026-11-02.
- Mensajes de otras sesiones durante la redacción: ninguno.
- Huellas (`sha256`) de `celdas.py` y `calc.py` en `{dir-de-trabajo}`: `25bd1a92…dcd40b3` y `38ea113c…ec2040`.

## 11. Barrido de lo privado

El servicio va como `{servicio-privado}` y el directorio como `{dir-de-trabajo}`; rutas de repositorio por alias.
Resultado esperado del barrido de nombres de máquina, rutas absolutas y nombre real del servicio: 0 coincidencias.
