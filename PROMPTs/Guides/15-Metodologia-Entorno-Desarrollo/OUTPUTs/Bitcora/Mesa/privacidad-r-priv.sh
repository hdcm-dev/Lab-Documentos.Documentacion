#!/usr/bin/env bash
# Chequeo R-PRIV de la guía 15: el mismo grep que registran las bitácoras de la mesa (Ciclo-1 a Ciclo-3),
# con los identificadores privados leídos de un archivo de patrones local, alias <patrón-R-PRIV>.
#
# El archivo no se versiona (repositorio público). Se busca, en este orden:
#   1. la ruta de la variable PATRON_R_PRIV;
#   2. patron-R-PRIV.local.txt junto a este guion (ignorado por .gitignore).
# Formato: una expresión extendida por línea; se corre sin distinguir mayúsculas (-i).
#
# Uso: privacidad-r-priv.sh <guía.md> [<Examples/> …]
# Salida: las coincidencias (fuera de bin/obj/node_modules/.venv); exit 0 sin coincidencias, 1 con
# coincidencias, 2 si falta el archivo de patrones (no se puede afirmar R-PRIV).
set -u
dir=$(cd "$(dirname "$0")" && pwd)
pat=${PATRON_R_PRIV:-$dir/patron-R-PRIV.local.txt}
if [ ! -s "$pat" ]; then
  echo "R-PRIV: no hay <patrón-R-PRIV> (PATRON_R_PRIV o patron-R-PRIV.local.txt); chequeo no ejecutado" >&2
  exit 2
fi
[ "$#" -gt 0 ] || { echo "uso: $0 <guía.md> [<Examples/> …]" >&2; exit 2; }
salida=$(grep -rn -i -E -f "$pat" "$@" | grep -v -E "/(bin|obj|node_modules|\.venv)/")
if [ -n "$salida" ]; then printf '%s\n' "$salida"; exit 1; fi
echo "R-PRIV: sin coincidencias ($(grep -c . "$pat") expresiones)"
