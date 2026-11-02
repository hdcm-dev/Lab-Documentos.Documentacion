# E10 · Fase 5 de 6 — Diseño editorial (Comisión B)

Fecha: 2026-11-02. Alcance: libro 0.12.0, Conocimiento y README de `Examples/`. Sin cambios de contenido (C-4.3).

## 1. Criterios
Jerarquía de títulos sin saltos; rótulo «Tabla/Figura n.m» bajo cada tabla y cada diagrama, numeración correlativa por capítulo o anexo; mermaid ≤ 15 nodos (U-4.3); anclas resolubles; tope de 60.000 palabras y topes por parte (`contar.sh`).

## 2. Controles (por script)
- Encabezados: 0 saltos de nivel.
- Rótulos: 62 antes; numeración correlativa sin huecos. 5 mermaid sin rótulo (l. 1704, 1867, 2896, 2965, 4139).
- Nodos por mermaid: máximo 15 (fig. 15.1: 15 nodos más 7 subgrafos). Ninguno excede U-4.3.
- Conocimiento: 2 mermaid, `mermaid.sh` rc 0. README: sin mermaid.

## 3. Cambios en el libro
1. Tras el mermaid del escalón 3 (§9.7), se agregó «Figura 9.4. El escalón 3: el modelo elige qué sigue.»; la antigua 9.4 (MCP) pasó a «Figura 9.5». No había remisiones textuales a «Figura 9.4».
2. §10.2: se agregó «Figura 10.1. Los tres ecosistemas.»
3. §15.2: se agregó «Figura 15.1. La imagen redibujada con los tipos de la demo.»
4. §15.3: se agregó «Figura 15.2. PD-6 en dos peticiones dentro del chat del circuito.»
5. Anexo E.3: se agregó «Figura E.1. Fases del arnés.»
6. Anexo E.3 l. 4145, para devolver los Anexos a su tope: antes «corre cuatro fases, de a una y cada una en su contenedor» → después «corre cuatro fases sucesivas, cada una en su contenedor» (mismo sentido).

Primer intento con rótulos más largos: `contar.sh` rc 1 (Parte V 8.308/8.300, Anexos 13.009/13.000). Se acortaron los rótulos.

sha256 del libro: antes `a1d2f567…be03`, después `40b42d4c8d099d44fa995446f9593c9d338a4de29ea01a1cf7c9be3ba2b8617f`.

## 4. Compuertas (después)
| Compuerta | rc | Resultado |
|---|---|---|
| `tools/contar.sh` | 0 | 59.373/60.000; Parte V 8.293/8.300; Anexos 13.000/13.000 |
| `verificar-markdown.py` guia · ejemplos · arbol | 0 · 0 · 0 | — |
| `compuerta-referencias.sh` | 0 | — |
| `compuerta-intervalos.py` | 0 | 28/28; 21/21 |
| `compuerta-cabeceras.sh Bitacoras/Evidencia` | 0 | — |
| `compuerta-rpriv.sh` libro, Examples, Conocimientos | 0 | 0 hallazgos |
| `mermaid.sh` libro · Conocimiento | 0 · 0 | 25 bloques en el libro |
| docs-guard `mermaid-arroba` (sólo lectura) | 0 | verde, 0 errores, 0 avisos |

## 5. Pendientes
1. Margen de palabras agotado: Anexos 13.000/13.000, Parte V a 7 palabras. La fase 6 no puede agregar texto en esas partes sin recortar.
2. Heredado de F4: convención de cursiva para anglicismos técnicos (*pipeline*, *streaming*, *embeddings*). No se aplicó: afecta a decenas de apariciones y requiere un criterio común. Queda para la mesa B.
3. Heredado de F4: separador de miles en cifras de 4 dígitos.

## 6. Mensajes ajenos
Ninguno.
