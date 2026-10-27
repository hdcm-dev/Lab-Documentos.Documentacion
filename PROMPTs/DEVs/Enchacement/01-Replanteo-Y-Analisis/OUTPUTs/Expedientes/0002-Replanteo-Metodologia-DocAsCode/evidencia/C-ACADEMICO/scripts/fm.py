import sys, re, pathlib, collections
root = pathlib.Path(sys.argv[1])
files = sorted(root.rglob('*.md'))
files = [f for f in files if f.is_file() and '/obj/' not in str(f) and '/bin/' not in str(f)]
withfm = 0; fields = collections.Counter(); vals = {k: collections.Counter() for k in ['doc_type','status','origin','confidence']}
prefixes = collections.Counter()
for f in files:
    t = f.read_text(errors='replace')
    m = re.match(r'---\n(.*?)\n---\n', t, re.S)
    if not m: continue
    withfm += 1
    for line in m.group(1).splitlines():
        mm = re.match(r'([A-Za-z_]+):\s*(.*)', line)
        if not mm: continue
        k, v = mm.group(1), mm.group(2).strip()
        fields[k] += 1
        if k in vals: vals[k][v.split('#')[0].strip()[:40]] += 1
        if k == 'doc_id':
            p = re.match(r'([A-Za-z]+[-_])', v)
            prefixes[p.group(1) if p else v[:12]] += 1
print(f'archivos .md: {len(files)}; con frontmatter: {withfm}')
print('campos (presencia):', ', '.join(f'{k}={n}' for k,n in fields.most_common(16)))
for k,c in vals.items():
    print(f'{k}: {len(c)} valores distintos ->', '; '.join(f'{v!r}:{n}' for v,n in c.most_common(12)))
print('prefijos de doc_id:', ', '.join(f'{k}{n}' if False else f'{k}={n}' for k,n in prefixes.most_common(15)))
