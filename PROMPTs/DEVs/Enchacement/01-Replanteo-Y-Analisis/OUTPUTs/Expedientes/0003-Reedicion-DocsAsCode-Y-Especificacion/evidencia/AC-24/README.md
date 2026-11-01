# AC-24 — Cómo dibuja mermaid la arroba en una etiqueta

Experimento del PR 3 de §5.6 (PR común de Lab-Documentos), 2026-11-01. Lo cita la providencia
[`007`](../../actuaciones/007-providencia-ac24-y-r-l6.md).

- **Variantes:** [`variantes.txt`](variantes.txt). Cada línea es la única arista de un `flowchart LR` de un archivo
  Markdown mínimo (`# t` y un bloque `mermaid`); el prefijo es el nombre del archivo.
- **Dibujado:** [`dibujado.txt`](dibujado.txt). Es el texto que quedó en el SVG de la primera etiqueta de cada
  variante, dibujada con el `mermaid.sh` de medios (mermaid-cli en contenedor). La variante `v6` no tiene `traces` y
  sale vacía.

## Lectura

| Etiqueta | Variantes | Dibujo |
| --- | --- | --- |
| `#64;` sin HTML | `v1`, `v2`, `w3` | `ID@1.0`: limpio |
| `#64;` con `<br/>`, `<br>` o `<b>` en la misma etiqueta | `v3`, `v4`, `w1`, `w2` | «Unsupported markdown: link» |
| `&#64;` con HTML | `w4` | `ID&@1.0` |
| Arroba entre espacios | `v7`, `v8`, `w5`, `w6` | `ID @ 1.0`: limpio, pero no es una traza válida |

`w3` muestra que el HTML cuenta sólo si está en la misma etiqueta: el `<br/>` del otro nodo no afecta.
