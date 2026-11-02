#!/usr/bin/env python3
# O5 (ciclo 1, 2026-10-28): ¿sobrevive la caché de prefijo de un contexto fijo largo si entre medio
# llega otro pedido distinto? (OLLAMA_NUM_PARALLEL=1). Endpoint sólo por OLLAMA_ENDPOINT (R-PRIV).
import json, os, time, urllib.request
EP = os.environ["OLLAMA_ENDPOINT"].rstrip("/")
def chat(content, n=8):
    body = {"model": "qwen3.5:4b", "stream": False, "think": False,
            "messages": [{"role": "system", "content": SIS}, {"role": "user", "content": content}],
            "options": {"temperature": 0, "seed": 1, "num_predict": n, "num_ctx": 4096}}
    t = time.time()
    req = urllib.request.Request(EP + "/api/chat", json.dumps(body).encode(), {"Content-Type": "application/json"})
    with urllib.request.urlopen(req, timeout=900) as r: d = json.load(r)
    return {"prompt_eval_count": d.get("prompt_eval_count"), "prompt_eval_s": round(d.get("prompt_eval_duration", 0) / 1e9, 2), "pared_s": round(time.time() - t, 2)}
def out(**k): print(json.dumps(k, ensure_ascii=False), flush=True)
frase = "Requisito de Movilidad Urbana: cada localidad tiene nombre, provincia, código postal de cuatro dígitos y habitantes mayor o igual a uno. "
SIS_LARGO = "Sos la ayuda de Movilidad Urbana. Contexto fijo:\n" + frase * 50
OTRO = "Sos un extractor de localidades. Devolvé sólo JSON."
out(paso="inicio", fecha=time.strftime("%Y-%m-%dT%H:%M:%S%z"), caracteres_sistema=len(SIS_LARGO))
SIS = SIS_LARGO; out(paso="ayuda-1 (frío)", **chat("¿Qué requisito tiene el código postal?"))
SIS = SIS_LARGO; out(paso="ayuda-2 (mismo prefijo, otra pregunta)", **chat("¿Y los habitantes?"))
SIS = OTRO;      out(paso="pedido intercalado distinto", **chat("Agregá Bella Vista, Corrientes, CP 3432, 39000 habitantes"))
SIS = SIS_LARGO; out(paso="ayuda-3 (después del intercalado)", **chat("¿Qué requisito tiene el nombre?"))
out(paso="fin", fecha=time.strftime("%Y-%m-%dT%H:%M:%S%z"))
