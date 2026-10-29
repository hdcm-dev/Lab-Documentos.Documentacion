#!/usr/bin/env bash
# Ensayo TEM-SDEI-03 (E1-U4b): el ancla de versión de una traza y la unicidad del registro de IDs.
# Uso: bash 03-tem03-ancla.sh RAIZ_DE_LAB_DOCUMENTOS
# Caso 1: la ficha subió a 1.1 y la página sigue trazando a @1.0 → rojo.
# Caso 2: la página traza a @1.1 → verde.
# Caso 3: dos documentos declaran el mismo ID → rojo por ambigüedad (por eso los IDs llevan el corpus_id).
set -uo pipefail
RAIZ="$(cd "${1:?falta la raíz de Lab-Documentos}" && pwd)"
T="$(mktemp -d)"; trap 'rm -rf "$T"' EXIT
pagina() { cat <<MD
---
doc_id: DEMO-TEM03-PAG
doc_type: ficha
title: Ayuda del comentario
description: Página de ayuda de prueba que traza a la ficha de la regla del largo del comentario.
status: borrador
origin: ia-generated
confidence: alta
owner: ensayo
last_review: 2026-10-27
audience: [persona-usuaria]
traces: [DEMO-TEM03-01@$1]
---

# Ayuda del comentario

El comentario admite hasta 80 caracteres.
MD
}
ficha() { cat <<MD
---
doc_id: DEMO-TEM03-FICHAS$1
doc_type: ficha
title: Fichas de reglas
description: Ficha de prueba que declara la regla del largo máximo del comentario con su versión.
status: borrador
origin: ia-generated
confidence: alta
owner: ensayo
last_review: 2026-10-27
audience: [analista]
traces: [DEMO-TEM03-01]
---

# Fichas

## DEMO-TEM03-01 Largo máximo del comentario

**Versión:** 1.1

El campo admite 80 caracteres.
MD
}
caso() {
  echo "== $1"
  python3 -I "$RAIZ/tools/docs-guard/dg.py" trazas --raiz "$T/$2" "$T/$2" 2>&1 | sed "s#$T/##g"
  echo "rc=${PIPESTATUS[0]}"
}
mkdir -p "$T/c1" "$T/c2" "$T/c3"
pagina 1.0 > "$T/c1/ayuda.md"; ficha "" > "$T/c1/fichas.md"
pagina 1.1 > "$T/c2/ayuda.md"; ficha "" > "$T/c2/fichas.md"
pagina 1.1 > "$T/c3/ayuda.md"; ficha "" > "$T/c3/fichas.md"; ficha "-COPIA" > "$T/c3/otra-guia.md"
caso "caso 1: la página traza a @1.0 y la ficha está en 1.1" c1
caso "caso 2: la página traza a @1.1" c2
caso "caso 3: el ID se declara en dos documentos" c3
