#!/bin/sh
# correr.sh <carpeta-de-sonda> [args]: compila y corre en el SDK oficial, con caché NuGet en el volumen <volumen-nuget>
d=$1; shift
docker run --rm -e DOTNET_CLI_TELEMETRY_OPTOUT=1 -e DOTNET_NOLOGO=1 -v {dir-de-trabajo}/senior-dotnet-r2/$d:/work -v <volumen-nuget>:/root/.nuget/packages -w /work mcr.microsoft.com/dotnet/sdk:10.0 sh -c "dotnet --version && dotnet run -c Release -- $* 2>&1"
