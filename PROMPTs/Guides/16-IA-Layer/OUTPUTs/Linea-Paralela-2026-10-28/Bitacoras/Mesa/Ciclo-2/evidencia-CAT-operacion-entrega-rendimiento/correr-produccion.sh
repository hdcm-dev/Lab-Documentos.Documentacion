#!/usr/bin/env bash
# Arranque de la demo fuera de Development: sin y con AI__TimeoutSegundos por variable.
W=$W
docker run --rm -v <volumen-nuget>:/root/.nuget/packages -v $W/demo:/work -w /work mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet build src/MovilidadUrbana.Asistente -c Debug -nologo -v q > $W/00-build.txt 2>&1; echo "build rc=$?" >> $W/00-build.txt
for caso in sin-variable con-variable; do
  extra=""; [ $caso = con-variable ] && extra="-e AI__TimeoutSegundos=300"
  timeout 90 docker run --rm --network none -v <volumen-nuget>:/root/.nuget/packages -v $W/demo:/work -w /work \
    -e ASPNETCORE_ENVIRONMENT=Production -e ASPNETCORE_URLS=http://+:8080 $extra mcr.microsoft.com/dotnet/sdk:10.0 \
    dotnet run --project src/MovilidadUrbana.Asistente --no-build --no-launch-profile > $W/01-produccion-$caso.txt 2>&1
  echo "rc=$? (124 = sigue arriba al vencer el timeout de 90 s)" >> $W/01-produccion-$caso.txt
done
