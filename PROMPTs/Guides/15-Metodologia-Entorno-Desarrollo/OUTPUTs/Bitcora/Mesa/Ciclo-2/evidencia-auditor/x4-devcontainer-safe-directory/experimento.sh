#!/usr/bin/env bash
# X4 (C2-11): el devcontainer de A.9 con safe.directory en postCreateCommand, levantado con la CLI de
# referencia en un host Linux (el repo pertenece al usuario; el contenedor corre como root).
# Uso, desde el host: bash experimento.sh   (Docker, Node/npx y red)
set -u
AQUI=$(cd "$(dirname "$0")" && pwd); T=$(mktemp -d); W=$T/dc
mkdir -p "$W"; cp -a "$AQUI/../propuestas/repo/." "$W/"
cd "$W" && git init -q -b main . && git -c user.email=lab@ejemplo.invalid -c user.name=lab add -A \
  && git -c user.email=lab@ejemplo.invalid -c user.name=lab commit -qm plantillas && echo "repo del usuario uid=$(id -u)"
echo "postCreateCommand: $(grep -o '"postCreateCommand": .*' .devcontainer/devcontainer.json)"
npx -y @devcontainers/cli@0.89.0 up --workspace-folder "$W" > "$T/up.json" 2> "$T/up.err"; echo "devcontainer up rc=$?"
grep -o '"outcome":"[a-z]*"' "$T/up.json"
grep -E 'dubious|fatal|failed' "$T/up.err" | head -3
npx -y @devcontainers/cli@0.89.0 exec --workspace-folder "$W" sh -c 'echo "en el contenedor: uid=$(id -u) core.hooksPath=$(git config core.hooksPath) status=$(git status --porcelain | wc -l) cambios"'
id=$(grep -o '"containerId":"[0-9a-f]*"' "$T/up.json" | cut -d'"' -f4); [ -n "$id" ] && docker rm -f "$id" >/dev/null && echo "contenedor eliminado"
rm -rf "$T"
