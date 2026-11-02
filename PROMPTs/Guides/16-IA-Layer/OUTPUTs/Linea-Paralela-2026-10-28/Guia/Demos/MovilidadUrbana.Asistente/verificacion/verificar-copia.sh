#!/usr/bin/env bash
# Verifica la copia literal de MovilidadUrbana.ApiWeb (ver PROCEDENCIA.md):
#   1. diff -r entre cada carpeta copiada y la del commit de origen;
#   2. dotnet build de la copia sola (sin Agregado/ ni Program.cs de la demo).
# Uso: verificar-copia.sh <clon de Lab-E2E.WebBlazor> [commit]
# Se corre dentro del SDK de .NET 10 o con git y dotnet en el PATH. No escribe en el clon de origen.
set -euo pipefail
origen_repo="${1:?uso: verificar-copia.sh <clon de Lab-E2E.WebBlazor> [commit]}"
commit="${2:-59399ba}"
aqui="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
demo="$(cd "$aqui/.." && pwd)"
tmp="$(mktemp -d)"; trap 'rm -rf "$tmp"' EXIT
git -C "$origen_repo" archive "$commit" src/MovilidadUrbana.ApiWeb | tar -x -C "$tmp"
o="$tmp/src/MovilidadUrbana.ApiWeb"
echo "commit de origen: $(git -C "$origen_repo" rev-parse "$commit")"
fallas=0
for c in Domain Application Contracts Controllers Sessions Infrastructure; do
  if diff -r "$o/$c" "$demo/src/MovilidadUrbana.Asistente/$c"; then echo "diff -r $c: 0 diferencias"; else echo "diff -r $c: HAY diferencias"; fallas=1; fi
done
echo "archivos de ApiWeb que NO se copian: $(cd "$o" && ls -1 | grep -vxE 'Domain|Application|Contracts|Controllers|Sessions|Infrastructure' | tr '\n' ' ')"
dotnet build "$aqui/CopiaSola/CopiaSola.csproj" -c Release \
  --property:BaseOutputPath="$tmp/bin/" --property:BaseIntermediateOutputPath="$tmp/obj/" -nologo
exit $fallas
