#!/usr/bin/env bash
# Ensayo E1: cuenta cláusulas sin criterio de aceptación y términos vagos (muestra actual frente a reescritura Dado/Cuando/Entonces)
D=$1
echo "== Muestra actual ($(tail -n +2 $D/muestra-actual.tsv | wc -l) cláusulas)"
tail -n +2 $D/muestra-actual.tsv | awk -F'\t' '{a[$4]++; u[$5]++; v[$6]++; c[$7]++} END {printf "atomica si=%d no=%d | univoca si=%d no=%d | verificable si=%d parcial=%d no=%d | criterio si=%d parcial=%d no=%d\n", a["si"],a["no"],u["si"],u["no"],v["si"],v["parcial"],v["no"],c["si"],c["parcial"],c["no"]}'
echo "-- sin criterio completo (parcial o no):"; tail -n +2 $D/muestra-actual.tsv | awk -F'\t' '$7!="si"{printf "%s ", $1} END{print ""}'
echo "-- términos vagos (léxico) en la muestra actual:"; cut -f1,3 $D/muestra-actual.tsv | tail -n +2 | grep -i -w -o -f $D/vagos.txt | sort | uniq -c | sort -rn
echo "== Reescritura DCE ($(tail -n +2 $D/muestra-dce.tsv | wc -l) cláusulas que reemplazan a las sin criterio)"
tail -n +2 $D/muestra-dce.tsv | awk -F'\t' 'NF!=5 || $2=="" || $3=="" || $4=="" || $5=="" {print "INCOMPLETA: "$1; bad++} END {print "incompletas: " bad+0}'
echo "-- términos vagos en la reescritura:"; tail -n +2 $D/muestra-dce.tsv | cut -f2-4 | grep -i -w -c -f $D/vagos.txt || true
echo "-- cobertura: ids sin criterio que la reescritura cubre"
for id in $(tail -n +2 $D/muestra-actual.tsv | awk -F'\t' '$7!="si"{print $1}'); do grep -q "^$id" $D/muestra-dce.tsv && echo "$id cubierto" || echo "$id SIN REESCRITURA"; done | sort | uniq -c | awk '{print}' | grep -c "cubierto" | xargs echo "cubiertos:"
for id in $(tail -n +2 $D/muestra-actual.tsv | awk -F'\t' '$7!="si"{print $1}'); do grep -q "^$id" $D/muestra-dce.tsv || echo "SIN REESCRITURA: $id"; done
