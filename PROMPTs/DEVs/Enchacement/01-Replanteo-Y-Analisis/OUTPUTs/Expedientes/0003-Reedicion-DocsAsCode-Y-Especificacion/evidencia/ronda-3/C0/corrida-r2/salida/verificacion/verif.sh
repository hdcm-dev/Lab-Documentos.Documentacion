cd /corrida/repo/LD
command grep -oE '[A-Za-z0-9_./-]+\.[A-Za-z]+:[0-9]+(-[0-9]+)?' ../../salida/A-01.md | sort -u | while IFS=: read -r f r; do
  if [ ! -f "$f" ]; then echo "NO EXISTE $f"; elif [ "$(wc -l < "$f")" -lt "${r#*-}" ]; then echo "FUERA DE RANGO $f:$r"; fi
done
echo "== fin chequeo; citas distintas: $(command grep -oE '[A-Za-z0-9_./-]+\.[A-Za-z]+:[0-9]+(-[0-9]+)?' ../../salida/A-01.md | sort -u | wc -l)"
echo "== sueltas:"; command grep -nE '(^|[ (,])`:[0-9]+' ../../salida/A-01.md; echo "rc=$?"
echo "== muestra"
sed -n 45,46p AGENTS.md; sed -n 75p .github/workflows/docs-guard.yml | sed 's/repository: [^/]*/repository: {organizacion}/'; sed -n 27p tools/docs-guard/prefijos.txt
sed -n 70p Concepts/Framework-Concept/Demo/tools/FrameworkConcept.Receptor/AutenticacionDelReceptor.cs; sed -n 18p .github/workflows/docs-enlaces-semanal.yml
echo "== barrido 12b"
command grep -rnIiE --exclude-dir=.git --exclude-dir=Sistema-De-Documentacion-E-Integracion -e '[0-9]{1,3}(\.[0-9]{1,3}){3}' -e '/(home|Users)/[a-z]' -e "$(hostname -s)" -e '<host>' -e 'hdcm' ../../salida/A-01.md ../../salida/docs ../../salida/tools/docs-guard/prefijos.txt ../../salida/A-11 ../../salida/.github; echo "rc=$?"
