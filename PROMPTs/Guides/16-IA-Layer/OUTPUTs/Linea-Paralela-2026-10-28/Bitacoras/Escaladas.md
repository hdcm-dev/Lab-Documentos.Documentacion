---
doc_id: BIT-16-ESC
doc_type: registro-de-escaladas
title: Escaladas de la mesa de la guía 16 (M§6)
status: vigente
origin: agent
owner: aplicación de la mesa (REED-16 §9.7, §12)
last_review: 2026-10-28
audience: [presidencia, PO, redacción]
traces: [IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md §6; REED-16 §12; Mesa/Ciclo-1/05-Aplicacion.md §7; Mesa/Ciclo-1/Ronda-2/03-Parches.md §5; Mesa/Ciclo-1/Ronda-2/04-Aprobacion-*.md; Mesa/Ciclo-1/Ronda-2/05-Aplicacion.md]
---

# Escaladas de la mesa (M§6)

Registro único de las escaladas al humano de la mesa de la guía 16, con el formato de M§6. Una escalada sale sólo por uno de los siete disparadores de M§6; las de tipo 2 y 3 bloquean el ciclo y salen en el momento, las demás se entregan juntas al final del ciclo. Cada entrada lleva el default que aplica la redacción mientras nadie responde. Rutas relativas a `OUTPUTs/Bitacoras/`.

## Ciclo 1, primera ronda (2026-10-28)

Ninguna escalada (`Mesa/Ciclo-1/05-Aplicacion.md` §7). Este archivo no existía.

## Ciclo 1, segunda ronda (2026-10-28)

**Ninguna escalada.**

- **Tipo 6 (empate persistente):** no aplica. Los 29 ítems de la boleta (`Mesa/Ciclo-1/Ronda-2/00-Boleta.md`) salieron con mayoría de 3 o más sobre 5 votos y sin veto; la opción ganadora de cada uno está en `Mesa/Ciclo-1/Ronda-2/03-Parches.md` §1.
- **`ESCALAR` en la aprobación:** ninguno. Los 15 parches salieron `APLICAR` (P2-06 en su vuelta 2), y los cinco jueces revisaron los siete disparadores de REED-16 §12 sin encontrar uno.
- Revisión propia de la aplicación contra los siete disparadores de M§6: (1) la única ambigüedad de intención, la lectura de «streaming de tokens» en C1-48 = A, la desempató la evidencia (`Mesa/Ciclo-1/Ronda-2/00-Boleta.md` l. 46) y la ratificaron las cinco aprobaciones; (2) no hay conflicto entre restricciones duras; (3) la divergencia de la prueba «piedra» (P2-04) no cambia el alcance, porque no se endurece la copia; (4) lo único irreversible a la vista sigue siendo el primer commit de `OUTPUTs/`, regido por el dictamen §2; (5) nada manda datos afuera ni usa un proveedor con costo; (6) sin empates; (7) ninguna decisión cerrada se reabrió.

### Elevaciones internas a la presidencia (no son escaladas de M§6)

No van al PO: la presidencia es una instancia de la corrida. Se listan acá para que la redacción tenga en un solo lugar el default que aplica mientras tanto (el mismo de `Mesa/Ciclo-1/06-Plan-De-Redaccion.md` §10.8).

| Id | Qué decide la presidencia | Origen | Default de la redacción mientras tanto | Qué bloquea |
|---|---|---|---|---|
| ELV-01 | Sentido de «workflow» (C1-32): opción A, «workflow» a secas, u opción B, «flujo fijo», para el camino fijado por código | Boleta §6; Parche P2-14 | §7 de la guía se redacta; cada frase del sentido (a) lleva `[C: término de C1-32]`; rigen las formas comunes («workflow de MAF», «proceso»; sin «agentic workflow», «flujo agéntico» ni «flujo de trabajo») | la entrada «Workflow» del Anexo C y el cierre (C2 = 0 marcas) |
| ELV-02 | Apagado del segundo servidor de prueba (C1-51) | Parche P2-10; juez de riesgo | sigue arriba (14 CPU / 34 GiB, `KEEP_ALIVE` 10 min); ninguna corrida nueva sin pedido de la mesa | nada de la redacción; tiene que decidirse antes del cierre del ciclo 1 |
