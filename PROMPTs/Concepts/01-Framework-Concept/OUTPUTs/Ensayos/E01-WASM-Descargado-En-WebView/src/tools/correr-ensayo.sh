#!/usr/bin/env bash
# E01 — corrida reproducible en un dispositivo: instala el cascarón, arranca 3 veces y guarda logcat + capturas.
#   corrida 1: datos limpios, manifiesto v1  -> descarga e instala v1, la muestra
#   corrida 2: relanzar con v1               -> "al día", arranque sin descarga
#   corrida 3: manifiesto v2, relanzar       -> descarga v2, current=v2, previous=v1
# Uso (desde el host, con el ensayo en $E):
#   bash correr-ensayo.sh emu   (adb dentro de fc-android-emu, APK android-x64)
#   bash correr-ensayo.sh g42   (adb remoto de la PC del PO, APK android-arm64)
set -uo pipefail
E="$(cd "$(dirname "$0")/../.." && pwd)"
DISP="${1:?emu|g42}"
PKG=com.frameworkconcept.ensayo01
case "$DISP" in
  emu) A="docker exec fc-android-emu adb"; APK=/work/src/Cascaron/bin/Release/net10.0-android/android-x64/$PKG-Signed.apk ;;
  g42) A="docker exec adb-contenedor adb -H 203.0.113.30 -P 5037 -s <serie-del-g42>"
       APK=/tmp/fc-e01-$PKG-arm64.apk
       docker cp "$E/src/Cascaron/bin/Release/net10.0-android/android-arm64/$PKG-Signed.apk" adb-contenedor:$APK ;;
  *) echo "dispositivo desconocido"; exit 2 ;;
esac
EV="$E/evidencia"; LOC="$EV/local"; SRV="$LOC/servidor"
mkdir -p "$EV" "$LOC"
R="$EV/corrida-$DISP.log"
: > "$R"
log() { echo "[$(date +%H:%M:%S)] $*" | tee -a "$R"; }

log "install $APK"
$A install -r "$APK" 2>&1 | tail -1 | tee -a "$R"
log "pm clear (sólo el paquete del ensayo)"
$A shell pm clear $PKG 2>&1 | tee -a "$R"
ACT=$($A shell cmd package resolve-activity --brief $PKG | tail -1 | tr -d '\r')
log "actividad: $ACT"

arrancar() {  # $1 = etiqueta, $2 = espera en s
  $A shell am force-stop $PKG
  $A logcat -c
  log "--- corrida $1: am start -W"
  $A shell am start -W -n "$ACT" 2>&1 | tr -d '\r' | grep -E 'Status|TotalTime|WaitTime' | tee -a "$R"
  sleep "$2"
  $A logcat -d -v time 2>/dev/null | tr -d '\r' | grep -E 'I/E01|E01-|chromium|Console|AndroidRuntime|FATAL|monodroid-assembly' > "$EV/logcat-$DISP-$1.txt"
  grep -E 'I/E01|E01-|Uncaught|FATAL' "$EV/logcat-$DISP-$1.txt" | grep -vE 'req#' | sed 's/^/    /' | tee -a "$R"
  echo "    requests interceptadas: $(grep -c '→ content/current' "$EV/logcat-$DISP-$1.txt"), sin manejar: $(grep -c 'sin manejar' "$EV/logcat-$DISP-$1.txt")" | tee -a "$R"
  $A exec-out screencap -p > "$LOC/captura-$DISP-$1.png"
  log "captura: evidencia/local/captura-$DISP-$1.png sha256=$(sha256sum "$LOC/captura-$DISP-$1.png" | cut -c1-64)"
  log "en el dispositivo: $($A shell run-as $PKG sh -c "'cat files/content/current/.version; echo; ls files/content'" 2>&1 | tr '\n' ' ')"
}

cp "$SRV/manifest-v1.json" "$SRV/manifest.json"; log "servidor: manifest -> v1"
arrancar 1-v1-limpio 45
arrancar 2-v1-relanzar 30
cp "$SRV/manifest-v2.json" "$SRV/manifest.json"; log "servidor: manifest -> v2"
arrancar 3-v2-publicada 45
log "fin"
