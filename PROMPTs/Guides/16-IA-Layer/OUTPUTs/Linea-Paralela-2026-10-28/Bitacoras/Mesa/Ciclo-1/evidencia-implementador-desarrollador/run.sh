#!/bin/sh
set -u
W=<TRABAJO>
p=$1; shift
echo "===== run $p $* ($(date -Is))"
docker run --rm -u 1000:1000 -e HOME=/tmp -e DOTNET_CLI_TELEMETRY_OPTOUT=1 -e DOTNET_NOLOGO=1 -e NUGET_PACKAGES=/nuget \
  -v $W/nuget:/nuget -v $W/$p:/w -w /w mcr.microsoft.com/dotnet/sdk:10.0 dotnet run -c Release -- "$@" 2>&1 | tail -60
