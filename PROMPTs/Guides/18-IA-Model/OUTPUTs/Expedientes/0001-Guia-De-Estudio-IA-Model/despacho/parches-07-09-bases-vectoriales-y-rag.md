# Constancia del cuerpo de parches — lote «local 09-Bases-Vectoriales-Y-RAG.md»

Fecha: 2026-11-07. Lote de un parche: PA-09 (hallazgos R2-INF-01, opción b, y R2-INF-06).
Documento intervenido: `<worktree-guia>/Guides/IA/IA-Model/09-Bases-Vectoriales-Y-RAG.md`,
aplicado entero en esta pasada. Sin commits.

## PA-09 — 09-Bases-Vectoriales-Y-RAG.md

### 1. Reformulación de la frase citante de §1.1 (R2-INF-06)

- **Hallazgo**: la frase que cita al documento 08 decía «cuesta memoria en proporción
  creciente», cosa que el dueño (08, caché KV) no afirma: el costo es proporcional al largo
  del contexto.
- **Qué cambió** (líneas 56–57): «finita, cuesta memoria en proporción creciente
  ([`08-Inferencia-Local.md`]…)» → «finita, cuesta memoria en proporción al largo del
  contexto — la caché KV de [`08-Inferencia-Local.md`]… —». Reformulación de una línea; el
  enlace al dueño se conserva.

### 2. Descargo textual sobre la revisión del modelo de embeddings (R2-INF-01, opción b)

- **Hallazgo**: las similitudes de los laboratorios valen para la revisión del modelo con que
  se verificó; otra revisión puede reordenar un empate fino. Entra el descargo textual ya;
  fijar la revisión (commit) queda como deuda PD-02 — **no se escribió ningún commit**, en
  cumplimiento de R2-REF-06.
- **Qué cambió en §3.1** (líneas 423–425): al párrafo de determinismo que cierra el ejemplo 1
  («…un modelo distinto da vectores de otro espacio, no “parecidos”») se le sumó: «Y un
  descargo sobre la vigencia: estas similitudes valen para la revisión del modelo con que se
  corrió la verificación; otra revisión del mismo modelo puede desplazar los valores y
  reordenar un empate fino.»
- **Qué cambió en §3.2** (líneas 598–600): al párrafo de lectura de la recuperación, justo
  tras el empate a 0,421 («…el modelo respondió bien»), se le sumó: «Rige acá el mismo
  descargo de §3.1: un empate así de fino vale para la revisión del modelo de *embeddings*
  con que se verificó la corrida, y otra revisión puede reordenarlo.»
- **Qué NO se tocó**: las salidas transcriptas de las corridas, los bloques «Protocolo de la
  cifra», la nota previa de §3 y toda marca de verificación (fechas «verificado el
  2026-11-07», digest, versiones). Los agregados son prosa adyacente.

## Devueltos

Ninguno: el lote no incluía parches que tocaran salidas verificadas o marcas del verificador.

## Observaciones

- Ninguna corrección fuera de la dirección votada fue necesaria ni aplicada.
- PD-02 sigue abierta tal como la fijó el jurado: el descargo entra sin nombrar revisión;
  cuando el verificador aporte el dato observado (caché de HF o recorrida), los tres bloques
  protocolo podrán fijarla.
