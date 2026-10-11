import re, sys, json, importlib.util
import os; S=os.path.dirname(os.path.abspath(__file__))
G=os.environ.get('GUIA', os.path.join(S,'../../../../../../../../../Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md'))
spec=importlib.util.spec_from_file_location('pg', S+'/parches_guia.py'); pg=importlib.util.module_from_spec(spec); spec.loader.exec_module(pg)
orig=open(G,encoding='utf-8').read(); txt=orig
def prose(s):
    s=re.sub(r'```.*?```', ' ', s, flags=re.S)
    s='\n'.join(l for l in s.split('\n') if not re.match(r'^\| B\d{2,3} \|', l) and not re.match(r'^  - "', l) and l.strip()!='```')
    return len(s.split())
def tot(s): return len(s.split())
res=[]; errores=[]
for P in pg.P:
    dp=dt=0; detalle=[]
    for i,op in enumerate(P['ops']):
        k=op[0]
        if k=='RL':
            pre,new=op[1],op[2]
            starts=[m.start() for m in re.finditer(r'(?m)^'+re.escape(pre), txt)]
            if len(starts)!=1: errores.append((P['id'],i,'RL',len(starts),pre[:60])); continue
            a=starts[0]; b=txt.find('\n',a); old=txt[a:b]; txt=txt[:a]+new+txt[b:]; mult=1
            P['ops'][i]=('RL',pre,new,op[3],old)
        elif k in ('R','RA'):
            old,new=op[1],op[2]; n=txt.count(old)
            if (k=='R' and n!=1) or (k=='RA' and n<1): errores.append((P['id'],i,k,n,old[:80])); continue
            txt=txt.replace(old,new); mult=n
        else:
            a,b,new=op[1],op[2],op[3]
            ia=txt.find(a); 
            if txt.count(a)!=1: errores.append((P['id'],i,'RG-desde',txt.count(a),a[:60])); continue
            if b=='\x00FIN': ib=len(txt)
            else:
                ib=txt.find(b,ia)
                if ib<0 or txt.count(b)!=1: errores.append((P['id'],i,'RG-hasta',txt.count(b),b[:60])); continue
            old=txt[ia:ib]; txt=txt[:ia]+new+txt[ib:]; mult=1
            P['ops'][i]=(k,a,b,new,op[4],old)
        cubo=op[3] if k in ('R','RA','RL') else op[4] if k=='RG' and len(op)>4 and op[4] in ('prosa','evid') else None
        if k=='RG': cubo=pg.P[[x['id'] for x in pg.P].index(P['id'])]['ops'][i][4] if False else None
        if cubo=='evid' and '```' not in old+new: d_p=0
        else: d_p=(prose(new)-prose(old))*mult
        d_t=(tot(new)-tot(old))*mult
        dp+=d_p; dt+=d_t; detalle.append((i,d_p,d_t-d_p))
    res.append((P['id'],dp,dt-dp,detalle))
open(S+'/guia-parcheada.md','w',encoding='utf-8').write(txt)
print('errores:',errores)
import pickle; pickle.dump(pg.P, open(S+'/P_aplicado.pkl','wb'))
SP=SE=0
for pid,dp,de,det in res:
    print(f'{pid}: prosa {dp:+d}  evid {de:+d}'); SP+=dp; SE+=de
print('TOTAL prosa',SP,'evid',SE,'| wc -w antes',tot(orig),'después',tot(txt))
json.dump([[pid,dp,de,det] for pid,dp,de,det in res], open(S+'/deltas.json','w'))
