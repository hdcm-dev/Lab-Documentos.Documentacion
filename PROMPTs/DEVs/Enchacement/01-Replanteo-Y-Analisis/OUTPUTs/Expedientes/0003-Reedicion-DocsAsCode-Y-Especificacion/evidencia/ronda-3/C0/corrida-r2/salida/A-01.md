---
doc_id: FIC-DISENO-DOCUMENTAL
doc_type: ficha
title: Ficha de diseño documental de Lab-Documentos
description: "Ficha A-01: escenario, catálogo activo, decisiones D-01 a D-17, artefactos y verificación del sistema documentador."
status: borrador
origin: ia-generated
confidence: media
owner: aplicador
last_review: 2026-11-02
audience: [humano, agente]
traces: [LAB-DOCUMENTOS-README]
---

# Ficha de diseño documental de Lab-Documentos

Todas las citas `ruta:línea` son relativas a la raíz del árbol recibido (`repo/LD`), sin `.git`; valen contra la huella
de la cabecera. Las salidas completas de los comandos están en `inventario/` y `verificacion/` de la salida del
aplicador (no van al repositorio).

| Campo | Valor |
| --- | --- |
| Proyecto y repositorios leídos, con SHA (sin `.git`: «SHA: pendiente» y huella del árbol con `LC_ALL=C`, comando 11, §2.4) | Lab-Documentos (un solo repositorio, `repo/LD`). SHA: pendiente (`git -C repo/LD log -1` → «fatal: not a git repository»). Huella del árbol, comando 11 con `{excluidas}` podada: `f94e29c0ab02675105c1f052e1b9a717b02ae9cf5420b62e7698322826620316`. Es el repositorio de la compuerta: `{compuerta}` es la del árbol recibido; huellas `dg.py` `471936d8f86f2d91a6b9633adc8016bfb9135547053739a7952d3321e689bdbf` y `ci-local.sh` `5d07aed13433fbe55289e0dc1551f0bd06e6ceace7f400152106d8c8369e851d`, idénticas a las de `compuerta/` (`diff -r` sin diferencias) |
| Carpetas excluidas o sin lectura (`{excluidas}`, nombres de carpeta a cualquier profundidad, separados por espacios) | `Sistema-De-Documentacion-E-Integracion` (pendiente: sin lectura; `find . ! -readable` → `./Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion`, «Permission denied»). Ninguna excluida por el encargo |
| Fecha (salida de `date -u +%F`, comando 10) | 2026-11-02 (la de `montaje.txt`; el comando 10 dentro de `./aislado` devolvió `2026-11-02`) |
| Quién aplica (el rol, no un nombre) | aplicador |
| Conocimiento aplicado (alias, versión, huella) | DocsAsCode-Designing-Specification 1.2; SHA-256 de `conocimiento.md`: `aeb9135f60c3177a98c5c97eac1e272e889d10ab8a07b5b3df0827d3d85716d8` |

## 1. Inventario (paso 1)

Todos los comandos se corrieron con `./aislado` desde `repo/LD`, con `EXC=(Sistema-De-Documentacion-E-Integracion)`
y el bucle de `X` y `P` del bloque de §3.1. Guion: `inventario/inventario.sh`.

| Patrón de §3.1 | Comando | Cuenta | Salida o ruta a la salida |
| --- | --- | --- | --- |
| ID declarado más de una vez | 1b (la carpeta sin lectura impide el 1 sobre `.`); además 1 sobre cada carpeta legible (`Concepts`, `Guides`, `.github`, `scripts`, `tools`, `README.md`, `AGENTS.md`) | 1b: 80 IDs; 1: 602 duplicados en `Guides`, 4 en `Concepts`, 0 en el resto | `inventario/c01b.txt` (p. ej. `ESC-1` 116 veces, `ACT-01` 4, `E2E-01` 2); `inventario/c01.txt` |
| Versión declarada dos veces | 2 | 0 (rc=123 de `xargs`: ningún archivo con `^version:` tiene además `Versión:**`) | `inventario/c02.txt` |
| Estado «planificado» o equivalente (y la proporción planificada, con ruta:línea) | 3 con `{carpeta-tecnica}` = `docs/tecnica` | 0; rc=2, carpeta ausente («No such file or directory»). Proporción planificada: no aplica (sin documentación técnica, CL-07 de baja) | `inventario/c03.txt` |
| Traza de la interfaz a una unidad que no le corresponde | 4 con `{carpeta-ayuda}` = `ayuda` | 0; rc=2, carpeta ausente (CL-06 de baja) | `inventario/c04.txt` |
| Puntero a un documento obsoleto o ausente (sin CHANGELOG: «archivo ausente», cuenta 0 y su rc) | 5 (las dos líneas) | CHANGELOG presente (1); 8 líneas, rc=0. Ruta nombrada como obsoleta: `Sistema-Documentador-Tecnico-Guide.md` (`DOC-SDT-0001`, `CHANGELOG.md:160`); `README.md:11` y `Guides/README.md:11` la trazan y la traza no resuelve en el árbol legible (comando 1 sobre `README.md`: «traza-no-resuelve: DOC-SDT-0001»); el archivo estaría en la carpeta sin lectura: pendiente | `inventario/c05.txt`, `inventario/c01.txt` |
| Advertencia del índice del proyecto (cuenta y lista del comando 6; cada una pasa a reserva, con su estado) | 6 con `{indice}` = `README.md AGENTS.md Guides/README.md` (índice del cuerpo `SDEI`: sin lectura) | 1 | `AGENTS.md:139` («La compuerta lo excluye del aviso AI-3»): reserva R-1, estado: vigente, cubierta por la excepción con huella de `tools/docs-guard/excepciones.txt:7` |
| Espacios de IDs en uso, con su origen y sus choques con los Id de esta ficha (D-07) | 7 | 247 prefijos | `inventario/c07.txt`. Origen: registro `tools/docs-guard/prefijos.txt:8-40` (p. ej. `TEM`, `ESC`, `ACT`, `RD`); convenio externo de la industria `tools/docs-guard/prefijos.txt:31-40`; el resto (p. ej. `E2E`, `GF`, `AIP`, `US`) sin registro, heredado. Choques con los Id de esta ficha: `A` (427), `D` (56), `I` (9), `CL` (8), `DE` (2); son etiquetas de la ficha, no `doc_id`, y la ficha no los declara como encabezado |
| Plataformas que compila cada máquina (D-09) | 8 | 4 valores | `inventario/c08.txt`: `net10.0` (29), `net8.0` (13), `net10.0-android` (1), `$(TF)` (1); sin iOS. Línea plataforma → runner: Linux y Android → `{etiqueta-runner}` (`.github/workflows/framework-concept-demo.yml:43`) |
| Prefijos nuevos libres (comando 9, uno por prefijo) | 9 | `FIC` 0, `PRC` 0, `RD` 3 (`RD-1[0-9][0-9]`: 0) | `inventario/c09.txt`. `RD` está registrado con el mismo sentido (`tools/docs-guard/prefijos.txt:27`); el RRD usa el rango libre `RD-100` en adelante |

## 2. Decisiones

| Id | Pregunta | Valor | Evidencia (ruta:línea en el SHA leído, o «pendiente: qué falta») | Clase (P o H) | Si es H: opciones y default para la persona |
| --- | --- | --- | --- | --- | --- |
| D-01 | ¿Escenario y contextos? | Corpus de guías. Sin roles: la demo tiene una sola política de autorización y es CL-10 | `README.md:16-17` («Repositorio de guías de estudio y conceptos»); `Concepts/Framework-Concept/README.md:37` (demo que ilustra la guía); `Concepts/Framework-Concept/Demo/tools/FrameworkConcept.Receptor/AutenticacionDelReceptor.cs:70` (una política) | P | — |
| D-01 · sitio | ¿Hay sitio publicado? | No (remite a D-03, H) | `AGENTS.md:45-46` («sin sitio publicado») | H | Ver D-03 |
| D-01 · marco | ¿Hay marco de especificación? | No hay marco externo; registro propio de prefijos y `doc_id` | `tools/docs-guard/prefijos.txt:1-5` | P | — |
| D-01 · topología | ¿Mismo repo, hermano o dedicado? | Mismo repo para todo, salvo CL-09 en el repo hermano de documentación (sin verificar en el hermano) | `CHANGELOG.md:34` (expedientes en el repo hermano); `tools/docs-guard/arbol.tsv:8` | P | — |
| D-01 · organización | ¿Dentro o fuera de la organización del runner (medido)? | Dentro: el repo es el de la compuerta y su workflow saca las herramientas de `{organizacion}/Lab-Documentos` | `.github/workflows/docs-guard.yml:72-77`; `tools/docs-guard/arbol.tsv:3-7` (repos de la organización del runner). Sin remoto `origin` (sin `.git`) | P | — |
| D-02 | ¿Qué clases de pieza se activan? | CL-01 (sólo A-01), CL-02, CL-03, CL-09, CL-10, CL-12, CL-13. Bajas frente a la fila: CL-08 (D-12 no elige índice), CL-11 (sin copia con huella) | Ver §3 | P | — |
| D-03 | ¿Hay sitio publicado? | No (default, abierta) | `AGENTS.md:45-46` | H | Sí · No; default No |
| D-04 | ¿Hay marco de especificación con registro de IDs? | No: registro propio (`prefijos.txt` más `doc_id`). En el árbol legible el registro no resuelve: 1b da 80 IDs repetidos y el 1, 602 en `Guides` | `tools/docs-guard/prefijos.txt:1-5`; `inventario/c01b.txt`; `inventario/c01.txt`. En `SDEI`: pendiente, sin lectura | P | — |
| D-05 | ¿Dónde vive cada pieza? | Mismo repo: A-01 en `docs/_diseno/`, A-04 en `docs/_requisitos.md`, A-06 en `docs/_gobierno/`; CL-09 en el repo hermano | `CHANGELOG.md:34`; ubicaciones de CL-03 y CL-12 sujetas a D-12 y D-11 | P | — |
| D-06 | ¿Contra qué ancla vale cada pieza? | Commit para todo lo del repo. Línea de versión del cuerpo con etiqueta de archivo `sdei-v2.0.0-borrador` | `CHANGELOG.md:36`; mecanismo actual de anclas: `source.lock` sólo en fixtures (`find . -name source.lock` → 3, todos en `tools/docs-guard/fixtures/anclas/`) | P | — |
| D-07 | ¿Qué prefijos e IDs? | Registro del proyecto `tools/docs-guard/prefijos.txt` (A-02), más `FIC` y `PRC` internos (libres, comando 9 en 0). Prefijos heredados fuera del registro (p. ej. `E2E`, `GF`): a un saneamiento aparte | `tools/docs-guard/prefijos.txt:1-40`; `AGENTS.md:105` (prefijo nuevo: clase P); `inventario/c09.txt` | P | — |
| D-08 | ¿Qué esquema de frontmatter? | Mapeo al existente, sin cambios: ya tiene `ficha`, `rrd`, `proceso` y `anexo` | `tools/docs-guard/esquemas/cuerpo.schema.json:7`, `tools/docs-guard/esquemas/cuerpo.schema.json:10`, `tools/docs-guard/esquemas/cuerpo.schema.json:18` | P | — |
| D-09 | ¿Cómo corre la compuerta? | Abierta. Propuesta: la compuerta del propio árbol (es la de origen), con su workflow y `docs` sumada a la RUTA | `.github/workflows/docs-guard.yml:60`, `.github/workflows/docs-guard.yml:63`, `.github/workflows/docs-guard.yml:72-77` | H | Workflow propio con la compuerta del árbol · reutilizable llamado con `ruta: docs`; default: workflow propio |
| D-10 | ¿Qué controles bloquean y cuáles avisan, en qué carpeta? | Manda la tabla del proyecto. En `docs` bloquean los grupos con línea de base 0 (ver §7); `Guides` y `Concepts` avisan (heredado, líneas de base de A-08). Si la plataforma vuelve obligatorio el check: pendiente, sin configuración ni respuesta de la API | `tools/docs-guard/README.md:142-157`; A-08 | P | — |
| D-11 | ¿Quién decide qué? | Tres delegaciones del merge asentadas, con alcance en los expedientes 0003, 0002 y 0001; el PR de adopción no cae en ninguna: lleva reserva y lo fusiona una persona. Las actas citadas: pendiente, acta sin versionar en este árbol | `CHANGELOG.md:32-39`, `CHANGELOG.md:320-327`, `CHANGELOG.md:340-346`; tabla P/H `AGENTS.md:102-107` | H | Mapa medido · ampliar una delegación al PR de adopción; default: fusiona una persona |
| D-12 | ¿Qué canales hay para agentes? | `AGENTS.md` puntero, ya existente | `AGENTS.md:17-19`; `AGENTS.md:139` (cambiarlo es H) | H | `AGENTS.md` puntero · más un índice para agentes; default: puntero |
| D-13 | ¿Cómo es la ayuda al usuario final? | Ninguna: no hay producto con personas usuarias (corpus); única si se reabre | `README.md:16-17` | P | — |
| D-14 | ¿Qué es privado y cómo se nombra? | Alias por destino privado; el repo es público (evidencia secundaria). Lista: pendiente; barrido 12b con patrones genéricos | `AGENTS.md:109-110`; `tools/docs-guard/arbol.tsv:3-7`; comando 13 en `inventario/c13.txt` | P | — |
| D-15 | ¿Hay un cuerpo formativo? | Sí: el propósito declarado es enseñar | `README.md:16-17`; `Guides/README.md:16` | P | — |
| D-16 | ¿Idioma y estilo? | Castellano, el del proyecto. No se traducen: claves del frontmatter, IDs y prefijos, nombres de grupos (`PR-1` … `PR-7`) y `docs-guard` | `README.md:16-17`; `tools/docs-guard/esquemas/cuerpo.schema.json:7`; `tools/docs-guard/prefijos.txt:8-40` | P | — |
| D-17 | ¿Cómo es el carril programado? | El existente: semanal (lunes), frescura 365 días, vigila enlaces entre repos, atraso, deriva de fijadas, frescura y AI-3; sólo avisa, con un issue | `.github/workflows/docs-enlaces-semanal.yml:17-18`; `tools/docs-guard/README.md:191-205` | P | — |

## 3. Catálogo activo

Fila de partida: corpus de guías (CL-02, CL-03, CL-08 a CL-13; CL-01 sólo por A-01).

| Clase | Activa (sí o no) | Alta o baja frente al escenario, con motivo | Dónde vive (todas las ubicaciones) | Ancla | Evidencia |
| --- | --- | --- | --- | --- | --- |
| CL-01 | sí | Sólo por A-01 (fila) | `docs/_diseno/ficha-diseno-documental.md` | Commit | Esta ficha |
| CL-02 | sí | Fila | `docs/_requisitos.md` (A-04); posibles RRD dentro de `SDEI`, sin lectura | Commit | `CHANGELOG.md:14` (RRD propio `RD-21` a `RD-27` en el cuerpo) |
| CL-03 | sí | Fila | `AGENTS.md` en la raíz | Commit | `AGENTS.md:15-19` |
| CL-04 | no | Fila; los comentarios `///` del código (160 archivos `.cs`) son de las demos de guías, que son CL-10 | — | — | `command grep -rlI --include='*.cs' '^ *///' .` → 160; `Concepts/Framework-Concept/README.md:37` |
| CL-05 | no | Fila; los dos `Program.cs` con OpenAPI son ejemplos de guías (CL-10) | — | — | `Guides/Dot-NET-Arquitectura-Guide/Examples/Dot-NET-Arquitectura-Lab/MyProject/src/Backend/MyProject.WebAPI/Program.cs`; grupo PR-6: «contratos=0» (`verificacion/base-Guides-contrato.txt`) |
| CL-06 | no | Fila; sin personas usuarias de un producto | — | — | `inventario/c04.txt` (carpeta ausente) |
| CL-07 | no | Fila; la documentación de una demo que ilustra una guía es CL-10 | — | — | `inventario/c03.txt`; `Concepts/Framework-Concept/README.md:37` |
| CL-08 | no | Baja: D-12 no elige un índice para agentes (default) | — | — | `AGENTS.md:17-19` |
| CL-09 | sí | Fila | Repo hermano de documentación (sin verificar en el hermano) | Commit | `CHANGELOG.md:34`, `CHANGELOG.md:342` |
| CL-10 | sí | Fila; D-15 = Sí | `Guides/`, `Concepts/`, `Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/` (sin lectura) | Versión del cuerpo y etiqueta | `README.md:27-32`; `CHANGELOG.md:36` |
| CL-11 | no | Baja: el conocimiento de `Concepts/` es propio y sin huella declarada | — | — | `Concepts/Framework-Concept/Conocimientos/Knowledge-App-Hibrida-OTA-Offline-First.md:4` |
| CL-12 | sí | Fila | `docs/_gobierno/como-intervenir.md` (A-06); instancia posible en `SDEI`, sin lectura | Versión de la plantilla | `CHANGELOG.md:17` (instancia de «Cómo intervenir» en el cuerpo) |
| CL-13 | sí | Fila | `README.md`, `CHANGELOG.md` | Fecha | `README.md:14`; `CHANGELOG.md:3` |
| CL-14 | no | Fila; sin sitio (D-03) | — | — | `AGENTS.md:45-46` |

## 4. Decisiones de clase H para una persona

| Id | Estado (abierta, o «decidida por {actor}» con ruta:línea) | Opciones | Default propuesto | Quién decide |
| --- | --- | --- | --- | --- |
| D-03 | abierta | Sí · No | No | Responsable del producto |
| D-09 | abierta | Workflow propio con la compuerta del árbol · reutilizable con `ruta: docs` | Workflow propio, con `docs` en la RUTA (A-07) | Responsable del producto |
| D-11 | abierta para el PR de adopción; las tres delegaciones existentes, decididas por el PO (`CHANGELOG.md:34`, `CHANGELOG.md:322`, `CHANGELOG.md:342`), no se reabren | Fusiona una persona · ampliar una delegación | Fusiona una persona, con reserva | Responsable del producto |
| D-12 | abierta | `AGENTS.md` puntero · más un índice | Puntero; la fila nueva de A-11 en `AGENTS.md` | Responsable del producto |
| Cambiar `AGENTS.md` (A-11) y renovar su huella en `excepciones.txt` | abierta | Aplicar la fila · no tocar `AGENTS.md` | Aplicar la fila y renovar la huella en el mismo PR | Una persona (`AGENTS.md:139-142`) |
| Volver obligatorio el check `docs-guard` para `docs` (D-10) | abierta | Obligatorio · sólo avisa | Obligatorio cuando la línea de base de `docs` sea 0 | Responsable de la organización |

## 5. Artefactos A-02 a A-11

| Id | Producido (sí o no) | Ruta | Motivo si no se produce | Propuesta sujeta a (D-nn), si depende de una H abierta | «Sin probar», si falta la compuerta |
| --- | --- | --- | --- | --- | --- |
| A-02 | sí | `tools/docs-guard/prefijos.txt` (instancia existente, con `FIC` y `PRC` al final) | — | — | probado (§7) |
| A-03 | no | `tools/docs-guard/esquemas/cuerpo.schema.json` | La instancia existente ya tiene el vocabulario que piden los artefactos (DK-09) | — | — |
| A-04 | sí | `docs/_requisitos.md` | — | — | probado (§7) |
| A-05 | no | `AGENTS.md` | Ya existe un puntero; su cambio va por A-11 | D-12 | — |
| A-06 | sí | `docs/_gobierno/como-intervenir.md` | — | D-09, D-11 | probado (§7) |
| A-07 | sí | `.github/workflows/docs-guard.yml.cambio` (bloque que reemplaza el de `.github/workflows/docs-guard.yml:58-64`); guion `scripts/ci-local.sh` sin cambios | — | D-09, D-10 | sin probar en la CI; el guion local, probado (§7) |
| A-08 | sí | `docs/_diseno/linea-de-base.md` (texto para la descripción del PR); `tools/docs-guard/excepciones.txt` sin altas | — | — | probado |
| A-09 | no | — | Todo vive junto al código; el ancla es el commit (§2.4, fila I-19) | — | — |
| A-10 | no | `.github/workflows/docs-enlaces-semanal.yml` | El carril existente cumple D-17 | — | — |
| A-11 | sí | `A-11/CHANGELOG.md.entrada` (después de `CHANGELOG.md:4`); `A-11/AGENTS.md.entrada` (después de `AGENTS.md:54`) | — | D-12 (la de `AGENTS.md`) | — |

## 6. Lo que el conocimiento no resolvió

| Sección o decisión | Cita textual de lo que no resuelve | Qué quedó sin hacer |
| --- | --- | --- |
| §5.6, A-02 | «`DocsAsCode-Designing-Specification §5.6`, A-02, no resuelve: «No se agregan prefijos del proyecto al registro de origen ni se usa el de origen como registro del proyecto» cuando el proyecto es el repositorio de la compuerta» | Se tomó el registro existente del árbol como el del proyecto (instancia existente, DK-09) y se sumaron `FIC` y `PRC`; la autoprueba se corrió sobre esa misma configuración (§7) |
| §5.7, copia con huella | «`DocsAsCode-Designing-Specification §5.7` no resuelve: `{copia-proyecto}` y `{copia-origen}` cuando el proyecto ya es la compuerta de origen» | No se crearon `.docs-guard/` ni `.docs-guard-origen/` |
| §2.4, fila DE-24 | Carpeta sin lectura: `Sistema-De-Documentacion-E-Integracion` | Unicidad de IDs, RRD existente, instancia de «Cómo intervenir» y enlaces dentro del cuerpo `SDEI`: pendiente, sin lectura |
| Irregularidad del aplicador | — | Al empezar, el aplicador listó el directorio y leyó la carta con un comando de consola fuera de `./aislado` (sólo lectura, dentro del directorio de la corrida). Ningún valor de esta ficha sale de esa lectura. En el par rojo/verde, un `cp` a `/tmp` dentro del contenedor efímero de `./aislado` (sin efecto fuera de él); y la sección 7 se completó con un guion de Python y un `cp` corridos fuera de `./aislado`, escribiendo sólo en `salida/` |

## 7. Verificación (§6)

| Comprobación | Comando | Resultado (salida textual) |
| --- | --- | --- |
| Compuerta sobre los artefactos, con A-02 y A-03 (copia de §5.7 y su huella) | En una copia del árbol (sin la carpeta sin lectura) con A-02 aplicado y A-01, A-04, A-06 y A-08 montados en `docs`: `bash scripts/ci-local.sh {grupo} docs`, un grupo por vez (`npm_config_offline=true`, cachés del montaje) | `esquema` «PR-2 esquema: verde (errores=0 avisos=0) archivos-con-frontmatter=4»; `ai` «PR-3 anti-inyeccion: verde (errores=0 avisos=1)» (el aviso es AI-3 en `AGENTS.md:17`); `estructura` «PR-4 mermaid: verde» y «mermaid-arroba: verde»; `contrato` «verde, contratos=0»; `fijadas` «PR-7 fijadas: verde», «reflint: verde», «url-fecha: verde»; `trazas` con `DOCS_GUARD_TRAZAS_EXTRA=""` «PR-5 traces-resolve: verde (errores=0 avisos=0) trazas=4 resueltas=4»; con los punteros de la raíz, ROJO por 8 trazas de `AGENTS.md`, `README.md` y `Guides/README.md` a IDs de la carpeta sin lectura; `enlaces` ROJO, «11 Errors», todos enlaces de `AGENTS.md` a la carpeta sin lectura. Salidas en `verificacion/docs-*.txt` |
| Par rojo/verde plantado, con la compuerta de D-09 | Traza plantada `FIC-NO-EXISTE` en `traces` de `docs/_gobierno/como-intervenir.md`; `DOCS_GUARD_TRAZAS_EXTRA="" bash scripts/ci-local.sh trazas docs`; después, la traza quitada y la misma corrida | Con la traza: «== PR-5 traces-resolve: ROJO (errores=1 avisos=0) trazas=5 resueltas=4», rc=1. Sin ella: «== PR-5 traces-resolve: verde (errores=0 avisos=0) trazas=4 resueltas=4», rc=0 |
| Autoprueba de la compuerta de origen (sin red ni caché: «pendiente», con el comando, §5.7) | `npm_config_offline=true bash scripts/ci-local.sh autoprueba docs` (la compuerta del árbol, con A-02 aplicado) | rc=0; «ok AK-7 fixture permanente rojo (rc=1; AI-1..AI-5 detectados)»; «== autoprueba: verde» (`verificacion/autoprueba.txt`) |
| Chequeo de citas ruta:línea (§3.5; cada cita repite el archivo, sin `:n` sueltas) | El bloque de §3.5 sobre esta ficha, desde `repo/LD` (`verificacion/verif.sh`); además `grep` de `:n` sueltas | Salida vacía (52 citas distintas); `:n` sueltas: ninguna (rc=1) |
| Muestra de cinco citas releídas contra lo que afirman (§3.5) | `sed -n` sobre cada cita | `AGENTS.md:45-46` dice «sin sitio publicado» (D-03): sostiene. `.github/workflows/docs-guard.yml:75` dice `repository: {organizacion}/Lab-Documentos` (D-01 · organización): sostiene. `tools/docs-guard/prefijos.txt:27` dice «RD interno requerimiento documental (RRD)»: sostiene. `Concepts/Framework-Concept/Demo/tools/FrameworkConcept.Receptor/AutenticacionDelReceptor.cs:70` tiene una sola `AddPolicy` (D-01, sin roles): sostiene. `.github/workflows/docs-enlaces-semanal.yml:18` dice `cron: "17 6 * * 1"` (D-17, lunes): sostiene |
| Barrido por `{lista-privada}` (§3.6; sin la lista, comando 12b y «lista: pendiente») | 12b sobre la ficha y los artefactos de la salida (IPv4, rutas de usuario, `hostname -s` del entorno y un `-e` por cada etiqueta de runner y organización del inventario) | Sin salida, rc=1. Lista: pendiente (no hay `{lista-privada}`). Sobre el árbol heredado, el 12b da 235 líneas (`inventario/c12b.txt`), fuera del alcance de la adopción |
