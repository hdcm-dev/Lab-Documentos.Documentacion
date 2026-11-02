"""Compuerta documental: frontmatter, prefijos, trazas y enlaces de una carpeta.

Uso: python3 scripts/docs-guard.py <carpeta> [--registro docs/_gobierno/prefijos.txt]
     [--excepciones docs/_gobierno/excepciones.txt] [--solo-avisar]

Sale 0 si no hay errores y 1 si hay alguno. Determinista y sin red: lee sólo archivos del repo.
Con --solo-avisar informa los errores como avisos y sale 0 (línea de base de lo heredado).
"""

import hashlib
import pathlib
import re
import sys

CAMPOS = ["doc_id", "doc_type", "title", "description", "status", "origin", "owner",
          "last_review", "audience", "traces"]
ESTADOS = {"borrador", "vigente", "obsoleto"}
ORIGENES = {"human", "ia-assisted", "ia-generated"}
ENLACE = re.compile(r"\]\(([^)\s]+)\)")
TRAZA = re.compile(r"^([A-Z][A-Z0-9]*)-[A-Z0-9-]+?(?:@(\d+)\.(\d+))?$")


def argumento(nombre, defecto):
    if nombre in sys.argv:
        return sys.argv[sys.argv.index(nombre) + 1]
    return defecto


def leer_registro(ruta):
    prefijos = {}
    for linea in pathlib.Path(ruta).read_text(encoding="utf-8").splitlines():
        linea = linea.strip()
        if not linea or linea.startswith("#"):
            continue
        partes = linea.split(None, 2)
        prefijos[partes[0]] = partes[1]
    return prefijos


def leer_frontmatter(texto):
    lineas = texto.splitlines()
    if not lineas or lineas[0].strip() != "---":
        return None
    datos = {}
    for linea in lineas[1:]:
        if linea.strip() == "---":
            return datos
        if ":" in linea and not linea.startswith(" "):
            clave, valor = linea.split(":", 1)
            valor = valor.strip()
            if valor.startswith("[") and valor.endswith("]"):
                valor = [v.strip() for v in valor[1:-1].split(",") if v.strip()]
            datos[clave.strip()] = valor
    return None


def lineas_fuera_de_cercos(texto):
    cerco = False
    for n, linea in enumerate(texto.splitlines(), 1):
        if linea.strip().startswith("```"):
            cerco = not cerco
            continue
        if not cerco:
            yield n, linea


def main():
    if len(sys.argv) < 2:
        print("uso: docs-guard.py <carpeta>")
        return 2
    carpeta = pathlib.Path(sys.argv[1])
    registro = leer_registro(argumento("--registro", "docs/_gobierno/prefijos.txt"))
    ruta_exc = pathlib.Path(argumento("--excepciones", "docs/_gobierno/excepciones.txt"))
    excepciones = set()
    if ruta_exc.exists():
        for linea in ruta_exc.read_text(encoding="utf-8").splitlines():
            if linea.strip() and not linea.startswith("#"):
                excepciones.add(linea.split()[0])
    solo_avisar = "--solo-avisar" in sys.argv

    documentos = {}
    errores, avisos = [], []
    archivos = sorted(p for p in carpeta.rglob("*.md") if "_legacy" not in p.parts)
    for md in archivos:
        texto = md.read_text(encoding="utf-8")
        fm = leer_frontmatter(texto)
        if fm is None:
            errores.append(f"{md}: sin frontmatter")
            continue
        for campo in CAMPOS:
            if campo not in fm:
                errores.append(f"{md}: falta el campo {campo}")
        if fm.get("origin") not in ORIGENES:
            errores.append(f"{md}: origin fuera del vocabulario")
        elif fm.get("origin") != "human" and "confidence" not in fm:
            errores.append(f"{md}: falta confidence (origin no es human)")
        if fm.get("status") not in ESTADOS:
            errores.append(f"{md}: status fuera de borrador|vigente|obsoleto")
        desc = fm.get("description", "")
        if not 10 <= len(desc) <= 160:
            errores.append(f"{md}: description fuera de 10 a 160 caracteres")
        doc_id = fm.get("doc_id", "")
        prefijo = doc_id.split("-", 1)[0]
        if registro.get(prefijo) != "interno":
            errores.append(f"{md}: doc_id {doc_id} con prefijo fuera del registro interno")
        if doc_id in documentos:
            errores.append(f"{md}: doc_id {doc_id} declarado dos veces (ambiguo)")
        documentos[doc_id] = (md, fm.get("version", ""))
        for n, linea in lineas_fuera_de_cercos(texto):
            for m in ENLACE.finditer(linea):
                destino = m.group(1)
                if re.match(r"^[a-z]+:", destino) or destino.startswith("#"):
                    continue
                if destino.startswith("/"):
                    errores.append(f"{md}:{n}: enlace absoluto {destino}")
                    continue
                if not (md.parent / destino.split("#")[0]).exists():
                    errores.append(f"{md}:{n}: enlace roto {destino}")

    for doc_id, (md, _) in documentos.items():
        fm = leer_frontmatter(md.read_text(encoding="utf-8"))
        for traza in fm.get("traces", []) or []:
            m = TRAZA.match(traza)
            if not m:
                errores.append(f"{md}: traza mal formada {traza}")
                continue
            prefijo = m.group(1)
            ambito = registro.get(prefijo)
            if ambito is None:
                errores.append(f"{md}: traza {traza} con prefijo fuera del registro")
            elif ambito == "externo":
                avisos.append(f"{md}: traza externa {traza} no se resuelve acá")
            else:
                base = traza.split("@")[0]
                if base not in documentos:
                    errores.append(f"{md}: traza {traza} no resuelve")
                elif m.group(2):
                    version = documentos[base][1]
                    if version.split(".")[:2] != [m.group(2), m.group(3)]:
                        errores.append(f"{md}: traza {traza} desfasada (vigente {version})")

    activos = []
    for e in errores:
        huella = hashlib.sha256(e.encode("utf-8")).hexdigest()[:16]
        (avisos if huella in excepciones else activos).append(f"[{huella}] {e}")
    for a in avisos:
        print(f"AVISO {a}")
    for e in activos:
        print(("AVISO " if solo_avisar else "ERROR ") + e)
    print(f"Documentos: {len(archivos)}; errores: {len(activos)}; avisos: {len(avisos)}")
    return 0 if solo_avisar or not activos else 1


if __name__ == "__main__":
    sys.exit(main())
