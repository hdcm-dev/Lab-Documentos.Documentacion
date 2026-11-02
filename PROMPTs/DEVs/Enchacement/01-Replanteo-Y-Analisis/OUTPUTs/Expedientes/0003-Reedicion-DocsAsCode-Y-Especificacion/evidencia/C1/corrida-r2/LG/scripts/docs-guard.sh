#!/usr/bin/env bash
# Guion local de la compuerta documental: el mismo que corre la CI (.github/workflows/docs-guard.yml).
# Uso: bash scripts/docs-guard.sh [carpeta]   (por omisión, docs/)
#      bash scripts/docs-guard.sh --linea-de-base <carpeta>   (sólo avisa: medir lo heredado)
set -euo pipefail
cd "$(dirname "$0")/.."
if [[ "${1:-}" == "--linea-de-base" ]]; then
  exec python3 scripts/docs-guard.py "${2:?carpeta}" --solo-avisar
fi
exec python3 scripts/docs-guard.py "${1:-docs}"
