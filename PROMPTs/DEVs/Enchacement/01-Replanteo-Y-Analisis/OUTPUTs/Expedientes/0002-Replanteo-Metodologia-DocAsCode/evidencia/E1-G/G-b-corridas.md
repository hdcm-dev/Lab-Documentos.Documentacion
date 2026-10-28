# G-b — Corridas reales en el runner sobre el SHA de cada merge de E1

- **Umbral**: N09 §9.2, fila G-b («Una corrida verde sobre el SHA del merge, con URL y SHA copiados a `evidencia/`»); folio 133, fila G-b («el merge de cada unidad | corre `docs-guard`/`verificar` en `[self-hosted, i7infra-dev]` | la corrida es verde sobre el SHA del merge | API de Actions | URL y SHA»).
- **Medido**: 2026-10-28, desde hpdev (contingencia por la caída de i7infra), con la API REST de GitHub (`/repos/{r}/pulls/{n}`, `/repos/{r}/actions/runs?per_page=100` en todas sus páginas, `/repos/{r}/actions/runs/{id}/jobs`). Totales leídos: Lab-Documentos 137 corridas, Lab-Documentos.Documentacion 13, Lab-E2E.WebBlazor 121.
- **Árboles**: `hdcm-dev/Lab-Documentos` en `{dir-de-trabajo}/ld-main` (detached en `490646bcba9db31d55d2710ddf2e73b9f5adaa89`); `hdcm-dev/Lab-Documentos.Documentacion` en `{dir-de-trabajo}/ldd-e1g`.
- **Runner**: «runner» es `runner_name` del job; «etiquetas» son las `labels` que la API devuelve para el job (las pedidas en `runs-on`). Las etiquetas registradas del runner no se pudieron leer: `/orgs/hdcm-dev/actions/runners` responde 403 («You must be an org admin or have the runners and runner groups fine-grained permission») y `/repos/hdcm-dev/Lab-Documentos/actions/runners` devuelve la lista vacía (el runner es de la organización).

## 1. Cuándo existe una corrida sobre el merge

`docs-guard` corre en `push` a `main` recién desde el #26:

```
$ git log --format='%h %ad %s' --date=iso -- .github/workflows/docs-guard.yml
9d00e42 2026-10-28 00:21:00 -0300 E1-G: reparaciones de cierre del escalón 1
265481d 2026-10-27 12:25:24 -0300 ci(docs-guard): grupos PR-1 a PR-7, autoprueba G-c/AK-7 y carril programado (E1-U2)
8c3fc99 2026-10-27 09:42:19 -0300 feat(docs-guard): compuerta mínima de documentación y delegación del merge
# en 8c3fc99 y 265481d: on: pull_request + workflow_call (sin push)
# en 9d00e42: on: pull_request + push: branches: [main] + workflow_dispatch + workflow_call
```

`docs-guard.yml:26-30` en `490646b`: `pull_request:`, el comentario «Compuerta E1-G (G-b): la corrida sobre el commit de merge queda en main.», `push: branches: [main]` y `workflow_dispatch:`.

El workflow `Verificar` de Lab-Documentos.Documentacion (`.github/workflows/verificar.yml:14-16`) corre en `pull_request` y `workflow_dispatch`, no en `push`; llama a `docs-guard` (job `docs-guard / docs-guard`).

Por eso, antes del #26 las únicas corridas sobre un SHA de merge son despachos a mano (`workflow_dispatch`) o el carril programado.

## 2. Tabla

Conclusión «—» = no hay corrida sobre ese SHA. «PR (cabeza)» = corrida `pull_request` cuya `head_sha` es la cabeza del PR; no es el SHA del merge.

| unidad | PR | merge SHA | corrida | conclusión | runner | URL |
| --- | --- | --- | --- | --- | --- | --- |
| E1-U0a | Lab-Documentos #11 | `f603984a3a4b35ea62feb7e5b3f68c0ad3331311` | sobre el merge: ninguna | — | — | — |
| | | cabeza `87c3b65` | docs-guard, PR (cabeza) | success | i7infra-runner-dev [self-hosted, i7infra-dev] | https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40508916199 |
| E1-U0b | Lab-Documentos.Documentacion #17 | `34bdd44895d199c62e0bddd85b29ea8a0d4f4a78` | sobre el merge: ninguna | — | — | — |
| | | cabeza `0cf7e8a` | Verificar, PR (cabeza) | success | i7infra-runner-dev [self-hosted, i7infra-dev] | https://github.com/hdcm-dev/Lab-Documentos.Documentacion/actions/runs/40511792195 |
| E1-U0c | Lab-Documentos.Documentacion #20 | `60d94f3c3aea84205f0a0ae3e50d6b8211aacae4` | sobre el merge: ninguna | — | — | — |
| | | cabeza `cc2bfd6` | Verificar, PR (cabeza) | success | i7infra-runner-dev [self-hosted, i7infra-dev] | https://github.com/hdcm-dev/Lab-Documentos.Documentacion/actions/runs/40526214446 |
| E1-U1 | Lab-Documentos #15 | `ad71e4745fc85b1a5889cc707ddb8f3006ac6ec2` | sobre el merge: ninguna | — | — | — |
| | | cabeza `fa33bc0` | docs-guard, PR (cabeza) | success | i7infra-runner-dev [self-hosted, i7infra-dev] | https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40514695217 |
| E1-U2 | Lab-Documentos #16 | `c0766dc03fa0fcd3793a5e1185867845465ca3ed` | docs-enlaces-semanal, `workflow_dispatch` sobre el merge (no es docs-guard) | success | i7infra-runner-dev [self-hosted, i7infra-dev] | https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40556547619 |
| | | cabeza `f9ebd8a` | docs-guard, PR (cabeza) | success | i7infra-runner-dev [self-hosted, i7infra-dev] | https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40554387515 |
| E1-U3 | Lab-Documentos #19 | `080f158b64d71928f8a4446971b20af5d1aa0e93` | mini-demo-movilidad, `workflow_dispatch` sobre el merge (no es docs-guard) | success | i7infra-runner-dev [self-hosted, i7infra-dev] | https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40578471106 |
| | | cabeza `c8b3183` | docs-guard, PR (cabeza) | success | i7infra-runner-dev [self-hosted, i7infra-dev] | https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40576440302 |
| E1-U4a | Lab-Documentos #20 | `e57aae24e579187aebf078b647718b4041582a7a` | sobre el merge: ninguna | — | — | — |
| | | cabeza `db7c8ce` | docs-guard, PR (cabeza) | success | i7infra-runner-dev [self-hosted, i7infra-dev] | https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40567848891 |
| E1-U4b | Lab-Documentos #22 | `6832a752ddbf7aaaaa555c200a9763588d8fc5ef` | sobre el merge: ninguna | — | — | — |
| | | cabeza `6dddbd7` | docs-guard, PR (cabeza) | success | i7infra-runner-dev [self-hosted, i7infra-dev] | https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40585466886 |
| E1-U4c | Lab-Documentos #24 | `ecb63420d2204ab6073136275713cb6be008e99e` | sobre el merge: ninguna | — | — | — |
| | | cabeza `fc6351e` | docs-guard, PR (cabeza) | success | i7infra-runner-dev [self-hosted, i7infra-dev] | https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40590237182 |
| E1-U4d | Lab-Documentos #23 | `2fdf859ce3c8131ba6226951b7981e7d046468d0` | sobre el merge: ninguna | — | — | — |
| | | cabeza `f697528` | docs-guard, PR (cabeza) | success | i7infra-runner-dev [self-hosted, i7infra-dev] | https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40588253783 |
| E1-U4e | Lab-Documentos #21 | `4fa998e613932dd5b767b9c220764fb351c6553d` | sobre el merge: ninguna | — | — | — |
| | | cabeza `c483d80` | docs-guard, PR (cabeza) | success | i7infra-runner-dev [self-hosted, i7infra-dev] | https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40580884735 |
| E1-U4f | Lab-Documentos #25 | `fe10086f2b083f6cfe227da49174d204c1b0e008` | sobre el merge: ninguna | — | — | — |
| | | cabeza `6839258` | docs-guard, PR (cabeza) | success | i7infra-runner-dev [self-hosted, i7infra-dev] | https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40593745133 |
| E1-U5 | Lab-Documentos.Documentacion #22 | `e0e520f2d5ca323d46cf202aacfba8e06349e283` | Verificar, `workflow_dispatch` sobre el merge (incluye `docs-guard / docs-guard`) | success | i7infra-runner-dev [self-hosted, i7infra-dev] | https://github.com/hdcm-dev/Lab-Documentos.Documentacion/actions/runs/40598387395 |
| | | mismo merge | Verificar, `workflow_dispatch` (segundo despacho) | success | i7infra-runner-dev [self-hosted, i7infra-dev] | https://github.com/hdcm-dev/Lab-Documentos.Documentacion/actions/runs/40626040276 |
| | | cabeza `8ef1fb0` | Verificar, PR (cabeza) | success | i7infra-runner-dev [self-hosted, i7infra-dev] | https://github.com/hdcm-dev/Lab-Documentos.Documentacion/actions/runs/40597128735 |
| E1-G (reparaciones) | Lab-Documentos #26 | `56ea2d3f754d9bb386b10e37add55477aa863079` | docs-guard, `push` a main sobre el merge | success | i7infra-runner-dev [self-hosted, i7infra-dev] | https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40628034346 |
| | | cabeza `e83f373` | docs-guard, PR (cabeza) | success | i7infra-runner-dev [self-hosted, i7infra-dev] | https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40626573338 |
| E1-G (frontmatter) | Lab-Documentos #27 | `75043a5ebc0de3fde976a8945eccbeebc312cbba` | docs-guard, `push` a main sobre el merge | success | **hpdev-runner-dev** [self-hosted, i7infra-dev] | https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40682252298 |
| | | cabeza `9b49337` | docs-guard, PR (cabeza) | success | **hpdev-runner-dev** [self-hosted, i7infra-dev] | https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40628526386 |
| E1-G (AGENTS.md) | Lab-Documentos #28 | `490646bcba9db31d55d2710ddf2e73b9f5adaa89` | docs-guard, `push` a main sobre el merge | success | **hpdev-runner-dev** [self-hosted, i7infra-dev] | https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40683351337 |
| | | cabeza `56f40c5` | docs-guard, PR (cabeza) | success | **hpdev-runner-dev** [self-hosted, i7infra-dev] | https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40682964089 |

Fuera del rango pedido (E1-U6, Lab-E2E.WebBlazor #12, merge `59399ba6678c56c3219988a5f9666fc4e0047160`): sobre el merge sólo hay la corrida programada `E2E` (`schedule`, success, job «Publicar la aplicación» en hpdev-runner-dev, el resto en runners alojados `ubuntu-latest`), https://github.com/hdcm-dev/Lab-E2E.WebBlazor/actions/runs/40665257981; la del PR (`CI`, cabeza `83542ab`, success) es https://github.com/hdcm-dev/Lab-E2E.WebBlazor/actions/runs/40505728851.

Todas las corridas de la tabla tienen `run_attempt` 1. En las corridas de PR también corrieron `framework-concept-demo` (y `mini-demo-movilidad` cuando correspondía), todas success; los ids están en la salida de la API y no cambian el veredicto.

## 3. Corrida de docs-guard en push a main sobre 490646b

```
GET /repos/hdcm-dev/Lab-Documentos/actions/runs/40683351337
docs-guard push main 490646bcba9db31d55d2710ddf2e73b9f5adaa89 completed success
  https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40683351337 2026-10-28T11:52:49Z 2026-10-28T11:53:18Z
GET .../runs/40683351337/jobs
docs-guard success hpdev-runner-dev self-hosted,i7infra-dev 2026-10-28T11:52:52Z
  https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40683351337/job/122799395977
```

Ya estaba terminada al consultarla; no hizo falta sondear.

## 4. E-F12: cambio de entorno, no falla

Desde la caída de i7infra (2026-10-28 00:50 -03), los jobs que piden `[self-hosted, i7infra-dev]` los toma **hpdev-runner-dev**, que acepta la etiqueta pedida `i7infra-dev` (la API lo muestra tomando esos jobs). Que además lleve `hpdev` viene del despacho y no se pudo leer del registro (403, ver arriba). Los workflows no cambiaron: `runs-on` sigue en `[self-hosted, i7infra-dev]` (`docs-guard.yml:54` en `490646b`). Corridas en hpdev dentro de esta tabla: 40628526386 (PR #27, job iniciado 2026-10-28T11:17:41Z; la corrida se creó a las 03:45:50Z, quedó en cola durante la caída y la tomó hpdev al volver), 40682252298, 40682964089 y 40683351337. En 40628526301 (framework-concept-demo del #27) el job `alcance` corrió en i7infra-runner-dev a las 03:48:13Z y `fw-ok` en hpdev-runner-dev a las 11:16:35Z: la corrida cruza los dos equipos.

## 5. Cotejo con el umbral

| caso | merges | resultado |
| --- | --- | --- |
| docs-guard/Verificar verde sobre el SHA del merge | E1-U5 (`e0e520f`), #26 (`56ea2d3`), #27 (`75043a5`), #28 (`490646b`) | cumple |
| corrida verde sobre el merge, pero de otro workflow | E1-U2 (`c0766dc`, docs-enlaces-semanal), E1-U3 (`080f158`, mini-demo-movilidad) | no es la que nombra el folio 133 |
| ninguna corrida sobre el SHA del merge | E1-U0a, E1-U0b, E1-U0c, E1-U1, E1-U4a, E1-U4b, E1-U4c, E1-U4d, E1-U4e, E1-U4f | no cumple |

Tomado al pie de la letra («una corrida verde sobre el SHA del merge» de `docs-guard`/`verificar` para cada unidad), **G-b no se cumple**: 4 de 16 merges (13 de E1 y 3 de E1-G) lo satisfacen.

### Atenuante medido (no reemplaza el umbral)

En Lab-Documentos, el árbol de cada commit de merge es idéntico al de la cabeza del PR, que tiene corrida docs-guard verde, y todos los merges son ancestros de `490646b`, que tiene su corrida verde en push:

```
$ for … ; do git rev-parse $merge^{tree} $cabeza^{tree}; git merge-base --is-ancestor $merge 490646b; done
U0a c20f694=c20f694 IGUAL   U1  4037f6e=4037f6e IGUAL   U2  5429c44=5429c44 IGUAL   U3  0e31729=0e31729 IGUAL
U4a cf6908d=cf6908d IGUAL   U4b d76f15f=d76f15f IGUAL   U4c b3fe9c5=b3fe9c5 IGUAL   U4d b7d5f62=b7d5f62 IGUAL
U4e c954f65=c954f65 IGUAL   U4f 0a3ade3=0a3ade3 IGUAL   #26 1c0fab9 IGUAL   #27 ec4f4a2 IGUAL   #28 3d266af IGUAL
(todos ancestros de 490646b)
```

En Lab-Documentos.Documentacion, E1-U0c (`60d94f3`) y E1-U5 (`e0e520f`) también tienen el mismo árbol que su cabeza. **E1-U0b (`34bdd44`) no**: su cabeza `0cf7e8a` estaba atrasada respecto de main, y el merge suma 6 archivos (225 líneas, entre ellos `040-archivo-cierre-del-expediente.md` y `041-constancia-g42-liberado-y-limpieza.md`) que la corrida del PR no vio.

Los dos hechos muestran que el contenido de cada merge de Lab-Documentos pasó docs-guard, pero no son una corrida sobre el SHA del merge. Aceptar la equivalencia por árbol es una decisión de la presidencia o de la mesa, no de esta verificación.

### Cómo se completaría

`docs-guard` tiene `workflow_dispatch` recién desde `9d00e42`. Un despacho actúa sobre una referencia (rama o etiqueta), y GitHub usa el workflow tal como está en esa referencia. En los merges anteriores al #26 el archivo no tiene `workflow_dispatch`, así que no se puede despachar docs-guard sobre esos SHA sin cambiar el workflow que corre. Para Lab-Documentos.Documentacion sí se puede: `Verificar` tiene `workflow_dispatch` desde E1-U0b, pero también necesita una referencia en `34bdd44` y otra en `60d94f3`. Crear esas referencias (ramas o etiquetas) queda fuera del alcance de este despacho.

## 6. Refutación (sostiene NO_CUMPLE y acota el atenuante)

Reproducida por la crítica del paquete el 2026-10-28, sobre `490646b` (Lab-Documentos) y `e0e520f` (Lab-Documentos.Documentacion).

```
$ sed -n 60,63p .github/workflows/docs-guard.yml       # Lab-Documentos, 490646b
      - name: Checkout del repositorio que se verifica
        uses: actions/checkout@11bd71901bbe5b1630ceea73d27597364c9af683 # v4.2.2
        with:
          persist-credentials: false
# sin «ref:» → en un evento pull_request el checkout toma refs/pull/N/merge (el merge sintético con la base)

$ git show e0e520f:.github/workflows/verificar.yml | sed -n 57,59p
    uses: hdcm-dev/Lab-Documentos/.github/workflows/docs-guard.yml@f603984a3a4b35ea62feb7e5b3f68c0ad3331311 # E1-U0a
    with:
      ruta: .github

$ git show f603984:.github/workflows/docs-guard.yml | grep -n 'name: [0-9]/3'
62:      - name: 1/3 herramientas
65:      - name: 2/3 enlaces
68:      - name: 3/3 estructura
```

- En Lab-Documentos, las corridas de PR verificaron el merge sintético; con árbol de merge = árbol de cabeza (§5), el contenido de cada merge pasó `docs-guard`. Sigue sin ser una corrida sobre el SHA del merge.
- La corrida de E1-U5 que cuenta como cumple (40598387395) llama a la suite mínima de E1-U0a (3 pasos) y sólo sobre `ruta: .github`: al pie de la letra es `Verificar`, pero no equivale a PR-1…PR-7.
- `N10-Plan-De-Implementacion.md:163` pide para `docs-guard.yml` sólo `pull_request` y `workflow_call`, y `:176` para `verificar.yml` sólo `pull_request`: con el plan como estaba, G-b no podía cumplirse antes de `9d00e42` (#26).
