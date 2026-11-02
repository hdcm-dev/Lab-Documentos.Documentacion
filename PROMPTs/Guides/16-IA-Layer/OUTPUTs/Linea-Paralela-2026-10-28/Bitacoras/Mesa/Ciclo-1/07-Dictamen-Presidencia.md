---
doc_id: BIT-16-C1-07
doc_type: dictamen-de-presidencia
title: Dictamen de la presidencia sobre el ciclo 1
status: vigente
origin: agent
owner: presidencia de la corrida
last_review: 2026-10-28
audience: [mesa, redacción, relectura integral]
traces: [Mesa/Ciclo-1/02-Revision-Homogeneidad.md, Mesa/Ciclo-1/05-Aplicacion.md (D-1, D-2, D-5, D-6, D-7), Mesa/Ciclo-1/06-Plan-De-Redaccion.md §8]
---

# Dictamen de la presidencia sobre el ciclo 1

## 1. Excepción de P-01 a «sólo agregado» (deuda D-1)

**Se acepta.** R-PRIV es una restricción dura del contrato y le gana a la convención de «sólo agregado», que es una regla de forma de la bitácora. La redacción in situ que hizo P-01 (40 líneas en 13 archivos) queda firme y no se restaura. Alcance: sólo para borrar datos que R-PRIV prohíbe. Ninguna otra corrección puede usar esta excepción para reescribir texto de la bitácora.

## 2. Identificadores de equipos y contenedores en la bitácora (deuda D-2, C1-39)

- **Guía, `Examples/` y `Demos/`:** cero. Ahí rige la compuerta R-PRIV ampliada a nombres de equipos y contenedores del laboratorio (opción A de C1-39), porque van al repositorio público.
- **Bitácora:** se permiten mientras no se commitee, que es la convención vigente («sin commit»). Son contexto operativo necesario para retomar el trabajo, como en `Reanudar.md`. Antes de cualquier commit de `OUTPUTs/`, la presidencia exige un barrido de redacción, y ese barrido es la condición del primer commit.

## 3. Boleta y homogeneidad (C1 completo)

La revisión de homogeneidad está bien fundada. El 93 % de votos 5-0 viene de una boleta mal diseñada por la presidencia: en contradicciones y criterios MI, PROCEDE quería decir «hay que resolverlo», y la decisión real quedaba en la columna de opción. Se dispone lo siguiente:

1. Se abre una **segunda ronda del ciclo 1, votando la opción**, sobre los ítems de §5 de la revisión: el bloque del perímetro (C1-48 → C1-40/C1-62 con PC-13 cerrada → C1-55, C1-56) y la ubicación (C1-38 → C1-53).
2. **Se re-registran** como NO_PROCEDE de la propuesta, con la alternativa adoptada, los ítems C1-67, C1-72, C1-61 y C1-64. Con la opción que ganó se re-registran C1-42, C1-43, C1-44, C1-45, C1-46, C1-50, C1-51, C1-59 y C1-71. La segunda ronda también revisa las precisiones pedidas: C1-36, C1-12, C1-37, C1-41, C1-49 y C1-01.
3. Antes de votar, las preguntas C (PC-01…PC-15) se resuelven como **consulta dirigida** a los especialistas que ya están en el panel, con experimentos cuando hagan falta. No es una convocatoria nueva.
4. Desde ahora, en todo ciclo, la boleta de contradicciones y criterios MI vota la opción, y el umbral de 80 % de M§9 se mide sobre la opción.

## 4. Ollama en estación 2 (MI-03, PC-07, PC-08)

Se autoriza a levantar un Ollama en contenedor en estación 2 (15 vCPU, 38 GB) para lo que estación 1 no cubre. Ya estaba previsto en `Reanudar.md` §3 como extensión de cómputo, y es reversible. Debe medirse con el mismo `sondeo.py`, sin escribir su dirección (R-PRIV), y registrarse como un segundo servidor de prueba. La guía lo menciona sólo como «una estación de laboratorio con más núcleos».

## 5. 2026-10-28 — Elevaciones de la ronda 2 (ELV-01, ELV-02, D-R2-4, D-R2-5)

- **ELV-01 (C1-32), opción A.** El camino fijado por código se llama «workflow», a secas, y el glosario (Anexo C) lo define como en la consulta de definiciones: es el término de la documentación de Microsoft Agent Framework y de la literatura citada. Traducirlo a «flujo fijo» le daría al lector un término que no va a encontrar en ninguna fuente. Siguen rigiendo las formas excluidas: «agentic workflow», «flujo agéntico» y «flujo de trabajo». Se reemplazan todas las marcas `[C: término de C1-32]`.
- **ELV-02.** El segundo servidor de prueba sigue arriba durante la redacción y las pruebas de `Examples/` y `Demos/`, y se usa con el recurso `<recurso-propio>` (cupo 1). Se apaga al cierre, con inventario en `05-Cierre.md`. Toda cifra medida ahí lleva el rótulo de esa estación.
- **D-R2-4.** Se ratifican los siete ajustes mecánicos de minorías `MEJORAR_PLAN`.
- **D-R2-5.** Rige la frase reescrita de la tensión 1 (06-Plan §10.2).
