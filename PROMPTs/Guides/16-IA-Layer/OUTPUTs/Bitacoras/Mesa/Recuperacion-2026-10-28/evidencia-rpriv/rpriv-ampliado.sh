#!/usr/bin/env bash
# Barrido S2 ampliado (mesa de recuperación 2026-10-28, inventariador «rpriv»).
# Complementa la compuerta v2 de la línea archivada (Linea-<fecha>/Bitacoras/Mesa/Ciclo-1/Ronda-2/aplicacion/rpriv.sh)
# con las clases que esa compuerta no ve (plan de integración de la otra sesión, R5 y A2):
# IP parcial y /16 de la red privada, «-home-<usuario>-», usuario delante de una máscara, cualquier mención de la
# clave de cabeceras por pedido, nombres de contenedores y volúmenes del laboratorio, herramienta y recursos de turnos.
# Los identificadores (equipos, usuario, apps y organizaciones privadas) se leen de RPRIV_LISTA, que vive fuera del repo.
# Informa por clase y por archivo, nunca el texto. Los literales están partidos para que el script no se marque a sí mismo.
# Uso: RPRIV_LISTA=<privado, fuera de la raíz> rpriv-ampliado.sh <raíz> [<raíz>...]
set -u
[ -s "${RPRIV_LISTA:-}" ] || { echo "RPRIV_LISTA ausente" >&2; exit 2; }
declare -A C=(
  [ip-parcial]='(^|[^0-9A-Za-z.§])(100\.(6[4-9]|[7-9][0-9xX]|1[01][0-9xX]|12[0-7])|192\.168|172\.(1[6-9]|2[0-9]|3[01]))\.([0-9xX*]{1,3}|<)'
  [home]='/ho''me/[A-Za-z]|-ho''me-[A-Za-z]|~/[A-Za-z]'
  [usuario-mascara]='[A-Za-z][A-Za-z0-9._-]*@(<[a-z]|[0-9]{1,3}\.[0-9])'
  [cabeceras]='[Cc]ustom[Hh]eader''s'
  [contenedores]='ia-lay''er-[a-z0-9-]+|n3b?-(oll''ama|nu''get)\b'
  [turnos]='con-recur''so\.sh|(^|[^a-z-])recur''so\.sh|tools/medios/recur''sos|RECURSOS_DI''R|ollama-l''an|ollama-infra''vm'
)
rc=0
for RAIZ in "$@"; do
  echo "== $(date -Iseconds) raiz=$(basename "$RAIZ")"
  for k in ip-parcial home usuario-mascara cabeceras contenedores turnos; do
    n=$(grep -rEnI --exclude-dir=bin --exclude-dir=obj -e "${C[$k]}" "$RAIZ" | wc -l)
    f=$(grep -rlEI --exclude-dir=bin --exclude-dir=obj -e "${C[$k]}" "$RAIZ" | wc -l)
    echo "$k lineas=$n archivos=$f"; [ "$n" -eq 0 ] || rc=1
  done
  n=$(grep -rnIwF --exclude-dir=bin --exclude-dir=obj -f "$RPRIV_LISTA" "$RAIZ" | wc -l)
  f=$(grep -rlIwF --exclude-dir=bin --exclude-dir=obj -f "$RPRIV_LISTA" "$RAIZ" | wc -l)
  echo "identificadores lineas=$n archivos=$f"; [ "$n" -eq 0 ] || rc=1
  if [ "${DETALLE:-0}" = 1 ]; then
    for k in ip-parcial home usuario-mascara cabeceras contenedores turnos; do
      echo "-- $k por archivo"; grep -rcEI --exclude-dir=bin --exclude-dir=obj -e "${C[$k]}" "$RAIZ" | grep -v ':0$' | sed "s#^$RAIZ/##"
    done
    echo "-- identificadores por archivo"; grep -rcIwF --exclude-dir=bin --exclude-dir=obj -f "$RPRIV_LISTA" "$RAIZ" | grep -v ':0$' | sed "s#^$RAIZ/##"
  fi
done
exit $rc
