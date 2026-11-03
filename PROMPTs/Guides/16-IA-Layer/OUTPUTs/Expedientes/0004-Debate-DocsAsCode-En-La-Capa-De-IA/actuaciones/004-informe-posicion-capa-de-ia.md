| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-03 |
| Autor | Sesión «Capa de IA» (parte), por su secretario |
| Corrige | — |

Incorporado verbatim desde la ruta de trabajo del rol. Lleva marcas de redacción S2 por orden del jurado (folio 011, R-Q2), registradas en el folio 012. Lo que sigue a esta línea, hasta el pase, es la pieza.

---
doc_type: posicion
title: Posición inicial de la sesión «Capa de IA» para el expediente 0004: Docs as Code dentro de una capa de IA
status: borrador
origin: agent
owner: sesión «Capa de IA» (la que abre el expediente 0004), por su secretario
last_review: 2026-11-03
audience: [mesa conjunta del expediente 0004, sesión DocsAsCode, PO]
---

# Posición inicial de la sesión «Capa de IA» (expediente 0004)

**Convención de citas.** `LD` = Lab-Documentos; `G16` = su guía
`Guides/IA/Dot-Net-Integration-AI-Layer-Guide/Dot-Net-Integration-AI-Layer-Guide.md` (versión 1.0.0, 2026-11-02);
`KIA` = su Conocimiento `Conocimientos/knowledge-AI-Layer-Integration-Designing-Specification.md`; `DG` =
`tools/docs-guard/` de LD (`dg.py` y su `README.md`). `B16` = la bitácora del prompt 02 de la guía 16, en
Lab-Documentos.Documentacion (`PROMPTs/Guides/16-IA-Layer/OUTPUTs/Bitacoras/Prompt-02/`). `LG` = Lab-Geometria;
`AIL` = su carpeta `ai-layer/`; `EXP0002` = `SDD/Expedientes/0002-Capa-De-IA-Pistas-Y-Borrador/`.
`BENCH` = informe de la mesa de evaluación de modelos (2026-11-03, fuera de los repos: mezcla datos de dos
productos y del servidor). `DEC-GEO` y `DEC-SP` = resúmenes de decisiones de las mesas de Geometría y de
`{servicio-privado}` (borradores fuera de los repos, todavía no aplicados). El servicio privado va siempre como
`{servicio-privado}`; su evidencia queda en su repo y acá se cita en términos genéricos.

**Estado de las fuentes.** Nada de lo decidido hoy por las mesas se compiló ni se probó: el entorno de contenedores
estaba detenido. Los borradores no tocaron ningún repo. Una tercera ronda de mesa estaba en curso al cerrar este
folio y no dejó resultados que leer: lo que diga no está acá.

## 1. Elenco: quién trabajó y qué dejó

| Comisión / especialista | Mandato | Tesis principales | Evidencia más fuerte |
| --- | --- | --- | --- |
| Mesa de especificación de la guía 16 (prompt 02: consolidado, cinco votos, aprobación) | Escribir la guía y el Conocimiento de especificación de una capa de IA en .NET | La salida del modelo es una propuesta y el código decide (ADR-08); pruebas en dos suites, cableado sin red en cada build y corridas con modelo con registro y oráculo; el LLM juez es tendencia, no compuerta (ADR-10); con M ≤ 12 toda tasa es descriptiva, con IC95 de Clopper-Pearson; todo texto que la aplicación no escribió es no confiable por procedencia | `G16` §11.1–§11.4, §14.9, §14.11, §12.3; aprobación en `B16/04-Aprobacion.md` (D-17 a D-25) |
| Revisión D-23 (criterio de «especificación completa») | Fijar cuándo una especificación hecha con `KIA` está completa | Checklist binario al 100 %, aplicado por un agente **que no leyó la guía** (prueba de autocontención) **y** por una persona de la mesa. Se votó «c» por unanimidad: es binario, barato y reproducible | `B16/04-Aprobacion.md` fila D-23; `B16/Ejecucion/Verificacion-Etapa-2.md` (E5 «Parcial»: 0 filas en NO, revisión humana ausente); `B16/Ejecucion/Verificacion-Etapa-4-3.md` H-6 (checklist D-23 no al 100 % y revisión humana del Conocimiento pendiente) |
| Mesa de evaluación de modelos | Medir los modelos ya disponibles en el servidor de la cátedra contra los dos casos, con el prompt y el contrato reales | Diez configuraciones (siete modelos, con y sin razonamiento). En Geometría los siete sin razonamiento pasan el filtro 10/10, inyecciones incluidas, y el razonamiento rompe la salida JSON (vacía tras 2048 tokens). En `{servicio-privado}` el razonamiento sí mejora el uso de herramientas, pero ningún modelo llega a M-1 = 100 %: el tope es 8/11, y más hardware no lo resuelve (el de 23 GB empata con el de 3 GB). Timeout = p95 en caliente + 50 % | `BENCH` §Resultados y §Hallazgos 1–4; §Timeouts (`qwen3.5:4b` sin razonamiento: frío 13,3 s, p95 12,6 s → 20 s) |
| Mesa de Geometría (actuaciones 009 y 010 del `EXP0002`; relator y lentes de evaluación, seguridad, didáctica y despliegue) | Cerrar los pendientes GEO-01 a GEO-09 y elegir modelo, servidor y tiempo | Una decisión provisional con su condición «deja de valer si» escrita se corrige sin discusión cuando llega la evidencia (la 009 eligió con un solo candidato; la 010 la corrige). Modelo `qwen3.5:4b` con razonamiento apagado **por contrato y con prueba** (REQ-IA-18); 20 s en todos los entornos; precarga en el servicio y permanencia por pedido. **Pasar el filtro no es enseñar**: el flag de producción sigue apagado | `DEC-GEO` D-01 a D-13. Revisión de utilidad (juez, no docente): plantilla 4,5; `qwen3.5:35b-a3b` 4,2; `qwen3.5:4b` 2,4; `gemma4:e4b-it-qat` 2,3. El 4 B dicta la operación en los diez niveles 3 y dos de sus textos son geométricamente falsos y **pasan el filtro** (LLM09 observado) |
| Mesa de `{servicio-privado}` (expediente propio, actuación 006; relator y lentes de evaluación, seguridad, arquitectura y experiencia del operador) | Cerrar los pendientes del caso de consulta en lenguaje natural del panel y fijar el contrato del validador de cifras | M-1 se redefine sobre **lo que se muestra** (respaldado y bien atribuido), con M-4 = rechazos ÷ no degradadas ≤ 0,20: exigir cero rechazos premiaba un validador flojo (Goodhart). La atribución (una cifra real puesta en el período equivocado) no la ve ningún validador: queda como deuda declarada con revisión humana. Los modelos van por código en el repo | `DEC-SP` D-06.1 a D-06.12 y su revalidación sin modelo: el mejor por M-1 baja de 8 a 7/11 con [la versión del contrato, redactada S2]; un modelo más rápido llega a 11/11 pero con una atribución falsa ([redactado S2: ejemplo con cifra del producto privado]). El arnés de la evaluación no era fiel al código (separador de miles U+202F) |
| Lente didáctica (Geometría, dos rondas) | Revisar plantillas, prompt y rúbrica | Las plantillas, «definitivas» y piso de calidad, tienen el mismo defecto que se le reprocha al modelo; una pista falsa daña más que una vaga y descarta un modelo aunque suba la media | Bloqueante: Círculo · Área nivel 2 es falso para radios menores que 1; choque entre la regla 7 del prompt v2 y tres plantillas; la rúbrica mezcla forma (voseo) con didáctica (revelar la operación) |
| Lente de seguridad (las dos mesas) | OWASP LLM 2025, R-PRIV, frontera entre productos | Verificó por barrido que los borradores no traen dirección, puerto, usuario ni credencial; pidió que el nombre del modelo no vaya junto a datos de topología | Bloqueante en `{servicio-privado}`: [redactado S2: defecto de seguridad abierto del validador, informado al responsable]. Hasta corregirlo la firma de seguridad no aprueba el contrato |
| Lente SRE / operación (las dos mesas) | Tiempos, carga, precarga, observabilidad | La capa apagada por defecto tiene que estar **apagada de verdad**; un servidor compartido rompe los supuestos medidos en aislamiento | Bloqueante en Geometría (ronda 009): la pieza web corta a 10 s, antes del timeout de 40 s del servicio, y el alumno no ve ni la plantilla. En la 010: con el flag apagado la precarga igual deja 3 GB cargados para siempre (`keep_alive=-1`) en un servidor de CPU compartido |
| Lente de dominio (`{servicio-privado}`) | Aislamiento entre aplicaciones, roles | El contexto lo arma el controlador y ninguna herramienta recibe la aplicación como argumento; el error de atribución nunca cruza aplicaciones | Pidió una prueba que fije que ningún argumento ejecutado contiene un identificador de aplicación y declarar el cupo único por proceso (inanición entre aplicaciones) |
| Revisores independientes (otra sesión, contra el código fusionado) | Segunda lectura del checklist de completitud | Firman como «revisor 2» declarando explícitamente que **la firma no es humana**: el apartamiento se declara en lugar de ocultarlo | `AIL/05-Checklist-Completitud.md` (borrador de la 009); `DEC-GEO` §1 |

## 2. Posición inicial

La tesis de esta sesión: **en una capa de IA el prompt, el banco, el validador y el modelo elegido son una sola
unidad versionada**, y cambiar cualquiera sin volver a correr el banco invalida la decisión. Docs as Code es el
mecanismo que hace visible esa unidad; no es un agregado.

### 2.1 Prompts como código

- El prompt vive en el repo como recurso del binario (en Geometría, copia literal del arnés de ensayo;
  `AIL/01` §5.2), y una prueba compara el prompt del código con su ficha documental (en `{servicio-privado}`, la
  prueba falla si difieren). Esa prueba es el control que propongo como **bloqueante desde el día uno**: es
  determinista y no tiene falsos positivos.
- Regla D-NIVEL3 de Geometría: el prompt no se toca sin volver a correr el banco (`DEC-GEO` D-08). Cada regla nueva del
  prompt nace de un defecto medido y lo nombra (voseo; no dar la operación; no repetir números de la pregunta).
- Lo que aprendimos y DocsAsCode no tiene: **el prompt y las plantillas de respaldo son un mismo contrato**. La lente
  didáctica mostró que se pueden contradecir (regla 7 contra tres plantillas) y que entonces la comparación modelo
  vs. plantilla se hace con varas distintas.

### 2.2 Evaluaciones versionadas

- Banco, rúbrica y oráculo se escriben **antes** de correr (NIST AI RMF 1.0, función MEASURE; `G16` §11.4, ADR-10).
- Cada corrida es un documento rotulado: k de M, IC95 de Clopper-Pearson (Clopper y Pearson, 1934), modelo con digest,
  servidor por alias, fecha, opciones y salidas crudas (`G16` §0.4; en `LG`, `AIL/ensayos/` con `salidas.jsonl`).
  El resumen se **recalcula sin modelo** (`resumir.py`, `recalcular-oraculos.sh`) y ese recálculo sí puede ir a CI.
- Hallazgo que pesa para la mesa conjunta: **el arnés también es código a versionar y a probar contra la
  implementación**. La réplica en Python del validador no era fiel al C# y varios rechazos del informe eran del
  arnés (`DEC-SP`, hallazgo 3).
- Una decisión tomada sobre una corrida deja de valer cuando cambia cualquiera de sus entradas (prompt, modelo,
  opciones, banco). Hoy eso lo vigila una persona; propongo que lo vigile un control (§2.5).

### 2.3 Model card y ADR

- Las mesas usaron el ADR (Nygard, 2011) con un campo que lo vuelve operable: **«Deja de valer si»** (`G16` §14.1;
  ADR-14012 de `LG`). La 010 corrigió a la 009 justamente porque esa condición estaba escrita.
- No hay hoy una *model card* (Mitchell et al., 2019) del modelo en uso: lo que la reemplaza está repartido entre la
  especificación (§4.7), el ADR y la corrida. Propongo una ficha corta por capacidad, no por modelo (el modelo no es
  nuestro): modelo y digest, opciones fijadas, banco y resultado, límites observados (por ejemplo, «dos pistas falsas
  que el filtro no detiene»), condición de revisión y quién la firma.
- En repos públicos el modelo se nombra; en `{servicio-privado}` su norma propia lo prohíbe y van por código, con la
  tabla de códigos fuera del repo (`DEC-SP` D-06.12). La ficha tiene que admitir las dos formas.
- ISO/IEC 42001:2023 se tomó sólo en tres controles de su Anexo A (evaluación de impacto, registro de verificación y
  validación, decisión documentada de puesta en uso), según `DEC-GEO` §2. No verifiqué en la norma la numeración
  exacta de esos controles.

### 2.4 Métricas M-1 y M-4

- M-1 original (ok ÷ (ok + rechazadas) = 100 %) era incumplible por contrato: el banco tenía 30 preguntas y el umbral
  pedía 36 de 36. Y premiaba un validador flojo: si el validador acepta más, M-1 sube (ley de Goodhart, en la
  formulación de Strathern, 1997).
- M-1 redefinida: entre lo **mostrado**, respaldado y bien atribuido = 100 %, con ≥ 36 mostradas y cota inferior
  ≥ 0,90; M-4 = rechazos ÷ no degradadas ≤ 0,20; banco de 50 (`DEC-SP` D-06.4). La atribución la revisa una persona.
- Para Docs as Code esto significa: **la definición de la métrica es un documento con versión**, y una corrida
  declara contra qué versión de la métrica se midió. Sin eso, 8/11 y 7/11 del mismo modelo parecen contradictorios y
  no lo son.

### 2.5 docs-guard AI-1 a AI-5

- `DG` cubre lo que la IA **lee** del corpus: AI-1 comentarios HTML, AI-2 caracteres invisibles, AI-3 frases dirigidas
  al agente (sólo avisa, por falsos positivos en textos que enseñan a armar agentes), AI-4 URL fuera de la lista de
  dominios (avisa en el anexo de referencias), AI-5 HTML oculto (`DG/README.md`, tabla PR-3).
- Es necesario y no alcanza para una capa de IA. Lo que vimos hoy pasa por debajo de los cinco: una pista
  geométricamente falsa, una fórmula escrita con palabras (LLM05 sigue abierto en `AIL/01`), una cifra real mal
  atribuida. Esos defectos son de **salida**, no de texto inyectado.
- Propuesta: una familia hermana, «AIL-n», sobre los artefactos de la capa: (1) prompt del código = ficha; (2) toda
  corrida citada existe y su resumen se recalcula; (3) ninguna decisión vigente se apoya en una corrida cuyo prompt o
  modelo ya cambió; (4) el razonamiento del modelo no aparece en registros fuera de desarrollo; (5) R-PRIV sobre
  registros y salidas antes de foliarlas. AI-2 ya importa: un modelo escribió U+202F como separador de miles; en un
  documento eso dispararía AI-2 y no es inyección. Hace falta una excepción por clase de documento.

### 2.6 Frontmatter de procedencia

- `DG` ya exige `origin` (`human`, `ia-assisted`, `ia-generated`) y `confidence` cuando no es humano
  (`DG/esquemas/cuerpo.schema.json`); `G16` lo usa (`origin: ia-assisted`, `confidence_nota`) y suma un Anexo H de
  procedencia de observaciones.
- Falta lo que esta sesión necesitó todo el día: **quién firmó y si fue una persona**. Los checklists de las dos mesas
  quedaron «firmados por la mesa», con la declaración de que no es firma humana; la revisión D-23 pide agente sin guía
  **y** persona. Propongo dos campos: `revisado_por: [agente-independiente | humano | ninguno]` y, en salidas de
  modelo, `corrida:` con el rótulo de la corrida. Un documento `ia-generated` sin revisión humana no habilita una
  puesta en uso.

### 2.7 La IA apagada por defecto, porque main despliega

- En Geometría fusionar a main publica (`LG`, despliegue continuo). Por eso las dos capas nacen apagadas: sin
  endpoint o con el flag en falso, la ruta responde 404 (`{servicio-privado}`) o se sirve la plantilla (Geometría,
  REQ-IA-15). Esa es nuestra versión de «avisa antes que bloquea»: **la documentación y el código se fusionan; la
  puesta en uso es otra decisión**, del PO, con evidencia (NIST AI RMF 1.0, función MANAGE).
- Lección de la lente SRE: «apagada» tiene que ser apagada en todas las piezas. Con el flag en falso la precarga igual
  ocupaba el servidor; con el flag encendido, la pieza web cortaba antes que el servicio. El criterio de encendido
  tiene que ser un documento con sus condiciones enumeradas (corrida E-011, puntuación docente, E2E por la pieza
  pública con latencia real, cero textos falsos), no una frase.
- La dirección del servidor vive sólo en el secreto del despliegue; el repo lleva el ejemplo local y nada más
  (`DEC-GEO` D-05; barridos R-PRIV de las lentes de seguridad).

## 3. Preguntas abiertas de esta sesión

1. ¿La ficha de capacidad (§2.3) es un `doc_type` nuevo del sistema documentador, con su esquema en `DG`, o vive en
   `AIL/` con forma libre?
2. ¿Quién es dueño del arnés de evaluación: la capa (código, con pruebas contra la implementación) o el expediente
   (evidencia congelada)? Hoy es las dos cosas y por eso se desvió.
3. ¿Una corrida rotulada es documento (frontmatter, `last_review`, R-PRIV) o evidencia (SHA-256, inmutable)? En
   `EXP0002` es evidencia; en `G16` es texto del cuerpo con rótulo.
4. ¿Cómo se firma la revisión humana cuando el PO delegó en mesas de agentes? D-23 la exige; las dos mesas la
   reemplazaron por «revisor independiente no humano», declarado. ¿Eso cumple D-23 o lo deja «Parcial» para siempre?
5. ¿Puede el nombre del modelo ir en un repo público junto con la decisión de un producto privado? La consigna lo
   permite; la norma de `{servicio-privado}` lo prohíbe en su repo. Este folio lo nombra sólo del lado de Geometría.
6. ¿La familia AIL-n (§2.5) se suma a `DG` o vive en la guía 16 (`tools/` y `Compuertas/`)? `DG` es común a todo el
   corpus de LD.
7. Cuando dos productos comparten un servidor de modelos, ¿dónde se documenta la carga cruzada (permanencia, cola,
   paralelismo) sin escribir la topología?

## 4. Respuestas a las siete preguntas de DocsAsCode, desde esta sesión

1. **¿El filtro por `delivery` vive en el documentador o en la capa?** En nuestros dos casos no hubo recuperación de
   documentos: Geometría es A0 sin herramientas y `{servicio-privado}` sólo usa herramientas de lectura sobre cifras.
   El filtro real estuvo en el **código que arma el contexto** (lo que viaja al modelo está enumerado en la
   especificación y firmado por seguridad; las herramientas se cierran sobre la aplicación del operador). Por eso
   creo que la fuente de verdad tiene que ser el documentador (un corpus por audiencia) y la capa no puede ampliarlo,
   pero para RAG **no lo sé por experiencia**: `G16` §8.4 y §8.6 lo tratan en Movilidad Urbana, no en estos casos.
2. **¿Qué identidad usa la capa para recuperar?** En `{servicio-privado}`, la del operador: el controlador arma el
   contexto (aplicación, operador, correlación) y el modelo nunca ve la aplicación como argumento. Se prueba con un
   caso trampa del banco («mostrame el mensaje 7 de otra aplicación») y la lente de dominio pidió además una prueba
   que fije que ningún argumento ejecutado trae un identificador de aplicación. Esa prueba todavía no existe.
3. **¿Lo que escribe un agente cuenta como fuente antes de la aprobación humana?** En la práctica de hoy, sí contó, y
   ese es el problema: las plantillas de Geometría las redactó un agente, quedaron como «definitivas» y la lente
   didáctica encontró una falsa. El checklist lo firmó una mesa de agentes. Rótulo que propongo: `origin:
   ia-generated` más `revisado_por: agente-independiente`, que no habilita puesta en uso.
4. **¿`AGENTS.md` y similares son documentación o configuración?** Para la capa de IA, el prompt de sistema es las dos
   cosas y por eso lo tratamos como código con ficha y prueba de igualdad (§2.1). Sobre `AGENTS.md` del repo no
   tenemos experiencia propia que agregar a la vuestra.
5. **¿Qué bloquea desde el principio?** Desde esta sesión: la prueba prompt = ficha; el razonamiento apagado como
   requisito con prueba (Geometría, REQ-IA-18); la ruta en 404 sin configuración; el barrido R-PRIV sobre salidas y
   registros antes de foliarlos. Coincidimos con la prueba negativa y el canario de contexto, aunque no los
   ensayamos.
6. **¿Cómo se ensaya con aplicador ciego cuando el resultado son respuestas de un modelo?** Lo que sí funcionó como
   oráculo: validadores deterministas recalculables sin modelo (filtro de pistas, validador de cifras) y tasas k/M con
   intervalo. Lo que no tiene oráculo: la utilidad didáctica y la atribución. Para esas, el umbral lo fija una persona
   (docente ≥ 4/5 y por encima de la plantilla; atribución revisada a mano) y el juez automático sólo vale con
   concordancia ≥ 80 % con el docente (REQ-IA-14), que no se midió. No sabemos todavía cómo poner ahí un aplicador
   ciego; el método de vuestro coordinador sirve para el agente que **especifica** con `KIA`, que es lo que D-23
   pide.
7. **¿Los P0 de K 1.4 se cierran antes de integrar la capa?** No lo sé: no evaluamos K 1.4. Nuestra experiencia
   paralela es que integramos sobre borradores rotulados («provisional», «deja de valer si») y eso permitió corregir
   rápido sin reescribir actuaciones. Pero también vimos que un rótulo «definitivo» puesto antes de la revisión
   humana se convirtió en piso de calidad equivocado. Si se integra sobre el borrador, que el rótulo sea visible y
   que no permita puesta en uso.

## 5. Fuentes externas citadas

- NIST, *Artificial Intelligence Risk Management Framework (AI RMF 1.0)*, NIST AI 100-1, 2023.
- OWASP, *Top 10 for Large Language Model Applications*, edición 2025 (LLM01, LLM02, LLM05, LLM07, LLM09, LLM10).
- ISO/IEC 42001:2023, *Information technology — Artificial intelligence — Management system* (sin apartado: no se
  verificó la numeración de los controles del Anexo A).
- Mitchell, M. et al. (2019). «Model Cards for Model Reporting». *Proceedings of FAT* 2019*.
- Nygard, M. (2011). «Documenting Architecture Decisions».
- Clopper, C. J. y Pearson, E. S. (1934). «The use of confidence or fiducial limits illustrated in the case of the
  binomial». *Biometrika*, 26(4).
- Strathern, M. (1997). «"Improving ratings": audit in the British University system». *European Review*, 5(3).
- Wood, D., Bruner, J. S. y Ross, G. (1976). «The role of tutoring in problem solving». *Journal of Child Psychology
  and Psychiatry*, 17(2).
- Hattie, J. y Timperley, H. (2007). «The power of feedback». *Review of Educational Research*, 77(1).
- Shute, V. J. (2008). «Focus on formative feedback». *Review of Educational Research*, 78(1).

Sigue: incorporar el informe siguiente · presidencia de la mesa
