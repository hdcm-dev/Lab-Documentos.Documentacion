# Lote aprobado del ciclo 3, en forma ejecutable: P-02…P-23 de 03-Parches.md §3 (parches.py del auditor)
# más P-01 y P-19 de la «Revisión 2» (reemplazan a los de §3). Orden de aplicación (C-3 de costo-beneficio):
# P-16 → P-01 … P-22 → P-23.
import os, importlib.util
S = os.path.dirname(os.path.abspath(__file__))
spec = importlib.util.spec_from_file_location('pa', os.path.join(S, '../evidencia-auditor/simulacion/parches.py'))
pa = importlib.util.module_from_spec(spec); spec.loader.exec_module(pa)
P = {p['id']: dict(p) for p in pa.P}
# --- P-01, revisión 2: ops 1-8 sin cambios; op 9 con «todo otro motivo se escribe»; ops 10-15 nuevas
p1 = P['P-01']; ops = list(p1['ops'][:8])
assert p1['ops'][8][1].startswith('El motivo o el matiz va fuera del corchete')
ops.append(("rep", "El motivo o el matiz va fuera del corchete: **[no verificado]** (requiere Windows), **[criterio]** (sobre la base del fabricante).",
            "El motivo o el matiz va fuera del corchete: **[no verificado]** (requiere una plataforma alojada), **[criterio]** (sobre la base del fabricante). Sin motivo escrito, **[no verificado]** quiere decir «requiere Windows» (§0.4); todo otro motivo se escribe."))
ops += [
 ("rep", "que recomiende o desaconseje el BOM en `.cs` **[no verificado]**.", "que recomiende o desaconseje el BOM en `.cs` **[no verificado]** (sin documento del fabricante)."),
 ("rep", "[B80] | **[no verificado]** | **[no verificado]** |", "[B80] | **[no verificado]** (no ejercitado) | **[no verificado]** (no ejercitado) |"),
 ("rep", "pero que mueva su digest **[no verificado]**:", "pero que mueva su digest **[no verificado]** (requiere la plataforma):"),
 ("rep", "y no GitHub [B107] **[no verificado]** (§8.2.2)", "y no GitHub [B107] **[no verificado]** (requiere la plataforma; §8.2.2)"),
 ("rep", "No se ejercitó **[no verificado]**.", "**[no verificado]** (no ejercitado en el laboratorio)."),
 ("rep", "cómo se comporta con las más nuevas **[no verificado]**.", "cómo se comporta con las más nuevas **[no verificado]** (requiere la plataforma)."),
]
p1['ops'] = ops; p1['rev'] = 2
# --- P-19, revisión 2: op 1 igual; op 2 termina en «; cuatro marcas de juicio (§0.3).»; op 3 con el párrafo 1.1.0 nuevo
p19 = P['P-19']; o = list(p19['ops'])
k, a, b = o[1]; assert b.endswith('B194–B204, E2-7, E2-8.')
o[1] = (k, a, b[:-1] + '; cuatro marcas de juicio (§0.3).')
k, a, b = o[2]; old = '§3.5 comprimida, Práctica de §3, B218–B224.'; assert b.count(old) == 1
o[2] = (k, a, b.replace(old, '§3.5 comprimida, fila §3 en la ruta mínima, motivo por defecto de **[no verificado]**, B218–B224.'))
p19['ops'] = o; p19['rev'] = 2
ORDEN = ['P-16'] + [f'P-{i:02d}' for i in range(1, 23) if i != 16] + ['P-23']
