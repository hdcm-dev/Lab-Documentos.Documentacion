"""Parte la guía (archivo único) en un cuerpo de páginas por H2, con frontmatter.

Uso: python3 -I split_guide.py <guia.md> <dir_salida>
Ensayo de C-AGENTES-IA. Sólo lee la guía; escribe en dir_salida.
"""
import re, sys, pathlib, unicodedata

src = pathlib.Path(sys.argv[1]).read_text(encoding="utf-8")
out = pathlib.Path(sys.argv[2]); out.mkdir(parents=True, exist_ok=True)

# quitar frontmatter original
if src.startswith("---"):
    src = src.split("---", 2)[2]

def slug(s):
    s = unicodedata.normalize("NFKD", s).encode("ascii", "ignore").decode()
    s = re.sub(r"[^a-zA-Z0-9]+", "-", s).strip("-").lower()
    return s[:50]

parts = re.split(r"(?m)^## ", src)
pages = []
for i, p in enumerate(parts[1:], start=1):
    title, _, body = p.partition("\n")
    title = title.strip()
    # descripción: primera oración de prosa
    prose = [l for l in body.splitlines() if l.strip() and not l.startswith(("#", "|", "```", "-", ">", "!"))]
    desc = re.split(r"(?<=[.:])\s", prose[0].strip())[0] if prose else title
    desc = desc.replace('"', "'")[:160]
    name = f"{i:02d}-{slug(title)}.md"
    fm = (f"---\ndoc_id: SDT-P{i:02d}\ndoc_type: guia-tema\ntitle: \"{title}\"\n"
          f"description: \"{desc}\"\nstatus: ensayo\norigin: agent\nconfidence: media\n"
          f"owner: ensayo-c-agentes-ia\nlast_review: 2026-10-26\naudience: [humanos, agentes]\n"
          f"traces: [SDT@guia-actual]\n---\n\n")
    (out / name).write_text(fm + "# " + title + "\n" + body, encoding="utf-8")
    pages.append(name)
print(len(pages), "páginas")
