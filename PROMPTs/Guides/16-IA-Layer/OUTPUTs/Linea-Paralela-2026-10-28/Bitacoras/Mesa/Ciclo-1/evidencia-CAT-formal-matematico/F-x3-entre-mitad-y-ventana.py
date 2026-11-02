#!/usr/bin/env python3
"""CAT-formal (2026-10-28): ¿un prompt ENTRE contexto/2 y contexto se trunca? Desambigua R-C08 («límite = contexto/2 + 2»).
Lectura A: todo prompt > ctx/2+2 se trunca (la ventana útil es la mitad). Lectura B: sólo el prompt que excede la ventana se recorta, y lo que queda es ctx/2+2.
Mismo corpus que X3 con 120 líneas. Primero num_ctx 16384 (largo real), después num_ctx 4096. Endpoint por OLLAMA_ENDPOINT, no se imprime."""
import json, os, sys, time, urllib.request
EP = os.environ["OLLAMA_ENDPOINT"].rstrip("/")
def call(path, body):
    req = urllib.request.Request(EP + path, data=json.dumps(body).encode(), method="POST", headers={"Content-Type": "application/json"})
    t0 = time.monotonic()
    with urllib.request.urlopen(req, timeout=900) as r:
        return json.loads(r.read().decode()), time.monotonic() - t0
modelo = sys.argv[1]; n = int(sys.argv[2])
lineas = [f"Respuesta sintética {i}: la persona {i} viaja en colectivo {i % 7 + 1} días por semana para ir a estudiar." for i in range(1, n + 1)]
prompt = "Corpus sintético escrito para esta prueba.\n" + "\n".join(lineas) + "\n¿Qué medio aparece en la respuesta sintética 1? Contestá con una palabra."
for ctx in (16384, 4096):
    r, dt = call("/api/generate", {"model": modelo, "prompt": prompt, "stream": False, "options": {"temperature": 0, "num_predict": 8, "num_ctx": ctx}})
    print(json.dumps({"lineas": n, "num_ctx": ctx, "prompt_eval_count": r.get("prompt_eval_count"), "done_reason": r.get("done_reason"), "respuesta": r.get("response"), "pared_s": round(dt, 2)}, ensure_ascii=False), flush=True)
