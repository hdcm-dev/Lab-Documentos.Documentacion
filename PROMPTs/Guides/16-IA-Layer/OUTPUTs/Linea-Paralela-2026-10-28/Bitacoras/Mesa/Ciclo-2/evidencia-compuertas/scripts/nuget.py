import json,urllib.request,gzip,sys
def get(u):
    r=urllib.request.urlopen(urllib.request.Request(u,headers={'Accept-Encoding':'gzip','User-Agent':'compuertas'}),timeout=60); d=r.read()
    if r.headers.get('Content-Encoding')=='gzip': d=gzip.decompress(d)
    return json.loads(d)
for spec in sys.argv[1:]:
    n,v=spec.split('@'); idx=get(f'https://api.nuget.org/v3/registration5-gz-semver2/{n.lower()}/index.json')
    items=[]
    for p in idx['items']:
        its=p.get('items') or get(p['@id'])['items']; items+=its
    stable=[i['catalogEntry'] for i in items if '-' not in i['catalogEntry']['version'] and i['catalogEntry'].get('listed',True)]
    def key(e): return tuple(int(x) for x in e['version'].split('.')[:4] if x.isdigit())
    last=max(stable,key=key)['version'] if stable else '-'
    e=next((i['catalogEntry'] for i in items if i['catalogEntry']['version'].lower()==v.lower()),None)
    if not e: print(f'{n}\t{v}\tNO EXISTE\tultima={last}'); continue
    print(f"{n}\t{v}\tultima={last}\tpublicada={e.get('published','')[:10]}\tdeprecado={'si' if e.get('deprecation') else 'no'}\tvulns={len(e.get('vulnerabilities') or [])}")
