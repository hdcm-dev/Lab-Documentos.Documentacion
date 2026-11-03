| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-03 |
| Autor | Refutador |
| Corrige | — |

Incorporado verbatim desde la ruta de trabajo del rol. Lleva marcas de redacción S2 por orden del jurado (folio 011, R-Q2), registradas en el folio 012. Lo que sigue a esta línea, hasta el pase, es la pieza.

---
doc_type: informe
title: Informe del refutador — expediente 0004, Docs as Code dentro de una capa de IA
status: borrador
origin: ia-generated
confidence: media
revisado_por: ninguno
owner: refutador de la mesa conjunta del expediente 0004
last_review: 2026-11-03
audience: [presidencia de la mesa, análisis de decisiones, jurado, PO]
---

# Informe del refutador (expediente 0004)

**Secciones de `Knowledge-Mesa-De-Expertos-A-Pedido.md` leídas:** §0 (mapa de carga, fila del refutador),
§1 (identidad y roles), §2.1 (pasos 6, 6 bis, 7 y 10) y §2.2 (clases de objeto). No cargué
`Knowledge-Excepcion-A-Un-Conocimiento.md` ni `Knowledge-Cadena-De-Consecuencias.md`: **ninguna comisión dejó
ficha de excepción** (verificado: ningún informe declara `XC-<n>` ni se aparta por escrito de una convención
que rige), así que no hay ficha que refutar ni paso 6 bis que convocar. Lo declaro para el cruce del paso 10.

**Folios leídos, enteros:** las dos posiciones (sesión «Capa de IA» y sesión DocsAsCode) y los cinco informes:
C-DAC-IND, C-GOB-IA, C-LLMOPS, C-DOCS-COMO-CONTEXTO y C-DIDACTICA.

**Anclas.** E1 = lo medí con un comando; E2 = lo leí en un documento; C = criterio del refutador (sólo funda
una pregunta o un ítem para el jurado). El servicio privado va como `{servicio-privado}`.

## 0. Medición propia (E1)

| # | Qué | Resultado |
| --- | --- | --- |
| R-V1 | Disparo del flujo de publicación del front de Lab-Geometria en el `main` remoto, después de `fetch` | `deploy-front-ftp.yml` declara sólo `workflow_dispatch`; el commit que lo cambió se titula «Declarar el canal de FTP alternativo y quitarle el disparo automático». **Confirma V-8 de C-LLMOPS sobre el remoto, no sólo sobre el clon.** El nombre «alternativo» sugiere que hay otro canal de publicación que no está en `.github/workflows/`; la premisa «fusionar a main publica» queda **no demostrada por los flujos del repo**, ni refutada |
| R-V2 | `208-resultado-ronda-4` en el `main` remoto de Lab-Documentos.Documentacion | Existe (1 coincidencia). C-DIDACTICA no lo localizó; C-DAC-IND sí. La discrepancia es de copia local, no de hecho (ver contradicción 11) |

## 1. Ataque a la lectura dominante

### 1.1 Cuál es la lectura dominante

Las cinco comisiones convergen en un mismo paquete, con matices:

1. La industria **no tiene** una metodología nombrada que integre Docs as Code «dentro» de una capa de IA; hay
   una extensión del principio («si es texto que gobierna el sistema, va al repo, por PR, con prueba»).
2. El sistema documentador es la fuente de verdad del filtro por `delivery`; la capa no amplía.
3. Lo escrito por un agente no es fuente hasta la aprobación humana; se suma `revisado_por`.
4. Hace falta un `doc_type` nuevo de «ficha de capacidad» con esquema en docs-guard.
5. Fusionar no es poner en uso; la capa nace apagada.
6. Bloquean desde el día uno: prompt = ficha, prueba negativa de no publicación y (según quién) el canario.

### 1.2 Por evidencia

**R-1. El punto 1 es la única respuesta al PO, y es la menos fundada en evidencia.** Es un enunciado
**negativo sobre la industria** («no existe una metodología establecida») sostenido por ausencia: ninguna
comisión declara qué buscó y dónde. C-DAC-IND lo rotula honestamente como C. Pero C-GOB-IA y C-DIDACTICA lo
reescriben como afirmación positiva distinta («documentación exigida del sistema tratada como código»; «tres
puertas»), sin más evidencia. Un C no puede ser el dictamen. Pregunta para el jurado: ¿se asienta como
«la mesa no encontró una metodología nombrada» (lo que sí está probado) en lugar de «la industria no la tiene»?

**R-2. Casi todo lo que se propone para el corpus como insumo de IA no tiene caso donde ejercerse.** Lo admiten
C-DOCS-COMO-CONTEXTO (§2.2.1, «control declarado que nadie ejerce»), C-LLMOPS (S-3) y C-DIDACTICA (escalón 8,
«no existe en ninguno de los dos proyectos»): **ninguno de los dos casos recupera documentos**. Índice por
audiencia, canario de contexto, filtro antes del índice, MCP con OAuth 2.1, vigencia que actúa sobre el
índice: todo eso se diseña para un componente que no existe en Lab-Geometria ni en `{servicio-privado}`. Por
la regla de la propia norma («descripción o control», §3.3) es descripción. La lectura dominante lo presenta
como «bloquea desde el día uno»; en estos dos proyectos un control sin objeto ni par rojo/verde no bloquea nada.

**R-3. Las cifras de modelos que viajan en las posiciones no prueban lo que se les hace decir.** C-LLMOPS lo
midió (V-4): 7/11, 8/11 y 11/11 tienen intervalos que se solapan. Sin embargo, la posición «Capa de IA» y
C-DIDACTICA usan «8 → 7/11», «11/11 con atribución falsa» y los puntajes del juez (4,5; 4,2; 2,4; 2,3) como
lecciones. Los puntajes son de un juez **no calibrado** (REQ-IA-14 no medido: lo dicen las mismas partes).
Cualquier frase del dictamen que ordene modelos por esos números contradice G16 §11.4 y ADR-10 de la propia
sesión.

**R-4. Las fuentes de la sesión «Capa de IA» no están en ningún repo.** `DEC-GEO`, `DEC-SP` y `BENCH` son
borradores fuera de los repos; REQ-IA-18 y las actuaciones 009 y 010 no existen en ninguna rama (C-LLMOPS
V-9, C-DIDACTICA E1). Todo lo que se apoya en ellos es C por definición de la norma. Eso incluye media posición:
el razonamiento apagado por contrato, la precarga con `keep_alive=-1`, el 20 s, la regla R2, las dos pistas
falsas que pasan el filtro. **Un expediente público no puede foliar como hallazgo lo que no puede citar por
ruta.**

**R-5. El estado de D-23 está en contradicción y nadie lo resolvió.** La posición «Capa de IA» lo da
«Parcial» (H-6 de su bitácora); C-DAC-IND midió en el `main` de Lab-Documentos un commit «pasa a vigente con
D-23 cerrado (15 SÍ, 1 NO APLICA, 0 NO medido)». C-GOB-IA, C-LLMOPS y C-DIDACTICA responden la pregunta 4
(«¿la firma no humana cumple D-23?») **sin mirar cuál de los dos estados rige**. Si D-23 se cerró por mesa
delegada, la pregunta ya tiene una respuesta de hecho, y las tres comisiones dictaminan contra ella sin decirlo.

**R-6. La premisa «main despliega» sostiene tres propuestas y no está demostrada.** La posición «Capa de IA»
§2.7, C-GOB-IA (§4, último punto) y C-DIDACTICA (§3.2.5: «main despliega con la capa apagada») se apoyan en
ella. C-LLMOPS la puso en duda en el clon; yo la medí en el remoto (R-V1): el único flujo de publicación del
repo es manual. La conclusión «fusionar ≠ poner en uso» sigue valiendo por razones de gobernanza, pero el
**argumento de urgencia** («hay que nacer apagado *porque* main publica») no está sostenido por los flujos
versionados. La presidencia tiene que medir el otro canal antes de que esa frase entre al dictamen.

### 1.3 Por aplicación

**R-7. Lo que la lectura dominante propone cambia un linter común a todo un corpus para resolver dos
proyectos.** Docs-guard es de Lab-Documentos y corre sobre todo su corpus (lo dicen la posición «Capa de IA»
§3.6 y C-DAC-IND §3.2.6). Un `doc_type` nuevo, un campo `revisado_por` y una familia AIL-n afectan a todas
las guías, no sólo a la 16. Ninguna comisión midió cuántos documentos del corpus quedarían en rojo si
`revisado_por` se vuelve obligatorio para `origin` ≠ `human` (todo el corpus generado por agentes, que es
la mayor parte de lo producido este año, incluidos los cinco informes de esta mesa, que llevan `origin:
ia-generated` y ninguno `revisado_por: humano`).

**R-8. Las propuestas sobre `{servicio-privado}` no se pueden aplicar ni verificar desde un expediente
público.** C-DOCS-COMO-CONTEXTO lo dice («no corresponde verificarlo desde un expediente público»). Cualquier
plan que nazca acá para el privado es una recomendación sin quien la aplique en este repo ni evidencia que la
cierre (§4 de la norma, «Quién aplica»).

**R-9. Riesgo de publicación, que ninguna comisión levantó.** Las posiciones y C-DIDACTICA (escalón 7) describen
con detalle una **vulnerabilidad abierta** de `{servicio-privado}`: [redactado S2: defecto de seguridad abierto del validador, informado al responsable], con la frase que la explota [redactada S2]. La lente de seguridad la marcó **bloqueante y sin corregir**.
El alias no protege: el expediente va a un repo público, y describir un bypass no corregido con su entrada de
ejemplo es divulgarlo. Lo mismo, en menor grado, para «[versión del contrato redactada S2]», «[número de expediente privado redactado S2]» y el ejemplo de
atribución con su cifra. **Propuesta: que la presidencia saque la frase de explotación y la versión del
contrato de todo folio que vaya al repo público hasta que el privado lo corrija**, y que C-DIDACTICA no
proponga publicar ese caso como «folio genérico» mientras siga abierto. Es P0 de privacidad y seguridad del
propio expediente.

## 2. Ataque al objetivo, contra el pedido literal

**Lo que pidió el PO**, en dos mensajes:

1. Una pregunta conceptual: *cómo, metodológicamente, en la industria*, el concepto Docs as Code **se integra
   dentro** de una capa de IA.
2. Un formato: una mesa **citando a los expertos de ambas sesiones**, un **expediente de debate**, y que
   **expongan sus conocimientos**.

**Qué se dio por fijo sin que nadie lo pidiera:**

| # | Supuesto | Quién lo fijó | Por qué no está en el pedido |
| --- | --- | --- | --- |
| O-1 | La clase de objeto es «diseño de una norma o decisión» | Todas las comisiones lo copian de la carta | El pedido es una **pregunta y un debate**, no una norma por diseñar. La clase decide que el refutador ataque el «costo de aplicar» y que el dictamen sea sin «depende»: el PO no pidió nada que aplicar |
| O-2 | Hay que responder **catorce preguntas** (siete de cada sesión) | Las posiciones | Las preguntas las formularon las sesiones; el PO hizo **una**. Cuatro de cinco comisiones gastan la mitad de su informe en ellas y la pregunta del PO queda en un párrafo |
| O-3 | La salida incluye propuestas aplicables: `doc_type` nuevo, `revisado_por`, AIL-n, canario, datasheet, huella de unidad, McNemar, ficha de servidor, nueve escalones de cátedra | Las comisiones | El PO pidió «que expongan sus conocimientos», no un plan. Con la regla de la casa («la mesa decide y queda aprobado»), un veredicto sobre esto **se aplicaría sin que el PO lo haya pedido** |
| O-4 | Una comisión de didáctica que diseña un curso | La composición | Ninguna de las dos sesiones trabajaba en docencia de la capa; el pedido no menciona estudiantes. Que Lab-Geometria sea de cátedra justifica una lente, no un plan de nueve escalones |
| O-5 | Un encuadre regulatorio (AI Act, ISO/IEC 42001) | C-GOB-IA | Útil como contexto; pero los dos proyectos no consta que se pongan en el mercado de la Unión Europea, y el Reglamento (UE) 2024/1689 rige por su ámbito territorial. Presentarlo como «lo que exige la industria regulada» sin decir que su aplicabilidad acá no está establecida sobredimensiona la respuesta |

**Salida más chica que cumple el pedido:**

- Un **dictamen corto** que responde la pregunta del PO en un solo punto: «no encontramos una metodología con
  nombre; la práctica observable integra Docs as Code en N puntos», con N decidido por el jurado (ver
  contradicción 1), cada punto con su fuente externa y su ejemplo en estos dos proyectos.
- Las **exposiciones** de cada experto (las dos posiciones y los cinco informes) foliadas como tales: es lo
  que el PO pidió que hagan.
- Las propuestas, en un apartado **«ideas expuestas, no decididas»**, sin veredicto ni plan de aplicación,
  hasta que el PO pida aplicarlas. Esto evita que O-3 se aplique por silencio.

Con eso, el paso 8 vota sólo el dictamen y la composición, y el paso 9 (aplicación) no tiene objeto. Si el
jurado prefiere mantener propuestas, pido que cada una pase la prueba de §3 (costo real) y que las que no
tienen caso donde ejercerse (R-2) queden fuera del plan.

## 3. Costo real de aplicar cada propuesta en estos dos proyectos

Escala C de criterio: **bajo** (un PR chico en un repo), **medio** (cambia un esquema o un linter común, con
par rojo/verde), **alto** (requiere construir un componente que no existe), **no aplicable** (no hay objeto
en ninguno de los dos proyectos).

| # | Propuesta (quién) | Costo en Lab-Geometria | Costo en `{servicio-privado}` | Valor demostrado hoy |
| --- | --- | --- | --- | --- |
| K-1 | Prueba prompt del código = ficha, bloqueante (todos) | Bajo; ya está la ficha en `ai-layer/01` | Existe según la posición (C) | Alto: determinista. **Es la única propuesta con costo bajo, objeto y valor en los dos** |
| K-2 | `revisado_por` en el esquema de docs-guard (Capa de IA; GOB; DOCS-CONTEXTO; LLMOPS) | Medio, y **no se paga en Geometría sino en Lab-Documentos**: el esquema es común a todo el corpus (R-7). Opcional no controla nada; obligatorio pone en rojo el corpus generado por agentes | Igual, si usa docs-guard | Medio; la pregunta real (quién firma cuando el PO delegó) no la resuelve un campo |
| K-3 | `doc_type` «ficha de capacidad» con esquema (GOB con ~15 campos; LLMOPS; DIDACTICA; DAC-IND) | Medio: esquema + plantilla + una instancia | Medio, con modelos por código y tabla fuera del repo | Medio; hay **una** capacidad por proyecto. Una plantilla en la guía 16 cuesta menos y no toca el linter común |
| K-4 | Familia AIL-n, cinco controles (Capa de IA) | Alto: AIL-3 necesita la «huella de la unidad» (F-4), que no existe | Alto, y no verificable desde acá | AIL-1 = K-1; AIL-2 existe en parte (`resumir.py`). El resto, sin implementación previa |
| K-5 | Huella de la unidad versionada (LLMOPS F-4) | Medio-alto: definir qué entra (prompt, plantillas, validador, modelo+digest, opciones, banco, versión de métrica) y un control que la compare | Alto | Es condición de K-4; sin K-4 no tiene consumidor |
| K-6 | Índice por audiencia, filtro antes del índice, canario de contexto, `llms.txt` desde la matriz, MCP con OAuth (DAC; DOCS-CONTEXTO; GOB) | **No aplicable**: no hay recuperación | **No aplicable**: no hay recuperación | Ninguno en estos casos (R-2) |
| K-7 | Prueba negativa de no publicación **conectada a CI** (DAC; todos) | Bajo: ya hay controles; falta el par | Bajo-medio: según la posición DocsAsCode la prueba existe y no corre en ningún flujo (C) | Alto en el privado: es el único bloqueo que hoy no corre. **Segunda propuesta que pasa la prueba de costo** |
| K-8 | Calendario de promoción avisa → bloquea con fecha (DAC) | Bajo | Bajo | Medio; el hallazgo del especialista externo (main verde con contradicción) lo respalda |
| K-9 | Datasheet del banco (GOB; LLMOPS) | Bajo: un documento | Bajo | Bajo-medio |
| K-10 | McNemar entre modelos (LLMOPS F-1) | Bajo si los registros crudos son por caso (lo son: `registro-*.jsonl`) | Bajo si hay registros por caso | **Bajo**: con M = 11 la prueba apareada tampoco tendrá potencia; lo que falta es banco, no estadístico |
| K-11 | Ficha de servidor compartido por alias (GOB; LLMOPS) | Bajo-medio | Bajo-medio | Medio; resuelve la pregunta 7 de la Capa de IA |
| K-12 | Nueve escalones de cátedra (DIDACTICA) | Alto: material nuevo; escalón 5 depende de folios que no existen; escalón 8 de un componente que no existe | Escalón 7 depende de publicar la vulnerabilidad de R-9 | No pedido (O-4) |
| K-13 | Ensayo ciego como compuerta de publicación del conocimiento de la capa (DAC prop. 7) | Alto: cuatro rondas en el 0003 y ninguna pasó | — | Su único resultado fue «borrador ensayado, no probado»; GOB y DAC-IND ya lo descartan como compuerta |
| K-14 | Ensayo ciego de la ficha para decidir puesta en uso (GOB §3.1.6) | Alto: banco de fichas con defectos sembrados para **una** ficha por proyecto | Igual | Sin antecedente |
| K-15 | Prompt de sistema y plantillas como un mismo contrato (Capa de IA §2.1) | Bajo: corregir regla 7 o las tres plantillas | — | Alto: hay un defecto medido (C hasta foliar) |

**Lectura del refutador:** sólo K-1, K-7, K-8, K-15 y, en segundo término, K-9 y K-11 tienen costo bajo y
objeto en estos dos proyectos. K-6 y K-12 no tienen objeto. K-2, K-3 y K-4 cargan su costo en un linter común
de otro repo y deberían ir, si van, como plantilla en la guía 16 antes que como esquema en docs-guard.

## 4. Citas externas dudosas

Verifiqué cada fuente contra lo que conozco de la bibliografía; no inventé ninguna corrección de cláusula.
Las que no tienen observación están bien citadas (autor, año, lugar y numeración coinciden).

| # | Cita | Dónde | Observación | Acción propuesta |
| --- | --- | --- | --- | --- |
| X-1 | Fowler (2006), «Contract Test» | C-LLMOPS §1.7 | La entrada «ContractTest» del sitio de Fowler es de **2011**, no de 2006. Robinson (2006), «Consumer-Driven Contracts», sí es de 2006 | Corregir el año o citar sólo a Robinson |
| X-2 | Gentle, *Docs Like Code* (2017): «Just Write Click» (C-DAC-IND) frente a «Lulu Press» (C-DIDACTICA) | Dos informes | La primera edición es autoeditada (impresa por Lulu); «Just Write Click» es el sitio de la autora. Las dos comisiones citan editoriales distintas para el mismo libro | Unificar: Gentle, A. (2017). *Docs Like Code*. Autoedición |
| X-3 | Hattie y Timperley (2007) y Shute (2008) para «una retroalimentación errónea perjudica más que su ausencia» | C-DIDACTICA §1.6; posición «Capa de IA» | Las dos obras documentan que la retroalimentación puede tener efectos negativos, pero la afirmación comparativa «más que su ausencia» no es su tesis en esos términos. La fuente clásica de efectos negativos es Kluger y DeNisi (1996), *Psychological Bulletin*, 119(2) | Bajar la frase a «puede perjudicar» o sumar Kluger y DeNisi (1996) |
| X-4 | Reglamento (UE) 2024/1689, Anexo III punto 3 «una pista no hace nada de eso» | C-GOB-IA §1.4 | El punto 3 incluye sistemas que evalúan resultados de aprendizaje **también cuando se usan para orientar el proceso de aprendizaje**. Una pista no evalúa, pero la exclusión no es tan limpia como dice el informe; y, sobre todo, falta establecer la aplicabilidad territorial (O-5) | Citar el Anexo III sin glosa terminante y declarar que la aplicabilidad no está establecida |
| X-5 | Reglamento (UE) 2024/1689, artículo 14 como fundamento de la firma humana de la puesta en uso | C-GOB-IA §1.3 y §3.2.4 | El artículo 14 rige **sólo** para alto riesgo, y el mismo informe concluye que ninguno de los dos casos lo es. Usarlo como fundamento de un requisito para estos casos es contradictorio dentro del informe | Fundar la firma en NIST AI RMF (MANAGE) y en ISO/IEC 42001 7.5, sin el artículo 14 |
| X-6 | AGENTS.md «bajo custodia de la Agentic AI Foundation de la Linux Foundation» | C-DOCS-COMO-CONTEXTO §1.1.2 | La comisión lo toma de CA-7 sin verificarlo. Coincide con lo anunciado a fines de 2025, pero es un hecho institucional reciente y cambiante | Mantener con «según CA-7» y fecha de consulta, como ya lo dice |
| X-7 | NIST AI RMF 1.0, función MEASURE, como fuente de «banco, rúbrica y oráculo se escriben antes de correr» | Posición «Capa de IA» §2.2 | MEASURE pide métodos y métricas documentados; «antes de correr» es una lectura de la sesión, no una formulación de la norma | Citar NIST sin atribuirle el «antes» |
| X-8 | «Biggs y Tang» y «Procida, Diátaxis» sin año | C-DIDACTICA | No es error, pero la regla de la clase pide autor **y año**: Biggs y Tang tienen ediciones con año; Diátaxis se cita s. f. con fecha de consulta | Completar |
| X-9 | Zheng et al. (2023) en «NeurIPS» | C-LLMOPS; C-DIDACTICA | Correcto, en el carril *Datasets and Benchmarks* de NeurIPS 2023 | Sin cambio; precisar el carril si se quiere |

Sin observación (verificadas): Mitchell et al. 2019; Gebru et al. 2021, CACM 64(12); Arnold et al. 2019, IBM
JRD 63(4/5); Nygard 2011; Clopper y Pearson 1934, *Biometrika* 26(4); Brown, Cai y DasGupta 2001, *Statistical
Science* 16(2); McNemar 1947, *Psychometrika* 12(2); Strathern 1997, *European Review* 5(3); Manheim y Garrabrant
2018; Sculley et al. 2015; Breck et al. 2017; Liang et al. (HELM) 2022/2023; Greshake et al. 2023; Carlini et
al. 2019; Willison 2025; Lewis et al. 2020; Saltzer y Schroeder 1975, *Proc. IEEE* 63(9); W3C PROV-O 2013; RFC
9728 (2025); RFC 8707 (2020); MCP revisión 2025-06-18; OWASP Top 10 for LLM Applications 2025 (LLM01, 02, 05,
06, 07, 08, 09, 10 con sus títulos correctos); NIST AI 100-1 (2023); NIST AI 600-1 (2024) y sus riesgos
nombrados; ISO/IEC 42001:2023 (7.5, información documentada, estructura armonizada); ISO/IEC 23894:2023;
ISO/IEC 42005:2025; Winters, Manshreck y Wright 2020; Humble y Farley 2010; Hodgson 2017; Forsgren, Humble y Kim
2018; OpenAPI 3.1.0; JSON Schema 2020-12; Biggs 1996; Anderson y Krathwohl 2001; Collins, Brown y Newman 1989;
van Merriënboer 1997 y 2007; Sweller 1988; Sweller y Cooper 1985; Renkl y Atkinson 2003; Wood, Bruner y Ross
1976; CS2023; SWEBOK v4.0; Ribeiro et al. 2020; Huyen 2022 y 2025; Howard 2024 (`llms.txt`).

## 5. Contradicciones entre comisiones (para el paso 7)

1. **La respuesta misma a la pregunta del PO.** C-DAC-IND: Docs as Code entra «en **dos** puntos y sólo en
   dos» (gobierno de los artefactos de la capa; canal de publicación a consumidores máquina). C-DIDACTICA:
   «**tres** puertas» (suma «lo que la IA escribe es borrador que pasa por revisión»). C-GOB-IA: la integración
   «**no es** Docs as Code dentro de la capa de IA» sino la documentación exigida del sistema tratada como
   código. Tres respuestas distintas a la única pregunta del pedido.
2. **¿La capa filtra por `delivery`?** C-DAC-IND: no filtra, «a lo sumo vuelve a comprobar» y eso es seguridad.
   C-LLMOPS: no filtra, comprueba la huella del corpus. C-DIDACTICA: verifica y **no** filtra (dos fuentes de
   verdad confunden). C-GOB-IA: aplica el mismo filtro «como segunda barrera». C-DOCS-COMO-CONTEXTO: filtra de
   nuevo por la identidad de la sesión, defensa en profundidad, y si discrepan gana el más restrictivo.
3. **`AGENTS.md`: documentación o configuración.** C-DAC-IND y C-DOCS-COMO-CONTEXTO: documentación (esta última,
   con `delivery` obligatorio). C-LLMOPS: **configuración**, dentro de la unidad versionada, con prueba de
   igualdad contra una ficha. C-DIDACTICA: configuración que se documenta. C-GOB-IA: información documentada
   y además configuración que no se distribuye por `delivery`, lo que choca con C-DOCS-COMO-CONTEXTO.
4. **Los P0 de K 1.4.** C-DAC-IND, C-GOB-IA, C-LLMOPS y C-DIDACTICA: se integra sobre el borrador rotulado.
   C-DOCS-COMO-CONTEXTO: para lo que alimenta un índice, **se cierran antes**.
5. **El canario.** C-GOB-IA: bloquea desde el principio, sin distinguir. C-DAC-IND: no es determinista, lo deja a
   seguridad. C-DOCS-COMO-CONTEXTO: bloquea en el contexto armado y sólo avisa en la respuesta.
6. **Dónde va AIL-n.** C-DAC-IND: en docs-guard sólo (1) y (2), el resto en la guía 16. C-GOB-IA: completitud y
   vigencia de la ficha en docs-guard, lo que compara con código en la guía 16. C-LLMOPS: **todo** en docs-guard
   como familia opcional. C-DOCS-COMO-CONTEXTO: en docs-guard sólo procedencia y entrega de lo que entra al
   contexto.
7. **Firma humana cuando el PO delegó.** C-DAC-IND: la firma es la aprobación del PR o del merge por el PO.
   C-GOB-IA: la delegación cubre el merge y **no** la puesta en uso; la firma va en la decisión de puesta en uso.
   C-LLMOPS: basta para fusionar, no para encender. C-DIDACTICA: la firma es del **docente responsable** y no se
   delega. Tres firmantes distintos para el mismo campo.
8. **`lee-ia` / `escribe-ia`.** C-DAC-IND: sobran los dos (duplican `origin`). C-DOCS-COMO-CONTEXTO: sobra
   `lee-ia`, **no** sobra `escribe-ia`.
9. **Qué ensaya el aplicador ciego.** C-DAC-IND, C-LLMOPS, C-DIDACTICA: al agente que especifica con el
   conocimiento. C-GOB-IA: a la **ficha de capacidad**, para decidir la puesta en uso. C-DOCS-COMO-CONTEXTO: al
   **contexto armado**, con preguntas que tientan la recuperación. Tres objetos de ensayo distintos.
10. **Herramientas como OpenAPI.** C-LLMOPS (F-5): la herramienta se declara en OpenAPI/JSON Schema con prueba de
    contrato. C-DOCS-COMO-CONTEXTO (§2.3.2): en MCP la herramienta se descubre por el protocolo y el equivalente
    del 404 es que no aparezca en la lista; el OpenAPI por audiencia vale sólo para lo expuesto por HTTP.
11. **Existencia de `EXP3/208`.** C-DAC-IND: está en el `main` remoto (commit citado). C-DIDACTICA: no lo localizó
    y lo deja en C. Mi medición (R-V2) da la razón a C-DAC-IND; la diferencia es de copia local.
12. **Estado de D-23.** Posición «Capa de IA»: «Parcial». C-DAC-IND: el `main` de Lab-Documentos lo da cerrado.
    C-GOB-IA, C-LLMOPS y C-DIDACTICA dictaminan «queda Parcial» sin resolver cuál rige (R-5).
13. **«Main despliega».** C-GOB-IA y C-DIDACTICA lo dan por hecho; C-LLMOPS lo pone en duda; R-V1 no lo
    encuentra en los flujos del repo (R-6).
14. **Corrida: documento o evidencia.** C-DAC-IND: «evidencia» (el resumen aparte es documento). C-GOB-IA,
    C-LLMOPS, C-DIDACTICA: «las dos, en dos piezas». C-DOCS-COMO-CONTEXTO: si se indexa, documento con
    `delivery`. En el fondo convergen; la diferencia es de rótulo y conviene que el dictamen use uno solo.
15. **Qué sobra de las 13 familias de controles.** C-GOB-IA: no bloquear la capa por ellas. C-DIDACTICA: sobran
    para el estudiante. Ninguna otra comisión las trata; no es contradicción de fondo pero sí de alcance, y el
    jurado no tiene base para decidirlo (nadie las midió sobre la capa).

## 6. Preguntas que dejo al jurado

1. ¿Se reclasifica el objeto a la salida más chica de §2 (dictamen + exposiciones + ideas no decididas), dado
   que el PO no pidió aplicar nada (O-1, O-3)?
2. ¿Se saca del expediente público la descripción de la vulnerabilidad R2 de `{servicio-privado}` con su
   entrada de ejemplo, hasta que se corrija (R-9)?
3. ¿Cuál de las tres respuestas de la contradicción 1 es el dictamen, o se asienta que la mesa no tiene una sola?
4. ¿Se mide el estado real de D-23 y el canal real de publicación de Lab-Geometria antes de que cualquier frase
   que dependa de ellos entre al dictamen (R-5, R-6)?
5. ¿Las propuestas sin objeto en estos dos proyectos (K-6, K-12) quedan fuera de cualquier plan?

## 7. Lo que revisé y está bien

- C-LLMOPS midió en vez de opinar: V-2, V-3 y V-4 son recálculos verificables, y V-8 resultó cierto en el
  remoto (R-V1).
- C-DAC-IND marca con honestidad su tesis central como C y detectó las dos inconsistencias de estado más
  importantes del expediente (D-23 y la copia local desalineada).
- C-DOCS-COMO-CONTEXTO separa el canario en contexto armado (determinista) y en respuesta (no determinista):
  es la distinción que resuelve parte de la contradicción 5.
- Todas las comisiones declaran su no-competencia y la respetan; ninguna escribió máquinas, direcciones ni
  rutas del host en sus folios (barrido de lectura sobre los siete folios).
- Las citas externas son, en su gran mayoría, reales y bien numeradas (§4).

Sigue: incorporar el informe siguiente · presidencia de la mesa
