#!/usr/bin/env bash
# Sondas de lectura (sólo grep) del especialista de Didáctica, ciclo 1, 2026-10-28.
# Uso: bash sondas.sh  (desde cualquier lugar). No modifica nada.
set -u
B="$(cd "$(dirname "$0")/../../.." && pwd)"   # .../OUTPUTs/Bitacoras
cd "$B" || exit 1
echo "# Base: Bitacoras/ ; fecha: $(date -I)"
echo
echo "## S1. Uso del marco N0 (ocurrencias de IDs) por registro de núcleo"
for f in Nucleos/*.md; do
  printf '%-48s ESC=%-3s CTX=%-3s ACT=%-3s\n' "$(basename "$f")" \
    "$(grep -o 'ESC-0[1-5]' "$f" | wc -l)" "$(grep -o 'CTX-[A-Z]\+' "$f" | wc -l)" "$(grep -o 'ACT-[A-Z]\+' "$f" | wc -l)"
done
echo
echo "## S2. Subsección «Aplicación por escenario» como encabezado en los núcleos"
grep -n -i '^#.*aplicación por escenario' Nucleos/*.md || echo "(ninguna)"
echo
echo "## S3. Mapa conceptual «estoy acá → qué aplico» redactado en núcleos o integración"
grep -rn -i 'estoy acá\|estoy en ESC\|mapa conceptual' Nucleos 04-Integracion.md || echo "(ninguno)"
echo
echo "## S4. Preguntas guía por núcleo (encabezados **P<n>. / **PG-<n>.)"
total=0
for f in Nucleos/*.md; do
  n=$(grep -c '^\*\*P[0-9]\+\.\|^\*\*PG-[0-9]\+\.' "$f"); total=$((total+n))
  printf '%-48s %s\n' "$(basename "$f")" "$n"
done
echo "TOTAL $total"
echo
echo "## S5. Preguntas guía sobre «¿RAG o no?» (texto de la pregunta)"
grep -n '^\*\*P[G-]*[0-9]*\.' Nucleos/*.md | grep -i 'RAG\|vectoriz\|en el prompt\|ventana' 
echo
echo "## S6. Preguntas guía sobre «¿herramienta, agente o workflow?»"
grep -n '^\*\*P[G-]*[0-9]*\.' Nucleos/*.md | grep -i 'agente\|workflow\|Agent Framework\|UseFunctionInvocation'
echo
echo "## S7. Cita «If you can write a function» en respuestas"
grep -n -c 'If you can write a function' Nucleos/*.md
echo
echo "## S8. Propuestas didácticas del PO trazadas (ocurrencias)"
for p in PR-1 PR-3 PR-4 PR-5 PR-6 PR-7 PR-12 PR-14 PR-18 PR-20; do
  printf '%-6s 04=%s Nucleos=%s 02=%s\n' "$p" "$(grep -c "$p\b" 04-Integracion.md)" "$(cat Nucleos/*.md | grep -c "$p\b")" "$(grep -c "$p\b" 02-Cohesion-Global.md)"
done
echo
echo "## S9. Respuestas atadas al servidor dado de baja (frase «servidor … LAN»/«red de laboratorio» en §Preguntas)"
for f in Nucleos/*.md; do
  awk -v F="$(basename "$f")" '/^## [0-9]+\. Preguntas guía/{on=1;next} /^## /{on=0} on && /servidor de la LAN|servidor Ollama de la LAN|red de laboratorio/{print F":"NR": "substr($0,1,140)}' "$f"
done
echo
echo "## S10. Mapeo de capacidades C1–C8 de N6 a ESC (pendiente declarado y su cierre)"
grep -n 'mapeo de §1.5' Nucleos/N6-Caso-Movilidad-Urbana.md | cut -c1-260
grep -n 'C1.*ESC-0\|ESC-0.*C1\b' 04-Integracion.md || echo "04-Integracion: sin tabla C1–C8 → ESC"
grep -n 'fila N6' 03-Marco-De-Referencia.md | cut -c1-200
