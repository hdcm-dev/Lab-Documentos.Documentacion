#!/usr/bin/env bash
# PC-07: memoria del contenedor y del anfitrión con el modelo cargado. Se corre en estación 2 por ssh (sin escribir direcciones).
echo "fecha=$(date -Is)"
docker stats --no-stream --format 'contenedor={{.Name}} mem={{.MemUsage}} memperc={{.MemPerc}} cpu={{.CPUPerc}}' <ollama-estación-2>
free -m | sed -n '1,3p'
docker exec <ollama-estación-2> ollama ps
