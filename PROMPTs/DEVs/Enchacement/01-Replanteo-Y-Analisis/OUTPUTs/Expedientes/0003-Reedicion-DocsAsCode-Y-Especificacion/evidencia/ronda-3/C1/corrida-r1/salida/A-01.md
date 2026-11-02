---
doc_id: FIC-DISENO-DOCUMENTAL
doc_type: ficha
title: Ficha de diseño documental de Lab-Geometria
description: A-01 del sistema documentador de Fábrica de Geometría; decisiones, catálogo activo, artefactos y verificación.
status: borrador
origin: ia-assisted
confidence: media
owner: Product Owner
last_review: 2026-11-02
audience: [humano, agente, po, desarrollo]
traces: []
---

# Ficha de diseño documental — Fábrica de Geometría

Las citas `ruta:línea` llevan el repo como prefijo (`LG/` = Lab-Geometria, el código; `LGD/` =
Lab-Geometria.Documentacion, el hermano) y valen contra la huella del árbol de la cabecera; el chequeo de citas corre
desde la carpeta que contiene los dos (`repo/`). Las salidas completas de los comandos están en `salida/_inventario/`
(`c01.txt`, `c01b.txt`, … por número de comando). Todo comando se corrió con `./aislado`, sin red.

| Campo | Valor |
| --- | --- |
| Proyecto y repositorios leídos, con SHA (sin `.git`: «SHA: pendiente» y huella del árbol con `LC_ALL=C`, comando 11, §2.4) | Fábrica de Geometría. `LG` (Lab-Geometria) y `LGD` (Lab-Geometria.Documentacion). **SHA: pendiente** en los dos: `./aislado git -C repo/LG log -1` y `./aislado git -C repo/LGD log -1` devuelven «fatal: not a git repository». Huella del árbol (comando 11 desde `repo/`): `0355c45f63f4f052482daf72cbdaedf5a515af57b63c6f0a9ec703d782450ed8`; por repo, desde su raíz: `LG` `e2ccd06a7e48bf6536b56ae4445f4eb731c0d5583590136a5199d6497c24d01d`, `LGD` `92b7eee5b71d6046d2359b9098d2f6a5538240959666438e4207309f9485eb46`. Revisión declarada en prosa por el índice (evidencia secundaria): `4b114d7`, etiqueta `v1.2.0` (LGD/ia-db/README.md:38) |
| Carpetas excluidas o sin lectura (`{excluidas}`, nombres de carpeta a cualquier profundidad, separados por espacios) | `{excluidas}` vacío: ninguna carpeta excluida por el encargo y ninguna sin permiso de lectura (`./aislado bash -c 'find repo ! -readable \| head'` sin salida). `.git` no existe en ningún repo |
| Fecha (salida de `date -u +%F`, comando 10) | 2026-11-02 (comando 10 dentro de `./aislado`; coincide con `montaje.txt`) |
| Quién aplica (el rol, no un nombre) | aplicador |
| Conocimiento aplicado (alias, versión, huella) | DocsAsCode-Designing-Specification 1.3; SHA-256 de `conocimiento.md`: `8a3122671827a4777c112477a1a76603ac294f9b3ce386da857cda1c9543279e` |

## 1. Inventario (paso 1)

Comandos copiados del bloque numerado de §3.1, corridos desde `repo/` con `EXC=()` (sin excluidas). `{compuerta}` =
`../compuerta/tools/docs-guard`.

| Patrón de §3.1 | Comando | Cuenta | Salida o ruta a la salida |
| --- | --- | --- | --- |
| ID declarado más de una vez | 1: `python3 ../compuerta/tools/docs-guard/dg.py trazas --raiz . .`; también 1b | 1: 960 `id-duplicado` (238 fuera de `_legacy/`); 1b: 387 IDs repetidos | `_inventario/c01.txt`, última línea: «PR-5 traces-resolve: ROJO (errores=995 avisos=0) trazas=35 resueltas=0 ids-duplicados=960». Fuera de `_legacy/`, los duplicados se concentran en `LG/SDD/Docs/Audit` (169), `LGD/PROMPTs/Fixs/01-Ajuste-UX/OUTPUTs` (33), `LG/SDD/Expedientes/0001-…/actuaciones` (13) y `LGD/ia-db/indexes` (8). Además 35 `traza-mal-formada` (p. ej. `Rules-Documentacion-§2.1`). 1b: `_inventario/c01b.txt` |
| Versión declarada dos veces | 2 | 9 | `_inventario/c02.txt`: 9 archivos con `version:` en frontmatter y `**Versión:**` en el cuerpo, todos `README.md` de `11-Documentacion` (vivos y `_legacy`), p. ej. `LG/SDD/Docs/Producto/11-Documentacion/README.md` |
| Estado «planificado» o equivalente (y la proporción planificada, con ruta:línea) | 3 literal sobre `docs/tecnica`; 3 adaptado sobre `{carpeta-tecnica}` = `LG/SDD/Docs/Unidades-Entrega` | literal 0 (rc=2, «carpeta ausente»: `grep: docs/tecnica: No such file or directory`); adaptado 2316 líneas (rc=0) | `_inventario/c03.txt` (mayoría «previstos» en tablas de historias y en `_legacy`). Estado de cada documento (`**Estado:**`, sin `_legacy`): 406 de 408 lo declaran; Aprobado 164, Aprobada 144, Propuesto 58, Done 34, Aceptado 4, Descartada 1, otro 1. **Proporción planificada: 0 de 406** con estado «Planificado/Previsto/Pendiente» (`grep -rnE '^\*\*Estado:\*\* *(Planificad\|Previst\|Pendiente)'` sin salida); 58 de 406 en «Propuesto», que no se iguala a planificado. Ejemplo: LG/SDD/Docs/Unidades-Entrega/GeometriaFactory-Api/05-Arquitectura-Tecnica/Contratos-REST.md:6 |
| Traza de la interfaz a una unidad que no le corresponde | 4 literal sobre `{carpeta-ayuda}` (no hay carpeta de ayuda: `LG/src/GeometriaFactory.Web/Ayuda`); 4 adaptado sobre `LG/src/GeometriaFactory.Web` | 0 y 0 | literal: rc=2, «carpeta ausente»; adaptado: rc=1, sin salida. No hay ayuda con `traces:` en el repo de la interfaz |
| Puntero a un documento obsoleto o ausente (sin CHANGELOG: «archivo ausente», cuenta 0 y su rc) | 5, en cada repo (`-iname 'changelog*'` encuentra `changelog.md`) | `LG`: 1 archivo, 16 líneas (rc=0); `LGD`: 1 archivo, 0 líneas (rc=1) | `_inventario/c05-LG.txt`. Rutas nombradas, contra el árbol: `scripts/verify-stage-i.sh`, `.github/workflows/e2e.yml`, `deploy/compose.yaml` y `.github/workflows/deploy-front-ftp.yml` existen (`[ -e ]` en `LG/`); `deploy-front-ftp` está «retirado» como disparador y pasó a manual (LG/.github/workflows/deploy-front-ftp.yml:38-39). 0 punteros a archivos ausentes |
| Advertencia del índice del proyecto (cuenta y lista del comando 6; cada una pasa a reserva, con su estado) | 6 sobre `{indice}` = `LGD/ia-db/README.md LGD/ia-db/indexes/*.md` | 98 (README 4, 00 7, 01 3, 02 4, 03 20, 04 7, 05 10, 06 8, 07 5, 08 1, 09 5, 10 12, 11 7, 12 5) | Lista: `_inventario/c06.txt`. Las 98 pasan a reserva del pull request de adopción con estado «abierta, sin clasificar»: el conocimiento no da cómo separar avisos de la prosa de advertencias reales (§7) |
| Espacios de IDs en uso, con su origen y sus choques con los Id de esta ficha (D-07) | 7 | 142 prefijos | `_inventario/c07.txt`. Mayores: CU 20111, RN 16207, E 9760, BT 9733, F 9699, US 9684, ADR 9344, PRODUCT 7453, NB 5020, A 4046, PT 3862, QG 2669, RA 2407, EP 2206, AG 1870, SD 1049. Origen: marco SDD del proyecto (LG/SDD/README.md:3) y observaciones del índice (`O-`, LGD/ia-db/README.md:29). **Chocan con los Id de A-01**: `A` (4046), `D` (1155), `CL` (1025), `I` (174); `DE` no aparece. Los Id de esta ficha no se declaran como `doc_id` ni encabezado, así que no entran al registro |
| Plataformas que compila cada máquina (D-09) | 8 | 1 | `1 <TargetFramework>net10.0` (sin `net10.0-ios` ni `-android`). Más el visor Node/webpack (LG/SDD/Docs/README.md:89). Línea plataforma → runner: Linux → `ubuntu-latest` (LG/.github/workflows/ci.yml:47); no hace falta Mac |
| Prefijos nuevos libres (comando 9, uno por prefijo) | 9 con `RD`, `FIC`, `PRC`, `AUD` | 0, 0, 0, 0 | Los cuatro libres en todo el árbol leído (`repo/`) |

## 2. Decisiones

| Id | Pregunta | Valor | Evidencia (ruta:línea en el SHA leído, o «pendiente: qué falta») | Clase (P o H) | Si es H: opciones y default para la persona |
| --- | --- | --- | --- | --- | --- |
| D-01 | ¿Escenario y contextos? | **Panel con roles**. Roles (inventario de autorización): alumno (`Student`) y administrador (`Administrator`, el docente), con menú restringido y chequeo del claim de rol en los puntos de acceso. Superficies: panel web (`GeometriaFactory-Web`) y servicio REST (`GeometriaFactory-Api`) bajo `/v1/`, expuesto también a aplicaciones propias que actúan por las mismas dos personas; un documento OpenAPI (`v1`) con explorador. Sin paquetes publicados. Tipos de alcance: no registrados | LG/src/GeometriaFactory.Domain/Values/Role.cs:12-19; LG/src/GeometriaFactory.Web/Components/Layout/WorkShell.razor:170-181; LG/src/GeometriaFactory.Api/Endpoints/WorkEndpoints.cs:106; LG/src/GeometriaFactory.Api/Composition/CompositionRoot.cs:220-227; LG/SDD/Docs/README.md:40; LG/SDD/Docs/README.md:54-55; LG/src/GeometriaFactory.Api/Composition/ApiDocumentation.cs:117-120; sin paquetes: LG/SDD/Docs/README.md:144 | P | — |
| D-01 · sitio | ¿Hay sitio publicado? | Remite a D-03: «pendiente: decisión H». Medido: no hay build de sitio de documentación | `find . -name mkdocs.yml -o -name docfx.json -o -name 'docusaurus.config*' -o -name _config.yml -o -name book.toml -o -name llms.txt` desde `repo/`: sin salida, rc=0. El explorador Scalar del servicio es un sitio de API, no de documentación (LG/src/GeometriaFactory.Api/Composition/ApiDocumentation.cs:108-120) | H (hereda de D-03) | Ver D-03 |
| D-01 · marco | ¿Hay marco de especificación? | Sí: framework SDD, que vive en otro repositorio y no se copia; su especificación generada vive en `LG/SDD/` | LG/SDD/README.md:3; LGD/ia-db/README.md:43 | P | — |
| D-01 · topología | ¿Mismo repo, hermano o dedicado? | Código y especificación en el mismo repo (`LG`); índice para agentes, análisis y prompts en el repo hermano `LGD` | LGD/README.md:3-5; LG/SDD/Docs/README.md:93-102 | P | — |
| D-01 · organización | ¿Dentro o fuera de la organización del runner (medido)? | pendiente: organización (sin `.git` ni remoto en ningún repo, y la compuerta de origen llega sin remoto) | `./aislado git -C repo/LG remote -v`: «fatal: not a git repository» | P | — |
| D-02 | ¿Qué clases de pieza se activan? | Fila de panel con roles (CL-01 a CL-08, CL-12) más altas CL-09 y CL-13; CL-04 y CL-05 activas con control «pendiente»; bajas CL-10, CL-11, CL-14 | Ver §3 | P | — |
| D-03 | ¿Hay sitio publicado? | pendiente: decisión H. Medido: sin build de sitio (comando de D-01 · sitio) | Ver D-01 · sitio | H | Opciones: Sí · No. Default propuesto: **No** |
| D-04 | ¿Hay marco de especificación con registro de IDs? | Sí: se usan los IDs del marco SDD, declarados en encabezados del repo con `**Versión:**`. El registro **no resuelve** hoy: 960 IDs declarados más de una vez (238 fuera de `_legacy/`) y 35 trazas mal formadas; esos heredados van a un saneamiento aparte (A-08) | LG/SDD/Docs/Unidades-Entrega/GeometriaFactory-Api/05-Arquitectura-Tecnica/Contratos-REST.md:1-6; comandos 1, 1b y 2 (§1) | P | — |
| D-05 | ¿Dónde vive cada pieza? | Especificación (CL-01) y técnica (CL-07) en `LG/SDD/`; A-01, RRD, proceso y registro de audiencias en `LG/docs/`; CL-04 y CL-05 en el build; CL-08 en `LGD/ia-db/`; CL-09 en `LGD/PROMPTs/`, `LGD/Analisis/` y `LG/SDD/Expedientes/`; CL-13 en la raíz de cada repo. Ubicación de CL-03 y CL-12: propuesta sujeta a D-12 y D-11 | Tres preguntas de I-20; LG/SDD/Docs/README.md:93-102; LGD/ia-db/README.md:66-71 | P | — |
| D-06 | ¿Contra qué ancla vale cada pieza? | Lo que vive en `LG`: el commit. `LGD/ia-db/`: SHA fijado `4b114d7` (hoy en prosa, instancia existente) más etiqueta `v1.2.0`; A-09 lo pasa a `source.lock`. Líneas de versión vivas: una sola, `v1.x` (MinVer desde etiquetas; `v1.0.0` y `v1.2.0` registradas); el SHA completo, pendiente (sin `.git`) | LGD/ia-db/README.md:38; LGD/ia-db/indexes/00_MASTER-INDEX.md:10; LGD/ia-db/indexes/00_MASTER-INDEX.md:154-156; LG/Directory.Build.props:30 | P | — |
| D-07 | ¿Qué prefijos e IDs? | Registro mínimo del proyecto (A-02): `RD`, `FIC`, `PRC`, `AUD` internos (comando 9 en 0); externos del marco SDD: CU, RN, US, ADR, NB, BT, EP, PT, QG, RA, SD, AG. Unicidad: rojo hoy en el corpus heredado (comando 1); los artefactos nuevos, únicos (§8). Choques con los Id de esta ficha: `A`, `D`, `CL`, `I` en uso con otro sentido; no se fijan como prefijos | Comandos 1, 7 y 9 (§1) | P (prefijo del registro propio; no hay tabla P/H escrita del proyecto) | — |
| D-08 | ¿Qué esquema de frontmatter? | Diez campos más `description` para lo nuevo (A-03). Lo heredado avisa: 12 archivos con frontmatter propio del marco (`doc_type: contrato-agentes`, `status: Vigente`, `rol_intervencion`, `momento`), sin migrar. Vocabulario del proyecto: `doc_type` anexo, indice, operativa, rrd, proceso, ficha, registro-audiencias; `audience` humano, agente, desarrollo, qa, devops, po, docente, estudiante, persona-usuaria | LG/SDD/Docs/Producto/11-Documentacion/Contrato-Agentes.md:1-14; LG/SDD/Docs/README.md:131-134 (roles de lectura PO/docente, desarrollo, QA, operador); `grep -rl '^doc_id:' LG LGD --include=*.md \| wc -l` = 12 | P | — |
| D-09 | ¿Cómo corre la compuerta? | pendiente: decisión H y organización. Default propuesto: copia con huella del guion de origen en `LG/.docs-guard/` (copia intacta en `LG/.docs-guard-origen/`), en el runner Linux del proyecto | Runners del proyecto: `ubuntu-latest` (LG/.github/workflows/ci.yml:47) y uno propio con etiqueta `{etiqueta-runner}` (LG/.github/workflows/e2e.yml:69). Plataforma: sólo Linux (comando 8). Organización: pendiente | H | Opciones: workflow reutilizable de la compuerta de origen · copia con huella en runner propio. Default propuesto: **copia con huella** (la organización no se pudo medir y el proyecto declara prefijos y vocabulario propios) |
| D-10 | ¿Qué controles bloquean y cuáles avisan, en qué carpeta? | Carpeta verificada: `docs/` de `LG` (nueva). Todos los controles **avisan** en la adopción: sobre lo heredado la línea de base de trazas es 995 errores (comando 1); en `docs/` es la de §8. Un control pasa a bloquear sólo con las cinco condiciones y par rojo/verde. Si la plataforma vuelve obligatorio el check: pendiente (sin configuración ni API, sin red); volverlo obligatorio es acto H (§4). El proyecto no tiene tabla de bloqueo documental; sus puertas bloqueantes son de código | LG/.github/workflows/ci.yml:1-2; `_inventario/c01.txt` | P | — |
| D-11 | ¿Quién decide qué? | Product Owner decide lo de clase H. Delegaciones del merge: en `LG`, al agente con checks en verde y sin reserva; en `LGD`, al agente con guarda G1–G4 y sin reserva, con excepción y revocación por unidad. El pull request de adopción lleva reserva (H abiertas) y lo fusiona una persona. Visto bueno en ausencia del titular: pendiente | LG/AGENTS.md:65; LGD/README.md:11-28 | H | Decidida por el Product Owner (ver §4) |
| D-12 | ¿Qué canales hay para agentes? | pendiente: decisión H. Existen `LG/AGENTS.md` (derivado de su contrato) y el índice `LGD/ia-db/`; `LGD` no tiene `AGENTS.md` | LG/AGENTS.md:3-5; LGD/ia-db/README.md:3-9; `ls repo/LGD` sin `AGENTS.md` | H | Opciones: `AGENTS.md` puntero · índice para agentes · canales derivados (sólo con sitio). Default propuesto: **`AGENTS.md` puntero en cada repo, con la `ia-db` como punto de entrada de A-11** |
| D-13 | ¿Cómo es la ayuda al usuario final? | **Por rol** (D-01 da dos roles con permisos distintos). En el punto de uso: ninguno hoy; idioma único (castellano) | Role.cs y WorkShell.razor de D-01; ayuda inexistente: comando 4 (§1) | P | — |
| D-18 | ¿Audiencias y entrega? | **Perfil mínimo** (A-12): publico, alumno, administrador (incluye alumno), desarrollo; nivel `publico` o `producto`; regla `nivel-vs-repo`. Extensión «superficie» registrada en D-01 (panel y servicio REST); las demás, no. Pares 200/403: pendiente | D-01; LG/README.md:3 | P | Exponer o ensanchar la documentación de API y cambiar la jerarquía: H (§4) |
| D-14 | ¿Qué es privado y cómo se nombra? | Alias más barrido. `LG`: público (evidencia secundaria: «público de consulta»). `LGD`: visibilidad pendiente. Lista privada: **lista: pendiente**; barrido 12b sobre lo producido (§8). Alias usados: `{etiqueta-runner}`, `{repositorio}`, `{persona}` | LG/README.md:3; comando 13 sin mención de visibilidad en `LGD` | P | — |
| D-15 | ¿Hay un cuerpo formativo? | No: el propósito declarado es una herramienta del aula, no una guía de estudio; los `samples/` documentan capas del producto | LG/SDD/Docs/README.md:36-38; LG/AGENTS.md:90 | P | — |
| D-16 | ¿Idioma y estilo? | Castellano para personas; identificadores de código en inglés. No se traducen: claves de frontmatter, IDs, códigos de condición y rutas del contrato (`/v1/`) | LG/AGENTS.md:36-37; LG/SDD/Docs/README.md:40 | P | — |
| D-17 | ¿Cómo es el carril programado? | Semanal; frescura 365 días; vigila el atraso del SHA de `LGD/ia-db/source.lock` contra `main` del código; sólo avisa, con issue (A-10). El proyecto no fija frecuencia propia | `grep -rn 'schedule\|cron' LG/.github/workflows LGD/.github/workflows`: sólo comentarios, ningún `schedule:` | P | — |

## 3. Catálogo activo

| Clase | Activa (sí o no) | Alta o baja frente al escenario, con motivo | Dónde vive (todas las ubicaciones) | Ancla | Evidencia |
| --- | --- | --- | --- | --- | --- |
| CL-01 | sí | En la fila; especificación SDD más A-01 | `LG/SDD/Intake/`, `LG/SDD/Docs/`; A-01 en `LG/docs/_diseno/` | Commit y versión del ID | LG/SDD/Docs/README.md:125 |
| CL-02 | sí | En la fila; sin RRD hoy, nace con A-04 | `LG/docs/_requisitos.md` | Commit | Comando 9 de `RD` en 0 |
| CL-03 | sí | En la fila | `LG/AGENTS.md` (derivado de `Contrato-Agentes.md`); `LGD/AGENTS.md` propuesto | Commit | LG/AGENTS.md:3-5 |
| CL-04 | sí | En la fila; fuente presente (comentarios XML) con la generación apagada: control «pendiente» | Build de `LG` | Commit | LG/Directory.Build.props:26; LG/src/GeometriaFactory.Domain/Values/Role.cs:3-6 |
| CL-05 | sí | En la fila; contrato generado en ejecución, sin paso que lo extraiga: control «pendiente» | Build/ejecución del servicio de `LG` | Commit | LG/src/GeometriaFactory.Api/Composition/ApiDocumentation.cs:58; LG/src/GeometriaFactory.Api/Composition/ApiDocumentation.cs:117 |
| CL-06 | sí | En la fila; sin pieza todavía (RD-06) | Repo de la interfaz, `LG/src/GeometriaFactory.Web` (carpeta por definir) | Commit y versión del ID trazado | Comando 4 (§1) |
| CL-07 | sí | En la fila; vive en el corpus SDD, no en `docs/tecnica/` | `LG/SDD/Docs/Unidades-Entrega/`, `LG/SDD/Docs/Producto/` | Commit | LG/SDD/Docs/README.md:101-102 |
| CL-08 | sí | En la fila; D-12 pendiente, el índice ya existe | `LGD/ia-db/` | SHA fijado `4b114d7` y etiqueta `v1.2.0` (A-09) | LGD/ia-db/README.md:3-9; LGD/ia-db/README.md:38 |
| CL-09 | sí | Alta: hay expedientes, prompts y análisis | `LGD/PROMPTs/`, `LGD/Analisis/`, `LG/SDD/Expedientes/` (clase repartida) | Commit | LGD/README.md:3-5; LG/AGENTS.md:59 |
| CL-10 | no | Fuera de la fila; D-15 = No | — | — | LG/SDD/Docs/README.md:36-38 |
| CL-11 | no | Fuera de la fila; sin copias con huella declarada | — | — | `grep -rlE 'source.lock\|base_commit\|BASE-FIJADA' --include=*.md .` desde `repo/`: 0 |
| CL-12 | sí | En la fila; sin instancia, nace con A-06 | `LG/docs/_gobierno/como-intervenir.md` | Versión de la plantilla | Comando 9 de `PRC` en 0 |
| CL-13 | sí | Alta: README y registro de cambios en los dos repos | `LG/README.md`, `LG/changelog.md`, `LGD/README.md`, `LGD/changelog.md` | Fecha o versión (MinVer) | LG/README.md:6; LG/changelog.md:1-5; LGD/changelog.md:1-4 |
| CL-14 | no | Fuera de la fila; sólo con sitio (D-03 pendiente, default No) | — | — | D-01 · sitio |

## 4. Decisiones de clase H para una persona

| Id | Estado (abierta, o «decidida por {actor}» con ruta:línea) | Opciones | Default propuesto | Quién decide |
| --- | --- | --- | --- | --- |
| D-03 | abierta | Sí · No | No | Product Owner |
| D-09 | abierta | Reutilizable · copia con huella | Copia con huella en el runner Linux | Product Owner |
| D-11 | decidida por el Product Owner: merge delegado al agente con checks en verde y sin reserva (LG/AGENTS.md:65; LGD/README.md:11-28) | — | — | Product Owner |
| D-12 | abierta | `AGENTS.md` puntero · índice para agentes · canales derivados | `AGENTS.md` puntero en cada repo; `ia-db` como punto de entrada | Product Owner |
| D-18 · jerarquía | abierta | Jerarquía de A-12 (administrador incluye alumno) · otra | La de A-12 | Product Owner |
| D-18 · API | abierta | Publicar la documentación de API (OpenAPI y Scalar) en producción · sólo en desarrollo | Sólo en desarrollo, como hoy (llave de configuración) | Product Owner |
| Check obligatorio | abierta | Volver obligatorio `docs-guard` antes del merge · dejarlo avisando | Dejarlo avisando hasta línea de base 0 | Product Owner |
| Pull request de adopción | abierta (lleva reserva) | Fusionar · pedir cambios | Lo fusiona una persona | Product Owner |

## 5. Audiencias y entrega (D-18)

Perfil mínimo; extensión activada: superficie (registrada en D-01, §2).

| Audiencia (fila de A-12) | Incluye | Nivel de acceso (`publico`, `producto`, `restringido`, `interno`) | Punto de aplicación (repositorio, build, servidor) | Par de entrega (200 con contenido / distinto de 200 sin contenido) o «pendiente» | Evidencia |
| --- | --- | --- | --- | --- | --- |
| publico | — | `publico` | repositorio | pendiente | LG/README.md:3 |
| alumno | publico | `producto` | servidor | pendiente | LG/src/GeometriaFactory.Domain/Values/Role.cs:15 |
| administrador | alumno | `producto` | servidor, por rol | pendiente | LG/src/GeometriaFactory.Domain/Values/Role.cs:18; LG/src/GeometriaFactory.Web/Components/Layout/WorkShell.razor:170-181 |
| desarrollo | publico | `publico` | repositorio | pendiente | LG/SDD/Docs/README.md:132 |

## 6. Artefactos A-02 a A-13

Rutas relativas a `salida/`; el primer segmento es el repo.

| Id | Producido (sí o no) | Ruta | Motivo si no se produce | Propuesta sujeta a (D-nn), si depende de una H abierta | «Sin probar», si falta la compuerta |
| --- | --- | --- | --- | --- | --- |
| A-02 | sí | `LG/.docs-guard/tools/docs-guard/prefijos.txt` | — | D-09 | probado (§8) |
| A-03 | sí | `LG/.docs-guard/tools/docs-guard/esquemas/cuerpo.schema.json` | — | D-09 | probado (§8) |
| A-04 | sí | `LG/docs/_requisitos.md` | — | — | probado (§8) |
| A-05 | sí | `LGD/AGENTS.md` (nuevo); `_propuestas/LG-Contrato-Agentes-insercion.md` (cambio en la fuente del `AGENTS.md` derivado de `LG`) | — | D-12 | — |
| A-06 | sí | `LG/docs/_gobierno/como-intervenir.md` | — | D-11, D-12 | probado (§8) |
| A-07 | sí | `LG/.github/workflows/docs-guard.yml`; guion en `LG/.docs-guard/scripts/` y `LG/.docs-guard-origen/scripts/` | — | D-09 | el workflow, sin probar en una CI; el guion, probado en local (§8) |
| A-08 | sí | `_pr-adopcion.md` (informe de línea de base); `LG/.docs-guard/tools/docs-guard/excepciones.txt` (vacío) | — | — | — |
| A-09 | sí | `LGD/ia-db/source.lock` | — | — | sin probar (SHA completo pendiente) |
| A-10 | sí | `LGD/.github/workflows/docs-atraso-semanal.yml` | — | — | sin probar (usa red) |
| A-11 | sí | `_propuestas/A-11-entradas.md` (tres destinos con su línea de inserción) | — | D-12 | — |
| A-12 | sí | `LG/docs/_gobierno/registro-audiencias.md` | — | D-18 (jerarquía) | probado (§8) |
| A-13 | sí | `_pr-adopcion.md` §2 | — | — | — |

**Suposiciones** (las pide la carta del aplicador en esta sección):

- S-1. Se tomó `LG/SDD/Docs/Unidades-Entrega` como `{carpeta-tecnica}` y `LG/src/GeometriaFactory.Web` como `{carpeta-ayuda}` adaptada, porque los defaults no existen; se informan junto al literal (§2.4, DE-24).
- S-2. Se tomó como `{indice}` toda la `ia-db` (`README.md` más `indexes/*.md`), porque el `README.md` se declara punto de entrada único y deriva a los índices.
- S-3. El proceso del aplicador corrió fuera de `./aislado` unos comandos de sólo lectura o de escritura en `salida/` (lectura de la carta, `mkdir`, escritura de archivos con `cat` y un ajuste con `python3`) antes de corregirse; ninguno usó red ni tocó `repo/` ni `compuerta/`.

## 7. Lo que el conocimiento no resolvió

| Sección o decisión | Cita textual de lo que no resuelve | Qué quedó sin hacer |
| --- | --- | --- |
| §3.1, patrón 6 | «`DocsAsCode-Designing-Specification §3.1`, patrón 6, no resuelve: «la cuenta y la lista pasan a A-01, y cada advertencia, como reserva, con su estado»» sin decir cómo separar una advertencia real de la prosa que contiene «pendiente» o «aviso» | Las 98 líneas pasan en bloque a reserva, sin clasificar |
| D-04 | «`DocsAsCode-Designing-Specification §3.2`, D-04, no resuelve: qué contestar cuando hay marco con IDs en el repo pero el registro no resuelve (960 duplicados)» | Se contesta «Sí» con unicidad en rojo y el saneamiento aparte |
| D-01 · organización | «`DocsAsCode-Designing-Specification §3.2`, D-09, no resuelve: «si no se puede medir, "pendiente: organización", sin demandarla»» | D-09 queda con default y la organización pendiente |
| D-11 | «`DocsAsCode-Designing-Specification §3.2`, D-11, no resuelve: «Por cada visto bueno obligatorio, quién lo da en ausencia del titular, o "pendiente"»» | Pendiente: el proyecto no nombra suplente del Product Owner |

## 8. Verificación (§6)

| Comprobación | Comando | Resultado (salida textual) |
| --- | --- | --- |
| Compuerta sobre los artefactos, con A-02 y A-03 (copia de §5.7 y su huella) | Desde `salida/LG`: `bash .docs-guard/scripts/ci-local.sh {grupo} docs`, un grupo por vez (enlaces, esquema, ai, estructura, trazas, contrato, fijadas); huella del guion copiado igual a la de origen (`dg.py` 471936d8…bdbf, `ci-local.sh` 5d07aed1…851d) | Todos rc=0. «PR-1 fuera-del-repo: verde (errores=0 avisos=0)»; «PR-2 esquema: verde (errores=0 avisos=1) archivos-con-frontmatter=4»; «PR-3 anti-inyeccion: verde (errores=0 avisos=0)»; «Summary: 0 error(s)» y «PR-4 mermaid-arroba: verde»; «PR-5 traces-resolve: verde (errores=0 avisos=0) trazas=3 resueltas=3 ids-duplicados=0»; «PR-6 contratos: verde … contratos=0»; «PR-7 url-fecha: verde». Montados: A-01 (copia en `docs/_diseno/`), A-02, A-03, A-04, A-06, A-12; A-05 y A-07 viven fuera de `docs/` y no entran a la RUTA |
| Par rojo/verde plantado, con la compuerta de D-09 | Plantar `FIC-NO-EXISTE` en `traces` de `docs/_requisitos.md`, correr `ci-local.sh trazas docs`, restaurar y volver a correr | Rojo, rc=1: «(docs/_requisitos.md, línea 1) ERROR traza-no-resuelve: FIC-NO-EXISTE: el ID no está declarado en el registro» y «PR-5 traces-resolve: ROJO (errores=1 avisos=0) trazas=4 resueltas=3». Verde, rc=0: «PR-5 traces-resolve: verde (errores=0 avisos=0) trazas=3 resueltas=3 ids-duplicados=0» |
| Autoprueba de la compuerta de origen (sin red ni caché: «pendiente», con el comando, §5.7) | Desde `salida/LG`: `bash .docs-guard-origen/scripts/ci-local.sh autoprueba docs`, con las cachés de la imagen (`DOCS_GUARD_CACHE` y `npm_config_cache` dentro de la imagen, `npm_config_offline=true`) | rc=0; última línea «== autoprueba: verde» (salida completa en `salida/_inventario/autoprueba.txt`) |
| Chequeo de citas ruta:línea (§3.5; cada cita repite el archivo, sin `:n` sueltas) | El bloque de §3.5 sobre `../salida/A-01.md`, desde `repo/` | Salida vacía (rc=0) sobre 50 citas únicas con archivo; sin `:n` sueltas |
| Muestra de cinco citas releídas contra lo que afirman (§3.5) | `sed -n` de cada línea citada | LG/src/GeometriaFactory.Domain/Values/Role.cs:12 «public enum Role» (dos roles, D-01); LG/AGENTS.md:65 «Fusionar un PR y borrar su rama \| Lo hace el agente, por decisión del Product…» (D-11); LGD/ia-db/README.md:38 «revisión `4b114d7`» (D-06); LG/.github/workflows/ci.yml:47 «runs-on: ubuntu-latest» (D-09); LG/Directory.Build.props:26 «GenerateDocumentationFile false» (CL-04). Las cinco sostienen lo afirmado |
| Barrido por `{lista-privada}` (§3.6; sin la lista, comando 12b y «lista: pendiente») | Comando 12b sobre `salida/` (sin `_inventario/`), con `-e` por IPv4, rutas de usuario, `hostname -s` del entorno y la etiqueta de runner del inventario. **lista: pendiente** | 0 coincidencias en A-01 y en los artefactos nuevos. 4 coincidencias en `dominios.txt` de las dos copias de la compuerta (la dirección de escucha de todas las interfaces y la de loopback, genéricas heredadas de la compuerta de origen, no privadas) |
