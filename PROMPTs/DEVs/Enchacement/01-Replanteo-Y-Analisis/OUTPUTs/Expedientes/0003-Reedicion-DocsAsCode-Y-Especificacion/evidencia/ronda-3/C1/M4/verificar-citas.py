#!/usr/bin/env python3
# Uso: verificar-citas.py <corrida>  (rutas relativas a la corrida)
import os,re,sys,random,json
base=sys.argv[1]; repo=os.path.join(base,'repo'); sal=os.path.join(base,'salida')
pat=re.compile(r'([A-Za-z0-9_.\-]+(?:/[A-Za-z0-9_.\-]+)+\.[A-Za-z0-9]+):(\d+)(?:-(\d+))?')
res=[]
for dp,_,fs in os.walk(sal):
  for f in fs:
    p=os.path.join(dp,f)
    try: t=open(p,encoding='utf-8').read()
    except Exception: continue
    for m in pat.finditer(t):
      ruta,a,b=m.group(1),int(m.group(2)),int(m.group(3) or m.group(2))
      if ruta.startswith('home/') or 'workspace-dev' in ruta:
        res.append((os.path.relpath(p,base),'<ruta-absoluta-fuera-de-repo>',  'fuera-de-repo')); continue
      fp=next((os.path.join(repo,x,ruta) for x in ('','LG','LGD') if os.path.isfile(os.path.join(repo,x,ruta))),None); est='ok'
      if not fp: est='archivo-inexistente'
      else:
        n=sum(1 for _ in open(fp,'rb'))
        if a<1 or b>n or a>b: est='linea-fuera-de-rango(%d)'%n
      res.append((os.path.relpath(p,base),m.group(0),est))
ok=[r for r in res if r[2]=='ok']; bad=[r for r in res if r[2] not in('ok','fuera-de-repo')]; fuera=[r for r in res if r[2]=='fuera-de-repo']
a01=[r for r in res if r[0]=='salida/A-01.md']
random.seed(3)
print(json.dumps({'corrida':os.path.basename(base.rstrip('/')),'citas':len(res),'ok':len(ok),'invenciones':len(bad),'fuera_de_repo':len(fuera),'A01':{'citas':len(a01),'invenciones':sum(r[2] not in('ok','fuera-de-repo') for r in a01)},
 'detalle_invenciones':sorted(set(bad)),'muestra_verificada':random.sample(ok,min(20,len(ok)))},ensure_ascii=False,indent=1))
