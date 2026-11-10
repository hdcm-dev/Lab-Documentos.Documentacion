# Folio 022 — Providencia: autorización del PO, banco mudado y cierre de deudas PD-01/PD-02

| Campo | Valor |
| --- | --- |
| Tipo | providencia |
| Fecha | 2026-11-10 |
| Autor | presidencia de la mesa |
| Corrige | — |

Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas: las del presidente (§1–§8).

## 1. Testimonio del PO (2026-11-10, en sesión, literal)

> aquí tenes que revisar el plan porque hubo cambios, pero si tenes autorizacion, luego de revisar,
> ha habido tantos cambios que ahora myai corre en i9dev

Excepción de barrido declarada (mismo criterio que el folio 021 §3 para el folio 004): «i9dev» en
el testimonio es un alias de equipo sin dirección, puerto ni credencial; se preserva la
transcripción literal.

Lectura de la presidencia: (a) el banco de ensayo my-ai se mudó de host; (b) el PO autoriza, previa
revisión del plan, ejecutar lo pendiente del lote del folio 021 §5 contra el banco nuevo. La fila 2
(instalar el cliente `ollama` en el puesto de verificación) no se da por autorizada: instalar en un
host exige ok explícito y el testimonio no lo nombra — sigue su default (todo por API).

## 2. Verificación del banco nuevo (despacho verificado)

- `GET /api/version` → `0.32.0-rc0` (la misma versión validada en los folios 004 y 011).
- `GET /api/tags` → 12 modelos: los 11 del testimonio del folio 004 **más `nomic-embed-text`**.
- `POST /api/embed` con `nomic-embed-text` → **responde embeddings** (vector real recibido);
  con un modelo generativo sigue el error «Start it with --embeddings», como antes.
- En el texto público el banco sigue siendo `localhost`/`$OLLAMA_HOST`: la mudanza de host no toca
  ninguna pieza de la guía.

## 3. Decisiones

1. **Fila 3 del lote (embeddings del banco): resuelta por el entorno.** Hay modelo dedicado de
   embeddings en el banco. El eje del documento 09 (biblioteca local, eje declarado no fijo) no se
   reescribe en esta unidad: queda asentado acá que el camino por banco ya es posible.
2. **PD-01 se cierra ahora** (su evento llegó: decisión de ACT-03/PO): corrida del tramo final del
   lab 6.B — entrenamiento (completo si el costo medido lo permite; si no, el reducido con el
   apartamiento declarado), fusión, GGUF, creación de `taller-qwen` y `taller-qwen-base` en el banco
   **por API**, comparación servida del paso 6 con salidas reales al documento 06, y **borrado de los
   dos modelos del banco al cerrar**. Constancia `despacho/verif-06b.md`, evidencia cruda en
   `evidencia/local/` (no versionada) con huella.
3. **PD-02 se cierra ahora**: se observa la revisión (commit del repositorio del modelo
   `paraphrase-multilingual-MiniLM-L12-v2`) con descarga fresca y se fija en los tres bloques
   «Protocolo de la cifra» del documento 09. Constancia `despacho/verif-09b.md`.
4. Tras las dos corridas, edición de conformidad sobre 06 y 09 (M3, mermaid, enlaces) y compuerta
   local del repo destino en verde antes del PR.
5. Entrega por Conformacion-Pull-Request-Automatico 2.0; la delegación asentada en los CHANGELOG
   (2026-11-07) cubre los PR del expediente 0001 en ambos repositorios.

Sigue: folio 023 (resolución de cierre de deudas, con las constancias incorporadas por cuenta) ·
despachos abiertos: corredor PD-01, corredor PD-02, editor de conformidad · insumos: folios 020,
021, constancias verif-06/verif-09, este folio · si se corta acá, las deudas quedan abiertas como
estaban y nada del banco queda ocupado (los modelos de prueba se borran incluso ante corte).
