# Verificación de las filas de §R.6 que toma P2-10 desde PC-06: load_s por paso y modelo, y truncamiento.
# Uso: python3 -I verificar-pc06.py <PC06-*.jsonl>...
import json, sys
for f in sys.argv[1:]:
    rows = [json.loads(l) for l in open(f, encoding="utf-8")]
    m = rows[0]["modelo"]; pasos = {}
    for r in rows:
        if "load_s" in r: pasos.setdefault(r["paso"], []).append(r)
    for p, rs in sorted(pasos.items()):
        ls = [r["load_s"] for r in rs]; pe = [r.get("prompt_eval_count") for r in rs]
        pv = [r.get("prompt_eval_s") for r in rs]
        print(f"{m} | {p} | N={len(rs)} | load_s {min(ls):.2f}–{max(ls):.2f} | prompt_eval_count {sorted(set(pe))} | prompt_eval_s {min(pv):.1f}–{max(pv):.1f} | done_reason {sorted({r.get('done_reason') for r in rs})} | ps {sorted({r.get('ps_context_length') for r in rs}, key=str)}")
