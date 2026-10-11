#!/usr/bin/env bash
# Ciclo 2 · lector sin contexto. Receta de punta a punta: aplicar el Anexo A
# (A.1 variante B, A.2, A.3, A.4, A.4b, A.5, A.6) y A.11 «Qué se copia y adónde»
# a una solución .NET sintética creada como la crea el SDK (dotnet new sln/console/classlib),
# heredada «ya convertida a UTF-8 con BOM», como el caso.
# La estación «Windows» se simula con core.fileMode=false y archivos sin bit x
# (lo que la guía dice de NTFS en §8.2.5, E5-3). NO es Windows: se mide git y los scripts.
# Uso: docker run --rm -u "$(id -u):$(id -g)" -e HOME=/tmp -v <Examples>:/ex:ro -v <esta carpeta>:/out \
#        lab-n2-texto:local bash /out/receta-a11.sh
set -u
EX=/ex; W=/tmp/w; rm -rf "$W"; mkdir -p "$W"; cd "$W"
git config --global user.email lector@ejemplo.invalid; git config --global user.name lector
git config --global init.defaultBranch main
echo "== SDK: $(dotnet --version) · git $(git --version | cut -d' ' -f3)"

echo; echo "################ 1. Estación «Windows» (core.fileMode=false) ################"
mkdir win && cd win && git init -q && git config core.fileMode false
dotnet new sln -n Heredado >/dev/null
dotnet new console -n App -o src/App >/dev/null
dotnet new classlib -n Lib -o src/Lib >/dev/null
dotnet sln add src/App/App.csproj src/Lib/Lib.csproj >/dev/null
echo "-- BOM de lo que crea el SDK (head -c3 | od):"
for f in Heredado.sln src/App/App.csproj src/App/Program.cs src/Lib/Lib.csproj src/Lib/Class1.cs; do
  printf '   %-22s %s\n' "$f" "$(head -c3 "$f" | od -An -tx1 | tr -d ' ')"; done
R=$EX/A-plantillas/repo
cp $R/.editorconfig $R/.gitattributes $R/global.json $R/Directory.Build.props $R/Directory.Build.targets $R/Directory.Packages.props $R/nuget.config .
# A.1 variante B: «descomentar» las dos líneas de [*.cs]
sed -i 's/^# \[\*\.cs\]$/[*.cs]/; s/^# charset = utf-8-bom$/charset = utf-8-bom/' .editorconfig
echo "-- .editorconfig tras descomentar la variante B:"; grep -n -A1 '^\[\*\.cs\]' .editorconfig | sed 's/^/   /'
# A.11 «Qué se copia y adónde» (copia como la haría el Explorador de Windows: sin bit x)
mkdir -p tools/ci .githooks
cp $EX/N7-compuertas-y-gobierno/compuerta/compuerta.sh tools/ci/
cp $EX/N2-politica-de-texto-y-remediacion/tools/check_text_policy.py tools/ci/
cp $R/.githooks/pre-commit .githooks/
chmod a-x tools/ci/* .githooks/*
git config core.hooksPath .githooks
dotnet restore Heredado.sln >/dev/null 2>&1; echo "-- restore: locks generados: $(find . -name packages.lock.json | tr '\n' ' ')"
git add -A
echo "-- modos registrados en el índice:"; git ls-files -s tools/ci .githooks | awk '{print "   "$1, $4}'
echo "-- compuerta a mano, como dice A.11 para Windows (bash tools/ci/compuerta.sh --staged):"
bash tools/ci/compuerta.sh --staged 2>&1 | sed 's/^/   /'; echo "   rc=${PIPESTATUS[0]}"
git commit -q --no-verify -m "política + plantillas" && echo "-- commit inicial hecho (--no-verify sólo para fijar el punto de partida)"

echo; echo "################ 2. Clon de un compañero en Linux / devcontainer ################"
cd "$W"; git clone -q win linux && cd linux && git config core.hooksPath .githooks
printf 'namespace Lib;\npublic class Sensor { public string T => "Atenci\xf3n"; }\n' > src/Lib/Sensor.cs   # cp1252
git add src/Lib/Sensor.cs
echo "-- commit de un .cs en cp1252 con el hook activado:"
git commit -m "sensor cp1252" 2>&1 | sed 's/^/   /'; echo "   rc=${PIPESTATUS[0]}"
echo "-- paso de CI de A.12, tal cual (tools/ci/compuerta.sh sin bash delante):"
tools/ci/compuerta.sh 2>&1 | sed 's/^/   /'; echo "   rc=${PIPESTATUS[0]}"

echo; echo "################ 3. Control: el bit registrado con git update-index --chmod=+x ################"
cd "$W/win" && git update-index --chmod=+x tools/ci/compuerta.sh .githooks/pre-commit && git commit -q --no-verify -m "bit x"
cd "$W"; rm -rf linux2; git clone -q win linux2 && cd linux2 && git config core.hooksPath .githooks
printf 'namespace Lib;\npublic class Sensor { public string T => "Atenci\xf3n"; }\n' > src/Lib/Sensor.cs
git add src/Lib/Sensor.cs; git commit -m "sensor cp1252" 2>&1 | sed 's/^/   /'; echo "   rc=${PIPESTATUS[0]}"
