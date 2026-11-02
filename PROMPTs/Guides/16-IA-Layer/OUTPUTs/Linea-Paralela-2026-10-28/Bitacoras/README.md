---
doc_id: BIT-16-README
doc_type: indice-de-bitacora
title: Bitácora de la mesa — Integración de una capa de IA en .NET
status: en curso
origin: agent
last_review: 2026-10-25
audience: [PO, mesa-evaluadora, próxima corrida de la mesa]
traces: [PROMPT-16, REED-16, BIT-16-00]
---

# Bitácora — Integración de una capa de IA en .NET

Cuaderno de trabajo de la mesa evaluadora que produce la guía `Dot-Net-Integration-AI-Layer-Guide.md`, en `/LAB/Lab-Documentos/Lab-Documentos/Guides/IA/Dot-Net-Integration-AI-Layer-Guide/`, junto con su laboratorio `Examples/` y su demo `Demos/`. La guía es el único entregable de lectura y no remite a esta bitácora, porque es autocontenida; la bitácora sí remite a la guía. Acá quedan borradores, apuntes, debates, informes verbatim y evidencia: sirven para retomar el trabajo o auditar cómo se llegó a cada decisión, no son material de estudio.

- **Prompt del PO** (sólo lectura): `../../Crear-IA-Layer-Guide.md`.
- **Prompt reeditado** sobre el marco de mesa: [`../Crear-IA-Layer-Guide-Reedicion.md`](../Crear-IA-Layer-Guide-Reedicion.md) (REED-16).
- **Marco**: `/IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md`.
- **Imagen de entrada**: `../../INPUTs/AI-Layer.png`.

## Estado

| Fase | Estado al 2026-10-25 |
|---|---|
| Fundación (contrato, descomposición, cohesión, marco de referencia, reedición) | hecha |
| Investigación por núcleo (`Nucleos/`) | pendiente |
| Integración (`04-Integracion.md`) | pendiente |
| Ciclos de mesa y relectura integral (`Mesa/`) | pendiente |
| Insumos del PO para la mesa: [`Mesa/I-01`](Mesa/I-01-Insumos-Del-PO-Agentes-LangGraph-Anotaciones.md) (LangGraph en .NET, Microsoft Graph, anotaciones para agentes) | vigente (2026-10-26) |
| Insumo del PO: [`Mesa/I-02`](Mesa/I-02-Insumo-Del-PO-Recorrido-AI-Engineer.md) (índice de un curso «AI Engineer 2026»: fuente de forma y cobertura, no citable) | vigente (2026-10-26) |
| Insumo del PO: [`Mesa/I-03`](Mesa/I-03-Insumo-Del-PO-Temario-AI-Engineering.md) (temario «AI Engineering»: forma y cobertura; tema nuevo CAG; despliegue) | vigente (2026-10-26) |
| Insumo del PO: [`Mesa/I-04`](Mesa/I-04-Insumo-Del-PO-Encuesta-Bloqueos.md) (encuesta sobre bloqueos para llevar IA a producción: señal de audiencia, no evidencia) | vigente (2026-10-26) |
| Insumo del PO: [`Mesa/I-05`](Mesa/I-05-Insumo-Del-PO-Desarrollo-De-Agentes-En-NET.md) (borrador «Desarrollo de agentes de IA en .NET»: ideas generales reencuadradas sobre Movilidad Urbana; no transcripto) | vigente (2026-10-26) |
| Directiva del PO: [`Mesa/I-06`](Mesa/I-06-Directiva-Del-PO-Caso-Unico-Y-Medios.md) (caso único Movilidad Urbana; medios móviles para la demo) | vinculante (2026-10-26) |
| Cierre (`05-Cierre.md`) | pendiente |

## Orden de lectura

### Fase 1 · Fundación (2026-10-25)

| Archivo | Qué es |
|---|---|
| [`00-Contrato-De-Entrada.md`](00-Contrato-De-Entrada.md) | Contrato de la mesa (M§2): objeto, objetivo, restricciones duras (R-PO-*, R-EVID, R-LLM, R-PRIV, R-ESCR, R-HOST), decisiones cerradas DC-01…DC-08, fuera de alcance, umbral, presupuesto; escala de evidencia y severidades aplicadas; inventario de señales; supuestos SUP-01…SUP-08; evidencia de partida (versiones de NuGet al 2026-10-25). |
| [`01-Descomposicion-Conceptual.md`](01-Descomposicion-Conceptual.md) | Núcleos N0…N6: alcance, ideas agrupadas, preguntas, por qué cada uno es un núcleo, diagrama de dependencias, decisiones de segmentación y plan de validación. |
| [`02-Cohesion-Global.md`](02-Cohesion-Global.md) | Grafo y matriz núcleo × núcleo, entregas entre núcleos, vínculos transversales, tensiones con regla de resolución, trazabilidad solicitud → núcleo → sección, estructura prevista de la guía, orden de trabajo. **Abierto**: se completa en la fase de plan y al integrar. |
| [`03-Marco-De-Referencia.md`](03-Marco-De-Referencia.md) | N0: escenarios ESC-01…05, contextos CTX-LOCAL/NUBE, CTX-PROTO/PROD, CTX-PUB/SENS, actores ACT-DEV/ARQ/OPS/SEC/USR y sus matrices de cruce. Pasa a la §2 de la guía. |

### Fase 2 · Investigación por núcleo e integración

| Carpeta o archivo | Qué contendrá |
|---|---|
| [`Nucleos/`](Nucleos/) | Un registro por núcleo, `N<n>-<slug>.md`, con la estructura de REED-16 §6.2: alcance y preguntas, fuentes con fecha, experimentos con comando y salida (R-LLM), marcas [C] resueltas, borrador de la sección, validación y entregas. |
| `04-Integracion.md` | Cuaderno de integración: tensiones de BIT-16-02 §5 resueltas, reparaciones en origen, modelo reconstruido. |

### Fase 3 · Mesa evaluadora

| Paso | Archivo en `Mesa/Ciclo-n/` | Qué es |
|---|---|---|
| 0 | `00-Convocatoria.md` (ciclo 1) | Barrido de señales, votación del catálogo, cartas de AH-01 y AH-02, descartes y apartamiento del techo del panel. |
| 1 | `Informe-<rol>.md`, `evidencia-<rol>/` | Informes verbatim, a ciegas. |
| 2 | `01-Consolidado.md` | Relatoría: ítems para el jurado, contradicciones, lote S4, preguntas C, solicitudes de convocatoria. |
| 3 | `02-Voto-<juez>.md` | Veredictos con fundamento. |
| 4 | `03-Parches.md` | Parches con texto exacto, capa y verificación. |
| 5 | `04-Aprobacion-<juez>.md` | `APLICAR`, `MEJORAR_PLAN`, `NO_APLICAR` o `ESCALAR`. |
| 6 | `05-Aplicacion.md`, `aplicacion/` | Aplicación, verificación, changelog y deuda. |

### Fase 4 · Cierre

`05-Cierre.md`: bloque de cierre de REED-16 §13. `Escaladas.md` sólo si hubo.

## Convenciones

- **IDs.** `BIT-16-nn` (documentos de la bitácora), `REED-16` (reedición), `S-nn` (solicitudes), `R-*` (reglas), `DC-nn` (decisiones cerradas), `SUP-nn` (supuestos), `N0…N6` (núcleos), `ESC-`, `CTX-`, `ACT-` (marco de referencia), `AH-nn` (ad hoc). En los ciclos: `C<ciclo>-NN` ítems de jurado, `P-NN` parches.
- **Evidencia.** Niveles E1–E4 y C, severidades S1–S4, según `00-Contrato-De-Entrada.md` §3. Las pruebas contra el modelo siguen R-LLM.
- **Solo agregado.** Las correcciones a documentos de fases anteriores se agregan como notas fechadas; no reescriben el texto original.
- **Privacidad (R-PRIV).** El servidor de IA es «el servidor Ollama de la LAN del laboratorio»; nunca se escriben su dirección, puerto, usuarios ni credenciales.
- **Rutas.** Fuera de esta carpeta, desde la raíz del workspace (`/LAB/...`, `/IA/...`).
- **Sin commit.** Nada de esto se commitea ni se sube desde la corrida.

## 2026-10-28 — Reanudación tras la caída de equipo anterior

> Nota agregada el 2026-10-28 desde estación 1. **Sólo agregado**: las tablas de arriba quedan como estaban al 2026-10-25/26 y esta nota las actualiza. Convención de nombres desde hoy: el servidor medido hasta el 2026-10-26 es **el servidor Ollama de la LAN del laboratorio (dado de baja el 2026-10-28)**; el que lo reemplaza es **el Ollama propio en contenedor (estación 1)**, que se usa sólo por `OLLAMA_ENDPOINT` (R-PRIV: su dirección no se escribe). Contexto completo y reglas de la reanudación: [`../Reanudar.md`](../Reanudar.md).

**Qué pasó.** equipo anterior murió el 2026-10-28 a las 00:50 (-03). La carpeta de la guía existía sólo en estación 1, en la copia del 2026-10-26 a la mañana. **Lo que se trabajó en equipo anterior el 26 y el 27 se perdió** (incluidos los intermedios de `{dir-de-trabajo}/`) y no se reconstruye de memoria. `Examples/`, `Demos/` y la guía final siguen vacíos.

### Estado real al 2026-10-28

| Fase | Estado |
|---|---|
| Fundación (contrato, descomposición, cohesión, marco de referencia, reedición) | **hecha** (2026-10-25) |
| Investigación por núcleo: [`Nucleos/`](Nucleos/) N0b, N1, N1b, N2, N3, N3b, N4, N5, N6 | **hecha, en borrador para el jurado** (25 y 26-10), con «Abierto / no verificado» y verificación adversarial. Cada registro tiene su «Nota de reanudación» del 2026-10-28 (qué se perdió, qué valen las mediciones previas, qué pasa a re-verificación) y su «Reparación de integración (BIT-16-04)» |
| Entorno nuevo | El Ollama propio en contenedor (estación 1): Ollama 0.40.11, CPU i7-8550U de 4 núcleos, 30 GB, sin GPU, contexto 4096 al cargar. Modelos (`/api/tags`): `qwen3.5:4b` (`d8b0f5e9760cd1682034f292d7ef72ec46f432149be0df7574bf2d6e92e38c04`), `qwen2.5:0.5b` (`a8b0c51577010a279d933d14c2a8ab4b268079d44c5c8830c0a93900f1827c67`), `qwen3-embedding:0.6b` (`ac6da0dfba84a81fdbfbaf330198c33cd77c4cdfc53e8bc50eb581914a15621d`). Acceso por turnos (recurso `<recurso-compartido>`) |
| [`Sondeo-Entorno.md`](Sondeo-Entorno.md) | Las §0–§8 son historia del servidor dado de baja. **Nota nueva del 2026-10-28** (§R.0–§R.5): sondeo E1 contra estación 1 (versión, modelos y capacidades, chat, embeddings 1024, tool calling R-LLM con N = 10, recomendaciones) |
| Integración ([`04-Integracion.md`](04-Integracion.md)) | **hecha** (2026-10-28): ocho tensiones resueltas, contradicciones entre núcleos y entre borradores, reparaciones en origen, 24 criterios propios para la mesa (MI-01…MI-24), modelo reconstruido, pendientes de re-verificación y estructura de la guía ajustada |
| Ciclo 1 de la mesa (`Mesa/Ciclo-1/`) | **pendiente** |
| Redacción de la guía, `Examples/` y `Demos/` (con pruebas contra el Ollama de estación 1) | **pendiente** |
| Relectura integral de la mesa | **pendiente** |
| Cierre (`05-Cierre.md`) | **pendiente** |

### Filas nuevas del orden de lectura

| Archivo o carpeta | Qué es |
|---|---|
| [`04-Integracion.md`](04-Integracion.md) | Cuaderno de integración (BIT-16-04): contexto de la reanudación, evidencia nueva, tabla de las ocho tensiones, contradicciones y su resolución, reparaciones en origen, criterios para la mesa, modelo completo (mermaid), pendientes contra estación 1 y estructura prevista de la guía |
| [`Sondeo-Evidencia/`](Sondeo-Evidencia/) | Scripts y salidas crudas del sondeo E1 del 2026-10-28 contra el Ollama propio en contenedor (estación 1) (`2026-10-28/`: `sondeo.py`, `correr.sh`, `correr-extra.sh`, `salidas/*.jsonl`) |
| [`Integracion-Evidencia/`](Integracion-Evidencia/) | Evidencia de la integración por grupo: `A-arquitectura/` (EA-1…EA-6: copia del caso base, prueba de arquitectura, tres vías de recuperación), `B-abstracciones-agentes/` (E-B1…E-B6: tool calling, salida estructurada, agente MAF con aprobación, ESC-01/ESC-02 por similitud, LangGraph) y `C-operacion-demo/` (X0…X5: versiones, OTel y ciclo de vida, escrituras propuestas por el modelo, ventana de contexto, variables del contenedor, caso base) |

**Próximo paso.** Convocatoria del ciclo 1 de la mesa (REED-16 §8–§9) con los criterios MI-01…MI-24 de BIT-16-04 §5 como insumo, y después la redacción de la guía, los ejemplos y la demo. Al cerrar cada fase, respaldar la carpeta `16-IA-Layer` en estación 2 (`Reanudar.md` §5).

## 2026-10-28 — Mesa ciclo 1

> Nota agregada el 2026-10-28 desde estación 1, al cerrar la aplicación del ciclo 1 (REED-16 §9.7). **Sólo agregado**, salvo la redacción R-PRIV in situ de Parche P-01 (rutas del home y una dirección con usuario, en 13 archivos de `OUTPUTs/`; el dictamen de la presidencia sobre esa excepción queda pendiente).

**Estado.** El ciclo 1 corrió completo: convocatoria, 13 informes a ciegas, consolidado (C1-01…C1-48, MI-01…MI-24 como C1-49…C1-72 y el lote C1-S4), cinco votos, revisión de homogeneidad, 44 parches del cuerpo auditor, cinco aprobaciones y aplicación. Los 73 ítems salieron `PROCEDE` y los 44 parches, `APLICAR`; no hubo `NO_APLICAR`, reversiones ni escaladas al PO. Siete parches quedan **condicionados** a una segunda ronda (P-05, P-17, P-23, P-35 y las partes de P-13, P-22 y P-27): se aplicó la parte común y las ramas quedaron escritas. La mayoría de los criterios de verificación se corren sobre `Examples/` y `Demos/`, que todavía no existen: quedan diferidos a la redacción y están listados uno por uno en `05-Aplicacion.md`. Ningún núcleo quedó validado (secciones «Validación del núcleo (ciclo 1)» al final de cada registro).

| Fase | Estado |
|---|---|
| Ciclo 1 de la mesa (`Mesa/Ciclo-1/`) | **hecho** (2026-10-28), con segunda ronda pendiente para los parches condicionados |
| Redacción de la guía, `Examples/` y `Demos/` | **pendiente**; la rige `Mesa/Ciclo-1/06-Plan-De-Redaccion.md` |
| Relectura integral de la mesa | **pendiente** |
| Cierre (`05-Cierre.md`) | **pendiente** |

| Archivo o carpeta | Qué es |
|---|---|
| [`Mesa/Ciclo-1/00-Convocatoria.md`](Mesa/Ciclo-1/00-Convocatoria.md) … [`04-Aprobacion-*.md`](Mesa/Ciclo-1/) | convocatoria, informes, consolidado, votos, homogeneidad, parches y aprobaciones del ciclo 1 |
| [`Mesa/Ciclo-1/05-Aplicacion.md`](Mesa/Ciclo-1/05-Aplicacion.md) | changelog hallazgo → veredicto → parche → verificación → archivo (sha256 y líneas), deuda declarada, escaladas y revertidos |
| [`Mesa/Ciclo-1/06-Plan-De-Redaccion.md`](Mesa/Ciclo-1/06-Plan-De-Redaccion.md) | **plan vinculante de redacción**: estructura por sección, `Examples/` y demo, pendientes asignados, RV-01…RV-19 por título, compuertas y decisiones abiertas |
| [`Mesa/Ciclo-1/aplicacion/`](Mesa/Ciclo-1/aplicacion/) | compuerta `rpriv.sh` con su salida antes y después, `verificar-ciclo-1.sh` y su salida, `conteo-preguntas.sh`, sondas E1 del limitador (Parche P-03) y de `OpcionesDeIA` (Parche P-11), extracto de la card de Qwen3.5-4B (Parche P-33) |
| [`Sondeo-Entorno.md`](Sondeo-Entorno.md) §R.6 y [`Sondeo-Evidencia/2026-10-28/cifras.py`](Sondeo-Evidencia/2026-10-28/cifras.py) | tabla única de cifras de la estación de laboratorio (Parche P-21) |
| [`Integracion-Evidencia/C-operacion-demo/README.md`](Integracion-Evidencia/C-operacion-demo/README.md) | cabeceras R-LLM de X2 y X3, `X3-fecha.txt` y copias de scripts (Parche P-25); criterio D1–D6 2b frente a 4b (Parche P-36) |

**Commit.** Nada se commitea desde la corrida. Además, por la condición del juez de riesgo, ningún commit de `OUTPUTs/` mientras `rpriv.sh` informe `identificadores > 0` (hoy hay nombres de equipos y de contenedores en la bitácora), salvo un dictamen fechado de la presidencia.

**Próximo paso.** Los entregables previos de `06-Plan-De-Redaccion.md` §1 (segunda ronda, plan de preguntas, trazabilidad, matriz de snippets, consultas PC), después `Examples/` y la guía. Respaldar la carpeta `16-IA-Layer` en el equipo de respaldo (`Reanudar.md` §5, con `RESPALDO_DESTINO`).

## 2026-10-28 — Mesa ciclo 1, ronda 2

> Nota agregada el 2026-10-28, al cerrar la aplicación de la segunda ronda del ciclo 1 (REED-16 §9.7; dictamen de la presidencia §3). **Sólo agregado**, salvo la redacción R-PRIV in situ de Parche P2-01 (1 ruta del home en `Mesa/Ciclo-1/Ronda-2/evidencia-AH-01-seguridad/README.md`, con la excepción del dictamen §1).

**Estado.** La segunda ronda votó la opción en 29 ítems (todos con mayoría de 3 o más, sin vetos), después de siete consultas dirigidas con experimentos (PC-01…PC-15). El cuerpo auditor diseñó 15 parches (P2-01…P2-15; P2-06 en dos vueltas) y los cinco jueces los aprobaron (`APLICAR`, con ajustes vinculantes). La aplicación insertó 102 notas fechadas en 17 archivos, creó la compuerta R-PRIV v2 y agregó a `06-Plan-De-Redaccion.md` la §10, que reemplaza todas las ramas provisionales de su §8. Ya no queda ninguna rama provisional: la demo es D1–D6, sin herramientas que escriban, con el normalizador en `Agregado/Application/Normalizacion` y la caché fuera de la demo. Queda abierto el sentido de «workflow» (C1-32) y el apagado del segundo servidor, los dos en manos de la presidencia, y las pruebas en `Cableado/` que levantan los bloqueos de N0b y N5 §4.2. **Escaladas: ninguna** (`Escaladas.md`).

| Fase | Estado |
|---|---|
| Ciclo 1 de la mesa, primera ronda | **hecho** (2026-10-28) |
| Ciclo 1 de la mesa, segunda ronda (`Mesa/Ciclo-1/Ronda-2/`) | **hecho** (2026-10-28) |
| Redacción de la guía, `Examples/` y `Demos/` | **pendiente**; la rige `Mesa/Ciclo-1/06-Plan-De-Redaccion.md`, con su §10 por encima de §0–§9 |
| Relectura integral de la mesa | **pendiente** |
| Cierre (`05-Cierre.md`) | **pendiente**; bloqueado por C1-32 y por «Validación del núcleo» |

| Archivo o carpeta | Qué es |
|---|---|
| [`Mesa/Ciclo-1/Ronda-2/00-Boleta.md`](Mesa/Ciclo-1/Ronda-2/00-Boleta.md) … [`04-Aprobacion-*.md`](Mesa/Ciclo-1/Ronda-2/) | boleta, consultas dirigidas con su evidencia, votos, parches y aprobaciones de la ronda 2 |
| [`Mesa/Ciclo-1/Ronda-2/05-Aplicacion.md`](Mesa/Ciclo-1/Ronda-2/05-Aplicacion.md) | changelog por parche y por ítem, ajustes incorporados, versiones (sha256 y líneas), compuertas, deuda declarada |
| [`Mesa/Ciclo-1/06-Plan-De-Redaccion.md`](Mesa/Ciclo-1/06-Plan-De-Redaccion.md) §10 | **reglas vinculantes de la ronda 2**: cómo quedó cada fila de §8, cambios por sección, RV nuevas, barridos, compuertas, parches del ciclo 1 reemplazados, pruebas a hacer pasar y lo abierto con su default |
| [`Mesa/Ciclo-1/Ronda-2/aplicacion/`](Mesa/Ciclo-1/Ronda-2/aplicacion/) | compuerta `rpriv.sh` v2 (con `cabeceras=`), sintéticos, casos rojos y verdes, salida antes y después; `verificar-ronda-2.sh` y su salida; verificaciones de P2-10 y PC-06 |
| [`Escaladas.md`](Escaladas.md) | registro de escaladas de M§6 (ninguna) y elevaciones internas a la presidencia con su default |

**Commit.** Nada se commitea desde la corrida. El primer commit de `OUTPUTs/` exige el barrido del dictamen §2 con la compuerta v2: `patrones=0`, `cabeceras=0` e `identificadores=0`.

**Próximo paso.** Los entregables previos de `06-Plan-De-Redaccion.md` §1 que siguen pendientes (plan de preguntas, trazabilidad, matriz de snippets, evidencia a guía), después `Examples/` con las pruebas de §10.7 y la guía. La presidencia decide C1-32 y el apagado del segundo servidor antes del cierre del ciclo 1.

## 2026-10-28 — Redacción

> Nota agregada el 2026-10-28, al cerrar la fase de compuertas de la redacción (REED-16 §9.1; plan de redacción §7 y §10.5). **Sólo agregado.** Sin commit.

**Estado.** La guía, los doce `Examples/` y la demo están escritos. Las compuertas corrieron sobre los tres y las fallas se corrigieron en la capa donde nacieron; donde un snippet no coincidía con el código, mandó el código compilado. Registro completo, con comandos, resultados antes y después y changelog: [`Mesa/Ciclo-2/00-Compuertas-Redaccion.md`](Mesa/Ciclo-2/00-Compuertas-Redaccion.md). Guía: sha256 `99e62a78…3885cf4` → `dcba317763c72d66686264f9e0189c387a84139f96592377a01d9089bb730325`.

| Compuerta | Resultado |
|---|---|
| C1–C5, snippets = código, enlaces y anclas, ids de bitácora, RD-PO-4, barridos §6 y §10.4 | cerradas (66 de 66 snippets; 194 enlaces, 0 rotos; 13 de 13 carpetas citadas) |
| Build y `Cableado/` en `sdk:10.0` (`sha256:de4fe90a…dc02b`) | 14 de 14 builds sin advertencias; 338/338 pruebas, también con la caché NuGet vacía |
| Versiones | Anexo D.2 = nuget.org = `.csproj` (32 filas); 0 vulnerables y 0 deprecados en 28 proyectos |
| Mermaid | 16 de 16 válidos (mermaid 11.12.0) |
| R-PRIV v2 y ampliado | `patrones=0 identificadores=0 cabeceras=0`; capturas revisadas |
| Presupuesto ±20 % | **abierta**: 8 de 11 secciones fuera (60 629 palabras frente a 40 200); pasa a la relectura integral |
| Clon limpio con modelo; R-LLM por archivo; RV-18 de las piezas de la demo; «flujo de trabajo» en el Anexo C | **abiertas** o a decidir por la presidencia (`00-Compuertas-Redaccion.md` §5) |

| Archivo o carpeta | Qué es |
|---|---|
| [`Mesa/Ciclo-2/00-Compuertas-Redaccion.md`](Mesa/Ciclo-2/00-Compuertas-Redaccion.md) | compuertas, comandos, antes y después, changelog con sha256, lo que no se cerró |
| [`Mesa/Ciclo-2/evidencia-compuertas/`](Mesa/Ciclo-2/evidencia-compuertas/) | salidas de cada compuerta, scripts, bloques Mermaid, salidas de `dotnet` y la consulta a nuget.org |
| [`Mesa/Ciclo-2/matriz-snippets.md`](Mesa/Ciclo-2/matriz-snippets.md) | estado real de las 70 filas (nota fechada al final): 58 corren, 2 compilan, 1 no ejecutado, 9 no entran |

**Próximo paso.** Relectura integral (REED-16 §10), con la compresión que pide el presupuesto, y las decisiones de la presidencia de `00-Compuertas-Redaccion.md` §5.
