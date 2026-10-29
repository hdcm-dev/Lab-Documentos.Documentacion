---
doc_id: DB00
doc_type: bitacora-indice
title: Índice vivo de la corrida DocAsCode
status: vigente
origin: agent
confidence: alta en fases 1–2 (reconstruidas de B00 y de la carátula del expediente 0002); alta en Asiento (folio 100 leído); alta en fases 10–11 (retornos de verificación); alta en fase 12 (retornos de U3 y U4a, merges comprobados en origin/main); alta en fase 13 (retornos de U4b–U4e, merges #21–#24 comprobados en origin/main); alta en fase 14 (retorno de U4f, merge #25 comprobado en origin/main); alta en fase 15 (retorno de U5, merge Documentacion#22 comprobado en origin/main)
owner: bitacorista de la corrida DocAsCode
last_review: 2026-10-27
audience: [PO, presidencia, mesa, agentes de implementación]
traces: [B00, EXP0002-README, EXP0002-F099, EXP0002-F100]
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
| 16 | E1 onda 8 (E1-G) | E1 | 2026-10-27 | Siguiente | Compuerta E1-G |

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

## 4. Folios del expediente 0002

001–004 (apertura, caso, panel, acta de composición), 0060 y 0070 (informes complementarios), 010–017 (comisiones),
080 (análisis), 085 (refutación), 090 (reconsideración), 095 (veredicto), 099 (resolución), **100 (respuesta del PO y
lectura, ciclo 2)**, 110, 115, 120, 125 y 129 (ciclo 2), 130–133 (E1 onda 0), 210 y 216 (E1 onda 1), 211-e1-u0b y 211-e1-u1 (E1 onda 2; número 211 repetido, ver §5), 212-e1-u2 y 230-e1-u0c (E1 onda 3), 213-e1-u3 y 214-e1-u4a (E1 onda 4), 218-e1-u4b, 250-e1-u4e, 251-e1-u4d y 252-e1-u4c (E1 onda 5), 260-e1-u4f (E1 onda 6), 270-e1-u5 (E1 onda 7). Fuente: `ls EXP/actuaciones/` el 2026-10-27.

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
| 7 | E-F1: cola del runner único i7infra-dev (hasta 15m28s) | Asumido: esperar antes de G3 |
| 7 | LD-23: `ci.yml` de Lab-E2E.WebBlazor en `ubuntu-latest`, actions por etiqueta | Anotado; fuera de alcance de U6 |
| 8 | Corrida anterior de la onda 2 cortada; U0b y U1 retomadas sin duplicar | Cerrado |
| 8 | PR de par #18 apilado sobre la rama de #17, cerrado al borrarla; re-runs `startup_failure` | Cerrado: verde por `workflow_dispatch` (LD-05 de U0b) |
| 8 | Fallo de red pasajero al bajar lychee (`curl 92`) | Pasa a E1-U2: reintento y caché |
| 8 | E-F1 repite: `fw-ok` ~30 min en cola | Asumido |
| 8 | Folio 211 usado por dos unidades (BIT-1) | Abierto: presidencia |
| 9 | E-F1 repite: ~13 min de cola en U2 | Asumido |
| 9 | U2/LD-05: informe del issue cortado en 60 000 bytes con `head -c` (puede dejar `<details>` abierto) | Deuda conocida: unidad próxima |
| 9 | U0c/LD-05: la copia sin versionar de `OUTPUTs/` del PO choca con main; `git pull` no la sobrescribe | Abierto: avisar al PO (mover o borrar antes del pull); resincronizar folios posteriores a `cc2bfd6` |
| 10 | BIT-2: al reanudar tras el límite de sesión se volvió a despachar la onda 2, ya cerrada; las unidades sólo verificaron | Cerrado; al reanudar, partir de §6 (onda 4) |
| 12 | E-F1 repite: en U3, unos 7 de los 11 min de push a última corrida fueron cola | Asumido |
| 12 | P-LECT sin cero estricto: tutorial de U3 (criterio 6 en parte, LD-17) y README/Marco/Mapa de U4a | Pasa a G-e de E1-G (onda 8) |
| 12 | BIT-4: rama remota ajena `cierre/0001-tpr-emulador` en Lab-Documentos, con worktree fuera de `{dir-de-trabajo}` | No es de E1: no tocar; excluir de la limpieza final |
| 13 | BIT-5: `{dir-de-trabajo}/h.cfg` con una credencial local (PE-10) (aviso de U4c; el archivo sigue ahí) | Abierto · presidencia: borrarlo ya; rotar el token es acto del PO |
| 13 | U4b/H-1: `dg.py` rechaza `traces: []`, que el anexo del esquema admite; U4d: no hay control de los bloques de CR-5; `dg.py` sin exclusión de carpetas (`_legacy/`) | Pasa a U4f/E2 |
| 13 | Merge vs rebase: U4d y U4c rebasaron, U4b hizo merge; los dos caminos funcionaron | Presidencia: fijar uno |
| 13 | BIT-6: `{dir-de-trabajo}/convencion-temas-sdei.txt` ya no está | Sin efecto: la forma vigente es la de main |
| 14 | U4f/H-1: el paso «avisos» repite `url-fecha` sobre el cuerpo nuevo; los 33 avisos de GUIA salen como anotaciones en cada PR | Abierto: se resuelve al archivar GUIA (versión siguiente) |
| 14 | BIT-5 repite (U4f/H-3): `h.cfg` sigue en `{dir-de-trabajo}/` | Abierto · presidencia |
| 14 | E-F7: citas web sin fecha de consulta | Cerrado por U4f |
| 15 | U5 · P-1: la ia-db v4.0 sin commitear del PO (más índices 05–10 sin seguimiento) choca con main (v4.1) | Abierto · avisar al PO: `git checkout -- ia-db` y borrar los índices 05–10 sin seguimiento antes del pull |
| 15 | U5 · H-1..H-4: README raíz y `Guides/README.md` apuntan a GUIA obsoleta; diagrama de SDEI «en redacción»; `framework-concept-demo.yml` con `actions/checkout@v4` sin SHA; 202 enlaces absolutos en Framework Concept | Pasa a E1-G (onda 8) u otra unidad |
| 15 | BIT-7: la carta pide «Claude Opus 5.5 (1M context)» en `Co-Authored-By` y el entorno no (U5/LD-08) | Abierto · presidencia: alinear la carta |
| 15 | BIT-5 repite: `h.cfg` sigue en `{dir-de-trabajo}/` | Abierto · presidencia |
| 11 | BIT-3: segunda reanudación que re-despacha una onda cerrada (la 3); U2 y U0c sólo verificaron, sin cambios | Cerrado; presidencia: despachar desde §6 (onda 4), no repetir ondas cerradas |

## 6. Punto de continuación

```text
Sigue: E1 onda 8 — compuerta E1-G (N10 §14).
Onda 7 cerrada: Lab-Documentos.Documentacion#22 (e0e520f, cabeza 8ef1fb0): ia-db v4.1 (la v4.0 local del PO
publicada y ampliada, U5/LD-01) con índices nuevos 11_Sistema-Documentador-SDEI y 12_Framework-Concept;
base_commit fe10086; cobertura 55/55 .md y 29/29 doc_id; Verificar 40597128735 verde (verificar + docs-guard).
origin/main: Lab-Documentos = fe10086, Lab-Documentos.Documentacion = e0e520f.
Onda 6: #25 (fe10086). Onda 5: #21 (4fa998e), #22 (6832a75), #23 (2fdf859), #24 (ecb6342). Onda 4: #20 (e57aae2),
#19 (080f158). Onda 3: #16 (c0766dc, tag docs-guard-v1.0.0), Documentacion#20 (60d94f3). Onda 2: Documentacion#17
(34bdd44), #15 (ad71e47). Onda 1: #11 (f603984), Lab-E2E.WebBlazor#12 (59399ba). D08 FIRME (L2).
Para E1-G (G-e): P-LECT con cero estricto del tutorial de la demo (U3/LD-17), README/Marco/Mapa (U4a) y TEM-01..07
(U4b, U4c, U4d); el lector tiene que poder ver los anexos (U4a/LD-06). Hallazgos de U5 a resolver o derivar:
README raíz y Guides/README.md de Lab-Documentos apuntan a GUIA obsoleta (H-1); diagrama de SDEI «en redacción» (H-2);
framework-concept-demo.yml con actions/checkout@v4 sin SHA (H-3); 202 enlaces absolutos en Framework Concept (H-4).
Para E2: dg.py acepta traces: [] (U4b/H-1); control de bloques CR-5 (U4d); exclusión de carpetas y prefijos externos
en dg.py (U4d); G3 por corrida de workflow, a decir en CPA (U4c); sacar el cuerpo nuevo del paso «avisos» o archivar
GUIA (U4f/H-1).
Si el PR queda behind o en conflicto: integrar main y conservar las entradas de todos en CHANGELOG/README/Referencias
(merge o rebase; presidencia fija uno). workflow_dispatch sólo tras el merge; cola del runner 7-30 min. No apilar PRs
de par. Controles negativos con GITHUB_ACTIONS=false; probar en el layout de la CI.
Mains locales del PO intactos: Lab-Documentos 5d5c2b4, Lab-Documentos.Documentacion 8da0cd9.
Avisar al PO antes de su pull en Lab-Documentos.Documentacion: git checkout -- ia-db y borrar los índices 05-10 sin
seguimiento (U5/P-1); mover o borrar su copia sin versionar de OUTPUTs/ (U0c/LD-05).
Pendientes: BORRAR YA {dir-de-trabajo}/h.cfg (credencial local (PE-10), BIT-5; sigue ahí tras U5) y avisar al PO para
que rote la credencial; resincronizar los OUTPUTs/ posteriores a cc2bfd6 (folios 212, 213, 214, 218, 230, 250, 251, 252,
260, 270; evidencia E1-U0c, U3, U4a, U4b, U4c, U4d, U4e, U4f, U5); deuda U2/LD-05 (cortar el informe por línea);
alinear la línea Co-Authored-By de la carta con el entorno (BIT-7).
Al reanudar, despachar desde aquí (onda 8); no repetir ondas cerradas (BIT-2, BIT-3).
Abiertos: L11 (acto del PO), E-16, U0c/LD-05 y U5/P-1 (avisar al PO), LD-23, BIT-1 (folio 211 duplicado), BIT-4
(rama ajena cierre/0001-tpr-emulador, no tocar), BIT-5, BIT-7, U4f/H-1 · presidencia
```
