import sys,json,urllib.request,gzip
def get(u):
    r=urllib.request.urlopen(u,timeout=30); d=r.read()
    try: d=gzip.decompress(d)
    except Exception: pass
    return json.loads(d)
for line in sys.stdin:
    pid,st,pr=line.rstrip('\n').split('\t')
    v=st if st!='—' else pr
    try:
        idx=get(f"https://api.nuget.org/v3/registration5-gz-semver2/{pid.lower()}/index.json")
        found=None
        for page in idx['items']:
            items=page.get('items') or get(page['@id'])['items']
            for it in items:
                if it['catalogEntry']['version'].lower()==v.lower(): found=it['catalogEntry']
        dep=found.get('deprecation') if found else None
        vul=found.get('vulnerabilities') if found else None
        print(f"{pid}\t{v}\tlisted={found.get('listed') if found else '?'}\tpublished={found.get('published','?')[:10] if found else '?'}\tdeprecation={json.dumps(dep.get('reasons')) if dep else 'no'}\tvulns={len(vul) if vul else 0}")
    except Exception as e:
        print(f"{pid}\t{v}\tERROR {e}")
