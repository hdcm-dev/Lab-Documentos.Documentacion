#!/usr/bin/env bash
# X2 (C2-01, C2-02, C2-03, C2-05/06, C2-07, C2-14, C2-53): las plantillas propuestas en ../propuestas/repo
# (A.4 con NU1603 activo, A.4b con WinExe, A.10 con EditorConfig, A.11 compuerta con descubrimiento y
# requested = resolved, A.12/A.17 registro del entorno, A.18 .gitignore), juntas, en la imagen de A.10.
# Uso, desde el host: bash experimento.sh   (necesita Docker y red: nuget.org, npm, PyPI)
set -u
AQUI=$(cd "$(dirname "$0")" && pwd); P=$AQUI/../propuestas/repo
T=$(mktemp -d); trap 'rm -rf "$T"' EXIT; cp -a "$P/." "$T/"
echo "== 0. Imagen de A.10 propuesta"
docker build -q -t auditor-c2-a10:local --build-arg PYTHON_VERSION="$(cat "$T/tools/gen/.python-version")" "$T/imagen" >/dev/null && echo "   docker build rc=0"
docker run --rm auditor-c2-a10:local python3 -c 'import editorconfig,sys;print("   import editorconfig OK con", sys.version.split()[0])'
docker run --rm --user "$(id -u):$(id -g)" -e HOME=/tmp -v "$T":/w -w /w auditor-c2-a10:local bash -c '
set -u
git config --global user.email lab@ejemplo.invalid; git config --global user.name lab; git config --global init.defaultBranch main
git init -q .
dotnet restore src/App -v q >/dev/null; (cd web && npm install -s --no-audit --no-fund >/dev/null); (cd tools/gen && uv lock -q)
git add -A && git commit -qm "plantillas + locks"
echo "   versionado: $(git ls-files | grep -cE "(^|/)(bin|obj|node_modules|\.venv)/") archivos de bin/obj/node_modules/.venv (A.18)"
echo "== 1. Compuerta propuesta en modo CI sobre las plantillas (proyectos en subcarpetas)"
CI=true bash tools/ci/compuerta.sh; echo "   rc=$?"
echo "== 2. Pasos 8a de A.12, en la misma imagen: build + registro del entorno"
echo "SOURCE_DATE_EPOCH=$(git log -1 --pretty=%ct)" >> /tmp/github_env; set -a; . /tmp/github_env; set +a
CI=true dotnet build src/App -c Release -o out -v q -nologo >/dev/null && echo "   dotnet build rc=0 (SOURCE_DATE_EPOCH=$SOURCE_DATE_EPOCH)"
bash tools/ci/registrar-entorno.sh out/App.dll | sed "s/^/   /"; echo "   rc=${PIPESTATUS[0]}"; rm -rf out
echo "== 3. El .cs del caso en cp1252, en una subcarpeta, en el hook (--staged)"
printf "class Alarma { string \xc7audal = \"Atenci\xf3n\"; }\n" > src/App/Alarma.cs; git add src/App/Alarma.cs
bash tools/ci/compuerta.sh --staged | grep -E "texto|byte|resultado"; echo "   rc=${PIPESTATUS[0]}"; git rm -q --cached src/App/Alarma.cs; rm src/App/Alarma.cs
echo "== 4. Versión central inexistente (Primitives 8.0.2): con lock, el restore no avisa"
sed -i "s|<PackageVersion Include=\"Newtonsoft.Json\" Version=\"13.0.3\" />|&\n    <PackageVersion Include=\"Microsoft.Extensions.Primitives\" Version=\"8.0.2\" />|" Directory.Packages.props
sed -i "s|<PackageReference Include=\"Newtonsoft.Json\" />|&\n    <PackageReference Include=\"Microsoft.Extensions.Primitives\" />|" src/App/App.csproj
dotnet restore src/App 2>&1 | grep -cE "NU1603" | sed "s/^/   restore local: líneas NU1603 = /"
git commit -qam "Primitives 8.0.2"
CI=true bash tools/ci/compuerta.sh | grep -E "grafo NuGet|pide|resultado"; echo "   rc=${PIPESTATUS[0]}"
git reset -q --hard HEAD~1 && rm -rf src/App/obj
echo "== 5. Una app de escritorio (WinExe, WinForms) recibe lock con A.4b propuesta"
mkdir -p src/Escritorio; printf "<Project Sdk=\"Microsoft.NET.Sdk\">\n  <PropertyGroup>\n    <OutputType>WinExe</OutputType>\n    <TargetFramework>net8.0-windows</TargetFramework>\n    <UseWindowsForms>true</UseWindowsForms>\n    <EnableWindowsTargeting>true</EnableWindowsTargeting>\n  </PropertyGroup>\n  <ItemGroup>\n    <PackageReference Include=\"Newtonsoft.Json\" />\n  </ItemGroup>\n</Project>\n" > src/Escritorio/Escritorio.csproj
dotnet restore src/Escritorio -v q >/dev/null; echo "   restore local rc=$?; packages.lock.json: $([ -f src/Escritorio/packages.lock.json ] && echo SI || echo NO)"
CI=true dotnet msbuild src/Escritorio -nologo -getProperty:OutputType -getProperty:RestorePackagesWithLockFile -getProperty:RestoreLockedMode | tr -d "\n " | sed "s/^/   /"; echo
git add -A && git commit -qm escritorio && CI=true bash tools/ci/compuerta.sh | grep -E "Escritorio|resultado"; echo "   rc=${PIPESTATUS[0]}"
echo "== 6. web/package.json cambiado sin regenerar su lock (subcarpeta)"
sed -i "s/\"private\": true,/\"private\": true,\n  \"dependencies\": { \"is-number\": \"7.0.0\" },/" web/package.json; git commit -qam "dep sin lock"
CI=true bash tools/ci/compuerta.sh | grep -E "grafo npm|EUSAGE|resultado"; echo "   rc=${PIPESTATUS[0]}"
git reset -q --hard HEAD~1
'
echo "== 7. La misma compuerta en la imagen de A.10 SIN EditorConfig (receta actual de Examples/A-plantillas)"

docker build -q -t auditor-c2-a10-actual:local --build-arg PYTHON_VERSION=3.12.15 "${EXAMPLES:?ruta de Examples}/A-plantillas/repo/imagen" >/dev/null && echo "   docker build rc=0"
docker run --rm --user "$(id -u):$(id -g)" -e HOME=/tmp -v "$T":/w -w /w auditor-c2-a10-actual:local bash -c '
git config --global --add safe.directory /w; bash tools/ci/compuerta.sh | grep -E "texto|resultado"; echo "   rc=${PIPESTATUS[0]}"'
echo "== 8. YAML de A.12 propuesto"
docker run --rm -v "$T":/w -w /w python:3.12-slim sh -c 'pip -q install --disable-pip-version-check pyyaml==6.0.3 >/dev/null 2>&1; python -c "import yaml;d=yaml.safe_load(open(\".github/workflows/ci.yml\"));j=d[\"jobs\"][\"compuerta\"];print(\"   ci.yml: YAML válido; permissions:\",d[\"permissions\"],\"| container con credentials:\",\"credentials\" in j[\"container\"])"'
