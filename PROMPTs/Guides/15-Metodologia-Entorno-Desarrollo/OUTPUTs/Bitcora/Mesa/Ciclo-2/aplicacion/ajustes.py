# Ajustes de aplicación (ciclo 2), cada uno derivado de un parche aprobado; ver 05-Aplicacion.md §3.
import os, sys
G = os.environ['GUIA']; t = open(G, encoding='utf-8').read()
def R(a, b):
    global t
    assert t.count(a) == 1, (t.count(a), a[:60]); t = t.replace(a, b); print('ok:', a[:70].replace('\n', '⏎'))
# AJ-1 (P-23 L4 → P-15): «Las líneas de A.17 (commit y hash de la DLL) se copian de esa salida»: la salida
# regenerada de EA-1 en Examples/ (no la del experimento X7 del auditor).
R('commit=6f6df869… arbol_limpio=si', 'commit=9fc4bb38… arbol_limpio=si')
R('sha256 out/App.dll=2bcec512…', 'sha256 out/App.dll=d6cc63cb…')
# AJ-2 (P-17, op 0): la fila nueva «Escenario / contexto / actor», con el mismo texto, en su lugar alfabético
# (el ancla del op la dejaba antes de «Enfriamiento»; el parche declara «filas nuevas en orden alfabético»).
FILA = '| Escenario / contexto / actor | ESC-nn, CTX-… y ACT-…: dónde se trabaja, qué combina la solución, qué rol decide. | §2 |\n'
R(FILA + '| Enfriamiento (*cooldown*) |', '| Enfriamiento (*cooldown*) |')
R('| Etiqueta (*tag*) |', FILA + '| Etiqueta (*tag*) |')
open(G, 'w', encoding='utf-8').write(t)
