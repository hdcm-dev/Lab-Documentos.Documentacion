cd /corrida/repo/proyecto
EXC=(); X=(--exclude-dir=.git); P=(-name .git)
for d in "${EXC[@]}"; do X+=(--exclude-dir="$d"); P+=(-o -name "$d"); done
echo "### 1"; python3 /corrida/compuerta/tools/docs-guard/dg.py trazas --raiz . .; echo "rc=$?"
echo "### 1b"; command grep -rIhoE "${X[@]}" --include='*.md' -e '^doc_id: *[A-Z][A-Z0-9]*(-[A-Z0-9]+)+' -e '^#{1,6} +`?[A-Z][A-Z0-9]*(-[A-Z0-9]+)+' . | sed -E 's/^(doc_id: *|#+ +`?)//' | sort | uniq -cd; echo "rc=$?"
echo "### 2"; command grep -rlE "${X[@]}" '^version:' --include='*.md' . | xargs -r grep -l 'Versión:\*\*'; echo "rc=$?"
echo "### 3"; command grep -rniE "${X[@]}" -e planificad -e previst -e 'a implementar' -e TODO docs/tecnica; echo "rc=$?"
echo "### 4"; command grep -rn "${X[@]}" '^traces:' docs/ayuda; echo "rc=$?"
echo "### 5a"; find . -maxdepth 1 -iname 'changelog*' | wc -l
echo "### 5b"; find . -maxdepth 1 -iname 'changelog*' -exec grep -niE -e obsolet -e retirad -e elimin -e renombr {} + </dev/null; echo "rc=$?"
echo "### 6"; command grep -niE -e advertencia -e aviso -e warning -e pendiente INDICE.md; echo "rc=$?"
echo "### 7"; command grep -rIhoE "${X[@]}" --include='*.md' '\b[A-Z][A-Z0-9]*-[A-Z0-9]+' . | sed -E 's/-.*//' | sort | uniq -c | sort -rn; echo "rc=$?"
echo "### 8"; command grep -rhoE "${X[@]}" --include='*.csproj' '<TargetFrameworks?>[^<]+' . | sort | uniq -c; echo "rc=$?"
for p in FIC RD PRC AUD; do echo "### 9 $p"; command grep -rIlwE "${X[@]}" "$p-[0-9]+" . | wc -l; done
echo "### 10"; date -u +%F
echo "### 11"; find . \( "${P[@]}" \) -prune -o -type f -print0 | LC_ALL=C sort -z | xargs -0 sha256sum | sha256sum
echo "### 12b"; command grep -rnIiE "${X[@]}" -e '[0-9]{1,3}(\.[0-9]{1,3}){3}' -e '/(home|Users)/[a-z]' -e "$(hostname -s)" .; echo "rc=$?"
echo "### 13"; command grep -rniE -e privad -e 'públic' -e private -e public -e visibility README* AGENTS.md .github; echo "rc=$?"
echo "### git"; git rev-parse HEAD; git log --oneline | wc -l; git branch -a; git tag; ls .github 2>&1; echo "### find md"; find . -name .git -prune -o -name '*.md' -print
echo "### auth"; command grep -rniE "${X[@]}" -e Authorize -e Policy -e Claim -e Role .; echo "rc=$?"
echo "### openapi"; find . -name .git -prune -o -iname '*openapi*' -print; command grep -rniE "${X[@]}" -e '///' --include='*.cs' . | head; echo "rc=$?"
echo "### resx"; find . -name .git -prune -o \( -iname '*.resx' -o -iname 'AGENTS.md' \) -print
