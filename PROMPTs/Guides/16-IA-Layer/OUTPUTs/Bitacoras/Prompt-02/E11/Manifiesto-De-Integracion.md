# E11 · Manifiesto de integración

> Etapa E11 del plan integrado (`../05-Plan-Integrado.md`), parte de compuertas finales. Fecha: 2026-11-02. Este manifiesto **no integra nada**: no hay commit, push, PR ni merge. Lista lo que la integración tiene que llevar, por repo, y lo que la frena.

## Índice

- [1. Huella final](#1-huella-final)
- [2. Lab-Documentos (LD)](#2-lab-documentos-ld)
- [3. Lab-Documentos.Documentacion (LDD)](#3-lab-documentosdocumentacion-ldd)
- [4. Lab-Geometria](#4-lab-geometria)
- [5. Repo privado](#5-repo-privado)
- [6. Bloqueos antes de integrar](#6-bloqueos-antes-de-integrar)

## 1. Huella final

| Pieza | sha256 |
|---|---|
| Libro `Dot-Net-Integration-AI-Layer-Guide.md` (0.12.0) | `5ebbfdbb2497b9e2e197851f453cb335311ca1d6a301548249e1a74db87b5e12` |
| Conocimiento `knowledge-AI-Layer-Integration-Designing-Specification.md` | `16ab8280be520387203440b669d3d1202825358c4560c467c4545372b262b126` |
| Carpeta de la guía (471 archivos; `find . -type f \| sort \| xargs sha256sum \| sha256sum`) | `f093596254a3bf8c2d365057bf283cb6d223cdfe8a045a8a0afe9e898b17d5af` |

E11 no cambió ningún archivo de la guía: el libro tiene la misma huella que al cierre de la fase 6 de E10.

## 2. Lab-Documentos (LD)

Rama base: `main` en `0bed863`. **Toda la carpeta es nueva para git**: `Guides/IA/Dot-Net-Integration-AI-Layer-Guide/` está hoy en `.git/info/exclude` del clon (exclusión local, no versionada), así que `git ls-files` da 0. Quien integre tiene que sacar esa línea del `exclude` local o forzar el `add`.

| Ruta (relativa a `Guides/IA/Dot-Net-Integration-AI-Layer-Guide/`) | Archivos |
|---|---|
| `Dot-Net-Integration-AI-Layer-Guide.md`, `Dot-Net-Integration-AI-Layer-Guide.md.refs` | 2 |
| `Conocimientos/` | 1 |
| `Compuertas/` (`README.md`, `ac6.excepciones`; sin listas privadas) | 2 |
| `Demos/` (raíz 3 + `MovilidadUrbana.Asistente/` 111) | 114 |
| `Examples/` (raíz 5 + 01…17 + `_Comun/` 52) | 313 |
| `tools/` (raíz 15 + `oraculos/` 24) | 39 |
| **Total** | **471** |

No hay `bin/` ni `obj/` en la carpeta (el arnés compila en volúmenes de docker).

## 3. Lab-Documentos.Documentacion (LDD)

Rama base: `main` en `8b96bc6`. `PROMPTs/Guides/16-IA-Layer/` también está en `.git/info/exclude` del clon.

| Ruta (relativa a `PROMPTs/Guides/16-IA-Layer/`) | Archivos | Integra el agente |
|---|---|---|
| `01-Crear-IA-Layer-Guide.md`, `02-Ajuste-Coherencia-Reedicion-Documentacion.md` | 2 | **No**: prompts del PO |
| `INPUTs/` (`AI-Layer.png`) | 1 | **No**: insumo del PO |
| `OUTPUTs/Bitacoras/Prompt-02/` (esta bitácora) | 268 + este E11 | Sí, sujeto a §6 |
| `OUTPUTs/Bitacoras/` (resto: raíz 13, `Compuertas/` 5, `Evidencia/` 769, `Mesa/` 173, `Nucleos/` 39, `Redaccion/` 30) | 1.029 | Sí, sujeto a §6 |
| `OUTPUTs/Linea-*-2026-10-28/` (Bitacoras 868, Guia 546, raíz 2) | 1.416 | Sí, sujeto a §6 (el nombre de la carpeta nombra un equipo) |
| `OUTPUTs/Crear-IA-Layer-Guide-Reedicion.md`, `OUTPUTs/Reanudar.md` | 2 | Sí |

## 4. Lab-Geometria

Rama local `g16/ai-layer-v1` (worktree de E5), **sin push** (no existe en el remoto). Base `origin/main` `5f07b12`. 26 archivos nuevos, 1.814 líneas.

| Commit | Mensaje |
|---|---|
| `0f01e83` | ai-layer: criterio R-LLM y arnes del ensayo de pistas, antes de correr |
| `b4832d4` | ai-layer: especificacion de V1 y V2 y expediente 0002 |

Archivos: `ai-layer/` (README, especificaciones V1 y V2, ADR, propuesta de nomenclatura, checklist, `ensayos/` con criterio, resultado, banco, scripts y la corrida del 2026-11-01) y `SDD/Expedientes/0002-Capa-De-IA-Pistas-Y-Borrador/` (README, actuaciones 001–004, evidencia E-001…E-006). Al fusionar, el capítulo 16 del libro puede sumar los enlaces a `ai-layer/` y al expediente 0002 (pendiente de E8).

## 5. Repo privado

Rama local `g16/ai-layer-v1`, **sin push**. 7 archivos nuevos, 447 líneas.

| Commit | Mensaje |
|---|---|
| `08b4850` | docs(ai-layer): especificación del piloto de consulta en lenguaje natural (expediente del caso) |
| `121d3b9` | Afinar la lista negra del filtro de fuga U-7.1 |

Archivos: `ai-layer/` (README, checklist, especificación v0.1) y el expediente del caso (README, actuaciones 001–002, `evidencia/lista-negra.txt`).

## 6. Bloqueos antes de integrar

1. **LDD es público y la bitácora no pasa R-PRIV con clases privadas** (ver `Compuertas.md` §4): 256 hallazgos en `OUTPUTs/`, casi todos el nombre del recurso de turnos en los registros R-LLM congelados; además IP privadas en evidencia y el nombre de un equipo en la carpeta `Linea-*`. La carta dice también que la bitácora «está excluida de git». Decisión del PO: integrar la bitácora redactada, integrarla sólo en parte, o dejarla fuera.
2. Las exclusiones de `.git/info/exclude` en los dos clones son locales: la integración tiene que retirarlas a sabiendas.
3. docs-guard `ai` (AI-4) en rojo por dominios no registrados en `dominios.txt` (H-2, archivo común): pendiente de coordinación.
4. docs-guard `esquema`: 12 errores, iguales a la línea base (prefijo `GUIA-` no registrado en `prefijos.txt`, archivo común).
