---
doc_id: EXP0002-F255
doc_type: providencia
title: Propuesta H al PO — política de etiquetas, situación del tag docs-guard-v1.0.0 y regla owner/alias
status: vigente
origin: agent
confidence: alta (cada hecho lleva el comando que lo mide, corrido el 2026-10-28 sobre main de los dos repos)
owner: presidencia de la mesa de Replanteo y análisis DocAsCode (vuelta de E1)
last_review: 2026-10-28T14:05:29-03:00
audience: [PO, presidencia, refutador, agentes que reparen E1, bitacorista]
traces: [EXP0002-F133, EXP0002-F245, EXP0002-F250, EXP0002-F251, EXP0002-F252, N10]
---

# 255 — Propuesta H: etiquetas, tag `docs-guard-v1.0.0` y owner/alias

| Campo | Valor |
| --- | --- |
| Tipo | Propuesta de clase H. Espera al PO: ningún agente la fusiona ni crea, mueve o borra etiquetas por ella |
| Fecha | 2026-10-28T14:05:29-03:00 |
| Autor | Presidencia de la mesa (vuelta de E1), por la unidad U14-H-D del acta `250`. Decisiones DEC-09, DEC-19 y DEC-20. Defectos DEF-21 y DEF-69 |
| Rama | `exp0002/e1r-h-politicas` (Lab-Documentos.Documentacion) |
| Pide | Tres decisiones del PO (§5). Cada una lleva un default sugerido; nada se asienta por silencio (`250` §10) |

## Índice

1. [Por qué es clase H](#1-por-qué-es-clase-h)
2. [Política de etiquetas (DEF-21)](#2-política-de-etiquetas-def-21)
3. [El tag docs-guard-v1.0.0 ya existe](#3-el-tag-docs-guard-v100-ya-existe)
4. [Regla owner/alias (DEF-69)](#4-regla-owneralias-def-69)
5. [Lo que decide el PO](#5-lo-que-decide-el-po)
6. [Qué se hace después de cada respuesta](#6-qué-se-hace-después-de-cada-respuesta)

## 1. Por qué es clase H

- Etiquetar es acto del PO en la propia guía: `00-Marco.md:144` (`ACT-SDEI-1`: «aceptar decisiones de arquitectura,
  pasar a vigente, etiquetar, publicar») y `99-Anexos/Como-Decidir.md:145` (etiquetar es H, «la persona fusiona o
  aprueba»), en Lab-Documentos `d65d52b`.
- El plan lo dice para este tag: `N10:222`, «El PO etiqueta `docs-guard-v1.0.0` (acto H)».
- `252` §3 (DEC-20) lista la política de etiquetas, el tag y la regla owner/alias como clase H de U14.

## 2. Política de etiquetas (DEF-21)

### 2.1 El defecto

El cuerpo de la guía del sistema documentador (`Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/`,
Lab-Documentos `d65d52b`) dice tres cosas que no se cierran entre sí:

| Lugar | Dice | Falta |
| --- | --- | --- |
| `00-Marco.md:78` | «una etiqueta por compuerta» | Si es anotada, cuándo se crea y con qué nombre |
| `TEM-03-Topologia-Y-Versionado.md:61` | «una etiqueta anotada por compuerta» | Qué compuerta (la de cada PR, la de escalón) y el nombre |
| `TEM-03-Topologia-Y-Versionado.md:143` | «etiqueta por compuerta» | Lo mismo |
| `README.md:159-161` | el PO fija la versión en `2.0.0` «y la marca con una etiqueta anotada» | Es **una por versión**, no una por compuerta |
| `TEM-03-Topologia-Y-Versionado.md:69` | etiqueta de versión «en Git, como etiqueta anotada»: `v1.2.0`, o `docs-guard-v1.0.0` para una herramienta | Cómo se nombra la versión de un cuerpo en un repositorio que aloja varias guías |

Medida: `git grep -n -iE 'etiqueta' origin/main -- Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion`.

### 2.2 Regla propuesta (P-ET)

| # | Regla | Por qué |
| --- | --- | --- |
| P-ET-1 | **Una etiqueta por versión publicada**, no por compuerta. Se crea cuando la compuerta del escalón que publica esa versión pasa (por ejemplo, el paso a `vigente` y `2.0.0` de `README.md:159-161`). Una compuerta que no cambia la versión no etiqueta | Unifica las tres frases con la del README: la compuerta de cada PR corre decenas de veces y no puede llevar etiqueta |
| P-ET-2 | **Siempre anotada** (`git tag -a`), con mensaje que cite el PR, el SHA del merge y el folio que la autoriza. Nunca liviana | `TEM-03:61` y `:69` ya lo piden; la anotada guarda quién y cuándo (`git cat-file -t <tag>` da `tag`) |
| P-ET-3 | **Nombre**: `<pieza>-v<SemVer>`. Herramienta: `docs-guard-v1.0.0`. Cuerpo de guía en un repositorio con varias guías: el prefijo de sus IDs en minúscula, `sdei-v2.0.0`. Un repositorio de un solo producto puede usar `v<SemVer>` a secas (`TEM-03:69`) | Lab-Documentos aloja varias guías (`00-Marco.md:77`): un `v2.0.0` a secas no dice de cuál |
| P-ET-4 | **Inmutable**: no se mueve ni se borra. Un error se corrige con otra versión (`-v1.0.1`) | Quien cita la etiqueta tiene que leer siempre lo mismo |
| P-ET-5 | **La crea el PO** (H). Un agente la propone en el folio o en el PR y la verifica después con `git ls-remote --tags origin <nombre>` y `git cat-file -t` | `00-Marco.md:144`; `N10:222` |
| P-ET-6 | Lab-Documentos.Documentacion **no etiqueta**: el expediente y las bitácoras se anclan por SHA | `git ls-remote --tags origin` en LDD sale vacío; nada lo consume |

El texto de las cinco frases de §2.1 se unifica después, en una reparación de clase P sobre Lab-Documentos (rama
`exp0002/e1r-<tema>` de la ola 2), una vez que el PO elija la regla. Esta propuesta no toca la guía.

## 3. El tag `docs-guard-v1.0.0` ya existe

La aceptación de U14 en el plan («el tag aparece en `git ls-remote --tags` sólo después del ok del PO») y la fila
U14 del acta `250` («el tag existe sólo con el ok del PO») suponen que el tag falta. **No falta**:

| Medida (2026-10-28) | Resultado |
| --- | --- |
| `git ls-remote --tags origin` en Lab-Documentos | `c0766dc03fa0fcd3793a5e1185867845465ca3ed refs/tags/docs-guard-v1.0.0` (única etiqueta) |
| `git cat-file -t c0766dc0…` | `commit`: es una **etiqueta liviana**, sin objeto tag, sin autor ni fecha propios |
| `git log -1 --format='%cI %s' c0766dc` | `2026-10-27T15:04:27-03:00 Merge pull request #16 from hdcm-dev/exp0002/e1-u2-docs-guard-completo` (E1-U2) |
| Evidencia previa | `evidencia/E1-G/criterios-por-unidad.md:58` y `:81` ya la midieron (I-2, «etiqueta liviana») |
| Antes de E1 | 0 etiquetas en Lab-Documentos (`I02-Versionado-Y-Deriva.md:331`, `N09-Integracion.md:505`, `085-refutacion.md:269`, 2026-10-26) |
| `GET /repos/hdcm-dev/Lab-Documentos/events` (3 páginas) | Ningún `CreateEvent` de tipo `tag` en la ventana que da la API: no se puede saber desde la API quién la empujó |
| `git grep -n 'docs-guard-v1' origin/main -- .github` en los dos repos | 0: ningún workflow la consume. `verificar.yml:57` de LDD fija `docs-guard.yml` por SHA (`f603984…`), no por etiqueta |

Lectura de la presidencia:

- La etiqueta nació entre el merge de #16 (2026-10-27T15:04:27-03:00) y la medida I-2 de E1-G. El plan la había
  reservado al PO (`N10:222`) y `133` §3 la pedía como entregable de E1-U2: la creó la unidad E1-U2: su folio, rescatado
  de i7infra por el #36, lo asienta como acto propio (`212-e1-u2.md:61`, `:75`: «referencia ligera creada por la
  API»). Corrección de la premisa (`257` D06): el tag **tiene asiento**, pero no autorización del PO (`N10:222`);
  queda como **hecho H asentado y sin autorizar**.
- Es liviana, contra P-ET-2 y contra `TEM-03:61` y `:69`, que piden anotada.
- Como nada la consume, conservarla o reemplazarla no cambia ninguna corrida de CI.

Opciones para el PO:

| Opción | Qué se hace | Reversible | Efecto |
| --- | --- | --- | --- |
| **T-A (default sugerido)** | Ratificarla como está: el PO asienta en el PR de este folio que la acepta; queda como excepción nombrada a P-ET-2; la próxima versión de `docs-guard` nace anotada | Sí | Ninguno sobre la historia; la medida de `251` §3 sigue dando el mismo SHA |
| T-B | Reemplazarla por una anotada sobre el mismo commit: `git tag -a -f docs-guard-v1.0.0 c0766dc -m "…"` y push forzado de la etiqueta | **No** (mueve una ref pública) | El nombre resuelve al mismo commit, pero quien la haya bajado guarda la liviana |
| T-C | Borrarla y dejar `docs-guard` sin versión hasta una `docs-guard-v1.1.0` anotada | **No** | `251` §3 pasa a «ausente» y E1-G2 la declara reserva nombrada |

## 4. Regla owner/alias (DEF-69)

### 4.1 El defecto

`G-f-barrido-s2.txt:152-154` (observación O1): las guías publican la cuenta pública de autoría del PO en `owner:`
mientras el expediente la oculta con el alias `{cuenta-del-PO}` (carátula `README.md:25`). Los dos criterios conviven
sin regla escrita. No es fuga: es la autoría de un repositorio público del PO y figura en los commits.

| Medida (Lab-Documentos `d65d52b`) | Resultado |
| --- | --- |
| `git grep -n '^owner: {cuenta-del-PO}' origin/main` (con el valor real) | 4 líneas, todas en la línea 9 del frontmatter: `Sistema-Documentador-Tecnico-Guide.md`, `Dot-NET-Arquiectura-Interactive-Guide.md`, `Dot-NET-Arquitectura-Guide.md`, `Metodologia-Entorno-Desarrollo-Guide.md` |
| Resto de los `owner:` de Lab-Documentos | Roles (`ACT-01 Product Owner`, …), nombres de guía o de repositorio (`Lab-Documentos`, `docs-guard`) |
| El valor contra el patrón S2 | Coincide con una clase genérica (líneas 1–20), no con los literales privados (líneas 21–33): cada barrido S2 lo vuelve a encontrar en esas 4 líneas |

### 4.2 Reglas posibles

| Opción | Regla | Qué cambia |
| --- | --- | --- |
| **O-A (default sugerido)** | `owner:` designa **un rol o una pieza** (`Product Owner de Lab-Documentos`, `docs-guard`), nunca una cuenta. Las cuentas, usuarios y máquinas van en alias en todo lo público; la autoría personal queda en los commits | 4 líneas de frontmatter en Lab-Documentos, por una reparación P de la ola 2. El barrido S2 deja de dar falsos positivos en esas líneas. Es la convención que ya siguen los demás `owner:` |
| O-B | La cuenta pública del PO vale en `owner:` de las guías que firma; en el expediente y la evidencia sigue el alias, porque allí la cuenta aparece junto a datos operativos | Nada en los archivos. Se escribe la regla en la guía y el barrido S2 clasifica esas 4 líneas como «autoría pública, no fuga» en cada corrida |

Las dos son reversibles. La mesa sugiere O-A porque deja una sola regla para todo lo público y porque el `owner:`
responde «quién responde por esto», que es un rol.

## 5. Lo que decide el PO

| # | Pregunta | Default sugerido | Reversible |
| --- | --- | --- | --- |
| 1 | Política de etiquetas | P-ET-1 a P-ET-6 de §2.2 | Sí |
| 2 | Tag `docs-guard-v1.0.0` existente (liviana, sin autorización asentada) | T-A: ratificarla y dejarla como excepción nombrada | T-A sí; T-B y T-C no |
| 3 | Regla owner/alias | O-A: `owner:` es un rol o una pieza | Sí |

Cómo responder: un comentario en el PR de este folio (por ejemplo, «1 sí, 2 T-A, 3 O-A»). El PR queda abierto con la
marca «[espera PO]» y no lo fusiona un agente (`252` §3).

## 6. Qué se hace después de cada respuesta

| Respuesta | Siguiente paso | Clase |
| --- | --- | --- |
| 1 aprobada | Reparación P en Lab-Documentos que unifica `00-Marco.md:78`, `TEM-03:61`, `:143` y `README.md:159-161` con P-ET-1 a P-ET-3 | P |
| 2 = T-A | El PO fusiona este PR; la fila de `251` §3 lee «presente, liviana, ratificada por el PO en el PR de `255`» | — |
| 2 = T-B o T-C | La ejecuta el PO, o un agente con su orden escrita en el PR; después, medida con `git ls-remote --tags` y `git cat-file -t` | H |
| 3 = O-A | Reparación P en Lab-Documentos sobre las 4 líneas de §4.1 | P |
| 3 = O-B | Se escribe la regla en la guía y se agrega la clasificación al barrido S2 | P |

Mientras tanto, E1-G2 no espera: mide con lo fusionado y declara la política, el tag y la regla owner/alias como
reservas nombradas (`251` §6, punto 5; DEC-20).

## 7. Resolución del PO (2026-10-29)

El PO delegó en la presidencia «armar una solución definitiva» para los cuatro PR H, tomando como base el diseño de
i7infra y lo avanzado en hpdev, y aprobó en la misma sesión reescribir la historia de los dos repositorios. Se
resuelve:

| # | Resolución | Por qué |
| --- | --- | --- |
| 1 | **Política aprobada**: P-ET-1 a P-ET-6 | Default de la mesa; coincide con `TEM-03:61` y `:69` |
| 2 | **T-B**: el tag se recrea **anotado** sobre el commit que reemplace a `c0766dc` en la historia reescrita, con mensaje que cite el #16, este folio y la resolución | La reescritura ya mueve todas las referencias públicas: lo irreversible de T-B deja de ser un costo propio, y la etiqueta queda conforme a P-ET-2 sin excepción |
| 3 | **O-A**: `owner:` es un rol o una pieza, nunca una cuenta | Default de la mesa; una sola regla para todo lo público |

Siguientes pasos: T-B lo ejecuta quien hace la reescritura y se mide con `git cat-file -t docs-guard-v1.0.0` =
`tag`; las reparaciones P de §6 (filas 1 y 3) entran en la vuelta E1-R.

