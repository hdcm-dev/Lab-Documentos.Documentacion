# Tool-Prompt — Investigación con Mesa Evaluadora: Metodología del entorno de desarrollo

> **Invocación**:
> - ultracode leer y ejecutar `/LAB/Lab-Documentos.Documentacion/PROMPTs/Guides/15-Metodologia-Entorno-Desarrollo/OUTPUTs/Metodlogia-Entorno-Desarrollo.md`
>
> **Prompt de origen (del PO, sólo lectura, no se modifica)**: `/LAB/Lab-Documentos.Documentacion/PROMPTs/Guides/15-Metodologia-Entorno-Desarrollo/Crear-Analizar-Metodlogia-Entorno-Desarrollo.md`
>
> **Marco base**: `/IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` (en adelante, «el marco»; las referencias `§n` del marco se escriben `M§n`).
>
> **Overview**: Investigación. Una mesa evaluadora, armada por caso, investiga qué propone hoy la industria para fijar el entorno de desarrollo —codificación del fuente, toolchain, dependencias, contenedores y procedencia de lo construido— en .NET, Node.js, Python y en una solución que combine los tres; descompone el pedido en núcleos conceptuales, los trabaja con evidencia verificable, los integra en **una sola guía de estudio** y, una vez terminada, la relee entera para corregir edición, compresión y coherencia.
>
> **Fecha de reedición**: 2026-10-07. **Idioma**: español rioplatense, una sola voz de autor.

---

## Índice

- [1. Contexto](#1-contexto)
- [2. Solicitudes](#2-solicitudes)
- [3. Reglas](#3-reglas)
- [4. Framework](#4-framework)
- [5. Contrato de entrada (Fase 0)](#5-contrato-de-entrada-fase-0)
- [6. Descomposición en núcleos conceptuales](#6-descomposición-en-núcleos-conceptuales)
- [7. El caso que se plantea a la mesa](#7-el-caso-que-se-plantea-a-la-mesa)
- [8. Composición del panel](#8-composición-del-panel)
- [9. El ciclo](#9-el-ciclo)
- [10. Relectura integral obligatoria](#10-relectura-integral-obligatoria)
- [11. Dónde va cada salida](#11-dónde-va-cada-salida)
- [12. Escalada al PO](#12-escalada-al-po)
- [13. Criterios de parada y bloque de cierre](#13-criterios-de-parada-y-bloque-de-cierre)
- [14. Prompt de arranque](#14-prompt-de-arranque)
- [15. Trazabilidad con el prompt de origen](#15-trazabilidad-con-el-prompt-de-origen)

---

## 1. Contexto

> El prompt de origen transcribe el comentario literal de un fix hecho en un repositorio **privado** de una organización. Ese texto nombra componentes e identificadores privados y por eso **no se reproduce** acá ni en ninguna salida (regla R-PRIV). El hecho técnico se conserva completo, descripto en forma genérica.

**El caso disparador.** En un sistema .NET heredado de una organización, alrededor de cien archivos `.cs` y `.razor` estaban guardados en Windows-1252 (cp1252) y se convirtieron a UTF-8 con BOM. El motivo: al compilar en Linux, el compilador de C# (Roslyn) los leía como UTF-8; un proyecto de servicios no compilaba porque un identificador contenía un carácter no ASCII, y los textos con acentos salían con `?`. En Windows, el mismo código compilaba y se veía bien: la conversión no cambia nada ahí.

**Por qué pasa.** El código se desarrolla a la vez con Visual Studio en Windows y en entornos Linux, o se construye dentro de devcontainers Linux. Cada entorno aporta por su cuenta lo que el repositorio no declara.

**Las preocupaciones del PO que se derivan del caso**, en el orden en que las plantea:

1. **Codificación unificada.** Cómo mantener un criterio único de codificación (*charset*; el PO escribe «setcode») del código fuente, para no tener commits cuyo único cambio sea el BOM.
2. **Congelar el entorno.** Una mecánica que permita congelar los paquetes NuGet y las versiones de compiladores y SDK. El PO pregunta si esto se puede hacer mediante el desarrollo en contenedores, y cómo se integra en equipos donde los desarrolladores usan herramientas sobre Windows y sobre Linux.
3. **Saber con qué se construyó cada pieza.** El PO lo marca como «super importante»: si se construye una pieza de código, poder saber con qué entorno se ensambló.

---

## 2. Solicitudes

| ID | Solicitud | Fuente en el prompt de origen |
|---|---|---|
| S-01 | Analizar las estrategias que propone la industria actual para los entornos de desarrollo .NET, Node.js y Python. | §Solicitudes, párr. 1 |
| S-02 | Analizar en especial qué sucede cuando esos tres ecosistemas se integran en una única solución. | §Solicitudes, párr. 1 |
| S-03 | Reeditar el prompt sobre el marco de Mesa Evaluadora, a partir del contexto, las reglas, los objetivos y las solicitudes, planteando el caso a la mesa. **Este documento es esa reedición.** | §Solicitudes, párr. 2 |
| S-04 | La mesa está formada por expertos en didáctica, en edición de material bibliográfico, senior en .NET, arquitectos de software y desarrolladores de código, que revisan la documentación generada. | §Solicitudes, párr. 2 |
| S-05 | Analizar si hace falta un experto más. | §Solicitudes, párr. 2 |
| S-06 | La mesa vuelve a analizar el documento una vez finalizado y hace las correcciones pertinentes en edición y compresión, ajustando su coherencia. | §Solicitudes, párr. 2 |
| S-07 | La mesa puede llevar apuntes, borradores, debates y precompilaciones, que después forman parte de la edición del documento final. | §Solicitudes, párr. 2 |
| S-08 | El documento final queda en `/LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md`. | §Solicitudes, párr. 2 |

«Compresión» en S-06 se lee en sus dos sentidos y la mesa atiende ambos: **comprensión** del lector (que se entienda) y **compresión** del texto (que no sobre: repeticiones, rodeos, secciones que dicen dos veces lo mismo). Supuesto registrado como SUP-07 (§5).

---

## 3. Reglas

### 3.1 Reglas del PO (se conservan íntegras)

- **R-PO-1 — Forma.** Los documentos Markdown de documentación se organizan en secciones jerárquicas con índices. Incluyen definiciones, explicaciones, ejemplos claros y, cuando sea necesario, gráficos mermaid.
- **R-PO-2 — Autocontenido.** Son autocontenidos, no delta: el lector no necesita otro documento ni conocer la historia del pedido para entenderlos.
- **R-PO-3 — Formación de criterio.** Llevan ejemplos, explicaciones, snippets de código representativos y preguntas guía acompañadas de respuestas explicativas, formadoras de criterio, que le permitan al lector identificar en qué caso se aplica cada concepto del documento.
- **R-PO-4 — Descomposición conceptual.** Se aplica una estrategia de descomposición conceptual sobre la totalidad del prompt (detalle operativo en §6):
  - identificar y agrupar las ideas con relación temática, semántica o de dependencia fuerte, formando núcleos conceptuales coherentes; no fragmentar por extensión ni por párrafos: la unidad de segmentación la determinan la afinidad y la dependencia entre ideas;
  - abordar el análisis y la planificación por núcleos o ejes temáticos, documentando cada uno en un Markdown independiente, y mantener un documento de cohesión global con las relaciones, dependencias, referencias y vínculos entre núcleos;
  - cada núcleo debe poder analizarse, planificarse y validarse de manera relativamente independiente, sin perder contexto ni relaciones, conservando la trazabilidad necesaria para integrarlo después en una solución global;
  - abordados los núcleos, una fase de integración consolida sus resultados, resuelve dependencias o contradicciones entre ellos y reconstruye el modelo completo;
  - el objetivo es transformar un pedido de gran volumen y complejidad en unidades conceptuales manejables, con cohesión, dependencia y trazabilidad, que se presentan por eje a la mesa evaluadora y planificadora y finalmente se integran en un todo coherente.
- **R-PO-5 — Registros retomables.** Para cumplir R-PO-4 se generan registros Markdown que se puedan retomar y evaluar, en `/LAB/Lab-Documentos.Documentacion/PROMPTs/Guides/15-Metodologia-Entorno-Desarrollo/OUTPUTs/Bitcora`.
- **R-PO-6 — No inventar información.**
- **R-PO-7 — Evidencia.** Toda afirmación debe estar respaldada por evidencia verificable.

### 3.2 Reglas que precisan a las del PO

Estas reglas no agregan exigencias nuevas: hacen operables R-PO-6, R-PO-7 y el entorno de trabajo.

- **R-EVID — Qué cuenta como evidencia.** Una URL de documentación oficial o de un estándar (learn.microsoft.com, docs.npmjs.com, nodejs.org, packaging.python.org, peps.python.org, docs.astral.sh, containers.dev, git-scm.com, editorconfig.org, slsa.dev, reproducible-builds.org, docs.docker.com, unicode.org u otra fuente primaria equivalente) **con fecha de consulta**, o un experimento ejecutado con comando y salida (E1). El conocimiento previo del modelo **no** es evidencia: versiones, valores por defecto, deprecaciones y estados (por ejemplo, de un PEP o de Corepack) se verifican en la fuente vigente a la fecha de trabajo. Lo que es criterio propio se declara como tal en el texto («criterio de la guía: …»).
- **R-PRIV — Privacidad.** Ninguna salida (bitácora, guía, laboratorio) nombra repositorios, proyectos, clientes ni identificadores del caso privado. El caso se describe como en §1 y se **reproduce con un ejemplo sintético propio** en el laboratorio. Una compuerta mecánica (`grep` de una lista de identificadores prohibidos, mantenida sólo en la memoria de la sesión y no escrita en ningún archivo) debe dar cero antes de cada cierre de ciclo.
- **R-ESCR — Dónde se escribe.** Sólo en la bitácora, en la guía final y en el laboratorio `Examples/` (§11). El prompt de origen no se toca. Ningún otro archivo de `LAB/Lab-Documentos` se toca (puede haber cambios ajenos sin commitear). No se hace commit ni push.
- **R-HOST — Dónde se ejecuta.** Los experimentos corren en contenedores con imágenes oficiales (`mcr.microsoft.com/dotnet/sdk`, `node`, `python`), con el directorio del experimento montado: `docker run --rm -v <dir>:/w -w /w <imagen> <comando>`. No se asume ningún SDK instalado en el host.
- **R-AUTO — Autonomía.** No se le pregunta al PO salvo los disparadores cerrados de §12. Ante duda, la mesa decide con criterio y registra el supuesto.

---

## 4. Framework

### 4.1 Profile

Aplicar:
- `/IA/IA.Prompts/PromptFramework/Profiles/Study-Guide-Documentation.md` (se resuelve en `/IA/PROMPTs/IA.Prompts/PromptFramework/Profiles/`).

De ese Profile rigen, en particular: el **marco de referencia** (escenarios, contextos, actores) fijado una vez y referenciado en todo el documento; la estructura de cada tema **Definición → Aplicación por escenario y contexto → Ejemplos → Preguntas guía con respuesta → Criterios de calidad → Plantilla o anexo**; y sus criterios de calidad.

### 4.2 RuleSet y Rules

- RuleSet: `/IA/PROMPTs/IA.Prompts/PromptFramework/RuleSets/RuleSet-Study-Guide.md`.
- Rules, en `/IA/PROMPTs/IA.Prompts/PromptFramework/Rules/`: Rule-Evidences, Rule-Narrative-Voice, Rule-Dual-Audience, Rule-Markdown, Rule-Documentation, Rule-Indexing.

### 4.3 Marco de mesa

`/IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` rige el ciclo completo. El objeto que el marco imagina es una especificación de software (spec → plan → tareas → código); acá el objeto es una **guía de estudio** con su laboratorio. La traducción de cada concepto del marco a este objeto está en §5 y §9. Donde este prompt se aparta del marco, lo dice y lo justifica (ver «apartamientos» en §8.4 y §13).

### 4.4 Precedencia

Cuando dos fuentes normativas chocan: (1) reglas del PO (§3.1), (2) reglas que las precisan (§3.2), (3) Profile, RuleSet y Rules, (4) el marco de mesa. Un choque entre (1) y (2) que no se resuelva leyendo ambas es disparador de escalada (§12, tipo 2).

---

## 5. Contrato de entrada (Fase 0)

El contrato instanciado vive en la bitácora: `OUTPUTs/Bitcora/00-Contrato-De-Entrada.md` (doc_id `BIT-15-00`). Es la fuente de verdad del contrato; lo que sigue es su resumen operativo. Si un ciclo lo modifica, se modifica allá y se registra el cambio en el changelog.

```yaml
objeto:
  artefacto: guía de estudio + laboratorio de ejemplos ejecutables
  ruta/id: /LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md
  version: "0 al inicio (archivo inexistente o vacío); cada ciclo registra sha256 y cantidad de líneas"
  capas: # de origen a derivada; un defecto se repara en la capa donde nace (M§1.1)
    - pedido: prompt del PO (sólo lectura) + este prompt reeditado
    - núcleos: OUTPUTs/Bitcora/1N-*.md (análisis, fuentes y experimentos por núcleo)
    - laboratorio: /LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Examples/
    - guía: el .md final, que cita núcleos (por su contenido) y laboratorio (por ruta)
objetivo: >
  Que un lector sin contexto previo entienda por qué el mismo código se comporta distinto en
  Windows, Linux y contenedores, y forme criterio para fijar, por capas, la codificación del
  fuente, el toolchain, las dependencias, el entorno de construcción y la procedencia de lo
  construido, en .NET, Node.js, Python y en una solución que los combine.
restricciones_duras: [R-PO-1..7, R-EVID, R-PRIV, R-ESCR, R-HOST, R-AUTO, Profile, RuleSet, Rules]
decisiones_cerradas:
  - DC-01 Un solo .md de entrega. Las piezas que el Profile pide como documentos separados
          (marco de referencia, mapa conceptual, temas, anexos, README) son secciones y anexos
          de ese archivo; el «README» es el índice inicial con ruta de lectura.
  - DC-02 Ecosistemas obligatorios: .NET, Node.js, Python y su combinación. Otros (Java, Go,
          Rust) sólo como contraste de una línea con fuente.
  - DC-03 Los cinco perfiles del PO (didáctica, edición bibliográfica, senior .NET, arquitectura,
          desarrollo) integran la mesa siempre. La convocatoria puede sumar; no puede quitar.
  - DC-04 Hay al menos un ciclo de relectura integral posterior a la integración (§10).
  - DC-05 El caso se presenta en forma genérica y se reproduce con un ejemplo sintético.
  - DC-06 Examples/ lleva un .gitignore que excluye bin/, obj/, node_modules/, .venv/, __pycache__/.
  - DC-07 Las unidades de trabajo son los núcleos N0–N8 (§6); su cohesión está en BIT-15-02.
fuera_de_alcance:
  - Otras guías de LAB/Lab-Documentos: se pueden enlazar, no editar.
  - El repositorio privado del caso y su corrección real.
  - Despliegue y operación en producción: la guía termina en el artefacto construido y su procedencia.
  - Comparativas comerciales de productos de CI o de registros de artefactos más allá de un ejemplo.
  - Recomendar una herramienta única «para todo»: la guía forma criterio por contexto.
umbral_de_calidad: S1 y S2 bloquean el cierre
presupuesto: { ciclos_max: 3, hallazgos_max_por_especialista: 7 }
```

**Supuestos registrados** (detalle en BIT-15-00 §5): SUP-01 «setcode» = codificación del fuente; SUP-02 los finales de línea (CRLF/LF) entran con la codificación porque comparten mecanismo y síntoma; SUP-03 «congelar» abarca dos capas distintas, toolchain y grafo de dependencias; SUP-04 la respuesta a «¿se puede con contenedores?» es matizada y se valida con E1; SUP-05 Visual Studio en Windows sin contenedor sigue siendo una estación legítima; SUP-06 versiones de referencia: SDK .NET 8.0 y 10.0, Node y Python en la versión vigente que indique su fuente oficial a la fecha; **SUP-07** «compresión» en S-06 abarca comprensión del lector y economía del texto.

### 5.1 Escala de evidencia aplicada a una guía (M§3)

| Nivel | En esta guía significa | Puede fundar |
|---|---|---|
| E1 | Experimento en contenedor reproducible desde `Examples/`, con comando y salida capturados; o compuerta mecánica sobre el `.md` (enlaces internos, índice, `grep` de privacidad, mermaid que renderiza). | corrección |
| E2 | Cita literal de la guía o del pedido, con sección y línea, que muestra contradicción, ambigüedad u omisión. | corrección |
| E3 | Escenario construido que la guía no resuelve (p. ej., «dev en Windows con Visual Studio guarda un archivo y el commit cambia el BOM»). | corrección |
| E4 | Regla del contrato (R-*, Profile, Rules) o documentación oficial con URL y fecha de consulta. | corrección |
| C | Experiencia general, «suele hacerse». En la bitácora se marca **[C: a verificar en N…]**. | sólo una pregunta |

Un hallazgo C que no asciende en dos ciclos se descarta y se registra como descartado (M§3).

### 5.2 Severidades aplicadas a una guía (M§3)

- **S1**: afirmación técnica falsa o sin fuente presentada como hecho; identificador privado filtrado; snippet presentado como ejecutado que no corre; contradicción entre secciones.
- **S2**: núcleo sin preguntas guía con respuesta; recomendación sin el escenario o contexto donde aplica; ejemplo que un lector en Windows (o en Linux) no puede reproducir sin preguntar.
- **S3**: índice o anclas incompletas; mermaid que repite la prosa; término usado con dos sentidos; párrafo redundante.
- **S4**: estilo y redacción (Rule-Narrative-Voice). No pasa por jurado: se aplica o descarta en lote.

---

## 6. Descomposición en núcleos conceptuales

### 6.1 Regla

La descomposición pedida en R-PO-4 ya se ejecutó sobre la totalidad del prompt y está en la bitácora. El criterio de corte fue el **mecanismo** (mismos archivos de configuración y misma herramienta que los lee) y el **modo de falla** (mismo síntoma cuando faltan): dos ideas van juntas si comparten ambos; se separan si se pueden fijar, probar y romper por separado.

| ID | Núcleo | Responde a | Depende de |
|---|---|---|---|
| N0 | Modelo de capas del entorno y vocabulario de reproducibilidad | preocupaciones 2 y 3; univocidad de «congelar» | — |
| N1 | Codificación de texto y finales de línea: el fenómeno (incluye la reproducción sintética del caso) | preocupación 1 | N0 |
| N2 | Política de texto del repositorio y remediación de código heredado | preocupación 1 | N1 |
| N3 | Fijación del toolchain (SDK, compilador, runtime, intérprete, gestor de paquetes) | preocupación 2 | N0 |
| N4 | Congelamiento de dependencias (NuGet, npm/pnpm/Yarn, pip/uv/Poetry) | preocupación 2 | N0, N3 |
| N5 | Entornos en contenedores y convivencia con estaciones Windows | preocupación 2 («¿con contenedores?») | N1–N4 |
| N6 | Procedencia y trazabilidad de la pieza construida | preocupación 3 | N3–N5 |
| N7 | Compuertas, gobierno y actualización controlada | «mantener un criterio», «mecánica» | N2, N3, N4, N6 |
| N8 | Integración políglota en una única solución — **fase de integración** | S-02 | N1–N7 |

Alcance, preguntas que responde cada núcleo, decisiones de segmentación y plan de validación: `BIT-15-01` (`01-Descomposicion-Conceptual.md`). Grafo de dependencias, qué entrega cada núcleo a los demás, contradicciones previsibles, trazabilidad pedido → núcleo → sección y estructura prevista de la guía: `BIT-15-02` (`02-Cohesion-Global.md`). Escenarios ESC-01…05, contextos CTX-NET/NODE/PY/POLI y actores ACT-DEV/ARQ/OPS/REV: `BIT-15-03` (`03-Marco-De-Referencia.md`).

### 6.2 Registro obligatorio por núcleo

Cada núcleo tiene **un Markdown independiente** en la bitácora, `1N-<slug>.md` (por ejemplo `10-N0-modelo-de-capas-y-reproducibilidad.md`, …, `18-N8-integracion-poliglota.md`), con frontmatter (Rule-Dual-Audience: `doc_id`, `status`, `last_review`, `traces`) y estas secciones:

1. **Alcance y preguntas** (copiadas de BIT-15-01, ajustadas si la investigación las corrige).
2. **Fuentes consultadas**: URL, fecha de consulta y qué afirmación sostiene cada una.
3. **Experimentos**: ruta en `Examples/`, comando exacto, salida capturada, versión de la imagen (etiqueta y, cuando se fija, digest).
4. **Hallazgos [C] resueltos**: cada marca `[C: a verificar]` de BIT-15-01 con su resolución (confirmada con evidencia, corregida o descartada).
5. **Borrador de la sección de la guía**, con la estructura del Profile.
6. **Validación del núcleo**: resultado del plan de validación de BIT-15-01 §4 y veredicto de la mesa sobre ese núcleo.
7. **Entregas a otros núcleos y deudas** (qué hereda quién, qué queda abierto).

Un núcleo está **validado** cuando su plan de validación pasó, no quedan marcas `[C]` sin resolver en su borrador y la mesa no tiene hallazgos S1/S2 abiertos sobre él.

### 6.3 Fase de integración

N8 es la integración: consolida N1–N7 en la solución políglota, resuelve las tensiones previstas en BIT-15-02 §4 (por ejemplo, una política de BOM elegida para C# que no conviene a scripts de shell o a Python) y reconstruye el modelo completo. **Si una tensión obliga a cambiar la recomendación de un núcleo anterior, el cambio se hace en el núcleo de origen** (M§1.1) y se marcan como «a revalidar» N8 y las secciones de la guía que derivan de él (M§1.2). El cuaderno de integración vive en `Bitcora/19-Integracion.md`.

---

## 7. El caso que se plantea a la mesa

> **A la mesa.** Un equipo desarrolla el mismo código con Visual Studio en Windows, en Linux y en devcontainers. Un sistema .NET heredado, con unos cien archivos en cp1252, compila en Windows y falla en Linux: un identificador no ASCII rompe la compilación y los literales con acento se corrompen. El PO quiere tres cosas: un criterio de codificación unificado que no produzca commits de BOM, una mecánica para congelar SDK, compiladores y paquetes —y saber si los contenedores lo resuelven en un equipo mixto Windows/Linux—, y poder saber después con qué entorno se construyó cada pieza. Pide, además, que eso se analice frente a lo que hoy propone la industria para .NET, Node.js y Python, y en especial para una solución que los combine.
>
> La mesa debe producir **una guía de estudio** que forme criterio, no un manual de una herramienta. Cada afirmación técnica lleva fuente primaria con fecha o un experimento reproducible. La guía recorre los núcleos N0–N8, termina en una integración políglota coherente y, una vez terminada, la mesa la vuelve a leer completa para corregir edición, compresión y coherencia.
>
> Preguntas que la mesa tiene que poder responder con evidencia al cerrar:
> 1. ¿Por qué el mismo fuente compila distinto en Windows y en Linux, y qué hace con el BOM cada lector (compilador de C#, Razor, Node.js, Python, git, editores)?
> 2. ¿Qué política de texto declara el repositorio, en qué archivos, quién la lee y cómo se verifica? ¿Cómo se migra un código heredado sin ensuciar la historia?
> 3. ¿Qué capas del entorno fija cada mecanismo (archivo de versión del SDK, lock file, imagen de contenedor) y cuáles deja abiertas?
> 4. ¿Resuelven los contenedores el problema en un equipo mixto? ¿Qué sí, qué no y qué tiene que ser idéntico entre una estación Windows sin contenedor y un devcontainer?
> 5. ¿Qué tiene que viajar con un artefacto para saber con qué entorno se construyó, y cómo se demuestra (builds deterministas, SBOM, procedencia)?
> 6. ¿Qué mecánica sostiene todo eso en el tiempo (compuertas locales iguales a las de CI, revisión de PR, actualización controlada)?
> 7. ¿Qué se rompe primero cuando .NET, Node.js y Python conviven en una sola solución, y cómo se fija todo desde un punto de verdad?

---

## 8. Composición del panel

La composición la decide la mesa de convocatoria (M§5.1) y **no** se eleva al PO. Este apartado fija lo que no se discute (núcleo permanente y perfiles del PO) y presenta el análisis de S-05 como propuesta que la mesa vota.

### 8.1 Núcleo permanente del marco (M§4.1.1, siempre)

| Rol | Pregunta que responde en esta guía |
|---|---|
| **Requisitos** | ¿Cada solicitud S-01…S-08, cada preocupación del PO y cada pregunta de §7 tiene una sección que la responde? ¿Cada sección declara en qué escenario y contexto aplica? |
| **Verificación / QA** | ¿Cada afirmación técnica tiene fuente con fecha o experimento? ¿Cada experimento corre como dice desde `Examples/`? Corre las compuertas mecánicas (§9.1). |
| **Implementador ingenuo** | ¿Un lector que no participó puede seguir la guía y reproducir cada ejemplo sin preguntar nada? Cada pregunta que necesita hacer es un hallazgo. |
| **Abogado del diablo** | Ataca la recomendación dominante de cada núcleo (por ejemplo, «UTF-8 con BOM para todo» o «el devcontainer lo resuelve»). Entra después de leer al resto. |

### 8.2 Perfiles pedidos por el PO (DC-03, siempre)

| Perfil del PO | Cómo se instancia | Juzga | No le corresponde |
|---|---|---|---|
| **Didáctica** | Especialista variable con mandato fijo | Marco de referencia, progresión §1→§11 de la guía, calidad de las preguntas guía y de sus respuestas como formadoras de criterio (R-PO-3), adecuación al lector. | Corrección técnica. |
| **Edición de material bibliográfico** | Especialista variable con mandato fijo | Estructura jerárquica e índices (R-PO-1, Rule-Indexing), autocontención (R-PO-2), voz única (Rule-Narrative-Voice), aparato de referencias y fechas de consulta (Rule-Evidences), compresión del texto. | Corrección técnica. |
| **Senior .NET** | Especialista variable con mandato fijo | N1 (Roslyn, MSBuild, Razor), N3 (`global.json`), N4 (NuGet: lock file, gestión central, fuentes), N6 (build determinista, SourceLink), lado .NET de N8. | Node.js, Python. |
| **Arquitectura de software** | Rol de catálogo (M§4.1.2) con señal presente: más de un componente e integración entre ecosistemas (§Solicitudes, párr. 1) | N0 (modelo de capas), N5, N8, coherencia del modelo entre núcleos, puntos de verdad únicos. | Detalle de comandos por ecosistema. |
| **Desarrollador de código** | Se funde con el **implementador ingenuo** del núcleo y se le asigna una estación concreta: **Windows con Visual Studio**, porque es la perspectiva en la que el caso disparador demostró ser frágil. Un segundo desarrollador, con estación Linux/devcontainer, lo instancia la mesa si lo vota (§8.3). | Reproducibilidad de cada ejemplo desde su estación; claridad de los pasos. | Decisiones de política. |

### 8.3 Análisis de S-05: ¿hace falta otro experto?

El barrido de señales (M§5.1.b) sobre el pedido arroja estas señales que **ninguno de los cinco perfiles del PO cubre**. Para cada una, la propuesta a la mesa de convocatoria (criterio del analista, la mesa vota):

| Señal (con ubicación) | Hueco que deja el panel del PO | Propuesta |
|---|---|---|
| «.net, nodejs, python … integran todos estos en una única solución» (§Solicitudes, párr. 1) | Nadie con competencia en Node.js ni en Python: el senior es de .NET. | `INSTANCIAR_AD_HOC` **AH-01 Desarrollador políglota Node.js/Python**. |
| «congelar nugets y versiones de compiladores, sdk» y «saber con qué entorno se ensambló esa pieza» (§Contexto, párr. 4 y 5) | Imágenes, CI, SBOM, procedencia SLSA y atestaciones no son de arquitectura ni de .NET. | `CONVOCAR` el rol de catálogo **Operación y entrega**, instanciado con carta de mandato como **AH-02 DevOps y cadena de suministro**. |
| «al mismo tiempo en entorno linux … devcontainer» (§Contexto, párr. 2) | El implementador ingenuo tiene estación Windows; falta la perspectiva opuesta. | `INSTANCIAR_AD_HOC` **AH-03 Desarrollador con estación Linux/devcontainer**. |
| Caso real en repositorio privado (§Contexto, bloque de código) | Riesgo de filtrar identificadores. | `NO_CONVOCAR` el rol de catálogo Seguridad y privacidad: lo cubre una compuerta mecánica E1 (§9.1, `grep` en cero) a cargo de Verificación. Se registra el motivo; si aparece una filtración, el registro corrige el criterio. |
| «No inventar… evidencia verificable» (§Reglas) | — | Cubierto por Verificación/QA (núcleo). No suma rol. |

**Cartas de mandato de los ad hoc propuestos** (M§4.1.3). Sin carta aprobada, sus salidas se descartan.

```yaml
agente_ad_hoc:
  id: AH-01
  nombre: Desarrollador políglota Node.js / Python
  señal_que_lo_justifica: { descripción: "pedido explícito de Node.js y Python y de su integración con .NET", ubicación: "prompt de origen §Solicitudes, párr. 1" }
  pregunta_que_responde: ¿Lo que la guía afirma sobre Node.js y Python (lectura de texto, fijación de runtime y gestor, lock files, metadatos de build) es correcto y vigente, y es equivalente en rigor a lo que dice de .NET?
  competencia: Node.js (nodejs.org, docs.npmjs.com, pnpm, Yarn, Corepack), Python (peps.python.org, packaging.python.org, docs.astral.sh, Poetry, pip-tools). NO opina sobre .NET, didáctica ni forma.
  evidencia_admisible: [E1, E2, E3, E4]
  tope_hallazgos: 5
  se_disuelve_cuando: N1, N3, N4, N6 y N8 validados en su parte Node/Python y cerrada la relectura integral.
```

```yaml
agente_ad_hoc:
  id: AH-02
  nombre: DevOps y cadena de suministro
  señal_que_lo_justifica: { descripción: "congelar SDK/compiladores/paquetes; saber con qué entorno se ensambló la pieza; devcontainers", ubicación: "prompt de origen §Contexto, párr. 2, 4 y 5" }
  pregunta_que_responde: ¿Lo que la guía propone para imágenes, devcontainers, compuertas de CI, SBOM y procedencia es correcto, vigente y alcanzable para un equipo chico?
  competencia: Docker y Dev Containers (docs.docker.com, containers.dev), CI genérica, SBOM (SPDX, CycloneDX), SLSA (slsa.dev), reproducible-builds.org. NO opina sobre detalles de lenguaje ni sobre didáctica.
  evidencia_admisible: [E1, E2, E3, E4]
  tope_hallazgos: 5
  se_disuelve_cuando: N5, N6 y N7 validados y cerrada la relectura integral.
```

```yaml
agente_ad_hoc:
  id: AH-03
  nombre: Desarrollador con estación Linux / devcontainer
  señal_que_lo_justifica: { descripción: "el equipo trabaja también en Linux y en devcontainers", ubicación: "prompt de origen §Contexto, párr. 2" }
  pregunta_que_responde: ¿Cada ejemplo de la guía se puede reproducir, tal como está escrito, desde Linux nativo y desde un devcontainer, sin preguntar nada?
  competencia: reproducir pasos en shell Linux y en contenedor. NO opina sobre política, didáctica ni corrección conceptual.
  evidencia_admisible: [E1, E3]
  tope_hallazgos: 5
  se_disuelve_cuando: cerrada la relectura integral.
```

### 8.4 Techo del panel: apartamiento declarado

El marco fija un techo de núcleo + 5 variables/ad hoc por ciclo (M§4.1.4). Este caso tiene 4 perfiles variables impuestos por el PO (didáctica, edición, senior .NET, arquitectura) más hasta 3 ad hoc propuestos (AH-01…03): 7 en total. **Apartamiento:** los perfiles del PO son restricción dura (E4: DC-03) y no consumen cupo; el techo de 5 rige para los que entran por señal. Con 3 propuestos, hay cupo para 2 más por convocatoria en caliente (M§5.2). El apartamiento se informa en el bloque de cierre (`apartamientos_del_marco`).

### 8.5 Mesa de convocatoria

Los 5 jueces (§9.4) votan cada especialidad propuesta en §8.3 con `CONVOCAR`, `NO_CONVOCAR` o `INSTANCIAR_AD_HOC` (sobre la carta, no sobre la idea). Mayoría simple; ante empate se convoca. El registro completo —convocados, descartados con motivo, postergados— va a `Bitcora/20-Convocatoria.md` y se contrasta al cierre contra los hallazgos reales (M§5.1.c).

---

## 9. El ciclo

### 9.1 Base mecánica (antes de cualquier agente, y de nuevo después de cada aplicación)

Los cinco chequeos de coherencia del marco (M§3) traducidos a una guía. Lo que falla entra como S1 con evidencia E1.

| # | Chequeo del marco | En esta guía | Cómo se corre |
|---|---|---|---|
| C1 | Sin afirmaciones contradictorias | Ninguna recomendación de un núcleo contradice a otra; las tensiones de BIT-15-02 §4 están resueltas en N8. | Lectura cruzada guiada por la tabla de tensiones. |
| C2 | Todo requisito con ID, criterio y prueba | Toda solicitud S-01…S-08 y toda pregunta de §7 tiene sección; toda afirmación técnica tiene fuente con fecha o experimento. | Tabla de trazabilidad de BIT-15-02 §5 + búsqueda de marcas `[C:` (deben ser cero en la guía). |
| C3 | Toda tarea referencia un requisito | Toda sección de la guía responde a una solicitud o a un núcleo (no hay secciones huérfanas). | Tabla de trazabilidad inversa. |
| C4 | Sin requisitos ni tareas huérfanos | Todo núcleo N0–N8 tiene sección, preguntas guía con respuesta y al menos un ejemplo; todo directorio de `Examples/` es citado por la guía y toda cita apunta a un directorio existente. | Script de enlaces sobre el `.md` y listado de `Examples/`. |
| C5 | Glosario unívoco | Cada término del glosario (anexo) se usa con un solo sentido; en especial *fijar*, *congelar*, *reproducible*, *determinista*, *hermético*. | Búsqueda de cada término y revisión de sus usos. |

Compuertas adicionales, también E1: anclas internas que resuelven; índice coherente con los encabezados; bloques mermaid que renderizan; `grep` de identificadores privados en cero (R-PRIV); `Examples/.gitignore` presente con las cinco exclusiones (DC-06).

### 9.2 Trabajo por núcleo

En el orden de BIT-15-02 §7 (N0; N1 y N3 en paralelo; N2 y N4; N5; N6; N7; N8 como integración), cada núcleo:

1. **Investigación.** Resuelve cada marca `[C]` contra la fuente primaria vigente y corre los experimentos de su plan de validación en contenedor, guardando el experimento en `Examples/` y su salida en el registro del núcleo.
2. **Borrador.** Redacta la sección de la guía en el registro del núcleo (§6.2, punto 5).
3. **Panel a ciegas** (M§5.2) sobre ese núcleo: cada especialista convocado cuyo mandato lo alcanza emite hasta 7 hallazgos (esquema M§8) y hasta 3 ítems de «lo que revisé y está bien», sin ver los informes de los demás. Fuera de su mandato no opina: emite una solicitud de convocatoria. Una sola ronda de convocatoria en caliente por ciclo.
4. **Relator**, **jurado**, **auditores**, **aprobación**, **aplicación y verificación**: §9.3–§9.7.

Los núcleos que no dependen entre sí pueden recorrer el ciclo en paralelo. El ciclo 1 termina cuando N0–N8 están validados e integrados en la guía.

### 9.3 Relator (consolida, no vota)

Deduplica, agrupa por raíz común, detecta contradicciones **entre especialistas** (por ejemplo, el senior .NET recomienda BOM y AH-01 lo desaconseja para Python) y las eleva como ítem separado. No edita hallazgos. Salida: `Bitcora/22-Relatoria-Ciclo-<n>.md`.

### 9.4 Jurado de cinco (M§4.3)

Funciones objetivo fijas, iguales para todos los núcleos: **evidencia**, **impacto** (qué le pasa al lector si no se corrige), **costo/beneficio**, **coherencia histórica** (¿reabre una decisión cerrada?, ¿es consistente con veredictos previos?) y **riesgo e irreversibilidad**. Votan **por hallazgo**: `PROCEDE`, `NO_PROCEDE` o `INSUFICIENTE` (vuelve una vez al especialista con un pedido concreto). Quórum 5; mayoría ≥3; empate en primera ronda → `INSUFICIENTE`; empate en segunda → escalada (§12, tipo 6). Veto acotado del juez de riesgo sólo ante corrección irreversible y severidad ≤ S3. Cada voto lleva una línea de fundamento; sin fundamento no cuenta. Si el jurado necesita conocimiento técnico, llama como **perito** al especialista que emitió el hallazgo: responde, no vota. Si el jurado vota 5-0 en más del 80 % de los ítems, el ciclo se marca sospechoso de homogeneidad y el abogado del diablo revisa los `NO_PROCEDE` (M§9). Salida: `Bitcora/23-Veredictos-Ciclo-<n>.md`.

### 9.5 Cuerpo auditor (diseña, no aprueba)

Por hallazgo `PROCEDE`, un parche con: texto exacto a reemplazar o agregar, **capa** donde se aplica (pedido, núcleo, laboratorio o guía), derivados a revalidar, criterio de verificación y plan de reversión. Parches que tocan la misma sección se fusionan antes de aprobarse. Salida: `Bitcora/24-Parches-Ciclo-<n>.md`.

### 9.6 Aprobación (M§5.5): cuatro resultados

- `APLICAR`.
- `MEJORAR_PLAN`: el hallazgo vale, el parche no; vuelve a auditoría con la objeción concreta (máximo 2 vueltas).
- `NO_APLICAR`: el costo o el riesgo del parche supera al del defecto; el defecto se registra como **deuda declarada**.
- `ESCALAR`: §12.

Chequeo obligatorio antes de aplicar: **¿el parche corrige en la capa donde nació el defecto?** Una afirmación falsa en la guía que viene de un núcleo mal investigado se corrige primero en el registro del núcleo (y en su experimento, si corresponde) y después se propaga a la guía; no se parchea sólo la guía. Los auditores argumentan, no votan su propio parche.

### 9.7 Aplicación y verificación

Se aplica, se corre el criterio de verificación de cada parche (re-ejecutar el experimento afectado, re-correr el chequeo que falló) y se re-corren las compuertas de §9.1. Si una verificación falla, se revierte ese parche y su hallazgo vuelve a auditoría marcado `regresión`. Changelog: hallazgo → veredicto → parche → verificación → versión nueva (sha256 y líneas de la guía), en `Bitcora/25-Changelog.md`.

---

## 10. Relectura integral obligatoria

Pedido literal del PO (S-06, DC-04): **una vez finalizado el documento, la mesa lo vuelve a analizar completo y hace las correcciones pertinentes en edición y compresión, ajustando su coherencia.** No se reemplaza por las revisiones por núcleo: es un ciclo propio (ciclo 2) sobre la guía integrada, leída de punta a punta como la leerá el lector.

- **Panel**: todo el panel convocado (núcleo permanente + perfiles del PO + ad hoc vigentes), a ciegas, sobre la guía entera.
- **Foco**, además de los mandatos de cada rol:
  - **Edición**: jerarquía e índices, voz única, uniformidad de formato de snippets, tablas y referencias, anexo de referencias completo con fechas.
  - **Compresión** (SUP-07): que se entienda —definiciones antes del uso, ejemplos que iluminan, preguntas guía cuyas respuestas forman criterio— y que no sobre —repeticiones entre secciones, párrafos que dicen dos veces lo mismo, mermaid que duplica la prosa—. Recortar redundancia **no** autoriza recortar evidencia ni citas: una cita entra con su explicación.
  - **Coherencia**: los cinco chequeos de §9.1 sobre la guía completa, terminología única, recomendaciones que no se contradicen entre secciones, el marco de referencia usado igual en todas.
- **Correcciones**: siguen el mismo jurado → auditoría → aprobación → verificación. Si la corrección nace en un núcleo, se repara allá y se propaga (§9.6).
- **Ciclo 3** sólo si la relectura no cumplió el criterio de rendimientos decrecientes (§13).
- Salida: `Bitcora/26-Relectura-Integral.md` (informes, veredictos, parches y verificación de este ciclo).

---

## 11. Dónde va cada salida

Raíces: `BIT = /LAB/Lab-Documentos.Documentacion/PROMPTs/Guides/15-Metodologia-Entorno-Desarrollo/OUTPUTs/Bitcora`, `GUIA = /LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo`.

| Salida | Ubicación | Notas |
|---|---|---|
| Contrato de entrada | `BIT/00-Contrato-De-Entrada.md` | existente; se actualiza allá |
| Descomposición conceptual | `BIT/01-Descomposicion-Conceptual.md` | existente |
| Cohesión global | `BIT/02-Cohesion-Global.md` | existente; se actualiza al integrar |
| Marco de referencia | `BIT/03-Marco-De-Referencia.md` | existente |
| Registro por núcleo (N0–N8) | `BIT/10-N0-<slug>.md` … `BIT/18-N8-<slug>.md` | estructura de §6.2 |
| Cuaderno de integración | `BIT/19-Integracion.md` | tensiones resueltas y reparaciones en origen |
| Registro de convocatoria | `BIT/20-Convocatoria.md` | votos por especialidad, cartas aprobadas, descartes y postergados |
| Informes del panel (verbatim) | `BIT/21-Informes-Panel-Ciclo-<n>.md` | uno por ciclo; cada informe con su rol |
| Relatoría | `BIT/22-Relatoria-Ciclo-<n>.md` | |
| Veredictos | `BIT/23-Veredictos-Ciclo-<n>.md` | votos con fundamento |
| Parches | `BIT/24-Parches-Ciclo-<n>.md` | |
| Changelog | `BIT/25-Changelog.md` | |
| Relectura integral | `BIT/26-Relectura-Integral.md` | |
| Apuntes, debates, precompilaciones | `BIT/27-Debates-y-Apuntes.md` (o archivos `27-*` por tema) | S-07: insumo de edición, no entregable |
| Escaladas | `BIT/28-Escaladas.md` | sólo si hay |
| Bloque de cierre | `BIT/29-Cierre.md` | §13 |
| Experimentos ejecutables | `GUIA/Examples/<NN>-<núcleo>-<tema>/` | cada uno con su comando de contenedor; el `README.md` del laboratorio indica cómo correr todos |
| Exclusiones del laboratorio | `GUIA/Examples/.gitignore` | `bin/`, `obj/`, `node_modules/`, `.venv/`, `__pycache__/` |
| **Guía final (único entregable)** | `GUIA/Metodologia-Entorno-Desarrollo-Guide.md` | un solo `.md`, estructura de BIT-15-02 §6 |

Reglas de las salidas: la guía no referencia la bitácora (es autocontenida, R-PO-2) y sí referencia `Examples/` con rutas relativas a sí misma; la bitácora sí referencia la guía y el laboratorio. Nada de lo escrito contiene identificadores del caso privado. Toda la bitácora lleva frontmatter con `doc_id` estable.

---

## 12. Escalada al PO

**Regla general: la mesa decide sola** (R-AUTO). La composición del panel, la redacción, la estructura, la elección entre alternativas técnicas dentro de las restricciones, el orden de los núcleos y el contenido de los ejemplos **nunca** se escalan.

Se escala si y sólo si aparece uno de los siete disparadores del marco (M§6), leídos para este caso:

| # | Disparador | Ejemplo en este caso |
|---|---|---|
| 1 | Ambigüedad de intención irresoluble por evidencia | El pedido admite dos destinatarios incompatibles de la guía y ninguna evidencia desempata. |
| 2 | Conflicto entre restricciones duras | R-PRIV impide mostrar algo que R-PO-7 exige evidenciar y el ejemplo sintético no alcanza. **Bloquea y sale en el momento.** |
| 3 | Cambio de alcance | La guía tendría que incluir despliegue en producción u otro ecosistema para responder una solicitud. **Bloquea y sale en el momento.** |
| 4 | Irreversibilidad con impacto real | Cualquier acción que toque fuera de las rutas de R-ESCR (por ejemplo, convertir archivos reales de otra guía). |
| 5 | Dominio con consecuencia externa | Publicar algo que exponga datos de terceros. |
| 6 | Empate persistente del jurado | Dos rondas sin mayoría sobre el mismo hallazgo. |
| 7 | Reapertura de una decisión cerrada | El panel sostiene con E1/E2 que una DC-0n es contradictoria (no sólo mejorable). |

Ante duda sobre si escalar: no se escala; se aplica el criterio por defecto y se registra en `deuda_declarada`. Las escaladas se agrupan al final del ciclo (salvo las de tipo 2 y 3) con el formato de M§6: una pregunta cerrada, contexto de hasta cinco líneas, opciones con consecuencia, recomendación de la mesa con reparto de votos y qué hace la mesa si el PO no responde.

---

## 13. Criterios de parada y bloque de cierre

El trabajo cierra cuando se cumple **cualquiera** (M§7):

- No quedan hallazgos S1 ni S2 abiertos **y** la relectura integral (§10) ya se ejecutó al menos una vez.
- **Rendimientos decrecientes**: el ciclo N produjo menos del 20 % de hallazgos válidos nuevos (≥ S3, `PROCEDE`) respecto del ciclo N-1.
- Se agotó `ciclos_max` (3).
- Hay una escalada bloqueante sin responder.

Ningún criterio de parada exime de la relectura integral: si el presupuesto se agota antes, la relectura consume el último ciclo.

Al cerrar se emite, en `BIT/29-Cierre.md`:

```yaml
cierre:
  version_final: { guia_sha256: <...>, lineas: <n>, fecha: <...> }
  ciclos_ejecutados: <n>   # incluye la relectura integral
  nucleos: { validados: [N0..N8], a_revalidar: [<...>] }
  panel:
    nucleo_permanente: [requisitos, verificacion, implementador_ingenuo_windows_vs, abogado_del_diablo]
    perfiles_del_po: [<rol: hallazgos_procedentes>]
    convocados_por_señal: [<rol: hallazgos_procedentes>]
    ad_hoc: [<id: pregunta que respondió y qué aportó>]
    descartados: [<rol: motivo>]
    postergados_por_cupo: [<rol>]
    aporte_nulo: [<roles a no reconvocar>]
  hallazgos: { detectados: n, procedentes: n, aplicados: n, revertidos: n, descartados_C: n }
  coherencia: { contradicciones: 0, solicitudes_sin_seccion: 0, afirmaciones_sin_evidencia: 0, secciones_huerfanas: 0, terminos_ambiguos: 0 }
  compuertas: { enlaces_rotos: 0, mermaid_invalidos: 0, identificadores_privados: 0, gitignore_examples: ok }
  experimentos: [<ruta en Examples/: comando: resultado>]
  relectura_integral: { ejecutada: true, correcciones_edicion: n, correcciones_compresion: n, correcciones_coherencia: n }
  apartamientos_del_marco: [<p. ej., techo del panel §8.4, con motivo>]
  supuestos: [SUP-01..SUP-07 y los que se agreguen]
  deuda_declarada: [<hallazgos NO_APLICAR con motivo>]
  escaladas_pendientes: [<...>]
  capas_a_revalidar: [<...>]
```

`deuda_declarada`, `apartamientos_del_marco` y `capas_a_revalidar` son la salida más valiosa del cierre y se informan explícitamente al PO.

---

## 14. Prompt de arranque

> Vas a ejecutar este prompt siguiendo el marco de Mesa Evaluadora. Reglas no negociables:
>
> 1. Leé completo el prompt de origen, este prompt, el marco, el Profile, el RuleSet, las Rules y los cuatro registros existentes de la bitácora (00–03) antes de producir nada.
> 2. Validá el contrato de entrada (§5). Si falta un campo, ese es tu primer hallazgo y lo resolvés con un supuesto registrado, no preguntando.
> 3. Corré las compuertas mecánicas (§9.1) antes de convocar a nadie, y de nuevo después de cada aplicación.
> 4. Armá el panel para este caso: núcleo permanente + los cinco perfiles del PO + lo que la mesa de convocatoria vote sobre §8.3. Registrá convocados, descartes con motivo y postergados.
> 5. Trabajá por núcleo en el orden de BIT-15-02 §7, con su registro independiente en la bitácora (§6.2), y cerrá con la integración en N8 reparando en la capa de origen.
> 6. El panel trabaja a ciegas y en paralelo; nadie opina fuera de su mandato. Todo hallazgo declara evidencia; las conjeturas sólo generan preguntas. Verificá versiones y defaults en la fuente vigente: tu conocimiento previo no es evidencia.
> 7. Jurado de cinco con funciones fijas, voto por hallazgo con fundamento; auditores con parche de texto exacto y criterio de verificación, sin votar lo propio; aprobación con cuatro resultados.
> 8. Terminada la guía, ejecutá la relectura integral (§10): edición, compresión y coherencia sobre el documento completo.
> 9. Decidí sin consultar salvo los siete disparadores de §12. Nunca nombres el caso privado.
> 10. Pará según §13 y emití el bloque de cierre.
>
> Entregá: la guía final, el laboratorio `Examples/` con su `.gitignore`, la bitácora completa (convocatoria, registros por núcleo, informes, veredictos, parches, changelog, relectura, cierre) y las escaladas si las hubiera. Al PO, sólo un resumen con el bloque de cierre; la deliberación queda en la bitácora.

---

## 15. Trazabilidad con el prompt de origen

Chequeo de que la reedición no perdió nada del pedido.

| Elemento del prompt de origen | Dónde quedó en este prompt |
|---|---|
| Encabezado Tool-Prompt, invocación y overview «Investigación» | Encabezado (invocación a este archivo; origen citado) |
| Comentario del fix (cp1252 → UTF-8 con BOM, Roslyn en Linux, identificador no ASCII, `?` en acentos, sin cambio en Windows) | §1 «El caso disparador» (genérico por R-PRIV) |
| Desarrollo simultáneo Visual Studio/Windows, Linux y devcontainers | §1 «Por qué pasa»; ESC-01…05 (§6.1, BIT-15-03) |
| Criterio unificado de «setcode» sin commits de BOM | §1 preocupación 1; SUP-01; N1, N2 |
| Congelar NuGet, compiladores y SDK; ¿con contenedores?; equipos Windows y Linux | §1 preocupación 2; SUP-03, SUP-04, SUP-05; N3, N4, N5 |
| Saber con qué entorno se ensambló cada pieza | §1 preocupación 3; N6 |
| Analizar estrategias de la industria para .NET, Node.js, Python | S-01; §7 preguntas 1–6; AH-01 |
| En especial, su integración en una única solución | S-02; N8; §7 pregunta 7 |
| Reeditar el prompt sobre el marco y plantear el caso a la mesa | S-03; este documento; §7 |
| Mesa: didáctica, edición bibliográfica, senior .NET, arquitectos, desarrolladores | S-04; DC-03; §8.2 |
| Analizar si hace falta un experto más | S-05; §8.3 con cartas de mandato |
| Relectura del documento finalizado: edición, compresión, coherencia | S-06; DC-04; §10 |
| Apuntes, borradores, debates y precompilaciones de la mesa | S-07; §11 (`27-*` y registros por núcleo) |
| Ruta del documento final | S-08; §5 (`ruta/id`); §11 |
| Regla de forma: jerarquía, índices, definiciones, ejemplos, mermaid | R-PO-1 |
| Autocontenido, no delta | R-PO-2 |
| Ejemplos, snippets, preguntas guía con respuestas formadoras de criterio | R-PO-3 |
| Descomposición conceptual completa (núcleos, documento por núcleo, cohesión global, validación independiente, integración, trazabilidad) | R-PO-4; §6 |
| Registros retomables en `OUTPUTs/Bitcora` | R-PO-5; §6.2; §11 |
| No inventar información | R-PO-6; R-EVID |
| Toda afirmación con evidencia verificable | R-PO-7; R-EVID; §5.1 |
| Profile Study-Guide-Documentation | §4.1 |
