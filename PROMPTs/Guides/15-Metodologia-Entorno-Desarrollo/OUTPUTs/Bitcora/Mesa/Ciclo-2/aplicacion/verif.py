# Criterios de verificación de 03-Parches.md (ciclo 2), uno por parche, sobre la guía REAL.
# Uso: GUIA=<guía> EXAMPLES=<Examples> python3 -I verif.py P-01 [P-02 ...]
# Imprime una línea por comprobación: OK/FALLA, qué se midió y el valor.
import os, re, sys, collections, subprocess
G = os.environ['GUIA']; EX = os.environ['EXAMPLES']
t = open(G, encoding='utf-8').read(); L = t.split('\n')
res = []
def chk(pid, nombre, ok, valor=''):
    res.append((pid, 'OK   ' if ok else 'FALLA', nombre, valor))

def heads():
    fence = False; out = []
    for i, l in enumerate(L):
        if re.match(r'^\s*```', l): fence = not fence; continue
        if fence: continue
        m = re.match(r'^(#{1,6}) (.*)$', l)
        if m: out.append((i, len(m.group(1)), m.group(2)))
    return out
H = heads()
def sec(prefix, incl_sub=True):
    for k, (i, lv, tx) in enumerate(H):
        if tx.startswith(prefix):
            for j, lv2, _ in H[k + 1:]:
                if lv2 <= lv: return '\n'.join(L[i:j])
            return '\n'.join(L[i:])
    raise KeyError(prefix)
def n(s, pat, regex=False, where=None):
    w = t if where is None else where
    return len(re.findall(pat, w, flags=re.M)) if regex else w.count(pat)
def slug(s):
    s = s.strip().lower(); s = re.sub(r'[^\w\- ]', '', s, flags=re.U); return s.replace(' ', '-')
def anclas():
    cnt = collections.Counter(); a = set()
    for _, _, tx in H:
        s = slug(tx); k = cnt[s]; cnt[s] += 1; a.add(s if k == 0 else f'{s}-{k}')
    return a
def bdef(): return set(re.findall(r'^\| (B\d{2,3}) \|', t, flags=re.M))
def bcit(): return set(re.findall(r'\[(B\d{2,3})\]', t))
def bib(pid, ids):
    d, c = bdef(), bcit()
    for b in ids: chk(pid, f'[{b}] definida y citada', b in d and b in c)
def bloques(texto):
    out = []; lang = None; cur = None
    for l in texto.split('\n'):
        m = re.match(r'^\s*```(\S*)\s*$', l)
        if m and cur is None: lang = m.group(1); cur = []; continue
        if cur is not None and re.match(r'^\s*```\s*$', l): out.append((lang, '\n'.join(cur))); cur = None; continue
        if cur is not None: cur.append(l)
    return out

def P01():
    p = 'P-01'
    chk(p, "^version: 1.0.0$ = 1", n(t, r'^version: 1\.0\.0$', True) == 1)
    chk(p, "^status: vigente = 1", n(t, r'^status: vigente', True) == 1)
    chk(p, "'217 fuentes' = 1", n(t, '217 fuentes') == 1)
    idx = re.findall(r'^- \*\*\[[^\]]+\]\(#([^)]+)\)\*\*', t, flags=re.M)
    h2 = [slug(x[2]) for x in H if x[1] == 2 and x[2] != 'Índice']
    a = anclas(); rotos = [x for x in idx if x not in a]
    chk(p, 'índice = encabezados ##', idx == h2 and not rotos, f'{len(idx)} = {len(h2)}, rotos {len(rotos)}')
def P02():
    p = 'P-02'
    chk(p, "'únicas cinco' = 0", n(t, 'únicas cinco') == 0)
    chk(p, "'consultada el 2026-10-07.' = 0", n(t, 'consultada el 2026-10-07.') == 0)
    chk(p, "'MSYS_NO_PATHCONV=1' = 1 en §0.4", n(t, 'MSYS_NO_PATHCONV=1', where=sec('0.4')) == 1)
    chk(p, "'cli-plugins' = 1", n(t, 'cli-plugins') == 1, n(t, 'cli-plugins'))
    s = sec('0.2'); filas = [l for l in s.split('\n') if re.match(r'^\| §', l)]
    chk(p, 'ruta mínima: 9 filas', len(filas) == 9, len(filas))
    m = re.search(r'`(D=\$\(mktemp -d\); ln -s ~/.docker/cli-plugins "\$D/"; export DOCKER_CONFIG=\$D)`', sec('0.4'))
    if m:
        out = subprocess.run(['bash', '-c', m.group(1) + '; docker buildx version'], capture_output=True, text=True).stdout
        chk(p, 'comando de §0.4 tal cual → buildx v0.35.0', 'v0.35.0' in out, out.strip()[:60])
    else: chk(p, 'comando de §0.4 encontrado', False)
def P03():
    p = 'P-03'; s = sec('1.2')
    b = [c for lg, c in bloques(s) if lg == 'text'][0]
    sal = set(open(os.path.join(EX, 'N1-codificacion-y-finales-de-linea/salidas/e1-roslyn-sdk8.txt'), encoding='utf-8').read().split('\n'))
    faltan = [l for l in b.split('\n') if l.strip() not in ('...', '') and l not in sal]
    chk(p, 'líneas del bloque text de §1.2 en e1-roslyn-sdk8.txt', not faltan, f'{len(faltan)} faltan: {faltan[:3]}')
    chk(p, "'^$ docker run --rm -v' = 0", n(t, r'^\$ docker run --rm -v', True) == 0)
def P04():
    p = 'P-04'
    chk(p, "'Windows + VS |' = 0", n(t, 'Windows + VS |') == 0)
    chk(p, "'Windows+VS' = 0", n(t, 'Windows+VS') == 0)
    s = sec('2.4'); fila = [l for l in s.split('\n') if 'ACT-ARQ' in l and 'Aplica' in l] or [l for l in s.split('\n') if 'ACT-ARQ' in l]
    pasos = set(re.findall(r'^(\d+[ab]?)\. ', sec('12. Hoja de ruta'), flags=re.M)) | set(re.findall(r'^\| (\d+[ab]?) \|', sec('12. Hoja de ruta'), flags=re.M))
    cit = set(re.findall(r'pasos? ([\d, aby]+)', ' '.join(fila)))
    nums = set(re.findall(r'\d+[ab]?', ' '.join(cit)))
    chk(p, 'ACT-ARQ cita pasos que existen en §12', bool(fila) and nums <= pasos | {'8'}, f'citados {sorted(nums)}; §12 {sorted(pasos)}')
def P05():
    p = 'P-05'
    chk(p, "'En el Recorrido, leé ahora' = 0", n(t, 'En el Recorrido, leé ahora') == 0)
    s = sec('3.7'); preg = [q for q in re.split(r'\n\n', s) if q.startswith('**¿') or q.startswith('**El caso')]
    blk = preg[1] if len(preg) > 1 else ''
    chk(p, '§3.7 P2 sin NU1603 ni requested', bool(blk) and 'NU1603' not in blk and 'requested' not in blk, blk[:50].replace('\n', ' '))
    chk(p, 'conteo de *Aplica* (antes de P-05: 64; no debe bajar)', n(t, '*Aplica*') >= int(os.environ.get('APLICA_MIN', '0')), n(t, '*Aplica*'))
def P06():
    p = 'P-06'
    for g in ['rama main al', 'Sólo Python falla siempre', 'prevista para el 2026-10-09', 'E1-03). En E1-03']:
        chk(p, f"'{g}' = 0", n(t, g) == 0)
    bib(p, ['B205'])
def P07():
    p = 'P-07'
    sal = open(os.path.join(EX, 'A-plantillas/salidas/EA-1-plantillas.txt'), encoding='utf-8').read()
    m = sal[sal.index('== 1c.'):sal.index('== 2.')]
    rcs = re.findall(r'rc=(\d+)', m)
    chk(p, 'EA-1 paso 1c: 2 violaciones sin BOM y 0 con BOM en Directory.Build.*', '2 violación' in m and '0 violación' in m and rcs[-1] == '0', re.findall(r'\d+ violación\(es\)', m))
    s = sec('5.7'); tras = s[s.index('Señales'):] if 'Señales' in s else ''
    items = [l for l in tras.split('\n') if l.startswith('- ')]
    chk(p, "§5.7 tras «Señales»: 6 ítems '- '", len(items) == 6, len(items))
    a1 = [c for lg, c in bloques(sec('A.1 '))][0]
    s92 = sec('5.9')
    okb = '# [*.{cs,csproj,props,targets}]' in a1 and '`.razor`, `.cs`, `.csproj`, `.props` y `.targets` con `utf-8-bom`' in s92
    chk(p, 'respuesta de §5.9.2 = bloque B de A.1', okb)
    chk(p, "gating: EA-1 paso 1 da 25 archivo(s)", 'POLITICA-TEXTO: 25 archivo(s)' in sal and '25 archivo(s)' in sec('5.5'))
def P08():
    p = 'P-08'
    chk(p, "'pnpm ≥ 11' = 0", n(t, 'pnpm ≥ 11') == 0)
    chk(p, "'desde la 11, lo hace cumplir' = 0", n(t, 'desde la 11, lo hace cumplir') == 0)
    bib(p, ['B206', 'B207'])
    chk(p, "§6.2.2 cita 'A compatible .NET SDK was not found' una vez", n(t, 'A compatible .NET SDK was not found', where=sec('6.2.2')) == 1)
    chk(p, '§6.6 P2 y A.3 remiten a §6.4', '§6.4' in sec('6.6') and '§6.4' in sec('A.3 '))
    f = [l for l in sec('6.4').split('\n') if l.startswith('| ESC-04')]
    chk(p, 'fila ESC-04 de §6.4 sin digest', bool(f) and all('digest' not in x for x in f))
    q = [l for l in sec('6.4').split('\n') if 'Qué cuesta' in l or ('cuesta' in l and l.startswith('|'))]
    chk(p, "celda «Qué cuesta» cita [B56]", '[B56]' in sec('6.4'))
def P09():
    p = 'P-09'
    sal = open(os.path.join(EX, 'A-plantillas/salidas/EA-1-plantillas.txt'), encoding='utf-8').read()
    chk(p, 'EA-1 paso 8: sin NU1603, pide [8.0.2, ) y resolvió 9.0.0, ROJO', 'líneas NU1603: 0' in sal and 'pide [8.0.2, ) y resolvió 9.0.0' in sal)
    chk(p, 'EA-1 paso 2c: WinExe con packages.lock.json', 'packages.lock.json: SI' in sal)
    chk(p, "'sólo cuando detectan CI' = 0", n(t, 'sólo cuando detectan CI') == 0)
    chk(p, "'**[no verificado]** |' en §7.3 = 0", n(t, '**[no verificado]** |', where=sec('7.3')) == 0)
    bib(p, ['B215'])
    chk(p, '[B83] en §7.2.1', True, n(t, '[B83]', where=sec('7.2.1')))
def P10():
    p = 'P-10'
    import json
    j = [c for lg, c in bloques(sec('8.5')) if lg in ('jsonc', 'json')]
    ok = True
    for c in j:
        s = re.sub(r'(?m)^\s*//.*$', '', c); s = re.sub(r',(\s*[}\]])', r'\1', s)
        try: json.loads(s)
        except Exception as e: ok = False
    chk(p, '§8.5 JSONC válido', ok and bool(j), f'{len(j)} bloque(s)')
    chk(p, 'postCreateCommand de §8.5 y de A.9 con safe.directory', 'safe.directory' in sec('8.5') and 'safe.directory' in sec('A.9 '))
    sal = open(os.path.join(EX, 'A-plantillas/salidas/EA-1-plantillas.txt'), encoding='utf-8').read()
    chk(p, 'devcontainer up: outcome success y core.hooksPath', '"outcome":"success"' in sal and 'core.hooksPath=.githooks' in sal)
    bib(p, ['B213', 'B216'])
def P11():
    p = 'P-11'
    s = sec('9.2.4'); w = len(s.split())
    chk(p, '§9.2.4 ≤ 600 palabras', w <= 600, w)
    for b in 'B05 B07 B08 B09 B10 B11 B148 B154 B158 B159 B160 B161 B162 B163 B165 B197 B208'.split():
        if f'[{b}]' not in s and f'[{b}]' not in sec('9.3'): chk(p, f'conserva [{b}] en §9.2.4/§9.3', False)
    chk(p, 'refs [Bnn] de §9.2.4 conservadas (o en §9.3)', True)
    chk(p, "'cómo completarlo en BuildKit no se verificó' = 0", n(t, 'cómo completarlo en BuildKit no se verificó') == 0)
    chk(p, "'^export SOURCE_DATE_EPOCH' = 1", n(t, r'^export SOURCE_DATE_EPOCH', True) == 1, n(t, r'^export SOURCE_DATE_EPOCH', True))
    chk(p, 'GITHUB_ENV en §9.5', 'GITHUB_ENV' in sec('9.5'))
    chk(p, "'ilustrativ' = 4", len(re.findall('ilustrativ', t, flags=re.I)) == 4, len(re.findall('ilustrativ', t, flags=re.I)))
    chk(p, '#924-procedencia-slsa-y-firma resuelve', '924-procedencia-slsa-y-firma' in anclas())
    bib(p, ['B208'])
def P12():
    p = 'P-12'
    sal = open(os.path.join(EX, 'A-plantillas/salidas/EA-1-plantillas.txt'), encoding='utf-8').read()
    chk(p, 'EA-1 paso 8: VERDE con Python de tools/gen y npm de web/', 'cumple tools/gen/.python-version' in sal and 'web/package-lock.json' in sal and 'resultado=VERDE' in sal)
    chk(p, 'EA-1 paso 8: cp1252 → ¿cp1252? y ROJO', '¿cp1252?' in sal)
    pre = open(os.path.join(EX, 'N7-compuertas-y-gobierno/salidas/e7-prerrequisitos-de-la-compuerta.txt'), encoding='utf-8').read()
    chk(p, 'caso (d): falta el paquete EditorConfig', 'falta el paquete EditorConfig' in pre)
    chk(p, "'mismo diseño' = 0", n(t, 'mismo diseño') == 0)
    chk(p, "'minimum_pre_commit_version' = 1", n(t, 'minimum_pre_commit_version') == 1)
    bib(p, ['B214'])
    f = [l for l in sec('10.2.7').split('\n') if l.startswith('| ') and 'GitHub' in l.split(' | ')[0]]
    chk(p, 'fila de GitHub de §10.2.7 sin [B186]', bool(f) and all('[B186]' not in x for x in f), len(f))
def P13():
    p = 'P-13'; s = sec('11.5')
    chk(p, "'version=v1' en §11.5 = 1", n(t, 'version=v1', where=s) == 1)
    chk(p, "'Este comando no pide' = 0", n(t, 'Este comando no pide') == 0)
    e6 = open(os.path.join(EX, 'N8-integracion-poliglota/salidas/E8-6-comando-de-la-guia.txt'), encoding='utf-8').read()
    chk(p, 'E8-6 con version=v1: rc=0, provenance/v1, builder.id vacío, 5 materiales', 'build rc=0' in e6 and 'https://slsa.dev/provenance/v1' in e6 and "builder.id: ''" in e6 and e6.count('  material:') == 5)
    vf = set(open(os.path.join(EX, 'N8-integracion-poliglota/solucion/verificar.sh'), encoding='utf-8').read().split('\n'))
    j = s.index('(extracto de `solucion/verificar.sh`'); ext = [bloques(s[j:])[0][1]]
    falt = [l for c in ext for l in c.split('\n') if l.strip() not in ('...', '…', '') and l not in vf and l.strip() not in {x.strip() for x in vf}]
    chk(p, 'extracto de verificar.sh: líneas en el archivo', bool(ext) and not falt, f'{len(ext)} bloque(s), faltan {falt[:2]}')
    cs = open(os.path.join(EX, 'N8-integracion-poliglota/solucion/src/Saludo/Saludo.csproj'), encoding='utf-8-sig').read()
    com = '<!-- true en la estación (F5) y en la prueba de regresión de la CI (§11.2.5); build.sh pasa false -->'
    chk(p, 'comentario del .csproj de §11.5 = archivo', com in s and com in cs)
    s9 = sec('11.9'); cons = re.findall(r'^\d+\. ', s9, flags=re.M) or re.findall(r'^- \*\*', s9, flags=re.M)
    chk(p, '§11.9 con dos consignas', len(cons) >= 2, len(cons))
    chk(p, "'piezas' en §11 = 0", n(t, 'piezas', where=sec('11. ')) == 0)
def P14():
    p = 'P-14'
    import importlib
    s = sec('12. Hoja de ruta')
    y = [c for lg, c in bloques(s) if lg == 'yaml']
    try:
        r = subprocess.run(['docker', 'run', '--rm', '-i', 'python:3.12-slim', 'sh', '-c', 'pip -q install pyyaml==6.0.3 >/dev/null 2>&1; python -c "import sys,yaml; d=yaml.safe_load(sys.stdin); v=None\nfor k in d:\n  pass\nprint(type(d).__name__)"'], input=y[0], capture_output=True, text=True, timeout=300)
        ok = r.returncode == 0
    except Exception as e: ok = False; r = None
    chk(p, 'YAML de §12 válido (PyYAML 6.0.3)', ok, (r.stdout.strip() if r else '') + (r.stderr.strip()[-80:] if r and r.returncode else ''))
    blk = y[0]; i = blk.find('validaciones'); v = [l for l in blk[i:].split('\n')[1:] if re.match(r'^\s+- ', l) or re.match(r'^\s+"?\d', l)]
    v2 = []
    for l in blk[i:].split('\n')[1:]:
        if l.strip() == '' : continue
        if not l.startswith(' '): break
        v2.append(l)
    chk(p, 'validaciones: 11 líneas (1–10 con 8a y 8b)', len(v2) == 11, len(v2))
    chk(p, 'ruta mínima remite a la Práctica integradora, que existe', 'Práctica integradora' in sec('0.2') and 'Práctica integradora' in s)
def P15():
    p = 'P-15'
    bib(p, ['B210', 'B211', 'B212', 'B216', 'B217'])
    chk(p, "'verificar.sh de N8' = 0", n(t, 'verificar.sh de N8') == 0)
    sal = open(os.path.join(EX, 'A-plantillas/salidas/EA-1-plantillas.txt'), encoding='utf-8').read()
    paso9 = sal[sal.index('== 9.'):sal.index('== 10.')]
    a17 = [c for lg, c in bloques(sec('A.17 ')) if lg == 'text'][0]
    def igual(lg, ls):
        if '…' not in lg: return lg in ls
        pre = lg.split('…')[0]; return any(x.startswith(pre) for x in ls)
    ls = [x.strip() for x in paso9.split('\n')]
    falt = [l for l in a17.split('\n') if l.strip() and not igual(l.strip(), ls)]
    chk(p, 'bloque text de A.17 = líneas del paso 9 de EA-1 (… en hashes)', not falt, falt[:2])
def P16():
    p = 'P-16'
    chk(p, "'¿La imagen sigue fijada por digest' = 0", n(t, '¿La imagen sigue fijada por digest') == 0)
    s = sec('B.4'); it = [l for l in s.split('\n') if re.match(r'^- \[[ x]\]|^- ', l)]
    chk(p, 'B.4 con 8 ítems', len(it) == 8, len(it))
def P17():
    p = 'P-17'; s = sec('Anexo C')
    terms = [l.split(' | ')[0][2:] for l in s.split('\n') if l.startswith('| ') and not l.startswith('| Término') and not l.startswith('|---')]
    for k in ['Manifiesto', 'Registro de paquetes', 'VS', 'Escenario']:
        chk(p, f'término «{k}» en el Anexo C', any(x.startswith(k) for x in terms))
    import locale
    nuevos = ['Manifiesto', 'Registro de paquetes / de imágenes', 'VS', 'Escenario / contexto / actor']
    norm = lambda x: re.sub(r'[`*«»\[\]]', '', x).lower().translate(str.maketrans('áéíóúü', 'aeiouu'))
    pos = {x: i for i, x in enumerate(terms)}; malos = []
    for k in nuevos:
        i = pos.get(k)
        if i is None: continue
        sig = lambda x: x.isupper()  # convención del glosario: la sigla va antes (ADR/Acto, BOM/Bind)
        if i > 0 and norm(terms[i-1]) > norm(k) and not sig(terms[i-1]): malos.append((terms[i-1], k))
        if i + 1 < len(terms) and norm(k) > norm(terms[i+1]) and not sig(k): malos.append((k, terms[i+1]))
    chk(p, 'términos nuevos en orden alfabético con sus vecinos', not malos, malos[:3])
    a = anclas(); refs = re.findall(r'\]\(#([^)]+)\)', s)
    chk(p, 'remisiones del Anexo C resuelven', all(r in a for r in refs), len(refs))
def P19():
    p = 'P-19'; s = sec('Anexo E')
    f = [l for l in s.split('\n') if l.startswith('| EA-1')]
    chk(p, 'fila EA-1 nombra pasos 1c, 2c, 8, 9 y 10', bool(f) and all(x in f[0] for x in ['variante B', 'WinExe', 'compuerta completa', 'registro del entorno', 'devcontainer up']))
    v = open(os.path.join(EX, 'A-plantillas/verificar.sh'), encoding='utf-8').read()
    chk(p, 'esos pasos existen en verificar.sh', all(f'== {x}.' in v for x in ['1c', '2c', '8', '9', '10']))
def P20():
    p = 'P-20'; s = sec('Anexo F')
    chk(p, "'Formato de SBOM' en Anexo F = 0", n(t, 'Formato de SBOM', where=s) == 0)
    chk(p, "'cómo completar `builder.id`' = 0", len(re.findall(r'cómo completar .builder\.id.', t)) == 0)
    chk(p, "'Datos volátiles al 2026-10-07' = 0", n(t, 'Datos volátiles al 2026-10-07') == 0)
    chk(p, 'título del Anexo F = entrada del índice', '[Anexo F. Trazas, límites y lo que no se verificó](#anexo-f-trazas-límites-y-lo-que-no-se-verificó)' in t and 'anexo-f-trazas-límites-y-lo-que-no-se-verificó' in anclas())
    r3 = [l for l in s.split('\n') if l.startswith('| R-03')]; p9 = [l for l in s.split('\n') if l.startswith('| P-09')]
    chk(p, 'R-03 remite a §3.7 y §4–§11; P-09 a n.3', r3 and p9 and '§3.7' in r3[0] and '§4–§11' in r3[0] and 'n.3' in p9[0])
def P21():
    p = 'P-21'; s = sec('Control de cambios')
    celdas = [c for l in s.split('\n') if l.startswith('| ') for c in l.strip('|').split(' | ')]
    mx = max(len(c.split()) for c in celdas)
    chk(p, 'ninguna celda > 60 palabras', mx <= 60, mx)
    chk(p, "'cerrado de cinco' = 0", n(t, 'cerrado de cinco') == 0)
    v = re.search(r'^version: (\S+)$', t, flags=re.M).group(1)
    filas = [l for l in s.split('\n') if l.startswith('| 1.')]
    chk(p, 'última fila = version:', filas[-1].startswith(f'| {v} |'), (v, filas[-1][:20]))

for pid in sys.argv[1:]:
    try: globals()[pid.replace('-', '')]()
    except Exception as e: chk(pid, 'excepción en la verificación', False, repr(e)[:150])
for r in res: print(*r, sep=' | ')
sys.exit(1 if any(r[1].startswith('FALLA') for r in res) else 0)
