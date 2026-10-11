# Evidencia del cuerpo auditor · ciclo 2 (2026-10-09)

Insumo de `../03-Parches.md`. Nada de esta carpeta modifica `Examples/` ni la guía: los experimentos corren sobre copias.

| Carpeta | Qué contiene | Cómo se corre |
|---|---|---|
| `propuestas/` | `repo/`: plantillas propuestas con la compuerta completa (para probar); `compuerta.diff` y `plantillas.diff` contra `Examples/` | — |
| `x0-docker-config/` | `buildx` con `DOCKER_CONFIG` vacío y con `cli-plugins` enlazado (C2-24) | `bash experimento.sh` |
| `x2-compuerta-propuesta/` | plantillas propuestas en la imagen de A.10 (C2-01…C2-03, C2-07, C2-14, C2-53) | `EXAMPLES=<Examples> bash experimento.sh` |
| `x3-regresion-n7/` | N7 con la compuerta nueva (C2-05, C2-06) | `EXAMPLES=<Examples> bash experimento.sh` |
| `x4-devcontainer-safe-directory/` | `devcontainer up` con `safe.directory` (C2-11) | `bash experimento.sh` |
| `x5-variante-b/` | variante B ampliada (C2-12) | ver la cabecera del script |
| `x5-version-v1/` | §11.5 con `version=v1` (C2-28) | `N8=<…/N8-integracion-poliglota> bash comando-de-la-guia-v1.sh` |
| `x6-prerrequisitos/` | caso (d): falta el paquete EditorConfig (C2-07) | `COMPUERTA=… EXAMPLES=… bash probar-prerrequisitos.sh` |
| `x7-ea1-propuesto/` | `repo/` = `A-plantillas/repo/` tras P-23 L3; `verificar.sh` = EA-1 con los pasos 1c, 2c, 8, 9, 10 | `EXAMPLES=<Examples> COMPUERTA=../propuestas/repo/tools/ci/compuerta.sh bash verificar.sh` |
| `simulacion/` | `parches_guia.py` (P-01…P-21 en forma ejecutable), `gen.py`, `guia-parcheada.md`, `deltas.json` | `GUIA=<guía> python3 gen.py` |

Fuentes web consultadas el 2026-10-09: `../03-Parches.md` §6.
