---
doc_id: EXP0003-F385
doc_type: refutacion
title: Refutación del ciclo 3 — ataque a las recomendaciones mejor puntuadas de F380 y F381 (audiencias, paneles, portales y formularios)
status: borrador
origin: agent
confidence: alta en las 16 fuentes reabiertas hoy (§2) y en los hechos del cuerpo medidos con grep; media en la severidad, que es juicio de esta silla y va con su motivo
owner: presidencia de la reedición DocsAsCode (expediente 0003), silla del refutador
last_review: 2026-11-02
audience: [presidencia, jurado del ciclo 3, comisiones CA-1 a CA-9, analistas AD-A y AD-B, PO]
traces: [EXP0003-F099, EXP0003-F204, EXP0003-F300, EXP0003-F310, EXP0003-F320, EXP0003-F330, EXP0003-F340, EXP0003-F350, EXP0003-F360, EXP0003-F370, EXP0003-F374, EXP0003-F376, EXP0003-F380, EXP0003-F381]
---

| Campo | Valor |
| --- | --- |
| Tipo | refutacion |
| Fecha | 2026-11-02 (pedido fechado 2026-11-01; corte de energía en el medio) |
| Autor | Refutador del ciclo 3, fuera del panel: ataca, no vota (`MEP`) |
| Leído | `F300`; `F310`–`F376` (nueve informes); `F380` y `F381`; `F099` §5.2; `F204` §1, §8–§9; `SDEI/` en `LD` `00171bd` (`00-Marco.md`, `TEM-04`, `TEM-05`, `Examples/Prueba-Ayuda-Por-Rol/`); `K` 1.2 en curso (D-01, D-12, D-13) |

Convención: igual que `F380`. `SDEI/` = la guía del sistema de documentación e integración en `LD`; `K` = el
conocimiento en curso; `{servicio-privado}` por alias; `{dir-de-trabajo}` por alias.

## Índice

1. [Resumen de ataques](#1-resumen-de-ataques)
2. [Fuentes reabiertas hoy](#2-fuentes-reabiertas-hoy)
3. [Ataques P0](#3-ataques-p0)
4. [Ataques P1](#4-ataques-p1)
5. [Ataques P2 y P3](#5-ataques-p2-y-p3)
6. [Lo que sobrevive](#6-lo-que-sobrevive)
7. [No verificado, incidencias y mensajes](#7-no-verificado-incidencias-y-mensajes)
8. [Barrido de lo privado](#8-barrido-de-lo-privado)

## 1. Resumen de ataques

| Id | Sev. | Blanco | Ataque en una línea |
| --- | --- | --- | --- |
| R3-01 | **P0** | A-06, A-09, A-11 (ambos analistas, FIRME) | Ningún folio trata que la **fuente** viva en un repositorio público: el filtro de build no protege lo que ya está publicado en el repo |
| R3-02 | **P0** | B-11 w1 / bb1 (FIRME, 4,65 y +12 celdas) | Variantes `Clave.{audiencia}` en `.resx` compilado: en la app móvil y en un cliente WebAssembly viajan **todas** las variantes al dispositivo |
| R3-03 | P1 | A-10 i3 y B-10 v3 (AD-A) | Las ganadoras son síntesis de la propia silla, sin comisión que las sostenga; AD-B llega a otro lugar (A-10 empate, B-10 «nada obligatorio») |
| R3-04 | P1 | A-02/A-12 b3 / m1 | Campo `audiencias:` al lado de `audience:`: casi homónimos, idioma mezclado en las claves, y `audience` sigue diciendo `agente`, que A-04 acaba de sacar |
| R3-05 | P1 | A-06 e1 «404 indistinguible» | La industria no converge en el 404 (Redocly da 403 y redirige al login); la prueba tiene falsos verdes |
| R3-06 | P1 | A-14 l1 y el plan de ronda 3 | Ronda 2: ningún caso pasa con 1.1; sumar D-18 y ~30 controles a 1.2 confunde la causa del resultado de ronda 3 |
| R3-07 | P1 | A-13 y `F099` §5.2 | Parte III tiene caps. 7–8 y presupuesto L3 de 500 líneas; 1, 2 o 3 capítulos nuevos renumeran IV–VI y rompen L3–L9 |
| R3-08 | P2 | Método de firmeza | «FIRME» = +3 celdas que puntúa una sola silla; 16/23 FIRME (AD-A) y 22/29 (AD-B) no coinciden en A-06, A-15, B-10 |
| R3-09 | P2 | A-11 j1 | Cinco controles bloqueantes sin par rojo/verde medido; `indice-sin-fuga` corre sobre la salida y no ve la entrega real |
| R3-10 | P2 | b2 (CA-1) costo | «Migra 283 archivos» cuenta todo `LD`; en `SDEI/` son 30 |
| R3-11 | P2 | B-07 s1a / x1 | ID de contexto en frontmatter + resolvedor: es el `<resourceid>` de DITA sin su `@appname`; con dos productos colisiona |
| R3-12 | P3 | Complejidad para el PO | Registro, jerarquía, niveles, `canal_agente`, `cumple`, localizador decorado: siete piezas nuevas para un PO con un servicio |

## 2. Fuentes reabiertas hoy

Se reabrieron 16 con WebFetch el 2026-11-02. **Ninguna atribución resultó falsa**; dos son incompletas y eso alimenta
ataques (R3-05, R3-11).

| # | Fuente (URL) | Atribución en los folios | Resultado |
| --- | --- | --- | --- |
| 1 | https://learn.microsoft.com/en-us/aspnet/core/fundamentals/openapi/aspnetcore-openapi | «doesn't enable authorization checks by default»; sin grupo = en todos los documentos; «Audiences, such as public and internal APIs» | Literal, confirmada (act. 2026-10-29) |
| 2 | https://design-system.service.gov.uk/components/text-input/ | Pista para la mayoría; sin enlaces; no placeholder por etiqueta | Literal, confirmada |
| 3 | https://genai.owasp.org/llmrisk/llm062025-excessive-agency/ | «in the context of that specific user … minimum privileges necessary» | Confirmada |
| 4 | https://www.mintlify.com/docs/deploy/authentication-setup | 404 sin el grupo; `llms.txt` y mapa «public pages only» | Confirmada |
| 5 | https://www.w3.org/WAI/WCAG22/Understanding/labels-or-instructions.html | 3.3.2 nivel A; no exige asociación programática (1.3.1) | Confirmada |
| 6 | https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.displayattribute.description | «typically used as a tooltip or description UI element»; `GetDescription` | Confirmada (act. 2026-05-27) |
| 7 | https://redocly.com/docs/realm/access/page-permissions | `rbac` en frontmatter; 403; sin enlace en la barra | Confirmada; **además**: sin sesión «redirected to the login page» (R3-05) |
| 8 | https://docs.oasis-open.org/dita/dita/v1.3/os/part1-base/langRef/base/resourceid.html | `@appid`, `@appname`, `@ux-context-string`, `@ux-windowref` | Confirmada; `@appid` es único **junto con** `@appname` (R3-11) |
| 9 | https://docs.appcues.com/targeting-by-user-property | `Appcues.identify()`; valores sensibles a mayúsculas | Confirmada |
| 10 | https://backstage.spotify.com/docs/plugins/rbac.md | TechDocs sin permisos propios; visibilidad por el catálogo | Confirmada: «controlled indirectly through the Catalog permissions» |
| 11 | https://redocly.com/docs/cli/decorators/remove-x-internal | Quita nodos con la bandera; `internalFlagProperty` | Confirmada |
| 12 | https://simonwillison.net/2025/Jun/16/the-lethal-trifecta/ | Datos privados + contenido no confiable + comunicar afuera | Confirmada |
| 13 | https://llmstxt.org/ | Raíz o subcamino; «most specific»; `rel="alternate"`; no trata acceso | Confirmada |
| 14 | https://www.nngroup.com/articles/form-design-placeholders/ | Sherwin 2014, rev. 2018; «clear, visible labels … outside empty form fields» | Confirmada |
| 15 | https://modelcontextprotocol.io/specification/2025-06-18/basic/authorization | Autorización opcional; RFC 9728 y 8707; «MUST NOT accept or transit any other tokens»; 403 | Confirmada |
| 16 | https://learn.microsoft.com/en-us/copilot/microsoft-365/microsoft-365-copilot-privacy | «Semantic Index honors the user identity-based access boundary»; XPIA «may not be available in all … scenarios» | Confirmada (act. 2026-10-31) |

Lectura del refutador: las fuentes están bien citadas, pero **todas describen plataformas con servidor que decide la
entrega**. Ninguna respalda que un repo de fuente pueda contener lo restringido si es público (R3-01), ni que recursos
compilados en un cliente sean «resueltos en servidor» (R3-02). El defecto no está en las citas sino en lo que se
infiere de ellas.

## 3. Ataques P0

### R3-01 La fuente en repositorio público (A-06, A-09, A-11)

**Ataque.** A-09 h1/i1 («una fuente, salidas por superficie, paquete sólo público», 4,80 y +14 celdas, la ganadora
más firme del tablero) y A-06 e1 ponen la protección en el **build** y en el **servidor**: el nivel decide qué se
empaqueta y qué se entrega. Eso supone que el repo de fuente no es una superficie. El cuerpo vive en un repositorio
público (`LD`), los ejemplos (`Examples/Prueba-Ayuda-Por-Rol/`) y el libro también; A-15/B-12 proponen extender ese
ejemplo con un formulario y niveles `restringido`/`interno`. Cualquier página `restringido` escrita en un repo público
ya está publicada: ni el 404 ni `paquete-sin-fuga` la protegen. Lo mismo vale para el caso real: si
`{servicio-privado}` adopta el cuerpo con docs en el mismo repo que un SDK público, lo restringido sale por el clon.
Ninguno de los nueve informes ni de los dos análisis lo trata (búsqueda de «repositorio público» en `F300`–`F381`: 0
coincidencias).

**Impacto.** En el libro, la Parte III enseñaría un control que no controla lo más simple de filtrar. En los ensayos,
un aplicador ciego que siga `K` podría poner páginas `interno` en un repo público y pasar todos los controles.

**Lo resuelve.** (1) Regla en D-18: el nivel máximo de una fuente está acotado por la visibilidad del repo que la
contiene; `restringido` e `interno` exigen fuente en repo privado (o submódulo privado). (2) Control `docs-guard`
`nivel-vs-repo`: si el repo se declara público y una página declara nivel > `producto`, rojo; par rojo/verde en la
PoC-R. (3) El ejemplo público usa contenido **ficticio** y lo dice en su README. (4) Una línea en A-06: «acceso» se
mide en tres puntos —repo, build, servidor—, no en dos.

### R3-02 Variantes por audiencia en recursos compilados (B-11)

**Ataque.** B-11 w1/bb1 (4,65; +12 celdas en AD-A, +7 en AD-B) propone `IStringLocalizer` decorado que busca
`Clave.{audiencia}` en `.resx` y cae a `Clave`, «en servidor». Pero el `.resx` se compila en ensamblados satélite que
viajan con el binario: en la app móvil de `{servicio-privado}` (MAUI) y en cualquier cliente Blazor WebAssembly, el
paquete instalado contiene **todas** las variantes, incluidas las de administrador raíz. Lo mismo `[Display(Description
= …)]` en un DTO compartido entre servidor y cliente. Es entrega por diseño, el punto 1 de la escala de `F380` §3.2
(«Fuga por diseño»), y contradice e1 de la misma silla (no entrega probada). B-11 sólo excluye lo restringido de
`MauiAsset`; los recursos de cadenas no los menciona. *Sin verificar hoy* el empaquetado exacto de satélites en MAUI
Android; el comportamiento de satélites en clientes .NET es el general y se pide medirlo.

**Lo resuelve.** (1) Regla: variantes de nivel > `producto` nunca en `.resx` de ensamblados que se distribuyen a
clientes; se sirven por API autenticada con el token del usuario (lo mismo que B-10 exige al asistente). (2) Control
de producto: inspeccionar el APK/`wwwroot/_framework` construido y dar rojo si aparece una clave con sufijo de nivel
no público; par rojo/verde en la PoC-R. (3) B-11 deja de ser FIRME hasta ese par.

## 4. Ataques P1

### R3-03 Ganadoras que inventó el analista (A-10 i3, B-10 v3)

`F380` se define «fuera del panel: consolida, no vota». Sin embargo en A-10 y B-10 corona **síntesis propias**
(«i3 síntesis de esta silla», «v3 síntesis de esta silla») que ninguna comisión propuso ni puntuó, y las declara
ganadoras con margen +1 y +3. Con la escala de la misma silla, una alternativa sin comisión no puede tener V = 5
(«la sostienen ≥ 2 comisiones»). `F381`, a ciegas, llega a A-10 **empate 7/14 inversiones** y a B-10 **aa3 nada
obligatorio** CON REVISIÓN. B-10 FIRME en AD-A y CON REVISIÓN con otra ganadora en AD-B es una contradicción directa.
**Lo resuelve**: el jurado trata i3 y v3 como propuestas nuevas, las devuelve a CA-7 y CA-8 para puntuarlas, y
ninguna entra a `K` como FIRME en este ciclo.

### R3-04 `audiencias:` junto a `audience:` (A-02/A-12, X-1)

La ganadora de ambos analistas agrega un campo `audiencias:` (entrega) y deja `audience:` (orientación). (a) Son casi
homónimos en dos idiomas: un error de tipeo cambia la semántica de acceso a la de orientación sin que nada falle,
porque `audience` es válido. (b) Las demás claves del frontmatter están en inglés (`doc_id`, `audience`, `traces`); la
nueva rompe la convención. (c) `audience` en `SDEI/00-Marco.md:11` y `TEM-04-Doble-Audiencia.md:11` y `:263` incluye
`agente`, que A-04 (FIRME en ambos) acaba de sacar de las audiencias: la contradicción queda viva en el cuerpo.
**Lo resuelve**: clave con nombre que no se confunda (p. ej. `delivery:`), control que rechace `audiencias:` y otras
variantes cercanas, y limpieza de `agente` en `audience` en el PR de A-04.

### R3-05 El 404 indistinguible no es convergencia de industria (A-06 e1)

AD-A respalda el 404 con Mintlify (confirmado). Redocly, citado por CA-2 y CA-3, da **403** a quien tiene sesión sin
el equipo y **redirige al login** a quien no tiene sesión (confirmado hoy, fuente 7): la existencia de la página se
revela. Dos de los productos de referencia difieren; la regla no puede presentarse como práctica establecida.
Además la prueba es frágil: un 404 por URL mal armada da verde falso en la prueba negativa. **Lo resuelve**: la
regla exige «no entrega del contenido» (403 o 404 a elección declarada) y la prueba negativa compara contra el mismo
URL con un usuario autorizado (par: autorizado 200 con contenido, no autorizado ≠ 200 y sin contenido).

### R3-06 Ronda 3 con más carga confunde la causa (A-14)

`F204` §1: «Una corrida de ocho pasa (C2-r2), y con reserva. Ningún caso pasa. El conocimiento 1.1 no alcanza
todavía.» A-14 propone re-sellar sólo oráculos afectados y mantener el criterio de caso. Si 1.2 trae a la vez las
correcciones de ronda 2 **y** D-18, campo nuevo, jerarquía y un núcleo de cinco controles bloqueantes, un fracaso en
ronda 3 no se puede atribuir: ¿falla la corrección o falla audiencias? **Lo resuelve**: o ronda 3 con 1.2 sin D-18
(audiencias va a 1.3), o ronda 3 con dos brazos declarados en el folio previo (casos con y sin roles), con *n* fijado
antes.

### R3-07 Capítulos nuevos contra el plan del libro (A-13)

`F099` §5.2 fija Parte III = caps. 7–8 (`TEM-04`, `TEM-05`), L3 con 500 líneas, y numera IV–VI y anexos sobre eso
(L4–L9). AD-A deja A-13 en **empate exacto** (7/14 inversiones) y AD-B elige tres capítulos con +1. Cualquier
capítulo nuevo renumera 9–18, mueve referencias cruzadas de los anexos y el índice de L9; ninguno de los dos análisis
lo costea. **Lo resuelve**: audiencias como secciones dentro de los caps. 7–8 (sin renumerar), con presupuesto L3
revisado en una línea del folio de resolución; si el jurado quiere capítulos, un apéndice a `F099` §5.2 con la nueva
numeración antes de tocar L3.

## 5. Ataques P2 y P3

- **R3-08 (P2) Firmeza de una sola mano.** «+3 celdas» sobre puntos que pone una sola silla, sin segunda puntuación,
  convierte juicio en «FIRME». La sensibilidad ±10 % sobre pesos no prueba nada si las celdas son el sesgo.
  Discrepan en firmeza A-06, A-10, A-15, B-10, B-12. *Lo resuelve*: FIRME sólo si ambos analistas coinciden en
  ganadora y firmeza; si no, CON REVISIÓN.
- **R3-09 (P2) Controles sin par.** j1 declara cinco bloqueantes; ninguno tiene par rojo/verde corrido hoy (AD-A lo
  reconoce sólo para `cumple`). `indice-sin-fuga` revisa la salida del build, no lo que el servidor entrega con cada
  token. *Lo resuelve*: ningún control pasa a bloqueante sin par en la PoC-R; mientras tanto, avisa.
- **R3-10 (P2) Costo de b2 inflado.** «Se migran 283 archivos»: medido hoy en `LD` `00171bd`, 283 es todo el repo;
  en `SDEI/` son 30. La desventaja de Co de b2 se reduce si la migración se acota al cuerpo. No cambia la ganadora
  por R3-04, pero el número debe corregirse.
- **R3-11 (P2) ID de contexto sin espacio de nombres.** DITA hace único `@appid` **junto con** `@appname`
  (confirmado). s1a/x1 ponen sólo el ID: con `{servicio-privado}` y un segundo servicio (criterio PE) colisionan.
  *Lo resuelve*: `contexto: <app>/<id>`.
- **R3-12 (P3) Complejidad.** Registro con jerarquía, cuatro niveles, `canal_agente`, `cumple`, localizador decorado,
  ID de contexto, mapa derivado: el PO tiene hoy un servicio con tres roles (raíz, administrador por aplicación,
  integrador). *Lo resuelve*: perfil mínimo (roles planos + nivel + `nivel-vs-repo`) y el resto como extensión por
  escenario.

## 6. Lo que sobrevive

Sin ataque que mueva la ganadora: A-01 (audiencia ≠ permiso), A-04 (lector como dimensión), A-05 (jerarquía
expandida en el build), A-07 (OpenAPI por exposición; fuente 1 confirma que sin grupo un endpoint va a todos los
documentos, lo que **refuerza** el control `contrato-por-exposicion`), A-08, B-01, B-02, B-05, B-06, B-09 (WCAG 3.3.2
no exige asociación: la prueba de `aria-describedby` es correcta como agregado, no como exigencia de 3.3.2).

## 7. No verificado, incidencias y mensajes

- Empaquetado de ensamblados satélite en MAUI Android y en Blazor WebAssembly: **sin verificar hoy** por fuente; se
  pide medirlo en la PoC-R (R3-02).
- ISO/IEC/IEEE 26514:2022 3.1.7: sigue **sin verificar** contra la edición publicada (como en `F380` §10).
- Incidencia: corte de energía el 2026-11-01; folio redactado el 2026-11-02.
- Mensajes de otras sesiones durante la redacción: ninguno.

## 8. Barrido de lo privado

El servicio va como `{servicio-privado}`; sin nombres de máquina ni rutas absolutas del sistema de archivos.
