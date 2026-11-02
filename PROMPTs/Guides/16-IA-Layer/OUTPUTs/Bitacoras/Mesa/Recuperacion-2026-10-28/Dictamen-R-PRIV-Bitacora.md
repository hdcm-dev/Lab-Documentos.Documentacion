---
doc_id: BIT-16-REC-DICT
doc_type: dictamen-adoptado
title: Dictamen R-PRIV de la bitácora (§1–§2 del dictamen de la presidencia del insumo, adoptado por REC-33)
status: vigente (adoptado el 2026-10-29, bloque B-02 del plan de recuperación)
origin: copia textual del insumo (sólo §1 y §2); procedencia PB-01 en Procedencia.md
last_review: 2026-10-29
---

# Dictamen R-PRIV de la bitácora (adoptado)

> **2026-10-29 — Recuperación (B-02, paso 2.1, REC-33 opción A).** Copia textual de los apartados §1 y §2 del dictamen de la presidencia del ciclo 1 de la línea archivada (`$INSUMO/Bitacoras/Mesa/Ciclo-1/07-Dictamen-Presidencia.md`, sha256 `2624422d7b6297b22a516b267668f3d389237ec0cb61cf30a0e5067e3702e8ee`). Los apartados §3 a §5 son del insumo y no se adoptan acá. Lo que dice el texto de abajo sobre «la bitácora» rige para `Bitacoras/` de la base, con la precisión del plan de recuperación: el barrido de redacción se hizo en B-02 (antes de cualquier commit) y las capturas que alimentan recálculos (`Evidencia/R-LLM/*.jsonl`, `*.tsv` y demás `.jsonl`) conservan sus valores, declarados históricos en `Bitacoras/README.md`.

## 1. Excepción de P-01 a «sólo agregado» (deuda D-1)

**Se acepta.** R-PRIV es una restricción dura del contrato y le gana a la convención de «sólo agregado», que es una regla de forma de la bitácora. La redacción in situ que hizo P-01 (40 líneas en 13 archivos) queda firme y no se restaura. Alcance: sólo para borrar datos que R-PRIV prohíbe. Ninguna otra corrección puede usar esta excepción para reescribir texto de la bitácora.

## 2. Identificadores de equipos y contenedores en la bitácora (deuda D-2, C1-39)

- **Guía, `Examples/` y `Demos/`:** cero. Ahí rige la compuerta R-PRIV ampliada a nombres de equipos y contenedores del laboratorio (opción A de C1-39), porque van al repositorio público.
- **Bitácora:** se permiten mientras no se commitee, que es la convención vigente («sin commit»). Son contexto operativo necesario para retomar el trabajo, como en `Reanudar.md`. Antes de cualquier commit de `OUTPUTs/`, la presidencia exige un barrido de redacción, y ese barrido es la condición del primer commit.

