#!/usr/bin/env bash
# Ensayo de TEM-SDEI-01 y TEM-SDEI-03 (E1-U4b): adopciones públicas de cada práctica recomendada, con fecha.
# Uso: bash 04-adopciones.sh [FECHA_DE_CORTE]   (por defecto, hoy; el umbral es de 24 meses antes del corte)
# Requiere curl, jq y git. Sin token alcanza (15 consultas a la API pública de GitHub; el límite anónimo es 60 por hora).
# Con DG_CURL_CONFIG apuntando a un archivo de configuración de curl, lo usa (por ejemplo, para una cabecera de token).
# Para cada adopción: el último commit que tocó la ruta que materializa la práctica, su fecha y si cae en la ventana.
set -uo pipefail
CORTE="${1:-$(date -u +%F)}"
LIMITE="$(date -u -d "$CORTE -24 months" +%F)"
CFG=(); [[ -n "${DG_CURL_CONFIG:-}" ]] && CFG=(-K "$DG_CURL_CONFIG")
echo "corte: $CORTE · ventana desde: $LIMITE"
printf '%-6s %-28s %-32s %-12s %-10s %s\n' práct repositorio ruta commit fecha "≤24m"
adop() {  # PRÁCTICA REPO RUTA
  local j sha fecha ok
  j="$(curl -fsS "${CFG[@]}" "https://api.github.com/repos/$2/commits?path=$3&per_page=1")" || { echo "$1 $2 $3 ERROR"; return; }
  sha="$(jq -r '.[0].sha // empty' <<<"$j" | cut -c1-12)"; fecha="$(jq -r '.[0].commit.committer.date // empty' <<<"$j" | cut -c1-10)"
  [[ -z "$sha" ]] && { printf '%-6s %-28s %-32s %s\n' "$1" "$2" "$3" "SIN COMMITS"; return; }
  ok=no; [[ "$fecha" > "$LIMITE" || "$fecha" == "$LIMITE" ]] && ok=sí
  printf '%-6s %-28s %-32s %-12s %-10s %s\n' "$1" "$2" "$3" "$sha" "$fecha" "$ok"
}
# TEM-01, P1: documentación en Git, revisada por PR y verificada en CI (docs as code)
adop P1 github/docs content
adop P1 github/docs .github/workflows/link-check-daily.yml
adop P1 kubernetes/website content/en
adop P1 MicrosoftDocs/azure-docs articles
# TEM-01, P2: la referencia de la API sale de un contrato OpenAPI versionado
adop P2 github/rest-api-description descriptions
adop P2 stripe/openapi openapi
# TEM-01, P3: lint de prosa en la CI (Vale) además de enlaces
adop P3 mintlify/docs .vale.ini
adop P3 openshift/openshift-docs .vale.ini
adop P3 grafana/grafana .vale.ini
# TEM-03, P4: la documentación vive en el mismo repositorio que el código que describe
adop P4 backstage/backstage docs
adop P4 grafana/grafana docs/sources
# TEM-03, P5: repositorio de documentación separado, con una rama por versión del producto
adop P5 kubernetes/website content/en
adop P5 istio/istio.io content
for r in kubernetes/website istio/istio.io; do
  n="$(git ls-remote --heads "https://github.com/$r.git" 'release-1.*' | wc -l)"
  u="$(git ls-remote --heads "https://github.com/$r.git" 'release-1.*' | sed 's#.*refs/heads/##' | sort -V | tail -1)"
  printf 'P5     %-28s ramas release-1.*: %s (la última: %s)\n' "$r" "$n" "$u"
done
# TEM-03, P6: copias versionadas de la documentación sólo cuando conviven versiones (Docusaurus)
adop P6 facebook/docusaurus website/versioned_docs
adop P6 jestjs/jest website/versioned_docs
