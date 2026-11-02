#!/usr/bin/env bash
# Verificación de §6 sobre A-01…A-13 montados. Se corre con: ./aislado bash salida/_auxiliares/verificacion.sh
# Salidas: salida/_auxiliares/verificacion-*.txt
set -u
S=/corrida/salida
A=$S/_auxiliares
M=$A/montaje
export GITHUB_ACTIONS=false

# 0. A-01 al repo (docs/_diseno/) y árbol montado: LG leído + artefactos de salida/LG
mkdir -p $S/LG/docs/_diseno
cp $S/A-01.md $S/LG/docs/_diseno/ficha-diseno-documental.md
rm -rf $M $A/montaje-rojo
mkdir -p $M
cp -a /corrida/repo/LG $M/LG
cp -a $S/LG/. $M/LG/

# 1. Compuerta del proyecto (copia con A-02 y A-03) sobre docs/, grupo por grupo, y huella del guion
cd $M/LG
{ echo '$ sha256sum .docs-guard/tools/docs-guard/dg.py .docs-guard/scripts/ci-local.sh .docs-guard-origen/tools/docs-guard/dg.py .docs-guard-origen/scripts/ci-local.sh /corrida/compuerta/tools/docs-guard/dg.py /corrida/compuerta/scripts/ci-local.sh'
  sha256sum .docs-guard/tools/docs-guard/dg.py .docs-guard/scripts/ci-local.sh .docs-guard-origen/tools/docs-guard/dg.py .docs-guard-origen/scripts/ci-local.sh /corrida/compuerta/tools/docs-guard/dg.py /corrida/compuerta/scripts/ci-local.sh
  for g in enlaces esquema ai estructura trazas contrato fijadas; do
    echo "\$ .docs-guard/scripts/ci-local.sh $g docs"
    .docs-guard/scripts/ci-local.sh $g docs 2>&1
    echo "rc=$?"
  done; } > $A/verificacion-compuerta.txt

# 2. Autoprueba con la copia de origen, intacta, sin red
{ echo '$ npm_config_offline=true .docs-guard-origen/scripts/ci-local.sh autoprueba docs'
  npm_config_offline=true .docs-guard-origen/scripts/ci-local.sh autoprueba docs 2>&1
  echo "rc=$?"; } > $A/verificacion-autoprueba.txt

# 3. Par rojo/verde: traza a un ID inexistente plantada en una copia del árbol
cp -a $M $A/montaje-rojo
sed -i 's/^traces: \[FIC-FICHA\]$/traces: [FIC-FICHA, FIC-NO-EXISTE]/' $A/montaje-rojo/LG/docs/_gobierno/como-intervenir.md
{ echo '== rojo: montaje-rojo/LG, docs/_gobierno/como-intervenir.md con traces: [FIC-FICHA, FIC-NO-EXISTE]'
  grep -n '^traces:' $A/montaje-rojo/LG/docs/_gobierno/como-intervenir.md
  cd $A/montaje-rojo/LG
  echo '$ .docs-guard/scripts/ci-local.sh trazas docs'
  .docs-guard/scripts/ci-local.sh trazas docs 2>&1; echo "rc=$?"
  echo '== verde: montaje/LG, sin la traza plantada'
  cd $M/LG
  grep -n '^traces:' docs/_gobierno/como-intervenir.md
  echo '$ .docs-guard/scripts/ci-local.sh trazas docs'
  .docs-guard/scripts/ci-local.sh trazas docs 2>&1; echo "rc=$?"; } > $A/verificacion-par.txt

# 4. Chequeo de citas de §3.5, desde la carpeta que contiene los dos repos
cd /corrida/repo
{ echo '$ cd /corrida/repo && command grep -oE '"'"'[A-Za-z0-9_./-]+\.[A-Za-z]+:[0-9]+(-[0-9]+)?'"'"' /corrida/salida/A-01.md | sort -u | while IFS=: read -r f r; do …; done'
  command grep -oE '[A-Za-z0-9_./-]+\.[A-Za-z]+:[0-9]+(-[0-9]+)?' $S/A-01.md | sort -u | while IFS=: read -r f r; do
    if [ ! -f "$f" ]; then echo "NO EXISTE $f"; elif [ "$(wc -l < "$f")" -lt "${r#*-}" ]; then echo "FUERA DE RANGO $f:$r"; fi
  done
  echo "fin del chequeo (salida vacía arriba = sin defectos)"
  echo "citas distintas: $(command grep -oE '[A-Za-z0-9_./-]+\.[A-Za-z]+:[0-9]+(-[0-9]+)?' $S/A-01.md | sort -u | wc -l)"
  echo '$ command grep -noE '"'"'(^|[ (`])`?:[0-9]+'"'"' /corrida/salida/A-01.md   # «:n» sueltas'
  command grep -noE '(^|[ (])`:[0-9]+' $S/A-01.md; echo "rc=$?"; } > $A/verificacion-citas.txt 2>&1

# 5. Barrido 12b sin lista privada, sobre lo que va a los repositorios
cd $S
MAQ="$(hostname -s)"
{ echo "\$ command grep -rnIiE --exclude-dir=.git -e '[0-9]{1,3}(\.[0-9]{1,3}){3}' -e '/(home|Users)/[a-z]' -e '$MAQ' -e '{maquina}' A-01.md LG LGD"
  command grep -rnIiE --exclude-dir=.git -e '[0-9]{1,3}(\.[0-9]{1,3}){3}' -e '/(home|Users)/[a-z]' -e "$MAQ" -e '{maquina}' A-01.md LG LGD
  echo "rc=$?"; } > $A/verificacion-barrido.txt 2>&1
