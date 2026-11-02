#!/usr/bin/env python3
"""M4 Invenciones: extrae cada cita `ruta:línea` o `ruta:a-b` de salida/A-01.md y de
los artefactos .md de salida/ (sin _inventario/, que son salidas crudas de comandos)
y comprueba que el archivo existe y que la línea (o el rango) existe.

Uso: python3 -I m4_citas.py <dir-de-la-corrida>  -> TSV por stdout, resumen por stderr.

Resolución de rutas (A-01 declara «relativas a repo/LD/ salvo que digan otra cosa»):
  1. `salida/...`, `conocimiento.md`, `A-01-ficha-vacia.md`, `repo/...` -> relativas al dir de la corrida.
  2. resto -> relativas a repo/LD/.
  3. si no existe y es nombre corto (p. ej. `docs-guard.yml`), se busca por sufijo en repo/LD;
     se acepta sólo si hay un candidato único (se marca «resuelta-por-sufijo»).
  `:N` sin ruta (continuación) hereda la última ruta citada en la misma línea del documento.
"""
import os, re, sys

run = os.path.abspath(sys.argv[1])
repo = os.path.join(run, "repo", "LD")
SPAN = re.compile(r"`([^`]*)`")
CITA = re.compile(r"^([A-Za-z0-9_./{}-]*):(\d+)(?:-(\d+))?$")
RUN_REL = ("salida/", "repo/", "conocimiento.md", "A-01-ficha-vacia.md")

todos = []
for d, _, fs in os.walk(repo):
    if ".git" in d.split(os.sep):
        continue
    for f in fs:
        todos.append(os.path.relpath(os.path.join(d, f), repo))

def resolver(p):
    if p.startswith(RUN_REL):
        return os.path.join(run, p), "corrida"
    c = os.path.join(repo, p)
    if os.path.exists(c):
        return c, "repo"
    cand = [t for t in todos if t == p or t.endswith("/" + p)]
    if len(cand) == 1:
        return os.path.join(repo, cand[0]), "resuelta-por-sufijo:" + cand[0]
    return None, "no-existe" if not cand else "ambigua:%d" % len(cand)

def nlineas(f):
    with open(f, "rb") as h:
        return len(h.read().splitlines())

docs = [os.path.join(run, "salida", "A-01.md")]
for d, _, fs in os.walk(os.path.join(run, "salida")):
    if "_inventario" in d:
        continue
    for f in sorted(fs):
        p = os.path.join(d, f)
        if f.endswith(".md") and p not in docs:
            docs.append(p)

print("doc\tlinea_doc\tcita\truta_resuelta\testado")
tot = mal = 0
for doc in docs:
    rel_doc = os.path.relpath(doc, run)
    with open(doc, encoding="utf-8") as h:
        for i, linea in enumerate(h, 1):
            ultima = None
            for s in SPAN.findall(linea):
                m = CITA.match(s.strip())
                if not m:
                    continue
                ruta, a, b = m.group(1), int(m.group(2)), int(m.group(3) or m.group(2))
                if ruta == "":
                    if ultima is None:
                        continue
                    ruta = ultima
                elif "." not in os.path.basename(ruta) and "/" not in ruta:
                    continue  # p. ej. `dotnet:1-10.0` (no es cita)
                ultima = ruta
                f, origen = resolver(ruta)
                tot += 1
                if f is None:
                    estado = "FALLA archivo " + origen
                elif os.path.isdir(f):
                    estado = "FALLA es directorio"
                else:
                    n = nlineas(f)
                    estado = "ok" if 1 <= a <= b <= n else "FALLA linea fuera (%d lineas)" % n
                    if origen.startswith("resuelta"):
                        estado += " [" + origen + "]"
                if estado.startswith("FALLA"):
                    mal += 1
                cita = s if s.startswith(ruta) else ruta + s
                rr = os.path.relpath(f, run) if f else "-"
                print(f"{rel_doc}\t{i}\t{cita}\t{rr}\t{estado}")
print(f"citas={tot} fallas={mal}", file=sys.stderr)
