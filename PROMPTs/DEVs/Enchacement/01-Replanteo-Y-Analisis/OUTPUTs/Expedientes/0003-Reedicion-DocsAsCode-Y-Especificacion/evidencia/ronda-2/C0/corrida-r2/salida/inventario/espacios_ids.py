# Lista los espacios de IDs (prefijos) declarados en el repo, con su carpeta de origen, usando el registro de dg.py.
# Uso: python3 -I salida/inventario/espacios_ids.py repo/LD   (sólo lectura; no escribe bytecode)
import sys
sys.dont_write_bytecode = True
from pathlib import Path
raiz = Path(sys.argv[1]).resolve()
sys.path.insert(0, str(raiz / 'tools' / 'docs-guard'))
import dg
reg = dg.registro([str(raiz)])
pref = dg.prefijos()
esp = {}
for ident, decls in reg.items():
    p = ident.split('-')[0]
    for f, v, n in decls:
        top = '/'.join(Path(f).resolve().relative_to(raiz).parts[:2])
        esp.setdefault(p, {}).setdefault(top, set()).add(ident)
print(f'IDs declarados: {len(reg)}; duplicados: {sum(1 for d in reg.values() if len(d) > 1)}')
print('prefijo\tregistro\tIDs\tcarpetas de origen (IDs)')
for p in sorted(esp):
    total = len(set().union(*esp[p].values()))
    orig = '; '.join(f'{k} ({len(v)})' for k, v in sorted(esp[p].items()))
    print(f'{p}\t{pref.get(p, "FUERA DEL REGISTRO")}\t{total}\t{orig}')
rd = sorted(i for i in reg if i.startswith('RD-'))
print('RD en uso:', ' '.join(rd) if rd else '(ninguno en el árbol legible)')
