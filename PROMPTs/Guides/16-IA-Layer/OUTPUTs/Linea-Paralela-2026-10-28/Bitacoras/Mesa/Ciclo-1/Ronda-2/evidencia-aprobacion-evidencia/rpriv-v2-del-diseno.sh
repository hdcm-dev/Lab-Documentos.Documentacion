#!/usr/bin/env bash
# Compuerta R-PRIV v2 (P2-01): los cuatro patrones y RPRIV_LISTA de P-01, más los
# encabezados por pedido serializados en cuerpos capturados (PC-03, OllamaSharp 5.5.0).
# Uso: RPRIV_LISTA=<privado> RPRIV_SINTETICOS=<objetos sintéticos> rpriv.sh <raíz> [--detalle]
set -u
RAIZ="${1:?raíz}"
FIN='([^0-9.]|\.([^0-9]|$)|$)'
P="/home/[A-Za-z0-9._-]+|(^|[^0-9.])100\.(6[4-9]|[7-9][0-9]|1[01][0-9]|12[0-7])\.[0-9]{1,3}\.[1-9][0-9]{0,2}${FIN}|(^|[^0-9.])(10\.[0-9]{1,3}|192\.168|172\.(1[6-9]|2[0-9]|3[01]))\.[0-9]{1,3}\.[1-9][0-9]{0,2}${FIN}|[A-Za-z0-9._-]+@[0-9]{1,3}(\.[0-9]{1,3}){3}"
CH='"<clave-de-cabeceras>":\{[^}]+\}'
CAP=(--include='*.jsonl' --include='*.json' --include='*.ndjson' --include='*.txt' --include='*.log')
[ -s "${RPRIV_LISTA:-}" ] || { echo "RPRIV_LISTA ausente" >&2; exit 2; }
SINT="${RPRIV_SINTETICOS:-/dev/null}"
n1=$(grep -rEnI --exclude-dir=bin --exclude-dir=obj -e "$P" "$RAIZ" | wc -l)
n2=$(grep -rnIwF --exclude-dir=bin --exclude-dir=obj -f "$RPRIV_LISTA" "$RAIZ" | wc -l)
n3=$(grep -rhoEI --exclude-dir=bin --exclude-dir=obj "${CAP[@]}" -e "$CH" "$RAIZ" | grep -vxF -f "$SINT" | wc -l)
echo "$(date -Iseconds) raiz=$(basename "$RAIZ") patrones=$n1 identificadores=$n2 cabeceras=$n3"
if [ "${2:-}" = "--detalle" ]; then
  echo "-- cabeceras por archivo"; grep -rcEI --exclude-dir=bin --exclude-dir=obj "${CAP[@]}" -e "$CH" "$RAIZ" | grep -v ':0$' | sed "s#^$RAIZ/##"
fi
[ "$n1" -eq 0 ] && [ "$n2" -eq 0 ] && [ "$n3" -eq 0 ]
