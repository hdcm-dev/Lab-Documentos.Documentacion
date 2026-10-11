#!/usr/bin/env python3
"""Aplica parches.py en orden a una COPIA de la guía, falla si un ancla no es única,
mide el Δ de palabras por parche (prosa / evidencia y plantillas) y escribe:
guia-parcheada.md, deltas.json y parches-md.txt (el texto de §3 de 03-Parches.md).
Uso: GUIA=<ruta de la guía> python3 -I gen.py"""
import os, json, sys, re
sys.path.insert(0, os.path.dirname(os.path.abspath(__file__)))
from parches import P
guia = os.environ["GUIA"]
t = open(guia, encoding="utf-8").read()

CITA = re.compile(r"^[(\[]*(\[B\d+\])+[)\],.;:]*$|^[(]?E[0-9A]+-[0-9]+[a-z]?[),.;:]*$|^[(]?EA-1[),.;:]*$")
def cubos(texto):
    """Prosa: palabras fuera de bloques de código, de filas [Bnn] del Anexo D y de filas del Anexo E.
    Dentro de la prosa, las citas sueltas ([Bnn], IDs de experimento) se presupuestan como evidencia (C2-36)."""
    pro = evi = 0; dentro = False; anexo = ""
    for l in texto.split("\n"):
        if l.startswith("## "): anexo = l[:12]
        if l.startswith("```"): dentro = not dentro; evi += len(l.split()); continue
        pal = l.split()
        if dentro or (anexo.startswith("## Anexo D.") and l.startswith("| B")) or (anexo.startswith("## Anexo E.") and l.startswith("| E")):
            evi += len(pal); continue
        c = sum(1 for w in pal if CITA.match(w)); evi += c; pro += len(pal) - c
    return pro, evi

p0, e0 = cubos(t); w0 = len(t.split())
deltas = []; fallas = 0
for p in P:
    a = cubos(t)
    for op in p["ops"]:
        if op[0] == "rep":
            _, old, new = op; c = t.count(old)
            if c != 1: print(f"FALLA {p['id']}: ancla con {c} apariciones: {old[:90]!r}"); fallas += 1; continue
            t = t.replace(old, new)
        else:
            _, old, new, n = op; c = t.count(old)
            if c != n: print(f"FALLA {p['id']}: se esperaban {n} y hay {c}: {old!r}"); fallas += 1; continue
            t = t.replace(old, new)
    b = cubos(t)
    deltas.append(dict(id=p["id"], prosa=b[0]-a[0], evidencia=b[1]-a[1]))
open("guia-parcheada.md", "w", encoding="utf-8").write(t)
p1, e1 = cubos(t); w1 = len(t.split())
res = dict(antes=dict(total=w0, prosa=p0, evidencia=e0), despues=dict(total=w1, prosa=p1, evidencia=e1), parches=deltas, fallas=fallas)
json.dump(res, open("deltas.json", "w", encoding="utf-8"), ensure_ascii=False, indent=1)
for d in deltas: print(f"{d['id']}: prosa {d['prosa']:+d}, evidencia y plantillas {d['evidencia']:+d}")
print(f"total wc -w: {w0} -> {w1} ({w1-w0:+d}); prosa {p0} -> {p1} ({p1-p0:+d}); evidencia {e0} -> {e1} ({e1-e0:+d}); fallas={fallas}")

# Texto de los parches para el documento
F = "~~~~"
out = []
for p, d in zip(P, deltas):
    out.append(f"### {p['id']} · {p['titulo']}\n")
    out.append(f"- **Hallazgos**: {', '.join(p['hallazgos'])}.")
    out.append(f"- **Sección**: {p['seccion']}.")
    out.append(f"- **Capa de origen**: {p['capa']}. **Costo**: {p['costo']}. **Reversible**: {'sí' if p['reversible'] else 'no'}. **Δ palabras** (`wc -w`): prosa {d['prosa']:+d}, evidencia y plantillas {d['evidencia']:+d}.")
    out.append(f"- **Verificación**: {p['verificacion']}.\n")
    for i, op in enumerate(p["ops"], 1):
        if op[0] == "rep":
            out.append(f"{i}. Reemplazar\n\n{F}text\n{op[1]}\n{F}\n\npor\n\n{F}text\n{op[2]}\n{F}\n")
        else:
            out.append(f"{i}. Reemplazar las {op[3]} apariciones de\n\n{F}text\n{op[1]}\n{F}\n\npor\n\n{F}text\n{op[2]}\n{F}\n")
open("parches-md.txt", "w", encoding="utf-8").write("\n".join(out))
