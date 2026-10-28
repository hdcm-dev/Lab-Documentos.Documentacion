---
doc_id: EXP0002-F240
doc_type: constancia
title: Constancia de la caída de i7infra durante la verificación de E1-G y reconciliación del escalón 1 con lo que quedó en GitHub
status: vigente
origin: agent
confidence: alta en lo que viene de la API de GitHub (merge SHA, fechas, corridas, comentario del PO); media en lo que sólo dicen las descripciones de los PR, porque sus folios y salidas se perdieron
owner: presidencia de la mesa de Replanteo y análisis DocAsCode (compuerta E1-G)
last_review: 2026-10-28
audience: [presidencia, mesa de E1-G, PO, bitacorista, agentes que retomen E1]
traces: [EXP0002-F130, EXP0002-F131, EXP0002-F132, EXP0002-F133, N09, N10]
---

# 240 — Constancia: caída de i7infra y reconciliación de E1

| Campo | Valor |
| --- | --- |
| Tipo | constancia |
| Fecha | 2026-10-28 |
| Autor | Presidencia de la mesa (compuerta E1-G). Pluma delegada en un agente redactor; la presidencia revisa |
| Corrige | — (no edita folios ni la carátula) |

Leído: carátula (`README.md`), `130` §2–§4, `131` §2 (L6), `132` §3, `133` completo, `210`, `211-e1-u0b`,
`211-e1-u1`, `216`; `N09` §9.2; `N10` §6 (E1-G) y §14. Insumos nuevos de esta compuerta:
[`evidencia/E1-G/antecedentes-prs.md`](../evidencia/E1-G/antecedentes-prs.md) y
[`evidencia/E1-G/criterios-por-unidad.md`](../evidencia/E1-G/criterios-por-unidad.md).

## Índice

1. [Definiciones](#1-definiciones)
2. [Hecho: caída de i7infra](#2-hecho-caída-de-i7infra)
3. [Cambio de entorno](#3-cambio-de-entorno)
4. [Folios perdidos](#4-folios-perdidos)
5. [Antecedente: los PR de E1](#5-antecedente-los-pr-de-e1)
6. [Antecedente: criterios por unidad](#6-antecedente-criterios-por-unidad)
7. [Los PR de la compuerta (#26, #27, #28)](#7-los-pr-de-la-compuerta-26-27-28)
8. [Lo que no dejó rastro](#8-lo-que-no-dejó-rastro)
9. [Pase](#9-pase)

## 1. Definiciones

- **i7infra**: la máquina principal donde corrieron E1 y el runner `i7infra-runner-dev` hasta el 2026-10-28.
- **hpdev**: la máquina de contingencia desde la que sigue el trabajo; su runner es `hpdev-runner-dev`.
- **Antecedente**: contenido que sobrevive fuera de los folios perdidos (descripción de PR, corrida de Actions, árbol
  publicado). Se incorpora como lo que es, citando su fuente; no reemplaza al folio que faltó.
- **CPA**: conformación automática del PR (D08 FIRME, `130` §4).

## 2. Hecho: caída de i7infra

i7infra dejó de responder el **2026-10-28 a las 00:50 -03** con la verificación de la compuerta E1-G en curso. Lo que
estaba sólo en su disco y no se había empujado a GitHub se da por perdido. No hay copia en hpdev: la búsqueda de los
guiones de `evidencia/E1-U4b/` y de copias previas de `133` dio vacía (`G-a-fechas.txt` §4; `G-g-lista-ver.md` §2,
I-7: `find / -xdev -name 01-tem01-inventario.sh …` sin resultado; repetida por la crítica de este paquete con
`-name E1-U4b -o -name 01-tem01-inventario.sh`, también vacía).

## 3. Cambio de entorno

| Antes | Después | Efecto en la compuerta |
| --- | --- | --- |
| Runner `i7infra-runner-dev`, etiquetas `self-hosted`, `i7infra-dev` | Runner `hpdev-runner-dev`, con las mismas etiquetas (incluida `i7infra-dev`) más `hpdev` | Los workflows siguen pidiendo `runs-on: [self-hosted, i7infra-dev]` (`docs-guard.yml:54` en `490646b`) y no se tocan |
| E-F12: el registro del job nombraba `i7infra-runner-dev` | El registro del job nombra `hpdev-runner-dev` | **Cambio de entorno, no falla.** Ejemplos: corridas 40682252298 y 40683351337 (docs-guard, push) y los 40 jobs del par rojo/verde de G-c |
| Sin registro de qué `grep` resolvía el shell del agente en i7infra | En hpdev, `grep` del shell del agente es una función que llama a ugrep 7.8.4 (`type grep`); `xargs grep` ejecuta GNU grep 3.8 (`/usr/bin/grep --version`) | Ninguno sobre las medidas; se asienta para reproducir el barrido S2 |

La etiqueta `hpdev` del runner no se pudo leer del registro: `/orgs/hdcm-dev/actions/runners` responde 403 y la lista
del repo vuelve vacía (`G-b-corridas.md`). Lo verificado son las etiquetas que el job pidió.

La corrida 40628526301 (cola del #27) cruza los dos equipos: el job `alcance` corrió en `i7infra-runner-dev` a las
03:48:13Z y `fw-ok` en `hpdev-runner-dev` a las 11:16:35Z.

## 4. Folios perdidos

Se escribieron en i7infra y **no llegaron a GitHub**:

| Unidad | Folio | Qué se sabe de él |
| --- | --- | --- |
| E1-U0c | citado como `230` en la carátula (`README.md:16`) | Sólo el número, por esa cita |
| E1-U2, E1-U3, E1-U4a, E1-U4b, E1-U4c, E1-U4d, E1-U4e, E1-U4f, E1-U5 | número desconocido | Nada fuera de su PR |
| Verificación de E1-G (medidas anteriores a la caída) | número desconocido | Lo que dejaron los PR #26 y #27 |
| Evidencia `evidencia/E1-U4b/01…04` y `evidencia/E1-U4c/02…04` | — | TEM-01 a TEM-03 citan `E1-U4b/`; el PR #24 declara `E1-U4c/`. No existe en ninguna rama (`git log --all -- '*evidencia/E1-U4*'` vacío, `criterios-por-unidad.md` §2) |

**No se reconstruyen como si existieran.** No se emite un folio `230` ni folios con fecha 2026-10-27 para esas
unidades: escribirlos hoy sería fabricar un asiento con fecha y contenido que nadie puede verificar. Su contenido se
incorpora como antecedente (§5 y §6) con la fecha de hoy y la fuente de cada dato. La cita de la carátula a `230`
queda sin destino; la corrección la hace la presidencia por corrigenda (estilo `125`), no este folio.

Los folios de esta compuerta se numeran desde `240` **[criterio propio]**: el rango `217`–`239` pudo haberse usado
en i7infra y no se reutiliza, para que una cita vieja a un folio perdido no caiga en otro distinto.

## 5. Antecedente: los PR de E1

Fuente: API REST de GitHub, `GET /repos/hdcm-dev/{repo}/pulls/{n}`, consultada el 2026-10-28. Los 17 PR dan
`merged=true` y son merges de dos padres (ninguno squash). Cada ficha, con la descripción íntegra en un bloque literal,
está en [`antecedentes-prs.md`](../evidencia/E1-G/antecedentes-prs.md) §3. Única redacción: `merged_by`, que es la
cuenta personal del PO en los 17, figura como `{cuenta-del-PO}`.

| Repo | PR | Unidad | Folio | Head | Merge commit | `merged_at` (UTC) |
| --- | --- | --- | --- | --- | --- | --- |
| Lab-E2E.WebBlazor | [#12](https://github.com/hdcm-dev/Lab-E2E.WebBlazor/pull/12) | E1-U6 | `216` | `83542ab` | `59399ba6678c56c3219988a5f9666fc4e0047160` | 2026-10-27T12:59:18Z |
| Lab-Documentos | [#11](https://github.com/hdcm-dev/Lab-Documentos/pull/11) | E1-U0a | `210` | `87c3b65` | `f603984a3a4b35ea62feb7e5b3f68c0ad3331311` | 2026-10-27T13:21:33Z |
| Lab-Documentos.Documentacion | [#17](https://github.com/hdcm-dev/Lab-Documentos.Documentacion/pull/17) | E1-U0b | `211-e1-u0b` | `0cf7e8a` | `34bdd44895d199c62e0bddd85b29ea8a0d4f4a78` | 2026-10-27T13:56:12Z |
| Lab-Documentos | [#15](https://github.com/hdcm-dev/Lab-Documentos/pull/15) | E1-U1 | `211-e1-u1` | `fa33bc0` | `ad71e4745fc85b1a5889cc707ddb8f3006ac6ec2` | 2026-10-27T14:26:50Z |
| Lab-Documentos.Documentacion | [#20](https://github.com/hdcm-dev/Lab-Documentos.Documentacion/pull/20) | E1-U0c | perdido (`230`) | `cc2bfd6` | `60d94f3c3aea84205f0a0ae3e50d6b8211aacae4` | 2026-10-27T15:01:17Z |
| Lab-Documentos | [#16](https://github.com/hdcm-dev/Lab-Documentos/pull/16) | E1-U2 | perdido | `f9ebd8a` | `c0766dc03fa0fcd3793a5e1185867845465ca3ed` | 2026-10-27T18:04:28Z |
| Lab-Documentos | [#20](https://github.com/hdcm-dev/Lab-Documentos/pull/20) | E1-U4a | perdido | `db7c8ce` | `e57aae24e579187aebf078b647718b4041582a7a` | 2026-10-27T19:34:59Z |
| Lab-Documentos | [#19](https://github.com/hdcm-dev/Lab-Documentos/pull/19) | E1-U3 | perdido | `c8b3183` | `080f158b64d71928f8a4446971b20af5d1aa0e93` | 2026-10-27T20:28:49Z |
| Lab-Documentos | [#21](https://github.com/hdcm-dev/Lab-Documentos/pull/21) | E1-U4e | perdido | `c483d80` | `4fa998e613932dd5b767b9c220764fb351c6553d` | 2026-10-27T20:53:44Z |
| Lab-Documentos | [#22](https://github.com/hdcm-dev/Lab-Documentos/pull/22) | E1-U4b | perdido | `6dddbd7` | `6832a752ddbf7aaaaa555c200a9763588d8fc5ef` | 2026-10-27T21:27:46Z |
| Lab-Documentos | [#23](https://github.com/hdcm-dev/Lab-Documentos/pull/23) | E1-U4d | perdido | `f697528` | `2fdf859ce3c8131ba6226951b7981e7d046468d0` | 2026-10-27T21:43:03Z |
| Lab-Documentos | [#24](https://github.com/hdcm-dev/Lab-Documentos/pull/24) | E1-U4c | perdido | `fc6351e` | `ecb63420d2204ab6073136275713cb6be008e99e` | 2026-10-27T21:57:32Z |
| Lab-Documentos | [#25](https://github.com/hdcm-dev/Lab-Documentos/pull/25) | E1-U4f | perdido | `6839258` | `fe10086f2b083f6cfe227da49174d204c1b0e008` | 2026-10-27T22:26:15Z |
| Lab-Documentos.Documentacion | [#22](https://github.com/hdcm-dev/Lab-Documentos.Documentacion/pull/22) | E1-U5 | perdido | `8ef1fb0` | `e0e520f2d5ca323d46cf202aacfba8e06349e283` | 2026-10-27T22:48:39Z |
| Lab-Documentos | [#26](https://github.com/hdcm-dev/Lab-Documentos/pull/26) | E1-G (reparaciones) | este folio §7 | `e83f373` | `56ea2d3f754d9bb386b10e37add55477aa863079` | 2026-10-28T03:40:31Z |
| Lab-Documentos | [#27](https://github.com/hdcm-dev/Lab-Documentos/pull/27) | E1-G (frontmatter) | este folio §7 | `9b49337` | `75043a5ebc0de3fde976a8945eccbeebc312cbba` | 2026-10-28T11:44:11Z |
| Lab-Documentos | [#28](https://github.com/hdcm-dev/Lab-Documentos/pull/28) | E1-G (`AGENTS.md`, clase H) | este folio §7 | `56f40c5` | `490646bcba9db31d55d2710ddf2e73b9f5adaa89` | 2026-10-28T11:52:46Z |

La redacción se verificó: el barrido S2 de los 17 cuerpos dio vacío antes de transcribirlos
(`antecedentes-prs.md` §1) y se repitió sobre los archivos escritos (`evidencia/E1-G/S2-folios.txt`).

## 6. Antecedente: criterios por unidad

Fuente: [`criterios-por-unidad.md`](../evidencia/E1-G/criterios-por-unidad.md), que aplica `133` §3 a las unidades sin
folio (E1-U0c, E1-U2, E1-U3, E1-U4a…f, E1-U5) con el árbol de `490646b`, la API y lo que dicen los PR.

| Resultado | Cantidad | Detalle |
| --- | --- | --- |
| Sí | 33 de 35 | Medidos hoy, salvo los que sólo constan en el PR (fila siguiente) |
| Sí, sólo con evidencia del PR | incluidos en los 33 | E1-U2 E-F10 y E-F14; E1-U3 E-F13 (11 min 13 s); conteo de fuentes *primarias* de E1-U4b/c/d. Sin salida de comando que los respalde hoy |
| Sin evidencia | 1 | E1-U4b/c/d, P-5 «≥ 1 ensayo reproducible en `evidencia/`»: `evidencia/E1-U4b/` y `evidencia/E1-U4c/` se perdieron sin publicarse; TEM-01:213-217 apunta a un guion que no existe |
| No | 1 | E1-U3, «P-LECT sin dudas»: 4 huecos de la última ronda declarados fuera de alcance; el PR difiere el cero estricto a G-e; las actas se perdieron |

Los criterios de E1-U0a, E1-U0b, E1-U1 y E1-U6 constan en sus folios (`210`, `211-e1-u0b`, `211-e1-u1`, `216`), que
sobrevivieron porque estaban versionados.

## 7. Los PR de la compuerta (#26, #27, #28)

- **#26** (reparaciones de E1-G): `docs-guard` pasa a correr también en `push` a `main` y por `workflow_dispatch`;
  `framework-concept-demo.yml` fija `actions/checkout` por SHA; la ruta de lectura del README apunta al cuerpo SDEI.
  Merge `56ea2d3`, 2026-10-28T03:40:31Z, por CPA, todavía con i7infra en pie.
- **#27** (frontmatter que un lector YAML acepta, regla `frontmatter-no-yaml`): lo fusionó **otra sesión**, ya
  desde hpdev, el 2026-10-28 a las 11:44:11Z, por CPA. Merge `75043a5ebc0de3fde976a8945eccbeebc312cbba`, head
  `9b49337`. `docs-guard` en push sobre el merge: success, run 40682252298, en `hpdev-runner-dev`.
- **#28** (`AGENTS.md`: `description` entre comillas y huella AK-3 renovada; **clase H** porque toca una excepción de
  un control): **aprobado por el PO el 2026-10-28**. Testimonio literal: **«si aprobado, vos dale para delante»**,
  asentado en el comentario
  [6468108316](https://github.com/hdcm-dev/Lab-Documentos/pull/28#issuecomment-6468108316) del PR (creado
  2026-10-28T11:44:26Z), que dice haberlo recibido «en la sesión de Claude Code de hpdev»; el despacho de la
  presidencia para esta compuerta lo da por aprobado. Se actualizó con `main` (head
  `56f40c5`) y se fusionó por CPA: merge `490646bcba9db31d55d2710ddf2e73b9f5adaa89`, 2026-10-28T11:52:46Z.
  Check-runs de la cabeza `56f40c5` (API `commits/56f40c5/check-runs`, consultada hoy): `fw-ok` success,
  `docs-guard` success, `alcance` success, `mini-demo` success; `apk` y `compuerta` skipped. Sobre el merge:
  `docs-guard` push success, run 40683351337, terminado a las 11:53:18Z en `hpdev-runner-dev`.

El comentario 6468108316 dice «la CI corrió en verde en .»: le falta el nombre del runner. Es un defecto de forma del
comentario; los check-runs de arriba son la medida.

## 8. Lo que no dejó rastro

- **El generador de sitio usado en i7infra.** Que se usó uno consta sólo en la descripción del #27 («Al renderizar
  el cuerpo SDEI con un generador de sitio para la demo de E1-G»). En `490646b` no hay configuración de ningún generador ni workflow que
  publique un sitio (`git ls-files | grep -iE 'mkdocs|docusaurus|antora|sphinx|hugo|astro|vitepress|book\.toml'`:
  vacío; workflows: `docs-enlaces-semanal`, `docs-guard`, `framework-concept-demo`, `mini-demo-movilidad`). En
  Lab-Documentos.Documentacion sólo están las configuraciones de evaluación del ciclo 1
  (`evidencia/C-ARQ-NET/config/`), que no son el generador de E1. Qué generador se usó, con qué versión y qué
  produjo: **no se sabe** y no se reconstruye.
- **Las actas de lectura de E1-U3** (nueve rondas de P-LECT).
- **Las salidas de E-F10, E-F13 y E-F14**: sólo quedan sus números en los PR #16 y #19.
- **Las medidas de la verificación de E1-G previas a la caída**: se volvieron a tomar desde hpdev; constan en `245`.

## 9. Pase

A `245` (resolución de la compuerta E1-G), que mide G-a…G-g sobre lo que quedó en GitHub y usa este folio como
antecedente. La evidencia de `evidencia/E1-G/` está sin versionar al escribir este folio: lo que no entre por PR
corre el mismo riesgo que se llevó `evidencia/E1-U4b/` · presidencia.
