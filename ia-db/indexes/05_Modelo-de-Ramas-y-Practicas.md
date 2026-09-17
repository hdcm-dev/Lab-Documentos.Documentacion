# 05 — Modelo de ramas, versionado, pull requests y guías prácticas

> **Propósito**: el procedimiento de ramas, versionado y pull requests que el equipo adoptó, con
> sus workflows listos para copiar, y las dos guías prácticas que lo ejercitan (GitFlow adoptado
> y GitHub Flow como línea de base). Cubre `Guides/Estandares-Modelo-Ramas-Guide/`,
> `Guides/GitFlow-Practice-Guide/` y `Guides/GitHubFlow-Practice-Guide/` (≈4 600 líneas + 3 yml).
> **Fuente primaria**: `Estandares-Modelo-Ramas-Guide/Estandares-Modelo-Ramas.md` (`GF-GUIA`,
> `last_review` 2026-08-23, consolida `GF-01..08` y `GF-AX-*`), `Anexos/workflows/README.md`
> (`GF-AX-WF`), `GitFlow-Practice-Guide/README.md` (`GF-09`), `GitHubFlow-Practice-Guide/README.md` (`GHF-IDX`).

## En una pantalla

- **Modelo adoptado: tronco `main` + ramas `release/x.y`**. Las correcciones nacen en `main` y
  viajan a la release por **cherry-pick, nunca al revés**. No existe `develop`, `homologacion` ni
  `produccion`: esos son **ambientes**, y entre ambientes se mueven **artefactos** (§6 **[C]**).
- Marcas: **[F]** fuente externa (Anexo E) · **[C]** convención del equipo, discutible ·
  **[E]** comprobado ejecutando, con fecha. Las dos guías prácticas usan las mismas marcas.
- Práctica sobre `Lab-GitFlow` con la app de `Lab-E2E.WebBlazor`, equipo de tres (I1/I2/I3 rotando
  por los actores). Las dos prácticas dejan **estados incompatibles**: correr una a la vez.
- Estado de verificación: `ci.yml` **corrió en Actions** (2026-08-25, runner `i7infra-dev`);
  `release.yml` y `auditoria-convergencia.yml` **no** (sus disparadores no se dieron; la lógica de
  shell de la auditoría se probó fuera de Actions el 2026-08-23). Los escenarios de GitHub Flow
  **no se ejecutaron**.

## El documento único `Estandares-Modelo-Ramas.md` (2 132 líneas)

| § | Tema | Qué fija |
|---|---|---|
| 1 | Marco de referencia | Escenarios `E-01..08`, contextos `C-1..4`, actores `A-*` (tabla abajo) |
| 2 | Mapa conceptual | Entrada por escenario, por rol, por artefacto; rutas de lectura |
| 3 | Fundamentos de Git | Las cinco operaciones que importan |
| 4 | GitFlow | Cómo funciona; **la nota de 2020** de Driessen cambia cómo leer el modelo (`NVIE-1`) |
| 5 | Cómo elegir el modelo | Cuatro modelos comparados; criterio en tres preguntas; qué dice la evidencia (DORA) y qué no |
| 6 | **Modelo adoptado** | Inventario de ramas, las siete reglas, nomenclatura, la única excepción, guardarraíles |
| 7 | Integración y versionado | Rama ≠ tag ≠ artefacto ≠ ambiente; SemVer; ciclo de vida de una versión; build hermético; demostraciones; autorización y cierre |
| 8 | Pull requests y pruebas | Ciclo del PR, tamaño, estados del issue, qué verifica el pipeline y cuándo, protección de rama |
| A–E | Anexos | Glosario · Plantillas (PR, issue, cherry-pick) · Listas de verificación · Preguntas que forman criterio · Fuentes |

### Marco (§1)

| Eje | Valores |
|---|---|
| Escenarios | `E-01` funcionalidad nueva · `E-02` defecto antes de liberar · `E-03` corte de versión · `E-04` estabilización de la candidata · `E-05` emergencia en producción · `E-06` versión de demostración · `E-07` mantenimiento sin efecto funcional · `E-08` rechazo de un cambio |
| Contextos | `C-1` sin release abierta · `C-2` con release abierta (cada cambio exige decisión de admisión) · `C-3` producción comprometida (habilita la vía de excepción) · `C-4` producto con **tres o más** versiones soportadas (cambia el modelo) |
| Actores | `A-PO` · `A-DEV` · `A-REV` revisión · `A-QA` · `A-OPS` devops/releases · `A-SEC` · `A-AUT` autoridad de cambio (autoriza a producción según riesgo) |

### Comparación de modelos (§5.2)

| | GitHub Flow | GitFlow | GitLab Flow | Tronco + release |
|---|---|---|---|---|
| Ramas de vida larga | 1 | 2 | 1 + ambientes | 1 |
| Versiones vivas | 1 | varias | 1–2 | 1–2 |
| Defecto de producción se corrige en | principal | release/hotfix | principal + cherry-pick | principal + cherry-pick |
| Coordinación | baja | alta | media | media |
| Necesita feature flags / pruebas fuertes | sí / sí | no / menos | sí / sí | sí / sí |

El desacuerdo GitFlow (estabilizar en release y mergear hacia develop) vs. tronco (corregir en
tronco y cherry-pickear) **se resuelve por contexto**: web con despliegue frecuente y una versión
viva → tronco; producto instalable con varias versiones soportadas → GitFlow (§6.2).

### Modelo adoptado (§6)

| Rama | Vida | Nace de | Quién escribe |
|---|---|---|---|
| `main` | permanente | — | nadie directamente: solo merges de PR |
| `feature/*`, `fix/*`, `chore/*` | objetivo ≤ 2 días; **> 7 días incumple [C]** | `main` | el desarrollador asignado |
| `release/x.y` | semanas, luego se borra | `main` o un commit anterior | nadie directamente: cherry-picks y hotfixes por PR |
| `hotfix/*` | vía de excepción | **el tag de producción** | PR a `release/x.y` + retorno obligatorio a `main` |

Nomenclatura `prefijo/NNN-descripcion` (número de issue adelante), p. ej. `feature/107-filtro-por-partida`.

**Las siete reglas (§6.2)**: 1 toda rama nace de `main` actualizado [C] · 2 `main` protegida [C] ·
3 un issue → una rama → un PR → un commit en `main` [C] · 4 los defectos se reproducen y corrigen
en el tronco, con prueba, y después se cherry-pickean [F: TBD-1, SRE-2, GL-1] · 5 no se corrigen
en la release «esperando llevarlos de vuelta» [F: TBD-2] · 6 se construye una sola vez y se
promociona el artefacto [F: SRE-1] · 7 la configuración depende del ambiente por variable de
entorno, nunca de la rama [C]. Las reglas 4 y 5 son «el corazón del modelo».

**La única excepción (§6.4)**: emergencia real —servicio caído/degradado para usuarios ahora, o
vulnerabilidad siendo explotada—, decidida a partir de un hecho registrado. Un mismo issue produce
dos ramas y dos PR (hotfix y retorno).

### Integración y versionado (§7)

- Cuatro objetos que no se confunden: **rama** (puntero móvil), **tag** (puntero inmutable, `v1.4.0`;
  no es un artefacto), **artefacto** (build versionado; no se rehace por ambiente), **ambiente**.
- SemVer: PATCH corrección compatible · MINOR funcionalidad compatible · MAJOR incompatible ·
  candidata `v1.4.0-rc1` · demostración `v1.5.0-demo.3` **[C]** (nunca soportada).
- Ciclo de una versión: **corte** → estabilización (se admite cualquier defecto de QA) →
  **congelamiento** (solo bloqueantes) → **pase** a producción. Rollback: lo decide `A-AUT`; el tag
  fallido no se borra ni se reutiliza; se reabre el issue y se abre uno de emergencia [F: ITIL-1].

### Pull requests y pipeline (§8)

| Disparador | Alcance |
|---|---|
| `pull_request` a `main`/`release/*` | Comprobaciones rápidas + regresión en **un solo navegador** (chromium) |
| `push` a `main` / `release/*` / `merge_group` | Matriz completa de navegadores (un cherry-pick limpio no garantiza que funcione [F: TBD-1]) |
| `schedule` | Matriz completa nocturna |
| `workflow_dispatch` | A pedido, parametrizado |

Protección de `main` y `release/*`: sin push directo, verificaciones obligatorias (**un solo check
`CI aprobada`**), 1 aprobación [C], *Require review from Code Owners*.

### Fuentes (Anexo E)

`DORA-1`, `TBD-1/2` (trunkbaseddevelopment.com), `GOOG-1/2` (small CLs, speed of reviews),
`SRE-1/2/3` (Google SRE Book, release engineering), `GL-1` (GitLab Flow), `NVIE-1` (Driessen +
nota 2020), `GH-1` (GitHub Flow docs), `GHA-1` (reusing workflows), `PW-1` (Playwright CI),
`PYT-1`, `NIST-1` (SP 800-218), `ISO-9241`, `SWEBOK-1`, `SEMVER-1`, `CC-1` (Conventional Commits),
`ISO-12207`, `ISO-29119`, `ITIL-1`, `ISTQB-1`. Cada fila registra si la URL respondió 200 o si se
cita «por el insumo».

## Los workflows del anexo (`Anexos/workflows/`, `GF-AX-WF`)

| Archivo | Disparadores | Qué hace |
|---|---|---|
| `ci.yml` | `pull_request` y `push` a `main` y `release/**`, `merge_group` | Verificación rápida, regresión E2E, check resumen `CI aprobada`. **Reemplaza** al `ci.yml` de la app sembrada, que solo cubría `main` |
| `release.yml` | `push` de tag `v*` | Verifica la referencia, construye **una vez**, publica la versión; único con `contents: write` |
| `auditoria-convergencia.yml` | diario, `push` a `release/**`, a pedido | `git cherry` (compara por contenido; exige `fetch-depth: 0`) para detectar correcciones de release que no volvieron a `main`; excluye commits con encabezado `Convergencia:` |

Supuestos declarados: existe `e2e.yml` reutilizable en la app con exactamente cuatro entradas
(`navegadores`, `url-base`, `referencia`, `retencion-dias`; **no** `cantidad-shards`); proyecto en
`src/MovilidadUrbana.Web`, pruebas .NET en `tests/MovilidadUrbana.E2ETests` con `pruebas.runsettings`;
runner autoalojado `self-hosted` + `i7infra-dev` (es un contenedor sin Docker, con .NET 10 sobre
Ubuntu 24.04, por eso los jobs corren sin `container:`); repositorio privado sin forks o con
aprobación manual (un runner persistente ejecutando el `ci.yml` de un PR ajeno es ejecución
remota de código) **[C]**.

## Guía práctica de GitFlow (`GitFlow-Practice-Guide/`, `GF-09`)

Ocho escenarios en `Guia-Practica-GitFlow.md`, cada uno con objetivo, precondición, pasos, qué
observar, errores frecuentes y verificación. **Orden de ejecución ≠ orden de lectura**:
**00 → 01 → 03 → 02 → 04 → 05 → 06 → 07** (el 02 exige `release/1.0`, que solo crea el 03; el 05
exige `v1.0.0`, que produce el paso 6 del 03).

| # | Escenario | Ejercita |
|---|---|---|
| 00 | Preparación | Repo, protección de rama, pipeline, `CODEOWNERS` |
| 01 | Funcionalidad nueva | `E-01`: rama corta, PR, revisión, squash merge |
| 02 | Defecto con release abierta | `E-02`: prueba que falla primero, cherry-pick, nueva candidata |
| 03 | Corte de release y liberación | `E-03`+`E-04`: corte retroactivo, candidata, admisión, autorización, tag final, promoción |
| 04 | PR que rompe la regresión | `E-08`: «el control que motivó esta guía» |
| 05 | Emergencia en producción | `E-05`: hotfix desde el tag y retorno obligatorio |
| 06 | Versión de demostración | `E-06`: artefacto identificable y desechable |
| 07 | Cierre y auditoría | Convergencia, higiene de ramas, retrospectiva |

Requiere: escritura y permiso de protección de rama en el repo de práctica; runner `i7infra-dev`
o uno alojado cambiando `runs-on:`; Docker en cada máquina. Los escenarios 01–05 llevan una jornada.

## Guía práctica de GitHub Flow (`GitHubFlow-Practice-Guide/`, `GHF-IDX`, `confidence: media`)

Ejercita el modelo **no adoptado** como línea de base: «todo lo que un modelo agrega hay que
justificarlo contra lo que costaría no tenerlo». Tres consecuencias a sentir: el defecto de
producción se corrige en la principal; hacen falta **feature flags**; hace falta automatización
de pruebas fuerte. Orden de ejecución = orden de lectura (00 → 07).

| # | Escenario | Ejercita |
|---|---|---|
| 00 | Preparación | Sin `release.yml` ni auditoría de convergencia |
| 01 | Funcionalidad nueva | Los seis pasos documentados [F: GH-1] |
| 02 | Corrección hacia adelante | `E-05` sin rama de hotfix |
| 03 | PR que rompe la regresión | `E-08` |
| 04 | Cambio grande con feature flag | Lo que reemplaza a la rama larga |
| 05 | Reversión | Cuando corregir hacia adelante no llega a tiempo |
| 06 | Vista previa para demostración | `E-06` sin tag |
| 07 | Cierre y auditoría | Qué controles dejan de tener sentido |

Estado: comandos escritos para correrse, **no ejecutados**; el `ci.yml` de la app sembrada cubre
el modelo sin agregados [E]. Existe una bitácora de corrida real en
`Lab-Documentos.Documentacion/PROMPTs/Guides/05-Practica-Interactiva-Practica-GitHubFlow/OUTPUTs/`
(`GHF-EXP-01`, según el CHANGELOG del 2026-09-03).

## Relación con las otras guías

- El pipeline que §8 describe se explica sección por sección en `GitHub-Action-Guide.md`
  (traza `GF-07`, `GF-08`, `GF-AX-WF`) → [06](06_GitHub-Actions-y-E2E.md).
- `DevOps-Guide/guia-flujo-trabajo-versionado.md` propone otro modelo (`main` + `homologacion`)
  que **no es el adoptado** (hallazgo H-05) → [07](07_DevOps-Agiles-SDD-UX.md).
- La familia 6 de Documentación técnica (`DOC-DEVGUIDE`, git workflow) es el lugar donde este
  procedimiento se documentaría en un proyecto → [01](01_Documentacion-Tecnica.md).
