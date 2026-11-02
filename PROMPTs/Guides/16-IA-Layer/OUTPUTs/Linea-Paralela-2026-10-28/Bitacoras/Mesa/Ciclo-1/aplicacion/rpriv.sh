#!/usr/bin/env bash
# Compuerta R-PRIV (Parche P-01, ciclo 1, con el ajuste vinculante del juez de evidencia).
# Uso: RPRIV_LISTA=<archivo privado fuera del repo> rpriv.sh <raíz> [--detalle]
# Informa «patrones=» e «identificadores=» por separado. Sale 0 sólo si los dos dan 0;
# el cierre sobre OUTPUTs/ lee «patrones=0» (los identificadores informan y no bloquean
# salvo dictamen de la presidencia, C1-39). Con --detalle lista archivo:cantidad, sin el texto.
set -u
RAIZ="${1:?raíz}"
FIN='([^0-9.]|\.([^0-9]|$)|$)'
P="/home/[A-Za-z0-9._-]+|(^|[^0-9.])100\.(6[4-9]|[7-9][0-9]|1[01][0-9]|12[0-7])\.[0-9]{1,3}\.[1-9][0-9]{0,2}${FIN}|(^|[^0-9.])(10\.[0-9]{1,3}|192\.168|172\.(1[6-9]|2[0-9]|3[01]))\.[0-9]{1,3}\.[1-9][0-9]{0,2}${FIN}|[A-Za-z0-9._-]+@[0-9]{1,3}(\.[0-9]{1,3}){3}"
[ -s "${RPRIV_LISTA:-}" ] || { echo "RPRIV_LISTA ausente" >&2; exit 2; }
n1=$(grep -rEnI --exclude-dir=bin --exclude-dir=obj -e "$P" "$RAIZ" | wc -l)
n2=$(grep -rnIwF --exclude-dir=bin --exclude-dir=obj -f "$RPRIV_LISTA" "$RAIZ" | wc -l)
echo "$(date -Iseconds) raiz=$(basename "$RAIZ") patrones=$n1 identificadores=$n2"
if [ "${2:-}" = "--detalle" ]; then
  echo "-- patrones por archivo"; grep -rEcI --exclude-dir=bin --exclude-dir=obj -e "$P" "$RAIZ" | grep -v ':0$' | sed "s#^$RAIZ/##"
  echo "-- identificadores por archivo"; grep -rcIwF --exclude-dir=bin --exclude-dir=obj -f "$RPRIV_LISTA" "$RAIZ" | grep -v ':0$' | sed "s#^$RAIZ/##"
fi
[ "$n1" -eq 0 ] && [ "$n2" -eq 0 ]
