#!/usr/bin/env python3
# Uso: python3 -I verificar-citas.py <corrida>   (rutas relativas a la corrida)
# 1) toda cita ruta:línea[-línea] de salida/ se resuelve contra repo/{,LG,LGD} y rango;
# 2) en salida/A-01.md, además, cada literal `...` (o **...**) de la misma línea de la ficha
#    se busca en la línea citada (±2): contenido-coincide / sin-literal-contrastable / literal-no-hallado.
import os,re,sys,random,json
base=sys.argv[1].rstrip('/'); repo=os.path.join(base,'repo'); sal=os.path.join(base,'salida')
pat=re.compile(r'([A-Za-z0-9_.\-{}]+(?:/[A-Za-z0-9_.\-{}]+)+\.[A-Za-z0-9]+):(\d+)(?:-(\d+))?')
lit=re.compile(r'`([^`]{3,80})`|\*\*([^*]{3,60})\*\*')
def resolver(r):
  return next((os.path.join(repo,x,r) for x in ('','LG','LGD') if os.path.isfile(os.path.join(repo,x,r))),None)
res=[];a01=[]
for dp,_,fs in os.walk(sal):
  for f in fs:
    p=os.path.join(dp,f); rel=os.path.relpath(p,base)
    try: L=open(p,encoding='utf-8').read().splitlines()
    except Exception: continue
    for ln in L:
      for m in pat.finditer(ln):
        ruta,a,b=m.group(1),int(m.group(2)),int(m.group(3) or m.group(2))
        if ruta.startswith(('home/','vm/')) or 'workspace-dev' in ruta: res.append((rel,'<ruta-absoluta>','fuera-de-repo'));continue
        fp=resolver(ruta); est='ok'
        if not fp:
          r2=ruta[2:] if ruta.startswith('./') else ruta
          if os.path.isfile(os.path.join(repo,'LG','src',r2)): fp=os.path.join(repo,'LG','src',r2); est='ok'
          elif any(os.path.isfile(os.path.join(sal,x,r2)) for x in ('','LG','LGD')) or any(os.path.isfile(os.path.join(sal,x)) for x in (r2,)): est='triado:archivo-creado-por-la-corrida'
          elif '...' in ruta or re.match(r'^(Api|Web|Maquetas)/',ruta): est='triado:abreviatura-en-texto-del-repo'
          else: est='archivo-inexistente'
        if est.startswith('triado'): res.append((rel,m.group(0),est)); continue
        else:
          tl=open(fp,encoding='utf-8',errors='replace').read().splitlines()
          if a<1 or b>len(tl) or a>b: est='linea-fuera-de-rango(%d)'%len(tl)
        res.append((rel,m.group(0),est))
        if rel=='salida/A-01.md' and est=='ok':
          ventana='\n'.join(tl[max(0,a-3):b+2]).lower()
          ls=[ (x or y).strip() for x,y in lit.findall(ln)]
          ls=[x for x in ls if not pat.search(x) and not x.endswith(('.txt','.sh','.py')) and ' ' not in x[:1]]
          hits=[x for x in ls if x.lower() in ventana]
          a01.append({'cita':m.group(0),'contenido':'contenido-coincide' if hits else 'sin-literal-contrastable','literal':hits[:2]})
ok=[r for r in res if r[2]=='ok']; bad=sorted(set(r for r in res if r[2]=='archivo-inexistente' or r[2].startswith('linea'))); tri=sorted(set(r for r in res if r[2].startswith('triado')))
A=[r for r in res if r[0]=='salida/A-01.md']
random.seed(4)
print(json.dumps({'corrida':os.path.basename(base),'citas':len(res),'ok':len(ok),'no_resueltas':len(bad),'fuera_de_repo':sum(r[2]=='fuera-de-repo' for r in res),
 'A01':{'citas':len(A),'no_resueltas':sum(r[2]!='ok' for r in A),
        'contenido':{k:sum(1 for x in a01 if x['contenido']==k) for k in ('contenido-coincide','sin-literal-contrastable')},'detalle':a01},
 'invenciones':len(bad),'detalle_invenciones':bad,'triados':{k:sum(1 for r in tri if r[2]==k) for k in set(r[2] for r in tri)},'detalle_triados':tri,'muestra_salida':random.sample(ok,min(20,len(ok)))},ensure_ascii=False,indent=1))
