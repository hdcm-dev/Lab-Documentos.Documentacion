---
doc_id: BIT-16-MESA-C3-04
doc_type: veredictos-del-jurado
title: Ciclo 3 · Veredictos del jurado (M§4.3, M§5.3)
version: v1
status: cerrado
origin: agent (secretaría; transcribe los votos, no vota)
last_review: 2026-10-26
traces: [BIT-16-MESA-C3-03, BIT-16-04 v2, M§4.3, M§5.3, M§9]
---

# Ciclo 3 · Veredictos del jurado

Jurado de cinco: juez de evidencia, juez de impacto, juez de costo-beneficio, juez de coherencia y juez de riesgo (reversibilidad). Objeto: los 40 ítems de `03-Consolidacion.md` (3 contradicciones, 10 papeletas, 27 hallazgos). El lote S4 está vacío.

**Nota de transcripción.** El juez de riesgo rotuló cada voto con el texto de su opción (por ejemplo «A: 4 h»). El conteo del jurado lo deja aparte y no lo suma a ninguna letra. La secretaría lo transcribe igual. Cuando el texto coincide con la opción ganadora, en la columna «¿unánime?» se lo cuenta como coincidente.

## 1. Resumen

| Medida | Valor |
|---|---|
| Ítems votados | 40 |
| Hallazgos PROCEDE | 27 de 27 (24 por 5-0; H3-017 4-1 NO_PROCEDE; H3-026 4-1 INSUFICIENTE; H3-027 3-2 INSUFICIENTE) |
| NO_PROCEDE | 0 |
| Votos INSUFICIENTE | 3 (H3-026: 1; H3-027: 2) |
| Unánimes, con el rótulo coincidente | 31 de 40 (77,5 %) |
| Vetos de riesgo | 0 |
| Empates | 0 |
| **Segundas rondas** | **ninguna**: ningún ítem quedó empatado ni sin mayoría (M§5.3), así que no se convocó una segunda ronda. Las minorías fundadas se transcriben en §4 |

## 2. Contradicciones y papeletas

| Ítem | Tema | Resultado | Conteo | ¿Unánime? |
|---|---|---|---|---|
| C3-01 | Estado de DEP-14 | **A: rige EMB-B** | A:4 · «B: rige EMB-C hasta que la presidencia vuelva a verificar»:1 | no |
| C3-02 | Fusión F1 (01+02) | **A: no** | A:4 · «A: no»:1 | sí |
| C3-03 | RV-03: 4 h o 6 h | **A: 4 h** | A:4 · «A: 4 h»:1 | sí |
| P3-01 | RV-03 tope de horas | **A: 4 h** | A:4 · «A: 4 h»:1 | sí |
| P3-02 | H2-056 fusiones | **A: F1 no, F2 no, F3 sí** | A:4 · «A: F1 no, F2 no, F3 sí»:1 | sí |
| P3-03 | RV-05 OA | **C: 27 OA (26 + OA-A6)** | C:3 · A:1 · «A: 26 OA»:1 | no |
| P3-04 | RV-04 presupuesto de palabras | **A: enmendada** (§0.5 al Anexo E; total ≤ 44.330) | A:4 · «A: enmendada…»:1 | sí |
| P3-05 | RV-01 casos integradores | **A: ninguno** | A:3 · B:1 · «B: optativo, sólo el caso 3, fuera del conteo»:1 | no |
| P3-06 | RV-11 juez de 15 | **B′: `qwen2.5:0.5b` en el Ollama propio** | B′:4 · «A: sesgo declarado»:1 | no |
| P3-07 | Criterio de dificultad | **B: nivel de PR-3 + regla residual** (08→B, 17→A) | B:4 · «B: …»:1 | sí |
| P3-08 | P-12 / DEP-15 | **B: regla general de estímulo; 05 padrón; 16 en `Nombre`** | B:4 · «A: regla general de estímulo + 05 en variante intermedia»:1 | no |
| P3-09 | Recorte de la demo | **B: RC-1; humo en PD-2, PD-3 y PD-6; PD-7 sale** | B:4 · «B: …»:1 | sí |
| P3-10 | Par CTX-NUEVA / CTX-EXISTENTE | **A: aplicar completo** | A:3 · B:1 · «B: sólo 03 §2 y la guía»:1 | no |

## 3. Hallazgos H3-001…H3-027

| Ítem | Título | Resultado | Conteo |
|---|---|---|---|
| H3-001 | Hosts de la LAN en Ciclo-2/09 l. 31 (S1) | PROCEDE | 5 |
| H3-002 | AC-7/AC-8 pasan en vacío; falta 100.64/10 | PROCEDE | 5 |
| H3-003 | DEP-12 huérfana y AC-11 humo del host | PROCEDE | 5 |
| H3-004 | La provisión del Ollama propio supone un contenedor local | PROCEDE | 5 |
| H3-005 | TURNO-3 sin tabla ni cota | PROCEDE | 5 |
| H3-006 | PD-1 subpresupuestado | PROCEDE | 5 |
| H3-007 | El arnés aborta con /api/ps vacío | PROCEDE | 5 |
| H3-008 | La política de origen bloquea 11 y PD-6 | PROCEDE | 5 |
| H3-009 | Compensación y regla de conteo | PROCEDE | 5 |
| H3-010 | La compuerta de familias de ID marca OA-S2, QA y PC | PROCEDE | 5 |
| H3-011 | PD-2 mal rotulado ESC-02 | PROCEDE | 5 |
| H3-012 | Subsecciones fuera del criterio de inclusión; §14 sin OA | PROCEDE | 5 |
| H3-013 | OA-S1 sin práctica | PROCEDE | 5 |
| H3-014 | Tres sentidos de «contexto» | PROCEDE | 5 |
| H3-015 | §B.4 Agente por código en el escalón 3 | PROCEDE | 5 |
| H3-016 | Residuos de los parches del ciclo 2 | PROCEDE | 5 |
| H3-017 | AC-5 sólo cubre Domain | PROCEDE | 4 · NO_PROCEDE 1 (costo-beneficio) |
| H3-018 | La calibración de 15 no se puede obtener | PROCEDE | 5 |
| H3-019 | 05 con M = 5 frente a la regla de ≥ 6 discordantes | PROCEDE | 5 |
| H3-020 | 16: un solo ataque, comparación trivial | PROCEDE | 5 |
| H3-021 | Carga ajena en la máquina del Ollama propio | PROCEDE | 5 |
| H3-022 | Falso positivo de AC-8 en «coincidente» | PROCEDE | 5 |
| H3-023 | docker pull con una credencial vencida | PROCEDE | 5 |
| H3-024 | El orden de TURNO-2 no tiene criterio | PROCEDE | 5 |
| H3-025 | La papeleta F1 oculta el costo | PROCEDE | 5 |
| H3-026 | Plan sobredimensionado frente a «iniciar» | PROCEDE | 4 · INSUFICIENTE 1 (evidencia) |
| H3-027 | DEP-10 caro con un contrato alternativo escrito | PROCEDE | 3 · INSUFICIENTE 2 (evidencia, coherencia) |

## 4. Minorías fundadas (se transcriben y no cambian el resultado)

- **C3-01, riesgo**: «rige EMB-C hasta que la presidencia vuelva a verificar». Lo que pedía se cumplió en el cierre: la secretaría corrió `<gestor-de-turnos> estado` y `salud [recurso-modelo-propio]` (rc = 0, 0.40.11, dos modelos; `08-Cierre.md` §4). La minoría queda atendida.
- **P3-03, costo-beneficio y riesgo**: mantener 26 OA, porque OA-A6 depende de P3-10. Ganó P3-10 A, así que la dependencia quedó satisfecha.
- **P3-05, impacto y riesgo**: caso integrador 3 optativo, fuera del conteo. Pasa a deuda: «los casos integradores tienen valor didáctico» (coherencia lo dijo en su voto A).
- **P3-06, riesgo**: sesgo declarado, porque B′ agrega una dependencia en el último ciclo. Queda como riesgo en R-08 y en la salida de §E.5 (si `salud` falla, EMB-C, y 15 queda «no ejecutado»).
- **P3-08, riesgo**: variante intermedia de 05. Salió de la papeleta. Si el padrón de 05 no da el prefijo que mide DEP-03, el efecto queda como medición de la construcción (deuda 2 de `05-Parches.md` §5).
- **P3-10, costo-beneficio y riesgo**: aplicar el par sólo en 03 §2 y en la guía. Se aplicó completo. CTX-NUEVA queda «sin ejecución», que es lo que ellos pedían declarar.
- **H3-017, costo-beneficio**: las tres reglas de capa van a deuda. Ganó PROCEDE y se aplicaron.
- **H3-026, evidencia**: no verificó la letra «iniciar» del prompt del PO. Queda registrado: el alcance mínimo es una decisión de la mesa, no una lectura literal del prompt.
- **H3-027, evidencia y coherencia**: no verificaron que `(nombre, provincia)` cubra lo que resolvía DEP-10. Queda como deuda: la conducta en tareas de varios pasos no se mide (R-08, §14.6).
