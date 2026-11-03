| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-03 |
| Autor | Comisión C-LLMOPS |
| Corrige | — |

Incorporado verbatim desde la ruta de trabajo del rol. Lleva marcas de redacción S2 por orden del jurado (folio 011, R-Q2), registradas en el folio 012. Lo que sigue a esta línea, hasta el pase, es la pieza.

---
doc_type: informe-de-comision
title: Informe de la comisión C-LLMOPS — expediente 0004, Docs as Code dentro de una capa de IA
status: borrador
origin: ia-generated
confidence: media
revisado_por: ninguno
last_review: 2026-11-03
audience: [mesa conjunta del expediente 0004, presidente, refutador, PO]
---

# Informe de la comisión C-LLMOPS (expediente 0004)

**Secciones leídas de Knowledge-Mesa-De-Expertos-A-Pedido:** §0, §2.2 (clase «diseño de una norma o decisión»: se citan fuentes externas, sin inventar cláusulas), §3.2, §3.3 y §4.

**Mandato.** LLMOps: prompts como código, evaluaciones versionadas y reproducibles, contratos de herramientas y OpenAPI, métricas de aceptación con intervalo (Clopper-Pearson), elección de modelo con evidencia, feature flags y despliegue desde main. **No-competencia:** no opino sobre filtrado por audiencia como control de acceso, didáctica, ni seguridad de contenido más allá de lo que toca a la evaluación o al contrato.

**Clases de ancla.** E1 = lo medí o lo leí en el árbol con comando; E2 = norma o decisión aceptada citada; C = afirmación de una parte que no verifiqué (sólo funda preguntas).

## 0. Verificaciones hechas contra los repos (E1)

| # | Qué | Resultado |
| --- | --- | --- |
| V-1 | Lab-Geometria, `ai-layer/ensayos/` | Existen `banco.json`, `pistas.py`, `resumir.py`, `Criterio-R-LLM.md`, `Resultado.md` y `corrida-2026-11-01/` con `registro-A.jsonl`, `registro-B.jsonl`, `resumen.txt` y `SHA256SUMS`. `pistas.py` comprueba el digest del modelo antes de la primera llamada y lo graba en cada registro. |
| V-2 | Intervalos de `resumen.txt` | `0/30 [0.000, 0.116]` y `30/30 [0.884, 1.000]`: recalculados con la distribución beta, coinciden (Clopper-Pearson exacto, bilateral 95 %). |
| V-3 | Umbral M-1 de `{servicio-privado}` (≥ 36 mostradas, cota inferior ≥ 0,90) | 36/36 da cota inferior 0,903; 35/35 ya no la alcanza. El umbral es coherente con su muestra mínima: **es el primer n en que un pleno puede pasar**. |
| V-4 | Cifras de BENCH (C, no en repo) recalculadas | 8/11 → IC95 [0,390; 0,940]; 7/11 → [0,308; 0,891]; 11/11 → [0,715; 1]; 10/10 → [0,692; 1]. **Los tres intervalos de 7, 8 y 11 de 11 se solapan**: con M = 11 no hay evidencia estadística de que un modelo sea mejor que otro. |
| V-5 | Pruebas que leen el banco | `tests/GeometriaFactory.Integration.Tests/AI/ModelBenchRunTests.cs` corre los treinta casos de `banco.json` y se declara «conducta, no compuerta»; `HintFilterTests.cs` replica los ocho casos de `autoprueba()` de `pistas.py`. Es decir: en Geometría el arnés Python y el C# **sí están atados por prueba** en el filtro. |
| V-6 | Guía 16 de Lab-Documentos | Define IC95 de Clopper-Pearson y «con M ≤ 12 la tasa es descriptiva» (§11.4); el LLM juez sólo «si está calibrado» (§11.5–§11.6); fija un único `num_ctx` por servidor compartido, con prueba `Compartido_SinNumCtxDelArnes_Rechaza`. |
| V-7 | docs-guard de Lab-Documentos | `esquemas/cuerpo.schema.json` tiene `origin ∈ {human, ia-assisted, ia-generated}` y exige campos extra si no es `human`. No hay campo de revisor. |
| V-8 | «En Geometría fusionar a main publica» (Capa de IA §2.7) | **No se sostiene en el clon que leí** (main en `056801d`, PR #237): `deploy-front-ftp.yml` sólo tiene `workflow_dispatch`, con la nota de que el disparo automático se retiró; `ci.yml` declara «este flujo no publica nada». Si el despliegue continuo volvió en PR posteriores, el clon está atrasado; la mesa tiene que medirlo sobre el main remoto antes de apoyar algo en esa premisa. |
| V-9 | REQ-IA-18 (razonamiento apagado por contrato) | No aparece en ningún `.md` de Lab-Geometria: vive sólo en el borrador `DEC-GEO`, como dice la propia parte. |

## 1. Cómo resuelve la industria esta cuestión, desde LLMOps

1. **El sistema de ML es más que el modelo, y la deuda está en lo que lo rodea.** Sculley et al. (2015), «Hidden Technical Debt in Machine Learning Systems», NeurIPS: la configuración, los datos y el código de pegamento son deuda si no se versionan y prueban con el mismo rigor que el código. Breck et al. (2017), «The ML Test Score: A Rubric for ML Production Readiness and Technical Debt Reduction», IEEE BigData: rúbrica de pruebas de datos, de modelo, de infraestructura y de monitoreo, cada una con puntaje. La tesis de la Capa de IA («prompt, banco, validador y modelo son una sola unidad versionada») es exactamente esto aplicado a LLM.
2. **Prompts como código y evaluación como prueba de regresión.** La práctica dominante en las plataformas de proveedores y en las herramientas abiertas de evaluación es: el prompt vive en el repositorio, cada cambio corre un conjunto de evaluación fijo y el resultado se compara con una línea base. Liang et al. (2022), «Holistic Evaluation of Language Models» (HELM), Stanford CRFM: evaluar con escenarios y métricas declarados, publicar las salidas crudas y las configuraciones para que el resultado se pueda reproducir. Es la versión pública de la «corrida rotulada» de las dos sesiones.
3. **La documentación del modelo y del dataset es un artefacto estándar.** Mitchell et al. (2019), «Model Cards for Model Reporting», FAT*; Gebru et al. (2021), «Datasheets for Datasets», *Communications of the ACM* 64(12). En LLMOps el banco de evaluación es un dataset y le corresponde su datasheet (origen, composición, para qué no sirve).
4. **Gestión del riesgo con medición antes del uso.** NIST AI 100-1 (AI RMF 1.0, 2023), funciones MEASURE y MANAGE; NIST AI 600-1 (2024), perfil de IA generativa del AI RMF. ISO/IEC 42001:2023 (sistema de gestión de IA; sin apartado). ISO/IEC 23894:2023 (gestión del riesgo en IA; sin apartado).
5. **Intervalos, no tasas puntuales, con muestras chicas.** Clopper y Pearson (1934), *Biometrika* 26(4). Brown, Cai y DasGupta (2001), «Interval Estimation for a Binomial Proportion», *Statistical Science* 16(2): el exacto es conservador; Wilson es alternativa aceptada. Para comparar dos modelos sobre **el mismo banco**, la prueba apareada adecuada es la de McNemar (1947), *Psychometrika* 12(2); comparar dos intervalos que se solapan no es una prueba.
6. **Evaluadores con modelo sólo calibrados.** Zheng et al. (2023), «Judging LLM-as-a-Judge with MT-Bench and Chatbot Arena», NeurIPS: el juez tiene sesgos de posición, verbosidad y autopreferencia; se mide su concordancia con personas antes de usarlo. Coincide con ADR-10 y REQ-IA-14 de las partes.
7. **Contratos de herramientas.** OpenAPI Specification 3.1.0 (OpenAPI Initiative, 2021) y JSON Schema (draft 2020-12): una herramienta expuesta a un modelo se declara con esquema de entrada y salida; el *function calling* de los proveedores consume justamente un subconjunto de JSON Schema. Model Context Protocol (especificación publicada por Anthropic, 2024) define herramientas también por esquema. Pruebas de contrato dirigidas por el consumidor: Fowler (2006), «Contract Test» / Robinson (2006), «Consumer-Driven Contracts: A Service Evolution Pattern».
8. **Feature flags y despliegue desde main.** Humble y Farley (2010), *Continuous Delivery*, Addison-Wesley: el código va siempre a main y el *release* se separa del *deploy*. Hodgson (2017), «Feature Toggles (aka Feature Flags)», martinfowler.com: tipos de toggle (release, ops, experiment, permission) y que cada toggle es deuda con fecha de retiro. Forsgren, Humble y Kim (2018), *Accelerate*: entrega continua con *trunk-based development*.
9. **Ley de Goodhart en métricas de aceptación.** Goodhart (1975) y la formulación de Strathern (1997), *European Review* 5(3); en ML, Manheim y Garrabrant (2018), «Categorizing Variants of Goodhart's Law», arXiv.

## 2. Lo que hicieron las dos sesiones contra eso

### 2.1 Coincide

| Práctica de la industria | Evidencia en las sesiones |
| --- | --- |
| Corrida reproducible: modelo con digest, opciones, fecha, salidas crudas, huella | E1, V-1 y V-2 (Lab-Geometria `ai-layer/ensayos/`). |
| Resumen recalculable sin modelo, apto para CI | `resumir.py` en Lab-Geometria (E1); `recalcular-oraculos.sh` (C, Capa de IA §2.2). |
| IC95 de Clopper-Pearson y «M ≤ 12 es descriptivo» | V-2, V-6. |
| Juez con modelo sólo calibrado | G16 §11.5–§11.6 (V-6); REQ-IA-14 (C). |
| Regla «el prompt no se toca sin volver a correr el banco» | `DEC-GEO` D-08 (C). Es la prueba de regresión de HELM/Breck. |
| Goodhart detectado en M-1 y M-4 añadida como contrapeso | `DEC-SP` D-06.4 (C); umbral coherente con su n (V-3). |
| Separar fusión de puesta en uso por flag apagado | Capa de IA §2.7 y DocsAsCode §2.1 punto 4: es *release ≠ deploy* de Humble y Farley. |
| Cada control con par rojo/verde | DocsAsCode §2.1 punto 3; «una prueba que no se vio fallar no cierra» (§3.3 del Knowledge). |
| ADR con «deja de valer si» | Lab-Geometria `ai-layer/03-ADR.md` (E1 de existencia). Es la condición de revisión que piden NIST MANAGE y una model card. |

### 2.2 Falta

| # | Falta | Por qué importa | Ancla |
| --- | --- | --- | --- |
| F-1 | **Comparación apareada entre modelos.** Las decisiones de modelo se toman por k/M puntual (8/11 vs 7/11 vs 11/11). | V-4: los intervalos se solapan; con M = 11 la elección es descriptiva por la propia regla de G16 §11.4. Falta McNemar sobre el mismo banco, o un banco más grande. | E1 + E2 |
| F-2 | **Versión de la métrica en la corrida.** La Capa de IA lo propone (§2.4) pero no existe campo. | 8/11 y 7/11 del mismo modelo se leen como contradicción. | C |
| F-3 | **Datasheet del banco.** Ni `banco.json` de Geometría ni el banco de 50 de `{servicio-privado}` declaran origen, cobertura y límites. | Gebru et al. (2021); sin eso «cambió el banco» no es detectable. | E1 (V-1: no hay ficha del banco) |
| F-4 | **Huella de la unidad versionada.** No hay un identificador único de (prompt, plantillas, validador, modelo+digest, opciones, banco, versión de métrica) que la decisión cite y que un control compare. | Sin él, AIL-3 («ninguna decisión se apoya en una corrida cuyo prompt o modelo cambió») no es implementable mecánicamente. | C |
| F-5 | **Contrato de herramientas como OpenAPI/JSON Schema con prueba de contrato.** DocsAsCode propone «herramienta = contrato OpenAPI por audiencia»; ninguna sesión tiene hoy el esquema de las herramientas de `{servicio-privado}` en un documento versionado con diff. | El defecto R2 ([redactado S2: defecto de seguridad abierto del validador, informado al responsable]) es un defecto de contrato de salida de la herramienta (`status`), no del validador. | C |
| F-6 | **Ciclo de vida del flag.** Ninguna sesión fija dueño, tipo de toggle ni fecha de retiro del flag de la capa. | Hodgson (2017): un toggle de *release* sin fecha se vuelve permanente; ya pasó con la precarga ignorando el flag (Capa de IA §1, lente SRE). | C |
| F-7 | **Monitoreo en uso.** Nada mide la deriva una vez encendida la capa (tasa de rechazo del filtro, latencia p95, degradación a plantilla). | NIST AI 600-1, función MEASURE/MANAGE en uso; Breck et al., pruebas de monitoreo. | E2 |
| F-8 | **Premisa de despliegue continuo sin verificar.** | V-8. | E1 |

### 2.3 Sobra

| # | Sobra | Por qué |
| --- | --- | --- |
| S-1 | Elegir modelo «por hardware» o por un solo pleno (11/11) | V-4: el pleno de 11 tiene cota inferior 0,715; con eso no se descarta nada. La conclusión correcta de BENCH es «ningún modelo cumple con evidencia», no «X es el mejor». |
| S-2 | Duplicar el validador en dos lenguajes sin prueba que los ate | `DEC-SP` hallazgo 3 (C): la réplica Python no era fiel (U+202F). En Geometría sí están atados (V-5); donde no lo están, sobra la réplica o falta la prueba. Propongo que sobre: el arnés llama al validador del producto. |
| S-3 | Proponer `llms.txt` / índice por audiencia como pieza de LLMOps | Fuera de mi mandato como control; desde LLMOps sólo digo que ninguno de los dos casos tiene recuperación (Capa de IA §4.1), así que diseñarlo hoy es agregado sin caso. |

## 3. Respuestas propias

### 3.1 Las 7 preguntas de DocsAsCode

1. **¿Dónde vive el filtro por `delivery`?** En el documentador, como fuente de verdad: genera un corpus por audiencia con su huella, y la capa de IA consume ese artefacto ya filtrado y versionado; la capa no filtra, comprueba la huella del corpus que carga. Es el mismo patrón que prompt y banco: una entrada versionada de la unidad (F-4).
2. **¿Qué identidad usa para recuperar?** La del usuario final, propagada; nunca la del servicio. Se prueba con una prueba de contrato negativa en CI: por cada rol, una llamada a cada herramienta con un recurso de otro alcance debe devolver el mismo resultado que la API devuelve a ese rol (404 sin cuerpo), y la prueba que pidió la lente de dominio (ningún argumento ejecutado trae identificador de aplicación) bloquea.
3. **¿Lo escrito por un agente cuenta como fuente antes de la aprobación humana?** No. Entra al repo con `origin: ia-generated` y un campo de revisor; no entra a ningún banco, plantilla ni corpus de contexto hasta que el revisor sea humano.
4. **¿`AGENTS.md` y equivalentes son documentación o configuración?** Configuración, tratada como código: va en la unidad versionada (F-4), su cambio dispara la corrida del banco y lleva prueba de igualdad con su ficha, igual que el prompt de sistema. Su ficha sí es documentación con frontmatter.
5. **¿Qué bloquea desde el principio?** Lo determinista y sin falsos positivos: (a) prompt del código = ficha; (b) el resumen de toda corrida citada se recalcula y coincide (`resumir.py`); (c) huella de la unidad citada por una decisión vigente = huella actual; (d) ruta en 404 / plantilla con el flag apagado, probado en rojo con el flag encendido; (e) prueba negativa de contrato de herramientas (respuesta 2). La corrida con modelo nunca bloquea un PR: es conducta, no compuerta, como ya declara `ModelBenchRunTests.cs`.
6. **¿Cómo se ensaya con aplicador ciego si el resultado son respuestas de un modelo?** Separando dos ensayos. El aplicador ciego ensaya al **agente que especifica** con KIA (oráculo: checklist D-23 binario). Las respuestas del modelo se ensayan con banco fijo y oráculo determinista, k/M con Clopper-Pearson, umbral = cota inferior del IC95 ≥ el valor pactado, con el n mínimo que lo hace alcanzable (para 0,90, n ≥ 36; V-3). Lo que no tiene oráculo determinista lo puntúa una persona; el juez con modelo entra sólo con concordancia medida.
7. **¿Los P0 de K 1.4 se cierran antes de integrar?** Se integra sobre el borrador rotulado, con el flag de puesta en uso apagado y un control que impide encenderlo mientras haya un P0 abierto citado en la ficha de capacidad. Fusionar no es poner en uso; esa separación es la que hace segura la integración temprana.

### 3.2 Preguntas de la Capa de IA que tocan mi mandato

1. **Ficha de capacidad: ¿`doc_type` con esquema o forma libre?** `doc_type` nuevo con esquema en docs-guard. Campos mínimos: huella de la unidad (F-4), modelo por nombre o por código, digest, opciones, banco con versión, versión de métrica, corrida citada, k/M e IC95 por métrica, límites observados, «deja de valer si», revisor y su naturaleza (humano / agente).
2. **¿Dueño del arnés?** La capa, como código con pruebas contra la implementación; el arnés invoca el validador del producto en vez de reimplementarlo (S-2). El expediente guarda sólo las salidas congeladas.
3. **¿Corrida: documento o evidencia?** Las dos, separadas: los registros crudos son evidencia inmutable con SHA-256 (como `SHA256SUMS` en Lab-Geometria); el `Resultado.md` que los resume es documento con frontmatter, que cita la huella y se recalcula en CI.
4. **¿Revisión humana delegada en mesas cumple D-23?** No cumple: queda «Parcial» y lo dice el campo de revisor. Sí basta para fusionar; no basta para encender el flag de producción.
5. **¿Nombre del modelo en repo público junto a decisión de un producto privado?** No. En el repo público va el nombre sólo en decisiones del producto público; las del privado van por código, y la ficha admite las dos formas.
6. **¿AIL-n en docs-guard o en la guía 16?** En docs-guard, como familia opcional que se activa por la presencia de `doc_type` de ficha de capacidad o de corrida; las reglas son sobre artefactos del corpus y docs-guard es lo que ya corre en cada repo.
7. **¿Dónde se documenta la carga cruzada de un servidor compartido?** En una ficha de servidor por alias, con los parámetros que el arnés fija y verifica (`num_ctx` único, permanencia, paralelismo), sin dirección; cada corrida cita el alias y declara si el servidor estaba compartido. G16 ya da el patrón (V-6).

## 4. Lo que revisé y está bien

- Los intervalos de `ai-layer/ensayos/corrida-2026-11-01/resumen.txt` están bien calculados (V-2).
- El umbral M-1 «≥ 36 mostradas con cota inferior ≥ 0,90» es aritméticamente consistente (V-3).
- `pistas.py` fija y comprueba el digest del modelo antes de correr, y graba modelo, digest y fecha en cada registro (V-1): es reproducibilidad de verdad, no declarada.
- `ModelBenchRunTests.cs` se declara conducta y no compuerta, y `HintFilterTests.cs` ata el filtro C# a la autoprueba Python (V-5).
- G16 §11.4–§11.6 y la regla del `num_ctx` único con prueba de rechazo (V-6).
- El esquema de procedencia de docs-guard (`origin` con tres valores) existe y es la base correcta para el campo de revisor (V-7).
- Las dos partes citan el ADR con condición de revisión y lo usaron para corregir una decisión (009 → 010): es la práctica correcta.

**Cierre de la comisión.** Hallazgos P1: F-1 (elección de modelo sin evidencia comparativa) y F-8 (premisa de despliegue desde main no verificada en el clon). P2: F-4, F-5, F-6. P3: F-2, F-3, F-7.

Sigue: incorporar el informe siguiente · presidencia de la mesa
