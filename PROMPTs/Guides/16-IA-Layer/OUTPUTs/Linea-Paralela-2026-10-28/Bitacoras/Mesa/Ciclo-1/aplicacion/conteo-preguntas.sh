#!/usr/bin/env bash
# Conteo de preguntas guía de los nueve núcleos (Parche P-09, ajuste del juez de evidencia). Uso: conteo-preguntas.sh <Bitacoras/Nucleos>
set -u; D="${1:?carpeta Nucleos}"; t=0
for f in N0b N1- N1b N2 N3- N3b N4 N5 N6; do
  a=$(ls "$D"/$f*.md); n=$(awk '/^## [0-9]+\. Preguntas/{s=1;next} /^## /{s=0} s' "$a" | grep -cE '^\*\*P(G-)?[0-9]+\.'); t=$((t+n)); echo "$(basename "$a") $n"; done
echo "total $t"
