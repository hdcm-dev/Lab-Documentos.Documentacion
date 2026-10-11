#!/usr/bin/env bash
# Ciclo 2 · lector sin contexto. ¿El hook (--staged) mira el lock que se commitea o el del disco?
# Caso diario de Visual Studio: agrego una referencia, el IDE restaura (regenera el lock en disco),
# y en «Git Changes» marco sólo el .csproj. Después, la CI (clon limpio) corre la misma compuerta.
# Uso: docker run --rm -u "$(id -u):$(id -g)" -e HOME=/tmp -v <Examples>:/ex:ro -v <esta carpeta>:/out \
#        lab-n2-texto:local bash /out/hook-lock-sin-stage.sh
set -u
EX=/ex; W=/tmp/w2; rm -rf "$W"; mkdir -p "$W"; cd "$W"
git config --global user.email lector@ejemplo.invalid; git config --global user.name lector
git config --global init.defaultBranch main
mkdir dev && cd dev && git init -q
dotnet new sln -n Heredado >/dev/null; dotnet new console -n App -o src/App >/dev/null; dotnet new classlib -n Lib -o src/Lib >/dev/null
dotnet sln add src/App/App.csproj src/Lib/Lib.csproj >/dev/null
R=$EX/A-plantillas/repo
cp $R/.gitattributes $R/global.json $R/Directory.Build.props $R/Directory.Build.targets $R/Directory.Packages.props $R/nuget.config .
printf 'bin/\nobj/\n' > .gitignore
mkdir -p tools/ci .githooks
cp $EX/N7-compuertas-y-gobierno/compuerta/compuerta.sh $EX/N2-politica-de-texto-y-remediacion/tools/check_text_policy.py tools/ci/
cp $R/.githooks/pre-commit .githooks/; chmod +x tools/ci/compuerta.sh .githooks/pre-commit
git config core.hooksPath .githooks
dotnet restore Heredado.sln >/dev/null 2>&1
git add -A && git commit -q -m inicial && echo "-- commit inicial (hook en verde)"
git clone -q --bare . "$W/origen.git"
echo "-- agrego ProjectReference App -> Lib y restauro (como el IDE):"
sed -i 's#</Project>#  <ItemGroup><ProjectReference Include="../Lib/Lib.csproj" /></ItemGroup>\n</Project>#' src/App/App.csproj
dotnet restore Heredado.sln >/dev/null 2>&1
git status --short | sed 's/^/   /'
git add src/App/App.csproj
echo "-- commit con SÓLO el .csproj marcado (hook --staged):"
git commit -m "referencia a Lib" 2>&1 | sed 's/^/   /'; echo "   rc=${PIPESTATUS[0]}"
git push -q "$W/origen.git" main
echo "-- CI: clon limpio y la misma compuerta (sin alcance, como en main):"
cd "$W" && git clone -q origen.git ci && cd ci && bash tools/ci/compuerta.sh 2>&1 | sed 's/^/   /'; echo "   rc=${PIPESTATUS[0]}"
