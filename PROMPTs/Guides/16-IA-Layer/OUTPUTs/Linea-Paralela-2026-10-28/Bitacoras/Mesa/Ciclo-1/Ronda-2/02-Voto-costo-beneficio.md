---
doc_id: BIT-16-C1-R2-02-CB
doc_type: voto
title: Voto del juez de costo-beneficio, segunda ronda del ciclo 1
status: entregado
origin: agent
owner: juez de costo-beneficio (REED-16 §9.4)
last_review: 2026-10-28
audience: [relator, presidencia, cuerpo-auditor]
traces: [Ronda-2/00-Boleta.md, Mesa/Ciclo-1/07-Dictamen-Presidencia.md, Mesa/Ciclo-1/02-Voto-costo-beneficio.md, Ronda-2/Consulta-AH-01-seguridad.md, Ronda-2/Consulta-AH-02-formal.md, Ronda-2/Consulta-comparacion-2b-4b.md, Ronda-2/Consulta-definiciones.md, Ronda-2/Consulta-{estación-2}-ollama.md, Ronda-2/Consulta-operacion-telemetria.md, Ronda-2/Consulta-senior-dotnet.md]
---

# Voto del juez de costo-beneficio, segunda ronda del ciclo 1

Función fija: **¿el beneficio justifica el costo?** Voto una clave por ítem (boleta §0.1). Mido el costo en código que se escribe y mantiene, en pruebas, en turnos de modelo en la estación de laboratorio (13–58 s por llamada; 25–70 s por pregunta de `IAyuda`, CAT-OP-07) y en el riesgo de retrabajo o de escalada. No agrego evidencia nueva: me apoyo en las siete consultas de esta ronda y en mi voto de la ronda 1.

**Dependencias.** Mi cadena es C1-48 = A → C1-40 = B → C1-62 y C1-14 siguen a C1-40; C1-55 = B y C1-56 = B (los votaría igual con cualquier rama de C1-48, ver fundamento); C1-38 = A → C1-53 = A; C1-37 = B → C1-37-clave = A; C1-41 = A ↔ C1-50 = A; C1-28 = A → C1-59 = A; C1-61 = A → C1-45 = A; C1-46 = A → C1-71 = A. En C1-62 y C1-14 elijo la opción «sigue al antecedente»: un par incoherente entre aprobación y contrato es lo más caro que puede salir de esta ronda, porque se convierte en escalada (regla 4).

## 1. Bloque del perímetro

| Ítem | Clave | Fundamento |
|---|---|---|
| C1-48 | **A** | PC-01 y PC-09 bajan el costo de escribir MCP, pero no el de cargarlo en la demo. El código de D7, con M13 y el catálogo único, se paga una sola vez igual en `Examples/08`. Si va en la demo, se suma además a la superficie que `Cableado/` verifica en cada corrida, a la autenticación de CTX-PROD y al barrido de la regla de perímetro de todos los dependientes. La afirmación de la guía que necesita D7 como E1 la cubre el ejemplo con el mismo grado de evidencia. CTX-PROTO no pide más que D1–D6. |
| C1-40 | **B** | Es la rama barata con cualquier perímetro, no sólo con A. No tiene almacén de aprobaciones pendientes, endpoint, id aleatorio, vencimiento ni las pruebas D1b y D1h. Su costo extra son B1–B4 y la prueba D3, que se corren con dobles y sin turnos de modelo. AH-01 cerró PC-13 y prefiere B (Consulta-AH-01 §1.2 y tabla final), así que desaparece la objeción de evidencia que dio el 3-2. D6 da 10/10 bajas sin confirmar con los dos modelos (Consulta-comparacion-2b-4b): el riesgo viene de ofrecer la herramienta, y no ofrecerla lo elimina sin costo. |
| C1-62 | **D** | Condicionado a C1-40. Con mi voto (C1-40 = B), da B: la misma protección (nada se escribe sin la persona, y el alta también) con el contrato más chico. Elijo D y no B a secas para que el texto de MI-14 nunca quede en contra de la rama ganadora, porque esa contradicción cuesta una escalada. |
| C1-55 | **B** | Dos adaptadores en la demo hacen pagar el oro dos veces en cada corrida, a 25–70 s por pregunta en la estación (CAT-OP-07). El segundo servidor lee el prompt a unos 107–110 tok/s (Consulta-{estación-2}-ollama), así que la comparación pareada sale más barata en `Examples/05` y se corre una sola vez. La votaría así también con C1-48 = C, porque el costo dentro de la demo no cambia con el perímetro. |
| C1-56 | **B** | El candidato pide un oro, métricas y mantenimiento dentro de la demo. En `Examples/04` cuesta lo mismo una sola vez y con las mismas métricas de C1-24. Completar la fila N6 con lo que la demo cubre de verdad es texto barato. Ninguna consulta cambia esta cuenta. |

## 2. Ubicación de la normalización

| Ítem | Clave | Fundamento |
|---|---|---|
| C1-38 | **A** | Es la síntesis que voté en la ronda 1 («pieza nueva que el adaptador invoca»), pero en la variante que no rompe nada: un archivo, una línea en `PROCEDENCIA.md`, y `diff -r` = 0 sin reescribir el criterio de MI-05. La prueba común exige «piedra» por la herramienta **y** por el endpoint. Con B, el endpoint normal no pasa por el adaptador, así que habría que duplicar la normalización o dejar un camino sin ella. Con C hay que reescribir MI-05 y sostener una excepción en cada verificación. Así queda una sola pieza para los dos caminos, y además sirve como validación del lado del servidor que pide PC-15. |
| C1-53 | **A** | Condicionado a C1-38 A: copia literal, condiciones de C1-19 y `diff -r` = 0 sobre todo lo copiado. Reimplementar el dominio, endurecer H1–H5 y abrir ESC-06 (B) es lo más caro de todo el bloque, y su único disparador (que caiga M2) no se da con ninguna opción de C1-38. |

## 3. Re-registros

| Ítem | Clave | Fundamento |
|---|---|---|
| C1-67 | **A** | PC-14 ya pagó el trabajo caro: la validación de AH-01 y la sonda L ya están hechas. Lo que queda es redacción, la precondición declarada y una prueba M14 en `Cableado/` con cliente falso, sin turnos de modelo. La tasa L entra como tasa observada, sin corrida nueva. A ese costo, un ejemplo concreto del dominio rinde más que la explicación conceptual de B. `Examples/11` sale en las dos opciones. |
| C1-72 | **A** | B pide una corrida R-LLM-3d (K ≥ 10 pedidos, m ≥ 3) dentro del ciclo para fijar un umbral de una métrica que todavía no está definida (P-02). Son muchos turnos de modelo para un número que la demo no usa como compuerta. «No medido» cuesta una línea y es honesto. Reemplazar la cota N ≥ 96 por R-LLM-3d es texto. |
| C1-61 | **A** | PC-05 muestra que la vía `/v1` descarta `TopK`, ignora `max_completion_tokens` (se pidieron 3 tokens y salieron 57) y no deja fijar `num_ctx` por pedido. Ponerla en la composición de la demo agrega una variante degradada que habría que rotular y probar en cada corrida. En 01 y 06, con la tabla de diferencias, el lector aprende lo mismo y se paga una sola vez. |
| C1-64 | **A** | B no cambia la demo, que sigue sin juez, y agrega unos 35 min de segundo servidor por corrida (PC-08), más una calibración que hay que mantener. Como resultado da un k/n que no puede ser compuerta. A enseña el método con las cifras de costo de PC-08, que ya se pagaron. |
| C1-42 | **A** | Es el hecho medido (21 GiB del 35b-a3b contra 5 GB del contenedor) y no cuesta nada. La posición B atribuye una causa que nadie midió con un denso de 7–9B: publicarla tiene costo de corrección después. |
| C1-43 | **A** | La réplica de PC-10 ya está hecha. Reescribir la tensión 1 como tasa de un pedido es texto. Sostener «A por defecto» con un 12/16 de un pedido (B) invita a una refutación que obliga a rehacer la sección. |
| C1-44 | **A** | Mismo objeto que C1-64. Las cifras de PC-08 reemplazan el «no medido» del costo sin correr nada más. |
| C1-45 | **A** | Condicionado a C1-61 A. Es el mismo objeto. |
| C1-46 | **A** | Dentro de D-06 cuesta una sección. Un ADR nuevo necesita número, trazas y referencias cruzadas, y no aporta contenido que D-06 no lleve. El contenido obligatorio sale de C1-12. |
| C1-50 | **A** | Condicionado a C1-41 A. El rótulo nuevo dice lo que midió la comparación sin pedir otra corrida. Cambiar al 35b-a3b (B) obliga a volver a medir todo, y PC-07 no lo separa del 4b, que además es unas 4 veces más rápido: más costo y ningún beneficio medido. |
| C1-51 | **A** | Acotado a lo que ya rindió (P-03, P-07, el juez y los prompts largos), con versión, digest y sondeo hechos. B amplía el compromiso a la concurrencia y al contexto grande, que nadie midió todavía ahí: es trabajo nuevo sin una afirmación de la guía que lo necesite. |
| C1-59 | **A** | Condicionado a C1-28 A. Las sumas son configuración y pruebas con dobles. La prueba concurrente de M6 (PC-11) se corre sin modelo y cierra un cruce probado E1. Quitar M13–M15 (B) ahorra poco y deja huecos ya medidos. |
| C1-71 | **A** | Condicionado a C1-46 A. Es el mismo objeto. |

## 4. Precisiones

| Ítem | Clave | Fundamento |
|---|---|---|
| C1-12 | **A** | Corregir el título y dos frases de P-12 es texto. La prueba (a)–(c) se corre con la clase real y dos sesiones, sin modelo. B y C publican una frase que PC-11 ya refutó con E1, y eso obliga a corregir después en la guía publicada, que es lo más caro. |
| C1-37 | **B** | En la ronda 1 voté «adoptar la doble capa si da las dos señales». La da, pero cuenta doble los tokens en cada fallo de caché (48 contra 24, PC-02), y el histograma de tokens es justamente la medida de costo de M8. Corregirlo con advertencias y contadores aparte cuesta más que B. B da spans de herramientas, un histograma limpio y un `Counter<long>` de pocas líneas. Pierde sólo el span del acierto, que el contador ya cuenta. C no muestra las herramientas, que era lo que motivó reabrir el orden. |
| C1-37-clave | **A** | Condicionado a C1-37 B, aunque vale en cualquier orden. Es una línea (`CacheKeyAdditionalValues = [SessionId]`), la caché por scope que ya pide P-12 y una prueba de cableado sin modelo. B saca la caché de los pedidos con herramientas, que son los caros, y pierde el beneficio que justifica tener caché. |
| C1-41 | **A** | Condicionado a C1-50 A. La corrida ya está pagada y el rótulo de C1-50 A declara su alcance («N = 10, una corrida»). B exige K ≥ 10 pedidos × m ≥ 3 semillas × 2 modelos: decenas de horas de estación para una comparación de tarea que la guía no necesita publicar. C repite la misma corrida para medir la pared, que no es una afirmación de la guía. |
| C1-49 | **A** | Ya está aplicada por P-24: no tiene costo de cambio. La sección de agentes es el lugar de C, y con la demo mínima no hace falta un agente de MAF en la demo. Mover C (B) o recortarla (C) implica redactar de nuevo una sección ya escrita. |
| C1-36 | **A** | Cambio mi voto de la ronda 1. Con PC-02 corrida, verificar P-03 cuesta poco (C1-37). Redactar ahora las secciones de N0b y N5 §4.2 sobre un núcleo con S1 abierto se arriesga a reescribirlas cuando se aplique el parche. Esperar el parche cuesta menos que el retrabajo. El resto de la redacción no queda bloqueado. |
| C1-01 | **A** | El patrón de `<clave-de-cabeceras>` es un grep más sobre capturas que ya existen y hoy da 0 (PC-03). Cuesta casi nada y cubre una fuga de credenciales irreversible apenas haya un commit. En la ronda 1 dejé abierta la exclusión del commit como cierre. El dictamen §2 la cierra (barrido como condición del primer commit), así que C ya no tiene beneficio. |

## 5. Suspensos parciales

| Ítem | Clave | Fundamento |
|---|---|---|
| C1-14 | **C** | Condicionado a C1-40. Con mi voto (C1-40 = B), da B: sin endpoint de aprobación ni almacén pendiente en la demo, el contrato de la rama A va una sola vez a `Examples/07`. Lo único que suma la rama B es el vencimiento del historial y su exclusión de los registros (D1g), que es configuración. Elijo C por la misma razón que en C1-62: el contrato no puede quedar en contra de la rama ganadora. |
| C1-28 | **A** | Con mi C1-48 = A, M13 se aplica en `Examples/08`. El middleware de Origin ya está escrito y probado (403, PC-01), y la especificación MCP 2025-06-18 lo exige. Dejarlo afuera (B) ahorra unas líneas y enseña un servidor que no cumple la especificación. El catálogo único (PC-09) es más barato de mantener que las dos definiciones de B y C: una sola fuente de herramientas, sin divergencia. C paga esa duplicación sin beneficio. |

## 6. Nota para el cuerpo auditor

En esta ronda, de mis votos, sólo consumen turnos de modelo los que ya se pagaron (PC-07, PC-08, PC-10, PC-14 y la comparación 2b/4b). Los parches que se aplican desde estas claves son texto, compilación o pruebas con dobles. Pido que la aplicación lo declare en turnos (M§4.4) y que no abra corridas nuevas por los ítems donde voté contra investigar (C1-72, C1-64, C1-41).
