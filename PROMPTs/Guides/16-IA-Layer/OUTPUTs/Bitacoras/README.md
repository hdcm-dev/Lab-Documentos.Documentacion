---
doc_id: BIT-16-README
doc_type: indice-de-bitacora
title: Bitácora de la mesa — Integración de una capa de IA en .NET
status: mesa cerrada (3 ciclos); construcción cerrada con deuda declarada; redacción cerrada (2026-10-28), con pendientes y dos decisiones del PO
origin: agent
last_review: 2026-10-28
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

| Fase | Estado al 2026-10-27 |
|---|---|
| Fundación (contrato, descomposición, cohesión, marco de referencia, reedición) | hecha |
| Investigación por núcleo (`Nucleos/`) | hecha: N0b, N1, N1b, N2, N3, N3b, N4, N5, N6 y [`Sondeo-Entorno.md`](Sondeo-Entorno.md); N0b y N6 con nota «Revisión de la mesa, ciclo 1» |
| Plan de integración ([`04-Plan-De-Integracion.md`](04-Plan-De-Integracion.md)) | **v3 = ESTRUCTURA APROBADA — FINAL** (2026-10-26, ciclo 3): estructura de referencia para la construcción y la redacción; v2, v1 y v0 en [`…v2.md`](04-Plan-De-Integracion.v2.md), [`…v1.md`](04-Plan-De-Integracion.v1.md) y [`…v0.md`](04-Plan-De-Integracion.v0.md) |
| Ciclo 1 de la mesa ([`Mesa/Ciclo-1/`](Mesa/Ciclo-1/)) | **cerrado** el 2026-10-26: 94 ítems votados, 93 procedentes, 24 parches aplicados, 0 revertidos, 8 ajustes declarados; una escalada al PO (ESC-001, embeddings; por defecto, Ollama propio en contenedor). Ver [`08-Cierre.md`](Mesa/Ciclo-1/08-Cierre.md) |
| Ciclo 2 de la mesa ([`Mesa/Ciclo-2/`](Mesa/Ciclo-2/)) | **cerrado** el 2026-10-26: auditoría de homogeneidad del ciclo 1, panel con Operación y entrega, jurado endurecido; 89 ítems votados (85 procedentes, 70 unánimes), 27 parches aplicados, 0 revertidos. Abre el ciclo 3. Ver [`08-Cierre.md`](Mesa/Ciclo-2/08-Cierre.md) |
| Ciclo 3 de la mesa ([`Mesa/Ciclo-3/`](Mesa/Ciclo-3/)) | **cerrado** el 2026-10-26: 40 ítems votados (27 hallazgos PROCEDE, 10 papeletas decididas, 3 contradicciones); 20 parches aplicados y 0 revertidos; DEP-14 resuelta (rige EMB-B). La mesa cierra por `ciclos_max` |
| Construcción de `Examples/` (01–17, `_Comun`) y `Demos/MovilidadUrbana.Asistente` ([`06-Construccion.md`](06-Construccion.md)) | **cerrada el 2026-10-27 con deuda declarada**: 18 piezas, 17 aprobadas con observaciones y **08 rechazada** (S2 en su oráculo, sin corregir); AC-1, AC-2, AC-4, AC-5, AC-8, AC-10 y AC-11 cumplen; **AC-6 falla en Examples** (OpenTelemetry en dos versiones; beta transitivo de SK); AC-3b parcial (DEP-03, DEP-09 y DEP-13 sin corrida; extensiones 03, 04 y 08 sin correr); AC-7 cumple sobre lo construido, con 5 falsos positivos en la bitácora; `<recurso-compartido>` 7.795 s de 14.400; `[recurso-modelo-propio]` 1.785 s de 7.200. Evidencia en `Evidencia/` y `Evidencia/Cierre-Construccion/` |
| Redacción de la guía ([`07-Redaccion.md`](07-Redaccion.md)) | **cerrada el 2026-10-28**: guía 0.10.1 completa (Partes 0 a VI, Cierre, Anexos A a G; 66.458 palabras). Relectura de nueve perfiles más el jurado: 98 filas consolidadas (3 S1, 25 S2, 48 S3, 17 S4 y 5 compresiones), 88 aplicadas completas y 10 en parte; aprobada con una condición, ya cumplida. AC-1 a AC-11 cumplen sobre la guía escrita (AC-3a no se volvió a correr). Quedan para el PO la publicación de la demo y ESC-001. Logs en `Evidencia/Cierre-Redaccion/` |
| Insumos del PO para la mesa: [`Mesa/I-01`](Mesa/I-01-Insumos-Del-PO-Agentes-LangGraph-Anotaciones.md) (LangGraph en .NET, Microsoft Graph, anotaciones para agentes) | vigente (2026-10-26) |
| Insumo del PO: [`Mesa/I-02`](Mesa/I-02-Insumo-Del-PO-Recorrido-AI-Engineer.md) (índice de un curso en línea de terceros: fuente de forma y cobertura, no citable) | vigente (2026-10-26) |
| Insumo del PO: [`Mesa/I-03`](Mesa/I-03-Insumo-Del-PO-Temario-AI-Engineering.md) (temario de un curso en línea de terceros: forma y cobertura; tema nuevo CAG; despliegue) | vigente (2026-10-26) |
| Insumo del PO: [`Mesa/I-04`](Mesa/I-04-Insumo-Del-PO-Encuesta-Bloqueos.md) (encuesta sobre bloqueos para llevar IA a producción: señal de audiencia, no evidencia) | vigente (2026-10-26) |
| Insumo del PO: [`Mesa/I-05`](Mesa/I-05-Insumo-Del-PO-Desarrollo-De-Agentes-En-NET.md) (borrador «Desarrollo de agentes de IA en .NET»: ideas generales reencuadradas sobre Movilidad Urbana; no transcripto) | vigente (2026-10-26) |
| Directiva del PO: [`Mesa/I-06`](Mesa/I-06-Directiva-Del-PO-Caso-Unico-Y-Medios.md) (caso único Movilidad Urbana; medios móviles para la demo) | vinculante (2026-10-26) |
| Cierre ([`05-Cierre-Mesa-De-Estructuracion.md`](05-Cierre-Mesa-De-Estructuracion.md)) | hecho: una página para el PO con lo decidido, lo descartado y lo que queda para la construcción |

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
| [`04-Plan-De-Integracion.md`](04-Plan-De-Integracion.md) | Plan de integración (BIT-16-04): estructura de la guía, marco conceptual, tratamiento de PR-1…PR-22, especificación de `Examples/` y `Demos/`, riesgos y dependencias. **v2 aprobada en el ciclo 2**; copias v1 y v0; registro de cambios, changelogs de los ciclos 1 y 2 y re-votos al final. |
| [`Compuertas/rd-po-4.excepciones`](Compuertas/rd-po-4.excepciones) | Excepciones del barrido RD-PO-4 (AC-8) y archivos pendientes de reescritura. Recalculado en el ciclo 2. |
| [`Compuertas/rd-po-4.positivos`](Compuertas/rd-po-4.positivos) | Casos positivos del barrido (PAR2-03): el barrido tiene que marcar sus cinco líneas. |
| [`Compuertas/rd-po-4.negativos`](Compuertas/rd-po-4.negativos) | Casos negativos del barrido (PAR3-15): el patrón no tiene que marcar ninguna línea. |
| [`Compuertas/familias-id.positivos`](Compuertas/familias-id.positivos) · [`.negativos`](Compuertas/familias-id.negativos) | Casos de prueba de la compuerta de familias de ID (PAR3-03). |

### Fase 3 · Mesa evaluadora

Ciclo 1 (2026-10-26), en [`Mesa/Ciclo-1/`](Mesa/Ciclo-1/). La numeración real de los archivos difiere de la prevista en REED-16 §12; esta tabla es la vigente.

| Paso | Archivo | Qué es |
|---|---|---|
| Insumos | [`Mesa/I-01`…`I-06`](Mesa/) | Insumos y directiva del PO (I-06 vinculante). |
| 1 | [`01-Convocatoria.md`](Mesa/Ciclo-1/01-Convocatoria.md) | Composición del panel con motivos, catálogo variable, techo excedido por pedido del PO, contraste con los hallazgos. |
| 2 | [`02-Informes/`](Mesa/Ciclo-1/02-Informes/) | Doce informes a ciegas (núcleo, seis perfiles del PO, AH-01, AH-02). |
| 3 | [`03-Consolidacion.md`](Mesa/Ciclo-1/03-Consolidacion.md) | Relatoría: 63 hallazgos, 9 contradicciones, 22 propuestas PR, preguntas C, solicitudes de convocatoria. |
| 4 | [`04-Veredictos.md`](Mesa/Ciclo-1/04-Veredictos.md) | Votos de los cinco jueces por ítem, con fundamento; sospecha de homogeneidad. |
| 5 | [`05-Parches.md`](Mesa/Ciclo-1/05-Parches.md) | Parches PAR-01…PAR-24 con texto exacto, capa y verificación. |
| 6 | [`06-Aprobacion.md`](Mesa/Ciclo-1/06-Aprobacion.md) | Mesa de decisión: 24 `APLICAR`; objeciones minoritarias. |
| 7 | [`07-Aplicacion-Y-Verificacion.md`](Mesa/Ciclo-1/07-Aplicacion-Y-Verificacion.md) | Aplicación, ajustes AJ-01…AJ-08, verificación por parche y chequeos de coherencia. |
| 8 | [`08-Cierre.md`](Mesa/Ciclo-1/08-Cierre.md) | Bloque de cierre de M§7, deuda declarada, escalada ESC-001 y capas a revalidar. |

Ciclo 2 (2026-10-26), en [`Mesa/Ciclo-2/`](Mesa/Ciclo-2/), sobre la v1.

| Paso | Archivo | Qué es |
|---|---|---|
| 0 | [`00-Auditoria-Homogeneidad.md`](Mesa/Ciclo-2/00-Auditoria-Homogeneidad.md) · [`00-Revision-Abogado-NO-PROCEDE.md`](Mesa/Ciclo-2/00-Revision-Abogado-NO-PROCEDE.md) | Auditoría del jurado del ciclo 1 (diagnóstico «mixto») y revisión de los `NO_PROCEDE` (M§9). |
| 1 | [`01-Convocatoria.md`](Mesa/Ciclo-2/01-Convocatoria.md) | Panel: núcleo, seis perfiles del PO, Operación y entrega (con su señal), AH-01, AH-02; techo respetado. |
| 2 | [`02-Informes/`](Mesa/Ciclo-2/02-Informes/) | Trece informes a ciegas. |
| 3 | [`03-Consolidacion.md`](Mesa/Ciclo-2/03-Consolidacion.md) | 59 hallazgos, 9 ratificaciones, 14 re-votos, 7 contradicciones. |
| 4 | [`04-Veredictos.md`](Mesa/Ciclo-2/04-Veredictos.md) | Jurado endurecido: 85 PROCEDE de 89, 70 unánimes, 5 INSUFICIENTE. |
| 5 | [`05-Parches.md`](Mesa/Ciclo-2/05-Parches.md) | Parches PAR2-01…PAR2-27 con texto exacto, capa, verificación y papeletas. |
| 6 | [`06-Aprobacion.md`](Mesa/Ciclo-2/06-Aprobacion.md) | 27 `APLICAR` (19 unánimes); objeciones en minoría; papeletas sin votar. |
| 7 | [`07-Aplicacion-Y-Verificacion.md`](Mesa/Ciclo-2/07-Aplicacion-Y-Verificacion.md) | Aplicación literal, verificación por parche, chequeos mecánicos, compuertas recalculadas. |
| 8 | [`08-Cierre.md`](Mesa/Ciclo-2/08-Cierre.md) | Bloque de cierre de M§7: 57/63 = 90,5 %, H2-050 abierto → ciclo 3. |

Ciclo 3 (2026-10-26), en [`Mesa/Ciclo-3/`](Mesa/Ciclo-3/), sobre la v2. Es el último.

| Paso | Archivo | Qué es |
|---|---|---|
| 1 | [`01-Convocatoria.md`](Mesa/Ciclo-3/01-Convocatoria.md) | Agenda obligatoria y panel de nueve informes (techo respetado). |
| 2 | [`02-Informes/`](Mesa/Ciclo-3/02-Informes/) | Nueve informes a ciegas. |
| 3 | [`03-Consolidacion.md`](Mesa/Ciclo-3/03-Consolidacion.md) | 27 hallazgos, 10 papeletas, 3 contradicciones. |
| 4 | [`04-Veredictos.md`](Mesa/Ciclo-3/04-Veredictos.md) | 40 ítems, 31 unánimes; sin segundas rondas; minorías transcriptas. |
| 5 | [`05-Parches.md`](Mesa/Ciclo-3/05-Parches.md) | PAR3-01…PAR3-20 con texto exacto. |
| 6 | [`06-Aprobacion.md`](Mesa/Ciclo-3/06-Aprobacion.md) | 20 `APLICAR` (18 unánimes); objeciones de riesgo. |
| 7 | [`07-Aplicacion-Y-Verificacion.md`](Mesa/Ciclo-3/07-Aplicacion-Y-Verificacion.md) | Aplicación literal, verificación por parche y chequeos finales. |
| 8 | [`08-Cierre.md`](Mesa/Ciclo-3/08-Cierre.md) | Bloque de cierre de M§7 de los tres ciclos, deuda consolidada, ESC-001, DEP-14. |

### Fase 4 · Cierre

[`05-Cierre-Mesa-De-Estructuracion.md`](05-Cierre-Mesa-De-Estructuracion.md): una página para el PO. No hubo escaladas nuevas, así que no hay `Escaladas.md`; ESC-001 está en `Mesa/Ciclo-3/08-Cierre.md`.

### Fase 5 · Construcción (2026-10-27)

| Archivo o carpeta | Qué es |
|---|---|
| [`06-Construccion.md`](06-Construccion.md) | Cierre de la construcción: estado y veredicto por pieza, compuertas AC-1…AC-11, turnos contra el tope de §E.5, inventario y limpieza de §E.6, cifras citables y deuda para la redacción. |
| [`Evidencia/`](Evidencia/) | Evidencia por pieza, `R-LLM/` (registros recalculables), `Arnes/` (turnos y logs del arnés) y `Cierre-Construccion/` (compuertas, build, recálculo y medidor del cierre). |
| [`Evidencia/saneamiento-R-PRIV.md`](Evidencia/saneamiento-R-PRIV.md) | Saneamiento R-PRIV y R-06 de la bitácora previo a construir. |

### Fase 6 · Redacción (2026-10-27 y 2026-10-28)

| Archivo o carpeta | Qué es |
|---|---|
| [`07-Redaccion.md`](07-Redaccion.md) | Cierre de la redacción: cómo se escribió (muestra, cuerpo, síntesis), relectura integral de la mesa, parches, compresión, compuertas AC-1…AC-11 con sus logs, limpieza de §E.6, pendientes y decisiones del PO. |
| [`Redaccion/`](Redaccion/) | Carta de redacción, glosario, registro de referencias y de versiones, decisiones de la muestra, pendientes por sección, acta de la relectura, `secciones/` (borradores, no resincronizados) y la guía previa a la compresión. |
| [`Evidencia/Cierre-Redaccion/`](Evidencia/Cierre-Redaccion/) | Logs del cierre de la redacción: build y pruebas, compuertas, AC-9 (bloques y cifras), anclas, REF y mermaid, render de mermaid, limpieza y turnos. |

## Convenciones

- **IDs.** `BIT-16-nn` (documentos de la bitácora), `REED-16` (reedición), `S-nn` (solicitudes), `R-*` (reglas), `DC-nn` (decisiones cerradas), `SUP-nn` (supuestos), `N0…N6` (núcleos), `ESC-`, `CTX-`, `ACT-` (marco de referencia), `AH-nn` (ad hoc). En los ciclos: `C<ciclo>-NN` ítems de jurado, `P-NN` parches.
- **Evidencia.** Niveles E1–E4 y C, severidades S1–S4, según `00-Contrato-De-Entrada.md` §3. Las pruebas contra el modelo siguen R-LLM.
- **Solo agregado.** Las correcciones a documentos de fases anteriores se agregan como notas fechadas; no reescriben el texto original.
- **Privacidad (R-PRIV).** El servidor de IA es «el servidor Ollama de la LAN del laboratorio»; nunca se escriben su dirección, puerto, usuarios ni credenciales.
- **Rutas.** Fuera de esta carpeta, desde la raíz del workspace (`/LAB/...`, `/IA/...`).
- **Sin commit.** Nada de esto se commitea ni se sube desde la corrida.

---

> **2026-10-28 — Recuperación de la línea de <equipo-principal> como base.** Nota agregada (sólo agregado; no reescribe lo anterior).
>
> - **Qué pasó.** El 2026-10-28 a las 00:50 el equipo principal perdió la red y la corrida se reanudó en el equipo de contingencia (<equipo-de-contingencia>) desde la foto del 26-10. A las 20:20 el equipo principal (<equipo-principal>) volvió con una línea más avanzada: plan de integración v3, mesa en tres ciclos, construcción de `Examples/` 01–17 y la demo, y redacción de la guía 0.10.1 con relectura. Por decisión del PO (en paráfrasis: tomar como base los avances del equipo principal y recuperarlos acá), **esa línea es la base**.
> - **Base restaurada.** Esta carpeta (`OUTPUTs/Bitacoras/`: README, `04-Plan-De-Integracion.md` v3, `Mesa/Ciclo-1…3`, `05-Cierre-Mesa-De-Estructuracion.md`, `06-Construccion.md`, `07-Redaccion.md`, `Evidencia/`, `Compuertas/`, `Redaccion/`, `Nucleos/`, `Sondeo-Entorno.md`) y la guía `/LAB/Lab-Documentos/Lab-Documentos/Guides/IA/Dot-Net-Integration-AI-Layer-Guide/` (0.10.1, `Examples/` 01–17, `Demos/MovilidadUrbana.Asistente/`, `tools/`, `Compuertas/`), restauradas desde la copia de sólo lectura tomada del equipo principal el 2026-10-28 a las 20:25.
> - **Línea de contingencia archivada.** `/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/Guides/16-IA-Layer/OUTPUTs/Linea-*-2026-10-28/` guarda intacta, **sólo lectura**, la línea del equipo de contingencia: bitácora (reanudación, `04-Integracion`, sondeo de los servidores vigentes con §R, mesa ciclo 1 con ronda 2 y dictamen, ciclo 2 con compuertas de redacción, 13 informes de relectura) y `Guia/` (guía de 4.107 líneas, 12 ejemplos y demo). Su `README.md` explica el contenido. Es **insumo** de la mesa de recuperación, no base.
> - **Foto previa al cambio.** `$FOTOS/linea-*-2026-10-28-2040.tgz` (directorio de fotos fuera del árbol) (estado completo de la línea de contingencia antes de restaurar la base; con copia en la estación de respaldo).
> - **Mesa de recuperación.** `Mesa/Recuperacion-2026-10-28/`: seis inventarios, matriz de 35 ítems (`01-Matriz.md`), panel y jurado (`Panel-*.md`, `02-Voto-*.md`), plan ejecutable aprobado (`03-Plan-De-Recuperacion.md`, bloques B-00…B-15) y registro de procedencia (`Procedencia.md`: cada pieza traída del insumo, con su origen y sha256). La guía resultante será la **0.11.0**, «en revisión» hasta cerrar la re-corrida con modelo en los dos servidores vigentes (REC-02) y la relectura integral (REC-03).
> - **Entorno.** El «servidor Ollama de la LAN del laboratorio» de la convención R-PRIV de arriba **ya no existe**: sus cifras valen como historia. Rigen dos roles: «estación de laboratorio de 4 núcleos» (estación 1) y «estación de laboratorio con más núcleos» (estación 2); endpoints sólo como variables (la convención se actualiza en B-02 del plan).
> - **R-PRIV.** Los nombres de equipos de esta nota se admiten hasta el commit por el dictamen adoptado en REC-33; el barrido previo al commit los reemplaza por marcadores. Sin commit, push ni PR desde esta corrida.

> **2026-10-29 — Recuperación, bloque B-02: notas a §Convenciones (sólo agregado, salvo la redacción R-PRIV que se describe).**
>
> - **Dictamen R-PRIV adoptado (REC-33, opción A).** Rige [`Mesa/Recuperacion-2026-10-28/Dictamen-R-PRIV-Bitacora.md`](Mesa/Recuperacion-2026-10-28/Dictamen-R-PRIV-Bitacora.md) (§1 y §2 del dictamen de la presidencia del insumo): R-PRIV le gana a «sólo agregado», **sólo para borrar lo que R-PRIV prohíbe**; la guía, `Examples/` y `Demos/` van con cero equipos, contenedores y recursos del laboratorio; en la bitácora, el barrido de redacción es condición de cualquier commit. Dictamen fechado sobre la clase de C1-39 (contenedores, volúmenes, red, etiqueta, recursos y herramienta de turnos): **es privada** y se redacta en la prosa, en los planes y en los `.log`/`.txt`; las capturas que alimentan recálculos quedan como están (ver abajo).
> - **Redacción hecha en B-02 (pasos 2.2 a 2.4).** Barrido por mapa de valor exacto (el mapa vive fuera del repo, en el directorio de trabajo) sobre los `.md`, `.log` y `.txt` de esta carpeta, incluida la mesa de recuperación: 157 archivos, 735 líneas, sin agregar ni quitar líneas. Además, a mano: I-06:10 en paráfrasis (y su excepción de `Compuertas/rd-po-4.excepciones` retirada como comentario fechado), el teléfono del PO y el gestor en I-06:27-29 y `06-Construccion.md` §4, el nombre comercial de los dos cursos de terceros en este README y en `02-Cohesion-Global.md`, la cita del PO de la nota de recuperación de arriba (paráfrasis) y las listas de términos privados de dos inventarios de la mesa. Por eso **la nota «Recuperación de la línea …» de arriba ya no nombra equipos** y su última viñeta («se admiten hasta el commit») quedó cumplida.
> - **Marcadores vigentes** (RPRI-12, y los de la línea `origin/main`): `{dir-de-trabajo}` (directorio de trabajo fuera del repo), `{dir-de-sesion}` (directorio temporal de la sesión), `{copia-de-rescate}`, `{disco-de-trabajo}`, `$FOTOS` (fotos fuera del árbol), `$INSUMO` (la línea archivada); `<equipo-principal>` (el equipo que perdió la red el 2026-10-28), `<equipo-de-contingencia>` (el equipo donde siguió la corrida), `<estación-2>`; `<teléfono-de-prueba>`; `<ollama>`, `<[recurso-modelo-propio]>`, `<ollama-n3>`, `<ollama-n3b>` (contenedores de Ollama), `<volumen-nuget>`, `<volumen-nuget-n3>`, `<volumen-artefactos…>` (con el sufijo que tenía), `<red-del-arnés>`, `<etiqueta-del-arnés>`, `<contenedor-del-arnés>`, `<contenedor-de-cierre>`, `<prefijo-del-laboratorio>`; `<gestor-de-turnos>` = «gestor de turnos del laboratorio (privado)», `<dir-del-gestor>`; `<recurso-compartido>`, `<recurso-estación-2>`, `<recurso-emulador>` (nombres de recursos del gestor); «clave de cabeceras por pedido».
> - **Roles vigentes desde el 2026-10-28** (reemplazan, para lo nuevo, a «el servidor Ollama de la LAN del laboratorio» de la convención R-PRIV de arriba, que pasa a historia): **estación 1** = «estación de laboratorio de 4 núcleos»; **estación 2** = «estación de laboratorio con más núcleos» (nunca emuladores ni KVM). Sus endpoints sólo como variables; nunca se escriben.
> - **Equivalencia de papeles (REC-07 C).** En el repo de la guía, desde B-01, el arnés pide los papeles `modelo-compartido` y `modelo-propio`; un adaptador fuera del repo los traduce a los recursos del gestor. En la bitácora: `<recurso-compartido>` ≡ `modelo-compartido`, y el recurso del «Ollama propio» (`[recurso-modelo-propio]`, que el gestor ya no tiene; el barrido no lo cuenta como privado y queda escrito así) ≡ `modelo-propio`. **El recurso de la estación 1 se llama igual que el recurso del servidor compartido de antes**: hasta el 2026-10-28, `<recurso-compartido>` era el turno del servidor compartido de la LAN (retirado); desde el 2026-10-28 es el turno de la estación 1. Toda cifra anterior a esa fecha con ese recurso es del servidor retirado. El nombre de fase `lan` del arnés **no se renombra** (cambiaría rótulos de capturas fijadas por hash): es el nombre histórico del rol «estación 1 / modelo compartido» (m-2 del plan).
> - **Capturas con valores históricos (RPRI-11, paso 2.3).** `Evidencia/R-LLM/*.jsonl`, los demás `.jsonl` de `Evidencia/` y los `.tsv` del gestor y del medidor **no se tocaron**: alimentan recálculos y hashes citados. Conservan, como valor histórico declarado, el nombre del recurso de turno del servidor compartido (el que acá se escribe `<recurso-compartido>`). Son las únicas coincidencias que deja el barrido sobre esta carpeta (37 archivos: 31 `.jsonl` y 6 `.tsv`; la compuerta R-PRIV del repo cuenta 36, porque en uno la coincidencia es un valor histórico que ya exceptúa por valor exacto); `recalcular-oraculos.sh` sobre `R-LLM/` sigue dando 365 de 365.
> - **Fuera de todo commit** (pasos 2.4 y 2.5): las tres capturas PNG de terceros (`Mesa/I-02-…png`, `Mesa/I-03-…png`, `Mesa/I-04-…png`), las transcripciones de I-02, I-03 e I-04 (material de terceros no citable; no se resumieron en el lugar porque no es borrado R-PRIV: queda para la mesa que integra) y `OUTPUTs/Reanudar.md` (nota de la línea archivada; la mueve la presidencia a `$INSUMO` después de esta nota). Lista en `Mesa/Recuperacion-2026-10-28/04-Aplicacion.md`, B-02.
> - **Sondeo vigente (REC-06.4).** [`Sondeo-Entorno.md`](Sondeo-Entorno.md) lleva una nota fechada («§0–§8 son historia») y el §R del insumo (sondeo de la estación 1 y §R.7 de la estación 2), con crudos en [`Evidencia/Sondeo-2026-10-28/`](Evidencia/Sondeo-2026-10-28/).
> - **Deudas resueltas que la tabla de estado de arriba todavía muestra (REC-06.5).** La fila de construcción dice «08 rechazada» y «AC-6 falla en Examples»: las dos quedaron **resueltas** en el saneamiento del 2026-10-27, como dice [`06-Construccion.md`](06-Construccion.md) §2.1 (estado vigente: 08 aprobado con observaciones, AC-6 cumple, con `OpenTelemetry.Api` 1.20.1 fijado y la preview `Azure.AI.OpenAI` 2.9.0-beta.1 como excepción escrita). La fila de redacción dice que quedan para el PO «la publicación de la demo y ESC-001»: **ESC-001 se cerró «sin objeto»** el 2026-10-29 (ver `Mesa/Ciclo-3/08-Cierre.md` y `07-Redaccion.md`, notas de B-02); al PO le quedan la publicación de la demo, el commit y el paso a «publicada».
> - **Pedidos al gestor (DEU-04, REC-06.8).** Tres pedidos los hace la presidencia fuera del repo: que el gestor no tenga una dirección de Ollama por defecto, una verificación de salud para la estación 2 y la regla «nunca emuladores ni KVM» en su protocolo. Esta mesa no los verifica.

> **2026-10-29 — Plan de recuperación aplicado (B-00…B-13).** Nota agregada (sólo agregado).
>
> - **Guía 0.11.0, «en revisión».** Se aplicaron los bloques B-00 a B-13 de [`Mesa/Recuperacion-2026-10-28/03-Plan-De-Recuperacion.md`](Mesa/Recuperacion-2026-10-28/03-Plan-De-Recuperacion.md) (con las enmiendas de la Vuelta 2): arnés y `tools/`, bitácora, `Examples/`, demo, guía por partes, fase con modelo única en las dos estaciones vigentes (B-11), relleno de cifras (B-12, 0 marcadores pendientes) y encabezado 0.11.0 (B-13). Detalle, sha256 y desvíos por bloque en [`04-Aplicacion.md`](Mesa/Recuperacion-2026-10-28/04-Aplicacion.md); piezas del insumo en [`Procedencia.md`](Mesa/Recuperacion-2026-10-28/Procedencia.md).
> - **Verificación integral al cierre de B-13.** Build 561/561 (18 proyectos) y demo 79/79 sin modelo, AC-5…AC-10, `verificar-markdown.py`, `compuerta-intervalos.py` y barrido R-PRIV en 0 (salvo el valor histórico declarado de 15). Sin `bin/`, `obj/` ni `*.db` en la guía.
> - **Lo que falta.** B-14 (relectura integral, REC-03/REC-04) y B-15 (presentación al PO: publicación de la demo, commit y paso a «publicada», DEU-07). Sin commit, push ni PR desde esta corrida.

> **2026-11-02 — Bitácora enmascarada (decisión del PO, prompt 02).** Nota agregada (sólo agregado).
>
> Toda la carpeta `OUTPUTs/` (bitácora del prompt 01, `Mesa/Recuperacion-2026-10-28/`, `Prompt-02/` y la línea paralela) se publica **enmascarada**: los datos que comprometen servicios o cuentas se sustituyen por marcadores estables; la idea de cada registro se conserva. La carpeta de la línea paralela del 2026-10-28 pasó a llamarse `Linea-Paralela-2026-10-28/` (antes llevaba el nombre de un equipo). Los registros con sha256 citado cambian de huella: la correspondencia vieja→nueva está en [`Prompt-02/E11/Enmascarado-Mapa-sha256.tsv`](Prompt-02/E11/Enmascarado-Mapa-sha256.tsv); el detalle, en [`Prompt-02/E11/Enmascarado.md`](Prompt-02/E11/Enmascarado.md).
>
> | Marcador | Qué representa |
> |---|---|
> | `[host-dev]` | equipo de desarrollo del laboratorio (estación 1) |
> | `[host-ia]` | máquina virtual de inferencia del laboratorio |
> | `[host-infra]` | servidor de infraestructura del laboratorio |
> | `[host-mac]` | equipo Mac del laboratorio |
> | `[api-de-modelos]` | API privada de modelos del laboratorio |
> | `[recurso-modelo]` | recurso «servidor de modelos en la red» del gestor de turnos |
> | `[recurso-modelo-propio]` | recurso «servidor de modelos propio» del gestor de turnos |
> | `[gestor-de-turnos]` | script del gestor de turnos de recursos compartidos |
> | `[usuario]` | cuenta de usuario del equipo |
> | `[ruta-home]` | directorio personal (`[ruta-home]/…`) |
> | `[ruta-trabajo]` | carpeta de trabajo de los agentes fuera del repo (`[ruta-trabajo]/…`) |
> | `[ruta-temporal]` | carpeta temporal de las sesiones |
> | `[IP-privada]` | dirección de red privada (RFC 1918) |
> | `[IP-tailnet]` | dirección de la red superpuesta (rango compartido RFC 6598) |
> | `[puerto]` | puerto no estándar de un servicio del laboratorio |
>
> Se mantienen los marcadores anteriores de la forma `<…>` y `{estación-N}`. Los identificadores de turno conservan fecha, hora y sufijo (p. ej. `20261027T134714-[recurso-modelo]-…`). Las cadenas `10.11.0.0` y `10.0.0.0` son versiones de ensamblado, no direcciones (RPRI-19).
