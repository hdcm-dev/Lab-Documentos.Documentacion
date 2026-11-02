import json,sys,urllib.request,gzip
def get(u):
    r=urllib.request.urlopen(u); d=r.read()
    try: d=gzip.decompress(d)
    except Exception: pass
    return json.loads(d)
for pid in sys.argv[1:]:
    idx=get(f"https://api.nuget.org/v3/registration5-gz-semver2/{pid.lower()}/index.json")
    items=[]
    for p in idx["items"]:
        if "items" not in p: p=get(p["@id"])
        items+=p["items"]
    vs=[(i["catalogEntry"]["version"],i["catalogEntry"].get("published","")[:16]) for i in items]
    first=vs[:3]; ga=[v for v in vs if "-" not in v[0]][:1]
    print(pid,"| primeras:",first,"| primera estable:",ga,"| última:",vs[-1], "| total",len(vs))
