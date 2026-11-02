# Wilson 95 % (z=1,959964) para los k/n que cita la guía; compara con el intervalo impreso.
import math, sys
z=1.959964
def w(k,n):
    p=k/n; d=1+z*z/n; c=(p+z*z/(2*n))/d; h=z*math.sqrt(p*(1-p)/n+z*z/(4*n*n))/d
    return max(0,c-h), min(1,c+h)
casos=[(10,10),(0,10),(8,10),(9,10),(1,10),(5,10),(7,10),(4,10),(11,12),(10,12),(8,12),(12,12),(12,16),(5,5),(3,3),(37,48)]
for k,n in casos:
    a,b=w(k,n); print(f"{k}/{n}: [{a:.3f}; {b:.3f}]")
