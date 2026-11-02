#!/bin/bash
# Reproduce los comandos de los README tal cual (más el volumen de caché NuGet de la corrida).
W=<copia-limpia>; L=<trabajo>/logs
IMG=mcr.microsoft.com/dotnet/sdk:10.0; NU="-v <volumen-nuget>:/root/.nuget/packages"
run(){ n=$1; shift; echo "### $n :: $*" ; ( "$@" ) > $L/$n.log 2>&1; echo "rc=$?" | tee -a $L/$n.log; }
cd $W/Examples/06-Tool-Calling
run 06-build docker run --rm $NU -v "$PWD":/ex -w /ex $IMG dotnet build 06-Tool-Calling.slnx
run 06-cableado docker run --rm $NU -v "$PWD":/ex -w /ex $IMG dotnet test 06-Tool-Calling.slnx --filter TestCategory=Cableado
run 06-consola-sinmodelo docker run --rm $NU -e DOTNET_ENVIRONMENT=Development -v "$PWD":/ex -w /ex $IMG dotnet run --project src/MovilidadUrbana.Ejemplos.ToolCalling -- --sin-modelo
run 06-consola-sinenv docker run --rm $NU -v "$PWD":/ex -w /ex $IMG dotnet run --project src/MovilidadUrbana.Ejemplos.ToolCalling -- --sin-modelo
run 06-suite-completa docker run --rm $NU -v "$PWD":/ex -w /ex $IMG dotnet test 06-Tool-Calling.slnx
cd $W/Examples/07-Agente-Con-Aprobacion
run 07-build docker run --rm $NU -v "$PWD":/work -w /work $IMG dotnet build 07-Agente-Con-Aprobacion.slnx -c Release
run 07-cableado docker run --rm $NU -v "$PWD":/work -w /work $IMG dotnet test 07-Agente-Con-Aprobacion.slnx -c Release --filter TestCategory=Cableado
run 07-consola-s docker run --rm $NU -e DOTNET_ENVIRONMENT=Development -v "$PWD":/work -w /work $IMG dotnet run --project src/MovilidadUrbana.Ejemplos.AgenteConAprobacion -c Release -- --sin-modelo --aprobar s
run 07-consola-n docker run --rm $NU -e DOTNET_ENVIRONMENT=Development -v "$PWD":/work -w /work $IMG dotnet run --project src/MovilidadUrbana.Ejemplos.AgenteConAprobacion -c Release -- --sin-modelo --aprobar n
cd $W/Examples/10-Workflow
run 10-build docker run --rm $NU -v "$PWD":/ex -w /ex $IMG dotnet build 10-Workflow.slnx
run 10-cableado docker run --rm $NU -v "$PWD":/ex -w /ex $IMG dotnet test 10-Workflow.slnx --filter TestCategory=Cableado
run 10-encuesta docker run --rm $NU -e DOTNET_ENVIRONMENT=Development -v "$PWD":/ex -w /ex $IMG dotnet run --project src/MovilidadUrbana.Ejemplos.Orquestacion -- encuesta
run 10-alta-nadie docker run --rm $NU -e DOTNET_ENVIRONMENT=Development -v "$PWD":/ex -w /ex $IMG dotnet run --project src/MovilidadUrbana.Ejemplos.Orquestacion -- alta --sin-modelo --confirmar nadie
run 10-alta-si docker run --rm $NU -e DOTNET_ENVIRONMENT=Development -v "$PWD":/ex -w /ex $IMG dotnet run --project src/MovilidadUrbana.Ejemplos.Orquestacion -- alta --sin-modelo
run 10-secuencial docker run --rm $NU -e DOTNET_ENVIRONMENT=Development -v "$PWD":/ex -w /ex $IMG dotnet run --project src/MovilidadUrbana.Ejemplos.Orquestacion -- secuencial --sin-modelo
cd $W/Demos/MovilidadUrbana.Asistente
run demo-cableado docker run --rm $NU -v "$PWD":/work -w /work $IMG dotnet test MovilidadUrbana.Asistente.slnx --filter "FullyQualifiedName~Cableado"
ls -ln $W/Examples/06-Tool-Calling/src/*/ | head -5 > $L/propietarios.log
echo FIN
