#!/usr/bin/env python3
"""E-B5: búsqueda semántica (ESC-02) sobre las ETIQUETAS del catálogo Medios de Movilidad Urbana.

Pregunta: ¿sirve la similitud de embeddings para mapear expresiones coloquiales a la clave del
catálogo (lo que ESC-02 hace bien), a diferencia de contar localidades (lo que hace mal)?
Endpoint sólo por OLLAMA_ENDPOINT; nunca se imprime (R-PRIV). Biblioteca estándar.
"""
import json, math, os, sys, time, urllib.request

EP = os.environ["OLLAMA_ENDPOINT"].rstrip("/")
MODEL = os.environ.get("OLLAMA_EMBEDDING_MODEL", "qwen3-embedding:0.6b")
# Catálogo copiado de MovilidadUrbana.ApiWeb/Domain/Catalogos.cs (clave, etiqueta).
MEDIOS = [("colectivo", "Colectivo"), ("auto", "Auto particular"), ("bicicleta", "Bicicleta"),
          ("moto", "Moto"), ("caminata", "A pie"), ("tren", "Tren")]
# Expresiones coloquiales escritas para la prueba (rotuladas), con la clave que debería salir.
CONSULTAS = [("voy caminando", "caminata"), ("a pata", "caminata"), ("me tomo el bondi", "colectivo"),
             ("en la bici", "bicicleta"), ("en mi coche", "auto"), ("en el ferrocarril", "tren"),
             ("en la moto de mi hermano", "moto"), ("en avión", None)]

def embed(textos):
    req = urllib.request.Request(EP + "/api/embed", data=json.dumps({"model": MODEL, "input": textos}).encode(),
                                 headers={"Content-Type": "application/json"})
    with urllib.request.urlopen(req, timeout=300) as r:
        return json.load(r)["embeddings"]

def cos(a, b):
    return sum(x * y for x, y in zip(a, b)) / (math.sqrt(sum(x * x for x in a)) * math.sqrt(sum(y * y for y in b)))

t0 = time.time()
docs = embed([f"Medio de transporte: {e}" for _, e in MEDIOS])
qs = embed([c for c, _ in CONSULTAS])
print(json.dumps({"paso": "b5-inicio", "modelo": MODEL, "dimension": len(docs[0]), "fecha": time.strftime("%Y-%m-%dT%H:%M:%S%z")}))
aciertos = 0
for (texto, esperado), q in zip(CONSULTAS, qs):
    orden = sorted(((cos(q, d), MEDIOS[i][0]) for i, d in enumerate(docs)), reverse=True)
    top1, s1 = orden[0][1], orden[0][0]
    margen = s1 - orden[1][0]
    ok = (top1 == esperado) if esperado else None
    aciertos += 1 if ok else 0
    print(json.dumps({"paso": "b5", "consulta": texto, "esperado": esperado, "top1": top1, "score1": round(s1, 3),
                      "top2": orden[1][1], "score2": round(orden[1][0], 3), "margen": round(margen, 3), "acierto": ok}, ensure_ascii=False))
print(json.dumps({"paso": "b5-fin", "aciertos": aciertos, "con_clave_esperada": sum(1 for _, e in CONSULTAS if e), "pared_s": round(time.time() - t0, 2)}))
