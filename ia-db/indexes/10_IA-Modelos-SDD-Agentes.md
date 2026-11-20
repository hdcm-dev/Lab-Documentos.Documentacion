# 10 · IA: modelos, SDD y agentes

> **Propósito**: inventario y destilado de `Guides/IA/` **excepto** `Dot-Net-Integration-AI-Layer-Guide/`
> (que tiene índice propio): la guía de estudio de modelos de IA `IA-Model/` (15 piezas, prefijo
> `IAM-`), la metodología `SDD-Guide/`, el catálogo de especialidades `AG-xx`, los prompts de
> refinamiento documental, y dos notas sueltas (`Claude-Guide.md/`, `references/notas/`).
> 38 archivos `.md`, 13 783 líneas (`wc -l`): 8 924 en `IA-Model/` y 4 859 en el resto.
> **Fuente primaria**: frontmatter YAML de `IA-Model/` (`doc_id`, `status`, `last_review`,
> `traces`, `entorno_validado`); para el material importado, encabezados «Documento / Versión /
> Fecha» e índices internos de cada archivo; `CHANGELOG.md` para la historia de la guía 18.
> **Base**: `Lab-Documentos` en `main` 34929f2. Todas las rutas son relativas a `Lab-Documentos/`.

## Advertencias de lectura

- **Dos mundos en una carpeta.** `IA-Model/` es material **generado en el repo** (2026-11-07,
  `origin: ia-generated`) con aparato propio de frontmatter; todo lo demás (SDD, AG-xx,
  refinamiento) **llegó ya escrito** desde el proyecto *Motor DSL de Generación de Documentos*
  (abril de 2026) y **no tiene `doc_id`**: se identifica por ruta.
- Los IDs del material importado (`AG-xx`, `SA-xx`, `NB-xx`, `CU-xx`, `RN-xx`, `US-xx`, `BT-xx`,
  `TK-xx`) son **del proyecto de origen**; no remiten a nada de este repo. Los `ACT-xx` de
  `IA-Model/` tampoco equivalen a los `AG-xx`.
- Las rutas `docs/00_contexto/…`, `docs/11_examples/…` que citan las fichas AG **no existen acá**
  (ver H-10.03).
- **Dos numeraciones de subagentes** que no coinciden: `AG-ROOT…AG-11` (13 perfiles) y
  `SA-01…SA-12` (12 subagentes del prompt). Leé el ID junto al nombre del perfil (H-10.04).
- Nombres con rarezas: `Spec-Driven Development-SDD.md` (espacio), `Claude-Guide.md/` (un
  **directorio** con extensión `.md`), `prompt_refinanmiento.md` (errata «refinanmiento»).
  Citalos entre comillas en la shell.

## Inventario

### `Guides/IA/IA-Model/` — guía 18, modelos de IA

Todas con `status: borrador`, `origin: ia-generated`, `audience: [humano, agente]`.

| Archivo | doc_id | doc_type | last_review | confidence | Líneas | Qué es |
|---|---|---|---|---|---:|---|
| `IA-Model-Guide.md` | `IAM-M0` | indice | 2026-11-07 | alta | 165 | Portada, tabla de contenido, ruta formativa y ruta de consulta |
| `Marco-De-Referencia.md` | `IAM-M1` | marco-de-referencia | 2026-11-07 | media | 319 | Catálogos ESC/CTX/ACT, glosario bilingüe, normalización de grafías |
| `Cohesion-Global.md` | `IAM-M2` | mapa | 2026-11-10 | alta | 289 | Grafo de dependencias, autocontenido/no-delta, fronteras, dueño único de labs |
| `Convenciones.md` | `IAM-M3` | marco-de-referencia | 2026-11-07 | alta | 387 | Reglamento editorial: identidad, APA 7, ejemplo operable, «protocolo», vigencia, plantilla |
| `01-Representacion-Del-Lenguaje.md` | `IAM-01` | tema | 2026-11-07 | alta | 568 | Texto → tokens, vocabularios, embeddings, similitud, ventana de contexto |
| `02-Arquitectura-Transformer.md` | `IAM-02` | tema | 2026-11-07 | alta | 643 | Atención, *decoder-only*, posición, MoE |
| `03-Del-Modelo-Base-Al-Asistente.md` | `IAM-03` | tema | 2026-11-07 | alta | 745 | Base/*instruct*, muestreo, *prompting*, razonamiento, alucinación |
| `04-Datos-Y-Corpus.md` | `IAM-04` | tema | 2026-11-07 | alta | 630 | Formatos de dataset, limpieza, deduplicación, contaminación, licencias y procedencia |
| `05-Preentrenamiento-Y-Leyes-De-Escala.md` | `IAM-05` | tema | 2026-11-07 | alta | 624 | Objetivo autoregresivo, pérdida/perplejidad, checkpoints, economía; demo en CPU |
| `06-Ajuste-Fino-Y-Alineacion.md` | `IAM-06` | tema | **2026-11-10** | alta | 819 | SFT, LoRA/QLoRA, DPO/RLHF; cadena PEFT/TRL → GGUF → motor local |
| `07-Evaluacion-Y-Metricas.md` | `IAM-07` | tema | 2026-11-07 | alta | 874 | Perplejidad, métricas de tarea, benchmarks y contaminación, LLM-juez, eval propio |
| `08-Inferencia-Local.md` | `IAM-08` | tema | 2026-11-07 | alta | 759 | llama.cpp/Ollama/vLLM, GGUF, cuantización, memoria; «paso 0» del banco |
| `09-Bases-Vectoriales-Y-RAG.md` | `IAM-09` | tema | **2026-11-10** | alta | 877 | Embeddings aplicados, ANN/HNSW, motores vectoriales, pipeline RAG y diagnóstico |
| `10-Multimodalidad-Y-Generacion-No-Textual.md` | `IAM-10` | tema | 2026-11-07 | alta | 607 | VLM, audio, difusión: qué cambia respecto del transformer |
| `11-Panorama-Y-Ecosistema-Abierto.md` | `IAM-11` | tema | 2026-11-07 | **media** | 618 | Familias, licencias, *model cards*, tabla de referencia, criterio de selección (capa volátil) |

`owner` es `ACT-06` (mantenedor) en todas salvo `IAM-04` (`ACT-05`, curador de datos) e `IAM-07`
(`ACT-04`, evaluador) (verificado en el frontmatter de las 15 piezas).

### Resto de `Guides/IA/` — material importado

| Ruta | Versión · fecha | Líneas | Qué es |
|---|---|---:|---|
| `Guides/IA/SDD-Guide/Metodologia-Prompting-SDD-Guide.md` | 1.0 · 2026-04-06 · Activo | 671 | **Núcleo**: prompting colaborativo Claude ↔ Copilot bajo SDD |
| `Guides/IA/SDD-Guide/Spec-Driven Development-SDD.md` | s/d | 79 | Los tres niveles de SDD y marco de decisión |
| `Guides/IA/SDD-Guide/Secciones-Disciplinas-Especialidades-Tables.md` | s/d | 80 | Tablas: secciones `00…11` de `/docs/`, especialidades, trazabilidad, agente → doc |
| `Guides/IA/SDD-Guide/References.md` | s/d | 5 | Tres URL de `agentfactory.panaversity.org` (SDD, markdown writing, three levels) |
| `Guides/IA/references/agentes-especialidades/README.md` | 2026-04-04 | 74 | Índice de las 13 especialidades y orden de lectura |
| `Guides/IA/references/agentes-especialidades/AG-ROOT…AG-11` (13 archivos) | s/d | 187–286 c/u (3 204) | Una ficha por especialidad, estructura fija |
| `Guides/IA/references/agentes-especialidades/tabla-caracterizacion-agentes.md` | 1.0 · 2026-04-03 | 29 | Tabla de caracterización (≈ §1 del siguiente) |
| `Guides/IA/references/refinamiento_docs/agentes-refinamiento-docs.md` | 1.0 · 2026-04-03 | 515 | Perfiles, criterios por agente y **prompt maestro** de orquestación |
| `Guides/IA/references/refinamiento_docs/prompt_refinanmiento.md` | s/d | 189 | Variante «lista para ejecutar» del prompt maestro (SA-01…SA-12) |
| `Guides/IA/references/notas/tools.md` | s/d | 7 | Atajos de vista previa Markdown en VS Code (no es material de IA) |
| `Guides/IA/Claude-Guide.md/Fast-Guide.md` | s/d | 6 | Nota: reanudación automática de Claude Code al recuperar el límite de uso |

Fichas AG (líneas): ROOT 187 · 00 228 · 01 223 · 02 268 · 03 253 · 04 245 · 05 256 · 06 204 ·
07 279 · 08 264 · 09 257 · 10 254 · 11 286.

## Árbol del dominio

```
Guides/IA/
├── IA-Model/                    ← guía 18: QUÉ es un modelo y cómo se trabaja con él
│   ├── IA-Model-Guide.md (M0) · Marco-De-Referencia.md (M1)
│   ├── Cohesion-Global.md (M2) · Convenciones.md (M3)
│   └── 01-…11-*.md              (núcleos temáticos IAM-01…IAM-11)
├── SDD-Guide/                   ← el MÉTODO (cómo se trabaja con IA bajo SDD)
├── references/
│   ├── agentes-especialidades/  ← los PERFILES AG-xx (quién revisa cada sección)
│   ├── refinamiento_docs/       ← los PROMPTS (orquestador + subagentes SA-xx)
│   └── notas/tools.md
├── Claude-Guide.md/Fast-Guide.md   ← directorio con nombre .md
└── Dot-Net-Integration-AI-Layer-Guide/  → fuera de este índice (integración .NET y diseño conversacional)
```

## 1. Guía de modelos de IA (`IA-Model/`)

**Qué promete** (`IAM-M0` §1): para un lector **sin conocimiento previo de IA**, con terminal y
programación básica como únicos supuestos (ACT-01), cerrar habiendo servido un modelo local,
hablado por API con muestreo controlado, ajustado uno chico, medido con un eval propio, indexado
un corpus con RAG y elegido un modelo leyendo su *model card*. Forma **criterio**, no es tutorial
de una herramienta. Doble audiencia humano/agente.

**Origen** (`IAM-M0`, `CHANGELOG.md` entradas 2026-11-07 y 2026-11-10): expediente 0001
(«Guia-De-Estudio-IA-Model») de la guía 18; estructura y temario son decisiones del folio 011
§2 y §4. El expediente vive en el repo de documentación, **no** en éste.

### 1.1 Marco de referencia (`IAM-M1`)

| Catálogo | IDs | Contenido destilado |
|---|---|---|
| Escenarios | `ESC-01…07` | Elegir modelo · montar y servir local · RAG sobre corpus propio · adaptar a dominio · evaluar con evidencia · multimodal · integrar en app (remite a la guía de integración .NET, no se duplica) |
| Contextos | `CTX-01…06` | CPU 8–16 GB (**piso del lector**) · GPU de consumo · servidor en red local (banco, `OLLAMA_HOST`) · API de terceros · datos sensibles sin internet · contenedor/CI |
| Actores | `ACT-01…06` | Estudiante-lector · desarrollador integrador · operador del banco · evaluador · curador de datos · mantenedor de la guía |

§5 glosario bilingüe con forma canónica única por término; §6 normalización de grafías e idioma.

### 1.2 Orden de lectura

**Ruta formativa** (`IAM-M0` §3, derivada del grafo de `IAM-M2` §2):

```
M0 → M1 → 01 → 02 → 03 → 08 → 04 → 05 → 06 → 07 → 09 → 10 → 11
```

- **08 va temprano a propósito**: depende sólo de 02 y 03, y desde ahí el lector tiene un
  modelo servido (el «paso 0» del banco) contra el que pegan los labs de 04–11. Es la única
  alteración del orden numérico; los enlaces Anterior/Siguiente siguen esta ruta (03 → 08 → 04).
- **04 → 05 → 06 → 07** es el ciclo de vida del modelo; se lee en bloque.
- **11 cierra siempre**: es el único sumidero del grafo y la capa volátil.
- **M3 no está en la fila**: es el reglamento; se consulta al primer laboratorio o primera cifra.

**Ruta de consulta** (`IAM-M0` §4), «estoy acá, qué leo»:

| Necesidad | Entrada | Apoyo |
|---|---|---|
| Elegir modelo (ESC-01) | 11 | 08 (memoria) |
| Montar y servir local (ESC-02) | 08 | 02, 03 |
| Responde mal o distinto cada vez | 03 (muestreo, semilla, alucinación) | 07 |
| Preguntar a mis documentos (ESC-03) | 09 | 01, 08 |
| Adaptar a mi dominio (ESC-04) | 06 (abre con la decisión prompt / RAG / ajuste) | 04 |
| Evaluar/comparar (ESC-05) | 07 | 03 |
| Imagen o audio (ESC-06) | 10 | 02 |
| Integrar en una app (ESC-07) | `Guides/IA/Dot-Net-Integration-AI-Layer-Guide/Dot-Net-Integration-AI-Layer-Guide.md` | — |
| Término dudoso | M1 §5–§6 | — |
| Una cifra no coincide con la web | 11 + M3 §6 (ganó la web) | `last_review` |
| Un lab no reproduce | M3 §3 y §4 | 08 |

### 1.3 Grafo de dependencias (`IAM-M2` §2)

| doc_id | Depende de | Por qué |
|---|---|---|
| IAM-01 | — | Punto de entrada |
| IAM-02 | 01 | La atención opera sobre tokens y embeddings |
| IAM-03 | 02 | Base/instruct presupone el decoder-only |
| IAM-04 | 03 | Los pares instrucción→respuesta motivan formatos de dataset |
| IAM-05 | 04 | Preentrenar es consumir un corpus |
| IAM-06 | 05 | El ajuste parte de un checkpoint |
| IAM-07 | 03, 06 | Sin muestreo fijado no hay corridas comparables |
| IAM-08 | 02, 03 | Parámetros y ventana dimensionan memoria |
| IAM-09 | 01, 08 | Embeddings de 01; servir por API de 08 |
| IAM-10 | 02, 03 | El VLM es un transformer con otro frente |
| IAM-11 | 05–10 | Elegir modelo exige todo el recorrido |

Invariantes que el mantenedor debe conservar: **acíclico** (un ciclo se resuelve moviendo
contenido, no con una flecha) e **IAM-11 único sumidero**. IAM-M1 no es nodo: es apoyo permanente.

### 1.4 Decisiones editoriales clave

| Decisión | Fuente |
|---|---|
| Cada temático es **autocontenido y no-delta**: prerrequisitos declarados al abrir («Antes de leer»), nunca exige leer una versión anterior de sí mismo | `IAM-M2` §3; `IAM-M0` §5 |
| **Dueño único de laboratorio**: cada ejemplo operable existe una vez; los demás enlazan | `IAM-M2` §5 |
| Ejemplo **operable** = entorno + versiones fijadas + salida esperada; lo no reproducible se marca «ilustrativo» | `IAM-M3` §3 |
| Toda cifra medida lleva bloque **«protocolo»** (su corrida) | `IAM-M3` §4 |
| Extensión orientativa del temático **350–700 líneas**; superarla exige apartamiento declarado (06, 07, 08, 09 lo superan) | `IAM-M3` §5; envoltura de `IAM-06` |
| Vigencia en `last_review`; 01–10 envejecen lento, 11 caduca por diseño | `IAM-M3` §6 |
| Plantilla fija del temático: definición · aplicación por escenario · ejemplos · bloque didáctico · criterios de calidad · anexo | `IAM-M3` §7; `IAM-M0` |
| Citado APA 7.ª | `IAM-M3` §2 |
| Frontmatter como **interfaz de carga para agentes** (`doc_id`, `doc_type`, `traces`, `audience`) | `IAM-M0` §5 |
| Banco referido como `http://localhost:11434` o `$OLLAMA_HOST`, reemplazable por instalación propia | `IAM-M0` §1 |

### 1.5 Campo `entorno_validado` y deudas

Los temáticos declaran en frontmatter `entorno_validado` (herramienta, versión, contexto, fecha).
El commit 0a42e44 (2026-11-10, «cierre de deudas PD-01 y PD-02») actualizó `IAM-06`, `IAM-09` e
`IAM-M2` a `last_review: 2026-11-10`:

- `IAM-06`: `entorno_validado` pasa a «sí» con entrenamiento **reducido**, fusión, GGUF, creación
  por API en el banco y comparación servida; la corrida completa se cortó por costo medido y rige
  la reducida con apartamiento declarado. `confidence` hoy es **alta** (la ia-db anterior la daba media).
- `IAM-09`: revisión de embeddings fijada (PD-02, según el mensaje del commit).
- Las deudas PD-01/PD-02 estaban asentadas en el folio 021 del expediente (`CHANGELOG.md`).

## 2. Spec-Driven Development (`SDD-Guide/`)

### 2.1 Los tres niveles (`Spec-Driven Development-SDD.md`)

| Nivel | Idea | Cuándo |
|---|---|---|
| 1 · **Spec-First** | La spec guía la implementación y luego se descarta | Sesión única, prototipos, bugs puntuales |
| 2 · **Spec-Anchored** (estándar de equipo) | Spec y código son vivos; **el cambio de spec precede al de código** | Equipo de 2+, compliance, mantenimiento 6+ meses |
| 3 · **Spec-as-Source** (experimental) | La spec es el artefacto; el código se regenera (specs idénticas no dan código idéntico) | CRUD repetitivo, código desechable, con tests robustos |

Recomendación: empezar en Spec-First y migrar a Spec-Anchored con equipo u horizonte largo.
Fuente que cita: Panaversity Agent Factory (`SDD-Guide/References.md`).

### 2.2 Metodología de prompting colaborativo (`Metodologia-Prompting-SDD-Guide.md`)

**Separación de roles** (§2–§3): Claude = arquitecto de prompts y estratega documental (proyecto
persistente con knowledge base; genera prompts, evalúa salidas, orquesta subagentes; **sin**
acceso al filesystem); Copilot = ejecutor en el IDE que sigue la lectura prescrita («no decide qué
es relevante», §3.2); el humano orquesta, copia prompts y aprueba (§3.3). Validada en el Motor DSL
(.NET/MAUI, 12 secciones documentales; cifras de CU/tests declaradas en §1, sin verificar).

```
1 Contextualización → 2 Definición de la idea → 3 Prompt especializado (Claude→Copilot)
   → 4 Ejecución y revisión humana → 5 Prompt de coherencia → 6 Refinamiento ─┐
   ↑──────────────────────────────────────────────────────────────────────────┘
```

| § | Qué responde |
|---|---|
| §4 | Las 6 fases, cada una con prompt típico y tabla de caracterización (dirección, tipo, AG-xx implícita, input, output, restricción). F1: «NO generar artefactos, solo analizar» |
| §5 | 7 patrones: lectura antes de acción · uno a la vez con confirmación · diagnóstico antes de plan · corrección de desvío · decisión de arquitectura embebida · verificación y deploy · coherencia pre-sprint |
| §6 | 13 especialidades AG-ROOT…AG-11, flujo de trazabilidad, mapeo agente → entradas/salidas |
| §7 | Las 12 secciones `00_contexto … 11_examples` de `/docs/` |
| §8 | Ejemplo completo concepto → sprint |
| §9 | Anti-patrones |
| §10 | Adaptación a otro proyecto (no todos necesitan las 12 secciones; coherencia cada 2–3 sprints) |
| §11–§12 | Diagrama del flujo; cadena de trazabilidad |
| §13 | Control de cambios (sólo 1.0) |

**Cadena de trazabilidad** (§12): Visión (`00`) → NB-xx (`01`) → CU-xx → RN-xx (`02`) → ADR
(`05`) → US-xx → BT-xx (`06`) → TK-xx (`07`) → test cases (`08`) → pipeline (`09`).

**Anti-patrones** (§9): mega-prompt inicial · aprobar sin revisar · Copilot sin lectura previa ·
sesiones largas (máx. 2–3 CU) · Claude sin ver la salida de Copilot · mezclar lectura y escritura
en interfaces de proveedor · prompt sin `dotnet build`/`dotnet test` final.

`Secciones-Disciplinas-Especialidades-Tables.md` repite en tablas el contenido de §6–§7 (duplicado
parcial; no se verificó línea por línea).

## 3. Catálogo de especialidades AG-xx (`references/agentes-especialidades/`)

| ID | Perfil | Sección del template | Artefactos |
|---|---|---|---|
| AG-ROOT | Arquitecto de Soluciones Senior | `docs/README.md` | Árbol documental, coherencia cruzada |
| AG-00 | Product Manager | `00_contexto/` | Visión, alcance, roadmap, acuerdo de equipo |
| AG-01 | Analista de Negocio Senior | `01_necesidades_negocio/` | NB-xx, criterios de éxito |
| AG-02 | Analista Funcional | `02_especificacion_funcional/` | CU-xx, RN-xx, DSL, modelo conceptual |
| AG-03 | Especialista DX | `03_ux/` | Experiencia del desarrollador/usuario |
| AG-04 | Ingeniero de Prompts | `04_prompts_ai/` | System prompt, guardrails, few-shot, evaluación |
| AG-05 | Arquitecto de Software Senior | `05_arquitectura_tecnica/` | ADR, contratos, pipeline, C4 |
| AG-06 | Scrum Master | `06_backlog/` | Backlog, US-xx, BT-xx |
| AG-07 | Gestión de Proyectos Ágiles | `07_plan/` | Plan de sprints, TK-xx |
| AG-08 | Ingeniero QA | `08_calidad_y_pruebas/` | Estrategia, DoD, cobertura, quality gates |
| AG-09 | Ingeniero DevOps | `09_devops/` | CI/CD, SemVer, NuGet, rollback |
| AG-10 | Technical Writer | `10_developer_guide/` | Guías de integración, tutoriales, troubleshooting |
| AG-11 | Developer Advocate | `11_examples/` | Apps de referencia ejecutables |

Prefijos de carpeta de AG-03, AG-06 y AG-07 verificados en las fichas (`03_ux`, `06_backlog`,
`07_plan`); el sufijo completo del nombre, sin verificar.

**Estructura fija de cada ficha** (por encabezados): §1 ¿Qué es? · §2 Tareas · §3 Especificaciones
que produce · §4 Criterios de calidad · §5 Preguntas guía (con ejemplo) · §6 Plantilla base ·
§7 Anti-patrones.

**Uso** (`README.md` del catálogo): leer la ficha antes de escribir, usar la plantilla mientras se
escribe, aplicar §4 como checklist al revisar, lanzar los subagentes del prompt maestro al
refinar. Orden recomendado: AG-00 → 01 → 02 → (03 + 04) → 05 → 06 → 07 → 08 → 09 → 10 → 11 → AG-ROOT.

## 4. Prompts de refinamiento (`references/refinamiento_docs/`)

| Archivo | Contenido | Subagentes |
|---|---|---|
| `agentes-refinamiento-docs.md` | §1 caracterización · §2 competencias y criterios por agente · §3 **prompt maestro** · §4 uso (completo y parcial) · §5 control de cambios | AG-ROOT…AG-11 |
| `prompt_refinanmiento.md` | El mismo prompt «listo para ejecutar», con consolidación ampliada | `SA-01…SA-12` |

Reglas comunes: **no modificar archivos** (sólo analizar y reportar); salida en español y
Markdown; cada subagente entrega *Hallazgos* (ID · severidad Alta/Media/Baja · archivo ·
descripción), *Propuestas* y *Evaluación* 1–10. La consolidación agrega dashboard de salud, mapa
de trazabilidad Visión→Pipeline, top 10, plan por impacto/esfuerzo y dependencias entre hallazgos.

Correspondencia en `prompt_refinanmiento.md`: `SA-01`=AG-ROOT, `SA-02`=AG-00, `SA-03`=Analista de
Negocio (AG-01), `SA-05`=DX (AG-03), `SA-07`=Arquitecto (AG-05) … `SA-12` = AG-10 + AG-11 (los
ejemplos no tienen subagente propio).

## 5. Notas sueltas

- `Claude-Guide.md/Fast-Guide.md`: Claude Code «(v2.1.234 o posterior)» puede continuar solo al
  restablecerse el límite: `/config` → *Continue automatically at usage limit*, o
  `/config autoContinueAtUsageLimit=true`. Versión y clave **(sin verificar)** contra documentación oficial.
- `references/notas/tools.md`: `Ctrl+K V` (vista lado a lado) y `Ctrl+Shift+V` (vista previa) en
  VS Code. Sin título ni encabezado; no es material de IA.

## 6. Relaciones con otras guías

| Desde | Hacia | Naturaleza |
|---|---|---|
| `IAM-M0` §4, `IAM-M1` ESC-07 | `Guides/IA/Dot-Net-Integration-AI-Layer-Guide/Dot-Net-Integration-AI-Layer-Guide.md` | Integración en aplicación: se referencia, no se duplica (enlace verificado, existe) |
| 10 piezas de `IA-Model/` (11 menciones) | «guía 16 del repositorio» | Mención por número a la integración .NET, sin enlace |
| Diseño conversacional | `Guides/IA/Dot-Net-Integration-AI-Layer-Guide/Conversational-Design-Framework-Guide.md` y `AI-Layer-Conversational-Design` en la base de conocimientos | `git ls-files \| grep -i convers` no encuentra **ninguna** guía conversacional fuera de esa carpeta: queda en el índice de la capa de IA |
| SDD / AG-xx | `Guides/Metodologia-Agiles/` (Scrum, Jira) y `Guides/UX-UI-Design/` | Mismo proyecto de origen (Motor DSL); las secciones `06_`/`07_` y `03_` del template se trabajan allí |
| `Guides/Despliegue/DevOps-Guide/plan-mejoras-devops_v1.0.md` | `Guides/IA/…` | Única guía de fuera de `Guides/IA/` que menciona estas rutas (grep) |
| `CHANGELOG.md` | `Guides/IA/IA-Model/` | Entradas 2026-11-07 (alta) y 2026-11-10 (PD-01/PD-02) |

## 7. Estado y vigencia

| Pieza | Estado |
|---|---|
| `IA-Model/` (15) | `borrador`, fusionada en `main` (38d41ec + 0a42e44); ya no está pendiente en rama como registraba la ia-db anterior |
| `SDD-Guide/Metodologia-Prompting-SDD-Guide.md` | «Activo» 1.0 (2026-04-06); sin cambios de contenido desde su ingreso |
| Resto del material importado | Sin estado declarado; sin cambios desde la reorganización 82b2fe1 |
| `tabla-caracterizacion-agentes.md` | Duplicado de §1 de `agentes-refinamiento-docs.md` |
| `prompt_refinanmiento.md` | Variante del prompt maestro con otra numeración (SA-xx) |

## 8. Hallazgos

| ID | Hallazgo | Evidencia |
|---|---|---|
| H-10.01 | Directorio con extensión `.md` | `Guides/IA/Claude-Guide.md/Fast-Guide.md` |
| H-10.02 | Nombre con espacio y errata | `SDD-Guide/Spec-Driven Development-SDD.md`; `refinamiento_docs/prompt_refinanmiento.md` |
| H-10.03 | **Enlaces rotos** a la estructura `docs/` del proyecto de origen: 25 destinos inexistentes en 5 fichas | `AG-ROOT-arquitecto-soluciones.md` (`docs/00_contexto/…`, `docs/11_examples/`, `ruta`); `AG-01` (`../../02_especificacion_funcional/casos-de-uso/CU-XX-nombre_v1.0.md`); `AG-07`, `AG-10` (`guia-integracion-maui.md`, `formato-dsl-templates.md`…), `AG-11` (`ejemplo-01-simple.md`…) |
| H-10.04 | Dos numeraciones de subagentes; `SA-03` ≠ `AG-03` | `prompt_refinanmiento.md` §SA-03 (Analista de Negocio), §SA-05 (DX), §SA-07 (Arquitecto) |
| H-10.05 | Enlace roto en el índice del catálogo: apunta a una ruta hermana inexistente | `agentes-especialidades/README.md` → `../agentes-refinamiento-docs.md` (real: `../refinamiento_docs/agentes-refinamiento-docs.md`) |
| H-10.06 | Referencia a la integración por **número** («guía 16») en vez de por ruta | 11 menciones en 10 piezas: `IAM-01` l. 234, `IAM-03` l. 246, `IAM-07` l. 318, `IAM-08` l. 264, `IAM-09` l. 286, `IAM-10` l. 186 y 202, `IAM-11` l. 292, `IAM-M1` l. 65, `IAM-M2` l. 186, `IAM-M3` l. 366 |
| H-10.07 | Referencias a un expediente externo (folios 011, 021) que no está en este repo | `Cohesion-Global.md` (8 menciones a «expediente 0001»), `IA-Model-Guide.md` |
| H-10.08 | Cuatro temáticos superan las 700 líneas de su propio contrato (06: 819, 07: 874, 08: 759, 09: 877) | `IAM-M3` §5; `IAM-06` declara el apartamiento (el resto, sin verificar) |
| H-10.09 | `Convenciones.md` contiene la plantilla del temático **embebida** con sus propios `## Índice`/`## 1. Definición`…, lo que duplica encabezados de nivel 2 en el archivo | `IA-Model/Convenciones.md` l. 328–358 |
| H-10.10 | Nota de VS Code archivada bajo `Guides/IA/` y sin título | `references/notas/tools.md` |
| H-10.11 | `References.md` del SDD: sólo URL sueltas, sin título ni contexto | `SDD-Guide/References.md` |
| H-10.12 | La ia-db anterior citaba un `rules.md` inexistente en el material de refinamiento; hoy `grep rules.md` en el alcance no devuelve resultados | `Guides/IA/references/` |

## Glosario del dominio

| Término | Definición | Fuente |
|---|---|---|
| `IAM-` | Prefijo de doc_id de la guía 18: `M0…M3` marco, `01…11` temas | `IA-Model/*` frontmatter |
| ESC / CTX / ACT | Escenario, contexto de ejecución, actor de la guía 18 | `IAM-M1` §2–§4 |
| Banco | Servidor Ollama en red usado por los labs (CTX-03) | `IAM-M0` §1 |
| Paso 0 | Verificación del banco antes de los labs | `IAM-08` |
| Autocontenido / no-delta | Se lee sin abrir otro / sin versión previa | `IAM-M2` §3 |
| Protocolo | Bloque que acompaña toda cifra medida | `IAM-M3` §4 |
| `entorno_validado` | Campo YAML con la corrida que valida el tema | frontmatter temáticos |
| PD-01 / PD-02 | Deudas declaradas de la guía 18, cerradas el 2026-11-10 | `CHANGELOG.md` |
| SDD | Spec-Driven Development (3 niveles) | `SDD-Guide/Spec-Driven Development-SDD.md` |
| AG-xx | Especialidad documental del proyecto de origen | `references/agentes-especialidades/` |
| SA-xx | Subagente del prompt de refinamiento | `prompt_refinanmiento.md` |

## Fuentes

- `Guides/IA/IA-Model/` (las 15 piezas: frontmatter, índices; `IA-Model-Guide.md` §1–§5,
  `Cohesion-Global.md` §2, `Marco-De-Referencia.md` §2–§4, `Convenciones.md` §5, envoltura de
  `06-Ajuste-Fino-Y-Alineacion.md`)
- `Guides/IA/SDD-Guide/` (4 archivos), `Guides/IA/references/` (19 archivos),
  `Guides/IA/Claude-Guide.md/Fast-Guide.md`
- `CHANGELOG.md` (entradas 2026-11-07 y 2026-11-10); commits 38d41ec, 0a42e44, 82b2fe1
- Comprobación de enlaces relativos por script sobre el alcance; `wc -l` para conteos
- Referencia de estilo: ia-db v1.x, índice 09 (2026-10-29)

**Vigencia**: 2026-11-16 · fuente `Lab-Documentos` `main` 34929f2.
