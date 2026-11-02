#!/bin/sh
# Corre la sonda real con OLLAMA_ENDPOINT del entorno (no se escribe en ningún archivo)
docker run --rm -e OLLAMA_ENDPOINT -e DOTNET_CLI_TELEMETRY_OPTOUT=1 -e DOTNET_NOLOGO=1 -v {dir-de-trabajo}/senior-dotnet-r2/real:/work -v <volumen-nuget>:/root/.nuget/packages -w /work mcr.microsoft.com/dotnet/sdk:10.0 sh -c "dotnet --version && dotnet run -c Release --no-build 2>&1"
