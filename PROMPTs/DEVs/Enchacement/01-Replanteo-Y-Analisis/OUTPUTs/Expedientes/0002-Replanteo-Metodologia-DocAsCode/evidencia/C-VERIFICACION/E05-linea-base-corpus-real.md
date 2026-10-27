# E05 — Línea de base: cuánto rojo da cada validador sobre el corpus real (costo de adopción y falsos positivos)
Método: comando en contenedor efímero (--rm) · Fecha-hora: 2026-10-26 (tarde, -03:00) · Quién: comisión C-VERIFICACION

Corpus: corpus/base = copia de los 15 .md de la guía y Examples/ (Lab-Documentos 5d5c2b4 + árbol de trabajo; huella de la guía 01659b6e22106ea0); /o/Bitacoras y /o/Expedientes/.../actuaciones = bitácoras y folios 001-004 de esta corrida.

## markdownlint-cli2 0.18.1, configuración por defecto
```text
    332 MD013/line-length
     13 MD025/single-title
      1 MD033/no-inline-html
      1 MD032/blanks-around-lists
      1 MD028/no-blanks-blockquote
```
## markdownlint-cli2 con MD013 off, MD025 front_matter_title vacío, MD033 off
```text
Summary: 2 error(s)
corpus/base/Examples/Lanzar-Example.md:4 MD032/blanks-around-lists Lists should be surrounded by blank lines [Context: "> - Leer y ejecutar `/LAB/Lab-..."]
corpus/base/Sistema-Documentador-Tecnico-Guide.md:87 MD028/no-blanks-blockquote Blank line inside blockquote
```
## Esquema de frontmatter, validadores propios y mermaid
```text
corpus/base/Sistema-Documentador-Tecnico-Guide.md
11:9-11:66 warning Must NOT have duplicate items (items ## 1 and 0 are identical) • /w/tools/schemas/cuerpo.schema.json • #/properties/traces/uniqueItems frontmatter-schema remark-lint

⚠ 1 warning
== cita-linea
corpus/base: citas-a-raiz=1 sin-linea=1
/o/Bitacoras: citas-a-raiz=44 sin-linea=27
== ocultos
corpus/base: ocultos=0
/o/Bitacoras: ocultos=0
== url-fecha
corpus/base: urls=6 sin-fecha=6
/o/Bitacoras: urls=227 sin-fecha=225
== mermaid-parse
corpus/base: bloques=6 invalidos=0
/o/Bitacoras: bloques=43 invalidos=1
```

## Folios 001–004 del expediente (únicos que esta comisión lee: trabaja a ciegas)
```text
cita-linea: citas-a-raiz=19 sin-linea=19
ocultos: ocultos=0
url-fecha: urls=0 sin-fecha=0
mermaid-parse: bloques=5 invalidos=0
/o/Bitacoras/I03-Documentacion-Para-Agentes-IA.md:210: mermaid inválido: Parse error on line 12:
```
