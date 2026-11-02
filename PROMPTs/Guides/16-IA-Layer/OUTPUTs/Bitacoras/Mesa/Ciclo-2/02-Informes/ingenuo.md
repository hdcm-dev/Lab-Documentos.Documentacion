---
doc_id: BIT-16-MESA-C2-INF-INGENUO
doc_type: informe-de-especialista
title: Informe del implementador ingenuo sobre el plan de integración v1
rol: Implementador ingenuo (núcleo permanente)
objeto: 04-Plan-De-Integracion.md (v1, estructura aprobada)
modo: a ciegas respecto de los demás informes del ciclo 2; leído el cierre y el informe propio del ciclo 1 para no repetir
fecha: 2026-10-26
---

# Implementador ingenuo: informe sobre el plan v1

Leí la v1 como si me tocara construir `Examples/` y la demo mañana. Cada hallazgo es una pregunta que tendría que hacer antes de escribir la primera línea. Contrasté las que tocan el caso base contra `Lab-E2E.WebBlazor` en `8fb4c3a` (`git show 8fb4c3a:<ruta>`, sólo lectura, DC-05). No repito lo que el ciclo 1 ya corrigió ni la deuda que el cierre ya declaró: la colisión «nivel A/B», las horas de §E.5 sin recalcular y el 140 frente a 144.

## Hallazgos

### H-01 · S2 · E1 · confianza 0,85. La demo junta dos hosts del caso base en uno y la tabla de delta no lo registra

- **Ubicación**: §F.2 (línea de base y tabla de delta), §F.5, §F.9, ADR-11 (§13.12).
- **Afirmación**: en `8fb4c3a`, `MovilidadUrbana.ApiWeb` y `MovilidadUrbana.Web` son dos proyectos con su `Program.cs` y su propia copia de `Domain/`, `Application/` e `Infrastructure/`, con espacios de nombres distintos. La v1 copia ApiWeb y «las piezas que se nombran» de Web: `SessionMiddleware`, `App.razor` y `Routes.razor`. Después las sirve en **un solo** servicio `demo` en el puerto 8080 (§F.9), con `SessionMiddleware` aplicado «fuera de `/api` y `/mcp`» (§F.5). Para hacer eso hay que fusionar los dos `Program.cs`, pasar el `.csproj` a componentes Razor y elegir una de las dos clases `SessionContext`. Además, `App.razor` y `Routes.razor` no compilan solos. La tabla de delta no tiene fila para ninguno de esos cambios. Como implementador no sé si la demo es un host o dos. Tampoco sé qué vale: ADR-11 dice que deja de valer «si la demo crece a más de un host».
- **Ancla**: `Routes.razor` en `8fb4c3a`: `@using MovilidadUrbana.Web.Infrastructure.Sessions`, `DefaultLayout="typeof(Layout.MainLayout)"`, `NotFoundPage="typeof(Pages.NotFound)"`; `App.razor`: `@inject MovilidadUrbana.Web.Infrastructure.Sessions.SessionContext Session`, `css/Tokens.css`, `css/Componentes.css`, `js/mq-dialogo.js`, `js/mq-foco.js`. ApiWeb `Program.cs`: `app.UseMiddleware<SessionHeaderMiddleware>();` global, sin `AddRazorComponents`. El `.csproj` de ApiWeb: «Es un proyecto independiente… no referencia a ningún otro proyecto de la solución». La tabla de §F.2 no tiene filas para `Program.cs`, `.csproj`, `MainLayout`, `Pages/NotFound`, `wwwroot/` ni `_Imports.razor`.
- **Impacto**: AC-10 (`git diff --stat base-8fb4c3a` contra la tabla) falla apenas se fusionan los hosts, o pasa porque nadie lo mira. Los dos constructores pueden armar topologías distintas.
- **Dirección**: decidir explícitamente si la demo es un host o dos. Si es uno, sumar a la tabla de delta la fusión de `Program.cs` y `.csproj`, el `SessionContext` elegido y el cierre mínimo de dependencias de `App.razor`/`Routes.razor`, y confirmar que ADR-11 sigue valiendo. Si son dos, decir cómo la página Blazor alcanza el `IChatClient` «asistente».

### H-02 · S2 · E1 · confianza 0,85. La copia literal de la línea de base no pasa AC-1 ni AC-6

- **Ubicación**: §F.2 (primer commit «base 8fb4c3a sin cambios»), §E.1 (tabla de versiones, «Sin `NoWarn`»), §F.10 AC-1 y AC-6.
- **Afirmación**: el `.csproj` de ApiWeb en `8fb4c3a` tiene `GenerateDocumentationFile` y `NoWarn` CS1591, y referencia `Microsoft.AspNetCore.OpenApi` y `Scalar.AspNetCore`. Hay tres choques. (a) AC-1 pide «sin `NoWarn`»: si se saca, `-warnaserror` convierte en error cada miembro público sin comentario XML. Si se deja, AC-1 no pasa. (b) Ninguno de los dos paquetes está en la tabla de §E.1 ni, por lo tanto, en el Anexo F. Así AC-6, «versiones resueltas = Anexo F», falla desde el primer commit. (c) AC-6 compara además **todas** las transitivas (`--include-transitive`) contra una tabla que lista unas veinte filas. No está definido qué universo se compara. EF Core Sqlite, por ejemplo, trae `SQLitePCLRaw.*`.
- **Ancla**: `git show 8fb4c3a:src/MovilidadUrbana.ApiWeb/MovilidadUrbana.ApiWeb.csproj`: `<GenerateDocumentationFile>true</GenerateDocumentationFile>`, `<NoWarn>$(NoWarn);CS1591</NoWarn>`, `Microsoft.AspNetCore.OpenApi` 10.0.11, `Scalar.AspNetCore` 2.17.3. Plan §E.1: «**Sin `NoWarn`** (H-023)». AC-6: «`dotnet list package --include-transitive` contra el Anexo F (comparación mecánica)».
- **Impacto**: el primer `tools/verificar.sh` sobre la línea de base falla, o el constructor improvisa una de tres salidas sin registro: documentar todo, sacar `GenerateDocumentationFile` o dejar `NoWarn`. Las tres tocan la tabla de delta.
- **Dirección**: fijar qué pasa con CS1591, con OpenApi y con Scalar en la demo (se quedan con versión en el Anexo F, o salen como delta «modificado por otro motivo»), y definir el universo de AC-6: directas más una lista cerrada de transitivas fijadas.

### H-03 · S2 · E1 · confianza 0,8. AC-3b exige M entradas por paso de la demo, pero ningún paso tiene M ni oráculo

- **Ubicación**: §F.10 AC-3b, §F.8 (`ConModelo/`), §F.1 (tabla de pasos), §E.5 nivel de turno A.
- **Afirmación**: AC-3b no deja cerrar si PD-1…PD-6 no tienen «al menos un registro R-LLM válido (**M entradas distintas**, … oráculo aplicado)». §F.8 manda a buscar los oráculos «en la fila de §E.2 **o en la del paso**». Pero la tabla de §F.1 trae una sola frase de ejemplo por paso y no tiene columna de M, de entradas ni de oráculo. El presupuesto de §E.5 cuenta para la demo «una corrida de humo por paso (6 × 2)», que da una entrada por paso. No sé qué entradas escribir para PD-1…PD-6, qué oráculo aplicar ni cuántas llamadas cuestan.
- **Ancla**: AC-3b: «Cada PD-1…PD-6 y cada ejemplo de nivel A de §E.5 tiene al menos un registro R-LLM válido (M entradas distintas, campos completos, sin `truncado_posible`, oráculo aplicado)». §F.8: «con oráculos y precondiciones declarados en la fila de §E.2 o en la del paso». §F.1: columnas «Paso | v0 | Escenario | Capacidad | Escalón | Qué muestra». §E.5: «la demo PD-1…PD-6, una corrida de humo por paso (6 × 2)».
- **Impacto**: o la demo no cierra nunca por AC-3b, o cada constructor inventa entradas y oráculos para los pasos, sin revisión, y el presupuesto de A queda corto.
- **Dirección**: dar a cada PD-n su conjunto de entradas (o remitir de forma explícita al de un ejemplo, como PD-1 → 08 y PD-2 → 07) con su oráculo, y alinear AC-3b y §E.5 con esa decisión: humo de una entrada, o M entradas.

### H-04 · S2 · E2 · confianza 0,75. Las variables canónicas no alcanzan para las reglas que dependen de ellas

- **Ubicación**: §E.1 (tabla de variables canónicas, viñeta `num_ctx`, esquema R-LLM), §E.2 fila 05, §F.6 (plan C), §F.9.
- **Afirmación**: hay cuatro reglas que no puedo programar con las seis variables de la tabla. (a) AJ-01: «con `servidor = compartido` y la variable sin venir del arnés, el código rechaza la corrida». El código no tiene de dónde sacar `servidor`, que tampoco es variable. Y una variable de entorno no lleva marca de «vino del arnés». (b) El ejemplo 05 corre el chat con `qwen2.5:0.5b` en el Ollama propio. Las variables de chat son `OLLAMA_ENDPOINT` y `OLLAMA_MODEL`, con default `qwen3.5:4b`, y no está dicho qué valores toman para 05 sin pisar los del resto. (c) El plan C de §F.6 («generador de hash estable») no tiene un interruptor en tiempo de ejecución: sólo existe `--fake` para los ejemplos, y la demo ingiere los `*Policy` «al arrancar». (d) `OLLAMA_EMBED_ENDPOINT` toma por default `OLLAMA_ENDPOINT`. En el laboratorio ese default apunta al servidor que responde 501, y no está dicho qué hace la demo si la ingesta del arranque recibe un 501.
- **Ancla**: §E.1: «con `servidor = compartido` y la variable sin venir del arnés, el código rechaza la corrida, y una prueba de cableado comprueba ese rechazo (R-04; AJ-01)». Tabla: `OLLAMA_EMBED_ENDPOINT` | «el valor de `OLLAMA_ENDPOINT`». §E.2 fila 05: «**Ollama propio** `ollama/ollama:0.40.11` con `qwen2.5:0.5b`». §F.6 plan C: «Generador de hash estable para el cableado; PD-2 se informa como no ejecutado». Sondeo §5: 501 sin modelo de embeddings.
- **Impacto**: la prueba de cableado de AJ-01 no se puede escribir de forma determinista. 05 puede terminar corriendo contra el servidor compartido (R-04). Y la demo puede caerse al arrancar en el camino (1) de §F.9 si falta `OLLAMA_EMBED_ENDPOINT`.
- **Dirección**: completar la tabla canónica con lo que esas reglas leen: el tipo de servidor, el origen de `num_ctx` (o un mecanismo para saberlo), el endpoint y el modelo de 05 y el modo de embeddings para el plan C. Fijar además la conducta de la demo ante un 501 al arrancar. Conviene revisarlo junto con la ratificación de AJ-01.

### H-05 · S3 · E2 · confianza 0,7. El presupuesto del ejemplo 15 no cuenta las llamadas del juez sobre el registro de 07

- **Ubicación**: §E.5 nivel de turno B («15 (10 de calibración)»), §E.2 fila 15.
- **Afirmación**: 15 evalúa con `RelevanceEvaluator` y `GroundednessEvaluator` «el registro R-LLM de 07 de la última corrida válida», que tiene 16 entradas, y además los 10 casos de calibración. Con dos evaluadores, eso son unas 2 × (16 + 10) = 52 llamadas al juez, y cada una lleva el contexto recuperado y la respuesta. El presupuesto cuenta 10. No sé si cada evaluador corre una vez por caso ni si la caché de reporte ahorra la primera corrida (no la ahorra).
- **Ancla**: §E.2 fila 15: «**Entrada fija**: el registro R-LLM de 07 … más los 10 casos de calibración»; «después `RelevanceEvaluator` y `GroundednessEvaluator` con juez local». §E.2 fila 07: «Las 16 preguntas de `conjunto-de-oro.v1.json`». §E.5: «15 (10 de calibración)».
- **Impacto**: el nivel B subestima 15 en unas 40 llamadas, y las de 15 son de las que más tokens de entrada llevan. La línea de corte decide sobre una cifra equivocada.
- **Dirección**: contar en §E.5 las llamadas reales de 15 (evaluadores × casos), o acotar qué parte del registro de 07 se evalúa con el juez.

### H-06 · S3 · E1 · confianza 0,7. Los espacios de nombres de la prueba de arquitectura y del `diff` de `_Comun` no salen de la copia literal

- **Ubicación**: §F.3 (prueba de arquitectura), §E.1 (regla `_Comun` ↔ demo), §F.2 (línea de base).
- **Afirmación**: la prueba de arquitectura recorre «ningún tipo de `MovilidadUrbana.Asistente.Domain.*`». Pero la línea de base es una copia literal, y en `8fb4c3a` el espacio de nombres es `MovilidadUrbana.ApiWeb.Domain`. Para que exista `MovilidadUrbana.Asistente.Domain` hay que renombrar todos los archivos, y ese cambio no está en la tabla de delta. Si no se renombra, la prueba recorre un espacio de nombres vacío y pasa siempre. Algo parecido pasa con la regla «`diff -r` vacío salvo los namespaces» entre `_Comun` y la demo: no es un comando, porque `diff -r` no ignora los espacios de nombres. Y el `Domain/` de la demo lleva además cabeceras `// Procedencia` y `// Delta`.
- **Ancla**: `git show 8fb4c3a:src/MovilidadUrbana.ApiWeb/Domain/Catalogos.cs`: `namespace MovilidadUrbana.ApiWeb.Domain;`. §F.3: «ningún tipo de `MovilidadUrbana.Asistente.Domain.*` referencia ensamblados…». §E.1: «`diff -r` vacío salvo los namespaces».
- **Impacto**: AC-5 puede pasar en vacío, que es el peor caso para una prueba que reemplaza al compilador (ADR-11). Además, la igualdad entre `_Comun` y la demo no se verifica de forma mecánica.
- **Dirección**: fijar el espacio de nombres de la demo (renombrar, como delta declarado, o conservar el del caso base) y escribir la prueba sobre ese. Hacer que la prueba falle si no encuentra ningún tipo. Dar la comparación entre `_Comun` y la demo como un comando que normalice los espacios de nombres y las cabeceras.

### H-07 · S4 · E1 · confianza 0,9. Restos editoriales que confunden al que construye

- **Ubicación**: §A.3 (párrafos «Lector principal» y «Lectores»), §H (registro de cambios), §F.10 AC-3a.
- **Afirmación**: (a) §A.3 tiene dos párrafos seguidos que definen a los lectores. El segundo remite a «(§2.3)» sin decir si es la §2.3 de la guía o la de este plan, que no existe. (b) El encabezado del plan dice «parches PAR-01…PAR-24». La fila v1 de §H dice «PAR-01…PAR-23». El cierre registra 24 parches aplicados. (c) AC-3a se rotula «(CI)», y §E.1 dice que no hay CI y que no se agrega ningún workflow.
- **Ancla**: línea 95, «**Lector principal**: …», y línea 97, «**Lectores**: el principal es ACT-DEV en su faceta *AI Engineer* (§2.3)»; línea 16, «parches PAR-01…PAR-24»; §H v1, «parches PAR-01…PAR-23»; AC-3a, «`ConModelo/` verde… (CI)»; §E.1, «no hay CI del repo para esto … y **no se agrega un workflow**».
- **Impacto**: es menor, pero el rótulo «CI» puede llevar a alguien a crear el workflow que §E.1 descarta. Y la discrepancia en el número de parches pone en duda si el PAR-24 se aplicó.
- **Dirección**: dejar un solo párrafo de lectores con la remisión calificada, alinear el registro de cambios con 24 parches y cambiar «CI» por el nombre del arnés.

## Revisado y bien

1. **`LocalidadesController` saltea el servicio**, como dice §F.2, columna «modificado por otro motivo». Lo verifiqué en `8fb4c3a`: el constructor recibe `LocalidadService service` **y** `ILocalidadRepository repository`. El delta declarado tiene base real.
2. **El puente de sesión en Blazor de §F.5** coincide palabra por palabra con `Routes.razor` en `8fb4c3a` («Un circuito de Blazor Server no tiene acceso a la petición HTTP original, así que este parámetro es el puente…», con `OnParametersSet` → `Contexto.Set(SessionId)`). La pregunta H-06 del ciclo 1 quedó bien resuelta.
3. **La tabla de OA cuadra con §15**: 3 OA comunes + 9 de ACT-DEV + 4 de ACT-ARQ + 4 de ACT-OPS + 4 de ACT-SEC + 1 de SK = 25. Coincide con los «25 ítems» de §15 y con PR-14 de §D.

## Solicitudes de convocatoria

- **Operación y entrega**: H-01 y H-04 (un host o dos, compose, conducta de la demo al arrancar sin embeddings y variables de ejecución) son de su mandato más que del mío. El cierre del ciclo 1 ya recomendaba convocarlo.
- **Senior .NET**: decidir qué se hace con CS1591, OpenApi y Scalar y cuál es el universo de transitivas de AC-6 (H-02).
