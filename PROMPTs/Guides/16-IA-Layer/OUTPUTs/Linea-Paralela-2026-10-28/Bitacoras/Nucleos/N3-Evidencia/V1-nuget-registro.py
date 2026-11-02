import sys,json,urllib.request,gzip
def get(u):
    r=urllib.request.urlopen(u).read()
    try: r=gzip.decompress(r)
    except: pass
    return json.loads(r)
for id in sys.argv[1:]:
    try: d=get(f"https://api.nuget.org/v3/registration5-gz-semver2/{id}/index.json")
    except Exception as e: print(id,"ERR",e); continue
    items=[]
    for p in d["items"]:
        if "items" not in p: p=get(p["@id"])
        items+=p["items"]
    last=items[-1]["catalogEntry"]
    dep=last.get("deprecation")
    deps=[]
    for g in last.get("dependencyGroups",[]) or []:
        deps.append((g.get("targetFramework"),[(x["id"],x.get("range")) for x in g.get("dependencies",[]) or []]))
    print("==",id,last["version"],last.get("published","")[:10],"listed",last.get("listed"))
    if dep: print("   DEPRECATION",dep.get("reasons"),dep.get("alternatePackage",{}).get("id"))
    print("   deps",deps)
