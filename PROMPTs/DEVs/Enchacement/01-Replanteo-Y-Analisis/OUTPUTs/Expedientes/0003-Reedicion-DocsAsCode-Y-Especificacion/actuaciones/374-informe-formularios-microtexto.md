---
doc_id: EXP0003-F374
doc_type: informe
title: Informe de la comisión CA-8 (formularios, microtexto y ayuda contextual) — ciclo 3, eje B
status: vigente
origin: agent
confidence: alta en las citas al cuerpo SDEI (00171bd), a K 1.2 y a las fuentes abiertas el 2026-11-01/02; media en la propuesta (criterio de la comisión, sin prototipo corrido); baja en Material 3 y Fluent 2 (no abrieron, rotuladas «sin verificar»)
owner: comisión CA-8 de la mesa del expediente 0003
last_review: 2026-11-02
audience: [análisis de decisiones, refutador, jurado del ciclo 3, presidencia]
traces: [EXP0003-F300, EXP0003-F099, EXP0003-F204]
---

| Campo | Valor |
| --- | --- |
| Tipo | informe de comisión |
| Fecha | 2026-11-02 (fuentes consultadas entre el 2026-11-01 y el 2026-11-02) |
| Autor | Comisión CA-8: diseño de formularios, microtexto (UX writing) y ayuda contextual |
| Mandato | `F300` §7: B-01, B-02, B-03, B-05, B-06, B-09, B-12; contesto además B-04, B-07 (parte CSH), B-10 y B-11 desde la especialidad |
| Ciego | No leí los informes `F31x`–`F37x` de las otras comisiones. Nota de numeración: `F300` §9 asigna `F310`–`F318`; la carta de esta comisión fija `F374`, y así se archiva |

**Convención de citas** como en `F300`: `SDEI/` = el cuerpo en `00171bd`; `K` = conocimiento 1.2; lo privado por
alias (`{servicio-privado}`, `{dir-de-trabajo}`).

## Índice

1. [Resumen](#1-resumen)
2. [Fuentes consultadas](#2-fuentes-consultadas)
3. [Respuestas del eje B](#3-respuestas-del-eje-b)
4. [Puntuación de la hipótesis y alternativas](#4-puntuación-de-la-hipótesis-y-alternativas)
5. [Lo que revisé y está bien](#5-lo-que-revisé-y-está-bien)
6. [Pieza → cambio → motivo → costo → orden](#6-pieza--cambio--motivo--costo--orden)
7. [Riesgos](#7-riesgos)
8. [No verificado, incidencias y barrido](#8-no-verificado-incidencias-y-barrido)

---

## 1. Resumen

Sí: docs as code se integra con los formularios, y la industria ya tiene casi todas las piezas, pero **repartidas
en tres lugares que hoy nadie traza entre sí**: la regla (atributo de validación, esquema), el texto (recurso
localizable, `description` del esquema, `uiSchema`) y la guía de estilo (sistema de diseño). Lo que falta, y es lo
que este cuerpo puede aportar, es **la traza `ID@versión` del texto a la regla y un control que da rojo cuando el
número que promete el texto no es el número que hace cumplir el código**. El cuerpo ya tiene el caso que lo prueba:
la divergencia 60/80 de `RN-LOC-01` en la mini demo (`SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:127-135`).

Recomendación: el microtexto de campo es un **canal de `CL-06`** (no una clase nueva) con **registro propio**: un
«catálogo de microtexto» por clave de campo (`campo × tipo × audiencia × idioma`), con traza a la regla y versión,
del que salen los recursos (`.resx`, i18n JSON, `uiSchema`). Tres controles nuevos: `mt-traza` (bloquea),
`mt-desfase-regla` (bloquea en lo nuevo) y `mt-traduccion-atrasada` (avisa). La accesibilidad (asociación con
`aria-describedby`) se prueba en las pruebas de la interfaz, no en `docs-guard`.

## 2. Fuentes consultadas

Abiertas con WebFetch salvo rótulo; fecha de consulta 2026-11-02.

| Id | Fuente | Qué dice (lo que importa) | URL |
| --- | --- | --- | --- |
| S1 | GOV.UK Design System, *Text input* | Pista «for help that's relevant to the majority of users»; «single short sentence»; «Do not use links in hint text»; «Do not use placeholder text in place of a label, or for hints or examples»; ejemplo con `aria-describedby="event-name-hint"` | https://design-system.service.gov.uk/components/text-input/ |
| S2 | GOV.UK Design System, *Error message* | «explain what went wrong and how to fix it»; «Use the same message next to the field and in the Error summary»; «include language from the question … label»; prefijo oculto «Error:»; `aria-describedby="…-hint …-error"` | https://design-system.service.gov.uk/components/error-message/ |
| S3 | Sherwin, K. (2014-05-11, revisado 2018-09-10), *Placeholders in Form Fields Are Harmful*, NN/g | «clear, visible labels that are placed outside empty form fields» | https://www.nngroup.com/articles/form-design-placeholders/ |
| S4 | Carbon Design System, *Form usage* | Helper text: «pertinent information that assists the user in correctly completing a field», forma preferida; placeholder «should not be used as a replacement for a persistent label»; el error reemplaza al helper bajo el campo; la información de formato va en helper, no en tooltip | https://carbondesignsystem.com/components/form/usage/ |
| S5 | Atlassian Design System, *Form usage* | Helper para lo que ayuda a completar; evitar placeholder (no accesible), salvo búsqueda; validar en línea; no deshabilitar el botón de enviar, decir qué falta | https://atlassian.design/components/form/usage |
| S6 | USWDS, *Form* | Alinear la validación con el campo; aviso de error en `<title>`; soporte parcial de `aria-describedby` en VoiceOver de macOS | https://designsystem.digital.gov/components/form/ |
| S7 | W3C, *Understanding SC 3.3.2* (WCAG 2.2) | Nivel A; «Labels or instructions are provided when content requires user input»; **no exige** la asociación programática: eso es 1.3.1 (y 4.1.2 el nombre accesible) | https://www.w3.org/WAI/WCAG22/Understanding/labels-or-instructions.html |
| S8 | W3C, *Understanding SC 3.3.1* | Nivel A; el ítem con error se identifica y «the error is described to the user in text» | https://www.w3.org/WAI/WCAG22/Understanding/error-identification.html |
| S9 | W3C, *Understanding SC 3.3.3* | Nivel AA; si se conocen sugerencias de corrección, se dan | https://www.w3.org/WAI/WCAG22/Understanding/error-suggestion.html |
| S10 | W3C, WAI-ARIA 1.2, `aria-describedby` | «Identifies the element (or elements) that describes the object.» (cierra el «sin verificar» de `F300` §11) | https://www.w3.org/TR/wai-aria-1.2/#aria-describedby |
| S11 | JSON Schema, *Annotations* | `title` corto, `description` explicación larga; `examples` «isn't used for validation» | https://json-schema.org/understanding-json-schema/reference/annotations |
| S12 | OpenAPI 3.1.0 | Schema Object «superset of JSON Schema Specification Draft 2020-12»; los `description` admiten CommonMark | https://spec.openapis.org/oas/v3.1.0 |
| S13 | react-jsonschema-form, *uiSchema* | `ui:help` debajo del control, después de los errores; `ui:description` reemplaza la descripción; `ui:placeholder` | https://rjsf-team.github.io/react-jsonschema-form/docs/api-reference/uiSchema/ |
| S14 | JSON Forms, *i18n* | Claves `<i18nkey>.label`, `.description`, `.error.<keyword>` (p. ej. `name.error.required`), con caída a `error.<keyword>`; sin clave, la ruta de la propiedad | https://jsonforms.io/docs/i18n |
| S15 | Microsoft Learn, `DisplayAttribute.Description` (.NET 10) | «used to display a description in the UI»; «typically used as a tooltip or description UI element»; leer con `GetDescription` (resuelve el recurso) | https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.displayattribute.description |
| S16 | Microsoft Learn, *Blazor forms validation* (semilla de `F300` §8, no reabierta) | `DataAnnotationsValidator`, `ValidationMessage<TValue>`, `ValidationSummary`, `ErrorMessage` | https://learn.microsoft.com/en-us/aspnet/core/blazor/forms/validation |
| S17 | FluentValidation, *Localization* | Mensajes por defecto traducidos según `CurrentUICulture`; `WithMessage` con lambda contra `.resx` o `IStringLocalizer`; `ILanguageManager` para reemplazar los por defecto | https://docs.fluentvalidation.net/en/latest/localization.html |
| S18 | OASIS DITA 1.3, `<resourceid>` | Identificador de tema para «context-sensitive help systems»; `@appid`/`@appname`, `@ux-context-string`, `@ux-windowref` | https://docs.oasis-open.org/dita/dita/v1.3/os/part1-base/langRef/base/resourceid.html |
| S19 | MadCap Flare 2026, *Context-Sensitive Help* | Archivo de alias y archivo de cabecera («map file»); CSH ID nombre o número; apertura por `MadCap.OpenHelp` o `#cshid=` en la URL. **Consultado por buscador, sin abrir la página** | https://help.madcapsoftware.com/flare2026/Content/Flare/Step2-Authoring/CSH/CSH.htm |
| S20 | Zendesk, *Web Widget (Classic) Help Center API* | `helpCenter:setSuggestions` con búsqueda o `labels` para sugerir artículos según el contexto. **Consultado por buscador, sin abrir la página** | https://developer.zendesk.com/api-reference/widget/help-center-api/ |
| S21 | Pendo, *Take a tour of Pendo* (semilla de `F300` §8, no reabierta) | Guías en producto y segmentos de visitantes y cuentas | https://support.pendo.io/hc/en-us/articles/20826000368411-Take-a-tour-of-Pendo |

## 3. Respuestas del eje B

### B-01 Mecanismos de microtexto y estado del arte

**Estado del arte.** Los sistemas de diseño públicos coinciden (S1, S3, S4, S5): etiqueta visible siempre; texto de
pista o *helper* breve, persistente y debajo de la etiqueta, para lo que sirve a la mayoría; **marcador nunca en lugar
de etiqueta ni con información crítica** (S1, S3, S4, S5: cuatro fuentes independientes); *tooltip* sólo para lo
accesorio, no para el formato (S4); el error reemplaza a la pista bajo el campo (S4), dice qué pasó y cómo
arreglarlo, con las palabras de la etiqueta, idéntico junto al campo y en el resumen (S2); validar en línea y no
deshabilitar el botón de enviar (S5). GOV.UK además prohíbe enlaces en la pista (S1). Material 3 y Fluent 2: **sin
verificar** (no abrieron).

**Tipología que propongo para el cuerpo** (vocabulario cerrado del campo `tipo`): `etiqueta`, `pista`,
`marcador` (desaconsejado; sólo ejemplo de formato que repite la pista), `error.<regla>`, `resumen-error`,
`descripcion-seccion`, `ayuda-ampliada` (desplegable o enlace a la página `CL-06`), `recorrido` (paso de guía).

**Cuerpo SDEI.** `TEM-05:271-277` ya pide en la página de ayuda la tabla «campo, qué escribir» y «el mensaje literal
bajo el campo» (también `:238`). Es la página la que copia el microtexto; **el microtexto mismo no tiene pieza, ni
ancla, ni control**. No hay guía de redacción del microtexto en el cuerpo.

### B-02 Fuente única entre especificación, validación y texto

**Estado del arte.** Tres familias, ninguna une regla y texto con traza:

- **.NET:** la regla en el atributo (`[StringLength(60, MinimumLength = 3)]`, S16) o en FluentValidation (S17); el
  texto en `[Display(Name, Prompt, Description)]` (S15: `Description` «typically used as a tooltip or description»;
  `Prompt` es el marcador) y en `ErrorMessage`/`ErrorMessageResourceName` contra `.resx`.
- **JSON Schema/OpenAPI:** la regla (`minLength`, `maxLength`) y el texto (`title`, `description`) viven **en el
  mismo objeto** (S11, S12); `ui:help`/`ui:placeholder` en un `uiSchema` aparte (S13); JSON Forms resuelve
  etiqueta, descripción y error por clave i18n con caída por palabra clave (S14).
- **Herramientas de guía y ayuda contextual** (S20, S21): el texto vive fuera del repo.

**Derivar no es generar** (`TEM-05:44`). Lo que el esquema **sí** puede generar sin pérdida son los **números**
(límites, obligatoriedad, formato): el texto «Entre {min} y {max} caracteres» con los parámetros sacados de la regla no
puede desfasarse. Lo que **no** se genera es la frase para la persona (el porqué, el dónde encontrar el dato): eso se
deriva y se escribe. Propuesta: **el texto lleva marcadores de parámetro y la herramienta los llena desde la regla**
(`{min}`, `{max}`, `{obligatorio}`), como ya hace `ErrorMessage = "{0} debe tener entre {2} y {1}"` en .NET [criterio
propio; el formato `{0}`/`{1}`/`{2}` de `StringLength` no se reabrió hoy: sin verificar]. Así el número se genera y la
frase se deriva.

Se pierde, si se genera la frase: la voz de la tarea y la regla de S2 («qué pasó y cómo arreglarlo»); se gana, si se
generan los números: el desfase 60/80 de `TEM-05:127-131` no puede volver a ocurrir en el texto (sí en el código).

### B-03 Traza `ID@versión` del texto de campo

`K:288` (D-13) dice hoy «el texto localizado en archivos de recursos no se ancla». Propuesta: **el ancla no va en el
recurso sino en un registro del que el recurso sale**, porque `.resx` sólo tiene `<comment>` libre y los JSON de i18n
no tienen metadatos. Dos formas, por orden de preferencia:

1. **Catálogo de microtexto** (`doc_type: microtexto`, un archivo YAML o tabla Markdown por formulario, en la carpeta de
   ayuda de A-01 §3), con una fila por clave:

   ```yaml
   doc_id: MT-LOC-ALTA          # catálogo del formulario «Alta de localidad»
   doc_type: microtexto
   form: alta-de-localidad
   traces: [RD-01]
   entradas:
     - clave: Localidad.Nombre.pista
       tipo: pista
       audiencia: [persona-usuaria]
       traza: RN-LOC-01@1.1
       parametros: {min: 3, max: 60}      # los copia la herramienta desde la regla; no se escriben a mano
       es: "Entre {min} y {max} caracteres, único por provincia"
     - clave: Localidad.Nombre.error.maxLength
       tipo: error.maxLength
       audiencia: [persona-usuaria]
       traza: RN-LOC-01@1.1
       es: "El nombre tiene que tener {max} caracteres o menos"
   ```

   Del catálogo se **emiten** `Resources/*.resx` (o i18n JSON, o `uiSchema`) en el build, con la traza copiada al
   `<comment>` para quien abra el recurso.

2. **Comentario estructurado en el recurso** (`<comment>traza: RN-LOC-01@1.1; audiencia: persona-usuaria</comment>`),
   para el proyecto que no quiere generar recursos. Más barato, más frágil (lo edita una herramienta de traducción).

En ambos, la clave es el **identificador de contexto** (como el CSH ID de S18/S19): `Formulario.Campo.tipo`.

### B-04 Clase de pieza (entrada de la tabla de §6)

**Canal de `CL-06`, no clase nueva**: mismo lector (`ACT-SDEI-6`, `SDEI/00-Marco.md:156`), mismo origen (la regla),
misma traza. Lo que cambia es la **unidad** (la clave, no la página) y el **ancla** (el registro del §B-03, no el
frontmatter de una página). Vive con el código de la interfaz cuando D-05 dice «mismo pull request que el código»
(caso normal: cambia la regla y cambia el texto). Una clase nueva duplicaría escenarios, roles y controles que `CL-06`
ya tiene.

### B-05 Control de que la ayuda no quedó atrás de la regla

Tres controles, cada uno con su par rojo/verde:

| Control | Qué mira | Condición de rojo | Bloquea | Par rojo/verde |
| --- | --- | --- | --- | --- |
| `mt-traza` (extiende `PR-5`, `SDEI/TEM-06-Compuertas-Y-CI.md:94`) | Cada entrada del catálogo trae `traza: ID@versión` que resuelve y está en la versión vigente | Traza que no resuelve o versión desfasada (mismos mensajes que `TEM-05:149-152`) | Sí | Rojo: `RN-LOC-01@1.0` con la ficha en 1.1. Verde: `@1.1` |
| `mt-desfase-regla` | Los números del texto (tras llenar parámetros) contra los de la regla leída del código o del esquema (`StringLength`, `MaxLength`, `maxLength`, `Required`, `required`) | Un número literal en el texto que no es parámetro y no coincide; campo obligatorio en la regla sin entrada `error.required`; entrada `error.<keyword>` sin regla que la dispare | Sí en lo nuevo; avisa en lo heredado (regla de `K` D-10) | Rojo: la mini demo tal como está (texto 60, `MaxLength` ausente, validación sólo mínimo: `TEM-05:127-131`). Verde: la propuesta de la ficha `RN-LOC-01` aplicada |
| `mt-traduccion-atrasada` (el control de `TEM-05:187-196` que no existe) | Cada traducción declara el hash de la entrada fuente | Fuente cambiada después de la traducción | Avisa (nunca bloquea: la falta de traducción no quita ayuda, `TEM-05:189-190`) | Rojo: cambiar la frase `es` sin tocar `en`. Verde: actualizar `en` con el hash nuevo |

Más dos **avisos de estilo** baratos sobre el catálogo (derivados de S1, S3–S5): `marcador` sin `pista` equivalente,
y enlace en una `pista`. Avisan; no bloquean (son criterio de diseño, no de verdad).

**Límite honesto:** `mt-desfase-regla` lee la regla por análisis estático de atributos o del esquema; una regla escrita
como `if` en un servicio no se ve. Ahí la traza se mantiene, el desfase lo cubre la prueba Dado/Cuando/Entonces de la
ficha («Dado un nombre de 61 caracteres…»).

### B-06 Por audiencia y por idioma

- **Audiencia** es una columna de la entrada (`audiencia: [...]`), con el mismo vocabulario cerrado que las páginas
  de `CL-06`. El mismo campo puede tener dos `pista` (p. ej., administrador raíz: «afecta a todas las aplicaciones»;
  administrador de aplicación: sin esa frase). La resolución ocurre **en el servidor**, con el rol y el alcance de la
  sesión, igual que la ayuda por página (`TEM-05:33-79`: «ocultar … es visibilidad; no entregarla es acceso»).
- **Alcance** (inquilino, aplicación) no cambia el texto: cambia los **parámetros** (p. ej., el límite configurado
  por aplicación). Se llena en tiempo de ejecución, no en el catálogo.
- **Idioma**: columna por idioma; la fuente con aviso si falta, nunca vacío (`TEM-05:189`).
- **Superficie**: el catálogo es uno; el build emite por superficie (web: recursos del servidor; móvil: el paquete
  lleva **sólo** las entradas de audiencias que esa app sirve). Lo que viaja en la app instalada es visible
  (`SDEI/00-Marco.md` §2.5): una entrada restringida nunca se compila en el binario móvil; se pide al servidor.

Control: `mt-cruce-audiencia` — ninguna entrada de una audiencia restringida aparece en un recurso emitido para una
superficie o audiencia pública. Bloquea. Generaliza el cruce de rol de `TEM-05:160-185` al microtexto.

### B-07 Integración con paneles y portales (parte de microtexto y CSH)

El patrón probado desde hace décadas es el **identificador de contexto**: la pantalla o el campo lleva un ID; un
mapa ID → tema resuelve la ayuda (DITA `<resourceid>` con `@ux-context-string`, S18; Flare con alias y cabecera y
`#cshid=`, S19; Zendesk sugiere artículos por `labels` según la página, S20). Propuesta para el cuerpo: **la clave del
catálogo es el CSH ID**, y `ayuda-ampliada` apunta a una página `CL-06` por su `doc_id`. El mapa se versiona con el
catálogo (mismo pull request) y `docs-guard` verifica que cada `ayuda-ampliada` resuelve a una página de la misma
audiencia o más amplia (si no, cruce). Los paneles de cada servicio del paquete consumen el mismo mapa por
servicio; el detalle de portales lo dejo a la comisión de integración.

### B-08 (lateral) Plataformas de guía en producto

Desde mi especialidad: su contenido (recorridos, *tooltips*) es microtexto que vive en el editor del proveedor
(S21), sin pull request ni traza. Mitigación compatible: exportar o versionar su contenido como entradas `tipo:
recorrido` del catálogo y declararlo en A-01 como «ubicación externa sin ancla» (`K` D-05). **Sin verificar** que
Pendo exporte o importe por API; no lo abrí.

### B-09 Accesibilidad

- **Qué exige WCAG 2.2**: 3.3.2 (A) que haya etiqueta o instrucciones (S7); 3.3.1 (A) error identificado y descrito
  en texto (S8); 3.3.3 (AA) sugerencia de corrección si se conoce (S9). **3.3.2 no exige la asociación
  programática**: la exige 1.3.1, y el nombre accesible 4.1.2 (S7). Un control que sólo mire 3.3.2 deja pasar una
  pista que el lector de pantalla no anuncia.
- **Mecanismo**: `aria-describedby` «Identifies the element (or elements) that describes the object» (S10); GOV.UK
  enlaza pista y error en ese orden (S1, S2) y antepone «Error:» oculto (S2). USWDS advierte soporte parcial en
  VoiceOver de macOS (S6): probar con lector real, no sólo el atributo.
- **Dónde se verifica**: en las **pruebas de la interfaz** (componente o extremo a extremo con un motor de reglas de
  accesibilidad), no en `docs-guard`: el catálogo no ve el DOM. Lo que `docs-guard` sí puede: que todo campo con regla
  tenga `etiqueta` y que todo `error.<keyword>` exista (insumo de 3.3.1/3.3.3). Prueba propuesta: cada campo con
  entrada `pista` o `error` tiene un `aria-describedby` que apunta a un nodo cuyo texto es la entrada resuelta para la
  audiencia de la sesión. [Criterio propio; no verifiqué hoy el comportamiento de `ValidationMessage` de Blazor
  respecto de `aria-describedby`: **sin verificar**.]

### B-10 (lateral) Agente que asiste en el formulario

El catálogo filtrado por audiencia es la mejor entrada para un asistente: frases cortas, por clave, con traza. Riesgos
desde el microtexto: una `pista` editable por el usuario o por un inquilino es vector de inyección (`TEM-04:191-192`
ya separa el asistente de la persona usuaria). Regla: el asistente recibe sólo entradas resueltas por el servidor para
la sesión, y sólo de catálogos versionados en el repo, nunca de texto configurable en tiempo de ejecución.

### B-11 (lateral) .NET

Blazor/ASP.NET: `IStringLocalizer` sobre los `.resx` emitidos; `[Display(ResourceType=…)]` y
`ErrorMessageResourceName` (S15, S16) o `WithMessage(_ => localizer[clave])` en FluentValidation (S17). Por audiencia:
un `IStringLocalizer` envoltorio que busca `clave@audiencia` y cae a `clave` [criterio propio]. MAUI: recursos
embebidos sólo con las audiencias públicas de la app; lo restringido por API autenticada.

### B-12 Demo

**Extender la mini demo `MovilidadUrbana-Mini-Demo`**, no armar otra: ya tiene la regla con versión (`RN-LOC-01@1.1`),
el texto bajo el campo, la divergencia real 60/80 y el contrato OpenAPI (`contracts/openapi.json`). Agregar:
`docs/microtexto/alta-de-localidad.yaml` (catálogo, dos audiencias: `persona-usuaria` y un rol administrador
inventado para la demo, con un campo cuya pista difiere), el emisor de `.resx`, y en `verificar.sh` los tres pares
rojo/verde de B-05. El rojo de `mt-desfase-regla` sale **gratis** del código fijado hoy; el verde, aplicando la
propuesta de la ficha en una rama de la demo. Si la demo no puede tocar el código fijado por SHA, el verde se hace
contra el `maxLength` del contrato OpenAPI, que es fuente de la demo.

## 4. Puntuación de la hipótesis y alternativas

Criterios: C1 fidelidad al pedido del PO («guiar o asistir con pequeña información», con la misma fuente); C2
verificabilidad en CI (rojo/verde); C3 costo de adopción; C4 riesgo de desfase o fuga; C5 alineación con estándares e
industria. 1 = peor, 5 = mejor.

| Opción | C1 | C2 | C3 | C4 | C5 | Nota |
| --- | --- | --- | --- | --- | --- | --- |
| H §6.5 de la presidencia: ayuda de campo como canal de `CL-06`, traza en el recurso, control de desfase | 4 | 3 | 4 | 3 | 4 | Acierta en la clase; «traza en el recurso» es frágil (`.resx` sin metadatos, JSON sin comentarios) |
| **A1 (recomendada)**: canal de `CL-06` + catálogo de microtexto con traza y parámetros llenados desde la regla; emite recursos; 3 controles + cruce | 5 | 5 | 3 | 5 | 4 | Más costo inicial (emisor); elimina el desfase numérico por construcción |
| A2: todo desde el esquema (JSON Schema/OpenAPI `description` + `uiSchema`), sin catálogo | 3 | 4 | 4 | 3 | 5 | Muy estándar; pero no hay audiencia en JSON Schema y el texto de usuario queda en el contrato de API (lo lee el integrador) |
| A3: clase nueva `CL-15 Microtexto` | 3 | 4 | 2 | 4 | 3 | Duplica roles y escenarios de `CL-06` |
| A4: no hacer nada; la página `CL-06` copia el microtexto (estado actual) | 2 | 2 | 5 | 1 | 2 | Es exactamente el estado en que nació el 60/80 |

Sobre las otras piezas de §6, desde mi especialidad: §6.1 matriz de audiencias — 4 (necesito su vocabulario cerrado
como valores de `audiencia` del catálogo; sin él, el cruce no se puede verificar); §6.3 control de cruce de alcance —
4, y propongo que la misma regla cubra entradas de microtexto (`mt-cruce-audiencia`); §6.2 y §6.4 fuera de mi
especialidad, sin puntuación.

## 5. Lo que revisé y está bien

- `TEM-05:44` «derivar no es generar»: se sostiene, refinado (números se generan, frases se derivan).
- `TEM-05:127-135`: la página declara la divergencia y no la decide; es el ejemplo exacto de lo que el control debe
  atrapar antes.
- `TEM-05:238` y `:271-277`: pedir el mensaje literal bajo el campo es correcto (S2).
- `TEM-05:189`: fuente con aviso y nunca vacío, consistente con 3.3.2.

## 6. Pieza → cambio → motivo → costo → orden

| Pieza | Cambio | Motivo | Costo | Orden |
| --- | --- | --- | --- | --- |
| `SDEI/00-Marco.md` §2.5 y §4 | Fila «Canales de ayuda»: página, microtexto de campo, CSH | E-09 | Bajo | 3 |
| `TEM-04` | §3.4: el asistente consume sólo microtexto resuelto por el servidor | B-10 | Bajo | 5 |
| `TEM-05` | Sección nueva «Microtexto de campo»: tipología B-01, catálogo B-03, audiencia e idioma B-06, CSH B-07, accesibilidad B-09; convertir el control de traducción atrasada en real | Núcleo del eje B | Medio | 2 |
| `TEM-06` | `mt-traza` (en `PR-5`), `mt-desfase-regla`, `mt-cruce-audiencia`, `mt-traduccion-atrasada`, con su fila en la tabla de bloqueo | B-05, B-06 | Medio (herramienta) | 4 |
| `99-Anexos/Glosario.md` | Microtexto, pista, marcador, mensaje de validación, identificador de contexto (CSH ID), catálogo de microtexto | Vocabulario | Bajo | 1 |
| `99-Anexos/Esquema-Frontmatter-Y-Prefijos.md` | `doc_type: microtexto`; prefijo `MT-` (comando 9 en 0 antes) | B-03 | Bajo | 1 |
| `Examples/` | Extender `MovilidadUrbana-Mini-Demo` (B-12) | Prueba | Medio | 4 |
| `K` D-13 | Opciones suman «microtexto de campo: ninguno · en recursos sin traza · catálogo con traza»; quitar «no se ancla» y reemplazarlo por el registro | B-03 | Bajo | 2 |
| `K` D-01, §2.3 | Sin cambio propio; tomar el vocabulario de audiencias que resuelva el eje A | Dependencia | — | 2 |
| `K` A-01 / A-03 | A-01 §3 lista la ubicación del catálogo; A-03 vocabulario `tipo` y `audiencia` del catálogo | B-04 | Bajo | 3 |
| Libro (`F099` §5.2) | En el capítulo de ayuda, una sección de microtexto con el caso 60/80 como hilo | Pedagogía | Medio | 6 |
| Oráculos y criterio de caso (`F204`) | En los casos con formulario, una fila: «D-13 declara el microtexto y su ubicación»; no exige catálogo | B-03 | Bajo; re-sella si el jurado la acepta | 5 |

## 7. Riesgos

1. **Sobrecosto en proyectos chicos**: un catálogo para tres campos es burocracia. Mitigación: D-13 «en recursos sin
   traza» como opción válida declarada, con el control en aviso.
2. **Falso verde de `mt-desfase-regla`**: reglas fuera de atributos o esquema no se ven (§B-05, límite).
3. **Doble fuente** si el equipo edita el `.resx` emitido a mano. Mitigación: el emisor marca el archivo como generado
   y el control compara el emitido con el catálogo.
4. **Fuga por microtexto**: una pista de administrador raíz que se compila en la app móvil. Mitigación:
   `mt-cruce-audiencia` y emisión por superficie.
5. **Accesibilidad declarada y no probada**: un control de catálogo no prueba el DOM (S7 vs 1.3.1). Mitigación: la
   prueba de interfaz de B-09 en el carril del producto.

## 8. No verificado, incidencias y barrido

- **Sin verificar**: Material 3 *Text fields* (la página no devolvió contenido); Fluent 2 (no consultado); formato de
  marcadores `{0}{1}{2}` de `StringLength.ErrorMessage`; vínculo de `ValidationMessage` de Blazor con
  `aria-describedby`; exportación de contenido de Pendo.
- **Consultadas sólo por buscador** (S19 Flare, S20 Zendesk): resumen del buscador; el refutador debería reabrirlas.
- **No reabiertas hoy** (semillas de `F300`): S16, S21.
- Salesforce *field-level help* (`F300` §11): no lo busqué; queda en la comisión de UX.
- Mensajes de otras sesiones durante la redacción: ninguno.
- Barrido de lo privado: el servicio va como `{servicio-privado}`; sin nombres de máquina ni rutas absolutas del
  sistema de archivos en este folio.
