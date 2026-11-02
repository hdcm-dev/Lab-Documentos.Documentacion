---
doc_id: EXP0003-F380
doc_type: analisis
title: Análisis de decisiones A del ciclo 3 — audiencias (A-01 a A-15) y paneles, portales y formularios (B-01 a B-12), con matriz ponderada, sensibilidad, firmeza R-06 e impacto sobre cuerpo, conocimiento, libro y ensayos
status: borrador
origin: agent
confidence: alta en lo citado de los informes F310–F376 y en el cálculo (guion reproducible, §3.5); media en los puntajes de celda, que son juicio de esta silla y van con su motivo; alta en las cuatro fuentes externas reabiertas hoy (§9)
owner: presidencia de la reedición DocsAsCode (expediente 0003), silla de análisis de decisiones A
last_review: 2026-11-02
audience: [presidencia, jurado del ciclo 3, refutador, comisiones CA-1 a CA-9, editores, PO]
traces: [EXP0003-F099, EXP0003-F204, EXP0003-F300, EXP0003-F310, EXP0003-F320, EXP0003-F330, EXP0003-F340, EXP0003-F350, EXP0003-F360, EXP0003-F370, EXP0003-F374, EXP0003-F376]
---

| Campo | Valor |
| --- | --- |
| Tipo | analisis |
| Fecha | 2026-11-02 (pedido fechado 2026-11-01; se redactó después del corte de energía) |
| Autor | Analista de decisiones A (AD-A), fuera del panel: consolida, no vota, no cuenta en el denominador (`MEP` paso 6 bis) |
| Corrige | — Se escribió **a ciegas** respecto de `F381` (AD-B): no se abrió ese folio |

**Convención de citas.** Igual que `F300`: `SDEI/` = la guía del sistema de documentación e integración en `LD`
`00171bd`; `K` = el conocimiento en curso (1.2); `MEP`, `MCT` = los conocimientos de mesa; `{servicio-privado}`,
`{dir-de-trabajo}` por alias. Las comisiones se citan por folio: CA-1 `F310`, CA-2 `F320`, CA-3 `F330`, CA-4 `F340`,
CA-5 `F350`, CA-6 `F360`, CA-7 `F370`, CA-8 `F374`, CA-9 `F376`.

## Índice

1. [Mandato y alcance](#1-mandato-y-alcance)
2. [Insumos leídos](#2-insumos-leídos)
3. [Método](#3-método)
4. [Tablero](#4-tablero)
5. [Eje A — pregunta por pregunta](#5-eje-a--pregunta-por-pregunta)
6. [Eje B — pregunta por pregunta](#6-eje-b--pregunta-por-pregunta)
7. [Discrepancias entre comisiones que van al jurado](#7-discrepancias-entre-comisiones-que-van-al-jurado)
8. [Impacto: qué rehacer y en qué orden](#8-impacto-qué-rehacer-y-en-qué-orden)
9. [Fuentes externas reabiertas hoy](#9-fuentes-externas-reabiertas-hoy)
10. [Lo no verificado, incidencias y mensajes](#10-lo-no-verificado-incidencias-y-mensajes)
11. [Barrido de lo privado](#11-barrido-de-lo-privado)

---

## 1. Mandato y alcance

`F300` §7 pide a cada analista, a ciegas del otro, la matriz ponderada, la dominancia y la cadena de consecuencias
de las salidas de las comisiones para (a) la forma de la decisión de audiencias en `K` y (b) la clase de pieza y el
control del microtexto. El despacho de esta silla lo amplía a **todas** las preguntas A-nn y B-nn y al análisis de
impacto (pregunta común de `F300` §5.3). Este folio no decide: ordena alternativas para el jurado (`F395`).

## 2. Insumos leídos

- `F300` completo (providencia, preguntas, hipótesis §6, panel).
- Los nueve informes `F310`, `F320`, `F330`, `F340`, `F350`, `F360`, `F370`, `F374`, `F376`: dictamen por pregunta,
  propuesta, puntuación y tabla «qué rehacer». El despacho hablaba de siete; en la carpeta hay nueve (CA-1 a CA-9),
  y se leyeron los nueve.
- `F099` (R-06 y la estructura del libro §5.2, Parte III caps. 7–8) y `F204` §8–§9 (criterio de caso y ronda 3).
- `F080` §4, sólo como modelo de forma del método.
- **No leídos**: `F381` (por ceguera), `F385` (no existe todavía).

## 3. Método

### 3.1 Criterios y pesos

Los fija el despacho. Pesos fijados antes de puntuar **[criterio propio]**: validez lleva más porque incluye
«cumple el pedido literal» (E-01 a E-10 de `F300`), que es filtro antes que preferencia.

| Id | Criterio | Qué mide | Peso |
| --- | --- | --- | --- |
| V | Validez | Responde la frase del PO y se sostiene en la fuente que cita | 0,20 |
| CI | Verificabilidad en CI | Hay control determinista con par rojo/verde (en `docs-guard` o en la CI del producto) | 0,15 |
| S | Simplicidad | Piezas, campos y reglas nuevas | 0,10 |
| Co | Costo de adopción | Migración y herramienta que exige | 0,10 |
| Seg | Seguridad | No divulgación efectiva (acceso, no sólo visibilidad) | 0,15 |
| Comp | Compatibilidad con el cuerpo vigente | Reusa lo que hay (`TEM-05`, anclas `muestra`, `topic`, PoC-R) sin contradecirlo | 0,15 |
| PE | Practicidad y escalabilidad para el PO | Sirve al caso `{servicio-privado}` y a un segundo servicio sin rehacer | 0,15 |

### 3.2 Escala anclada (1–5, 5 = mejor)

| Punto | V | CI | S | Co | Seg | Comp | PE |
| --- | --- | --- | --- | --- | --- | --- | --- |
| 5 | Cubre la frase y la sostienen ≥ 2 comisiones con fuente | Control con par, bloqueante | 0–1 pieza nueva | Sin migración | Entrega negada y probada | Reusa tal cual | Un registro sirve a N servicios |
| 4 | Cubre la frase; una comisión con fuente | Control con par que avisa, o prueba del producto | 2 piezas | PR mecánico | Entrega negada, prueba parcial | Ajuste menor | Ajuste por servicio |
| 3 | Cubre parcialmente | Control sin par medido | 3 piezas | Migración acotada | Visibilidad bien rotulada | Neutral | Sirve a un servicio |
| 2 | Deja una frase sin cubrir | A mano | 4–5 piezas | Herramienta o migración grande | Riesgo de fuga conocido | Choca con una regla | Rehacer por servicio |
| 1 | Contradice la frase | No verificable | > 5 piezas | Toolchain nuevo o licencia | Fuga por diseño | Contradice el cuerpo | No escala |

### 3.3 Firmeza (R-06 de `F099` §4)

**FIRME** si la ganadora aventaja a la segunda en **tres o más puntos de celda** (suma sin ponderar de las
diferencias). Si no, **CON REVISIÓN**, con una condición comprobable.

### 3.4 Sensibilidad

±10 % relativo en cada peso, de a uno, renormalizando (14 corridas por pregunta). Se cuenta cuántas corridas cambian
la ganadora.

### 3.5 Cálculo

Guion propio, Python 3 sin red (`python3 -I`), `matriz.py` `sha256 67ca3362…af2fb5`; salida `salida.txt`
`sha256 089cdc3f…2e4707`, ambos en `{dir-de-trabajo}/mesa/ad-a-c3/`. Todos los puntos están en §5 y §6: se
recalcula sin el guion.

## 4. Tablero

Orden de celdas: V, CI, S, Co, Seg, Comp, PE.

| Pregunta | Ganadora (origen) | Total | Segunda | Margen | Celdas | ±10 % invierte | Firmeza |
| --- | --- | --- | --- | --- | --- | --- | --- |
| A-01 | a1 ISO 26514 adaptada; audiencia ≠ permiso (CA-1, CA-5) | 4,50 | a3 | 0,35 | +3 | 0/14 | **FIRME** |
| A-02/A-03/A-12 | b3 registro + campo de entrega aparte + vista derivada (CA-3, con CA-6) | 4,40 | b4 (CA-4) | 0,10 | +1 | 0/14 | CON REVISIÓN |
| A-04 | c1 lector como dimensión; `TEM-04` sigue como tema (CA-1, 3, 5, 7, 9) | 4,35 | c2 | 0,45 | +3 | 0/14 | **FIRME** |
| A-05 | d1 jerarquía declarada una vez, expandida en el build (CA-1, 3, 9) | 4,65 | d2 | 0,65 | +4 | 0/14 | **FIRME** |
| A-06 | e1 nivel → punto de aplicación + pruebas negativas del producto (CA-3, CA-4) | 4,30 | e2 | 0,65 | +3 | 0/14 | **FIRME** |
| A-07 | f1 exposición por operación, contrato por exposición, ensanchar = H por cambio (CA-2) | 4,45 | f2 | 0,45 | +2 | 0/14 | CON REVISIÓN |
| A-08 | g1 tipo de alcance en el repo, valores en el servidor (CA-2, 3, 9) | 4,50 | g2/g3 | 1,15 | +7 | 0/14 | **FIRME** |
| A-09 | h1 una fuente, salidas por superficie, paquete sólo público (todas) | 4,80 | h2 | 2,10 | +14 | 0/14 | **FIRME** |
| A-10 | i3 filtro único + `canal_agente` con `ninguno` por defecto en lo no público (síntesis CA-7 H+ y X2) | 4,65 | i2 | 0,30 | +1 | 0/14 | CON REVISIÓN |
| A-11 | j1 núcleo bloqueante en `docs-guard` + pruebas del producto | 4,50 | j3 | 0,80 | +4 | 0/14 | **FIRME** |
| A-13 | k1 / k2 (empate exacto) | 4,25 | — | 0,00 | +1 | 7/14 | CON REVISIÓN |
| A-14 | l1 re-sellar sólo oráculos afectados; criterio de caso igual | 4,35 | l2 | 0,80 | +6 | 0/14 | **FIRME** |
| A-15/B-12 | m1 extender `Prueba-Ayuda-Por-Rol` con formulario | 4,35 | m3 | 0,05 | +1 | 0/14 | CON REVISIÓN |
| B-01 | n1 escalera de capas con vocabulario cerrado (CA-6, CA-8) | 4,35 | n2 | 1,15 | +6 | 0/14 | **FIRME** |
| B-02 | o1 números interpolados de la regla, letra escrita (CA-1, 4, 8) | 4,50 | o2 | 0,85 | +5 | 0/14 | **FIRME** |
| B-03/B-04 | p2 canal de `CL-06`; traza desde la ficha con anclas `muestra`/`valida` (CA-1, CA-4) | 4,50 | p3 | 0,25 | +3 | 0/14 | **FIRME** |
| B-05 | q1 anclas `contiene` + límite interpolado (CA-1, CA-4) | 4,50 | q2 | 0,50 | +4 | 0/14 | **FIRME** |
| B-06 | r1 etiqueta y error iguales; variantes justificadas; servidor (CA-5, 6, 3) | 4,50 | r2 | 0,80 | +5 | 0/14 | **FIRME** |
| B-07 | s1a ID de contexto estable en el frontmatter, mapa derivado (CA-1, 6, 9) | 4,50 | s1b (CA-2) | 0,25 | +2 | 0/14 | CON REVISIÓN |
| B-08 | t1 sólo canal derivado que dirige, nunca restringido (CA-2, 6, 9) | 4,35 | t3 | 0,35 | +1 | 0/14 | CON REVISIÓN |
| B-09 | u1 `aria-describedby` probado en la interfaz (CA-8, CA-9) | 4,35 | u2 | 1,20 | +7 | 0/14 | **FIRME** |
| B-10 | v3 regla condicional: si hay asistente, misma pieza con token del usuario, sugiere y no envía (CA-3, 7, 8) | 4,65 | v1 | 0,35 | +3 | 0/14 | **FIRME** |
| B-11 | w1 `Display`+`.resx`+localizador por audiencia en servidor; `AddOpenApi` por documento (CA-4, 8, 9) | 4,65 | w2 | 2,00 | +12 | 0/14 | **FIRME** |

Resultado: **16 FIRME, 7 CON REVISIÓN** (una en empate exacto). Ninguna ganadora cambia con ±10 %, salvo el empate
de A-13. Nota de dominancia: i3 y v3 son síntesis que dominan a sus componentes; se marcan como de esta silla.

## 5. Eje A — pregunta por pregunta

### A-01 Definición y término

| Alt. | Origen | Contenido | Celdas |
| --- | --- | --- | --- |
| a1 | CA-1, CA-5 | «Audiencia» con la definición de ISO/IEC/IEEE 26514, 3.1.7, adaptada (`F310` §5.1); **no es un permiso**: a quién se entrega lo dice la regla de entrega | 5,4,4,4,5,5,4 = 4,50 |
| a2 | CA-3, CA-4, CA-9 | Conjunto de lectores definido por atributos (rol, alcance, superficie, acceso) al que se entrega | 4,4,5,4,3,4,4 = 3,95 |
| a3 | CA-5 | a1 + audiencia primaria/secundaria y audiencia invocada (Ong; Ede y Lunsford) | 5,4,3,3,5,5,3 = 4,15 |

a2 pierde en Seg: mete el acceso dentro de la definición y reabre lo que `TEM-05:48` ya separa («ocultar es
visibilidad; no entregarla es acceso»). a3 agrega una distinción que CA-5 mismo condiciona («si en la ronda 3
ningún caso usa la secundaria, se vuelve a una tabla», `F350` §6). **FIRME a1**; «audiencia primaria» queda como
nota de glosario, no como campo. La norma ISO es de pago y CA-1 la citó por su FDIS (`F310` §8 R6): **sin verificar
por esta silla** en la edición publicada.

### A-02, A-03, A-12 Dimensiones, relación con el escenario y forma en `K`

Las tres se deciden juntas: son la misma decisión (qué es D-18 y qué campo lleva la página).

| Alt. | Origen | Contenido | Celdas |
| --- | --- | --- | --- |
| b1 | Presidencia (`F300` §6.1–2) | Matriz única por audiencia con acceso y lector en la fila, tabla en el repo | 4,3,4,4,3,4,4 = 3,70 |
| b2 | CA-1 A1 | D-18 «Audiencias y entrega»; `audience` pasa a IDs del registro y **se migran 283 archivos**; modo de lectura fuera | 5,4,3,2,4,4,4 = 3,90 |
| b3 | CA-3 S-1 (con CA-6 §5.2) | Registro de audiencias con jerarquía y nivel; campo **nuevo** `audiencias:` (entrega, *deny by default*), `audience` queda como orientación; la «matriz audiencia × página» es vista **derivada** (D) | 5,5,3,4,5,4,4 = 4,40 |
| b4 | CA-4 A1 | Matriz **ejecutable**: cada fila nombra `cumple` (política, documento OpenAPI) y de ella salen pruebas negativas | 5,5,3,3,5,4,4 = 4,30 |
| b5 | CA-1 A2, CA-5 A2, CA-6 CA6-B | Sin decisión nueva: ampliar D-01/D-13 | 2,3,5,5,2,5,2 = 3,20 |

Dimensiones (A-02): las nueve comisiones convergen en **rol, alcance, superficie y nivel de acceso** como
ortogonales; **jerarquía** derivada del rol (inclusión); **lector humano/agente** fuera del acceso (canal);
**idioma** no amplía acceso. Obligatoriedad por escenario: nivel siempre que haya producto; rol y jerarquía en
`ESC-SDEI-3`; alcance y superficie sólo si existen (inventario de D-01).

A-03: la fila «Audiencias» de `SDEI/00-Marco.md` §2.5 **no se reemplaza**: pasa a «Audiencias típicas» (CA-1, 2, 5,
6, 9). «agente» sale de esa fila (CA-7).

**Recomendación: b3 tomando la columna `cumple` de b4. CON REVISIÓN** (ventaja +1 sobre b4). b3 le gana a b2 en
costo (no migra 283 archivos: el campo nuevo convive y lo heredado avisa) y le gana a b1 en Seg (una sola fuente del
acceso: CA-3 §6). **Condición comprobable**: si en la PoC-R extendida la prueba negativa generada desde `cumple`
corre en la CI del producto y da rojo al quitar el filtro (C-AUD-3 de CA-4), `cumple` es obligatoria; si no se puede
generar, queda opcional y la matriz se declara no ejecutable.

*Cadena de consecuencias.* Cae en quien escribe ayuda (un campo `audiencias:` por página) y en `K` (D-18, A-01,
A-03). Reversible: el registro se puede aplanar a `roles`. Lo irreversible es ampliar una entrega; por eso AC-5
(guarda de merge) sobre el registro.

### A-04 Doble audiencia

c1 (lector como dimensión/canal; `TEM-04` sigue como tema, renombrable «Lectura por agentes») 4,35; c2 (capítulo 7
absorbido por el de audiencias, CA-2) 3,90; c3 («agente» como audiencia con acceso propio, la lectura actual del
Marco) 2,50, rechazada por CA-7 X1: daría al agente un alcance que su usuario no tiene. **FIRME c1.**

### A-05 Jerarquía de privilegio

d1 (`incluye:` en el registro, el build expande a la lista de roles; el servidor sigue preguntando pertenencia; la
herencia es vertical, no de alcance — CA-3 §4) 4,65; d2 (orden de inclusión de valores, CA-2) 4,00; d3 (roles planos
repetidos por página, hoy) 3,50. Cruce: enlace de abajo hacia arriba = rojo; de arriba hacia abajo = verde.
Cambiar la jerarquía = H con reserva (CA-3 §5.3). **FIRME d1.**

### A-06 Acceso frente a visibilidad

e1 (cada nivel `publico`/`producto`/`restringido`/`interno` nombra su punto de aplicación; las pruebas del producto
prueban la **no entrega**: 404 indistinguible en página, `.md`, `llms.txt`, búsqueda, ayuda de campo y asistente,
caché privada; CA-3 §4 y CA-4 §6.3) 4,30; e2 (sólo controles declarativos en `docs-guard`) 3,65; e3 (delegar al RBAC
de un portal comercial) 2,85. CA-3 advierte la «falsa sensación»: AC-1 a AC-4 prueban declaraciones; sólo PP-1 a
PP-4 prueban entrega. **FIRME e1.** Mintlify, reabierto hoy, sostiene el 404 a quien no está en el grupo y el
`llms.txt` sólo público (§9).

### A-07 Documentación de API restringida

| Alt. | Origen | Celdas |
| --- | --- | --- |
| f1 | CA-2: `x-exposicion` por operación (y por propiedad), un contrato por exposición, `CA2-C2` monotonía, `CA2-C2b` ensanchar = H **por cambio**; interfaz interactiva sólo en desarrollo | 5,5,3,3,5,4,5 = 4,45 |
| f2 | Presidencia + CA-3/CA-4: exposición H una vez; `MapOpenApi().RequireAuthorization(...)`; `C-API-1` grupo obligatorio | 4,4,4,4,4,4,4 = 4,00 |
| f3 | CA-2 A3: RBAC del portal comercial | 3,2,4,2,4,2,3 = 2,85 |

Hecho verificado hoy: Microsoft Learn dice «The OpenAPI endpoint doesn't enable authorization checks by default» y
«Any endpoint that hasn't been assigned a group name is included in all OpenAPI documents» (§9): sostiene `C-API-1`
en las dos alternativas. **Recomendación f1, CON REVISIÓN** (+2). Condición: si la marca por **propiedad** (no sólo
por operación) no se puede emitir con transformadores de `AddOpenApi` en la PoC, se adopta f1 a nivel de operación y
la propiedad queda como aviso. Clase: exponer = **H**; cada ensanchamiento = **H por cambio**; angostar = P con aviso
en `CHANGELOG`.

### A-08 Alcance por inquilino o aplicación

g1 (CA-2, CA-3, CA-9 convergen: el repo declara sólo el **tipo** de alcance — `generico`/`por-aplicacion` —; los
valores son datos del producto que el servidor rellena con la autorización del recurso; cruce de alcance = prueba
del producto + barrido de literales) 4,50; g2 (cruce de alcance en `docs-guard`, hipótesis §6.3) 3,35; g3 (valor de
alcance en el frontmatter, CA-1) 3,35. CA-2 lo dice exacto: «No hay alcance en el repo que `docs-guard` pueda
cruzar». **FIRME g1**; la hipótesis §6.3 se enmienda.

### A-09 Varias superficies

h1 (una fuente; `superficie` como atributo; lo que viaja en el paquete instalable es `publico`; lo demás se pide al
servidor; control de paquete) 4,80, unánime; h2 (fuentes separadas) 2,70. **FIRME h1.** El segundo servicio del
paquete del PO es **otra superficie del mismo producto**, no otro escenario (CA-2). En móvil la pista es texto
visible, no *tooltip* (CA-9).

### A-10 Agente por audiencia

i1 (CA-7 H+: filtro único para página, `.md`, `llms.txt`, MCP e índices; token del usuario; índices particionados;
AG-1…AG-6) 4,30; i2 (CA-7 X2: sin canales para agentes en lo no público) 4,35; **i3 síntesis de esta silla**: la regla
del filtro único es norma; `canal_agente` en el registro con `ninguno` por defecto para niveles no públicos, y sólo
se habilita con AG-2/AG-3 en verde: 4,65. **CON REVISIÓN** (+1 sobre i2). Condición: si en la PoC-R el `llms.txt`
por audiencia pasa AG-3 (equivalencia de canales) con dos sesiones, el valor por defecto puede pasar a «por sesión».

### A-11 Controles verificables en CI

Hay cerca de 30 controles propuestos con nombres distintos para lo mismo. Agrupados:

| Familia (nombre unificado propuesto) | Propuestos como | Dónde | Bloquea |
| --- | --- | --- | --- |
| `audiencia-vocabulario` | C-AUD-1 (CA-1, CA-4), AC-1 (CA-3), `audiencia-declarada` (CA-6) | `docs-guard` | Sí, línea de base 0 |
| `cruce-de-audiencia` (con jerarquía expandida) | C-AUD-2, AC-2, `cruce-exposicion`, `scope-cross` | `docs-guard` | Sí |
| `indice-sin-fuga` | C-AUD-3 (CA-1), AC-3, AG-2, AG-4 | `docs-guard` sobre salida del build | Sí |
| `paquete-sin-fuga` | AC-4, CA2-C3, C-AUD-5 (CA-4), `bundle-leak`, `paquete-sin-restringido` | `docs-guard` o build | Sí |
| `ampliacion-de-acceso` | AC-5, CA2-C2b | Guarda de merge | Reserva H |
| `contrato-por-exposicion` | CA2-C1/C2, C-API-1/2 | Producto | Sí |
| `contexto-resuelve` | C-AUD-5 (CA-1), B-07-C1, `ctx-orphan` | `docs-guard` | Avisa al principio |
| `anclas` extendidas a recursos | C-AUD-4 (CA-1), C-CAMPO-1, `mt-traza`, `resx-trace` | `docs-guard`/producto | Sí, como hoy |
| `traduccion-atrasada` | C-AUD-6, C-CAMPO-3, `mt-traduccion-atrasada` | `docs-guard` | Avisa |
| `anti-inyeccion-en-recursos` | AG-5 | `docs-guard` | Como AI-n hoy |
| Pruebas de entrega | PP-1…PP-4 (CA-3), C-AUD-3 (CA-4), C-AUD-4 interfaz API en producción | Producto | CI del producto |

j1 (esas familias, núcleo bloqueante de cinco + pruebas del producto) 4,50; j2 (los ~30 por separado) 3,35; j3
(sólo vocabulario y cruce) 3,70. **FIRME j1.** Las comisiones difieren en nombres, no en fondo: el jurado sólo tiene
que adoptar la tabla de nombres.

### A-13 Impacto en el libro

| Alt. | Origen | Parte III | Celdas |
| --- | --- | --- | --- |
| k1 | CA-1, CA-4, CA-5 | 7 «Audiencias» (nuevo) · 8 «Lectura por agentes» · 9 «Ayuda al usuario final» con 9.x punto de uso | 4,4,5,4,4,5,4 = 4,25 |
| k2 | CA-6, CA-9 | k1 + 10 «Ayuda en el punto de uso: pantallas, campos y portales» (nuevo) | 5,4,4,3,4,4,5 = 4,25 |
| k3 | CA-2, CA-4 | k2 + capítulo «Documentación de API por exposición y portales» | 5,4,3,2,4,3,4 = 3,75 |

**Empate exacto k1/k2; CON REVISIÓN.** Esta silla recomienda **k2**, porque el PO escribió «me interesa mucho» sobre
el eje B (`F300` §2.2) y un capítulo propio lo hace encontrable. Condición: si el borrador del lote L3 de `F099` deja
la parte de punto de uso por debajo de un tercio del capítulo de ayuda, se funde en 9.x (k1). La API restringida va
como sección del cap. 7 y del cap. 18 (casos), no como capítulo (k3 pierde en simplicidad y compatibilidad con
`F099` §5.2).

### A-14 Impacto en los ensayos

l1 (re-sellar **sólo** los oráculos de casos con roles, API o formulario, con fila de D-18 y, si el caso tiene
formulario, fila de D-13 «microtexto y ubicación»; criterio de caso de `F204` §8 sin cambio) 4,35 — ocho de nueve
comisiones; l2 (re-sellar todos) 3,55; l3 (no re-sellar; ronda 3 con 1.2 y ronda 4 para audiencias) 3,20. **FIRME
l1.** CA-1 explica por qué no es opcional: sin la fila, una aplicadora que conteste D-18 bien suma discrepancias en M2
que no son error. **Ronda 3**: no nueva ni adicional; es la misma de `F204` §9, que se sella recién con `K` 1.3.

### A-15 y B-12 Demo

m1 (extender `Prueba-Ayuda-Por-Rol` con tercer rol en jerarquía, dos alcances, salida empaquetada sin lo restringido,
contrato de tres exposiciones, `llms.txt` por audiencia y un formulario con pista interpolada y par rojo/verde —
siete comisiones) 4,35; m2 (extender sólo la mini demo `MovilidadUrbana`, CA-8) 3,65; m3 (las dos) 4,30. **m1, CON
REVISIÓN** (+1). Condición: si el rojo de desfase en la mini demo sale «gratis» del código fijado por SHA (CA-8 §B-12)
sin tocar ese código, se suma (m3) porque el 60/80 es el hilo pedagógico del libro.

## 6. Eje B — pregunta por pregunta

### B-01 Mecanismos de microtexto

n1 (escalera de capas con vocabulario cerrado `etiqueta · pista · info · ejemplo · validacion`; pista de una oración
para la mayoría, sin enlaces; nada esencial en marcador ni *tooltip*; lo largo, por identificador de contexto — CA-6,
CA-8, CA-1) 4,35; n2 (sin taxonomía) 3,20. **FIRME n1.** GOV.UK reabierto hoy: «Use hint text for help that's
relevant to the majority of users», «Do not use links in hint text», no usar marcador en lugar de etiqueta (§9).

### B-02 Fuente única regla ↔ texto

o1 (los **números** se interpolan desde la constante o el atributo de la regla; la **letra** la escribe la autora de
ayuda: «derivar no es generar», `TEM-05:44`) 4,50 — CA-1, CA-4, CA-8; o2 (generar la frase desde OpenAPI/JSON Schema)
3,65, choca con `TEM-05:44` y deja la voz del integrador; o3 (copia manual, hoy: el 60/80) 2,40. **FIRME o1.**

### B-03 y B-04 Traza del texto de campo y clase de pieza

Clase: **canal de `CL-06`, no clase nueva** — ocho de nueve comisiones (p4, clase nueva, sólo como alternativa
descartada de CA-8). La discusión es dónde vive la traza:

| Alt. | Origen | Contenido | Celdas |
| --- | --- | --- | --- |
| p1 | Presidencia §6.5, CA-9 | Traza `ID@versión` en el `<comment>` del `.resx` | 3,3,5,5,3,4,3 = 3,55 |
| p2 | CA-1, CA-4 | Traza **desde la ficha** de la regla: filas `muestra` (clave del recurso) y `valida` (atributo), con `contiene`; `docs-guard` suma resolvedor `.resx`/JSON Schema | 5,5,4,4,4,5,4 = 4,50 |
| p3 | CA-6, CA-8 | Catálogo de microtexto (`doc_type: microtexto`) del que el build **emite** los recursos | 5,5,2,2,5,4,5 = 4,25 |
| p4 | CA-8 A3 | Clase nueva `CL-15` | 3,4,2,2,4,2,3 = 2,95 |

**FIRME p2** (+3 sobre p3). Reusa el ancla `muestra` que ya dio rojo en la mini demo (`F340` §7.2); p1 es frágil
(el `<comment>` lo pisan las herramientas de traducción, `F374` §B-03). p3 queda **admitido como opción de D-13**
(«catálogo con traza») para proyectos con muchas variantes por audiencia o sin .NET; no es la recomendación por
defecto. Consecuencia: la frase de `K` D-13 «el texto localizado en archivos de recursos no se ancla» se reemplaza
cuando exista el resolvedor (expediente de herramienta).

### B-05 Control de desfase

q1 (anclas extendidas con `contiene` + límite interpolado: el desfase numérico desaparece por construcción; la
prosa la cubre la traza con versión) 4,50; q2 (`mt-desfase-regla` / `rule-text-drift`: comparar números del texto con
los atributos por análisis estático o reflexión — CA-8, CA-9) 4,00; q3 (sólo traza con versión) 3,85. **FIRME q1**;
q2 queda admitido como prueba unitaria del producto donde la regla no está en atributos (límite honesto de CA-8).

### B-06 Por audiencia y por idioma

r1 (etiqueta y mensaje de error **iguales** para todas las audiencias — CA-5 por Novick y Ward; variantes sólo en
pista o ayuda ampliada con `varia_por: alcance | superficie`; resolución en el servidor, nunca todas las variantes
al cliente — CA-3; el alcance cambia **parámetros**, no texto — CA-8; traducción atrasada como aviso) 4,50; r2 (clave
con sufijo de audiencia libre) 3,70. **FIRME r1.**

### B-07 Paneles y portales

Las cinco comisiones que lo tratan convergen en el **identificador de contexto estable** (DITA `<resourceid>`, Flare
*alias/header*, Visual Studio F1), resuelto en el servidor con la audiencia; el portal como **superficie y
renderizador**, no como fuente; el enlace del panel al portal **no transfiere permiso**. La diferencia es dónde vive
el vínculo:

- s1a (CA-1, CA-6, CA-9): la página declara `contexto:` (hoy `topic`), con vocabulario `ctx.<unidad>.<pantalla>[.<campo>]`
  y `alias` para renombres; el mapa es derivado. 4,50.
- s1b (CA-2): archivo `_contexto.yaml` aparte. 4,25.
- s2 sugerencias por URL (patrón Zendesk) 3,05; s3 enlaces por URL 3,05.

**s1a, CON REVISIÓN** (+2). Condición: si un mismo contexto necesita resolver a páginas distintas por audiencia y el
frontmatter no lo expresa sin duplicar, se pasa a s1b. Control `contexto-resuelve`: avisa hasta línea de base 0, luego
bloquea.

### B-08 Plataformas de guía en producto

t1 (admitidas sólo como canal derivado que **dirige**: sin números ni reglas, nunca con audiencia `restringido` o
`interno`, declaradas como contenido fuera del repo; recorridos que enlazan a `ctx` — CA-2, CA-6, CA-9) 4,35; t3
(prohibirlas) 4,00; t2 (adoptarlas para la ayuda normativa) 2,20. **t1, CON REVISIÓN** (+1). Condición: se activa
sólo si el PO pide recorridos o anuncios; si no, el cuerpo dice «no se usa» y t3 rige en la práctica. Que una
plataforma impida la entrega (no sólo la dirija) quedó **sin verificar** en CA-3 y CA-9.

### B-09 Accesibilidad

u1 (asociación con `aria-describedby` probada en las pruebas de la interfaz con lector o motor de reglas; `docs-guard`
sólo comprueba que exista entrada de etiqueta y de error por campo con regla; CA-8 aclara que 3.3.2 no exige la
asociación programática, la exigen 1.3.1 y 4.1.2) 4,35; u2 (verificarlo en `docs-guard`) 3,15. **FIRME u1.** El
soporte de `aria-describedby` en `ValidationMessage` de Blazor quedó **sin verificar** (CA-8).

### B-10 Agente que asiste en el formulario

v3 (síntesis de esta silla): regla condicional — si hay asistente, usa **la misma pieza** de microtexto, recuperada con
el token del usuario, cita `ID@versión`, **sugiere y no envía**, el alcance lo fija la sesión, AI-1…AI-5 corren sobre
los recursos (AG-5); `assistant_use` por pieza es H (CA-7). Si no hay asistente, no se exige nada. 4,65; v1 (exigirlo
siempre) 4,30; v2 (prohibir asistente) 4,15. **FIRME v3.** OWASP LLM06:2025, reabierto hoy: «actions taken on behalf
of a user are executed on downstream systems in the context of that specific user» (§9).

### B-11 Implementación en .NET

w1 (`[Display(Name, Prompt, Description, ResourceType)]` y `ErrorMessageResourceName` sobre `.resx`; `IStringLocalizer`
decorado que busca `Clave.{audiencia}` y cae a `Clave` con la audiencia de los *claims*; autorización basada en
recursos para el alcance; `AddOpenApi` por documento y `MapOpenApi().RequireAuthorization`; MAUI: sólo lo público en
`MauiAsset`, lo demás por API autenticada en `CacheDirectory`; no `Hint` y `Placeholder` distintos en Android) 4,65 —
CA-4, CA-8, CA-9; w2 (texto literal en componentes) 2,65. **FIRME w1.**

## 7. Discrepancias entre comisiones que van al jurado

| # | Tema | Posiciones | Lectura de esta silla |
| --- | --- | --- | --- |
| X-1 | Campo de la página | CA-1: `audience` pasa a IDs (migra 283 archivos). CA-3, CA-4, CA-6: campo nuevo `audiencias`, `audience` queda | Campo nuevo (b3): mismo poder, sin migración forzada |
| X-2 | Cruce de alcance en `docs-guard` (hipótesis §6.3) | CA-1 y CA-9 lo ponen en `docs-guard`; CA-2 y CA-3: prueba del producto, el repo no tiene valores | Producto + barrido de literales (g1) |
| X-3 | Traza del microtexto | Ficha (CA-1, CA-4) · catálogo (CA-6, CA-8) · `<comment>` del recurso (presidencia, CA-9) | Ficha por defecto; catálogo como opción (p2) |
| X-4 | Ensanchar exposición de API | H una vez (presidencia) · H por cada cambio que ensancha (CA-2, CA-3) | H por cambio (f1) |
| X-5 | Nombre de `TEM-04` y cap. 8 | «Lectura por agentes» (CA-5) · «Canales para personas y agentes» (CA-1) · se integra (CA-2) | Tema propio; el nombre es editorial |
| X-6 | Capítulos nuevos | 1, 2 o 3 capítulos (A-13) | Empate; recomendación k2 con condición |
| X-7 | Escala de puntuación de las comisiones | CA-6 da a su propia propuesta 3,60 < H 3,70; CA-5 empata H y A1 | Las escalas K1–K7 de `Como-Decidir` no miden seguridad ni cumplimiento del pedido: por eso esta silla usó los siete criterios del despacho |
| X-8 | Procedimiento | CA-1 declara haber recibido la hipótesis §6 en su encargo, contra la ceguera de `F300` §7 (`F310` §6) | Lo evalúa el refutador; no cambia puntajes aquí |

## 8. Impacto: qué rehacer y en qué orden

### 8.1 Cuerpo (`SDEI/`)

| Pieza | Cambio | Pregunta |
| --- | --- | --- |
| `99-Anexos/Glosario.md` | Altas: audiencia, regla de entrega, nivel de acceso, punto de aplicación, alcance, superficie, lector, identificador de contexto, microtexto, capa; «Rol» remite a audiencia; «Doble audiencia» como nombre anterior | A-01, B-01 |
| `00-Marco.md` §2.5 | «Audiencias» → «Audiencias típicas»; «agente» sale a la columna lector; filas «Superficies» y «Canales de ayuda»; regla del paquete: sólo `publico` | A-03, A-09 |
| `00-Marco.md` §4 | Quién decide exponer o ensanchar (H); desarrollo decide clave y ubicación del microtexto, no su letra | A-07, B-04 |
| `99-Anexos/Esquema-Frontmatter-Y-Prefijos.md` | Campos `audiencias`, `contexto`, `superficie`, `alcance` (tipo); prefijo `AUD-`; `doc_type` del registro | A-02, B-07 |
| `TEM-04` | Agente como lector que hereda la audiencia de su usuario; filtro único; `canal_agente`; MCP; trifecta | A-04, A-10, B-10 |
| `TEM-05` | `roles` → `audiencias` con jerarquía; alcance genérico/instanciado; superficies; sección «Ayuda en el punto de uso» (capas, interpolación, anclas desde la ficha, contexto, plataformas) | A-05…A-09, B-01…B-08 |
| `TEM-06` | Las familias de §5 A-11 con condición de bloqueo y par | A-11, B-05 |
| `99-Anexos/Referencias.md` | Fuentes de los informes, reabiertas por el refutador | — |
| `Examples/Prueba-Ayuda-Por-Rol/` | m1 | A-15, B-12 |

### 8.2 Conocimiento `K` (1.2 → 1.3)

D-18 nueva «Audiencias y entrega» (registro, nivel, punto de aplicación, `cumple`, `canal_agente`, exposición H por
cambio); D-01 inventaría audiencias, alcances, documentos OpenAPI y superficies; D-13 suma «en el punto de uso»
(ninguno · recursos con anclas desde la ficha · catálogo) y quita «no se ancla»; §2.3 remite a D-18; A-01 lleva la
sección de audiencias; A-03 cierra `audiencias` al registro y deja `audience` como orientación. Controles: los de
§5 A-11 en la tabla de bloqueo.

### 8.3 Libro (`F099` §5.2)

Parte III de dos a cuatro capítulos (k2): 7 «Audiencias y entrega», 8 «Lectura por agentes», 9 «Ayuda al usuario
final», 10 «Ayuda en el punto de uso»; renumeración de los siguientes; 1.5 reescrito; 3.2 con la fila nueva; cap. 14
(caso de estudio) con la PoC-R extendida; cap. 18 con casos de portales y la API por exposición; anexos A
(glosario), C (esquema) y G (plantilla del registro). El lote L3 sigue suspendido hasta `F399`.

### 8.4 Ensayos

Se re-sellan **sólo** los oráculos de casos con roles, API o formulario (l1), después de publicar `K` 1.3 y antes de
sellar la ronda 3 de `F204` §9. El criterio de caso no cambia. **No hace falta ronda adicional**: la ronda 3 prevista
corre con 1.3.

### 8.5 Orden de PRs

| # | PR | Repositorio | Depende de |
| --- | --- | --- | --- |
| 1 | Vocabulario: glosario, Marco §2.5/§4, esquema de frontmatter (campo nuevo, sin migración) | `LD` | `F399` |
| 2 | Temas: `TEM-04`, `TEM-05` (con sección de punto de uso), `TEM-06` (controles declarados como «propuestos» hasta 3) | `LD` | 1 |
| 3 | Expediente de herramienta: resolvedor `.resx`/JSON Schema, familias de controles con fixtures rojo/verde | `LD` (`docs-guard`) | 2 |
| 4 | Ejemplo: PoC-R extendida (m1) con pruebas negativas | `LD` | 3 |
| 5 | `K` 1.3 (D-18, D-01, D-13, §2.3, A-01, A-03) citando líneas de 1–4 | conocimiento | 4 |
| 6 | Oráculos re-sellados y ronda 3 | ensayos | 5 |
| 7 | Libro: lotes de Parte III y afectados | `LD` | 2 y 6 (cap. 18.6) |

## 9. Fuentes externas reabiertas hoy (2026-11-02)

| Fuente | Qué dice (literal) | URL |
| --- | --- | --- |
| Microsoft Learn, *Generate OpenAPI documents* (actualizado 2026-10-29) | «The OpenAPI endpoint doesn't enable authorization checks by default»; «Any endpoint that hasn't been assigned a group name is included in all OpenAPI documents»; documentos por «Audiences, such as public and internal APIs» | https://learn.microsoft.com/en-us/aspnet/core/fundamentals/openapi/aspnetcore-openapi |
| GOV.UK Design System, *Text input* | «Use hint text for help that's relevant to the majority of users»; «Do not use links in hint text»; «Do not use placeholder text in place of a label, or for hints or examples» | https://design-system.service.gov.uk/components/text-input/ |
| OWASP GenAI, *LLM06:2025 Excessive Agency* | «actions taken on behalf of a user are executed on downstream systems in the context of that specific user and with the minimum privileges necessary» | https://genai.owasp.org/llmrisk/llm062025-excessive-agency/ |
| Mintlify, *Authentication setup* | Usuario sin el grupo requerido: «will receive a 404 error»; con autenticación parcial, `llms.txt` «reflecting public pages only» y mapa del sitio «listing public pages only» | https://www.mintlify.com/docs/deploy/authentication-setup |

Las demás fuentes se citan **por el informe que las trajo**, con la fecha de consulta de esa comisión; esta silla no
las reabrió y no las presenta como verificadas por ella.

## 10. Lo no verificado, incidencias y mensajes

- ISO/IEC/IEEE 26514 3.1.7 (definición de audiencia): citada por CA-1 sobre el FDIS; **sin verificar** la edición
  publicada.
- Formato `{0}`/`{1}`/`{2}` de `StringLength`, soporte de `aria-describedby` en `ValidationMessage`, exportación de
  contenido de Pendo: **sin verificar** (lo declaran CA-8 y CA-9).
- Los puntos de celda son juicio de esta silla; se recalculan con §5–§6.
- Incidencia: corte de energía el 2026-11-01; el folio se redactó el 2026-11-02. El despacho mencionaba siete
  informes; había nueve y se usaron los nueve.
- Mensajes de otras sesiones durante la redacción: ninguno.

## 11. Barrido de lo privado

El servicio va como `{servicio-privado}`, el directorio de trabajo como `{dir-de-trabajo}`; sin nombres de máquina
ni rutas absolutas del sistema de archivos. Resultado esperado del barrido sobre este archivo: 0 coincidencias.
