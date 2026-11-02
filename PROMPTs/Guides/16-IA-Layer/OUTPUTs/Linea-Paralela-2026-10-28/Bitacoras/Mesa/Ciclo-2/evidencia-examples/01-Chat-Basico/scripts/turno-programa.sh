#!/bin/bash
set -u
: "${OLLAMA_ENDPOINT:?falta OLLAMA_ENDPOINT}"
W={dir-de-trabajo}/ej01/copia; S={dir-de-trabajo}/ej01/salidas-programa; rm -rf $S; mkdir -p $S
D="docker run --rm --network host -e OLLAMA_ENDPOINT -e DOTNET_ENVIRONMENT=Development -e DOTNET_CLI_TELEMETRY_OPTOUT=1 -e DOTNET_NOLOGO=1 -v $W:/work -v <volumen-nuget>:/root/.nuget/packages -w /work mcr.microsoft.com/dotnet/sdk:10.0"
for prov in ollama openai-compatible; do
{
  echo "# R-LLM — estimando: existencia, 1 corrida (2 vueltas), proveedor $prov, estación de laboratorio de 4 núcleos, fecha $(date -Iseconds)"
  echo "# Ollama $(curl -s $OLLAMA_ENDPOINT/api/version)"
  echo "# modelo@digest: $(curl -s $OLLAMA_ENDPOINT/api/tags | python3 -c 'import json,sys; print([m["name"]+"@"+m["digest"][:12] for m in json.load(sys.stdin)["models"] if m["name"]=="qwen3.5:4b"])')"
  echo "# parámetros: appsettings.json + appsettings.Development.json (T 0.7, top_p 0.8, top_k 20, min_p 0, presence 1.5, repeat 1.0, think false, num_ctx 8192 sólo por la vía nativa, sin semilla)"
  echo "# comando: dotnet run --project src/MovilidadUrbana.Ejemplos.ChatBasico -c Release --no-build -- --AI:Proveedor=$prov"
  t0=$(date +%s)
  $D sh -c "dotnet run --project src/MovilidadUrbana.Ejemplos.ChatBasico -c Release --no-build -- --AI:Proveedor=$prov 2>&1; echo \"# código de salida: \$?\""
  echo "# pared total: $(( $(date +%s) - t0 )) s"
} > $S/programa-$prov.txt 2>&1
done
grep -rlF "$OLLAMA_ENDPOINT" $S | xargs -r sed -i "s|$OLLAMA_ENDPOINT|\$OLLAMA_ENDPOINT|g"
H=${OLLAMA_ENDPOINT#*://}; H=${H%%:*}; grep -rlF "$H" $S | xargs -r sed -i "s|$H|<servidor>|g"
