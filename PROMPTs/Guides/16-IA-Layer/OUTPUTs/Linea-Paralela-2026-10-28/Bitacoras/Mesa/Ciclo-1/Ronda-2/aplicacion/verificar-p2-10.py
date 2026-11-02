# Verificación de P2-10 (ronda 2): pares por semilla sobre la salida cruda de la comparación 2b/4b, y Wilson 95 %.
# Uso: python3 -I verificar-p2-10.py <03-comparacion.jsonl>
import json, math, sys
rows = [json.loads(l) for l in open(sys.argv[1], encoding="utf-8")]
d = {}
for r in rows:
    if "pedido" in r: d[(r["pedido"], r["modelo"], r["seed"])] = r["falla"]
def wilson(k, n, z=1.96):
    p = k / n; c = (p + z*z/(2*n)) / (1 + z*z/n); h = z*math.sqrt(p*(1-p)/n + z*z/(4*n*n)) / (1 + z*z/n)
    return max(0, c - h), min(1, c + h)
for ped in sorted({k[0] for k in d}):
    s = sorted({k[2] for k in d if k[0] == ped})
    a = [d.get((ped, "qwen3.5:2b", x)) for x in s]; b = [d.get((ped, "qwen3.5:4b", x)) for x in s]
    pares = [(x, y) for x, y in zip(a, b) if x is not None and y is not None]
    k2 = sum(x for x, _ in pares); k4 = sum(y for _, y in pares); n = len(pares)
    solo2 = sum(1 for x, y in pares if x and not y); solo4 = sum(1 for x, y in pares if y and not x)
    w2 = wilson(k2, n); w4 = wilson(k4, n)
    print(f"{ped}: n={n} fallas 2b={k2} [{w2[0]:.2f}; {w2[1]:.2f}] 4b={k4} [{w4[0]:.2f}; {w4[1]:.2f}] discordantes={solo2+solo4} (sólo 2b {solo2}, sólo 4b {solo4})  R-LLM-3e: {'difiere' if max(solo2, solo4) >= 6 and min(solo2, solo4) == 0 else 'no separado con este N'}")
