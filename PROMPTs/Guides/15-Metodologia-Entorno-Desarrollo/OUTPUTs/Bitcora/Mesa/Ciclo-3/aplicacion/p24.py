# P-24: notas de solo agregado en la capa de origen, leídas de la tabla de §4 de 03-Parches.md.
# Uso: python3 -I p24.py <Bitcora> [--escribir]
import sys, os, re
B = sys.argv[1]; esc = '--escribir' in sys.argv
src = open(os.path.join(B, 'Mesa/Ciclo-3/03-Parches.md'), encoding='utf-8').read()
sec = src[src.index('## 4. P-24'):src.index('## 5. P-25')]
filas = [l for l in sec.split('\n') if re.match(r'^\| O-\d+ \|', l)]
RUTA = {'04-Integracion.md': '04-Integracion.md', 'Mesa/Ciclo-1/03-Parches.md': 'Mesa/Ciclo-1/03-Parches.md',
        'Mesa/Ciclo-2/01-Consolidado.md': 'Mesa/Ciclo-2/01-Consolidado.md'}
errores = []; plan = []
for f in filas:
    oid, arch, ancla, nota = f.split(' | ', 3)
    oid = oid.strip('| ').strip(); arch = arch.strip('`')
    nota = nota[:-2] if nota.endswith(' |') else nota
    nota = nota.strip()[1:-1]  # quita el par de backticks exterior
    ruta = os.path.join(B, RUTA.get(arch, arch))
    t = open(ruta, encoding='utf-8').read(); L = t.split('\n')
    if ancla.startswith('al final'):
        pos = len(L)
        while pos > 0 and L[pos-1] == '': pos -= 1
    else:
        a = max(re.findall(r'`([^`]+)`', ancla), key=len)
        hits = [i for i, l in enumerate(L) if a in l]
        if len(hits) != 1: errores.append((oid, arch, len(hits))); continue
        i = hits[0]
        # fin del bloque: si está dentro de un bloque de código, hasta el cierre; si no, hasta la línea en blanco
        dentro = sum(1 for l in L[:i] if l.startswith('```')) % 2 == 1
        j = i + 1
        if dentro:
            while not L[j].startswith('```'): j += 1
            j += 1
        else:
            while j < len(L) and L[j].strip() != '': j += 1
        pos = j
    plan.append((oid, ruta, pos, nota))
if errores: print('ERRORES', errores); sys.exit(1)
# aplicar de abajo hacia arriba por archivo
from collections import defaultdict
porarch = defaultdict(list)
for p in plan: porarch[p[1]].append(p)
for ruta, ps in porarch.items():
    L = open(ruta, encoding='utf-8').read().split('\n')
    for oid, _, pos, nota in sorted(ps, key=lambda x: -x[2]):
        L[pos:pos] = ['', nota]
        print(oid, os.path.relpath(ruta, B), 'línea', pos + 2)
    if esc: open(ruta, 'w', encoding='utf-8').write('\n'.join(L))
print('notas', len(plan), 'escrito' if esc else '(simulado)')
