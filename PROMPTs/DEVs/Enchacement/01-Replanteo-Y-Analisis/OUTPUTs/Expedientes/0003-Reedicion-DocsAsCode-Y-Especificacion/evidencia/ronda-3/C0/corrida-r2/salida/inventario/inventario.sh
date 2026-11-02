#!/usr/bin/env bash
# Inventario §3.1 (comandos copiados del bloque numerado), corrido desde repo/LD con ./aislado
cd /corrida/repo/LD
O=/corrida/salida/inventario
EXC=(Sistema-De-Documentacion-E-Integracion); X=(--exclude-dir=.git); P=(-name .git)
for d in "${EXC[@]}"; do X+=(--exclude-dir="$d"); P+=(-o -name "$d"); done
command grep -rIhoE "${X[@]}" --include='*.md' -e '^doc_id: *[A-Z][A-Z0-9]*(-[A-Z0-9]+)+' -e '^#{1,6} +`?[A-Z][A-Z0-9]*(-[A-Z0-9]+)+' . | sed -E 's/^(doc_id: *|#+ +`?)//' | sort | uniq -cd > $O/c01b.txt 2>&1; echo "rc=$?" >> $O/c01b.txt
for d in Concepts Guides .github scripts tools README.md AGENTS.md; do echo "== $d"; python3 tools/docs-guard/dg.py trazas --raiz . $d 2>&1 | tail -15; echo "rc=${PIPESTATUS[0]}"; done > $O/c01.txt
command grep -rlE "${X[@]}" '^version:' --include='*.md' . | xargs -r grep -l 'Versión:\*\*' > $O/c02.txt 2>&1; echo "rc=$?" >> $O/c02.txt
command grep -rniE "${X[@]}" -e planificad -e previst -e 'a implementar' -e TODO docs/tecnica > $O/c03.txt 2>&1; echo "rc=$?" >> $O/c03.txt
{ command grep -rn "${X[@]}" '^traces:' ayuda; echo "rc=$?"; } > $O/c04.txt 2>&1
{ find . -maxdepth 1 -iname 'changelog*' | wc -l; } > $O/c05a.txt
{ find . -maxdepth 1 -iname 'changelog*' -exec grep -niE -e obsolet -e retirad -e elimin -e renombr {} + </dev/null; echo "rc=$?"; } > $O/c05.txt 2>&1
{ command grep -niE -e advertencia -e aviso -e warning -e pendiente README.md AGENTS.md Guides/README.md; echo "rc=$?"; } > $O/c06.txt 2>&1
{ command grep -ciE -e advertencia -e aviso -e warning -e pendiente README.md AGENTS.md Guides/README.md; } > $O/c06n.txt 2>&1
command grep -rIhoE "${X[@]}" --include='*.md' '\b[A-Z][A-Z0-9]*-[A-Z0-9]+' . | sed -E 's/-.*//' | sort | uniq -c | sort -rn > $O/c07.txt
{ command grep -rhoE "${X[@]}" --include='*.csproj' '<TargetFrameworks?>[^<]+' . | sort | uniq -c; echo "rc=${PIPESTATUS[0]}"; } > $O/c08.txt 2>&1
for p in FIC PRC RD; do echo "$p $(command grep -rIlwE "${X[@]}" "$p-[0-9]+" . | wc -l)"; done > $O/c09.txt
date -u +%F > $O/c10.txt
find . \( "${P[@]}" \) -prune -o -type f -print0 | LC_ALL=C sort -z | xargs -0 sha256sum | sha256sum > $O/c11.txt 2>&1
{ command grep -rnIiE "${X[@]}" -e '[0-9]{1,3}(\.[0-9]{1,3}){3}' -e '/(home|Users)/[a-z]' -e "$(hostname -s)" . ; echo "rc=$?"; } > $O/c12b.txt 2>&1
{ command grep -rniE -e privad -e 'públic' -e private -e public -e visibility README* AGENTS.md .github Guides/README.md; echo "rc=$?"; } > $O/c13.txt 2>&1
