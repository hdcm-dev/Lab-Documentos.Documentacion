#!/usr/bin/env bash
set -u; cd "$(dirname "$0")"; mkdir -p salidas
date -Is > salidas/x2-fecha.txt
python3 -I escrituras.py qwen3.5:4b 10 > salidas/x2-escrituras-qwen3.5-4b.jsonl 2>&1
date -Is >> salidas/x2-fecha.txt
