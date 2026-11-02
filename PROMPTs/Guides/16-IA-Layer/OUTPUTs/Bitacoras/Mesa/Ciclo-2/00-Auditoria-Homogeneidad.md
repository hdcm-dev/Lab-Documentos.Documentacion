---
doc_id: BIT-16-MESA-C2-00
doc_type: auditoria-de-homogeneidad
title: Ciclo 2 · Auditoría de homogeneidad del jurado del ciclo 1 (M§9, «consenso vacío»)
version: v1
status: para la presidencia
origin: agent (auditor de homogeneidad; no vota, no edita lo votado)
last_review: 2026-10-26
traces: [BIT-16-MESA-C1-03, BIT-16-MESA-C1-04, BIT-16-MESA-C1-05, BIT-16-MESA-C1-06, BIT-16-MESA-C1-07, BIT-16-MESA-C1-08, M§3, M§4.3, M§5.3, M§5.5, M§9]
---

# Ciclo 2 · Auditoría de homogeneidad del jurado del ciclo 1

**Pregunta.** El jurado del ciclo 1 votó 94 de 94 ítems por unanimidad (93 `PROCEDE` 5-0, 1 `NO_PROCEDE` 0-5) y aprobó 21 de 24 parches con A5. ¿Hubo un consenso fundado o una aprobación en bloque?

**Diagnóstico: mixto.**

- **Sobre los hallazgos H-xxx el consenso está mayormente fundado.** Los votos de evidencia e impacto citan ubicación y son propios de cada ítem. La re-verificación de anclas del cuerpo auditor (`../Ciclo-1/05-Parches.md` §0.2) confirma los hechos que cambian el diseño, salvo dos premisas (H-004, H-008).
- **Hubo bloque en tres lugares:**
  1. Los jueces de costo-beneficio (J3) y de riesgo (J5) dejaron de aplicar su función objetivo.
  2. En las contradicciones X-xxx la unanimidad tapó soluciones distintas, y el cuerpo auditor terminó eligiendo entre ellas.
  3. En la aprobación, 21 parches pasaron sin fundamento registrado. Entre ellos va uno con una cifra que contradice su fuente, y en la misma ronda esa cifra se objetó en otro parche.

Método: análisis textual de las 470 celdas de voto de `04-Veredictos.md`, leídas contra `03-Consolidacion.md`, `05-Parches.md`, `06-Aprobacion.md` y `07-Aplicacion-Y-Verificacion.md`, y contra el plan v0. Los conteos de §1 son E1: los dio un script de sólo lectura, que se puede volver a correr sobre la tabla de votos (corte por ` | `, prefijo `PROCEDE — ` quitado). Las afirmaciones sobre el plan y los parches son E2 y llevan su ubicación.

## 1. Lo que se midió

### 1.1 Fundamentos duplicados o casi duplicados

| Medida | Resultado | Lectura |
|---|---|---|
| Pares de votos del **mismo juez** en ítems distintos con similitud ≥ 0,60 (difflib) | **28 pares**: J4 18, J5 7, J3 2, J1 1, J2 0 | No hay copiar y pegar literal, pero J4 escribe con plantilla: «Es coherente con H-0xx y con PR-xx. No toca/reabre ninguna DC» (H-002, H-015, H-024, H-035, H-046 con similitud de 0,63 a 0,86 entre sí; PR-02/PR-08 0,83; PR-12/PR-19 0,80) |
| Pares de votos de **jueces distintos sobre el mismo ítem** con similitud ≥ 0,50 | **111 de 940** pares | Lo más alto está en las PR: PR-06 J1/J4 0,84, PR-14 J1/J4 0,83, PR-13 J1/J4 0,79; y H-014 J3/J5 0,82. En esas filas los jueces repiten la dirección del relator en lugar de juzgar desde su función |
| Votos sobre H-xxx que toman ≥ 60 % de sus palabras del «Detalle» del relator | **30 de 315** (J1 12, J4 6, J3 5, J5 4, J2 3) | El anclaje en el relator es bajo en los hallazgos |
| Votos sobre X-xxx que empiezan con «Hay que resolverla» | **28 de 45** | Se votó que la contradicción existe, no cuál opción gana (ver §2.2) |
| Votos sobre PR-xx cortos (< 200 caracteres) que sólo remiten a H-/X- | **50 de 110** | En las propuestas PR el voto es «se adopta con los cambios de H-…»: reenvío, no juicio |
| Votos sobre PR-xx que fundan en «consenso / apoyo / sin oposición» | **24 de 110** | Contar apoyos del panel es tarea del relator, no fundamento de un juez (M§4.2 frente a M§4.3) |
| Uso de `INSUFICIENTE` (M§5.3) | **0 de 94** | Con 9 hallazgos que declaran E4 y varios E4 «razonables» (§1.3), que nunca se usara la salida intermedia es señal de bloque |

**Total**: 28 pares casi duplicados dentro de un mismo juez, 111 pares casi duplicados dentro de un mismo ítem y 28 fórmulas idénticas en las contradicciones, sobre 470 fundamentos.

### 1.2 ¿Cada juez aplicó su función objetivo?

| Juez | Función (M§4.3) | Qué muestran los votos | Veredicto |
|---|---|---|---|
| J1 evidencia | ¿probado al nivel que declara? | Ancla concreta (línea, §, archivo, grep, nuspec) en **53 de 94**; «Verificado» en 10. **Ninguna** de las 22 PR tiene ancla propia, y tampoco H-016–H-019, H-024, H-029–H-032, H-039, H-040, H-050, H-052 ni 5 de las 9 X. Acepta «E4 coherente» o «E4 razonable» (H-009, H-014, H-049) donde M§3 define E4 como **regla externa declarada en el contrato**, no como razonamiento plausible | Aplicada en hallazgos; **ausente en PR**; nivel E4 mal aplicado |
| J2 impacto | si no se corrige, ¿qué pasa? | Consecuencia concreta y propia del ítem en casi todos. Invade la función de J1 en H-032, H-052 y X-006 («Verificado:…»). En H-052, J1 y J2 «verifican» términos distintos de AC-8 («ticket» y «incidente»); los dos están en v0 l. 697, así que no hay error, pero sí duplicación de función | Aplicada; con impactos inflados en H-004 y H-008 (§3) |
| J3 costo-beneficio | ¿corregir cuesta menos que el daño? | «Barato / cuesta poco / es texto / trivial / gratis» en **54 de 94**. Menciona un recurso medible (turnos, horas, llamadas, RAM) en **14 de 94**. Pesa contra la corrección sólo en 9 (p. ej. H-019 «no corresponde gastar en una credencial», H-022 y X-002 «no compensa», X-007 «sin casos integradores»). **Nunca** cuantifica la extensión de la guía, aunque los parches llevan el plan de 14.205 a 23.710 palabras (+67 %, `07-…` §1) y los OA de 19 a 25 | **No aplicada** como balance: describe el costo como bajo por defecto |
| J4 coherencia histórica | ¿reabre una DC? ¿es consistente con el ciclo? | Cita una decisión cerrada o una regla del contrato (DC-, SUP-, R-0n, RD-PO, I-06, MD-) en **45 de 94**. En el resto, la «coherencia» es con otros hallazgos del mismo lote, en formato de plantilla. En la aprobación **no detectó** tres contradicciones que introdujeron los parches: PAR-13 frente a R-04, la regla doble de AC-8 en PAR-19 y la colisión «nivel A/B» que crean juntos PAR-14, PAR-15 y PAR-19. Las tres las encontró una minoría de otra función o la secretaría después de aplicar | **Parcial**: revisa DC-xx en la mitad; falla justo en lo que es su función, la coherencia interna |
| J5 riesgo e irreversibilidad | ¿revertible? ¿qué se rompe? | «Revertible» en **85 de 94**. Nombra algo irreversible sólo en 7 (H-001, H-005, H-019, H-026, H-044, H-053, PR-21). El objeto es texto de plan sin commitear, así que la respuesta «revertible» sale casi por construcción y la función no discrimina. No usó el veto acotado (M§5.3), aunque tampoco había ítems que lo habilitaran | **Degenerada** por el objeto: hay que reformularle la pregunta (§5) |

### 1.3 ¿Pasaron ítems S3/S4 o de evidencia C que no debían?

- **S4**: el lote está vacío (`04-…` l. 138). Correcto.
- **Nivel C**: ningún hallazgo C fundó un parche. El único C (ingenuo H-06) se fusionó en H-008 con un E3 de senior .NET, y eso está declarado. Correcto **en forma**. Pero la premisa del E3 de H-008 la desmintió después la sonda del cuerpo auditor (§3).
- **E4 mal clasificado**: el relator rotula E4 en H-007, H-009, H-014, H-044, H-047, H-049, H-050, H-053 y H-060. En H-053 (R-PRIV de la reedición) y H-060 (contrato l. 106) el E4 es legítimo. En **H-009, H-014, H-047 y H-049** lo que se cita es una omisión o una contradicción interna del plan (eso es E2) o un razonamiento sin regla externa (eso es C). J1 los dio por buenos con «E4 coherente», «E4 razonable» y «E4 suficiente». El fondo de H-047 (diagrama de §A.4 frente a aristas de §F.3) es E2 y se sostiene. H-009 y H-049 son omisiones con decisión abierta: E2 a lo sumo. Ninguno cae, pero el nivel declarado no es el que se probó.
- **S3 que se trataron como S2**: no hay. Sí hay **S2 inflados** (H-004 y H-008, §3).

### 1.4 Ítems de costo alto que nadie objetó en el jurado

| Ítem | Costo que no se pesó | Evidencia |
|---|---|---|
| H-001 | J3: «cuesta las mismas llamadas». PAR-15 suma además «estabilidad, 3 repeticiones en 8 ejemplos (24)» al nivel A | `05-…` l. 658–664 |
| H-021 / PR-03 | El nivel A da 8,0 h pesimistas contra un tope de 4 h. El tope y t = 60/200 s son **[criterio propio]** del cuerpo auditor y el jurado nunca los votó. Lo objetaron recién en la aprobación J1 y J3 (3-2), y lo arregló la secretaría (AJ-02, AJ-03) sin voto | `05-…` PAR-15; `06-…` §2 |
| H-026, H-060 | J3: «re-medir con embeddings sale barato (0,6B)». Depende de un Ollama propio que hoy **no es recurso del gestor** (DEP-14) y que compite con `build` en una máquina al límite (R-02); además está atado a ESC-001 sin respuesta | `05-…` PAR-15 último párrafo; `08-Cierre.md` ESC-001 |
| H-011 | La «sonda previa» multiherramienta sobre Qwen consume turnos de `<recurso-compartido>` que no se cuantificaron | `04-…` l. 40 |
| H-035 / PR-14 | Los OA pasan de 19 a 25 y §15 a 25 ítems. Nadie pesó la extensión. Los OA de las preguntas guía los asignó la secretaría (AJ-05) | plan v1 l. 103–127; `07-…` AJ-05 |
| H-040 | El presupuesto de 43.700 palabras para la guía lo fijó PAR-05 como **[criterio propio]**. El jurado votó que hace falta un presupuesto, no ese número | plan v1 l. 361 |
| H-041 | Diez plantillas comentadas en el Anexo A: extensión no estimada | `07-…` §3 PAR-05 |

## 2. Dónde la unanimidad no era unanimidad

### 2.1 Aprobación sin fundamento registrado

`06-Aprobacion.md` registra 21 parches A5-M0-N0-E0 con la columna de objeciones en «—» y sin una línea de fundamento por juez. M§5.3 dice que «un voto sin fundamento no cuenta para el quórum». Si se aplica la misma regla a la mesa de decisión de M§5.5, esos 21 resultados no son verificables.

La prueba de que hubo bloque está en el propio lote. **PAR-10 se aprobó A5 con el mismo rango «11 a 200 s» en §12.7** (`05-…` l. 454) que el juez de evidencia objetó en PAR-15 (l. 658) por contradecir N3b X3 (474,7 s) y el Sondeo §0 (más de 600 s). El mismo juez aprobó una cifra en un parche y la objetó en otro. La secretaría lo corrigió en los dos lugares (AJ-02).

### 2.2 Contradicciones con soluciones divergentes y voto 5-0

| X | Lo que propusieron los jueces | Lo que aplicó el cuerpo auditor | Problema |
|---|---|---|---|
| X-007 | J2: derivar §15 de los OA **y agregar algunos casos integradores**. J3: **sin** casos integradores. J4: casos integradores **optativos**. J1 y J5 no eligen | PAR-02: «sin casos integradores nuevos (costo-beneficio y coherencia)» | Atribuye a J4 una posición que J4 no tomó. Contando bien, queda 1 a favor, 1 en contra y 1 optativo: no hay mayoría por ninguna opción |
| X-008 | J2: calidad no medida **y aciertos entre contexto completo y RAG si cabe**. J4: aciertos entre contexto completo y RAG si es ejecutable. J3 y J5: declarar la calidad no medida | PAR-08 y PAR-14: calidad no medida y **sin variante RAG en 05** («jurado: costo-beneficio, riesgo, coherencia») | Atribuye a J4 la opción contraria a la que propuso. La comparación con RAG que pedían J2 y J4 se eliminó |
| X-002 | J2, J4 y J5 dejan abiertas las dos salidas (Ollama propio por turnos o sesgo declarado). J3: sesgo declarado | PAR-10: sesgo declarado; el Ollama propio queda «no planificado» | Mayoría débil, pero nadie se opone. De prioridad baja |

En las tres, el voto «PROCEDE — hay que resolverla» no decidió la opción. La decidió el cuerpo auditor, que según M§4.4 diseña la corrección pero «no reabre lo votado» (`05-…` l. 14). Cuando lo votado no fija la opción, la elección es suya y no del jurado.

### 2.3 Ajustes que entraron sin voto

AJ-01…AJ-08 (`07-…` §2) cambian texto aprobado. AJ-01 a AJ-04 nacen de objeciones `MEJORAR_PLAN` que, según M§5.5, tenían que volver a auditoría. AJ-05 recorta las preguntas guía de §10 y §12 a 5 y asigna OA. El cierre ya los declara pendientes de ratificación; esta auditoría lo confirma y los incluye en §4.

## 3. Premisas que la sonda posterior desmintió

- **H-004** (S2). El jurado aceptó «`int Habitantes`» desde `N6-Evidencia/sonda-Program.cs:94`. La sonda del cuerpo auditor muestra que en `8fb4c3a` **`LocalidadModel.Habitantes` ya es `int?`** y que `LocalidadRules.HabitantesValidos` rechaza `null` (`05-…` §0.2). El defecto vive en el dossier N6 y en el plan, no en el caso base. Que «D2 y 03 guardan población inventada» (J2) era cierto del plan v0, pero no es un riesgo de retrabajo de la base. La severidad S2 está en duda.
- **H-008** (S2). J2 escribió «la demo rompe el aislamiento» y J5 «fuga entre usuarios, falla grave». La sonda muestra que la web del caso base **no** usa `SessionHeaderMiddleware`: usa `SessionMiddleware` con la cookie `sesion-movilidad` y le pasa `SessionId` al circuito por `<Routes>` («este parámetro es el puente»). El defecto era la **descripción del plan** (§F.5), no un hueco de aislamiento a resolver. El parche (PAR-17) ya se adaptó a la base, pero el impacto votado está inflado.

## 4. Ítems a re-votar en el ciclo 2

Orden por prioridad. «Re-votar» quiere decir con una línea de fundamento por juez, desde su función, y con `INSUFICIENTE` habilitado.

1. **X-007**: no hay mayoría por ninguna opción (§2.2). Votar la opción: con o sin casos integradores en §15.
2. **X-008**: la resolución aplicada contradice a dos de los cinco jueces y le atribuye a J4 lo contrario (§2.2). Votar si 05 o 07 compara contexto completo con RAG cuando es ejecutable.
3. **H-021 / PR-03 (tope de 4 h, t por llamada y línea de corte)**: el número nunca se votó, A pesimista da 8,0 h y AJ-02 y AJ-03 cambiaron el cálculo sin voto. Votar el tope y la línea de corte con el t por ejemplo de AJ-02.
4. **H-040 (cifra de 43.700 palabras)**: se votó la necesidad de un presupuesto, no el número. El plan creció 67 %. Votar el número con costo explícito.
5. **H-035 / PR-14 (25 OA y OA de AJ-05)**: la extensión no se pesó y los OA son criterio de la secretaría. Re-votar con didáctica como perito.
6. **H-004**: la premisa sobre la base es falsa (§3). Re-votar la severidad (propuesta: S3, capa de origen N6).
7. **H-008**: la base ya puentea la sesión al circuito (§3). Re-votar la severidad y el impacto (propuesta: S3, defecto de descripción en §F.5).
8. **H-001**: J3 dijo que cuesta «las mismas llamadas» y PAR-15 suma 24. Re-votar el costo.
9. **H-026 y H-060 (re-medición con embeddings)**: el costo de «barato» depende de DEP-14 (recurso inexistente) y de ESC-001. Re-votar el costo; ESC-001 no se reabre: rige el default B.
10. **H-009, H-014 y H-049**: el nivel E4 está mal aplicado (§1.3). Re-votar sólo el nivel de evidencia (E2 si es omisión citada; si no, pregunta).
11. **X-002**: mayoría débil para «sesgo declarado» (§2.2). Ratificar o abrir la opción de un Ollama propio por turnos.
12. **PR-07**: revisión obligatoria del único `NO_PROCEDE` por el abogado del diablo (M§9). Se espera que se mantenga por RD-PO-1, pero el marco la exige.

## 5. Parches cuestionables

| Parche | Motivo |
|---|---|
| **PAR-10** | Aprobado A5 con el rango «11 a 200 s» en §12.7, contradicho por N3b X3 y el Sondeo §0. La corrección (AJ-02) entró sin voto. Es la prueba más directa de aprobación en bloque |
| **PAR-15** | Aprobado 3-2 con una cifra «medida» que contradice su fuente. El tope de 4 h y t = 60/200 s son [criterio propio] sin voto. Con lo que trae, A queda en 8,0 h pesimistas. AJ-02 y AJ-03 sin ratificar, y las horas siguen sin recalcular hasta DEP-13 |
| **PAR-13** | El default `num_ctx` 8192 contradice R-04 en el servidor compartido. J4 (coherencia) lo aprobó. AJ-01 sin ratificar |
| **PAR-19** | La celda de AC-8 traía dos reglas incompatibles y J4 la aprobó. AJ-04 sin ratificar |
| **PAR-14** (con PAR-15 y PAR-19) | Juntos crean la colisión «nivel A/B» (dificultad del ejemplo frente a turno). Pasó con A5 y la detectó la secretaría después de aplicar. La propuesta T-A/T-B/T-C queda para el ciclo 2 |
| **PAR-02** | Resuelve X-007 contra lo que propuso J4 y se lo atribuye. Lleva los OA a 25 sin estimar la extensión |
| **PAR-08** | Resuelve X-008 eliminando la variante RAG que pedían J2 y J4, y se lo atribuye a «coherencia» |
| **PAR-05** | Fija el presupuesto de 43.700 palabras y diez plantillas del Anexo A como [criterio propio], sin que nadie lo vote |
| **PAR-17** | J1 anunció una «imprecisión menor» sin detallarla (`06-…` §2) y quedó sin identificar. El parche además descansa en un H-008 de impacto inflado. Pedirle a J1 que la explicite |
| **05-Parches.md §Cobertura** | Dice «los 85 ítems PROCEDE tienen parche» y son 93. Ninguno de los cinco jueces lo detectó en la aprobación (lo marcó `07-…` §5). No cambia ningún parche, pero muestra que la cobertura no se revisó |

## 6. Recomendaciones para el jurado del ciclo 2

- **Un juez adversarial** sobre los unánimes S2 (ya previsto en `08-Cierre.md`) que empiece por los ítems de §4.
- **J3 obligado a cuantificar**: llamadas, horas de turno de `<recurso-compartido>` o del Ollama propio y palabras de guía, o «no cuantificable» con motivo. «Barato» solo no funda.
- **J5 con la pregunta reformulada** para un objeto sin commitear: ¿qué se vuelve irreversible **cuando se construya o se publique** (repo público, anclas, datos de la LAN, recurso compartido)?
- **J4 con un chequeo de coherencia** sobre el parche aplicado, no sólo sobre el ítem: términos con dos sentidos y reglas contradictorias en una misma celda.
- **En las X, votar la opción** y no la existencia de la contradicción. Si no hay mayoría por ninguna, `INSUFICIENTE` y segunda ronda (M§5.3).
- **Mesa de decisión con una línea de fundamento por juez** también en los A5.
