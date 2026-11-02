#!/usr/bin/env python3
# PC-06 (mesa ciclo 1, ronda 2, guía 16, 2026-10-28). R-LLM.
# Pregunta: sin num_ctx, ¿Ollama reutiliza el contexto con que quedó cargado el modelo (api/ps)?
# Criterio escrito ANTES de correr:
#   H-reuso:  paso 3 (sin num_ctx, modelo cargado con 8192) da prompt_eval_count ≈ el del paso 2 (sin truncar),
#             api/ps sigue en 8192 y load_duration es chico (no recarga).
#   H-recarga: paso 3 da ≈ ctx_defecto/2 + 2 (truncado como en el paso 1), api/ps vuelve al contexto por defecto
#             y load_duration es grande (recargó).
# Cada paso usa un prompt con un encabezado propio (serie, paso) para que la caché de prefijo no se mezcle con la medición.
# Endpoint sólo por OLLAMA_ENDPOINT; nunca se imprime (R-PRIV).
import json, os, sys, time, urllib.request
EP = os.environ["OLLAMA_ENDPOINT"].rstrip("/")
MODELO = sys.argv[1]; N = int(sys.argv[2]); LINEAS = int(sys.argv[3])  # LINEAS=0 → prompt corto (sólo api/ps)
def http(ruta, body=None, t=900):
    req = urllib.request.Request(EP + ruta, json.dumps(body).encode() if body is not None else None, {"Content-Type": "application/json"})
    with urllib.request.urlopen(req, timeout=t) as r: return json.load(r)
def ps():
    return [{"modelo": m["name"], "context_length": m.get("context_length")} for m in http("/api/ps").get("models", [])]
def ctx_de(modelo):
    for m in ps():
        if m["modelo"] == modelo: return m["context_length"]
    return None
def descargar():
    http("/api/generate", {"model": MODELO, "keep_alive": 0})
    for _ in range(60):
        if ctx_de(MODELO) is None: return True
        time.sleep(1)
    return False
def prompt(serie, paso):
    cab = f"Planilla {serie}-{paso} de Movilidad Urbana.\n"
    if LINEAS == 0: return cab + "Respondé sólo: ok"
    lin = [f"Localidad {i}: código postal {3000 + i}, provincia Corrientes, habitantes {1000 + i * 7}." for i in range(1, LINEAS + 1)]
    return cab + "\n".join(lin) + "\n¿Cuál es el código postal de la Localidad 1? Respondé sólo el número."
def chat(serie, paso, num_ctx):
    opts = {"temperature": 0, "seed": 1, "num_predict": 8}
    if num_ctx: opts["num_ctx"] = num_ctx
    body = {"model": MODELO, "stream": False, "think": False, "messages": [{"role": "user", "content": prompt(serie, paso)}], "options": opts}
    t = time.time(); d = http("/api/chat", body)
    return {"num_ctx_pedido": num_ctx, "prompt_eval_count": d.get("prompt_eval_count"), "prompt_eval_cached_count": d.get("prompt_eval_cached_count"),
            "load_s": round(d.get("load_duration", 0) / 1e9, 2), "prompt_eval_s": round(d.get("prompt_eval_duration", 0) / 1e9, 2),
            "pared_s": round(time.time() - t, 2), "done_reason": d.get("done_reason"), "respuesta": d.get("message", {}).get("content", "").strip()[:20],
            "ps_context_length": ctx_de(MODELO)}
def out(**k): print(json.dumps(k, ensure_ascii=False), flush=True)
v = http("/api/version").get("version")
dig = next((m["digest"][:12] for m in http("/api/tags")["models"] if m["name"] == MODELO), None)
out(paso="inicio", fecha=time.strftime("%Y-%m-%dT%H:%M:%S%z"), ollama=v, modelo=MODELO, digest=dig, N=N, lineas=LINEAS,
    caracteres_prompt=len(prompt(0, 0)), opciones="temperature 0, seed 1, num_predict 8, think false", ps_inicial=ps())
for s in range(1, N + 1):
    out(serie=s, paso="0 descargar", descargado=descargar(), ps=ps())
    out(serie=s, paso="1 frío, sin num_ctx", **chat(s, 1, None))
    out(serie=s, paso="2 con num_ctx=8192", **chat(s, 2, 8192))
    out(serie=s, paso="3 sin num_ctx, cargado con 8192", **chat(s, 3, None))
    out(serie=s, paso="4 sin num_ctx otra vez", **chat(s, 4, None))
out(paso="fin", fecha=time.strftime("%Y-%m-%dT%H:%M:%S%z"), ps_final=ps())
