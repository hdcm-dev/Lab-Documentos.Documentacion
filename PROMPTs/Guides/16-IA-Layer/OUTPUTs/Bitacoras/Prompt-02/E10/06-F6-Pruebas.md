# E10 · Fase 6 · Corrección de pruebas (galeradas) — 2026-11-02

## 0. Reanudación tras corte de red (ssh)
Al retomar, el libro no estaba en el sha256 de cierre de F5 (`40b42d4c…617f`) sino en `062f6508…` (mtime 07:17:45, posterior al cierre de F5 a las 07:13). El diff contra la copia previa a F5 mostró, además de los rótulos de F5, **un único cambio no registrado** del intento de F6 cortado:
- Libro l. 2685 (ADR, REF-184): `«not just the "positive" ones»` → `«not just the “positive” ones»` (comillas de segundo nivel, mismo criterio que F4 l. 1854). Se conserva y se registra aquí.
Nada en el Conocimiento ni en los README cambió después de F5. No quedó ningún archivo 06-* previo.

## 1. Criterios
Lectura de galeradas por script: render en GitHub (cercos balanceados, columnas de tablas, etiquetas HTML crudas, backticks/asteriscos impares), enlaces y anclas, código citado contra `Examples/`, compuertas de E3.

## 2. Controles
| Control | Resultado |
|---|---|
| Cercos de código balanceados (libro, Conocimiento, 17 README) | 0 abiertos |
| Columnas de tablas | 0 desajustes |
| Etiquetas HTML crudas fuera de código (aparte de `<a id>`) | 1: l. 4002 `WithTools<T>()` → corregido |
| Backticks/asteriscos impares | 3 falsos positivos (README 04 l.71 y 14 l.32: span con doble backtick válido; README 10 l.16: `\*` escapado) |
| Código citado: líneas de bloques `csharp` (≥25 car.) del libro y README contra los `.cs` de su ejemplo | 405/405 literales |
| Enlaces internos/relativos del árbol (`verificar-markdown.py arbol`) | 1.626 internos, 35 relativos, 0 rotos |
| Salidas esperadas vs registros | cubierto por `compuerta-intervalos.py` (21/21 filas) y F1/F2; sin cambios |

## 3. Cambio
1. **Libro l. 4002 (REF-133):** `(WithTools<T>(); …` → ``(`WithTools<T>()`; …``. Antes, GitHub tomaba `<T>` como etiqueta HTML y la borraba del render («WithTools()»).

## 4. Compuertas (después)
| Compuerta | rc | Resultado |
|---|---|---|
| `tools/contar.sh` | 0 | 59.373/60.000 |
| `verificar-markdown.py guia <libro>` · `arbol <guía>` | 0 · 0 | 0 hallazgos |
| `compuerta-referencias.sh` | 0 | 0 rotas en 21 archivos |
| `compuerta-intervalos.py <libro> Evidencia/R-LLM` | 0 | 28/28; 21/21 |
| `compuerta-cabeceras.sh Evidencia` | 0 | 0 |
| `compuerta-rpriv.sh` libro, Examples, Conocimientos | 0 | 0 hallazgos |
| `mermaid.sh` libro · Conocimiento | 0 · 0 | 25 · 2 |
| docs-guard `mermaid-arroba` (sólo lectura) | 0 | verde, 27 bloques |

sha256 final del libro: `5ebbfdbb2497b9e2e197851f453cb335311ca1d6a301548249e1a74db87b5e12`.

## 5. Pendientes
1. Capturas de render con `web.sh` en escritorio y móvil (U-4.2): no tomadas en esta fase; el render se verificó por script. Para E11 o mesa B.
2. Heredados de F5: margen de palabras agotado (Anexos 13.000/13.000); cursiva de anglicismos técnicos; separador de miles.
3. Heredado de F1: rutas absolutas en dos archivos de datos/código del ejemplo 15 (E11).

## 6. Mensajes ajenos
Ninguno.
