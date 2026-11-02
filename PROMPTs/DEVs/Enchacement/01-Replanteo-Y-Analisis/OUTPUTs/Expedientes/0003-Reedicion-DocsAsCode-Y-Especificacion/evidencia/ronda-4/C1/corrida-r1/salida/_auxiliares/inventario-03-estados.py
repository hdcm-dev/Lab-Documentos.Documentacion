# Patrón 3 de §3.1: estado de cada documento de {carpeta-tecnica} (LG/SDD/Docs) y proporción planificada.
# Se lee status: del frontmatter; sin frontmatter, la fila «Estado» de la tabla de cabecera (o «**Estado:**»).
# Uso (dentro de ./aislado): python3 -I inventario-03-estados.py /corrida/repo LG/SDD/Docs
import os, re, sys
from collections import Counter

raiz, carpeta = sys.argv[1], sys.argv[2]
os.chdir(raiz)
filas, difieren = [], []
for d, subdirs, archivos in os.walk(carpeta):
    subdirs.sort()
    for a in sorted(archivos):
        if not a.endswith('.md'):
            continue
        p = os.path.join(d, a)
        lineas = open(p, encoding='utf-8', errors='replace').read().split('\n')
        fm = cab = None
        if lineas and lineas[0].strip() == '---':
            for i, l in enumerate(lineas[1:60], start=2):
                if l.strip() == '---':
                    break
                m = re.match(r'^status:\s*"?([^"#]+?)"?\s*$', l)
                if m:
                    fm = (m.group(1).strip(), i)
        for i, l in enumerate(lineas[:80], start=1):
            m = re.match(r'^\|\s*\**Estado\**\s*\|\s*(.+?)\s*\|\s*$', l) or re.match(r'^\*\*Estado:\*\*\s*(.+?)\s*$', l)
            if m:
                cab = (m.group(1).strip().strip('*`'), i)
                break
        legacy = '/_legacy/' in p + '/'
        if fm:
            filas.append((p, fm[0], f'{p}:{fm[1]}', 'frontmatter', legacy))
            if cab and cab[0].lower() != fm[0].lower():
                difieren.append(f'{p}:{fm[1]} status: {fm[0]}  ≠  {p}:{cab[1]} Estado: {cab[0]}')
        elif cab:
            filas.append((p, cab[0], f'{p}:{cab[1]}', 'cabecera', legacy))
        else:
            filas.append((p, '(sin estado)', p, '-', legacy))

def resumen(sel, rotulo):
    c = Counter(f[1].split(' ')[0].split(',')[0].split(';')[0].strip('*`.').lower() for f in sel)
    tot = len(sel)
    plan = sum(v for k, v in c.items() if k.startswith('planificad'))
    print(f'== {rotulo}: {tot} documentos .md; planificados {plan} ({(100*plan/tot if tot else 0):.1f} %)')
    for k, v in c.most_common():
        print(f'   {v:5d}  {k}')

resumen(filas, f'{carpeta} entera')
resumen([f for f in filas if not f[4]], f'{carpeta} sin _legacy/')
print('== documentos planificados (ruta:línea del estado)')
for f in filas:
    if f[1].lower().startswith('planificad'):
        print('  ', f[2], '→', f[1], f'({f[3]})')
print('== frontmatter y cabecera difieren (manda el frontmatter, I-02)')
for x in difieren:
    print('  ', x)
print('== estado de cada documento')
for f in filas:
    print(f'   {f[2]}\t{f[1]}\t{f[3]}')
