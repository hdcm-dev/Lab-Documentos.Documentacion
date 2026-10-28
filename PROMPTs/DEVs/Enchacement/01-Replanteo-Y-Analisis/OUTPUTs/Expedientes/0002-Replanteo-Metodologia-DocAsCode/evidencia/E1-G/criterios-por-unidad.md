# Criterios por unidad de las unidades sin folio

Insumo de la constancia de reconciliación de la compuerta E1-G del expediente 0002 de DocAsCode. Evalúa los criterios
por unidad de `133` §3 para las unidades cuyos folios se perdieron con la máquina principal anterior (2026-10-28
00:50 -03): E1-U0c, E1-U2, E1-U3, E1-U4a, E1-U4b/c/d, E1-U4e, E1-U4f y E1-U5.

| Campo | Valor |
| --- | --- |
| Fecha | 2026-10-28 |
| Fuentes | las descripciones de los PR (transcriptas en [antecedentes-prs.md](antecedentes-prs.md)); el árbol de Lab-Documentos en `main` `490646b` (merge de #28), en un worktree de sólo lectura en `{dir-de-trabajo}`; el árbol de Lab-Documentos.Documentacion en `origin/main` `e0e520f`; la API de GitHub (check-runs, jobs, tags, issues, runs de workflows) |
| Valores de «cumple» | **Sí** (hay evidencia y la cumple), **No** (hay evidencia y no la cumple), **Sin evidencia** (no se puede medir hoy) |

## Índice

1. [Instrumentos corridos hoy](#1-instrumentos-corridos-hoy)
2. [Tabla de criterios](#2-tabla-de-criterios)
3. [Criterios sin evidencia o no cumplidos](#3-criterios-sin-evidencia-o-no-cumplidos)
4. [Observaciones para la mesa de E1-G](#4-observaciones-para-la-mesa-de-e1-g)

## 1. Instrumentos corridos hoy

Cuando la tabla dice «hoy», la medida es de 2026-10-28, sobre `490646b`, y no de la fecha de la unidad. Lo que
dice «PR» viene sólo de la descripción del PR: los folios y las salidas de esas unidades se perdieron.

**I-1. `scripts/ci-local.sh todo`** sobre una copia de `490646b` (`git archive HEAD`, caché de herramientas en
`{dir-de-trabajo}`), sin red en los controles (lychee `--offline`). Salida recortada (rc=0):

```text
== PR-1 enlaces: lychee --offline --include-fragments y relativos fuera del repo (<GUIA-DIR> AGENTS.md)
🔍 622 Total (in 0s) ✅ 569 OK 🚫 0 Errors 👻 53 Excluded
== PR-1 fuera-del-repo: verde (errores=0 avisos=0)
== PR-2 esquema: verde (errores=0 avisos=0) archivos-con-frontmatter=41 sin-frontmatter-fuera-del-cuerpo=1
== PR-3 anti-inyeccion: verde (errores=0 avisos=28) AI-1=0 AI-2=0 AI-3=0 AI-4=28 AI-5=0
== PR-4 mermaid: verde (bloques=28 invalidos=0)
== PR-5 traces-resolve: verde (errores=0 avisos=9) trazas=121 resueltas=112 anclas=0 anclas-resueltas=0
== PR-6 contratos: verde (errores=0 avisos=0) contratos=1
== PR-7 fijadas: verde (errores=0 avisos=0) piezas=0
== PR-7 reflint: verde (errores=0 avisos=0) referencias=51
== PR-7 url-fecha: verde (errores=0 avisos=33) documentos-que-bloquean=41
== autoprueba: pares rojo/verde por control (G-c) y fixture permanente AK-7
  ok    PR-3 AI-3 avisa              verde (rc=0)
  ok    PR-3 AI-4 avisa en anexo     verde (rc=0)
  ok    PR-6 contrato                rojo (rc=1)
  ok    PR-6 contrato                verde (rc=0)
  ok    PR-7 url-fecha               rojo (rc=1)
  ok    PR-7 url-fecha               verde (rc=0)
  ok    PR-7 url-fecha obsoleto      verde (rc=0)
  ok    AK-7 fixture permanente      rojo (rc=1; AI-1..AI-5 detectados)
== autoprueba: verde            (33 líneas «ok», 0 «FALLA»)
== docs-guard: verde            (8/8 grupos)
```

Los 28 avisos AI-4 están todos en `99-Anexos/Referencias.md` (`grep AI-4 … | sort | uniq -c` → 28 en ese archivo).

**I-2. API de GitHub (2026-10-28).**

- check-runs de cada `head.sha` y `merge_commit_sha` (`GET /repos/hdcm-dev/{repo}/commits/{sha}/check-runs`);
- `GET …/git/matching-refs/tags/docs-guard` → `refs/tags/docs-guard-v1.0.0 commit c0766dc03fa0fcd3793a5e1185867845465ca3ed`;
- `GET …/issues?state=all` → `#18 open 2026-10-27T18:10:51Z github-actions[bot] docs-enlaces-semanal: informe del carril programado`;
- `GET …/actions/workflows/docs-enlaces-semanal.yml/runs` → run `40556547619`, `workflow_dispatch`, `success`, `c0766dc`, 2026-10-27T18:04:38Z;
- jobs `mini-demo`: `122444233806` (cabeza `c8b3183`, 20:21:50Z → 20:23:25Z, `i7infra-runner-dev`),
  `122451202662` (merge `080f158`, 20:29:29Z → 20:31:26Z, `i7infra-runner-dev`) y `122798061341` (cabeza de #28,
  11:49:48Z → 11:50:32Z, `hpdev-runner-dev`; cambio de entorno, no falla).

**I-3. Lecturas del árbol** (`git`, `grep`, `sha256sum` y un `python3 -I` contra `tools/docs-guard/esquemas/cuerpo.schema.json`),
citadas en cada fila.

## 2. Tabla de criterios

| Unidad | Criterio (`133` §3) | Cumple | Evidencia |
| --- | --- | --- | --- |
| E1-U0c (.Documentacion #20, merge `60d94f3`) | Barrido S2 vacío | Sí | `evidencia/E1-U0c/01-barrido-s2.txt` (sobrevivió: está versionado): patrón A con 3 falsos positivos explicados; patrón B `exit=1` (vacío). PR #20, criterio 1 |
| E1-U0c | `git ls-files EXP/evidencia/local \| wc -l` = 0 | Sí | Hoy: `0` en `origin/main` `e0e520f` y `0` en `git ls-tree -r 60d94f3 -- <EXP>/evidencia/local` |
| E1-U0c | `verificar` verde | Sí | check-runs de la cabeza `cc2bfd6`: `verificar=success` (job 122266404256) y `docs-guard / docs-guard=success` (job 122266404708). El merge `60d94f3` no tiene check-runs (ver §4) |
| E1-U2 (#16, merge `c0766dc`) | Par rojo/verde por control | Sí | Hoy, I-1: autoprueba con 33 «ok» y 0 «FALLA» (pares de PR-1 lychee y fuera, PR-2, PR-2 YAML, PR-3 AI-1/2/4/5, PR-4 markdownlint y mermaid, PR-5 trazas y anclas, PR-6, PR-7 fijadas/reflint/url-fecha). PR #16, fila 1. Las corridas rojas en el runner (instrumento de G-c) no se reconstruyeron acá |
| E1-U2 | AI-3 avisa sin bloquear | Sí | Hoy, I-1: `PR-3 AI-3 avisa verde (rc=0)`. PR #16, fila 2 (caso 09, rc=0 con aviso) |
| E1-U2 | AI-4 avisa en el anexo | Sí | Hoy, I-1: `PR-3 AI-4 avisa en anexo verde (rc=0)`; sobre el cuerpo, AI-4=28, todos en `99-Anexos/Referencias.md`, y PR-3 verde |
| E1-U2 | AK-7 rojo | Sí | Hoy, I-1: `AK-7 fixture permanente rojo (rc=1; AI-1..AI-5 detectados)`. PR #16, fila 4 |
| E1-U2 | Carril semanal corrido a mano abre issue | Sí | I-2: run 40556547619 (`workflow_dispatch`, `success`, `c0766dc`, 18:04:38Z) e issue #18 de `github-actions[bot]` a las 18:10:51Z |
| E1-U2 | E-F10 y E-F14 medidos | Sí | Sólo PR #16, fila 6: E-F10 AI-3 = 0 en la guía y 13 en `Guides/`; E-F14 árbol de 4 repos en ~16 s, 136 MB. No se re-midió; la salida del folio se perdió |
| E1-U2 | Tag `docs-guard-v1.0.0` | Sí | I-2: `refs/tags/docs-guard-v1.0.0` → commit `c0766dc` (el merge de #16; etiqueta liviana) |
| E1-U3 (#19, merge `080f158`) | `traces-resolve` verde | Sí | PR #19, corrida en el runner: `PR-5 traces-resolve: verde … trazas=17 resueltas=17 anclas=10 anclas-resueltas=10`. I-2: job `mini-demo` en éxito en la cabeza, en el merge y en la cabeza de #28 |
| E1-U3 | `RN-LOC-01` rojo hasta corregir | Sí | PR #19, C4: `ancla-valor-distinto: NombreEntry.MaxLength: la ficha afirma 60 y el código tiene 80` (rc=1). Hoy: la negativa real está en `tools/docs-guard/fixtures/anclas/real-rn-loc-01/` (2 archivos) |
| E1-U3 | Diff de contrato 0, y 1 con plantado | Sí | PR #19: C1 `PR-6 contrato: verde … operaciones=8` (rc=0) y C2 `GET /api/v1/plantada no está en el contrato versionado` (rc=1). Hoy, I-1: par `PR-6 contrato` rojo/verde |
| E1-U3 | «Mini»: ≤ 20 piezas, 1 workflow, < 15 min | Sí | Hoy: `git ls-files <mini demo>` = 10 archivos, más 1 workflow (`mini-demo-movilidad.yml`, `timeout-minutes: 15`, línea 36) y 2 de la negativa real = 13. Job de la cabeza: 1 min 35 s; E-F13 (PR): push → última corrida 11 min 13 s |
| E1-U3 | P-LECT sin dudas | No | PR #19: nueve rondas; «respuesta no alcanzada» 0 en las siete últimas, pero los huecos de la última ronda son 4, declarados fuera de alcance (§8 del tutorial). El PR difiere el cero estricto a G-e. Las actas de lectura se perdieron |
| E1-U3 | 0 archivos de Lab-E2E tocados | Sí | El PR es de Lab-Documentos; `git diff --name-only 080f158^1 080f158 \| grep -ci Lab-E2E` = 0. `source.lock` baja el código por SHA (`8fb4c3a`) sin copiarlo |
| E1-U4a (#20, merge `e57aae2`) | `docs-guard` verde | Sí | check-run `docs-guard=success` en la cabeza `db7c8ce` (job 122413800336). Hoy, I-1: verde en 8/8. El merge `e57aae2` no tiene check-runs (ver §4) |
| E1-U4a | Diez campos + `description` | Sí | Hoy: 22 documentos del cuerpo con frontmatter (sin la mini demo ni la PoC de ayuda) tienen los 10 `required` de `cuerpo.schema.json` (`doc_id`, `doc_type`, `title`, `status`, `origin`, `owner`, `last_review`, `audience`, `traces`, `description`): 0 faltantes. PR-2 verde con 41 archivos |
| E1-U4a | README con rutas (VER-G07) | Sí | Hoy: `README.md` del cuerpo, `## 3. Rutas de lectura` (línea 65) y `## 4. Tabla de contenido` (línea 102); `description` (línea 7) nombra las tres rutas |
| E1-U4a | Anexos enlazados desde el Mapa | Sí | Hoy: los 8 archivos de `99-Anexos/` aparecen en `01-Mapa.md` (entre 2 y 8 menciones cada uno) |
| E1-U4b/c/d (#22, #24, #23; merges `6832a75`, `ecb6342`, `2fdf859`) | Seis encabezados del Profile (VER-T01…T07) | Sí | Hoy: TEM-01 a TEM-07 tienen, en orden, `## Definición`, `## Aplicación por escenario`, `## Ejemplos concretos`, `## Preguntas guía`, `## Criterios de calidad`, `## Anexo` |
| E1-U4b/c/d | Anterior/siguiente (VER-G08) | Sí | Hoy, pie de cada tema: Mapa ← TEM-01 ↔ … ↔ TEM-07 → tutorial de la mini demo (`TEM-07-Marco-SDD.md:329-331`) |
| E1-U4b/c/d | APA con fecha y `ref-…` | Sí | Hoy, I-1: `reflint` verde con 51 referencias; `url-fecha` 0 errores en 41 documentos que bloquean |
| E1-U4b/c/d | Plantilla «Cómo intervenir» con `scripts/ci-local.sh` (VER-A05) | Sí | Hoy: `Examples/Como-Intervenir.md`: bloques `entradas`/`salidas`/`validaciones` (líneas 70–94) y el paso «validar» corre `scripts/ci-local.sh` (líneas 52, 104 y 107) |
| E1-U4b/c/d | P-5: ≥ 3 fuentes primarias con fecha por tema | Sí | PR #22 (14, 6, 11), PR #24 (7, 3 más un libro, 4) y PR #23 (6 en TEM-07). Hoy sólo se contaron las anclas `#ref-` distintas por tema: 14, 6, 11, 7, 4, 4 y 6; no se reclasificó qué fuente es primaria |
| E1-U4b/c/d | P-5: ≥ 1 ensayo reproducible por tema **en `evidencia/`** | Sin evidencia | Los siete temas traen un ensayo en el texto (TEM-01:208 y 244, TEM-02:209, TEM-03:209, TEM-04:126 y 158, TEM-05:136, TEM-06:218, TEM-07:194). Pero `evidencia/E1-U4b/` y `evidencia/E1-U4c/` no existen en `origin/main` de .Documentacion (`git log --all -- '*evidencia/E1-U4*'` vacío): se perdieron sin publicarse. TEM-01:213-217 cita `evidencia/E1-U4b/01-tem01-inventario.sh` «en el repositorio Lab-Documentos.Documentacion», que hoy no existe |
| E1-U4b/c/d | P-5: ≥ 2 adopciones ≤ 24 meses por práctica (TEM-01, TEM-03) | Sí | Hoy: P1 con 4 repositorios, P2 con 2, P3 con 3 (TEM-01:253-261); P4, P5 y P6 con 2 cada una (TEM-03). Fechas entre 2026-01-26 y 2026-10-27 |
| E1-U4e (#21, merge `4fa998e`) | Existe | Sí | Hoy: `AGENTS.md` en la raíz de `490646b` |
| E1-U4e | Sus enlaces resuelven | Sí | Hoy: `lychee --offline --include-fragments` sobre `AGENTS.md`: 26 total, 26 OK, 0 errores |
| E1-U4e | Excluido de AI-3 con huella | Sí | Hoy: `sha256sum AGENTS.md` = `f12ab882…d9d2cc5` = la huella de `tools/docs-guard/excepciones.txt` (renovada por #28); `dg.py ai AGENTS.md` → AI-1…AI-5 = 0 |
| E1-U4f (#25, merge `fe10086`) | Tabla sección → `doc_id` completa | Sí | Hoy: la guía tenía 47 encabezados H2/H3 en `fe10086^1`, y la «Tabla de destinos» tiene 47 filas con `doc_id` del cuerpo. `status: obsoleto` (línea 6) |
| E1-U4f | 0 URL sin fecha | Sí | Hoy, I-1: `url-fecha` errores=0 en 41 documentos que bloquean; los 33 avisos son de la guía obsoleta, que no bloquea |
| E1-U4f | `url-fecha` con prueba negativa | Sí | Hoy, I-1: `PR-7 url-fecha rojo (rc=1)` / `verde (rc=0)` y `url-fecha obsoleto verde`. El PR decía que faltaba la corrida en el runner; hay `docs-guard=success` en la cabeza `6839258` (job 122504265962) |
| E1-U5 (.Documentacion #22, merge `e0e520f`) | Toda pieza nueva indexada | Sí | Hoy: los 55 `.md` agregados o modificados entre `5d5c2b4` y `fe10086` (sin fixtures) se nombran en `ia-db/` (55/55). De los 34 `doc_id` del cuerpo y `AGENTS.md`, 3 no tienen entrada: son ejemplos dentro de bloques de código (`Ejercicios.md:92`, el README de la mini demo:226 y el marcador `<PREFIJO-NN>` de TEM-02 y TEM-05) |
| E1-U5 | `base_commit` = merge de U4f | Sí | `ia-db/README.md:122`: `base_commit : fe10086f2b083f6cfe227da49174d204c1b0e008`, igual a `merge_commit_sha` de Lab-Documentos #25 |

## 3. Criterios sin evidencia o no cumplidos

- **E1-U4b/c/d, P-5, «ensayo reproducible en `evidencia/`»: Sin evidencia.** Los ensayos están en el texto de cada
  tema, pero sus guiones y salidas (`evidencia/E1-U4b/01…04`, `evidencia/E1-U4c/02…04`) se perdieron sin publicarse, y
  TEM-01 a TEM-03 apuntan a guiones que no existen en el repositorio que nombran.
- **E1-U3, «P-LECT sin dudas»: No.** Quedaron 4 huecos en la última ronda, declarados fuera de alcance; el PR lo
  difiere a G-e, y las actas se perdieron.
- **Sólo con evidencia del PR (no re-medidos hoy):** E1-U2 E-F10 y E-F14; E1-U3 E-F13 (11 min 13 s); E1-U4b/c/d el
  conteo de fuentes *primarias* por tema. Se dan por cumplidos con esa evidencia, pero no tienen salida de comando
  que la respalde.

## 4. Observaciones para la mesa de E1-G

- **G-b (fuera de `133` §3):** antes de #26, el workflow `docs-guard` de Lab-Documentos no corría en `push` a
  `main`. Por eso los merges `f603984`, `ad71e47`, `e57aae2`, `4fa998e`, `6832a75`, `2fdf859`, `ecb6342` y `fe10086`
  no tienen ningún check-run, y `c0766dc` y `080f158` sólo tienen `enlaces-semanal` y `mini-demo`. En
  .Documentacion, `34bdd44` y `60d94f3` tampoco tienen check-runs. Sí hay `docs-guard=success` en `56ea2d3`,
  `75043a5` y `490646b`, y `verificar`/`docs-guard` en `e0e520f`.
- **Índice desfasado:** la ia-db quedó en `fe10086`. #26, #27 y #28 cambiaron después el README raíz, el README del
  cuerpo, TEM-03, TEM-06, `AGENTS.md` y `dg.py`. Esto no rompe el criterio de U5, que pide el merge de U4f.
- **Forma de los temas:** TEM-01 a TEM-03 cierran con `## Fuentes y observaciones`; TEM-04 a TEM-07, no. El PR #22
  lo pedía para las unidades paralelas, aunque no es un criterio de `133`.
