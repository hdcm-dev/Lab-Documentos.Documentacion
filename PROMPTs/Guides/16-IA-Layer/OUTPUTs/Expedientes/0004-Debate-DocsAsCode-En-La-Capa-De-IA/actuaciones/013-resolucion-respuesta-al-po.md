| Campo | Valor |
| --- | --- |
| Tipo | resolucion |
| Fecha | 2026-11-03 |
| Autor | Presidencia de la mesa conjunta |
| Corrige | — |

| Campo | Valor |
| --- | --- |
| Reintegra | ninguna |
| Clase del cambio | Ninguna especificación cambia por este folio: es un dictamen de debate. Lo adoptado (§4) lo aplica quien convocó, en el repositorio que corresponda, con su propio artefacto |

# Resolución — la respuesta de la mesa al Product Owner

Funda: el veredicto del jurado (folio 011), que leyó las dos posiciones (003, 004), los cinco informes (005 a
009) y el refutador (010). La presidencia no vota: ordena y traduce. Lo que agrega va marcado **(agregado de la
presidencia)**.

## 1. Respuesta al PO

**Pregunta (folio 001):** ¿cómo, metodológicamente, en la industria, Docs as Code se integra dentro de una capa
de IA?

**Respuesta, en corto:**

1. **No hay una metodología con nombre** que lo haga. Lo que la mesa encontró —y esto prueba su búsqueda, no la
   ausencia en la industria— es la práctica de Docs as Code (Write the Docs; Anne Gentle, *Docs Like Code*,
   2017; Winters, Manshreck y Wright, *Software Engineering at Google*, O'Reilly, 2020) y marcos de gestión que
   piden **información documentada y controlada** del sistema de IA (ISO/IEC 42001:2023, 7.5; NIST AI 100-1,
   AI RMF 1.0, 2023; NIST AI 600-1, 2024). Ninguna norma nombra Docs as Code.
2. **Lo que se observa es el mismo principio extendido:** «si es texto que gobierna el sistema, va al repo, por
   PR, con prueba». Entra a la capa de IA **por tres puertas** (2–1; la disidencia lee la tercera como caso de la
   primera):
   - **Puerta 1, gobierno de los artefactos de la capa.** Prompt de sistema y plantillas de respaldo, banco de
     evaluación, rúbrica, definición de la métrica con versión, ADR y ficha del sistema por capacidad se tratan
     como código (Mitchell et al., 2019, *Model Cards*; Gebru et al., 2021, *Datasheets for Datasets*; Nygard,
     2011, ADR; Sculley et al., 2015).
   - **Puerta 2, la documentación como fuente de la IA.** Lo que el corpus entrega a una máquina —índice de
     recuperación, `llms.txt`, `AGENTS.md`, recursos MCP— es **un destino de publicación más**: hereda el filtro
     por audiencia y su contenido es **entrada no confiable** (OWASP Top 10 for LLM Applications 2025, LLM01).
   - **Puerta 3, lo que la IA escribe.** Entra como borrador con procedencia declarada (`origin`, `confidence`)
     y no es fuente ni habilita una puesta en uso hasta que una persona lo aprueba (W3C PROV-O, 2013; NIST AI
     600-1).
3. **Dónde termina Docs as Code:** en el comportamiento del modelo en ejecución (eso es evaluación: NIST AI RMF,
   MEASURE), en el permiso del usuario en tiempo de ejecución (seguridad; Saltzer y Schroeder, 1975), en la
   verdad del contenido y en la **decisión de encender** (NIST AI RMF, MANAGE; Humble y Farley, 2010; Hodgson,
   2017). **Fusionar no es encender.**
4. **Por qué así:** el repositorio con PR es la forma más barata de cumplir lo que piden los marcos de gestión
   para la documentación del sistema (identificación, revisión, aprobación, control de cambios, conservación).
   El Reglamento (UE) 2024/1689 queda como contexto: su aplicabilidad a estos dos proyectos no está establecida.

**En estos dos proyectos (agregado de la presidencia):** ni Lab-Geometria ni `{servicio-privado}` recuperan
documentos hoy, así que la puerta 2 queda diseñada y no ejercida; las puertas 1 y 3 sí tienen objeto y defectos
medidos, y por eso el plan (§4) empieza por ellas.

## 2. Respuestas por pregunta

Una por pregunta, sin «depende»; el detalle y los votos, en el folio 011 §2.

### 2.1 Preguntas de la sesión DocsAsCode

| # | Respuesta | Votos |
| --- | --- | --- |
| D-1 | El filtro por `delivery` tiene **una fuente de verdad: el documentador**, que genera un corpus por audiencia con su huella. La capa no filtra de nuevo: verifica la huella y, si no coincide, rechaza | 2–1 |
| D-2 | La capa recupera con **la identidad del usuario final, propagada**; nunca la del servicio ni la del agente. Se prueba con una prueba de contrato negativa por rol y por herramienta en CI | 3–0 |
| D-3 | Lo que escribe un agente **no es fuente** antes de la aprobación humana: va con `origin: ia-generated` (o `ia-assisted`) y `confidence` | 3–0 |
| D-4 | `AGENTS.md` y equivalentes son **configuración que se documenta**: en el repo, con frontmatter, por PR; no se distribuyen por `delivery` | 2–1 |
| D-5 | Bloquean desde el primer día sólo los controles deterministas con objeto: prompt del código = ficha; prueba negativa de no publicación en CI; recálculo de toda corrida citada. El canario, sólo donde haya recuperación | 3–0 y 2–1 |
| D-6 | **Dos ensayos distintos**: el aplicador ciego ensaya al agente que especifica (oráculo: checklist); las respuestas del modelo, con banco y validadores recalculables, k/M con intervalo de Clopper y Pearson (1934); lo sin oráculo lo fija una persona | 3–0 |
| D-7 | Se integra **sobre el borrador rotulado**, y el rótulo impide la puesta en uso mientras un P0 citado siga abierto | 3–0 |

### 2.2 Preguntas de la sesión «Capa de IA»

| # | Respuesta | Votos |
| --- | --- | --- |
| C-1 | Ficha de capacidad como **plantilla en la guía 16**, no como `doc_type` de docs-guard, hasta que haya una segunda capacidad o una segunda guía | 2–1 |
| C-2 | El arnés de evaluación es **código de la capa**, que invoca el validador del producto en vez de reimplementarlo | 3–0 |
| C-3 | Una corrida son **dos piezas**: registros crudos como evidencia con SHA-256 y un resumen como documento que declara la versión de la métrica | 3–0 |
| C-4 | La delegación en mesas **cubre la fusión, no la puesta en uso**: la firma humana va en la decisión de encender. Antes de aplicarlo, se mide qué estado de D-23 rige | 3–0 |
| C-5 | En el repo público, el nombre del modelo **no** va junto a una decisión del producto privado | 3–0 |
| C-6 | Las compuertas AIL viven en la **guía 16**; a docs-guard sube sólo lo que mira texto del corpus común, y sólo si otra guía lo pide | 2–1 |
| C-7 | La carga cruzada de un servidor compartido se documenta en una **ficha de servidor por alias**, sin topología ni dirección | 3–0 |

### 2.3 Preguntas del refutador

| # | Respuesta | Votos |
| --- | --- | --- |
| R-Q1 | Salida intermedia: dictamen, exposiciones verbatim y sólo las propuestas de §4; el resto, «ideas expuestas, no adoptadas» | 2–1 |
| R-Q2 | Se retira la descripción del defecto abierto del validador privado: hecho en el folio 012 | 3–0 |
| R-Q3 | El dictamen es el de §1 (tres puertas, con el porqué de gobernanza) | 2–1 |
| R-Q4 | Antes de afirmar «main despliega» o el estado de D-23, se miden | 3–0 |
| R-Q5 | Las propuestas sin objeto (índice, canario, `llms.txt`, MCP; escalones de cátedra) van a deuda | 3–0 |

## 3. Veredicto por criterio del objetivo (folio 002 §4)

| Criterio | Veredicto | Por qué |
| --- | --- | --- |
| O-1 Dictamen sin «depende», con fuentes reales | Cumple | §1; fuentes con autor y año o norma con número |
| O-2 Posiciones e informes verbatim | Cumple, con marcas S2 | Folios 003 a 011; marcas registradas en 012; 003 tal cual |
| O-3 Cada pregunta por separado | Cumple | §2: siete, siete y cinco |
| O-4 Plan sólo con objeto y costo bajo | Cumple | §4; lo no adoptado, nombrado |
| O-5 Nada que el repo público no deba llevar | Cumple, con una observación | Barrido del folio 012; dos menciones a un número de expediente privado en 003, sin editar por pedido de su parte |

## 4. Plan de adopción

Lo aplica **quien convocó la mesa**; lo de `{servicio-privado}` es recomendación para su responsable y no se
verifica desde este repositorio.

| Orden | Propuesta | Dónde |
| --- | --- | --- |
| 1 | Barrido del expediente: retirar el defecto abierto del validador privado y verificar que ningún modelo se nombre junto al producto privado | Este expediente (hecho, folio 012) |
| 2 | Medir el estado vigente de D-23 y el canal real de publicación de Lab-Geometria antes de afirmarlos | Lab-Documentos, Lab-Geometria |
| 3 | Prueba «prompt del código = ficha», bloqueante | Lab-Geometria (y `{servicio-privado}`) |
| 4 | Prompt y plantillas de respaldo como un solo contrato; quitar «definitivas» hasta la revisión humana | Lab-Geometria |
| 5 | Prueba negativa de no publicación conectada a CI, con su par rojo/verde | `{servicio-privado}`; el par, Lab-Geometria |
| 6 | Recálculo en CI de toda corrida citada, con la versión de la métrica declarada | Lab-Geometria |
| 7 | Calendario «avisa → bloquea» con fecha en cada control nuevo | Los dos |
| 8 | Plantillas en la guía 16: ficha por capacidad, datasheet del banco y ficha de servidor por alias | Lab-Documentos (guía 16); instancias en Lab-Geometria |

**No adoptadas (ideas expuestas):** campo obligatorio de revisión en docs-guard, ficha como `doc_type`, AIL-3 a
AIL-5, huella de la unidad versionada, índice/canario/`llms.txt`/MCP, prueba de McNemar, escalones de cátedra,
ensayo ciego como compuerta. **Deuda declarada:** la del folio 011 §4, doce puntos.

Sigue: cierre por decisión con lo abierto enumerado · presidencia de la mesa · Cierra con: folio 014
