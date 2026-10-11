#!/usr/bin/env bash
# Implementador ingenuo: sigue §5.2.6 + A.1/A.2 + A.11 tal como están escritas.
set -u
EX=/ex; W=/tmp/w; rm -rf $W; mkdir -p $W; cd $W
git config --global user.email d@x; git config --global user.name dev; git config --global init.defaultBranch main
git init -q --bare origen.git
git clone -q origen.git arq; cd arq
mkdir -p src Pages
printf 'namespace App;\r\npublic static class Sensor\r\n{\r\n    public static int \xc7audal => 42;\r\n    public static string Texto => "Atenci\xf3n";\r\n}\r\n' > src/Sensor.cs
printf '<h1>Se\xf1al</h1>\r\n' > Pages/Index.razor
printf '\xef\xbb\xbf\r\nMicrosoft Visual Studio Solution File, Format Version 12.00\r\n' > App.sln
printf '<Project Sdk="Microsoft.NET.Sdk"><PropertyGroup><TargetFramework>net8.0</TargetFramework><OutputType>Exe</OutputType></PropertyGroup></Project>\r\n' > src/App.csproj
printf 'System.Console.WriteLine(App.Sensor.Texto);\r\n' > src/Program.cs
git -c core.autocrlf=false add -A; git -c core.autocrlf=false commit -qm heredado; git push -q origin main
# estación del dev: clon con un trabajo SIN commitear
cd $W; git clone -q origen.git dev; cd dev; printf '// TODO trabajo a medio hacer\r\n' >> src/Program.cs; echo "[dev] cambio local sin commitear: $(git status --short)"
# ---- commit 1: política (A.1, A.2) ----
cd $W/arq; cp $EX/A-plantillas/repo/.editorconfig $EX/A-plantillas/repo/.gitattributes .
git add .editorconfig .gitattributes; git commit -qm politica
# ---- commit 2: migración mecánica (tools/migrar-a-utf8.sh) ----
mkdir -p tools; cp $EX/N2-politica-de-texto-y-remediacion/tools/*.sh $EX/N2-politica-de-texto-y-remediacion/tools/check_text_policy.py tools/
git add tools; git commit -qm tools
echo "== migrar"; bash tools/migrar-a-utf8.sh CP1252 2>&1 | tail -8
git commit -qm migracion; SHA=$(git rev-parse HEAD)
echo "== verificar"; bash tools/verificar-commit-mecanico.sh $SHA CP1252 2>&1 | tail -2
echo "== compuerta texto (todo)"; python3 tools/check_text_policy.py 2>&1 | tail -3
git push -q origin main
# ---- paso 5 en la estación del dev: refrescar working tree ----
cd $W/dev; git pull -q 2>&1 | tail -3; echo "[dev] tras pull: $(git status --short | tr '\n' ' ')"
git rm -rq --cached . && git reset -q --hard
echo "[dev] tras el refresco del §5.2.6 paso 5: status='$(git status --short)'"
grep -c 'TODO trabajo a medio hacer' src/Program.cs || echo "[dev] el trabajo sin commitear SE PERDIÓ"
