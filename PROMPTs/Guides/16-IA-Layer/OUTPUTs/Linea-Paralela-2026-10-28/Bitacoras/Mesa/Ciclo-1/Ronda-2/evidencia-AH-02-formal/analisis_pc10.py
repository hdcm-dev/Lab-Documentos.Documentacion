#!/usr/bin/env python3
"""Análisis de la sonda PC-10 (sin modelo). Uso: python3 -I analisis_pc10.py salida.jsonl
Calcula: k/n e IC95 de Wilson por pedido; tasa agregada ingenua (ensayos independientes) frente a
bootstrap por conglomerado (se remuestrean pedidos); ICC de ANOVA y efecto de diseño; prueba de
permutación de homogeneidad entre pedidos; efecto de la semilla entre pedidos (Cochran Q por
permutación); semillas 1..8 frente a 1001..1008 en P0 (Fisher exacto); reproducibilidad (bloque C)."""
import json, math, random, sys
from itertools import combinations
from math import comb

def wilson(k, n, z=1.96):
    if n == 0: return (float('nan'),) * 2
    p = k / n; d = 1 + z*z/n; c = p + z*z/(2*n); r = z*math.sqrt(p*(1-p)/n + z*z/(4*n*n))
    return max(0, (c - r)/d), min(1, (c + r)/d)

filas = [json.loads(l) for l in open(sys.argv[1]) if l.startswith('{')]
cab = filas[0]; filas = filas[1:]
A = [f for f in filas if f['bloque'] == 'A']; B = [f for f in filas if f['bloque'] == 'B']; C = [f for f in filas if f['bloque'] == 'C']
print(f"modelo {cab['modelo']}@{cab['digest'][0][:12]}… Ollama {cab['ollama']['version']} {cab['endpoint']} T 0.7 num_predict 300 think=false; inicio {cab['fecha_utc']}")
print(f"errores HTTP: {sum(f['http'] != 200 for f in filas)} de {len(filas)}")
ped = sorted({f['pedido'] for f in A}); semillas = sorted({f['seed'] for f in A})
Y = {(f['pedido'], f['seed']): int(f['ok']) for f in A}
print("\n[1] Por pedido (semillas 1..8), criterio: exactamente una llamada a buscar_requisitos")
for p in ped:
    v = [Y[(p, s)] for s in semillas]; k = sum(v); lo, hi = wilson(k, len(v))
    print(f"  {p}: {''.join(map(str, v))}  {k}/{len(v)}  Wilson95 [{lo:.2f}, {hi:.2f}]  «{cab['pedidos'][p]}»")
print("  semilla:", ' '.join(f"s{s}={sum(Y[(p, s)] for p in ped)}/{len(ped)}" for s in semillas))
K = len(ped); m = len(semillas); N = K*m; k = sum(Y.values()); pbar = k/N
lo, hi = wilson(k, N)
print(f"\n[2] Agregado {k}/{N} = {pbar:.3f}; Wilson ingenuo (48 ensayos independientes) [{lo:.2f}, {hi:.2f}]")
# ICC por ANOVA de un factor (estimador clásico para datos binarios)
medias = {p: sum(Y[(p, s)] for s in semillas)/m for p in ped}
msb = m*sum((medias[p]-pbar)**2 for p in ped)/(K-1)
msw = sum((Y[(p, s)]-medias[p])**2 for p in ped for s in semillas)/(K*(m-1))
icc = (msb-msw)/(msb+(m-1)*msw) if (msb+(m-1)*msw) > 0 else float('nan')
deff = 1+(m-1)*icc; neff = N/deff if deff > 0 else float('nan')
print(f"  ICC(ANOVA) = {icc:.3f}; efecto de diseño 1+(m-1)ICC = {deff:.2f}; n efectivo ≈ {neff:.1f} (de {N})")
rng = random.Random(20261028)
bs = []
for _ in range(20000):
    mues = [rng.choice(ped) for _ in ped]; bs.append(sum(medias[p] for p in mues)/K)
bs.sort(); print(f"  bootstrap por conglomerado (se remuestrean los {K} pedidos, 20000 réplicas) IC95 percentil [{bs[499]:.2f}, {bs[19499]:.2f}]")
# homogeneidad entre pedidos: estadístico chi-cuadrado, permutación de los 48 resultados
def chi(Yd):
    tot = sum(Yd.values())/N; s = 0
    for p in ped:
        o = sum(Yd[(p, x)] for x in semillas); e = tot*m
        if 0 < tot < 1: s += (o-e)**2/e + ((m-o)-(m-e))**2/(m-e)
    return s
obs = chi(Y); vals = list(Y.values()); claves = list(Y.keys()); mayor = 0; R = 20000
for _ in range(R):
    rng.shuffle(vals); mayor += chi(dict(zip(claves, vals))) >= obs - 1e-12
print(f"  homogeneidad entre pedidos: chi2 = {obs:.2f} (gl {K-1}); p por permutación = {(mayor+1)/(R+1):.4f}")
# efecto de la semilla (bloques = pedidos): Cochran Q, permutando semillas dentro de cada pedido
def cochran(Yd):
    col = [sum(Yd[(p, s)] for p in ped) for s in semillas]; fil = [sum(Yd[(p, s)] for s in semillas) for p in ped]
    T = sum(col); den = m*T - sum(r*r for r in fil)
    return (m-1)*(m*sum(c*c for c in col) - T*T)/den if den else 0.0
q = cochran(Y); mayor = 0
for _ in range(R):
    Yp = {}
    for p in ped:
        v = [Y[(p, s)] for s in semillas]; rng.shuffle(v); Yp.update({(p, s): v[i] for i, s in enumerate(semillas)})
    mayor += cochran(Yp) >= q - 1e-12
print(f"  efecto de la semilla entre pedidos (¿la semilla s arrastra el mismo resultado en todos?): Cochran Q = {q:.2f} (gl {m-1}); p por permutación = {(mayor+1)/(R+1):.4f}")
# B frente a A-P0
kA = sum(Y[('P0', s)] for s in semillas); kB = sum(int(f['ok']) for f in B); nB = len(B)
def fisher(a, n1, b, n2):
    t = a+b; n = n1+n2; pr = lambda x: comb(n1, x)*comb(n2, t-x)/comb(n, t)
    p0 = pr(a); return sum(pr(x) for x in range(max(0, t-n2), min(t, n1)+1) if pr(x) <= p0 + 1e-12)
print(f"\n[3] P0 semillas 1..8: {kA}/8; P0 semillas 1001..1008: {kB}/{nB} ({''.join(str(int(f['ok'])) for f in B)}); Fisher exacto bilateral p = {fisher(kA, 8, kB, nB):.3f}")
print("\n[4] Reproducibilidad: misma semilla, mismo pedido, otra corrida (bloque C frente a A)")
for f in C:
    a = next(x for x in A if x['pedido'] == f['pedido'] and x['seed'] == f['seed'])
    igual = (a['tool_calls'] == f['tool_calls'] and a['content'] == f['content'])
    print(f"  {f['pedido']} seed {f['seed']}: idéntica = {igual}  (ok {a['ok']} / {f['ok']})")
lat = sorted(f['wall_s'] for f in filas); print(f"\nlatencia por corrida: mediana {lat[len(lat)//2]:.1f} s, máx {lat[-1]:.1f} s, total {sum(lat)/60:.1f} min")
