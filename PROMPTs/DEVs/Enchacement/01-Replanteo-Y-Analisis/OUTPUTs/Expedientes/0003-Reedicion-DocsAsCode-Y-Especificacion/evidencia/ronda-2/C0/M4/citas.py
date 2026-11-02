#!/usr/bin/env python3
"""M4 (invenciones), caso C0: extrae cada cita ruta:línea (o rango, o lista con
comas, o continuación `:N` que hereda el archivo anterior) de salida/A-01.md y de
los artefactos de salida/, y comprueba que el archivo existe en repo/LD y que la
línea existe. El repo leído no trae .git: no hay comprobación contra un commit.

Uso: python3 -I citas.py <dir-de-la-corrida> [--tsv salida.tsv]
Todas las rutas que imprime son relativas al directorio de la corrida.

Clases de origen:
  aplicador  -> texto escrito por el aplicador: los .md de salida/ que no son copia
                del repo. En las copias montadas del repo (carpetas montaje/ y
                origen/) sólo cuentan las líneas que no están en el archivo del
                repo con la misma ruta (lo que el aplicador agregó o cambió).
  cruda      -> salidas de comandos (.txt, .tsv) y de scripts: se informan aparte.
                Una línea con forma de grep `ruta:n:texto` se contrasta con la línea
                n del repo (procedencia); el resto de sus citas se comprueba igual.
  copia      -> líneas idénticas al repo dentro de las copias montadas: no cuentan.

Resolución (vale la primera que exista):
  repo/X, salida/X, conocimiento.md -> tal cual, desde la corrida
  X con '/' o nombre suelto          -> repo/LD/X
  nombre suelto que no está en la raíz -> búsqueda por nombre en repo/
salida/respuestas.md cuenta como fuente sólo si la respuesta cita un archivo del
directorio: se informa cuántas respuestas tienen una fuente distinta de «—».
"""
import os, re, sys

FILE = r'(?P<f>(?:[\w.@{}+\-]+/)*[\w.@{}+\-]*[\w\-]\.[A-Za-z][A-Za-z0-9]{0,9})'
LINES = r':(?P<l>\d+(?:[-–]\d+)?(?:,\d+(?:[-–]\d+)?)*)'
CITA = re.compile(FILE + LINES + r'(?![\w/])')
CONT = re.compile(r'`:(?P<l>\d+(?:[-–]\d+)?)`|(?<=[,;] ):(?P<l2>\d+(?:[-–]\d+)?)(?![\w/])')
GREP = re.compile(r'^(?P<f>[^\s:]+\.[A-Za-z0-9]+):(?P<n>\d+):(?P<t>.*)$')
SKIP_EXT = {'com', 'stream', 'net', 'org', 'io'}
REPO = 'repo/LD'
COPY_DIRS = ('montaje', 'origen')
TEXT_EXT = {'md', 'txt', 'tsv'}

def read_lines(p):
    try:
        with open(p, 'rb') as fh:
            data = fh.read()
    except (PermissionError, IsADirectoryError, FileNotFoundError):
        return None
    return data.decode('utf-8', 'replace').splitlines()

def nlines(p):
    l = read_lines(p)
    return -1 if l is None else len(l)

def index_names(run):
    idx = {}
    for dp, dn, fn in os.walk(os.path.join(run, 'repo')):
        for f in fn:
            idx.setdefault(f, []).append(os.path.relpath(os.path.join(dp, f), run))
    return idx

def resolve(run, f, idx):
    ex = lambda r: os.path.isfile(os.path.join(run, r))
    if f.startswith(('repo/', 'salida/')) or f == 'conocimiento.md':
        return [f] if ex(f) else []
    r = REPO + '/' + (f[2:] if f.startswith('./') else f)
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

def copy_counterpart(src):
    """salida/.../montaje/<rel> -> repo/LD/<rel>, si src está en una copia."""
    parts = src.split('/')
    for i, p in enumerate(parts):
        if p in COPY_DIRS and i + 1 < len(parts):
            return REPO + '/' + '/'.join(parts[i + 1:])
    return None

def classify(src):
    ext = src.rsplit('.', 1)[-1].lower() if '.' in src.rsplit('/', 1)[-1] else ''
    if ext not in TEXT_EXT:
        return None
    if copy_counterpart(src):
        return 'aplicador' if ext == 'md' else 'cruda'
    return 'aplicador' if ext == 'md' else 'cruda'

def scan(run):
    idx = index_names(run)
    srcs = []
    for dp, dn, fn in os.walk(os.path.join(run, 'salida')):
        for f in sorted(fn):
            srcs.append(os.path.relpath(os.path.join(dp, f), run))
    srcs.sort(key=lambda s: (s != 'salida/A-01.md', s))
    rows, prov = [], {'coinciden': 0, 'no': []}
    copias = {'archivos': 0, 'lineas_propias': 0}
    for src in srcs:
        cls = classify(src)
        if cls is None:
            continue
        lines = read_lines(os.path.join(run, src))
        if lines is None:
            continue
        cp = copy_counterpart(src)
        repo_set = None
        if cp:
            rl = read_lines(os.path.join(run, cp))
            repo_set = set(rl) if rl is not None else set()
            copias['archivos'] += 1
        for ln, line in enumerate(lines, 1):
            if repo_set is not None and line in repo_set:
                continue
            if repo_set is not None:
                copias['lineas_propias'] += 1
            if cls == 'cruda':
                g = GREP.match(line)
                if g:
                    rr = resolve(run, g.group('f'), idx)
                    n = int(g.group('n'))
                    rl = read_lines(os.path.join(run, rr[0])) if rr else None
                    # Salidas de docs-guard (`ruta:n: ERROR ...`) no copian el texto: sólo se
                    # contrasta la existencia de la línea; un grep -n sí copia el texto.
                    t = g.group('t')
                    if rl is not None and 1 <= n <= len(rl) and (t.startswith(' ') or rl[n - 1] == t):
                        prov['coinciden'] += 1
                    else:
                        prov['no'].append(f'{src}:{ln}\t{g.group("f")}:{n}')
                    continue
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
                for a, b in parse_ranges(m.group('l') or m.group('l2')):
                    cands = resolve(run, f, idx)
                    ok = [c for c in cands if nlines(os.path.join(run, c)) >= b]
                    if not cands:
                        st = 'ARCHIVO_INEXISTENTE'
                    elif not ok:
                        st = 'LINEA_INEXISTENTE'
                    else:
                        st = 'OK'
                    res = (ok or cands or [''])[0]
                    rows.append(dict(clase=cls, origen=f'{src}:{ln}', cita=f'{f}:{a}' + (f'-{b}' if b != a else ''),
                                     resuelta=res, candidatos=len(cands), estado=st))
    return rows, prov, copias

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
    rows, prov, copias = scan(run)
    if '--tsv' in sys.argv:
        out = sys.argv[sys.argv.index('--tsv') + 1]
        with open(out, 'w', encoding='utf-8') as fh:
            fh.write('clase\torigen\tcita\tresuelta\tcandidatos\testado\n')
            for r in rows:
                fh.write(f"{r['clase']}\t{r['origen']}\t{r['cita']}\t{r['resuelta']}\t{r['candidatos']}\t{r['estado']}\n")
    for cls in ('aplicador', 'cruda'):
        rs = [r for r in rows if r['clase'] == cls]
        uniq = {(r['cita'], r['resuelta']) for r in rs}
        bad = [r for r in rs if r['estado'] != 'OK']
        a01 = [r for r in rs if r['origen'].startswith('salida/A-01.md:')]
        print(f'[{cls}] citas: {len(rs)} (distintas: {len(uniq)}); en A-01: {len(a01)}; '
              f'en otros artefactos: {len(rs) - len(a01)}; fallan: {len(bad)}')
        for r in bad:
            print(f"  {r['estado']}\t{r['origen']}\t{r['cita']}\t{r['resuelta']}")
        for r in rs:
            if r['estado'] == 'OK' and r['candidatos'] > 1:
                print(f"  AMBIGUA({r['candidatos']})\t{r['origen']}\t{r['cita']}\t-> {r['resuelta']}")
    print(f"copias montadas del repo: {copias['archivos']} archivos; líneas propias del aplicador en ellas: {copias['lineas_propias']}")
    print(f"procedencia de líneas `ruta:n:` en salidas crudas: {prov['coinciden']} coinciden con repo/, {len(prov['no'])} no")
    for x in prov['no'][:200]:
        print(f'  PROCEDENCIA_NO\t{x}')
    resp = respuestas(run)
    con_fuente = [q for q in resp if q[2] not in ('—', '-', '')]
    print(f'respuestas del coordinador: {len(resp)}; con fuente en el directorio: {len(con_fuente)}')
    for q in con_fuente:
        print(f'  {q[0]}\t{q[2]}')
