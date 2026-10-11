# Aplica a la guía REAL un parche del lote (lote.py); falla y no escribe si un ancla no aparece las veces declaradas.
# Uso: GUIA=<guía> python3 -I aplicar.py P-16
import os, sys, json
sys.path.insert(0, os.path.dirname(os.path.abspath(__file__)))
from lote import P
G = os.environ['GUIA']; t = open(G, encoding='utf-8').read()
pid = sys.argv[1]; err = []
for i, op in enumerate(P[pid]['ops'], 1):
    n = op[3] if op[0] == 'all' else 1; c = t.count(op[1])
    if c != n: err.append(f'{pid} op {i}: ancla con {c} apariciones (se esperaban {n}): {op[1][:80]!r}'); continue
    t = t.replace(op[1], op[2])
if err: print('\n'.join(err)); sys.exit(1)
open(G, 'w', encoding='utf-8').write(t); print(pid, 'aplicado:', len(P[pid]['ops']), 'ops')
