# Verificación independiente de la etapa 3 (E3 tramos 1–6, E7, E8, E9)

> Fecha: 2026-11-01. Verificador independiente, sin arreglos: sólo se informa. Cada criterio se comprobó contra los archivos y con las compuertas corridas de nuevo. No se usaron los resúmenes como evidencia.

## Índice

- [1. Estado verificado](#1-estado-verificado)
- [2. Criterios de aceptación del plan](#2-criterios-de-aceptación-del-plan)
- [3. Compuertas corridas](#3-compuertas-corridas)
- [4. Revisión adversarial](#4-revisión-adversarial)
- [5. Hallazgos](#5-hallazgos)
- [6. Pendientes heredados y su estado](#6-pendientes-heredados-y-su-estado)
- [7. Mensajes ajenos](#7-mensajes-ajenos)

## 1. Estado verificado

- **Guía:** `Dot-Net-Integration-AI-Layer-Guide.md`, versión 0.12.0 «en revisión», `tope_palabras: 60000`. Su sha256, `ec4185d448aef67a446a86b3241d0da955f28457845887e9576fb77f1e19d82d`, coincide con el cierre de E9.
- **Conocimiento:** 599 líneas, sha256 `0eca9c5516f1…`. Coincide con E8.
- **Git:** la guía no figura en `HEAD` de LD y la bitácora queda excluida en LDD por `.git/info/exclude`. Ninguna de las dos está versionada. Por eso no hubo diff contra git y la integridad se comprobó por sha256.

## 2. Criterios de aceptación del plan

| Etapa | Criterio | Resultado | Cómo se comprobó |
|---|---|---|---|
| E3 | 0 bloques «Historia» en el cuerpo | **Cumple en el libro** (0 coincidencias de `Historia (`). **No cumple en los README de ejemplos:** quedan 23 bloques en 13 README (01, 02, 12, 13, 15, 17, …) | `grep` |
| E3 | 0 términos con dos definiciones | **Cumple** en lo medible: 68 «Definición», ningún término en cursiva repetido. El glosario remite con «Se desarrolla en» y la Tabla C.1 da definiciones de una línea, en tensión leve con «el glosario no repite definiciones» | `grep` + `uniq -d` |
| E3 | Extensión ≤ tope votado | **Cumple en el total** (59.375 / 60.000). **No cumple por parte:** los Anexos tienen 12.956 sobre 12.900. `contar.sh` sale con rc 0 igual, porque no falla por parte | `tools/contar.sh` |
| E3 | Todas las anclas viejas resuelven por alias | **Cumple:** 283/283 anclas de `E2/Anclas-Viejo-Nuevo.md` existen; 0 id duplicados. Dos alias (`s3-0`, `s4-1`) caen en las Tablas C.1/C.2, no en `anexo-c`, y es correcto | script propio |
| E3 | Prácticas a los README (D-11 d) | **Cumple:** 0 «Práctica» en el libro; 16 de 17 README con «El código, paso a paso». El 14 no lo tiene, pero su código queda en el libro (§10.7) | `grep` |
| E3 | Excepción I-5 y línea ADR-01 | **Cumple:** «Excepción declarada» en §5.8 y columna ADR-01 en las fichas. El rótulo «I-5» no aparece literal | `grep` |
| E3 | §0.5 sin cifra; remite a `contar.sh` | **Cumple** (línea 166) | lectura |
| E3 | U-2.3: enlace al Conocimiento en el cap. 0 y al final de la Parte VI | **Parcial:** está en §0.6 y en §16.7 (Parte VII), no al final de la Parte VI. El desvío está declarado en el tramo 5 (nota del índice de E2), pero no hay decisión de mesa registrada | `grep` |
| E3 | Versión 0.12.0 «en revisión» | **Cumple** | front matter |
| E7 | ≤ 600 líneas | **Cumple** (599) | `wc -l` |
| E7 | Checklist D-23 al 100 % en la prueba de autocontención | **NO cumple:** quedan 3 DEBE en NO en la ronda 3 y no hubo ronda sobre el v1 final (lo declara E7) | `E7/Prueba-De-Autocontencion.md` |
| E7 | 0 P0/P1 de E5–E6 sin regla | **Cumple** según `E7/Caso-A-Regla.md` (10/10 P1). La trazabilidad no se re-derivó línea por línea | lectura |
| E7 | Verificador P-14 | **PENDIENTE** | — |
| E7 | Prueba en la estación 1 con turno | **Divergencia declarada:** se usó un agente sin la estación 1 | E7 §1.4 |
| E8 | Extensión dentro del tope | **Cumple** en la Parte VII (7.297 / 7.600) | `contar.sh` |
| E8 | Enlaces a Lab-Geometria resolubles | **Cumple:** 5/5 dan HTTP 200 y el commit `5f07b12` existe (`v1.2.0-5-g5f07b12`) | `curl` + `git` |
| E8 | 0 menciones del caso privado | **Cumple:** filtro U-7.1 con 0 coincidencias en la carpeta de la guía | §3 |
| E8 | Example 18 sólo si se implementa (D-27 b) | **Cumple:** no hay Example 18 y §16.3 lo explica | lectura |
| E9 | ≤ 5 casos en D.13 | **Cumple** (REF-209…213) | lectura |
| E9 | URL con fecha de consulta que responde | **Cumple:** 11/11 (REF-196…199, 207…213) con HTTP 200 y «consultado 2026-11-01» | `curl` |
| E9 | 0 Id renumerados | **Cumple** en lo verificable: no hay Id duplicados y los nuevos son ≥ 200. No hay versión en git contra la cual comparar | `uniq -d` |

## 3. Compuertas corridas

| Compuerta | Alcance | rc | Resultado |
|---|---|---|---|
| `tools/verificar.sh build`, con turno `build` por `[gestor-de-turnos]` (envoltorio `TURNO_CMD`) | todo `Examples/` | **0** | -warnaserror con 0 errores; pruebas y consolas `--fake --verificar` en verde; AC-6 ok; R-PRIV del build 0; un solo CONCEDIDO/LIBERADO. Las fases con modelo (`fase 3a/lan/3b`) quedan **NO EJECUTADO**: el plan pide `build` para E3 y no hubo turno de modelo |
| `tools/contar.sh` | libro | 0 | 59.375 / 60.000; Anexos 12.956 / 12.900 (sobre el tope) |
| `tools/verificar-markdown.py guia` | libro | 0 | 0 rotos |
| `tools/verificar-markdown.py arbol` / `ejemplos` | `Examples`, `Conocimientos` | 0 / 0 | 0 rotos |
| `tools/compuerta-referencias.sh` | carpeta de la guía | 0 | 0 rotas en 21 archivos |
| `tools/compuerta-intervalos.py` | libro + `Bitacoras/Evidencia/R-LLM` | 0 | 28/28 figuras en el mapa; 21/21 filas |
| `tools/compuerta-cabeceras.sh` | `Bitacoras/Evidencia` | 0 | 0 en 2 cuerpos (sobre `Examples` da rc 2: no hay cuerpos) |
| `tools/compuerta-rpriv.sh` | libro, `Examples`, `Conocimientos`, `Demos`, bitácoras E3/E7/E8/E9 y sus resúmenes | 0 | 0 hallazgos. Sólo clases genéricas, sin `COMPUERTAS_DIR` |
| Filtro U-7.1 (`grep -rniIF -f`, lista negra privada de 27 líneas) | carpeta de la guía en LD; `PROMPTs/Guides/16-IA-Layer` en LDD | — | LD: 0. LDD: una sola coincidencia, en el prompt del PO (`02-Ajuste-…md`), que no es salida de la etapa |
| `tools/medios/mermaid.sh` | libro (25) y Conocimiento (2) | 0 / 0 | todos ok |
| docs-guard `mermaid-arroba` (de `[ruta-trabajo]/dac-LD-comun`, todavía no está en el `main` de LD) | carpeta de la guía | 0 | verde: 27 bloques, 0 errores |
| docs-guard `fuera` | libro | 0 | verde |
| docs-guard `esquema` | libro | 1 | 12 errores, igual a la línea base |
| docs-guard `ai` | libro | 1 | **87 errores AI-4 contra 83 de la línea base (E8)**: ver H-2 |

## 4. Revisión adversarial

- **Contenido inventado: ninguno detectado.** Se cotejaron las afirmaciones nuevas contra su fuente:
  - capítulo 16 contra Lab-Geometria en `5f07b12`: el contrato del validador dice «36.00 donde la geometría dice 54.00» y «los señala y no los corrige»; `AGENTS.md` dice «siete proyectos de código»; `DependencyGateTests.cs` admite el prefijo `Microsoft`;
  - el ensayo contra `Ejecucion/E5.md`: 0/30, IC [0; 0,116], mediana 26,8 s y 24/30, que el libro escribe «cuatro de cada cinco»;
  - §14.1 contra las páginas: LinkedIn (~10 % → ~0,01 %), Shopify (kappa 0,02 → 0,61, humanos 0,69), Anthropic (una llamada con puntaje 0,0–1,0 y aprobado; observabilidad «without monitoring the contents of individual conversations») y GitHub (~6.000 caracteres).
- **Referencias que no dicen lo citado:** ninguna en las que se revisaron.
- **Salida del ejemplo 13:** la salida esperada que escribe el README, «protocolo MCP negociado: 2026-07-28», coincide con la corrida real de este build (línea 581 del log).
- **Deltas residuales:** en el libro no aparecen «antes decía» ni «en la versión anterior». El Anexo H, «anterior a esta versión», es procedencia por diseño (D-10 a). Ver H-3 y H-4.
- **Anclas rotas:** 0 internas. Ver H-1, sobre los destinos externos.

## 5. Hallazgos

| Id | Severidad | Hallazgo | Evidencia |
|---|---|---|---|
| H-1 | **P1** | El Anexo H (Tabla H.1) enlaza 11 veces a `/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/Guides/16-IA-Layer/OUTPUTs/Bitacoras/Prompt-02/E3/Tramo-*.md#5-…`. Esa carpeta está en `.git/info/exclude` de LDD y no se publica. En local resuelven; en GitHub serán enlaces rotos y exponen la ruta de una bitácora de trabajo en el libro público | `grep -o "(/LAB/[^)]*)"`; `git check-ignore -v` |
| H-2 | P2 | E9 sube docs-guard AI-4 de 83 a 87 errores: `github.blog`, `shopify.engineering`, `www.anthropic.com` y `www.linkedin.com` no están en `dominios.txt`, que es un archivo común. E9 no corrió docs-guard ni lo informa | diff de `E8/Evidencia/dg-ai.log` contra la corrida actual |
| H-3 | P2 | El Conocimiento declara «Compatible-con: … edición 0.11.0; las remisiones `[Guía §x]` usan esa numeración», pero en la carpeta sólo existe la 0.12.0, con capítulos corridos +1. Ejemplos: `[Guía §2.4]` es hoy §3.4 y `[Guía §13.x]` es hoy el cap. 14. Un lector del Conocimiento llega a la sección equivocada | línea 10 del Conocimiento; encabezados del libro |
| H-4 | P2 | Quedan 23 párrafos «Historia (hasta el 2026-10-28…)» en 13 README de `Examples/`. C-2.2 los saca del cuerpo, pero los README son material publicado del libro. Tramo 6 los difirió a E10 sólo para 15, 16 y 17 | `grep -rc "Historia ("` |
| H-5 | P2 | Los Anexos están 56 palabras sobre su tope (12.956 / 12.900) y `contar.sh` sale con rc 0 igual. La redistribución de topes del tramo 6 no tiene ratificación de mesa | `contar.sh`; P-E9-1 y tramo 6 §6.5 |
| H-6 | P2 | E7 no cumple el checklist D-23 al 100 %, P-14 no revisó y la prueba no usó la estación 1 | `Ejecucion/E7.md` §3 |
| H-7 | P3 | U-2.3: el segundo enlace al Conocimiento está en §16.7, no al final de la Parte VI. Hay desvío declarado, pero no hay decisión registrada | `grep` |
| H-8 | P3 | El índice del Prólogo (línea 60) enlaza «Parte VII» con el alias viejo `#parte-vi`. Resuelve, pero confunde. Lo mismo pasa con los alias `s13…`/`s14…` de las Partes I–VI (tramo 6 §6.2) | línea 60 |
| H-9 | P3 | El README 14 no tiene «El código, paso a paso». Su código sigue en el libro (§10.7, línea 1981) | `grep` |
| H-10 | P3 | `mermaid-arroba` existe sólo en las ramas de DocsAsCode (`[ruta-trabajo]/dac-LD-*`), no en el `main` de LD. Las etapas lo aplicaron a mano. Con el control real da verde | dg.py |

Fuera de estos, todos los criterios verificables están en verde.

## 6. Pendientes heredados y su estado

1. Revisión humana D-23 (E5, E6, E7) y P-14: **abierto**.
2. Mesa sobre los topes redistribuidos y los Anexos +56: **abierto** (H-5).
3. Remisiones del Conocimiento a la 0.12.0: **abierto** (H-3).
4. P-E9-2 (§9.9) y P-E9-3 (`protocolVersion` en `Garantias.cs`): **abiertos** para E10 y E11.
5. Verificación de etapa 2, pendientes 3 y 4 (U-7.1 y R-PRIV en la bitácora): hoy U-7.1 da 0 en LDD salvo el prompt del PO. R-PRIV en E3/E7/E8/E9 da 0. Antes de E11 se recomienda correr R-PRIV con `COMPUERTAS_DIR`, que esta verificación no tuvo.
6. Fases con modelo de `verificar.sh`: **NO EJECUTADO** (E11).

## 7. Mensajes ajenos

Ninguno durante la verificación.

Evidencia local de esta verificación (scratchpad de la sesión): log de `verificar.sh build`, salida de `contar.sh` y de docs-guard `ai`.
