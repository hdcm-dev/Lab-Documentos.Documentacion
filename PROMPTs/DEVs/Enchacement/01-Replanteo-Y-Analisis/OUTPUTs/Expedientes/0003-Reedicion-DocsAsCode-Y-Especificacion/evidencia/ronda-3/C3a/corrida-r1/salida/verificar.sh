set -u
B=/corrida/salida/_banco; rm -rf "$B"; mkdir -p "$B"
cp -r /corrida/repo/proyecto/. "$B/"; rm -rf "$B/.git"
cp -r /corrida/salida/.docs-guard "$B/"; cp -r /corrida/compuerta "$B/.docs-guard-origen"
cp -r /corrida/salida/docs /corrida/salida/AGENTS.md /corrida/salida/.github "$B/"
mkdir -p "$B/docs/_diseno"; cp /corrida/salida/A-01.md "$B/docs/_diseno/ficha-diseno-documental.md"
cd "$B"
echo "### huella copia"; sha256sum .docs-guard/tools/docs-guard/dg.py .docs-guard/scripts/ci-local.sh
for g in enlaces esquema ai estructura trazas contrato fijadas; do echo "### VERDE $g"; .docs-guard/scripts/ci-local.sh $g docs 2>&1 | tail -4; echo "rc=${PIPESTATUS[0]}"; done
echo "### ROJO plantado"; sed -i 's/^traces: \[FIC-FICHA\]$/traces: [FIC-FICHA, FIC-NO-EXISTE]/' docs/_gobierno/como-intervenir.md; grep -n '^traces' docs/_gobierno/como-intervenir.md
.docs-guard/scripts/ci-local.sh trazas docs 2>&1 | tail -4; echo "rc=${PIPESTATUS[0]}"
sed -i 's/, FIC-NO-EXISTE//' docs/_gobierno/como-intervenir.md
echo "### VERDE de nuevo"; .docs-guard/scripts/ci-local.sh trazas docs 2>&1 | tail -2; echo "rc=${PIPESTATUS[0]}"
echo "### AUTOPRUEBA origen"; npm_config_offline=true .docs-guard-origen/scripts/ci-local.sh autoprueba docs 2>&1 | tail -15; echo "rc=${PIPESTATUS[0]}"
echo "### 12b sobre artefactos"; cd /corrida/salida; command grep -rnIiE --exclude-dir=_banco --exclude-dir=.docs-guard -e '[0-9]{1,3}(\.[0-9]{1,3}){3}' -e '/(home|Users)/[a-z]' -e "$(hostname -s)" -e '{dir-de-trabajo}/' . ; echo "rc=$?"
echo "### citas"; cd /corrida/repo/proyecto
command grep -oE '[A-Za-z0-9_./-]+\.[A-Za-z]+:[0-9]+(-[0-9]+)?' /corrida/salida/A-01.md | sort -u | while IFS=: read -r f r; do
  if [ ! -f "$f" ]; then echo "NO EXISTE $f"; elif [ "$(wc -l < "$f")" -lt "${r#*-}" ]; then echo "FUERA DE RANGO $f:$r"; fi
done; echo "fin-citas"
