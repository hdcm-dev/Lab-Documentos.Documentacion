#!/usr/bin/env bash
# aplicar.sh <dir-corrida> <prompt> — lanza el aplicador ciego de la ronda 4 como proceso aparte (expediente 0003).
# Directorio de trabajo = la corrida; sin fuentes de configuración del usuario ni del proyecto; sin MCP; sólo
# Read/Write/Edit/Glob/Grep/Bash; guardia PreToolUse; transcripción en <dir>/../_transcripciones/.
set -euo pipefail
D="$(cd "$1" && pwd -P)"; P="$2"; T="$(dirname "$D")/_transcripciones"; mkdir -p "$T"
cd "$D"
exec claude -p "$P" --setting-sources "" --settings {area-de-ensayo}/ensayos/insumos/aislado/guardia-settings.json \
  --strict-mcp-config --mcp-config '{"mcpServers":{}}' --tools Read Write Edit Glob Grep Bash \
  --permission-mode bypassPermissions --model claude-opus-5-5 --output-format stream-json --verbose \
  --append-system-prompt "Sos el aplicador de una corrida de ensayo. Toda consola: «cd $D && ./aislado <comando>» (tuberías sólo dentro de ./aislado bash -c '...'). Archivos sólo dentro de $D, con rutas absolutas; Glob/Grep con path. Lo rechazado por la guardia no se reintenta por otra vía." \
  > "$T/$(basename "$D")-$(date +%H%M%S).jsonl"
