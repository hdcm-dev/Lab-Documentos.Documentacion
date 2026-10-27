import re,sys
t=open(sys.argv[1],errors='replace').read()
refs=re.findall(r'^<a id="(ref-[^"]+)"></a>(.*)$',t,re.M)
bad=[]
for rid,body in refs:
    probs=[]
    if not re.search(r'\((\d{4}[a-z]?|s\. f\.)(,[^)]*)?\)',body): probs.append('sin año o s. f.')
    if not re.search(r'\*[^*]+\*',body): probs.append('sin título en cursiva')
    urls=re.findall(r'https?://\S+',body)
    if urls and not re.search(r'consultad[oa]s? el \d{4}-\d{2}-\d{2}',body): probs.append('URL sin fecha de consulta')
    if probs: bad.append((rid,probs))
cited=set(re.findall(r'\]\(#(ref-[^)]+)\)',t)); declared=set(r for r,_ in refs)
print(f'referencias: {len(refs)}; con algún defecto de formato: {len(bad)}')
for r,p in bad: print('  ',r,'->',', '.join(p))
print(f'citadas en el texto: {len(cited)}; citadas sin entrada: {sorted(cited-declared)}; entradas nunca citadas: {len(declared-cited)} {sorted(declared-cited)[:8]}')
