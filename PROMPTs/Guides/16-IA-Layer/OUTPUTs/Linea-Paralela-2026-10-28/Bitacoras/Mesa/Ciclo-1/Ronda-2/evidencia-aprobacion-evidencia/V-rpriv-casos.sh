#!/usr/bin/env bash
# Casos de la aprobación (juez de evidencia, ronda 2): formas de <clave-de-cabeceras> que el patrón del diseño no ve.
# Uso: V-rpriv-casos.sh <script rpriv> <lista de prueba> <sintéticos>; corre en una carpeta temporal propia.
set -u; G="$1"; L="$2"; SI="$3"; T=$(mktemp -d)
printf '%s\n' '{"msg":"{\"<clave-de-cabeceras>\":{\"Authorization\":\"Bearer ABC\"}}"}' > "$T/a-escapado.jsonl"
printf '%s\n' '{"<clave-de-cabeceras>": {"Authorization": "Bearer ABC"}}' > "$T/b-con-espacios.json"
printf '%s\n' '{' '  "<clave-de-cabeceras>": {' '    "Authorization": "Bearer ABC"' '  }' '}' > "$T/c-indentado.json"
printf '%s\n' '{"<clave-de-cabeceras>": { }}' '{"<clave-de-cabeceras>":{}}' > "$T/d-vacios.json"
for f in a-escapado.jsonl b-con-espacios.json c-indentado.json d-vacios.json; do
  U=$(mktemp -d); cp "$T/$f" "$U/"; printf '%s: ' "$f"; RPRIV_LISTA="$L" RPRIV_SINTETICOS="$SI" bash "$G" "$U" | sed 's/^[^ ]* //'; rm -rf "$U"; done
rm -rf "$T"
