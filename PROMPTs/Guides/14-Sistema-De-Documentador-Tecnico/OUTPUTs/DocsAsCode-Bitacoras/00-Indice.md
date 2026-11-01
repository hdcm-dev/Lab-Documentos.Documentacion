---
doc_id: DB00
doc_type: bitacora-indice
title: Índice vivo de la corrida DocAsCode
status: vigente
origin: agent
confidence: alta en fases 1–2 (reconstruidas de B00 y de la carátula del expediente 0002); alta en Asiento (folio 100 leído); alta en fases 10–11 (retornos de verificación); alta en fase 12 (retornos de U3 y U4a, merges comprobados en origin/main); alta en fase 13 (retornos de U4b–U4e, merges #21–#24 comprobados en origin/main); alta en fase 14 (retorno de U4f, merge #25 comprobado en origin/main); alta en fase 15 (retorno de U5, merge Documentacion#22 comprobado en origin/main); alta en fase 16 (merges por API de GitHub y git log de la historia nueva, folios 240–261 leídos, 2026-11-01); media en el estado de §5 donde no se pudo medir sin tocar i7infra (BIT-5)
owner: bitacorista de la corrida DocAsCode
last_review: 2026-11-01
audience: [PO, presidencia, mesa, agentes de implementación]
traces: [B00, EXP0002-README, EXP0002-F099, EXP0002-F100, EXP0002-F257, EXP0002-F261, DB16, DB-R02-00]
---

# 00 — Índice vivo de la corrida DocAsCode

## Índice

1. [Referencias](#1-referencias)
2. [Fases y workflows](#2-fases-y-workflows)
3. [Entradas de esta bitácora](#3-entradas-de-esta-bitácora)
4. [Folios del expediente 0002](#4-folios-del-expediente-0002)
5. [Incidentes](#5-incidentes)
6. [Punto de continuación](#6-punto-de-continuación)

## 1. Referencias

| Qué | Ruta (desde la raíz del workspace) |
|---|---|
| Caso (tool-prompt) | `LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/DEVs/Enchacement/01-Replanteo-Y-Analisis/Replanteo-Y-Analisis.md` |
| Expediente 0002 (`EXP/`) | `…/01-Replanteo-Y-Analisis/OUTPUTs/Expedientes/0002-Replanteo-Metodologia-DocAsCode/` |
| Bitácoras de análisis (`B/`) | `…/01-Replanteo-Y-Analisis/OUTPUTs/Bitacoras/` (maestra: `B/00-Bitacora-Maestra.md`) |
| Esta bitácora | `LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/Guides/14-Sistema-De-Documentador-Tecnico/OUTPUTs/DocsAsCode-Bitacoras/` |

Desde el ciclo 2, por pedido del PO (folio 100), el seguimiento por fase vive en esta carpeta; `B/00` queda como
índice de las bitácoras de análisis.

## 2. Fases y workflows

| # | Fase | Workflow (runId) | Fecha | Estado | Producto |
|---|---|---|---|---|---|
| 1 | Relevamiento, investigación y descomposición (R01–R07, I01–I07, N00–N08, C00) | `wf_daf37797-400` | 2026-10-26 | Cerrada | 22 bitácoras + maestra en `B/` |
| 2 | Mesa ciclo 1: apertura, panel, comisiones, análisis, refutación, veredicto, integración (P10), crítica C10 | `wf_38b94176-93b` (tres cortes por límite de sesión y reanudaciones) | 2026-10-26 | Cerrada | Folios 001–099, `N09`, `N10`, `C10` |
| — | Respuesta del PO al lote L1–L13 | — (chat) | 2026-10-27 | Recibida | Testimonio en folio 100 §1 |
| 3 | Asiento: lectura del lote y apertura del ciclo 2 | ciclo 2 (runId no nombrado en el despacho) | 2026-10-27 | Cerrada | Folio 100 |
| 4 | Mesa ciclo 2 (PRE-04) | ciclo 2 (despachos A20, R20, J1–J5, P21) | 2026-10-27 | Cerrada | Folios 110, 115, 120, 125, 129 |
| 5 | Cierre del ciclo 2: dictamen, firmeza, habilitación de E1 | ciclo 2 (presidencia) | 2026-10-27 | Cerrada | Folios 120, 125, 129; P-2 a P-5 aplicadas |
| 6 | E1 onda 0: asiento de respuestas del PO (L1–L13) y providencias | E1 (presidencia) | 2026-10-27 | Cerrada | Folios 130–133 |
| 7 | E1 onda 1 (U0a‖U6) | E1 | 2026-10-27 | Cerrada | Lab-Documentos#11 (`f603984`), Lab-E2E.WebBlazor#12 (`59399ba`); folios 210, 216 |
| 8 | E1 onda 2 (U0b‖U1) | E1 | 2026-10-27 | Cerrada | Lab-Documentos.Documentacion#17 (`34bdd44`), Lab-Documentos#15 (`ad71e47`); folios 211-e1-u0b, 211-e1-u1 |
| 9 | E1 onda 3 (U2‖U0c) | E1 | 2026-10-27 | Cerrada | Lab-Documentos#16 (`c0766dc`, tag `docs-guard-v1.0.0`), Lab-Documentos.Documentacion#20 (`60d94f3`); folios 212-e1-u2, 230-e1-u0c |
| 10 | E1 onda 2, reanudación tras límite de sesión (sólo verificación de U0b y U1) | E1 | 2026-10-27 | Cerrada | Sin cambios: #17 (`34bdd44`) y #15 (`ad71e47`) confirmados en `origin/main` |
| 11 | E1 onda 3, reanudación tras límite de sesión (sólo verificación de U2 y U0c) | E1 | 2026-10-27 | Cerrada | Sin cambios: #16 (`c0766dc`, tag `docs-guard-v1.0.0`) y #20 (`60d94f3`) confirmados en `origin/main` |
| 12 | E1 onda 4 (U3‖U4a) | E1 | 2026-10-27 | Cerrada | Lab-Documentos#20 (`e57aae2`), Lab-Documentos#19 (`080f158`); folios 213-e1-u3, 214-e1-u4a |
| 13 | E1 onda 5 (U4b‖U4c‖U4d‖U4e) | E1 | 2026-10-27 | Cerrada | Lab-Documentos#21 (`4fa998e`, U4e), #22 (`6832a75`, U4b), #23 (`2fdf859`, U4d), #24 (`ecb6342`, U4c); folios 218-e1-u4b, 250-e1-u4e, 251-e1-u4d, 252-e1-u4c |
| 14 | E1 onda 6 (U4f) | E1 | 2026-10-27 | Cerrada | Lab-Documentos#25 (`fe10086`, GUIA obsoleta con tabla de destinos, `dg.py url-fecha`); folio 260-e1-u4f |
| 15 | E1 onda 7 (U5) | E1 | 2026-10-27 | Cerrada | Lab-Documentos.Documentacion#22 (`e0e520f`, ia-db v4.1, `base_commit` `fe10086`); folio 270-e1-u5 |
| 16 | E1 onda 8: compuerta E1-G, caída y rescate de i7infra, clase H, ia-db v4.2, reescritura de la historia y repin | E1 (presidencia, mesa de recuperación `257`) | 2026-10-28 a 2026-10-29 | Cerrada: E1-G **INSUFICIENTE**, rige `245`; vuelta E1-R abierta | LDD #27, #29–#31, #36, #37, #39, #32, #33, #41 y LD #26–#28, #30, #32, #31 (SHA en `16` §3); folios 240–259 y 261; mains nuevos LD `bf86669` y LDD `15d8452` |
| 17 | Reedición del prompt 02 de la Guía 14 (libro DocsAsCode, conocimiento de especificación, ajustes de coherencia) | Reedición DocsAsCode (expediente 0003) | 2026-11-01 | En curso: ver [`Reedicion-02/`](Reedicion-02/00-Plan.md) | Expediente 0003; bitácoras de `Reedicion-02/` |

Los SHA de las filas 7 a 15 (y los de `03`–`15`) son de la historia anterior a la reescritura del 2026-10-29 y no se
editan. Su equivalente en la historia nueva está en la entrada `16` §4; la regla de lectura, en el folio `261` §7.

## 3. Entradas de esta bitácora

| Archivo | Fase | Estado |
|---|---|---|
| `01-2026-10-26-Relevamiento.md` | 1 | No escrita: reconstruida en §2 desde `B/00` |
| `02-2026-10-26-Mesa-Ciclo-1.md` | 2 | No escrita: reconstruida en §2 y §5 desde `B/00` §4 |
| [`03-2026-10-27-Asiento.md`](03-2026-10-27-Asiento.md) | 3 | Cerrada |
| [`04-2026-10-27-Mesa-Ciclo-2.md`](04-2026-10-27-Mesa-Ciclo-2.md) | 4 | Cerrada |
| [`05-2026-10-27-Cierre.md`](05-2026-10-27-Cierre.md) | 5 | Cerrada |
| [`06-2026-10-27-Onda0.md`](06-2026-10-27-Onda0.md) | 6 | Cerrada |
| [`07-2026-10-27-Onda1.md`](07-2026-10-27-Onda1.md) | 7 | Cerrada |
| [`08-2026-10-27-Onda2.md`](08-2026-10-27-Onda2.md) | 8 | Cerrada |
| [`09-2026-10-27-Onda3.md`](09-2026-10-27-Onda3.md) | 9 | Cerrada |
| [`10-2026-10-27-Onda2-Reanudacion.md`](10-2026-10-27-Onda2-Reanudacion.md) | 10 | Cerrada |
| [`11-2026-10-27-Onda3-Reanudacion.md`](11-2026-10-27-Onda3-Reanudacion.md) | 11 | Cerrada |
| [`12-2026-10-27-Onda4.md`](12-2026-10-27-Onda4.md) | 12 | Cerrada |
| [`13-2026-10-27-Onda5.md`](13-2026-10-27-Onda5.md) | 13 | Cerrada |
| [`14-2026-10-27-Onda6.md`](14-2026-10-27-Onda6.md) | 14 | Cerrada |
| [`15-2026-10-27-Onda7.md`](15-2026-10-27-Onda7.md) | 15 | Cerrada |
| [`16-2026-10-28-Onda8-Rescate-Y-Reescritura.md`](16-2026-10-28-Onda8-Rescate-Y-Reescritura.md) | 16 | Cerrada (escrita el 2026-11-01). Junta las dos entradas que preveía `257` D12 |
| [`Reedicion-02/`](Reedicion-02/00-Plan.md) | 17 | En curso: plan `00-Plan.md`, bitácoras por núcleo y cohesión |

## 4. Folios del expediente 0002

001–004 (apertura, caso, panel, acta de composición), 0060 y 0070 (informes complementarios), 010–017 (comisiones),
080 (análisis), 085 (refutación), 090 (reconsideración), 095 (veredicto), 099 (resolución), **100 (respuesta del PO y
lectura, ciclo 2)**, 110, 115, 120, 125 y 129 (ciclo 2), 130–133 (E1 onda 0), 210 y 216 (E1 onda 1), 211-e1-u0b y 211-e1-u1 (E1 onda 2; número 211 repetido, ver §5), 212-e1-u2 y 230-e1-u0c (E1 onda 3), 213-e1-u3 y 214-e1-u4a (E1 onda 4), 218-e1-u4b, 250-e1-u4e, 251-e1-u4d y 252-e1-u4c (E1 onda 5), 260-e1-u4f (E1 onda 6), 270-e1-u5 (E1 onda 7). Fuente: `ls EXP/actuaciones/` el 2026-10-27.

Onda 8 y vuelta de E1 (2026-10-28 a 2026-11-01). Los números 211, 250, 251, 252 y 260 están repetidos y se citan por
nombre completo (`258` §4):

| Folio | Qué es |
|---|---|
| `240-constancia-caida-i7infra-y-reconciliacion.md` | Constancia de la caída de i7infra |
| `245-resolucion-compuerta-e1.md` | Resolución de E1-G: INSUFICIENTE, una sola vuelta (**rige**) |
| `249-providencia-estado.md` | Estado al 2026-10-28 |
| `250-acta-mesa-organizacion-y-vuelta-e1.md` | Acta de la mesa de organización y vuelta de E1 |
| `251-corrigenda-133-criterios-vuelta.md` | Corrigenda a 133: criterios de la vuelta |
| `252-corrigenda-n10-y-caratula.md` | Corrigenda a N10 y a la carátula |
| `253-constancia-resguardo.md` | Constancia del resguardo privado |
| `254-corrigenda-patron-s2.md` | Corrigenda del patrón S2 |
| `255-propuesta-etiquetas-y-owner.md` | Propuesta H de etiquetas, tag y owner/alias; resuelta por el PO (§7) |
| `256-corrigenda-cuenta-marcas-g-g.md` | Corrigenda de la cuenta de marcas de G-g |
| `257-acta-mesa-recuperacion-i7infra.md` | Acta de la mesa de recuperación y plan por olas |
| `258-constancia-rescate-i7infra.md` | Constancia del rescate y tabla de folios con nombre completo |
| `259-corrigenda-rescate-i7infra.md` | Corrigenda única por el rescate |
| `261-constancia-reescritura-de-historia.md` | Constancia de la reescritura de la historia, reversión de «No reescribir» y repin |
| `290-compuerta-e1.md` | Compuerta E1-G de i7infra: antecedente, **sustituida** (`258` §5) |

Reservados o libres: `260-registro-e1r.md` (U32), `262` y `264` libres, `263` y `265` (U43). Fuente: `ls
EXP/actuaciones/` en `{dir-de-trabajo}/wt/dac-LDD` el 2026-11-01.

## 5. Incidentes

| Fase | Incidente | Estado |
|---|---|---|
| 2 | `J4-coherencia-historica-V2` cortado por límite de sesión (2026-10-26 22:33 UTC) | Re-despachado; votó (095 §4.3) |
| 2 | `J5-riesgo-V2` corrió dos veces con rótulos distintos | Irregularidad declarada (095 §4.3; L13) |
| 2 | `P10:integracion` cortado en la primera corrida | Re-despachado y terminado |
| 2 | `C10:critica` cortado antes de empezar | Corrido después; `B/C10` (104 líneas) |
| 3 | Punto «2.» de la respuesta del PO llegó vacío | Observación O-1 del folio 100 |
| 5 | Lectura del lote por la presidencia (E-16) no confirmada por el PO | Abierto: avisar al PO |
| 6 | L11 (forks, permisos, runner group) pendiente como acto del PO | Abierto; guardas en workflows |
| 7 | E-F1: cola del runner único i7infra-dev (hasta 15m28s) | Asumido. Desde el 2026-10-28 la línea corre en hpdev (`257` D15) |
| 7 | LD-23: `ci.yml` de Lab-E2E.WebBlazor en `ubuntu-latest`, actions por etiqueta | Anotado; fuera de alcance de U6 |
| 8 | Corrida anterior de la onda 2 cortada; U0b y U1 retomadas sin duplicar | Cerrado |
| 8 | PR de par #18 apilado sobre la rama de #17, cerrado al borrarla; re-runs `startup_failure` | Cerrado: verde por `workflow_dispatch` (LD-05 de U0b) |
| 8 | Fallo de red pasajero al bajar lychee (`curl 92`) | Pasa a E1-U2: reintento y caché |
| 8 | E-F1 repite: `fw-ok` ~30 min en cola | Asumido |
| 8 | Folio 211 usado por dos unidades (BIT-1) | Cerrado: no se renumera; se cita por nombre completo (`252` §4, `257` D02, `258` §4) |
| 9 | E-F1 repite: ~13 min de cola en U2 | Asumido |
| 9 | U2/LD-05: informe del issue cortado en 60 000 bytes con `head -c` (puede dejar `<details>` abierto) | Deuda conocida: unidad próxima |
| 9 | U0c/LD-05: la copia sin versionar de `OUTPUTs/` del PO choca con main; `git pull` no la sobrescribe | Cerrado: los folios y la evidencia posteriores a `cc2bfd6` entraron con LDD #36 (`258` §2), y el 2026-11-01 el clon del PO está en `origin/main` (`8b96bc6`) sin copia de `OUTPUTs/` sin versionar (`git status --porcelain`, sólo lectura) |
| 10 | BIT-2: al reanudar tras el límite de sesión se volvió a despachar la onda 2, ya cerrada; las unidades sólo verificaron | Cerrado; al reanudar, partir de §6 |
| 12 | E-F1 repite: en U3, unos 7 de los 11 min de push a última corrida fueron cola | Asumido |
| 12 | P-LECT sin cero estricto: tutorial de U3 (criterio 6 en parte, LD-17) y README/Marco/Mapa de U4a | Pasa a G-e de E1-G2 (U42; umbral de `257` D13) |
| 12 | BIT-4: rama remota ajena `cierre/0001-tpr-emulador` en Lab-Documentos, con worktree fuera de `{dir-de-trabajo}` | No es de E1: no tocar; excluir de la limpieza final |
| 13 | BIT-5: `{dir-de-trabajo}/h.cfg` con una credencial local (PE-10) (aviso de U4c) | Pendiente de verificación del PO: borrar las dos copias y rotar el token son actos suyos (`257` D08, K50-I7). No se comprueba desde esta línea porque i7infra no se toca |
| 13 | U4b/H-1: `dg.py` rechaza `traces: []`, que el anexo del esquema admite | Cerrado por LD #31 (`bf86669`): `traces-vacio` pasa a aviso (`tools/docs-guard/dg.py:15`, `:346`) |
| 13 | U4d: no hay control de los bloques de CR-5; `dg.py` sin exclusión de carpetas (`_legacy/`) | Pasa a E2 |
| 13 | Merge vs rebase: U4d y U4c rebasaron, U4b hizo merge; los dos caminos funcionaron | Fijado para los PR H y la vuelta: merge de main, nunca rebase ni force-push de rama (`257` D06; `218:125`) |
| 13 | BIT-6: `{dir-de-trabajo}/convencion-temas-sdei.txt` ya no está | Sin efecto: la forma vigente es la de main |
| 14 | U4f/H-1: el paso «avisos» repite `url-fecha` sobre el cuerpo nuevo; los 33 avisos de GUIA salen como anotaciones en cada PR | Abierto: se resuelve al archivar GUIA (versión siguiente) |
| 14 | BIT-5 repite (U4f/H-3) | Ver fila 13 |
| 14 | E-F7: citas web sin fecha de consulta | Cerrado por U4f |
| 15 | U5 · P-1: la ia-db v4.0 sin commitear del PO (más índices 05–10 sin seguimiento) choca con main | Cerrado: el 2026-11-01 el clon del PO no tiene cambios en `ia-db/` (`git status --porcelain -- ia-db` vacío) |
| 15 | U5 · H-1: README raíz y `Guides/README.md` apuntan a GUIA obsoleta | En parte: la traza ambigua a `GUIA-INDICE` salió con `69c80c7` (LD #31), y `dg.py trazas AGENTS.md README.md Guides/README.md` da `traces-resolve: verde` sobre `origin/main` (`0bed863`). Pero `README.md:11` y `Guides/README.md:11` siguen trazando `DOC-SDT-0001` (obsoleto): pasa a U20 |
| 15 | U5 · H-2: diagrama de SDEI «en redacción» | Cerrado: `git grep -n -i "en redacción"` sobre el README de SDEI en `origin/main` sale vacío |
| 15 | U5 · H-3: `framework-concept-demo.yml` con `actions/checkout@v4` sin SHA | Cerrado: fijado por SHA (`framework-concept-demo.yml:49`, `:94`, `:155`, `@11bd719… # v4.2.2`) |
| 15 | U5 · H-4: 202 enlaces absolutos en Framework Concept | Sin medir de nuevo; territorio de FRAMEWORK MAUI (`Reedicion-02/00-Plan.md` §5) |
| 15 | BIT-7: la carta pide «Claude Opus 5.5 (1M context)» en `Co-Authored-By` y el entorno no (U5/LD-08) | Abierto · presidencia: alinear la carta |
| 15 | BIT-5 repite | Ver fila 13 |
| 11 | BIT-3: segunda reanudación que re-despacha una onda cerrada (la 3); U2 y U0c sólo verificaron, sin cambios | Cerrado; presidencia: despachar desde §6, no repetir ondas cerradas |
| 16 | Mains locales del PO (antes `5d5c2b4` y `8da0cd9`, de la historia vieja) | Cerrado: el 2026-11-01 están en `origin/main`: LD `0bed863` y LDD `8b96bc6` |
| 16 | BIT-8: la onda 8 no tuvo bitácora hasta el 2026-11-01 | Cerrado con la entrada `16` |
| 16 | BIT-9: `257` D12 preveía las entradas 16-Onda8-E1-G y 17-Caida-i7infra-E1-R; se juntaron en la `16` | Desvío declarado. Sigue pendiente el addendum a `OUTPUTs/Reanudar.md` (U35) |
| 16 | BIT-10: `refs/pull/*` conserva la historia vieja (`051:43-45` de FC) | Abierto · decide el PO (GitHub Support) |
| 16 | BIT-11: SHA viejos en folios, bitácoras, carátula y `base_commit` de la ia-db (`fe10086`) | Regla: no se editan; se leen por `16` §4 y por el mapa de `051` (`261` §7). La ia-db se pone al día en el reindexado de cierre (U34) |

## 6. Punto de continuación

```text
Sigue: vuelta E1-R (acta 257 §9). En paralelo: reedición del prompt 02 de la Guía 14 (Reedicion-02/, expediente 0003).
Onda 8 cerrada (entrada 16): E1-G INSUFICIENTE (rige 245; el 290 es antecedente sustituido); rescate LDD #36 (0bb43b7),
corrigenda 259 LDD #39 (2ef8fbf), ia-db v4.2 parcial LDD #37 (6a784fd), PR H LD #32 (9f6c3fb), LD #31 (bf86669),
LDD #32 (3640c33), LDD #33 (15d8452); reescritura de la historia el 2026-10-29 (folio 261); repin LDD #41 (b88ec81).
Historia nueva: LD main reescrito = bf86669, LDD = 15d8452; tag docs-guard-v1.0.0 anotado sobre 14d5a28.
origin/main al 2026-11-01: LD = 0bed863, LDD = 8b96bc6 (lo posterior es de FRAMEWORK MAUI).
SHA anteriores al 2026-10-29 22:55 −03: historia vieja; no se editan, se leen por 16 §4 y el mapa de 051 (261 §7).
Pendiente de E1-R: U20-TRZ (README.md:11 y Guides/README.md:11 todavía trazan DOC-SDT-0001; H1 de TEM-04..06),
U21–U23 (texto), U24 (fase 1b), U25 (corrida nueva de los guiones originales), U26 (marcas a URL+SHA),
U29 (pares rojo/verde en hpdev), U30 (G-b sobre los equivalentes nuevos de 34bdd44 y 60d94f3: 97e30bc y faaeab1),
U31 (E-F4 y fuentes primarias), U32 (260-registro-e1r.md), U33 (CHANGELOG), U34 (reindexado de cierre; la v4.2 sólo
tocó el índice 12, base_commit sigue en fe10086 = 6878568 nuevo), U35 (addendum a Reanudar.md), K40 (sitio regenerado).
Después: E1-G2 (U40 barrido, U41 medidas G-a..G-g, U42 P-LECT con umbral de 257 D13, U43 mesa 263 y resolución 265
con el Anexo L6 del 290 §14); U44 (cierre de worktrees, ramas y resguardo); K50-I7 (actos del PO en i7infra).
Después: E2 y E3 (N10 §14); la entrada a E2 la aprueba el PO.
Para E2: control de bloques CR-5 y exclusión de carpetas y prefijos externos en dg.py (U4d); G3 por corrida de
workflow, a decir en CPA (U4c); sacar el cuerpo nuevo del paso «avisos» o archivar GUIA (U4f/H-1).
workflow_dispatch sólo tras el merge. No apilar PRs de par. Controles negativos con GITHUB_ACTIONS=false; probar en el
layout de la CI.
Coordinación con FRAMEWORK MAUI (Reedicion-02/00-Plan.md §5): territorios disjuntos, worktrees {dir-de-trabajo}/wt/dac-*, un PR
común a la vez por repo y merges serializados con aviso.
Si el PR queda behind: update-branch o merge de main, nunca rebase (257 D06), y esperar los checks.
Abiertos: L11 (acto del PO), E-16, LD-23, BIT-4 (rama ajena, no tocar), BIT-5 (pendiente de verificación del PO),
BIT-7, BIT-10 (refs/pull, PO), U4f/H-1, U2/LD-05, U5/H-4 (FC) · presidencia.
No repetir ondas cerradas (BIT-2, BIT-3).
```
