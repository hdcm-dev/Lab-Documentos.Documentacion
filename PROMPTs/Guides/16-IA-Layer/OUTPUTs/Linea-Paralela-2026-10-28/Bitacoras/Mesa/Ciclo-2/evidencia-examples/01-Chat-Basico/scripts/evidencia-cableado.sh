#!/bin/sh
# Compila desde cero la copia y corre Cableado, ConModelo sin endpoint y el listado de paquetes.
set -u
E=<workspace>/LAB/Lab-Documentos/Lab-Documentos/Guides/IA/Dot-Net-Integration-AI-Layer-Guide/Examples/01-Chat-Basico
W={dir-de-trabajo}/ej01/copia
O={dir-de-trabajo}/ej01/salidas-cableado; mkdir -p $O
rsync -a --delete --exclude bin --exclude obj --exclude TestResults $E/ $W/
D="docker run --rm -e DOTNET_CLI_TELEMETRY_OPTOUT=1 -e DOTNET_NOLOGO=1 -v $W:/work -v <volumen-nuget>:/root/.nuget/packages -w /work mcr.microsoft.com/dotnet/sdk:10.0"
{ echo "# imagen: $(docker image inspect mcr.microsoft.com/dotnet/sdk:10.0 --format '{{index .RepoDigests 0}}'); fecha $(date -Iseconds)"
  $D sh -c "dotnet --version && dotnet build 01-Chat-Basico.slnx -c Release 2>&1 | tail -6"; } > $O/01-build.txt 2>&1
$D sh -c "dotnet test 01-Chat-Basico.slnx -c Release --no-build --filter TestCategory=Cableado --logger 'console;verbosity=detailed' 2>&1" > $O/02-test-cableado.txt 2>&1
$D sh -c "dotnet test 01-Chat-Basico.slnx -c Release --no-build --filter TestCategory=ConModelo --logger 'console;verbosity=normal' 2>&1" > $O/03-test-conmodelo-sin-endpoint.txt 2>&1
$D sh -c "dotnet list 01-Chat-Basico.slnx package --include-transitive 2>&1; dotnet list 01-Chat-Basico.slnx package --vulnerable --include-transitive 2>&1; dotnet list 01-Chat-Basico.slnx package --deprecated 2>&1" > $O/04-paquetes.txt 2>&1
echo listo
