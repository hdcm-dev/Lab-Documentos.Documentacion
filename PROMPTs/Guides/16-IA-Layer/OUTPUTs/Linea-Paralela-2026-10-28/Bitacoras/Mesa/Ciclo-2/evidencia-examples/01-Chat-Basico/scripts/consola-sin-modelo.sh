#!/bin/sh
W={dir-de-trabajo}/ej01/copia; O={dir-de-trabajo}/ej01/salidas-cableado
D="docker run --rm -e DOTNET_CLI_TELEMETRY_OPTOUT=1 -e DOTNET_NOLOGO=1 -v $W:/work -v <volumen-nuget>:/root/.nuget/packages -w /work mcr.microsoft.com/dotnet/sdk:10.0"
{ echo "## sin DOTNET_ENVIRONMENT=Development (falta TimeoutSegundos), sin servidor"
  $D sh -c 'dotnet run --project src/MovilidadUrbana.Ejemplos.ChatBasico -c Release --no-build; echo "# código de salida: $?"'
  echo "## con Development y una pregunta de 2001 caracteres, sin servidor"
  $D sh -c 'DOTNET_ENVIRONMENT=Development dotnet run --project src/MovilidadUrbana.Ejemplos.ChatBasico -c Release --no-build -- --pregunta "$(head -c 2001 /dev/zero | tr "\0" a)"; echo "# código de salida: $?"'
} > $O/05-consola-sin-modelo.txt 2>&1
