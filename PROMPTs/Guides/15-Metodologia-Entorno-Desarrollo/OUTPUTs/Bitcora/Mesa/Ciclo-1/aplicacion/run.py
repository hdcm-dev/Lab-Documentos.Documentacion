import sys
exec(open("fw.py", encoding="utf-8").read())
for p in sys.argv[1:]:
    exec(open(p, encoding="utf-8").read())
fails = [x for x in LOG if not x[2]]
for x in fails: print("FALLA", x)
print("ops", len(LOG), "fallas", len(fails))
open(SP + "/ap/out.md", "w", encoding="utf-8").write(G["S"])
import json; json.dump(LOG, open(SP + "/ap/log.json", "w"), ensure_ascii=False, indent=0)
