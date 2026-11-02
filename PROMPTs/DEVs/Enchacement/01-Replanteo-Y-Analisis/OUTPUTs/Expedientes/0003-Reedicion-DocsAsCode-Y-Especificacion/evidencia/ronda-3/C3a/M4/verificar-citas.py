#!/usr/bin/env python3
# Uso: verificar-citas.py <corrida>  (rutas relativas a la corrida)
# Resuelve cada cita archivo:linea de salida/ contra repo/{,proyecto}; si no esta en repo
# pero si en salida/ se clasifica como archivo creado por la corrida (no invencion).
import os,re,sys,random,json
base=sys.argv[1]; repo=os.path.join(base,'repo'); sal=os.path.join(base,'salida')
pat=re.compile(r'(?<![A-Za-z0-9_./\-])([A-Za-z0-9_.\-]+(?:/[A-Za-z0-9_.\-]+)*\.[A-Za-z][A-Za-z0-9]*):(\d+)(?:-(\d+))?')
def nl(fp): return sum(1 for _ in open(fp,'rb'))
def busca(root,ruta):
  for x in ('','proyecto'):
    p=os.path.join(root,x,ruta)
    if os.path.isfile(p): return p
  return None
res=[]
for dp,dn,fs in os.walk(sal):
  dn[:]=[d for d in dn if d not in('node_modules','.git')]
  for f in fs:
    p=os.path.join(dp,f)
    try: t=open(p,encoding='utf-8').read()
    except Exception: continue
    for m in pat.finditer(t):
      ruta,a,b=m.group(1),int(m.group(2)),int(m.group(3) or m.group(2))
      if ruta.startswith(('http','www.')) or re.fullmatch(r'[\d.]+',ruta): continue
      fp=busca(repo,ruta); est='ok'
      if not fp:
        fs2=busca(sal,ruta)
        if fs2: est='creado-por-la-corrida' if (1<=a<=b<=nl(fs2)) else 'linea-fuera-de-rango-en-salida'
        else: est='archivo-inexistente'
      elif a<1 or b>nl(fp) or a>b: est='linea-fuera-de-rango(%d)'%nl(fp)
      res.append((os.path.relpath(p,base),m.group(0),est))
ok=[r for r in res if r[2]=='ok']; cre=[r for r in res if r[2]=='creado-por-la-corrida']
bad=[r for r in res if r[2] not in('ok','creado-por-la-corrida')]
a01=[r for r in res if r[0]=='salida/A-01.md']
random.seed(3)
print(json.dumps({'corrida':os.path.basename(base.rstrip('/')),'citas':len(res),'ok':len(ok),'creadas_por_la_corrida':len(cre),'residuos':len(bad),
 'A01':{'citas':len(a01),'ok':sum(r[2]=='ok' for r in a01),'residuos':sum(r[2] not in('ok','creado-por-la-corrida') for r in a01)},
 'detalle_residuos':sorted(set(bad)),'muestra_verificada':random.sample(ok,min(20,len(ok)))},ensure_ascii=False,indent=1))
