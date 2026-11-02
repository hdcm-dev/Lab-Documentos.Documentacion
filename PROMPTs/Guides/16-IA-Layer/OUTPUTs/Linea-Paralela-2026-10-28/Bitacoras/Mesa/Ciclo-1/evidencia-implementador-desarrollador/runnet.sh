#!/bin/sh
set -u
W=<TRABAJO>; p=$1
docker run --rm --network host -u 1000:1000 -e HOME=/tmp -e DOTNET_CLI_TELEMETRY_OPTOUT=1 -e DOTNET_NOLOGO=1 -e NUGET_PACKAGES=/nuget \
  -e OLLAMA_ENDPOINT -e OLLAMA_MODEL -e LINEAS -v $W/nuget:/nuget -v $W/$p:/w -w /w mcr.microsoft.com/dotnet/sdk:10.0 dotnet run -c Release 2>&1 | grep -v workload | sed "s#${OLLAMA_ENDPOINT}#<OLLAMA_ENDPOINT>#g"
