#!/usr/bin/env bash
cd "$(dirname "$0")"
python3 -I pc06.py qwen2.5:0.5b 5 185 > pc06-qwen2.5-0.5b.jsonl 2> pc06-stderr-05b.txt
python3 -I pc06.py qwen3.5:4b 5 0 > pc06-qwen3.5-4b-corto.jsonl 2> pc06-stderr-4b.txt
