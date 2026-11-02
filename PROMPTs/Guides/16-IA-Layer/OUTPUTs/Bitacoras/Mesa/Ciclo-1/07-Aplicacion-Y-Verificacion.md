---
doc_id: BIT-16-MESA-C1-07
doc_type: aplicacion-y-verificacion
title: Ciclo 1 · Aplicación de los parches, verificación y chequeos de coherencia (M§5.6)
version: v1
status: cerrado
origin: agent (secretaría de la mesa)
last_review: 2026-10-26
traces: [BIT-16-MESA-C1-05, BIT-16-MESA-C1-06, BIT-16-04 v1, M§3, M§5.6]
---

# Ciclo 1 · Aplicación y verificación

## 1. Qué se aplicó y en qué orden

- Copia de la v0: `../../04-Plan-De-Integracion.v0.md` (762 líneas, 14.205 palabras), guardada antes de tocar nada.
- Orden de `05-Parches.md` §0.3: capa de origen primero (PAR-21 en `02-Cohesion-Global.md` y `Crear-IA-Layer-Guide-Reedicion.md`; PAR-22 en N6; PAR-23 en N0b), después el plan de arriba abajo (PAR-01…PAR-20) y al final PAR-24.
- Método: cada cambio es un reemplazo exacto de texto, con el bloque tomado **literalmente** de `05-Parches.md` (no transcripto a mano) y una aserción de una sola ocurrencia; si un texto de origen no aparecía exactamente una vez, el script abortaba sin escribir. Ningún reemplazo abortó.
- Resultado: `../../04-Plan-De-Integracion.md` **v1** (1.002 líneas, 23.710 palabras con el changelog), marcado en el encabezado como ESTRUCTURA APROBADA v1, 2026-10-26, ciclo 1.
- Una corrección de la propia aplicación: en PAR-07, la extracción del texto en línea arrastró, en la viñeta «Orden interno» de §4, la instrucción siguiente del parche. Se detectó al revisar la línea y se dejó sólo el texto aprobado.

## 2. Ajustes de aplicación declarados (AJ-01…AJ-08)

Son cambios que el texto aprobado no traía. Se aplican porque (a) corrigen una afirmación que contradice la evidencia (regla R-EVID), (b) resuelven una contradicción que el chequeo de coherencia de M§3 marcaría como S1, o (c) arrastran a la numeración v1 un derivado que el parche listaba «a revalidar» y que, sin tocar, haría fallar su propia verificación. Todos son reversibles (la v0 está guardada y cada ajuste tiene su texto de origen en el script de aplicación) y quedan **sujetos a ratificación del jurado en el ciclo 2**.

| ID | Origen | Dónde | Qué cambia | Fundamento |
|---|---|---|---|---|
| AJ-01 | Objeción minoritaria a PAR-13 (juez de impacto) | §E.1, viñetas «Arnés» y «num_ctx» | `verificar.sh --con-modelo` lee `context_length` de `/api/ps` dentro del turno y exporta `OLLAMA_NUM_CTX`, o aborta; el default 8192 vale sólo para el Ollama propio o el lector, y con `servidor = compartido` sin la variable del arnés el código rechaza la corrida, con prueba de cableado | Sin esto, §E.1 contradice R-04 (§G.2): coherencia, condición 1 de M§3 |
| AJ-02 | Objeción minoritaria a PAR-15 (juez de evidencia) | §E.5 «Datos medidos» y estimación; §12.7 (PAR-10) | El rango «medido de 11 a 200 s» se reemplaza por lo que sí se midió (11–24 s respuestas cortas, Sondeo §8; 474,7 s con 4.441 tokens, N3b X3; más de 600 s bajo carga, Sondeo §0); DEP-13 estima t por ejemplo (t ≈ p/9,4 + s/4) con pesimista ≥ 475 s para 07, 11 y PD-n | R-EVID: la cifra aprobada contradecía la fuente que cita. Verificado en Sondeo l. 201 y N3b l. 235 |
| AJ-03 | Objeción minoritaria a PAR-15 (juez de costo-beneficio) | §E.5, línea de corte 1 | Prioridad dentro de A (PD-1…PD-6 y 07, 08, 09 primero); lo que exceda el tope pasa a «no ejecutado», sin cifras y como deuda | Sin esto, la línea de corte no alcanza el tope que el mismo título promete: contradicción interna |
| AJ-04 | Objeción minoritaria a PAR-19 (juez de impacto) | §F.10, celda de AC-8 | Se borra la oración que excluía «incidente» del patrón que lo incluía; «Línea» sólo cuenta como identificador de código; las ocurrencias que nombran la prohibición van a excepciones | La celda tenía dos reglas incompatibles y la verificación (1) de PAR-19 no podía correrse |
| AJ-05 | Derivados de PAR-03, PAR-05, PAR-08, PAR-11 | §B.1; §C §13 (Fuente); diagrama de §A.2; preguntas guía de §1, §2, §4, §10, §12 y §13 | Quita `IAsistenteDeMovilidad` de §B.1; reescribe la fuente de §13 sin `D-0n`; «CAG» → «prefijo estable» en el diagrama; asigna OA a las preguntas guía que no lo tenían y recorta §10 y §12 a 5 (las de estado de paquete van al Anexo F, según la regla de PAR-05) | Verificaciones de PAR-03 (2) y PAR-11 (1); término canónico de PAR-05 y PAR-08; regla de preguntas de PAR-05. **Los OA asignados son criterio de la secretaría**: los revalida didáctica en el ciclo 2 |
| AJ-06 | Derivados de la renumeración (PAR-14, PAR-16, PAR-20) | §A.2 (ADR-01/02, §8.9, diagrama P4), §C §12 (fuente), §F.1, §F.6, §F.8, §G.2 R-08, §G.4 P-02 | IDs v0 (`D-01`, `D5`, `D1–D7`, `Examples/12`, `Examples/13`, `§5.9`, `§8.7`) pasan a v1 (ADR-, PD-, 05, 10, §5.8, §8.9); la escalera del diagrama de la columna vertebral pasa a «herramienta → workflow → agente» | Verificación de PAR-16 (1) y colisión de IDs (H-044) |
| AJ-07 | Chequeo de coherencia «toda sección tiene fuente y escenario» | Fichas §0, §2, §3, §15 | Se agrega la línea de fuente o de escenarios que faltaba | M§3 adaptado (paso 3 del despacho) |
| AJ-08 | PAR-21 | BIT-16-02 §6, fila S-12 | El artefacto de la convocatoria es `Mesa/Ciclo-1/01-Convocatoria.md` (el `00-Convocatoria.md` previsto no existe) | La fila tenía que apuntar a un archivo existente |

## 3. Verificación de cada parche

«Diferida» quiere decir que el criterio se corre sobre un artefacto que todavía no existe (la guía redactada, `Examples/` o `Demos/`): queda en `capas_a_revalidar` y en los criterios de cierre AC-n. «Criterio adaptado» quiere decir que el criterio literal fallaba sólo por el propio texto aprobado (una negación o una cita de la prohibición), y se corrió en su intención. **Ningún parche se revirtió: 0 regresiones.**

| Parche | Resultado |
|---|---|
| PAR-21 | pasa con AJ-08 (S-12 remite a `01-Convocatoria.md`) · 17 filas S-xx; 0 numeración vieja; 0 «04-Integracion.md» en REED-16 |
| PAR-22 | pasa · nota con 4 viñetas, 1 ocurrencia |
| PAR-23 | pasa · nota, 1 ocurrencia |
| PAR-01 | pasa · (1) criterio adaptado: la única ocurrencia de la frase es la negación dentro del texto aprobado; (2) = 1; (3) = 5 |
| PAR-02 | pasa · 25 filas OA; cobertura OA→ruta con 0 faltantes; §15 con 25 ítems; «siete partes» = 0 |
| PAR-03 | pasa con AJ-05 (quedaba `IAsistenteDeMovilidad` en §B.1) · aristas EP/BZ→PT sin etiqueta = 0; (3) diferida a la construcción |
| PAR-04 | pasa · sin `G4[`; «Agente como grafo» = 0; §B.4 con 7 columnas en las 8 filas; «agencia 3» sólo en PD-6 |
| PAR-05 | pasa en el plan (plantilla, regla, casas, presupuesto, 10 plantillas del Anexo A) · (1)–(4) diferidas a la guía redactada |
| PAR-06 | pasa en el plan · (1)–(3) diferidas a la guía redactada |
| PAR-07 | pasa · «Cambio-De-Proveedor» = 0; recuadro «En este laboratorio» presente; 0 `D-0[12]` en §4 y §5 |
| PAR-08 | pasa con AJ-05 (diagrama de §A.2 decía «CAG» sin calificar) · toda línea con `recall@` dice «hit rate»; 05 sin embeddings |
| PAR-09 | pasa · «si venís de SK» = 5; §9 con 5 preguntas · (1) diferida a la guía (el cuadro vive en §9.1) |
| PAR-10 | pasa · «Escenario construido E3» = 0; §11.5 sólo con menciones negativas de control de acceso; «8 de 10» presente; Anexo B con ASI09 y loopback |
| PAR-11 | pasa · 0 `D-0n` en §13–§14 (tras corregir AJ-05); 0 T1–T7/H1–H5/C1–C8 en §14; ADR-11 y ADR-12 presentes |
| PAR-12 | pasa · sólo PR-7 (NA) y PR-18 (A) no son AC; PR-20 con «CP inválido va en 09» · (3) criterio adaptado: PR-1 y PR-9 citan PR-01 y AH-02, no un H-/X- |
| PAR-13 | pasa · pinning presente; 0 «AIEVAL001 en 15»; 0 rc0 con embeddings · (5) criterio adaptado: las variables viejas sólo aparecen en la frase que las prohíbe · (2), (6), (7) diferidas a la construcción |
| PAR-14 | pasa · 17 filas 01–17; § no decrecientes salvo 14; 05 sin MEVD ni embeddings; 0 «Habitantes = 0»; 12 sin revisor; 08 «dato que no está», 09 «CP 34» |
| PAR-15 | pasa con AJ-02 y AJ-03 · §E.5 presente; llamadas recalculadas desde las M de §E.2: A 140 frente a 144 (−2,8 %), B 91 frente a 91 · (3) diferida al cierre de la construcción |
| PAR-16 | pasa con AJ-06 (quedaban D5 y D1–D7 en §F.6 y §F.8) · PD-1 es lectura · (3) diferida a la construcción |
| PAR-17 | pasa · «cookie del circuito» = 0; «sesion-movilidad» = 2; «sin aprobación en la demo» = 0 · (3) diferida a la construcción |
| PAR-18 | pasa · 0 rc0 en §F.6; `int?` en §F.7 · (3) diferida a la construcción |
| PAR-19 | pasa con AJ-04 · (1) el patrón de AC-8 sobre el plan v1 da sólo las 3 líneas listadas en `Compuertas/rd-po-4.excepciones`; (2) AC-7 sobre `OUTPUTs/` da 0 reales tras redactar un nombre de host en un informe (1 falso positivo: número de versión); (3) = 0; (4) 11 filas |
| PAR-20 | pasa · 0 filas `| D-0n |` y 14 `| DEP-nn |` en §G.3; 0 «no está verificado en ningún dossier»; P-07 y P-10 «Resuelto (ciclo 1» |
| PAR-24 | pasa · fila v1 = 1; frontmatter v1 |

## 4. Chequeos mecánicos de coherencia (M§3 adaptado a la guía)

| Chequeo | Resultado | Cómo |
|---|---|---|
| Toda solicitud S-01…S-17 tiene sección y/o artefacto | **Pasa**: 17 de 17 en la matriz única de BIT-16-02 §6 (PAR-21) | `grep -cE "^\| S-[01][0-9] \|"` = 17 |
| Todo insumo I-01…I-06 tiene sección y/o ejemplo | **Pasa**: I-01 → §9.3, §B.4–§B.5 y ejemplo 14; I-02 → §D PR-1…PR-7 (PR-7 NA con motivo); I-03 → §6, ejemplo 05, §D PR-8…PR-12; I-04 → relectura (PR-15), §0.1, §13; I-05 → §A.4, §8, §9, Anexo B, ejemplos 08, 09, 14; I-06 → RD-PO-1…4, AC-8 y P-12 | conteo de menciones en el plan: I-01 14, I-02 6, I-03 1 + filas PR-8…PR-12, I-04 5, I-05 8, I-06 8. La matriz de BIT-16-02 §6 no tiene fila propia para I-02: queda cubierto por §D (anotado para el ciclo 2) |
| Toda sección del índice §C tiene fuente (dossier §) y escenario N0 | **Pasa después de AJ-07**: §0, §2, §3 y §15 no tenían una de las dos líneas | script sobre las fichas `**§N …**` |
| Todo OA tiene ruta de lectura que pasa por su sección | **Pasa**: 0 faltantes en 25 OA | script de cobertura OA → §0.2 |
| Ningún ejemplo sin criterio de prueba | **Pasa**: las 17 filas de §E.2 tienen oráculo y criterio ejecutable, y modo `--fake` | script sobre §E.2 |
| Ningún término con dos sentidos | **Falla en 1** (nuevo, S3): «nivel A/B» designa a la vez la dificultad del ejemplo (columna «Nivel»: B básico, I intermedio, **A avanzado**) y el nivel de turno de §E.5 (**A obligatorio**, B si queda presupuesto, C sin `<recurso-compartido>`); AC-3b dice «ejemplo de nivel A de §E.5». CAG, D-0n, E3 y PD-n quedaron con un solo sentido | revisión de `grep "nivel A\|nivel B"` y de los glosarios. **No se corrige en este ciclo** (cambiaría texto aprobado de PAR-14, PAR-15 y PAR-19): pasa al ciclo 2 como ítem con propuesta «renombrar los niveles de turno a T-A, T-B, T-C» |
| Barrido RD-PO (I-06): ningún dominio ajeno en ejemplos | **Pasa**: `Examples/` y `Demos/` están vacíos y la guía tiene 0 bytes; en el plan v1, 3 ocurrencias (l. 26, 822, 851), las tres nombran la prohibición y están listadas en `../../Compuertas/rd-po-4.excepciones` | patrón de AC-8 (texto y código) |
| Barrido RD-PO sobre el resto de la bitácora | **Informativo, deuda**: hay dominios ajenos en snippets o salidas de Sondeo-Entorno, N2, N5, `N4-Evidencia/compilecheck/Program.cs` y en el informe de QA que los cita. Ninguno está en la guía ni en los ejemplos. R-06 manda reescribirlos al redactar; quedan listados como pendientes (no como excepciones) en el archivo de excepciones | mismo patrón |
| Barrido de IPs privadas y hosts (R-PRIV, AC-7) sobre `OUTPUTs/` | **Pasa después de una redacción**: el informe de desarrollo citaba el nombre de un runner de la LAN; se reemplazó por «[nombre de host del laboratorio, redactado por R-PRIV en el cierre del ciclo 1]». El único acierto restante del patrón de IP es un número de versión de ensamblado en N5 (falso positivo). La lista de hosts usada no se escribe en el repo | patrones de AC-7 + lista de hosts fuera del repo |

## 5. Observaciones para el ciclo 2

- `05-Parches.md` dice «los 85 ítems con veredicto PROCEDE (63 hallazgos, 9 contradicciones, 21 propuestas PR)»: la suma es 93. Con PR-07 son 94 ítems votados (93 PROCEDE y 1 NO_PROCEDE). El error es de conteo y no cambia ningún parche.
- El juez de evidencia mencionó una imprecisión menor en PAR-17 sin detallarla; no se identificó ninguna verificable.
- Las listas fuera del repo que exigen AC-7 (`$R_PRIV_LISTA`) y AC-8 (`$RD_PO_LISTA`) todavía no existen; hay que crearlas antes de la construcción.
- AC-7 necesita un mecanismo de excepciones para falsos positivos (números de versión de ensamblado de cuatro componentes, como la versión diez-once-cero-cero).
