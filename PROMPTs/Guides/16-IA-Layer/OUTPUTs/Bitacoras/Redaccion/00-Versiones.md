---
doc_id: BIT-16-RED-00-VER
doc_type: borrador-de-anexo
title: Versiones verificadas y señales de obsolescencia (Anexo F de la guía 16)
status: vigente para la redacción
origin: agent (preparación de la redacción)
last_review: 2026-10-27
audience: [redactores, relectura integral]
traces: [BIT-16-04 v3 §C Anexo F, §E.1 (tabla de versiones), BIT-16-06 §2 AC-6, Examples/Directory.Packages.props, Demos/MovilidadUrbana.Asistente/Directory.Packages.props, Compuertas/ac6.excepciones, BIT-16-N2 §3, BIT-16-N3 §3, BIT-16-N4 §3.1, BIT-16-N5 §3.1, BIT-16-N6 §3, Mesa/I-01]
---

# Versiones verificadas y señales de obsolescencia (Anexo F)

Esta es **la única tabla de versiones de la guía** (H-045): las secciones §5, §7 y §9 remiten acá y no llevan tabla propia. Las versiones salen de los dos `Directory.Packages.props` (`Examples/` y `Demos/MovilidadUrbana.Asistente/`), que tienen gestión central y *pinning* de transitivos; el estado y la fecha, de la re-verificación del día de la construcción (2026-10-27) o, para lo que esa re-verificación no cubrió, de los dossiers (2026-10-25/26).

## Índice

- [Cómo se lee](#cómo-se-lee)
- [1. Paquetes que usan los ejemplos y la demo](#1-paquetes-que-usan-los-ejemplos-y-la-demo)
- [2. Filas de estado: lo que la guía no usa y por qué](#2-filas-de-estado-lo-que-la-guía-no-usa-y-por-qué)
- [3. Invariante de versiones y su excepción](#3-invariante-de-versiones-y-su-excepción)
- [4. Entorno de las corridas (propuesta de bloque aparte)](#4-entorno-de-las-corridas-propuesta-de-bloque-aparte)
- [Respaldo interno (no va a la guía)](#respaldo-interno-no-va-a-la-guía)

## Cómo se lee

- **Estado**: GA, preview, alpha, deprecado (marca de deprecación en el registro de nuget.org), retirado (lo declara el fabricante) o archivado (el repositorio lo declara). «Estable» sin más quiere decir que la versión no tiene sufijo de preview y que ningún dossier registró su estado de soporte.
- **Fecha de verificación**: el día en que se consultó la fuente. 2026-10-27 es la re-verificación de la construcción contra la API de contenido de nuget.org [REF-187] y la restauración del build (SDK 10.0.403).
- **Fuente**: el `[REF-nn]` del registro único (`00-Referencias.md`). La columna de respaldo interno de la última sección dice de qué dossier o evidencia sale cada fila; esa columna no se copia a la guía.
- Las versiones se citan en la guía **sólo desde esta tabla** (plan §E.1). Si una sección necesita nombrar una versión, remite al ancla `anexo-f`.

## 1. Paquetes que usan los ejemplos y la demo

| Paquete | Versión | Estado | Fecha de verificación | Fuente |
|---|---|---|---|---|
| `Microsoft.Extensions.AI` | 10.11.0 | GA, con tipos marcados `[Experimental]` | 2026-10-27 | [REF-187], [REF-44] |
| `Microsoft.Extensions.AI.Abstractions` | 10.11.0 (fijado también como transitivo) | GA | 2026-10-27 | [REF-187], [REF-44] |
| `Microsoft.Extensions.AI.OpenAI` | 10.11.0 | GA; arrastra `OpenAI` 2.14.0. Sólo en 02 | 2026-10-27 | [REF-187], [REF-49] |
| `OpenAI` (transitivo de `Microsoft.Extensions.AI.OpenAI`) | 2.14.0 | GA | 2026-10-25 | [REF-187], [REF-49] |
| `OllamaSharp` | 5.5.0 | GA, de la comunidad; implementa `IChatClient` e `IEmbeddingGenerator` | 2026-10-27 | [REF-187], [REF-50] |
| `Microsoft.Extensions.VectorData.Abstractions` | 10.11.0 (fijado también como transitivo) | GA | 2026-10-27 | [REF-187], [REF-89] |
| `CommunityToolkit.VectorData.InMemory` | 1.0.1 | GA; recomendado sólo para prototipos | 2026-10-27 | [REF-187], [REF-89], [REF-98] |
| `Microsoft.Extensions.AI.Evaluation` | 10.11.0 (fijado también como transitivo) | GA | 2026-10-27 | [REF-187], [REF-151] |
| `Microsoft.Extensions.AI.Evaluation.Quality` | 10.11.0 | GA | 2026-10-25 | [REF-187], [REF-151] |
| `Microsoft.Extensions.AI.Evaluation.Reporting` | 10.11.0 | GA | 2026-10-25 | [REF-187], [REF-152] |
| `Microsoft.Extensions.Compliance.Abstractions` | 10.11.0 (fijado también como transitivo) | estable | 2026-10-27 | [REF-187] |
| `Microsoft.Agents.AI` | 1.26.0 | GA (1.0.0 en nuget.org el 2026-04-02; anuncio del 2026-04-03) | 2026-10-27 | [REF-187], [REF-43], [REF-117] |
| `Microsoft.Agents.AI.Abstractions` | 1.26.0 | GA | 2026-10-25 | [REF-187], [REF-117] |
| `Microsoft.Agents.AI.Workflows` | 1.26.0 | GA | 2026-10-27 | [REF-187], [REF-124] |
| `Microsoft.Agents.AI.Workflows.Generators` | 1.26.0 | GA; sin él, un executor con `[MessageHandler]` no compila (`CS0534`) | 2026-10-25 | [REF-187], [REF-126] |
| `ModelContextProtocol` | 2.3.0 | GA (1.0.0 el 2026-02-25; 2.0.0 el 2026-07-28) | 2026-10-27 | [REF-187], [REF-130] |
| `ModelContextProtocol.AspNetCore` | 2.3.0 | GA | 2026-10-25 | [REF-187], [REF-130] |
| `Microsoft.SemanticKernel` | 1.81.0 | GA, en mantenimiento (correcciones críticas y de seguridad); sucesor declarado: Microsoft Agent Framework. Sólo en 14 | 2026-10-27 | [REF-187], [REF-136], [REF-137] |
| `Azure.AI.OpenAI` (transitivo de `Microsoft.SemanticKernel` 1.81.0) | 2.9.0-beta.1 | **preview, dependencia transitiva preliminar de SK, no fijada**: forzar otra versión cambiaría la dependencia que SK 1.81.0 declara, y 14 no usa Azure OpenAI. Última estable: 2.1.0 (2024-12-06). Es la única preview que admite el invariante (sección 3) | 2026-10-27 | [REF-187] |
| `OpenTelemetry` | 1.20.1 | GA | 2026-10-27 | [REF-187] |
| `OpenTelemetry.Extensions.Hosting` · `OpenTelemetry.Exporter.OpenTelemetryProtocol` | 1.20.1 | GA | 2026-10-25 | [REF-187] |
| `OpenTelemetry.Exporter.InMemory` (sólo 17) | 1.20.1 | estable | 2026-10-27 | [REF-187] |
| `OpenTelemetry.Api` (sólo transitivo) | 1.20.1, **fijado también como transitivo** | estable. Sin el pin, MAF 1.26.0 arrastra 1.18.0 en 10 y 12 mientras 17 resuelve 1.20.1, y la familia queda en dos versiones | 2026-10-27 | [REF-187] |
| `Microsoft.Extensions.Caching.Memory` | 10.0.14 | GA | 2026-10-27 | [REF-187] |
| `Microsoft.Extensions.Hosting` | 10.0.14, sólo en las consolas (los proyectos web lo traen con el framework compartido) | GA | 2026-10-27 | [REF-187] |
| `Microsoft.EntityFrameworkCore.Sqlite` | 10.0.14 (el caso base fija 10.0.11) | GA en la 10; la 11 está en RC | 2026-10-27 | [REF-187], [REF-186] |
| `NUnit` · `NUnit3TestAdapter` · `Microsoft.NET.Test.Sdk` | 4.3.2 · 5.0.0 · 17.14.0 | **fieles al caso base por decisión**: no son las últimas; migrar no aporta nada a lo que la guía enseña y la alineación con el caso base sí | 2026-10-27 (restauración) | [REF-186] |
| `Microsoft.AspNetCore.OpenApi` · `Scalar.AspNetCore` | 10.0.11 · 2.17.3 | fieles al caso base; sólo en la demo y sólo en Development | 2026-10-27 (restauración) | [REF-186] |
| `Microsoft.AspNetCore.Mvc.Testing` · `NUnit.Analyzers` | 10.0.11 · 4.7.0 | fieles al caso base; sólo en las pruebas de la demo | 2026-10-27 (restauración) | [REF-186] |

## 2. Filas de estado: lo que la guía no usa y por qué

Estas filas responden las preguntas de estado que el plan sacó de las secciones (H-038): «¿sigue sirviendo…?», «¿y AutoGen?», «¿Safety con un modelo local?», «¿puedo confiar en que `gen_ai.*` no cambie?». Cada sección que las necesite remite acá.

| Paquete o componente | Versión | Estado | Fecha de verificación | Fuente |
|---|---|---|---|---|
| `Microsoft.Extensions.AI.Ollama` | ninguna estable; última 9.7.0-preview.1.25356.2 (2025-07-08) | **deprecado** en nuget.org; alternativa: `OllamaSharp` («No further updates, features, or fixes are planned») | 2026-10-25 | [REF-188] |
| `Azure.AI.Inference` | ninguna estable; última 1.0.0-beta.5 (2025-05-14) | **retirado** el 2026-08-26; migrar a OpenAI/v1 | 2026-10-25 | [REF-57], [REF-58] |
| `Microsoft.Extensions.AI.AzureAIInference` | ninguna estable; última 10.0.0-preview.1.25559.3 (2025-11-11) | sin marca de deprecación, pero depende del `Azure.AI.Inference` retirado (abandono **inferido**) | 2026-10-25 | [REF-188] |
| AutoGen (`Microsoft.AutoGen.Core`, `AutoGen.Core`) | 0.4.0-dev.3 (nunca estable) · 0.2.3 | **archivado**: el repositorio declara «Project archived and no longer maintained» y deriva a Microsoft Agent Framework | 2026-10-25 | [REF-141], [REF-188] |
| `Microsoft.Extensions.AI.Evaluation.Safety` | 10.11.0-preview.1.26513.7 | **sólo preview**; usa el servicio de evaluación de Microsoft Foundry: requiere suscripción de Azure y un proyecto. Con un modelo local quedan Quality y NLP | 2026-10-25 | [REF-154], [REF-188] |
| `Microsoft.Extensions.AI.Evaluation.NLP` | 10.11.0-preview.1.26513.7 | sólo preview | 2026-10-25 | [REF-188] |
| `Microsoft.Extensions.DataIngestion` (y `.Abstractions`, `.Markdig`, `.MarkItDown`) | 10.11.0-preview.1.26513.7 | preview | 2026-10-25 | [REF-94], [REF-188] |
| `Microsoft.SemanticKernel.Connectors.InMemory` · `.SqliteVec` | 1.74.0-preview | **deprecados** (motivo `Legacy`): renombrados a `CommunityToolkit.VectorData.*` | 2026-10-25 | [REF-99], [REF-188] |
| `CommunityToolkit.VectorData.SqliteVec` | 1.0.3-preview | preview; depende de `sqlite-vec` 0.1.7-alpha.2.1 | 2026-10-25 | [REF-97], [REF-112] |
| `Microsoft.Agents.AI.Workflows.Declarative` (YAML) | 1.26.0 | GA desde 1.9.0 (2026-06-03) | 2026-10-25 | [REF-43], [REF-188] |
| `Microsoft.Agents.AI.Hosting` | 1.26.0-preview.261023.1 | preview | 2026-10-25 | [REF-188] |
| `Microsoft.Extensions.AI.Templates` (plantilla `aichatweb`) | 10.11.0-preview.3.26513.7 | preview; sin proveedor por defecto desde 10.8.4, porque GitHub Models se retiró el 2026-07-30 | 2026-10-25 | [REF-59], [REF-60], [REF-61] |
| LangGraph | no hay paquete oficial para .NET; Python 1.2.17, JS 1.5.2 | se integra por HTTP con el Agent Server (LangSmith Deployment); NuGet `q=langgraph` sólo devuelve paquetes de terceros | 2026-10-25 | [REF-142], [REF-146], [REF-148], [REF-149], [REF-189] |
| LangChain .NET (tryAGI, `LangChain`) | 0.17.1 | comunitario, sin componente de grafo | 2026-10-25 | [REF-150] |
| `Microsoft.Graph` | 6.9.0 | **no es IA**: cliente de las API de Microsoft 365 («Microsoft Graph Client Library allows you to call Office 365, Azure AD and other Microsoft services…») | 2026-10-26 | [REF-187] |
| Convención `gen_ai.*` de OpenTelemetry | repositorio `semantic-conventions-genai`, rama main | estado Development; se mudó de repositorio en 2026; M.E.AI 10.11.0 emite los nombres de métricas de la v1.41.0 de `semantic-conventions`, que el repositorio nuevo ya cambió | 2026-10-25 | [REF-168], [REF-169], [REF-171] |
| `CommunityToolkit.Aspire.Hosting.Ollama` · `CommunityToolkit.Aspire.OllamaSharp` | 13.6.1 | GA, Community Toolkit. `Aspire.Hosting.Ollama` **no existe** en nuget.org (404) | 2026-10-26 | [REF-175], [REF-176], [REF-188] |
| Especificación MCP | última publicada: 2026-07-28 (`specification/latest` redirige ahí) | la DLL de `ModelContextProtocol.Core` 2.3.0 trae las cadenas de versión 2024-11-05 a 2026-07-28; que el SDK negocie todas es una inferencia **no verificada en la documentación** | 2026-10-26 | [REF-38] |

## 3. Invariante de versiones y su excepción

La compuerta de versiones de la construcción (AC-6) exige que cada familia de paquetes resuelva **una sola versión** en todos los proyectos y que no haya previews, salvo las que una excepción escrita nombre por id y versión exactos. Hay una sola: `Azure.AI.OpenAI` 2.9.0-beta.1, transitivo de `Microsoft.SemanticKernel` 1.81.0 en 14. Una preview no listada hace fallar la compuerta, y también una excepción que ya no se resuelve en ningún proyecto, para que la excepción no quede vencida en silencio. Resultado del 2026-10-27: en `Examples/`, «familias en una sola versión; previews sólo las de la excepción»; en la demo, «familias en una sola versión, sin previews».

Dos límites que la guía declara junto a la tabla:
- Los `Microsoft.Extensions.*` del runtime se resuelven en dos o tres versiones y quedan **fuera** del invariante tal como está escrito.
- El hash de `Examples/Directory.Packages.props` cambió con el pin de `OpenTelemetry.Api`: los registros de corridas anteriores conservan el hash viejo y no se re-corrieron.

## 4. Entorno de las corridas (propuesta de bloque aparte)

No son paquetes y la tabla única es de paquetes. Se proponen como un bloque corto debajo de la tabla, porque cada salida rotulada de la guía las nombra. Lo decide el redactor del Anexo F; si no entran acá, viven en el Anexo E.

| Componente | Versión | Fecha | Fuente |
|---|---|---|---|
| Imagen de compilación | `mcr.microsoft.com/dotnet/sdk:10.0`, SDK 10.0.403 | 2026-10-27 | registro del build de la construcción |
| Servidor Ollama compartido del laboratorio | 0.32.0-rc0 (release candidate), sólo CPU | 2026-10-25/27 | sondeo del entorno; campo `ollama_version` de los registros |
| Ollama propio del laboratorio | 0.40.11 (la última publicada al 2026-10-24) | 2026-10-27 | campo `ollama_version` de los registros; [REF-74] |
| Modelo de chat (compartido) | `qwen3.5:4b`, digest `2a654d98e6fb` | 2026-10-27 | campo `digest` de los registros |
| Modelo de chat y juez (propio) | `qwen2.5:0.5b`, digest `a8b0c5157701` | 2026-10-27 | ídem |
| Modelo de embeddings (propio) | `qwen3-embedding:0.6b`, digest `ac6da0dfba84` | 2026-10-27 | ídem |

## Respaldo interno (no va a la guía)

| Fila | De dónde sale |
|---|---|
| Versiones de la sección 1 | `Examples/Directory.Packages.props` y `Demos/MovilidadUrbana.Asistente/Directory.Packages.props` (lectura del 2026-10-27); fechas 2026-10-27: `Evidencia/Arnes/dep-02-versiones-nuget.txt` (DEP-02: M.E.AI, Abstractions, OpenAI, OllamaSharp, VectorData, Evaluation, Compliance, InMemory, Agents.AI, Workflows, ModelContextProtocol, SemanticKernel, OpenTelemetry, Caching.Memory, Hosting, EF Sqlite) |
| Estados de la sección 1 | N2 §3 (M.E.AI, OpenAI, OllamaSharp, SK, MAF, MCP); N3 §3 (VectorData); N4 §3.1 (Agents.AI.*, Generators, MCP); N5 §3.1 (Evaluation.*, OpenTelemetry, Caching); N6 §3 (InMemory, EF Sqlite) |
| `Azure.AI.OpenAI` 2.9.0-beta.1 y `OpenTelemetry.Api` 1.20.1 | `Evidencia/Cierre-Construccion/ac6-paquetes.cierre.log`; `Compuertas/ac6.excepciones`; BIT-16-06 §2 AC-6 (P2-AC6); plan §E.1, las dos filas nuevas. Última estable de `Azure.AI.OpenAI`: N2 §3 |
| `OpenTelemetry.Exporter.InMemory` | no figura en la tabla de N5 §3.1; la versión la confirma la restauración (17 la resuelve: `ac6-paquetes.cierre.log`). Estado sin registrar en dossier |
| Paquetes del caso base | plan §E.1 (H-055, H2-006); `MovilidadUrbana.ApiWeb.csproj` y `MovilidadUrbana.ApiWeb.Tests.csproj` @ `8fb4c3a`. El plan da las últimas versiones de NUnit, NUnit3TestAdapter y Test.Sdk (5.0.0 · 6.3.1 · 18.11.0 al 2026-10-26) desde el informe del senior .NET de la mesa: no se verificaron en un dossier ni en DEP-02, y por eso esta tabla no las escribe (ver pendientes de `00-Referencias.md`) |
| Filas de estado | N2 §3 (M.E.AI.Ollama, Azure.AI.Inference, AzureAIInference, Templates, GitHub Models); N3 §3 (DataIngestion, M.E.AI.Ollama motivo `Other`); N4 §3.1 (AutoGen, Declarative, Hosting, LangGraph, tryAGI), N4 P7, E01, E05, E06; N5 §3.1 y P3, P6, V1, V8, V9 (Safety, NLP, Aspire, `gen_ai.*`); N6 §3 (SK connectors, SqliteVec); I-01 E-PO-3 y E-PO-4 (Microsoft.Graph, `q=graphlang`); N4 E03 y N1b H18 (MCP) |
| Invariante (sección 3) | BIT-16-06 §2.1 AC-6 y §5 («Deuda que sigue abierta», AC-6); `verificar-build.ac6.cierre.log` |
| Entorno (sección 4) | `Evidencia/Cierre-Construccion/verificar-build.saneo.log` (SDK 10.0.403); `Sondeo-Entorno.md` §0; campos `modelo`, `digest`, `ollama_version` y `maquina` de `Evidencia/R-LLM/*.modelo*.jsonl` y `Evidencia/Sondas/*.jsonl` |
