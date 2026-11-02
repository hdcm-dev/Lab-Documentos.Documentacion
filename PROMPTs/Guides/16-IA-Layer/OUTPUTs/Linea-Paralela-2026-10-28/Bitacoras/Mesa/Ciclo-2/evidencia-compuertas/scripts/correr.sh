#!/usr/bin/env bash
# Compuerta build+test (Cableado) de Examples/ y Demos/ en sdk:10.0, sobre una copia fuera del workspace.
set -u
G=<workspace>/LAB/Lab-Documentos/Lab-Documentos/Guides/IA/Dot-Net-Integration-AI-Layer-Guide
W=<área de trabajo>/compuertas-redaccion; F=$W/fuente; O=$W/salidas; mkdir -p $O
rm -rf $F; mkdir -p $F; rsync -a --exclude bin --exclude obj --exclude TestResults "$G/Examples" "$G/Demos" $F/
IMG=mcr.microsoft.com/dotnet/sdk:10.0
echo "imagen: $IMG $(docker image inspect $IMG --format '{{.Id}} {{index .RepoDigests 0}}')" | tee $O/imagen.txt
run(){ local dir="$1" tag="$2"; shift 2
  docker run --rm -v <volumen-nuget>:/root/.nuget/packages -v "$F/$dir":/ex -w /ex -e DOTNET_CLI_TELEMETRY_OPTOUT=1 -e DOTNET_NOLOGO=1 $IMG bash -c "$*" > "$O/$tag.txt" 2>&1
  echo "$tag rc=$?" | tee -a $O/resumen.txt; }
: > $O/resumen.txt
run Examples/01-Chat-Basico 01 "dotnet --version; dotnet build 01-Chat-Basico.slnx -c Release && dotnet test 01-Chat-Basico.slnx -c Release --no-build --filter TestCategory=Cableado"
run Examples/02-Streaming 02 "dotnet build src/MovilidadUrbana.Streaming -c Release && dotnet build tests/MovilidadUrbana.Streaming.Tests -c Release && dotnet test tests/MovilidadUrbana.Streaming.Tests -c Release --no-build --filter TestCategory=Cableado"
run Examples/03-Salida-Estructurada 03 "dotnet build src/MovilidadUrbana.SalidaEstructurada -c Release && dotnet build tests/MovilidadUrbana.SalidaEstructurada.Tests -c Release && dotnet test tests/MovilidadUrbana.SalidaEstructurada.Tests -c Release --no-build --filter 'Category!=ConModelo'"
run Examples/04-Embeddings-Y-Busqueda 04 "dotnet build 04-Embeddings-Y-Busqueda.slnx -c Release && dotnet test 04-Embeddings-Y-Busqueda.slnx -c Release --no-build --filter TestCategory=Cableado"
run Examples/05-RAG-En-Memoria 05 "dotnet build 05-RAG-En-Memoria.slnx -c Release && dotnet test 05-RAG-En-Memoria.slnx -c Release --no-build --filter 'FullyQualifiedName~Cableado'"
run Examples/06-Tool-Calling 06 "dotnet build 06-Tool-Calling.slnx -c Release && dotnet test 06-Tool-Calling.slnx -c Release --no-build --filter TestCategory=Cableado"
run Examples/07-Agente-Con-Aprobacion 07 "dotnet build 07-Agente-Con-Aprobacion.slnx -c Release && dotnet test 07-Agente-Con-Aprobacion.slnx -c Release --no-build --filter TestCategory=Cableado"
run Examples/08-Servidor-Y-Cliente-MCP 08 "dotnet build 08-Servidor-Y-Cliente-MCP.slnx -c Release && dotnet test 08-Servidor-Y-Cliente-MCP.slnx -c Release --no-build --filter TestCategory=Cableado"
run Examples/09-Pruebas-Con-Cliente-Falso 09 "dotnet build 09-Pruebas-Con-Cliente-Falso.slnx -c Release && dotnet test 09-Pruebas-Con-Cliente-Falso.slnx -c Release --no-build --filter TestCategory=Cableado"
run Examples/10-Workflow 10 "dotnet build 10-Workflow.slnx -c Release && dotnet test 10-Workflow.slnx -c Release --no-build --filter TestCategory=Cableado"
run Examples/12-Anotaciones-Pareadas 12 "dotnet build 12-Anotaciones-Pareadas.slnx -c Release && dotnet test 12-Anotaciones-Pareadas.slnx -c Release --no-build --filter TestCategory=Cableado"
run Examples/13-Prueba-De-Arquitectura 13 "dotnet build 13-Prueba-De-Arquitectura.slnx -c Release && dotnet test 13-Prueba-De-Arquitectura.slnx -c Release --no-build --filter 'FullyQualifiedName~Cableado'"
run Demos/MovilidadUrbana.Asistente demo "dotnet build MovilidadUrbana.Asistente.slnx -c Release && dotnet test MovilidadUrbana.Asistente.slnx -c Release --no-build --filter 'FullyQualifiedName~Cableado'"
run Demos/MovilidadUrbana.Asistente/verificacion/CopiaSola copiasola "dotnet build CopiaSola.csproj -c Release"
for t in 01 02 03 04 05 06 07 08 09 10 12 13 demo copiasola; do printf '%s: ' $t; grep -E 'Correctas!|Passed!|Failed!|Con error!|error\(es\)|Error\(s\)|errores|Advertencia|Warning\(s\)|advertencia\(s\)' $O/$t.txt | tr '\n' ' '; echo; done | tee $O/conteos.txt
