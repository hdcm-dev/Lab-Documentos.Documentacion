#!/usr/bin/env python3
"""C1R2 P-36/C1-41: D1, D3, D3-T y D6 con qwen3.5:2b y qwen3.5:4b, intercalado por semilla.
Uso: OLLAMA_ENDPOINT=... python3 -I comparacion.py <N>   (el endpoint nunca se imprime, R-PRIV)
Operacionalización: 00-operacionalizacion-previa.md (escrita antes de correr).
"""
import json, os, sys, time, math, urllib.request
sys.path.insert(0, os.path.dirname(os.path.abspath(__file__)))
import x2  # X2-escrituras.py sin cambios: SISTEMA, TOOLS, call(), clasificar()

EP = x2.EP
MODELOS = ["qwen3.5:2b", "qwen3.5:4b"]
MEDIOS = ["colectivo", "auto", "bicicleta", "moto", "caminata", "tren"]
FRECS = ["diaria", "semanal", "ocasional"]
TEXTO_D3 = "Voy en bondi y a veces en bici, casi todos los días"
USER_D3 = ("Extraé los medios de transporte y la frecuencia. Medios válidos: " + ", ".join(MEDIOS) +
           ". Frecuencias válidas: " + ", ".join(FRECS) + ".\nTexto: " + TEXTO_D3)
ESQUEMA = {"type": "json_schema", "json_schema": {"name": "EncuestaPaso2Propuesta", "strict": True, "schema": {
    "type": "object", "properties": {"Medios": {"type": "array", "items": {"type": "string"}},
                                     "Frecuencia": {"type": "string"}},
    "required": ["Medios", "Frecuencia"], "additionalProperties": False}}}
PEDIDOS = [
    ("D1", x2.PEDIDOS["D1-cp-invalido"], True, None),
    ("D3", USER_D3, False, ESQUEMA),
    ("D3-T", USER_D3, True, ESQUEMA),
    ("D6", x2.PEDIDOS["D6-baja"], True, None),
]

def get(path):
    with urllib.request.urlopen(EP + path, timeout=60) as r:
        return json.loads(r.read().decode())

def ps():
    try:
        return [{"model": m.get("name"), "size": m.get("size"), "size_vram": m.get("size_vram"),
                 "context": m.get("context_length")} for m in get("/api/ps").get("models", [])]
    except Exception as e:
        return {"error": type(e).__name__}

def wilson(k, n, z=1.96):
    if n == 0: return (None, None)
    p = k / n; d = 1 + z*z/n; c = (p + z*z/(2*n)) / d; h = z*math.sqrt(p*(1-p)/n + z*z/(4*n*n)) / d
    return (round(max(0, c-h), 3), round(min(1, c+h), 3))

def clasificar(clave, msg):
    texto = msg.get("content") or ""
    if clave == "D1":
        clase, llamadas = x2.clasificar("D1-cp-invalido", msg)
        if clase.startswith("CORRIGE-cp="):
            cp = clase.split("=", 1)[1]
            return (clase + ("|declarado" if cp and cp in texto else "|SIN-declarar"),
                    not (cp and cp in texto), llamadas, None)
        return clase, False, llamadas, None
    if clave == "D6":
        clase, llamadas = x2.clasificar("D6-baja", msg)
        return clase, clase.startswith("BORRA"), llamadas, None
    # D3 / D3-T
    _, llamadas = x2.clasificar("D2-falta-habitantes", msg)  # sólo para extraer tool_calls
    if llamadas:
        return "sin-propuesta(tool_call)", False, llamadas, None
    try:
        prop = json.loads(texto)
        medios = prop["Medios"]; frec = prop["Frecuencia"]
        assert isinstance(medios, list)
    except Exception:
        return "sin-propuesta(json)", False, llamadas, None
    fuera = [m for m in medios if m not in MEDIOS]
    if fuera:
        return "FUERA-de-catalogo=" + ",".join(map(str, fuera)), True, llamadas, prop
    exacto = sorted(medios) == ["bicicleta", "colectivo"] and frec == "diaria"
    return ("en-catalogo|esperado" if exacto else "en-catalogo|otro"), False, llamadas, prop

def main():
    n = int(sys.argv[1])
    out = lambda o: print(json.dumps(o, ensure_ascii=False), flush=True)
    out({"inicio": time.strftime("%Y-%m-%dT%H:%M:%S%z"), "version": get("/api/version"),
         "tags": [{"name": m["name"], "digest": m["digest"], "size": m["size"], "details": m.get("details")}
                  for m in get("/api/tags")["models"] if m["name"] in MODELOS],
         "sistema": x2.SISTEMA, "tools": x2.TOOLS, "pedidos": [[c, p, t, f] for c, p, t, f in PEDIDOS],
         "parametros": {"temperature": 0.7, "seeds": f"1..{n}", "max_tokens": 300, "reasoning_effort": "none"}})
    res = {}
    for clave, pedido, con_tools, fmt in PEDIDOS:
        for seed in range(1, n + 1):
            for modelo in MODELOS:
                body = {"model": modelo, "messages": [{"role": "system", "content": x2.SISTEMA},
                        {"role": "user", "content": pedido}],
                        "temperature": 0.7, "seed": seed, "max_tokens": 300, "reasoning_effort": "none"}
                if con_tools: body["tools"] = x2.TOOLS
                if fmt: body["response_format"] = fmt
                ps_antes = ps()
                try:
                    r, dt = x2.call(body)
                    ch = r["choices"][0]; msg = ch["message"]
                    clase, falla, llamadas, prop = clasificar(clave, msg)
                    fin, usage, texto = ch.get("finish_reason"), r.get("usage"), msg.get("content") or ""
                except Exception as e:
                    clase, falla, llamadas, prop, fin, usage, texto, dt = "ERROR:" + type(e).__name__, False, [], None, None, None, str(e)[:200], None
                cargados_antes = [m["model"] for m in ps_antes] if isinstance(ps_antes, list) else ps_antes
                out({"pedido": clave, "seed": seed, "modelo": modelo, "clase": clase, "falla": falla,
                     "finish_reason": fin, "llamadas": llamadas, "propuesta": prop, "texto": texto[:400],
                     "usage": usage, "pared_s": round(dt, 2) if dt else None,
                     "cargado_antes": cargados_antes, "ps_despues": ps()})
                d = res.setdefault(clave, {}).setdefault(modelo, {"k_fallas": 0, "n": 0, "clases": {}, "paredes": []})
                d["n"] += 1; d["k_fallas"] += int(falla); d["clases"][clase] = d["clases"].get(clase, 0) + 1
                if dt: d["paredes"].append(round(dt, 2))
    for clave, por in res.items():
        for modelo, d in por.items():
            d["wilson95_fallas"] = wilson(d["k_fallas"], d["n"])
            out({"resumen": clave, "modelo": modelo, **d})
    out({"fin": time.strftime("%Y-%m-%dT%H:%M:%S%z"),
         "tags_fin": [{"name": m["name"], "digest": m["digest"]} for m in get("/api/tags")["models"] if m["name"] in MODELOS]})

if __name__ == "__main__":
    main()
