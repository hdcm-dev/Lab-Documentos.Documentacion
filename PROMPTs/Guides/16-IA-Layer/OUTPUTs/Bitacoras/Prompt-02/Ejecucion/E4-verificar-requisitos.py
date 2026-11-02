#!/usr/bin/env python3
# E4-verificar-requisitos.py — U-5.6: falla si una especificación tiene un REQ-IA-nn sin criterio o sin prueba.
#
#   python3 -I E4-verificar-requisitos.py <especificacion.md>...
#   python3 -I E4-verificar-requisitos.py --autoprueba
#
# Lee toda tabla markdown cuya cabecera tenga las columnas «Id», «Criterio de aceptación» y «Prueba»
# (forma de §8 del Conocimiento v0). Por cada fila cuyo Id sea REQ-IA-nn exige: criterio y prueba no vacíos
# (un guion o «—» cuenta como vacío), Id con dos dígitos o más e Id único en el archivo. Una fila marcada
# «NO APLICA» en la columna Prueba pasa sólo si trae motivo («NO APLICA: <motivo>»).
# Salida: 0 = todo completo · 1 = hay requisitos incompletos · 2 = uso incorrecto o sin requisitos.
import re, sys

VACIO = {'', '-', '—', '–'}
ID = re.compile(r'^REQ-IA-\d{2,}$')

def celdas(linea):
    l = linea.strip()
    if not (l.startswith('|') and l.endswith('|')):
        return None
    return [c.strip() for c in re.split(r'(?<!\\)\|', l[1:-1])]

def revisar(texto, nombre):
    errores, vistos, n = [], {}, 0
    cab = None
    for i, linea in enumerate(texto.splitlines(), 1):
        c = celdas(linea)
        if c is None:
            cab = None
            continue
        if cab is None:
            cab = {k.lower(): j for j, k in enumerate(c)}
            if not {'id', 'criterio de aceptación', 'prueba'} <= cab.keys():
                cab = {}
            continue
        if not cab or all(set(x) <= set('-: ') for x in c):
            continue
        rid = c[cab['id']].strip('`') if cab['id'] < len(c) else ''
        if not rid.startswith('REQ-IA'):
            continue
        n += 1
        crit = c[cab['criterio de aceptación']] if cab['criterio de aceptación'] < len(c) else ''
        prue = c[cab['prueba']] if cab['prueba'] < len(c) else ''
        if not ID.match(rid):
            errores.append(f'{nombre}:{i}: Id mal formado «{rid}»')
        if rid in vistos:
            errores.append(f'{nombre}:{i}: Id repetido {rid} (primero en la línea {vistos[rid]})')
        vistos.setdefault(rid, i)
        if crit in VACIO:
            errores.append(f'{nombre}:{i}: {rid} sin criterio de aceptación')
        if prue in VACIO:
            errores.append(f'{nombre}:{i}: {rid} sin prueba')
        elif prue.upper().startswith('NO APLICA') and not re.match(r'(?i)^NO APLICA\s*:\s*\S', prue):
            errores.append(f'{nombre}:{i}: {rid} NO APLICA sin motivo')
    return n, errores

def autoprueba():
    bueno = ('| Id | Requisito | PROTO | PROD | Criterio de aceptación | Prueba |\n|---|---|---|---|---|---|\n'
             '| REQ-IA-01 | r | DEBE | DEBE | c | `T1` |\n| REQ-IA-02 | r | PUEDE | PUEDE | c | NO APLICA: sin RAG |\n')
    malo = bueno + '| REQ-IA-03 | r | DEBE | DEBE | — | `T3` |\n| REQ-IA-04 | r | DEBE | DEBE | c |  |\n' \
                   '| REQ-IA-01 | r | DEBE | DEBE | c | `T` |\n| REQ-IA-5 | r | DEBE | DEBE | c | `T` |\n' \
                   '| REQ-IA-06 | r | DEBE | DEBE | c | NO APLICA |\n'
    nb, eb = revisar(bueno, 'bueno')
    nm, em = revisar(malo, 'malo')
    ok = nb == 2 and not eb and nm == 7 and len(em) == 5
    print(f'autoprueba: bueno {nb} filas {len(eb)} errores; malo {nm} filas {len(em)} errores (se esperan 2/0 y 7/5)')
    for e in em:
        print('  ' + e)
    return 0 if ok else 1

def main(args):
    if args == ['--autoprueba']:
        return autoprueba()
    if not args:
        print(__doc__ or 'uso: E4-verificar-requisitos.py <especificacion.md>...', file=sys.stderr)
        return 2
    total, todos = 0, []
    for ruta in args:
        with open(ruta, encoding='utf-8') as f:
            n, e = revisar(f.read(), ruta)
        total += n; todos += e
    for e in todos:
        print(e)
    if total == 0:
        print('sin requisitos REQ-IA-nn en una tabla con Id, Criterio de aceptación y Prueba', file=sys.stderr)
        return 2
    print(f'{total} requisitos revisados, {len(todos)} incompletos')
    return 1 if todos else 0

if __name__ == '__main__':
    sys.exit(main(sys.argv[1:]))
