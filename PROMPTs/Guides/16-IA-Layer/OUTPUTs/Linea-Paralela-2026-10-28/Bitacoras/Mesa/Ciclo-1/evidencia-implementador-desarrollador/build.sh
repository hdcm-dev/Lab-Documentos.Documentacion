#!/bin/sh
# Compila (y corre si se pide) cada sonda en el contenedor oficial del SDK, como lo haría el lector.
set -u
W=<TRABAJO>
for p in "$@"; do
  echo "===== $p ($(date -Is))"
  docker run --rm -u 1000:1000 -e HOME=/tmp -e DOTNET_CLI_TELEMETRY_OPTOUT=1 -e DOTNET_NOLOGO=1 -e NUGET_PACKAGES=/nuget \
    -v $W/nuget:/nuget -v $W/$p:/w -w /w mcr.microsoft.com/dotnet/sdk:10.0 \
    sh -c 'dotnet --version; dotnet build -c Release 2>&1 | grep -E "error|warning|Warn|Error|Correcto|Build succeeded|Compilación" | sort -u | head -40'
done
