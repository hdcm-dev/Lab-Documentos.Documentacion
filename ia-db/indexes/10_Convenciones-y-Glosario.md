# 10 · Convenciones transversales y glosario cruzado

> **Propósito**: lo que hay que saber antes de leer **cualquier** guía del corpus: cómo se identifica
> un documento (frontmatter, `doc_id`), cómo se marca la procedencia de una afirmación (niveles de
> autoridad, marcas de evidencia), por qué **el mismo prefijo significa cosas distintas en cada
> guía**, y un glosario de los términos que cruzan guías, con la fuente de cada definición. Lo
> propio de un solo dominio queda en su índice (01–09); acá sólo va lo que se repite o choca.
> **Fuentes primarias**: los cuatro `00-Marco-de-Referencia/Convenciones.md` (`MARCO-CONVENCIONES`)
> de `Guides/Documentacion-Tecnica/Creacion-Guias-Tecnicas/`, `Guides/Despliegue/Documentacion-Informe-Despliegue/`,
> `Guides/Arquitectura/Organizacion-Estilo-Patrones-Codigo/` y `Guides/Arquitectura/Organizacion-Estilo-Rest-API/`;
> la «Convención de marcas» de `Estandares-Modelo-Ramas.md`, `GitHub-Action-Guide.md` y `Beginner-Guide.md`;
> `Dot-NET-Arquitectura-Guide.md` §0.5; `Metodologia-Entorno-Desarrollo-Guide.md` §0.3 y §2; los glosarios
> listados al final. Frontmatter relevado con `awk` sobre los 295 `.md` versionados (`main` 5d5c2b4, 2026-10-18) y
> re-contado en la v4.1 sobre `fe10086` (2026-10-27): §1.2, §1.3 y §2.1. El contrato del cuerpo `SDEI` está en
> `Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/99-Anexos/Esquema-Frontmatter-Y-Prefijos.md`.

Rutas relativas a `Lab-Documentos/`. Abreviaturas de guía usadas en las tablas:

| Sigla | Guía | Índice |
|---|---|---|
| **DT** | `Guides/Documentacion-Tecnica/Creacion-Guias-Tecnicas/` (`GUIA-INDICE`) | [01](01_Documentacion-Tecnica.md) |
| **SDT** | `Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/Sistema-Documentador-Tecnico-Guide.md` (`DOC-SDT-0001`, obsoleto) | [01](01_Documentacion-Tecnica.md) |
| **SDEI** | Cuerpo `SDEI` en la misma carpeta (`IDX-SDEI`, `corpus_id: SDEI`), con `AGENTS.md` y `tools/docs-guard/` | [11](11_Sistema-Documentador-SDEI.md) |
| **FC** | `Concepts/Framework-Concept/` (`FC-GUIA-INDICE` en `Developer-Guide.md`, prefijo `FC-` desde `0989a15`) | [12](12_Framework-Concept.md) |
| **IS** | `Guides/Despliegue/Documentacion-Informe-Despliegue/` (informe de solución) | [02](02_Informe-de-Solucion.md) |
| **OEP** | `Guides/Arquitectura/Organizacion-Estilo-Patrones-Codigo/` | [03](03_Organizacion-Codigo-NET.md) |
| **REST** | `Guides/Arquitectura/Organizacion-Estilo-Rest-API/` | [04](04_Diseno-REST-API.md) |
| **NET** | `Guides/Dot-NET-Arquitectura-Guide/Dot-NET-Arquitectura-Guide.md` (`GUIA-NET-ARQ`) y su interactiva (`GUIA-NET-ARQ-INT`) | [05](05_Arquitectura-NET-y-Laboratorio.md) |
| **ENT** | `Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (`GUIA-ENT-DEV`) | [06](06_Metodologia-Entorno-Desarrollo.md) |
| **E2E** / **TG** | `Guides/Testing/Lab-E2E.WebBlazor-Guides/E2E-Guide/` (`E2E-00`…) / `…/Test-Guide/` | [07](07_Testing-E2E.md) |
| **GF** / **GHA** | `Guides/GitFlow/Estandares-Modelo-Ramas-Guide/Estandares-Modelo-Ramas.md` (`GF-GUIA`) / `Guides/Despliegue/GitHub-Action-Guide/GitHub-Action-Guide.md` (`GHA-00`) | [08](08_Ramas-CI-CD-y-DevOps.md) |
| **IMP** | Material importado: `Guides/Despliegue/DevOps-Guide/`, `Guides/IA/`, `Guides/Metodologia-Agiles/`, `Guides/UX-UI-Design/` | [08](08_Ramas-CI-CD-y-DevOps.md), [09](09_IA-Agiles-UX-y-Otros.md) |
| **SEG** | `Guides/Otros/Seguridad-Red-Windows-Guide/` | [09](09_IA-Agiles-UX-y-Otros.md) |

---

## 1. Frontmatter

### 1.1 El bloque normado (DT, IS, OEP, REST)

Las cuatro guías estructuradas definen el mismo bloque en su `Convenciones.md` §Frontmatter obligatorio
(difieren sólo en el ejemplo de `doc_id` y en el párrafo final; comparado con `diff`):

```yaml
---
doc_id: DOC-SAD            # DT usa un ID real de ejemplo; IS/OEP/REST: TEM-XXX (marcador)
doc_type: tema | marco-de-referencia | familia | mapa | anexo | indice
title: <título>
status: vigente | borrador | obsoleto
origin: human | ia-assisted | ia-generated
confidence: alta | media | baja      # obligatorio si origin != human
owner: <actor responsable>
last_review: AAAA-MM-DD
audience: [humano, agente]
traces: [IDs de documentos relacionados]
---
```

«`origin` y `confidence` no son decorativos: son el mecanismo por el cual un lector distingue lo
verificado de lo inferido» (DT `Convenciones.md` §Frontmatter obligatorio). Los campos no aplicables
se omiten, no se dejan vacíos. El bloque **no prevé `version`**: ninguna de esas cuatro guías tiene
número de versión; la vigencia se lee en `last_review`.

### 1.2 Lo que hay en la práctica (relevado sobre el repo)

En `5d5c2b4`, 207 de los 295 `.md` versionados abrían con frontmatter; en `fe10086`, **262 de 342** (sin contar
los fixtures de `tools/docs-guard/`). Valores encontrados (frecuencias de `fe10086`):

| Campo | Valores y frecuencia | Dónde |
|---|---|---|
| `origin` | `ia-assisted` ×206 · `ia-generated` ×22 · `agente` ×19 · `ai-assisted` ×3 | `ia-assisted`: DT, IS, OEP, REST, SEG, SDEI · `ia-generated`: SDT, FC, la mini demo y `Ejercicios` de SDEI, `README.md` y `Guides/README.md` · `agente`: GF, GHA, prácticas, E2E · `ai-assisted`: NET, NET-INT, ENT (el `agent` de SDT desapareció en `fe10086`) |
| `status` | `vigente` ×207 · `borrador` ×41 · `en construcción` ×1 · `obsoleto` ×1 | `borrador`: SDEI, FC, `AGENTS.md` · `obsoleto`: SDT · `en construcción`: `GUIA-NET-ARQ-INT` |
| `doc_type` | normado (`tema`, `familia`…) en DT/IS/OEP/REST; `documento-tematico`, `guia-de-estudio`, `guia-practica`, `guia-rapida`, `anexo` en GF/GHA/E2E; `study-guide`, `study-guide-activity` en NET/ENT; `study-note` en SDT; vocabulario cerrado de 14 tipos en SDEI (`tema`, `anexo`, `rrd`, `ficha`, `proceso`…); `marco-de-referencia`/`tema`/`anexo`/`portada`/`indice` en FC; `guia-estudio` en SEG; `analisis` en OEP `61-Analisis-Integral` | frontmatter de cada archivo |
| `owner` | título de la guía (DT/IS/OEP/REST/SEG) · `Lab-GitFlow` (GF, GHA) · `Lab-E2E.WebBlazor.Documentacion` (E2E) · cuenta personal del autor (NET, ENT, SDT) · rol o nombre del cuerpo (SDEI: «Lab-Documentos — guía del sistema documentador», `ACT-09 Technical Writer`; FC: `Lab-Documentos`) | ídem |
| `audience` | `[humano, agente]` (normado) · por rol `[desarrollo, qa, devops, po, …]` (GF/GHA/E2E) · prosa libre (NET, ENT) · lista cerrada de diez valores en SDEI (`humano`, `agente`, `desarrollo`, `persona-usuaria`…) | ídem |
| Campos extra | `version` (NET 2.5.0, NET-INT 0.4.0, ENT 1.1.0) · `consolida:` (GF) · `prerequisites`, `sdk_validado`/`entorno_validado`, `related`, `fuentes_consultadas`, `laboratorio`, `fuente_actividad` (NET/ENT) | ídem |

Sin frontmatter: todo el material importado (IMP), `Microservicios-Guide.md` y `Manejo-Archivos-Guide.md`
de NET, 11 documentos de `Lab-E2E.WebBlazor-Guides/` (casos, Test-Guide, `Nomenclatura-…`) y los
README de ejemplos/laboratorios. El material importado usa en su lugar un encabezado
«Documento / Versión / Fecha / Estado» más una tabla «Control de cambios» ([09](09_IA-Agiles-UX-y-Otros.md)).

> Consecuencia práctica: **no hay un esquema único**. Para filtrar por vigencia hay que mirar
> `status` + `last_review` en las guías con frontmatter, `version` en NET/ENT y el encabezado en IMP.
> Sólo `CHANGELOG.md` registra versiones (de NET y SDT) — ver [00](00_MASTER-INDEX.md#3-procedencia).

### 1.3 El contrato del cuerpo `SDEI` (desde `fe10086`)

El único bloque de frontmatter **verificado por máquina**: diez campos (`doc_id`, `doc_type`, `title`, `status`,
`origin`, `confidence` si `origin` no es `human`, `owner`, `last_review`, `audience`, `traces`) más `description` de
10 a 160 caracteres, con vocabulario cerrado; `corpus_id` y `version` sólo en el README del cuerpo; las páginas de
ayuda (`roles`, `translation_of`) con esquema propio. Lo hace cumplir `docs-guard` (`PR-2`) con
`tools/docs-guard/esquemas/*.schema.json` y el registro cerrado `tools/docs-guard/prefijos.txt` (prefijo, ámbito
`interno`/`externo`, descripción). Fuera de una carpeta con `corpus_id`, las faltas sólo avisan
([11](11_Sistema-Documentador-SDEI.md) §4).

---

## 2. Identificadores de documento (`doc_id`)

Regla compartida por DT/IS/OEP/REST: «los enlaces apuntan al identificador, no a la ruta: los archivos
se mueven, los IDs no» (DT `Convenciones.md` §Identificadores). Prefijos de `doc_id` por guía:

| Prefijo | Significa | Guías que lo usan |
|---|---|---|
| `GUIA-INDICE` | README raíz de la guía | DT, IS, OEP (REST tiene el README vacío) |
| `MARCO-ESCENARIOS/CONTEXTOS/ACTORES/CONVENCIONES` | Marco de referencia | DT, IS, OEP, REST |
| `MAPA-CONCEPTUAL` | Mapa «estoy acá → qué leo» | DT, IS, OEP (REST lo cita 8 veces y no existe) |
| `FAM-` | README de familia | DT (`FAM-VIS`…`FAM-USR`), IS (`FAM-NAT`, `FAM-ARQ`, `FAM-DESP`, `FAM-REQ`, `FAM-RED`), OEP (`FAM-SRV`…`FAM-PAT`), REST (`FAM-FUN`…`FAM-TRA`) |
| `DOC-` | Documento por tipo documental | DT (`DOC-SAD`, `DOC-ADR`, `DOC-SDD`…); SDT con esquema propio `DOC-SDT-0001` |
| `TEM-` | Documento temático | IS, OEP, REST · SDEI con sufijo de cuerpo (`TEM-SDEI-01`…`07`) · FC sin sufijo (`TEM-01`…`TEM-08`) |
| `IDX-`, `ANX-`, `GP-`, `DEMO-` | Índice, anexo, guía práctica o proceso, pieza de ejemplo | SDEI (`IDX-SDEI`, `ANX-SDEI-*`, `GP-SDEI-*`, `DEMO-MU-*`); raíz (`IDX-LABDOC-AGENTS`) |
| `MET-` / `ARQ-` | Método ágil / modelo de arquitectura | DT (`80-…`, `90-…`) |
| `ANEXO-` | Anexos (`GLOSARIO`, `CHECK`, `REFERENCIAS`, `PLANTILLA(S)`, `PENDIENTES`, `REVISION`) | DT, IS, OEP, REST |
| `GF-`, `GHF-`, `GHA-`, `E2E-` | Documentos del bloque ramas / Actions / E2E | GF (`GF-GUIA`, `GF-AX-WF`, `GF-09`…), prácticas (`GHF-IDX`, `GHF-GUIA`), GHA (`GHA-00`), E2E (`E2E-00`…`E2E-04`) |
| `GUIA-NET-ARQ`, `GUIA-NET-ARQ-INT`, `GUIA-ENT-DEV` | Guías únicas versionadas | NET, ENT |
| `GUIA-PRINCIPAL`, `CUADERNO` | Guía y cuaderno de seguridad (sin prefijo de dominio) | SEG |

### 2.1 Los `doc_id` sólo son únicos dentro de cada guía

Relevado con `awk` sobre el primer bloque de frontmatter de cada `.md` (2026-10-18). `doc_id` repetidos:

| `doc_id` | Veces | Causa |
|---|---:|---|
| `MARCO-ESCENARIOS`, `MARCO-CONTEXTOS`, `MARCO-ACTORES`, `MARCO-CONVENCIONES` | 4 c/u | Aparato común de DT, IS, OEP, REST — **a propósito**; se desambigua por ruta |
| `GUIA-INDICE` | 3 | Ídem (DT, IS, OEP). El Framework Concept lo usó entre `fe10086` y `0989a15`; hoy es `FC-GUIA-INDICE` |
| `MAPA-CONCEPTUAL`, `ANEXO-GLOSARIO`, `ANEXO-REFERENCIAS` | 3 c/u | Ídem (DT, IS, OEP; `ANEXO-REFERENCIAS` también en REST) |
| `ANEXO-CHECK`, `ANEXO-PENDIENTES` | 2 c/u | Ídem |
| `FAM-ARQ` | 2 | Familia «Arquitectura» de DT (`30-Arquitectura/`) y de IS (`20-Arquitectura/`) |
| `GF-GUIA`, `GHA-00`, `GF-09-ESCENARIOS`, `GHF-GUIA`, `GF-AX-WF` | 2 c/u | **Copias aplanadas** en `Guides/Testing/Lab-E2E.WebBlazor-Guides/` de los originales de `Guides/GitFlow/` y `Guides/Despliegue/` ([08](08_Ramas-CI-CD-y-DevOps.md) H-03) |
| `E2E-00`, `E2E-01` | 2 c/u | Copia vieja `Guides/Testing/E2E-Guide/` y vigente `Lab-E2E.WebBlazor-Guides/E2E-Guide/` con contenido divergente ([07](07_Testing-E2E.md) H-01) |

Además, tres plantillas de DT (`40-Diseno/API-Specification.md`, `Integration-Guide.md`,
`Modelo-de-Datos.md`) y el ejemplo de `Convenciones.md` escriben **dentro de bloques de código** el
mismo `doc_id` que el documento que las contiene; un `grep '^doc_id:'` ingenuo los cuenta como
duplicados ([01](01_Documentacion-Tecnica.md)).

**Regla para un agente**: citar siempre `doc_id` **más ruta** (o sigla de guía). `TEM-ARQ` o
`MARCO-ACTORES` sin ruta son ambiguos.

---

## 3. Cómo se marca la procedencia de una afirmación

El corpus tiene un rasgo central: **separar lo normado de lo convenido y de la opinión propia**. Lo
resuelve con dos familias de mecanismos que no se mezclan dentro de una misma guía.

### 3.1 Niveles de autoridad + catálogo de fuentes (IS, OEP, REST; DT en menor medida)

| Nivel | IS (4 niveles) | OEP (3 niveles) | REST (4 niveles) | Prefijo de fuente |
|---|---|---|---|---|
| Normativo | ISO/IEC/IEEE, RFC, OMG, Microsoft | **sólo Microsoft** (Learn, SDK) | RFC, OpenAPI, Microsoft Learn | `N-xx` |
| Marco / guía de organización | arc42, C4, TOGAF, SAD de RUP | — (no existe) | Microsoft (Azure/Graph), Google AIP, Zalando… | `G-xx` (IS, REST) |
| Convención de facto | Práctica dominante + evidencia | Práctica del ecosistema | Práctica dominante + evidencia `P-xx` | `F-xx` |
| Criterio propio | «esta guía recomienda» | «esta guía recomienda» | «esta guía recomienda» | — |
| (Fuente, no nivel) | Obras `O-xx`, evidencia de plataforma `P-xx` | Obras `O-xx` | Obras `O-xx`, plataformas `P-xx` | `O-xx`, `P-xx` |

Fuentes: IS `Convenciones.md` §Los cuatro niveles de autoridad y `99-Anexos/Referencias.md` §Los cinco
niveles; OEP `Convenciones.md` §Los tres niveles de autoridad y `99-Anexos/Referencias.md` §5; REST
`Convenciones.md` §Los cuatro niveles y `99-Anexos/Referencias.md` §Los cinco niveles de identificador.

- Los catálogos `N-/G-/F-/O-/P-` **se numeran por guía**: `N-01` de IS es ISO/IEC/IEEE 42010:2022;
  `N-01` de REST es RFC 9110; `N-01` de OEP es *Framework Design Guidelines — Naming Guidelines* (Microsoft Learn, 2008) (cada `99-Anexos/Referencias.md`). Citar «`N-01`» sin guía no identifica nada.
- REST `Convenciones.md` §Identificadores enumera `N/F/O/P` y omite `G-xx`, que su anexo sí define ([04](04_Diseno-REST-API.md)).
- DT no numera fuentes por nivel: declara prefijos de industria dentro de ejemplos (`RF-`, `RNF-`,
  `RN-`, `CU-`, `ADR-`, `TC-`, `RSK-`) y remite a la trazabilidad (`Convenciones.md` §Trazabilidad y fuentes).

### 3.2 Marcas en línea (GF, GHA, E2E, NET, ENT)

| Marca | GF | GHA | E2E (`Beginner-Guide`) | NET (§0.5) | ENT (§0.3) |
|---|---|---|---|---|---|
| Fuente externa | **[F]** → Anexo E | **[F: ID]** → Anexo E | **[F: id]** → Anexo E | enlace `#ref-…` al Anexo E | **[Bnn]** → Anexo D (B01–B223) |
| Convención / criterio propio | **[C]** convención del equipo | **[C]** | **[C]** criterio | «Criterio de esta guía» | **[criterio]** |
| Comprobado en el workspace | — (no usa) | **[E: ID]** (Anexo F, leído 2026-08-31) · **[E: OBS-n]** hecho negativo | **[E: ruta]** archivo del laboratorio | `[Compilado: …]` / `[Compilado sin captura: …]` + captura `Lnn-…txt` | `E<n>-<m>` experimento (Anexo E) · **[observado]** |
| Ejecutado | — | — | **[V]** verificado por ejecución (registro en §9) | capturas del laboratorio | experimentos con salida versionada |
| No verificado / ilustrativo | — | — | — | `[Fragmento ilustrativo: motivo]` | **[no verificado]** · **[interpretación]** (Anexo F) |

Otras marcas propias: Test-Guide **[B: n]** (bibliografía consultada el 2026-09-12; no es la `[Bnn]` de ENT);
NET-INT «⏳ Pendiente de mesa», «⚠ Hallazgo contra la guía», «Verificado en máquina», `[Leído]`, `[Fuente: enunciado §X]`;
taller «La Estancia» `⟨M⟩` (texto de la mesa; lo demás es del usuario y no se reescribe). Detalle en [05](05_Arquitectura-NET-y-Laboratorio.md), [06](06_Metodologia-Entorno-Desarrollo.md), [07](07_Testing-E2E.md).

Principio común, con la misma frase en GF y E2E: «un documento de proceso pierde autoridad cuando
presenta preferencias del autor como si fueran estándares de la industria» (`Estandares-Modelo-Ramas.md`
§Convención de marcas; `Beginner-Guide.md` §Cómo leer las marcas de evidencia).

### 3.3 Material sin mecanismo de procedencia

IMP (DevOps, SDD, `references/`, Scrum/Jira, UX) **no** marca niveles ni evidencia: mezcla norma,
práctica y prescripción del proyecto de origen (Motor DSL) sin distinguirlas. Leerlo como material de
referencia, nunca como norma del corpus ([09](09_IA-Agiles-UX-y-Otros.md) §Advertencias de lectura).

---

## 4. Estructura de documento

| Guía | Estructura fija | Fuente |
|---|---|---|
| DT, IS, OEP, REST | Documento temático en 7 secciones: Resumen ejecutivo · Definición · Aplicación por escenario · Ejemplos · Preguntas guía · Criterios de calidad · Anexo (plantilla comentada). Variantes admitidas: catálogo (OEP `TEM-ANTI`, REST `TEM-STATUS`), redacción (IS) | cada `Convenciones.md` §Estructura de un documento temático |
| ENT | Capítulos §4–§11 con `n.1`…`n.9`: Definición, Cómo funciona, Industria, Aplicación, Ejemplos, Preguntas guía, Criterios de calidad, Plantilla, Práctica | ENT §0.2 |
| NET | **Respuesta:** en negrita al inicio de cada pregunta | NET §0.3 |
| Prácticas GF/GHF | Objetivo · Precondición · Pasos · Qué observar · Errores frecuentes · Verificación | `Git-Flow-Guides/*/README.md` |
| Corpus `Lab-E2E.WebBlazor-Guides/` | Encabezado «De qué va / Para quién / Qué deja» | todos sus `.md` |

La regla de 7 secciones se cumple **con desvíos**: DT intercala secciones y numera 1–11 en algunos
documentos; REST numera sólo en 6 de 40 temas ([01](01_Documentacion-Tecnica.md), [04](04_Diseno-REST-API.md)).
Las cuatro guías atribuyen la estructura al Profile `Study-Guide-Documentation`, que **no está en el
repo**: vive en `IA/PROMPTs/IA.Prompts/PromptFramework/Profiles/Study-Guide-Documentation.md` del workspace.

---

## 5. Prefijos de marco: el mismo prefijo, otro significado

**Antes de citar `ESC-2`, `CTX-1`, `ACT-03` o `E-01` hay que decir de qué guía.** Ninguna guía trae
tabla de correspondencia con las otras, salvo IS y REST, que mapean sus ejes a los genéricos de DT
(`Escenarios.md` / `Contextos.md` §Correspondencia…).

| Guía | Escenarios | Contextos | Actores | Fuente |
|---|---|---|---|---|
| DT | `ESC-1` desarrollo nuevo · `2` migración · `3` evaluación con código · `4` evaluación desde afuera | `CTX-1` web/cliente interactivo · `2` backend/servicios · `3` fullstack | `ACT-01..10` (PO, analista, arquitecto, desarrollador, QA, DevOps/SRE, seguridad, UX/UI, technical writer, **agente de IA**) | `DT/00-Marco-de-Referencia/*.md` |
| IS | `ESC-1` en diseño · `2` construida · `3` evolución/migración · `4` solución ajena | `CTX-1` monolito · `2` cliente-servidor · `3` distribuido en el borde · `4` multiservicio en infra controlada | `ACT-01..08` (arquitecto, desarrollador/líder, solicitante técnico, despliegue y operación, analista/PO, patrocinador/decisor, redactor, auditor) | `IS/00-Marco-de-Referencia/*.md` |
| OEP | `ESC-1` nuevo · `2` evolución · `3` normalización · `4` evaluación | `CTX-1` web/cliente · `2` servicio/API · `3` biblioteca · `4` distribuida | `ACT-01..06` (arquitecto, desarrollador, responsable técnico, revisor, DevOps, mantenedor de biblioteca) | `OEP/00-Marco-de-Referencia/*.md` |
| REST | `ESC-1` API nueva · `2` exposición/migración · `3` evolución en producción · `4` API ajena (`4a` con código, `4b` sólo desde afuera) | `CTX-1` pública · `2` interna entre servicios · `3` backend de app propia · `4` integración externa | `ACT-01..07` (arquitecto de API, productor, consumidor, QA, analista, PO de API, seguridad y operaciones **con veto**) | `REST/00-Marco-de-Referencia/*.md` |
| E2E | `ESC-01..05` (pantalla nueva, PR, intermitente, despliegue, regresión de fondo) | `CTX-01..04` (máquina de desarrollo, runner de CI, entorno desplegado, emulación móvil) | `ACT-01..04` (desarrollo, QA, DevOps, PO/autoridad de cambio) | `Beginner-Guide.md` §2 |
| TG | `S1..S6` (regla, caso de uso, contrato, superficie, persistencia, regresión visual) | `C-Web`, `C-API`, `C-Móvil`, `C-Escritorio`, `C-CI` | — | `Panorama-De-Pruebas-Automatizadas.md` §2 |
| ENT | `ESC-01..05` (Windows+VS, Linux, WSL 2, devcontainer, CI) | `CTX-NET`, `CTX-NODE`, `CTX-PY`, `CTX-POLI` | `ACT-DEV`, `ACT-ARQ`, `ACT-OPS`, `ACT-REV` | ENT §2 |
| GF | `E-01..08` (funcionalidad, defecto pre-release, corte, estabilización, emergencia, demo, mantenimiento, rechazo) | `C-1..4` (sin/con release abierta, producción comprometida, ≥3 versiones vivas) | `A-PO`, `A-DEV`, `A-REV`, `A-QA`, `A-OPS`, `A-SEC`, `A-AUT` | `Estandares-Modelo-Ramas.md` §1 |
| GHA | `E-01..10` (PR, rama principal, puertas, NuGet, FTP, contenedor, móvil, release, entorno, programada) | `C-1..5` (runner alojado/propio, repo público/privado, plataforma ≠ runner) | `A-DEV`, `A-QA`, `A-DEVOPS`, `A-PO`, `A-SEC` | `GitHub-Action-Guide.md` §3 |
| NET | `E-A..E-E` (Blazor CRUD, API con clientes .NET, base heredada, reglas ricas, app local) | — | — | NET §0.4, §9.1 |

### 5.1 Otras colisiones de identificadores

| ID | Significados que conviven | Dónde |
|---|---|---|
| `ESC-01` | Pantalla nueva (E2E) · Windows + Visual Studio (ENT) | E2E §2; ENT §2 |
| `E-01…` | Escenario de ramas (GF) · escenario de automatización (GHA) | GF §1; GHA §3 |
| `F-xx` | Fuente de facto (IS/OEP/REST) · hallazgo de la interactiva `F-A…F-J` (NET-INT §5) | — |
| `P-xx` | Evidencia de plataforma (IS/REST) · `traces: P-01…P-10` en ENT | frontmatter de ENT |
| `B..` | `[Bnn]` fuente de ENT · `[B: n]` bibliografía de TG | ENT §0.3; `Test-Guide/README.md` |
| `A…` | Actor `A-xx` (GF/GHA) · hito `A0–A9` del taller (NET-INT §4.2) · «Anexo A» de varias guías | — |
| `DORA-1` | Trunk-based development (GF Anexo E) · Continuous integration (GHA Anexo E) | [08](08_Ramas-CI-CD-y-DevOps.md) H-20 |
| `SA-03`, `SA-05` | Subagentes del prompt de refinamiento · secciones de `metodologia-uix-ux.md` | [09](09_IA-Agiles-UX-y-Otros.md) |
| `ESC-TESTIGO`, `ESC-CORPUS` | `traces` de SEG que sólo existen en `Lab-Documentos.Documentacion/PROMPTs/Guides/07-…/OUTPUTs/` | [09](09_IA-Agiles-UX-y-Otros.md) |

### 5.2 Series de pasos y experimentos

| Serie | Qué numera | Guía |
|---|---|---|
| `L00–L24` / `V01–V09` | Pasos del laboratorio (`lab.sh`) / corridas de variantes (`variantes.sh`) | NET Anexo A |
| `A0–A9` / `F-A…F-J` | Hitos de la Actividad 4 / hallazgos contra la guía | NET-INT §4.2, §5 |
| `E0-1…E8-6`, `EA-1` | 74 experimentos del laboratorio (N0–N8, A-plantillas) | ENT Anexo E |
| `T1–T5` | Topologías de solución | OEP `TEM-TOPO` |
| `G1–G8` | Criterios generales de la lista de verificación del informe | IS `ANEXO-CHECK` |
| `HUE-` / `VER-` / `CNV-` | Huecos, verificaciones y convenciones pendientes | DT `99-Anexos/Pendientes.md` |
| `AG-ROOT`, `AG-00…AG-11` / `SA-01…SA-12` | Especialidades SDD / subagentes de refinamiento (SA-n = AG-(n-2)) | IMP `Guides/IA/references/` |
| `NB-`, `CU-`, `RN-`, `US-`, `BT-`, `TK-`, `FU-`, `WF-`, `D1–D7` | IDs del proyecto de origen (Motor DSL) dentro de ejemplos | IMP |
| `I1/I2/I3` | Integrantes del equipo de práctica | prácticas GF/GHF |

---

## 6. Otras convenciones compartidas

| Convención | Qué fija | Fuente |
|---|---|---|
| Dominio de ejemplo **reserva de salas** | Salas, reservas, usuarios, sedes; compartido por DT, OEP y REST | REST `Convenciones.md` §Vocabulario y ejemplos |
| Dominio **sistema de audiencias** en el borde | Ejemplo único de IS (CTX-3, .NET 10) | IS `00-Marco-de-Referencia/Contextos.md` |
| Otros dominios de ejemplo | Productos/pedidos (NET), La Estancia «La Ana» (NET-INT), turnos (OEP `61`), `MovilidadUrbana` (E2E/TG), SRV-MADERA01 (SEG) | índices 03, 05, 07, 09 |
| Idioma por planos | Estructura/patrón en inglés como sufijo, dominio en español como raíz (`CrearProductoCommand`, `IProductoRepository`) | NET §8.4; OEP `Modelos-y-Contratos.md` §Nomenclatura; `Lab-E2E.WebBlazor-Guides/Nomenclatura-Convensiones-Arquitecture-Dot-Net.md` §1 |
| `data-testid` en español | Contrato interfaz ↔ prueba; no se traduce | `Nomenclatura-…md` §3; `Beginner-Guide.md` §5.3 |
| Regla «no duplicar» | Cada tema vive en un documento; los demás lo referencian | cada `Convenciones.md` §No duplicar |
| Diagramas en Mermaid | 279 bloques en 160 archivos del repo | `grep` sobre `.md` versionados |
| SemVer de tags `vX.Y.Z`, `-rcN`, `-demo.N` [C] | Versionado del modelo de ramas adoptado | GF §7.3 |

---

## 7. Glosario cruzado

Términos que aparecen en más de una guía o que cambian de sentido entre guías. Para el resto, ver el
glosario propio de cada guía (lista en §7.3).

### 7.1 Términos compartidos

| Término | Definición | Fuente |
|---|---|---|
| Escenario | Situación de partida con disparador reconocible; en DT «determina si la documentación decide, describe o infiere». El conjunto concreto cambia por guía (§5) | DT `99-Anexos/Glosario.md`; GF Anexo A |
| Contexto | En DT, tipo de software (web, backend, fullstack); en IS, forma de despliegue; en REST, distancia al consumidor; en ENT, ecosistema tecnológico | §5 de este índice |
| Actor | «Rol con autoridad y alcance definidos sobre ciertos documentos» (DT); en todas las guías con marco se define por lo que decide, no por el cargo | DT `Glosario.md`; `Actores.md` de cada guía |
| Familia | Agrupación de artefactos que responden a la misma pregunta | DT `Glosario.md`; IS/OEP/REST README de familia |
| Artefacto (documental) | Documento concreto y nombrado, con propósito, dueño y audiencia propios | DT `Glosario.md` |
| Artefacto (de build) | Resultado compilado y versionado que se promueve entre ambientes sin recompilar | GF §7.1, §7.5; ENT (procedencia, §9) |
| Doble audiencia | Documento que sirve a la vez a una persona que comprende y a un agente que extrae datos (`audience: [humano, agente]`) | DT `Glosario.md` |
| ADR / RFC | Registro de una decisión con alternativas y justificación / propuesta abierta a comentarios antes de implementar | DT `Glosario.md`; IS `TEM-DECISIONES` (ADR embebido); ENT A.16 (ADR de entorno) |
| Spec-Driven Development (SDD) | La especificación es el artefacto primario y versionado del que se deriva el código. Tres tratamientos: DT `DOC-SDD` (aptitud de una spec para un agente), REST `TEM-SDD` (OpenAPI como spec), IMP `SDD-Guide` (niveles Spec-First / Spec-Anchored / Spec-as-Source) — sin enlaces entre sí | DT `95-Transversales/Spec-Driven-Development.md`; REST `95-Transversales/Spec-Driven-Development.md`; `Guides/IA/SDD-Guide/Spec-Driven Development-SDD.md` |
| UX / DX | DX = UX cuyo usuario es un desarrollador e interfaz son código, contratos, errores y documentación. Tratada en DT `DOC-UX`, REST `TEM-DX` e IMP `UX-UI-Guide.md` §10 | `UX-UI-Guide.md` §1.2, §10.1; REST `Experiencia-del-Consumidor.md` |
| Capa (*layer*) / *tier* | Capa = agrupación lógica del código por responsabilidad; tier = unidad de despliegue físico. El español traduce ambos como «capa» | OEP `99-Anexos/Glosario.md` |
| Monolito / monolito modular / monolito distribuido | Una unidad desplegable (no implica desorden) / con módulos de límites que algo hace cumplir / varias unidades que no pueden desplegarse ni fallar por separado (sin fuente normativa) | OEP `Glosario.md`; `10-Arquitectura-de-Servicios/*.md` |
| Contrato / `Contracts` | Forma de los datos que cruzan un borde (DTO). En NET es además el **proyecto** `Contracts`, que nace con el primer cliente .NET (L22) | OEP `Glosario.md`; NET Anexo D, §6.3, §8.5 |
| DTO | Tipo plano sin comportamiento que transporta datos «a través de una frontera» (OEP) / «entre procesos» (NET; dentro del proceso NET habla de mensaje) | OEP `Glosario.md`; NET Anexo D |
| Composition root | Único lugar que registra qué implementación corresponde a cada interfaz (`Program.cs`) | NET Anexo D, §2.5 |
| CQRS | NET: separar modelo de escritura y lectura, «no es lo que hace este ejemplo». OEP: «CQRS sin ceremonia» = repositorios para escribir, `DbContext` proyectado a DTO para leer | NET Anexo D §4.8; OEP `Patrones-de-Acceso-a-Datos.md` §CQRS |
| Puerta (*gate*) / compuerta única | Condición que un cambio debe cumplir para avanzar en el pipeline (GHA) / un solo programa por repo con tres pasos que se invoca igual desde hook, CI y publicación (ENT) | GHA §1.4; ENT §10.2.2 |
| CI aprobada | Job resumen y único check obligatorio de la protección de rama | GF §8.5; `Anexos/workflows/ci.yml` |
| Promoción | Mover el mismo artefacto, construido una vez, entre ambientes sin recompilar | GF §6.2 regla 6, §7.5 |
| Nivel 2 de Richardson | Recursos con URI propia y verbos HTTP según su semántica, sin hipermedia | REST `10-Fundamentos-REST/Modelo-de-Madurez.md` |
| Informe de solución | Documento transversal, sintético y orientado a una decisión (arquitectura + despliegue + requisitos) | IS `10-Naturaleza-del-Informe/Que-es-y-que-no-es.md` |
| Superficie / promesa / estado | Recorte de interfaz con promesa propia (`[TestFixture]`) / compromiso verificable mirando la pantalla (`[Test]`) / situación observada con una aserción | E2E `Mapa-Del-Conjunto.md` §2.1; `Caso-HolaMundo-Page.md` |
| Docs as code / llms.txt | Documentación con las herramientas del código (Git, PR, CI) / índice Markdown del sitio para modelos de lenguaje | SDT §2.1, §1.4, §11 |

### 7.2 Términos con criterio divergente entre guías

| Término | Choque | Fuentes |
|---|---|---|
| **Build hermético / reproducible** | GF lo define como build «insensible a las bibliotecas y herramientas de la máquina: dos personas obtienen resultados idénticos» [F: SRE-1]. ENT separa tres propiedades: **determinista** (de una herramienta), **reproducible** (de una build, bit a bit) y **hermética** (del sistema de build, aislado del host), y advierte que ningún nivel vigente de SLSA exige hermeticidad. OEP `TEM-BUILD` llama «reproducible» al build con `global.json` + `rollForward latestFeature`; ENT muestra que un `rollForward` permisivo sólo hace cumplir el piso (E0-2) | GF §7.5, Anexo A; ENT §3.1, §3.4, §6.4; OEP `20-Organizacion-de-Soluciones/Build-Compartido.md` |
| **Modelo de ramas** | Adoptado: tronco `main` + `release/x.y` (GF §6, [C]). IMP propone `main` + `homologacion` y versión `MAJOR.MINOR.PATCH.BUILD` (`guia-flujo-trabajo-versionado.md`) y GitHub Flow estricto (D3, `marco-teorico.md` §6.7). **Prevalece GF** | [08](08_Ramas-CI-CD-y-DevOps.md) H-10 |
| **MediatR / AutoMapper** | `Microservicios-Guide.md` los prescribe; `GUIA-NET-ARQ` §4.9, §9.4 y Anexo C no los adopta (licencia RPL/comercial, CVE de AutoMapper) | [05](05_Arquitectura-NET-y-Laboratorio.md) |
| **Firma y feed NuGet** | IMP `marco-teorico.md` §8.1: firma con `dotnet nuget sign`, feed GitHub Packages; GHA §7.4/OBS-4: paquetes en nuget.org, ningún workflow firma; versión fuera del `.csproj` (GHA) vs `<Version>` en el `.csproj` (`publish-nuget.md`) | [08](08_Ramas-CI-CD-y-DevOps.md) |
| **Inventario de estados de pantalla** | DT: cuatro como piso, seis al especificar la interfaz, más dos de Blazor interactive server. E2E: dos estados son distintos si la salida ofrecida es distinta | DT `95-Transversales/UX-UI-y-Flujo-de-Usuario.md`; E2E `Del-Requerimiento-Al-Caso.md` §4 |
| **Umbral para volver a GitFlow** | GF §1.2 «tres o más versiones en paralelo» vs §4.4/§5.6 «dos versiones» | [08](08_Ramas-CI-CD-y-DevOps.md) H-18 |

### 7.3 Dónde están los glosarios completos

| Guía | Glosario |
|---|---|
| DT | `Guides/Documentacion-Tecnica/Creacion-Guias-Tecnicas/99-Anexos/Glosario.md` (canónico; las plantillas traen glosarios propios, ver `Revision-de-Consistencia.md` §Glosario canónico) |
| SDT | `Sistema-Documentador-Tecnico-Guide.md` §11 (16 términos) |
| IS | `Guides/Despliegue/Documentacion-Informe-Despliegue/99-Anexos/Glosario.md` (con fuente por término) |
| OEP | `Guides/Arquitectura/Organizacion-Estilo-Patrones-Codigo/99-Anexos/Glosario.md` |
| REST | **No tiene** (`ANEXO-GLOSARIO` citado, archivo inexistente) |
| NET | `Dot-NET-Arquitectura-Guide.md` Anexo D (término · alias · definición · § · código); `Microservicios-Guide.md` §1.1; `Manejo-Archivos-Guide.md` §7 |
| ENT | `Metodologia-Entorno-Desarrollo-Guide.md` Anexo C (86 filas) |
| E2E | `Lab-E2E.WebBlazor-Guides/E2E-Guide/Beginner-Guide.md` Anexo D |
| GF / GHA | `Estandares-Modelo-Ramas.md` Anexo A / `GitHub-Action-Guide.md` Anexo A (también en las copias de `Lab-E2E.WebBlazor-Guides/`) |
| IMP | `UX-UI-Guide.md` Apéndice A; `plan-mejoras-devops_v1.0.md` §11.1 |
| SEG | `Beginning-Security-Windows-Network-Guide.md` §13 |
