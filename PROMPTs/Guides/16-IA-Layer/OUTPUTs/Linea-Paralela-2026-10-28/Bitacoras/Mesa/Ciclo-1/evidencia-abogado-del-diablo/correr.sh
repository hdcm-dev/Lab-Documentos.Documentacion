#!/usr/bin/env bash
# ABOGAD: alternativa de MI-02. Baja qwen3.5:2b al Ollama propio en contenedor (estación 1), corre la misma
# sonda de herramientas del sondeo del 2026-10-28 (bici y «a pie», N = 10, T 0.7, seeds 1..10,
# reasoning_effort none) con el 2b y, en la misma ventana, con el 4b; mide pared; y borra el 2b.
# Criterio de éxito (escrito antes): tool_call única, nombre correcto, medio == esperado.
# Requiere OLLAMA_ENDPOINT (no se imprime, R-PRIV).
set -u
cd "$(dirname "$0")"; OUT=salidas; S="python3 -I sondeo.py"
date -Is > $OUT/00-fecha.txt
docker exec <ollama> ollama pull qwen3.5:2b > $OUT/01-pull-resumen.txt 2>&1
$S info > $OUT/02-info.jsonl 2>&1
for m in qwen3.5:2b qwen3.5:4b; do
  SONDEO_VARIANTE=bici $S tools "$m" 10 >> $OUT/03-tools-bici.jsonl 2>&1
  SONDEO_VARIANTE=apie $S tools "$m" 10 >> $OUT/04-tools-apie.jsonl 2>&1
done
$S ps > $OUT/05-ps.jsonl 2>&1
docker exec <ollama> ollama rm qwen3.5:2b > $OUT/06-rm.txt 2>&1
docker exec <ollama> ollama list > $OUT/07-list-final.txt 2>&1
date -Is >> $OUT/00-fecha.txt
