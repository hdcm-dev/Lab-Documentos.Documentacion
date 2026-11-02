---
doc_id: BIT-16-MESA-C3-06
doc_type: aprobacion-de-parches
title: Ciclo 3 · Mesa de decisión sobre los parches (M§4.5)
version: v1
status: cerrado
origin: agent (secretaría; transcribe, no vota)
last_review: 2026-10-26
traces: [BIT-16-MESA-C3-05, BIT-16-MESA-C3-04, M§4.5]
---

# Ciclo 3 · Aprobación

## 1. Decisiones

| Parche | Sección | Resultado | Conteo |
|---|---|---|---|
| PAR3-01 | §A.3 OA y criterio de inclusión | APLICAR | A5-M0-N0-E0 |
| PAR3-02 | §B.3, §B.4 | APLICAR | A5-M0-N0-E0 |
| PAR3-03 | §C preámbulo | APLICAR | A5-M0-N0-E0 |
| PAR3-04 | §C fichas Parte 0–IV | APLICAR | A5-M0-N0-E0 |
| PAR3-05 | §C fichas Parte V–Anexos | APLICAR | A5-M0-N0-E0 |
| PAR3-06 | §D PR-3, PR-14, PR-20 | APLICAR | A5-M0-N0-E0 |
| PAR3-07 | §E.1 | APLICAR | A5-M0-N0-E0 |
| PAR3-08 | §E.2 | APLICAR | A5-M0-N0-E0 |
| PAR3-09 | §E.4 (d) | APLICAR | A5-M0-N0-E0 |
| PAR3-10 | §E.5 | APLICAR | A5-M0-N0-E0 |
| PAR3-11 | §E.6 | APLICAR | A5-M0-N0-E0 |
| PAR3-12 | §F.1 y barrido de PD-n | APLICAR | A5-M0-N0-E0 |
| PAR3-13 | §F.2–§F.5 | APLICAR | A5-M0-N0-E0 |
| PAR3-14 | §F.6, §F.8, §F.9 | APLICAR | A5-M0-N0-E0 |
| PAR3-15 | §F.10 y Compuertas | APLICAR | **A4-M1**-N0-E0 |
| PAR3-16 | §G | APLICAR | A5-M0-N0-E0 |
| PAR3-17 | BIT-16-03 §2 y §4.2 | APLICAR | A5-M0-N0-E0 |
| PAR3-18 | BIT-16-02 §6 | APLICAR | A5-M0-N0-E0 |
| PAR3-19 | R-PRIV en Ciclo-2/09 y dos informes | APLICAR | **A4-M1**-N0-E0 |
| PAR3-20 | Encabezado, §H, changelog | APLICAR | A5-M0-N0-E0 |

Son 20 APLICAR, 18 de ellos unánimes (90 %). No hubo MEJORAR_PLAN por mayoría, ni NO_APLICAR, ni ESCALAR.

## 2. Objeciones en minoría (juez de riesgo)

Votó MEJORAR_PLAN y quedó en minoría. Las objeciones **no se aplican** como ajustes, porque la presidencia indicó aplicar sin ajustes propios. Se registran como deuda o como hechos de la aplicación (ver `07-Aplicacion-Y-Verificacion.md` §3):

- **PAR3-15**:
  - (a) Mientras DEP-16 no se cierre, AC-7 y AC-8 quedan siempre en rojo. La objeción pide declarar que, hasta DEP-16, se use la lista de la secretaría fuera del repo. **No se aplicó al texto del plan** y pasa a deuda. En los hechos, la secretaría corrió los barridos de este ciclo con su lista, guardada fuera del repo.
  - (b) La excepción l. 25 de `rd-po-4.excepciones` tiene que borrarse después de probar `(?<!co)incidente`. **Se cumplió** en ese orden: primero la prueba (0 en `rd-po-4.negativos`, 0 en `Ciclo-1/03-Consolidacion.md:85`) y después el borrado.
- **PAR3-19**:
  - (1) Verificar con la lista de la secretaría. **Se hizo**: 0 en los tres archivos.
  - (2) No dejar copia de respaldo en `OUTPUTs/` y registrar antes las líneas afectadas (1, 5 y 3). **Se cumplió**.
  - (3) Agregar en `Ciclo-2/09` una nota «redactado en ciclo 3 por R-PRIV». **No se agregó**, porque no está en el texto del parche. La trazabilidad la dan este registro y `07`, y la nota queda como deuda.
