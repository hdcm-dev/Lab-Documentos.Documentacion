---
doc_id: FIC-DISENO-DOCUMENTAL
doc_type: ficha
title: Ficha de diseño documental de Fábrica de Geometría
description: Decisiones, catálogo activo y verificación del sistema documentador de Fábrica de Geometría.
status: borrador
origin: ia-generated
confidence: media
owner: Product Owner
last_review: 2026-11-02
audience: [desarrollo, po, agente]
traces: []
---

# Ficha de diseño documental — Fábrica de Geometría

Destino en el repositorio: `docs/_diseno/ficha-diseno-documental.md` de `Lab-Geometria` (copia montada en
`salida/LG/docs/_diseno/ficha-diseno-documental.md`). Las citas llevan el repositorio como prefijo (`LG/` =
Lab-Geometria, `LGD/` = Lab-Geometria.Documentacion) y se leen desde la carpeta `repo/` que los contiene. Las salidas
completas de los comandos están en `salida/inventario/`.

| Campo | Valor |
| --- | --- |
| Proyecto y repositorios leídos, con SHA | Fábrica de Geometría: `LG` y `LGD`. Ninguno trae `.git` (`./aislado git -C repo/LG log -1` → «fatal: not a git repository»; igual para `LGD`): **SHA: pendiente**. Huella del árbol (comando 11, `LC_ALL=C`), desde `repo/`: `0355c45f63f4f052482daf72cbdaedf5a515af57b63c6f0a9ec703d782450ed8`; por repositorio: `LG` `e2ccd06a7e48bf6536b56ae4445f4eb731c0d5583590136a5199d6497c24d01d`, `LGD` `92b7eee5b71d6046d2359b9098d2f6a5538240959666438e4207309f9485eb46` (`salida/inventario/c11.txt`) |
| Carpetas excluidas o sin lectura (`{excluidas}`) | (ninguna). `find repo -type d ! -readable` → salida vacía; el encargo no excluye carpetas |
| Fecha | 2026-11-02 (de `montaje.txt`, por la carta del aplicador; el comando 10 no se usa para este campo) |
| Quién aplica | aplicador |
| Conocimiento aplicado | `DocsAsCode-Designing-Specification`, versión 1.3, SHA-256 de `conocimiento.md` `8a3122671827a4777c112477a1a76603ac294f9b3ce386da857cda1c9543279e` |

## 1. Inventario (paso 1)

Todos los comandos corrieron con `./aislado`, desde `repo/` (carpeta que contiene los dos repositorios), con
`EXC=()` y por lo tanto `X=(--exclude-dir=.git)` y `P=(-name .git)`.

| Patrón de §3.1 | Comando | Cuenta | Salida o ruta a la salida |
| --- | --- | --- | --- |
| ID declarado más de una vez | 1: `python3 ../compuerta/tools/docs-guard/dg.py trazas --raiz . .`; también 1b | 1: 960 IDs duplicados (995 errores, rc=1); 1b: 388 IDs repetidos | `salida/inventario/c01.txt` (última línea: «PR-5 traces-resolve: ROJO (errores=995 avisos=0) trazas=35 resueltas=0 ids-duplicados=960»); por repositorio `c01-LG.txt` (897) y `c01-LGD.txt` (21); `c01b.txt`. Buena parte son copias congeladas en `_legacy/` |
| Versión declarada dos veces | 2 | 9 archivos (rc=0) | `salida/inventario/c02.txt`: tres `11-Documentacion/README.md` vigentes de `LG/SDD/Docs` y seis bajo `_legacy/` |
| Estado «planificado» o equivalente (y la proporción planificada) | 3 literal: `{carpeta-tecnica}` = `docs/tecnica` | 0 (rc=2, «carpeta ausente»: «grep: docs/tecnica: No such file or directory») | `salida/inventario/c03-literal.txt`. Comando adaptado sobre la ubicación real de CL-07, `LG/SDD/Docs`: 4575 líneas; 1084 de 1186 archivos `.md` con el patrón (490 de 560 sin `_legacy/`), `salida/inventario/c03-adaptado.txt`. La proporción por estado de documento queda **pendiente**: el patrón cuenta menciones, no estados, y el estado de cada documento SDD vive en una tabla de cabecera (p. ej. `LG/SDD/Docs/README.md:7`), no en un campo uniforme |
| Traza de la interfaz a una unidad que no le corresponde | 4, adaptado: `{carpeta-ayuda}` = `LG/src/GeometriaFactory.Web` (no hay pieza CL-06) | 0 (rc=1) | `salida/inventario/c04.txt` |
| Puntero a un documento obsoleto o ausente | 5, por repositorio | `LG`: 1 CHANGELOG, 16 líneas con el patrón (rc=0); `LGD`: 1 CHANGELOG, 0 (rc=1) | `salida/inventario/c05.txt`. Contra el árbol: `LG/changelog.md:1776` declara retirado el canal `deploy-front-ftp` y `LG/.github/workflows/deploy-front-ftp.yml` sigue en el árbol; `LG/changelog.md:1767` nombra `scripts/verify-stage-i.sh`, que existe |
| Advertencia del índice del proyecto | 6, `{indice}` = `LGD/ia-db/README.md` y `LGD/ia-db/indexes/*.md` | 98 (suma de `c06-cuenta.txt`; rc=0) | Lista en `salida/inventario/c06.txt`. Cada una pasa a reserva con estado «abierta, sin revisar» (§4, fila R-IDX) |
| Espacios de IDs en uso, con su origen y sus choques | 7 | 142 prefijos | `salida/inventario/c07.txt`. Origen marco SDD: `CU` 20111, `RN` 16207, `BT` 9733, `US` 9684, `ADR` 9344, `NB` 5020, `TC` 3963, `PT` 3862, `QG` 2669, `AG` 1870, `DOC` 12. Origen informes de mesa y auditoría (`LG/SDD/Docs/Audit/`, `LGD/PROMPTs/`): `A`, `B`, `C`, `D`, `E`, `H`, `O`. **Chocan con los Id de esta ficha**: `A` 4046, `D` 1155, `CL` 1025, `I` 174; `DE` no aparece. Los Id de esta ficha no se declaran como IDs del repositorio (no van en `doc_id` ni en encabezados `# ID —`) |
| Plataformas que compila cada máquina | 8 | 1 | `<TargetFramework>net10.0` (`salida/inventario/c08.txt`): sólo Linux; plataforma → runner: Linux → `ubuntu-latest` (`LG/.github/workflows/ci.yml:47`) |
| Prefijos nuevos libres | 9, uno por prefijo | `RD` 0, `FIC` 0, `PRC` 0, `AUD` 0 | `salida/inventario/c09.txt` |
| Barrido sin lista privada | 12b, con `-e {etiqueta-runner}` (etiqueta de runner del inventario) y `hostname -s` del contenedor | 130 líneas (rc=0) | `salida/inventario/c12b.txt`; ver D-14 |
| Visibilidad | 13, por repositorio | `LG` rc=0; `LGD` rc=2 (sin `AGENTS.md`) | `salida/inventario/c13.txt` |
| Markdown con y sin frontmatter | `find` + `awk` de la primera línea `---` | `LG` 1288 `.md`, 7 con frontmatter; `LGD` 57, 0 | `salida/inventario/md-frontmatter.txt` |
| Inventario de autorización (D-01) | `grep -rnE "Authorize\|AddPolicy\|RequireRole\|…"` y `grep` de `Role.` en `LG/src` | 2 roles | `salida/inventario/autorizacion.txt`; el grep de `Role.` se citó en D-01 |

## 2. Decisiones

| Id | Pregunta | Valor | Evidencia (ruta:línea en el SHA leído, o «pendiente: qué falta») | Clase (P o H) | Si es H: opciones y default para la persona |
| --- | --- | --- | --- | --- | --- |
| D-01 | ¿Escenario y contextos? | Panel con roles. Roles: `Student` («Alumno») y `Administrator` («Administrador»), con permisos distintos. Superficies: panel web (Blazor) y API REST `/v1/` con documento OpenAPI y explorador. Audiencias declaradas: alumno y docente; la API se expone a aplicaciones propias. Sin paquetes publicados | `LG/src/GeometriaFactory.Domain/Values/Role.cs:12-19`; `LG/src/GeometriaFactory.Api/Endpoints/WorkEndpoints.cs:106` (sólo alumno); `LG/src/GeometriaFactory.Application/Accounts/GovernCommissionAccountsUseCase.cs:61` (sólo administrador); `LG/src/GeometriaFactory.Infrastructure/Security/AccessTokenIssuer.cs:25` (claim de rol); `LG/src/GeometriaFactory.Web/Services/SessionState.cs:110` (menú por rol); `LG/src/GeometriaFactory.Api/Composition/ApiDocumentation.cs:37`, `LG/src/GeometriaFactory.Api/Composition/ApiDocumentation.cs:117` y `LG/src/GeometriaFactory.Api/Composition/ApiDocumentation.cs:119` (OpenAPI y explorador); `LG/SDD/Docs/README.md:40`; paquetes: `grep -rn "IsPackable\|PackageId"` sólo da `IsPackable false` en pruebas y samples | P | — |
| D-01 · sitio | ¿Hay sitio publicado? | Remite a D-03: No (propuesto) | Ver D-03 | H | Ver D-03 |
| D-01 · marco | ¿Hay marco de especificación? | Sí: framework SDD, procedencia 13.16; vive en un repositorio aparte y su salida está en `LG/SDD/` | `LG/SDD/README.md:3`; `LG/SDD/Docs/README.md:176` | P | — |
| D-01 · topología | ¿Mismo repo, hermano o dedicado? | Mismo repo (código y `SDD/` en `LG`) más repo hermano `LGD` (índice para agentes, análisis, prompts) | `LG/SDD/README.md:5`; `LGD/README.md:3` | P | — |
| D-01 · organización | ¿Dentro o fuera de la organización del runner (medido)? | pendiente: organización | Sin `.git` no hay remoto `origin` que medir; las líneas `uses:` sólo nombran acciones públicas (`actions/*`, `SamKirkland/FTP-Deploy-Action`), `grep -n "uses:" LG/.github/workflows/*.yml LGD/.github/workflows/*.yml`. No se demanda (§3.5) | P | — |
| D-02 | ¿Qué clases de pieza se activan? | CL-01 a CL-09, CL-12, CL-13. Altas frente a la fila: CL-09 y CL-13. Bajas: ninguna de la fila | §3 de esta ficha | P | — |
| D-03 | ¿Hay sitio publicado? | No (default). La API sirve su referencia en `/documentacion` (Scalar), que es la salida de CL-05, no un sitio de documentación | `find LG LGD -iname "mkdocs.y*ml" -o -iname docfx.json -o -iname "docusaurus.config.*"` → vacío (rc=1); `LG/src/GeometriaFactory.Api/Composition/ApiDocumentation.cs:40` | H | Abierta: Sí · No; default No |
| D-04 | ¿Hay marco de especificación con registro de IDs? | Sí, el del marco SDD, con IDs en encabezados y `doc_id` dentro del repo; **la unicidad no se cumple**: el control de trazas da 960 IDs duplicados (mayormente copias de `_legacy/`). Los IDs SDD entran como prefijos externos de A-02; los nuevos, como internos | Comando 1 (`salida/inventario/c01.txt`), 1b (`c01b.txt`), 2 (`c02.txt`); `LG/SDD/Docs/Producto/11-Documentacion/Contrato-Agentes.md:2` (ejemplo de `doc_id`) | P | — |
| D-05 | ¿Dónde vive cada pieza? | Mismo repo `LG`: CL-01, CL-02, CL-03, CL-06, CL-07 (`SDD/`), CL-12, CL-13; build: CL-04 y CL-05; repo hermano `LGD`: CL-08, CL-09, y también CL-03 y CL-13 propias. Detalle en §3 | I-20 aplicado: CL-04 y CL-05 las emite el build (`LG/Directory.Build.props:26`, `LG/src/GeometriaFactory.Api/Composition/ApiDocumentation.cs:117`); índice y prompts hablan del proyecto (`LGD/README.md:3-5`) | P (CL-03 y CL-12 sujetas a D-12) | — |
| D-06 | ¿Contra qué ancla vale cada pieza? | Commit para lo que vive en `LG`; SHA fijado para `LGD/ia-db` (A-09). Mecanismo actual: ancla en prosa, revisión `4b114d7` etiquetada `v1.2.0`. Líneas de versión: etiquetas `v*` calculadas por MinVer; la lista de etiquetas queda **pendiente: sin `.git`** | `LGD/ia-db/README.md:38`; `LGD/ia-db/README.md:128`; `LG/.github/workflows/ci.yml:50` | P | — |
| D-07 | ¿Qué prefijos e IDs? | Registro del proyecto (A-02): internos `FIC`, `RD`, `PRC`, `AUD` (libres, comando 9 en 0); externos los del marco SDD medidos con el comando 7. Los IDs duplicados heredados van a A-08 y a un saneamiento aparte | `salida/inventario/c09.txt`, `c07.txt`; sin tabla P/H escrita del proyecto: prefijo del registro propio → P | P | — |
| D-08 | ¿Qué esquema de frontmatter? | Diez campos más `description` para lo nuevo (`docs/`), con vocabulario propio en A-03; el frontmatter SDD heredado (12 archivos) avisa y no se mapea | `LG/SDD/Docs/Producto/11-Documentacion/Contrato-Agentes.md:1-14` (esquema SDD distinto: `rol_intervencion`, `momento`); `salida/inventario/linea-de-base.txt` (esquema: 107 errores en `LG`) | P | — |
| D-09 | ¿Cómo corre la compuerta? | Copia con huella de la compuerta de origen en `.docs-guard/` (y `.docs-guard-origen/` para la autoprueba), en el runner Linux del proyecto `ubuntu-latest`. El reutilizable no aplica: la organización no se pudo medir y el proyecto declara prefijos y vocabulario propios | `LG/.github/workflows/ci.yml:47`; comando 8 (Linux); huellas `dg.py` `471936d8…bdbf`, `ci-local.sh` `5d07aed1…851d` (`sha256sum`) | H | Abierta: reutilizable · copia con huella; default copia con huella |
| D-10 | ¿Qué controles bloquean y cuáles avisan, en qué carpeta? | `docs/` (nueva): los grupos PR-1 a PR-7 tienen línea de base 0 y par rojo/verde en la autoprueba; quedan en **avisa** hasta que la plataforma pueda volver obligatorio el check, y pasan a bloquear con ese acto H. `SDD/`, raíz y `LGD`: avisan, con la línea de base de A-08. Que la plataforma impida el merge: **pendiente** (sin configuración ni respuesta de la API). No hay tabla de bloqueo previa del proyecto | `salida/inventario/linea-de-base.txt`; §8 de esta ficha; `LG/docs` no existe (`ls LG/docs` → «No such file or directory») | P | — |
| D-11 | ¿Quién decide qué? | Mapa de delegaciones: en `LG`, el agente fusiona y borra la rama con checks en verde y sin reserva; en `LGD`, el agente fusiona con la guarda G1–G4 y sin reserva. Lo demás lo fusiona el Product Owner. Visto bueno de §7 del README del producto: el Orquestador SDD; en su ausencia, el Product Owner. El PR de adopción lleva reserva (H abiertas) y lo fusiona el Product Owner | `LG/AGENTS.md:65` (derivado de `LG/SDD/Docs/Producto/11-Documentacion/Contrato-Agentes.md`, `LG/AGENTS.md:3`); `LGD/README.md:11-27`; `LG/SDD/Docs/README.md:13` | H | Decidida por el Product Owner (delegaciones citadas); ver §4 |
| D-12 | ¿Qué canales hay para agentes? | `AGENTS.md` puntero en cada repo (en `LG` ya existe, derivado; en `LGD`, nuevo) y el índice `LGD/ia-db/` como punto de entrada de A-11. Sin canales derivados (D-03 No) | `LG/AGENTS.md:3-5`; `LGD/README.md:35-39`; `ls repo/LGD` sin `AGENTS.md` (comando 13: «grep: AGENTS.md: No such file or directory») | H | Abierta: `AGENTS.md` puntero · índice · ambos; default ambos (puntero más el índice existente) |
| D-13 | ¿Cómo es la ayuda al usuario final? | Por rol (D-01 da dos roles con permisos distintos); en el punto de uso: ninguno hoy. Un solo idioma (castellano para personas): no hay archivos `.resx`. Las pantallas trazan a los casos de uso `CU` de la unidad Web | `LG/AGENTS.md:36`; `find LG/src -name "*.resx"` → vacío; comando 7 (`CU`); `LG/SDD/Docs/Unidades-Entrega/GeometriaFactory-Web/02-Especificacion-Funcional/Casos-De-Uso/` | P | — |
| D-14 | ¿Qué es privado y cómo se nombra? | Alias más barrido. `LG` es público; `LGD`: **pendiente** (sin evidencia de visibilidad). Destinos privados medidos con 12b: rutas de usuario y nombre de máquina en `LG/SDD/` (p. ej. `LG/SDD/Maquetas/GeometriaFactory-Web/README.md:36`), la etiqueta de runner en `LG/.github/workflows/e2e.yml:69`, un nombre de persona en `LGD/README.md:19`. Alias: `{etiqueta-runner}`, `{dir-de-trabajo}`, `{persona}`. Lista: **pendiente** (no hay `{lista-privada}`) | `LG/README.md:3`; `LG/.github/workflows/e2e.yml:70`; `salida/inventario/c12b.txt`, `c13.txt` | P | — |
| D-15 | ¿Hay un cuerpo formativo? | No: el producto se usa en una cátedra, pero el repositorio no declara que enseñe | `LG/README.md:3`; `LG/SDD/Docs/README.md:36-38` | P | — |
| D-16 | ¿Idioma y estilo? | Los del proyecto: castellano para personas; identificadores de código en inglés. No se traducen: claves del frontmatter, IDs, `Student`/`Administrator`, rutas `/v1/`, `/openapi/v1.json` | `LG/AGENTS.md:36`; `LG/src/GeometriaFactory.Domain/Values/Role.cs:15`; `LG/src/GeometriaFactory.Api/Composition/ApiDocumentation.cs:37` | P | — |
| D-17 | ¿Cómo es el carril programado? | Semanal; frescura 365 días; vigila el atraso del SHA de `LGD/ia-db/source.lock` contra `main` de `LG` y la deriva; sólo avisa, con issue. El proyecto no fija otra frecuencia | `grep -rn "schedule\|cron" LG/.github LGD/.github` → vacío (rc=1) | P | — |
| D-18 | ¿Audiencias y entrega? | Perfil mínimo más la extensión «superficie» (registrada en D-01). Roles sin jerarquía (`incluye` vacío): el administrador no hace lo del alumno. Repo público: sólo `publico` y `producto` en fuentes del repo | `LG/src/GeometriaFactory.Api/Endpoints/WorkEndpoints.cs:106`; `LG/.github/workflows/e2e.yml:70`; A-12 | P | — |

## 3. Catálogo activo

| Clase | Activa (sí o no) | Alta o baja frente al escenario, con motivo | Dónde vive (todas las ubicaciones) | Ancla | Evidencia |
| --- | --- | --- | --- | --- | --- |
| CL-01 | sí | En la fila | `LG/SDD/` (especificación SDD) y `LG/docs/_diseno/` (A-01) | Commit | `LG/SDD/README.md:3` |
| CL-02 | sí | En la fila; no hay RRD previo (A-04 nuevo) | `LG/docs/_requisitos.md` | Commit | Comando 9: `RD` 0 |
| CL-03 | sí | En la fila | `LG/AGENTS.md` (derivado de `Contrato-Agentes.md`); `LGD/AGENTS.md` (nuevo, propuesta sujeta a D-12) | Commit | `LG/AGENTS.md:3` |
| CL-04 | sí | En la fila; fuente presente (comentarios XML) y generación apagada: control **pendiente**, línea de base sin medir (no hay `dotnet` en el entorno aislado) | Build | Commit | `LG/Directory.Build.props:26`; `LG/src/GeometriaFactory.Domain/Values/Role.cs:14` |
| CL-05 | sí | En la fila; el contrato se genera en ejecución y no hay paso que lo extraiga: control **pendiente**, línea de base 0 contratos | Build más un paso de la CI que levanta el servicio | Commit | `LG/src/GeometriaFactory.Api/Composition/ApiDocumentation.cs:117`; `salida/inventario/linea-de-base.txt` (contratos=0) |
| CL-06 | sí | En la fila; sin pieza todavía (RD-06) | `LG` (repo de la interfaz), carpeta por crear | Commit y versión del ID trazado | Comando 4 adaptado: 0 |
| CL-07 | sí | En la fila; vive en `SDD/Docs/` y no en `docs/tecnica/` | `LG/SDD/Docs/` | Commit | `LG/SDD/Docs/README.md:140`; comando 3 literal rc=2 |
| CL-08 | sí | En la fila | `LGD/ia-db/` | SHA fijado `4b114d7` (A-09); etiqueta `v1.2.0` | `LGD/ia-db/README.md:38` |
| CL-09 | sí | Alta: hay expedientes, informes de auditoría y prompts | `LG/SDD/Expedientes/`, `LG/SDD/Docs/Audit/`, `LGD/PROMPTs/`, `LGD/Analisis/` | Commit | `LG/SDD/README.md:7-8`; `LGD/README.md:3-5` |
| CL-10 | no | Fuera de la fila; D-15 No | — | — | `LG/README.md:3` |
| CL-11 | no | Fuera de la fila; no hay copias con huella | — | — | `dg.py fijadas`: piezas=0 en los dos repos (`salida/inventario/linea-de-base.txt`) |
| CL-12 | sí | En la fila; A-06 nuevo | `LG/docs/_gobierno/como-intervenir.md` (propuesta sujeta a D-12) | Versión de la plantilla | Comando 9: `PRC` 0 |
| CL-13 | sí | Alta: hay README y registro de cambios en los dos repos | `LG/README.md`, `LG/changelog.md`, `LGD/README.md`, `LGD/changelog.md` | Fecha de cada entrada | Comando 5: un CHANGELOG por repo; `LG/SDD/Docs/README.md:148` |
| CL-14 | no | Fuera de la fila; D-03 No | — | — | Ver D-03 |

## 4. Decisiones de clase H para una persona

| Id | Estado (abierta, o «decidida por {actor}» con ruta:línea) | Opciones | Default propuesto | Quién decide |
| --- | --- | --- | --- | --- |
| D-03 | abierta | Sí · No | No | Product Owner |
| D-09 | abierta | Workflow reutilizable · copia con huella en el runner del proyecto | Copia con huella en `ubuntu-latest` | Product Owner |
| D-11 | decidida por el Product Owner: `LG/AGENTS.md:65` y `LGD/README.md:19-27` | — | — | Product Owner |
| D-12 | abierta | `AGENTS.md` puntero · índice · ambos | Ambos: puntero en cada repo (el de `LG` por su fuente) y `LGD/ia-db/` como entrada | Product Owner |
| A-05 en `LG` | abierta (CL-03 es H; `LG/AGENTS.md` se regenera desde su fuente) | Cambiar `Contrato-Agentes.md` · dejar `AGENTS.md` como está | Cambiar la fuente con la propuesta de `salida/LG/SDD/Docs/Producto/11-Documentacion/Contrato-Agentes.md.propuesta-A-05.md` | Product Owner |
| Check obligatorio (D-10) | abierta | Volver obligatorio `docs-guard` antes del merge · dejarlo en aviso | Dejarlo en aviso hasta confirmar que el plan lo permite | Product Owner |
| Fusión del PR de adopción | abierta (lleva reserva por las H abiertas) | Fusionar · pedir cambios | Revisar y fusionar después de decidir D-03, D-09 y D-12 | Product Owner |
| R-IDX | abierta, sin revisar | Revisar cada una de las 98 advertencias del índice · diferirlas | Revisarlas en el saneamiento aparte | Product Owner |

## 5. Audiencias y entrega (D-18)

Perfil mínimo más la extensión «superficie» (fila D-01 de §2). Registro en A-12.

| Audiencia (fila de A-12) | Incluye | Nivel de acceso | Punto de aplicación | Par de entrega | Evidencia |
| --- | --- | --- | --- | --- | --- |
| alumno | — | producto | servidor | pendiente: sin servicio levantado (sin red ni `dotnet`) | `LG/src/GeometriaFactory.Domain/Values/Role.cs:15` |
| administrador | — | producto | servidor | pendiente: igual | `LG/src/GeometriaFactory.Domain/Values/Role.cs:18` |
| consumidor-api | — | publico | servidor | pendiente: igual | `LG/src/GeometriaFactory.Api/Composition/ApiDocumentation.cs:37`; `LG/SDD/Docs/README.md:40` |
| desarrollo | — | publico | repositorio | no aplica: repo público | `LG/.github/workflows/e2e.yml:70` |

## 6. Artefactos A-02 a A-13

| Id | Producido (sí o no) | Ruta | Motivo si no se produce | Propuesta sujeta a (D-nn), si depende de una H abierta | «Sin probar», si falta la compuerta |
| --- | --- | --- | --- | --- | --- |
| A-02 | sí | `salida/LG/.docs-guard/tools/docs-guard/prefijos.txt` | — | D-09 | Probado (§8) |
| A-03 | sí | `salida/LG/.docs-guard/tools/docs-guard/esquemas/cuerpo.schema.json` (sin nota aparte) | — | D-09 | Probado (§8) |
| A-04 | sí | `salida/LG/docs/_requisitos.md` | — | — | Probado (§8) |
| A-05 | sí | `salida/LGD/AGENTS.md`; para `LG`, `salida/LG/SDD/Docs/Producto/11-Documentacion/Contrato-Agentes.md.propuesta-A-05.md` (el `AGENTS.md` es derivado) | — | D-12 | `LGD`: sin probar con su compuerta (`LGD` no tiene la copia) |
| A-06 | sí | `salida/LG/docs/_gobierno/como-intervenir.md` | — | D-09, D-12 | Probado (§8) |
| A-07 | sí | `salida/LG/.github/workflows/docs-guard.yml`; guion: `salida/LG/.docs-guard/` y `salida/LG/.docs-guard-origen/` | — | D-09 | El guion se probó local (§8); el workflow, sin probar en la CI |
| A-08 | sí | `salida/LG/docs/_gobierno/linea-de-base.md` (texto de la descripción del PR) y `salida/LG/.docs-guard/tools/docs-guard/excepciones.txt` (vacío) | — | D-09 | Probado (§8) |
| A-09 | sí | `salida/LGD/ia-db/source.lock` (SHA `4b114d7`, abreviado; el completo, **pendiente**: sin `.git`) | — | — | Sin probar (el atraso necesita red) |
| A-10 | sí | `salida/LGD/.github/workflows/docs-semanal.yml` | — | D-09 | Sin probar: necesita red, y el `arbol.tsv` de la copia es el del origen (pendiente de reemplazar) |
| A-11 | sí | `salida/A-11-entradas.md` (dos destinos: `LGD/ia-db/README.md` y `LG/changelog.md`) | — | D-12 | No aplica |
| A-12 | sí | `salida/LG/docs/_gobierno/registro-audiencias.md` | — | — | Probado (§8) |
| A-13 | sí | `salida/LG/docs/_gobierno/controles-de-entrega.md` | — | — | Probado su frontmatter (§8); los controles, pendientes |

## 7. Lo que el conocimiento no resolvió

| Sección o decisión | Cita textual de lo que no resuelve | Qué quedó sin hacer |
| --- | --- | --- |
| §3.1, patrón 3 | «`DocsAsCode-Designing-Specification §3.1`, patrón 3, no resuelve: cómo sacar «el estado de cada documento» cuando el corpus no lo declara en un campo uniforme» | La proporción planificada por estado quedó pendiente; se informó la proporción por mención |
| D-04 | «`DocsAsCode-Designing-Specification §3.2`, D-04, no resuelve: qué opción vale cuando el marco tiene registro en el repo pero sus IDs están duplicados por copias congeladas» | Se eligió «Sí» y la unicidad quedó como saneamiento aparte (A-08) |
| A-10 | «`DocsAsCode-Designing-Specification §5.7` no resuelve: qué `arbol.tsv` usa el carril programado de un proyecto» | El `arbol.tsv` del proyecto queda pendiente |

## 8. Verificación (§6)

| Comprobación | Comando | Resultado (salida textual) |
| --- | --- | --- |
| Compuerta sobre los artefactos, con A-02 y A-03 | `bash salida/montar.sh` (copia de `repo/LG` más `salida/LG` en `salida/_montaje/LG`, borrada al final); desde ahí `bash .docs-guard/scripts/ci-local.sh <grupo> docs` para enlaces, esquema, ai, estructura, trazas, contrato y fijadas | Los siete con rc=0: «PR-1 fuera-del-repo: verde (errores=0 avisos=0)»; «PR-2 esquema: verde (errores=0 avisos=1) archivos-con-frontmatter=6» (el aviso: `traces-vacio` de esta ficha); «PR-3 anti-inyeccion: verde (errores=0 avisos=0)»; «Summary: 0 error(s)» y «PR-4 mermaid-arroba: verde»; «PR-5 traces-resolve: verde (errores=0 avisos=0) trazas=6 resueltas=6 ids-duplicados=0»; «PR-6 contratos: verde»; «PR-7 fijadas: verde», «PR-7 reflint: verde», «PR-7 url-fecha: verde» |
| Par rojo/verde plantado, con la compuerta de D-09 | Se agregó `FIC-NO-EXISTE` a `traces` de `docs/_gobierno/como-intervenir.md` en el montaje y se corrió `ci-local.sh trazas docs`; después se restauró y se volvió a correr | Rojo: «ERROR traza-no-resuelve: FIC-NO-EXISTE: el ID no está declarado en el registro» y «PR-5 traces-resolve: ROJO (errores=1 avisos=0) trazas=7 resueltas=6», rc=1. Verde: «PR-5 traces-resolve: verde (errores=0 avisos=0) trazas=6 resueltas=6», rc=0 (`salida/inventario/par-rojo-verde.txt`) |
| Autoprueba de la compuerta de origen | `bash .docs-guard-origen/scripts/ci-local.sh autoprueba docs`, con la caché del montaje (`DOCS_GUARD_CACHE=/opt/docs-guard`, `npm_config_cache=/opt/npm-cache`, `npm_config_offline=true`) | «ok AK-7 fixture permanente rojo (rc=1; AI-1..AI-5 detectados)»; «== autoprueba: verde» |
| Chequeo de citas ruta:línea | El bloque de §3.5 sobre esta ficha, desde `repo/` | Salida vacía (entre «== citas» y «== fin citas» no salió ninguna línea NO EXISTE ni FUERA DE RANGO) |
| Muestra de cinco citas releídas | Lectura de cada línea | `LG/src/GeometriaFactory.Domain/Values/Role.cs:12-19`: el enum `Role` con `Student` y `Administrator`. `LG/Directory.Build.props:26`: `GenerateDocumentationFile` en `false`. `LG/.github/workflows/e2e.yml:70`: «El repositorio es público». `LGD/ia-db/README.md:38`: revisión `4b114d7` etiquetada `v1.2.0`. `LG/AGENTS.md:65`: «Fusionar un PR y borrar su rama \| Lo hace el agente, por decisión del Product Owner» |
| Barrido por `{lista-privada}` | Sin la lista: comando 12b sobre `LG` y `LGD`; sobre los artefactos: `grep -rnIiE -e '[0-9]{1,3}(\.[0-9]{1,3}){3}' -e '/(home\|Users)/[a-z]' -e {etiqueta-runner} salida/LG/docs salida/LGD salida/A-11-entradas.md` | Lista: **pendiente**. Repos: 130 líneas (`salida/inventario/c12b.txt`), que van al saneamiento de D-14. Artefactos (con la etiqueta real en lugar de {etiqueta-runner} y un `-e` por cada parte del nombre de {persona}): salida vacía, rc=1 |

## 9. Suposiciones

| Qué se supuso | Por qué |
| --- | --- |
| `{indice}` es `LGD/ia-db/README.md` más `LGD/ia-db/indexes/*.md` | `LGD/README.md:35-39` lo nombra como entrada única con manifiesto |
| El runner Linux del proyecto para la compuerta es `ubuntu-latest` y no la etiqueta propia | `LG/.github/workflows/ci.yml:47` corre las puertas de cada pull request ahí; la etiqueta propia sólo corre E2E (`LG/.github/workflows/e2e.yml:69`) |
| «docente» del producto es el rol `Administrator` | `LG/SDD/Docs/README.md:38` («el docente habilita cuentas») y `LG/src/GeometriaFactory.Application/Accounts/GovernCommissionAccountsUseCase.cs:61` |
| El par rojo/verde usó una copia temporal del archivo dentro del contenedor (`/tmp` del contenedor, efímero y descartado) | Restaurar el archivo; no quedó nada fuera de `salida/` |
