# Aparato de referencias: extrae las filas de las tablas de fuentes (§7) de cada núcleo,
# y reporta (a) ids repetidos entre núcleos con distinto contenido, (b) la misma URL con ids distintos,
# (c) filas sin fecha de consulta propia ni de tabla y (d) filas sin versión/ms.date.
# Uso: python3 -I fuentes.py <archivos...>
import re, sys, collections
byid = collections.defaultdict(list); byurl = collections.defaultdict(list)
for f in sys.argv[1:]:
    name = f.split('/')[-1].split('-')[0]
    txt = open(f, encoding='utf-8').read()
    m = re.search(r'^## 7\. Tabla de fuentes(.*?)(?=^## )', txt, flags=re.S | re.M)
    if not m: print(name, 'SIN §7'); continue
    sec = m.group(1)
    fecha_tabla = bool(re.search(r'Fecha de consulta', sec))
    rows = [r for r in sec.splitlines() if re.match(r'^\|\s*\**[A-Z]\d+\**\s*\|', r)]
    sin_fecha = sin_ver = 0; ids = []
    for r in rows:
        rid = re.match(r'^\|\s*\**([A-Z]\d+)', r).group(1); ids.append(rid)
        byid[rid].append(name)
        for u in re.findall(r'https?://[^\s|)>`]+', r)[:1]:
            byurl[u.rstrip('.,;')].append(f'{name}:{rid}')
        if not fecha_tabla and not re.search(r'20\d\d-\d\d-\d\d', r): sin_fecha += 1
        if not re.search(r'ms\.date|v\d|\b\d+\.\d+(\.\d+)?\b|20\d\d-\d\d-\d\d|\d{4}‑\d\d‑\d\d|commit|\(\d{4}', r): sin_ver += 1
    fmt = 'F01' if any(re.match(r'[A-Z]0\d', i) for i in ids) else 'F1'
    print(f'{name}: filas={len(rows)} prefijo={sorted(set(i[0] for i in ids))} formato={fmt} fecha_por_tabla={fecha_tabla} filas_sin_fecha={sin_fecha} filas_sin_version_ni_fecha={sin_ver}')
print('\n(a) ids presentes en más de un núcleo:')
rep = {k: v for k, v in byid.items() if len(set(v)) > 1}
print(f'   {len(rep)} ids; p. ej. ' + '; '.join(f'{k}→{sorted(set(v))}' for k, v in sorted(rep.items())[:8]))
print('\n(b) misma URL con ids distintos:')
for u, v in sorted(byurl.items()):
    if len(set(x.split(":")[1] for x in v)) > 1 or len(set(x.split(":")[0] for x in v)) > 1:
        print(f'   {u}  ←  {", ".join(v)}')
