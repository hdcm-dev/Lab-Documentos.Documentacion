# Lista los espacios de IDs declarados en el repo (doc_id, RD-nn, encabezados) con la función registro() de dg.py.
import sys, importlib.util
from pathlib import Path
from collections import defaultdict
dg_path, raiz = sys.argv[1], Path(sys.argv[2]).resolve()
spec = importlib.util.spec_from_file_location('dg', dg_path); dg = importlib.util.module_from_spec(spec)
sys.dont_write_bytecode = True; spec.loader.exec_module(dg)
reg = dg.registro([raiz]); pref = dg.prefijos()
esp = defaultdict(lambda: [0, set()])
for ident, decl in reg.items():
    p = ident.split('-')[0]
    esp[p][0] += 1
    for f, v, n in decl:
        rel = str(Path(f).resolve().relative_to(raiz)).split('/')
        esp[p][1].add('/'.join(rel[:2]) if len(rel) > 1 else rel[0])
print('prefijo\tids\tregistro\tcarpetas-de-origen')
for p in sorted(esp):
    print(f"{p}\t{esp[p][0]}\t{pref.get(p,'FUERA-DEL-REGISTRO')}\t{', '.join(sorted(esp[p][1]))}")
print(f"total-ids\t{len(reg)}\tprefijos\t{len(esp)}\tfuera-del-registro\t{sum(1 for p in esp if p not in pref)}")
