# Panel AH-02 · evaluación (relectura integral de la guía 0.11.0)

Lectura a ciegas (sin Panel-*.md ajenos). Foco: oráculos, criterios previos, intervalos, «no medido» honesto. La guía no se editó.

## AH-02-evaluacion-01 · mayor · §10.6, párrafo «Lo que vio el laboratorio después»
- Problema: el texto dice «su repetición, con criterio propio, no había cerrado al escribir esta sección». Ya cerró: R-15b terminó (rc 0) y no cumple su criterio fijado antes de correr.
- Evidencia: 00-Preparacion.md §4: 41/52 interpretables, IC95 Clopper-Pearson [0,653; 0,889], mínimo 45/52; rótulo `qwen3.5:4b`@`d8b0f5e9760c`, estación 2, Ollama 0.40.11, 2026-10-29; criterio sha256 `3f573a4e…aebaf`.
- Propuesta: reemplazar la frase por «la repetición del 2026-10-29 (estación 2) dio 41/52 salidas interpretables, por debajo del mínimo fijado antes de correr (45/52): no medido», con el rótulo R-LLM y la advertencia de juez y generador de la misma familia. No informar acuerdo ni puntajes de esa corrida.

## AH-02-evaluacion-02 · mayor · ADR-10 (§13.11, «Consecuencias» y «Confianza») y pregunta guía «¿Puedo usar un modelo para evaluar a otro?»
- Problema: sólo nombran el juez histórico («ninguna de sus salidas se pudo leer», «hasta el 2026-10-28 … ninguna salida interpretable»). Con la corrida del 2026-10-29 el estado vigente es otro (no medido por criterio, con 41/52 legibles); el lector puede creer que el juez vigente sigue sin dar ninguna salida legible.
- Evidencia: mismas cifras del hallazgo 01; los dos textos rotulan sólo la historia.
- Propuesta: agregar una oración con el estado vigente «no medido (41/52 < 45/52, 2026-10-29)», remitiendo a §10.6; sin cifras de acuerdo.
