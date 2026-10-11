EX=/ex; W=/tmp/h; rm -rf $W; mkdir -p $W/r; cd $W/r; git init -q; git config user.email d@x; git config user.name d
cp $EX/A-plantillas/repo/.editorconfig $EX/A-plantillas/repo/.gitattributes .; cp -r $EX/A-plantillas/repo/.githooks .; mkdir -p tools/ci
cp $EX/N7-compuertas-y-gobierno/compuerta/compuerta.sh tools/ci/; git config core.hooksPath .githooks
printf 'class A { string s = "Atención"; }\n' > A.cs; git add -A; git commit -qm ok; echo "exit=$?"
