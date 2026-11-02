---
doc_id: BIT-16-C1-INF-implementador-desarrollador
titulo: Informe del implementador ingenuo / desarrollador de código — ciclo 1
ciclo: 1
especialista: implementador ingenuo fundido con desarrollador de código (REED-16 §8.1, §8.2)
fecha: 2026-10-28
maquina: <equipo-de-contingencia>
estado: entregado a ciegas (no se leyeron otros informes del ciclo)
evidencia: evidencia-implementador-desarrollador/
---

# Informe del implementador ingenuo / desarrollador de código (ciclo 1)

## Índice

1. [Mandato y cómo trabajé](#1-mandato-y-cómo-trabajé)
2. [Lo que compilé y corrí](#2-lo-que-compilé-y-corrí)
3. [Hallazgos](#3-hallazgos)
4. [Lo que revisé y está bien](#4-lo-que-revisé-y-está-bien)
5. [Posición sobre los MI de mi mandato](#5-posición-sobre-los-mi-de-mi-mandato)
6. [Solicitudes de convocatoria](#6-solicitudes-de-convocatoria)

## 1. Mandato y cómo trabajé

Me puse en el lugar de alguien con una estación Linux con Docker, sin SDK instalado y sin experiencia previa en IA (REED-16 §8.2). Las preguntas fueron dos: si con lo planeado (ejemplos 01–11 y la demo) puedo reproducir todo sin preguntar, y si los snippets de los borradores compilan. El diseño no lo juzgo. Lo que cae fuera de mi mandato va en §6.

Objeto leído: `04-Integracion.md` (§0–§8, MI-01…MI-24), N6 completo (snippets §4, Anexos A y B, notas del 2026-10-28), y los pasajes de REED-16 §1.3, §5, §8, §9.1 y §11 que fijan qué tiene que poder reproducir el lector. De N2, N3, N4 y N5 leí sólo lo que hacía falta para ubicar snippets y sondas.

Todas las compilaciones corrieron en `mcr.microsoft.com/dotnet/sdk:10.0` (SDK 10.0.403), como lo haría el lector, por el recurso `build`. Las corridas contra el modelo fueron por el recurso `modelo-compartido` contra el Ollama propio en contenedor (<equipo-de-contingencia>), con el endpoint sólo en `OLLAMA_ENDPOINT` y borrado de la salida (R-PRIV). Los intermedios quedaron en `$TRABAJO/implementador/`. Las fuentes de las sondas y las salidas están en [`evidencia-implementador-desarrollador/`](evidencia-implementador-desarrollador/).

## 2. Lo que compilé y corrí

| # | Qué | Origen | Resultado | Archivo |
|---|---|---|---|---|
| K1 | Snippets N6 §4.1, §4.2, §4.3 y §4.4 **pegados literal**, contra la copia de `Domain/` y `Application/` de ApiWeb en `59399ba`, sin `NoWarn` | N6 §4 | `0 Error(s)`, `0 Warning(s)`. Tuve que agregar 11 `using` que los snippets no traen (ver IMPLEM-04) | `snippetsN6/`, `build-1.txt` |
| K2 | Sonda B de la integración (E-B1…E-B5), tal cual está en la bitácora | `Integracion-Evidencia/B-…/sonda/` | `0 Error(s)`, `0 Warning(s)` | `build-1.txt` |
| K3 | Sonda X1 (OTel `sourceName` y ciclo de vida T1), compilada **y corrida** | `Integracion-Evidencia/C-…/X1-*` | Compila sin advertencias. La salida reproduce X1: 0 spans con nombres distintos y 1 con nombres iguales; con Singleton, `InvalidOperationException`; con Scoped, `SessionId=sesion-A/B` | `run-1.txt` |
| K4 | Experimento A (`ExpCapas`), modo `fake`, con la copia regenerada según su README | `Integracion-Evidencia/A-…/exp-capas/` | Compila y corre: 12 enunciados y las vías A, B y C como en EA-5 | `build-1.txt`, `run-1.txt` |
| K5 | `compilecheck` de N4 (E02) | `Nucleos/N4-Evidencia/compilecheck/` | `0 Error(s)`, `0 Warning(s)` | `build-2.txt` |
| K6 | `V1-snippets-compilados.cs` de N3 con `V1-Snip.csproj` | `Nucleos/N3-Evidencia/` | Así como está: CS5001 (el `.csproj` dice `Exe` y el archivo no tiene `Main`). Con el `Program` de ejecución al lado: CS0101. Compila sólo si se cambia a `Library`, y entonces da 0 errores pero 4 advertencias NU1902/NU1903 (`System.Security.Cryptography.Pkcs` 9.0.11, transitivo de EF Core SqlServer 10.0.14 → SqlClient 6.1.7) | `build-2.txt`…`build-4.txt` |
| K7 | Sonda negativa: la reparación de N6 §4.3 («dimensión tomada de configuración») hecha como la haría un lector ingenuo, pasándole al atributo un valor de configuración | N6, nota del 2026-10-28 | `error CS0182: An attribute argument must be a constant expression` | `dimconfig/`, `run-1.txt` |
| K8 | Cómo llega `num_ctx` desde `IChatClient` y qué devuelve `Usage`, con HTTP falso | M10, MI-18 | OllamaSharp 5.5.0 traduce `ChatOptions.AdditionalProperties["num_ctx"]` a `"options":{"num_ctx":8192}`, igual que `RawRepresentationFactory → ChatRequest.Options.NumCtx`; `Reasoning.Effort = None` → `"think":false`; `Usage.InputTokenCount` = `prompt_eval_count` | `numctx/`, `run-1.txt` |
| K9 | Lo mismo contra el modelo. R-LLM: `qwen2.5:0.5b` (`a8b0c5157701`), Ollama 0.40.11, T 0, Seed 1, MaxOutputTokens 16, N = 1 por condición. Criterio escrito antes: sin `num_ctx`, `InputTokenCount` < 2100; con 8192, > 2900 | M10, MI-18 | **Corrida 1** (300 líneas, 22 161 caracteres): 2050 sin `num_ctx`, 4098 con 8192, las dos con `FinishReason=stop`, las dos respuestas equivocadas («3229», «3156»; la esperada era 3001). El criterio no se cumplió porque el prompt era más largo de lo que estimé (truncó también con 8192, como en X3). **Corrida 2** (100 líneas, 7361 caracteres): 2741 en las dos condiciones, **incluida la que no fija `num_ctx`**. `api/ps` mostró después `context_length= 8192`: el modelo seguía cargado con el contexto que había pedido la corrida anterior | `numctxreal/`, `numctx-real*.txt`, `api-ps.txt` |
| K10 | ¿Llega un contenedor del SDK a `localhost` del anfitrión? Simulación con un servicio en `127.0.0.1:18080` del anfitrión | REED-16 §1.3, N6 Anexo B | Desde el anfitrión responde. Desde el contenedor con la red por defecto: `rc=7`, sin respuesta. Con `--network host`, responde | `localhost-simulacion.txt` |

Versiones consultadas el 2026-10-28T09:44-03:00 en `https://api.nuget.org/v3-flatcontainer/<id>/index.json`: MEAI 10.11.0, OllamaSharp 5.5.0, Microsoft.Agents.AI y .Workflows 1.26.0, InMemory 1.0.1 y ModelContextProtocol.AspNetCore 2.3.0 son las últimas, como dice X0. NUnit va por la 5.0.0 (publicada el 2026-09-27T14:58Z según `registration5-semver1/nunit/5.0.0.json`); el caso base usa 4.3.2 en sus 7 proyectos de test. Imagen `ollama/ollama:0.40.11`: existe en Docker Hub (`hub.docker.com/v2/repositories/ollama/ollama/tags/0.40.11`, 2026-10-24) con el digest `sha256:dea72d1e2227…`, el mismo que corre en <equipo-de-contingencia>. Avisos GHSA-2fmv-rv2c-59x7 y GHSA-846f-f764-76mx: publicados el 2026-10-13 (`api.github.com/advisories/<id>`).

## 3. Hallazgos

### IMPLEM-01 — No hay receta para que el lector levante el Ollama y lo alcance desde el contenedor

- **Ubicación:** `04-Integracion.md` §8 (fila «E Laboratorio y demo», l. 380, y el párrafo de `Examples/`, l. 383); N6 Anexo B (l. 482, «`OLLAMA_ENDPOINT` (por defecto `http://localhost:11434`)»); N6 Anexo A (`README.md`); REED-16 §1.3 y §8.2.
- **Capa de origen:** pedido (REED-16 §1.3 fija `localhost:11434` por defecto pensando en el anfitrión, mientras §8.2 y §9.1 ponen al lector en un contenedor) e integración (§8 no le da contenido al Anexo E).
- **Severidad:** S2 («ejemplo que el implementador no puede reproducir sin preguntar», REED-16 §5.2).
- **Evidencia:** E1 + E2. E2: el Anexo E de la estructura sólo promete «Registros R-LLM de `Examples/` y de `ConModelo/`». En ningún lugar del objeto está cómo levanta el lector su propio Ollama: qué imagen y versión, qué `ollama pull`, qué digest comparar, cuánto disco y RAM hacen falta (3,32 GB del 4b, Sondeo §R.1), qué latencia esperar (13–58 s por llamada, X2) ni qué hacer si `OLLAMA_MODEL` no está definida. Además, 04 §2 tensión 4 dice «ningún modelo literal en el código», pero las sondas de las que se va a copiar traen `?? "qwen3.5:4b"` (`exp-capas/Experimento/Program.cs` l. 52, `sonda/Program.cs` l. 18). E1 (K10): desde `mcr.microsoft.com/dotnet/sdk:10.0` con la red por defecto, `localhost` es el propio contenedor. El valor por defecto que prometen el Anexo B y M10 **no llega** al Ollama del anfitrión, y lo mismo le pasa a la demo ASP.NET si escucha en `localhost` dentro del contenedor. Mis propias corridas necesitaron `--network host` (`runnet.sh`).
- **Impacto si no se corrige:** el lector de §8.2 corre el ejemplo 01, recibe un error de conexión y tiene que preguntar o adivinar la red de Docker. Con la demo le pasa dos veces: hacia Ollama y hacia el navegador.
- **Propuesta de dirección:** que el Anexo E (o un `Examples/README.md` común) traiga una receta única y probada: una red de Docker; `ollama/ollama:0.40.11` (con el digest) y un volumen; `ollama pull` de los tres modelos con verificación de digest por `/api/tags`; el `docker run` del SDK con `--network <red> -e OLLAMA_ENDPOINT=http://ollama:11434` (o `--network host`, declarando la diferencia), `-u`, `HOME` y la caché NuGet; para la demo, `ASPNETCORE_URLS=http://0.0.0.0:<p>` y `-p`. Suma una tabla de requisitos (disco, RAM, latencia por llamada, `HttpClient.Timeout`) y el comportamiento definido cuando falta una variable (fallar con un mensaje, o un valor en `appsettings`, pero uno solo). La compuerta E1 de §9.1 debería correr la receta en limpio, no contra el Ollama ya armado de <equipo-de-contingencia>.

### IMPLEM-02 — M10 y MI-18 piden `num_ctx` y `prompt_eval_count` desde .NET, pero ningún borrador muestra cómo

- **Ubicación:** `04-Integracion.md` §3.2 R-C08 (l. 111), §5 MI-18, §6.3 M10; N3b §6 criterio 8; ningún snippet .NET de los núcleos.
- **Capa de origen:** integración.
- **Severidad:** S2.
- **Evidencia:** E1 + E2. E2: `grep -rn "NumCtx\|num_ctx" --include=*.cs` sobre toda la bitácora devuelve 0 resultados. Todas las menciones están en prosa o en scripts HTTP/Python (X3, X4b). E1 (K8): la vía existe y es corta. `ChatOptions.AdditionalProperties["num_ctx"]` llega como `options.num_ctx` por OllamaSharp 5.5.0, y `ChatResponse.Usage.InputTokenCount` es el `prompt_eval_count`. E1 (K9, R-LLM, N = 1): con un prompt mayor que la ventana trunca en silencio en las dos condiciones (2050 y 4098, `FinishReason=stop`, respuestas equivocadas). Sin `num_ctx`, el resultado **depende del estado del servidor**: tras una petición con 8192, la siguiente sin `num_ctx` no truncó (2741) porque el modelo seguía cargado con 8192 (`api/ps`). O sea, «2050 sin `num_ctx`» (X3) no es un dato que el lector vaya a reproducir siempre. Por la vía `OpenAICompatible` (`/v1`) no verifiqué si hay forma de pasar `num_ctx`.
- **Impacto si no se corrige:** el lector no puede cumplir M10 ni MI-18 sin investigar por su cuenta. Si copia un ejemplo sin esa pieza, recibe respuestas truncadas con HTTP 200 que cambian según quién usó el servidor antes.
- **Propuesta de dirección:** que §4 o §5 de la guía y el ejemplo 04/05 (o el 01) traigan el snippet compilado. Fijar `num_ctx` por configuración en `ChatOptions` y comparar `Usage.InputTokenCount` con el largo esperado, tratando la diferencia como error. Hay que declarar que sin `num_ctx` el comportamiento depende del servidor y aclarar qué pasa con el selector `OpenAICompatible`: P-08 o un pendiente nuevo, sin afirmar nada que no se haya medido.

### IMPLEM-03 — La reparación de N6 §4.3 («dimensión de configuración») no se puede hacer con el atributo del snippet

- **Ubicación:** N6 §4.3 (l. 261, `[VectorStoreVector(384)]`) y su nota «Reparación de integración» (l. 599); `04-Integracion.md` R-C12 y MI-17.
- **Capa de origen:** núcleo (N6), y la reparación de integración la arrastra.
- **Severidad:** S3. Pasa a S2 si la guía conserva el atributo y a la vez pide «dimensión por configuración».
- **Evidencia:** E1. El snippet literal compila (K1), pero con la dimensión fija en 384. La lectura ingenua de la reparación, que es poner en el atributo un valor leído de configuración, da `error CS0182` (K7). La forma que sí funciona ya está en la bitácora: `VectorStoreCollectionDefinition` con `new VectorStoreVectorProperty("Vector", typeof(ReadOnlyMemory<float>), dimensions: Dimension)` (`Integracion-Evidencia/A-arquitectura/exp-capas/Nuevo/Infrastructure/AI/BuscadorDeRequisitos.cs` l. 20), con la dimensión tomada del primer embedding.
- **Impacto si no se corrige:** quien siga la reparación se queda sin compilar, o deja el 384 y falla al cargar con `qwen3-embedding:0.6b` (1024).
- **Propuesta de dirección:** que el snippet de §4.3 (y el ejemplo 05) use la definición por código. La dimensión sale de configuración o del embedding de prueba del arranque (MI-17), y la guía explica en una línea por qué el atributo no sirve para eso.

### IMPLEM-04 — Los snippets no traen `using` ni el espacio de nombres de los tipos del caso base

- **Ubicación:** N6 §4.1–§4.6; el mismo patrón se repite en N1, N2 y N4 según el recuento de bloques (`grep -c '^```csharp'`: 7, 7 y 11).
- **Capa de origen:** núcleo.
- **Severidad:** S3.
- **Evidencia:** E1 (K1). Para que §4.1–§4.4 compilaran tuve que agregar 11 `using`. Hay tres que el lector sin experiencia no puede adivinar: `CommunityToolkit.VectorData.InMemory` (no `Microsoft.SemanticKernel.Connectors.InMemory`, que era la ubicación anterior de `InMemoryVectorStore`), `MovilidadUrbana.ApiWeb.Application` (por `Result`) y `MovilidadUrbana.ApiWeb.Domain` (por `Catalogos`). Además, §4.3 deja libres `embeddings` y `contexto`, y §4.1 deja libres `innerClient` y `herramientas`, sin decir de dónde salen.
- **Impacto si no se corrige:** cada snippet copiado arranca con errores CS0246, y el lector depende del autocompletado del IDE o tiene que preguntar.
- **Propuesta de dirección:** que cada snippet de la guía traiga sus `using` (o una línea «compila en `Examples/NN/archivo.cs`» con ruta relativa) y declare las variables libres con su tipo. La compuerta de §9.1 («versiones de los `PackageReference` iguales a las que cita la guía») podría extenderse a «cada snippet tiene su archivo compilado en `Examples/`».

### IMPLEM-05 — La lista de ejemplos no está reconciliada con la integración ni con REED-16 §11

- **Ubicación:** N6 Anexo B (l. 482–498); `04-Integracion.md` §8 (l. 383); REED-16 §11 (l. 424).
- **Capa de origen:** integración.
- **Severidad:** S3.
- **Evidencia:** E2 + E4.
  - (a) **Nombres.** REED-16 §11 dice `Examples/<NN>-<núcleo>-<tema>/`; el Anexo B usa `Examples/NN-Nombre/` (`01-Chat-Basico`).
  - (b) **Tipo de proyecto.** El Anexo B dice «cada uno es una consola net10.0 … con un modo `--fake`», pero el 08 es un servidor ASP.NET con su cliente y el 09 es un proyecto NUnit. Las sondas de las que se va a partir usan un argumento posicional (`fake`/`real`, `exp-capas/Experimento/Program.cs` l. 8), no `--fake`.
  - (c) **Piezas sin lugar en la lista.** Lo que la integración agregó no tiene ejemplo asignado: la prueba de arquitectura (MI-04), la búsqueda de requisitos por significado de ESC-02 (MI-08), la validación de dimensión (MI-17), la comprobación de `num_ctx` (MI-18) y el generador del corpus sintético que se perdió (P-07).
  - (d) **Versiones.** «NUnit 4.x» sin fijar. NuGet ya publica NUnit 5.0.0 (2026-09-27) y el caso base usa 4.3.2.
  - (e) **Cantidad.** El despacho habla de «ejemplos 01–11», pero 10 y 11 son opcionales y el 11 depende de MI-19.
- **Impacto si no se corrige:** el redactor y el lector no tienen una tabla única de qué carpeta existe, qué tipo de proyecto es, cómo se corre y con qué versión. La compuerta C4 (sin huérfanos) no tiene contra qué compararse.
- **Propuesta de dirección:** una tabla canónica de `Examples/` (en 04 o en el Anexo E): carpeta según REED-16 §11 (o el desvío declarado), tipo de proyecto, comando de contenedor, paquetes con versión exacta (NUnit 4.3.2 como el caso base, o el cambio declarado), convención de modo falso, y dónde vive cada pieza que agregó la integración.

### IMPLEM-06 — Algunas sondas de la bitácora no se reproducen tal como están

- **Ubicación:** `Integracion-Evidencia/A-arquitectura/exp-capas/verificar-capas.sh` l. 9; `Nucleos/N3-Evidencia/V1-Snip.csproj`; `Integracion-Evidencia/B-abstracciones-agentes/sonda/Program.cs` l. 19; `04-Integracion.md` §3.3 I-1 y §7 P-14.
- **Capa de origen:** núcleo (N3) e integración (A y B).
- **Severidad:** S3.
- **Evidencia:** E1 + E2.
  - `verificar-capas.sh` trae `SRC=` con una ruta absoluta del home del laboratorio. En otra máquina el `diff -r` falla, y en un repo público además choca con `Reanudar.md` §5.
  - `V1-Snip.csproj` declara `Exe`, pero `V1-snippets-compilados.cs` sólo compila como biblioteca: CS5001 tal como está y CS0101 con el `Program` de ejecución al lado (K6). N3 V3 lo dice en prosa («como biblioteca»), no en el proyecto.
  - La sonda B lee `OLLAMA_EMBED_MODEL`, mientras I-1 fija `OLLAMA_EMBEDDING_MODEL` «porque es la que usa el código ejecutado». Quien reproduzca E-B4/E-B5 con la variable canónica obtiene en silencio el valor por defecto.
- **Impacto si no se corrige:** P-14 dice que «la sonda B ya cubre las piezas centrales», así que el redactor va a copiar de estas sondas y con ellas se lleva la ruta absoluta, el tipo de proyecto equivocado y la variable vieja.
- **Propuesta de dirección:** que antes de copiar a `Examples/` se normalicen. Ruta del caso base por parámetro o relativa; `OutputType` acorde (o un `Program` propio); variables con los nombres de I-1. Que la compuerta E1 sea «clon limpio en otra carpeta + comando del README», no «compila en la carpeta de trabajo».

## 4. Lo que revisé y está bien

1. **Las versiones fijadas compilan juntas y siguen siendo las últimas.** MEAI 10.11.0, OllamaSharp 5.5.0, MAF 1.26.0 (con Workflows y Generators), MEVD 10.11.0, InMemory 1.0.1, ModelContextProtocol 2.3.0 y OpenTelemetry 1.20.1 compilaron sin advertencias en el SDK 10.0.403 en cinco proyectos distintos (K1–K5). NuGet las da como últimas al 2026-10-28T09:44-03:00. Los snippets de N6 §4.1–§4.4 compilan literal contra la copia real del caso base sin `NoWarn`, lo que confirma lo que N6 E5 afirmaba.
2. **Las sondas de la integración se reproducen fuera de su carpeta original.** X1 dio exactamente la salida registrada (OTel 0/1 spans; Singleton → excepción, Scoped → la sesión correcta), y el experimento A en modo `fake` dio los 12 enunciados y las tres vías, regenerando la copia como indica su README. Para el lector, eso hace de M6, M8 y MI-15 controles enseñables con un caso que falla y uno que pasa.
3. **El camino feliz de configuración está bien pensado para alguien sin experiencia en IA.** Un solo juego de variables (`OLLAMA_ENDPOINT`, `OLLAMA_MODEL`, `OLLAMA_EMBEDDING_MODEL`, `AI:Proveedor`), razonamiento apagado por `ChatOptions.Reasoning` (verificado en K8: `"think":false`), el 0.5b sólo como humo y dos suites (`Cableado/` sin modelo y `ConModelo/` por turno). Con eso, el lector puede compilar y probar todo sin modelo antes de tocar Ollama.

## 5. Posición sobre los MI de mi mandato

| MI | Posición | Fundamento |
|---|---|---|
| MI-02 | propuesta | Para reproducir, el 4b es lo mínimo que hace tool calling (E-B1: 0/5 con el 0.5b) y entra en una estación sin GPU (3,32 GB). El modelo mayor en <estación-2> no lo puede reproducir un lector con hardware común. Condición: IMPLEM-01 (pull con digest y latencias esperadas). |
| MI-04 | propuesta | Que la prueba sea un test NUnit dentro de la suite `Cableado/` y no el `grep` con ruta absoluta (IMPLEM-06): así corre con `dotnet test` en cualquier clon. |
| MI-09 | propuesta | Un diff mínimo 4.1 → 4.2 sobre el mismo `IChatClient` es lo más fácil de seguir para el lector, y las piezas compilan (K1, K2, K5). |
| MI-10 | propuesta | Sólo en lo que me toca: el consumo de LangGraph necesita Python y la CLI, fuera de «Linux con Docker sin SDK». Acepto la regla «sólo si se levanta, si no snippet rotulado no ejecutado», siempre que el snippet no ejecutado no quede en `Examples/` como si corriera, y que si se levanta sea con una imagen y una versión fijas. |
| MI-12 | propuesta | Reproducir un preview exige cadenas como `10.11.0-preview.1.26513.7` que cambian semana a semana. Con GA por defecto, el lector restaura sin `--prerelease` y la compuerta de versiones es estable. |
| MI-13 | propuesta | La demo con el selector y su prueba de cableado son la única evidencia ejecutable de que «Application no cambia». Condición: `OllamaSharp` por defecto y el cambio en una sola variable documentada (`AI__Proveedor`). Queda abierto `num_ctx` por `/v1` (IMPLEM-02). |
| MI-17 | propuesta | La validación al arrancar es lo que convierte un 384/1024 equivocado en un error claro. Requiere la definición por código (IMPLEM-03), porque el atributo no admite configuración (K7, CS0182). |
| MI-18 | propuesta | Fijar `num_ctx` no alcanza: con un prompt más grande que la ventana el truncado sigue siendo silencioso (K9: 4098 con 8192, `FinishReason=stop`), y sin fijarlo el resultado depende del estado del servidor (K9 corrida 2 y `api/ps`). La comparación es implementable con `Usage.InputTokenCount` (K8). Falta el snippet (IMPLEM-02). |
| MI-22 | propuesta | Que haya dueños explícitos le asegura al lector que cada corrida contra el modelo tenga su registro R-LLM en el Anexo E. Pido que el dueño de P-14 (snippets reilustrados y compilados) entregue también el archivo compilable de cada snippet (IMPLEM-04). |

Los demás MI (01, 03, 05–08, 11, 14–16, 19–21, 23, 24) son de diseño, de dominio o de seguridad y caen fuera de mi mandato. Me abstengo.

## 6. Solicitudes de convocatoria

- **Senior .NET o AH-01 (seguridad de lo copiable):** los snippets de N3 que usan `Microsoft.EntityFrameworkCore.SqlServer` 10.0.14 arrastran `System.Security.Cryptography.Pkcs` 9.0.11 con dos avisos (GHSA-2fmv-rv2c-59x7, moderado; GHSA-846f-f764-76mx, alto; publicados el 2026-10-13) y producen NU1902/NU1903 al compilar (K6). Hay que decidir si la guía muestra ese proveedor, con qué versión, y si la compuerta de compilación exige cero advertencias NU19xx.
- **Experto en IA:** la dependencia del estado del servidor que vi en K9 (sin `num_ctx`, el modelo sigue cargado con el contexto que pidió la petición anterior) es un comportamiento de Ollama 0.40.11 que no caractericé con N suficiente. Si la guía va a explicarlo, hace falta una medición propia con R-LLM.
- **Verificación/QA:** la compuerta E1 de REED-16 §9.1 se corre en <equipo-de-contingencia>, con el Ollama ya armado y la red alcanzable. Propongo sumar una corrida en limpio (otro directorio, sin caché NuGet, con el Ollama levantado por la receta del Anexo E) para cubrir IMPLEM-01 e IMPLEM-06.
