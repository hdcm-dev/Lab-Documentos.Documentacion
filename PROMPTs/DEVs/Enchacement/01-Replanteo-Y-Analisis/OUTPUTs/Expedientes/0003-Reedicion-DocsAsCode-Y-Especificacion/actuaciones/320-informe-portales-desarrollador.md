---
doc_id: EXP0003-F320
doc_type: informe
title: Informe de la comisión CA-2 (ciclo 3) — portales de desarrollador y documentación de API restringida; audiencias, exposición del contrato e integración con paneles y portales
status: vigente
origin: agent
confidence: alta en lo medido sobre el cuerpo SDEI en 00171bd y en las fuentes abiertas hoy (2026-11-01) con su URL; media en los puntajes y en las propuestas, que son criterio propio con escala anclada y van rotulados; baja en lo rotulado «sin verificar»
owner: comisión CA-2 (portales de desarrollador y documentación de API) de la mesa de la reedición DocsAsCode, ciclo 3
last_review: 2026-11-01
audience: [presidencia, refutador, análisis de decisiones, jurado del ciclo 3, PO]
traces: [EXP0003-F300, EXP0003-F099, EXP0003-F204, A-07, A-08, A-09, B-07]
---

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-01 |
| Autor | Comisión CA-2, a ciegas: no leyó ningún informe `F31x` ni `F37x` de otra comisión del ciclo 3 |
| Corrige | — |

| Cabecera de comisión | Valor |
| --- | --- |
| Rol | Portales de desarrollador y documentación de API: pública, para socios, interna; acceso por credencial o invitación; OpenAPI filtrado por audiencia; portales comerciales con control de acceso |
| Preguntas a cargo | A-07, A-08, A-09, B-07 (`F300` §7). Contesto además las demás A-nn y B-nn desde esta especialidad, más breve |
| No-competencia | Retórica y teoría de la audiencia (CA-5), microtexto y accesibilidad del formulario (CA-8), modelo formal de control de acceso (CA-3). Donde toco esos temas, lo hago sólo por el lado del portal y del contrato |
| Norma | `Knowledge-Mesa-De-Expertos-A-Pedido` 3.1 (`MEP`) |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | Cabecera; §0 (renglones 1–3 de «Lo que no se omite»); §2.2; §3.2; §5.2 |
| Otros documentos cargados | Ninguno entero. `Cadena-De-Consecuencias` y `Excepcion-A-Un-Conocimiento` no se cargaron: no propongo apartarme de ninguna convención que rige |
| Insumos leídos | `F300` entero; `SDEI/00-Marco.md` §2.4–§7; `SDEI/TEM-05` entero; `SDEI/TEM-04` §2–§3.1; `SDEI/01-Mapa.md` §4; `SDEI/99-Anexos/Glosario.md` (búsquedas); `SDEI/Examples/Prueba-Ayuda-Por-Rol/README.md` (índice); `SDEI/Examples/MovilidadUrbana-Mini-Demo/contracts/openapi.json` (medido); `K` §2.3 y §3.2–§3.3; `F099` §5.2 (tabla del libro); `F204` (índice, §7, §9) |
| Medios propios | `grep`, `sed`, un guion `python3 -I` de lectura sobre el contrato de la mini demo; WebFetch y WebSearch el 2026-11-01 (§6) |

**Convención de citas.** Como en `F300`: `SDEI/` = la carpeta del cuerpo en `LD@00171bd`; `K` = el conocimiento en
curso (1.2, en `{dir-de-trabajo}/conocimiento/`); `F0nn`–`F3nn` = folios de la mesa. Lo que es opinión de esta
comisión lleva **[criterio propio]**. Lo privado va por alias: `{servicio-privado}`, `{dir-de-trabajo}`.

## Índice

1. [Definiciones](#1-definiciones)
2. [Lo que la pregunta da por fijo](#2-lo-que-la-pregunta-da-por-fijo)
3. [Hallazgos](#3-hallazgos)
4. [Estado del arte en portales de desarrollador](#4-estado-del-arte-en-portales-de-desarrollador)
5. [Dictamen por pregunta](#5-dictamen-por-pregunta)
6. [Puntajes: hipótesis de la presidencia y alternativas](#6-puntajes-hipótesis-de-la-presidencia-y-alternativas)
7. [Qué rehacer: pieza → cambio → motivo → costo → orden](#7-qué-rehacer)
8. [Riesgos](#8-riesgos)
9. [Fuentes externas](#9-fuentes-externas)
10. [Lo que revisé y está bien](#10-lo-que-revisé-y-está-bien)
11. [Solicitudes de convocatoria y excepciones](#11-solicitudes-de-convocatoria-y-excepciones)
12. [Lo no verificado e incidencias](#12-lo-no-verificado-e-incidencias)
13. [Barrido de lo privado de este folio](#13-barrido-de-lo-privado-de-este-folio)

---

## 1. Definiciones

Las propone esta comisión **[criterio propio]**, separadas a propósito porque la industria las separa (§4).

| Término | Definición propuesta | Por qué separarlo |
| --- | --- | --- |
| Audiencia | Para quién **se escribe** una pieza: un conjunto de lectores con la misma tarea y el mismo lenguaje (raíz del panel, administrador de una aplicación, usuario móvil, integrador, operador) | Es una decisión editorial. Zalando la usa así en su API: `x-audience` es «relevant for quality of design and documentation, reviews» (§9, [Z-219]) |
| Exposición | Quién **puede recibir** la pieza: `publico` · `autenticado` (cualquier cuenta del producto) · `restringido` (por invitación, grupo o credencial) · `interno` (el equipo; no sale del build) | Es una decisión de seguridad. Dos audiencias distintas pueden tener la misma exposición, y una misma audiencia puede leer piezas de exposiciones distintas |
| Punto de cumplimiento | Dónde se hace cumplir la exposición: **build** (no se compila), **servidor del producto** (no se entrega), **portal** (grupo del portal), **repositorio privado** | `SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:48`: «Ocultar … es visibilidad; no entregarla es acceso». El punto de cumplimiento es lo que convierte visibilidad en acceso |
| Alcance | El subconjunto de datos del producto que la persona administra (una aplicación, un inquilino) | Distinto del rol: dos administradores del mismo rol con alcances distintos (`F300` E-04) |
| Superficie | Dónde se lee: panel web, app móvil, portal de desarrollador, paquete/SDK, `llms.txt` | Decide por qué canal viaja y, por lo tanto, qué punto de cumplimiento es posible (en el paquete de la app no hay servidor que filtre) |
| Contrato por exposición | Un documento OpenAPI emitido por el build para cada nivel de exposición, cada uno subconjunto del siguiente | Es el mecanismo que usan la plataforma .NET y las herramientas de portal (§4.2) |

## 2. Lo que la pregunta da por fijo

1. **Que «audiencia» y «acceso» son la misma tabla.** `F300` §6.1 pone el nivel de acceso como columna de la fila de
   audiencia. La industria de portales los modela por separado: Zalando clasifica la API por audiencia de diseño
   y los portales (Azure API Management, Mintlify, Redocly) controlan el acceso por grupo. Si van en la misma
   fila, una página común a dos audiencias con exposiciones distintas no tiene dónde ir (hallazgo H-02).
2. **Que la exposición de la API se decide una vez.** La hipótesis (§6.4) la hace decisión H, sin decir cuándo.
   El riesgo real aparece **en cada pull request que ensancha** una operación: de interna a socios, de socios a
   pública (H-04).
3. **Que el alcance se declara en la documentación.** En el portal la documentación hereda el permiso del objeto
   que documenta (Backstage, Azure API Management por producto). Declararlo dos veces abre una deriva (H-05).

## 3. Hallazgos

Tope de la carta no fijado; reporto ocho. Lectura P0–P3 para este caso **[criterio propio]**: P0 = una pieza
restringida se entrega a quien no corresponde; P1 = no hay control que lo detecte en CI; P2 = el cuerpo o `K` no
dice cómo decidirlo; P3 = redacción.

| Id | Nivel | Ancla | Hallazgo | Impacto si no se corrige | Dirección |
| --- | --- | --- | --- | --- | --- |
| H-01 | P1 | E1: `python3 -I` sobre `SDEI/Examples/MovilidadUrbana-Mini-Demo/contracts/openapi.json` → 8 operaciones, todas con `tags`, extensiones `x-`: ninguna | El contrato del ejemplo no tiene marca de exposición por operación; `PR-6` (`SDEI/TEM-06-Compuertas-Y-CI.md:95`) compara un solo contrato | Cuando la API tenga operaciones internas o para socios, no hay de dónde filtrar ni qué comparar | Marca de exposición por operación y un contrato por exposición (A-07) |
| H-02 | P2 | E1: `SDEI/00-Marco.md:108`; `K` §2.3 (l. 168) | «Audiencias» es una lista por escenario y mezcla audiencia editorial («integrador») con lector («agente»); no existe la dimensión exposición | No se puede decir qué es público, qué es para socios y qué es interno, que es lo que pide el PO (`F300` E-05) | Dos campos: `audience` (editorial) y `exposicion` (seguridad), §1 |
| H-03 | P1 | E1: `grep -n -i "cruce\|audience\|roles" tools/docs-guard/dg.py` → sólo l. 338 y 342 (elección de esquema) | `docs-guard` no tiene control de cruce de rol, de audiencia ni de exposición; lo confirma `SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:180-182` | Una página `publico` puede enlazar a una `restringido`, y un índice público puede listar títulos restringidos, sin rojo | Controles CA2-C1 a CA2-C4 (A-11) |
| H-04 | P0 potencial | E1: `SDEI/01-Mapa.md:85` (CL-05, clase D) | El contrato REST es clase D («emitido en el build»). Ensanchar la exposición de una operación queda como cambio D, sin persona | Una operación interna pasa al contrato público en un pull request que un agente fusiona solo | Ensanchar la exposición es acto H por cambio; la compuerta da rojo hasta que exista la decisión |
| H-05 | P2 | E1: `SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:103-109` | El cuerpo resuelve rol en el servidor, pero no dice cómo se resuelve el alcance (aplicación o inquilino) ni si la página se declara por alcance | Dos fuentes de verdad del alcance (la autorización del producto y el frontmatter), con deriva | El alcance se hereda de la autorización del recurso; la documentación no lo duplica (A-08) |
| H-06 | P1 | E1: `SDEI/00-Marco.md:112` («Lo que viaja en el paquete de la app instalada es visible para quien la instala») | El cuerpo enuncia la regla de confidencialidad del paquete, pero no hay control que impida que una página de administrador entre al paquete móvil | Una ayuda de administrador viaja en la app que instala cualquiera | Control de manifiesto por superficie, CA2-C3 (A-09) |
| H-07 | P2 | E1: `SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:90` (ESC-SDEI-4: «Qué decide el rol: Nada») | En el escenario del servicio con paquetes el cuerpo dice que el rol no decide nada; el PO pide lo contrario para su API (`F300` E-05) | El escenario que más se parece a `{servicio-privado}` no admite documentación restringida para desarrolladores | Fila nueva: en ESC-SDEI-4 decide la exposición (pública, socios, interna) |
| H-08 | P2 | E1: `SDEI/TEM-04-Doble-Audiencia.md:106-110` | El único caso de portal del cuerpo (un proveedor público de notificaciones) es público entero; no hay caso de portal con partes restringidas | El libro (cap. 18) no tiene un caso comercial de documentación de API restringida | Sumar los casos de §4 con fecha |

## 4. Estado del arte en portales de desarrollador

Todas las fuentes, abiertas el 2026-11-01 (§9). Las citas van en inglés, literales.

### 4.1 Portales: quién ve qué y dónde se hace cumplir

| Producto | Unidad de control | Dónde vive la regla | Qué recibe quien no tiene acceso | Canales derivados | Fuente |
| --- | --- | --- | --- | --- | --- |
| Azure API Management, portal de desarrolladores | Grupos (fijos: Administrators, Developers, Guests; propios, p. ej., uno por socio; o grupos de Microsoft Entra) asociados a **productos** de API; páginas y secciones con «Access» por grupo | Base del servicio; contenido como JSON editado en el editor visual, con revisiones | «An attempt by a user to access a page they aren't authorized to access results in a 404 Not Found error»; además oculta botones y menús | — | [AZ-GRP], [AZ-POR] |
| Mintlify | `groups` en el frontmatter de la página; `public: true` por página o grupo | El repositorio (docs as code) | 404 para el que no está en el grupo; advierte: «Visibility rules only hide content in the browser, so use page-level `groups` for sensitive content» | `llms.txt` «Publicly accessible, reflecting public pages only» | [MINT] |
| Redocly (Realm/Reunite) | `rbac` por equipo en `redocly.yaml` (rutas, globs, `**`) o en el frontmatter de la página | El repositorio | Sin sesión: va al login; con sesión y sin equipo: **403** (revela que existe); la página no genera enlace en la barra | — | [RED-RBAC], [RED-PAGE] |
| ReadMe (Enterprise) | Proyecto público o privado; acceso de lectores por login propio, SAML u OAuth (puente que pasa los datos como JWT) | El tablero del producto | — (la página no lo dice) | — | [README] |
| Backstage (TechDocs) | **Ninguna propia**: «Its visibility is controlled indirectly through the Catalog permissions on the entities the docs belong to» | La política de permisos del catálogo | Según la política | — | [BS-PERM], [BS-RBAC] |
| Apigee, portal integrado | «Audiences» (vista previa) | — | **sin verificar**: la página abrió pero el cuerpo no se pudo leer | — | [APIGEE] |

**Lo que converge [criterio propio sobre los hechos de la tabla]:** (1) un vocabulario cerrado de grupos declarado
en configuración o en frontmatter; (2) el cumplimiento en el punto que sirve, nunca en la vista; (3) **404 y no
403** en los dos portales que lo dicen con cuidado (Azure, Mintlify), igual que `SDEI/TEM-05:106-107`; Redocly
devuelve 403, que revela la existencia; (4) el canal para agentes **hereda el filtro** (Mintlify lo dice de
`llms.txt`), igual que la prueba de concepto del cuerpo; (5) el modelo más simple de alcance es heredar el
permiso del objeto documentado (Backstage).

### 4.2 El contrato: cómo se filtra OpenAPI por audiencia

| Mecanismo | Qué hace | Fuente |
| --- | --- | --- |
| OpenAPI 3.1.1, *Security Filtering* | La norma admite que objetos como `Paths` estén «present but empty» o se quiten, para «allow an additional layer of access control over the documentation» | [OAS-311] |
| OpenAPI, extensiones `x-` | Campos con prefijo `x-`; «Support for any one extension is optional» | [OAS-311] |
| Zalando, regla 219 (MUST) | `x-audience` en `info`, con valores `component-internal` ⊂ `business-unit-internal` ⊂ `company-internal` ⊂ `external-partner` ⊂ `external-public`; «Exactly one audience per API specification»; si una API sirve a varias, se parte la especificación | [Z-219] |
| OpenAPI Overlay 1.0.0 (2024-10-17) | Documento aparte con acciones `target` (JSONPath) + `update`/`remove`; entre sus usos, quitar elementos antes de compartir la descripción afuera | [OVL] |
| Redocly CLI, decoradores | `filter-out` (quita nodos con `property` = `value`, p. ej., `tags`), `filter-in`, `remove-x-internal` (quita lo marcado con `x-internal`, nombre configurable con `internalFlagProperty`) | [RED-FO], [RED-RXI] |
| ASP.NET Core (`Microsoft.AspNetCore.OpenApi`, .NET 9+) | Varios documentos por app: `AddOpenApi("internal")`, `AddOpenApi("public")`, y cada endpoint a uno con `.WithGroupName(...)`; transformadores de documento, operación y esquema por documento | [MS-CUST] |
| ASP.NET Core, recomendación de seguridad | «As a security best practice on limiting information disclosure, OpenAPI user interfaces (Swagger UI, ReDoc, Scalar) should only be enabled in development environments» | [MS-USE] |
| ASP.NET Core, metadatos | `[Description]` → `description`; `[Required]`, `[Range]`, `[MaxLength]`, `[RegularExpression]` → `required`, `minimum`/`maximum`, `maxLength`, `pattern` | [MS-META] |
| Fern | `x-fern-audiences` para filtrar endpoints, esquemas y propiedades por audiencia | **sin verificar**: la página oficial dio 404 hoy; sólo resultado de búsqueda |

### 4.3 Casos comerciales de documentación para socios o por invitación

| Caso | Qué se verificó | Fuente |
| --- | --- | --- |
| Stripe, fases de lanzamiento | *Private preview*: «Restricted to a subset of accounts. Access is by invitation only»; documentación «Directly from the Stripe product team and from the Stripe docs». No dice que las páginas se oculten a quien no fue invitado | [STRIPE] |
| Azure API Management | Ejemplo oficial de «one custom group for developers affiliated with a specific partner organization» con acceso sólo a un producto | [AZ-GRP] |
| Shopify, *developer previews* | Se activan en una tienda de desarrollo desde el Partner Dashboard; **no** se encontró documentación restringida | resultado de búsqueda; **sin verificar** en la página |
| Twilio, *private beta* | Acceso por formulario o representante; **no** se encontró documentación oculta | resultado de búsqueda; **sin verificar** |

**Lectura [criterio propio]:** los grandes proveedores públicos (Stripe, Shopify, Twilio) restringen **la
funcionalidad** y, en lo verificado, publican la documentación o la entregan aparte; quienes restringen **la
documentación** misma son los portales con grupos (Azure, Mintlify, Redocly, ReadMe privado). Para
`{servicio-privado}` el pedido del PO («no quiera hacer pública por razones de seguridad») es del segundo tipo.

### 4.4 Integración con paneles y portales: ayuda contextual

| Patrón | Cómo se vincula pantalla → tema | Dónde vive el vínculo | Fuente |
| --- | --- | --- | --- |
| Identificadores de contexto (MadCap Flare) | Un *header file* («map file») con IDs y un *alias file* que asigna cada ID a un tema; el desarrollo llama `MadCap.OpenHelp(ID, …)` o `Default.htm#cshid=[ID]` | Archivo de texto compartido entre desarrollo y documentación | [FLARE] (resultado de búsqueda sobre páginas oficiales de 2024–2026; **la página exacta dio 404**) |
| Widget con sugerencias por URL o etiqueta (Zendesk Web Widget Classic) | «Contextual Help to recommend articles to users based on the web page they're on»; por código, `setHelpCenterSuggestions` con `search` o `labels` | En la configuración del widget y en el código de la página; el contenido, en el centro de ayuda del proveedor | [ZD] |
| Portal de desarrolladores embebido en la plataforma de API | El portal toma APIs y productos de la instancia; las páginas propias son JSON con revisiones; visibilidad por grupo | Base del servicio, editor visual | [AZ-POR] |
| Guías en producto (Pendo) | Segmentos de visitantes y cuentas dirigen guías | El editor del proveedor | `F300` §8 (semilla de la presidencia; no reabierta por CA-2) |

## 5. Dictamen por pregunta

### A-07 — Documentación de API restringida (a cargo)

**Estado del arte.** §4.1–§4.3. La norma OpenAPI admite expresamente filtrar la documentación por autorización
([OAS-311]); la plataforma .NET emite varios documentos por app ([MS-CUST]) y desaconseja la interfaz interactiva
fuera de desarrollo ([MS-USE]); las herramientas filtran por marca ([RED-FO], [RED-RXI], [OVL]).

**Qué cubre el cuerpo.** El contrato como `CL-05` emitido en el build y su diff `PR-6`
(`SDEI/01-Mapa.md:85`; `SDEI/TEM-06-Compuertas-Y-CI.md:95`); confidencialidad «en el build y en los secretos» para
ESC-SDEI-4 (`SDEI/00-Marco.md:112`). **No cubre**: exposición por operación, contrato por exposición, portal
restringido, quién decide ensanchar (H-01, H-04, H-07).

**Propuesta [criterio propio].**

1. **Marca por operación** en el código, que el build vuelca como extensión `x-exposicion` con valores
   `interno` · `restringido:<grupo>` · `autenticado` · `publico` (orden de inclusión como Zalando: lo más
   chico está incluido en lo más ancho). El proyecto puede adoptar los valores de Zalando tal cual si ya los usa.
   Se marcan también **esquemas y propiedades** que sólo existen para un nivel (un campo interno en una respuesta
   pública es una fuga aunque la operación sea pública).
2. **Un contrato por exposición**, emitido en el build: `contracts/openapi.publico.json`,
   `contracts/openapi.restringido.<grupo>.json`, `contracts/openapi.interno.json`. `PR-6` corre sobre cada uno.
   Lo interno **no se publica** (punto de cumplimiento: build); lo restringido se sirve **sólo** desde un portal o
   ruta con autorización por grupo (punto: portal o servidor); lo público, donde sea.
3. **Interfaz interactiva** (Swagger UI, Scalar): sólo en desarrollo, como dice Microsoft; para socios, el portal
   sirve el contrato restringido ya filtrado, no la interfaz viva de la API de producción. Poner la interfaz
   detrás de `RequireAuthorization()` es práctica difundida, pero sólo la sostienen fuentes de terceros
   (**sin verificar** en la documentación de Scalar o Microsoft).
4. **Clase de decisión.** Que la API tenga documentación restringida y para qué grupos: **H** (la persona
   responsable del producto), una vez, en `K`. **Cada ensanchamiento** de una operación, esquema o propiedad
   (interno → restringido → autenticado → público): **H por cambio**. Angostar (público → restringido) es P, pero
   rompe a quien integra: va con aviso en el `CHANGELOG` (`CL-13`).

**Controles en CI [criterio propio].**

| Id | Control | Condición de bloqueo | Par rojo/verde |
| --- | --- | --- | --- |
| CA2-C1 `exposicion-completa` | Toda operación del contrato interno tiene `x-exposicion` de un vocabulario cerrado (A-03) | Rojo si falta o el valor no está en el vocabulario | Rojo: quitar la marca de una operación; verde: reponerla |
| CA2-C2 `exposicion-monotona` | `publico ⊆ autenticado ⊆ restringido:* ⊆ interno`, por operación y por cierre de `$ref` (ningún esquema alcanzable desde una operación pública lleva una propiedad marcada más angosta) | Rojo si un contrato más ancho contiene algo más angosto | Rojo: agregar `x-exposicion: interno` a una propiedad de un esquema que devuelve una operación pública; verde: separar el esquema |
| CA2-C2b `exposicion-ensancha` | Diff de `x-exposicion` entre la base y el pull request | Rojo si alguna marca se ensancha y no hay fila de decisión H con `decidido_por` (una persona) en el registro de exposición del proyecto; agregar esa fila es H, como las excepciones de `K` §2.2 regla 5 | Rojo: cambiar una operación de `interno` a `publico` sin fila; verde: con la fila asentada por una persona |

**Ejemplo** — `[Fragmento ilustrativo: muestra la forma; los nombres son de ejemplo y no salen de un repositorio]`:

```csharp
// Un documento por exposición (AddOpenApi con nombre y WithGroupName: Microsoft Learn, [MS-CUST]).
builder.Services.AddOpenApi("publico");
builder.Services.AddOpenApi("restringido-integradores");
builder.Services.AddOpenApi("interno");

app.MapPost("/v1/mensajes", Enviar)
   .WithGroupName("publico")
   .AddOpenApiOperationTransformer((op, ctx, ct) =>
   { op.Extensions ??= new Dictionary<string, IOpenApiExtension>();
     op.Extensions["x-exposicion"] = new JsonNodeExtension("publico"); return Task.CompletedTask; });
// Lo que es de varios niveles se arma con un transformador de documento que quita, del documento
// más ancho, las operaciones cuya marca es más angosta (la inclusión monótona la verifica CA2-C2).
```

```yaml
# [Fragmento ilustrativo] Alternativa sin .NET: un bundle por exposición con Redocly ([RED-FO]).
apis:
  publico:
    root: contracts/openapi.interno.json
    decorators:
      filter-out: { property: x-exposicion, value: [interno, restringido-integradores, autenticado] }
```

### A-08 — Alcance por inquilino o aplicación (a cargo)

**Estado del arte.** Azure API Management ata la visibilidad a **productos** y grupos, con un grupo por socio
([AZ-GRP]); Backstage no le da permiso propio a la documentación: la hereda de la entidad del catálogo que
documenta ([BS-RBAC]). Ninguna fuente verificada declara el alcance en el frontmatter de una página.

**Qué cubre el cuerpo.** Rol decidido en el servidor (`SDEI/TEM-05:103-109`); nada de alcance (H-05).

**Propuesta [criterio propio].** Separar dos clases de contenido:

| Clase | Qué es | Cómo se resuelve el alcance | Control |
| --- | --- | --- | --- |
| Genérica por rol | La ayuda de «configurar los canales de una aplicación»: igual para toda aplicación | No se declara alcance: el rol alcanza | CA2-C4: una página `alcance: generico` no contiene literales de inquilino (identificadores, claves, dominios del cliente), por barrido con patrones como el de lo privado (`K` D-14) |
| Instanciada por alcance | La ayuda que muestra **datos** del alcance: el identificador de la aplicación, su clave de prueba, sus *endpoints* | Plantilla en el repositorio con marcadores; el servidor la rellena **con la misma autorización que el dato** (herencia del recurso, como Backstage) | Prueba del producto: el administrador de la aplicación A pide la instancia de B → 404 |

El «cruce de alcance» de la hipótesis queda, entonces, como **prueba del producto** (no hay alcance en el
repositorio que `docs-guard` pueda cruzar), más CA2-C4 en CI. Campo de frontmatter: `alcance: generico | instancia`
(default `generico`).

### A-09 — Varias superficies del mismo producto (a cargo)

**Estado del arte.** Los portales separan por grupo y producto, no por superficie; el canal para agentes hereda el
filtro (Mintlify, [MINT]); DITA tiene `@deliveryTarget` y `@platform` (`F300` §8, semilla no reabierta por CA-2).

**Qué cubre el cuerpo.** La regla de confidencialidad del paquete (`SDEI/00-Marco.md:112`) y la ayuda que «viaja
con el binario» (`SDEI/TEM-05:98`). No hay control (H-06).

**Propuesta [criterio propio].** **Una sola fuente** con salidas por superficie, porque la traza `ID@versión` y el
diff son uno solo. Campo `superficie: [panel, movil, portal, paquete]`. Regla: **lo que entra al paquete de una app
distribuida tiene exposición `publico`** (quien instala puede leerlo); la ayuda restringida de la app móvil se pide
al servidor después de autenticar. Control:

| Id | Control | Condición de bloqueo | Par rojo/verde |
| --- | --- | --- | --- |
| CA2-C3 `paquete-superficie` | El build emite un manifiesto (`doc_id@versión` de cada pieza empaquetada por superficie); la compuerta lo cruza con el frontmatter | Rojo si una pieza del manifiesto de `movil` o `paquete` tiene exposición distinta de `publico`, o si su `superficie` no la incluye | Rojo: agregar al paquete móvil una página del administrador raíz; verde: servirla desde el servidor |

El segundo servicio del paquete del PO entra como **otra superficie** del mismo producto, con sus audiencias, no
como otro escenario: coincide con la composición por unión de `SDEI/00-Marco.md:62-63`.

### A-01 a A-06 y A-10 a A-15 — desde esta especialidad (no a cargo)

| Pregunta | Respuesta de CA-2 [criterio propio salvo cita] |
| --- | --- |
| A-01 Definición | Sostengo separar **audiencia** (editorial) de **exposición** (seguridad), §1; la industria de API lo hace ([Z-219] vs. [AZ-GRP]). El término de comunicación técnica lo da CA-1/CA-5 |
| A-02 Dimensiones | Obligatorias: audiencia, exposición, superficie. Derivadas: punto de cumplimiento (sale de exposición × superficie), lector humano/agente (canal). Opcional: alcance (sólo si hay contenido instanciado). Jerarquía: no es dimensión aparte, es el orden de inclusión de los valores (como Zalando) |
| A-03 Relación con rol y escenario | La fila «Audiencias» de `SDEI/00-Marco.md:108` queda como **default** por escenario; la decisión nueva la concreta por proyecto. En ESC-SDEI-4 se corrige «Qué decide el rol: Nada» (`SDEI/TEM-05:90`) por «qué decide la exposición» |
| A-04 Doble audiencia | El agente es **canal y lector**, no audiencia: `llms.txt` y `.md` heredan la exposición de la página, como en Mintlify. El cap. 7 pasa a ser una sección del capítulo de audiencias |
| A-05 Jerarquía | Orden de inclusión de valores de `audience`/`roles` (raíz ⊃ admin de aplicación ⊃ usuario); el cruce se controla igual que el de exposición: un enlace desde una pieza de exposición ancha a una angosta da rojo |
| A-06 Acceso vs. visibilidad | 404, no 403 (Azure y Mintlify; `SDEI/TEM-05:106`). Redocly da 403: no sirve de modelo en eso. La prueba: pedir la pieza, su `.md` y el índice con una sesión sin acceso |
| A-10 Agente por audiencia | `llms.txt` por exposición, con el mismo filtro que la página ([MINT]); el agente del usuario actúa con la sesión del usuario |
| A-11 Controles | CA2-C1, C2, C2b, C3, C4 y B-07-C1; más `cruce-exposicion`: ningún enlace de una pieza más ancha a una más angosta; ningún índice (`llms.txt`, barra, búsqueda) de exposición X lista una pieza más angosta. Quedan en el producto: el 404 en tiempo de ejecución y el cruce de alcance |
| A-12 Ficha y oráculos | Decisión nueva en `K` (D-18 «Audiencias y exposición»), con dos artefactos: el vocabulario en A-03 (audiencias, exposiciones, grupos, superficies) y un registro de exposición (filas H). D-13 suma «ayuda de campo» y la superficie |
| A-13 Libro | Parte III: «Audiencias, exposición y canales»; cap. 7 se integra; capítulo nuevo «Documentación de API por exposición y portales»; el cap. 18 suma los casos de §4 |
| A-14 Ensayos | Sí, re-sellar: cualquier oráculo de un caso con API o con roles necesita la fila D-18. El criterio de caso no cambia de forma; suma una decisión firme |
| A-15 Demo | Extender `Prueba-Ayuda-Por-Rol` con un contrato de tres operaciones (pública, restringida, interna) y dos alcances; mostrar los tres contratos emitidos y CA2-C2 en rojo/verde. No arma otro ejemplo: el caso que funciona ya tiene el filtro de rol |

### B-07 — Integración con paneles y portales de servicios (a cargo)

**Estado del arte.** §4.4: tres patrones (identificador de contexto; widget con sugerencias por URL o etiqueta;
portal propio de la plataforma de API) más las guías en producto.

**Qué cubre el cuerpo.** La ayuda servida por la app con un catálogo filtrado (`SDEI/TEM-05:98`, `:162-177`).
No hay vínculo pantalla → tema versionado.

**Propuesta [criterio propio].**

1. **Mapa de contexto versionado** en el repositorio (`docs/_contexto.yaml`): `contexto` (identificador estable
   de pantalla o campo, el mismo que pone el código, p. ej., en un atributo `data-ayuda`) → `doc_id`, con la
   exposición y las audiencias heredadas de la pieza. Es el *header/alias file* de Flare, pero dentro del
   repositorio y con traza.
2. **El portal es un renderizador**, no la fuente: los portales que viven en git (Mintlify, Redocly) leen
   frontmatter y configuración del repositorio, y encajan directo; los que tienen editor propio (Azure, Zendesk,
   Pendo) dejan contenido fuera de la traza: si se usan, se declaran como copia publicada y un carril programado
   compara lo publicado (por su API) con el repositorio.
3. **Portal de desarrolladores del paquete**: consume los contratos por exposición de A-07 y las páginas con
   `superficie: portal`; el grupo del portal = el valor `restringido:<grupo>`.

| Id | Control | Condición de bloqueo | Par rojo/verde |
| --- | --- | --- | --- |
| B-07-C1 `mapa-contexto` | Cada `doc_id` del mapa resuelve; cada identificador de contexto que el código declara (extraído del árbol fijado por `source.lock` o del mismo repo) tiene fila o «sin ayuda» explícito; las audiencias de la pieza cubren los roles de la pantalla | Rojo si una fila no resuelve o si la pieza es más angosta que la pantalla; aviso si una pantalla no tiene fila | Rojo: borrar la página a la que apunta un contexto; verde: reponerla |

### B-01 a B-06 y B-08 a B-12 — desde esta especialidad (no a cargo)

| Pregunta | Respuesta de CA-2 [criterio propio salvo cita] |
| --- | --- |
| B-01 Microtexto | De CA-8. Por el lado del contrato: la `description` de la propiedad en OpenAPI es el texto que lee quien integra, no la pista del formulario |
| B-02 Fuente única | En ASP.NET Core, `[Description]` y los atributos de validación se vuelcan al esquema OpenAPI ([MS-META]): el contrato ya es una fuente única de **límites**; el texto de la pista se **deriva** de ahí, no se genera (`SDEI/TEM-05:44`). Ojo: en Minimal APIs los atributos sólo ponen metadatos, no validan ([MS-META]) |
| B-03 Traza del texto de campo | Clave del recurso = identificador de contexto; el mapa de contexto lleva el `ID@versión` de la regla |
| B-04 Clase de pieza | Canal de `CL-06` (coincido con la hipótesis §6.5), con el mapa de contexto como su ancla |
| B-05 Control de desfase | Comparar los límites del esquema emitido (`maxLength`, `required`) con los números del texto de ayuda: es el 60/80 de `SDEI/00-Marco.md:183` hecho control |
| B-06 Por audiencia | El texto del campo hereda la exposición y la audiencia de la pieza; si cambia por rol, son dos claves |
| B-08 Plataformas de guía | Ganan segmentación y medición; pierden traza, revisión por PR y versión (§4.4). Admisibles sólo como copia publicada con reconciliación |
| B-09 Accesibilidad | De CA-8 |
| B-10 Agente en el formulario | Usa el mismo índice por exposición que `llms.txt`; nunca el contrato interno |
| B-11 .NET | `AddOpenApi` por exposición; ayuda restringida servida por un endpoint con política; en MAUI, sólo lo `publico` empaquetado (CA2-C3) |
| B-12 Demo | Un formulario de la demo cuyo `maxLength` sale del atributo, se ve en el contrato y en la pista; B-05 en rojo cuando cambia el atributo |

## 6. Puntajes: hipótesis de la presidencia y alternativas

Criterios y pesos de `K` §3.3 (K1 simplicidad, K2 practicidad, K3 escalabilidad, K4 costo de adopción, K5 doble
audiencia, K6 coherencia con el marco de especificación, K7 riesgo de deriva; 0,15 cada uno salvo K4 = 0,10).
Escala 1–5, con el observable. **[criterio propio]**

| Alternativa | K1 | K2 | K3 | K4 | K5 | K6 | K7 | Ponderado |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| **H** Hipótesis de la presidencia (`F300` §6) | 3: una decisión, una tabla y un control | 4: responde las cinco frases del PO | 4: una fila por audiencia | 3: tabla nueva y control nuevo | 4: incluye `llms.txt` como canal | 4: se apoya en D-01/D-13 | 3: la matriz copia roles que viven en la autorización; acceso en la fila de audiencia (H-02) | **3,60** |
| **CA2-A1** Audiencia y exposición separadas, exposición por pieza y por operación, contrato por exposición, ensanchar = H por cambio | 3: dos campos y un registro | 4: cubre la API restringida con mecanismos de plataforma | 5: escala a operaciones y propiedades | 3: marcas en el código | 4: `llms.txt` por exposición | 4: el contrato sigue siendo `CL-05` | 4: C2 y C2b son mecánicos | **3,90** |
| **CA2-A2** Herencia del permiso del recurso (modelo Backstage): la documentación declara el permiso del producto que la gobierna | 4: un campo | 3: no resuelve la API para socios sin portal | 3 | 2: exige leer la autorización del producto | 3 | 3 | 5: una sola fuente del permiso | **3,35** |
| **CA2-A3** Delegar al RBAC del portal comercial (Mintlify o Redocly), configuración en el repo | 4 | 4 | 3 | 3: plan comercial | 3 | 2: el vocabulario lo fija el proveedor | 2: el cumplimiento queda fuera del producto | **3,00** |

**Por ítem de la hipótesis:**

| Ítem de `F300` §6 | Puntaje (1–5) | Motivo |
| --- | --- | --- |
| 1 Matriz por audiencia con acceso y punto de cumplimiento | 3 | Bien la idea de punto de cumplimiento; mal que el acceso sea columna de la audiencia: va por pieza (H-02) |
| 2 Tabla versionada en el repo | 4 | Sí, como **vocabulario** en A-03 más un registro de exposición; no como fuente de roles |
| 3 Control de cruce de alcance en `docs-guard` | 2 | No hay alcance en el repo que cruzar; va como prueba del producto más CA2-C4 (A-08) |
| 4 Exposición de la API como decisión H | 4 | Correcto, pero **por cambio que ensancha**, no sólo una vez (H-04, CA2-C2b) |
| 5 Ayuda de campo como canal de `CL-06` con control de desfase | 4 | Coincido; falta el mapa de contexto como ancla (B-07) |

**Recomendación:** combinar **H + CA2-A1**, con la regla de alcance de **CA2-A2** para el contenido instanciado y
**CA2-A3** sólo como renderizador admisible.

## 7. Qué rehacer

| Pieza | Cambio | Motivo | Costo | Orden |
| --- | --- | --- | --- | --- |
| `SDEI/00-Marco.md` §2.5 | Fila «Audiencias» como default; filas nuevas «Exposición» y «Superficies» por escenario | H-02, H-07 | Bajo | 2 |
| `SDEI/00-Marco.md` §4 | Fila del actor que decide ensanchar la exposición (H) | H-04 | Bajo | 2 |
| `SDEI/TEM-04` | El agente como canal que hereda la exposición; §3.5 generalizada | A-04, A-10 | Medio | 4 |
| `SDEI/TEM-05` | Tabla de §2: en ESC-SDEI-4 decide la exposición; alcance genérico vs. instanciado; mapa de contexto | H-05, H-07, B-07 | Medio | 3 |
| `SDEI/TEM-06` | CA2-C1, C2, C2b, C3, C4, B-07-C1 y cruce de exposición; `PR-6` por contrato | H-01, H-03 | Alto (herramienta) | 5 (expediente de herramienta) |
| `99-Anexos/Glosario.md` | Audiencia, exposición, punto de cumplimiento, alcance, superficie, contrato por exposición, mapa de contexto | §1 | Bajo | 1 |
| `Examples/` | Extender `Prueba-Ayuda-Por-Rol` con contrato de tres exposiciones y dos alcances | A-15 | Medio | 5 |
| `K` D-01 | Inventario de autorización también de grupos de API y superficies | A-03 | Bajo | 2 |
| `K` D-13 | Suma ayuda de campo, superficie y mapa de contexto | B-04, B-07 | Bajo | 2 |
| `K` §2.3 | Filas «Exposición» y «Superficies» | H-02 | Bajo | 2 |
| `K` D-18 (nueva) | «Audiencias y exposición»: vocabulario, registro de exposición H, contrato por exposición | A-07, A-12 | Medio | 2 |
| `K` A-01, A-03 | A-01 lleva D-18; A-03 suma `exposicion`, `superficie`, `alcance` con `enum` | A-12 | Bajo | 2 |
| Libro (`F099` §5.2) | Parte III renombrada; cap. 7 integrado; capítulo nuevo de API por exposición y portales; cap. 18 con §4 | A-13, H-08 | Medio | 4 |
| Oráculos y criterio de caso (`F204` §9) | Re-sellar con fila D-18 donde el caso tenga API o roles; criterio sin cambio de forma | A-14 | Medio | 3 (antes de la ronda 3) |

## 8. Riesgos

| Riesgo | Mitigación |
| --- | --- |
| La marca `x-exposicion` se olvida en una operación nueva y cae en el default | Sin default: CA2-C1 en rojo si falta |
| Un esquema compartido filtra una propiedad interna por una operación pública | CA2-C2 sobre el cierre de `$ref` |
| El portal comercial devuelve 403 y revela existencia | Exigir 404 en la prueba del producto; Redocly no cumple por defecto |
| Contenido editado en el editor del portal, fuera del repo | Copia publicada con reconciliación programada |
| Documentación restringida empaquetada en la app móvil | CA2-C3 |
| La interfaz interactiva de la API queda abierta en producción | Sólo en desarrollo ([MS-USE]); los socios leen el contrato filtrado en el portal |
| Sobrediseño para proyectos sin API restringida | D-18 con default «todo `publico`, una audiencia por escenario»: la matriz sólo se escribe si el inventario da más de una exposición |

## 9. Fuentes externas

Todas consultadas el 2026-11-01.

| Ancla | Referencia | URL |
| --- | --- | --- |
| [AZ-GRP] | Microsoft. (2025, 29 de septiembre). *Manage developer accounts using groups – Azure API Management*. Microsoft Learn | https://learn.microsoft.com/en-us/azure/api-management/api-management-howto-create-groups |
| [AZ-POR] | Microsoft. (2025, 4 de junio). *Overview of the developer portal in Azure API Management*. Microsoft Learn | https://learn.microsoft.com/en-us/azure/api-management/developer-portal-overview |
| [MINT] | Mintlify. (s. f.). *Authentication setup* | https://www.mintlify.com/docs/deploy/authentication-setup |
| [RED-RBAC] | Redocly. (s. f.). *RBAC* | https://redocly.com/docs/realm/access/rbac |
| [RED-PAGE] | Redocly. (s. f.). *Page permissions* | https://redocly.com/docs/realm/access/page-permissions |
| [RED-FO] | Redocly. (s. f.). *filter-out decorator* | https://redocly.com/docs/cli/decorators/filter-out |
| [RED-RXI] | Redocly. (s. f.). *remove-x-internal decorator* | https://redocly.com/docs/cli/decorators/remove-x-internal |
| [README] | ReadMe. (2026, 21 de septiembre). *End User Access* (Enterprise) | https://docs.readme.com/ent/docs/getting-started-authentication-setup |
| [BS-PERM] | Backstage. (s. f.). *Permissions overview* | https://backstage.io/docs/permissions/overview |
| [BS-RBAC] | Spotify. (s. f.). *RBAC* (Spotify Plugins for Backstage) | https://backstage.spotify.com/docs/plugins/rbac.md |
| [APIGEE] | Google Cloud. (s. f.). *Manage the audiences for your portal (Preview)* — **cuerpo sin leer** | https://docs.cloud.google.com/apigee/docs/api-platform/publish/portal/portal-audience |
| [OAS-311] | OpenAPI Initiative. (2024, 24 de octubre). *OpenAPI Specification v3.1.1*, «Specification Extensions» y «Security Filtering» | https://spec.openapis.org/oas/v3.1.1.html |
| [OVL] | OpenAPI Initiative. (2024, 17 de octubre). *Overlay Specification v1.0.0* | https://spec.openapis.org/overlay/v1.0.0.html |
| [Z-219] | Zalando. (s. f.). *RESTful API Guidelines*, regla 219 «MUST provide API audience» | https://opensource.zalando.com/restful-api-guidelines/#219 |
| [MS-CUST] | Microsoft. (2026, 21 de octubre). *Customize OpenAPI documents*. Microsoft Learn | https://learn.microsoft.com/en-us/aspnet/core/fundamentals/openapi/customize-openapi |
| [MS-USE] | Microsoft. (2026, 28 de agosto). *Use the generated OpenAPI documents*. Microsoft Learn | https://learn.microsoft.com/en-us/aspnet/core/fundamentals/openapi/using-openapi-documents |
| [MS-META] | Microsoft. (2026, 22 de octubre). *Include OpenAPI metadata in an ASP.NET Core app*. Microsoft Learn | https://learn.microsoft.com/en-us/aspnet/core/fundamentals/openapi/include-metadata |
| [STRIPE] | Stripe. (s. f.). *Product release phases* | https://docs.stripe.com/release-phases |
| [ZD] | Zendesk. (s. f.). *How do I make top articles automatically show when a visitor opens the Web Widget (Classic)?* | https://support.zendesk.com/hc/en-us/articles/4408835873306 |
| [FLARE] | MadCap Software. (s. f.). *Context-Sensitive Help* (Flare 2024–2026) — por resultado de búsqueda | https://help.madcapsoftware.com/flare2026/Content/Flare/Step2-Authoring/CSH/CSH.htm |

## 10. Lo que revisé y está bien

1. **404 y no 403** (`SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:106-107`): coincide con Azure API Management y Mintlify.
2. **El mismo filtro para la página, el `.md` y el `llms.txt`** (`SDEI/TEM-05:107-109`): es lo que hace Mintlify con
   su `llms.txt` «reflecting public pages only».
3. **El contrato emitido en el build y comparado en cada pull request** (`SDEI/TEM-06:95`): es la base correcta
   para el contrato por exposición; sólo hay que multiplicarlo.

## 11. Solicitudes de convocatoria y excepciones

- **Solicitud a CA-3**: verificar si `restringido:<grupo>` con inclusión monótona alcanza o hace falta ABAC para
  socios con varias aplicaciones (señal: A-08, la plantilla instanciada).
- **Solicitud a CA-4**: verificar en .NET 10 la forma de incluir una operación en **varios** documentos OpenAPI
  (aquí se propuso un transformador de documento; la opción exacta no se verificó hoy).
- **Excepciones a conocimientos:** ninguna.

## 12. Lo no verificado e incidencias

- **Apigee, *audiences***: la página abrió pero su cuerpo no se pudo leer (sólo navegación): **sin verificar**.
- **Fern `x-fern-audiences`**: la página oficial dio 404; sólo resultado de búsqueda: **sin verificar**.
- **ReadMe**: no se verificó restricción por página; sólo por proyecto.
- **Scalar o Swagger UI detrás de `RequireAuthorization()`**: sólo fuentes de terceros: **sin verificar**.
- **Stripe**: no se verificó si las páginas de *private preview* se ocultan a quien no fue invitado.
- **Shopify y Twilio**: sólo resultados de búsqueda: **sin verificar**.
- **MadCap Flare**: la URL exacta probada dio 404; lo de §4.4 sale del resultado de búsqueda sobre las páginas
  oficiales: **sin verificar en la página**.
- **Backstage**: el texto sobre TechDocs se leyó en la documentación de Spotify para Backstage, no en
  backstage.io.
- **DITA `@deliveryTarget` y Pendo**: semillas de `F300` §8, no reabiertas por CA-2.
- **Incidencia de despacho**: la carta pide puntuar la hipótesis de `F300` §6, y `F300` §7 dice que las
  comisiones no la leen antes de entregar. Rigió la carta; la hipótesis se leyó en la providencia, que la carta
  manda leer, y se puntuó en §6 por separado de las alternativas propias.
- **Mensajes de otras sesiones** durante el trabajo: ninguno.

## 13. Barrido de lo privado de este folio

Se buscaron nombres de máquina, rutas absolutas del sistema de archivos y el nombre real del servicio privado. El
servicio va como `{servicio-privado}`, el directorio de trabajo como `{dir-de-trabajo}` y los repositorios por
alias (`SDEI/`, `LD`, `K`). Barrido corrido el 2026-11-01 con `grep -n -E` sobre rutas absolutas, los nombres de máquina del laboratorio y el nombre real del servicio: 0 coincidencias (rc=1).
