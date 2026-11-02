---
doc_id: BIT-16-MESA-C1-INF-ARQ
doc_type: informe-de-especialista
title: Informe del especialista en arquitectura de software — ciclo 1
objeto: BIT-16-04 (04-Plan-De-Integracion.md, v0)
rol: Arquitecto de software (pedido por el PO; señal: integración entre capas y sistemas)
modo: a ciegas (sin leer Ciclo-1/ ni informes de otros especialistas)
fecha: 2026-10-26
---

# Informe de arquitectura — ciclo 1

Mandato: ubicación de la capa de IA en el stack y en Domain/Application/Infrastructure, puertos y adaptadores, ADR, escenario «sumar IA a una app existente», acoplamiento a proveedores y la demo como ilustración de capas. Contrastado contra N1, N6, N0b §3.4, Sondeo-Entorno, N4 §2.2–§2.3 e I-05/I-06.

Niveles de evidencia (M§8): E4 = lectura literal de los documentos de la corrida, con ancla. Las conjeturas (C) van sólo como preguntas.

## Hallazgos

### ARQ-01 · Falta el caso de uso que orquesta «puerto de IA + reglas + escritura» (S2, confianza 0,85)

- **Ubicación**: §F.3 (diagrama, aristas `EP --> PT` y `BZ --> PT`) frente a §A.4 (diagrama de secuencia).
- **Afirmación**: el §A.4 dibuja `Presentación → Caso de uso (Application) → puerto IExtractorDeLocalidad → … → LocalidadRules`, pero el §F.3 conecta los endpoints y la página Blazor **directo a los puertos de IA**, y ningún servicio de Application compone extracción, normalización, validación y `SaveAsync` (D2, D3). Así como está, esa composición queda en el endpoint (lógica en Presentación) o en el adaptador (lógica de aplicación en Infrastructure). Ninguna de las dos es lo que dice la tesis.
- **Evidencia (E4)**: §A.4: «P->>A: pedido + sesión (la pone el código)» / «A->>X: puerto IExtractorDeLocalidad» / «A->>D: LocalidadRules»; §F.3: «EP --> PT», «BZ --> PT»; N6 §1.3, fila C2: «puerto `IExtractorDeLocalidad`; `LocalidadService.SaveAsync` sin cambios» (no dice quién los encadena). N1 F12: la UI habla con infraestructura «strictly through interfaces defined in Application Core».
- **Impacto**: la demo contradice su propio diagrama de secuencia y el OA-0.2; el lector copia la composición en el controller.
- **Dirección**: nombrar en §F.2/§F.3 el caso de uso que orquesta cada capacidad que escribe (D1–D3) y hacer que Presentación dependa de él; reservar la flecha directa Presentación → puerto sólo para el chat conversacional, como excepción declarada (N1 P8).

### ARQ-02 · El ida y vuelta de la aprobación humana no tiene diseño de estado entre peticiones (S2, confianza 0,8)

- **Ubicación**: §F.4 (fila `eliminar_localidad`), §E.3 `07-Agente-Con-Aprobacion`, D6.
- **Afirmación**: la aprobación exige responder `CreateResponse` **en la misma `AgentSession`**. En la consola de `07` eso pasa en un proceso. En la demo hay dos peticiones (la que produce el pedido y la que trae la decisión), sobre una API sin estado identificada por `X-Sesion-Id` o sobre un circuito Blazor. El plan no dice dónde vive la `AgentSession` ni el `ToolApprovalRequestContent` pendiente entre esas dos peticiones, ni con qué vida útil.
- **Evidencia (E4)**: §F.4: «`ApprovalRequiredAIFunction`; la UI muestra el pedido y devuelve la decisión»; N6 §2: «el llamador responde con `CreateResponse(true|false)` en la misma `AgentSession`»; N4 §2.2: la superficie incluye `SerializeSessionAsync`/`DeserializeSessionAsync` (confirmada sólo por XML de la DLL, N4 V02, no ejecutada en el caso).
- **Impacto**: D6 (y la prueba Q5) puede andar en `Cableado/` y no en la demo real; o se resuelve con un estático o singleton que mezcla sesiones (el antipatrón de T1).
- **Dirección**: decidir en D-06/D-07 el portador del estado (circuito Blazor, almacén del servidor indexado por sesión con `SerializeSessionAsync`) y sumarlo a §G.3 como dependencia que se verifica con una sonda antes de construir D6.

### ARQ-03 · Carpetas o proyectos: la regla de dependencia de la demo no es una decisión registrada (S2, confianza 0,75)

- **Ubicación**: §F.3 («Reglas que la demo cumple y prueba»), AC-5, §13.
- **Afirmación**: la tesis de la guía es puerto y adaptador, pero la demo hereda un solo ensamblado con capas en carpetas, donde el compilador no impide que `Domain/` referencie `Microsoft.Extensions.AI`. El control queda en un `grep` y en una prueba de arquitectura «si la mesa la pide». La elección entre carpetas con prueba de arquitectura y proyectos separados no figura entre los ADR, aunque es lo que el lector ACT-ARQ tiene que decidir al sumar IA.
- **Evidencia (E4)**: §F.3: «`Domain/` sin `Microsoft.Extensions.AI` (`grep` vacío, y una prueba de arquitectura si la mesa la pide)»; N1 §2.14: «las capas son **carpetas** de un único ensamblado, no proyectos separados, así que el compilador no impide violar la dependencia»; N0b D-01, consecuencias: «hace falta una prueba de arquitectura o un `grep`».
- **Impacto**: la demo, que tiene que *mostrar* las capas, depende de una convención que no se ve en el código.
- **Dirección**: tomarlo como decisión explícita, ya sea un ADR propio o una consecuencia ampliada de D-01, con alternativas de fuente (N1 F12, N6 F04), y fijar si AC-5 se cumple por compilación o por una prueba obligatoria.

### ARQ-04 · «Sumar IA a una app existente» sin línea de base: la copia se mezcla con cambios (S2, confianza 0,8)

- **Ubicación**: §F.1, §F.2 (filas Domain, Persistence y Controllers), §14.1.
- **Afirmación**: PR-17 promete mostrar la capa de IA agregada «sin reescribir» la app. Pero §F.2 rotula como «copia» piezas que cambian: los controllers pasan a endpoints, las reglas se endurecen (T2) y EF Core sube de versión. Además, la demo es una solución nueva. Sin una línea de base verificable (el código del caso base tal cual) y un delta enumerado, el lector no puede ver qué agregó la IA ni qué obligó a cambiar la IA. El endurecimiento de T2 es la lección más valiosa del caso, y así queda escondida.
- **Evidencia (E4)**: §F.2: «Controllers de `/api/v1` | **Copia mínima** de localidades y encuesta como endpoints»; «`Domain/` … **Copia** con procedencia; **endurecimiento declarado**»; «EF Core Sqlite **10.0.14** (el caso base fija 10.0.11)»; I-05 A-2: «agregarle la capa de IA sin reescribirla».
- **Impacto**: §14.1 no puede responder «lo que se copia y lo que es nuevo» con precisión, y D-01 pierde su escenario.
- **Dirección**: fijar como criterio de la demo una línea de base (la copia literal de `8fb4c3a`) y una tabla de delta en tres columnas: agregado por la IA, modificado a causa de la IA (T2 y T7) y modificado por otro motivo (versión, endpoints), con un motivo por fila. Decidir si los controllers se conservan como controllers.

### ARQ-05 · La sesión fija de MCP exige cambiar un middleware que el plan declara copiado sin cambios (S3, confianza 0,75)

- **Ubicación**: §F.5 (último punto), §F.2 (fila Persistence/Sessions).
- **Afirmación**: el middleware del caso base corre en todas las rutas y, sin encabezado, crea una sesión nueva sembrada por petición. Para que `/mcp` use «una sesión fija de demostración», hay que modificar `SessionHeaderMiddleware` o la composición de rutas. §F.2 lo da como copia y no registra ese desvío, que además introduce una segunda fuente de identidad.
- **Evidencia (E4)**: §F.5: «MCP usa una sesión fija de demostración, declarada»; §F.2: «`Sessions/SessionHeaderMiddleware` | **Copia**»; N6 §4.5: «si el cliente MCP **no** manda el encabezado, cada petición recibe una sesión nueva, sembrada con los datos iniciales».
- **Impacto**: D7 se construye con un cambio no declarado en Infrastructure; la prueba «sesión ajena» no cubre la ruta MCP.
- **Dirección**: declarar en §F.2 el cambio y su punto de inyección (rama de pipeline para `/mcp` o un resolvedor de sesión por adaptador de entrada), y sumar a `Cableado/` una prueba de aislamiento entre MCP y la API.

### ARQ-06 · Dónde viven las opciones propias de Ollama: el «cambio de proveedor» puede quedar acoplado en los adaptadores (S3, confianza 0,7)

- **Ubicación**: §E.1 (`num_ctx`), §E.2 `02-Cambio-De-Proveedor` (criterio de prueba), §E.3 `12-CAG-vs-RAG`, §G.3 dependencia de `num_ctx`.
- **Afirmación**: `ReasoningEffort.None` es portable (anduvo por las dos vías), pero `num_ctx` y `keep_alive` son de Ollama y su vía desde `IChatClient` no está verificada. El plan no fija dónde se configuran: en la raíz de composición o el pipeline, o en cada adaptador de funcionalidad. El criterio de `02` verifica con un `grep` «fuera del host», y eso no cubre `Infrastructure/AI`, que es justamente donde se colaría el acoplamiento. `12` prevé saltear `IChatClient` con `HttpClient` a `/api/chat`, y eso es acoplamiento directo al proveedor.
- **Evidencia (E4)**: §E.1: «Cómo se pasa `num_ctx` desde `IChatClient` con OllamaSharp **no está verificado**»; §E.2: «se verifica con un `grep` de `OllamaSharp` y `OpenAI` fuera del host»; §E.3 `12`: «o `HttpClient` a `/api/chat` si `num_ctx` no se puede pasar por `IChatClient`»; Sondeo §6: «`ReasoningEffort.None` funcionó **por las dos vías**».
- **Impacto**: D-02 («proveedor intercambiable») se afirma, pero la prueba de `02` no lo demuestra para los adaptadores.
- **Dirección**: decidir en D-02 que las opciones propias del proveedor se fijan en un solo lugar (composición o middleware del pipeline). Ajustar el criterio de `02` para que el `grep` abarque `Application/` y los adaptadores de funcionalidad. Rotular `12` como acoplado a Ollama a propósito si toma la vía HTTP.

### ARQ-07 · Registro de decisiones con IDs que chocan y omisiones respecto de N0b §3.4.11 (S3, confianza 0,85)

- **Ubicación**: §G.3 (IDs D-01…D-07), §E.1 y §E.3 (remisiones «§G, D-03»), §13.12.
- **Afirmación**: «D-0x» nombra a la vez los ADR (D-03 «Local o nube») y las dependencias de §G.3 (D-03 «cómo se pasa `num_ctx`»). Las remisiones quedan ambiguas justo en el documento que tiene que trazar decisiones. Además, §13.12 lista como decisión no tomada sólo «sincrónico o en segundo plano», y omite la que N0b deja abierta sobre el ciclo de vida del cliente en DI (T1). Esa decisión condiciona ARQ-02 y D-06.
- **Evidencia (E4)**: §G.3: «D-03 | **Cómo se pasa `num_ctx` (y `keep_alive`)…**»; §C §12: «Qué decisión toca: D-03, D-09»; N0b §3.4.11: «Ciclo de vida del cliente en DI (singleton o scoped) como decisión aparte | Parcial … Mientras tanto queda dentro de D-06»; plan §13.12: «(sincrónico o en segundo plano: sin fuente, N0b §3.4.11)».
- **Impacto**: trazabilidad rota entre §E, §G y §13; una decisión abierta desaparece del registro.
- **Dirección**: renombrar las dependencias (p. ej. DEP-xx) y sumar a §13.12 (o a D-06) el ciclo de vida del cliente y el estado de la sesión de agente, con su estado de verificación.

## Posiciones sobre PR-1…PR-22 (las de mi mandato)

| PR | Posición | Fundamento |
|---|---|---|
| PR-5 | apoya_con_cambios | Apoyo el reorden por autonomía del plan (N4 §2.15, F21; N4 §6.1 crit. 1). Cambio: D-07 en N0b todavía lista «agente → workflow», así que hay que reescribir sus alternativas con el orden nuevo y no sólo remitir a §B.3 |
| PR-12 | apoya | Marco y mapa primero, integración al final, con anticipos de D-01/D-02 en §4.6 y §5.9: la arquitectura queda visible sin presentar alternativas que el lector todavía no conoce |
| PR-13 | apoya_con_cambios | El formato de N0b (B19 + B20) es bueno. Hay que sumar las decisiones que la demo toma sin registrarlas (carpetas o proyectos, estado de la aprobación entre peticiones, ciclo de vida del cliente) y desambiguar los IDs (ARQ-03, ARQ-02, ARQ-07) |
| PR-16 | apoya_con_cambios | El principio es correcto y tiene fuente (N1 P9, OWASP). Para que «la aplicación decide» se vea en el código, la demo necesita el caso de uso orquestador (ARQ-01). Además, «autoriza» no tiene materialización: `X-Sesion-Id` no autentica (F.5), así que la forma corta tiene que decir que la demo muestra aislamiento y no autorización |
| PR-17 | apoya_con_cambios | Bien como encuadre de la demo y de D-01, no como escenario N0 (BIT-16-03 §1). Requiere línea de base y delta enumerado, o la promesa «sin reescribir» no se puede verificar (ARQ-04) |
| PR-18 | apoya | Pregunta guía con inventario verificable de M.E.AI/MAF; no construir un marco (disparador 3) |
| PR-19 | apoya | El cuadro con la fila «LangGraph por HTTP» ordena el acoplamiento por ecosistema; las versiones ya están verificadas en N2/N4 |
| PR-20 | apoya_con_cambios | La sesión como identidad mínima, con una prueba negativa de sesión ajena, es correcta. Falta cubrir la ruta MCP, que usa otra fuente de identidad (ARQ-05) |

## Revisado y bien

1. **§B.1, mapeo imagen → capas .NET**: MCP como adaptador de entrada (igual que un controller), la Vector DB separada en uso (Infrastructure/AI) y almacenamiento (Persistence), y el servidor de modelos fuera de la solución por configuración. Es fiel a N1 §1.1 y N6 §1.3, y cada fila trae su fuente.
2. **§F.2 y §F.4, herramientas sobre casos de uso**: se agrega `ResultadosDeEncuestaService` en vez de tomar un atajo al repositorio, no se copia la excepción de `LocalidadesController`, no se expone `RegistrarAsync` (H6/T7) y la sesión sale del scope y nunca de un argumento. Coincide con N6 P5, T1 y T7 y con N0b D-06.
3. **§F.6, embeddings con planes A/B/C**: el código depende sólo de `IEmbeddingGenerator` y de la configuración, con un endpoint de embeddings separado (`OLLAMA_EMBED_ENDPOINT`). La decisión del PO queda aislada en la composición y la degradación del plan C está declarada.

## Solicitudes de convocatoria

- Seguridad (AH-01): la demo no tiene autorización (sólo aislamiento por `X-Sesion-Id`, que no autentica) y el principio rector dice «autoriza». Que evalúe si alcanza con declararlo o si D6 necesita un control mínimo.
