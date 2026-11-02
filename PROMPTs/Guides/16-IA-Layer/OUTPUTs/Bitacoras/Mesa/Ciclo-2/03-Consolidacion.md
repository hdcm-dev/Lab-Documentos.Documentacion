# Ciclo 2 · Consolidación del relator (M§4.2)

Fecha: 2026-10-26. Objeto: `../../../04-Plan-De-Integracion.md`, ESTRUCTURA APROBADA v1. Insumos: los catorce informes de `02-Informes/` (didáctica, edición, senior .NET, IA, arquitectura, desarrollo, operación y entrega, requisitos, QA, implementador ingenuo, AH-01, AH-02, abogado del diablo), la revisión del abogado del diablo sobre los NO_PROCEDE (`00-Revision-Abogado-NO-PROCEDE.md`) y la auditoría de homogeneidad (`00-Auditoria-Homogeneidad.md`). El relator consolida: no vota ni edita contenido. Los hallazgos con raíz común se fusionaron y conservan todos sus orígenes; las direcciones son las de los especialistas. Cuando dos orígenes propusieron severidades distintas, se consigna la más alta y se anota la otra.

**Aviso de numeración.** El despacho llama AJ-08 a la asignación de OA a las preguntas guía. En `Ciclo-1/07-Aplicacion-Y-Verificacion.md` §2 y en el plan (l. 382, 391, 412, 472, 490, 501) esa asignación es **AJ-05**; AJ-08 es la corrección de la fila S-12 de BIT-16-02 (convocatoria). Didáctica, requisitos y QA lo señalaron por separado. Esta consolidación usa la numeración de 07.

**Resumen.** 59 hallazgos consolidados (S1: 2, S2: 32, S3: 23, S4: 2), 9 ítems de ratificación (AJ-01…AJ-08 y la colisión «nivel A/B»), 14 ítems de re-voto del ciclo 1 pedidos por la auditoría, 7 contradicciones entre especialistas. Dos S4 en lote. Un descarte de nivel C (parcial).

**Sobre la homogeneidad.** La auditoría diagnostica «mixto» para el ciclo 1 (J3, J4 y J5 con plantilla; 21 de 24 parches A5 sin fundamento; X-007 y X-008 atribuidas al jurado contra lo votado). En este ciclo el panel no converge: hay siete contradicciones explícitas (§3), entre ellas sobre si ratificar AJ-01, AJ-03 y AJ-05 y sobre la propuesta T-A/T-B/T-C. QA declaró haber visto por azar dos líneas de otros informes del ciclo 2 y no emitió ese hallazgo para no contaminar la medición; el hallazgo llegó igual por operación, desarrollo e implementador ingenuo, que lo encontraron a ciegas.

## 1. Hallazgos consolidados

| ID | Sev. | Título | Orígenes |
|---|---|---|---|
| H2-001 | S1 | Lo especificado no entra en el tope de 4 h y AJ-03 contradice AC-3b | DES2-01, QA-01, DA2-01 (panel), DA2-02 y DA2-03 (revisión NO_PROCEDE) |
| H2-002 | S2 | Los insumos del presupuesto están mal contados (07, 15, DEP-03, t nominal) | DES2-02, QA-07, ingenuo H-05, AH-02 H-07, QA-01 (parte DEP-03) |
| H2-003 | S2 | AC-3b no tiene lista cerrada: PD-n sin M ni oráculo, PD-7 y 05/06 sin criterio | REQ2-01, ingenuo H-03, DES2-01 (parte M de PD-n) |
| H2-004 | S2 | El tope de <recurso-compartido> no tiene medidor ni corte, y el R-LLM no guarda duraciones | OP-05, QA-02 |
| H2-005 | S2 | La demo funde dos hosts del caso base sin ADR ni filas en el delta | ARQ2-01, H-SN2-04, ingenuo H-01 |
| H2-006 | S2 | La copia literal del .csproj choca con AC-1, AC-6 y la gestión central de versiones | H-SN2-03, ARQ2-02, ingenuo H-02 |
| H2-007 | S3 | AC-6 (todas las transitivas = Anexo F) es inalcanzable; faltan paquetes en la tabla | H-SN2-06, ingenuo H-02 (parte) |
| H2-008 | S3 | Renombre de namespaces no declarado: la prueba de arquitectura pasa en vacío y el diff -r no se puede correr | ingenuo H-06, H-SN2-03 (parte), DA2-05 (revisión) |
| H2-009 | S2 | Aprobación en el escalón 1 (sin MAF): nadie guarda el pedido pendiente y el camino de vuelta admite argumentos alterados | H-SN2-01, ARQ2-03, AH01-C2-H3 |
| H2-010 | S2 | «Herramientas por scope» se rompe por el IServiceProvider raíz del cliente keyed singleton | H-SN2-02 |
| H2-011 | S2 | El chat no fija qué consume Presentación por escalón; IAlmacenDeConversaciones sin capa; PD-6 por la API sin respaldo | ARQ2-04, DA2-06 (revisión) |
| H2-012 | S2 | La política de origen no cubre texto no confiable a mitad del bucle y nunca se ejercita en la demo | AH01-C2-H1, ARQ2-05 |
| H2-013 | S2 | /mcp: «sólo loopback» no es frontera suficiente (Origin/Host, red de compose, camino docker run) | AH01-C2-H2, H-SN2-07 |
| H2-014 | S3 | MCP del lado cliente: herramientas, descripciones y resultados ajenos sin tratamiento de no confiables | AH01-C2-H4 |
| H2-015 | S3 | La integración exige cambios en Application que el delta no registra | ARQ2-06 |
| H2-016 | S3 | num_ctx no llega por la vía /v1; la prueba espía y la guarda de truncado lo dan por aplicado | H-SN2-05 |
| H2-017 | S2 | Variables y provisión incompletas: 05 sin endpoint ni modelo, plan C sin interruptor, 501 de embeddings, modelo sin carga | ingenuo H-04 (parte), OP-06 |
| H2-018 | S2 | El arnés no tiene contrato para los ejemplos de consola ni recurso por ejemplo; depende de un script fuera del repo | DES2-04 |
| H2-019 | S2 | El arnés no dice dónde corre ni en qué orden pide los turnos; anida build y <recurso-compartido> | OP-03 |
| H2-020 | S2 | DEP-14 no se puede cumplir con el gestor de recursos actual, y R-02 no mitiga CPU | OP-01 |
| H2-021 | S3 | La limpieza no tiene inventario (volúmenes, intermedios, registros crudos) | OP-07 |
| H2-022 | S2 | El esquema R-LLM no guarda lo que leen los oráculos ni las versiones de lo que se corrió | IA2-05, DES2-05, AH-02 H-04 (parte), OP-04 (parte) |
| H2-023 | S2 | Sin separación entre entradas de afinado y de medición; entradas sin congelar | AH-02 H-04 |
| H2-024 | S3 | estado_cache se deduce de un campo que N3b midió como inútil para eso | DES2-06 |
| H2-025 | S3 | Ejemplo 05: imagen, modelo y orden de consultas distintos de la medición que cita | IA2-07, DES2-07, OP-04 |
| H2-026 | S2 | El oráculo de 07 no está definido para 5 de los 12 literales | IA2-04, QA-03, AH-02 H-03 |
| H2-027 | S2 | El texto vectorizado de 06 no está fijado; la pregunta del nombre tiene dos relevantes | IA2-04 (parte), AH-02 H-02 |
| H2-028 | S3 | Los oráculos de 08 y 12 dejan pasar invenciones y ausencias de cifra | IA2-05 (parte), QA-04 |
| H2-029 | S2 | La regla «intervalos que no se solapan» no puede afirmar nada con M = 4 o 5; 06 usa otro criterio | QA-05, AH-02 H-01 |
| H2-030 | S3 | La calibración del juez no controla el autofavorecimiento y su umbral es compatible con el azar | IA2-06, AH-02 H-06 |
| H2-031 | S3 | Exclusiones (truncado, precondición) sin regla de denominador ni mínimo de válidas | AH-02 H-05 |
| H2-032 | S2 | El principio rector «con int? el modelo no tiene dónde inventarlo» es falso | IA2-01 |
| H2-033 | S2 | La frontera entre los escalones 1 y 3 de agencia no es operativa | IA2-02 |
| H2-034 | S2 | El ejemplo 12 cambia a la vez escalón y cantidad de agentes, y su verificador LLM hace una cuenta determinista | IA2-03 |
| H2-035 | S2 | En §8, la instancia del escalón 2 y §8.5 usan conceptos que se enseñan recién en §8.7 | H-DID2-04 |
| H2-036 | S2 | El criterio de inclusión no se corrió sección → OA: once subsecciones sin OA, entre ellas la tesis (§4.4) | H-DID2-02, REQ2-06 (parte) |
| H2-037 | S2 | §15 usa un solo formato de ítem para OA procedimentales y de decisión | H-DID2-03 |
| H2-038 | S3 | Las rutas por actor no se derivan de §A.3 ni traen los prerrequisitos de los ejemplos; §0.3 incompleto | H-DID2-05, REQ2-05 |
| H2-039 | S3 | El rótulo de dificultad B/I/A no tiene criterio y se desvía de PR-3 sin declararlo | H-DID2-06 (parte) |
| H2-040 | S3 | «§4.2 se lee antes de §4.1» contradice la numeración por una razón de la bitácora | H-DID2-07 |
| H2-041 | S1 | Contradicción del Anexo F con §5.8 y residuos de la aplicación (§A.3, §H) | ED2-01, ARQ2-07 (a), REQ2-02 (parte §H), REQ2-05 (parte), ingenuo H-07 (parte) |
| H2-042 | S3 | §11 sin «Qué decisión toca»; ADR-08 y ADR-11 sin sección que los cite | ARQ2-07 (b) |
| H2-043 | S3 | La ficha de §12 cita el ejemplo 16 (inyección) en lugar del 17 (observabilidad) | REQ2-04 |
| H2-044 | S2 | Las fichas para la guía remiten a secciones del plan (§A–§H) que en la guía son anexos | ED2-03 |
| H2-045 | S3 | Familias de ID: [R-nn] choca con los riesgos; sin lista de qué llega al lector; cifras sin fuente citable | ED2-04 |
| H2-046 | S3 | Sin tabla de contenido, sin régimen de anclas y sin forma para §1–§3 y §13–§15 | ED2-05 |
| H2-047 | S3 | El presupuesto de extensión no tiene regla de conteo, la Parte 0 no entra y las correcciones sólo suman | ED2-06, DA2-07 (panel) |
| H2-048 | S3 | El glosario no cubre los términos de la tesis y los títulos usan alias | ED2-07 |
| H2-049 | S2 | La matriz única no traza dos pedidos del PO (I-04 §5.2, I-05 §5.2), ni Q1–Q6, ni I-02 | REQ2-02 |
| H2-050 | S2 | P-12 sigue sin decidir y su respaldo omite la siembra, OA-D3 y §11.7 | REQ2-03 |
| H2-051 | S3 | La línea de base de AC-10 exige un commit que las reglas de la corrida prohíben | REQ2-07 |
| H2-052 | S3 | El R-LLM guarda texto de personas y AC-7 sólo busca IPs y hosts | AH01-C2-H5 |
| H2-053 | S2 | Los patrones de AC-8 no detectan identificadores compuestos ni mayúsculas | QA-06 |
| H2-054 | S2 | Seis de siete pasos de la demo repiten la lección de un ejemplo: costo doble sin votar | DA2-02 (panel) |
| H2-055 | S2 | P-03 (página Blazor) se decidió sin costo: tres entradas en un host originan diez hallazgos | DA2-03 (panel) |
| H2-056 | S2 | Tres decisiones de alcance tomadas por costumbre: no fusionar, 17 ejemplos, t = 60 s | DA2-04 (panel) |
| H2-057 | S3 | Tres de las cinco preguntas de nivel C del cierre no tienen objeto | DA2-06 (panel) |
| H2-058 | S4 | AC-3a se rotula «(CI)» cuando §E.1 descarta un workflow | ingenuo H-07 (parte) |
| H2-059 | S4 | La exclusión del multiagente cita RD-PO-3, que no la sostiene | DA2-07 (revisión) |

### Detalle

**H2-001 (S1).** AJ-03 manda a «no ejecutado» lo que exceda el tope también dentro del nivel A (l. 671), y AC-3b exige un registro R-LLM válido para cada PD-n y cada ejemplo de A (l. 818). Con las cifras del plan el corte se dispara siempre: conjunto prioritario de AJ-03 = 28 × 475 s + 31 × 200 s ≈ 5,4 h (QA-01; DA2-02 rev: 6,5 h con sondas); pesimista de A = 11,1 h y nominal 4,6 h (DES2-01); el total especificado da ≈ 19 h con el t medido por clase (DA2-01 panel, E1: Sondeo l. 68, 199,6 s con una herramienta). Además, el plan declara las tasas informativas y sin umbral. Direcciones: una sola regla en §E.5 y AC-3b (DES2-01, QA-01, DA2-03 rev); decisión de alcance votada y cuantificada antes de construir, que reemplace a AJ-03 (DA2-01 panel); separar ejemplos de demostración (1–2 entradas + garantías de código) y de medición (06, 07, 15, 16), ahorro ≈ 46 llamadas (DA2-02 rev). DES2-01 y DA2-01 la proponen S1; QA-01 y DA2-02/03 rev, S2.

**H2-002 (S2).** 07 figura entre las llamadas de más de ~1.900 tokens, pero su corpus completo mide ~250 (N3b X4b punto 7, E1); DEP-13 calibra t sólo con 08 y 09 (DES2-02). 15 corre dos evaluadores sobre las 16 salidas de 07 más 10 de calibración (≥ 52 llamadas) y §E.5 cuenta 10 (QA-07, ingenuo H-05, AH-02 H-07). DEP-03 figura en las sondas de <recurso-compartido> aunque §G.3 la declara sin él (QA-01). La suma de A no sale de sus sumandos (140 contra ≈ 144). Dirección: medir el prompt de cada ejemplo con --fake, t por ejemplo, calibrar DEP-13 por familia de llamada, contar llamadas por evaluador y por entrada, margen de repetición declarado.

**H2-003 (S2).** AC-3b no cubre PD-7 (modelo del lado cliente), ni 05 y 06 (nivel de turno C pero con modelo en el Ollama propio); los PD-n no tienen M ni oráculo en §F.1 y §E.5 sólo presupuesta humo (6 × 2) (REQ2-01, ingenuo H-03). Dirección: lista cerrada «todo ejemplo o paso que llama a un modelo, en cualquier servidor»; columnas M y Oráculo en §F.1 o remisión explícita al ejemplo hermano.

**H2-004 (S2).** <gestor-de-turnos> renueva sin límite mientras el comando vive (E1); el tope es una estimación sin medidor (OP-05). El R-LLM sólo tiene load_duration_ms y prompt_eval_duration_ms, así que la verificación (3) de PAR-15 no se puede calcular y los timeouts no dejan duración (QA-02). Dirección: medidor por registro.log, plazo por suite derivado del tope restante, tiempo de reloj y eval_duration en cada línea, «excluida» con tiempo consumido.

**H2-005 (S2).** ApiWeb y Web son independientes en 8fb4c3a (E1). Routes.razor y App.razor dependen de MainLayout, NotFound, DialogHost, Sidebar, VersionStamp, servicios y assets propios; `@Assets["MovilidadUrbana.Web.styles.css"]` no carga sin error al cambiar el ensamblado; el host único necesita AddRazorComponents, UseAntiforgery, MapStaticAssets y conciliar StatusCodePages. Nada figura en §F.2 ni en un ADR; AC-10 falla por construcción; la caducidad de ADR-11 mira al revés. Direcciones: decidir uno o dos hosts y registrarlo (ARQ2-01, ingenuo H-01); vía (a) cierre completo de dependencias o (b) App/Routes nuevos y mínimos (H-SN2-04).

**H2-006 (S2).** El .csproj de ApiWeb trae `<NoWarn>$(NoWarn);CS1591</NoWarn>` con GenerateDocumentationFile, OpenApi 10.0.11 y Scalar 2.17.3 con Version en línea; las pruebas usan Mvc.Testing 10.0.11 y NUnit.Analyzers 4.7.0 (E1). Choca con AC-1, AC-6 y CPM (NU1010). Dirección: filas de composición en el delta; decidir CS1591, OpenApi/Scalar y sumar paquetes al Anexo F.

**H2-007 (S3).** El cierre transitivo incluye OpenAI 2.14.0, ML.Tokenizers 2.0.0, SQLitePCLRaw, System.*; falta OpenTelemetry.Exporter.InMemory (17); Compliance.Abstractions 10.11.0 existe (E1, flatcontainer). Dirección: invariante por familia en tools/verificar.sh con --format json; universo cerrado de transitivas fijadas.

**H2-008 (S3).** La copia conserva `MovilidadUrbana.ApiWeb.Domain` y la prueba recorre `MovilidadUrbana.Asistente.Domain.*`: sin renombre declarado pasa en vacío; «diff -r vacío salvo los namespaces» no es ejecutable. DA2-05 rev pregunta por qué la demo no referencia un único Domain. Dirección: fijar el namespace, prueba que falle si no encuentra tipos, script con normalización.

**H2-009 (S2).** ADR-12 resuelve el estado sólo para la AgentSession de MAF; PD-5 y 09 aprueban sin MAF, donde FunctionInvokingChatClient ejecuta la ToolCall que llega en la ToolApprovalResponseContent entrante (E1, XML M.E.AI 10.11.0). Si la API recibe el historial del cliente, se aprueba con argumentos alterados; el SSE de ChatResponseUpdate crudo saca hacia el cliente los argumentos del modelo. Además: la propiedad es ToolApprovalRequestContent.ToolCall (ToolCallContent) y, si una llamada es aprobable, todas las de esa respuesta piden aprobación. Dirección: ADR-12 extendido al escalón 1; el servidor guarda historial y pedido por (sesión, conversación, id); la API recibe sólo {conversación, id, decisión}; prueba de rechazo de argumentos alterados; DEP-09 como sonda de dos peticiones.

**H2-010 (S2).** FunctionInvokingChatClient recibe su IServiceProvider al construirse; con singleton keyed es la raíz; AIFunctionFactory resuelve parámetros IServiceProvider desde AIFunctionArguments.Services (E1). En Development falla por ValidateScopes; en Production compartiría instancias entre sesiones (E3). Dirección: cerrar DEP-04 con la regla «AIFunctionFactory.Create(método, instancia) en el scope, sin parámetros de DI»; prueba con ValidateScopes/ValidateOnBuild por el singleton real.

**H2-011 (S2).** Presentación «consume el IChatClient», pero PD-6 es un AIAgent con AgentSession; con un controller y una página, o PD-1/PD-5 suben al escalón 3 o PD-6 no tiene entrada; IAlmacenDeConversaciones no aparece en capas, diagrama ni delta (ARQ2-04). DA2-06 rev pregunta si PD-6 necesita la API (DEP-11 sin sondear, sin respaldo escrito). Dirección: una ruta o modo por escalón; ubicar el almacén; decidir PD-6 sólo en Blazor o escribir el respaldo de DEP-11.

**H2-012 (S2).** La política se decide al armar el cliente del pedido y no cubre el resultado de una herramienta de recuperación (RAG agéntico que la guía enseña), los campos libres de las lecturas (Nombre sin endurecer) ni los resultados MCP (AH01-C2-H1; MCP 2025-06-18 SHOULD validar resultados). El asistente no tiene herramienta de recuperación, así que la política y la cláusula de AC-4 se cumplen sin probarse; la ayuda va del endpoint al puerto IAyuda sin caso de uso, segunda excepción no declarada (ARQ2-05). Dirección: definir «no confiable» por procedencia, decir qué pasa a mitad del bucle y ejercitarlo en 16 o en una prueba; declarar la ayuda como excepción de lectura y la política como preventiva en la demo, o darle recuperación al asistente.

**H2-013 (S2).** La especificación MCP exige con MUST validar Origin contra DNS rebinding (E1); AllowedHosts en loopback sólo está en 13; con `ASPNETCORE_URLS=http://+:8080` Kestrel escucha en todas las interfaces del contenedor y los demás contenedores del bridge (ollama-embed) alcanzan /mcp; el camino (1) docker run no fija 127.0.0.1. Dirección: distinguir escuchar, publicar y validar Origin/Host; AllowedHosts en la demo con prueba de rechazo; red de compose de confianza o separada; mostrarlo con un curl desde otro contenedor.

**H2-014 (S3).** El plan monta como AIFunction lo que devuelve McpClient.ListToolsAsync sin decir que nombres, descripciones, anotaciones y resultados ajenos son no confiables ni que una escritura MCP queda sin aprobación (MCP Tools: MUST considerar anotaciones no confiables). Dirección: lista permitida por nombre, escrituras envueltas en aprobación, prueba en 13.

**H2-015 (S3).** LocalidadService sólo tiene GetAllAsync, SaveAsync (sin entidad) y DeleteAsync; el controller lee del repositorio (E3 sobre 8fb4c3a). Para la aprobación por id y para agregar_localidad hacen falta métodos nuevos y cambiar DependencyInjection.cs, y el delta da Application como «agregado». Dirección: declarar los cambios con motivo.

**H2-016 (S3).** AddOllamaOption escribe en AdditionalProperties y sólo OllamaSharp lo lee; por /v1 num_ctx no llega (E3). Dirección: limitar la invariante al adaptador OllamaSharp; pregunta abierta: ¿/v1 sin num_ctx recarga el modelo del servidor compartido (R-04)? Si no se responde, la vía /v1 de 02 corre sólo contra el Ollama propio.

**H2-017 (S2).** La tabla canónica no tiene endpoint ni modelo de chat para 05, ni interruptor del plan C, y OLLAMA_EMBED_ENDPOINT apunta por defecto al servidor que responde 501 sin conducta definida (ingenuo H-04). El Ollama propio no tiene paso de carga ni volumen, la red entre el SDK y el Ollama propio no está, y la demo reconstruye el almacén al arrancar sin degradar a C (OP-06; N3-Evidencia usó `--network host`). Dirección: completar la tabla; provisión declarada con volumen del proyecto; degradar a C por configuración con rótulo en UI y registro.

**H2-018 (S2).** Los ejemplos son consolas y verificar.sh sólo corre dotnet test por categoría; --con-modelo pone bajo <recurso-compartido> también a 05 y 06; <gestor-de-turnos> está fuera del repo público. Dirección: contrato por ejemplo (proyecto de pruebas o --verificar con código de salida), recurso marcado por ejemplo, envoltorio de turno inyectado por variable.

**H2-019 (S2).** <gestor-de-turnos> es del host y no corre dentro del contenedor del SDK; la suite con modelo anidada en build retiene el cupo horas; 07, 16 y PD-2 piden <recurso-compartido> y [recurso-modelo-propio] sin orden (riesgo de espera cruzada, código 4); las corridas manuales de la demo contra el compartido quedan sin turno. Dirección: arnés del host que pide cada turno por separado y lanza un contenedor por fase; orden global de pedido; turno obligatorio para la demo y suma al tope.

**H2-020 (S2).** Con cupos.conf = «[recurso-modelo-propio] 1», <gestor-de-turnos> aborta con «TTL[$r]: variable sin asignar» (E1, prueba aislada); el gestor no tiene exclusión entre recursos, así que no «compite con build» como promete R-02. Dirección: DEP-14 como cambio al gestor con dueño y criterio verificable; regla de convivencia escrita o R-02 limitado a memoria.

**H2-021 (S3).** Ya existen los volúmenes <volumen-nuget> y <ollama-n3> (~913 MB) sin dueño (E1); el plan sólo dice «borrar contenedores al terminar». Dirección: sección de limpieza con inventario y comando de verificación al cerrar.

**H2-022 (S2).** El esquema (l. 618) no guarda llamadas a herramientas (nombre, argumentos, resultado), ids y puntajes recuperados, contexto de grounding, ni hash de instrucciones, herramientas y entradas, ni versión de Ollama; tampoco separa resultado por llamada del resultado por entrada. Sin eso no se auditan 08, 11, 16 ni corre 15 sobre su entrada declarada. Dirección: sumar esos campos bajo AC-7 y comprobar que cada oráculo se calcula sólo desde el registro.

**H2-023 (S2).** Nada separa las entradas con que se afinan prompts, herramientas y el «no sé» de las que informan tasas; entradas.v1.json no se congela; DEP-10 decide con 5 entradas y 11 mide la misma cadena con M = 5. Dirección: congelar entradas y oro antes de la primera corrida que cuenta (cambio = v2, tasas v1 descartadas), conjunto de desarrollo aparte.

**H2-024 (S3).** N3b X4b: frío 4.728 tokens / 102,65 s, cacheado 4.725 / 1,10 s; «prompt_eval_count no sirve para detectar aciertos» (E1). Dirección: deducir de prompt_eval_duration frente a count con umbral de DEP-03; «desconocido» por defecto en el compartido.

**H2-025 (S3).** 05 corre en 0.40.11, elegida (H-027) sólo para embeddings; X4b se midió en 0.32.0-rc0 a propósito; qwen2.5:0.5b es transformer puro y qwen3.5:4b híbrido (hipótesis de N3b no mencionada en la v1); digest y orden de consultas sin fijar; tiempos sin excluir builds. Dirección: fijar la imagen de X4b o declarar re-medición; rotular las cifras; declarar en §6.3 y §5.7 que con qwen3.5:4b no está medido.

**H2-026 (S2).** Cinco literales de 8fb4c3a no fijan valor («Una de las provincias del catálogo.», «Al menos uno.», etc., E1); provincia y frecuencia dependen de Catalogos, fuera del corpus; la tasa se informa k/12. Dirección: el oro declara por pregunta valor esperado y formas aceptadas (incluidas palabras) o «sin valor verificable»; tasa sobre M efectivo (k/7); reclasificar las de Catalogos o sumar sus etiquetas.

**H2-027 (S2).** Varios literales no nombran su tema y dos comparten RequisitoDelNombre; el texto vectorizado (rótulo + clase + literal) no está fijado; lo de N3 E3 se midió sobre enunciados redactados. Dirección: plantilla generada en código y versionada con el oro, mismo texto para la línea base léxica, recall@k o desambiguación, declarar que E3 no se transfiere.

**H2-028 (S3).** «Números de la respuesta ⊆ números de las herramientas» deja pasar «hay dos», un conteo igual a un id y una respuesta sin cifras; en 12, un resumen sin porcentajes pasa. Dirección: normalizar numerales en palabras, comparar contra el campo de conteo, excluir ids, exigir la cifra en entradas legítimas y contar la ausencia aparte.

**H2-029 (S2).** Clopper-Pearson al 95 %: 0/5 = [0; 0,522] y 5/5 = [0,478; 1] se solapan; el primer M separable es 6; con M = 12 hacen falta 7 de diferencia (E1). 06 afirma ventaja con 3 preguntas [criterio propio]. 12 y 16 gastan ≈ 70 llamadas en resultados decididos de antemano. Dirección: una regla única en §10.4 (pares discordantes en diseños pareados, o tasas descriptivas con M ≤ 12); M mínimo declarado; fundar o sacar el criterio de 06.

**H2-030 (S3).** El sesgo declarado aparece sobre salidas del propio modelo y los casos de calibración son ajenos (el malo de E5 es de qwen2.5:7b); 8/10 tiene intervalo [0,44; 0,97]. AH-02 matiza que el umbral resiste un juez constante o al azar (P ≈ 1,2 %). Dirección: calibrar con salidas de qwen3.5:4b en 07 anotadas a ciegas, informar intervalo y acuerdo juez-oráculo; con 10 casos sólo se descarta un juez. Pregunta abierta: ¿hay un juez de otra familia en el Ollama propio sin violar R-04?

**H2-031 (S3).** «No cuenta para ninguna tasa» y «excluida, se cuenta aparte» sin denominador ni repetición: 16 con 2 de 5 en top-k queda k/2, k/5 o inválido según quién lea. Dirección: k/M_válidas + e/M excluidas con motivo, mínimo de válidas y repetición.

**H2-032 (S2).** §A.4 l. 139 y §F.7: el campo anulable da lugar para no inventar pero no impide devolver un número plausible; HabitantesValidos sólo detecta null; el propio 03 mide «tasa de invención». Dirección: separar lo que garantiza el código de lo que se mide como tasa; garantía por confirmación del usuario o por presencia del valor en la entrada; vale también para la encuesta.

**H2-033 (S2).** El plan dice que el escalón mide autonomía (l. 268) pero pone 11 y PD-6 en el 3 porque «conserva la conversación» (l. 277), que es estado; listar → eliminar(id) es lo que UseFunctionInvocation resuelve en el 1. Dirección: frontera observable (pedido acotado con tope de iteraciones frente a tarea abierta); reubicar 11/PD-6 en el 1 con el estado como dimensión aparte, o darles una tarea del 3.

**H2-034 (S2).** A (un agente) contra B (workflow de dos agentes) cambia dos variables; el verificador LLM hace la cuenta del oráculo determinista (función, escalón −1); la «instancia positiva» del escalón 2 queda declarada a la vez como «sube más de lo necesario». Dirección: camino fijo redactor LLM → executor de código que compara → vuelta con el error; comparar «uno o varios» con el escalón fijo o ajustar OA-D7.

**H2-035 (S2).** §8.5 usa el ejemplo 11 y §8.6 la variante B del 12, que necesitan AsAIAgent/AgentSession de §8.7; viola l. 623 y PAR-14 no lo detectó (filas 10 → 11 con § decreciente). Dirección: escalón 2 sin agentes (§B.3 admite nodos función o llamada) o en §8.8 con remisión; §8.5 con 09; verificar primer § de cada fila y conceptos usados. Depende de SC-1 (didáctica): ¿la variante B se arma sin agentes sin perder lo que mide?

**H2-036 (S2).** l. 129 exige sección → OA; sin OA: §2.5, §4.1, §4.4, §4.5, §10.1, §10.7, §11.2, §11.5, §11.6, §12.3, §12.6–§12.9; §4.4 es la decisión central de la tesis y no tiene ejemplo propio (§4 lista 01 y 02, que son de §5). Dirección: correr el criterio en los dos sentidos; crear OA «decidir entre puerto propio e IChatClient» o declarar subsecciones de contexto sin ítem en §15 con motivo (REQ2-06: algunas las pidió el PO).

**H2-037 (S2).** «¿Qué escalón elegís y por qué?» para 25 OA, varios procedimentales (OA-D1, OA-D9, OA-O1, OA-O2, OA-A1, OA-SK1). Dirección: el tipo de ítem sigue al verbo; procedimentales con tarea sobre el ejemplo y criterio verificable por el lector.

**H2-038 (S3).** ACT-SEC no pasa por §7.1–§7.4 ni §8.7 aunque sus OA citan 16 y 11; ACT-ARQ suma secciones que ningún OA-A apunta; las preguntas de OA-O1/OA-O2 viven en §11, fuera de la ruta OPS; §0.3 omite EF Core, NUnit, el circuito de Blazor y Clopper-Pearson. Dirección: ruta = tronco ∪ secciones de los OA ∪ secciones de sus preguntas ∪ conceptos de sus ejemplos; lo agregado a mano con motivo; §0.3 completo.

**H2-039 (S3).** B/I/A sin criterio (l. 623); 06 y 07 son «I» aunque PR-3 llama avanzado al RAG operable con citas, y el desvío no está en §D; 10 (sin modelo) es «A» y 11 (agente con sesión) «I». Dirección: criterio declarado (conceptos nuevos, piezas tocadas), reasignación y desvío de PR-3 en §D. La parte de la colisión de letras va a RAT-NIVEL.

**H2-040 (S3).** l. 408: «se numera así para que §4.1 conserve la remisión de N1b», que es de la bitácora. Dirección: orden de lectura = numeración; trazabilidad con N1b en la bitácora.

**H2-041 (S1).** El Anexo F dice «§5.8 desaparece como subsección» (frase de la v0, donde §5.8 era «Paquetes vigentes»), pero en la v1 §5.8 es «Decisión en curso: ADR-02» y P-02 ubica ahí el anticipo (l. 417, 526, 880; verificado por el relator). Residuos: dos párrafos de lectores (l. 95 y 97, el segundo con «(§2.3)» ambiguo); §H dice PAR-01…PAR-23 sin AJ (l. 900) mientras el encabezado dice PAR-24 más AJ (l. 16). El cierre del ciclo 1 declaró 0 contradicciones. Dirección: la frase del Anexo F nombra la lista de paquetes de §5; un solo párrafo de lectores; §H con PAR-24 y AJ-01…AJ-08; verificación mecánica de que toda remisión «§N.k» resuelve a número y tema. ED2-01 la propone S1; ARQ2-07 S3; ingenuo S4.

**H2-042 (S3).** §11 sin su «Qué decisión toca» (ADR-06); ADR-08 (tema de §5.3) y ADR-11 (tema de §4.3) sólo aparecen en §A.4, §13 y §F.7. Dirección: sumar el bloque y las citas, o registrar por qué no.

**H2-043 (S3).** l. 489 «Ejemplos: `16`»; 17-Observabilidad cubre §12.1–§12.3 y OA-O1 (l. 643). Dirección: «`17`» y chequeo mecánico en los dos sentidos entre §E.2 y las líneas Ejemplos de §C.

**H2-044 (S2).** «demo §F.9» (OA-O2) apunta en la guía al Anexo F (Versiones); «§A.3», «§C», «§E.1» chocan con los Anexos A, C y E; «Remiten: §B.5» es remisión de la guía al plan (~30 remisiones entre l. 330 y 530). Dirección: prefijo «plan §X» para las del plan y destino en la guía para las demás; compuerta `grep -nE "§[A-H](\.|\b)"` = 0 sobre la guía.

**H2-045 (S3).** [R-nn] de la guía choca con los riesgos R-01…R-08 que las fichas citan; PAR-05 fijó la entrada del Anexo D pero no la cita en el cuerpo; AC-9 admite cifras no re-ejecutadas que la guía no puede referenciar; PR-1 y PR-01 son dos grafías. Dirección: prefijo sin colisión (p. ej. [REF-nn]), marca de cita, re-ejecutar o no incluir, tabla de familias de ID con grep de compuerta.

**H2-046 (S3).** La Parte 0 no tiene tabla de contenido; la plantilla repite cinco títulos de nivel 3 en ocho secciones, que GFM desambigua por orden (insertar un título corre todas las anclas); §1–§3 y §13–§15 sin forma; nivel de Partes y de los agrupadores de §8 sin fijar. Dirección: §0.0 con tabla generada; anclas explícitas declaradas en §0.4 con verificación; forma declarada.

**H2-047 (S3).** Sin regla de conteo (sólo excluye código y tablas de versiones); la Parte 0 estimada en ~1.480 palabras contra 1.380 (filas de OA = 551 palabras, E3); las correcciones del ciclo 2 sólo agregan (DA2-07). Dirección: regla de conteo ejecutable, tope coherente o mapa de ejemplos al Anexo E; regla de compensación (cada parche declara cuánto suma y qué saca, J3 lo verifica). Preguntas abiertas: ¿alcanzan 4.500 palabras para la Parte VI con 12 ADR? ¿58 preguntas guía más 25 ítems repiten la misma práctica? La afirmación de que el resultado pasa las 50.000 palabras es nivel C y se descarta como afirmación (§5).

**H2-048 (S3).** Faltan en el glosario puerto, adaptador, raíz de composición, modelo, token, temperatura, alucinación, grounding, MCP, oráculo, línea base, entrada distinta, spotlighting, nivel; títulos con alias («§8.2 Tool calling», «ADR-07 Nivel de orquestación», «CAG de servicio» en §B.3 y §6). Dirección: glosario superconjunto de §3.0, §4.2 y §B; títulos con el canónico; C5 que busque alias en títulos.

**H2-049 (S2).** BIT-16-02 §6: Q1–Q6 es un marcador sin filas; I-04 §5.2 dice «preocupaciones de audiencia» pero el insumo pregunta si se convoca a AH-02; I-05 §5.2 pregunta si PR-17 es escenario nuevo o variante de ESC-04 y P-05 lo reformula como contextos y lo deja abierto; I-02 sin fila (E1). Dirección: seis filas Q, filas I-04/I-05 con el pedido literal y su resolución, decidir PR-17 o declarar el apartamiento, fila I-02.

**H2-050 (S2).** El respaldo de P-12 («05 y 16 pasan a explicación conceptual») no menciona la siembra (PD-1, 12, resumir_encuesta), ni OA-D3 (único ejemplo 05), ni §11.7; el corpus de 05 usa «la localidad ficticia Nº n» y P-12 no lo pregunta; no hay decisión registrada ni DEP. Dirección: el jurado decide P-12 en este ciclo con la pregunta completa; respaldo con lo que cae; P-12 en §G.3 como condición previa de 05, 12, 16 y PD-1.

**H2-051 (S3).** l. 697 y AC-10 dependen de un commit «base 8fb4c3a»; las reglas de la corrida dicen «no commitear». Dirección: copia exportada y diff -r (como _Comun) o commit diferido con el PO, escrito en AC-10.

**H2-052 (S3).** El R-LLM guarda entrada y salida textuales; PD-4 procesa edad, distancia y minutos de la persona (N6 T5); sólo la siembra está rotulada; AC-7 busca IPs y hosts. Dirección: entradas sintéticas rotuladas; §11.4 trata el registro como las trazas; compuerta que verifica que los nombres pertenecen al conjunto sintético.

**H2-053 (S2).** Prueba en scratchpad (E1): el patrón de código no marca ReclamoService, TicketId ni IncidenteRepository; el de texto distingue mayúsculas y no ve «Reclamos»; «probado contra el plan v1» sólo prueba ausencia de falsos positivos. Dirección: término dentro del identificador, insensible a mayúsculas, ambos patrones sobre todos los archivos, archivo de casos positivos. DA2-05 (panel) lo pide como parche aparte de la ratificación de AJ-04.

**H2-054 (S2).** PD-1↔08, PD-2↔07, PD-3↔03, PD-4↔04, PD-5↔09, PD-6↔11, PD-7↔13: 78 llamadas (≈ 3,9 h), dos copias de Domain y dos arneses. Opciones a votar: (a) un registro con dos usos (PD-n en humo, evidencia del ejemplo hermano, un solo origen de Domain); (b) la demo es la escalera y los ejemplos que la repiten quedan en --fake; (c) mantener y declarar el costo.

**H2-055 (S2).** Las tres entradas en un host originan diez hallazgos del ciclo 2 (ARQ2-01, ARQ2-03, ARQ2-04, ARQ2-05, SN2-01, SN2-04, SN2-07, ingenuo H-01, AH01-C2-H2, AH01-C2-H3). Opciones: (a) una sola presentación para el chat; (b) PD-7 fuera, ESC-05 por 13; (c) mantener y sumar el costo. Pregunta a la presidencia: ¿el contrato exige que la demo sola recorra los cinco escenarios?

**H2-056 (S2).** «No se fusionan ejemplos» entró con PAR-15/PAR-20 sin votarse (la v0, l. 753, preveía 01+02, 10+11 y 14 opcional); los 17 ejemplos vienen de la v0; t = 60 s está por debajo de todo lo medido. Dirección: re-votar fusiones con su ahorro y el OA que conservan.

**H2-057 (S3).** ToolCallAccuracy (ningún ejemplo lo usa, l. 619), PublishContainer (ya existe sdk + dotnet run, DEP-05) y keep_alive (no se fija, l. 596) se cierran con una decisión de alcance; los reintentos del SDK de OpenAI en 02 y las ChatOptions del juez en 15 se atan a sus filas. Responde la «deuda declarada y cinco preguntas nivel C» que el cierre del ciclo 1 trasladó.

## 2. Ratificación de los ajustes de secretaría y colisión «nivel A/B»

Texto de cada AJ en `Ciclo-1/07-Aplicacion-Y-Verificacion.md` §2. La posición del abogado del diablo (DA2-05 panel) se consigna en cada uno; los demás orígenes, donde los hay.

| ID | AJ | Qué cambió | Posiciones del panel | Insumo para el voto |
|---|---|---|---|---|
| RAT-AJ-01 | AJ-01 (PAR-13) | Rechazo de corrida con `servidor = compartido` sin num_ctx del arnés; lectura de /api/ps dentro del turno | OP-02: ratificar sólo con fuente explícita (variable canónica de tipo de servidor, marca num_ctx_origen, default seguro). DES2-03 e ingenuo H-04: no implementable como está; /api/ps vacío aborta con un Ollama propio recién levantado. DA2-05: no ratificar; reemitir como parche del ciclo 2 con criterio de verificación. | Ninguna variable de l. 601–608 define `servidor` ni el origen (E1). La auditoría cuestiona PAR-13 (default 8192 contra R-04). |
| RAT-AJ-02 | AJ-02 (PAR-15, PAR-10) | Reemplaza «11 a 200 s» por lo medido; t por ejemplo t ≈ p/9,4 + s/4 con pesimista ≥ 475 s | QA: consistente con su fuente (reproduce 474,7 s). DES2-02: la clasificación de 07 entre las llamadas largas es errónea (~250 tokens). DA2-05: ratificar en las cifras. | Ver H2-002. |
| RAT-AJ-03 | AJ-03 (PAR-15) | Prioridad dentro de A; lo que exceda el tope pasa a «no ejecutado» como deuda | DES2-01, QA-01: incompatible con AC-3b; unificar. DA2-03 rev: ratificar reescribiendo AC-3b con una sola regla, PD-n fuera del recorte. DA2-05 panel: rechazar; lo reemplaza la decisión de alcance de DA2-01. | Ver H2-001 y X2-02. |
| RAT-AJ-04 | AJ-04 (PAR-19) | Una sola regla en AC-8; «Línea» sólo como identificador | DA2-05: ratificar; QA-06 va como parche aparte (H2-053). | La auditoría cuestiona PAR-19 por haber pasado con dos reglas. |
| RAT-AJ-05 | AJ-05 (PAR-03/05/08/11) | Quita IAsistenteDeMovilidad de §B.1, fuente de §13, «prefijo estable» en el diagrama, **OA asignados a las preguntas guía** y recorte de §10 y §12 | H-DID2-01: ratificar con cambios; 8 de 21 preguntas atadas a un OA que no ejercitan (§1 → OA-0.2, §2 → OA-A2, §4 → OA-D1, §12 → OA-O4 y OA-O2), y local/nube y RAG sí/no preguntadas dos veces. REQ2-06: revalidar una por una. DA2-05: no ratificar; votar la regla y sacar las preguntas sin OA. ED2-07: «CAG de servicio» sigue en §B.3 y §6. | Despacho y auditoría lo llaman AJ-08. Ver X2-03. |
| RAT-AJ-06 | AJ-06 (PAR-14/16/20) | IDs v0 → v1 | ED2-01, ARQ2-07, REQ2-04: la renumeración dejó «§5.8 desaparece» (H2-041) y «Ejemplos: 16» en §12 (H2-043). DA2-05: ratificar y completar. | |
| RAT-AJ-07 | AJ-07 | Línea de fuente o escenarios en §0, §2, §3, §15 | DA2-05: ratificar. Nadie objeta. | |
| RAT-AJ-08 | AJ-08 (PAR-21) | S-12 remite a `Ciclo-1/01-Convocatoria.md` | QA: verificado, el archivo existe. DA2-05: ratificar. | |
| RAT-NIVEL | Colisión «nivel A/B» (PAR-14, PAR-15, PAR-19) | Diferida en 07 §4 por «cambiaría texto aprobado» | QA-01 y DA2-04 rev: votar T-A/T-B/T-C en el primer bloque con la misma regla que los AJ (DA2-04 rev: criterio doble, porque AJ-01…AJ-05 sí cambiaron texto aprobado). ED2-02: «nivel» tiene seis sentidos y A/B/C nombra además embeddings, variantes, anexos y secciones; T-A/T-B/T-C resuelve una sola colisión; propone T1–T3 interno, EMB-A…C, variantes con nombre, ADR-07 «Escalón de orquestación», §4.4 «Dos contratos». H-DID2-06: T-A/T-B/T-C deja las mismas letras a la vista; la dificultad conserva su nombre y el turno usa un nombre interno que no llegue a la guía. | Contraejemplo E3 (ED2-02): 10 es Nivel A y Turno C; leído con §E.2, AC-3b exige un R-LLM imposible. Ver X2-01. |

## 3. Contradicciones entre especialistas

| ID | Tema | Posición 1 | Posición 2 | Qué decide el jurado |
|---|---|---|---|---|
| X2-01 | Nombre del nivel de turno | QA-01, DA2-04 rev: ratificar T-A/T-B/T-C | ED2-02, H-DID2-06: T-A/T-B/T-C no resuelve; prefijo sin letras (T1–T3), interno, fuera de la guía, y la regla aplicada a las demás colisiones | Esquema de nombres y alcance del renombre |
| X2-02 | AJ-03 | DA2-03 rev: ratificar con AC-3b reescrito y PD-n fuera del recorte | DA2-05 panel: rechazar, reemplazar por una decisión de alcance cuantificada; DES2-01: o deuda de A admitida o A redefinido para entrar en el tope | Si la línea de corte sobrevive o se sustituye por una decisión de alcance previa |
| X2-03 | AJ-05 | H-DID2-01: ratificar con cambios (reatar o crear OA, una sola casa para local/nube y RAG sí/no) | DA2-05 panel: no ratificar; reemitir como parche, votar la regla y sacar las preguntas sin OA | Ratificar con cambios o reemitir |
| X2-04 | AJ-01 | OP-02: ratificar con una fuente explícita | DA2-05 panel, DES2-03: no implementable; reemitir como parche | Ratificar con condición o reemitir |
| X2-05 | Escalón y ruta de PD-6 | §F.1 y ARQ2-04: PD-6 en el escalón 3 con su propia ruta o modo y almacén ubicado | IA2-02: reubicar 11/PD-6 en el escalón 1, con el estado como dimensión aparte; DA2-06 rev: ¿PD-6 sólo en Blazor, sin API? | Escalón de PD-6 y si se mantiene por la API |
| X2-06 | Alcance de la demo | ARQ2-01, ingenuo H-01, H-SN2-04: mantener y registrar la fusión de hosts (con dos vías de construcción); REQ2-01: PD-7 entra o se declara sin modelo | DA2-03 panel: recortar (una presentación, PD-7 fuera) antes de corregir; DA2-02 panel: la demo no repite ejemplos | Si se corrige la demo tal como está o se recorta primero |
| X2-07 | Medición frente a presupuesto | QA-05, AH-02 H-01: subir M a 6 o más, o comparación pareada, para que la regla pueda afirmar algo | DA2-02 rev, DA2-01 panel: bajar entradas (demostración con 1–2) y separar ejemplos de medición | Qué ejemplos miden y con qué M, dentro de qué tope |

## 4. Re-votos del ciclo 1 que pide la auditoría

| ID | Ítem | Motivo (auditoría) | Insumos del ciclo 2 |
|---|---|---|---|
| RV-01 | X-007 (PAR-02) | Sin mayoría (J2 casos integradores, J3 ninguno, J4 optativos); PAR-02 atribuyó a J4 lo que no tomó; OA a 25 sin estimar extensión | H2-047 |
| RV-02 | X-008 (PAR-08, PAR-14) | J2 y J4 pedían comparar contexto completo y RAG cuando sea ejecutable; los parches la eliminaron citando «coherencia» | DA2 panel (revisado y bien): se sostiene en el fondo por tiempos medidos; el defecto es de procedimiento. H2-025 |
| RV-03 | H-021 / PR-03 (PAR-15) | Tope de 4 h y t = 60/200 s nunca votados; A pesimista 8,0 h; AJ-02/AJ-03 sin voto | H2-001, H2-002, H2-004, H2-056 |
| RV-04 | H-040 (PAR-05) | Se votó la necesidad de presupuesto, no el número 43.700; el plan creció 67 % | H2-047 |
| RV-05 | H-035 / PR-14 | OA de 19 a 25 y §15 a 25 ítems sin costo; OA de preguntas guía por la secretaría | RAT-AJ-05, H2-036, H2-037 |
| RV-06 | H-004 | En el caso base LocalidadModel.Habitantes ya es int?; el int está sólo en la sonda de N6; propuesta S3 con capa de origen N6 | H2-032 |
| RV-07 | H-008 (PAR-17) | El caso base ya pasa SessionId al circuito; el defecto era la descripción, no la fuga; J1 anunció una «imprecisión menor» nunca identificada | Senior .NET, arquitectura e ingenuo confirman el puente en 8fb4c3a; H2-011 |
| RV-08 | H-001 | J3 fundó en «las mismas llamadas», pero PAR-15 suma 24 de estabilidad | H2-001, X2-07 |
| RV-09 | H-026 y H-060 | Re-medición «barata» depende de un Ollama propio que no es recurso del gestor (DEP-14) y compite con build; ESC-001 no se reabre | H2-020, H2-027 |
| RV-10 | H-009, H-014, H-049 | E4 mal aplicado (no hay regla externa del contrato); re-votar sólo el nivel | — |
| RV-11 | X-002 | Mayoría débil: sólo J3 eligió «sesgo declarado» | H2-030 |
| RV-12 | PR-07 (NO_PROCEDE) | M§9 exige revisión del único NO_PROCEDE | DA2-01 rev (S3): se sostiene por RD-PO-1, pero «dependencias no sondeadas» es falso para MCP (2.3.0 sondeado) y PR-20 no cubre la intención porque 08 viene mezclado con EF Core y sesiones; propone PR-07b (paso 0 de 08 sobre Catalogos, --fake + M = 3, ≈ 6 llamadas) y corregir la fila de §D |
| RV-13 | PAR-10 | Aprobado A5 con «11 a 200 s», la cifra que el juez de evidencia objetó en PAR-15; corregido por AJ-02 sin voto | RAT-AJ-02 |
| RV-14 | 05-Parches §Cobertura | «Los 85 ítems PROCEDE tienen parche» cuando son 93; la cobertura no se revisó | — |

PAR-13, PAR-19 y PAR-14 (también cuestionados) se votan en RAT-AJ-01, RAT-AJ-04 y RAT-NIVEL.

## 5. S4 en lote y nivel C

**S4 en lote:** H2-058 (AC-3a «(CI)»: nombrar el arnés en lugar de CI; ingenuo H-07) y H2-059 (motivo de la exclusión del multiagente: escribir costo de turno + R-08 en lugar de RD-PO-3; pregunta abierta: ¿un handoff mínimo entra en el nivel de turno B si DEP-10 da ≥ 3 de 5?; DA2-07 rev).

**Nivel C descartado:** la afirmación de DA2-07 (panel) de que el resultado pasará las 50.000 palabras: es conjetura sin medición. Se descarta como afirmación y queda como pregunta dentro de H2-047; el resto del hallazgo (58 preguntas guía contadas, 25 ítems, regla de compensación) tiene ancla y entra.

**Preguntas abiertas (no son hallazgos):** /v1 sin num_ctx y recarga del compartido (H2-016); juez de otra familia sin violar R-04 (H2-030); ¿el resultado de B en 05 depende del intercalado de consultas, dada la restauración no explicada de G en X4b? (DES2-07); ¿la excepción del chat (§A.4 p. 6) admite reenviar ChatResponseUpdate sin filtrar? (AH01-C2-H3); ¿el cliente reenvía el historial y el servidor vuelve a resolver los argumentos? (ARQ2-03).

## 6. Solicitudes de convocatoria (para la presidencia)

- Operación y entrega ya fue convocada en este ciclo (informe `operacion.md`), como pedía el cierre del ciclo 1; el panel le dirige además: red de compose y /mcp (H2-013), /v1 y R-04 (H2-016), línea de base sin commit (H2-051), M y turnos de PD-n (H2-003), contabilidad de turnos y tope (H2-004), si verificar.sh puede depender del gestor fuera del repo (H2-018).
- Seguridad (AH-01): protocolo de aprobación sin MAF ante una respuesta falsificada (H2-009) y regla de herramientas por scope (H2-010).
- Didáctica: SC-1 (H2-035); legibilidad de OA-D6/OA-D7 con frontera 1/3 operativa (H2-033, H2-034); orientación previa a §1 si el mapa sale de la Parte 0 (H2-046, H2-047); costo didáctico de «la demo es la escalera» (H2-054); PR-07b (RV-12).
- Senior .NET y arquitectura: referencia única del Domain frente a dos copias (H2-008) y PD-6 por la API (H2-011).
- Jurado: votar en el primer bloque la decisión de alcance (H2-001 con H2-054, H2-055, H2-056) antes de cualquier parche que sume mediciones; J3 con t medido por clase de llamada, no con «barato»; P-12 con la pregunta completa (H2-050).
- Presidencia: I-05 §5.2, escenario nuevo o variante de ESC-04, o apartamiento declarado (H2-049); si el contrato exige que la demo sola recorra los cinco escenarios (H2-055).
- Formal/estadístico (opcional, desarrollo): ratificar la regla de comparación con varias variantes y M = 5 (H2-029).
