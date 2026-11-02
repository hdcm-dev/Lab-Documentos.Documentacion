#!/usr/bin/env bash
set -u; D={dir-de-trabajo}/c-operacion-demo
$D/tools/correr-x2.sh
$D/ctx/correr-x3.sh
t0=$(date -Is); docker logs --since 30m <ollama> 2>&1 | grep -i 'truncat' | sed -E 's/[0-9]{1,3}(\.[0-9]{1,3}){3}(:[0-9]+)?/<ip>/g' | tail -5 > $D/ctx/salidas/x3-logs-truncado.txt
echo "consultado $t0" >> $D/ctx/salidas/x3-logs-truncado.txt
