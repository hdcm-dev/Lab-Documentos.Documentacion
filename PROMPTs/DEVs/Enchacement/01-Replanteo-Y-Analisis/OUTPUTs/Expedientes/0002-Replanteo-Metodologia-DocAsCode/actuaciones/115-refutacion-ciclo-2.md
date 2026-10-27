---
doc_id: EXP0002-F115
doc_type: refutacion
title: Refutación del ciclo 2 — ataque al folio 110 (evidencia, aplicación, objetivo)
status: vigente
origin: agent
confidence: alta en R-1 a R-3 (listados y grep del 2026-10-27); media en R-4 a R-7, que son lectura del refutador rotulada
owner: despacho R20 de la mesa de Replanteo y análisis DocAsCode (refutador, ciclo 2)
last_review: 2026-10-27
audience: [presidencia, jurado del ciclo 2, bitacorista, PO]
traces: [EXP0002-F110, EXP0002-F099, EXP0002-F100, EXP0002-F090, EXP0002-F085]
---

| Campo | Valor |
| --- | --- |
| Tipo | refutacion (`R01` §4) |
| Fecha | 2026-10-27 |
| Autor | Despacho R20. Ataca; no vota |
| Objeto | `F110` completo (313 líneas) |

Secciones leídas: `F110` completo; `F100:55-72` (§3); `F099:50-56`, `:100-156`, `:186-187`, `:308`, `:323`;
`F085:120-130`, `:200-232`; `F090:93-94`, `:127`; `MP:555-562`; listados de `KB-privada/Knowledges/` y de
`/IA/SDD/IA.SDD/Conocimiento/`; `KB-privada/Rules/Rule-Detencion-Y-Lote.md` (encabezados y §3.2–§3.8);
`KB-privada/Knowledges/Knowledge-Cadena-De-Consecuencias.md:1-31`, `:75-101`, `:164-165`;
`wc -l` de `TP` y `wc -c` de K-Mesa fuente.

# 115 — Refutación del ciclo 2

## Índice

1. [Veredictos](#1-veredictos)
2. [Hallazgos](#2-hallazgos)
3. [Correcciones propuestas](#3-correcciones-propuestas)
4. [Lecciones de decisión de esta refutación](#4-lecciones-de-decisión-de-esta-refutación)
5. [Lo no verificado](#5-lo-no-verificado)
6. [Observaciones](#6-observaciones)

## 1. Veredictos

| Decisión | Veredicto | Motivo en una línea | Hallazgo |
| --- | --- | --- | --- |
| D22-R' | **REFUTA (en su premisa, no en su forma)** | La escalera N1/N2/N3 que `KLD` vendría a crear ya es norma escrita de la base (`Rule-Detencion-Y-Lote` §3.2, §3.5, §3.8; `Rule-Mesa` §3.6; `Cadena-De-Consecuencias`); lo único nuevo es el registro de lecciones. La estructura en dos capas (P que garantiza, H que se consulta) sí se sostiene | R-1, R-2, R-4 |
| D07-R | SOSTIENE | Resultado invariante (`F099` §5.2); la lección N1 es correcta | — |
| H-D22 | SOSTIENE | Un voto sobre texto archivado no se traslada (`F095` §4.2) | — |
| H-5 D08 | **DEBILITA** | Pasar a FIRME se apoya en L2 «aceptada con P», que es **lectura de la presidencia** revisable por el PO (`F100` §6), no aprobación escrita. El hecho que fija la condición no ocurrió del todo | R-5 |
| H-5 D23 | SOSTIENE | Condición de `F099:118` intacta | — |
| H-5 D24 | SOSTIENE | Corrige la premisa falsa que marcó `F085:225` («3 de 6») | — |
| H-5 D25 | SOSTIENE | Activa la condición (a) de `F099:119` sólo cuando el expediente exista | — |
| H-5 D17 | SOSTIENE | E-F12 decide (`F099:150-155`) | — |
| L12' | **DEBILITA** | «Sin `INSUFICIENTE`» en E3 esconde que O-A3/O-A4 dependen de un expediente posterior que puede no existir al cierre de E3 | R-6 |
| P-2 | SOSTIENE | No renombrar es lo reversible | — |
| P-3 | SOSTIENE | Corrigenda en vez de editar folios firmados | — |
| P-4 | SOSTIENE | `wc -l` de `TP` = 67 (verificado hoy) | — |
| P-5 | **DEBILITA** | Los umbrales «≥ 3 fuentes», «≥ 1 ensayo», «≥ 2 adopciones», «≤ 24 meses» no tienen fuente y no están rotulados como criterio propio | R-7 |

**Cuenta.** SOSTIENE 9 · DEBILITA 3 · REFUTA 1.

## 2. Hallazgos

### R-1 (P1, ancla E1) — La escalera ya existe como norma de la base

`F110` §3 afirma que la escalera vive «**sólo como preferencia del asistente**, no como texto de ningún orquestador ni de
ningún conocimiento», y §2 que `KLD` no existe porque en `Knowledges/` «sólo están los de conformación de PR y los de mesa».

Contraste (2026-10-27):

- `KB-privada/Knowledges/` tiene **37** documentos, no sólo PR y mesa; entre ellos
  `Knowledge-Cadena-De-Consecuencias.md` (2.0, 2026-10-24), cuyo `Consumidor` es literalmente «quien conduce el trabajo o
  una fase y despacha a otros agentes; quien preside una mesa; … un análisis de decisiones o un jurado» (`:6`), y que ya
  fija «lo reversible frente a lo irreversible no empata» (`:75-79`, `:101`) y «un obstáculo no es una decisión» (`:90`).
- `KB-privada/Rules/Rule-Detencion-Y-Lote.md` es exactamente N1→N3: §3.1 autocorrección, §3.2 «la pregunta
  previa y la lista cerrada» de lo que no tiene respuesta, §3.3 forma de toda detención **con propuesta**, §3.5 lote con
  `SI NO RESPONDÉS`, §3.7 fases irreversibles, §3.8 **«La mesa antes de la detención»** (N2).
- `Rule-Mesa.md` §3.6 da la lista cerrada de siete disparadores de escalada (citado por `Cadena-De-Consecuencias:31`).
- `Knowledge-Cadena-De-Consecuencias.md` ya está copiado en `/IA/SDD/IA.SDD/Conocimiento/` (listado del directorio).

Consecuencia: `KLD` tal como lo describe A2 (1) y (2) **duplica** norma vigente, y su criterio de irreductibilidad
(«irreversible con consecuencia externa, cambio de alcance, acto H») compite con la lista cerrada de
`Detencion-Y-Lote` §3.2 y §3.7 sin declararlo. Es una excepción no declarada a esa regla, justo lo que §10 de `F110`
dice que no hay.

### R-2 (P1, ancla E1) — Lo genuinamente nuevo es el registro de lecciones

Contrastado contra los mismos documentos: ninguno pide registrar, por decisión resuelta sin quien pidió, el nivel que la
cerró y la corrección posterior. `Detencion-Y-Lote` §3.5 regla 6 registra el default tomado por silencio, pero no la
decisión tomada en N1/N2. Esa es la pieza que sirve al objetivo del PO («enriquecer los conocimientos sobre lógica de
decisión», `F100` §1) y la que `F110` debería proponer como objeto de la capa A.

### R-3 (P2, ancla E1) — La tabla §9 no cumple el formato de lección que el propio folio define

§2 define la lección con «contexto, nivel, criterio, evidencia, resultado y corrección». La tabla §9 trae decisión,
nivel, por qué y lección candidata: faltan **evidencia** y **resultado**. Como semilla de `KLD` (A4), nace sin la
columna que la hace auditable.

### R-4 (P2, ancla C) — La capa A en el SDD-B sigue siendo «carga»

El argumento de que `KLD` «gobierna cómo decide» y por eso no es carga es criterio propio (rotulado, bien). Pero el
mecanismo de entrada al SDD-B es **el mismo** que `F090` R-A2 midió y llamó carga (`F090:94`): una fila en el índice
barrida por K-Mesa §3.4. El objeto cambia; el mecanismo no. Nada obliga al orquestador del SDD-B a llevar el registro de
lecciones sin la capa B (CC §5), que es justo lo que `F110` §11 deja no verificado. Si R-1 se acepta, la objeción se
agrava: la regla de detención ya está en la base y el SDD-B igual no la aplica por sí sola.

### R-5 (P2, ancla E4 parcial) — D08 a FIRME adelanta la confirmación del PO

`F100` §3 fila L2 dice «Aceptada» con fundamento en el testimonio §1; el PO respondió al punto 1 con su objetivo, no con
«P sin aprobación explícita». La condición de revisión de `F099:103` es «si el PO, al asentar la delegación, pide
aprobación explícita en todo P»: el PO **no la pidió**, pero tampoco asentó la delegación por escrito con techo e
intervalo (lo que exige L2, `F099:323`). Con `Detencion-Y-Lote` §3.5 regla 6, un asiento por lectura es decisión vigente
más ítem diferido, no firme.

### R-6 (P2, ancla C) — L12' convierte un observable diferido en verde

O-A3 y O-A4 se cumplen «con el primer expediente posterior». Si E3 cierra antes de que ese expediente exista, «sin
`INSUFICIENTE`» declara cumplido algo no medido. Choca con la regla de rigor de la carta común (no inventar) y con D1
(«ambos» es alcance de la corrida, `F099:53-54`).

### R-7 (P3, ancla C) — Umbrales de P-5 sin fuente

«≥ 3 fuentes primarias», «≥ 2 adopciones», «≤ 24 meses» no citan origen; sólo «mini» remite a `F099` RS-5. La sección
debería rotularlos **[criterio propio]** o fundarlos.

## 3. Correcciones propuestas

| # | Sobre | Corrección |
| --- | --- | --- |
| C2-1 | D22-R' §2, §3, §4.2 A2, §10 | Borrar «sólo como preferencia del asistente» y «sólo están los de conformación de PR y los de mesa». Redefinir `KLD` como **registro y destilación de lecciones de decisión** que **cita** `Rule-Detencion-Y-Lote` (§3.2, §3.5, §3.7, §3.8), `Rule-Mesa` §3.6 y `Cadena-De-Consecuencias` para la escalera, sin redefinirla. Alternativa más barata y preferible por K1: proponer el registro como **cambio P** (MINOR) de `Detencion-Y-Lote` o de `Cadena-De-Consecuencias` §5, en vez de un documento nuevo. El jurado elige entre ambas |
| C2-2 | §4.2 A2 (irreductibilidad) | Sustituir el criterio propio por remisión a la lista cerrada de `Detencion-Y-Lote` §3.2 y §3.7 más la lista H de D08; si se quiere ampliar, declararlo como excepción por `Knowledge-Excepcion-A-Un-Conocimiento` |
| C2-3 | §9 | Agregar columnas «Evidencia» (ruta:línea) y «Resultado» (estado tras el jurado), para que la semilla cumpla el formato de §2 |
| C2-4 | §4.2 / O-A4 | Declarar explícito que en el SDD-B la capa A es **carga** hasta que rija la capa B; «ambos» en el SDD-B queda `PENDIENTE` (no verde) sin la capa B |
| C2-5 | H-5 D08 | Mantener **CON REVISIÓN**; condición nueva: «pasa a FIRME cuando el PO asiente por escrito la delegación de L2 con techo e intervalo, o al vencer el plazo que fije la presidencia sin objeción» |
| C2-6 | L12' | Reemplazar «sin `INSUFICIENTE`» por «`PENDIENTE` con evento de cierre: primer expediente posterior en cada SDD (O-A3, O-A4)», y asentarlo como ítem diferido |
| C2-7 | P-5 | Rotular los umbrales como **[criterio propio]** provisional hasta el rol K2, o citar su fuente |

## 4. Lecciones de decisión de esta refutación

| Decisión | Nivel | Criterio | Evidencia | Resultado | Lección candidata |
| --- | --- | --- | --- | --- | --- |
| R-1 | N1 | Antes de crear un conocimiento, listar la base completa | `ls Knowledges/` (37), `Rules/Rule-Detencion-Y-Lote.md` | Propuesta C2-1 | «Una afirmación de inexistencia se prueba con el listado completo, y se busca también en `Rules/`» |
| R-5 | N1 | Una lectura no es una aprobación | `F100` §6, `F099:103`, `:323` | C2-5 | «Lo asentado por lectura del testimonio queda vigente y diferido, no firme» |
| R-6 | N1 | Un observable futuro no es verde | `F110` O-A3/O-A4 | C2-6 | «Lo que se mide después del cierre se declara PENDIENTE con evento, nunca cumplido» |

## 5. Lo no verificado

| Qué | Motivo |
| --- | --- |
| Si `Rule-Detencion-Y-Lote` y `Rule-Mesa` están vendorizadas en el SDD-B y en IA.SDD | No se listó `Rules/` en esos destinos; sólo `IA.SDD/Conocimiento/` |
| Que el registro de lecciones quepa en `Detencion-Y-Lote` sin romper su techo | No se midió su tamaño |
| Contenido completo de `Rule-Mesa` §3.6 | Sólo por la cita de `Cadena-De-Consecuencias:31` y `K-Mesa:81` |

## 6. Observaciones

- O-1: la estructura de D22-R' (capa P que garantiza + capa H con sugerencia) es la contribución valiosa del folio y
  sobrevive a R-1; lo que cae es la idea de que la escalera está por escribir.
- O-2: el bitacorista copia §4 a `DB/` como insumo de lecciones.
- O-3: sin commits, PR ni contenedores. Archivo creado: este folio.

Sigue: reconsideración o jurado del ciclo 2 · presidencia
