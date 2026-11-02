---
doc_id: BIT-16-REC-INV-repos
titulo: Inventario «repos» de la mesa de reconciliación estación 1 / equipo anterior
guia: 16-IA-Layer
fecha: 2026-10-28
hora_relevamiento: "20:21–20:30 (-03)"
rol: inventariador «repos» (sólo lectura)
estado: cerrado
---

# Inventario «repos»: estado de git, GitHub e equipo anterior para la guía 16

Relevamiento de sólo lectura. No se hizo commit, push, fetch, PR, rama, stash ni cambio de configuración, ni en estación 1 ni en equipo anterior. En GitHub sólo se hicieron GET a la API REST y `git ls-remote`. En equipo anterior sólo `git status/branch/log/reflog/stash list/worktree list`, `find`, `ps` y `stat`.

Abreviaturas: **LD** = `hdcm-dev/Lab-Documentos` (guía en `Guides/IA/Dot-Net-Integration-AI-Layer-Guide/`); **LDD** = `hdcm-dev/Lab-Documentos.Documentacion` (bitácora y prompts en `PROMPTs/Guides/16-IA-Layer/`).

## 1. estación 1

| | LD | LDD |
|---|---|---|
| Rama actual | `main` = `origin/main` (0989a15, PR #33) | `main` d05955b, **detrás 6** de `origin/main` (3e6f266) |
| Cambios versionados | ninguno (`git status --porcelain` vacío) | ninguno |
| Carpeta de la guía 16 | ignorada por `.git/info/exclude:7` `/Guides/IA/Dot-Net-Integration-AI-Layer-Guide/` (verificado con `git check-ignore -v`) | ignorada por `.git/info/exclude:7` `/PROMPTs/Guides/16-IA-Layer/`; además excluye `/PROMPTs/Guides/14-.../ARTIFACTs/` |
| ¿La guía 16 está en el índice o en algún commit? | no en `main`; sólo en `rescate/{estación-1}-2026-10-28` (ver abajo) | ídem |
| Stash | vacío | vacío |
| Worktrees | `{worktrees}/ld-main` (detached 490646b, limpio); **`{worktrees}/ld-fc-tpr` creado a las 20:27 de hoy** (detached 0989a15): la otra mesa está activa ahora | `{worktrees}/ldd-e1g` (rama `exp0002/e1g-resolucion`, un archivo sin seguimiento: actuación 250 del exp. 0002) |
| `bin/` y `obj/` dentro de las carpetas de la guía 16 | 0 | 0 |

**Ramas locales `rescate/{estación-1}-2026-10-28` (sólo locales, no están en GitHub):**

- LD 674466c (08:29 de hoy, autor `<usuario-git>`), sobre 5d5c2b4: 183 archivos. Incluye `Guides/IA/Dot-Net-Integration-AI-Layer-Guide/Dot-Net-Integration-AI-Layer-Guide.md` **con 0 bytes** (la foto del 26-10 tenía la guía vacía). El resto es Framework Concept y otros.
- LDD 20cd8bb (08:30 de hoy), sobre 8da0cd9: 628 archivos. **57 son de la guía 16**: el prompt, REED-16, `INPUTs/AI-Layer.png`, bitácoras 00–03, `README.md`, `Sondeo-Entorno.md`, 9 de `Mesa/` (insumos I-01 a I-03…) y 39 de `Nucleos/`. Es la foto del 26-10 que se usó para reanudar.

Ramas `exp0002/*` locales marcadas «desaparecido» (ya fusionadas y borradas en GitHub): restos de la otra mesa, que no tocan la guía 16.

## 2. GitHub (estado a las 20:2x)

- **PRs abiertos:** LD #31 `exp0002/e1r-h-ci-trazas` (28 archivos: docs-guard, fixtures, `.gitignore`, `scripts/ci-local.sh`) y LD #32 `exp0002/e1r-h-agents` (`AGENTS.md`); LDD #32 `exp0002/e1r-h-verificar` (`.github/README.md`, `verificar.yml`) y LDD #33 `exp0002/e1r-h-politicas` (actuación 255). Los cuatro tienen el título «[espera PO]». **Ninguno toca rutas de la guía 16** (lista de archivos por API).
- **Ramas remotas:** sólo `main` más las dos `exp0002/e1r-h-*` de cada repo. No hay ninguna rama `rescate/*` ni rama de la guía 16.
- **Historia remota de las rutas:** `GET /commits?path=` devuelve vacío para `Guides/IA/Dot-Net-Integration-AI-Layer-Guide` y para `PROMPTs/Guides/16-IA-Layer`. El único commit bajo `Guides/IA` es 9162e07 (28-09, reorganización de Guides/). **La guía 16 nunca se publicó.**
- **Algo que conviene saber de LD #31:** suma la regla `id-duplicado`, `traces-vacio` y el control de READMEs del cuerpo sin frontmatter. Cuando la guía 16 entre al repo, va a pasar por esa versión de docs-guard: `doc_id` únicos, `traces` no vacío y frontmatter YAML válido en cada página.

## 3. equipo anterior (sólo lectura por ssh)

| | LD | LDD |
|---|---|---|
| `main` | 5d5c2b4 «.» (11-10), **detrás 56**, no está adelantado | 8da0cd9 «.», **detrás 35**, no está adelantado |
| Modificados | `CHANGELOG.md`, `Lanzar-Example.md`; sin seguimiento `.github/`, `Concepts/`, **`Guides/IA/Dot-Net-Integration-AI-Layer-Guide/`** | 4 prompts de las guías 06 y 14, `Actualizar-Indexado.md`, entre otros (27 entradas); sin seguimiento **`PROMPTs/Guides/16-IA-Layer/`** (los `*.log` de `Evidencia/` quedan además ignorados por `.gitignore`) |
| `.git/info/exclude` | **vacío**: la guía 16 está como `??`, no excluida | **vacío** |
| Stash | vacío | vacío |
| Commits de la guía 16 en cualquier rama (`git log --all -- <ruta>`) | **ninguno** | **ninguno** |
| `git log --all --since=2026-10-25` | sólo commits de la otra línea (exp. 0002 y Framework Concept), todos ya en GitHub | ídem |
| Ramas y worktrees locales | `cierre/0001-tpr-emulador`, `exp0002/e1g-frontmatter-yaml`, `exp0002/e1g-reparaciones`, `fc/tpr-teléfono de pruebas`, con worktrees en `{tmp-de-sesiones}` y `{dir-de-trabajo}` | `fc/tpr-teléfono de pruebas` con worktrees en `{tmp-de-sesiones}` y `{dir-de-trabajo}` |

**Respuestas:**

- **¿Se commiteó o se empujó algo de la guía 16 desde equipo anterior?** No. Sin commits en ninguna rama, sin stash y sin rastro en GitHub. Todo lo de equipo anterior está sin seguimiento en los dos árboles de trabajo.
- **¿Hay archivos modificados después de las 20:20 de hoy?** En las carpetas de la guía 16, **no**: 0 archivos (`find -newermt "2026-10-28 20:20"`). En todo el árbol `LAB/Lab-Documentos`, tampoco (fuera de `.git`). Los 16 archivos de la guía 16 tocados hoy son de 00:20 a 00:39 (`07-Redaccion.md`, `06-Construccion.md`, `Bitacoras/README.md`, la guía, los README de los Examples 03, 04 y 08, `tools/verificar-markdown.py` y `Evidencia/Cierre-Redaccion/*`). La sesión que trabajó la guía 16 en equipo anterior (transcripto con 628 menciones de `16-IA-Layer`) registra su último evento a las **00:39 (-03)**. No hubo trabajo después del corte de las 00:50. La copia de `$FOTOS/rescate/` debería estar completa respecto de esa línea. Lo confirma el inventariador de contenidos.
- **Actividad viva en equipo anterior:** a las 20:01 se reconectó VS Code y hay **4 sesiones de Claude Code abiertas desde las 20:03, 20:03, 20:08 y 20:22**, con cwd en `workspace-dev`. Además, a las **20:21:19 y 20:21:20 hubo `git fetch -q --all`** en los dos clones (reflog de `origin/main`). Ninguno de los tres transcriptos recientes trabaja la guía 16 (0, 1 y 0 menciones, y ninguna en sus últimas 200 líneas). Sigue vivo también un `claude --resume` de terminal del 21-10 (Sl+, sin hijos), que es el caso de la memoria «sesión vieja sobrevive a la reconexión».

## 4. Unidades

| id | riesgo | qué hacer |
|---|---|---|
| REPO-01 | La guía 16 no existe en GitHub ni en ninguna rama remota. No hay colisión de contenido con la otra mesa ni con equipo anterior en el remoto. | Nada que revertir. La entrada de la guía 16 al repo es un acto futuro y separado. No lo hace esta mesa (decisión del PO: sin commit, push ni PR). |
| REPO-02 | En estación 1 las dos carpetas están excluidas por `.git/info/exclude` y la otra mesa trabaja en worktrees (`{worktrees}/*`, uno creado a las 20:27). Un `git add -A` de esa mesa en el clon principal no las levanta. | Mantener las exclusiones. No escribir la reconciliación fuera de esas dos carpetas. No tocar `{worktrees}/`. |
| REPO-03 | Las ramas locales `rescate/{estación-1}-2026-10-28` (LD y LDD) **contienen 57 archivos de la guía 16 (foto del 26-10)** y una guía de 0 bytes. Si alguien las empuja o abre un PR desde ellas, publica la bitácora vieja de la guía 16 y una guía vacía, y además rompe la regla de las exclusiones. | Tratarlas como respaldo local, nunca para empujar. Avisar a la presidencia y a la otra mesa que, si se publica algo del rescate, hay que sacar `PROMPTs/Guides/16-IA-Layer/` y `Guides/IA/Dot-Net-Integration-AI-Layer-Guide/` del conjunto. Decisión de mesa. |
| REPO-04 | En equipo anterior **no hay exclusiones**: las carpetas de la guía 16 están como `??`. Hay 4 sesiones de Claude vivas desde las 20:03 y un fetch a las 20:21. Una sesión de equipo anterior que haga `git add -A` y empuje publicaría la línea **no canónica** (0.10.1, con «servidor Ollama de la LAN» y mediciones contra un servidor dado de baja). | Pedirle al PO, por presidencia, que confirme qué hacen esas sesiones y que ninguna toque la guía 16. Esta mesa no escribe en equipo anterior (ni siquiera la exclusión). Si el PO lo autoriza, agregar las dos rutas al `exclude` de equipo anterior o retirar sus copias. Decisión de mesa o del PO. |
| REPO-05 | equipo anterior tiene más cambios sin commitear ajenos a la guía 16 (guías 06 y 14, `Actualizar-Indexado`, `Concepts/`, `.github/`), con `main` muy atrasado (56/35). No es materia de esta mesa, pero se cruza con el rescate de la otra. | Derivarlo a la mesa de integración del repo. No mezclarlo con la reconciliación de la guía 16. |
| REPO-06 | El LDD de estación 1 está **6 commits detrás** de `origin/main`. Ninguno toca la guía 16, así que un `pull` no choca con la carpeta excluida. | No hacer pull desde esta mesa. Lo maneja la otra mesa. Riesgo bajo. |
| REPO-07 | LD #31 (pendiente del PO) endurece docs-guard (`id-duplicado`, `traces-vacio`, frontmatter de README). La guía 16 de estación 1 todavía no pasó por esa versión. | Cuando la guía vaya a entrar, correr docs-guard de `main`, con #31 si ya está fusionado, sobre una copia. Anotarlo como compuerta pendiente, no como bloqueo actual. |
| REPO-08 | No hubo escritura en equipo anterior sobre la guía 16 después de las 00:39 (ni después de las 20:20). La copia en `$FOTOS/rescate/` es la última versión de esa línea, salvo que alguna de las sesiones reabiertas retome el trabajo. | Repetir este chequeo (`find -newermt` sobre las dos carpetas en equipo anterior) justo antes de cerrar la reconciliación. Si aparece algo nuevo, copiarlo de nuevo como insumo con su hora. |
