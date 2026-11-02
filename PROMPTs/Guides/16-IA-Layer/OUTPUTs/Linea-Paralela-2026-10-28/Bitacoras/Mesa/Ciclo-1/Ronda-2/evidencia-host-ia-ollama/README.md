# Evidencia de la consulta {estación-2}-ollama (C1 ronda 2, 2026-10-28)

Segundo servidor de prueba: **estación de laboratorio de 15 vCPU** (VM de 15 vCPU y 38 GB, CPU de escritorio sin GPU, AVX2), con un Ollama propio en contenedor. Autorización: dictamen de presidencia §4. La dirección del servidor no se escribe en ningún archivo del workspace (R-PRIV): todos los scripts la leen de `OLLAMA_ENDPOINT`.

## Servidor

| Dato | Valor |
|---|---|
| Imagen | `ollama/ollama@sha256:dea72d1e2227…` (la misma que la estación de 4 núcleos; etiqueta 0.40.11) |
| `/api/version` | 0.40.11 |
| Límites del contenedor | 14 CPU, 34 GiB (`--cpus 14 --memory 34g`); un núcleo y unos 4 GB quedan para el anfitrión |
| Variables | `OLLAMA_NUM_PARALLEL=1`, `OLLAMA_MAX_LOADED_MODELS=1` (la estación de 4 núcleos usa 2), `OLLAMA_KEEP_ALIVE=10m` |
| Volumen | propio del contenedor, sólo para los modelos |
| Publicación | sólo en la interfaz de la red privada del laboratorio, no en todas las interfaces |
| Modelos (digest corto) | `qwen3.5:4b@d8b0f5e9760c`, `qwen3-embedding:0.6b@ac6da0dfba84`, `qwen2.5:0.5b@a8b0c5157701` (los tres iguales a la estación de 4 núcleos), `qwen3.5:35b-a3b@72aac7c28be8` |

`qwen2.5:0.5b` se bajó aunque la consulta no lo pedía, para correr `correr.sh` sin cambios (el script lo usa).

## Archivos

| Archivo | Qué es | Pregunta |
|---|---|---|
| `00-bajadas.txt` | duración de cada `ollama pull` y `ollama list` final | — |
| `01-registro-manifiestos.txt` | sha256 de los manifiestos del registro de Ollama para `35b-a3b`, `35b-a3b-q4_K_M`, `35b` y `4b`, y capas del de `35b-a3b` | PC-07 |
| `ollama-library-qwen3.5-tags-2026-10-28.html` | página https://ollama.com/library/qwen3.5/tags bajada el 2026-10-28T12:12-03:00 | PC-07 |
| `sondeo/sondeo.py`, `sondeo/correr.sh`, `sondeo/correr-extra.sh` | copia byte a byte de `Bitacoras/Sondeo-Evidencia/2026-10-28/` (sha256 de `sondeo.py`: `4d8f45e5…2826e`, igual al original) | MI-03 |
| `sondeo/salidas/` | salidas del sondeo en la estación de 15 vCPU, 2026-10-28T12:35–12:38 | MI-03 |
| `sonda_largo.py` | prompt de 3503 tokens, `num_ctx` 8192, N = 3, primera línea distinta por corrida para que no sirva la caché | PC-07 |
| `memoria.sh` | `docker stats`, `free -m` y `ollama ps` del anfitrión (se corre por ssh, sin direcciones) | PC-07 |
| `pc07/` | corridas del 4b y del 35b-a3b (chat, herramientas N = 10 × 2, lectura larga N = 3, memoria) y `resumen.py` con su salida | PC-07 |
| `pc08/SondaEval-Program.cs`, `pc08/SondaEval.csproj` | sonda .NET: siete evaluadores de `Microsoft.Extensions.AI.Evaluation.Quality` 10.11.0 con `qwen3.5:4b` como juez por OllamaSharp 5.5.0; cada llamada al juez se mide con un `DelegatingChatClient` | PC-08 |
| `pc08/eval-{estación-2}.jsonl` | 4 casos × 7 evaluadores, razonamiento apagado (28 llamadas) | PC-08 |
| `pc08/eval-{estación-2}-razonando.jsonl` | 1 caso × 7 evaluadores, razonamiento por defecto | PC-08 |
| `pc08/costo.py`, `pc08/costo-salida.txt` | costo medido y estimación para la estación de 4 núcleos | PC-08 |
| `pc08/eval-{estación-1}.jsonl` | el caso C1 × 7 evaluadores corrido en la estación de 4 núcleos con turno `<recurso-compartido>` (2026-10-28T13:19–13:40), 1285,3 s | PC-08 |

## Comandos

```bash
# desde esta carpeta; OLLAMA_ENDPOINT se toma del archivo fuera del workspace que indica la consulta
export OLLAMA_ENDPOINT=$(cat {dir-de-trabajo}/{estación-2}-endpoint.txt)
(cd sondeo && ./correr.sh && ./correr-extra.sh)
python3 -I sonda_largo.py qwen3.5:4b 3 > pc07/01-largo-4b.jsonl
python3 -I sondeo/sondeo.py chat qwen3.5:35b-a3b > pc07/03-chat-35b.jsonl
python3 -I sondeo/sondeo.py tools qwen3.5:35b-a3b 10 > pc07/05-tools-35b.jsonl
SONDEO_VARIANTE=apie python3 -I sondeo/sondeo.py tools qwen3.5:35b-a3b 10 > pc07/06-tools-apie-35b.jsonl
python3 -I sonda_largo.py qwen3.5:35b-a3b 3 > pc07/07-largo-35b.jsonl
python3 -I pc07/resumen.py
# sonda .NET (carpeta de trabajo con SondaEval.csproj y Program.cs = SondaEval-Program.cs)
<envoltorio-de-turnos> build {estación-2}-ollama "sonda EVAL" 20 -- docker run --rm -v <volumen-nuget>:/root/.nuget/packages -v $PWD:/w -w /w mcr.microsoft.com/dotnet/sdk:10.0 dotnet build -c Release
docker run --rm -e OLLAMA_ENDPOINT -e OLLAMA_MODEL=qwen3.5:4b -v <volumen-nuget>:/root/.nuget/packages -v $PWD:/w -w /w mcr.microsoft.com/dotnet/sdk:10.0 dotnet bin/Release/net10.0/SondaEval.dll > eval-{estación-2}.jsonl
docker run ... -e RAZONAR=1 -e CASOS=C1-edad ... > eval-{estación-2}-razonando.jsonl
(cd pc08 && python3 -I costo.py)
```

SDK `mcr.microsoft.com/dotnet/sdk:10.0`, paquetes: Microsoft.Extensions.AI 10.11.0, Microsoft.Extensions.AI.Evaluation 10.11.0, Microsoft.Extensions.AI.Evaluation.Quality 10.11.0, OllamaSharp 5.5.0 (versiones de ensamblado impresas en la primera línea de cada `.jsonl`).
