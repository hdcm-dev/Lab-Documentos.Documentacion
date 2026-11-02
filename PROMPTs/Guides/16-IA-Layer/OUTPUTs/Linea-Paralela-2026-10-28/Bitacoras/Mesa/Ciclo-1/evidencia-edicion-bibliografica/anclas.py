# Compuerta de anclas: para cada .md, compara los enlaces internos (#...) con los
# encabezados reales (slug estilo GitHub). Uso: python3 -I anclas.py <archivos...>
import re, sys, unicodedata
def slug(h):
    h = h.strip().lower()
    h = re.sub(r'[`*_]', '', h)
    h = re.sub(r'\[([^\]]*)\]\([^)]*\)', r'\1', h)
    out = []
    for ch in h:
        if ch.isalnum() or ch in '-_ ':
            out.append(ch)
    return ''.join(out).replace(' ', '-')
for f in sys.argv[1:]:
    txt = open(f, encoding='utf-8').read()
    # quitar bloques de código
    txt_nc = re.sub(r'```.*?```', '', txt, flags=re.S)
    heads = [m.group(2) for m in re.finditer(r'^(#{1,6})\s+(.*)$', txt_nc, flags=re.M)]
    slugs = {}
    for h in heads:
        s = slug(h); n = slugs.get(s, -1) + 1; slugs[s] = n
    valid = set()
    for s, n in slugs.items():
        valid.add(s)
        for i in range(1, n + 1): valid.add(f'{s}-{i}')
    links = re.findall(r'\]\(#([^)]+)\)', txt_nc)
    bad = [l for l in links if l not in valid]
    nh2 = len(re.findall(r'^## ', txt_nc, flags=re.M))
    print(f'{f.split("/")[-1]}: enlaces internos={len(links)} rotos={len(bad)} h2={nh2}')
    for b in bad: print('   ROTO #' + b)
