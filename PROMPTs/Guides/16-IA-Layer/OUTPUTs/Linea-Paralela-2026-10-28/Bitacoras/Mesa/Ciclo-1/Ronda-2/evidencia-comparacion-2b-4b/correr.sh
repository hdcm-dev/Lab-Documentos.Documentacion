#!/usr/bin/env bash
# C1R2 P-36/C1-41. Baja qwen3.5:2b, corre la comparación intercalada y borra el 2b. Endpoint sólo por variable.
set -u; cd "$(dirname "$0")"; OUT=salidas; mkdir -p $OUT
date -Is > $OUT/00-fecha.txt
docker exec <ollama> ollama list > $OUT/01-list-inicial.txt 2>&1
docker exec <ollama> ollama pull qwen3.5:2b 2>&1 | tr '\r' '\n' | grep -v '^pulling.*%' | tail -15 > $OUT/02-pull.txt
python3 -I comparacion.py 10 > $OUT/03-comparacion.jsonl 2>&1
echo "rc=$?" >> $OUT/00-fecha.txt
docker exec <ollama> ollama rm qwen3.5:2b > $OUT/04-rm.txt 2>&1
docker exec <ollama> ollama list > $OUT/05-list-final.txt 2>&1
date -Is >> $OUT/00-fecha.txt
