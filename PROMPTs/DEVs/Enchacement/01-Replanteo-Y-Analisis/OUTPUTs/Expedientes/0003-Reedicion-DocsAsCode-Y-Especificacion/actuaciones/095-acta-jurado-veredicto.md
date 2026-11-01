---
doc_id: EXP0003-F095
doc_type: informe
title: Acta del jurado de veredicto — votos de las tres miradas sobre P-01 a P-28, recuento, alternativa ganadora y ataques sin número de pregunta
status: vigente
origin: agent
confidence: alta en los votos (transcriptos de la salida estructurada de cada juez) y en el recuento; media en el rótulo de firmeza de cada decisión, que aplica la regla R-06 adoptada por el jurado y queda rotulado como lectura de la presidencia
owner: presidencia de la reedición DocsAsCode (expediente 0003), que redacta y no vota
last_review: 2026-11-01
audience: [presidencia, jurado de veredicto, refutador, análisis de decisiones, comisiones, editores, PO]
traces: [TP:18, TP:42, TP:48, TP:66, TP:70, TP:73, EXP0003-F001, EXP0003-F004, EXP0003-F080, EXP0003-F081, EXP0003-F085]
---

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-01 |
| Autor | Jurado de veredicto, tres miradas (J1 practicidad y simplicidad de mantenimiento; J2 rigor académico y editorial; J3 escalabilidad y aplicación por agentes sin contexto). Redacta el acta la presidencia, que no vota |
| Corrige | — |

Norma y secciones leídas por quien redacta: `KB-privada/Knowledges/Knowledge-Mesa-De-Expertos-A-Pedido.md` 3.1
(`MEP`), mapa de carga, fila «Presidís una mesa», y §2.1, pasos 8 y 10; `KB-privada/Rules/Rule-Mesa.md` 1.1 (`RM`)
§3.5.4 (jurado y veredicto: quórum, mayoría, empate, homogeneidad); `Knowledge-Cadena-De-Consecuencias` 2.0 y
`Knowledge-Excepcion-A-Un-Conocimiento` 2.1 por remisión del mapa de carga. Insumos que leyó el jurado: folios
`F080` (análisis de decisiones A), `F081` (análisis B) y `F085` (refutación, segunda pasada), con remisiones a los
informes `F010`–`F019`. Carta: el texto de cada despacho de juez lo armó el guion del workflow de la mesa y no se
archivó por separado (excepción de §9, igual que en `F004` §11).

# Veredicto del jurado — expediente 0003, ronda 1

## Índice

1. [Cómo vota este jurado](#1-cómo-vota-este-jurado)
2. [Alias y definiciones](#2-alias-y-definiciones)
3. [Recuento y resultado](#3-recuento-y-resultado)
4. [Observaciones de procedimiento](#4-observaciones-de-procedimiento)
5. [Ataques sin número de pregunta que el jurado tomó](#5-ataques-sin-número-de-pregunta-que-el-jurado-tomó)
6. [Condiciones que los votos dejan a la resolución](#6-condiciones-que-los-votos-dejan-a-la-resolución)
7. [Votos de la ronda 1, pregunta por pregunta](#7-votos-de-la-ronda-1-pregunta-por-pregunta)
8. [Observaciones de cada juez](#8-observaciones-de-cada-juez)
9. [Excepciones a conocimientos](#9-excepciones-a-conocimientos)
10. [Lo no verificado e incidencias](#10-lo-no-verificado-e-incidencias)
11. [Barrido de lo privado de este folio](#11-barrido-de-lo-privado-de-este-folio)

---

## 1. Cómo vota este jurado

El jurado de composición (`F004` §5) votó con tres miradas; el de veredicto repite esa forma, con una mirada por
criterio del PO más el rigor que pide el pedido (`TP:73`).

| Juez | Mirada | Pregunta que se hace |
| --- | --- | --- |
| J1 | Practicidad y simplicidad de mantenimiento | ¿Funciona hoy con lo que hay y cuesta poco sostenerlo? |
| J2 | Rigor académico y editorial | ¿La decisión está anclada a la letra del pedido y a una fuente, y el libro resultante funciona como obra de consulta? |
| J3 | Escalabilidad y aplicación por agentes sin contexto | ¿Otro proyecto, o un agente que no estuvo acá, puede aplicarlo sin preguntar? |

**Qué se votó.** Por cada pregunta P-01 a P-28 (`F001` §8), una alternativa de las que trajeron `F080`, `F081` y
`F085`, con fundamento y con la respuesta a cada ataque del refutador que la toca. Además, cada juez dejó
observaciones sobre los ataques que no tienen número de pregunta (§5, §8).

**Regla de recuento.** Mayoría simple entre alternativas: gana la que reúne dos votos de tres (`RM` §3.5.4, «Mayoría
simple», aplicada a tres jueces; ver §9). Si las tres votan distinto, decide la presidencia con el análisis de
decisiones y lo declara. Todo voto llevó fundamento: ninguno queda fuera del recuento.

## 2. Alias y definiciones

| Alias | Qué es |
| --- | --- |
| `TP` | El pedido del PO, `sha256` `da388e9d…74b37`, sin versionar, en el clon principal de `LDD` (no en el worktree; §10) |
| `F0nn` | Folio `mesa/0nn-*.md` de este expediente |
| `MEP`, `RM`, `CDC`, `CPA` | `Knowledge-Mesa-De-Expertos-A-Pedido` 3.1, `Rule-Mesa` 1.1, `Knowledge-Cadena-De-Consecuencias` 2.0, `Knowledge-Conformacion-Pull-Request-Automatico` 2.0, todos de la base de conocimientos de la organización (`KB-privada/`) |
| `LD`, `LDD`, `LG`, `LGD` | Lab-Documentos, Lab-Documentos.Documentacion, Lab-Geometria, Lab-Geometria.Documentacion (públicos) |
| `SDEI/` | `Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/` de `LD` en `0bed863` |
| `GV` | `SDEI/Sistema-Documentador-Tecnico-Guide.md`, la guía obsoleta |
| `{servicio-privado}` · `{dir-de-trabajo}` · `{host-de-pruebas}` · `{etiqueta-runner}` · `<org>` | Como en `F001` §1 y `F081` §2 |

| Término | Significado en esta acta |
| --- | --- |
| Ganadora | La alternativa que reúne dos o tres votos |
| Unanimidad | Los tres jueces votan la misma alternativa, aunque sus fundamentos difieran |
| FIRME / CON REVISIÓN | Regla R-06, que los tres jueces aceptaron (§5): FIRME exige ventaja mayor que el ruido medido entre evaluadores, **tres o más puntos de celda** **[criterio propio del refutador, adoptado]**; si no, CON REVISIÓN con una condición comprobable |
| `R-n`, `C-n` | Ataque y contradicción del refutador (`F085` §4–§7) |
| `L-n` | Fila del lote del PO propuesta por `F085` §9 |

## 3. Recuento y resultado

| P | Tema | J1 | J2 | J3 | Recuento | Ganadora | Firmeza (R-06) |
| --- | --- | --- | --- | --- | --- | --- | --- |
| P-01 | Libro frente a fuentes | A+ | A+ | D | 2–1 | **A+**: edición de lectura con SHA de `LD` por capítulo, sin reformular reglas, control de co-cambio | CON REVISIÓN |
| P-02 | `doc_id` del libro | `DOC-SDEI-LIBRO` | `DOC-SDEI-LIBRO` | `DOC-SDEI-LIBRO` | 3–0 | `DOC-SDEI-LIBRO`, `guia-de-estudio` | FIRME (desempate fuera de la matriz, declarado) |
| P-03 | Partes, orden y anexos | N2 + V2 sin tomos | N2 + V2 sin tomos | N2 + V2 sin tomos | 3–0 | Núcleo de N2 §7 + variante V2 **sin plan de tomos** | Núcleo FIRME; variante CON REVISIÓN |
| P-04 | PR común | C + `mermaid-arroba` | C + `mermaid-arroba` | C + `mermaid-arroba` | 3–0 | `PE`, filas de delegación y control `mermaid-arroba` con fixtures; el resto de `dg.py` a expediente de herramienta | FIRME en la composición; el control sigue la condición de P-20 |
| P-05 | Guía de estilo | M3 | M3 | M3 | 3–0 | M3: cuerpo → RAE y ASALE → Microsoft *Spanish (Neutral)* | FIRME |
| P-06 | `Lanzar-Example` | RWs | SPLIT con ruta | SPLIT con ruta | 2–1 | **SPLIT** con ruta dentro de un `OUTPUTs/` de `LDD`; si saneado no corre, RWs | CON REVISIÓN |
| P-07 | Caso del portal | Reverificado | Reverificado | Reverificado | 3–0 | Reverificado al 2026-11-01, método declarado, APA | FIRME |
| P-08 | Guía obsoleta y versión | X1 + etiqueta | X1 + etiqueta | X1 + etiqueta | 3–0 | X1 con etiqueta anotada antes de borrar `GV` | FIRME |
| P-09 | Delegación del merge | D1 | D1 | D1 | 3–0 | D1: providencia + filas de `CHANGELOG` con la decisión del PO | FIRME |
| P-10 | Commits fuera de `main` | E1 | E1 | E1 | 3–0 | E1: «PR #n, merge `<sha nuevo>`» + nota de equivalencia | FIRME |
| P-11 | Etiqueta de runner | R-B | R-B | R-B | 3–0 | R-B por plataforma; sin renombre | FIRME |
| P-12 | U25 y U26 | U-A′ | U-A′ | U-A′ | 3–0 | U-A′: re-correr sólo los guiones que el libro cita | CON REVISIÓN |
| P-13 | Términos | Separar | Separar | Separar | 3–0 | Separaciones con instrumento; «atraso», «deriva de copia fijada» | FIRME |
| P-14 | `PE` | Patrón de ejemplo | Patrón de ejemplo | Patrón de ejemplo | 3–0 | `PE` = patrón de ejemplo; `PEND-` para pendientes | FIRME |
| P-15 | Traza de la ayuda | SYN | SYN | SYN | 3–0 | SYN | FIRME |
| P-16 | Clases por escenario | COMP | S | S | 2–1 | **S**: composición por unión + fila prescriptiva + anotación por celda + correcciones medidas | Núcleo FIRME; anotación CON REVISIÓN |
| P-17 | Quién decide la fase 1b | Rol `ACT-SDEI-2` | Rol `ACT-SDEI-2` | Rol `ACT-SDEI-2` | 3–0 | Decide el rol; `TEM-02` nombra al ocupante | FIRME |
| P-18 | Aviso programado | R+D | R+D | R+D | 3–0 | R+D | FIRME |
| P-19 | Sitio | S0 | S0 | S0 | 3–0 | S0: captura del render completo en GitHub | FIRME |
| P-20 | Mermaid | R+L | R+L | R+L | 3–0 | R+L | CON REVISIÓN |
| P-21 | Capas A y B | Hecho fechado | Hecho fechado | Hecho fechado | 3–0 | Reescribir con hecho fechado en IA.SDD@`bac7e48` | FIRME |
| P-22 | Prefijo del conocimiento | ANX | ANX | ANX | 3–0 | `ANX-SDEI-ESPECIFICACION`, `doc_type: anexo` | FIRME |
| P-23 | Forma del conocimiento | E+ | E+ | E+ | 3–0 | E+ | FIRME |
| P-24 | Neutralidad | N-T | N-T | N-T | 3–0 | N-T, fundado en `TP:18` | FIRME |
| P-25 | Métrica | e | e | e | 3–0 | e con umbral sellado; C0 como agregado | CON REVISIÓN |
| P-26 | Oráculo | O3 | O3 | O3 | 3–0 | O3 como agregado; par `LG 4b114d7` + `LGD b47d22b` | CON REVISIÓN |
| P-27 | Dónde viven los ensayos | G-c | G-c | G-c | 3–0 | G-c | FIRME |
| P-28 | Escalón 2 | No mezclar | No mezclar | No mezclar | 3–0 | No mezclar; «escalón 2», nunca «G2» | FIRME |

**Totales.** 28 preguntas con ganadora. 25 unánimes y 3 por 2–1 (P-01, P-06, P-16). Ningún triple empate: la
presidencia no tuvo que desempatar. Por la regla R-06, 8 decisiones quedan CON REVISIÓN en todo o en parte (P-01,
P-03 variante, P-06, P-12, P-16 variante, P-20, P-25, P-26) y 20 FIRME.

**Dónde el jurado se apartó de los análisis.**

| P | `F080` o `F081` recomendaba | Ganó | Por qué (votos) |
| --- | --- | --- | --- |
| P-01 | D, edición ensamblada (`F080`) | A+ | `F085` R-04 y R-04a: dos celdas de D fuera de su ancla; `TP:42` pide editar el documento unificado. J3 votó D y aceptó bajar K4, no la inversión |
| P-03 | V2 con plan de tomos (`F080`) | V2 sin tomos | R-07: `TP:48` pide «un solo documento». Unánime |
| P-04 | Núcleo C «nada de `dg.py`» FIRME (`F080`) frente a C + control (`F081`) | C + `mermaid-arroba` | R-05, salida (a). Unánime |
| P-08 | X1 con enlace al SHA (`F080`) | X1 con etiqueta | R-10: `GV:27` pide la «versión archivada»; un SHA ya resultó no ser permanente en `LD`. Unánime |
| P-12, P-20, P-26 | FIRME con ventaja 2 (`F081`) | Misma alternativa, CON REVISIÓN | R-06. Unánime |

## 4. Observaciones de procedimiento

### 4.1 Lo que se cumplió

- Cada voto trae alternativa, fundamento con cita y respuesta a la refutación que lo toca.
- Los tres jueces verificaron por su cuenta líneas del pedido (`TP:18`, `:42`, `:48`, `:66`, `:67`, `:70`, `:73`)
  con `cat -n` y la huella (J1, J2). La presidencia repitió la medición al redactar: `sha256sum` da
  `da388e9dc72c2ce0d379f65fd1c5a5f8048f9b26694b056af60a329d44f74b37`, igual a `F001` §10.
- Los tres declaran que no escribieron archivos, que no usaron git y que no recibieron mensajes de otra sesión.

### 4.2 Homogeneidad

`RM` §3.5.4 marca el ciclo como sospechoso de homogeneidad si el jurado vota igual en más del 80 % de los ítems. Acá
la unanimidad es de 25 de 28 (89 %): **la marca aplica**. La regla manda que el refutador revise los `NO_PROCEDE`; no
hay ninguno, porque se votaron alternativas y no procedencia. Lo que la presidencia constata en su lugar:

| Comprobación | Resultado |
| --- | --- |
| ¿Las unanimidades coinciden con ataques no resueltos? | No. Las 25 unánimes son preguntas que `F085` §6.1 dio por SOSTIENE, o cuyo ataque (R-05, R-06, R-07, R-10, R-11 a R-17) los tres jueces aceptaron con el mismo efecto |
| ¿Dónde se partió el voto? | En las tres preguntas donde los análisis tenían el margen más chico o el refutador invirtió (P-01: REFUTA; P-06 y P-16: variantes con margen 0,10) |
| ¿Mismo modelo en los tres jueces? | Sí. Es el riesgo que la regla nombra («Dos agentes del mismo modelo tienden a coincidir») y queda declarado |

La resolución (folio 099) no reabre ninguna unanimidad por esta marca; deja el riesgo en su bloque de cierre.

### 4.3 Diferencias de fundamento dentro de una unanimidad

| P | Diferencia | Efecto |
| --- | --- | --- |
| P-04 | J2 dice que el núcleo «no se rotula FIRME tal como lo escribió `F080`»; J1 y J3, que el dictamen va «en una sola frase» con P-20 | Ninguno sobre la ganadora. La resolución escribe P-04 y P-20 en una frase (R-05) |
| P-12 | J1 condiciona: «si U-B se midiera igual de verde en K4, se reconsidera»; J3: «si una corrida no reproduce la salida que cita el libro, se corrige la cita en el mismo PR» | Las dos condiciones son comprobables y compatibles; la resolución las suma |
| P-20 | J1: «si el control da falsos positivos en el primer mes de PR con diagramas, se retira»; J3: «si los fixtures de `F011` no reproducen 2 de 28 sin falsos positivos, el control no entra y rige L» | La de J3 es de entrada; la de J1, de revisión. Se suman |
| P-26 | J3 agrega: «si O3 y el borrador N4 §4 difieren en más de ⌊0,15·n⌋ filas, se folia la diferencia antes de correr C1» | Compatible; la resolución la adopta |
| P-06 | J1 votó RWs con el mismo procedimiento reescrito; J2 y J3, SPLIT con la ruta fijada por R-11 | Gana SPLIT; la presidencia fija la ruta (R-11) y la caída a RWs queda como condición |
| P-16 | J1 votó COMP sin anotación, porque la condición de revisión de `F080` («si P-26 fija un oráculo que no sale de la fila del Marco») se cumple con O3 | Gana S. La condición de `F080` dice «en la edición siguiente»: la anotación entra ahora y se revisa en la próxima edición |

## 5. Ataques sin número de pregunta que el jurado tomó

| Ataque | J1 | J2 | J3 | Lo que deja a la resolución |
| --- | --- | --- | --- | --- |
| R-01 (P0): nombres de máquina en el `main` público de `LDD` | PR correctivo hacia adelante con alias, lo decide la mesa; la historia, al lote del PO | Igual; fila L-1 | Igual; además, la presidencia elige entre ficha de excepción y limpieza de `00-Marco.md:170` en `LDD` | Unánime en las dos primeras partes. La tercera la pide J3 y la decide la presidencia |
| R-02 y C-1 (P1): finalidad de `TP:70` y mitad «nuevos» de `TP:18` | Declarar si se prueba o abrir P-29 | Abrir P-29 o declarar con motivo | Abrir P-29 o declarar con motivo | Unánime en que el dictamen no puede callar; ninguno elige entre las dos salidas |
| R-03 y C-6 (P1): «crear ejemplos» (`TP:73`) | Nombrar quién crea ejemplos | Los editores de contenido, con la silla académica como consultora; primer hueco `ESC-SDEI-3` | Igual que J2 | Dos jueces nombran al aplicador; J1 pide que se nombre. La resolución lo asienta |
| R-06: regla de firmeza | Acepta (aplica CON REVISIÓN en P-12, P-20, P-26) | Acepta la regla (≥ 3 puntos de celda) y pide declarar qué método rige | Acepta la regla y lo mismo | Unánime |
| C-3: registro por intervención como agregado | — | Marcarlo como agregado | — | La resolución lo marca |
| R-16: cómo se nombra la base de conocimientos | Acepta que la fije la presidencia | Igual | Igual | Unánime: la fija la presidencia |
| XC-1 (`F019` §7.1): choque de A+ con «un dato en un solo documento» | — | La admite como candidata con el camino SHA por capítulo + co-cambio | — | La resolución la trata en «Excepciones» |

## 6. Condiciones que los votos dejan a la resolución

| # | Condición | Pedida por | Pregunta |
| --- | --- | --- | --- |
| K-1 | Reabrir D sólo si un guion de ensamblado con reescritura de enlaces se mide verde en PR-1 a PR-5 y en menos de 150 líneas | J1, J2 (J3 la escribe al revés: si D falla, A+) | P-01 |
| K-2 | Si la captura de P-19 muestra que GitHub no dibuja el libro entero, va al PO como pregunta de una línea (L-2) | J1, J2, J3 | P-03, P-19 |
| K-3 | P-04 y P-20 se escriben en una sola frase; el pin de `LDD` es fila del lote | J1, J2, J3 | P-04, P-20 |
| K-4 | La ruta del tool-prompt saneado queda dentro de un `OUTPUTs/` de `LDD`; si saneado no corre, RWs | J2, J3 | P-06 |
| K-5 | El proveedor del caso de P-07 se nombra sólo en el libro y en las referencias | J1, J2, J3 | P-07 |
| K-6 | Etiqueta anotada sobre el commit que contiene `GV` antes de borrarla; los enlaces a la versión archivada apuntan a ella | J1, J2, J3 | P-08 |
| K-7 | Las condiciones de §4.3 para P-12, P-20 y P-26 | J1, J3 | P-12, P-20, P-26 |
| K-8 | Si el PO aprueba la copia a la base (AG-3), se mide `ANX` contra la compuerta de la base antes de copiar | J1, J2, J3 | P-22 |
| K-9 | El umbral de P-25 se sella antes de correr; C0 sólo corrige el oráculo; C0 y O3 van marcados como agregados | J1, J2, J3 | P-25, P-26 |
| K-10 | La corrigenda del estado del escalón 1 (folios 290 y 259 del 0002) se recomienda a la presidencia del 0002 | J2, J3 | P-28 |
| K-11 | El nivel 3 de P-05 se toma por la lengua, no por el alcance | J1, J2, J3 | P-05 |

## 7. Votos de la ronda 1, pregunta por pregunta

Transcriptos de la salida de cada juez. Se respeta el texto; sólo se quitan las comillas de escape del formato de
origen.

### P-01 — Relación entre el libro y los documentos fuente

- **J1.** *Alternativa:* A+: edición de lectura con SHA de LD por capítulo (colofón/anexo de correspondencia), el
  libro no reformula reglas ni umbrales, control de co-cambio libro↔fuente; CON REVISIÓN (se reabre D sólo si un
  guion de ensamblado con reescritura de enlaces se mide verde PR-1 a PR-5 y en menos de 150 líneas). *Fundamento:*
  Desde el mantenimiento, A+ funciona hoy con lo que hay; D agrega guion, manifiesto y control, deja 36 enlaces rotos
  sin reescritura (F018 §7) y no se midió dónde vive el guion ni si la compuerta lo tolera (F080 §11). TP:42 pide «que
  los editores editen un documento unificado» (verificado con cat -n, huella da388e9d…74b37), y D declara el archivo
  final «no se edita a mano». Con las celdas K4 y K6 de D llevadas a su ancla, A+ gana o empata en las tres pruebas
  (F085 §6.2, V16, V18). *Refutación:* Acepto R-04 y R-04a (F085 §4 y §6.2): las dos celdas de D estaban fuera del
  ancla del propio F080, y TP:66 no sirve para decidir entre las dos.
- **J2.** *Alternativa:* A+: edición de lectura con colofón y SHA de LD por capítulo, el libro no reformula reglas ni
  umbrales, control de co-cambio libro↔fuente; CON REVISIÓN: se reabre D sólo si el guion de ensamblado con
  reescritura de enlaces se mide en verde PR-1 a PR-5 y en menos de 150 líneas. *Fundamento:* El pedido dice «que los
  editores editen un documento unificado» (TP:42, verificado hoy) y le aplica cuatro rondas de libro (TP:64-67); con
  D el archivo unificado lleva «no se edita a mano» y las rondas de estilo y ortotipografía se dispersan en 19
  fuentes. TP:67 («Errores de la versión diagramada») no discrimina: con A+ el render de GitHub es la versión
  diagramada (F085 R-04a). Las celdas K4 y K6 de D en F080 §6.1 salen de su propia ancla (mdBook deja la salida en
  ./book, no la versiona; F085 V16) y, corregidas, A+ gana o empata en las tres pruebas (F085 §6.2). El colofón con
  SHA es el «ancla de versión» que el cuerpo ya enseña (F017 H10). *Refutación:* Acepta R-04 y R-04a (REFUTA a D).
  Admite XC-1 de F019 §7.1 como ficha candidata con el camino de compromiso SHA por capítulo + control de co-cambio.
- **J3.** *Alternativa:* D, edición ensamblada CON REVISIÓN: un guion arma el libro desde las fuentes según un
  manifiesto, y el archivo armado lleva el rótulo «se edita en las fuentes». Las intervenciones 5 y 6 se hacen sobre
  lo armado y sus correcciones vuelven a la fuente. Si el guion con reescritura de enlaces pasa de 150 líneas o deja
  enlaces rotos en PR-1, se pasa a A+ (nunca a A). *Fundamento:* Mi mirada es la escalabilidad. Ahí D tiene K3=5 y A+
  K3=3 (F080 §6.1). Con A+ quedan unas 50 000 palabras duplicadas (N2 §11), cada PR se corrige dos veces y el costo
  de volver a D crece con cada PR (F080 §6.1, cadena, paso 4). Un agente sin contexto que aplica el cuerpo en otro
  proyecto no va a sostener la corrección doble. TP:48 pide que el documento «reúna» las fuentes, y ensamblar es la
  práctica de mdBook SUMMARY.md, Asciidoctor include y DITA bookmap (F080 §10, X1-X2, consultadas el 2026-11-01). La
  lectura de TP:42 que tomo es «editar el documento unificado a través de sus fuentes, viendo el resultado en el
  mismo PR». *Refutación:* Acepto R-04 en parte. Acepto bajar D·K4 a 4, porque el control de regeneración es local.
  También acepto que TP:66 no discrimina (R-04a). Rechazo la inversión: con K4=4, D sigue adelante con los pesos de
  F080 (3,90 contra 3,80) y empata con pesos iguales (F085 §6.2). Bajar K6 a 4 depende de no versionar la salida, y
  eso se resuelve dentro de D tratando la salida como artefacto de construcción con su comprobación. Que la ventaja
  sea chica justifica el CON REVISIÓN, no el cambio de ganador.

**Resultado:** A+, 2–1. CON REVISIÓN (K-1).

### P-02 — `doc_id` del libro

- **J1.** *Alternativa:* DOC-SDEI-LIBRO, doc_type guia-de-estudio, sin tocar archivos comunes. *Fundamento:* Las dos
  opciones dan verde y no tocan archivos comunes, así que salen empatadas (F080 §6.1). Desempato por univocidad: el H1
  del cuerpo ya se llama «guía de estudio» (W7), y en el mismo repositorio ya funciona el precedente FC-GUIA-LIBRO. Se
  puede revertir sin costo mientras ninguna traza apunte al libro, y hoy no apunta ninguna. *Refutación:* No hay
  ataque: F085 §6.1 SOSTIENE. Acepto la nota de que el desempate se toma fuera de la matriz.
- **J2.** *Alternativa:* DOC-SDEI-LIBRO, doc_type: guia-de-estudio. *Fundamento:* Empate exacto en la matriz (F080
  §6.1, 4,40 y 4,40); el desempate editorial es la univocidad: el H1 del cuerpo entero ya se llama «guía de estudio»,
  así que …-GUIA nombraría igual a la pieza y al conjunto; …-LIBRO sigue el precedente FC-GUIA-LIBRO del mismo repo
  (F080 W7). Las dos pasan la compuerta sin archivos comunes y hoy tienen cero trazas, por lo que es reversible.
  *Refutación:* No hay ataque (F085 §6.1: SOSTIENE); sin objeción.
- **J3.** *Alternativa:* DOC-SDEI-LIBRO, doc_type guia-de-estudio, sin tocar archivos comunes. *Fundamento:* Las dos
  alternativas empatan en 4,40, están medidas en verde y no tocan archivos comunes (F080 §6.1, P-02). Para replicar
  en otros proyectos, «-LIBRO» nombra la pieza y no el cuerpo entero (el H1 del cuerpo ya se llama «guía de
  estudio», F080 W7). Además sigue el patrón que ya funciona en el mismo repo, FC-GUIA-LIBRO. Un agente sin contexto
  distingue mejor «el libro» de «la guía». *Refutación:* No hay ataque. F085 §6.1 SOSTIENE el desempate.

**Resultado:** `DOC-SDEI-LIBRO`, 3–0.

### P-03 — Partes, orden y anexos

- **J1.** *Alternativa:* Núcleo de N2 §7 (prólogo, partes I-VI, caps. 1-18, anexos A-J, orden TEM-01→07) con
  Diátaxis por capítulo, software con versión como sección del anexo B y sección «de la explicación al
  conocimiento»; variante V2 SIN plan de tomos (unicidad de encabezados, portada/colofón con SHA y «Cómo citar»,
  anexo A glosario-índice). *Fundamento:* V2 paga una sola vez 49 encabezados y 43 enlaces (F012, medido). A cambio
  evita que el lector caiga en un capítulo equivocado sin ver ningún error, que es P1. Sumar el software al anexo B
  evita abrir un anexo nuevo. El plan de tomos contradice TP:48 («en un solo documento»; línea verificada), así que
  sale. Si el render falla, el PO decide si se parte. *Refutación:* Acepto R-07 (F085 §6.5): los tomos salen de V2.
  Si la captura de P-19 muestra que GitHub no dibuja el libro entero, eso es un obstáculo y va al PO como pregunta de
  una línea.
- **J2.** *Alternativa:* Núcleo N2 §7 (prólogo, partes I-VI, cap. 1-18, anexos A-J, orden TEM-01→07) + V2 SIN plan
  de tomos: Diátaxis por capítulo, encabezados únicos, software con versión como sección del anexo B, portada y
  colofón con equivalencias de nombre, SHA de fuentes y «Cómo citar» (APA 7), anexo A como glosario-índice
  alfabético, figuras numeradas «Figura c.n» con pie. *Fundamento:* Es el aparato mínimo de una obra de consulta que
  F017 midió ausente: 7 títulos repetidos y 43 enlaces a anclas que GitHub sufija sin error (F012), glosario fuera de
  orden (F017 H07), título sin aparición en el texto (H03), 21 figuras sin número (H11). El plan de tomos contradice
  «en un solo documento» (TP:48) y cae por el filtro F-C del propio F080 §4.4; si la captura del render falla, es un
  obstáculo del PO, no de la mesa. *Refutación:* Acepta R-07 (DEBILITA): el plan de tomos sale de V2 y queda como fila
  L-2 condicional del lote del PO.
- **J3.** *Alternativa:* Núcleo N2 (prólogo, partes I-VI, capítulos 1-18, anexos A-J, orden TEM-01→07), Diátaxis por
  capítulo, «Software» con versión en el anexo B y la sección «de la explicación al conocimiento», con la variante V2
  sin el plan de tomos. *Fundamento:* La unicidad de encabezados es lo que más le sirve a un agente sin contexto. Hay
  7 títulos repetidos 7 veces y 43 enlaces a anclas que GitHub sufija en silencio (F012, citado en F080 §6.1). Esos
  son errores invisibles para quien navega por ancla. El glosario-índice y el «Cómo citar» con SHA de las fuentes
  (F017 H03, H10) hacen que la obra se pueda consultar fuera de este repo. Diátaxis por capítulo evita rotular mal la
  parte V, que es mixta (F-D). *Refutación:* Acepto R-07. TP:48 pide «un solo documento», así que el plan de tomos
  sale de V2. Si la captura de P-19 muestra que el archivo único no se dibuja entero, eso es un obstáculo y va al PO
  como pregunta de una línea.

**Resultado:** núcleo de N2 + V2 sin tomos, 3–0. Núcleo FIRME; variante CON REVISIÓN (K-2).

### P-04 — Qué entra en el PR común y cuándo

- **J1.** *Alternativa:* Un solo PR común: PE = patrón de ejemplo en prefijos.txt:24 + filas de delegación en
  CHANGELOG de LD y LDD + control mermaid-arroba con sus fixtures, con constancia de coordinación con FRAMEWORK MAUI
  antes de abrirlo; el resto de dg.py (exclusiones, precedencia de versión, IDs) a expediente de herramienta; subir el
  pin de LDD queda como fila del lote, no en este PR. *Fundamento:* El control está medido: atrapa 2 de 28 diagramas
  rotos, sin falsos positivos y en 39 ms (F011 E-V04/E-V05). Como el PR común igual exige coordinar con FRAMEWORK MAUI
  por la línea de PE, sumarle un control chico cuesta poco y evita que la compuerta dé verde con diagramas rotos. Los
  cambios de comportamiento de dg.py que piden ensayos que no corrieron quedan fuera, en lotes chicos (DORA, citada
  por F011). El dictamen lo dice en una sola frase, sin la doble firmeza contradictoria. *Refutación:* Acepto R-05
  (F085 §6.3) y tomo su salida (a). El núcleo de F080, «nada de dg.py», deja de rotularse FIRME tal como estaba
  escrito.
- **J2.** *Alternativa:* C más mermaid-arroba: `PE` corregido en prefijos.txt:24 + filas de delegación en CHANGELOG
  de LD y LDD + control mermaid-arroba con fixtures rojo/verde en dg.py; constancia de coordinación con FRAMEWORK
  MAUI antes del PR y subida del pin de LDD como fila del lote; el resto de cambios de dg.py a un expediente de
  herramienta. *Fundamento:* Los dos análisis dejaron dos FIRME contradictorios («nada de dg.py» en F080 §6.1 y un
  control en dg.py en F081 §6.7); el dictamen debe decirlo en una sola frase (F085 R-05). El control está medido:
  atrapa 2 de 28 diagramas rotos, 0 falsos positivos, 39 ms (F011 E-V04/E-V05), y el defecto ya apareció en dos
  libros (F017 §4.10). Lo demás de dg.py no tiene ensayo y toca archivo común: va aparte (DORA, lotes chicos, F011).
  *Refutación:* Acepta R-05 en su salida (a) y R-06 sobre el rótulo: el núcleo no se rotula FIRME tal como lo
  escribió F080.
- **J3.** *Alternativa:* C más mermaid-arroba: PE = patrón de ejemplo en prefijos.txt, filas de delegación en
  CHANGELOG de LD y LDD y el control mermaid-arroba con sus fixtures. Antes del PR, constancia de coordinación con
  FRAMEWORK MAUI. La subida del pin de LDD va como fila del lote. El resto de dg.py va a un expediente de herramienta.
  *Fundamento:* Un control determinista en la herramienta común le sirve a todo proyecto que la use, sin depender de
  que el agente sepa que tiene que dibujar localmente. Está medido: atrapa 2 de 28 diagramas, sin falsos positivos, en
  39 ms (F011 E-V04/E-V05, en F081 §6.7). Lo demás de dg.py (B) mezcla tres objetivos y descansa en ensayos que no
  corrieron (F081 §6.1), así que va a su expediente. Los lotes chicos están documentados en DORA, «Working in small
  batches» (F011, consultada el 2026-11-01). *Refutación:* Acepto R-05. El dictamen tiene que decirlo en una frase, y
  elijo la salida (a). Por eso el núcleo de F080 («nada de dg.py») no puede quedar FIRME tal como está escrito.

**Resultado:** C + `mermaid-arroba`, 3–0 (K-3).

### P-05 — Guía de estilo de base

- **J1.** *Alternativa:* M3: convenciones del cuerpo (voseo incluido) → RAE y ASALE (Ortografía 2010, DPD) →
  Microsoft Spanish (Neutral); ante un choque manda el nivel 1. *Fundamento:* Es una sola fila en 00-Marco.md §5 y en
  P.4 del libro, y les da a los editores un árbitro para las dudas de lengua: la errata «enviálo» pasó todas las
  rondas (F015 H10). Es la única opción con guía de la industria en castellano (F080 W12, Microsoft Localization
  Style Guides). Agregar Google no suma nada para el castellano y cuesta un nivel más que mantener. *Refutación:*
  Acepto R-15 (F085 V17): el dictamen dice que el nivel 3 se toma por la lengua y no por el alcance. El ganador no
  cambia.
- **J2.** *Alternativa:* M3: convenciones del cuerpo (voseo incluido) → RAE y ASALE (Ortografía 2010, DPD) →
  Microsoft Spanish (Neutral) Style Guide; manda el nivel 1 donde choque, y el nivel 3 se toma por la lengua, no por
  el alcance. *Fundamento:* Es la única alternativa con norma en la lengua del libro; la Ortografía académica resuelve
  tildes, comillas y mayúsculas que ninguna guía en inglés cubre (F017 §4.4, H08). La precedencia proyecto → guía →
  terceros es la que Google mismo declara (F017 F2). Microsoft define sus guías como de localización (F085 V17), así
  que el argumento de alcance que excluye a Google también le alcanza: el dictamen debe fundarla en la lengua.
  *Refutación:* Acepta R-15 (P3, nota de fundamento; no cambia el ganador).
- **J3.** *Alternativa:* M3: convenciones del cuerpo (voseo incluido), después RAE y ASALE (Ortografía 2010, DPD) y
  después Microsoft Spanish (Neutral). Si chocan, manda el nivel 1. *Fundamento:* Es la única alternativa con norma
  en castellano. La guía de Microsoft lista Spanish (Neutral) (F080 X6, consultada el 2026-11-01) y refuta N6 §5.3.
  Una jerarquía de tres niveles con «manda el 1» se traslada a otro proyecto cambiando sólo el nivel 1. La errata
  «enviálo» (F015 H10) muestra que sin árbitro de lengua los errores pasan. *Refutación:* Acepto R-15 como nota: el
  nivel 3 se toma por la lengua y no por el alcance, porque Microsoft define esas guías como de localización (F085
  V17). El ganador no cambia.

**Resultado:** M3, 3–0 (K-11).

### P-06 — Cómo entra `Lanzar-Example`

- **J1.** *Alternativa:* RWs: el procedimiento genérico se reescribe en la fuente de LD (versiones fijas, variables
  explicadas, sin entorno, remisión a TEM-05 §3.3) y el libro lo trae; el tool-prompt no se conserva como pieza
  aparte. *Fundamento:* Con una sola pieza no hay que mantener dos de acuerdo. En la propia matriz de F080, RWs saca
  4,10 y SPLIT 4,00 (F080 §6.1, tabla P-06). El procedimiento reescrito está medido: compila, «9 páginas, 0 fallas»,
  sin túnel (F012 ensayos 1-2, F013 E4), y los agentes también lo pueden leer en el libro. No se midió que el prompt
  siga corriendo después de sanearlo (F080 §11), y su destino en LDD no tiene ruta permitida. *Refutación:* Acepto
  R-11 (F085 §6.6): fuera de OUTPUTs/, PROMPTs/ de LDD es del PO. Eso refuerza RWs, que no necesita esa ruta.
- **J2.** *Alternativa:* SPLIT con ruta fijada: procedimiento genérico reescrito en la fuente de LD (versiones
  fijas, variables explicadas, sin datos del entorno) que el libro trae en 14.3; el tool-prompt, saneado con alias, a
  una carpeta OUTPUTs/ de LDD; si saneado deja de correr, se descarta (RWs) y lo dice el PR. *Fundamento:*
  Lanzar-Example es otro género (instrucciones imperativas a un agente) con ruta del espacio de trabajo, túneles del
  usuario y versiones `latest` (F017 H05; F080 §6.1 F-A). La reescritura compila con 0 errores y el paso 5 da
  200/302/200/404/200 sin túnel (F012, F013 E4). TP:18 nombra a agentes como consumidores, lo que justifica conservar
  el tool-prompt; pero PROMPTs/ fuera de OUTPUTs/ es del PO (restricción dura), así que la ruta debe quedar fijada.
  *Refutación:* Acepta R-11 (DEBILITA): la ruta va dentro de un OUTPUTs/ o la variante pasa a RWs.
- **J3.** *Alternativa:* SPLIT: el procedimiento genérico se reescribe en la fuente de LD con versiones fijas, sin
  datos del entorno y con remisión a TEM-05 §3.3, y el libro lo trae. El tool-prompt, saneado con alias, va a LDD a
  una ruta dentro de un OUTPUTs/ que fija el dictamen. Si al sanearlo deja de correr, se aplica RWs. *Fundamento:*
  TP:18 nombra a los agentes como consumidores, y el tool-prompt es la única receta para que un agente levante y
  publique la prueba (F080 §6.1, P-06). El procedimiento reescrito está medido: compila con 0 errores, «9 páginas, 0
  fallas» y 200/302/200/404/200 sin túnel (F012 ensayos 1-2, F013 E4). Las versiones fijas son lo que vuelve
  reproducible la receta en otro host (Docker, «Image tags are mutable», F080 W12). *Refutación:* Acepto R-11. Fuera
  de OUTPUTs/, PROMPTs/ de LDD es del PO (restricción dura), así que la ruta se fija dentro de un OUTPUTs/.

**Resultado:** SPLIT con ruta fijada, 2–1. CON REVISIÓN (K-4).

### P-07 — Caso del portal de un proveedor público de notificaciones

- **J1.** *Alternativa:* Reverificado con fecha 2026-11-01, método de conteo declarado y entrada APA; el argumento en
  el patrón y las cifras como datos fechados; va como documentación de quien integra; si al publicar la consulta tiene
  más de 90 días, se repite en ese PR. *Fundamento:* F015 y F017 lo midieron hoy con curl, y tres de las cinco cifras
  cambiaron (F080 §6.1). HISTÓRICO publicaría números que ya no son ciertos. Declarar el método resuelve la diferencia
  179/159, que viene de dos formas de contar. *Refutación:* Acepto R-14: el proveedor se nombra sólo en el libro y en
  las referencias, nunca en los folios del expediente ni junto al servicio privado de notificaciones.
- **J2.** *Alternativa:* Reverificado al 2026-11-01, con método de conteo declarado y entrada APA; el argumento se
  apoya en el patrón y las cifras van como datos fechados; se repite la consulta en el PR si pasan más de 90 días;
  documentación de quien integra, no modelo de ayuda al usuario final. *Fundamento:* El patrón sigue en pie (Markdown
  servido, OpenAPI 3.1 en la línea 60, generador declarado, llms.txt) pero tres de cinco cifras cambiaron, p. ej.
  920 → 834 líneas (F017 H02, curl del 2026-11-01). Rotularlo HISTÓRICO publicaría cifras ya falsas; dos métodos de
  conteo dieron 179 y 159, por eso el método se declara (F080 §6.1). La fuente hoy no tiene entrada bibliográfica (F017
  H02). *Refutación:* Acepta R-14 (P2): el proveedor público se nombra sólo en el libro y en las referencias, no en los
  folios del expediente.
- **J3.** *Alternativa:* Reverificado con fecha 2026-11-01, método de conteo declarado y entrada APA. El argumento va
  en el patrón y las cifras como datos fechados. Va como documentación de quien integra, nunca asociado a
  {servicio-privado}. Si al publicar la consulta tiene más de 90 días, se repite. *Fundamento:* Tres de las cinco
  cifras ya cambiaron (920 a 834 líneas, entre otras; F080 §6.1, P-07). HISTÓRICO publicaría datos falsos a la fecha.
  El patrón (.md servido, OpenAPI 3.1, llms.txt) es lo que otro proyecto puede reutilizar. Las cifras sólo sirven
  fechadas y con su método, porque F015 contó 179 y F017 contó 159 con métodos distintos. *Refutación:* Acepto R-14.
  El proveedor se nombra sólo en el libro y en las referencias, no en los folios del expediente.

**Resultado:** Reverificado, 3–0 (K-5).

### P-08 — Archivado de la guía obsoleta y versión del cuerpo

- **J1.** *Alternativa:* X1 con la enmienda de R-10: libro y archivado de la guía obsoleta en el mismo PR; el cuerpo a
  2.0.0-borrador.1 (frontmatter y tabla del README); las dos trazas de README.md:11 y Guides/README.md:11
  re-apuntadas a IDX-SDEI; antes de borrar la guía, una etiqueta con nombre sobre el commit que la contiene, y los
  enlaces a la versión archivada apuntan a esa etiqueta. *Fundamento:* X1 domina a las otras tres (F080 §6.1), y PR-5
  bloquea si alguien olvida re-apuntar (F014 E5). La etiqueta es un solo comando y sobrevive a una reescritura de
  historia. Que eso pasa lo prueba P-10: la reescritura del 2026-10-29 dejó dos SHA citados fuera de main. Con la
  etiqueta, además, se cumple entera la letra de GV:27, «los enlaces pasan a la versión archivada» (F085 V12).
  *Refutación:* Acepto R-10 (F085 §6.6).
- **J2.** *Alternativa:* X1 con etiqueta: libro y archivado de la guía obsoleta en el mismo PR; el cuerpo pasa a
  2.0.0-borrador.1 (en las dos menciones del README); antes de borrarla, etiqueta anotada con nombre sobre el commit
  que la contiene; las dos trazas se re-apuntan a IDX-SDEI y los enlaces que la citan pasan a la versión archivada por
  la etiqueta. *Fundamento:* La guía obsoleta exige que «los enlaces que lo citan pasan a la versión archivada» (GV:27,
  verificado hoy): un enlace a IDX-SDEI cumple sólo la mitad. Un SHA no es permanente en este repo: P-10 existe porque
  la reescritura del 2026-10-29 dejó 080f158 y fe10086 fuera de main (F014 DS-01); una etiqueta sobrevive a un mapa de
  commits. SemVer §11.4 ordena borrador < borrador.1 (F080 W12), y archivar junto al libro cumple «no delta» (TP:46;
  F017 §4.7). *Refutación:* Acepta R-10 (DEBILITA): se agrega la etiqueta antes del borrado.
- **J3.** *Alternativa:* X1 con etiqueta: libro y archivado de GV en el mismo PR, y el cuerpo pasa a
  2.0.0-borrador.1 en el frontmatter y en la tabla del README. Antes de borrar GV se crea una etiqueta con nombre sobre
  el commit que la contiene, y las dos trazas y los enlaces que pasan a la versión archivada apuntan a esa etiqueta.
  *Fundamento:* X1 domina a las otras tres (F080 §6.1). SemVer §11.4 ordena borrador < borrador.1 (F080 X4, consultada
  el 2026-11-01). En este repo un SHA ya resultó no ser permanente: la reescritura del 2026-10-29 dejó 080f158 y
  fe10086 fuera de main (P-10). Para un agente sin contexto que llega años después, una etiqueta es un nombre
  resoluble que sobrevive a un mapa de commits. *Refutación:* Acepto R-10. GV:27 pide que los enlaces pasen a la
  «versión archivada» (F085 V12), y la etiqueta cubre esa mitad de la letra.

**Resultado:** X1 con etiqueta, 3–0 (K-6).

### P-09 — Cómo se asienta la delegación del merge del 0003

- **J1.** *Alternativa:* D1: providencia en el expediente + fila en CHANGELOG de LD y LDD con la decisión del PO,
  alcance desde el primer merge; conformación manual hasta que conteste (pregunta de una línea, como obstáculo).
  *Fundamento:* CPA §3.1 dice que la delegación «la decide el responsable del producto y se asienta con fecha» (F085
  V14), así que la mesa no se la puede asentar sola. Cuesta una línea del PO y evita que vuelvan a él al menos cinco
  PR en dos repos (F081 §6.2). Es revocable por unidad. *Refutación:* No hay ataque: F085 SOSTIENE. Acepto la nota
  R-17: la celda K6 por analogía con NIST AC-5 baja, y el ganador no cambia.
- **J2.** *Alternativa:* D1: providencia en el expediente + fila de CHANGELOG en LD y LDD con la decisión del PO,
  alcance desde el primer merge; conformación manual mientras no conteste. *Fundamento:*
  Knowledge-Conformacion-Pull-Request-Automatico §3.1 dice que la delegación «la decide el responsable del producto y
  se asienta con fecha» (F085 V14), así que la mesa no se la puede asentar sola (D2 por F-G). Cada delegación vigente
  es por expediente (0001 y 0002 con asiento propio; F081 D-2) y hoy no hay fila del 0003 (F081 W2). Es un obstáculo
  de una línea, no una escalada (CDC §3). *Refutación:* No hay ataque al ganador (SOSTIENE). Acepta R-17 sólo como
  nota: K6 por NIST AC-5 es analogía y baja a 3-4 sin cambiar el ganador.
- **J3.** *Alternativa:* D1: providencia en el expediente y filas de CHANGELOG en LD y LDD con la decisión del PO,
  cuyo alcance incluye el primer merge. Mientras tanto, conformación manual. Al PO va como obstáculo de una línea.
  *Fundamento:* CPA §3.1 dice «La decide el responsable del producto y se asienta con fecha» (F085 V14), así que la
  mesa no puede asentarla sola (D2 queda excluida). Que cada delegación se asiente por expediente (0001 y 0002 tienen
  el suyo, F081 W3) es lo que la vuelve reproducible en otros repos. D4 carga cada PR al PO, en contra de
  LD:CHANGELOG.md:288. *Refutación:* No aplica. F085 SOSTIENE. R-17 baja K6 por la analogía con NIST AC-5, pero el
  margen (0,50) no cambia.

**Resultado:** D1, 3–0.

### P-10 — Cómo se citan los commits fuera de `main`

- **J1.** *Alternativa:* E1: «PR #n, merge <sha nuevo>» (e3841b6 #19, 6878568 #25) + nota de equivalencia con su
  alcance (tools/docs-guard, Guides/Documentacion-Tecnica, scripts, .github). *Fundamento:* Son 8 sustituciones en 4
  temas (F081 W9, confirmado por F085 V10), y el árbol de cada par es idéntico (F014 E8, F019 V7). El guion de
  TEM-07:200 sigue corriendo porque git checkout necesita un SHA. Citar sólo el PR, o refs/pull, rompe la reproducción
  en un clon nuevo. *Refutación:* No hay ataque: F085 SOSTIENE.
- **J2.** *Alternativa:* E1: «PR #n, merge `<sha nuevo>`» (e3841b6 #19, 6878568 #25) con nota de equivalencia que
  declara su alcance (los tres archivos que difieren están fuera de SDEI y tools/). *Fundamento:* Referencias.md:39
  pide fuentes «por versión publicada o por commit», y el número de PR solo no lo cumple (F017 §4.8). Medido: los SHA
  viejos no son ancestros de main y `git diff --stat` con los nuevos da 3 archivos fuera del cuerpo (F017 H04). Son 8
  líneas en 4 temas (F085 V10). El PR da contexto al lector humano y sobrevive a otra reescritura. *Refutación:* Sin
  ataque (SOSTIENE).
- **J3.** *Alternativa:* E1: «PR #n, merge <SHA nuevo>» (e3841b6 #19, 6878568 #25) con una nota de equivalencia que
  declara su alcance (tools/docs-guard, Guides/Documentacion-Tecnica, scripts, .github). *Fundamento:* Un clon nuevo
  no trae refs/pull (E3) y git checkout necesita un SHA. Con E2 deja de correr el guion de TEM-07:200 (F081 §6.3).
  Referencias.md:39 pide citar por versión publicada o por commit. Son 8 líneas en 4 temas (F085 V10, coincide con
  F081). *Refutación:* No aplica. F085 SOSTIENE por muestreo.

**Resultado:** E1, 3–0.

### P-11 — La etiqueta de runner

- **J1.** *Alternativa:* R-B por plataforma: la etiqueta es un parámetro en el conocimiento (Linux; Mac para iOS),
  VER-W09 y F1 sin el literal, workflows intactos; no se renombra ahora (se reabre si cambia la configuración del
  runner o un tercer repo quiere usarla). *Fundamento:* Son tres líneas de texto. Renombrar toca 7 directivas en LD
  (F085 V9) más LDD, LG y el check obligatorio, con una ventana en la que LD no puede fusionar (F011 §3.3). Mantener
  el renombre sale caro y alcanza a otra sesión, y sólo se ganaría un nombre. *Refutación:* Acepto la nota de R-01
  sobre P-11: el costo de dejar el nombre en la etiqueta es marginal frente a lo que ya está publicado. No cambia el
  ganador.
- **J2.** *Alternativa:* R-B por plataforma: la etiqueta como parámetro en el conocimiento (Linux; Mac para iOS),
  VER-W09 y F1 sin el literal, workflows intactos; sin fila al PO por el renombre. *Fundamento:* Renombrar toca 7
  directivas en LD, más LDD y LG, y el único check obligatorio; un job sin runner espera hasta 24 h (F081 §6.4, F011
  §3.3; F085 V9 confirma 7 directivas). La nota sola deja VER-W09 y F1 incumplibles para un caso MAUI, porque iOS
  corre sólo en Mac (F013 H06). Es la alternativa reversible y barata. *Refutación:* Acepta la nota de R-01 sobre
  P-11: el costo «deja el nombre de máquina en la etiqueta» es marginal frente a lo ya publicado, y lo publicado se
  trata aparte (ver observaciones).
- **J3.** *Alternativa:* R-B por plataforma: la etiqueta pasa a ser un parámetro del conocimiento ({etiqueta-runner},
  con Linux y Mac para iOS), VER-W09 y F1 dejan de llevar el literal y los workflows no se tocan. Se reabre si cambia
  la configuración del runner o un tercer repo quiere usar la etiqueta. *Fundamento:* Esta es la pregunta más propia
  de mi mirada. Con el literal, otro proyecto no puede cumplir VER-W09 ni F1, y un caso MAUI necesita un runner Mac
  (Microsoft Learn, iOS «only run on a Mac», F081 §6.4). R-C toca 7 directivas en LD más LDD y LG, además del check
  obligatorio fw-ok, con hasta 24 h de espera (F011 §3.3), y alcanza a la organización. Renombrar no se recomienda,
  así que no se eleva. *Refutación:* Acepto R-01 como nota sobre P-11: el costo de «dejar el nombre en la etiqueta
  pública» es marginal frente a lo que ya está publicado (F085 V4-V5). No cambia la alternativa. R-01 se trata aparte
  (ver observaciones).

**Resultado:** R-B por plataforma, 3–0.

### P-12 — Cierre de U25 y U26

- **J1.** *Alternativa:* U-A′: re-correr antes del libro sólo los guiones que el libro cita (U26 y U25), con salida
  vigente y diff explicado; 04-adopciones.sh rotulado «no reproducido» hasta que corra; CON REVISIÓN (no FIRME).
  *Fundamento:* Cuesta menos de 0,2 s por guion (F011 E-V03). Evita publicar salidas que el dg.py vigente ya no da:
  03-tem03-ancla.sh pasa de errores=3 a errores=5. Un libro que enseña la herramienta vigente no le genera reclamos de
  divergencia al lector. *Refutación:* Acepto R-06: con ventaja de 2 puntos de celda, que cae dentro del ruido medido
  entre evaluadores, el rótulo pasa a CON REVISIÓN. Condición: si U-B se midiera igual de verde en K4, se reconsidera.
- **J2.** *Alternativa:* U-A′, CON REVISIÓN: antes del libro se re-corren sólo los guiones que el libro cita, con
  salida vigente, diff explicado y URL y SHA de LDD; 04-adopciones.sh rotulado «no reproducido» hasta que corra.
  *Fundamento:* Un libro de consulta no puede publicar salidas que la herramienta vigente ya no da: 03-tem03-ancla.sh
  pasó de errores=3 a errores=5 por el control id-duplicado (F011 E-V03), y cuesta menos de 0,2 s por guion. La salida
  histórica no se pierde: queda citada con el SHA equivalente (P-10). La ventaja es de 2 puntos de celda, dentro del
  ruido medido entre evaluadores (F085 R-06). *Refutación:* Acepta R-06: no cambia el ganador, pero el rótulo pasa de
  FIRME a CON REVISIÓN.
- **J3.** *Alternativa:* U-A′ CON REVISIÓN: antes del libro se corren U26 y U25 de los guiones que el libro cita, con
  salida vigente y diff explicado contra la histórica, que queda citada con su SHA equivalente. 04-adopciones.sh se
  rotula «no reproducido» hasta que corra. Condición: si una corrida no reproduce la salida que cita el libro, se
  corrige la cita en el mismo PR. *Fundamento:* Un agente sin contexto repite el guion contra main y tiene que obtener
  lo que el libro dice. Con U-B no pasa: 03-tem03-ancla.sh pasa de errores=3 a errores=5 por id-duplicado (F011
  E-V03). Cada guion cuesta menos de 0,2 s (F081 §6.5). *Refutación:* Acepto R-06. La ventaja de 2 puntos de celda
  está dentro del ruido medido en P-04, así que el rótulo pasa de FIRME a CON REVISIÓN. El ganador no cambia.

**Resultado:** U-A′, 3–0. CON REVISIÓN (K-7).

### P-13 — Términos con dos o más sentidos

- **J1.** *Alternativa:* Adoptar las separaciones, cada sentido con su instrumento: «letra» = lo que la app promete
  (se corrige TEM-01:283-284); «atraso» = SHA frente a main; «deriva» = contenido frente a código; «deriva de copia
  fijada» = copia cuya huella cambió (alias en el glosario hasta que el expediente de herramienta renombre
  semanal.sh:15); compuerta = carril PR, control = uno solo, compuerta de escalón = hito; PR-7 «fijadas y referencias»
  y «siete grupos más autoprueba». *Fundamento:* «Atraso» y «deriva de copia fijada» son los nombres que ya usa la
  herramienta (semanal.sh:14-15, TEM-06:101-102; F080 W2-W3, confirmado por F085 V8). Así se reescriben 12 líneas de
  prosa sin tocar ningún archivo común. Es texto y se puede revertir. Cierra la lectura divergente que F010 H02 midió.
  *Refutación:* No hay ataque: F085 SOSTIENE.
- **J2.** *Alternativa:* Adoptar las separaciones con instrumento: «letra» = lo que la app promete (se corrige
  TEM-01:283-284); «atraso» para SHA frente a main; «deriva de copia fijada» para la copia que cambió su huella,
  «deriva» a secas para contenido frente a código; «control» (uno), «compuerta» (carril PR), «compuerta de escalón»
  (hito); PR-7 «fijadas y referencias», siete grupos más autoprueba; todo con entrada en el glosario. *Fundamento:*
  «Atraso» es el nombre que ya usan el instrumento (semanal.sh, control 3; F085 V8), TEM-06:101 y el glosario, así que
  elegir «desfase» dejaría dos nombres para un sentido o tocaría un archivo común (F080 §6.2). La univocidad
  terminológica es requisito de norma (ISO/IEC/IEEE 29148:2018, ISO/IEC/IEEE 24765:2017; F014). La lectura de
  «deriva» del carril como deriva de contenido es la puerta de un P0 medido (F010 H01-H02). *Refutación:* Sin ataque
  (SOSTIENE).
- **J3.** *Alternativa:* Adoptar las separaciones, cada una con su instrumento. «letra» es lo que se promete (se
  corrige TEM-01:283-284). «compuerta» es el carril PR, «control» es uno solo y «compuerta de escalón» es el hito.
  «PR-7» es «fijadas y referencias» más autoprueba. «atraso» nombra el SHA frente a main y «deriva de copia fijada» la
  huella cambiada. «deriva» a secas queda para contenido frente a código. *Fundamento:* Un término con dos sentidos es
  un P1 para quien no tiene contexto: el aviso de «deriva» del carril se lee como deriva de contenido (F010 H02). Elijo
  «atraso» porque así lo nombra el instrumento (semanal.sh:14, TEM-06:101, Glosario.md:48; F080 W2-W3), lo que evita
  tocar un archivo común. ISO/IEC/IEEE 29148:2018 (unambiguous) y 24765:2017 respaldan la regla. *Refutación:* No
  aplica. F085 SOSTIENE (V11 coincide: 12, 4 y 31).

**Resultado:** separaciones con instrumento, 3–0.

### P-14 — Qué significa `PE`

- **J1.** *Alternativa:* PE = patrón de ejemplo, corregido en prefijos.txt:24 dentro del PR común; PEND- para los
  pendientes; los PE-1…14 del folio 290 del 0002 no se reescriben. *Fundamento:* La única ocurrencia del otro sentido
  es prefijos.txt:24, contra 25 usos en 7 archivos (F019 V2; F080 W11). Como la regla dice «manda el archivo»,
  corregir una sola línea es lo más barato. *Refutación:* No hay ataque: F085 SOSTIENE.
- **J2.** *Alternativa:* `PE` = patrón de ejemplo, corregido en prefijos.txt:24 en el PR común; `PEND-` para
  pendientes; los PE-1…14 del folio 290 del 0002 no se reescriben. *Fundamento:* «Pregunta de evaluación» aparece
  sólo en prefijos.txt:24, y «patrón de ejemplo» tiene 25 usos en 7 archivos (F019 V2; F080 §6.2). Cuatro comisiones
  coinciden. La regla «manda el archivo» haría prevalecer el sentido falso si no se corrige el archivo (F081 D-1).
  *Refutación:* Sin ataque (SOSTIENE).
- **J3.** *Alternativa:* PE = patrón de ejemplo, corregido en prefijos.txt:24 en el PR común. Los pendientes del
  expediente usan PEND-, y los PE-1…14 del folio 290 del 0002 no se reescriben. *Fundamento:* «Pregunta de evaluación»
  aparece sólo en prefijos.txt:24, y «patrón de ejemplo» tiene 25 usos en 7 archivos (F019 V2). La regla «manda el
  archivo» (Esquema…:199-200) haría que un agente sin contexto adopte el sentido que nadie usa. Hay unanimidad de
  F010, F011, F014 y F019. *Refutación:* No aplica. F085 SOSTIENE.

**Resultado:** patrón de ejemplo, 3–0.

### P-15 — A qué traza una página de ayuda y cómo se corrige el ejemplo

- **J1.** *Alternativa:* SYN: TEM-05:48 remite a la tabla por escenario sin rebajar :88; las 7 páginas en castellano
  se retrazan a CU-1000x@versión de la unidad Web en 5f07b12; RRD con rango propio (RD-21…); pregunta de evaluación de
  la mitad «caso de uso»; source.lock recién cuando exista el trabajo de CI con --fuente. *Fundamento:* Con
  source.lock hoy la compuerta da rojo (ROJO errores=8, F015 H03), y eso es P0. Remitir desde :48 evita que la regla
  quede falsa en ESC-SDEI-2 y ESC-SDEI-4 (F080 W10). Todo se hace en el PR de coherencia, sin archivos comunes.
  *Refutación:* No hay ataque: F085 SOSTIENE.
- **J2.** *Alternativa:* SYN: TEM-05:48 remite a la tabla por escenario sin rebajar :88; retrazar las 7 páginas en
  castellano a CU-1000x@versión de la unidad Web en 5f07b12; RRD con rango propio (RD-21…); releer el texto;
  translation_of alineado; pregunta de evaluación en TEM-05; source.lock cuando exista el trabajo de CI con --fuente.
  *Fundamento:* Hoy TEM-05:48 («traza a un RD-») y :88 («RD- y caso de uso de la unidad») se contradicen (verificado
  en 02-Propuesta §9), y el ejemplo viola las dos mitades; dg.py da 9 avisos traza-no-verificable, todos de ese
  ejemplo (F017 H09). Escribir la regla compuesta en :48 la haría falsa para ESC-SDEI-2 y -4 (F080 §6.2). Con
  source.lock sin trabajo de CI se mide ROJO errores=8 (F015 H03), y RD-01 choca (F015 H04). *Refutación:* Sin ataque
  (SOSTIENE).
- **J3.** *Alternativa:* SYN: TEM-05:48 remite a la tabla por escenario sin rebajar :88. Las 7 páginas en castellano
  se retrazan a CU-1000x@versión de la unidad Web en 5f07b12, con RRD de rango propio (RD-21…), se releen y se alinea
  translation_of. source.lock entra cuando exista el trabajo de CI con --fuente. *Fundamento:* Remitir a la tabla por
  escenario escala: la regla compuesta de ESC-SDEI-3 escrita en :48 sería falsa para ESC-SDEI-2 y ESC-SDEI-4 (F080
  §6.1, P-15). Meter source.lock ya da ROJO (errores=8) (F015 H03). Que RD-01 choque y dé rojo (F015 H04) justifica el
  rango propio. *Refutación:* No aplica. F085 SOSTIENE.

**Resultado:** SYN, 3–0.

### P-16 — Qué clases activa cada escenario

- **J1.** *Alternativa:* COMP: composición por unión (una oración en el Marco, respeta 00-Marco.md:58-60) +
  correcciones puntuales medidas (CL-08 y CL-13 en ESC-SDEI-1 y ESC-SDEI-2; XML «prevista» en ESC-SDEI-3; ancla «sin
  etiqueta» de N5 B7); sin anotación celda por celda. *Fundamento:* Para mantener, la oración de unión es la pieza más
  chica: F080 da 4,20 a COMP contra 4,10 a S. La anotación por celda servía para que la fila del Marco no diera
  coincidencias falsas como oráculo, y F080 mismo la vuelve retirable si P-26 fija un oráculo que no sale de esa fila,
  que es lo que voto en P-26 (O3). Agregarla sería una marca más por celda que hay que mantener sin función.
  *Refutación:* No hay ataque: F085 SOSTIENE la síntesis de F080. Me aparto de esa variante porque se cumple la
  condición de revisión que el propio F080 escribió.
- **J2.** *Alternativa:* S: composición por unión (una oración en el Marco) + fila prescriptiva «Clases activas por
  defecto» con altas y bajas con motivo + anotación por celda de lo que el ejemplo no tiene, medido en su SHA +
  correcciones medidas (CL-08 y CL-13 en ESC-SDEI-1 y -2; XML «prevista» en ESC-SDEI-3; ancla «sin etiqueta»).
  *Fundamento:* Si la fila se deriva del ejemplo, sus defectos se vuelven norma: F013 H02 midió CL-03 pedida y
  ausente en el ejemplo MAUI. Sin anotación, la fila usada como oráculo da coincidencias falsas. La unión no agrega
  fases ni filas y respeta 00-Marco.md:58-60 (F080 §6.2). En una obra de consulta la tabla debe decir si es mínimo,
  máximo u observación (F010 H07). *Refutación:* Sin ataque (SOSTIENE).
- **J3.** *Alternativa:* S: composición de escenarios por unión (una oración en el Marco), fila prescriptiva «Clases
  activas por defecto» con altas y bajas con motivo, y anotación por celda de lo que el ejemplo no tiene, medido en su
  SHA. Correcciones: CL-08 y CL-13 en ESC-SDEI-1 y 2, XML «prevista» en ESC-SDEI-3 y CL-03/XML de CL-04 «no presentes»
  en ESC-SDEI-2. *Fundamento:* La composición por unión permite aplicar el cuerpo a un proyecto mixto sin inventar
  filas y respeta «un escenario nunca agrega fases» (00-Marco.md:58-60). La anotación evita que un agente que usa la
  fila como oráculo copie los defectos del ejemplo. F013 H02 midió uno: CL-03 pedida y ausente en MAUI. Cuesta una
  marca por celda, una sola vez. *Refutación:* No aplica. F085 SOSTIENE.

**Resultado:** S, 2–1. Núcleo FIRME; anotación CON REVISIÓN.

### P-17 — Quién decide la fase 1b en `ESC-SDEI-1`

- **J1.** *Alternativa:* Decide el rol ACT-SDEI-2 en todos los escenarios; TEM-02:164-169 nombra al ocupante (en
  ESC-SDEI-1, la responsable de la guía o quien el PO designe por delegación asentada); la clave de EJR-SDEI-05
  contesta con el rol. *Fundamento:* Hoy hay cuatro respuestas distintas (F010 H08, F012 LECT-01), y «docente» choca
  con 00-Marco.md:148 (F080 W9). La regla «un rol, una regla» no exige un cambio por escenario, y alcanza con cambiar
  dos o tres líneas. *Refutación:* Acepto R-17: CODEOWNERS es sólo una analogía y K6 baja. El margen de 0,70 o más no
  cambia el ganador.
- **J2.** *Alternativa:* Decide el rol ACT-SDEI-2 en todos los escenarios; TEM-02 nombra a quién ocupa el rol (en
  ESC-SDEI-1, la responsable de la guía o quien el PO designe por delegación asentada); la clave de EJR-SDEI-05
  contesta con el rol. *Fundamento:* Hoy hay cuatro respuestas distintas en el cuerpo (F010 H08, F012 LECT-01), y
  «docente» choca con 00-Marco.md:148 (F080 §6.2). Un rol con una regla y la persona como ocupante es la forma unívoca
  que necesita una clave de ejercicio. Margen dominante en la matriz (4,70). *Refutación:* Acepta R-17 sólo como nota:
  CODEOWNERS asigna revisores por ruta, así que K6 es analogía y baja; el ganador no cambia.
- **J3.** *Alternativa:* Decide el rol ACT-SDEI-2 en todos los escenarios. TEM-02:164-169 nombra al ocupante (en
  ESC-SDEI-1, la responsable de la guía o quien el PO designe por delegación asentada), y la clave de EJR-SDEI-05
  responde con el rol. *Fundamento:* Un rol se transfiere a otro proyecto y una persona no. Hoy hay cuatro respuestas
  (F010 H08, F012 LECT-01), y «docente» choca con 00-Marco.md:148. Cambian tres puntos de texto. *Refutación:* Acepto
  R-17 como nota: CODEOWNERS asigna revisores por ruta y es una analogía, así que K6 baja. El ganador no cambia, con un
  margen mayor o igual a 0,50.

**Resultado:** decide el rol `ACT-SDEI-2`, 3–0.

### P-18 — Qué dice el cuerpo del aviso programado

- **J1.** *Alternativa:* R+D: reescribir lo que hace el carril (cuenta commits de atraso de base_commit y
  source.lock; A1 mide la deriva por símbolo cuando corre la demo) y declarar como deuda que A1 no está programado, con
  evento de cierre; en 00-Marco.md:183-184, 01-Mapa.md:68-70 y Ejercicios.md:112-116 a la vez. *Fundamento:* Cuesta
  una línea y vale con las dos lecturas, descripción o control, porque evita absolver un control que nunca se ejerció
  (MEP:285). Programar A1 toca un workflow común y la cola del runner compartido, y no corrige el texto que hoy es
  falso. *Refutación:* No hay ataque: F085 SOSTIENE.
- **J2.** *Alternativa:* R+D: reescribir lo que el carril hace (cuenta commits de atraso de base_commit y source.lock;
  A1 mide la deriva por símbolo al correr la demo) y declarar como deuda que A1 no está programado, con evento de
  cierre; se reescriben a la vez 00-Marco.md:183-184, 01-Mapa.md:68-70 y Ejercicios.md:112-116. *Fundamento:*
  semanal.sh tiene control 3 «atraso» y control 4 «deriva» de copia, no deriva por símbolo (F085 V8): el texto actual
  es falso. R+D vale con las dos lecturas en disputa, descripción (F010) o control declarado (F013), y evita absolver
  un control no ejercido (F-G). Programar A1 toca un workflow común y no corrige el texto (F080 §6.2). *Refutación:*
  Sin ataque (SOSTIENE).
- **J3.** *Alternativa:* R+D: reescribir lo que el carril hace (cuenta commits de atraso de base_commit y source.lock;
  A1 mide la deriva por símbolo al correr la demo) y declarar como deuda que A1 no está programado, con su evento de
  cierre. Se reescriben 00-Marco.md:183-184, 01-Mapa.md:68-70 y Ejercicios.md:112-116. *Fundamento:* Sirve tanto si el
  texto era descripción como si era control (F010 frente a F013), y no absuelve un control no ejercido (MEP:285). Si
  se programara A1 (P), caería en un workflow común (clase H) y el texto falso seguiría ahí. Un agente sin contexto
  necesita saber qué no se vigila. *Refutación:* No aplica. F085 SOSTIENE y V8 coincide.

**Resultado:** R+D, 3–0.

### P-19 — ¿Hay sitio publicado?

- **J1.** *Alternativa:* S0: sin sitio y sin ensayo MkDocs; una captura del render completo del libro en GitHub en el
  PR del libro. *Fundamento:* Con S0 no se suma ninguna herramienta ni entorno que mantener, y la captura mide el único
  riesgo real: que GitHub dibuje 345 a 407 KB (F017 H01). Material anuncia el fin de vida para el 2027-05-05 (F081
  §6.6). Si el render falla, va al PO como obstáculo. *Refutación:* No hay ataque: F085 SOSTIENE y lo encuentra
  coherente con R-07, que acepto en P-03.
- **J2.** *Alternativa:* S0: sin sitio publicado ni ensayo MkDocs en esta edición; captura del render completo del
  libro en GitHub adjunta al PR del libro. Se reabre si el render falla y el PO no admite partirlo (L-2).
  *Fundamento:* El riesgo medido es que GitHub no dibuje entero un libro de 345-407 KB frente a 400 KB documentados
  (F017 H01), no los slugs de MkDocs. Material for MkDocs anuncia fin de vida el 2027-05-05 (F081 §9, reabierto). Una
  captura es más simple y prueba lo que sí está en riesgo. *Refutación:* Sin ataque (SOSTIENE). Se ajusta la
  condición de reapertura a R-07: partir el libro es del PO.
- **J3.** *Alternativa:* S0: sin sitio y sin ensayo MkDocs, con captura del render completo en GitHub en el PR del
  libro. Si no se dibuja entero, va como obstáculo al PO (¿partir el libro?). *Fundamento:* El riesgo medido es que
  GitHub no dibuje el libro entero: se estiman 345 a 407 KB frente a 400 KB (F017 H01), no los slugs de MkDocs.
  Material anuncia «End of life on May 5, 2027» (F081 §9), así que adoptarlo ahora fija un costo que otros proyectos
  heredarían. Sin una herramienta más, el cuerpo se aplica igual en cualquier repo GitHub. *Refutación:* No hay ataque
  contra S0 (F085 SOSTIENE). Tomo la coherencia con R-07: la condición de reapertura de F081 §6.6 («partir en tomos»)
  pasa a ser la pregunta al PO.

**Resultado:** S0, 3–0 (K-2).

### P-20 — Mermaid: control local o CI

- **J1.** *Alternativa:* R+L: control mermaid-arroba en PR-4 con fixtures rojo y verde (entra al PR común de P-04) +
  dibujado local obligatorio en los PR que tocan diagramas, con su salida en el PR; en LDD rige sólo lo local hasta
  que se suba el pin; CON REVISIÓN. *Fundamento:* El control es determinista y barato: 2 de 28, sin falsos positivos,
  39 ms (F011 E-V04/E-V05). Sólo con lo local, la compuerta da verde con diagramas rotos (F011 V-04), y dibujar en la
  CI pide un navegador en un runner sin contenedores (F085 V13). Así queda consistente con P-04 en una sola frase.
  *Refutación:* Acepto R-05 y R-06: queda una sola frase junto con P-04, y el rótulo pasa a CON REVISIÓN por la
  ventaja de 2. Condición: si el control da falsos positivos en el primer mes de PR con diagramas, se retira al
  expediente de herramienta.
- **J2.** *Alternativa:* R+L, CON REVISIÓN: control mermaid-arroba en PR-4 (dentro del PR común según P-04) +
  dibujado local obligatorio con tools/medios/mermaid.sh sobre el libro completo, con su salida registrada en el PR
  como parte de la corrección de pruebas. *Fundamento:* TP:67 define la corrección de pruebas sobre «la versión
  diagramada», así que un diagrama que parsea pero se dibuja mal es un error de prueba (F017 §4.10). Con L sola, la
  compuerta da verde con dos diagramas rotos (F011 V-04); el control los atrapa sin falsos positivos en 39 ms. La
  ventaja es de 2 puntos de celda, dentro del ruido. *Refutación:* Acepta R-05 (coherente con P-04) y R-06 (rótulo
  CON REVISIÓN).
- **J3.** *Alternativa:* R+L CON REVISIÓN: control mermaid-arroba en PR-4 con fixtures rojo y verde, más dibujado
  local obligatorio en los PR que tocan diagramas, con la salida en el PR. En LDD rige sólo lo local hasta que suba el
  pin. *Fundamento:* Lo que entra a la herramienta se aplica solo en todo proyecto, y lo local depende de la disciplina
  del agente. Con L, la compuerta da verde con dos diagramas rotos (F011 V-04). El dibujado en la CI queda excluido
  porque el runner no tiene contenedores (framework-concept-demo.yml:12, F085 V13). *Refutación:* Acepto R-05, que
  queda coherente con P-04 (a), y acepto R-06: la ventaja de 2 lleva el rótulo a CON REVISIÓN. Condición: si los
  fixtures de F011 no reproducen el resultado de 2 de 28 sin falsos positivos, el control no entra y rige L.

**Resultado:** R+L, 3–0. CON REVISIÓN (K-3, K-7).

### P-21 — «Las capas A y B no existen» en `TEM-07`

- **J1.** *Alternativa:* Reescribir con un hecho fechado: en IA.SDD@bac7e48 hay un conocimiento de lógica de decisión
  1.0 que registra lecciones y dos líneas de norma que mandan correrlo; su lección no tiene los campos «evidencia» ni
  «resultado» que pide TEM-07:176; en LG no hay copia; si son las capas del diseño lo decide el escalón 2; TEM-07:95 se
  ajusta en el mismo cambio. *Fundamento:* Lo verificaron tres sillas por separado en IA.SDD público (F010 H09, F013
  H04, F019 V10-V11). Es la corrección mínima: reemplaza una afirmación falsa por un hecho con SHA, sin afirmar que
  sean lo mismo. Es texto y se puede revertir. *Refutación:* No hay ataque a la decisión: F085 SOSTIENE. Acepto R-16:
  la presidencia fija una sola regla para nombrar la base de conocimientos en todos los folios.
- **J2.** *Alternativa:* SYN, hecho fechado: en IA.SDD@bac7e48 hay un conocimiento de lógica de decisión 1.0 que
  registra lecciones y dos líneas de norma que mandan correrlo; su lección no tiene los campos «evidencia» y
  «resultado» que TEM-07:176 pide a la capa A; en LG sólo hay una aplicación citada; si son las capas del diseño lo
  decide el escalón 2. TEM-07:95 se ajusta en el mismo cambio. *Fundamento:* Tres sillas lo verificaron por separado en
  el repo público (F010 H09, F013 H04, F019 V10-V11): «las capas A y B no existen» ya era inexacta cuando se escribió.
  Un hecho fechado y anclado por SHA, sin afirmar identidad, es la forma rigurosa de corregirlo. El diseño de capas
  está rotulado borrador, así que es descripción (F080 §6.2). *Refutación:* Acepta R-16 (P2) como regla general: la
  presidencia fija cómo se nombra la base de conocimientos y el barrido lo aplica igual a todos los folios. P-21 no
  cambia: cita sólo IA.SDD por SHA.
- **J3.** *Alternativa:* Reescribir con un hecho fechado: IA.SDD@bac7e48 tiene un conocimiento de lógica de decisión
  1.0 cuya lección no tiene los campos «evidencia» ni «resultado» que pide TEM-07:176. No se afirma identidad, y si es
  la capa A lo decide el escalón 2. Se ajusta TEM-07:95. *Fundamento:* Tres sillas lo verificaron por separado en
  IA.SDD público (F010 H09, F013 H04, F019 V10-V11). Un hecho con SHA lo puede comprobar cualquier agente, y una frase
  absoluta como «no existen» no. La frase ya era inexacta cuando se escribió. *Refutación:* F085 SOSTIENE. Remito R-16
  (cómo nombrar la base de conocimientos) a la presidencia: tiene que fijar un criterio único para todos los folios.
  No cambia el ganador.

**Resultado:** hecho fechado, 3–0.

### P-22 — Prefijo y `doc_type` del conocimiento

- **J1.** *Alternativa:* ANX: ANX-SDEI-ESPECIFICACION, doc_type: anexo, version del frontmatter igual a **Versión:**;
  pasa a KNW si aparece un segundo conocimiento en LD o se aprueba la copia a la base, y en ese caso se mide ANX contra
  la compuerta de la base antes de copiar. *Fundamento:* No toca ningún archivo común. KNW da rojo medido con dos
  errores y pide cambiar prefijos.txt y cuerpo.schema.json (F011 E-V01) para una sola pieza. Se puede revertir con un
  rename, porque hoy no apunta ninguna traza (F014). *Refutación:* Acepto R-12: queda la condición de medir ANX contra
  la compuerta de la base si el PO aprueba AG-3.
- **J2.** *Alternativa:* ANX: ANX-SDEI-ESPECIFICACION, doc_type: anexo, version igual a **Versión:**; si el PO aprueba
  la copia a la base (AG-3), se mide ANX contra la compuerta de la base antes de copiar. Pasa a KNW con un segundo
  conocimiento en LD o con la copia aprobada. *Fundamento:* KNW da rojo con dos errores y exige dos archivos comunes,
  prefijos.txt y cuerpo.schema.json (F011 E-V01); ANX no toca ninguno y hoy tiene 0 trazas, así que renombrar es
  barato (F081 §6.8). Nadie midió si la compuerta de la base acepta doc_type: anexo (F085 §10), y eso debe quedar como
  condición, no como supuesto. *Refutación:* Acepta R-12 (DEBILITA el fundamento, no el ganador).
- **J3.** *Alternativa:* ANX: ANX-SDEI-ESPECIFICACION, doc_type: anexo, con version igual a **Versión:**. Se pasa a
  KNW cuando haya un segundo conocimiento en LD o el PO apruebe la copia a la base, y en ese caso ANX se mide antes
  contra la compuerta de la base. *Fundamento:* Hoy no toca ningún archivo común, y KNW da rojo y pide dos
  (prefijos.txt y cuerpo.schema.json; F011 E-V01). Con cero trazas al doc_id, renombrarlo después es barato (F014).
  Desde la escalabilidad, la condición de paso a KNW es lo que evita estirar «anexo» cuando haya muchos conocimientos.
  *Refutación:* Acepto R-12. Agrego la condición de medir ANX contra la compuerta de la base si se aprueba AG-3. Un
  agregado sin aprobar no funda una decisión.

**Resultado:** ANX, 3–0 (K-8).

### P-23 — Forma del conocimiento

- **J1.** *Alternativa:* E+: forma estricta §0-§10 con frontmatter, excepción escrita a «version sólo en el README»
  en 00-Marco.md:161, una línea que diga qué versión manda y version = **Versión:**. *Fundamento:* Es la única forma
  medida en verde en PR-2 y PR-5 (F012 ensayo 4). Sin frontmatter, PR-2 da rojo, y la forma libre deja la prueba de
  reproducción sin contra qué contar (F081 §6.9). Cuesta texto una sola vez y no agrega herramientas. *Refutación:* No
  hay ataque: F085 SOSTIENE.
- **J2.** *Alternativa:* E+: forma estricta §0-§10 con frontmatter y doble cabecera, excepción escrita a «version sólo
  en el README» en 00-Marco.md:161, una línea que diga qué versión manda, y version = **Versión:**. *Fundamento:* Es la
  única medida en verde en PR-2 y PR-5 (F012 ensayo 4). La estricta sin frontmatter da rojo sin-frontmatter, y la forma
  libre pierde la §6 normativa contra la que cuenta la prueba (F081 §6.9). Se funda en el propósito de la forma, no en
  su obligatoriedad fuera de la base (F018; F081 D-7). *Refutación:* Sin ataque (SOSTIENE).
- **J3.** *Alternativa:* E+: forma estricta de la base (§0-§10, frontmatter y once campos), con excepción escrita a
  «version sólo en el README» en 00-Marco.md:161, una línea que diga qué versión manda y version = **Versión:**.
  *Fundamento:* Es la forma que le da a un agente sin contexto «para quién», «cuándo» y la regla de falla (F012,
  F018), y está medida verde en PR-2 y PR-5 (F012 ensayo 4). La forma libre deja la prueba sin norma contra la cual
  contar (K5=1). La fundo en el propósito de la forma, no en que sea obligatoria fuera de la base (F018).
  *Refutación:* No aplica. F085 SOSTIENE.

**Resultado:** E+, 3–0.

### P-24 — Neutralidad respecto de SDD

- **J1.** *Alternativa:* N-T: neutral en todo el conocimiento, apéndice incluido; lo propio de SDD va al libro o a un
  perfil. *Fundamento:* Lo fundo en TP:18: el conocimiento debe aplicarse «en otro contexto diferente» y en proyectos
  nuevos o existentes (línea verificada). Lo propio de SDD tiene su lugar en el libro, y un solo texto neutral tiene
  menos variantes que mantener. La regla es fácil de chequear: cero apariciones del término. *Refutación:* Acepto
  R-12: el fundamento es TP:18 y no la compuerta de la base, que depende de AG-3 sin aprobar. El ganador no cambia.
- **J2.** *Alternativa:* N-T: neutral respecto de SDD en todo el conocimiento, apéndice incluido; lo propio de SDD va
  al libro o a un perfil. *Fundamento:* El fundamento principal es el pedido: el conocimiento es para agentes «en otro
  contexto diferente» y para «nuevos o ya existentes proyectos» (TP:18, verificado hoy). Además, una sola línea con
  «SDD» en un apéndice da FALLA neutralidad rc=1 en la compuerta de la base (F010 §6 E4), así que N-A no cumple ni su
  propio fin. Sin la compuerta de la base, N-T igual gana (4,50 contra 4,17; F085 R-12). *Refutación:* Acepta R-12: el
  fundamento se apoya en TP:18 y no en la compuerta de un agregado sin aprobar.
- **J3.** *Alternativa:* N-T: neutral en todo el conocimiento, apéndice incluido. Lo propio de SDD va al libro o a un
  perfil. *Fundamento:* TP:18 pide que agentes «en otro contexto diferente» lo apliquen «en nuevos o ya existentes
  proyectos», y eso es la neutralidad. Una sola línea con «SDD» en un apéndice da FALLA - neutralidad (1), rc=1 (F010
  §6 E4), y el alias del caso privado dispara \bSDD\b (F012). *Refutación:* Acepto R-12: el fundamento principal pasa
  a TP:18 y no a la compuerta de la base. Sin ella, N-T igual gana (4,50 contra 4,17).

**Resultado:** N-T, 3–0.

### P-25 — Métrica de éxito de la reproducción

- **J1.** *Alternativa:* e: tabla decisión por decisión, las trampas como filas del oráculo, instrumentos de F016,
  umbral entero ≤ ⌊0,15·n⌋ sellado antes de correr, cada corrida pasa sola; C0 corre primero y sólo puede corregir el
  oráculo (con nueva huella), nunca el umbral; C0 marcado como agregado aceptado; CON REVISIÓN. *Fundamento:* Da un
  criterio de paso que se verifica con un comando, sin dejar el «efectivo» a la deliberación (F081 §6.11). Sellar el
  umbral es lo que hace válido el prerregistro: si se lo mueve después de ver C0, se pierde. Es una tabla y un número
  por caso. *Refutación:* Acepto R-13: el umbral queda sellado y C0 se marca como agregado.
- **J2.** *Alternativa:* e, CON REVISIÓN: una sola tabla decisión por decisión, con las trampas como filas del oráculo
  y los instrumentos de F016; umbral entero ≤ ⌊0,15·n⌋ sellado con huella antes de correr; cada corrida pasa sola. C0
  corre primero y sólo puede corregir el oráculo, nunca el umbral; C0 entra marcado como agregado aceptado por el
  jurado. *Fundamento:* Es la única alternativa que da un criterio de paso verificable por comando; la unión (c) deja
  dos definiciones de invención y de verde (F016 H04). El valor del prerregistro es justamente no mover el umbral
  después de ver resultados: permitirlo en C0, como hace F081 §6.11, anula el K6 que lo sostiene (F085 R-13). McHugh
  (2012) trata acuerdo entre evaluadores, no un umbral contra oráculo, así que el umbral queda declarado como [criterio
  propio]. *Refutación:* Acepta R-13 y C-2 (C0 como agregado aceptado), y R-17 en lo que toca a McHugh.
- **J3.** *Alternativa:* e CON REVISIÓN: una sola tabla con las decisiones del caso, una por fila, y las trampas como
  filas del oráculo, con los instrumentos de F016. El umbral entero ≤ ⌊0,15·n⌋ queda sellado con huella antes de
  correr y cada corrida pasa sola. C0 va primero, como agregado aceptado, y en C0 sólo se corrige el oráculo, nunca el
  umbral. *Fundamento:* Un criterio verificable por comando es lo único que permite repetir la prueba en otro proyecto
  sin el jurado de este. Con f el veredicto queda a juicio (F081 §6.11). Una sola unidad evita las dos definiciones de
  invención y de verde (F016 H04). El prerregistro respalda sellar antes (COS, F081 §9). *Refutación:* Acepto R-13: el
  umbral no se mueve después de ver C0, y C0 va marcado como agregado (C-2).

**Resultado:** e, 3–0. CON REVISIÓN (K-9).

### P-26 — Oráculo e insumos de cada caso

- **J1.** *Alternativa:* O3: oráculo escrito antes y con huella por un agente distinto desde el repo del caso en su
  SHA, con N4 §4 y la hoja privada sólo como borrador, bajo O-1 a O-6; Geometría con el par LG 4b114d7 + LGD b47d22b;
  CON REVISIÓN. *Fundamento:* O2 obliga a reverificar N4 §4 contra 4b114d7 de todos modos y mide en parte a su autor
  (F081 §6.12). O3 cuesta un despacho más por caso y es reproducible por terceros, porque la ia-db de b47d22b indexa
  4b114d7. La columna del Marco es circular: es justo lo que la reedición corrige. *Refutación:* Acepto R-06: con
  ventaja 2, pasa a CON REVISIÓN. Acepto C-2: O3 entra como agregado aceptado, con el motivo de no medir al autor.
- **J2.** *Alternativa:* O3, CON REVISIÓN: oráculo escrito antes y sellado con huella por un agente distinto del autor
  del conocimiento, desde el repo del caso en SHA fijo del remoto (Geometría: LG 4b114d7 + LGD b47d22b), con N4 §4 y la
  hoja privada sólo como borrador, bajo O-1 a O-6; O3 entra como agregado aceptado con motivo (no medir al autor).
  *Fundamento:* La columna del Marco es circular, porque la reedición la corrige (F011 V-09), e ISO/IEC/IEEE 29119-1
  define el oráculo como fuente independiente de resultados esperados. N4 §4 se midió sobre 5f07b12, no sobre el par
  elegido, y lo escribió quien diseñó parte del conocimiento (F081 §6.12). 0202722 queda afuera por 209 commits de
  atraso (O-6). La ventaja es de 2 puntos de celda, dentro del ruido. *Refutación:* Acepta R-06 (rótulo CON REVISIÓN)
  y C-2 (O3 marcado como agregado).
- **J3.** *Alternativa:* O3 CON REVISIÓN: oráculo escrito por un agente distinto desde el repo del caso en su SHA, con
  N4 §4 y la hoja privada sólo como borrador, bajo O-1 a O-6 y «sólo commit del remoto». En Geometría se usa el par LG
  4b114d7 + LGD b47d22b (si el PR #3 se cierra sin fusionar, refs/pull/3/head por SHA con copia del índice y su
  huella). 0202722 queda fuera. O3 se marca como agregado aceptado. *Fundamento:* Un oráculo escrito por un agente que
  no diseñó el conocimiento es la medida más cercana a «agente sin contexto», que es lo que TP:18 quiere probar. O2
  mide en parte al autor. O1 es circular, porque la reedición corrige esa columna (ISO/IEC/IEEE 29119-1, oráculo como
  fuente de los resultados esperados; F081 §6.12). *Refutación:* Acepto R-06 (ventaja 2: CON REVISIÓN). Condición: si
  O3 y el borrador N4 §4 difieren en más de ⌊0,15·n⌋ filas, se folia la diferencia antes de correr C1. También acepto
  C-2 (marcar O3 como agregado).

**Resultado:** O3, 3–0. CON REVISIÓN (K-7, K-9).

### P-27 — Dónde viven los ensayos

- **J1.** *Alternativa:* G-c: evidencia de Geometría en evidencia/ del expediente 0003 de LDD, sin PR a LGD (worktree
  descartable de LGD sólo como medio para correr docs-guard); lo del servicio privado de notificaciones sólo en local,
  con cifras y huellas en lo público. *Fundamento:* La evidencia queda en el expediente que la usa, en una carpeta que
  ya existe (F001 §10), sin ramas huérfanas en un repo con otra sesión trabajando. Un PR en LGD quedaría en reserva
  porque ese repo no tiene workflows ni delegación (F011 E-V06). *Refutación:* No hay ataque: F085 SOSTIENE.
- **J2.** *Alternativa:* G-c: la evidencia de Geometría va en evidencia/ del expediente 0003 de LDD, con worktree
  descartable de LGD sólo como medio para correr la compuerta, sin PR a LGD; lo privado, sólo local, con cifras y
  huellas públicas. *Fundamento:* La evidencia vive en el expediente que la usa, y su carpeta ya existe vacía (F001
  §10). Una rama descartable se pierde al borrarla en un repo con PR #2 y #3 en curso de otra sesión (F081 §6.13). Un
  PR en el repo privado cae por F-E y F-A. *Refutación:* Sin ataque (SOSTIENE).
- **J3.** *Alternativa:* G-c: la evidencia de Geometría va en evidencia/ del expediente 0003 de LDD, con worktree
  descartable de LGD sólo para correr docs-guard en su layout, sin PR. Lo del servicio privado queda sólo en local, y
  en lo público van cifras y huellas. *Fundamento:* La evidencia vive en el expediente que la usa y sobrevive a que se
  borre una rama (G-a pierde K4). Un agente que replica el ensayo encuentra en un solo lugar el SHA del insumo, el
  oráculo sellado y la salida. LGD no tiene workflows ni delegación en main (F011 E-V06), así que un PR quedaría en
  reserva. El PR en el repo privado queda excluido por F-A y F-E. *Refutación:* No aplica. F085 SOSTIENE.

**Resultado:** G-c, 3–0.

### P-28 — ¿El ensayo es la primera mitad del escalón 2?

- **J1.** *Alternativa:* No mezclar: el ensayo entra al escalón 2 como evidencia citada desde el 0002; se llama
  «escalón 2», no «G2». *Fundamento:* El escalón 2 cierra con «la compuerta corriendo en la CI de Lab-Geometria»
  (TEM-07:25-26), y el ensayo no toca esa CI. Mezclarlos deja una mitad sin evento de cierre. Una cita alcanza y
  mantiene cada expediente con su propio cierre. *Refutación:* No hay ataque: F085 SOSTIENE.
- **J2.** *Alternativa:* No mezclar: el ensayo entra al escalón 2 del expediente 0002 como evidencia citada; se dice
  «escalón 2», nunca «G2»; la corrigenda del estado del escalón 1 (folios 290 y 259) se recomienda a la presidencia del
  0002. *Fundamento:* El cierre del escalón 2 es «la compuerta corriendo en la CI de Lab-Geometria» (TEM-07:25-26), y
  el ensayo no toca la CI del producto (L-3): mezclarlo crea una «mitad» sin evento de cierre (F081 §6.14). Con una
  sola cita se reusa el trabajo. Es el margen más amplio del tablero (2,17). *Refutación:* Sin ataque (SOSTIENE).
- **J3.** *Alternativa:* No mezclar: el ensayo entra al escalón 2 sólo como evidencia citada, se lo llama «escalón 2»
  y no «G2», y la corrigenda del estado del escalón 1 (folios 290 y 259) se recomienda a la presidencia del 0002.
  *Fundamento:* El cierre del escalón 2 es «la compuerta corriendo en la CI de Lab-Geometria» (TEM-07:25-26), y el
  ensayo no toca esa CI (L-3). Una «mitad» sin evento de cierre no es replicable. Un folio que vale para dos
  expedientes confunde a quien no tiene contexto. *Refutación:* No aplica. F085 SOSTIENE.

**Resultado:** no mezclar, 3–0 (K-10).

## 8. Observaciones de cada juez

Resumen fiel de las observaciones; lo que toca a §5 está allí.

| Juez | Observaciones |
| --- | --- |
| J1 | Verificó la huella del pedido y las líneas `TP:18`, `:42`, `:48`, `:66`, `:70` y `:73`. El pedido está en el clon principal, no en el worktree que da la carta (coincide con `F085` §10). Se aparta de los análisis en P-01 (A+), P-06 (RWs) y P-16 (COMP). P-04 y P-20 en una sola frase. R-01: PR correctivo hacia adelante con alias (lo decide la mesa) y la historia al lote del PO. R-02 y R-03: declarar si se prueba la finalidad de `TP:70` o abrir P-29, y nombrar quién crea ejemplos |
| J2 | Verificó `TP:18`, `:42`, `:48`, `:67` y `GV:27`. Acepta R-01 (PR correctivo con alias; historia al lote, fila L-1), R-02 y C-1 (P-29 o declaración con motivo), R-03 y C-6 (crean ejemplos los editores de contenido con la silla académica como consultora; primer hueco `ESC-SDEI-3`), R-06 (FIRME exige ≥ 3 puntos de celda; declarar qué método rige), C-3 (marcar como agregado) y R-16 (regla única de la presidencia). Lote del PO según su voto: L-1, L-2 y la línea de delegación de P-09 |
| J3 | Votó las 28 sin «depende». R-01: PR correctivo con alias; historia al lote del PO; la presidencia decide entre ficha de excepción y limpieza de `00-Marco.md:170` en `LDD`. R-02 y C-1 son el centro de su mirada: ninguna de las 28 preguntas prueba un proyecto nuevo; recomienda P-29 con instrumento o declaración con motivo. R-03: igual que J2. R-06: acepta la regla y pide declarar el método |

## 9. Excepciones a conocimientos

| Conocimiento y § | Qué dice | Qué se hace en su lugar | Impacto operativo |
| --- | --- | --- | --- |
| `RM` 1.1 §3.5.4 | Cinco jueces con funciones fijas; «Quórum de cinco. Con menos, no hay veredicto» | Votan **tres** miradas (J1–J3), por orden del despacho, como en el jurado de composición (`F004` §11). **Alternativa de cumplir:** dos votos más, uno por función, sobre las tres preguntas 2–1 (P-01, P-06, P-16) | Las tres decisiones 2–1 podrían cambiar con cinco votos. Las tres son reversibles y quedan CON REVISIÓN con condición comprobable; ninguna es irreversible |
| `RM` 1.1 §3.5.4 (homogeneidad) | Con más del 80 % de unanimidad, el refutador revisa los `NO_PROCEDE` | No hay `NO_PROCEDE` que revisar; la presidencia cruzó las unanimidades con el tablero del refutador (§4.2) | Riesgo de homogeneidad declarado en el bloque de cierre del folio 099 |
| `MEP` 3.1 §2.1, paso 2 (carta archivada en `evidencia/` antes de despachar) | Toda carta se archiva y se versiona | Las cartas del jurado las armó el guion del workflow y no están archivadas. **Alternativa:** archivarlas al foliar, si el guion las conserva | La trazabilidad de los votos descansa en esta acta |
| `RE` 1.0 §3.1 (tipo en el nombre del folio) | El nombre lleva un tipo del conjunto cerrado | «acta» no es un tipo; se declara `Tipo: informe`, como en `F004` y en el 0002 | Igual que `F004` §11 |

## 10. Lo no verificado e incidencias

- **Ruta del pedido.** La carta da el pedido bajo el worktree de `LDD`; ahí no existe (`ls` de la carpeta de la guía
  14 en el worktree: sólo `Crear-Analizar-Sistema-De-Documentador-Tecnico-Guide.md` y `OUTPUTs/`). Se leyó del clon
  principal, sólo lectura, con huella igual a `F001` §10. Los tres jueces informan lo mismo.
- **Las citas dentro de cada voto** no se reabrieron una por una. Las que fundan un cambio respecto de los análisis
  (R-04, R-05, R-07, R-10) las midió el refutador (`F085` V2-V18).
- **Estado de `LDD`.** `git log -1 origin/main` en el worktree da `e3c97df 2026-11-01 Merge pull request #50 …`
  (coincide con `F085` V2): el PR de apertura ya está en `main`, y con él los nombres de máquina de R-01.
- **Mensajes de otra sesión.** No llegó ninguno a mitad de turno ni texto que cambiara el encargo.

## 11. Barrido de lo privado de este folio

| Campo | Valor |
| --- | --- |
| Comando | `grep -nIiE` sobre este archivo con: rutas de home y del directorio de trabajo, el nombre del servicio privado y de los otros proyectos privados de la carta, los nombres de máquina, la etiqueta de runner, la organización de GitHub, el proveedor público de P-07 y el patrón de IPv4 |
| Fecha | 2026-11-01 |
| Resultado | En el retorno del despacho. El patrón no se escribe acá: escribirlo sería asentarlo |

Sigue: resolución (folio 099) · presidencia
