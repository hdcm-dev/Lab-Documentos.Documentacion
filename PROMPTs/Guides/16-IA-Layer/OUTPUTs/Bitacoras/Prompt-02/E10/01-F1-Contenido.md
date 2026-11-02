# E10 · Fase 1 · Edición de contenido (intervención 1/6)

- **Fecha:** 2026-11-02 · **Responsable:** Comisión A (P-07). Guía al empezar y al terminar: sha256 `cd3fc125a390d713dabb8f3c5067ad9d017e1bcae68a1730fce8516f539432d2` (el libro no cambió en esta fase).
- **Criterios:** exactitud técnica, completitud, autocontención y respaldo de cada afirmación verificable.

## 1. Controles de respaldo (sin cambios necesarios)

| Control | Resultado |
|---|---|
| 1.020 remisiones `§x.y` contra 162 encabezados numerados | 0 sin destino |
| 82 identificadores en código (`Nombre_Con_Guion`) citados por el libro contra `Examples/` y `Demos/` | todos existen (los 26 «faltantes» del primer barrido eran variables de entorno o estaban en `Demos/`; cotejados uno por uno) |
| Versiones de `Examples/Directory.Packages.props` contra el libro (Anexo F) | coinciden; los dos desvíos del barrido eran falsos positivos (13.6.1 es de Aspire; 4.3.2 es NUnit en la misma fila) |
| Conteos del Prólogo (17 ejemplos, 7 partes, anexos A–H) | coinciden con `Examples/` y con los encabezados |
| §8: pruebas `Validador_CitaNoRecuperada_SeRechazaSiempre`, `Validador_SinCita` | existen en `07/Pruebas/RagConCitasTests.cs` |

## 2. Cambios (autocontención: P2 heredado de `00-Correcciones.md` §4.3)

Seis README de ejemplos remitían a rutas absolutas del registro de trabajo, que está excluido de git (`.git/info/exclude` de LDD): para el lector público eran remisiones sin destino. Mismo criterio que H-1.

| Archivo | Antes | Después |
|---|---|---|
| `05/README.md` l. 61 | «Registros en `/LAB/…/Bitacoras/Evidencia/R-LLM/`:» | «Registros en la carpeta R-LLM del registro de trabajo de la edición, que no se publica (procedencia en el Anexo H de la guía):» |
| `09/README.md` l. 89 | ruta absoluta a `R-LLM/09-….jsonl` y `…/Evidencia/Arnes/…` | nombres de archivo sin ruta + «(registro de trabajo de la edición, que no se publica; procedencia en el Anexo H de la guía)» |
| `10/README.md` l. 90 | ruta absoluta a `Evidencia/10-…/` y `R-LLM/10-….jsonl` | ídem, «`10-Workflow-Y-Contraejemplo.jsonl` de la carpeta R-LLM» |
| `11/README.md` l. 88 | ruta absoluta | ídem |
| `14/README.md` l. 93 | ruta absoluta | ídem, «de la carpeta R-LLM» |
| `15/README.md` l. 95 | ruta absoluta | ídem |

Copias previas: scratchpad de la sesión, `e10f1/*.README.md`. Primera pasada dejó `R-LLM/…` entre comillas invertidas en 05, 10 y 14 y `compuerta-referencias.sh` las leyó como rutas (rc 1, 3 rotas); se reescribió sin barra y quedó en 0.

## 3. Compuertas (después de los cambios)

| Compuerta | rc | Resultado |
|---|---|---|
| `tools/contar.sh` | 0 | 59.338/60.000, ninguna parte sobre su tope |
| `verificar-markdown.py guia <libro>` · `ejemplos Examples` · `arbol Conocimientos` | 0 · 0 · 0 | 18 README |
| `compuerta-referencias.sh` | 0 | 0 rotas en 21 archivos |
| `compuerta-intervalos.py <libro> Evidencia/R-LLM` | 0 | 28/28; 21/21 |
| `compuerta-cabeceras.sh <libro>` | 0 | — |
| `compuerta-rpriv.sh` (libro, Examples, Conocimientos) | 0 | 0 hallazgos |
| `mermaid.sh` / docs-guard | — | no se repitió: libro y Conocimiento sin cambios en bytes desde la corrida verde de `00-Correcciones.md` |

## 4. Pendientes para las fases siguientes

1. **P2, código de 15** (`entradas/salidas-07.v1.json` l. 13, `Application/CongeladorDeSalidas.cs` l. 69): siguen con la ruta absoluta al registro. Es dato de un oráculo congelado; cambiarlo exige recalcular (E11, `recalcular-oraculos.sh`). Se deja para E11.
2. H-2 (dominios.txt, coordinación con DAC), H-6 (PO: D-23 y P-14), H-10: sin cambio.
3. Anexos a 2 palabras del tope: F3–F5 deben compensar todo agregado.
4. Fase 2 (académica): muestreo de 30 afirmaciones con semilla (U-4.4).

## 5. Mensajes ajenos

Ninguno.
