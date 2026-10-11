#!/bin/sh
# Abogado del diablo, ciclo 2, AD-02. La herramienta existente (editorconfig-checker 4.0.2) sobre el
# repositorio de plantillas del Anexo A (proyectos en subcarpetas), en las mismas condiciones en que
# el ciclo 2 encontró fallas de la compuerta propia: cp1252 del caso en src/App, archivos copiados
# "desde Windows" sin bit de ejecución, salidas de build sin .gitignore y una imagen sin Python.
# Uso (host con docker y git): sh experimento.sh <dir-plantillas-A> <dir-trabajo>
set -u
P=$1; W=$2; EC=ghcr.io/editorconfig-checker/editorconfig-checker:4.0.2
rm -rf "$W"; mkdir -p "$W"; cp -a "$P/." "$W/"; cd "$W" || exit 2
git init -q && git -c user.email=a@b -c user.name=ad add -A && git -c user.email=a@b -c user.name=ad commit -qm plantillas
ec() { docker run --rm --network none -u "$(id -u):$(id -g)" -v "$W":/check:ro "$EC" /usr/bin/editorconfig-checker -no-color "$@"; }
echo "== 0. Imagen: $(docker run --rm $EC /usr/bin/editorconfig-checker --version) ; ¿trae python3? $(docker run --rm --entrypoint sh $EC -c 'command -v python3 || echo no')"
echo "== 1. Plantillas limpias (lo que EA-1 da como 0 violaciones con la compuerta propia)"
ec; echo "rc=$?"
echo "== 2. El .cs del caso en cp1252, en una SUBCARPETA (src/App), y un .razor sin BOM"
printf 'class Alarma { string \307audal = "Atenci\363n"; }\n' > src/App/Alarma.cs
printf '<h1>Hola</h1>\n' > src/App/X.razor
ec; echo "rc=$?"
echo "== 3. Salidas de build sin .gitignore: obj/ con BOM (como *.nuget.g.props) y sin versionar"
mkdir -p src/App/obj; printf '\357\273\277<Project />\n' > src/App/obj/App.csproj.nuget.g.props
ec 2>&1 | grep 'obj/' | sed 's/^/   sin .gitignore: /'
printf 'obj/\nbin/\n' > .gitignore
ec 2>&1 | grep -c 'obj/' | sed 's/^/   con .gitignore (obj\/ excluido), líneas que mencionan obj\/: /'
echo "== 4. Sólo lo versionado (git ls-files) — equivalente al alcance de la CI sobre clon limpio"
git -c user.email=a@b -c user.name=ad add src/App/Alarma.cs src/App/X.razor >/dev/null
ec $(git ls-files | tr '\n' ' '); echo "rc=$?"
