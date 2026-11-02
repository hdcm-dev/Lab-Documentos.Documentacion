---
doc_id: EXP0003-F376
doc_type: informe
title: Informe de la comisión CA-9 — integración del sistema documentador con paneles de control, portales y servicios, y la ayuda en el punto de uso
status: vigente
origin: agent
confidence: alta en las citas al cuerpo SDEI (00171bd) y a K 1.2, leídas el 2026-11-02; alta en las fuentes de industria marcadas «verificada», abiertas el 2026-11-02; baja en las rotuladas «sin verificar»; media en las propuestas, que son criterio propio de la comisión
owner: comisión CA-9 del ciclo 3 de la mesa de la reedición DocsAsCode (expediente 0003)
last_review: 2026-11-02
audience: [análisis de decisiones, refutador, jurado del ciclo 3, presidencia, PO]
traces: [EXP0003-F300, EXP0003-F099, EXP0003-F199, EXP0003-F204]
---

| Campo | Valor |
| --- | --- |
| Tipo | informe de comisión |
| Fecha | 2026-11-02 (la providencia fija 2026-11-01; el trabajo se retomó tras un corte de energía, y las fuentes se abrieron el día de redacción) |
| Comisión | CA-9 — integración con paneles de control, portales y servicios |
| Mandato | A-08, A-09; B-07, B-08, B-11 (a cargo); el resto, desde la especialidad |
| Trabajo a ciegas | No se leyeron los folios `F310`–`F375`. La propuesta de §6 de `F300` se leyó porque viaja en la carta como hipótesis a puntuar |

**Convención de citas.** Como `F300`: `SDEI/` = cuerpo en `00171bd`; `K` = conocimiento en curso 1.2 (las líneas
se midieron hoy: D-01 en `K:276`, D-13 en `K:288`; `F300` §4 cita 262 y 274, de una versión anterior). Lo privado,
por alias: `{servicio-privado}`.

## 1. Tesis de la comisión

La industria resuelve la llegada de la ayuda al panel con **tres piezas que se repiten** en todos los casos
verificados: (1) un **identificador estable de contexto** que pone la pantalla o el campo (no la URL de la ayuda);
(2) un **resolvedor** que traduce ese identificador más los atributos del usuario (rol, cuenta, plan, idioma) a un
contenido; (3) una **fuente de contenido** que vive fuera del código de la pantalla. Las plataformas comerciales de
guía en producto (Pendo, Appcues, WalkMe, Userpilot, Intercom) ponen (2) y (3) en su propio editor y su propia
nube; docs as code puede poner (3) en el repositorio y (2) en el servidor del producto, y gana traza, PR y versión.
El microtexto de campo (descripción, pista, mensaje de validación) ya tiene en .NET un lugar nativo
(`DisplayAttribute.Description`, `Prompt`, `ErrorMessage` con `ResourceType`), que es donde hay que anclarlo, no en
una página.

## 2. Estado del arte (fuentes)

| # | Fuente | Qué dice, en lo que importa | Estado (2026-11-02) |
| --- | --- | --- | --- |
| S1 | Pendo, *Segment rules* (act. 2026-10-29), https://support.pendo.io/hc/en-us/articles/32271753394203 | Segmentos por metadatos de visitante y de cuenta (campos propios + por defecto); los segmentos se asignan a guías, salvo los «ineligible for guide targeting» | verificada |
| S2 | Pendo, *Take a tour of Pendo* (semilla de `F300` §8) | Guías, *tooltips*, centro de recursos, segmentos de visitantes y cuentas | verificada por la presidencia el 2026-11-01; no reabierta |
| S3 | Appcues, *Targeting by User Property*, https://docs.appcues.com/targeting-by-user-property | Propiedades (rol, plan) «passed to us through the Appcues.identify() call»; valores «case-sensitive» | verificada |
| S4 | WalkMe, segmentación (base de conocimiento y curso SAP Learning *Exploring Segmentation Overview*) | Segmentos por reglas del motor; variables con rol y nivel de acceso; reglas OR dentro del segmento, AND con la condición de despliegue | resultado de búsqueda, página no abierta: **sin verificar** |
| S5 | Userpilot, *Localize Resource Center Content*, https://docs.userpilot.com/article/212-localize-respurce-center-content | Idioma por propiedad `locale_code` (ISO 639-1); traducción por exportación CSV/XLIFF y reimportación | resultado de búsqueda: **sin verificar** en la página |
| S6 | Intercom, audiencias de artículos y Messenger | Audiencia por reglas; artículos internos no visibles a externos; varios centros de ayuda por marca | sólo foros y una página en japonés vista en búsqueda: **sin verificar** |
| S7 | Zendesk, *Web Widget (Messaging) Core API*, https://developer.zendesk.com/api-reference/widget-messaging/web/core/ | `zE("messenger:set", "behavior", …)` con *prompts* previos a la conversación | verificada; la sugerencia de artículos por página (`helpCenter:setSuggestions`, widget clásico) **sin verificar** |
| S8 | Salesforce, *Field-level help* (guía de estilo, developer.salesforce.com, v196) | Texto del administrador por campo, al pasar sobre el ícono | 403 al abrir: **sin verificar** en fuente oficial (coincide con `F300` §11) |
| S9 | Microsoft Learn, *DisplayAttribute.Description* (act. 2026-05-27), https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.displayattribute.description | «typically used as a tooltip or description UI element»; `Prompt` en el mismo atributo; `GetDescription()` para leerlo (resuelve recursos) | verificada |
| S10 | Microsoft Learn, *Display tooltips – .NET MAUI* (act. 2026-07-28), https://learn.microsoft.com/en-us/dotnet/maui/user-interface/tooltips | `ToolTipProperties.Text`; en Android, pulsación larga; en iOS sólo app de iPhone/iPad en Mac con Apple silicon | verificada |
| S11 | Microsoft Learn, *Blazor forms validation* (semilla `F300` §8) | `DataAnnotationsValidator`, `ValidationMessage<T>`, `ErrorMessage` | verificada por la presidencia el 2026-11-01 |
| S12 | Microsoft Learn, *Azure API Management groups* (semilla) | Visibilidad de productos en el portal por grupos | verificada por la presidencia el 2026-11-01 |
| S13 | MadCap Flare, ayuda sensible al contexto (archivo de cabecera y de alias: ID de contexto → tema) | Patrón clásico de CSH | URL probada dio 404: **sin verificar** |
| S14 | Consolas de nube (Azure portal, AWS console, Google Cloud console), Stripe Dashboard, Atlassian | Paneles «Learn more»/ayuda lateral por pantalla | **sin verificar** hoy; no se afirma nada de su mecanismo |

**Lectura.** Todas las plataformas verificadas (S1, S3) segmentan por **atributos que manda el producto** (rol,
cuenta, plan) y son **visibilidad**, no acceso: el contenido está en el script del cliente o en su nube y la
segmentación decide qué se muestra. Esto coincide con la distinción de `SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:103-109`
(«ocultar … es visibilidad; no entregarla es acceso») y descalifica a estas plataformas como canal de la
documentación restringida (A-06, A-07).

## 3. Respuestas a cargo

### A-08 Alcance por inquilino o aplicación

- **Arte.** En Pendo el alcance es un metadato de **cuenta** separado del de visitante (S1); Appcues lo modela como
  propiedad del usuario (S3); APIM, por grupo (S12). Patrón común: alcance = atributo del sujeto distinto del rol.
- **SDEI cubre:** el filtro por `roles` (`SDEI/TEM-05…:160-185`, `:280`). **No cubre:** alcance; el filtro es sólo
  por rol, y el cruce lo detecta el validador de la prueba, no `docs-guard` (`:180-182`).
- **Propuesta.** Campo de frontmatter `scope` con dos formas: `scope: any` (por defecto) o `scope: {tipo: app,
  valor: "{param}"}`. La ayuda **no** enumera inquilinos reales en el repo (serían datos del cliente): declara el
  *tipo* de alcance y el texto usa marcadores que el servidor completa (`{app.nombre}`). Lo que varía por inquilino
  real (p. ej., ayuda escrita por un cliente) no es docs as code y va a contenido del producto, fuera del repo.
- **Control (CI, bloquea).** `scope-cross`: una página con `scope.tipo=app` no puede enlazar a otra con alcance
  distinto salvo `any`; y ninguna página contiene un identificador concreto de inquilino (lista negra/regex del
  formato de ID del producto). Par rojo/verde: página común que enlaza a una de alcance → rojo.
- **Riesgo.** Confundir alcance de **documentación** con alcance de **datos**: la ayuda casi nunca cambia por
  inquilino; lo que cambia son los datos que el texto nombra.

### A-09 Varias superficies del mismo producto

- **Arte.** Las plataformas tienen SDK web y móvil separados con el mismo contenido central (S1, S3, S4 «Mobile
  menu segmentation», sin verificar). En .NET MAUI la ayuda de campo cabe en `ToolTipProperties.Text`, pero en
  Android sólo aparece con pulsación larga y en iPhone no aparece (S10): en móvil la pista **debe** ser texto
  visible, no *tooltip*.
- **SDEI cubre:** `SDEI/00-Marco.md:104-112` advierte que lo que viaja en el paquete de la app es visible para quien
  la instala. **No cubre:** una sola fuente con salidas por superficie.
- **Propuesta.** Una fuente; campo `surfaces: [panel, movil, api, servicio-2]`. Regla de entrega: **la app
  instalada lleva sólo lo de audiencia `publico` o `autenticado-sin-rol`**; lo de rol o alcance se pide al servidor
  con la sesión (mismo filtro que la página, `TEM-05:103-109`). Control `bundle-leak` (CI, bloquea): el build de la
  app falla si el paquete de ayuda empaquetado contiene una página con `roles` restringidos o `access` distinto de
  público.
- **Riesgo.** Ayuda sin conexión: la app pierde la ayuda por rol fuera de línea; se acepta y se declara.

### B-07 Integración con paneles y portales

- **Patrón propuesto, «ID de contexto» (`ctx`).** Cada pantalla y cada campo del panel declaran un ID estable
  (`ctx: panel.apps.crear`, `ctx: panel.apps.crear#nombre`); cada página de ayuda declara `contexts: [...]`. El
  servidor resuelve `ctx + audiencia + idioma + versión del producto → página o fragmento` y devuelve 404 si la
  audiencia no alcanza (como `TEM-05:160-185`). Es el patrón de la ayuda sensible al contexto (S13, sin verificar)
  y el de las plataformas (S1, S3), pero con la tabla en el repo.
- **Versionado del vínculo.** La tabla `ctx → página` se compila junto con la ayuda y se publica con la versión del
  producto (ancla de `SDEI/00-Marco.md:104-112`, «Etiqueta y SHA»). Un `ctx` que desaparece del código sin bajar de
  la ayuda, o viceversa, es rojo.
- **Controles (CI).** `ctx-orphan` (bloquea): todo `ctx` declarado en el código (extraído por patrón o por un
  atributo `[HelpContext("…")]`) tiene al menos una página por cada audiencia que ve esa pantalla; todo `contexts`
  de una página existe en el código del SHA de `source.lock`. Par: borrar el atributo de una pantalla → rojo.
- **Portal de desarrolladores y segundo servicio.** El portal es otra **superficie** de la misma fuente, con su
  propio punto de cumplimiento (grupos de APIM, S12, o el servidor del portal). El panel enlaza al portal con
  enlace profundo `portal/{ctx}`; el portal aplica su propio acceso: el enlace no transfiere permiso.
- **Riesgo.** Mantener IDs estables cuesta disciplina; sin el control, los ID se pudren como las URL.

### B-08 Plataformas de guía en producto

| Criterio | Plataforma (Pendo/Appcues/WalkMe) | Docs as code con resolvedor propio |
| --- | --- | --- |
| Autoría | Editor visual, sin PR | PR, revisión, `docs-guard` |
| Traza `ID@versión` a la regla | No hay campo nativo (sin verificar que exista) | Sí (frontmatter) |
| Segmentación | Rica (S1, S3) | La que el servidor implemente |
| Acceso real | No (visibilidad; contenido en el cliente) | Sí (servidor, 404) |
| Recorridos y analítica | Sí | No, salvo que se construya |
| Idioma | Exportación CSV/XLIFF (S5, sin verificar) | Archivos del repo con `translation_of` (`TEM-05:187-196`) |

- **Propuesta.** No adoptar plataforma para la ayuda **normativa** (la que traza a una regla). Si el PO quiere
  recorridos, se admiten como **canal derivado**: el recorrido sólo enlaza a `ctx` o páginas del repo, nunca
  redacta reglas propias; control `tour-text` (aviso, no bloqueo) que compara exportaciones de la plataforma contra
  el repo si la plataforma permite exportar.
- **Riesgo.** Segundo lugar de verdad; costo de licencia; script de terceros en el panel (superficie de ataque).

### B-11 Implementación en .NET (Blazor + MAUI + servicios)

1. **Microtexto en el modelo.** `[Display(Name, Prompt, Description, ResourceType = typeof(AyudaCampos))]` y
   `ErrorMessageResourceName` en los validadores (S9, S11). El texto vive en `.resx`; la regla, en el atributo: misma
   línea de código, que es la «fuente única» de B-02 sin generar texto.
2. **Traza en el recurso (B-03).** En el `.resx`, el `<comment>` de cada entrada lleva `trace: RN-12@1.3`. Control
   `resx-trace` (bloquea en escenario 3): toda entrada usada por un `Description` o `ErrorMessageResourceName` tiene
   `trace`; si la regla trazada cambió de versión, rojo hasta revisar el texto.
3. **Desfase regla↔texto (B-05).** `rule-text-drift` (bloquea): los números de `[Range]`/`[StringLength]` deben
   aparecer en el texto de ayuda o error que los anuncia (comparación por reflexión en una prueba unitaria). Par:
   subir `StringLength` de 50 a 60 sin tocar el texto → rojo.
4. **Por audiencia en el servidor.** Un `IStringLocalizer` decorado que busca primero `Clave.{audiencia}` y cae a
   `Clave`; la audiencia sale de los *claims*. En Blazor Server/SSR la resolución ocurre en el servidor; en
   WebAssembly y en MAUI, **sólo** recursos de audiencia pública van en el ensamblado (A-09).
5. **Accesibilidad.** El componente de campo pone la descripción en un elemento con id y `aria-describedby`
   (GOV.UK, semilla de `F300` §8); en MAUI, texto visible bajo el campo y `SemanticProperties.Hint` (**sin
   verificar** hoy).
6. **Ayuda por pantalla.** Atributo `[HelpContext]` en la página Razor y en la `ContentPage`; endpoint
   `GET /ayuda/ctx/{id}` con el filtro de rol/alcance de `TEM-05`.

## 4. Respuestas desde la especialidad (no a cargo)

| Pregunta | Respuesta breve de CA-9 |
| --- | --- |
| A-01 | Audiencia = conjunto de lectores definido por atributos (rol, alcance, superficie, acceso, lector) al que se entrega un contenido. Rol es un atributo del producto; persona es artefacto de UX, no de entrega |
| A-02 | Mínimo: rol, alcance, superficie, acceso, lector, idioma. Jerarquía y canal son derivados (jerarquía, del inventario de autorización; canal, de la superficie) |
| A-03 | Se suma como decisión nueva; la fila de `SDEI/00-Marco.md:107` pasa a ser ejemplo por escenario |
| A-04 | «Lector: humano/agente» como dimensión; `TEM-04` sigue como tema por su contenido (formatos, inyección) |
| A-05 | Herencia declarada en la matriz (raíz ⊃ admin-app); el control de cruce usa esa herencia: un enlace hacia arriba es rojo, hacia abajo es verde |
| A-06 | Plataformas de guía = visibilidad (S1, S3): nunca canal de lo restringido. Prueba: petición sin el atributo → 404 |
| A-07 | Portal con grupos (S12) o paquete privado; decisión H, de una persona |
| A-10 | El `llms.txt` del panel se sirve por `ctx` y audiencia, con el mismo endpoint de B-07 |
| A-11 | `scope-cross`, `bundle-leak`, `ctx-orphan`, `resx-trace`, `rule-text-drift` (ver §3) |
| A-12 | Decisión nueva en `K`; D-13 amplía sus valores con «en el punto de uso» |
| A-13 | Capítulo nuevo «Ayuda en el punto de uso: pantallas, campos y portales» en la Parte III |
| A-14 | Sí: filas de audiencia y de `ctx` en los oráculos del escenario 3; re-sellar |
| A-15 | Extender `Prueba-Ayuda-Por-Rol` con dos alcances, un formulario y un `ctx` (B-12) |
| B-01 | Pista visible bajo la etiqueta; sin marcador como etiqueta (semillas GOV.UK y NN/g); en móvil nunca sólo *tooltip* (S10) |
| B-02 | Sí, con `DisplayAttribute` y `ErrorMessageResourceName` (S9, S11); se deriva, no se genera |
| B-03 | `trace` en el `<comment>` del `.resx` (§3, B-11.2) |
| B-04 | Canal de `CL-06` («ayuda en el punto de uso»), no clase nueva: comparte regla, traza y audiencia; su ancla es la entrada del recurso |
| B-05 | `rule-text-drift` (§3) |
| B-06 | Clave con sufijo de audiencia + cultura del `.resx`; `translation_of` también en recursos |
| B-09 | `aria-describedby` en el componente; prueba de interfaz que lo verifica (bUnit o Playwright) |
| B-10 | El asistente consulta el mismo endpoint `ctx` con la sesión del usuario; nunca un índice global |
| B-12 | Formulario «Crear aplicación» con dos audiencias y el par rojo/verde de `rule-text-drift` |

## 5. Puntaje de la hipótesis (`F300` §6) y alternativas

Escala 1–5 (5 = mejor). Alternativa A1 (CA-9): matriz de audiencias **más** tabla `ctx` como artefacto par.
Alternativa A2: delegar segmentación a una plataforma de guía en producto.

| Criterio | Hipótesis §6 | A1 matriz + `ctx` | A2 plataforma |
| --- | --- | --- | --- |
| Cumple el pedido literal (audiencias y punto de uso) | 4 | 5 | 3 |
| Acceso real, no sólo visibilidad | 4 | 5 | 1 |
| Traza `ID@versión` | 4 | 5 | 1 |
| Verificable en CI | 3 (sólo cruce de alcance) | 5 | 1 |
| Costo de adopción | 4 | 3 | 3 |
| Integración con paneles y portales (B-07) | 2 (no la nombra) | 5 | 4 |

Comentario: la hipótesis es correcta en audiencias pero no trae el **vínculo pantalla→ayuda** ni el control de
paquete móvil; el punto 5 (ayuda de campo como canal de `CL-06`) coincide con esta comisión.

## 6. Riesgos

1. Contenido restringido empaquetado en la app (mitiga `bundle-leak`).
2. IDs de contexto inestables (mitiga `ctx-orphan`).
3. Segunda fuente de verdad si se adopta una plataforma comercial (B-08).
4. Datos de inquilinos en el repositorio (A-08, control de formato de ID).
5. Fuentes sin verificar (S4–S8, S13, S14): el refutador debe reabrirlas antes de citar en el libro.

## 7. Lo que revisé y está bien

- La regla de servidor y 404 de `SDEI/TEM-05…:103-109` es la base correcta para todo canal nuevo.
- El aviso de confidencialidad del paquete de `SDEI/00-Marco.md` §2.5 ya anticipa A-09.
- `translation_of` (`TEM-05:187-196`) se extiende sin cambio de forma a los recursos.

## 8. Tabla «pieza → cambio → motivo → costo → orden»

| Pieza | Cambio | Motivo | Costo | Orden |
| --- | --- | --- | --- | --- |
| `SDEI/00-Marco.md` §2.5 y §4 | Fila «Audiencias» como ejemplo; fila nueva «Punto de uso» por escenario | A-03, B-07 | bajo | 2 |
| `TEM-04` | Lector humano/agente como dimensión; `llms.txt` por `ctx` | A-04, A-10 | bajo | 4 |
| `TEM-05` | Sección «Ayuda en pantalla y en campo»: `ctx`, `.resx` con traza, móvil | B-07, B-11 | medio | 3 |
| `TEM-06` | Controles `scope-cross`, `bundle-leak`, `ctx-orphan`, `resx-trace`, `rule-text-drift` con par | A-11, B-05 | alto | 5 |
| `99-Anexos/Glosario.md` | Audiencia, alcance, superficie, ID de contexto, punto de uso | A-01 | bajo | 1 |
| `Examples/` | Extender `Prueba-Ayuda-Por-Rol` (B-12, A-15) | demo | medio | 6 |
| `K` D-01, D-13, §2.3, A-01, A-03 | Decisión nueva de audiencias; D-13 con «punto de uso»; vocabulario `audience`, `scope`, `surfaces`, `contexts` | A-12 | medio | 2 |
| Libro (`F099` §5.2) | Parte III con capítulo nuevo de punto de uso | A-13 | medio | 7 |
| Oráculos y criterio (`F204`) | Filas de audiencia y `ctx` en escenario 3; re-sellar | A-14 | medio | 8 |

## 9. Incidencias

- Corte de energía durante el ciclo; el informe se redactó el 2026-11-02 sin leer los folios de otras comisiones.
- Mensajes de otras sesiones durante la redacción: ninguno.
- Barrido de lo privado: el servicio va como `{servicio-privado}`; 0 nombres de máquina, 0 rutas absolutas.
