#!/usr/bin/env bash
# M6 de C3a: monta una copia de la semilla d39dfbd con los artefactos de una corrida y corre la compuerta de LD@00171bd
# como copia parametrizada (conocimiento 1.1 §5.7): {copia-proyecto} con A-02 como prefijos.txt y {copia-origen} intacta.
# Uso: m6.sh <corrida> <prefijo-copia> <variante: base|a01> <par: verde|rojo>
set -uo pipefail
SP={area-del-perito}
RUN={dir-de-trabajo}/corridas-r2/$1
COPIA=$2          # .docs-guard o docs-guard
VAR=$3; PAR=$4
A=$SP/m6/$1-$VAR-$PAR
rm -rf "$A"; mkdir -p "$A"
git -C "$RUN/repo/proyecto" archive d39dfbd4d113794fc0edca9f6d16739b51a502f3 | tar -x -C "$A"
S=$RUN/salida
for c in proyecto origen; do
  mkdir -p "$A/$COPIA/$c"
  cp -r $SP/gate/ld/tools $SP/gate/ld/scripts "$A/$COPIA/$c/"
done
cp "$S/$COPIA/proyecto/tools/docs-guard/prefijos.txt"   "$A/$COPIA/proyecto/tools/docs-guard/prefijos.txt"    # A-02
cp "$S/$COPIA/proyecto/tools/docs-guard/excepciones.txt" "$A/$COPIA/proyecto/tools/docs-guard/excepciones.txt" # A-08
mkdir -p "$A/docs/_gobierno"
cp "$S/docs/_gobierno/esquema-frontmatter.md" "$A/docs/_gobierno/"   # A-03 (nota; el JSON no se produjo)
cp "$S/docs/_requisitos.md" "$A/docs/"                                # A-04
cp "$S/AGENTS.md" "$A/"                                               # A-05
cp "$S/docs/_gobierno/como-intervenir.md" "$A/docs/_gobierno/"       # A-06
if [[ -f "$S/.github/workflows/docs-guard.yml" ]]; then mkdir -p "$A/.github/workflows"; cp "$S/.github/workflows/docs-guard.yml" "$A/.github/workflows/"; fi  # A-07
if [[ $VAR == a01 ]]; then mkdir -p "$A/docs/_diseno"; cp "$S/A-01.md" "$A/docs/_diseno/ficha-diseno-documental.md"; fi
if [[ $PAR == rojo ]]; then
  # Par plantado: una traza a un ID inexistente (RD-99, prefijo interno del registro A-02) en A-04.
  sed -i '0,/^traces: \[/s//traces: [RD-99, /' "$A/docs/_requisitos.md"
  grep -n '^traces:' "$A/docs/_requisitos.md"
fi
cd "$A"
export DOCS_GUARD_CACHE={cache-herramientas}
total=0
for g in herramientas enlaces esquema ai estructura trazas contrato fijadas; do
  echo "######## $g (copia-proyecto, RUTA=docs)"
  "$COPIA/proyecto/scripts/ci-local.sh" "$g" docs; rc=$?
  echo "######## rc $g = $rc"
  [[ $g != herramientas && $rc -ne 0 ]] && total=1
done
echo "######## autoprueba (copia-origen)"
"$COPIA/origen/scripts/ci-local.sh" autoprueba docs; rca=$?
echo "######## rc autoprueba = $rca"
echo "######## AGREGADO grupos PR: $([[ $total -eq 0 ]] && echo verde || echo ROJO); autoprueba: $([[ $rca -eq 0 ]] && echo verde || echo ROJO)"
