# Ensayo E-03 — ruta de lectura: alcance desde cada punto de entrada

Fecha: 2026-10-26. Lab-Documentos `5d5c2b4`; Lab-Documentos.Documentacion (árbol de trabajo).

## Script ($WORK/scripts/ruta.py, borrado al terminar)

```python
import os, re, sys
from collections import deque
ROOT = sys.argv[1]
starts = sys.argv[2:]
link = re.compile(r'\]\(([^)\s#]+)(?:#[^)]*)?\)')
def bfs(start):
    seen, q, broken = set(), deque([os.path.normpath(start)]), []
    while q:
        f = q.popleft()
        if f in seen: continue
        seen.add(f)
        try: txt = open(f, encoding='utf-8').read()
        except Exception: continue
        for t in link.findall(txt):
            if t.startswith(('http:', 'https:', 'mailto:')): continue
            p = os.path.normpath(os.path.join(os.path.dirname(f), t))
            if os.path.isdir(p): p = os.path.join(p, 'README.md') if os.path.exists(os.path.join(p,'README.md')) else p
            if not os.path.exists(p): broken.append((os.path.relpath(f, ROOT), t)); continue
            if p.endswith('.md') and p not in seen: q.append(p)
    return seen, broken
for s in starts:
    seen, broken = bfs(os.path.join(ROOT, s))
    guia = any(x.endswith('Sistema-Documentador-Tecnico-Guide.md') for x in seen)
    [print("   ROTO", b) for b in broken[:3]]
    print(f"INICIO {s} ({os.path.getsize(os.path.join(ROOT,s))} bytes): alcanzables={len(seen)} rotos={len(broken)} llega_a_la_guia={guia}")
```

## Comandos y salida

```text
$ python3 -I ruta.py /LAB/Lab-Documentos/Lab-Documentos README.md Guides/README.md Guides/Documentacion-Tecnica/Creacion-Guias-Tecnicas/README.md Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/Sistema-Documentador-Tecnico-Guide.md
INICIO README.md (0 bytes): alcanzables=1 rotos=0 llega_a_la_guia=False
INICIO Guides/README.md (0 bytes): alcanzables=1 rotos=0 llega_a_la_guia=False
INICIO Guides/Documentacion-Tecnica/Creacion-Guias-Tecnicas/README.md (15218 bytes): alcanzables=59 rotos=1 llega_a_la_guia=False
INICIO Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/Sistema-Documentador-Tecnico-Guide.md (71505 bytes): alcanzables=2 rotos=8 llega_a_la_guia=True
$ python3 -I ruta.py /LAB/Lab-Documentos/Lab-Documentos.Documentacion ia-db/README.md
INICIO ia-db/README.md (12094 bytes): alcanzables=12 rotos=1 llega_a_la_guia=False
```

El único roto de `Creacion-Guias-Tecnicas` y el de la ia-db son marcadores `…` dentro de texto (falsos positivos: `60-Desarrollo/Release-Notes.md`, `indexes/04_Diseno-REST-API.md`).

## Enlaces de la guía, uno por uno

```text
ROTO :189 ../Documentacion-Tecnica/README.md
ROTO :203 ../Documentacion-Tecnica/30-Arquitectura/ADR.md
ROTO :203 ../Documentacion-Tecnica/30-Arquitectura/SAD.md
ROTO :203 ../Documentacion-Tecnica/95-Transversales/Spec-Driven-Development.md
ROTO :432 ../Documentacion-Tecnica/README.md
OK   :476 Examples/Prueba-Ayuda-Por-Rol/README.md
ROTO :590 ../Documentacion-Tecnica/60-Desarrollo/Change-Log.md
ROTO :625 ../Documentacion-Tecnica/60-Desarrollo/Change-Log.md
ROTO :633 ../Documentacion-Tecnica/README.md
```

## Enlaces entrantes a la guía

```text
$ grep -rln "Sistema-Documentador-Tecnico-Guide" /LAB/Lab-Documentos/Lab-Documentos --include=*.md
CHANGELOG.md
Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/Examples/Lanzar-Example.md
Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/Examples/Prueba-Ayuda-Por-Rol/README.md
```

Desde la ia-db, la guía se nombra por ruta en texto (`ia-db/indexes/01_Documentacion-Tecnica.md:9`, `:19`), no por enlace: un agente que lee rutas la encuentra; una persona que sigue enlaces, no.
