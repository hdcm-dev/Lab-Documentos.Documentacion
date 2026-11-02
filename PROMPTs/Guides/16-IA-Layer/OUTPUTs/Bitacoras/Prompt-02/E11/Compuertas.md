# E11 · Compuertas finales: registro

> Etapa E11 del plan integrado (`../05-Plan-Integrado.md`), sólo la parte de compuertas finales. Fecha: 2026-11-02, -03. Registro de sólo agregado. Sin commit, push, PR ni merge. `{guía}` = carpeta de la guía 16 en LD; `{trabajo}` = carpeta de trabajo de la etapa, fuera de los repos.

## Índice

- [1. Resumen](#1-resumen)
- [2. Reanudación](#2-reanudación)
- [3. Compuertas](#3-compuertas)
- [4. R-PRIV y U-7.1 sobre la bitácora](#4-r-priv-y-u-71-sobre-la-bitácora)
- [5. Cambios](#5-cambios)
- [6. Pendientes](#6-pendientes)

## 1. Resumen

Todas las compuertas de la guía dan rc 0, salvo docs-guard `esquema` y `ai`, que quedan en su línea base conocida (archivos comunes, coordinación). `verificar.sh --con-modelo` (build, 3a, lan, 3b) terminó con rc 0 en 2 h 56 min, con un turno por fase. La guía no cambió: sha256 del libro `5ebbfdbb2497b9e2e197851f453cb335311ca1d6a301548249e1a74db87b5e12`. La bitácora **no** pasa R-PRIV con clases privadas: eso frena integrarla en un repo público (ver §4 y `Manifiesto-De-Integracion.md` §6).

## 2. Reanudación

La sesión se reanudó tras un corte de red que cortó el ssh. Al reanudar no existía `E11/` ni proceso de E11 en curso, ni concesión a nombre de la etapa en el gestor: no había trabajo a medias que recuperar. La corrida con modelo se lanzó desacoplada de la terminal (`setsid`/`nohup`) para que otro corte no la mate.

## 3. Compuertas

| Compuerta | Alcance | rc | Resultado |
|---|---|---|---|
| `tools/verificar.sh --con-modelo` (estación 1; `TURNO_CMD` = envoltorio del gestor de turnos, papel → recurso de modelo; `COMPUERTAS_DIR` con clases privadas) | todo `Examples/` | **0** | build -warnaserror, pruebas y consolas `--fake --verificar` en verde; AC-6 ok; R-PRIV del build 0 (patrones 3, lista 20, históricos 1). Fases 3a, lan y 3b con modelo: Ollama 0.40.11, `qwen3.5:4b` `d8b0f5e9760c`, embeddings `ac6da0dfba84`, `num_ctx` 8192 leído en `/api/ps`, `keep_alive 0` al cerrar cada fase. Turnos: 1 build + 3 de modelo, todos concedidos y liberados; 4 renovaciones; sin concesiones colgadas. 10.546 s. `Evidencia/verificar-con-modelo.log` |
| `tools/contar.sh` | libro | 0 | 59.373 / 60.000 |
| `tools/verificar-markdown.py guia` | libro | 0 | 0 rotos; 82 rutas, 4 exceptuadas |
| `tools/verificar-markdown.py arbol` | `Examples`, `Conocimientos`, `Demos` | 0 / 0 / 0 | 0 rotos |
| `tools/verificar-markdown.py ejemplos` | `Examples` | 0 | 18 archivos |
| `tools/compuerta-cabeceras.sh` | `Bitacoras/Evidencia` | 0 | 0 en 2 cuerpos |
| `tools/compuerta-intervalos.py` | libro + `Evidencia/R-LLM-2026-10-28` | 0 | 28/28 figuras en el mapa; 21/21 filas |
| `tools/compuerta-referencias.sh` | `{guía}` | 0 | 0 rotas en 21 archivos |
| `tools/compuerta-rpriv.sh` con `COMPUERTAS_DIR` (clases privadas) | `{guía}` completa | 0 | 0 hallazgos. Primera pasada: 1 (el `turno_id` de `Examples/15-…/entradas/salidas-07.v1.json`, valor histórico que el README de 15 declara así); se agregó a `r-priv.historicos` de `{trabajo}` (fuera del repo) y dio 0 |
| `tools/compuerta-rpriv.sh` con `COMPUERTAS_DIR` | bitácora completa (`OUTPUTs/`) | 1 | **256 hallazgos**: ver §4 |
| Filtro U-7.1 (`grep -rniIF -f`, lista negra privada de 27 líneas) | `{guía}` | — | **0** |
| Filtro U-7.1 | `PROMPTs/Guides/16-IA-Layer` de LDD | — | 2 coincidencias, ambas en el prompt del PO (`02-Ajuste-…md`), **fuera del alcance declarado**: no es salida de la etapa y no se toca. Salidas: 0 |
| Filtro U-7.1 | resto de LD y LDD (informativo) | — | LD: 55 en 10 archivos ajenos a la guía (un proveedor de notificaciones público, en guías de Despliegue/Testing, Documentación Técnica, `CHANGELOG` y fixtures de docs-guard). LDD: 82 fuera de 16-IA-Layer. Fuera del territorio: no se toca |
| `tools/medios/mermaid.sh` | libro (25) y Conocimiento (2) | 0 | 27/27 ok |
| docs-guard `mermaid-arroba` (`dg.py` de la rama común, sólo lectura) | `{guía}` | 0 | verde: 27 bloques |
| docs-guard `fuera` | libro / `{guía}` | 0 / 0 | verde (corrido desde la raíz de LD; desde otra raíz da 35 falsos «fuera del repo») |
| docs-guard `esquema` | libro | 1 | 12 errores = línea base (prefijo `GUIA-` no está en `prefijos.txt`) |
| docs-guard `ai` | libro | 1 | AI-4 = 87, igual a la línea base de E10 (H-2: dominios no registrados en `dominios.txt`) |
| docs-guard `ai` | `{guía}` completa | 1 | AI-4 = 91: los 87 del libro + 3 del Conocimiento (c4model.com, adr.github.io, www.rfc-editor.org) + 1 de `Demos/…/README.md` l. 145 (nombre de servicio de compose tomado por dominio). Mismo pendiente H-2 |

Salidas (rutas locales reemplazadas): `Evidencia/`, con `SHA256SUMS`.

Observaciones de la corrida con modelo (medición, no compuerta; el libro no cita estas cifras): 15 da acuerdo juez-oráculo 6/16 y juez-anotador 4/10, «juez no calibrado», deterministas 12/16 y 5/5 + 5/5; 04 y 08 por la vía extension muestran fallas de oráculo aisladas (normalización 1, no-inventa 6/8). Coinciden con la conducta que el libro ya describe para un modelo chico; no se reescribió nada.

## 4. R-PRIV y U-7.1 sobre la bitácora

| Alcance | ip-privada | host | identificadores | Total |
|---|---|---|---|---|
| `OUTPUTs/` completo | 41 | 4 | 211 | 256 |
| sólo `Bitacoras/Prompt-02/` | 0 | 4 | 23 | 27 |
| sólo `Prompt-02/E11/` | 0 | 0 | 0 | 0 |

- En `OUTPUTs/` el grueso es el nombre del recurso de turnos dentro de los `turno_id` de los registros R-LLM (221) y direcciones privadas en la evidencia; son registros de sólo agregado, no se redactan en esta etapa.
- En `Prompt-02/` son el nombre del envoltorio del gestor de turnos y nombres de equipos en propuestas, plan, consolidado, coordinación y logs de build de E3/E8.
- Una carpeta de `OUTPUTs/` lleva el nombre de un equipo en su propio nombre.
- No son fallas mecánicas de la guía: redactarlas cambia registros de otras etapas. Decisión del PO antes de integrar la bitácora (Manifiesto §6).

## 5. Cambios

- `{guía}`: ninguno. Libro `5ebbfdbb…5e12`, Conocimiento `16ab8280…b126`, carpeta (471 archivos) `f0935962…d5af`.
- Fuera de los repos: `{trabajo}/compuertas/` (listas privadas armadas para esta etapa, según `Compuertas/README.md`; no se copian a ningún repo).
- En la bitácora: `E11/` (este registro, el manifiesto, `Evidencia/`) y `../Ejecucion/E11.md`.

## 6. Pendientes

1. **Bitácora en LDD público**: 256 hallazgos R-PRIV (§4). Opciones para el PO: redactar, integrar sólo `Prompt-02/E11` y resúmenes, o no integrar la bitácora (la carta la da por excluida de git).
2. H-2 (`dominios.txt`, archivo común): 91 AI-4 en la carpeta; coordinación.
3. `prefijos.txt` (archivo común): 12 errores de esquema por `GUIA-`; coordinación.
4. Ruta absoluta del registro en `Examples/15-…/entradas/salidas-07.v1.json` (pendiente de E10): el archivo es histórico con sha256 fijado en `ejemplo.json`; cambiarlo exige una `v2`. No es mecánico.
5. `.git/info/exclude` de LD y LDD excluye la carpeta de la guía y `16-IA-Layer`: la integración tiene que retirarlo a sabiendas.
6. Ramas `g16/ai-layer-v1` de Lab-Geometria y del repo privado, sin push (Manifiesto §4–§5).
7. Mensajes ajenos a mitad de turno: ninguno.
