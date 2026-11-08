---
doc_id: DB-R02-05
doc_type: bitacora
title: Rondas editoriales del libro DocsAsCode — cierre: partición por Parte, dibujo de mermaid y etiqueta de archivo
status: borrador
origin: agent
confidence: alta en tamaños, conteos y estados de dibujo (medidos el 2026-11-07 sobre la cabeza 7483a4d y sobre main 0d8c1d6)
owner: presidencia de la reedición DocsAsCode (expediente 0003)
last_review: 2026-11-08
traces: [DB-R02-00, EXP0003-F400]
---

# 05 — Rondas editoriales del libro: cierre

## Qué se hizo

Por la resolución 99 de la mesa de cierre del libro (folio 400 del expediente 0003), el libro
`DocsAsCode-Developer-Guide.md` de `hdcm-dev/Lab-Documentos` se partió por Parte dentro del PR 8 (#61), que se fusionó
con el commit de merge `0d8c1d6`. El archivo único pesaba 529 KB, superaba el techo de 400 KB y llevaba 30 mermaid de
los que GitHub dibujaba entre 0 y 12.

- Rama puesta al día con un merge de `main` (sin rebase ni squash); conflicto en `CHANGELOG.md` resuelto conservando
  las dos entradas.
- Correcciones aprobadas de la intervención 4: 79 de 79 ya estaban aplicadas en `ba99393`; ninguna de las 5
  rechazadas se aplicó.
- 456 anclas remapeadas (encabezados y anclas `ref-…`); 546 enlaces hacia o dentro del libro en todo el repositorio,
  0 rotos; el enlace entrante del conocimiento de especificación se remapeó a la Parte V-b.
- Barrido de privados: 0 hallazgos (un falso positivo léxico en el título de una referencia).
- docs-guard local verde en los ocho grupos; en la CI, docs-guard, mini-demo-movilidad y framework-concept-demo en
  éxito sobre la cabeza, y docs-guard en éxito sobre el commit de merge.

## Mediciones por archivo

| Archivo | KB | Mermaid | Dibujados en GitHub |
| --- | ---: | ---: | ---: |
| `DocsAsCode-Developer-Guide.md` (raíz: índice y glosario-índice) | 29 | 0 | — |
| `DocsAsCode-Developer-Guide-Parte-0.md` | 19 | 1 | 1 |
| `DocsAsCode-Developer-Guide-Parte-I.md` | 76 | 7 | 7 |
| `DocsAsCode-Developer-Guide-Parte-II.md` | 77 | 5 | 5 |
| `DocsAsCode-Developer-Guide-Parte-III.md` | 38 | 2 | 2 |
| `DocsAsCode-Developer-Guide-Parte-IV.md` | 66 | 5 | 5 |
| `DocsAsCode-Developer-Guide-Parte-V-a.md` | 75 | 4 | 4 (3 en el primer intento, 4 al reintento) |
| `DocsAsCode-Developer-Guide-Parte-V-b.md` | 35 | 3 | 3 |
| `DocsAsCode-Developer-Guide-Parte-VI.md` | 36 | 2 | 2 |
| `DocsAsCode-Developer-Guide-Anexos.md` (B a J) | 100 | 1 | 1 |
| **Total** | | **30** | **30** |

Medición: vista de blob de GitHub sobre `7483a4d`, recorriendo la página y contando los contenedores de render en
estado listo. Criterios de la resolución: ≤ 350 KB por archivo (techo 400) y ≤ 7 mermaid (límite 15); cumplidos.

## Etiqueta

`sdei-v2.0.0-borrador`, anotada, sobre `31660d3`: `git ls-remote` la resuelve a ese commit y el enlace a la guía
archivada `Sistema-Documentador-Tecnico-Guide.md` en la etiqueta responde 200.

## Apartamiento declarado

La resolución nombraba la pieza de anexos «anexos-b-h»; el libro tiene anexos hasta J (I, correspondencia; J, marcas
de estado), así que la pieza es `DocsAsCode-Developer-Guide-Anexos.md` con B a J. El anexo A (glosario-índice) va en la
raíz, como pide la resolución.
