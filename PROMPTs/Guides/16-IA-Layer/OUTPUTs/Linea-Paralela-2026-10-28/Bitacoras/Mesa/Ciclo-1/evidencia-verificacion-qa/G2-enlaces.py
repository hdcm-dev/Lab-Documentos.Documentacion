import re,sys,os,unicodedata
def slug(h):
    h=h.strip().lower()
    h=re.sub(r'[`*_~]','',h)
    h=re.sub(r'\[([^\]]*)\]\([^)]*\)',r'\1',h)
    h=re.sub(r'[^\w\- ]','',h,flags=re.U)
    return h.replace(' ','-')
def anchors(p):
    a=set();cnt={}
    inside=False
    for l in open(p,encoding='utf-8'):
        if l.startswith('```'): inside=not inside
        if inside: continue
        m=re.match(r'^(#{1,6})\s+(.*)',l)
        if m:
            s=slug(m.group(2)); n=cnt.get(s,0); cnt[s]=n+1
            a.add(s if n==0 else f"{s}-{n}")
    return a
bad=0;tot=0
for f in sys.argv[1:]:
    txt=open(f,encoding='utf-8').read()
    txt=re.sub(r'```.*?```','',txt,flags=re.S)
    for m in re.finditer(r'\]\(([^)\s]+)\)',txt):
        t=m.group(1)
        if t.startswith(('http://','https://','mailto:')): continue
        tot+=1
        path,_,frag=t.partition('#')
        tgt=os.path.normpath(os.path.join(os.path.dirname(f),path)) if path else f
        if path.startswith('/'):
            tgt=os.environ.get('WORKSPACE','.')+path
        if not os.path.exists(tgt):
            bad+=1;print(f"ROTO-ARCHIVO {f} -> {t}");continue
        if frag and tgt.endswith('.md') and os.path.isfile(tgt):
            from urllib.parse import unquote
            if unquote(frag) not in anchors(tgt):
                bad+=1;print(f"ROTO-ANCLA {f} -> {t}")
print(f"enlaces relativos: {tot}; rotos: {bad}")
