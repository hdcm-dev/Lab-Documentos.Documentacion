# Mesa evaluadora — Ciclo 4 sobre el cuaderno de ejercicios

**Fecha:** 2026-09-17
**Objeto:** `Cuaderno-Ejercicios-Seguridad-Windows.md` v1.0 (nuevo entregable compañero)
**Disparador:** el usuario pidió un cuaderno de ejercicios prácticos con una sección de respuestas explicativas.

## 1. Convocatoria
- Núcleo (requisitos, verificación, lector-novato, abogado) + **E-Didáctica** (calidad pedagógica: unicidad de respuesta, dificultad progresiva, distractores plausibles) + **E-SeguridadWin** (corrección técnica de enunciados y soluciones).
- No se reconvoca AH-002 (los renders ya fueron validados en el ciclo 3; el cuaderno los reusa sin cambiarlos).

## 2. Chequeos mecánicos
| Chequeo | Resultado |
|---|---|
| ¿Cada ejercicio tiene su respuesta en la sección final? | OK: 7.1/7.2 y todos los 1.x–6.x mapeados |
| ¿Respuestas separadas de enunciados (no debajo)? | OK (sección "Respuestas explicativas" al final) |
| ¿Coherencia con el escenario testigo? | OK; micro-casos nuevos declarados como tales |
| ¿Cada respuesta explica el "porqué", no solo el "qué"? | OK |
| ¿Referencia a la sección de la guía en cada respuesta? | OK |

## 3. Hallazgos (panel a ciegas)

| ID | Sev | Ev | Hallazgo | Veredicto |
|---|---|---|---|---|
| H-23 | S2 | E2 | (E-SeguridadWin) En 4.3 conviene remarcar que "aislar de la red" ≠ "reiniciar"; un lector podría confundir la excepción de ransomware con apagar. | PROCEDE 5-0 (aplicado: la respuesta 4.3 ya lo aclara) |
| H-24 | S3 | E3 | (E-Didáctica) Falta una tabla de autoevaluación / puntaje que oriente al lector sobre su nivel según cuántos resolvió. | PROCEDE 4-1 |
| H-25 | S3 | E3 | (E-Didáctica) Falta una nota sobre que varios ejercicios admiten respuesta correcta con matices (los 🔴 abiertos), para no penalizar redacción distinta a la modelo. | PROCEDE 4-1 |
| H-26 | S3 | E2 | (Lector-novato) El cuaderno no dice explícitamente que se puede resolver sin laboratorio (solo leyendo) y opcionalmente reproducir en él. | PROCEDE 3-2 |
| H-27 | S4 | E2 | (E-Edición) Metadato "Estado: En revisión de mesa" → pasar a Aprobado al cierre. | PROCEDE lote |
| H-28 | S3 | E3 | (Abogado del diablo) El ejercicio 6.2 (DCSync) es 🔴 pero no está declarado como "de escalamiento": el lector novato podría frustrarse. Aclarar que su objetivo es *reconocer y escalar*, no resolver. | PROCEDE 4-1 (la respuesta ya lo dice; se refuerza en el enunciado) |

## 4. Parches
| Parche | Cubre | Cambio |
|---|---|---|
| P-18 | H-24 | Agregar sección "Cómo autoevaluarte" con bandas de nivel |
| P-19 | H-25, H-26 | Nota en "Cómo usar este cuaderno": respuestas modelo (no únicas en los 🔴), y que se puede hacer sin laboratorio |
| P-20 | H-28 | En el enunciado de 6.2, marcar que el objetivo es reconocer y escalar |
| P-21 | H-27 | Estado → Aprobado |

## 5. Verificación
- Existe "Cómo autoevaluarte" con bandas.
- Nota de respuestas modelo + sin-laboratorio presente.
- 6.2 marca objetivo de escalamiento.
- Estado = Aprobado; fences balanceados.
