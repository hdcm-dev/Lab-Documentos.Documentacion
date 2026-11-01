---
doc_id: DB-R02-02
doc_type: bitacora-plan
title: Propuesta de panel y contrato de entrada de la mesa de la reedición DocsAsCode
status: borrador
origin: agent
confidence: alta en el enunciado, los orígenes y el barrido (literales y comandos con salida del 2026-11-01); media en la composición propuesta, que vota el jurado (Mesa §3.4.5)
owner: presidencia de la reedición DocsAsCode (expediente 0003)
last_review: 2026-11-01
traces: [DB-R02-00, DB-R02-01, DAC0003-N1, DAC0003-N2, DB-R02-N3, DB-R02-N4, DAC0003-N5, DB-R02-N6, DAC0003-N7]
---

# 02 — Propuesta de panel y contrato de entrada de la mesa

Contrato de entrada de la mesa que pide el prompt 02 (línea 73), armado con la forma de
`Knowledge-Mesa-De-Expertos-A-Pedido` 3.1 §5.1 y con `Knowledge-Mesa-Consulta-A-Un-Tercero` 2.0. Ningún despacho sale
antes del enunciado (Mesa-De-Expertos-A-Pedido §2.1, paso 1). La composición del panel la vota el jurado; esta
propuesta es la hipótesis que vota.

## Índice

1. [Fuentes y lectura de las normas](#1-fuentes-y-lectura-de-las-normas)
2. [Pedido literal y huellas](#2-pedido-literal-y-huellas)
3. [Enunciado](#3-enunciado)
   1. [Frases del prompt](#31-frases-del-prompt)
   2. [Frases del pedido del chat](#32-frases-del-pedido-del-chat)
   3. [Frases con dos lecturas](#33-frases-con-dos-lecturas)
   4. [Agregados marcados](#34-agregados-marcados)
4. [Clase de objeto, objeto y objetivo](#4-clase-de-objeto-objeto-y-objetivo)
5. [Convenciones que rigen y decisiones cerradas](#5-convenciones-que-rigen-y-decisiones-cerradas)
6. [Composición del panel](#6-composición-del-panel)
   1. [Núcleo permanente](#61-núcleo-permanente)
   2. [Variables y ad hoc](#62-variables-y-ad-hoc)
   3. [Roles fuera del panel](#63-roles-fuera-del-panel)
   4. [Descartes y postergaciones](#64-descartes-y-postergaciones)
   5. [Consulta a un tercero](#65-consulta-a-un-tercero)
7. [Preguntas que la mesa decide](#7-preguntas-que-la-mesa-decide)
8. [Resto del contrato de entrada](#8-resto-del-contrato-de-entrada)
9. [Despacho verificado](#9-despacho-verificado)

## 1. Fuentes y lectura de las normas

| Norma | Versión | Secciones leídas |
| --- | --- | --- |
| `IA.Knowledge.Base/Knowledges/Knowledge-Mesa-De-Expertos-A-Pedido.md` | 3.1 | Cabecera y §0 (l. 1-110), §2.1-§2.2 (l. 139-178), §3.1-§3.4 (l. 240-320), §4 (l. 322-333), §5.1 (l. 337-373) |
| `IA.Knowledge.Base/Knowledges/Knowledge-Mesa-Consulta-A-Un-Tercero.md` | 2.0 | Cabecera, §0, §1, §2, §2.1, §5 bis, §6.1, §8, §8.1 |
| `IA.Knowledge.Base/Rules/Rule-Mesa.md` | 1.1 | §3.4 (composición, l. 190-268) |

Consecuencias de la lectura que ordenan esta propuesta:

- **Las bitácoras N1-N7 no viajan como «lectura previa».** Lo que midieron (comandos con salida) es base mecánica
  (paso 3); lo que proponen viaja como hipótesis a refutar (Mesa-De-Expertos-A-Pedido §2.1, paso 2).
- **Un hallazgo heredado de un informe anterior entra como `C`** hasta que una comisión lo verifique (§3.2). Eso vale
  para los hallazgos de los folios 245, 255 y 290 del expediente 0002 que N1 relevó.
- **El panel no aplica.** Aplica quien convoca o quien el pedido designe (§4, «Quién aplica»). Los editores de las
  seis rondas son aplicadores, no comisiones.

## 2. Pedido literal y huellas

| Pieza | Literal | Canal y fecha | Huella SHA-256 |
| --- | --- | --- | --- |
| Prompt 02 | El archivo entero, 104 líneas (`wc -l`) | Archivo del PO, sin versionar, clon `…/Lab-Documentos.Documentacion/PROMPTs/Guides/14-Sistema-De-Documentador-Tecnico/02-Ajuste-Coherencia-Reedicion-Documentacion.md` | `da388e9dc72c2ce0d379f65fd1c5a5f8048f9b26694b056af60a329d44f74b37` (`sha256sum` del archivo, 2026-11-01) |
| Pedido del chat | «bueno en función de lo que tenemos, ejecuta lo siguiente […] pero tenes que sumar los ajustes de coherencias que indicas, pruebas en {equipo-de-pruebas} [alias] o donde haya recursos disponibles, tenes que coordinar con los agentes lanzados en la sesión `FRAMEWORK MAUI` […] así que coordina con dischos agentes para que no se pisen con los PR, por ahi revisen como pueden trabajar en paralelo sin interferirse mutuamente y generar conflictos - y busquen el mejor camino, tal vez deberian armonizar las ramas e instanciar una clon del repo en paralelo como estrategia de trabajo. espues que coordines con los subagentes de `FRAMEWORK MAUI` arma el plan y ponelo en marcha» | Chat de la sesión, 2026-11-01, relayado por el arnés | `a824d94906e65e7ed3a9e140b6ecca1864cb04e2da42447feaa95ea6ee6802bb` (texto completo tal como llegó, en el scratchpad: `{dir-de-trabajo}/scratchpad/pedido-chat-2026-11-01.txt`) |

El pedido del chat responde a un mensaje anterior de la sesión que ofrecía escribir la bitácora 16 de la onda 8 y
actualizar el índice. «Los ajustes de coherencias que indicás» remite a ese mensaje (Plan §1 lo registra igual).

## 3. Enunciado

Clases de cada frase según Mesa-De-Expertos-A-Pedido §3.1: incógnita, dato, requisito, deseable o exclusión.

### 3.1 Frases del prompt

| # | Frase (literal abreviado) | Prompt | Clase | Sujeto | Origen de la condición |
| --- | --- | --- | --- | --- | --- |
| E-01 | «Leer `…/Lab-Geometria.Documentacion/ia-db/README.md`, es `Geometria`» | :12 | Dato | Lab-Geometria | Pedido |
| E-02 | Leer la ia-db del servicio privado y su conocimiento de escena | :14 | Dato | Servicio privado | Pedido |
| E-03 | Diseñar un conocimiento de especificación aplicable «en otro contexto», a proyectos nuevos o existentes | :18 | Requisito | Conocimiento P2 | Pedido |
| E-04 | Aplicarlo a Geometría y al servicio privado «a fin de probar la efectividad» y corregir lo necesario | :20 | Requisito | Conocimiento P2 (lo que se corrige) | Pedido |
| E-05 | «seria interesante enriquecer ejemplos y guia relativo a lo que desarrolle en `Geometría`» | :22 | **Deseable** | Ejemplos y libro | Pedido |
| E-06 | El servicio privado «es un proyecto privado y las guias y ejemplos son parte de un repositorio público» | :22 | Restricción (exclusión de sus datos en lo público) | Repos públicos | Pedido |
| E-07 | Editar y armonizar los contenidos con los ejemplos, la demo y la aplicación a servicios existentes | :28 | Requisito | Cuerpo SDEI y ejemplos | Pedido |
| E-08 | Pedir a la mesa una revisión de los documentos, con expertos en revisión y edición bibliográfica | :38 | Requisito | Panel | Pedido |
| E-09 | Coherencia de lo redactado, consecuente con las ejemplificaciones | :40 | Requisito | Cuerpo SDEI | Pedido |
| E-10 | Documento unificado `DocsAsCode-Developer-Guide.md` que reúna los documentos individuales, con la regla de documentación | :42-48 | Requisito | Libro P1 | Pedido |
| E-11 | «Luego que se le aplique una ronda de revisión como si fuera un libro» y la tabla de seis intervenciones | :50, :58-67 | Requisito | Libro P1 | Pedido |
| E-12 | Una sección inicial que explique los fundamentos | :52 | Requisito | Libro P1 | Pedido |
| E-13 | El conocimiento en `…/Sistema-De-Documentacion-E-Integracion/Conocimientos/knowledge-DocsAsCode-Designing-Specification.md` | :54 | Requisito (ruta) | Conocimiento P2 | Pedido |
| E-14 | Añadir referencias y casos «según lo que se ha relevado en la industria» | :56 | Requisito | Libro P1 | Pedido |
| E-15 | Con el libro, ejemplos, demo y producción, «material suficiente» para que un equipo de agentes o personas trabaje en una aplicación | :70 | Incógnita (¿alcanza?) | Libro + conocimiento | Pedido |
| E-16 | Panel: analistas de sistemas, arquitectos MAUI .NET, especialistas en análisis y criterios de decisión, documentación técnica de usuario y de sistemas, académicos de edición | :73 | Requisito | Panel | Pedido |
| E-17 | «La mesa debería abrir los expedientes si se requiere» | :73 | Requisito condicional | Expediente 0003 | Pedido |
| E-18 | Arquitectura clara; alternativas posibles; buscar simplicidad, practicidad, escalabilidad | :73 | Requisito (criterios de decisión) | Decisiones de la mesa | Pedido |
| E-19 | Investigadores que ensayan; expedientes con resultados evaluados ante la mesa | :73 | Requisito | Peritos y expediente | Pedido |
| E-20 | «basarse en las tendencias del mercado y los estandares de la industria» | :73 | Requisito (mandato de investigación) | Comisiones | Pedido; Mesa-De-Expertos-A-Pedido §3.1, fila «Que busquen…» |
| E-21 | Regla de documentación: secciones jerárquicas, definiciones, ejemplos, mermaid, autocontenido, no delta, índices | :79 | Requisito | Todo documento creado | Pedido |
| E-22 | Descomposición en núcleos, documento de cohesión, integración, registros en `OUTPUTs/DocsAsCode-Bitacoras` | :81-94 | Requisito | Proceso | Pedido |
| E-23 | «No inventar información»; «Toda afirmación debe estar respaldada por evidencia verificable» | :96-98 | Requisito | Todo | Pedido |
| E-24 | Aplicar el Profile `Study-Guide-Documentation` | :102-105 | Requisito | Libro P1 | Pedido (ruta corregida, Plan §8) |

### 3.2 Frases del pedido del chat

| # | Frase | Clase | Origen |
| --- | --- | --- | --- |
| E-25 | «sumar los ajustes de coherencias que indicas» | Requisito | Chat del 2026-11-01; remite a la onda 8 sin bitácora, índice y pendientes ya resueltos (Plan §1) |
| E-26 | «pruebas en {equipo-de-pruebas} [alias] o donde haya recursos disponibles» | Requisito (lugar de las pruebas) | Chat |
| E-27 | Coordinar con FRAMEWORK MAUI para que no se pisen los PR | Requisito | Chat |
| E-28 | «tal vez deberian armonizar las ramas e instanciar una clon del repo en paralelo» | **Deseable** | Chat («tal vez») |
| E-29 | «arma el plan y ponelo en marcha» | Requisito | Chat |

**Caso que funciona** (§3.3, «Caso que funciona antes que diseño»): la reedición 04 de FRAMEWORK MAUI produjo un libro
unificado y un conocimiento con el mismo pedido de forma. N2 §3 arma su tabla diferencial (qué se adopta, qué falló)
y N3 §3.3 la del conocimiento. La primera salida para cada pieza que difiere es igualarla, salvo donde N2 y N3 dan E1
de que la referencia no sirve: comentarios HTML (AI-1 da rojo, N2 §4.1), `doc_type: libro` (fuera del vocabulario,
N2 §4.1) y cabecera del conocimiento fuera de la forma de la base (N3 §3.3).

### 3.3 Frases con dos lecturas

Se toma la lectura que menos agrega y se declara (§3.1).

| # | Frase | Lectura A | Lectura B | Se toma |
| --- | --- | --- | --- | --- |
| L-1 | «que este documento reuna los documentos individuales […] en un solo documento» (:48) | El libro reúne; los documentos fuente siguen y mandan (N2 D-N2-1 A) | El libro reemplaza a los documentos fuente, que pasan a obsoletos (N2 D-N2-1 B) | **A**: no obliga a depreciar 30 documentos ni a re-apuntar trazas. Queda como pregunta P-01 porque la regla de corrección doble que A necesita es un agregado |
| L-2 | Ubicación del conocimiento: `ARTIFACTs/` (:18) frente a `Conocimientos/` de LD (:54) | Una sola ubicación, la de la solicitud | Dos copias | **A**, en LD: `PROMPTs/` fuera de `OUTPUTs/` es del PO (Plan §8). La copia en `ARTIFACTs/` la decide el PO |
| L-3 | «realizar las correcciones que sean necesarias» (:20) | Corregir el conocimiento y el libro | Corregir además el diseño de los servicios | **A**: los ensayos producen artefactos de ensayo; cambios en los productos son otro pedido |
| L-4 | «una ronda de revisión como si fuera un libro» (:50) y la tabla de seis intervenciones (:58-67) | Una ronda que pasa por las seis intervenciones | Seis rondas completas de mesa | **A**: una pasada editorial con seis intervenciones en orden, cada una con su registro (Plan §4, fase 5) |
| L-5 | «abrir los expedientes si se requiere» (:73) | El expediente 0003 ya abierto | Un expediente por núcleo | **A**: el 0003 existe; le falta el folio 001 de apertura (`01-Cohesion-Global.md` §6.3) |
| L-6 | «instanciar una clon del repo en paralelo» (chat) | Worktrees propios (`{dir-de-trabajo}/wt/dac-LD`, `{dir-de-trabajo}/wt/dac-LDD`) | Clones completos aparte | **A**: ya acordado con FRAMEWORK MAUI (Plan §5, constancia 002) y es lo que permite el conocimiento de conformación automática §3.5 (N7 §4.2) |

### 3.4 Agregados marcados

Cláusulas que no salen del pedido ni de una regla con E2. No se despachan como objetivo; salen marcadas.

| # | Agregado | Quién lo propuso | Tratamiento |
| --- | --- | --- | --- |
| AG-1 | Regla de corrección doble libro ↔ fuente | N2 D-N2-1 | Pregunta P-01 |
| AG-2 | Publicar el libro como sitio | Plan §6 («Sitio MkDocs. Se construye») | Pregunta P-19; hoy es ensayo (N7 H4) |
| AG-3 | Copiar el conocimiento a IA.Knowledge.Base | N3 M-4 | Al PO, en el lote del cierre |
| AG-4 | Cambios de herramienta en `dg.py` (exclusión de carpetas, precedencia de versión, IDs locales) | N1 §5, N4 §5, N5 §4 | Pregunta P-04: entran sólo si la mesa los liga a un requisito |
| AG-5 | Renombrar la etiqueta de runner | N2 H-5 | Pregunta P-11 |

## 4. Clase de objeto, objeto y objetivo

**CLASE DE OBJETO: corpus documental existente**, porque la pregunta principal del pedido es la revisión, coherencia y
unificación del cuerpo SDEI (E-07 a E-11). Se descarta como clase principal «diseño de una norma» (el conocimiento
P2, E-03); de ella se suman sólo dos rasgos que el pedido ya pide: las comisiones **citan fuentes externas** y no
inventan cláusulas (E-20, E-23), y el dictamen responde **cada pregunta por separado, sin «depende»**
(Mesa-De-Expertos-A-Pedido §2.2). La parte «investigación de un defecto» ya se cerró con un peritaje de una variable:
la causa del mermaid mal dibujado es `@` (N7 §3.2; `01-Cohesion-Global.md` C-01).

**OBJETO.**

| Pieza | Ruta | Revisión |
| --- | --- | --- |
| Cuerpo SDEI | `Lab-Documentos/Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/**` | `0bed863` (worktree `{dir-de-trabajo}/wt/dac-LD`) |
| Expediente 0002 y bitácoras | `Lab-Documentos.Documentacion/PROMPTs/…/Expedientes/0002-…` y `OUTPUTs/DocsAsCode-Bitacoras/` | `8b96bc6` (worktree `{dir-de-trabajo}/wt/dac-LDD`) |
| Casos de aplicación | Lab-Geometria `5f07b12`, Lab-Geometria.Documentacion `0202722`; servicio privado (sólo por alias) | N4 §1; N5 §1 |

**OBJETIVO.** Que el cuerpo SDEI quede coherente con sus ejemplos y su demo [E-07, E-09], reunido en un libro
autocontenido, no delta y con índice que abre con sus fundamentos y suma referencias y casos de la industria
[E-10, E-12, E-14, E-21, E-24], revisado como libro en seis intervenciones [E-11], acompañado de un conocimiento de
especificación que alguien sin contexto pueda aplicar [E-03, E-13] y cuya efectividad se pruebe aplicándolo a
Geometría y al servicio privado sin exponer a este en lo público [E-04, E-06], con toda afirmación respaldada por
evidencia [E-23], las pruebas corridas en el equipo de pruebas [E-26] y los PR coordinados con FRAMEWORK MAUI [E-27], sumando los
ajustes de coherencia de la corrida anterior [E-25].

Fuera del objetivo, como deseables: enriquecer los ejemplos con material de Geometría (E-05) y armonizar las ramas
(E-28).

## 5. Convenciones que rigen y decisiones cerradas

**Barrido del índice** (Mesa-De-Expertos-A-Pedido §3.4), corrido el 2026-11-01:

```text
$ cd IA/IA.Knowledge.Base/Knowledges
$ grep '^| \[' Index-Knowledge.md | cut -d'|' -f4,12
 Bundle-JS | Vigente
 Cadena-De-Consecuencias | Vigente
 Clean-Architecture-DataManager | Vigente
 Comunidad-Cientifica-Autoevolutiva | Vigente
 Conformacion-Pull-Request-Automatico | Vigente
 Conformacion-Pull-Request-Manual | Vigente
 DataTier-DataBase-Layer | Vigente
 DataTier-DataBase-Layer-Acceso-NET | Vigente
 Deduccion-De-Reglas-De-Negocio | Vigente
 Detencion-Y-Lote | Vigente
 Entorno-De-Ejecucion-Del-Agente | Vigente
 Escalas-De-Juicio | Vigente
 Excepcion-A-Un-Conocimiento | Vigente
 Expediente | Vigente
 Forma-De-Conocimiento | Vigente
 Icono-Y-Ancla | Vigente
 Indexing | Vigente
 Logica-De-Decision | Vigente
 Media-File-Service-DataTier | Vigente
 Media-File-Service-EF | Vigente
 Media-File-Service-SMB | Vigente
 Media-File-Service-SMB-Esqueletos | Vigente
 Mesa | Vigente
 Mesa-Consulta-A-Un-Tercero | Vigente
 Mesa-De-Expertos-A-Pedido | Vigente
 Migraciones-SQL-Versionadas | Vigente
 Migraciones-SQL-Versionadas-Esqueletos | Vigente
 Parametros-De-Sistema | Vigente
 Parametros-De-Sistema-Esqueletos | Vigente
 Perfiles-Y-Extension | Vigente
 Red-Movil-Problematica | Vigente
 Release-Y-Despliegue-Versionado | Vigente
 Template-Blazor-Interactive-Server-Panel-De-Control | Vigente
 Template-Blazor-Interactive-Server-SDD-Default | Vigente
 Template-Blazor-Interactive-Server-Sistema-De-Diseno-V2 | Vigente
 Template-Blazor-Interactive-Server-Sistema-De-Diseno-V2-Componentes | Vigente
 Template-HTML-Panel-De-Control | Vigente
 Template-HTML-Panel-De-Control-Recorridos | Vigente
 Template-HTML-SDD-Default | Vigente
 Template-HTML-Sistema-De-Diseno-V2 | Vigente
 Turnos-De-Recursos-Compartidos-En-Un-Host | Vigente
 Versionado-Esquema-Base-De-Datos-EF-Layer | Vigente
 Versionado-Paquetes-NuGet | Vigente
 Versionado-Producto-Integral | Vigente
 WhatsApp-Web-MCP | Vigente
```

Versiones tomadas con `grep -m1 '^\*\*Versión'` de cada documento.

| Alias | Versión | Rige | Por qué toca el objeto |
| --- | --- | --- | --- |
| Mesa-De-Expertos-A-Pedido | 3.1 | Todo | Mesa pedida por nombre (Prompt:73) |
| Mesa-Consulta-A-Un-Tercero | 2.0 | §1, §2, §5 bis, §6 | Nombrado por el pedido (Prompt:73); `Condicion-de-carga: —`, se carga por nombre |
| Mesa (regla) | 1.1 | §3.4, §3.5 | Composición y ciclo |
| Expediente (regla) | 1.0 | Todo | Expediente 0003 |
| Escalas-De-Juicio (regla) | 1.2 | §3.1-§3.4 | P0-P3 y anclas |
| Detencion-Y-Lote (regla) | 1.1 | §3.5-§3.8 | Lote del cierre y bloqueos |
| Excepcion-A-Un-Conocimiento | 2.1 | Si una comisión propone no seguir una convención | Paso 6 bis |
| Cadena-De-Consecuencias | 2.0 | Antes de recomendar | Análisis de decisiones |
| Forma-De-Conocimiento (regla) | 1.3 | Todo | Forma del conocimiento P2 (N3 §3.1) |
| Conformacion-Pull-Request-Automatico | 2.0 | §3.1-§3.5 | Ciclo de los PR (N7 §4.2) |
| Conformacion-Pull-Request-Manual | — (condicional) | Si la delegación del 0003 no se asienta | «Si el agente no la encuentra, rige el padre» (N7 §4.3) |
| Logica-De-Decision | 1.0 | Decisiones de la mesa | Criterios de decisión pedidos (E-18) |
| Indexing | 2.1 | ia-db de LDD | Rule-Indexing del RuleSet (N2 §2.2) |
| Icono-Y-Ancla | — | Glosario y definiciones del libro | Su Tema es «entregar una definición de modo que quien la lee pueda operar con ella» |
| Turnos-De-Recursos-Compartidos-En-Un-Host | 1.1 (condicional) | Pruebas pesadas en el equipo de pruebas | Supuesto: el runner y los contenedores son compartidos (N4 §9; N7 §2) |
| Versionado-Producto-Integral | — (condicional) | Versión del cuerpo y familias de versión del caso privado | Supuesto: un producto multiartefacto (N5 §2, familias sin etiqueta) |
| Entorno-De-Ejecucion-Del-Agente | — (condicional) | Mensajes de otra sesión a mitad de turno | Supuesto: dos sesiones en los mismos repos (chat, E-27) |

Las versiones con «—» se toman con el mismo `grep` al despachar la carta que las cite.

**Descartes del barrido**: Bundle-JS, Clean-Architecture-DataManager, DataTier-*, Media-File-Service-*,
Migraciones-SQL-*, Parametros-De-Sistema-*, Template-*, Versionado-Esquema-Base-De-Datos-EF-Layer,
Versionado-Paquetes-NuGet (su Tema es de código o de producto, no de documentación); Red-Movil-Problematica (red
móvil); WhatsApp-Web-MCP (no hay consulta por ese canal); Comunidad-Cientifica-Autoevolutiva (modelo permanente sin
pedido, no una mesa a pedido); Deduccion-De-Reglas-De-Negocio (lee fuentes de negocio, no un corpus documental);
Perfiles-Y-Extension (no se crea un perfil); Release-Y-Despliegue-Versionado (lo usa N3 como ejemplar de forma, no
rige el objeto).

**DECISIONES CERRADAS** (no se reabren salvo contradicción con E1 o E2):

| Decisión | Fuente |
| --- | --- |
| Territorios, worktrees, un PR común a la vez por repo, merges serializados y anunciados | Plan §5; constancia 002 del expediente 0003 |
| La mesa decide y la propuesta mejor fundada queda aprobada | Plan §4, fase 2 (delegación del PO del 2026-09-14) |
| Lo privado se nombra por alias en lo público | `00-Marco.md:170`; Plan §7; E-06 |
| El conocimiento canónico va en LD, no en `PROMPTs/` | Plan §8; L-2 |
| La historia de LD y LDD se reescribió y «No reescribir» quedó revertido (mains nuevos `bf86669` y `15d8452`) | Mensaje anterior de la sesión citado en el pedido del chat; folio 259 del expediente 0002 (N1 §5) |
| Las convenciones del barrido, en sus versiones | Esta sección |

## 6. Composición del panel

Techo: núcleo permanente más cinco variables o ad hoc por ciclo; empate convoca (Rule-Mesa §3.4.5). Cada variable
lleva su señal con ubicación (Rule-Mesa §3.4.2).

### 6.1 Núcleo permanente

| Silla | Quién la titula | Pregunta | Origen |
| --- | --- | --- | --- |
| Requisitos | **Analista de sistemas** | ¿Cada afirmación del cuerpo, del libro y del conocimiento es unívoca, atómica y verificable? ¿Qué falta? | Rule-Mesa §3.4.1; pedido E-16. Precedente: «requisitos (analista de sistemas)» en `IA.Knowledge.Base/Expedientes/0001-Capturar-Y-Catalogar-Conocimientos/actuaciones/003-informe-jurado-composicion.md:109` |
| Verificación | Ingeniero de verificación documental (CI y compuertas) | ¿Cómo se prueba cada afirmación? ¿Qué quedó sin criterio de aceptación? | Rule-Mesa §3.4.1; E-19, E-23 |
| Lector sin contexto | Un agente que no participó, de otro arnés si se puede | ¿Puede trabajar con el libro y con el conocimiento sin preguntar? Cada pregunta es un hallazgo | Rule-Mesa §3.4.1; E-03, E-15. Es también la P-LECT pendiente del folio 245 (N1 §5) |
| Refutador | — | Ataca la lectura dominante, el objetivo y cada ficha de excepción; entra último | Rule-Mesa §3.4.1; Mesa-De-Expertos-A-Pedido §2.1, paso 6 |

### 6.2 Variables y ad hoc

**Composición A (recomendada):**

| # | Silla (catálogo o ad hoc) | Quién la titula | Señal con ubicación | Origen |
| --- | --- | --- | --- | --- |
| V1 | Arquitectura | **Arquitecto de apps móviles MAUI .NET** | Más de una unidad de entrega: la mini demo tiene web, API y móvil (`docs/tecnica/arquitectura.md:27-30`, N1-31); topología multirrepo (`TEM-03`; N4 §3.1); dos unidades en Geometría (N4 §3.3) | E-16 |
| V2 | Trazabilidad documental | **Especialista en documentación técnica de sistemas** | IDs, trazas y prefijos: `prefijos.txt:24` frente a `Esquema…:117` (N1-05); commits muertos (N1-17); `_legacy/` y versión doble (N4 §5) | E-16 |
| V3 | Uso y accesibilidad | **Especialista en documentación técnica de usuario** | Ayuda al usuario final y por rol: `TEM-05`, `Examples/Prueba-Ayuda-Por-Rol/`, ADR-10010 de Geometría (N4 §3.6) | E-16 |
| V4 | Formal (convocatoria automática) | Especialista en métodos cuantitativos | Umbrales y pesos: `Como-Decidir.md:74-76` (0,15 y 0,10); «≥ 85 %» (N3 §5.6) y «≥ 6 de 8» (N4 §7.3); «cuatro familias» con seis filas (N1-07) | Rule-Mesa §3.4.2 |
| V5 | **Ad hoc: edición bibliográfica y de libros** | **Académico en edición de material bibliográfico** | El pedido pide un libro y una revisión «como si fuera un libro» (Prompt:50, :58-67); ningún rol del catálogo cubre aparato crítico, estructura de obra de consulta ni norma de citación | E-08, E-16; carta de mandato (Rule-Mesa §3.4.4): pregunta única «¿el libro funciona como obra de consulta: estructura, aparato crítico, índices, glosario y ejemplos?»; no-competencia: contenido técnico de las compuertas; tope de hallazgos: el de §8; se disuelve al veredicto |

**Composición B (alternativa para el jurado):** V2 y V3 en una sola silla, «Documentación técnica de usuario y de
sistemas» (el pedido los nombra juntos, Prompt:73), y entra **Operación y entrega** con la señal de la etiqueta de
runner (`docs-guard.yml:60`), el versionado del cuerpo (`README.md:22`, `2.0.0-borrador`) y la delegación faltante
(N7 H8). Costo: una sola mirada para trazas y ayuda, que son los dos ejes con más hallazgos (N1 §6).

**Mandato de investigación para todas las comisiones** (E-20; Mesa-De-Expertos-A-Pedido §3.1): cada comisión cita
fuentes externas con URL y fecha de consulta o norma con su número; la base es N6 §3, como hipótesis a refutar.

### 6.3 Roles fuera del panel

| Rol | Mandato | Origen | Nota |
| --- | --- | --- | --- |
| **Análisis de decisiones** | Por cada pregunta P-xx de §7, criterios (simplicidad, practicidad, escalabilidad, fuente única, paso por la compuerta) y cadena de consecuencias de cada alternativa; además, el camino de compromiso de cada ficha de excepción admitida | Pedido E-16 y E-18; Mesa-De-Expertos-A-Pedido §2.1, paso 6 bis | La norma lo convoca sólo ante una ficha admitida; el pedido lo amplía a todas las preguntas. No emite hallazgos (§4, «Criterio de corte») |
| Jurado | Dos folios: composición y veredicto | Mesa-De-Expertos-A-Pedido §2.1, pasos 4 y 8 | Vota esta propuesta |
| Peritos e investigadores | Ensayos: reproducción del conocimiento (N3 §5.6), render del libro (N2 §12.3), P-LECT del tutorial, prueba de ayuda por rol levantada | E-19; §2.2, clase «investigación de un defecto» | Corren en el equipo de pruebas (E-26), con la guarda de recursos si aplica |
| Quien aplica | Presidencia de la reedición; los **editores** de las seis intervenciones (contenido, académica, estilo, ortotipográfica, diseño editorial, pruebas) | §4, «Quién aplica»; Prompt:42 «que los editores editen» | Nunca un rol del panel. Quien diseña un parche no lo vota (§3.2) |
| Coordinador y entrevistador | Ver §6.5 | Mesa-Consulta-A-Un-Tercero §1 | Una sola mano en el canal |

### 6.4 Descartes y postergaciones

| Rol | Decisión | Motivo |
| --- | --- | --- |
| Operación y entrega | Postergado al ciclo 2 en la composición A | Techo; su señal la cubre en parte Verificación (compuertas) y la decisión de la etiqueta de runner es de clase H |
| Seguridad | Descartado | La única señal es anti-inyección (PR-3), que ya mide la compuerta; lo privado lo cubre el barrido (N7 §6, paso 6) |
| Interfaz externa | Descartado | El contrato OpenAPI de la demo es objeto de PR-6 y está verde (N7 §3.1) |
| Especialista en industria y estándares como silla | Descartado | El pedido lo pide como mandato («basarse en…», E-20), no como especialidad; lo cumplen todas las comisiones con N6 como hipótesis |
| Datos y dominio, Concurrencia, Rendimiento, Cumplimiento | Descartados | Sin señal en el cuerpo SDEI |

### 6.5 Consulta a un tercero

El conocimiento regula la conversación de la mesa con **una persona de afuera** por un canal (§0). Dos lecturas:

| Lectura | Qué implica | Se toma |
| --- | --- | --- |
| A | Se carga y rige sólo si la mesa necesita consultar a alguien de afuera; hoy no hay un tercero identificado | **A** (agrega menos) |
| B | Se aplica por analogía a la coordinación con la sesión FRAMEWORK MAUI | Recomendada como práctica, marcada como agregado |

Con A, lo que rige si aparece la consulta: una sola mano en el canal (coordinador), un entrevistador que destila de 3
a 5 preguntas por ronda con el formato `rol · pregunta · por qué · prioridad · qué hago si no contesta` (§2), tope de
tres rondas (§2), contraste del insumo recibido con el pedido antes de usarlo (§5 bis) y los cortes de §6.1. Con B,
hay un hueco: el conocimiento exige un conocimiento de canal (§8.1) y no existe uno para mensajes entre sesiones.

## 7. Preguntas que la mesa decide

Cada pregunta trae las alternativas que sacaron los núcleos. El dictamen responde cada una por separado (§4).

### 7.1 Libro

| Id | Pregunta | Alternativas (fuente) |
| --- | --- | --- |
| P-01 | ¿Qué relación tienen el libro y los documentos fuente? | A. Edición de lectura; manda la fuente; corrección doble en el mismo PR (N2 D-N2-1, recomendada). B. Libro canónico; fuentes a `obsoleto` (N2). C. Libro generado por script (N2; impide las seis intervenciones) |
| P-02 | ¿Qué `doc_id` lleva el libro? | `DOC-SDEI-GUIA` sin tocar archivos comunes (N2 D-N2-2, recomendada; el `doc_id` exacto no se ensayó, `01-Cohesion-Global.md` §3.3). `LIB-SDEI` con prefijo nuevo en el PR común (N2) |
| P-03 | ¿Qué partes, orden y anexos tiene? | Prólogo, partes I a VI, capítulos 1-18, anexos A-J, orden TEM-01→07 (N2 §7, D-N2-3). Variantes: rotular cada parte por su forma Diátaxis (N6 §5 punto 6); sumar anexo de herramientas con versión (N6 §5 punto 1); sección «de la explicación al conocimiento» (N3 §7) |
| P-05 | ¿Qué guía de estilo de base usan las rondas de estilo y ortotipografía? | Sólo las convenciones del cuerpo (`00-Marco.md` §5). Convenciones del cuerpo y Google como segundo nivel (N6 §5 punto 3). Convenciones del cuerpo y Microsoft |
| P-06 | ¿Cómo entra `Lanzar-Example`? | Íntegro como procedimiento en el capítulo 14.3 (N2 §8.6). Reescrito con versiones fijas y sin datos del entorno, o movido a LDD (N1-32) |
| P-07 | ¿Cómo entra el caso del portal de notificaciones? | Reverificado antes de redactar 18.1 (N2 §9.3, pedido a N6, sin hacer). Como **HISTÓRICO (fecha)** con su fecha original (N2 §9.3). Excluido y declarado |
| P-08 | ¿Cuándo se archiva la guía obsoleta y en qué versión del cuerpo viaja el libro? | Archivado en el mismo cambio que publica el libro (N1 §8 punto 3). Libro dentro de `2.0.0-borrador` o apertura de `2.1.0` (N2 D-N2-6) |

### 7.2 Herramienta común y gobierno

| Id | Pregunta | Alternativas (fuente) |
| --- | --- | --- |
| P-04 | ¿Qué entra en el PR común y cuándo? | A. Un PR por repo con prefijos (`PE` corregido, `KNW` o `LIB` si se eligen), fila de delegación en `CHANGELOG` y dibujado de mermaid en PR-4 (N1-05, N3 M-1, N7 H3, H8). B. A más cambios de `dg.py`: exclusión de carpetas (N1 U4d, N4 §5), precedencia de versión (N4 caso R), IDs locales y versión de IDs en sección (N5 B2-B3). C. Sólo delegación y prefijos; la herramienta va a un expediente propio (clase H, N1 §8 punto 5) |
| P-09 | ¿Cómo se asienta la delegación del merge del expediente 0003? | Providencia en el expediente y fila de `CHANGELOG` en el PR común (N7 H8). Ampliar el alcance de la delegación del 0002. Conformación manual hasta el cierre |
| P-10 | ¿Cómo se citan los commits que la reescritura dejó fuera de `main` (`080f158`, `fe10086`)? | SHA nuevo del merge equivalente con el mapa de commits del rescate y número de PR (N1-17: `e3841b6` #19, `6878568` #25). Sólo número de PR. URL de `refs/pull`, que la API todavía sirve (N1-17) |
| P-11 | ¿Qué se hace con la etiqueta de runner `{runner-anterior-del-cuerpo}`? | Nota en el Marco: etiqueta histórica (N1-35). Parámetro en el conocimiento, sin tocar workflows (N3 §4.4). Renombrarla en LD, LDD y Lab-Geometria y en el runner (N2 H-5; clase H, archivo común) |
| P-12 | ¿Cómo se cierran U25 y U26 (evidencia de los ensayos)? | Corrida nueva en `evidencia/E1-R/` y marcas con URL y SHA de LDD antes del libro (N1-18). Sólo URL y SHA en el libro; la corrida, en los ensayos de la fase 4 |
| P-19 | ¿Hay sitio publicado? | No; ensayo informativo por PR del libro (N7 H4, §6 paso 5). Sitio con MkDocs y slug compatible con GitHub (N7 §3.3), con el riesgo de fin de vida de Material (N6 §5 punto 5). Otro generador citado como ejemplo con fecha (N6) |
| P-20 | ¿El dibujado de mermaid queda como control local o entra a la CI? | Control local obligatorio antes de cada PR (N7 H3). Paso nuevo de PR-4 en el PR común (N1-25, N7 H3) |

### 7.3 Coherencia del cuerpo

| Id | Pregunta | Alternativas (fuente) |
| --- | --- | --- |
| P-13 | ¿Qué significan los términos con dos o más sentidos? | «letra»: lo que se promete, separado de intención y comportamiento (N1-03). «deriva»: contenido contra código, y «desfase» para SHA contra `main` (N1-04). «compuerta»: control, compuerta del carril PR y compuerta de escalón (N1-11). «PR-7»: «fijadas y referencias», contando `autoprueba` (N1-10) |
| P-14 | ¿Qué significa `PE`? | Patrón de ejemplo en el registro y `PEND-` para los pendientes del expediente (N1-05). Pregunta de evaluación, como dice hoy `prefijos.txt:24`, y otro prefijo para los patrones |
| P-15 | ¿A qué traza una página de ayuda y cómo se corrige el ejemplo? | La regla es compuesta (`TEM-05:88`: fila `RD-` y caso de uso de la unidad de la pantalla) y el ejemplo viola las dos mitades (N1-21, N4 H1; `01-Cohesion-Global.md` §2.3). Opciones: retrazar el ejemplo a `CU-100NN` y sumarle RRD y `source.lock`; declarar el ejemplo anterior a la regla; reescribir `TEM-05:48` para que no contradiga a `:88` |
| P-16 | ¿Qué clases activa cada escenario? | Sumar CL-08 y CL-13 a `ESC-SDEI-1` (N1-23). Sumar CL-06 y CL-09 a `ESC-SDEI-4` o admitir escenarios compuestos (N5 §5 punto 2, B1). Rotular «previsto» la fuente XML de `ESC-SDEI-3` (N4 H4). Ancla por familia con caso «sin etiqueta» (N5 B7) |
| P-17 | ¿Quién decide la fase 1b en `ESC-SDEI-1`? | La analista (`00-Marco.md:145`). Docente o responsable de la guía (`TEM-02:166`). Analista o PO (clave de `EJR-SDEI-05`) (N1-22) |
| P-18 | ¿Qué dice el cuerpo del aviso programado? | Reescribir: avisa el atraso del SHA; la deriva por símbolo la mide A1 al correr la demo (N1-24). Programar A1 en el carril semanal (N1-24; toca un workflow, archivo común) |
| P-21 | ¿Qué se hace con «las capas A y B no existen» en `TEM-07`? | Verificar primero si el conocimiento de lógica de decisión versionado en IA.SDD es la capa A (N5 §5 punto 1); según el resultado, reescribir o dejar |

### 7.4 Conocimiento de especificación y ensayos

| Id | Pregunta | Alternativas (fuente) |
| --- | --- | --- |
| P-22 | ¿Qué prefijo y `doc_type` lleva el conocimiento? | `KNW` y `doc_type: conocimiento` en el PR común (N3 M-1 A). `ANX-SDEI-ESPECIFICACION` con `doc_type: anexo`, verde medido (N3 M-1 B) |
| P-23 | ¿Qué forma lleva? | Forma estricta de la base, §0-§10, con frontmatter y once campos, verificable por las dos compuertas (N3 M-2, §3.4). Forma libre como el conocimiento de FRAMEWORK MAUI (N3 §3.3) |
| P-24 | ¿Es neutral respecto de SDD? | «SDD» sólo en el apéndice por escenario (N3 M-3). Sin restricción, porque en LD no se exige |
| P-25 | ¿Qué métrica de éxito tiene la prueba de reproducción? | La de N3 (100 % contestadas, ≥ 85 % de coincidencia, 0 invenciones, 0 preguntas sin respuesta, compuerta verde). La de N4 (≥ 6 de 8 trampas, 100 % de trazas verdes, 0 inventadas). Unión de las dos |
| P-26 | ¿Qué oráculo y qué insumos tiene cada caso? | Oráculo: columna del Marco (N3 §5.6) o N4 §4 y la hoja de integración privada de N5, escritos antes y con huella (`01-Cohesion-Global.md` C-04). Insumos: conocimiento, repo del caso en SHA fijo y plantilla A-01 (N3) o conocimiento y README de la ia-db (N4); en Geometría, qué ia-db (`0202722`, PR #3 o la local sin commitear; N4 §3.2) |
| P-27 | ¿Dónde viven los ensayos? | Geometría: rama descartable en un worktree de Lab-Geometria.Documentacion, sin merge (N4 §7.2), o PR. Servicio privado: sólo `{dir-de-trabajo}/privado/` (N3 §5.6) o PR en su repo de documentación por conformación automática (N5 §6; Plan P5) |
| P-28 | ¿El ensayo en Geometría es la primera mitad del escalón 2? | Sí, se mezclan (N4 H6). No; el escalón 2 queda en el expediente 0002 y se llama «escalón 2», no «G2» (N4 §9) |

## 8. Resto del contrato de entrada

| Campo | Valor |
| --- | --- |
| LECTURA P0-P3 | **P0**: viola una restricción dura (lo privado expuesto en lo público, un dato falso sobre el ejemplo conductor, un guion publicado que no corre, la compuerta en rojo) o hace imposible el objetivo. **P1**: retrabajo o lectura divergente entre lectores o aplicadores (un término con dos sentidos, dos reglas que se contradicen). **P2**: pérdida acotada (una cita de línea vieja, una referencia sin fecha). **P3**: claridad |
| RESTRICCIONES DURAS | Regla de documentación (Prompt:79); no inventar y evidencia verificable (Prompt:96-98); alias para lo privado (E-06; `00-Marco.md:170`); territorios y PR coordinados con FRAMEWORK MAUI (E-27; Plan §5); `PROMPTs/` del PO sólo en `OUTPUTs/`; nada se escribe en {equipo-anterior}; nada se instala en un host sin acuerdo del PO; guarda G1-G4 y merge atado al SHA (N7 §4.2) |
| FUERA DE ALCANCE | `Concepts/Framework-Concept/**` y `PROMPTs/Concepts/**` (FRAMEWORK MAUI); `Guides/IA/Dot-Net-Integration-AI-Layer-Guide` y `PROMPTs/Guides/16-IA-Layer`; el código y la especificación de Geometría y del servicio privado (L-3); el despliegue real de Geometría (N4 §3.7) |
| MEDIOS | `scripts/ci-local.sh`, `tools/medios/mermaid.sh`, `enlaces_anclas.py`, `verificar.sh` de la mini demo, ensayo MkDocs informativo, barrido de lo privado, API pública de GitHub (N7 §6-§7). Sin observar: render del libro completo, prueba de ayuda por rol levantada |
| EXPEDIENTE | `Lab-Documentos.Documentacion/PROMPTs/DEVs/Enchacement/01-Replanteo-Y-Analisis/OUTPUTs/Expedientes/0003-Reedicion-DocsAsCode-Y-Especificacion/` (falta el folio 001) |
| QUIÉN APLICA | La presidencia y los editores de las seis intervenciones, fuera del panel (§6.3) |
| PRESUPUESTO | Tope de 12 hallazgos por comisión **[criterio propio]**; una ronda prevista. Con una sola ronda la mesa cierra **por decisión** y lo dice (Mesa-De-Expertos-A-Pedido §4, «Criterio de corte») |
| estado, diff_normativo, pendientes_declarados | `pendientes_declarados`: los abiertos de N1 §5. Los otros dos no aplican: la mesa no cumple la condición de Mesa §3.1 sobre un plan por aprobar de un framework con perfil |

## 9. Despacho verificado

Datos que viajan en las cartas, con el comando que los sostiene (Mesa-De-Expertos-A-Pedido §3.2).

| Dato | Comando | Salida (2026-11-01) |
| --- | --- | --- |
| Huella del prompt | `sha256sum …/02-Ajuste-Coherencia-Reedicion-Documentacion.md` | `da388e9d…74b37` |
| Huella del pedido del chat | `sha256sum …/scratchpad/pedido-chat-2026-11-01.txt` | `a824d949…02bb` |
| Base de LD y LDD | `git -C {dir-de-trabajo}/wt/dac-LD log -1 --format='%h %s'`; ídem LDD | `0bed863 Merge pull request #41 …`; `8b96bc6 Merge pull request #49 …` |
| PR abiertos en LD y LDD | `curl -s https://api.github.com/repos/hdcm-dev/<repo>/pulls?state=open` (18:11 UTC) | Ninguno |
| Regla compuesta de traza de ayuda | `sed -n 48p` y `sed -n 88p SDEI/TEM-05-Ayuda-Al-Usuario-Final.md` | l. 48: «Toda página de usuario traza a un `RD-`»; l. 88: «La fila `RD-` y el caso de uso de la unidad de la pantalla» |
| Clases de `ESC-SDEI-4` | `sed -n 100,109p SDEI/00-Marco.md` | «CL-01 a CL-05, CL-07, CL-08, CL-11 a CL-13» |
| Expediente 0003 | `ls -R …/0003-Reedicion-DocsAsCode-Y-Especificacion/` | Sólo `002-constancia-…` y `README.md`; `evidencia/` vacía |
| Versiones de las normas | `grep -m1 '^\*\*Versión'` sobre cada archivo | Mesa-De-Expertos-A-Pedido 3.1; Mesa-Consulta-A-Un-Tercero 2.0; Mesa 1.1; Expediente 1.0; Escalas-De-Juicio 1.2; Detencion-Y-Lote 1.1; Excepcion-A-Un-Conocimiento 2.1; Cadena-De-Consecuencias 2.0; Forma-De-Conocimiento 1.3; Conformacion-Pull-Request-Automatico 2.0; Logica-De-Decision 1.0; Indexing 2.1; Turnos-De-Recursos-Compartidos-En-Un-Host 1.1 |

No llegó ningún mensaje de otra sesión ni texto a mitad de turno que cambiara el encargo. No se escribió en ningún
repositorio.
