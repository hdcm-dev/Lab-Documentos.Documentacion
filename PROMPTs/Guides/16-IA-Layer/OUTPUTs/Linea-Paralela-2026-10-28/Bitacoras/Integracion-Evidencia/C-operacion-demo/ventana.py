#!/usr/bin/env python3
"""X3 C-operacion-demo (2026-10-28): ¿el Ollama propio en contenedor (estación 1, 0.40.11) trunca en silencio sin num_ctx?
Re-verifica N5 §8.3 y N3b X4b.4 en el servidor vigente. Uso: OLLAMA_ENDPOINT=... python3 -I ventana.py <modelo>
El corpus es SINTÉTICO, escrito para esta prueba (rótulo exigido por N6 §1.1.2): frases numeradas sobre la encuesta.
"""
import json, os, sys, time, urllib.request
EP = os.environ.get("OLLAMA_ENDPOINT", "http://localhost:11434").rstrip("/")
def call(path, body=None):
    req = urllib.request.Request(EP + path, data=json.dumps(body).encode() if body else None,
                                 method="POST" if body else "GET", headers={"Content-Type": "application/json"})
    t0 = time.monotonic()
    with urllib.request.urlopen(req, timeout=900) as r:
        return json.loads(r.read().decode()), time.monotonic() - t0
modelo = sys.argv[1]
lineas = [f"Respuesta sintética {i}: la persona {i} viaja en colectivo {i % 7 + 1} días por semana para ir a estudiar." for i in range(1, 321)]
prompt = "Corpus sintético escrito para esta prueba.\n" + "\n".join(lineas) + "\n¿Qué medio aparece en la respuesta sintética 1? Contestá con una palabra."
for etiqueta, opciones in [("sin-num_ctx", {"temperature": 0, "num_predict": 8}),
                           ("num_ctx-8192", {"temperature": 0, "num_predict": 8, "num_ctx": 8192})]:
    r, dt = call("/api/generate", {"model": modelo, "prompt": prompt, "stream": False, "options": opciones})
    ps, _ = call("/api/ps")
    cargado = [{"modelo": m.get("name"), "context_length": m.get("context_length")} for m in ps.get("models", [])]
    print(json.dumps({"caso": etiqueta, "modelo": modelo, "opciones": opciones, "caracteres_prompt": len(prompt),
                      "prompt_eval_count": r.get("prompt_eval_count"), "eval_count": r.get("eval_count"),
                      "done_reason": r.get("done_reason"), "respuesta": r.get("response"),
                      "ps": cargado, "pared_s": round(dt, 2)}, ensure_ascii=False), flush=True)
