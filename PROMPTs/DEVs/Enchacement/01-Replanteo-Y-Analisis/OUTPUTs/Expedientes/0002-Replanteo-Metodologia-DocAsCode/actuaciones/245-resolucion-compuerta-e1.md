---
doc_id: EXP0002-F245
doc_type: resolucion
title: Resolución de la compuerta E1-G — paquete G-a a G-g con veredicto por criterio tras refutación, corte y pase
status: vigente
origin: agent
confidence: alta en las medidas, que se repitieron con su refutación; media en la lectura del corte, porque 133 §5 no dice qué produce un NO_CUMPLE sin P0 y esa parte es criterio propio
owner: presidencia de la mesa de Replanteo y análisis DocAsCode (compuerta E1-G)
last_review: 2026-10-28
audience: [PO, presidencia, mesa de E1-G, agentes que reparen E1, bitacorista]
traces: [EXP0002-F012, EXP0002-F130, EXP0002-F131, EXP0002-F132, EXP0002-F133, EXP0002-F240, N09, N10, R07]
---

# 245 — Resolución de la compuerta E1-G

| Campo | Valor |
| --- | --- |
| Tipo | resolucion |
| Fecha | 2026-10-28 |
| Autor | Presidencia de la mesa (compuerta E1-G). Consolida y no vota. Pluma delegada en un agente redactor; la presidencia revisa |
| Corrige | — |

Leído: `N09` §9.1–§9.2; `N10` §6 (E1-G, E2-U0), §10, §14; `012` §6; `131` §2 (L6); `132` §3; `133` completo; `R07`
§5; `240`. Evidencia de esta compuerta: `evidencia/E1-G/` (`G-a-fechas.txt`, `G-b-corridas.md`, `G-c-negativas.md`,
`G-d-traces.txt`, `G-e-lectura-dudas.md`, `G-f-barrido-s2.txt`, `G-g-lista-ver.md`, `antecedentes-prs.md`,
`criterios-por-unidad.md`, `S2-folios.txt`).

## Índice

1. [Definiciones](#1-definiciones)
2. [Objeto y base medida](#2-objeto-y-base-medida)
3. [Cómo se compuso la mesa](#3-cómo-se-compuso-la-mesa)
4. [Paquete G-a…G-g](#4-paquete-g-ag-g)
5. [Detalle por criterio](#5-detalle-por-criterio)
6. [Cambios de entorno](#6-cambios-de-entorno)
7. [Corte](#7-corte)
8. [Lo no verificado](#8-lo-no-verificado)
9. [Qué decide la presidencia o el PO](#9-qué-decide-la-presidencia-o-el-po)
10. [Pase](#10-pase)
11. [Anexo A — Propuesta al dueño del Profile (L6)](#11-anexo-a--propuesta-al-dueño-del-profile-l6)

## 1. Definiciones

- **Verificador**: agente que mide un criterio con el instrumento de `133` §2 y emite un veredicto.
- **Refutador**: agente distinto que repite la medida, busca lo que el verificador no vio y dice si el veredicto se
  sostiene; si no se sostiene, da un veredicto corregido.
- **Veredicto final**: el del verificador si el refutador lo sostiene; el corregido si no. Este folio sólo usa el final.
- **Valores**: CUMPLE, NO_CUMPLE, INSUFICIENTE (falta una medida o el instrumento no puede producirla); `P0` marca
  un defecto que por sí solo da `NO_PROCEDE` (`133` §5).

## 2. Objeto y base medida

El objeto es el escalón 1 sobre los SHA de merge de E1-U0a a E1-U5 (`N10` §6, E1-G), con E1-U6 cuando el criterio lo
pide (`133` §3 lo lista). Base:

| Repo | SHA medido | Punta de `main` al cerrar | Efecto |
| --- | --- | --- | --- |
| Lab-Documentos | `490646bcba9db31d55d2710ddf2e73b9f5adaa89` (merge del #28) | `227954a` (#29, fusionado 11:56:57Z, ajeno a E1) | #29 toca sólo `CHANGELOG.md` y `Concepts/Framework-Concept/99-Anexos.md` (API compare: ahead 2); no altera G-c, G-d, G-e ni G-g |
| Lab-Documentos.Documentacion | `e0e520f` (worktree) y `f51c065` (`origin/main`, #23) | `f51c065` | G-f midió el subconjunto del expediente en `e0e520f`; su refutador midió el repo entero en `f51c065` |
| Lab-E2E.WebBlazor | `59399ba` (merge de E1-U6); fuente de la mini demo en `8fb4c3a` | `59399ba` | — |

## 3. Cómo se compuso la mesa

`132` §3 y `N10` §6 (E1-G, opción B) piden para esta compuerta: **núcleo + `C-ARQ-NET`, `C-ANALISTA`, `C-ACADEMICO` +
`C-DEVOPS`, `C-CONFIG-RELEASE`**.

Lo que corrió de verdad en esta vuelta, sin adornarlo:

- La presidencia despachó **un verificador y un refutador por criterio** (siete pares de veredicto y refutación), cada uno con
  la medida de un solo criterio. No se les asignó silla de especialista de `132` §3 ni se los convocó con esos roles.
- **No hubo votación ni jurado.** Los veredictos de §4 son medidas refutadas, no votos. Este folio no inventa votos ni
  atribuye posiciones a especialistas que no se sentaron.
- La mesa de la opción B, por lo tanto, **no se constituyó**. Su dictamen sobre este paquete queda pendiente para la
  vuelta (§10). `C-DECISIONES`, obligatorio sin silla en E1-G, recibe este folio como lector (`132` §4).

## 4. Paquete G-a…G-g

| # | Umbral (`N09` §9.2; `133` §2) | Verificador | Refutador | **Final** | P0 | Medida (resumen) |
| --- | --- | --- | --- | --- | --- | --- |
| G-a | Fecha del folio de criterios anterior a la primera rama; cada criterio con instrumento | INSUFICIENTE | sostiene | **INSUFICIENTE** | no | 132/133 fechados el mismo día, sin hora; versionados en `cc2bfd6` 2 h 16 min después del primer commit de E1 |
| G-b | Corrida verde de `docs-guard`/`verificar` sobre el SHA de cada merge, con URL y SHA | NO_CUMPLE | sostiene | **NO_CUMPLE** | no | 4 de 16 merges con corrida verde del workflow pedido; 10 sin ninguna corrida |
| G-c | 100 % de las compuertas bloqueantes en rojo con su defecto plantado | CUMPLE | **no sostiene** | **INSUFICIENTE** | no | 20/20 pares de `docs-guard`; quedan sin par controles bloqueantes de otros workflows |
| G-d | 100 % de las `traces` del escalón resuelven | CUMPLE | **no sostiene** | **NO_CUMPLE** | no | 117 de 119 traces agregadas por E1 resuelven (98,3 %); E1 rompió 23 que antes resolvían |
| G-e | P-LECT: cero dudas sin respuesta | NO_CUMPLE | sostiene | **NO_CUMPLE** | no | 21 de 34 dudas sin respuesta |
| G-f | Barrido S2 vacío sobre todo lo versionado en repos públicos | NO_CUMPLE | sostiene (objeta el P0) | **NO_CUMPLE** | **a decidir** (§9) | 8 líneas con defecto en el subconjunto; el repo entero muestra fugas más graves |
| G-g | 100 % de los VER-* obligatorios | NO_CUMPLE | sostiene | **NO_CUMPLE** | no | 43 de 51 obligatorios (84,3 %); evidencia de ensayos perdida |

Resultado: **ninguna de las siete cumple.** Dos INSUFICIENTE y cinco NO_CUMPLE.

## 5. Detalle por criterio

### G-a — Folio de criterios previo

- **Final: INSUFICIENTE** (sostenido). No P0: nada indica que los criterios se escribieran después de las ramas, y
  `133` no cita PR, SHA ni folios 21x posteriores.
- **Medida, primera parte (fecha).** `132` y `133` dicen 2026-10-27 en `last_review` y en la tabla (`:9`, `:19`), sin
  hora. Se versionaron una sola vez en `cc2bfd6` (2026-10-27T14:57:10Z, Lab-Documentos.Documentacion #20, merge
  `60d94f3`); `git diff cc2bfd6..HEAD` vacío. La primera rama de E1 es **Lab-E2E.WebBlazor #12** (E1-U6): commit
  `83542ab` a las 12:41:00Z; CreateEvent de la rama a las 12:41:11Z (sello de GitHub). Lab-Documentos #11 llega 79 s
  después. Los eventos de los tres repos muestran que antes de las 12:41:11Z no se creó ninguna rama `exp0002`.
- **Única cota de tercero**: el cuerpo de Lab-Documentos #11, sin ediciones (GraphQL `userContentEdits` 0), dice
  «Dependencia: PRE-03 (folio 133), hecha» a las 12:42:47Z. Pesa poco: es autodeclaración, y el mismo commit
  `8c3fc99` cita el folio `130` como asiento existente cuando `130` recién se versionó en `cc2bfd6`. El cuerpo de
  E2E #12, la rama realmente primera, dice «Basada en origin/main (sin dependencias)».
- **Medida, segunda parte (instrumento por criterio)**, agregada por el refutador: `133` §2 tiene 7/7 filas con
  instrumento y §3 12/12 unidades con instrumento. Huecos parciales: §4 (umbrales P-5) no tiene instrumento; en E1-U2,
  el tag `docs-guard-v1.0.0` no queda cubierto por «Actions; API de issues»; en E1-U4a, «anexos enlazados desde el
  Mapa» no queda cubierto por «validador de frontmatter».
- **Por qué INSUFICIENTE y no NO_CUMPLE.** Una lectura literal daría NO_CUMPLE: el instrumento corrió y dio contrario
  al umbral. Prevalece INSUFICIENTE porque la granularidad de día no ordena hechos del mismo día. Pero **no falta una
  medida: el instrumento es estructuralmente inadecuado**. `N10` §14 pone el versionado de 132/133 (E1-U0c) en la
  onda 3, después de la onda 1; por diseño, `git log` nunca podía mostrar los folios antes de la primera rama.
  **Repetir la medida dará siempre lo mismo**: «vuelve una vez» es estéril para G-a sin una decisión (§9).
- Evidencia: `G-a-fechas.txt` (§6, refutación); https://github.com/hdcm-dev/Lab-E2E.WebBlazor/pull/12;
  https://github.com/hdcm-dev/Lab-Documentos/pull/11; https://github.com/hdcm-dev/Lab-Documentos.Documentacion/pull/20
  (`cc2bfd6f3a8c3f9d3b6749808db3d1eb7c7a26fe`); `210-e1-u0a.md:71`; `N10-Plan-De-Implementacion.md:505`, `:519`.
- Correcciones a la evidencia escrita que señaló el refutador, sin efecto en el veredicto, **ya hechas** en
  `G-a-fechas.txt`: §3 suma las ramas de par rojo/verde (Lab-Documentos #12, `12d8999`, 12:42:30Z; .Documentacion
  #18, `99eedde`, 13:24:38Z); §4 decía que ningún registro local tenía entradas del 2026-10-27, y hay dos de otro
  proyecto (20:43–20:45Z) sin relación con el expediente: ahora dice «ninguna transcripción local del expediente
  0002». La refutación (eventos, cita de `130` en `8c3fc99`, instrumento por criterio) está en su §6.

### G-b — Corrida real en el runner

- **Final: NO_CUMPLE** (sostenido). No P0.
- **Medida.** 16 merges (13 de E1-U0a…E1-U5 y #26, #27, #28), todos de dos padres. Con corrida verde del workflow
  pedido sobre el SHA del merge, 4:

  | Merge | Workflow | Evento | Run | Runner |
  | --- | --- | --- | --- | --- |
  | E1-U5 `e0e520f` | Verificar | workflow_dispatch | [40598387395](https://github.com/hdcm-dev/Lab-Documentos.Documentacion/actions/runs/40598387395) | i7infra-runner-dev |
  | #26 `56ea2d3` | docs-guard | push | [40628034346](https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40628034346) | i7infra-runner-dev |
  | #27 `75043a5` | docs-guard | push | [40682252298](https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40682252298) | hpdev-runner-dev |
  | #28 `490646b` | docs-guard | push | [40683351337](https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40683351337) | hpdev-runner-dev |

  Con corrida verde de **otro** workflow: E1-U2 `c0766dc` (docs-enlaces-semanal, 40556547619) y E1-U3 `080f158`
  (mini-demo-movilidad, 40578471106). **Sin ninguna corrida**: E1-U0a `f603984`, U0b `34bdd44`, U0c `60d94f3`, U1
  `ad71e47`, U4a `e57aae2`, U4b `6832a75`, U4c `ecb6342`, U4d `2fdf859`, U4e `4fa998e`, U4f `fe10086`. Todos tienen
  corrida verde de PR.
- **Atenuante, acotado por el refutador.** En Lab-Documentos el árbol de cada merge es igual al de la cabeza de su PR
  (13/13), y las corridas de PR verificaron `refs/pull/N/merge` (el merge sintético), porque `docs-guard.yml` hace
  checkout sin `ref`. En .Documentacion vale poco: U0b no es igual (el merge suma 6 archivos, 225 líneas, de PR del
  expediente 0001), y el `docs-guard` de Verificar sólo revisa `ruta: .github`. La corrida de E1-U5 que cuenta como
  cumple llama a `docs-guard@f603984` (suite mínima, 3 pasos): al pie de la letra es Verificar, pero no equivale a
  PR-1…PR-7.
- **Causa: defecto del plan, no de la ejecución.** `N10` §6 pidió para `docs-guard.yml` sólo `pull_request` y
  `workflow_call` (`N10:163`) y para `verificar.yml` sólo `pull_request` (`N10:176`). Con eso G-b no podía cumplirse
  hasta `9d00e42` (#26).
- **Denominador.** `N10` §6 dice «de E1-U0a a E1-U5» (16 con los de la compuerta). Si se aplica `133` §3, que lista
  E1-U6, son 17 y U6 tampoco cumple (Lab-E2E.WebBlazor no tiene `docs-guard` ni Verificar; sobre `59399ba` sólo hay la
  corrida programada E2E 40665257981). El resultado es el mismo.
- Evidencia: `G-b-corridas.md` (§6, refutación).

### G-c — Prueba negativa

- **Final: INSUFICIENTE.** El verificador dio CUMPLE; **el refutador no lo sostuvo** y prevalece su corrección.
- **Lo medido, confirmado.** 20 casos bloqueantes de `docs-guard` (PR-1 lychee, ancla, fuera, `AGENTS.md`; PR-2
  esquema, YAML, prefijo, RRD; PR-3 AI-1, AI-2, AI-4, AI-5; PR-4 markdownlint, mermaid; PR-5; PR-6; PR-7 fijadas,
  reflint, url-fecha; autoprueba AK-7) plantados en la rama `exp0002/e1g-negativa-hpdev`, sin PR y luego borrada (404):
  **20/20 rojas y 20/20 verdes**, cada roja con un solo grupo fallido, el esperado; las 20 reversiones dejan el árbol de
  `490646b` (tree `3d266af`). Primer par: rojo
  [40684924940](https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40684924940) / verde
  [40686315722](https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40686315722); último: rojo 40690653886 / verde
  [40690768991](https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40690768991). Tabla completa en
  `G-c-negativas.md`.
- **Por qué no se sostuvo el CUMPLE.** El verificador acotó el criterio a «compuertas de `docs-guard`»; `N09` §9.2 y
  `133` §2 dicen «cada control bloqueante» del escalón. Quedan sin par en el sentido de `133` §1:
  1. `mini-demo-movilidad.yml` C1 (contrato) y C3 (trazas y anclas contra el SHA), marcados «Bloquea» en su
     encabezado; ni el defecto real `RN-LOC-01` (60/80) que `N09` §9.1 nombra como prueba negativa de E1 tiene un par
     con URL de las dos corridas en el runner.
  2. El job `verificar` de `verificar.yml` en .Documentacion (clave privada, binarios `.apk/.aab/.keystore/.jks/.p12`,
     archivo > 5 MiB, todos con `exit 1`); el par de E1-U0b (`211-e1-u0b`, fila 3) sólo plantó un enlace roto.
  3. El paso `herramientas` de `docs-guard.yml` (`sha256sum -c` del tarball de lychee), sin `continue-on-error`.
  4. Granularidad no declarada: hay reglas que bloquean sin plantar (PR-5 `traza-mal-formada`, `traza-ambigua`,
     `traza-sin-version`, `traza-version-desfasada`, `dg.py:640-665`; PR-6 `contrato-sin-extraccion`, `dg.py:722`; PR-2
     `ayuda.schema.json` y `readme-cuerpo.schema.json`).
  Además: PR-7 «fijadas» no vigila ninguna pieza real (no hay `BASE-FIJADA.md` en la ruta), y el «ensayo local previo»
  no tiene salida guardada.
- **Por qué INSUFICIENTE y no NO_CUMPLE**: lo que falta es medir (plantar) esos controles; lo plantado dio lo esperado.
- Evidencia: `G-c-negativas.md` (§6, refutación, con los 40 pares recontrolados por API); el árbol final idéntico a
  `490646b` y la rama borrada.

### G-d — Trazas

- **Final: NO_CUMPLE.** El verificador dio CUMPLE (107/107 en el cuerpo SDEI); **el refutador no lo sostuvo**.
- **Lo medido, confirmado.** `bash scripts/ci-local.sh trazas` en `490646b`: 121 traces, 112 resueltas, 9 avisos
  `traza-no-verificable` (CU-000nn de la prueba de concepto E0, sin `source.lock`, no tocadas por E1). Mini demo contra
  `8fb4c3a`: 17/17 traces y 10/10 anclas; deriva contra `59399ba`: 10/10.
- **Por qué no se sostuvo.** El instrumento recorre sólo la ruta por defecto del cuerpo SDEI. E1 agregó 12 traces fuera
  de ella (`AGENTS.md` 6, `README.md` 3, `Guides/README.md` 3, en E1-U1 `3167f7d` y E1-U4e `c483d80`), y
  `dg.py trazas AGENTS.md README.md Guides/README.md` da **ROJO**: `traza-ambigua: GUIA-INDICE: declarado 4 veces` en
  `README.md:1` y `Guides/README.md:1`. Total de E1 en el repo: **117 de 119 (98,3 %)**. Y hay regresión: E1-U4c
  (`fc6351e`) declaró TEM-04, TEM-05 y TEM-06, que ya estaban en `Concepts/Framework-Concept`; esa carpeta pasa de 83/89
  (sobre el árbol de `507afd6`) a 60/89 (sobre `490646b`), con 23 `traza-ambigua` nuevas.
- Ninguna lectura razonable llega al 100 %: «el cuerpo SDEI» da 112/121 (92,6 %); «toda trace que agregó E1» da
  117/119. Las traces del expediente en .Documentacion no se miden (Verificar corre con `ruta: .github`).
- Evidencia: `G-d-traces.txt` (§5, refutación, con los comandos y la salida sobre `490646b` y `507afd6`).

### G-e — P-LECT

- **Final: NO_CUMPLE** (sostenido). No P0, pero `133` §2 exige cero: impide el PROCEDE hasta reparar y repetir.
- **Medida.** 34 dudas del lector contra `490646b`: 13 respondidas, **21 sin respuesta** (D-03 a D-08, D-10, D-11,
  D-15 a D-21, D-24 a D-28, D-30). Ejemplos verificados por el refutador: D-17 (`Esquema-Frontmatter-Y-Prefijos.md:54`
  admite `traces: []`; `TEM-03:322` dice que la compuerta lo rechaza), D-19 (AK-2 y AK-6 no existen en ningún archivo),
  D-20 (`Glosario.md:28` dice «cuatro familias» y la tabla tiene seis), D-21 (`TEM-06:198` cita líneas equivocadas de
  `docs-guard.yml`), D-11 (`evidencia/E1-U4b/` no publicada).
- **Lo que el refutador agrega.** El conteo es más benévolo que el protocolo de `012` §6, que distingue «respondida»,
  «con respuesta no alcanzada» y «hueco»: D-01, D-02, D-12, D-14, D-22, D-23 y D-32 serían «no alcanzada». Falta el
  tramo de PR simulado con CI verde que `012` §6 pide para E1, y el acta no identifica al lector.
- D-17 y D-18 tocan el contrato de `docs-guard`: si se corrige `dg.py` es clase H.
- Evidencia: `G-e-lectura-dudas.md` §6 y §7 (refutación).

### G-f — Barrido S2

- **Final: NO_CUMPLE** (sostenido). **P0: a decidir por la presidencia** (§9); el verificador propuso «no P0» y el
  refutador mostró que su fundamento no se sostiene fuera del subconjunto medido.
- **Medida del verificador** (patrón de 20 líneas, `-i`; `git ls-files -z | xargs -0 grep -nIiE -f`): Lab-Documentos
  `490646b`, 97 líneas en 32 archivos (el archivo decía 33; corregido); .Documentacion, subconjunto del
  expediente 0002 y las bitácoras en `e0e520f`, 15 líneas en 10 archivos. Defectos:
  - D1: el nombre de la organización privada del SDD-B en `Guides/Despliegue/DevOps-Guide/publish-nuget.md:26,42,62`
    (anterior a E1).
  - D2: una ruta que nombra la carpeta local de INFRA-privada en
    `Guides/Despliegue/GitHub-Action-Guide/GitHub-Action-Guide.md:2949` y en su gemela
    `Guides/Testing/Lab-E2E.WebBlazor-Guides/GitHub-Action-Guide.md:2953` (anterior a E1; coincide por accidente).
  - D3: la ruta del anfitrión de `{dir-de-trabajo}` en `Bitacoras/R07-Reglas-PromptFramework.md:304`,
    `actuaciones/014-informe-c-arq-net.md:93` y `actuaciones/090-reconsideracion.md:213`, **entrada por E1-U0c**: el
    patrón de E1-U0c no cubría esa raíz.
- **Lo que el refutador agrega.** `133` §2 dice «todo lo versionado en repos públicos». El repo .Documentacion entero da
  210 líneas en 95 archivos, y Lab-E2E.WebBlazor (público, recibió E1-U6) 11 líneas en 2 archivos (todas el
  directorio personal del usuario genérico `dev` del contenedor: candidato a falso positivo). Fuera del
  subconjunto, en el expediente 0001 de Framework-Concept: **la IP del tailnet del equipo del PO junto con la serie del
  teléfono** (`actuaciones/041-constancia-g42-liberado-y-limpieza.md:17`, `a4d26c8`, 2026-10-27), que la carta 003 de
  ese mismo expediente redacta con una IP de documentación; el correo personal del PO en un archivo de las bitácoras de
  editores; seis rutas con el directorio personal del usuario del equipo; un prompt `{usuario-del-host}@{máquina}` en
  una práctica de GitHub Flow; el nombre de la organización del SDD-B en `Bitacoras/00-Registro.md:36` de
  Framework-Concept; 23 archivos bajo `PROMPTs/Concepts/01-Framework-Concept/` con la raíz de máquinas del anfitrión
  (medido por la crítica del paquete, `G-f-barrido-s2.txt` §7); 12 archivos
  versionados bajo `evidencia/local/` (uno con las interfaces de red del anfitrión), contra la convención. En
  Lab-E2E.WebBlazor, con el patrón ampliado, 5 líneas con identificadores de la app privada en `.devcontainer/`
  (anteriores a E1). El patrón omitió identificadores que el propio repo trata como privados (control R-PRIV).
- **Cambio de entorno corregido**: `xargs grep` ejecuta GNU grep 3.8, no ugrep (ver §6).
- Este folio **no transcribe** los valores filtrados: los cita por archivo y línea.
- Evidencia: `G-f-barrido-s2.txt` (§7, refutación, con conteos por clase y sin valores).

### G-g — Lista VER-*

- **Final: NO_CUMPLE** (sostenido). No P0.
- **Medida.** De los 111 ítems de `R07` §5 aplican 73 y 51 son obligatorios (criterio de obligatoriedad propio del
  verificador, `G-g-lista-ver.md` §1: ni `R07` ni `133` lo definen). Cumplen **43 de 51 (84,3 %)**; no cumplen E02,
  E03, E07, G08 (parcial), M02, D01, A06 y F05. `docs-guard` completo sobre `git archive 490646b`: rc=0. P-5: fuentes
  y adopciones cumplen; la mini demo cumple (10 piezas, 1 workflow, jobs de 35 a 117 s, medidos en `080f158` y
  `56f40c5`, con `git diff 56f40c5 490646b` vacío sobre la demo y su workflow); **«≥ 1 ensayo reproducible en
  `evidencia/`» no cumple en ningún tema**.
- **Defecto principal (D1 del folio de evidencia)**: TEM-01:213,217,246, TEM-02:214,217 y TEM-03:193,213,221 remiten a
  `evidencia/E1-U4b/…` en .Documentacion, que no existe en `main`, en ninguna rama, en ningún PR ni en la historia.
  Explica E02, E03, D01, A06 y F05. `docs-guard` no lo ve porque son code spans.
- **Lo que el refutador agrega.** El NO_CUMPLE no depende del criterio propio: aun con sólo los VER que cita `133` §3,
  G08 falla (el tutorial de la mini demo no enlaza al anterior ni al siguiente). Son 5 marcas `[Compilado: …]` que
  citan `E1-U4b` (para 4 guiones), más 3 menciones en prosa.
  G08 se evaluó con indulgencia («Volver al Mapa» no es anterior/siguiente; Ejercicios y
  `Como-Intervenir-Lab-Documentos.md` tampoco enlazan). VER-A02 depende de G-d.
- Evidencia: `G-g-lista-ver.md` (§8, refutación); PR #22 (merge `6832a75`) y #24 (merge `ecb6342`) declaran los ensayos en
  `evidencia/E1-U4b/` y `evidencia/E1-U4c/`.

## 6. Cambios de entorno

Ninguno de estos es una falla del escalón:

| Cambio | Dónde se ve | Lectura |
| --- | --- | --- |
| Runner `hpdev-runner-dev` en lugar de `i7infra-runner-dev`, con las mismas etiquetas pedidas | E-F12 en los registros de G-b, G-c y G-g | Cambio de entorno (`240` §3) |
| Medidas desde hpdev, Python 3.11.2 | G-a…G-g | — |
| `grep` del shell del agente = función que llama a ugrep 7.8.4; `xargs grep` = GNU grep 3.8 | G-f | El barrido corrió con GNU grep; `G-f-barrido-s2.txt` decía lo contrario y ya se corrigió |
| G-d corrió `dg.py` en local, no en el runner | G-d | El instrumento de `133` es el script; la corrida en el runner es tema de G-b |
| `main` de los dos repos avanzó durante la medición (`227954a`, `f51c065`) | G-c, G-f, G-g | Sin efecto sobre las medidas (§2) |
| Evidencia de E1-U4b/E1-U4c perdida con i7infra | G-g, G-e, criterios por unidad | Es pérdida, no cambio de entorno: cuenta como incumplimiento |

## 7. Corte

`133` §5 y `N09` §9.2: **PROCEDE** si las siete cumplen; **NO_PROCEDE** ante un P0; **INSUFICIENTE** si falta una
medida (vuelve una vez).

- **No PROCEDE**: ninguna de las siete cumple.
- Ningún veredicto final trae P0 declarado. G-f queda con la severidad abierta (§9, punto 1).
- La regla no dice qué produce un NO_CUMPLE sin P0 (G-b, G-d, G-e, G-g). **[criterio propio]** de la presidencia: un
  NO_CUMPLE sin P0 es un defecto reparable dentro del escalón y sigue el camino de INSUFICIENTE (reparar y volver),
  porque `NO_PROCEDE` se reserva para lo que la regla nombra.

**Corte: INSUFICIENTE — E1 vuelve una vez**, con las reparaciones de §10. **Reserva**: si la presidencia califica de
P0 la exposición de la IP del tailnet del equipo del PO y la serie del teléfono en un repo público (G-f), el corte pasa
a **NO_PROCEDE**.

Advertencias sobre la vuelta: G-a no se resuelve volviendo a medir (§5, G-a), y la regla no dice qué pasa si la vuelta
única tampoco da las siete. Las dos cosas son decisiones (§9).

## 8. Lo no verificado

- **E-F4** («agregado y cuerpo partido por núcleo para agentes»), que `N10` §10 cierra en E1-G: no se midió en esta
  vuelta. INSUFICIENTE.
- **Lecciones de E1 a `DocsAsCode-Bitacoras/`** (`N10` §14, onda 8): no se emitieron.
- **D08**: FIRME por `130` §4; no se reexaminó.
- Las etiquetas registradas del runner de hpdev (403 en la API de la organización).
- E-F10, E-F13, E-F14 y el conteo de fuentes primarias de E1-U4b/c/d: sólo con lo que dicen los PR (`240` §6).
- El dictamen de la mesa de la opción B (§3).

## 9. Qué decide la presidencia o el PO

1. **Severidad de G-f.** ¿Es P0 la IP del tailnet del equipo del PO con la serie del teléfono en
   `041-constancia-g42-liberado-y-limpieza.md:17` del expediente 0001 de Framework-Concept? Si lo es, el corte es
   NO_PROCEDE. Corregir el archivo es reversible y lo hace la presidencia; **reescribir la historia de git** para
   sacarlo de `a4d26c8` es irreversible y con consecuencia externa: sale al PO (`131` §1, criterio K-EXT, y §4).
2. **G-a**: aceptar el testimonio de #11 como prueba, o corregir la norma (onda 0 versionada y fusionada antes de la
   onda 1, u hora ISO 8601 con zona en los folios de criterios). Repetir `git log` no sirve.
3. **G-b**: aceptar la equivalencia por árbol para los 10 merges sin corrida (no aplica a E1-U0b), o crear referencias
   en `34bdd44` y `60d94f3` para despachar Verificar. En Lab-Documentos no se puede despachar `docs-guard` sobre esos
   SHA sin cambiar el workflow que corre en ellos. Asentar el defecto del plan (`N10:163`, `:176`).
4. **Regla de corte**: qué produce NO_CUMPLE sin P0 (este folio aplicó un criterio propio, §7) y qué pasa si la vuelta
   única falla.
5. **G-c**: granularidad de «control bloqueante» (fila del README §5 de `docs-guard` o regla de `dg.py`) y si entran
   los workflows `mini-demo-movilidad` y `verificar`.
6. **G-d**: alcance de «traces del escalón» (cuerpo SDEI, toda trace agregada por E1, o también las del expediente en
   .Documentacion) y cómo se resuelve la colisión TEM-04/05/06 con `Concepts/Framework-Concept`.
7. **G-g**: fijar qué VER-* son obligatorios para que el porcentaje sea comparable; reescribir y versionar los guiones
   de E1-U4b/E1-U4c, o pasarlos al texto de cada tema y corregir las remisiones.
8. **Mesa**: constituir la mesa de la opción B (`132` §3) para el dictamen de la vuelta, o asentar por qué no.

## 10. Pase

E1 **no** pasa a E2-U0. Vuelve una vez, con estas reparaciones, en ramas `exp0002/e1g-…` por CPA (las de `dg.py`, una
excepción o un workflow, clase H):

| Criterio | Reparación | Repo |
| --- | --- | --- |
| G-a | La decisión §9.2, asentada por folio; completar en `133` (por corrigenda) los instrumentos de §4 P-5, del tag de E1-U2 y de los anexos de E1-U4a | .Documentacion |
| G-b | La decisión §9.3 y, si corresponde, los despachos de Verificar; anotar el defecto del plan en `N10` por corrigenda | .Documentacion |
| G-c | Pares rojo/verde en el runner para C1 y C3 de `mini-demo-movilidad` (incluido `RN-LOC-01`), para el job `verificar` (clave privada, binario, tamaño) y para el paso `herramientas`; granularidad declarada; salida del ensayo local guardada | Lab-Documentos, .Documentacion |
| G-d | Resolver `GUIA-INDICE` duplicado (`README.md`, `Guides/README.md`); resolver la colisión de TEM-04/05/06 con Framework-Concept; volver a correr `dg.py trazas` sobre toda trace agregada por E1 | Lab-Documentos |
| G-e | Corregir las 21 dudas sin respuesta y las «no alcanzadas»; repetir el P-LECT con las clases de `012` §6, el PR simulado con CI verde y la identidad del lector | Lab-Documentos |
| G-f | Redactar D1, D2 y D3; redactar los hallazgos del repo entero y de Lab-E2E.WebBlazor (o pedir que lo decida su dueño, si el repo no es de este expediente); sacar del índice los `evidencia/local/` versionados; ampliar el patrón S2 canónico de `099`/`R07`; barrer los tres repos enteros sobre la punta de `main` | los tres |
| G-g | Guiones de ensayo de los temas en `evidencia/` o dentro del tema; anterior/siguiente del tutorial, de Ejercicios y de `Como-Intervenir-Lab-Documentos.md`; índice de este último; contar bien las marcas | Lab-Documentos, .Documentacion |
| Pendientes de §8 | Medir E-F4; emitir las lecciones de E1; emitir el anexo L6 (§11) | .Documentacion |
| Evidencia | Versionar `evidencia/E1-G/` con este folio (PR de la presidencia) | .Documentacion |

Cuando la vuelta dé PROCEDE, sigue **E2-U0** (`N10` §7): folio de criterios del escalón 2 con fecha anterior a la
primera rama de E2, la condición de D24 y los observables de D23 · presidencia.

## 11. Anexo A — Propuesta al dueño del Profile (L6)

`133` §5 y `131` §2 (L6, opción (b)) piden que este folio lleve como anexo una propuesta escrita al dueño del Profile:
`OBJ-nn`, `EJR-nn`, ruta real del framework, contrato de frontmatter y verificación por lector sin contexto, «con la
evidencia de E1» (`131:54`).

**Estado: PENDIENTE.** No hay texto de esa propuesta en ningún folio, PR ni archivo publicado: si se redactó en
i7infra, se perdió. Este folio no la inventa.

Lo que sí existe, y la propuesta deberá citar: el default de L6 aplicado en E1-U4a — objetivos `OBJ-SDEI-01` a `05`
en la ruta del README del cuerpo (`Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/README.md:59-63`
en `490646b`) y ejercicios `EJR-SDEI-01` a `05` con claves en `99-Anexos/Ejercicios.md` —, con el Profile intacto.

**Evento que la destraba**: la presidencia la redacta en la vuelta de E1-G, con la evidencia de G-e repetido (lector
sin contexto) y de G-d (contrato de frontmatter y trazas), y la agrega como anexo del folio de resolución de esa
vuelta. Su ausencia, sola, no es un P0; sin ella el folio de E1-G no está completo según `133` §5.
