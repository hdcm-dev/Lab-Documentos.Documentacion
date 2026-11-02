#!/bin/bash
# Turno de modelo para Examples/07: la consola y las dos pruebas ConModelo, sobre la copia ya compilada.
# OLLAMA_ENDPOINT sólo por variable de entorno; las salidas se limpian del endpoint antes de guardarse.
set -u
# Variables: EJEMPLO (carpeta del ejemplo), TRABAJO (carpeta de trabajo), VOLUMEN_NUGET (volumen docker de la caché).
: "${OLLAMA_ENDPOINT:?falta OLLAMA_ENDPOINT}"
W=${TRABAJO:?carpeta de trabajo fuera del workspace}/copia
S=${TRABAJO:?carpeta de trabajo fuera del workspace}/salidas-modelo; rm -rf $S; mkdir -p $S/rllm
export ESTACION=${ESTACION:-estación de laboratorio de 4 núcleos}
D="docker run --rm --network host -e OLLAMA_ENDPOINT -e ESTACION -e RLLM_SALIDA=/salidas/rllm -e DOTNET_ENVIRONMENT=Development -e DOTNET_CLI_TELEMETRY_OPTOUT=1 -e DOTNET_NOLOGO=1 -v $W:/work -v $S:/salidas -v ${VOLUMEN_NUGET:?volumen de la caché NuGet}:/root/.nuget/packages -w /work mcr.microsoft.com/dotnet/sdk:10.0"
{
  echo "# R-LLM — estimando: existencia, 1 corrida, sin semilla, estación: $ESTACION, fecha $(date -Iseconds)"
  echo "# Ollama $(curl -s $OLLAMA_ENDPOINT/api/version)"
  echo "# modelo@digest: $(curl -s $OLLAMA_ENDPOINT/api/tags | python3 -c 'import json,sys; print([m["name"]+"@"+m["digest"][:12] for m in json.load(sys.stdin)["models"] if m["name"]=="qwen3.5:4b"])')"
  echo "# parámetros: appsettings.json + appsettings.Development.json (T 0.7, top_p 0.8, top_k 20, min_p 0, presence 1.5, repeat 1.0, think false, num_ctx 8192, iteraciones 3, sin semilla), /api/chat (OllamaSharp 5.5.0), MAF 1.26.0"
  echo "# comando: dotnet run --project src/MovilidadUrbana.Ejemplos.AgenteConAprobacion -c Release --no-build -- --aprobar s"
  t0=$(date +%s); $D sh -c "dotnet run --project src/MovilidadUrbana.Ejemplos.AgenteConAprobacion -c Release --no-build -- --aprobar s 2>&1; echo \"# código de salida: \$?\""; echo "# pared total: $(( $(date +%s) - t0 )) s"
} > $S/programa.txt 2>&1
for t in DelChatAlAgenteConModeloTests BajaConAprobacionConModeloTests; do
  { echo "# estación: $ESTACION; inicio $(date -Iseconds)"
    $D sh -c "dotnet test 07-Agente-Con-Aprobacion.slnx -c Release --no-build --filter FullyQualifiedName~$t --logger 'console;verbosity=normal' 2>&1"
    echo "# fin $(date -Iseconds)"; } > $S/$t.txt 2>&1
done
grep -rlF "$OLLAMA_ENDPOINT" $S | xargs -r sed -i "s|$OLLAMA_ENDPOINT|\$OLLAMA_ENDPOINT|g"
H=${OLLAMA_ENDPOINT#*://}; H=${H%%:*}; grep -rlF "$H" $S | xargs -r sed -i "s|$H|<servidor>|g"
echo listo
