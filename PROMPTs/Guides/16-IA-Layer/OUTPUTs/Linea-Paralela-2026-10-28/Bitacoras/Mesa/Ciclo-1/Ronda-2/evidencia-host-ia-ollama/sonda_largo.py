#!/usr/bin/env python3
"""PC-07: lectura de un prompt largo (~2000 tokens) y pared por operación, para qwen3.5:4b y qwen3.5:35b-a3b.
Uso: OLLAMA_ENDPOINT=... python3 -I sonda_largo.py <modelo> <N>
Cada corrida cambia la primera línea (número de corrida) para que la caché de prefijo no sirva la lectura.
El endpoint sale de OLLAMA_ENDPOINT y nunca se imprime (R-PRIV)."""
import json, os, sys, time, urllib.request
EP = os.environ["OLLAMA_ENDPOINT"].rstrip("/")
REQ = ["Encuesta, nombre: Al menos 3 caracteres.", "Encuesta, edad: Entre 16 y 110 años.",
       "Encuesta, localidad: Una de las localidades cargadas en el ABM.", "Encuesta, medios: Al menos uno.",
       "Encuesta, distancia: Entre 0 y 500 km por día.", "Encuesta, minutos: Entre 1 y 600 minutos.",
       "Localidad, nombre: Entre 3 y 60 caracteres, único por provincia.", "Localidad, código postal: 4 dígitos.",
       "Localidad, habitantes: Un número entero de 1 en adelante."]
def post(path, body):
    r = urllib.request.Request(EP + path, json.dumps(body).encode(), {"Content-Type": "application/json"}, method="POST")
    t = time.monotonic()
    with urllib.request.urlopen(r, timeout=1800) as f: d = json.loads(f.read())
    return d, time.monotonic() - t
model, n = sys.argv[1], int(sys.argv[2])
for i in range(1, n + 1):
    lineas = [f"Corrida {i} de la sonda de lectura larga."] + [f"Fragmento {k}: {REQ[k % len(REQ)]}" for k in range(160)]
    pregunta = "Con los fragmentos de arriba: ¿cuántos dígitos lleva el código postal de una localidad? Respondé en una oración."
    body = {"model": model, "stream": False, "think": False,
            "messages": [{"role": "user", "content": "\n".join(lineas) + "\n\n" + pregunta}],
            "options": {"temperature": 0, "num_predict": 40, "num_ctx": 8192}}
    d, dt = post("/api/chat", body)
    ns = 1e9
    pe, ped, ec, ed = d.get("prompt_eval_count"), d.get("prompt_eval_duration", 0), d.get("eval_count"), d.get("eval_duration", 0)
    print(json.dumps({"paso": "largo", "modelo": model, "corrida": i, "wall_s": round(dt, 2),
        "load_s": round(d.get("load_duration", 0) / ns, 2), "prompt_eval_count": pe, "prompt_eval_s": round(ped / ns, 2),
        "lectura_tok_s": round(pe / (ped / ns), 1) if ped else None, "eval_count": ec, "eval_s": round(ed / ns, 2),
        "gen_tok_s": round(ec / (ed / ns), 1) if ed else None, "num_ctx": 8192, "content": d.get("message", {}).get("content")},
        ensure_ascii=False), flush=True)
