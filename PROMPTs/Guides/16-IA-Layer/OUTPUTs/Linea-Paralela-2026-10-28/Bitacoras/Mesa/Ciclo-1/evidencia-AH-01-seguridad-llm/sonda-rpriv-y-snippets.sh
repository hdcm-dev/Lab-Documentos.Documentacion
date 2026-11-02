#!/usr/bin/env bash
# Sonda E1 de AH-01 (2026-10-28, estación 1). Sólo lectura. Enmascara los dos últimos octetos de toda IP.
# Excluye los Informe-*.md y evidencias de otros especialistas del ciclo (revisión a ciegas).
set -u
B="${1:?carpeta OUTPUTs de 16-IA-Layer}"; cd "$B" || exit 1
echo "## 1. Rutas del home por archivo (conteo)"; grep -rc -E '/home/' --include=*.md --exclude=Informe-*.md --exclude-dir=evidencia-* . | grep -v ':0$'
echo "## 2. IPs privadas o de tailnet (RFC 1918 y <rango-cgnat>), enmascaradas"
grep -rno -E '\b(100\.(6[4-9]|[7-9][0-9]|1[01][0-9]|12[0-7])|192\.168|10\.[0-9]+|172\.(1[6-9]|2[0-9]|3[01]))\.[0-9]+\.[0-9]+' --include=*.md --exclude=Informe-*.md --exclude-dir=evidencia-* . | sed -E 's/\.[0-9]+\.[0-9]+$/.x.x/'
echo "## 3. Usuario@host en comandos (enmascarado)"; grep -rno -E '[a-z]+@(<IP|[0-9])' --include=*.md --exclude=Informe-*.md --exclude-dir=evidencia-* . | sed -E 's/@.*/@{enmascarado}/'
echo "## 4. Hostnames del laboratorio en los núcleos y en BIT-16-04 (conteo por archivo)"
for f in Bitacoras/Nucleos/*.md Bitacoras/04-Integracion.md; do printf '%s ' "$f"; grep -o -i -E 'estación 1|equipo anterior|estación 2' "$f" | wc -l; done
echo "## 5. Hostname dentro del diagrama de BIT-16-04 §6.2"; grep -n -E 'OLL\[' Bitacoras/04-Integracion.md
echo "## 6. Puerto 11434: anfitriones con que aparece"; grep -rho -E '[a-zA-Z0-9.<>_-]+:11434' --include=*.md --exclude=Informe-*.md --exclude-dir=evidencia-* . | sort | uniq -c
echo "## 7. Aprobación cableada en true (N4 §4.3)"; grep -n -E 'aprobado = ' Bitacoras/Nucleos/*.md
echo "## 8. Cliente MCP con npx -y sin versión (N4 §4.6)"; grep -n -E 'npx' Bitacoras/Nucleos/*.md
echo "## 9. Menciones de OWASP/inyección en N4"; grep -c -i -E 'owasp|inyecci|injection' Bitacoras/Nucleos/N4-Agentes-Y-Orquestacion.md
echo "## 10. Controles de MCP o de salida hacia la UI en M1–M12 (BIT-16-04 §6.3)"; sed -n '/^| M1 /,/^| M12 /p' Bitacoras/04-Integracion.md | grep -c -i -E 'mcp|AllowedHosts|encod|Markup|adversari'
echo "## 11. Contexto RAG concatenado sin marcar (N6 §4.3)"; grep -n -E 'contexto.AppendLine' Bitacoras/Nucleos/N6-Caso-Movilidad-Urbana.md
