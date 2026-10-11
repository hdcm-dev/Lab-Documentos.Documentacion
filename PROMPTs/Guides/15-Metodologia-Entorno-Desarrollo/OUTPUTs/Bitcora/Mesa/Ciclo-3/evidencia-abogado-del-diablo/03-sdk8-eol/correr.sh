#!/bin/sh
# Abogado del diablo, ciclo 3, experimento 03: ¿qué dice el propio SDK fijado por las plantillas (8.0.425, A.3)
# sobre su soporte, el día de la versión 1.0.0 de la guía? Y qué fija hoy la plantilla.
D=$(cd "$(dirname "$0")" && pwd)
G=$D/../../../../../../../../../../Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo
echo "== A.3 en el laboratorio (Examples/A-plantillas/repo/global.json):"; cat "$G/Examples/A-plantillas/repo/global.json"
echo "== ARG de la imagen de A.10:"; grep -n 'SDK_IMAGE' "$G/Examples/A-plantillas/repo/imagen/Dockerfile" | head -2
echo "== dotnet sdk check, dentro de mcr.microsoft.com/dotnet/sdk:8.0 (fecha del host: $(date -u +%F))"
docker run --rm -e DOTNET_NOLOGO=1 -e DOTNET_CLI_TELEMETRY_OPTOUT=1 mcr.microsoft.com/dotnet/sdk:8.0 dotnet sdk check
