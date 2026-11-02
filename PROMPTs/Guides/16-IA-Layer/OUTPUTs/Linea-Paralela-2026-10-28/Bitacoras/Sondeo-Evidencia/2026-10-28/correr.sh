#!/usr/bin/env bash
# Corre el sondeo E1 completo. Requiere OLLAMA_ENDPOINT. Salida JSONL por paso en $OUT.
set -u
cd "$(dirname "$0")"; OUT=${OUT:-salidas}; mkdir -p "$OUT"
S="python3 -I sondeo.py"
date -Is > "$OUT/00-fecha.txt"
$S info > "$OUT/01-info.jsonl" 2>&1
for m in qwen2.5:0.5b qwen3.5:4b; do
  $S chat "$m" >> "$OUT/02-chat.jsonl" 2>&1; $S ps >> "$OUT/02-chat.jsonl" 2>&1
done
$S embed qwen3-embedding:0.6b > "$OUT/03-embed.jsonl" 2>&1; $S ps >> "$OUT/03-embed.jsonl" 2>&1
for m in qwen2.5:0.5b qwen3.5:4b; do $S tools "$m" 10 >> "$OUT/04-tools.jsonl" 2>&1; done
date -Is >> "$OUT/00-fecha.txt"
