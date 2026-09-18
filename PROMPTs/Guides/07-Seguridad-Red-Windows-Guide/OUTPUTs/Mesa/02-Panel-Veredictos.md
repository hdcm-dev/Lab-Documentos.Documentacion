---
doc_id: MESA-02-VEREDICTOS
doc_type: mesa
title: Panel de hallazgos y veredictos
status: vigente
origin: ia-assisted
audience: [humano, agente]
traces: [MESA-01-CONVOCATORIA, MESA-03-CIERRE]
---

# Mesa evaluadora — Panel de hallazgos y veredictos (ciclo 1)

El relator consolidó los cinco informes ciegos, dedupló y agrupó por raíz. El jurado (5 funciones: evidencia, impacto, costo-beneficio, coherencia, riesgo) votó hallazgo por hallazgo. Resumen.

## 1. Hallazgos consolidados (deduplicados)

| ID mesa | Origen (especialistas) | Sev. | Descripción | Veredicto |
|---|---|---|---|---|
| H-01 | T-01 + V-01 | S2 | El evento 1102 se presenta como imposible de evadir | **PROCEDE** |
| H-02 | T-02 | S3 | Logon Type 8 descrito como «contraseña en claro por la red» (falso) | **PROCEDE** |
| H-03 | V-02 + T-03 | S3 | IP real `45.77.13.9` como C2; «enrutable» impreciso | **PROCEDE** |
| H-04 | V-03 | S3 | Tabla de Logon Types rotulada «oficial» siendo subconjunto; falta tipo 12 | **PROCEDE** |
| H-05 | E-01 | S2 | Diagrama `timeline` roto por `:` en las horas | **PROCEDE** |
| H-06 | E-02 | S3 | Referencia cruzada §1.4 → debe ser §1.7 | **PROCEDE** |
| H-07 | E-04 | S3 | Falta el 4624 de `sqlbackup` (LogonID 0x7A441); cadena colgada | **PROCEDE** |
| H-08 | E-03 | S3 | Multiplicidad terminológica para el canal Security | **PROCEDE** |
| H-09 | E-05 | S4 | «en dos horas» vs. ráfaga de ~1 h | **PROCEDE** |
| H-10 | E-06 | S4 | T1003 listada como citada sin anclar en el cuerpo | **PROCEDE** |
| H-11 | V-04 | S4 | Paráfrasis de la RFC 791 entre comillas de cita literal | **PROCEDE** |
| H-12 | V-05 | S4 | Kerberoasting (0x17/4769) sin la marca de rigor que sí lleva su hermano | **PROCEDE** |
| D-01 | Didáctica | S2 | §11 suelta términos ofensivos sin definir (LLMNR, LSASS, DCSync…) | **PROCEDE** |
| D-02 | Didáctica + L-02 + L-07 | S2 | PowerShell/pipeline/cmd-vs-PS/multilínea sin explicar | **PROCEDE** |
| D-03 | Didáctica + L-03 | S3 | Laboratorio y proyecto integrador sin receta ejecutable | **PROCEDE** |
| D-04 | Didáctica | S3 | «Notas de rigor» de sourcing en el flujo del principiante | **NO_APLICAR (deuda)** |
| D-05 | Didáctica | S3 | NTLM y otros usados antes de definirse | **PROCEDE** (glosario) |
| D-06 | Didáctica | S4 | Hex sin decir al lector que sólo debe *emparejar* | **PROCEDE** |
| L-01 | Lector ingenuo | S1* | No enseña a construir la línea de base de un servidor real | **PROCEDE** |
| L-04 | Lector ingenuo | S3 | Cuenta `soporte` de auditoría dada por existente | **PROCEDE** |
| L-05 | Lector ingenuo | S3 | «Descargá Sysinternals/Sysmon» sin decir cómo | **PROCEDE** |
| L-06 | Lector ingenuo | S4 | `C:\evidencia\` sin decir que hay que crearla | **PROCEDE** |

\* L-01 es S1 *desde la perspectiva del lector* (sin baseline no puede ejecutar el método); el jurado lo tomó como bloqueante de la utilidad práctica y lo priorizó.

## 2. Fundamento de los votos no unánimes

**D-04 — NO_APLICAR (deuda declarada).** El juez de coherencia observó que las «Notas de rigor» que la didáctica quiere segregar son valoradas por los especialistas E2 (edición) y E5 (verificación) como **el mayor mérito de la obra** y que Rule-Evidences las exige. El juez de costo-beneficio sumó que Markdown no ofrece un «margen» real para segregarlas sin romper el flujo. Resolución: se conservan, ya están visualmente acotadas como blockquote «Nota de rigor». Se registra como deuda: en una eventual edición con maquetación (no Markdown plano) podrían ir a nota al margen.

**L-01 — elevado a prioridad máxima pese a ser «lo que el prompt no pidió literalmente».** El prompt pide que el lector pueda «auditar un servidor real». Sin saber construir su línea de base, no puede. El juez de impacto lo consideró la diferencia entre una guía que se entiende y una que se usa. Se aplicó (nueva guía en §1.7).

## 3. Reparación en la capa de origen

Todos los parches se aplicaron sobre los entregables (capa de origen del defecto) y sobre el corpus del escenario cuando el dato vivía ahí (IP, 4624 de sqlbackup). No se parcheó «aguas abajo». Ningún hallazgo tocó decisiones cerradas del contrato.
