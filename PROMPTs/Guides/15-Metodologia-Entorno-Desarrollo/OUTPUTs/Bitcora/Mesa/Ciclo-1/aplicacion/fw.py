#!/usr/bin/env python3
"""Aplicador de parches de la mesa (ciclo 1) sobre la guía. Corre siempre desde la copia original."""
import re, sys, os, json
SP = "<scratchpad>"
GUIA = "<workspace>/LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md"
S = open(SP + "/bk/guide-orig.md", encoding="utf-8").read()
LOG = []          # (pid, op, ok, detalle)
SNAP = {}         # pid -> texto antes del parche (para revertir)
CUR = [None]

def begin(pid):
    CUR[0] = pid; SNAP[pid] = S_get()

def S_get():
    return G["S"]
G = {"S": S}

OLDS = []
def R(old, new, n=1, note=""):
    OLDS.append((CUR[0], old))
    s = G["S"]; c = s.count(old)
    if c != n:
        LOG.append((CUR[0], "R", False, f"esperaba {n}, hay {c}: {old[:90]!r} {note}"))
        return False
    G["S"] = s.replace(old, new)
    LOG.append((CUR[0], "R", True, old[:70])); return True

def AFTER(anchor, add):
    return R(anchor, anchor + add)

def BEFORE(anchor, add):
    return R(anchor, add + anchor)

def lines():
    return G["S"].split("\n")

def setlines(L):
    G["S"] = "\n".join(L)

def qfind(qprefix, start_hdr=None, end_hdr=None):
    L = lines(); lo, hi = 0, len(L)
    if start_hdr:
        lo = next(i for i, l in enumerate(L) if l.startswith(start_hdr))
        hi = next((i for i in range(lo + 1, len(L)) if L[i].startswith(end_hdr)), len(L)) if end_hdr else len(L)
    idx = [i for i in range(lo, hi) if L[i].startswith("**" + qprefix) or L[i].startswith("**" + qprefix.lstrip("¿"))]
    return L, idx

def APPQ(qprefix, add, sec=None, endsec=None):
    """Agrega `add` al final del párrafo de respuesta de la pregunta en negrita que empieza con qprefix."""
    L, idx = qfind(qprefix, sec, endsec)
    if len(idx) != 1:
        LOG.append((CUR[0], "APPQ", False, f"pregunta {qprefix!r}: {len(idx)} coincidencias")); return False
    i = idx[0]; j = i
    while j + 1 < len(L) and L[j + 1].strip() != "":
        j += 1
    L[j] = L[j].rstrip() + add
    setlines(L); LOG.append((CUR[0], "APPQ", True, qprefix[:60])); return True

def REPQ_ANSWER(qprefix, newanswer, sec=None, endsec=None):
    """Reemplaza el párrafo de respuesta (líneas tras la pregunta) por newanswer."""
    L, idx = qfind(qprefix, sec, endsec)
    if len(idx) != 1:
        LOG.append((CUR[0], "REPQ", False, f"pregunta {qprefix!r}: {len(idx)}")); return False
    i = idx[0]; j = i
    while j + 1 < len(L) and L[j + 1].strip() != "":
        j += 1
    if j == i:
        LOG.append((CUR[0], "REPQ", False, f"respuesta en la misma línea {qprefix!r}")); return False
    L[i + 1:j + 1] = [newanswer]
    setlines(L); LOG.append((CUR[0], "REPQ", True, qprefix[:60])); return True

def SPLITQ(sec, endsec):
    """Formato C1-55: '?** ' -> '?**' + salto de línea en las preguntas de una sección."""
    L = lines()
    lo = next(i for i, l in enumerate(L) if l.startswith(sec))
    hi = next(i for i in range(lo + 1, len(L)) if L[i].startswith(endsec))
    n = 0
    for i in range(lo, hi):
        if L[i].startswith("**") and "?** " in L[i]:
            a, b = L[i].split("?** ", 1)
            L[i] = a + "?**\n" + b; n += 1
    setlines(L); LOG.append((CUR[0], "SPLITQ", True, f"{sec}: {n} preguntas"))
    return n

def UNNUMQ(sec, endsec):
    L = lines()
    lo = next(i for i, l in enumerate(L) if l.startswith(sec))
    hi = next(i for i in range(lo + 1, len(L)) if L[i].startswith(endsec))
    n = 0
    for i in range(lo, hi):
        m = re.match(r"^\*\*\d+\. ", L[i])
        if m:
            L[i] = "**" + L[i][m.end():]; n += 1
    setlines(L); LOG.append((CUR[0], "UNNUMQ", True, f"{sec}: {n}"))
    return n

def BEFORE_SECTION_END(hdr_prefix, add):
    """Inserta `add` antes del '---' que cierra la sección cuyo encabezado empieza con hdr_prefix."""
    L = lines()
    lo = [i for i, l in enumerate(L) if l.startswith(hdr_prefix)]
    if len(lo) != 1:
        LOG.append((CUR[0], "BSE", False, f"{hdr_prefix}: {len(lo)}")); return False
    k = next(i for i in range(lo[0] + 1, len(L)) if L[i] == "---")
    # retrocede sobre líneas en blanco
    j = k
    while L[j - 1].strip() == "":
        j -= 1
    L[j:k] = ["", add.strip("\n"), "", ""]
    # normaliza: exactamente una línea en blanco antes de ---
    setlines(L); G["S"] = G["S"].replace(add.strip("\n") + "\n\n\n---", add.strip("\n") + "\n\n---")
    LOG.append((CUR[0], "BSE", True, hdr_prefix)); return True

def END_OF_SECTION_APPEND(hdr_prefix, next_hdr_prefix, add):
    """Inserta `add` (bloque) al final de la subsección: antes del siguiente encabezado."""
    L = lines()
    lo = [i for i, l in enumerate(L) if l.startswith(hdr_prefix)]
    if len(lo) != 1:
        LOG.append((CUR[0], "EOS", False, f"{hdr_prefix}: {len(lo)}")); return False
    k = next(i for i in range(lo[0] + 1, len(L)) if L[i].startswith(next_hdr_prefix) or L[i] == "---")
    j = k
    while L[j - 1].strip() == "":
        j -= 1
    L[j:k] = ["", add.strip("\n"), ""]
    setlines(L); LOG.append((CUR[0], "EOS", True, hdr_prefix)); return True

def LINE_REPLACE(startswith, newline, n=1):
    L = lines(); idx = [i for i, l in enumerate(L) if l.startswith(startswith)]
    if len(idx) != n:
        LOG.append((CUR[0], "LINE", False, f"{startswith[:80]!r}: {len(idx)}")); return False
    for i in idx:
        L[i] = newline
    setlines(L); LOG.append((CUR[0], "LINE", True, startswith[:60])); return True
