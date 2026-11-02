# Ejemplo 04 — Embeddings y búsqueda del requisito por significado

Nivel: intermedio. Se usa en la **§6, «Estrategias de conocimiento: contexto fijo, CAG y RAG»** de la guía (pipeline
RAG: embeddings, almacén vectorial, dimensión validada al arrancar y métricas de recuperación). Es el único lugar de
la guía donde vive el escenario ESC-02 del caso Movilidad Urbana: **buscar el requisito por significado**.

## Qué demuestra

- **La mitad de recuperación de un RAG, sin generar.** Una persona pregunta «¿Cuántos números lleva el CP?» y la
  búsqueda devuelve el enunciado `LocalidadPolicy.RequisitoDelCodigoPostal` («4 dígitos.»), aunque no compartan
  palabras. Si el enunciado correcto no está entre los k primeros, ningún prompt lo arregla después.
- **El corpus son los doce enunciados reales** de `LocalidadPolicy` y `EncuestaPolicy` del caso base, leídos por
  reflexión (`Requisitos/CatalogoDeRequisitos.cs`); cada fragmento se indexa con su entidad y su campo
  («Localidad — código postal: 4 dígitos.»). Las cuatro clases copiadas y su procedencia están en
  `src/MovilidadUrbana.Busqueda/CasoBase/PROCEDENCIA.md`.
- **`IEmbeddingGenerator` con pipeline** (telemetría → caché → verificador de dimensión → OllamaSharp) y
  **`Microsoft.Extensions.VectorData` con el almacén en memoria** (`CommunityToolkit.VectorData.InMemory`, GA). La
  colección se define en tiempo de ejecución con `VectorStoreCollectionDefinition`: la dimensión sale de
  `OpcionesDeIA.DimensionDeEmbeddings`, no de un atributo.
- **Dimensión validada al arrancar.** Antes de crear la colección se genera un embedding de prueba; si su largo no es
  la dimensión declarada, la aplicación no arranca y el mensaje nombra el modelo y las dos dimensiones. Además, cada
  vector que vuelve del proveedor se verifica (invariante: largo = dimensión declarada). Vectores de dimensiones
  distintas no son comparables y ningún otro componente lo avisa.
- **Métricas de recuperación** sobre un oro versionado: hit@1, hit@3, recall@3, MRR@3 y abstención correcta, con sus
  definiciones en `Evaluacion/MetricasDeRecuperacion.cs`. El oro se genera desde código (`Evaluacion/GeneradorDeOro.cs`,
  con los relevantes nombrados por `nameof`) y lleva la versión del caso base; una prueba verifica que el archivo
  `oro/oro-requisitos.json` es exactamente la salida del generador.
- **Consulta con y sin instrucción.** La model card del modelo de embeddings por defecto indica instrucción sólo en la
  consulta (`Instruct: <tarea>\nQuery:<consulta>`), nunca en el documento, y redactada en inglés. El ejemplo corre el
  oro en los dos formatos y los compara pareados.
- **Modo sin modelo.** `AI:Modo=SinModelo` reemplaza al servidor por un generador léxico determinista (bolsa de palabras
  con hash). Corre el circuito completo sin servidor y sirve de línea de base: no entiende significado.

## Requisitos

- Docker con la imagen `mcr.microsoft.com/dotnet/sdk:10.0` (se compiló con el SDK 10.0.403).
- Para la parte con modelo: el servidor Ollama de prueba con `qwen3-embedding:0.6b`, alcanzado **sólo** por
  `OLLAMA_ENDPOINT` (por defecto `http://localhost:11434`). `OLLAMA_EMBEDDING_MODEL` cambia el modelo.

| Paquete | Versión |
|---|---|
| `Microsoft.Extensions.AI` | 10.11.0 |
| `OllamaSharp` | 5.5.0 |
| `Microsoft.Extensions.VectorData.Abstractions` | 10.11.0 |
| `CommunityToolkit.VectorData.InMemory` | 1.0.1 |
| `System.Numerics.Tensors` | 10.0.14 |
| `Microsoft.Extensions.Caching.Memory` | 10.0.14 |
| `Microsoft.Extensions.Hosting`, `.Http`, `.Options.DataAnnotations` | 10.0.14 |
| `NUnit` / `NUnit3TestAdapter` / `Microsoft.NET.Test.Sdk` (pruebas) | 5.0.0 / 6.3.1 / 18.11.0 |

## Comandos (desde esta carpeta)

**Compilar:**

```bash
docker run --rm -v "$PWD":/work -w /work mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet build 04-Embeddings-Y-Busqueda.slnx -c Release
```

**Pruebas de `Cableado/` (sin modelo, deterministas):**

```bash
docker run --rm -v "$PWD":/work -w /work mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet test 04-Embeddings-Y-Busqueda.slnx -c Release --filter TestCategory=Cableado
```

**La consola en modo sin modelo (no necesita servidor):**

```bash
docker run --rm -e DOTNET_ENVIRONMENT=Development -v "$PWD":/work -w /work mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet run --project src/MovilidadUrbana.Busqueda -c Release -- evaluar --AI:Modo=SinModelo
```

**La consola contra el servidor de prueba** (`OLLAMA_ENDPOINT` tiene que estar definida en tu shell; si el servidor
corre en tu máquina, agregá `--network host`):

```bash
docker run --rm -e OLLAMA_ENDPOINT -e DOTNET_ENVIRONMENT=Development \
  -v "$PWD":/work -w /work mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet run --project src/MovilidadUrbana.Busqueda -c Release -- buscar "¿Cuántos números lleva el CP?"
```

Otros comandos: `-- evaluar` (corre el oro con y sin instrucción), `-- similitud colectivo ómnibus` (coseno con
`TensorPrimitives`), `-- oro > oro/oro-requisitos.json` (regenera el oro). `-- buscar "x" --AI:DimensionDeEmbeddings=512`
muestra el arranque fallido por dimensión (código de salida 4). Sin `-e DOTNET_ENVIRONMENT=Development` falta
`TimeoutSegundos` y la consola sale con código 3 antes del primer pedido.

**Pruebas de `ConModelo/` (contra el servidor de prueba, por turno):**

```bash
docker run --rm -e OLLAMA_ENDPOINT -e RLLM_SALIDA=/work/salidas-con-modelo \
  -v "$PWD":/work -w /work mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet test 04-Embeddings-Y-Busqueda.slnx -c Release --filter TestCategory=ConModelo --logger "console;verbosity=normal"
```

Cada prueba escribe su registro R-LLM en `salidas-con-modelo/` (ignorada por git). Sin `OLLAMA_ENDPOINT`, las tres
quedan `Inconclusive` («ConModelo: no medido»; `dotnet test` las cuenta como omitidas): nunca en verde.

## Resultado esperado

- **`Cableado`: 13 de 13 en verde.**
  - Generador falso fijo con un eje por requisito: tres consultas respondibles y una no respondible reproducen las
    cuentas a mano: hit@1 = 1/3, hit@3 = 2/3, recall@3 = 0,5, MRR@3 = 0,5, abstención 1/1 con umbral 0,6
    (`MetricasAManoTests`).
  - Generador de 512 con dimensión declarada 1024 → `DimensionDeEmbeddingsException` y no arranca, sin ingerir nada;
    1024/1024 → arranca con los 12 requisitos; sin dimensión declarada adopta la del primer embedding (768); un vector
    de 512 a mitad de la ingesta también corta el arranque (`DimensionTests`).
  - El oro versionado es la salida de su generador; tiene 12 respondibles y 10 no respondibles de evaluación, y
    calibración separada (`OroYCatalogoTests`).
  - La segunda generación del mismo texto sale de la caché, sin llamar al generador (`CacheTests`).
  - Ningún endpoint, modelo ni timeout literal fuera de `OpcionesDeIA` y los appsettings (`LiteralesTests`).
  - Modo sin modelo: el oro corre completo y da la misma tabla dos veces (`SinModeloTests`).
- **`ConModelo`**: tres pruebas. Las tasas **se informan, no se aprueban**; sólo los invariantes pueden fallar.

## Resultado medido

> Medido en la estación de laboratorio (CPU de 4 núcleos sin GPU; contenedor limitado a 4 CPU / 5 GB; Ollama 0.40.11),
> 2026-10-28. `qwen3-embedding:0.6b@ac6da0dfba84`, `/api/embed` por OllamaSharp 5.5.0. Estimando: **la tarea** (la
> unidad es la consulta), K = 12 respondibles y 10 no respondibles redactadas antes de correr, m = 3 repeticiones por
> consulta y formato. Los embeddings no muestrean (no hay semilla ni temperatura): las 128 de 128 parejas de
> repeticiones dieron vectores idénticos, así que m no agrega información. Wilson 95 % sobre las consultas. Umbral de
> abstención calibrado con un conjunto aparte (5 + 5 consultas) y aplicado sin tocar a la evaluación.

| Formato | hit@1 | hit@3 | recall@3 | MRR@3 | abstención correcta | abstenciones indebidas |
|---|---|---|---|---|---|---|
| con instrucción (umbral 0,4756) | 11/12, [0,65; 0,99] | 11/12, [0,65; 0,99] | 0,917 | 0,917 | 4/10, [0,17; 0,69] | 4/12 |
| sin instrucción (umbral 0,4407) | 10/12, [0,55; 0,95] | 10/12, [0,55; 0,95] | 0,833 | 0,833 | 4/10, [0,17; 0,69] | 4/12 |
| generador léxico falso (modo sin modelo, sin instrucción; determinista, no es un modelo) | 5/12, [0,19; 0,68] | 7/12, [0,32; 0,81] | 0,542 | 0,486 | 4/10, [0,17; 0,69] | 6/12 |

Línea de azar con 12 enunciados y un relevante: hit@1 = 0,08 y hit@3 = 0,25.

Cómo se lee:

- **Con y sin instrucción: no separado con este N.** En la comparación pareada (mismas consultas, mismo digest) hubo
  un solo par discordante en hit@1 y en hit@3 (la consulta del CP, que sólo encuentra con instrucción) y un par en cada
  sentido en abstención. Para decir «difiere» harían falta al menos 6 pares discordantes en el mismo sentido.
- **El modelo no separa respondibles de no respondibles por similitud.** En los dos formatos la calibración **no fue
  separable** (la peor respondible quedó por debajo de la mejor no respondible), y con el umbral calibrado se abstuvo
  bien en 4 de 10 no respondibles y se abstuvo de más en 4 de 12 respondibles. La similitud siempre devuelve algo:
  «¿Si elimino una ciudad se pierden las encuestas?» trae «Una de las localidades cargadas en el ABM.» con 0,46,
  más que la respuesta correcta a «¿Cuántos números lleva el CP?» (0,37). La consola, por eso, trae los umbrales sin
  configurar y lo dice.
- **Un fallo con las dos variantes:** «¿Me preguntan cada cuánto viajo en colectivo?» no trae «Con qué asiduidad usa
  esos medios.» entre los tres primeros: «colectivo» la lleva hacia los medios de transporte.
- **Existencia** (n = 1 por par): coseno(«colectivo», «ómnibus») = 0,6082; («colectivo», «bicicleta») = 0,5962;
  («en avión», «Moto») = 0,7010; («en avión», «Tren») = 0,6371. Un sinónimo no queda necesariamente más cerca que
  otro medio, y «avión», que no está en el catálogo, queda cerca de todos.
- **Invariantes:** con 1024 declarada arrancó y midió 1024; con 512 declarada no arrancó, con el mensaje «El modelo
  de embeddings «qwen3-embedding:0.6b» devolvió vectores de 1024 dimensiones y el almacén declara 512…».
- No se informan paredes: el servidor de prueba atendía a la vez otros pedidos y las latencias no serían de este
  ejemplo solo.

## Archivos

| Archivo | Qué tiene |
|---|---|
| `src/MovilidadUrbana.Busqueda/Configuracion/OpcionesDeIA.cs` | modo, endpoint, modelo, dimensión (`null` = medir), timeout sin defecto, k, instrucción y umbrales |
| `src/MovilidadUrbana.Busqueda/Configuracion/ComposicionDeIA.cs` | variables de entorno → sección `AI`; pipeline del generador; almacén y arranque |
| `src/MovilidadUrbana.Busqueda/Busqueda/AlmacenDeRequisitos.cs` | prueba de dimensión, `VectorStoreCollectionDefinition`, ingesta, búsqueda, formato de la consulta |
| `src/MovilidadUrbana.Busqueda/Busqueda/VerificadorDeDimension.cs` | `DelegatingEmbeddingGenerator` que hace cumplir el invariante de largo |
| `src/MovilidadUrbana.Busqueda/Requisitos/CatalogoDeRequisitos.cs` | los doce enunciados por reflexión, con entidad y campo |
| `src/MovilidadUrbana.Busqueda/Evaluacion/` | oro y su generador, métricas, calibración y tabla |
| `src/MovilidadUrbana.Busqueda/SinModelo/GeneradorLexicoFalso.cs` | el generador del modo sin modelo |
| `oro/oro-requisitos.json` | oro versionado (salida de `-- oro`) |
| `tests/.../Cableado/`, `tests/.../ConModelo/` | pruebas sin modelo y contra el servidor de prueba |
