# 14 · Convenciones transversales y glosario cruzado

> **Propósito**: lo que conviene saber antes de leer **cualquier** guía del corpus. Cubre cómo se
> identifica un documento (frontmatter, `doc_id`), cómo se marca de dónde sale cada afirmación (niveles
> de autoridad, marcas de evidencia), por qué **el mismo prefijo significa cosas distintas en cada guía**
> y un glosario de los términos que cruzan guías, con la fuente de cada uno. Lo que es propio de un solo
> dominio queda en su índice (01–13). Acá va sólo lo que se repite entre guías o choca.
> **Fuentes primarias**: los `00-Marco-de-Referencia/Convenciones.md` (`MARCO-CONVENCIONES`) de DT, IS, OEP y
> REST; `Guides/IA/IA-Model/Convenciones.md` (`IAM-M3`); `tools/docs-guard/prefijos.txt`; la «Convención de marcas»
> de `Estandares-Modelo-Ramas.md`; `Dot-NET-Arquitectura-Guide.md` §0.5; `Metodologia-Entorno-Desarrollo-Guide.md`
> §0.3 y §2; `Dot-Net-Integration-AI-Layer-Guide.md` §0.4; y los glosarios que se listan en §8.
> Relevado sobre `main` `34929f2` (2026-11-15): 412 `.md` versionados (sin contar `tools/docs-guard/`), de los
> cuales 301 abren con frontmatter.

Las rutas son relativas a `Lab-Documentos/`. Estas son las siglas de guía que usan las tablas:

| Sigla | Guía | Índice |
|---|---|---|
| **DT** | `Guides/Documentacion-Tecnica/Creacion-Guias-Tecnicas/` | [01](01_Documentacion-Tecnica.md) |
| **IS** | `Guides/Despliegue/Documentacion-Informe-Despliegue/` (informe de solución) | [02](02_Informe-de-Solucion.md) |
| **OEP** | `Guides/Arquitectura/Organizacion-Estilo-Patrones-Codigo/` | [03](03_Organizacion-Codigo-NET.md) |
| **REST** | `Guides/Arquitectura/Organizacion-Estilo-Rest-API/` | [04](04_Diseno-REST-API.md) |
| **NET** / **NET-INT** | `Guides/Dot-NET-Arquitectura-Guide/Dot-NET-Arquitectura-Guide.md` (`GUIA-NET-ARQ`) y su guía interactiva (`GUIA-NET-ARQ-INT`) | [05](05_Arquitectura-NET-y-Laboratorio.md) |
| **ENT** | `Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (`GUIA-ENT-DEV`) | [06](06_Metodologia-Entorno-Desarrollo.md) |
| **E2E** / **TG** | `Guides/Testing/Lab-E2E.WebBlazor-Guides/E2E-Guide/` (`E2E-00`…`E2E-04`) / `…/Test-Guide/` | [07](07_Testing-E2E.md) |
| **GF** / **GHA** | `Guides/GitFlow/Estandares-Modelo-Ramas-Guide/Estandares-Modelo-Ramas.md` (`GF-GUIA`) / `Guides/Despliegue/GitHub-Action-Guide/` (`GHA-00`) | [08](08_Ramas-CI-CD-y-DevOps.md) |
| **IA-NET** / **CONV** | `Guides/IA/Dot-Net-Integration-AI-Layer-Guide/`: libro .NET (`GUIA-NET-IA`) y libro de diseño conversacional (`GUIA-DISENO-CONVERSACIONAL`) | [09](09_IA-Layer-DotNet.md) |
| **IAM** | `Guides/IA/IA-Model/` (prefijo `IAM-`) | [10](10_IA-Modelos-SDD-Agentes.md) |
| **IMP** | Material importado: `Guides/Despliegue/DevOps-Guide/`, `Guides/IA/SDD-Guide/`, `Guides/IA/references/`, `Guides/Metodologia-Agiles/`, `Guides/UX-UI-Design/` | [08](08_Ramas-CI-CD-y-DevOps.md), [10](10_IA-Modelos-SDD-Agentes.md), [11](11_Agiles-UX-y-Seguridad.md) |
| **SEG** | `Guides/Otros/Seguridad-Red-Windows-Guide/` | [11](11_Agiles-UX-y-Seguridad.md) |
| **SDEI** | `Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/` (`corpus_id: SDEI`), con `AGENTS.md` y `tools/docs-guard/` | [12](12_Sistema-Documentador-SDEI.md) |
| **FC** | `Concepts/Framework-Concept/` (prefijo `FC-`) | [13](13_Framework-Concept.md) |

---

## 1. Frontmatter

### 1.1 El bloque normado (DT, IS, OEP, REST)

Las cuatro guías estructuradas definen el mismo bloque en `Convenciones.md` §Frontmatter obligatorio:

```yaml
---
doc_id: DOC-SAD            # DT usa un ID real de ejemplo; IS/OEP/REST usan el marcador TEM-XXX
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

- La guía lo dice así: «`origin` y `confidence` no son decorativos». Son lo que le permite al lector
  distinguir lo verificado de lo inferido (DT `Convenciones.md` §Frontmatter obligatorio).
- Un campo que no aplica se omite. No se deja vacío.
- **No hay campo `version`**: la vigencia se lee en `last_review`.

### 1.2 Variantes por familia de guías

| Familia | Campos que agrega o cambia | Fuente |
|---|---|---|
| DT, IS, OEP, REST | El bloque normado de §1.1, sin `version` | cada `Convenciones.md` |
| IAM | El bloque normado más `entorno_validado` (la corrida que valida el tema); `origin: ia-generated`; `owner: ACT-xx`; las 15 piezas están en `status: borrador` | `Guides/IA/IA-Model/*.md` |
| NET, NET-INT, ENT | `version`, `sdk_validado`/`entorno_validado`, `related`, `laboratorio`, `prerequisites`; `doc_type: study-guide`; `origin: ai-assisted` | frontmatter de cada guía |
| IA-NET, CONV | `version` (1.2.0 y 1.6.0), `doc_type: guia-de-estudio`, `tope_palabras`, `related` | frontmatter de los dos libros |
| GF, GHA, E2E | `owner: Lab-GitFlow` / `Lab-E2E.WebBlazor.Documentacion`, `audience` por rol, `consolida:` (GF); `origin: agente` | [08](08_Ramas-CI-CD-y-DevOps.md), [07](07_Testing-E2E.md) |
| SDEI | Diez campos más `description` (≤160 caracteres) y un `delivery` opcional; `corpus_id` y `version` van sólo en el README del cuerpo; las páginas de ayuda usan `roles`/`translation_of` y no llevan `doc_id`. Lo valida una máquina | `99-Anexos/Esquema-Frontmatter-Y-Prefijos.md` §2–§3 |
| FC | El bloque normado más `description`, con `origin: ia-generated` y `status: borrador`; el Conocimiento lleva un encabezado propio, sin `doc_id` | [13](13_Framework-Concept.md) |
| SEG, `Guides/README.md` | El bloque normado; `doc_id` genéricos (`GUIA-PRINCIPAL`, `CUADERNO`, `GUIAS-INDICE`) | [11](11_Agiles-UX-y-Seguridad.md) |
| IMP | Sin frontmatter. Usa una cabecera en negrita «Documento / Versión / Fecha / Estado», una tabla «Control de cambios» y el cierre «Fin del documento» | p. ej. `Guides/Metodologia-Agiles/*/Estudio-Guide.md` |
| Conocimientos (IA-NET `K1–K8`, FC) | Una cabecera en negrita (Alias, Versión, Estado, Fecha…), sin `doc_id` | FC `Conocimientos/README.md`; los de IA-NET y SDEI se mudaron a la base de conocimientos (`Rule-Forma-De-Conocimiento.md`) y en LD queda un puntero |

Además quedan sin frontmatter: `Microservicios-Guide.md` y `Manejo-Archivos-Guide.md` de NET,
11 documentos de `Lab-E2E.WebBlazor-Guides/` (usan el bloque «De qué va / Para quién / Qué deja»),
los README de ejemplos y `Guides/IA/Claude-Guide.md`.

### 1.3 Valores observados (en `34929f2`)

| Campo | Frecuencia | Lectura |
|---|---|---|
| `origin` | `ia-assisted` ×221 · `ia-generated` ×41 · `agente` ×19 · `ai-assisted` ×3 | Hay cuatro grafías; `agente` y `ai-assisted` no están en el vocabulario normado |
| `status` | `vigente` ×210 · `borrador` ×73 · `en construcción` ×1 | Ya no queda ningún `obsoleto` versionado. `borrador` corresponde a SDEI, FC e IAM; `en construcción`, a `GUIA-NET-ARQ-INT` |

> **Consecuencia**: no hay un esquema único. Para filtrar por vigencia hay que mirar `status` +
> `last_review` donde haya frontmatter, `version` en NET/ENT/IA-NET y la cabecera en IMP.

---

## 2. Identificadores de documento (`doc_id`)

La regla común de DT, IS, OEP y REST es enlazar por ID y no por ruta: «los archivos se mueven, los IDs no»
(DT `Convenciones.md` §Identificadores).

### 2.1 Prefijos de `doc_id`

| Prefijo | Significado | Guías |
|---|---|---|
| `GUIA-INDICE` | README raíz de la guía | DT, IS, OEP |
| `MARCO-ESCENARIOS/CONTEXTOS/ACTORES/CONVENCIONES` | Marco de referencia | DT, IS, OEP, REST |
| `MAPA-CONCEPTUAL` | Mapa «estoy acá → qué leo» | DT, IS, OEP |
| `FAM-` | README de una familia | DT (`FAM-VIS`…`FAM-USR`), IS, OEP (`FAM-SRV`…`FAM-PAT`), REST |
| `DOC-` | Documento por tipo documental | DT (`DOC-SAD`, `DOC-SRS`, `DOC-RUNBOOK`…); SDEI (`DOC-SDEI-LIBRO-*`) |
| `TEM-` | Documento temático | IS, OEP, REST (`TEM-RMM`, `TEM-STATUS`…); SDEI (`TEM-SDEI-nn`) |
| `MET-` / `ARQ-` | Método ágil / modelo de arquitectura | DT `80-Metodos-Agiles/`, `90-Modelos-de-Arquitectura/` |
| `ANEXO-` | `GLOSARIO`, `CHECK`, `REFERENCIAS`, `PENDIENTES`… | DT, IS, OEP, REST |
| `IDX-`, `ANX-`, `GP-`, `DEMO-`, `AUD-` | Índice, anexo, guía práctica, pieza de demo (`DEMO-MU-nn`), audiencias | SDEI |
| `FC-` | Todo el Framework Concept (`FC-TEM-0n`, `FC-MARCO-REFERENCIA`, `FC-ANEXO-99`, `FC-GUIA-INDICE`, `FC-ADR-0001`…) | FC |
| `IAM-` | `IAM-M0…M3` (marco) e `IAM-01…11` (temas) | IAM |
| `GUIA-` | Guía de estudio sin espacio de prefijo propio | `GUIA-NET-ARQ(-INT)`, `GUIA-ENT-DEV`, `GUIA-NET-IA`, `GUIA-DISENO-CONVERSACIONAL` |
| `GF-`, `GHF-`, `GHA-`, `E2E-` | Bloque de ramas, Actions y E2E | GF, GHA, E2E |
| `GUIA-PRINCIPAL`, `CUADERNO` | Guía y cuaderno de seguridad, sin prefijo de dominio | SEG |

### 2.2 El registro cerrado de prefijos

`tools/docs-guard/prefijos.txt` declara cada prefijo con su **ámbito**:

- **interno**: el ID se declara en este repo y, si no resuelve, `traces-resolve` bloquea. Son internos
  `ESC CTX ACT DOC FAM MET ARQ MARCO MAPA ANX IDX FC AUD TEM CQ PE OBJ EJR RD VER DEMO GP GUIA`.
- **externo**: el ID pertenece al sistema documentado. Resuelve contra el SHA de `source.lock`; sin
  `source.lock` sólo avisa. Son externos `RF RNF RN CU ADR TC RSK FLU NB`.

Un prefijo nuevo entra por un PR que lo agregue. La compuerta **bloquea** sólo dentro de las carpetas cuyo
README declara `corpus_id` (el cuerpo SDEI); en el resto del repo sólo avisa ([12](12_Sistema-Documentador-SDEI.md)).
`IAM-`, `GF-` y `E2E-` no figuran en el registro (verificado en `34929f2`).

### 2.3 Los `doc_id` sólo son únicos dentro de cada guía

Estos son los `doc_id` que se repiten en el primer bloque de frontmatter (`34929f2`):

| `doc_id` | Veces | Causa |
|---|---:|---|
| `MARCO-ESCENARIOS/CONTEXTOS/ACTORES/CONVENCIONES` | 4 c/u | Aparato común de DT, IS, OEP y REST, **a propósito** |
| `GUIA-INDICE`, `MAPA-CONCEPTUAL`, `ANEXO-GLOSARIO`, `ANEXO-REFERENCIAS` | 3 c/u | Lo mismo |
| `ANEXO-CHECK`, `ANEXO-PENDIENTES`, `FAM-ARQ` | 2 c/u | Lo mismo (`FAM-ARQ` está en DT y en IS) |
| `GF-GUIA`, `GHA-00`, `GF-09-ESCENARIOS`, `GHF-GUIA`, `GF-AX-WF` | 2 c/u | **Copias aplanadas** en `Guides/Testing/Lab-E2E.WebBlazor-Guides/` |
| `E2E-00`, `E2E-01` | 2 c/u | Una copia vieja y una vigente de la guía E2E ([07](07_Testing-E2E.md)) |

**Regla para un agente**: citar siempre `doc_id` **más ruta** (o la sigla de la guía). `MARCO-ACTORES` sin
ruta es ambiguo. El prefijo `FC-` se creó justamente para que el Framework Concept no chocara con estos IDs.

---

## 3. Cómo se marca la procedencia de una afirmación

El rasgo central del corpus es **separar lo normado de lo convenido y de la opinión propia**. Hay dos
mecanismos, y una misma guía no los mezcla.

### 3.1 Niveles de autoridad y catálogo de fuentes (IS, OEP, REST)

| Nivel | IS (4) | OEP (3) | REST (4) | Prefijo de fuente |
|---|---|---|---|---|
| Normativo | ISO/IEC/IEEE, RFC, OMG, Microsoft | **sólo Microsoft** | RFC, OpenAPI, Microsoft Learn | `N-xx` |
| Marco / guía de organización | arc42, C4, TOGAF | no tiene | Microsoft (Azure/Graph), Google AIP, Zalando… | `G-xx` |
| Convención de facto | Práctica dominante | Práctica del ecosistema | Práctica dominante | `F-xx` |
| Criterio propio | «esta guía recomienda» | ídem | ídem | — |
| (Son fuentes, no niveles) | Obras `O-xx`, plataforma `P-xx` | Obras `O-xx` | `O-xx`, `P-xx` | `O-`, `P-` |

Fuentes: los `Convenciones.md` (§Los cuatro / tres niveles de autoridad) y `99-Anexos/Referencias.md` de cada guía.

- **Los catálogos se numeran por guía**: `N-01` es ISO/IEC/IEEE 42010 en IS y RFC 9110 en REST. Un «`N-01`»
  sin guía no identifica nada.
- DT no numera fuentes por nivel. En los ejemplos usa prefijos de industria (`RF-`, `RNF-`, `RN-`, `CU-`, `ADR-`,
  `TC-`, `RSK-`) y cita las normas ISO por designación, nunca por texto (`Convenciones.md` §Trazabilidad y fuentes).

### 3.2 Marcas en línea

| Guía | Fuente externa | Criterio propio | Comprobado / ejecutado | No verificado | Fuente |
|---|---|---|---|---|---|
| GF | **[F]** → Anexo E | **[C]** convención del equipo | (no tiene) | — | `Estandares-Modelo-Ramas.md` §Convención de marcas |
| GHA | **[F: ID]** (`GHDOC-*`…) | **[C]** | **[E: ID]**, `[E: OBS-n]` | — | `GitHub-Action-Guide.md` |
| E2E / TG | **[F: id]** · TG `[B: n]` | **[C]** | **[E: ruta]** · **[V]** por ejecución | — | `Beginner-Guide.md`; `Test-Guide/README.md` |
| NET | `[Autor, año]` / `#ref-…` | «Criterio de esta guía» | Salida registrada, `[Compilado]`, `[Compilado sin captura]` | `[Fragmento ilustrativo]` | NET §0.5 |
| NET-INT | `[Fuente: enunciado]`, `[Leído]` | — | «Verificado en máquina» | «Pendiente de mesa», «Hallazgo contra la guía» | NET-INT §0.3 |
| ENT | **[Bnn]** (B01–B223, Anexo D) | **[criterio]** | **[observado]**, `E<n>-<m>` | **[no verificado]**, **[interpretación]** | ENT §0.3 |
| IA-NET | `[REF-nn]` | «criterio de la guía» | tasa k de M con IC95 de Clopper-Pearson | NO VERIFICADO, NO EJECUTADO | IA-NET §0.4 |
| IAM | cita APA (sin verificar formato exacto) | — | bloque «protocolo» con la corrida | — | `IA-Model/Convenciones.md` §4 |
| FC | `[archivo:líneas]`, `[folio NNN]`, `[E0x]`, `[Rn]` | — | — | NO VERIFICADO, NO EJECUTADO, ESPECULACIÓN, HISTÓRICO, VARIANTE NO FUSIONADA | libro FC, Prólogo y tabla 0.2 |
| SDEI | APA 7 con ancla `ref-…` y fecha de consulta | Clase D/P/H | Ancla `ruta#Símbolo@SHA` | — | `00-Marco.md` §5; `tools/docs-guard/README.md` §4 |

> Las letras se reutilizan entre guías: `[B: n]` de TG no es `[Bnn]` de ENT, y GF **no tiene** `[E]` (sólo
> `[F]`/`[C]`, verificado). GF y E2E comparten una frase: «un documento de proceso pierde autoridad cuando
> presenta preferencias del autor como si fueran estándares de la industria».

### 3.3 Clases D/P/H (SDEI)

**D**: la cierra un generador. **P**: la propone un agente o una persona. **H**: la decide sólo una persona
(`00-Marco.md` §1; `Como-Decidir.md` §6). Pasar un documento a `vigente` requiere un PR propio de una persona.

### 3.4 Material sin mecanismo de procedencia

IMP (DevOps, SDD, `references/`, Scrum/Jira, UX) **no** marca niveles ni evidencia. Mezcla norma, práctica y
lo que prescribía su proyecto de origen (Motor DSL). Hay que leerlo como referencia, nunca como norma del corpus.

---

## 4. Estructura de documento y numeración

### 4.1 Estructura fija por guía

| Guía | Estructura | Fuente |
|---|---|---|
| DT, IS, OEP, REST | Temático en 7 secciones: Resumen · Definición · Aplicación por escenario · Ejemplos · Preguntas guía · Criterios de calidad · Anexo (plantilla comentada). Las variantes de catálogo son OEP `TEM-ANTI` y REST `TEM-STATUS`; la familia 50 de IS usa frases «así no / así sí» | cada `Convenciones.md` §Estructura |
| IAM | Definición, aplicación por escenario, ejemplos, bloque didáctico, criterios de calidad y anexo; **350–700 líneas** orientativas, y pasarse exige un apartamiento declarado | `IA-Model/Convenciones.md` §5, §7 |
| ENT | Capítulos con `n.1`…`n.9`: `n.3` industria, `n.6` preguntas guía, `n.9` práctica | ENT §0.2 |
| NET | Caps. I–II con **Respuesta:** en negrita al principio | NET §0.3 |
| IA-NET | Definición → Escenarios → Ejemplo → Decisión → Preguntas → Calidad; anclas estables `cN`/`cN-k` | IA-NET §0.4, §0.7 |
| SDEI | Seis secciones fijas más «Fuentes y observaciones» | README del cuerpo §5 |
| FC | Resumen, definición, aplicación por escenario, ejemplos, preguntas guía, criterios, plantilla, observaciones, referencias | capítulos `0n-*.md` |
| Prácticas GF/GHF | Objetivo · Precondición · Pasos · Qué observar · Errores frecuentes · Verificación | `Git-Flow-Guides/*/README.md` |
| `Lab-E2E.WebBlazor-Guides/` | Cabecera «De qué va / Para quién / Qué deja» | sus `.md` |
| Material importado (ágiles) | «## 1 — Título», con raya | [11](11_Agiles-UX-y-Seguridad.md) |

### 4.2 Nombres de archivo y numeración de carpetas

| Convención | Significado | Dónde |
|---|---|---|
| `00-Marco-de-Referencia/` | Escenarios, Contextos, Actores, Convenciones | DT, IS, OEP, REST |
| `01-…` | Naturaleza o primera familia (p. ej. `01-Mapa.md` en SDEI) | varias |
| `10-`…`95-` | Familias temáticas; **el orden de las carpetas es el orden de lectura** | IS README; DT (`80-Metodos-Agiles`, `90-Modelos-de-Arquitectura`, `95-Transversales`) |
| `99-Anexos/` | Glosario, Referencias, Pendientes, Check | DT, IS, OEP, REST, SDEI; FC `99-Anexos.md` |
| `0n-Nombre.md` | Capítulo numerado | FC, SDEI |
| `NN-Nombre/` | Ejemplo con un `.csproj`, `README`, `ejemplo.json` y `entradas.v1.json` congelado por SHA-256 (cambiar la entrada crea un `v2`) | IA-NET `Examples/README.md` |
| `*-Guide.md` | Guía de un solo archivo | NET, ENT, GHA, IMP |
| `capturas/Lnn-*.txt` | Salida de cada paso del laboratorio; la primera línea es `# comando:` | NET |
| `Examples/*/salidas/*.txt` | Salidas de referencia versionadas | ENT |
| `ADR-NNNN-*.md` | Decisión registrada | FC `Decisiones/` |
| `Anterior/Siguiente` | Siguen la ruta formativa, no el orden numérico | IAM `Cohesion-Global.md` §2 |

---

## 5. Prefijos de marco: el mismo prefijo, otro significado

**Antes de citar `ESC-2`, `CTX-1`, `ACT-03` o `E-01` hay que decir de qué guía es.** Sólo IS y REST traen una
tabla de correspondencia con los ejes de DT.

| Guía | Escenarios | Contextos | Actores | Fuente |
|---|---|---|---|---|
| DT | `ESC-1` nuevo · `2` migración · `3` evaluación con código · `4` evaluación desde afuera | `CTX-1` web · `2` backend · `3` fullstack | `ACT-01..10`; `ACT-10` es el **agente de IA, sin autoridad** | `DT/00-Marco-de-Referencia/*.md` |
| IS | `ESC-1` en diseño · `2` construida · `3` en evolución · `4` ajena | `CTX-1` monolito · `2` cliente-servidor · `3` borde · `4` distribuido | `ACT-01..08` | `IS/00-Marco-de-Referencia/*.md` |
| OEP | `ESC-1` nuevo · `2` evolución · `3` normalización · `4` evaluación | `CTX-1` web · `2` API · `3` biblioteca · `4` distribuida | `ACT-01..06` | `OEP/00-Marco-de-Referencia/*.md` |
| REST | `ESC-1..4` (`4a` con código, `4b` desde afuera) | `CTX-1` pública · `2` interna · `3` backend propio · `4` integración | `ACT-01..07`; seguridad y operaciones con **veto** | `REST/00-Marco-de-Referencia/*.md` |
| IAM | `ESC-01..07` | `CTX-01..06` (`CTX-01` equipo sólo CPU; `CTX-03` el banco Ollama) | `ACT-01..06` | `IA-Model/Marco-De-Referencia.md` §2–§4 |
| E2E | `ESC-01..05` | `CTX-01..04` | `ACT-01..04` | `Beginner-Guide.md` §2 |
| TG | `S1..S6` | `C-Web`, `C-API`, `C-Móvil`, `C-Escritorio`, `C-CI` | — | `Panorama-De-Pruebas-Automatizadas.md` §2 |
| ENT | `ESC-01..05` (Windows+VS, Linux/macOS, WSL2, devcontainer, CI) | `CTX-NET/NODE/PY/POLI` | `ACT-DEV/ARQ/OPS/REV` | ENT §2 |
| IA-NET | `ESC-nn` de la demo | `CTX-EXISTENTE/LOCAL/PROTO` | `ACT-DEV/ARQ/OPS/SEC` | IA-NET §3.2–§3.3 |
| SDEI | `ESC-SDEI-1..4` | `CTX-SDEI-1..4` | `ACT-SDEI-1..6` | `SDEI/00-Marco.md` §2–§4 |
| GF | `E-01..08` | `C-1..4` (`C-4`: tres o más versiones; es el único que justifica GitFlow) | `A-PO`, `A-DEV`, `A-REV`… | GF §1 |
| GHA | `E-01..10` | `C-1..5` | `A-DEV`, `A-QA`, `A-DEVOPS`… | GHA §3 |
| NET | `E-A..E-E` | — | — | NET §0.4, §9.1 |

### 5.1 Otras colisiones de identificadores

| ID | Significados que conviven | Dónde |
|---|---|---|
| `ESC-01` | Pantalla nueva (E2E) · Windows+VS (ENT) · primer escenario de IAM | §5 |
| `P-n` / `P-xx` | Principios de arquitectura `P-1…P-10` (IA-NET §1.2) · principios de proceso `P-1…P-9` (CONV cap. 2) · evidencia de plataforma `P-xx` (IS/REST) · decisiones FC `P1…P11` · `PD-1…6` demo IA-NET / `PD-01/02` deudas IAM | índices 09, 10, 13 |
| `F-…` | Fuente de facto `F-xx` (IS/OEP/REST) · hallazgo `F-A…F-J` (NET-INT §5) · forma de respuesta `F1–F8` (K5) | — |
| `E…` | Escenario `E-01` (GF/GHA) · experimento `E<n>-<m>` (ENT) · etapa `E0–E7` (CONV) · antipatrón `E1–E9` (K4 §7 en la base; §8 en `8791fb1`) · `E-A…E-E` (NET) | — |
| `R…` | Rúbrica `R1–R14` (CONV Anexo I) · registro `R-LLM` · `[Rn]` en FC | índices 09, 13 |
| `A…` | Actor `A-xx` (GF/GHA) · hito `A0–A9` (NET-INT) · artefacto `A-01..A-13` (SDEI) | — |
| `T…` | Topología `T1–T5` (OEP) · principio del turno `T-1…T-8` (CONV cap. B) | — |
| `SA-xx` / `AG-xx` | Subagentes del refinamiento / especialidades SDD; **las numeraciones no coinciden** | IMP `Guides/IA/references/` |
| `ESC-TESTIGO`, `ESC-CORPUS` | `traces` de SEG que no resuelven dentro de `Lab-Documentos/` | [11](11_Agiles-UX-y-Seguridad.md) |

### 5.2 Series de pasos, experimentos y registros

| Serie | Qué numera | Guía |
|---|---|---|
| `L00–L24` / `V01–V09` | Pasos de `lab.sh` / variantes de `variantes.sh` | NET Anexo A |
| `RN-xx` | Reglas de negocio de La Estancia | NET-INT |
| `E<n>-<m>`, `EA-1` | Experimentos del Anexo E | ENT |
| `K1–K8` | Id históricos de los Conocimientos de la capa de IA, mudados el 2026-11-19 a la base de conocimientos y citados hoy por alias (`AI-Layer-*`); el libro es su fuente, no rige sobre ellos | IA-NET `Conocimientos/README.md` (puntero, con la correspondencia de secciones) |
| `ADR-01…13` / `ADR-IA-01…06` | Decisiones de la capa / del caso Geometría | IA-NET caps. 14 y 16 |
| `AC-6/7/8`, `R-PRIV` | Compuertas | IA-NET `Compuertas/README.md` |
| `HUE-` / `VER-` / `CNV-` | Huecos, verificaciones y convenciones pendientes | DT `99-Anexos/Pendientes.md` |
| `CL-01..14`, `RD-nn`, `CQ-01..14`, `PE-01..12`, `OBJ-`/`EJR-SDEI-nn` | Clases de pieza, requerimientos documentales, criterios, patrones, objetivos/ejercicios | SDEI |
| `AI-1..5`, `PR-1..7` | Chequeos anti-inyección y grupos del carril PR de `docs-guard` | `tools/docs-guard/README.md` §1 |
| `N1–N5` | Núcleos temáticos | FC `08-Cohesion-Global.md` |
| `G1–G8` | Criterios de la lista de verificación del informe | IS `ANEXO-CHECK` |
| `OBS-n`, `W-*` | Observaciones y catálogo de evidencia | GHA Anexo F |
| `FU-`/`WF-`, `US-`, `BT-`, `NB-`, `CU-` | IDs del proyecto de origen (Motor DSL), sin destino en este repo | IMP |
| `FLU-` | Flujo de usuario | DT `95-Transversales/UX-UI-y-Flujo-de-Usuario.md` |

---

## 6. Otras convenciones compartidas

| Convención | Qué fija | Fuente |
|---|---|---|
| Dominio de ejemplo **reserva de salas** | Es el ejemplo común de DT, OEP y REST | REST `Convenciones.md` §Vocabulario y ejemplos |
| Otros dominios de ejemplo | Sistema de audiencias en el borde (IS), productos y pedidos (NET), La Estancia (NET-INT), `MovilidadUrbana` (E2E, IA-NET, SDEI), Geometría (IA-NET cap. 16), SRV-MADERA01 (SEG) | índices 02, 05, 07, 09, 11, 12 |
| Idioma por planos | El patrón va en inglés como sufijo y el concepto de dominio en español como raíz (`CrearProductoCommand`) | NET §8.4; `Lab-E2E.WebBlazor-Guides/Nomenclatura-Convensiones-Arquitecture-Dot-Net.md` §1–§3 |
| `data-testid` / `AutomationId` | No se traducen: son el contrato entre interfaz y prueba | `Nomenclatura-…md` §3 |
| No duplicar | Cada tema vive en un solo documento («el documento dueño») y los demás lo enlazan | cada `Convenciones.md`; E2E `Mapa-Del-Conjunto.md` §3.2; IAM `Convenciones.md` (preámbulo) |
| Autocontenido | Cada documento IAM se lee sin abrir otro y sin una versión previa | IAM `Cohesion-Global.md` §3 |
| Diagramas | Mermaid; el C4 se dibuja con `flowchart`+`subgraph`, no con `C4Context`; la lámina IA-NET se edita en el `.def.json`, nunca en el SVG | IS `Convenciones.md`; IA-NET `Laminas/LEEME.md` |
| Vocabulario del FC | Primera mención: «contenedor nativo (native shell; en la jerga del proyecto, "cascarón")»; después nunca «contenedor» solo | FC `Decisiones/ADR-0001-Contenedor-Nativo.md` |
| Lo privado | Se nombra sólo por alias; no se versionan rutas de máquina, IPs, hosts ni usuarios | `AGENTS.md` §5 |
| SemVer | Tags `vX.Y.Z`, `-rcN` [C] (GF §7.3); contenido OTA en SemVer sin pre-release, más `+commit` (FC P7) | GF; FC `Demo/versionado/` |

---

## 7. Glosario cruzado

### 7.1 Términos compartidos

| Término | Definición | Fuente |
|---|---|---|
| Escenario | Situación de partida con un disparador reconocible; determina si la documentación decide, describe o infiere. El conjunto concreto cambia por guía (§5) | DT `99-Anexos/Glosario.md` |
| Contexto | Tipo de software (DT), forma de despliegue (IS), distancia al consumidor (REST), ecosistema (ENT), equipo o banco (IAM) | §5 |
| Actor | Rol con autoridad y alcance definidos sobre ciertos documentos; se define por lo que decide, no por el cargo | DT `Glosario.md`; `Actores.md` |
| Familia | Agrupación de artefactos que responden a la misma pregunta | DT `Glosario.md` |
| Doble audiencia | Documento que sirve a una persona y a un agente (`audience: [humano, agente]`) | DT `Glosario.md` |
| `audience` vs `delivery` | `audience` orienta; `delivery` es la regla de entrega que protege | SDEI `Esquema-Frontmatter-Y-Prefijos.md` |
| Cuerpo nuevo | Carpeta cuyo README declara `corpus_id`; ahí la compuerta bloquea | `tools/docs-guard/README.md` §1 |
| `source.lock` | Archivo que fija el repo y el SHA del código documentado | SDEI (mini demo) |
| ADR | Registro de una decisión con alternativas | DT `Glosario.md`; IA-NET cap. 14; FC `Decisiones/` |
| Spec-Driven Development | La especificación es el artefacto primario. Lo tratan DT `DOC-SDD`, REST `TEM-SDD` e IMP `SDD-Guide` (Spec-First / Spec-Anchored / Spec-as-Source), sin enlaces entre sí | `95-Transversales/Spec-Driven-Development.md` (DT, REST); `Guides/IA/SDD-Guide/` |
| Capa / *tier* | Capa: agrupación lógica por responsabilidad. *Tier*: unidad de despliegue físico | OEP `99-Anexos/Glosario.md` |
| Monolito distribuido | Varias unidades desplegables que no pueden desplegarse ni fallar por separado | OEP `Microservicios.md` |
| Composition root | El único lugar que registra las implementaciones (la WebAPI / `Program.cs`) | NET §2.5, Anexo D |
| Contrato / `Contracts` | Forma de los datos que cruzan un borde; en NET es además el proyecto `Contracts` | OEP `Glosario.md`; NET §8.5 |
| Compuerta / puerta | Condición que un cambio debe cumplir para avanzar (GHA) · compuerta única texto·toolchain·grafo (ENT §10.2.2) · `docs-guard` (SDEI) · `AC-n` (IA-NET) | — |
| Check requerido | Job agregador que es el único check obligatorio de `main` (CI aprobada en GF; `fw-ok` en FC) | GF §8.5; `framework-concept-demo.yml` |
| Promesa | Lo que se prueba; la promesa negativa se verifica comparando dos observaciones | E2E `Caso-Login-Page.md` §2.4 |
| Superficie | Unidad de prueba deducida del acto (`[TestFixture]`) | E2E `Mapa-Del-Conjunto.md` §2.1 |
| Cliente guionado / `--fake` | `IChatClient` sin servidor; prueba la conducta del código, no la del modelo | IA-NET §0.4 |
| Conducta del modelo vs garantía del código | La garantía se prueba en cada build; la conducta se informa como k de M (P-10) | IA-NET §1.2 |
| Banco | Servidor Ollama en red donde corren los labs; se verifica en el Paso 0 | IAM `IA-Model-Guide.md` §1; `08-Inferencia-Local.md` |
| Conocimiento | Documento destilado para que lo cargue un agente, con cabecera propia y sin `doc_id` | La base de conocimientos (los de IA-NET y SDEI, desde el 2026-11-19); FC `Conocimientos/` |
| Nivel 2 de Richardson | Recursos con URI y verbos HTTP según su semántica, sin hipermedia | REST `Modelo-de-Madurez.md` |
| Informe de solución | Documento transversal, sintético y orientado a una decisión | IS `Que-es-y-que-no-es.md` |
| Contenedor nativo | La app MAUI que se publica en tienda; reemplaza a «cascarón» | FC `ADR-0001` §2 |
| Offline-first / outbox | La base local es la fuente de verdad | FC libro cap. 5 |

### 7.2 Términos con criterio divergente entre guías

| Término | Choque | Fuentes |
|---|---|---|
| Build hermético / reproducible | GF lo define como un build insensible a la máquina. ENT separa tres propiedades: determinista, reproducible y hermética. OEP llama reproducible al build con `global.json` + `rollForward` | GF §7.5; ENT §3; OEP `Build-Compartido.md` |
| Modelo de ramas | GF adopta `main` + `release/x.y`. IMP propone `main` + `homologacion` y GitHub Flow. **Prevalece GF** | [08](08_Ramas-CI-CD-y-DevOps.md) |
| MediatR / AutoMapper | `Microservicios-Guide.md` los prescribe; `GUIA-NET-ARQ` no los adopta | [05](05_Arquitectura-NET-y-Laboratorio.md) |
| Principios `P-n` | IA-NET y CONV numeran listas distintas con el mismo prefijo | [09](09_IA-Layer-DotNet.md) |
| Extensión de un documento | IAM: 350–700 líneas por temático; IA-NET: `tope_palabras` en el frontmatter | IAM `Convenciones.md` §5 |

---

## 8. Dónde están los glosarios completos

| Guía | Glosario |
|---|---|
| DT | `Guides/Documentacion-Tecnica/Creacion-Guias-Tecnicas/99-Anexos/Glosario.md` |
| IS | `Guides/Despliegue/Documentacion-Informe-Despliegue/99-Anexos/Glosario.md` |
| OEP | `Guides/Arquitectura/Organizacion-Estilo-Patrones-Codigo/99-Anexos/Glosario.md` |
| REST | No tiene: cita `ANEXO-GLOSARIO`, pero el archivo no existe (verificado en `34929f2`) |
| NET | `Dot-NET-Arquitectura-Guide.md` Anexo D |
| ENT | `Metodologia-Entorno-Desarrollo-Guide.md` Anexo C |
| E2E | `Lab-E2E.WebBlazor-Guides/E2E-Guide/Beginner-Guide.md` Anexo D |
| GF / GHA | `Estandares-Modelo-Ramas.md` Anexo A / `GitHub-Action-Guide.md` Anexo A |
| IA-NET / CONV / IAM / FC | Glosario propio en cada libro (sin verificar la sección exacta) |
| SEG | `Beginning-Security-Windows-Network-Guide.md` §13 |
| IMP | `UX-UI-Guide.md` Apéndice A |
