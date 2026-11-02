#!/usr/bin/env bash
# Verificaciones de la aplicación de la ronda 2 del ciclo 1 que se pueden correr sobre la bitácora (REED-16 §9.7).
# Uso (desde OUTPUTs/): RPRIV_LISTA=<archivo privado fuera de OUTPUTs> Bitacoras/Mesa/Ciclo-1/Ronda-2/aplicacion/verificar-ronda-2.sh
set -u; B=Bitacoras; N=$B/Nucleos; I=$B/04-Integracion.md; C1=$B/Mesa/Ciclo-1; A=$C1/Ronda-2/aplicacion
echo "# verificación de la ronda 2 — $(date -Iseconds)"
echo "## P2-01 compuerta v2 sobre OUTPUTs/ (patrones=0 y cabeceras=0; identificadores informa)"
RPRIV_SINTETICOS=$A/rpriv-sinteticos.txt "$A/rpriv.sh" . | sed 's/^[^ ]* //'
echo "## P2-01 casos rojos y verdes (lista de prueba temporal, fuera de OUTPUTs/)"
T=$(mktemp -d); echo 'token-inexistente-zzq' > "$T/l"; "$A/rpriv-casos.sh" "$A/rpriv.sh" "$T/l" "$A/rpriv-sinteticos.txt"; rm -rf "$T"
echo "## Notas de la ronda 2 por parche (total en OUTPUTs/)"
for p in 01 02 03 04 05 06 07 08 09 10 11 12 13 14 15; do printf 'P2-%s %s\n' $p "$(grep -rho "Parche P2-$p (ciclo 1, ronda 2)" --include=*.md . | wc -l)"; done
echo "## Frases viejas con la nota de la ronda 2 a la vista en el mismo archivo"
for q in "estado del servidor" "si el cliente la expone" "N ≥ 96" "se apaga al terminar" "no se comparó punta a punta"; do
  for f in $I $N/*.md $B/Sondeo-Entorno.md; do c=$(grep -c "$q" "$f"); [ "$c" -gt 0 ] && echo "«$q» $(basename "$f"): apariciones=$c notas-ronda-2=$(grep -c 'ciclo 1, ronda 2' "$f")"; done; done
echo "## P2-05 «pierde la sesión|falla al arrancar|mezcla sesiones» en BIT-16-04 fuera de notas (debe ser 0)"
grep -nE "pierde la sesión|falla al arrancar|mezcla sesiones" $I | grep -vc ':>'
echo "## P2-02 fila N6 de 03-Marco: nota de la ronda 2 presente"; grep -c 'Parche P2-02 (ciclo 1, ronda 2).\*\* Fila N6' $B/03-Marco-De-Referencia.md
echo "## P2-10 criterio D1–D6: sha256 del texto previo a la nota (debe ser el de F09)"
f=$B/Integracion-Evidencia/C-operacion-demo/criterio-D1-D6-qwen3.5-2b-vs-4b.md; head -n "$(( $(grep -n 'Parche P2-10' "$f" | head -1 | cut -d: -f1) - 2 ))" "$f" | sha256sum | cut -c1-64
echo "## P2-10 pares por semilla (03-comparacion.jsonl)"; python3 -I $A/verificar-p2-10.py $C1/Ronda-2/evidencia-comparacion-2b-4b/03-comparacion.jsonl
echo "## P2-09/P2-10 PC-06 por paso"; python3 -I $A/verificar-pc06.py $C1/Ronda-2/evidencia-operacion-telemetria/PC06-qwen3.5-4b-corto.jsonl $C1/Ronda-2/evidencia-operacion-telemetria/PC06-qwen2.5-0.5b.jsonl
echo "## P2-06 copias en Integracion-Evidencia/C-operacion-demo (cmp = 0)"
for s in evidencia-operacion-telemetria/PC02-salida.txt evidencia-aprobacion-evidencia/P2-06v2-salida.txt evidencia-aprobacion-evidencia/P2-06v2-Program.cs evidencia-aprobacion-evidencia/P2-06v2.csproj evidencia-aprobacion-impacto/P206v2-salida.txt evidencia-aprobacion-impacto/P206v2-Program.cs evidencia-aprobacion-impacto/P206v2-Sonda.csproj; do cmp -s $C1/Ronda-2/$s $B/Integracion-Evidencia/C-operacion-demo/$(basename $s) && echo "igual $(basename $s)" || echo "DISTINTO $(basename $s)"; done
echo "## P2-15 encabezado «## Validación del núcleo (ciclo 1)» por registro (debe ser 1)"; for f in $N/*.md; do echo "$(basename $f) $(grep -c '^## Validación del núcleo (ciclo 1)' $f)"; done
echo "## [C: en las notas de la ronda 2 (sólo menciones de la marca de C1-32 y de la compuerta)"
grep -rh 'ciclo 1, ronda 2' --include=*.md . | grep -o '\[C:[^]]*\]' | sort | uniq -c
echo "## [C: fuera de notas en 00, 01 y 03 (ciclo 1: 13 = 11 marcas + 2 explicaciones)"; cat $B/00-*.md $B/01-*.md $B/03-*.md | grep -v '^>' | grep -o '\[C:' | wc -l
echo "## 06-Plan §10 presente y §8 sin tocar"; grep -c '^## 10\. Ronda 2' $C1/06-Plan-De-Redaccion.md; sed -n '285,297p' $C1/06-Plan-De-Redaccion.md | sha256sum | cut -c1-64
echo "## Enlaces relativos (G2-enlaces.py) sobre todos los .md de OUTPUTs/"; WORKSPACE="$(cd ../../../../../../.. && pwd)" python3 -I $C1/evidencia-verificacion-qa/G2-enlaces.py $(find . -name '*.md' | sort) | tail -3
