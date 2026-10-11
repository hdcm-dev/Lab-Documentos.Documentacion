#!/usr/bin/env python3
"""Compara (o escribe con --write) los bloques del Anexo A con Examples/A-plantillas/repo/."""
import sys, re, os
guia, repo = sys.argv[1], sys.argv[2]
write = "--write" in sys.argv
t = open(guia, encoding="utf-8").read()
a = t.index("## Anexo A."); b = t.index("## Anexo B.")
anx = t[a:b]
blocks = []  # (sección, lang, contenido)
sec = None
lines = anx.split("\n"); i = 0
while i < len(lines):
    l = lines[i]
    if l.startswith("### A."): sec = l.split()[1]
    m = re.match(r"^```(\w*)$", l)
    if m:
        j = i + 1
        while lines[j] != "```": j += 1
        blocks.append((sec, m.group(1), "\n".join(lines[i+1:j]) + "\n")); i = j
    i += 1
MAP = {("A.1",0):".editorconfig",("A.2",0):".gitattributes",("A.3",0):"global.json",("A.4",0):"Directory.Build.props",("A.4",1):"Directory.Build.targets",
 ("A.5",0):"Directory.Packages.props",("A.6",0):"nuget.config",("A.7",0):"web/package.json",("A.7",1):"web/.npmrc",("A.8",0):"tools/gen/pyproject.toml",
 ("A.8",1):"tools/gen/.python-version",("A.9",0):".devcontainer/devcontainer.json",("A.10",0):"imagen/Dockerfile",("A.11",0):".githooks/pre-commit",
 ("A.11",1):"tools/ci/compuerta.sh",("A.12",0):".github/workflows/ci.yml",("A.13",0):".github/dependabot.yml",("A.14",0):".github/CODEOWNERS",
 ("A.15",0):".git-blame-ignore-revs",("A.16",0):"docs/adr/0000-plantilla-entorno.md"}
cnt = {}; ok = True
for sec, lang, c in blocks:
    k = cnt.get(sec, 0); cnt[sec] = k + 1
    f = MAP.get((sec, k))
    if not f: print("SIN MAPEO", sec, k, lang); ok = False; continue
    p = os.path.join(repo, f)
    cur = open(p, "rb").read() if os.path.exists(p) else None
    new = c.encode("utf-8")
    if cur == new: print(f"igual      {f}")
    else:
        ok = False
        why = "no existe" if cur is None else ("difiere sólo en el salto final" if cur.rstrip(b"\n") == new.rstrip(b"\n") else "DIFIERE")
        print(f"{why:10} {f}")
        if write:
            os.makedirs(os.path.dirname(p) or ".", exist_ok=True); open(p, "wb").write(new)
            if f.endswith(".sh") or f.endswith("pre-commit"): os.chmod(p, 0o755)
print("TODO IGUAL" if ok else "HAY DIFERENCIAS")
