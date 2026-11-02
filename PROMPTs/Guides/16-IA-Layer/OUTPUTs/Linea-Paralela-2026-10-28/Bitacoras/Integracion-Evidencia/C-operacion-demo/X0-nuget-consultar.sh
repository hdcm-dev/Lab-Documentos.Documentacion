#!/usr/bin/env bash
# Consulta la última estable y la última preview de cada paquete en el flatcontainer de nuget.org.
set -euo pipefail
for p in "$@"; do
  id=$(echo "$p" | tr 'A-Z' 'a-z')
  v=$(curl -fsS "https://api.nuget.org/v3-flatcontainer/$id/index.json" | python3 -I -c 'import sys,json; vs=json.load(sys.stdin)["versions"]; st=[x for x in vs if "-" not in x]; pr=[x for x in vs if "-" in x]; print((st[-1] if st else "—")+"\t"+(pr[-1] if pr else "—"))' 2>/dev/null || echo "404	404")
  printf '%s\t%s\n' "$p" "$v"
done
