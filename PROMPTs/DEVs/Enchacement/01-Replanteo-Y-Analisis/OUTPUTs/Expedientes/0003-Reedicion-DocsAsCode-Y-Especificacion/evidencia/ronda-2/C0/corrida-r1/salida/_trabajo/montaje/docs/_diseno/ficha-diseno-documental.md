---
doc_id: ANX-LABDOC-FICHA-DISENO
doc_type: ficha
title: Ficha de diseño documental de Lab-Documentos
description: A-01 del diseño documental de Lab-Documentos, con inventario, decisiones D-01 a D-17, catálogo activo y verificación.
status: borrador
origin: ia-generated
confidence: media
owner: Lab-Documentos — responsable del producto (PO)
last_review: 2026-11-01
audience: [humano, agente, po]
traces: [IDX-LABDOC-AGENTS]
---

# Ficha de diseño documental — Lab-Documentos

Estado de la corrida: **ronda 0, borrador**. Las filas marcadas «pendiente (Q-n)» esperan la respuesta del canal de
demandas (`salida/demandas.md`). Rutas de evidencia: relativas a la raíz del repositorio leído (`repo/LD`). Las
salidas completas de los comandos están en `salida/_trabajo/` del lugar de trabajo (no van al repositorio).

| Campo | Valor |
| --- | --- |
| Proyecto y repositorios leídos, con SHA (sin `.git`: «SHA: pendiente» y huella del árbol, §3.1) | Lab-Documentos (`README.md:14`), un solo repositorio, recibido en `repo/LD`. **SHA: pendiente** (sin `.git`: `git rev-parse HEAD` devolvió «fatal: no es un repositorio git»; Q-2). Huella del árbol: `117ee288a52bebf72be5c7c313b985c2ab357ab4eff5729d3701d4ea37e73a62` con `find . -type f -not -path './.git/*' -print0 \| sort -z \| xargs -0 sha256sum \| sha256sum` desde `repo/LD` (1123 archivos). La misma corrida avisó «Permiso denegado» sobre `Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion` (modo `d---------`, `ls -ld`): esa carpeta, el cuerpo `SDEI`, **no se leyó** y no entra en la huella (Q-1) |
| Fecha | 2026-11-01 |
| Quién aplica | Agente aplicador de la corrida C0-r1 (subagente), sin contexto previo |
| Conocimiento aplicado (alias, versión, huella) | `DocsAsCode-Designing-Specification`, versión 1.1, `conocimiento.md` con SHA-256 `afd741b838ae2bf457f6d2a6143a079d1d65ee76f1ab55d134f560f7165483e8` |

## 1. Inventario (paso 1)

Notas de método. (a) En el shell del aplicador `grep` es una función que llama a `ugrep` con `--ignore-files`
(`type grep`); los comandos 2 a 5 se corrieron con el `grep` de GNU en un shell limpio
(`env -i PATH=/usr/bin:/bin bash --noprofile --norc -c '…'`, `type grep` → `grep is /usr/bin/grep`), con el texto
del bloque sin cambios. (b) `{compuerta}` = `tools/docs-guard`, la compuerta de origen, que en este proyecto vive en
el mismo repositorio (`README.md:41`; `tools/docs-guard/README.md:3-6`). (c) Todos los comandos se corrieron desde
la raíz de `repo/LD`; ninguno recorrió la carpeta `SDEI` (permiso denegado).

| Patrón de §3.1 | Comando | Cuenta | Salida o ruta a la salida |
| --- | --- | --- | --- |
| ID declarado más de una vez | `python3 tools/docs-guard/dg.py trazas --raiz . .` (1) | 56 IDs distintos con `id-duplicado`; 606 hallazgos (rc=1) | `salida/_trabajo/inv-1-trazas.txt`. Última línea: «== PR-5 traces-resolve: ROJO (errores=1446 avisos=0) trazas=1921 resueltas=1081 ids-duplicados=606». Reglas: 606 `id-duplicado`, 704 `traza-ambigua`, 134 `traza-no-resuelve`, 2 `traza-mal-formada`. Por prefijo del ID duplicado: ESC 465, ACT 29, AG 26, MARCO 16, US 15, CTX 15, ANEXO 10, GF 6, E2E 4, AIP 4, MAPA 3, GUIA 3, RN 2, GHF 2, GHA 2, FAM 2, ADR 2 |
| Versión declarada dos veces | `grep -rlE '^version:' --include='*.md' . \| xargs -r grep -l 'Versión:\*\*'` (2) | 0 | `salida/_trabajo/inv-2-version.txt`: única salida «grep: ./Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion: Permission denied»; rc=123 (ningún archivo con las dos marcas en lo legible) |
| Estado «planificado» o equivalente | `grep -rniE -e planificad -e previst -e 'a implementar' -e TODO docs/tecnica` (3), con `{carpeta-tecnica}` = `docs/tecnica`, la ubicación por defecto de CL-07 (§2.1) | 0 | `salida/_trabajo/inv-3-planificado.txt`: «grep: docs/tecnica: No such file or directory», rc=2. CL-07 no está activa (§3) |
| Traza de la interfaz a una unidad que no le corresponde | (4) no se corrió: no hay `{carpeta-ayuda}`. Búsqueda: `find . -type d \| grep -iE 'ayuda\|help\|tecnic\|docs$'` | 0 | La búsqueda devolvió sólo `./Guides/Documentacion-Tecnica` y sus subcarpetas, `./tools/docs-guard/fixtures/esquema-ayuda` (fixture de la compuerta) y `./Guides/Metodologia-Entorno-Desarrollo/Examples/A-plantillas/repo/docs` (ejemplo de una guía). Ninguna es ayuda al usuario final; CL-06 no está activa (§3). Lo que haya en `SDEI`: pendiente (Q-1) |
| Puntero a un documento obsoleto o ausente | `grep -niE -e obsolet -e retirad -e elimin -e renombr CHANGELOG.md` (5); cada ruta nombrada, contra el árbol con `find` y `ls` | 2 punteros | `salida/_trabajo/inv-5-changelog.txt` (8 líneas). `CHANGELOG.md:160` declara `obsoleto` a `Sistema-Documentador-Tecnico-Guide.md` (`DOC-SDT-0001`); `find . -name 'Sistema-Documentador-Tecnico-Guide*'` no da salida en lo legible. Lo trazan `README.md:11` y `Guides/README.md:11` (`traces: [… DOC-SDT-0001]`), y el control 1 da `traza-no-resuelve` en los dos. Las demás rutas nombradas existen (`tools/docs-guard/fixtures/url-fecha/obsoleto/a.md`, `README.md`, `Guides/README.md`) o están eliminadas y no se citan (`CHANGELOG.md:533-535`: `ls Guides` no muestra `references/`) |
| Advertencia del índice del proyecto (pasa a reserva) | Lectura de `README.md` (índice raíz, `doc_type: indice`, `README.md:3`) y `Guides/README.md` (`Guides/README.md:3`) | 0 advertencias en los índices; 3 reservas | Los dos índices no traen advertencias. Reservas: R-1, la deuda declarada «el trabajo de CI con `--fuente` queda como deuda» (`CHANGELOG.md:14`); R-2, «deuda: A1 sin programar» (`CHANGELOG.md:15`); R-3, la excepción de AI-3 de `AGENTS.md` tiene huella vencida: `tools/docs-guard/excepciones.txt:7` declara `f12ab882…2cc5` y `sha256sum AGENTS.md` da `26d0e20c…0e92`, así que AI-3 vuelve a avisar en `AGENTS.md:17` (`salida/_trabajo/base/ai.punteros.txt`). El índice para agentes (CL-08, repo hermano) no se recibió: pendiente (Q-5) |
| Espacios de IDs en uso, con su origen (D-07) | `python3 -I -B salida/_trabajo/scripts/espacios.py tools/docs-guard/dg.py .` (usa `registro()` y `prefijos()` de `tools/docs-guard/dg.py:537-546`, `tools/docs-guard/dg.py:261-266`) | 33 prefijos, 263 IDs; 18 prefijos fuera del registro | `salida/_trabajo/inv-7-espacios.tsv`. En el registro (`tools/docs-guard/prefijos.txt:8-40`): ACT, ADR, ARQ, CTX, DOC, ESC, FAM, FC, IDX, MAPA, MARCO, MET, RF, RN, TEM. Fuera del registro (heredados, a A-08): AG, AIP, ANALISIS, ANEXO, CUADERNO, D, E2E, EP, F, G, GF, GHA, GHF, GUIA, GUIAS, LAB, N, US. Origen: `doc_id` y encabezados de `Guides/`, `Concepts/` y los punteros de la raíz. Los IDs del cuerpo `SDEI` (`IDX-SDEI`, `MARCO-SDEI`, `RD-nn`…) no se pudieron listar: pendiente (Q-1) |

## 2. Decisiones

| Id | Pregunta | Valor | Evidencia (ruta:línea en el SHA leído, o «pendiente: qué falta») | Clase (P o H) | Si es H: opciones y default para la persona |
| --- | --- | --- | --- | --- | --- |
| D-01 | ¿Escenario y contextos? | **Corpus de guías.** Audiencias del corpus (estudiante, docente, agente). La demo compilable de Framework Concept ilustra una guía, así que su documentación es CL-10 (DK-14) y no abre el escenario «app sin roles». Roles con permisos distintos: no aplica a un corpus (no hay autorización que inventariar en la documentación) | `README.md:16-17` («Repositorio de guías de estudio…»); `AGENTS.md:45-46`; `CHANGELOG.md:336` («la demo compilable que ilustra la guía») | P | — |
| D-01 · sitio | ¿Hay sitio publicado? | No | `AGENTS.md:45-46` («…leídas en GitHub, sin sitio publicado») | P (la decisión es D-03, H) | Ver D-03 |
| D-01 · marco | ¿Hay marco de especificación? | No hay marco de especificación externo; el registro de IDs es propio (`doc_id` y encabezados, más el registro cerrado de prefijos) | `tools/docs-guard/prefijos.txt:1-5`; `tools/docs-guard/README.md:87`. Búsqueda negativa: `find . -maxdepth 3 -type d` sin carpetas de un marco (salida en el inventario de árbol: `Concepts`, `Guides`, `scripts`, `tools`, `.github`) | P | — |
| D-01 · topología | ¿Mismo repo, hermano o dedicado? | Mismo repo para el corpus, la compuerta y README/CHANGELOG; repo hermano `Lab-Documentos.Documentacion` para expedientes (y, por defecto, el índice para agentes) | `tools/docs-guard/arbol.tsv:8`; `CHANGELOG.md:34` (folio del expediente 0003 «en» el hermano); `CHANGELOG.md:342` | P | — |
| D-01 · organización | ¿Dentro o fuera de la organización del runner (medido)? | **pendiente: organización** | Sin `.git` no hay remoto `origin` que medir (Q-2). Líneas `uses:` de los workflows: sólo `actions/checkout` (`.github/workflows/docs-guard.yml:68`, `.github/workflows/docs-guard.yml:73`); el workflow toma sus herramientas de `{organizacion}/Lab-Documentos` (`.github/workflows/docs-guard.yml:75`), que es este mismo repositorio por nombre, pero la organización del runner `[self-hosted, {etiqueta-runner}]` (`.github/workflows/docs-guard.yml:60`) no se puede medir sin la API | P | — |
| D-02 | ¿Qué clases de pieza se activan? | Fila «corpus de guías» con altas: CL-01 (sólo A-01), CL-02, CL-03, **CL-04 (alta)**, **CL-05 (alta)**, CL-08, CL-09, CL-10, CL-12, CL-13. CL-11: pendiente. Bajas: CL-06, CL-07, CL-14 | Detalle y evidencia por clase en §3 | P | — |
| D-03 | ¿Hay sitio publicado? | No (estado medido; default) | `AGENTS.md:45-46` | H | Opciones: Sí (activa CL-14 y el build del sitio entra a la compuerta) · No. Default: No |
| D-04 | ¿Hay marco de especificación con registro de IDs? | **No: registro propio** (`doc_id` del corpus, `tools/docs-guard/prefijos.txt`). Sobre la raíz entera el registro **no resuelve** según el criterio de D-04: 56 IDs se declaran más de una vez. Sobre la RUTA por defecto de la compuerta (el cuerpo `SDEI`) el proyecto declara línea de base 0, que no se pudo comprobar (Q-1) | Inventario, patrón 1 (`salida/_trabajo/inv-1-trazas.txt`); `tools/docs-guard/README.md:150`; `scripts/ci-local.sh:35` | P | — |
| D-05 | ¿Dónde vive cada pieza? | Mismo repo: CL-01 (A-01), CL-02, CL-03, CL-04, CL-05, CL-10, CL-12, CL-13. Repo hermano: CL-08, CL-09. Build: CL-04 y CL-05 como generación (apagada hoy). Ubicaciones por clase en §3 | I-20: ninguna pieza del corpus la emite el build salvo CL-04/CL-05; el corpus cambia en el mismo PR que la compuerta (`.github/workflows/docs-guard.yml:72-81`); los expedientes hablan del proyecto, no del producto (`CHANGELOG.md:34`) | P | — |
| D-06 | ¿Contra qué ancla vale cada pieza? | Commit para todo lo que vive en el repo. Líneas de versión: cuerpo `SDEI` 2.0 con etiqueta `sdei-v2.0.0-borrador` (`CHANGELOG.md:36` delega su creación; su existencia: pendiente, Q-2); Framework Concept v1.0.0 (`CHANGELOG.md:331`): etiqueta pendiente (Q-2). Lo que vive en el hermano (CL-08, CL-09): SHA fijado, pendiente (Q-5) | `CHANGELOG.md:36`; `CHANGELOG.md:331`. Sin `.git` no se pueden listar etiquetas | P | — |
| D-07 | ¿Qué prefijos e IDs? | Registro del proyecto = `tools/docs-guard/prefijos.txt` (ámbitos `interno`/`externo`), que es también el registro de la compuerta de origen (ver D-09 y §6). La adopción **no agrega prefijos**: A-01 usa `ANX` (interno) con `ANX-LABDOC-FICHA-DISENO`, sin aparición previa en lo legible (`grep -rn 'ANX-LABDOC' .` → sólo «Permission denied» sobre `SDEI`, rc=2). 18 prefijos heredados fuera del registro: se cuentan en A-08 y van a un saneamiento aparte (P). Unicidad frente al cuerpo `SDEI`: pendiente (Q-1) | `tools/docs-guard/prefijos.txt:17`; inventario, espacios de IDs; tabla P/H del proyecto: un prefijo nuevo es P (`AGENTS.md:105`) | P | — |
| D-08 | ¿Qué esquema de frontmatter? | El existente: diez campos más `description`, con vocabulario cerrado de `doc_type` y `audience`; lo heredado avisa y el cuerpo nuevo (README con `corpus_id`) bloquea | `tools/docs-guard/esquemas/cuerpo.schema.json:7`, `tools/docs-guard/esquemas/cuerpo.schema.json:10`, `tools/docs-guard/esquemas/cuerpo.schema.json:18`; `tools/docs-guard/README.md:31` | P | — |
| D-09 | ¿Cómo corre la compuerta? | Estado medido: la compuerta de origen corre **en su propio repositorio**: el job toma `scripts/` y `tools/docs-guard/` del mismo repo al SHA del evento y corre `scripts/ci-local.sh` por grupo en `[self-hosted, {etiqueta-runner}]` (Linux). No hay pieza D de iOS. Decisión: de una persona | `.github/workflows/docs-guard.yml:60`, `.github/workflows/docs-guard.yml:72-81`, `.github/workflows/docs-guard.yml:83-128`; `.github/workflows/framework-concept-demo.yml:159` (sólo APK Android) | H | Opciones: (a) mantener la compuerta de origen en su repositorio, como corre hoy · (b) copia con huella en una carpeta propia (default literal del conocimiento, que aquí sería copiar la compuerta dentro de su propio repo) · (c) workflow reutilizable. Default propuesto: (a), porque el proyecto **es** el repositorio de origen; el default literal (b) no aplica sin duplicar el guion (§6) |
| D-10 | ¿Qué controles bloquean y cuáles avisan, en qué carpeta? | Manda la tabla del proyecto (`tools/docs-guard/README.md:148-157`). Línea de base medida (A-08): en `Guides/` y `Concepts/` (heredado) dan rojo `esquema`, `ai` y `trazas`, así que ahí **avisan**; `fuera`, `mermaid-arroba`, `contratos`, `fijadas`, `reflint` y `url-fecha` dan 0 errores. Carpeta nueva `docs/_diseno/` (A-01): bloquea con los controles de la compuerta. RUTA por defecto (`SDEI`): pendiente (Q-1). Si la plataforma vuelve obligatorio el check: pendiente (Q-4); mientras no se afirme, por §2.4 todo queda en «avisa» y la defensa es la revisión del PR | `tools/docs-guard/README.md:148-157`; `scripts/ci-local.sh:35`; salidas en `salida/_trabajo/base/` | P | — |
| D-11 | ¿Quién decide qué? | Mapa medido de delegaciones del merge: (1) expediente 0003 de DocsAsCode en este repo, con la etiqueta `sdei-v2.0.0-borrador`; (2) expediente 0002 de DocAsCode en este repo; (3) expediente 0001 de Framework Concept en este repo y en el hermano. Guarda G1–G4 en las tres. Lo que no cae en ninguna lo fusiona una persona (el PO). Clase H del proyecto: `AGENTS.md:102-107` | `CHANGELOG.md:32-39`; `CHANGELOG.md:320-327`; `CHANGELOG.md:340-346`; `AGENTS.md:54` | H | Opciones: el mapa medido · una delegación nueva para la adopción, asentada por escrito · sin delegación (fusiona el PO). Default propuesto: el mapa medido; el PR de adopción no cae en ningún alcance, así que lo fusiona una persona |
| D-12 | ¿Qué canales hay para agentes? | `AGENTS.md` puntero (existe); índice para agentes en el hermano (CL-08): pendiente (Q-5). Sin canales derivados (no hay sitio) | `AGENTS.md:17-19`; `AGENTS.md:45-46` | H | Opciones: `AGENTS.md` puntero · índice para agentes · canales derivados (sólo con sitio). Default: `AGENTS.md` puntero (el existente) |
| D-13 | ¿Cómo es la ayuda al usuario final? | **Ninguna.** Se descarta el default («única» si D-01 no da roles) porque el escenario corpus no activa CL-06 y no hay carpeta de ayuda | §2.3 (fila corpus, CL-06 fuera); inventario, patrón 4 (`find`) | P | — |
| D-14 | ¿Qué es privado y cómo se nombra? | Alias por destino privado más barrido por lista. El proyecto ya fija la regla (`AGENTS.md:109-110`, con el alias **SDD-B**). Visibilidad: público según la declaración del propio proyecto (`tools/docs-guard/arbol.tsv:2-4`, `tools/docs-guard/arbol.tsv:7`); sin respuesta de la API (sin red): pendiente (Q-4). Inventario de destinos privados por comando, sólo cifras: 121 apariciones de una IPv4 distinta de 0.0.0.0 y 127.0.0.1, 52 rutas `/home/…` o `/Users/…`, 33 archivos con el nombre del host del runner (comandos en `salida/_trabajo/inv-privado.txt`). `{lista-privada}`: pendiente (Q-3) | `AGENTS.md:109-110`; `tools/docs-guard/arbol.tsv:2-4` | P | — |
| D-15 | ¿Hay un cuerpo formativo? | Sí. Perfil de guía de estudio: el del proyecto, «Guía de estudio — Documentación técnica» | `README.md:16-17`; `README.md:28-29` | P | — |
| D-16 | ¿Idioma y estilo? | Castellano; CHANGELOG en formato Keep a Changelog. No se traducen: los nombres de campo del frontmatter (`doc_id`, `doc_type`, `title`, `status`, `origin`, `owner`, `last_review`, `audience`, `traces`, `description`) y los términos de patrón en inglés del código de los ejemplos | `README.md:16-17`; `CHANGELOG.md:3`; `tools/docs-guard/esquemas/cuerpo.schema.json:7`; `CHANGELOG.md:526` | P | — |
| D-17 | ¿Cómo es el carril programado? | Existe: semanal (lunes 06:17 UTC) y a mano; frescura de 365 días; vigila el árbol del workspace, enlaces entre repos y externos, atraso de `base_commit` y `source.lock`, deriva de piezas fijadas, frescura y línea de base de AI-3; modo: sólo avisa, con un único issue | `.github/workflows/docs-enlaces-semanal.yml:16-19`; `.github/workflows/docs-enlaces-semanal.yml:3-6`; `.github/workflows/docs-enlaces-semanal.yml:74-97`; `tools/docs-guard/README.md:194-199` | P | — |

## 3. Catálogo activo

| Clase | Activa (sí o no) | Alta o baja frente al escenario, con motivo | Dónde vive (todas las ubicaciones) | Ancla | Evidencia |
| --- | --- | --- | --- | --- | --- |
| CL-01 | Sí, sólo por A-01 | Igual a la fila (DK-14): no hay especificación de producto | `docs/_diseno/ficha-diseno-documental.md` (A-01, propuesta) | Commit y versión del ID | `tools/docs-guard/prefijos.txt:17` (prefijo `ANX`) |
| CL-02 | Sí | Igual a la fila. Hay un RRD propio en el cuerpo `SDEI` (filas `RD-21` a `RD-27`); su ruta exacta: pendiente (Q-1) | Cuerpo `SDEI`, ruta pendiente (Q-1) | Commit | `CHANGELOG.md:14`; `tools/docs-guard/prefijos.txt:27` |
| CL-03 | Sí | Igual a la fila | `AGENTS.md` (raíz; un solo repo recibido). Ubicación sujeta a D-12 (H) | Commit | `AGENTS.md:15-19` |
| CL-04 | Sí, control «pendiente» | **Alta** (DK-13): fuente presente con generación apagada. Línea de base: 152 archivos `.cs` con comentarios `///` y ningún `GenerateDocumentationFile` | Código de la demo, `Concepts/Framework-Concept/Demo/` | Commit | `grep -rlE '^\s*///' --include='*.cs' Concepts \| wc -l` → 152; `grep -rn 'GenerateDocumentationFile\|DocumentationFile' --include='*.props' --include='*.csproj' Concepts` → sin salida, rc=1 |
| CL-05 | Sí, control «pendiente» | **Alta** (DK-13): el receptor de prueba de la demo expone endpoints REST sin contrato emitido ni paso que lo extraiga. Línea de base: sin extracción | Build de la demo; un paso de la CI tendría que levantar el receptor y extraer el contrato | Commit | `Concepts/Framework-Concept/Demo/tools/FrameworkConcept.Receptor/Program.cs:32`; `find . -name 'openapi*.json'` → sólo fixtures de `tools/docs-guard/fixtures/` |
| CL-06 | No | Igual a la fila (baja): no hay ayuda al usuario final | — | — | Inventario, patrón 4 |
| CL-07 | No | Igual a la fila (baja): la documentación escrita de la demo es CL-10 (DK-14) | — | — | `CHANGELOG.md:336`; inventario, patrón 3 |
| CL-08 | Sí | Igual a la fila. Repo hermano no recibido: ubicación como evidencia secundaria declarada (DK-15) | Repo hermano `Lab-Documentos.Documentacion` (rotulado: evidencia secundaria; existencia del índice pendiente, Q-5) | SHA fijado y etiqueta: pendiente (Q-5) | `tools/docs-guard/arbol.tsv:8` |
| CL-09 | Sí | Igual a la fila | Repo hermano `Lab-Documentos.Documentacion` (evidencia secundaria) | Commit del hermano; desde este repo, SHA fijado: pendiente (Q-5) | `CHANGELOG.md:34`; `CHANGELOG.md:342` |
| CL-10 | Sí | Igual a la fila | `Guides/` (guías por categoría) y `Concepts/Framework-Concept/` (guía, libro y demo) | Versión del cuerpo y etiqueta (`sdei-v2.0.0-borrador`; las demás: pendiente, Q-2) | `README.md:16-17`; `Guides/README.md:21-31`; `CHANGELOG.md:331-336`; `CHANGELOG.md:36` |
| CL-11 | Pendiente | La fila la activa. En lo legible no hay copia con huella: `BASE-FIJADA.md` sólo aparece en fixtures, y `Concepts/Framework-Concept/Conocimientos/` es conocimiento propio, no copiado. El cuerpo `SDEI` no se leyó (Q-1) | — | Versión y SHA-256 | `find . -name 'BASE-FIJADA.md'` → `tools/docs-guard/fixtures/fijadas/{rojo,verde}/Knowledges/BASE-FIJADA.md`; `Concepts/Framework-Concept/Conocimientos/README.md:3-6` |
| CL-12 | Sí | Igual a la fila. Hay una instancia de «Cómo intervenir» en el cuerpo `SDEI`; ruta pendiente (Q-1). Ubicación sujeta a una persona (CL-12 es H) | Cuerpo `SDEI` | Versión de la plantilla: pendiente (Q-1) | `README.md:30-31`; `CHANGELOG.md:17` |
| CL-13 | Sí | Igual a la fila | `README.md`, `CHANGELOG.md` (raíz) | Fecha (entradas del CHANGELOG por fecha) | `README.md:14`; `CHANGELOG.md:3`; `CHANGELOG.md:6` |
| CL-14 | No | Igual a la fila (baja): sin sitio publicado | — | — | `AGENTS.md:45-46` |

## 4. Decisiones de clase H para una persona

| Id | Opciones | Default propuesto | Quién decide |
| --- | --- | --- | --- |
| D-03 | Sí · No | No | Responsable del producto (PO) |
| D-09 | (a) compuerta de origen en su repo · (b) copia con huella · (c) workflow reutilizable | (a) | PO |
| D-11 | Mapa medido · delegación nueva para la adopción · sin delegación | Mapa medido; el PR de adopción lo fusiona una persona | PO |
| D-12 | `AGENTS.md` puntero · índice para agentes · canales derivados | `AGENTS.md` puntero (el existente) | PO |
| Pasar A-01 a `vigente` (acción H de la tabla P/H, `AGENTS.md:104`) | Dejar en `borrador` · pasar a `vigente` | Dejar en `borrador` hasta la revisión de una persona | PO |

## 5. Artefactos A-02 a A-11

| Id | Producido (sí o no) | Ruta | Motivo si no se produce | Propuesta sujeta a (D-nn), si depende de una H abierta |
| --- | --- | --- | --- | --- |
| A-02 | No | `tools/docs-guard/prefijos.txt` (instancia existente) | Existe y la adopción no agrega prefijos (DK-09: no se duplica) | D-09 |
| A-03 | No | `tools/docs-guard/esquemas/cuerpo.schema.json` (instancia existente) | Existe; A-01 usa valores del vocabulario vigente (`ficha`; `humano`, `agente`, `po`) | D-09 |
| A-04 | No | — | La instancia existente está en el cuerpo `SDEI`, no legible; un RRD nuevo no puede elegir un rango `RD-nn` libre sin leerlo (pendiente, Q-1) | — |
| A-05 | No | `AGENTS.md` (instancia existente) | Existe y es un puntero (`AGENTS.md:17-19`); cambiarlo es H (`AGENTS.md:139`) | D-12 |
| A-06 | No | — | La instancia existente está en el cuerpo `SDEI`, no legible (pendiente, Q-1) | — |
| A-07 | No | `.github/workflows/docs-guard.yml`, `scripts/ci-local.sh` (instancias existentes) | Existen y corren el mismo guion en la CI y en local | D-09 |
| A-08 | Sí | `salida/pr-adopcion/descripcion.md` (descripción del PR de adopción; no va al árbol del repo). Archivo de excepciones: existente, `tools/docs-guard/excepciones.txt`, no se produce uno vacío | — | — |
| A-09 | No | — | Las piezas de fuera viven en el hermano, que no se recibió: falta el SHA de este repo y el árbol del hermano (pendiente, Q-2 y Q-5) | — |
| A-10 | No | `.github/workflows/docs-enlaces-semanal.yml` (instancia existente) | Existe y declara frecuencia, frescura, qué vigila y modo (D-17) | — |
| A-11 | Sí, parcial | `salida/CHANGELOG.entrada.md` (entrada del CHANGELOG y su punto de inserción). Entrada del índice para agentes: pendiente (Q-5) | Índice del hermano no recibido | — |

## 6. Lo que el conocimiento no resolvió

| Sección o decisión | Cita textual de lo que no resuelve | Qué quedó sin hacer |
| --- | --- | --- |
| §5.6 y §5.7, D-09 | `DocsAsCode-Designing-Specification §5.6` no resuelve: «No se agregan prefijos del proyecto al registro de origen ni se usa el de origen como registro del proyecto», cuando el proyecto **es** el repositorio de la compuerta de origen | No se armó `{copia-proyecto}` dentro del repo: A-02 y A-03 quedan en las instancias existentes, sujetas a D-09 |
| §3.1, comando 4 | `DocsAsCode-Designing-Specification §3.1` no resuelve: el valor de `{carpeta-ayuda}` cuando el proyecto no tiene ayuda al usuario final | El comando 4 no se corrió; la cuenta 0 sale de la búsqueda con `find` |
| §2.1, DK-13 frente a DK-14 | `DocsAsCode-Designing-Specification §2.1` no resuelve si la fuente de una clase D que vive en la demo de una guía (CL-10) da de alta CL-04 y CL-05 en un corpus | Se aplicó la letra de DK-13 (alta con control pendiente); queda a revisión |
| §6, DE-14 | `DocsAsCode-Designing-Specification §6`, DE-14, no resuelve cómo correr el par rojo/verde completo sin red, si las herramientas de PR-1 y PR-4 se bajan de internet (`scripts/ci-local.sh:64-83`) | Los grupos que usan lychee, markdownlint-cli2 y mermaid quedan sin correr (§7) |

Suposiciones: ninguna.

## 7. Verificación (§6)

| Comprobación | Comando | Resultado (salida textual) |
| --- | --- | --- |
| Compuerta sobre los artefactos, con A-02 y A-03 (copia de §5.7 y su huella) | pendiente de esta ronda | pendiente |
| Par rojo/verde plantado, con la compuerta de D-09 | pendiente de esta ronda | pendiente |
| Autoprueba de la compuerta de origen | pendiente de esta ronda | pendiente |
| Chequeo de citas ruta:línea (§3.5; cada cita repite el archivo, sin `:n` sueltas) | pendiente de esta ronda | pendiente |
| Barrido por `{lista-privada}` (§3.6) | pendiente (Q-3) | pendiente: sin `{lista-privada}` |
