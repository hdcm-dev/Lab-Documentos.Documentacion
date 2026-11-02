#!/usr/bin/env python3
"""Sondas del experto en IA, mesa ciclo 1 (2026-10-28). Endpoint sólo por OLLAMA_ENDPOINT (R-PRIV: no se imprime).
S1  Embeddings con y sin instrucción de consulta (Qwen3-Embedding es «instruction aware»): repite E-B5
    (mismo catálogo, mismas consultas) agregando el formato del model card: 'Instruct: {tarea}\nQuery:{consulta}'.
    Determinista (embeddings): N = 1 por consulta y variante.
S2  Conteo de tokens del mismo texto con el tokenizador de qwen2.5:0.5b y el de qwen3.5:4b
    (/api/generate, raw=true, num_predict=1 -> prompt_eval_count).
S3  Truncado sin num_ctx con qwen3.5:4b (X3 se midió sólo con qwen2.5:0.5b), con un corpus que DISCRIMINA:
    el dato pedido está sólo en la primera línea.
Uso: python3 -I sonda_experto.py s1|s2|s3
"""
import json, math, os, sys, time, urllib.request
EP = os.environ["OLLAMA_ENDPOINT"].rstrip("/")
def call(path, body=None, timeout=1800):
    req = urllib.request.Request(EP + path, data=json.dumps(body).encode() if body else None,
                                 method="POST" if body else "GET", headers={"Content-Type": "application/json"})
    t0 = time.monotonic()
    with urllib.request.urlopen(req, timeout=timeout) as r:
        return json.loads(r.read().decode()), round(time.monotonic() - t0, 2)
def out(d): print(json.dumps(d, ensure_ascii=False), flush=True)

MEDIOS = [("colectivo", "Colectivo"), ("auto", "Auto particular"), ("bicicleta", "Bicicleta"),
          ("moto", "Moto"), ("caminata", "A pie"), ("tren", "Tren")]
CONSULTAS = [("voy caminando", "caminata"), ("a pata", "caminata"), ("me tomo el bondi", "colectivo"),
             ("en la bici", "bicicleta"), ("en mi coche", "auto"), ("en el ferrocarril", "tren"),
             ("en la moto de mi hermano", "moto"), ("en avión", None)]
TAREAS = {
  "sin-instruccion": None,
  "instr-en": "Given a commuter's informal description of how they travel, retrieve the matching means of transport",
  "instr-es": "Dada la descripción informal de cómo viaja una persona, recuperar el medio de transporte que corresponde",
}
def cos(a, b): return sum(x*y for x, y in zip(a, b)) / (math.sqrt(sum(x*x for x in a)) * math.sqrt(sum(y*y for y in b)))

def s1():
    m = os.environ.get("OLLAMA_EMBEDDING_MODEL", "qwen3-embedding:0.6b")
    docs, _ = call("/api/embed", {"model": m, "input": [f"Medio de transporte: {e}" for _, e in MEDIOS]})
    docs = docs["embeddings"]
    out({"sonda": "s1-inicio", "modelo": m, "dimension": len(docs[0]), "norma_doc0": round(math.sqrt(sum(x*x for x in docs[0])), 4),
         "fecha": time.strftime("%Y-%m-%dT%H:%M:%S%z")})
    for nombre, tarea in TAREAS.items():
        textos = [c if tarea is None else f"Instruct: {tarea}\nQuery:{c}" for c, _ in CONSULTAS]
        qs, _ = call("/api/embed", {"model": m, "input": textos})
        ok = 0; filas = []
        for (c, esp), q in zip(CONSULTAS, qs["embeddings"]):
            orden = sorted(((cos(q, d), MEDIOS[i][0]) for i, d in enumerate(docs)), reverse=True)
            hit = (orden[0][1] == esp) if esp else None
            ok += 1 if hit else 0
            filas.append({"consulta": c, "esperado": esp, "top1": orden[0][1], "s1": round(orden[0][0], 3),
                          "top2": orden[1][1], "s2": round(orden[1][0], 3), "acierto": hit})
        out({"sonda": "s1", "variante": nombre, "aciertos": ok, "de": 7, "filas": filas})

def s2():
    texto = ("Corpus sintético escrito para esta prueba. La localidad debe tener un código postal de cuatro dígitos "
             "y pertenecer a una provincia del catálogo. La encuesta registra el medio de transporte principal, "
             "la frecuencia semanal y el motivo del viaje: trabajo, estudio, salud o recreación. ") * 4
    for m in ["qwen2.5:0.5b", "qwen3.5:4b"]:
        r, dt = call("/api/generate", {"model": m, "prompt": texto, "raw": True, "stream": False,
                                       "options": {"num_predict": 1, "temperature": 0}})
        out({"sonda": "s2", "modelo": m, "caracteres": len(texto), "prompt_eval_count": r.get("prompt_eval_count"),
             "chars_por_token": round(len(texto) / r["prompt_eval_count"], 2), "pared_s": dt})

def s3():
    m = "qwen3.5:4b"
    lineas = ["Respuesta sintética 1: la persona 1 viaja en TREN todos los días."] + \
             [f"Respuesta sintética {i}: la persona {i} viaja en colectivo {i % 7 + 1} días por semana para ir a estudiar." for i in range(2, 241)]
    prompt = ("Corpus sintético escrito para esta prueba.\n" + "\n".join(lineas) +
              "\n¿Qué medio aparece en la respuesta sintética 1? Contestá con una palabra.")
    r, dt = call("/api/generate", {"model": m, "prompt": prompt, "stream": False, "think": False,
                                   "options": {"temperature": 0, "num_predict": 8}})
    ps, _ = call("/api/ps")
    out({"sonda": "s3", "modelo": m, "opciones": "sin num_ctx; think false; temperature 0; num_predict 8",
         "caracteres_prompt": len(prompt), "prompt_eval_count": r.get("prompt_eval_count"),
         "done_reason": r.get("done_reason"), "respuesta": r.get("response"),
         "ps": [{"modelo": x.get("name"), "context_length": x.get("context_length")} for x in ps.get("models", [])],
         "pared_s": dt, "fecha": time.strftime("%Y-%m-%dT%H:%M:%S%z")})

def s4():
    m = "qwen3.5:4b"
    lineas = [f"Respuesta sintética {i}: la persona {i} viaja en colectivo {i % 7 + 1} días por semana." for i in range(1, 61)]
    corpus = "Corpus sintético escrito para esta prueba.\n" + "\n".join(lineas)
    casos = [("A-frio", corpus, "¿Cuántos días viaja la persona 7?"),
             ("B-mismo-prefijo", corpus, "¿Cuántos días viaja la persona 12?"),
             ("C-prefijo-alterado", "X" + corpus, "¿Cuántos días viaja la persona 7?")]
    for etiqueta, pre, preg in casos:
        r, dt = call("/api/chat", {"model": m, "stream": False, "think": False, "keep_alive": "30m",
                                   "messages": [{"role": "system", "content": pre}, {"role": "user", "content": preg + " Contestá con un número."}],
                                   "options": {"temperature": 0, "num_predict": 8, "num_ctx": 4096}})
        out({"sonda": "s4", "caso": etiqueta, "modelo": m, "prompt_eval_count": r.get("prompt_eval_count"),
             "prompt_eval_cached_count": r.get("prompt_eval_cached_count"),
             "prompt_eval_s": round(r.get("prompt_eval_duration", 0) / 1e9, 2), "load_s": round(r.get("load_duration", 0) / 1e9, 2),
             "respuesta": r.get("message", {}).get("content"), "pared_s": dt, "fecha": time.strftime("%Y-%m-%dT%H:%M:%S%z")})

def s5():
    m = "qwen3.5:4b"
    lineas = ["Respuesta sintética 1: la persona 1 viaja en TREN todos los días."] + \
             [f"Respuesta sintética {i}: la persona {i} viaja en colectivo {i % 7 + 1} días por semana." for i in range(2, 121)]
    prompt = ("Corpus sintético escrito para esta prueba.\n" + "\n".join(lineas) +
              "\n¿Qué medio aparece en la respuesta sintética 1? Contestá con una palabra.")
    r, dt = call("/api/generate", {"model": m, "prompt": prompt, "stream": False, "think": False, "keep_alive": "30m",
                                   "options": {"temperature": 0, "num_predict": 8, "num_ctx": 4096}})
    out({"sonda": "s5", "modelo": m, "opciones": "num_ctx 4096; think false; temperature 0; num_predict 8",
         "caracteres_prompt": len(prompt), "prompt_eval_count": r.get("prompt_eval_count"),
         "prompt_eval_s": round(r.get("prompt_eval_duration", 0) / 1e9, 2),
         "done_reason": r.get("done_reason"), "respuesta": r.get("response"), "pared_s": dt, "fecha": time.strftime("%Y-%m-%dT%H:%M:%S%z")})

{"s1": s1, "s2": s2, "s3": s3, "s4": s4, "s5": s5}[sys.argv[1]]()
