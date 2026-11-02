#!/usr/bin/env bash
# Criterios de verificación de los parches del ciclo 1 que se pueden correr sobre la bitácora (REED-16 §9.7).
# Uso (desde OUTPUTs/): RPRIV_LISTA=<archivo privado> Bitacoras/Mesa/Ciclo-1/aplicacion/verificar-ciclo-1.sh
set -u; B=Bitacoras; N=$B/Nucleos; I=$B/04-Integracion.md; A=$B/Mesa/Ciclo-1/aplicacion
echo "# verificación del ciclo 1 — $(date -Iseconds)"
echo "## P-01 compuerta R-PRIV sobre OUTPUTs/"; "$A/rpriv.sh" . | head -1
echo "## P-01 caso rojo fuera del repo (debe salir 1)"; T=$(mktemp -d); printf 'ruta /%s/alguien/x\nhost 100.%s.7.9.\n' home 99 > "$T/caso.md"; "$A/rpriv.sh" "$T" >/dev/null; echo "rc=$?"; rm -rf "$T"
echo "## P-02 «falso aceptado» por archivo (apariciones; las posteriores a la nota están dentro de notas de Parche P-02)"
for f in $N/N0b-*.md $I; do echo "$(basename $f): total=$(grep -ci 'falso aceptado' $f) primera-nota-P-02=l.$(grep -n 'Parche P-02 (ciclo 1)' $f | head -1 | cut -d: -f1) apariciones-fuera-de-notas-tras-la-primera-nota(texto previo, citas anteriores a la nota)=$(awk -v n=$(grep -n 'Parche P-02 (ciclo 1)' $f | head -1 | cut -d: -f1) 'NR>n && tolower($0) ~ /falso aceptado/ && $0 !~ /^>/' $f | wc -l)"; done
echo "## P-04 ESC-0 y «Aplicación por escenario» por registro (N1–N5)"
for f in $N/N1-*.md $N/N2*.md $N/N3-*.md $N/N4*.md $N/N5*.md; do echo "$(basename $f): ESC-0=$(grep -c 'ESC-0' $f) aplicacion_por_escenario=$(grep -c 'Aplicación por escenario' $f)"; done
echo "## P-05 ESC-0 en N6 Anexo A"; awk '/^## Anexo A\./{s=1} /^## Anexo B\./{s=0} s' $N/N6-*.md | grep -c 'ESC-0'
echo "## P-06 PR distintas en la nota de Parche P-06"; awk '/Parche P-06 \(ciclo 1\)\.\*\* Decisión/{s=1} s&&/^$/{exit} s' $I | grep -oE 'PR-[0-9]+' | sort -u -t- -k2n | tr '\n' ' '; echo; awk '/Parche P-06 \(ciclo 1\)\.\*\* Decisión/{s=1} s&&/^$/{exit} s' $I | grep -oE 'PR-[0-9]+' | sort -u | wc -l
echo "## P-06 filas que citan «§n» sin título (debe ser 0)"; awk '/Parche P-06 \(ciclo 1\)\.\*\* Decisión/{s=1} s&&/^$/{exit} s' $I | grep -E '^> \| PR' | grep -E 'guía §[0-9]' | grep -vcE 'guía §[0-9] «'
echo "## P-09 conteo de preguntas guía"; "$A/conteo-preguntas.sh" $N | tail -1
echo "## P-12 «mezcla sesiones» fuera de notas en BIT-16-04"; grep -n 'mezcla sesiones' $I | grep -v ':>' | wc -l
echo "## P-21 cifras.py reproduce la tabla (diff = 0)"; (cd $B && python3 -I Sondeo-Evidencia/2026-10-28/cifras.py | diff -q - Sondeo-Evidencia/2026-10-28/cifras-2026-10-28.md && echo "diff=0")
echo "## P-28 marcas [C:] en 00, 01 y 03 (13 − 2 explicaciones = 11)"; cat $B/00-*.md $B/01-*.md $B/03-*.md | grep -v '^>' | grep -o '\[C:' | wc -l; echo '(fuera de las notas; las notas de Parche P-28 nombran la notación)'
echo "## P-31 doc_id agregados"; grep -l 'Parche P-31 (ciclo 1).\*\* `doc_id`' $N/*.md | wc -l
echo "## P-34 encabezado «## Validación del núcleo (ciclo 1)» por registro"; for f in $N/*.md; do echo "$(basename $f) $(grep -c '^## Validación del núcleo (ciclo 1)' $f)"; done
echo "## P-37 «no corre en estación 1» con nota a la vista"; for f in $I $N/N3b-*.md $B/Sondeo-Entorno.md; do echo "$(basename $f): menciones=$(grep -c 'no corre en estación 1' $f) notas_P-37=$(grep -c 'Parche P-37 (ciclo 1)' $f)"; done
echo "## P-27 tensión 6: «pruebas adversariales extendidas»"; grep -c 'pruebas adversariales extendidas' $I
echo "## Enlaces relativos (G2-enlaces.py) sobre todos los .md de OUTPUTs/"; WORKSPACE="$(cd ../../../../../../.. && pwd)" python3 -I $B/Mesa/Ciclo-1/evidencia-verificacion-qa/G2-enlaces.py $(find . -name '*.md' | sort) | tail -3
