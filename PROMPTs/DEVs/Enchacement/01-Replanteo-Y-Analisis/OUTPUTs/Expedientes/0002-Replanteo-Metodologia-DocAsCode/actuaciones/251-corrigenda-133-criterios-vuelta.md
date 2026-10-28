---
doc_id: EXP0002-F251
doc_type: corrigenda
title: Corrigenda a 133 — criterios de la vuelta de E1 (precedencia con hora, instrumentos faltantes, alcance de G-b a G-g, lista VER cerrada, corte y P0, denominador)
status: vigente
origin: agent
confidence: alta en lo que transcribe del fallo del acta 250 (DEC-10 a DEC-15) y en las citas, verificadas con el comando que se indica; la lista VER cerrada aplica el criterio de DEC-15 y su asignación por tipo de pieza es criterio propio
owner: presidencia de la mesa de Replanteo y análisis DocAsCode (vuelta de E1)
last_review: 2026-10-28T13:35:47-03:00
audience: [PO, presidencia, refutador, agentes que reparen E1, mesa de la opción B, verificadores de E1-G2, bitacorista]
traces: [EXP0002-F129, EXP0002-F133, EXP0002-F240, EXP0002-F245, EXP0002-F250, EXP0002-F254, EXP0002-F256, N09, N10, R07]
---

# 251 — Corrigenda a 133: criterios de la vuelta de E1

| Campo | Valor |
| --- | --- |
| Tipo | corrigenda (sólo agregado, por referencia; estilo `125`) |
| Fecha | 2026-10-28T13:35:47-03:00 |
| Autor | Presidencia de la mesa (vuelta de E1), por la unidad U10 del acta `250`. Decisiones DEC-10, DEC-11, DEC-12, DEC-13, DEC-14 y DEC-15. Defectos DEF-01, DEF-02, DEF-07, DEF-18, DEF-55 y DEF-75 |
| Corrige | `133` §2 (filas G-a…G-g), §3 (instrumentos de E1-U2 y E1-U4a), §4 (instrumentos de P-5) y §5 (corte). `133` no se edita |
| Rige | Para la vuelta de E1 (ramas `exp0002/e1r-*`), para la re-verificación E1-G2 y, en lo que dice §2, desde E2-U0 |

## Índice

1. [Qué se corrige](#1-qué-se-corrige)
2. [G-a: precedencia con hora](#2-g-a-precedencia-con-hora)
3. [Instrumentos que faltaban](#3-instrumentos-que-faltaban)
4. [Alcance de G-b a G-g](#4-alcance-de-g-b-a-g-g)
5. [Lista VER cerrada](#5-lista-ver-cerrada)
6. [Corte y P0](#6-corte-y-p0)
7. [Denominador de G-b](#7-denominador-de-g-b)
8. [Efecto](#8-efecto)
9. [Pase](#9-pase)

## 1. Qué se corrige

| Lugar de `133` | Defecto | Medida que lo funda | Lo reemplaza |
| --- | --- | --- | --- |
| §2, fila G-a | «la fecha del folio es anterior» con fecha de día sin hora; `git log` de la rama no ordena hechos del mismo día (DEF-01) | `133:9` y `:19` dicen `2026-10-27`; `245` §5 G-a: 132/133 se versionaron en `cc2bfd6` (2026-10-27T11:57:10-03:00), después de la primera rama de E1 | §2 de este folio |
| §3, E1-U2 y E1-U4a; §4 | Sin instrumento para el tag `docs-guard-v1.0.0`, para «anexos enlazados desde el Mapa» ni para los umbrales P-5 (DEF-02) | `245:105-108` | §3 |
| §2, filas G-b…G-g | Alcance abierto: «cada control bloqueante», «las `traces` de E1», «los obligatorios» sin definir | `245` §9.3–§9.7; DEF-55: `grep -c obligatorio` en `R07` da 0 | §4 y §5 |
| §5 | No dice qué produce un NO_CUMPLE sin P0 ni qué pasa si la vuelta única falla; no define P0 (DEF-75) | `245:285-294`; `N09` §9.2 | §6 |
| §2, fila G-b | Denominador sin fijar: `N10` §6 da 16 merges y `133` §3 suma E1-U6 (DEF-07) | `G-b-corridas.md:67`; `245:149-151` | §7 |

## 2. G-a: precedencia con hora

**Para el E1 ya ejecutado.** G-a queda asentado como **defecto del plan** (DEF-01), no como P0. Por diseño, `N10` §14
ponía el versionado de 132/133 (E1-U0c) en la onda 3, después de la onda 1 (`N10:505`, `:519`; la corrigenda `252`
lo asienta en `N10`). El testimonio del cuerpo de Lab-Documentos #11 («PRE-03 (folio 133), hecha», 12:42:47Z) queda
como **antecedente, no como prueba**: es autodeclaración, y el mismo commit `8c3fc99` cita el folio `130` antes de que
exista (`245:101-104`).

**Norma desde esta corrigenda.** Todo folio de criterios de un escalón o de una vuelta:

1. Lleva `last_review` en el frontmatter y `Fecha` en la tabla con fecha y hora ISO 8601 con zona
   (`AAAA-MM-DDThh:mm:ss±hh:mm`).
2. Se fusiona en `main` **antes** del primer commit de la primera rama del escalón o de la vuelta.

**En la vuelta se cumple así.** Este folio, `252`, `253` y `254` entran por la rama `exp0002/e1g-corrigendas-vuelta`, y
su merge en `main` precede a la creación de cualquier rama `exp0002/e1r-*` (incluidas las `e1r-rojo-*` y `e1r-h-*`).

**Instrumento de E1-G2** (no la API de eventos, que caduca):

```bash
# T0: hora del merge de este folio en main de Lab-Documentos.Documentacion
T0=$(git log -1 --format=%cI <SHA del merge de 251>)
# Por cada PR cuya rama empieza con exp0002/e1r- (en los dos repos):
#   created_at del PR y fecha del primer commit del PR
curl -s "https://api.github.com/repos/hdcm-dev/<repo>/pulls?state=all&per_page=100" \
  | jq -r '.[] | select(.head.ref | startswith("exp0002/e1r-")) | [.number, .head.ref, .created_at] | @tsv'
curl -s "https://api.github.com/repos/hdcm-dev/<repo>/pulls/<N>/commits?per_page=100" \
  | jq -r '.[0].commit.committer.date'
# Ramas sin PR (e1r-rojo-*): primer commit propio de la rama, antes de borrarla (DEC-13)
git log --reverse --format=%cI origin/main..<rama> | head -1
```

Cumple si `T0` es anterior al `created_at` y al primer commit de **toda** rama `exp0002/e1r-*`. La regla rige también
desde E2-U0.

## 3. Instrumentos que faltaban

| Criterio de `133` | Instrumento | Evidencia esperada |
| --- | --- | --- |
| §4, «≥ 3 fuentes primarias con fecha por tema» | Anclas `Referencias.md#ref-…` distintas por tema, cruzadas con `Verificación: V` y «consultado el» en `99-Anexos/Referencias.md` (`G-g-lista-ver.md` §2, I-5) | Tabla tema → citadas / verificadas / con fecha |
| §4, «≥ 1 ensayo reproducible en `evidencia/` por tema» | `ls evidencia/E1-R/ensayos/TEM-0n/` y `bash guion.sh \| diff - salida.txt` vacío, por tema (§4, G-g) | Siete carpetas y siete `diff` vacíos |
| §4, «≥ 2 adopciones ≤ 24 meses por práctica» (TEM-01, TEM-03) | API pública de GitHub `commits?path=…&per_page=1&until=<fecha de la medida>` por fila de adopción (`G-g-lista-ver.md` §2, I-6) | Salida completa, con SHA y fecha |
| §4, «mini» ≤ 20 piezas / 1 workflow | `find …/MovilidadUrbana-Mini-Demo -type f \| wc -l`; `grep -l` del nombre de la demo en `.github/workflows/` | Cantidades |
| §4, «mini» < 15 min | API de Actions, jobs de `mini-demo-movilidad.yml` (`started_at`, `completed_at`) | Duración por job y URL |
| §3, E1-U2: tag `docs-guard-v1.0.0` | `git ls-remote --tags origin docs-guard-v1.0.0` en Lab-Documentos | SHA del tag, o «ausente». Crear el tag es clase H (DEC-20, folio `252` §3): si falta, es reserva nombrada (§6) |
| §3, E1-U4a: «cada anexo enlazado desde el Mapa» | Por cada archivo de `99-Anexos/`: `grep -c "<archivo>" 01-Mapa.md` ≥ 1 | Tabla anexo → cuenta |

## 4. Alcance de G-b a G-g

| Criterio | Alcance para E1-G2 | Decisión |
| --- | --- | --- |
| G-b | Cada merge del denominador (§7) tiene corrida verde del workflow pedido sobre su SHA. Se acepta la **equivalencia por árbol**: `git rev-parse <merge>^{tree}` = `<cabeza>^{tree}` y la cabeza tiene corrida verde del workflow pedido (los 8 merges de LD de DEF-03, más E1-U2 y E1-U3 de DEF-04). En LDD, Verificar se despacha sobre refs efímeras que apuntan a `34bdd44` y `60d94f3`, sin commits nuevos (las dos versiones de `verificar.yml` ya tienen `workflow_dispatch`); las refs se anclan en local antes de borrarse. Como `verificar.yml` no tiene `push` (`verificar.yml:14-16`), **cada merge de LDD de la vuelta lleva un despacho de Verificar sobre el SHA del merge** | DEC-12 |
| G-c | Un **control bloqueante** es cada regla o chequeo con identificador propio que puede terminar en exit≠0 en un workflow que E1 introdujo o modificó: las reglas de `dg.py` (incluidas las 7 sin caso: `:644`, `:657`, `:662`, `:665`, `:722` y los dos esquemas, en `main` de Lab-Documentos), C1 y C3 de `mini-demo-movilidad` (con `RN-LOC-01`), los tres chequeos del job `verificar` de LDD y el paso `herramientas` (sha256). Cada uno lleva par rojo/verde en el runner, en ramas `exp0002/e1r-rojo-*` que no se fusionan, sólo con material sintético. PR-7 «fijadas» se prueba con una pieza BASE-FIJADA sintética plantada en esa rama, sin tocar `dg.py`. Las ramas no se borran hasta que el folio `260` cite el SHA y la URL de las dos corridas, y antes se anclan en `refs/resguardo/*`. Sumar fixtures a la autoprueba de `dg.py` es clase H | DEC-13 |
| G-d | Toda trace que E1 o la vuelta agregó o modificó en Lab-Documentos (diff `5d5c2b4..main`: cuerpo SDEI, `README.md`, `Guides/README.md`, `AGENTS.md` y `Examples/`), con umbral del 100 %, y **regresión cero en lo ajeno**: `Concepts/Framework-Concept` vuelve al menos a la base 83/89 de `507afd6`. Las traces del expediente en LDD se miden en local con `dg.py` y se informan sin bloquear; llevarlas a CI es clase H (DEF-17), igual que ampliar la ruta de CI de LD (DEF-16). Quedan **fuera del escalón** y se declaran (DEF-18): los 6 errores previos de trazas de Framework-Concept y los 9 avisos `traza-no-verificable` de la prueba E0, con aviso a la línea FC | DEC-14 |
| G-f | Barrido de los tres repos enteros (Lab-Documentos, Lab-Documentos.Documentacion, Lab-E2E.WebBlazor) sobre la punta de `main`, con **las dos partes** del patrón de `254`, clasificando cada línea: real propia del escalón, falso positivo o ajena con dueño. Cumple con 0 sin clasificar y 0 reales propias. Lo ajeno (Framework-Concept, prompts del PO fuera de `OUTPUTs/`, Lab-E2E) se informa con dueño y no cuenta contra E1 (§6); en particular `{raíz-de-máquinas}` en el folio 044 de FC (DEC-08) | DEC-07, DEC-08, DEC-11 |
| G-g | 100 % de la **lista VER cerrada** de §5 sobre las piezas de cada tipo, más los umbrales P-5 de `133` §4 con los instrumentos de §3. Los ensayos perdidos de E1-U4b y E1-U4c **no se reconstruyen** en su ruta (`240` §4): se escriben guiones nuevos, al menos uno por tema (TEM-01…07, P-5), en `evidencia/E1-R/ensayos/TEM-0n/` de LDD, con guion, salida y SHA de Lab-Documentos, corridos en hpdev y rotulados «guion nuevo, ejecutado el AAAA-MM-DD; el original de E1-U4b/E1-U4c se perdió (240 §4)». Las 5 marcas `[Compilado]` y las 4 menciones en prosa que cuenta `256` §2 pasan a URL + SHA del merge | DEC-15; `256` |

## 5. Lista VER cerrada

Obligatoriedad (DEC-15): un VER-* es **obligatorio** en la vuelta si lo cita `133` §3, si es aceptación de `N10` §6, o
si está en `R07` §5.3 (evidencia y veracidad) o §5.13 (carta común), y sólo sobre los tipos de pieza que marca la tabla.
**[criterio propio]** de la presidencia: la columna de cada tipo de pieza sale de la columna «Aplica a» de `R07` §5
(G para el cuerpo y la demo; B para el expediente).

Tipos de pieza: **TEMA** = TEM-01…TEM-07 del cuerpo SDEI; **CUERPO** = README, `00-Marco.md`, `01-Mapa.md` y
`99-Anexos/`; **DEMO** = `Examples/` (mini demo, tutorial, `Como-Intervenir*.md`); **WF** = workflows que E1 introdujo
o modificó; **EXP** = folios y evidencia de la vuelta en LDD (de `251` en adelante y `evidencia/E1-R/`).

| VER | Origen de la obligatoriedad | TEMA | CUERPO | DEMO | WF | EXP | Instrumento |
| --- | --- | --- | --- | --- | --- | --- | --- |
| VER-W09 | `N10` §6, E1-U0a (4) | — | — | — | ✔ | — | `grep -n "runs-on"` en los workflows |
| VER-E01 | `R07` §5.3 | ✔ | ✔ | ✔ | — | ✔ | Re-medición independiente de lo citado (muestra declarada) |
| VER-E02 | `R07` §5.3; `N10` §6, E1-U4b/c/d (3) | ✔ | ✔ | ✔ | — | ✔ | Cada marca y cita resuelve: `ruta:línea` existe; URL con respuesta 200 y SHA de 40 caracteres |
| VER-E03 | `R07` §5.3 | ✔ | ✔ | ✔ | — | ✔ | `grep` de las etiquetas de no verificado y lectura dirigida de lo perdido |
| VER-E04 | `R07` §5.3 | ✔ | ✔ | ✔ | — | ✔ | `grep -c "\[criterio propio\]"` por pieza ≥ 1 donde hay criterio |
| VER-E05 | `R07` §5.3 | — | — | — | — | ✔ | Lectura dirigida: la conclusión cita la medida contraria si existe |
| VER-E06 | `R07` §5.3 | — | — | — | — | ✔ | Cada medida trae comando y salida |
| VER-E07 | `R07` §5.3 | ✔ | — | — | — | ✔ | `grep -c "^## .*[Oo]bservaciones"` = 1 por pieza |
| VER-E08 | `R07` §5.3 | ✔ | ✔ | — | — | — | Anclas `ref-…` por tema (§3) |
| VER-E09 | `R07` §5.3 | — | — | — | — | ✔ | Lectura dirigida |
| VER-G07 | `133` §3, E1-U4a; `N10` §6 (3) | — | ✔ (README) | — | — | — | Tabla de contenido contra `ls` del cuerpo |
| VER-G08 | `133` §3, E1-U4b/c/d; `N10` §6 (2) | ✔ | ✔ | ✔ | — | — | `grep` de anterior/siguiente al pie, incluidos tutorial, `Ejercicios.md` y `Como-Intervenir-Lab-Documentos.md` (`245` §10, G-g) |
| VER-T01…T07 | `133` §3, E1-U4b/c/d; `N10` §6 (1) | ✔ | — | — | — | — | `awk` de encabezados `## ` fuera de código (`G-g-lista-ver.md` §2, I-2) |
| VER-A01 | `N10` §6, E1-U4a (2) | ✔ | ✔ | ✔ | — | — | `dg.py esquema` (PR-2) |
| VER-A02 | `N10` §6, E1-U3 (1) | ✔ | ✔ | ✔ | — | — | `dg.py trazas` (PR-5); es la medida de G-d |
| VER-A05 | `133` §3, E1-U4b/c/d; `N10` §6 (5) | — | — | ✔ | — | — | `grep` de `entradas`/`salidas`/`validaciones` y de `scripts/ci-local.sh` |
| VER-M10 | `N10` §6, E1-U1 (1) y E1-U4e | ✔ | ✔ | ✔ | — | — | `lychee --offline --include-fragments` exit 0 |
| VER-I04 | `N10` §6, E1-U5 | — | — | — | — | si aplica | **Si aplica**, según CL-08 (`N09:249`): sólo donde el escenario activa CL-08, es decir la ia-db de LDD. En Lab-Documentos (`ESC-SDEI-1`, sin CL-08) no aplica (DEF-36) |
| VER-C01 | `R07` §5.13 | — | — | — | — | — | **No aplica**: la fase de sólo lectura terminó con el mandato de escritura de E1 (`N10` §6) |
| VER-C02 | `R07` §5.13 | ✔ | ✔ | ✔ | ✔ | ✔ | Las dos partes del patrón de `254`; es la medida de G-f |
| VER-C03 | `R07` §5.13 | ✔ | ✔ | ✔ | — | ✔ | Lectura dirigida: los repos públicos se nombran |
| VER-C04 | `R07` §5.13 | — | — | — | — | ✔ | La constancia de cierre (U44) lista `{dir-de-trabajo}` vacío o borrado |
| VER-C05 | `R07` §5.13 | — | — | — | — | — | Recomendado: es proceso y no deja marca en la pieza; se informa |

Son 27 obligatorios (W09; E01–E09; G07, G08; T01–T07; A01, A02, A05; M10; I04 si aplica; C02, C03, C04). Todo otro
VER-* de `R07` §5 se informa como **recomendado**. Para comparar con la primera vuelta, E1-G2 informa también la medida
sobre la lista de 51 de `G-g-lista-ver.md` §6, que ya no decide el criterio.

## 6. Corte y P0

Se ratifica `245` §7 y se completa `133` §5 (DEC-11):

1. **E1 ya ejecutado.** Un NO_CUMPLE sin P0 es un defecto reparable y sigue el camino de INSUFICIENTE.
2. **«Vuelve una vez»** significa exactamente una ronda E1-R y una re-verificación E1-G2.
3. **Corte de E1-G2.** PROCEDE si los siete criterios cumplen. NO_PROCEDE si hay un P0, o si queda algún NO_CUMPLE o
   INSUFICIENTE atribuible al escalón. No hay tercera vuelta: el replanteo de E1 sale al PO con una propuesta.
4. **P0** es cualquiera de estos:
   - (i) un dato personal o de infraestructura privada que el escalón introdujo y está en el HEAD público;
   - (ii) un control bloqueante que da verde con el defecto plantado;
   - (iii) un criterio cuya evidencia no se puede reproducir.
5. **Lo ajeno o pendiente del PO** (clase H, prompts del PO fuera de `OUTPUTs/`, Framework-Concept, Lab-E2E) no
   cuenta como falla del escalón. Va como **reserva nombrada**, el pase a E2-U0 espera a que se resuelva y nada se da
   por aprobado en silencio.

## 7. Denominador de G-b

Los 16 merges de E1-U0a…E1-U5 y de la compuerta (`G-b-corridas.md` §2: 13 de unidades y #26, #27, #28 de
Lab-Documentos), más **cada merge de E1-R**. E1-U6 entra en la tabla con la corrida disponible en Lab-E2E.WebBlazor
sobre `59399ba` (la programada `E2E`), **declarada** como control equivalente de ese repo. No se agregan workflows a
Lab-E2E (DEC-12).

## 8. Efecto

- `133` sigue vigente en todo lo que este folio no corrige. Ni `133` ni `245` se editan.
- Los verificadores y el refutador de E1-G2 (U41) usan los instrumentos de §2, §3 y §5 y el corte de §6.
- La cuenta de marcas de G-g es la de `256`.

## 9. Pase

A la presidencia, para fusionar este folio antes de abrir cualquier rama `exp0002/e1r-*`, y después a las unidades de
las olas 1 y 2 del acta `250` §8 y a la re-verificación E1-G2 · presidencia.
