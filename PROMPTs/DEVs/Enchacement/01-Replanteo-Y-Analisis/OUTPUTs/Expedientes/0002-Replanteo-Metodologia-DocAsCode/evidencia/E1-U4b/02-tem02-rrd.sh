#!/usr/bin/env bash
# Ensayo TEM-SDEI-02 (E1-U4b): la fase 1b del ciclo deja su huella en el RRD, y la compuerta la verifica.
# Uso: bash 02-tem02-rrd.sh RAIZ_DE_LAB_DOCUMENTOS
# Caso 1: una fila sin criterio Dado/Cuando/Entonces y con una decisión fuera del vocabulario → rojo.
# Caso 2: la misma fila corregida → verde.
set -uo pipefail
RAIZ="$(cd "${1:?falta la raíz de Lab-Documentos}" && pwd)"
T="$(mktemp -d)"; trap 'rm -rf "$T"' EXIT
fm='---
doc_id: RD-TEM02
doc_type: rrd
title: RRD de ensayo
description: Registro de requerimientos documentales de prueba para el ensayo del tema 02.
status: borrador
origin: ia-generated
confidence: alta
owner: ensayo
last_review: 2026-10-27
audience: [analista]
traces: [RD-01]
---

# RRD de ensayo

| ID | Audiencia | Tarea | Pieza | Criterio | Decisión |
| --- | --- | --- | --- | --- | --- |'
mkdir -p "$T/rojo" "$T/verde"
printf '%s\n%s\n' "$fm" '| RD-01 | persona usuaria | cargar un comentario sin que se corte | CL-06, docs/ayuda/comentarios.md | la ayuda dice el límite | ok |' > "$T/rojo/_requisitos.md"
printf '%s\n%s\n' "$fm" '| RD-01 | persona usuaria | cargar un comentario sin que se corte | CL-06, docs/ayuda/comentarios.md | Dado el límite de la ficha, cuando la persona lee la ayuda, entonces el número coincide | aceptado |' > "$T/verde/_requisitos.md"
for c in rojo verde; do
  echo "== caso $c"
  python3 -I "$RAIZ/tools/docs-guard/dg.py" esquema --raiz "$T/$c" "$T/$c" 2>&1 | sed "s#$T/##g"
  echo "rc=${PIPESTATUS[0]}"
done
