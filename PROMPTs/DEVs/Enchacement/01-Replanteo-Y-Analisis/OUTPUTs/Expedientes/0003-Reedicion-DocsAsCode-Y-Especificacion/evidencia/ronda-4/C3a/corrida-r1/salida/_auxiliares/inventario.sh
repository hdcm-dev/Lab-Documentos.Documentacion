#!/usr/bin/env bash
# Inventario de §3.1 sobre repo/proyecto; {excluidas} vacía; una salida por comando en salida/_auxiliares/.
cd /corrida/repo/proyecto
A=/corrida/salida/_auxiliares
C=/corrida/compuerta/tools/docs-guard
EXC=(); X=(--exclude-dir=.git); P=(-name .git)
for d in "${EXC[@]}"; do X+=(--exclude-dir="$d"); P+=(-o -name "$d"); done
{ echo "\$ python3 $C/dg.py trazas --raiz . ."; python3 $C/dg.py trazas --raiz . . ; echo "rc=$?"; } > $A/inventario-01.txt 2>&1
{ command grep -rIhoE "${X[@]}" --include="*.md" -e "^doc_id: *[A-Z][A-Z0-9]*(-[A-Z0-9]+)+" -e "^#{1,6} +\`?[A-Z][A-Z0-9]*(-[A-Z0-9]+)+" . | sed -E "s/^(doc_id: *|#+ +\`?)//" | sort | uniq -cd; echo "rc=$?"; } > $A/inventario-01b.txt 2>&1
{ command grep -rlE "${X[@]}" "^version:" --include="*.md" . | xargs -r grep -l "Versión:\*\*"; echo "rc=$?"; } > $A/inventario-02.txt 2>&1
{ command grep -rniE "${X[@]}" -e planificad -e previst -e "a implementar" -e TODO docs/tecnica; echo "rc=$?"; } > $A/inventario-03.txt 2>&1
{ command grep -rn "${X[@]}" "^traces:" Colmenar/Resources/Ayuda; echo "rc=$?"; } > $A/inventario-04.txt 2>&1
{ find . -maxdepth 1 -iname "changelog*" | wc -l; find . -maxdepth 1 -iname "changelog*" -exec grep -niE -e obsolet -e retirad -e elimin -e renombr {} + </dev/null; echo "rc=$?"; } > $A/inventario-05.txt 2>&1
{ command grep -niE -e advertencia -e aviso -e warning -e pendiente -e "sin implementar" -e "no ejercid" AGENTS.md; echo "rc=$?"; command grep -ciE -e advertencia -e aviso -e warning -e pendiente -e "sin implementar" -e "no ejercid" AGENTS.md; echo "rc=$?"; } > $A/inventario-06.txt 2>&1
{ command grep -rIhoE "${X[@]}" --include="*.md" "\b[A-Z][A-Z0-9]*-[A-Z0-9]+" . | sed -E "s/-.*//" | sort | uniq -c | sort -rn; echo "rc=$?"; command grep -rnIoE "${X[@]}" --include="*.md" "\b[A-Z][A-Z0-9]*-[A-Z0-9]+" . ; } > $A/inventario-07.txt 2>&1
{ command grep -rhoE "${X[@]}" --include="*.csproj" "<TargetFrameworks?>[^<]+" . | sort | uniq -c; echo "rc=$?"; command grep -rnE "${X[@]}" --include="*.csproj" "<TargetFrameworks?" . ; } > $A/inventario-08.txt 2>&1
{ for PREFIJO in RD FIC PRC AUD; do printf "%s " $PREFIJO; command grep -rIlwE "${X[@]}" "$PREFIJO-[0-9]+" . | wc -l; done; } > $A/inventario-09.txt 2>&1
{ date -u +%F; } > $A/inventario-10.txt 2>&1
{ find . \( "${P[@]}" \) -prune -o -type f -print0 | LC_ALL=C sort -z | xargs -0 sha256sum | sha256sum; git rev-parse HEAD; git status --short | wc -l; } > $A/inventario-11.txt 2>&1
{ command grep -rnIiE "${X[@]}" -e "[0-9]{1,3}(\.[0-9]{1,3}){3}" -e "/(home|Users)/[a-z]" -e "$(hostname -s)" .; echo "rc=$?"; echo "maquina-o-etiqueta=$(hostname -s)"; } > $A/inventario-12b.txt 2>&1
{ command grep -rniE -e privad -e "públic" -e private -e public -e visibility README* AGENTS.md .github; echo "rc=$?"; } > $A/inventario-13.txt 2>&1
