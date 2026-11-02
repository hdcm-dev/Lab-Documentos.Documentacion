---
doc_id: EXP0003-F370
doc_type: informe
title: Informe de la comisión CA-7 (agentes y LLM como audiencia) — el agente como lector que hereda la audiencia de su usuario, el filtro único para página, `.md`, `llms.txt` y MCP, y la ayuda de formulario como superficie de inyección
status: vigente
origin: agent
confidence: alta en las citas al cuerpo SDEI (00171bd), a K 1.2 y a F300, leídas y medidas con número de línea el 2026-11-02; alta en las fuentes externas marcadas «verificada» (abiertas el 2026-11-02); media en las propuestas, rotuladas [criterio propio] donde no salen de una fuente
owner: comisión CA-7 «agentes y LLM como audiencia» del ciclo 3 de la mesa de la reedición DocsAsCode (expediente 0003)
last_review: 2026-11-02
audience: [presidencia, refutador, análisis de decisiones, jurado del ciclo 3, editores, PO]
traces: [EXP0003-F300, EXP0003-F099, EXP0003-F204, TEM-SDEI-04, TEM-SDEI-05, TEM-SDEI-06, MARCO-SDEI]
---

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-02 (la providencia es del 2026-11-01; la redacción se retomó tras un corte de energía) |
| Autor | Comisión CA-7. Trabajó a ciegas: no leyó F310–F369 |
| Corrige | — |

**Convención de citas.** Como en `F300`: `SDEI/` = cuerpo en `00171bd`; `K` = conocimiento 1.2; las líneas de `K`
se midieron hoy (D-13 está en la l. 288, no en la 274 que cita `F300` §4: el archivo creció entre mediciones).
Fuentes externas: «verificada» = abierta el 2026-11-02 con lectura del pasaje citado.

## Índice

1. [Tesis de la comisión](#1-tesis-de-la-comisión)
2. [Fuentes verificadas hoy](#2-fuentes-verificadas-hoy)
3. [Respuestas a cargo: A-04, A-10, A-11, B-10](#3-respuestas-a-cargo)
4. [Respuestas desde la especialidad al resto de A-nn y B-nn](#4-respuestas-desde-la-especialidad-al-resto)
5. [Puntuación de la hipótesis y alternativas](#5-puntuación-de-la-hipótesis-y-alternativas)
6. [Riesgos](#6-riesgos)
7. [Lo que revisé y está bien](#7-lo-que-revisé-y-está-bien)
8. [Tabla «pieza → cambio → motivo → costo → orden»](#8-tabla-pieza--cambio--motivo--costo--orden)
9. [Lo no verificado e incidencias](#9-lo-no-verificado-e-incidencias)
10. [Barrido de lo privado](#10-barrido-de-lo-privado)

## 1. Tesis de la comisión

1. **El agente no es una audiencia: es un lector que actúa por una audiencia.** «Humano / agente» es la dimensión
   *lector* de cada audiencia (A-04). Un agente de código del equipo pertenece a la audiencia «desarrollo interno»;
   el asistente del administrador de una aplicación de `{servicio-privado}` pertenece a «administrador de aplicación,
   alcance = esa aplicación». No existe una audiencia «agente» con su propio nivel de acceso.
2. **El agente hereda el alcance de su usuario y nunca lo amplía.** Es la regla de OWASP LLM06 («executed … in the
   context of that specific user») y la de Microsoft 365 Copilot («only surfaces organizational data to which
   individual users have at least view permissions»). Traducido al sistema documentador: cada canal para agentes
   (`.md` crudo, `llms.txt`, servidor MCP, índice embebido para un asistente) pasa por **el mismo filtro y en el
   mismo punto de cumplimiento** que la página HTML, ya generalizado de rol a audiencia (rol × alcance × acceso).
3. **`llms.txt` y `AGENTS.md` no son control de acceso.** llmstxt.org no trata autenticación; `AGENTS.md` es un
   archivo de instrucciones. El acceso se hace cumplir en el servidor (o en el repositorio privado), y el `llms.txt`
   es una **salida más del filtro**, uno por audiencia, nunca un índice global.
4. **El texto de ayuda de un formulario que lee un asistente es contenido no confiable para ese asistente.** Si el
   asistente además ve datos privados y puede comunicarse hacia afuera, se cumple la «lethal trifecta» (Willison,
   2025). El control documental (AI-1…AI-5 de `TEM-04` §3.4) cubre la fuente; el resto es del producto.

## 2. Fuentes verificadas hoy

| Fuente | Qué dice (en lo que importa) | URL | Estado |
| --- | --- | --- | --- |
| OWASP GenAI Security Project, *Top 10 for LLM Applications 2025* | LLM01 Prompt Injection; LLM02 Sensitive Information Disclosure; LLM06 Excessive Agency; LLM07 System Prompt Leakage; LLM08 Vector and Embedding Weaknesses | https://genai.owasp.org/llm-top-10/ | verificada |
| OWASP, *LLM06:2025 Excessive Agency* | Ejecutar en el contexto del usuario; permisos mínimos; «implement authorization in downstream systems rather than relying on an LLM to decide» (mediación completa) | https://genai.owasp.org/llmrisk/llm062025-excessive-agency/ | verificada |
| Model Context Protocol, *Authorization* (rev. 2025-06-18) | Autorización opcional; en HTTP: OAuth 2.1, RFC 9728 obligatorio, RFC 8707 `resource` obligatorio, validación de audiencia del token; «MCP servers MUST NOT accept or transit any other tokens»; 403 por alcance insuficiente | https://modelcontextprotocol.io/specification/2025-06-18/basic/authorization | verificada (hay revisiones posteriores de la especificación: no se leyeron, ver §9) |
| llmstxt.org | Howard, 2024-09-03 (modificada 2026-08-10); raíz o subcamino, «el más específico» gana; `.md` en la misma URL; descubrimiento por `rel="alternate" type="text/markdown"`; no trata control de acceso | https://llmstxt.org/ | verificada |
| AGENTS.md | «README for agents», sin campos obligatorios; custodia de la Agentic AI Foundation (Linux Foundation); más de 60 000 proyectos; «the closest AGENTS.md to the edited file wins»; el pedido del usuario en el chat prevalece | https://agents.md/ | verificada |
| Willison, S. (2025-06-16), *The lethal trifecta for AI agents* | Acceso a datos privados + exposición a contenido no confiable + capacidad de comunicar hacia afuera = exfiltración | https://simonwillison.net/2025/Jun/16/the-lethal-trifecta/ | verificada |
| Microsoft Learn, *Data, Privacy, and Security for Microsoft Copilot* (ms.date 2026-07-09) | «Semantic Index honors the user identity-based access boundary»; clasificadores de inyección cruzada (XPIA) que «may not be available in all … scenarios» | https://learn.microsoft.com/en-us/copilot/microsoft-365/microsoft-365-copilot-privacy | verificada (caso comercial: recuperación recortada por permisos) |

## 3. Respuestas a cargo

### A-04 Doble audiencia

**Estado del arte.** La industria separa dos ejes que `TEM-04` mezcla bajo un nombre: el **formato** para máquina
(`.md`, `llms.txt`, frontmatter, MCP) y la **autoridad** del lector. llmstxt.org sólo resuelve el primero;
MCP y OWASP LLM06 resuelven el segundo atando al agente a la identidad y al alcance del usuario.

**Qué cubre SDEI.** `TEM-04` define bien los canales (l. 43-46), que lo leído es dato y no instrucción (l. 60-62),
y la tabla por escenario ya distingue «agente de código» de «asistente de la persona usuaria» (l. 85-90, 191-194).
§3.5 (l. 196-201) ya aplica el filtro de rol a los canales para agentes. **No cubre**: que el asistente pertenece a
una audiencia concreta; MCP no aparece en todo el cuerpo (búsqueda hoy: 0 coincidencias en `TEM-04`/`TEM-06`).

**Propuesta.** `TEM-04` queda como tema propio **de canal y de defensa**, renombrado «Lectores humanos y agentes»
[criterio propio]; la dimensión `lector: [humano, agente]` entra en cada fila de la matriz de audiencias. Capítulo 7
del libro: deja de presentar al agente como «segunda audiencia» y lo presenta como lector que hereda audiencia;
suma una sección MCP (servidor de documentación con OAuth 2.1 y el mismo filtro). En el frontmatter, `audience`
deja de mezclar audiencias con lectores (hoy `TEM-04` l. 11: `[humano, agente, estudiante, …]`): se separan
`audience:` (vocabulario cerrado de la matriz) y `reader:` (`humano`, `agente`), con `reader` por defecto ambos.

### A-10 Agente por audiencia

**Estado del arte.** Tres mecanismos en uso: (a) `llms.txt` por subcamino (llmstxt.org admite `/docs/llms.txt`;
gana el más específico); (b) recuperación recortada por permisos en el momento de la consulta (Microsoft 365
Copilot, verificada); (c) servidor MCP como recurso protegido OAuth 2.1 con validación de audiencia del token y
prohibición de reenviar el token (verificada).

**Qué cubre SDEI.** La prueba de concepto ya sirve página, `.md` y `llms.txt` desde un catálogo con el mismo filtro,
con 404 al rol ajeno (`TEM-05` l. 160-185). Falta: alcance (aplicación/inquilino), nivel de acceso, y el caso del
asistente embebido o MCP.

**Propuesta.**
1. **Regla de filtro único** [criterio propio, deriva de OWASP LLM06 «complete mediation»]: existe una sola función
   `Visible(audiencia_sesión, pieza)` en el servidor; todos los canales (HTML, `.md`, `llms.txt`, búsqueda,
   respuesta MCP, contexto que se le pasa a un asistente) la llaman. Ningún canal tiene su propio filtro.
2. **`llms.txt` generado por sesión**, no publicado estático, cuando el nivel de acceso no es público; para lo
   público, un `llms.txt` estático por audiencia pública.
3. **404, no 403**, para la pieza fuera de audiencia (no revela existencia, CWE-200), igual que la prueba de
   concepto; el 403 queda para el MCP cuando el *scope* no alcanza, como dice la especificación.
4. **Asistente embebido** (el del panel o de la app): recibe un token de la sesión del usuario con su audiencia, no
   una credencial de servicio; recupera documentación con ese token. **Prohibido** precargar en el prompt de sistema
   documentación de otras audiencias «para que sepa más» (OWASP LLM07: el prompt de sistema se filtra).
5. **Índices vectoriales**: un índice por nivel de acceso, o metadatos de audiencia en cada fragmento filtrados
   **antes** de la búsqueda (OWASP LLM08). Un índice común filtrado sólo en la respuesta no cumple.

**Ejemplo** (`{servicio-privado}`): el asistente del administrador de la aplicación A pregunta «¿cómo roto la
clave del SDK?»; el filtro con `alcance=A` entrega la página de la app A y no la del raíz («rotación global de
claves»), ni el `llms.txt` lista la del raíz ni la de la app B.

### A-11 Controles verificables en CI (los de mi especialidad)

| Id propuesto | Control | Condición de bloqueo | Par rojo/verde |
| --- | --- | --- | --- |
| AG-1 | Todo `llms.txt` y todo índice para agentes del build se generan de la matriz; ninguno es escrito a mano | Bloquea si un `llms.txt` del árbol publicado no tiene la marca de generación | Rojo: `llms.txt` editado a mano; verde: regenerado |
| AG-2 | Ningún `llms.txt` público lista una pieza de acceso ≠ `publico` | Bloquea | Rojo: fixture con pieza `restringido` en el índice público |
| AG-3 | Equivalencia de canales: para cada audiencia de la matriz, el conjunto de piezas de HTML = `.md` = `llms.txt` (= recursos MCP si los hay) | Bloquea | Rojo: el `.md` crudo de una pieza de admin servido a usuario |
| AG-4 | Las piezas `restringido`/`interno` no tienen URL en el sitio estático público ni en el *sitemap* | Bloquea | Rojo: pieza interna en `sitemap.xml` |
| AG-5 | AI-1…AI-5 corren también sobre los recursos de microtexto (`.resx`, JSON de esquema, `ui:help`) | AI-1, AI-2, AI-5 bloquean; AI-3 avisa, como hoy (`TEM-06` l. 92) | Rojo: comentario oculto en un `ErrorMessage` |
| AG-6 | `AGENTS.md` no contiene contenido de nivel `restringido` (sólo apunta) | Avisa | — |

AG-3 y AG-4 son pruebas **del producto** cuando el filtro está en el servidor (corren contra el servidor levantado
con dos sesiones); `docs-guard` sólo puede verificar AG-1, AG-2, AG-5 y AG-6 sobre el build. Ninguna de estas
pruebas demuestra que el asistente no filtre: demuestran que **no tiene** lo que podría filtrar.

### B-10 Agente que asiste en el formulario

**Estado del arte.** Asistentes en producto que guían el llenado existen (Copilot en Microsoft 365, verificada como
caso de recuperación con permisos); la defensa reconocida por OWASP (LLM01) es reducir el poder, no confiar en
clasificadores (Microsoft mismo dice que sus clasificadores XPIA «may not be available in all … scenarios").

**Riesgos y controles.**
- *Inyección por texto de ayuda* (LLM01 indirecta): el microtexto entra por PR como cualquier pieza → AG-5 lo
  cubre en la fuente. Lo que no cubre: **valores que el usuario cargó en otros campos** (p. ej., el nombre de una
  campaña con una orden escondida) que el asistente lee después. Eso es del producto: marcar los datos del usuario
  como no confiables y no darle al asistente acción de envío sin confirmación humana.
- *Fuga de ayuda de otra audiencia* (LLM02): cubierta por la regla de filtro único (A-10.1).
- *Trifecta*: un asistente de formulario que ve datos privados, lee texto cargado por terceros y puede llamar a
  URLs o enviar notificaciones (caso `{servicio-privado}`) reúne las tres patas. Regla [criterio propio]: el
  asistente de formulario **sugiere valores, no envía**; el envío lo hace la persona.
- *Desfase*: el asistente que explica una regla con ayuda vieja da información errónea (LLM09). Lo cubre el
  control de desfase regla↔texto del eje B (comisiones CA-4/CA-8); el asistente debe citar `ID@versión`.

**Propuesta.** El asistente usa **la misma pieza de microtexto** (no un texto aparte «para la IA»), recuperada con
el token de la sesión, y cita la traza. Campo en el registro: `assistant_use: permitido | no` por pieza (una persona
lo decide: clase H, porque autoriza que el texto entre en un contexto con capacidad de acción).

## 4. Respuestas desde la especialidad al resto

| Pregunta | Aporte de CA-7 |
| --- | --- |
| A-01 | Distinguir **audiencia** (grupo destinatario con alcance y acceso) de **lector** (humano o agente, que actúa por una audiencia) y de **actor** (`Glosario` l. 43). Entrada nueva de glosario «Lector». |
| A-02 | Dimensiones con efecto en agentes: acceso (obligatoria siempre que haya algo no público), alcance, lector. `lector` es ortogonal y derivable (por defecto ambos). |
| A-03 | Sumar, no reemplazar: la fila del Marco l. 106 lista «agente» como audiencia en los cuatro escenarios; debe pasar a la columna lector. |
| A-05 | El agente de un administrador raíz es la causa típica de fuga por resumen: si el raíz pide «armá la guía para mis administradores», el agente puede copiar páginas del raíz. Control: los artefactos generados por agente heredan `audience` más restrictiva de sus fuentes [criterio propio]. |
| A-06 | Sólo cuenta el punto de cumplimiento que el agente no puede saltear (servidor o repo privado). Ocultar en la UI no protege de un agente que pide el `.md` crudo: lo prueba AG-3. |
| A-07 | La doc de API restringida servida por MCP necesita el mismo grupo que el portal; un OpenAPI filtrado por audiencia es lo que un agente integrador consume. Decisión de exposición: clase H, coincido con la hipótesis. |
| A-08 | El cruce de alcance para agentes es el mismo control que para humanos si existe filtro único; si no, aparece en búsqueda y en índices vectoriales primero. |
| A-09 | Lo que viaja en el paquete móvil (`Marco` §2.5) es legible por cualquier agente que lo desempaque: sólo puede llevar nivel `publico` o «autenticado en el producto» no sensible. |
| A-12 | Decisión nueva en `K` (ver §5), con subcampos `lector` y `canal_agente` (ninguno · `llms.txt` estático · por sesión · MCP). |
| A-13 | Cap. 7 cambia (ver A-04); sección MCP nueva; capítulo de confidencialidad suma la trifecta. |
| A-14 | Los oráculos de la ronda 3 deberían llevar al menos una fila «el `llms.txt` de la audiencia X no lista piezas de Y»: si la resolución la acepta, se re-sellan. |
| A-15 | Extender `Prueba-Ayuda-Por-Rol` con un segundo alcance y un endpoint de recursos para agentes que use el mismo filtro; no armar otro ejemplo. |
| B-01/B-09 | La descripción accesible (`aria-describedby`) es también lo que lee un agente de navegador: una sola fuente sirve a los dos [criterio propio; no verifiqué un agente concreto que la use]. |
| B-02/B-03 | Para el agente, `ID@versión` en el recurso es lo que le permite citar; sin traza no hay forma de detectar ayuda vieja. |
| B-04 | Variante de canal de `CL-06`, no clase nueva: de lo contrario el filtro único se parte en dos. |
| B-05/B-06 | Sin aporte propio más allá de AG-5. |
| B-07/B-08 | Plataformas de guía en producto con contenido fuera del repo: su contenido no pasa por AI-1…AI-5 ni por el filtro único; si un asistente lo lee, es una fuente sin compuerta. Recomiendo que el asistente no las use como contexto. |
| B-11 | El asistente obtiene un token con *claims* de audiencia de la sesión; no se le da una clave de servicio. |
| B-12 | Agregar al ejemplo un caso rojo: cambia la regla y el asistente cita la versión vieja → el control de desfase da rojo. |

## 5. Puntuación de la hipótesis y alternativas

Escala 1–5 (5 = mejor). Criterios: C1 cumple el pedido literal; C2 seguridad frente a agentes; C3 verificable en
CI; C4 costo (5 = barato); C5 coherencia con el cuerpo.

| Opción | C1 | C2 | C3 | C4 | C5 | Nota |
| --- | --- | --- | --- | --- | --- | --- |
| H — hipótesis de la presidencia (matriz D-18 con lector y acceso, tabla en repo, cruce de alcance, API clase H, ayuda de campo en CL-06) | 5 | 3 | 4 | 3 | 4 | Le falta exigir que **todos** los canales usen el mismo filtro: con eso sube C2 a 5 |
| H+ — H más la regla de filtro único, `canal_agente` en la matriz y AG-1…AG-6 (esta comisión) | 5 | 5 | 4 | 3 | 4 | Recomendada |
| X1 — audiencia «agente» propia con acceso propio (lo que hoy sugiere el Marco l. 106) | 2 | 1 | 3 | 4 | 3 | Rechazar: el agente obtiene un alcance que su usuario no tiene |
| X2 — sin canales para agentes en lo no público (sólo HTML autenticado) | 4 | 4 | 5 | 5 | 3 | Alternativa mínima válida para quien no quiera MCP ni asistente; deja al agente leyendo HTML |

## 6. Riesgos

- **Falsa seguridad por `llms.txt`**: tomarlo como lista de permitidos. Mitigación: texto explícito en `TEM-04`.
- **Agente con credencial de servicio** en el panel (más simple de implementar): rompe todo el modelo. Debe ser
  regla del conocimiento, no recomendación.
- **Resúmenes que bajan de nivel**: un agente redacta para una audiencia con fuentes de otra (A-05).
- **MCP en evolución**: la especificación tiene revisiones posteriores a la leída; atar el texto a la revisión.
- **Sobre-ingeniería**: X2 alcanza para muchos proyectos; la matriz debe admitir `canal_agente: ninguno`.

## 7. Lo que revisé y está bien

- `TEM-04` l. 60-62: lo leído es dato, la instrucción vive en `AGENTS.md` de clase H. Coincide con AGENTS.md y OWASP.
- `TEM-04` §3.4 y `TEM-06` l. 92: la compuerta anti-inyección determinista y sin modelo es la forma correcta.
- `TEM-05` l. 160-185: el 404 al rol ajeno y el `llms.txt` por rol ya son el patrón que pide A-10.
- `TEM-04` l. 97: el `llms.txt` declara que sigue una propuesta, no una norma. Correcto según llmstxt.org.

## 8. Tabla «pieza → cambio → motivo → costo → orden»

| Pieza | Cambio | Motivo | Costo | Orden |
| --- | --- | --- | --- | --- |
| `SDEI/00-Marco.md` §2.5 y §4 | «agente» sale de la fila Audiencias y pasa a dimensión lector | A-04, X1 | bajo | 2 |
| `TEM-04` | Agente como lector que hereda audiencia; filtro único; sección MCP; trifecta | A-04, A-10, B-10 | medio | 3 |
| `TEM-05` | §3.3 generaliza a audiencia y alcance; canales para agentes en la misma regla | A-10 | medio | 3 |
| `TEM-06` | AG-1…AG-6; AI-n sobre recursos de microtexto | A-11 | medio | 4 |
| `99-Anexos/Glosario.md` | Entradas «Audiencia», «Lector», «Filtro único», «MCP» | A-01 | bajo | 2 |
| `Examples/` | Prueba-Ayuda-Por-Rol con segundo alcance y canal para agentes | A-15, B-12 | medio | 5 |
| `K` D-01, D-13, §2.3 | D-13 apunta a la decisión nueva; §2.3 deja de copiar la fila del Marco | A-12 | bajo | 1 |
| `K` decisión nueva | Matriz de audiencias con `lector`, `acceso`, `cumplimiento`, `canal_agente`, `assistant_use` | A-12 | medio | 1 |
| `K` A-01, A-03 | Vocabulario `audience` cerrado y `reader` aparte | A-04 | bajo | 1 |
| Libro (`F099` §5.2) | Cap. 7 reescrito; sección MCP | A-13 | medio | 6 |
| Oráculos y criterio de caso (`F204`) | Fila de no-fuga por `llms.txt`; re-sellado | A-14 | medio | 6 |

## 9. Lo no verificado e incidencias

- Revisiones de la especificación MCP posteriores a 2025-06-18: **sin verificar** hoy.
- Que algún agente de navegador concreto use `aria-describedby` como contexto: **sin verificar** (B-01/B-09).
- No se encontró un estándar que defina «audiencia» para agentes; la tesis 1 es [criterio propio].
- Corte de energía durante el ciclo: el informe se redactó el 2026-11-02 sin borrador previo en la carpeta.
- Mensajes de otras sesiones durante la redacción: ninguno.

## 10. Barrido de lo privado

Servicio privado sólo como `{servicio-privado}`; sin nombres de máquina ni rutas absolutas; rutas del cuerpo por
alias `SDEI/`, `K`.
