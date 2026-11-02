# Intervalos de Wilson al 95 % para las tasas que sostienen decisiones en BIT-16-04 (cálculo, sin modelo).
import math
def wilson(k, n, z=1.96):
    p = k / n; d = 1 + z*z/n; c = p + z*z/(2*n); r = z*math.sqrt(p*(1-p)/n + z*z/(4*n*n))
    return (c - r) / d, (c + r) / d
casos = [("EA-6 vía B omite recuperar (BIT-16-04 §1)", 2, 5), ("EA-6 salida-real: vía B pide buscar_requisitos", 3, 5),
 ("EA-6 vía A acierta y cita (corrida única)", 1, 1), ("X2 D1 falso aceptado si no hubiera confirmación", 2, 10),
 ("X2 D1 altera CP inválido", 10, 10), ("E-B2 válida para el dominio", 11, 13), ("E-B3 aprobación emitida", 3, 3),
 ("E-B5 coloquial→Medios", 4, 7), ("Juez: acuerdo 16/20 (hipotético, MI-16 tope)", 16, 20), ("Juez: acuerdo 8/10 (hipotético, MI-16 piso)", 8, 10),
 ("Corpus B *Policy: hit@1 (sonda AH-02)", 5, 6)]
for nombre, k, n in casos:
    lo, hi = wilson(k, n); print(f"{nombre}: {k}/{n} = {k/n:.2f}  IC95 Wilson [{lo:.2f}, {hi:.2f}]")
# regla del tres: con 0 fallas en n, cota superior 95 % ~ 3/n
for n in (3, 5, 10, 30): print(f"0 fallas en n={n}: cota superior 95 % ≈ {1-0.05**(1/n):.2f} (regla del tres {3/n:.2f})")
