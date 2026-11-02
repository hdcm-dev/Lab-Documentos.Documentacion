#!/usr/bin/env python3
"""Sondeo E1 del Ollama propio en contenedor (estación 1, estación de laboratorio de 4 núcleos), 2026-10-28.

Uso:  OLLAMA_ENDPOINT=... python3 -I sondeo.py <paso> [args]
Pasos: info | chat <modelo> | embed <modelo> | tools <modelo> <N> | ps
El endpoint sale SIEMPRE de OLLAMA_ENDPOINT y nunca se imprime (R-PRIV).
"""
import json, os, sys, time, urllib.request, urllib.error

EP = os.environ.get("OLLAMA_ENDPOINT", "http://localhost:11434").rstrip("/")
TIMEOUT = 900


def call(method, path, body=None):
    data = json.dumps(body).encode() if body is not None else None
    req = urllib.request.Request(EP + path, data=data, method=method,
                                 headers={"Content-Type": "application/json"})
    t0 = time.monotonic()
    try:
        with urllib.request.urlopen(req, timeout=TIMEOUT) as r:
            raw = r.read().decode()
            code = r.status
    except urllib.error.HTTPError as e:
        raw, code = e.read().decode(), e.code
    dt = time.monotonic() - t0
    try:
        return code, json.loads(raw), dt
    except json.JSONDecodeError:
        return code, raw, dt


def out(obj):
    print(json.dumps(obj, ensure_ascii=False), flush=True)


def info():
    c, v, _ = call("GET", "/api/version"); out({"paso": "version", "http": c, "resp": v})
    c, t, _ = call("GET", "/api/tags"); out({"paso": "tags", "http": c, "resp": t})
    for m in t.get("models", []):
        c, s, _ = call("POST", "/api/show", {"model": m["name"]})
        mi = s.get("model_info", {}) if isinstance(s, dict) else {}
        arch = mi.get("general.architecture", "")
        out({"paso": "show", "modelo": m["name"], "digest": m.get("digest"),
             "size": m.get("size"), "details": s.get("details"),
             "capabilities": s.get("capabilities"),
             "parameters": s.get("parameters"),
             "general.parameter_count": mi.get("general.parameter_count"),
             "context_length": mi.get(f"{arch}.context_length"),
             "embedding_length": mi.get(f"{arch}.embedding_length"),
             "architecture": arch})


def ps():
    c, p, _ = call("GET", "/api/ps"); out({"paso": "ps", "http": c, "resp": p})


PROMPT_CHAT = ("En dos oraciones: ¿para qué sirve una encuesta de movilidad urbana "
               "que registra el medio de transporte que usa cada persona?")


def chat(model):
    body = {"model": model, "stream": False, "messages": [{"role": "user", "content": PROMPT_CHAT}],
            "options": {"temperature": 0, "num_predict": 200}}
    if model.startswith("qwen3.5"):
        body["think"] = False
    c, r, dt = call("POST", "/api/chat", body)
    if c != 200:
        out({"paso": "chat", "modelo": model, "http": c, "resp": r, "wall_s": round(dt, 2)}); return
    ns = 1e9
    out({"paso": "chat", "modelo": model, "http": c, "request": body, "wall_s": round(dt, 2),
         "load_s": round(r.get("load_duration", 0) / ns, 2),
         "total_s": round(r.get("total_duration", 0) / ns, 2),
         "prompt_eval_count": r.get("prompt_eval_count"),
         "prompt_eval_s": round(r.get("prompt_eval_duration", 0) / ns, 2),
         "eval_count": r.get("eval_count"),
         "eval_s": round(r.get("eval_duration", 0) / ns, 2),
         "eval_tok_s": round(r["eval_count"] / (r["eval_duration"] / ns), 2) if r.get("eval_duration") else None,
         "done_reason": r.get("done_reason"),
         "thinking": bool(r.get("message", {}).get("thinking")),
         "content": r.get("message", {}).get("content")})


def embed(model):
    textos = ["Voy al trabajo en bicicleta todos los días.", "Uso el colectivo algunos días por semana."]
    c, r, dt = call("POST", "/api/embed", {"model": model, "input": textos})
    if c != 200:
        out({"paso": "embed", "via": "/api/embed", "modelo": model, "http": c, "resp": r}); return
    e = r["embeddings"]
    out({"paso": "embed", "via": "/api/embed", "modelo": model, "http": c, "input": textos,
         "n_vectores": len(e), "dimension": len(e[0]), "wall_s": round(dt, 2),
         "load_s": round(r.get("load_duration", 0) / 1e9, 2),
         "total_s": round(r.get("total_duration", 0) / 1e9, 2),
         "prompt_eval_count": r.get("prompt_eval_count"), "primeros_3": e[0][:3]})
    c, r, dt = call("POST", "/api/embed", {"model": model, "input": textos[0]})
    out({"paso": "embed", "via": "/api/embed (caliente, 1 texto)", "modelo": model, "http": c,
         "wall_s": round(dt, 2), "total_s": round(r.get("total_duration", 0) / 1e9, 2) if isinstance(r, dict) else None})
    c, r, dt = call("POST", "/v1/embeddings", {"model": model, "input": textos[0]})
    dim = len(r["data"][0]["embedding"]) if c == 200 else None
    out({"paso": "embed", "via": "/v1/embeddings", "modelo": model, "http": c, "dimension": dim,
         "wall_s": round(dt, 2), "error": None if c == 200 else r})


MEDIOS = ["colectivo", "auto", "bicicleta", "moto", "caminata", "tren"]
TOOL = {"type": "function", "function": {
    "name": "contar_respuestas_por_medio",
    "description": "Devuelve cuántas respuestas de la encuesta de Movilidad Urbana declararon un medio de transporte.",
    "parameters": {"type": "object", "properties": {
        "medio": {"type": "string", "enum": MEDIOS,
                  "description": "Clave del medio de transporte de la encuesta."}},
        "required": ["medio"]}}}
# Variante por entorno (SONDEO_VARIANTE): "bici" (principal) o "apie" (sinónimo que hay que mapear a la clave).
VARIANTES = {
    "bici": ("¿Cuántas respuestas de la encuesta de Movilidad Urbana dicen que se viaja en bicicleta?", "bicicleta"),
    "apie": ("¿Cuánta gente contestó en la encuesta de Movilidad Urbana que va a pie?", "caminata"),
}
PEDIDO, ESPERADO = VARIANTES[os.environ.get("SONDEO_VARIANTE", "bici")]
# SONDEO_RAZONAR=1 deja el razonamiento de qwen3.5 en su valor por defecto (encendido).
RAZONAR = os.environ.get("SONDEO_RAZONAR") == "1"
TEMP_TOOLS = 0.7


def tools(model, n):
    ok_n = 0
    for i in range(1, n + 1):
        body = {"model": model, "messages": [
                    {"role": "system", "content": "Respondé usando las herramientas disponibles cuando hagan falta."},
                    {"role": "user", "content": PEDIDO}],
                "tools": [TOOL], "temperature": TEMP_TOOLS, "seed": i, "max_tokens": 300}
        if model.startswith("qwen3.5") and not RAZONAR:
            body["reasoning_effort"] = "none"
        c, r, dt = call("POST", "/v1/chat/completions", body)
        rec = {"paso": "tools", "modelo": model, "corrida": i, "seed": i, "http": c, "wall_s": round(dt, 2)}
        if c != 200:
            rec.update({"ok": False, "motivo": "http", "resp": r}); out(rec); continue
        ch = r["choices"][0]; msg = ch["message"]; tcs = msg.get("tool_calls") or []
        motivo, ok = "", False
        if len(tcs) != 1:
            motivo = f"tool_calls={len(tcs)}"
        else:
            f = tcs[0]["function"]
            try:
                a = json.loads(f["arguments"]) if isinstance(f["arguments"], str) else f["arguments"]
            except json.JSONDecodeError:
                a = None
            if f["name"] != TOOL["function"]["name"]:
                motivo = "nombre"
            elif not isinstance(a, dict) or a.get("medio") not in MEDIOS:
                motivo = "argumento fuera del enum"
            elif a["medio"] != ESPERADO:
                motivo = "medio equivocado"
            else:
                ok = True
        ok_n += ok
        rec.update({"ok": ok, "motivo": motivo, "finish": ch.get("finish_reason"),
                    "tool_calls": [t["function"] for t in tcs], "content": msg.get("content"),
                    "reasoning": bool(msg.get("reasoning")), "usage": r.get("usage")})
        out(rec)
    out({"paso": "tools-resumen", "modelo": model, "N": n, "exitos": ok_n, "tasa": ok_n / n,
         "temperature": TEMP_TOOLS, "seeds": f"1..{n}", "pedido": PEDIDO, "esperado": ESPERADO, "razonamiento_por_defecto": RAZONAR, "tool": TOOL})


if __name__ == "__main__":
    p = sys.argv[1]
    if p == "info": info()
    elif p == "ps": ps()
    elif p == "chat": chat(sys.argv[2])
    elif p == "embed": embed(sys.argv[2])
    elif p == "tools": tools(sys.argv[2], int(sys.argv[3]))
