| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-10-25 |
| Autor | Jurado de veredicto (ronda 2) |
| Corrige | — |

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-10-25 |
| Autor | Jurado de veredicto, ronda 2 |
| Corrige | — |

| Campo | Valor |
| --- | --- |
| Rol | Jurado de veredicto de la **ronda 2** (`Mesa` §3.5.4 y §3.5.5; paso 8 de `Mesa-De-Expertos-A-Pedido` §2.1). Vota; no diseña |
| Carta | `evidencia/027-carta-r2-jurado-veredicto.md` (guardada verbatim antes de empezar, con sus tres líneas de cabecera) |
| Norma | `<base de conocimiento>/Knowledges/Knowledge-Mesa-De-Expertos-A-Pedido.md` 3.1 |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | Cabecera y §0 (líneas 1–111). Por la fila «Sos el jurado (componés el panel o votás el veredicto)» del Mapa de carga: §2 (2.1, 2.2 con su subsección, 2.3), §3 (3.1 a 3.4), §4, §7 y §8 |
| Documentos cargados con versión | `Excepcion-A-Un-Conocimiento` 2.0, entero · `Cadena-De-Consecuencias` 2.0, entero · `Mesa` 1.0 (`Rules/Rule-Mesa.md`): §3.5.4, §3.5.5, §3.5.6 y §3.5.7, por remisión del texto de mi acto (la carta nombra §3.5.4, §3.5.5 y §3.5.7) · `Escalas-De-Juicio` 1.0: §3.1 a §3.4, por remisión (lectura P0–P3 y clase de ancla) · `Versionado-Producto-Integral` 2.0 (VPI), por respaldo, sólo las líneas que votan ítems: 225 (§2.6, rango hacia el servicio), 253 (§2.6, «Clasificar»), 290–291 (§2.8, sufijo y fase), 338–362 (§3.2, «Rige desde» y R13) · `Release-Y-Despliegue-Versionado` 2.0, por respaldo, sólo la línea 113 (invariante 1) · `Conformacion-Pull-Request-Automatico` 2.0, por respaldo, sólo las guardas G1 y G3 (líneas 126–128) |
| No cargados | Dossiers N1–N5 y relevamientos R1–R4: sus datos los tomo por los informes que los citan. De I1–I7 abrí sólo las líneas que verifico en §1.3. Informes de comisiones r1 (009–018): no los necesité fuera de lo que el folio 021 recoge |
| Insumos leídos | Pedido (evidencia 001 desde la línea 4); folios 003, 004, 005, 006, 007, 021 entero, 022 y 023; los once archivos `despacho/r2-*.md` (composición, ocho comisiones, refutador y análisis de decisiones), enteros; I0 líneas 1–120, 199–270 y 408–431; E01 `INFORME.md` líneas 262–270; el borrador del PO `Lab-Documentos/Concepts/Framework-Concept/Framework-APP.md`, líneas 1–60 y 85–106 (ver §1.4) |
| Medios propios | Lectura del árbol con `grep`, `sed`, `cat` y `ls`, sin dispositivo, sin compilar, sin fuentes externas nuevas, sin intermedios fuera del scratchpad, sin commits. Comandos y salidas en §1.3 |
| Rótulo | No nombra el repositorio privado de la app de referencia del PO, ni hosts, direcciones o series de dispositivos |

# Veredicto del jurado — ronda 2 del expediente 0001

## Índice

1. [Cómo vota este jurado](#1-cómo-vota-este-jurado)
2. [Votación de los hallazgos de la ronda 2](#2-votación-de-los-hallazgos-de-la-ronda-2)
3. [Rendimiento y dato para el criterio de corte](#3-rendimiento-y-dato-para-el-criterio-de-corte)
4. [Fichas de excepción](#4-fichas-de-excepción)
5. [Dictamen consolidado P1–P13](#5-dictamen-consolidado-p1p13)
6. [Lote para quien pidió](#6-lote-para-quien-pidió)
7. [Homogeneidad: por qué no es eco](#7-homogeneidad-por-qué-no-es-eco)
8. [Señales para la presidencia](#8-señales-para-la-presidencia)

---

## 1. Cómo vota este jurado

### 1.1 Funciones, rótulos y quórum declarado

Las cinco funciones de `Mesa` §3.5.4: **Evidencia** (¿el ancla sostiene el nivel?), **Impacto**, **Costo y beneficio**,
**Coherencia histórica** (¿reabre una decisión cerrada, contradice el veredicto r1 o lo aprobado en el folio 023?) y
**Riesgo e irreversibilidad**. Rótulos de la carta: `PROCEDE`, `NO PROCEDE`, `ARCHIVA`. Cada voto lleva una línea de
fundamento; donde el nivel votado difiere del declarado, se dice. El veto acotado del juez de riesgo no se usó.

**Quórum (R2-04).** Este folio lo escribe **un solo agente que aplica las cinco funciones**; no son cinco jueces
despachados por separado. `Mesa` §3.5.4 dice «Quórum de cinco. Con menos, no hay veredicto». No lo rodeo ni lo
oculto: lo **declaro**, como pide la alternativa que deja R2-04, y lo elevo como señal a la presidencia (§8), que es
quien compone el despacho. Para que el defecto pese menos que en r1: (a) el juez de evidencia **abrió** las anclas que
sostienen cifras o citas que pasan al dictamen (§1.3); (b) en los ítems disputados la función que decidió se nombra.

### 1.2 Lectura de los niveles

La del contrato y de la carta: **P0**, viola una restricción dura o hace imposible el objetivo; **P1**, el plan saldría
con retrabajo o lecturas divergentes entre implementadores o lectores de la guía; **P2**, pérdida acotada; **P3**,
claridad.

**Interpretativo** (dato para `Mesa` §3.5.7, con la definición de la carta: «cambian una decisión»): un procedente es
interpretativo si, aceptado, **cambia lo que una decisión P1–P13 manda construir, aceptar o rechazar** (agrega o
quita una regla, cambia la alternativa elegida o su criterio de aceptación). No lo es si sólo cambia un fundamento, un
nombre, un rótulo (NO VERIFICADO, criterio, lectura), una fuente, una condición de revisión o la forma de escribir la
guía sin cambiar lo que enseña a hacer.

### 1.3 Anclas que el juez de evidencia abrió

| Qué se verificó | Comando | Salida | Ítems que sostiene |
| --- | --- | --- | --- |
| La consulta del índice estaba en el camino crítico de la corrida que 021 cita como «sin bloquear» | `cat ~/fc-work/arq-e02r/evidencia/logcat-2-v1-relanzar.txt` | `t=944ms recuperar` → `t=1345ms actualizador: al día (v1)` → `t=1606ms hybridwebview-agregado` → `t=3692ms js-marca 'primer-render v1'` → `t=3749ms puente Listo` | `FOR` H-02, R2-04 |
| Ningún ensayo llamó `reportFullyDrawn` | `grep -rn reportFullyDrawn Ensayos/E01-…/ ~/fc-work/arq-e02r/src \| grep -v INFORME \| wc -l` | `0` | `FOR` H-02, `VER` H-01 |
| 021 no nombra Shiny ni AOT | `grep -ci shiny 021-…` · `grep -c AOT 021-…` | `0` · `0` | `VER` H-02, H-08; `ARQ` H-07; `SEG` H-04 |
| La familia empresarial baja pantallas y lógica | `sed -n 56,60p I6-…` | Power Apps canvas: «pantallas y fórmulas Power Fx»; SAP MDK: «páginas, acciones, reglas JS»; Salesforce: «diseños, LWC, configuración» | R2-02 |
| La industria OTA sí activa en sesión | `sed -n 66,70p; 80,81p I2-…` | «Capgo por defecto aplica cuando la app pasa a segundo plano»; «Capgo `always` aplica aun en uso activo» | R2-07 (corrige a `ARQ` H-02) |
| VPI: miembro nuevo en interfaz es mayor; rango con techo; sufijo marca fase; R13 rige desde `candidata`, antes en aviso | `grep -n` y `sed -n` sobre VPI 2.0 | l.253 «todo miembro nuevo en un tipo interfaz, es cambio mayor»; l.225 «Nunca un piso a secas»; l.290 «El sufijo de pre-release marca la fase»; l.343 «en una fase anterior la regla es recomendación y su compuerta corre en modo aviso»; l.362 R13 `candidata` | `ARQ` H-04, `DEV` H-03, R2-09, `FOR` H-08, R2-08 |
| Invariante 1 de releases | `grep -n 'construido una sola vez' Release-Y-Despliegue-Versionado.md` | l.113 «Inmutable, construido una sola vez desde un commit» | `DEV` H-07 |
| E01 no midió el arranque sin red ni AOT | `sed -n 262,270p E01/INFORME.md` | «Arranque del contenido sin red … NO VERIFICADO … no se cortó la red»; «Publicación con `wasm-tools` (AOT/relink) … NO VERIFICADO» | `REQ` H-01, `VER` H-02, `SEG` H-04 |

Las citas de Apple 2.5.19 y de Play *Permissions…* las abrieron por separado `SEG` (con huella) y el refutador
(WebFetch): dos aperturas independientes con el mismo texto. No las reabrí.

### 1.4 Lo que el juez de evidencia encontró al abrir la fuente de la premisa de P1

R2-01 y el análisis r2 (§3.1) sostienen que **ninguna frase de quien pidió** da la lectura (b) por su letra. Al abrir
las fuentes de intención, el juez de evidencia encontró una que **ninguna comisión, ni el refutador ni el análisis
citaron**: el borrador del PO, que el pedido manda leer como «una idea de aplicación» (evidencia 001, «Contexto») y
cuyo §1 el contrato ya usa como fuente del sujeto (folio 003, líneas 15–16):

- `Framework-APP.md:28`, §1 «Qué se quiere», ítem 2: «Si cambio esas pantallas, la app **se autoactualiza al
  arrancar**, sin pasar por la tienda.»
- `Framework-APP.md:86`, opción A: «Las páginas se escriben en Razor (**lo que quiero**)».
- `Framework-APP.md:101`: «**Recomendación inicial:** A … Si en la prueba de concepto el peso o el arranque del WASM no
  convencen, caer a B.»

Es **E2** (cita literal con archivo y línea) de la intención de quien pidió. No es un hallazgo de especialista y no
entra en ninguna cuenta: es el fundamento con que este jurado vota R2-01, `ANA` H-02 y el default de P1. Lo que R-15
(r1) objetó del borrador fue apoyar **celdas de evidencia técnica** en él; acá se usa como lo que es, el enunciado de lo
que el PO quiere.

---

## 2. Votación de los hallazgos de la ronda 2

Abreviaturas de los informes: `REQ`, `VER`, `LSC`, `ARQ`, `ANA`, `DEV`, `FOR`, `SEG`, `REF`. `021:n` = línea del
dictamen r1. «Int.» = interpretativo (§1.2): **S** sí, **N** no. «→» marca un nivel votado distinto del declarado.

### 2.1 Requisitos (`REQ`) — 10

| Id | Nivel | Voto | Int. | Fundamento |
| --- | --- | --- | --- | --- |
| H-01 | P1 | PROCEDE | S | E1 (`grep -c` → 0 en el OBJETIVO) + E2 F004/F005. El alcance de «sin red» es la app entera (F004), no sólo la encuesta; P11 suma la corrida con la red cortada como criterio de aceptación. Asentar la cláusula es acto de la presidencia (§8) |
| H-02 | P1 | PROCEDE | S | E2 sobre 021:409-421 y F006. Se resuelve con una sola regla de activación y la señal de rechazo nombrada (P2) |
| H-03 | P1 | PROCEDE | N | E2: la misma pieza se llama A (021) y C (F003, I0). Nombre único y tabla de equivalencias (premisas, P10) |
| H-04 | P1 | PROCEDE | S | E2 021:316-318. Se adopta la definición como entrada propia del índice (P1, P2) |
| H-05 | P1 | PROCEDE | S | E2 + ODK [6] (tipo de campo publicado no cambia). Regla de evolución en P13 y compuerta en P8 |
| H-06 | P1 | PROCEDE | S | E2 021:645. Detección por instantánea del contrato (P3, P8) |
| H-07 | P1 | PROCEDE | S | E2 021:520, 526 + ServiceNow [138]. Los pendientes sobreviven al cierre y al vencimiento (P4, P5) |
| H-08 | P2 | PROCEDE | S | E2 021:422, sin momento. Se fija: al ingresar o en el arranque en frío, nunca a mitad de sesión (P2, P4) |
| H-09 | P2 | PROCEDE | S | E2 021:887-888. Anuncio en el índice firmado con fecha y plazo de aviso (P13; valor en el lote) |
| H-10 | P2 | PROCEDE | N | E4 Cadena §2 paso 4 + E2 021:636 (N sin valor) + HECHO [104]. Condiciones de revisión comprobables (P1, P6, P7) |

### 2.2 Verificación (`VER`) — 10

| Id | Nivel | Voto | Int. | Fundamento |
| --- | --- | --- | --- | --- |
| H-01 | P1 | PROCEDE | S | E2 021:327 frente a F003:87 (el g42 es un MEDIO de la mesa). El g42 pasa a dispositivo de medida del laboratorio y la rama «gama más baja» sale; el soporte va al lote |
| H-02 | P1 | PROCEDE | S | HECHO [102] + E1 (§1.3: AOT 0 en 021; E01 l.264 NO VERIFICADO). Contenido sin AOT con comprobación (P1, P8) |
| H-03 | P1 | PROCEDE | S | Mismo defecto que `REQ` H-06, con fuentes primarias Expo y Capgo. P3, P8 |
| H-04 | P1 | PROCEDE | S | E2 021:398, 402, 455 + HECHO [34][106]. Estado terminal decidido (pantalla del cascarón) y probado (P2, P8) |
| H-05 | P1 | PROCEDE | S | E2 021:848 + HECHO `dotnet/maui#25784`, `#30847`. Capacidades sólo por el puente (P12) |
| H-06 | P2 | PROCEDE | S | Mismo defecto que `SEG` H-02, a menor nivel. Se resuelve con «declaración y uso en el mismo binario» (P12) |
| H-07 | P2 | PROCEDE | N | HECHO [104]: MAUI 10 sin soporte desde el 2027-05-11. Condición de revisión con fecha (P1, P7, P11) |
| H-08 | P2 | PROCEDE | N | E1 (§1.3). Tabla diferencial con Shiny en la guía; no cambia P2 |
| H-09 | P3 | PROCEDE | N | HECHO [103]. Riesgo sumado a P9 |
| H-10 | P2 | PROCEDE | N | E2 021:376 frente a F003:84. La condición de iOS pasa a eventos comprobables dentro del alcance (P1, P9) |

### 2.3 Lector sin contexto (`LSC`) — 10

| Id | Nivel | Voto | Int. | Fundamento |
| --- | --- | --- | --- | --- |
| H-01 | P1 | PROCEDE | N | E2 EV001:33 frente a 021:737. Se escriben las dos lecturas y se toma la que menos agrega, declarada (§0 renglón 1): sin experiencia en **esta técnica**. Es lo mismo que r1 votó en `ACA` H-01 y no aplicó (R2-12) |
| H-02 | P1 | PROCEDE | N | Mismo defecto que `REQ` H-03 |
| H-03 | P1 | PROCEDE | N | E2: «manifiesto» con tres referentes; el del PO (F004) es el que **no** viaja. Tres términos en el glosario (P10) |
| H-04 | P1 | PROCEDE | S | E2 021:751 frente a F003:29-30. La industria tiene un tema propio en la guía, atado a su requisito (P10) |
| H-05 | P2 | PROCEDE | N | E4 restricción dura «autocontenido y no delta» (F003:74). Las decisiones se escriben en la guía; las P-numbers son metadato del anexo |
| H-06 | P1 | PROCEDE | N | E2 021:348 frente a I0:64-65. Play pasa a «interpretación no verificada», al lado de Apple |
| H-07 | P2 | PROCEDE | N | E2 021:891 frente a I0:69-70. La guía da la regla vigente y por qué no es la de I0 |
| H-08 | P2 | PROCEDE | S | E2: F004 y F006 sin escenario. La guía suma dos escenarios (P10) |
| H-09 | P2 | PROCEDE | N | E2 021:737 frente a 021:798-802. Prerrequisitos separados en «traer» y «se enseña» |
| H-10 | P2 | PROCEDE | N | E2 021:802 frente a 021:682. La guía declara el emulador como camino admitido sólo con imagen de WebView ≥ 94 en host con KVM, NO VERIFICADO |

### 2.4 Arquitecto MAUI (`ARQ`) — 9

| Id | Nivel | Voto | Int. | Fundamento |
| --- | --- | --- | --- | --- |
| H-01 | P1 | PROCEDE | S | E2 021:316 + ODK [6]. Su dirección (mismo índice, dos clases) es la adoptada; el argumento que decide es el paso 4: el actualizador vive en el cascarón y separar después cuesta un release por tienda |
| H-02 | P1 | PROCEDE | S | Procede por la **univocidad**: dos reglas de activación y «punto seguro» sin lista cerrada. **Dos correcciones del juez de evidencia:** (1) «ninguna fuente leída activa a mitad de sesión» es falso (Capgo, I2:69 y 80-81, §1.3); (2) el E3 no muestra pérdida de rollback: con activación en caliente la marca queda puesta y el arranque siguiente vuelve a `previous`, igual que si la activación fuera en frío. Lo que decide F2 es una sola regla y la matriz del análisis (29 frente a 16) |
| H-03 | P1 | PROCEDE | S | E2 021:387, 396, 490 frente a 855-856. La ruta la lee el cascarón instalado: decidir ahora (Cadena §2 paso 4). Índice por canal y por mayor del puente |
| H-04 | P1 | PROCEDE | S | El defecto es real: 021 no dice qué es menor o mayor para el puente. **La dirección no se adopta tal cual**: con el contrato escrito como interfaces C#, declarar «miembro nuevo = menor» es no seguir VPI §2.6 (l.253) sin ficha (R2-09). Se adopta la de `DEV` H-03 y R2-09: el contrato es la tabla de métodos de `Call(sobre)` y el catálogo |
| H-05 | P1 | PROCEDE | S | E2 + E4 VPI §2.6 «Detectar». Detección adoptada en la forma de R2-08 (instantánea), no con generador y hash propios |
| H-06 | P1 | PROCEDE | S | Mismo defecto que `VER` H-05 |
| H-07 | P2 | PROCEDE | N | E1 (§1.3). Tabla diferencial con Shiny en la guía; no se adopta Shiny como dependencia (beta, I4 §2) |
| H-08 | P2 | PROCEDE | N | HECHO [104] + 021:479-480. Evento de revisión «un PR sube el mayor de MAUI» (P3) |
| H-09 | P2 | PROCEDE | S | E2 021:491 frente a 021:843 + Adaptive Cards [90]. `requires` lleva id y rango por capacidad (P3, P12) |

### 2.5 Analista de sistemas y decisiones (`ANA`) — 9

| Id | Nivel | Voto | Int. | Fundamento |
| --- | --- | --- | --- | --- |
| H-01 | P2 | PROCEDE | N | El defecto (021 da por fijo «un solo canal» sin origen) es real. **Su dirección no se adopta**: su matriz comparó el paquete único con dos líneas, no con «un índice, dos clases», que nadie había puntuado (R2-06; el análisis la puntúa 25 frente a 21) |
| H-02 | P1 | PROCEDE | N | E2: «vacía el requisito» (021:230) no resiste a I1. El fundamento se reescribe. **La decisión no cambia, y la pregunta (a)/(b) no va al lote tal como la formula**: el árbol la contesta (`Framework-APP.md:28`, §1.4). Lo que sí sale al lote es el criterio del propio PO, «si … no convencen, caer a B» (§6, ítem 1) |
| H-03 | P1 | PROCEDE | S | E2 + E3. Los bloqueos van al mismo punto que la activación (próximo arranque en frío o ingreso), nunca a mitad de una captura; rechazar una versión de contenido no rechaza las respuestas tomadas con ella. «O al terminar la encuesta» no se adopta: con F2 ese punto ya no existe |
| H-04 | P2 | PROCEDE | N | E2 F006 frente a 021:409-418. Se declara que «al iniciar» se cumple un inicio después de la descarga. **El login como punto de activación no se adopta**: suma una segunda regla, que es lo que F2 quita |
| H-05 | P1 | PROCEDE | S | Mismo defecto que `REQ` H-07; su cadena elige la reversible (retener) |
| H-06 | P1 | PROCEDE | S | Mismo defecto que `REQ` H-05, con Kobo [17] |
| H-07 | P3 | PROCEDE | N | E2 I0:240-242. Se escribe por qué P13.7 no es la regla de I0. **El envío oportunista no se adopta**: con F2 caería en el camino crítico del arranque, y con red lo hace la sincronización de P5 (análisis §3.10) |
| H-08 | P2 | **NO PROCEDE** | — | La pérdida que señala (la demo no ejercita F004) ya está declarada como tal en 021:529-530 («no ejecutado en la demo»), F004 entra como «alternativa a evaluar» (folio 004, «Efecto»), y la dirección suma un mecanismo de ingreso con costo «sin medir» por su propia cadena. Costo y beneficio: no se justifica. P10 le da a «al iniciar sesión» su escenario en la guía (`LSC` H-08) |
| H-09 | P2 | PROCEDE | N | E1 (`grep -c`). Mismo defecto que `REQ` H-03 |

### 2.6 Integración, versionado y pruebas (`DEV`) — 9

| Id | Nivel | Voto | Int. | Fundamento |
| --- | --- | --- | --- | --- |
| H-01 | P2 | PROCEDE | S | E2 F007 frente a 021:607. Dos formas de merge con el mismo control; sale «equipo chico» (P6) |
| H-02 | P1 | PROCEDE | S | E2 + E4 + HECHO Capgo/Expo releídas. Se adopta la detección; la forma, la de R2-08 (instantánea). Su contradicción interna (aviso en H-02, obligatoria en §3) se resuelve: bloquea, como prueba del producto (P6, P8) |
| H-03 | P1 | PROCEDE | S | E4 VPI l.253 + E2 021:474: con `Call(sobre)` la superficie C# no cambia. Clasificación declarada para la tabla de métodos, como hueco de VPI §2.6 sin apartarse de ella |
| H-04 | P1 | PROCEDE | N | E4 VPI §2.6: «sin quién lo revalide, la frase correcta es "compatible en teoría con"». **La corrección es el rótulo**, no subir la prueba a la compuerta: su costo (puente simulado generado) está sin medir y la regla de VPI se cumple rotulando (análisis §3.8, N2) |
| H-05 | P1 | PROCEDE | S | Mismo defecto que `REQ` H-05; compuerta de definiciones con rojo provocado (P8) |
| H-06 | P1 | PROCEDE | S | **E1 propio** (M2-2 rojo, M2-3 verde, M2-4 `NETSDK1178`). Revierte un descarte de 021 (l.872) con costo nulo: el Info.plist fuente se comprueba en el runner Linux |
| H-07 | P1 | PROCEDE | S | E4 RYD l.113 (abierta). Se adopta la parte (1), publicar sólo desde una etiqueta alcanzable desde `main`; la parte (2) sigue a N2, al tramo siguiente |
| H-08 | P2 | PROCEDE | S | HECHO [104] + OPINIÓN [114]. La cadena de herramientas es atributo del cascarón; su PR exige prueba en dispositivo `manual: con registro` (P6, P7) |
| H-09 | P3 | PROCEDE | N | E1 (WebFetch de Expo *Error recovery*). La cita de I0/I7 sobre «contenido nuevo contra cascarón viejo» no la sostiene Expo; se rotula criterio de I6 e I7 |

### 2.7 Formal (`FOR`) — 10

| Id | Nivel | Voto | Int. | Fundamento |
| --- | --- | --- | --- | --- |
| H-01 | P1 | PROCEDE | S | Mismo defecto que `VER` H-01, con el inventario de umbrales |
| H-02 | P1 | PROCEDE | S | **E1 reabierto por este jurado** (§1.3). Instrumento, condición y estadístico del umbral se fijan; la palabra TTFD sale mientras no se llame `reportFullyDrawn` (análisis §3.3, U2) |
| H-03 | P1 | PROCEDE | S | E2 + E3. Una sola regla de activación, lista cerrada, señal de rechazo y cota en arranques (P2). No se adopta la espera acotada: rompería el umbral (5 146–5 675 ms, su propia cadena) |
| H-04 | P2 | PROCEDE | S | E2 021:396, 400, 410, 412. `expires` y el intervalo de reanudación tienen valor (criterio del jurado, provisorio, al lote) |
| H-05 | P2 | PROCEDE | N | E4 RYD inv. 10 + E2 021:399. Unidad y consumidor de la retención declarados; «N» deja de nombrar cuatro cosas |
| H-06 | P1 | PROCEDE | S | E2 + E3. Retención de definiciones separada de la de paquetes; la limpieza nunca retira; plazo de aviso (P13) |
| H-07 | P1 | PROCEDE | S | E2 + E3. El roll-forward nunca baja la versión de una definición (P7, P13) |
| H-08 | P1 | PROCEDE | S | E4 VPI l.290 (abierta). El contenido no lleva pre-release en ningún canal (P7) |
| H-09 | P1 | PROCEDE | S | E2. `requires` con rango, un solo esquema de versión del catálogo, fuente y comando del número del WebView, y el piso de P2 rotulado política de soporte |
| H-10 | P1 | PROCEDE | S | Mismo defecto que `REQ` H-06 y `ARQ` H-05, desde los umbrales |

### 2.8 Seguridad del canal y tiendas (`SEG`) — 10

| Id | Nivel | Voto | Int. | Fundamento |
| --- | --- | --- | --- | --- |
| H-01 | P3 | PROCEDE | N | E2. La premisa de conformidad se reancla en EV001:21 |
| H-02 | P0 → **P1** | PROCEDE | S | Las citas son exactas (abiertas por `SEG` y por `REF`). Pero el texto de 021 **no manda** un permiso dormido: la semilla del release es «una versión completa» (021:402) y puede traer la función. Es lectura divergente (P1), no un mecanismo que la tienda prohíbe por sí (P0). Además la baja de la cuenta que cita, 2.5.19 la ata a esconder funciones (R2-05). Se adopta su dirección: declaración y uso en el mismo binario |
| H-03 | P1 | PROCEDE | S | E2 2.5.2 y 2.3.1(a), abiertas. La regla operativa se rotula lectura; las notas de revisión describen el canal; el consejo de Capgo se cita como lo que no se hace |
| H-04 | P1 | PROCEDE | S | Mismo defecto que `VER` H-02 |
| H-05 | P1 | PROCEDE | S | Mismo defecto que `ARQ` H-01, con el argumento de iOS: la definición sobrevive a apagar el `.wasm` |
| H-06 | P1 | PROCEDE | S | E1 (`grep` → 0) + E2 Play Data safety y Apple 2.3, abiertas. Campo «¿cambia los datos que se recogen o comparten?» en el PR y en la publicación de una definición |
| H-07 | P1 | PROCEDE | S | E2 4.7, 4.7.2, 4.7.3 abiertas; alcance NO VERIFICADO (se mantiene). Rama iOS de P12 condicionada, como diseño |
| H-08 | P1 | PROCEDE | S | E1 (`grep` → 0) + E2 021:390. Semántica de la reserva fijada en la forma R2 del análisis (§3.5): el cliente rechaza claves revocadas; publicar la revocación es diseño |
| H-09 | P1 | PROCEDE | S | E2 021:396, 400, 428. `expires` con valor y renovación por job sin revisor humano (X1) |
| H-10 | P2 | PROCEDE | S | E2 + HECHO Shorebird [29]. Lista firmada de versiones retiradas; es la señal de «rechazo» que P2 no nombraba |

### 2.9 Refutador (`REF`) — 12

| Id | Nivel | Voto | Int. | Fundamento |
| --- | --- | --- | --- | --- |
| R2-01 | P1 | PROCEDE | N | El fundamento r1 no sostiene la premisa. **Corrección del jurado:** la premisa no se funda sólo en la lectura extendida del renglón 3, sino en el literal del PO que nadie citó (`Framework-APP.md:28`, :86, :101; §1.4) |
| R2-02 | P1 | PROCEDE | N | E1 (§1.3, I6:56-60). La industria tiene práctica para (a) y para (b); la guía presenta las dos familias |
| R2-03 | P1 | PROCEDE | S | E2 sobre los ocho informes. El análisis repuntuó (A+datos 13, C-min 26). El precio entra a la guía y al lote; lo que sólo sirve a producción entra a la demo como diseño (P11) |
| R2-04 | P1 | PROCEDE | N | E4 `Mesa` §3.5.4 + E1 (§1.3). Este folio declara que no hay quórum (§1.1) y corrige la fila del umbral (`FOR` H-02) |
| R2-05 | P1 | PROCEDE | N | Reclasifica `SEG` H-02 de P0 a P1 con E2 y regla 1 de `Escalas-De-Juicio` §3.4. Lo hago mío (§2.8) |
| R2-06 | P1 | PROCEDE | S | Disenso sin pesar entre `ANA` y tres comisiones; decide el paso 4 de `ARQ`. Un índice, dos clases |
| R2-07 | P1 | PROCEDE | S | Una sola regla de activación. Su corrección de la afirmación de industria de `ARQ` H-02 la verifiqué (§1.3) |
| R2-08 | P1 | PROCEDE | S | La forma más chica que cumple VPI §2.6 «Detectar»: instantánea del contrato; bloquea con `main` protegido (folio 023) |
| R2-09 | P1 | PROCEDE | S | E4 VPI l.253. Contrato = tabla de métodos y catálogo, no interfaces C#; clasificación como hueco de VPI |
| R2-10 | P2 | PROCEDE | S | `expires` con valor y renovación sin revisor; revocación como diseño; retirados sí |
| R2-11 | P2 | PROCEDE | N | E4 Cadena §2 paso 2: la asimetría de retrabajo de `ANA` no está medida. El default de P1 se funda en el literal del PO, no en ella |
| R2-12 | P2 | PROCEDE | N | E2 021:197 frente a 021:737. El cuerpo de parches coteja cada `PROCEDE` de r1 contra el texto del dictamen (§8) |

---

## 3. Rendimiento y dato para el criterio de corte

| Especialista | Hallazgos | Procedentes | No procede | Archiva | Procedentes interpretativos |
| --- | --- | --- | --- | --- | --- |
| Requisitos | 10 | 10 | 0 | 0 | 8 |
| Verificación | 10 | 10 | 0 | 0 | 6 |
| Lector sin contexto | 10 | 10 | 0 | 0 | 2 |
| Arquitecto MAUI | 9 | 9 | 0 | 0 | 7 |
| Analista de sistemas y decisiones | 9 | 8 | 1 | 0 | 3 |
| Integración, versionado y pruebas | 9 | 9 | 0 | 0 | 7 |
| Formal | 10 | 10 | 0 | 0 | 9 |
| Seguridad del canal y tiendas | 10 | 10 | 0 | 0 | 9 |
| Refutador | 12 | 12 | 0 | 0 | 6 |
| **Total** | **89** | **88** | **1** | **0** | **57** |

- **Rendimiento:** 88 procedentes / 9 especialistas (ocho comisiones y el refutador; el análisis y el jurado no entran)
  = **9,8 por especialista** (r1: 11,7).
- **Ningún procedente queda en P0.** Reclasificado: `SEG` H-02, de P0 a P1.
- **Interpretativos: 57 de 88**, por hallazgo. Contados por decisión, los procedentes cambian **12 de las 13**
  decisiones (todas menos P9). Hay solapamiento: el mismo cambio lo traen varias comisiones (por ejemplo, la
  detección del contrato la traen cinco).
- **Dato para `Mesa` §3.5.7:** la ronda 2 **no** es una ronda sin hallazgos interpretativos. Con r1 y r2 con
  interpretativos, el criterio «dos rondas seguidas limpias» exige al menos dos rondas más (r3 y r4 limpias); con el
  techo de cuatro rondas, **la mesa no puede cerrar por criterio antes de r4**. Si cierra ahora, cierra **por
  decisión**, y se dice (§8).

---

## 4. Fichas de excepción

| Ficha | Voto | Fundamento |
| --- | --- | --- |
| **Fichas nuevas de la ronda 2** | **No hay** | Ninguna comisión presentó ficha (`REF` §6; análisis M-1, `ls despacho \| grep -i ficha` → sin salida). No hay ficha que votar ni camino de compromiso que juzgar |
| XC-1 (r1) | Cerrada; no se vota | El PO eligió C-1 (folio 023, ítem 2). La excepción decae; se cumple VPI §2.7, cláusula 2 |
| Propuestas que necesitarían ficha y no la traen | **Se cumple la convención** | (1) Contrato como interfaces C# con «miembro nuevo = menor» (`ARQ` H-04): contra VPI l.253; con la tabla de métodos de `Call(sobre)` no hace falta (R2-09). (2) Clave exacta derivada por hash como decisor (I0, I7): contra el rango de VPI §2.6; nadie la sostiene. (3) Leer VPI §3.2 como **mandato** de modo aviso para toda prueba del contrato: no; la instantánea bloquea como **prueba del producto** y la compuerta R13 de VPI sigue rotulada «aviso hasta `candidata`» en la tabla de gobierno, así que no hay excepción (análisis §3.8, G1) |

---

## 5. Dictamen consolidado P1–P13

Texto entero que rige. Reemplaza al §5 del folio 021. Lo aprobado por el PO en el folio 023 (P6 en I1 implantado, XC-1
= C-1, iOS como diseño sin ensayo, VPI rige con atribución a versiones exactas) entra tal cual; ningún hallazgo r2 lo
contradice con E1 o E2.

### 5.0 Premisas

| Premisa | Decisión vigente | Fundamento |
| --- | --- | --- |
| **Qué se actualiza** | Lectura (b): **las pantallas y su comportamiento, además de los datos**. Las dos lecturas quedan escritas: (a) sólo encuestas y datos, la forma de la familia de encuestas (I1); (b) pantallas y lógica, la forma de la familia empresarial (I6) y de las OTA (I2). Se retira «la lectura (a) vacía el requisito» (021:230) | Literal del PO: `Framework-APP.md:28` («Si cambio esas pantallas, la app se autoactualiza al arrancar, sin pasar por la tienda»), :86 («lo que quiero») y :101 (recomendación A); el pedido manda leer ese borrador como la idea (evidencia 001, «Contexto») y el contrato ya toma de su §1 el sujeto (F003:15-16). Refuerzo: la tabla diferencial contra el caso de referencia (018 §3.1; §0 renglón 3). La industria no decide entre (a) y (b) (R2-02) |
| **«Blazor híbrido»** | App .NET MAUI cuyas pantallas de negocio se escriben con componentes Razor y se sirven como Blazor WebAssembly en `HybridWebView`. El glosario separa «Blazor Hybrid» de Microsoft (`BlazorWebView`, compilado, no descargable) de esta forma, cada una con su «qué NO es» | Como r1; I4[3]; I0:41 |
| **Operación sin red** | Requisito del escenario: **la app instalada arranca, deja entrar y opera completa sin red** con lo último instalado o la semilla, y envía lo tomado al recuperar la red. Instrumento: corrida en el teléfono de medida con la red cortada (arranque en frío, toma, persistencia, envío al volver la red). Hasta correrla, **NO VERIFICADO** | F004 («operativas perfectamente sin internet»), F005; `REQ` H-01; E01 l.267 |
| **VPI rige** | Rige, en `fase: diseño` | Folio 023, ítem 4 |
| **Conformidad con las tiendas** | Condición de diseño: lo diseñado tiene que poder distribuirse por Play y App Store, aunque no se publique (publicar sigue fuera de alcance, F003:84) | EV001:21 (`SEG` H-01) |
| **Grado por plataforma** | Android: decidido con fuente y ensayo. iOS: decidido por fuente, **diseño sin ensayo, NO VERIFICADO** | Folio 023, ítem 3 |
| **Perfil del lector** | Dos lecturas de «sin experiencia»: en programación, o en esta técnica. Se toma **sin experiencia en esta técnica** (la que menos agrega), declarada: sabe C#/.NET básico y git; no conoce MAUI, Blazor WebAssembly, firma ni integración continua | §0 renglón 1; `LSC` H-01; `ACA` H-01 r1; R2-12 |
| **Nombre del modelo** | En la guía: «pantallas Blazor WebAssembly descargables más encuestas como datos». En el expediente se abrevia A+datos. Tabla de equivalencias en el anexo: contrato «híbrido (C)» = I0 «C» = 021 «A + datos»; descartadas: C de N1, C-min, C-full, B pura, A pura, D | `REQ` H-03, `LSC` H-02, `ANA` H-09 |

### P1 — Modelo de contenido actualizable (D-01) · **modificado**

**Decisión.**

- **Modelo:** pantallas Blazor WebAssembly descargables más encuestas como datos.
- **Pantallas:** páginas Razor compiladas a Blazor WebAssembly **sin AOT** (`RunAOTCompilation` falso o ausente; el
  empaquetador lo comprueba y la compuerta lo prueba con rojo provocado, P8), empaquetadas como contenido firmado,
  bajadas por el canal (P2) y servidas localmente por un único `HybridWebView` con `WebResourceRequested` (.NET 10).
  Habilitar AOT es una decisión con su propia revisión de conformidad, no una optimización.
- **Condiciones de E01 §7:** C-1 `HybridWebView` + `WebResourceRequested`, no `HybridRoot`; C-2 el paquete trae
  `_framework/hybridwebview.js` y `<base href="/">`; C-3 Android System WebView ≥ 94, con pantalla «actualizá el
  WebView»; C-4 archivos planos, sin `.br`/`.gz`.
- **Definición de la encuesta:** archivo de datos con `encuestaId` y `version` (entero monótono), publicado como
  **entrada propia de clase `definicion`** en el mismo índice firmado del canal (misma firma, misma cadena de
  verificación que el contenido), con `compatible-con-contenido: >=A.B.C <D.0.0` (forma de VPI §2.6), `sha256` y
  `size`. Corregir una encuesta publica **sólo** la definición, sin nueva versión de contenido. Las páginas Razor
  genéricas del contenido la dibujan. Se activa al empezar la próxima encuesta; la que está en curso termina con la
  suya (P13).
- **Pantallas propias del cascarón:** XAML (arranque, error, «sin contenido sano», «actualizá el WebView»,
  «actualizá la app»). `BlazorWebView` no se usa.
- **iOS:** piso del cascarón iOS 16.4 más comprobación de capacidad del motor antes de cargar el contenido; diseño sin
  ensayo (P9).
- **Umbral de arranque:**
  - Métrica: **tiempo al primer render del contenido (TPR)**: la marca JS `primer-render`, con reloj desde
    `Process.StartElapsedRealtime`. No se llama TTFD mientras no se llame `reportFullyDrawn`.
  - Condición: arranque en frío (`am force-stop` + `am start -W`), contenido instalado, consulta del índice fuera del
    camino crítico (N = 0, P2).
  - Dispositivo: el teléfono de medida del laboratorio (moto g42, MEDIOS del folio 003). El umbral vale en él; **no**
    es una declaración de soporte (el soporte va al lote).
  - Estadístico: el **máximo de 5 corridas** (criterio del jurado, conservador, provisorio hasta la medida de
    dispersión de `FOR` S-4).
  - **Umbral: ≤ 5 000 ms** (criterio del jurado anclado en Android vitals, que considera excesivo un arranque en frío
    de 5 s o más).
  - Estado: 3 692–4 871 ms medidos **con la consulta en el camino crítico** (E02-R; cota pesimista). La condición
    declarada: **sin medir**.
- **Función nueva de peso:** un contenido o una definición que cambie el propósito declarado en la ficha de tienda, o
  agregue un módulo visible que la ficha no describe, sale también por tienda. Lo decide quien aprueba el PR con el
  campo obligatorio de la plantilla. La regla se rotula **lectura** de DPLA 3.3.1(B) y de la industria; 2.5.2 se cita
  al pie de la letra («introduces or changes features or functionality»). Las notas de revisión describen el canal de
  contenido, el catálogo y el forzado (2.3.1(a)); el consejo de ocultar el canal (Capgo) se cita como lo que no se
  hace.
- **Orden de construcción:** primero el núcleo común a A+datos y C-min (canal firmado y actualizador, esquema y
  versión de la definición, P13, outbox y sincronización, entrada, procedimiento de PR); después el anfitrión
  `HybridWebView` y los mecanismos propios de bajar código. Así una respuesta del PO al ítem 1 del lote no tira
  trabajo (agregado del análisis, `[AG]`, adoptado por este jurado).
- **Precio que la guía declara:** unos 2 s más de primer render que C-min; 9,13 MB por versión retenida; WebView ≥ 94;
  iOS ≥ 16.4; `.wasm` NO VERIFICADO ante Apple **y ante Play** (ninguna política nombra WebAssembly; la lectura
  «intérprete» vale para IL sin AOT); y los diez grupos de mecanismos que existen sólo por bajar código (R2-03).

**Fundamento.** Premisa «Qué se actualiza» (literal del PO, §1.4). E01 §6.2, E02-R, E-SEG-1 (r1). HECHO [102]: sin
AOT, Blazor WASM corre en un intérprete de IL; Play «code that runs in a virtual machine or an interpreter», abierta por
`SEG`. Matriz del análisis r2 §3.1 (A+datos 13, C-min 26, B pura 17), que ordena pero no decide: decide la lectura del
PO (compuerta). Canal de la definición: análisis §3.2 (K2 25, K1 21, K3 18) y paso 4 de `ARQ` §3. Umbral: §1.3 de este
folio y análisis §3.3 (U2 27 frente a 23).

**Qué se descartó y por qué.** D, sitio remoto: sin red no opera (F005). C-min: pierde lo que el PO escribió que quiere
(pantallas actualizables, `Framework-APP.md:28`); queda como camino si el PO responde «no convence» (§6). B pura:
dominada por C-min en este escenario (análisis §3.1). A pura: ata la encuesta al código. C de N1: dos renderizadores.
K1, la definición dentro del paquete: cada corrección baja el paquete entero (3 395 072 B frente a 4 B de diferencia,
análisis M-4) y separar después cuesta un release por tienda. K3, dos líneas con índice propio: más piezas sin
beneficio sobre K2. AOT: cambia la clase del código descargado sin decisión.

**Condición de revisión.** Cualquiera de estos hechos: (1) el PO responde en el lote que el costo no convence → P1 pasa
a C-min sobre el núcleo común, con A documentada como extensión; (2) el TPR, máximo de 5 corridas en la condición
declarada, supera 5 000 ms en el teléfono de medida → se evalúa C-min con E02-B como base; (3) un PR cambia código
Razor sólo para corregir una encuesta → se revisa el esquema de la definición; (4) en las corridas de la compuerta de
la demo ninguna definición se publica sin contenido nuevo → se reevalúa K1; (5) cualquiera de los eventos de P9 →
se evalúa iOS; (6) 2027-05-11, fin de soporte de MAUI 10 → el cascarón sube de mayor por tienda y se re-verifica el
contrato.

### P2 — Canal de actualización (D-02) · **modificado**

**Decisión.**

**Servidor, índice y firma**

| Pieza | Decisión |
| --- | --- |
| Servidor | Estático y propio. **Un índice firmado por canal y por mayor del puente**, en ruta fija `/{canal}/puente-{mayor}/indice.json`; el cascarón lee el de su mayor. Cada canal (`dev`/`beta`/`prod`) es un índice distinto y el cliente rechaza el de otro canal |
| Entradas | Dos clases: `contenido` (código) y `definicion` (datos), cada una con `size` y `sha256`, aceptables por separado |
| Qué se firma | El índice, byte a byte, con `expires` y la lista `retiradas` (versiones de contenido retiradas) |
| Algoritmo | ECDSA P-256 con SHA-256, de la plataforma, sin dependencias |
| Claves | Conjunto embebido con `keyId`: la activa y una de reserva fuera de línea. El cliente **acepta sólo claves no revocadas**; una revocación firmada por la reserva retira la activa sin tienda. En la demo, el rechazo de una clave revocada es un rojo provocado de la suite; publicar una revocación se enseña como diseño, no implantado. Las dos comprometidas exigen cascarón nuevo, y se declara |
| `expires` | Vigencia del índice **30 días**, renovada por un job programado **cada 7 días** en el mismo *environment* protegido, sin revisor humano para la renovación (sí para publicar contenido). En la demo, la renueva su guion. Valores: criterio del jurado, provisorios, al lote |

**Verificación y activación en el cliente**

| Pieza | Decisión |
| --- | --- |
| Orden | Firma y clave no revocada → `expires` → versión estrictamente mayor que la instalada en ese canal (contenido) o en esa `encuestaId` (definición) → hash por archivo → descomprimir en `staging/` |
| Activación de contenido | **Una sola regla:** en el próximo arranque en frío, **antes de mostrar**, si la versión ya está bajada y verificada en `staging/`. Directorios inmutables `versions/vN` y `puntero.json` reemplazado con un solo `rename`. No hay activación en caliente. El borrado de versiones viejas va a la retención |
| Activación de definición | Al empezar la próxima encuesta (P1, P13) |
| Rollback local | Marca «pendiente» al activar, que el contenido borra con `Listo(version)`. Si el arranque siguiente la encuentra, vuelve a `previous` y anota la versión en una lista local de fallidas que no se reinstalan |
| Retiradas | Una versión de contenido que figura en `retiradas` se trata como fallida local en el próximo arranque en frío: se vuelve a `previous`, sin rebajar la monotonía de lo nuevo. Es la señal de «rechazo» |
| Estado terminal | Si no queda versión sana (`current` y `previous` fallidas o retiradas, o no hay `previous`): **pantalla propia del cascarón** «no hay contenido sano», con las versiones, que reintenta la descarga cuando hay red. Los pendientes no se tocan; la sincronización del outbox, que es del cascarón (P5), sigue. No se vuelve a la semilla |
| Rollback remoto | No existe como rebaja. Se corrige hacia adelante con versión mayor, o se retira la mala (`retiradas`). `rollBackToEmbedded` no entra |
| Retención | Servidor: **3 o más paquetes firmados de contenido por canal y por mayor, con sus índices**; los consumen la re-descarga de un `previous` perdido y la atribución de errores a versiones exactas (VPI; folio 023). Las definiciones se retienen aparte (P13). Teléfono: `current` + `previous` |
| Semilla | Una versión completa del contenido del release del cascarón, del mismo pipeline y firmada igual. No es destino de rollback |
| Transporte | Sólo HTTPS |

**Momento**

| Pieza | Decisión |
| --- | --- |
| Espera al abrir | **Ninguna** (N = 0): arranca lo instalado |
| Consulta | En segundo plano, con tres disparadores de una misma rutina: arranque en frío, login con cuenta exitoso y reanudación. La reanudación consulta sólo si pasaron **15 minutos** o más desde la última consulta exitosa (criterio del jurado; análogos: Shiny «at best every 15 minutes», SAP 20–25 min; al lote). El desbloqueo local no dispara nada que necesite red |
| Temporizador de rollback | No hay: el rollback es por marca |

**Forzado y bloqueos (F006)**

| Caso | Decisión |
| --- | --- |
| Contenido `mandatory` | Se activa con la regla general: en el próximo arranque en frío, antes de mostrar, ya verificado. **«Al iniciar» se cumple un inicio después de la descarga**, y la guía lo dice. Cota declarada: un arranque en frío desde que quedó verificado; sin cota en tiempo mientras el proceso viva (al lote) |
| Sin red | No se fuerza nada |
| Pendientes | Ningún forzado descarta, migra ni invalida pendientes, ni espera a vaciar el outbox (P13) |
| Versión de contenido retirada | Como «Retiradas» y «Estado terminal», arriba: nunca a mitad de una captura y nunca sin red |
| Cascarón bajo la versión mínima soportada | **Política de soporte**, no declaración de compatibilidad (fuera del alcance del rango de VPI §2.6). Se lee con el índice y se aplica **en el próximo arranque en frío o en el próximo ingreso con cuenta**, nunca a mitad de una captura; durante la sesión, sólo un aviso. Android desde Play: In-App Updates inmediato. APK fuera de Play: pantalla propia con enlace. iOS: pantalla de bloqueo y ficha de la App Store. Sin red no bloquea |

**Custodia de la clave.** Demo: clave de demostración generada por el guion en la máquina de quien corre la demo; no
se versiona ninguna clave privada; la compuerta del PR usa una clave de prueba. Producción: diseño, no implantado; la
firma de publicación corre en un job aparte con *environment* protegido y revisor obligatorio, y **sólo acepta
artefactos construidos desde una etiqueta alcanzable desde `main`** (P6). Clave de contenido y certificado de Apple son
secretos distintos con custodios distintos.

**La guía** lleva la tabla diferencial contra Shiny.AppDeviceBridge (transporte, piso frente a rango, rollback,
obligatoria antes de mostrar), rotulado «referencia documentada por el proveedor, no medida». Shiny no se adopta como
dependencia.

**Fundamento.** E-SEG-1 y TUF 1.0.37 §5.3 y §5.5 (r1); R2-07 y análisis §3.4 (F2 29, F3 18, F1 16, F4 15); análisis
§3.5 (X1 por el paso 4 frente a X3; R2 por el paso 4 frente a R0) y §3.6 (T1 por el paso 4 frente a T2); `ARQ` H-03 y
Expo Updates v1 [I2[5]]; `SEG` H-10 y Shorebird [29]; Expo `fallbackToCacheTimeout` 0 [34]; «bajar no es aplicar»
[21][35][50]; ServiceMax [140] y Oracle [142] para el ingreso; `FOR` H-03 a H-05.

**Qué se descartó y por qué.** Activación al terminar la encuesta (F1): segunda regla y lista abierta. Espera acotada
al abrir (F3): 5 146–5 675 ms, rompe el umbral de P1. Login como punto de activación: segunda regla. Volver a la
semilla como estado terminal (T2): puede no leer datos nuevos, irreversible para ellos. Sin `expires` (X3): congelamiento
sin cota, y agregarlo después exige tienda. Firma de vigencia separada (X2): más piezas. Aceptar cualquier clave (R0):
la reserva no protege del compromiso. TUF completo, Sigstore, sólo HTTPS + sha256, Ed25519, `IMMEDIATE`: como r1.

**Condición de revisión.** (1) La corrida en el teléfono de medida con dos versiones fallidas sin red muestra que la
semilla lee y escribe la base local sin pérdida → T2 pasa a opción. (2) El job de renovación falla y la base deja de
aceptar contenido antes de que se vea → se alarga la vigencia o se pasa a X2. (3) Una obligatoria tarda en llegar al
teléfono de medida más que la cota que fije el PO. (4) La suite no puede provocar el rojo «clave revocada» en el runner
→ se declara que compromiso = release del cascarón.

### P3 — Cascarón, puente y compatibilidad · **modificado**

**Decisión.**

- **Cascarón:** app MAUI con pantallas XAML, el actualizador, el servidor de contenido (`WebResourceRequested`), el
  puente, el catálogo de capacidades (P12) y un solo `HybridWebView`.
- **Puente:** un único método `Call(sobre)` registrado con `SetInvokeJavaScriptTarget`; sobre JSON-RPC 2.0 más `v`;
  eventos por `InvokeJavaScriptAsync`; al cargar, `bridge.handshake` (devuelve la versión del puente, el catálogo con la
  versión de cada entrada y, sólo para la pantalla de diagnóstico, la huella de `contrato.json`) y `Listo(version)`.
  El transporte (`hybridwebview.js`, `__hwvInvokeDotNet`) es parte del contrato y su dueño es el cascarón. Seguridad:
  el puente atiende sólo al origen local; navegación a otros orígenes bloqueada; CSP `default-src 'self'; script-src
  'self' 'wasm-unsafe-eval'`, `connect-src` acotado, `object-src 'none'`; el refresh token nunca cruza el puente.
- **El contrato es la tabla de métodos de `Call(sobre)`, el catálogo y el transporte**, no interfaces C# expuestas al
  contenido.
- **Clasificación del cambio del puente** (hueco de VPI §2.6 para este objeto, sin apartarse de ella): método nuevo,
  entrada nueva del catálogo o campo opcional nuevo en una respuesta → **menor**; método quitado, parámetro obligatorio
  nuevo, cambio de tipo o de forma de un sobre, o cambio del transporte → **mayor**.
- **Detección:** prueba de **instantánea**. La tabla de métodos (nombre, parámetros y respuesta), el catálogo (id y
  versión) y la identidad del transporte se serializan y se comparan con un `contrato.json` versionado: si difieren y
  la versión del puente no subió, rojo; si la versión subió y no difieren, rojo. Corre en `fw-ok` y **bloquea** (P6,
  P8), como prueba del producto; la compuerta R13 de VPI sigue rotulada «aviso hasta `candidata`» en la tabla de
  gobierno.
- **Compatibilidad:** un solo predicado, que el actualizador evalúa antes de activar:

  ```text
  puente ∈ compatible-con-puente: >=A.B.C <(A+1).0.0
    ∧ ∀ r ∈ requires: r.id ∈ catálogo ∧ versión(catálogo[r.id]) ∈ r.rango (>=X.Y.Z <(X+1).0.0)
    ∧ motor ≥ mínimo   (Android: mayor de la versión del proveedor de WebView activo ≥ 94; iOS: 16.4 y capacidad)
  ```

  La forma del rango es la canónica de VPI §2.6. El piso declarado por un paquete se rotula **«compatible en teoría
  con»** mientras ninguna prueba lo revalide (VPI §2.6). `minShellVersion` sale del teléfono; el piso del cascarón de
  P2 es política de soporte. El número del WebView se lee con `adb shell dumpsys webviewupdate` (proveedor activo y
  versión); el comando lo verifica quien aplica antes de escribirlo en la guía (NO VERIFICADO en este expediente).
- **Lo opcional** lo resuelve el `handshake`.

**Fundamento.** R2-08, R2-09, `DEV` H-03, `ARQ` H-04/H-05/H-09, `FOR` H-09/H-10, `REQ` H-06, `VER` H-03; VPI l.225 y
l.253; Expo `fingerprint` [38] y Capgo `--fail-on-incompatible` [46] (la lección: la clave no queda suelta del código);
Adaptive Cards `requires` [90]; análisis §3.7 (D1 27, D3 24, D2 18; D1 por el paso 4).

**Qué se descartó y por qué.** Clave exacta derivada por hash como decisor: contra VPI §2.6 sin contradicción que
funde una ficha, y rompe el ingreso de capacidades en dos pasos (P12). Interfaces C# con «miembro nuevo = menor»:
excepción sin ficha. Generador más hash propio (D2): misma cobertura que la instantánea con tres piezas más. Constante a
mano sin detección (D3): falla documentada [58] y un paquete incompatible publicado es irreversible para quien lo bajó.
`handshake` como único decisor: detecta tarde.

**Condición de revisión.** (1) Un rojo provocado con un contrato cambiado y la versión sin subir no falla con la
instantánea → se reevalúa, y la clave exacta sólo con ficha. (2) Un PR sube el mayor de MAUI del cascarón → la
instantánea compara el transporte y, si cambió, sube el mayor del puente y se publica el índice del mayor nuevo con su
semilla. (3) En los rojos provocados, una de las dimensiones del predicado nunca rechaza un paquete → se quita.

### P4 — Entrada del usuario y qué entra en la demo (D-03, D-07) · **modificado**

**Decisión para el framework.**

| Pieza | Decisión |
| --- | --- |
| Entrada local y sesión | Separadas. Entrar es el desbloqueo local; la sesión con el servidor es el token. La renovación corre en segundo plano y no bloquea la entrada. Las acciones `Encolable` esperan en el outbox hasta que haya sesión válida. Sin período de gracia local: sin red se opera sin límite; al vencer la sesión, se vuelve a ingresar con red antes de sincronizar |
| Primer ingreso | OIDC con *authorization code* + PKCE en el navegador del sistema (RFC 8252) |
| Desbloqueo local | Android: Keystore con `setUserAuthenticationParameters` (API ≥ 30). iOS: Keychain con `userPresence`; LocalAuthentication para rostro |
| D-03 | T1. Sin bloqueo de pantalla, o con API < 30, el desbloqueo local no se ofrece |
| D-07 | I1: cualquier emisor OIDC; Keycloak en contenedor para ensayar |
| Outbox y cierre de sesión | Cada fila tiene dueño. **Cerrar sesión o vencer la sesión no borra filas pendientes**: quedan con su dueño, invisibles para otra identidad, y salen cuando el mismo dueño vuelve a autenticarse con red. Borrarlas es un acto explícito del dueño, con confirmación que dice cuántas se pierden. Nunca se envía con otra identidad |
| Versión mínima del cascarón | Se evalúa **al ingresar** y en el arranque en frío; durante la sesión, sólo aviso (P2) |
| Tiendas | Cuenta de demostración para la revisión; si la cuenta se crea en la app, borrado de cuenta en la app y por la web |

**Decisión para la demo.** Sin IdP: la sesión por dispositivo del caso base. Login, desbloqueo y el disparador «al
iniciar sesión» van a la guía, con escenario propio (P10), rotulados «no ejecutado en la demo».

**Fundamento.** r1 (`ASD` H-04/H-05, `SEG` P4, R-11); `REQ` H-07/H-08, `ANA` H-05; ServiceNow Zurich [138] (pérdida de
caché al vencer); ServiceMax [140] y Oracle [142] (cascarón al ingresar); CommCare [21] y D365 FS [128] (login como
momento de consulta). Cadena de `ANA` P4: retener es reversible, borrar no.

**Qué se descartó y por qué.** F1 del borrador; T2; T3; I2; I3; demo con Keycloak (como r1). Borrar la base al cerrar
sesión: pérdida irreversible de datos de campo. Ingreso de dispositivo por QR en la demo (`ANA` H-08): no procede (§2.5).

**Condición de revisión.** El ensayo E-N2-1 cierra en verde en el teléfono de medida por un camino de red que la guía
pueda enseñar → el login entra a la demo como etapa opcional.

### P5 — Datos locales y trabajo sin red (D-04, D-05) · **modificado**

**Decisión.**

| Pieza | Decisión |
| --- | --- |
| Propiedad del esquema | El cascarón es dueño de sus tablas (outbox, registro de red, versión de contenido, definiciones con respuestas, configuración). El contenido no hace DDL: guarda documentos JSON en una tabla genérica (colección, id, versión de forma, json) por la API acotada del puente. Una actualización de contenido nunca necesita migración ni release del cascarón |
| D-05 | S2: EF Core SQLite 10.0.11 para las tablas del cascarón, detrás de `IDb` |
| Migraciones | **C-1 de XC-1, aprobado por el PO (folio 023):** sobre de columnas estables; cláusula 2 de VPI §2.7 cumplida (el binario exige su número y no arranca si no coincide); cláusulas 1, 3 y 4 cumplidas; `fase: diseño`. La migración al abrir no se implementa |
| Datos del contenido | Cada documento lleva su versión de forma; lector tolerante; el rollback no revierte datos |
| Outbox | Fila escrita en la misma transacción que el cambio local; clave de idempotencia única; dueño; desde que se encola, acción, versión del payload, versión de contenido y `{encuestaId, versionDefinicion}`. La reclasificación del índice no se aplica a lo ya encolado. **Sobrevive al cierre y al vencimiento de la sesión** (P4) |
| Orden | Por entidad. Una fila en `Rechazado` o `Error` suspende sólo a sus dependientes; la carta muerta se muestra al usuario |
| D-04 | C2: versión + 412, con «último gana» declarado por acción |
| Sincronización | Envía el outbox cada vez que hay red y sesión válida, sin depender del momento de la actualización (P13.6 y P13.7) |

**Fundamento.** E-ASD-1 y E-AD-1 (E1, r1); Android *Build an offline-first app*; Survey123 [28]; D365 [127]; SAP
`ErrorArchive` [130]; `ANA` §3 P5 y `VER` §1.2 (la investigación no contradice ninguna fila); folio 023 ítem 2.

**Qué se descartó y por qué.** S1 como principal (queda como caída); «conservar EF porque el caso base lo usa» como
restricción; migrar al abrir (C-2 de XC-1, no elegido por el PO); recrear el almacén (3 → 0 pendientes); orden global;
C1 «último gana siempre»; C3 CRDT.

**Condición de revisión.** El primer build iOS en Release falla por EF Core con trimming → S1 o S3 detrás de `IDb`. Un
PR cambia la constante de esquema exigido → ese PR trae su decisión sobre el sobre, con C-1 vigente.

### P6 — Procedimiento de PR e integración · **modificado**

**Decisión.**

1. **T1 implantado** (folio 023): protección de `main` de `hdcm-dev/Lab-Documentos` con PR obligatorio, **un único**
   check requerido `fw-ok`, modo estricto y «Do not allow bypassing the above settings». Prueba de implantación: el
   parche M-13 en un PR, con la captura del botón de fusionar deshabilitado.
2. **Un solo workflow de PR**, sin `paths` en el `on:`; el alcance a `Demo/**` lo decide un paso del job.
3. **Agregador `fw-ok` estricto:** `skipped` cuenta como rojo, salvo una lista declarada de omisiones legítimas con
   motivo. **Toda suite que entra a `fw-ok` bloquea**, incluidas la instantánea del contrato y la compuerta de
   definiciones (P8).
4. **Runner** `runs-on: [self-hosted, i7infra-dev]` con guarda de mismo repositorio, aprobación de forks para todos los
   colaboradores externos, `permissions: contents: read` y ningún secreto en los jobs de PR (folio 023, ítem 1).
5. **Merge:** dos formas con un mismo control. Manual por defecto (Conformacion-Pull-Request-Manual 2.0: lo hace
   alguien que no escribió el cambio). Automática sólo con delegación asentada (como el folio 007 para los PR de esta
   corrida), con las guardas G1–G4 de Conformacion-Pull-Request-Automatico 2.0 y `fw-ok` como la corrida que G3
   exige. La guía cita el PR de la demo como ejemplo de la segunda.
6. **Plantilla de PR** con la unidad declarada, «qué sigue después del merge», el campo «¿cambia el propósito
   declarado en la ficha de tienda?» (P1) y el campo «¿cambia los datos que se recogen o comparten?»; si es sí, la
   declaración de la tienda (Data safety, privacidad de App Store Connect) se actualiza antes de promover a `prod`.
7. **Publicación del contenido:** el paquete se construye sólo desde una etiqueta alcanzable desde `main`
   (Release-Y-Despliegue-Versionado, invariante 1) y el job de firma no acepta otro artefacto.
8. **PR de la cadena de herramientas:** un PR que cambia `global.json`, `workloadVersion` o `MauiVersion` exige, antes
   de fusionar, una prueba en dispositivo `manual: con registro` (VPI §3.2), y la instantánea en rojo si cambió el
   transporte.

**Fundamento.** Folio 023; E1 de `DEV` r1 (M-1 a M-13); GitHub *About protected branches* y *Secure use reference*;
F007 y `DEV` H-01; R2-08 y análisis §3.8 (G1 28, G2 21); RYD l.113; `DEV` H-08; `SEG` H-06 con Play Data safety y Apple
2.3.

**Qué se descartó y por qué.** A sin protección; C rulesets; E repositorio privado; I3 repositorio nuevo (como r1).
Detección en modo aviso (G2): un contrato cambiado pasaría en verde a `main` protegido. «Equipo chico» como motivo:
sin frase de quien pidió.

**Condición de revisión.** (1) La API de corridas muestra PR de `Guides/` bloqueados por `fw-ok` sin tocar `Demo/**` →
falla el filtro por paso. (2) **En un mes calendario, 3 o más PR con `fw-ok` en verde pasan a rojo al actualizarse con
`main` en modo estricto** → se evalúa la merge queue (criterio del jurado; reemplaza «más de N PR por día»).

### P7 — Líneas de versión · **modificado**

**Decisión.**

| Línea | Gramática | Fuente única | Relación y regla de orden |
| --- | --- | --- | --- |
| Cascarón | `ApplicationDisplayVersion` = `MAYOR.MENOR.PARCHE` sin sufijo; `ApplicationVersion` = entero monótono | Un archivo de propiedades | Implementa un mayor del puente. **Atributo:** la cadena de herramientas (SDK, `workloadVersion`, `MauiVersion`), con condición de revisión 2027-05-11 |
| Puente | SemVer 2.0.0; el mayor es la identidad del contrato, transporte incluido | `contrato.json` y la constante del cascarón, atadas por la instantánea (P3) | Lo consume el contenido con rango con techo; clasificación de P3 |
| Contenido | SemVer 2.0.0 con `+<commit>`, **sin pre-release en ningún canal** (la madurez la da el canal); clase «paquete» | El proyecto del contenido | Anti-rollback por precedencia SemVer sin metadatos; la identidad no se reutiliza |
| Definición de encuesta | `encuestaId` + `version` entero monótono | El archivo de la definición | Declara `compatible-con-contenido` con techo; entrada propia del índice; **el roll-forward nunca baja su versión**: revertir su contenido es publicar una versión nueva |
| Catálogo de capacidades | Una versión **por entrada** | Constante del cascarón | Agregar una entrada es menor del puente; su forma, en `requires` con rango (P3) |
| Esquema del cascarón | Entero monótono (VPI §2.7) | El cascarón | Lo exige el binario (P5) |
| Paquetes NuGet, si los hay | Un mismo número para todos | Un archivo de propiedades | Independientes del cascarón de la demo |
| Fase | `diseño`, en `versionado/rutas.json` | — | Fija qué reglas rigen |

El canal es un puntero que promueve el mismo artefacto, no una línea. La huella de `contrato.json` es dato de
diagnóstico, no línea. Las versiones de cascarón, puente, contenido, definición y la huella se ven en la pantalla de
diagnóstico, para atribuir errores a versiones exactas (folio 023, ítem 4).

**Fundamento.** r1 (`DEV` P7, `REQ` H-07, VPI §2.6–§2.8); folio 023; `FOR` H-07/H-08 (VPI l.290); `DEV` H-08; `ARQ`
H-04/H-09; HECHO [104]; ODK [6][7].

**Qué se descartó y por qué.** Número único; piso `minShellVersion`; fecha como versión de contenido (r1). Pre-release
en el contenido: promoverlo a `prod` pone al producto en `candidata` por VPI §2.8. Huella como línea: no ordena.

**Condición de revisión.** Se declara la fase `candidata` → rigen los tramos siguientes. 2027-05-11, fin de soporte de
MAUI 10.

### P8 — Qué se prueba en cada capa y qué es compuerta · **modificado**

**Decisión: compuerta mínima obligatoria del PR**, todo en `[self-hosted, i7infra-dev]`, detrás de `fw-ok` estricto.

| Capa | ¿Compuerta? | Rojo provocado que se entrega |
| --- | --- | --- |
| Build de la solución sin el proyecto MAUI, avisos como error | Sí | Un aviso promovido a error |
| Unitarias de dominio y ViewModels (`net10.0`) | Sí | El parche M-13, nunca el M-12 |
| Unitarias del actualizador: diez casos de N4 §3.6; C02–C08 de E-SEG-1; corte provocado en cada paso de la activación; el predicado de P3 (incluye `requires` con rango); reglas de P13; **clave revocada; índice vencido; versión retirada; doble falla sin red → estado terminal** | Sí | Cada caso visto en rojo contra el código de E01 antes de darse por cumplido |
| **Instantánea del contrato** (P3) | Sí | Cambiar la forma de un método sin subir la versión del puente |
| **Definiciones:** válidas contra su esquema; si cambiaron respecto de la base del PR, `version` estrictamente mayor; sin borrado ni cambio de tipo de un campo publicado | Sí | Editar una pregunta sin subir `version` |
| **Catálogo frente a AndroidManifest e Info.plist fuente** (claves `NS*UsageDescription`) | Sí | Una capacidad del catálogo sin su permiso o su clave de uso (M2-2 de `DEV`) |
| **Contenido:** sin AOT, y sin uso de API web del WebView que pidan permisos (geolocalización, `getUserMedia`, `capture`) | Sí | Un paquete con `RunAOTCompilation=true`; un contenido que llama `navigator.geolocation` |
| APK del cascarón y empaquetado del contenido | Sí | Un error de compilación |
| Componentes Razor (bUnit), contrato con Playwright y puente simulado, contenido sobre el piso declarado, renderizado de la definición con el motor mínimo | **Tramo siguiente** | — |
| Dispositivo Android | No: manual al etiquetar y en PR de cadena de herramientas (P6), con logcat y captura versionados, «k de n» | — |
| Emulador | No: sólo con imagen de WebView ≥ 94 en un host con KVM fuera del runner | — |
| iOS | No. **Queda afuera, una por una:** build `net10.0-ios` (`NETSDK1178`, M2-4), Info.plist combinado, firma y perfil, API pública del marco iOS, ejecución en WebKit | — |

- El tramo siguiente entra cuando se publica el primer paquete de contenido fuera de la demo, o se declara la fase
  `candidata`, lo que ocurra primero.
- Las pruebas intermitentes van a cuarentena con expediente, no a reintentos.
- Cada suite obligatoria entra con su rojo provocado medido (VPI §3.4, T2).
- «Probar el contenido nuevo contra el cascarón viejo» se rotula **criterio de I6 e I7**; Expo *Error recovery* se cita
  sólo para el staging que emula el estado del dispositivo (`DEV` H-09).

**Fundamento.** r1 (R-13; `DEV` H-05/H-06/H-08; `VER` H-03/H-05/H-07/H-08); `DEV` H-02/H-05/H-06 (E1 M2-2 a M2-4);
`VER` H-02/H-04/H-05; `SEG` H-04/H-08/H-09/H-10; R2-08; análisis §3.7–§3.8.

**Qué se descartó y por qué.** Siete capas obligatorias desde el primer PR; emulador en el PR (sin KVM); dispositivo en
el PR; cobertura mínima como compuerta (r1). Contenido sobre el piso en la compuerta ahora (`DEV` H-04): costo sin
medir; el piso se rotula «compatible en teoría con» (P3).

**Condición de revisión.** La de entrada del tramo siguiente. El primer contenido que use un método ausente en su piso
declarado y llegue al `handshake` en una corrida de la demo → la prueba de nombres de método contra el piso (N3 del
análisis) entra a la compuerta.

### P9 — iOS (D-06) · **confirmado**

**Decisión: no se compila iOS, y se declara** (aprobado por el PO, folio 023, ítem 3).

- Todo iOS sale en la guía y en el procedimiento de PR como **«diseño sin ensayo, NO VERIFICADO», sin compuerta**, sin
  job `macos-*`.
- Documentado, sin ejecutar: origen `app://0.0.0.1/` interceptable por esquema propio; ECDSA P-256 soportado; piso iOS
  16.4.
- Riesgos nombrados: `.wasm` frente a 2.5.2 y DPLA 3.3.1(B); el puente frente a 4.7.2 y el consentimiento por
  instancia de 4.7.3 (rama iOS de P12); funciones latentes (2.5.19) y divulgación en las notas de revisión (2.3.1(a));
  la semilla frente a 4.2.3(ii), mitigado con la semilla completa; EF Core con trimming; **memoria del runtime WASM en
  WKWebView** (`EmccMaximumHeapSize`, Microsoft Learn [103]); AOT (P1).

**Fundamento.** Folio 023; Microsoft, *Build an iOS app on macOS with .NET CLI*; F003:88; `VER` H-09; `SEG` H-03/H-07.

**Qué se descartó y por qué.** Mac propia; afirmar iOS como decidido (EV001, «toda afirmación … evidencia verificable»).

**Condición de revisión.** Cualquiera de estos hechos: se asienta una cuenta de Apple Developer con su custodia; hay un
`run_id` de un job `macos-*` verde que produce el `.ipa`; hay una corrida en un iPhone con captura equivalente a la
corrida 3 de E01; se asienta una respuesta de App Review o de Apple sobre 4.7 para contenido propio.

### P10 — Estructura de la guía · **modificado**

**Decisión: O3-m-r.**

- **Perfil del lector** (premisas): sin experiencia en esta técnica; sabe C#/.NET básico y git; no conoce MAUI, Blazor
  WebAssembly, firma ni integración continua; las dos lecturas y la elegida, declaradas en `Developer-Guide.md`.
- **Criterio de aceptación:** un clon limpio, siguiendo sólo la guía, llega al inicio rápido.
- **Prerrequisitos medidos**, separados en «lo que el lector trae» (C#/.NET, git) y «lo que la guía enseña» (contenedores,
  depuración USB y opciones de desarrollador, generar la clave de demostración); dispositivo con WebView ≥ 94 y su
  comando; el emulador, admitido sólo con imagen de WebView ≥ 94 en host con KVM, NO VERIFICADO.

| Pieza | Qué lleva |
| --- | --- |
| `Developer-Guide.md` | Único índice (rol `GUIA-INDICE`): resumen, prerrequisitos, «Cómo usar esta guía» (aprender, hacerlo ahora, evaluar), ruta de lectura en Mermaid, plataformas verificadas. `README.md` sólo remite a él |
| `00-Marco-de-Referencia/` | **Siete escenarios:** primer arranque; actualización con fallo y rollback; contenido incompatible o capacidad faltante; sin red (la encuesta de F005 con P13); PR y release; **actualizar al iniciar sesión (F004)**; **actualización obligatoria (F006)**, estos dos con «no ejecutado en la demo» donde corresponda. Contextos y actores (encuestador, coordinador que publica, servidor) |
| `01-Mapa-Conceptual/` | — |
| `05-Inicio-Rapido/` | La demo terminada muestra v1 → v2 al reabrir |
| `10-Tutorial/` | Un concepto nuevo por etapa, cada paso con un resultado visible |
| `20-` a `60-` | Temas: cada uno responde a una decisión de este dictamen, **escrita en el texto del tema**; la referencia P1–P13 es metadato del anexo. Aplicación por escenario en una tabla por tema; «no aplica» en una celda con su motivo. **Un tema propio «Qué existe en la industria y por qué el framework no lo usa»**, atado al requisito de basarse en la industria (F003:29-30): las dos familias (encuestas en campo; empresariales y OTA), qué cuesta cada una (el precio de R2-03), la tabla diferencial contra Shiny.AppDeviceBridge y el retiro de CodePush |
| `70-Como-Hacer/` | — |
| `99-Anexos/` | Glosario con «Blazor Hybrid» frente a «Blazor WebAssembly en `HybridWebView`», cascarón, contenido, **índice del canal**, **manifiesto del paquete de contenido**, **manifiesto de la app** (AndroidManifest/Info.plist, el que sólo cambia por tienda), canal, compuerta y runner, cada uno con su «qué NO es». Tabla de equivalencias de nombres del modelo. Referencias, sólo las leídas. Mapa guía↔demo. Pendientes, con los NO VERIFICADO (**Apple y Play** frente a `.wasm`; iOS; arranque sin red; TPR en la condición declarada) |

- **Contenido obligatorio:** toda salida es «salida registrada» con SDK, workload y pack; tensiones nombradas por
  documento; la etiqueta `i7infra-dev` explicada como dato del entorno; la tabla diferencial caso base → demo; el
  costo medido de A; por qué P13.7 no es la regla «sincronizar primero» de I0 (criterio del sintetizador, ninguna
  plataforma la documenta); cada regla con su historia de falla con fuente cuando la haya (I0:424).
- **Borrador `Framework-APP.md`:** no se edita (es del PO); se exceptúa por nombre en el verificador; la guía lo cita
  como antecedente y como origen de «qué se quiere».

**Fundamento.** r1 (`ACA` P10, `LSC` P10, R-14, Diátaxis, análisis r1); `LSC` H-01 a H-10; `REQ` H-03; restricción dura
«autocontenido y no delta» (F003:74).

**Qué se descartó y por qué.** O1, O2, O3 completa (r1). La regla «o sale» sin lugar para la industria: deja el
requisito F003:30 fuera de lo que lee el destinatario. Nombrar el modelo por letra.

**Condición de revisión.** El verificador V-03 exige un tema que no responde a ninguna decisión → se agrega con su
motivo; el tema de industria, si V-03 encuentra que no responde a nada que la guía decide, se funde en «Qué se
descartó» de P1.

### P11 — Alcance mínimo de la demo, cómo se corre y dónde vive su workflow · **modificado**

**Alcance mínimo (M2, sobre el modelo de P1).**

- **Base:** el caso base portado a páginas Razor servidas como contenido; se conservan dominio, reglas
  (`EncuestaRules`, `LocalidadRules`) y pruebas de ViewModels, copiadas y no referidas, con mapa archivo por archivo.
- **Orden de construcción:** núcleo común primero (P1).
- **Encuesta de tres pasos como definición versionada, entrada propia del índice:** v1 → v2 tomada al empezar la
  próxima encuesta; contenido v1 → v2 al reabrir; semilla completa; paquete con firma inválida rechazado; contenido
  que no avisa «arranqué» vuelve a `previous`.
- **Un PR en rojo** con el parche M-13 en `i7infra-dev`, y su equivalente local en rojo en la máquina del lector.
- **Una encuesta tomada sin red**, enviada por el outbox con idempotencia a un **receptor didáctico** dentro de `Demo/`
  (doble de prueba: deduplica por clave y compara versión con `If-Match`). Una encuesta tomada con la definición v1 y
  sincronizada después de llegar v2 (P13).
- **Lo que sólo sirve a producción** entra como **diseño, no implantado**: publicar una revocación, la firma de
  producción con revisor. En la demo, `expires` lo renueva el guion.
- **Fuera del mínimo:** login, desbloqueo y cámara (P4).

**Cómo se corre (C3).** Receta de contenedor versionada en `Demo/`, copiada con su cierre de dependencias, sin imágenes
locales ni `dev.sh`; `global.json` con SDK y `workloadVersion`, `MauiVersion` en un archivo de propiedades; un guion
único que compila, sirve el contenido e instala; dispositivo con WebView ≥ 94 comprobado por comando; **un solo camino
de red**, medido antes de escribirlo; el túnel público queda excluido; candidato: el reenvío inverso de puertos del
canal de depuración, **NO VERIFICADO**.

**Dónde vive el workflow (W2).** `.github/workflows/` en la raíz de `hdcm-dev/Lab-Documentos`, con el alcance a
`Concepts/Framework-Concept/Demo/**` decidido por un paso del job; la guía cita el YAML. `fw-ok` es **check requerido**
de `main` protegido (folio 023, ítem 1).

**Criterio de aceptación.** (1) Una corrida real del workflow, con su `run_id` y sus jobs en `i7infra-runner-dev`
(API `actions/runs/{id}/jobs`); (2) la demo corrida desde un clon limpio siguiendo sólo la guía; (3) **la corrida con la
red cortada** en el teléfono de medida: arranque en frío con el contenido instalado, toma de una encuesta, persistencia
y envío al volver la red.

**Fundamento.** r1 (`ASD` P11, R-11, `ACA` P11, `LSC` H-04/H-05/H-11, `DEV` P11, `VER` H-09, `REQ` H-04/H-10, F005);
folio 023; `REQ` H-01; R2-03; análisis §3.1, punto 2.

**Qué se descartó y por qué.** W1, W3, los cuatro hechos de `ACA`, M2 con login, C1, C2 (r1). Implantar revocación y
firma de producción en la demo: costo de producción para un lector principiante (R2-10).

**Condición de revisión.** La demo pasa a un repositorio propio → el YAML se muda con ella. La medición del camino de
red falla → se mide otro antes de escribir la etapa.

### P12 — Capacidades del dispositivo y el manifiesto de la app (folio 004) · **modificado**

**Decisión.**

- **Catálogo** del cascarón: lista constante en su código, una entrada por capacidad, con id estable (`device.info`,
  `network.status`, `camera.capture`…), **su versión propia** y lo que declara en cada plataforma (permiso, clave de
  uso, feature o `<queries>`). El manifiesto de la app declara **sólo** lo que el catálogo implementa.
- **Descubrimiento:** por `bridge.handshake` (versión del puente y catálogo con versiones).
- **Toda capacidad del dispositivo pasa por el puente.** El contenido no usa API web del WebView que piden permisos; la
  compuerta lo prueba (P8). Negarlas además con `Permissions-Policy` es defensa adicional, NO VERIFICADO en
  `HybridWebView`.
- **Pedido en el uso**, nunca en el `handshake`: verificar, pedir en contexto, rationale y salida a ajustes.
- **El contenido declara** en su manifiesto de paquete `capabilities: { requires, optional }`, cada ítem con id y rango
  con techo sobre la versión de la entrada.
- **Si falta una:** de `requires` → el actualizador no activa el paquete (predicado de P3); de `optional` → el
  contenido oculta la función o explica por qué no está; permiso denegado → rationale y salida a ajustes.
- **Una capacidad nueva entra con declaración y uso en el mismo binario:** el release del cascarón trae la entrada del
  catálogo, la declaración del manifiesto de la app **y** una semilla cuyo contenido usa la función de forma visible,
  descripta en la ficha y en las notas de revisión. El contenido OTA posterior la evoluciona. `optional` sirve para que
  un contenido nuevo degrade en cascarones viejos, no para anticipar permisos.
- **Rama iOS (diseño, NO VERIFICADO):** mientras no se asiente que 4.7 no alcanza al contenido propio, o un permiso
  previo de Apple, el catálogo se expone en iOS sólo al contenido de la semilla del binario; el pedido de permiso del
  sistema en el uso cumple el consentimiento por instancia de 4.7.3.
- **Compuerta:** catálogo frente a AndroidManifest **e Info.plist fuente** (P8).
- **Catálogo de la demo:** sólo lo que su contenido usa, sin permisos de tiempo de ejecución; el rechazo por `requires`
  faltante y por versión fuera de rango se demuestra en la suite del actualizador.

**Fundamento.** Android *Declare app permissions*, *Request runtime permissions*; Apple `NSCameraUsageDescription`
(r1); Play *Permissions and APIs that Access Sensitive Information* («necessary to implement current features»,
«unimplemented») y Apple 2.5.19 («hidden, dormant, or undocumented»), abiertas por `SEG` y `REF`; Apple 4.7, 4.7.2 y
4.7.3; `dotnet/maui#25784`, `#30847`; Adaptive Cards [90]; Tauri [I7 §3.8]; `DEV` M2-2/M2-3 (E1); análisis §3.9 (C2
30, C3 16).

**Qué se descartó y por qué.** «Dos tiempos» leído como permiso antes que función (choca con Play y Apple). Una
pantalla XAML por capacidad (C3). Sin catálogo. La prueba sobre Info.plist descartada por «no tiene dónde correr»:
corre (E1).

**Condición de revisión.** Una revisión de Play o de Apple observa una función no ejercible en el binario revisado.
Cierre de `dotnet/maui#30847` → se revisa «sólo por el puente». Con un job `macos-*` medido → se suma la prueba sobre el
Info.plist combinado. Se asienta respuesta de Apple sobre 4.7 → se revisa la rama iOS.

### P13 — Encuestas tomadas con una versión cuando llega otra (folio 005) · **modificado**

**Decisión.**

1. La definición lleva `encuestaId` y `version` propios, que cambian en cada publicación.
2. Cada respuesta guarda `{encuestaId, versionDefinicion}` desde que se empieza a cargar. La encuesta en curso se
   termina con su versión; la nueva aplica a la próxima.
3. El cliente conserva una copia de toda definición con respuestas en curso o pendientes, en la base local junto a
   ellas e independiente de la retención de paquetes.
4. El servidor (en la demo, el receptor didáctico) acepta las versiones publicadas y no retiradas. **El servidor
   retiene las definiciones aparte de los paquetes; la limpieza de paquetes nunca retira una definición.**
5. **Retirar una versión de definición** es un acto explícito, **anunciado en el índice firmado** con su fecha de
   retiro, con un **plazo de aviso de 30 días** (criterio del jurado, provisorio, al lote). Una respuesta de una versión
   retirada no se borra: queda en carta muerta, visible al usuario.
6. La sincronización es idempotente y no depende de la versión de la app.
7. **Ninguna actualización, tampoco una obligatoria, descarta, migra en silencio ni invalida pendientes.** El forzado
   no espera a vaciar el outbox: la sincronización de P5 envía cada vez que hay red. La guía dice por qué no es la regla
   «sincronizar primero» de I0: es criterio del sintetizador que ninguna plataforma documenta, y con una fila
   rechazada dejaría la obligatoria sin aplicarse nunca.
8. **Regla de evolución:** dentro de un mismo `encuestaId`, el nombre y el tipo de un campo publicado no cambian;
   agregar preguntas, corregir textos y aflojar restricciones sí. Un cambio destructivo es un `encuestaId` nuevo o una
   migración explícita en el servidor. La compuerta del PR y la publicación lo validan (P8).
9. **El roll-forward nunca baja la versión de una definición**; revertir su contenido es publicar una versión nueva, y
   la versión mala queda publicada y no retirada mientras corra su plazo.
10. **Rechazar (retirar) una versión de contenido no rechaza las respuestas tomadas con ella**; a las respuestas sólo
    las afecta retirar una versión de definición (5).

**Fundamento.** ODK `orx:version` [7], «the `version` must change» y tipo de campo publicado [6], borradores atados a
su versión [11]; Kobo [17]; aceptación de versiones viejas en Central [10], OPINIÓN autorizada, NO VERIFICADO en la doc
oficial; service worker [F6] (r1); `REQ` H-05/H-09, `ANA` H-03/H-06/H-07, `DEV` H-05, `FOR` H-06/H-07; análisis §3.10
(S1 26, S3 23, S2 16).

**Qué se descartó y por qué.** Validar contra la versión vigente; forzar antes de sincronizar (r1). «El servidor nunca
retira una versión con pendientes» (I0): no es verificable, el servidor no ve lo no enviado. Envío oportunista antes de
activar (`ANA` H-07): con P2 caería en el camino crítico del arranque, y con red ya lo hace P5.

**Condición de revisión.** Si la demo pasa a un servidor real, se verifica que acepte versiones anteriores (NO
VERIFICADO para ODK Central). Una corrida en la que un pendiente queda sin enviar teniendo red entre la verificación de
una obligatoria y el arranque siguiente → defecto de P5.

---

## 6. Lote para quien pidió

**Los cuatro abiertos del folio 021 ya no están vigentes:** el PO los contestó (folio 023: proteger `main` y correr en
el runner propio; XC-1 = C-1; iOS diseño sin ensayo; sí atribuir a versiones exactas). No se repreguntan.

**La pregunta «(a) o (b)» que piden `ANA` H-02, R2-01 y el análisis r2 no va al lote:** el árbol la contesta con el
literal del PO (`Framework-APP.md:28`, §1.4), y `Mesa-De-Expertos-A-Pedido` §3.1 dice «No se le pregunta a quien pidió
nada que el pedido y el árbol contesten». Lo que el árbol **no** contesta es el juicio que el propio PO dejó escrito
como condición. Sólo esto:

1. **P1 — Tu borrador decía: «Si en la prueba de concepto el peso o el arranque del WASM no convencen, caer a B».**
   Medido: primer render 3,7–4,9 s con pantallas descargables (con la consulta en el camino crítico) frente a
   1,6–1,7 s con encuestas como datos solas; 9,13 MB por versión retenida; y diez mecanismos que el framework suma sólo
   por bajar código (sin AOT, detección del contrato, índice por mayor del puente, capacidades sólo por el puente, rama
   iOS de 4.7, entre otros). Con las encuestas como datos solas, corregir una encuesta sigue sin pasar por la tienda,
   pero una pantalla o lógica nueva sí. **¿Te convence el costo de las pantallas descargables, o caemos a encuestas como
   datos solas?**
   **SI NO RESPONDÉS:** rige el dictamen: pantallas Blazor WebAssembly descargables más encuestas como datos. La
   construcción empieza por el núcleo común a las dos, así que una respuesta posterior que pida caer cambia sólo el
   anfitrión de las pantallas y no tira el resto.

2. **Valores de producto que el árbol no fija.** ¿Confirmás estos valores, o das otros?
   - Dispositivos soportados: Android con WebView del sistema ≥ 94; iOS 16.4 como diseño.
   - Cota del forzado: un arranque en frío desde que la versión quedó verificada; sin cota en tiempo.
   - Plazo de aviso para retirar una versión de encuesta: 30 días.
   - Vigencia del índice firmado: 30 días, renovada cada 7.
   - Consulta al volver a la app desde segundo plano: como mucho una cada 15 minutos.

   **SI NO RESPONDÉS:** rigen esos valores, como criterio del jurado y provisorios. La guía los muestra como
   parámetros, y ninguno se apoya en algo irreversible.

---

## 7. Homogeneidad: por qué no es eco

**El dato.** Voté `PROCEDE` en 88 de los 89 hallazgos que las comisiones emitieron: coincido con su rótulo en el
98,9 %. Supera el 80 % de la carta y el umbral de `Mesa` §3.5.4. Lo explico.

1. **Qué se vota con `PROCEDE`.** Si el defecto **existe** y su ancla lo sostiene, no si la dirección propuesta es la
   correcta (`Mesa-De-Expertos-A-Pedido` §4: «Procedente es el hallazgo que el jurado votó que procede … tenga parche o
   no»). Las comisiones r2 tenían un objeto estrecho: buscar defectos en un dictamen escrito antes de la investigación,
   anclándolos en sus líneas. Casi todos los anclajes son E2 sobre 021 más una fuente verificada. Que un defecto así
   anclado exista no es materia de opinión.
2. **El juez de evidencia abrió las anclas que pasan cifras o citas al dictamen** (§1.3), en lugar de adoptarlas: la
   corrida de E02-R, el `grep` de `reportFullyDrawn`, I6, I2, cinco líneas de VPI, RYD y E01. Al abrirlas corrigió dos
   afirmaciones de una comisión (`ARQ` H-02) y no adoptó ninguna afirmación sin abrirla, que es la falla que R2-04
   encontró en r1.
3. **Donde voté distinto de una comisión, del refutador o del análisis:**

   | Ítem | Lo que proponían | Lo que votó el jurado |
   | --- | --- | --- |
   | `SEG` H-02 | P0 | P1 (con R2-05) |
   | `ANA` H-08 | Etapa de ingreso por QR | No procede |
   | `ANA` H-01 | Confirmar «un solo canal» | Procede el defecto; la dirección se descarta |
   | `ANA` H-02, R2-01, análisis | Pregunta (a)/(b) al lote | No va: el árbol la contesta (literal del PO que nadie citó) |
   | Análisis §3.1 | Default (a), C-min | (b), por la intención escrita del PO |
   | `ANA` H-04 | Login como punto de activación | No se adopta |
   | `ANA` H-07 | Envío oportunista | No se adopta |
   | `ARQ` H-02 | Rollback perdido en la activación en caliente; ninguna fuente activa en sesión | Las dos premisas, corregidas; procede por univocidad |
   | `ARQ` H-04 | «Miembro nuevo = menor» con interfaces C# | Excepción sin ficha; se adopta la tabla de métodos |
   | `DEV` H-02 | Generador y hash propios; aviso en `diseño` | Instantánea; bloquea |
   | `DEV` H-04 | Contenido sobre el piso en la compuerta | Rótulo de VPI; tramo siguiente |
   | `DEV` H-07 | Predicado contra los cascarones soportados al publicar | Sólo la parte (1) ahora |
   | `FOR` H-03/H-04 | Valores sólo de producto, sin valor | Valores provisorios del jurado, con default en el lote |

4. **Lo que no puedo resolver desde acá:** un solo agente aplicó las cinco funciones. Por eso no hay quórum de cinco y
   lo declaro (§1.1). Que mis votos coincidan con informes que leí después de que ellos los escribieron no prueba
   independencia. El remedio es de composición: despachar cinco jueces por separado, y lo elevo (§8).

---

## 8. Señales para la presidencia

Ninguna va a quien pidió.

| Señal | Qué pide |
| --- | --- |
| **Quórum** (`Mesa` §3.5.4; R2-04) | Este veredicto no tiene quórum de cinco: lo emitió un agente. Para que valga como veredicto de `Mesa`, despachar los cinco jueces por separado o asentar en la resolución que se cierra con veredicto de un solo agente, declarado |
| **Criterio de corte** (§3) | La ronda 2 tiene 57 procedentes interpretativos. No hay cierre por criterio sin dos rondas limpias más, dentro del techo de cuatro. Si se cierra ahora, el bloque de cierre dice **por decisión** |
| **Enunciado** | Asentar en el OBJETIVO la cláusula sin red con sus dos orígenes (F004, F005) y su instrumento (`REQ` H-01). Asentar como requisito el literal del borrador del PO `Framework-APP.md:28`, que funda la premisa de P1 (un testimonio no es E4 hasta asentarse, `Escalas-De-Juicio` §3.3) |
| **Académico editor** | Su condición de entrada en caliente se cumplió (`LSC` S-1 con P1 sobre P10; composición r2 §6) y no figura en `despacho/`. P10 se decidió sin esa comisión. Convocarla en la ronda siguiente, si la hay, o asentar el motivo |
| **Cuerpo de parches** (R2-12) | Cotejar cada `PROCEDE` de r1 y de r2 contra el texto de este dictamen antes de aplicar |
| **Obstáculos de una línea**, a quien tiene el teléfono de medida | (1) La corrida de `FOR` S-4: arranque en frío, consulta fuera del camino crítico, 5 corridas, marca `primer-render` y `reportFullyDrawn` desde `Listo`. (2) La corrida con la red cortada (`REQ` H-01). (3) Dos versiones fallidas sin red (`VER` H-04). (4) Peso de una definición sola bajada por el canal (análisis O-1). (5) Qué pasa si el contenido pide geolocalización por la API web en `HybridWebView` (`VER` H-05) |
| **Obstáculos para quien aplica** | Tiempo de pared de la instantánea y de la compuerta de definiciones en el runner, con su primer rojo provocado. El comando `adb shell dumpsys webviewupdate`, verificado antes de escribirlo en la guía. Pendiente de r1: que un administrador de `hdcm-dev` lea el grupo del runner (`DEV` M-7, 403) |
| **Barrido antes de versionar** | Este folio no nombra el repositorio privado ni direcciones o series. El folio 004 sí lo nombra (testimonio): se redacta en la copia publicada |

Sigue: resolución con el plan y el lote al PO · presidencia · Cierra con: folio resolucion

Sigue: respuesta del PO al lote y resolución · presidencia · Cierra con: folio resolucion
