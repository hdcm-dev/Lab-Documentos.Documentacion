---
doc_id: EXP0003-F007
doc_type: providencia
title: Providencia sobre AC-24 y la precisión de R-L6 tras el experimento de la arroba en mermaid
status: vigente
origin: agent
confidence: alta en el hecho (experimento dibujado, catorce variantes); alta en la decisión (aplica la resolución 099 sin apartarse)
owner: presidencia de la reedición DocsAsCode
last_review: 2026-11-01
audience: [PO, presidencia, agentes de la reedición]
traces: [EXP0003-F099, EXP0003-F006]
---

| Campo | Valor |
| --- | --- |
| Tipo | providencia |
| Fecha | 2026-11-01 |
| Autor | Presidencia de la reedición DocsAsCode |
| Precisa | `099` §5.2, regla R-L6, y §5.3, ajuste AC-24 |

# 007 — AC-24 y la precisión de R-L6

## Índice

1. [El hecho: lo que mostró el experimento del PR 3](#1-el-hecho-lo-que-mostró-el-experimento-del-pr-3)
2. [Decisión sobre AC-24](#2-decisión-sobre-ac-24)
3. [R-L6 precisada](#3-r-l6-precisada)
4. [El control `mermaid-arroba`](#4-el-control-mermaid-arroba)

## 1. El hecho: lo que mostró el experimento del PR 3

AC-24 manda escribir `#64;` en lugar de la arroba seguida de versión en dos etiquetas mermaid del cuerpo. Al aplicarlo
en el PR 3 de §5.6, se dibujaron catorce variantes mínimas. Las variantes y lo que dibujó cada una están en
[`evidencia/AC-24/`](../evidencia/AC-24/README.md). Lo que muestran:

- **`#64;` en una etiqueta con HTML falla.** Si la etiqueta lleva `<br/>`, `<br>` o `<b>`, mermaid convierte `#64;`
  en arroba antes de leer el Markdown. El autoenlace de correo vuelve y el dibujo dice «Unsupported markdown: link».
- **`&#64;` no sirve.** Dibuja `ID&@1.0`.
- **La arroba entre espacios dibuja limpio, pero enseña mal.** Dibuja `ID @ 1.0`, que no es una traza válida para
  `RE_TRAZA` de `dg.py` (`ID@1.0`, sin espacios). Un diagrama del cuerpo no debe mostrar una traza que la compuerta
  rechaza.
- **`#64;` en una etiqueta sin HTML dibuja limpio**: `ID@1.0`. El HTML de otro nodo no afecta.

## 2. Decisión sobre AC-24

AC-24 se aplica como lo pide la resolución, con `#64;`. Para que dibuje limpio, se saca el HTML de las dos etiquetas
(`99-Anexos/Esquema-Frontmatter-Y-Prefijos.md:82` y `Examples/MovilidadUrbana-Mini-Demo/docs/_requisitos.md:56`). No
se usa la arroba entre espacios, por lo dicho en §1.

## 3. R-L6 precisada

En R-L6, la parte de la arroba queda así: «sin arroba seguida de un nombre con punto; `#64;` sólo en etiquetas sin
HTML». El resto de la regla no cambia. Con esta redacción la heredan el libro y el conocimiento de especificación
(PR 7 y PR 8 de §5.6).

## 4. El control `mermaid-arroba`

El control nuevo `dg.py mermaid-arroba` (PR 3) da rojo con la arroba seguida de un nombre con punto. También da rojo
con `#64;` dentro de una etiqueta que lleva HTML. Así la compuerta exige lo mismo que R-L6 precisada.
