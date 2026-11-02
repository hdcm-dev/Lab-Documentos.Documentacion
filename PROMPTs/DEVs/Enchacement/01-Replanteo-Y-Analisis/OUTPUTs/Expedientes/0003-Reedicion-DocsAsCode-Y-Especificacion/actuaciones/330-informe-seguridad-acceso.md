---
doc_id: EXP0003-F330
doc_type: informe
title: Informe de la comisión CA-3 (seguridad y control de acceso) — audiencia como orientación y acceso como política, alcance, jerarquía, agente con el alcance de su usuario y ayuda de formulario sin fuga
status: vigente
origin: agent
confidence: alta en lo medido (lectura del cuerpo en 00171bd, del conocimiento 1.2 y de la prueba de ayuda por rol; corrida de la prueba en un contenedor el 2026-11-01 con siete sondas HTTP) y en las fuentes externas reabiertas el 2026-11-01; media en las propuestas y en las puntuaciones, rotuladas [criterio propio]
owner: comisión CA-3 (seguridad y control de acceso) del ciclo 3 de la mesa de la reedición DocsAsCode
last_review: 2026-11-01
audience: [presidencia, análisis de decisiones, refutador, jurado del ciclo 3, PO]
traces: [EXP0003-F300, EXP0003-F099, EXP0003-F204]
---

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-01 |
| Autor | Comisión CA-3, a ciegas: no leyó ningún informe de otra comisión (`mesa/31x-*` a `mesa/37x-*`) |
| Corrige | — |

| Cabecera de comisión | Valor |
| --- | --- |
| Rol | Seguridad y control de acceso: RBAC y ABAC, multiinquilino y alcance, mínimo privilegio, divulgación de información por la documentación, visibilidad frente a autorización en el servidor, documentación como superficie de ataque, auditoría (`F300` §7, fila CA-3) |
| Preguntas a cargo | A-05, A-06, A-08, A-10; B-10. Contesto además, desde la seguridad, las demás A-nn y B-nn y la tabla de §5.3 |
| No-competencia | Redacción y forma editorial del microtexto, accesibilidad (B-09), retórica de la audiencia (A-01 en su parte académica), diseño visual de paneles |
| Norma | `KB/Knowledges/Knowledge-Mesa-De-Expertos-A-Pedido.md` 3.1 (`MEP`) |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | Líneas 1–111 (cabecera y §0 con el «Mapa de carga»); §2.2; §3.2; §3.3; §4; §5.2 |
| Otros documentos cargados | `Cadena-De-Consecuencias` 2.0 §2; `Mesa-Consulta-A-Un-Tercero` 2.0 §0 y §1 (no hay tercero: no rige) |
| Insumos leídos | `F300` entero; `SDEI/TEM-05` entero; `SDEI/TEM-04` l. 30-230; `SDEI/00-Marco.md` l. 60-140; `SDEI/99-Anexos/Glosario.md` (términos de rol, actor, control); `SDEI/99-Anexos/Esquema-Frontmatter-Y-Prefijos.md` l. 46-64; `SDEI/Examples/Prueba-Ayuda-Por-Rol/` (README, `Consola/Program.cs`, `Web/HelpCatalog.cs`, `Web/Program.cs`, `Web/Components/Pages/Ayuda.razor`, `Web/Components/AyudaContextual.razor`, `Web/AyudaDemo.Web.csproj`); `tools/docs-guard/esquemas/ayuda.schema.json`; `K` §0, §2.2, §2.3, §3.2, §5.2, §6; `F099` §5.2.1; `F204` índice, §5 y §7 |
| Medios propios | `git`, `grep`, `sed`; la prueba de ayuda por rol compilada y corrida en una copia, en `mcr.microsoft.com/dotnet/sdk:10.0` con `ASPNETCORE_ENVIRONMENT=Production`, y sondeada con `curl` (§7); WebFetch y WebSearch el 2026-11-01 (§8) |

**Convención de citas.** Como `F300`: `SDEI/` = la carpeta del cuerpo en Lab-Documentos `00171bd`; `PAR/` =
`SDEI/Examples/Prueba-Ayuda-Por-Rol/`; `K` = el conocimiento en curso, versión 1.2; `KB/` = la base de
conocimiento del PO. Lo privado va por alias: `{servicio-privado}`, `{dir-de-trabajo}`. Lo que es opinión de esta
comisión lleva **[criterio propio]**. Toda fuente externa lleva su URL en §8, consultada el 2026-11-01.

**Lectura P0–P3 para este caso** [criterio propio]: **P0**, la propuesta o el cuerpo entregarían documentación
restringida a quien no corresponde, o la harían parecer protegida sin estarlo; **P1**, falta un control o un punto
de aplicación que la propuesta necesita para cumplir el pedido sin fuga; **P2**, defecto acotado, de prueba o de
caso borde; **P3**, forma.

## Índice

1. [Definiciones y forma de este informe](#1-definiciones-y-forma-de-este-informe)
2. [Lo que el objetivo da por fijo, mirado desde la seguridad](#2-lo-que-el-objetivo-da-por-fijo-mirado-desde-la-seguridad)
3. [Hallazgos](#3-hallazgos)
4. [Dictamen por pregunta](#4-dictamen-por-pregunta)
5. [Propuesta concreta](#5-propuesta-concreta)
6. [Puntuación de la hipótesis y de las alternativas](#6-puntuación-de-la-hipótesis-y-de-las-alternativas)
7. [Ensayo corrido](#7-ensayo-corrido)
8. [Fuentes externas](#8-fuentes-externas)
9. [Lo que revisé y está bien](#9-lo-que-revisé-y-está-bien)
10. [Qué rehacer: tabla de §5.3](#10-qué-rehacer-tabla-de-53)
11. [Solicitudes de convocatoria y dudas para el PO](#11-solicitudes-de-convocatoria-y-dudas-para-el-po)
12. [Excepciones a conocimientos](#12-excepciones-a-conocimientos)
13. [Lo no verificado](#13-lo-no-verificado)
14. [Mensajes de otras sesiones](#14-mensajes-de-otras-sesiones)
15. [Barrido de lo privado de este folio](#15-barrido-de-lo-privado-de-este-folio)

---

## 1. Definiciones y forma de este informe

Desde la seguridad, la palabra «audiencia» nombra **dos cosas que hay que mantener separadas**, porque una protege
y la otra no:

| Término | Definición [criterio propio, sobre las fuentes citadas] | Protege |
| --- | --- | --- |
| **Audiencia (orientación)** | Para quién se escribe una pieza: decide registro, tarea, ruta de lectura. Es lo que hoy hace `audience` en el corpus: «A quién sirve; ordena las rutas de lectura» (`SDEI/99-Anexos/Esquema-Frontmatter-Y-Prefijos.md:53`) | No |
| **Acceso (entrega)** | A quién se le **entrega** la pieza por cualquier canal (página, `.md`, `llms.txt`, índice de búsqueda, ayuda de campo, respuesta de un asistente, paquete instalado). Es una decisión de autorización: atributos del sujeto, de la pieza, de la acción y del entorno, evaluados contra una política (NIST SP 800-162, Hu et al., 2014, act. 2019) | Sólo si un **punto de aplicación** en el servidor o en el build la hace cumplir |
| Visibilidad | Mostrar u ocultar en la navegación. El cuerpo ya lo dice: «Ocultar … es visibilidad; no entregarla es acceso. Sólo lo segundo protege» (`SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:48`). La industria lo repite: Mintlify, «Visibility rules only hide content in the browser» | No |
| Alcance | El conjunto de recursos sobre el que vale un permiso (Microsoft Learn, *Understand scope for Azure RBAC*: «Scope is the set of resources that access applies to»). En `{servicio-privado}`: global (raíz) o una aplicación | Sí, como atributo de autorización |
| Nivel de acceso | Clasificación de la pieza: `publico`, `producto` (sesión del producto), `restringido` (pertenencia que concede una persona: invitación, credencial, grupo), `interno` (no sale del build ni del repositorio privado) | Sí, con su punto de aplicación (§5.3) |
| Punto de aplicación | El componente que niega la entrega: el servidor del producto, el portal, el build, el repositorio privado. Sin él, un nivel es una etiqueta | — |

**Consecuencia de diseño** [criterio propio]: la audiencia del PO («todos ven documentación diferente — incluso
alcances diferentes», `F300` E-04) es **orientación más acceso**. El sistema documentador puede escribir la
orientación en el repositorio; el acceso lo decide el producto en el servidor, con atributos que el repositorio
**declara** pero no **resuelve** (la pertenencia de una persona a una aplicación es dato del producto, no del repo).

Forma: hallazgos con nivel y ancla (§3), dictamen por pregunta (§4), propuesta con campos, controles y ejemplo
(§5), puntuación (§6), ensayo (§7), fuentes (§8), tabla de §5.3 (§10).

## 2. Lo que el objetivo da por fijo, mirado desde la seguridad

| Lo que se da por fijo | Origen | Lectura de CA-3 |
| --- | --- | --- |
| Que la audiencia es **una** fila con todas las dimensiones, incluido «lector (humano, agente)» (`F300` §6.1) | Hipótesis de la presidencia, sin frase del PO | El PO pidió roles, jerarquía, superficies, alcances y una API restringida (E-01 a E-05). «Lector agente» es un agregado marcado (`F300` §3). Como dimensión de **acceso** es peligroso: el agente no tiene acceso propio, hereda el del usuario (H-04) |
| Que la tabla del repo lleva el **alcance** («por aplicación o inquilino») | Hipótesis §6.1 | El repo puede llevar el **tipo** de alcance; los **valores** (qué aplicaciones, qué inquilinos) son datos del producto y, escritos en el repo, son divulgación (H-05) |
| Que la documentación de la API restringida se protege restringiendo la documentación | E-05, «por razones de seguridad» | El pedido es literal y se cumple, pero restringir la documentación no protege la API: la protege su autorización (OWASP Top 10:2025 A01: «Access control is only effective when implemented in trusted server-side code») (H-09) |
| Que el «cruce de alcance» es un control de `docs-guard` | Hipótesis §6.3 | Mitad sí: el cruce **entre declaraciones** (enlaces entre páginas de distinto acceso) es determinista y va a `docs-guard`; el cruce **en ejecución** (un administrador de la aplicación A pide algo de la B) sólo se prueba en el producto (§5.4) |

## 3. Hallazgos

| Id | Nivel | Ancla | Hallazgo | Impacto si no se corrige | Dirección |
| --- | --- | --- | --- | --- | --- |
| CA3-01 | P1 | E1: `SDEI/99-Anexos/Esquema-Frontmatter-Y-Prefijos.md:53`; `K:430-437` | `audience` es un campo de **orientación** con un vocabulario que mezcla tipo de lector (`humano`, `agente`) y función (`docente`, `qa`). Si la matriz de audiencias reutiliza ese campo para decidir la entrega, un campo que nadie hace cumplir pasa a parecer un control | Una página marcada `audience: [admin-raiz]` se lee como protegida y se publica igual en un sitio estático: CWE-200 | Separar: `audience` sigue de orientación; el acceso va en un campo propio que lee el servidor (§5.2) |
| CA3-02 | P1 | E1: §7, sonda 1 y 5; `PAR/Web/Program.cs:43-54` | Las respuestas filtradas por rol (`llms.txt`, `.md` crudo, HTML) salen **sin `Cache-Control` ni `Vary`**. La sesión va en cookie, no en `Authorization`, así que la prohibición de RFC 9111 §3.5 para cachés compartidas no la cubre | Un proxy o CDN compartido puede servir el `llms.txt` del administrador a un alumno: CWE-524 | Respuestas filtradas por audiencia con `Cache-Control: private, no-store` y `Vary: Cookie`; claves de caché de salida con audiencia y alcance (OWASP *Multi-Tenant Security Cheat Sheet*). Prueba del producto, no `docs-guard` |
| CA3-03 | P2 | E1: `PAR/Web/Components/Pages/Ayuda.razor:38`; §7, sonda 6 | La página muestra «Visible para: Student, Administrator» a quien la lee: el alumno aprende el nombre de un rol que no tiene. Con alcance, esa lista nombraría aplicaciones o inquilinos ajenos | Divulgación de la estructura de autorización: CWE-200 | La lista de acceso no se muestra al lector; sólo en una vista de autor |
| CA3-04 | P1 | E2: OWASP LLM06:2025 («Implement authorization in downstream systems rather than relying on an LLM to decide»); Microsoft Learn, Copilot: «only surfaces organizational data to which individual users have at least view permissions» | La hipótesis pone «lector (humano, agente)» como columna de cada fila de audiencia. Si eso se lee como acceso, habilita una fila «agente» con nivel propio: un índice para agentes con más alcance que su usuario | Fuga por el asistente: LLM02:2025 y LLM08:2025 | El lector es dimensión de **orientación y canal**, nunca de acceso. Regla: un agente recupera con la identidad y los atributos de su usuario, en el servidor (§4, A-10) |
| CA3-05 | P1 | E2: OWASP *Multi-Tenant Security Cheat Sheet* («Bind tenant context to a server-verified identity and current tenant membership»); `K` I-09 (`K:146`) | La tabla del repo con «alcance (por aplicación o inquilino)» invita a escribir valores de alcance (nombres de aplicaciones, de clientes, de socios) en un repositorio | Divulgación de clientes en el repo (y, si es público, choque con I-09); además, la tabla queda vieja con cada alta de aplicación | En el repo, el **tipo** de alcance (`global`, `por-aplicacion`, `propio`); la pertenencia se resuelve en el producto con autorización por recurso |
| CA3-06 | P1 | E1: `SDEI/00-Marco.md:112`; `PAR/Web/AyudaDemo.Web.csproj:12`; MASWE-0004 (OWASP MAS, título «Sensitive Data Hardcoded in the App Package») | El cuerpo dice que lo que viaja en la app instalada es visible, pero ningún control comprueba **qué páginas** viajan. La prueba incrusta toda la ayuda, de todos los roles, en el ensamblado (`EmbeddedResource Include="Ayuda\**\*.md"`): en el servidor está bien; copiado a una app MAUI, entrega la ayuda del administrador a cualquiera que descargue el paquete | Fuga por el paquete móvil; el filtro por rol en la app es sólo visibilidad | Control AC-4 (§5.4): lo empaquetado en una superficie instalable sólo admite nivel `publico`; lo demás se pide al servidor con sesión |
| CA3-07 | P1 | E1: `SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:180-182`; `PAR/Web/HelpCatalog.cs:104-122` | El cruce de rol existe como validador de la prueba, no como control de `docs-guard`; el cruce de nivel, de alcance y de superficie no existe en ningún lado | Una página de administrador de aplicación enlaza a una del administrador raíz; además del enlace roto, revela el título o la ruta | Control AC-2 que generaliza `HelpCatalog.Validate` a «lectores(origen) ⊆ lectores(destino)» sobre todas las dimensiones de acceso, con la jerarquía expandida |
| CA3-08 | P2 | E1: `PAR/Web/Program.cs:40`; `Ayuda.razor:53`; `AyudaContextual.razor:18` | El rol se lee con `FindFirst("gf:role")`: un solo rol por sesión. Un usuario con dos roles, o un administrador de dos aplicaciones en `{servicio-privado}`, ve sólo lo del primero | Falla cerrada (no filtra de más), pero niega ayuda que corresponde; quien la arregle «a mano» puede abrir de más | El filtro evalúa el **conjunto** de atributos del sujeto; prueba con un sujeto de dos roles y dos alcances |
| CA3-09 | P1 | E2: OWASP API Security Top 10 2023, API9 («Make API documentation available only to those authorized to use the API»); OWASP Top 10:2025 A01 | La hipótesis §6.4 (exponer la documentación de la API es clase H) es correcta, pero no dice **qué** protege ni que la protección no puede depender del secreto de la documentación. Si el SDK se publica en un feed público, su superficie y sus comentarios XML ya son públicos | Una decisión H «documentación restringida» que da falsa seguridad o que no se puede cumplir | La decisión H se escribe con tres respuestas: qué se restringe (operaciones de administración, internas), qué ya es público por el paquete, y qué control del servidor protege cada operación (§4, A-07) |
| CA3-10 | P2 | E2: `KB/Knowledges/Knowledge-Cadena-De-Consecuencias.md` §2, punto 4 («alcanza a terceros que ya la tomaron … es irreversible»); `SDEI/TEM-06-Compuertas-Y-CI.md:48` (G4) | **Ampliar** el acceso de una página o de una audiencia es irreversible en los hechos: lo leído no se des-lee. La hipótesis no fija quién decide una ampliación | Un agente amplía `roles` en su propio pull request y la guarda lo fusiona | Toda ampliación de acceso (página o registro) es clase H y deja reserva automática (G4); una restricción es P |
| CA3-11 | P2 | E2: OWASP Top 10:2025 A01 (registrar las fallas de control de acceso); *Multi-Tenant Security Cheat Sheet* (contexto de inquilino verificado en los eventos de auditoría) | No hay requisito de auditoría: ni de las denegaciones (404 por audiencia), ni de las concesiones de acceso `restringido` (quién invitó a qué desarrollador y cuándo) | No se puede reconstruir quién vio la documentación de desarrollador ni detectar una enumeración | Requisito del producto (no de `docs-guard`): registrar denegaciones y concesiones con sujeto, alcance verificado y pieza; la concesión la hace una persona |
| CA3-12 | P2 | E2: CWE-204 («Observable Response Discrepancy»), CWE-209 | La ayuda de campo y los mensajes de validación pueden enumerar o revelar reglas internas: «ese nombre de aplicación ya existe» cuando la unicidad es global en `{servicio-privado}` revela aplicaciones de otros administradores | Enumeración entre alcances desde un formulario | Revisión de cada mensaje de validación por audiencia con la pregunta «¿revela algo de otro alcance?»; prueba del producto |
| CA3-13 | P3 | E1: §7, sondas 2 a 4; GitHub Docs (404 en lugar de 403); Redocly (403 a quien inició sesión sin el equipo); Mintlify (404) | La industria se divide entre 404 y 403. El cuerpo elige 404 «para no revelar siquiera que la página existe» (`SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:106-107`), y la prueba lo cumple: el 404 de una página restringida y el de una inexistente sólo difieren en la URL que repite el selector de idioma | — (está bien) | Mantener el 404 como regla y convertir la comparación en prueba del producto |

## 4. Dictamen por pregunta

Las preguntas a cargo (A-05, A-06, A-08, A-10, B-10) van completas: estado del arte, qué cubre el cuerpo, propuesta,
riesgos. Las demás, sólo lo que la seguridad les agrega.

### A-05 — Jerarquía de privilegio

**Estado del arte.** El modelo NIST de RBAC (Sandhu, Ferraiolo y Kuhn, 2000) se adoptó como ANSI/INCITS 359-2004 y se
revisó como INCITS 359-2012, con un modelo de referencia y una especificación funcional (NIST CSRC, *Role Based
Access Control*); las jerarquías de roles son parte del modelo de referencia **[el detalle de jerarquías generales y
limitadas no lo confirma la página consultada: referencia bibliográfica, sin reabrir el texto de la norma]**. Azure
RBAC hereda permisos de un alcance padre a uno hijo («Lower levels inherit role permissions from higher levels»).
OWASP pide mínimo privilegio «horizontally and vertically» y prefiere ABAC o ReBAC a RBAC para decisiones por objeto
(*Authorization Cheat Sheet*).

**Qué cubre el cuerpo.** Sólo roles planos: la página lista sus roles y el filtro pregunta si el rol de la sesión
está en la lista (`PAR/Web/HelpCatalog.cs:66`). No hay jerarquía declarada ni herencia.

**Propuesta** [criterio propio]. (1) La jerarquía se declara **una vez**, en el registro de audiencias (§5.2): `AdminRaiz
⊃ AdminApp ⊃ Usuario`. (2) El build la **expande**: cada página termina con la lista explícita de roles que la
leen. El filtro en ejecución sigue siendo pertenencia a un conjunto (como hoy), sin interpretar la jerarquía en el
servidor: menos lógica en el punto de aplicación, menos errores. (3) Páginas exclusivas del nivel alto: se declaran
para `AdminRaiz` y la expansión no las baja. (4) La herencia es **vertical, no horizontal**: el raíz hereda las
páginas de rol de `AdminApp`, pero no los alcances: si una página es «por aplicación», el raíz la ve con alcance
global por su propio permiso, no porque herede el de una aplicación. (5) El cruce: un enlace de una página de
`AdminRaiz` a una de `AdminApp` no cruza (el raíz hereda); uno de `AdminApp` a una de `AdminRaiz`, sí: rojo en AC-2.

**Riesgo.** Una herencia mal declarada abre de golpe todo un nivel. Por eso cambiar la jerarquía es una ampliación
y, por CA3-10, clase H con reserva.

### A-06 — Acceso frente a visibilidad

**Estado del arte.** «Except for public resources, deny by default»; «Access control is only effective when
implemented in trusted server-side code»; la navegación forzada a páginas autenticadas es la debilidad típica (OWASP
Top 10:2025 A01, que mapea CWE-200 y CWE-425). En portales: Mintlify devuelve 404 a quien no está en los `groups` de la
página y aclara que la personalización sola «do not restrict access to a page's direct URL»; con autenticación
parcial, su `llms.txt` y su mapa del sitio reflejan sólo las páginas públicas. Redocly declara `rbac` por página en el
frontmatter y devuelve 403 a quien inició sesión sin el equipo. Backstage TechDocs no tiene permisos propios: su
visibilidad sale de los permisos del catálogo sobre la entidad dueña de la documentación. GitBook arma contenido
adaptativo con *claims* del visitante y distingue *claims* firmados de no firmados (los que llegan por URL o cookie sin
firmar se declaran `unsigned`).

**Qué cubre el cuerpo.** Bien la distinción y la regla del servidor (`SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:48`,
`:63-64`, `:103-109`); el 404 y el mismo filtro para página, `.md` y `llms.txt` (`PAR/Web/Program.cs:34-55`). Falta:
niveles de acceso con su punto de aplicación, caché (CA3-02), paquete móvil (CA3-06) y búsqueda.

**Propuesta: dónde se hace cumplir cada nivel** [criterio propio]:

| Nivel | Punto de aplicación | Cómo se prueba que **no se entrega** |
| --- | --- | --- |
| `publico` | Ninguno en ejecución; el **build** publica sólo estas páginas | El artefacto publicado (sitio, paquete, `llms.txt`) no contiene ninguna página de otro nivel (AC-3, AC-4) |
| `producto` | Servidor del producto, con sesión; mismo filtro en todos los canales | Prueba de matriz audiencia × canal × página con el estado esperado (200 o 404) y el cuerpo sin el título; 404 indistinguible del de una página inexistente; cabeceras de caché privadas |
| `restringido` | Servidor o portal, con pertenencia **concedida por una persona** (invitación, grupo, credencial) y revocable | Lo anterior más: sin la concesión, 404; con la concesión revocada, 404 en la siguiente sesión; la concesión queda auditada |
| `interno` | Build y repositorio privado: no se compila en el producto (`SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:103-105`) | El artefacto del producto no contiene ninguna pieza `interno` (AC-3) |

**Qué aportan las normas.** ABAC (NIST SP 800-162) da el vocabulario: atributos del **sujeto** (rol, alcance),
del **objeto** (nivel, roles, tipo de alcance, superficies de la pieza), de la **acción** (leer, listar, indexar,
recuperar para un agente) y del **entorno** (superficie desde la que se pide). CWE-200 es la consecuencia que se
evita; CWE-425, la forma de ataque que la prueba de matriz cubre; CWE-204, la razón del 404 indistinguible.

### A-08 — Alcance por inquilino o aplicación

**Estado del arte.** Azure RBAC define el alcance como el conjunto de recursos al que vale un permiso, en una jerarquía
de cuatro niveles. OWASP *Multi-Tenant Security Cheat Sheet*: «Treat client-supplied tenant identifiers as selectors
only»; atar el contexto de inquilino a una identidad verificada por el servidor; probar la denegación entre
inquilinos; incluir el inquilino en toda clave de caché cuyo valor o autorización varíe por inquilino. CWE-639 es el
defecto: cambiar la clave que identifica el recurso para ver el de otro. Zanzibar (Pang et al., 2019) es el
antecedente de la autorización por relaciones (ReBAC), que OWASP prefiere para decisiones por objeto.

**Qué cubre el cuerpo.** Nada: ni `SDEI/TEM-05` ni `K` D-13 (`K:274`) nombran el alcance.

**Propuesta** [criterio propio]. Dos administradores del mismo rol ven documentación distinta por dos razones, y cada
una se resuelve en otro lugar:

1. **Distinto contenido por los datos de su aplicación** (su clave, su configuración, sus plataformas activas): no es
   documentación del repo, es **dato del producto** que una página plantilla muestra. La página declara `alcance:
   por-aplicacion` y el servidor rellena con los datos de la aplicación que el sujeto administra, con autorización por
   recurso. El repo nunca guarda valores.
2. **Distinta documentación por lo que su aplicación tiene habilitado** (un plan, una función, un socio con un
   contrato propio): es un **atributo del objeto** (`requiere: [funcion-x]`) que el servidor compara con un atributo
   de la aplicación. La pertenencia de una aplicación a un plan es dato del producto.

**Cruce de alcance.** Declarativo (AC-2): una página `global` no enlaza a una `por-aplicacion` que el mismo lector
puede no ver. En ejecución (prueba del producto): el administrador de la aplicación A pide la página de la B
cambiando el identificador en la URL, y recibe 404 (CWE-639).

**Riesgo.** Un índice de búsqueda o un `llms.txt` común a todas las aplicaciones mezcla alcances. La regla: todo
índice derivado se arma por audiencia y alcance, o se filtra en el servidor en el momento de la consulta.

### A-10 — Agente por audiencia

**Estado del arte.** `llms.txt` es una propuesta de Jeremy Howard (2024-09-03) que no trata acceso ni autenticación
(llmstxt.org). Mintlify, con autenticación parcial, publica un `llms.txt` que refleja sólo las páginas públicas.
Microsoft 365 Copilot «only surfaces organizational data to which individual users have at least view permissions»
y su índice semántico respeta el límite de identidad del usuario. OWASP para LLM: LLM02:2025 pide limitar el acceso
a datos sensibles por mínimo privilegio; LLM06:2025, que las extensiones actúen en el contexto del usuario y que la
autorización la decida el sistema de abajo, no el modelo; LLM08:2025, almacenes de *embeddings* con control de acceso
fino y particionados, y advierte la fuga entre contextos en entornos multiinquilino.

**Qué cubre el cuerpo.** El mismo filtro para `.md` y `llms.txt` que para la página (`SDEI/TEM-04-Doble-Audiencia.md:89`,
`:196-201`; `PAR/Web/Program.cs:34-55`) y lo que el agente lee es dato (`SDEI/TEM-04-Doble-Audiencia.md:60-63`). Falta:
recuperación semántica (RAG), asistentes del producto, y la regla de que el agente no tiene acceso propio.

**Propuesta** [criterio propio]. (1) **El agente no es una audiencia de acceso**: es un canal de la audiencia de su
usuario. (2) Todo canal para agentes (`llms.txt`, `.md`, índice de búsqueda, almacén de *embeddings*, herramienta MCP)
se arma o se filtra **en el servidor** con los atributos verificados del usuario, con el mismo filtro que la página.
(3) Si hay un índice semántico, se particiona por nivel y alcance, o se filtra en la consulta con metadatos de acceso
que salen del mismo frontmatter; nunca un índice global con un filtro en el *prompt*. (4) Un `llms.txt` público sólo
lista páginas `publico`. (5) Prueba: la consulta del asistente de un usuario `AdminApp` no recupera ningún fragmento
de una página `AdminRaiz` (se siembra un marcador único en la página restringida y se busca en la respuesta y en los
fragmentos recuperados).

### B-10 — Agente que asiste en el formulario

**Estado del arte.** Lo de A-10, más: OWASP LLM01 (inyección) y LLM08 (instrucciones escondidas en documentos que entran
al índice, con el ejemplo del texto blanco sobre blanco); OWASP *Input Validation Cheat Sheet*: «Client-side
validation is bypassable», y validar en el servidor aunque el navegador valide lo mismo.

**Qué cubre el cuerpo.** La fuente revisada contra inyección (AI-1 a AI-5, `SDEI/TEM-04-Doble-Audiencia.md:166-172`) y la
idea de que el asistente de la persona usuaria no lo controla quien documenta (`:191-194`).

**Propuesta y riesgos** [criterio propio]:

| Riesgo | Por dónde entra | Control |
| --- | --- | --- |
| Fuga de ayuda de otra audiencia | El asistente recupera ayuda de campo o páginas con una identidad de servicio que ve todo | Recupera con la identidad del usuario (A-10); prueba con marcador sembrado |
| Inyección por la ayuda | Texto escondido en la fuente | Ya cubierto por AI-1 a AI-5 sobre la fuente; la ayuda de campo en archivos de recursos tiene que pasar los mismos controles (hoy no los pasa: `docs-guard` mira Markdown) |
| Inyección por los **datos** del formulario | En `{servicio-privado}`, lo que un administrador escribe (nombre de la aplicación, texto de una notificación) aparece en formularios que lee otro rol, y su asistente lo lee como contexto | El contexto del formulario se pasa como dato delimitado; el asistente **sugiere** valores, no envía; todo envío pasa por la misma validación y autorización del servidor (LLM06) |
| Agencia excesiva | El asistente cambia un campo oculto o el alcance (la aplicación seleccionada) | El alcance no es un campo que el asistente pueda fijar; lo fija la sesión |
| Mensajes que enumeran | La ayuda o la validación revelan existencia de recursos de otro alcance (CA3-12) | Revisión por audiencia; prueba del producto |
| Promesa sin regla | La ayuda dice un límite que el servidor no aplica (el 60/80 de `SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:127-132`) | El control de desfase regla↔texto (B-05) es también de integridad: la validación del cliente es experiencia, no seguridad |

### Demás preguntas, desde la seguridad

| Pregunta | Aporte de CA-3 |
| --- | --- |
| A-01 Definición | Separar orientación y acceso (§1). El término «actor» del glosario (`SDEI/99-Anexos/Glosario.md:43`) es del sistema documentador; el «sujeto» de ABAC es quien pide la pieza: no confundirlos |
| A-02 Dimensiones | De acceso, ortogonales: rol, alcance, nivel, superficie. Derivada: jerarquía (se expande a roles). De orientación: lector humano o agente, idioma, tarea. El idioma **no** puede ampliar el acceso: lo decide la página fuente (`PAR/Web/HelpCatalog.cs:30`, `:66`; `tools/docs-guard/esquemas/ayuda.schema.json:16`, una traducción no lleva `roles`). Obligatoria por escenario: el nivel, en todo escenario con producto; rol y alcance, en panel con roles; superficie, si hay más de una |
| A-03 Relación | Rol es atributo del sujeto; persona de UX es orientación; escenario fija qué dimensiones son obligatorias. La fila «Audiencias» del Marco (`SDEI/00-Marco.md:108`) queda como orientación; el acceso entra como decisión nueva |
| A-04 Doble audiencia | Queda como dimensión de **orientación y canal** dentro de cada audiencia; el cap. 7 suma «el agente hereda el acceso de su usuario» |
| A-07 API restringida | Clase H, con la ficha de CA3-09: qué se restringe, qué ya es público por el paquete, qué control protege cada operación. Mecanismos verificados: grupos que manejan la visibilidad de productos en el portal de Azure API Management (semilla de `F300` §8); `MapOpenApi().RequireAuthorization("…")` en ASP.NET Core, que no autoriza por defecto («The OpenAPI endpoint doesn't enable authorization checks by default»); la plantilla publica el documento sólo en desarrollo (`if (app.Environment.IsDevelopment())`). Un documento OpenAPI por audiencia, generado, no uno filtrado en la interfaz de Swagger (eso es visibilidad) [criterio propio] |
| A-09 Superficies | Una fuente; salidas por superficie. Lo que viaja en un paquete instalable es `publico` (AC-4); lo demás, por API con sesión |
| A-11 Controles | §5.4 |
| A-12 Ficha y oráculos | Decisión nueva en `K` (D-18) con el registro de audiencias como artefacto nuevo (A-12 del conocimiento) y los controles AC-1 a AC-4; D-13 queda para la forma de la ayuda |
| A-13 Libro | Parte III suma un capítulo «Audiencias y acceso» (§10) |
| A-14 Ensayos | §10, última fila |
| A-15 Demo | Extender `Prueba-Ayuda-Por-Rol` con jerarquía (tres roles), dos aplicaciones, una superficie empaquetada y un OpenAPI con `RequireAuthorization`, más las pruebas negativas de §5.4 |
| B-01 Mecanismos | Todo lo que va en el HTML o en el paquete del cliente (marcador, *tooltip*, texto de ayuda) se entrega: si el campo es de un rol, el texto se resuelve en el servidor |
| B-02, B-03 Fuente única | Los `ErrorMessage` de las anotaciones de datos viajan con el ensamblado que las declara; en Blazor WebAssembly o MAUI, al cliente. No poner ahí reglas internas ni límites de otro plan |
| B-04 Clase de pieza | Fuera de competencia; desde la seguridad, el microtexto necesita los mismos atributos de acceso que la página |
| B-05 Desfase | Además de documental, es de integridad (tabla de B-10, última fila) |
| B-06 Por audiencia | El texto de un campo por audiencia se elige en el servidor; nunca se envían todas las variantes con un interruptor en el cliente |
| B-07 Paneles y portales | El vínculo pantalla→tema ya filtra por rol y no dibuja nada si el rol no alcanza (`PAR/Web/HelpCatalog.cs:78-80`; `PAR/Web/Components/AyudaContextual.razor:3-4`): buen patrón. Un *widget* de un portal externo recibe el contexto de la pantalla: mandar el identificador del tema, no el del inquilino ni el de la aplicación |
| B-08 Plataformas de guía | La segmentación de una plataforma comercial dirige qué guía se muestra (semilla Pendo, `F300` §8); si además impide la entrega, **sin verificar**. Contenido restringido no va ahí |
| B-09 Accesibilidad | Fuera de competencia |
| B-11 .NET | Políticas y *claims* para el rol; autorización por recurso para el alcance; `RequireAuthorization` en el OpenAPI; caché de salida variando por audiencia y alcance; en MAUI, sólo ayuda `publico` en el paquete |
| B-12 Demo | El de A-15 con un formulario: ayuda y mensaje trazan a la regla, y la prueba de matriz incluye la ayuda del campo |

## 5. Propuesta concreta

### 5.1 Definición para el glosario

**Audiencia**: conjunto de lectores definido por atributos (rol, alcance, superficie, canal, tipo de lector) para el
que se escribe una pieza y al que se le entrega. Su **orientación** decide cómo se escribe; su **acceso**, a quién
se entrega, y sólo protege si un punto de aplicación lo hace cumplir. **[criterio propio, sobre NIST SP 800-162 y
`SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:48`]**

### 5.2 Registro de audiencias y campos de frontmatter

La «matriz» de la presidencia, con cuatro enmiendas: los valores de alcance no van; la jerarquía se declara y se
expande; el lector agente no es fila de acceso; la columna «dónde se hace cumplir» sale del nivel.

```yaml
# [Fragmento ilustrativo: registro de audiencias de un producto como {servicio-privado}, por su forma]
jerarquia:
  AdminRaiz: [AdminApp]
  AdminApp: []
  Usuario: []
  Integrador: []
audiencias:
  AUD-PUB:      {nivel: publico,     roles: [],           alcance: global,         superficies: [sitio]}
  AUD-USR:      {nivel: producto,    roles: [Usuario],    alcance: propio,         superficies: [movil]}
  AUD-ADM-APP:  {nivel: producto,    roles: [AdminApp],   alcance: por-aplicacion, superficies: [panel]}
  AUD-ADM-RAIZ: {nivel: producto,    roles: [AdminRaiz],  alcance: global,         superficies: [panel]}
  AUD-DEV:      {nivel: restringido, roles: [Integrador], alcance: por-aplicacion, superficies: [portal, api]}
  AUD-INT:      {nivel: interno,     roles: [],           alcance: global,         superficies: [repo]}
punto_de_aplicacion:
  publico: build
  producto: servidor-del-producto
  restringido: servidor-o-portal-con-concesion-de-una-persona
  interno: build-y-repo-privado
```

La página declara a qué audiencias se entrega, y aparte, para quién se escribe:

```yaml
# [Fragmento ilustrativo: página de ayuda del panel]
title: Rotar la clave de una aplicación
audiencias: [AUD-ADM-APP]       # acceso: lo lee el servidor; AdminRaiz entra por la jerarquía
audience: [persona-usuaria]     # orientación: no protege
topic: claves
traces: [CU-nnnn@1.2]
```

Sin `audiencias`, la página no se entrega a nadie (*deny by default*); hoy la prueba ya falla en ese caso
(`PAR/Web/HelpCatalog.cs:111-112`). La vista «matriz audiencia × página» que pidió la presidencia es **derivada**
(clase D) del registro y del frontmatter: no se escribe a mano, para no tener dos fuentes del acceso.

### 5.3 Quién decide

| Acto | Clase | Motivo |
| --- | --- | --- |
| Crear una audiencia, ampliar sus roles, su nivel o la jerarquía | H, con reserva automática en G4 | Irreversible en los hechos (CA3-10) |
| Asignar una página a una audiencia más amplia que la que tenía | H, con reserva | Igual |
| Restringir (quitar una audiencia, subir el nivel) | P | Reversible y del lado seguro |
| Exponer la documentación de la API (`AUD-DEV` a `publico`) | H | `F300` §6.4, con la ficha de CA3-09 |
| Conceder `restringido` a una persona concreta | H, en el producto | No es del repo: es una concesión auditada (CA3-11) |

### 5.4 Controles

Los de `docs-guard` se evalúan contra la regla de bloqueo de cinco condiciones (`K:154-163`). Todos son deterministas,
sin red, y el defecto lo introduce el mismo pull request; bloquean cuando su línea de base es 0 y tienen su par.

| Id | Control | Dónde | Rojo cuando | Par rojo/verde | Bloquea |
| --- | --- | --- | --- | --- | --- |
| AC-1 | `acceso-declarado` | `docs-guard` (esquema) | Una página de producto no declara `audiencias`, o declara un ID fuera del registro | Página sin `audiencias` / con `[AUD-ADM-APP]` | Sí, con línea de base 0 |
| AC-2 | `cruce-de-acceso` | `docs-guard` | Hay un enlace de P a T con lectores(P) ⊄ lectores(T), con lectores = roles expandidos × alcance × superficie | `AdminApp` → página `AdminRaiz` / `AdminRaiz` → página `AdminApp` | Sí |
| AC-3 | `indice-sin-fuga` | `docs-guard`, con sitio o con salida del build | Un artefacto de nivel N (sitio, `llms.txt`, mapa, índice de búsqueda) contiene una página de nivel más restrictivo | `llms.txt` público con una página `producto` / sin ella | Sí, si hay build; si no, no aplica |
| AC-4 | `paquete-sin-fuga` | `docs-guard` sobre el proyecto de la superficie instalable (globs de `EmbeddedResource` o `MauiAsset`) | El paquete incluye una página que no es `publico` | Glob que incluye `Ayuda/**` / glob que incluye sólo `Ayuda/publico/**` | Sí |
| AC-5 | `ampliacion-de-acceso` | Guarda de merge (G4), no `docs-guard` | El diff amplía `audiencias` de una página, o un rol, nivel o jerarquía del registro | Diff que agrega `AdminApp` / diff que lo quita | Deja reserva: decide una persona |
| AC-6 | `valores-de-alcance` | `docs-guard` | Aparece un valor de la lista privada (aplicaciones, clientes) en la documentación | — | **Avisa**: tiene falsos positivos (falla la condición 5) |
| PP-1 | Matriz de entrega | Pruebas del producto | Para cada audiencia × canal (página, `.md`, `llms.txt`, ayuda de campo, búsqueda, asistente) × página, el estado no es el esperado, o un 404 por acceso difiere de uno por inexistencia en algo más que la URL | — | La CI del producto |
| PP-2 | Cruce de alcance en ejecución | Pruebas del producto | El administrador de A recibe algo de B cambiando el identificador | — | Ídem |
| PP-3 | Caché | Pruebas del producto | Una respuesta filtrada por audiencia no lleva `Cache-Control: private` o `no-store` y `Vary` por la sesión | — | Ídem |
| PP-4 | Asistente | Pruebas del producto | El asistente de una audiencia recupera el marcador sembrado en una página de otra | — | Ídem |

### 5.5 Riesgos de la propuesta

- **Indirección**: cambiar una fila del registro abre o cierra muchas páginas a la vez. A favor: se revisa en un lugar.
  En contra: el radio del error es grande. Por eso AC-5 sobre el registro.
- **Falsa sensación**: AC-1 a AC-4 prueban declaraciones; sólo PP-1 a PP-4 prueban la entrega. Un cuerpo que tenga
  los primeros sin los segundos repite el «control declarado y no ejercido» (`MEP` §3.3, «Descripción o control»).
- **Costo**: un campo nuevo por página y un archivo de registro; el validador ya existe en la prueba
  (`PAR/Web/HelpCatalog.cs:104-122`) y se generaliza.

## 6. Puntuación de la hipótesis y de las alternativas

Escala 1–5 (5 es mejor); sin pesos, que son de los analistas. **[criterio propio]** en cada celda; el motivo, debajo.

| Criterio | H: matriz de la presidencia (`F300` §6) | S-1: H con las cuatro enmiendas de §5.2 y los controles de §5.4 | S-2: sólo `roles` con jerarquía y cruce de rol | S-3: delegar el acceso en una plataforma de portal (`groups`, `rbac`) |
| --- | --- | --- | --- | --- |
| C1 No divulgación efectiva | 3 | 5 | 2 | 4 |
| C2 Verificable en CI y en pruebas | 3 | 5 | 4 | 2 |
| C3 Costo de adopción | 3 | 3 | 5 | 2 |
| C4 Cumple el pedido literal (E-01 a E-05) | 5 | 5 | 2 | 3 |
| C5 Reversibilidad | 4 | 4 | 5 | 2 |
| C6 Carga para quien escribe | 3 | 4 | 5 | 4 |

- **H.** Cubre todas las dimensiones que pidió el PO (C4 = 5). Pierde en C1 y C2 por tres cosas: lleva valores de
  alcance al repo (CA3-05), pone al agente como fila (CA3-04) y, si la tabla se escribe a mano además del frontmatter,
  hay dos fuentes del acceso. No dice qué control prueba la entrega.
- **S-1.** Lo mismo que H en cobertura, con una sola fuente del acceso, la vista derivada y pruebas de entrega. Cuesta
  igual que H (un registro, un campo, cuatro controles).
- **S-2.** La más chica y reversible, pero no cubre alcance, superficie ni API restringida (E-03 a E-05): no cumple el
  pedido. Sirve como primer paso si el orden de §10 lo pide.
- **S-3.** Mintlify y Redocly hacen cumplir el acceso por página en su portal (404 y 403, respectivamente), lo que da C1
  alto para el portal. Pero no cubre la ayuda dentro del producto ni la móvil, su comportamiento no se prueba en la
  CI del proyecto (C2) y ata el acceso a un proveedor (C5). Útil como canal del portal de desarrolladores, no como
  modelo.

**Cadena de consecuencias de S-1** (`Cadena-De-Consecuencias` §2). *Dónde cae*: en quien escribe (un campo más por
página) y en el producto (cuatro pruebas). *Cuánto pesa*: la prueba ya tiene el validador de cruce en 19 líneas
(`PAR/Web/HelpCatalog.cs:104-122`); el resto, sin medir. *Qué pierde la alternativa*: S-2 pierde el alcance y la API;
S-3 pierde la ayuda en el producto. *Reversible*: agregar el campo y los controles es reversible; lo que no lo es es
entregar de más, que S-1 ataca con AC-5. Condición para revisar: si en dos productos medidos el registro tiene una
sola audiencia por superficie, la indirección sobra y se vuelve a `roles` por página.

## 7. Ensayo corrido

**Qué.** La prueba de ayuda por rol, copiada a `{dir-de-trabajo}`, compilada y corrida en un contenedor
`mcr.microsoft.com/dotnet/sdk:10.0` con `ASPNETCORE_ENVIRONMENT=Production`; sondas con `curl` y una cookie de la
sesión `Student` obtenida en `/entrar/Student`. Fecha: 2026-11-01, hora local (el reloj del contenedor dio
`2026-11-02T00:22Z`). El contenedor se borró al terminar.

```text
[Salida registrada: corrida del 2026-11-01; recortada a lo que importa]
1 GET /ayuda/llms.txt (Student)                 → 200; cabeceras: Content-Type, Date, Server, Transfer-Encoding (sin Cache-Control ni Vary)
  cuerpo: cuatro páginas (dos comunes, dos de alumno); ninguna de administrador
2 GET /ayuda/administrador/gobernar-las-cuentas.md (Student) → 404
3 GET /ayuda/administrador/gobernar-las-cuentas    (Student) → 404, 1197 bytes, «Gobernar» aparece 0 veces
4 GET /ayuda/administrador/no-existe               (Student) → 404, 1175 bytes
  diff de 3 y 4: sólo las dos líneas del selector de idioma que repiten la URL pedida (22 bytes = diferencia de largo de la ruta)
5 GET /ayuda/alumno/enviar-un-trabajo.md (Student) → 200; sin Cache-Control ni Vary
6 GET /ayuda/comun/ingresar (Student)             → «Visible para</dt><dd>Student, Administrator»
7 GET /ayuda/llms.txt sin sesión → 302; GET /ayuda/alumno/..%2Fadministrador%2Fgobernar-las-cuentas.md (Student) → 404
```

**Lectura.** Sondas 2 a 4 y 7: el acceso se cumple y el 404 no distingue (CA3-13). Sondas 1 y 5: CA3-02. Sonda 6:
CA3-03. La sonda 7 sin sesión da 302 al ingreso y no el 401 que escribe el middleware (`PAR/Web/Program.cs:41`):
el desafío de la cookie lo convierte en redirección antes; no filtra nada y coincide con el README (`/ayuda` sin
sesión, 302).

## 8. Fuentes externas

Todas consultadas el 2026-11-01 con WebFetch o WebSearch.

| Fuente | Qué dice, en lo que se usa | URL |
| --- | --- | --- |
| Hu, V. C., Ferraiolo, D., Kuhn, R., Schnitzer, A., Sandlin, K., Miller, R. y Scarfone, K. (2014, act. 2019-08-02). *Guide to Attribute Based Access Control (ABAC) Definition and Considerations*, NIST SP 800-162 | Autorización por atributos del sujeto, del objeto, de la operación y, a veces, del entorno, contra políticas | https://csrc.nist.gov/pubs/sp/800/162/upd2/final |
| NIST CSRC, *Role Based Access Control* (página del proyecto) | Modelo NIST adoptado como ANSI/INCITS 359-2004, revisado como INCITS 359-2012; Sandhu, Ferraiolo y Kuhn (2000), *The NIST Model for Role-Based Access Control: Towards a Unified Standard*, 5th ACM Workshop on RBAC | https://csrc.nist.gov/projects/role-based-access-control |
| MITRE, CWE-200 | «exposes sensitive information to an actor that is not explicitly authorized»; hijos 203, 209, 538, entre otros | https://cwe.mitre.org/data/definitions/200.html |
| MITRE, CWE-204 | *Observable Response Discrepancy* | https://cwe.mitre.org/data/definitions/204.html |
| MITRE, CWE-209 | Mensaje de error con información sensible | https://cwe.mitre.org/data/definitions/209.html |
| MITRE, CWE-425 | *Direct Request* («Forced Browsing») | https://cwe.mitre.org/data/definitions/425.html |
| MITRE, CWE-524 | Caché con información sensible legible fuera de la esfera de control | https://cwe.mitre.org/data/definitions/524.html |
| MITRE, CWE-639 | *Authorization Bypass Through User-Controlled Key* | https://cwe.mitre.org/data/definitions/639.html |
| MITRE, CWE-1295 | *Debug Messages Revealing Unnecessary Information*; miembro de la vista de diseño de hardware, con ejemplos de interfaces de depuración. **Marginal para este objeto**: no se funda nada en ella | https://cwe.mitre.org/data/definitions/1295.html |
| OWASP Top 10:2025, A01 Broken Access Control | Denegar por defecto salvo lo público; control sólo en el servidor; navegación forzada; registrar las fallas; mapea CWE-200 y CWE-425 | https://top10.owasp.org/2025/A01_2025-Broken_Access_Control |
| OWASP API Security Top 10 2023, API9 Improper Inventory Management | «Make API documentation available only to those authorized to use the API»; generar la documentación en la CI | https://api-security.owasp.org/editions/2023/en/0xa9-improper-inventory-management |
| OWASP Cheat Sheet Series, *Authorization* | Mínimo privilegio horizontal y vertical; denegar por defecto; validar en cada pedido; preferir ABAC y ReBAC; pruebas unitarias y de integración de la autorización; registrar | https://cheatsheetseries.owasp.org/cheatsheets/Authorization_Cheat_Sheet.html |
| OWASP Cheat Sheet Series, *Multi-Tenant Security* | Identificador de inquilino del cliente sólo como selector; contexto atado a identidad verificada; probar la denegación entre inquilinos; inquilino en la clave de caché; inquilino verificado en la auditoría | https://cheatsheetseries.owasp.org/cheatsheets/Multi_Tenant_Security_Cheat_Sheet.html |
| OWASP Cheat Sheet Series, *Input Validation* | «Client-side validation is bypassable»; validar en el servidor | https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html |
| OWASP GenAI, LLM02:2025 *Sensitive Information Disclosure* | Mínimo privilegio sobre los datos; restringir las fuentes del modelo | https://genai.owasp.org/llmrisk/llm022025-sensitive-information-disclosure/ |
| OWASP GenAI, LLM06:2025 *Excessive Agency* | Extensiones en el contexto del usuario, permisos mínimos, autorización en el sistema de abajo | https://genai.owasp.org/llmrisk/llm062025-excessive-agency/ |
| OWASP GenAI, LLM08:2025 *Vector and Embedding Weaknesses* | Almacenes con control de acceso fino y particionados; fuga entre contextos multiinquilino; instrucciones escondidas en documentos | https://genai.owasp.org/llmrisk/llm082025-vector-and-embedding-weaknesses/ |
| OWASP MAS, MASWE-0004 | Título: «Sensitive Data Hardcoded in the App Package». **Sólo el título**: el cuerpo de la página no se pudo leer | https://mas.owasp.org/MASWE/MASVS-STORAGE/MASWE-0004/ |
| IETF, RFC 9111 *HTTP Caching* (2022) | §5.2.2.7 `private`: una caché compartida no debe guardar la respuesta; §3.5: no reutilizar una respuesta a un pedido con `Authorization` salvo directiva explícita | https://www.rfc-editor.org/rfc/rfc9111.html |
| Microsoft Learn, *Understand scope for Azure RBAC* (act. 2026-02-13) | Alcance = conjunto de recursos; cuatro niveles; herencia de padre a hijo | https://learn.microsoft.com/en-us/azure/role-based-access-control/scope-overview |
| Microsoft Learn, *Generate OpenAPI documents* (ASP.NET Core, act. 2026-10-29) | El punto del OpenAPI no autoriza por defecto; `MapOpenApi().RequireAuthorization("ApiTesterPolicy")`; ejemplo que lo mapea sólo en desarrollo | https://learn.microsoft.com/en-us/aspnet/core/fundamentals/openapi/aspnetcore-openapi |
| Microsoft Learn, *Data, Privacy, and Security for Microsoft Copilot* (act. 2026-10-31) | Sólo muestra datos que el usuario puede ver; el índice semántico respeta el límite de identidad | https://learn.microsoft.com/en-us/copilot/microsoft-365/microsoft-365-copilot-privacy |
| Mintlify, *Authentication and personalization* | `groups` en el frontmatter; 404 sin grupo; la visibilidad sólo oculta en el navegador; con autenticación parcial, `llms.txt` y mapa reflejan sólo lo público | https://www.mintlify.com/docs/authentication-personalization/overview |
| Redocly, *RBAC* y *RBAC for pages* | `rbac` en `redocly.yaml` y en el frontmatter de la página; sin el equipo, 403; las páginas ocultas no generan enlace en la barra | https://redocly.com/docs/realm/access/rbac ; https://redocly.com/docs/realm/access/page-permissions |
| Spotify for Backstage, *RBAC plugin* | TechDocs no registra permisos propios; su visibilidad sale de los permisos del catálogo sobre la entidad | https://backstage.spotify.com/docs/plugins/rbac.md |
| GitBook, *Enabling adaptive content* | *Claims* del visitante; los que llegan por URL, cookie sin firmar o *feature flags* se declaran `unsigned` | https://gitbook.com/docs/publishing-documentation/adaptive-content/enabling-adaptive-content |
| GitHub Docs, *Troubleshooting the REST API* | 404 en lugar de 403 «to avoid confirming the existence of private repositories» | https://docs.github.com/en/rest/using-the-rest-api/troubleshooting-the-rest-api |
| Pang, R. et al. (2019). *Zanzibar: Google's Consistent, Global Authorization System*. USENIX ATC 19 | Sistema global para guardar y evaluar listas de control de acceso (antecedente de ReBAC) | https://www.usenix.org/conference/atc19/presentation/pang |
| Howard, J. (2024-09-03, v2 modificada 2026-08-10). *The /llms.txt file* | No trata acceso, autenticación ni contenido privado | https://llmstxt.org/ |

## 9. Lo que revisé y está bien

1. **El 404 no distingue** una página restringida de una inexistente (§7, sondas 2 a 4): cumple lo que promete
   `SDEI/TEM-05-Ayuda-Al-Usuario-Final.md:106-107`.
2. **Una traducción no amplía el acceso**: lo decide la página fuente (`PAR/Web/HelpCatalog.cs:30`, `:66`) y el
   esquema no deja que una traducción declare `roles` (`tools/docs-guard/esquemas/ayuda.schema.json:16`).
3. **Un solo filtro para todos los canales** de la ayuda (página, `.md`, `llms.txt`: `PAR/Web/Program.cs:34-55`), y la
   ayuda contextual no dibuja nada si el rol no alcanza (`PAR/Web/Components/AyudaContextual.razor:3-4`).

## 10. Qué rehacer: tabla de §5.3

| Pieza | Cambio | Motivo | Costo | Orden |
| --- | --- | --- | --- | --- |
| `SDEI/00-Marco.md` §2.5 | La fila «Audiencias» queda como orientación; se suman las filas «Niveles de acceso activos» y «Punto de aplicación por nivel». «Confidencialidad» (l. 112) pasa a remitir a ellas | CA3-01, A-06 | Bajo | 2 |
| `SDEI/00-Marco.md` §4 | Ninguno en actores; una línea: «el sujeto de una decisión de acceso no es un actor» | A-01 | Bajo | 2 |
| `SDEI/TEM-04` | §3.5 suma: el agente hereda el acceso de su usuario; RAG e índices por nivel y alcance; `llms.txt` público sólo con páginas `publico` | CA3-04, A-10 | Medio | 3 |
| `SDEI/TEM-05` | Rol → audiencia con acceso; niveles y puntos de aplicación; jerarquía expandida; alcance por tipo; paquete móvil; caché; ayuda de campo con los mismos atributos; «Visible para» fuera de la vista del lector | A-05, A-06, A-08, CA3-02, CA3-03, CA3-06 | Alto | 3 |
| `SDEI/TEM-06` | AC-1 a AC-4 y AC-6 en la tabla de controles, con su par; AC-5 como condición de reserva de G4; PP-1 a PP-4 como pruebas del producto que la ficha exige declarar | §5.4 | Medio (herramienta: expediente aparte) | 4 |
| `SDEI/99-Anexos/Glosario.md` | Audiencia, acceso, nivel de acceso, alcance, punto de aplicación, sujeto; «rol» remite a audiencia | §1, §5.1 | Bajo | 1 |
| `SDEI/Examples/` | `Prueba-Ayuda-Por-Rol`: jerarquía de tres roles, dos aplicaciones, `Cache-Control` privado, sin «Visible para», un formulario con ayuda de campo, un OpenAPI con `RequireAuthorization`, pruebas PP-1 a PP-4 | A-15, B-12 | Alto | 5 |
| `K` D-01 | El inventario de autorización ya detecta roles (`K:262`); suma alcance (autorización por recurso) y superficies instalables | A-08 | Bajo | 2 |
| `K` D-13 | Queda para la forma de la ayuda (ninguna, única, por audiencia, por idioma); el acceso pasa a D-18 | A-12 | Bajo | 2 |
| `K` D-18 (nueva) | «Audiencias y acceso»: registro (§5.2), niveles con punto de aplicación, quién decide (§5.3), API expuesta como H con la ficha de CA3-09 | Pedido E-01 a E-05 | Medio | 2 |
| `K` §2.3 | La fila «Audiencias» suma «niveles activos» por escenario | A-02 | Bajo | 2 |
| `K` A-01 | Una fila D-18 en §2; en §4, las H de §5.3; el barrido de §3.6 también busca valores de alcance | CA3-05 | Bajo | 2 |
| `K` A-03 | El esquema suma `audiencias` (IDs del registro) separado de `audience`; artefacto nuevo: el registro de audiencias | CA3-01 | Medio | 2 |
| Libro (`F099` §5.2) | Parte III: cap. 7 suma «el agente hereda el acceso»; cap. 8 se apoya en el capítulo nuevo «Audiencias y acceso» (definición, dimensiones, niveles, punto de aplicación, alcance, API restringida, pruebas de entrega), antes del cap. 7. Cap. 14 suma el ensayo de §7 | A-13 | Medio | 6 |
| Oráculos y criterio de caso (`F204`) | Re-sellar **sólo** los oráculos de los casos con roles o API (el panel con roles y el de `{servicio-privado}`): una fila D-18 con los hechos de acceso medidos (roles, si hay alcance por aplicación, superficie instalable, si el OpenAPI se publica). El criterio de caso no cambia; suma un ítem de barrido: A-01 no lleva valores de alcance | A-14, CA3-05 | Medio | Después de `F399` y antes de sellar la ronda 3 |

## 11. Solicitudes de convocatoria y dudas para el PO

- **Convocatoria**: ninguna. La accesibilidad (B-09) y la redacción del microtexto son de CA-8; las señalo sin dictaminar.
- **Dudas para el PO** (por la presidencia, `MCT` si hace falta; ninguna traba este informe):
  1. En `{servicio-privado}`, ¿el administrador raíz necesita leer la ayuda «por aplicación» de cada aplicación, o
     sólo la suya? Decide si la herencia vertical alcanza al contenido por aplicación (A-05, punto 4).
  2. ¿El SDK para integradores se publica en un feed público? Si sí, su superficie ya es pública y la restricción de
     la documentación de desarrollador cubre sólo lo que no está en el paquete (CA3-09).

## 12. Excepciones a conocimientos

Ninguna. No propongo dejar de seguir ninguna convención que rige.

## 13. Lo no verificado

- INCITS 359 en su texto (jerarquías generales y limitadas): no reabierto; la página de NIST sólo confirma la norma
  y que el software maneja las jerarquías.
- MASWE-0004: sólo el título; la descripción no se pudo leer en la página consultada.
- Pendo: si la segmentación impide la entrega del contenido o sólo dirige qué se muestra: **sin verificar**.
- Redocly: si su búsqueda y su `llms.txt` respetan `rbac`: la página consultada no lo dice.
- GitBook: no encontré una advertencia explícita sobre usar contenido adaptativo para material confidencial; lo de
  §4, A-06, se limita a lo que la página dice.
- El costo en líneas de AC-1 a AC-4: sin medir.

## 14. Mensajes de otras sesiones

Ninguno durante la redacción.

## 15. Barrido de lo privado de este folio

Se buscaron nombres de máquina, rutas absolutas del sistema de archivos, usuarios y el nombre real del servicio
privado. El servicio va como `{servicio-privado}`; el directorio de trabajo, como `{dir-de-trabajo}`; los repositorios,
por alias (`SDEI/`, `PAR/`, `K`, `KB/`). Lab-Documentos y Lab-Geometria son públicos y se nombran. Comando corrido el
2026-11-01 sobre este archivo: `grep -n -i -E` con rutas absolutas del equipo, nombres de máquina, el nombre real del
servicio privado y del proveedor citado en `SDEI/TEM-04`, el usuario, `127.0.0.1` y `192.168`; salida vacía, `rc=1`
(0 coincidencias).
