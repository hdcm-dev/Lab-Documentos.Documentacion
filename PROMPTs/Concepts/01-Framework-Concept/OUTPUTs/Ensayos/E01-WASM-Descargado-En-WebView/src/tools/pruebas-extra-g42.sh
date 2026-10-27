#!/usr/bin/env bash
# E01 — pruebas adicionales en el g42 (después de correr-ensayo.sh g42, con v2 instalada):
#   4) manifiesto "v3" que apunta al zip de v1 con un sha256 adulterado -> debe rechazarse y seguir en v2
#   5) toque real del botón device.info (input tap) -> segunda llamada al puente
set -uo pipefail
E="$(cd "$(dirname "$0")/../.." && pwd)"
PKG=com.frameworkconcept.ensayo01
A="docker exec adb-contenedor adb -H 203.0.113.30 -P 5037 -s <serie-del-g42>"
SRV="$E/evidencia/local/servidor"; EV="$E/evidencia"; R="$EV/corrida-g42-extra.log"; : > "$R"
log() { echo "[$(date +%H:%M:%S)] $*" | tee -a "$R"; }
ACT=$($A shell cmd package resolve-activity --brief $PKG | tail -1 | tr -d '\r')

printf '{"version":"v3","archivo":"contenido-v1.zip","sha256":"%s","tamano":3394811}\n' \
  0000000000000000000000000000000000000000000000000000000000000000 > "$SRV/manifest.json"
log "servidor: manifest -> v3 con sha256 adulterado"
$A shell am force-stop $PKG; $A logcat -c
$A shell am start -W -n "$ACT" | tr -d '\r' | grep -E 'TotalTime' | tee -a "$R"
sleep 30
$A logcat -d -v time | tr -d '\r' | grep -E 'I/E01|Uncaught' | grep -v 'req#' | tee "$EV/logcat-g42-4-sha-adulterado.txt" | sed 's/^/    /' | tee -a "$R"
$A exec-out screencap -p > "$E/evidencia/local/captura-g42-4-sha-adulterado.png"
log "captura-g42-4 sha256=$(sha256sum "$E/evidencia/local/captura-g42-4-sha-adulterado.png" | cut -c1-64)"

log "toque en el botón device.info (194,1068 en 1080x2400)"
$A logcat -c
$A shell input tap 194 1068
sleep 4
$A logcat -d -v time | tr -d '\r' | grep -E 'puente DeviceInfo' | tee "$EV/logcat-g42-5-toque.txt" | sed 's/^/    /' | tee -a "$R"

cp "$SRV/manifest-v2.json" "$SRV/manifest.json"; log "servidor: manifest -> v2 (restaurado)"
log "fin"
