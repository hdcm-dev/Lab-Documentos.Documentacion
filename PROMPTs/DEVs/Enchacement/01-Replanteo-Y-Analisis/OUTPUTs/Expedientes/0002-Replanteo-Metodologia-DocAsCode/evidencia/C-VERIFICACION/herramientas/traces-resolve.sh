#!/bin/bash
# Resuelve cada traza ID@versión de las páginas de ayuda contra el SDD del sistema destino.
# Regla propuesta (Q38): el ID existe una sola vez fuera de _legacy, la versión coincide con la
# cabecera «**Versión:**», y una página de ayuda de pantalla traza a la unidad Web (CU-100NN).
# uso: traces-resolve.sh <dir-ayuda> <raiz-SDD>     exit 1 si alguna traza falla
A=$1; S=$2; rc=0
for f in $(find "$A" -name '*.md'); do
  for t in $(awk 'NR==1&&/^---/{f=1;next} f&&/^---/{exit} f&&/^traces:/' "$f" | grep -oE '(CU|RN)-[0-9]{5}@[0-9]+\.[0-9]+'); do
    id=${t%@*}; v=${t#*@}
    hits=$(find "$S" -path '*/_legacy' -prune -o -name "$id-*.md" -print)
    n=$(echo "$hits" | grep -c .)
    if [ "$n" -ne 1 ]; then echo "$f: $t no resuelve ($n archivos)"; rc=1; continue; fi
    hv=$(grep -m1 -oE '^\*\*Versión:\*\* *[0-9.]+' "$hits" | grep -oE '[0-9.]+$')
    u=$(grep -m1 -oE '^\*\*Unidad de entrega:\*\* *[A-Za-z.-]+' "$hits" | sed 's/.*\*\* *//')
    msg="$f: $t → unidad $u, versión $hv"
    [ "$hv" != "$v" ] && { echo "$msg: VERSIÓN DESFASADA"; rc=1; continue; }
    case "$id" in CU-1*) echo "$msg: ok";; *) echo "$msg: UNIDAD NO ES DE PANTALLA"; rc=1;; esac
  done
done; exit $rc
