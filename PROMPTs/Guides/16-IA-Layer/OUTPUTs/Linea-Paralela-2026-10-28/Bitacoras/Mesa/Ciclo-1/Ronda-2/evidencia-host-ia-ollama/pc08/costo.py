#!/usr/bin/env python3
"""PC-08: costo en tiempo del juez (MEAI.Evaluation.Quality 10.11.0, qwen3.5:4b) medido en estación 2 y estimado para estación 1.
Uso (desde esta carpeta): python3 -I costo.py
Modelo de estimación por llamada: pared ≈ tokens_entrada / lectura + tokens_salida / generación.
Tasas de estación 2: medidas en esta consulta (../pc07/01-largo-4b.jsonl y ../sondeo/salidas/02-chat.jsonl).
Tasas de estación 1: Sondeo-Evidencia/2026-10-28/cifras-2026-10-28.md (lectura mediana 19 tok/s, rango 13,2-21,9;
generación 7,4 tok/s en 02-chat l. 3 y 10,7 en O3)."""
import json, statistics as st
J = [json.loads(l) for l in open("eval-{estación-2}.jsonl") if '"paso": "juez"' in l or '"paso":"juez"' in l]
J = [j for j in J if j["paso"] == "juez"]
ev = {}
for j in J: ev.setdefault(j["etiqueta"].split("/")[1], []).append(j)
LI, GI = 108.8, 12.1          # estación 2 4b: lectura mediana (3 corridas, 3503 tok) y generación mediana
H = {"central": (19.0, 7.4), "optimista": (21.9, 10.7), "pesimista": (13.2, 7.4)}
def est(j, l, g): return j["tokens_entrada"] / l + j["tokens_salida"] / g
print("| Evaluador | N | tok entrada (med) | tok salida (med) | pared estación 2 s (med; rango) | modelo estación 2 s (med) | estación 1 estimado s (med, central) | estación 1 rango s |")
print("|---|---|---|---|---|---|---|---|")
for k, js in ev.items():
    p = [j["pared_s"] for j in js]
    print(f"| {k} | {len(js)} | {st.median([j['tokens_entrada'] for j in js]):.0f} | {st.median([j['tokens_salida'] for j in js]):.0f} | "
          f"{st.median(p):.1f}; {min(p):.1f}–{max(p):.1f} | {st.median([est(j, LI, GI) for j in js]):.1f} | "
          f"{st.median([est(j, *H['central']) for j in js]):.0f} | {min(est(j, *H['optimista']) for j in js):.0f}–{max(est(j, *H['pesimista']) for j in js):.0f} |")
tot = sum(j["pared_s"] for j in J)
print(f"\nTotal medido estación 2, {len(J)} llamadas: {tot:.1f} s; media {tot/len(J):.1f} s por evaluación.")
for n, (l, g) in H.items():
    t = sum(est(j, l, g) for j in J); print(f"estación 1 {n} (lectura {l}, gen {g}): {t:.0f} s = {t/60:.1f} min; media {t/len(J):.0f} s por evaluación")
print(f"Ajuste del modelo en estación 2: suma estimada {sum(est(j, LI, GI) for j in J):.0f} s frente a {tot:.0f} s medidos.")
# Diseño de AH-02--01: 10-20 casos x 2 adaptadores x 3 evaluadores x N corridas. Se usa la media por evaluación de
# Relevance, Groundedness y Completeness (los tres que piden pregunta+respuesta+contexto o verdad).
tres = [j for j in J if j["etiqueta"].split("/")[1] in ("Relevance", "Groundedness", "Completeness")]
mi = st.mean(j["pared_s"] for j in tres); mh = st.mean(est(j, *H["central"]) for j in tres)
print(f"\nMedia por evaluación (Relevance, Groundedness, Completeness): estación 2 {mi:.1f} s medido; estación 1 {mh:.0f} s estimado")
for casos in (10, 20):
    for n in (1, 3):
        k = casos * 2 * 3 * n
        print(f"{casos} casos x 2 adaptadores x 3 evaluadores x N={n}: {k} evaluaciones -> estación 2 {k*mi/60:.0f} min; estación 1 {k*mh/60:.0f} min ({k*mh/2700:.1f} turnos de 45 min)")
