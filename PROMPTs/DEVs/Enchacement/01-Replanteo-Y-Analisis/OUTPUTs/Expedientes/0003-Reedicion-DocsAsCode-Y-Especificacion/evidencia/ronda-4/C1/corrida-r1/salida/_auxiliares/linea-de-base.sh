#!/usr/bin/env bash
# Línea de base de cada control (A-08), sobre el árbol montado: LG del SHA leído más los artefactos de salida/LG.
# Se corre con: ./aislado bash salida/_auxiliares/linea-de-base.sh
# Salida: salida/_auxiliares/linea-de-base-<carpeta>.txt, una sección por control.
set -u
A=/corrida/salida/_auxiliares
cd $A/montaje/LG
DG=.docs-guard/tools/docs-guard/dg.py
py() { python3 -I $DG "$@"; }
export GITHUB_ACTIONS=false
for C in SDD docs; do
  out=$A/linea-de-base-$C.txt
  : > $out
  for ctl in fuera esquema ai mermaid-arroba trazas contratos fijadas reflint url-fecha avisos; do
    { echo "\$ python3 -I $DG $ctl $C"; py $ctl $C 2>&1 | tail -3; echo "rc=${PIPESTATUS[0]}"; echo; } >> $out
  done
  { echo "\$ lychee --offline --include-fragments --no-progress --config .docs-guard/scripts/docs-guard.lychee.toml $C"
    $DOCS_GUARD_CACHE/lychee-0.18.1/lychee --offline --include-fragments --no-progress --config .docs-guard/scripts/docs-guard.lychee.toml $C 2>&1 | tail -4; echo "rc=${PIPESTATUS[0]}"; echo; } >> $out
  { echo "\$ npx --yes markdownlint-cli2@0.17.2 --config .docs-guard/scripts/docs-guard.markdownlint-cli2.jsonc \"$C/**/*.md\""
    npx --yes markdownlint-cli2@0.17.2 --config .docs-guard/scripts/docs-guard.markdownlint-cli2.jsonc "$C/**/*.md" 2>&1 | tail -4; echo "rc=${PIPESTATUS[0]}"; echo; } >> $out
done
# Punteros de la raíz que ci-local.sh suma a PR-1, PR-3, PR-4 y PR-5
out=$A/linea-de-base-punteros.txt
: > $out
for ctl in ai trazas; do
  { echo "\$ python3 -I $DG $ctl AGENTS.md README.md"; py $ctl AGENTS.md README.md 2>&1 | tail -3; echo "rc=${PIPESTATUS[0]}"; echo; } >> $out
done
{ echo "\$ npx --yes markdownlint-cli2@0.17.2 --config .docs-guard/scripts/docs-guard.markdownlint-cli2.jsonc AGENTS.md"
  npx --yes markdownlint-cli2@0.17.2 --config .docs-guard/scripts/docs-guard.markdownlint-cli2.jsonc AGENTS.md 2>&1 | tail -4; echo "rc=${PIPESTATUS[0]}"; } >> $out
