import sys, re, pathlib
g = pathlib.Path(sys.argv[1]); corpus = pathlib.Path(sys.argv[2])
t = g.read_text()
ids = {}
for f in corpus.rglob('*.md'):
    if not f.is_file(): continue
    m = re.match(r'---\n(.*?)\n---\n', f.read_text(errors='replace'), re.S)
    if m:
        d = re.search(r'^doc_id:\s*(\S+)', m.group(1), re.M)
        if d: ids.setdefault(d.group(1), []).append(f)
rows = []
for n, line in enumerate(t.splitlines(), 1):
    for m in re.finditer(r'\]\(([^)#\s]+\.md)(#[^)]*)?\)', line):
        target = m.group(1)
        if target.startswith('http'): continue
        p = (g.parent / target).resolve()
        rows.append((n, target, p.exists()))
broken = [r for r in rows if not r[2]]
print(f'enlaces internos a .md: {len(rows)}; rotos: {len(broken)}; destinos rotos distintos: {len(set(r[1] for r in broken))}')
for n, target, ok in broken:
    stem = pathlib.Path(target).stem
    guess = {'README':'(índice de la guía)','ADR':'DOC-ADR','SAD':'DOC-SAD','Spec-Driven-Development':'DOC-SDD','Change-Log':'DOC-CHANGELOG'}.get(stem, '?')
    hits = ids.get(guess, [])
    print(f'  L{n}: {target} -> roto | id esperado {guess}: {len(hits)} coincidencia(s) ' + (str(hits[0].relative_to(corpus)) if len(hits)==1 else ''))
