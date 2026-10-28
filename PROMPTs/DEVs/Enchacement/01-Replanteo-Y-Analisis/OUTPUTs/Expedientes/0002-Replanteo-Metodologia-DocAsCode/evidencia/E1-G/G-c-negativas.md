# G-c — Prueba negativa: cada control bloqueante de docs-guard en rojo con su defecto plantado

- **Umbral**: N09 §9.2, fila G-c («100 % de las compuertas bloqueantes en rojo con su defecto plantado, en rama que no se fusiona»); folio 133, fila G-c («cada control bloqueante | se planta su defecto | la corrida da rojo | par rojo/verde | URL de ambas corridas») y §1 («Par rojo/verde: commit con defecto plantado en rama que no se fusiona (rojo) y su reversión (verde)»).
- **Medido**: 2026-10-28, entre 12:04Z y 12:49Z, desde hpdev (contingencia por la caída de i7infra). Corridas en el runner `hpdev-runner-dev` (etiquetas pedidas por el job: `self-hosted`, `i7infra-dev`). Que el registro del job muestre `hpdev-runner-dev` y no `i7infra-runner-dev` es cambio de entorno (E-F12), no falla.
- **Árbol medido**: `hdcm-dev/Lab-Documentos` `main` en `490646bcba9db31d55d2710ddf2e73b9f5adaa89` (merge del #28). Controles leídos de `.github/workflows/docs-guard.yml`, `scripts/ci-local.sh`, `tools/docs-guard/dg.py` y `tools/docs-guard/README.md` §4–§6 en ese SHA.
- **Rama**: `exp0002/e1g-negativa-hpdev`, desde `490646b`, en un worktree propio en `{dir-de-trabajo}`. Nunca tuvo PR (la API devolvió 0 PR para esa cabeza) y no se fusionó. Al cierre: árbol final idéntico a la base (`git diff 490646b HEAD --stat` vacío), rama remota borrada (`DELETE /git/refs/heads/…` → 204; `GET /git/ref/heads/…` → 404; `GET /branches/…` → 404, 12:49:11Z), worktree y rama local quitados.

## 1. Inventario de controles (bloquea / avisa)

Fuente: `tools/docs-guard/README.md` §5 («Qué bloquea y qué avisa») y el agregador estricto de `docs-guard.yml` (grupos `ENLACES ESQUEMA AI ESTRUCTURA TRAZAS CONTRATO FIJADAS AUTOPRUEBA`: cualquiera distinto de `success` pone el job en rojo).

| Grupo | Control | Bloquea | Fila de la tabla §3 |
| --- | --- | --- | --- |
| PR-1 | lychee `--offline --include-fragments` (archivo y ancla) | Sí | 1, 2 |
| PR-1 | `dg.py fuera` (relativo que sale del repo) | Sí | 3 |
| PR-1 | `AGENTS.md` de la raíz (CL-03) | Sí (si existe) | 4 |
| PR-2 | esquema del frontmatter; `frontmatter-no-yaml` en el cuerpo nuevo; registro de prefijos; esquema RRD | Sí | 5, 6, 7, 8 |
| PR-3 | AI-1, AI-2, AI-5; AI-4 fuera del anexo de referencias | Sí | 9, 10, 12, 11 |
| PR-3 | AI-3; AI-4 dentro del anexo | No: avisa | — (ver §4) |
| PR-4 | markdownlint estructural; mermaid que parsea | Sí | 13, 14 |
| PR-5 | traces-resolve (nivel 1) | Sí | 15 |
| PR-5 | traza a un ID externo sin `source.lock`; anclas de nivel 2 sin `--fuente` | No: avisa / no se comprueban en este job | — (ver §4) |
| PR-6 | diff del contrato OpenAPI | Sí | 16 |
| PR-7 | piezas fijadas (SHA-256); `reflint` y `url-fecha` en el cuerpo nuevo | Sí | 17, 18, 19 |
| PR-7 | `reflint` y `url-fecha` en lo heredado; `url-fecha` en `status: obsoleto`; `cita-linea` | No: avisa | — |
| — | autoprueba (pares de fixtures y AK-7) | Sí | 20 |

Son 20 casos bloqueantes sobre 8 grupos del agregador: 8/8 grupos y 20/20 casos tienen par en el runner (§3).

## 2. Evidencia previa encontrada (antes de esta medición)

| Fuente | Qué hay | Vale como par en el runner para la compuerta actual |
| --- | --- | --- |
| Folio 210 (E1-U0a), fila 3; PR #12 | Par de enlace roto: rojo run 40505939059 sobre `12d89998a20f521c6a6241c5afd2a7ed0dfd22b0`, verde run 40507350875 sobre `c5cf38ff1151ce1b7dde624f0ba7ce9509409b13`. La API lo confirma hoy (`failure` / `success`, rama `exp0002/e1-u0a-par-rojo-verde`) | Sólo PR-1, y sobre la compuerta mínima de E1-U0a (pasos «1/3 herramientas, 2/3 enlaces, 3/3 estructura»), no sobre el `docs-guard` de E1-U2 |
| PR #16 (E1-U2), criterios 1 y 4 | «Par rojo/verde por control bloqueante (G-c) — Sí: paso `autoprueba`»; «`ci-local.sh todo` con cada defecto plantado, uno por vez (18 casos)» | No: los fixtures prueban el control sobre `tools/docs-guard/fixtures/`, y los 18 casos fueron locales, sin URL de corrida |
| PR #26 (E1-G reparaciones) | `ci-local.sh todo` local en verde; no trae pares | No |
| Actions, `status=failure` en todo el repo (4 corridas) | 40505939059 (par de U0a), 40567079738 (docs-guard en la cabeza `8c75722` de E1-U3, rama luego fusionada), 40568169682 (mini-demo), 40432670449 (framework-concept-demo) | Ninguna es un par plantado de la compuerta actual |
| `evidencia/E1-U0a/02-corridas-runner.txt`, `evidencia/E1-U1/01-ensayo-de-cierre.txt` | Corridas de U0a y ensayo de U1 | Igual que la primera fila |

Conclusión: antes de hoy sólo PR-1 tenía par en el runner, y sobre una versión anterior del workflow. Por eso se plantaron los 20 casos.

## 3. Pares rojo/verde en el runner

Cada fila: un commit «NO FUSIONAR: defecto plantado <control>» sobre la cabeza anterior y, después, un commit de reversión («NO FUSIONAR: revierte el defecto plantado <control>», `git revert`). Cada commit se empujó a la rama y se despachó `docs-guard` con `workflow_dispatch` sobre ella (`POST /actions/workflows/docs-guard.yml/dispatches`, `ref` = la rama); la corrida se ubicó por `head_sha` y se esperó a `completed`. «Qué quedó rojo» copia la línea del agregador estricto y la primera línea de error del log del job (rutas relativas a la RUTA del cuerpo SDEI; las del runner se recortan).

| # | control | bloqueante | defecto plantado | corrida roja (SHA, URL) | qué quedó rojo en el log | corrida verde (SHA, URL) |
| --- | --- | --- | --- | --- | --- | --- |
| 1 | PR-1 lychee (enlace interno) | Sí | enlace a `No-Existe-Gc.md` en `99-Anexos/Glosario.md` | `a18ddf8af794e48d020423e6d715e9fd6b4e3d68` failure: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40684924940 | agregador: ENLACES=failure; `[ERROR] 99-Anexos/No-Existe-Gc.md \| Cannot find file` | `14f6649cf541ef4efdcddb7d0b9a2cd08b526ede` success: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40686315722 |
| 2 | PR-1 lychee (ancla) | Sí | enlace a `Referencias.md#ancla-que-no-existe-gc` | `fc407e81e322cd5210a98387b2f222803b052e86` failure: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40686459701 | agregador: ENLACES=failure; `[ERROR] 99-Anexos/Referencias.md#ancla-que-no-existe-gc \| Cannot find fragment` | `3c5b23cf8884c3c08847109dec16deb5106bbf5b` success: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40686596674 |
| 3 | PR-1 `fuera` (relativo fuera del repo) | Sí | enlace `../../../../../fuera-del-repo-gc.md` (también lo ve lychee) | `97763bac214a56b157c0b076e816ec702af18d14` failure: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40686734504 | agregador: ENLACES=failure; `relativo-fuera-del-repo: ../../../../../fuera-del-repo-gc.md` (dg.py fuera) y `[ERROR] ../fuera-del-repo-gc.md \| Cannot find file` (lychee) | `d6632b70c7029ca0affbaf464672e77efa33c84f` success: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40686870694 |
| 4 | PR-1 sobre `AGENTS.md` (CL-03) | Sí | enlace a `no-existe-gc.md` en `AGENTS.md` de la raíz | `0f3d4e90c5c9feff8f241eea9d2418e8502233cf` failure: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40687011481 | agregador: ENLACES=failure; `[ERROR] no-existe-gc.md \| Cannot find file` | `1b7d34ae933b4bf18ff5d36a2e15ebe1a7813528` success: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40687152000 |
| 5 | PR-2 esquema del frontmatter | Sí | `status: inventado-gc` en el Glosario | `d4c46ecba383356fee8f46d26ff3bfec4fa1cfbd` failure: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40687291276 | agregador: ESQUEMA=failure; `esquema-cuerpo: status: «inventado-gc» fuera del vocabulario ['vigente', 'borrador', 'obsoleto']` | `06e698e8dce4f4e02b647d4da8fe55be15963025` success: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40687406462 |
| 6 | PR-2 `frontmatter-no-yaml` (cuerpo nuevo) | Sí | `title:` sin comillas con «: » | `1813c32a87817dda355ba7b0a7038094e24b119c` failure: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40687526245 | agregador: ESQUEMA=failure; `frontmatter-no-yaml: valor sin comillas que contiene «: »; un lector YAML no lo acepta: entrecomillarlo` | `d8712d0a041d832d89cc3dcb3327201270169c89` success: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40687616393 |
| 7 | PR-2 registro de prefijos | Sí | página nueva con `doc_id: ZZG-SDEI-PRUEBA` | `4c76c942a0b3ed79d1658773fdc5050d9e2faa37` failure: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40687712978 | agregador: ESQUEMA=failure; `prefijo: «ZZG-» no está en el registro (prefijos.txt)` | `a2e6cd0df6d3a6df084ea5dd570a4ea9666e9e63` success: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40687807214 |
| 8 | PR-2 esquema RRD | Sí | decisión `quizas-gc` en una fila `RD-nn` de `_requisitos.md` de la mini demo | `bd52daf5b8e2aed7132244b1a9be923f8c20e6c5` failure: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40687923880 | agregador: ESQUEMA=failure; `rrd-decision: «quizas-gc» fuera de ['aceptado', 'diferido', 'pendiente', 'rechazado']` | `e547a78aa2629132b2b154a50fe3311d73ae7f23` success: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40688036203 |
| 9 | PR-3 AI-1 comentario HTML | Sí | `<!-- … -->` en un párrafo | `b92d3ead8b96e7da7a7ea86290e0315fd21954ba` failure: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40688150992 | agregador: AI=failure; `AI-1 comentario-html: <!-- comentario plantado G-c -->` | `ffa8345337c033f23e6498583d0a9e81c07c2df4` success: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40688264342 |
| 10 | PR-3 AI-2 carácter invisible | Sí | U+200B dentro de una palabra | `30d94c7ffee3d44c13ffb42cf95d784a892e9968` failure: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40688387358 | agregador: AI=failure; `AI-2 caracter-invisible: U+200B` | `3c19f3f369fd9a877c6727b87a09da35a09b276d` success: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40688507519 |
| 11 | PR-3 AI-4 dominio fuera de la lista (fuera del anexo) | Sí | URL a `dominio-no-permitido-gc.invalid` (con fecha de consulta, para no tocar `url-fecha`) | `7f23abaf9ad53bb30285c8f57ff5781f01a97aa1` failure: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40688625466 | agregador: AI=failure; `AI-4 dominio-no-permitido: dominio-no-permitido-gc.invalid` | `cb0cc99e73626c11598c94a44bd1787ec593c160` success: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40688744602 |
| 12 | PR-3 AI-5 HTML oculto | Sí | `<span style="display:none">` | `e2825b555559d6a3a29279ff90055002b775d042` failure: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40688860735 | agregador: AI=failure; `AI-5 html-oculto: <span style="display:none">` | `927c44ea55bdf1d299ef695bd09d47b76574b96b` success: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40688984761 |
| 13 | PR-4 markdownlint estructural | Sí | encabezado `####` tras un `##` (MD001) | `0ed6584c00e769caa22471c9d90e6c309e6a0921` failure: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40689103588 | agregador: ESTRUCTURA=failure; `99-Anexos/Glosario.md:78 MD001/heading-increment` | `5d6a61ba5d1d8caaf7fbd031bd5a9b1c3fa97c19` success: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40689197662 |
| 14 | PR-4 mermaid que parsea | Sí | arista incompleta en el diagrama de `TEM-02-Ciclo-Documental.md` | `bf28aad4a86989be58085d1376d8012bc9d5649f` failure: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40689314871 | agregador: ESTRUCTURA=failure; `mermaid inválido: Parse error on line 3:` | `16e35a13773a3b82dcd2ce8ec40baee0bd77744a` success: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40689405864 |
| 15 | PR-5 traces-resolve | Sí | `traces` del Glosario con `TEM-SDEI-NOEXISTE-GC` | `6b6258a44cf1f9e211c8e3c7d77b220fc89436ae` failure: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40689521567 | agregador: TRAZAS=failure; `traza-no-resuelve: TEM-SDEI-NOEXISTE-GC: el ID no está declarado en el registro` | `40863d12ba1b9e28a26d98daf608c7bb10114230` success: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40689636652 |
| 16 | PR-6 diff del contrato OpenAPI | Sí | `contracts/.generado/openapi.json` con una operación de más (`GET /gc/plantada`) | `97f24947df49a4bc299abafee209b70f0173b02a` failure: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40689757046 | agregador: CONTRATO=failure; `operacion-nueva: GET /gc/plantada no está en el contrato versionado` | `6e78828a60a7653e48fe6c9e9516ba890c655007` success: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40689875922 |
| 17 | PR-7 piezas fijadas (SHA-256) | Sí | `BASE-FIJADA.md` nuevo con una huella que no es la del archivo | `8ec5da559903d1e32181e4f4d2a23977fc17411d` failure: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40689995069 | agregador: FIJADAS=failure; `huella-distinta: Glosario.md cambió respecto de lo fijado` | `dfd2e3f8f49a390b10afeaa3622d4a283a072b80` success: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40690087964 |
| 18 | PR-7 `reflint` (cuerpo nuevo) | Sí | entrada `ref-aghajani-2019` de `Referencias.md` sin título en cursiva | `1076192e23d6e51a2888349fd2dffceb5988ac38` failure: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40690207238 | agregador: FIJADAS=failure; `ref-sin-titulo-en-cursiva: ref-aghajani-2019` | `8e1a4d0492c7866442e1ba5421e06b1e1c288f4e` success: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40690322965 |
| 19 | PR-7 `url-fecha` (cuerpo nuevo) | Sí | cita por dominio `docusaurus.io/docs/gc-prueba` sin fecha ni `ref-…` | `5db8314903bbe7cd1daf03522c0e71b4832a8791` failure: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40690422344 | agregador: FIJADAS=failure; `dominio-sin-referencia: docusaurus.io/docs/gc-prueba` | `fa25beb81d547e594ec4559b8c643f687b33be69` success: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40690527515 |
| 20 | autoprueba (G-c y AK-7) | Sí | fixture AK-7 desarmado: su comentario HTML escapado | `15513a30a52c6fe663273d003d6ac3a6328f2548` failure: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40690653886 | agregador: AUTOPRUEBA=failure; `FALLA AK-7 fixture permanente rc=1; no detectados: AI-1` | `4a0fbf18354dda546131b79a0a221e86e5318cee` success: https://github.com/hdcm-dev/Lab-Documentos/actions/runs/40690768991 |

Totales: 20 rojas (`conclusion: failure`), 20 verdes (`conclusion: success`), las 40 en `hpdev-runner-dev`. En cada roja el agregador marcó **un solo** grupo distinto de `success`, el del control plantado; en cada verde, los ocho grupos `success` y `== docs-guard: verde`. Duración de los jobs: 26 s a 43 s (media 31 s).

Ensayo local previo (mismo orden): `scripts/ci-local.sh todo` con cada defecto, uno por vez, sobre `490646b`: los 20 dieron rc=1 con un solo grupo `ROJO`, el esperado; la base dio `== docs-guard: verde`, rc=0.

## 4. Lo que no se planta, y por qué

- **AI-3** y **AI-4 en el anexo**: avisan por diseño (README §5). Su no-bloqueo lo prueba la autoprueba en cada corrida verde: `ok    PR-3 AI-3 avisa              verde (rc=0)` y `ok    PR-3 AI-4 avisa en anexo     verde (rc=0)` (run 40690768991). Plantarlos no daría rojo y no es parte de G-c.
- **Anclas de nivel 2** (`ruta#Símbolo@SHA`): `docs-guard` no las comprueba (no baja código; `dg.py trazas` sin `--fuente`). Las bloquea el workflow `mini-demo-movilidad`, fuera del alcance de esta medición; en `docs-guard` sólo entra su par de fixtures dentro de la autoprueba (`PR-5 anclas`, rojo y verde en cada corrida).
- **`url-fecha` en lo heredado o en `status: obsoleto`**, **`reflint` en lo heredado**, **`cita-linea`** y **trazas externas sin `source.lock`**: avisan (README §5).

## 5. Observaciones

- **Disparador.** Se usó `workflow_dispatch` y no un PR en borrador: `docs-guard.yml` corre también por despacho, y los grupos no comparan contra la base del PR (`scripts/ci-local.sh` no usa diff), así que el job es el mismo. Un PR habría disparado también `framework-concept-demo` (5 a 10 min por cabeza en el mismo runner) cuarenta veces. Por eso no hubo PR que cerrar.
- **Corrida sobrante.** El primer intento de reversión falló en local (opción inválida de `git revert`); el push se rechazó y el despacho volvió a correr la cabeza roja: run 40685058091 sobre `a18ddf8af794e48d020423e6d715e9fd6b4e3d68`, `failure`. Repite la roja de la fila 1; no se usa en la tabla. La reversión buena es `14f6649cf541ef4efdcddb7d0b9a2cd08b526ede`.
- **Fila 3.** El relativo que sale del repositorio también lo ve lychee (el destino no existe); los dos están en el grupo PR-1 y el log muestra la regla `relativo-fuera-del-repo` de `dg.py fuera`.
- **Commits.** 40 en la rama (`git log 490646b..4a0fbf18354dda546131b79a0a221e86e5318cee`), todos con «NO FUSIONAR» en el asunto. Los SHA siguen accesibles por las URL de las corridas aunque la rama ya no existe.

## 6. Refutación (no sostiene el CUMPLE: INSUFICIENTE)

Reproducida por la crítica del paquete el 2026-10-28. Los 40 pares de §3 se recontrolaron por API (`/actions/runs/{id}/jobs`): 40/40 con el `head_sha`, la `conclusion` y el runner (`hpdev-runner-dev`) de la tabla. Lo que objeta la refutación es el alcance: el umbral dice «cada control bloqueante» del escalón (`N09` §9.2; `133` §2), no sólo los de `docs-guard`. Controles bloqueantes sin par en el runner:

| # | Control | Dónde bloquea (SHA) | Por qué no tiene par |
| --- | --- | --- | --- |
| 1 | `mini-demo-movilidad.yml` C1 (contrato) y C3 (trazas y anclas contra el SHA) | `.github/workflows/mini-demo-movilidad.yml:5` y `:7` («Bloquea»), `490646b` | §4 lo dejó fuera de esta medición; la negativa real `RN-LOC-01` (C4) corre dentro de cada corrida, pero no hay par con URL de las dos corridas |
| 2 | Job `verificar` de Lab-Documentos.Documentacion: clave privada, `.apk/.aab/.keystore/.jks/.p12`, archivo > 5 MiB | `.github/workflows/verificar.yml:42-53` (`FALLA=1`, `exit "$FALLA"`), `e0e520f` | El par de E1-U0b (folio `211-e1-u0b`, fila 3) plantó sólo un enlace roto |
| 3 | Paso `herramientas` de `docs-guard.yml` (`sha256sum -c` del tarball de lychee) | `.github/workflows/docs-guard.yml:76-77`, sin `continue-on-error`; `scripts/ci-local.sh:58` | No se plantó una huella falsa |
| 4 | Reglas de `dg.py` que bloquean y no tienen caso propio | PR-5 `traza-mal-formada`, `traza-ambigua`, `traza-sin-version`, `traza-version-desfasada` (`tools/docs-guard/dg.py:644`, `:657`, `:662`, `:665`); PR-6 `contrato-sin-extraccion` (`:722`); PR-2 `ayuda.schema.json` y `readme-cuerpo.schema.json` | La granularidad («fila del README §5» o «regla de `dg.py`») no está declarada |

Además: PR-7 «fijadas» no vigila ninguna pieza real (`PR-7 fijadas: verde … piezas=0` en `criterios-por-unidad.md` §1, I-1; `BASE-FIJADA.md` sólo existe en `tools/docs-guard/fixtures/`), y el «ensayo local previo» de §3 no tiene salida guardada.
