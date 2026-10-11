# Ajustes de aplicación del ciclo 3 sobre la guía REAL (después del lote).
# AJ-1 (P-13, condición C-2 y L-01b): commit y hash de la DLL del extracto de A.17, desde la salida versionada de EA-1.
# R-1  (P-16, regresión parcial): la fila B224 repite la URL de B62 y la verificación de P-16 («0 URL repetidas») falla.
#      Se revierte esa fila y se aplica el arrastre que la revisión 2 de P-01 y P-19 prevé para «P-16 sin B224»
#      (223 fuentes; B194–B223; B218–B223), extendido a la op 1 de P-16 y a las dos citas [B224] de P-18 op 5.
# Uso: GUIA=<guía> EXAMPLES=<Examples> python3 -I ajustes.py
import os, re, sys
G = os.environ['GUIA']; EX = os.environ['EXAMPLES']
t = open(G, encoding='utf-8').read()
o = open(os.path.join(EX, 'A-plantillas/salidas/EA-1-plantillas.txt'), encoding='utf-8').read()
c = re.search(r'commit=([0-9a-f]{8})[0-9a-f]* arbol_limpio=si', o).group(1)
d = re.search(r'sha256 out/App\.dll=([0-9a-f]{8})', o).group(1)
ops = [
 ('AJ-1', 'commit=ab2a6d36… arbol_limpio=si', f'commit={c}… arbol_limpio=si'),
 ('AJ-1', 'sha256 out/App.dll=fa6a50ec…', f'sha256 out/App.dll={d}…'),
 ('R-1', '| B224 | .NET — `releases-index.json` (8.0: `eol-date` 2026-11-10; 10.0: `latest-sdk` 10.0.401), reconsultado | https://builds.dotnet.microsoft.com/dotnet/release-metadata/releases-index.json | 2026-10-09 |\n', ''),
 ('R-1', 'fuentes_consultadas: "2026-10-07; B194–B224: 2026-10-09"', 'fuentes_consultadas: "2026-10-07; B194–B223: 2026-10-09"'),
 ('R-1', '(224 fuentes, Anexo D)', '(223 fuentes, Anexo D)'),
 ('R-1', 'Las fuentes B01–B193 se consultaron el **2026-10-07**; B194–B224, el **2026-10-09**.', 'Las fuentes B01–B193 se consultaron el **2026-10-07**; B194–B223, el **2026-10-09**.'),
 ('R-1', 'motivo por defecto de **[no verificado]**, B218–B224.', 'motivo por defecto de **[no verificado]**, B218–B223.'),
 ('R-1', 'SDK de .NET 10.0.401 vigente y .NET 11 en RC1 [B224][B62]', 'SDK de .NET 10.0.401 vigente y .NET 11 en RC1 [B62]'),
 ('R-1', 'fin de soporte de .NET 8 y 9 el 2026-11-10 [B61][B224]', 'fin de soporte de .NET 8 y 9 el 2026-11-10 [B61]'),
]
err = []
for k, a, b in ([] if '--aj2' in sys.argv else ops):
    n = t.count(a)
    if n != 1: err.append((k, n, a[:70])); continue
    t = t.replace(a, b); print(k, 'ok:', a[:70].replace('\n', ' '))
if err: print('ERRORES (no se escribe):', err); sys.exit(1)
if '--aj2' not in sys.argv: open(G, 'w', encoding='utf-8').write(t)

# AJ-2 (P-11, condición C-1 del voto APLICAR de costo-beneficio; la misma cita pide el juez de evidencia):
# la frase de §11.2.2 sobre Python 3.15 cita también [B220]. Sólo cita, sin prosa. Se corre aparte: python3 -I ajustes.py --aj2
if '--aj2' in sys.argv:
    t = open(G, encoding='utf-8').read(); a = 'desde 3.15 usa UTF-8 estricto [B29][B205],'
    assert t.count(a) == 1; t = t.replace(a, 'desde 3.15 usa UTF-8 estricto [B29][B205][B220],')
    open(G, 'w', encoding='utf-8').write(t); print('AJ-2 ok')
