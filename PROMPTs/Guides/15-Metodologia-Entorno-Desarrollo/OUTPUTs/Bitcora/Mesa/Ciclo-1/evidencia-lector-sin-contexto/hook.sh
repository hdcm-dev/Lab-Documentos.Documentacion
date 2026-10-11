#!/usr/bin/env bash
# Estación sin Python (como un Windows con VS + Git for Windows): ¿qué hace el hook de A.11?
EX=/ex; W=/tmp/h; rm -rf $W; mkdir -p $W; cd $W
git config --global user.email d@x; git config --global user.name dev; git config --global init.defaultBranch main
git init -q r; cd r
cp $EX/A-plantillas/repo/.editorconfig $EX/A-plantillas/repo/.gitattributes .
cp -r $EX/A-plantillas/repo/.githooks .; mkdir -p tools/ci
echo "== (a) hook de A.11 + esqueleto de A-plantillas, archivo en cp1252"
cp $EX/A-plantillas/repo/tools/ci/compuerta.sh tools/ci/
git config core.hooksPath .githooks
printf 'class A { string s = "Atenci\xf3n"; }\n' > A.cs; git add -A
git commit -qm cp1252 && echo "   commit ACEPTADO (exit $?)"; git log --oneline | head -1
echo "== (b) compuerta completa de N7 copiada a tools/ci (la que A.11 señala), sin python3 en la estación"
git reset -q --soft HEAD~1 2>/dev/null || true; git rm -q --cached -r . >/dev/null; rm -rf .git; git init -q; git config core.hooksPath .githooks
cp $EX/N7-compuertas-y-gobierno/compuerta/compuerta.sh tools/ci/compuerta.sh
printf 'class A { string s = "Atención"; }\n' > A.cs; git add -A
command -v python3 || echo "   (no hay python3 en esta estación)"
git commit -qm utf8-valido; echo "   exit=$?"
echo "== (c) con python3 copiando check_text_policy.py junto a la compuerta? -> la guía no lo dice"
