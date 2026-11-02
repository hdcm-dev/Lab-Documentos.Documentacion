#!/usr/bin/env python3
"""PC-10 (AH-02, ciclo 1 ronda 2, 2026-10-28): ¿semillas 1..N de un mismo pedido son ensayos
independientes? Sonda sobre la elección de herramienta de la vía B (EA-6 [R4]), vía /api/chat.

Uso: OLLAMA_ENDPOINT=... python3 -I sonda_pc10.py <modelo> > salida.jsonl
El endpoint sale SIEMPRE de OLLAMA_ENDPOINT y nunca se imprime (R-PRIV).

Criterio de éxito escrito ANTES de correr (R-LLM): una corrida es OK si la respuesta trae
exactamente una llamada y es a buscar_requisitos (mismo criterio que EA-6 [R4]).
Bloques:
  A  K=6 pedidos (todos de requisitos; el P0 es el de EA-6) × semillas 1..8  -> ICC entre pedidos
  B  P0 × semillas 1001..1008 (no consecutivas)                         -> ¿importa el valor de la semilla?
  C  P0 × semillas 1,2,3 repetidas                                       -> ¿misma semilla = misma salida?
"""
import json, os, sys, time, urllib.request, urllib.error

EP = os.environ.get("OLLAMA_ENDPOINT", "http://localhost:11434").rstrip("/")
MODELO = sys.argv[1] if len(sys.argv) > 1 else "qwen3.5:4b"
SISTEMA = "Sos el asistente de Movilidad Urbana. Usá las herramientas; no inventes datos."
TOOLS = [
    {"type": "function", "function": {"name": "buscar_requisitos",
        "description": "Busca los requisitos de carga de localidades y de la encuesta.",
        "parameters": {"type": "object", "properties": {"pregunta": {"type": "string", "description": "La pregunta sobre un requisito"}}, "required": ["pregunta"]}}},
    {"type": "function", "function": {"name": "contar_localidades_por_provincia",
        "description": "Cuenta cuántas localidades cargadas hay en una provincia.",
        "parameters": {"type": "object", "properties": {"provincia": {"type": "string", "description": "Nombre de la provincia"}}, "required": ["provincia"]}}},
]
PEDIDOS = {
    "P0": "¿Cuántos dígitos lleva el código postal de una localidad?",
    "P1": "¿Qué formato tiene que tener el código postal al cargar una localidad?",
    "P2": "¿Cuál es la cantidad mínima de habitantes que acepta una localidad?",
    "P3": "¿Qué requisitos tiene el nombre de una localidad?",
    "P4": "¿Qué medios de transporte se pueden registrar en la encuesta?",
    "P5": "¿Es obligatorio indicar la provincia al cargar una localidad?",
}


def chat(texto, seed):
    body = {"model": MODELO, "stream": False, "think": False, "tools": TOOLS,
            "messages": [{"role": "system", "content": SISTEMA}, {"role": "user", "content": texto}],
            "options": {"temperature": 0.7, "seed": seed, "num_predict": 300}}
    req = urllib.request.Request(EP + "/api/chat", data=json.dumps(body).encode(), method="POST",
                                 headers={"Content-Type": "application/json"})
    t0 = time.monotonic()
    try:
        with urllib.request.urlopen(req, timeout=900) as r:
            code, resp = r.status, json.loads(r.read().decode())
    except urllib.error.HTTPError as e:
        code, resp = e.code, {"error": e.read().decode()}
    return code, resp, round(time.monotonic() - t0, 2)


def out(o):
    print(json.dumps(o, ensure_ascii=False), flush=True)


def corrida(bloque, pid, seed):
    code, r, dt = chat(PEDIDOS[pid], seed)
    msg = r.get("message", {}) if isinstance(r, dict) else {}
    calls = [{"name": c["function"]["name"], "arguments": c["function"].get("arguments")} for c in (msg.get("tool_calls") or [])]
    ok = len(calls) == 1 and calls[0]["name"] == "buscar_requisitos"
    out({"bloque": bloque, "pedido": pid, "seed": seed, "modelo": MODELO, "http": code, "wall_s": dt,
         "ok": ok, "tool_calls": calls, "content": msg.get("content", ""), "done_reason": r.get("done_reason"),
         "prompt_eval_count": r.get("prompt_eval_count"), "eval_count": r.get("eval_count")})


def main():
    with urllib.request.urlopen(EP + "/api/version", timeout=30) as r: v = json.loads(r.read())
    with urllib.request.urlopen(EP + "/api/tags", timeout=30) as r: t = json.loads(r.read())
    dig = [m.get("digest") for m in t.get("models", []) if m["name"] == MODELO]
    out({"bloque": "cabecera", "fecha_utc": time.strftime("%Y-%m-%dT%H:%M:%SZ", time.gmtime()), "ollama": v,
         "modelo": MODELO, "digest": dig, "endpoint": "/api/chat", "options": {"temperature": 0.7, "num_predict": 300},
         "think": False, "sistema": SISTEMA, "pedidos": PEDIDOS})
    for s in range(1, 9):              # A, intercalado por semilla para no confundir orden con pedido
        for pid in PEDIDOS: corrida("A", pid, s)
    for s in range(1001, 1009): corrida("B", "P0", s)
    for s in (1, 2, 3): corrida("C", "P0", s)


main()
