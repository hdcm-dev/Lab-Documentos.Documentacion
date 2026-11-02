# Ajustes finales de E11 (2026-11-02)

> Resuelve las tres observaciones de `../Ejecucion/Verificacion-Cierre-Etapa-4.md` §4. Sin commit, push ni PR (la fusión de las ramas va por conformación automática, aparte). Sin turno de modelo; sólo turno `build`. Sin tocar archivos comunes, DocsAsCode ni FRAMEWORK MAUI. Mensajes ajenos a mitad de turno: ninguno. `{guía}` = carpeta de la guía 16 en LD; `{trabajo}` = `[ruta-trabajo]/g16-p02/e11-ajustes`.

## 1. Cambios

| # | Archivo | Cambio | sha256 nuevo |
|---|---|---|---|
| 1 | `Examples/15-…/entradas/calibracion.v1.json` → `calibracion.v2.json` | Versión nueva con el mecanismo de `salidas-07`: `version` v2 y la `nota` cita `entradas/salidas-07.v2.json`. Casos, umbral y anotaciones sin cambio. La `v1` sale del árbol | `7f35be96c58c690af327c39d60843a5d2dd6c21b9c767ec9d6db79aca7fbf384` |
| 1 | `Examples/15-…/ejemplo.json` | Ruta y sha fijado de la calibración (antes `ae9d1408…0362`) | `8eb1e40c5698…6ddb` |
| 1 | `Application/CasosDeEvaluacion.cs` (`Archivo`), `Application/OraculoDelJuez.cs` (comentario) | `calibracion.v2.json` | `a6784335f13c…`, `9cba62b813ae…` |
| 1 | `Examples/15-…/README.md` | Tabla de entradas y un párrafo: la `calibracion.v2` reemplaza a su `v1`, mismo contenido, sha nuevo en `ejemplo.json` | `54da8d2fee22…` |
| 2 | `Examples/_Comun/…/AI/LectorDePrefijoCacheado.cs` l. 1, `…Pruebas/LecturaDelUsoTests.cs` l. 1 | «procedencia en la bitácora de la recuperación» → «procedencia en un registro de trabajo no publicado; ver el Anexo H» | `7bb125eb7303…`, `9af5d29c3c0c…` |
| 2 | `Examples/06-…/ejemplo.json` l. 2 | «ver la bitácora de aplicación» → «registro de trabajo no publicado; ver el Anexo H de la guía» | `be8360c77361…` |
| 2 | `Conocimientos/knowledge-…Specification.md` l. 572 | «bitácora del prompt 02 de la guía 16, etapa E7» → «registro de trabajo no publicado de la guía 16 (ver su Anexo H)» | `d7ed2f029233…` |
| 3 | `E11/compuertas/r-priv.historicos` (fuera del repo) | Retirado. R-PRIV pasa con `historicos=0` | — |

Oráculos: ninguno cita el sha ni la ruta de la calibración (`grep` de `ae9d1408` y `calibracion.v1` en `{guía}`: 0). `grep "bitácora"` en `Examples/` y `Conocimientos/`: 0.

## 2. Compuertas

| Compuerta | rc | Resultado |
|---|---|---|
| `tools/verificar.sh build` con turno `build` por `[gestor-de-turnos]` (dueño `g16-e11-ajustes`), concedido y liberado; registros, volumen de artefactos y etiqueta propios en `{trabajo}` | 0 | 202 s; 18 «Passed!», 0 «Failed!». La consola de 15 lee salidas `5a8951ecbb34` y calibración `7f35be96c58c`. R-PRIV del build: 0 (historicos=0) |
| `tools/recalcular-oraculos.sh` sobre el registro `--fake` de 15 | 0 | 26/26 |
| `tools/contar.sh` | 0 | 59.385 / 60.000; Anexos 13.000 / 13.000 |
| `verificar-markdown.py guia` · `arbol` Examples/Conocimientos/Demos · `ejemplos` | 0 · 0/0/0 · 0 | 4 rutas exceptuadas; 18 archivos |
| `compuerta-referencias.sh` | 0 | 0 rotas en 21 archivos |
| `compuerta-intervalos.py` (libro + R-LLM-2026-10-28 + mapa) | 0 | 28/28; 21/21 |
| `compuerta-rpriv.sh {guía}` con las listas privadas de E11 | 0 | 0 hallazgos (patrones=3, lista=20, historicos=0) |
| Filtro U-7.1 (`grep -rniIF -f r-priv.lista`) | — | 0 |
| `tools/medios/mermaid.sh` libro y Conocimiento | 0 · 0 | 25 + 2 ok |

Salidas de las compuertas en `{trabajo}`.
