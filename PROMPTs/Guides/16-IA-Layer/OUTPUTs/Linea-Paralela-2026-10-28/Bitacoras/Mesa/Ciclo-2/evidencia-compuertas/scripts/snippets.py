# Compara cada bloque csharp de la guía con el archivo y las líneas que cita «Compila en».
import re,sys,os,glob
G=sys.argv[1]; L=open(os.path.join(G,'Dot-Net-Integration-AI-Layer-Guide.md'),encoding='utf-8').read().split('\n')
files=[os.path.relpath(p,G) for p in glob.glob(G+'/**/*',recursive=True) if os.path.isfile(p) and '/bin/' not in p and '/obj/' not in p]
blocks=[];i=0
while i<len(L):
    m=re.match(r'^```(\w*)',L[i])
    if m:
        j=i+1
        while not L[j].startswith('```'): j+=1
        blocks.append((i+1,j+1,m.group(1),L[i+1:j])); i=j+1
    else: i+=1
last_full=None
def resolve(p,ctx):
    p=p.rstrip('.,;:)')
    if p.startswith(('Examples/','Demos/')):
        return p if os.path.exists(os.path.join(G,p)) else None
    suf=p.split('/',1)[1] if p.startswith(('…/','.../')) else p
    c=[r for r in files if r.endswith('/'+suf) or r==suf]
    if ctx: c=[r for r in c if r.startswith(ctx)] or c
    return c[0] if len(c)>=1 else None
ctxs={}
cur=None
for n,l in enumerate(L,1):
    for m in re.finditer(r'`((?:Examples|Demos)/[^`\s]+)`',l):
        parts=m.group(1).split('/'); cur='/'.join(parts[:2]); 
        if parts[0]=='Examples' and re.fullmatch(r'\d\d',parts[1]):
            cur=next((('Examples/'+x) for x in os.listdir(G+'/Examples') if x.startswith(parts[1]+'-')),cur)
    ctxs[n]=cur
def norm(s): return re.sub(r'\s+',' ',s.strip())
tot=ok=sinref=0
for (a,b,lang,body) in blocks:
    if lang not in ('csharp',): continue
    tot+=1
    ref=None
    for k in range(b+1,min(b+4,len(L))):
        if 'Compila en' in L[k-1] and not L[k-1].rstrip().endswith(':'): ref=(k,L[k-1]); break
        if L[k-1].startswith('```'): break
    if not ref:
        for k in range(a-1,max(a-6,0),-1):
            if 'Compila en' in L[k-1] and L[k-1].rstrip().rstrip('*').endswith(':'): ref=(k,L[k-1]); break
            if L[k-1].startswith('```'): break
    if not ref:
        has_using=any(x.strip().startswith('using ') for x in body)
        sinref+=1; print(f'B{a}: SIN «Compila en» (using propio: {has_using})'); continue
    k,line=ref
    m=re.search(r'Compila en `([^`]+)`',line)
    path=resolve(m.group(1),ctxs.get(k)) if m else None
    rm=re.search(r'Compila en `[^`]+`[^(]{0,30}?(?:\(|, )?\s*(?:l\.|l[ií]neas)\s*(\d+)\s*[-–]\s*(\d+)',line)
    if not path: print(f'B{a}: ruta no resuelta {m.group(1) if m else line[:80]}'); continue
    src=open(os.path.join(G,path),encoding='utf-8',errors='replace').read().split('\n')
    sn=[norm(x) for x in body if norm(x) and not norm(x).startswith(('// …','// ...','…','...'))]
    if rm:
        lo,hi=int(rm.group(1)),int(rm.group(2)); seg=[norm(x) for x in src[lo-1:hi]]
    else:
        lo=hi=None; seg=[norm(x) for x in src]
    found=sum(1 for x in sn if x in seg)
    allf=sum(1 for x in sn if x in [norm(y) for y in src])
    frac=found/len(sn) if sn else 1
    status='OK' if frac>=0.95 else 'DIFIERE'
    if status=='OK': ok+=1
    print(f'B{a}: {status} {found}/{len(sn)} en rango {lo}-{hi} (en archivo {allf}) {path}')
    if status!='OK':
        for x in sn:
            if x not in seg: print('      falta:', x[:110])
print(f'bloques csharp: {tot}; coinciden: {ok}; sin referencia: {sinref}')
