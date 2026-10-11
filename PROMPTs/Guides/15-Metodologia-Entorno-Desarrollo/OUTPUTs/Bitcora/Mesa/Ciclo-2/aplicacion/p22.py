# P-22: notas de solo agregado en la capa de origen (ciclo 2). Uso: python3 -I p22.py
import os, re, shutil, sys
S = os.path.dirname(os.path.abspath(__file__))
C2 = os.path.dirname(S); MESA = os.path.dirname(C2); B = os.path.dirname(MESA)
txt = open(os.path.join(C2, "03-Parches.md"), encoding="utf-8").read()
sec = txt[txt.index("## 4. P-22"):txt.index("## 5. P-23")]
rows = [l for l in sec.split("\n") if re.match(r"^\| O-\d+ \|", l)]
def cells(l):
    parts = re.split(r"(?<!\\)\|", l.strip()[1:-1])
    return [p.strip() for p in parts]
ANCLAS = {  # texto que identifica la línea ancla en el archivo (de la columna «Ancla»)
 "O-1": "> **Corrección mesa ciclo 1 (2026-10-09, C1-03, C1-58).**",
 "O-2": "> **Corrección mesa ciclo 1 (2026-10-09, C1-26).** El lock va **sólo en los ejecutables**",
 "O-3": "> **Corrección mesa ciclo 1 (2026-10-09, C1-31).**",
 "O-4": "# charset = utf-8-bom",
 "O-5": "> **Corrección mesa ciclo 1 (2026-10-09, C1-20, C1-21).**",
 "O-6": "- `builder.id` **vacío**: una build local no tiene identidad de plataforma.",
 "O-7": "export SOURCE_DATE_EPOCH=$(git log -1 --pretty=%ct)",
 "O-8": "| ESC-04 Devcontainer | Hook dentro del contenedor + CI |",
 "O-9": "**La compuerta es lo que hace «único» al punto de verdad.**",
 "O-10": "- **[fabricante]** `open()` sin `encoding=` depende del *locale* hasta 3.14.",
}
def fin_de_bloque(L, i):
    # dentro de un bloque de código: hasta la valla de cierre; si no, hasta la línea en blanco
    fence = False
    for k in range(0, i + 1):
        if L[k].lstrip().startswith("```"): fence = not fence
    j = i
    if fence:
        while not L[j + 1].lstrip().startswith("```"): j += 1
        return j + 1
    while j + 1 < len(L) and L[j + 1].strip() != "": j += 1
    return j
snap = os.path.join(S, "instantanea-origen"); os.makedirs(snap, exist_ok=True)
log = []
for r in rows:
    c = cells(r); oid, arch, nota = c[0], c[1], c[3]
    nota = nota[1:-1].replace("\\|", "|")
    if oid == "O-11":
        destinos = [os.path.join(MESA, "Ciclo-1", "03-Parches.md"), os.path.join(MESA, "Ciclo-1", "05-Aplicacion.md")]
    else:
        destinos = [os.path.join(B, arch.strip("`"))]
    for d in destinos:
        rel = os.path.relpath(d, B); s = os.path.join(snap, rel.replace("/", "__"))
        if not os.path.exists(s): shutil.copy2(d, s)
        L = open(d, encoding="utf-8").read().split("\n")
        if any(nota.split("**")[1] in l and nota[:60] in l for l in L):
            log.append((oid, rel, "ya presente")); continue
        if oid == "O-11":
            while L and L[-1] == "": L.pop()
            L += ["", nota, ""]
        else:
            idx = [i for i, l in enumerate(L) if l.startswith(ANCLAS[oid])]
            if len(idx) != 1: log.append((oid, rel, f"ANCLA {len(idx)}")); continue
            j = fin_de_bloque(L, idx[0])
            L[j + 1:j + 1] = ["", nota]
        open(d, "w", encoding="utf-8").write("\n".join(L))
        log.append((oid, rel, "insertada"))
for x in log: print(*x)
