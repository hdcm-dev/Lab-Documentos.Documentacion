| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-03 |
| Autor | Jurado de veredicto |
| Corrige | — |

Incorporado verbatim desde la ruta de trabajo del rol. Lo que sigue a esta línea, hasta el pase, es la pieza.

---
doc_type: informe-jurado
title: Veredicto del jurado — Docs as Code dentro de una capa de IA (expediente 0004)
status: borrador
origin: ia-generated
confidence: media
owner: jurado de veredicto del expediente 0004
last_review: 2026-11-03
audience: [PO, mesa conjunta del expediente 0004]
---

# Veredicto del jurado (expediente 0004)

**Leído:** las dos posiciones (sesión DocsAsCode y sesión «Capa de IA»), los cinco informes de comisión
(C-DAC-IND, C-DOCS-COMO-CONTEXTO, C-GOB-IA, C-LLMOPS, C-DIDACTICA), el informe del refutador y
`Knowledge-Mesa-De-Expertos-A-Pedido.md` §2, §3, §4, §7 y §8.

**Votantes.** Tres votos independientes, razonados por separado: **I** (industria: qué hace la práctica
observable), **G** (gobernanza: qué pide un sistema de gestión y de riesgos), **A** (aplicación: qué cuesta y
qué tiene objeto en Lab-Geometria y en `{servicio-privado}`). Se vota por mayoría; la disidencia se asienta.

**Clase de objeto.** El jurado mantiene «diseño de una norma o decisión» (§2.2) **sólo para la forma del
cierre** (cada pregunta por separado, sin «depende», fuentes externas citadas). Acepta el reparo O-1/O-3 del
refutador en su consecuencia: lo que el PO pidió es una respuesta y una exposición; las propuestas se adoptan
**sólo** si tienen objeto y costo bajo en estos dos proyectos, y su aplicación es de quien convocó, nunca del
jurado ni del panel (§4, «Quién aplica»). Voto 3–0.

**Regla de evidencia aplicada.** Un hallazgo `C` sólo funda pregunta (§3.2). Lo que se apoya en borradores
fuera de los repos (R-4) entra al dictamen como experiencia expuesta, no como hecho foliado. Las cifras de
modelos no ordenan modelos: los intervalos se solapan (C-LLMOPS V-4; R-3).

---

## 1. Respuesta a la pregunta del PO

> «¿Cómo, metodológicamente, en la industria, este concepto de Docs as Code se integra dentro de la capa de IA?»

**Dictamen (voto 3–0 en el enunciado; 2–1 en el número de puntos, ver abajo):**

1. **La mesa no encontró una metodología con nombre** que integre Docs as Code «dentro» de una capa de IA. Se
   asienta así —lo probado es la búsqueda de la mesa, no la ausencia en la industria (R-1)—. Ninguna norma
   nombra Docs as Code; lo que sí existe es la práctica de Docs as Code (Write the Docs, guía «Docs as Code»,
   s. f.; Gentle, *Docs Like Code*, 2017, autoedición; Winters, Manshreck y Wright, *Software Engineering at
   Google*, O'Reilly, 2020, capítulo «Documentation») y los marcos que piden **información documentada y
   controlada** del sistema de IA (ISO/IEC 42001:2023, cláusula 7.5; NIST AI 100-1, AI RMF 1.0, 2023; NIST AI
   600-1, 2024).

2. **Lo observable en la industria es la extensión del mismo principio** —«si es texto que gobierna el
   sistema, va al repo, por PR, con prueba»— y entra a una capa de IA **por tres puertas**:

   | Puerta | Qué se trata como código | Fuentes | Ejemplo en estos proyectos |
   | --- | --- | --- | --- |
   | **1. Gobierno de los artefactos de la capa** | Prompt de sistema y plantillas de respaldo, banco de evaluación, rúbrica, definición de la métrica con versión, ADR con «deja de valer si», ficha del sistema por capacidad | Mitchell et al. (2019), *Model Cards*; Gebru et al. (2021), *Datasheets for Datasets*, CACM 64(12); Arnold et al. (2019), *FactSheets*, IBM JRD 63(4/5); Nygard (2011); Sculley et al. (2015), NeurIPS | Prueba «prompt del código = ficha» (Lab-Geometria y `{servicio-privado}`); `AIL/ensayos/` con recálculo sin modelo |
   | **2. Documentación como fuente de la IA** | Lo que el corpus entrega a consumidores máquina (índice de recuperación, `llms.txt`, `AGENTS.md`, recursos MCP) es **un destino de publicación más**, que hereda el filtro de compilación por audiencia, y su contenido es **entrada no confiable** | Howard (2024), propuesta `llms.txt`; especificación MCP revisión 2025-06-18; OWASP Top 10 for LLM Applications 2025 (LLM01); Lewis et al. (2020), RAG | docs-guard AI-1 a AI-5 sobre el corpus; en estos dos casos **no hay recuperación de documentos** |
   | **3. Lo que la IA escribe** | Entra como borrador con procedencia declarada (`origin`, `confidence`) y no es fuente ni habilita puesta en uso hasta su aprobación | W3C PROV-O (2013); NIST AI 600-1 (procedencia de contenido) | Esquema de frontmatter de docs-guard; las plantillas de Geometría redactadas por un agente y marcadas «definitivas» antes de revisión |

3. **Dónde termina Docs as Code**, y lo que sigue es otra disciplina: el **comportamiento en ejecución** del
   modelo (ingeniería de evaluación: NIST AI RMF, función MEASURE), el **permiso del usuario en tiempo de
   ejecución** (seguridad; Saltzer y Schroeder, 1975, *Proc. IEEE* 63(9)), la **verdad** del contenido y la
   **decisión de puesta en uso** (NIST AI RMF, función MANAGE; Humble y Farley, *Continuous Delivery*, 2010;
   Hodgson, «Feature Toggles», 2017). Fusionar no es encender.

4. **Por qué la industria lo hace así** (encuadre de C-GOB-IA, aceptado como fundamento y no como
   tercera respuesta rival): los marcos de gestión piden que la documentación del **sistema** —no del modelo—
   esté identificada, revisada, aprobada, con control de cambios y conservada (ISO/IEC 42001:2023, 7.5), y el
   repositorio con PR es la forma más barata de cumplirlo. El Reglamento (UE) 2024/1689 se cita sólo como
   contexto: **su aplicabilidad a estos dos proyectos no está establecida** (O-5, X-4, X-5).

**Votación del número de puertas.** I: dos (C-DAC-IND; la tercera es un caso de la primera). G: tres (la
procedencia de lo generado es un control propio en NIST AI 600-1). A: tres (es la única que tiene un defecto
medido en estos proyectos). **Tres puertas, 2–1.** La disidencia de I se asienta: la puerta 3 puede leerse
como regla de la puerta 1 aplicada a otro autor.

**Contradicción 1 del refutador resuelta:** las tres respuestas no son rivales; «dos puntos» (C-DAC-IND) y
«tres puertas» (C-DIDACTICA) son el qué, y «documentación exigida del sistema tratada como código» (C-GOB-IA)
es el porqué.

---

## 2. Respuestas a las preguntas abiertas

### 2.1 Las siete de la sesión DocsAsCode

| # | Pregunta | Respuesta | Votos |
| --- | --- | --- | --- |
| D-1 | ¿El filtro por `delivery` vive en el documentador o en la capa? | **Fuente de verdad única: el documentador**, que genera un corpus por audiencia con su huella. La capa **no filtra ni amplía**: verifica que consume el corpus de la audiencia de la sesión (huella) y, si no coincide, rechaza. Dos filtros con reglas propias son dos fuentes de verdad | 2–1 (G disiente: segunda barrera que filtra de nuevo, gana el más restrictivo) |
| D-2 | ¿Qué identidad usa la capa para recuperar? ¿Cómo se prueba? | **La del usuario final, propagada**; nunca la del servicio ni la del agente. Se prueba con una **prueba de contrato negativa** por rol y por herramienta en CI, más el caso trampa del banco. En `{servicio-privado}` falta la prueba de que ningún argumento ejecutado trae el identificador de aplicación | 3–0 |
| D-3 | ¿Lo que escribe un agente cuenta como fuente antes de la aprobación humana? | **No.** Rótulo: `origin: ia-generated` (o `ia-assisted`) con `confidence`; no entra a banco, plantilla ni corpus de una capa, ni habilita puesta en uso | 3–0 |
| D-4 | ¿`AGENTS.md` y equivalentes: documentación o configuración? | **Configuración que se documenta**: vive en el repo con frontmatter (audiencia y vigencia) porque es texto que gobierna un agente, y se trata como código (PR, revisión). **No se distribuye por `delivery`**: es instrucción para el agente del repo, no contenido publicado | 2–1 (I disiente: documentación plena, con `delivery`) |
| D-5 | ¿Qué bloquea desde el principio, sin «avisa»? | Sólo lo **determinista con objeto en el proyecto**: (a) prompt del código = ficha; (b) prueba negativa de no publicación conectada a CI; (c) recálculo del resumen de toda corrida citada. El **canario** bloquea **en el contexto armado** y sólo avisa en la respuesta, y **no se implementa donde no hay recuperación** (hoy, ninguno de los dos) | 3–0 en (a)–(c); 2–1 en el canario (G: bloquea sin distinguir) |
| D-6 | ¿Cómo se ensaya con aplicador ciego cuando el resultado son respuestas de un modelo? | **Dos ensayos distintos.** El aplicador ciego ensaya al **agente que especifica** con el conocimiento (oráculo: checklist). Las **respuestas del modelo** se ensayan con banco y validadores deterministas recalculables, tasa k/M con IC95 de Clopper-Pearson (1934); lo que no tiene oráculo (utilidad didáctica, atribución) lo fija una persona, y un juez automático vale sólo calibrado contra ella (Zheng et al., 2023, NeurIPS, carril *Datasets and Benchmarks*) | 3–0 |
| D-7 | ¿Los cuatro P0 de K 1.4 se cierran antes de integrar? | **Se integra sobre el borrador, rotulado**, y el rótulo **impide la puesta en uso** mientras un P0 citado esté abierto. Para lo que alimente un índice de recuperación, se cierran antes; hoy no hay tal índice | 3–0 |

### 2.2 Las siete de la sesión «Capa de IA»

| # | Pregunta | Respuesta | Votos |
| --- | --- | --- | --- |
| C-1 | ¿Ficha de capacidad: `doc_type` con esquema en docs-guard o forma libre en `AIL/`? | **Plantilla en la guía 16 (y en `AIL/`)**, no `doc_type` en docs-guard por ahora: hay una capacidad por proyecto y docs-guard es común a todo el corpus de Lab-Documentos (R-7). Pasa a `doc_type` con esquema cuando haya una segunda capacidad o una segunda guía que la use | 2–1 (G disiente: `doc_type` ya) |
| C-2 | ¿Dueño del arnés de evaluación? | **La capa, como código**, con pruebas contra la implementación; el arnés invoca el validador del producto en lugar de reimplementarlo. El expediente guarda sólo la salida, congelada | 3–0 |
| C-3 | ¿Corrida rotulada: documento o evidencia? | **Dos piezas, un rótulo**: los registros crudos son **evidencia** inmutable con SHA-256; el resumen que los cita es **documento**, con frontmatter y R-PRIV, y declara la versión de la métrica contra la que se midió | 3–0 |
| C-4 | ¿Cómo se firma la revisión humana si el PO delegó en mesas? | La delegación **cubre la fusión y no la puesta en uso**. La firma humana va en la **decisión de encendido**, del PO (en Lab-Geometria, el docente responsable si lo hay), fundada en NIST AI RMF, MANAGE, e ISO/IEC 42001:2023, 7.5 (no en el artículo 14 del AI Act, X-5). Antes de aplicar, **se mide qué estado de D-23 rige** (R-5) | 3–0 |
| C-5 | ¿Nombre del modelo en repo público junto a una decisión de un producto privado? | **No.** En el repo público el modelo se nombra sólo en decisiones del producto público; las de `{servicio-privado}` van por código, con la tabla fuera del repo | 3–0 |
| C-6 | ¿AIL-n en docs-guard o en la guía 16? | **En la guía 16 (`tools/` y `Compuertas/`)**, como compuertas de la capa. A docs-guard sólo sube lo que mira texto del corpus común (procedencia y entrega), y sólo si una segunda guía lo pide | 2–1 (I: (1) y (2) en docs-guard) |
| C-7 | ¿Dónde se documenta la carga cruzada de un servidor de modelos compartido? | En una **ficha de servidor por alias**: parámetros que el arnés fija y verifica (contexto, permanencia, paralelismo, cola), sin topología ni dirección; la dirección vive sólo en el secreto del despliegue | 3–0 |

### 2.3 Las cinco del refutador

| # | Pregunta | Respuesta | Votos |
| --- | --- | --- | --- |
| R-Q1 | ¿Se reclasifica a la salida más chica? | **En parte.** Dictamen + exposiciones foliadas verbatim + propuestas; pero se adoptan sólo las de §3, con objeto y costo bajo; el resto va a «ideas expuestas, no adoptadas» | 2–1 (A: salida más chica sin adopciones) |
| R-Q2 | ¿Se saca la descripción de la vulnerabilidad del validador de `{servicio-privado}`? | **Sí, P0.** Se retiran de todo folio que vaya al repo público la frase de explotación, la versión del contrato y el ejemplo con su cifra, hasta que el privado lo corrija; se reemplazan por «defecto de seguridad abierto del validador, informado al responsable» | 3–0 |
| R-Q3 | ¿Cuál respuesta es el dictamen? | La de §1: tres puertas, con el porqué de C-GOB-IA | 2–1 |
| R-Q4 | ¿Se miden D-23 y el canal real de publicación antes? | **Sí.** Ninguna frase que dependa de «main despliega» o del estado de D-23 entra como hecho. «Fusionar no es poner en uso» se sostiene por gobernanza, no por urgencia | 3–0 |
| R-Q5 | ¿Fuera de plan las propuestas sin objeto (K-6, K-12)? | **Sí**, a deuda | 3–0 |

---

## 3. Propuestas adoptadas, en orden

Aplica **quien convocó la mesa**, no el jurado (§4). Las de `{servicio-privado}` son recomendaciones para su
responsable: no se aplican ni se verifican desde este repo público (R-8).

| Orden | Propuesta | Dónde | Por qué primero | Votos |
| --- | --- | --- | --- | --- |
| 1 | **Barrido del expediente**: retirar la descripción del defecto abierto del validador privado (R-9) y verificar que ningún folio lleve nombre de modelo junto a decisiones del privado | Expediente 0004 | P0 de seguridad del propio expediente | 3–0 |
| 2 | **Medir antes de afirmar**: el estado vigente de D-23 en Lab-Documentos y el canal real de publicación de Lab-Geometria | Lab-Documentos, Lab-Geometria | Sostiene C-4 y la frase «fusionar ≠ encender» | 3–0 |
| 3 | **K-1: prueba «prompt del código = ficha», bloqueante** | Lab-Geometria (existe la ficha en `ai-layer/01`); en `{servicio-privado}` ya existe según su sesión | Determinista, sin falsos positivos, objeto en los dos | 3–0 |
| 4 | **K-15: prompt y plantillas de respaldo como un solo contrato** (corregir la contradicción regla 7 / tres plantillas) y retirar el rótulo «definitivas» hasta revisión humana | Lab-Geometria | Defecto medido; es la puerta 3 | 3–0 |
| 5 | **K-7: prueba negativa de no publicación conectada a CI**, con su par rojo/verde | `{servicio-privado}` (existe y no corre); Lab-Geometria, el par | Único bloqueo que hoy no corre | 3–0 |
| 6 | **Recálculo de toda corrida citada en CI** (`resumir.py`, recálculo de oráculos) y corrida declara versión de métrica | Lab-Geometria | Ya existe en parte; cierra C-3 | 3–0 |
| 7 | **K-8: calendario «avisa → bloquea» con fecha** en cada control nuevo | Los dos | Costo bajo; evita el verde con contradicción | 3–0 |
| 8 | **Plantillas en la guía 16**: ficha por capacidad (con `revisado_por` como campo de la plantilla, no del esquema común), datasheet del banco (K-9) y ficha de servidor por alias (K-11) | Lab-Documentos, guía 16; instancias en Lab-Geometria | Documentan sin tocar el linter común | 2–1 (G: al esquema de docs-guard) |

**No adoptadas (ideas expuestas):** K-2 como campo obligatorio de docs-guard, K-3 como `doc_type`, K-4
(AIL-3 a AIL-5), K-5 huella de la unidad, K-6 índice/canario/`llms.txt`/MCP, K-10 McNemar, K-12 escalones de
cátedra, K-13 y K-14 ensayo ciego como compuerta.

---

## 4. Deuda declarada

1. **Sin recuperación de documentos en ningún caso**: el filtro por audiencia antes del índice, el canario de
   contexto, `llms.txt` por audiencia y MCP con autorización quedan diseñados y no ejercidos (§3.3,
   «descripción o control»).
2. **AIL-3 a AIL-5 y la huella de la unidad versionada** (invalidación automática de una decisión cuando
   cambia prompt, modelo, opciones o banco): hoy lo vigila una persona.
3. **`revisado_por` en el esquema común de docs-guard**: no se midió cuántos documentos del corpus quedarían en
   rojo (R-7).
4. **Juez automático sin calibrar** (concordancia con docente no medida): sus puntajes no fundan decisiones.
5. **Bancos chicos** (M = 11): los intervalos se solapan; lo que falta es banco, no estadístico.
6. **Fuentes de la sesión «Capa de IA» fuera de los repos** (decisiones, actuaciones, un requisito): todo lo
   que se apoya en ellas sigue en `C` hasta foliarse por ruta.
7. **Estado de D-23 y canal de publicación de Lab-Geometria** sin medir (orden 2).
8. **Prueba de que ningún argumento ejecutado trae el identificador de aplicación** en `{servicio-privado}`:
   no existe.
9. **Defecto abierto del validador de `{servicio-privado}`**: corrección a cargo de su responsable; el
   expediente no lo describe.
10. **Citas a corregir** en los informes (sin editar los folios, que van verbatim): Fowler «Contract Test» es
    de 2011; Gentle (2017) es autoedición; «más que su ausencia» baja a «puede perjudicar» con Kluger y
    DeNisi (1996), *Psychological Bulletin* 119(2); NIST MEASURE sin el «antes»; Biggs y Tang y Diátaxis con
    año o fecha de consulta; AI Act sin glosa terminante y sin el artículo 14 como fundamento.
11. **Ensayo ciego del conocimiento de la capa**: cuatro rondas en el expediente 0003 sin pasar; queda como
    método para el agente que especifica, no como compuerta.
12. **Una sola ronda**: el cierre es **por decisión**, no por criterio (§4, «Criterio de corte»).

Sigue: incorporar el informe siguiente · presidencia de la mesa
