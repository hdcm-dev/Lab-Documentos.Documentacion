# Abogado del diablo, ciclo 2, AD-03. Cuánto texto dedica la guía a cada respuesta de la tercera
# pregunta del caso: 8a (registro del entorno + SBOM, para todo equipo) y 8b (procedencia firmada,
# condicional). Uso: python3 -I medir.py <guia.md>
import re, sys
L = open(sys.argv[1], encoding="utf-8").read().split("\n")
def sec(ini, fin):  # palabras entre el encabezado que empieza con ini y el siguiente que empieza con fin
    a = next(i for i, l in enumerate(L) if l.startswith(ini))
    b = next(i for i, l in enumerate(L) if i > a and l.startswith(fin))
    return a + 1, b, sum(len(l.split()) for l in L[a:b])
for rot, ini, fin in [
    ("§9.2.4 Procedencia SLSA y firma (8b)", "#### 9.2.4", "### 9.3"),
    ("§9.2.3 SBOM (8a)", "#### 9.2.3", "#### 9.2.4"),
    ("§11.2.8 SBOM y procedencia políglota", "#### 11.2.8", "#### 11.2.9"),
]:
    a, b, w = sec(ini, fin); print(f"{rot:42s} L{a}-L{b}  {w} palabras")
txt = "\n".join(L)
for pat in [r"registro del entorno", r"registro de entorno", r"registrar-entorno", r"cosign", r"SLSA", r"builder\.id", r"atestaci"]:
    print(f"{pat:24s} {len(re.findall(pat, txt, re.I))} apariciones")
code = re.findall(r"```(\w*)\n(.*?)```", txt, re.S)
reg = [c for lang, c in code if re.search(r"dotnet-sdk=|toolchain: |registrar-entorno|IMAGEN_DIGEST", c)]
slsa = [c for lang, c in code if re.search(r"cosign|attest|provenance|builder", c)]
print(f"bloques de código que muestran el registro del entorno (formato/contenido): {len(reg)}")
for c in reg: print("   >", c.strip().splitlines()[0][:110])
print(f"bloques de código de procedencia/firma: {len(slsa)}")
for c in slsa: print("   >", c.strip().splitlines()[0][:110])
