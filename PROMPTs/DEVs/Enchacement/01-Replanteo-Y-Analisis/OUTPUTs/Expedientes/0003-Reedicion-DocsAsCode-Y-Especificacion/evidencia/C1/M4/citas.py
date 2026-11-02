#!/usr/bin/env python3
"""M4 (invenciones): extrae cada cita ruta:línea (o rango, o lista con comas, o
continuación `:N` que hereda el archivo anterior) de salida/A-01.md y de los
artefactos de salida/, y comprueba que el archivo existe y que la línea existe.

Uso: python3 -I citas.py <dir-de-la-corrida> [--tsv salida.tsv]
Todas las rutas que imprime son relativas al directorio de la corrida.

Una cita en una línea que menciona lo «plantado», o en la salida del par rojo, apunta a la copia del par
rojo/verde (ya borrada), no a repo/: se informa como COPIA_PLANTADA y no cuenta.

Resolución de una ruta citada (en este orden; vale la primera que exista):
  repo/X, salida/X            -> tal cual, desde la corrida
  conocimiento.md             -> la corrida
  LG/X, LGD/X                 -> repo/LG/X, repo/LGD/X
  Lab-Geometria.Documentacion/X -> repo/LGD/X ; Lab-Geometria/X -> repo/LG/X
  X relativa                  -> repo/LG/X, repo/LGD/X (si existe en ambos, ambigua)
  nombre suelto (sin '/')     -> (en artefactos bajo salida/LGD se prefiere repo/LGD)
                                 búsqueda por nombre en repo/ y en salida/inventario;
                                 vale si ALGÚN candidato tiene la línea (se informa
                                 la cantidad de candidatos)
"""
import os, re, sys, json

FILE = r'(?P<f>(?:[\w.@{}+\-]+/)*[\w.@{}+\-]*[\w\-]\.[A-Za-z][A-Za-z0-9]{0,9})'
LINES = r':(?P<l>\d+(?:[-–]\d+)?(?:,\d+(?:[-–]\d+)?)*)'
CITA = re.compile(FILE + LINES + r'(?![\w/])')
CONT = re.compile(r'`:(?P<l>\d+(?:[-–]\d+)?)`')
SKIP_EXT = {'com', 'stream', 'net', 'org', 'io'}  # host:puerto

def nlines(p):
    with open(p, 'rb') as fh:
        data = fh.read()
    n = data.count(b'\n')
    if data and not data.endswith(b'\n'):
        n += 1
    return n

def index_names(run):
    idx = {}
    for base in ('repo', os.path.join('salida', 'inventario')):
        for dp, dn, fn in os.walk(os.path.join(run, base)):
            for f in fn:
                idx.setdefault(f, []).append(os.path.relpath(os.path.join(dp, f), run))
    return idx

def resolve(run, f, idx, src):
    ex = lambda r: os.path.isfile(os.path.join(run, r))
    if f.startswith(('repo/', 'salida/')) or f == 'conocimiento.md':
        return [f] if ex(f) else []
    for pre, root in (('LGD/', 'repo/LGD/'), ('LG/', 'repo/LG/'),
                      ('Lab-Geometria.Documentacion/', 'repo/LGD/'),
                      ('Lab-Geometria/', 'repo/LG/')):
        if f.startswith(pre):
            r = root + f[len(pre):]
            return [r] if ex(r) else []
    if '/' in f:
        c = [r for r in ('repo/LG/' + f, 'repo/LGD/' + f) if ex(r)]
        # archivo de salida bajo salida/LGD -> preferir LGD
        if len(c) == 2 and '/LGD/' in src:
            c = ['repo/LGD/' + f]
        return c
    c = sorted(idx.get(f, []))
    pref = [x for x in c if x.startswith('repo/LGD/')] if '/LGD/' in src else []
    return pref or c

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
                    cands = resolve(run, f, idx, src)
                    ok = [c for c in cands if nlines(os.path.join(run, c)) >= b]
                    if 'plantad' in line.lower() or 'rojo' in os.path.basename(src):
                        st = 'COPIA_PLANTADA'
                    elif not cands:
                        st = 'ARCHIVO_INEXISTENTE'
                    elif not ok:
                        st = 'LINEA_INEXISTENTE'
                    else:
                        st = 'OK'
                    rows.append(dict(origen=f'{src}:{ln}', cita=f'{f}:{a}' + (f'-{b}' if b != a else ''),
                                     resuelta=(ok or cands or [''])[0], candidatos=len(cands),
                                     estado=st, a=a, b=b))
    return rows

if __name__ == '__main__':
    run = sys.argv[1]
    rows = scan(run)
    if '--tsv' in sys.argv:
        out = sys.argv[sys.argv.index('--tsv') + 1]
        with open(out, 'w', encoding='utf-8') as fh:
            fh.write('origen\tcita\tresuelta\tcandidatos\testado\n')
            for r in rows:
                fh.write(f"{r['origen']}\t{r['cita']}\t{r['resuelta']}\t{r['candidatos']}\t{r['estado']}\n")
    tot = len(rows); uniq = {(r['cita'], r['resuelta']) for r in rows}
    bad = [r for r in rows if r['estado'] not in ('OK', 'COPIA_PLANTADA')]
    for r in rows:
        if r['estado'] == 'COPIA_PLANTADA':
            print(f"  COPIA_PLANTADA (cita a la copia del par rojo, no a repo/)\t{r['origen']}\t{r['cita']}")
    amb = [r for r in rows if r['estado'] == 'OK' and r['candidatos'] > 1]
    print(f'citas: {tot} (distintas: {len(uniq)}); fallan: {len(bad)}; ambiguas resueltas: {len(amb)}')
    for r in bad:
        print(f"  {r['estado']}\t{r['origen']}\t{r['cita']}\t{r['resuelta']}")
    for r in amb:
        print(f"  AMBIGUA({r['candidatos']})\t{r['origen']}\t{r['cita']}\t-> {r['resuelta']}")
