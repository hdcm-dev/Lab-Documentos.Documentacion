#!/bin/sh
# Copia el ejemplo a /vm y compila + corre Cableado en el SDK oficial.
set -e
E=<workspace>/LAB/Lab-Documentos/Lab-Documentos/Guides/IA/Dot-Net-Integration-AI-Layer-Guide/Examples/01-Chat-Basico
W={dir-de-trabajo}/ej01/copia
mkdir -p $W
rsync -a --delete --exclude bin --exclude obj --exclude TestResults $E/ $W/
docker run --rm -e DOTNET_CLI_TELEMETRY_OPTOUT=1 -e DOTNET_NOLOGO=1 -v $W:/work -v <volumen-nuget>:/root/.nuget/packages -w /work mcr.microsoft.com/dotnet/sdk:10.0 sh -c "dotnet --version && dotnet build 01-Chat-Basico.slnx -c Release 2>&1 | tail -30 && dotnet test 01-Chat-Basico.slnx -c Release --no-build --filter TestCategory=Cableado --logger 'console;verbosity=detailed' 2>&1"
