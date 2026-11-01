---
doc_id: EXP0003-F006
doc_type: providencia
title: Providencia sobre la delegación del merge (P-09) y el lote del PO de la resolución 099
status: vigente
origin: agent
confidence: alta en la delegación (regla del PO del 2026-10-25, literal); alta en los defaults (resolución 099 §5.8)
owner: presidencia de la reedición DocsAsCode
last_review: 2026-11-01
audience: [PO, presidencia, agentes de la reedición]
traces: [EXP0003-F099, EXP0003-F085]
---

| Campo | Valor |
| --- | --- |
| Tipo | providencia |
| Fecha | 2026-11-01 |
| Autor | Presidencia de la reedición DocsAsCode |
| Corrige | `099` §5.8, fila P-09: la pregunta ya tenía respuesta del PO |

# 006 — Delegación del merge y lote del PO

## Índice

1. [P-09: la delegación ya existe](#1-p-09-la-delegación-ya-existe)
2. [Resto del lote: rigen los defaults](#2-resto-del-lote-rigen-los-defaults)
3. [Primer PR del plan: alias y foliado juntos](#3-primer-pr-del-plan-alias-y-foliado-juntos)

## 1. P-09: la delegación ya existe

La resolución `099` §5.8 deja como pregunta al PO si delega el merge de los PR del expediente 0003. Esa pregunta ya
tiene respuesta.

**La regla.** El 2026-10-25 el PO fijó una regla general para todos los PR que hace el agente. Literal: «siempre para
conformar los pr sigue `KB-privada/Knowledges/Knowledge-Conformacion-Pull-Request-Automatico.md`». Antes había dicho:
«vos te encargas de todos los pr». La regla está registrada en la memoria del agente: `{memoria-del-agente}`, entrada
de esa fecha.

**Cómo se aplica a este expediente:**

- Los PR del expediente 0003 se conforman con la guarda G1–G4: estado `clean`, controles verdes en la cabeza y merge
  atado al SHA.
- Cuando corresponde, se anuncia el merge a las otras sesiones (constancias `002` y `005`).
- La fila de delegación en el `CHANGELOG.md` de Lab-Documentos entra en el PR común (PR 3 de `099` §5.6). Esa fila
  asienta la delegación en el repositorio destino, como pide la regla.
- La creación de la etiqueta de archivo `sdei-v2.0.0-borrador` queda dentro del alcance. Es un acto reversible y
  previsto por la resolución.

## 2. Resto del lote: rigen los defaults

Ninguna de estas tres preguntas detiene el plan. Se aplica el default de cada una (`099` §5.8, columna «SI NO
RESPONDÉS») y se le informan al PO en el mismo turno.

| # | Default aplicado |
| --- | --- |
| L-1 | Los nombres de máquina se corrigen sólo hacia adelante: este PR reemplaza los nombres por alias. La historia queda como está y se declara deuda. Otras guías de los mismos repositorios ya nombran esas máquinas; reescribir la historia por esto sería desproporcionado |
| L-3 | El pin del workflow reutilizable de Lab-Documentos.Documentacion queda en `bf86669`. En Lab-Documentos.Documentacion rige el dibujado local de mermaid |
| AG-3 | El conocimiento no se copia a la base privada |

L-2 sólo se pregunta si la captura de P-19 falla.

## 3. Primer PR del plan: alias y foliado juntos

Los PR 1 y 2 de `099` §5.6 van en un solo PR (`dac/0003-mesa`). Los dos tocan sólo Lab-Documentos.Documentacion y van
en serie. Separarlos agregaría un ciclo de CI sin ganar aislamiento.

**Alias.** Se aplicaron en `Reedicion-02/`, en esta carpeta del expediente y en las tres piezas de la onda 8 ya
fusionadas: índice `00`, bitácora `16` y folio `261` del 0002. Los nombres de archivo de folios anteriores que
contienen un nombre de máquina se conservan, porque son rutas y no se renombran.

**Folio 003 y constancia de la guía 16.** El folio `003` es la propuesta de panel. La constancia de coordinación con la
guía 16 pasa al número `005`, porque se había escrito como `003` antes de foliar.
