---
doc_id: DAC0003-N1
doc_type: bitacora-nucleo
title: Núcleo N1 — Coherencia del cuerpo SDEI con sus ejemplos y su demo
status: borrador
origin: agent
confidence: alta en lo medido (grep, dg.py, ci-local.sh, verificar.sh, mermaid.sh y API de GitHub, corridos el 2026-11-01 en el equipo de pruebas); media en las propuestas, que decide la mesa
owner: presidencia de la reedición DocsAsCode (expediente 0003), relevamiento del núcleo N1
last_review: 2026-11-01
traces: [DB-R02-00, EXP0002-F245, EXP0002-F255, EXP0002-F259, EXP0002-F290, DB00]
---

# Núcleo N1 — Coherencia del cuerpo SDEI con sus ejemplos y su demo

## Índice

1. [Alcance y base medida](#1-alcance-y-base-medida)
2. [Pruebas corridas](#2-pruebas-corridas)
3. [Estado de la guía vieja](#3-estado-de-la-guía-vieja)
4. [Tabla de hallazgos](#4-tabla-de-hallazgos)
5. [Pendientes heredados del expediente 0002 y su estado real](#5-pendientes-heredados-del-expediente-0002-y-su-estado-real)
6. [Lectura transversal por tipo](#6-lectura-transversal-por-tipo)
7. [Lo no verificado](#7-lo-no-verificado)
8. [Insumos para la mesa](#8-insumos-para-la-mesa)

## 1. Alcance y base medida

| Campo | Valor |
| --- | --- |
| Cuerpo auditado | `{dir-de-trabajo}/wt/dac-LD/Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/` (72 archivos, 6098 líneas de `.md` principales) |
| Base de Lab-Documentos (LD) | worktree `{dir-de-trabajo}/wt/dac-LD`, rama `dac/0003-base`, cabeza `0bed863` (merge del PR #41) |
| Base de Lab-Documentos.Documentacion (LDD) | worktree `{dir-de-trabajo}/wt/dac-LDD`, rama `dac/0003-base`, cabeza `8b96bc6` (merge del PR #49) |
| Leído | README, 00-Marco, 01-Mapa, TEM-01…07, la guía vieja (encabezado y tabla de destinos), los ocho anexos, `Examples/**` (mini demo completa, prueba de ayuda por rol, «Cómo intervenir» y su instancia, `Lanzar-Example.md`); en LDD, `00-Indice.md` §4–§6 y los folios 245, 255, 259 y 290 del expediente 0002 |
| Abreviaturas | `SDEI/` = la carpeta del cuerpo; `EXP/` = `{dir-de-trabajo}/wt/dac-LDD/PROMPTs/DEVs/Enchacement/01-Replanteo-Y-Analisis/OUTPUTs/Expedientes/0002-Replanteo-Metodologia-DocAsCode/` |
| Qué no se tocó | Ningún repositorio: todo se leyó y se corrió sobre los worktrees, con salidas en el scratchpad de la sesión |

## 2. Pruebas corridas

Todas en el equipo de pruebas, el 2026-11-01, sobre `{dir-de-trabajo}/wt/dac-LD`.

| Prueba | Comando | Resultado |
| --- | --- | --- |
| docs-guard completo | `DOCS_GUARD_CACHE=<scratchpad>/dg-cache scripts/ci-local.sh todo SDEI/` (tras el paso `herramientas`: lychee 0.18.1, mermaid 11.4.1, markdownlint-cli2 0.17.2) | rc=0; los 8 pasos del agregador en verde (`enlaces`, `esquema`, `ai`, `estructura`, `trazas`, `contrato`, `fijadas`, `autoprueba`) |
| Trazas | `python3 -I tools/docs-guard/dg.py trazas SDEI/` | verde: trazas=121, resueltas=112, 9 avisos `traza-no-verificable` (todas de `Prueba-Ayuda-Por-Rol/Web/Ayuda/es/**`) |
| Avisos | `dg.py avisos SDEI/` y paso `fijadas` | `avisos`: 11 (5 de la guía vieja); PR-7 `url-fecha`: verde con **33 avisos**, todos de la guía vieja |
| Mini demo | `TRABAJO=<scratchpad>/mini-demo verificar.sh todo` (SDK .NET 10.0.403 del host) | rc=0 en 22 s: C1 8 operaciones, C2 rojo esperado, C3 17/17 trazas y 10/10 anclas contra `8fb4c3a`, C4 rojo por el 60/80, A1 sin deriva contra `main` `59399ba` |
| Enlaces y anclas | script propio con slug de GitHub sobre todo `SDEI/**/*.md` | 3 rotos, los tres deliberados y excluidos en `scripts/docs-guard.lychee.toml:5-10`; 0 anclas muertas |
| Mermaid dibujado | `tools/medios/mermaid.sh` (contenedor `minlag/mermaid-cli:11.4.2`) sobre los 19 archivos con diagramas, sin la guía vieja | **rc=1**: 21 diagramas, 2 «Unsupported markdown: link» (N1-25) |
| Reproducibilidad de un guion del cuerpo | clon nuevo de LD + `git checkout --quiet 080f158` (el guion de `TEM-07:200`) | **falla**: `error: ruta especificada '080f158' no concordó…`; `fatal: Not a valid object name` (N1-17) |
| Runner real | `GET /repos/hdcm-dev/Lab-Documentos/actions/runs/41327937941/jobs` | job `docs-guard` en `runner_name: {runner-del-cuerpo}`, labels `['self-hosted','{runner-anterior-del-cuerpo}']` |

## 3. Estado de la guía vieja

`SDEI/Sistema-Documentador-Tecnico-Guide.md` (`DOC-SDT-0001`, 841 líneas):

| Pregunta | Respuesta | Evidencia |
| --- | --- | --- |
| ¿Qué estado tiene? | `status: obsoleto` desde el 2026-10-27 (unidad E1-U4f) | líneas 6 y 22–28 |
| ¿Qué la reemplaza? | El cuerpo SDEI: README (`IDX-SDEI`), Marco, Mapa, `TEM-SDEI-01…07` y anexos | línea 24; tabla de destinos líneas 30–87 |
| ¿Se archivó? | No. Dice que se archiva «en la versión siguiente del cuerpo»; el cuerpo sigue en `2.0.0-borrador` | línea 26; `README.md:22` |
| ¿Sigue citada? | Sí: siete enlaces vivos desde el cuerpo, cuatro de ellos como **única** fuente de un dato | `TEM-01:170`, `TEM-03:245`, `TEM-04:106`, `TEM-05:184`, `README.md:99,124`, `01-Mapa.md:130`, `Prueba-Ayuda-Por-Rol/README.md:3`, `Lanzar-Example.md:27` |
| ¿Cuesta algo mantenerla? | Sus 33 avisos de `url-fecha` salen en cada corrida (pendiente PE-6 del 290, abierto) | paso `fijadas` del §2 |
| ¿Su tabla de destinos es exacta? | No del todo: la fila 8.7 dice actores `ACT-SDEI-1` a `ACT-SDEI-5` y el Marco tiene seis (`00-Marco.md:149`); la fila 10 dice que «cada tema cierra con sus hechos, interpretaciones y criterio propio», y sólo TEM-01…03 tienen esa sección | líneas 79 y 82 |
| Datos propios que el cuerpo no absorbió | El caso de un portal público de notificaciones (Mintlify, MDX, `llms.txt` de 170 páginas) sólo vive acá: `Referencias.md` no tiene ninguna entrada de ese proveedor (`grep -c OneSignal` = 0) | tabla de destinos, filas 1–1.4 «Parcial» |

Conclusión: está **obsoleta en el estado, viva en el uso**. Antes de archivarla, el libro unificado (P1) tiene que absorber
el caso del portal con su referencia APA y retirar las siete remisiones.

## 4. Tabla de hallazgos

Tipos: (a) afirmación que el ejemplo contradice o no ilustra; (b) término con dos sentidos; (c) referencia rota, ancla
muerta o dato desactualizado; (d) solapamiento o hueco entre documentos; (e) contradicción entre glosario y uso; (f) lo
que la demo hace y la doc no cuenta. Severidad: **alta** (rompe la reproducción o hace decir algo falso sobre el
ejemplo conductor), **media** (un lector o un agente llega a una respuesta distinta según el documento), **baja**
(forma, precisión o consistencia menor).

| Id | Documento:línea | Tipo | Evidencia | Sev. | Propuesta |
| --- | --- | --- | --- | --- | --- |
| N1-01 | `TEM-01-Sistema-Documentador.md:268` | a | Dice «la pantalla promete 60 caracteres para el **comentario**»; la regla es el largo del **nombre de una localidad**: `RN-LOC-01.md:35`, `00-Marco.md:175`, `Patrones-De-Ejemplos.md:30` (PE-01) | alta | «para el nombre de una localidad» |
| N1-02 | `99-Anexos/Esquema-Frontmatter-Y-Prefijos.md:158` | a | Ejemplo `RD-03 \| persona usuaria \| cargar un comentario… \| docs/ayuda/comentarios.md`; el RD-03 real es de desarrollo y apunta a `tecnica/arquitectura.md` (`_requisitos.md:248`). Resto de una versión anterior de la demo, igual que N1-01 | media | Usar la fila RD-01 real recortada, como hace `TEM-02:185-187` |
| N1-03 | `TEM-01:283-284` frente a `RN-LOC-01.md:37,39` y `MovilidadUrbana-Mini-Demo/README.md:168` | b | TEM-01: «divergencia entre la **letra (el código)** y la intención». La ficha y el tutorial: letra = **lo que la app promete** (texto bajo el campo); «la letra y la intención dicen 60; el comportamiento admite 80» | media | Fijar tres términos: letra (lo que se promete), intención (para qué), comportamiento (lo que el código hace). Llevarlos al glosario |
| N1-04 | `99-Anexos/Glosario.md:57` frente a `MovilidadUrbana-Mini-Demo/README.md:45` | b, e | Glosario: deriva = «distancia entre lo que una pieza afirma y lo que el código hace». Tutorial: deriva = «diferencia entre el SHA fijado y `main`». `TEM-05:43` ya advierte un tercer uso («derivar» una página) | media | Glosario con dos entradas: deriva (contenido) y desfase o atraso del ancla (SHA frente a `main`, que es como lo llama `semanal.sh:14`) |
| N1-05 | `Patrones-De-Ejemplos.md:28-41`; `tools/docs-guard/prefijos.txt:24`; `EXP/actuaciones/290-compuerta-e1.md` §12; `00-Indice.md` §5 y §6 | b, e | `PE-nn` = patrón de ejemplo (anexo, `Esquema…:117`); `PE` = «pregunta de evaluación» en el registro que **manda** (`Esquema…:199`); `PE-1…PE-14` = pendientes en el 290; «credencial local (PE-10)» en el índice | media | Registro: `PE` = patrón de ejemplo; los pendientes del expediente con otro prefijo (`PEND-`) |
| N1-06 | `Esquema-Frontmatter-Y-Prefijos.md:102-132` frente a `prefijos.txt:20` | c | El registro tiene `FC` (Framework Concept); el anexo no lo lista, y dice que ante diferencia manda el archivo y se corrige el anexo (`:199-200`) | baja | Sumar la fila `FC` |
| N1-07 | `Glosario.md:28` | e | «Hay **cuatro** familias de siglas»; la tabla siguiente tiene seis filas (`PR`, `AI`, `AK`, `G`, `CQ/PE/VER`, `CL`). Era D-20 del 245 | media | «seis familias», o sacar el número |
| N1-08 | `Glosario.md:34` | e | «`AK-1` a `AK-7`»: `git grep` en LD sólo encuentra AK-1, AK-3, AK-4, AK-5 y AK-7; AK-2 y AK-6 no aparecen en ningún archivo. Era D-19 del 245 | media | Listar los AK que existen o definir AK-2 y AK-6 donde se definen los demás |
| N1-09 | `TEM-01:52` y `Glosario.md` §2 | e, d | TEM-01: «Los cinco [términos] están en el Glosario»; «Fuente de verdad» no está. Tampoco: Ficha, Escalón, Divergencia (leve/de fondo), Guarda de merge, Runner, Repositorio hermano, Actor, Rol, Unidad, Letra/Intención, aunque se usan en Marco, temas y demo (VER-H03, `Lista-De-Verificacion.md` §7) | media | Completar el glosario; el libro (P1) lo necesita como capítulo de referencia |
| N1-10 | `00-Marco.md:44`; `TEM-03:49-50`; `Examples/Como-Intervenir.md:108` | b | Llaman a PR-7 «referencias». El workflow: «PR-7 fijadas … piezas fijadas con su SHA-256 y reflint» (`.github/workflows/docs-guard.yml:14`) y `TEM-06:71,95` «fijadas y reflint». «Siete grupos» omite el octavo paso del agregador, `autoprueba` (`docs-guard.yml:15,121`) | media | Un solo nombre: «PR-7 fijadas y referencias (`reflint`, `url-fecha`)», y nombrar `autoprueba` donde se cuentan los grupos |
| N1-11 | `Glosario.md:52`; `TEM-03:47-48`; `00-Marco.md:78`; `TEM-03:61,143`; `TEM-07:24-26` | b | «Compuerta» = un control (glosario), un conjunto de controles (TEM-03), y el hito de un escalón («etiqueta por compuerta», «compuerta de cierre»). El 255 §2.1 ya midió la ambigüedad | media | Tres términos: control, compuerta (carril PR) y compuerta de escalón |
| N1-12 | `TEM-03:322` | c | Dice que `docs-guard` rechaza `traces: []`. `dg.py:15,342-346` hoy lo acepta y avisa `traces-vacio` (D-17 del 245; U4b/H-1) | media | Borrar la observación o reescribirla en pasado con la versión de `dg.py` que lo cambió |
| N1-13 | `TEM-06:198` | c | «[Compilado: .github/workflows/docs-guard.yml, l. 40-51]»; hoy `permissions:` está en la 50, `runs-on:` en la 60 y `timeout-minutes:` en la 61. D-21 del 245, abierto | media | Citar por SHA del commit y rango real, o por bloque nombrado |
| N1-14 | `TEM-02:156` | c | El enlace a «el tema 07» va a `README.md#4-tabla-de-contenido`; TEM-07 existe | baja | Enlazar `TEM-07-Marco-SDD.md` |
| N1-15 | `01-Mapa.md:48-49`; `TEM-06:215-216` | c | «mientras estén en redacción» y «“Cómo intervenir”, en redacción»: los siete temas y `Examples/Como-Intervenir.md` existen | baja | Quitar las frases de estado |
| N1-16 | `TEM-03:319` | c | «Otra guía … declara `TEM-01` a `TEM-08`»; el Framework Concept las renombró a `FC-TEM-nn` (`CHANGELOG.md:83`; `git grep '^doc_id:' Concepts/Framework-Concept`). La convención sigue justificada por `MARCO-CONVENCIONES`, declarado cuatro veces | baja | Reescribir el motivo con el caso vigente |
| N1-17 | `TEM-07:187,200`; `TEM-01:218,343`; `TEM-02:218,342`; `TEM-03:162,221`; LDD `ia-db/README.md:122` | c | Tras la reescritura de la historia de LD, `080f158` y `fe10086` no son ancestros de `main` (`git merge-base --is-ancestor` = no); los merges equivalentes son `e3841b6` (#19) y `6878568` (#25). La API de GitHub todavía los sirve (200, por `refs/pull`), pero un clon nuevo no: el guion de TEM-07 falla en el primer paso (§2) | alta | Remapear con el mapa de commits del rescate y citar «PR #n, merge `<sha nuevo>`»; actualizar el `base_commit` de la ia-db |
| N1-18 | `TEM-01:213-218`; `TEM-02:214-218`; `TEM-03:193,212-213,221` | c, d | Remiten a `evidencia/E1-U4b/…` de LDD como code span sin URL ni SHA. Desde el #36 la carpeta existe (`EXP/evidencia/E1-U4b/`), pero U26 (marcas a URL + SHA, `259` §4) no se hizo y U25 (corrida nueva de los guiones) tampoco: no hay `EXP/evidencia/E1-R/` | alta | Cerrar U25 y U26; para el libro, URL permanente al SHA de LDD |
| N1-19 | `TEM-01:170-180`; `TEM-04:105-111`; `TEM-03:245`; `TEM-05:184`; `Prueba-Ayuda-Por-Rol/README.md:3`; `Lanzar-Example.md:27` | d, c | El caso de industria y la propuesta por rol dependen de la guía obsoleta. Las cifras del portal (Mintlify, 170 páginas) no tienen referencia APA (`Referencias.md`: 0 entradas del proveedor), contra la convención de citación (`00-Marco.md:165`) | media | Absorber el caso en el libro con su referencia y fecha de consulta; retirar las remisiones antes de archivar |
| N1-20 | `TEM-01:334`, `TEM-02:333`, `TEM-03:309` frente a TEM-04…07; `TEM-04:15`, `TEM-05:15`, `TEM-06:15`; `TEM-07:4` | d | TEM-01…03 tienen una 7.ª sección «Fuentes y observaciones»; TEM-04…07 no (`README.md:135-136` habla de seis). Títulos H1: «Tema 0n — …» en 01–03 y 07, «TEM-0n …» en 04–06; TEM-07 tiene `title: TEM-07 — …` y H1 «Tema 07 — …». Pie de navegación en dos formatos | media | Una plantilla de tema para el libro; observaciones en todos o en ninguno (VER-T07, VER-E07) |
| N1-21 | `TEM-05:48` frente a `Prueba-Ayuda-Por-Rol/Web/Ayuda/es/alumno/enviar-un-trabajo.md:6` | a | «Toda página de usuario traza a un `RD-`»; las páginas de la prueba de ayuda por rol trazan sólo a `CU-000nn@1.1` y las de `Consola/Ayuda/` no trazan. Las 9 trazas dan «no verificable» (§2): el escenario `ESC-SDEI-3` no tiene ningún ejemplo cuyas trazas resuelvan | media | Declarar el límite en TEM-05 o sumar RRD y `source.lock` al ejemplo (insumo para el ensayo sobre Geometría, N4) |
| N1-22 | `00-Marco.md:145,148`; `TEM-02:166`; `99-Anexos/Ejercicios.md` clave de EJR-SDEI-05 | a, d | ¿Quién decide la fase 1b en `ESC-SDEI-1`? Marco: la analista (`ACT-SDEI-2`), y el docente «no decide el contenido normativo»; TEM-02: «docente o responsable de la guía»; Ejercicios: «la analista o el PO» | media | Una respuesta en el Marco y que TEM-02 y la clave la citen |
| N1-23 | `00-Marco.md:105`; `TEM-04:86`; `Examples/Como-Intervenir-Lab-Documentos.md:22,26`; `Lista-De-Verificacion.md:150` | a, d | Para `ESC-SDEI-1` el Marco activa CL-02, 03, 09, 10, 11, 12. En LD se usan además CL-13 (CHANGELOG obligatorio, `MovilidadUrbana-Mini-Demo/README.md:311-313`; delegación en `CHANGELOG.md:285`) y CL-08 (la ia-db de LDD indexa LD: `ia-db/indexes/11_Sistema-Documentador-SDEI.md`). TEM-04 afirma «No hay índice interno»; VER-I04 exige reflejar los cambios en la ia-db. Workflows y `tools/docs-guard/` no tienen clase, aunque la instancia dice que cambiar un workflow es H | media | Revisar la fila del Marco y el catálogo (una clase para la herramienta de la compuerta o su ubicación explícita) |
| N1-24 | `00-Marco.md:183-184`; `Ejercicios.md:116`; `01-Mapa.md:70` | a, f | Dicen que el aviso programado detecta que el método que cita la ficha cambió. El carril semanal sólo cuenta commits de atraso del SHA (`tools/docs-guard/semanal.sh:14,89-106`); la deriva por símbolo (A1) corre sólo en `mini-demo-movilidad` ante un PR que toca la demo o `tools/docs-guard/`, o a mano (`.github/workflows/mini-demo-movilidad.yml:17-23`) | media | Decir «avisa que el SHA quedó N commits atrás; la deriva por símbolo la mide A1 al correr la demo», o programar A1 |
| N1-25 | `Esquema-Frontmatter-Y-Prefijos.md:82`; `MovilidadUrbana-Mini-Demo/docs/_requisitos.md:56` | c | `tools/medios/mermaid.sh`: «MAL DIBUJADO … Unsupported markdown: link» (corchetes y rutas en las etiquetas); PR-4 da verde porque sólo parsea | media | Etiquetas sin `[...]` ni rutas con punto; evaluar sumar el dibujado a PR-4 |
| N1-26 | `MovilidadUrbana-Mini-Demo/README.md:114` | c | El ejemplo dice `RN-LOC-01.md:62: ERROR ancla-valor-distinto`; la corrida da `:62 ancla-no-contiene` y `:63 ancla-valor-distinto` (§2, coincide con `RN-LOC-01.md:71-72`) | baja | `:63` |
| N1-27 | `MovilidadUrbana-Mini-Demo/README.md:54-57`; `TEM-01:240`; `01-Mapa.md:81` | a | La columna «Clase» pone «contrato» y «anexo» en lugar de CL-05 y CL-01; el Mapa ubica CL-01 (regla) en el repositorio del código y la demo la escribe en LD. No está dicho qué clase es una ficha propia «sin SDD» | baja | Declarar la ficha como CL-01 con topología «dedicado + `source.lock`» y corregir la tabla |
| N1-28 | `Esquema-Frontmatter-Y-Prefijos.md:75,166`; `TEM-03:86` | a | El ejemplo de frontmatter usa `doc_id: TEM-03`, que la convención del propio anexo (`:137-139`) y `TEM-03:88-90` declaran ambiguo; el ancla de ejemplo `Pantalla.cs#LargoMaximo@8fb4c3a` no tiene la forma `Clase.Miembro` que exige la compuerta (`MovilidadUrbana-Mini-Demo/README.md:196`); el encabezado de ficha de ejemplo (`## RN-LOC-01 Largo máximo del nombre`) no es el real (`# RN-LOC-01 — Largo del nombre de la localidad`, `RN-LOC-01.md:15`) | baja | Ejemplos tomados de la demo real |
| N1-29 | `Patrones-De-Ejemplos.md` §2; `TEM-04:152,176`; `TEM-05:143`; `TEM-06:224`; `TEM-07:198,242` | b, e | El anexo define dos marcas (`[Compilado: …]`, `[Fragmento ilustrativo: …]`); el cuerpo usa una tercera, `[Salida registrada: …]`, y usa `[Compilado: …]` para salidas y guiones que no compilan | baja | Registrar «Salida registrada» como marca, con su regla |
| N1-30 | `99-Anexos/Como-Decidir.md:109` | a | Usa la matriz «cuerpo o archivo único» como ejemplo de `PE-01`, problema conductor; PE-01 define como problema conductor el 60/80 de la localidad (`Patrones-De-Ejemplos.md:30`) | baja | Citar PE-02 (ejemplo trabajado) o quitar la cita |
| N1-31 | `00-Marco.md:82-83`; `docs/tecnica/arquitectura.md:27-30,62-64`; `docs/tecnica/compilar-y-primer-pedido.md` §5–§6 | f | La app tiene tres aplicaciones (web, API y móvil), no «una app MAUI con una API web». Las fichas anclan sólo la móvil, pero el tutorial técnico atribuye a RN-LOC-01/02 el comportamiento de la API, cuya copia de `LocalidadRules` no tiene ancla: un cambio ahí no da rojo. A1 también compara el contrato contra `main` (§2), lo que el Marco no cuenta | baja | Contar las tres aplicaciones y declarar el límite o anclar la copia de la API |
| N1-32 | `Examples/Lanzar-Example.md:18,33,51,59,92,101` | c, d | Ruta del workspace en lo versionado (aviso `cita-linea`); `@devcontainers/cli@latest` y `cloudflared:latest` sin fijar (contra `TEM-06:288` y PE-11); remite a la «sección 7» de la guía obsoleta; nombra túneles del usuario (`jump-host-tunnel-*`); es un tool-prompt con `doc_type: guia-practica` en LD, cuando el Mapa ubica los prompts (CL-09) en el repositorio hermano | baja | Reescribir como guía práctica con versiones fijas y sin datos del entorno, o moverlo a LDD |
| N1-33 | `MovilidadUrbana-Mini-Demo/README.md:383-392`; `Ejercicios.md` (pie); `Como-Intervenir-Lab-Documentos.md:1-35` | d | Sin «anterior/siguiente» en el tutorial ni en Ejercicios; la instancia no tiene índice ni navegación. Es la reparación G-g del 245 §10, abierta | media | Pie de navegación uniforme y un índice en la instancia |
| N1-34 | `00-Marco.md:78`; `TEM-03:61,143`; `Sistema-Documentador-Tecnico-Guide.md:9` | c | Aprobado en el 255 §7 (P-ET-1: una etiqueta por versión, no por compuerta; O-A: `owner` es un rol), sin aplicar: las tres frases siguen diciendo «etiqueta por compuerta» y la guía vieja lleva en `owner` la cuenta pública del PO. T-B sí se aplicó: `git cat-file -t docs-guard-v1.0.0` = `tag` | media | Reparación P de 255 §6, filas 1 y 3 |
| N1-35 | `00-Marco.md:52,135`; `TEM-06:209`; `Lista-De-Verificacion.md:149`; `Como-Decidir.md` F1 | f | La etiqueta `[self-hosted, {runner-anterior-del-cuerpo}]` es correcta, pero hoy la sirve el runner `{runner-del-cuerpo}` (§2). El Marco ya dice «no es una dirección»; el nombre igual induce a pensar en un host | baja | Una nota en el Marco: etiqueta histórica, el host lo decide la organización |
| N1-36 | LDD `00-Indice.md` §4 y §6; `EXP/actuaciones/290-compuerta-e1.md:5` | c, d | §4 lista folios hasta el 270 (faltan 240, 245, 249–259 y 290). §6 sigue en «Sigue: E1 onda 8 — compuerta E1-G … Al reanudar, despachar desde aquí (onda 8)», y lista como pendientes `traces: []`, H-1 a H-3 y #28, ya resueltos. El 290 dice `status: vigente` aunque el 259 §5 dice que «el `290` no rige» | media | P7: bitácora 16, índice al día y una corrigenda que pase el 290 a sustituido |

## 5. Pendientes heredados del expediente 0002 y su estado real

Medidos sobre `{dir-de-trabajo}/wt/dac-LD` (`0bed863`) y `{dir-de-trabajo}/wt/dac-LDD` (`8b96bc6`) el 2026-11-01.

| Pendiente | Origen | Qué decía | Estado real hoy | Evidencia |
| --- | --- | --- | --- | --- |
| G-e (P-LECT con cero dudas) | `00-Indice.md` §5 (onda 12), §6; 245 G-e; 290 PE-1 | Tutorial, README/Marco/Mapa y TEM-01…07 sin cero estricto | **Abierto.** Rige el 245 (INSUFICIENTE, `259` §5); no hay P-LECT posterior ni carpeta `evidencia/E1-R/`; la propuesta de umbral (290 PE-1) no se resolvió | `ls EXP/evidencia/` (sin `E1-R`, sin `E1-G2`) |
| D-11 (evidencia de ensayos) | 245 G-e y G-g | `evidencia/E1-U4b/` no existía | **Resuelto en parte.** Existe desde el #36 (`EXP/evidencia/E1-U4b/`); U25 (corrida nueva) y U26 (marcas a URL + SHA) siguen abiertos | N1-18 |
| D-17 (`traces: []`) | 245 G-e; U4b/H-1; 290 PE-2 | `dg.py` lo rechazaba | **Código resuelto, texto abierto.** `dg.py:342-346` avisa; `TEM-03:322` sigue diciendo lo contrario; `00-Indice.md` §6 lo sigue pidiendo para E2 | N1-12 |
| D-19 (AK-2, AK-6) | 245 G-e | No existen | **Abierto** | N1-08 |
| D-20 («cuatro familias») | 245 G-e | Seis filas | **Abierto** | N1-07 |
| D-21 (líneas de `docs-guard.yml`) | 245 G-e | Rango equivocado | **Abierto** | N1-13 |
| G-d: `GUIA-INDICE` duplicado | 245 §10 | Ambigüedad | **Abierto**, fuera del cuerpo SDEI: tres `README.md` lo declaran (`Guides/Arquitectura/Organizacion-Estilo-Patrones-Codigo/`, `Guides/Despliegue/Documentacion-Informe-Despliegue/`, `Guides/Documentacion-Tecnica/Creacion-Guias-Tecnicas/`) y tres páginas lo trazan | `git grep -n 'doc_id: *GUIA-INDICE'` |
| G-d: colisión TEM-04/05/06 con Framework Concept | 245 §10 | IDs repetidos | **Resuelto** por el prefijo `FC-` (`CHANGELOG.md:83`); deja desactualizado `TEM-03:319` | N1-16 |
| G-g: navegación e índice | 245 §10 | Tutorial, Ejercicios e instancia | **Abierto** | N1-33 |
| U5 H-1 | `00-Indice.md` §5, §6 | README raíz y `Guides/README.md` apuntaban a la guía obsoleta | **Resuelto**: `README.md:30` y `Guides/README.md:23` apuntan al README del cuerpo | grep |
| U5 H-2 | ídem | Diagrama con temas «en redacción» | **Resuelto** en el diagrama (`README.md:90`); quedan dos frases de estado (N1-15) | grep |
| U5 H-3 | ídem | `actions/checkout@v4` sin SHA | **Resuelto**: ningún `uses:` sin SHA de 40 caracteres en `.github/workflows/` | grep |
| U5 H-4 | ídem; 290 PE-7 | 202 enlaces absolutos en Framework Concept | **Abierto**, territorio de FRAMEWORK MAUI: 179 apariciones de `](/` en `Concepts/Framework-Concept` (el método de conteo puede diferir del original) | `git grep -c '](/'` |
| U4d: bloques de CR-5 | `00-Indice.md` §5; 290 PE-3 | Ningún control mira `entradas`/`salidas`/`validaciones` | **Abierto**: no hay regla en `dg.py` | grep |
| U4d: exclusión de carpetas y prefijos externos en el mismo repositorio | `00-Indice.md` §5; 290 PE-4; `TEM-07:239` | Falta en `dg.py` | **Abierto**: `dg.py trazas` sigue sin opciones (`uso: dg.py trazas RUTA...`); TEM-07 lo describe bien | `dg.py trazas --help` |
| U4f/H-1: avisos de la guía obsoleta | `00-Indice.md` §5; 290 PE-6 | 33 avisos por PR | **Abierto**: 33 en PR-7 `url-fecha` | §2 |
| U2/LD-05: informe cortado con `head -c` | `00-Indice.md` §5; 290 PE-5 | Puede dejar `<details>` abierto | **Abierto**: `.github/workflows/docs-enlaces-semanal.yml:84` | grep |
| 290 PE-13 (#28, `AGENTS.md`) | 290 §12 | Clase H pendiente | **Resuelto**: PR #28 `closed`, `merged: true` | API de GitHub |
| 255 P-ET y O-A | 255 §7 | Unificar la regla de etiquetas; `owner` como rol | **Abierto** el texto; T-B **resuelto** | N1-34 |
| 290 (observación): «Fuentes y observaciones» sólo en TEM-01…03 | 290 §8 | «Queda para la pasada a vigente» | **Abierto** | N1-20 |
| P7 del plan: bitácora de la onda 8 e índice | Plan §2 | Falta la entrada 16 | **Abierto** | N1-36 |

## 6. Lectura transversal por tipo

| Tipo | Hallazgos | Patrón |
| --- | --- | --- |
| (a) Afirmación contra el ejemplo | N1-01, 02, 21, 22, 23, 24, 27, 28, 30 | Restos de una versión anterior de la demo (el «comentario») y reglas generales que el ejemplo de `ESC-SDEI-3` no cumple |
| (b) Dos sentidos | N1-03, 04, 05, 10, 11, 29 | «letra», «deriva», «PE», «PR-7», «compuerta», marcas de procedencia |
| (c) Rotas o desactualizadas | N1-12…17, 25, 26, 32, 34, 36 | Texto que no siguió a la herramienta, a la reescritura de la historia ni a las resoluciones del expediente |
| (d) Solapamiento o hueco | N1-09, 18, 19, 20, 22, 23, 33 | La guía vieja como fuente única; forma de tema despareja; quién decide 1b |
| (e) Glosario frente a uso | N1-04, 05, 07, 08, 09, 29 | El glosario quedó atrás del cuerpo |
| (f) Lo que la demo hace y no se cuenta | N1-24, 31, 35 | Alcance real de A1, tres aplicaciones, runner real |

Lo que **sí** es coherente y conviene conservar en el libro: el caso 60/80 de punta a punta (ficha 1.0 en rojo, 1.1 en
verde, ayuda que declara la divergencia, contrato que no la ve), el ensayo de TEM-05 (las cifras 121/112/9 coinciden
con la corrida de hoy), la regla de bloqueo de TEM-06 con su aplicación en el workflow, y el cálculo de la matriz de
`Como-Decidir.md` §5 (4,20 / 3,50 / 2,70, recalculado).

## 7. Lo no verificado

- La afirmación de 245 G-d «E1 rompió 23 trazas que antes resolvían»: no se volvió a medir (fuera del cuerpo SDEI).
- Que el runner sea efímero (`TEM-06:84,168`): la API muestra el nombre del runner, no su configuración.
- El conteo de 202 enlaces absolutos de U5 H-4: el conteo de hoy usa otro patrón (`](/`).
- La prueba de ayuda por rol no se levantó (Blazor en devcontainer); se leyeron su código, su salida registrada y sus páginas.
- No llegó ningún mensaje de otra sesión ni texto a mitad de turno que cambiara el encargo.

## 8. Insumos para la mesa

1. **Antes del libro (P1):** cerrar N1-01, N1-17 y N1-18; las tres hacen que el libro herede un dato falso o un guion
   que no corre.
2. **Glosario como capítulo:** resolver N1-03, 04, 05, 09, 10 y 11 con una decisión de términos, porque el libro unificado
   los va a usar en todas sus partes.
3. **Guía vieja:** absorber el caso del portal con referencia APA (N1-19) y archivarla en el mismo cambio que publica
   el libro; eso también cierra PE-6.
4. **Ejemplo de `ESC-SDEI-3`:** N1-21 es el hueco que el ensayo sobre Geometría (N4) puede llenar, con RRD y trazas
   que resuelvan.
5. **Compuerta:** N1-25 (dibujar mermaid) y N1-24 (A1 programado) son mejoras de herramienta, de clase H si tocan
   `dg.py` o un workflow (245 G-e).
6. **Expediente:** N1-36 entra por P7 (bitácora 16 y corrigenda del 290).
