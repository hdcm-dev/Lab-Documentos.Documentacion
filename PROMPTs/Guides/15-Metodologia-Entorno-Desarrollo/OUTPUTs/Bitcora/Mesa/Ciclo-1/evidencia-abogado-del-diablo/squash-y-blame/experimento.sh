#!/bin/sh
# Abogado del diablo, ciclo 1. ¿Un PR de migración fusionado con SQUASH rompe .git-blame-ignore-revs?
# Hipótesis: no, si el SHA se agrega DESPUÉS de fusionar (el que quedó en main), en un PR aparte.
# Uso: sh experimento.sh > salida.txt   (sólo git)
set -eu
W=$(mktemp -d); cd "$W"; git init -q -b main r; cd r
git config user.name autora; git config user.email autora@ejemplo
printf 'class Sensor\r\n{\r\n    int Leer() => 42; // Atenci\363n\r\n}\r\n' > Sensor.cs
git add Sensor.cs; git commit -qm "codigo original (cp1252, CRLF)"
git switch -qc migracion; git config user.name migrador
iconv -f CP1252 -t UTF-8 Sensor.cs | tr -d '\r' > t && mv t Sensor.cs
git commit -qam "migracion mecanica"; git commit -q --allow-empty -m "segundo commit de la rama (para que el squash junte dos)"
git switch -q main; git merge -q --squash migracion; git commit -qm "Migracion cp1252 -> UTF-8 (squash)"
S=$(git rev-parse HEAD); echo "SHA del squash en main: $S"
echo "-- blame sin ignore-revs"; git blame -s Sensor.cs | sed 's/^/   /'; git log -1 --format='   autor del commit atribuido: %an' "$S"
echo "$S" > .git-blame-ignore-revs; git add .git-blame-ignore-revs; git commit -qm "aislar la migracion de blame"
echo "-- blame con ignore-revs del SHA del squash"; git -c blame.ignoreRevsFile=.git-blame-ignore-revs blame Sensor.cs | sed 's/^/   /'
git --version
