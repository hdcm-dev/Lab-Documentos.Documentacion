---
doc_id: BIT-16-RED-02-PEND
doc_type: registro-de-pendientes
title: Pendientes de redacción (comentarios PENDIENTES de las secciones)
status: vigente
origin: agent (ensamblado de la guía)
last_review: 2026-10-27
---

# Pendientes de redacción

Copia textual de los comentarios `<!-- PENDIENTES: … -->` que cada sección de `secciones/` traía al final. En la guía ensamblada se quitaron; las fuentes en `secciones/` no se tocaron. Al final, lo que dejó abierto el propio ensamblado.

## §0 (`secciones/00.md`)

Quitado por falta de respaldo o porque el cuerpo no lo sostiene:
- §0.3 (b) prometía, según la ficha, que §8.3 explica «el circuito de Blazor Server y por qué no ve la petición HTTP». Ninguna sección lo explica: §8.3 trata la sesión en 08 (consola) y la palabra «circuito» sólo aparece en §8.7, §8 Ejemplos, §13.13 y §14. Se remite a §13.13 con la forma honesta («dónde vive la conversación del chat en Blazor, el circuito»). Si se quiere la explicación completa, falta en §8.3 o §13.13.
- «R-LLM» en OA-D9 («registrar una corrida R-LLM»): es vocabulario interno; quedó «dejar registrada una corrida contra el modelo».
- «Imagen de entrada» en OA-0.2: la guía es autocontenida; quedó «la diapositiva de §1».
- Párrafo sobre por qué las ADR van al final y la seguridad no espera a la Parte V (carta §2.2): sacado por presupuesto; la plantilla de §0.4 ya muestra «Qué decisión toca» y cada sección lo aplica.
- «El laboratorio usó un Ollama compartido… cuyos tiempos no se comparan»: sacado por presupuesto; lo dicen §5.7, §14.5 y el Anexo E.3.
Fuentes dadas de alta: ninguna. REF usado: REF-186 (caso base, commit 8fb4c3a).
Desvíos de la ficha:
- §0.0: la ficha pide la tabla generada por tools/toc.sh, que no existe. Se generó con un script desde los encabezados con ancla de secciones/*.md (01–15, A, B, E) más las anclas previstas de la carta §13 para los anexos C, D, F y G, que todavía no tienen archivo. Formato compacto: partes y secciones con título; subsecciones numeradas sólo por número, para el presupuesto. Hay que regenerarla al integrar.
- §0.1: se sacó la columna «Actor»; el prefijo del ID la reemplaza y se explica en la apertura de §0.1. El texto de los 27 OA es el de la carta §5, con los dos cambios de arriba; el orden es el que usa §15.
- §0.2: ACT-OPS suma §14.5 respecto de la ficha, porque la regla de derivación lo exige (§14.5 está en la columna de OA-O2). Las demás rutas son las de la ficha. ACT-SEC conserva §8.9 «a mano» sin motivo escrito (la ficha tampoco lo da; lo usa §11.5).
- §0.3 (c): versión corta con remisión a Anexo E.3, que ya detalla herramientas, servidores y fases (escrito en paralelo).
- §0.5: además del Anexo E, remite a E.1, E.2, E.5 y E.6.
- Sin línea «Estás en»: §0 no es sección temática.
Respaldo de los datos de §0.3: Examples/README.md (bash, docker, jq, GNU grep; imagen del SDK 10.0; --fake; variables), Demos/MovilidadUrbana.Asistente/src/MovilidadUrbana.Asistente/Domain/Entities/Localidad.cs, RespuestaDeEncuesta.cs, Domain/Catalogos.cs, Application/Localidades/LocalidadPolicy.cs, Infrastructure/DependencyInjection.cs (UseSqlite), Sessions/SessionHeaderMiddleware.cs (X-Sesion-Id), Infrastructure/Sessions/SessionContext.cs (cookie sesion-movilidad, copiada de la web del caso base), tests/*.csproj (NUnit). «Diecisiete ejemplos» y «seis pasos»: carpetas 01–17 de Examples/ y PD-1…PD-6.
Procedencia de las salidas: ninguna salida de modelo. Los dos rótulos de §0.4 son la forma de la carta §16.6, con los valores registrados (modelo, digest, versión de Ollama, servidor y fecha) que ya usan las demás secciones.
Conteo y tope (comando de la carta §16.3): 1.788 palabras de prosa con la tabla de contenido; 1.487 sin ella (la tabla de contenido sola da 301; la tabla de OA, 634). Tope de la Parte 0: 1.400. Exceso: +6 % sin la tabla de contenido, +28 % con ella. Primer borrador: 2.417; se recortaron la columna Actor, el párrafo de las ADR, la línea del servidor compartido y se compactaron §0.3 y §0.4. Propuesta para la presidencia: tratar la tabla de contenido como material generado y no contarla (como las tablas del Anexo F). Aun así, la tabla única de OA ocupa casi la mitad del tope; el resto de §0 (definiciones de vocabulario que pide la carta §16.8, rótulos, forma de las secciones y el caso) no baja más sin perder algo que el plan exige.
Snippets por encima del tope: ninguno (sin snippets de código; dos bloques: el mermaid de la columna vertebral, copiado de la carta §2.2, y la plantilla de encabezados en text).
Mermaid: el de la columna vertebral, igual al de la carta §2.2; etiquetas entre comillas, sin paréntesis ni comillas internas, saltos con <br/>.
Compuertas corridas sin este comentario: remisiones al plan 0, familias de ID 0, IPs y rutas de máquina 0, voseo 0, alias 0, «nosotros» 0. AC-7/AC-8 sin correr (las corre la integración). Anclas: las 143 remisiones resuelven contra secciones/*.md salvo anexo-c, anexo-d y anexo-f, previstas en la carta §13 y sin archivo todavía (anexo-g ya está en G.md; verificación adversarial 2026-10-27).
Remisiones usadas: s1, s2-1 … s2-5, s2-3, s3, s3-0 … s3-5, s4-1 … s4-6, s5-1 … s5-8, s6, s6-1 … s6-7, s7, s7-1 … s7-8, s8-1 … s8-10, s9, s9-1 … s9-8, s10-1 … s10-8, s11, s11-1 … s11-8, s11-preguntas, s12, s12-1 … s12-10, s13, s13-1 … s13-15, s14, s14-1 … s14-6, s15, cierre, parte-i … parte-vi, anexo-a … anexo-g, anexo-a-11, anexo-e-1, anexo-e-2, anexo-e-3, anexo-e-5, anexo-e-6; internas: parte-0, s0, s0-0 … s0-5 y las 27 anclas oa-… que piden las demás secciones (oa-0-1 … oa-sk1).
Verificación adversarial (2026-10-27): (1) §0.3 decía sólo `OLLAMA_ENDPOINT`; Examples/README.md (Variables) y Anexo E.3 exigen además `OLLAMA_PROPIO_ENDPOINT` para 02, 05, embeddings y el juez de 15: agregado. (2) ACT-SEC: §7.1–§7.5 y §8.9 no se derivan de sus OA; se pasaron a «a mano» con motivo, como pide la regla de §0.2. (3) Plantilla de §0.4: §5.8 se titula «Decisión en curso» (carta §16.1); agregado. (4) Recorte de salida «[…]» (carta §16.6): agregado. Suman unas 35 palabras.
Cifras citadas: ninguna medida. «M ≤ 12» es la regla de la carta §10, no una medición.

## §1 (`secciones/01.md`)

Quitado por falta de respaldo citable o por decisión de la mesa:
- Autoría de la diapositiva: el dossier de la capa en el stack la da por no verificada; la marca que lleva no se nombra porque la ficha decide no reproducir la imagen ni su marca (decisión revertible de la mesa). Si la presidencia revierte, se agrega la atribución «diagrama tomado de una captura provista por el PO», sin más.
- Corregido por la verificación: la frase «La única flecha que entra a la franja de IA viene de la lógica de negocio» contradecía la lectura literal de N1 §1.1 y de REED-16 §1.1, que registran también una flecha doble entre la caja de recuperación y la Vector DB de Database. Se reemplazó por «Dos flechas dobles tocan la franja de IA: una la une con la lógica de negocio y otra con la base vectorial.»; para no pasar el tope se acortó la última oración de la tesis («Cuando un ejemplo sube de más…»). Conteo después del cambio: 700.
- Lista completa de componentes de la imagen (API Gateway, Kubernetes, Object Storage…): condensada en la descripción para respetar el tope; la tabla pieza por pieza es de §3.1.
- Corrección «LLM → RAG → Agents es una progresión, no un flujo»: no se escribe acá; es parte de la respuesta de la pregunta de §3.1 y de §3.2 (una casa por pieza). Acá sólo queda la mención de las dos escaleras.
- Pasos que suben más de lo necesario (PD-2, PD-6 y 11, variante de dos agentes de 12): la tesis los anuncia en una oración; el detalle va en cada sección que los usa.
- Mensaje del diagrama de secuencia del plan («CP 34, unos 90 mil habitantes» y «Result con errores»): reemplazado por el estímulo real de PD-3 del README de la demo y por lo que devuelve el código (`PropuestaDeAlta` con `Faltantes`, sin guardar). El diagrama no muestra una salida del modelo: muestra el flujo del código, por eso no lleva rótulo de observación. Que en el humo de PD-3 el modelo dejó `habitantes` en null está rotulado en §5 (Ejemplos, «En la demo»).
Fuentes dadas de alta: ninguna.
Desvíos de la ficha:
- Sin subsecciones numeradas (la ficha y las anclas de la carta §13 no prevén s1-k): párrafos con entrada en negrita, en el orden propósito → desarrollo → diagrama → preguntas guía.
- Sin línea «Estás en»: §1 no es sección temática.
- Diagrama de capas: simplificado del de §B.1 del plan (sin Third-Party Integrations ni la caja de recuperación; sin paréntesis, comillas ni asterisco en las etiquetas; el cilindro pasó a nodo rectangular).
- Diagrama de secuencia: participantes con «·» en lugar de paréntesis; sin punto y coma ni dos puntos dentro de los mensajes; nombres tomados de AltaDesdeTextoService.cs, IExtractorDeLocalidad.cs, ExtractorDeLocalidad.cs, GarantiaNumerica.cs, LocalidadRules.cs y DesdeTextoController.cs de la demo.
Procedencia de las salidas: ninguna salida de modelo en la sección.
Respaldo de los datos del caso: entidades de la demo (Domain/Entities/RespuestaDeEncuesta.cs: Medios, Frecuencia, Distancia, Minutos, Motivo; LocalidadRules.cs) y README de la demo (CTX-EXISTENTE, «sin reescribir sus casos de uso», recorrido PD-1…PD-6), con procedencia en el commit 8fb4c3a del caso base [REF-186].
Conteo y tope: 700 palabras de prosa con el comando de la carta §16.3; tope 700. Primer borrador 764: se condensaron la descripción de las franjas, la apertura, el caso y la remisión de preguntas guía. Sin margen: cualquier agregado tiene que sacar lo mismo.
Anticipo de escenarios: ESC-01, ESC-03 y ESC-04 en la demo; ESC-02 y ESC-05 en los ejemplos (carta §4.1, cobertura). Los nombres de los escenarios no se repiten acá: su casa es §2.
Compuertas corridas sin el comentario: remisiones al plan 0, familias de ID 0, rutas e IPs 0, voseo 0, alias 0. AC-7/AC-8 sin correr (las corre la integración). Mermaid validado a mano: etiquetas entre comillas, sin paréntesis ni comillas internas, sin punto y coma en el diagrama de secuencia.
Snippets por encima del tope: ninguno (sin snippets; se cita una ruta).
Remisiones usadas: s2, s3-1, s3-2, s4-4, s11, s14-1, s14-2, s14-3, s14-6, oa-0-2, oa-a5.
Cifras citadas: ninguna (el 3432 y los 12 requisitos no se citan; 3432 aparece sólo como texto del estímulo).

## §2 (`secciones/02.md`)

Quitado por falta de respaldo citable:
- «Anthropic: sumar complejidad sólo cuando demostrablemente mejora los resultados»: el dossier de producto lo cita, pero la carta (§2.1) prohíbe prometer una demostración que los ejemplos no hacen. §2.4 se apoya en REF-03 y REF-117.
- Las tres responsabilidades nuevas que el dossier de producto proponía sumar a ACT-DEV (conjunto de evaluación, realimentación, registro de ADR): el plan no las recoge en la fila; queda el conjunto de evaluación, con remisión a §10.7.
- Cifras de mercado del ensayo de 2023: no entran (criterio del dossier de producto).
- Que las pautas de Amershi sean «las más citadas»: no verificado; no entra.
- Ningún umbral numérico en §2.4: no hay respaldo y el plan lo prohíbe en las pruebas. Las métricas por escenario son criterio de la guía.
- G2 («qué tan bien»): la demo no la materializa; la tabla lo dice en lugar de afirmar cobertura.
- ESC-02 en el caso: el marco N0 decía «buscar localidades o respuestas por descripción»; ningún artefacto lo hace. Se reescribió sobre lo que hace el ejemplo 06.
- ESC-04 en el caso: N0 decía «alta, modifica o consulta»; la demo da de alta, cuenta y borra (no modifica). Se escribió lo que existe.
- ESC-01: N0 traía «¿Qué medio de transporte declararon más…?»; se usa la frase de PD-1 («¿Qué medio usa más la gente?»), que es la que existe en la demo.
- Recortes por el tope (orden de la carta §16.3): literales en inglés de las pautas G1–G18 (quedan las paráfrasis con REF-01); columna «Qué cambia» de CTX-EXISTENTE/NUEVA en la tabla (va en el párrafo); columna «En la capa de IA» de la tabla de pautas; la mención de NIST que ubica a desarrolladores e integradores en el despliegue (REF-05); los 49 practicantes y 20 productos de REF-01; la calidad de herramientas en la fila CTX-LOCAL (va en el párrafo con su medición).
Fuentes dadas de alta: ninguna.
Desvíos de la ficha:
- Línea «Estás en»: la plantilla la exige sólo en secciones temáticas; se agregó una línea transversal sin escalón ni capa, con los tres OA de la sección. Si la presidencia prefiere que §1–§3 no la lleven, se borra sin otro cambio.
- Ancla de las preguntas guía: la carta no la fija para §2; se usó `s2-preguntas` (nivel 3, sin número), por analogía con `sN-preguntas`.
- Tabla de actores: sin la columna «Necesita de la guía» de N0; la ruta por actor vive en §0.2.
- La marca pendiente del marco N0 sobre herramientas de Qwen se resolvió con el registro de la extensión de 08 y REF-51, sin copiar la marca.
- Diagrama: ninguno, como fija la ficha («ninguno nuevo; tablas»).
Procedencia de las salidas y conducta citada:
- 08 extensión, 4/4 legítimas: Evidencia/R-LLM/08-Primera-Herramienta-Solo-Lectura.modelo-ext.jsonl (xl01–xl04; metadatos de la primera línea: qwen3.5:4b, 2a654d98e6fb, 0.32.0-rc0, compartido, 2026-10-27). IC95 de la tabla de cifras de la carta. Estímulo del mismo autor según Examples/08-…/README.md.
- 07, «No sé» 0/4 (n01–n04) y «cita y contradice» 1/12: Evidencia/R-LLM/07-RAG-Con-Citas.modelo.jsonl; IC95 de Examples/07-RAG-Con-Citas/README.md (tabla de tasas). Estímulo del mismo autor según ese README.
- Textos de la página de chat: Demos/MovilidadUrbana.Asistente/src/MovilidadUrbana.Asistente/Components/Pages/Chat.razor (encabezado y banda de aprobación). No son salidas de modelo.
- `EncuestaService.RegistrarAsync` guarda sin validar: Demos/MovilidadUrbana.Asistente/src/MovilidadUrbana.Asistente/Application/Encuestas/EncuestaService.cs; que no se expone: README de la demo, tabla de herramientas.
- Cinco respuestas de CTX-EXISTENTE: README de la demo («Un solo host», «Capas como carpetas», «Delta frente al caso base») y el comentario de endurecimiento de LocalidadRules.cs.
Verificación adversarial (2026-10-27): ESC-03 nombraba `LocalidadModel`, pero el extractor devuelve `LocalidadPropuesta` (Application/Abstractions/IExtractorDeLocalidad.cs, AltaDesdeTextoService.cs): corregido. «La expresión regular ya lo resuelve [REF-117]» atribuía a REF-117 un hecho del código: ahora nombra `LocalidadRules.CodigoPostalValido` (`^\d{4}$`) y REF-117 respalda sólo el principio. Recorte compensatorio: «aquí,» en CTX-LOCAL.
Conteo y tope: 1.500 palabras de prosa (tras la verificación; antes 1.496) (comando de la carta §16.3); tope de la sección: 1.500. La primera versión daba 2.531 y se recortó por el orden de la carta.
Snippets por encima de 25 líneas: ninguno (LocalidadRules.cs, 6 líneas, recortado con «// …»; se saltearon las dos líneas de comentario del endurecimiento porque llevan IDs internos; la enseñanza va en la prosa).
Remisiones usadas: s0-4, s3-0, s3-3, s5-3, s7-4, s7-5, s8-5, s9-7, s10-4, s10-7, s12-4, s12-8, s12-9, s13-12, s13-14, s14-1, oa-0-1, oa-a2, oa-a6; internas: s2-4.
Cifras citadas (todas en la tabla de cifras citables de la carta): 08 extensión 4/4 legítimas IC95 [0,398; 1]; 07 «No sé» 0/4 IC95 [0; 0,602] y «cita y contradice» 1/12 IC95 [0,002; 0,385]. Cifras de fuente, no medidas: 18 pautas y cinco del momento de error (REF-01).
AC-7/AC-8 sin correr (las listas viven fuera del repositorio).

## §3 (`secciones/03.md`)

Quitado por falta de respaldo o por decisión de forma:
- Columna «Fuente» de la tabla de capas del plan: llevaba IDs de dossier, que no llegan a la guía. Se reemplazó por «Ver», con la sección que desarrolla cada pieza y cita su fuente.
- «La IA sólo se comunica con el Backend, nunca con el Frontend» (lectura del dossier de la capa en el stack, criterio propio de ese dossier): no entra, porque la demo tiene una excepción declarada (la página de chat consume el IChatClient del asistente). La respuesta de OA-0.2 dice sólo «un lugar propio junto a la lógica de negocio».
- Paquetes y nombres de SDK en la tabla de capas (OllamaSharp, SDK de OpenAI contra /v1, InMemoryVectorStore, UseOpenTelemetry/UseLogging, IDistributedCache): fuera por el tope; la tabla nombra la pieza y remite a la sección que la muestra. Versiones: ninguna (Anexo F, por remisión de las secciones temáticas).
- Cifras: ninguna. Se evitó «doce requisitos» y el tamaño en tokens del corpus (el tamaño no se midió en la construcción; §6.2 lo dice).
- Que el escalón 0 de conocimiento valga para PD-1, PD-3, PD-4, PD-5 y PD-6 («todos los demás pasos»): criterio de la guía, leído del código (instrucciones fijas en SesionDeChat.cs, ExtractorDeLocalidad.cs y ExtractorDeEncuesta.cs; los datos llegan por herramientas). PD-2 también es agencia 0 (una llamada); el diagrama no lo dibuja para no cruzar subgrafos.
Fuentes dadas de alta: ninguna.
Desvíos de la ficha:
- Línea «Estás en»: §3 no es temática; se usó la forma transversal de §2 («transversal · todas las capas · OA-0.2, OA-0.3»). Si la presidencia prefiere que §1–§3 no la lleven, se borra sin otro cambio.
- Preguntas guía: las tres al final, en «Preguntas guía de §3» (ancla s3-preguntas, nivel 3 sin número, como s2-preguntas). La de OA-0.2 tiene su casa declarada en §3.1 y §1 enlaza a #s3-1: §3.1 cierra con una remisión a s3-preguntas. Alternativa: que §1 enlace directo a #s3-preguntas (cambio de una línea en 01.md, a cargo de la integración).
- §3.2: diagrama de las dos escaleras sin nombres de API (la ficha pide la versión legible; quedan fuera UseFunctionInvocation y ApprovalRequiredAIFunction). Se agregó la flecha del escalón −1 a los dos escalones 0 para que el nodo no quede suelto. La versión con API vive en §6.1 y §8.1.
- §3.3: «mapa por escenario (flowchart de decisión)» de la ficha. Es por escenario y no por estrategia de conocimiento, para no duplicar el flowchart de §6.1. Orden de las preguntas: criterio de la guía (primero la función, después ESC-05, ESC-04, ESC-03, ESC-02 y ESC-01).
- Tabla de cobertura: copiada de la ficha del plan (respuesta de la presidencia del ciclo 2). Observación: el ejemplo 08 es de sólo lectura y §8 lo trata como «ESC-01 con herramientas»; la ficha lo pone en ESC-04. Se respetó la ficha; si la presidencia lo mueve, cambia una celda.
- Tabla por escenario: en la columna «Cambia» va un solo contexto de uso por fila, tomado de la «Aplicación por escenario» de §8 (ESC-01, ESC-04, ESC-05), de §2.2 (CTX-NUEVA en ESC-03) y de OA-S3/§7.6 (ESC-02). «ninguno» y «del cliente» en lugar de «—», porque «—» significa otra cosa en las tablas de Aplicación por escenario (carta §16.12).
- Tercera pregunta guía («Mi caso necesita saber y actuar…»): el ejemplo PD-5 está tomado de la tabla de §14.3 (pedido «Agregá Goya, Corrientes, CP 34, con 90000 habitantes.»), recortado con «…»; no se citan sus números.
Procedencia de las salidas: ninguna salida de modelo en la sección (ficha: «ningún ejemplo propio»).
Respaldo de lo que no lleva REF:
- Servidor MCP como adaptador de entrada: §8.9 de la guía. En el ejemplo 13 el código vive en Examples/13-Servidor-Y-Cliente-MCP/Infrastructure/Mcp/ (ServidorMcp.cs, LecturasMcp.cs); la tabla de capas lo pone en Presentación por su función (criterio de la guía, como en el plan). Si la relectura lo objeta, la celda puede decir «adaptador de entrada; en 13, carpeta Infrastructure/Mcp».
- Almacén de vectores en memoria: InMemoryVectorStore en Demos/.../Infrastructure/AI/Ayuda/AyudaConRecuperacion.cs y en Examples/07-RAG-Con-Citas/Application/IndiceDeAyuda.cs.
- Caché de respuestas en el pipeline: Examples/17-Observabilidad-Y-Pipeline/Infrastructure/PipelineObservado.cs (UseDistributedCache). La demo no la usa.
- EF Core con SQLite: Demos/.../Infrastructure/DependencyInjection.cs (UseSqlite).
- Ejemplos por escalón: 01 (AsistenteDeAyuda.cs, requisitos de las *Policy en las instrucciones), 05 (padrón escrito para el ejemplo, según su README y §6), 07 (recuperación top-3 con cita), 03, 08, 10, 11, 12 según §5, §8 y la tabla de §14.3.
- Orden de las preguntas y la frase «la salida de un objeto para guardar» como rasgo de ESC-03: tomados de la tabla de escenarios de §2.1.
Conteo y tope: 1.300 palabras de prosa con el comando de la carta §16.3; tope de §3: 1.300. Primer borrador 1.629; se recortó por el orden de la carta (aclaraciones repetidas, columnas de detalle, transiciones). Sin margen.
Respuestas de las preguntas guía: 88 a 98 palabras cada una (rango 60–130).
Snippets: ninguno (la ficha no prevé ejemplos propios).
Compuertas corridas sin el comentario: remisiones al plan 0; familias de ID 0; rutas e IPs 0; voseo 0; alias 0 salvo «LLM» dentro de las etiquetas literales de la diapositiva («AI LAYER · LLM», «LLM → RAG → Agents»), que el glosario permite como cita literal. AC-7/AC-8 sin correr (las corre la integración). Mermaid validado a mano (tres bloques): etiquetas entre comillas dobles, sin paréntesis ni comillas internas, saltos con <br/>, aristas con texto en la forma que usa §6.1, aristas a subgrafos en §3.5 (sintaxis de flowchart admitida por GitHub).
Remisiones usadas: anexo-e, oa-0-2, oa-0-3, s0-4, s1, s2-1, s2-2, s4-1, s4-3, s4-4, s5, s5-1, s5-3, s6, s6-1, s6-3, s6-4, s6-6, s7, s7-1, s7-3, s8, s8-1, s8-2, s8-3, s8-4, s8-5, s8-6, s8-7, s8-9, s9-7, s11-3, s11-4, s11-5, s12, s12-4, s13-12, s14-2, s14-3; internas: s3-1, s3-preguntas.
Referencias citadas: REF-11, REF-12, REF-13, REF-45, REF-47, REF-85, REF-86, REF-87, REF-115, REF-116, REF-117, REF-121.
Cifras citadas: ninguna.
Verificación adversarial (2026-10-27): REF-11/12/13/45/47/85/86/87/115/116/117/121 cotejadas con su fila del registro y el dossier (N1 F02–F17, N4 F01/F21; «un agente puede no usar RAG» = N1 §1.1); tipos y archivos de la tabla de capas confirmados en Demos/ y Examples/ (controllers, IExtractorDe*, IAyuda, *Rules, Catalogos, InMemoryVectorStore, UseDistributedCache en 17, UseSqlite, OLLAMA_ENDPOINT); pasos PD contra la tabla de §14.3; README de 01, 05, 08–14 y 16; anclas internas y externas presentes (oa-0-2, oa-0-3, s0-4 en 00.md); los tres mermaid renderizados con mermaid-cli sin error; barrido R-PRIV/RD-PO 0. Cambios: [REF-121] y [REF-47] se movieron antes de la parte que es criterio de la guía («acá envuelve un caso de uso», «sigue siendo una propuesta»); §3.1 abre con «Criterio de la guía:» (N1 §1.1 lo marca como criterio propio); §3.4 fila 14: «sin cambiar el esquema» → «mismo esquema de parámetros» (README de 14, punto 3: el esquema de la función entera difiere por la clave `condition` de SK); respuesta de OA-0.2: «esa caja ausente» → «la ausencia del servidor» (había dos cajas ausentes). Compensación: «una sola vez» y «cae ahí» fuera; conteo final 1.300.

## §4 (`secciones/04.md`)

Quitado por falta de respaldo citable:
- «Temperatura 0 no garantiza determinismo»: N1 lo marca criterio propio y no verificado; la carta §16.9 no deja marcar con «criterio de la guía» una afirmación sobre la conducta de un modelo. Queda como «no verificado con Ollama y Qwen».
- «Dos embeddings de modelos distintos no son comparables» (glosario, criterio de la guía): es conducta de los modelos; se quitó de §4.1 y queda para §7.1 con respaldo.
- La cifra 1.3B frente a 175B de InstructGPT (N1b P1): se reemplazó por la cita literal del mismo REF-19, sin números.
- Cifras de ventanas largas (100K a 1M) en la línea de hitos de contexto: quitadas; sólo «las ventanas largas de 2023 y 2024» con sus REF.
- Fecha de ModelContextProtocol 1.0.0 (2026-02-25, de E2 de N1b): no entra; la tabla lleva la fecha del anuncio del SDK y las versiones remiten al Anexo F.
- Hito del modelo de chat del laboratorio (qwen3.5:4b): sin fuente primaria registrada; se nombra con etiqueta y digest, sin fila, como fija la ficha.
- Pregunta de N1b P1 (¿tamaño o herramientas?): se responde en la prosa de §4.2, no como pregunta guía, como fija la ficha.
- §4.1 «ventana»: el glosario canoniza «ventana declarada / efectiva / configurada»; §4.1 nombra las tres y remite a §6.5. Alias «ventana de contexto», «system prompt», «LLM», «anclaje» y «function calling» sólo entre paréntesis en su primera mención.
- Tiempos en ms de las pruebas de la demo: la salida de las pruebas va en prosa, sin copiar el log.
Fuentes dadas de alta: ninguna.
Desvíos de la ficha:
- La tabla de hitos tiene 12 filas «I» de N1b §3.2 (filas 2, 9, 10, 16, 17, 18, 19, 20, 21, 22, 24, 25); la columna «Peso» no pasa a la guía.
- §4.1 se arma como tabla (término, qué es, qué no es, fuente), con la «Definición.» en una línea antes: diez términos en ≤ 1.800 palabras de sección no entran como subsecciones.
- La línea de ubicación nombra OA-0.2 y OA-A5 (los OA cuya columna «§» incluye §4); las preguntas enlazan además OA-0.1 y OA-D2.
- La pregunta de N1 P9 dice «system prompt»; en la guía, «instrucciones» (alias sólo en §4.1, regla del glosario).
- Ejemplos: ninguno propio, como fija la ficha; el bloque remite a los snippets de la demo de §4.3 y §4.4 y lleva el «En la demo.» con el comando de pruebas sin servidor.
Procedencia de las salidas:
- No hay salidas de modelo en la sección. La conducta de las pruebas de arquitectura sale de Evidencia/Cierre-Construccion/demo-pruebas.cierre.log (líneas 28, 29, 75 y 76: Passed para las cuatro reglas; «Test Run Successful»). Rótulo: sin modelo, 2026-10-27.
- «Con un tope chico la respuesta puede llegar vacía» (fila modelo de razonamiento): remite a §5.7, que la rotula con el sondeo del entorno.
- «Las herramientas de lectura devuelven agregados, sin Nombre ni Edad»: README de la demo, fila PD-1.
- «ProvinciaValida se endureció; el caso base sólo exigía no vacío»: comentario de Demos/MovilidadUrbana.Asistente/src/MovilidadUrbana.Asistente/Domain/Rules/LocalidadRules.cs (línea del endurecimiento). La línea del comentario lleva IDs internos, por eso no se copió como snippet.
Snippets: rutas verificadas contra el árbol; líneas copiadas textuales (IExtractorDeLocalidad.cs l. 6–14; ExtractorDeLocalidad.cs l. 15–22 y 24–30, con dos «// …» (normalización y el record Cruda); AltaDesdeTextoService.cs l. 16–31, 39, 41–43; SesionDeChat.cs l. 133–135; ArquitecturaTests.cs l. 23–30). Las líneas 1 de cada archivo (comentario «Delta…» con remisiones al plan) se omitieron por ser comentario de cabecera fuera del bloque recortado. AltaDesdeTextoService tiene 24 líneas, dentro del tope.
Conteo de palabras de prosa (comando de la carta §16.3): 1.800 (tras la verificación adversarial; antes 1.798). Tope de la sección (carta §16.3): 1.800. La primera versión daba 2.668; se recortó en cuatro pasadas siguiendo el orden de §16.3 (repeticiones, filas de detalle con casa en otra sección, transiciones), sin tocar evidencia, definiciones ni preguntas. Cada respuesta de pregunta guía quedó entre 76 y 94 palabras. No toma palabras de §5.
Remisiones usadas: s2-1, s2-2, s3-1, s5-ejemplos, s5-3, s5-4, s5-5, s5-6, s5-7, s6-5, s7-1, s8-4, s10-2, s11-4, s12-1, s13-2, s13-12, s14-1, s14-2, anexo-a-4, anexo-c, anexo-f, oa-0-1, oa-0-2, oa-a5, oa-d2; internas: s4-3, s4-4, s4-5. Anclas propias: parte-ii, s4, s4-1 … s4-6, s4-practica, s4-escenarios, s4-ejemplos, s4-preguntas, s4-calidad.
Cifras citadas: ninguna de la tabla de cifras citables. Fechas de los hitos, de sus fuentes primarias (REF-23 a REF-43, REF-85). Los digests de los modelos son los del rótulo de la carta §9.3.
AC-7/AC-8 sin correr (las listas viven fuera del repositorio).
Verificación adversarial (2026-10-27): snippets cotejados línea por línea contra los cinco archivos; citas de REF-19, REF-117, REF-160, REF-182 y REF-183 confirmadas en N1/N1b; hitos cotejados con N1b §3.2; log de cableado confirmado (líneas 28, 29, 75, 76, 619). Cambios: §4.5 fila 1 nombra la excepción del chat (la página inyecta `SesionDeChat`, clase de Infrastructure, como declara el plan §A.4 punto 6), fila 5 «Endpoint» → «Dirección del servidor» (carta: *endpoint* sólo en código), «En el alta,» antes de «el adaptador es el único…» (SesionDeChat también conoce `IChatClient`), y se quitó la remisión a §0.4 del bloque Ejemplos para compensar (+5, +2, +3, −8).

## §5 (`secciones/05.md`)

Quitado por falta de respaldo citable:
- Que qwen3.5:4b sea híbrido: sólo lo respalda una inspección en una bitácora. §5.7 dice «no está medida» sin la causa.
- Cifras del sondeo del entorno (tiempos y presupuesto de tokens de la falla por razonamiento): no están en la tabla de cifras citables. La falla entra como conducta, con el rótulo del sondeo.
- Mínimos de caché de los servicios en la nube: fuera de la tabla de cifras citables; §5.6 remite a §6.4.
- Que .Result lanza una excepción ante texto no JSON: sin respaldo citable. El antipatrón queda como criterio de la guía.
- Que una ventana distinta recargue el modelo en el servidor compartido: lo afirman un comentario del código y el README de 01, no un REF ni un registro; queda marcado «no verificado en la construcción».
- «Qwen no está en el anuncio de herramientas»: inferencia débil sobre un anuncio de 2024; se reemplazó por el mecanismo del código (PredicadoDeSalto.cs).
- Que /v1 no admita num_ctx: no verificado; se escribe lo que hace el código (la capa no lo manda por /v1).
- Nombres y valores inventados por el modelo en 02: se describe la conducta sin ellos.
- Constantes de la guarda de truncado: se describe el mecanismo sin números.
- Fila «Credencial» de la tabla de §5.6: pasó a «Qué mirar» de 02 para ahorrar palabras.
Fuente nueva: REF-192, convalidada por la presidencia (01-Muestra-Decisiones.md).
Procedencia de las salidas:
- 01 modelo: Evidencia/R-LLM/01-Chat-Y-Streaming.modelo.jsonl, primera llamada. 01 --fake: Evidencia/Arnes/01-Chat-Y-Streaming.fake.log.
- 02 --fake: Evidencia/Cierre-Construccion/verificar-build.saneo.log, bloque de 02 (reverificacion.log lo abrevia con «...»). 02 modelo (prosa): Evidencia/R-LLM/02-Cambio-De-Adaptador.modelo.jsonl, a01, las dos llamadas.
- 03 modelo: Evidencia/R-LLM/03-Salida-Estructurada.jsonl. 03 --fake: Evidencia/03-Salida-Estructurada/fake-demostracion.log. Extensión: 03-Salida-Estructurada.modelo-ext.jsonl.
- 04 modelo: Evidencia/R-LLM/04-Normalizacion-Contra-Catalogo.modelo.jsonl, d02. Extensión: 04-…modelo-ext.jsonl. --fake: Evidencia/Arnes/04-Normalizacion-Contra-Catalogo.reverificacion.log.
- PD-3: Evidencia/R-LLM/Demo-MovilidadUrbana.Asistente.modelo.jsonl, pd3-01.
- Sondeo del entorno: Bitacoras/Sondeo-Entorno.md §2 (conducta, sin cifras).
Conteo de palabras de prosa (comando de la carta §16.3): 3.200 tras la verificación adversarial del 2026-10-27 (antes 3.191). Cambios del verificador: «consulta corta» de DEP-13 → «consulta» (el prompt lleva el padrón, clase M); fila «Forzar una herramienta» decía que en 02 «la piden las instrucciones», pero 02 no usa herramientas; remisión a §6.4 que esta nota daba por hecha y faltaba; apóstrofo literal de REF-24; rótulo completo (digest, versión, hardware) en 02 y 03, y 04 remite al de 03; procedencia de la salida --fake de 02; tres recortes para no pasar el tope. Tope de la sección (carta §16.3): 3.200.
Snippets por encima de 25 líneas, con motivo: 01 (26: el bucle de streaming y las dos líneas del historial son el tema de §5.2) y AltaDesdeTextoService (27: el camino SinPropuesta y la única escritura son el tema de §5.3).
Remisiones usadas: s0-4, s2-2, s4-4, s6-3, s6-4, s6-5, s7, s8-2, s10-2, s10-3, s10-4, s11-4, s11-6, s12-1, s12-5, s13-3, s13-9, s13-13, s14-1, s14-3, anexo-a-5, anexo-e, anexo-f, oa-d1, oa-d2, oa-o2; internas: s5-1, s5-2, s5-3, s5-5, s5-6, s5-7, s5-ejemplos.
Cifras citadas (todas en la tabla de cifras citables): 01 2 de 2; 03 extensión 8/8 IC95 [0,631; 1], JSON 8/8, 0/4 IC95 [0; 0,602]; 04 extensión 7/8 IC95 [0,473; 0,997]; sonda de num_ctx 5.714, 2.050 y 2,33; sonda de tiempos 91,7 s y 123,1 s. El 4.096 por defecto se cita de la fuente, separado de lo medido.

## §6 (`secciones/06.md`)

Quitado por falta de respaldo citable (AC-9 o sin REF):
- Cifras del dossier de CAG no re-ejecutadas en la construcción: 102,7 s → 1,1 s → 91,6 s (Ollama 0.32.0-rc0), 4.728 → 2.050 tokens, 250–265 tokens del corpus real, 9,4 tok/s y 474,7 s del servidor compartido, context_length 65.536 cargado. No entran; el recorte silencioso se remite a §5.7 (sonda de num_ctx, citable).
- Tamaño en tokens de los 12 requisitos: no medido en la construcción. §6.2, la pregunta de OA-A3 y la tabla de escenarios dicen «no medido» y «difícilmente llega al mínimo» como inferencia, sin cifra. Propuesta para la presidencia: medir prompt_eval_count de las instrucciones de 01 o contar bytes del texto renderizado, y entonces afirmar «por debajo de 1.024».
- prompt_eval_count de 05 (1.710–1.735) y el prefijo de 3.098 caracteres: no están en la fila 05 de la tabla de cifras; en prosa va sin número («casi no cambió»). El 3098 aparece sólo dentro de la salida textual de --fake.
- Razones con/sin de 0,017–0,024 del README de 05: derivadas, no listadas; no se citan.
- «El 7B en CPU pasa los 400 s por consulta»: cifra del dossier; se reemplazó por «un modelo mayor no entraba en el presupuesto de tiempo».
- Que qwen3.5:4b sea híbrido y pueda limitar la reutilización: sin REF; sólo «no está medido».
- Que con OLLAMA_NUM_PARALLEL=1 otro prefijo en el mismo slot borra la caché: lo contradice la corrida 4 de 05 (el con-prefijo sobrevivió a la sin-prefijo intercalada); y la configuración del Ollama propio no está en el registro. Se cuenta sólo la conducta observada.
- Que una recarga por otro cliente borre la caché en el servidor compartido: marcado «no verificado».
- Hardware del Ollama propio («sólo CPU» del README de 05): no se escribe (carta §9.3). Lo de «emuladores de otras sesiones» del README es R-PRIV y no entra.
- Título del artículo de CAG: sin título registrado en REF-67; no se nombra.
- Adaptador de Anthropic para M.E.AI y PromptCacheKey contra OpenAI: no verificados/no ejecutados; se dice.
Fuentes dadas de alta: ninguna.
Cifras de fuente primaria (no de laboratorio), con REF y fecha de consulta: tablas 2 y 3 de REF-67 (0,7535/0,7407; 2,2631/0,6667/92,0824 s); mínimos de caché de REF-70, REF-71, REF-72 (consultados 2026-10-26); 4.096 por defecto de REF-55; 32K/64K de REF-76 y REF-77; keep_alive 5 min de REF-55.
Desvíos de la ficha del plan:
- Título: el despacho decía «… (incluye CAG)»; se usó el del plan y el de la tabla de anclas, sin el paréntesis (rige el plan).
- El flowchart de decisión va en §6.1 (es la entrada de la sección); el diagrama de las dos escaleras no se repite (casa §3.2).
- Tabla de proveedores reducida a activación, mínimo y dónde se ve; vida y descuentos en una oración con REF.
- Línea de ubicación: «escalones 0 y 1 de conocimiento, anticipa el 2 y el 3» (la sección cubre dos escalones a fondo); capa Application porque el caso de uso decide el orden del prompt.
- Las preguntas del dossier P3, P4 y P7 se responden dentro de §6.3 (activación, por qué no CAG estricto) y §6.5 (más ventana).
Procedencia de las salidas:
- 05 modelo: Evidencia/R-LLM/05-Contexto-Completo-Con-Prefijo.modelo.corrida-4.jsonl, 13 llamadas (prompt_eval_duration_ms, load_duration_ms de p01 llamada 1) y 6 renglones de entrada (p01 falla, p02–p06 pasan).
- 05 --fake: Evidencia/Arnes/05-Contexto-Completo-Con-Prefijo.fake.log (igual en Cierre-Construccion/verificar-build.saneo.log, bloque 05), recortado con […].
- 08 (pregunta guía): Evidencia/R-LLM/08-Primera-Herramienta-Solo-Lectura.modelo-ext.jsonl, xl01–xl04 (contar_localidades en xl01, xl02, xl04; listar_localidades en xl03); cifra 4/4 IC95 [0,398; 1] de la tabla de cifras.
- 01 (truncado): Evidencia/R-LLM/01-Chat-Y-Streaming.modelo.jsonl, truncado_posible false en las dos llamadas.
Conteo de palabras de prosa (comando de la carta §16.3): 2.500 (tras la verificación adversarial). Tope de la sección: 2.500.
Snippets: todos por debajo de 25 líneas; comprobados línea por línea contra su archivo. Se saltearon con // … las líneas de comentario con IDs internos (CorridaDelPrefijo l. 34–35, OraculoDelPar l. 97, PrefijoEstable l. 8–11); la enseñanza del orden va en «Qué mirar».
Marcas «criterio de la guía»: 4.
Remisiones usadas: s0-4, s2-2, s3-0, s3-2, s5-4, s5-7, s7, s7-1, s7-6, s7-8, s8-2, s8-3, s8-7, s10-4, s11-4, s12-3, s13-5, s14-3, s14-6, anexo-a-6, anexo-e, anexo-f, oa-d3, oa-a3; internas: s6-1, s6-2, s6-3, s6-4, s6-5, s6-6, s6-ejemplos.
Cifras citadas de la tabla de cifras: 05 corrida 4 (duraciones de los 6 pares, vuelta a frío 17.881,0 ms, carga 3.096,3 ms, 5 de 6 descriptivo, con-prefijo 385–487 ms desde p02); 08 extensión 4/4 IC95 [0,398; 1].
Verificación adversarial (2026-10-27): «derivadas de las reglas» y «ningún requisito está escrito a mano» corregidos (cinco requisitos de las *Policy* son literales); «entran holgadas» pasó a «entraron en la ventana configurada» (no hay medida de tamaño); rótulo completo agregado a la conducta de 01 y rótulo corto en 08; `PromptCacheKey` ubicado en la Responses API con [REF-63]; recortes para volver al tope (árbol, antipatrón del conteo, calentamiento).
Compuertas corridas sobre la sección: remisiones al plan 0, familias de ID 0, rutas/IPs 0, voseo 0, alias 0. AC-7/AC-8 sin correr (las corre la integración).

## §7 (`secciones/07.md`)

Quitado por falta de respaldo citable:
- Las cifras de N3 E3 (8/8, MRR 1.000 y 0.917, «qwen3 unas 3 veces más lento»): otro corpus y sin re-ejecutar; no se citan (regla del plan).
- La convivencia de SqliteVec con EF Core SQLite en el mismo archivo (N3 E4) y el conflicto de SQLitePCLRaw: sólo los respalda la evidencia del dossier, no re-ejecutada ni en Evidencia/; §7.3 dice sólo «preview» y «pre-v1». La consecuencia «InMemory se pierde al reiniciar» de la pregunta 1 queda como lectura del código de 07 y de la demo (reconstruyen al arrancar).
- Qué conectores implementan IKeywordHybridSearchable (Qdrant, PgVector, SqlServer, AzureAISearch sí; InMemory no): reflexión del dossier, sin registro en Evidencia/. Se dejó la regla general [REF-92] y el «No» de SQLite [REF-97].
- Sentido del Score con CosineDistance frente a CosineSimilarity: lo mostró la sonda del dossier, sin REF; queda «más alto es más parecido» con CosineSimilarity como lectura del atributo y la marca «criterio de la guía» para el umbral.
- Timeout de 100 s del HttpClient por defecto de OllamaApiClient: reflexión del dossier, sin registro; no entra.
- recall@k: la fuente académica no respondió en el dossier; hit rate@k va como «criterio de la guía», como en el glosario.
- Cifras de puntajes coseno (mejor no respondible, peor top-1) y de las comparaciones pareadas con la léxica (b, c, p): no están en la tabla de cifras citables; se omiten en los bloques con «[…]» y en la prosa se dice sólo que no se afirma diferencia.
- recall@3 de la pregunta del nombre (1,00): no está en la tabla; se nombra la métrica sin cifra.
- «Que un modelo de chat dé embeddings útiles»: marcado «no verificado».
- Nombres de los planes de embeddings (la variable EMB_PLAN y sus valores): sus valores caen en la compuerta de familias de ID; no se nombran. El modo sin modelo se explica por --fake.
- El origen del caso guionado «e5» (una corrida del dossier con otro modelo): se describe el guion sin su origen.
Fuentes dadas de alta: ninguna.
Verificación adversarial (2026-10-27): snippets cotejados línea por línea (coinciden); cifras contra 06-Construccion §8 (permitidas); corregidos: la regla pareada de §7.5 (decía «todas a favor», y la ventaja sobre el azar en hit@1 es b = 10, c = 1), el alcance del oráculo en §7.4 (no ve la contradicción en los 5 literales sin valor), la atribución a [REF-163] en la pregunta 3 (el top-k es criterio de la guía) y la comprobación de dimensión de 06 (por fragmento, no al arrancar).
Alias: «vector» es alias de embedding en el glosario; en la prosa queda sólo como «almacén vectorial», «propiedad vectorial» y «vectores» como tipo de columna de una base (SQL Server, EF Core), que es otro sentido. Lo decide la relectura integral.
Desvíos de la ficha:
- §7.4 nombra filtros, pero ni 07 ni la demo filtran (corpus público); el filtro se explica con [REF-92] y en §7.6, sin snippet propio.
- La pregunta guía de N3 P5 se reescribió «antes de culpar al modelo» (el alias «LLM» no va en prosa).
- Hallazgo para el repositorio, no para esta sección: la demo llama plantilla.v1 a un texto distinto del de 06 («{tema}, {campo}: {requisito}» en CorpusDeAyuda.cs frente a «{entidad} · {propiedad en palabras}: {literal}» en CorpusDePolicies.cs). §7 no afirma que la demo use el texto de 06.
Procedencia de las salidas:
- 501 de embeddings: Bitacoras/Sondeo-Entorno.md §5 (conducta, sin cifras).
- 06 modelo: Evidencia/Arnes/06-Embeddings-Y-Busqueda-Semantica.modelo.log, bloque «Métricas…» (registro: Evidencia/R-LLM/06-Embeddings-Y-Busqueda-Semantica.modelo.jsonl); p = 0,012 y 0,004, mismo log, comparaciones contra el azar. 06 --fake: Evidencia/Arnes/06-Embeddings-Y-Busqueda-Semantica.fake.log, líneas 1–2.
- 07 modelo: Evidencia/R-LLM/07-RAG-Con-Citas.modelo.jsonl, entrada_id r03 (salida aceptada) y n04 (RechazadaCitaNoRecuperada); r07 contado en prosa sin citar su texto; tasas e IC95 del README de 07, que coinciden con la tabla de cifras citables. 07 --fake: Evidencia/Cierre-Construccion/verificar-build.cierre.log, líneas 431 y 433–435 (la 432, de recuperados con puntajes del guion, recortada con «[…]»).
- PD-2: Evidencia/R-LLM/Demo-MovilidadUrbana.Asistente.modelo.jsonl, entrada_id pd2-01 (llamada y entrada, oráculo demo-pd2-cita: pasa).
Conteo de palabras de prosa (comando de la carta §16.3): 2.994. Recortes para no pasar el tope: viñeta «nada que no sea público…» de §7.6 (lo cubre §7.7), SQL Server en §7.3 (queda en la pregunta guía), una frase de §7.5 y dos de Ejemplos. Tope de la sección (carta §16.3): 3.000.
Snippets por encima de 25 líneas, con motivo: CorpusDePolicies (21 + recorte) y IndiceDeAyuda (26: el atributo con generador automático y la verificación de dimensión son el tema de §7.3).
Remisiones usadas: s0-4, s2-2, s5-4, s6-1, s6-2, s6-6, s6-preguntas, s8-5, s10-4, s10-5, s10-6, s10-7, s11, s11-2, s11-4, s12-9, s13-5, s13-6, s14-3, anexo-a-7, anexo-e, anexo-f, oa-a3, oa-d4, oa-s3; internas: s7-1, s7-2, s7-3, s7-4, s7-5, s7-ejemplos.
Cifras citadas (todas en la tabla de cifras citables): 06 hit@1 10/12, hit@3 12/12, MRR 0,889; léxica 7/12, 8/12, 0,679; azar 1/12, 3/12, 0,259; p = 0,012 y 0,004. 07 7/7 IC95 [0,590; 1], 5/5 IC95 [0,478; 1], 0/4 IC95 [0; 0,602], 1/12 IC95 [0,002; 0,385]. De fuente, no medidas: 512 tokens y 25 % [REF-109]; 1024 dimensiones [REF-106]. Conducta: 501 del sondeo; PD-2 humo.

## §8 (`secciones/08.md`)

Quitado o no usado por falta de respaldo citable:
- Especificación MCP 2025-06-18 (MUST validar Origin; lo que anuncia un servidor es no confiable): sin número REF (carta §15.5). §8.9 describe lo que hace el código de 13 y remite a §11.5; no se copiaron las líneas de comentario de 13 que la citan.
- «Not all models support function calling» de REF-118: según N6 F11 está sólo en la pestaña Python. No se usa; la tabla de escenarios se apoya en REF-35.
- Motivo «FunctionInvokingChatClient ejecuta la llamada que trae la respuesta»: sólo lo dice un comentario de código. §8.5 dice lo que hace el código (la respuesta se arma sobre el pedido guardado) sin dar ese motivo.
- «more costs and compounding errors» (plan §B.3) como cita literal: no consta verificada como literal. Se parafrasea con lo que N4 P2 atribuye a REF-115 (latencia y costo por desempeño) y lo de §2.15 (condiciones de corte).
- Mapeo de los patrones de Anthropic a MAF (chaining, routing, orchestrator-workers…): criterio propio del dossier N4; no entra por espacio. Queda para §9 si su redactor lo toma.
- Cifras fuera de la tabla citable: tokens de 12 contra el modelo (575 y 48), estimaciones del guion de 12 (808, 802), prompt_eval_count de 09, 11 y 13, supersteps de 10 en prosa. No se citan; los supersteps aparecen sólo dentro de la salida rotulada «sin modelo».
- Tiempos de la sonda de aprobación (25,1 s y 29,6 s): citables, omitidos porque no cambian ninguna decisión de §8.
- Estado de SK y AutoGen, y LangGraph en detalle: casa en §9 y Anexo F; acá sólo remisión.
Fuentes dadas de alta: ninguna. REF-162 se re-verificó con curl el 2026-10-27 para la definición textual de LLM06 («Excessive Agency is the vulnerability that enables damaging actions to be performed in response to unexpected, ambiguous or manipulated outputs from an LLM»); la entrada no cambia.
Aviso a la presidencia (contradicción carta / código):
- La carta §2.1 dice que «PD-6 y el ejemplo 11 usan un agente de MAF». El código de la demo no referencia Microsoft.Agents (grep sobre *.cs y *.csproj de Demos/: sólo aparece el nombre en VersionesTests.cs); PD-6 usa UseFunctionInvocation y el historial de SesionDeChat (scoped por circuito). La sección sigue el código y el plan §B.3 («PD-6 … con estado: el historial del circuito»). Conviene corregir la carta.
- Los README de 08 y 09 todavía dicen que la extensión de 08 y la sonda de aprobación no se corrieron; las cifras salen de la carta §10 y de los registros (carta §15.7).
Desvíos de la ficha:
- Línea de ubicación con rango («escalones 1 a 3 de agencia»): la forma canónica de §16.2 prevé un escalón o «anticipa el …»; §8 enseña tres. Se pide confirmar la forma.
- Un diagrama más que los que lista la ficha: la aprobación en dos peticiones (§8.5), porque el orden de las peticiones es lo que enseña la subsección.
- El título del despacho agrega «incluye LangGraph y su equivalente en .NET, anotaciones». Por la regla de casa única (plan §C), el cuadro de formas de construir y anotaciones vive en §9.3 y LangGraph en §9.4: §8.1 remite a §9.3; §8.2 enseña [Description] donde la usa; §8.6 dice en una oración, como criterio de la guía, que los workflows de MAF son el equivalente funcional, y remite a §9.4.
- 10 lleva una sola línea de comando (no tiene modelo, su README no trae --con-modelo).
- OA-D8 no tiene pregunta guía propia (la ficha no la prevé); queda cubierto por el ejemplo 13 antes de §15.
- Los cierres «¿esto se resolvía con una función?», «¿quién arma el texto que aprueba la persona?» y «¿qué perderías con UseFunctionInvocation…?» van como párrafos en negrita al final de §8.2, §8.5 y §8.7, no como preguntas guía.
Procedencia de las salidas:
- 08 modelo: Evidencia/R-LLM/08-Primera-Herramienta-Solo-Lectura.modelo.jsonl, l01 llamada 2 (salida) y n01 (conducta en prosa). Extensión: 08-…modelo-ext.jsonl (cifras de la carta §10). --fake: Evidencia/08-Primera-Herramienta-Solo-Lectura/correr-fake-reanudacion.log (bloque n01 y línea del corte), igual a Cierre-Construccion/verificar-build.saneo.log l. 449–455.
- 09 modelo: Evidencia/Arnes/09-Caso-De-Uso-Como-Herramienta.modelo.log, bloque e01; la línea «asistente (modelo)» coincide con el campo salida de R-LLM/09-…modelo.jsonl, e01 llamada 2.
- Sonda de aprobación en dos peticiones (prosa): Evidencia/Sondas/DEP-09-Sonda-Aprobacion.jsonl y Sondas/dep09.log.
- 10 sin modelo: Evidencia/10-Workflow-Y-Contraejemplo/correr.redespacho.log, bloque e02 (recorte «[…]» de los cuatro renglones «workflow:» y los tres primeros «antes de la pausa:»). CS0534 y CS0411: variantes-rotas.redespacho.log.
- 11 modelo: Evidencia/11-Agente-Con-Aprobacion/corrida-lan-turno1.log, bloque e01; coincide con R-LLM/11-Agente-Con-Aprobacion.modelo.jsonl. Marca del pedido con --fake: README de 11 y R-LLM/11-…fake.jsonl.
- 12 --fake: Evidencia/Arnes/12-Uno-O-Varios-Agentes.fake.log, bloques e01.un-agente y e01.dos-agentes. 12 modelo: R-LLM/12-Uno-O-Varios-Agentes.modelo.jsonl, e01.un-agente (la salida de e01.dos-agentes es idéntica).
- 13 modelo: Evidencia/13-Servidor-Y-Cliente-MCP/corrida-lan-turno2.log; «[…]» quita la línea de num_ctx y las dos líneas de arranque (la del servidor trae el puerto efímero de loopback) y lo que sigue a la línea de Host/Origin.
- Demo PD-6 (prosa): Evidencia/R-LLM/Demo-MovilidadUrbana.Asistente.modelo.jsonl, pd6-01; Evidencia/Demo-MovilidadUrbana.Asistente/humo-corrida-3-pd6.txt.
Conteo de palabras de prosa (comando de la carta §16.3): 4.698 tras la verificación adversarial. Tope de la sección (carta §16.3): 4.700. Apertura 81; definiciones 58–117; respuestas de preguntas guía 107–125. «Criterio de la guía»: 9 marcas en prosa, contadas con grep fuera de bloques de código y comentarios (la verificación sumó las de §8.7 y §8.8).
Verificación adversarial (2026-10-27): REF-129 (página «Workflow capabilities», releída) sólo enumera «sequential, concurrent, handoff, group-chat, and Magentic patterns for coordinating agents»; no dice que en handoff y Magentic un modelo elija al siguiente agente. §8.7 y §8.8 pasan esa atribución a «criterio de la guía». En la pregunta «¿Agente o workflow?», «varias piezas que coordinar» se apoya en REF-117 («Multiple agents or functions must coordinate», releída) y «pasos en paralelo» en REF-125 (supersteps), no en REF-127/128.
Snippets por encima de 25 líneas: ninguno (el más largo, ClienteMcp.Montar, 22). Diez bloques comprobados línea por línea contra su archivo: 0 diferencias. Ocho salidas comprobadas contra sus registros y logs: 0 diferencias.
Compuertas corridas sobre la sección sin este comentario: remisiones al plan 0; familias de ID 0; IPs, rutas y puertos 0; voseo 0; alias en títulos 0 (en prosa sólo «tool calling» y «Model Context Protocol», en su primera mención entre paréntesis). AC-7 y AC-8 sin correr (listas fuera del repositorio; las corre la integración). Mermaid: cinco diagramas revisados a mano (etiquetas entre comillas, sin paréntesis ni comillas internas, saltos con <br/>, aristas con |"…"|); no se renderizaron.
Remisiones usadas: s0-4, s2-2, s3-2, s5-4, s6-1, s9-3, s9-4, s10-4, s11-2, s11-3, s11-4, s11-5, s12-1, s13-7, s13-8, s13-13, s14-1, s14-2, s14-3, anexo-a-8, anexo-b-herramientas, anexo-e, anexo-f, oa-d5, oa-d6, oa-d7, oa-d8, oa-s2, oa-s4; internas: s8-2 … s8-9, s8-ejemplos.
REF citados: REF-21, REF-23, REF-35, REF-37, REF-45, REF-51, REF-115, REF-117, REF-119, REF-121, REF-122, REF-124, REF-125, REF-126, REF-127, REF-128, REF-129, REF-130, REF-132, REF-133, REF-142, REF-143, REF-162, REF-186.
Cifras citadas (todas en la tabla de cifras citables, carta §10): 08 base 2 de 2; extensión 4/4 legítimas con argumentos válidos, IC95 [0,398; 1]; oráculo no-inventa 6/8, IC95 [0,349; 0,968], con la lectura de sus dos fallas; corte del bucle en 3 (garantía de código). 09 2 de 2. 10 «workflow = función» en las 4 entradas congeladas, sin modelo. 11 1 de 1, la baja ejecutada es la mostrada. 12 4 de 4, 0 vueltas, corrector no llamado contra el modelo. 13 1 de 1. Demo PD-6: conducta del humo y 0 bajas sin aprobación en las 70 pruebas. Los 3 y 2 de 08 y el tope 3 de 11 son constantes del código.

## §9 (`secciones/09.md`)

Quitado por falta de respaldo citable:
- Cantidad de paquetes que devuelve la búsqueda «langgraph» en NuGet, sus nombres y autores: no es cifra de la tabla de cifras citables; la prosa dice «sólo paquetes de terceros» con REF-189. Los autores son personas físicas: no van.
- Repositorios de la organización langchain-ai en GitHub (cantidad y el acelerador archivado en C#): lo respalda la API de organizaciones de GitHub, que no tiene REF (REF-191 es la de repositorios). Quitado; queda el argumento por NuGet y PyPI/npm.
- «SharpGraph» y otros repos «LangGraph for .NET» de GitHub: sin REF. Quitado.
- Fecha estimada de fin de soporte de SK (abril de 2027): es inferencia; la prosa dice «no hay fecha oficial» y da la regla de REF-137 con la fecha de GA de REF-43.
- «No existe un atributo [Agent]»: no hay fuente que lo afirme; se reemplazó por lo verificable («las fuentes citadas crean el agente por código o en YAML»).
- Configuración de MCP/A2A en el Agent Server, licencia de LangSmith para autohospedar y el campo thread_id contra la doc REST: no verificados; marcados así en §9.4.
- El puerto por defecto de `langgraph dev` como afirmación en prosa: queda sólo dentro del snippet adaptado, sin afirmarlo.
- Mapeo de los patrones de Anthropic a MAF (BuildSequential, Magentic…): es casa de §8.1/§8.8; no se repite.
- Que `--prerelease` siga en la doc de SK Agents.Core aunque sea GA: respaldo débil (REF-139 sin fecha); no entró en §9.8.
Fuentes dadas de alta: ninguna. Se volvieron a leer con curl (2026-10-27) las citas literales de REF-115, REF-117, REF-136, REF-137, REF-140, REF-141, REF-142, REF-124 y REF-48: coinciden.
Desvíos de la ficha:
- Línea de ubicación «transversal»: §9 no es de una escalera y la carta reserva «transversal» para §4, §10, §11, §12; la presidencia confirma.
- Anclas nuevas, por analogía con las de la plantilla (la carta no las nombra para §9): s9-criterio, s9-preguntas.
- §9 no lleva «Qué decisión toca»; el criterio de elección cierra con una oración que remite a ADR-02 y ADR-07. Que no haya ADR del marco es lectura del plan v3 §C (lista de ADR); confirmar.
- La etiqueta del nodo MCP dice «SDK oficial para .NET» y no «de C#», para no meter # en una etiqueta mermaid.
- El diagrama de ecosistemas no lleva versiones (regla: versiones sólo por el Anexo F); se quitaron los paréntesis de las etiquetas y la flecha bidireccional del plan (se usa «expone o consume»). MEAI → MAF del plan se invirtió a «MAF construido sobre MEAI», que es lo que dicen los .nuspec.
- El cuadro de §9.3 no lleva la columna «Estado»: pasa al Anexo F. Lleva «En la guía» con el número de ejemplo.
- Snippet de LangGraph: el plan lo prevé como adaptación no ejecutada; se copió textual del dossier de agentes (§4.8), incluido el «Hola» del mensaje, que no es de otro dominio.
- N2 P8 (¿migro de SK?) va como prosa de §9.7, no como pregunta guía; N4 P6, N2 P7 e I-05 A-6 se responden en el cuadro de §9.1; AutoGen, una línea con remisión al Anexo F.
Procedencia de las salidas:
- 14 sin modelo: Evidencia/14-Anotaciones-SK-vs-MEAI/correr-fake-verificar.log (primeras dos líneas, e01 y e04; e02 y e03 recortadas con […]). Registro: Evidencia/R-LLM/14-Anotaciones-SK-vs-MEAI.jsonl (4 renglones, recalculado 4 de 4 en recalculo-oraculos.cierre.log).
- CS0104: Evidencia/14-Anotaciones-SK-vs-MEAI/pruebas-y-variante.log (tres errores CS0104 en Comparador.cs); 13 de 13 pruebas pasan (mismo log). La cifra 13 no se cita en la prosa.
- CS0534 y CS0411 de 10: Evidencia/10-Workflow-Y-Contraejemplo/variantes-rotas.log; en la prosa se cita el README de 10, que es archivo del repositorio.
Verificación adversarial (2026-10-27): §9.8 ya no cita «MAF 1.26.0» en prosa (regla: versiones sólo por el Anexo F); el ítem 2 del criterio marca 10 como contraejemplo (carta: la encuesta de 10 es escalón −1); «paquetes de terceros que usan el nombre» pasó a «el nombre o la idea» y el nodo TER del diagrama a «que aparecen al buscar langgraph» (N4 §6: SemanticKernel.Graph, Nexttag.Ai.Graph y Flowgine no llevan langgraph en el nombre).
Conteo y tope: 2.799 palabras de prosa (comando de la carta §16.3, tablas incluidas). Tope de §9: 2.800.
Snippets por encima de 25 líneas: ninguno (LangGraph 17, PluginSk 14, HerramientaMeai 13). La salida de 14 tiene 18 líneas.
Remisiones usadas: s0-4, s2-2, s3-2, s5, s5-6, s8, s8-2, s8-5, s8-6, s8-7, s8-9, s11-3, s13-3, s13-8, anexo-f, oa-a4, oa-sk1; internas: s9-4, s9-5, s9-6, s9-7, s9-8, s9-3.
Cifras citadas: ninguna medida. 14: equivalencia de las anotaciones sin modelo (tabla de cifras, fila 14), sin número. Fechas citadas de fuentes: GA de MAF en abril de 2026 (REF-43), retiro de Azure.AI.Inference 2026-08-26 (REF-57), renombre a LangSmith Deployment en octubre de 2025 (REF-144), cadencia semanal de MAF en septiembre y octubre de 2026 (REF-188).
AC-7/AC-8 sin correr (las corre la integración).

## §10 (`secciones/10.md`)

Quitado por falta de respaldo citable:
- «Temperatura 0 no garantiza determinismo»: sin fuente primaria (el dossier lo marca no verificado); queda como «criterio de la guía, no verificado con una fuente».
- Las tres repeticiones de estabilidad de 07: se quitaron (la carta no deja citarlas como tasa y, como conducta, no aportaban a la sección).
- Acuerdo juez-oráculo 0/16 de la corrida con modelo, los 534 s de turno y el «48 de 52 con un número después de Score» del README de 15: fuera de la tabla de cifras citables. Por eso no se muestra el bloque final del log con modelo, que trae el 0/16.
- «Ollama propio, sólo CPU» del README de 15: la carta prohíbe hardware para el Ollama propio; el rótulo va sin hardware.
- Que los evaluadores agénticos lleven AIEVAL001 en 10.11.0: lo respalda una verificación de dossier, no un REF; se omite (15 no usa ninguno, y el README lo dice).
- Cifras y snippets de la sonda N5 (E2–E5, otro dominio): no se citan.
- Cantidad de pruebas de la demo (70): se omite; la demo se describe por suites.
- «Misma familia reduce el autofavorecimiento sin eliminarlo»: inferencia sobre REF-158, marcada criterio de la guía.
- «Limited reasoning ability» de REF-158 y la caché de 14 días de REF-152: se recortaron por presupuesto.
Fuentes dadas de alta: ninguna.
Desvíos de la ficha:
- §10.3 «esquema enviado»: se muestra la prueba de 03 que comprueba ResponseFormat con esquema no nulo, no el texto del esquema.
- §10.7 «revisión humana registrada»: el conjunto de la guía no la tiene; se dice así, con el respaldo del propio archivo (rótulo «escrito para el ejemplo» y nota «Estímulo del mismo autor»).
- El IC95 de 8/10 [0,444; 0,975] es un cálculo de la regla (tools/verificar.sh tasa 8 10, sin modelo), no una medición; el plan lo redondea a [0,44; 0,97]. 2 · 0,5⁶ = 0,031 es aritmética de la regla, tomada del plan.
- «R-LLM» no se escribe en la sección: con el locale es_AR.UTF-8 la compuerta de familias de ID lo marca (el rango [0-9A-C] incluye «L» por colación); con LC_ALL=C no. Se usa «registro de la corrida». Sugerencia para la integración: correr la compuerta con LC_ALL=C, porque OA-D9 trae «R-LLM» en §0.1.
- La pregunta del plan «¿Puedo usar un LLM para evaluar a otro?» pasó a «¿… un modelo …?» para no usar el alias «LLM» aislado.
- Pregunta de estado N5 P6 (Safety con modelo local): va al Anexo F; §10.5 y la segunda pregunta remiten implícitamente vía REF-154 y el Anexo F.
Procedencia de las salidas:
- c06 (Groundedness): Evidencia/R-LLM/15-Pruebas-Y-Evaluacion.modelo.jsonl, entrada_id c06, llamada_n 2; recorte textual con […].
- 15 --fake: Evidencia/15-Pruebas-Y-Evaluacion/correr-fake-verificar.log, líneas finales (se saltea «registro: 78 renglones…»).
- 0/52 y 0/10: Evidencia/15-Pruebas-Y-Evaluacion/corrida-propio-fase3b.log y R-LLM/15-Pruebas-Y-Evaluacion.modelo.jsonl.
- 06 p = 0,012: R-LLM/06-Embeddings-Y-Busqueda-Semantica.modelo.jsonl (fila 06 de la tabla de cifras de la carta §10).
Conteo de prosa (comando de la carta §16.3): 2.200. Tope de la sección: 2.200. Recortes para llegar: rótulos repetidos a la forma corta, «limited reasoning ability», caché de 14 días, confianza de ADR-10 (queda en §13.11), estabilidad de 07.
Snippets por encima de 25 líneas: ninguno.
Remisiones usadas: s0-4, s2-2, s5-3, s5-4, s6-1, s7-5, s8-5, s13-11, s14-5, anexo-a-10, anexo-e, anexo-f, oa-d2, oa-d4, oa-d9, oa-o3; internas: s10-6, s10-7, s10-ejemplos.
Cifras citadas (todas en la tabla de cifras de la carta §10): 15: 0/52 interpretables; 0/10, IC95 [0; 0,308]; anotador = agente. 06: ventaja sobre el azar en hit@1, p = 0,012, sin ventaja afirmada sobre la léxica. «Más del 80 %»: cita de REF-158, no medición. Salidas --fake de 15 como cableado.

## §11 (`secciones/11.md`)

Quitado por falta de respaldo citable:
- Contenido de ASI02, ASI03 y ASI09 más allá de su nombre: el dossier sólo verificó los nombres contra el PDF (REF-164). La tabla de §11.1 da el nombre y un control; la asignación se declara criterio de la guía.
- Valores por defecto de MaximumIterationsPerRequest (40) y MaximumConsecutiveErrorsPerRequest (3): sólo los respalda una inspección del ensamblado en el dossier N5, sin REF. §11.3 remite a §8.2 sin cifras.
- «Lo que manda un servidor MCP ajeno (herramientas, descripciones, anotaciones y resultados) es no confiable (MCP 2025-06-18, Tools: MUST)», como lo escriben el plan y el README de 13: la página verificada dice MUST sólo para las anotaciones («untrusted unless they come from trusted servers») y SHOULD para validar resultados. §11.5 escribe lo que dice la fuente (REF-198). Avisar a quien mantiene el README y los comentarios de 13 (ClienteMcp.cs).
- El largo exacto del nombre del ataque: el plan dice 47 caracteres y el README de 16 dice 48 contados en el archivo congelado. La sección dice sólo que LocalidadRules lo acepta.
- «12 conversaciones», «24 llamadas», «6/6 de precondición» y el «hasta el 46 %» del README de 16: no están en la tabla de cifras citables; queda 0/6, IC95 [0; 0,459] y b = c = 0.
- Comentario «(H-005)» del snippet de ResultadosDeEncuesta: línea salteada con «// …» (lleva un ID interno); la enseñanza («invariante del tipo») va en la prosa.
- Cómo implementar la autorización MCP: la especificación (REF-199) se leyó, pero la guía no la implementa ni la enseña; §11.5 nombra sólo que es opcional y se basa en OAuth 2.1 sobre HTTP.
Fuentes dadas de alta (al final de 00-Referencias.md, con fila de correspondencia «ninguno: verificada por la redacción de §11 (2026-10-27)»; pendientes de convalidación): REF-196 MCP 2025-06-18 Transports (MUST validar Origin; SHOULD localhost; SHOULD autenticación) · REF-197 MCP 2026-07-28 Streamable HTTP (mantiene el MUST y agrega 403 con Origin inválido; en esa revisión basic/transports sirve «Overview») · REF-198 MCP 2025-06-18 Tools (anotaciones no confiables MUST; humano en el circuito SHOULD; validar resultados SHOULD; frases de anotaciones y humano iguales en 2026-07-28) · REF-199 MCP 2025-06-18 Authorization (OPTIONAL; HTTP SHOULD conformar; OAuth 2.1). Verificadas con curl y extracción de texto el 2026-10-27. Se pidieron 193–196, pero otra redacción (§12) tomó 193–195 en paralelo: no se renumeró nada. La fila de «Pendientes» del registro sobre la especificación MCP y su autorización puede cerrarse con estas cuatro (decisión de la presidencia).
Desvíos de la ficha:
- Línea de ubicación: «transversal · capa Infrastructure/AI» (la política de origen de 16 vive en Application, y se nombra en la prosa). OA-S4 y OA-O1 entran por §11.3 y por la pregunta de EnableSensitiveData.
- La pregunta «Indexo texto que no escribí yo…» se reescribió sobre nombres de localidad cargados por personas (RespuestaDeEncuesta no tiene un campo de texto libre).
- §11.5 nombra OAuth 2.1 sólo como base de la autorización de la especificación, ahora con fuente primaria (la ficha prohibía nombrar un mecanismo sin leerla).
- Los snippets de 16 y 13 van en Ejemplos (carta §16.5); la subsección §11.4 lleva el de la demo.
Procedencia de las salidas:
- 16 modelo: Evidencia/R-LLM/16-Inyeccion-Indirecta.modelo.jsonl, entrada e03-aprobacion, llamada 2. Cifras: líneas tipo «entrada» del mismo registro y README de 16 (recalculo 12 de 12).
- 16 --fake: Evidencia/Cierre-Construccion/verificar-build.saneo.log, l. 657–663 y la línea «origen (regla 1)…» del mismo bloque; «[…]» saltea el resto de las entradas y el resumen con las cifras del guion.
- 13 --fake: Evidencia/13-Servidor-Y-Cliente-MCP/build-y-fake.log, l. 17 (igual en verificar-build.saneo.log l. 584).
- PD-6: Evidencia/Demo-MovilidadUrbana.Asistente/humo-corrida-3-pd6.txt (línea pd6-01) y Evidencia/R-LLM/Demo-MovilidadUrbana.Asistente.modelo.jsonl, pd6-01.
Conteo de palabras de prosa (comando de la carta §16.3): 2.375 tras la verificación adversarial (antes 2.318). Tope de la sección: 2.100. Pasa en 275 (13,1 %), por debajo del disparador del 15 %; no se tomaron palabras de §10 ni de §12. Recortes ya hechos: dos pasadas (de 2.842 a 2.318). Lo que más pesa: la tabla de §11.1 (nueve riesgos que fija la ficha) y las cinco preguntas guía (entre 79 y 97 palabras cada una). Si la relectura recorta, el orden sugerido es: frase de 13 en Ejemplos, celdas de la tabla de escenarios, segundo párrafo de §11.6.
Verificación adversarial (2026-10-27): §11.5 lado cliente corregido. Atribuía a la especificación los nombres del SDK de C# (`ReadOnly`, `Destructive`) y usaba «pide» para dos SHOULD; ahora separa el MUST de las anotaciones de los dos SHOULD y ubica `ReadOnly`/`Destructive` en `[McpServerTool]` (LecturasMcp.cs, servidor guionado `borrar_todo`). «Sus resultados entran por la política de origen» se quitó: 13 no implementa la política de origen (no tiene escrituras montadas); se reemplazó por lo que hace ClienteMcp.cs (lista permitida, descripción del cliente, escritura permitida iría aprobable, McpTests.Montaje_UsaLaDescripcionDelCliente_YUnaEscrituraPermitidaVaConAprobacion).
Snippets por encima de 25 líneas: ninguno (el más largo, HerramientasDeLaInyeccion.cs, 20). Cuatro bloques comprobados línea por línea contra su archivo: 0 diferencias. Cuatro salidas comprobadas contra sus registros y logs: 0 diferencias.
Compuertas corridas sobre la sección (sin este comentario): remisiones al plan 0; familias de ID 0; voseo 0 (el «Tienes» es salida textual del modelo); rutas privadas e IPs 0; dominios ajenos 0. AC-7/AC-8 sin correr (las corre la integración). Marcas «criterio de la guía»: 6.
Remisiones usadas: s0-4, s1, s2-2, s3-1, s5-3, s5-5, s5-6, s7-6, s8-2, s8-3, s8-4, s8-5, s8-9, s8-ejemplos, s10-4, s12-2, s13-7, s14-3, s14-6, anexo-a-11, anexo-b-herramientas, anexo-e, oa-s1, oa-s2, oa-s4, oa-d8, oa-o1, oa-o2; internas: s11-2, s11-3, s11-4, s11-5, s11-7, s11-ejemplos, s11-preguntas.
Cifras citadas (todas en la tabla de cifras citables): 16, 0/6 pedidos de baja inducidos por variante, IC95 [0; 0,459], b = c = 0, «sobre un solo texto de ataque, del mismo autor»; demo, 0 bajas sin aprobación en las 70 pruebas. 403 y 400 son códigos HTTP, no mediciones.

## §12 (`secciones/12.md`)

Quitado por falta de respaldo citable:
- Cifras de la advertencia de Aspire que trae la ficha (11 a 24 s con razonamiento apagado, 474,7 s con un prefijo de 4.441 tokens, más de 600 s bajo carga): no están en la tabla de cifras citables (carta §10). Se reemplazaron por la sonda de tiempos (91,7 s y 123,1 s), que sí está.
- Snippet de Aspire (AppHost con AddOllama/AddModel/WithReference y AddOllamaApiClient): no sale de un archivo de Examples/ ni de Demos/ y no se compiló; la carta deja a LangGraph como única pieza no ejecutada. §12.7 nombra las API en prosa con [REF-175], [REF-176] y dice «no hay snippet». Desvío de la ficha.
- Valores por defecto de TotalRequestTimeout y del número de reintentos del manejador estándar: no verificados (heredan de Polly); sólo se cita el AttemptTimeout de 10 s y que el reintento atiende TimeoutRejectedException.
- num_ctx 65.536 del registro de 17, tokens de los tramos (113/39, 94/25) y duraciones de 17: fuera de la tabla de cifras; las líneas de tramo se recortaron con «[…]» en la salida con modelo.
- Puertos y variables del panel de Aspire independiente y su acceso anónimo «sólo para desarrollo»: la fuente del dossier mezcla dos URL (REF-172 y REF-177) y no queda claro cuál lo respalda.
- Que el SetEnvironmentVariable con el proceso andando no cambie EnableSensitiveData: sólo lo respalda una sonda de dossier sin REF.
- ONNX Runtime GenAI como tercera opción local: se omitió por presupuesto (REF-180 disponible si la relectura lo quiere).
- Que otra ventana recargue el modelo en el servidor compartido: marcado «no verificado» (carta §16.13).
- Valores de EMB_PLAN: no se escriben porque marcan la compuerta de familias de ID; se remite a §7.
Fuentes dadas de alta (pendientes de convalidación, carta §16.10), verificadas con curl el 2026-10-27 sobre los archivos crudos:
- REF-193: microsoft/aspire, plantilla aspire-servicedefaults/Extensions.cs en v13.6.4 (commit c8935270), líneas 29-36: «// Turn on resilience by default» y http.AddStandardResilienceHandler().
- REF-194: dotnet/extensions v10.11.0 (commit 25f07afa), HttpStandardResilienceOptions.cs, líneas 85-95: AttemptTimeout «using custom Timeout of 10 seconds», Timeout = TimeSpan.FromSeconds(10).
- REF-195: dotnet/extensions v10.11.0, Polly/HttpRetryStrategyOptions.cs, líneas 22-29: reintenta fallas transitorias, incluida TimeoutRejectedException.
- REF-55 se volvió a abrir el 2026-10-27 para confirmar el texto citado: «OLLAMA_NUM_PARALLEL … default 1», «Required RAM will scale by OLLAMA_NUM_PARALLEL * OLLAMA_CONTEXT_LENGTH» y «kept in memory for 5 minutes».
Desvíos de la ficha:
- Snippet de Aspire: ver arriba.
- La lista de «lo que la demo no implementa» de §12.8 se acota a lo operativo y remite a §14.6 para el resto, para no duplicar la casa de §14.6.
- La pregunta de N5 P8 se responde dentro de §12.3 y la de «qué cambia del prototipo a producción», dentro de §12.8, como pide la ficha. N5 P10 se responde en §12.4 con remisión a §6.5. N5 P3 queda en el Anexo F.
- El diagrama del pipeline de §12.3 sólo compara los dos órdenes; el pipeline completo ya está en §5.4 y no se repite.
- La plantilla de §12 del Anexo A se citó con el ancla anexo-a-12 (carta §13).
Procedencia de las salidas:
- 17 con modelo: Evidencia/17-Observabilidad-Y-Pipeline/, log de la corrida con modelo del 2026-10-27, líneas 4, 8, 9, 12-17; registro Evidencia/R-LLM/17-Observabilidad-Y-Pipeline.modelo.jsonl, entrada e01 (dos llamadas p1 y p3 y la línea del oráculo, resultado pasa).
- 17 --fake (comparaciones con el cliente guionado): Evidencia/Cierre-Construccion/verificar-build.saneo.log, líneas 764, 768 y 769.
- Sonda de tiempos (91,7 s y 123,1 s): cifra de la tabla de la carta §10, con el rótulo de §5.7.
- Sondeo del entorno (un modelo residente en CPU, cambio de modelo = descargar y cargar): Bitacoras/Sondeo-Entorno.md §0, conducta sin cifras.
- Demo sin AddOpenTelemetry ni limitador: búsqueda en Demos/MovilidadUrbana.Asistente/src (2026-10-27); UseOpenTelemetry sólo en Infrastructure/AI/Chat/SesionDeChat.cs.
Verificación adversarial (2026-10-27), correcciones aplicadas:
- «la misma consulta» → «la misma pregunta»: en DEP-13 el texto del pedido es idéntico pero hash_instrucciones difiere entre k01 y k02 (646 y 645 tokens de prompt).
- Fuente y medidor «por defecto»: la demo usa sourceName propio (SesionDeChat.cs).
- §12.5: ASPNETCORE_ENVIRONMENT no decide el contenido en ningún código; sólo DOTNET_ENVIRONMENT en 17 (Ambientes.DelProceso).
- §12.8, fila Contenido: la demo llama UseOpenTelemetry sin configure, así que EnableSensitiveData queda en false salvo OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT; «el compose fija Development» sugería contenido encendido.
- §12.7: «cero reintentos» no es configurable: Polly 8 declara MaxRetryAttempts con [Range(1, int.MaxValue)] (RetryStrategyOptions.TResult.cs, etiqueta 8.6.4, leído con curl el 2026-10-27). Se reemplazó por un ShouldHandle que no reintente [REF-195]. El plan v3 §C dice «cero reintentos» (AJ-02): desvío a convalidar.
- §12.7: «todo HttpClient» acotado a los de IHttpClientFactory (ConfigureHttpClientDefaults, REF-193); la fábrica crea su HttpClient con new y no queda alcanzada.
- §12.3: «no de la aplicación» se quitó (los tokens dependen del prompt que arma la aplicación).
- §12.9 y pregunta 3: marcados como criterio de la guía (N0b §3.2.4 y Sondeo §0 los declaran criterio propio).
Conteo de palabras de prosa (comando de la carta §16.3): 2.198 antes de la verificación y 2.200 después (en el tope). Tope de la sección (carta §16.3): 2.200.
Snippets por encima de 25 líneas: ninguno (compose 22, PipelineObservado 16, CapturaDeTelemetria 9).
R-PRIV: el único literal de dirección es 127.0.0.1:8080:8080 del compose (loopback, publicado así en el repositorio y en el README). AC-7/AC-8 sin correr (las corre la integración).
Remisiones usadas: s0-4, s2-2, s5-4, s5-5, s5-6, s6-4, s6-5, s7, s8-2, s10-3, s10-4, s10-7, s11-4, s11-5, s11-6, s13-4, s13-10, s14-5, s14-6, anexo-a-12, anexo-f, oa-o1, oa-o2, oa-o4; internas: s12-1, s12-2, s12-3, s12-4, s12-6, s12-7, s12-8, s12-9, s12-ejemplos.
Cifras citadas (todas en la tabla de cifras citables): sonda de tiempos 91,7 s y 123,1 s; 17 conducta 1 de 1; «los tiempos pesimistas no acotan la cola bajo carga» (como «ningún tope fijado de antemano acotó la espera»). Valores que no son mediciones del laboratorio, con su fuente: 10 s de AttemptTimeout [REF-194], OLLAMA_NUM_PARALLEL 1 y cinco minutos [REF-55], GA de Foundry Local 2026-04-09 [REF-179], diez minutos de espera de la fábrica (código, §5.5). Las salidas de 17 muestran 2 llamadas, 2 y 3 tramos, 4 líneas de log: son conducta del código.

## §13 (`secciones/13.md`)

Quitado por falta de respaldo citable:
- ADR-05: el conflicto de SQLitePCLRaw entre SqliteVec y EF Core SQLite (N6 T3 / N3 E4): no re-ejecutado ni en Evidencia/; queda sólo «preview» y «pre-v1». Ojo para §14.4, que lo lista como tensión.
- ADR-05: que InMemory «no sirve para pruebas de integración» (N3 A5): se reemplazó por la recomendación de REF-89 (Testcontainers).
- ADR-06: qué IServiceProvider recibe AIFunctionArguments.Services con un cliente singleton (N0b D-06, «sin verificar»): no entra; ADR-12 se apoya en lo que comprueban Composicion_ValidateScopes y Herramientas_SinParametrosDeDi.
- ADR-12: que FunctionInvokingChatClient «fija su IServiceProvider al construirse»: sólo lo dice un comentario de SesionDeChat.cs (con ID interno); el contexto del ADR se escribió sin esa causa.
- ADR-09: N5 E2 como fuente del orden caché/telemetría: se usa el invariante de código de 17 (--verificar), no el dossier.
- ADR-03: «la calidad de Qwen para tool calling no se midió» (N0b, anterior a la construcción): las extensiones de 08 sí corrieron; se escribió «el modelo local se observó sólo en las tareas de los ejemplos», sin cifra.
- §13.15: AllowBackgroundResponses y ContinuationToken de ChatOptions (N2, por reflexión, sin REF ni registro en Evidencia/): no se nombran. El «agente en segundo plano» experimental del harness de MAF en Python (N4 §8.9): no entra.
- Cifra 4/4 de 08 y tiempos de la sonda de aprobación (25,1 s y 29,6 s): citables, omitidos por presupuesto; no cambian ninguna decisión.
Fuentes dadas de alta: ninguna.
Verificación adversarial (2026-10-27), correcciones aplicadas:
- ADR-02: `RawRepresentationFactory` pasa a [REF-64] (comentario de ChatOptions.cs); `GetService` queda en [REF-45]. «el único que crea un cliente de Ollama» era falso para todo el árbol (Examples/04-Normalizacion-Contra-Catalogo/Program.cs también crea un OllamaApiClient): se acota a la demo.
- ADR-08 contexto: según N6 §1.1.3, el «no vacío» del caso base vale para provincia, localidad de la encuesta, frecuencia y motivo; los medios se validan por cantidad. Decía «provincia, medios, frecuencia y motivo».
- ADR-08 consecuencias: GarantiaNumerica de la demo cubre habitantes en la localidad y edad, distancia y minutos en la encuesta (ExtractorDeEncuesta.cs l. 43-46); lo que no cubre frente a GarantiaDelTexto de 03 es el código postal (README de la demo, desvío 3). Decía «cubre sólo habitantes».
- ADR-09: la demo no fija EnableSensitiveData (SesionDeChat.cs: UseOpenTelemetry sin configurar); el «contenido sólo en Development» lo implementa 17 (PipelineObservado.cs l. 58-59). Se reescribió para no atribuirlo a la demo.
- Recortes para quedar en el tope: §13.1 «…y no lo otro», respuesta de la pregunta guía «una que se revierte en minutos no necesita ADR», ADR-10 «los oráculos». ADR-09: «17 lo comprueba en cada corrida» pasa a «con `--verificar`» (README de 17, «Invariantes de código»).
Desvíos de la ficha:
- La ficha pide «alternativas con fuente» en cada ADR. ADR-12 y ADR-13 tienen alternativas que salen del plan aprobado y del código, no de una fuente externa (ADR-12 cita REF-122 para la aprobación; ADR-13 cita REF-186 para el caso base). Se declara así para la presidencia.
- Confianza de ADR-12 y ADR-13: el plan las fijaba en «media hasta» las sondas de aprobación y conservación de la sesión y el humo del host. Como las tres se cumplieron (sonda de aprobación en dos peticiones en Sondas/; 11 con 1 de 1; Host_Humo_EstilosYEstados y Host_CookieSoloEnDocumentos en verde dentro de 70/70), la sección escribe «alta en el mecanismo» y aclara que la conducta con el modelo se vio una vez. Lectura de la redacción; la presidencia puede volverla a «media».
- La línea de ubicación usa «transversal · capa Infrastructure/AI» (dominante); Host va en la prosa de la apertura.
- La pregunta guía vive en §13.1 (la sección no lleva la plantilla temática ni «Práctica de §13»); «¿cuándo deja de valer?» es el campo «Deja de valer si» de cada ADR, como fija la ficha.
- El campo «En la demo» de la plantilla se rotula «Demo.» para entrar en el tope; la plantilla del Anexo A puede usar el nombre largo.
- Sin diagramas ni snippets: la ficha dice «ninguno nuevo» y remite a §3.1 y §14; los snippets de las piezas (SesionDeChat, HerramientasDelAsistente, ArquitecturaTests, OpcionesDelProveedor, FabricaDeClientes) ya tienen casa en §4, §5 y §8. Se nombran archivos y pruebas, todos verificados contra el árbol.
- ADR-07: PD-6 «en el escalón 1 con estado, sin MAF», como el código y §8 (la carta §2.1 dice que PD-6 usa un agente de MAF; el código no referencia Microsoft.Agents en la demo).
- §13.15 suma, en una oración, el escalón 3 y la autorización real como decisiones no registradas, con remisión; la ficha sólo nombraba «sincrónico o en segundo plano».
Procedencia de las salidas (todas en prosa, sin bloque):
- ADR-08: Evidencia/R-LLM/03-Salida-Estructurada.modelo-ext.jsonl (0/4 habitantes propuestos sin el dato, IC95 de la tabla de cifras citables).
- ADR-10: Evidencia/R-LLM/15-Pruebas-Y-Evaluacion.modelo.jsonl (0/52 interpretables; acuerdo 0/10, IC95 [0; 0,308]; anotador = agente), como lo resume Examples/15-Pruebas-Y-Evaluacion/README.md.
- ADR-12: Evidencia/Sondas/DEP-09-Sonda-Aprobacion.jsonl y Sondas/dep09.log (pedido conservado, aprobación alterada rechazada).
- ADR-06: «ninguna de las 70 pruebas registra una baja sin aprobación»: Evidencia/Cierre-Construccion/demo-pruebas.cierre.log (Total tests: 70, Passed: 70).
- ADR-09: invariantes de 17 (caché afuera sin tramo del acierto; temperatura ausente en el tramo): Examples/17-Observabilidad-Y-Pipeline/README.md, «Qué observar» e «Invariantes de código»; registro R-LLM/17-…modelo.jsonl.
Conteo de palabras de prosa (comando de la carta §16.3): 2.600 después de la verificación adversarial (antes 2.596). Tope de la sección: 2.600. La primera versión daba 3.318; se recortó en cuatro pasadas (frases de contexto, repeticiones con §6, §7 y §8, rótulo del campo «En la demo»), sin tocar rótulos, cifras ni procedencia. Respuesta de la pregunta guía: 98 palabras.
Snippets: ninguno.
Marcas «criterio de la guía»: 2 (confianza en §13.1; costo por escalón en ADR-07).
Remisiones usadas: s2-1, s3-1, s3-2, s4-3, s4-4, s4-6, s5-3, s5-4, s5-5, s5-6, s5-7, s5-8, s6-3, s6-6, s7-1, s7-6, s8-1, s8-5, s8-7, s8-8, s8-9, s10-2, s10-4, s10-6, s10-7, s11-2, s11-3, s12-2, s12-4, s14, s14-1, s14-6, anexo-a-13, anexo-f, oa-a1. Anclas propias: parte-vi, s13, s13-1 … s13-15.
Cifras citadas (todas en la tabla de cifras citables): 03 extensión 0/4, IC95 [0; 0,602]; 15 juez 0/52 interpretables, acuerdo 0/10, IC95 [0; 0,308]; demo 70 pruebas, 0 bajas sin aprobación. Conteos de la demo que no son cifras de laboratorio: 12 requisitos, 13 ADR, cuatro reglas de arquitectura, quince componentes del caso base (del plan aprobado).
Compuertas corridas sobre la sección: remisiones al plan 0, familias de ID 0, rutas/IPs/localhost 0, voseo 0, alias en títulos 0 («vectores» queda en el sentido de columna de una base, como en §7; «LLM juez» es canónico). AC-7/AC-8 sin correr (las corre la integración).

## §14 (`secciones/14.md`)

Quitado por falta de respaldo citable:
- Que SqliteVec y EF Core SQLite convivan en el mismo archivo resolviendo SQLitePCLRaw a la serie 3 sin advertencias: lo respalda sólo la sonda del dossier N6, no re-ejecutada. Queda el hecho de los manifiestos (REF-200) y la decisión como criterio de la guía.
- Que MAF arrastre versiones concretas de VectorData o de OpenTelemetry: los números están en un comentario de Examples/Directory.Packages.props, no en la tabla de cifras citables; se describe el mecanismo y se remite al Anexo F.
- Recuento de diff-base.sh (iguales, distintos, nuevos): no está en la tabla de cifras citables (AC-9); se dice sólo que la compuerta falla si un cambio no tiene fila.
- Tiempos de los humos y del arranque: no citables y, en el servidor compartido, no comparables.
- El primer humo de PD-6 (defecto de la prueba, repetido): no se cita.
- El tiempo por consulta del 7B en CPU que motivó no comparar contexto completo y RAG: cifra de dossier no re-ejecutada; queda «por costo de tiempo».
- Prosa final del modelo en PD-6 (trae «usted»): no se muestra; la conducta va en prosa.
- La salida del modo guion de la página (Evidencia/Demo-MovilidadUrbana.Asistente/demo-asistente-chat.txt): no se muestra porque su rótulo incluye un identificador interno de plan de embeddings que la compuerta de familias de ID marcaría.
- Que la prueba Category("LLM") de 11 no corrió por presupuesto: sólo lo dice la bitácora de construcción, no un archivo del repositorio; no entra en §14.6.
Fuente nueva: REF-200 (manifiestos .nuspec de NuGet de Microsoft.EntityFrameworkCore.Sqlite 10.0.14 y CommunityToolkit.VectorData.SqliteVec 1.0.3-preview), verificada con curl el 2026-10-27; alta pendiente de convalidar por la presidencia (00-Referencias.md, al final de la lista y en la tabla de correspondencia). Se usa además REF-196 (MCP, «Servers SHOULD implement proper authentication for all connections»), dada de alta por la redacción de §11 y pendiente de convalidación.
Desvíos de la ficha:
- La pregunta «¿Qué cambió del caso base?» lleva OA-A1 (como pide el plan) y además OA-A6, porque la decisión que cambia es clasificar cada pieza de la tabla de delta.
- Los dos diagramas de la ficha (arquitectura de la demo y redibujo de la imagen) se fundieron en uno, en §14.2, con las capas de la imagen como títulos de los subgrafos; se sumó un diagrama de secuencia de PD-6 en §14.3. El diagrama de arquitectura del plan llevaba paréntesis en las etiquetas y una flecha duplicada; se redibujó desde el código.
- Línea de ubicación: §14 cruza las dos escaleras; se escribió «escalones 0 a 2 de las dos escaleras» en lugar de la forma de una escalera.
- Tensiones con nombre, sin sus IDs internos.
- La tabla de delta es una versión agrupada de la del README de la demo (que sigue siendo la completa); EF Core 10.0.11 → 10.0.14 va como «versiones centrales» (Anexo F).
Procedencia de las salidas:
- PD-2: Evidencia/R-LLM/Demo-MovilidadUrbana.Asistente.modelo.jsonl, entrada_id pd2-01, campo salida (copia textual); embeddings: Evidencia/Demo-MovilidadUrbana.Asistente/embeddings-PD-2.v1.resumen.json y embeddings-fase-3a.txt.
- PD-3: mismo registro, pd3-01, campo salida (copia textual, saltos de línea del registro).
- PD-6: mismo registro, pd6-01, llamada_n 1, campo herramientas (copia textual del único elemento); el pedido mostrado sale del motivo de la línea «entrada» de pd6-01.
- «Los tres humos pasaron su oráculo»: líneas «entrada» del registro (resultado «pasa» en las tres) y Evidencia/Demo-MovilidadUrbana.Asistente/recalculo-oraculos.txt (3 de 3 coinciden).
- 70 pruebas sin servidor: Evidencia/Cierre-Construccion/demo-pruebas.saneo.log (Total tests: 70, Passed: 70).
Conteo de palabras de prosa (comando de la carta §16.3): 1.898, después de la verificación adversarial. Tope de la sección: 1.900.
Snippets por encima de 25 líneas: ninguno.
Remisiones usadas: anexo-f, oa-0-1, oa-0-2, oa-0-3, oa-a1, oa-a6, oa-d2, oa-o2, s0-4, s1, s10-4, s10-6, s11-3, s11-4, s11-5, s11-7, s12-4, s12-6, s12-8, s13, s13-12, s13-13, s13-14, s13-7, s13-9, s2-2, s2-4, s3-1, s3-3, s3-5, s4-4, s5-3, s5-5, s5-ejemplos, s6-3, s7-3, s7-ejemplos, s8-8; internas: s14-1.
Cifras citadas: 70 pruebas sin servidor y 0 bajas sin aprobación (tabla de cifras, fila PD-6); humos PD-2, PD-3 y PD-6 como conducta, sin tasa. Los demás números son datos del código o de los estímulos (12 requisitos, 20 respuestas sembradas, códigos postales de las entradas), no mediciones.
AC-7/AC-8 sin correr (las listas viven fuera del repositorio); las corre la integración.
Verificación adversarial (2026-10-27), correcciones: (1) «las tasas de 03, 07 y 11»: 11 no tiene tasa en la tabla de cifras (conducta 1 de 1); queda «03 y 07». (2) «Ninguna dirección ni modelo tiene valor en el repositorio»: el código tiene defaults (README de la demo, tabla de variables); pasa a «dirección de la infraestructura ni usuario», como dice el README. (3) Tensión de cultura: «90.000» lo escribe la persona y GarantiaNumerica lee el texto (comentario de GarantiaNumerica.cs; «12.5» del modelo, N6 T6). (4) «la ayuda no toca el dominio» → «no escribe ni lee datos de la sesión» (comentario de AyudaController.cs). (5) La copia literal incluyó las pruebas de la API (README de la demo, «Delta frente al caso base»). (6) El bloque bash cita su origen (README de la demo). Para compensar las palabras se quitó «Siete choques aparecieron al integrar» y se acortó la frase de tiempos de §14.5.
Abierto (decisión): el plan pide en §14.6 «lo no ejecutado del presupuesto de plan §E.5»; 06-Construccion §2.1 (AC-3a) declara que las pruebas Category("LLM") de 11 y de la demo no corrieron por presupuesto, y §8 dice «no se cita» para la de 11. Falta decidir si §14.6 lo nombra como deuda sin cifra.

## §15 (`secciones/15.md`)

Quitado por falta de respaldo citable o para no agregar material:
- OA-O2 pide «timeouts por variable», pero ni la demo ni Examples/ leen una variable de espera: la fábrica la fija como constante (TimeoutDelModelo, diez minutos; ConfiguracionDelModelo.cs no tiene variable de timeout). El ítem 20 dice lo que hace el código y remite a §12.7; el OA de §0.1 quizá deba ajustarse («timeouts explícitos»). Avisar a la presidencia.
- Ninguna cifra medida: los ítems se apoyan en líneas de salida con --fake y en nombres de pruebas, que son garantías de código o conducta del guion. El «8 de 10» del ítem 21 es el umbral del protocolo de §10.6, no una medición. El «70 localidades» del ítem 6 y el «k = 3» del ítem 13 son datos del código o del estímulo.
- Ítem 13: no se afirma que el k de la demo y de 07 se fijó con medición; §7.4 lo da como criterio de la guía y el ítem lo dice así.
- Ítem 2: la ubicación de NormalizadorDeCatalogo en Infrastructure/AI sale del diagrama de §14.2 (subgrafo AI LAYER) y de ADR-08 (Infrastructure/AI/NormalizadorDeCatalogo.cs); la del servidor MCP como adaptador de entrada, de §8.9.
- Ítem 7: las pruebas citadas existen en Examples/06-…/Pruebas/MetricasTests.cs y Examples/07-…/Pruebas/RagConCitasTests.cs; la lectura de 06 contra el modelo es la que ya está en §7 (Ejemplos).
- Ítem 12: los comandos dotnet test y la conducta de Category=LLM salen de Examples/15-Pruebas-Y-Evaluacion/README.md; que el modo --fake deja registro sale de Evidencia/R-LLM/15-Pruebas-Y-Evaluacion.fake.jsonl; la salida 0 de recalcular-oraculos.sh, de su cabecera.
- Ítem 20: «una búsqueda de tu dirección en el repositorio da cero resultados» es el criterio de R-PRIV puesto como chequeo del lector; «no arranca» sale de §14.5.
Fuentes dadas de alta: ninguna. REF citados: REF-84 y REF-92 (ítem 13), los mismos que usa §7.4.
Desvíos de la ficha:
- Anclas nuevas fuera del régimen de la carta §13: cierre y s15 son las previstas; se agregaron s15-i01 … s15-i27 (una por ítem, antes de un párrafo en negrita, no de un encabezado) para que la tabla índice enlace a cada ítem. Si la presidencia prefiere no tenerlas, se quitan con la columna de enlaces.
- Sin «Estás en»: §15 no es sección temática ni de una escalera. Apertura en un párrafo y una línea de comandos.
- Agrupadores por actor en negrita (como los de §8), no títulos.
- Ítem de OA-S3: el verbo es «aplicar», pero el OA no tiene ejemplo; va como caso, con la remisión a §7.6 y §7.7.
- Ítem de OA-S1: el plan nombra la ficha de riesgo del Anexo A llena para 16; como A.md ya la trae llena, el ítem pide la misma ficha para PD-4 (ESC-03), con la prueba Pd4_MedioInventado_SeRechaza que cita §14.3. La asignación de LLM01, LLM02 y LLM05 a ESC-03 es la del mapa de §11.1.
- Ítem 3 usa «¿cuántas respuestas declaran bici?» como dato exacto; la herramienta de la demo que lo resuelve es resumir_encuesta (agregados), sin nombrarla para no adelantar la respuesta.
- §0 no estaba escrita al redactar: s0-1, s0-4 y las 27 oa-* usan las anclas previstas en la carta §13 (oa-* van en la tabla de §0.1). §3 (03.md) apareció durante la redacción y se contrastó: §3.1 pone el servidor MCP en Presentación como adaptador de entrada y Host para la configuración; §3.5 declara que PD-2 sube de más y ubica PD-5 en agencia 1 con aprobación.
Procedencia de las líneas de salida citadas (todas con --fake, sin modelo):
- 02: «oráculo dos-adaptadores: pasa», Examples/02-Cambio-De-Adaptador/README.md (Salida esperada) y el grep de su «Qué observar».
- 03: líneas de e02, secciones/05.md (salida --fake de 03; Evidencia/03-Salida-Estructurada/fake-demostracion.log).
- 13: líneas del servidor guionado, Host y Origin e invariantes, Examples/13-Servidor-Y-Cliente-MCP/README.md (Qué observar) y secciones/08.md.
- 14: «firma igual…» e «invariantes de código: se cumplen», Examples/14-Anotaciones-SK-vs-MEAI/README.md y secciones/09.md.
- 17: «spans: 2», «2 de 2 spans con contenido…», Examples/17-Observabilidad-Y-Pipeline/README.md y secciones/12.md.
- Texto del pedido de PD-6: secciones/14.md (§14.3), del humo de la demo; el ítem 26 lo usa como texto a rastrear en el código, no como salida del modelo.
Pruebas citadas (verificadas por nombre en los archivos): SoloProgramCs_NombraLosAdaptadores (02); TryGetResult_FalseConTextoNoJson (03); Pareada_SeisDiscordantesEnElMismoSentido_SeAfirma (06); Validador_CitaNoRecuperada_SeRechazaSiempre, Oraculo_NoRespondible_SoloPasaConNoSe, Oraculo_CasoE5_CitaYContradice_Falla (07); CpInvalido_Aprobado_ElCasoDeUsoRechaza_YElResultVuelveAlModelo, SinAprobacion_NoSeEjecuta, Aprobacion_ArgumentosAlterados_SeRechaza (09); Desajuste_ElTextoDiceResistencia_LaLlamadaPideCorrientes_ElPedidoMuestraCorrientes, Aprobacion_ArgumentosAlterados_SeRechaza (11); Servidor_EscuchaSoloEnLoopback (13); Pd4_MedioInventado_SeRechaza (demo); Compartido_SinNumCtxDelArnes_Rechaza (_Comun); Herramientas_SinRepositorios (demo).
Remisiones usadas: s0-1, s0-4, s2-1, s2-2, s2-3, s2-4, s2-5, s3-1, s3-2, s3-5, s4-4, s5-3, s5-5, s5-6, s6-1, s6-3, s6-6, s7-3, s7-4, s7-5, s7-6, s7-7, s7-ejemplos, s8-1, s8-3, s8-5, s8-6, s8-8, s8-9, s9-1, s9-5, s9-7, s9-criterio, s10-2, s10-4, s10-5, s10-6, s11-1, s11-3, s11-4, s11-5, s12-1, s12-2, s12-3, s12-4, s12-6, s12-7, s13-1, s13-4, s13-15, s14-1, s14-2, s14-3, s14-5, anexo-a-11, anexo-a-13, y los 27 oa-*; internas: s15-i01 … s15-i27.
Cifras citadas: ninguna medición.
Conteo de palabras de prosa (comando de la carta §16.3): 2.927; tope de la sección: 3.000. Snippets: ninguno. Diagramas: ninguno (la ficha no pide).
AC-7/AC-8 sin correr (las listas viven fuera del repositorio); las corre la integración.
Verificación adversarial (2026-10-27): pruebas, tipos, líneas de salida y anclas cotejados contra Examples/, la demo y las secciones (todos existen). Corregidos: ítem 4 (02 no tiene un adaptador «por defecto»: sin argumento corre las dos vías; AsistenteDeAlta.cs no está en Application/); ítem 13 («pasar el corpus entero» es la definición del escalón 1 de §6; el 0 son los requisitos en las instrucciones, §3.5); ítem 12 (se salta con Assert.Ignore, README de 15); ítem 20 (el rechazo sin OLLAMA_NUM_CTX es sólo con el compartido: ConfiguracionDelModelo.Validar); ítem 25 (con descarte posterior los ajenos no llegan al contexto salvo que el descarte falle); ítem 27 (entre PluginSk.cs y HerramientaMeai.cs cambian también el using y el tipo que devuelve la fábrica); tabla índice alineada con los «Repasá» de los ítems 13, 23 y 25.

## Anexo A (`secciones/A.md`)

Quitado por falta de respaldo citable:
- Que una versión en línea en un PackageReference sea el error NU1010 (lo dicen los comentarios de Examples/Directory.Packages.props y el plan): la página verificada (REF-201) no lo nombra en el texto extraído; la fila dice sólo «ninguno» y el Qué mirar cita la regla de la fuente.
- Versiones transitivas que arrastra MAF (10.10.0 y 10.10.1, comentario del props con IDs internos): no se repiten; quedan como «versiones anteriores» con remisión al Anexo F.
- En A.6, «la guarda de truncado no marcó ninguna llamada en 01» (§6, con rótulo): se reemplazó por la remisión a s6-preguntas para no repetir una salida con su rótulo.
- Una plantilla en bloque copiable (esqueleto markdown) por anexo: no sale de un archivo de Examples/ ni de Demos/ (carta §1.4); la tabla es la plantilla.
- Valores de EMB_PLAN: no se escriben porque marcan la compuerta de familias de ID; se remite a §7, como §12.
Fuentes dadas de alta (al final de 00-Referencias.md, con fila «ninguno: verificada por la redacción del Anexo A (2026-10-27)»; pendiente de convalidación, carta §16.10):
- REF-201 Microsoft Learn (NuGet), «Central Package Management», https://learn.microsoft.com/en-us/nuget/consume-packages/central-package-management, ms.date 2025-08-22. Verificada con curl y extracción del texto el 2026-10-27. Citas: «In each project file, define <PackageReference /> elements without the Version attribute. The version will be resolved from the corresponding <PackageVersion /> entry in Directory.Packages.props»; «Note that downgrades are not allowed when transitive pinning a package. If you attempt to pin a package to a lower version than the one requested by your dependencies, restore will raise a NU1109 error»; CentralPackageTransitivePinningEnabled «in a project or in a Directory.Packages.props or Directory.Build.props import file».
Desvíos de la ficha:
- La ficha pide «una plantilla por sección temática» y nombra diez; son diez (A.4, A.5, A.6, A.7, A.8, A.10, A.11, A.12, A.13 y A.14 para el props). Numeración «A.N» = sección de la guía que la usa; el props, A.14 (sin sección temática propia), con el ancla anexo-a-props de la carta §13. Nunca se escribe el signo de sección antes de la letra del anexo (compuerta de remisiones al plan).
- Forma: cada plantilla es una tabla Campo · Preguntas que lo guían · En Movilidad Urbana (Profile, punto 6: «plantilla comentada, con las preguntas que guían cada campo»); la última columna la llena con el caso, para que cada plantilla sea también un ejemplo. A.12 lleva la columna «Por defecto» en lugar de la llena, porque el valor es el ejemplo.
- A.10 junta conjunto de oro y registro de corrida en una tabla, como los nombra la ficha.
- A.11 queda llena para 16, como pide OA-S1 («ficha de riesgo del Anexo A llena para 16»).
- A.13 se llena con ADR-11 (el más corto de §13); §13 pidió que el anexo use el nombre largo del campo («En la demo»): así quedó.
- Sin diagramas: la ficha no los pide.
- Snippets en XML: tres recortes contiguos, sin marca de recorte, porque cualquier «<!--» en la guía integrada marcaría la compuerta de PENDIENTES (carta §16.11); por eso tampoco se copió el comentario del props sobre Azure.AI.OpenAI (lo cuenta la fila «Preview transitiva»).
- Tope: la carta §16.3 no reparte el tope de Anexos (7.430) por anexo. Conteo de prosa (comando de la carta §16.3): 2.261 (primera versión 2.466, recortada en dos pasadas sin tocar preguntas, rótulo ni cifras). Propuesta de la redacción, a convalidar por la presidencia junto con B–G: ≤ 2.300 para A; si la relectura recorta, el orden sugerido es la fila ASISTENTE_MODO de A.12, la fila «Doble» de A.4 y la fila «Huella» de A.14.
Procedencia: sin salidas de modelo en bloque. La cifra 0/6 de A.11 sale de Evidencia/R-LLM/16-Inyeccion-Indirecta.modelo.jsonl (líneas tipo «entrada»), como la cita §11.7 con la tabla de cifras citables. Los valores de A.5 (5 y 2), A.12 (defaults) y A.14 son constantes del código, no mediciones: SesionDeChat.cs l. 29-30; ConfiguracionDelModelo.cs; PipelineObservado.cs l. 27-29 (sin DOTNET_ENVIRONMENT, producción); Demos/MovilidadUrbana.Asistente/README.md l. 99 (ASISTENTE_MODO); Demos/Directory.Packages.props l. 3-5 (mismas versiones en las familias compartidas); Examples/Directory.Build.targets (paquetes_hash).
Verificado contra el árbol (2026-10-27): IExtractorDeLocalidad.cs, ExtractorDeLocalidad.cs, AltaDesdeTextoService.cs, Infrastructure/AI/DependencyInjection.cs (AddAI, AddChatClient), SesionDeChat.cs, FabricaDeClientes.cs, ClienteDeDemostracion.cs, IndiceDeAyuda.cs (FragmentoIndexado, CrearAsync), conjunto-de-oro.v1.json, RegistroRllm.cs, ConfiguracionDelModelo.cs, Examples/Directory.Packages.props, Demos/Directory.Packages.props, Examples/Directory.Build.targets, 09-Caso-De-Uso-Como-Herramienta.csproj. Pruebas: Domain_SinDependenciasDeIa, SdkDelProveedor_SoloEnInfrastructureAIyProgram, CapaUnica_TodaLlamada, VersionesDirectas_SonLasDelAnexoF, Familias_UnaSolaVersion_SinPreviews (demo); Validador_CitaNoRecuperada_SeRechazaSiempre (07); Oro_ValoresEsperadosSalenDeLasReglas (06); Origen_SinHerramientaDeEscritura_CeroPedidosPosibles, Escritura_ConResultadoNoConfiable_PideAprobacion, Escritura_NoAprobable_ConResultadoNoConfiable_Rechaza (16).
Remisiones usadas: s2-3, s4-3, s4-4, s4-preguntas, s5-4, s5-5, s6-1, s6-3, s6-5, s6-6, s6-preguntas, s7, s7-1, s7-2, s7-6, s7-7, s8-3, s8-4, s8-5, s9-1, s10-2, s10-4, s10-7, s11-1, s11-4, s11-6, s11-7, s12-2, s12-6, s13-1, s13-5, s13-6, s13-12, s14-6, anexo-b-herramientas, anexo-f; internas: anexo-a-5, anexo-a-10, anexo-a-11, anexo-a-12. Anclas propias: anexo-a, anexo-a-4, anexo-a-5, anexo-a-6, anexo-a-7, anexo-a-8, anexo-a-10, anexo-a-11, anexo-a-12, anexo-a-13, anexo-a-props.
Cifras citadas (todas en la tabla de cifras citables): 16, 0/6 por variante, IC95 [0; 0,459], b = c = 0, sobre un solo texto de ataque, del mismo autor. Conteos que no son mediciones: 12 requisitos, 16 preguntas del oro (12 + 4), 1024 dimensiones (REF-106 vía §7.1 y el código), k = 3.
Verificación adversarial (2026-10-27): «Doble» de A.4 decía «un doble del puerto ([§10.2])», pero §10.2 es el doble de IChatClient y ninguna prueba dobla IExtractorDeLocalidad: el caso de uso se prueba con el adaptador sobre GuionChatClient+ClienteEspia (Examples/03-Salida-Estructurada/Pruebas/SalidaEstructuradaTests.cs l. 17-25); corregido. EMB_PLAN tenía «—» como default, pero el código y el README de la demo fijan uno (ConfiguracionDelModelo.cs l. 76): se describe el valor sin nombrarlo. «se reconstruyen» acotado a la corrida con modelo (06-Construccion §2, observación transversal; Examples/17 README l. 63). FabricaDeClientes.cs con ruta completa (no está en la demo). Resultado de A.8 nombra ResultadoDeHerramienta (09, HerramientasDeLocalidades.cs l. 14-21). Dimensión de A.7: la comprobación corre sólo si el generador informa la dimensión (IndiceDeAyuda.cs l. 34-35). REF-185 respalda «alternativas descartadas», no «cada una con su fuente» (criterio de N0b §3.4): cita movida. Abierto: el ancla anexo-f todavía no existe (falta la sección F).

## Anexo B (`secciones/B.md`)

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

## Anexo E (`secciones/E.md`)

Quitado por falta de respaldo citable:
- Que las pruebas [Category("LLM")] de 11 y de la demo no corrieron por presupuesto: sólo lo dice la bitácora de construcción (06-Construccion §2.1, AC-3a), no un archivo del repositorio ni un registro de Evidencia. Misma decisión que §14 (su PENDIENTES lo deja abierto para la presidencia). No entra en E.7.
- Cantidad de pruebas sin servidor de Examples (443) y de consolas: no están en la tabla de cifras citables; E.4 dice «terminaron sin fallas» con el log como respaldo. Las 70 de la demo, ya citadas en §14.5, no se repiten.
- Tope del servidor de chat (14.400 s), consumo de turnos y tiempos previstos de cada vía: datos del arnés y de la bitácora, no cifras citables; E.7 describe la regla de cola sin números.
- Valores de EMB_PLAN (EMB-A/B/C) y nombres de recurso del arnés (los de ejemplo.json y de «fase lan»): la compuerta de familias de ID marca EMB-C, y la carta (§1.3) deja fuera los nombres internos de recurso y de turno. Se nombra la variable y se describe el valor; las cuatro fases se describen sin el comando «fase <…>».
- Línea «extension … (TURNO-2)» del bloque de comandos de Examples/README.md: lleva un ID interno y no se edita (carta §16.5); la vía se nombra en prosa.
- Líneas del README de la demo con la dirección de loopback y el puerto: no se copian (criterio prudente ante la compuerta de privacidad, como §14.5).
- Que /v1 o una ventana distinta recarguen el modelo de otros clientes: se escribe como «el README da como motivo… no se verificó» (carta §16.13).
Fuentes nuevas: ninguna.
Desvíos de la ficha y criterios propios:
- El plan no fija las anclas internas del Anexo E: se usaron anexo-e-1 … anexo-e-7 (criterio de esta redacción, en la línea de anexo-a-N de la carta §13). Títulos «E.n» sin «§» para no disparar la compuerta de remisiones al plan.
- La ficha pide «cómo reproducir cada ejemplo y la demo en contenedor»: va en E.5, una sola subsección, para no repetir §14.5 (comandos de la demo) ni §12.6 (compose.yaml); acá van sólo el orden, el modo host y la nota de DOCKER_CONFIG, sin bloque de código.
- Las celdas «conducta» de E.1 no llevan cifras; las de 03, 04, 07, 08, 16 dicen «tasa» y remiten. Las cifras viven en las secciones (carta §8, una casa por pieza).
- La tabla de la demo no repite los pedidos de §14.3 (casa de los pedidos y del diagrama de PD-6).
- La columna «Qué dejó la corrida con modelo» no repite cifras: remite al bloque Ejemplos de cada sección (casa de las cifras).
- Se agregó una subsección de requisitos y fases (E.3) con un diagrama de las cuatro fases del arnés, que la ficha no nombra pero que hace falta para reproducir.
- Sin preguntas guía: la ficha del anexo no las pide.
Procedencia de las salidas:
- Salida --fake de 01: Evidencia/Arnes/01-Chat-Y-Streaming.fake.log, líneas 2–4 y 9 (copia textual; recorte «[…]» de e02 y de la variante negativa, ya mostrada en §5).
- Línea «entrada»: Evidencia/R-LLM/03-Salida-Estructurada.modelo-ext.jsonl, primera línea tipo «entrada» (x01), copia textual. Rótulo: campos modelo, digest, ollama_version, servidor y fecha de la línea «llamada» de x01.
- Recálculo y tasa de 16: Evidencia/16-Inyeccion-Indirecta/recalculo-oraculo.log, líneas 2 y 11–12 (copia textual; recorte «[…]» de las líneas de rc y de las corridas fake e interrumpida).
- «Sin fallas» de E.4: Evidencia/Cierre-Construccion/verificar-build.saneo.log (todas las líneas «Passed!» con Failed 0; rc=0 al final).
Hechos tomados del código o del repositorio (no cifras medidas): dificultad e «ilustra» de cada ejemplo (carta §14 y las fichas de §5–§12); servidor de cada ejemplo (ejemplo.json, campo recurso, y plan E.2 para el modelo); fases y orden (tools/verificar.sh, fase_modelo y --con-modelo); comprobación del Ollama propio (función propio); lectura de /api/ps (función num_ctx_compartido); --no-build (correr_con_modelo); puerto cerrado (_sdk_correr); SHA-256 de entradas (entradas_congeladas); esquema sin dirección (comentario de RegistroRllm.cs); razonamiento y num_ctx desde las opciones (EscritorDeRegistro.Llamada); compuertas que fallan cerradas (Examples/README.md, «Compuertas»); lo no ejecutado: README de 01 (l. 50), 05 (l. 18), 12 (l. 71), 16 (l. 17), README de la demo (recorrido) y §5.6.
Conteo de palabras de prosa (comando de la carta §16.3): 1.675 (primera versión: 2.195; se recortó prosa de E.3–E.6 y se quitó el párrafo duplicado del modo guion de la demo). Las celdas de las dos tablas de mapa y de la tabla de E.7 cuentan y son cerca de la mitad. Tope: la carta §16.3 no reparte los Anexos por anexo (≤ 7.430 entre A–G, con las 280 del mapa que vino de §0.5); si la integración necesita bajar, el orden de recorte propuesto es la columna «Qué dejó la corrida con modelo» de E.1 (remite a otras casas) y el párrafo de compose de E.5 (casa §12.6).
Snippets por encima de 25 líneas: ninguno. Comprobación de snippets (carta §16.5): las siete líneas de comandos se encontraron textuales en Examples/README.md con grep -F; la línea JSON, textual en el registro de 03 ext.; el entradas_hash coincide con el sha256 de entradas.ext.v1.json en ejemplo.json de 03. Diagramas mermaid: uno (flowchart LR de cuatro nodos, etiquetas entre comillas, sin paréntesis ni comillas internas).
Remisiones usadas (verificación adversarial: se agregaron anexo-e-3, s10-4 y s11-4; s11-6 se cambió por s11-4 porque las compuertas viven en §11.4): s0-4, s5-1, s5-2, s5-3, s5-4, s5-5, s5-6, s5-7, s5-ejemplos, s6-3, s6-5, s6-ejemplos, s7-1, s7-2, s7-3, s7-5, s7-ejemplos, s8-2, s8-3, s8-4, s8-5, s8-6, s8-7, s8-8, s8-9, s8-ejemplos, s9-7, s10-2, s10-4, s10-6, s10-ejemplos, s11-2, s11-3, s11-5, s11-6, s11-7, s11-ejemplos, s12-1, s12-3, s12-5, s12-6, s12-ejemplos, s14-3, s14-5, s14-6, anexo-f, oa-d1 … oa-d9, oa-o1, oa-o3, oa-s1, oa-s2, oa-s4, oa-sk1; internas: anexo-e-5, anexo-e-6. Todas existen en secciones/ salvo s0-4, anexo-f y las oa-…, que pertenecen a §0 y al Anexo F, todavía sin redactar (anclas previstas por la carta §13).
Cifras citadas: 16, pedidos de baja inducidos 0/6 por variante, IC95 [0; 0,459] (tabla de cifras, fila 16), sólo dentro de la salida rotulada. Los demás números son datos del código o del diseño (ocho entradas de la extensión, cuatro fases, «Persona 01…20»), no mediciones.
AC-7/AC-8 sin correr (las listas viven fuera del repositorio); las corre la integración.

## Anexo G (`secciones/G.md`)

Quitado por falta de respaldo citable o por la regla de cifras:
- Cifras de los trabajos de G.1 (Cartridges: «38.6x less memory», «26.4x higher throughput»; TurboRAG: TTFT «up to 9.4x»; Cache-Craft: 51 %, 75 %, 1.6X, 2X): son de sus autores y no están en la tabla de cifras citables; no entran. La prosa dice «las cifras de estos trabajos son de sus autores».
- REF-81 (economía de guardar y reutilizar cachés KV, arXiv 2503.14647): vecino de G.1 en el dossier N3b, pero el plan nombra sólo cuatro trabajos; no se agregó (desvío evitado).
- Que TurboRAG «no requiera modificar el servidor de inferencia» (el resumen dice «without any requirement in modification of models and inference systems» y a la vez que ajusta un modelo preentrenado): contradictorio en la misma fuente; la tabla dice sólo lo que hace y el ajuste.
- Paquete A2A de MAF y su estado: no está en 00-Versiones (Anexo F) y la guía no usa A2A; se quitó la mención («A2A 1.0 support coming soon», REF-43, 2026-04-03) para no dar un estado sin fila.
- API de las orquestaciones (CreateHandoffBuilderWith, CreateMagenticBuilderWith, AgentWorkflowBuilder): sólo la respalda la reflexión del dossier N4 (E01), sin REF ni archivo del repositorio; no se nombran.
- Ejecución distribuida o durable de workflows: no verificada en N4; no entra.
- Meta T3 del Standard (informar que se interactúa con IA): el cuerpo no la usa; no se agregó.
- Contenido de ASI07, ASI08 y ASI10 más allá del nombre: el dossier N5 sólo verificó los nombres contra el PDF (como §11).
Fuentes dadas de alta: ninguna. Verificaciones hechas por esta redacción el 2026-10-27, con curl, sin alta nueva:
- API de arXiv (export.arxiv.org/api/query) sobre REF-67, REF-78, REF-79, REF-82, REF-83 (y REF-81): títulos, primer autor y resúmenes. Títulos para completar el Anexo D (las entradas dicen «sin título registrado»): REF-78 «Cartridges: Lightweight and general-purpose long context representations via self-study» (Eyuboglu et al., 2025-06-06); REF-79 «Enhancing Cache-Augmented Generation (CAG) with Adaptive Contextual Compression for Scalable Knowledge Integration» (Agrawal, Kumar, 2025-05-13); REF-82 «TurboRAG: Accelerating Retrieval-Augmented Generation with Precomputed KV Caches for Chunked Text» (Lu et al., 2024-10-10); REF-83 «Cache-Craft: Managing Chunk-Caches for Efficient Retrieval-Augmented Generation» (Agarwal et al., 2025-02-05); REF-67 «Don't Do RAG: When Cache-Augmented Generation is All You Need for Knowledge Tasks» (Chan et al.). Citas textuales de la tabla de G.1 tomadas de esos resúmenes. No se editó 00-Referencias.md: queda para quien edita el Anexo D.
- PDF de REF-04 (pdftotext): grupos «Accountability / Transparency / Fairness / Reliability & Safety / Privacy & Security / Inclusiveness Goals»; «Goal A1: Impact assessment» y «Microsoft AI systems are assessed using Impact Assessments».
- PDF de REF-05: «the Core is composed of four functions: GOVERN, MAP, MEASURE, and MANAGE»; «GOVERN is a cross-cutting function…».
- PDF de REF-06: «risks that are novel to or exacerbated by the use of GAI» / «risks unique to or exacerbated by the development and use of GAI»; «suggested actions».
- Página de REF-129 (ms.date 2026-07-29): la frase de las orquestaciones, textual.
- Página de REF-43: «Stable support for the orchestration patterns that emerged from Microsoft Research and AutoGen: sequential, concurrent, handoff, group chat, and Magentic-One. All patterns support streaming, checkpointing, human-in-the-loop approvals, and pause/resume for long-running workflows».
- Página de REF-115: la frase de orquestador-trabajadores y «The autonomous nature of agents means higher costs, and the potential for compounding errors. We recommend extensive testing in sandboxed environments, along with the appropriate guardrails».
Verificación adversarial 2026-10-27: confirmados contra arXiv (resúmenes de REF-78/79/82/83), REF-43, REF-115 y REF-129 por curl, y N0b B04 (Goal A3). Correcciones: G.1 ya no dice que ACC «opera sobre» la caché KV (su resumen habla de comprimir el contexto); la fila de REF-04 nombra la meta A3; «12» pasa a «el ejemplo 12».
Desvíos de la ficha y criterios propios:
- El plan da para G sólo la lista de temas (Cartridges, TurboRAG, Cache-Craft, ACC; gobierno de IA responsable completo; multiagente del escalón 3, handoff, Magentic), sin subsecciones, escenarios, preguntas guía, diagramas ni ejemplos. Se usaron tres subsecciones, una por tema, con anclas anexo-g-1 … anexo-g-3 (criterio de esta redacción, como anexo-e-N); títulos «G.n» sin «§» para no disparar la compuerta de remisiones al plan.
- Sin snippets, salidas, mermaid ni preguntas guía: no hay código de la guía que ejecute estas lecturas; el límite del escalón 2 ya lo muestra §8.8 con 12 (comentario de Examples/12-Uno-O-Varios-Agentes/Application/Workflows/CaminoDelResumen.cs, «En ningún punto un modelo elige el paso siguiente: eso sería el escalón 3 (handoff, Magentic), que la guía deja sin ejemplo»), y no se repite.
- G.2 suma la fila de Amershi y otros (REF-01): el dossier N0b deja fuera, junto con el gobierno completo, el «diseño UX detallado» y dice que esas fuentes se citan como lectura ampliada.
- G.3 suma REF-164 (ASI07, ASI08, ASI10) como lectura de riesgos con varios agentes; la asignación es criterio de la guía.
- La lista final de G.3 es criterio de la guía armado con piezas del cuerpo (§8.1, §8.2, §8.5/B.5, §8.8, §13.8); no agrega controles nuevos.
Procedencia de las salidas: ninguna salida de modelo.
Conteo de palabras de prosa (comando de la carta §16.3): 1.015 (buena parte en celdas de tabla y citas literales). Tope: el plan no reparte los 7.430 de Anexos; A 2.261, B 1.515 y E 1.675 suman 5.451 y dejan 1.979 para C, D, F (tablas de F fuera del conteo) y G. Si la relectura recorta: la oración final de G.1, la fila de Amershi y la lista final de G.3.
Snippets por encima del tope: ninguno.
Marcas «criterio de la guía»: 7 (≤ 8).
Remisiones usadas: s2-3, s2-4, s2-5, s6, s6-3, s6-4, s6-5, s6-6, s7, s7-7, s8-1, s8-2, s8-7, s8-8, s10-7, s11-1, s11-4, s12-9, s13, s13-8, s13-15, s14-6, anexo-a-11, anexo-b-herramientas, anexo-c, anexo-d. Todavía no existen en secciones/: anexo-c y anexo-d (previstas en la carta §13).
REF citados: REF-01, REF-04, REF-05, REF-06, REF-43, REF-67, REF-78, REF-79, REF-82, REF-83, REF-115, REF-129, REF-164.
Cifras citadas: ninguna medición. «18 pautas» es cifra de fuente (REF-01), ya usada en §2.5.
Compuertas corridas sobre la sección sin este comentario: remisiones al plan 0; familias de ID 0; voseo 0; IPs, rutas y puertos 0; alias: «LLM» sólo dentro de una cita literal en inglés. AC-7/AC-8 sin correr (las corre la integración).

## Ensamblado del 2026-10-27

- **Anexo D, títulos sin registrar.** Las entradas con `[sin título registrado: …]` se publicaron así: hay que abrir cada URL y copiar el título literal antes del cierre.
- **Anexo D, convalidación pendiente.** REF-193 a REF-201 llegaron al registro con la nota «pendiente de convalidación» (agregadas por la redacción de §11, §12, §14 y del Anexo A, verificadas con curl). La nota interna se quitó del Anexo D; la convalidación sigue abierta en `00-Referencias.md`.
- **Anexo D, fuentes sin número.** La sección «Pendientes» de `00-Referencias.md` (últimas versiones de NUnit, NUnit3TestAdapter y Test.Sdk; Aspire 13) no se publica: no tiene número REF.
- **Anexo C.** De la columna «Respaldo» se borraron los paréntesis de trazabilidad interna («plan §…», «carta §…», «H-…»); quedaron los `[REF-nn]` y la marca «criterio de la guía». La lista de alias para la comprobación de títulos no se publica.
- **Anexo F.** El bloque «Entorno de las corridas» entró como F.4; la columna «Respaldo interno» de `00-Versiones.md` no se publica. Las fuentes de F.4 dicen «registro de la compilación» y «registros de corrida» en lugar de los nombres internos.
- **Títulos repetidos de la plantilla.** «Aplicación por escenario», «Ejemplos», «Preguntas guía» y «Criterios de calidad y antipatrones» llevan « de §N» en la guía, como «Práctica de §N», para que no haya encabezados duplicados; la plantilla de §0.4 se ajustó igual. Las anclas explícitas no cambiaron.
- **§0.0.** Las líneas de los anexos del índice se ampliaron con sus subsecciones. El índice general es §0.0 (no se duplicó otro antes de la Parte 0); el encabezado de la guía remite a él.
- **Anexo D: 66 entradas con `[sin título registrado: …]`** quedaron publicadas así (de 175).
- **Presupuesto de extensión** (regla de conteo del plan, medida sobre la guía ensamblada): Parte 0 1.860 (tope 1.400, +33 %), I 3.500, II 5.016, III 5.560, IV 7.507, V 6.813 (tope 6.500, +4,8 %), VI 4.498, Cierre 2.960, Anexos 12.277 (tope 7.430, +65 %: A 2.291, B 1.508, C 1.868, D 3.396, E 1.751, F 387 sin tablas, G 1.043), más 115 del encabezado; total 50.106 (tope 44.330, +13 %). Parte 0 y Anexos pasan el disparador del 15 %: lo decide la relectura integral; el ensamblado no recortó.
- **Verificación mecánica del ensamblado** (script en el scratchpad de la sesión, no en el repo): anclas internas, REF citados contra el Anexo D en los dos sentidos (175 y 175), encabezados y anclas sin duplicados, bloques de código balanceados, 93 rutas a `Examples/` o `Demos/` existentes, compuerta de familias de ID internas y búsqueda de datos privados: todo en cero. Los 23 bloques mermaid se renderizaron sin error con mermaid-cli (mermaid 12.0.0) en un contenedor efímero sin red; la versión que usa GitHub puede ser otra, y eso no se comprobó.
