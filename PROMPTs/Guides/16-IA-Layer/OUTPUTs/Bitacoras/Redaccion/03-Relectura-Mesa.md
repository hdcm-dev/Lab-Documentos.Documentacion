---
doc_id: BIT-16-RED-03-RELECTURA
doc_type: acta-de-mesa
title: Relectura integral de la guía 16 — jurado de cinco criterios
status: vigente
origin: agent (jurado de la mesa de relectura)
last_review: 2026-10-27
---

# Relectura integral: jurado de cinco criterios

Objeto: `Guides/IA/Dot-Net-Integration-AI-Layer-Guide/Dot-Net-Integration-AI-Layer-Guide.md`, ensamblada, 5.126 líneas.
Insumo: nueve informes de relectura (didáctica, edición, .NET, IA, arquitectura, desarrollo, seguridad, evaluación, cohesión). Ningún perfil editó archivos.
Jurado: cinco criterios. **E**videncia: ¿el hallazgo está probado contra el código, el registro o la fuente? **I**mpacto: ¿qué copia mal el lector? **CB**, costo-beneficio: ¿cuánto texto y cuánto riesgo de romper otra cosa cuesta el parche? **Co**herencia: ¿respeta el plan v3, AC-9, I-06 y la plantilla? **R**iesgo: ¿el parche introduce algo sin respaldo o rompe anclas?

Rutas de este documento: relativas a la carpeta de la guía (`Examples/…`, `Demos/…`, `tools/…`) o a `Bitacoras/`.

## 1. Verificaciones propias del jurado

Antes de votar, el jurado comprobó en el código o en los registros los hallazgos S1 y los que cambian una afirmación de seguridad:

| Hallazgo | Comprobación | Resultado |
|---|---|---|
| `EMB_PLAN` en A.12 | `Examples/_Comun/MovilidadUrbana.Asistente.Comun/AI/ConfiguracionDelModelo.cs`: `Leer("EMB_PLAN", "EMB-B")` y `Validar()` acepta sólo `EMB-A`, `EMB-B` o `EMB-C`; `Examples/README.md` l. 62 da la misma fila | confirmado |
| Paquetes de F.1 sin uso | búsqueda de `Microsoft.Extensions.Hosting"`, `OpenTelemetry.Extensions.Hosting` y `OpenTelemetryProtocol` en `*.csproj` y `*.props`: sólo aparecen en `Examples/Directory.Packages.props` | confirmado |
| §12.10 frente a ADR-09 | guía l. 3593 («un límite frente al servidor»); `UseOpenTelemetry` aparece sólo en `Infrastructure/AI/Chat/SesionDeChat.cs` de la demo | confirmado |
| `Nombre` y `Edad` en CTX-SENS | `Demos/…/Infrastructure/AI/Extraccion/ExtractorDeEncuesta.cs` l. 23 («edad sólo si la dice») y l. 55 (`JsonPropertyName("edad")`) | confirmado |
| Regla 1 en la demo | `HerramientasDelAsistente.cs` l. 40-45: `conEscrituras` en `false` «es la regla 1»; la única llamada con `conEscrituras: false` está en `tests/…/Cableado/AprobacionTests.cs:103` | confirmado |
| `escriturasAprobables` | mismo comentario: «existe sólo para probar la regla 2 […]; la demo siempre las arma aprobables» | confirmado |
| Lectura que pide aprobación | `ResolutorDeAprobaciones.cs` l. 82-83 | confirmado |
| Normalización en 04 | `Examples/04-…/Application/NormalizacionDeMovilidad.cs` y `Infrastructure/AI/NormalizadorDeCatalogo.cs` | confirmado |
| Acuerdo del juez 0/10 | `06-Construccion.md` §8, fila 15: «acuerdo 0/10, IC95 [0; 0,308]» **está admitido**; lo que se discute es la lectura, no la cifra | la cifra se puede citar; el jurado cambia la lectura (H-20) |
| Subcomando `extension` del arnés | `tools/verificar.sh` l. 500 | existe |
| Fuentes para parches nuevos | Anexo D: [REF-55] (FAQ de Ollama: `keep_alive`, `OLLAMA_NUM_PARALLEL`), [REF-35], [REF-75], [REF-84], [REF-92], [REF-109], [REF-194] (orden con *Total Request Timeout*), [REF-195]; **no hay** fuente registrada para Clopper-Pearson, para el circuito de Blazor ni para `OLLAMA_HOST` | condiciona H-28 y H-29 |

## 2. Informes resumidos

| Perfil | Veredicto | S1 | S2 | S3 | S4 | Núcleo |
|---|---|---|---|---|---|---|
| Didáctica | aprobado con observaciones | 0 | 4 | 7 | 3 | OA-O2 promete timeouts por variable; ítem 3 contradice PD-3; §8.6 justifica el workflow de 12 con un argumento que también vale para un método; ítem 12 sin contenedor |
| Edición | aprobado con observaciones | 0 | 1 | 6 | 11 | extensión +12,8 % (Anexos +65 %, Parte 0 +33 %); glosario contra sus reglas; citas (REF-110, REF-187, cadencia de MAF); ADR-03; catorce compresiones |
| .NET | aprobado con observaciones | 2 | 2 | 5 | 3 | `EMB_PLAN` falso; F.1 lista paquetes que nadie referencia; snippet de §9.4 sin archivo; `BindExecutor` y `CS0411`; §12.7 «excluí ese manejador» |
| IA | aprobado con observaciones | 0 | 2 | 8 | 2 | la escalera «mide cuánto decide el modelo» y el 2 decide menos que el 1; acuerdo 0/10 con IC sobre salidas no interpretables; afirmaciones más fuertes que sus fuentes |
| Arquitectura | aprobado con observaciones | 1 | 6 | 5 | 1 | §12.10 atribuye a ADR-09 lo que no decide; telemetría sólo en el chat; ADR-01 sin el caso de `Chat.razor`; diagramas con piezas en la capa equivocada; ejemplos en `Application/` |
| Desarrollo | aprobado con observaciones | 0 | 4 | 5 | 1 | reprodujo `--fake` de 03, 08 y 16, la demo (70/70) y el recálculo (32/32); el lector con Ollama propio no puede correr: `localhost` desde contenedores, versión y digest exigidos, `/api/ps` con un solo servidor |
| Seguridad | aprobado con observaciones | 1 | 5 | 2 | 0 | PD-4 manda el relato y extrae la edad, contra B.4 e ítem 24; regla 1 no aplicada en el chat; interruptor sin aprobación en el snippet; descripción y esquema MCP del servidor; CTX-LOCAL «sin salida de datos»; LLM10 |
| Evaluación | aprobado con observaciones | 0 | 4 | 6 | 3 | «cita y contradice 1/12» no es contradicción (r09) y r07 queda fuera; G10 presentado como garantía; 05 afirma el mecanismo de caché; «basta un agente» sin respaldo en 12 |
| Cohesión | aprobado con observaciones | 0 | 4 | 9 | 6 | barridos RD-PO, R-PRIV, REF y nombres de prueba limpios; ejemplos en `Application/`; snippet de escrituras; §12.10; §0.3 promete explicaciones que no están; PR-15 incompleto en fragmentación y perfil del equipo |

## 3. Auditoría de homogeneidad

**Los nueve veredictos son idénticos.** El jurado no acepta la unanimidad tal cual. Tres perfiles (.NET, arquitectura, seguridad) informan S1 y aun así votan «aprobado con observaciones». Por definición, un S1 es algo falso que el lector copia: con S1 abiertos, la guía no está aprobada. **Veredicto del jurado: aprobada condicionada.** No se publica sin los parches de los S1 (H-01, H-03, H-04) y de los S2 de seguridad (H-08 a H-12). El resto puede entrar en la misma pasada o quedar registrado.

**La unanimidad de los barridos mecánicos se justifica.** RD-PO, R-PRIV, REF citados contra el Anexo D, anclas, snippets textuales y nombres de prueba los corrieron por script al menos tres perfiles por separado (edición, .NET, desarrollo y cohesión), con el mismo resultado limpio. Son verificaciones binarias y reproducibles: que coincidan es lo esperado.

**La coincidencia de hallazgos se justifica.** Cinco perfiles marcan el ítem 12 (`dotnet test` sin contenedor), cinco la remisión de §10.5 a §7.5 y tres la cadencia de MAF. Son hechos textuales que cualquier relectura atenta encuentra, y el jurado los comprobó. Donde los perfiles discrepan en severidad (la normalización contra `Catalogos`, S2 a S3; el acuerdo del juez, S2 a S4), el jurado fija una sola.

**El jurado no votó en bloque.** Quedan 98 filas consolidadas (las 5 compresiones incluidas). 88 se aplican completas y 10 en parte. Además, 16 propuestas parciales se descartan con motivo (§5). Hay votos con disidencia o abstención en H-02, H-12, H-15, H-23, H-29, H-30, H-40, H-41, H-44, H-51, H-64, H-66, H-68, H-74 y H-81, y queda registrada en cada fila. Cuatro severidades se recalificaron. H-02 baja de S1 a S2. H-07 baja de S2 a S3. H-28 baja de S2 a S3. H-05 queda en S2 para todos los perfiles, porque bloquea al lector que siguió §0.3.

## 4. Consolidación y veredictos

Leyenda de votos: `+` a favor de aplicar, `−` en contra, `=` neutro. Orden: E · I · CB · Co · R. Decisión: **A** aplicar, **AP** aplicar en parte, **D** descartar.

### 4.1 Severidad S1 tras la consolidación

| ID | Hallazgo (perfiles) | Votos | Decisión | Dueña |
|---|---|---|---|---|
| H-01 | A.12 declara un default falso para `EMB_PLAN` y no da sus valores (.NET S1, desarrollo S2) | + + + + + | A | A, 14 |
| H-03 | §12.10 atribuye a ADR-09 «telemetría siempre» y «un límite frente al servidor» (arquitectura S1, cohesión S2) | + + + + + | A | 12 |
| H-04 | B.4 y los ítems 23 y 24 dicen que `Nombre` y `Edad` no entran al contexto; PD-4 manda el relato y extrae la edad (seguridad S1) | + + + + + | A | 11, B, 15, 04 |

### 4.2 S2

| ID | Hallazgo (perfiles) | Votos | Decisión | Dueña |
|---|---|---|---|---|
| H-02 | F.1 presenta como usados `Microsoft.Extensions.Hosting`, `OpenTelemetry.Extensions.Hosting` y `…OpenTelemetryProtocol` (.NET S1). Recalificado S2: es falso, pero el lector no lo copia en código | + = + + + (I neutro: no rompe nada) | A (texto; el `.props` queda fuera de alcance) | F |
| H-05 | El ítem 12 manda `dotnet test` en el host (didáctica, edición, .NET, desarrollo, cohesión) | + + + + + | A | 15 |
| H-06 | Los ejemplos 01, 05, 07, 09, 11, 12, 16 y 17 ponen bajo `Application/` piezas que §4 y ADR-01 mandan a Infrastructure/AI, y no lo declaran (arquitectura, cohesión) | + + + + + | A (aviso; no se mueven carpetas) | E, 08, 06 |
| H-08 | El snippet de `HerramientasDelAsistente.cs` muestra la rama sin aprobación y no dice que existe sólo para una prueba (seguridad, cohesión) | + + + + + | A | 08 |
| H-09 | La regla 1 de la política de origen se da por vigente en la demo y verificada con una prueba que sólo ejerce el parámetro (seguridad) | + + + + + | A | 11, B, 13 |
| H-10 | El cliente MCP: sólo las lecturas usan la descripción del cliente, y el esquema de parámetros siempre es el del servidor (seguridad) | + + + + + | A | 08, 11, B |
| H-11 | CTX-LOCAL definido «sin salida de datos» cuando el laboratorio usa un servidor compartido (seguridad) | + + + + + | A | 02, 12 |
| H-12 | El control mínimo de LLM10 omite el largo máximo de entrada y el límite de concurrencia (seguridad) | + + + + = (R neutro: la recomendación de OWASP no está en el Anexo D; va como criterio) | A | 11, 12, 14 |
| H-13 | El criterio «toda llamada pasa por `UseOpenTelemetry`» no lo cumple la demo: PD-2, PD-3 y PD-4 no emiten tramos (arquitectura) | + + + + + | A | 12, 13, B |
| H-14 | ADR-01 no recoge que `Chat.razor` inyecta `SesionDeChat`, un tipo concreto de Infrastructure/AI (arquitectura) | + + + + + | A | 13 |
| H-15 | Cuatro diagramas (§3.1, §5.4, §8.2, §11.1) ponen en Application la sesión de chat, la política de origen y la aprobación; §11.1 invierte la flecha (arquitectura) | + + + + = (R: hay que tocar mermaid) | A | 03, 05, 08, 11 |
| H-16 | §5 y B.1 dan como criterio que Application reciba `IChatClient`, la opción que ADR-01 llama deuda; el glosario define mal «puerto» (arquitectura) | + + + + + | A | 05, B, C |
| H-17 | La escalera «mide cuánto decide el modelo», y el escalón 2 deja decidir menos que el 1 (IA) | + + + + + | A | 03, 08, 13, C |
| H-18 | §8.6 e ítem 9 justifican el workflow de MAF en 12 con un argumento que también cumple un método de C# (didáctica) | + + + + + | A | 08, 15 |
| H-20 | §10.6 y ADR-10: «acuerdo 0/10, IC95 [0; 0,308]» cuando ninguna salida se pudo leer (IA S2, evaluación S4) | + + + + + | A (sin quitar la cifra admitida: cambia la lectura) | 10, 13 |
| H-21 | 07: «cita y contradice 1/12» es r09 (agrega un valor que el literal no fija); r07, que sí contradice la regla, queda fuera de la cuenta (evaluación) | + + + + + | A | 07, 02 |
| H-22 | §2.5 da a entender que el código garantiza «acotar ante la duda» (G10); n01 citó un fragmento real y se mostró (evaluación) | + + + + + | A | 02, 07 |
| H-23 | 05: «el motor conservó el prefijo» y «la rompe un carácter cambiado» con una corrida y `estado_cache` desconocido; además, en el orden alternado el 6/6 es inalcanzable (evaluación S2, didáctica S3) | + + + + − (R: «compatible con» puede leerse como afirmación débil) | A, 4-1 | 06 |
| H-24 | «Basta un agente» en §8 y ADR-07 se apoya en 12, que no responde esa pregunta (evaluación) | + + + + + | A | 08, 13 |
| H-25 | OA-O2 promete timeouts por variable; la espera es una constante (didáctica) | + + + + + | A | 00 |
| H-26 | El ítem 3 resuelve en el escalón 1 un alta que PD-3 resuelve en el 0 (didáctica) | + + + + + | A | 15, 03 |
| H-27 | El bloque C# de §9.4 (LangGraph por HTTP) no sale de ningún archivo y saluda con «Hola» (.NET S2, didáctica S4) | + + + + + | A: pasa a bloque `text` con un pedido del caso | 09 |
| H-29 | Los defaults `localhost` no sirven desde los contenedores que exige la guía (desarrollo) | + + + + = (R: `OLLAMA_HOST` sin REF) | A, con condición | E, 12, 14 |
| H-30 | El arnés exige versión y digests exactos y la guía no da otra vía (desarrollo) | + + + + = | A, con condición | E |
| H-31 | Con un solo Ollama para los dos papeles, la fase de chat aborta por `/api/ps` (desarrollo) | + + + + + | A | E |

### 4.3 S3

| ID | Hallazgo (perfiles) | Votos | Decisión | Dueña |
|---|---|---|---|---|
| H-07 | La normalización contra `Catalogos` aparece en tres capas según la sección (.NET S3, arquitectura S2, cohesión S3). Recalificado S3: las tres variantes existen en el código; falta decirlo | + + + + + | A | 05, 13 |
| H-19 | §8.8 omite group chat entre las orquestaciones de MAF; G.3 pone orquestador-trabajadores en el 3 cuando [REF-115] lo cuenta como workflow; 12 no se nombra como evaluador-optimizador (edición, IA) | + + + + + | A | 08, G, C |
| H-28 | §0.3 promete explicar Clopper-Pearson y el circuito de Blazor, y el cuerpo no lo hace (cohesión S2). Recalificado S3: no hay fuente registrada para ninguna de las dos explicaciones | + = + + + | AP: §0.3 deja de prometer; §10.4 suma lo que el código hace; el circuito queda pendiente de fuente | 00, 10 |
| H-32 | `demo.sh host` sin build previo muere y el script igual anuncia la URL (desarrollo) | + + + + + | A | 14 |
| H-33 | UID 1000 fijo en el `docker run` manual (desarrollo) | + + + + + | A | E, 15 |
| H-34 | Se invita a usar banderas (05 `--orden`, 08 `--extension`, 15 otro juez) sin comando que las pase (desarrollo) | + + + + + | A | 06, 08, 10 |
| H-35 | `RLLM_DIR` vacío en el shell del lector; el registro queda en un lugar distinto según la vía (desarrollo, didáctica) | + + + + + | A | E, 15 |
| H-36 | Imagen del SDK flotante `sdk:10.0` contra un SDK validado 10.0.403 (desarrollo) | + + + + + | A | E |
| H-37 | Rutas de lectura frente a OA e ítems: §14.2 fuera del tronco; §5.3 fuera de ACT-SEC; OA-D9 promete una corrida con modelo; la pregunta del vacío atada a OA-O2 (didáctica) | + = + + + | A | 00 |
| H-38 | Parte I con tasas, IC, digests y `tool_choice` antes de los conceptos; §2.2 se sostiene con un 4/4, que no muestra la dependencia; `/v1` sugiere que la API nativa sí fuerza la herramienta (didáctica, evaluación, IA, cohesión) | + + + + + | A | 02, 05 |
| H-39 | §3.4: la fila «una aprobación entre dos peticiones» manda a 11 y no a 09 (didáctica S3, edición S4) | + + + + + | A | 03 |
| H-40 | Ninguna salida muestra el bloque «costo por variante» de 12 que OA-D7 pide comparar (didáctica) | + + = = = (R: los tokens guionados pueden leerse como medición) | AP: entra con rótulo de salida guionada y sin las cifras de tokens en la prosa | 08 |
| H-41 | 09 deja aprobar el «34» y PD-5 valida antes; la guía no compara ni dice cuál conviene; §8.4 dice que PD-5 «repite» (didáctica, cohesión) | + + + + = | A, 4-1 (R: «conviene» es criterio y se rotula) | 08 |
| H-42 | Ítem 13: no queda claro si «criterio de la guía» cuenta como fuente frente a §13.15 (didáctica) | + + + + + | A | 15 |
| H-43 | Pregunta guía de §6: CAG «comparable o mejor» contra las salvedades de §6.3 (didáctica, IA) | + + + + = | AP: sin el «5 de 6 casos» de IA, que no figura en §8 de 06-Construccion | 06 |
| H-44 | Extensión sobre los topes del plan (Anexos +65 %, Parte 0 +33 %); `tools/contar.sh` no existe (edición) | + = − + = | AP: compresiones de bajo riesgo (H-45 a H-49) y motivo registrado en 07-Redaccion; `tools/contar.sh` descartado (fuera de alcance) | 07-Redaccion, varias |
| H-50 | Remisión de §10.5 a §7.5 en vez de §7.4 (cinco perfiles) | + + + + + | A | 10 |
| H-51 | El glosario no cumple sus reglas: alias «contexto», alias «función», canónico «escalón de orquestación» contra el uso «agencia», términos núcleo ausentes, sinónimos sin declarar (edición) | + + = + = | AP: (a), (b), (c) y (e) completos; (d) sólo las filas con casa en la guía | C, 08, 10, 13 |
| H-52 | §7.5: la definición de MRR va como cita literal y es una traducción; el descriptor de REF-110 no la nombra (edición) | + = + + + | A | 07, D |
| H-53 | REF-187 se usa para descripciones y dependencias de `.nuspec`, que su URL no sirve; «los nombres viejos no están» no lo respalda una lista de versiones (edición, cohesión) | + + + + + | A | D, 09, F |
| H-54 | La cadencia semanal de MAF se generaliza más allá de septiembre y octubre de 2026 (edición, .NET, cohesión) | + + + + + | A | 09, 13 |
| H-55 | §12.4 y ADR-03 prometen «servidor compartido» y no lo listan como alternativa (edición) | + + + + + | A: opción 2 (se conserva el título del plan) | 12, 13 |
| H-56 | `BindExecutor` existe; `CS0411` es de inferencia de tipos (.NET) | + = + + + | A | 08, 09 |
| H-57 | §12.7: la fábrica no «excluye» el manejador de resiliencia; crea el `HttpClient` fuera de `IHttpClientFactory` (.NET) | + + + + + | A | 12, B |
| H-58 | 05 manda el prefijo como mensaje de sistema y no por `ChatOptions.Instructions`, sin explicarlo (.NET) | + + + + + | A | 06 |
| H-59 | §4.2 atribuye a Lewis et al. «sin reentrenar» (IA) | + = + + + | A | 04 |
| H-60 | §6.1 reduce RAG a la recuperación densa (IA) | + + + + + | A | 06 |
| H-61 | «Al menos seis discordantes» se lee como condición suficiente (IA, evaluación) | + + + + + | A | 10, 07 |
| H-62 | §10.1 declara sin fuente el no determinismo, y [REF-75] ya está registrada (IA S3, evaluación S4) | + + + + + | A | 10, C |
| H-63 | §7.5: la línea base del azar es una sola permutación con semilla, y no se la distingue de la esperanza (IA, evaluación) | + = + + + | A | 07 |
| H-64 | Mapeo de la diapositiva incompleto: faltan *Auth Service*, *API Gateway*, *File Storage*, *Object Storage* y *NoSQL* (arquitectura) | + + + + = | A | 01, 03 |
| H-65 | §14.2 llama a las dos excepciones «excepciones al principio rector» e iguala AI LAYER con Infrastructure/AI (arquitectura) | + + + + + | A | 14 |
| H-66 | El almacén vectorial cambia de capa entre §1, §3.1 y §14.2 (arquitectura) | + + + + = | A | 01, 03 |
| H-67 | La prueba de arquitectura no cubre dos reglas que la guía enuncia (arquitectura) | + + + + + | A (texto; la regla nueva queda como deuda) | 13, 04 |
| H-68 | §1: «cuyo autor no se verificó», y la diapositiva lleva una marca visible (arquitectura) | + = + + = | A | 01 |
| H-69 | 08: la frase sugiere que el modelo ve ids de sesión; el id venía en la pregunta (seguridad) | + + + + + | A | 08 |
| H-70 | `Development` en el compose también expone OpenAPI, Scalar y el detalle de errores (seguridad) | + + + + + | A | 12 |
| H-71 | ADR-08 apoya la confianza alta en 0/4 (evaluación) | + + + + + | A | 13 |
| H-72 | Latencias atribuidas a carga ajena, que no se midió; los pesimistas por clase sin su origen (evaluación) | + + + + + | AP: sin los tokens 645 y 646, que no están en la tabla AC-9 | 05, 12 |
| H-73 | Observaciones del sondeo previo (razonamiento por defecto, 501 de embeddings, servidor compartido) con el peso de las corridas recalculadas (evaluación) | + + + + + | A | 05, 07, 12 |
| H-74 | §14.3 no declara que el humo de PD-6 se repitió (evaluación) | + = + = = (Co: AC-9 dice que el primer PD-6 no se cita) | A, 3-2: se menciona que existió, sin su resultado | 14 |
| H-75 | PR-15: la fragmentación no tiene pregunta guía ni ejemplo (cohesión) | + + + + + | A | 07, E |
| H-76 | PR-15: el perfil del equipo no tiene pregunta guía (cohesión) | + + + + + | A | 02 |
| H-77 | Una lectura en la misma respuesta que una escritura también pide aprobación, y la guía dice que las lecturas no (cohesión) | + + + + + | A | 08, B |
| H-78 | Criterio de §8: «tope de errores seguidos… una prueba lo comprueba», y B.5 dice que no hay prueba (didáctica S4, cohesión S3) | + + + + + | A | 08 |
| H-79 | §11.2: la inyección «por el Nombre que cargó otra persona» contradice el aislamiento por sesión (cohesión) | + + + + + | A | 11 |
| H-80 | §0 y §1 no anuncian que el escalón 3 no se ejecuta (cohesión) | + + = + + | A en §0, compensado con recortes de H-45 | 00 |
| H-81 | ADR-01 de consecuencias: `AgentSession` respaldado por tres REF distintas (edición S4) | = = + + = | A, con condición: elegir la REF tras releer las tres | 08, 09 |

### 4.4 S4

| ID | Hallazgo (perfiles) | Decisión | Dueña |
|---|---|---|---|
| H-82 | Plantilla de §0.4: «… de §N de §0» (didáctica, edición, cohesión) | A | 00 |
| H-83 | §14: «la sesión repartida por zona», jerga sin explicar (didáctica) | A | 14 |
| H-84 | E.1: la dificultad no sube en el orden de lectura (didáctica) | A | E |
| H-85 | Índice: subsecciones sin título y falta «Criterio de elección» de §9 (edición) | AP: sólo se agrega `s9-criterio`; los títulos se descartan por tope | 00 |
| H-86 | Anexo A: numeración A.4–A.14 (edición) | AP: se explica en la introducción; no se renumera, porque `anexo-a-12` tiene decenas de remisiones | A |
| H-87 | Anexo D, forma (edición) | AP: (a) reubicar entradas, (c) fechas ISO, (e) autores, (f) URL plantilla y `q=graphlang`, (g) regla de la cita; (b) en H-49; (d) descartado sin dato | D |
| H-88 | Forma única de la glosa de citas en inglés (edición) | A | 00, 01, 09 |
| H-89 | Siglas antes de definirse; versiones en el cuerpo de §12.1; voseo «preví»; *pipeline* en dos formas (edición) | A | 00, 12, 05 |
| H-90 | §0.3: «para los embeddings, 02, 05 y el juez de 15» es ambiguo; §5.5 omite el juez de 15 (edición, .NET) | A | 00, 05 |
| H-91 | REF-46 fechada en 10.10.1 (.NET) | A | D |
| H-92 | Anexo C, fila IC95: Clopper-Pearson no es criterio de la guía (cohesión) | A | C |
| H-93 | «Circuito» con dos sentidos (cohesión) | A | 12 |
| H-94 | Encabezado: «falta su relectura integral» (edición, cohesión) | A, al cerrar la pasada de parches | 00 |
| H-95 | Embedding: «mide parecido» y «preserva el significado» (IA) | A | 03, 07 |
| H-96 | ReAct: el razonamiento no va «en el prompt», sino en la salida (IA) | A | 08 |
| H-97 | §14.1, tabla de delta: faltan `EncuestaPropuesta`, `RespuestaDeAyuda` y los `Contracts/` (arquitectura) | A | 14 |
| H-98 | Comentarios de los bloques bash que varían entre ejemplos (desarrollo) | AP: sólo E.4 fija la forma; no se tocan seis secciones por algo cosmético | E |

### 4.5 Compresiones de edición (de H-44)

| ID | Compresión | Decisión |
|---|---|---|
| H-45 | C2–C3: el caso vive en §0.3; la cita completa de [REF-117] vive en §8.1 | A |
| H-46 | C4–C7: una sola casa para agencia excesiva (§11.3), regla pareada (§10.4), latencias (§5.7), `tool_choice` (§5.6), `localhost` (§12.6), «70 pruebas» (§14.5) y «aprobar no es autorizar» (pregunta guía de §11) | A |
| H-47 | C8–C9: frases de arranque repetidas de «Práctica» y «Ejemplos», y el ejemplo 13 completo dos veces | A |
| H-48 | C10–C11: §14.3 como tabla única de la demo (E.2 remite); A.12 como tabla única de variables (§5.5, §7.1 y §14.5 remiten) | A |
| H-49 | C13: recortar REF-164 y REF-192 a REF-201 a descriptor corto, con las citas en el cuerpo | A |

## 5. Descartado, con motivo

| Propuesta | Perfil | Motivo |
|---|---|---|
| Crear `tools/contar.sh` | edición | Fuera del alcance de escritura de la redacción (regla 6). Se registra como pendiente en 07-Redaccion. |
| Alinear `Examples/15-Pruebas-Y-Evaluacion/README.md` con el comando del ítem 12 | edición | Fuera del alcance de escritura. Pendiente para la pasada de código. |
| Quitar las tres entradas de `Examples/Directory.Packages.props` (H-02, vía a) | .NET | Fuera del alcance de escritura. La guía describe lo que hay y deja el retiro como pendiente. |
| Mover las carpetas de los ejemplos a `Infrastructure/AI` (H-06) | cohesión | Toca código ya verificado y sus registros (`entradas_hash`). El aviso alcanza para el lector. |
| Corregir el código de 13 para que las escrituras usen la descripción del cliente (H-10) | seguridad | Fuera de alcance. Pendiente registrado. |
| Agregar la prueba `Presentacion_SoloElChatEntraAInfrastructureAI` (H-67) | arquitectura | Es código. La guía la declara deuda. |
| Renumerar el Anexo A | edición | Rompe la remisión `anexo-a-12`, que aparece en decenas de lugares. Se explica la numeración en lugar de cambiarla. |
| Títulos en cada subsección del índice | edición | Suma unas 300 palabras a una Parte 0 ya pasada de su tope. GitHub genera el índice de títulos. |
| Retitular §5.8 «Qué decisión toca: ADR-02» | edición | El título «Decisión en curso» lo fija la carta §16.1. Se conserva. |
| C1: fundir §4.1 en §3.0 | edición | §4.1 está en el índice del plan §C, y el plan manda. Sólo se unifica el respaldo de «temperatura» (H-51). |
| C12: fundir los Criterios de calidad de cada sección con el Anexo B | edición | El plan exige las dos cosas: la plantilla de §0.4 y las listas por actor. |
| C14: rótulos con nombre en F.4 | edición | Cambia la regla de los rótulos (completo una vez por sección). El ahorro no justifica el riesgo de que una salida quede sin rótulo legible. |
| Anexo D (d): agregar vN de arXiv o año a REF-76…REF-83 y REF-158 | edición | No hay dato registrado. Agregarlo sería inventar. Queda pendiente: completarlo al consultar cada fuente. |
| «5 de 6 casos» del artículo de CAG (H-43) | IA | No está en la tabla AC-9 ni el jurado lo encontró en el registro de referencias. Se usa la redacción de didáctica. |
| Tokens 645 y 646 de DEP-13 (H-72) | evaluación | No figuran en 06-Construccion §8. Por AC-9 no entran. |
| «Con 9 a 0 daría 0,004» (H-63) | IA | No hace falta para el parche, y suena a medición. |
| Fusionar §8.8 con la salida de tokens guionados citados en prosa (H-40) | didáctica | Las cifras de un guion leídas en prosa parecen una medición. Entra sólo el bloque de salida, rotulado. |

## 6. Parches por sección dueña

Forma: **buscar** el fragmento citado en la sección y **reemplazar** o **agregar** el texto dado. El texto que sale de un informe ya pasó por el jurado y quedó ajustado. «Condición» indica lo que hay que comprobar antes de aplicar. Las secciones con archivo en `Redaccion/secciones/` se parchean ahí y se reensamblan. C, D y F no tienen archivo y se parchean en la guía.

### 00 · Parte 0

- **P-00-1 (H-25).** Fila OA-O2. Reemplazar el texto del objetivo por: «Configurar endpoint, modelo y `num_ctx` por variable, sin ningún valor en el repositorio, y fijar de forma explícita la espera y la política de reintentos del cliente del modelo, sin el manejador estándar de resiliencia». En «Dónde se enseña», agregar [§12.7](#s12-7).
  - **Estado:** aplicado: fila OA-O2 con el texto dado y [§12.7] sumado a «Dónde se enseña».
- **P-00-2 (H-37).** §0.2: en el tronco común, agregar [§14.2](#s14-2). En la ruta ACT-SEC, agregar «[§5.3](#s5-3), para LLM05». OA-D9: reemplazar «dejar registrada una corrida contra el modelo» por «recalcular el oráculo desde el registro de una corrida». La pregunta guía de §5 «¿Por qué el modelo me devolvió vacío?» se ata a OA-D1 en la tabla de §0.1.
  - **Estado:** aplicado: §14.2 al tronco común, «§5.3, para LLM05» al frente de ACT-SEC, OA-D9 reescrito; la pregunta «¿Por qué el modelo me devolvió vacío?» se reatada a OA-D1 en su propia etiqueta de §5 (la tabla de §0.1 no lista preguntas).
- **P-00-3 (H-28).** §0.3, «Se explica»: reemplazar «el intervalo de Clopper-Pearson ([§10.4](#s10-4))» por «cómo se calcula el intervalo de cada tasa ([§10.4](#s10-4))», y «dónde vive la conversación del chat en Blazor, el circuito ([§13.13](#s13-13))» por «dónde vive la conversación del chat en Blazor ([§13.13](#s13-13)); qué es un circuito de Blazor Server se da por conocido».
  - **Estado:** aplicado tal cual en «Se explica» de §0.3.
- **P-00-4 (H-90).** §0.3: reemplazar «para los embeddings, 02, 05 y el juez de 15, el de `OLLAMA_PROPIO_ENDPOINT`» por «para 02, 05 y el juez de 15, el de `OLLAMA_PROPIO_ENDPOINT`; los embeddings usan `OLLAMA_EMBED_ENDPOINT`, que por defecto toma ese mismo valor».
  - **Estado:** aplicado; comprobado en `ConfiguracionDelModelo.cs` l. 74 (`OLLAMA_EMBED_ENDPOINT` toma por defecto el valor de `OLLAMA_PROPIO_ENDPOINT`).
- **P-00-5 (H-82).** Plantilla de §0.4: «#### Criterios de calidad y antipatrones de §N».
  - **Estado:** aplicado: se quitó «de §0» de la plantilla.
- **P-00-6 (H-88).** §0.4, agregar la regla: «Cita en inglés: «cita» (glosa en castellano) [REF-nn]. Toda cita en inglés lleva su glosa».
  - **Estado:** aplicado: viñeta «Cita en inglés» en la lista de evidencia de §0.4; además se llevaron a esa forma las 21 citas en inglés del cuerpo y de G que tenían la glosa sin paréntesis.
- **P-00-7 (H-89).** §0.1, al pie de la tabla: «Siglas: M.E.AI (Microsoft.Extensions.AI), MAF (Microsoft Agent Framework), SK (Semantic Kernel), MCP (Model Context Protocol), ADR (registro de decisión de arquitectura); glosario en el [Anexo C](#anexo-c)».
  - **Estado:** aplicado: línea de siglas al pie de la tabla de §0.1.
- **P-00-8 (H-80).** Al final de §0, una oración: «Los agentes se construyen y se prueban en el escalón 1 (11, 12). El agente autónomo del escalón 3 se explica sin ejemplo ejecutado, porque ningún pedido de Movilidad Urbana lo necesita ([§8.7](#s8-7))». Se compensa con H-45: el caso queda descrito sólo acá.
  - **Estado:** aplicado: oración al final de §0.5, cierre de §0; compensado con P-01-4.
- **P-00-9 (H-85).** Índice: agregar «[Criterio de elección](#s9-criterio)» bajo §9.
  - **Estado:** aplicado: «Criterio de elección» agregado a la línea de §9 del índice.
- **P-00-10 (H-94).** Encabezado y *front matter*: al cerrar la pasada, cambiar «falta su relectura integral» por «relectura integral de la mesa aplicada (2026-10-27)» y subir la versión.
  - **Estado:** aplicado al cerrar la pasada: `version` 0.10.0 en el *front matter* y encabezado «relectura integral de la mesa aplicada (2026-10-27)».

### 01 · §1

- **P-01-1 (H-64).** «Lo que dibuja la diapositiva»: «*Backend* (pasarela de API, servicio de autenticación, lógica de negocio, microservicios y almacenamiento de archivos) […] *Database* (SQL, NoSQL, la base vectorial otra vez, caché y almacenamiento de objetos); las integraciones de terceros quedan al costado del frontend».
  - **Estado:** aplicado en «Lo que dibuja la diapositiva»; las integraciones de terceros pasan al cierre de la oración, al costado del frontend.
- **P-01-2 (H-66).** Diagrama: el nodo PE pasa a `"Infrastructure/Persistence<br/>EF Core · SQLite"`, y al nodo X se le suma `" · almacén vectorial"`. Las etiquetas van entre comillas, sin paréntesis.
  - **Estado:** aplicado: PE = «Infrastructure/Persistence<br/>EF Core · SQLite»; X suma «· almacén vectorial»; etiquetas entre comillas, sin paréntesis.
- **P-01-3 (H-68).** Reemplazar «cuyo autor no se verificó» por «que lleva la marca visible de su autor; la guía no reproduce la imagen ni su marca, y no verificó qué organización está detrás».
  - **Estado:** aplicado, y la oración siguiente se ajustó («La guía la describe…») para no repetir «no la reproduce».
- **P-01-4 (H-45).** «El caso»: dejar sólo la frase de escenarios cubiertos (ESC-01, ESC-03 y ESC-04 en la demo; ESC-02 y ESC-05 en los ejemplos) y remitir a [§0.3](#s0-3). La cita de [REF-117] se reduce a «escribí la función si alcanza [REF-117]».
  - **Estado:** aplicado: «El caso» queda en dos oraciones con remisión a §0.3; la cita de REF-117 de la tesis queda «escribí la función si alcanza».
- **P-01-5 (H-88).** «La tesis»: «aumentar la complejidad sólo cuando hace falta» → forma de §0.4: «only increasing complexity when needed» (aumentar la complejidad sólo cuando hace falta) [REF-115].
  - **Estado:** aplicado: «only increasing complexity when needed» (aumentar la complejidad sólo cuando hace falta) [REF-115].

### 02 · §2

- **P-02-1 (H-38).** Párrafo después de la tabla de §2.2: reemplazarlo por «En CTX-LOCAL la llamada con herramientas depende del modelo y del servidor: Ollama la anunció para modelos concretos [REF-35] y el código verifica la capacidad antes de correr ([§5.6](#s5-6)). En 08, n01 no llamó a ninguna herramienta aunque se le pedía (conducta, [§8](#s8-ejemplos))». La tasa 4/4 y la mención de `tool_choice` se quedan en §8 y §5.6.
  - **Estado:** aplicado: el párrafo tras la tabla de §2.2 cambia la tasa 4/4 y `tool_choice` por REF-35, §5.6 y la conducta de n01 (comprobada en Ejemplos de §8).
- **P-02-2 (H-11).** Tabla de §2.2, fila CTX-LOCAL. «Contexto de uso»: «Modelo local o en un servidor de la organización (en el laboratorio, Qwen en un servidor Ollama compartido)». «Qué cambia»: «sin costo por token; los datos no salen de la organización, pero en un servidor compartido llegan a un servidor que opera otro y que atiende otros clientes; capacidad y ventana acotadas por el hardware».
  - **Estado:** aplicado tal cual en la fila CTX-LOCAL.
- **P-02-3 (H-22, H-38).** Cierre de §2.5: «Por eso G10 no se deja sólo al prompt: el código rechaza toda cita a un fragmento no recuperado. Esa garantía no detecta la duda: en 07, una pregunta sin respuesta en los requisitos citó un fragmento real y se mostró ([Ejemplos de §7](#s7-ejemplos))». Las tasas de §2.5 y sus preguntas guía se reemplazan por «ver las tasas en Ejemplos de §7».
  - **Estado:** aplicado: el cierre de §2.5 remite a las tasas de Ejemplos de §7 y explica qué no detecta la garantía; n01 comprobado en `R-LLM/07-RAG-Con-Citas.modelo.jsonl` (citó `LocalidadPolicy.RequisitoDeLosHabitantes`, recuperado).
- **P-02-4 (H-21).** Pregunta guía «¿Cómo diseño una pantalla…?»: «en el ejemplo 07, una respuesta con cita válida afirmó un valor que la fuente citada no fija, y otra contradijo la regla que citaba sin que el oráculo pudiera verlo ([§7](#s7-ejemplos))». Sin cifra en §2.
  - **Estado:** aplicado: sin cifra en §2.
- **P-02-5 (H-76).** Nueva pregunta guía: «Mi equipo es .NET y nunca trabajó con modelos: ¿qué tiene que aprender primero?». Respuesta: «Criterio de la guía: el tronco común de [§0.2](#s0-2); después OA-D1, OA-D2, OA-D9 y OA-A2, en ese orden, y la fila ACT-DEV de [§2.3](#s2-3). La respuesta cambia si el equipo ya opera servicios con SLA: entonces conviene sumar antes la ruta ACT-OPS».
  - **Estado:** aplicado como tercera pregunta guía, atada a OA-0.1 (el parche no fijaba OA; es la que trata «por dónde empiezo»).
- **P-02-6 (H-45).** §2.4: la cita de [REF-117] queda como «escribí la función si alcanza [REF-117]».
  - **Estado:** aplicado en §2.4.

### 03 · §3

- **P-03-1 (H-17).** Último párrafo de §3.2: «En agencia, el escalón ordena cuánto del proceso compone el sistema alrededor del modelo y quién fija el camino. En el 1 el modelo elige herramienta y argumentos dentro de un pedido. En el 2 el código fija un camino de varias llamadas. En el 3 el camino lo decide el modelo. El 2 no le da al modelo más decisión que el 1: suma piezas, llamadas y costo [REF-115] (criterio de la guía)».
  - **Estado:** aplicado en el último párrafo de §3.2; además el rótulo del subgrafo del diagrama pasó de «¿cuánto decide el modelo?» a «¿qué puede hacer el modelo?», que repetía la lectura que H-17 corrige.
- **P-03-2 (H-26).** Debajo del árbol de §3.3: «PD-3 y PD-5 son el mismo pedido. Lo que decide la rama es por dónde entra: un endpoint de alta propone (ESC-03, escalón 0) y el chat actúa con herramientas (ESC-04, escalón 1)».
  - **Estado:** aplicado debajo del árbol de §3.3.
- **P-03-3 (H-39).** §3.4: la fila pasa a «una aprobación entre dos peticiones | pedido guardado en el servidor | [§8.5](#s8-5) | 09». Se agrega «una conversación que sobrevive entre peticiones | `AgentSession` serializada | [§8.7](#s8-7) | 11».
  - **Estado:** aplicado: fila corregida (pedido guardado, §8.5, 09) y fila nueva de `AgentSession` (§8.7, 11).
- **P-03-4 (H-15).** §3.1: «el chat usa `IChatClient`» sale de la fila «BACKEND · Business Logic» y pasa a «AI LAYER · Services & Agents»: «sesión de chat, herramientas sobre casos de uso, agentes, workflows».
  - **Estado:** aplicado: «el chat usa `IChatClient`» sale de Business Logic; Services & Agents suma la sesión de chat.
- **P-03-5 (H-64).** §3.1, filas nuevas: «BACKEND · API Gateway, Microservices | no hay: un host ([§13.14](#s13-14)) | —»; «BACKEND · Auth Service | no hay: la sesión aísla y no autentica ([§11.3](#s11-3), [§14.6](#s14-6)) | Presentación, middleware de sesión»; «BACKEND · File Storage; DATABASE · NoSQL, Object Storage | no se usan en el caso | —».
  - **Estado:** aplicado: tres filas nuevas en la tabla de cuatro columnas (lo que el parche daba en tres celdas se repartió en «En .NET», «Capa» y «Ver»).
- **P-03-6 (H-66).** §3.1, fila «DATABASE · Vector DB»: «el almacén de vectores; en la demo, en memoria dentro de Infrastructure/AI; en CTX-PROD, Persistence o un servicio externo ([§13.6](#s13-6))».
  - **Estado:** aplicado; la columna «Capa de la solución» dice «Infrastructure/AI en la demo» y «Ver» suma §13.6.
- **P-03-7 (H-95).** §3.0, fila «embedding»: «Vector con el que se mide parecido de significado, por distancia a otros del mismo modelo [REF-87]».
  - **Estado:** aplicado en la fila «embedding» de §3.0.

### 04 · §4

- **P-04-1 (H-59).** §4.2, fila 2020-05-22 RAG: «memoria no paramétrica que se actualiza cambiando el índice, con procedencia [REF-85]; el artículo ajusta recuperador y generador; el RAG de aplicación de esta guía no entrena nada (criterio de la guía)».
  - **Estado:** aplicado en la fila 2020-05-22 de §4.2 (REF-85 queda sólo en su columna).
- **P-04-2 (H-67).** §4.5, primera fila: «`DesdeTextoController` llama al caso de uso (sin prueba que lo imponga); el chat es la excepción de [§4.4](#s4-4)».
  - **Estado:** aplicado en la primera fila de §4.5.
- **P-04-3 (H-04).** Tabla «Aplicación por escenario», fila ESC-03: después de «el texto de la persona viaja al modelo», agregar «, con lo que haya escrito de sí misma ([§11.4](#s11-4))».
  - **Estado:** aplicado en la fila ESC-03 de «Aplicación por escenario».

### 05 · §5

- **P-05-1 (H-16).** Primer criterio de calidad: «Application recibe su puerto propio por constructor. `IChatClient` lo reciben los adaptadores y la sesión de chat de Infrastructure/AI; un servicio de Application, sólo en un prototipo y registrado como deuda (ADR-01). Un solo archivo de la raíz de composición nombra al adaptador».
  - **Estado:** aplicado como primer criterio de calidad de §5, con remisión a §4.4.
- **P-05-2 (H-07).** §5.3: reemplazar «el caso de uso normaliza la provincia contra `Catalogos`» por «la provincia se normaliza contra `Catalogos`: en la demo, en el adaptador (`NormalizadorDeCatalogo` dentro de `ExtractorDeLocalidad`, ADR-08); en 03, en el caso de uso; en 04, por un puerto de Application implementado en Infrastructure/AI». La pregunta guía «El modelo devolvió un JSON perfecto» se unifica: «…la provincia o el medio se normalizan contra `Catalogos` (en el adaptador en la demo, en Application en 03 y 04) y las reglas validan…».
  - **Estado:** aplicado en §5.3 y en la pregunta guía «El modelo devolvió un JSON perfecto».
- **P-05-3 (H-15).** Diagrama de §5.4: el nodo APP pasa a `"Application · caso de uso<br/>o la sesión de chat de Infrastructure/AI"`.
  - **Estado:** aplicado en el nodo APP del diagrama de §5.4.
- **P-05-4 (H-38).** Tabla de §5.6, fila «Forzar una herramienta»: agregar «La guía no verificó que la API nativa de Ollama ofrezca un equivalente; en los ejemplos la herramienta no se fuerza en ninguna vía». Esta fila es la casa única de `tool_choice` (H-46).
  - **Estado:** aplicado en la fila «Forzar una herramienta» de §5.6.
- **P-05-5 (H-72).** §5.7: «Dos llamadas con la misma pregunta tardaron 91,7 s y 123,1 s [rótulo]. La diferencia es compatible con carga ajena en el servidor compartido, pero no se midió». Casa única de las latencias (H-46).
  - **Estado:** aplicado en §5.7 (casa única de las latencias); §12 y §12.7 remiten acá.
- **P-05-6 (H-73).** §5.7, «Razonamiento encendido por defecto»: agregar al rótulo «observación del sondeo previo a la construcción, no repetida ni recalculada».
  - **Estado:** aplicado en el rótulo de «Razonamiento encendido por defecto».
- **P-05-7 (H-89, H-90).** Pregunta guía de §5: «preví el `false`» → «prevé el `false`». Tabla de §5.5: «el Ollama propio, de 02, 05 y el juez de 15». Las variables remiten a A.12 (H-48).
  - **Estado:** aplicado: «prevé»; la tabla de variables de §5.5 se reemplazó por una oración que nombra las variables y remite a A.12 (H-48), y la corrección «02, 05 y el juez de 15» vive en esa oración y en la fila de A.12, que ya la tenía. Choque resuelto: la fila de la tabla de §5.5 no se corrige porque la tabla deja de existir.

### 06 · §6

- **P-06-1 (H-60).** Definición de §6.1: «RAG recupera fragmentos por parecido. En su forma densa, la de [§7](#s7), por distancia entre embeddings [REF-86], [REF-87]. En la dispersa (BM25, la línea base de [REF-67]), por términos compartidos. Ninguna de las dos cuenta: puede traer las localidades de Chaco porque se parecen».
  - **Estado:** aplicado en la definición de §6.1; BM25 como línea base de REF-67 comprobado en §6.3 y en el descriptor.
- **P-06-2 (H-23).** 05, párrafo después de la tabla de la corrida 4: «Desde p02, aun con una sin-prefijo intercalada, el con-prefijo bajó a 385–487 ms. En esta corrida, eso es compatible con que el motor reutilice el prefijo; con una corrida y el estado de la caché desconocido, no se afirma. En el orden alternado el 6 de 6 es inalcanzable, porque p01 siempre llega en frío: lo que enseña 05 es el procedimiento (prefijo idéntico, duraciones del servidor, vuelta a frío) y por qué con estos datos no se afirma la ventaja, no la ventaja misma». Pregunta guía «¿qué cuida la caché del prefijo y qué la rompe?»: la vuelta a frío pasa a «tardó 17.881,0 ms en esa corrida (descriptivo, una medición)». Condición: que el 17.881,0 sea una duración de la corrida 4, admitida por AC-9.
  - **Estado:** aplicado; condición cumplida: 17.881,0 ms es la vuelta a frío de `R-LLM/05-Contexto-Completo-Con-Prefijo.modelo.corrida-4.jsonl`, corrida admitida por AC-9. La pregunta guía dice «pueden romperla» en lugar de «la rompen».
- **P-06-3 (H-23, H-34).** «Probá --orden calentamiento»: «Probá `--orden calentamiento` (`docker run … -w /src/05-Contexto-Completo-Con-Prefijo … dotnet run -- --fake --orden calentamiento`, como en [E.5](#anexo-e-5)), una exploración no adoptada que agrega una con-prefijo antes del primer par. Explica por qué p01 llega en frío, pero no es el resultado del ejemplo».
  - **Estado:** aplicado con el comando abreviado de E.5.
- **P-06-4 (H-58).** «Qué mirar» de 05: «A diferencia de 01–04 y 07, el prefijo va como mensaje de sistema en la lista y no en `ChatOptions.Instructions`: así `--verificar` comprueba byte a byte el primer mensaje que sale (`CorridaDelPrefijo.cs`). No se verificó que el adaptador ponga `Instructions` en la misma posición».
  - **Estado:** aplicado en «Qué mirar» de 05, que conserva «la pregunta al final».
- **P-06-5 (H-43).** Primera pregunta guía: «el artículo de CAG lo encontró comparable a RAG en la mayoría de sus comparaciones, con un solo modelo y dos conjuntos, y con las salvedades de [§6.3](#s6-3) [REF-67]. Como CAG precarga el mismo texto que el contexto completo, la guía extiende ese resultado a este escalón (criterio de la guía; 05 no midió calidad)».
  - **Estado:** aplicado en la primera pregunta guía de §6.
- **P-06-6 (H-06).** Criterios: «El caso de uso pone lo estable primero…» → «El adaptador (o, en un prototipo, el servicio que arma el pedido) pone lo estable primero…».
  - **Estado:** aplicado en el primer criterio de calidad de §6.

### 07 · §7

- **P-07-1 (H-21).** Párrafo de 07 «Con el mismo rótulo…»: «…cita válida con un valor que el literal citado no fija 1/12, IC95 [0,002; 0,385] (r09: cita la regla de frecuencia y agrega un valor de distancia que esa regla no fija). Aparte, y sin contar en ninguna tasa: en r07, una de las preguntas sin valor verificable, el modelo afirmó lo contrario de la regla que citó y pasó, porque ahí el oráculo sólo comprueba la cita ([§7.4](#s7-4))». El nombre de la métrica en la salida no cambia, porque es la del registro.
  - **Estado:** aplicado: la métrica conserva su nombre de registro entre comillas y se explica; r07 queda aparte, sin tasa. Comprobado r07 y r09 en el registro de 07.
- **P-07-2 (H-22).** Después de la salida de n04: «En n01 la respuesta citó un fragmento recuperado y se mostró. n02, n03 y n04 se rechazaron porque el modelo inventó la fuente, no porque el código detectara la duda».
  - **Estado:** aplicado tras la salida de n04; n02 y n03 citaron «[Fuente: No sé]» y n04 «[Fuente: No disponible]», según el registro.
- **P-07-3 (H-52).** §7.5, MRR: «el rango recíproco es la inversa del rango del primer documento relevante [REF-110]», sin comillas.
  - **Estado:** aplicado sin comillas.
- **P-07-4 (H-63, H-61).** §7.5: «La línea base de azar es una permutación fija con semilla. Sus valores coinciden con la esperanza del azar (1/12, 3/12, MRR ≈ 0,259), pero la p de la comparación pareada depende de esa permutación: vale como piso, no como medida del azar (criterio de la guía)». La regla de las seis discordantes remite a [§10.4](#s10-4) (H-46).
  - **Estado:** aplicado en §7.5; la regla de las seis discordantes se reemplazó por la remisión a §10.4. Se evitó repetir las tres cifras del azar dos veces seguidas.
- **P-07-5 (H-95).** Definición de §7.1: «representación numérica de un texto en la que textos de significado parecido quedan cerca [REF-87], [REF-89]».
  - **Estado:** aplicado en la definición de §7.1.
- **P-07-6 (H-75).** Nueva pregunta guía: «Si los requisitos pasan a ser una guía de uso extensa, ¿cómo la parto?». Respuesta: «Por unidad de sentido, como en [§7.2](#s7-2); como punto de partida, el criterio de Microsoft de 512 tokens con 25 % de solapamiento, más chico en documentos cortos [REF-109]; y se mide hit rate@k antes y después contra el conjunto de oro ([§7.5](#s7-5)). La respuesta cambia si cada regla entra entera en un fragmento: entonces no se parte. Ningún ejemplo de la guía fragmenta (Anexo E.7)».
  - **Estado:** aplicado como pregunta guía atada a OA-D4 (quinta de §7); REF-109 respalda 512 tokens y 25 %.
- **P-07-7 (H-73).** §7.1, el 501 «This server does not support embeddings»: agregar «observación del sondeo previo a la construcción, no repetida ni recalculada».
  - **Estado:** aplicado en el rótulo del 501.
- **P-07-8 (H-06).** «Qué mirar» de 07: «En la demo, el índice y el almacén viven en `Infrastructure/AI/Ayuda/`».
  - **Estado:** aplicado; comprobado `Infrastructure/AI/Ayuda/AyudaConRecuperacion.cs` con `InMemoryVectorStore`.

### 08 · §8

- **P-08-1 (H-06).** Al principio de «Ejemplos de §8»: «En 09, 11, 12 y 16, las herramientas, el servidor de aprobaciones, la política de origen y los workflows están en la carpeta `Application/` del ejemplo, para que se lean junto al caso de uso. En una aplicación por capas van en Infrastructure/AI, como en 08 y en la demo ([§3.1](#s3-1)), porque usan tipos de M.E.AI y de MAF que Application no referencia ([§5.4](#s5-4))».
  - **Estado:** aplicado al principio de «Ejemplos de §8», después de la nota sobre el estímulo del mismo autor.
- **P-08-2 (H-08).** Después del snippet de `HerramientasDelAsistente.cs`: «Qué mirar: `GuardaDeOrigen` envuelve cada escritura antes de la aprobación. `escriturasAprobables` vale `true` por defecto y la demo nunca lo pone en `false`: esa rama existe sólo para que `AprobacionTests` compruebe que una escritura no aprobable se rechaza después de texto no confiable (regla 2, [§11.3](#s11-3)). No se copia a producción: la escritura se monta siempre con `ApprovalRequiredAIFunction`».
  - **Estado:** aplicado tras el snippet de `HerramientasDelAsistente.cs`.
- **P-08-3 (H-17).** §8.1, Definición: la misma frase de P-03-1.
  - **Estado:** aplicado en la Definición de §8.1, que deja de decir «según cuánto decide».
- **P-08-4 (H-18, H-19).** §8.6, «La instancia positiva»: «El escalón 2 es la forma: un camino fijo con un modelo adentro y el verificador en código, el patrón evaluador-optimizador de [REF-115] con el evaluador en código. Un método de C# alcanza para eso. 12 usa `WorkflowBuilder` para comparar las dos variantes cambiando una sola arista: sube de más en el artefacto, no en el escalón. MAF se justifica con checkpoints, pausa humana o pasos en paralelo, como en 10».
  - **Estado:** aplicado: reemplaza la oración de criterio de «La instancia positiva».
- **P-08-5 (H-19).** §8.8, Definición: «Las orquestaciones de MAF son secuencial, concurrente, *group chat*, *handoff* y Magentic [REF-129]. Criterio de la guía: secuencial y concurrente siguen un camino fijo (escalón 2); en *handoff* y Magentic un modelo elige al siguiente agente (escalón 3); *group chat* cae en el 2 o en el 3 según quién elija al siguiente orador, el código o un modelo». Condición: comprobar que [REF-129] enumera las cinco, como cita G.3.
  - **Estado:** aplicado; condición cumplida: G.3 cita literal de REF-129 con las cinco orquestaciones.
- **P-08-6 (H-24).** Pregunta guía «¿De verdad necesito varios agentes…?»: «En Movilidad Urbana la guía usa uno (criterio de la guía): ningún pedido tiene instrucciones que se contradigan. 12 no lo decide: en sus cuatro corridas el corrector nunca se llamó ([§8.8](#s8-8))».
  - **Estado:** aplicado en la pregunta guía.
- **P-08-7 (H-41).** §8.4: «En la demo, PD-5 hace el alta desde el chat con un cambio: valida con `LocalidadRules` antes de armar el pedido, así la persona no aprueba algo que no se puede guardar, y `SaveAsync` vuelve a validar al ejecutar ([§14.3](#s14-3))». §8.5, después de «el que no deja escribir es `SaveAsync`»: «09 deja pasar el 34 a la aprobación para mostrar que aprobar no valida. En una aplicación conviene lo de la demo: validar antes de preguntar (criterio de la guía)».
  - **Estado:** aplicado en §8.4 y en «Aprobar no es validar ni autorizar» de §8.5.
- **P-08-8 (H-77).** §8.5: «Excepción observada con la versión de M.E.AI del [Anexo F](#anexo-f): si el modelo pide una lectura en la misma respuesta que una escritura aprobable, la lectura también pasa por el pedido de aprobación. La demo la muestra como «Consultar … (lectura, no cambia datos)» (`ResolutorDeAprobaciones.cs`)».
  - **Estado:** aplicado como párrafo «Excepción observada» en §8.5; el texto de la demo comprobado en `ResolutorDeAprobaciones.cs` l. 83.
- **P-08-9 (H-78).** Segundo criterio de calidad: «El bucle tiene tope de iteraciones, que comprueba un guion que no para (en 08), y tope de errores seguidos, fijado en el código pero sin prueba propia (B.5, control 7)».
  - **Estado:** aplicado en el segundo criterio de calidad, con remisión a B.5 control 7.
- **P-08-10 (H-10).** §8.9, «Cliente», después de «y descarta el resto»: «La descripción propia vale para las lecturas; una escritura permitida conserva la del servidor. En los dos casos, el esquema de los parámetros sigue siendo el que anunció el servidor, y sus descripciones llegan al modelo: es texto no confiable por procedencia ([§11.3](#s11-3)), como las anotaciones que la especificación pide tratar como no confiables [REF-198]». «Qué mirar» de `ClienteMcp.cs`: «…diga lo que diga el servidor de sí mismo. Sólo la rama de lecturas reemplaza la descripción».
  - **Estado:** aplicado en «Cliente» de §8.9 y en «Qué mirar» de `ClienteMcp.cs`.
- **P-08-11 (H-69).** Extensión de 08: «en otra repitió el identificador de sesión que traía la propia pregunta negativa (`ejemplo-08-b`), y el oráculo leyó sus dígitos como cifras. El modelo no recibe ningún id de sesión de la aplicación ([§8.3](#s8-3))». Respaldo: `Bitacoras/Evidencia/P4-Corridas-Modelo/ext-08.log`.
  - **Estado:** aplicado; `ejemplo-08-b` comprobado en `Evidencia/P4-Corridas-Modelo/ext-08.log` l. 36.
- **P-08-12 (H-34).** «Probá --extension»: «`tools/verificar.sh extension 08-Primera-Herramienta-Solo-Lectura --fake`, o el `docker run` manual de [E.5](#anexo-e-5) con `-- --fake --extension`». Condición: comprobar que `verificar.sh extension` acepta `--fake`.
  - **Estado:** aplicado; condición cumplida: `tools/verificar.sh` acepta `--fake` en las vías (corrida en seco, `via()` l. 367-386).
- **P-08-13 (H-40).** Salida `--fake` de 12: sumar el bloque «costo por variante» textual de `Bitacoras/Evidencia/Arnes/12-Uno-O-Varios-Agentes.fake.log`, con el rótulo «salida guionada (`--fake`): los tokens los fija el guion; no es una medición». La prosa no repite esas cifras.
  - **Estado:** aplicado: el bloque «costo por variante» copiado de `Evidencia/Arnes/12-Uno-O-Varios-Agentes.fake.log` l. 24-26 con el rótulo de salida guionada; la prosa no repite las cifras.
- **P-08-14 (H-56).** §8.6: «La documentación vuelve executor a una función con `BindExecutor`. En la versión del [Anexo F](#anexo-f), `BindExecutor` existe pero recibe una fábrica de executors, y con una función no compila (`CS0411`, no se pueden inferir los tipos). Para una función, el método es `BindAsExecutor`».
  - **Estado:** aplicado en §8.6.
- **P-08-15 (H-96).** §8.2: «En ReAct el modelo escribía razonamientos y acciones intercalados en el texto que generaba, y la aplicación los parseaba [REF-21]».
  - **Estado:** aplicado en §8.2.
- **P-08-16 (H-15).** Diagrama de secuencia de §8.2: el participante pasa a `participant A as "Sesión de chat · Infrastructure/AI"`, o sin comillas si el mermaid actual no las usa.
  - **Estado:** aplicado sin comillas, como el resto de los participantes del diagrama.
- **P-08-17 (H-46, H-47).** §8.4: la definición textual de agencia excesiva se reemplaza por «agencia excesiva, [§11.3](#s11-3)». «70 pruebas…» remite a [§14.5](#s14-5). Las frases de arranque repetidas de «Ejemplos» se quitan.
  - **Estado:** aplicado: §8.4 remite a §11.3 para la definición; «70 pruebas» remite a §14.5; la frase de arranque de «Ejemplos» se quitó (H-47 se extendió a §6, §7, §11 y §12; se conserva en §5, la primera).
- **P-08-18 (H-81).** `AgentSession`: la misma REF en §8.7 y en §9.3 y §9.6. Condición: releer [REF-117], [REF-118], [REF-122] y [REF-140] y quedarse con la que lo dice.
  - **Estado:** aplicado con REF-122: el dossier N4 §2.3 y N6 F12 la registran para `AgentSession` (REF-117 y REF-118 no la nombran en su registro). §8.7 ya la citaba; §9.3 suma REF-122 junto a REF-118 (que respalda `AsAIAgent`) y §9.6 cambia REF-117 por REF-122.

### 09 · §9

- **P-09-1 (H-27).** §9.4, vía 1: el bloque `csharp` pasa a un bloque `text`, con el rótulo «boceto HTTP, no ejecutado; la forma de la respuesta no se contrastó»: `POST /threads` → `thread_id`; `POST /threads/{thread_id}/runs/wait` con `assistant_id` y `input` = «¿Cuántas localidades tengo en Corrientes?». Así se cumple el contrato de §0.4 sin excepciones.
  - **Estado:** aplicado: bloque `text` con `POST /threads` y `POST /threads/{thread_id}/runs/wait` y el pedido de Corrientes, rotulado «boceto HTTP, no ejecutado»; la credencial `X-Api-Key` pasó a «Qué mirar» con REF-146, cuyo descriptor la nombra.
- **P-09-2 (H-54).** §9.8 «Cadencia» y criterio de §9: «MAF publicó una versión estable por semana, aproximadamente, en septiembre y octubre de 2026 [REF-188]».
  - **Estado:** aplicado en §9.8 y en el criterio de elección.
- **P-09-3 (H-53).** §9.8: «… no están en las versiones del Anexo F (compilación de 10 y 11 con esas versiones)», en lugar de [REF-187] como respaldo.
  - **Estado:** aplicado.
- **P-09-4 (H-56).** §9.8, «Documentación por detrás del paquete»: «la página de executors usa `BindExecutor` [REF-126], que en la versión del Anexo F recibe una fábrica y con una función no compila (`CS0411`)».
  - **Estado:** aplicado.
- **P-09-5 (H-88, H-45).** Glosa de «it is perfectly fine to use Semantic Kernel», «Semantic Kernel is now Microsoft Agent Framework!», la descripción de Microsoft.Graph y «Project archived and no longer maintained» en la forma de §0.4. §9.1: la cita de [REF-117] queda como «[REF-117]», sin el texto.
  - **Estado:** aplicado: glosas entre paréntesis para SK, Microsoft.Graph y AutoGen, más las de M.E.AI, Anthropic y LangGraph en §9.1 y §9.4; la cita de REF-117 en §9.1 queda sin texto.

### 10 · §10

- **P-10-1 (H-50).** §10.5, «Qué mirar»: `([§7.5](#s7-5))` → `([§7.4](#s7-4))`.
  - **Estado:** aplicado.
- **P-10-2 (H-20).** §10.6: «Acuerdo con la anotación: 0/10, IC95 [0; 0,308].» → «Acuerdo con la anotación: 0/10, IC95 [0; 0,308], pero sólo porque ninguna de las 10 de calibración dio una salida interpretable. El acuerdo no se midió: se registró la ausencia de salidas legibles». «Ninguna salida fue interpretable, 0/52» → «Ninguna de las 52 llamadas al juez devolvió una salida interpretable (recuento de llamadas, no tasa)».
  - **Estado:** aplicado en §10.6.
- **P-10-3 (H-61).** §10.4, «Comparación pareada»: «…da p < 0,05. Si ningún par discordante va en contra, eso pide al menos 6 a favor (2 · 0,5⁶ = 0,031); si hay alguno en contra, pide más: 7 contra 1 da p = 0,070 (cálculo, no medición). Decide la p, no el conteo». Casa única de la regla (H-46).
  - **Estado:** aplicado; 7 contra 1 da p = 9/128 ≈ 0,070, recalculado.
- **P-10-4 (H-28).** §10.4, después de «Tasa con intervalo»: «El intervalo es el de Clopper-Pearson, que calcula `tools/verificar.sh tasa`. Con M chico es ancho: con 4/4 el piso es 0,398, y eso muestra cuánto no se sabe con cuatro entradas». No se agrega teoría sin fuente.
  - **Estado:** aplicado en la viñeta «Tasa con intervalo», que ya nombraba Clopper-Pearson y `verificar.sh tasa`.
- **P-10-5 (H-62).** §10.1: «Temperatura 0 y semilla fija no garantizan la misma salida entre llamadas ni entre versiones del modelo. En Ollama, la reutilización del prefijo que activa en cada pedido [REF-73] «can cause nondeterministic results» (puede dar resultados no deterministas) [REF-75]; para otros servidores y entre versiones, criterio de la guía».
  - **Estado:** aplicado; la frase literal de llama.cpp está registrada en N3b §2.4 y ya se citaba en §6.4.
- **P-10-6 (H-34).** 15, «Probá otro juez con `OLLAMA_PROPIO_MODEL`»: dar el comando `tools/verificar.sh correr 15-Pruebas-Y-Evaluacion --con-modelo` con la variable exportada, y advertir que la corrida queda con el rótulo del lector (E.5). Condición: comprobar que `correr` toma `OLLAMA_PROPIO_MODEL` del entorno.
  - **Estado:** aplicado con condición resuelta: `correr` pasa `OLLAMA_PROPIO_MODEL` al contenedor (`correr_con_modelo`, l. 317), pero el arnés exige versión y digests del Ollama propio (`propio()`, l. 300); la guía lo dice y manda a E.5 para otro servidor.
- **P-10-7 (H-51).** OA-D9, preguntas de §10: «cliente falso» o «`IChatClient` falso» → «cliente guionado». «Juez» suelto → «LLM juez» después de su primera aparición.
  - **Estado:** aplicado en OA-D9, la pregunta guía de §10 y ADR-10; «juez» suelto pasó a «LLM juez» en la prosa de §10, §13.11 y §14.6 (las salidas del registro no cambian).

### 11 · §11

- **P-11-1 (H-04).** §11.4, antes de «Lo que sale en las trazas»: «**Lo que escribe la persona sí entra.** En ESC-03 el texto libre viaja entero al modelo, con lo que la persona haya escrito de sí misma. El extractor de la encuesta (PD-4) le pide además la edad, si el relato la dice (`Infrastructure/AI/Extraccion/ExtractorDeEncuesta.cs`). Con un servidor propio, ese texto no sale de la organización. Con un servidor compartido o en la nube, llega a un servidor que opera otro. Qué campos personales se extraen con un modelo, y hacia qué servidor, lo decide ACT-SEC. La garantía del tipo vale para lo que devuelve una herramienta, no para lo que escribe la persona».
  - **Estado:** aplicado antes de «Lo que sale en las trazas», con la ruta completa del extractor.
- **P-11-2 (H-09).** §11.3, «Política de origen»: reemplazar «Vive en la frontera de la herramienta, en 16 ([Ejemplos](#s11-ejemplos)) y en la demo (`GuardaDeOrigen`, [§8](#s8-ejemplos)).» por «La regla 1 la ejerce 16 en su variante «origen»; en la demo, la ayuda la cumple por diseño, porque va fuera del chat. El chat de la demo no la aplica: si el historial ya trae nombres leídos, el pedido empieza marcado y rige la regla 2 (`GuardaDeOrigen`, [§8](#s8-ejemplos))».
  - **Estado:** aplicado en la viñeta «Política de origen».
- **P-11-3 (H-12).** §11.1, fila LLM10. «Control mínimo»: «largo máximo del texto que viaja al modelo; límite de pedidos simultáneos; topes del bucle; sin reintentos (los dos primeros, criterio de la guía)». «Dónde»: [§5.5](#s5-5), [§8.2](#s8-2), [§12.3](#s12-3).
  - **Estado:** aplicado en la fila LLM10.
- **P-11-4 (H-15).** Diagrama de §11.1: «política de origen · pedido de aprobación» pasa del nodo APL al nodo IA. La flecha se invierte: `IA -->|"herramientas sobre casos de uso"| APL`, y se agrega `PRES -->|"chat"| IA`. En las etiquetas, sin paréntesis.
  - **Estado:** aplicado: los dos rótulos pasan al nodo IA; `IA -->|"herramientas sobre casos de uso"| APL` y `PRES -->|"chat"| IA`.
- **P-11-5 (H-10).** §11.5, «Lado cliente»: «el cliente reemplaza la descripción de las lecturas; el esquema de parámetros y la descripción de las escrituras permitidas siguen siendo del servidor, y se revisan antes de permitir la herramienta».
  - **Estado:** aplicado en «Lado cliente».
- **P-11-6 (H-79).** §11.2: «…por el `Nombre` de una localidad dada de alta por el ABM, texto que escribió una persona y no la aplicación; en CTX-PROD con datos compartidos entre usuarios, también por lo que cargó otra persona».
  - **Estado:** aplicado en la Definición de §11.2.
- **P-11-7 (H-46, H-47).** §11.3 es la casa de agencia excesiva. «Aprobar no es autorizar» vive en la pregunta guía de §11; §11.3 la remite. En «Ejemplos de §11», sólo el snippet de `ServidorMcp.cs` y «Recorrido, comandos y salida en [§8](#s8-ejemplos)».
  - **Estado:** aplicado: en «Ejemplos de §11», 13 queda con el snippet de `ServidorMcp.cs` y la remisión a §8; «70 pruebas» remite a §14.5. §11.3 ya remitía a la pregunta guía sobre autorización.

### 12 · §12

- **P-12-1 (H-03, H-13).** §12.10: «Toca **ADR-09, pipeline transversal** ([§13.10](#s13-10)): opciones del proveedor en una capa única pegada al adaptador, telemetría y registro en el pipeline del chat, contenido sólo en `Development` y caché sólo con pedidos idénticos. La demo no limita la concurrencia: en CTX-PROD hace falta ese límite ([§12.3](#s12-3))».
  - **Estado:** aplicado en §12.10.
- **P-12-2 (H-13).** Criterio de calidad «Toda llamada al modelo pasa por `UseOpenTelemetry`…»: agregar «(en la demo, sólo el chat: [§12.8](#s12-8))». §12.8, fila Telemetría: «`UseOpenTelemetry` sólo en el chat, sin exportador; PD-2, PD-3 y PD-4 no emiten tramos».
  - **Estado:** aplicado en el criterio de calidad y en la fila Telemetría de §12.8.
- **P-12-3 (H-12).** §12.8, fila «Concurrencia y costo», columna «En la demo»: «sin límite de concurrencia, sin largo máximo del texto ni caché».
  - **Estado:** aplicado.
- **P-12-4 (H-11, H-55).** §12.4, al final de «Servidor compartido»: «Para CTX-SENS cuenta como un tercero: el texto de la persona y los resultados de las herramientas llegan a él ([§11.4](#s11-4))». Las viñetas pasan a cuatro, en el orden de ADR-03: servidor propio (Ollama), servidor compartido, Foundry Local en el dispositivo, nube.
  - **Estado:** aplicado: cuatro viñetas en el orden de ADR-03, con el párrafo «Servidor compartido» convertido en la segunda.
- **P-12-5 (H-57).** §12.7, «Advertencia»: «Criterio de la guía: el cliente del modelo no toma su `HttpClient` de `IHttpClientFactory` cuando los *service defaults* activan la resiliencia. Así lo hace la fábrica de [§5.5](#s5-5), que lo crea con `new` y una espera de diez minutos, fuera de la fábrica. Si tiene que salir de `IHttpClientFactory`, fijá el *attempt timeout* y el *total request timeout* en al menos diez minutos [REF-194], y un `ShouldHandle` que no reintente [REF-195]».
  - **Estado:** aplicado en «Advertencia» de §12.7, que además deja de repetir las latencias y remite a §5.7.
- **P-12-6 (H-70).** «Qué mirar» del `compose.yaml`: «`Development` también expone la descripción OpenAPI y Scalar, y muestra el detalle de los errores. Sirve para el prototipo; fuera de él, el ambiente va en `Production` y la telemetría sin contenido ([§12.2](#s12-2))».
  - **Estado:** aplicado en «Qué mirar» del `compose.yaml`.
- **P-12-7 (H-29).** §12.6, después del diagrama: «Si Ollama corre en tu máquina, los contenedores no lo ven como `localhost`: ver [E.3](#anexo-e-3)». Es la casa única de «localhost es el contenedor» (H-46).
  - **Estado:** aplicado como remisión a E.3 dentro del párrafo que ya decía que `localhost` es el contenedor.
- **P-12-8 (H-72, H-73).** Introducción de §12: «…y los tiempos por clase previstos de antemano no acotaron la cola en 07, 16 y 17 (registros de cada pieza)». Las latencias remiten a [§5.7](#s5-7). En «Servidor compartido», a lo que viene del sondeo: «observación del sondeo previo a la construcción, no repetida ni recalculada».
  - **Estado:** aplicado en la introducción (sin cifras, remite a §5.7; «pesimistas por clase que no acotan la cola» admitido por AC-9, fila «Sondas y tiempos») y en el rótulo de «Servidor compartido»; la pregunta guía «¿Por qué mi modelo local tarda minutos?» también remite a §5.7.
- **P-12-9 (H-89).** §12.1: «La versión de M.E.AI que usan los ejemplos emite los nombres de métricas de una versión anterior de la convención [REF-171] ([Anexo F](#anexo-f))».
  - **Estado:** aplicado.
- **P-12-10 (H-93).** §12.8 y §12.9: «circuito de realimentación» → «ciclo de realimentación».
  - **Estado:** aplicado en §12.8 y §12.9.

### 13 · §13

- **P-13-1 (H-14).** ADR-01. En Alternativas: «(d) para el chat, la página inyecta una sesión de chat de Infrastructure/AI, sin puerto de Application». En Decisión: «(c) cuando el prompt es detalle de la funcionalidad; para el chat, (d): la funcionalidad es la conversación, la sesión no tiene reglas propias y toda escritura pasa por herramientas sobre casos de uso». En Consecuencias: «Presentación depende de un tipo concreto de Infrastructure/AI, excepción a la regla de dependencia [REF-182]; ninguna prueba de arquitectura la acota a `Chat.razor`». En «Deja de valer si»: «…o la sesión de chat suma lógica de negocio o se expone por la API».
  - **Estado:** aplicado en ADR-01 (alternativa d, decisión, consecuencias y «deja de valer si»).
- **P-13-2 (H-17, H-24).** ADR-07. Contexto: «Cada escalón suma piezas y costo; sólo en el 3 el modelo decide el camino». Decisión: «…y un agente, por criterio de la guía; 12 sólo muestra cómo medirlo ([§8.8](#s8-8))».
  - **Estado:** aplicado en ADR-07.
- **P-13-3 (H-07, H-71).** ADR-08. Consecuencias: «Criterio de la guía: normalizar traduce la salida del modelo y va en el adaptador; 03 y 04 la muestran en Application para aislar el mecanismo». Confianza: «Alta, por la garantía del código (`GarantiaDelTexto`) y sus pruebas sin modelo. Como dato descriptivo, no como respaldo: en la extensión de 03, 0 de 4 propuestas de habitantes sin el dato, IC95 [0; 0,602]».
  - **Estado:** aplicado en ADR-08; «GarantiaDelTexto» es de 03, y se nombró también `GarantiaNumerica`, la de la demo, que es la que lista «Demo».
- **P-13-4 (H-13).** ADR-09, Consecuencias: «Sólo el pipeline del chat emite tramos: los extractores (PD-3, PD-4) y la ayuda (PD-2) usan el cliente base, que no lleva `UseOpenTelemetry`. En CTX-PROD la telemetría va en el cliente base, por encima de la capa de opciones, para cubrir toda llamada (criterio de la guía)».
  - **Estado:** aplicado en ADR-09.
- **P-13-5 (H-20).** ADR-10, Consecuencias: «acuerdo 0/10, IC95 [0; 0,308]» → «acuerdo 0/10, IC95 [0; 0,308], sólo porque ninguna salida de calibración se pudo leer: el acuerdo no se midió».
  - **Estado:** aplicado en ADR-10.
- **P-13-6 (H-67).** ADR-11, Consecuencias: «Las cuatro reglas cubren Domain, el SDK y las herramientas. No cubren que Presentación entre a Infrastructure/AI sólo por el chat ni que Application use sólo `.Abstractions`: con capas como carpetas, esas dos quedan a revisión y, como deuda, a una quinta regla».
  - **Estado:** aplicado en ADR-11.
- **P-13-7 (H-09).** ADR-06, «Confianza»: después de la lista de pruebas, «(la primera comprueba la opción `conEscrituras: false`, no su uso en el chat)».
  - **Estado:** aplicado con corrección: la prueba que ejerce `conEscrituras: false` es la segunda de la lista (`ContextoNoConfiable_SinHerramientasDeEscritura`, como dice B.5), no la primera; la aclaración va junto a ella.
- **P-13-8 (H-55).** ADR-03, Alternativas: (a) servidor propio, (b) servidor compartido, (c) Foundry Local en el dispositivo, (d) nube. El título del plan se conserva.
  - **Estado:** aplicado: cuatro alternativas; título conservado.
- **P-13-9 (H-54).** §13.1, pregunta guía: «MAF publicó una estable por semana, aproximadamente, en septiembre y octubre de 2026 [REF-188]».
  - **Estado:** aplicado en la pregunta guía de §13.1.
- **P-13-10 (H-51).** §13.11: «cliente falso» → «cliente guionado». El título de ADR-07 queda «Escalón de agencia» (H-51 c).
  - **Estado:** aplicado: «cliente guionado» en ADR-10; título «ADR-07 Escalón de agencia», y las remisiones de §8.10, §9 y B.2 dicen «escalón de agencia».

### 14 · §14

- **P-14-1 (H-65).** §14.2. El subgrafo pasa a `"AI LAYER · adaptadores en Infrastructure/AI<br/>sus puertos, en Application"`. La oración: «Las dos excepciones a la regla de que Presentación entra por un caso de uso ([§3.1](#s3-1)) van rotuladas. El chat entra por la sesión de chat y escribe sólo por herramientas sobre casos de uso. La ayuda entra por el puerto `IAyuda` y no escribe ni lee datos de la sesión. El principio rector se cumple en las dos».
  - **Estado:** aplicado en el subgrafo y en la oración de «Qué mirar» de §14.2.
- **P-14-2 (H-97).** §14.1, tabla de delta: «tres puertos de IA, tres casos de uso, `LocalidadPropuesta` y `EncuestaPropuesta` con campos anulables, y `RespuestaDeAyuda`». Controllers: «`DesdeTextoController`, `AyudaController` y sus contratos (`Contracts/DesdeTexto.cs`, `Contracts/Ayuda.cs`); ninguna ruta de chat».
  - **Estado:** aplicado; comprobados `EncuestaPropuesta`, `RespuestaDeAyuda` y `Contracts/DesdeTexto.cs`, `Contracts/Ayuda.cs`.
- **P-14-3 (H-32).** §14.5: «`tools/demo.sh host guion`, después de `pruebas` o de `build` (no compila), levanta la página en http://127.0.0.1:8080 (`PUERTO_HOST` cambia el puerto); `host modelo` hace lo mismo con el cliente real. Si la página no responde, `docker logs` del contenedor que levanta `demo.sh` muestra el motivo».
  - **Estado:** aplicado; `PUERTO_HOST` y `dotnet run --no-build` comprobados en `Demos/…/tools/demo.sh` l. 147-156. No se nombra el contenedor.
- **P-14-4 (H-74).** §14.3: «Los tres humos pasaron su oráculo. El de PD-6 se repitió, porque la primera corrida falló por un defecto de la aserción de la prueba, no del modelo». Sin el resultado de la primera, como pide AC-9.
  - **Estado:** aplicado sin el resultado de la primera corrida.
- **P-14-5 (H-12).** §14.6, viñeta nueva: «**Consumo.** Ningún endpoint limita el largo del texto ni los pedidos simultáneos, y cada llamada puede esperar diez minutos: en CTX-PROD van los dos límites antes de exponer la demo (LLM10, [§11.1](#s11-1))».
  - **Estado:** aplicado como viñeta nueva de §14.6.
- **P-14-6 (H-83).** Preguntas guía, tercera: «la sesión repartida por zona» → «la sesión por encabezado en `/api` y por cookie en las páginas».
  - **Estado:** aplicado.
- **P-14-7 (H-01, H-48).** §14.5: de la lista de variables, sólo las que agrega la demo (`EMB_PLAN`, `ASISTENTE_MODO`), con remisión a [A.12](#anexo-a-12). La línea de `localhost` remite a §12.6.
  - **Estado:** aplicado: §14.5 nombra sólo `EMB_PLAN` y `ASISTENTE_MODO`, remite a A.12 y a §12.6.

### 15 · §15

- **P-15-1 (H-05, H-33, H-35).** Ítem 12: «corré, con el SDK en contenedor como en [E.5](#anexo-e-5), `docker run --rm -u "$(id -u):$(id -g)" -e HOME=/tmp -v "$PWD/Examples":/src -w /src/15-Pruebas-Y-Evaluacion mcr.microsoft.com/dotnet/sdk:10.0 dotnet test --filter "Category!=LLM"`, y lo mismo con `"Category=LLM"`, sin ningún Ollama. Después, `tools/recalcular-oraculos.sh "${RLLM_DIR:-Examples/registros}"/15-Pruebas-Y-Evaluacion.jsonl` ([A.12](#anexo-a-12))».
  - **Estado:** aplicado en el ítem 12, con la ruta por defecto del arnés (`Examples/registros`, cabecera de `verificar.sh`).
- **P-15-2 (H-26).** Ítem 3, respuesta: «El tercero escribe. Si entra por el alta desde texto, alcanza el escalón 0 de agencia, como PD-3: el modelo propone y la persona confirma en el formulario. Sólo si llega al chat entre otros pedidos hace falta el escalón 1 con aprobación, como PD-5».
  - **Estado:** aplicado en el ítem 3.
- **P-15-3 (H-18).** Ítem 9: «Escalón 2: camino fijo con el verificador en código. Un método alcanza; el workflow de MAF entra si hace falta reanudar o pausar».
  - **Estado:** aplicado en el ítem 9.
- **P-15-4 (H-42).** Ítem 13, criterio: «Las alternativas descartadas tienen fuente (pedir de más [REF-92]; lo del medio de un contexto largo se usa peor [REF-84]; el escalón 0, [§6.2](#s6-2)). La elegida, k = 3, se declara criterio de la guía y se apoya en la medición de [§7.5](#s7-5). §13.15 vale cuando ninguna alternativa tiene fuente».
  - **Estado:** aplicado en el ítem 13; se quitó la oración anterior que decía que el ADR no se escribe sin fuente para cada alternativa.
- **P-15-5 (H-04).** Ítem 24: «y nada con `Nombre` ni `Edad` entra al contexto» → «y ninguna herramienta pone `Nombre` ni `Edad` en el contexto. Lo que la persona escribe en el chat o en PD-4 sí sale hacia el servidor del modelo». Ítem 23: «LLM02 en CTX-NUBE, porque ese texto sale de la organización» → «LLM02, porque el relato puede traer la edad y el extractor la pide: en CTX-NUBE o con un servidor compartido, ese dato sale hacia otro operador».
  - **Estado:** aplicado en los ítems 23 y 24.

### A · Anexo A

- **P-A-1 (H-01).** A.12, fila `EMB_PLAN`: «| `EMB_PLAN` | `EMB-B` | `EMB-A`, `EMB-B` o `EMB-C`. Con `EMB-C` no hay modelo de embeddings, y 06, 07 y la ayuda de la demo se rotulan «no ejecutado contra un modelo de embeddings» ([§7](#s7)). Otro valor se rechaza al arrancar |».
  - **Estado:** aplicado en la fila `EMB_PLAN` de A.12; comprobado contra `ConfiguracionDelModelo.cs` y el README de la demo.
- **P-A-2 (H-48).** A.12 es la tabla única de variables. Se le suman las filas que hoy sólo están en §5.5 y §7.1, que después remiten.
  - **Estado:** aplicado: A.12 ya tenía las filas de §5.5 y §7.1; esas secciones (y §12.5, E.3 y §14.5) remiten a A.12.
- **P-A-3 (H-86).** Introducción: «Cada plantilla lleva la letra A y el número de la sección para la que sirve. §1–§3 y §9 no dejan plantilla. A.14 sirve para el Anexo F y conserva su número por las remisiones».
  - **Estado:** aplicado en la introducción del Anexo A.

### B · Anexo B

- **P-B-1 (H-16).** B.1, primer ítem: el mismo texto de P-05-1.
  - **Estado:** aplicado en B.1, conservando el «Se verifica».
- **P-B-2 (H-13).** B.3, ítem 4: «Toda llamada pasa por `UseOpenTelemetry` (en la demo, sólo el chat: [§12.8](#s12-8))».
  - **Estado:** aplicado.
- **P-B-3 (H-57).** B.3, el ítem de resiliencia: «el `HttpClient` del modelo, fuera de `IHttpClientFactory` o con las esperas de [§12.7](#s12-7)».
  - **Estado:** aplicado.
- **P-B-4 (H-04).** B.4, ítem 2: «Está decidido qué datos llegan a qué modelo. Las herramientas y la recuperación no ponen `Nombre` ni `Edad` en el contexto. El texto que escribe la persona sí entra, y PD-4 extrae la edad. En CTX-NUBE, o con un servidor compartido, ese texto sale hacia quien opera el servidor ([§11.4](#s11-4))».
  - **Estado:** aplicado.
- **P-B-5 (H-09).** B.5, control 4, «Se verifica con»: «`ContextoNoConfiable_SinHerramientasDeEscritura`, que prueba que `Crear(conEscrituras: false)` no monta escrituras; el chat de la demo no usa esa vía y aplica la regla 2».
  - **Estado:** aplicado en la columna «Se verifica con» del control 4.
- **P-B-6 (H-10).** B.5, control 9: «con la descripción del cliente en las lecturas; el esquema de parámetros del servidor se revisa antes de permitir la herramienta».
  - **Estado:** aplicado.
- **P-B-7 (H-77).** B.5, control 3: agregar la excepción de P-08-8, con remisión a [§8.5](#s8-5).
  - **Estado:** aplicado en el texto del control 3.

### C · Anexo C (sin archivo en `secciones/`; se parchea en la guía)

- **P-C-1 (H-51).** (a) Alias de «contexto de uso»: sólo «CTX-». (b) Alias de «herramienta»: «tool»; se quita «función». (c) Canónico: «escalón de agencia» (con «escalera de agencia»); «escalón de orquestación» pasa a alias. (e) En «cliente guionado», alias «doble de `IChatClient`». (d) Filas nuevas, cada una con su casa: contexto fijo ([§6.2](#s6-2)), dato exacto o carril aparte ([§6.1](#s6-1)), conjunto de oro ([§10.7](#s10-7), [REF-114]), política de origen ([§11.3](#s11-3), criterio de la guía), garantía del código ([§10.1](#s10-1)), caché de respuestas y caché de prefijo ([§6.4](#s6-4)), MRR ([§7.5](#s7-5), [REF-110]), capa única de opciones ([§5.4](#s5-4)), servidor de chat, servidor compartido y Ollama propio ([E.3](#anexo-e-3)), agencia excesiva ([§11.3](#s11-3)), inyección directa e indirecta ([§11.2](#s11-2)). Condición: cada fila nueva se escribe con la definición que ya da su casa, sin redactar una nueva.
  - **Estado:** aplicado: (a), (b), (c) y (e) completos; (d) con once filas nuevas, cada una con la definición de su casa (contexto fijo, dato exacto, cachés, capa única de opciones, agencia excesiva, política de origen, inyección, MRR, conjunto de oro, garantía del código, servidores).
- **P-C-2 (H-17).** «Escalón de agencia»: «Ordena por complejidad de orquestación; en el 3, el camino lo decide el modelo». «Workflow»: «Más estrecho que [REF-115], que incluye patrones donde el modelo elige la ruta (criterio de la guía)».
  - **Estado:** aplicado en «escalón de agencia» y «workflow».
- **P-C-3 (H-16).** «Puerto»: «Interfaz que expresa lo que el núcleo necesita. El puerto propio (`IExtractorDeLocalidad`) se define en Application; el puerto técnico (`IChatClient`) lo define M.E.AI y lo consumen los adaptadores».
  - **Estado:** aplicado.
- **P-C-4 (H-62).** «Temperatura»: el mismo respaldo que §10.1 ([REF-73], [REF-75]) y el mismo que §4.1 para la definición, de modo que las dos casas citen igual.
  - **Estado:** aplicado: la fila de §4.1 y la del glosario citan [REF-14], [REF-73], [REF-75] y remiten a §10.1.
- **P-C-5 (H-92).** IC95, Respaldo: «método estándar de Clopper-Pearson; la regla M ≤ 12 es criterio de la guía».
  - **Estado:** aplicado.

### D · Anexo D (sin archivo en `secciones/`)

- **P-D-1 (H-52).** REF-110: «[sin título registrado: fórmula de RRF, k = 60; definición de rango recíproco]».
  - **Estado:** aplicado.
- **P-D-2 (H-53).** REF-187: «[sin título registrado: API de contenido de paquetes: `index.json` (versiones) y `{id}.nuspec` (descripción y dependencias)]», con las dos URL plantilla y los ids consultados nombrados en el Anexo F.
  - **Estado:** aplicado con las dos URL plantilla; los ids remiten al Anexo F.
- **P-D-3 (H-87).** (a) REF-192 pasa a D.3; REF-193–195 a D.10; REF-196–199 a D.6; REF-74 a D.10. (c) «2026-10-25/26» → «consultado 2026-10-25 y 2026-10-26», y lo mismo para «/27». (e) Autores: «Apellido, Inicial.», por ejemplo «Schluntz, E.; Zhang, B.» en REF-115. Condición: confirmar los apellidos en la fuente antes de reescribirlos. (f) REF-189 suma la URL de `q=graphlang`. (g) La regla de la introducción pasa a «junto a la afirmación que respalda».
  - **Estado:** aplicado en parte: (a) reubicadas REF-192 (D.3), REF-74 y REF-193–195 (D.10), REF-196–199 (D.6), en orden de número; (c) el Anexo D no tenía fechas con barra: la única, en F.4, pasó a «del 2026-10-25 al 2026-10-27»; (f) y (g) aplicados. (e) no aplicado: la condición falló, la página de REF-115 firma «Erik S.» y no hay apellido registrado para el primer autor; los demás autores tampoco tienen iniciales registradas. Queda pendiente en 07-Redaccion.
- **P-D-4 (H-49).** REF-164 y REF-192 a REF-201: descriptor corto entre corchetes. Las citas textuales quedan en la frase del cuerpo que respaldan. Condición: antes de recortar, verificar que cada cita esté en el cuerpo.
  - **Estado:** aplicado: REF-164 y REF-192–201 con descriptor corto. Las citas literales estaban en el cuerpo sólo para REF-193; en las demás el cuerpo parafrasea con su REF, y el descriptor nombra el fragmento exacto (miembro, sección o campo) para ubicarla. No se llevaron literales nuevos al cuerpo, porque iba contra el objetivo de la compresión.
- **P-D-5 (H-91).** REF-46: «(página de la API en 10.10.1; los ejemplos compilan contra 10.11.0, Anexo F)».
  - **Estado:** aplicado.

### E · Anexo E

- **P-E-1 (H-06, H-84).** E.1: «Los ejemplos aíslan un mecanismo y no siguen todas las reglas de ubicación de [§4](#s4): varios ponen instrucciones, `IChatClient`, herramientas, el almacén o el workflow bajo `Application/`, lo que ADR-01 admite sólo en un prototipo y como deuda. La ubicación de referencia es la de la demo ([§14.2](#s14-2))». Y: «La Parte III (05 a 07) y la Parte IV (08 a 13) dependen de §5 y no una de la otra: quien se trabe en 05 o 07 puede seguir por 08 y volver después».
  - **Estado:** aplicado en E.1.
- **P-E-2 (H-48).** E.2 se reduce a «Pasos y cierre: [§14.3](#s14-3)».
  - **Estado:** aplicado: E.2 queda en una línea con remisión a §14.3.
- **P-E-3 (H-29).** E.3, al final: «Si Ollama corre en tu máquina, los contenedores no lo ven como `localhost`: el servidor tiene que escuchar fuera del *loopback*, y se exporta la dirección de la puerta de enlace de la red *bridge* de docker (la da `docker network inspect bridge`): `export OLLAMA_ENDPOINT=http://<puerta-de-enlace>:11434`, y lo mismo con `OLLAMA_PROPIO_ENDPOINT`. El valor por defecto `localhost` sólo sirve para un `dotnet run` fuera de contenedor». Condición: el nombre de la variable que hace escuchar a Ollama fuera del *loopback* entra sólo si [REF-55] lo documenta; si no, la frase queda sin la variable. Respaldo del comportamiento: `tools/verificar.sh` l. 78-88 y `Demos/…/tools/demo.sh` l. 63.
  - **Estado:** aplicado sin nombrar la variable que hace escuchar a Ollama fuera del *loopback* (REF-55 no la registra).
- **P-E-4 (H-31).** E.3, después de «aborta sin llamar si hay otro»: «Con un solo servidor para el chat y para el Ollama propio, esperá a que se descargue el modelo de la fase anterior (`keep_alive` [REF-55]) o descargalo antes de la fase de chat; si no, la fase aborta sin llamar». Lo mismo, en una línea, en E.5, entre `embeddings` y `humo`. Sin los «cinco minutos», salvo que [REF-55] los dé.
  - **Estado:** aplicado en E.3 y en E.5; sin «cinco minutos» en esa oración (REF-55 registra `keep_alive`; la cifra ya está en §12.4).
- **P-E-5 (H-33, H-36).** E.3: «Los scripts corren el SDK como 1000:1000; con otro UID, la carpeta de registros tiene que admitir escritura de ese usuario. Para reproducir con el SDK de las corridas, fijá la imagen: `export SDK_IMAGEN=mcr.microsoft.com/dotnet/sdk:10.0.403` (la usan `verificar.sh` y `demo.sh`). Con `sdk:10.0` sin fijar, un SDK más nuevo puede sumar advertencias que `-warnaserror` vuelve errores». E.5, `docker run` manual: `-u 1000:1000` → `-u "$(id -u):$(id -g)"`.
  - **Estado:** aplicado; `SDK_IMAGEN` comprobado en `tools/verificar.sh` l. 49 y `Demos/…/tools/demo.sh` l. 31.
- **P-E-6 (H-30).** E.5, después del `docker run` manual: «Con otro Ollama u otro modelo, el arnés no corre, y es a propósito: así tus cifras no se mezclan con las de la guía. Para correr igual, usá el mismo `docker run` con las variables del servidor y sin `--fake`. Lo que salga lleva tu rótulo (modelo, digest, versión, fecha) y no se compara con el de la guía». Condición: confirmar en `Examples/README.md` la forma exacta de la corrida contra el modelo fuera del arnés, y copiarla de ahí.
  - **Estado:** aplicado con condición resuelta: `Examples/README.md` no trae la corrida contra el modelo fuera del arnés; la forma (variables por nombre, sin `--fake`) se tomó de `correr_con_modelo` en `tools/verificar.sh`, y se cita ese archivo.
- **P-E-7 (H-35).** E.6, paso 4: `tools/recalcular-oraculos.sh "${RLLM_DIR:-Examples/registros}"/*.jsonl`, y agregar: «con el arnés, el registro queda en `Examples/registros/`; con el `docker run` manual, en `registros/` dentro de la carpeta del ejemplo».
  - **Estado:** aplicado en el paso 4 de E.6.
- **P-E-8 (H-98).** E.4: fijar el comentario «# compila con -warnaserror y corre --fake --verificar, sin red».
  - **Estado:** aplicado en los dos comentarios del bloque de E.4.
- **P-E-9 (H-75).** E.7: «La fragmentación no se ejecutó: el corpus de requisitos entra entero, regla por regla».
  - **Estado:** aplicado como fila nueva de la tabla de E.7.

### F · Anexo F (sin archivo en `secciones/`)

- **P-F-1 (H-02).** F.1: las filas `Microsoft.Extensions.Hosting` y `OpenTelemetry.Extensions.Hosting · OpenTelemetry.Exporter.OpenTelemetryProtocol` pasan a una nota al pie de la tabla: «Declarados en `Examples/Directory.Packages.props` sin que ningún proyecto los referencie en esta versión de los ejemplos; no se usan». Se quita «sólo en las consolas». Si se confirma con el registro de restauración que `Microsoft.Agents.AI.Abstractions` llega sólo como transitivo, se agrega «(sólo transitivo de `Microsoft.Agents.AI`)»; si no, queda como está.
  - **Estado:** aplicado: filas quitadas y nota al pie de F.1. `Microsoft.Agents.AI.Abstractions` queda como estaba: no hay registro de restauración local que muestre que llega sólo como transitivo (sólo consta su `PackageVersion`).
- **P-F-2 (H-53).** F.2, fila Microsoft.Graph: el respaldo pasa al `.nuspec` de REF-187 ampliada (P-D-2).
  - **Estado:** aplicado: respaldo «[REF-187] (`.nuspec`)» y glosa de la descripción.

### G · Anexo G

- **P-G-1 (H-19).** G.3, «El patrón y su costo», después de la cita: «Anthropic lo cuenta entre los workflows; la guía lo pone en el 3 porque el modelo fija las subtareas (criterio de la guía)».
  - **Estado:** aplicado.

### 07-Redaccion.md

- **P-07R-1 (H-44).** Registrar: el conteo de la relectura (Parte 0 1.860/1.400, Anexos 12.277/7.430, total 49.991/44.330, medido con un script ad hoc con la regla del plan); las compresiones H-45 a H-49 aplicadas; el exceso remanente de la Parte 0 (la tabla de OA ocupa casi la mitad del tope) y de los Anexos (el Anexo D crece con cada fuente) como motivo registrado, según la regla del plan §C; y `tools/contar.sh` como pendiente fuera de alcance.
  - **Estado:** aplicado en `Bitacoras/07-Redaccion.md`.
- **P-07R-2.** Registrar los pendientes de código descartados acá: retirar los tres `PackageVersion` sin uso, alinear el README de 15, la descripción del cliente en las escrituras de 13 y la quinta regla de arquitectura.
  - **Estado:** aplicado en `Bitacoras/07-Redaccion.md`.

## 7. Orden de aplicación sugerido

1. S1 y S2 de seguridad: P-A-1, P-12-1, P-11-1, P-B-4, P-15-5, P-04-3, P-08-2, P-11-2, P-B-5, P-13-7, P-08-10, P-11-5, P-B-6, P-02-2, P-12-4, P-11-3, P-12-3, P-14-5.
2. Resto de S2 (arquitectura, evaluación, didáctica, desarrollo).
3. S3 y S4.
4. Compresiones H-45 a H-49, después de las inserciones, para medir el conteo final.
5. Volver a correr las compuertas: anclas, mermaid, REF citados contra el Anexo D, R-PRIV, RD-PO y AC-9 sobre las cifras tocadas (07, 10, 13, 06). Después, P-00-10.

## 8. Aplicación (2026-10-27)

Todos los parches de §6 se aplicaron en `Guides/IA/Dot-Net-Integration-AI-Layer-Guide/Dot-Net-Integration-AI-Layer-Guide.md`, que pasa a la versión 0.10.0. Cada uno tiene su línea «Estado». Tres se ajustaron porque chocaban con el código, con la evidencia o con otro parche: P-03-5, P-05-7 y P-13-7. Cuatro resolvieron su condición de otra forma: P-10-6, P-E-6, P-F-1 y P-D-4. Uno quedó en parte: P-D-3 (e). La guía no tiene `secciones/` resincronizadas: el archivo de la guía es la fuente. Las compuertas del punto 5 de §7 se corrieron después de los parches, y la extensión y los pendientes quedaron en `Bitacoras/07-Redaccion.md`.
