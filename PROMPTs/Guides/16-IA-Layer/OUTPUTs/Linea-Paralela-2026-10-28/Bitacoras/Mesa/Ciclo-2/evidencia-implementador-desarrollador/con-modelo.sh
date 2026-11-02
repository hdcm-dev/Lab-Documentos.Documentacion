#!/bin/bash
# Comandos ConModelo de los README, con OLLAMA_ENDPOINT apuntando a la estación 2 (sin --network ia-guia: el servidor está en otro equipo).
W=<trabajo>/guia; L=<trabajo>/logs
IMG=mcr.microsoft.com/dotnet/sdk:10.0; NU="-v <volumen-nuget>:/root/.nuget/packages"
EP=$(cat <archivo-del-endpoint>)
ROT="medido en una estación de laboratorio con más núcleos, $(date +%F)"
run(){ n=$1; shift; echo "### $n $(date +%T)"; ( "$@" ) > $L/$n.log 2>&1; echo "rc=$? $(date +%T)" | tee -a $L/$n.log; }
cd $W/Examples/06-Tool-Calling
run 06-conmodelo docker run --rm $NU -e OLLAMA_ENDPOINT="$EP" -e ESTACION="$ROT" -v "$PWD":/ex -w /ex $IMG dotnet test 06-Tool-Calling.slnx --filter TestCategory=ConModelo --logger "console;verbosity=normal"
cd $W/Demos/MovilidadUrbana.Asistente
run demo-conmodelo-d1 docker run --rm $NU -v "$PWD":/work -w /work -e OLLAMA_ENDPOINT="$EP" -e ESTACION_ROTULO="$ROT" -e CONMODELO_SALIDA=/work/resultados-conmodelo $IMG dotnet test MovilidadUrbana.Asistente.slnx --filter "TestCategory=ConModelo&Name~D1_"
cd $W/Examples/10-Workflow
run 10-conmodelo docker run --rm $NU -e OLLAMA_ENDPOINT="$EP" -e ESTACION="$ROT" -v "$PWD":/ex -w /ex $IMG dotnet test 10-Workflow.slnx --filter TestCategory=ConModelo --logger "console;verbosity=normal"
echo FIN
