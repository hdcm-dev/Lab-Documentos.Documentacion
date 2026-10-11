# Aplica a la guía REAL los parches pedidos, con los ops de evidencia-auditor/simulacion/parches_guia.py.
# Uso: GUIA=<guía> python3 -I aplicar.py P-18 [P-01 ...]   (falla y no escribe si un ancla no es única)
# Opcional: SOLO_OPS=P-07:0,1,2 aplica sólo esos índices de op de ese parche; SALTAR_OPS=P-07:5 los omite.
import os, re, sys, json, importlib.util
S = os.path.dirname(os.path.abspath(__file__))
spec = importlib.util.spec_from_file_location('pg', os.path.join(S, '../evidencia-auditor/simulacion/parches_guia.py'))
pg = importlib.util.module_from_spec(spec); spec.loader.exec_module(pg)
G = os.environ['GUIA']; txt = open(G, encoding='utf-8').read()
def sel(var):
    d = {}
    for item in filter(None, os.environ.get(var, '').split(';')):
        pid, ks = item.split(':'); d[pid] = {int(k) for k in ks.split(',')}
    return d
solo, saltar = sel('SOLO_OPS'), sel('SALTAR_OPS')
errores = []; log = []
for pid in sys.argv[1:]:
    P = [p for p in pg.P if p['id'] == pid][0]
    for i, op in enumerate(P['ops']):
        if pid in solo and i not in solo[pid]: continue
        if pid in saltar and i in saltar[pid]: log.append((pid, i, 'omitido')); continue
        k = op[0]
        if k in ('R', 'RA'):
            n = txt.count(op[1])
            if (k == 'R' and n != 1) or n < 1: errores.append((pid, i, k, n, op[1][:70])); continue
            txt = txt.replace(op[1], op[2]); log.append((pid, i, f'{k} x{n}'))
        elif k == 'RL':
            st = [m.start() for m in re.finditer(r'(?m)^' + re.escape(op[1]), txt)]
            if len(st) != 1: errores.append((pid, i, 'RL', len(st), op[1][:70])); continue
            a = st[0]; b = txt.find('\n', a); txt = txt[:a] + op[2] + txt[b:]; log.append((pid, i, 'RL'))
        else:
            a, b, new = op[1], op[2], op[3]
            if txt.count(a) != 1: errores.append((pid, i, 'RG-desde', txt.count(a), a[:70])); continue
            ia = txt.find(a)
            if b == '\x00FIN': ib = len(txt)
            else:
                ib = txt.find(b, ia)
                if ib < 0 or txt.count(b) != 1: errores.append((pid, i, 'RG-hasta', txt.count(b), b[:70])); continue
            txt = txt[:ia] + new + txt[ib:]; log.append((pid, i, 'RG'))
if errores:
    print('ERRORES (no se escribe):', *errores, sep='\n'); sys.exit(1)
open(G, 'w', encoding='utf-8').write(txt)
for x in log: print(*x)
print('ok', len(log), 'ops')
