# Antecedentes de los PR del escalón 1

Insumo de la constancia de reconciliación de la compuerta E1-G del expediente 0002 de DocAsCode. Los folios de
E1-U0c (citado como `230`), E1-U2, E1-U3, E1-U4a…E1-U4f y E1-U5 se escribieron en la máquina principal anterior y se
perdieron con ella (2026-10-28 00:50 -03); lo que sigue es lo que queda de esas unidades en GitHub.

| Campo | Valor |
| --- | --- |
| Fecha de la consulta | 2026-10-28 |
| Instrumento | API REST de GitHub, `GET /repos/hdcm-dev/{repo}/pulls/{n}`, una llamada por PR, con la credencial del equipo (no se imprime) |
| Campos | `title`, `head.ref`, `head.sha`, `merge_commit_sha`, `merged_at`, `merged_by.login`, `body` |
| Repos | `hdcm-dev/Lab-Documentos`, `hdcm-dev/Lab-Documentos.Documentacion`, `hdcm-dev/Lab-E2E.WebBlazor` (los tres públicos) |

## Índice

1. [Redacción aplicada](#1-redacción-aplicada)
2. [Tabla de PR → merge](#2-tabla-de-pr--merge)
3. [Fichas](#3-fichas)

## 1. Redacción aplicada

Las descripciones se transcriben íntegras, dentro de un bloque literal, tal como las devuelve la API. Antes de
escribirlas se barrieron los 17 `body` con el patrón S2 del folio 099 §11 (directorio personal del host, carpeta de
intermedios y raíz del workspace del equipo, usuario del equipo, IPv4 privadas, servicio y organización privados) y
el barrido dio **vacío**: el generador aborta si encuentra una coincidencia y no abortó. Ninguna descripción cita
rutas del host, el usuario del equipo, IP privadas ni repos u organizaciones privadas, así que **no se redactó nada
dentro de las descripciones**.

Única redacción: el campo `merged_by` es la cuenta personal del PO en GitHub en los 17 PR; se escribe
`{cuenta-del-PO}` (alias del README del expediente). Son 17 reemplazos, uno por ficha.

Se conservan sin redactar, porque son públicos y forman parte de lo que se audita: la etiqueta de runner
`i7infra-dev` (está en los workflows públicos) y los nombres `i7infra-runner-dev` / `hpdev-runner-dev` que aparecen
en otros anexos de E1-G.

## 2. Tabla de PR → merge

| Repo | PR | Unidad | Head SHA | Merge commit | `merged_at` (UTC) |
| --- | --- | --- | --- | --- | --- |
| Lab-Documentos | [#11](https://github.com/hdcm-dev/Lab-Documentos/pull/11) | E1-U0a | `87c3b65` | `f603984a3a4b35ea62feb7e5b3f68c0ad3331311` | 2026-10-27T13:21:33Z |
| Lab-Documentos | [#15](https://github.com/hdcm-dev/Lab-Documentos/pull/15) | E1-U1 | `fa33bc0` | `ad71e4745fc85b1a5889cc707ddb8f3006ac6ec2` | 2026-10-27T14:26:50Z |
| Lab-Documentos | [#16](https://github.com/hdcm-dev/Lab-Documentos/pull/16) | E1-U2 | `f9ebd8a` | `c0766dc03fa0fcd3793a5e1185867845465ca3ed` | 2026-10-27T18:04:28Z |
| Lab-Documentos | [#19](https://github.com/hdcm-dev/Lab-Documentos/pull/19) | E1-U3 | `c8b3183` | `080f158b64d71928f8a4446971b20af5d1aa0e93` | 2026-10-27T20:28:49Z |
| Lab-Documentos | [#20](https://github.com/hdcm-dev/Lab-Documentos/pull/20) | E1-U4a | `db7c8ce` | `e57aae24e579187aebf078b647718b4041582a7a` | 2026-10-27T19:34:59Z |
| Lab-Documentos | [#21](https://github.com/hdcm-dev/Lab-Documentos/pull/21) | E1-U4e | `c483d80` | `4fa998e613932dd5b767b9c220764fb351c6553d` | 2026-10-27T20:53:44Z |
| Lab-Documentos | [#22](https://github.com/hdcm-dev/Lab-Documentos/pull/22) | E1-U4b | `6dddbd7` | `6832a752ddbf7aaaaa555c200a9763588d8fc5ef` | 2026-10-27T21:27:46Z |
| Lab-Documentos | [#23](https://github.com/hdcm-dev/Lab-Documentos/pull/23) | E1-U4d | `f697528` | `2fdf859ce3c8131ba6226951b7981e7d046468d0` | 2026-10-27T21:43:03Z |
| Lab-Documentos | [#24](https://github.com/hdcm-dev/Lab-Documentos/pull/24) | E1-U4c | `fc6351e` | `ecb63420d2204ab6073136275713cb6be008e99e` | 2026-10-27T21:57:32Z |
| Lab-Documentos | [#25](https://github.com/hdcm-dev/Lab-Documentos/pull/25) | E1-U4f | `6839258` | `fe10086f2b083f6cfe227da49174d204c1b0e008` | 2026-10-27T22:26:15Z |
| Lab-Documentos | [#26](https://github.com/hdcm-dev/Lab-Documentos/pull/26) | E1-G (reparaciones) | `e83f373` | `56ea2d3f754d9bb386b10e37add55477aa863079` | 2026-10-28T03:40:31Z |
| Lab-Documentos | [#27](https://github.com/hdcm-dev/Lab-Documentos/pull/27) | E1-G (frontmatter) | `9b49337` | `75043a5ebc0de3fde976a8945eccbeebc312cbba` | 2026-10-28T11:44:11Z |
| Lab-Documentos | [#28](https://github.com/hdcm-dev/Lab-Documentos/pull/28) | E1-G (AGENTS.md, clase H) | `56f40c5` | `490646bcba9db31d55d2710ddf2e73b9f5adaa89` | 2026-10-28T11:52:46Z |
| Lab-Documentos.Documentacion | [#17](https://github.com/hdcm-dev/Lab-Documentos.Documentacion/pull/17) | E1-U0b | `0cf7e8a` | `34bdd44895d199c62e0bddd85b29ea8a0d4f4a78` | 2026-10-27T13:56:12Z |
| Lab-Documentos.Documentacion | [#20](https://github.com/hdcm-dev/Lab-Documentos.Documentacion/pull/20) | E1-U0c | `cc2bfd6` | `60d94f3c3aea84205f0a0ae3e50d6b8211aacae4` | 2026-10-27T15:01:17Z |
| Lab-Documentos.Documentacion | [#22](https://github.com/hdcm-dev/Lab-Documentos.Documentacion/pull/22) | E1-U5 | `8ef1fb0` | `e0e520f2d5ca323d46cf202aacfba8e06349e283` | 2026-10-27T22:48:39Z |
| Lab-E2E.WebBlazor | [#12](https://github.com/hdcm-dev/Lab-E2E.WebBlazor/pull/12) | E1-U6 | `83542ab` | `59399ba6678c56c3219988a5f9666fc4e0047160` | 2026-10-27T12:59:18Z |

## 3. Fichas

### Lab-Documentos #11 — E1-U0a

| Campo | Valor |
| --- | --- |
| URL | https://github.com/hdcm-dev/Lab-Documentos/pull/11 |
| Título | feat(docs-guard): compuerta mínima de documentación y delegación del merge (E1-U0a) |
| Estado | `closed`, `merged=true` |
| Rama | `exp0002/e1-u0a-delegacion-y-docs-guard` → `main` |
| Head SHA | `87c3b65419c0abc58a35d61e854b739c85f964dd` |
| `merge_commit_sha` | `f603984a3a4b35ea62feb7e5b3f68c0ad3331311` |
| `merged_at` | 2026-10-27T13:21:33Z |
| `merged_by` | `{cuenta-del-PO}` (redactado: cuenta personal del PO) |
| Largo de la descripción | 2096 caracteres |

Descripción íntegra:

`````markdown
## Unidad declarada

Expediente 0002 de DocAsCode, unidad **E1-U0a** (raíz del escalón 1): compuerta mínima de documentación `docs-guard` y sección «Delegación del merge» en `CHANGELOG.md`. Toca `.github/workflows/docs-guard.yml`, `scripts/` y `CHANGELOG.md`; no toca la demo ni las guías.

- `docs-guard.yml`: `pull_request` y `workflow_call`; un job en `[self-hosted, i7infra-dev]`, `timeout-minutes: 10`, grupo `docs-${{ github.workflow }}-${{ github.ref }}` con `cancel-in-progress` en PR; `lychee --offline --include-fragments` y markdownlint estructural sobre la guía del sistema documentador; `permissions: contents: read`, sin `pull_request_target`, actions fijadas por SHA, guarda `if:` contra forks; sin `container:`.
- `scripts/ci-local.sh`: los mismos pasos en el mismo orden.
- Línea de base: los 8 enlaces rotos de la guía se excluyen con nombre en `scripts/docs-guard.lychee.toml`; 7 los sanea E1-U1 y 1 es el defecto plantado de la prueba de concepto.

## Delegación del merge (testimonio del PO)

Primer merge del repositorio dentro del expediente 0002, fusionado por `Conformacion-Pull-Request-Automatico` 2.0 por pedido explícito del PO (folio 130 §2 y §3, en `hdcm-dev/Lab-Documentos.Documentacion`). Testimonio literal, fila L2, 2026-10-27:

> «esto surgió porque despues de un avance surgia preguntas y confirmaciones tontas … Mi objetivo es que se enriquesca de tal forma el conocimiento analitico que los subagentes con este conocimiento puedan orquestar de forma automatica todo el proceso de desarrollo»

Guarda: techo 120 min, intervalo 30 s, `clean` y controles de la cabeza en éxito (al menos uno). Dependencia: PRE-03 (folio 133), hecha; la rama sale de `origin/main`.

## Qué sigue después del merge

Nada que publicar. E1-U0b llama a este workflow por SHA; E1-U1 retira las exclusiones de la línea de base.

## ¿Cambia el propósito declarado en la ficha de tienda?

- [x] No aplica (el PR no toca la demo)

## ¿Cambia los datos que se recogen o se comparten?

- [x] No aplica (el PR no toca la demo)

🤖 Generated with [Claude Code](https://claude.com/claude-code)
`````

### Lab-Documentos #15 — E1-U1

| Campo | Valor |
| --- | --- |
| URL | https://github.com/hdcm-dev/Lab-Documentos/pull/15 |
| Título | E1-U1: saneamiento con alcance cerrado de la guía del sistema documentador |
| Estado | `closed`, `merged=true` |
| Rama | `exp0002/e1-u1-saneamiento-guia` → `main` |
| Head SHA | `fa33bc0ea928b3888a52915c699586919fdd4bd0` |
| `merge_commit_sha` | `ad71e4745fc85b1a5889cc707ddb8f3006ac6ec2` |
| `merged_at` | 2026-10-27T14:26:50Z |
| `merged_by` | `{cuenta-del-PO}` (redactado: cuenta personal del PO) |
| Largo de la descripción | 1843 caracteres |

Descripción íntegra:

`````markdown
## E1-U1 — Saneamiento con alcance cerrado de la guía actual

Expediente 0002 de DocAsCode, decisión D02 (FIRME). Rama basada en `origin/main` (f603984, con E1-U0a ya fusionada).

### Alcance aplicado
- 8 enlaces rotos de la guía (`../Documentacion-Tecnica/` → `../Creacion-Guias-Tecnicas/`); exclusión retirada de `scripts/docs-guard.lychee.toml`.
- Frontmatter atípico (`status`, `origin`, `confidence`, `audience`) y `DOC-ADR` duplicado en `traces`.
- Cita literal de ACT-10; Docusaurus fijado por commit (no `main`); `@props` en lugar de `@product`.
- `llms.txt` deja de ser «adoptada» (X5).
- Ítems de R02 §11.2: recuento de páginas, `translation_of`, `$P` de `Lanzar-Example.md`, `302`/`401` (no re-medidos).
- Tabla única de contrato de frontmatter (7.3, con `owner` y `last_review`).
- `README.md` y `Guides/README.md` (vacíos) con ruta de lectura mínima.
- **Se conservan** el defecto plantado de la consola y los dos respaldos de cultura de `Web/Ayuda/en/` (exclusiones permanentes con motivo). No se aplica APA.

### Criterios
1. `lychee --offline` sobre GUIA-DIR: exit 0 (24 total, 20 OK, 0 errores, 4 excluidos: 3 con nombre + 1 externo).
2. `grep -c adoptad` en la guía: 0.
3. PR-1 (enlaces) y PR-4 (markdownlint estructural 0 errores; mermaid 6 bloques, 0 inválidos): línea de base 0.

Ensayo: `scripts/ci-local.sh` → verde.

### Delegación del merge
Merge automático conforme a Knowledge-Conformacion-Pull-Request-Automatico (clase P). Testimonio del PO (2026-10-27, L2, asentado en el CHANGELOG): «esto surgió porque despues de un avance surgia preguntas y confirmaciones tontas … Mi objetivo es que se enriquesca de tal forma el conocimiento analitico que los subagentes con este conocimiento puedan orquestar de forma automatica todo el proceso de desarrollo».

🤖 Generated with [Claude Code](https://claude.com/claude-code)
`````

### Lab-Documentos #16 — E1-U2

| Campo | Valor |
| --- | --- |
| URL | https://github.com/hdcm-dev/Lab-Documentos/pull/16 |
| Título | ci(docs-guard): grupos PR-1 a PR-7, autoprueba G-c/AK-7 y carril programado (E1-U2) |
| Estado | `closed`, `merged=true` |
| Rama | `exp0002/e1-u2-docs-guard-completo` → `main` |
| Head SHA | `f9ebd8a96aa0f461075d01788d6f47a3631d5ff4` |
| `merge_commit_sha` | `c0766dc03fa0fcd3793a5e1185867845465ca3ed` |
| `merged_at` | 2026-10-27T18:04:28Z |
| `merged_by` | `{cuenta-del-PO}` (redactado: cuenta personal del PO) |
| Largo de la descripción | 2564 caracteres |

Descripción íntegra:

`````markdown
## E1-U2 — docs-guard completo y herramientas

Expediente 0002 de DocAsCode, onda 3. Rama desde `main` ad71e47 (E1-U1 ya fusionada, PR #15).

### Qué trae

- `.github/workflows/docs-guard.yml`: un solo job con los grupos PR-1 a PR-7, `autoprueba` y `avisos`, cada uno con `continue-on-error`, y un **agregador estricto** al final.
- `tools/docs-guard/`: `dg.py` (biblioteca estándar) con los controles portados de los prototipos de las comisiones (verificación, anti-inyección `agent_channels`, `reflint`); esquemas de frontmatter; `prefijos.txt`; `excepciones.txt` (AK-3, con huella); `dominios.txt` (AK-4, clase P con aprobación); mermaid por lockfile.
- `tools/docs-guard/fixtures/`: par rojo/verde por control bloqueante y fixture permanente **AK-7**, que tiene que dar rojo en cada corrida.
- `.github/workflows/docs-enlaces-semanal.yml` + `tools/docs-guard/semanal.sh` + `arbol.tsv` (tabla repo → ruta): carril programado, sólo aviso, `issues: write` sólo para el issue del informe.
- `scripts/ci-local.sh`: mismos pasos, mismo orden.

Seguridad: `permissions: contents: read` (más `issues: write` sólo en el carril programado), sin `pull_request_target`, actions fijadas por SHA, guarda `if:` contra forks, ningún secreto en el carril PR.

### Criterios de aceptación

| # | Criterio | Estado |
| --- | --- | --- |
| 1 | Par rojo/verde por control bloqueante (G-c) | Sí: paso `autoprueba` |
| 2 | AI-3 avisa y no bloquea | Sí: caso 09 del ensayo, rc=0 con aviso |
| 3 | AI-4 sólo avisa en el anexo de referencias | Sí: par `ai-4` / `ai-4-anexo` |
| 4 | Fixture AK-7 rojo en cada corrida | Sí: caso 16 (desarmado → autoprueba rojo) |
| 5 | Carril programado corrido a mano con issue | Se corre por `workflow_dispatch` tras el merge (el workflow tiene que estar en `main`) |
| 6 | E-F10 y E-F14 | E-F10: AI-3 = 0 en la guía, 13 en `Guides/` (2 archivos sobre cómo se arma un agente). E-F14: árbol de 4 repos en ~16 s, 136 MB |

### Ensayo de cierre

`ci-local.sh todo` con cada defecto plantado, uno por vez (18 casos): cada uno dio rojo sólo en su grupo; la base y AI-3 dieron verde.

### Conformación

Primer merge delegado de este repo por conformación automática (CPA), con la delegación asentada por escrito por el PO el 2026-10-27: «Mi objetivo es que se enriquesca de tal forma el conocimiento analitico que los subagentes con este conocimiento puedan orquestar de forma automatica todo el proceso de desarrollo». Después del merge: etiqueta `docs-guard-v1.0.0` sobre el commit de merge.

🤖 Generated with [Claude Code](https://claude.com/claude-code)
`````

### Lab-Documentos #19 — E1-U3

| Campo | Valor |
| --- | --- |
| URL | https://github.com/hdcm-dev/Lab-Documentos/pull/19 |
| Título | E1-U3: mini demo MovilidadUrbana con anclas al SHA y contrato extraído en ejecución |
| Estado | `closed`, `merged=true` |
| Rama | `exp0002/e1-u3-mini-demo-movilidad` → `main` |
| Head SHA | `c8b31837a7e6692661ce8cf14ae64f5c1110680d` |
| `merge_commit_sha` | `080f158b64d71928f8a4446971b20af5d1aa0e93` |
| `merged_at` | 2026-10-27T20:28:49Z |
| `merged_by` | `{cuenta-del-PO}` (redactado: cuenta personal del PO) |
| Largo de la descripción | 7576 caracteres |

Descripción íntegra:

`````markdown
## E1-U3 — Mini demo MovilidadUrbana en `Examples/`

Expediente 0002 de DocAsCode, unidad E1-U3 (onda 4 del plan). Base: `origin/main` en `c0766dc` (E1-U2 ya fusionada, PR #16).

### Qué trae

- `Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/Examples/MovilidadUrbana-Mini-Demo/`: `source.lock` (Lab-E2E.WebBlazor, `8fb4c3a`), RRD (`docs/_requisitos.md`), fichas `RN-LOC-01` (1.1, divergencia 60/80 de fondo) y `RN-LOC-02` con anclas `ruta#Símbolo@SHA`, ayuda CL-06, técnica CL-07, `contracts/openapi.json` extraído en ejecución del SHA, `README.md` con el tutorial y `verificar.sh`.
- `.github/workflows/mini-demo-movilidad.yml` (un workflow): `git archive` del SHA, compila y arranca la ApiWeb, extrae `GET /openapi/v1.json` y corre C1 contrato (bloquea), C2 operación plantada (tiene que dar exit 1), C3 trazas de nivel 1 y 2 (bloquea), C4 la ficha RN-LOC-01 sin corregir (tiene que dar rojo por el 60/80) y A1 deriva contra `main` de Lab-E2E.WebBlazor (avisa).
- `tools/docs-guard/`: anclas de nivel 2 en `dg.py trazas --fuente` / `--deriva`; filas `RD-nn` del RRD en el registro; prefijo `DEMO`; un contrato con `source.lock` que declara `workflow:` lo compara ese workflow; fixtures `anclas/` (par rojo/verde en la autoprueba y la negativa real `real-rn-loc-01/`).

Seguridad del workflow: `runs-on: [self-hosted, i7infra-dev]`, `permissions: contents: read`, sin `pull_request_target`, checkout fijado por SHA, guarda `if:` contra forks, sin secretos (el repo del código es público y se baja anónimo), `timeout-minutes: 15`. No se modifica ningún archivo de Lab-E2E.WebBlazor.

### Ensayo de cierre (local, imagen del runner)

```text
== C1 contrato: contracts/openapi.json frente al extraído de 8fb4c3a8b1cc629027f456c7c3ce19e041164c06
    == PR-6 contrato: verde (errores=0 avisos=0) operaciones=8
== C2 plantado: una operación de más tiene que dar exit 1
    /trabajo/plantado.json:1: ERROR operacion-nueva: GET /api/v1/plantada no está en el contrato versionado
  ok    C2: rojo (rc=1)
== C3 trazas: traces-resolve y anclas contra 8fb4c3a8b1cc629027f456c7c3ce19e041164c06
    == PR-5 traces-resolve: verde (errores=0 avisos=0) trazas=17 resueltas=17 anclas=10 anclas-resueltas=10
== C4 negativa: RN-LOC-01 sin corregir (defecto real 60/80) tiene que dar rojo
    RN-LOC-01.md:62: ERROR ancla-no-contiene: LocalidadRules.NombreValido no contiene «LargoMaximoDelNombre»
    RN-LOC-01.md:63: ERROR ancla-valor-distinto: NombreEntry.MaxLength: la ficha afirma 60 y el código tiene 80
  ok    C4: rojo por el defecto real 60/80 (rc=1, 2 anclas)
== A1 deriva contra main (avisa, no bloquea)
  contrato: sin deriva frente a main (59399ba6678c56c3219988a5f9666fc4e0047160)
  anclas: sin deriva frente a main (59399ba6678c56c3219988a5f9666fc4e0047160)
== mini demo: verde
```

### Corrida en el runner (cabeza final `c8b3183`)

docs-guard (run 40576440302, 1 min 43 s), mini-demo-movilidad (run 40576440254, 1 min 35 s; `verificar.sh` 63 s de pared) y framework-concept-demo (run 40576440359, 36 s): las tres en éxito en `[self-hosted, i7infra-dev]`. E-F13: push → última corrida, 11 min 13 s (3 min 54 s de jobs, el resto cola del runner único). R-E4 repetido en el runner: 5 rutas y 8 operaciones, extracción en 29 s. dotnet 10 está en la imagen (N10 §12).

```text
== fuente: https://github.com/hdcm-dev/Lab-E2E.WebBlazor.git @ 8fb4c3a8b1cc629027f456c7c3ce19e041164c06 y main
  8fb4c3a8b1cc629027f456c7c3ce19e041164c06 -> 8fb4c3a8b1cc629027f456c7c3ce19e041164c06 (103 archivos)
  main -> 59399ba6678c56c3219988a5f9666fc4e0047160 (103 archivos)
== contrato: extracción en ejecución (SHA)


  contrato: 5 rutas, 8 operaciones, OpenAPI 3.1.1
  extraído en 29 s
== contrato: extracción en ejecución (main)


  contrato: 5 rutas, 8 operaciones, OpenAPI 3.1.1
  extraído en 21 s
== C1 contrato: contracts/openapi.json frente al extraído de 8fb4c3a8b1cc629027f456c7c3ce19e041164c06
    == PR-6 contrato: verde (errores=0 avisos=0) operaciones=8
  ok    C1: verde (rc=0)
== C2 plantado: una operación de más tiene que dar exit 1
    $RUNNER_TEMP/mini-demo-movilidad/plantado.json:1: ERROR operacion-nueva: GET /api/v1/plantada no está en el contrato versionado
    == PR-6 contrato: ROJO (errores=1 avisos=0) operaciones=8
  ok    C2: rojo (rc=1)
== C3 trazas: traces-resolve y anclas contra 8fb4c3a8b1cc629027f456c7c3ce19e041164c06
    == PR-5 traces-resolve: verde (errores=0 avisos=0) trazas=17 resueltas=17 anclas=10 anclas-resueltas=10
  ok    C3: verde (rc=0)
== C4 negativa: RN-LOC-01 sin corregir (defecto real 60/80) tiene que dar rojo
    RN-LOC-01.md:62: ERROR ancla-no-contiene: LocalidadRules.NombreValido no contiene «LargoMaximoDelNombre»
    RN-LOC-01.md:63: ERROR ancla-valor-distinto: NombreEntry.MaxLength: la ficha afirma 60 y el código tiene 80
    == PR-5 traces-resolve: ROJO (errores=2 avisos=0) trazas=1 resueltas=1 anclas=6 anclas-resueltas=4
  ok    C4: rojo por el defecto real 60/80 (rc=1, 2 anclas)
== A1 deriva contra main (avisa, no bloquea)
    == PR-6 contrato: verde (errores=0 avisos=0) operaciones=8
  contrato: sin deriva frente a main (59399ba6678c56c3219988a5f9666fc4e0047160)
    == PR-5 traces-resolve (deriva: sólo avisa): verde (errores=0 avisos=0) anclas=10 resueltas=10
  anclas: sin deriva frente a main (59399ba6678c56c3219988a5f9666fc4e0047160)
== agregador mini demo
  C1  verde
  C2  verde
  C3  verde
  C4  verde
== mini demo: verde
== tiempo de pared: 63 s
```

### Durante la unidad

- **Integración de `main`**: E1-U4a (PR #20) se fusionó a mitad de camino y dejó el PR en `dirty`; se integró `origin/main` (conflictos en `CHANGELOG.md` y `prefijos.txt`, resueltos dejando las dos entradas). La guía es ahora el cuerpo SDEI: el README del cuerpo enlaza la demo (`DEMO-MU-00`) y el anexo de prefijos suma `DEMO`.
- **Defectos propios corregidos en la unidad**: el registro de IDs no excluía `tools/docs-guard/fixtures/` del repo verificado (en la CI las herramientas van en `.docs-guard/`: RD-01 y RN-LOC-01 quedaban ambiguos, run 40567079738); C4 contaba líneas « ERROR » y en el runner `dg.py` anota con `::error` (run 40568169682).
- **P-LECT**: nueve rondas con lectores sin contexto (agente de sólo lectura, consigna de E1 de F012 §6: documentar el paso 1 de la Encuesta y proponerlo por PR simulado). Con respuesta no alcanzada: 1, 1 y después 0 en siete rondas seguidas. Huecos: 14, 7, 7, 11, 5, 6, 3, 6, 4: cada lector abre bordes nuevos del método de clasificación de reglas. §8 del tutorial los declara fuera de alcance y §5.6 los canaliza como supuestos del PR (F012 §6, fila E1: «huecos = 0 o declarados fuera de alcance»). Las 21 anclas que propuso el primer lector resolvieron al primer intento contra el SHA. El cero estricto sobre el texto final queda para la P-LECT de E1-G (G-e).

Piezas de la demo: 13 (10 en la carpeta, el workflow y la negativa real); el PR toca además 8 fixtures genéricos del control nuevo (G-c) y modifica 7 archivos existentes.


- **Merge:** delegado — se fusiona si la guarda pasa y no hay reserva.
- **Delegación:** `CHANGELOG.md` de este repositorio, sección «Delegación del merge» del 2026-10-27; asiento en el folio 130 §2 del expediente 0002 (`hdcm-dev/Lab-Documentos.Documentacion`); decidió el PO. Testimonio literal (L2): «esto surgió porque despues de un avance surgia preguntas y confirmaciones tontas … Mi objetivo es que se enriquesca de tal forma el conocimiento analitico que los subagentes con este conocimiento puedan orquestar de forma automatica todo el proceso de desarrollo».

🤖 Generated with [Claude Code](https://claude.com/claude-code)
`````

### Lab-Documentos #20 — E1-U4a

| Campo | Valor |
| --- | --- |
| URL | https://github.com/hdcm-dev/Lab-Documentos/pull/20 |
| Título | E1-U4a: esqueleto del cuerpo SDEI (README, Marco, Mapa y anexos) |
| Estado | `closed`, `merged=true` |
| Rama | `exp0002/e1-u4a-cuerpo-esqueleto` → `main` |
| Head SHA | `db7c8ce5c182f85d6f82a6d446cc2981c56e5d9e` |
| `merge_commit_sha` | `e57aae24e579187aebf078b647718b4041582a7a` |
| `merged_at` | 2026-10-27T19:34:59Z |
| `merged_by` | `{cuenta-del-PO}` (redactado: cuenta personal del PO) |
| Largo de la descripción | 4572 caracteres |

Descripción íntegra:

`````markdown
## E1-U4a — Esqueleto del cuerpo documental `SDEI` (2.0.0-borrador)

Unidad E1-U4a del plan de implementación del expediente 0002 de DocAsCode (N10 §6), onda 4. Base: `origin/main` en c0766dc (E1-U2 fusionada, PR #16).

### Qué agrega

En `Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/`:

| Archivo | `doc_id` | Contenido |
| --- | --- | --- |
| `README.md` | `IDX-SDEI` | `corpus_id: SDEI`, `version: 2.0.0-borrador`, objetivos `OBJ-SDEI-01..05`, tres rutas (aprender, intervenir, agente; D27), tabla de contenido completa |
| `00-Marco.md` | `MARCO-SDEI` | Escenarios `ESC-SDEI-1..4` (= V1–V4), contextos `CTX-SDEI-1..4`, actores `ACT-SDEI-1..6`, convenciones |
| `01-Mapa.md` | `MAPA-SDEI` | «Estoy acá → qué aplico» por escenario, contexto, artefacto (CL-01..14) y actor; índice de anexos |
| `99-Anexos/Esquema-Frontmatter-Y-Prefijos.md` | `ANX-SDEI-ESQUEMA` | CR-4: diez campos más `description`, trazas, registro de prefijos, forma del RRD |
| `99-Anexos/Glosario.md` | `ANX-SDEI-GLOSARIO` | Términos y siglas, con dónde se ancla cada uno |
| `99-Anexos/Referencias.md` | `ANX-SDEI-REFERENCIAS` | 31 referencias APA 7 con anclas `ref-…` y fecha de consulta (D28) |
| `99-Anexos/Criterios-De-Calidad.md` | `ANX-SDEI-CQ` | CQ-01..14 y qué control de `docs-guard` automatiza cada uno |
| `99-Anexos/Patrones-De-Ejemplos.md` | `ANX-SDEI-PE` | PE-01..12 y marcas de procedencia |
| `99-Anexos/Lista-De-Verificacion.md` | `ANX-SDEI-VER` | Ítems VER-* aplicables a una guía |
| `99-Anexos/Como-Decidir.md` | `ANX-SDEI-DECIDIR` | Criterios K1–K7, escala anclada, filtros, firmeza, matriz trabajada (D27) y quién decide |
| `99-Anexos/Ejercicios.md` | `ANX-SDEI-EJERCICIOS` | `EJR-SDEI-01..05` con claves (default de L6, folio 131) |

Además: `Examples/Lanzar-Example.md` suma frontmatter (`GP-SDEI-LANZAR`) porque el cuerpo nuevo lo exige; `tools/docs-guard/prefijos.txt` registra `GP`; entrada en `CHANGELOG.md`.

### Criterios de aceptación

| # | Criterio | Cumple | Evidencia |
| --- | --- | --- | --- |
| 1 | `docs-guard` verde | Sí (local); runner: ver la corrida de este PR | `scripts/ci-local.sh todo` → `docs-guard: verde`, 8/8 grupos; 25 casos de autoprueba ok |
| 2 | Todo documento con los diez campos más `description` | Sí | PR-2: 25 archivos con frontmatter, 0 errores; chequeo de campos: 12/12 documentos nuevos o tocados OK |
| 3 | README con tabla de contenido completa y rutas (VER-G07) | Sí | README §3 (tres rutas) y §4 (todos los archivos de la carpeta, más los temas en redacción) |
| 4 | Cada anexo enlazado desde el Mapa | Sí | Los 8 anexos aparecen en `01-Mapa.md` (2 a 6 enlaces cada uno; §6 los lista todos) |

### Ensayo de cierre

```text
== agregador docs-guard
  enlaces      verde   (lychee: 233 enlaces, 201 OK, 0 errores, 32 excluidos)
  esquema      verde   (archivos-con-frontmatter=25)
  ai           verde   (AI-1..AI-5 = 0; AI-4 = 25 avisos, todos en el anexo de referencias)
  estructura   verde   (mermaid: 14 bloques, 0 inválidos)
  trazas       verde   (55 trazas, 46 resueltas, 9 avisos heredados de la PoC de ayuda por rol)
  contrato     verde
  fijadas      verde   (reflint: 31 referencias)
  autoprueba   verde
== docs-guard: verde
```

Defectos plantados en el cuerpo nuevo, uno por vez y revertidos: ancla rota en el Marco → PR-1 rojo (`Cannot find fragment`); `description` borrada → PR-2 rojo; año borrado de una referencia → PR-7 `reflint` rojo (`ref-sin-anio`).

**P-LECT parcial** (README, Marco y Mapa, por un lector sin contexto que no ve los anexos), tres rondas: dudas de gravedad alta 9 → 6 → 4, y las cuatro de la última ronda corregidas antes de este commit. Quedan dudas medias y bajas, en su mayoría respondidas por los anexos o propias de los temas en redacción. El umbral de cero dudas rige para la compuerta E1 (G-e), no para esta unidad.

### Barrido S2

Vacío sobre el diff: sin rutas del equipo, IPs privadas, hosts, usuarios ni nombres de repositorios privados (el servicio push se nombra SDD-B).

- **Merge:** delegado — se fusiona si la guarda pasa y no hay reserva.
- **Delegación:** `CHANGELOG.md`, sección «Delegación del merge (Conformacion-Pull-Request-Automatico 2.0)», 2026-10-27, decidida por el PO. Testimonio literal del PO (fila L2): «esto surgió porque despues de un avance surgia preguntas y confirmaciones tontas … Mi objetivo es que se enriquesca de tal forma el conocimiento analitico que los subagentes con este conocimiento puedan orquestar de forma automatica todo el proceso de desarrollo».

🤖 Generated with [Claude Code](https://claude.com/claude-code)
`````

### Lab-Documentos #21 — E1-U4e

| Campo | Valor |
| --- | --- |
| URL | https://github.com/hdcm-dev/Lab-Documentos/pull/21 |
| Título | E1-U4e: AGENTS.md puntero de la ruta «agente» |
| Estado | `closed`, `merged=true` |
| Rama | `exp0002/e1-u4e-agents-md` → `main` |
| Head SHA | `c483d80a133e544ade8bb21f17c0ebd46179c2e1` |
| `merge_commit_sha` | `4fa998e613932dd5b767b9c220764fb351c6553d` |
| `merged_at` | 2026-10-27T20:53:44Z |
| `merged_by` | `{cuenta-del-PO}` (redactado: cuenta personal del PO) |
| Largo de la descripción | 2343 caracteres |

Descripción íntegra:

`````markdown
## E1-U4e — `AGENTS.md` puntero de Lab-Documentos

Expediente 0002 de DocAsCode, unidad E1-U4e (onda 5). Depende de E1-U4a, ya fusionada (#20, e57aae2); la rama sale de `origin/main` (080f158).

### Qué entra

- **`AGENTS.md`** en la raíz: puerta de la ruta «agente» del cuerpo `SDEI` (D27, CL-03). Dice qué es el repositorio, qué leer y en qué orden (README del cuerpo → convenciones del Marco → esquema de frontmatter → glosario → Mapa), cómo validar con `scripts/ci-local.sh`, qué puede proponer un agente (clase P) y qué es clase H, y enlaza los anexos de referencia. No repite reglas: si difiere del documento al que apunta, vale el documento.
- **`tools/docs-guard/excepciones.txt`**: primera excepción con huella (AK-3): `AGENTS.md` fuera de AI-3 mientras su SHA-256 sea `2449556…fafb`.
- **`scripts/ci-local.sh`**: `enlaces`, `ai` y `estructura` revisan también el `AGENTS.md` de la raíz, si existe; si falta, `enlaces` avisa (el script lo usan otros repositorios por el workflow reutilizable, que lo toman por SHA fijado).
- README del cuerpo y README de la raíz enlazan `AGENTS.md`; `tools/docs-guard/README.md` y `CHANGELOG.md` lo documentan.

### Criterios de aceptación (N10 §6)

| Criterio | Resultado |
| --- | --- |
| Existe | Sí: `AGENTS.md` en la raíz |
| Sus enlaces resuelven | Sí: lychee `--offline --include-fragments` sobre `AGENTS.md`: 26 enlaces, 26 OK. Con un destino y un ancla plantados rotos, PR-1 da rojo (rc=1) |
| Excluido de AI-3 por ruta con huella (AK-3) | Sí: sin la excepción, AI-3=1 (aviso); con ella, AI-3=0; con el archivo cambiado y la huella sin renovar, AI-3=1 otra vez |

Ensayo de cierre: `scripts/ci-local.sh` (todo) verde, 8/8 grupos, con `AGENTS.md` dentro de enlaces, ai y estructura.

### Conformación

Cambiar `AGENTS.md` es clase H. Este PR se fusiona por la guarda G1–G4 de Conformacion-Pull-Request-Automatico porque el PO delegó el merge por escrito, también para este primer merge de clase H (expediente 0002, folio 130 §2, testimonio L2 del 2026-10-27):

> «esto surgió porque despues de un avance surgia preguntas y confirmaciones tontas … Mi objetivo es que se enriquesca de tal forma el conocimiento analitico que los subagentes con este conocimiento puedan orquestar de forma automatica todo el proceso de desarrollo»

🤖 Generated with [Claude Code](https://claude.com/claude-code)
`````

### Lab-Documentos #22 — E1-U4b

| Campo | Valor |
| --- | --- |
| URL | https://github.com/hdcm-dev/Lab-Documentos/pull/22 |
| Título | E1-U4b: temas 01 a 03 del cuerpo SDEI |
| Estado | `closed`, `merged=true` |
| Rama | `exp0002/e1-u4b-temas-01-03` → `main` |
| Head SHA | `6dddbd7d933d0b709bed5162c55bd61a4c360bb3` |
| `merge_commit_sha` | `6832a752ddbf7aaaaa555c200a9763588d8fc5ef` |
| `merged_at` | 2026-10-27T21:27:46Z |
| `merged_by` | `{cuenta-del-PO}` (redactado: cuenta personal del PO) |
| Largo de la descripción | 5112 caracteres |

Descripción íntegra:

`````markdown
## E1-U4b — Temas 01 a 03 del cuerpo SDEI

Unidad E1-U4b del plan de implementación del expediente 0002 de DocAsCode (onda 5, grupo paralelo P-C). Rama basada en `origin/main` `080f158`, que ya contiene la dependencia E1-U4a (PR #20, merge `e57aae2`).

### Qué agrega

| Archivo (en la guía del sistema documentador) | `doc_id` | Contenido |
| --- | --- | --- |
| `TEM-01-Sistema-Documentador.md` | `TEM-SDEI-01` | Definición y arquitectura de referencia, catálogo breve de clases, el portal de un proveedor de notificaciones como caso de industria, adopciones públicas P1–P3 con fecha, inventario por comando, un cambio recorrido de punta a punta, plantilla de inventario |
| `TEM-02-Ciclo-Documental.md` | `TEM-SDEI-02` | Fases 1a a 5 y 5m con entradas, salidas, actores y controles; RRD con Dado/Cuando/Entonces; estados; cláusulas; plantilla de RRD y de cláusula |
| `TEM-03-Topologia-Y-Versionado.md` | `TEM-SDEI-03` | Cuatro topologías, anclas (commit, SHA fijado, etiqueta, versión del cuerpo) y dónde se escriben, la regla del mismo pull request, adopciones públicas P4–P6 con fecha, ensayo de traza desfasada e ID ambiguo, plantilla de topología y ancla |
| `99-Anexos/Referencias.md` | — | §7: SemVer, Keep a Changelog, Diátaxis, GivenWhenThen y doce repositorios públicos citados por commit |
| `README.md`, `01-Mapa.md`, `CHANGELOG.md` | — | La tabla de contenido enlaza los tres temas; el Mapa sigue al tema 01; entrada del CHANGELOG |

Los IDs llevan el `corpus_id` (`TEM-SDEI-nn`) porque `Concepts/Framework-Concept/` ya declara `TEM-01` a `TEM-08` y el registro de IDs es único para el repositorio.

### Criterios de aceptación

| # | Criterio | Cumple | Evidencia |
| --- | --- | --- | --- |
| 1 | Seis encabezados del Profile, idénticos (VER-T01..T07) | Sí | Chequeo `05-encabezados-y-enlaces.sh`: los tres en orden y con el mismo nombre; un encabezado renombrado da rojo |
| 2 | Enlace al anterior y al siguiente (VER-G08) | Sí, con salvedad | TEM-01 ← Mapa, TEM-02 ↔ TEM-01/03, TEM-03 → «Tema 04, en redacción» con enlace a la guía de un solo archivo: TEM-04 todavía no existe (E1-U4c) |
| 3 | APA con fecha de consulta y ancla `ref-…` | Sí | PR-7 `reflint`: 47 referencias, 0 errores; 0 citas sin ancla |
| 4 | `docs-guard` verde | Sí | Ensayo de cierre abajo |
| 6 | ≥ 3 fuentes primarias con fecha y ≥ 1 ensayo reproducible por tema; ≥ 2 adopciones ≤ 24 meses por práctica en TEM-01 y TEM-03 | Sí | Fuentes citadas: 14, 6 y 11. Ensayos 01 a 04 en `evidencia/E1-U4b/`. Adopciones: P1–P6 con 2 o 3 repositorios cada una, todas entre 2026-01-26 y 2026-10-27 |

### Ensayo de cierre

`scripts/ci-local.sh todo` sobre `a70b24a`:

- PR-1: lychee 403 enlaces, 355 OK y 0 errores; fuera del repo, 0.
- PR-2: 35 archivos con frontmatter, 0 errores.
- PR-3: AI-1, AI-2, AI-3 y AI-5 en 0; AI-4 con 26 avisos, sólo en el anexo de referencias.
- PR-4: mermaid con 21 bloques y 0 inválidos.
- PR-5: 90 trazas y 81 resueltas; los 9 avisos son los heredados de la PoC de ayuda por rol.
- PR-6: 1 contrato. PR-7: `reflint` con 47 referencias.
- La autoprueba está en verde y el agregador también.

Defectos plantados, uno por vez y revertidos, todos en rojo:

- una cita a `ref-fowler-2031` (PR-1);
- una traza a `TEM-SDEI-09` (PR-5);
- un encabezado renombrado (chequeo 05).

**P-LECT por tema.** El lector fue una sesión nueva, sin herramientas, que recibió sólo el texto del tema. Se hicieron tres rondas.

| Tema | Ronda 1 (total/altas) | Ronda 2 | Ronda 3 |
| --- | --- | --- | --- |
| TEM-SDEI-01 | 32/2 | 24/1 | 23/1 |
| TEM-SDEI-02 | 25/5 | 31/2 | 31/3 |
| TEM-SDEI-03 | 23/4 | 29/1 | 27/2 |

Después de cada ronda se corrigieron todas las dudas altas. El umbral de cero dudas rige para G-e en E1-G.

### Para las unidades paralelas (E1-U4c, E1-U4d)

- Los seis encabezados van como H2 sin número, con estos nombres exactos: `Definición`, `Aplicación por escenario`, `Ejemplos concretos`, `Preguntas guía`, `Criterios de calidad`, `Anexo`. Antes van `Índice` y después `Fuentes y observaciones`.
- Los IDs siguen la forma `TEM-SDEI-nn`.
- Hay conflictos esperables, que se resuelven conservando las dos partes:
  - `README.md`: las filas contiguas de la tabla de contenido;
  - `Referencias.md`: el agregado al final;
  - `CHANGELOG.md`.
- Cuando exista TEM-04, conviene que su PR cambie el «siguiente» de TEM-03.

**Hallazgo (no se corrige en esta unidad).** `dg.py esquema` rechaza `traces: []` como campo faltante, y el anexo del esquema dice que la lista vacía vale. Queda señalado en TEM-03 y en el folio de la unidad.

- **Merge:** delegado. Se fusiona si la guarda pasa y no hay reserva.
- **Delegación:** `CHANGELOG.md` § «Delegación del merge» (folio 130 §2 del expediente 0002), con fecha 2026-10-27; la decidió el PO.
- **Testimonio del PO (L2, literal):** «esto surgió porque despues de un avance surgia preguntas y confirmaciones tontas … Mi objetivo es que se enriquesca de tal forma el conocimiento analitico que los subagentes con este conocimiento puedan orquestar de forma automatica todo el proceso de desarrollo».

🤖 Generated with [Claude Code](https://claude.com/claude-code)
`````

### Lab-Documentos #23 — E1-U4d

| Campo | Valor |
| --- | --- |
| URL | https://github.com/hdcm-dev/Lab-Documentos/pull/23 |
| Título | Cuerpo SDEI: TEM-07 Integración con un marco SDD y proceso «Cómo intervenir» (E1-U4d) |
| Estado | `closed`, `merged=true` |
| Rama | `exp0002/e1-u4d-tem07-y-proceso` → `main` |
| Head SHA | `f6975288127751810224311a15e8fd94446efc7d` |
| `merge_commit_sha` | `2fdf859ce3c8131ba6226951b7981e7d046468d0` |
| `merged_at` | 2026-10-27T21:43:03Z |
| `merged_by` | `{cuenta-del-PO}` (redactado: cuenta personal del PO) |
| Largo de la descripción | 3290 caracteres |

Descripción íntegra:

`````markdown
## Qué trae

Unidad **E1-U4d** del expediente 0002 de DocAsCode (fuente: N09 §6 y §10; decisión D16). Base: `main` en `6832a75`, que ya contiene E1-U4a (#20), E1-U3 (#19), E1-U4e (#21) y E1-U4b (#22). La rama se rebasó dos veces, sobre #21 y sobre #22: en CHANGELOG se conservan todas las entradas, y en Referencias, la sección 7 de U4b más la 8 nueva de este PR.

- `TEM-07-Marco-SDD.md` (`TEM-SDEI-07`, **borrador hasta el escalón 2**): integración del sistema documentador con un marco SDD. Trae los seis encabezados del tema, la frontera «se cita / se agrega / decide una persona» por clase de pieza y un ensayo reproducible de `traces-resolve` contra el SDD de Lab-Geometria en `5f07b12`.
- `Examples/Como-Intervenir.md` (`GP-SDEI-INTERVENIR`, CR-5): la plantilla del proceso en cinco pasos (ubicar, derivar, validar, proponer, mantener). Cada paso tiene bloques `entradas` / `salidas` / `validaciones`, y el paso «validar» corre `scripts/ci-local.sh`.
- `Examples/Como-Intervenir-Lab-Documentos.md` (`GP-SDEI-INTERVENIR-LD`): la instancia de una página para este repositorio, con las guías prácticas de los ejemplos. Traza a `IDX-SDEI@2.0`, así que da rojo si el cuerpo cambia de versión.
- Referencias nuevas: GitHub (2026), Spec Kit v1.2.4; Kiro (s. f.); Nygard (2011). Además, filas en el README y el Mapa y una entrada en el CHANGELOG.

## Criterios de aceptación

1. Los seis encabezados del Profile (VER-T01 a VER-T07): **sí**. Están alineados con la forma que dejó en `main` E1-U4b (#22): H1 «Tema 07 — …» y H2 sin número.
2. Enlaces anterior y siguiente (VER-G08): **sí**. El anterior, Tema 06, todavía no está fusionado. Por eso se nombra sin enlace, con enlace a su fila del README, en la misma forma que usan los temas 01 a 03. Lo convierte en enlace quien fusione después.
3. APA con fecha de consulta y ancla `ref-…`: **sí**. `reflint` da 34 referencias y 0 errores.
4. `docs-guard` en verde: **sí**, en local. La CI corre en este PR.
5. La plantilla tiene bloques entradas/salidas/validaciones y su paso «validar» nombra `scripts/ci-local.sh` (VER-A05): **sí**.
6. Al menos 3 fuentes primarias con fecha y al menos 1 ensayo reproducible: **sí**. Se citan Böckeler (2025), Thoughtworks (2025), GitHub (2026), Kiro (s. f.), Nygard (2011) y Tan et al. (2024), más las reglas de IA.SDD por permalink. El ensayo se volvió a correr desde el guion publicado sobre un clon nuevo, con los mismos 4 resultados.

## Aviso para las unidades hermanas

El H1 de un tema **no** empieza con el ID (`# TEM-07 — …`). `dg.py` cuenta como declaración todo encabezado que empieza con un ID, y `TEM-01` a `TEM-08` ya están declarados en `Concepts/Framework-Concept`, que traza a ellos. Un H1 así los vuelve ambiguos.

## Merge

- **Merge:** delegado. Se fusiona si la guarda G1–G4 pasa y no hay reserva.
- **Delegación:** asentada en `CHANGELOG.md` («Delegación del merge», Conformacion-Pull-Request-Automatico 2.0). El PO la ratificó por escrito el 2026-10-27: «esto surgió porque despues de un avance surgia preguntas y confirmaciones tontas … Mi objetivo es que se enriquesca de tal forma el conocimiento analitico que los subagentes con este conocimiento puedan orquestar de forma automatica todo el proceso de desarrollo».

🤖 Generated with [Claude Code](https://claude.com/claude-code)
`````

### Lab-Documentos #24 — E1-U4c

| Campo | Valor |
| --- | --- |
| URL | https://github.com/hdcm-dev/Lab-Documentos/pull/24 |
| Título | E1-U4c: temas 04 a 06 del cuerpo SDEI |
| Estado | `closed`, `merged=true` |
| Rama | `exp0002/e1-u4c-temas-04-06` → `main` |
| Head SHA | `fc6351e23a3b4b4aae8b912f7093654cf3601755` |
| `merge_commit_sha` | `ecb63420d2204ab6073136275713cb6be008e99e` |
| `merged_at` | 2026-10-27T21:57:32Z |
| `merged_by` | `{cuenta-del-PO}` (redactado: cuenta personal del PO) |
| Largo de la descripción | 4588 caracteres |

Descripción íntegra:

`````markdown
## E1-U4c — Temas 04 a 06 del cuerpo `SDEI`

Unidad E1-U4c del plan de implementación del expediente 0002 de DocAsCode (N10 §6, onda 5, grupo P-C). Depende de E1-U4a, ya fusionada (PR #20, e57aae2). La rama está rebasada sobre `origin/main` 2fdf859, que ya incluye E1-U4e (#21), E1-U4b (#22) y E1-U4d (#23).

### Qué agrega

En `Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/`:

| Archivo | `doc_id` | Contenido | Ensayo reproducible |
| --- | --- | --- | --- |
| `TEM-04-Doble-Audiencia.md` | `TEM-SDEI-04` | Una fuente para personas y agentes. Canales por escenario y contexto, `AGENTS.md` como puntero y anti-inyección AI-1 a AI-5 | Índice generado del frontmatter dos veces, con `diff` vacío; AI-1 y AI-2 plantados dan rojo |
| `TEM-05-Ayuda-Al-Usuario-Final.md` | `TEM-SDEI-05` | Ayuda escrita a partir de la especificación, traza con versión, divergencia declarada (60/80) y rol resuelto en el servidor | `traces-resolve` sobre la página de la mini demo: versión desfasada e ID inexistente dan rojo |
| `TEM-06-Compuertas-Y-CI.md` | `TEM-SDEI-06` | Los dos carriles, la regla de bloqueo de cinco condiciones, los pares rojo/verde, la seguridad del runner y una plantilla para dar de alta un control | `ci-local.sh todo` en verde; un ancla plantada da rojo en PR-1 |

Además:

- `README.md` del cuerpo: las filas de TEM-04 a TEM-06 enlazan a sus archivos.
- `99-Anexos/Referencias.md`: nueva entrada `ref-gitlab-testing-sf`.
- `00-Marco.md` §6, `PE-01` y `EJR-SDEI-04`: el caso 60/80 es el nombre de una localidad (`RN-LOC-01`), como dice la ficha verificada contra el código, y no un comentario. Lo detectó la P-LECT.
- `TEM-03` y `TEM-07`: sus pies enlazan a TEM-04 y TEM-06 (antes decían «en redacción»).
- `CHANGELOG.md`: entrada de la unidad. Se conservan las entradas de E1-U4e, E1-U4b y E1-U4d.

### Criterios de aceptación

| # | Criterio | Cumple | Evidencia |
| --- | --- | --- | --- |
| 1 | Seis encabezados del Profile, idénticos (VER-T01..T07) | Sí, en los siete temas. TEM-04 a 06 se alinearon con TEM-01 a 03 y TEM-07, que ya estaban en main con los títulos sin número | `## Definición` … `## Anexo` en TEM-01 a TEM-07 |
| 2 | Enlace anterior/siguiente (VER-G08) | Sí. La cadena TEM-03 → 04 → 05 → 06 → 07 queda enlazada en los dos sentidos | Pie de cada tema |
| 3 | APA con fecha y ancla `ref-…` | Sí. Toda cita enlaza a su ancla del anexo, y `reflint` da 32 referencias con 0 errores | PR-7 |
| 4 | `docs-guard` verde | Sí en local. En el runner, ver la corrida de este PR | `scripts/ci-local.sh todo`: verde en 8 de 8 grupos |
| 6 | ≥ 3 fuentes primarias con fecha y ≥ 1 ensayo reproducible por tema | Sí. Fuentes con fecha: TEM-04 tiene 7, TEM-05 tiene 3 (más un libro, que no lleva fecha) y TEM-06 tiene 4. Cada tema trae un ensayo con sus comandos y su salida registrada | `evidencia/E1-U4c/02` a `04` del expediente |

El criterio 5 (plantilla «Cómo intervenir») es de E1-U4d.

### Ensayo de cierre

```text
== agregador docs-guard            (cabeza fc6351e)
  enlaces      verde   (lychee: 542 enlaces, 489 OK, 0 errores, 53 excluidos)
  esquema      verde
  ai           verde   (AI-1, AI-2, AI-3 y AI-5 en 0; los AI-4, todos en el anexo de referencias)
  estructura   verde
  trazas       verde   (121 trazas, 112 resueltas, 9 avisos heredados de la PoC de ayuda por rol)
  contrato     verde
  fijadas      verde
  autoprueba   verde
== docs-guard: verde
```

**P-LECT.** El lector fue una sesión efímera sin herramientas. Recibió el tema, el Marco y el Glosario. Se hicieron tres rondas por tema:

| Tema | Altas, ronda 1 | Ronda 2 | Ronda 3 |
| --- | --- | --- | --- |
| TEM-04 | 2 | 1 | 0 |
| TEM-05 | 0 | 0 | 1 |
| TEM-06 | 1 | 1 | 1 |

Todas las altas se corrigieron, también las de la ronda 3, que no tuvo una ronda más. Quedan dudas medias. El umbral de cero dudas rige en la P-LECT de E1-G.

### Delegación y testimonio del PO

- **Delegación del merge:** `CHANGELOG.md` de este repositorio, entrada «compuerta de documentación y delegación del merge» (Conformacion-Pull-Request-Automatico 2.0). Techo de 120 min, intervalo de 30 s.
- **Testimonio del PO (2026-10-27, L2):** «esto surgió porque despues de un avance surgia preguntas y confirmaciones tontas … Mi objetivo es que se enriquesca de tal forma el conocimiento analitico que los subagentes con este conocimiento puedan orquestar de forma automatica todo el proceso de desarrollo».
- **Clase P, sin reserva.** Los temas quedan en `status: borrador`. Pasarlos a `vigente` es un acto H, en un PR aparte.

🤖 Generated with [Claude Code](https://claude.com/claude-code)
`````

### Lab-Documentos #25 — E1-U4f

| Campo | Valor |
| --- | --- |
| URL | https://github.com/hdcm-dev/Lab-Documentos/pull/25 |
| Título | E1-U4f: la guía de un solo archivo pasa a obsoleta y url-fecha ampliado (E-F7) |
| Estado | `closed`, `merged=true` |
| Rama | `exp0002/e1-u4f-guia-obsoleta` → `main` |
| Head SHA | `6839258adee7a202b2c160b605db9cfc01ee7c65` |
| `merge_commit_sha` | `fe10086f2b083f6cfe227da49174d204c1b0e008` |
| `merged_at` | 2026-10-27T22:26:15Z |
| `merged_by` | `{cuenta-del-PO}` (redactado: cuenta personal del PO) |
| Largo de la descripción | 3290 caracteres |

Descripción íntegra:

`````markdown
## E1-U4f — La guía de un solo archivo pasa a `obsoleto`; `url-fecha` ampliado (E-F7)

Expediente 0002 de DocAsCode, plan N10 §14, onda 6. Rama basada en `main` `ecb6342`, que ya trae las dependencias fusionadas: E1-U3 (#19), E1-U4b (#22), E1-U4d (#23) y E1-U4c (#24).

### Qué cambia

- **`Sistema-Documentador-Tecnico-Guide.md`** (`DOC-SDT-0001`): `status: obsoleto`, aviso con su reemplazo (el README del cuerpo, `IDX-SDEI`) y **tabla de destinos** «sección vieja → `doc_id` nuevo» para las **47 secciones** (H2 y H3), con ancla de destino y cobertura: 38 completas y 9 parciales, y en cada parcial dice qué no se trasladó. El texto original no cambia. El archivo se archiva recién en la versión siguiente del cuerpo.
- **`dg.py url-fecha`** (grupo PR-7, en el paso `fijadas`): cada URL y cada **cita por dominio dentro de un code span** (`` `docusaurus.io/docs/…` ``, que el aviso heredado no veía) tiene que llevar en su párrafo o fila la fecha de consulta o una cita enlazada al anexo (`#ref-…`). Bloquea en el cuerpo nuevo, salvo en documentos `obsoleto`, y avisa en lo heredado. No marca direcciones locales, dominios de ejemplo, plantillas con «…», direcciones de clonado `.git` ni imágenes de contenedor con etiqueta.
- Fixtures `url-fecha/rojo` (4 citas incompletas), `verde` y `obsoleto` en la autoprueba.
- Se actualizaron el README del cuerpo y el Mapa (la ruta «aprender» ya no pasa por la guía vieja), la tabla de grupos y el anexo de TEM-06, `CQ-11`, `tools/docs-guard/README.md` y el CHANGELOG. La cita de TEM-07 a las reglas del marco SDD ahora lleva fecha de consulta: la URL fijada a un SHA se verificó hoy con respuesta 200.

### Criterios de aceptación

1. **Cada sección de GUIA tiene destino:** sí. Son 47 secciones y 47 filas; ninguna queda sin destino y no hay `doc_id` inexistentes. Las anclas las valida PR-1 (lychee `--include-fragments`).
2. **Sobre el cuerpo nuevo, 0 URL sin fecha y 0 citas por dominio sin referencia completa:** sí. `url-fecha` da 0 errores en 41 documentos que bloquean. La guía obsoleta queda con 33 avisos (5 URL y 28 citas por dominio). Si se la vuelve a `borrador`, da rojo con esos 33.
3. **`url-fecha` ampliado tiene prueba negativa:** sí. El fixture rojo da rc=1 y está en la autoprueba. Además, una cita por dominio plantada en TEM-03 da rojo, mientras que el aviso heredado no la ve.

### Supuestos

- Los documentos `obsoleto` avisan y no bloquean. D28 nombraba la guía como piloto, pero la ficha de E1-U4f mide el cuerpo nuevo: la conversión a APA se hizo en los temas que la reemplazan, no en el archivo que se retira.
- «Medido el / verificado el AAAA-MM-DD» vale como fecha para una observación propia.

### Ensayo

`scripts/ci-local.sh todo` da verde en local, con autoprueba verde y los pares rojo/verde de `url-fecha`. Falta la corrida en el runner `[self-hosted, i7infra-dev]` de esta cabeza.

**Merge:** delegado. Se fusiona si la guarda G1–G4 pasa y no hay reserva. **Delegación:** `CHANGELOG.md` §«Delegación del merge», 2026-10-27, decidida por el PO. Testimonio (L2): «Mi objetivo es que se enriquesca de tal forma el conocimiento analitico que los subagentes con este conocimiento puedan orquestar de forma automatica todo el proceso de desarrollo».

🤖 Generated with [Claude Code](https://claude.com/claude-code)
`````

### Lab-Documentos #26 — E1-G (reparaciones)

| Campo | Valor |
| --- | --- |
| URL | https://github.com/hdcm-dev/Lab-Documentos/pull/26 |
| Título | E1-G: reparaciones de cierre del escalón 1 |
| Estado | `closed`, `merged=true` |
| Rama | `exp0002/e1g-reparaciones` → `main` |
| Head SHA | `e83f373034af285a7e750cb77657f7e1fe26f566` |
| `merge_commit_sha` | `56ea2d3f754d9bb386b10e37add55477aa863079` |
| `merged_at` | 2026-10-28T03:40:31Z |
| `merged_by` | `{cuenta-del-PO}` (redactado: cuenta personal del PO) |
| Largo de la descripción | 1574 caracteres |

Descripción íntegra:

`````markdown
Compuerta E1-G del expediente 0002 de DocAsCode: reparaciones que salieron de la verificación del escalón 1.

## Qué cambia

| Archivo | Cambio | Criterio |
| --- | --- | --- |
| `.github/workflows/docs-guard.yml` | Corre también en `push` a `main` y por `workflow_dispatch` | G-b: la corrida sobre el commit de merge queda registrada |
| `.github/workflows/framework-concept-demo.yml` | `actions/checkout` fijada por SHA (v4.2.2) | Seguridad de CI: actions fijadas por SHA |
| `README.md`, `Guides/README.md` | La ruta de lectura apunta al README del cuerpo SDEI, no a la guía obsoleta; el README raíz nombra `AGENTS.md` | Hallazgo registrado en E1-U5 |
| README del cuerpo SDEI | El diagrama de rutas ya no marca los temas «en redacción» | Hallazgo registrado en E1-U5 |
| `CHANGELOG.md` | Entrada del 2026-10-28 | — |

Sin cambios de contenido de los temas ni de los controles. `push` y `workflow_dispatch` no cambian permisos: siguen `contents: read`, sin `pull_request_target`, con la guarda contra forks.

## Ensayo

`scripts/ci-local.sh todo` en local: los ocho grupos en verde (`== docs-guard: verde`, rc=0). Barrido S2 del diff: vacío.

## Delegación

Se fusiona por la guarda G1-G4 de la conformación automática, con la delegación del merge asentada por escrito por el PO (testimonio L2 del folio 130 del expediente: «Mi objetivo es que se enriquesca de tal forma el conocimiento analitico que los subagentes con este conocimiento puedan orquestar de forma automatica todo el proceso de desarrollo»).

🤖 Generated with [Claude Code](https://claude.com/claude-code)
`````

### Lab-Documentos #27 — E1-G (frontmatter)

| Campo | Valor |
| --- | --- |
| URL | https://github.com/hdcm-dev/Lab-Documentos/pull/27 |
| Título | E1-G: frontmatter que un lector YAML acepta (regla frontmatter-no-yaml) |
| Estado | `closed`, `merged=true` |
| Rama | `exp0002/e1g-frontmatter-yaml` → `main` |
| Head SHA | `9b49337b4de0bf0a1657a52ff2ea2dc6b3d5546b` |
| `merge_commit_sha` | `75043a5ebc0de3fde976a8945eccbeebc312cbba` |
| `merged_at` | 2026-10-28T11:44:11Z |
| `merged_by` | `{cuenta-del-PO}` (redactado: cuenta personal del PO) |
| Largo de la descripción | 2035 caracteres |

Descripción íntegra:

`````markdown
Compuerta E1-G del expediente 0002 de DocAsCode: segundo hallazgo reparable de la verificación.

## Hallazgo

Al renderizar el cuerpo SDEI con un generador de sitio para la demo de E1-G, el frontmatter del README del cuerpo salió como texto: su `description` tiene «: » sin comillas, y eso no es YAML válido. Un barrido con un lector YAML estricto dio 5 archivos así entre lo que agregó E1 (README del cuerpo, TEM-03, TEM-06, `AGENTS.md` y un fixture). `dg.py esquema` usa un subconjunto propio de YAML y no lo detectaba, así que VER-A01 («frontmatter YAML») no se cumplía del todo aunque PR-2 diera verde.

## Qué cambia

| Archivo | Cambio |
| --- | --- |
| `tools/docs-guard/dg.py` | Regla `frontmatter-no-yaml` en PR-2: un valor sin comillas con «: » da rojo en el cuerpo nuevo y avisa en lo heredado |
| `tools/docs-guard/fixtures/esquema-yaml/` y `scripts/ci-local.sh` | Par rojo/verde de la regla en la autoprueba (G-c) |
| README del cuerpo, TEM-03, TEM-06, `fixtures/url-fecha/obsoleto/a.md` | `description` entre comillas; la fila «Estado» del README ya no dice que faltan temas |
| `tools/docs-guard/README.md`, `CHANGELOG.md` | Documentan la regla |

**Fuera de este PR:** `AGENTS.md` tiene el mismo defecto, pero su huella está exceptuada de AI-3 (AK-3) y renovar la excepción es clase H: queda para un PR aparte que decide una persona.

## Ensayo

`scripts/ci-local.sh todo`: los ocho grupos en verde; `PR-2 esquema YAML` rojo (rc=1) y verde (rc=0) en la autoprueba. Lector YAML estricto sobre el cuerpo: 0 inválidos. Barrido S2 del diff: vacío.

## Delegación

Clase P (un control nuevo con su par rojo/verde y cambios de frontmatter). Se fusiona por la guarda G1-G4 de la conformación automática, con la delegación del merge asentada por escrito por el PO (folio 130, L2: «Mi objetivo es que se enriquesca de tal forma el conocimiento analitico que los subagentes con este conocimiento puedan orquestar de forma automatica todo el proceso de desarrollo»).

🤖 Generated with [Claude Code](https://claude.com/claude-code)
`````

### Lab-Documentos #28 — E1-G (AGENTS.md, clase H)

| Campo | Valor |
| --- | --- |
| URL | https://github.com/hdcm-dev/Lab-Documentos/pull/28 |
| Título | AGENTS.md: description entre comillas y huella AK-3 renovada (clase H) |
| Estado | `closed`, `merged=true` |
| Rama | `exp0002/e1g-agents-yaml` → `main` |
| Head SHA | `56f40c5d94a016f44785239c3d5a40f359d05a4d` |
| `merge_commit_sha` | `490646bcba9db31d55d2710ddf2e73b9f5adaa89` |
| `merged_at` | 2026-10-28T11:52:46Z |
| `merged_by` | `{cuenta-del-PO}` (redactado: cuenta personal del PO) |
| Largo de la descripción | 1339 caracteres |

Descripción íntegra:

`````markdown
**Clase H — espera la aprobación de una persona; no lo fusiona el agente.**

`AGENTS.md` tiene en su frontmatter un valor sin comillas con «: » (`description: Puerta de la ruta «agente»: …`), que no es YAML válido: un generador de sitio o un agente que lea el frontmatter con un lector estricto lo rechaza entero. Lo detectó la compuerta E1-G del expediente 0002 de DocAsCode; el resto de los archivos con el mismo defecto se corrigen en #27.

## Qué cambia

| Archivo | Cambio |
| --- | --- |
| `AGENTS.md` | Sólo la línea `description:`, ahora entre comillas. El texto es el mismo |
| `tools/docs-guard/excepciones.txt` | Huella SHA-256 de `AGENTS.md` renovada (`2449556…` → `f12ab88…`); sin ella, AI-3 vuelve a mirar el archivo |

## Por qué es clase H

Renovar una excepción con huella (AK-3) es clase H según la delegación del merge (D08): la excepción saca a `AGENTS.md` del control anti-inyección AI-3, y por eso cada cambio del archivo lo revisa una persona. Para revisarlo alcanza el diff de una línea de `AGENTS.md`.

## Ensayo

`dg.py ai` sobre `AGENTS.md` con la huella nueva: AI-1…AI-5 = 0.

## Sugerencia

Aprobar y fusionar. Si no se aprueba, `AGENTS.md` sigue funcionando para quien lo lee como Markdown; sólo falla para quien parsea su frontmatter como YAML.

🤖 Generated with [Claude Code](https://claude.com/claude-code)
`````

### Lab-Documentos.Documentacion #17 — E1-U0b

| Campo | Valor |
| --- | --- |
| URL | https://github.com/hdcm-dev/Lab-Documentos.Documentacion/pull/17 |
| Título | exp0002 E1-U0b: delegación del merge y llamador de docs-guard |
| Estado | `closed`, `merged=true` |
| Rama | `exp0002/e1-u0b-delegacion-y-verificar` → `main` |
| Head SHA | `0cf7e8ab3d1c263ca629ae500f774509c04adb6d` |
| `merge_commit_sha` | `34bdd44895d199c62e0bddd85b29ea8a0d4f4a78` |
| `merged_at` | 2026-10-27T13:56:12Z |
| `merged_by` | `{cuenta-del-PO}` (redactado: cuenta personal del PO) |
| Largo de la descripción | 1292 caracteres |

Descripción íntegra:

`````markdown
Expediente 0002 (DocAsCode), unidad **E1-U0b**: arranque de Lab-Documentos.Documentacion.

- `CHANGELOG.md`: sección «Delegación del merge» (fecha 2026-10-27, responsable PO, techo 120 min, intervalo 30 s).
- `.github/workflows/verificar.yml`: job `docs-guard` que llama a `hdcm-dev/Lab-Documentos/.github/workflows/docs-guard.yml@f603984a3a4b35ea62feb7e5b3f68c0ad3331311` (E1-U0a, fusionada en hdcm-dev/Lab-Documentos#11) con `herramientas-ref` igual; el job `verificar` pasa a `[self-hosted, i7infra-dev]`, checkout fijado por SHA y guarda contra forks. `permissions: contents: read`, sin `pull_request_target`.
- `.github/README.md`: documentación de la CI (carpeta verificada por docs-guard).

Criterio E-F12: el registro del job llamado debe mostrar el runner `i7infra-dev`.

**Testimonio del PO (folio 130 §2, L2), que delega también el primer merge de este repo:** «esto surgió porque despues de un avance surgia preguntas y confirmaciones tontas … Mi objetivo es que se enriquesca de tal forma el conocimiento analitico que los subagentes con este conocimiento puedan orquestar de forma automatica todo el proceso de desarrollo».

Conformación: Knowledge-Conformacion-Pull-Request-Automatico (G1–G4, merge atado al SHA).

🤖 Generated with [Claude Code](https://claude.com/claude-code)
`````

### Lab-Documentos.Documentacion #20 — E1-U0c

| Campo | Valor |
| --- | --- |
| URL | https://github.com/hdcm-dev/Lab-Documentos.Documentacion/pull/20 |
| Título | E1-U0c: expediente 0002 y bitácoras del replanteo DocAsCode |
| Estado | `closed`, `merged=true` |
| Rama | `exp0002/e1-u0c-expediente-y-bitacoras` → `main` |
| Head SHA | `cc2bfd6f3a8c3f9d3b6749808db3d1eb7c7a26fe` |
| `merge_commit_sha` | `60d94f3c3aea84205f0a0ae3e50d6b8211aacae4` |
| `merged_at` | 2026-10-27T15:01:17Z |
| `merged_by` | `{cuenta-del-PO}` (redactado: cuenta personal del PO) |
| Largo de la descripción | 1827 caracteres |

Descripción íntegra:

`````markdown
## E1-U0c: versionar el expediente 0002 y las bitácoras

Unidad E1-U0c del plan de implementación (bitácora N10, §14, onda 3). Agrega `PROMPTs/DEVs/Enchacement/01-Replanteo-Y-Analisis/OUTPUTs/` completo: el expediente 0002 (actuaciones y evidencia) y las bitácoras I, N, R y C. No toca nada de `PROMPTs/` fuera de `OUTPUTs/`.

- **Base:** `origin/main` en `34bdd44` (E1-U0b ya fusionada, PR #17).
- **Rutas:** las del equipo pasan a rutas desde la raíz del workspace. Los datos que no se publican (base de conocimientos privada, repo privado de runners, organización y runner del SDD-B, carpeta de intermedios, memoria del agente, cuenta del PO) se nombran con alias. La tabla de alias está en el README del expediente.
- **`evidencia/local/`:** queda fuera del índice. `git ls-files <EXP>/evidencia/local | wc -l` da `0`.

### Criterios de aceptación

1. **Barrido S2 vacío** sobre todo lo agregado: ruta del host, usuario, servicio privado, su organización, repos privados e IP privadas. La evidencia está en `evidencia/E1-U0c/01-barrido-s2.txt`. El patrón A da 3 coincidencias y las tres son falsos positivos (dos URL públicas y el folio 099 citando su propio patrón). El patrón B da `exit 1`, o sea, vacío.
2. **`evidencia/local/` fuera del índice:** `0`.
3. **`verificar` verde:** lo dicen las corridas de este PR.

### Merge

- **Merge:** delegado. Se fusiona si la guarda pasa y no hay reserva (clase P, sólo documentación, `CPA`).
- **Delegación:** la sección «Delegación del merge» de `CHANGELOG.md` (E1-U0b), fechada el 2026-10-27, la decidió el PO. Su testimonio (L2): «Mi objetivo es que se enriquesca de tal forma el conocimiento analitico que los subagentes con este conocimiento puedan orquestar de forma automatica todo el proceso de desarrollo».

🤖 Generated with [Claude Code](https://claude.com/claude-code)
`````

### Lab-Documentos.Documentacion #22 — E1-U5

| Campo | Valor |
| --- | --- |
| URL | https://github.com/hdcm-dev/Lab-Documentos.Documentacion/pull/22 |
| Título | ia-db v4.1: reindexado de Lab-Documentos hasta fe10086 (exp. 0002, E1-U5) |
| Estado | `closed`, `merged=true` |
| Rama | `exp0002/e1-u5-reindexado-ia-db` → `main` |
| Head SHA | `8ef1fb0374e05eca717b3d27ce1e595c074869da` |
| `merge_commit_sha` | `e0e520f2d5ca323d46cf202aacfba8e06349e283` |
| `merged_at` | 2026-10-27T22:48:39Z |
| `merged_by` | `{cuenta-del-PO}` (redactado: cuenta personal del PO) |
| Largo de la descripción | 2698 caracteres |

Descripción íntegra:

`````markdown
## Qué hace

Reindexado incremental de la `ia-db` de este repositorio. La base es `Lab-Documentos` al SHA del merge de E1-U4f: `fe10086f2b083f6cfe227da49174d204c1b0e008`, PR hdcm-dev/Lab-Documentos#25. Es la unidad **E1-U5** del expediente 0002 de DocAsCode (N10 §6 y §14, onda 7).

- **Base del índice.** Se partió de la v4.0, la regeneración del 2026-10-18, que no estaba publicada; queda publicada en este PR. La versión resultante es la **v4.1**.
- **Índices nuevos.**
  - `11_Sistema-Documentador-SDEI.md`: cuerpo `SDEI` (29 `doc_id`), mini demo MovilidadUrbana, `docs-guard` y sus workflows, `AGENTS.md` y procedencia en el expediente 0002.
  - `12_Framework-Concept.md`.
- **Índices actualizados.**
  - 00: cifras re-medidas, §2.1 fuera de `Guides/`, linaje E, §7.1 con lo que cambió en la v4.1, hallazgos que dejan de valer.
  - 01: el apunte `DOC-SDT-0001` figura como obsoleto.
  - 08: workflows propios del repo.
  - 10: frontmatter re-contado, contrato SDEI, prefijos, `GUIA-INDICE` ×4.
  - `README.md`: navegación, resumen, estructura y manifiesto con `base_commit`.
- **Redacción S2 (repo público).** Se redactaron una cuenta personal y tres IP privadas que se citaban del corpus.
- **`llms.txt`.** El índice no lo enlaza porque en E1 no hay sitio publicado.

## Criterios de aceptación (ficha E1-U5)

| Criterio | Resultado |
| --- | --- |
| Todo documento nuevo del cuerpo tiene entrada | Sí. Los 55 `.md` agregados o modificados entre `5d5c2b4` y `fe10086` tienen entrada (55/55), y los 29 `doc_id` del cuerpo también |
| `base_commit` = merge de U4f | Sí: `fe10086…` en el manifiesto del README |
| Enlaza a `llms.txt` sólo si hay sitio | No lo enlaza, porque no hay sitio en E1; la sección «Restricciones» lo dice |

**Ensayo de cierre.** Cobertura 55/55. En la ia-db se comprobaron 185 enlaces con sus anclas, con 0 rotos. Se comprobaron 228 rutas citadas contra `git ls-tree fe10086`; las 9 que no existen son intencionales. Ningún índice pasa de 500 líneas, no hay líneas largas duplicadas entre archivos y el barrido S2 dio vacío.

## Dependencias

E1-U4f (hdcm-dev/Lab-Documentos#25) y E1-U0c (#20) ya están fusionadas. La rama sale de `origin/main`.

## Conformación

Merge por `CPA` (clase P, X12) con guarda G1–G4 y commit de merge atado al SHA.

La delegación está asentada en `CHANGELOG.md` (folio 130 §2). Testimonio literal del PO (L2): «esto surgió porque despues de un avance surgia preguntas y confirmaciones tontas … Mi objetivo es que se enriquesca de tal forma el conocimiento analitico que los subagentes con este conocimiento puedan orquestar de forma automatica todo el proceso de desarrollo».

🤖 Generated with [Claude Code](https://claude.com/claude-code)
`````

### Lab-E2E.WebBlazor #12 — E1-U6

| Campo | Valor |
| --- | --- |
| URL | https://github.com/hdcm-dev/Lab-E2E.WebBlazor/pull/12 |
| Título | Propuesta de expediente: documentar desde el código (H-L07, D19, D25) |
| Estado | `closed`, `merged=true` |
| Rama | `exp0002/e1-u6-propuesta-expediente` → `main` |
| Head SHA | `83542abe06cc95577b163818e72efaf6f2dde9ad` |
| `merge_commit_sha` | `59399ba6678c56c3219988a5f9666fc4e0047160` |
| `merged_at` | 2026-10-27T12:59:18Z |
| `merged_by` | `{cuenta-del-PO}` (redactado: cuenta personal del PO) |
| Largo de la descripción | 994 caracteres |

Descripción íntegra:

`````markdown
Carta de propuesta de expediente (expediente 0002 de la metodología DocAsCode, unidad E1-U6, fila L7: sí). Insumo: defecto H-L07. Cambios propuestos: D19 y D25 (máximo de 60, OpenAPI en build, X-Sesion-Id declarado y probado, ID de regla en XML doc).

- No toca código: el diff sólo agrega docs/propuestas/0001-Propuesta-Expediente-Documentacion-Desde-El-Codigo.md.
- Basada en origin/main (sin dependencias).
- **Merge:** delegado — se fusiona si la guarda G1–G4 pasa y no hay reserva.
- **Delegación:** docs/propuestas/0001-…md §8, 2026-10-27, responsable del producto. Primer merge del repositorio por conformación automática, pedido explícitamente. Testimonio: «esto surgió porque despues de un avance surgia preguntas y confirmaciones tontas … Mi objetivo es que se enriquesca de tal forma el conocimiento analitico que los subagentes con este conocimiento puedan orquestar de forma automatica todo el proceso de desarrollo».

🤖 Generated with [Claude Code](https://claude.com/claude-code)
`````
