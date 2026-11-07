# Bitácora 02 — Ronda de estructura: panel, refutación y veredicto

**Fecha:** 2026-11-07 · **Autor:** bitacorista de la ronda (agente) · **Estado:** vigente

Registro retomable de la fase 2 del plan (bitácora 01, §4). Continúa a
`01-arranque-y-enunciado.md`; el expediente del caso vive en
`OUTPUTs/Expedientes/0001-Guia-De-Estudio-IA-Model/` (actuaciones 001–004, informes en `despacho/`).
Esta bitácora existe por mandato del pedido (rol bitacorista) y porque el refutador constató que la
fase de comisiones había cerrado sin registro (RF-07): se asienta antes del cierre de la ronda.

## 1. Qué corrió en la ronda

1. **Composición del panel** (folio `actuaciones/003`): la propuesta de ocho comisiones excedía el
   techo «núcleo + cinco» de Rule-Mesa §3.4.5; el jurado resolvió por fusión temática, sin descartar
   ningún rol mandado: tres variables (V1 Fundamentos/arquitecturas/panorama; V2 Entrenamiento,
   ajuste fino y métricas; V3 Inferencia local, RAG y bases vectoriales) + dos ad hoc con carta
   (A1 Arquitectura de sistemas IA; A2 Edición académica, pedagogía y publicación científica) +
   núcleo permanente (refutador y jurado). Bitacorista, entrevistador y secretaría quedaron fuera
   del panel, asignados a sus fases (folio 003 §5).
2. **Comisiones a ciegas**: las cinco emitieron informe en `despacho/` (prefijos FP-, EM-, H-IR-,
   ARQIA-, H-EDI-), cada una con su carta, clase de objeto «diseño de una norma o decisión» y
   Cadena-De-Consecuencias §2 antes de elegir entre opciones. Ninguna propuso ficha de excepción.
3. **Providencia sobreviniente** (folio `actuaciones/004`): el PO confirmó el banco my-ai como medio
   de pruebas; sólo suma medios (once modelos verificados por `/api/tags`, Qwen entre ellos). En el
   texto público los ejemplos usan `localhost`; el host real no se versiona.
4. **Refutación** (`despacho/refutador.md`): ocho hallazgos RF-01…RF-08; atacó sobre todo el costo
   de aplicar la estructura (clase norma/decisión), degradó un ancla mal construida (RF-05) y
   recortó un agregado sin frase del pedido (RF-04). Propuso el mapa consolidado (§5) y el lote
   filtrado (§6).
5. **Veredicto** (`despacho/jurado-veredicto.md`): 45 hallazgos consolidados, **45 PROCEDE, 0 NO
   PROCEDE, 0 ARCHIVA**, todos 5–0 (constancia de homogeneidad con causa observable: refutación
   efectiva + trabajo a ciegas + convergencia triple independiente sobre Ollama/Qwen). Rendimiento
   7,5 por especialista. Con una sola ronda, si la presidencia cierra, el rótulo es «por decisión».

## 2. Temario y marco aprobados (resumen; la letra manda en `despacho/jurado-veredicto.md`)

- **Temario** (§2 del veredicto): once núcleos con dueño único, adoptando el mapa del refutador —
  01 Representación del lenguaje · 02 Transformer y variantes · 03 Del modelo base al asistente ·
  04 Datos y corpus · 05 Preentrenamiento y leyes de escala · 06 Ajuste fino y alineación ·
  07 Evaluación y métricas · 08 Inferencia local · 09 Bases vectoriales y RAG · 10 Multimodalidad ·
  11 Panorama y ecosistema abierto (única capa volátil, fechada). Ruta formativa:
  M0 → M1 → 01 → 02 → 03 → 08 → 04 → 05 → 06 → 07 → 09 → 10 → 11.
- **Marco de referencia** (§3): siete escenarios ESC-01…ESC-07 (elegir, servir, RAG, ajustar,
  evaluar, multimodal, integrar —el 07 remite a la guía 16—), seis contextos CTX-01…CTX-06 (piso
  CPU 8–16 GB; banco en red con `OLLAMA_HOST`; API de terceros; datos sensibles; contenedor/CI) y
  seis actores ACT-01…ACT-06 definidos por lo que deciden (el ajustador se funde en el
  estudiante-lector actuando en ESC-04).
- **Estructura documental** (§4): 15 piezas bajo `Guides/IA/IA-Model/` del repo destino —
  `IA-Model-Guide.md` como raíz portada-índice (M0), `Marco-De-Referencia.md` (M1),
  `Cohesion-Global.md` (M2, grafo de dependencias), `Convenciones.md` (M3, citado APA, protocolo
  por cifra, contrato de profundidad, vigencia) y los once temáticos. Frontmatter normado con
  prefijo `IAM-`. Documento temático: envoltura + definición + aplicación por escenario + 2–3
  laboratorios operables con dueño único + bloque didáctico (absorbe «Preguntas guía») + criterios
  de calidad + anexo.
- **Ejemplos operables por verbo del pedido** (§4, PREGUNTA 4): montar/descargar → doc 08; inferir
  → 03 y 08; entrenar → 06 (QLoRA sobre Qwen ≤1.5B, export GGUF; demo juguete en 05); medir → 07;
  RAG → 09; multimodal → 10; elegir → 11. Cada laboratorio existe una sola vez; el resto lo cita.

## 3. Hallazgos por nivel y su suerte

Los 45 procedieron; lo relevante para retomar es qué corrección quedó mandada:

- **P1 (quince)**: alcance multimodal cubierto en doc 10 (FP-01); prerrequisitos del lector
  declarados en ACT-01 (FP-02); cadena de entrenamiento operable HF → GGUF → Ollama porque Ollama
  no entrena (EM-01/ARQIA-01); «entrenar» = ajuste fino operable + demo conceptual (EM-02);
  protocolo por cifra (EM-03) y contrato de profundidad (EM-04) en M3; Ollama/Qwen reclasificado
  como medio del contrato, no requisito del pedido (H-IR-01/RF-03/ARQIA-04/H-EDI-01, convergencia
  triple; la corrección va al origen); el banco no tiene modelo de embeddings (H-IR-02, obstáculo
  por canal directo, no al lote); autocontenido/no-delta definidos operativamente antes de
  despachar redactores (ARQIA-03); portada-índice + cuerpo multi-documento (H-EDI-02); dos rutas
  de lectura (H-EDI-03); consolidación de 31 núcleos en once con dueño único (RF-01) y presupuesto
  editorial medible (RF-02, opción B votada con condición de revisión en ronda 2).
- **P2 (veinticuatro)**: tabla de modelos de referencia y capa volátil única en doc 11
  (FP-04/FP-05/ARQIA-02/H-EDI-06); «pesos abiertos» según OSAID 1.0 (FP-06); frontera métricas de
  calidad (doc 07) / de servicio (doc 08) (EM-05); contaminación de benchmarks como contenido de
  primera clase (EM-06); licencias al doc 04 (EM-07) y «Datos y corpus» como núcleo propio
  (EM-08); `OLLAMA_HOST` + paso 0 de verificación (H-IR-03); defaults de hardware (H-IR-04);
  prefijo `IAM-` verificado libre (ARQIA-06); grafo de dependencias como entregable de M2
  (ARQIA-07); citado autor-año y frontmatter de la casa (H-EDI-04/05); forma del bloque didáctico
  (H-EDI-07/ARQIA-05); gobernanza regulatoria fuera de alcance (RF-04); re-anclado de FP-03
  (RF-05); lote filtrado de catorce dudas a cuatro + cortesía (RF-06); bitácora por fase (RF-07).
- **P3 (seis)**: regla de corte del glosario (FP-07); glosario bilingüe con forma canónica
  (EM-09/H-EDI-08); agregado RAG asentado como marcado (FP-03/H-IR-05, fila 4 del lote); frase
  trunca del pedido registrada como ilegible (ARQIA-08, cortesía del lote); trazabilidad de la
  forma multi-documento al Profile (RF-08).

## 4. Dudas que quedaron para el lote al PO (veredicto §5, cada una con su «SI NO RESPONDÉS»)

1. ¿Hay GPU para los laboratorios de ajuste fino y cuál es el piso de hardware del lector?
   (default: CPU x86-64 / 16 GB, Qwen ≤1.5B, labs largos «ilustrativo»).
2. ¿Generación de imagen/audio con laboratorio operable o nivel conceptual en doc 10?
   (default: conceptual con ejemplo marcado «ilustrativo»).
3. ¿El lector maneja terminal y un lenguaje básico? (default: supuesto de ACT-01).
4. Ratificación de agregados marcados: Qwen/Ollama como medio y RAG como lectura aplicada de
   «bases vectoriales» (default: quedan «propuesto, sin ratificar»; nada irreversible depende).
5. (Cortesía P3) La frase trunca «…modelos open sorce con el modelo.» ¿nombraba otro modelo?

Además, **un obstáculo por canal directo** (no va al lote): pedir al operador del banco un modelo
de embeddings (`POST /api/embed`); si no, rige la biblioteca local como camino alternativo.

## 5. Qué sigue

- Incorporación del veredicto como actuación, consolidación y resolución de la presidencia
  (cierre de ronda «por decisión», con lo abierto del §4 enumerado; folio `resolucion`).
- Elevación del lote al PO por el entrevistador (fase de cierre de dudas).
- **Fase 3 — elaboración por núcleos** (workflow «elaboracion-nucleos», bitácora 01 §4): antes de
  despachar redactores quedan por fijar prefijo/vocabulario `doc_type` (ARQIA-06) y M2/M3 como
  insumos normativos; un redactor por documento (M0–M3 + 11 temáticos), verificador técnico contra
  el banco y editor académico; A2 se desdobla si el volumen de verificación lo exige (folio 003 §3).

**Sigue:** Bitácora 03, tras la fase de elaboración.
