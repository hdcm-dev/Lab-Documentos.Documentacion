# N3 — Evidencia ejecutada (2026-10-25)

Todas las corridas se hicieron en contenedor `mcr.microsoft.com/dotnet/sdk:10.0` (SDK 10.0.400), con la caché de NuGet en un volumen Docker (`<contenedor-del-arnés>`) y los intermedios fuera del repositorio. El servidor Ollama de la LAN del laboratorio se nombra así, sin dirección; los modelos de embeddings corrieron en un contenedor `ollama/ollama:latest` local (Ollama 0.40.11) publicado sólo en loopback.

## E1 — Reflexión sobre conectores, OllamaSharp y DataIngestion + búsqueda determinista

Fuentes: `E1-N3Probe.csproj`, `E1-reflexion-y-busqueda-Program.cs`.

```text
$ docker run --rm -v <sonda>:/work -v <contenedor-del-arnés>:/root/.nuget -w /work mcr.microsoft.com/dotnet/sdk:10.0 bash -c "dotnet --version && dotnet run"
10.0.400
CommunityToolkit.VectorData.InMemory: InMemoryCollection`2 hybrid=False
CommunityToolkit.VectorData.SqliteVec: SqliteCollection`2 hybrid=False
CommunityToolkit.VectorData.Qdrant: QdrantCollection`2 hybrid=True
CommunityToolkit.VectorData.PgVector: PostgresCollection`2 hybrid=True
CommunityToolkit.VectorData.Redis: RedisHashSetCollection`2 hybrid=False
CommunityToolkit.VectorData.Redis: RedisJsonCollection`2 hybrid=False
CommunityToolkit.VectorData.SqlServer: SqlServerCollection`2 hybrid=True
CommunityToolkit.VectorData.AzureAISearch: AzureAISearchCollection`2 hybrid=True
OllamaApiClient is IEmbeddingGenerator<string,Embedding<float>>: True
OllamaApiClient is IChatClient: True
DataIngestion types: ClassificationEnricher, DocumentTokenChunker, EnricherOptions, HeaderChunker, ImageAlternativeTextEnricher, IngestionChunkerOptions, IngestionPipeline`1, IngestionPipelineOptions, IngestionResult, KeywordEnricher, SectionChunker, SemanticSimilarityChunker, SentimentEnricher, SummaryEnricher, VectorStoreWriter`1, VectorStoreWriterOptions
DataIngestion.Abstractions types: IngestionChunk`1, IngestionChunker`1, IngestionChunkProcessor`1, IngestionChunkWriter`1, IngestionDocument, IngestionDocumentElement, IngestionDocumentFooter, IngestionDocumentHeader, IngestionDocumentImage, IngestionDocumentParagraph, IngestionDocumentProcessor, IngestionDocumentReader, IngestionDocumentSection, IngestionDocumentTable
[InMemory] enc-1 (encuesta.md#paso2) score=0.3876
[InMemory] enc-2 (encuesta.md#paso3) score=0.7643
[SqliteVec] enc-1 (encuesta.md#paso2) score=0.3876
[SqliteVec] enc-2 (encuesta.md#paso3) score=0.7643
```

Lectura: con `DistanceFunction.CosineDistance` el `Score` es una **distancia** (menor = más parecido): el primer resultado tiene el score más bajo. El generador de E1 es un hash de palabras sin semántica (sólo prueba la API, no la calidad).

## E2 — El servidor Ollama de la LAN del laboratorio y los embeddings

```text
$ curl -s <servidor-lan>/api/version
{"version":"0.32.0-rc0"}
$ curl -s <servidor-lan>/api/tags   # modelos instalados (nombre, familia, parámetros)
gpt-oss:20b gptoss 20.9B
qwen3-coder:30b qwen3moe 30.5B
gemma4:e4b-it-qat gemma4 7.5B
qwen3.5:4b qwen35 4.7B
qwen2.5:14b-instruct qwen2 14.8B
qwen2.5:7b-instruct qwen2 7.6B
qwen2.5vl:7b qwen25vl 8.3B
qwen2.5-coder:3b-base qwen2 3.1B
qwen2.5-coder:14b qwen2 14.8B
qwen2.5-coder:7b qwen2 7.6B
$ curl -s <servidor-lan>/api/embed -d '{"model":"qwen2.5:7b-instruct","input":["alta de localidad","medio de transporte de la encuesta"]}'
qwen2.5:7b-instruct ERROR This server does not support embeddings. Start it with `--embeddings`
$ curl -s <servidor-lan>/api/embed -d '{"model":"qwen3.5:4b", ...}'
qwen3.5:4b ERROR This server does not support embeddings. Start it with `--embeddings`
```

Lectura: el servidor de la LAN **no tiene ningún modelo de embeddings instalado** y sus modelos de chat **rechazan** `/api/embed`. No se instaló nada en ese servidor (decisión del PO).

## E3 — RAG real: tres configuraciones de embeddings sobre un corpus del dominio

Fuentes: `E3-N3Rag.csproj`, `E3-rag-real-Program.cs`. Corpus: 12 enunciados redactados a partir de las reglas de Movilidad Urbana (ia-db 02, §2–§5). 8 preguntas en castellano coloquial con un fragmento «correcto» cada una. Búsqueda con `InMemoryVectorStore` + `SearchAsync(top: 5)`, coseno.

```text
$ ollama pull nomic-embed-text ; ollama pull qwen3-embedding:0.6b    # en el contenedor local
qwen3-embedding:0.6b       ac6da0dfba84    639 MB
nomic-embed-text:latest    0a109f422b47    274 MB
$ docker run --rm --network host -e OLLAMA_ENDPOINT=http://localhost:<puerto-del-contenedor-local> -e OLLAMA_CHAT_ENDPOINT=<servidor-lan> -e OLLAMA_CHAT_MODEL=qwen2.5:7b-instruct ... dotnet run
   miss [nomic-embed-text] '¿Se puede ir caminando como medio?' -> loc-hab,enc-min,enc-medios (gold rank 3)
nomic-embed-text: dims=768 recall@1=7/8 recall@3=8/8 MRR@5=0.917 t=13277ms
   miss [nomic-embed-text+prefijos] '¿Se puede ir caminando como medio?' -> loc-hab,enc-medios,enc-frec (gold rank 2)
nomic-embed-text +prefijos: dims=768 recall@1=7/8 recall@3=8/8 MRR@5=0.938 t=9711ms
qwen3-embedding:0.6b: dims=1024 recall@1=8/8 recall@3=8/8 MRR@5=1.000 t=39014ms
CONTEXTO:
[reglas/encuesta#distancia] La distancia recorrida por día va de 0 a 500 km; cero es válido porque se puede no viajar.
[reglas/encuesta#minutos] El tiempo de viaje diario va de 1 a 600 minutos; cero minutos no es válido.
[catalogo#medios] Los medios de transporte posibles son colectivo, auto particular, bicicleta, moto, a pie y tren; hay que elegir al menos uno.
RESPUESTA (qwen2.5:7b-instruct, 263723 ms):
[reglas/encuesta#distancia] [reglas/encuesta#minutos]
```

Primera corrida: la llamada de chat cayó por `TaskCanceledException ... HttpClient.Timeout of 100 seconds` (el `HttpClient` por defecto de `OllamaApiClient`); se repitió con `HttpClient { Timeout = 10 min }`. Muestra chica (8 preguntas, 12 fragmentos): sirve para enseñar a medir, **no** para elegir modelo en general. Los tiempos incluyen la carga del modelo en frío y la CPU del contenedor.

## E4 — EF Core SQLite y SqliteVec en el mismo proceso y el mismo archivo

Fuentes: `E4-P.csproj`, `E4-ef-y-sqlitevec-Program.cs`.

```text
EF ok, filas=1
vec ok a score=0
EF tras vec, filas=1
SQLitePCLRaw: 3.0.3.3048
# obj/project.assets.json: SQLitePCLRaw.bundle_e_sqlite3/3.0.3, SQLitePCLRaw.core/3.0.3 ...
```

Lectura: `Microsoft.EntityFrameworkCore.Sqlite` 10.0.11 declara `SQLitePCLRaw.bundle_e_sqlite3` 2.1.12; `CommunityToolkit.VectorData.SqliteVec` 1.0.3-preview pide `[3.0.3, )`. NuGet resuelve 3.0.3 y, en linux-x64, ambos funcionan sobre el mismo archivo. No se probó en Android/MAUI.

## E5 — Mismo contexto, prompt con formato de cita explícito

Fuente: `E5-chat-prompt-mejorado.json` (POST `/api/chat`, `temperature: 0`, servidor de la LAN).

```text
Si no viajas, debes poner cero kilómetros y cero minutos [reglas/encuesta#distancia][reglas/encuesta#minutos].
eval_count 37 total_s 92.998457928
```

Lectura: la respuesta **cita** `[reglas/encuesta#minutos]` y a la vez lo **contradice** (la fuente dice que cero minutos no es válido). Citar no es estar fundamentado: hace falta evaluar *groundedness* (N5) y que la regla la aplique el código del dominio, no el modelo.

## Limpieza

Contenedor `<contenedor-del-arnés>` eliminado. Quedan los volúmenes Docker `<contenedor-del-arnés>` (modelos `nomic-embed-text` y `qwen3-embedding:0.6b`, unos 913 MB) y `<contenedor-del-arnés>` (caché de paquetes), por si la demo los reutiliza; se borran con `docker volume rm <contenedor-del-arnés> <contenedor-del-arnés>`.
