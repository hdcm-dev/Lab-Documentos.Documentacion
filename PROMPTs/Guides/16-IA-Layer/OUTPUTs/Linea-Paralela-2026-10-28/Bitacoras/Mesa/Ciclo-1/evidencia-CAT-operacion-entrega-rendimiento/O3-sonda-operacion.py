#!/usr/bin/env python3
# Sonda CAT-OP (ciclo 1, 2026-10-28). Endpoint SOLO por OLLAMA_ENDPOINT (R-PRIV); no se imprime.
# O3a: ¿prompt_eval_count cuenta los tokens reutilizados de la caché de prefijo? (viabilidad de MI-18)
# O3b: velocidad de prompt_eval de qwen3.5:4b con ~1500 tokens (dimensiona timeouts, MI-24/M10)
# O3c: dos pedidos simultáneos con OLLAMA_NUM_PARALLEL=1 (cola en el servidor, M9)
import json, os, sys, time, threading, urllib.request
EP = os.environ["OLLAMA_ENDPOINT"].rstrip("/")
def chat(model, content, num_predict=8, extra=None):
    body = {"model": model, "stream": False, "messages": [{"role": "user", "content": content}],
            "options": {"temperature": 0, "seed": 1, "num_predict": num_predict, "num_ctx": 4096}}
    if model.startswith("qwen3.5"): body["think"] = False
    if extra: body.update(extra)
    t = time.time()
    req = urllib.request.Request(EP + "/api/chat", json.dumps(body).encode(), {"Content-Type": "application/json"})
    with urllib.request.urlopen(req, timeout=900) as r: d = json.load(r)
    w = time.time() - t
    return {k: d.get(k) for k in ("prompt_eval_count", "prompt_eval_duration", "eval_count", "eval_duration", "load_duration", "total_duration", "done_reason")} | {"pared_s": round(w, 2), "t_ini": round(t, 2)}
def out(**k): print(json.dumps(k, ensure_ascii=False), flush=True)
frase = "La encuesta de Movilidad Urbana registra el medio de transporte, el motivo del viaje y la localidad de cada persona. "
largo = frase * 60 + "\nRespondé con una sola palabra: ¿qué medio aparece primero en el texto?"
out(paso="inicio", fecha=time.strftime("%Y-%m-%dT%H:%M:%S%z"), caracteres_prompt_largo=len(largo))
for m in ("qwen2.5:0.5b", "qwen3.5:4b"):
    for i in (1, 2, 3):
        out(paso="O3a/O3b", modelo=m, repeticion=i, **chat(m, largo))
# O3c: secuencial de referencia y luego dos simultáneos (prompts distintos para que no compartan caché)
cortos = ["En una oración: ¿para qué sirve registrar el motivo del viaje en una encuesta de movilidad?",
          "En una oración: ¿para qué sirve registrar la localidad en una encuesta de movilidad?"]
for i, p in enumerate(cortos):
    out(paso="O3c-secuencial", indice=i, **chat("qwen3.5:4b", p + " (secuencial)", num_predict=40))
res = [None, None]
def hilo(i): res[i] = chat("qwen3.5:4b", cortos[i] + " (simultáneo)", num_predict=40)
ths = [threading.Thread(target=hilo, args=(i,)) for i in (0, 1)]
t0 = time.time(); [t.start() for t in ths]; [t.join() for t in ths]
for i, r in enumerate(res):
    out(paso="O3c-simultaneo", indice=i, inicio_relativo_s=round(r["t_ini"] - t0, 2), **r)
out(paso="fin", fecha=time.strftime("%Y-%m-%dT%H:%M:%S%z"))
