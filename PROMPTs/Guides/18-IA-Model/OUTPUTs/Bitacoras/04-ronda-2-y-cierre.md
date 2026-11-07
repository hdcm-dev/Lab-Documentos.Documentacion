# Bitácora 04 — Ronda 2, parches y cierre de la mesa

**Fecha:** 2026-11-07 · **Autor:** bitacorista del cierre (agente) · **Estado:** vigente

Registro retomable de la ronda 2 y del cierre del caso. Continúa a `01-arranque-y-enunciado.md`,
`02-ronda-de-estructura.md` y `03-elaboracion.md`. Expediente del caso:
`OUTPUTs/Expedientes/0001-Guia-De-Estudio-IA-Model/` (folios 001–021; la letra manda en los
folios, esta bitácora resume). Rutas de la guía relativas al repo destino (`<worktree-guia>`,
rama `g18/ia-model-guide`); las del expediente, relativas a `OUTPUTs/` (`<worktree-doc>`).

## 1. Reparación de la tubería 06/07 y cierre de elaboración (folio 013)

1. Los dos pendientes de la bitácora 03 §4.1 se saldaron primero: la tubería de los núcleos 06 y
   07 se había caído sin devolver resultado con los documentos ya escritos; se completó con una
   corrida de reparación (verificador → editor) y sus constancias `despacho/verif-06.md` y
   `despacho/verif-07.md`. Comprobación de la presidencia: `grep -c VERIFICAR` → 0 en ambos
   documentos. Con eso las constancias de verificación quedaron 11/11 y la edición académica
   completa en las 15 piezas.
2. **Folio 013** (providencia): cierre de la fase de elaboración y convocatoria de la ronda 2,
   con las cartas ya archivadas en `evidencia/` — 016 (las cinco comisiones de la ronda 1 con el
   objeto cambiado a corpus existente), 017 (refutador), 018 (jurado) y 019 (cuerpo de parches,
   fuera del panel). Regla de la ronda: esta ronda encuentra; sólo el cuerpo de parches corrige,
   y únicamente lo votado PROCEDE. Insumo obligatorio: las observaciones compiladas de la fase
   anterior (`evidencia/015`, con su adenda de la reparación).

## 2. Ronda 2: comisiones a ciegas, refutador y veredicto (folios 014–020)

1. **Cinco comisiones a ciegas** (folios 014–018), cada una contra el borrador completo en
   `<worktree-guia>/Guides/IA/IA-Model/`: 47 hallazgos en conjunto. Ninguna propuso ficha de
   excepción.
2. **Refutador** (folio 019): 10 hallazgos `R2-REF-`; consolidó las 39 filas de comisión en ~17
   hechos, degradó dos P1 a P2, tumbó un ancla defectuosa con re-corrida propia y degradó a C los
   negativos no abiertos. Sin BLOQUEO.
3. **Jurado** (folio 020): de los 57 detectados, **54 PROCEDE / 0 NO PROCEDE / 3 ARCHIVA**
   (R2-ENT-05, R2-ENT-06, R2-ENT-12); ningún tramo de clase C fundó parche. Constancia de
   homogeneidad con causa observable (árbitro previo + trabajo a ciegas + convergencia
   independiente). El veredicto fijó 12 direcciones de parche (PA-01…PA-12, dirección y clase,
   no redacción) y 2 deudas declaradas (PD-01, PD-02) con evento de cierre.

## 3. Aplicación de parches (constancias `despacho/parches-01…08`)

- **PA-01…PA-12 aplicados en 8 lotes** (transversal, M3, M1, doc 11, doc 04, doc 07, doc 09,
  M2), con constancia por lote en `despacho/parches-NN-*.md`: **0 parches devueltos**. Ninguna
  edición entró en cercas de código ni tocó salidas verificadas o marcas del verificador; cada
  parche se verificó con el comando del ancla del hallazgo que lo funda.
- **Deudas NO aplicadas, conforme al veredicto**:
  - **PD-01** — tramo final del lab 6.B (servir `taller-qwen` en el banco, pasos 5–6) y la
    promoción de `status`/`confidence` de IAM-06; evento de cierre: respuesta del PO a la fila 1
    del lote (§5 del folio 021). La salvedad quedó anotada en M2 §5 (PA-11).
  - **PD-02** — fijación de la revisión (commit) del modelo de embeddings en los protocolos del
    doc 09; evento de cierre: constancia del verificador con el dato observado (no se inventa un
    commit). El descargo textual ya entró (PA-09).

## 4. Verificación de cierre (tres lentes independientes, posterior a los parches)

1. **Parches: CONFORME** — los 12 PA comprobados contra la dirección votada (anclas del jurado
   corridas); PD-01 y PD-02 comprobadas como NO aplicadas; condición de R2-REF-01 respetada.
2. **Editorial: CONFORME** — enlaces relativos y anclas: 564 verificados, 0 rotos; frontmatter
   15/15 conforme a la norma parchada; `grep -c VERIFICAR` → 0 en las 15 piezas; índices contra
   encabezados reales sin desajustes. Mermaid: 12/12 documentos con diagrama validados (el lente
   llegó a 4 renderizados al corte de su corrida; la presidencia completó la pasada: ok=12,
   fallos=0).
3. **Higiene de publicación: CON-DEFECTOS en su corrida, 4 defectos corregidos por la presidencia
   antes de la resolución** — dos rutas internas del host en `evidencia/015` reemplazadas por
   marcadores, y la declaración de `evidencia/local/` como no versionada asentada en 7 archivos
   (constancias verif-01/04/05/06/09 y folios 012/013). Barrido limpio tras la corrección; nada
   tocado fuera del objeto en ningún worktree.
4. **Dos excepciones de barrido declaradas** (folio 021 §3): la palabra «infravm» en el testimonio
   literal del PO del folio 004 (huella E-8 verificada: alterar la transcripción la rompería) y el
   regex de barrido citado verbatim en el folio 017 (patrón de un `grep`, no una ruta real).

## 5. Resolución final (folio 021)

- La cuenta de folios cierra en 21 (001–021). Con los parches aplicados y verificados, la guía
  cumple la regla de cierre de la clase y el pedido: ningún P0/P1 vigente, todo P2 con parche o
  deuda declarada con evento abrible, las cuatro preguntas del caso respondidas.
- Con 54 hallazgos procedentes en la segunda ronda no hay dos rondas seguidas limpias: el cierre
  es **por decisión y no por criterio**, con lo abierto enumerado en el folio 021 §4 (PD-01,
  PD-02, cliente `ollama` del puesto de verificación, `/api/embed` del banco, primarias
  pendientes de 11 §1.5, condiciones de revisión de PA-01/02/03).
- **Lote al PO**: 4 filas con defaults (Detencion-Y-Lote 1.1; nada se asienta por silencio) —
  modelos de prueba del lab 6.B (P2, condiciona PD-01), cliente `ollama` (P3), embeddings del
  banco (P3) y la ratificación de los defaults del folio 011 §5 (P3).
- Las 15 piezas se entregan con `status: borrador`; la promoción a vigente es decisión del PO,
  con PD-01 resuelta o asentada.

## 6. Alta en la ia-db del repo destino

Alta **incremental** de la guía en la ia-db de `<worktree-guia>`: fila en `ia-db/indexes/09` y
en `ia-db/indexes/00_MASTER-INDEX`. Queda **fuera de la base declarada** hasta la próxima
regeneración completa de la ia-db (el alta incremental registra, no re-genera).

## 7. Qué sigue

1. **Entrega** por `Knowledge-Conformacion-Pull-Request-Automatico` 2.0 en ambos repos: PR de la
   rama de la guía (`g18/ia-model-guide`, repo destino) y PR de outputs (`g18/ia-model-outputs`,
   expediente + bitácoras), con fusión por el ciclo automático.
2. Lote al PO (folio 021 §5) pendiente de respuesta; mientras tanto rigen los defaults
   declarados.
3. Eventos de cierre abiertos: PD-01 (respuesta a la fila 1) y PD-02 (constancia del verificador
   de 09 con el commit observado).

Si se corta acá: el expediente queda cerrado (folio 021) y sólo se invalida la entrega, que puede
relanzarse desde los dos worktrees tal como están. **Fin de la serie de esta corrida**; una
corrida futura (deudas o revisión de la capa volátil) abre bitácora nueva.
