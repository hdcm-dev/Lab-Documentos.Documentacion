---
doc_id: EXP0003-F400
doc_type: resolucion
title: Resolución 99 de la mesa de cierre del libro — partir por Parte dentro del PR 8, etiqueta sdei-v2.0.0-borrador, fusión por el ciclo automático y PR 9 de cierre
status: vigente
origin: agent
confidence: alta en la decisión (unanimidad de editor, render y proceso, 2026-11-07); alta en las mediciones citadas, tomadas el 2026-11-07
owner: presidencia de la reedición DocsAsCode (expediente 0003)
last_review: 2026-11-07
audience: [PO, presidencia, editores, agentes que apliquen el plan, sesión FRAMEWORK MAUI]
traces: [EXP0003-F099, EXP0003-F399]
---

| Campo | Valor |
| --- | --- |
| Tipo | resolucion |
| Fecha | 2026-11-07 |
| Autor | Mesa de cierre del libro (editor, render, proceso), por orden del PO del 2026-11-07 |
| Corrige | — |

Folio versionado antes del merge del PR 8 (hdcm-dev/Lab-Documentos #61), como pide su §1. El texto que sigue es
la resolución tal como la escribió la mesa; las rutas del equipo se sustituyen por marcadores.

**Fecha:** 2026-11-07. **Decide:** la mesa (editor, render, proceso), por orden del PO del mismo día:
«si fusionás todos los PR seguí el conocimiento Knowledge-Conformacion-Pull-Request-Automatico.md; que la
mesa decida el mejor camino y lo ejecute». Normas leídas: Automático §3.1–§3.5, §4 y §5; padre Manual §4
(un defecto propio se corrige en la misma unidad) y §5 (cierre con decisiones pendientes).

### 1. Decisión

Unanimidad de los tres votos: **partir el libro por Parte dentro del PR 8** (hdcm-dev/Lab-Documentos #61),
crear la etiqueta `sdei-v2.0.0-borrador` antes del merge, fusionar el PR 8 por el ciclo automático y
después abrir el PR 9 en Lab-Documentos.Documentacion.

Fundamentos:

- **Partir es corrección de un defecto propio** (Manual §4, Automático §3.4 último párrafo): el archivo
  único (529 KB, 30 mermaid, GitHub dibuja 0–12) incumple el techo de 400 KB y deja diagramas sin dibujar.
  Fusionarlo así dejaría un defecto conocido en `main`.
- **La reserva «decisión que no le corresponde al agente» queda levantada** para la partición: el PO delegó
  hoy la decisión en la mesa. La condición de proceso se cumple escribiendo esta resolución y llevándola
  al expediente como folio versionado antes del merge (§3.1: lo dicho y no escrito no alcanza).
- **Granularidad:** un archivo por Parte (V partida en 5a y 5b) más uno de Anexos B–H; se descarta por
  capítulo (~25 archivos, sin mejora de dibujo).
- **Ninguna decisión de este camino es exclusiva del PO** según el conocimiento. Sí lo serían las
  decisiones de contenido abiertas (p. ej. temas de fondo que pidan criterio nuevo): **no se resuelven
  al fusionar**, se difieren al folio de cierre (no hay registro durable de diferidos, SDD §12.3).

### Discrepancia resuelta: correcciones aprobadas de int4-propuestas

El editor las mete en el PR 8; render las deja fuera de ambos PR. Resuelve la mesa:
- **Las aprobadas (tramos a, b, c; 79 filas) entran en el PR 8, aplicadas antes de partir**: ya están
  decididas (no hay decisión pendiente) y sus números de línea son los del archivo único. Las que corrigen
  una afirmación falsa o un enlace roto son, además, bloqueantes.
- **Las rechazadas (`tramo-*.rechazadas.tsv`) no se aplican** y se listan en el folio de cierre.
- **Lo que pida una decisión de contenido nueva** va como diferido al folio de cierre, no a ningún PR.

### 2. Delegación (Automático §3.1)

| Repo | Asiento | Consecuencia |
| --- | --- | --- |
| hdcm-dev/Lab-Documentos | `CHANGELOG.md` l. 99–106, folio 006 §1 del exp. 0003, 2026-10-25, PO. Cubre PR del expediente y la etiqueta. Techo 120 min, relectura 30 s | Ciclo automático para PR 8 |
| hdcm-dev/Lab-Documentos.Documentacion | **Sin fila del exp. 0003** (sólo la del exp. 0001 de Framework Concept) | El PR 9 asienta su propia fila (orden del PO 2026-11-07, literal, y regla general «siempre para conformar los pr sigue…»), con el patrón «incluido este PR, que asienta la fila» |

Cada informe cita ruta, fecha y responsable de la delegación.

### 3. Plan ejecutable

Todo en worktrees bajo `<worktrees>/`; nada de checkout/commit/clean/stash en clones principales. Commits con
la identidad de autor del repositorio (`git -c user.name=… -c user.email=…`, cuenta noreply)
y `Co-Authored-By: Claude Opus 5.5 <noreply@anthropic.com>`. Un PR por vez por repo.

### Paso 1 — Worktree y puesta al día del PR 8
- `git worktree add <worktrees>/dac-0003-libro dac/0003-libro` (desde ba99393); `git merge origin/main`
  (≈34 commits). **Nunca rebase ni squash** (lleva expediente).
- **Acepta:** merge sin conflictos o con conflictos resueltos y declarados; `git log` conserva ba99393.

### Paso 2 — Aplicar aprobadas sobre el libro único
- Aplicar las 79 filas aprobadas de `int4-propuestas/tramo-{a,b,c}` y las citas remapeadas, en orden de
  línea descendente para no desplazar números.
- **Acepta:** cada fila aprobada aplicada o justificada como no aplicable (conteo aplicado + justificado =
  79); 0 filas rechazadas aplicadas.

### Paso 3 — Partir, remapear, barrer
- Raíz `DocsAsCode-Developer-Guide.md`: portada, prólogo, índice general con enlaces `archivo#ancla`,
  glosario-índice. Piezas `parte-0` … `parte-6` (5a/5b) y `anexos-b-h`, con navegación
  «anterior · índice · siguiente» y frontmatter según Anexo C, `estado: borrador`.
- Remapear anclas con `*.anclas.txt` y `*.referencias.tsv`; actualizar LIBRO-INDICE / `01-Mapa.md` y
  cualquier enlace entrante de otros documentos del repo.
- Barrido de privados con grep sobre todos los archivos nuevos y modificados: nombres de máquinas, rutas
  `/home` y `/vm`, IPs, nombre del servicio privado (va `{servicio-privado}`). No se toca `Concepts/`.
- **Acepta:**
  - cada archivo ≤ 350 KB (meta) y en ningún caso > 400 KB; ≤ 7 mermaid por archivo (límite duro 15);
  - **0 enlaces internos rotos** (comprobados con un verificador de anclas sobre todo el repo, no sólo el libro);
  - **0 hallazgos** en el barrido de privados;
  - markdownlint y docs-guard en verde **en local** antes de empujar.

### Paso 4 — Medir el dibujo en GitHub
- Empujar la rama y medir cada pieza con el medidor de `mermaid-pr8-r3` (nuevo registro `mermaid-pr8-r4`).
- **Acepta:** 30/30 mermaid dibujados; un timeout del medidor se reintenta hasta 2 veces; una falla
  reproducible es **reserva** (no se fusiona).

### Paso 5 — Etiqueta
- Crear `sdei-v2.0.0-borrador` anotada sobre 31660d3 en el worktree, empujarla, comprobar con
  `git ls-remote --tags origin sdei-v2.0.0-borrador` (devuelve 31660d3 o el objeto etiqueta que apunta a él)
  y que un enlace `.../blob/sdei-v2.0.0-borrador/<ruta guía archivada>` responde 200.
- **Acepta:** ls-remote coincide y HTTP 200. Si ya existe apuntando a otro SHA: reserva (no se pisa).

### Paso 6 — Folio de esta resolución
- Antes del merge del PR 8, llevar esta resolución al expediente 0003 como folio versionado (en la rama del
  PR 9 ya abierta en borrador, o en el propio PR 8 si el expediente vive allí) y citarlo en el informe.
- **Acepta:** el folio tiene URL en una rama empujada al momento de publicar el informe.

### Paso 7 — Guarda y merge del PR 8 (Automático §3.3, §5.2)
- Credencial `-utn` del almacén de git, `permissions.push == true` verificado (sin listar `~/.git-credentials`).
- Publicar informe con el enlace del PR, la delegación citada y esta resolución, **antes** de fusionar.
- Guarda en primer plano (los procesos de fondo mueren con el turno): G1 head.sha = SHA auditado;
  G2 `mergeable == true` y `mergeable_state == clean`; G3 ≥ 1 corrida, todas `success` (docs-guard y
  markdownlint incluidos); G4 sin reserva. Techo 120 min, relectura 30 s, última relectura inmediata.
- SendMessage «fusiono hdcm-dev/Lab-Documentos #61» a FRAMEWORK MAUI, Crear IA Layer Guide y
  workspace-dev-e8 (confirmar el nombre exacto con ListAgents: el contexto menciona también
  workspace-dev-eb).
- `PUT .../pulls/61/merge` con `merge_method=merge` y `sha`; leer `merged == true`; recién entonces borrar
  `dac/0003-libro` y comprobar 404; leer controles del commit de merge en `main`.
- **Acepta:** `merged=true`, rama remota 404, controles del merge en `main` en verde. Si fallan: se declara
  y **no se encadena** el PR 9.

### Paso 8 — PR 9 en Lab-Documentos.Documentacion (desde main 87bcaa4 actualizado)
- Fila de delegación del exp. 0003 en `CHANGELOG.md` (fecha 2026-11-07, PO, orden literal).
- Entrada en `R2/05-Rondas-Editoriales.md` con partición, mediciones (tamaño y mermaid por archivo) y
  etiqueta; reindexado de su ia-db (índice 11) sobre `main` ya con el libro partido.
- Folio de cierre del exp. 0003: diferidos (rechazadas, citas pendientes que no son error de hecho,
  decisiones de contenido abiertas: partición ya resuelta, BadDeviceToken y demás que sigan abiertas).
- Mismo ciclo: barrido de privados 0, CI verde, guarda, aviso a las tres sesiones (y a workspace-dev-cf
  sólo si se toca Lab-Geometria.Documentacion), merge commit atado al SHA.
- **Acepta:** igual que paso 7.

### Paso 9 — Reindexado de ia-db de Lab-Documentos
- PR aparte en Lab-Documentos (uno por vez por repo), mismo ciclo y mismos criterios.

### Paso 10 — Cierre
- `git fetch --prune` en ambos repos: 0 ramas remotas del expediente; worktrees retirados.
- Cierre de ciclo que diga «fusionado por el agente» con los tres enlaces.

### 4. Reservas (el merge vuelve al PO)

- Mermaid que no dibuja de forma reproducible.
- Enlaces rotos en documentos ajenos que no se corrigen en el mismo PR.
- Barrido de privados ≠ 0 que no se pueda corregir en la unidad.
- Guarda que no pasa (estado ≠ `clean`, controles en rojo o ausentes, techo agotado, merge rechazado),
  incluida una falla ya presente en `main` (se comenta con evidencia en el PR).
- Etiqueta existente sobre otro SHA.
- Cualquier cuestionamiento particular del PO sobre la unidad durante la corrida.
