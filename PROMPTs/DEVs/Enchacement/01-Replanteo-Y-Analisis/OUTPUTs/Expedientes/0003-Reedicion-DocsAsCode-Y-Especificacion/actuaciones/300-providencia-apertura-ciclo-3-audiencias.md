---
doc_id: EXP0003-F300
doc_type: providencia
title: Apertura del ciclo 3 de la mesa — audiencias (eje A) e integración con paneles, portales y formularios (eje B), con lo que hay que rehacer del cuerpo, el conocimiento, el libro y los ensayos
status: vigente
origin: agent
confidence: alta en los pedidos literales, en las citas al cuerpo SDEI (00171bd), al conocimiento en curso, a F099 y a F204 (leídos el 2026-11-01) y en las fuentes semilla de §8 (consultadas el 2026-11-01); media en la lectura del enunciado y en la propuesta preliminar de §6, que es hipótesis a refutar y no decisión
owner: presidencia de la reedición DocsAsCode (expediente 0003)
last_review: 2026-11-01
audience: [jurado de composición, comisiones CA-1 a CA-9, análisis de decisiones, refutador, jurado del ciclo 3, presidencia, PO]
traces: [EXP0003-F001, EXP0003-F099, EXP0003-F199, EXP0003-F204]
---

| Campo | Valor |
| --- | --- |
| Tipo | providencia |
| Fecha | 2026-11-01 |
| Autor | Presidencia de la reedición DocsAsCode. Convoca y no vota |
| Corrige | Abre un ciclo nuevo sobre `F099` §5.2 (Parte III «Audiencias y canales») y sobre `F204` §9 (ronda 3). No anula ningún folio: lo que el ciclo 3 resuelva y cambie se asienta en su resolución (`F399`) |

**Convención de citas.** `F0nn`/`F1nn`/`F2nn` = folios de esta mesa y de las actuaciones del expediente;
`SDEI/` = `Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/` de `LD` en `00171bd`;
`K` = el conocimiento en curso `knowledge-DocsAsCode-Designing-Specification.md` (versión 1.2, en
`{dir-de-trabajo}/conocimiento/`); `EXP3/` como en `F099` §2; `MEP` = `Knowledge-Mesa-De-Expertos-A-Pedido`,
`MCT` = `Knowledge-Mesa-Consulta-A-Un-Tercero` (base de conocimiento del PO). Lo privado va por alias:
`{servicio-privado}`, `{dir-de-trabajo}`. Rige la delegación del PO: lo que esta mesa decide queda aprobado.

## Índice

1. [Objeto y radicación](#1-objeto-y-radicación)
2. [Pedidos literales del PO](#2-pedidos-literales-del-po)
3. [ENUNCIADO](#3-enunciado)
4. [Estado del cuerpo y del conocimiento sobre el tema](#4-estado-del-cuerpo-y-del-conocimiento-sobre-el-tema)
5. [Ejes y preguntas](#5-ejes-y-preguntas)
   1. [Eje A — audiencias](#51-eje-a--audiencias)
   2. [Eje B — paneles, portales y formularios](#52-eje-b--paneles-portales-y-formularios)
   3. [Pregunta común a los dos ejes](#53-pregunta-común-a-los-dos-ejes)
6. [Propuesta preliminar de la presidencia (hipótesis a refutar)](#6-propuesta-preliminar-de-la-presidencia-hipótesis-a-refutar)
7. [Panel](#7-panel)
8. [Fuentes semilla verificadas hoy](#8-fuentes-semilla-verificadas-hoy)
9. [Folios esperados y orden](#9-folios-esperados-y-orden)
10. [Lo que queda en espera](#10-lo-que-queda-en-espera)
11. [Lo no verificado e incidencias](#11-lo-no-verificado-e-incidencias)
12. [Barrido de lo privado de este folio](#12-barrido-de-lo-privado-de-este-folio)

---

## 1. Objeto y radicación

**Ciclo 3.** El ciclo 1 dictaminó P-01 a P-28 (`F099`); el ciclo 2, P-29 (`F199`). El ciclo 3 trata el concepto
de **audiencia** y la **llegada de la documentación al punto de uso** (paneles, portales, formularios), que el PO
pidió el 2026-11-01 en dos tramos (§2). Radica en este expediente porque cambia piezas que el expediente ya
produce: el cuerpo SDEI, el conocimiento `K`, el libro (`F099` §5.2) y los oráculos de los ensayos (`F204`).

**Clase de objeto** (`MEP` §2.2): documento normativo y método; el eje B suma una parte de **interfaz** (cómo se
ve la ayuda de un campo), pero el ciclo no ejecuta interfaces: si una comisión necesita medir una, pide peritaje
por la presidencia (`MEP` §2.1, paso 7).

**Mandato del PO sobre el alcance.** «si tenés que volver a empezar y ajustar para incluir esta idea que van a
debatir, háganlo» (§2.1). La mesa queda autorizada a proponer rehacer lo ya hecho; la resolución dice qué se rehace
y en qué orden.

## 2. Pedidos literales del PO

### 2.1 Primer tramo (2026-11-01)

Transcripto del despacho que recibió la presidencia, sin corregir:

> «lo de rol venía a cuento de que yo tengo un panel de control que puede tener un administrador raíz, y
> administradores con menos privilegios, pero no son raíz — cada uno con necesidades documentales diferentes —
> incluso la aplicación móvil, el perfil de ese usuario tiene ya necesidades documentales diferentes — podría tener
> un segundo servicio como parte del paquete con otro tipo de usuario — todos ven documentación diferente — incluso
> alcances diferentes — hasta si tengo una API, tendría una documentación para desarrollador que tal vez no quiera
> hacer pública por razones de seguridad, y hacer pública a usuarios específicos con carácter de desarrollador»

> «claro audiencias — está muy bueno esa conceptualización — necesitaba el término correcto — y es audiencias.
> Tratá este concepto de audiencia en la mesa y convocá los mejores especialistas del tema, estándares de la
> industria, academia y casos comerciales — si tenés que volver a empezar y ajustar para incluir esta idea que van
> a debatir, háganlo»

### 2.2 Segundo tramo (2026-11-01)

Literal, tal como lo escribió el PO (con su ortografía):

> «suma tambien esto, me interesa  mucho la integración con los servicios como paneles de control y portales, - me
> intersa saber si este concepto de docsAsCode se integra con los formularios de ingreso de datos como una forma de
> guiar o asistir a los usuarios con pequeña información, que mecanismos hay al respeto y que se esta usando»

Lectura de la presidencia: (1) integración del sistema documentador con los servicios que exponen paneles de
control y portales; (2) la documentación llevada al punto de uso dentro de los formularios (ayuda de campo, pistas,
marcadores, mensajes de validación, ayuda contextual, recorridos guiados), por audiencia, con la misma fuente de
verdad, traza y versión que el resto; (3) qué mecanismos existen y qué se usa hoy en la industria.

### 2.3 Caso real que funda el pedido

`{servicio-privado}`: servicio de notificaciones del PO con **panel** (administrador raíz y administradores por
aplicación, sin privilegio raíz), **app móvil** con perfil de usuario propio, **SDK/API para integradores** y la
posibilidad de un segundo servicio en el mismo paquete. Se nombra sólo por alias; en lo público, sólo su forma.

## 3. ENUNCIADO

| # | Frase (origen) | Clase | Sujeto | Nota |
| --- | --- | --- | --- | --- |
| E-01 | «cada uno con necesidades documentales diferentes» (§2.1) | Dato | Roles del panel | Raíz y no raíz son audiencias distintas aun en la misma superficie |
| E-02 | «la aplicación móvil … ya necesidades documentales diferentes» (§2.1) | Dato | Superficie móvil | La superficie es dimensión, además del rol |
| E-03 | «un segundo servicio como parte del paquete con otro tipo de usuario» (§2.1) | Dato | Producto con varios servicios | Varias superficies del mismo producto |
| E-04 | «todos ven documentación diferente — incluso alcances diferentes» (§2.1) | Requisito | Sistema documentador | Alcance (por aplicación o inquilino) como dimensión distinta del rol |
| E-05 | «documentación para desarrollador que tal vez no quiera hacer pública … usuarios específicos con carácter de desarrollador» (§2.1) | Requisito (condicional del PO: «tal vez») | Documentación de API | Acceso restringido por credencial o invitación, no sólo visibilidad |
| E-06 | «Tratá este concepto de audiencia en la mesa … mejores especialistas … estándares, academia y casos comerciales» (§2.1) | Requisito | Mesa | Fija la composición mínima del panel (§7) |
| E-07 | «si tenés que volver a empezar y ajustar … háganlo» (§2.1) | Requisito (habilitación) | Mesa | Autoriza rehacer; no obliga a rehacer lo que no haga falta |
| E-08 | «la integración con los servicios como paneles de control y portales» (§2.2) | Incógnita | Sistema documentador | Eje B |
| E-09 | «si este concepto de docsAsCode se integra con los formularios … pequeña información» (§2.2) | Incógnita | Formularios | Eje B, microtexto en el punto de uso |
| E-10 | «que mecanismos hay al respeto y que se esta usando» (§2.2) | Incógnita | Estado del arte | Exige fuentes de industria con fecha de consulta |

**Agregados marcados** (no salen del pedido; entran como pregunta, no como objetivo): «doble audiencia»
humano/agente aplicada por audiencia (A-04, A-10); accesibilidad del texto de ayuda (B-09); agente que asiste
en el formulario (B-10); controles verificables en CI (A-11, B-05). Los propone la presidencia porque el cuerpo ya
los trata (`SDEI/TEM-04`, `SDEI/TEM-06`) y porque WCAG 2.2 los vuelve obligatorios en nivel A para todo campo (§8).

**Caso que funciona.** La prueba de concepto `SDEI/Examples/Prueba-Ayuda-Por-Rol/` sirve página, `.md` crudo y
`llms.txt` desde un mismo catálogo con el mismo filtro de rol, con 404 al rol que no corresponde
(`SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:160-185`). Toda salida del ciclo se compara primero contra ese caso.

## 4. Estado del cuerpo y del conocimiento sobre el tema

Lo que hay hoy, medido el 2026-11-01:

| Pieza | Qué dice | Hueco frente al pedido |
| --- | --- | --- |
| `SDEI/00-Marco.md:104-112` (§2.5) | La fila «Audiencias» por escenario: «Estudiante, docente, agente» · «Persona usuaria, desarrollo, consumidor de la API, agente» · «Lo anterior más los roles del panel» · «Integrador, operador, agente» | Audiencia es una lista por escenario; no hay dimensiones (superficie, alcance, acceso) ni dónde se hace cumplir |
| `SDEI/TEM-04-Doble-Audiencia.md` | Humano y agente como los dos lectores; §3.5 la ayuda filtrada por rol también para el agente | La «doble audiencia» es una dimensión (lector humano o agente), no el concepto entero |
| `SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:33-79` | Define rol, traza con versión `ID@versión`, «Visibilidad y acceso: ocultar … es visibilidad; no entregarla es acceso. Sólo lo segundo protege» | Ayuda **por página**; no trata ayuda de campo, validación, ni portales de desarrollador; el «cruce de rol» no es control de `docs-guard` (l. 180-182) |
| `SDEI/TEM-05…:187-196` (§3.4) | Idiomas: fuente con aviso, nunca 404; control de traducción atrasada **[criterio propio; no existe]** | Falta el control |
| `K` D-01 (l. 262) | Escenario y contextos; roles por inventario de autorización | Audiencia no es decisión propia; se deduce del escenario |
| `K` D-13 (l. 274) | Ayuda: ninguna · única · por rol · por idioma | No contempla superficie, alcance, acceso, ni el punto de uso (campo) |
| `K` §2.3 (l. 163-180) | Copia la fila «Audiencias» del Marco | Hereda el hueco |
| `F099` §5.2, l. 200 | Libro, Parte III «Audiencias y canales», cap. 7 «Doble audiencia» | El título de la parte ya dice «audiencias», pero el contenido es sólo humano/agente |
| `F204` | Ronda 2: «Una corrida de ocho pasa (C2-r2), y con reserva. Ningún caso pasa»; propone 1.2 y ronda 3 | Los oráculos no tienen filas de audiencia; si la resolución las pide, se re-sellan (§10) |

## 5. Ejes y preguntas

Cada comisión contesta **todas** las preguntas de su mandato (§7) y puede contestar las demás. Toda respuesta trae
fuente verificable (URL consultada el día, o referencia bibliográfica completa) o el rótulo «sin verificar».

### 5.1 Eje A — audiencias

**¿Cómo modela el sistema documentador las audiencias (rol, jerarquía, alcance, superficie, canal y acceso)?**

- **A-01 Definición y término.** ¿Qué es una «audiencia» en el sistema documentador, con qué término y qué
  definición, y de qué fuente (comunicación técnica, retórica, normas ISO/IEC/IEEE 26511–26515, DITA)? ¿Cómo se
  distingue de «lector», «público destinatario», «persona», «rol» y «actor» (`SDEI/99-Anexos/Glosario.md`: «Actor …
  No confundir con el rol de un producto»)?
- **A-02 Dimensiones.** ¿Cuáles son las dimensiones mínimas de una audiencia (rol, jerarquía de privilegio,
  alcance, superficie, canal, idioma, nivel de acceso, lector humano o agente) y cuáles son ortogonales o
  derivadas? ¿Qué dimensión es obligatoria y cuál opcional por escenario?
- **A-03 Relación con rol, persona y escenario.** ¿Cómo se relaciona la audiencia con el rol del producto, con la
  «persona» de UX y con los escenarios `ESC-SDEI-1…4` del Marco? ¿La audiencia reemplaza la fila «Audiencias» de
  `SDEI/00-Marco.md` §2.5 o se suma como decisión nueva?
- **A-04 Doble audiencia.** ¿La «doble audiencia» humano/agente (`TEM-04`) queda como dimensión dentro de cada
  audiencia o sigue como tema propio? ¿Qué cambia en el capítulo 7 del libro?
- **A-05 Jerarquía de privilegio.** ¿Cómo se documenta una jerarquía (administrador raíz ⊃ administrador de
  aplicación ⊃ usuario): herencia de páginas, páginas exclusivas del nivel alto, y qué pasa con un enlace que
  cruza niveles (el «cruce de rol» de `TEM-05` §3.3)?
- **A-06 Acceso vs visibilidad.** ¿Dónde se hace cumplir cada nivel de acceso (público, autenticado en el
  producto, restringido por invitación o credencial, interno) y cómo se prueba que la documentación restringida no
  se entrega (no sólo que no se muestra)? ¿Qué aportan RBAC/ABAC (NIST SP 800-162) y la divulgación de
  información (CWE-200)?
- **A-07 Documentación de API restringida.** ¿Cómo se publica la documentación de una API a desarrolladores
  autorizados y no al público (portal con grupos, OpenAPI filtrado, Swagger/Scalar detrás de autorización,
  paquete privado)? ¿Quién decide exponerla y con qué clase de decisión (D/P/H)?
- **A-08 Alcance por inquilino o aplicación.** ¿Cómo se modela que dos administradores del mismo rol vean
  documentación distinta por la aplicación o el inquilino que administran, y cómo se evita el «cruce de alcance»?
- **A-09 Varias superficies del mismo producto.** Panel web, app móvil, servicio y SDK: ¿una sola fuente con
  salidas por superficie o fuentes separadas? ¿Cómo viaja la ayuda dentro de la app instalada (confidencialidad
  de `SDEI/00-Marco.md` §2.5: «lo que viaja en el paquete … es visible para quien la instala»)?
- **A-10 Agente por audiencia.** ¿`llms.txt` y los `.md` crudos por audiencia, con el mismo filtro que la página?
  ¿Cómo actúa un agente con el alcance de su usuario sin filtrar documentación restringida?
- **A-11 Controles verificables en CI.** ¿Qué controles nuevos van a `docs-guard` (por ejemplo: toda página
  declara audiencia de un vocabulario cerrado; ningún enlace cruza audiencia o alcance; ninguna página restringida
  aparece en un índice público; par rojo/verde por control)? ¿Cuáles quedan en las pruebas del producto?
- **A-12 Ficha A-01 y oráculos.** ¿Cómo entra la audiencia en la ficha A-01 del conocimiento (¿decisión nueva
  «D-18 Matriz de audiencias y acceso» o ampliación de D-01/D-13?), en el vocabulario `audience` de A-03 y en los
  oráculos de los ensayos?
- **A-13 Impacto en el libro.** ¿Qué capítulos cambian (Parte III «Audiencias y canales», cap. 7; capítulos de
  ayuda, de API, de confidencialidad) y qué capítulo nuevo hace falta?
- **A-14 Impacto en los ensayos.** ¿Los oráculos de la ronda 3 llevan filas de audiencia y, por lo tanto, se
  re-sellan? ¿Cambia el criterio de caso de `F204`?
- **A-15 Demo o ejemplo.** ¿Qué ejemplo público y reproducible muestra audiencias con al menos dos roles en
  jerarquía, dos alcances, dos superficies y una API restringida? ¿Se extiende `Prueba-Ayuda-Por-Rol` o se arma
  otro?

### 5.2 Eje B — paneles, portales y formularios

**¿Cómo se integra con los servicios que exponen paneles de control y portales, y cómo llega la documentación al
punto de uso en los formularios de ingreso de datos (ayuda de campo, pistas, validación, ayuda contextual,
recorridos), por audiencia y con traza a la regla?**

- **B-01 Mecanismos de microtexto en formularios y su estado del arte.** Etiqueta, texto de pista (*hint*),
  marcador (*placeholder*), texto de ayuda de campo, ícono con *tooltip*, mensaje de validación, descripción de
  sección, ayuda en línea expandible: ¿qué recomienda hoy la industria (sistemas de diseño públicos, NN/g, guías de
  plataforma) y qué desaconseja?
- **B-02 Fuente única entre especificación, validación y texto de ayuda.** ¿Puede el texto de un campo salir de la
  misma fuente que la regla que lo valida (anotaciones de datos en .NET, JSON Schema `description` y `ui:help`,
  OpenAPI `description`, archivos de recursos) y qué se pierde si se genera en lugar de derivarse (`TEM-05`:
  «derivar» no es «generar»)?
- **B-03 Traza `ID@versión` del texto de campo.** ¿Cómo lleva un texto de campo o un mensaje de validación la traza
  a la regla y su versión, si vive en un archivo de recursos y no en una página con frontmatter (`K` D-13: «el
  texto localizado en archivos de recursos no se ancla»)?
- **B-04 Clase de pieza.** ¿El microtexto de formulario es una clase nueva del catálogo (`CL-nn`), una variante de
  `CL-06` Ayuda al usuario final, o parte del código de la interfaz? ¿Dónde vive, cuál es su ancla y su control?
- **B-05 Control en CI de que la ayuda no quedó atrás de la regla.** ¿Qué control detecta que el texto de ayuda o
  el mensaje de validación no coincide con la regla vigente (traza desfasada, límites numéricos distintos, campo
  obligatorio no anunciado), y con qué par rojo/verde?
- **B-06 Por audiencia y por idioma.** ¿Cómo cambia el texto de un mismo campo según rol, alcance o superficie, y
  cómo se localiza sin perder la traza (control de traducción atrasada de `TEM-05` §3.4, hoy inexistente)?
- **B-07 Integración con paneles y portales de servicios.** Ayuda contextual por pantalla, identificadores de
  contexto (página o campo → tema de ayuda), portal de ayuda del servicio, *widgets* embebidos: ¿qué patrones hay,
  cómo se versiona el vínculo pantalla→tema, y cómo se integra con un portal de desarrolladores y con el panel de
  cada servicio del paquete?
- **B-08 Plataformas de guía en producto.** Recorridos guiados, *tooltips*, centros de recursos, segmentación por
  audiencia (por ejemplo, plataformas comerciales de adopción digital): ¿qué hacen, dónde vive su contenido (fuera
  del repositorio, en su propio editor) y qué se pierde o se gana frente a docs as code (traza, revisión por PR,
  versión)?
- **B-09 Accesibilidad del texto de ayuda.** ¿Cómo se asocia la ayuda al campo para lectores de pantalla
  (`aria-describedby`, descripción accesible), qué exige WCAG 2.2 (3.3.2 Labels or Instructions, nivel A; 3.3.1,
  3.3.3) y cómo se verifica en CI o en pruebas de la interfaz?
- **B-10 Agente que asiste en el formulario.** ¿Un asistente dentro del producto puede usar la misma ayuda,
  filtrada por la audiencia del usuario, para guiar el llenado? ¿Qué riesgos trae (inyección por texto de ayuda,
  fuga de ayuda de otra audiencia) y qué control los cubre (`TEM-04` §3.4 anti-inyección)?
- **B-11 Implementación en .NET.** En ASP.NET Core/Blazor y .NET MAUI: ¿de dónde sale el texto (anotaciones,
  recursos, metadatos), cómo se resuelve por audiencia en el servidor y cómo llega a la app móvil sin exponer lo
  restringido?
- **B-12 Demo o ejemplo.** ¿Qué ejemplo público muestra un formulario cuyo texto de ayuda y mensaje de validación
  trazan a la misma regla con versión, por dos audiencias, con un control que da rojo cuando la regla cambia?

### 5.3 Pregunta común a los dos ejes

**¿Qué hay que rehacer del cuerpo, del conocimiento, del libro y de los ensayos para incluirlo?** Cada comisión
cierra su informe con una tabla «pieza → cambio → motivo → costo → orden», con estas filas mínimas: `SDEI/00-Marco.md`
§2.5 y §4; `TEM-04`; `TEM-05`; `TEM-06` (controles); `99-Anexos/Glosario.md`; `Examples/`; `K` D-01, D-13, §2.3,
A-01, A-03; libro (`F099` §5.2); oráculos y criterio de caso de los ensayos (`F204`). Las preguntas A-12, A-13,
A-14 y B-04 son la entrada de esa tabla; la resolución la consolida.

## 6. Propuesta preliminar de la presidencia (hipótesis a refutar)

No es decisión ni lectura previa: viaja como hipótesis (`MEP` §2.1, paso 2) y el refutador la ataca primero.

1. **Decisión nueva «Matriz de audiencias y acceso»** (provisionalmente D-18 de `K`): una fila por audiencia con
   superficie (panel, móvil, API, servicio), rol, alcance (por aplicación o inquilino), canal (página, ayuda de
   campo, portal, `llms.txt`, paquete), lector (humano, agente) y **nivel de acceso** (público, autenticado en el
   producto, restringido por invitación o credencial, interno), con **dónde se hace cumplir** (servidor del
   producto, portal, repositorio privado, build).
2. **Artefacto:** la matriz como tabla versionada en el repositorio (`doc_type` propio), de la que leen la
   compuerta y el filtro del producto.
3. **Control de «cruce de alcance»** en `docs-guard`, generalización del cruce de rol de `TEM-05` §3.3.
4. **Exposición de la documentación de API como decisión de una persona** (clase H), nunca deducida.
5. **Ayuda de campo como canal de la misma pieza `CL-06`**, con traza `ID@versión` en el recurso y un control de
   desfase regla↔texto [hipótesis del eje B].

## 7. Panel

Composición fijada por la presidencia en esta providencia; el jurado de composición la vota y puede descartar o
sumar con motivo (`MEP` §2.1, paso 4). **Todas las comisiones trabajan a ciegas**: no leen los informes de las
otras ni la propuesta de §6 antes de entregar el suyo; la reciben recién en la refutación.

| Comisión | Especialidad | Preguntas a cargo | Fuentes mínimas que debe consultar |
| --- | --- | --- | --- |
| CA-1 | Comunicación técnica y arquitectura de la información | A-01, A-02, A-03, A-13; B-04 | ISO/IEC/IEEE 26511 a 26515 (análisis de audiencia y tareas); DITA 1.3 procesamiento condicional `@audience` y DITAVAL; Diátaxis |
| CA-2 | Portales de desarrollador y documentación de API restringida | A-07, A-08, A-09; B-07 | Portales con grupos y visibilidad (p. ej., Azure API Management, ver §8); OpenAPI con filtrado por audiencia; Swagger/Scalar detrás de autorización; paquetes privados |
| CA-3 | Seguridad y control de acceso | A-05, A-06, A-08, A-10; B-10 | NIST SP 800-162 (ABAC); RBAC; CWE-200; OWASP sobre divulgación de información; aislamiento por inquilino |
| CA-4 | Arquitectura .NET (ASP.NET/Blazor + .NET MAUI + servicios) | A-06, A-09, A-11, A-15; B-02, B-03, B-11, B-12 | Políticas y *claims* de ASP.NET Core; validación de formularios de Blazor (anotaciones de datos, `ValidationMessage`); recursos y localización; ayuda en MAUI |
| CA-5 | Academia: retórica y comunicación técnica, estudios de documentación | A-01, A-02, A-03, A-04 | Ede y Lunsford (audiencia dirigida e invocada); Ong; Schriver; Redish; Carroll (minimalismo); estudios empíricos de documentación (Aghajani et al., 2019, ya en `SDEI/99-Anexos/Referencias.md`) |
| CA-6 | UX y ayuda en producto | A-09, A-13; B-01, B-06, B-07, B-08 | Centros de ayuda segmentados por permiso o edición (Salesforce, Atlassian, Microsoft 365, Google Workspace); plataformas de guía en producto |
| CA-7 | Agentes y LLM como audiencia | A-04, A-10, A-11; B-10 | `llms.txt` (llmstxt.org); agentes que actúan con el alcance del usuario; fuga de documentación restringida por el agente; inyección por texto |
| CA-8 | Formularios, microtexto y ayuda contextual | B-01, B-02, B-03, B-05, B-06, B-09, B-12 | GOV.UK Design System (texto de pista, mensajes de error); NN/g (marcadores, ayuda en formularios); WCAG 2.2 3.3.1–3.3.3; WAI-ARIA `aria-describedby`; JSON Schema y `ui:help` |
| CA-9 | Integración con paneles de control, portales y servicios | A-08, A-09; B-07, B-08, B-11 | Ayuda contextual por identificador de pantalla; portales de ayuda de servicios; *widgets* embebidos; el caso `{servicio-privado}` por su forma |

**Dos analistas de decisiones a ciegas** (AD-A y AD-B): cada uno, sin ver al otro, arma la matriz ponderada,
dominancia y cadena de consecuencias de las salidas que traen las comisiones para (a) la forma de la decisión de
audiencias en `K` y (b) la clase de pieza y el control del microtexto de formulario. Las discrepancias entre los
dos van al jurado como ítem.

**Un refutador**: ataca la lectura dominante y la propuesta de §6, por evidencia y por aplicación, y el objetivo
contra el pedido literal (¿hay una solución más chica que lo cumple?; ¿se dio por fijo algo que el PO no pidió?).
**Verifica al menos 15 de las fuentes citadas** por las comisiones, reabriendo la URL el día, y rotula las que no
abren o no dicen lo que se les atribuye.

**Jurado de tres**: vota por separado cada pregunta A-nn y B-nn y la tabla de §5.3; el resultado y las disidencias
van al acta y la presidencia los consolida en `F399` sin votar.

**Cartas.** Cada carta sale del esqueleto de `MEP` §5.2, con la ruta y la versión de `MEP`, la línea
«Secciones … leídas», la lectura P0–P3 del caso y la cláusula fija sobre mensajes de otras sesiones (si llegan, no
se cambia de tarea: se anotan). Se archiva en `evidencia/` antes de despachar.

## 8. Fuentes semilla verificadas hoy

Consultadas por la presidencia el 2026-11-01. Son punto de partida, no conclusión: cada comisión las vuelve a
abrir y suma las suyas.

| Fuente | Qué dice (en lo que importa al ciclo) | URL |
| --- | --- | --- |
| W3C, *Understanding SC 3.3.2: Labels or Instructions* (WCAG 2.2) | Nivel A: «Labels or instructions are provided when content requires user input» | https://www.w3.org/WAI/WCAG22/Understanding/labels-or-instructions.html |
| GOV.UK Design System, *Text input* | Usar texto de pista «for help that's relevant to the majority of users»; una sola oración corta, sin enlaces; no usar marcador en lugar de etiqueta; el ejemplo asocia la pista con `aria-describedby` | https://design-system.service.gov.uk/components/text-input/ |
| Sherwin, K. (2014, revisado 2018), *Placeholders in Form Fields Are Harmful*, Nielsen Norman Group | No reemplazar etiquetas por marcadores; etiquetas visibles fuera del campo | https://www.nngroup.com/articles/form-design-placeholders/ |
| Microsoft Learn, *ASP.NET Core Blazor forms validation* (actualizado 2026-10-29) | Validación con anotaciones de datos y `DataAnnotationsValidator`; mensajes por campo con `ValidationMessage<TValue>` y resumen con `ValidationSummary`; `ErrorMessage` en el atributo | https://learn.microsoft.com/en-us/aspnet/core/blazor/forms/validation |
| react-jsonschema-form, *uiSchema* | `ui:help` agrega texto de guía al campo, debajo del control; `ui:description` y `ui:placeholder` | https://rjsf-team.github.io/react-jsonschema-form/docs/api-reference/uiSchema/ |
| OASIS DITA 1.3, *Conditional processing (profiling)* | Atributos de procesamiento condicional: `@audience`, `@deliveryTarget`, `@otherprops`, `@platform`, `@props` | https://docs.oasis-open.org/dita/dita/v1.3/os/part1-base/archSpec/base/condproc.html |
| Microsoft Learn, *Manage developer accounts using groups – Azure API Management* | «groups are used to manage the visibility of products to developers in the developer portal»; grupos fijos Administrators, Developers, Guests y grupos propios (p. ej., por socio) | https://learn.microsoft.com/en-us/azure/api-management/api-management-howto-create-groups |
| NIST SP 800-162, *Guide to Attribute Based Access Control (ABAC) Definition and Considerations* (2014, act. 2019) | ABAC decide por atributos del sujeto, del objeto, de la acción y del entorno contra políticas | https://csrc.nist.gov/pubs/sp/800/162/upd2/final |
| MITRE, CWE-200 | «Exposure of Sensitive Information to an Unauthorized Actor» | https://cwe.mitre.org/data/definitions/200.html |
| llmstxt.org | Propuesta de Jeremy Howard (2024-09-03) de un `/llms.txt` en la raíz o en un subcamino; **no** es mecanismo de control de acceso | https://llmstxt.org/ |
| Pendo, *Take a tour of Pendo* | Guías en producto (mensajes, recorridos, *tooltips*) y segmentos de visitantes y cuentas para dirigirlas; centro de recursos | https://support.pendo.io/hc/en-us/articles/20826000368411-Take-a-tour-of-Pendo |

## 9. Folios esperados y orden

| Folio | Quién | Contenido |
| --- | --- | --- |
| `F304` | Jurado de composición | Acta de composición del panel de §7 |
| `F310`–`F318` | CA-1 a CA-9 | Un informe por comisión, verbatim, en la ruta que le da su carta, con «lo que revisé y está bien» y la tabla de §5.3 |
| `F380`, `F381` | AD-A, AD-B | Análisis de decisiones a ciegas |
| `F385` | Refutador | Refutación, con la verificación de ≥ 15 fuentes |
| `F395` | Jurado del ciclo 3 | Acta del veredicto, votos por separado |
| `F399` | Presidencia | Resolución: qué rehacer del cuerpo, del conocimiento, del libro y de los ensayos, en qué orden, y si los oráculos se re-sellan |

## 10. Lo que queda en espera

- **Ronda 3 de los ensayos** (`F204` §9): su preparación sigue (aislamiento de red, correcciones de la 1.2), pero
  **no se sella ni se corre** hasta `F399`. Si la resolución pide filas de audiencia en los oráculos, se sellan con
  ellas.
- **Redacción del libro** en lo que toca a la Parte III y a los capítulos de ayuda y API: se suspende hasta `F399`;
  lo demás sigue según `F099`.
- **Conocimiento `K` 1.2**: no se publica una 1.3 hasta `F399`; las correcciones de la ronda 2 ya hechas se
  conservan.

## 11. Lo no verificado e incidencias

- **Primer tramo del pedido (§2.1):** transcripto del despacho que recibió la presidencia; no hay huella del chat
  en este folio. El segundo tramo (§2.2) es literal del relevo del pedido.
- **Salesforce, ayuda de campo (*field-level help*)**: sólo se encontraron fuentes de terceros y una guía de
  estilo de Salesforce que devolvió 403 el 2026-11-01: **sin verificar** en fuente oficial. Queda para CA-6.
- **WAI-ARIA 1.2, definición de `aria-describedby`**: la página abrió, pero la definición no se leyó en la porción
  consultada: **sin verificar**. Queda para CA-8.
- **Centros de ayuda de Atlassian, Microsoft 365 y Google Workspace segmentados por permiso o edición**: nombrados
  como mandato de CA-6, **sin verificar** hoy por la presidencia.
- **Referencias académicas de CA-5** (Ede y Lunsford, Ong, Schriver, Redish, Carroll): nombradas como mandato,
  **sin verificar** hoy por la presidencia; la comisión trae la referencia bibliográfica completa.
- Mensajes de otras sesiones durante la redacción: ninguno.

## 12. Barrido de lo privado de este folio

Se buscaron nombres de máquina, rutas absolutas del sistema de archivos y el nombre real del servicio privado:
el servicio va como `{servicio-privado}`, el directorio de trabajo como `{dir-de-trabajo}`, y las rutas de los
repositorios por alias (`SDEI/`, `EXP3/`, `K`). Resultado esperado del comando de barrido sobre este archivo: 0
coincidencias.
