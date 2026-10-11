#!/usr/bin/env bash
# Ciclo 3 · lector sin contexto (implementador ingenuo). Receta de punta a punta sobre la guía 1.0.0:
# CTX-NET «archivos mínimos» de §3.6 (A.1 variante B, A.2, A.3, A.4, A.4b, A.5, A.6, A.18),
# A.11 «Qué se copia y adónde» (con el chmod que ahora indica), A.12 guardado como lo nombra
# su propio campo `name:` y A.17. Solución sintética creada por el SDK, heredada «ya convertida
# a UTF-8 con BOM», como el caso. NO es Windows: se mide git, la compuerta y los scripts.
# Uso: docker run --rm -u "$(id -u):$(id -g)" -e HOME=/tmp -v <Examples>:/ex:ro -v <esta carpeta>:/out \
#        lab-n2-texto:local bash /out/receta-ciclo3.sh
set -u
EX=/ex; R=$EX/A-plantillas/repo; W=/tmp/w; rm -rf "$W"; mkdir -p "$W"; cd "$W"
git config --global user.email lector@ejemplo.invalid; git config --global user.name lector
git config --global init.defaultBranch main
echo "== SDK: $(dotnet --version) · git $(git --version | cut -d' ' -f3)"

echo; echo "######## 1. Solución heredada con BOM + archivos mínimos de CTX-NET (§3.6) ########"
mkdir sol && cd sol && git init -q
dotnet new sln -n Heredado >/dev/null
dotnet new console -n App -o src/App >/dev/null
dotnet new classlib -n Lib -o src/Lib >/dev/null
dotnet sln add src/App/App.csproj src/Lib/Lib.csproj >/dev/null
for f in $(find src -name "*.cs" -o -name "*.csproj"); do
  head -c3 "$f" | od -An -tx1 | grep -q "ef bb bf" || { printf '\xef\xbb\xbf' | cat - "$f" > t && mv t "$f"; }; done
# §3.6, CTX-NET, «Archivos mínimos»: .editorconfig, .gitattributes, global.json,
# Directory.Build.props, Directory.Packages.props, nuget.config (+ A.4b y A.18)
cp $R/.editorconfig $R/.gitattributes $R/global.json $R/Directory.Build.props $R/Directory.Build.targets \
   $R/Directory.Packages.props $R/nuget.config $R/.gitignore .
# A.1 variante B, «descomentar» las dos líneas
sed -i 's/^# \[\*\.{cs,csproj,props,targets}\]$/[*.{cs,csproj,props,targets}]/; s/^# charset = utf-8-bom$/charset = utf-8-bom/' .editorconfig
grep -n -A1 '^\[\*\.{cs' .editorconfig | sed 's/^/   /'
# Lo que dice el comentario de la variante B: «los Directory.Build.* de este anexo se guardan entonces con BOM»
for f in Directory.Build.props Directory.Build.targets; do printf '\xef\xbb\xbf' | cat - "$f" > t && mv t "$f"; done
# A.11, «Qué se copia y adónde», con el chmod que indica
mkdir -p tools/ci .githooks
cp $EX/N7-compuertas-y-gobierno/compuerta/compuerta.sh $EX/N2-politica-de-texto-y-remediacion/tools/check_text_policy.py tools/ci/
cp $R/.githooks/pre-commit .githooks/
git config core.hooksPath .githooks
dotnet restore Heredado.sln >/dev/null 2>&1
git add -A && git update-index --chmod=+x tools/ci/compuerta.sh .githooks/pre-commit
chmod +x tools/ci/compuerta.sh .githooks/pre-commit
echo "-- modos: $(git ls-files -s tools/ci/compuerta.sh .githooks/pre-commit | awk '{printf "%s %s; ", $1, $4}')"
echo "-- primer commit con el hook activado (sin --no-verify):"
git commit -m "política de entorno" 2>&1 | grep -v '^warning: in the working copy' | sed 's/^/   /'; echo "   rc=${PIPESTATUS[0]}"
echo "-- control: Directory.Packages.props también con BOM:"
printf '\xef\xbb\xbf' | cat - Directory.Packages.props > t && mv t Directory.Packages.props; git add Directory.Packages.props
git commit -m "política de entorno" 2>&1 | grep -E 'COMPUERTA|POLITICA' | sed 's/^/   /'; echo "   rc=${PIPESTATUS[0]}"

echo; echo "######## 2. A.12 guardado con el nombre que da su campo name: (compuerta) y A.17 ########"
mkdir -p .github/workflows
# El bloque A.12 de la guía, guardado como .github/workflows/compuerta.yml
cp $R/.github/workflows/ci.yml .github/workflows/compuerta.yml
grep -n '^name:\|image: ghcr' .github/workflows/compuerta.yml | sed 's/^/   /'
cp $R/tools/ci/registrar-entorno.sh tools/ci/
echo "-- A.17 (registrar-entorno.sh), línea de imagen, con el workflow como compuerta.yml:"
bash tools/ci/registrar-entorno.sh 2>/dev/null | grep '^imagen=' | sed 's/^/   /'
mv .github/workflows/compuerta.yml .github/workflows/ci.yml
echo "-- control, el mismo archivo como ci.yml:"
bash tools/ci/registrar-entorno.sh 2>/dev/null | grep '^imagen=' | sed 's/^/   /'
