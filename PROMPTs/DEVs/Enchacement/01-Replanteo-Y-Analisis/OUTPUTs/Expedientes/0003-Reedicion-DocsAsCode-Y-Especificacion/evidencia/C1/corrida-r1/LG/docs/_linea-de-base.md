---
doc_id: SDOC-LINEA-DE-BASE
doc_type: anexo
title: Línea de base de los controles documentales
description: Línea de base medida de cada control documental antes de activar su bloqueo, con la regla de bloqueo aplicada control por control.
status: borrador
origin: ia-generated
confidence: media
owner: pendiente (lo asigna una persona; ver A-01 §4)
last_review: 2026-11-01
audience: [desarrollo, agente, po]
traces: [SDOC-PREFIJOS]
---

# Línea de base (A-08)

Medida el 2026-11-01 sobre la copia leída de los dos repositorios (sin `.git`: SHA no comprobable, ver A-01).
Salidas completas en `salida/inventario/` de la corrida. Condiciones de bloqueo: 1 determinista sin red,
2 defecto del mismo PR, 3 par rojo/verde, 4 base 0, 5 sin falsos positivos conocidos.

| Control | Corpus | Línea de base | 1 | 2 | 3 | 4 | 5 | Propuesta |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Enlaces relativos (`verificar.py`) | `Lab-Geometria.Documentacion` sin `PROMPTs/` | 0 errores | sí | sí | sí (par en `par-rojo-verde-LGD-verificar.txt`) | sí | sí, ninguno conocido | bloquea, si la plataforma puede volverlo obligatorio (pendiente) |
| Forma de la `ia-db` (`verificar.py`) | `ia-db/` | 0 errores | sí | sí | no medido | sí | sí | avisa hasta tener par rojo/verde |
| Enlaces relativos, misma regla | `Lab-Geometria` vivo (sin `_legacy/` ni `Maquetas/`) | 11 rotos | sí | sí | no medido | no | no: 2 son marcadores `(...)` en `SDD/Docs/Audit/DoR-Tramo-k-2026-09-12.md:65`, `:207` | avisa |
| Enlaces relativos, misma regla | `Lab-Geometria` entero | 5838 rotos | sí | — | — | no | — | fuera de la compuerta (lo heredado de `_legacy/`) |
| Frontmatter presente | `Lab-Geometria` | 1276 de 1288 sin frontmatter | sí | sí | no medido | no | — | avisa; bloquea sólo en carpetas nuevas (`docs/`) |
| Frontmatter presente | `Lab-Geometria.Documentacion` | 57 de 57 sin frontmatter | sí | sí | no medido | no | — | avisa |
| Trazas contra el registro | ambos | no medible: no hay control ni registro que resuelva | — | — | — | — | — | pendiente |
| Barrido de lo privado ({etiqueta-runner}) | `Lab-Geometria` vivo · `Lab-Geometria.Documentacion` | 11 archivos · 2 archivos | sí | sí | no medido | no | no medido | avisa |
| Barrido de IP por expresión regular | `Lab-Geometria` vivo | 20 archivos candidatos sin clasificar (incluye números de versión) | sí | — | — | — | falsos positivos probables | pendiente de clasificar |
