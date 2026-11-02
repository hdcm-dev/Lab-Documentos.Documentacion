#!/usr/bin/env bash
# Sonda de cobertura del especialista Requisitos (ciclo 1, 2026-10-28). Sólo lectura.
# Uso: sonda-cobertura.sh <ruta a OUTPUTs/Bitacoras>
set -u
B="${1:?ruta a Bitacoras}"
cd "$B" || exit 1
echo "## [1] ESC-/CTX- y 'escenario' por registro de núcleo"
for f in Nucleos/*.md; do
  printf '%s | ESC=%s | CTX=%s | escenario=%s | "Aplicación por escenario"=%s\n' "$(basename "$f")" \
    "$(grep -oE 'ESC-0[1-6]' "$f" | wc -l)" "$(grep -oE 'CTX-[A-Z]+' "$f" | wc -l)" \
    "$(grep -ci 'escenario' "$f")" "$(grep -ci 'aplicación por escenario' "$f")"
done
echo
echo "## [2] Propuestas del PO PR-n: menciones en 04-Integracion y en la convocatoria del ciclo 1"
for p in $(seq 1 22); do
  printf 'PR-%s | 04=%s | 00-Convocatoria=%s\n' "$p" "$(grep -cE "PR-$p\b" 04-Integracion.md)" "$(grep -cE "PR-$p\b" Mesa/Ciclo-1/00-Convocatoria.md)"
done
echo
echo "## [3] I-06 / RD-PO en el contrato de entrada"
printf 'menciones RD-PO|I-06 en 00-Contrato-De-Entrada.md = %s\n' "$(grep -cE 'RD-PO|I-06' 00-Contrato-De-Entrada.md)"
echo
echo "## [4] Trazabilidad 02 §6: filas para núcleos agregados y para preguntas de REED-16 §7"
sed -n '/^## 6\. Trazabilidad/,/^## 7\./p' 02-Cohesion-Global.md > /tmp/.trz.$$ 2>/dev/null || true
T=$(sed -n '/^## 6\. Trazabilidad/,/^## 7\./p' 02-Cohesion-Global.md)
for k in N0b N1b N3b 'Anexo F' 'pregunta' 'Pregunta'; do printf '%s en 02 §6 = %s\n' "$k" "$(grep -c "$k" <<<"$T")"; done
rm -f /tmp/.trz.$$
echo
echo "## [5] Pendientes de 04 §7 que nombran N1 / N3 / N6 snippets"
S=$(sed -n '/^## 7\. Pendientes/,/^## 8\./p' 04-Integracion.md)
printf 'P-14: %s\n' "$(grep -o 'P-14 | [^|]*' <<<"$S")"
printf 'menciones de N1 en 04 §7 = %s\n' "$(grep -cE '\bN1\b' <<<"$S")"
echo "N1, nota de reanudación, fila 3:"; grep -n '^| 3 | Snippets no ejecutados' Nucleos/N1-Capa-IA-En-El-Stack.md | cut -c1-200
echo
echo "## [6] Fila N6 de 03 §4.1 y delegación de N6 §8.8"
grep -n '^| N6 Caso' 03-Marco-De-Referencia.md
grep -n '§8.8 — fuentes de N0' Nucleos/N6-Caso-Movilidad-Urbana.md | cut -c1-330
printf 'ESC-0n en N6 Anexo A (recorrido D1–D7) = %s\n' "$(sed -n '/^## Anexo A/,/^## Anexo B/p' Nucleos/N6-Caso-Movilidad-Urbana.md | grep -c 'ESC-0')"
echo
echo "## [7] Ranura de Examples para MI-04 y PR-22"
AB=$(sed -n '/^## Anexo B/,/^## Verificación adversarial/p' Nucleos/N6-Caso-Movilidad-Urbana.md)
for k in 'arquitectura' 'KernelFunction' 'negativ'; do printf '%s en N6 Anexo B = %s\n' "$k" "$(grep -ci "$k" <<<"$AB")"; done
printf "MovilidadUrbana.Web: SUP-05 = '%s'\n" "$(grep -o 'SUP-05 | [^|]*' 00-Contrato-De-Entrada.md)"
