---
doc_id: ANX-LD-FICHA-DISENO
doc_type: ficha
title: Ficha de diseño documental de LD
description: Ficha A-01 de la adopción del conocimiento de diseño documental en LD; propuesta en borrador.
status: borrador
origin: ia-generated
confidence: media
owner: aplicador C0-r2
last_review: 2026-11-01
audience: [humano, agente]
traces: [ANX-LD-FICHA-DISENO, ANX-LD-NO-EXISTE]
---

# Ficha de diseño documental — LD (`repo/LD`)

Todas las citas `ruta:línea` son relativas a la raíz de `repo/LD`. Lo privado va por alias (§3.6 del conocimiento):
`{organizacion}` es el dueño que nombran `.github/workflows/docs-guard.yml:75` y `tools/docs-guard/arbol.tsv:7`;
`{etiqueta-runner}` es la etiqueta de `.github/workflows/docs-guard.yml:60`. Las salidas de comandos guardadas viven en
`salida/inventario/` y `salida/verificacion/` (se nombran sin número de línea).

| Campo | Valor |
| --- | --- |
| Proyecto y repositorios leídos, con SHA (sin `.git`: «SHA: pendiente» y huella del árbol, §3.1) | Un repositorio, `repo/LD` (portada «Lab-Documentos», `README.md:14`). **SHA: pendiente** (sin `.git`; demanda Q-1 contestada «no disponible»). Huella del árbol, con el comando de §3.1 corrido desde `repo/LD`: `117ee288a52bebf72be5c7c313b985c2ab357ab4eff5729d3701d4ea37e73a62`. La carpeta `Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/` da «Permiso denegado» y queda fuera de la huella y de toda lectura (Q-3 «no disponible») |
| Fecha | 2026-11-01 |
| Quién aplica | Agente aplicador (corrida C0-r2), sin contexto previo |
| Conocimiento aplicado (alias, versión, huella) | `DocsAsCode-Designing-Specification` 1.1; `sha256sum conocimiento.md` = `afd741b838ae2bf457f6d2a6143a079d1d65ee76f1ab55d134f560f7165483e8` |

## 1. Inventario (paso 1)

`{compuerta}` = `tools/docs-guard/` **del propio repo leído**: es la compuerta que el workflow del proyecto toma de su
mismo commit (`.github/workflows/docs-guard.yml:72-81`, `ref: github.sha`). Que sea `Lab-Documentos@{sha}` de §8 queda
pendiente (Q-2 «no disponible»). Árbol: 374 `.md` legibles, 264 con frontmatter y 110 sin él; cuatro workflows, todos con
`runs-on: [self-hosted, {etiqueta-runner}]` (salida en `salida/inventario/0-arbol.txt`).

| Patrón de §3.1 | Comando | Cuenta | Salida o ruta a la salida |
| --- | --- | --- | --- |
| ID declarado más de una vez | `python3 {compuerta}/dg.py trazas --raiz . .` (corrido como `python3 -I tools/docs-guard/dg.py trazas --raiz . .`) | 606 líneas `id-duplicado` (56 IDs distintos duplicados de 263 declarados) | `== PR-5 traces-resolve: ROJO (errores=1446 avisos=0) trazas=1921 resueltas=1081 ids-duplicados=606`, rc=1; completa en `salida/inventario/1-trazas.txt`; por prefijo en `salida/inventario/D-07-espacios-de-ids.txt`. Ej.: `ESC-1` en `Concepts/Framework-Concept/00-Marco.md:94` y 115 lugares más |
| Versión declarada dos veces | `grep -rlE '^version:' --include='*.md' . \| xargs -r grep -l 'Versión:\*\*'` | 0 | Sin salida; rc=123 (xargs: el segundo grep no halló). 15 archivos tienen `version:`, todos sin `**Versión:**` |
| Estado «planificado» o equivalente | `grep -rniE -e planificad -e previst -e 'a implementar' -e TODO {carpeta-tecnica}` | 0 (no aplica) | No hay `{carpeta-tecnica}` (CL-07): `find . \( -path "*docs/tecnica*" -o -iname "*ayuda*" -o -iname "help" \) -not -path "./tools/docs-guard/fixtures/*"` devuelve sólo `./tools/docs-guard/esquemas/ayuda.schema.json` (`salida/inventario/3-4-carpetas-y-roles.txt`) |
| Traza de la interfaz a una unidad que no le corresponde | `grep -rn '^traces:' {carpeta-ayuda}` | 0 (no aplica en el árbol legible) | Mismo `find`: no hay `{carpeta-ayuda}` legible. El CHANGELOG nombra páginas de ayuda dentro del cuerpo ilegible (`CHANGELOG.md:14`, `CHANGELOG.md:362`): no se pudieron contrastar (Q-3) |
| Puntero a un documento obsoleto o ausente | `grep -niE -e obsolet -e retirad -e elimin -e renombr CHANGELOG.md` | 1 puntero vivo a un obsoleto | 7 líneas (`salida/inventario/5-changelog.txt`). `CHANGELOG.md:160` declara obsoleto `DOC-SDT-0001`; lo siguen trazando `README.md:11` y `Guides/README.md:11`; el archivo no está en el árbol legible (`dg.py trazas`: `traza-no-resuelve: DOC-SDT-0001`) |
| Advertencia del índice del proyecto (pasa a reserva) | Lectura del índice | pendiente | El índice del proyecto es el README del cuerpo (`AGENTS.md:62-63`), dentro de la carpeta con «Permiso denegado». Pendiente: Q-3 |
| Espacios de IDs en uso, con su origen (D-07) | `python3 -I salida/inventario/espacios_ids.py` sobre la salida de `dg.py trazas` y `tools/docs-guard/prefijos.txt` | 35 prefijos en uso: 17 del registro, 18 fuera de él | `salida/inventario/D-07-espacios-de-ids.txt`. Origen: registro `tools/docs-guard/prefijos.txt:8-40`; expedientes del hermano `.Documentacion` (`CHANGELOG.md:34`): no leídos (Q-6); marco de especificación: ninguno hallado (D-01 · marco). `RD` en uso en el árbol legible: ninguno; `RD-21` a `RD-27` nombrados en `CHANGELOG.md:14` dentro del cuerpo ilegible |

## 2. Decisiones

| Id | Pregunta | Valor | Evidencia (ruta:línea en el SHA leído, o «pendiente: qué falta») | Clase (P o H) | Si es H: opciones y default para la persona |
| --- | --- | --- | --- | --- | --- |
| D-01 | ¿Escenario y contextos? | Corpus de guías (incluye la guía de estudio del Framework Concept con su demo, que entra por CL-10). Sin roles con permisos distintos | `README.md:16-17`; `AGENTS.md:45-46`; `CHANGELOG.md:335`. Inventario de autorización: `grep -rnE "\[Authorize\|AddAuthorization\|RequireRole\|IsInRole\|AddPolicy\|RequireClaim" --include=*.cs --include=*.razor .` da una sola política, `RequireAuthenticatedUser().RequireClaim("sub")` en `Concepts/Framework-Concept/Demo/tools/FrameworkConcept.Receptor/AutenticacionDelReceptor.cs:69-70` | P | — |
| D-01 · sitio | ¿Hay sitio publicado? | No | `AGENTS.md:45-46` («sin sitio publicado») | P (ver D-03) | — |
| D-01 · marco | ¿Hay marco de especificación? | No hallado; registro propio por `doc_id` y encabezados, con prefijos cerrados | `tools/docs-guard/prefijos.txt:1-5`; `.github/workflows/docs-guard.yml:11-12`. La parte del cuerpo `SDEI` no se leyó (Q-3) | P | — |
| D-01 · topología | ¿Mismo repo, hermano o dedicado? | Mismo repo más el hermano `.Documentacion` | `CHANGELOG.md:34`; `CHANGELOG.md:322`; `CHANGELOG.md:342`; `tools/docs-guard/arbol.tsv:7-8` | P | — |
| D-01 · organización | ¿Dentro o fuera de la organización del runner (medido)? | pendiente: organización | Sin `.git` no hay remoto `origin` (Q-1 «no disponible»). Indicios no medidos: `.github/workflows/docs-guard.yml:75` hace checkout de `{organizacion}/Lab-Documentos` y `tools/docs-guard/arbol.tsv:3-4` lo lista entre los repos «de la organización del runner» | P | — |
| D-02 | ¿Qué clases de pieza se activan? | CL-01 (sólo por A-01), CL-02, CL-03, CL-08, CL-09, CL-10, CL-11, CL-12, CL-13. Bajas frente a la fila: ninguna confirmada; CL-11 queda activa por la fila con su evidencia pendiente | Fila «Corpus de guías» de §2.3; detalle por clase en §3 | P | — |
| D-03 | ¿Hay sitio publicado? | No | `AGENTS.md:45-46` | H | Opciones: No · Sí (activa CL-14 y suma el build del sitio a la compuerta). Default: No, que es lo medido |
| D-04 | ¿Hay marco de especificación con registro de IDs? | No: registro propio (`doc_id` y encabezados más `prefijos.txt`). El registro **no resuelve** hoy en el sentido de §3.2: hay IDs declarados más de una vez | `tools/docs-guard/prefijos.txt:1-5`; 56 IDs duplicados (§1, patrón 1) | P | — |
| D-05 | ¿Dónde vive cada pieza? | Mismo repo: CL-02, CL-03, CL-10, CL-12, CL-13 y A-01. Repo hermano `.Documentacion`: CL-08 y CL-09 | `AGENTS.md:45-53`; `CHANGELOG.md:34`; `CHANGELOG.md:342`; `tools/docs-guard/arbol.tsv:8`. Ubicación dentro del hermano: pendiente (Q-6) | P | — |
| D-06 | ¿Contra qué ancla vale cada pieza? | Lo del mismo repo: commit. CL-10: versión del cuerpo y etiqueta (hay una etiqueta de archivo nombrada, `sdei-v2.0.0-borrador`). CL-08 y CL-09 en el hermano: SHA fijado, pendiente de comprobar. Líneas de versión vivas: pendiente | `CHANGELOG.md:36`; `tools/docs-guard/README.md:196`. Sin `.git` no se listan etiquetas ni líneas de versión (Q-1) | P | — |
| D-07 | ¿Qué prefijos e IDs? | Registro existente `tools/docs-guard/prefijos.txt` (interno y externo). 18 prefijos heredados fuera del registro y 56 IDs duplicados: se cuentan en A-08 y van a un saneamiento aparte (P). No se fijan IDs nuevos en el repo | `tools/docs-guard/prefijos.txt:8-40`; `salida/inventario/D-07-espacios-de-ids.txt`; `AGENTS.md:105` (un prefijo nuevo es P) | P | — |
| D-08 | ¿Qué esquema de frontmatter? | Mapeo al existente: diez campos más `description`, vocabulario cerrado de `doc_type` y `audience` | `tools/docs-guard/esquemas/cuerpo.schema.json:7-19` | P | — |
| D-09 | ¿Cómo corre la compuerta? | Existente: el repo corre su propio guion (`scripts/ci-local.sh` y `tools/docs-guard/`) tomado de su mismo commit, en runner propio con `{etiqueta-runner}`; además se ofrece como reutilizable | `.github/workflows/docs-guard.yml:32-48`; `.github/workflows/docs-guard.yml:60`; `.github/workflows/docs-guard.yml:72-81`. Organización: pendiente (D-01 · organización) | H | Opciones: (a) mantener la existente (el guion del propio repo en su commit); (b) copia con huella en `{copia-proyecto}` más `{copia-origen}` (§5.7); (c) llamar al reutilizable. Default propuesto: (a). Motivo: el repo leído es la casa de la compuerta y (b) sería copiarse a sí mismo; el conocimiento no prevé el caso (§6) |
| D-10 | ¿Qué controles bloquean y cuáles avisan, en qué carpeta? | Manda la tabla existente (`tools/docs-guard/README.md:148-157`) sobre la RUTA por defecto. En lo heredado (`Guides/`, `Concepts/`) todo avisa: la línea de base no es 0 (esquema 309 y 16, ai 824 y 108, trazas 1404 y 4). Línea de base de la RUTA por defecto: pendiente (carpeta ilegible). Si la plataforma vuelve obligatorio el check: pendiente | `tools/docs-guard/README.md:148-157`; `.github/workflows/docs-guard.yml:38`; línea de base en `salida/inventario/linea-de-base/resumen.txt`. Plataforma: sólo un comentario, `.github/workflows/framework-concept-demo.yml:5` («`fw-ok` es el único check requerido de main»), no la API (Q-4) | P | — |
| D-11 | ¿Quién decide qué? | Mapa medido: tres delegaciones del merge asentadas, cada una con su alcance (expediente 0003 en este repo; expediente 0002 en este repo; expediente 0001 de Framework Concept en este repo y en el hermano). Lo que cae fuera de las tres lo fusiona una persona. Tabla P/H del proyecto: `AGENTS.md:102-107` | `CHANGELOG.md:32-39`; `CHANGELOG.md:320-327`; `CHANGELOG.md:340-346`; `AGENTS.md:102-107` | H | Opciones: mantener el mapa medido · ampliar o acotar una delegación · retirar delegaciones (fusiona una persona). Default propuesto: el mapa medido |
| D-12 | ¿Qué canales hay para agentes? | `AGENTS.md` puntero (existe) más el índice para agentes del hermano (CL-08, no leído) | `AGENTS.md:15-17`; `AGENTS.md:139`; `CHANGELOG.md:34` | H | Opciones: `AGENTS.md` puntero · puntero más índice para agentes · canales derivados (no: sin sitio). Default propuesto: puntero más índice, lo existente |
| D-13 | ¿Cómo es la ayuda al usuario final? | Ninguna en el corpus. Se aparta del default (única) porque el escenario no lleva CL-06 y no hay carpeta de ayuda legible | `find` de §1 (patrones 3 y 4) sin carpeta de ayuda; D-01 sin roles (`Concepts/Framework-Concept/Demo/tools/FrameworkConcept.Receptor/AutenticacionDelReceptor.cs:69-70`). Las páginas de ayuda de ejemplo del cuerpo (`CHANGELOG.md:14`) son material de estudio, no ayuda del producto | P | — |
| D-14 | ¿Qué es privado y cómo se nombra? | Alias por destino privado (regla del repo: rutas, IP, hosts y usuarios fuera; repo privado sólo por alias, p. ej. `SDD-B`) más barrido. Visibilidad: pendiente. Lista del barrido: pendiente | `AGENTS.md:109-110`; `tools/docs-guard/README.md:201`. Visibilidad: sólo la declaración `tools/docs-guard/arbol.tsv:3-4` («sólo repos públicos»), no configuración ni API (Q-4). `{lista-privada}`: Q-5 «no disponible». Inventario de destinos privados: `grep -rnoE "(self-hosted, [a-z0-9-]+\|/home/[a-z]+\|[0-9]+\.[0-9]+\.[0-9]+\.[0-9]+)" --include=*.yml .github` devuelve 8 coincidencias, todas `self-hosted, {etiqueta-runner}` (las líneas `runs-on` de §1 y el comentario `.github/workflows/framework-concept-demo.yml:7`); ninguna ruta `/home` ni IP | P | — |
| D-15 | ¿Hay un cuerpo formativo? | Sí. Perfil de guía de estudio: pendiente (vive en el cuerpo ilegible) | `README.md:16`; `CHANGELOG.md:335`. Perfil: Q-3 | P | — |
| D-16 | ¿Idioma y estilo? | Castellano rioplatense del proyecto. No se traducen: los nombres de campo del frontmatter y los valores de su vocabulario, los ID con prefijo, y los nombres de control (`traces-resolve`, `id-duplicado`) | `README.md:16-17`; `tools/docs-guard/esquemas/cuerpo.schema.json:7-19`; `tools/docs-guard/prefijos.txt:8-40` | P | — |
| D-17 | ¿Cómo es el carril programado? | Existente: semanal (lunes); frescura 365 días; vigila enlaces entre repos y externos, atraso de `base_commit` y `source.lock`, deriva de piezas fijadas, frescura y línea de base de AI-3; sólo avisa, con un issue | `.github/workflows/docs-enlaces-semanal.yml:3-6`; `.github/workflows/docs-enlaces-semanal.yml:17-18`; `tools/docs-guard/README.md:194-199`; `tools/docs-guard/README.md:203-205` | P | — |

## 3. Catálogo activo

| Clase | Activa (sí o no) | Alta o baja frente al escenario, con motivo | Dónde vive (todas las ubicaciones) | Ancla | Evidencia |
| --- | --- | --- | --- | --- | --- |
| CL-01 | Sí, sólo por A-01 | Igual a la fila (DK-14) | A-01 propuesta en `salida/A-01.md`; en el repo, `docs/_diseno/ficha-diseno-documental.md` (no existe) | Commit | §5 del conocimiento; `find . -type d -name docs` sin `docs/_diseno` (`salida/inventario/0-arbol.txt`) |
| CL-02 | Sí | Igual a la fila | Dentro del cuerpo `SDEI` (ilegible); ubicación exacta pendiente (Q-3) | Commit | `CHANGELOG.md:14` (RRD propio `RD-21` a `RD-27`) |
| CL-03 | Sí | Igual a la fila | `AGENTS.md` en la raíz. En el hermano: pendiente (Q-6) | Commit | `AGENTS.md:1-17` |
| CL-04 | No | Igual a la fila (no está). El código C# del árbol es material de las guías y de la demo de CL-10, sin generación de referencia | `grep -rn "GenerateDocumentationFile" --include=*.csproj --include=*.props .` sin salida | — | Comando a la izquierda |
| CL-05 | No | Igual a la fila. Dos `Program.cs` de ejemplos de guía usan OpenAPI; son ejemplos de estudio, no un contrato del proyecto | — | — | `grep -rlnE "AddOpenApi\|Swashbuckle\|MapOpenApi\|openapi.json" --include=*.cs --include=*.csproj .` devuelve `Guides/Dot-NET-Arquitectura-Guide/Examples/Dot-NET-Arquitectura-Lab/MyProject/src/Backend/MyProject.WebAPI/Program.cs` y `Guides/Dot-NET-Arquitectura-Guide/Interactive-Activities/LaEstancia/src/LaEstancia.WebAPI/Program.cs` |
| CL-06 | No | Igual a la fila: sin carpeta de ayuda (D-13) | — | — | `find` de §1, patrones 3 y 4 |
| CL-07 | No | Igual a la fila: sin `docs/tecnica/` | — | — | `find` de §1, patrón 3 |
| CL-08 | Sí | Igual a la fila | Repo hermano `.Documentacion`; ubicación interna pendiente (Q-6) | SHA fijado: pendiente de comprobar | `CHANGELOG.md:34`; `tools/docs-guard/arbol.tsv:8` |
| CL-09 | Sí | Igual a la fila | Repo hermano `.Documentacion` (expedientes y folios) | Commit del hermano | `CHANGELOG.md:34`; `CHANGELOG.md:322`; `CHANGELOG.md:342` |
| CL-10 | Sí | Igual a la fila | Mismo repo: `Guides/` y `Concepts/Framework-Concept/` (con su demo) | Versión del cuerpo y etiqueta | `README.md:16-17`; `CHANGELOG.md:335`; `CHANGELOG.md:36` |
| CL-11 | Sí, con evidencia pendiente | Igual a la fila; no se halló en el árbol legible una copia con huella de un conocimiento compartido | pendiente | Versión y SHA-256 | `find . \( -name "BASE-FIJADA.md" -o -name "source.lock" \) -not -path "./tools/docs-guard/fixtures/*"` sin salida (rc=1 sólo por «Permiso denegado» en la carpeta del cuerpo); PR-7 `fijadas` da `piezas=0` en `Guides/` y `Concepts/` (`salida/inventario/linea-de-base/resumen.txt`) |
| CL-12 | Sí | Igual a la fila | Dentro del cuerpo `SDEI` («el proceso “Cómo intervenir”»); ruta exacta pendiente (Q-3) | Versión de la plantilla | `README.md:30-31` |
| CL-13 | Sí | Igual a la fila | `README.md` y `CHANGELOG.md` en la raíz | Fecha (el CHANGELOG va por fecha) | `README.md:14`; `CHANGELOG.md:6` |
| CL-14 | No | Igual a la fila: sin sitio | — | — | `AGENTS.md:45-46` |

## 4. Decisiones de clase H para una persona

| Id | Opciones | Default propuesto | Quién decide |
| --- | --- | --- | --- |
| D-03 | No · Sí | No | Responsable del producto |
| D-09 | (a) guion propio del repo en su commit · (b) copia con huella · (c) reutilizable | (a) | Responsable del producto |
| D-11 | Mapa medido · ampliar o acotar una delegación · retirar delegaciones | Mapa medido | Responsable del producto |
| D-12 | Puntero · puntero más índice para agentes | Puntero más índice (lo existente) | Responsable del producto |
| Acción H: cambiar `AGENTS.md` (A-05) | No tocarlo · actualizar el puntero | No tocarlo: ya es un puntero | Una persona (`AGENTS.md:139`) |
| Acción H: agregar una excepción a `tools/docs-guard/excepciones.txt` (A-08) | Ninguna · agregar con huella | Ninguna | Una persona (`AGENTS.md:105`; `tools/docs-guard/README.md:178`) |
| Acción H: pasar A-01 o cualquier documento a `vigente` | Queda `borrador` · pasa a `vigente` | Queda `borrador` | Una persona (`AGENTS.md:104`) |

## 5. Artefactos A-02 a A-11

| Id | Producido (sí o no) | Ruta | Motivo si no se produce | Propuesta sujeta a (D-nn), si depende de una H abierta |
| --- | --- | --- | --- | --- |
| A-02 | No | `tools/docs-guard/prefijos.txt` (instancia existente) | Ya existe y la adopción no fija prefijos nuevos (D-07). Que sea «registro del proyecto» o «de origen» depende de D-09 (§6) | D-09 |
| A-03 | No | `tools/docs-guard/esquemas/cuerpo.schema.json` (instancia existente) | Ya existe con su vocabulario (D-08); sin valores nuevos | D-09 |
| A-04 | No | Dentro del cuerpo `SDEI` | Instancia existente (`CHANGELOG.md:14`) en la carpeta ilegible: no se puede actualizar sin leerla (Q-3) | — |
| A-05 | No | `AGENTS.md` (instancia existente) | Ya es un puntero (`AGENTS.md:15-17`); cambiarlo es H | D-12 |
| A-06 | No | Dentro del cuerpo `SDEI` | Instancia existente (`README.md:30-31`) en la carpeta ilegible (Q-3) | — |
| A-07 | No | `.github/workflows/docs-guard.yml` y `scripts/ci-local.sh` (existentes) | Ya corren el mismo guion en CI y en local (`.github/workflows/docs-guard.yml:16`) | D-09 |
| A-08 | Sí | `salida/pr-adopcion/descripcion.md` (va en la descripción del pull request de adopción; `excepciones.txt` existente sin cambios) | — | — |
| A-09 | No | — | Las piezas de fuera (CL-08, CL-09) viven en el hermano no leído; no se sabe si ya tienen `source.lock` o `base_commit` (Q-6) | — |
| A-10 | No | `.github/workflows/docs-enlaces-semanal.yml` (existente) | Ya declara frecuencia, frescura, qué vigila y modo (D-17) | — |
| A-11 | Sí, sólo CHANGELOG | `salida/CHANGELOG.md` (entrada y punto de inserción) | La entrada del índice para agentes (CL-08) no se produce: el índice del hermano no se leyó (Q-6) | — |

## 6. Lo que el conocimiento no resolvió

| Sección o decisión | Cita textual de lo que no resuelve | Qué quedó sin hacer |
| --- | --- | --- |
| §3.1, §8 y D-09 | «`DocsAsCode-Designing-Specification §3.2`, D-09, no resuelve: el caso en que el proyecto es el repositorio que aloja la compuerta de origen». §5.6 dice «No se agregan prefijos del proyecto al registro de origen ni se usa el de origen como registro del proyecto» y acá ambos son el mismo archivo | D-09 queda H con default (a); A-02 y A-03 no se producen como copia |
| D-01 · organización y D-14 | «La organización se mide: remoto `origin` del repo y líneas `uses:` de sus workflows; si no se puede medir, “pendiente: organización”» | Organización y visibilidad sin medir (Q-1, Q-4) |
| §3.6 y DE-19 | «el barrido se nombra por esa lista: `grep -rnIiE -f {lista-privada} {carpeta}` no da salida» | Barrido no corrido (Q-5) |
| Paso 1, patrón 6 y CL-02, CL-12 | «Advertencia del índice del proyecto … Lectura del índice; cada advertencia pasa a A-01 como reserva» | Índice del cuerpo ilegible (Q-3) |
| Suposiciones | Ninguna. Lo no medido quedó «pendiente» con su motivo | — |

## 7. Verificación (§6)

| Comprobación | Comando | Resultado (salida textual) |
| --- | --- | --- |
| Compuerta sobre los artefactos, con A-02 y A-03 (copia de §5.7 y su huella) | `python3 -I tools/docs-guard/dg.py esquema --raiz {montaje}/verde {montaje}/verde` (A-01 con frontmatter, con el `prefijos.txt` y el esquema existentes) | Ver `salida/verificacion/par.txt`. Sin copia de §5.7: D-09 abierto (§6). Huellas del guion leído: `ci-local.sh` 5d07aed1…851d, `dg.py` 471936d8…bdbf |
| Par rojo/verde plantado, con la compuerta de D-09 | `python3 -I tools/docs-guard/dg.py trazas --raiz {montaje}/rojo {montaje}/rojo` y lo mismo con `verde` | Ver `salida/verificacion/par.txt` (compuerta del default (a) de D-09, sujeta a D-09) |
| Autoprueba de la compuerta de origen | `DOCS_GUARD_CACHE=salida/verificacion/cache bash scripts/ci-local.sh autoprueba` | `== autoprueba: ROJO (2 fallas)`, 48 `ok`. Las dos fallas son herramientas ausentes sin red: `PR-1 lychee … rc=127` y `PR-4 mermaid … MODULE_NOT_FOUND` (el paso `herramientas` las baja de la red). Salida en `salida/verificacion/autoprueba.txt` |
| Chequeo de citas ruta:línea (§3.5; cada cita repite el archivo, sin `:n` sueltas) | El bloque de §3.5, desde `repo/LD` | Ver `salida/verificacion/citas.txt` |
| Barrido por `{lista-privada}` (§3.6) | `grep -rnIiE -f {lista-privada} salida` | pendiente: sin `{lista-privada}` (Q-5) |
