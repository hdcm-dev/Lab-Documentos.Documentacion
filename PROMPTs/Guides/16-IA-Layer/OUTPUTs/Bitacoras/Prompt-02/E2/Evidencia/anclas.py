import re,sys
L=open('base.md',encoding='utf-8').read().split('\n')
ids=[]
for i,l in enumerate(L):
    for m in re.finditer(r'<a id="([^"]+)"',l): ids.append((i+1,m.group(1),l))
ROM={'0':'prologo','i':'parte-2','ii':'parte-3','iii':'parte-4','iv':'parte-5','v':'parte-6','vi':'parte-7'}
DEC={'s4-6','s5-8','s6-7','s7-8','s8-10','s10-8','s11-8','s12-10'}
def titulo(i,l):
    t=re.sub(r'<a id="[^"]*"></a>','',l).strip()
    if not t and i<len(L): t=L[i].strip()
    return t.replace('|','/')[:70]
def mapa(x):
    if x.startswith('parte-'): return ROM[x[6:]], 'alias'
    if x.startswith(('oa-','anexo-','cierre')):
        if x=='anexo-c': return 'anexo-c','se conserva; absorbe §3.0 y §4.1 (C-2.3)'
        if x=='anexo-e-1': return 'anexo-e-1','se conserva; único mapa de ejemplos (C-2.7)'
        return x,'se conserva'
    m=re.match(r's(\d+)(?:-(.+))?$',x)
    n=int(m.group(1)); k=m.group(2); c=('c17' if n==15 else f'c{n+1}') if n>0 else 'c0'
    if k is None: return c,'alias'
    if x in ('s3-0','s4-1'): return 'anexo-c','alias; definiciones fusionadas en el glosario (C-2.3)'
    if x in DEC: return c+'-decision','alias; paso «Decisión» del patrón (D-09 a)'
    if x=='s9-criterio': return 'c10-decision','alias; paso «Decisión» del patrón (D-09 a)'
    if k=='practica': return c+'-escenarios','alias; el rótulo «Práctica» desaparece (D-09 a)'
    if k=='ejemplos' and n in (5,7,8): return c+'-ejemplos','alias; prácticas al README, quedan objetivo, comando, salida y enlace (D-11 d)'
    if k in ('escenarios','ejemplos','preguntas','calidad'): return f'{c}-{k}','alias; paso del patrón (D-09 a)'
    if x=='s0-5': return 'c0-5','alias; remite a anexo-e-1 (C-2.7)'
    return f'{c}-{k}','alias'
rows=[];dest=set()
for ln,x,l in ids:
    d,nota=mapa(x); rows.append((x,ln,titulo(ln,l),d,nota)); dest.add(d)
old={x for _,x,_ in ids}
choque=[d for d in dest if d in old and not any(r[0]==d and r[3]==d for r in rows)]
print(len(rows),'filas;',len(set(r[0] for r in rows)),'únicas; choques',choque, file=sys.stderr)
with open('tabla.md','w',encoding='utf-8') as f:
    f.write('| # | Ancla 0.11.0 | Línea | Encabezado o fila | Ancla nueva | Tratamiento |\n|---|---|---|---|---|---|\n')
    for i,r in enumerate(rows,1):
        f.write(f'| {i} | `{r[0]}` | {r[1]} | {r[2]} | `{r[3]}` | {r[4]} |\n')
