# Abogado del diablo, ciclo 3, experimento 04: dónde se repite la guía y cuánto pesa cada parte.
# Uso: python3 -I medir.py <guía.md>
import re, sys
t = open(sys.argv[1], encoding="utf-8").read()
lineas = t.split("\n")
def sin_codigo(s):
    return re.sub(r"```.*?```", "", s, flags=re.S)
cuerpo = sin_codigo(t)
print("palabras totales (wc -w equivalente):", len(t.split()))
# peso por bloque mayor
secs = [(i, l) for i, l in enumerate(lineas) if l.startswith("## ")]
secs.append((len(lineas), "FIN"))
print("\n== palabras por sección de nivel 2 (con código y tablas)")
for (a, ta), (b, _) in zip(secs, secs[1:]):
    print(f"{len(' '.join(lineas[a:b]).split()):6d}  {ta[:70]}")
print("\n== afirmaciones repetidas (apariciones fuera de bloques de código)")
pats = {
 "el contenedor no arregla / el cp1252 falla igual adentro (E5-1)": r"E5-1",
 "Visual Studio sin devcontainer .NET": r"devcontainer.{0,80}(Visual Studio|ESC-01)|(Visual Studio|ESC-01).{0,80}devcontainer",
 "A compatible .NET SDK was not found": r"A compatible \.NET SDK was not found",
 "SDK exacto": r"SDK exacto",
 "[no verificado] (requiere Windows)": r"\*\*\[no verificado\]\*\* \(requiere Windows\)",
 "hook se saltea con --no-verify": r"--no-verify",
 "imagen/receta: etiqueta fija de SDK y SO": r"etiqueta fija",
 "runner alojado": r"runner alojado",
 "digest": r"\bdigest",
 "8a / 8b": r"\b8[ab]\b",
}
for k, p in pats.items():
    print(f"{len(re.findall(p, cuerpo)):4d}  {k}")
print("\n== tablas «Aplicación por escenario» (n.4) frente al mapa de §3.6: filas ESC-0n")
print("filas que empiezan con '| ESC-0':", sum(1 for l in lineas if l.startswith("| ESC-0")))
