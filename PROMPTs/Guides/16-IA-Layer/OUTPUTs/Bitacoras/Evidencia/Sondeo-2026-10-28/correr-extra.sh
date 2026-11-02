#!/usr/bin/env bash
# Corridas complementarias: sinónimo «a pie» -> clave «caminata» (10x2) y qwen3.5:4b con razonamiento por defecto (5).
set -u
cd "$(dirname "$0")"; OUT=${OUT:-salidas}; S="python3 -I sondeo.py"
date -Is > "$OUT/05-fecha.txt"
for m in qwen2.5:0.5b qwen3.5:4b; do SONDEO_VARIANTE=apie $S tools "$m" 10 >> "$OUT/05-tools-apie.jsonl" 2>&1; done
SONDEO_RAZONAR=1 $S tools qwen3.5:4b 5 > "$OUT/06-tools-razonando.jsonl" 2>&1
date -Is >> "$OUT/05-fecha.txt"
