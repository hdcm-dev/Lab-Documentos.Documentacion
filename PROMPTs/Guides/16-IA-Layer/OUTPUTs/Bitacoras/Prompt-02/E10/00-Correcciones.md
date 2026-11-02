# E10 · Correcciones de la verificación de etapa 3 (H-1…H-9) y terminología

- **Fecha:** 2026-11-02 (reanudación tras apagado). Guía al empezar: sha256 `5feb55e6…fa2f8d` (no `ec4185d4…` de E9): el intento anterior, cortado el 2026-11-01 21:31, dejó cambios sin registrar. Copia de ese estado en el scratchpad de la sesión.

## 1. Relevamiento: lo que el intento cortado ya había aplicado

| Hallazgo | Estado encontrado | Cómo se comprobó |
|---|---|---|
| H-1 | **Hecho.** Tabla H.1 sin rutas: columna «Registro» nombra la etapa; la definición dice que el registro de trabajo no se publica. 0 «Bitacoras» en el libro | `grep -c Bitacoras` = 0 |
| H-3 | **Hecho.** Línea Compatible-con a la 0.12.0; 45 remisiones `[Guía §x]` cotejadas por script contra los encabezados: todas caen en la sección del tema (ADR en §14.x, escaleras §4.2, etc.) | script de cotejo |
| H-4 | **Hecho.** 0 «Historia (» en `Examples/`; la procedencia pasó a la última fila de la Tabla H.1 («corrección E10») | `grep -rc` |
| H-5 | **Aplicado sin mesa:** `contar.sh` con Parte VII 7.500 y Anexos 13.000, y salida 1 si una parte supera | lectura de `tools/contar.sh` |
| H-8 | **Parcial:** el índice del Prólogo ya usa `#parte-7` y no quedan enlaces `#parte-vi`/`#sNN`; seguían 20 menciones de «Anexo H» sin enlace | `grep` |
| Terminología | **Hecho en el Conocimiento** (l. 346–347: primera mención «contenedor nativo (*native shell*; en la jerga del proyecto, "cascarón")», «app híbrida con contenido OTA», «paquete de actualización OTA firmado (*update bundle*)»). El libro, los README y `Compuertas/README.md` no hablan de la app MAUI ni del puente: nada que aplicar. 0 «App Shell», 0 «cascarón» suelto | `grep -rniI` |
| H-7, H-9 | **Sin hacer** | — |

## 2. Lo hecho en esta reanudación

- **H-5 y H-7:** mesa breve, `01-Mesa-H5-H7.md`. H-5: se ratifica el traspaso (5/5). H-7: se ratifica §16.7 (5/5): «final de la Parte VI» era la numeración 0.11.0 de la Parte de Integración. Sin edición del libro.
- **H-8:** 20 menciones de «Anexo H» en el cuerpo pasan a `[Anexo H](#anexo-h)` (perl; el encabezado y bloques de código intactos).
- **H-9:** README 14: «Sección de la guía» §9.7 → §10.7 y sección nueva «El código, paso a paso» con los fragmentos de `PluginSk.cs` y `HerramientaMeai.cs` y la salida sin modelo que comenta §10.7 (copiados del libro; la línea final de `HerramientaMeai.cs` cotejada con la fuente).

## 3. Compuertas

| Compuerta | rc | Resultado |
|---|---|---|
| `tools/contar.sh` | 0 | 59.338/60.000; Anexos 12.998/13.000; ninguna parte SOBRE |
| `verificar-markdown.py guia` / `ejemplos Examples` / `arbol Conocimientos` | 0/0/0 | 1.610 enlaces internos, 187/187 REF; 18 README; 16 enlaces |
| `compuerta-referencias.sh` | 0 | 0 rotas en 21 archivos |
| `compuerta-intervalos.py` (libro + Evidencia/R-LLM) | 0 | 28/28; 21/21 |
| `compuerta-rpriv.sh` (libro, Examples, Conocimientos) | 0 | 0 hallazgos (sin COMPUERTAS_DIR) |
| `mermaid.sh` libro y Conocimiento | 0 | todos ok |
| docs-guard `mermaid-arroba` (dac-LD-comun, sólo lectura) | 0 | verde, 27 bloques |

Guía sha256 `cd3fc125a390d713dabb8f3c5067ad9d017e1bcae68a1730fce8516f539432d2`.

## 4. Pendientes

1. **H-2** (coordinación): sumar `github.blog`, `shopify.engineering`, `www.anthropic.com`, `www.linkedin.com` a `dominios.txt` en el PR único de la guía 16, con aviso a DAC (acordado 2026-11-01).
2. **H-6** (PO): revisión humana D-23 y P-14.
3. **Nuevo (P2):** seis README (05, 09, 10, 11, 14, 15) y dos archivos de 15 (`entradas/salidas-07.v1.json`, `CongeladorDeSalidas.cs`) nombran rutas de `Bitacoras/Evidencia/` de LDD: mismo problema que H-1 en los ejemplos. No se tocó (fuera del alcance encomendado; el código de 15 afecta oráculos).
4. Anexos a 2 palabras del tope: todo agregado debe compensarse.
5. H-10 y P-E9-2/P-E9-3 siguen para E11.

## 5. Mensajes ajenos

Ninguno.
