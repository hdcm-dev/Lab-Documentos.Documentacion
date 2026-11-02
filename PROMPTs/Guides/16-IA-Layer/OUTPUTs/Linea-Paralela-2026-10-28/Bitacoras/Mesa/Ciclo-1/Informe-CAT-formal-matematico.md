---
doc_id: BIT-16-C1-INF-CAT-formal-matematico
doc_type: informe-de-especialista
title: Informe del especialista Formal / matemático — ciclo 1
status: hecho
origin: agent
owner: especialista Formal / matemático (panel del ciclo 1)
last_review: 2026-10-28
audience: [relator, jurado, presidencia de la mesa]
traces: [BIT-16-C1-00 §5.2, BIT-16-00 §3, BIT-16-04 §1 §3 §5 §6.3, Nucleos/N0b, Nucleos/N3, Nucleos/N3b, Nucleos/N5, Nucleos/N6, M§8]
---

# Informe del especialista Formal / matemático — ciclo 1

**Pregunta del mandato** (BIT-16-C1-00 §5.2): ¿cada definición, umbral, cuantificador y tasa de los borradores está enunciado sin ambigüedad, y no afirma más de lo que su N permite?

**Límites que respeté.** No juzgo si el método de evaluación es el correcto: eso es de AH-02. Tampoco juzgo la corrección técnica de .NET, la seguridad ni la forma. Trabajé a ciegas: no leí otros `Informe-*.md` del ciclo. Lo que vi fuera de mi mandato va en §4 como solicitud de convocatoria.

**Evidencia producida** (en `evidencia-CAT-formal-matematico/`, sin dirección ni puerto del servidor, por R-PRIV):

| Id | Qué | Nivel | Archivo |
|---|---|---|---|
| F-S1 | Sonda .NET 10.0.14 (SDK 10.0.403, contenedor `mcr.microsoft.com/dotnet/sdk:10.0`, recurso `build`). Usa la **copia literal** de `LocalidadRules.cs` de ApiWeb en `59399ba` y `CommunityToolkit.VectorData.InMemory` 1.0.1. Prueba: CP con dígitos no ASCII, `Habitantes`, nombre de más de 60 caracteres y sentido del `Score` con vectores fijos | E1 | `F-sonda-reglas-y-score-Program.cs`, `.csproj`, `-salida.txt` |
| F-X3a | Tercer punto de X3: `qwen2.5:0.5b`, Ollama 0.40.11, mismo corpus sintético, `num_ctx` 6144 y `num_ctx` 4096 con `num_predict` 64, por turno de `<recurso-compartido>`. La predicción se escribió antes de correr | E1 | `F-x3-tercer-punto.py`, `-salida.jsonl` |
| F-X3b | Prompt de 120 líneas (3682 tokens), que cae entre contexto/2 y contexto, con `num_ctx` 16384 y 4096 | E1 | `F-x3-entre-mitad-y-ventana.py`, `-salida.jsonl` |
| F-W | Intervalos de Wilson al 95 % para las tasas citadas (cálculo en `python3`; el método es estándar, la cifra es aritmética) | E1 (aritmética) | este informe, §1 |
| F-D | Fuentes vigentes, consultadas el 2026-10-28. `DistanceFunction.CosineDistance`: <https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.vectordata.distancefunction.cosinedistance> (updated_at 2026-10-16): «CosineDistance = 1 - CosineSimilarity. 2 means vectors are opposite. 1 means vectors are orthogonal. 0 means vectors are identical.» `trec_eval` `m_recall.c` y `m_success.c`: <https://github.com/usnistgov/trec_eval> (rama main): «Recall (relevant retrieved / relevant) measured at various doc level cutoffs» frente a «Success (a relevant doc has been retrieved) measured at various doc level». MRR: <https://en.wikipedia.org/wiki/Mean_reciprocal_rank>: «If none of the proposed results are correct, the reciprocal rank is 0». Ficha del modelo: <https://huggingface.co/Qwen/Qwen3-Embedding-0.6B>: «Embedding Dimension: Up to 1024, supports user-defined output dimensions ranging from 32 to 1024», MRL Support: Yes. El libro de Manning (nlp.stanford.edu) **no respondió** tampoco hoy (ECONNRESET), igual que en N3 §8.7 | E4 | — |

---

## 1. Hallazgos

### CAT-FO-01 — «Falso aceptado» tiene dos definiciones incompatibles, y la métrica de C2 no tiene una definición estable sobre la cual fijar umbral

- **Capa de origen**: núcleo (N0b), arrastrado a la integración (R-C20, MI-24).
- **Ubicación**: `Nucleos/N0b-Producto-Datos-Y-Perfil.md` L105 (§3.1.3) frente a L561 (reparación R-C20); `04-Integracion.md` §1 X2, §3.2 R-C20, §5 MI-24.
- **Severidad**: S1, por contrato: es una contradicción entre secciones sobre el mismo término.
- **Evidencia (E2 + E1)**.
  - N0b L105 define: «el error caro es el **falso aceptado**, un valor fuera de catálogo que entra (N6 T2, H3–H5)».
  - N0b L561 y R-C20 llaman «falso aceptado» a «2 de 10 con `qwen3.5:4b` si no hubiera confirmación (X2 D1)». Pero en X2 D1 el campo es `CodigoPostal`, que **no tiene catálogo**: se valida por formato (`^\d{4}$`, `LocalidadRules.cs`). Los 2/10 son las semillas 2 y 4, donde el modelo inventó «3400»; las otras 8 inventaron «34000»/«34089», que la regla rechaza (`X2-escrituras-qwen3.5-4b.jsonl`). El evento medido es entonces «valor **inventado** que satisface la regla de formato», no «valor fuera de catálogo que entra».
  - Además, el 2/10 es **condicional a un sistema que no existe**: «si no hubiera confirmación». Con R-C02 la métrica pasa a «propuestas que la persona tuvo que corregir». Esa es una tercera magnitud, que se mide sobre la persona y no sobre la regla, y que tiene otro denominador.
  - Las tres definiciones conviven en §1, §3.2 y §5. MI-24 pide votar «el umbral de la métrica de C2» sin decir cuál de las tres.
  - Sobre el N: las 10 corridas son **un único pedido** con semillas 1..10 a T 0.7. Wilson 95 % de 2/10 = [0,06; 0,51]. Esto sostiene «ocurre», no una tasa.
- **Impacto si no se corrige**: la guía enseñaría un umbral de una métrica que cambia de significado entre secciones. Y el lector aplicaría un «20 %» que es la frecuencia de una semilla elegida, sobre un pedido, en un sistema sin confirmación.
- **Propuesta de dirección**:
  1. Separar y nombrar tres eventos con su denominador: (a) valor fuera de catálogo que entra (campos con catálogo: provincia, medios, frecuencia, motivo); (b) valor inventado que pasa la regla de formato (CP); (c) propuesta corregida por la persona antes de confirmar.
  2. Atar «falso aceptado» a uno solo.
  3. Citar X2 D1 como «2 de 10 semillas de un pedido; existencia del caso (b)», sin porcentaje.
  4. Votar el umbral de MI-24 sólo sobre la métrica (c), y declarar que hoy no hay N para fijarlo (ver §3, MI-24).

### CAT-FO-02 — EA-6 declara N = 5 para las vías A y B, pero la vía A corrió una vez, y la regla «A por defecto» de MI-01 se apoya en esa comparación

- **Capa de origen**: integración (borrador A).
- **Ubicación**: `04-Integracion.md` §1 fila EA-6; §2 tensión 1 («con el 4b, B se saltea la recuperación 2/5 y la corrida completa contesta de memoria»); §5 MI-01 (respaldo «EA-5, EA-6 (N chico)»).
- **Severidad**: S2 (salida de modelo presentada como determinista: «A acierta y cita» con N = 1).
- **Evidencia (E1, sobre `Integracion-Evidencia/A-arquitectura/exp-capas/salida-real.txt`)**.

  | Bloque | Qué mide | N real |
  |---|---|---|
  | `[R3]` | Vía A | **una** corrida |
  | `[R4]` | Elección de herramienta de la vía B, una sola pregunta de requisitos | 5 semillas (`Seed=i`, T 0.7): 3/5 piden `buscar_requisitos` |
  | `[R4]` | Pregunta de conteo | 5/5 |
  | `[R5]` | Vía B completa (la que «contesta de memoria») | **una** corrida |

  Wilson 95 %: A 1/1 → [0,21; 1,00]; B 3/5 → [0,23; 0,88]. Los intervalos se superponen casi por completo, así que la diferencia A frente a B **no está medida**. Sí separan, en cambio, 5/5 frente a 0/5 de E-B1 ([0,57; 1] frente a [0; 0,43]). Por eso la frase de §1, «las tasas separan modelos y vías», vale para modelos y no para estas vías.
- **Impacto si no se corrige**: la guía presentaría «A por defecto» como respaldado por una medición, cuando lo sostiene el diseño (EA-5: toda pregunta necesita el corpus). Un N = 1 de la vía A no permite decir que «acierta».
- **Propuesta de dirección**:
  1. Corregir la fila EA-6: «A: N = 1; B, elección: N = 5 semillas de una pregunta; B, completa: N = 1».
  2. Reescribir la tensión 1 y MI-01 para que la regla A/B/C se sostenga como **criterio de diseño**, con EA-6 como ilustración de que «B puede no recuperar» (existencia).
  3. Si se quiere una comparación, que sea de la misma pregunta con el mismo N en las dos vías, con el criterio escrito antes (método, a cargo de AH-02).

### CAT-FO-03 — recall@k está definido como hit rate@k, MRR no tiene corte ni caso «ninguno», y el corpus real rompe la coincidencia que N3 da por buena

- **Capa de origen**: núcleo (N3), heredado por MI-08, P-05 y el conjunto de oro de C4 (R-C09).
- **Ubicación**: `Nucleos/N3-RAG-En-NET.md` L128 (§2.8), L129, L363 (P8), L452 y L626 (§8.7 abierto); `04-Integracion.md` R-C16, MI-08, R-C09, P-05.
- **Severidad**: S2. Sostiene un criterio votable (MI-08) y una medición pendiente (P-05).
- **Evidencia (E2 + E4)**.
  - N3 L128 llama recall@k a «proporción de preguntas cuyo fragmento relevante aparece entre los primeros k» y aclara bien que eso es *hit rate@k*. `trec_eval` separa `recall_k` («relevant retrieved / relevant») de `success_k` («a relevant doc has been retrieved»). La coincidencia que N3 reconoce («sólo cuando cada pregunta tiene un único fragmento relevante») **no se cumple en el corpus de la demo**: los 12 enunciados (EA-6 `[1]`) tienen `LocalidadPolicy.RequisitoDelNombre` y `EncuestaPolicy.RequisitoDelNombre`. Una pregunta como «¿cuántos caracteres lleva el nombre?» tiene dos relevantes, y entonces recall@1 ≤ 0,5 mientras que hit@1 puede ser 1.
  - R-C09 manda incluir en los casos de C4 «consultas no respondibles». Para ellas |relevantes| = 0: el recall queda indefinido (`trec_eval` devuelve 0), lo mismo que el hit y el rango recíproco. Si entran al promedio, bajan las tres métricas por construcción.
  - N3 L129 define MRR como «promedio de `1/rango` del primer resultado relevante». No dice el corte k ni que el rango recíproco vale 0 si no aparece ningún relevante (Wikipedia, MRR).
  - Con 12 documentos y un solo relevante, el hit@k de una recuperación **al azar** es k/12: con k = 5 da 0,42. «k = 3–5» (L363) es el 25–42 % del corpus, y recall@k no decrece al subir k: con k = 12 vale 1 para cualquier modelo. «Se sube k sólo si el recall lo pide» no tiene regla de parada.
- **Impacto si no se corrige**: MI-08 y P-05 producirían cifras que no son comparables entre sí ni con la literatura, y que en un corpus de 12 pueden parecer buenas sin superar el azar.
- **Propuesta de dirección**:
  1. Definir en el glosario (Anexo C) tres métricas por consulta con su fórmula: hit@k (alguno de los relevantes en top-k), recall@k (relevantes en top-k / relevantes) y RR@k (1/rango del primer relevante si rango ≤ k; si no, 0). MRR@k es su promedio.
  2. Declarar que las consultas sin relevante se excluyen de esas métricas y se evalúan aparte (abstención).
  3. Reportar k y la línea de azar k/|corpus| junto a cada cifra.
  4. Enunciar k = 3–5 como punto de partida con su criterio de parada (p. ej., el menor k cuyo hit@k ya no cambia), rotulado como criterio propio.
  5. §8.7 de N3 se puede cerrar con la fuente E4 de `trec_eval`, sin esperar a Manning.

### CAT-FO-04 — Las reglas de dominio enunciadas («4 dígitos», «entre 3 y 60», «del catálogo») afirman más que el código, y el corpus de C4 las enseña como verdad

- **Capa de origen**: pedido / caso base (la `*Policy` de ApiWeb), tomado sin matiz por los núcleos (N6 §1.1, N3 snippets) y por el corpus de C4.
- **Ubicación**: `Nucleos/N6-Caso-Movilidad-Urbana.md` L43 («`CodigoPostal` (4 dígitos), `Habitantes` (≥ 1)»), L47, L514; `Nucleos/N3-RAG-En-NET.md` L248–249; corpus de 12 enunciados (EA-6 `[1]`); `04-Integracion.md` §6.3 M2.
- **Severidad**: S2 (recomendación sin el contexto que la delimita). La parte de habitantes está bien (ver §2).
- **Evidencia (E1, F-S1, sobre la copia literal de `LocalidadRules.cs` en `59399ba`)**.

  | Regla enunciada | Lo que muestra F-S1 |
  |---|---|
  | «4 dígitos» | `CodigoPostalValido` acepta `٣٤٠٠` (árabe-índico), `３４００` (ancho completo) y `३४००` (devanagari). Acepta `" 3400 "` y `"3400\n"` porque aplica `Trim()`. Acepta `"0000"` |
  | «Entre 3 y 60 caracteres» | `NombreValido` acepta 61 y 200 caracteres: es H2 de la ia-db F03, que el caso base ya documenta. `HasMaxLength(60)` no rige en SQLite |
  | «Una de las provincias del catálogo» | La regla sólo exige no vacío (H1) |

  La regla real de CP es «exactamente cuatro caracteres de la categoría Unicode Nd, después de `Trim()`». El `\d` de .NET sin `RegexOptions.ECMAScript` no es `[0-9]`. «4 dígitos» es ambiguo, y `RequisitoDelNombre` y `RequisitoDeLaProvincia` enuncian límites que la API no impone.
- **Impacto si no se corrige**:
  1. La ayuda C4 (contexto fijo o RAG) le diría a la persona límites que el sistema no hace cumplir, y el conjunto de oro puntuaría esa respuesta como correcta.
  2. La normalización del adaptador (M2) quedaría sub-especificada para el CP, que no tiene catálogo: un modelo que devuelva dígitos de ancho completo pasaría la regla y se guardaría tal cual.
- **Propuesta de dirección**:
  1. Enunciar en la guía cada regla tal como la implementa el código. Para el CP: «4 caracteres que .NET reconoce como dígito decimal, tras recortar espacios; no valida existencia ni rango».
  2. Rotular en el corpus de C4 los dos enunciados que el código no impone (H1, H2) como «política mostrada, no verificada por la API», o excluirlos del conjunto de oro.
  3. Especificar la normalización del CP en el adaptador (a ASCII `[0-9]`, o rechazo).
  4. Con MI-05 (copia sin endurecer), esto queda en el adaptador y en el texto, no en la copia.

### CAT-FO-05 — «Límite = contexto/2 + 2» admite una lectura falsa: lo que mide es el largo que queda tras truncar, no el máximo admitido

- **Capa de origen**: integración (R-C08), que resume N3b X4b.4 y X3.
- **Ubicación**: `04-Integracion.md` §3.2 R-C08 (columna evidencia: «límite = contexto/2 + 2»); `Nucleos/N5-Operacion-Calidad-Seguridad.md` L749 («con un prompt mayor, el servidor trunca en silencio a contexto/2 + 2 tokens»); `Nucleos/N3b-CAG-Y-Estrategias-De-Conocimiento.md` L480, L528 (`4096 − (4096 − 4)/2 = 2050`, G14, en v0.32.0-rc0).
- **Severidad**: S3 (terminología no unívoca). La cifra es correcta.
- **Evidencia (E1, F-X3a y F-X3b, Ollama 0.40.11, `qwen2.5:0.5b`)**.
  - Con la predicción escrita antes: `num_ctx` 6144 → `prompt_eval_count` **3074** (predicho 3074). `num_ctx` 4096 con `num_predict` 64 → **2050**, igual que con 8, así que no depende de `num_predict` en ese rango. Con X3 son tres puntos, sobre un modelo y una forma de prompt.
  - F-X3b: un prompt de **3682** tokens con `num_ctx` 4096 se evalúa **entero** (3682 > 2050). Eso descarta la lectura «todo prompt mayor que contexto/2 + 2 se trunca».
  - La fórmula de la fuente (N3b, G14) es `ctx − (ctx − num_keep)/2`, con `num_keep` = 4. R-C08 omite tanto el parámetro como la condición («cuando el prompt no entra en la ventana»).
- **Impacto si no se corrige**: un lector puede concluir que la ventana útil es la mitad y achicar el contexto sin motivo. Más grave: puede usar «2050» como valor esperado de `prompt_eval_count` en la regla de MI-18, cuando el valor esperado es el largo del prompt.
- **Propuesta de dirección**: enunciarla como «si el prompt excede `num_ctx`, Ollama 0.40.11 conserva `num_ctx − (num_ctx − 4)/2` tokens (= `num_ctx`/2 + 2 con `num_ctx` par), sin error; verificado para 4096, 6144 y 8192 con un modelo». MI-18 compara contra el largo esperado del prompt, nunca contra esa cifra.

### CAT-FO-06 — Los cuantificadores de M1–M12 y el criterio de corte de MI-11 tienen términos sin valor o sin definición

- **Capa de origen**: integración (R-C01, tensión 6).
- **Ubicación**: `04-Integracion.md` §2 tensión 6 («costo de pocas líneas»); §6.3 M5, M7, M10, M11; §5 MI-11.
- **Severidad**: S3.
- **Evidencia (E2)**.
  - **M5** exige que `MaximumIterationsPerRequest` y `MaximumConsecutiveErrorsPerRequest` sean «explícitos», sin valor. Cualquier número, incluido el 40 por defecto escrito a mano, lo cumple, así que el control no es verificable.
  - **M10**: el «timeout del `HttpClient` por configuración» no tiene cota. Con paredes medidas de 5–92 s por iteración (M5) y 13–58 s por llamada (X2), el valor importa.
  - **M7**: «agregados, sin datos personales» no define qué es un agregado. Un conteo por (medio, motivo, localidad) puede tener celdas de tamaño 1 (ver §4).
  - **Criterio de corte de MI-11**: «daño observado **y** costo de pocas líneas». «Pocas» no tiene cota, y la conjunción excluiría un control de daño grave que cueste muchas líneas sin que eso quede dicho.
  - **M1 y M3** («toda», «ninguna») son universales correctos, siempre que se lean como invariantes de construcción verificados por prueba (M11 `Cableado/`), no como tasas. E-B3 (N = 3, 0 ejecuciones tras el rechazo) los ilustra, pero no los prueba. El texto de §6.3 cita E-B3 en M3 como «por qué», y está bien así, pero conviene decir que la garantía la da la prueba de cableado.
- **Impacto si no se corrige**: tres de los doce «mínimos obligatorios» no se pueden comprobar como cumplidos o incumplidos.
- **Propuesta de dirección**:
  1. Dar a M5 y M10 un valor o una regla que lo derive (p. ej., iteraciones ≥ herramientas encadenables del escenario; timeout ≥ percentil observado × margen, con el dato fuente).
  2. Definir «agregado» con un tamaño mínimo de celda, o remitirlo a AH-01.
  3. Reescribir el corte como dos condiciones nombradas, con la regla de desempate.
  4. Declarar que M1 y M3 se garantizan por prueba y no por medición.

### CAT-FO-07 — «Dimensión 1024» y «10–20 casos» se presentan como propiedad y como requisito, sin derivación

- **Capa de origen**: integración (R-C12, R-C09), sobre N3 y N5.
- **Ubicación**: `04-Integracion.md` tensión 4 («`qwen3-embedding:0.6b` (1024)»), R-C12 («la dimensión por configuración (1024)»), MI-02, MI-17; R-C09 y MI-16 («calibración con 10–20 casos»); `Nucleos/N5-Operacion-Calidad-Seguridad.md` L750.
- **Severidad**: S3.
- **Evidencia (E4 + E1 aritmética)**.
  - **Dimensión.** La ficha oficial dice «Up to 1024, supports user-defined output dimensions ranging from 32 to 1024» (MRL), así que 1024 es la dimensión por defecto y máxima, no una constante del modelo. E-B4 y EA-6 midieron 1024 desde .NET (E1), lo cual es correcto para la invocación usada.
  - **10–20 casos.** No hay derivación, y «calibrado» no está definido: ¿acuerdo juez-humano ≥ qué?, ¿sobre qué escala? Con n = 10 y 9 acuerdos, Wilson 95 % = [0,60; 0,98]; con n = 20 y 18 acuerdos, [0,70; 0,97]. Ninguno de los dos tamaños permite afirmar un acuerdo «alto» con un piso mayor que 0,7.
- **Impacto si no se corrige**: la guía enunciaría una validación de dimensión contra un literal, cuando el invariante es «el largo del vector = la dimensión declarada en `VectorStoreVector`». Y enunciaría un juez «calibrado» sin decir con qué criterio ni con qué incertidumbre.
- **Propuesta de dirección**:
  1. MI-17: enunciar el invariante como igualdad entre lo que devuelve el generador y lo que declara el almacén, con 1024 como valor por defecto del modelo vigente y la nota MRL (32–1024).
  2. MI-16: rotular «10–20» como criterio propio de tamaño mínimo práctico, definir «calibrado» como un acuerdo k/n reportado con su intervalo y sin umbral de aprobación, y dejar el tamaño final y el método a AH-02.

---

## 2. Lo que revisé y está bien

1. **El sentido del `Score` está bien enunciado** (N3 L28, C4 L379, V3 L544).
   - E1 (F-S1, InMemory 1.0.1, vectores fijos). `CosineSimilarity` devuelve 1,000 / 0,800 / 0,000 / −1,000 y `CosineDistance` devuelve 0,000 / 0,200 / 1,000 / 2,000 para idéntico, cos 0,8, ortogonal y opuesto.
   - E4. La doc vigente dice «CosineDistance = 1 − CosineSimilarity».
   - Mejora menor sin hallazgo: agregar la conversión del umbral (τ_d = 1 − τ_s) y los rangos ([−1, 1] y [0, 2]), y en BIT-16-04 §1 E-B5 indicar que «0,641» es similitud (`TensorPrimitives.CosineSimilarity`, `Program.cs` L175).
2. **`Habitantes ≥ 1` está bien enunciado y coincide con el código**: F-S1 da 0 → false, 1 → true, `int.MaxValue` → true, null → false, −5 → false (`HabitantesValidos`: `habitantes is not null && habitantes >= 1`). La cifra numérica de R-C08 (contexto/2 + 2) también se sostiene en 0.40.11 con un tercer punto predicho de antemano (F-X3a). Lo que falla es sólo la condición (CAT-FO-05).
3. **Las cautelas de N sobre las mediciones están bien escritas**: BIT-16-04 §1 («N es chico en todas: […] **no** son cifras de fiabilidad para citar en la guía»), N3 L351 («La muestra es chica: sirve para enseñar el método, no para un veredicto general») y la honestidad de N3 L128, que ya advierte que lo definido es *hit rate@k*. El defecto está en los lugares donde esas cifras se usan como respaldo de una decisión (CAT-FO-01, CAT-FO-02), no en las cautelas mismas.

---

## 3. Posición sobre los MI de BIT-16-04 §5 que caen en mi mandato

| MI | Posición | Fundamento |
|---|---|---|
| MI-01 | **otra** | Las tres vías y el orden A→B→C pueden quedar como criterio didáctico y de diseño. Pero la regla «A por defecto, B cuando…» no puede citar EA-6 como respaldo: A tiene N = 1 y B tiene 3/5 en una pregunta, con intervalos superpuestos (CAT-FO-02). Voto la propuesta con el respaldo reescrito como criterio de diseño (EA-5), y EA-6 sólo como existencia de «B puede no recuperar». |
| MI-02 | **abstencion** | La elección del modelo es del experto en IA. En mi mandato sólo entra que «(1024)» se enuncie como dimensión por defecto del modelo, no como constante (CAT-FO-07). |
| MI-08 | **propuesta** | El candidato de ESC-02 es correcto como escenario, con una condición de enunciación: que se mida con hit@k, recall@k y MRR@k definidos como en CAT-FO-03, con la línea de azar k/12 y sin consultas no respondibles en el promedio. |
| MI-11 | **otra** | La lista M1–M12 está bien como composición. El criterio de corte («pocas líneas») y M5, M7 y M10 tienen que tener valor o definición para ser verificables (CAT-FO-06). |
| MI-16 | **otra** | «10–20» como tamaño mínimo práctico, rotulado como criterio propio. «Calibrado» se define como acuerdo k/n con su intervalo, sin umbral de aprobación. El tamaño final y el método son de AH-02 (CAT-FO-07). |
| MI-17 | **propuesta** | Validar al arrancar es correcto. El invariante se enuncia como «largo devuelto = dimensión declarada en el almacén», no como «= 1024» (CAT-FO-07). |
| MI-18 | **propuesta** | La regla de comparar `prompt_eval_count` con el largo esperado es la correcta y la sostiene F-X3b. La fórmula de R-C08 se acompaña con su condición y su parámetro (CAT-FO-05). |
| MI-24 | **otra** | Que se investigue el umbral, sí, pero recién después de definir la métrica: hoy hay tres magnitudes con el mismo nombre (CAT-FO-01). Con 2/10 semillas de un pedido (Wilson [0,06; 0,51]) no se puede fijar ningún umbral, y la guía debe decir «no medido». «Sincrónico o en segundo plano» no es de mi mandato. |

---

## 4. Solicitudes de convocatoria (fuera de mi mandato)

1. **AH-01 (seguridad y privacidad)**: M7 y MI-21. Un «agregado» por medio, motivo y localidad con celdas de tamaño 1 puede reidentificar a una persona de la encuesta, aunque no devuelva el nombre. Hace falta decidir si se exige un tamaño mínimo de celda.
2. **AH-02 (evaluación)**: si las corridas «N = 10» y «N = 5», que son semillas 1..N del mismo pedido a T 0.7 (X2, EA-6, E-B1), cuentan como ensayos independientes para R-LLM, o si hace falta variar el pedido. Es una cuestión de método, no de enunciación.
3. **Senior .NET / arquitectura**: la normalización del CP en el adaptador (dígitos Unicode → ASCII, o rechazo) es una decisión de implementación que deriva de CAT-FO-04 y de M2.
