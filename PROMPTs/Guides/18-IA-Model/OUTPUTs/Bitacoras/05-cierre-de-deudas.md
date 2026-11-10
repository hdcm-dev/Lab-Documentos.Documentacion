# Bitácora 05 — Cierre de deudas PD-01 y PD-02 contra el banco nuevo

**Fecha:** 2026-11-10 · **Autor:** presidencia de la mesa (agente) · **Estado:** vigente

Continuación de la serie (bitácoras 01–04). Unidad posterior a la entrega del 2026-11-07, dentro
del mismo expediente 0001.

## 1. Disparador

El PO autorizó en sesión ejecutar lo pendiente tras revisar los cambios de entorno: el banco de
ensayo my-ai se mudó de host (testimonio y verificación en el folio 022). Para la guía la mudanza
es transparente: el texto público siempre nombró el banco como `localhost`/`$OLLAMA_HOST`. Novedad
material: el banco ahora ofrece un modelo dedicado de embeddings (`nomic-embed-text`) y
`POST /api/embed` responde — la fila 3 del lote quedó resuelta por el entorno.

## 2. Lo hecho

1. **Folio 022**: testimonio del PO, verificación del banco nuevo y plan de cierre.
2. **PD-01** (verif-06b): tramo final del lab 6.B servido de verdad — corrida completa cortada por
   costo medido (~229 min proyectados; apartamiento declarado), reducida entera, fusión, GGUF q8_0,
   `taller-qwen` y `taller-qwen-base` creados en el banco por API, comparación del paso 6 servida y
   transcripta al documento 06, y los dos modelos borrados con comprobación. Frontmatter de 06:
   `entorno_validado` 2026-11-10, `confidence: alta`, `status: borrador`. Cohesion-Global §5
   actualizada (la condición de ACT-03 se dio y cerró).
3. **PD-02** (verif-09b): revisión del modelo de embeddings observada con descarga fresca
   (`e8f8c211226b894fcb81acc59f3b34ba3efd5f42`) y fijada en los tres protocolos del documento 09.
4. **Editor de conformidad**: M3, mermaid, enlaces, barrido de fugas (cero) y compuerta local
   «== docs-guard: verde».
5. **Folio 023**: resolución de cierre con la cuenta y el estado final del lote.

## 3. Estado al cierre

Las dos deudas declaradas en el folio 021 quedaron cerradas; del lote sólo sigue en default la
fila 2 (cliente `ollama`: nada instalado, todo por API) y las filas del folio 011 §5. La promoción
de las piezas a `vigente` sigue siendo del PO. Entrega de esta unidad por
Conformacion-Pull-Request-Automatico 2.0 en ambos repositorios.

**Sigue:** nada pendiente de la mesa; el expediente queda cerrado con 23 folios.
