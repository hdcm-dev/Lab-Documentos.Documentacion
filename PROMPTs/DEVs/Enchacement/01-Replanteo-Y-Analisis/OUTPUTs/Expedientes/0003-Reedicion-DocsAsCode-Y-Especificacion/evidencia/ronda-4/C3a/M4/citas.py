#!/usr/bin/env python3
"""M4: extrae citas archivo:línea de salida/ y verifica contra repo/proyecto."""
import os,re,sys,json
run=sys.argv[1]; sal=os.path.join(run,'salida'); repo=os.path.join(run,'repo','proyecto')
ref=re.compile(r'([A-Za-z0-9_./-]+\.[A-Za-z0-9]+):(\d+)(?:-(\d+))?((?:\s*(?:,|y)\s*:?\d+(?:-\d+)?)*)')
cont=re.compile(r'^[,;]?\s*(?:y\s*)?:(\d+)(?:-(\d+))?')
quote=re.compile(r'«([^»]{6,})»')
def norm(s): return re.sub(r'[^\wáéíóúñü]+',' ',s.lower()).strip()
res=[]
skip=('_auxiliares/montaje','.docs-guard-origen','package-lock')
for d,_,fs in os.walk(sal):
  for f in fs:
    p=os.path.join(d,f); rel=os.path.relpath(p,sal)
    if any(s in rel for s in skip): continue
    try: lines=open(p,encoding='utf-8').read().split('\n')
    except Exception: continue
    for i,L in enumerate(lines,1):
      cites=[]
      for m in ref.finditer(L):
        fn=m.group(1); a=int(m.group(2)); b=int(m.group(3) or a); cites.append((fn,a,b))
        for n in re.finditer(r'(\d+)(?:-(\d+))?',m.group(4) or ''):
          cites.append((fn,int(n.group(1)),int(n.group(2) or n.group(1))))
        # forma ":72-73" suelta tras la cita en la misma celda
        tail=L[m.end():m.end()+40]
        mm=cont.match(tail.strip())
        if mm and not m.group(4): cites.append((fn,int(mm.group(1)),int(mm.group(2) or mm.group(1))))
      for fn,a,b in cites:
        if fn.startswith(('http','www')) or re.match(r'^\d',fn): continue
        tgt=os.path.join(repo,fn); st='OK'; txt=''
        if not os.path.isfile(tgt):
          c=[os.path.join(r,x) for r,_,xs in os.walk(repo) if '.git' not in r for x in xs if os.path.join(r,x).endswith('/'+fn)]
          tgt=c[0] if len(c)==1 else None
        if not tgt: st='ARCHIVO_INEXISTENTE'
        else:
          R=open(tgt,encoding='utf-8',errors='replace').read().split('\n')
          if R and R[-1]=='': R=R[:-1]
          if a<1 or b>len(R) or a>b: st=f'FUERA_DE_RANGO(len={len(R)})'
          else:
            txt=' | '.join(R[a-1:b])
            qs=[q for q in quote.findall(L)]
            for q in qs:
              # sólo si la cita textual va pegada a esta referencia
              if f'{fn}:{a}' in L and L.find(q) < L.find(f'{fn}:{a}') and L.find(f'{fn}:{a}')-L.find(q)<len(q)+12:
                if norm(q)[:40] not in norm(' '.join(R[max(0,a-3):b+2])): st='CITA_TEXTUAL_NO_COINCIDE:'+q[:60]
        res.append(dict(origen=f'salida/{rel}:{i}',cita=f'{fn}:{a}'+(f'-{b}' if b!=a else ''),estado=st,contenido=txt[:200]))
json.dump(res,sys.stdout,ensure_ascii=False,indent=1)
