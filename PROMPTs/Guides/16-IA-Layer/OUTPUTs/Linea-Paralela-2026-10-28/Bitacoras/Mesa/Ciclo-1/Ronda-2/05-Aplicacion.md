---
doc_id: BIT-16-C1-R2-05
doc_type: aplicacion-y-verificacion
title: Aplicación y verificación de la segunda ronda del ciclo 1 (REED-16 §9.7, M§5.6)
status: hecho
origin: agent
owner: aplicación de la ronda 2 (aplica y verifica; no vota)
last_review: 2026-10-28
audience: [presidencia, redacción, relectura integral, PO]
traces: [Mesa/Ciclo-1/07-Dictamen-Presidencia.md §1–§4; Ronda-2/00-Boleta.md; Ronda-2/02-Voto-*.md; Ronda-2/03-Parches.md (P2-01…P2-15, P2-06 vuelta 2); Ronda-2/04-Aprobacion-*.md (vueltas 1 y 2); Mesa/Ciclo-1/05-Aplicacion.md; Mesa/Ciclo-1/06-Plan-De-Redaccion.md §10; Escaladas.md; REED-16 §9.1, §12]
---

# Aplicación y verificación de la segunda ronda del ciclo 1

Apliqué los 15 parches de la ronda 2 (`APLICAR` en los 15; P2-06 en su vuelta 2), con los ajustes vinculantes de los jueces de evidencia, riesgo, impacto y coherencia histórica, y las posiciones `MEJORAR_PLAN` en minoría que eran mecánicas, como hizo la aplicación del ciclo 1. Las capas de guía, laboratorio y demo quedaron como reglas vinculantes en la §10 nueva de `Mesa/Ciclo-1/06-Plan-De-Redaccion.md`. Corrí las verificaciones que se pueden correr hoy sobre la bitácora y las compuertas de REED-16 §9.1 que aplican sin guía. Lo que se verifica en `Examples/`, `Demos/` o la guía queda **diferido**, uno por uno, y no se declara verde. Ninguna verificación falló y no hubo reversiones. Escaladas: ninguna.

Rutas relativas a `OUTPUTs/Bitacoras/` salvo que digan otra cosa (R-PRIV). Estados: **V** verificado hoy; **P** parcial (una parte hoy, el resto diferido); **D** diferido a la redacción.

## Índice

- [1. Cómo se aplicó](#1-cómo-se-aplicó)
- [2. Changelog por parche](#2-changelog-por-parche)
- [3. Changelog por ítem de la boleta](#3-changelog-por-ítem-de-la-boleta)
- [4. Ajustes incorporados que no estaban en el diseño](#4-ajustes-incorporados-que-no-estaban-en-el-diseño)
- [5. Versiones de los archivos](#5-versiones-de-los-archivos)
- [6. Compuertas de REED-16 §9.1](#6-compuertas-de-reed-16-91)
- [7. Deuda declarada](#7-deuda-declarada)
- [8. Escaladas, revertidos y regresiones](#8-escaladas-revertidos-y-regresiones)
- [9. Estadísticas](#9-estadísticas)

## 1. Cómo se aplicó

1. **Orden** de `03-Parches.md` §4: P2-01 primero (compuerta v2 y redacción in situ, con salida antes y después); el bloque del perímetro P2-02 → P2-03 → P2-04 en la misma pasada; P2-05, P2-06, P2-08, P2-09, P2-12, P2-14 (P2-08 antes que P2-09, P2-05 antes que P2-07); P2-07, P2-10, P2-11, P2-13; P2-15 al final, con el conteo de cinco pruebas de P2-06 vuelta 2.
2. **Sólo agregado.** 102 notas fechadas con el encabezado `> **2026-10-28 — Parche P2-NN (ciclo 1, ronda 2).**` (una con «Ronda 2 del ciclo 1: deudas cerradas»), en 17 archivos, al final de la sección que indica cada parche. Texto exacto de los bloques citados de `03-Parches.md`, con los ajustes vinculantes escritos y marcados dentro de la nota. Cuando un parche nombra varios ítems del mismo archivo, la nota completa va en la sección principal y las demás llevan una remisión de una línea (como en el ciclo 1). Script: `aplicar-r2.py`, intermedio fuera del repositorio, con un ensayo previo sobre una copia de `OUTPUTs/` que dio el mismo resultado byte a byte. Comparación contra la copia previa: **0 líneas quitadas** en los 17 archivos (salvo una línea en blanco final de `Mesa/Ciclo-1/05-Aplicacion.md`, que el script normaliza; D-R2-9).
3. **Excepción del dictamen §1** (borrar un dato que R-PRIV prohíbe): sólo P2-01 (b), 1 ruta del home en `Ronda-2/evidencia-AH-01-seguridad/README.md` l. 16, reemplazada por `$WORKSPACE`. Copia previa fuera de `OUTPUTs/` (condición transversal del juez de riesgo), diff palabra por palabra con 1 cambio, el esperado, y la copia se borró al terminar.
4. **Capas guía, laboratorio y demo:** `Mesa/Ciclo-1/06-Plan-De-Redaccion.md` §10 (agregada al final; §0–§9 sin tocar, comprobado con `diff` de las 323 líneas previas). BIT-16-04 §8 remite a ella para no tener dos versiones de las RV.
5. **Archivos nuevos:** la compuerta `aplicacion/rpriv.sh` v2 y su lista de sintéticos, los casos rojos y verdes, las verificaciones, `Escaladas.md` y siete copias de evidencia de P2-06 en `Integracion-Evidencia/C-operacion-demo/` (copias, no movidas; `cmp` = 0).
6. **Turnos:** ninguno. No hizo falta ni `<recurso-compartido>` ni `build`: las cifras salen de corridas ya pagadas (`03-Parches.md` §4.7) y las dos sondas nuevas de P2-06 las compilaron los jueces. No se usó el segundo servidor. Intermedios en el área de trabajo de la corrida, sin `bin/` ni `obj/`; las copias de respaldo se borraron.
7. **Nada se commiteó.**

## 2. Changelog por parche

| Parche | Ítems (opción, conteo) | Aprobación | Ajustes incorporados | Estado | Verificación (2026-10-28) |
|---|---|---|---|---|---|
| P2-01 | C1-01 (A, 5-0); PC-03 | 3 APLICAR (evidencia con ajuste) + 2 MEJORAR_PLAN (impacto, riesgo) | patrón `CH` del juez de evidencia (escapado, con espacios, indentado); sus cuatro casos; `RPRIV_LISTA` fuera de la raíz; `grep -i` para camelCase (impacto); Markdown cubierto por el barrido de RV-01 (riesgo) | **V** en `OUTPUTs/`; guía **D** | compuerta v2 sobre `OUTPUTs/`: `patrones` 1 → 0, `cabeceras` 0 (3 objetos sintéticos excluidos por valor, más los 4 de las dos listas de sintéticos), `identificadores` 446 → 452; casos 8/8 como se esperaba (`aplicacion/rpriv-casos-2026-10-28.txt`); redacción in situ con diff de 1 cambio |
| P2-02 | C1-48 (A, 3-1-1), C1-55 (B, 3-2), C1-56 (B, 3-2) | 4 APLICAR + 1 MEJORAR_PLAN (coherencia) | lectura del streaming ratificada por las cinco aprobaciones; notas en R-C13, R-C16 y nota consolidada de §6.2 (coherencia, con el `PIPE` que pide P2-06 vuelta 2) | **P** | nota de la fila N6 en `03-Marco` §4.1 presente; notas en §6.1, §6.2, §3.1, §5 y N6 Anexo A. Diferidos: `grep` de `AyudaRag\|IAlmacenDeRequisitos\|MapMcp\|McpServerTool` en `Demos/`; frase comparativa CAG/RAG en la guía |
| P2-03 | C1-40 (B, 4-1), C1-62 (B, 3-2), C1-14 (B, 3-2); PC-12, PC-13 | 4 APLICAR + 1 MEJORAR_PLAN (costo-beneficio) | verificación de B1 por lista cerrada y repositorios espía, no por reflexión (costo-beneficio); el caso «id de otra sesión» rotulado prueba nueva (evidencia) | **D** | notas en R-C02, MI-14, M3, N0b D-11, N6 §1.3, §4.4, P6 y Anexo A. Diferidos: `grep` de `ApprovalRequiredAIFunction\|AprobacionPendiente\|aprobaciones/` en `Demos/`, B1 (i)–(ii), D3, B4 y `Examples/07` |
| P2-04 | C1-38 (A, 5-0), C1-53 (A, 5-0) | 5 APLICAR | evidencia retira su condición «mismo error por los dos caminos»; la guía muestra lo que dé (impacto) | **D** | notas en MI-05, R-C03, M2, tensión 7, N6 Anexo A, §4.2, §2. Diferidos: `diff -r`, build de la copia, «piedra», enum 5 y nombre de 61, P-30 |
| P2-05 | C1-12 (A), C1-46 (A), C1-71 (A), todos 5-0; PC-11, PC-09 | 5 APLICAR (evidencia con ajuste) | frase 2 acotada a «sin `ValidateOnBuild`… no al construir el contenedor» (riesgo (a)); cita de .NET DI overview §«Scope validation», ms.date 2026-01-26 (evidencia); notas en N6 T1 y antipatrón (riesgo (b)); remisión en los snippets de N2 §4.5, N5 §4.1 y §4.7 (riesgo (c)) | **P** | `pierde la sesión\|falla al arrancar\|mezcla sesiones` en BIT-16-04 fuera de notas = 0. Diferidos: prueba (a)–(c) en `Cableado/`; cita en la guía |
| P2-06 (vuelta 2) | C1-37 (B, 4-1), C1-37-clave (A, 5-0); PC-02, PC-12 | 4 APLICAR (vuelta 2: evidencia, impacto y riesgo con ajuste; coherencia con precisión) | M8: streaming según `CoalesceStreamingUpdates` (evidencia 1, impacto C-1); «menos fragmentos» en nivel C; (2b) en los dos modos con el caso rojo sólo en `false` (evidencia 3, impacto C-2); reversión (evidencia 4, impacto C-3); «Estado» y rótulo del snippet con las sondas (evidencia 5–6, impacto C-4); versión de los datos leída en cada pedido y prueba (4) con la misma instancia (riesgo 1–3); frase del limitador (coherencia §3); la rama opcional del limitador no se toma y `VersionDeDatos` en el almacén de D-11 (costo-beneficio §3.1–3.2); copias de las salidas (evidencia 8, impacto C-5) | **P** | nombre `movilidadurbana.ai.cache.aciertos` presente en `PC02-salida.txt` (l. 14, 23); siete copias con `cmp` = 0. Diferidos: las cinco pruebas en `Cableado/` de `Examples/09` y los barridos sobre la guía |
| P2-07 | C1-59 (A), C1-28 (A), 5-0; PC-01, PC-09, PC-11, PC-12, PC-15 | 5 APLICAR (evidencia con ajuste) | cita del MUST de `Origin` en la revisión vigente 2026-07-28 (evidencia (1)); la guía no afirma qué revisión habla el SDK (evidencia (2)); `EsDeLectura` por reflexión y por nombre, ningún `ApprovalRequiredAIFunction` publicado (riesgo); builder no *slim* (impacto) | **D** | notas en §6.3, tensión 6, N4 §6.2 y §4.6, N6 §4.5, §1.3, Anexo A. Diferidos: tabla 400/401/403/200, `tools/list`, reflexión |
| P2-08 | C1-61 (A), C1-45 (A), 5-0; PC-03, PC-05 | 4 APLICAR + 1 MEJORAR_PLAN (coherencia) | nota en R-C14 y cierre de la **D** de P-39 en `Mesa/Ciclo-1/05-Aplicacion.md` (coherencia) | **D** | notas en MI-13, M10, R-C14, N2 §2.9, N1 §2.6, N6 Anexo B. Diferidos: captura de cuerpo en `Examples/01`, `grep` de `<clave-de-cabeceras>` y `Proveedor` |
| P2-09 | — (PC-04, PC-06) | 5 APLICAR (evidencia con ajuste) | el truncamiento a 2050 es 5 de 5 con el 0.5b, no 10 de 10, y lleva su condición (evidencia) | **P** | `verificar-pc06-2026-10-28.txt` reproduce la recarga a 4096 en las 10 series y los 2050 tokens sólo con el 0.5b; «estado del servidor» y «si el cliente la expone» con la nota a la vista en BIT-16-04, N3b y N5. Diferido: prueba del handler en `Examples/09` |
| P2-10 | C1-41 (A, 4-1), C1-50 (A), C1-42 (A), C1-51 (A), 5-0 | 4 APLICAR + 1 MEJORAR_PLAN (costo-beneficio) | fila (4) de §R.6 cita `eval-*.jsonl` y `costo-salida.txt` sólo como estimación superada; carga en frío 22,8–24,0 s (N = 2) (evidencia); fila (2) separada en recarga y carga (costo-beneficio); estado del segundo servidor, plazo del apagado y sin nombres (riesgo (a)–(c)); **decisión de la aplicación: entran las cinco filas** | **P** | `verificar-p2-10-2026-10-28.txt`: D1 9 y D3 10 discordantes en un sentido, D3-T 8, D6 0, con los Wilson del rótulo; sha256 del criterio previo a la nota = el de F09 del ciclo 1; «se apaga al terminar» y «no se comparó punta a punta» con la nota a la vista. Diferidos: `grep` de `qwen3.5:2b` y del segundo servidor en la guía |
| P2-11 | C1-64 (A), C1-44 (A), 5-0; PC-08 | 5 APLICAR (evidencia con ajuste) | 1285 s con «N = 1 caso, anfitrión sin reservar» y 154 s con «N = 3» (evidencia) | **D** | notas en N5 §2.6, §4.6, §8, MI-16, R-C09, pendiente P-03 e Informe-AH-02. Diferidos: `Evaluation` en `Demos/` y la sección de evaluación de la guía |
| P2-12 | C1-67 (A, 5-0); PC-14 | 5 APLICAR (evidencia con ajuste) | «3 de 10» con «lectura manual del texto» (evidencia) | **D** | notas en N5 P7, MI-19, M14. Diferidos: `Comentario` en la guía y `Examples/`, M14 en `Cableado/` |
| P2-13 | C1-72 (A), C1-43 (A), C1-49 (A), 5-0; PC-10 | 4 APLICAR + 1 MEJORAR_PLAN (impacto) | la frase de la tensión 1 se reescribe sin Wilson agrupado y sin tasa de tarea con K = 6 (impacto) | **P** | «N ≥ 96» con la nota de reemplazo a la vista en N0b y BIT-16-04; notas en EA-6, tensión 1, MI-01, MI-24, R-C20, M11 y en la consulta AH-02. Diferidos: `grep -L "estimando:"` y fracciones de la guía |
| P2-14 | — (consulta de definiciones; C1-49) | 5 APLICAR | — | **P** | notas en N1 §2.13, N4 §2.1, §2.2, §2.9, N6 §2, N0b D-07 y BIT-16-04 §8. Diferidos: C5 y la marca de C1-32 sobre la guía |
| P2-15 | C1-36 (A, 5-0) | 5 APLICAR | «las cinco de P2-06», con (2b) en los dos modos y (4) con la misma instancia (sigue a P2-06 vuelta 2) | **P** | `## Validación del núcleo (ciclo 1)` = 1 en los nueve registros; nota en REED-16 §6.2. Diferido: fecha de la sección de N5 §4.2 frente a las pruebas |

## 3. Changelog por ítem de la boleta

| Ítem | Opción ganadora (conteo) | Parche | Estado del parche |
|---|---|---|---|
| C1-01 | A (5-0) | P2-01 | V |
| C1-12 | A (5-0) | P2-05 | P |
| C1-14 | B (3-2) | P2-03 | D |
| C1-28 | A (5-0) | P2-07 | D |
| C1-36 | A (5-0) | P2-15 | P |
| C1-37 | B (4-1) | P2-06 | P |
| C1-37-clave | A (5-0) | P2-06 | P |
| C1-38 | A (5-0) | P2-04 | D |
| C1-40 | B (4-1) | P2-03 | D |
| C1-41 | A (4-1) | P2-10 | P |
| C1-42 | A (5-0) | P2-10 | P |
| C1-43 | A (5-0) | P2-13 | P |
| C1-44 | A (5-0) | P2-11 | D |
| C1-45 | A (5-0) | P2-08 | D |
| C1-46 | A (5-0) | P2-05 | P |
| C1-48 | A (3-1-1) | P2-02 | P |
| C1-49 | A (5-0) | P2-13 | P |
| C1-50 | A (5-0) | P2-10 | P |
| C1-51 | A (5-0) | P2-10 | P |
| C1-53 | A (5-0) | P2-04 | D |
| C1-55 | B (3-2) | P2-02 | P |
| C1-56 | B (3-2) | P2-02 | P |
| C1-59 | A (5-0) | P2-07 | D |
| C1-61 | A (5-0) | P2-08 | D |
| C1-62 | B (3-2) | P2-03 | D |
| C1-64 | A (5-0) | P2-11 | D |
| C1-67 | A (5-0) | P2-12 | D |
| C1-71 | A (5-0) | P2-05 | P |
| C1-72 | A (5-0) | P2-13 | P |

Re-registros del dictamen §3.2: C1-67, C1-72, C1-61 y C1-64 como NO_PROCEDE de la propuesta con la alternativa adoptada (P2-12, P2-13, P2-08, P2-11); C1-42, C1-43, C1-44, C1-45, C1-46, C1-50, C1-51, C1-59 y C1-71 con la opción que ganó. Todos quedaron escritos en la nota del parche que los toma.

Consultas que entran sin ítem: PC-04 y PC-06 (P2-09), las definiciones P-31.1–.5 (P2-14). Fuera de la boleta: C1-32 (elevado a la presidencia; `Escaladas.md`, ELV-01).

## 4. Ajustes incorporados que no estaban en el diseño

Para que la relectura sepa qué texto de las notas no es el de `03-Parches.md`:

| Parche | Origen | Tipo | Dónde quedó |
|---|---|---|---|
| P2-01 | evidencia §2 (1)–(3) | ajuste vinculante | `aplicacion/rpriv.sh` (patrón `CH`), nota de REED-16 §9.1, `rpriv-casos.sh` |
| P2-01 | impacto (camelCase), riesgo (Markdown) | `MEJORAR_PLAN` en minoría, mecánico | `grep -i` en `rpriv.sh`; barrido `<clave-de-cabeceras>` de RV-01 en 06-Plan §10.3 |
| P2-02 | las cinco aprobaciones | ratificación de la lectura del streaming | nota de BIT-16-04 §6.1 y N6 Anexo A |
| P2-02 | coherencia (mejora 1–4) | `MEJORAR_PLAN` en minoría, mecánico | notas de R-C13, R-C16 (§3.1) y nota consolidada de §6.2 |
| P2-03 | costo-beneficio (verificación de B1) | `MEJORAR_PLAN` en minoría, mecánico | nota de R-C02 y N6 §4.4; 06-Plan §10.7 |
| P2-05 | evidencia (cita), riesgo (a)–(c) | ajuste y condición vinculantes | nota de N0b D-06 y R-C04; notas en N6 §1.4, antipatrones, N2 §4.5, N5 §4.1 y §4.7 |
| P2-06 | vuelta 2: evidencia 1–8, impacto C-1 a C-5, riesgo 1–3, coherencia §3, costo-beneficio §3 | ajustes y condiciones vinculantes | nota de R-C07 y N5 §4.1; 06-Plan §10.3 (RV-03) y §10.7 |
| P2-07 | evidencia (1)–(2), riesgo, impacto | ajustes y condiciones vinculantes | nota de §6.3 y N4 §6.2 |
| P2-08 | coherencia (R-C14, P-39) | `MEJORAR_PLAN` en minoría, mecánico | nota de R-C14; nota en `Mesa/Ciclo-1/05-Aplicacion.md` §2 |
| P2-09 | evidencia (5/5, condición del 2050) | ajuste vinculante | nota de R-C08 y N3b X4 |
| P2-10 | evidencia (1)–(2), riesgo (a)–(c) | ajustes y condiciones vinculantes | nota de MI-03, §R.5 y §R.6 |
| P2-10 | costo-beneficio (fila (2)) | `MEJORAR_PLAN` en minoría, mecánico | §R.6; nota en `Consulta-operacion-telemetria.md` PC-06 |
| P2-11 | evidencia (N y anfitrión) | ajuste vinculante | nota de N5 §2.6 y MI-16 |
| P2-12 | evidencia (lectura manual) | ajuste vinculante | nota de N5 P7 y MI-19 |
| P2-13 | impacto (tensión 1 según R-LLM-3d) | `MEJORAR_PLAN` en minoría, mecánico | nota de EA-6; 06-Plan §10.2 (§6); nota en `Consulta-AH-02-formal.md` |
| P2-15 | impacto y costo-beneficio (sigue a P2-06) | derivado | nota de REED-16 §6.2 |

## 5. Versiones de los archivos

sha256 y líneas al terminar (2026-10-28), antes de escribir este archivo. «Líneas de las notas» = dónde empieza cada nota de la ronda 2 en la versión final. `Bitacoras/` se omite en las rutas, salvo REED-16 (en `OUTPUTs/`).

| Id | Archivo | sha256 | Líneas | Notas | Parches | Líneas de las notas |
|---|---|---|---|---|---|---|
| G01 | `../Crear-IA-Layer-Guide-Reedicion.md` | `efe9ea86805fac7e74d189a3a0a2f19593df4662893f0a4b9650b11cc2be455e` | 577 | 2 | P2-15, P2-01 | 243, 399 |
| G02 | `03-Marco-De-Referencia.md` | `695feb53fdeb040a90722b6045c1cd23820f5a73e431c395b2784c98be7beb71` | 153 | 1 | P2-02 | 105 |
| G03 | `04-Integracion.md` | `f037f7d27a8e08a504bebba7b769a1f064a7b78ad505d7903eafa3651cbda875` | 1061 | 45 | P2-02…P2-14, §3 | 72, 74, 118, 120, 122, 124, 149, 153, 207, 216, 218, 227, 262, 264, 269, 271, 475, 477, 479, 486, 488, 490, 493, 495, 499, 502, 507, 511, 513, 628, 726, 856, 858, 860, 862, 864, 874, 876, 878, 957, 959, 961, 963, 1059, 1061 |
| G04 | `Escaladas.md` (nuevo) | `63c6d796ea9ef8b5701ddcbb14f989be7a747f9c5d9ce14a80f3fb4feb89d8eb` | 36 | — | — | — |
| G05 | `README.md` | `654ed35d07bdf991c01a15ff8d9a728c96f36a98b75cc55bfdad92d06fa23060` | 160 | 1 | nota «Mesa ciclo 1, ronda 2» | 136 |
| G06 | `Sondeo-Entorno.md` | `e438f8a07f2df4144e260e2dd44e3c99d8531ae51b666b65590ab91547da44b7` | 344 | 2 | P2-10 | 315, 328 |
| G07 | `Integracion-Evidencia/C-operacion-demo/criterio-D1-D6-qwen3.5-2b-vs-4b.md` | `e1b9da1b2c74b6fec3248fc2945eaa8a6d0249d56b5bfe36075fe550bbeaf7d4` | 13 | 1 | P2-10 | 12 |
| G08 | `Integracion-Evidencia/C-operacion-demo/PC02-salida.txt` (copia) | `3e54eda234532bf5a15236e2bc3567bcb1d4cb549645e8252a24d1f6aaa6e0fa` | 62 | — | P2-06 | — |
| G09 | `Integracion-Evidencia/C-operacion-demo/P2-06v2-salida.txt` (copia) | `eeea8806cb806321512b0e2b8d1e63547306997f3bf23b805c6c196feb217a5f` | 15 | — | P2-06 | — |
| G10 | `Integracion-Evidencia/C-operacion-demo/P2-06v2-Program.cs` (copia) | `10290f1b2378d7a91bcfe2d6d78ed6d0a1b9ea3f4f02c29663cef27c75bdd49c` | 98 | — | P2-06 | — |
| G11 | `Integracion-Evidencia/C-operacion-demo/P2-06v2.csproj` (copia) | `62ea01563a90d5a3dcf0d45d80daf0ad338d3c9eaaa48979490fdfaec57cf761` | 7 | — | P2-06 | — |
| G12 | `Integracion-Evidencia/C-operacion-demo/P206v2-salida.txt` (copia) | `98bc90ef7a262ca30cd006da41aab922b5d720ceabd8659a1ec1c509c5a62e78` | 14 | — | P2-06 | — |
| G13 | `Integracion-Evidencia/C-operacion-demo/P206v2-Program.cs` (copia) | `2cdd92c20924930fa1a4b2320ca50348fa7443110c8e140ea120b82f9bb91a9a` | 73 | — | P2-06 | — |
| G14 | `Integracion-Evidencia/C-operacion-demo/P206v2-Sonda.csproj` (copia) | `391a72390cf7a8d4754410900646407ab2871da0aee20a524ec1665f3f1c30ee` | 8 | — | P2-06 | — |
| G15 | `Mesa/Ciclo-1/05-Aplicacion.md` | `ef667852d808a1b83547948dc7002eb7bec02faa7ecb6a481785af752f32c182` | 296 | 2 | P2-08; deudas D-1, D-2, D-5, D-6, D-7, D-9 | 90, 265 |
| G16 | `Mesa/Ciclo-1/06-Plan-De-Redaccion.md` | `858bbc6d3a6ff4e088e44f0722a1a77c0cdb8e59e709b04448f95c8a9d16cd64` | 502 | §10 | todos | §10 desde l. 327 (§10.1 a §10.8) |
| G17 | `Mesa/Ciclo-1/Informe-AH-02-evaluacion-llm-rag.md` | `d38961149e0cffe0e0d08af3ecf58c7a8361691ec5fd2c961de17df6898a899a` | 150 | 1 | P2-11 | 68 |
| G18 | `Mesa/Ciclo-1/Ronda-2/Consulta-AH-02-formal.md` | `f34b694adaf083265adbc178ed9e4483abe42b5c6e35ccc3db1523262bbbe112` | 103 | 1 | P2-13 | 67 |
| G19 | `Mesa/Ciclo-1/Ronda-2/Consulta-operacion-telemetria.md` | `bea1a2164900a2cfd9535a6e1652f4df7b30aaf54e065bb9238237f036bc2c11` | 118 | 1 | P2-10 | 99 |
| G20 | `Mesa/Ciclo-1/Ronda-2/evidencia-AH-01-seguridad/README.md` | `8db5016399b19ed267706ff0a33c038f2e82563eb56e2f12bb5964f6fcc5ba53` | 31 | 1 (+1 línea R-PRIV, l. 16) | P2-01 | 30 |
| G21 | `Mesa/Ciclo-1/Ronda-2/aplicacion/rpriv.sh` (nuevo) | `8632f1a8638f26a0a1326e93b651085b13669b921a5ed74e09ab832d7d74738a` | 23 | — | P2-01 | — |
| G22 | `Mesa/Ciclo-1/Ronda-2/aplicacion/rpriv-sinteticos.txt` (nuevo) | `645b7c29e473784cda2d4a29342067397283b83b265a0a543440d9b3e8ea1b3c` | 2 | — | P2-01 | — |
| G23 | `Mesa/Ciclo-1/Ronda-2/aplicacion/rpriv-casos.sh` (nuevo) | `f92fd428dd712d103412986aa4c3779092bb16e6ce015264b787fccc8f8bef2e` | 14 | — | P2-01 | — |
| G24 | `Mesa/Ciclo-1/Ronda-2/aplicacion/rpriv-casos-2026-10-28.txt` (nuevo) | `2d6ed85cbe012669599e6006df721f43cbab58b288089b6b1e5b3d9502ab7acf` | 8 | — | P2-01 | — |
| G25 | `Mesa/Ciclo-1/Ronda-2/aplicacion/rpriv-2026-10-28-antes.txt` (nuevo) | `2af0cb49411a07f8e110128d7f96f33c1c2c730efce613fbd224101e2fa703d2` | 8 | — | P2-01 | — |
| G26 | `Mesa/Ciclo-1/Ronda-2/aplicacion/rpriv-2026-10-28-despues.txt` (nuevo) | se escribe después de este archivo (§6) | — | — | P2-01 | — |
| G27 | `Mesa/Ciclo-1/Ronda-2/aplicacion/verificar-ronda-2.sh` (nuevo) | `08d2bc95b9644469958d8d5a6ccf03002e24a1ecd6f2f61b703ff2d2b9730a4d` | 29 | — | todos | — |
| G28 | `Mesa/Ciclo-1/Ronda-2/aplicacion/verificaciones-2026-10-28.txt` (nuevo) | `09187cc190994baba3619a93a18a572fc4c2ed4deba35064b53a493c2e6850e7` | 86 | — | todos | — |
| G29 | `Mesa/Ciclo-1/Ronda-2/aplicacion/verificar-p2-10.py` (nuevo) | `f75d17749e3d732df1da69508c48ba47ea733609e0d3a0258c48aa3b160a337f` | 18 | — | P2-10 | — |
| G30 | `Mesa/Ciclo-1/Ronda-2/aplicacion/verificar-p2-10-2026-10-28.txt` (nuevo) | `1085dae8163db7daff2435c9fcbce0bd420d4f8d395bfd5c821299eb11c26164` | 4 | — | P2-10 | — |
| G31 | `Mesa/Ciclo-1/Ronda-2/aplicacion/verificar-pc06.py` (nuevo) | `ac63fd644eb98cb6f2850a91332173d839e44989bb5e616e212ed179dbc65a36` | 12 | — | P2-09, P2-10 | — |
| G32 | `Mesa/Ciclo-1/Ronda-2/aplicacion/verificar-pc06-2026-10-28.txt` (nuevo) | `c3f4862d9b2372b43e5ca726bbe1419a654d35e691390404c97ca18e40503c0e` | 8 | — | P2-09, P2-10 | — |
| G33 | `Nucleos/N0b-Producto-Datos-Y-Perfil.md` | `1f0b236fff2adc81c0d09e4e7aede42e915ce26fcb5f6ba9079c1306ce42150c` | 638 | 5 | P2-03, P2-05, P2-13, P2-14 | 114, 294, 314, 357, 623 |
| G34 | `Nucleos/N1-Capa-IA-En-El-Stack.md` | `70a5dc67eea2d21a2929ecb382871c253e63e026329a937b0b187fd2fb07a42a` | 609 | 2 | P2-08, P2-14 | 122, 164 |
| G35 | `Nucleos/N2-Abstracciones-Y-Proveedores-NET.md` | `d7f00ac3a5b1e8d232e87b05e06e7ce7546fc4f7c338bad56417e104bd696d76` | 606 | 2 | P2-08, P2-05 | 108, 299 |
| G36 | `Nucleos/N3b-CAG-Y-Estrategias-De-Conocimiento.md` | `7119df3bf95c3a9714e8ead9e0827c4be7192163e7a7f604a3418fc536a1871e` | 668 | 6 | P2-09, P2-10 | 112, 204, 281, 339, 510, 629 |
| G37 | `Nucleos/N4-Agentes-Y-Orquestacion.md` | `46032af443ce340fc74250fe8184cd40351b6d37cca10309c07a2d6d8e94c0df` | 780 | 6 | P2-07, P2-14 | 70, 78, 80, 121, 430, 560 |
| G38 | `Nucleos/N5-Operacion-Calidad-Seguridad.md` | `d262a796200ab8af6aaaf714b725c4611838956b2d3f20fd156ebf8a4d655849` | 901 | 9 | P2-05, P2-06, P2-09, P2-11, P2-12 | 35, 104, 263, 265, 358, 495, 511, 578, 678 |
| G39 | `Nucleos/N6-Caso-Movilidad-Urbana.md` | `4b2a1178f8df07c9704d47c7f2411570143ff8c8ae72d63130a98ebd25e91312` | 769 | 15 | P2-02, P2-03, P2-04, P2-05, P2-07, P2-08, P2-14 | 106, 108, 125, 163, 165, 275, 329, 365, 415, 453, 588, 594, 596, 603, 636 |

Para ubicar una nota, buscar su encabezado `Parche P2-NN (ciclo 1, ronda 2)`.

## 6. Compuertas de REED-16 §9.1

| Compuerta | Hoy | Resultado | Salida |
|---|---|---|---|
| C1 sin contradicciones | sobre la bitácora, guiada por las notas | las ramas provisionales de 06-Plan §8 quedaron resueltas (§10.1); la contradicción de N4 §2.2/§2.9 resuelta (P2-14); la de M8/M9 sobre el limitador resuelta (P2-06); la tensión 1 conforme a R-LLM-3d (P2-13); `pierde la sesión\|falla al arrancar\|mezcla sesiones` en BIT-16-04 fuera de notas = 0; las frases viejas («estado del servidor», «si el cliente la expone», «N ≥ 96», «se apaga al terminar», «no se comparó punta a punta») tienen la nota de la ronda 2 a la vista en su archivo | `aplicacion/verificaciones-2026-10-28.txt` |
| C2 marcas `[C:` | conteo | **0 marcas nuevas** en las notas de la ronda 2; 00, 01 y 03 siguen con 13 apariciones fuera de notas (11 marcas resueltas por P-28 + 2 explicaciones). Las menciones de `[C: término de C1-32]` en 06-Plan §10 y `Escaladas.md` describen la marca que usará la guía, no son marcas sin resolver. Nivel C declarado con palabras («nivel C», «no medido») en seis afirmaciones (06-Plan §10.1) | ídem |
| C3 trazabilidad inversa | plan | cada regla de §10 nombra su parche; cada parche, sus ítems; cada ítem, su opción (§3) | 06-Plan §10 |
| C4 sin huérfanos | enlaces | **0 enlaces rotos** sobre todos los `.md` de `OUTPUTs/` (G2-enlaces.py; 375 enlaces en la corrida final, `aplicacion/rpriv-2026-10-28-despues.txt`; en la primera corrida faltaba sólo el del README a este archivo) | ídem |
| C5 glosario | — | no aplica sin guía; P2-14 fija las entradas y la C5 ampliada (06-Plan §10.5) | — |
| R-PRIV | `Ronda-2/aplicacion/rpriv.sh` v2 | **`patrones=0`** (antes 1) y **`cabeceras=0`** sobre `OUTPUTs/`; `identificadores` 446 → 452 (+6, todos nombres de carpetas o archivos de evidencia citados por el texto aprobado de P2-10 y P2-11; permitidos en la bitácora mientras no se commitee, dictamen §2) | `aplicacion/rpriv-2026-10-28-antes.txt`, `rpriv-2026-10-28-despues.txt` |
| Build y test en `sdk:10.0` | — | no hizo falta: ninguna sonda nueva; las de P2-06 vuelta 2 las compilaron los jueces (`P2-06v2-salida.txt`, `P206v2-salida.txt`, SDK 10.0.403) | — |
| Pruebas contra el modelo con R-LLM | — | ninguna corrida nueva | — |
| Mermaid | — | sigue **no corrida** (deuda D-3 del ciclo 1) | — |

## 7. Deuda declarada

Ningún parche salió `NO_APLICAR`. Lo que sigue es lo que la aplicación no pudo cerrar hoy, con su motivo y su default (REED-16 §12).

| # | Qué | Motivo | Default aplicado | Dónde se cierra |
|---|---|---|---|---|
| D-R2-1 | Verificaciones diferidas de P2-02 a P2-15 (las marcadas **D** o **P** en §2) | dependen de `Examples/`, `Demos/` o la guía | nunca verdes; la lista de pruebas está en 06-Plan §10.7 | redacción y relectura integral |
| D-R2-2 | `identificadores=452` en `OUTPUTs/` (+6 en esta ronda) | dictamen §2: permitidos en la bitácora mientras no haya commit | informan y no bloquean el ciclo; bloquean el primer commit | barrido de redacción previo al primer commit |
| D-R2-3 | La compuerta v2 no cuenta `<clave-de-cabeceras>` en Markdown | sobre `OUTPUTs/` un patrón multilínea arrastra párrafos (juez de riesgo, §0.1); el riesgo pidió que el cuerpo auditor decida si mira `*.md` en `OUTPUTs/` | en la guía, `Examples/` y `Demos/` lo cubre el barrido `<clave-de-cabeceras>` de RV-01 ampliada; en `OUTPUTs/`, no se mira `*.md` | cuerpo auditor, si la relectura lo pide |
| D-R2-4 | Siete posiciones `MEJORAR_PLAN` en minoría, en seis parches, incorporadas como ajuste (§4) | mismo criterio que la aplicación del ciclo 1: mecánicas y sin cambiar ninguna decisión | aplicadas y marcadas «Ajuste de la aplicación» en cada nota | presidencia; se revierten por nota si no las ratifica |
| D-R2-5 | La frase de la tensión 1 difiere del texto de diseño de P2-13 | el texto de diseño violaba R-LLM-3d del mismo parche (juez de impacto) | rige la frase reescrita (06-Plan §10.2); el texto de diseño queda como antecedente | presidencia, si quiere el texto de diseño: entonces la guía no puede usar el Wilson agrupado (RV-17) |
| D-R2-6 | `total_s` de los registros de PC-08 (1285,5 y 950,7 s) frente a 1285,3 y 950,4 de la aprobación de evidencia | suma de paredes por evaluación frente al registro `fin` | la guía y §R.6 dicen «1285 s» y «950 s» | sin efecto en ninguna cifra rotulada |
| D-R2-7 | El índice de 06-Plan no lista la §10 | sólo agregado: §0–§9 no se tocan | la §10 abre con su precedencia sobre §0–§9; el README la nombra | relectura integral |
| D-R2-8 | C1-32 y el apagado del segundo servidor | elevados a la presidencia | `Escaladas.md` ELV-01 y ELV-02 | presidencia, antes del cierre del ciclo 1 |
| D-R2-9 | `Mesa/Ciclo-1/05-Aplicacion.md` perdió la línea en blanco final | el script normaliza el final del archivo | sin cambio de contenido | — |
| D-R2-10 | Entregables previos de 06-Plan §1 que no son de la ronda 2 (`plan-de-preguntas.md`, `trazabilidad.md`, `matriz-snippets.md`, `evidencia-a-guia.md`) | son de la redacción | 06-Plan §10.2 «§1» dice qué suman | redacción, antes de escribir la guía |
| D-R2-11 | Mermaid sin renderizar (D-3 del ciclo 1) | no hay renderizador en la estación | sin cambio | compuerta de la redacción |

## 8. Escaladas, revertidos y regresiones

**Escaladas: ninguna** (registro en `Escaladas.md`). No hubo empate en ningún ítem (los 29 con mayoría de 3 o más, sin vetos) ni parches `ESCALAR`. Revisé los siete disparadores de M§6: la lectura de «streaming de tokens» la desempató la letra de la boleta y la ratificaron las cinco aprobaciones; la divergencia de «piedra» no cambia el alcance; nada toca `Lab-E2E.WebBlazor`, manda datos afuera ni reabre una DC. C1-32 y el apagado del segundo servidor son elevaciones a la presidencia, no escaladas al PO.

**Revertidos y regresiones: ninguno.** Ninguna verificación corrida hoy falló. La primera corrida de `verificar-ronda-2.sh` dio 1 enlace roto, el del README a este archivo, que todavía no existía; con este archivo escrito, el recuento da 0 (`rpriv-2026-10-28-despues.txt`, que guarda la compuerta y el recuento de enlaces de la segunda corrida).

## 9. Estadísticas

| Medida | Valor |
|---|---|
| Ítems de la boleta | 29, todos con mayoría ≥ 3 y sin veto (21 unánimes) |
| Parches | 15 aprobados (P2-06 en dos vueltas), 15 aplicados; 0 `NO_APLICAR`, 0 `ESCALAR`, 0 revertidos |
| Estado de verificación | V 1 · P 8 · D 6 |
| Ajustes incorporados | 8 parches con ajuste o condición vinculante (P2-01, P2-05, P2-06, P2-07, P2-09, P2-10, P2-11, P2-12); 7 posiciones `MEJORAR_PLAN` en minoría, en 6 parches (P2-01 dos, P2-02, P2-03, P2-08, P2-10, P2-13) |
| Notas fechadas | 102 en 17 archivos, más la §10 de 06-Plan y la nota del README |
| Archivos nuevos | 20 (`Escaladas.md`, 12 en `Ronda-2/aplicacion/` contando la salida «después», 7 copias de evidencia) y este |
| Redacción R-PRIV in situ | 1 línea en 1 archivo; `patrones` 1 → 0 |
| Enlaces relativos | 0 rotos |
| Turnos de modelo y de build | 0 |
| Escaladas | 0 |
