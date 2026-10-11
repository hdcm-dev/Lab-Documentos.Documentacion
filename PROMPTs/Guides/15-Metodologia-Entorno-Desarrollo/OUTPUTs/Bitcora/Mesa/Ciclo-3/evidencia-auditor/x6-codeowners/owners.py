import sys, os, fnmatch
root=sys.argv[1]
rules=[]
for l in open(os.path.join(root,'.github/CODEOWNERS')):
    l=l.strip()
    if not l or l.startswith('#'): continue
    p,*o=l.split(); rules.append((p,o))
def match(p,f):
    if p=='*': return True
    if p.startswith('**/'): return os.path.basename(f)==p[3:] or fnmatch.fnmatch(f,p[3:]) or fnmatch.fnmatch(f,'*/'+p[3:])
    if p.endswith('/'): return f.startswith(p[1:])
    return f==p[1:]
files=[]
for d,_,fs in os.walk(root):
    for x in fs:
        files.append(os.path.relpath(os.path.join(d,x),root))
# archivos que la guia nombra pero el repo de plantillas no trae
files += ['web/package-lock.json','tools/gen/uv.lock','src/App/packages.lock.json','.pre-commit-config.yaml']
for f in sorted(files):
    own=None
    for p,o in rules:
        if match(p,f): own=o
    print(f"{' '.join(own):45} {f}")
