#!/usr/bin/env bash
# E01 — publica el contenido Blazor WASM con una versión, lo comprime en zip (sin los .br/.gz precomprimidos),
# calcula sha256 y escribe manifest.json en el directorio que sirve el servidor estático.
# Uso (dentro del contenedor de compilación, con el ensayo montado en /work):
#   bash /work/src/tools/empaquetar.sh v1
set -euo pipefail
VER="${1:?versión, p. ej. v1}"
W=/work
PUB="$W/evidencia/local/salida/contenido-$VER"
SRV="$W/evidencia/local/servidor"
mkdir -p "$SRV"

dotnet publish "$W/src/Contenido/Contenido.csproj" -c Release -p:ContenidoVersion="$VER" -o "$PUB" 2>&1 | tail -3

cd "$PUB/wwwroot"
rm -f "$SRV/contenido-$VER.zip"
# El WebView no negocia Content-Encoding con lo que sirve el interceptor: se empaquetan sólo los archivos planos.
find . -type f ! -name '*.br' ! -name '*.gz' | sort | zip -q -X -@ "$SRV/contenido-$VER.zip"

ZIP="$SRV/contenido-$VER.zip"
SHA=$(sha256sum "$ZIP" | cut -d' ' -f1)
TAM=$(stat -c %s "$ZIP")
SIN=$(find . -type f ! -name '*.br' ! -name '*.gz' -printf '%s\n' | awk '{s+=$1} END{print s}')
N=$(find . -type f ! -name '*.br' ! -name '*.gz' | wc -l)
printf '{"version":"%s","archivo":"contenido-%s.zip","sha256":"%s","tamano":%s}\n' "$VER" "$VER" "$SHA" "$TAM" > "$SRV/manifest.json"
echo "paquete=$ZIP zip_bytes=$TAM sin_comprimir_bytes=$SIN archivos=$N sha256=$SHA"
cat "$SRV/manifest.json"
