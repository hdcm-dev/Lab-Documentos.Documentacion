# Tabla única de cifras de la estación de laboratorio (Parche P-21, ciclo 1, 2026-10-28).
# Se recalcula desde los .jsonl crudos; no llama al modelo. Uso (desde Bitacoras/):
#   python3 -I Sondeo-Evidencia/2026-10-28/cifras.py > Sondeo-Evidencia/2026-10-28/cifras-2026-10-28.md
# Rótulo de toda cifra (RV-01): medido en la estación de laboratorio (CPU de 4 núcleos sin GPU;
# contenedor limitado a 4 CPU / 5 GB; Ollama 0.40.11), 2026-10-28. Pared = segundos de reloj por llamada HTTP.
import json, statistics as st, pathlib
FUENTES = [
    "Sondeo-Evidencia/2026-10-28/salidas/02-chat.jsonl",
    "Sondeo-Evidencia/2026-10-28/salidas/03-embed.jsonl",
    "Sondeo-Evidencia/2026-10-28/salidas/04-tools.jsonl",
    "Sondeo-Evidencia/2026-10-28/salidas/05-tools-apie.jsonl",
    "Sondeo-Evidencia/2026-10-28/salidas/06-tools-razonando.jsonl",
    "Integracion-Evidencia/C-operacion-demo/X2-escrituras-qwen3.5-4b.jsonl",
    "Integracion-Evidencia/C-operacion-demo/X3-ventana-qwen2.5-0.5b.jsonl",
    "Mesa/Ciclo-1/evidencia-experto-ia/salidas/s2-tokenizador.jsonl",
    "Mesa/Ciclo-1/evidencia-experto-ia/salidas/s3-truncado-qwen3.5-4b.jsonl",
    "Mesa/Ciclo-1/evidencia-experto-ia/salidas/s4-cache-prefijo-qwen3.5-4b.jsonl",
    "Mesa/Ciclo-1/evidencia-experto-ia/salidas/s5-presupuesto-prompt-qwen3.5-4b.jsonl",
    "Mesa/Ciclo-1/evidencia-CAT-operacion-entrega-rendimiento/O3-salida.jsonl",
    "Mesa/Ciclo-1/evidencia-CAT-operacion-entrega-rendimiento/O5-salida.jsonl",
]
MODELO_POR_ARCHIVO = {"Mesa/Ciclo-1/evidencia-CAT-operacion-entrega-rendimiento/O5-salida.jsonl": "qwen3.5:4b"}  # O5-sonda-desalojo.py l. 7
DIGEST = {}  # modelo -> digest corto, de /api/tags del sondeo
for l in open("Sondeo-Evidencia/2026-10-28/salidas/01-info.jsonl", encoding="utf-8"):
    d = json.loads(l)
    if d.get("paso") == "tags":
        for m in d["resp"]["models"]: DIGEST[m["name"]] = m["digest"][:12]
def num(d, *ks):
    for k in ks:
        v = d
        for p in k.split("."):
            v = v.get(p) if isinstance(v, dict) else None
        if isinstance(v, (int, float)): return v
    return None
def seg(d, s, ns):
    v = num(d, s);  return v if v is not None else (num(d, ns) / 1e9 if num(d, ns) is not None else None)
grupos = {}
for f in FUENTES:
    for i, l in enumerate(open(f, encoding="utf-8"), 1):
        try: d = json.loads(l)
        except Exception: continue
        modelo = d.get("modelo") or MODELO_POR_ARCHIVO.get(f)
        pared = num(d, "wall_s", "pared_s")
        if not modelo or pared is None: continue
        op = d.get("paso") or d.get("sonda") or "?"
        sub = d.get("via") or d.get("caso") or d.get("pedido") or ""
        sub = str(sub).split("-seed")[0]
        carga = seg(d, "load_s", "load_duration")
        estado = "frío" if (carga or 0) > 1 else ("caliente" if carga is not None else "s/d")
        if "frio" in sub.lower() or "frío" in sub.lower(): estado = "frío"
        pt = num(d, "prompt_eval_count", "usage.prompt_tokens", "usage.input_tokens")
        ot = num(d, "eval_count", "usage.completion_tokens", "usage.output_tokens")
        pes = seg(d, "prompt_eval_s", "prompt_eval_duration"); es = seg(d, "eval_s", "eval_duration")
        g = grupos.setdefault((f, op, sub, modelo, estado), {"lineas": [], "pared": [], "pt": [], "ot": [], "lec": [], "gen": [], "cache": []})
        g["lineas"].append(i); g["pared"].append(pared)
        if pt is not None: g["pt"].append(pt)
        if ot is not None: g["ot"].append(ot)
        ca = num(d, "prompt_eval_cached_count", "usage.prompt_tokens_details.cached_tokens")
        if ca is not None: g["cache"].append(ca)
        if pt and pes and pes > 1: g["lec"].append(pt / pes)  # lectura real: más de 1 s de evaluación del prompt
        if ot and es: g["gen"].append(ot / es)
        elif num(d, "eval_tok_s"): g["gen"].append(num(d, "eval_tok_s"))
def med(xs, fmt="{:.0f}"): return fmt.format(st.median(xs)) if xs else "—"
def rng(xs): return f"{min(xs):.2f}–{max(xs):.2f}" if len(xs) > 1 else (f"{xs[0]:.2f}" if xs else "—")
print("| Fuente (archivo: líneas) | Operación | Modelo@digest | N | Frío/caliente | Tokens de prompt (mediana) | Tokens de salida (mediana) | Tokens en caché (mediana) | Pared s (mediana; rango) | tok/s lectura (mediana) | tok/s generación (mediana) | Suma de pared s |")
print("|---|---|---|---|---|---|---|---|---|---|---|---|")
for (f, op, sub, modelo, estado), g in grupos.items():
    ls = g["lineas"]; lin = f"{ls[0]}–{ls[-1]}" if len(ls) > 1 else f"{ls[0]}"
    print(f"| `{f}`: {lin} | {op}{(' / ' + sub) if sub else ''} | `{modelo}@{DIGEST.get(modelo, 's/d')}` | {len(ls)} | {estado} | {med(g['pt'])} | {med(g['ot'])} | {med(g['cache'])} | {med(g['pared'], '{:.2f}')}; {rng(g['pared'])} | {med(g['lec'], '{:.1f}')} | {med(g['gen'], '{:.1f}')} | {sum(g['pared']):.2f} |")
print("\nLa lectura del prompt (tok/s) se calcula sólo en llamadas con más de 1 s de evaluación del prompt; las repeticiones servidas desde la caché no cuentan como lectura.")
print("\nLímites del contenedor: 4 CPU / 5 GB (X4). Rótulo: medido en la estación de laboratorio (CPU de 4 núcleos sin GPU; contenedor limitado a 4 CPU / 5 GB; Ollama 0.40.11), 2026-10-28.")
