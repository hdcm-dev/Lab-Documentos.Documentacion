---
doc_id: EXP0002-F261
doc_type: constancia
title: Constancia de la reescritura de la historia de Lab-Documentos y Lab-Documentos.Documentacion — reversión de «No reescribir», mains nuevos, árboles idénticos, tag anotado, repin de docs-guard y regla de lectura de los SHA viejos
status: vigente
origin: agent
confidence: alta en los hechos de git y GitHub (comando y salida citados, consultados el 2026-11-01); alta en el testimonio del PO (respuesta literal registrada en la sesión DocsAsCode); media en la lista de pasajes afectados (grep sobre las actuaciones; puede haber menciones indirectas)
owner: presidencia de la mesa de recuperación del expediente 0002
last_review: 2026-11-01
audience: [PO, presidencia, agentes de E1-R, mesa de la opción B, bitacorista, línea Framework-Concept]
traces: [EXP0002-F250, EXP0002-F254, EXP0002-F255, EXP0002-F257, EXP0002-F258, EXP0002-F259]
---

# 261 — Constancia de la reescritura de la historia

| Campo | Valor |
| --- | --- |
| Tipo | constancia |
| Fecha | 2026-11-01 (asienta hechos del 2026-10-29) |
| Autor | Presidencia de la mesa de recuperación, por el bitacorista de la reedición DocsAsCode |
| Corrige | Por referencia: `258` (§4, `:101`), `254` (§8, `:141`) y el fundamento de `257` D02, D06 y §10. Ningún folio se edita |
| Número | `261`, libre según `257:211` («Libres: `261`, `262`, `264`») |

## Índice

1. [Qué se asienta](#1-qué-se-asienta)
2. [Testimonio del PO](#2-testimonio-del-po)
3. [Quién la ejecutó y cuándo](#3-quién-la-ejecutó-y-cuándo)
4. [Mains nuevos y árboles idénticos](#4-mains-nuevos-y-árboles-idénticos)
5. [Tag docs-guard-v1.0.0](#5-tag-docs-guard-v100)
6. [Repin de docs-guard (LDD #41)](#6-repin-de-docs-guard-ldd-41)
7. [Regla de lectura de los SHA viejos](#7-regla-de-lectura-de-los-sha-viejos)
8. [Qué folios se corrigen por referencia](#8-qué-folios-se-corrigen-por-referencia)
9. [Lo que no entra](#9-lo-que-no-entra)
10. [Pase](#10-pase)

## 1. Qué se asienta

Hasta el 2026-10-29 regía «No reescribir» la historia de los dos repositorios públicos. Era el default de `250:343`
(ítem 1 del lote: «No reescribir; rotar lo rotable. Si se reescribe, una sola operación después de E1-G2, con bundles y
mapa de SHA») y lo daban como decisión del PO `257:120` (D02), `257:124` (D06), `257:216` (§10), `254:141` y `258:101`.

El 2026-10-29 el PO **revirtió** esa decisión y aprobó reescribir la historia de hdcm-dev/Lab-Documentos (LD) y
hdcm-dev/Lab-Documentos.Documentacion (LDD) con `git filter-repo`, para borrar del pasado los datos que hasta entonces
sólo se habían redactado hacia adelante. La constancia `051` del expediente 0001 de Framework Concept asienta el acto
técnico (`PROMPTs/Concepts/01-Framework-Concept/OUTPUTs/Expedientes/0001-Framework-Concept-Maui-Autoactualizable/actuaciones/051-constancia-historia-reescrita.md`).
Este folio lo asienta en el expediente 0002, donde faltaba.

## 2. Testimonio del PO

El 2026-10-29 a las 23:15:15Z (20:15 −03), en la sesión DocsAsCode, se le preguntó al PO: «FRAMEWORK MAUI dice que
aprobaste reescribir la historia de Lab-Documentos y Lab-Documentos.Documentacion (git filter-repo + force-push) para
borrar del pasado los datos ya redactados. Antes habías decidido «No reescribir». ¿Lo confirmás? Es irreversible […]».
Respuesta literal:

> «si reescribi, pero cuida lo que se ha avanzado en `/LAB/Lab-Documentos/Lab-Documentos/Concepts` y
> `/LAB/Lab-Documentos/Lab-Documentos/Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion`»

En la misma ronda, sobre los cuatro PR de clase H, el PO respondió: «busca el mejor camino que tome como base el
diseño hecho en i7infra y capture los avances que hiciste aca - evalua, y arma una solución definitiva - cuida lo que
esta hecho en `/LAB/Lab-Documentos/Lab-Documentos/Concepts/Framework-Concept` y
`/LAB/Lab-Documentos/Lab-Documentos/Guides/IA/Dot-Net-Integration-AI-Layer-Guide` - porque ahi en esas hay otros
subagentes trabajando ahora». Es la delegación que resuelve el `255` §7.

Fuente: registro de la sesión DocsAsCode (respuesta a la pregunta al PO, sello `2026-10-29T23:15:15.808Z`). El
registro es privado; acá se transcribe sólo la respuesta.

## 3. Quién la ejecutó y cuándo

- **Ejecutó**: la sesión FRAMEWORK MAUI, con `git filter-repo` v2.47.0 sobre clones espejo (`--replace-text`,
  `--replace-message` y un mailmap), después de que las dos sesiones cerraron sus ramas (`051:20-22`). La sesión
  DocsAsCode no ejecutó la reescritura: hizo el repin del §6.
- **Orden de los hechos** (hora −03 del 2026-10-29; `git log --format='%h %cI %s' origin/main` en los dos repos y API
  `GET /repos/hdcm-dev/<repo>/activity?activity_type=force_push`, consultados el 2026-11-01):

| Hora | Hecho | Evidencia |
| --- | --- | --- |
| 22:38:18 | Merge LD #32 (AGENTS.md) | API: `merged_at` 2026-10-30T01:38:18Z |
| 22:50:36 | Merge LD #31 (docs-guard, `traces-vacio` pasa a aviso) | API: `merged_at` 2026-10-30T01:50:36Z |
| 22:52:46 | Merge LDD #32 (`verificar.yml`, opción b) | API: `merged_at` 2026-10-30T01:52:46Z |
| 22:52:53 | Merge LDD #33 (folio `255` resuelto) | API: `merged_at` 2026-10-30T01:52:53Z |
| 22:55:17 | Force-push de `main` de LDD: `b9f4317` → `15d8452` | API activity: `2026-10-30T01:55:17Z refs/heads/main b9f4317 -> 15d8452` |
| 22:55:31 | Force-push de `main` de LD: `b25b71b` → `bf86669` | API activity: `2026-10-30T01:55:31Z refs/heads/main b25b71b -> bf86669` |
| 23:00:02 | Merge LDD #41 (repin) | `b88ec81 2026-10-29T23:00:02-03:00 Merge pull request #41` |
| 23:02:40 | Merge LDD #42 (constancia `051` de FC) | `8f319ce 2026-10-29T23:02:40-03:00 Merge pull request #42` |

La reescritura se hizo antes de E1-G2, no «después de E1-G2» como proponía el default de `250:343`. Es un apartamiento
del default, decidido por el PO; se avisa, no se pregunta.

## 4. Mains nuevos y árboles idénticos

| Repositorio | `main` anterior | `main` nuevo | Árbol del anterior | Árbol del nuevo |
| --- | --- | --- | --- | --- |
| LD | `b25b71b4c9f0a68f9583e47e79baa4fc37819e4d` (merge de LD #31) | `bf866697b0688708eb28cdde2ffdb0a968e7a953` | `e25eb95a5ebf7c4b292c0a16fbf97b56eca4d749` | `e25eb95a5ebf7c4b292c0a16fbf97b56eca4d749` |
| LDD | `b9f431770c8eeea95e1242d43686194cbd867a14` (merge de LDD #33) | `15d84523d3a05f1f7c61771091553ba24f72027a` | `05107b758be10ac2787538c32ac76c3b04134f3c` | `05107b758be10ac2787538c32ac76c3b04134f3c` |

Comandos (2026-11-01):

- Árbol del anterior: `GET /repos/hdcm-dev/<repo>/git/commits/<sha-anterior>`, campo `tree.sha`. GitHub todavía sirve
  el objeto viejo porque lo retiene `refs/pull/*` (`051:43-45`).
- Árbol del nuevo: `git rev-parse bf86669^{tree}` en `{dir-de-trabajo}/wt/dac-LD` y `git rev-parse 15d8452^{tree}` en
  `{dir-de-trabajo}/wt/dac-LDD`.

Los árboles son idénticos: la punta no cambió ningún byte, y por eso el cuidado que pidió el PO sobre `Concepts/` y el
cuerpo SDEI se cumple en la punta. Los commits intermedios sí cambian de árbol, porque contenían los datos borrados. Por
ejemplo, el merge de LD #16 tiene árbol `5429c44…` en la historia vieja (`c0766dc`, API) y `0a667aa…` en la nueva
(`14d5a28`, `git rev-parse 14d5a28^{tree}`). Es lo esperado.

Ningún SHA anterior al force-push sigue en la historia nueva. Se comprobó con `git merge-base --is-ancestor <sha>
origin/main`, que da falso para `fe10086`, `c0766dc`, `f603984`, `ad71e47`, `e57aae2`, `5d5c2b4` y `75043a5` en LD, y
para `e0e520f`, `34bdd44`, `60d94f3`, `8da0cd9`, `cc2bfd6` y `5dadc00` en LDD.

## 5. Tag docs-guard-v1.0.0

El `255` §7 (resolución 2, T-B) pedía recrear el tag **anotado** sobre el commit que reemplazara a `c0766dc`. Medida
en `{dir-de-trabajo}/wt/dac-LD` después de `git fetch --tags`, el 2026-11-01:

- `git cat-file -t docs-guard-v1.0.0` da `tag`: es anotado.
- `git rev-parse docs-guard-v1.0.0^{commit}` da `14d5a28a33b869538aa0c97705666c0d7cd5648d`, el «Merge pull request #16
  from hdcm-dev/exp0002/e1-u2-docs-guard-completo» de la historia nueva. Es el mismo mensaje y la misma hora
  (2026-10-27T18:04:27Z) que `c0766dc` en la API.
- `git for-each-ref refs/tags/docs-guard-v1.0.0 --format='%(objecttype) %(taggerdate:iso) %(subject)'` da
  `tag 2026-10-29 22:54:08 -0300 docs-guard v1.0.0 (PR #16)`.

## 6. Repin de docs-guard (LDD #41)

`verificar.yml` de LDD llamaba al workflow reutilizable de docs-guard fijado por el SHA de LD `b25b71b` (commit
`eb70e81` del PR #32 de LDD). Ese SHA quedó huérfano.

- El PR #41 de LDD (rama `exp0002/repin-docs-guard`, cabeza `18cebd1`, merge `b88ec81accb6d27322835a87e6cb4f8419c5e7b5`)
  lo fijó en `bf866697b0688708eb28cdde2ffdb0a968e7a953`. Se ve en
  `git show origin/main:.github/workflows/verificar.yml`, líneas 73 (`uses: …/docs-guard.yml@bf8666…`) y 76
  (`herramientas-ref: bf8666…`).
- Check-runs de la cabeza `18cebd1`: `verificar` success y `docs-guard (.github) / docs-guard` success, corrida
  [40988758248](https://github.com/hdcm-dev/Lab-Documentos.Documentacion/actions/runs/40988758248), consultada el
  2026-11-01.
- Como los árboles son idénticos (§4), repinar a `bf86669` no cambia el código de docs-guard que corre la CI.

## 7. Regla de lectura de los SHA viejos

1. Todo SHA citado en folios, bitácoras, CHANGELOG, índices de la ia-db y descripciones de PR **escritos antes del
   force-push** (2026-10-29 22:55 −03) es de la historia vieja. **No se edita**: se lee por el mapa viejo→nuevo de la
   constancia `051` de FC (`051:38-40`), que está en el `{resguardo-privado}`.
2. Para los merges de PR alcanza con la correspondencia pública por número de PR:
   `git log origin/main --grep='^Merge pull request #N from' -1`. La bitácora `16` de la Guía 14 trae la tabla de los
   merges que cita el expediente.
3. Los objetos viejos todavía resuelven en GitHub por `refs/pull/*` (`051:43-45`), pero no son ancestros de `main`. Un
   control que necesite «SHA ancestro de main» (por ejemplo `git merge-base --is-ancestor` en U32-REG, o el despacho de
   Verificar de U30-GB sobre `34bdd44` y `60d94f3`, `257:182`) usa el equivalente nuevo y cita los dos.
4. `base_commit` de la ia-db (`fe10086`, ia-db/README.md:122) es de la historia vieja. Su equivalente nuevo es
   `6878568` (merge de LD #25). Lo actualiza el reindexado de cierre (U34), no una edición suelta.

## 8. Qué folios se corrigen por referencia

| Lugar | Dice | Se lee |
| --- | --- | --- |
| `258-constancia-rescate-i7infra.md:101` (§4) | «Ningún folio se renumera: el PO decidió no reescribir» | La regla de no renumerar y de citar por nombre completo **sigue**. Su fundamento ya no es «no reescribir»: la reescritura no tocó el contenido de la punta (§4), así que nombres y números de archivo quedaron iguales |
| `254-corrigenda-patron-s2.md:141` (§8) | «La historia de `main` no se reescribe: las versiones previas siguen en los commits que la columna «Entró» indica» | La historia se reescribió el 2026-10-29. Los SHA de la columna «Entró» son de la historia vieja (§7) y ya no contienen los valores reales |
| `257-acta-mesa-recuperacion-i7infra.md:120` (D02), `:124` (D06) y `:216` (§10) | «Decisión del PO de hoy: no reescribir historia»; «nunca rebase ni force-push»; «no se reescribe» | Las decisiones siguen, pero su fundamento cambia: D06 se cumplió (los cuatro PR H entraron por merge, sin rebase, antes del force-push, §3); lo fusionado desde hpdev se conserva en la punta con árbol idéntico (§4) |
| `250-acta-mesa-organizacion-y-vuelta-e1.md:343` (ítem 1 del lote) | Default «No reescribir»; si se reescribe, «después de E1-G2» | El PO decidió reescribir antes de E1-G2 (§2 y §3) |
| `252-corrigenda-n10-y-caratula.md` | — | La memoria de la sesión y `051:13` dicen que la decisión «No reescribir» quedó asentada en `252` y `258`. En `252` no aparece la palabra: `grep -n -i reescrib` sobre el `252` sale vacío. Lo que el `252` sostiene sobre numeración (§4) ya lo corrigió el `259`, y la reescritura no lo cambia. Se deja constancia de la diferencia, sin corrección |

Lo que no cambia: rige el `245` (INSUFICIENTE, una sola vuelta), el `290` sigue sustituido (`258` §5) y la carátula no
se edita.

## 9. Lo que no entra

- **La tabla de reemplazos de `filter-repo` y el mapa completo viejo→nuevo.** Son privados y quedan en el
  `{resguardo-privado}` (`051:38-40`).
- **Las `refs/pull/*` de GitHub**, que conservan copias de la historia vieja. Borrarlas requiere un pedido a GitHub
  Support, y eso lo decide el PO (`051:43-45`).
- **La realineación de los clones del PO.** Al 2026-11-01 los dos están en `main` igual a `origin/main` (`0bed863` en
  LD y `8b96bc6` en LDD), según `git -C <clon> rev-parse --short HEAD origin/main`, sólo lectura.

## 10. Pase

| Pasa a | Qué |
| --- | --- |
| U32-REG | Citar los merges de E1-R con SHA nuevo; los de antes del force-push, con el par viejo/nuevo (§7) |
| U30-GB, U41-MED | Usar los equivalentes nuevos de `34bdd44` (`97e30bc`, merge de LDD #17) y `60d94f3` (`faaeab1`, merge de LDD #20), o decidir en mesa que el despacho se haga sobre la ref vieja de `refs/pull/*` |
| U34 (reindexado de cierre) | `base_commit` a la punta de LD de la historia nueva |
| PO | Si pide a GitHub Support la purga de `refs/pull/*` |
| Bitacorista | Bitácora `16-2026-10-28-Onda8-Rescate-Y-Reescritura.md` de la Guía 14 |
