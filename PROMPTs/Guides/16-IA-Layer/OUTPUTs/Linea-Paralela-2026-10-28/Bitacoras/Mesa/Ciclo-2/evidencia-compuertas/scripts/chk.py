import sys,re,os
G=sys.argv[1]; L=open(G+'/Dot-Net-Integration-AI-Layer-Guide.md',encoding='utf-8').read().split('\n')
def norm(s): return re.sub(r'\s+',' ',s.strip())
for spec in sys.argv[2:]:
    blk,path,rng=spec.split('|'); a=int(blk)
    j=a
    while not L[j].startswith('```'): j+=1
    body=[norm(x) for x in L[a:j] if norm(x)]
    src=open(G+'/'+path,encoding='utf-8').read().split('\n')
    segs=[]
    for r in rng.split(','):
        lo,hi=map(int,r.split('-')); segs+= [norm(x) for x in src[lo-1:hi]]
    miss=[x for x in body if x not in segs]
    print(f'B{a} {len(body)-len(miss)}/{len(body)} {path}:{rng}')
    for x in miss: print('   falta:',x[:120])
