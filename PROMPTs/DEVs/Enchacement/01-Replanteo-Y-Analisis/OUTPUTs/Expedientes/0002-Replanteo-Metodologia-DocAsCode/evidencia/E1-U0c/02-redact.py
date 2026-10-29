#!/usr/bin/env python3
# redact2 — reemplazo de literales privados por alias (E1-U0c, versión publicable del script de reemplazo).
#
# Sustituye a la «copia redactada» original: este archivo no contiene ningún literal privado. Los pares
# literal -> alias se leen de un archivo de patrones que vive fuera de todo repositorio y no se publica.
#
# Uso:
#   redact2.py --patrones <archivo> RAIZ                      # todos los archivos de texto bajo RAIZ
#   redact2.py --patrones <archivo> --lista <lista> [--base DIR]  # sólo las rutas de la lista (relativas a DIR)
#   --verificar   no escribe: informa cuántos literales quedan y termina con 1 si queda alguno
#
# Archivo de patrones: una línea por par, «literal<TAB>alias»; las líneas vacías y las que empiezan con «#» se
# ignoran. Se aplica primero el literal más largo, así una ruta completa gana a su sufijo. Sin --patrones se usa
# la variable REDACT_PATRONES. El script se niega a correr si el archivo de patrones está dentro de un árbol de git.
#
# La salida informa por alias (número de reemplazos y de archivos), nunca el literal.
import argparse, os, pathlib, sys


def dentro_de_git(p: pathlib.Path) -> bool:
    for d in [p.parent, *p.parent.parents]:
        if (d / ".git").exists():
            return True
    return False


def leer_patrones(p: pathlib.Path):
    pares = []
    with open(p, encoding="utf-8", newline="") as f:
        for n, linea in enumerate(f, 1):
            linea = linea.rstrip("\r\n")
            if not linea or linea.startswith("#"):
                continue
            if "\t" not in linea:
                sys.exit(f"patrones: línea {n} sin tabulador")
            lit, alias = linea.split("\t", 1)
            if not lit:
                sys.exit(f"patrones: línea {n} con literal vacío")
            pares.append((lit, alias))
    return sorted(pares, key=lambda x: -len(x[0]))


def archivos(args):
    if args.lista:
        base = pathlib.Path(args.base)
        for l in open(args.lista, encoding="utf-8"):
            l = l.strip()
            if l:
                yield base / l
    else:
        for f in sorted(pathlib.Path(args.raiz).rglob("*")):
            if f.is_file() and ".git" not in f.parts:
                yield f


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--patrones", default=os.environ.get("REDACT_PATRONES"))
    ap.add_argument("--lista")
    ap.add_argument("--base", default=".")
    ap.add_argument("--verificar", action="store_true")
    ap.add_argument("raiz", nargs="?")
    args = ap.parse_args()
    if not args.patrones:
        sys.exit("falta --patrones (o REDACT_PATRONES)")
    if not args.lista and not args.raiz:
        sys.exit("falta RAIZ o --lista")
    pat = pathlib.Path(args.patrones).resolve()
    if dentro_de_git(pat):
        sys.exit("el archivo de patrones está dentro de un árbol de git: se niega")
    pares = leer_patrones(pat)
    cnt, fil, quedan = {}, {}, 0
    for f in archivos(args):
        try:
            with open(f, encoding="utf-8", newline="") as h:
                t = h.read()
        except (UnicodeDecodeError, FileNotFoundError, IsADirectoryError):
            continue
        o = t
        for lit, alias in pares:
            n = t.count(lit)
            if n:
                cnt[alias] = cnt.get(alias, 0) + n
                fil.setdefault(alias, set()).add(str(f))
                t = t.replace(lit, alias)
        if t != o:
            quedan += 1
            if not args.verificar:
                with open(f, "w", encoding="utf-8", newline="") as h:
                    h.write(t)
    for alias in sorted(cnt):
        print(f"{cnt[alias]}\t{len(fil[alias])}\t{alias}")
    modo = "con literales" if args.verificar else "modificados"
    print(f"archivos {modo}: {quedan}")
    return 1 if (args.verificar and quedan) else 0


if __name__ == "__main__":
    sys.exit(main())
