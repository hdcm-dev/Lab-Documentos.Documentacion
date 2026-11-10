# Folio 023 — Resolución: deudas PD-01 y PD-02 cerradas

| Campo | Valor |
| --- | --- |
| Tipo | resolucion |
| Fecha | 2026-11-10 |
| Autor | presidencia de la mesa |
| Corrige | — |

Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas: las del presidente (§1–§8).

## 1. Cuenta de la unidad

Plan del folio 022, ejecutado completo: dos corredores + editor de conformidad. Constancias nuevas:
`despacho/verif-06b.md` y `despacho/verif-09b.md`; 13 evidencias crudas con huella SHA-256 en
`evidencia/local/` (no versionada). Folios del expediente: 23 (001–023). La cuenta cierra.

## 2. PD-01 — CERRADA (constancia verif-06b)

- La corrida completa del lab 6.B se lanzó literal y se cortó por costo medido: el primer paso de
  optimización tomó 1.525,7 s → proyección ~229 min, sobre el techo de 150 del folio 022.
  **Apartamiento declarado** en documento y constancia; corrió entera la reducida
  (train_loss 4,333; 600,2 s; el paso 1 reproduce el loss 4,481 de verif-06 con la misma semilla).
- Cadena completa servida: fusión (con el remedio del tokenizador), GGUF q8_0 del ajustado
  (531.067.904 bytes, la cifra de verif-06) y del base; ambos creados en el banco **por API**
  (`/api/blobs` + `/api/create`), comparación del paso 6 servida de verdad (temperature 0, seed 42)
  y transcripta al documento 06 con protocolo M3.
- **Banco limpio comprobado**: `taller-qwen` y `taller-qwen-base` borrados y ausentes de
  `/api/tags` (12 modelos, sin restos).
- Documento 06: los dos bloques antes ilustrativos llevan salidas reales; el paso 5 documenta la vía
  por API; frontmatter con `entorno_validado` 2026-11-10 y `confidence: alta`; `status: borrador`
  (promoverlo es del PO). `Cohesion-Global.md` §5: la condición de ACT-03 quedó dada y cerrada.
- El contraste de estilo del paso 6 queda declarado como dependiente de la corrida completa
  (~229 min medidos en este CTX-01 compartido): diferencia de redacción, no de conducta, con 3
  micro-pasos — como el propio documento anticipa.

## 3. PD-02 — CERRADA (constancia verif-09b)

- Revisión observada con descarga fresca (contenedor `python:3.12.16-slim`, huggingface_hub 0.36.0):
  `model_info().sha = e8f8c211226b894fcb81acc59f3b34ba3efd5f42`, coincidente con el directorio de
  snapshot del caché. Fijada en los tres bloques «Protocolo de la cifra» del documento 09; los dos
  descargos de vigencia remiten ahora a «la revisión fijada en el protocolo». Eje del documento
  (biblioteca local) intacto; la disponibilidad de embeddings en el banco quedó en el folio 022.

## 4. Conformidad y compuerta

Editor: M3 conforme en 06, 09 y Cohesion-Global; mermaid de los tres compila; enlaces y anclas
correctos; barrido de fugas en documentos y constancias: cero (banco sólo como
`$OLLAMA_HOST`/`localhost`). Ajustes de forma del editor: `last_review` 2026-11-10 en 09 y
Cohesion-Global, `entorno_validado` de 09 ampliado con la revisión observada. Compuerta local del
repo destino: **«== docs-guard: verde»** (todos los grupos).

## 5. Estado del lote del folio 021 §5

| Fila | Estado |
| --- | --- |
| 1 (modelos de prueba en el banco) | Resuelta por autorización del PO (folio 022): ejecutada y limpiada |
| 2 (cliente `ollama` en el puesto) | Sigue su default: nada instalado, todo por API |
| 3 (embeddings del banco) | Resuelta por el entorno: `nomic-embed-text` disponible (folio 022) |
| 4 (filas del folio 011 §5) | Siguen sus defaults |

Quedan del lado del PO: la promoción de las piezas a `status: vigente` y, si algún día interesa el
contraste de estilo pleno del 6.B, una corrida completa en un CTX-01 dedicado (~229 min medidos acá).

Se dispone la entrega por Conformacion-Pull-Request-Automatico 2.0 en ambos repositorios (la
delegación asentada el 2026-11-07 cubre los PR del expediente 0001).

Sigue: entrega (commits, PRs, guarda y merge) y bitácora 05 · despachos abiertos: ninguno ·
insumos: folios 020–022, constancias verif-06b/verif-09b · si se corta acá, el cierre de deudas
queda asentado y sólo se invalida la entrega, que puede relanzarse; el banco quedó limpio.
