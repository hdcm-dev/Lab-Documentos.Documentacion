#!/usr/bin/env bash
# Ensayo TEM-SDEI-01 (E1-U4b): inventario de las piezas de un sistema documentador real, por comando.
# Uso: bash 01-tem01-inventario.sh RAIZ_DE_LAB_DOCUMENTOS
# Lee el frontmatter de cada .md de la guía con el mismo parser de docs-guard y clasifica cada pieza.
set -euo pipefail
RAIZ="$(cd "${1:?falta la raíz de Lab-Documentos}" && pwd)"
GUIA="Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion"
cd "$RAIZ"
echo "commit: $(git rev-parse --short HEAD)"
python3 -I - "$RAIZ" "$GUIA" <<'PY'
import sys, collections
from pathlib import Path
raiz, guia = Path(sys.argv[1]), sys.argv[2]
sys.path.insert(0, str(raiz / 'tools/docs-guard'))
import dg
tipos = collections.Counter(); sin = []
for f in sorted((raiz / guia).rglob('*.md')):
    fm, _ = dg.frontmatter(dg.leer(f))
    if fm and fm.get('doc_type'):
        tipos[str(fm['doc_type'])] += 1
    elif fm and fm.get('title'):
        tipos['ayuda (sin doc_id)'] += 1
    else:
        sin.append(str(f.relative_to(raiz / guia)))
print('piezas .md con frontmatter, por doc_type:')
for t, n in sorted(tipos.items()):
    print(f'  {t:22} {n}')
print(f'  sin frontmatter (README de ejemplos): {len(sin)}')
otras = sorted(p.relative_to(raiz / guia) for p in (raiz / guia).rglob('*')
               if p.is_file() and p.suffix in {'.json', '.lock', '.sh'})
print('piezas que no son prosa:', ', '.join(map(str, otras)))
wf = sorted(p.name for p in (raiz / '.github/workflows').glob('*.yml'))
print('workflows que corren compuertas:', ', '.join(wf))
PY
