#!/usr/bin/env bash
# X5 (C2-12): A.1 con la variante B ampliada a [*.{cs,csproj,props,targets}] sobre un heredado ya
# convertido a UTF-8 con BOM (como el caso), creado con el SDK. Dentro de lab-n2-texto:local:
#   docker run --rm -u "$(id -u):$(id -g)" -e HOME=/tmp -v <Examples>:/ex:ro -v "$PWD":/out lab-n2-texto:local bash /out/experimento.sh
set -u
W=/tmp/w; rm -rf $W; mkdir -p $W; cd $W; git init -q -b main .
dotnet new sln -n Heredado >/dev/null; dotnet new console -n App -o src/App >/dev/null; dotnet new classlib -n Lib -o src/Lib >/dev/null
for f in $(find src -name '*.cs' -o -name '*.csproj'); do head -c3 "$f" | od -An -tx1 | grep -q 'ef bb bf' || { printf '\xef\xbb\xbf' | cat - "$f" > t && mv t "$f"; }; done
printf 'bin/\nobj/\n' > .gitignore   # A.18
R=/ex/A-plantillas/repo; cp $R/.editorconfig $R/.gitattributes $R/Directory.Build.props $R/Directory.Build.targets .
POL="python3 /ex/N2-politica-de-texto-y-remediacion/tools/check_text_policy.py"
git add -A; echo "== A.1 tal cual (variante A)"; $POL | tail -1
sed -i 's/^# \[\*\.cs\]$/[*.{cs,csproj,props,targets}]/; s/^# charset = utf-8-bom$/charset = utf-8-bom/' .editorconfig
grep -n -A1 '^\[\*\.{cs' .editorconfig | sed 's/^/   /'; git add -A
echo "== Variante B ampliada, con Directory.Build.* copiados del Anexo A (sin BOM)"; $POL | sed 's/^/   /'
for f in Directory.Build.props Directory.Build.targets; do printf '\xef\xbb\xbf' | cat - "$f" > t && mv t "$f"; done; git add -A
echo "== Variante B ampliada, con Directory.Build.* guardados con BOM"; $POL | sed 's/^/   /'
