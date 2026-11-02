# Sonda AH-02 (P-05 parcial): recuperacion por embeddings sobre dos corpus con el mismo conjunto de preguntas.
# Corpus A = parafrasis de N3/E3 (historia); Corpus B = 12 enunciados de *Policy tal como los lee CorpusDeRequisitos (EA-6 salida-real.txt).
# Endpoint solo por variable de entorno (R-PRIV). Imprime ranks, score top-1 y huella de los vectores para ver determinismo.
import json, os, sys, math, hashlib, urllib.request, datetime
EP = os.environ["OLLAMA_ENDPOINT"].rstrip("/")
MODEL = os.environ.get("OLLAMA_EMBEDDING_MODEL", "qwen3-embedding:0.6b")
def embed(texts):
    req = urllib.request.Request(EP + "/api/embed", data=json.dumps({"model": MODEL, "input": texts}).encode(), headers={"Content-Type": "application/json"})
    with urllib.request.urlopen(req, timeout=600) as r: return json.load(r)["embeddings"]
def cos(a, b):
    return sum(x*y for x, y in zip(a, b)) / (math.sqrt(sum(x*x for x in a)) * math.sqrt(sum(y*y for y in b)))
A = [("loc-nombre","El nombre de una localidad debe tener entre 3 y 60 caracteres y no puede repetirse dentro de la misma provincia."),
 ("loc-cp","El código postal de una localidad se compone de exactamente 4 dígitos numéricos."),
 ("loc-hab","La cantidad de habitantes es un número entero de 1 en adelante, sin máximo."),
 ("loc-baja","Borrar una localidad no afecta las respuestas de encuesta ya registradas, porque guardan el nombre y no la clave."),
 ("enc-edad","Quien responde la encuesta debe tener entre 16 y 110 años, ambos bordes incluidos."),
 ("enc-dist","La distancia recorrida por día va de 0 a 500 km; cero es válido porque se puede no viajar."),
 ("enc-min","El tiempo de viaje diario va de 1 a 600 minutos; cero minutos no es válido."),
 ("enc-medios","Los medios de transporte posibles son colectivo, auto particular, bicicleta, moto, a pie y tren; hay que elegir al menos uno."),
 ("enc-frec","La frecuencia de uso puede ser todos los días, algunos días por semana u ocasionalmente."),
 ("enc-motivo","El motivo principal del viaje es trabajo, estudio, salud u otros."),
 ("enc-pasos","La encuesta es un asistente de tres pasos: datos personales, hábitos de viaje y motivo con confirmación."),
 ("sesion","Cada visitante tiene su propia sesión y sus datos quedan aislados del resto en la misma base SQLite.")]
B = [("L.Nombre","Localidad, nombre: Entre 3 y 60 caracteres, único por provincia."),
 ("L.Provincia","Localidad, provincia: Una de las provincias del catálogo."),
 ("L.CodigoPostal","Localidad, codigo postal: 4 dígitos."),
 ("L.Habitantes","Localidad, habitantes: Un número entero de 1 en adelante."),
 ("E.Nombre","Encuesta, nombre: Al menos 3 caracteres."),
 ("E.Edad","Encuesta, edad: Entre 16 y 110 años."),
 ("E.Localidad","Encuesta, localidad: Una de las localidades cargadas en el ABM."),
 ("E.Medios","Encuesta, medios: Al menos uno."),
 ("E.Frecuencia","Encuesta, frecuencia: Con qué asiduidad usa esos medios."),
 ("E.Distancia","Encuesta, distancia: Entre 0 y 500 km por día."),
 ("E.Minutos","Encuesta, minutos: Entre 1 y 600 minutos."),
 ("E.Motivo","Encuesta, motivo: El motivo principal del viaje.")]
# pregunta, oro en A, oro en B (None = el corpus no contiene la respuesta), respondible en B con el texto (si/no)
Q = [("¿Cuántos números lleva el CP?","loc-cp","L.CodigoPostal","si"),
 ("¿Puedo cargar dos pueblos con el mismo nombre en una provincia?","loc-nombre","L.Nombre","si"),
 ("¿Un chico de 15 años puede contestar?","enc-edad","E.Edad","si"),
 ("Si no viajo, ¿qué pongo en kilómetros?","enc-dist","E.Distancia","parcial"),
 ("¿Se puede ir caminando como medio?","enc-medios","E.Medios","no"),
 ("Si elimino una ciudad, ¿se pierden las encuestas?","loc-baja",None,"no"),
 ("¿Qué opciones hay para la razón del viaje?","enc-motivo","E.Motivo","no"),
 ("¿Los datos de otro usuario se mezclan con los míos?","sesion",None,"no"),
 # no respondibles en ambos corpus (control de umbral)
 ("¿Puedo viajar en avión?",None,None,"no"),
 ("¿A qué hora abre la municipalidad?",None,None,"no"),
 ("¿Cuál es la capital de Francia?",None,None,"no")]
def corrida(corpus, gold_idx, etiqueta):
    dv = embed([t for _, t in corpus]); qv = embed([q[0] for q in Q])
    huella = hashlib.sha256(json.dumps([round(x, 6) for x in dv[0][:64]]).encode()).hexdigest()[:12]
    print(f"## {etiqueta}: dim={len(dv[0])} n_docs={len(corpus)} huella_doc0={huella}")
    h1 = h3 = 0; rr = 0.0; n = 0
    for q, v in zip(Q, qv):
        s = sorted(((cos(v, d), corpus[i][0]) for i, d in enumerate(dv)), reverse=True)
        gold = q[gold_idx]; ids = [x[1] for x in s]
        rank = ids.index(gold) + 1 if gold else 0
        if gold:
            n += 1; h1 += rank == 1; h3 += 1 <= rank <= 3; rr += (1 / rank if rank <= 5 else 0)
        top = ", ".join(f"{i}:{sc:.3f}" for sc, i in s[:3])
        print(f"  q='{q[0]}' oro={gold} rank={rank or '-'} respondible_B={q[3]} top3=[{top}]")
    print(f"  RESUMEN {etiqueta}: con_oro={n} hit@1={h1}/{n} hit@3={h3}/{n} MRR@5={rr/n:.3f} (azar: hit@3 esperado = {3/len(corpus):.3f})")
print("# Sonda AH-02 recuperacion", datetime.datetime.now(datetime.timezone.utc).isoformat(), "modelo", MODEL)
for rep in (1, 2):
    print(f"=== repeticion {rep} ===")
    corrida(A, 1, "corpus A (parafrasis E3)")
    corrida(B, 2, "corpus B (*Policy reales)")
