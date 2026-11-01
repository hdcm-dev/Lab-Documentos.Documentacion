---
doc_id: EXP0003-F001
doc_type: providencia
title: Apertura del expediente 0003 — contrato de entrada, ENUNCIADO, OBJETIVO y verificación del despacho
status: vigente
origin: agent
confidence: alta en el enunciado, los orígenes y el despacho (literales y comandos con salida del 2026-11-01); media en la lectura de las frases dobles, que el refutador ataca
owner: presidencia de la reedición DocsAsCode (expediente 0003)
last_review: 2026-11-01
audience: [jurado de composición, comisiones, refutador, análisis de decisiones, peritos, presidencia, PO]
traces: [TP, CH, DB-R02-00, DB-R02-01, DB-R02-02, DAC0003-N1, DAC0003-N2, DB-R02-N3, DB-R02-N4, DAC0003-N5, DB-R02-N6, DAC0003-N7, EXP0003-F002]
---

| Campo | Valor |
| --- | --- |
| Tipo | providencia |
| Fecha | 2026-11-01 |
| Autor | Presidencia de la reedición DocsAsCode |
| Corrige | — |

# Providencia de apertura — expediente 0003

Norma y secciones leídas: `Mesa-De-Expertos-A-Pedido` 3.1 (`MEP`), fila «Presidís una mesa» del mapa de carga
(`MEP:104`), §2.1 pasos 1 a 4 (`MEP:139-146`), §3.1, §3.4 y §4 (`MEP:322-333`) y §5.1 (`MEP:337-375`);
`Mesa-Consulta-A-Un-Tercero` 2.0 (`MCT`) por la propuesta de panel (`PP` §6.5); `Rule-Mesa` 1.1 (`RM`) §3.4
(`RM:190-268`) y §3.5.2 y §3.5.4; `Cadena-De-Consecuencias` 2.0 §2. El contrato de entrada que esta providencia
asienta es el de `PP` (la bitácora 02), contrastado y con el despacho vuelto a correr.

## Índice

1. [Definiciones y alias](#1-definiciones-y-alias)
2. [Objeto y radicación](#2-objeto-y-radicación)
3. [Pedido literal y huellas](#3-pedido-literal-y-huellas)
4. [ENUNCIADO](#4-enunciado)
   1. [Frases del tool-prompt](#41-frases-del-tool-prompt)
   2. [Frases del pedido del chat](#42-frases-del-pedido-del-chat)
   3. [Frases con dos lecturas](#43-frases-con-dos-lecturas)
   4. [Agregados marcados](#44-agregados-marcados)
   5. [Caso que funciona](#45-caso-que-funciona)
5. [Clase de objeto](#5-clase-de-objeto)
6. [Objeto con revisiones](#6-objeto-con-revisiones)
7. [OBJETIVO con origen de cada cláusula](#7-objetivo-con-origen-de-cada-cláusula)
8. [Contrato de entrada](#8-contrato-de-entrada)
9. [Lectura P0–P3 del caso](#9-lectura-p0p3-del-caso)
10. [Despacho verificado](#10-despacho-verificado)
11. [Excepciones a conocimientos](#11-excepciones-a-conocimientos)
12. [Lo no verificado e incidencias](#12-lo-no-verificado-e-incidencias)
13. [Barrido de lo privado de este folio](#13-barrido-de-lo-privado-de-este-folio)

---

## 1. Definiciones y alias

**Expediente.** Carpeta que registra un caso que atraviesa más de un repositorio o corrida, o en el que entra
material externo que funda una decisión (`RE` §1). Este caso cumple las dos ramas: toca Lab-Documentos,
Lab-Documentos.Documentacion, Lab-Geometria y un repositorio privado, y las comisiones traen normas e industria
(`TP:73`).

**Providencia.** Folio de impulso: convoca, despacha u ordena (`RE` §3.4). Esta es la de apertura: asienta el
contrato de entrada y verifica el despacho (`MEP:144`, paso 2).

**ENUNCIADO.** Cada frase del pedido clasificada como incógnita, dato, requisito, deseable o exclusión, con su
sujeto y el origen de la condición (`MEP` §3.1). Ejemplo: «seria interesante enriquecer ejemplos…» (`TP:22`) es
un **deseable**, porque el condicional no obliga; «Toda afirmación debe estar respaldada por evidencia
verificable» (`TP:98`) es un **requisito**.

**Agregado.** Cláusula que no sale del pedido ni de una regla con ancla E2. No se despacha como objetivo: sale
marcada y, si importa, como pregunta (`MEP:144`, paso 2).

**Cuerpo SDEI.** El conjunto de documentos de
`/LAB/Lab-Documentos/Lab-Documentos/Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/` (`TP:36`).

**Libro.** El documento unificado `DocsAsCode-Developer-Guide.md` que pide `TP:48`. **Conocimiento P2.** El
conocimiento de especificación que pide `TP:54`.

| Alias | Qué es | Ruta desde la raíz del workspace |
| --- | --- | --- |
| `TP` | Tool-prompt del PO, 104 líneas. `TP:73` = línea 73 | `/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/Guides/14-Sistema-De-Documentador-Tecnico/02-Ajuste-Coherencia-Reedicion-Documentacion.md` (sin versionar) |
| `CH` | Pedido del chat del 2026-11-01 que pone en marcha el plan | Texto completo en el directorio de trabajo de la sesión, con huella (§3) |
| `B2/` | Bitácoras de la reedición | `/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/Guides/14-Sistema-De-Documentador-Tecnico/OUTPUTs/DocsAsCode-Bitacoras/Reedicion-02/` |
| `PL` | Plan de la reedición | `B2/00-Plan.md` |
| `CG` | Cohesión global de los núcleos | `B2/01-Cohesion-Global.md` |
| `PP` | Propuesta de panel y contrato de entrada | `B2/02-Propuesta-De-Panel.md` |
| `N1`–`N7` | Bitácoras de núcleo | `B2/Nucleo-N1.md` … `B2/Nucleo-N7.md` |
| `SDEI/` | Cuerpo SDEI | La ruta de la definición de arriba |
| `MEP`, `MCT` | `Knowledge-Mesa-De-Expertos-A-Pedido` 3.1, `Knowledge-Mesa-Consulta-A-Un-Tercero` 2.0 | `KB-privada/Knowledges/` |
| `RM`, `RE`, `EJ`, `DL` | `Rule-Mesa` 1.1, `Rule-Expediente` 1.0, `Rule-Escalas-De-Juicio` 1.2, `Rule-Detencion-Y-Lote` 1.1 | `KB-privada/Rules/` |
| `F002` | Constancia de coordinación con la sesión FRAMEWORK MAUI | `actuaciones/002-constancia-coordinacion-con-framework-maui.md` de este expediente |
| `{servicio-privado}` | El servicio privado de notificaciones push del segundo ensayo. No se escribe su nombre, repositorio, dominio ni infraestructura | — |
| `{host-de-pruebas}` | El host donde el pedido manda correr las pruebas (`CH`) | — |
| `{dir-de-trabajo}` | Directorio de trabajo de los agentes, fuera del workspace | — |

Las líneas de `PP`, `CG` y `N1`–`N7` que se citan son las de las copias de trabajo que leyó la mesa. Las copias
versionadas en `B2/` tienen el mismo número de líneas y difieren sólo en líneas reemplazadas por la redacción de
rutas (§10, fila 13), así que las citas valen igual.

## 2. Objeto y radicación

**Objeto.** Revisar la coherencia del cuerpo SDEI con sus ejemplos y su demo, reunirlo en un libro revisado como
libro, confeccionar un conocimiento de especificación y probarlo sobre Geometría y sobre `{servicio-privado}`
(carátula de este expediente, fila «Objeto»).

**Radicación.** Lab-Documentos.Documentacion, carpeta padre
`PROMPTs/DEVs/Enchacement/01-Replanteo-Y-Analisis/OUTPUTs/Expedientes/`, la que declaró el folio 001 del expediente
0002 (§2 de ese folio). El número 0003 es el siguiente libre: la carpeta tiene `0002-…` y `0003-…` (§10, fila 8).

**Por qué se abre** (`RE` §1). Atraviesa cuatro repositorios, uno privado, y entra material externo que funda
decisiones (`TP:73`, «basarse en las tendencias del mercado y los estandares de la industria»). Es la lectura A de
L-5 (§4.3): un solo expediente para toda la reedición.

**Antecedente.** Expediente 0002 (metodología DocsAsCode y escalón E1). Este expediente lo cita; no lo reabre.

## 3. Pedido literal y huellas

| Pieza | Literal | Canal, fecha y autor | Huella SHA-256 |
| --- | --- | --- | --- |
| `TP` | El archivo entero, 104 líneas. Las líneas 14, 18, 20 y 22 nombran `{servicio-privado}`: el testimonio que se foliará va **redactado** en esas líneas, con el original en `evidencia/local/` y su huella (`RE` §3.6, §3.8) | Archivo del PO, sin versionar; invocado en el chat de Claude Code con ultracode (`TP:4`) | `da388e9dc72c2ce0d379f65fd1c5a5f8048f9b26694b056af60a329d44f74b37` |
| `CH` | «bueno en función de lo que tenemos, ejecuta lo siguiente […] pero tenes que sumar los ajustes de coherencias que indicas, pruebas en `{host-de-pruebas}` o donde haya recursos disponibles, tenes que coordinar con los agentes lanzados en la sesión `FRAMEWORK MAUI` […] así que coordina con dischos agentes para que no se pisen con los PR, por ahi revisen como pueden trabajar en paralelo sin interferirse mutuamente y generar conflictos - y busquen el mejor camino, tal vez deberian armonizar las ramas e instanciar una clon del repo en paralelo como estrategia de trabajo. espues que coordines con los subagentes de `FRAMEWORK MAUI` arma el plan y ponelo en marcha» (el nombre del host va redactado) | Chat de la sesión, 2026-11-01, PO | `a824d94906e65e7ed3a9e140b6ecca1864cb04e2da42447feaa95ea6ee6802bb` (archivo con el texto completo, sin redactar) |

«Los ajustes de coherencias que indicás» remite a un mensaje anterior de la sesión que ofrecía escribir la bitácora 16
de la onda 8 y actualizar el índice (`PP:65-66`; `PL` §1).

## 4. ENUNCIADO

Clases según `MEP` §3.1. Sujeto: a qué pieza alcanza la frase. **Origen de la condición**: «pedido» si sale de
`TP` o `CH`; otra fuente si la condición viene de una regla. Base: `PP` §3, cotejada línea por línea contra `TP`
el 2026-11-01 (§10, fila 1).

### 4.1 Frases del tool-prompt

| # | Frase (literal abreviado) | `TP` | Clase | Sujeto | Origen |
| --- | --- | --- | --- | --- | --- |
| E-01 | «Leer `/PROG2/Geometria/Lab-Geometria.Documentacion/ia-db/README.md`, es `Geometria`» | :12 | Dato | Lab-Geometria | Pedido |
| E-02 | Leer la ia-db de `{servicio-privado}` y su conocimiento de escena | :14 | Dato | `{servicio-privado}` | Pedido |
| E-03 | Diseñar un conocimiento de **especificación** que agentes o humanos «en otro contexto diferente pudieran aplicarlos en nuevos o ya existentes proyectos» | :18 | Requisito | Conocimiento P2 | Pedido |
| E-04 | Aplicarlo a Geometría y a `{servicio-privado}` «a fin de probar la efectividad del conocimiento generado y realizar las correcciones que sean necesarias» | :20 | Requisito | Conocimiento P2 | Pedido |
| E-05 | «seria interesante enriquecer ejemplos y guia relativo a lo que desarrolle en `Geometría`» | :22 | **Deseable** | Ejemplos y libro | Pedido |
| E-06 | `{servicio-privado}` «es un proyecto privado y las guias y ejemplso son parte de un repositorio público» | :22 | **Exclusión** (sus datos fuera de lo público) | Repos públicos | Pedido; `SDEI/00-Marco.md:170` |
| E-07 | «Editar los contenidos generados y armonizar con respecto a ejemplos y demo construida. y aplicación sobre diseño de servicios existentes» | :28 | Requisito | Cuerpo SDEI y ejemplos | Pedido |
| E-08 | «solicitar a la mesa de expertos una revisión de dichos documentos generados, incluir expertos en revisión bibliografica y edición de material bibliografico» | :38 | Requisito | Panel | Pedido |
| E-09 | «Coherencia de lo redactado - y que sea consecuente y congruente con las ejemplificaciones» | :40 | Requisito | Cuerpo SDEI | Pedido |
| E-10 | «que los editores editen un documento unificado» con la regla de documentación, que «reuna los documentos individuales» en `DocsAsCode-Developer-Guide.md` | :42-48 | Requisito | Libro | Pedido |
| E-11 | «Luego que se le aplique una ronda de revisión como si fuera un libro», con la tabla de seis intervenciones | :50, :58-67 | Requisito | Libro | Pedido |
| E-12 | «tenga un sección inicial que explique estos fundamentos que hemos basado el framework» | :52 | Requisito | Libro | Pedido |
| E-13 | El conocimiento en `…/Sistema-De-Documentacion-E-Integracion/Conocimientos/knowledge-DocsAsCode-Designing-Specification.md` | :54 | Requisito (ruta) | Conocimiento P2 | Pedido |
| E-14 | «A la Guía de desarrollador añadir referencias y casos según lo que se ha relevado en la industria» | :56 | Requisito | Libro | Pedido |
| E-15 | Con el libro, los ejemplos, la demo y las implementaciones «nos queda el material suficiente» para que un grupo de agentes IA o humanos trabaje en una aplicación | :70 | **Incógnita** (¿alcanza?) | Libro y conocimiento | Pedido |
| E-16 | Reclutar especialistas: «analistas en sistemas y arquitectos en aplicaciones moviles en MAUI .NET, especialistas en analisis el cúal se le pida criterios de decisión y analisis de las decisiones, especialistas en documentación técnica de usuario y sistemas, […] académicos en edición de material bibliografico y libros» | :73 | Requisito | Panel | Pedido |
| E-17 | «La mesa debería abrir los expedientes si se requiere tal seguimiento» | :73 | Requisito condicional | Expediente | Pedido |
| E-18 | «trazar una arquitectura clara, puede alternativas, pero se deben buscar las ventajas de simplicidad y practicidad, escalibilidad» | :73 | Requisito (criterios de decisión) | Decisiones de la mesa | Pedido |
| E-19 | «Los investigadores especializados pueden ensayar […] que se armen expedientes, se presenten y evaluen los resultados ante la mesa» | :73 | Requisito | Peritos y expediente | Pedido |
| E-20 | «que consulten los estandares»; «Es importante basarse en las tendencias del mercado y los estandares de la industria» | :73 | Requisito (mandato de investigación) | Todas las comisiones | Pedido; `MEP` §3.1 |
| E-21 | Regla de documentación: secciones jerárquicas, definiciones, explicaciones, ejemplos, mermaid cuando haga falta, autocontenida, no delta, índices | :79 (y :45) | **Restricción dura** | Todo documento creado | Pedido |
| E-22 | Descomposición en núcleos, documento de cohesión, integración, registros en `OUTPUTs/DocsAsCode-Bitacoras` | :81-94 | Restricción dura (proceso) | Proceso | Pedido |
| E-23 | «No inventar información»; «Toda afirmación debe estar respaldada por evidencia verificable» | :96-98 | Restricción dura | Todo | Pedido |
| E-24 | Aplicar el Profile `Study-Guide-Documentation` | :104-105 | Requisito | Libro | Pedido. **Dato corregido**: la ruta de `TP:105` no existe; la real está bajo `/IA/PROMPTs/IA.Prompts/…` (§10, fila 11) |

Líneas sin fila: títulos, separadores y la invocación (`TP:1-11`, `:16`, `:24-27`, `:30-37`, `:69`, `:74-78`,
`:99-103`). `TP:16` («tenemos hasta ahora un marco conceptual y bibliografico…») es un dato de contexto que E-07
ya cubre.

### 4.2 Frases del pedido del chat

| # | Frase | Clase | Sujeto | Origen |
| --- | --- | --- | --- | --- |
| E-25 | «sumar los ajustes de coherencias que indicas» | Requisito | Bitácoras de la onda 8 e índice | `CH`; remite a la corrida anterior (`PL` §1) |
| E-26 | «pruebas en `{host-de-pruebas}` o donde haya recursos disponibles» | Requisito (medio) | Ensayos y peritajes | `CH` |
| E-27 | Coordinar con FRAMEWORK MAUI «para que no se pisen con los PR» | Restricción dura | PR de LD y LDD | `CH`; asentada en `F002` |
| E-28 | «tal vez deberian armonizar las ramas e instanciar una clon del repo en paralelo» | **Deseable** («tal vez») | Ramas | `CH` |
| E-29 | «arma el plan y ponelo en marcha» | Requisito | Presidencia | `CH` |

### 4.3 Frases con dos lecturas

Se toma la lectura que menos agrega y se declara (`MEP` §3.1). El refutador las ataca (`MEP:148`, paso 6).

| # | Frase | Lectura A | Lectura B | Se toma y por qué |
| --- | --- | --- | --- | --- |
| L-1 | «Que este documento reuna los documentos individuales […] en un solo documento» (`TP:48`) | El libro **reúne**; los documentos fuente siguen y mandan | El libro **reemplaza** a los fuente, que pasan a `obsoleto` | **A**: no obliga a depreciar el cuerpo ni a re-apuntar trazas (`N2` D-N2-1). La regla de corrección doble que A necesita es un agregado (AG-1) y va como pregunta P-01 |
| L-2 | Ubicación del conocimiento: `ARTIFACTs/` de `PROMPTs` (`TP:18`) frente a `Conocimientos/` del cuerpo (`TP:54`) | Una sola ubicación, la de la solicitud (`TP:54`) | Dos copias | **A**: `PROMPTs/` fuera de `OUTPUTs/` es del PO (`PL` §8). La copia en `ARTIFACTs/` la decide el PO |
| L-3 | «realizar las correcciones que sean necesarias» (`TP:20`) | Corregir el conocimiento y el libro | Corregir además el diseño de los servicios | **A**: los ensayos producen artefactos de ensayo; cambiar los productos es otro pedido |
| L-4 | «una ronda de revisión como si fuera un libro» (`TP:50`) y la tabla de seis intervenciones (`TP:58-67`) | Una pasada editorial con las seis intervenciones en orden, cada una con su registro | Seis rondas completas de mesa | **A**: una ronda, seis intervenciones (`PL` §4, fase 5) |
| L-5 | «abrir los expedientes si se requiere» (`TP:73`) | Un expediente, el 0003 | Un expediente por núcleo | **A**: el 0003 ya existe con su folio 002; le faltaba este (`CG` §6.3) |
| L-6 | «instanciar una clon del repo en paralelo» (`CH`) | Worktrees propios en `{dir-de-trabajo}` | Clones completos aparte | **A**: acordado con FRAMEWORK MAUI (`F002` §3, regla 3) |

### 4.4 Agregados marcados

| # | Agregado | Quién lo propuso | Tratamiento |
| --- | --- | --- | --- |
| AG-1 | Regla de corrección doble libro ↔ fuente | `N2` D-N2-1 | Pregunta P-01 |
| AG-2 | Publicar el libro como sitio | `PL` §6 | Pregunta P-19; hoy sólo ensayo informativo (`N7` H4) |
| AG-3 | Copiar el conocimiento a IA.Knowledge.Base | `N3` M-4 | Al PO, en el lote del cierre (`DL` §3.5) |
| AG-4 | Cambios de herramienta en `dg.py` (exclusión de carpetas, precedencia de versión, IDs locales) | `N1` §5, `N4` §5, `N5` §4 | Pregunta P-04: entran sólo si la mesa los liga a un requisito |
| AG-5 | Renombrar la etiqueta de runner | `N2` H-5 | Pregunta P-11; si se elige renombrar, es clase H (archivo común, `F002` §3, regla 2) |

### 4.5 Caso que funciona

La reedición 04 de FRAMEWORK MAUI produjo un libro unificado y un conocimiento con el mismo pedido de forma
(`F002` §4). Primera salida para cada pieza que difiere: igualarla, salvo donde los núcleos dan E1 de que la
referencia no sirve: comentarios HTML (la regla AI-1 de la compuerta los bloquea, `N2` §4.1), `doc_type: libro`
(fuera del vocabulario, `N2` §4.1) y la cabecera del conocimiento fuera de la forma de la base (`N3` §3.3). Las
tablas diferenciales están en `N2` §3 y `N3` §3.3.

## 5. Clase de objeto

| Clase | Señal | Decisión |
| --- | --- | --- |
| **Corpus documental existente** | Revisión, coherencia y unificación del cuerpo SDEI (E-07 a E-11) | **Tomada**. Es la pregunta principal del pedido |
| Diseño de una norma | El conocimiento P2 (E-03) | Descartada como clase principal. Se suman dos rasgos que el pedido ya pide: las comisiones **citan fuentes externas** y no inventan cláusulas (E-20, E-23), y el dictamen responde **cada pregunta por separado, sin «depende»** (`MEP` §2.2) |
| Investigación de un defecto | El mermaid mal dibujado | Cerrada: peritaje de una variable, la causa es `@` (`N7` §3.2; `CG` C-01) |
| Interfaz en ejecución | La prueba de ayuda por rol levantada | No es clase del caso; entra como peritaje (E-19) |

**`RM` §3.1 no se cumple**: no hay un plan por aprobar de un framework con perfil. `estado` y `diff_normativo`
llevan «no aplica»; `pendientes_declarados` lleva los abiertos de `N1` §5, que entran como clase `C` hasta que una
comisión los ancle (`RM:186-188`).

## 6. Objeto con revisiones

| Pieza | Ruta | Revisión |
| --- | --- | --- |
| Cuerpo SDEI | `SDEI/**` (Lab-Documentos) | `0bed863` = `origin/main` (§10, fila 3) |
| Expediente 0002 y bitácoras previas | `…/Expedientes/0002-Replanteo-Metodologia-DocAsCode/` y `OUTPUTs/DocsAsCode-Bitacoras/` (Lab-Documentos.Documentacion) | `origin/main` `8b96bc6` |
| Bitácoras de esta reedición, constancia 002 y carátula | `B2/` y este expediente | Rama `dac/0003-apertura`, `0df313f` (un commit sobre `8b96bc6`, §10, fila 4) |
| Caso Geometría | Lab-Geometria y Lab-Geometria.Documentacion | `5f07b12` y `0202722` (§10, fila 12) |
| Caso `{servicio-privado}` | Su repositorio de documentación | Sólo por alias; revisión en la bitácora privada, fuera de lo público |
| Libro y conocimiento P2 | `SDEI/DocsAsCode-Developer-Guide.md`; `SDEI/Conocimientos/knowledge-DocsAsCode-Designing-Specification.md` | **No existen todavía** (§10, fila 10) |

## 7. OBJETIVO con origen de cada cláusula

**OBJETIVO.** Que el cuerpo SDEI quede coherente con sus ejemplos y su demo **[E-07, E-09]**, reunido en un libro
autocontenido, no delta y con índice **[E-10, E-21]**, que abre con sus fundamentos **[E-12]**, suma referencias y
casos de la industria **[E-14]** y sigue el Profile de guía de estudio **[E-24]**; revisado como libro en seis
intervenciones **[E-11, L-4]**; acompañado de un conocimiento de especificación que alguien sin contexto pueda
aplicar **[E-03, E-13]**, cuya efectividad se pruebe aplicándolo a Geometría y a `{servicio-privado}` sin exponer
a este en lo público **[E-04, E-06]**; con decisiones fundadas en simplicidad, practicidad y escalabilidad y en
normas y tendencias de la industria **[E-18, E-20]**; con toda afirmación respaldada por evidencia **[E-23]**, las
pruebas corridas en `{host-de-pruebas}` o donde haya recursos **[E-26]**, los PR coordinados con FRAMEWORK MAUI
**[E-27]** y los ajustes de coherencia de la corrida anterior sumados **[E-25]**.

| Cláusula | Origen | Clase del origen |
| --- | --- | --- |
| Cuerpo coherente con ejemplos y demo | `TP:28`, `TP:40` | Pedido |
| Libro unificado, autocontenido, no delta, con índice | `TP:42-48`, `TP:79` | Pedido |
| Sección inicial de fundamentos | `TP:52` | Pedido |
| Referencias y casos de la industria | `TP:56` | Pedido |
| Profile de guía de estudio | `TP:104-105` (ruta corregida) | Pedido |
| Seis intervenciones en una ronda | `TP:50`, `TP:58-67`; lectura L-4 | Pedido, con lectura declarada |
| Conocimiento aplicable sin contexto, en su ruta | `TP:18`, `TP:54`; lectura L-2 | Pedido, con lectura declarada |
| Prueba de efectividad en dos casos | `TP:20` | Pedido |
| Sin exponer lo privado | `TP:22`; `SDEI/00-Marco.md:170` | Pedido y convención del cuerpo |
| Criterios simplicidad, practicidad, escalabilidad; normas y tendencias | `TP:73` | Pedido |
| Evidencia verificable | `TP:96-98` | Pedido |
| Pruebas en el host indicado | `CH` | Pedido |
| PR coordinados | `CH`; `F002` | Pedido |
| Ajustes de la corrida anterior | `CH`; `PL` §1 | Pedido |

**Fuera del objetivo, como deseables**: enriquecer ejemplos con material de Geometría (E-05) y armonizar ramas
(E-28). **Incógnita que el dictamen contesta**: E-15, si el material alcanza para que un equipo trabaje.
**Agregados**: AG-1 a AG-5, sólo como preguntas o lote al PO (§4.4).

## 8. Contrato de entrada

Campos de `MEP` §5.1. Lo que ya está arriba va por remisión.

```text
PEDIDO (literal): TP entero (104 líneas, huella en §3) y CH (§3). Los hizo el PO el 2026-11-01.
ENUNCIADO: §4 (E-01 a E-29, L-1 a L-6, AG-1 a AG-5, caso que funciona).
CLASE DE OBJETO: corpus documental existente, con dos rasgos de diseño de norma (§5).
OBJETO: §6.
OBJETIVO: §7.
PREGUNTAS DEL CASO: P-01 a P-28, en PP §7 (libro: P-01 a P-03, P-05 a P-08; herramienta y gobierno: P-04,
                    P-09 a P-12, P-19, P-20; coherencia del cuerpo: P-13 a P-18, P-21; conocimiento y ensayos:
                    P-22 a P-28). Son 28, numeradas sin huecos. El dictamen responde cada una.
LECTURA P0–P3: §9.
RESTRICCIONES DURAS: regla de documentación (TP:79); no inventar y evidencia verificable (TP:96-98); lo privado
                     por alias en lo público (E-06; SDEI/00-Marco.md:170); territorios y PR coordinados con
                     FRAMEWORK MAUI (F002 §3); PROMPTs/ del PO sólo se escribe en OUTPUTs/; nada se instala en un
                     host sin acuerdo del PO; guarda y merge atado al SHA de Conformacion-Pull-Request-Automatico
                     2.0 (N7 §4.2).
DECISIONES CERRADAS: territorios, worktrees, un PR común a la vez por repo y merges anunciados (F002 §3); la
                     propuesta mejor fundada que elige el jurado queda aprobada (delegación del PO del
                     2026-09-14; PL §4, fase 2); lo privado por alias (SDEI/00-Marco.md:170); el conocimiento
                     canónico va en Lab-Documentos (L-2); la historia de LD y LDD se reescribió y sus main son
                     los nuevos (N1 §5, folio 259 del 0002); las convenciones que rigen, abajo.
CONVENCIONES QUE RIGEN (barrido sobre IA.Knowledge.Base/Knowledges/Index-Knowledge.md, base e013c4f:
                        45 filas, todas Vigente; versión por grep -m1 '^\*\*Versión'):
    Mesa-De-Expertos-A-Pedido 3.1 · Mesa-Consulta-A-Un-Tercero 2.0 (lectura A de PP §6.5: rige sólo si
    aparece un tercero) · Mesa 1.1 (§3.4, §3.5) · Expediente 1.0 · Escalas-De-Juicio 1.2 · Detencion-Y-Lote 1.1 ·
    Excepcion-A-Un-Conocimiento 2.1 · Cadena-De-Consecuencias 2.0 · Forma-De-Conocimiento 1.3 (conocimiento P2) ·
    Conformacion-Pull-Request-Automatico 2.0 · Logica-De-Decision 1.0 · Indexing 2.1 · Icono-Y-Ancla (glosario
    del libro; versión al despachar) · Turnos-De-Recursos-Compartidos-En-Un-Host 1.1 (condicional: pruebas
    pesadas en el host compartido) · Versionado-Producto-Integral (condicional) ·
    Entorno-De-Ejecucion-Del-Agente (condicional: mensajes de otra sesión a mitad de turno).
    Descartes: los de PP §5, con su motivo.
    Fuera de la base: el Profile Study-Guide-Documentation (E-24).
FUERA DE ALCANCE: Concepts/Framework-Concept/** y PROMPTs/Concepts/** (FRAMEWORK MAUI); la guía 16 de IA y su
                  prompt (F002 §3, regla 6); el código y la especificación de Geometría y de {servicio-privado}
                  (L-3); el despliegue real de Geometría (N4 §3.7); los deseables E-05 y E-28.
MEDIOS: scripts/ci-local.sh, tools/medios/mermaid.sh, enlaces_anclas.py, verificar.sh de la mini demo, ensayo
        MkDocs informativo, barrido de lo privado, API pública de GitHub (N7 §6-§7); ensayos en
        {host-de-pruebas} con la guarda de turnos si son pesados. Sin observar: render del libro completo
        (no existe), prueba de ayuda por rol levantada.
EXPEDIENTE: /LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/DEVs/Enchacement/01-Replanteo-Y-Analisis/
            OUTPUTs/Expedientes/0003-Reedicion-DocsAsCode-Y-Especificacion/
QUIÉN APLICA: la presidencia y los editores de las seis intervenciones (contenido, académica, estilo,
              ortotipográfica, diseño editorial, pruebas), fuera del panel (MEP §4; TP:42, «que los editores
              editen»). Quien diseña un parche no lo vota.
PRESUPUESTO: [criterio propio] tope de 12 hallazgos por comisión (el jurado de composición lo ajusta por silla en
             el folio 004); una ronda prevista. Con una sola ronda la mesa cierra «por decisión» y lo escribe
             (MEP:328). Con cuatro rondas sin criterio, la decisión sube al PO en el lote del cierre.
estado / diff_normativo: no aplica (RM §3.1 no se cumple, §5).
pendientes_declarados: los abiertos de N1 §5, como clase C.
DESPACHO VERIFICADO: §10.
```

## 9. Lectura P0–P3 del caso

La de `PP` §8, sin cambios. Va en cada carta (`MEP:144`).

| Nivel | Qué es en este caso |
| --- | --- |
| **P0** | Viola una restricción dura (lo privado expuesto en lo público, un dato falso sobre el ejemplo conductor, un guion publicado que no corre, la compuerta en rojo) o hace imposible el objetivo |
| **P1** | Retrabajo o lectura divergente entre lectores o aplicadores: un término con dos sentidos, dos reglas que se contradicen |
| **P2** | Pérdida acotada: una cita de línea vieja, una referencia sin fecha |
| **P3** | Claridad |

## 10. Despacho verificado

Los comandos de `PP` §9, vueltos a correr el 2026-11-01 por la tarde, más los que agrega esta providencia. La
columna «Cambio» compara con `PP` §9.

| # | Dato | Comando | Salida actual | Cambio |
| --- | --- | --- | --- | --- |
| 1 | Huella y largo de `TP` | `sha256sum` y `wc -l` sobre `TP` | `da388e9dc72c2ce0d379f65fd1c5a5f8048f9b26694b056af60a329d44f74b37`; `104` | Igual |
| 2 | Huella de `CH` | `sha256sum` sobre el archivo del chat | `a824d94906e65e7ed3a9e140b6ecca1864cb04e2da42447feaa95ea6ee6802bb` | Igual |
| 3 | Base de LD | `git -C {dir-de-trabajo}/wt/dac-LD log -1 --format='%h %cs %s'`; `git log -1 origin/main` | `0bed863 2026-11-01 Merge pull request #41 …`, rama `dac/0003-base`; `origin/main` = `0bed863` | Igual |
| 4 | Base de LDD | `git -C {dir-de-trabajo}/wt/dac-LDD log -1 --format='%h %cs %s'`; `git log --oneline origin/main..HEAD`; `git diff --stat origin/main..HEAD` | `0df313f 2026-11-01 Reedición DocsAsCode: apertura del expediente 0003, plan y núcleos; onda 8 y folio 261 del 0002`, rama `dac/0003-apertura` (empujada); un commit sobre `origin/main` `8b96bc6`; 15 archivos, +4107 −45 | **Cambió**: `PP` daba `8b96bc6` como cabeza del worktree. `origin/main` sigue en `8b96bc6` |
| 5 | PR abiertos en LD y LDD | `curl -s https://api.github.com/repos/<org>/<repo>/pulls?state=open` (18:20 UTC) | `0` y `0` | Igual. La rama `dac/0003-apertura` no tiene PR todavía |
| 6 | Regla compuesta de traza de ayuda | `sed -n 48p` y `sed -n 88p SDEI/TEM-05-Ayuda-Al-Usuario-Final.md` | l. 48: «Toda página de usuario traza a un `RD-`»; l. 88: «La fila `RD-` y el caso de uso de la unidad de la pantalla, en el registro del SDD» | Igual |
| 7 | Clases de `ESC-SDEI-4` | `sed -n 100,109p SDEI/00-Marco.md` | l. 105: «CL-01 a CL-05, CL-07, CL-08, CL-11 a CL-13» | Igual |
| 8 | Expediente 0003 | `ls -R …/0003-Reedicion-DocsAsCode-Y-Especificacion/` | `README.md`; `actuaciones/002-constancia-coordinacion-con-framework-maui.md`; `evidencia/` vacía | Igual: falta este folio 001 |
| 9 | Versiones de las normas | `grep -m1 '^\*\*Versión'` sobre cada archivo | `MEP` 3.1; `MCT` 2.0; `RM` 1.1; `RE` 1.0; `EJ` 1.2; `DL` 1.1; Excepcion 2.1; Cadena 2.0; Forma 1.3; Conformación automática 2.0; Lógica de decisión 1.0; Indexing 2.1 (está en `Knowledges/`, no en `Rules/`); Turnos 1.1 | Igual |
| 10 | Libro y conocimiento P2 | `ls SDEI/DocsAsCode-Developer-Guide.md SDEI/Conocimientos` | `No existe el fichero o el directorio` (los dos) | Agregado por esta providencia |
| 11 | Ruta del Profile | `ls <ws>/IA/IA.Prompts/PromptFramework/Profiles/Study-Guide-Documentation.md`; ídem con `IA/PROMPTs/` | La de `TP:105` no existe; la de `IA/PROMPTs/IA.Prompts/…` existe | Agregado |
| 12 | Revisiones de Geometría | `git log -1 --format=%h` en Lab-Geometria y Lab-Geometria.Documentacion | `5f07b12` y `0202722` | Igual a `N4` §1 |
| 13 | Copias de trabajo frente a copias versionadas de `B2/` | `sha256sum` de cada par; `diff` filtrado a líneas que no sean reemplazos; `wc -l` | Ocho de nueve difieren en huella (N5 coincide); ninguna diferencia agrega ni quita líneas (0 en los nueve); los largos coinciden (p. ej. `PP` 416/416, `N2` 721/721) | Agregado. Las citas de línea valen en las dos |
| 14 | Índice de la base | `grep '^| \[' Index-Knowledge.md \| wc -l`; `git log -1 --format='%h %cs'` | `45`, todas `Vigente`; base `e013c4f 2026-10-30` | Agregado |

## 11. Excepciones a conocimientos

| Conocimiento y § | Qué dice | Qué se hace en su lugar | Impacto operativo |
| --- | --- | --- | --- |
| `RE` 1.0 §3.3 (folios en orden) | La foliatura avanza; cada folio se escribe cuando le toca | El folio 001 se asienta **después** del 002, que ya existe y lo cita en sus `traces`. **Alternativa de cumplir:** renumerar la constancia como 001 y esta como 002 | Ninguno sobre el estado derivado: el pase de este folio sigue al 002. El número 001 queda para la apertura, como en el 0002 |
| `RE` 1.0 §3.5-§3.6 (testimonio literal) frente a §3.8 (dato de un repositorio privado) | Literal sin recortar; y no asentar datos privados | El testimonio de `TP` y `CH` va redactado en las líneas que nombran `{servicio-privado}` o el host, con el original en `evidencia/local/` y su huella (§3) | Ninguno: es la vía que la regla prevé. Se declara porque elige entre dos lecturas |
| `MEP:144`, paso 2 (cada carta se archiva en `evidencia/` antes de despachar) | Carta archivada antes del despacho | Este folio se escribe fuera del expediente, en el directorio de la mesa, y lo foliará la presidencia; la carta que lo encargó no está archivada. **Alternativa de cumplir:** archivarla como `evidencia/001-carta-presidencia-apertura.md` al foliar | Hasta que se archive, la trazabilidad descansa en este folio |

## 12. Lo no verificado e incidencias

- **Si las líneas de `PP` §7 que citan a `N1`–`N7` siguen apuntando bien.** Esta providencia volvió a correr los
  datos de `PP` §9, no cada cita de §7. Las comisiones las anclan al usarlas.
- **Si el dato de `PP:296` es exacto.** `PP` dice que trazas y ayuda son «los dos ejes con más hallazgos
  (`N1` §6)», pero `N1` §6 clasifica por **tipo** (a-f), no por eje. Lo trata el jurado de composición (folio 004).
- **El barrido del índice** se corrió con `cut -d'|' -f4,12`, como en `PP` §5; `MEP` §5.1 pide también el campo 6
  (Tema). Los descartes de `PP` §5 dan el motivo por el Tema, leído aparte.
- **Incidencia**: al medir la fila 3 se corrió un `git fetch` en el worktree de LD. Actualizó sólo referencias
  remotas; `origin/main` quedó igual antes y después (`0bed863`). No hubo commits, push ni cambios de archivos.
- **Incidencia de lo privado fuera de este folio**: las copias versionadas de `B2/` (rama `dac/0003-apertura`)
  nombran el host de pruebas en `00-Plan.md` (3 apariciones), `01-Cohesion-Global.md` (2), `02-Propuesta-De-Panel.md`
  (5), `Nucleo-N1.md` (4), `Nucleo-N2.md` (1), `Nucleo-N3.md` (1), `Nucleo-N4.md` (6) y `Nucleo-N7.md` (8)
  (`grep -c -i` sobre cada archivo). Va a la presidencia para que decida si el barrido lo trata como privado antes
  de abrir el PR.
- **Mensajes de otra sesión**: no llegó ninguno a mitad de turno.

## 13. Barrido de lo privado de este folio

| Campo | Valor |
| --- | --- |
| Comando | `grep -nIiE` con rutas de home y del directorio de trabajo, direcciones IP, el nombre del servicio privado y de los otros proyectos privados, y el nombre del host, sobre este archivo |
| Fecha | 2026-11-01 |
| Resultado | **Vacío** (código de salida 1 de `grep`), sobre este folio y el 004. El patrón no se escribe acá: escribirlo sería asentarlo |

Sigue: incorporación de la propuesta de panel como folio 003 y jurado de composición (folio 004) · presidencia
