import re,sys
L=open(sys.argv[1],encoding='utf-8').read().split('\n')
prosa=[];f=False
for i,l in enumerate(L,1):
    if re.match(r'^\s*(```|~~~)',l): f=not f; continue
    if f or (i<15): continue
    s=re.sub(r'`[^`]*`','',l); s=re.sub(r'<!--.*?-->','',s); s=re.sub(r'\]\([^)]*\)',']',s); s=re.sub(r'https?://\S+','',s)
    prosa.append((i,s))
R={
 'HE-01 comillas rectas en prosa':r'"',
 'HE-04 fechas dd/mm/aaaa':r'\b\d{1,2}/\d{1,2}/\d{2,4}\b',
 'HE-05 miles con coma':r'\b\d{1,3},\d{3}\b',
 'HE-07 e.g./i.e.':r'\b(e\.g\.|i\.e\.)',
 'HE-08 guion suelto como inciso':r'\S - \S',
 'HE-11 marcas delta':r'Historia \(hasta|antes era|versión anterior|era ApiWeb',
}
for k,p in R.items():
    hits=[i for i,s in prosa if re.search(p,s) and not (k.startswith('HE-01') and '<a id=' in s)]
    print(f'{k}\t{len(hits)}\t{hits[:6]}')
tc=[i for i,s in prosa if re.match(r'^#{1,4} ',s) and len(re.findall(r'\b[A-ZÁÉÍÓÚ][a-záéíóú]{2,}',re.sub(r'^#+ \S+ ','',s)))>=3]
print(f'HE-06 encabezados con >=3 palabras capitalizadas\t{len(tc)}\t{tc[:6]}')
ref=[i for i,s in prosa if re.search(r'\[REF-\d+\]',s)]
print(f'HE-10 líneas con [REF-n] (informativo)\t{len(ref)}')
