import json,glob,os,statistics as st,sys
base=sys.argv[1]; rows={}
for f in sorted(glob.glob(base+'/estacion-*/**/*.jsonl',recursive=True)):
    est=f[len(base)+1:].split('/')[0]; rel=f[len(base)+1:]
    run=rel.split('/')[1] if rel.count('/')>1 else os.path.basename(f).split('.')[0]
    for l in open(f):
        try:d=json.loads(l)
        except:continue
        if d.get('tipo')!='llamada' or d.get('duracion_reloj_ms') is None:continue
        rows.setdefault((est,d.get('modelo'),run),[]).append(d)
def q(v,p):v=sorted(v);return v[min(len(v)-1,int(round(p*(len(v)-1))))]
print("estacion\tmodelo\tcorrida\tn\tmediana_s\tp90_s\tmax_s\tmedia_s\tfrio\tmaquina_valores")
agg={}
for k,v in sorted(rows.items()):
    t=[x['duracion_reloj_ms']/1000 for x in v]; agg.setdefault(k[:2],[]).extend(t)
    print(*k,len(t),f"{st.median(t):.1f}",f"{q(t,.9):.1f}",f"{max(t):.1f}",f"{st.mean(t):.1f}",sum(1 for x in v if x.get('estado_cache')=='frio'),",".join(sorted({str(x.get('maquina')) for x in v})),sep='\t')
print("\n# por estacion y modelo (descriptivo, sin agregar entre estaciones)")
for k,t in sorted(agg.items()):
    print(*k,len(t),f"{st.median(t):.1f}",f"{q(t,.9):.1f}",f"{max(t):.1f}",f"{st.mean(t):.1f}",f"llamadas_por_45min_mediana={int(2700/st.median(t))}",sep='\t')
