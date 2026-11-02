---
doc_id: EXP0003-F360
doc_type: informe
title: Informe de la comisión CA-6 (UX y ayuda en producto) — audiencias que rotulan, dirigen o restringen, y la documentación en el punto de uso de paneles, portales y formularios
status: vigente
origin: agent
confidence: alta en las citas al cuerpo SDEI (00171bd), a K 1.2, a F099 y a F300, leídas el 2026-11-01, y en las fuentes externas marcadas «verificada» (abiertas el 2026-11-01); media en las propuestas, rotuladas [criterio propio] donde no salen de una fuente; baja en lo rotulado «sin verificar»
owner: comisión CA-6 «UX y ayuda en producto» del ciclo 3 de la mesa de la reedición DocsAsCode (expediente 0003)
last_review: 2026-11-01
audience: [presidencia, refutador, análisis de decisiones, jurado del ciclo 3, editores, PO]
traces: [EXP0003-F300, EXP0003-F099, EXP0003-F204, TEM-SDEI-05, TEM-SDEI-04, MARCO-SDEI, DEMO-MU-11, DEMO-MU-21]
---

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-01 |
| Autor | Comisión CA-6, especialista en UX y ayuda en producto. A ciegas: no leí ningún informe de otra comisión del ciclo 3 |
| Corrige | — |

| Cabecera de comisión | Valor |
| --- | --- |
| Preguntas a cargo (F300 §7) | A-09, A-13; B-01, B-06, B-07, B-08. Contesto además las demás A-nn y B-nn desde esta especialidad, más breve (§5.3) |
| No competencia | Implementación de autorización en .NET (CA-4), modelo de control de acceso (CA-3), retórica y academia de la audiencia (CA-5), agentes (CA-7). Lo que encontré ahí va como señal en §11 |
| Norma | `Knowledge-Mesa-De-Expertos-A-Pedido` (`MEP`) 3.1 |
| Secciones de `MEP` 3.1 leídas | Cabecera (l. 1-15); §5.2 «Despacho de una comisión» (l. 375-414); índice de secciones (`grep -n '^#'`). `MCT` no se cargó: esta comisión no consultó a ningún tercero |
| Otros documentos cargados | `SDEI/99-Anexos/Como-Decidir.md` §2-§4 (criterios K1-K7, escala anclada, filtros, regla de firmeza), que uso para puntuar en §6 |
| Insumos leídos | `F300` entero (incluida §6, porque la carta me pide puntuarla: ver §12, incidencia 1); `F099` §5.2 (l. 190-215); `F204` índice y §7 (l. 198-225); `K` §2.3 (l. 163-180), D-01 (l. 262), D-13 (l. 274) |
| Objeto leído directamente | `SDEI/` en `00171bd`: `TEM-05` entero; `TEM-04` §3.5 (l. 196-201); `00-Marco.md` §2 (l. 60-115); `99-Anexos/Glosario.md` (términos Actor, Integración, Letra, Rol); `99-Anexos/Esquema-Frontmatter-Y-Prefijos.md:64`; `Examples/Prueba-Ayuda-Por-Rol/` (README, `Web/Components/AyudaContextual.razor`, `Web/HelpCatalog.cs`, una página de ayuda); `Examples/MovilidadUrbana-Mini-Demo/` (ficha `RN-LOC-01`, página `alta-de-localidad.md`); y del repositorio `LD`, `tools/docs-guard/esquemas/ayuda.schema.json` |
| Medios propios | Lectura con `sed`, `grep` y `cat -n`; 31 consultas web el 2026-11-01 (WebFetch y WebSearch; `curl` para dos páginas de Salesforce que devolvieron 403). Ningún ensayo ejecutado |

## Índice

1. [Definiciones y lectura del caso](#1-definiciones-y-lectura-del-caso)
2. [Tesis de la comisión](#2-tesis-de-la-comisión)
3. [Estado del arte desde UX y ayuda en producto](#3-estado-del-arte-desde-ux-y-ayuda-en-producto)
4. [Dictamen por pregunta a cargo](#4-dictamen-por-pregunta-a-cargo)
5. [Propuesta concreta](#5-propuesta-concreta)
6. [Puntuación de la hipótesis y de las alternativas](#6-puntuación-de-la-hipótesis-y-de-las-alternativas)
7. [Las demás preguntas, desde esta especialidad](#7-las-demás-preguntas-desde-esta-especialidad)
8. [Qué rehacer: pieza → cambio → motivo → costo → orden](#8-qué-rehacer-pieza--cambio--motivo--costo--orden)
9. [Riesgos](#9-riesgos)
10. [Lo que revisé y está bien](#10-lo-que-revisé-y-está-bien)
11. [Fuentes externas](#11-fuentes-externas)
12. [Lo no verificado, señales e incidencias](#12-lo-no-verificado-señales-e-incidencias)
13. [Barrido de lo privado de este folio](#13-barrido-de-lo-privado-de-este-folio)

---

## 1. Definiciones y lectura del caso

| Término | Definición que uso en este informe |
| --- | --- |
| Audiencia | Grupo de lectores que comparte una necesidad documental y un mismo derecho de acceso: la fila de la matriz (§5.1). Rol, alcance, superficie y lector son sus dimensiones, no sinónimos [criterio propio, a contrastar con CA-1 y CA-5] |
| Punto de uso | El lugar de la interfaz donde la persona necesita la información para seguir: un campo, una pantalla, un paso. Es la «presentación en contexto» de la heurística 10 de NN/g (§11, S-01) |
| Microtexto | Texto corto atado a un control de la interfaz: etiqueta, pista, información desplegable, ejemplo, mensaje de validación. En el glosario del cuerpo es parte de la **letra** («el texto de ayuda bajo el campo y los mensajes», `SDEI/99-Anexos/Glosario.md:78`) |
| Rotular / dirigir / restringir | Tres usos distintos de un mismo atributo de audiencia (§2): **rotular** es decir en el contenido a quién aplica, sin quitarlo a nadie; **dirigir** es mostrar u ocultar por relevancia; **restringir** es no entregar. Sólo el tercero protege (`SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:48`) |
| ID de contexto | Identificador estable que une una pantalla o un campo con un tema de ayuda, independiente de la URL de la página. En la prueba de concepto es el campo `topic` (`LD:tools/docs-guard/esquemas/ayuda.schema.json:12`) |

**Lectura P0–P3 para este caso** [criterio propio: `F300` no trae la lectura]: **P0**, una salida que entrega a una
audiencia documentación que no le corresponde (fuga por acceso); **P1**, un requisito literal del PO (`F300` E-01 a
E-05, E-08 a E-10) sin respuesta; **P2**, una deriva entre la ayuda y la regla que nadie detecta antes del merge;
**P3**, una mejora editorial o de forma.

## 2. Tesis de la comisión

1. **La industria usa el atributo de audiencia de tres maneras, con garantías distintas, y el cuerpo sólo nombra dos.**
   Los centros de ayuda públicos **rotulan** (Google Workspace imprime «Supported editions for this feature»;
   Microsoft Learn lleva `audience: Admin` en el frontmatter de una página pública); las plataformas de guía en
   producto **dirigen** (Salesforce por perfil, Pendo por segmentos, Appcues por propiedades que manda la app); los
   centros de ayuda con permisos **restringen** (Zendesk por segmentos de usuario, Confluence por restricciones de
   página que heredan los hijos). `TEM-05` distingue visibilidad de acceso (l. 48) pero no tiene nombre para la
   relevancia, que es lo que más se usa en producto. Una matriz de audiencias que no diga, fila por fila, cuál de
   los tres usos aplica confunde «no se lo muestro» con «no se lo entrego»: es la puerta de un P0.
2. **La ayuda en el punto de uso es una escalera de capas, y docs as code hoy cubre los dos extremos y no el medio.**
   La etiqueta y la pista (persistentes), la información desplegable, el mensaje de validación, el enlace contextual,
   el recorrido guiado y el centro de ayuda. El cuerpo cubre la página de ayuda (`TEM-05`) y el enlace contextual (la
   prueba `topic`), pero el microtexto vive en el código y la ficha lo copia a mano: en la mini demo el mismo «Entre 3
   y 60 caracteres» está en tres lugares (ficha `RN-LOC-01.md:37`, página `alta-de-localidad.md:50`, recurso de la
   app), y ninguna compuerta compara los tres.
3. **El ID de contexto es el contrato entre el producto y la documentación** (MadCap Flare: archivo de cabecera con IDs
   que el autor entrega al desarrollador; Visual Studio: metaetiqueta `Microsoft.Help.F1`). La prueba de concepto ya lo
   tiene (`topic`) y ya hace lo correcto por audiencia —si el rol no ve la página, el enlace no se dibuja
   (`AyudaContextual.razor:3-9`)—, pero ningún control comprueba que cada ID que usa la interfaz exista.
4. **Las plataformas comerciales de guía en producto dejan el contenido fuera del repositorio** (Pendo: se edita en su
   propio diseñador; la traducción por XLIFF «no se actualiza» si la guía cambia después de exportar). Sirven para
   recorridos y anuncios; no sirven para microtexto que traza a una regla.

## 3. Estado del arte desde UX y ayuda en producto

Toda fuente se abrió el 2026-11-01; la tabla completa con URL está en §11.

### 3.1 Segmentación de centros de ayuda: rotular, dirigir, restringir

| Caso | Mecanismo | Uso | Fuente |
| --- | --- | --- | --- |
| Google Workspace Admin Help | Cada artículo imprime «Supported editions for this feature: …» y enlaza «Compare your edition». El artículo es público para todos | Rotula por edición | S-10 (verificada) |
| Microsoft Learn, ayuda del Microsoft 365 admin center | La página pública «About administrator roles» declara en su frontmatter `audience: Admin`, `f1.keywords: CSH` y monikers de nube (`o365-worldwide`, `o365-21vianet`); su fuente es un Markdown en GitHub. El texto recomienda «the fewest permissions» y describe roles acotados frente al Global Administrator | Rotula por rol y variante; la variante de nube se elige por moniker en la misma fuente | S-11 (verificada) |
| Microsoft Learn, .NET MAUI | El Markdown fuente lleva `::: moniker range="net-maui-11.0"` … `::: moniker-end` para un bloque que sólo aplica a una versión | Condicional por versión en la misma fuente (análogo a DITA `@audience`) | S-12 (verificada) |
| Salesforce, In-App Guidance | El tipo de metadato `Prompt` restringe la guía a «Everyone» o a «SpecificProfiles», y en versiones nuevas a filtros de permiso (`uiFormulaRule`) | Dirige por perfil y permiso | S-13 (por extracto del buscador; la página oficial devolvió 403: **sin verificar en la página**) |
| Pendo | «Segments are groups of visitors and accounts that you define based on metadata and product usage», para «target guides to specific users»; un «Resource Center» dentro de la app | Dirige por segmento | S-14 (verificada; actualizada 2026-10-05) |
| Appcues | Se apunta cada experiencia por propiedades del usuario (rol, plan) que la app pasa por `Appcues.identify()` | Dirige por propiedades que manda el cliente | S-15 (verificada) |
| Zendesk Guide | Segmentos de usuario (usuarios con sesión o personal; filtrados por etiquetas, organizaciones, grupos); hasta 10 segmentos por artículo; «Any user who belongs to at least one of the applied user segments will be able to view that article» | Restringe | S-16 (verificada) |
| Confluence Cloud | Una restricción de vista «won't display for anyone who doesn't have permission to view it», se hereda a las páginas hijas, y una página no puede dar más acceso que su espacio | Restringe, con herencia por jerarquía | S-17 (verificada) |
| Atlassian, base de conocimiento de Jira Service Management | Restringir artículos a sólo agentes depende de permisos de Confluence; hilos de la comunidad reportan que lo restringido deja de mostrarse dentro de Jira | Restringe, con fricción | S-18 (sólo comunidad: **sin verificar** en documentación oficial) |

**Lectura.** Los centros de ayuda *públicos* de los cuatro casos comerciales del mandato **rotulan** por edición o rol
y no ocultan: el administrador acotado lee la misma página que el global, con la marca de quién puede hacer la tarea.
Esa es la práctica dominante para documentación pública (no hay secreto que proteger). El **restringir** aparece cuando
el contenido es de un cliente, de un socio o interno (Zendesk, Confluence). El **dirigir** aparece en la ayuda dentro del
producto. El pedido del PO (`F300` E-01, E-04, E-05) junta los tres: panel con raíz y no raíz (sobre todo rotular y
dirigir), alcance por aplicación (dirigir, o restringir si el contenido de una aplicación es privado de otra), API para
desarrolladores elegidos (restringir).

### 3.2 La escalera de la ayuda en el punto de uso (formularios)

NN/g separa la ayuda **proactiva** (antes del problema: tutoriales, superposiciones, ayuda contextual, *tooltips*,
asistentes) de la **reactiva** (después: preguntas frecuentes, documentación técnica, videos) (S-02), y dentro de la
proactiva prefiere la «pull revelation», la que dispara una señal de que la persona la necesita, sobre el tutorial de
arranque, que «interrupt users, don't necessarily improve task performance, and are quickly forgotten» (S-03).

| Capa | Qué es | Qué dice la industria | Fuente |
| --- | --- | --- | --- |
| 0. Etiqueta o instrucción | Lo mínimo que exige el campo | WCAG 2.2 SC 3.3.2, nivel A: «Labels or instructions are provided when content requires user input», y advierte que demasiada información daña tanto como poca | S-04 |
| 1. Pista persistente (*hint*, *helper text*) | Una línea bajo la etiqueta, siempre visible | GOV.UK: «for help that's relevant to the majority of users», una sola oración corta, sin enlaces, asociada con `aria-describedby`. Carbon: «pertinent information that assists the user», persistente salvo cuando la reemplaza un error. Fluent 2: «Helper text sits below a field and guides people on how to fill it in correctly». Atlassian Design System: «Use for information that clarifies the input» | S-05, S-06, S-07, S-08 |
| 2. Marcador (*placeholder*) | Texto dentro del campo vacío | Desaconsejado como etiqueta o para información esencial: NN/g (Sherwin, 2014, revisado 2018), GOV.UK, Carbon; el Atlassian Design System dice «Don't use placeholder text» salvo en búsqueda | S-09, S-05, S-06, S-08 |
| 3. Información desplegable (*tooltip*, *toggletip*, ícono de ayuda) | Detalle a pedido | NN/g: lo vital no va en un *tooltip* («Users shouldn't need to find a tooltip in order to complete their task»), y debe abrir también con teclado. Carbon: el *toggletip* abre al clic, queda abierto y admite elementos interactivos; el *tooltip*, no. Salesforce: la «field-level help» es un texto por campo que aparece al pasar sobre el ícono, y vive en el metadato del campo (`inlineHelpText`) | S-19, S-20, S-21 (Salesforce por extracto del buscador: **sin verificar en la página**) |
| 4. Mensaje de validación | Qué falló y qué hacer | Fluent 2: «guide people in how to move forward when their entry isn't valid». GOV.UK: un mensaje específico por estado de error | S-07, S-05 |
| 5. Enlace contextual a la página de ayuda | De la pantalla o el campo a un tema | MadCap Flare: IDs en un archivo de cabecera que el autor entrega al desarrollador, que hace la llamada por ID; Visual Studio: metaetiqueta `Microsoft.Help.F1` y, con varios valores, «Order matters»; Zendesk Web Widget: `helpCenter:setSuggestions` por búsqueda, etiquetas o URL | S-22, S-23, S-24 |
| 6. Recorrido guiado o anuncio | Pasos superpuestos a la interfaz | NN/g lo admite para interacciones nuevas, con moderación (S-03). Pendo, Salesforce, Appcues, WalkMe; en código abierto, Shepherd.js define cada paso en código (`attachTo`, `text`), con licencia AGPL-3.0 o comercial | S-14, S-13, S-15, S-25 |
| 7. Centro de ayuda o portal | Páginas completas, buscables | NN/g: «easy to search» y con pasos concretos (S-01); adaptativa sólo si acierta, con búsqueda siempre a mano (S-26) | S-01, S-26 |

**Lo que el cuerpo cubre hoy, por capa.** Capa 7 y 5: `TEM-05` y la prueba de concepto (página por rol, `.md`,
`llms.txt`, enlace contextual por `topic`). Capas 1, 3 y 4: aparecen sólo como **letra** citada en la ficha
(`RN-LOC-01.md:37`) y como tabla «Qué pide cada campo» de la página (`TEM-05:271-272`, plantilla); el texto real está en
el código del producto y no tiene ancla (`K` D-13, l. 274: «el texto localizado en archivos de recursos no se ancla»).
Capa 2: nada (correcto: no debería llevar información). Capa 6: nada. Capa 0: fuera del alcance documental (es
interfaz), pero WCAG la vuelve obligatoria.

### 3.3 Docs as code con audiencia en el metadato: el caso Microsoft Learn

Es el único caso comercial verificado hoy donde la ayuda de un panel de administración con roles jerárquicos
(Global Administrator, y roles acotados como Password o Helpdesk Administrator) se escribe como Markdown versionado en
Git, con la audiencia como metadato (`audience: Admin`), la variante de producto como moniker en la misma fuente, y
claves de ayuda contextual (`f1.keywords: CSH`) (S-11, S-12). La página además apunta al producto con enlaces de
redirección estables (`go.microsoft.com/fwlink/?linkid=…`) en lugar de URL del panel (S-11, observado en el cuerpo de
la página). Lo que **no** hace: no restringe; la documentación de un rol acotado es pública. Es la forma de «rotular»
llevada a docs as code, y es exactamente lo que el cuerpo no tiene hoy: un campo de audiencia con vocabulario y una
variante en la misma fuente.

### 3.4 Plataformas de adopción digital frente a docs as code

| Propiedad | Plataforma comercial (Pendo, Appcues, WalkMe, Salesforce In-App Guidance) | Docs as code (cuerpo SDEI) |
| --- | --- | --- |
| Dónde vive el texto | En el editor del proveedor (Pendo: «Visual Design Studio») | En el repositorio |
| Revisión | La del proveedor; sin pull request | Pull request y compuerta |
| Versión | Del proveedor; Pendo expone historial de cambios por API según un conector de terceros (**sin verificar** en Pendo) | `ID@versión` y SHA |
| Traducción | Pendo: XLIFF por idioma; «The translation file doesn't update if you edit your guide content … after exporting» (S-27) | `translation_of` con commit (propuesto, no existe el control: `TEM-05:191-193`) |
| Audiencia | Segmentos y propiedades que la app manda (Appcues: `identify()`) | Rol de la sesión resuelto en el servidor (`TEM-05:103-109`) |
| Traza a la regla | No existe | Existe para páginas (`traces`) |
| Fuerza | Lo edita quien no programa, sin despliegue; analítica de uso | Detecta la ayuda atrasada antes del merge |

## 4. Dictamen por pregunta a cargo

### B-01 — Mecanismos de microtexto y su estado del arte

**Respuesta.** La práctica convergente de cinco sistemas de diseño públicos (GOV.UK, Carbon, Fluent 2, Atlassian,
y NN/g como investigación) es: etiqueta siempre visible; **pista persistente** de una oración para lo que la mayoría
necesita; nada esencial en el marcador ni en el *tooltip*; información desplegable sólo para detalle; mensaje de
validación específico, que diga qué hacer; y enlace a la página para lo largo (§3.2, S-04 a S-09, S-19, S-20). Se
desaconseja: el marcador como etiqueta, los enlaces dentro de la pista, lo vital en un *tooltip*, y la ayuda adaptativa
que no acierta (S-26).

**Qué cubre el cuerpo.** La plantilla de `TEM-05` ya pide «Qué pide cada campo» y «Si algo sale mal» con el mensaje
literal (`TEM-05:271-277`) y la ficha ya separa letra, intención y comportamiento (`RN-LOC-01.md:37-39`). **No cubre**:
ninguna taxonomía de capas, ningún criterio de qué va en la pista y qué en la página, y ninguna regla de que la pista
no repita la página.

**Propuesta.** Las capas de §3.2 entran en el cuerpo como vocabulario cerrado del campo `capa` del catálogo de
microtexto (§5.3): `etiqueta · pista · info · ejemplo · validacion`. Regla de contenido [criterio propio, tomada de
S-05 y S-19]: lo que hace falta para completar el campo va en `pista`, nunca sólo en `info`; `info` sin `pista` en un
campo con regla es aviso.

### B-06 — Por audiencia y por idioma

**Respuesta.** El texto de un mismo campo cambia por audiencia en dos casos, y sólo en esos: (a) el **alcance** cambia
el límite que la persona puede poner (el administrador de una aplicación ve «hasta el tope que fijó el administrador
raíz»; la raíz ve el tope global); (b) la **superficie** cambia el canal (en .NET MAUI, `SemanticProperties.Hint`
«conflicts with the `Entry.Placeholder` property on Android, which both map to the same platform property», S-28, y
la pista visible bajo el campo no existe como control nativo). Fuera de esos casos, un texto por audiencia multiplica
traducciones sin beneficio [criterio propio].

**Industria.** Microsoft Learn resuelve variantes en la misma fuente por moniker (S-11, S-12); DITA lo hace con
`@audience` (fuente semilla de `F300` §8, no reabierta por esta comisión: es de CA-1). Pendo localiza por XLIFF y
declara que la traducción queda atrás si el original cambia (S-27): el mismo problema que `TEM-05` §3.4 quiere
controlar.

**Qué cubre el cuerpo.** Idioma para páginas: fuente con aviso, nunca 404 (`TEM-05:189-196`); el control de traducción
atrasada no existe (l. 192-193). Microtexto localizado: sin ancla (`K` D-13). Audiencia del microtexto: nada.

**Propuesta.** En el catálogo de microtexto (§5.3), la clave de una entrada es `id` + `audiencias` + `superficie`; una
variante por audiencia exige que la entrada nombre la dimensión que la justifica (`varia_por: alcance | superficie`), y
sin ella el control avisa «variante sin motivo». La traducción se ancla igual que la página: `traducido_de: <id>@<sha>`
o `@<regla>@<versión>`, y el control de traducción atrasada se escribe una sola vez para páginas y microtexto.

### B-07 — Integración con paneles y portales de servicios

**Respuesta.** Tres patrones verificados:

1. **ID de contexto con archivo de mapeo** entre producto y ayuda (MadCap Flare, S-22; Visual Studio F1, S-23). El
   autor dueño de los IDs se los entrega al desarrollador; la llamada es por ID, no por URL.
2. **Sugerencias por contexto** en un *widget* embebido (Zendesk `helpCenter:setSuggestions`, por búsqueda, etiquetas o
   URL de la pantalla, S-24): no hay ID; la pantalla manda una consulta.
3. **Enlace estable de redirección** desde la documentación al producto y al revés (`go.microsoft.com/fwlink/?linkid=…`
   en la página de roles de Microsoft 365, S-11): la URL de destino puede cambiar sin romper el enlace.

**Qué cubre el cuerpo.** El patrón 1 ya está en la prueba de concepto: `topic` en el frontmatter (esquema
`ayuda.schema.json:12`, ejemplo `Web/Ayuda/es/alumno/enviar-un-trabajo.md:7` con `topic: envio`), el componente
`AyudaContextual` que lo consulta con el rol y el idioma (`AyudaContextual.razor:12-19`, `HelpCatalog.cs:78-79`) y no
dibuja nada si el rol no ve la página (l. 3). **No cubre**: (a) ningún control comprueba que cada `Tema="…"` usado en la
interfaz tenga página; (b) nada dice que `topic` es un ID estable y versionado (renombrarlo rompe el enlace sin rojo);
(c) el portal de desarrolladores y el panel de cada servicio del paquete no aparecen.

**Propuesta.** El ID de contexto se vuelve parte del contrato documentado (§5.4): vocabulario `ctx.<unidad>.<pantalla>[.<campo>]`,
estable entre versiones, renombre sólo con alias; dos controles nuevos (`contexto-resuelve`, bloquea;
`contexto-huerfano`, avisa). Para un paquete con varios servicios (`F300` E-03), cada servicio publica su propio
catálogo de ayuda con prefijo de unidad, y el portal común (si existe) sólo enlaza por ID, nunca copia páginas
[criterio propio]. La integración con el portal de desarrolladores restringido es de CA-2; desde UX sólo agrego que el
enlace contextual desde el panel al portal (p. ej., «¿Cómo se integra?» en la pantalla de claves) se dibuja sólo para
la audiencia que tiene acceso al portal: el mismo patrón de `AyudaContextual`.

### B-08 — Plataformas de guía en producto

**Respuesta.** Hacen recorridos, *tooltips*, anuncios, listas de tareas y centros de recursos dentro del producto,
dirigidos por segmentos o propiedades (S-13 a S-15, S-25); el contenido vive en el editor del proveedor, se traduce por
exportación (S-27) y no tiene traza a una regla (§3.4). **Se gana**: autoría sin despliegue, analítica de uso, recorridos
que el cuerpo no ofrece. **Se pierde**: revisión por pull request, traza `ID@versión`, detección de ayuda atrasada,
y —porque la audiencia la manda el cliente con `identify()`— el dirigir no sirve para restringir [criterio propio,
inferido de S-15: la propiedad viaja desde la app].

**Propuesta.** El cuerpo admite una plataforma de guía como **canal de capa 6** con dos condiciones verificables
[criterio propio]: (1) su contenido no lleva números ni condiciones de una regla (eso es microtexto con traza, capa 1-4);
(2) su audiencia es de acceso `publico` o `autenticado`, nunca `restringido` ni `interno`. Se declara en la matriz como
canal con `modo: dirige` y `fuera_del_repo: sí`. Si el proyecto quiere recorridos con traza, la alternativa es una
biblioteca de recorridos en código (Shepherd.js es un ejemplo verificado; su licencia AGPL-3.0 pide revisar el uso
comercial, S-25) que toma el texto del mismo catálogo de microtexto.

### A-09 — Varias superficies del mismo producto

**Respuesta.** **Una fuente, salidas por superficie**, con la superficie como columna de la matriz. Motivos desde UX:
la tarea es la misma («dar de alta una aplicación») aunque cambie el gesto, y dos fuentes divergen (la mini demo ya
muestra la copia de la regla en la API sin ancla, `00-Marco.md:87`, en el texto de `ESC-SDEI-2`). La variante por
superficie se escribe en la misma página o entrada, como hace Microsoft Learn por moniker (S-12).

**Cómo viaja la ayuda en la app instalada.** Lo que se compila en el paquete lo ve quien lo instala
(`00-Marco.md:112`), y Microsoft dice de los recursos: «Do not use resource files to store passwords,
security-sensitive information, or private data» (S-29). Por lo tanto: en el paquete móvil sólo entran páginas y
microtexto de audiencias con acceso `publico` o `autenticado` **y** cuyo contenido no sea de otro alcance; lo
`restringido` se pide al servidor con la sesión y el mismo filtro que la página web. El microtexto en MAUI va por
`Placeholder` o `SemanticProperties.Hint`, que en Android son la misma propiedad (S-28): la entrada del catálogo para
`superficie: movil` no puede tener pista y marcador distintos.

**Control** (§5.5, `paquete-sin-restringido`): bloquea si el catálogo de una superficie empaquetada contiene una
entrada de acceso `restringido` o `interno`.

### A-13 — Impacto en el libro

**Respuesta.** La Parte III de `F099` §5.2 (l. 200-201) se llama «Audiencias y canales» pero trae sólo «Doble
audiencia» y «Ayuda al usuario final». Propongo:

| Nº nuevo | Capítulo | Contenido | Fuente |
| --- | --- | --- | --- |
| 7 | Audiencias | Definición y término (CA-1, CA-5); dimensiones; la matriz; rotular, dirigir, restringir; jerarquía y alcance; dónde se hace cumplir | Nuevo `TEM` o sección nueva de `00-Marco` (§8) |
| 8 | Doble audiencia | Queda, como la dimensión «lector» de cada audiencia | `TEM-04` |
| 9 | Ayuda al usuario final: páginas | Lo de hoy, con `audiencias` en vez de `roles` | `TEM-05` |
| 10 | Ayuda en el punto de uso | Capas de §3.2; catálogo de microtexto; IDs de contexto; recorridos; accesibilidad (con CA-8) | Nuevo |
| — | Portales y documentación de desarrollador restringida | Si CA-2 lo pide como capítulo; si no, sección de 7 | CA-2 |

Las Partes IV a VI corren dos números. El capítulo 18 (industria) suma una sección «Centros de ayuda segmentados y
guía en producto» con los casos de §3.1 y §3.4 (reverificados al redactar, como manda P-07 en `F099`). La ruta de
lectura «escribo la ayuda de un producto» del prólogo (`F099` §5.2, fila Prólogo) pasa a recorrer 7, 9 y 10.

## 5. Propuesta concreta

### 5.1 La matriz de audiencias, con el modo de entrega

Coincido con la forma de la hipótesis de la presidencia y le agrego dos columnas que salen de §3.1: **modo** y
**canales con capa**.

| Columna | Valores | Por qué |
| --- | --- | --- |
| `id` | `AUD-<n>`, del registro de prefijos | Lo citan las páginas y el microtexto |
| `rol` | Nombre del rol tal como lo guarda el producto (inventario de autorización de `K` D-01) | Ya es la regla de `TEM-05:163` |
| `hereda_de` | `AUD-<n>` o vacío | Jerarquía raíz ⊃ admin de aplicación (`F300` E-01) |
| `alcance` | `global · por-aplicacion · por-inquilino` | `F300` E-04 |
| `superficie` | `panel · movil · api · servicio:<nombre>` | `F300` E-02, E-03 |
| `lector` | `humano · agente · ambos` | `TEM-04` como dimensión |
| `acceso` | `publico · autenticado · restringido · interno` | `F300` E-05 |
| `modo` | `rotula · dirige · restringe` | §2.1. Regla: `acceso ∈ {restringido, interno}` ⇒ `modo = restringe` |
| `se_cumple_en` | `build · servidor · portal · repo-privado` | `TEM-05:103-109` |
| `canales` | `pagina · campo · contexto · recorrido · portal · llms · paquete` | §3.2 |

### 5.2 Frontmatter de la página de ayuda

`roles: [Student]` pasa a `audiencias: [AUD-02]` (el rol queda en la matriz, no repetido en cada página), más
`topic` → `contexto: ctx.envio.formulario` y, en la página que vale para varias audiencias con una diferencia,
bloques condicionales por audiencia **sólo** si el modo de esas audiencias es `rotula` o `dirige`; con `restringe`,
páginas separadas (un bloque condicional que se filtra en la vista es visibilidad, no acceso) [criterio propio].

### 5.3 Catálogo de microtexto (respuesta a B-02, B-03, B-04 desde UX)

Un archivo por unidad, en el repositorio del código (cambia en el mismo pull request que la regla: `K` D-05), del que
el build **deriva de forma determinista** (clase D) el recurso que lee la interfaz (`.resx` o JSON). La persona escribe
el texto en el catálogo; el build no lo reescribe. No es una clase nueva: es el **canal `campo` de `CL-06`**, con su
propio esquema.

```yaml
# [Fragmento ilustrativo: forma del caso {servicio-privado}; IDs, reglas y números inventados para el ejemplo]
- id: ctx.app-config.envios-por-minuto     # ID de contexto: lo usa la vista, no cambia entre versiones
  capa: pista                              # etiqueta | pista | info | ejemplo | validacion
  regla: RN-ENV-03@1.2                     # traza con versión, la misma regla de las páginas
  audiencias: [AUD-01]                     # administrador raíz
  superficie: panel
  parametros: {min: 1, max: 600}
  texto: {es: "Entre 1 y 600 envíos por minuto para todo el servicio"}
- id: ctx.app-config.envios-por-minuto
  capa: pista
  regla: RN-ENV-03@1.2
  audiencias: [AUD-02]                     # administrador de una aplicación (alcance por-aplicacion)
  superficie: panel
  varia_por: alcance
  parametros: {min: 1, max: tope-de-la-raiz}
  texto: {es: "Entre 1 y el tope que fijó la administración del servicio"}
- id: ctx.app-config.envios-por-minuto
  capa: validacion
  regla: RN-ENV-03@1.2
  audiencias: [AUD-01, AUD-02]
  superficie: panel
  texto: {es: "Escribí un número entre 1 y {max}"}
```

### 5.4 Contrato de IDs de contexto

`ctx.<unidad>.<pantalla>[.<campo>]`; el ID no se renombra sin una línea `alias: <id-viejo>` que lo mantenga resolviendo
una versión mayor; la vista llama por ID (como `AyudaContextual`), nunca por URL de página. Lo mismo vale para el enlace
desde una página al producto.

### 5.5 Controles verificables en CI

Cada control, con su condición de bloqueo según la regla de `K` §2.2 (determinista, defecto introducido por el mismo
pull request, par rojo/verde, línea de base 0, sin falsos positivos conocidos). Ninguno existe hoy.

| Control | Qué comprueba | Bloquea si | Par rojo/verde |
| --- | --- | --- | --- |
| `audiencia-declarada` | Toda página de ayuda y toda entrada del catálogo declara `audiencias` del registro de la matriz | Un valor no está en la matriz | Rojo: `audiencias: [AUD-99]`. Verde: `[AUD-02]` |
| `modo-coherente` | Fila con `acceso ∈ {restringido, interno}` tiene `modo: restringe`; canal `recorrido` fuera del repo no aparece en esa fila | La matriz lo viola | Rojo: fila `restringido` + `dirige` |
| `microtexto-traza` | `traces-resolve` (PR-5) extendido a `regla:` del catálogo | Versión desfasada o ID inexistente | Rojo: `RN-LOC-01@1.0` con la ficha en 1.1 (el mismo ensayo de `TEM-05:143-153`) |
| `microtexto-letra` | Los números del `texto` son valores de `parametros`, y `parametros` coincide con los de la ficha de la regla | Un número del texto no está en la regla | Rojo: ficha `max: 60`, texto «Entre 3 y 80». Verde: «Entre 3 y 60». **No** detecta que la app acepte 80 (comportamiento): eso queda en las pruebas del producto |
| `contexto-resuelve` | Cada ID de contexto usado en la interfaz (`Tema="…"` o equivalente) tiene al menos una página o entrada | Un ID usado no existe | Rojo: `Tema="envios"` sin página |
| `contexto-huerfano` | Páginas con `contexto` que ninguna vista usa | Avisa, no bloquea (puede ser una pantalla en otro repo) | — |
| `paquete-sin-restringido` | El catálogo de una superficie empaquetada (`movil`) no contiene audiencias `restringido` o `interno` | Contiene alguna | Rojo: entrada `AUD-05` (integrador) en el catálogo móvil |
| `traduccion-atrasada` | `traducido_de` contra la fuente, para páginas y microtexto | Avisa (el cuerpo ya dice «nunca 404», `TEM-05:189`) | Rojo: fuente cambió después del SHA declarado |

`microtexto-letra` necesita que la ficha declare sus parámetros en forma legible por máquina; hoy la ficha los dice en
prosa (`RN-LOC-01.md:35`). Es un campo más en la plantilla de ficha [criterio propio]. Si el refutador lo juzga
frágil, la versión mínima es sólo `microtexto-traza`, que reusa PR-5 tal cual.

### 5.6 Ejemplo público

Extender `Prueba-Ayuda-Por-Rol` y no armar otra [criterio propio: ya sirve página, `.md`, `llms.txt` e ID de contexto
con 404 por rol, y es el caso que funciona de `F300` §3]: (a) segundo nivel de administrador con alcance por grupo de
alumnos; (b) un formulario con pista y validación que salen del catálogo, trazadas a un caso de uso con versión; (c) el
par rojo/verde de `microtexto-letra` y `contexto-resuelve`; (d) una página restringida que sólo el administrador raíz
recibe. La superficie móvil y la API restringida exceden a esa prueba; desde UX alcanza con una captura por
superficie.

## 6. Puntuación de la hipótesis y de las alternativas

Escala anclada y pesos de `SDEI/99-Anexos/Como-Decidir.md` §3-§4 (K1, K2, K3, K5, K6, K7 = 0,15; K4 = 0,10), fijados
antes de puntuar. Cada celda cita su observable.

- **H**: propuesta de `F300` §6 (matriz, artefacto, cruce de alcance, exposición de API clase H, ayuda de campo como
  canal de `CL-06` con traza y control de desfase).
- **CA6-A**: H más el modo de entrega (§5.1), el catálogo de microtexto derivado al recurso (§5.3), el contrato de IDs
  de contexto (§5.4) y los ocho controles de §5.5.
- **CA6-B** (la más chica): sin decisión nueva; `audiencia` como vocabulario en D-13; microtexto sigue en el código y
  sólo se agrega `microtexto-traza` por comentario en el recurso.

| K | H | CA6-A | CA6-B |
| --- | --- | --- | --- |
| K1 Simplicidad | 3: dos o tres piezas (matriz, `doc_type`, control) | 2: suma catálogo, contrato y ocho controles (más de tres piezas, sin infraestructura) | 4: un campo y un control |
| K2 Practicidad | 3: paso sin medir (el cruce de alcance no existe) | 3: paso sin medir | 3: paso sin medir |
| K3 Escalabilidad | 4: una configuración (la matriz) por sistema | 4: matriz y catálogo por sistema | 4: un vocabulario por sistema |
| K4 Costo | 4: un PR mecánico más la matriz | 3: migración de los recursos de microtexto al catálogo | 5: menos de una hora |
| K5 Doble audiencia | 4: la columna lector sirve a los dos con un paso | 4: idem; el catálogo da al agente la misma ayuda de campo con el mismo filtro | 3: el agente no tiene la ayuda de campo filtrada |
| K6 Coherencia | 4: compatible, sin cambiar norma | 4: compatible; reusa PR-5, `topic` y el campo «Letra» de la ficha | 5: reusa D-13 tal cual |
| K7 Deriva | 4: el desfase de traza se detecta en el PR, el resto se declara | 5: traza, letra e ID de contexto, deterministas en el PR | 3: el microtexto sin catálogo se detecta a mano |
| **Total** | 0,15 × 22 + 0,40 = **3,70** | 0,15 × 22 + 0,30 = **3,60** | 0,15 × 22 + 0,50 = **3,80** |
| Filtro | Pasa | Pasa | **No cumple el pedido**: no modela alcance (`F300` E-04) ni API restringida (E-05) [criterio propio: no es uno de F1-F8, es el objetivo] |

**Lectura.** Los márgenes son menores que 0,30 (`Como-Decidir` §4): ninguna es firme. Excluida CA6-B por el pedido,
H y CA6-A quedan a 0,10, y CA6-A gana sólo en K7, el criterio que motivó el segundo tramo del PO («guiar o asistir con
pequeña información», `F300` §2.2) y el riesgo que el cuerpo ya conoce (60/80). Recomiendo **H con las piezas de
CA6-A en dos escalones, con revisión**: primero modo de entrega, `audiencia-declarada`, `modo-coherente`,
`microtexto-traza` y `contexto-resuelve` (todas de una pieza o un control); después `microtexto-letra` y
`paquete-sin-restringido`, con la condición comprobable «el par rojo/verde corre verde en la prueba de concepto
extendida (§5.6)».

## 7. Las demás preguntas, desde esta especialidad

| Pregunta | Posición de CA-6 |
| --- | --- |
| A-01 | «Audiencia» es el término de la industria de UX y del pedido; «persona» de UX es un arquetipo para diseñar, no un filtro de entrega: no se usa como valor de la matriz. La definición la trae CA-1/CA-5 |
| A-02 | Desde UX, obligatorias: rol, acceso, modo y superficie; alcance y jerarquía, obligatorias sólo si el producto las tiene (inventario de D-01); idioma no es dimensión de audiencia sino de traducción (§4, B-06) |
| A-03 | La fila «Audiencias» de `00-Marco.md:108` queda como valor por defecto por escenario; la matriz del proyecto la reemplaza en A-01 |
| A-04 | Dimensión `lector` de cada fila; el capítulo 8 queda (§4, A-13) |
| A-05 | Como Confluence (S-17): lo restringido se hereda hacia abajo y un hijo no da más acceso que su padre. Una página del nivel alto no se enlaza desde una del nivel bajo (el cruce de rol de `TEM-05:179-185`, generalizado). El rotulado (Microsoft 365, S-11) es la opción para documentación pública de la jerarquía |
| A-06 | Cada `modo` con su lugar de cumplimiento (§5.1); la prueba es la de `TEM-05:223`: con la sesión que no corresponde, página, `.md` e índice devuelven nada. El modelo es de CA-3 |
| A-07 | Desde UX: el enlace contextual al portal restringido se dibuja sólo para quien tiene acceso; la decisión de exponer es de CA-2/CA-3 (coincido en que es H) |
| A-08 | Un mismo rol con dos alcances es dos filas con `varia_por: alcance` sólo donde el texto cambia (§5.3); si el contenido de una aplicación es privado de otra, `modo: restringe` |
| A-10 | El catálogo de microtexto pasa por el mismo filtro que la página para el agente del usuario; es de CA-7 |
| A-11 | Los ocho controles de §5.5 |
| A-12 | Decisión nueva, no ampliación de D-13: D-13 responde «cómo es la ayuda» y la matriz responde «para quién y con qué acceso», que también rige documentación técnica y de API. D-13 suma la opción «en el punto de uso: capas …» |
| A-14 | Si D-18 entra en `K`, el oráculo de cada caso con roles tiene que contestarla: se re-sellan sólo los oráculos de casos con roles o paquetes; el criterio de caso de `F204` no cambia desde esta especialidad |
| A-15 | §5.6 |
| B-02 | Fuente única: la persona escribe en el catálogo; el recurso se deriva (D). Lo que se pierde si se **genera** el texto desde la regla (p. ej., el `ErrorMessage` por defecto de las anotaciones): la voz del usuario, que `TEM-05:44` exige |
| B-03 | En el catálogo, no en el recurso (§5.3): el recurso es salida de build |
| B-04 | Canal `campo` de `CL-06`, con esquema propio; vive con el código; ancla `regla@versión`; controles de §5.5 |
| B-05 | `microtexto-traza` y `microtexto-letra` (§5.5) |
| B-09 | La pista se asocia con `aria-describedby` (GOV.UK, S-05); en MAUI, `SemanticProperties.Hint` (S-28). La verificación es de CA-8 |
| B-10 | Un asistente en el formulario lee el catálogo filtrado por audiencia; las pistas de capa 1 no llevan enlaces ni instrucciones al agente (anti-inyección de `TEM-04` §3.4). Es de CA-7 |
| B-11 | Es de CA-4; desde UX, el catálogo resuelto en el servidor y, en móvil, sólo lo que pasa `paquete-sin-restringido` |
| B-12 | §5.6 |

## 8. Qué rehacer: pieza → cambio → motivo → costo → orden

| Pieza | Cambio | Motivo | Costo | Orden |
| --- | --- | --- | --- | --- |
| `SDEI/00-Marco.md` §2.5 | Fila «Audiencias» como valor por defecto, con remisión a la matriz; fila «Confidencialidad» con los modos | §2.1; `00-Marco.md:108`, `:112` | Bajo | 2 |
| `SDEI/00-Marco.md` §4 | Nada desde UX: los actores no son audiencias (`Glosario.md` «Actor») | — | — | — |
| `SDEI/TEM-04` | §3.5 remite a la matriz y suma el microtexto al mismo filtro | A-04, B-10 | Bajo | 4 |
| `SDEI/TEM-05` | `roles` → `audiencias`; «Rol» y «Visibilidad y acceso» suman «relevancia» (dirigir); §3.3 generaliza cruce de rol; remite el campo a un tema nuevo | §2, §5.2 | Medio | 3 |
| Tema nuevo «Ayuda en el punto de uso» | Capas, catálogo, IDs de contexto, recorridos, plataformas | B-01, B-07, B-08 | Alto | 3 |
| `SDEI/TEM-06` | Los controles de §5.5 con su estado (avisa hasta línea de base 0) | A-11, B-05 | Medio | 5 |
| `99-Anexos/Glosario.md` | Altas: audiencia, modo de entrega (rotular, dirigir, restringir), punto de uso, microtexto, capa, ID de contexto; «Rol» remite a audiencia | §1 | Bajo | 2 |
| `Examples/` | Extender `Prueba-Ayuda-Por-Rol` (§5.6); en la mini demo, el texto de `RN-LOC-01` pasa a una entrada de catálogo | A-15, B-12 | Alto | 6 |
| `K` D-01 | Detecta audiencias y alcance con el inventario de autorización | A-03 | Bajo | 1 |
| `K` D-13 | Suma «en el punto de uso» y la remisión a la decisión nueva | A-12 | Bajo | 1 |
| `K` decisión nueva (D-18) | Matriz de audiencias y acceso con `modo` | §5.1 | Medio | 1 |
| `K` §2.3 | La fila «Audiencias» remite a D-18 | Hereda el hueco (`F300` §4) | Bajo | 1 |
| `K` A-01 | Sección con la matriz y el catálogo por unidad | §5 | Medio | 1 |
| `K` A-03 | Vocabulario `audience` = IDs de la matriz más los lectores del cuerpo | A-12 | Bajo | 1 |
| Libro (`F099` §5.2) | Parte III de dos a cuatro capítulos; cap. 18 suma una sección (§4, A-13) | A-13 | Medio | 7 |
| Oráculos de ensayos (`F204`) | Re-sellar los de casos con roles o paquetes con la fila D-18; criterio de caso sin cambio | A-14 | Medio | 8, antes de la ronda 3 |

## 9. Riesgos

| Riesgo | Nivel | Mitigación |
| --- | --- | --- |
| Usar `dirige` donde hacía falta `restringe` (p. ej., una guía de Pendo con instrucciones de la API privada) | P0 | `modo-coherente`; plataformas externas sólo con acceso `publico`/`autenticado` (§4, B-08) |
| El microtexto se vuelve un segundo centro de ayuda (pistas largas, con enlaces) | P2 | Reglas de capa de S-05 y S-19; aviso si `pista` pasa de una oración [criterio propio] |
| Variantes por audiencia que multiplican traducciones | P2 | `varia_por` obligatorio; aviso «variante sin motivo» |
| `microtexto-letra` da falsos positivos con números que no son de la regla (fechas, ejemplos) | P2 | Sólo compara números en entradas con `regla:` y `capa` ≠ `ejemplo`; si los da, queda en «avisa» (`K` §2.2, condición 5) |
| Renombrar un ID de contexto deja pantallas sin ayuda sin rojo | P2 | `contexto-resuelve` y `alias` (§5.4) |
| Sobrediseño frente a un proyecto chico sin roles | P3 | La matriz de una fila es válida; `ESC-SDEI-2` no cambia |
| El rotulado público de la jerarquía revela la estructura de privilegios del panel | P1 | Para `{servicio-privado}`, rotular sólo lo que ya es público del producto; lo de la raíz, `restringe` |

## 10. Lo que revisé y está bien

1. **La regla de acceso de `TEM-05`** (l. 103-109): 404 y no 403, mismo filtro para página, `.md` y `llms.txt`. Coincide
   con Zendesk y Confluence (S-16, S-17) y es la base correcta del modo `restringe`.
2. **El enlace contextual de la prueba de concepto** (`AyudaContextual.razor:3-9`): no dibuja nada si el rol no ve la
   página. Es el patrón de «pull revelation» de NN/g (S-03) y el de ID de contexto de MadCap (S-22), ya resuelto por
   audiencia.
3. **La plantilla de `TEM-05`** (l. 271-277): pide el mensaje literal bajo el campo y comparar cada límite con la regla;
   es la forma manual de lo que `microtexto-letra` automatiza.

## 11. Fuentes externas

Todas consultadas el 2026-11-01. «Verificada» = abrí la página y leí el pasaje citado; «por extracto» = sólo el texto
que devolvió el buscador, porque la página oficial negó el acceso.

| Id | Fuente | Estado | URL |
| --- | --- | --- | --- |
| S-01 | Nielsen, J. (1994, revisado 2024-01-30). *10 Usability Heuristics for User Interface Design*, heurística 10. NN/g | Verificada | https://www.nngroup.com/articles/ten-usability-heuristics/ |
| S-02 | Kendrick, A. (2020-12-13). *Help and Documentation (Usability Heuristic #10)*. NN/g | Verificada | https://www.nngroup.com/articles/help-and-documentation/ |
| S-03 | Laubheimer, P. (2023-02-12). *Onboarding Tutorials vs. Contextual Help*. NN/g | Verificada | https://www.nngroup.com/articles/onboarding-tutorials/ |
| S-04 | W3C. *Understanding SC 3.3.2: Labels or Instructions* (WCAG 2.2), nivel A | Verificada | https://www.w3.org/WAI/WCAG22/Understanding/labels-or-instructions.html |
| S-05 | GOV.UK Design System. *Text input* | Verificada | https://design-system.service.gov.uk/components/text-input/ |
| S-06 | IBM Carbon Design System. *Text input: usage* | Verificada | https://carbondesignsystem.com/components/text-input/usage/ |
| S-07 | Microsoft Fluent 2. *Field: usage* | Verificada | https://fluent2.microsoft.design/components/web/react/core/field/usage |
| S-08 | Atlassian Design System. *Form: usage* | Verificada (primeros 100 000 caracteres) | https://atlassian.design/components/form/usage |
| S-09 | Sherwin, K. (2014-05-11, revisado 2018-09-10). *Placeholders in Form Fields Are Harmful*. NN/g | Verificada | https://www.nngroup.com/articles/form-design-placeholders/ |
| S-10 | Google Workspace Admin Help. *Switch your Archived User edition* («Supported editions for this feature») | Verificada | https://knowledge.workspace.google.com/admin/billing/switch-your-archived-user-edition?hl=en |
| S-11 | Microsoft Learn. *About administrator roles in the Microsoft 365 admin center* (ms.date 2026-10-07; frontmatter `audience: Admin`, `f1.keywords: CSH`, monikers) | Verificada | https://learn.microsoft.com/en-us/microsoft-365/admin/add-users/about-admin-roles |
| S-12 | Microsoft Learn. *Build accessible apps with semantic properties – .NET MAUI* (fuente con `::: moniker range`) | Verificada | https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/accessibility |
| S-13 | Salesforce. *Metadata API Developer Guide: Prompt* (`userAccess`: Everyone / SpecificProfiles; `uiFormulaRule`) | Por extracto (403) | https://developer.salesforce.com/docs/atlas.en-us.api_meta.meta/api_meta/meta_prompt.htm |
| S-14 | Pendo. *Take a tour of Pendo* (actualizada 2026-10-05) | Verificada | https://support.pendo.io/hc/en-us/articles/20826000368411-Take-a-tour-of-Pendo |
| S-15 | Appcues. *Targeting by User Property* | Verificada | https://docs.appcues.com/targeting-by-user-property |
| S-16 | Zendesk. *Creating user segments for Guide user permissions* | Verificada | https://support.zendesk.com/hc/en-us/articles/4408837707290-Creating-user-segments-for-Guide-user-permissions |
| S-17 | Atlassian. *Add or Remove Page Restrictions* (Confluence Cloud) | Verificada | https://confluence.atlassian.com/confcloud/page-restrictions-724764891.html |
| S-18 | Atlassian Community. Hilos sobre restringir artículos de la base de conocimiento de Jira Service Management | Sin verificar (comunidad) | https://community.atlassian.com/t5/Jira-Service-Management/Restricting-knowledge-base-articles-to-just-agents/qaq-p/2403128 |
| S-19 | Kendrick, A. (2019-01-27). *Tooltip Guidelines*. NN/g | Verificada | https://www.nngroup.com/articles/tooltip-guidelines/ |
| S-20 | IBM Carbon Design System. *Toggletip: usage* | Verificada | https://carbondesignsystem.com/components/toggletip/usage/ |
| S-21 | Salesforce. Field-level help (`inlineHelpText` del tipo `CustomField`; componente `lightning-helptext`) | Por extracto (403); el límite de caracteres no quedó claro (255 o 510 según la fuente) | https://developer.salesforce.com/docs/platform/lightning-component-reference/guide/lightning-helptext.html |
| S-22 | MadCap Software. *Context-Sensitive Help* (Flare 2026) | Verificada | https://help.madcapsoftware.com/flare2026/Content/Flare/Step2-Authoring/CSH/CSH.htm |
| S-23 | Microsoft Learn. *Microsoft Help Viewer SDK* (Visual Studio 2017, archivado; metaetiqueta `Microsoft.Help.F1`) | Verificada | https://learn.microsoft.com/en-us/previous-versions/visualstudio/visual-studio-2017/extensibility/internals/microsoft-help-viewer-sdk |
| S-24 | Zendesk Developer. *Web Widget (Classic) Help Center API*, `helpCenter:setSuggestions` | Verificada | https://developer.zendesk.com/api-reference/widget/help-center-api/ |
| S-25 | Shepherd.js (sitio oficial; AGPL-3.0 o licencia comercial) | Verificada | https://shepherdjs.dev/ |
| S-26 | Sherwin, K. (2015-03-15). *Pop-ups and Adaptive Help Get a Refresh*. NN/g | Verificada | https://www.nngroup.com/articles/pop-up-adaptive-help/ |
| S-27 | Pendo. *Localization* (actualizada 2026-07-29) | Verificada | https://support.pendo.io/hc/en-us/articles/360031866452 |
| S-28 | = S-12, sección *Hint* (conflicto con `Entry.Placeholder` en Android) | Verificada | https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/accessibility |
| S-29 | Microsoft Learn. *Working with .resx Files Programmatically* (ms.date 2025-10-20): «Do not use resource files to store passwords, security-sensitive information, or private data» | Verificada | https://learn.microsoft.com/en-us/dotnet/core/extensions/work-with-resx-files-programmatically |

## 12. Lo no verificado, señales e incidencias

**No verificado.**

- **Salesforce** (S-13, S-21): `developer.salesforce.com` devolvió 403 a WebFetch y a `curl` el 2026-11-01. Lo dicho sale
  de extractos del buscador sobre páginas oficiales. La guía de estilo de la «field-level help» que `F300` §11 dejó
  pendiente tampoco abrió. Queda **sin verificar en la página**.
- **Atlassian, Jira Service Management** (S-18): sólo comunidad.
- **Microsoft 365 admin center, ayuda dentro del panel** (panel de ayuda contextual del propio admin center): no
  encontré documentación oficial; lo verificado es la documentación pública en Learn (S-11). **Sin verificar**.
- **Apple Human Interface Guidelines, *Onboarding***: la página no devolvió contenido legible; no la cito.
- **Historial de guías por API en Pendo**: sólo por la documentación de un conector de terceros; **sin verificar**.
- **Elemento `<comment>` de `.resx` como lugar de la traza**: no lo verifiqué; por eso §5.3 pone la traza en el
  catálogo y no en el recurso.
- **Que la propiedad de `Appcues.identify()` pueda falsearse desde el cliente** es inferencia mía (§4, B-08): **[criterio
  propio]**, para CA-3.

**Señales para otras comisiones** (no son hallazgos de esta comisión).

- CA-4: si `topic` del esquema (`ayuda.schema.json:12`) es el ID de contexto, falta que `dg.py` lo valide como
  vocabulario y lo cruce con las vistas (`contexto-resuelve`).
- CA-8: el par pista/marcador de MAUI en Android (S-28) cambia cómo se prueba B-09 en la superficie móvil.
- CA-3: la regla `acceso restringido ⇒ modo restringe` necesita su verificación del lado del servidor.

**Incidencias.**

1. **Lectura de `F300` §6.** `F300` §7 dice que las comisiones no leen la propuesta de §6 antes de entregar; la carta
   de esta comisión me ordena puntuarla, y está en el mismo archivo que tenía que leer. La leí y la puntué (§6).
   Mis tesis de §2 salen de las fuentes de §11, no de §6.
2. **Número de folio.** `F300` §9 espera los informes de CA-1 a CA-9 en `F310`–`F318` (CA-6 sería `F315`); la carta me
   asigna `F360` y la ruta `360-…`. Sigo la carta.
3. **Mensajes de otras sesiones** durante el trabajo: ninguno.

## 13. Barrido de lo privado de este folio

Se buscaron nombres de máquina, rutas absolutas del sistema de archivos y el nombre real del servicio privado: el
servicio va como `{servicio-privado}`; las rutas, por alias (`SDEI/`, `LD:`, `K`, `F0nn`). Se corrió un `grep -c` con las rutas absolutas del sistema de archivos, los nombres de máquina y el nombre real del servicio;
resultado: 0 coincidencias (el patrón no se transcribe para que el folio no se cuente a sí mismo).
