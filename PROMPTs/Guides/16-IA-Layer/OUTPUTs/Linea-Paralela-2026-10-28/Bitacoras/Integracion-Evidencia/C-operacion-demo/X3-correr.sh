#!/usr/bin/env bash
set -u; cd "$(dirname "$0")"; mkdir -p salidas
date -Is > salidas/x3-fecha.txt
python3 -I ventana.py qwen2.5:0.5b > salidas/x3-ventana-qwen2.5-0.5b.jsonl 2>&1
date -Is >> salidas/x3-fecha.txt
