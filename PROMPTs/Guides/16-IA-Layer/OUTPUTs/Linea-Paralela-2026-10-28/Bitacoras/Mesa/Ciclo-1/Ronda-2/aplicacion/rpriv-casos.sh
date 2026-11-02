#!/usr/bin/env bash
# Casos rojos y verdes de la compuerta R-PRIV v2 (P2-01): los del diseño, los cuatro del juez de evidencia
# (V-rpriv-casos.sh) y el camelCase del juez de impacto. Cada caso corre en una carpeta temporal propia.
# Uso: rpriv-casos.sh <rpriv.sh> <RPRIV_LISTA de prueba fuera de la raíz> <sintéticos>
set -u; G="$1"; L="$2"; SI="$3"
caso() { U=$(mktemp -d); printf '%s\n' "${@:3}" > "$U/$2"; printf '%-34s esperado=%s  ' "$2" "$1"; RPRIV_LISTA="$L" RPRIV_SINTETICOS="$SI" bash "$G" "$U" | sed 's/^[^ ]* raiz=[^ ]* //' | tr -d '\n'; echo " rc=${PIPESTATUS[0]}"; rm -rf "$U"; }
caso "cabeceras=1" a-diseno-una-linea.jsonl '{"<clave-de-cabeceras>":{"Authorization":"Bearer ABC"}}'
caso "cabeceras=1" b-escapado.jsonl '{"msg":"{\"<clave-de-cabeceras>\":{\"Authorization\":\"Bearer ABC\"}}"}'
caso "cabeceras=1" c-con-espacios.json '{"<clave-de-cabeceras>": {"Authorization": "Bearer ABC"}}'
caso "cabeceras=1" d-indentado.json '{' '  "<clave-de-cabeceras>": {' '    "Authorization": "Bearer ABC"' '  }' '}'
caso "cabeceras=1" e-camelcase.json '{"<clave-de-cabeceras>":{"Authorization":"Bearer ABC"}}'
caso "cabeceras=0" f-vacios.json '{"<clave-de-cabeceras>": { }}' '{"<clave-de-cabeceras>":{}}'
caso "cabeceras=0" g-sintetico.txt '"<clave-de-cabeceras>":{"X-K":"v"}'
caso "patrones=1" h-ruta-home.md "ruta /ho""me/alguien/x"
