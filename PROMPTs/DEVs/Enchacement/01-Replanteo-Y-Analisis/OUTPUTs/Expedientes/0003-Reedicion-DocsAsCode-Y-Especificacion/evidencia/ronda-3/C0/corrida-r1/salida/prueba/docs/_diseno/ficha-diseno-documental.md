---
doc_id: FIC-LD-DISENO
doc_type: ficha
title: Ficha de diseño documental de Lab-Documentos
description: Decisiones, catálogo activo y artefactos del sistema documentador del repositorio, con su evidencia.
status: borrador
origin: ia-generated
confidence: media
owner: aplicador
last_review: 2026-11-02
audience: [humano, agente, po]
traces: [RD-LD-RRD]
---

# Ficha de diseño documental — Lab-Documentos

Ruta en el repositorio, si se adopta: `docs/_diseno/ficha-diseno-documental.md` (D-05). Las citas valen contra el
árbol recibido en `repo/LD/` y se leen desde esa carpeta. Lo privado se nombra por alias (§3.6 del conocimiento):
`{organizacion}` es el dueño de los repositorios en GitHub; `{etiqueta-runner}`, la etiqueta Linux del runner propio;
`{repositorio-hermano}`, el repositorio `.Documentacion` del proyecto.

| Campo | Valor |
| --- | --- |
| Proyecto y repositorios leídos, con SHA (sin `.git`: «SHA: pendiente» y huella del árbol con `LC_ALL=C`, comando 11, §2.4) | Lab-Documentos (un repo, `repo/LD/`). SHA: pendiente (copia sin `.git`: `./aislado git -C repo/LD log -1` → «fatal: not a git repository»). Huella del árbol (comando 11, con `{excluidas}` podadas): `f94e29c0ab02675105c1f052e1b9a717b02ae9cf5420b62e7698322826620316`. El proyecto es el repo de la compuerta (`tools/docs-guard/dg.py` y `scripts/ci-local.sh` existen en el árbol): huellas `dg.py` `471936d8f86f2d91a6b9633adc8016bfb9135547053739a7952d3321e689bdbf`, `ci-local.sh` `5d07aed13433fbe55289e0dc1551f0bd06e6ceace7f400152106d8c8369e851d`, idénticas a las de `compuerta/` (`sha256sum`; `diff -rq` sin salida) |
| Carpetas excluidas o sin lectura (`{excluidas}`, nombres de carpeta a cualquier profundidad, separados por espacios) | `Sistema-De-Documentacion-E-Integracion` — sin lectura: `find . -type d ! -readable` → `./Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion` y «Permission denied». Queda «pendiente: sin lectura» todo lo que vive ahí (cuerpo `SDEI`, `README.md:30`) |
| Fecha (salida de `date -u +%F`, comando 10) | 2026-11-02 (fecha del montaje, `montaje.txt`; el comando 10 dentro de `./aislado` devolvió la misma) |
| Quién aplica (el rol, no un nombre) | aplicador |
| Conocimiento aplicado (alias, versión, huella) | DocsAsCode-Designing-Specification, 1.2, SHA-256 de `conocimiento.md` `aeb9135f60c3177a98c5c97eac1e272e889d10ab8a07b5b3df0827d3d85716d8` |

## 1. Inventario (paso 1)

Todos los comandos corren con `./aislado bash -c 'cd repo/LD; …'`, con `EXC=(Sistema-De-Documentacion-E-Integracion)`
y el bucle de §3.1 que arma `X` y `P`. Las salidas completas están en `salida/inventario/` (`c01.txt`, `c01b.txt`,
`c02.txt`, `c05.txt`, `c07.txt`, `c13.txt`, `base-*.txt`).

| Patrón de §3.1 | Comando | Cuenta | Salida o ruta a la salida |
| --- | --- | --- | --- |
| ID declarado más de una vez | 1: `python3 ../../compuerta/tools/docs-guard/dg.py trazas --raiz . .` (la compuerta de origen; no excluye `{excluidas}`, que igual no se leen). 1b: el literal de §3.1 con `X` | 1: 606 IDs duplicados (612 líneas `id-duplicado`); 1b: 80 IDs repetidos | 1: `== PR-5 traces-resolve: ROJO (errores=1446 avisos=0) trazas=1921 resueltas=1081 ids-duplicados=606`, rc=1 (`inventario/c01.txt`). 1b: `4 ACT-01`, `4 ACT-02`, … `2 AG-ROOT`, `3 ANEXO-GLOSARIO` (`inventario/c01b.txt`) |
| Versión declarada dos veces | 2: el literal de §3.1 con `X` | 0 | sin salida; rc=123 de `xargs` (ningún `grep -l` encontró `Versión:**` en un archivo con `version:`) |
| Estado «planificado» o equivalente (y la proporción planificada, con ruta:línea) | 3, con `{carpeta-tecnica}` = `docs/tecnica/` (default) | 0 | `grep: docs/tecnica/: No such file or directory`, rc=2: carpeta ausente. Proporción planificada: no aplica, no hay documentación técnica CL-07 (§3) |
| Traza de la interfaz a una unidad que no le corresponde | 4, con `{carpeta-ayuda}` = `docs/ayuda` (default; no hay repo de interfaz) | 0 | `grep: docs/ayuda: No such file or directory`, rc=2: carpeta ausente |
| Puntero a un documento obsoleto o ausente (sin CHANGELOG: «archivo ausente», cuenta 0 y su rc) | 5 (las dos líneas) | CHANGELOG: 1 archivo; 8 líneas; 2 punteros a un obsoleto | `find … \| wc -l` → 1; segunda línea rc=0, 8 líneas (`inventario/c05.txt`). La que nombra un obsoleto: `DOC-SDT-0001` pasa a `status: obsoleto` (`CHANGELOG.md:160`); lo siguen trazando `README.md:11` y `Guides/README.md:11`; su archivo `Sistema-Documentador-Tecnico-Guide.md` no está en lo legible (`find . -name Sistema-Documentador-Tecnico-Guide.md` sin salida; vive, según `CHANGELOG.md:154-160`, en la carpeta sin lectura) |
| Advertencia del índice del proyecto (cuenta y lista del comando 6; cada una pasa a reserva, con su estado) | 6, con `{indice}` = `README.md` (el README del cuerpo `SDEI`, que es el índice de la documentación, está sin lectura) | 0 | lista: sin salida, rc=1; cuenta: 0. Ninguna reserva. El índice del cuerpo: «pendiente: sin lectura» |
| Espacios de IDs en uso, con su origen y sus choques con los Id de esta ficha (D-07) | 7 | 247 prefijos | Primeros: `1955 TEM`, `1689 ESC`, `1437 ACT`, `1288 CTX`, `864 MARCO`, `609 DOC`, `573 FAM`, `427 A`, `329 F`, `307 RN`, `252 AG`, `238 FC`, `232 ANEXO`, `123 CU` (`inventario/c07.txt`). Origen: registro (`tools/docs-guard/prefijos.txt:8-40`: `ESC`, `CTX`, `ACT`, `DOC`, `FAM`, `MARCO`, `TEM`, `FC`, `RD`, `RN`, `CU`…); fuera del registro, heredados de las guías (`ANEXO`, `AG`, `AIP`, `GHDOC`…), sin contar en esta ficha. Choques con los Id de A-01 (cuentas de `inventario/c07.txt`): `A` 427, `D` 56, `I` 9, `CL` 8, `DE` 2; los cinco están en uso en las guías con otro sentido y ninguno está en el registro. Los Id de A-01 no se declaran como `doc_id` ni como encabezado, así que no entran al registro de la compuerta |
| Plataformas que compila cada máquina (D-09) | 8 | 44 `TargetFramework` | `29 net10.0`, `13 net8.0`, `1 net10.0-android` (`Concepts/Framework-Concept/Demo/src/FrameworkConcept.Shell/FrameworkConcept.Shell.csproj:15`), `1 $(TF)`. Plataforma → runner: Linux y Android → `{etiqueta-runner}` (`.github/workflows/framework-concept-demo.yml:43`, `.github/workflows/docs-guard.yml:60`); sin iOS ni Mac |
| Prefijos nuevos libres (comando 9, uno por prefijo) | 9 con `FIC`; con `RD` para el rango del RRD | `FIC`: 0 (libre); `RD`: 3 archivos | `RD` en uso: `RD-01`, `RD-21`, `RD-27`, `RD-900` (`grep -rIhowE "RD-[0-9]+"`); el rango `RD-50`…`RD-55` está libre en lo legible; contra la carpeta sin lectura, pendiente |

## 2. Decisiones

| Id | Pregunta | Valor | Evidencia (ruta:línea en el SHA leído, o «pendiente: qué falta») | Clase (P o H) | Si es H: opciones y default para la persona |
| --- | --- | --- | --- | --- | --- |
| D-01 | ¿Escenario y contextos? | Corpus de guías. Audiencias: estudiante, humano, agente. Sin roles: no hay producto con permisos; la app de `Concepts/Framework-Concept/Demo/` es una demo que ilustra una guía (CL-10, DK-14) | Propósito: «Repositorio de guías de estudio y conceptos» (`README.md:16-17`); la demo, parte del libro de Framework Concept (`CHANGELOG.md:47`). Inventario de autorización: pendiente sobre la demo (no se corrió un inventario de políticas o claims; la demo no es producto del repositorio) | P | — |
| D-01 · sitio | ¿Hay sitio publicado? | No (remite a D-03, H) | «sin sitio publicado» (`AGENTS.md:45-46`); «se lee directamente en GitHub» (`README.md:17`) | H | Ver D-03 |
| D-01 · marco | ¿Hay marco de especificación? | Sí: el registro propio de prefijos y `doc_id` del repositorio (D-04) | `tools/docs-guard/prefijos.txt:1-5` | P | — |
| D-01 · topología | ¿Mismo repo, hermano o dedicado? | Repo dedicado al corpus, con un repo hermano `.Documentacion` para expedientes y trabajo previo | El hermano es el asiento de los expedientes (`CHANGELOG.md:34`) y figura en el árbol del carril (`tools/docs-guard/arbol.tsv:8`); el hermano no llegó: evidencia secundaria declarada, «sin verificar en el hermano» | P | — |
| D-01 · organización | ¿Dentro o fuera de la organización del runner (medido)? | Dentro: `{organizacion}`, la misma del runner y de la compuerta | Sin `.git`, evidencia secundaria del texto del repo: el workflow se baja las herramientas del mismo dueño (`.github/workflows/docs-guard.yml:75`) y el árbol del carril es de «la organización del runner» (`tools/docs-guard/arbol.tsv:3-4`, `tools/docs-guard/arbol.tsv:7`). Remoto `origin`: pendiente, sin `.git` | P | — |
| D-02 | ¿Qué clases de pieza se activan? | CL-01, CL-02, CL-03, CL-08, CL-09, CL-10, CL-11, CL-12, CL-13 activas; CL-04, CL-05, CL-06, CL-07, CL-14 de baja | Fila «Corpus de guías» de §2.3 más el alta de CL-01 por A-01; cada alta y baja con motivo en §3 | P | — |
| D-03 | ¿Hay sitio publicado? | No | `AGENTS.md:45-46`; `README.md:17` | H | Opciones: Sí · No. Default: No |
| D-04 | ¿Hay marco de especificación con registro de IDs? | Sí: el registro propio (prefijos con ámbito y `doc_id` en el repo), que hoy no resuelve sobre todo el árbol | Registro: `tools/docs-guard/prefijos.txt:1-5`. Comando 1: 606 IDs duplicados y 1446 errores sobre `.`; comando 1b: 80 repetidos; comando 2: 0. Sobre la carpeta del cuerpo (la que el registro sí gobierna, `.github/workflows/docs-guard.yml:38`), pendiente: sin lectura | P | — |
| D-05 | ¿Dónde vive cada pieza? | Mismo repo para CL-01, CL-02, CL-03, CL-10, CL-12, CL-13; repo hermano para CL-08 y CL-09; CL-11 donde vive su copia (§3) | Regla de I-20: las guías son el producto del repo (`README.md:16-17`); expedientes en el hermano (`CHANGELOG.md:34`) | P | — |
| D-06 | ¿Contra qué ancla vale cada pieza? | Commit para lo que vive en el repo; etiqueta para el cuerpo `SDEI` (`sdei-v2.0.0-borrador`); SHA fijado para lo que se cita del hermano | Etiqueta del cuerpo: `CHANGELOG.md:36`. Mecanismo actual de anclas: `source.lock` de la mini demo, que «baja por git archive el SHA de source.lock» (`.github/workflows/mini-demo-movilidad.yml:3`); citas al hermano por SHA (`CHANGELOG.md:13`). Otras líneas de versión: pendiente, sin `.git` no se listan etiquetas | P | — |
| D-07 | ¿Qué prefijos e IDs? | Registro del repositorio (`tools/docs-guard/prefijos.txt`) más `FIC` interno para la ficha y la línea de base (A-02); RRD en `RD-50`…`RD-55` | Comando 9: `FIC` 0. Prefijos heredados fuera del registro (`ANEXO`, `AG`, `AIP`, `GHDOC`…, comando 7): se cuentan en A-08 y van a un saneamiento aparte. Unicidad contra la carpeta sin lectura: pendiente. Un prefijo nuevo es P (`AGENTS.md:105`) | P | — |
| D-08 | ¿Qué esquema de frontmatter? | El del repositorio: diez campos más `description`, con su vocabulario | `tools/docs-guard/esquemas/cuerpo.schema.json:10`, `tools/docs-guard/esquemas/cuerpo.schema.json:18`; ya incluye `ficha`, `rrd`, `proceso` y `anexo` | P | — |
| D-09 | ¿Cómo corre la compuerta? | Default propuesto: la compuerta del propio árbol (el repo es la compuerta de origen), en el runner del proyecto `{etiqueta-runner}`, como hoy | El workflow saca las herramientas de este mismo repositorio en el SHA del PR (`.github/workflows/docs-guard.yml:72-81`) y corre en `{etiqueta-runner}` (`.github/workflows/docs-guard.yml:60`); local, `scripts/ci-local.sh` (`AGENTS.md:86-93`). Plataformas: Linux y Android en el mismo runner (inventario, patrón 8) | H | Opciones: (a) la compuerta del árbol, como hoy; (b) copia con huella en `.docs-guard/` y `.docs-guard-origen/`; (c) llamar al reutilizable. Default: (a), porque el repo es la compuerta de origen y la copia duplicaría el guion |
| D-10 | ¿Qué controles bloquean y cuáles avisan, en qué carpeta? | La tabla del proyecto manda: en la carpeta del cuerpo, PR-1, PR-2, PR-4, PR-5, PR-6, PR-7 `fijadas`, AI-1, AI-2, AI-5 bloquean; AI-3 y `cita-linea` avisan. Sobre `Guides/` y `Concepts/` (heredado) todos avisan; `docs/` (carpeta nueva de la adopción) bloquea con todos los grupos | Tabla: `tools/docs-guard/README.md:148-157`. Línea de base heredada (A-08): ningún grupo rojo en 0. Que la plataforma vuelva obligatorio el check: pendiente, sin configuración ni API (sin red); es un acto H (§4) | P | — |
| D-11 | ¿Quién decide qué? | Mapa de delegaciones del merge: expediente 0003 (`CHANGELOG.md:32-39`), expediente 0002 (`CHANGELOG.md:320-324`), expediente 0001 de Framework Concept (`CHANGELOG.md:340-343`), cada una decidida por el PO. La adopción no cae en ninguna: la fusiona una persona; con H abiertas, el PR lleva reserva | Las actas citadas viven en el hermano: «pendiente: acta sin versionar» en este árbol. Visto bueno en ausencia del titular: pendiente, no hay archivo que lo diga | H | Opciones: una persona fusiona la adopción · el PO asienta una delegación nueva con alcance de la adopción. Default: una persona fusiona |
| D-12 | ¿Qué canales hay para agentes? | `AGENTS.md` puntero, que ya existe; punto de entrada de A-11 | `AGENTS.md:17-19`; cambiarlo es H (`AGENTS.md:139`) | H | Opciones: `AGENTS.md` puntero · más un índice en el hermano. Default: `AGENTS.md` puntero (sin sitio, sin CL-14) |
| D-13 | ¿Cómo es la ayuda al usuario final? | Ninguna | Corpus de guías sin producto con usuario final (`README.md:16-17`); comando 4: carpeta ausente. El default «única» no aplica: no hay interfaz del repositorio a la que asista la ayuda | P | — |
| D-14 | ¿Qué es privado y cómo se nombra? | Alias más barrido. Público: Lab-Documentos (evidencia secundaria: «Sólo repos públicos», `tools/docs-guard/arbol.tsv:3-4`, `tools/docs-guard/arbol.tsv:7`). Alias del repo: el servicio push privado es `SDD-B` (`AGENTS.md:109-110`). Lista: pendiente | Comando 13: 11 líneas (`inventario/c13.txt`). Comando 12b, en §7 | P | — |
| D-15 | ¿Hay un cuerpo formativo? | Sí, sin perfil de guía de estudio a la vista | Propósito declarado: guías de estudio (`README.md:16`). El perfil del cuerpo vive en la carpeta sin lectura: pendiente | P | — |
| D-16 | ¿Idioma y estilo? | Castellano rioplatense del proyecto; no se traducen las claves del frontmatter, los IDs, los nombres de controles (`PR-1`…`PR-7`, `AI-1`…`AI-5`) ni los nombres de archivo | `README.md:16-17`; claves: `tools/docs-guard/esquemas/cuerpo.schema.json:10`; controles: `tools/docs-guard/README.md:150-157` | P | — |
| D-17 | ¿Cómo es el carril programado? | Semanal (lunes), frescura 365 días, vigila enlaces entre repos y externos, atraso de `base_commit` y `source.lock`, deriva de fijadas, frescura y línea de base de AI-3; sólo avisa, con un único issue | `.github/workflows/docs-enlaces-semanal.yml:17-18`; `tools/docs-guard/README.md:191-205` | P | — |

## 3. Catálogo activo

| Clase | Activa (sí o no) | Alta o baja frente al escenario, con motivo | Dónde vive (todas las ubicaciones) | Ancla | Evidencia |
| --- | --- | --- | --- | --- | --- |
| CL-01 | sí | Alta (DK-14): sólo por A-01 | `docs/_diseno/` (propuesta) | Commit | Esta ficha |
| CL-02 | sí | Fila | `docs/_requisitos.md` (A-04); el RRD del cuerpo, en la carpeta sin lectura (`CHANGELOG.md:14`, `RD-21` a `RD-27`) | Commit | `CHANGELOG.md:14` |
| CL-03 | sí | Fila | `AGENTS.md` en la raíz | Commit | `AGENTS.md:15-19` |
| CL-04 | no | Fila (no está); la demo tiene código, pero es CL-10 | — | — | Inventario, patrón 8 |
| CL-05 | no | Fila; PR-6 da 0 contratos en `Guides/` y `Concepts/` | — | — | `inventario/base-Guides-contrato.txt` |
| CL-06 | no | Fila; D-13 = ninguna | — | — | Comando 4, carpeta ausente |
| CL-07 | no | Fila; sin `docs/tecnica/` | — | — | Comando 3, carpeta ausente |
| CL-08 | sí | Fila | Repo hermano, sin verificar en el hermano | SHA fijado | `tools/docs-guard/arbol.tsv:8` |
| CL-09 | sí | Fila | Repo hermano (expedientes), sin verificar en el hermano | Commit | `CHANGELOG.md:34` |
| CL-10 | sí | Fila | `Guides/`, `Concepts/` (incluida la demo de Framework Concept) | Versión del cuerpo y etiqueta | `README.md:36-39`; `CHANGELOG.md:36` |
| CL-11 | sí | Fila | `Concepts/Framework-Concept/Conocimientos/`; con huella declarada: pendiente | Versión y SHA-256 | `CHANGELOG.md:48` |
| CL-12 | sí | Fila | Instancia de «Cómo intervenir» en el cuerpo `SDEI` (sin lectura) | Versión de la plantilla | `README.md:30-31`; `CHANGELOG.md:17` |
| CL-13 | sí | Fila | `README.md`, `CHANGELOG.md` | Fecha | `README.md:42`; `CHANGELOG.md:1-3` |
| CL-14 | no | Fila; sin sitio | — | — | `AGENTS.md:45-46` |

## 4. Decisiones de clase H para una persona

| Id | Estado (abierta, o «decidida por {actor}» con ruta:línea) | Opciones | Default propuesto | Quién decide |
| --- | --- | --- | --- | --- |
| D-03 | abierta | Sí · No | No | Responsable del producto |
| D-09 | abierta | Compuerta del árbol · copia con huella · reutilizable | Compuerta del árbol, como hoy | Responsable del producto |
| D-11 | abierta | Fusiona una persona · delegación nueva asentada | Fusiona una persona | Responsable del producto |
| D-12 | abierta | `AGENTS.md` puntero · más índice en el hermano | `AGENTS.md` puntero | Responsable del producto |
| Cambio de `AGENTS.md` (A-11) | abierta | Agregar la fila de la ficha y renovar la huella de AI-3 · no tocarlo | No tocarlo hasta cerrar D-12 | Persona (`AGENTS.md:139-142`) |
| Volver obligatorio el check `docs-guard` | abierta | Obligatorio · sólo aviso | Sólo aviso hasta medir la configuración | Persona con permisos del plan |

## 5. Artefactos A-02 a A-11

| Id | Producido (sí o no) | Ruta | Motivo si no se produce | Propuesta sujeta a (D-nn), si depende de una H abierta | «Sin probar», si falta la compuerta |
| --- | --- | --- | --- | --- | --- |
| A-02 | sí | `salida/tools/docs-guard/prefijos.txt` (instancia existente, actualizada en su ruta: suma `FIC`) | — | D-09 | — |
| A-03 | no | `tools/docs-guard/esquemas/cuerpo.schema.json` | La instancia existente ya cubre `ficha`, `rrd` y `anexo` (`tools/docs-guard/esquemas/cuerpo.schema.json:10`) | — | — |
| A-04 | sí | `salida/docs/_requisitos.md` | — | D-09, D-11 | — |
| A-05 | no | `AGENTS.md` | Ya existe un puntero (`AGENTS.md:17-19`) | D-12 | — |
| A-06 | no | — | La instancia existe en el cuerpo `SDEI` (`CHANGELOG.md:17`), sin lectura: no se puede actualizar en su ruta | — | — |
| A-07 | no | `.github/workflows/docs-guard.yml`, `scripts/ci-local.sh` | Ya existen y corren el mismo guion en CI y local (`.github/workflows/docs-guard.yml:83-84`) | D-09 | — |
| A-08 | sí | `salida/docs/_gobierno/linea-de-base.md`; excepciones: la instancia existente `tools/docs-guard/excepciones.txt`, sin cambios | — | D-11 | — |
| A-09 | no | — | Las piezas de afuera (CL-08, CL-09) viven en el hermano, que no llegó; el mecanismo actual existe (`.github/workflows/mini-demo-movilidad.yml:3`) | — | — |
| A-10 | no | `.github/workflows/docs-enlaces-semanal.yml` | Ya existe (`.github/workflows/docs-enlaces-semanal.yml:17-18`) | — | — |
| A-11 | sí | `salida/CHANGELOG.md.insercion`, `salida/AGENTS.md.insercion` | — | D-12 (la de `AGENTS.md`) | — |

## 6. Lo que el conocimiento no resolvió

| Sección o decisión | Cita textual de lo que no resuelve | Qué quedó sin hacer |
| --- | --- | --- |
| §5.7, D-09 | «`DocsAsCode-Designing-Specification §3.2`, D-09, no resuelve: qué hace el default "copia con huella" cuando el proyecto es el repo de la compuerta de origen» | Se propone, como default de la H, la compuerta del árbol; la copia no se armó |
| §2.4, DE-24 | «`DocsAsCode-Designing-Specification §2.4`, no resuelve: cómo medir la línea de base de `Guides/` cuando contiene una carpeta sin lectura» | La línea de base de `Guides/` incluye un error de permiso en PR-4; la del cuerpo queda pendiente |
| Ejecución | Desvío del aplicador, no del conocimiento: tres comandos corrieron fuera de `./aislado` (listar la carpeta de la corrida y leer la carta; escribir los dos `.insercion` con un heredoc) | Ninguno de los tres leyó ni escribió fuera del directorio de la corrida; los valores de la ficha salen de comandos corridos con `./aislado` |

## 7. Verificación (§6)

| Comprobación | Comando | Resultado (salida textual) |
| --- | --- | --- |
| Compuerta sobre los artefactos, con A-02 y A-03 (copia de §5.7 y su huella) | `./aislado bash -c 'cd salida/prueba; DOCS_GUARD_TRAZAS_EXTRA="" bash scripts/ci-local.sh {grupo} docs'`, un grupo por vez, en `salida/prueba/`: la compuerta del árbol con A-02 en `tools/docs-guard/prefijos.txt` y A-03 tal cual; huellas `dg.py` `471936d8…89bdbf` y `ci-local.sh` `5d07aed1…69e851d`, las mismas de `compuerta/`. Sobre A-01, A-04 y A-08 en `docs/`. `DOCS_GUARD_TRAZAS_EXTRA` vacío porque los punteros de la raíz no están en la prueba | `== PR-1 fuera-del-repo: verde (errores=0 avisos=0)`; `== PR-2 esquema: verde (errores=0 avisos=0) archivos-con-frontmatter=3`; `== PR-3 anti-inyeccion: verde (errores=0 avisos=0)`; `== PR-4 mermaid-arroba: verde (errores=0 avisos=0) bloques=0`; `== PR-5 traces-resolve: verde (errores=0 avisos=0) trazas=3 resueltas=3 ids-duplicados=0`; `== PR-6 contratos: verde (errores=0 avisos=0) contratos=0`; `== PR-7 url-fecha: verde (errores=0 avisos=0)`; todos rc=0 (`inventario/prueba-verde-*.txt`). A-05, A-06 y A-07 no se montaron: no se producen (§5) |
| Par rojo/verde plantado, con la compuerta de D-09 | Se agrega `FIC-LD-NO-EXISTE` a `traces` de `docs/_gobierno/linea-de-base.md` y se corre `ci-local.sh trazas docs`; se quita y se corre de nuevo | Rojo, rc=1, en la línea 1 de `docs/_gobierno/linea-de-base.md`: `ERROR traza-no-resuelve: FIC-LD-NO-EXISTE: el ID no está declarado en el registro` y `== PR-5 traces-resolve: ROJO (errores=1 avisos=0) trazas=4 resueltas=3`. Verde, rc=0: `== PR-5 traces-resolve: verde (errores=0 avisos=0) trazas=3 resueltas=3` |
| Autoprueba de la compuerta de origen (sin red ni caché: «pendiente», con el comando, §5.7) | `./aislado bash -c 'cd repo/LD && bash ../../compuerta/scripts/ci-local.sh autoprueba Guides'`, sin red, con las cachés del entorno (`DOCS_GUARD_CACHE=/opt/docs-guard`, `npm_config_cache=/opt/npm-cache`, `npm_config_offline=true`) | rc=0; últimas líneas: `ok PR-6 contrato rojo (rc=1)`, `ok PR-6 contrato verde (rc=0)`, `ok AK-7 fixture permanente rojo (rc=1; AI-1..AI-5 detectados)`, `== autoprueba: verde` (`inventario/autoprueba.txt`). Huella del árbol después de correrla: la misma, `f94e29c0…26620316` |
| Chequeo de citas ruta:línea (§3.5; cada cita repite el archivo, sin `:n` sueltas) | El bloque de §3.5 sobre esta ficha, desde `repo/LD`; y `grep -noE` de una cita suelta (acento grave, dos puntos y número) | Salida vacía (sólo el marcador de fin del bucle). Sueltas: sin salida, rc=1 |
| Muestra de cinco citas releídas contra lo que afirman (§3.5) | `sed -n` de cada línea | `CHANGELOG.md:160` → «`Sistema-Documentador-Tecnico-Guide.md` (`DOC-SDT-0001`): `status: obsoleto`» (puntero obsoleto). `AGENTS.md:45-46` → «… leídas en GitHub, sin sitio publicado» (D-03). `Concepts/Framework-Concept/Demo/src/FrameworkConcept.Shell/FrameworkConcept.Shell.csproj:15` → `<TargetFramework>net10.0-android</TargetFramework>` (patrón 8). `.github/workflows/docs-guard.yml:60` → `runs-on: [self-hosted, {etiqueta-runner}]` (D-09). `CHANGELOG.md:36` → «Alcance: los PR del expediente 0003 en este repositorio …» y la etiqueta `sdei-v2.0.0-borrador` (D-06, D-11) |
| Barrido por `{lista-privada}` (§3.6; sin la lista, comando 12b y «lista: pendiente») | 12b desde `salida/`, sobre `A-01.md`, `docs`, `tools`, `CHANGELOG.md.insercion` y `AGENTS.md.insercion`, con un `-e` por IPv4, rutas de usuario, la salida de `hostname -s` del entorno, la etiqueta del runner y el dueño de los repositorios del inventario | Sin salida, rc=1. Lista: pendiente (no hay `{lista-privada}` en el directorio de la corrida) |
