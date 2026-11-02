#!/usr/bin/env bash
# Inventario de §3.1, copiado del bloque numerado. Se corre con:
#   ./aislado bash salida/_auxiliares/inventario.sh
# desde la raíz de la corrida. «.» es /corrida/repo (la carpeta que contiene LG y LGD).
# {excluidas}: ninguna (el encargo no excluye carpetas y todas son legibles).
# {compuerta}: /corrida/compuerta/tools/docs-guard
set -u
A=/corrida/salida/_auxiliares
cd /corrida/repo
EXC=(); X=(--exclude-dir=.git); P=(-name .git)   # antes de todo; «command grep» saltea envoltorios
for d in "${EXC[@]}"; do X+=(--exclude-dir="$d"); P+=(-o -name "$d"); done   # {excluidas}: nombres, a cualquier profundidad

{ echo '$ python3 /corrida/compuerta/tools/docs-guard/dg.py trazas --raiz . .'; python3 /corrida/compuerta/tools/docs-guard/dg.py trazas --raiz . .; echo "rc=$?"; } > $A/inventario-01.txt 2>&1

{ echo "$ command grep -rIhoE ${X[*]} --include='*.md' -e '^doc_id: *[A-Z][A-Z0-9]*(-[A-Z0-9]+)+' -e '^#{1,6} +\`?[A-Z][A-Z0-9]*(-[A-Z0-9]+)+' . | sed -E 's/^(doc_id: *|#+ +\`?)//' | sort | uniq -cd"
  command grep -rIhoE "${X[@]}" --include='*.md' -e '^doc_id: *[A-Z][A-Z0-9]*(-[A-Z0-9]+)+' -e '^#{1,6} +`?[A-Z][A-Z0-9]*(-[A-Z0-9]+)+' . | sed -E 's/^(doc_id: *|#+ +`?)//' | sort | uniq -cd; echo "rc=$?"; } > $A/inventario-01b.txt 2>&1

{ echo "$ command grep -rlE ${X[*]} '^version:' --include='*.md' . | xargs -r grep -l 'Versión:\*\*'"
  command grep -rlE "${X[@]}" '^version:' --include='*.md' . | xargs -r grep -l 'Versión:\*\*'; echo "rc=$?"; } > $A/inventario-02.txt 2>&1

# 3: {carpeta-tecnica} literal (docs/tecnica/ en cada repo) y adaptada (LG/SDD/Docs, ubicación de CL-07 en A-01 §3)
{ for T in LG/docs/tecnica LGD/docs/tecnica LG/SDD/Docs; do
    echo "$ command grep -rniE ${X[*]} -e planificad -e previst -e 'a implementar' -e TODO $T; echo \"rc=\$?\""
    command grep -rniE "${X[@]}" -e planificad -e previst -e 'a implementar' -e TODO $T > $A/inventario-03-salida-$(echo $T | tr / _).txt 2>&1; rc=$?
    echo "líneas: $(wc -l < $A/inventario-03-salida-$(echo $T | tr / _).txt) (salida completa en inventario-03-salida-$(echo $T | tr / _).txt)"; echo "rc=$rc"
  done; } > $A/inventario-03.txt 2>&1

# 4: {carpeta-ayuda} literal por defecto: carpeta de ayuda del repo de la interfaz (LG/src/GeometriaFactory.Web)
{ for H in LG/src/GeometriaFactory.Web/ayuda LG/src/GeometriaFactory.Web; do
    echo "$ command grep -rn ${X[*]} '^traces:' $H; echo \"rc=\$?\""
    command grep -rn "${X[@]}" '^traces:' $H; echo "rc=$?"
  done; } > $A/inventario-04.txt 2>&1

# 5: por repo (cada uno tiene su raíz)
{ for R in LG LGD; do
    echo "== cd $R"
    echo "$ find . -maxdepth 1 -iname 'changelog*' | wc -l"
    (cd $R && find . -maxdepth 1 -iname 'changelog*' | wc -l)
    echo "$ find . -maxdepth 1 -iname 'changelog*' -exec grep -niE -e obsolet -e retirad -e elimin -e renombr {} + </dev/null; echo \"rc=\$?\""
    (cd $R && find . -maxdepth 1 -iname 'changelog*' -exec grep -niE -e obsolet -e retirad -e elimin -e renombr {} + </dev/null > $A/inventario-05-salida-$R.txt; echo "rc=$?")
    echo "líneas: $(wc -l < $A/inventario-05-salida-$R.txt) (salida completa en inventario-05-salida-$R.txt)"
  done; } > $A/inventario-05.txt 2>&1

# 6: {indice} = LGD/ia-db/README.md y LGD/ia-db/indexes/*.md
IDX=(LGD/ia-db/README.md LGD/ia-db/indexes/*.md)
{ echo "$ command grep -niE -e advertencia -e aviso -e warning -e pendiente -e 'sin implementar' -e 'no ejercid' {indice}; echo \"rc=\$?\""
  command grep -niE -e advertencia -e aviso -e warning -e pendiente -e 'sin implementar' -e 'no ejercid' "${IDX[@]}"; echo "rc=$?"; } > $A/inventario-06-lista.txt 2>&1
{ echo "$ command grep -ciE -e advertencia -e aviso -e warning -e pendiente -e 'sin implementar' -e 'no ejercid' {indice}"
  command grep -ciE -e advertencia -e aviso -e warning -e pendiente -e 'sin implementar' -e 'no ejercid' "${IDX[@]}"; echo "rc=$?"; } > $A/inventario-06-cuenta.txt 2>&1

{ echo "$ command grep -rIhoE ${X[*]} --include='*.md' '\b[A-Z][A-Z0-9]*-[A-Z0-9]+' . | sed -E 's/-.*//' | sort | uniq -c | sort -rn"
  command grep -rIhoE "${X[@]}" --include='*.md' '\b[A-Z][A-Z0-9]*-[A-Z0-9]+' . | sed -E 's/-.*//' | sort | uniq -c | sort -rn; } > $A/inventario-07.txt 2>&1

{ echo "$ command grep -rhoE ${X[*]} --include='*.csproj' '<TargetFrameworks?>[^<]+' . | sort | uniq -c"
  command grep -rhoE "${X[@]}" --include='*.csproj' '<TargetFrameworks?>[^<]+' . | sort | uniq -c; echo "rc=$?"
  echo "$ command grep -rnoE ${X[*]} --include='*.props' '<TargetFrameworks?>[^<]+' ."
  command grep -rnoE "${X[@]}" --include='*.props' '<TargetFrameworks?>[^<]+' .; echo "rc=$?"; } > $A/inventario-08.txt 2>&1

{ for PFX in RD FIC PRC AUD; do
    echo "$ command grep -rIlwE ${X[*]} '$PFX-[0-9]+' . | wc -l"
    command grep -rIlwE "${X[@]}" "$PFX-[0-9]+" . | wc -l
  done; } > $A/inventario-09.txt 2>&1

{ echo '$ date -u +%F'; date -u +%F; } > $A/inventario-10.txt 2>&1

{ for R in LG LGD; do
    echo "== cd $R"
    echo "$ find . \\( ${P[*]} \\) -prune -o -type f -print0 | LC_ALL=C sort -z | xargs -0 sha256sum | sha256sum"
    (cd $R && find . \( "${P[@]}" \) -prune -o -type f -print0 | LC_ALL=C sort -z | xargs -0 sha256sum | sha256sum)
  done; } > $A/inventario-11.txt 2>&1

{ for R in LG LGD; do
    echo "== cd $R"
    echo "$ command grep -rniE -e privad -e 'públic' -e private -e public -e visibility README* AGENTS.md .github {indice}"
    (cd $R && command grep -rniE -e privad -e 'públic' -e private -e public -e visibility README* AGENTS.md .github $( [ $R = LGD ] && echo ia-db ); echo "rc=$?")
  done; } > $A/inventario-13.txt 2>&1
