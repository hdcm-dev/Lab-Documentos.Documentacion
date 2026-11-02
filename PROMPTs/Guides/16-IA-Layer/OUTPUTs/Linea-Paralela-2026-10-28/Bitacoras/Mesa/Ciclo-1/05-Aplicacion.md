---
doc_id: BIT-16-C1-05
doc_type: aplicacion-y-verificacion
title: Aplicación y verificación del ciclo 1 (REED-16 §9.7, M§5.6)
status: hecho
origin: agent
owner: aplicación del ciclo 1 (aplica y verifica; no vota)
last_review: 2026-10-28
audience: [presidencia, redacción, relectura integral, PO]
traces: [REED-16 §9.1, §9.7, §12, §13; M§5.6, M§6; Mesa/Ciclo-1/01-Consolidado.md; 02-Voto-*.md; 02-Revision-Homogeneidad.md; 03-Parches.md; 04-Aprobacion-*.md; 06-Plan-De-Redaccion.md; BIT-16-00 R-PRIV, R-LLM]
---

# Aplicación y verificación del ciclo 1

Apliqué los 44 parches aprobados (`APLICAR` en los 44; cinco con una posición `MEJORAR_PLAN` en minoría, cuyos pedidos incorporé como ajuste porque eran mecánicos), con los ajustes vinculantes y las condiciones de ejecución de los cinco jueces de aprobación. Corrí los criterios de verificación que se pueden correr hoy y las compuertas de REED-16 §9.1 que aplican sin guía. La mayoría de los criterios se corren sobre `Examples/` y `Demos/`, que todavía no existen: quedan **diferidos**, uno por uno, y no se declaran verdes. Ningún parche falló su verificación, así que no hubo reversiones.

Rutas relativas a `OUTPUTs/` (R-PRIV). Estado: **V** verificado hoy; **P** parcial (una parte verificada hoy, el resto diferido); **D** verificación diferida a la redacción; **C** condicionado a la segunda ronda (parte común aplicada, ramas escritas en 03-Parches).

## Índice

- [1. Cómo se aplicó](#1-cómo-se-aplicó)
- [2. Changelog por parche](#2-changelog-por-parche)
- [3. Changelog por hallazgo](#3-changelog-por-hallazgo)
- [4. Versiones de los archivos](#4-versiones-de-los-archivos)
- [5. Compuertas de REED-16 §9.1](#5-compuertas-de-reed-16-91)
- [6. Deuda declarada](#6-deuda-declarada)
- [7. Escaladas](#7-escaladas)
- [8. Revertidos y regresiones](#8-revertidos-y-regresiones)
- [9. Estadísticas](#9-estadísticas)

## 1. Cómo se aplicó

1. **Orden** de 03-Parches §4: P-01 primero; después los S1 que bloquean secciones (P-02, P-03); después los firmes; los condicionados, sólo en su parte común.
2. **Registros de la bitácora: sólo agregado.** 131 notas fechadas con el encabezado `> **2026-10-28 — Parche P-NN (ciclo 1).**`, insertadas al final de la sección que indica cada parche (o al final del registro). Texto exacto de 03-Parches más los ajustes vinculantes, marcados como tales dentro de la nota. Script: `aplicar.py` (intermedio, fuera del repo); registro de cada inserción (archivo, línea, ancla) en el intermedio; resumen en §4.
3. **Excepción de P-01 (redacción R-PRIV in situ).** 40 líneas en 13 archivos: rutas del home → `$WORKSPACE`, `$FC_WORK`, `$HOME` o rutas desde la raíz del workspace; la viñeta de respaldo de `Reanudar.md` §5 con el texto exacto de P-01 (a); `verificar-capas.sh` l. 9 → `"${1:?ruta de la copia}"`. Antes de redactar hice una copia de `OUTPUTs/` fuera del repo (condición del juez de riesgo), verifiqué que sólo cambiaron rutas y la dirección (diff palabra por palabra: 0 cambios no esperados) y la borré, como pide la condición. **El dictamen de la presidencia sobre la excepción no está registrado**: la apliqué con el respaldo unánime del jurado (C1-01, 5/5) y de la aprobación (5/5). Si la presidencia la rechaza, rige la rama alternativa de P-01 (archivos fuera de commit); lo redactado no se restaura (reversión de P-01).
4. **Capas guía, laboratorio y demo:** consolidadas en `Mesa/Ciclo-1/06-Plan-De-Redaccion.md` (BIT-16-C1-06), vinculante. BIT-16-04 §8 remite a él para no tener dos copias de las RV.
5. **Ids:** en las notas, «pendiente P-nn de BIT-16-04» frente a «Parche P-nn (ciclo 1)» (condición transversal 1 del juez de impacto); cada registro tocado lleva una nota de convención.
6. **Turnos:** recurso `build` tres veces (sondas de P-11 y P-03; una compilación falló por el paquete faltante y se repitió). **Ningún turno de modelo** (`<recurso-compartido>`): nada de este ciclo lo necesitaba hoy. No se levantó nada en el equipo de respaldo. Intermedios en el área de trabajo de la corrida, sin `bin/` ni `obj/`.
7. **Nada se commiteó.**

## 2. Changelog por parche

| Parche | Ítems | Aprobación | Ajustes incorporados | Estado | Verificación (2026-10-28) | Archivos (§4) |
|---|---|---|---|---|---|---|
| P-01 | C1-01, C1-39 | 5/5 | cierre de patrones con punto final; `patrones=` e `identificadores=` por separado (evidencia); copia previa fuera del repo, borrada tras verificar (riesgo) | **V** | compuerta `rpriv.sh` sobre `OUTPUTs/` (incluida `Mesa/`): `patrones` 40 → 0; `identificadores` 370 → 360 (informan); caso rojo fuera del repo → rc = 1; diff palabra por palabra de los 13 archivos redactados: 0 cambios no esperados. Falta el dictamen de la presidencia sobre la excepción | F01, F05, F06, F12, F13, F20, F29, F30, F31, F33, F34, F35, F39, F44, F47, F48 |
| P-02 | C1-02, C1-72 (b) | 5/5 | — | **V** | `grep` de «falso aceptado» en N0b y BIT-16-04: toda aparición posterior a la primera nota está en notas de Parche P-02 o es texto previo (N0b l. 586, BIT-16-04 tabla MI-24). En la guía: RV-02, diferida | F04, F13, F33 |
| P-03 | C1-03, C1-37, C1-S4 (3) | 5/5 | — | **P** | sonda E1 con el recurso `build` en `sdk:10.0`: pedidos 1–3 → 200, 4.º → 503 con `Retry-After: 30`. Diferidos: compilar en `Examples/09`, clave de caché con `SessionId`, PC-02, `grep` en la guía | F04, F13, F23, F36, F41 |
| P-04 | C1-04 | 5/5 | celdas con respaldo citado o «pendiente» (evidencia) | **V** | N1–N5: `ESC-0` = 5, 5, 7, 5, 5 y «Aplicación por escenario» = 1 por registro; celdas sin respaldo rotuladas «sin respaldo en el registro: pendiente». Compuerta de encabezados en la guía: diferida | F13 |
| P-05 | C1-05, C1-48 | 5/5 | — | **C** | `ESC-0` en N6 Anexo A = 8; la fila N6 original de 03 §4.1 queda (sólo agregado) y la reemplaza la nota. Falta la segunda ronda de C1-48 (mayoría ≥ 3) | F03, F04, F13, F42 |
| P-06 | C1-06 | 4 APLICAR + 1 MEJORAR_PLAN | destinos por número y título (impacto, MEJORAR_PLAN incorporado) | **V** | 22 PR sin huecos; 0 filas con número de sección sin título; cada «aplicar» con destino en P-07 o P-29 | F04, F13 |
| P-07 | C1-07 | 4 APLICAR + 1 MEJORAR_PLAN | RV por título, tabla de correspondencia, frase de reversión corregida (impacto y evidencia) | **P** | estructura, correspondencia de numeración y RV por título aplicadas. Diferidos: `wc -w` por sección, C5 y trazabilidad sobre la guía | F04, F13 |
| P-08 | C1-08 | 5/5 | — | **D** | `grep` de ids de bitácora sobre la guía y `evidencia-a-guia.md`: la guía no existe | F04, F13 |
| P-09 | C1-09 | 5/5 | «filas = conteo» con comando guardado (evidencia) | **P** | conteo con comando guardado = 80. Falta `Mesa/Ciclo-2/plan-de-preguntas.md` (entregable previo) | F04, F13, F16 |
| P-10 | C1-10 | 5/5 | — | **P** | digest de `ollama/ollama:0.40.11` verificado hoy por los jueces de costo-beneficio y de riesgo (API de Docker Hub, 2026-10-28T11:27). Diferidos: receta de punta a punta y clon limpio de `Examples/01` | F04, F13, F47 |
| P-11 | C1-11, C1-13, C1-28 (largo de entrada) | 5/5 | `[ValidateObjectMembers]`, prueba de `Permisos = 0`, sangría (evidencia) | **P** | sonda E1 (`sdk:10.0`): `Permisos = 0` → `OptionsValidationException` con `[ValidateObjectMembers]` y arranca sin él; sin `TimeoutSegundos` → `OptionsValidationException`. Hallazgo: en consolas hace falta `Microsoft.Extensions.Options.DataAnnotations`. Diferidos: `Examples/01`, 2001 caracteres → 400, `num_ctx` con turno, `grep` de literales | F04, F13, F26 |
| P-12 | C1-12, C1-46, C1-71 | 5/5 | pendientes citados como «pendiente P-nn de BIT-16-04» (impacto) | **P** | «mezcla sesiones» fuera de notas en BIT-16-04 = 0. Diferidos: prueba del pendiente P-10 con `ValidateScopes` `true` y `false`; PC-11 | F04, F13, F33 |
| P-13 | C1-14 | 5/5 | D-11 en lugar de «D-07 bis» (coherencia); 404 no es control de acceso (riesgo) | **C** | D-11 firme. Diferidos: el puerto compila sin MEAI (Parche P-30); rama A (404 por sesión) tras la segunda ronda y PC-12 | F13, F33, F42 |
| P-14 | C1-15, C1-68 | 5/5 | — | **D** | `MarkupString` en `Demos/`, dos pestañas, cancelación < 1 s: la demo no existe | F04, F13, F42 |
| P-15 | C1-16, C1-18, C1-29 | 5/5 | — | **D** | mermaid no renderizado (no hay renderizador en la estación); regla de Parche P-30 y 0 `SaveAsync` en `ProponerLocalidadDesdeTexto`: diferidas | F04, F13, F34, F40, F42 |
| P-16 | C1-17 | 5/5 | — | **D** | pruebas de comportamiento heredado sobre la copia y `grep` en la guía: diferidos | F04, F13, F38, F42 |
| P-17 | C1-19, C1-38, C1-53 | 5/5 | — | **C** | puntos comunes aplicados; `diff -r` + build de la copia sola y prueba de cierre: diferidos; ubicación del normalizador: segunda ronda de C1-38 | F04, F13, F42 |
| P-18 | C1-20, C1-69 | 5/5 | — | **D** | SQLite en memoria con tres sesiones, reflexión y `ToQueryString`: diferidos | F04, F13, F42 |
| P-19 | C1-21 | 5/5 | — | **D** | `grep` de la cifra de patrón en la guía; PC-04 | F04, F13, F39, F41 |
| P-20 | C1-22, C1-66 | 5/5 | ídem | **D** | pendiente P-08 con `qwen3.5:4b` y prueba con cliente falso: diferidos | F04, F13, F38, F39, F41 |
| P-21 | C1-23 | 5/5 | columna fuente sin hosts (riesgo) | **V** | `cifras.py` re-ejecutado reproduce la tabla (diff = 0; 28 filas); las cuatro cifras de CAT-OP-02 reemplazadas. Cifras de la guía contra la tabla: en la relectura | F13, F39, F44, F45, F46 |
| P-22 | C1-24, C1-56 | 5/5 | — | **C** | definiciones y oro firmes; oro versionado, prueba determinista y pendiente P-05: diferidos; candidato en la demo: segunda ronda | F04, F13, F33, F38 |
| P-23 | C1-55 | 5/5 | — | **C** | parte común aplicada; comparación pareada diferida; rama tras la segunda ronda de C1-55 | F04, F13 |
| P-24 | C1-25, C1-43, C1-49 | 5/5 | — | **V** | nota visible en EA-6 (BIT-16-04 §1) y remisiones en tensión 1, MI-01 y pendiente P-01. Fracciones de la guía: RV-17, diferida | F04, F13 |
| P-25 | C1-26, C1-70, C1-S4 (4) | 5/5 | copiar, no renombrar (riesgo) | **P** | `X3-fecha.txt` copiado del intermedio; `escrituras.py` y `ventana.py` copiados (idénticos por `diff`), sin renombrar; cabeceras R-LLM de X2 y X3 en el README nuevo. Diferidos: `Inconclusive` sin endpoint y `grep -L "modelo@"` sobre salidas de `Examples/` (las salidas crudas no se tocan) | F04, F07, F08, F10, F11, F13, F42 |
| P-26 | C1-27, C1-35, C1-57, C1-58 | 5/5 | dos dobles del aprobador (evidencia) | **D** | `grep` de fragmentos inseguros en la guía, prueba de 0 ejecuciones con los dos dobles, `Examples/07` y `08`: diferidos | F04, F13, F32, F40 |
| P-27 | C1-28, C1-59 | 4 APLICAR + 1 MEJORAR_PLAN | título M1–M15 (impacto); tensión 6 (coherencia, MEJORAR_PLAN incorporado) | **P** | contradicción de la tensión 6 resuelta («pruebas adversariales extendidas» = 1); las 15 filas, con prueba o lugar, en el plan §4. Pruebas M13–M15: diferidas | F04, F13 |
| P-28 | C1-30, C1-S4 (1) | 4 APLICAR + 1 MEJORAR_PLAN | conteo `grep -o` = 13 − 2 (evidencia); tabla completa de anclas (coherencia, MEJORAR_PLAN incorporado) | **V** | `grep -o '\[C:'` fuera de notas en 00, 01 y 03 = 13 = 11 marcas + 2 explicaciones; las 11 con fila en las notas; anclas de REED-16 corregidas en tabla completa. `trazabilidad.md`: entregable previo | F01, F02, F03, F04, F13, F47 |
| P-29 | C1-31 | 5/5 | remisión en N1 §4.1 (riesgo) | **D** | matriz de snippets (entregable previo) y builds de cada carpeta: diferidos | F04, F13, F34, F42 |
| P-30 | C1-52 | 4 APLICAR + 1 MEJORAR_PLAN | segundo caso rojo; IL o agujero declarado (evidencia, MEJORAR_PLAN incorporado) | **D** | verde sobre la demo, rojo con la mutación y segundo caso rojo: diferidos (`Examples/13`) | F04, F05, F13 |
| P-31 | C1-32, C1-S4 (2) | 5/5 | — | **P** | `doc_id` en los seis registros (N1, N1b, N2, N3, N4, N5). C5, ids y REF sobre la guía: diferidos | F04, F13 |
| P-32 | C1-33, C1-60, C1-S4 (5) | 5/5 | — | **P** | nota en `Nucleos/N3-Evidencia/README.md` (nuevo) y en DC-08. Tabla del Anexo D, `--vulnerable` y `.gitignore` de prueba: el día de publicar | F01, F04, F13, F37, F47 |
| P-33 | C1-34 | 5/5 | preajuste exacto «Instruct (non-thinking) para tareas generales» (evidencia) | **V** | card de Qwen3.5-4B consultada hoy (E4, l. 835–838 guardadas): el preajuste citado existe; la fila de N1b lleva URL y fecha. PC-05: abierta | F13, F17, F34, F35 |
| P-34 | C1-36 | 5/5 | criterio por encabezado (impacto) | **V** | `## Validación del núcleo (ciclo 1)` = 1 en los nueve registros, con «Marcas [C] resueltas (2026-10-28)». Bloqueos vigentes: orden del pipeline (PC-02) y cierre de la sección de la demo | F13, F33, F34, F35, F36, F38, F39, F40, F41, F42, F47 |
| P-35 | C1-40, C1-62 | 5/5 | rama A sólo con PC-12 y PC-13 (riesgo) | **C** | parte común aplicada; prueba de 0 ejecuciones diferida; PC-13 y segunda ronda pendientes | F04, F13, F42 |
| P-36 | C1-41, C1-50 | 5/5 | — | **V** | criterio D1–D6 escrito con fecha 2026-10-28, sin ninguna corrida previa; el rótulo provisional va en el plan. `grep` en la guía: diferido | F04, F09, F13 |
| P-37 | C1-42, C1-51 | 5/5 | sin nombre del equipo; condiciones de uso del respaldo (evidencia, riesgo, costo-beneficio) | **V** | «no corre en estación 1» con nota a la vista en BIT-16-04, N3b y `Sondeo-Entorno.md`. No se levantó ningún contenedor en el equipo de respaldo | F04, F13, F39, F44 |
| P-38 | C1-44, C1-64 | 5/5 | semiancho con p declarado (evidencia) | **D** | `Evaluation` en `Demos/` y advertencia en la guía: diferidos | F04, F13, F33, F41 |
| P-39 | C1-45, C1-61 | 5/5 | — | **D** | `Proveedor` en `Demos/` y R-C14 en `Examples/06`: diferidos | F04, F13, F42 |
| P-40 | C1-47, C1-72 (a) | 5/5 | — | **D** | prueba de eventos de etapa con cliente falso: diferida | F04, F13, F42 |
| P-41 | C1-54 | 5/5 | — | **D** | depende de Parche P-30: diferida | F04, F13 |
| P-42 | C1-63 | 5/5 | — | **D** | `ActivityListener` sobre la fuente: diferida | F04, F13 |
| P-43 | C1-65 | 5/5 | — | **D** | generador falso de 512 frente a 1024: diferido | F04, F13, F42 |
| P-44 | C1-67 | 5/5 | — | **P** | PC-14 registrada (03-Parches §5 y plan §8). `grep` de `Comentario` en la guía y `Examples/`: diferido | F04, F13, F41 |

> **2026-10-28 — Parche P2-08 (ciclo 1, ronda 2).** Fila P-39: la **D** de «`Proveedor` en `Demos/` y R-C14 en `Examples/06`» se cierra en el diseño: el selector y la prueba de R-C14 con dos proveedores falsos viven en `Examples/01` y `06`, y la demo registra un solo proveedor (nota en BIT-16-04 §3.2, R-C14). La verificación sigue diferida a `Examples/` y `Demos/`.


## 3. Changelog por hallazgo

Veredicto del jurado (`PROCEDE` en los 73) → parche → estado. El texto del hallazgo está en 01-Consolidado §2–§5.

| Ítem | Veredicto | Parche | Estado |
|---|---|---|---|
| C1-01 | PROCEDE (5/5) | P-01 | P-01 **V** |
| C1-02 | PROCEDE (5/5) | P-02 | P-02 **V** |
| C1-03 | PROCEDE (5/5) | P-03 | P-03 **P** |
| C1-04 | PROCEDE (5/5) | P-04 | P-04 **V** |
| C1-05 | PROCEDE (5/5) | P-05 | P-05 **C** |
| C1-06 | PROCEDE (5/5) | P-06 | P-06 **V** |
| C1-07 | PROCEDE (5/5) | P-07 | P-07 **P** |
| C1-08 | PROCEDE (5/5) | P-08 | P-08 **D** |
| C1-09 | PROCEDE (5/5) | P-09 | P-09 **P** |
| C1-10 | PROCEDE (5/5) | P-10 | P-10 **P** |
| C1-11 | PROCEDE (5/5) | P-11 | P-11 **P** |
| C1-12 | PROCEDE (5/5) | P-12 | P-12 **P** |
| C1-13 | PROCEDE (5/5) | P-11 | P-11 **P** |
| C1-14 | PROCEDE (5/5) | P-13 | P-13 **C** |
| C1-15 | PROCEDE (5/5) | P-14 | P-14 **D** |
| C1-16 | PROCEDE (5/5) | P-15 | P-15 **D** |
| C1-17 | PROCEDE (5/5) | P-16 | P-16 **D** |
| C1-18 | PROCEDE (5/5) | P-15 | P-15 **D** |
| C1-19 | PROCEDE (5/5) | P-17 | P-17 **C** |
| C1-20 | PROCEDE (5/5) | P-18 | P-18 **D** |
| C1-21 | PROCEDE (5/5) | P-19 | P-19 **D** |
| C1-22 | PROCEDE (5/5) | P-20 | P-20 **D** |
| C1-23 | PROCEDE (5/5) | P-21 | P-21 **V** |
| C1-24 | PROCEDE (5/5) | P-22 | P-22 **C** |
| C1-25 | PROCEDE (5/5) | P-24 | P-24 **V** |
| C1-26 | PROCEDE (5/5) | P-25 | P-25 **P** |
| C1-27 | PROCEDE (5/5) | P-26 | P-26 **D** |
| C1-28 | PROCEDE (5/5) | P-11, P-27 | P-11 **P**, P-27 **P** |
| C1-29 | PROCEDE (5/5) | P-15 | P-15 **D** |
| C1-30 | PROCEDE (5/5) | P-28 | P-28 **V** |
| C1-31 | PROCEDE (5/5) | P-29 | P-29 **D** |
| C1-32 | PROCEDE (5/5) | P-31 | P-31 **P** |
| C1-33 | PROCEDE (5/5) | P-32 | P-32 **P** |
| C1-34 | PROCEDE (5/5) | P-33 | P-33 **V** |
| C1-35 | PROCEDE (5/5) | P-26 | P-26 **D** |
| C1-36 | PROCEDE (4-1) | P-34 | P-34 **V** |
| C1-37 | PROCEDE (5/5) | P-03 | P-03 **P** |
| C1-38 | PROCEDE (4 + 1 INSUFICIENTE) | P-17 | P-17 **C** |
| C1-39 | PROCEDE (5/5) | P-01 | P-01 **V** |
| C1-40 | PROCEDE (5/5) | P-35 | P-35 **C** |
| C1-41 | PROCEDE (5/5) | P-36 | P-36 **V** |
| C1-42 | PROCEDE (5/5) | P-37 | P-37 **V** |
| C1-43 | PROCEDE (5/5) | P-24 | P-24 **V** |
| C1-44 | PROCEDE (5/5) | P-38 | P-38 **D** |
| C1-45 | PROCEDE (5/5) | P-39 | P-39 **D** |
| C1-46 | PROCEDE (5/5) | P-12 | P-12 **P** |
| C1-47 | PROCEDE (5/5) | P-40 | P-40 **D** |
| C1-48 | PROCEDE (4 + 1 INSUFICIENTE) | P-05 | P-05 **C** |
| C1-49 = MI-01 | PROCEDE (5/5) | P-24 | P-24 **V** |
| C1-50 = MI-02 | PROCEDE (5/5) | P-36 | P-36 **V** |
| C1-51 = MI-03 | PROCEDE (5/5) | P-37 | P-37 **V** |
| C1-52 = MI-04 | PROCEDE (5/5) | P-30 | P-30 **D** |
| C1-53 = MI-05 | PROCEDE (5/5) | P-17 | P-17 **C** |
| C1-54 = MI-06 | PROCEDE (5/5) | P-41 | P-41 **D** |
| C1-55 = MI-07 | PROCEDE (5/5) | P-23 | P-23 **C** |
| C1-56 = MI-08 | PROCEDE (5/5) | P-22 | P-22 **C** |
| C1-57 = MI-09 | PROCEDE (5/5) | P-26 | P-26 **D** |
| C1-58 = MI-10 | PROCEDE (5/5) | P-26 | P-26 **D** |
| C1-59 = MI-11 | PROCEDE (5/5) | P-27 | P-27 **P** |
| C1-60 = MI-12 | PROCEDE (5/5) | P-32 | P-32 **P** |
| C1-61 = MI-13 | PROCEDE (5/5) | P-39 | P-39 **D** |
| C1-62 = MI-14 | PROCEDE (5/5) | P-35 | P-35 **C** |
| C1-63 = MI-15 | PROCEDE (5/5) | P-42 | P-42 **D** |
| C1-64 = MI-16 | PROCEDE (5/5) | P-38 | P-38 **D** |
| C1-65 = MI-17 | PROCEDE (5/5) | P-43 | P-43 **D** |
| C1-66 = MI-18 | PROCEDE (5/5) | P-20 | P-20 **D** |
| C1-67 = MI-19 | PROCEDE (3-2) (NO_PROCEDE de la propuesta del consolidado; se aplicó la alternativa conceptual) | P-44 | P-44 **P** |
| C1-68 = MI-20 | PROCEDE (5/5) | P-14 | P-14 **D** |
| C1-69 = MI-21 | PROCEDE (5/5) | P-18 | P-18 **D** |
| C1-70 = MI-22 | PROCEDE (5/5) | P-25 | P-25 **P** |
| C1-71 = MI-23 | PROCEDE (5/5) | P-12 | P-12 **P** |
| C1-72 = MI-24 | PROCEDE (4-1) | P-02, P-40 | P-02 **V**, P-40 **D** |
| C1-S4 | PROCEDE (5/5) (lote: (1) P-28, (2) P-31, (3) P-03, (4) P-25, (5) P-32) | P-03, P-25, P-28, P-31, P-32 | P-03 **P**, P-25 **P**, P-28 **V**, P-31 **P**, P-32 **P** |

## 4. Versiones de los archivos

sha256 y líneas después de la aplicación (2026-10-28, antes de escribir este archivo). «Notas» = notas fechadas insertadas; «R-PRIV» = líneas redactadas in situ (Parche P-01).

| Id | Archivo | sha256 | Líneas | Notas | R-PRIV | Parches | Líneas donde empiezan las notas |
|---|---|---|---|---|---|---|---|
| F01 | `Bitacoras/00-Contrato-De-Entrada.md` | `b39e8327662b2f888bc5a788a1d721d5b97d65ef26b338bc3f4b03403a5c18b9` | 189 | 3 | 1 | P-01, P-28, P-32 | 173, 177, 94 |
| F02 | `Bitacoras/01-Descomposicion-Conceptual.md` | `2f99dddbf758439bb07213f25952be6134b9cf6fb1fb8e61684368d92d4fb82f` | 229 | 1 | 0 | P-28 | 216 |
| F03 | `Bitacoras/03-Marco-De-Referencia.md` | `5d1b9bc7fd14df20426a345787f8ef40a9644b36592850647ce3382dab5a4d40` | 150 | 2 | 0 | P-05, P-28 | 88, 144 |
| F04 | `Bitacoras/04-Integracion.md` | `70e40c04fece33de7756fbbcace7349a4e041e070efd8c7b2d795329d4b47204` | 832 | 49 | 0 | P-02, P-03, P-05, P-06, P-07, P-08, P-09, P-10, P-11, P-12, P-14, P-15, P-16, P-17, P-18, P-19, P-20, P-21yremisiones, P-22, P-23, P-24, P-25, P-26, P-27, P-28, P-29, P-30, P-31, P-32, P-35, P-36, P-37, P-38, P-39, P-40, P-41, P-42, P-43, P-44 | 120, 129, 202, 430, 466, 468, 471, 385, 154, 135, 353, 81, 256, 265, 338, 275, 517, 158, 68, 550, 285, 295, 298, 545, 300, 302, 563, 314, 726, 316, 734, 321, 323, 165, 329, 331, 334, 167, 339, 341, 169, 353, 355, 627, 357, 359, 543, 361, 830 |
| F05 | `Bitacoras/Integracion-Evidencia/A-arquitectura/README.md` | `e0e0c3c3a89545954ead767b4532488260759cd1d221cec9148f9ced190f160e` | 11 | 1 | 0 | P-01, P-30 | 8 |
| F06 | `Bitacoras/Integracion-Evidencia/A-arquitectura/exp-capas/verificar-capas.sh` | `4f55888c47109318f7ad76ebfdc48376125cd15136d2d6dd93440ec91c19f2f3` | 10 | 0 | 1 | — | — |
| F07 | `Bitacoras/Integracion-Evidencia/C-operacion-demo/README.md` | `0c1794682956879f50137470c4b710010d1d185379ca2c65256be25fdc0b2ff7` | 30 | 0 | 0 | — | — |
| F08 | `Bitacoras/Integracion-Evidencia/C-operacion-demo/X3-fecha.txt` | `2cf0667b2ce1c2aba70f9ee09c24a4ce725dd6113d8d97ab9d62fcd19f1bad65` | 2 | 0 | 0 | — | — |
| F09 | `Bitacoras/Integracion-Evidencia/C-operacion-demo/criterio-D1-D6-qwen3.5-2b-vs-4b.md` | `6c306217efdc0f78f22cf5b95a29356cdb0291dd3fbcbee7523cb0c74f96f416` | 10 | 0 | 0 | — | — |
| F10 | `Bitacoras/Integracion-Evidencia/C-operacion-demo/escrituras.py` | `dc584aa56bf7e7b4a720e23b4d72bfa3a9c4918930b22acf4f92774dd6c564b4` | 87 | 0 | 0 | — | — |
| F11 | `Bitacoras/Integracion-Evidencia/C-operacion-demo/ventana.py` | `1b9658471523ba5c286e331b61c892c6337ed83f76baf823eb1e35387248a33a` | 25 | 0 | 0 | — | — |
| F12 | `Bitacoras/Mesa/Ciclo-1/00-Convocatoria.md` | `9d0e512eee5faf0996bf5e315cc70836848ad66280f8f7ff5f8169698da31e7b` | 445 | 1 | 2 | P-01 | 445 |
| F13 | `Bitacoras/Mesa/Ciclo-1/06-Plan-De-Redaccion.md` | `c86f1a96133f9ced24b8068d03384b6b4dca22f4f2bcd90a65280589efebf189` | 323 | 0 | 0 | — | — |
| F14 | `Bitacoras/Mesa/Ciclo-1/aplicacion/.gitignore` | `6c5082c7e6de3e350189c67a1aacf757485ecc26e0a3cf96683528565f3e5f12` | 2 | 0 | 0 | — | — |
| F15 | `Bitacoras/Mesa/Ciclo-1/aplicacion/conteo-preguntas-2026-10-28.txt` | `50c1ec51e7c34a5b21d39775d9207a690b6891007a17a957859612ba336620e1` | 10 | 0 | 0 | — | — |
| F16 | `Bitacoras/Mesa/Ciclo-1/aplicacion/conteo-preguntas.sh` | `27be959bd88658fd352492dbbfd169f32a94df9f753326b883d18221dfd54d61` | 6 | 0 | 0 | — | — |
| F17 | `Bitacoras/Mesa/Ciclo-1/aplicacion/qwen3.5-4b-card-l835-838.txt` | `e004315043930fb158bd5f2de92247df3c902bd87497a8e2c25d7beb6058c981` | 5 | 0 | 0 | — | — |
| F18 | `Bitacoras/Mesa/Ciclo-1/aplicacion/rpriv-2026-10-28-antes.txt` | `49404ee218f983f165ae628e29b2bbe24dd06c488736a567bd170e1ef7f4292a` | 77 | 0 | 0 | — | — |
| F19 | `Bitacoras/Mesa/Ciclo-1/aplicacion/rpriv-2026-10-28-despues.txt` | `2da3b106593eef5d141462cf6f2cdf3fed933393defaa1719b24d4324f5b6265` | 66 | 0 | 0 | — | — |
| F20 | `Bitacoras/Mesa/Ciclo-1/aplicacion/rpriv.sh` | `e437aaf53d867a51fb06e30d7e27c2643785b12b7781fd39366bcbd2d77d9f24` | 19 | 0 | 0 | — | — |
| F21 | `Bitacoras/Mesa/Ciclo-1/aplicacion/sonda-limitador/Program.cs` | `c8d5e34fde1e4a6519c67eb384d6c0391c4602336c81cc9ee156963b9fa02d1a` | 33 | 0 | 0 | — | — |
| F22 | `Bitacoras/Mesa/Ciclo-1/aplicacion/sonda-limitador/Sonda.csproj` | `972377d2802e34a7e223de4893b9759a0af47c74676665cfb86f235d5be384ec` | 3 | 0 | 0 | — | — |
| F23 | `Bitacoras/Mesa/Ciclo-1/aplicacion/sonda-limitador/salida.txt` | `409719e8c1ebdd559db7e918db7e0c353106872858c19a3ff111968157ab2d46` | 8 | 0 | 0 | — | — |
| F24 | `Bitacoras/Mesa/Ciclo-1/aplicacion/sonda-opciones/Program.cs` | `9ecafc426ad19fef6be7747b7b5bd64820c8baa950291882080f6f0d8bc76940` | 35 | 0 | 0 | — | — |
| F25 | `Bitacoras/Mesa/Ciclo-1/aplicacion/sonda-opciones/Sonda.csproj` | `3efb6e30d3f3166db999e0979250b2f9e99d1a67c62f39190757753a2ce74f62` | 7 | 0 | 0 | — | — |
| F26 | `Bitacoras/Mesa/Ciclo-1/aplicacion/sonda-opciones/salida.txt` | `e95655d77edd928941532d0e68b078fd424aa1dbc15d9af575777e59e7980b29` | 8 | 0 | 0 | — | — |
| F27 | `Bitacoras/Mesa/Ciclo-1/aplicacion/verificaciones-2026-10-28.txt` | `85860a05c2662001d42fa19745dca67c3ccb284dd28d9ac1a03a2c445ba1ea13` | 50 | 0 | 0 | — | — |
| F28 | `Bitacoras/Mesa/Ciclo-1/aplicacion/verificar-ciclo-1.sh` | `ffcbf046f95f46fe623723b05368634b5087b02ccd4586444c243fbb0d8d756c` | 23 | 0 | 0 | — | — |
| F29 | `Bitacoras/Mesa/Ciclo-1/evidencia-arquitectura/sonda-arquitectura-salida.txt` | `b7c52e69f53ac71e82ecb72af46b7d1700d3052d59c765f9a9b373aea5672f29` | 46 | 0 | 7 | — | — |
| F30 | `Bitacoras/Mesa/Ciclo-1/evidencia-arquitectura/sonda-arquitectura.sh` | `2de7286fd1fea11a263c60840c98e1e0ade7e1659fb3bbf16a127c726dccd24d` | 15 | 0 | 1 | — | — |
| F31 | `Bitacoras/Mesa/Ciclo-1/evidencia-verificacion-qa/G3-rpriv.txt` | `3a86722a56d4a407de17dab12af8e4972380bc3ae2acda819bf92c00953381e6` | 90 | 0 | 9 | — | — |
| F32 | `Bitacoras/Mesa/I-01-Insumos-Del-PO-Agentes-LangGraph-Anotaciones.md` | `b6bfcbc9ae487cc664063663533a656293c88ea69896ad5e5b44e555615905f9` | 110 | 1 | 0 | P-26 | 47 |
| F33 | `Bitacoras/Nucleos/N0b-Producto-Datos-Y-Perfil.md` | `1f8aabbed0d37c6ff8c93eeeed033544fdcb1ed9089f8e598c3c9b9e2e2dfe83` | 616 | 8 | 3 | P-01/P-04/P-31/P-34, P-02, P-12, P-13, P-22, P-34, P-38 | 107, 572, 282, 335, 147, 367, 596, 604 |
| F34 | `Bitacoras/Nucleos/N1-Capa-IA-En-El-Stack.md` | `df2785b97b36ad08e9b408efaae83a75ca1becf9c4fcbe4cd354768f390b6fdb` | 603 | 6 | 4 | P-01/P-04/P-31/P-34, P-15, P-29, P-33, P-34 | 167, 237, 120, 374, 569, 589 |
| F35 | `Bitacoras/Nucleos/N1b-Por-Que-Ahora-Evolucion-De-Los-LLM.md` | `67a58225d844a045641b44f0ff354632ea49c0292ceb3eb0ddc006aea3a87eee` | 467 | 3 | 2 | P-01/P-04/P-31/P-34, P-33, P-34 | 106, 445, 455 |
| F36 | `Bitacoras/Nucleos/N2-Abstracciones-Y-Proveedores-NET.md` | `a91d9fd2cfede405064bd57e718414a097fdb3947d9488cdb3d3598654378b92` | 591 | 3 | 0 | P-01/P-04/P-31/P-34, P-03, P-34 | 369, 556, 574 |
| F37 | `Bitacoras/Nucleos/N3-Evidencia/README.md` | `860ec6364d32dd54d426571ba2f09d9c5f0db48cc972ba6dbecdf05e31c841a9` | 5 | 0 | 0 | — | — |
| F38 | `Bitacoras/Nucleos/N3-RAG-En-NET.md` | `3d236ab482f411a07c9ba872013be70e2c93de8f4e53145243daafc4b4cd7fc3` | 710 | 7 | 0 | P-01/P-04/P-31/P-34, P-16, P-20, P-22, P-34 | 255, 322, 132, 93, 395, 678, 696 |
| F39 | `Bitacoras/Nucleos/N3b-CAG-Y-Estrategias-De-Conocimiento.md` | `b2746631644a2ad35a8d621ed2cedcbf37a1b5c59635d140e86b628012cafc2d` | 647 | 8 | 3 | P-01/P-04/P-31/P-34, P-19, P-20, P-21, P-34, P-37 | 49, 110, 199, 494, 496, 622, 627, 635 |
| F40 | `Bitacoras/Nucleos/N4-Agentes-Y-Orquestacion.md` | `0f1ce05c587b8dc5dbbf608599b63a69ff26ee8d64ad2b4fcf85759127394426` | 762 | 9 | 0 | P-01/P-04/P-31/P-34, P-15, P-26, P-34 | 56, 91, 135, 322, 416, 462, 543, 728, 746 |
| F41 | `Bitacoras/Nucleos/N5-Operacion-Calidad-Seguridad.md` | `12f2534e1af1fc178f86649b59d9e2c24ef9595f090b2363c83f738c201833c3` | 836 | 10 | 0 | P-01/P-04/P-31/P-34, P-03, P-19, P-20, P-34, P-38, P-44 | 276, 33, 249, 789, 439, 99, 611, 519, 803, 821 |
| F42 | `Bitacoras/Nucleos/N6-Caso-Movilidad-Urbana.md` | `cf0b79b3d2663a3e7598cddb5ad8b74c9dffdb2189937813a9e2b1e7f2af3dcc` | 707 | 10 | 0 | P-01/P-04/P-31/P-34, P-05, P-13, P-14, P-15, P-16, P-17, P-18, P-25, P-29, P-34, P-35, P-39, P-40, P-43 | 87, 57, 568, 500, 562, 285, 308, 382, 689, 695 |
| F43 | `Bitacoras/README.md` | `49077014668be71ae6d2a087e1c47fe9f5493a226a7e41c9e42b199dbe3b1348` | 134 | 0 | 0 | — | — |
| F44 | `Bitacoras/Sondeo-Entorno.md` | `227092c3b6f48a008a03155833bddc25124945d4dea8d99b53a09654203aeea2` | 322 | 3 | 2 | P-01, P-21, P-37 | 309, 313, 313 |
| F45 | `Bitacoras/Sondeo-Evidencia/2026-10-28/cifras-2026-10-28.md` | `6465f0ec9cb677b592bbed6d7a20d1b6f53a735dcdc575031294230be8d1e191` | 34 | 0 | 0 | — | — |
| F46 | `Bitacoras/Sondeo-Evidencia/2026-10-28/cifras.py` | `6af611c42c1e4a6ff5a8ceee9dd12855c22b51c7d4710a8e2901906600fd456b` | 71 | 0 | 0 | — | — |
| F47 | `Crear-IA-Layer-Guide-Reedicion.md` | `7530bbfc22af92ae752444d74d0ee019b7aa1815eee68d795f6bce6ac78d7c63` | 568 | 5 | 1 | P-01, P-10, P-28, P-32, P-34 | 363, 378, 380, 390, 240 |
| F48 | `Reanudar.md` | `6aae0eec6fbcea420ee19e757c0168a9b571f0f4037b5845dc558be3a4383d19` | 63 | 1 | 4 | P-01 | 62 |

Las líneas de inserción son las de cada nota en el momento de insertarla; notas posteriores en la misma sección corren las anteriores. Para ubicar una nota, buscar su encabezado `Parche P-NN (ciclo 1)`.

## 5. Compuertas de REED-16 §9.1

| Compuerta | Hoy | Resultado | Salida |
|---|---|---|---|
| C1 sin contradicciones | sobre la bitácora, guiada por las tensiones y las notas | contradicción tensión 6 / M14 resuelta (P-27); «mezcla sesiones» = 0 fuera de notas (P-12); «≥ 7B no corre» con nota a la vista (P-37); «falso aceptado» con un solo sentido vigente (P-02); orden del pipeline neutral hasta PC-02 (P-03) | `aplicacion/verificaciones-2026-10-28.txt` |
| C2 requisito con id, criterio y prueba | marcas `[C:]` | 11 de 11 con resolución (P-28); tabla S-/§7.n/PR → sección: esqueleto en el plan §9, completa en `Mesa/Ciclo-2/trazabilidad.md` (pendiente) | ídem |
| C3 trazabilidad inversa | plan de redacción | cada sección de la guía con núcleo y solicitud (plan §2 y §9) | `06-Plan-De-Redaccion.md` |
| C4 sin huérfanos | enlaces y núcleos | **0 enlaces rotos** sobre todos los `.md` de `OUTPUTs/` (G2-enlaces.py); cada núcleo con sección, preguntas y ejemplo en el plan; cada carpeta de `Examples/` citada por una sección | ídem |
| C5 glosario unívoco | — | no aplica sin guía; el procedimiento lo fija P-31 (Anexo C; agente y workflow por el Experto IA) | — |
| R-PRIV | `rpriv.sh` | **`patrones=0`** sobre `OUTPUTs/` (antes: 40); `identificadores=360` (361 después de escribir este archivo; nombres de equipos y contenedores en la bitácora; informan y no bloquean el ciclo, sí el commit) | `aplicacion/rpriv-2026-10-28-antes.txt`, `rpriv-2026-10-28-despues.txt` |
| Build y test en `sdk:10.0` | sondas | 2/2 sondas compilan y corren (SDK 10.0.403); `Examples/` y `Demos/` no existen | `aplicacion/sonda-*/salida.txt` |
| Pruebas contra el modelo con R-LLM | — | ninguna corrida nueva (no hacía falta hoy) | — |
| Mermaid que renderiza | — | **no corrida**: no hay renderizador de mermaid en la estación (deuda D-3) | — |
| `.gitignore` (DC-08) | — | no aplica sin `Examples/` ni `Demos/`; la carpeta `aplicacion/` lleva `.gitignore` con `bin/` y `obj/` | — |
| Versiones = `PackageReference` | — | el día de publicar (P-32) | — |

## 6. Deuda declarada

Ningún parche salió `NO_APLICAR`. Lo que sigue es lo que la aplicación no pudo cerrar hoy, con su motivo y su default (REED-16 §12: ante duda, default y registro).

| # | Qué | Motivo | Default aplicado | Dónde se cierra |
|---|---|---|---|---|
| D-1 | Dictamen de la presidencia sobre la excepción a «sólo agregado» de P-01 | no está registrado | redacción in situ aplicada (jurado y aprobación unánimes); copia previa borrada por condición del juez de riesgo | presidencia; si rechaza, rama alternativa (fuera de commit) |
| D-2 | `identificadores > 0` en `OUTPUTs/` (hostnames y nombres de contenedores) | C1-39: su estatus en la bitácora lo decide la presidencia | informan y no bloquean el ciclo; **bloquean el commit** (condición del juez de riesgo) | dictamen fechado de la presidencia |
| D-3 | Mermaid sin renderizar (P-15 y los diagramas de la bitácora) | no hay renderizador en la estación | sin cambio | compuerta de la redacción |
| D-4 | Verificaciones diferidas de P-03 (resto), P-07, P-08, P-10, P-11 (resto), P-12, P-13…P-20, P-22, P-23, P-25 (resto), P-26, P-27 (pruebas), P-29…P-32 (resto), P-35, P-38…P-44 | dependen de `Examples/`, `Demos/` o la guía | marcadas **D**/**P**/**C**, nunca verdes | redacción y relectura integral (plan §7) |
| D-5 | Segunda ronda de C1-48, C1-40/C1-62 (con PC-13), C1-55 y parte de C1-56, C1-38 y C1-53 | 02-Revision-Homogeneidad §3.1–§3.2; no hay segunda ronda registrada | parte común aplicada; ramas con mayoría actual rotuladas provisionales | `Mesa/Ciclo-2/segunda-ronda.md` |
| D-6 | PC-01…PC-15 sin responder | consultas dirigidas a Senior .NET, Operación, Experto IA, AH-01, AH-02 | «no probado» o versión conceptual en la guía | plan §1 y §8 |
| D-7 | Definición de *agente* y *workflow* | la pide P-31 al Experto IA | §7 de la guía no se redacta sin ella | plan §1 |
| D-8 | `grep -L "modelo@"` sobre salidas crudas (P-25) | las salidas no se tocan (sólo agregado) | cabeceras completadas en los README de A, B y C | `Examples/` en adelante |
| D-9 | Fila N6 de 03 §4.1 sigue diciendo «candidato» en el texto original | sólo agregado | la nota de P-05 en 03 §4.1 la reemplaza | segunda ronda de C1-48 |
| D-10 | La guía debe citar el paquete `Microsoft.Extensions.Options.DataAnnotations` en consolas | hallazgo nuevo de la sonda de P-11 (CS1061 sin él) | agregado a la nota de P-11 y al plan §2 (§5) | `Examples/01` |

Descartes con motivo, ya decididos por la mesa: PR-7 (P-06: RD-PO-1 y C1-27); la propuesta de MI-16 de juez calibrado en la demo (P-38); la propuesta de MI-19 con un campo `Comentario` (`NO_PROCEDE` de la propuesta en C1-67, 3-2; P-44); `Examples/11` (P-44).

> **2026-10-28 — Ronda 2 del ciclo 1: deudas cerradas** (orden de aplicación de `Ronda-2/03-Parches.md` §4.6; registro en `Ronda-2/05-Aplicacion.md`).
> - **D-1** cerrada por el dictamen de la presidencia §1 (`07-Dictamen-Presidencia.md`): la redacción in situ de P-01 queda firme; Parche P2-01 usó la misma excepción para 1 ruta.
> - **D-2** cerrada por el dictamen §2: identificadores permitidos en la bitácora mientras no se commitee; el barrido con `identificadores=0` es condición del primer commit (Parche P2-01, compuerta v2 en `Ronda-2/aplicacion/rpriv.sh`).
> - **D-5** cerrada por la ronda 2: C1-48 = A, C1-40 = B, C1-62 = B, C1-55 = B, C1-56 = B, C1-38 = A, C1-53 = A (Parches P2-02, P2-03 y P2-04). Los parches P-05, P-13, P-17, P-22, P-23, P-27 y P-35 pasan de **C** a firmes en la rama ganadora.
> - **D-6** cerrada salvo lo marcado en C por cada parche: PC-01, PC-09, PC-12 y PC-15 (P2-07), PC-03 y PC-05 (P2-01, P2-08), PC-04 y PC-06 (P2-09), PC-11 (P2-05), PC-14 (P2-12), PC-02 (P2-06), PC-07 y PC-08 (P2-10, P2-11), PC-10 (P2-13), PC-13 (P2-03).
> - **D-7** cerrada por Parche P2-14 para agente, herramienta, orquestación y workflow de MAF; el sentido de «workflow» (C1-32) sigue en la presidencia.
> - **D-9** cerrada por Parche P2-02: nota en `03-Marco-De-Referencia.md` §4.1 con la fila N6 sin «candidato».


## 7. Escaladas

**Ninguna.** Revisé los siete disparadores de REED-16 §12 contra lo aplicado, igual que los jueces de evidencia y de riesgo: no hay ambigüedad de intención, ni conflicto entre restricciones duras (el servidor de prueba está disponible por variable y turno), ni cambio de alcance (nada toca `Lab-E2E.WebBlazor` ni la nube), ni irreversibilidad con impacto real (lo único irreversible a la vista es el primer commit, que queda bloqueado por D-1 y D-2), ni consecuencia externa, ni empate persistente (la segunda ronda todavía no se votó), ni reapertura de una DC-0n («sólo agregado» es una convención de la bitácora, no una DC). No se creó `Escaladas.md`. D-1 y D-2 son decisiones de la presidencia, no del PO.

## 8. Revertidos y regresiones

**Ninguno.** Ninguna verificación corrida hoy falló. La única falla del día fue de la sonda de P-11 en su primera compilación (CS1061 por el paquete faltante); era de la sonda y no del parche, se corrigió la sonda y se registró como hallazgo (D-10).

## 9. Estadísticas

| Medida | Valor |
|---|---|
| Ítems del jurado | 73 (C1-01…C1-72 y C1-S4), 73 `PROCEDE` (68 unánimes; no unánimes: C1-36, C1-38, C1-48, C1-67, C1-72) |
| Parches | 44 aprobados, 44 aplicados; 0 `NO_APLICAR`, 0 revertidos |
| Estado de verificación | V 11 · P 11 · D 16 · C 6 |
| Ajustes vinculantes incorporados | 21 parches (incluidos los pedidos de las cinco posiciones `MEJORAR_PLAN` en minoría) |
| Notas fechadas insertadas | 131, en 19 archivos `.md` |
| Archivos nuevos | 24 (plan de redacción, evidencia de la aplicación, README de evidencia, tabla de cifras, criterio D1–D6, copias de scripts) |
| Redacción R-PRIV in situ | 40 líneas en 13 archivos; `patrones` 40 → 0 |
| Enlaces relativos | 0 rotos |
| Sondas E1 | 2 (recurso `build`, `sdk:10.0`), 2 en verde |
| Turnos de modelo | 0 |
| Escaladas | 0 |
