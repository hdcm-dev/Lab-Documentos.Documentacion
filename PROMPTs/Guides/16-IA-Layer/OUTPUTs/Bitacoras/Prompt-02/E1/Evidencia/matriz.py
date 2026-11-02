# Extrae de la guía las afirmaciones sobre ejemplos (bloques «**NN · …**» y E.1/E.7) y les busca artefacto.
import re, os, sys, json, glob
guia, evid = sys.argv[1], sys.argv[2]
L = open(os.path.join(guia, "Dot-Net-Integration-AI-Layer-Guide.md"), encoding="utf-8").read().split("\n")
inicio = [(i, m.group(1)) for i, l in enumerate(L) if (m := re.match(r"\*\*(\d\d) · ", l))]
filas = []
for k, (i, ej) in enumerate(inicio):
    fin = len(L)
    for j in range(i + 1, len(L)):
        if re.match(r"\*\*\d\d · |#{2,4} |<a id=", L[j]): fin = j; break
    for n in range(i, fin):
        for s in re.split(r"(?<=[.;])\s+(?=[A-ZÁÉÍÓÚ«(])", L[n]):
            if re.search(r"Observad|IC95|\b\d+/\d+\b|\bpasa\b|corrida del|no ejecutad|no medid|NO VERIFICADO", s):
                filas.append((n + 1, ej, s.strip(), L[n]))
carpetas = {os.path.basename(d)[:2]: d for d in glob.glob(os.path.join(guia, "Examples", "[0-9][0-9]-*"))}
def artefacto(ej, s):
    d = carpetas.get(ej); rel = os.path.relpath(d, guia) if d else "?"
    est = ""
    try: est = json.load(open(os.path.join(d, "ejemplo.json"), encoding="utf-8")).get("estado", "")
    except Exception: pass
    hist = "Historia" in s or "2026-10-27" in s or "qwen2.5:0.5b" in s
    m = re.search(r"estación (\d)", s)
    if hist:
        hay = [os.path.relpath(p, evid) for p in glob.glob(os.path.join(evid, "R-LLM", ej + "-*")) + glob.glob(os.path.join(evid, os.path.basename(d) if d else "-", "*"))][:2]
        return ("HISTORIA", ", ".join(hay) if hay else "sin registro archivado localizado")
    if "2026-10-29" in s or "2026-10-30" in s or "2026-11-01" in s or m:
        est_n = m.group(1) if m else ("2" if "estación 2" in est else "1" if "estación 1" in est else "?")
        r = glob.glob(os.path.join(evid, "R-LLM-2026-10-28", f"estacion-{est_n}", f"R-{ej}*"))
        if r: return ("VERIFICADO (registro)", os.path.relpath(r[0], evid))
        r = glob.glob(os.path.join(evid, "R-LLM-2026-10-28", "estacion-*", f"R-{ej}*"))
        if r: return ("VERIFICADO (registro, otra estación que la citada)", os.path.relpath(r[0], evid))
        return ("NO VERIFICADO", "sin registro archivado de esa corrida")
    if re.search(r"no ejecutad|no medid", s): return ("NO EJECUTADO (declarado)", rel + "/README.md")
    return ("CÓDIGO (build)", rel + " · `verificar.sh build`")
w = sys.stdout
previo = {}
fake_desde, ultimo = {}, {}
for n, ej, s, linea in filas:
    # una línea «Salida con --fake» o «[guion]» entre el rótulo y la cifra corta la herencia
    corte = any(re.search(r"--fake|\[guion\]", L[x]) for x in range(fake_desde.get(ej, n), n))
    if re.search(r"mismo rótulo", s) and ej in ultimo: previo[ej] = ultimo[ej]
    elif corte and not re.search(r"Observad", s): previo.pop(ej, None)
    fake_desde[ej] = n
    if re.search(r"Observad", s) or ej not in previo:
        marca, art = artefacto(ej, s if not re.search(r"Historia \(hasta", linea) else "Historia " + s)
        if not re.search(r"Observad", s) and marca == "CÓDIGO (build)":
            # antes de cualquier rótulo: salida de --fake si el bloque lo dice, si no, sin rótulo
            pass
        else:
            previo[ej] = (marca, art)
            if re.search(r"Observad", s): ultimo[ej] = (marca, art)
    else:
        marca, art = previo[ej]; marca = marca + " (hereda el rótulo previo)"
    s2 = s.replace("|", "\\|"); s2 = s2 if len(s2) <= 170 else s2[:167] + "…"
    w.write(f"| {n} | {ej} | {s2} | {art} | {marca} |\n")
