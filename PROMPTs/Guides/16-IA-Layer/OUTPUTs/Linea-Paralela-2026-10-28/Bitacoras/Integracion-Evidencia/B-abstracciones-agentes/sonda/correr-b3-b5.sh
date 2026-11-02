#!/bin/sh
docker run --rm --network host -e OLLAMA_ENDPOINT -e OLLAMA_MODEL=qwen3.5:4b -e N=3 -e DOTNET_CLI_TELEMETRY_OPTOUT=1 -e DOTNET_NOLOGO=1 -v <volumen-nuget>:/root/.nuget/packages -v $PWD:/w -w /w mcr.microsoft.com/dotnet/sdk:10.0 dotnet bin/Release/net10.0/SondaB.dll b3,b4 > salidas/02-b3-b4.jsonl 2> salidas/02-b3-b4.err
python3 -I esc02_catalogo.py > salidas/03-b5.jsonl 2> salidas/03-b5.err
