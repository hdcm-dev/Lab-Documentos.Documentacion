#!/bin/sh
# Compila desde cero una copia del ejemplo y corre Cableado, ConModelo sin endpoint, la consola sin modelo y el listado de paquetes.
set -u
# Variables: EJEMPLO (carpeta del ejemplo), TRABAJO (carpeta de trabajo), VOLUMEN_NUGET (volumen docker de la caché).
E=${EJEMPLO:?ruta de Examples/07-Agente-Con-Aprobacion}
W=${TRABAJO:?carpeta de trabajo fuera del workspace}/copia
O=${TRABAJO:?carpeta de trabajo fuera del workspace}/salidas-cableado; rm -rf $O; mkdir -p $O
docker run --rm -v ${TRABAJO:?carpeta de trabajo fuera del workspace}:/t alpine:3.20 rm -rf /t/copia 2>/dev/null || docker run --rm -v ${TRABAJO:?carpeta de trabajo fuera del workspace}:/t mcr.microsoft.com/dotnet/sdk:10.0 rm -rf /t/copia; mkdir -p $W
rsync -a --exclude bin --exclude obj --exclude TestResults $E/ $W/
D="docker run --rm -e DOTNET_CLI_TELEMETRY_OPTOUT=1 -e DOTNET_NOLOGO=1 -v $W:/work -v ${VOLUMEN_NUGET:?volumen de la caché NuGet}:/root/.nuget/packages -w /work mcr.microsoft.com/dotnet/sdk:10.0"
{ echo "# imagen: $(docker image inspect mcr.microsoft.com/dotnet/sdk:10.0 --format '{{index .RepoDigests 0}}'); fecha $(date -Iseconds)"
  $D sh -c "dotnet --version && dotnet build 07-Agente-Con-Aprobacion.slnx -c Release 2>&1 | tail -6"; } > $O/01-build.txt 2>&1
$D sh -c "dotnet test 07-Agente-Con-Aprobacion.slnx -c Release --no-build --filter TestCategory=Cableado --logger 'console;verbosity=normal' 2>&1" > $O/02-test-cableado.txt 2>&1
$D sh -c "dotnet test 07-Agente-Con-Aprobacion.slnx -c Release --no-build --filter TestCategory=ConModelo --logger 'console;verbosity=normal' 2>&1" > $O/03-test-conmodelo-sin-endpoint.txt 2>&1
$D sh -c "dotnet list 07-Agente-Con-Aprobacion.slnx package 2>&1; dotnet list 07-Agente-Con-Aprobacion.slnx package --include-transitive 2>&1; dotnet list 07-Agente-Con-Aprobacion.slnx package --vulnerable --include-transitive 2>&1; dotnet list 07-Agente-Con-Aprobacion.slnx package --deprecated 2>&1" > $O/04-paquetes.txt 2>&1
{ echo "## --sin-modelo --aprobar s"
  $D sh -c 'DOTNET_ENVIRONMENT=Development dotnet run --project src/MovilidadUrbana.Ejemplos.AgenteConAprobacion -c Release --no-build -- --sin-modelo --aprobar s; echo "# código de salida: $?"'
  echo "## --sin-modelo --aprobar n"
  $D sh -c 'DOTNET_ENVIRONMENT=Development dotnet run --project src/MovilidadUrbana.Ejemplos.AgenteConAprobacion -c Release --no-build -- --sin-modelo --aprobar n; echo "# código de salida: $?"'
  echo "## --sin-modelo, sin --aprobar y sin entrada (stdin cerrado): sin respuesta = no"
  $D sh -c 'DOTNET_ENVIRONMENT=Development dotnet run --project src/MovilidadUrbana.Ejemplos.AgenteConAprobacion -c Release --no-build -- --sin-modelo < /dev/null; echo "# código de salida: $?"'
  echo "## sin DOTNET_ENVIRONMENT=Development (falta TimeoutSegundos)"
  $D sh -c 'dotnet run --project src/MovilidadUrbana.Ejemplos.AgenteConAprobacion -c Release --no-build -- --sin-modelo; echo "# código de salida: $?"'
} > $O/05-consola-sin-modelo.txt 2>&1
# RV-12: literales de endpoint/modelo fuera de opciones y appsettings
{ echo "# grep de literales (RV-12) en src/ fuera de OpcionesDeIA.cs y appsettings*.json"; grep -rn "localhost:11434\|qwen3.5:4b\|num_ctx\|TimeoutSegundos = " $E/src --include=*.cs | grep -v OpcionesDeIA.cs | sed "s|$E/||"; echo "# fin"; } > $O/06-literales.txt
# bin/obj en el workspace
{ echo "# bin/ u obj/ en la carpeta del ejemplo:"; find $E -type d \( -name bin -o -name obj \) ; echo "# fin"; } >> $O/06-literales.txt
echo listo
