#!/usr/bin/env bash
# X0 (C2-24): DOCKER_CONFIG vacío cambia el plugin buildx; alternativa que conserva los plugins.
set -u
echo "== plugin por defecto";        docker buildx version
echo "== DOCKER_CONFIG=\$(mktemp -d)"; DOCKER_CONFIG=$(mktemp -d) docker buildx version
D=$(mktemp -d); mkdir -p "$D"; ln -s "$HOME/.docker/cli-plugins" "$D/cli-plugins"
echo "== DOCKER_CONFIG temporal con cli-plugins enlazado"; DOCKER_CONFIG=$D docker buildx version
echo '   --format {{.Manifest.Digest}} (una sola línea esperada):'
DOCKER_CONFIG=$D docker buildx imagetools inspect mcr.microsoft.com/dotnet/sdk:8.0 --format '{{.Manifest.Digest}}'
