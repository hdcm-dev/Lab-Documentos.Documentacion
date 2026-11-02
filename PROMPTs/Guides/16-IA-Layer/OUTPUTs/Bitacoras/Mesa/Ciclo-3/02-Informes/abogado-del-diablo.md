---
doc_id: BIT-16-MESA-C3-02-AD
doc_type: informe-de-panel
title: Ciclo 3 · Informe del abogado del diablo
version: v1
origin: agent (abogado del diablo, núcleo)
last_review: 2026-10-26
traces: [BIT-16-04 v2, BIT-16-MESA-C2-08, BIT-16-MESA-C2-09, informes del ciclo 3 (AH-02, arquitectura, desarrollo, didáctica, edición, operación, QA, requisitos)]
---

# Ciclo 3 · Abogado del diablo

**Objeto**: `04-Plan-De-Integracion.md` (v2). **Mandato**: atacar (a) el tamaño del plan frente al pedido y al servidor medido, (b) las posiciones mayoritarias sobre P-12 y sobre el recorte, (c) las respuestas de la presidencia, si hay evidencia E1/E2 en contra.

## 0. Comprobación propia (E1, 2026-10-26, sin direcciones por R-PRIV)

- `<gestor-de-turnos> estado` lista `[[recurso-modelo-propio]] cupo 1 · en uso 0`, y `<gestor-de-turnos> salud [recurso-modelo-propio]` devuelve `{"version":"0.40.11"}` con `qwen2.5:0.5b@a8b0c5157701` y `qwen3-embedding:0.6b@ac6da0dfba84`, con capacidad de embedding. **DEP-14 está resuelta y rige EMB-B.**
- **Los informes de didáctica (l. 17) y de operación (l. 19-21) dicen lo contrario** («recurso desconocido», rige EMB-C). Los dos se escribieron antes del alta. Todo lo que esos informes votan *por* EMB-C hay que releerlo: la segunda columna «con EMB-C» que pide OP para RV-03 y el argumento de didáctica para sacar PD-2 («queda no ejecutado»). La consolidación no puede contarlos como votos independientes sobre un régimen que ya no es el vigente.

## 1. Posiciones de agenda

| Tema | Mi opción | Fundamento |
|---|---|---|
| RV-03 (tope) | **(a) 4 h, sin subir.** El plan se recorta para que entre, no al revés | El servidor es compartido y, bajo carga, no responde en más de 600 s (Sondeo §0, E1). Desarrollo propone 6 h (l. 27) porque PD-1 sube a 1.900 s. Eso es el plan pidiendo más servidor para sostener su propio tamaño. Con el recorte de H3-AD-02 (PD-6 reutiliza el registro de 11) y H3-AD-03, TURNO-1 vuelve a quedar bajo el 90 % de 4 h incluso con el PD-1 corregido: 13.350 − 1.425 = 11.925 s ≈ 3,31 h |
| H2-054 (recorte de la demo) | **Contra la mayoría (dev/QA: «contra el modelo PD-1, PD-5, PD-6; PD-2-4 sólo cableado»)**: el ahorro real sale de PD-6, no de PD-2-4 | Ver H3-AD-02. La mayoría saca del modelo justo los pasos baratos (3 × K = 240 s, el 1,9 % de TURNO-1) y deja los caros. PD-2, PD-3 y PD-4 pueden quedar como cableado; PD-6 tiene que dejar de ser una corrida aparte |
| H2-056 (fusiones) | F1 no, F2 no, F3 sí (coincido con la mayoría) | Didáctica y QA lo demuestran con E1: el contrato admite un `recurso` por ejemplo (l. 638), y F1 y F2 mezclarían `<recurso-compartido>` con `[recurso-modelo-propio]`. No tengo evidencia en contra |
| P-12 / DEP-15 | **«Cumple» como regla general de estímulo (AH-02, H3-01), pero 05 en la variante intermedia (desarrollo, l. 66), no en la propuesta del plan** | Ver H3-AD-04. «La localidad ficticia Nº n» es un valor inventado, y el prompt del PO (§Reglas) dice «No inventar información». La variante de desarrollo (literales de `*Policy` × provincias de `Catalogos`) cumple la misma función de medición con valores del caso |
| CTX-NUEVA / CTX-EXISTENTE | **Aplicar sólo en 03 §2 y §2 de la guía, con CTX-NUEVA «sin ejemplo»; sin columna nueva en las matrices de cada documento** | No tengo E1/E2 contra la respuesta 2 (encaja en la definición de BIT-16-03 §2). Pero ningún artefacto ejercita CTX-NUEVA (arquitectura l. 55, didáctica l. 57), y edición (ED3-04) muestra que «contexto» ya tiene tres sentidos. Una columna más en cada tabla «Aplicación por escenario» suma palabras al presupuesto de RV-04 para un polo vacío |
| DEP-12 huérfana | Partir la fila (coincido con arquitectura, desarrollo y QA) | E1: una sola mención de `ServerSentEvents` (l. 985), y §F.1 dice que la API no tiene ruta de chat |
| RV-05 (26 OA) | **25: OA-A5 no entra** si no tiene un ejemplo propio en TURNO-1 | Cada OA sin evidencia ejecutada es una promesa de la guía que no se mide |
| RV-01 (casos integradores) | **Ninguno** (lo vigente) | La demo ya es el caso integrador. Uno más duplica la Parte VI |
| RV-04 (palabras) | Topes de la v1, **sin la compensación +625**; lo que no entre sale de la Parte VI (13 ADR) | El PO pidió «iniciar guías» (prompt, §Objetivos). 13 ADR para una guía que inicia es lo primero que sobra |
| RV-11 (juez) | (b′) de AH-02: juez `qwen2.5:0.5b` en el Ollama propio, misma familia declarada | E1 de §0: es lo único montado. Además saca 52 llamadas de `<recurso-compartido>` |
| Dificultad B/I/A | Adoptar el criterio del cuerpo auditor, sin votación extra | No es un costo de construcción |

## 2. Hallazgos

### H3-AD-01 · El plan sigue sobredimensionado frente a lo que pidió el PO · S2 · E2 · confianza 0,7

- **Ubicación**: plan entero; §C (13 ADR, Parte VI), §E (17 ejemplos), §F (7 pasos), §A.3 (26 OA).
- **Afirmación**: el prompt del PO tiene 664 palabras, y su §Objetivos dice «**Iniciar** guías de estudios, ejemplos y demostración práctica». El plan v2 tiene 32.722 palabras (1.236 líneas). Prevé 17 ejemplos, una demo de 7 pasos, 13 ADR, 26 OA, tres turnos y unas 192 llamadas a un servidor que mide unos 4 tok/s. El ciclo 2 dio 57 hallazgos nuevos sobre 63 (90,5 %), lo que no indica convergencia. Cada parche suma texto y el objeto crece.
- **Evidencia**: `wc -w` del prompt y del plan (E1); §Objetivos del prompt (E2); `08-Cierre.md` §1 (E2).
- **Impacto si no se corrige**: el ciclo 3 cierra por `ciclos_max` con un plan que no se construye en 4 h. La guía, que tiene 0 bytes, se escribe sobre una estructura que nadie puede verificar entera.
- **Dirección**: votar un **alcance mínimo de construcción**: TURNO-1 completo, 15 y 16 contra el Ollama propio (RV-11 b′) y TURNO-2 declarado como extensión fuera de la primera entrega. La Parte VI se reduce a las ADR que la demo ejerce. Lo demás queda como deuda declarada en §14.6, que es justo lo que el ciclo 3 tiene que dejar.

### H3-AD-02 · PD-6 vuelve a correr 11 con la misma entrada: 1.425 s de L duplicados · S2 · E1 · confianza 0,85

- **Ubicación**: §E.5 TURNO-1, filas 11 (l. 725) y PD-6 (l. 731); §F.1, fila PD-6 (l. 801); §E.5, «Paso de la demo».
- **Afirmación**: 11 y PD-6 usan la misma entrada («Borrá Resistencia»), son de clase L y hacen 3 llamadas cada uno. El propio §E.5 dice que el humo de un paso es «un registro con dos usos» y que su evidencia de conducta «es la del ejemplo hermano». Aun así, el plan los corre por separado. Lo único que PD-6 agrega (la aprobación entre dos peticiones, con el estado en el circuito) es una garantía de código, y la prueba el cableado sin modelo.
- **Evidencia**: E1 sobre el texto del plan (las tres líneas citadas).
- **Impacto si no se corrige**: el recorte que vota la mayoría ahorra 240 s y deja este doble de 1.425 s. Con eso, el tope de 4 h se vuelve inviable y empuja a RV-03 hacia 6 h.
- **Dirección**: dejar PD-6 en cableado con `--fake`, más una aserción de que la conducta del modelo es la registrada por 11. Lo mismo vale para PD-5 si su ejemplo hermano (08/09) ya registra la llamada H. Contra el modelo, la demo corre sólo PD-1, que es la integración que ningún ejemplo prueba.

### H3-AD-03 · DEP-10 (2.850 s) y la estabilidad son sondas de diseño, no de la guía · S3 · E1 · confianza 0,6

- **Ubicación**: §E.5 TURNO-1 (DEP-10, Estabilidad) y la línea de corte (a)(b).
- **Afirmación**: DEP-10 es la fila más cara de TURNO-1 (23 % del total). El plan ya tiene escrita la salida si falla: `eliminar_localidad(nombre, provincia)` con error si es ambiguo. La línea de corte la saca sólo si el total se pasa del 90 %.
- **Evidencia**: E1 (las filas de la tabla y el punto 1 (b)).
- **Impacto**: se gasta casi una hora del servidor compartido para elegir entre dos contratos, y uno de ellos ya está decidido como alternativa.
- **Dirección**: adoptar de entrada el contrato `(nombre, provincia)` y sacar DEP-10. El handoff mínimo (pregunta C del cierre) queda como deuda declarada.

### H3-AD-04 · P-12: la propuesta del plan para 05 contradice «No inventar información» · S2 · E2 · confianza 0,75

- **Ubicación**: §G.4 P-12; ejemplo 05; DEP-15.
- **Afirmación**: la mayoría (QA l. 77, AH-02, desarrollo para 16 y la siembra) vota «cumple». Para 16, la siembra y las entradas, la defensa vale: esas piezas usan entidades del caso y AH-02 muestra que sin estímulos escritos no hay medición. Para 05 no vale. «La localidad ficticia Nº n» no existe en la ia-db de Movilidad Urbana: es un valor inventado, y además 05 no mide calidad, sólo tiempos de prefijo (desarrollo l. 66). Con un corpus armado con valores del caso se obtiene lo mismo.
- **Evidencia**: prompt del PO, §Reglas, «No inventar información» (E2); §G.4 P-12 (E2); desarrollo l. 66 (E2).
- **Impacto si no se corrige**: un «cumple» en bloque deja asentado que alcanza con rotular para inventar valores. AC-8 no lo detecta.
- **Dirección**: votar P-12 en dos partes: (1) la regla general de estímulo de AH-02 H3-01, con la condición «sólo valores presentes en el caso base o derivados por una regla del caso», y (2) 05 con la variante intermedia. El costo es 0 llamadas.

### H3-AD-05 · Los votos sobre EMB-C de didáctica y operación están desfasados · S3 · E1 · confianza 0,9

- **Ubicación**: didáctica l. 17 y 106; operación l. 19-21, OP3-03 y su posición sobre RV-03 (l. 55-59).
- **Afirmación**: esos dos informes razonan con DEP-14 abierta. El estado E1 de hoy (§0) es otro. Además, el recurso real tiene un modelo de chat (`qwen2.5:0.5b`) distinto del medido en el plan (`qwen3.5:4b`, §E.5). Entonces 02 «contra el Ollama propio» no es comparable con 01, y las clases de t de §E.5 no valen para TURNO-3.
- **Evidencia**: E1 (§0; §E.5, «Datos medidos»).
- **Impacto**: la consolidación cuenta posiciones construidas sobre un régimen que ya no rige. TURNO-3 sigue sin cota de costo (QA l. 49), y el modelo de 02 es otro.
- **Dirección**: la presidencia asienta EMB-B en `08-Cierre.md`. Las posiciones que dependen de EMB-C se tratan como no emitidas. TURNO-3 recibe una tabla propia, con t medido sobre `qwen2.5:0.5b` en DEP-13. 02 declara que el segundo proveedor usa otro modelo.

## 3. Sobre las respuestas de la presidencia (Ciclo-2/09)

- **Respuesta 1**: sin evidencia en contra. La refuerzo: el prompt pone «ejemplos» y «demo» uno al lado del otro.
- **Respuesta 2**: sin E1/E2 en contra de la clasificación. Objeto el alcance de su aplicación (posición de agenda), no la respuesta.
- **Respuesta 3**: quedó superada por los hechos. El gestor cumplió (§0), y por eso corresponde la rama «rige EMB-B».

## 4. Revisado y bien

- La negativa a F1/F2 de H2-056, fundada en el contrato de un recurso por ejemplo (E1).
- La partición de DEP-12, en la que coinciden tres informes con la misma evidencia.
- La reformulación de P-12 como regla general de estímulo (AH-02 H3-01).
