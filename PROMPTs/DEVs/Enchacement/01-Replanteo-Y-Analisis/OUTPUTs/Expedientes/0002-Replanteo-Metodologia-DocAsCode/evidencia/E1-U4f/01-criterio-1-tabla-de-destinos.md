# 01 — Criterio 1: cada sección de GUIA tiene destino (rama exp0002/e1-u4f-guia-obsoleta, base origin/main ecb6342)

$ python3 -I c1.py GUIA-DIR
secciones=47 filas=47 sin-destino=0 doc_id-inexistente=0
rc=0

Anclas de la tabla: las valida PR-1 (lychee --offline --include-fragments) en 02.

## Script
```python
# Criterio 1: cada sección (H2/H3 fuera de código) de GUIA tiene fila en la tabla de destinos con doc_id que existe.
import re, sys, os
G = sys.argv[1]; p = os.path.join(G, 'Sistema-Documentador-Tecnico-Guide.md')
txt = open(p, encoding='utf-8').read().split('\n')
cod = False; heads = []; filas = {}
ids = set()
for base, _, fs in os.walk(G):
    for f in fs:
        if f.endswith('.md'):
            m = re.search(r'^doc_id: (\S+)', open(os.path.join(base, f), encoding='utf-8').read(), re.M)
            if m: ids.add(m.group(1))
for l in txt:
    if re.match(r'^\s*(```|~~~)', l): cod = not cod; continue
    if cod: continue
    m = re.match(r'^#{2,3} (.*)$', l)
    if m and m.group(1) not in ('Estado: obsoleto', 'Tabla de destinos'): heads.append(m.group(1))
    m = re.match(r'^\| \[(.+?)\]\(#[^)]+\) \| `([A-Z0-9-]+)` \|', l)
    if m: filas[m.group(1)] = m.group(2)
sin = [h for h in heads if h not in filas]
malos = {h: d for h, d in filas.items() if d not in ids}
print(f'secciones={len(heads)} filas={len(filas)} sin-destino={len(sin)} doc_id-inexistente={len(malos)}')
for h in sin: print('  SIN DESTINO:', h)
for h, d in malos.items(): print('  DOC_ID INEXISTENTE:', h, d)
sys.exit(1 if sin or malos else 0)
```
