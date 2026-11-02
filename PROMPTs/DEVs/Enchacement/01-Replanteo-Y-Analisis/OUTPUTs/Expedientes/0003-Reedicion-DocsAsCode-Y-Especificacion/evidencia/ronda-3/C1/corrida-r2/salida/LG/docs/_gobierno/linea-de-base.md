---
doc_id: FIC-LINEA-DE-BASE
doc_type: anexo
title: Línea de base de la compuerta documental de Fábrica de Geometría
description: Informe de línea de base por control y carpeta, medido antes de activar el bloqueo; va en la descripción del PR de adopción.
status: borrador
origin: ia-generated
confidence: media
owner: Product Owner
last_review: 2026-11-02
audience: [desarrollo, po]
traces: [FIC-DISENO-DOCUMENTAL]
---

# Línea de base de la compuerta documental

Medida con `python3 -I dg.py <control> --raiz <repo> <repo>` de la compuerta de origen, sin red, sobre la copia
recibida de cada repositorio. Lo heredado avisa; `docs/` es carpeta nueva. El archivo de excepciones de la copia
queda vacío.

| Control | Grupo | `Lab-Geometria` (todo el árbol) | `Lab-Geometria.Documentacion` | `docs/` (nueva) |
| --- | --- | --- | --- | --- |
| fuera-del-repo | PR-1 | 0 | 0 | ver ficha §8 |
| enlaces (lychee) | PR-1 | sin medir sobre lo heredado | sin medir | ver ficha §8 |
| esquema | PR-2 | 107 errores | 0 | ver ficha §8 |
| anti-inyección | PR-3 | 95 errores (AI-2 6, AI-4 89) | 26 errores (AI-1 1, AI-2 1, AI-4 24) | ver ficha §8 |
| mermaid-arroba | PR-4 | 0 | 0 | ver ficha §8 |
| traces-resolve e id-duplicado | PR-5 | 932 errores (897 IDs duplicados; 35 trazas, 0 resueltas) | 21 errores (21 IDs duplicados) | ver ficha §8 |
| contratos | PR-6 | 0 (ningún contrato extraído) | 0 | ver ficha §8 |
| fijadas, reflint, url-fecha | PR-7 | 0 errores; url-fecha 79 avisos | 0 errores; url-fecha 34 avisos | ver ficha §8 |

Los prefijos heredados que chocan entre sí (IDs duplicados del corpus SDD, sobre todo por las copias de `_legacy/`)
no se resuelven en la adopción: van a un saneamiento aparte, de clase P.
