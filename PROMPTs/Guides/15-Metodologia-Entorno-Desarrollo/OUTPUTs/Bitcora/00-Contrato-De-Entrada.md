---
doc_id: BIT-15-00
doc_type: contrato-de-entrada
title: Contrato de entrada de la mesa — Metodología del entorno de desarrollo
status: vigente
origin: agent
confidence: 0.85
owner: analista de descomposición (sin voto en la mesa)
last_review: 2026-10-07
audience: [mesa-evaluadora, presidente, PO]
traces: [PROMPT-15, MARCO-MESA-§2, PROFILE-STUDY-GUIDE]
---

# Bitácora 00 — Contrato de entrada

**Fecha:** 2026-10-07
**Norma de forma:** `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md`, §2 (contrato de entrada) y §3 (escala E1–E4, severidades S1–S4).
**Prompt de origen (sólo lectura):** `LAB/Lab-Documentos.Documentacion/PROMPTs/Guides/15-Metodologia-Entorno-Desarrollo/Crear-Analizar-Metodlogia-Entorno-Desarrollo.md`
**Precedente de forma (no de contenido):** `PROMPTs/Guides/06-Crear-Dot-NET-Arquitectura-Guide/OUTPUTs/Bitacora-Editores/` (contrato en bloque `text`, núcleos con tabla de dependencias, trazabilidad a comisiones).

El objeto de esta mesa no existe todavía: la guía de destino es un archivo vacío (0 bytes, verificado con `ls -la` el 2026-10-07). El contrato se instancia, por eso, sobre la **cadena** pedido → núcleos → guía, y no sobre una versión previa del entregable. Los campos que el marco pide como hash o versión se fijan contra el prompt del PO y se renuevan en cada ciclo contra la guía.

## 1. Pedido resumido (sin identificadores privados)

El PO relata un fix real en un repositorio **privado** de una organización: un sistema .NET heredado con alrededor de cien archivos `.cs`/`.razor` guardados en Windows-1252 se convirtió a UTF-8 con BOM, porque al compilar en Linux el compilador los leía como UTF-8, un identificador con un carácter no ASCII rompía la compilación y los textos con acentos salían con `?`; en Windows el mismo código compilaba sin cambios. El equipo desarrolla a la vez con Visual Studio en Windows, en Linux y en devcontainers Linux.

De ese caso el PO deriva tres preocupaciones encadenadas y una solicitud de análisis:

1. Un criterio unificado de codificación del código fuente para no tener commits cuyo único cambio sea el BOM.
2. Una mecánica para congelar paquetes NuGet y versiones de compilador/SDK, preguntándose si los contenedores sirven para eso y cómo convive con desarrolladores en Windows y Linux.
3. Saber con qué entorno se ensambló cada pieza construida.
4. Analizar qué propone hoy la industria para .NET, Node.js y Python, y en especial qué pasa cuando los tres conviven en una única solución.

> Regla de privacidad aplicada desde este documento: el caso se describe en forma genérica y se reproduce con un ejemplo sintético propio en `Examples/`. No se transcribe el comentario literal del fix porque nombra componentes e identificadores privados.

## 2. Contrato (§2 del marco)

```yaml
objeto:
  artefacto: guía de estudio (documentación formativa), hoy inexistente; se juzga la cadena pedido → núcleos → guía
  ruta/id: LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md
  version: "0 (archivo vacío al 2026-10-07); cada ciclo registra sha256 y cantidad de líneas"
  capas_derivadas:
    - LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Examples/  # laboratorio que la guía cita
    - OUTPUTs/Metodlogia-Entorno-Desarrollo.md                             # prompt reeditado sobre el marco de mesa (sólo el agente encargado)
objetivo: >
  Que un lector sin contexto previo entienda por qué el mismo código se comporta distinto en
  Windows, Linux y contenedores, y forme criterio para fijar, por capas, la codificación del
  fuente, el toolchain, las dependencias, el entorno de construcción y la procedencia de lo
  construido, en .NET, Node.js, Python y en una solución que los combine.
restricciones_duras:
  - R-PO-1  Secciones jerárquicas con índice; definiciones, explicaciones, ejemplos, mermaid cuando haga falta.
  - R-PO-2  Autocontenido, no delta.
  - R-PO-3  Snippets de código representativos y preguntas guía con respuestas explicativas formadoras de criterio.
  - R-PO-4  Descomposición conceptual por núcleos, con documento de cohesión global y fase de integración.
  - R-PO-5  Registros retomables en OUTPUTs/Bitcora.
  - R-PO-6  No inventar información.
  - R-PO-7  Toda afirmación respaldada por evidencia verificable.
  - R-PROF  Profile Study-Guide-Documentation: marco de referencia (escenarios, contextos, actores) fijado una vez y referenciado; estructura temática Definición → Aplicación por escenario → Ejemplos → Preguntas guía → Criterios de calidad → Anexo.
  - R-RULES Rule-Evidences (fuente + fecha de consulta, o comando + salida; criterio propio declarado como tal), Rule-Narrative-Voice (una sola voz, español rioplatense), Rule-Dual-Audience (frontmatter, IDs estables, diagramas como código, snippets con procedencia), Rule-Markdown, Rule-Documentation, Rule-Indexing.
  - R-PRIV  Ningún nombre de repositorio, proyecto, cliente ni identificador del caso privado; el caso se reproduce con un ejemplo sintético.
  - R-EVID  Fuentes primarias (documentación oficial o estándar) con fecha de consulta, o experimento E1 en contenedor con comando y salida. Versiones, defaults y deprecaciones se verifican en la fuente vigente al 2026-10-07; el conocimiento previo del modelo no cuenta como evidencia.
  - R-ESCR  Escritura permitida sólo en la bitácora, la guía, Examples/ y (agente encargado) OUTPUTs/Metodlogia-Entorno-Desarrollo.md. Sin commit ni push. El prompt del PO no se toca.
  - R-HOST  No hay dotnet en el host: toda compilación .NET corre en contenedor (mcr.microsoft.com/dotnet/sdk:8.0 o :10.0).
decisiones_cerradas:
  - DC-01  El entregable es UN solo .md en la ruta del objeto. Las piezas que el Profile pide como documentos separados (marco de referencia, mapa conceptual, documentos por tema, anexos, README) se materializan como secciones y anexos de ese archivo; el «README» es el índice inicial con ruta de lectura.
  - DC-02  Los tres ecosistemas obligatorios son .NET, Node.js y Python, más su combinación en una sola solución. Otros (Java, Go, Rust) quedan fuera salvo como contraste de una línea con fuente.
  - DC-03  La composición mínima de la mesa la fija el PO: didáctica, edición de material bibliográfico, senior .NET, arquitectura de software y desarrolladores. La mesa de convocatoria evalúa sumar especialistas (ver §4); no puede quitar ninguno de los cinco.
  - DC-04  La mesa relee el documento terminado y corrige edición, compresión y coherencia (pedido literal del PO): hay al menos un ciclo de relectura integral posterior a la integración.
  - DC-05  El caso disparador se presenta genéricamente y se reproduce con un ejemplo sintético en Examples/ (R-PRIV).
  - DC-06  El laboratorio Examples/ lleva un .gitignore que excluye bin/, obj/, node_modules/, .venv/, __pycache__/.
  - DC-07  Las unidades de trabajo son los núcleos N0–N8 de 01-Descomposicion-Conceptual.md; su cohesión y la trazabilidad pedido → núcleo → sección están en 02-Cohesion-Global.md.
fuera_de_alcance:
  - Otras guías de LAB/Lab-Documentos (GitFlow, Despliegue, Dot-NET-Arquitectura-Guide, …): se pueden enlazar, no editar.
  - Cualquier archivo de LAB/Lab-Documentos fuera de Guides/Metodologia-Entorno-Desarrollo/ (hay cambios ajenos sin commitear).
  - El repositorio privado del caso y su corrección real.
  - Despliegue y operación en producción (orquestadores, hosting); la guía termina en el artefacto construido y su procedencia.
  - Comparativas comerciales de productos de CI o de registros de artefactos más allá de lo necesario para un ejemplo.
  - Recomendar una herramienta única «para todo»: la guía forma criterio por contexto.
umbral_de_calidad: S1 y S2 bloquean el cierre.
presupuesto: { ciclos_max: 3, hallazgos_max_por_especialista: 7 }
```

## 3. Definiciones del contrato aplicadas a una guía

La escala de evidencia del marco (§3) se traduce así para un objeto documental:

| Nivel | En esta guía significa |
|---|---|
| E1 | Experimento en contenedor reproducible desde `Examples/`, con comando y salida capturados (p. ej. compilar un `.cs` en cp1252 con el SDK en Linux y ver el error). Compuertas mecánicas sobre el `.md`: enlaces internos que resuelven, índice coherente, `grep` de identificadores privados en cero. |
| E2 | Cita literal de la guía (sección/línea) o del prompt del PO que muestra contradicción, ambigüedad u omisión. |
| E3 | Escenario construido (por ejemplo, «dev en Windows con VS edita un archivo y el commit cambia el BOM») que la guía no resuelve. |
| E4 | Regla de este contrato (R-PO-*, R-PROF, R-RULES, R-PRIV, R-EVID) o documentación oficial con URL y fecha de consulta. |
| C  | Experiencia general o «suele hacerse»: sólo funda preguntas. Toda afirmación técnica de la bitácora que no tenga todavía fuente se marca **[C: a verificar en N…]**. |

Severidades orientativas para esta guía:

- **S1**: afirmación técnica falsa o sin fuente presentada como hecho; identificador privado filtrado; snippet marcado como ejecutado que no corre; contradicción entre secciones.
- **S2**: un núcleo sin preguntas guía con respuesta, o una recomendación sin el contexto (escenario/ecosistema) en que aplica; ejemplo que un lector en Windows no puede reproducir sin preguntar.
- **S3**: índice o anclas incompletas, mermaid que repite la prosa, terminología no unívoca.
- **S4**: estilo y redacción (Rule-Narrative-Voice).

## 4. Señales para la mesa de convocatoria (inventario, no decisión)

El barrido de señales (§5.1.b) sobre el prompt del PO arroja, con ubicación:

| Señal | Ubicación en el prompt | Rol que sugiere |
|---|---|---|
| «Visual Studio en Windows y al mismo tiempo en entorno Linux… devcontainer» | §Contexto, párr. 2 | Arquitectura; Operación y entrega |
| «congelar nugets y versiones de compiladores, sdk» | §Contexto, párr. 4 | Senior .NET (obligatorio por DC-03); ad hoc cadena de suministro |
| «saber con qué entorno se ensambló esa pieza» | §Contexto, párr. 5 | Operación y entrega; ad hoc procedencia/SLSA |
| «.net, nodejs, python… integran todos estos en una única solución» | §Solicitudes, párr. 1 | Ad hoc Node.js y Python (no cubiertos por los cinco roles del PO) |
| «secciones jerárquicas con índices… preguntas guía» | §Reglas, ítem 1 | Didáctica; Edición (obligatorios por DC-03) |
| «No inventar… evidencia verificable» | §Reglas, ítems 3–4 | Verificación/QA (núcleo permanente) |
| Caso real en repositorio privado | §Contexto, bloque de código | Seguridad y privacidad (filtrado de identificadores) |

Propuesta del analista a la mesa (la mesa vota; criterio propio declarado): sumar como especialistas **DevOps/CI y cadena de suministro** (cubre N5, N6, N8) y un **desarrollador políglota Node.js/Python** (cubre los ecosistemas que el panel del PO no nombra). El «desarrollador de código» que pide el PO se instancia como **implementador ingenuo con estación Windows + Visual Studio**, porque es la perspectiva que el caso disparador demostró frágil.

## 5. Supuestos registrados (sin consultar al PO)

| ID | Supuesto | Motivo |
|---|---|---|
| SUP-01 | «setcode» en el prompt significa *charset/encoding* del código fuente. | Lectura del contexto: el fix trata de cp1252 → UTF-8. |
| SUP-02 | El tratamiento de finales de línea (CRLF/LF) entra en el mismo núcleo que la codificación aunque el PO no lo nombre. | Comparten mecanismo (`.editorconfig`, `.gitattributes`, normalización de git) y el mismo síntoma: diffs cuyo único cambio es invisible. |
| SUP-03 | «Congelar» abarca dos cosas distintas: fijar el toolchain (SDK, runtime, intérprete) y congelar el grafo de dependencias. Se tratan en núcleos separados. | Mecanismos, archivos y fallas distintas; comparten vocabulario (ver N0). |
| SUP-04 | La pregunta «¿se puede hacer con contenedores?» se responde con matices y no con sí/no: el contenedor fija el SO y el toolchain, no fija por sí solo el grafo de dependencias ni la codificación de los archivos. **[C: a verificar en N5]** | Es la hipótesis que la mesa debe confirmar o refutar con E1. |
| SUP-05 | El destino incluye equipos que no pueden imponer devcontainers a todos (Visual Studio en Windows sigue siendo estación válida). | El PO lo plantea como convivencia, no como migración. |
| SUP-06 | Versión de referencia de los ejemplos .NET: SDK 8.0 y 10.0 (imágenes locales disponibles). Node y Python: la versión LTS/estable vigente que la fuente oficial indique al 2026-10-07. | Disponibilidad en el host y R-EVID. |
