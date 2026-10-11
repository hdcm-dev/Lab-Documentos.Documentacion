#!/bin/sh
# Abogado del diablo, ciclo 2, AD-05. El lector del caso (heredado YA convertido a UTF-8 con BOM, §1.4)
# copia A.1 tal cual (variante A activa) y después con la variante B descomentada.
# Verificador: editorconfig-checker 4.0.2 (misma lectura de .editorconfig que la compuerta propia, §5.2.5).
# Uso (host con docker): sh experimento.sh <dir-plantillas-A> <dir-trabajo>
set -u
P=$1; W=$2; EC=ghcr.io/editorconfig-checker/editorconfig-checker:4.0.2
rm -rf "$W"; mkdir -p "$W/src/Servicios"; cp "$P/.editorconfig" "$W/"; cd "$W" || exit 2
bom() { printf '\357\273\277'; }
for i in 1 2 3; do { bom; printf 'namespace S; class Alarma%s { string T = "Atenci\303\263n"; }\n' $i; } > src/Servicios/Alarma$i.cs; done
{ bom; printf '<Project Sdk="Microsoft.NET.Sdk"></Project>\n'; } > src/Servicios/Servicios.csproj
ec() { docker run --rm --network none -u "$(id -u):$(id -g)" -v "$W":/check:ro "$EC" /usr/bin/editorconfig-checker -no-color; }
echo "== A.1 tal cual (variante A): el heredado del caso, ya convertido con BOM (3 .cs + 1 .csproj)"
ec | grep -c 'wrong character encoding' | sed 's/^/   violaciones: /'
echo "== A.1 con la variante B descomentada ([*.cs] charset = utf-8-bom)"
sed -i 's/^# \[\*\.cs\]$/[*.cs]/; s/^# charset = utf-8-bom$/charset = utf-8-bom/' .editorconfig
grep -n -A1 '^\[\*\.cs\]' .editorconfig | sed 's/^/   /'
ec; echo "rc=$?"
