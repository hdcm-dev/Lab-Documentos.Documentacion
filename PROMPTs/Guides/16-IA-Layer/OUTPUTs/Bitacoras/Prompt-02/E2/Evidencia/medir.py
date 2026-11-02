import re,sys
L=open(sys.argv[1],encoding='utf-8').read().split('\n')
def idx(a):
    for i,l in enumerate(L):
        if f'<a id="{a}"' in l: return i
    raise SystemExit(a)
STUB=' '.join(['x']*60)
def hist(lines,upper):
    out=[]
    for l in lines:
        if l.startswith('Historia (hasta'): continue
        if upper and 'Historia (hasta' in l and not l.lstrip().startswith('|'):
            l=l[:l.index('Historia (hasta')]
        out.append(l)
    return out
def defs(lines):
    a,b=idx('s3-0'),idx('s3-1'); c,d=idx('s4-1'),idx('s4-2')
    return lines[:a]+lines[b:c]+lines[d:]
def pract(lines):
    out=[];skip=False
    for l in lines:
        if re.match(r'^\*\*(0[1-9]|1[0-7]) · ',l) and 'Examples/' in l:
            n=l[2:4]
            if n in ('01','02','03','04','06','07','08','09','10','11','12','13'):
                out.append(l.split(' · `')[0]+'** '+STUB); skip=True; continue
        if skip and (l.startswith('**En la demo.**') or l.startswith('<a id=') or l.startswith('#')): skip=False
        if not skip: out.append(l)
    return out
def proc(lines):
    i=max(k for k,l in enumerate(lines) if l.startswith('## Anexo G'))
    return lines+['','## Anexo H · Procedencia','',' '.join(['x']*150)]
v=sys.argv[2]; X=L
if 'P' in v: X=pract(X)   # D-11 d (antes: usa índices de texto, no de ancla)
if 'D' in v:
    L2=X
    def idx2(a):
        for i,l in enumerate(L2):
            if f'<a id="{a}"' in l: return i
    a,b=idx2('s3-0'),idx2('s3-1'); c,d=idx2('s4-1'),idx2('s4-2'); X=X[:a]+X[b:c]+X[d:]
if 'h' in v: X=hist(X,False)
if 'H' in v: X=hist(X,True)
if 'A' in v: X=proc(X)
open(sys.argv[3],'w',encoding='utf-8').write('\n'.join(X))
