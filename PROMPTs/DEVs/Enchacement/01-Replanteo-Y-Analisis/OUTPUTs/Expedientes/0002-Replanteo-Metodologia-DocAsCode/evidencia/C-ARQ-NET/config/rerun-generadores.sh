C=<intermedios>; O=$C/out2; U="-u $(id -u):$(id -g)"
# E9 MkDocs Material (pylib preinstalado: mkdocs 1.6.1 + material 9.6.23)
docker run --rm $U -e PYTHONPATH=/x/pylib -e HOME=/tmp -v $C:/x -w /x/mkdocs python:3.12-slim bash -c 'rm -rf site; s=$(date +%s%N); python -m mkdocs build --strict > /tmp/l 2>&1; echo "exit=$? build_ms=$(( ($(date +%s%N)-s)/1000000 ))"; echo "html=$(find site -name "*.html" | wc -l) md=$(find site -name "*.md" | wc -l)"; du -sh site' > $O/e9.txt 2>&1
sed -i 's#](../usuario/empezar.md)#](../usuario/no-existe.md)#' $C/mkdocs/docs/tecnica/arquitectura.md
docker run --rm $U -e PYTHONPATH=/x/pylib -e HOME=/tmp -v $C:/x -w /x/mkdocs python:3.12-slim bash -c 'python -m mkdocs build --strict 2>&1 | grep -E "WARNING|Aborted"; echo "exit=${PIPESTATUS[0]}"; python -m mkdocs build --strict -q >/dev/null 2>&1; echo "exit_con_-q=$?"' > $O/e10.txt 2>&1
sed -i 's#](../usuario/no-existe.md)#](../usuario/empezar.md)#' $C/mkdocs/docs/tecnica/arquitectura.md
# E11 Docusaurus 3.10.2 (node_modules ya instalados)
docker run --rm $U -e HOME=/tmp -v $C:/x -w /x/docusaurus node:24-bookworm-slim bash -c 'rm -rf build .docusaurus; s=$(date +%s%N); npx docusaurus build > /tmp/l 2>&1; echo "exit=$? build_ms=$(( ($(date +%s%N)-s)/1000000 ))"; echo "html=$(find build -name "*.html" | wc -l) md=$(find build -name "*.md" | wc -l)"; du -sh build node_modules' > $O/e11.txt 2>&1
sed -i 's#](../usuario/empezar.md)#](../usuario/no-existe.md)#' $C/docusaurus/docs/tecnica/arquitectura.md
docker run --rm $U -e HOME=/tmp -v $C:/x -w /x/docusaurus node:24-bookworm-slim bash -c 'rm -rf build; npx docusaurus build > /tmp/l 2>&1; echo "exit=$?"; grep -iE -m4 "broken|no-existe|error" /tmp/l' > $O/e12.txt 2>&1
sed -i 's#](../usuario/no-existe.md)#](../usuario/empezar.md)#' $C/docusaurus/docs/tecnica/arquitectura.md
