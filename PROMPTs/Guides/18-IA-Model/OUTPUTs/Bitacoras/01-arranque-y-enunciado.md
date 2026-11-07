# Bitácora 01 — Arranque, enunciado y plan por núcleos conceptuales

**Fecha:** 2026-11-07 · **Autor:** presidencia de la mesa (agente) · **Estado:** vigente

Registro retomable exigido por la regla de descomposición conceptual del prompt
(`PROMPTs/Guides/18-IA-Model/01-Crear-Study.Guide.md`). Las bitácoras de esta serie viven en
`OUTPUTs/Bitacoras/`; el expediente de la mesa, en `OUTPUTs/Expedientes/0001-guia-de-estudio-ia-model/`.

## 1. Pedido

Crear una guía de estudio práctica sobre modelos de IA (NLP, IA generativa, multimodales,
arquitecturas, transformers, métricas, motores de inferencia, bases vectoriales y términos
asociados) para un estudiante que no conoce el tema, en
`Lab-Documentos/Guides/IA/IA-Model/IA-Model-Guide.md`, mediante una mesa de expertos basada en
`Knowledge-Mesa-De-Expertos-A-Pedido` 3.1 y `Knowledge-Mesa-Consulta-A-Un-Tercero` 2.0, con
Profile `Study-Guide-Documentation` (RuleSet `Study-Guide`: Rule-All, Workflow, Evidences,
Markdown, Documentation, Indexing, Agents, Dual-Audience, Narrative-Voice).

## 2. Enunciado (lectura del pedido, §3.1 de la mesa a pedido)

| Frase del pedido | Función |
| --- | --- |
| «guía de estudio práctica pensada para quien nunca ha visto el tema» | Requisito: audiencia principiante, recorrido formativo |
| «incluya ejemplos, los pasos necesarios para montar modelos, descargarlos, entrenarlos» | Requisito: contenido práctico operable |
| «arquitecturas… transformers… métricas, motor de inferencia… bases de datos vectoriales, términos asociados» | Requisito: alcance temático mínimo |
| «Actualmente tenemos corriendo diferentes modelos de qwen» (open source) | Dato: el entorno del equipo usa modelos Qwen open source; los ejemplos deben serle aplicables |
| «Elaborar una guía en `…/Guides/IA/IA-Model/IA-Model-Guide.md`» | Requisito: ruta del entregable |
| «definiciones, gráficos, cuadros comparativos, preguntas guía con respuestas explicativas» | Requisito: recursos didácticos |
| «Planifica primero el temario, luego borrador, evalúa y reajusta, luego especialistas forman el contenido» | Requisito: orden del proceso |
| «consulta y también de referencia» | Requisito: doble uso (recorrido + consulta) |
| «Crea una mesa basada en los conocimientos …» + roles enumerados | Requisito: proceso por mesa; el panel incluye analistas/arquitectos de sistemas y modelos IA, editores bibliográficos/académicos, publicadores científicos, bitacoristas |
| «La mesa debería abrir los expedientes si se requiere tal seguimiento» | Deseable→adoptado: se abre expediente (el caso atraviesa varias corridas) |
| «basarse en las tendencias del mercado y los estándares de la industria» | Requisito: fuentes externas citables |
| Reglas: jerarquía, autocontenido, índices, descomposición por núcleos, bitácoras, no inventar, evidencia verificable | Requisitos |

**Sujeto:** la guía a crear (no existe aún: `Guides/IA/IA-Model/IA-Model-Guide.md` está vacío y sin
versionar en el clon principal). **Caso que funciona (referencia de forma, no de contenido):** las
guías 01–16 ya fusionadas del repo, con sus convenciones (`ia-db/indexes/10_Convenciones-y-Glosario.md`:
frontmatter `doc_id`, catálogos `ESC-/CTX-/ACT-`, marcas de autoridad). **Lectura con dos
interpretaciones, tomada la que menos agrega:** el pedido nombra UN archivo pero el Profile exige un
conjunto documental (marco, mapa, documentos por tema, anexos, README); se resuelve con
`IA-Model-Guide.md` como documento raíz (índice + mapa de lectura) y el conjunto en la misma carpeta
`Guides/IA/IA-Model/`. La mesa lo ratifica o corrige en la ronda de estructura.

## 3. Decisiones de arranque de la presidencia

- Convivencia (reglas R1–R8 del 2026-10-28): clones principales intactos; trabajo en worktrees
  `<worktree-guia>` (Lab-Documentos, rama `g18/ia-model-guide`) y
  `<worktree-doc>` (Lab-Documentos.Documentacion, rama `g18/ia-model-outputs`).
- Expediente 0001 del caso en `OUTPUTs/Expedientes/0001-guia-de-estudio-ia-model/` (secretaría lo arma
  conforme a Rule-Expediente 1.0).
- Banco de ensayo para ejemplos prácticos: Ollama alcanzable en la red interna del equipo
  (verificado: `GET /api/tags` responde; hay `qwen3-coder:30b` entre otros). En el texto público los
  ejemplos usan `localhost`; la evidencia cruda con hosts internos queda local, fuera del versionado.
- `Guides/IA/references/` del clon principal es material del usuario no señalado por el prompt: no se lee.
- La guía 16 (`Dot-Net-Integration-AI-Layer-Guide`) ya está en main: la 18 la referencia para la
  integración .NET en lugar de duplicarla.
- Consulta a un tercero: no hay tercero por canal en este caso; el protocolo 2.0 se aplica en su parte
  de recolección de dudas (entrevistador destila las de los especialistas) y lo que sobreviva sale al
  PO en un solo lote con `SI NO RESPONDÉS` en el cierre.

## 4. Plan por fases (descomposición por núcleos conceptuales)

1. **Contrato y despacho** (presidencia): folio 002-providencia con contrato de entrada, cartas en
   `evidencia/`.
2. **Ronda de estructura** (workflow «mesa-ronda-estructura»): jurado compone el panel; comisiones a
   ciegas proponen núcleos conceptuales, temario y marco de referencia (escenarios/contextos/actores);
   refutador; jurado vota el temario. Salida: temario aprobado + mapa de cohesión inicial.
3. **Elaboración** (workflow «elaboracion-nucleos»): un redactor especialista por núcleo + verificador
   técnico (corre los ejemplos contra el banco de ensayo) + editor académico. Salida: documentos de la
   guía + glosario + anexos + mapa de cohesión.
4. **Integración y revisión** (workflow «integracion-revision»): verificación cruzada contra el mapa,
   refutación global, correcciones, veredicto final del jurado.
5. **Cierre y entrega**: README/índices, actualización incremental de la ia-db, barrido de secretos,
   folio de resolución, PRs y fusión por `Knowledge-Conformacion-Pull-Request-Automatico` 2.0.

Cada fase deja su bitácora numerada en esta carpeta; los subagentes consultan avances e historial acá.

**Sigue:** Bitácora 02, tras la ronda de estructura.
