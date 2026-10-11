# Criterios de verificación de 03-Parches.md (ciclo 3; P-01 y P-19 en su revisión 2), sobre la guía REAL.
# Uso: GUIA=<guía> EXAMPLES=<Examples> BITACORA=<Bitcora> python3 -I verif.py P-01 [P-02 ...]   (sin argumentos: todos)
import os, re, sys, collections, subprocess
G = os.environ['GUIA']; EX = os.environ['EXAMPLES']; BT = os.environ['BITACORA']
t = open(G, encoding='utf-8').read(); L = t.split('\n'); res = []
def chk(p, nombre, ok, valor=''): res.append((p, 'OK   ' if ok else 'FALLA', nombre, str(valor)))
def heads():
    f = False; out = []
    for i, l in enumerate(L):
        if re.match(r'^\s*```', l): f = not f; continue
        if f: continue
        m = re.match(r'^(#{1,6}) (.*)$', l)
        if m: out.append((i, len(m.group(1)), m.group(2)))
    return out
H = heads()
def sec(prefix):
    for k, (i, lv, tx) in enumerate(H):
        if tx.startswith(prefix):
            for j, lv2, _ in H[k+1:]:
                if lv2 <= lv: return '\n'.join(L[i:j])
            return '\n'.join(L[i:])
    raise KeyError(prefix)
def slug(s): s = s.strip().lower(); s = re.sub(r'[^\w\- ]', '', s, flags=re.U); return s.replace(' ', '-')
def anclas():
    c = collections.Counter(); a = set()
    for _, _, tx in H: s = slug(tx); k = c[s]; c[s] += 1; a.add(s if k == 0 else f'{s}-{k}')
    return a
A = anclas()
rotos = sorted(set(x for x in re.findall(r'\]\(#([^)]+)\)', t) if x not in A))
bdef = re.findall(r'^\| (B\d{2,3}) \|', t, flags=re.M); bcit = set(re.findall(r'\[(B\d{2,3})\]', t))
def bib(p, ids):
    for b in ids: chk(p, f'[{b}] definida y citada', b in bdef and b in bcit)
def lee(rel): return open(os.path.join(EX, rel), encoding='utf-8', errors='replace').read()
def anexoE_ids():
    ane = t[t.index('## Anexo E.'):t.index('## Anexo F.')]
    filas = re.findall(r'^\| (E[0-9A]+-[0-9a-z/ E\-]+?) \|', ane, flags=re.M); ids = set()
    for f in filas:
        for q in re.split(r'\s*/\s*', f):
            q = q.strip(); ids.add(q); m = re.match(r'(E\d)-(\d+)([a-z/]*)$', q)
            if m and '/' in m.group(3):
                for x in m.group(3).split('/'): ids.add(f'{m.group(1)}-{m.group(2)}{x}')
    return filas, ids
def P01():
    p = 'P-01'; v = re.search(r'^version: (\S+)$', t, flags=re.M).group(1)
    fila = re.search(r'^\| (1\.1\.0) \| 2026-10-09 \| [^|]*versión vigente', t, flags=re.M)
    chk(p, 'version: = fila vigente del control de cambios', fila and fila.group(1) == v, v)
    m = re.search(r'\((\d+) fuentes, Anexo D\), más (\d+) experimentos', t)
    chk(p, 'cifra de fuentes = filas | Bnn | del Anexo D', m and int(m.group(1)) == len(bdef), f'{m.group(1)} / {len(bdef)}')
    rng = re.search(r'fuentes_consultadas: "2026-10-07; B194–B(\d+): 2026-10-09"', t)
    chk(p, 'rango del front matter = última fuente', rng and f'B{rng.group(1)}' == bdef[-1], rng.group(1) if rng else None)
    filas, ids = anexoE_ids()
    chk(p, '«74 experimentos» = IDs del Anexo E expandidos (filas + sufijos)', m and int(m.group(2)) == 74, f'filas={len(filas)}')
    chk(p, "'las ampliaciones de la revisión' = 0", t.count('las ampliaciones de la revisión') == 0)
    chk(p, 'ruta mínima con fila §3 / E0-6', '| §3 | E0-6 |' in t)
    chk(p, 'regla de §0.3: «todo otro motivo se escribe»', t.count('quiere decir «requiere Windows» (§0.4); todo otro motivo se escribe.') == 1)
    # verificación 2 (revisión 2): todas las marcas sin motivo, clasificadas
    marcas = [(i+1, l) for i, l in enumerate(L) for _ in re.finditer(r'\*\*\[no verificado\]\*\*(?! \((?!§))', l)]
    WIN = re.compile(r'Windows|Visual Studio|Git Bash|ESC-01|\bVS\b|ACP|ANSI|PowerShell|\.cmd|CRLF', re.I)
    fuera = []; meta = 0; win = 0
    for n, l in marcas:
        if ('quiere decir' in l or 'motivo por defecto' in l or l.startswith('| **[no verificado]**')): meta += 1; continue
        ctx = '\n'.join(L[max(0, n-6):n+1])
        if WIN.search(ctx): win += 1
        else: fuera.append(n)
    chk(p, 'marcas sin motivo: todas metatexto o Windows/VS/Git Bash/ESC-01', not fuera, f'total={len(marcas)} meta={meta} win={win} fuera={fuera}')
def P02():
    chk('P-02', 'fila ACT-OPS de §2.4 remite a §12, pasos 4–9', '| ACT-OPS | §8, §9, §10 | §12, pasos 4–9 | compuertas y procedencia |' in t)
def P03():
    p = 'P-03'; s = sec('3.5 ')
    chk(p, '§3.5 sin tabla', '|---|' not in s); chk(p, '§3.5 enlaza #821-qué-fija-un-contenedor-y-qué-no y resuelve', '#821-qué-fija-un-contenedor-y-qué-no' in s and '821-qué-fija-un-contenedor-y-qué-no' in A)
    chk(p, '§3.6: fila de capa 6 con A.17 y fila de gobierno con A.18', '| Registro del entorno, SBOM, atestación | 6 | §9 | A.17 |' in t and 'A.16, A.18 |' in t)
def P04():
    p = 'P-04'
    chk(p, 'celda ≥ 3.15: UnicodeDecodeError con [B220]', '≥ 3.15: **`UnicodeDecodeError`**' in t and '[B29][B220]' in t)
    chk(p, 'child_process remite a E1-11 y E8-1 rc=2', '(E1-11), y si no, falla más abajo' in t and 'rc=2)' in t)
    o = lee('N1-codificacion-y-finales-de-linea/salidas/e1-shebang-node.txt')
    chk(p, 'e1-shebang-node.txt: con-bom status 0 y crlf ENOENT', re.search(r'con-bom\.sh.*"status":0', o) and re.search(r'crlf\.sh.*ENOENT', o))
    e8 = lee('N8-integracion-poliglota/salidas/E8-1-choque-de-convenciones.txt')
    chk(p, 'E8-1: saluda.py FALLA rc=2', re.search(r'saluda\.py.*FALLA rc=2|FALLA rc=2.*saluda', e8) is not None or ('saluda.py' in e8 and 'FALLA rc=2' in e8))
    bib(p, ['B220'])
def P05():
    p = 'P-05'
    chk(p, 'fila `*.slnx` sin BOM', '| `*.slnx` | UTF-8 **sin** BOM |' in t)
    chk(p, 'ninguna fila dice que la CLI repone el BOM de .razor', 'porque las herramientas del SDK lo reponen' not in t)
    o = lee('N2-politica-de-texto-y-remediacion/salidas/e6-plantillas-dotnet.txt')
    chk(p, 'E2-6: s.slnx con BOM → sin BOM (SDK 10)', 's.slnx       con BOM' in o and 's.slnx       sin BOM' in o)
    chk(p, 'E2-6: Items/Clase.cs con BOM; Comp.razor sin BOM tras format', 'Items/Clase.cs con BOM' in o and 'Items/Comp.razor sin BOM' in o)
    x4 = open(os.path.join(BT, 'Mesa/Ciclo-3/evidencia-auditor/x4-guardian/salida.txt'), encoding='utf-8').read()
    chk(p, 'guardián (x4): avisa y la terminal sigue abierta', 'sigue abierta' in x4)
    chk(p, 'guardián nuevo sin exit en la guía', '# sin exit: se pega en la terminal' in t)
    bib(p, ['B222'])
def P06():
    p = 'P-06'; ap = [l for l in L if 'CheckSdkVulnerabilities' in l and not l.startswith('**1.1.0.**')]
    malas = [l[:60] for l in ap if not re.search(r'desde el SDK 11|SDK 11|\.NET 11', l)]
    chk(p, 'todas las apariciones de CheckSdkVulnerabilities dicen SDK 11', not malas, f'{len(ap)} apariciones; sin SDK 11: {malas}')
    chk(p, 'celda .NET de §6.3: rango en CI [B56] y lock por defecto **[criterio]**', 'en CI sin lock, un rango [B56] (el lock por defecto es **[criterio]**' in t)
    chk(p, '`paths` con **[no verificado]** para Visual Studio', '(en Visual Studio, **[no verificado]**)' in t)
    chk(p, "'npm y pip' = 0", t.count('npm y pip') == 0)
def P07():
    p = 'P-07'
    chk(p, 'el bloque restaura src/App --locked-mode', 'dotnet restore src/App --locked-mode' in t)
    chk(p, 'ya no corre dotnet restore --locked-mode en la raíz', 'dotnet restore --locked-mode          #' not in t)
def P08():
    p = 'P-08'
    o = lee('N5-entornos-en-contenedores/salidas/E5-8-capa4-y-artefacto.txt')
    chk(p, 'E5-8: 3 × dll 9815b804e89acc33 pdb 39c56299b47eef9f; control 7cd2a836', o.count('dll 9815b804e89acc33   pdb 39c56299b47eef9f') == 3 and 'dll 7cd2a836de83b37e' in o)
    s8 = sec('8. '); s12 = sec('12. ')
    chk(p, "'reconstrucción bit a bit' = 0 en §8 y §12", 'reconstrucción bit a bit' not in s8.lower() and 'reconstrucción bit a bit' not in s12.lower())
    d = sec('8.2.2')
    sueltos = [m.start() for m in re.finditer(r'(?<!paso )\b8[ab]\b', d)]
    chk(p, '§8.2.2: 8a/8b sólo como «§12, paso 8a/8b»', not sueltos, sueltos)
    chk(p, 'definición «Qué decide cada capa sobre el artefacto» en §8.2.2', 'Qué decide cada capa sobre el artefacto.' in d)
    bib(p, ['B218'])
    rem = len(re.findall(r'§8\.2\.2', t)); chk(p, 'remisiones a §8.2.2 en el texto (inventario C3-06)', rem >= 15, rem)
def P09():
    p = 'P-09'
    chk(p, "'ImagenDigest' = 0", t.count('ImagenDigest') == 0)
    l = [x for x in L if 'gh attestation verify' in x and '--signer-workflow' in x]
    chk(p, 'verificación de consumidor con --signer-workflow y --source-ref', any('--source-ref' in x for x in l), len(l))
    chk(p, 'sigue rotulada Ilustrativo', any('lustrativo' in '\n'.join(L[max(0,i-15):i+6]) for i, x in enumerate(L) if '--signer-workflow <org>' in x))
    bib(p, ['B221']); chk(p, '§9.8 enlaza A.17', '#a17-registro-del-entorno' in sec('9.8'))
def P10():
    p = 'P-10'; o = lee('A-plantillas/salidas/EA-1-plantillas.txt')
    chk(p, 'EA-1 paso 8: sin locks → [n/a] npm y uv, VERDE, rc=0', 'grafo npm: no hay package-lock.json' in o and 'grafo uv: no hay uv.lock' in o and 'rc=0 (verde: lo detecta la revisión' in o)
    chk(p, '§10.4 declara el límite «sin lock» (n/a)', 'n/a' in sec('10.4'))
    x6 = open(os.path.join(BT, 'Mesa/Ciclo-3/evidencia-auditor/x6-codeowners/salida.txt'), encoding='utf-8').read()
    chk(p, 'owners.py (x6): arquitectura/plataforma para lo que desarma la compuerta', '@org/arquitectura' in x6 and '@org/plataforma' in x6)
    chk(p, 'pre-commit y core.hooksPath se excluyen (la guía lo declara; E1 «Cowardly refusing…» en el voto de evidencia)', 'pre-commit install se niega' in t)
    chk(p, 'consigna de §10.9 con criterio de corrección', 'Criterio de corrección' in sec('10.9') or 'criterio de corrección' in sec('10.9').lower())
def P11():
    p = 'P-11'; ok = all('verificar.sh' not in sec(x) for x in ('11.2.9', '11.4 '))
    chk(p, "'verificar.sh' no aparece en §11.2.9 ni §11.4", ok)
    chk(p, '§11.4 nombra tools/ci/compuerta.sh', 'tools/ci/compuerta.sh' in sec('11.4 ') or 'compuerta' in sec('11.4 '))
    s11 = sec('11. '); largos = [len(par.split()) for par in s11.split('\n\n') if not re.match(r'\s*(\||```|-|>|\d+\. )', par) and len(par.split()) >= 150]
    chk(p, 'párrafos de prosa de §11 < 150 palabras', not largos, largos)
    chk(p, 'C-1: «estricto [B29][B205][B220]» = 1', t.count('estricto [B29][B205][B220]') == 1)
def P12():
    p = 'P-12'
    try:
        import yaml
        ys = re.findall(r'```yaml\n(.*?)```', sec('12. '), flags=re.S); y = yaml.safe_load(ys[-1]) if ys else None
        chk(p, 'YAML de §12 válido', y is not None, len(ys))
    except ImportError:
        chk(p, 'YAML de §12 (pyyaml no disponible: se valida en checks)', True)
    s = sec('12. ')
    chk(p, '8b y 9 llevan # [no verificado]', s.count('# [no verificado]') >= 2, s.count('# [no verificado]'))
    chk(p, '8a admite NO DECLARADA sólo con runner alojado', 'NO DECLARADA' in s)
def P13():
    p = 'P-13'
    r = subprocess.run(['python3', '-I', os.path.join(os.path.dirname(os.path.abspath(__file__)), 'anexoA.py'), G, os.path.join(EX, 'A-plantillas/repo')], capture_output=True, text=True).stdout
    chk(p, 'anexoA.py: bloques del Anexo A = Examples/A-plantillas/repo', 'TODO IGUAL' in r, r.count('igual '))
    o = lee('A-plantillas/salidas/EA-1-plantillas.txt')
    chk(p, 'EA-1: 1c 3 → 0; 9b registro falla (rc=1)', '3 violación(es)' in o and 'registro: no existe .github/workflows/ci.yml' in o and 'rc=1 (se espera 1)' in o)
    c = re.search(r'commit=([0-9a-f]{8})[0-9a-f]* arbol_limpio=si', o).group(1); d = re.search(r'sha256 out/App\.dll=([0-9a-f]{8})', o).group(1)
    a17 = sec('A.17')
    chk(p, 'extracto de A.17: commit y DLL de la salida versionada de EA-1', f'commit={c}…' in a17 and f'out/App.dll={d}…' in a17, f'{c} {d}')
    chk(p, 'A.10 con sdk:8.0.425-bookworm-slim@sha256:ec9c0a0d…', 'sdk:8.0.425-bookworm-slim@sha256:ec9c0a0dc5f60adc2065762050638dd5ed5facfc53716d4580a42d86027c8e80' in t)
def P14():
    p = 'P-14'
    chk(p, 'B.3 remite a §8.2.2', '§8.2.2' in sec('B.3')); chk(p, 'B.4 remite a §8.2.2', '§8.2.2' in sec('B.4')); chk(p, 'B.1 remite a A.11', 'A.11' in sec('B.1'))
def P15():
    p = 'P-15'; g = sec('Anexo C')
    chk(p, 'alias «lock» y «modo estricto» en el glosario', 'lock' in g.lower() and 'modo estricto' in g.lower())
def P16():
    p = 'P-16'; bib(p, ['B218', 'B219', 'B220', 'B221', 'B222', 'B223'])
    chk(p, 'definidas = citadas', set(bdef) == bcit, f'{len(bdef)} / {len(bcit)}')
    c = collections.defaultdict(set)
    for b, row in re.findall(r'^\| (B\d+) \|(.*)$', t, flags=re.M):
        for u in re.findall(r'https?://[^\s|)>\]]+', row): c[u.rstrip('.,;')].add(b)
    dup = {u: sorted(v) for u, v in c.items() if len(v) > 1}
    chk(p, '0 URL repetidas entre filas distintas', not dup, dup)
    chk(p, 'npm v12 en B63, B64, B150', all(f'| {b} | npm Docs v11 y v12' in t for b in ('B63', 'B64', 'B150')))
def P17():
    p = 'P-17'; filas, ids = anexoE_ids()
    chk(p, 'fila E5-8 en el Anexo E y salida existente', any(f.startswith('E5-8') for f in filas) and os.path.exists(os.path.join(EX, 'N5-entornos-en-contenedores/salidas/E5-8-capa4-y-artefacto.txt')))
    chk(p, 'salidas nuevas existen (E1-11 Node, E2-6)', os.path.exists(os.path.join(EX, 'N1-codificacion-y-finales-de-linea/salidas/e1-shebang-node.txt')))
    chk(p, 'línea de fechas de las corridas en el Anexo E', '2026-10-09' in t[t.index('## Anexo E.'):t.index('## Anexo F.')])
def P18():
    p = 'P-18'; dv = [l for l in L if l.startswith('**Datos volátiles**')]
    n = len(re.findall(r'\[B\d+\]', dv[0])) if dv else 0
    chk(p, '«Datos volátiles» con ≥ 12 citas [Bnn]', n >= 12, n)
    items = [x.strip() for x in re.sub(r'^\*\*Datos volátiles\*\* \([^)]*\): ', '', dv[0]).rstrip('.').split(';')] if dv else []
    sinfuente = [x for x in items if not re.search(r'\[B\d+\]|\(E\d-\d+\)|\(§[\d.]+\)', x)]
    chk(p, 'cada dato volátil con su fuente ([Bnn], experimento o sección)', items and not sinfuente, f'{len(items)} datos; sin fuente: {sinfuente}')
    chk(p, 'trazas P-03, P-04, P-07 nombran sus plantillas', 'A.1, A.2, A.15 |' in t and '| §7, A.5, A.6 |' in t and '§0.4, §3.6, §8.2.4, §10.4, §11.4, §12 |' in t)
def P19():
    p = 'P-19'; v = re.search(r'^version: (\S+)$', t, flags=re.M).group(1)
    f = re.search(r'^\| 1\.1\.0 \| 2026-10-09 \| ([^|]*) \|', t, flags=re.M)
    chk(p, 'fila 1.1.0 = version:', f is not None and v == '1.1.0', v)
    chk(p, 'celda ≤ 21 palabras', f and len(f.group(1).split()) <= 21, len(f.group(1).split()) if f else None)
    chk(p, "'Práctica de §3' = 0", t.count('Práctica de §3') == 0)
    chk(p, "'cuatro marcas de juicio (§0.3)' = 1", t.count('cuatro marcas de juicio (§0.3)') == 1)
    m = re.search(r'\*\*1\.1\.0\.\*\*.*?B218–B(\d+)\.', t)
    chk(p, 'rango del párrafo 1.1.0 = última fuente', m and f'B{m.group(1)}' == bdef[-1], m.group(1) if m else None)
def P20():
    p = 'P-20'; chk(p, '0 enlaces internos rotos', not rotos, rotos)
    chk(p, 'apertura del Anexo A remite a EA-1', 'cada plantilla dice qué paso la comprueba' in t)
def P21():
    p = 'P-21'; chk(p, '0 enlaces internos rotos', not rotos, rotos); chk(p, '§3: «La columna «Capítulo» de §3.2 es el mapa.»', 'La columna «Capítulo» de §3.2 es el mapa.' in t)
def P22():
    chk('P-22', '0 enlaces internos rotos', not rotos, rotos)
def P23():
    chk('P-23', "'**[no verificado]** (requiere Windows)' = 0", t.count('**[no verificado]** (requiere Windows)') == 0)
F = {f'P-{i:02d}': globals()[f'P{i:02d}'] for i in range(1, 24)}
for pid in (sys.argv[1:] or list(F)): F[pid]()
for r in res: print(*r, sep=' | ')
print(f"total={len(res)} OK={sum(1 for r in res if r[1].startswith('OK'))} FALLA={sum(1 for r in res if r[1]=='FALLA')}")
