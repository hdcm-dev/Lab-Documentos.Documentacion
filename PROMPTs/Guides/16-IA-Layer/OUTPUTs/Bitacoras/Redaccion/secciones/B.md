<a id="anexo-b"></a>
## Anexo B · Listas de verificación por actor

Un ítem de verificación sirve si se puede tachar con una prueba que pasa, un comando que da cero o un documento que existe. Estas listas siguen a los actores de [§2.3](#s2-3), y cada ítem remite a la sección que lo enseña. La lista de seguridad para herramientas ([B.5](#anexo-b-herramientas)) es común a ACT-DEV y ACT-SEC y usa los riesgos de OWASP de [§11.1](#s11-1). Criterio de la guía: son el piso de CTX-EXISTENTE × CTX-LOCAL × CTX-PROTO; lo que agrega CTX-PROD va dicho en el ítem.

Las pruebas citadas corren sin servidor de modelos. Las de la demo están en `Demos/MovilidadUrbana.Asistente/tests/MovilidadUrbana.Asistente.Tests/` y se citan desde `Cableado/`; las de un ejemplo, en `Examples/NN-…/Pruebas/`, y se citan con el número del ejemplo. Comandos y modo `--fake`: [Anexo E](#anexo-e).

<a id="anexo-b-dev"></a>
### B.1 Desarrollador .NET (ACT-DEV)

Objetivos: [OA-D1](#oa-d1) a [OA-D9](#oa-d9).

- [ ] Application recibe `IChatClient` o su puerto propio por constructor, y sólo la raíz de composición nombra al adaptador. Se verifica: en la carpeta de 02, `grep -lE "OllamaSharp|using OpenAI" *.cs` lista sólo `Program.cs` (`SoloProgramCs_NombraLosAdaptadores`); en la demo, `SdkDelProveedor_SoloEnInfrastructureAIyProgram` (`Cableado/ArquitecturaTests.cs`). [§4.4](#s4-4), [§5.5](#s5-5).
- [ ] Las opciones del proveedor se fijan en una sola capa, pegada al adaptador, y llegan a toda llamada, también a las del bucle de herramientas. Se verifica: `TodaLlamada_SaleConRazonamientoApagadoYNumCtx` (`Examples/_Comun/MovilidadUrbana.Asistente.Comun.Pruebas/CapaDeOpcionesTests.cs`) y, en 08, `Bucle_TodasLasLlamadasPasanPorLaCapaUnica`. [§5.4](#s5-4).
- [ ] Toda salida estructurada se consume con `TryGetResult`, con campos anulables, y pasa por las reglas antes de guardar; sin resultado, sigue el camino sin IA. Se verifica: en 03, `TextoNoJson_TryGetResultFalse_SinPropuesta_YNoSeEscribe`; en 15, `Catalogo_MedioInventado_FallaConLaClave`; en la demo, `Pd3_SinResultado_CaminoSinIa` y `Pd3_HabitantesInventado_SeTrataComoAusente` (`Cableado/PasosTests.cs`). [§5.3](#s5-3), [§10.3](#s10-3).
- [ ] En RAG, la cita se valida en código contra lo recuperado para esa pregunta, y la recuperación se mide contra dos líneas base sin modelo antes de evaluar la respuesta. Se verifica: en 07, `Validador_CitaNoRecuperada_SeRechazaSiempre`; en la demo, `Pd2_FuenteNoRecuperada_NoSeValida`. [§7.4](#s7-4), [§7.5](#s7-5).
- [ ] Cada paso usa el escalón más bajo que lo resuelve, con su criterio de salto escrito. [§8.1](#s8-1).
- [ ] Cada herramienta cumple la lista de [B.5](#anexo-b-herramientas). [§8.2](#s8-2)–[§8.5](#s8-5).
- [ ] El cableado corre sin red y aparte de las corridas contra el modelo, y cada corrida deja un registro cuyo oráculo se recalcula sin volver a llamar. Se verifica: `tools/verificar.sh correr <carpeta>` pasa sin servidor, y `tools/recalcular-oraculos.sh <registro.jsonl>` sale con 0. [§10.2](#s10-2), [§10.4](#s10-4).

<a id="anexo-b-arq"></a>
### B.2 Arquitecto o líder técnico (ACT-ARQ)

Objetivos: [OA-A1](#oa-a1) a [OA-A6](#oa-a6).

- [ ] Antes de construir un escenario están respondidas las cuatro preguntas de [§2.4](#s2-4), con su métrica, su error caro y el umbral para seguir.
- [ ] Lo que ve la persona cuando la respuesta está mal lo decide el código, no el prompt: el formulario cuando `TryGetResult` da `false`, el «No sé.», el pedido de aprobación. [§2.5](#s2-5).
- [ ] Cada capacidad tiene decidido su contrato, puerto propio o `IChatClient`, según quién define el prompt (ADR-01), y Domain no referencia M.E.AI. Se verifica: `Domain_SinDependenciasDeIa` y `Application_SinInfrastructureNiSdk` (`Cableado/ArquitecturaTests.cs`), que reemplazan al compilador mientras las capas sean carpetas (ADR-11). [§4.3](#s4-3), [§4.4](#s4-4).
- [ ] La estrategia de conocimiento es el escalón más bajo que alcanza: el dato exacto se consulta por herramienta, y el salto a RAG se justifica contra la ventana efectiva (ADR-04, ADR-05). [§6.1](#s6-1), [§6.6](#s6-6), [§7.8](#s7-8).
- [ ] Cada paso tiene fijado su escalón de orquestación, y la cantidad de agentes se decide con métricas deterministas sobre los mismos pedidos (ADR-07). [§8.1](#s8-1), [§8.8](#s8-8).
- [ ] El marco se elige por un mecanismo: M.E.AI primero, MAF por lo que el bucle no trae, Semantic Kernel sólo si ya está. [Criterio de elección de §9](#s9-criterio).
- [ ] Cada decisión que cuesta revertir es un ADR con las alternativas descartadas, las consecuencias negativas y «deja de valer si». [§13.1](#s13-1), plantilla en el [Anexo A](#anexo-a-13).
- [ ] En CTX-EXISTENTE, cada pieza tocada está en la tabla de delta, y un caso de uso que no valida no se expone. Se verifica: `tools/diff-base.sh`, de la demo, falla si un archivo cambiado no tiene fila. [§14.1](#s14-1).

<a id="anexo-b-ops"></a>
### B.3 Operador o DevOps (ACT-OPS)

Objetivos: [OA-O1](#oa-o1) a [OA-O4](#oa-o4).

- [ ] Servidor, modelo, ventana y ambiente salen de variables, y ningún valor de infraestructura vive en el repositorio: el `compose.yaml` de la demo deja las del modelo sin valor. [§5.5](#s5-5), [§12.5](#s12-5), [§12.6](#s12-6).
- [ ] Con un servidor compartido, la ventana es obligatoria y el modelo cargado no se cambia (criterio de la guía). Se verifica: `Compartido_SinNumCtxDelArnes_Rechaza`, en `CapaDeOpcionesTests.cs` y en la demo (`Cableado/ComposicionTests.cs`). [§12.4](#s12-4).
- [ ] El cliente del modelo tiene su espera y su política de reintentos explícitas, sin el manejador estándar que corta cada intento a los 10 s [REF-194]. La fábrica de los ejemplos y la demo da diez minutos y ningún reintento. [§5.5](#s5-5), [§12.7](#s12-7).
- [ ] Toda llamada pasa por `UseOpenTelemetry`, con la fuente y el medidor registrados, y un exportador en memoria muestra qué sale. Se verifica: en 17, `ContenidoApagado_LosSpansNoTraenMensajes_YEnDesarrolloSi`. [§12.1](#s12-1).
- [ ] `EnableSensitiveData` sale siempre del ambiente; en CTX-PROD con CTX-SENS queda apagado. Se verifica: en 17, `Ambiente_SoloDevelopmentEnciendeElContenido`. [§12.2](#s12-2).
- [ ] El tablero usa los nombres de métricas que emite la versión instalada. Se verifica: en 17, `Metricas_MEAIPublicaLosNombresDeSemconv141_QueNoSonLosDeLaConvencionVigente`; versiones en el [Anexo F](#anexo-f). [§12.1](#s12-1).
- [ ] El costo se cuenta por llamadas al modelo, con el orden de caché y telemetría elegido a sabiendas; en CTX-PROD, con un límite de concurrencia, que la demo no tiene. Se verifica: en 17, `CacheAfuera_TresPedidos_DosLlamadasYDosSpans_ElAciertoNoApareceEnLaTelemetria`. [§12.3](#s12-3), [§12.8](#s12-8).
- [ ] Las credenciales viven fuera del repositorio: Secret Manager sólo en desarrollo, un almacén en producción [REF-167] y una credencial por ambiente (criterio de la guía). [§11.6](#s11-6).
- [ ] Un puntaje de LLM juez se interpreta sólo si el juez se calibró; si no, el resultado se apoya en los evaluadores deterministas. [§10.6](#s10-6).

<a id="anexo-b-sec"></a>
### B.4 Responsable de datos y seguridad (ACT-SEC)

Objetivos: [OA-S1](#oa-s1) a [OA-S4](#oa-s4).

- [ ] Cada escenario tiene nombrados sus riesgos de OWASP y el control mínimo en código, en la ficha de riesgo del [Anexo A](#anexo-a-11). [§11.1](#s11-1).
- [ ] Está decidido qué datos llegan a qué modelo: en CTX-SENS, `Nombre` y `Edad` no entran al contexto; en CTX-NUBE, lo que entra sale de la organización. [§11.4](#s11-4).
- [ ] Las trazas y el registro de corridas no llevan datos personales: contenido apagado fuera de desarrollo, personas sintéticas, y en CTX-PROD un backend con política de retención. Se verifica: `tools/compuerta-ac7.sh` sobre los registros, con su lista fuera del repositorio. [§11.4](#s11-4), [§12.2](#s12-2).
- [ ] El permiso de quien pregunta filtra la consulta de recuperación, no lo ya recuperado. [§7.6](#s7-6).
- [ ] Ninguna escritura va sin confirmación (ADR-06); una excepción se registra en un ADR nuevo. [§13.7](#s13-7).
- [ ] La aprobación no se toma por autorización: `X-Sesion-Id` aísla pero no autentica [REF-186], y CTX-PROD pide identidad autenticada y permiso por operación antes del caso de uso. [§11.3](#s11-3), [§14.6](#s14-6).
- [ ] Una defensa contra la inyección indirecta no se declara robusta con un solo texto de ataque del mismo autor. [§11.7](#s11-7).
- [ ] Las herramientas cumplen la lista de [B.5](#anexo-b-herramientas).

<a id="anexo-b-herramientas"></a>
### B.5 Lista de seguridad para herramientas

Vale para ESC-01 con herramientas, ESC-04 y ESC-05 ([§2.1](#s2-1)). Como en [§11.1](#s11-1), los nombres de riesgo son de OWASP para aplicaciones con modelos de lenguaje, 2025 [REF-161], y para aplicaciones agénticas, 2026 [REF-164]; la asignación de cada control a un riesgo es criterio de la guía.

| # | Control | Riesgo | Se verifica con | Dónde |
|---|---|---|---|---|
| 1 | La herramienta envuelve un caso de uso de Application, nunca un repositorio, el `DbContext` ni SQL; si falta el caso de uso, se escribe | LLM06:2025 [REF-162] | `Herramientas_SinRepositorios` (`Cableado/ArquitecturaTests.cs`) | [§8.4](#s8-4) |
| 2 | La sesión la pone el código antes de armar las herramientas; ninguna firma recibe un id de sesión | ASI03 | en 08, `DosSesionesEnParalelo_NoSeVen`; en la demo, `Circuito_DosSesiones_NoSeVen` (`Cableado/SesionesTests.cs`) y `PedidoQueNombraOtraSesion_NoLaAlcanza` (`Cableado/AprobacionTests.cs`) | [§8.3](#s8-3) |
| 3 | Toda escritura se monta con `ApprovalRequiredAIFunction`; las lecturas, sin | LLM06:2025 [REF-162] | `TodaEscritura_EsAprobable` (`Cableado/AprobacionTests.cs`) | [§8.5](#s8-5) |
| 4 | Con texto que la aplicación no escribió: si llega al armar el pedido, no se montan escrituras; si llega a mitad del bucle, una escritura sólo corre aprobada y una no aprobable se rechaza | LLM01:2025 [REF-160] | `ContextoNoConfiable_SinHerramientasDeEscritura`, `Escritura_ConResultadoNoConfiable_PideAprobacion` y `Escritura_NoAprobable_ConResultadoNoConfiable_Rechaza` (`Cableado/AprobacionTests.cs`); en 16, `Origen_SinHerramientaDeEscritura_CeroPedidosPosibles` | [§11.3](#s11-3) |
| 5 | El pedido de aprobación muestra lo que resolvió el código (localidad, provincia, id, «de tu sesión») y avisa si viene después de texto no confiable; la respuesta se arma sobre el pedido guardado | ASI09 | `PedidoDeAprobacion_MuestraArgumentosResueltos` (`Cableado/PasosTests.cs`) y `Aprobacion_ArgumentosAlterados_SeRechaza` (`Cableado/AprobacionTests.cs`) | [§8.5](#s8-5), [§11.3](#s11-3) |
| 6 | Sobre datos de personas, la herramienta devuelve agregados con un tipo sin `Nombre` ni `Edad`; lo prueba el código, no otro modelo | LLM02:2025 | `Pd1_ResumirEncuesta_SinDatosPersonales` (`Cableado/PasosTests.cs`) | [§11.4](#s11-4) |
| 7 | El bucle tiene tope de iteraciones y de errores seguidos | LLM10:2025 | en 08, `GuionRepetido_ElBucleSeCortaEnElTope`, que prueba el tope de iteraciones; el de errores seguidos no tiene prueba ni en 08 ni en la demo. La demo fija 5 y 2 en `SesionDeChat`, y su prueba de composición sólo comprueba que estén | [§8.2](#s8-2) |
| 8 | Como servidor MCP: sólo lecturas y sólo loopback, con `Host` filtrado y `Origin` validado, mientras no haya la autorización que define la especificación [REF-199]; ninguna de las tres cosas es control de acceso [REF-196] | LLM06:2025, ASI03 | en 13, `Servidor_EscuchaSoloEnLoopback`, `Mcp_HostYOrigenAjenos_Rechaza` y `Listado_SoloLecturas_YLaSesionFijaNoVeLaApi` | [§11.5](#s11-5) |
| 9 | Como cliente MCP: se monta sólo la lista permitida por nombre, con la descripción del cliente; las anotaciones del servidor no deciden [REF-198]; una escritura permitida va aprobable | ASI02 | en 13, `ServidorGuionadoConBorrarTodo_ElClienteNoLaMonta` y `Montaje_UsaLaDescripcionDelCliente_YUnaEscrituraPermitidaVaConAprobacion` | [§8.9](#s8-9), [§11.5](#s11-5) |

Los resultados de un servidor MCP cuentan como texto no confiable para el control 4 (criterio de la guía, [§11.3](#s11-3)); 13 no lo ejercita porque no monta escrituras. Cada control es una garantía del código y vale con cualquier modelo. La lista no cubre la autorización, que la aprobación no reemplaza ([§14.6](#s14-6)), ni la conducta del modelo ante la inyección ([§11.7](#s11-7)).

<!-- PENDIENTES:
Quitado por falta de respaldo citable:
- Valores por defecto de MaximumIterationsPerRequest (40) y MaximumConsecutiveErrorsPerRequest (3) de M.E.AI: sólo los respalda una inspección de ensamblado del dossier N5 (§2.8), sin REF; el control 7 nombra los topes del código (08: 3 y 2; demo: 5 y 2) sin los defaults.
- «Lo que anuncia un servidor ajeno es no confiable» como MUST de la especificación (redacción del plan para PR-21): la fuente verificada (REF-198) dice MUST sólo para las anotaciones; validar resultados es SHOULD. El control 9 cita lo que dice la fuente y la frase sobre resultados va como criterio de la guía, igual que §11.5.
- Que la demo pruebe el corte del bucle: no lo prueba; Composicion_ValidateScopes sólo afirma que MaximoDeIteraciones y MaximoDeErroresSeguidos son > 0. Se dice así en el control 7.
- Que 13 aplique la política de origen a los resultados MCP: no la aplica (no monta escrituras); se dice así debajo de la tabla.
- Una lista para ACT-USR: no es lector (§2.3); no lleva lista.
Fuentes dadas de alta: ninguna. Se usan REF-160, REF-161, REF-162, REF-164, REF-167, REF-186, REF-194, REF-196, REF-198, REF-199.
Verificación adversarial (2026-10-27): se agregó el archivo de la demo a las pruebas de los controles 2, 4, 5 y 6, porque `Aprobacion_ArgumentosAlterados_SeRechaza` y `Escritura_ConResultadoNoConfiable_PideAprobacion` existen también en 09, 11 y 16; el control 7 aclara que ninguna prueba ejercita MaximumConsecutiveErrorsPerRequest (grep en 08 y en la demo).
Desvíos de la ficha:
- El plan enumera ocho puntos para la lista de seguridad; la tabla tiene nueve controles porque separa «toda escritura con aprobación» (3) de «sin escrituras con texto no confiable» (4), que el plan pone en el mismo punto, para que cada uno tenga su prueba.
- El plan dice «ninguna herramienta de escritura montada cuando el contexto trae texto recuperado o externo»; el control 4 sigue la forma en dos reglas de §11.3 (al armar el pedido, sin escrituras; a mitad del bucle, sólo aprobadas), que es lo que hace el código de la demo y de 16.
- Riesgos de los controles 8 y 9 (LLM06/ASI03 y ASI02): el plan no los asigna; se toman de las filas de ESC-05 de la tabla de §11.1 y se declaran criterio de la guía.
- La ficha del anexo no prevé ejemplos, diagramas ni preguntas guía: el anexo no lleva snippets (su casa es §8 y §11) ni mermaid; cada ítem remite a la prueba que lo verifica.
- Títulos de las subsecciones numerados «B.1…B.5», sin «§», para no tocar la compuerta de remisiones al plan.
Procedencia: sin salidas de modelo. Nombres de pruebas comprobados contra el árbol el 2026-10-27: Demos/…/Cableado/ArquitecturaTests.cs (Domain_SinDependenciasDeIa, Application_SinInfrastructureNiSdk, SdkDelProveedor_SoloEnInfrastructureAIyProgram, Herramientas_SinRepositorios), AprobacionTests.cs (Aprobacion_ArgumentosAlterados_SeRechaza, Escritura_ConResultadoNoConfiable_PideAprobacion, Escritura_NoAprobable_ConResultadoNoConfiable_Rechaza, ContextoNoConfiable_SinHerramientasDeEscritura, TodaEscritura_EsAprobable, PedidoQueNombraOtraSesion_NoLaAlcanza), PasosTests.cs (Pd1_ResumirEncuesta_SinDatosPersonales, Pd2_FuenteNoRecuperada_NoSeValida, Pd3_SinResultado_CaminoSinIa, Pd3_HabitantesInventado_SeTrataComoAusente, PedidoDeAprobacion_MuestraArgumentosResueltos), SesionesTests.cs (Circuito_DosSesiones_NoSeVen), ComposicionTests.cs (Compartido_SinNumCtxDelArnes_Rechaza, en la clase ConfiguracionTests); Examples/02 CambioDeAdaptadorTests.cs (SoloProgramCs_NombraLosAdaptadores; el grep, del README de 02); 03 SalidaEstructuradaTests.cs; 07 RagConCitasTests.cs; 08 HerramientasTests.cs (DosSesionesEnParalelo_NoSeVen, GuionRepetido_ElBucleSeCortaEnElTope, Bucle_TodasLasLlamadasPasanPorLaCapaUnica); 13 McpTests.cs; 15 CableadoTests.cs; 16 InyeccionIndirectaTests.cs; 17 ObservabilidadTests.cs; _Comun CapaDeOpcionesTests.cs (TodaLlamada_SaleConRazonamientoApagadoYNumCtx, Compartido_SinNumCtxDelArnes_Rechaza). Constantes: SesionDeChat.MaximoDeIteraciones = 5, MaximoDeErroresSeguidos = 2; FabricaDeClientes.TimeoutDelModelo = 10 min. Herramientas: tools/verificar.sh, tools/recalcular-oraculos.sh (sale 0 si todo coincide), tools/compuerta-ac7.sh, Demos/MovilidadUrbana.Asistente/tools/diff-base.sh.
Conteo de palabras de prosa (comando de la carta §16.3): 1.490, de las cuales buena parte son celdas de la tabla de B.5 y nombres de pruebas. El plan no reparte el tope de Anexos (7.430) por anexo: B toma ~20 %. Si la relectura recorta, orden sugerido: ítems de B.2 que repiten un «Qué decisión toca» (marco, ADR), el párrafo de convenciones, la última oración de B.5.
Anclas que todavía no existen en secciones/ (previstas en la carta §13; las ponen §0 y los Anexos A, E y F): oa-d1, oa-d9, oa-a1, oa-a6, oa-o1, oa-o4, oa-s1, oa-s4, anexo-a-11, anexo-a-13, anexo-e, anexo-f. El resto se comprobó contra los id de secciones/.
REF agregados al citar: REF-167 (Secret Manager), REF-186 (X-Sesion-Id no autentica), REF-194 (AttemptTimeout de 10 s), ya usados en §11 y §12.
Compuertas corridas sobre la sección sin este comentario: remisiones al plan 0; familias de ID 0 (con LC_ALL=C y con el locale); voseo 0; IPs, rutas y puertos 0; alias en títulos 0. AC-7/AC-8 sin correr (las corre la integración). Marcas «criterio de la guía»: 5 (una con mayúscula inicial).
Snippets: ninguno. Mermaid: ninguno.
Remisiones usadas: s2-1, s2-3, s2-4, s2-5, s4-3, s4-4, s5-3, s5-4, s5-5, s6-1, s6-6, s7-4, s7-5, s7-6, s7-8, s8-1, s8-2, s8-3, s8-4, s8-5, s8-8, s8-9, s9-criterio, s10-2, s10-3, s10-4, s10-6, s11-1, s11-3, s11-4, s11-5, s11-6, s11-7, s12-1, s12-2, s12-3, s12-4, s12-5, s12-6, s12-7, s12-8, s13-1, s13-7, s14-1, s14-6, anexo-a-11, anexo-a-13, anexo-e, anexo-f, oa-d1, oa-d9, oa-a1, oa-a6, oa-o1, oa-o4, oa-s1, oa-s4; internas: anexo-b-herramientas.
Cifras citadas: ninguna medición. 5 y 2 (demo), 10 s y diez minutos son constantes de código o de configuración ya citadas en §5.5 y §12.7.
-->
