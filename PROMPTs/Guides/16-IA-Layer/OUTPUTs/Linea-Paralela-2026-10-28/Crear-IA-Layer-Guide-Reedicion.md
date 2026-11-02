# Tool-Prompt — Guía con Mesa Evaluadora: integración de una capa de IA en aplicaciones .NET

> **Invocación**:
> - ultracode leer y ejecutar `/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/Guides/16-IA-Layer/Crear-IA-Layer-Guide.md`
>
> **Prompt de origen (del PO, sólo lectura, no se modifica)**: `/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/Guides/16-IA-Layer/Crear-IA-Layer-Guide.md` (sha256 `48484c0d…fdfd9b74`, 60 líneas, al 2026-10-25).
>
> **Este archivo**: `/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/Guides/16-IA-Layer/OUTPUTs/Crear-IA-Layer-Guide-Reedicion.md` — la reedición del pedido sobre el marco de mesa que el PO solicita en §Solicitudes, párr. 2. La invocación sigue siendo la del prompt de origen: quien lo ejecuta, ejecuta esta reedición.
>
> **Marco base**: `/IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` (en adelante, «el marco»; sus secciones se citan `M§n`).
>
> **Overview**: Guía de estudio con laboratorio y demo. Una mesa evaluadora, armada por caso, investiga cómo se integra hoy una **capa de IA** (*AI layer*) en el stack de una aplicación .NET —abstracciones y proveedores de modelos, RAG con embeddings y bases vectoriales, agentes con herramientas y orquestación (incluida la pregunta por LangGraph en .NET), operación, calidad y seguridad—; descompone el pedido en núcleos conceptuales, los trabaja con evidencia verificable y con pruebas reales contra el modelo Qwen del servidor Ollama de la LAN del laboratorio, los integra en **una sola guía de estudio** acompañada de ejemplos y de una demo basada en el caso Movilidad Urbana de Lab-E2E.WebBlazor y, una vez terminada, la relee entera para corregir edición, compresión y coherencia.
>
> **Fecha de reedición**: 2026-10-25. **Idioma**: español rioplatense, una sola voz de autor; términos técnicos y nombres de API en inglés cuando son nombres propios (`IChatClient`, *embeddings*, RAG, MCP…).

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

### 1.1 La imagen de entrada

El PO adjunta `INPUTs/AI-Layer.png` (sha256 `6d46bc8f…9d0cc8b7`) como «concepto teórico sobre la implementación de IA como parte del layer stack de una aplicación». Es una diapositiva titulada **«IA ya es parte del stack»**, con la marca LIDR en el ángulo superior derecho, que dibuja cinco capas apiladas de arriba hacia abajo. La descripción que sigue es literal respecto de lo que la imagen muestra; lo que se interpreta va marcado como tal.

| Capa (rótulo de la imagen) | Componentes dibujados | Relaciones dibujadas |
|---|---|---|
| **FRONTEND** | Web App · Mobile App · Admin Panel; fuera del recuadro, Third-Party Integrations | Una flecha punteada sale del recuadro hacia Third-Party Integrations; flechas verticales lo unen al backend. |
| **BACKEND** | API Gateway → Auth Service → Business Logic → Microservices → File Storage | Cadena horizontal de izquierda a derecha. Business Logic tiene una flecha doble hacia la capa de IA. |
| **AI LAYER** (resaltada en dorado) | LLM / Generative Models → **RAG Pipeline** → AI Services & Agents; debajo, una franja «Retrieval · Embeddings · Vector DB» | Flechas horizontales entre los tres bloques; líneas punteadas unen LLM y Agents con la franja inferior; una flecha doble baja desde la franja hacia la base de datos. |
| **DATABASE** | SQL DB · NoSQL DB · **Vector DB** (resaltada) · Cache (Redis) · Object Storage | Una flecha doble sube desde Vector DB a la capa de IA; una línea punteada inferior conecta todo el recuadro con la infraestructura. |
| **INFRASTRUCTURE** | Docker · Kubernetes · Cloud (AWS/GCP/Azure) · Monitoring & Logging | Una flecha sube desde la infraestructura hacia la base de datos. La franja inferior de la captura está parcialmente tapada por controles de un reproductor de video. |

**Lectura del diagrama (interpretación, a validar en N1).** La imagen sostiene una tesis de arquitectura: la IA deja de ser un servicio externo que se llama de vez en cuando y pasa a ser una **capa propia**, entre la lógica de negocio y los datos, con tres responsabilidades encadenadas —generar (LLM), recuperar contexto propio (RAG) y actuar (servicios y agentes)— y con un tipo de almacenamiento nuevo, la base vectorial, que aparece a la vez en la capa de IA y en la de datos. Lo que el diagrama **no** dice, y la guía tiene que resolver con evidencia, es cómo se materializa esa capa en una solución .NET concreta: qué abstracciones la separan de un proveedor, dónde viven las herramientas de un agente respecto de los casos de uso, quién valida lo que el modelo devuelve y cómo se opera.

### 1.2 El caso base para el ejemplo y la demo

El PO propone como base temática Lab-E2E.WebBlazor, descripto por su ia-db (`/LAB/Lab-E2E.WebBlazor/Lab-E2E.WebBlazor.Documentacion/ia-db/README.md`, v3.1 del 2026-10-25, indexada sobre el commit `8fb4c3a`):

- **MovilidadUrbana.Web**: Blazor Web App en modo Interactive Server, con un ABM de localidades y una encuesta de transporte en tres pasos; datos aislados por sesión (cookie) sobre un único SQLite con EF Core.
- **MovilidadUrbana.ApiWeb**: la misma temática como API REST `/api/v1`, con sesión por encabezado `X-Sesion-Id`, OpenAPI y Scalar en Development.
- Stack **.NET 10**, EF Core SQLite 10.0.11; cada app trae sus propias carpetas `Domain → Application → Infrastructure` (arquitectura en inglés, dominio en español). Entidades `Localidad`, `RespuestaDeEncuesta` (con `Nombre` y `Edad` de quien responde) y `Session`; servicios `LocalidadService` y `EncuestaService`; reglas en `LocalidadRules` y `EncuestaRules` (ia-db, índice `02_Dominio-Y-Reglas.md`).

El código fuente (`/LAB/Lab-E2E.WebBlazor/Lab-E2E.WebBlazor/`) es **de sólo lectura** para esta corrida. La demo se construye aparte, en el destino de la guía, tomando la temática y, cuando haga falta, fragmentos con procedencia (ruta + commit).

### 1.3 El entorno de pruebas

El PO cuenta con una API local en la red con el modelo Qwen para probar integraciones y los conceptos que la guía edite. En toda salida se la nombra **«el servidor Ollama de la LAN del laboratorio»**; en código y configuración, el endpoint es `http://localhost:11434` por defecto y se sobreescribe con la variable de entorno `OLLAMA_ENDPOINT` (R-PRIV). El modelo exacto (etiqueta y *digest*) se releva al iniciar con la API del servidor y se registra; el endpoint real no se escribe en ningún archivo.

---

## 2. Solicitudes

| ID | Solicitud | Fuente en el prompt de origen |
|---|---|---|
| S-01 | Analizar y describir la imagen `INPUTs/AI-Layer.png` como concepto teórico de la IA como capa del stack de una aplicación. | §Contexto, párr. 1 |
| S-02 | Recabar el marco teórico y práctico vigente sobre el tema dentro del ecosistema .NET («.NET Core»). | §Contexto, párr. 1 |
| S-03 | Iniciar guías de estudio, ejemplos y una demostración práctica. | §Objetivos |
| S-04 | Analizar las **estrategias y casos de integración** de la capa de IA en el stack .NET. | §Solicitudes, párr. 1 |
| S-05 | Tratar la **creación de agentes**. | §Solicitudes, párr. 1 |
| S-06 | Añadir **definiciones**. | §Solicitudes, párr. 1 |
| S-07 | Añadir **ejemplos** y **snippets de código** representativos. | §Solicitudes, párr. 1 |
| S-08 | Añadir **preguntas y respuestas explicativas**. | §Solicitudes, párr. 1 |
| S-09 | Una **demo** basada en Lab-E2E.WebBlazor (MovilidadUrbana.Web y MovilidadUrbana.ApiWeb). | §Contexto, párr. 2; §Solicitudes, párr. 1 |
| S-10 | Responder qué es y qué lugar tiene **LangGraph** en el ecosistema .NET («se ha escuchado sobre LangGraph»). | §Solicitudes, párr. 1 |
| S-11 | Reeditar el prompt sobre el marco Mesa-Evaluadora, a partir del contexto, las reglas, los objetivos y las solicitudes, planteando el caso a la mesa. **Este documento es esa reedición.** | §Solicitudes, párr. 2 |
| S-12 | La mesa está formada por expertos en **didáctica**, en **edición de material bibliográfico**, **senior en .NET**, **expertos en IA**, **arquitectos de software** y **desarrolladores de código**, que revisan la documentación generada. | §Solicitudes, párr. 2 |
| S-13 | Analizar si hace falta **un experto más**. | §Solicitudes, párr. 2 |
| S-14 | La mesa vuelve a analizar el documento **una vez finalizado** y corrige edición y compresión, ajustando su coherencia. | §Solicitudes, párr. 2 |
| S-15 | La mesa puede llevar apuntes, borradores, debates y precompilaciones que después forman parte de la edición del documento final. | §Solicitudes, párr. 2 |
| S-16 | Rutas de salida: guía en `/LAB/Lab-Documentos/Lab-Documentos/Guides/IA/Dot-Net-Integration-AI-Layer-Guide/Dot-Net-Integration-AI-Layer-Guide.md`; ejemplos en `…/Dot-Net-Integration-AI-Layer-Guide/Examples`; demo en `…/Dot-Net-Integration-AI-Layer-Guide/Demos`. | §Solicitudes, párr. 2 |
| S-17 | **Probar todo** y llevar registro de las pruebas, usando la API local con el modelo Qwen para pruebas de integración y para probar los conceptos editados. | §Solicitudes, párr. 2 (última oración) |

«Compresión» en S-14 se lee en sus dos sentidos y la mesa atiende ambos: **comprensión** del lector y **compresión** del texto (SUP-07). La última oración del párrafo 2 del origen está truncada («probar todo, y llevar .»); se lee como «llevar registro» (SUP-03).

---

## 3. Reglas

### 3.1 Reglas del PO (se conservan íntegras)

- **R-PO-1 — Forma.** Los documentos Markdown se organizan en secciones jerárquicas con índices. Incluyen definiciones, explicaciones, ejemplos claros y, cuando sea necesario, gráficos mermaid.
- **R-PO-2 — Autocontenido.** Son autocontenidos, no delta.
- **R-PO-3 — Formación de criterio.** Llevan ejemplos, explicaciones, snippets de código representativos y preguntas guía con respuestas explicativas formadoras de criterio, que le permitan al lector identificar en qué caso se aplica cada concepto.
- **R-PO-4 — Descomposición conceptual.** Sobre la totalidad del prompt: agrupar ideas por afinidad y dependencia (no por extensión ni por párrafo) en núcleos coherentes; un Markdown independiente por núcleo y un documento de cohesión global con relaciones, dependencias, referencias y vínculos; cada núcleo analizable, planificable y validable de forma relativamente independiente, con trazabilidad; fase de integración que consolida, resuelve dependencias o contradicciones y reconstruye el modelo completo; presentación por eje a la mesa evaluadora y planificadora e integración final en un todo coherente (detalle operativo en §6).
- **R-PO-5 — Registros retomables.** Para cumplir R-PO-4 se generan registros Markdown que se puedan retomar y evaluar. El origen escribe como ruta la de la guía final; se resuelve con SUP-02: los registros viven en la bitácora (`OUTPUTs/Bitacoras/`) y lo que maduran pasa, editado, a la guía.
- **R-PO-6 — No inventar información.**
- **R-PO-7 — Evidencia.** Toda afirmación respaldada por evidencia verificable.

### 3.2 Reglas que precisan a las del PO

No agregan exigencias: vuelven operables R-PO-6, R-PO-7, S-17 y el entorno.

- **R-EVID — Qué cuenta como evidencia.** URL de documentación oficial (learn.microsoft.com, devblogs.microsoft.com, docs.ollama.com, modelcontextprotocol.io, langchain-ai.github.io / docs.langchain.com, owasp.org, opentelemetry.io), repositorio GitHub oficial, nuget.org o `https://api.nuget.org/v3-flatcontainer/<id>/index.json` **con versión y fecha de consulta**, o un paper con identificador estable; o un experimento ejecutado con comando y salida (E1). El conocimiento previo del modelo **no** es evidencia: versiones GA/preview, renombres, deprecaciones y paquetes recomendados se verifican en la fuente vigente al 2026-10-25. Lo que es criterio propio se declara («criterio de la guía: …»); lo no verificado se marca «no verificado».
- **R-LLM — Evidencia sobre salidas de un modelo.** Una prueba contra el modelo es E1 sólo si registra: modelo y *digest*, parámetros (temperatura, semilla si el proveedor la respeta, `num_ctx` si se fija), el prompt o mensaje exacto, la salida y la fecha. Como la salida de un LLM no es determinista, las aserciones de los ejemplos verifican **forma y propiedades** (esquema JSON válido, herramienta invocada con argumentos válidos, respuesta que cita un dato existente), no texto literal. Un ejemplo que sólo «a veces» funciona se documenta con su tasa observada en N corridas, o no se presenta como funcionando.
- **R-PRIV — Repositorios públicos.** Los repositorios donde se escribe (Lab-Documentos, que aloja la guía, Examples/ y Demos/, y Lab-Documentos.Documentacion, que aloja esta reedición y la bitácora) son públicos. Ningún archivo contiene IPs privadas, hostnames de la LAN, puertos de la infraestructura del PO, usuarios ni credenciales. El servidor de IA se nombra «el servidor Ollama de la LAN del laboratorio»; en código, `OLLAMA_ENDPOINT` con default `http://localhost:11434`. No se nombran repositorios privados ni proyectos de terceros del PO. Una compuerta mecánica (`grep` de patrones de IP privada RFC 1918 y de una lista de identificadores prohibidos mantenida sólo en memoria de la sesión) debe dar cero antes de cada cierre de ciclo.
- **R-ESCR — Dónde se escribe.** En `PROMPTs/Guides/16-IA-Layer/` sólo dentro de `OUTPUTs/`; el prompt del PO e `INPUTs/` no se tocan. Fuera de ahí, sólo en la carpeta destino de la guía (`Dot-Net-Integration-AI-Layer-Guide/`: el `.md`, `Examples/`, `Demos/`). Lab-E2E.WebBlazor no se modifica. Sin commit ni push.
- **R-HOST — Dónde se ejecuta.** No hay SDK de .NET en el host: toda compilación y prueba corre en contenedor (`mcr.microsoft.com/dotnet/sdk:10.0`, con el directorio montado). Los intermedios de build y la caché de NuGet van a `{dir-de-trabajo}/` o a volúmenes Docker, nunca al directorio temporal del sistema ni al scratchpad. Las pruebas contra el modelo usan el servidor Ollama de la LAN; si no está disponible, un Ollama en contenedor local, y se registra cuál se usó.
- **R-AUTO — Autonomía.** No se le pregunta al PO salvo los disparadores cerrados de §12. Ante duda, la mesa decide con criterio y registra el supuesto.

---

## 4. Framework

### 4.1 Profile

Aplicar `/IA/IA.Prompts/PromptFramework/Profiles/Study-Guide-Documentation.md` (se resuelve en `/IA/PROMPTs/IA.Prompts/PromptFramework/Profiles/`). Rigen en particular: el **marco de referencia** (escenarios, contextos, actores) fijado una vez y referenciado en todo el documento; el **mapa conceptual** «estoy acá → qué aplico»; la estructura de cada tema **Definición → Aplicación por escenario (y qué cambia por contexto) → Ejemplos concretos → Preguntas guía con respuesta → Criterios de calidad → Anexo con plantilla comentada**; la sección de **métodos y marcos** (enfoques alternativos y criterios para elegir, que acá incluye la comparación de marcos de agentes y la pregunta por LangGraph); y sus criterios de calidad: formativo, trazable, consistente, interconectado, verificable.

### 4.2 RuleSet y Rules

- RuleSet: `/IA/PROMPTs/IA.Prompts/PromptFramework/RuleSets/RuleSet-Study-Guide.md`.
- Rules, en `/IA/PROMPTs/IA.Prompts/PromptFramework/Rules/`: Rule-All, Rule-Workflow, Rule-Evidences, Rule-Markdown, Rule-Documentation, Rule-Indexing, Rule-Agents, Rule-Dual-Audience, Rule-Narrative-Voice.

### 4.3 Marco de mesa

`/IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md` rige el ciclo completo. El marco imagina una especificación (spec → plan → tareas → código); acá el objeto es una **guía de estudio con laboratorio y demo**. La traducción de cada concepto está en §5 y §9; donde la reedición se aparta del marco, lo dice y lo justifica (§8.5 y §13).

### 4.4 Precedencia

Ante choque: (1) reglas del PO (§3.1), (2) reglas que las precisan (§3.2), (3) Profile, RuleSet y Rules, (4) el marco de mesa. Un choque entre (1) y (2) que no se resuelva leyendo ambas es disparador de escalada (§12, tipo 2).

### 4.5 Precedente de forma

La corrida de la guía 15 (`/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/Guides/15-Metodologia-Entorno-Desarrollo/OUTPUTs/`) es precedente **de forma**, no de contenido: su bitácora organizada en `00…05`, `Nucleos/` y `Mesa/Ciclo-n/` es la estructura que adopta §11.

---

## 5. Contrato de entrada (Fase 0)

El contrato instanciado vive en `OUTPUTs/Bitacoras/00-Contrato-De-Entrada.md` (doc_id `BIT-16-00`), que es su fuente de verdad. Lo que sigue es el resumen operativo; si un ciclo lo modifica, se modifica allá y se registra.

```yaml
objeto:
  artefacto: guía de estudio + laboratorio de ejemplos ejecutables + demo
  ruta/id: /LAB/Lab-Documentos/Lab-Documentos/Guides/IA/Dot-Net-Integration-AI-Layer-Guide/Dot-Net-Integration-AI-Layer-Guide.md
  version: "0 al inicio (archivo de 0 bytes al 2026-10-25); cada ciclo registra sha256 y líneas"
  capas: # de origen a derivada; un defecto se repara en la capa donde nace (M§1.1)
    - pedido: prompt del PO (sólo lectura) + esta reedición
    - marco_y_nucleos: OUTPUTs/Bitacoras/03-Marco-De-Referencia.md y Nucleos/N0..N6-*.md
    - laboratorio: …/Dot-Net-Integration-AI-Layer-Guide/Examples/
    - demo: …/Dot-Net-Integration-AI-Layer-Guide/Demos/
    - guía: el .md final, que cita Examples/ y Demos/ por ruta relativa
objetivo: >
  Que un desarrollador .NET sin experiencia previa en IA entienda qué es una capa de IA dentro
  del stack de una aplicación y forme criterio para diseñarla, construirla, probarla y operarla
  en .NET —abstracciones y proveedores, RAG, agentes y orquestación—, verificándolo sobre un
  caso concreto (Movilidad Urbana) contra un modelo local.
restricciones_duras: [R-PO-1..7, R-EVID, R-LLM, R-PRIV, R-ESCR, R-HOST, R-AUTO, Profile, RuleSet, Rules]
decisiones_cerradas:
  - DC-01 Un solo .md de guía. Las piezas que el Profile pide como documentos separados son secciones y anexos de ese archivo.
  - DC-02 Los seis perfiles del PO (didáctica, edición bibliográfica, senior .NET, IA, arquitectura, desarrollo) integran la mesa siempre.
  - DC-03 Hay al menos un ciclo de relectura integral posterior a la integración (§10).
  - DC-04 Unidades de trabajo: N0–N6 (§6); cohesión en BIT-16-02.
  - DC-05 Lab-E2E.WebBlazor es de sólo lectura; la demo es propia y replica su temática.
  - DC-06 Código agnóstico del proveedor; pruebas contra Ollama + Qwen; endpoint por OLLAMA_ENDPOINT (default localhost:11434).
  - DC-07 Stack de ejemplos y demo: .NET 10 y C#, alineado con el caso base.
  - DC-08 Examples/ y Demos/ llevan .gitignore (bin/, obj/, bases y almacenes vectoriales generados).
fuera_de_alcance:
  - Entrenamiento y fine-tuning de modelos.
  - Despliegue productivo real (Kubernetes, nube): se trata conceptualmente en N5.
  - Comparativas comerciales de proveedores de modelos más allá de un contraste con fuente.
  - Modificar Lab-E2E.WebBlazor u otras guías de Lab-Documentos.
  - Instalar, borrar o reconfigurar modelos en el servidor Ollama de la LAN.
  - La app Android MAUI del caso base.
umbral_de_calidad: S1 y S2 bloquean el cierre
presupuesto: { ciclos_max: 3, hallazgos_max_por_especialista: 7 }
```

**Supuestos registrados** (detalle en BIT-16-00 §5): SUP-01 «qween» es la familia Qwen servida por Ollama; SUP-02 los registros de R-PO-5 van a la bitácora; SUP-03 «llevar .» = llevar registro de pruebas; SUP-04 LangGraph en .NET es una **pregunta** a responder con evidencia, no una tecnología a adoptar por defecto; SUP-05 la demo cubre la web y la API del caso base; SUP-06 los embeddings usan un modelo de embeddings disponible en el servidor Ollama, o uno local en contenedor; SUP-07 «compresión» = comprensión + economía del texto; SUP-08 «.NET Core» = .NET moderno (hoy .NET 10).

### 5.1 Escala de evidencia aplicada a esta guía (M§3)

| Nivel | En esta guía significa | Puede fundar |
|---|---|---|
| E1 | Build y pruebas de `Examples/` y `Demos/` en contenedor con comando y salida; corrida contra el modelo con los datos de R-LLM; compuertas mecánicas sobre el `.md` (anclas, índice, mermaid, `grep` R-PRIV). | corrección |
| E2 | Cita literal de la guía o del pedido, con sección y línea, que muestra contradicción, ambigüedad u omisión. | corrección |
| E3 | Escenario construido que la guía no resuelve (p. ej., «un documento ingerido en el RAG contiene una instrucción que el agente obedece»). | corrección |
| E4 | Regla del contrato o documentación oficial con URL, versión y fecha de consulta. | corrección |
| C | Experiencia general, «suele hacerse». En la bitácora se marca **[C: a verificar en N…]**. | sólo una pregunta |

### 5.2 Severidades aplicadas a esta guía (M§3)

- **S1**: afirmación técnica falsa o sin fuente presentada como hecho (incluye un paquete deprecado presentado como vigente o una API inexistente); snippet o ejemplo presentado como ejecutado que no compila o no corre; IP, hostname, puerto o credencial filtrados; contradicción entre secciones.
- **S2**: núcleo sin preguntas guía con respuesta; recomendación sin el escenario o contexto donde aplica; ejemplo que el implementador no puede reproducir sin preguntar; salida de modelo presentada como determinista.
- **S3**: índice o anclas incompletas; mermaid que repite la prosa; término usado con dos sentidos; párrafo redundante.
- **S4**: estilo y redacción (Rule-Narrative-Voice). Se aplica o descarta en lote.

---

## 6. Descomposición en núcleos conceptuales

### 6.1 Núcleos

La descomposición pedida en R-PO-4 se hizo sobre la totalidad del prompt y está en la bitácora. El criterio de corte: dos ideas van juntas si comparten **abstracción o mecanismo** (la misma interfaz, el mismo flujo de datos) y **modo de falla**; se separan si se pueden construir, probar y romper por separado.

| ID | Núcleo | Responde a | Depende de |
|---|---|---|---|
| N0 | Marco de referencia didáctico: escenarios, contextos y actores | Profile; S-03, S-06 | — |
| N1 | La capa de IA en el stack de una aplicación | S-01, S-02, S-04 | N0 |
| N2 | Abstracciones y proveedores de IA en .NET | S-02, S-04, S-07, S-17 | N0, N1 |
| N3 | RAG en .NET: embeddings, ingesta y bases vectoriales | S-01 (RAG Pipeline, Vector DB), S-04, S-07 | N1, N2 |
| N4 | Agentes, herramientas y orquestación en .NET (incluye LangGraph) | S-05, S-10, S-04 | N1, N2, N3 |
| N5 | Operación, calidad y seguridad de la capa de IA | S-01 (Infrastructure, Monitoring), S-17; panel S-13 | N2, N3, N4 |
| N6 | El caso práctico: Movilidad Urbana con capa de IA — **fase de integración** | S-09, S-07, S-17 | N1–N5 |

Alcance, preguntas por núcleo, decisiones de segmentación y plan de validación: `BIT-16-01`. Grafo de dependencias, entregas entre núcleos, tensiones previsibles, trazabilidad y estructura prevista de la guía: `BIT-16-02`. Escenarios, contextos y actores: `BIT-16-03`.

### 6.2 Registro obligatorio por núcleo

Cada núcleo tiene un Markdown independiente en `OUTPUTs/Bitacoras/Nucleos/N<n>-<slug>.md`, con frontmatter (`doc_id`, `status`, `last_review`, `traces`) y estas secciones:

1. **Alcance y preguntas** (de BIT-16-01, ajustadas si la investigación las corrige).
2. **Fuentes consultadas**: URL o paquete con versión, fecha de consulta y afirmación que sostiene cada una.
3. **Experimentos**: ruta en `Examples/` o `Demos/`, comando exacto, salida capturada, imagen del SDK, modelo y *digest* (R-LLM).
4. **Marcas [C] resueltas**: cada `[C: a verificar]` de BIT-16-01 con su resolución.
5. **Borrador de la sección de la guía**, con la estructura del Profile.
6. **Validación del núcleo**: resultado del plan de BIT-16-01 §4 y veredicto de la mesa.
7. **Entregas a otros núcleos y deudas.**

Un núcleo está **validado** cuando su plan de validación pasó, no quedan marcas `[C]` en su borrador y la mesa no tiene S1/S2 abiertos sobre él.

> **2026-10-28 — Parche P-34 (ciclo 1).** Ninguno de los nueve registros tiene «Marcas [C] resueltas» ni «Validación del núcleo» con veredicto. Eso no bloquea la redacción en general. Sí bloquea: (a) redactar las secciones que derivan de un núcleo con S1 abierto hasta que su parche esté aplicado y verificado (hoy, N0b por P-02 y N5 §4.2 por P-03); (b) declarar validado un núcleo; (c) el cierre (REED-16 §13). Cada núcleo recibe, después de aplicar los parches de este ciclo, dos secciones agregadas: «Marcas [C] resueltas (2026-10-28)», con el mapa de cada `[C]` a su resolución, y «Validación del núcleo (ciclo 1)», con el veredicto de la mesa y los S1/S2 que quedan abiertos sobre él.
> **Ajuste de verificación (juez de impacto):** el criterio es «el encabezado `## Validación del núcleo (ciclo 1)` aparece una vez por registro», porque la nota de cada núcleo también contiene la cadena.

> **2026-10-28 — Parche P2-15 (ciclo 1, ronda 2).** P-34 queda firme como estaba (C1-36 = A; costo-beneficio cambió su voto de la ronda 1). Lo que levanta cada bloqueo: **N0b** (secciones que derivan de §3.1.3 y R-C20) se puede redactar cuando estén aplicadas la nota de P-02 y la de P2-13 que reemplaza su N, y el `grep -n "falso aceptado"` de P-02 dé el sentido 1 en todas las apariciones posteriores. **N5 §4.2** se puede redactar cuando estén verificadas, en `Cableado/` y con el recurso `build`, las pruebas (1)–(3) de P-03 (el fragmento compila; 4.º pedido → 503 con `Retry-After`; dos sesiones → dos fallos de caché) y las cinco de P2-06: (1) spans de la rama A, (2) contador por nombre, (2b) contador por streaming con `CoalesceStreamingUpdates` en `true` y en `false`, (3) clave con sesión y (4) escritura entre dos pedidos iguales, con la misma instancia del cliente. Si la demo usa caché, también en la demo (2b), y la (4) si la demo pasa a la regla (a) (ajuste que sigue a P2-06 vuelta 2). PC-02 ya corrió (Operación, `PC02-salida.txt`): lo que falta es pasar la sonda a `Cableado/`, no investigar. «Validado» y el cierre siguen bloqueados hasta que cada núcleo tenga «Marcas [C] resueltas» y «Validación del núcleo».



### 6.3 Fase de integración

N6 es la integración: arma la demo de Movilidad Urbana con los mecanismos de N2–N5, resuelve las tensiones de BIT-16-02 §4 y reconstruye el modelo completo de la capa de IA sobre un caso real. Si una tensión obliga a cambiar la recomendación de un núcleo anterior, el cambio se hace **en el núcleo de origen** (M§1.1) y se marcan como «a revalidar» N6 y las secciones derivadas (M§1.2). El cuaderno de integración es `Bitacoras/04-Integracion.md`.

---

## 7. El caso que se plantea a la mesa

> **A la mesa.** Un diagrama que circula en la industria afirma que «la IA ya es parte del stack»: entre la lógica de negocio y los datos aparece una capa con modelos generativos, un pipeline RAG y servicios y agentes, apoyada en embeddings y en una base vectorial, y operada con la misma infraestructura que el resto. El PO quiere que un desarrollador .NET entienda esa capa y sepa construirla: qué estrategias de integración existen hoy en .NET, cómo se crean agentes, qué hay de cierto sobre LangGraph en .NET, con definiciones, snippets, preguntas y respuestas que formen criterio. Lo quiere demostrado sobre un caso conocido —Movilidad Urbana, una web Blazor Interactive Server y una API REST en .NET 10 con EF Core SQLite— y probado de verdad contra el modelo Qwen del servidor Ollama de la LAN del laboratorio.
>
> La mesa debe producir **una guía de estudio** que forme criterio, no un catálogo de paquetes. Cada afirmación técnica lleva fuente vigente con fecha o un experimento reproducible; cada salida de modelo, sus parámetros y su modelo. La guía recorre N0–N6, termina en una demo coherente y, una vez terminada, la mesa la relee completa para corregir edición, compresión y coherencia. Los repositorios son públicos: nada de la infraestructura del PO se escribe.
>
> Preguntas que la mesa tiene que poder responder con evidencia al cerrar:
> 1. ¿Qué es una «capa de IA» y qué responsabilidades tiene frente a la lógica de negocio y a los datos? ¿Qué del diagrama de entrada se sostiene con fuentes y qué es simplificación?
> 2. ¿Qué abstracciones ofrece hoy .NET para hablar con un modelo sin atarse al proveedor, cuáles son GA y cuáles preview, y qué paquetes quedaron deprecados?
> 3. ¿Cómo se arma un pipeline RAG en .NET —ingesta, *chunking*, embeddings, almacén vectorial, recuperación— y cuándo no hace falta RAG?
> 4. ¿Qué es un agente, en qué se diferencia de una llamada con herramientas, y con qué marco se construye hoy en .NET? ¿Qué es LangGraph, existe para .NET y qué alternativas o vías de integración hay?
> 5. ¿Cómo se prueba, se observa y se asegura una capa de IA (no determinismo, evaluación, trazas, costo, inyección de prompts, agencia excesiva, datos personales)?
> 6. ¿Cómo queda todo eso integrado en Movilidad Urbana sin romper su arquitectura `Domain → Application → Infrastructure`, y qué muestra la demo funcionando contra Qwen?

---

## 8. Composición del panel

La composición la decide la mesa de convocatoria (M§5.1) y **no** se eleva al PO. Este apartado fija lo que no se discute (núcleo permanente y perfiles del PO) y presenta el análisis de S-13 como propuesta que la mesa vota.

### 8.1 Núcleo permanente del marco (M§4.1.1, siempre)

| Rol | Pregunta que responde en esta guía |
|---|---|
| **Requisitos** | ¿Cada solicitud S-01…S-17 y cada pregunta de §7 tiene una sección que la responde? ¿Cada sección declara en qué escenario y contexto aplica? |
| **Verificación / QA** | ¿Cada afirmación técnica tiene fuente con versión y fecha o experimento? ¿Cada ejemplo compila y corre como dice? ¿Las pruebas contra el modelo cumplen R-LLM? Corre las compuertas de §9.1. |
| **Implementador ingenuo** | ¿Un lector que no participó puede seguir la guía y reproducir cada ejemplo y la demo sin preguntar nada? Se funde con el perfil «desarrollador de código» del PO (§8.2). |
| **Abogado del diablo** | Ataca la recomendación dominante de cada núcleo (p. ej., «todo pasa por RAG», «hace falta un marco de agentes», «el modelo local alcanza para producción»). Entra después de leer al resto. |

### 8.2 Perfiles pedidos por el PO (DC-02, siempre)

| Perfil del PO | Cómo se instancia | Juzga | No le corresponde |
|---|---|---|---|
| **Didáctica** | Especialista con mandato fijo | Marco de referencia, progresión de la guía, calidad de preguntas guía y respuestas como formadoras de criterio (R-PO-3), adecuación al lector. | Corrección técnica. |
| **Edición de material bibliográfico** | Especialista con mandato fijo | Jerarquía e índices, autocontención, voz única, aparato de referencias con versión y fecha, compresión del texto. | Corrección técnica. |
| **Senior .NET** | Especialista con mandato fijo | Uso idiomático de .NET 10: inyección de dependencias, `IServiceCollection`, configuración, `IAsyncEnumerable`/streaming, EF Core, Blazor Interactive Server y ASP.NET Core en la demo; versiones de paquetes. | Calidad de modelos, didáctica. |
| **Experto en IA** | Especialista con mandato fijo | Corrección de los conceptos de IA: LLM, tokens y ventana de contexto, embeddings y similitud, *chunking*, recuperación, *tool calling*, agentes y orquestación (incluida la caracterización de LangGraph), límites del modelo Qwen usado. | Detalle de APIs .NET, forma. |
| **Arquitectura de software** | Rol de catálogo (M§4.1.2) con señal presente: más de un componente e integración entre capas (imagen de entrada; §Contexto, párr. 2) | N1 (la capa en el stack), ubicación de la capa de IA en `Domain/Application/Infrastructure`, fronteras de N3–N4, coherencia del modelo en N6. | Detalle de comandos. |
| **Desarrollador de código** | Se funde con el **implementador ingenuo**, con estación concreta: Linux con Docker y sin SDK instalado, como el entorno real de la corrida, y sin experiencia previa en IA. | Reproducibilidad de cada ejemplo y de la demo; claridad de los pasos. | Decisiones de diseño. |

### 8.3 Análisis de S-13: ¿hace falta otro experto?

El barrido de señales (M§5.1.b) sobre el pedido, la imagen y el caso base arroja señales que **ningún perfil del PO cubre**:

| Señal (con ubicación) | Hueco que deja el panel del PO | Propuesta |
|---|---|---|
| «AI Services & Agents» (imagen, capa AI LAYER) y «creación de agentes» (§Solicitudes, párr. 1): un modelo que **actúa** sobre casos de uso; documentos ingeridos por RAG que el modelo lee como texto; `RespuestaDeEncuesta` guarda `Nombre` y `Edad` (ia-db 02 §2); repositorios públicos. | Nadie tiene mandato adversarial sobre la superficie de ataque propia de una app con LLM: inyección de prompts directa e indirecta, divulgación de datos sensibles, agencia excesiva, manejo inseguro de la salida, secretos en código público. El abogado del diablo ataca la propuesta, no modela amenazas. | **`INSTANCIAR_AD_HOC` AH-01 Seguridad de aplicaciones con LLM** (ocupa el rol de catálogo Seguridad y privacidad, especializado). **Es el experto adicional que esta reedición recomienda.** |
| «probar todo» y «probar los conceptos editados» contra Qwen (§Solicitudes, párr. 2): las salidas de un LLM no son deterministas. | Verificación/QA prueba que el código corre; nadie juzga **cómo** se evalúa la calidad de una respuesta o de una recuperación. | `INSTANCIAR_AD_HOC` **AH-02 Evaluación de sistemas LLM y RAG**. |
| «Docker · Kubernetes · Cloud · Monitoring & Logging» y «Cache (Redis)» (imagen, capas INFRASTRUCTURE y DATABASE) | Observabilidad, costo por tokens y latencia no son de arquitectura ni de .NET. | `CONVOCAR` el rol de catálogo **Operación y entrega**, con el de **Rendimiento y costo** fusionado en su mandato (una señal compartida: N5). |
| Umbrales y cuantificadores previsibles en el borrador (similitud mínima, *top-k*, tamaño de *chunk*, temperatura, tasas de éxito de R-LLM) | — | Rol **Formal / matemático**: convocatoria automática si el barrido del ciclo 1 sobre el borrador encuentra la señal (M§4.1.2). |
| «Vector DB», «SQL DB», entidades del caso base | — | `NO_CONVOCAR` Datos y dominio: lo cubren el senior .NET (EF Core) y el experto en IA (almacén vectorial). Se registra el motivo. |
| «LangGraph en el ecosistema .NET» (§Solicitudes, párr. 1) | Puede exigir leer LangGraph en su ecosistema de origen (Python/JS). | `NO_CONVOCAR` por ahora: lo cubre el experto en IA. Si el ciclo 1 detecta que la caracterización necesita E1 en Python, se pide convocatoria en caliente de un ad hoc **AH-03 Ecosistema LangChain/LangGraph**. |

**Por qué AH-01 es el experto que más hace falta (criterio de la reedición, la mesa vota).** Los seis perfiles del PO juzgan si la guía enseña bien y si el código es correcto; ninguno juzga si lo que enseña es **seguro de copiar**. En una capa de IA ese riesgo no es accesorio: el capítulo de agentes enseña a darle a un modelo acceso a casos de uso que escriben en la base, el de RAG enseña a meter en el contexto texto que no controla el desarrollador, la demo trabaja sobre un dominio con datos personales, y todo se publica en repositorios públicos. Un lector que copie un agente con herramientas de escritura sin confirmación humana, o un RAG sin separación entre instrucciones y datos, reproduce los riesgos que OWASP cataloga para aplicaciones con LLM **[C: verificar edición vigente del OWASP Top 10 for LLM Applications en N5]**. AH-02 es el segundo en prioridad: sin él, S-17 se cumple con pruebas que pasan por azar.

**Cartas de mandato** (M§4.1.3). Sin carta aprobada, sus salidas se descartan.

```yaml
agente_ad_hoc:
  id: AH-01
  nombre: Seguridad de aplicaciones con LLM
  señal_que_lo_justifica: { descripción: "agentes que actúan sobre casos de uso; RAG que inyecta texto externo; datos personales en el caso base; repos públicos", ubicación: "imagen AI LAYER; prompt de origen §Solicitudes párr. 1; ia-db 02 §2; R-PRIV" }
  pregunta_que_responde: ¿Lo que la guía enseña a construir (llamadas al modelo, RAG, agentes con herramientas, servidor MCP, demo) es seguro de copiar, y la guía advierte con fuente cada riesgo propio de una app con LLM y su mitigación?
  competencia: OWASP Top 10 for LLM Applications, guías de seguridad de Microsoft para IA generativa, especificación de seguridad de MCP, manejo de secretos y datos personales en .NET. NO opina sobre didáctica, forma ni calidad de las respuestas del modelo.
  evidencia_admisible: [E1, E2, E3, E4]
  tope_hallazgos: 5
  se_disuelve_cuando: N3, N4, N5 y N6 validados en su parte de seguridad y cerrada la relectura integral.
```

```yaml
agente_ad_hoc:
  id: AH-02
  nombre: Evaluación de sistemas LLM y RAG
  señal_que_lo_justifica: { descripción: "probar todo y probar los conceptos contra un modelo no determinista", ubicación: "prompt de origen §Solicitudes párr. 2, última oración" }
  pregunta_que_responde: ¿Las pruebas de Examples/ y Demos/ demuestran lo que la guía afirma, con aserciones que no dependen del azar, y la guía enseña a evaluar calidad de respuesta y de recuperación con herramientas vigentes de .NET?
  competencia: evaluación de LLM (métricas, LLM-as-judge y sus límites), evaluación de recuperación, bibliotecas de evaluación de .NET, diseño de aserciones sobre salidas no deterministas (R-LLM). NO opina sobre seguridad, forma ni arquitectura.
  evidencia_admisible: [E1, E2, E3, E4]
  tope_hallazgos: 5
  se_disuelve_cuando: N5 y N6 validados y cerrada la relectura integral.
```

### 8.4 Comisiones por núcleo (propuesta)

| Núcleo | Comisión que lo juzga en primer término |
|---|---|
| N0 | didáctica, edición, requisitos |
| N1 | arquitectura, experto en IA, abogado del diablo |
| N2 | senior .NET, experto en IA, implementador |
| N3 | experto en IA, senior .NET, AH-01, AH-02 |
| N4 | experto en IA, arquitectura, AH-01, senior .NET |
| N5 | Operación y entrega, AH-01, AH-02, verificación |
| N6 | todo el panel |

### 8.5 Techo del panel: apartamiento declarado

El marco fija núcleo + 5 variables/ad hoc por ciclo (M§4.1.4). Este caso tiene 5 perfiles variables impuestos por el PO (didáctica, edición, senior .NET, IA, arquitectura; el desarrollador se funde con el implementador) más hasta 3 por señal (AH-01, AH-02, Operación y entrega) y el formal automático: hasta 9. **Apartamiento:** los perfiles del PO son restricción dura (E4: DC-02) y no consumen cupo; el techo de 5 rige para los que entran por señal, y con 4 queda lugar para una convocatoria en caliente (M§5.2). Se informa en el cierre (`apartamientos_del_marco`).

### 8.6 Mesa de convocatoria

Los 5 jueces (§9.4) votan cada especialidad de §8.3 con `CONVOCAR`, `NO_CONVOCAR` o `INSTANCIAR_AD_HOC` (sobre la carta, no sobre la idea). Mayoría simple; ante empate se convoca. El registro completo va a `Bitacoras/Mesa/Ciclo-1/00-Convocatoria.md` y se contrasta al cierre contra los hallazgos reales (M§5.1.c).

---

## 9. El ciclo

### 9.1 Base mecánica (antes de cualquier agente y después de cada aplicación)

| # | Chequeo del marco (M§3) | En esta guía | Cómo se corre |
|---|---|---|---|
| C1 | Sin afirmaciones contradictorias | Ninguna recomendación de un núcleo contradice a otra; las tensiones de BIT-16-02 §4 están resueltas en N6. | Lectura cruzada guiada por la tabla de tensiones. |
| C2 | Todo requisito con ID, criterio y prueba | Toda S-01…S-17 y toda pregunta de §7 tiene sección; toda afirmación técnica tiene fuente con versión y fecha o experimento. | Tabla de trazabilidad de BIT-16-02 §5; `grep '\[C:'` en la guía = 0. |
| C3 | Toda tarea referencia un requisito | Toda sección de la guía responde a una solicitud o a un núcleo. | Trazabilidad inversa. |
| C4 | Sin huérfanos | Todo núcleo tiene sección, preguntas guía con respuesta y al menos un ejemplo; todo directorio de `Examples/` y `Demos/` es citado y toda cita apunta a algo existente. | Script de enlaces + listado de directorios. |
| C5 | Glosario unívoco | *agente*, *herramienta*, *orquestación*, *workflow*, *RAG*, *embedding*, *chunk*, *contexto*, *prompt*, *capa de IA* con un solo sentido. | Búsqueda de cada término. |

Compuertas adicionales, también E1: `dotnet build` y `dotnet test` de cada proyecto de `Examples/` y `Demos/` en `mcr.microsoft.com/dotnet/sdk:10.0` (con la versión de imagen registrada); pruebas de integración contra el modelo con registro R-LLM; anclas e índice coherentes; mermaid que renderiza; `grep` R-PRIV en cero (IPs RFC 1918, lista de identificadores en memoria, cadenas con forma de credencial); `.gitignore` presentes (DC-08); versiones de los `PackageReference` iguales a las que cita la guía.

> **2026-10-28 — Parche P-01 (ciclo 1).** La compuerta R-PRIV es el script `Bitacoras/Mesa/Ciclo-1/aplicacion/rpriv.sh`, que se corre así:
>
> ```bash
> RPRIV_LISTA=<archivo privado fuera del repo> rpriv.sh <raíz> > rpriv-$(date +%F).txt
> ```
>
> Busca, en todo `<raíz>` (incluida `Mesa/`, sin `bin/` ni `obj/`), cuatro patrones:
> `/home/[A-Za-z0-9._-]+`;
> direcciones de host del rango <rango-cgnat> (`(^|[^0-9.])100\.(6[4-9]|[7-9][0-9]|1[01][0-9]|12[0-7])\.[0-9]{1,3}\.[1-9][0-9]{0,2}([^0-9.]|$)`);
> direcciones de host RFC 1918 con el mismo criterio de último octeto distinto de cero (así quedan afuera las versiones de ensamblado `10.11.0.0` y la notación de red);
> `usuario@IP` (`[A-Za-z0-9._-]+@[0-9]{1,3}(\.[0-9]{1,3}){3}`).
> Además busca, como palabra completa, cada identificador de `RPRIV_LISTA` (hostnames de la LAN y de la tailnet, usuarios, nombres de contenedores y de repos privados). Si `RPRIV_LISTA` falta, sale con código 2.
> El criterio de cierre es «el script sale con 0 sobre la raíz de la guía» y «los cuatro patrones dan 0 sobre `OUTPUTs/`». Los identificadores de `RPRIV_LISTA` sobre `OUTPUTs/` bloquean sólo si la presidencia los declara R-PRIV en la bitácora (C1-39). Mientras tanto, el recuento se informa y no bloquea. La salida queda guardada con fecha. Un recuento escrito en prosa no cierra la compuerta.
> **Ajustes vinculantes incorporados (juez de evidencia):** (1) el cierre de los patrones 2 y 3 es `([^0-9.]|\.([^0-9]|$)|$)`, para atrapar la dirección seguida de punto final; (2) el script informa `patrones=` e `identificadores=` por separado y el cierre sobre `OUTPUTs/` lee `patrones=0`. **Condición del juez de riesgo:** ningún commit de `OUTPUTs/` mientras `identificadores > 0`, salvo un dictamen fechado de la presidencia que declare esos identificadores no R-PRIV en la bitácora. También se redactó en este archivo una ruta del home (l. 116), con el mismo criterio.

> **2026-10-28 — Parche P-10 (ciclo 1).** La compuerta E1 de `Examples/` y `Demos/` es «clon limpio + comando del README». Se corre en una carpeta nueva fuera del workspace, sin caché NuGet previa, con el servidor levantado por la receta del Anexo E y la red `ia-guia`.

> **2026-10-28 — Parche P-28 (ciclo 1).** La fila C2 cita «BIT-16-02 §5» por la trazabilidad, que está en §6, y el despacho cita §6 por la estructura, que está en §7. Desde el ciclo 1, la trazabilidad es la de BIT-16-04 §8 (P-28) y la estructura es la de BIT-16-04 §8 (P-07).
> **Ajuste de la aplicación (posición MEJORAR_PLAN del juez de coherencia histórica):** el corrimiento de anclas no está sólo en la fila C2. Tabla completa de las citas de este documento a BIT-16-02:
>
> | Dónde (REED-16) | Cita | Sección real de BIT-16-02 | Vigente desde el ciclo 1 |
> |---|---|---|---|
> | §6.3 (l. 242), §9.1 C1 | tensiones §4 | §5 | BIT-16-04 §2 (tensiones 1–8) |
> | §9.1 C2 | trazabilidad §5 | §6 | BIT-16-04 §8 (Parche P-28) |
> | §9.2, §14 punto 5 | orden §7 | §8 | sin cambio |
> | §11 fila «Guía final» | estructura §6 | §7 | BIT-16-04 §8 (Parche P-07) |

> **2026-10-28 — Parche P-32 (ciclo 1).** La compuerta de versiones consulta nuget.org, no la guía. Para cada paquete del Anexo D usa el índice de registro y `flatcontainer` (como `R2-deprec.py`) y registra estado, versión, `published`, `deprecation` y `vulnerabilities`. La columna preview dice «última preview publicada al <fecha>» o se quita. Los `PackageReference` de `Examples/` y `Demos/` tienen que ser iguales a esa tabla. `dotnet list package --vulnerable --include-transitive` da 0 avisos, o cada aviso está aceptado con su GHSA, su severidad y su motivo en el Anexo D. DC-08 se chequea por contenido: cada `.gitignore` excluye `bin/`, `obj/`, `*.db` y los almacenes vectoriales generados. No alcanza con que exista. La compuerta se corre el día de la publicación, y la imagen `ollama/ollama` de P-10 entra en ella.

> **2026-10-28 — Parche P2-01 (ciclo 1, ronda 2).** Completa P-01 (c) (C1-01, opción A). La compuerta R-PRIV pasa a ser `Mesa/Ciclo-1/Ronda-2/aplicacion/rpriv.sh`, que hace lo mismo que la versión de P-01 y suma un tercer recuento, `cabeceras=`: los objetos `"<clave-de-cabeceras>":{…}` **no vacíos** dentro de capturas de cuerpo (`*.jsonl`, `*.json`, `*.ndjson`, `*.txt`, `*.log`). Motivo: OllamaSharp 5.5.0 serializa `ChatRequest.<clave-de-cabeceras>` en el cuerpo de `/api/chat` y `/api/embed`, así que un encabezado por pedido con una credencial queda dentro de cualquier captura del cuerpo, donde los cuatro patrones de P-01 no lo ven (Consulta Senior .NET, PC-03, `evidencia-senior-dotnet/R2-cuerpo-salida.txt` caso [C]). Los objetos sintéticos de esa sonda se declaran, por valor exacto, en `RPRIV_SINTETICOS` y no cuentan.
> **Criterio de cierre**, sin cambios de fondo respecto de P-01 y con el dictamen §2: (1) sobre la raíz de la guía, `Examples/` y `Demos/`, el script sale con 0 (`patrones=0 identificadores=0 cabeceras=0`); (2) sobre `OUTPUTs/`, `patrones=0` y `cabeceras=0` siempre; `identificadores` se permite en la bitácora mientras no haya commit, y debe dar 0 en el barrido que el dictamen §2 pone como condición del primer commit de `OUTPUTs/`. Cierra **la salida guardada del comando** con fecha. Dejar un archivo fuera del commit no cierra la compuerta: un dato que no se publica sigue estando.
> **Ajustes vinculantes incorporados (juez de evidencia):** (1) el patrón de cabeceras es `CH='\\?"<clave-de-cabeceras>\\?"[[:space:]]*:[[:space:]]*\{([[:space:]]*[^}[:space:]][^}]*\}|[[:space:]]*$)'`, que cubre JSON escapado, con espacios e indentado y sigue ignorando `{}` y `{ }`; (2) la verificación suma los cuatro casos de `Ronda-2/evidencia-aprobacion-evidencia/V-rpriv-casos.sh` (1, 1, 1 y 0); (3) la `RPRIV_LISTA`, también la de prueba, vive siempre fuera de la raíz que se barre.
> **Ajuste de la aplicación** (posiciones `MEJORAR_PLAN` de impacto y de riesgo, en minoría, incorporadas por ser mecánicas): el recuento de cabeceras no distingue mayúsculas (`grep -i`), así una clave en camelCase también cuenta. El Markdown de la guía, `Examples/` y `Demos/` no lo cuenta el script, porque sobre `OUTPUTs/` un patrón multilínea arrastra párrafos (juez de riesgo, §0.1): lo cubre el barrido `<clave-de-cabeceras>` de RV-01 ampliada (`Mesa/Ciclo-1/06-Plan-De-Redaccion.md` §10). Casos corridos el 2026-10-28: `Mesa/Ciclo-1/Ronda-2/aplicacion/rpriv-casos-2026-10-28.txt` (8 de 8 como se esperaba: cinco rojos de cabecera, dos verdes y un rojo de patrón). Salida antes y después: `Mesa/Ciclo-1/Ronda-2/aplicacion/rpriv-2026-10-28-{antes,despues}.txt`.






### 9.2 Trabajo por núcleo

En el orden de BIT-16-02 §7, cada núcleo: (1) **investigación**: resuelve sus `[C]` contra la fuente vigente y corre los experimentos de su plan, guardando el código en `Examples/` y la salida en su registro; (2) **borrador** de la sección en su registro; (3) **panel a ciegas** (M§5.2): cada especialista cuyo mandato lo alcanza emite hasta 7 hallazgos (esquema M§8) y hasta 3 ítems de «lo que revisé y está bien»; fuera de su mandato emite una solicitud de convocatoria; una sola ronda en caliente por ciclo; (4) relator, jurado, auditoría, aprobación, aplicación y verificación (§9.3–§9.7).

### 9.3 Relator (consolida, no vota)

Deduplica, agrupa por raíz común, detecta contradicciones **entre especialistas** (p. ej., el senior .NET recomienda una abstracción y el experto en IA la considera insuficiente para agentes) y las eleva como ítem separado. Salida: `Mesa/Ciclo-n/01-Consolidado.md`.

### 9.4 Jurado de cinco (M§4.3)

Funciones fijas: **evidencia**, **impacto** (qué le pasa al lector si no se corrige), **costo/beneficio**, **coherencia histórica** y **riesgo e irreversibilidad**. Voto por hallazgo: `PROCEDE`, `NO_PROCEDE` o `INSUFICIENTE`. Quórum 5; mayoría ≥3; empate en primera ronda → `INSUFICIENTE`; en segunda → escalada (§12, tipo 6). Veto acotado del juez de riesgo sólo ante corrección irreversible y severidad ≤ S3. Voto sin fundamento no cuenta. Perito sin voto cuando haga falta conocimiento técnico. Más de 80 % de votos 5-0 → ciclo sospechoso de homogeneidad; el abogado del diablo revisa los `NO_PROCEDE` (M§9). Salida: `Mesa/Ciclo-n/02-Voto-<juez>.md`.

### 9.5 Cuerpo auditor (diseña, no aprueba)

Por hallazgo `PROCEDE`: texto exacto a reemplazar o agregar, **capa** (pedido, núcleo, laboratorio, demo o guía), derivados a revalidar, criterio de verificación y plan de reversión. Parches sobre la misma sección se fusionan antes de aprobarse. Salida: `Mesa/Ciclo-n/03-Parches.md`.

### 9.6 Aprobación (M§5.5)

`APLICAR`, `MEJORAR_PLAN` (máximo 2 vueltas), `NO_APLICAR` (deuda declarada) o `ESCALAR`. Chequeo obligatorio: **¿el parche corrige en la capa donde nació el defecto?** Una afirmación falsa en la guía que viene de un núcleo mal investigado se corrige en el registro del núcleo (y en su ejemplo) y después se propaga. Salida: `Mesa/Ciclo-n/04-Aprobacion-<juez>.md`.

### 9.7 Aplicación y verificación

Se aplica, se corre el criterio de verificación (recompilar, re-ejecutar la prueba contra el modelo, re-correr el chequeo) y se re-corren las compuertas de §9.1. Si falla, se revierte el parche y el hallazgo vuelve como `regresión`. Changelog hallazgo → veredicto → parche → verificación → versión (sha256 y líneas) en `Mesa/Ciclo-n/05-Aplicacion.md`.

---

## 10. Relectura integral obligatoria

Pedido literal del PO (S-14, DC-03): **una vez finalizado el documento, la mesa lo vuelve a analizar completo y corrige edición y compresión, ajustando su coherencia.** Es un ciclo propio sobre la guía integrada, leída de punta a punta como la leerá el lector, y no lo reemplazan las revisiones por núcleo.

- **Panel**: todo el panel vigente, a ciegas, sobre la guía entera, los ejemplos y la demo.
- **Edición**: jerarquía, índice, voz única, formato uniforme de snippets y tablas, anexo de referencias completo con versión y fecha.
- **Compresión** (SUP-07): definiciones antes del uso, ejemplos que iluminan, respuestas que forman criterio; sin repeticiones entre secciones ni mermaid que duplique la prosa. Recortar redundancia no autoriza recortar evidencia.
- **Coherencia**: los cinco chequeos de §9.1 sobre la guía completa; mismas versiones de paquetes en el texto y en los `.csproj`; el marco de referencia usado igual en todas las secciones.
- Las correcciones siguen jurado → auditoría → aprobación → verificación. Ciclo 3 sólo si no se cumplió el criterio de rendimientos decrecientes (§13).

---

## 11. Dónde va cada salida

Raíces: `BIT = /LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/Guides/16-IA-Layer/OUTPUTs/Bitacoras`, `GUIA = /LAB/Lab-Documentos/Lab-Documentos/Guides/IA/Dot-Net-Integration-AI-Layer-Guide`.

| Salida | Ubicación | Notas |
|---|---|---|
| Índice de la bitácora | `BIT/README.md` | existente; se actualiza al cierre |
| Contrato de entrada | `BIT/00-Contrato-De-Entrada.md` | existente |
| Descomposición conceptual | `BIT/01-Descomposicion-Conceptual.md` | existente |
| Cohesión global | `BIT/02-Cohesion-Global.md` | existente; se completa en la fase de plan y al integrar |
| Marco de referencia (N0) | `BIT/03-Marco-De-Referencia.md` | existente |
| Registro por núcleo | `BIT/Nucleos/N0-…md` … `BIT/Nucleos/N6-…md` | estructura de §6.2 |
| Cuaderno de integración | `BIT/04-Integracion.md` | tensiones resueltas y reparaciones en origen |
| Convocatoria | `BIT/Mesa/Ciclo-1/00-Convocatoria.md` | votos, cartas, descartes, postergados |
| Informes del panel (verbatim) | `BIT/Mesa/Ciclo-n/Informe-<rol>.md` y `evidencia-<rol>/` | a ciegas |
| Relatoría | `BIT/Mesa/Ciclo-n/01-Consolidado.md` | |
| Veredictos | `BIT/Mesa/Ciclo-n/02-Voto-<juez>.md` | votos con fundamento |
| Parches | `BIT/Mesa/Ciclo-n/03-Parches.md` | |
| Aprobación | `BIT/Mesa/Ciclo-n/04-Aprobacion-<juez>.md` | |
| Aplicación, verificación y changelog | `BIT/Mesa/Ciclo-n/05-Aplicacion.md` y `aplicacion/` | |
| Apuntes, debates, precompilaciones (S-15) | `BIT/Nucleos/` y `BIT/Mesa/Ciclo-n/` | insumo de edición, no entregable |
| Escaladas | `BIT/Escaladas.md` | sólo si hay |
| Cierre | `BIT/05-Cierre.md` | §13 |
| Ejemplos ejecutables | `GUIA/Examples/<NN>-<núcleo>-<tema>/` | cada uno con su comando de contenedor y su `README.md` |
| Demo | `GUIA/Demos/<nombre>/` | solución .NET 10 propia con la temática Movilidad Urbana; `README.md` con cómo correrla |
| Exclusiones | `GUIA/Examples/.gitignore`, `GUIA/Demos/.gitignore` | `bin/`, `obj/`, `*.db`, almacenes vectoriales generados |
| **Guía final** | `GUIA/Dot-Net-Integration-AI-Layer-Guide.md` | un solo `.md`, estructura de BIT-16-02 §6 |

La guía no referencia la bitácora (es autocontenida) y sí referencia `Examples/` y `Demos/` con rutas relativas; la bitácora sí referencia la guía. Nada de lo escrito contiene datos de la infraestructura del PO. Toda la bitácora lleva frontmatter con `doc_id` estable.

---

## 12. Escalada al PO

**Regla general: la mesa decide sola** (R-AUTO). Composición del panel, redacción, estructura, elección técnica dentro de las restricciones (qué abstracción, qué almacén vectorial, qué marco de agentes), orden de los núcleos y contenido de ejemplos y demo **nunca** se escalan.

| # | Disparador (M§6) | Ejemplo en este caso |
|---|---|---|
| 1 | Ambigüedad de intención irresoluble | El pedido admite dos destinatarios incompatibles de la guía y ninguna evidencia desempata. |
| 2 | Conflicto entre restricciones duras | S-17 exige probar contra el servidor de la LAN y no está accesible, y R-PRIV impide documentar cómo se llegó a él. **Bloquea y sale en el momento** (con default: probar contra Ollama en contenedor local y registrarlo). |
| 3 | Cambio de alcance | Responder una solicitud exigiría desplegar en la nube, entrenar un modelo o tocar Lab-E2E.WebBlazor. **Bloquea y sale en el momento.** |
| 4 | Irreversibilidad con impacto real | Descargar, borrar o reconfigurar modelos en el servidor Ollama de la LAN. |
| 5 | Consecuencia externa | Usar un proveedor de nube con costo o enviar datos fuera del laboratorio. |
| 6 | Empate persistente del jurado | Dos rondas sin mayoría sobre el mismo hallazgo. |
| 7 | Reapertura de decisión cerrada | El panel sostiene con E1/E2 que una DC-0n es contradictoria. |

Ante duda: no se escala; se aplica el default y se registra en `deuda_declarada`. Formato de M§6, agrupadas al final del ciclo salvo tipos 2 y 3.

---

## 13. Criterios de parada y bloque de cierre

Cierra cuando se cumple **cualquiera** (M§7): no quedan S1 ni S2 abiertos **y** la relectura integral se ejecutó al menos una vez; rendimientos decrecientes (< 20 % de hallazgos válidos nuevos respecto del ciclo anterior); se agotó `ciclos_max` (3); hay una escalada bloqueante sin responder. Ningún criterio exime de la relectura integral: si el presupuesto se agota antes, ella consume el último ciclo.

En `BIT/05-Cierre.md`:

```yaml
cierre:
  version_final: { guia_sha256: <...>, lineas: <n>, fecha: <...> }
  ciclos_ejecutados: <n>
  nucleos: { validados: [N0..N6], a_revalidar: [<...>] }
  panel:
    nucleo_permanente: [requisitos, verificacion, implementador_ingenuo, abogado_del_diablo]
    perfiles_del_po: [<rol: hallazgos_procedentes>]
    convocados_por_señal: [<rol: hallazgos_procedentes>]
    ad_hoc: [<id: pregunta que respondió y qué aportó>]
    descartados: [<rol: motivo>]
    postergados_por_cupo: [<rol>]
    aporte_nulo: [<roles a no reconvocar>]
  hallazgos: { detectados: n, procedentes: n, aplicados: n, revertidos: n, descartados_C: n }
  coherencia: { contradicciones: 0, solicitudes_sin_seccion: 0, afirmaciones_sin_evidencia: 0, secciones_huerfanas: 0, terminos_ambiguos: 0 }
  compuertas: { builds_ok: n/n, tests_ok: n/n, enlaces_rotos: 0, mermaid_invalidos: 0, fugas_rpriv: 0, gitignore: ok }
  pruebas_contra_modelo: [<ejemplo: modelo@digest: parámetros: corridas: tasa_de_exito>]
  relectura_integral: { ejecutada: true, correcciones_edicion: n, correcciones_compresion: n, correcciones_coherencia: n }
  apartamientos_del_marco: [<p. ej., techo del panel §8.5, con motivo>]
  supuestos: [SUP-01..SUP-08 y los que se agreguen]
  deuda_declarada: [<hallazgos NO_APLICAR con motivo>]
  escaladas_pendientes: [<...>]
  capas_a_revalidar: [<...>]
```

---

## 14. Prompt de arranque

> Vas a ejecutar este prompt siguiendo el marco de Mesa Evaluadora. Reglas no negociables:
>
> 1. Leé completo el prompt de origen, esta reedición, el marco, el Profile, el RuleSet, las Rules y los registros existentes de la bitácora (README, 00–03) antes de producir nada.
> 2. Validá el contrato (§5). Si falta un campo, es tu primer hallazgo y lo resolvés con un supuesto registrado.
> 3. Relevá el modelo disponible en el servidor Ollama de la LAN (etiqueta y *digest*) y registralo sin el endpoint. Corré las compuertas de §9.1 antes de convocar a nadie y después de cada aplicación.
> 4. Armá el panel: núcleo permanente + los seis perfiles del PO + lo que la mesa de convocatoria vote sobre §8.3. Registrá convocados, descartes con motivo y postergados.
> 5. Trabajá por núcleo en el orden de BIT-16-02 §7, con su registro en `Nucleos/`, y cerrá con la integración en N6 reparando en la capa de origen.
> 6. Panel a ciegas y en paralelo; nadie opina fuera de su mandato. Todo hallazgo declara evidencia. Verificá versiones, estados GA/preview y deprecaciones en la fuente vigente: tu conocimiento previo no es evidencia. Las pruebas contra el modelo cumplen R-LLM.
> 7. Jurado de cinco con funciones fijas y voto fundado por hallazgo; auditores con parche de texto exacto, sin votar lo propio; aprobación con cuatro resultados.
> 8. Terminada la guía, ejecutá la relectura integral (§10).
> 9. Decidí sin consultar salvo los siete disparadores de §12. Nunca escribas datos de la infraestructura del PO.
> 10. Pará según §13 y emití el bloque de cierre.
>
> Entregá: la guía, `Examples/` y `Demos/` con sus `.gitignore`, la bitácora completa y las escaladas si las hubiera. Al PO, un resumen con el bloque de cierre; la deliberación queda en la bitácora.

---

## 15. Trazabilidad con el prompt de origen

| Elemento del prompt de origen | Dónde quedó |
|---|---|
| Encabezado, invocación y overview | Encabezado de esta reedición |
| Analizar y describir `AI-Layer.png` como concepto teórico | S-01; §1.1; N1 |
| Recabar marco teórico y práctico vigente en .NET | S-02; R-EVID; N1, N2 |
| Leer la ia-db de Lab-E2E.WebBlazor (Web y ApiWeb) como base del ejemplo | §1.2; S-09; DC-05; N6 |
| Objetivo: iniciar guías, ejemplos y demostración práctica | S-03; §5 `objetivo`; §11 |
| Estrategias y casos de integración en el stack .NET | S-04; N1, N2, N3; §7 preguntas 1–3 |
| Creación de agentes | S-05; N4; §7 pregunta 4 |
| Definiciones, ejemplos, snippets, preguntas y respuestas | S-06…S-08; R-PO-1, R-PO-3; §4.1 |
| Demo basada en Lab-E2E.WebBlazor | S-09; N6; §11 `Demos/` |
| LangGraph en el ecosistema .NET | S-10; SUP-04; N4; §7 pregunta 4 |
| Reeditar el prompt sobre Mesa-Evaluadora y plantear el caso | S-11; este documento; §7 |
| Mesa: didáctica, edición bibliográfica, senior .NET, IA, arquitectura, desarrollo | S-12; DC-02; §8.2 |
| Analizar si hace falta otro experto | S-13; §8.3 (AH-01 recomendado, AH-02) |
| Relectura del documento finalizado: edición, compresión, coherencia | S-14; DC-03; §10 |
| Apuntes, borradores, debates y precompilaciones | S-15; §11 |
| Rutas de guía, ejemplos y demo | S-16; §5 `ruta/id`; §11 |
| Probar todo contra la API local con Qwen | S-17; SUP-01, SUP-03; R-LLM; R-HOST; §9.1 |
| Regla de forma: jerarquía, índices, definiciones, ejemplos, mermaid | R-PO-1 |
| Autocontenido, no delta | R-PO-2 |
| Ejemplos, snippets, preguntas guía con respuesta formadora de criterio | R-PO-3 |
| Descomposición conceptual completa | R-PO-4; §6 |
| Registros retomables (ruta escrita: la de la guía) | R-PO-5; SUP-02; §6.2; §11 |
| No inventar información | R-PO-6; R-EVID |
| Toda afirmación con evidencia verificable | R-PO-7; R-EVID; R-LLM; §5.1 |
| Profile Study-Guide-Documentation | §4.1 |
