# Bitácora 03 — Fase de elaboración: redacción, verificación y edición por núcleos

**Fecha:** 2026-11-07 · **Autor:** bitacorista de la fase de elaboración (agente) · **Estado:** vigente

Registro retomable de la fase 3 del plan (folio `actuaciones/012`, resolución parcial). Continúa a
`01-arranque-y-enunciado.md` y `02-ronda-de-estructura.md`. Expediente del caso:
`OUTPUTs/Expedientes/0001-Guia-De-Estudio-IA-Model/`. Rutas de la guía relativas al repo destino
(`<worktree-guia>` = worktree de Lab-Documentos, rama `g18/ia-model-guide`); las del expediente,
relativas a `OUTPUTs/` (`<worktree-doc>`).

## 1. Marco de la fase

- Mandato: folio 012 — la mesa no redacta; roles fuera del panel con carta en `evidencia/`
  (redactor estructural 014, redactor temático 011, verificador técnico 012, editor académico 013).
- Secuencia por pieza: redactor → verificador → editor, en tubería; barrera única antes de M2/M0
  (que se escriben con el conjunto ya cerrado). Orden respetado: M3 y M1 primero, M2 y M0 al final.
- Banco: Ollama real por `$OLLAMA_HOST` (folio 004), 11 modelos; `/api/embed` deshabilitado
  (verificado en folio 012 §2) → el doc 09 usa biblioteca local de embeddings, como mandó el jurado.

## 2. Piezas escritas (árbol `Guides/IA/IA-Model/` del repo destino)

Las 15 piezas del folio 011 §4 existen; 8.624 líneas en total.

| Pieza | Líneas | | Pieza | Líneas |
| --- | --- | --- | --- | --- |
| `IA-Model-Guide.md` (M0, raíz) | 165 | | `06-Ajuste-Fino-Y-Alineacion.md` | 728 |
| `Marco-De-Referencia.md` (M1) | 276 | | `07-Evaluacion-Y-Metricas.md` | 824 |
| `Cohesion-Global.md` (M2) | 285 | | `08-Inferencia-Local.md` | 754 |
| `Convenciones.md` (M3) | 358 | | `09-Bases-Vectoriales-Y-RAG.md` | 870 |
| `01-Representacion-Del-Lenguaje.md` | 568 | | `10-Multimodalidad-Y-Generacion-No-Textual.md` | 607 |
| `02-Arquitectura-Transformer.md` | 643 | | `11-Panorama-Y-Ecosistema-Abierto.md` | 586 |
| `03-Del-Modelo-Base-Al-Asistente.md` | 740 | | | |
| `04-Datos-Y-Corpus.md` | 596 | | | |
| `05-Preentrenamiento-Y-Leyes-De-Escala.md` | 624 | | | |

## 3. Verificación técnica (constancias `despacho/verif-NN.md`; evidencia cruda en `evidencia/local/`, fuera del versionado)

Nueve constancias emitidas: 01–05, 08–11. Ninguna declaró BLOQUEO.

| Doc | Verificados | Corregidos | Ilustrativos | Nota |
| --- | --- | --- | --- | --- |
| 01 | 3 labs + 1 cifra M3 + 4 anclas | 2 pasajes (§3.1 y reenvío §4) | 0 | cl100k contrastado; reenvío re-anclado al ejemplo 2 |
| 02 | 2 | 2 (comandos `/api/show`: digest y patrón `ssm/full_attention`) | 1 (`ollama show`, sin CLI en el puesto) | fichas 4b y 35b-a3b (MoE) cotejadas campo a campo |
| 03 | 6 | 2 (lab 03-A pasos 1–2: dos predicciones del texto FALLARON en el banco y se reescribieron con salidas reales — prueba ingenua del base y «respuesta dominante» incorporada como contraejemplo medido) | 0 | streaming NDJSON y SSE observados; digests coinciden |
| 04 | 5 (incl. 1 adversarial del modo de falla) | 0 | 0 | bit a bit; sin ediciones |
| 05 | 2 | 1 cifra de protocolo (duración 1,4 s → 1,1 s) | 0 | salida byte a byte; aritmética de escala recomputada |
| 08 | 7 | 4 (CLI → `/api/ps`//api/show`, órdenes de magnitud y nota de caché en 08-B) | 1 (`ollama pull`: la carta prohíbe descargar al banco) | mermaid validado con `tools/medios/mermaid.sh` |
| 09 | 2 | 3 (labs 2–3: placeholders `VERIFICAR` reemplazados por salidas reales; cifras al corpus sembrado) | 0 | el corpus del redactor no se preservó: el verificador sembró uno equivalente y lo transcribió completo en §3.2 (reproducibilidad restaurada) |
| 10 | 5 | 0 | 1 (§3.3, generación de imagen — conforme al default del lote) | conteo frágil del VLM observado y explotado didácticamente |
| 11 | 3 | 2 (comando 11.A paso 4; mermaid §1.7) | 0 | las 11 filas de la tabla §1.6 cotejadas una a una contra el banco |

Totales: **35 verificados · 16 corregidos · 3 ilustrativos · 0 bloqueos**. En todos los casos la
corrección fue con evidencia (log con SHA-256) y salida real pegada; ningún marcador `VERIFICAR`
queda en los documentos verificados; sin rutas de host ni URL del banco en el texto versionado
(el banco figura como `$OLLAMA_HOST`/`localhost`).

## 4. Bloqueos y observaciones para la ronda 2

1. **Faltan las constancias de los docs 06 y 07** (`verif-06.md`, `verif-07.md` no existen en
   `despacho/`). Los documentos están escritos (728 y 824 líneas). La ronda 2 NO debe dar por
   verificados sus ejemplos (QLoRA/export GGUF en el 06; métricas en el 07) hasta que la
   verificación cierre o quede constancia de su estado.
2. **Cliente `ollama` ausente en el puesto de verificación** (verif-02, duda al PO): los pasos
   que lo prescriben quedaron ilustrativos o traducidos a su equivalente de API. Decidir si se
   instala (versión fija, regla «consultar antes de instalar») o si el equivalente API basta.
3. **`/api/embed` sigue deshabilitado en el banco** (folio 012 §2): el doc 09 corre con
   sentence-transformers local. La habilitación quedó como pedido por canal directo al operador.
4. **Empate 0,421/0,421 en el lab 2 del doc 09** (verif-09, observación no bloqueante): otra
   versión del modelo de embeddings puede invertir el orden; el corpus transcripto y las
   versiones fijadas acotan el riesgo.
5. **Doc 11, tabla §1.5**: filas sin fuente primaria quedaron marcadas «primaria pendiente de
   verificación» en el propio documento — revisarlas en ronda 2 (capa volátil, fechada).
6. **Lote al PO** (bitácora 02 §4): sigue sin respuestas asentadas; se trabajó con los defaults
   (ningún asentimiento por silencio; nada quedó bloqueado).
7. Verificaciones de los docs 01 y 09 corridas en contenedor `python:3.12.16-slim` con venv
   propio y versiones fijadas, idénticas al `entorno_validado` de cada documento; el resto en
   Python 3.11.2 local o contra el banco según declara cada constancia.

## 5. Qué sigue

1. **Ronda 2 de la mesa** (revisión del borrador completo, folio 012): revisita del presupuesto
   editorial (condición de RF-02, opción B), los puntos del §4 de esta bitácora —los docs 06 y 07
   primero—, cohesión M2/M0 contra el conjunto ya escrito y conformidad con M3.
2. Cierre de las verificaciones pendientes (06, 07) con constancia en `despacho/`.
3. **Entrega** por `Knowledge-Conformacion-Pull-Request-Automatico` 2.0: PR de la rama de la guía
   (`g18/ia-model-guide`) y PR de outputs (`g18/ia-model-outputs`), tras el veredicto de ronda 2.
4. Expediente: incorporar esta bitácora como folio (013 o siguiente) y asentar el resultado de la
   ronda 2.

Si se corta acá: lo escrito y verificado queda; retoman primero las verificaciones 06–07 y luego
la ronda 2. **Sigue:** Bitácora 04, tras la ronda 2 y la entrega.
