import sys, re, glob, json
exec(open("fw.py", encoding="utf-8").read())
for p in ["p1.py","p2.py","p3.py","p4.py","p5.py","p6.py"]:
    exec(open(p, encoding="utf-8").read())
B="<workspace>/LAB/Lab-Documentos.Documentacion/PROMPTs/Guides/15-Metodologia-Entorno-Desarrollo/OUTPUTs/Bitcora"
files = glob.glob(B+"/Nucleos/*.md") + [B+"/03-Marco-De-Referencia.md", B+"/04-Integracion.md"]
txt = {f: open(f, encoding="utf-8").read() for f in files}
strip = lambda s: re.sub(r"[*`]", "", s)
hits = []
for pid, old in OLDS:
    if not re.match(r"P-(0[3-9]|1[0-7])$", pid): continue
    segs = [x.strip() for x in re.split(r"[.;:\n]", strip(old)) if len(x.strip()) >= 28]
    for f, t in txt.items():
        ts = strip(t)
        for sg in segs:
            k = ts.find(sg)
            if k >= 0:
                line = ts[:k].count("\n") + 1
                after = "\n".join(ts.split("\n")[line-1:line+25])
                hits.append((pid, f.split("/")[-1], line, sg[:60], "Corrección mesa ciclo 1" in after))
                break
seen=set()
for h in hits:
    key=(h[1],h[2])
    if key in seen: continue
    seen.add(key); print(h)
print("coincidencias", len(seen))
