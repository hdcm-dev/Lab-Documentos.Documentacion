#!/usr/bin/env python3
"""M4 (invenciones), caso C3a: extrae cada cita ruta:línea (o rango, o lista con
comas, o continuación `:N` que hereda el archivo anterior) de salida/A-01.md y de
los artefactos de salida/, y comprueba que el archivo existe en repo/ y que la
línea existe, en el árbol de trabajo y en el commit HEAD del repo leído.

Uso: python3 -I citas.py <dir-de-la-corrida> [--tsv salida.tsv]
Todas las rutas que imprime son relativas al directorio de la corrida.

Resolución (vale la primera que exista):
  repo/X, salida/X, conocimiento.md -> tal cual, desde la corrida
  X con '/' o nombre suelto          -> repo/proyecto/X
  nombre suelto que no está en la raíz -> búsqueda por nombre en repo/ y salida/inventario
salida/respuestas.md cuenta como fuente sólo si la respuesta cita un archivo del
directorio: se informa aparte cuántas respuestas tienen una fuente distinta de «—».
"""
import os, re, sys, subprocess

FILE = r'(?P<f>(?:[\w.@{}+\-]+/)*[\w.@{}+\-]*[\w\-]\.[A-Za-z][A-Za-z0-9]{0,9})'
LINES = r':(?P<l>\d+(?:[-–]\d+)?(?:,\d+(?:[-–]\d+)?)*)'
CITA = re.compile(FILE + LINES + r'(?![\w/])')
CONT = re.compile(r'`:(?P<l>\d+(?:[-–]\d+)?)`')
SKIP_EXT = {'com', 'stream', 'net', 'org', 'io'}
REPO = 'repo/proyecto'

def nlines_bytes(data):
    n = data.count(b'\n')
    if data and not data.endswith(b'\n'):
        n += 1
    return n

def nlines(p):
    with open(p, 'rb') as fh:
        return nlines_bytes(fh.read())

def head_nlines(run, rel):
    if not rel.startswith(REPO + '/'):
        return None
    path = rel[len(REPO) + 1:]
    try:
        out = subprocess.run(['git', '-C', os.path.join(run, REPO), 'show', 'HEAD:' + path],
                             capture_output=True, check=True).stdout
    except subprocess.CalledProcessError:
        return -1
    return nlines_bytes(out)

def index_names(run):
    idx = {}
    for base in ('repo', os.path.join('salida', 'inventario')):
        for dp, dn, fn in os.walk(os.path.join(run, base)):
            if '.git' in dp.split(os.sep):
                continue
            for f in fn:
                idx.setdefault(f, []).append(os.path.relpath(os.path.join(dp, f), run))
    return idx

def resolve(run, f, idx):
    ex = lambda r: os.path.isfile(os.path.join(run, r))
    if f.startswith(('repo/', 'salida/')) or f == 'conocimiento.md':
        return [f] if ex(f) else []
    r = REPO + '/' + f
    if ex(r):
        return [r]
    if '/' not in f:
        return sorted(idx.get(f, []))
    return []

def parse_ranges(s):
    out = []
    for part in s.split(','):
        a, _, b = part.replace('–', '-').partition('-')
        out.append((int(a), int(b) if b else int(a)))
    return out

def scan(run):
    idx = index_names(run)
    srcs = []
    for dp, dn, fn in os.walk(os.path.join(run, 'salida')):
        for f in sorted(fn):
            srcs.append(os.path.relpath(os.path.join(dp, f), run))
    srcs.sort(key=lambda s: (s != 'salida/A-01.md', s))
    rows = []
    for src in srcs:
        try:
            text = open(os.path.join(run, src), encoding='utf-8').read()
        except UnicodeDecodeError:
            continue
        for ln, line in enumerate(text.splitlines(), 1):
            last = None
            toks = [(m.start(), 'C', m) for m in CITA.finditer(line)] + \
                   [(m.start(), 'K', m) for m in CONT.finditer(line)]
            for _, kind, m in sorted(toks, key=lambda t: t[0]):
                if kind == 'C':
                    f = m.group('f')
                    if f.rsplit('.', 1)[-1].lower() in SKIP_EXT:
                        continue
                    last = f
                else:
                    if last is None:
                        continue
                    f = last
                for a, b in parse_ranges(m.group('l')):
                    cands = resolve(run, f, idx)
                    ok = [c for c in cands if nlines(os.path.join(run, c)) >= b]
                    if not cands:
                        st = 'ARCHIVO_INEXISTENTE'
                    elif not ok:
                        st = 'LINEA_INEXISTENTE'
                    else:
                        st = 'OK'
                    res = (ok or cands or [''])[0]
                    hn = head_nlines(run, res) if res else None
                    head = '-' if hn is None else ('NO_EN_HEAD' if hn < 0 else ('OK' if hn >= b else 'LINEA_FUERA_DE_HEAD'))
                    if st == 'OK' and head not in ('OK', '-'):
                        st = head
                    rows.append(dict(origen=f'{src}:{ln}', cita=f'{f}:{a}' + (f'-{b}' if b != a else ''),
                                     resuelta=res, candidatos=len(cands), head=head, estado=st))
    return rows

def respuestas(run):
    p = os.path.join(run, 'salida', 'respuestas.md')
    if not os.path.isfile(p):
        return []
    out = []
    for line in open(p, encoding='utf-8'):
        m = re.match(r'\|\s*(Q-\d+)\s*\|(.*)\|(.*)\|\s*$', line)
        if m:
            out.append((m.group(1), m.group(2).strip(), m.group(3).strip()))
    return out

if __name__ == '__main__':
    run = sys.argv[1]
    rows = scan(run)
    if '--tsv' in sys.argv:
        out = sys.argv[sys.argv.index('--tsv') + 1]
        with open(out, 'w', encoding='utf-8') as fh:
            fh.write('origen\tcita\tresuelta\tcandidatos\thead\testado\n')
            for r in rows:
                fh.write(f"{r['origen']}\t{r['cita']}\t{r['resuelta']}\t{r['candidatos']}\t{r['head']}\t{r['estado']}\n")
    tot = len(rows); uniq = {(r['cita'], r['resuelta']) for r in rows}
    bad = [r for r in rows if r['estado'] != 'OK']
    a01 = [r for r in rows if r['origen'].startswith('salida/A-01.md:')]
    print(f'citas: {tot} (distintas: {len(uniq)}); en A-01: {len(a01)}; en artefactos: {tot - len(a01)}; fallan: {len(bad)}')
    for r in bad:
        print(f"  {r['estado']}\t{r['origen']}\t{r['cita']}\t{r['resuelta']}")
    amb = [r for r in rows if r['estado'] == 'OK' and r['candidatos'] > 1]
    for r in amb:
        print(f"  AMBIGUA({r['candidatos']})\t{r['origen']}\t{r['cita']}\t-> {r['resuelta']}")
    resp = respuestas(run)
    con_fuente = [q for q in resp if q[2] not in ('—', '-', '')]
    print(f'respuestas del coordinador: {len(resp)}; con fuente en el directorio: {len(con_fuente)}')
    for q in con_fuente:
        print(f'  {q[0]}\t{q[2]}')
