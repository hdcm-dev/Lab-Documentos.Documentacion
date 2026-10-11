#!/bin/sh
# J-I4 (juez de impacto, aprobación ciclo 2, 2026-10-09): las dos líneas de A.17 que leen el digest,
# en un repo cuyo workflow de A.12 se guardó con otro nombre (compuerta.yml, el name: del propio A.12).
set -u
T=$(mktemp -d); cd "$T"; mkdir -p .github/workflows
cat > .github/workflows/compuerta.yml <<'Y'
jobs:
  compuerta:
    runs-on: ubuntu-24.04
    container:
      image: ghcr.io/org/imagen-ci@sha256:0000000000000000000000000000000000000000000000000000000000000000
Y
cat > a17.sh <<'A'
#!/bin/sh
set -eu
img=$(sed -n 's/^ *\(container\|image\): *\([^ ]*@sha256:[0-9a-f]\{64\}\).*/\2/p' .github/workflows/ci.yml | head -1)
echo "imagen=${img:-NO DECLARADA (runner sin contenedor: capa 4 en el log «Set up job»)}"
A
echo "== workflow con container:, guardado como compuerta.yml =="; sh a17.sh; echo "rc=$?"
cp .github/workflows/compuerta.yml .github/workflows/ci.yml
echo "== el mismo, guardado como ci.yml =="; sh a17.sh; echo "rc=$?"
