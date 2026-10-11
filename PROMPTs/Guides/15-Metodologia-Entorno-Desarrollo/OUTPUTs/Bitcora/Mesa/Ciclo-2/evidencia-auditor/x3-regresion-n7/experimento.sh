#!/usr/bin/env bash
# X3: regresión de N7 con la compuerta propuesta (E7-01, E7-03, E7-07 Node y Python). Copia N2 y N7 a un
# directorio temporal, reemplaza compuerta/compuerta.sh y corre los run.sh como lo hace correr-todo.sh.
# Uso: EXAMPLES=<ruta a Examples> bash experimento.sh
set -u
AQUI=$(cd "$(dirname "$0")" && pwd); T=$(mktemp -d); trap 'rm -rf "$T"' EXIT
cp -a "$EXAMPLES/N2-politica-de-texto-y-remediacion" "$EXAMPLES/N7-compuertas-y-gobierno" "$T/"
cp "$AQUI/../propuestas/repo/tools/ci/compuerta.sh" "$T/N7-compuertas-y-gobierno/compuerta/compuerta.sh"
en() { local img=$1; shift; docker run --rm --user "$(id -u):$(id -g)" -e HOME=/tmp -e DOTNET_NOLOGO=1 \
  -e DOTNET_CLI_TELEMETRY_OPTOUT=1 -e npm_config_cache=/tmp/npm -v "$T":/ex -w /ex/N7-compuertas-y-gobierno "$img" "$@"; }
for x in "lab-n2-texto:local 01-misma-compuerta-local-y-ci/run.sh E7-01-misma-compuerta-local-y-ci" \
         "lab-n2-texto:local 03-revisor-cambios-de-entorno/run.sh E7-03-revisor-cambios-de-entorno" \
         "lab-n7-node:local 07-misma-compuerta-otros-ecosistemas/run.sh_node E7-07-otros-ecosistemas-node" \
         "lab-n7-python:local 07-misma-compuerta-otros-ecosistemas/run.sh_python E7-07-otros-ecosistemas-python"; do
  set -- $x; img=$1; scr=${2%_*}; arg=""; [ "$scr" != "$2" ] && arg=${2##*_}
  echo "=== $3 ($img)"
  en "$img" bash "$scr" $arg > "$T/nueva.txt" 2>&1
  grep -E 'resultado=|-> rc=|\[FALLA\]' "$T/nueva.txt" | sed 's/commit=[0-9a-f]*//' > "$T/a"
  grep -E 'resultado=|-> rc=|\[FALLA\]' "$EXAMPLES/N7-compuertas-y-gobierno/salidas/$3.txt" | sed 's/commit=[0-9a-f]*//' > "$T/b"
  if diff "$T/b" "$T/a" >/dev/null; then echo "   veredictos y códigos iguales a la salida versionada ($(wc -l < "$T/a") líneas)"; else echo "   DIFIEREN:"; diff "$T/b" "$T/a" | sed 's/^/   /'; fi
done
