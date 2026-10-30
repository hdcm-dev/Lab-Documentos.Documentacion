#!/usr/bin/env bash
# Chequeo de E1-U4b sobre los temas (VER-T01..T07 y VER-G08): los seis encabezados del Profile, idénticos y en orden,
# el enlace al anterior y al siguiente, y las citas APA con ancla ref-… que resuelven en el anexo de referencias.
# Uso: bash 05-encabezados-y-enlaces.sh RAIZ_DE_LAB_DOCUMENTOS
set -uo pipefail
RAIZ="$(cd "${1:?falta la raíz de Lab-Documentos}" && pwd)"
G="$RAIZ/Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion"
python3 -I - "$G" <<'PY'
import re, sys
from pathlib import Path
g = Path(sys.argv[1]); rc = 0
seis = ['Definición', 'Aplicación por escenario', 'Ejemplos concretos', 'Preguntas guía', 'Criterios de calidad', 'Anexo']
anclas = set(re.findall(r'<a id="(ref-[^"]+)"', (g / '99-Anexos/Referencias.md').read_text()))
for f in sorted(g.glob('TEM-*.md')):
    t = f.read_text()
    h2 = [h for h in re.findall(r'^## (.+)$', t, re.M) if h in seis]
    ok6 = h2 == seis
    pie = t.strip().splitlines()[-8:]
    ant = any('Documento anterior: [' in l for l in pie); sig = any('Siguiente documento:' in l for l in pie)
    citas = re.findall(r'Referencias\.md#(ref-[^)\s]+)\)', t)
    rotas = sorted(set(citas) - anclas)
    fuentes = len(set(citas))
    print(f'{f.name}: seis encabezados en orden={ok6} anterior={ant} siguiente={sig} '
          f'fuentes citadas={fuentes} citas sin ancla={rotas or 0}')
    rc |= not (ok6 and ant and sig and not rotas and fuentes >= 3)
print('resultado:', 'verde' if rc == 0 else 'ROJO'); sys.exit(rc)
PY
