#!/usr/bin/env bash
# T-qwen (D-04 c): 5 corridas por ejemplo, cada una con su turno <recurso-modelo> (vía verificar.sh) y su RLLM_DIR.
# El endpoint entra por OLLAMA_ENDPOINT del entorno del llamador; no se escribe en ningún archivo.
set -u
W={dir-de-trabajo} cd $W/guia
: "${OLLAMA_ENDPOINT:?}"
export TURNO_CMD=$W/turno.sh TURNO_MAPA=$W/turno.mapa VOLUMEN_NUGET=g16e1-nuget VOLUMEN_ARTEFACTOS=g16e1-artefactos ETIQUETA=proyecto=<dueño>
export OLLAMA_MODEL=qwen3.5:4b OLLAMA_SERVIDOR=propio RLLM_MAQUINA=estacion-1 RLLM_MAQUINA_PROPIO=estacion-1
export OLLAMA_VERSION_ESPERADA=0.40.11 DIGEST_4B_ESPERADO=d8b0f5e9760c DIGEST_EMB_ESPERADO=-
for e in ${EJEMPLOS:-08-Primera-Herramienta-Solo-Lectura 09-Caso-De-Uso-Como-Herramienta 11-Agente-Con-Aprobacion 13-Servidor-Y-Cliente-MCP 12-Uno-O-Varios-Agentes 16-Inyeccion-Indirecta}; do
  for s in 1 2 3 4 5; do
    d=$W/registros/tqwen/$e/s$s; mkdir -p $d
    [ -f $d/rc.txt ] && continue
    export RLLM_DIR=$d ETAPA_MOTIVO="T-qwen $e s$s"
    t0=$(date +%s); tools/verificar.sh correr $e --con-modelo > $d/consola.txt 2>&1; rc=$?
    echo "rc=$rc dur_s=$(( $(date +%s)-t0 )) fin=$(date -Is)" > $d/rc.txt
  done
done
