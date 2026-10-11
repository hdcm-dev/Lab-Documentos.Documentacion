import re, sys, os, unicodedata, collections
G = sys.argv[1]; base = os.path.dirname(G)
t = open(G, encoding="utf-8").read(); L = t.split("\n")
# --- encabezados fuera de código y slugs estilo GitHub
fence = False; heads = []; code_ok = True; opened = None; mermaids = []; cur = None; yamlblocks = []
for i, l in enumerate(L, 1):
    m = re.match(r"^(\s*)```(\S*)", l)
    if m:
        if not fence: fence = True; opened = (i, m.group(2)); cur = []
        else:
            if l.strip() != "```": print("CIERRE RARO", i, l)
            fence = False
            if opened[1] == "mermaid": mermaids.append((opened[0], "\n".join(cur)))
            if opened[1] == "yaml": yamlblocks.append((opened[0], "\n".join(cur)))
        continue
    if fence: cur.append(l); continue
    h = re.match(r"^(#{1,6}) (.*)$", l)
    if h: heads.append((i, len(h.group(1)), h.group(2)))
if fence: print("BLOQUE SIN CERRAR desde", opened); code_ok = False
def slug(s):
    s = s.strip().lower()
    s = re.sub(r"[^\w\- ]", "", s, flags=re.U)
    return s.replace(" ", "-")
cnt = collections.Counter(); anchors = set()
for i, lv, txt in heads:
    sl = slug(txt); n = cnt[sl]; cnt[sl] += 1
    anchors.add(sl if n == 0 else f"{sl}-{n}")
dups = [k for k, v in cnt.items() if v > 1]
links = re.findall(r"\]\(#([^)]+)\)", t)
rotas = sorted(set(a for a in links if a not in anchors))
print(f"encabezados={len(heads)} anclas={len(anchors)} enlaces internos={len(links)} rotos={len(rotas)} slugs duplicados={dups}")
for r in rotas: print("  ROTO #" + r)
# --- índice ↔ encabezados ##
idx = [m for m in re.findall(r"^- \*\*\[[^\]]+\]\(#([^)]+)\)\*\*", t, flags=re.M)]
h2 = [slug(x[2]) for x in heads if x[1] == 2 and x[2] not in ("Índice",)]
print("índice en orden con ## :", idx == h2, f"({len(idx)} entradas, {len(h2)} encabezados ##)")
if idx != h2:
    for a, b in zip(idx, h2):
        if a != b: print("   ", a, "≠", b)
# --- enlaces relativos
rel = re.findall(r"\]\((?!#|https?:)([^)]+)\)", t)
falt = [r for r in set(rel) if not os.path.exists(os.path.normpath(os.path.join(base, r.split("#")[0])))]
print(f"enlaces relativos={len(set(rel))} inexistentes={falt}")
# --- rutas Examples/ citadas en texto (backticks)
paths = set(re.findall(r"`(Examples/[^`*…]+?)`", t))
nofound = [p for p in paths if not os.path.exists(os.path.join(base, p.rstrip("/")))]
print(f"rutas `Examples/…` citadas={len(paths)} inexistentes={sorted(nofound)}")
# --- Bnn
defs = set(re.findall(r"^\| (B\d{2,3}) \|", t, flags=re.M))
cits = set(re.findall(r"\[(B\d{2,3})\]", t))
print(f"Bnn definidas={len(defs)} citadas={len(cits)} citadas sin definir={sorted(cits-defs)} definidas sin citar={sorted(defs-cits)}")
# --- IDs de experimentos
ane = t[t.index("## Anexo E."):t.index("## Anexo F.")]
filas = re.findall(r"^\| (E[0-9A]+-[0-9a-z/ E\-]+?) \|", ane, flags=re.M)
ids_tab = set()
for f in filas:
    for p in re.split(r"\s*/\s*", f):
        p = p.strip()
        m = re.match(r"(E\d)-(\d+)([a-z/]*)$", p)
        ids_tab.add(p)
        if m and "/" in m.group(3):
            for x in m.group(3).split("/"): ids_tab.add(f"{m.group(1)}-{m.group(2)}{x}")
        if re.match(r"E\d-\d+[a-z]$", p): ids_tab.add(p[:-1])
cuerpo = t[:t.index("## Anexo E.")] + t[t.index("## Anexo F."):]
ids_body = set(re.findall(r"\b(E[0-9]-\d+[a-z]?|EA-1)\b", cuerpo))
norm = lambda x: re.sub(r"^E(\d)-0?(\d+)", lambda m: f"E{m.group(1)}-{int(m.group(2)):02d}" if m.group(1)=="1" else f"E{m.group(1)}-{m.group(2)}", x)
ids_tab_n = {norm(x) for x in ids_tab}
sin_fila = sorted(x for x in ids_body if norm(x) not in ids_tab_n and norm(x).rstrip("abc") not in ids_tab_n)
print(f"IDs de experimento en el cuerpo={len(ids_body)} sin fila en el Anexo E={sin_fila}; filas del Anexo E={len(filas)}")
open(sys.argv[2] + "/mermaid_blocks.txt", "w").write("\n%%%%\n".join(b for _, b in mermaids))
import json; json.dump([b for _, b in mermaids], open(sys.argv[2] + "/mermaid.json", "w"))
json.dump([b for _, b in yamlblocks], open(sys.argv[2] + "/yaml.json", "w"))
print(f"bloques mermaid={len(mermaids)} yaml={len(yamlblocks)} bloques cerrados={code_ok}")
