# E11 · PR único de integración (parte B)

> Fecha: 2026-11-02. Un PR por repo, abierto y **sin fusionar** (acuerdo e: la guía 16 integra última). Worktrees propios en `[ruta-trabajo]/g16-LD` y `[ruta-trabajo]/g16-LDD`, rama `g16/prompt-02` desde `origin/main` fresco (LD `358b338`, LDD `c6acc22`).

## Índice

- [1. PR abiertos](#1-pr-abiertos)
- [2. Verificación local](#2-verificación-local)
- [3. Lo que quedó fuera](#3-lo-que-quedó-fuera)
- [4. Notas](#4-notas)

## 1. PR abiertos

| Repo | PR | Cabeza | Diff |
|---|---|---|---|
| LD | [#50](https://github.com/hdcm-dev/Lab-Documentos/pull/50) | `acfb9bd` | 472 archivos, +40.610 (guía 471 + `tools/docs-guard/dominios.txt`) |
| LDD | [#54](https://github.com/hdcm-dev/Lab-Documentos.Documentacion/pull/54) | ver el PR (este registro va en un segundo commit) | 2.561 archivos de `OUTPUTs/` + este registro |

Los 4 dominios sumados a `dominios.txt`: `github.blog`, `shopify.engineering`, `www.anthropic.com`, `www.linkedin.com`.

## 2. Verificación local

| Compuerta | rc | Resultado |
|---|---|---|
| `tools/verificar.sh build` con turno `build` (dueño `g16-e11-pr`) | 0 | 230 s, 18 Passed, 0 Failed; R-PRIV interna 0. Log sha256 `83fe5f421b358713561e05b272158ac0e0e786bcde706e26aa16484cca10e021` |
| docs-guard `mermaid-arroba` (guía) | 0 | 0 errores; fuera de la guía, los 2 de main |
| docs-guard `fuera` (guía) | 0 | igual a main fuera de la guía |
| docs-guard `esquema` (guía) | 1 | 12 errores (vocabulario del frontmatter y prefijo `GUIA-`), los mismos de E11; fuera de la guía: igual a main (342) |
| docs-guard `ai` (guía) | 1 | AI-4 81 (dominios de referencias no registrados), AI-3 7 avisos; fuera de la guía mejora: 2 AI-4 menos en DevOps-Guide por los dominios nuevos |
| R-PRIV LD (guía + `dominios.txt`, listas privadas con versiones) | 0 | 0 hallazgos |
| R-PRIV LDD (todo lo agregado, listas con versiones) | 0 | 0 hallazgos; sin históricos, 44 falsos positivos de versión de ensamblado (RPRI-19) |
| `mermaid.sh` (27 diagramas) | 0 | todos ok |

Huellas: libro `Dot-Net-Integration-AI-Layer-Guide.md` sha256 `9a00c490496a2eafa19b429be4a3a95370b0911798bf5a426a229be34cde76d7`; carpeta de la guía (471 archivos) `0ac960b0b4019dfe0cfc82aec699103741efb2f94a33be90b9acd64d24a505bd`. Difieren de las del manifiesto porque el libro se ajustó después (re-enmascarado y enlaces a Geometría).

## 3. Lo que quedó fuera

- LDD `01-Crear-IA-Layer-Guide.md` y `02-Ajuste-Coherencia-Reedicion-Documentacion.md`: prompts del PO no versionados (el 02 nombra el servicio privado).
- LDD `INPUTs/AI-Layer.png`: insumo del PO, no versionado.
- LDD 187 archivos `*.log` y `*.trx` de la evidencia: los excluye `.gitignore`.
- LD: nada; la guía no tiene `bin/` ni `obj/`.

## 4. Notas

- La exclusión de `.git/info/exclude` vale también en los worktrees (es del directorio común): se agregó con `git add -f` sobre la lista de `git ls-files -o --exclude-per-directory=.gitignore`, que respeta `.gitignore` y no el exclude local. Los clones compartidos no se tocaron.
- docs-guard de CI verifica por defecto la carpeta SDEI: la guía no entra en su ruta.
- Durante el turno no llegaron mensajes ajenos.
