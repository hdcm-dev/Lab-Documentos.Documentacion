import re,sys,unicodedata,collections
p=sys.argv[1]; t=open(p,encoding='utf-8').read()
lines=t.split('\n')
# slugs github
def slug(h):
    h=h.strip().lower()
    h=re.sub(r'[^\w\- ]','',h)  # keeps unicode letters
    return h.replace(' ','-')
heads=[];code=False
for l in lines:
    if l.startswith('```'): code=not code; continue
    if not code and re.match(r'^#{1,6} ',l): heads.append(re.sub(r'^#+ ','',l))
cnt=collections.Counter(); slugs=set()
for h in heads:
    s=slug(h)
    if cnt[s]: s2=f"{s}-{cnt[s]}"
    else: s2=s
    cnt[s]+=1; slugs.add(s2)
links=re.findall(r'\]\(#([^)]+)\)',t)
bad=[l for l in links if l not in slugs]
print("anclas internas:",len(links),"rotas:",len(bad)); [print("  ROTA",b) for b in bad]
# REF
used=set(re.findall(r'REF-(\d{3})',t.split('## Anexo D.')[0]))
defined=set(re.findall(r'^\| REF-(\d{3}) ',t,re.M))
print("REF usadas en cuerpo:",len(used),"definidas:",len(defined))
print("  usadas sin definir:",sorted(used-defined)); print("  definidas sin uso:",sorted(defined-used))
# citation format variants
print("citas con coma dentro de corchete [REF-a, REF-b]:",len(re.findall(r'\[REF-\d{3}, REF-\d{3}',t)))
print("citas pegadas ][REF:",len(re.findall(r'\]\[REF-',t)), " separadas '] [REF':",len(re.findall(r'\] \[REF-',t)))
# consulta column variants
cons=collections.Counter()
for m in re.finditer(r'^\| REF-\d{3} \|.*\| ([^|]*) \|$',t,re.M):
    cons[m.group(1).split(' ')[0]]+=1
print("primera palabra columna Consulta:",dict(cons))
# version column '—'
for m in re.finditer(r'^\| (REF-\d{3}) \|(.*)$',t,re.M):
    cols=[c.strip() for c in m.group(2).split('|')]
    if len(cols)>=4 and cols[2] in ('—','2025','2023','2024','sin versión','página sin versión','sin versión publicada','rama main'): print("  versión débil",m.group(1),":",cols[2])
    if '<' in cols[1] and ' ' in cols[1].strip('<>').split('>')[0]: print("  URL autolink con espacio",m.group(1))
# labels de estación completos
full4=t.count('CPU de 4 núcleos sin GPU; contenedor limitado a 4 CPU / 5 GB')
fullM=t.count('contenedor limitado a 14 CPU / 34 GiB')
print("rótulo completo 4 núcleos:",full4," rótulo completo más núcleos:",fullM)
# frases repetidas
for f in ['no es control de acceso','El modelo repite la política; la prueba muestra el código','el modelo repite la política; la prueba muestra el código','3400','10,5','50 s por cada 1000','2050','Tengés','13,3','167 s','no-launch-profile','IHttpClientFactory','el catálogo normaliza y las reglas deciden','La forma no es','el modelo propone; la aplicación ejecuta','If you can write a function','por defecto `http://localhost:11434`','Rótulos de estación y estimandos como en §0.5']:
    print(f"{t.lower().count(f.lower()):3d}  {f}")
# Compila en formats
print("'Compila en' total:",len(re.findall(r'Compila en',t)), " en itálica '*Compila en':",len(re.findall(r'\*Compila en',t)))
print("rangos con guion '-' l. a-b:",len(re.findall(r'l\. \d+-\d+',t)), " con '–':",len(re.findall(r'l\. \d+–\d+',t)), " 'líneas a–b':",len(re.findall(r'líneas \d+',t)))
