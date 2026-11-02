# C4: cada carpeta de Examples/ y Demos/ citada en la guía; cada ruta citada en code spans existe; rangos de líneas dentro del archivo.
import re,sys,os,glob
G=sys.argv[1]; guia=os.path.join(G,'Dot-Net-Integration-AI-Layer-Guide.md')
t=open(guia,encoding='utf-8').read()
dirs=sorted(d for d in os.listdir(os.path.join(G,'Examples')))+['MovilidadUrbana.Asistente']
print('== carpetas citadas')
for d in dirs:
    n=len(re.findall(re.escape(d),t)); print(f'{d}: {n}')
print('== rutas citadas que no existen')
files=[p for p in glob.glob(G+'/**/*',recursive=True) if '/bin/' not in p and '/obj/' not in p]
rel=[os.path.relpath(p,G) for p in files]
bad=0;tot=0;rng=0;badr=0
lines=t.split('\n')
last_full=None
for i,l in enumerate(lines,1):
    for m in re.finditer(r'`((?:Examples|Demos|…|\.\.\.)/[^`\s]+)`',l):
        p=m.group(1).rstrip('/').rstrip('.,;:)')
        tot+=1
        if p.startswith(('…/','.../')):
            suf=p.split('/',1)[1]
            cands=[r for r in rel if r.endswith(suf)]
            if last_full:
                c2=[r for r in cands if r.startswith(last_full)]
                cands=c2 or cands
            ok=bool(cands); target=cands[0] if cands else None
        else:
            if p.startswith('Examples/') or p.startswith('Demos/'):
                parts=p.split('/'); last_full='/'.join(parts[:2])
            ok=os.path.exists(os.path.join(G,p)); target=p
            if not ok:
                # comodines: NN, *
                if "*" in p or "NN" in p: ok=True
                mm=re.fullmatch(r"Examples/(\d\d)",p)
                if mm and any(x.startswith(mm.group(1)+"-") for x in os.listdir(os.path.join(G,"Examples"))): ok=True
        if not ok: bad+=1; print(f'L{i}: {p}')
        # rango de líneas inmediatamente después
        rest=l[m.end():m.end()+60]
        mr=re.match(r'[^`]{0,25}?l[ií]neas? (\d+)(?:[–-](\d+))?',rest)
        if ok and target and mr and os.path.isfile(os.path.join(G,target)):
            rng+=1
            n=sum(1 for _ in open(os.path.join(G,target),encoding='utf-8',errors='replace'))
            hi=int(mr.group(2) or mr.group(1))
            if hi>n: badr+=1; print(f'L{i}: {target} líneas {mr.group(0)} > {n}')
print(f'rutas citadas: {tot}; inexistentes: {bad}; rangos verificados: {rng}; fuera de archivo: {badr}')
print('== directorios de primer nivel bajo cada ejemplo no citados')
for d in dirs:
    base=os.path.join(G,'Examples',d) if d!='MovilidadUrbana.Asistente' else os.path.join(G,'Demos',d)
    for sub in sorted(os.listdir(base)):
        if sub.startswith('.') : continue
        pass
