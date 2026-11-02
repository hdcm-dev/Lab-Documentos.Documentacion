#!/usr/bin/env python3
"""Relectura C2 (verificación/QA): cada bloque de código de la guía con «Compila en <ruta> (l. a–b)»
se compara con el archivo citado. Uso: python3 -I verificar-snippets.py <carpeta-de-la-guía>"""
import re, sys, os, glob
raiz = sys.argv[1]
guia = open(os.path.join(raiz, 'Dot-Net-Integration-AI-Layer-Guide.md'), encoding='utf-8').read().split('\n')
archivos = [p for p in glob.glob(os.path.join(raiz, '**', '*'), recursive=True)
            if os.path.isfile(p) and '/bin/' not in p and '/obj/' not in p]
def norm(s): return re.sub(r'\s+', ' ', s).strip()
# bloques
bloques, i = [], 0
while i < len(guia):
    m = re.match(r'^\s*```(\w+)', guia[i])
    if m:
        lang, ini = m.group(1), i
        j = i + 1
        while not guia[j].strip().startswith('```'): j += 1
        bloques.append((lang, ini + 1, guia[i+1:j])); i = j + 1
    else: i += 1
rx = re.compile(r'[Cc]ompila(?:n)? (?:\(se copia a la salida\) )?en `([^`]+)`[^`]*?(?:l\.|líneas?)\s*(\d+)\s*[-–]\s*(\d+)')
ultimo_ejemplo = None
res = []
for lang, linea, cuerpo in bloques:
    if lang not in ('csharp',): continue
    # contexto: 6 líneas antes y 4 después
    ctx_antes = '\n'.join(guia[max(0, linea-8):linea-1]); ctx_desp = '\n'.join(guia[linea+len(cuerpo):linea+len(cuerpo)+4])
    m = rx.search(ctx_desp) or None
    if not m:
        ms = list(rx.finditer(ctx_antes)); m = ms[-1] if ms else None
    for mm in re.finditer(r'`((?:Examples|Demos)/[^`/]+)', '\n'.join(guia[:linea])): ultimo_ejemplo = mm.group(1)
    if not m: res.append((linea, 'SIN-REF', '', '')); continue
    ruta, a, b = m.group(1), int(m.group(2)), int(m.group(3))
    suf = ruta.replace('…/', '').lstrip('/')
    cands = [p for p in archivos if p.endswith('/' + suf) or p.endswith(suf)]
    if len(cands) > 1 and ultimo_ejemplo:
        c2 = [p for p in cands if ('/' + ultimo_ejemplo.split('/')[-1] + '/') in p]
        cands = c2 or cands
    if len(cands) != 1: res.append((linea, f'RUTA-AMBIGUA({len(cands)})', ruta, f'{a}-{b}')); continue
    src = open(cands[0], encoding='utf-8').read().split('\n')
    lineas_bloque = [norm(l) for l in cuerpo if norm(l) and not norm(l).startswith('// …') and '…' not in l]
    tramo = [norm(l) for l in src[a-1:b]]
    todo = [norm(l) for l in src]
    en_tramo = sum(1 for l in lineas_bloque if l in tramo)
    en_archivo = sum(1 for l in lineas_bloque if l in todo)
    n = len(lineas_bloque)
    estado = 'OK' if en_tramo == n else ('LINEAS-CORRIDAS' if en_archivo == n else 'DIFIERE')
    detalle = '' if estado == 'OK' else '; '.join(l[:70] for l in lineas_bloque if l not in todo)[:300]
    if estado == 'LINEAS-CORRIDAS':
        idx = [k+1 for k, l in enumerate(todo) if l == lineas_bloque[0]]
        detalle = f'primera línea del bloque en l. {idx[:3]}'
    res.append((linea, estado, os.path.relpath(cands[0], raiz), f'{a}-{b} {en_tramo}/{n} {detalle}'))
for r in res: print(*r, sep=' | ')
from collections import Counter
print('RESUMEN', Counter(r[1] for r in res))
