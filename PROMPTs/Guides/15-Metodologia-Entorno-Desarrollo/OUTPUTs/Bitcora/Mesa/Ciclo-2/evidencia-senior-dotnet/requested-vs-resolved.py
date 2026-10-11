import json,sys
bad=0
for tfm,deps in json.load(open(sys.argv[1]))["dependencies"].items():
    for n,d in deps.items():
        if d.get("type") in ("Direct","CentralTransitive") and "requested" in d:
            lo=d["requested"].strip("[(").split(",")[0].strip(" )]")
            if lo!=d["resolved"]:
                bad=1; print(f"lock: {n} pide {d['requested']} y resolvió {d['resolved']} ({tfm})")
print("requested=resolved: OK" if not bad else "requested≠resolved: REVISAR"); sys.exit(bad)
