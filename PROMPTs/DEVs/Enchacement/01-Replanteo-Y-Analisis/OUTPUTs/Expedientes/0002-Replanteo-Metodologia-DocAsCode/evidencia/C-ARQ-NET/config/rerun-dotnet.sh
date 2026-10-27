#!/bin/bash
# Re-corrida consolidada C-ARQ-NET (2026-10-26). Todo en contenedores --rm.
C=<intermedios>
O=$C/out2; mkdir -p $O
SDK=mcr.microsoft.com/dotnet/sdk:10.0
ENVS="-e DOTNET_CLI_HOME=/tmp -e NUGET_PACKAGES=/x/nuget -e DOTNET_NOLOGO=1 -e DOTNET_CLI_TELEMETRY_OPTOUT=1"
U="-u $(id -u):$(id -g)"
# E1: build ApiWeb con TreatWarningsAsErrors + OpenAPI en build
docker run --rm $U $ENVS -v $C:/x -w /x/src $SDK bash -c 'cd MovilidadUrbana.ApiWeb && rm -rf bin obj && s=$(date +%s%N); dotnet build -c Release -p:TreatWarningsAsErrors=true 2>&1 | tail -4; echo "build_ms=$(( ($(date +%s%N)-s)/1000000 ))"; git -C /x/src diff --exit-code --stat -- "*openapi*.json"; echo "diff_contrato_exit=$?"' > $O/e1.txt 2>&1
# E1b: sin NoWarn CS1591 (qué pasaría con XML obligatorio en todo miembro público)
docker run --rm $U $ENVS -v $C:/x -w /x/src/MovilidadUrbana.ApiWeb $SDK bash -c 'dotnet build -c Release --no-incremental -p:TreatWarningsAsErrors=true "-p:NoWarn=" 2>&1 | grep -c "error CS1591"; dotnet build -c Release --no-incremental -p:TreatWarningsAsErrors=true "-p:NoWarn=" 2>&1 | grep -oE "error CS1591: [^[]*" | sort | uniq | wc -l' > $O/e1b.txt 2>&1
# E5: docfx metadata+build con --warningsAsErrors
docker run --rm $U $ENVS -v $C:/x -w /x/docfx $SDK bash -c 'rm -rf api _site; s=$(date +%s%N); /x/tools/docfx metadata docfx.json --warningsAsErrors > /tmp/m.log 2>&1; echo "metadata_exit=$? metadata_ms=$(( ($(date +%s%N)-s)/1000000 ))"; s=$(date +%s%N); /x/tools/docfx build docfx.json --warningsAsErrors > /tmp/b.log 2>&1; echo "build_exit=$? build_ms=$(( ($(date +%s%N)-s)/1000000 ))"; grep -hE "warning\(s\)|error\(s\)" /tmp/m.log /tmp/b.log; echo "html=$(find _site -name "*.html" | wc -l) api_yml=$(ls api/*.yml | wc -l) md_en_site=$(find _site -name "*.md" | wc -l)"; du -sh _site' > $O/e5.txt 2>&1
# E6: enlace roto plantado
sed -i 's#](../usuario/empezar.md)#](../usuario/no-existe.md)#' $C/docfx/docs/tecnica/arquitectura.md
docker run --rm $U $ENVS -v $C:/x -w /x/docfx $SDK bash -c '/x/tools/docfx build docfx.json --warningsAsErrors > /tmp/b.log 2>&1; echo "build_exit=$?"; grep -E "InvalidFileLink|warning\(s\)" /tmp/b.log' > $O/e6.txt 2>&1
sed -i 's#](../usuario/no-existe.md)#](../usuario/empezar.md)#' $C/docfx/docs/tecnica/arquitectura.md
# E7: metadata en markdown
docker run --rm $U $ENVS -v $C:/x -w /x/docfx $SDK bash -c 'rm -rf api-md; /x/tools/docfx metadata docfx.json --outputFormat markdown --output api-md > /tmp/m.log 2>&1; echo exit=$?; echo "md=$(find api-md -name "*.md" | wc -l)"' > $O/e7.txt 2>&1
# E8a: docfx sobre MAUI net10.0-android con sdk:10.0 (sin workload)
docker run --rm $U $ENVS -v $C:/x -w /x/docfx-maui $SDK bash -c 'rm -rf api; /x/tools/docfx metadata docfx.json > /tmp/m.log 2>&1; echo "docfx_exit=$?"; grep -m3 -iE "workload|NETSDK|error" /tmp/m.log; echo "api_yml=$(ls api 2>/dev/null | wc -l)"' > $O/e8a.txt 2>&1
# E8b: docfx sobre MAUI con la imagen del runner (workload maui-android)
docker run --rm $ENVS --entrypoint bash -v $C:/x -w /x/docfx-maui runner-github-dev/dotnet-maui:2.338.1 -c 'rm -rf api; dotnet --version; s=$(date +%s%N); /x/tools/docfx metadata docfx.json > /tmp/m.log 2>&1; echo "docfx_exit=$? ms=$(( ($(date +%s%N)-s)/1000000 ))"; grep -E "warning\(s\)|error\(s\)" /tmp/m.log | tail -2; echo "api_yml=$(ls api | wc -l)"; chown -R '"$(id -u):$(id -g)"' api' > $O/e8b.txt 2>&1
