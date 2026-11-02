#!/usr/bin/env bash
# correr.sh RAIZ COPIA RUTA SALIDA GRUPOS...  — corre los grupos de la copia del proyecto desde RAIZ
set -u
RAIZ="$1"; COPIA="$2"; RUTA="$3"; OUT="$4"; shift 4
: > "$OUT"; total=0
cd "$RAIZ" || exit 9
for g in "$@"; do
  bash "$COPIA/scripts/ci-local.sh" "$g" "$RUTA" >> "$OUT" 2>&1; rc=$?
  echo "rc[$g]=$rc" >> "$OUT"; [[ $rc -ne 0 ]] && total=1
done
echo "== agregado: $([[ $total -eq 0 ]] && echo verde || echo ROJO)" >> "$OUT"
exit $total
