---
doc_id: BIT-16-C1-R2-02-riesgo
doc_type: voto-de-jurado
title: Voto del juez de riesgo e irreversibilidad — ciclo 1, ronda 2 (por opción)
status: entregado
origin: agent
owner: juez de riesgo e irreversibilidad (REED-16 §9.4; M§4.3)
last_review: 2026-10-28
audience: [presidencia, jurado, cuerpo-auditor]
traces: [Mesa/Ciclo-1/07-Dictamen-Presidencia.md, Ronda-2/00-Boleta.md, Ronda-2/Consulta-*.md, Mesa/Ciclo-1/02-Voto-riesgo.md, M§5.3]
---

# Voto del juez de riesgo e irreversibilidad — ciclo 1, ronda 2

**Función fija:** ¿hay riesgo o irreversibilidad? En cada ítem miro qué superficie de daño le queda al lector que copia la demo (escrituras sin confirmar, cruce de sesiones, fuga de datos, garantías falsas) y si la corrección se puede deshacer.

## 0. Verificación propia (E1, 2026-10-28T13:49-03:00)

`git status --short` en `Lab-Documentos.Documentacion` da `?? PROMPTs/Guides/16-IA-Layer/`, y HEAD es `d05955b`. La guía y la bitácora siguen sin seguimiento. Por eso cualquier corrección de este lote es reversible: el único acto irreversible a la vista sigue siendo el primer commit y push de `OUTPUTs/` a un remoto público (dictamen §2).

## 1. Resultado

**Ningún veto.** Ninguna opción de la boleta implica una corrección irreversible. Hay riesgo real (no irreversibilidad) en tres frentes, que inclinan mis votos: escrituras que nacen del modelo (D6: 10/10 bajas sin confirmar con los dos modelos; sesión serializada alterada ejecuta 77 en vez de 7, PC-13), cruce de sesiones (Singleton, PC-11; caché sin la sesión, PC-02) y garantías falsas publicadas (umbrales, juez como compuerta, comparación de tarea).

## 2. Votos

| Ítem | Clave | Fundamento desde el riesgo |
|---|---|---|
| C1-48 | **A** | Menor superficie: sin servidor HTTP en la demo, la confidencialidad no depende de loopback + `AllowedHosts` + Origin (PC-12: «/mcp sólo lecturas» cubre la integridad, no la confidencialidad). D7 en `Examples/08` con M13 completo enseña lo mismo sin exponerlo en la pieza que el lector copia entera. |
| C1-40 | **B** (en cualquier rama de C1-48) | Sin herramientas de escritura no hay qué ejecutar sin confirmar: D6 da 10/10 bajas sin confirmar con los dos modelos, y la rama A ejecutó un argumento alterado en la sesión serializada (77 por 7, PC-13) y su `RequestId` no es secreto. AH-01 prefiere B; la objeción de evidencia (B sin prueba) cayó con D3. Condición: B1–B4 y la prueba D3 (tipo=5, id=-1 descartados). |
| C1-62 | **B** | Coherente con C1-40 B: toda escritura, alta incluida, la ejecuta la persona; D1 muestra CP inventado 10/10 con el 4b, así que el alta también necesita confirmación fuera del modelo. |
| C1-55 | **C** | Es mi posición de ronda 1: la pieza no agrega escrituras, pero no debe forzar el perímetro. Con mi C1-48 A resuelve B (AyudaRag en `Examples/05`), sin escalada por la regla 4. |
| C1-56 | **C** | Igual criterio: el candidato no escribe; que siga al perímetro evita la escalada del disparador 3. Con C1-48 A resuelve B. |
| C1-38 | **A** | Carpeta agregada fuera del árbol copiado: `diff -r = 0` sobre todo lo copiado sigue siendo una prueba fuerte de la copia literal, y la normalización queda en núcleo, testeable sin modelo. Validación del lado del servidor obligatoria antes del caso de uso (PC-15: el tipo acepta enums no definidos; el largo 60 no se hace cumplir). |
| C1-53 | **A** | Con C1-38 A: copia literal + C1-19, `diff -r = 0` sobre todo lo copiado. Reimplementar el dominio abre divergencias no auditadas con el caso base. |
| C1-67 | **A** | Enseñar la inyección con el campo real (`Localidad.Nombre`), la precondición declarada y M14 da un control verificable; la tasa L va como tasa observada, nunca como control (10/10 repiten el texto inyectado). Una explicación sin ejemplo deja el riesgo sin prueba. |
| C1-72 | **A** | Un umbral sin métrica definida es una garantía falsa que se copia; «no medido» es lo seguro. R-LLM-3d reemplaza al N ≥ 96 basado en un intervalo descartado. |
| C1-61 | **A** | Por `/v1` se pierden `TopK` en silencio y `max_completion_tokens` se ignora (3 pedidos, 57 salidos): en la demo eso es un comportamiento silenciosamente distinto. En los ejemplos, con la tabla de PC-05, queda declarado. |
| C1-64 | **A** | El juez nunca como compuerta: con un juez sin calibrar como criterio de cierre se aprobaría por error. Las cifras de PC-08 quedan como costo medido. |
| C1-42 | **A** | Afirmar una causa no medida (lectura de prompt) es una garantía falsa; el hecho medido (21 GiB del 35b-a3b) y «no se midió» son lo correcto. |
| C1-43 | **A** | P0 12/16 (Wilson [0,51; 0,90]) es una tasa de un pedido: no sostiene «A por defecto». Por diseño no depende del azar del pedido. |
| C1-44 | **A** | Mismo objeto que C1-64: sin juez en la demo y nunca compuerta. |
| C1-45 | **A** | Mismo objeto que C1-61 (mi voto A allí). |
| C1-46 | **A** | Forma documental, reversible; dentro de D-06 evita duplicar el ADR. Lo que importa al riesgo es el contenido de C1-12 A. |
| C1-50 | **A** | El rótulo nuevo declara que ninguno confirma antes de borrar (D6), que es el dato de riesgo que el lector necesita. Condición: «tasa de un pedido, N = 10, una corrida» (PC-10), coherente con mi C1-41 B. El 35b como defecto ata la guía a un servidor que no es del lector. |
| C1-51 | **A** | Bajo demanda, por la mesa, con versión, digest y sondeo previo: reversible y acotado; la concurrencia sin medir queda «no medido» en vez de una cifra prestada de otro equipo. |
| C1-59 | **A** | M13–M15 son los controles de seguridad (MCP, inyección, retorno al modelo); sacarlos deja la demo sin pruebas de lo más riesgoso. Suma la prueba concurrente de M6 (PC-11). |
| C1-71 | **A** | Igual que C1-46. |
| C1-12 | **A** | Es el riesgo más alto del lote y PC-11 lo probó (E1): la sesión B vio y borró lo de A, sin error. El título tiene que decir exactamente eso; B y C lo minimizan. Prueba (a)–(c) con `ValidateScopes` en true y false. |
| C1-37 | **B** | La doble capa cuenta doble los tokens (48 contra 24): una métrica de costo falsa es un riesgo operativo. B conserva los spans de herramientas (trazabilidad de lo que ejecuta el modelo) con el histograma limpio y el acierto contado aparte. C pierde `execute_tool`. |
| C1-37-clave | **A** | PC-02 probó la fuga: sin la sesión en la clave, B recibe la respuesta de A. La opción B depende de clasificar bien cada pedido, y un error ahí es la misma fuga sin prueba que la detecte. Obligatoria con la prueba de dos sesiones. |
| C1-41 | **B** | Publicar 10/10 contra 0/10 como comparación de tarea sería una garantía falsa (PC-10). La corrida vale como tasa de un pedido; para afirmar algo de la tarea hace falta R-LLM-3d y 3e. No bloquea la guía si no hace esa afirmación. |
| C1-49 | **A** | Ubica C donde el lector ve el bucle del agente y rotula que sólo corrió con un doble: no se presenta como probado lo que no se corrió con el modelo. |
| C1-36 | **A** | Redactar secciones de núcleos con S1 abierto produce texto que se copia antes de verificarse; bloquear sólo esas secciones es barato y reversible. |
| C1-01 | **A** | El commit a un remoto público es lo único irreversible: la exclusión del commit no puede cerrar la compuerta, sólo el comando guardado que da 0. El patrón de `<clave-de-cabeceras>` cubre una fuga real de credenciales en el cuerpo (PC-03) a costo cero. |
| C1-14 | **B** | Sigue a mi C1-40 B: sin endpoint de aprobación no hay estado pendiente que forjar. El historial (D1g) es dato de la persona: vencimiento y fuera de los registros. El 404 por sesión distinta se declara como «no es control de acceso». |
| C1-28 | **A** | Origin es un MUST de la especificación MCP 2025-06-18 y el SDK 2.3.0 no lo valida (PC-01, 403 con el middleware). El catálogo único filtrado a lectura evita que una segunda definición exponga una herramienta de escritura. Con mi C1-48 A vive en `Examples/08`; la forma es la misma. |

## 3. Vetos

Ninguno. Nada de lo votado es irreversible mientras `16-IA-Layer/` siga sin seguimiento; la condición del primer commit es el barrido del dictamen §2 más la compuerta C1-01 A.
