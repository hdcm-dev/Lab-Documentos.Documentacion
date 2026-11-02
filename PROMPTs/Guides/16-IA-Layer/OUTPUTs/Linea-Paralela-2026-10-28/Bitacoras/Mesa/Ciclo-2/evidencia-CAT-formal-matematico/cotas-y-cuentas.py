# Cuentas de control del informe CAT-formal-matematico (2026-10-28). Sin red ni modelo.
from math import comb
print("cota exacta unilateral 95 % para 0/n (Clopper-Pearson): 1-0.05**(1/n)")
for n in (5,10,12,16): print(f"  n={n}: {1-0.05**(1/n):.3f}")
print("Wilson bilateral 95 % para 0/10: limite superior 0.278 (ver wilson-salida.txt)")
print("prueba del signo bilateral exacta, todos los discordantes en un sentido: p = 2*0.5**d")
for d in (5,6,7,9,10): print(f"  d={d}: p={2*0.5**d:.4f}")
print("prueba del signo con discordantes mixtos (la regla del codigo dice 'no separado'):")
def signo(a,b):
    n=a+b; k=min(a,b); return min(1,2*sum(comb(n,i) for i in range(k+1))/2**n)
for a,b in ((7,1),(9,1),(8,2),(2,1),(3,2)): print(f"  {a} vs {b}: p={signo(a,b):.4f}")
print("estimando 'pasa en m/m': si cada semilla acierta con prob p, P(pasa 3/3)=p**3")
for p in (0.7,0.8,0.9,0.95): print(f"  p={p}: p^3={p**3:.3f}; p^5={p**5:.3f}")
print("presupuesto E.5 regla 5: 45 min / 27 s =", round(45*60/27), "llamadas; K=10 x m=5 =", 10*5, "; 4 x m=10 =", 40)
print("azar hit@3 con 12 enunciados y 2 relevantes: 1-C(10,3)/C(12,3) =", round(1-comb(10,3)/comb(12,3),3))
