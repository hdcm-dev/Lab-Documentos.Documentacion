#!/usr/bin/env python3
"""CAT-formal (2026-10-28): ¿«límite = contexto/2 + 2» (R-C08, de X3 con 2 puntos) predice un tercer punto?
Mismo corpus sintético y mismo modelo que X3 (X3-ventana.py). El endpoint sale de OLLAMA_ENDPOINT y no se imprime (R-PRIV).
Predicción escrita ANTES de correr: num_ctx 6144 → 3074; num_ctx 4096 con num_predict 64 → 2050 si el límite no depende de num_predict."""
import json, os, sys, time, urllib.request
EP = os.environ["OLLAMA_ENDPOINT"].rstrip("/")
def call(path, body=None):
    req = urllib.request.Request(EP + path, data=json.dumps(body).encode() if body else None,
                                 method="POST" if body else "GET", headers={"Content-Type": "application/json"})
    t0 = time.monotonic()
    with urllib.request.urlopen(req, timeout=900) as r:
        return json.loads(r.read().decode()), time.monotonic() - t0
modelo = sys.argv[1]
lineas = [f"Respuesta sintética {i}: la persona {i} viaja en colectivo {i % 7 + 1} días por semana para ir a estudiar." for i in range(1, 321)]
prompt = "Corpus sintético escrito para esta prueba.\n" + "\n".join(lineas) + "\n¿Qué medio aparece en la respuesta sintética 1? Contestá con una palabra."
for etiqueta, opciones, pred in [("num_ctx-6144", {"temperature": 0, "num_predict": 8, "num_ctx": 6144}, 3074),
                                 ("num_ctx-4096-num_predict-64", {"temperature": 0, "num_predict": 64, "num_ctx": 4096}, 2050)]:
    r, dt = call("/api/generate", {"model": modelo, "prompt": prompt, "stream": False, "options": opciones})
    ps, _ = call("/api/ps")
    cargado = [{"modelo": m.get("name"), "context_length": m.get("context_length")} for m in ps.get("models", [])]
    print(json.dumps({"caso": etiqueta, "modelo": modelo, "opciones": opciones, "prediccion_ctx/2+2": pred,
                      "prompt_eval_count": r.get("prompt_eval_count"), "eval_count": r.get("eval_count"),
                      "done_reason": r.get("done_reason"), "respuesta": r.get("response"),
                      "ps": cargado, "pared_s": round(dt, 2)}, ensure_ascii=False), flush=True)
v, _ = call("/api/version"); print(json.dumps({"ollama_version": v.get("version")}))
