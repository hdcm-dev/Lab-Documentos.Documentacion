---
doc_id: BIT-16-C1-06
doc_type: plan-de-redaccion
title: Plan de redacción de la guía 16 — vinculante, consolidado de los parches aprobados del ciclo 1
status: vigente
origin: agent
owner: aplicación del ciclo 1 (REED-16 §9.7)
last_review: 2026-10-28
audience: [redacción, presidencia, relectura integral]
traces: [REED-16 §2, §6.2, §7, §9.1, §10, §11, §13; Mesa/Ciclo-1/03-Parches.md; Mesa/Ciclo-1/04-Aprobacion-*.md; Mesa/Ciclo-1/05-Aplicacion.md; BIT-16-03; BIT-16-04 §5–§8; Nucleos/N0b…N6]
---

# Plan de redacción de la guía 16 (vinculante)

Este plan es lo que usa la fase de redacción. Junta en un solo lugar lo que los 44 parches aprobados del ciclo 1 mandan para la guía, `Examples/` y `Demos/`, con los ajustes que pidieron los jueces de aprobación. Manda sobre la tabla de BIT-16-04 §8 (la reemplazó el Parche P-07) y sobre los borradores de los núcleos cuando difieren: los núcleos ya llevan notas del ciclo 1 que los alinean con este plan.

Convención: «P-nn» es un parche del ciclo 1 (`03-Parches.md`); los pendientes de BIT-16-04 §7 se citan como «pendiente P-nn de BIT-16-04». Los ids de bitácora (P-, MI-, R-C, EA-, X…) **no entran a la guía** (RV-08): en la guía rigen ESC-, CTX-, ACT-, D-nn, CASO-1…8, CTRL-01…15 y REF-nnn (P-31).

## Índice

- [0. Cómo se usa](#0-cómo-se-usa)
- [1. Entregables previos a redactar](#1-entregables-previos-a-redactar)
- [2. Estructura final de la guía, sección por sección](#2-estructura-final-de-la-guía-sección-por-sección)
- [3. `Examples/`: tabla canónica](#3-examples-tabla-canónica)
- [4. La demo](#4-la-demo)
- [5. Pendientes de BIT-16-04 asignados](#5-pendientes-de-bit-16-04-asignados)
- [6. Reglas vinculantes RV-01…RV-19](#6-reglas-vinculantes-rv-01rv-19)
- [7. Compuertas de la redacción](#7-compuertas-de-la-redacción)
- [8. Decisiones abiertas y qué hace la redacción mientras tanto](#8-decisiones-abiertas-y-qué-hace-la-redacción-mientras-tanto)
- [9. Trazabilidad mínima](#9-trazabilidad-mínima)

---

## 0. Cómo se usa

1. **Rutas (S-16).** Guía: `/LAB/Lab-Documentos/Lab-Documentos/Guides/IA/Dot-Net-Integration-AI-Layer-Guide/Dot-Net-Integration-AI-Layer-Guide.md`. Ejemplos: `…/Dot-Net-Integration-AI-Layer-Guide/Examples/NN-Nombre/`. Demo: `…/Dot-Net-Integration-AI-Layer-Guide/Demos/MovilidadUrbana.Asistente/`. La guía es autocontenida: no cita la bitácora (REED-16 §11, P-08).
2. **Orden de trabajo.** (a) Los entregables de §1. (b) `Examples/` antes que el texto: un snippet entra a la guía sólo después de compilar en su carpeta con `mcr.microsoft.com/dotnet/sdk:10.0` (RV-18). (c) Las secciones, en el orden de §2, salvo las bloqueadas de §8. (d) La demo. (e) Las compuertas de §7. (f) La relectura integral (REED-16 §10).
3. **Servidor y rótulo (RV-01).** En la guía, los README y los `appsettings*.json`, el servidor es «el servidor Ollama de prueba», alcanzado sólo por `OLLAMA_ENDPOINT` (por defecto `http://localhost:11434`). Toda cifra lleva «medido en la estación de laboratorio (CPU de 4 núcleos sin GPU; contenedor limitado a 4 CPU / 5 GB; Ollama 0.40.11), <fecha>» y sale de la tabla única de `Sondeo-Entorno.md` §R.6 o de un registro R-LLM nuevo (P-21). Ningún host, contenedor del laboratorio, usuario ni dirección.
4. **Modelos.** Chat: `qwen3.5:4b` con razonamiento apagado, **provisional** («elegido entre los que se probaron; no se comparó punta a punta con el 2b», P-36). Embeddings: `qwen3-embedding:0.6b`, 1024 como valor por defecto configurable (P-36, P-43). Humo: `qwen2.5:0.5b`. Nunca literales fuera de `OpcionesDeIA` y `appsettings` (RV-12). Muestreo: el preajuste «Instruct (non-thinking) para tareas generales» de la card (P-33).
5. **Turnos de modelo.** Por `<envoltorio-de-turnos> <recurso-compartido>`, 45 min por turno, con la pared estimada de la tabla de §R.6 (unos 50 s por cada 1000 tokens de contexto antes del primer token). Lo que no entra en un turno se rotula «no medido» y no se omite (P-21). Compilar, por el recurso `build`. Intermedios fuera del workspace, sin `bin/` ni `obj/`.
6. **Precedencia ante una duda.** Este plan > nota del ciclo 1 en el registro > texto previo del registro. Si este plan calla, rige el núcleo con sus notas.

## 1. Entregables previos a redactar

| Archivo | Parche | Qué tiene | Criterio de terminado |
|---|---|---|---|
| `Mesa/Ciclo-2/plan-de-preguntas.md` | P-09 | Una fila por pregunta guía de los nueve núcleos: id de origen (Nn Pk) → sección (§2 de este plan) → ESC/CTX → **una** respuesta vigente → decisión que la condiciona (MI o C1-nn) → fusionada con | filas de origen = salida de `Mesa/Ciclo-1/aplicacion/conteo-preguntas.sh` (80 el 2026-10-28); ninguna fila con dos respuestas; toda sección con al menos una pregunta. N6 P6 con el texto de P-35 |
| `Mesa/Ciclo-2/trazabilidad.md` | P-28 | S-01…S-17, preguntas §7.1–§7.6 de REED-16, PR-1…PR-22, RD-PO-1…4, MD-1…3 → sección → ejemplo o pieza → prueba o R-LLM → estado; filas propias para N0b, N1b, N3b y el Anexo F | ninguna fila sin sección (C2 y C3). Esqueleto en §9 de este plan |
| `Mesa/Ciclo-2/matriz-snippets.md` | P-29 | Una fila por snippet de N1, N2, N3, N3b, N4, N5 y N6: origen → archivo de `Examples/` donde compila → prueba de cableado o R-LLM → estado (compila / corre / no ejecutado) | ninguna fila «compila» sin archivo |
| `Mesa/Ciclo-2/evidencia-a-guia.md` | P-08 | Toda evidencia que sólo vive en la bitácora → destino (ejemplo, R-LLM del Anexo E, fuente E4 del Anexo D o «se omite» con motivo) → archivo | sin evidencia sin destino |
| `Mesa/Ciclo-2/segunda-ronda.md` | P-05, P-13, P-17, P-22, P-23, P-27, P-35 | Segunda ronda votando la opción, en este orden (03-Parches §4.4): C1-48 con la tabla de P-05 → C1-40/C1-62 con PC-13 cerrada → C1-55 y la parte de demo de P-22 → C1-38 con la carpeta de P-17 → C1-53 | mayoría ≥ 3 por ítem; si empata, escalada tipo 6 (REED-16 §12) |
| Definición de *agente* y *workflow* | P-31 | La fija el Experto IA antes de redactar §7, resolviendo N4 §2.2 l. 70 frente a §2.9 l. 104; si no la entrega, consulta dirigida de la presidencia | una definición por término, con sentidos excluidos |
| Consultas PC-01…PC-15 | 03-Parches §5 | Cada PC con su dueño (Senior .NET, Operación, Experto IA, AH-01, AH-02) | PC-13 antes de la segunda ronda de C1-40; PC-02 antes de redactar el orden del pipeline; PC-12 antes de la rama A de P-13 |

## 2. Estructura final de la guía, sección por sección

Estructura de P-07 (presupuesto orientativo, ±20 % por sección; recortar redundancia no autoriza recortar evidencia). Reglas de recorrido de P-07: el Profile se recorre una vez por sección (definición → aplicación por escenario → ejemplos → preguntas → criterios); cada término se define una vez, donde se enseña, con copia en el Anexo C; cada snippet aparece una vez y las demás secciones remiten; un solo molde de definición (qué es, qué problema resuelve, qué no es); §1 no define. Cada sección de tema (§4–§8) lleva su bloque «Aplicación por escenario» con ESC-01…ESC-05, tomado de las tablas de P-04 de N1–N5 (RV-04).

### §0 Índice, ruta de lectura, objetivos por actor y qué presupone la guía (≈ 1 200 palabras)

- **Núcleos fuente:** N0 (BIT-16-03 §3, actores), N0b §3.3.4 (objetivos por actor, PR-14), §3.3 (perfil «AI Engineer», PR-1).
- **Contenidos obligatorios:** índice con anclas; ruta de lectura por actor (ACT-*); objetivos de aprendizaje por actor; qué presupone (C#, ASP.NET Core, Docker) y qué no cubre (CTX-NUBE en profundidad, entrenamiento de modelos); cómo levantar el servidor de prueba, por remisión al Anexo E.
- **Reglas:** RV-08, RV-09; P-06 (PR-1, PR-14).
- **Preguntas previstas:** N0b PG-1, PG-6.
- **Cita:** Anexo E (receta), §1.
- **Cubre:** S-03, S-06; REED-16 §7 (encuadre).

### §1 Mapa conceptual: «estoy en ESC-xx con CTX-yy → qué aplico y en qué sección» (≈ 1 000)

- **Núcleos fuente:** N1, N0; BIT-16-04 §6.3 (árbol de decisión completo, ramas D1–D6).
- **Contenidos obligatorios:** el principio rector «el modelo propone; la aplicación ejecuta, autoriza y valida» (PR-16); el árbol de decisión completo como mapa de la guía; tabla ESC × CTX → sección. Nombra conceptos y remite; no define (P-07 regla 5).
- **Reglas:** P-07; P-06 (PR-12, PR-16); RV-04 no aplica (no es sección de tema).
- **Preguntas previstas:** N1 P1 («¿Mi funcionalidad necesita un LLM, o alcanza con código?»).
- **Cita:** ninguna pieza propia; remite a §4–§9.
- **Cubre:** S-04; REED-16 §7.1 (en parte).

### §2 Por qué ahora: lo que cambió en los LLM y lo hizo posible (≈ 1 500)

- **Núcleos fuente:** N1b (§3.2 tabla de hitos, §3.3 línea de tiempo, §3.4 carriles).
- **Contenidos obligatorios:** contratos programables (herramientas, formato), ventanas, modelos locales; la fila nueva de P-33 «modelos con modo de razonamiento conmutable: el modo es un parámetro de integración (latencia, tokens de salida, muestreo propio)», con la card de Qwen3.5-4B citada con URL y fecha; todo hito con fecha y fuente.
- **Reglas:** RV-09; P-33; P-06 (PR-2).
- **Preguntas previstas:** N1b P1–P7.
- **Cita:** —.
- **Cubre:** S-02.

### §3 Marco de referencia: escenarios, contextos y actores (≈ 2 000)

- **Núcleos fuente:** N0 (BIT-16-03 §1–§4, con la fila N6 de §4.1 reemplazada por el mapa de P-05), N0b §3.1 (mirada de producto), §3.2 (datos para la IA), §3.3 (perfil).
- **Contenidos obligatorios:** ESC-01…ESC-05 con su candidato en Movilidad Urbana (ESC-02: «buscar el requisito por significado», P-22); pares de contexto; actores; matriz núcleo × escenario sin «candidato» (P-05); métricas por escenario (PR-9) con «falso aceptado» sólo en el sentido 1 de P-02 y «no medido»; cuándo la IA aporta valor y cuándo no; datos para la IA (PR-10) sólo con fuente.
- **Reglas:** RV-02, RV-04 (no es sección de tema, pero el marco nombra los ESC que las otras usan), RV-17; P-02, P-05, P-22.
- **Preguntas previstas:** N0b PG-2, PG-3, PG-4.
- **Cita:** §9 (demo por escenario).
- **Cubre:** S-04, S-06; REED-16 §7.1.

### §4 La capa de IA en el stack y la regla de dependencias, con su prueba (≈ 3 000)

- **Núcleos fuente:** N1 (§1.1 lectura de la imagen, §2 definiciones, §2.14 puerto y adaptador, §4.7, §6), N0b D-01; BIT-16-04 §6.2 con el diagrama corregido de P-15.
- **Contenidos obligatorios:** lectura de `INPUTs/AI-Layer.png` (qué se sostiene con fuentes y qué es simplificación); **un único diagrama de capas** (P-15): herramientas y MCP como adaptadores de entrada, `IChatClient` como adaptador de salida, `IngestaDeRequisitos`, almacén vectorial en Persistence detrás de `IAlmacenDeRequisitos`, `ProponerLocalidadDesdeTexto` sin persistir; la regla de dependencias y su **prueba por reflexión con dos casos rojos** (P-30); sumar IA a una app existente (PR-17, variante de ESC-04); el orden del prompt y el armado del contexto son del adaptador (P-41).
- **Reglas:** RV-04, RV-08, RV-18, RV-19; P-15, P-30, P-41.
- **Preguntas previstas:** N1 P2, P3, P5, P8, P9.
- **Cita:** `Examples/13`; la demo (§9).
- **Cubre:** S-01, S-04; REED-16 §7.1, §7.6.

### §5 Hablar con un modelo desde .NET: abstracciones y proveedores, con métodos y marcos (≈ 4 500)

- **Núcleos fuente:** N2 (completo), N1 §2.6 (temperatura) con P-33.
- **Contenidos obligatorios:** `IChatClient`, historial, streaming y cancelación; salida estructurada (forma ≠ validez); `ChatOptions` y razonamiento por `ChatOptions.Reasoning`; **`OpcionesDeIA`** (P-11: una clase, sección `AI`, `ValidateDataAnnotations().ValidateOnStart()`, `[ValidateObjectMembers]` en `Concurrencia`, el paquete `Microsoft.Extensions.Options.DataAnnotations` en consolas, `num_ctx` por pedido, timeout sin valor por defecto en código, largo máximo de entrada); muestreo del fabricante (P-33); OllamaSharp como vía principal; cambio de proveedor sólo como ejemplo (01 y 06), con la limitación de `/v1` sin `num_ctx` (P-39); **métodos y marcos** MEAI / MAF / SK / SDK directo (PR-19) con el estado de la compuerta de versiones (P-32); paquetes deprecados fuera de todo camino (`Microsoft.Extensions.AI.Ollama`); anotaciones pareadas (PR-22).
- **Reglas:** RV-04, RV-12, RV-18, RV-19; P-11, P-32, P-33, P-39.
- **Preguntas previstas:** N2 P1–P5, P7–P10; N1 P7.
- **Cita:** `Examples/01`, `02`, `03`, `12`.
- **Cubre:** S-02, S-06, S-07; REED-16 §7.2.

### §6 Estrategias de conocimiento: contexto fijo, CAG y RAG; vías A y B (≈ 6 000)

- **Núcleos fuente:** N3b (escalera, caché de prefijo, ventana), N3 (RAG en .NET), N1 §2.10–§2.12.
- **Contenidos obligatorios:** la escalera como criterio, no secuencia (ramas D3–D4 del árbol); contexto fijo con los 12 enunciados como caso (`AyudaContextoFijo`, P-23); caché de prefijo según P-19 (reuso parcial con `qwen3.5:4b`, sin la cifra de patrón; costo local en pared y ocupación); **regla de ventana** de P-20 (presupuesto = `num_ctx` − salida máxima, truncado silencioso como error, el token es del modelo, sin constante caracteres/token); vías A y B con «A por defecto» **por diseño** (P-24); pipeline RAG: ingesta, fragmentación (tamaño y k elegidos con la tabla de §R.6), embeddings con instrucción en la consulta, MEVD InMemory (GA) y SqliteVec como variante preview rotulada (P-32), dimensión validada al arrancar (P-43); **métricas** hit@k, recall@k, MRR@k y abstención con sus definiciones (P-22) y el oro desde los `*Policy` reales con no respondibles; la diferencia política/código como hallazgo didáctico (P-16, RV-14); fragmentos recuperados marcados como contenido externo (CTRL-14).
- **Reglas:** RV-04, RV-14, RV-16, RV-17, RV-18; P-16, P-19, P-20, P-22, P-23, P-24, P-43.
- **Preguntas previstas:** N3b P1–P7; N3 P1–P9; N1 P4.
- **Cita:** `Examples/04`, `05`; demo D5.
- **Cubre:** S-04, S-07; REED-16 §7.3.

### §7 Agentes, herramientas y orquestación, por mecanismo; vía C (≈ 6 000)

- **Núcleos fuente:** N4 (con P-26), N1 §2.13, N6 §4.1 y §4.4.
- **Contenidos obligatorios:** organización **por mecanismo** (herramienta → agente → workflow → MCP) con el ecosistema (MEAI, MAF, LangGraph) como columna (P-26 (4)); herramientas finas sobre casos de uso y como adaptadores de entrada (P-15); **primer ejercicio**: `Examples/06` (PR-20); aprobación con función explícita que devuelve `false` sin respuesta y `ApprovalRequiredAIFunction` (P-26 (1), P-35); el diff 4.1 → 4.2 (`Examples/07`); workflow como contraejemplo (`Examples/10`) y las trampas `BindExecutor` / `[MessageHandler]`; MCP: servidor propio con CTRL-13 y cliente al servidor propio, terceros sólo con versión fijada, lista blanca y escrituras con aprobación (advertencia de la especificación MCP 2026-07-28); **LangGraph**: no hay paquete oficial para .NET; «equivalente en capacidades, no en modelo de programación», con tabla de diferencias (docs de LangGraph y de Agent Framework, 2026-10-28); consumo por HTTP como snippet «no ejecutado»; la vía C como «la misma recuperación dentro del agente», rotulada «corrida sólo con un doble» (P-24); la pregunta central «¿un agente o varios?» (PR-4) y «¿framework o propio?» (PR-18).
- **Reglas:** RV-04, RV-17, RV-18, RV-19; P-15, P-24, P-26, P-35.
- **Preguntas previstas:** N4 P1–P11; N1 P6.
- **Cita:** `Examples/06`, `07`, `08`, `10`, `12`; demo D6, D7.
- **Cubre:** S-05, S-07, S-10; REED-16 §7.4.

### §8 Operar, evaluar y asegurar; despliegue (≈ 5 500)

- **Núcleos fuente:** N5 (con P-03, P-19, P-38, P-44), N0b D-06, D-09, D-10, PG-5; BIT-16-04 §6.3 (controles, P-27).
- **Contenidos obligatorios:** **CTRL-01…CTRL-15** (§4 de este plan) con su prueba o «no medido» y la lista CTX-PROD con motivo, incluidas «pruebas adversariales extendidas»; dos suites, `Cableado/` y `ConModelo/`, con los tres tipos de aserción y `Inconclusive` sin endpoint (P-25); la cabecera R-LLM; OTel con la constante `TelemetriaDeIA.Fuente` (P-42); **los dos órdenes del pipeline con los spans medidos de cada uno, sin recomendar uno hasta PC-02** (RV-03); limitador en la entrada HTTP, 503 con `Retry-After` (P-03, verificado en sonda); clave de caché con `SessionId` si la caché queda por fuera de `UseFunctionInvocation`; ciclo de vida del cliente (P-12: «pierde la sesión sin error», cruce entre sesiones «no probado»); juez: método, advertencia oficial para modelos chicos o locales, k/n con Wilson y nunca compuerta, calidad «no medido» (P-38); inyección directa e indirecta (CTRL-14; N5 P7 conceptual, P-44); salida del modelo como texto (LLM05, P-14); datos personales y celda chica (CTRL-07, PC-15); versiones, deprecaciones y vulnerabilidades (P-32: cero NU19xx en el camino por defecto); despliegue como subsección visible (PR-11).
- **Reglas:** RV-02, RV-03, RV-04, RV-12, RV-16, RV-17, RV-18; P-03, P-12, P-25, P-27, P-32, P-38, P-42, P-44.
- **Preguntas previstas:** N5 P1–P11 (P7 conceptual); N2 P6; N0b PG-5.
- **Cita:** `Examples/09`; tests de la demo; Anexo E.
- **Cubre:** S-07, S-17; REED-16 §7.5.
- **Bloqueo (P-34):** la subsección del orden del pipeline no se redacta hasta PC-02.

### §9 Movilidad Urbana con capa de IA: la demo (≈ 3 500)

- **Núcleos fuente:** N6 (Anexo A con las notas del ciclo 1), N0b D-11.
- **Contenidos obligatorios:** el perímetro y el recorrido D1–D7 (§4 de este plan); qué es copia y qué es agregado, con la tabla única de convivencia de namespaces y cómo se lee `PROCEDENCIA.md` (RV-15); la deuda heredada (`LocalidadesController`, reglas que la política declara y el código no verifica, P-16); qué se toma de `MovilidadUrbana.Web` y por qué (SUP-05, P-14); la página de chat con streaming, cancelación y eventos de etapa (P-14, P-40); escrituras siempre confirmadas (P-35, parte común); agregados sin datos de la persona (P-18); el modelo provisional (P-36); la vía móvil «no ejecutada» hasta el ciclo de demo.
- **Reglas:** RV-01, RV-13, RV-14, RV-15, RV-17, RV-18; P-05, P-13, P-14, P-16, P-17, P-18, P-23, P-35, P-36, P-40, P-43.
- **Preguntas previstas:** N6 P1–P9 (P6 con el texto de P-35).
- **Cita:** `Demos/MovilidadUrbana.Asistente/`.
- **Cubre:** S-09, S-17; REED-16 §7.6.
- **Bloqueo:** la sección no se cierra antes de la segunda ronda (§8 de este plan).

### Anexos A–F (≈ 6 000 en total)

| Anexo | Contenido obligatorio | Parches |
|---|---|---|
| A Plantillas comentadas | `OpcionesDeIA` y su `appsettings.Development.json` (TimeoutSegundos 300, NumCtx 8192, LargoMaximoDeEntrada 2000, Concurrencia 1/2), composición en `Program.cs`, cliente falso, cabecera R-LLM | P-11, P-25 |
| B Plantillas, listas y autoevaluación | «Autoevaluación por escenario»: tres preguntas por ESC con respuesta explicativa y remisión (PR-6); lista de seguridad para herramientas (PR-21); listas por actor | P-06 |
| C Glosario | término preferido, definición única con el molde del Profile y sentidos excluidos, para *agente, herramienta, orquestación, workflow, RAG, embedding, chunk, contexto, prompt, capa de IA* y los términos de P-07 | P-31 |
| D Referencias | catálogo único REF-001… con URL canónica, versión o `ms.date` y fecha ISO; tabla de paquetes generada por la compuerta de versiones el día de publicar (estado, versión, `published`, deprecación, vulnerabilidades); filas de NUnit (vigente 5.0.0; el caso base usa 4.3.2), NUnit3TestAdapter, Microsoft.NET.Test.Sdk y hosting | P-17 (6), P-31, P-32 |
| E Laboratorio y demo | receta única del servidor (`ollama/ollama:0.40.11@sha256:dea72d1e22270fe095b68fdf756d2b489d615643c5a2eaebbc5f569181e322d8`, red `ia-guia`, volumen `ia-guia-modelos`, `pull` de los dos modelos, `ollama list` contra el digest, `docker run` del SDK con `OLLAMA_ENDPOINT=http://ollama:11434`), disco, memoria y latencia con el rótulo de RV-01; registros R-LLM de `Examples/` y `ConModelo/`; la tabla de cifras | P-10, P-21, P-25 |
| F Registro de decisiones | D-01…D-11 con alternativas, criterio, consecuencia y la pieza que la ilustra; D-06 con el contenido obligatorio de P-12; D-11 estado de la conversación (P-13) | P-06 (PR-13), P-12, P-13 |

## 3. `Examples/`: tabla canónica

Cada carpeta es independiente, en `net10.0`, con `README.md` que trae el comando exacto del contenedor, `OLLAMA_ENDPOINT` y el modo sin modelo si lo tiene (RV-11); `.gitignore` con `bin/`, `obj/`, `*.db` y almacenes generados (DC-08, P-32); `PackageReference` iguales a la tabla del Anexo D. «Contra qué modelo» se corre en el servidor de prueba, con R-LLM y el rótulo de RV-01. La 11 no existe (P-44).

| Carpeta | Nivel | Sección | Qué demuestra | Qué prueba (sin modelo, `Cableado`) | Contra qué modelo (R-LLM) | Modo sin modelo |
|---|---|---|---|---|---|---|
| `01-Chat-Basico` | básico | §5 | `IChatClient` con OllamaSharp; `OpcionesDeIA`; `num_ctx` por pedido; selector `AI:Proveedor` con la limitación de `/v1` (P-39) | arranque sin `TimeoutSegundos` y con `Concurrencia:Permisos = 0` → `OptionsValidationException`; entrada de 2001 caracteres rechazada con 0 llamadas; ningún literal fuera de opciones | `qwen3.5:4b` (chat); `qwen2.5:0.5b` para comprobar que `num_ctx` llega (≈ 6000 tokens: sin truncar con 8192, truncado con 4096) | no |
| `02-Streaming` | básico | §5 | `GetStreamingResponseAsync`, `ChatResponseUpdate`, cancelación | — | `qwen3.5:4b` | no |
| `03-Salida-Estructurada` | básico | §5 | `GetResponseAsync<LocalidadPropuesta>` + `LocalidadRules`: forma ≠ validez | JSON malformado → `TryGetResult` falso y camino sin IA | `qwen3.5:4b` | no |
| `04-Embeddings-Y-Busqueda` | intermedio | §6 | ESC-02: buscar el requisito por significado; hit@1, hit@3, recall@3, MRR@3 y abstención; consulta con y sin instrucción | generador falso fijo que reproduce las métricas a mano para tres consultas; generador de 512 con dimensión declarada 1024 → no arranca, 1024/1024 arranca (P-43); oro versionado con su generador | `qwen3-embedding:0.6b` | sí |
| `05-RAG-En-Memoria` | intermedio | §6 | RAG con citas sobre los `*Policy`; vías A y B; contexto fijo frente a RAG; `AyudaRag` y la comparación pareada si P-23 sale en rama B; fragmentos marcados como contenido externo | vía A determinista con buscador falso; vía B con cliente falso que pide la búsqueda | `qwen3.5:4b` + `qwen3-embedding:0.6b`; comparación pareada con N y criterio escritos antes | sí |
| `06-Tool-Calling` | básico, **primer ejercicio** (PR-20) | §7 | una o dos herramientas de sólo lectura (`contar_localidades`, `listar_localidades`) sobre casos de uso; límites del bucle (CTRL-05); selector de proveedor | cuatro pruebas negativas: provincia fuera de catálogo, CP inválido, localidad inexistente, sesión ajena; R-C14 (Application no cambia al cambiar el proveedor) con dos proveedores falsos | `qwen3.5:4b` por OllamaSharp y por `/v1` | sí |
| `07-Agente-Con-Aprobacion` | intermedio | §7 | diff 4.1 → 4.2 sobre el mismo `IChatClient`; `AsAIAgent`; aprobación según P-35 (si la demo sale en rama B, acá vive `ApprovalRequiredAIFunction`) | dos dobles de `IAprobador` (devuelve `null`; no responde y se corta por plazo) → 0 ejecuciones | `qwen3.5:4b` | sí |
| `08-Servidor-Y-Cliente-MCP` | avanzado | §7 | servidor MCP propio con CTRL-13 (loopback, `AllowedHosts`, agregados, sesión fija declarada); cliente MCP con lista blanca al servidor propio; agente con `McpClientTool` | pedido con otro `Host` → 400; herramientas MCP sin campos de la persona | `qwen3.5:4b` | sí |
| `09-Pruebas-Con-Cliente-Falso` | intermedio | §8 | `Cableado/` frente a `ConModelo/`; limitador 503; telemetría; ciclo de vida | 4.º pedido → 503 con `Retry-After`; dos sesiones con el mismo texto → dos fallos de caché; PC-02 (spans con doble capa, caché fría y caliente); `ActivityListener` con la fuente correcta ≥ 1 span y con otra 0; `ValidateScopes` `true` y `false` → la herramienta de A ve el `SessionId` de A; `InputTokenCount` menor que el esperado → «contexto truncado»; sin `OLLAMA_ENDPOINT`, `ConModelo` → `Inconclusive` | `ConModelo/` contra `qwen3.5:4b` | sí |
| `10-Workflow` (opcional) | avanzado | §7 | MAF Workflows como contraejemplo de la encuesta (CASO-8); `BindAsExecutor`; orquestación prearmada | compila; ejecutores con cliente falso | `qwen3.5:4b`, si sobra turno | no |
| `12-Anotaciones-Pareadas` | intermedio | §5 y §7 | la misma herramienta con `[KernelFunction]` y con `[Description]` + `AIFunctionFactory` | `dotnet build` | — | — |
| `13-Prueba-De-Arquitectura` | intermedio | §4 | regla de dependencias por reflexión (P-30) | verde sobre la copia; rojo con `global using` + propiedad `ChatMessage`; segundo caso rojo: uso sólo dentro de un cuerpo de método (si no se detecta, IL o agujero declarado) | — | sí |

## 4. La demo

**Ruta:** `Demos/MovilidadUrbana.Asistente/`. Solución autocontenida: copia literal del cierre de compilación de `MovilidadUrbana.ApiWeb` en `59399ba` (`Domain/`, `Application/`, `Contracts/`, `Controllers/`, `Sessions/`, `Infrastructure/Persistence|Sessions|DependencyInjection`), con `diff -r = 0` y `dotnet build` de la copia sola guardados en `PROCEDENCIA.md` (P-17). Lo agregado vive fuera del árbol copiado (`Agregado/…`, namespaces `MovilidadUrbana.Asistente.*`) e incluye `Infrastructure/AI`, los puertos de IA, `ProponerLocalidadDesdeTexto`, `ResultadosDeEncuestaService` con `ILecturaDeResultados` (P-18), `IngestaDeRequisitos` (P-15), la página de chat (P-14) y `tests/` con `Cableado/` y `ConModelo/`. SQLite del caso base; nada de SqlServer en el camino por defecto (P-32). Nada escribe en `Lab-E2E.WebBlazor`.

**Perímetro (P-05):** una pieza entra sólo si alguna afirmación de la guía la necesita como E1, y entra con todos sus controles.

| Paso | Pedido | CASO / ESC | Qué demuestra | Qué prueba (`Cableado/`) | Contra qué modelo | Estado |
|---|---|---|---|---|---|---|
| D1 | «Agregá Goya, Corrientes, CP 34, 89959 habitantes» | CASO-2 / ESC-03 → ESC-04 | la forma no es validez: el dominio rechaza lo que el modelo inventa; el alta se confirma | propuesta sin persistir (0 `SaveAsync`); reglas heredadas de P-16 (`"٣٤٥٠"` válido, nombre de 61 válido, provincia fuera de catálogo válida) | `qwen3.5:4b`, N = 10 (pendiente P-01 de BIT-16-04) | firme |
| D2 | «En Bella Vista no sé cuántos viven» | CASO-2 / ESC-03 | extracción tipada que no pasa las reglas; la UI pide el dato | idem D1 | `qwen3.5:4b`, N = 10 | firme |
| D3 | «Voy en bondi y a veces en bici…» | CASO-3 / ESC-03 | normalización a catálogo; un medio inventado se rechaza | «piedra» por herramienta → error del normalizador con 0 `SaveAsync`; el mismo valor por el endpoint normal da lo que diga el código copiado | `qwen3.5:4b`, N = 10 | firme salvo la ubicación del normalizador (segunda ronda de C1-38) |
| D4 | «¿Qué medio usa más la gente?» | CASO-1 / ESC-01, CTX-SENS | el dato exacto lo calcula un caso de uso; agregados sin nombres | SQLite en memoria con 3 sesiones; sin `Nombre` ni `Edad` (reflexión); `ToQueryString()` con `GROUP BY` | `qwen3.5:4b` | firme |
| D5 | «¿Cuántos dígitos lleva el código postal?» | CASO-4 / ESC-01 (+ ESC-02 si entra) | con 12 enunciados alcanza el contexto fijo | oro de P-22 con `AyudaContextoFijo` | `qwen3.5:4b` (unos 25–70 s por pregunta) | escalón 0 firme; `AyudaRag` en la demo según la segunda ronda de C1-55 |
| D6 | «Borrá Resistencia» | CASO-5 / ESC-04 | ninguna escritura sin confirmación | cliente falso que pide la baja → 0 ejecuciones sin confirmación, 1 con confirmación por el caso de uso; M14: texto inyectado en el mensaje y en un fragmento → 0 bajas | `qwen3.5:4b`, N = 10; M14 como tasa en `ConModelo/` | parte común firme; forma (rama A o B) según la segunda ronda de C1-40 |
| D7 | Un cliente MCP lista localidades | CASO-6 / ESC-05 | MCP es otro adaptador de entrada | CTRL-13 | `qwen3.5:4b` | en la demo sólo si C1-48 sale en rama B; si no, `Examples/08` |

**Controles CTRL-01…CTRL-15** (M1–M15 de P-27, ids de guía de P-31):

| CTRL | Control | Dónde se prueba |
|---|---|---|
| 01 | Toda escritura pasa por el caso de uso y sus reglas | `Cableado/` (invariante) |
| 02 | Argumentos validados en la aplicación (normalización contra `Catalogos`, CP no ASCII rechazado) | `Cableado/` (prueba «piedra») |
| 03 | Ninguna escritura propuesta por el modelo sin confirmación | `Cableado/` (invariante, 0 ejecuciones) |
| 04 | Salida estructurada con `TryGetResult` y camino sin IA | `Examples/03`, `Cableado/` |
| 05 | Iteraciones = herramientas encadenables + 1 (demo 3), errores consecutivos 2, por configuración | `Cableado/` |
| 06 | Herramientas por sesión | `Cableado/` (`ValidateScopes` `true` y `false`) |
| 07 | Agregados sin campos de la persona; celda mínima como advertencia de CTX-PROD | `Cableado/` |
| 08 | OTel con la constante de fuente; `EnableSensitiveData` sólo en Development; orden según PC-02 | `Examples/09` |
| 09 | Límite de concurrencia por configuración (1/2), 503 con `Retry-After` | `Examples/09`, demo |
| 10 | `OpcionesDeIA` validada al arrancar | `Examples/01`, demo |
| 11 | `Cableado/` siempre; `ConModelo/` por turno con tres tipos de aserción | demo |
| 12 | El asistente declara qué hace y que puede equivocarse; la ayuda muestra la fuente | demo |
| 13 | MCP HTTP en loopback, `AllowedHosts` restringido, autenticación en CTX-PROD (PC-01) | donde esté el servidor MCP |
| 14 | Inyección directa e indirecta → confirmación o ninguna herramienta de escritura, 0 bajas | `Cableado/`; tasa en `ConModelo/` |
| 15 | Largo máximo de entrada y de salida de herramientas; 400 si excede | `Cableado/` (0 llamadas) |

**Página de chat (P-14):** mismo host que la API copiada; de `MovilidadUrbana.Web` sólo la cookie de sesión y `Routes`, como desvío declarado en `PROCEDENCIA.md`; `SessionId` de la cookie al puerto; `await foreach` sobre `IAsyncEnumerable<EventoDelAsistente>` (`TextoParcial`, `EtapaIniciada`, `Final`), `InvokeAsync(StateHasChanged)` por evento, botón de cancelar; salida como texto, sin `MarkupString`. Pruebas: dos pestañas con cookies distintas ven `SessionId` distintos; cancelación en menos de 1 s con cliente falso; `EtapaIniciada` antes de cualquier `TextoParcial` (P-40).

**Estado de la conversación (D-11, P-13):** almacén en Infrastructure con clave `SessionId + ConversacionId` y vencimiento de 30 min; el puerto recibe `(SessionId, ConversacionId, texto, CancellationToken)` y no expone tipos de MEAI.

## 5. Pendientes de BIT-16-04 asignados

| Pendiente | Qué | Dónde se corre | Modelo | Parche que lo rige |
|---|---|---|---|---|
| P-01 | D1, D2, D3 y D6 por la vía .NET, N = 10 | demo, `ConModelo/` | `qwen3.5:4b` | P-24, P-35 |
| P-02 | `ConModelo/` con N mayor | demo y `Examples/09` | `qwen3.5:4b` | P-25 |
| P-03 | juez calibrado | **no se corre en la demo**; método enseñado y «no medido»; en el equipo de respaldo sólo bajo demanda y por la mesa | — | P-38, P-37 |
| P-04 | N4 4.6 (agente con `McpClientTool`) y 4.7 (`BuildSequential`) con modelo | `Examples/08` (4.6), `Examples/10` (4.7) | `qwen3.5:4b` | P-26 |
| P-05 | recuperación de los `*Policy` con métricas | `Examples/04` (y la demo si C1-48/C1-56 lo admiten) | `qwen3-embedding:0.6b` | P-22 |
| P-06 | oro de C4 con los dos adaptadores de `IAyuda` | demo (rama A) o `Examples/05` (rama B) | `qwen3.5:4b` + embeddings | P-23 |
| P-07 | comparativo CAG/RAG con corpus sintético (generador reescrito) | `Examples/05`; ≥ 7B «no medido en estación 1» | `qwen3.5:4b` | P-19, P-37 |
| P-08 | truncado con el modelo de chat; `prompt_eval_count` con contexto grande | `Examples/05` (contexto grande) y prueba de cableado en `Examples/09` | `qwen3.5:4b`, N ≥ 3 por tamaño, dato en la zona descartada | P-20 |
| P-09 | dimensión de embeddings validada al arrancar | `Examples/04` y demo | `qwen3-embedding:0.6b` + generador falso | P-43 |
| P-10 | `ValidateScopes=false` con cliente Singleton | `Examples/09` y demo (obligatorio) | sin modelo | P-12 |
| P-11 | `tool_choice` por `/v1` (opcional) | `Examples/06` | `qwen3.5:4b` | P-39 |
| P-12 | navegador del emulador sobre la página de chat | ciclo de demo; en este ciclo «no ejecutada» | — | P-14 |
| P-13 | re-consulta de versiones | compuerta de publicación (Anexo D) | — | P-32, P-10 |
| P-14 | snippets de N2, N4 y N5 reilustrados y por variable | `Examples/01`, `02`, `03`, `06`, `07`, `09` | según la carpeta | P-11, P-29 |
| P-15 | N1 §4.1, §4.3, §4.4 y §4.6 con `sdk:10.0` | `Examples/01` (4.1), `03` (4.3), `04` (4.4), `06`/`07` (4.6) | según la carpeta | P-29 |

## 6. Reglas vinculantes RV-01…RV-19

Texto de 03-Parches §3, con las secciones citadas por **título** (ajuste de los jueces de impacto y de evidencia sobre P-07). RV-05 a RV-07 no se usan.

| RV | Regla | Parche | Cómo se verifica |
|---|---|---|---|
| RV-01 | El servidor se nombra «el servidor Ollama de prueba», sólo por `OLLAMA_ENDPOINT`. Mediciones con el rótulo «medido en la estación de laboratorio (CPU de 4 núcleos sin GPU; contenedor limitado a 4 CPU / 5 GB; Ollama 0.40.11), fecha». Sin hostnames, contenedores del laboratorio, usuarios ni direcciones en la guía, los README ni los `appsettings*.json` | P-01 | `rpriv.sh` sobre la guía = 0 |
| RV-02 | En «Marco de referencia» y en «Operar, evaluar y asegurar», «falso aceptado» sólo en el sentido 1 de P-02, sin cifra ni umbral: «no medido» | P-02 | `grep -n "falso aceptado"` |
| RV-03 | En «Operar, evaluar y asegurar», ningún orden del pipeline como mejor práctica antes de PC-02: se muestran los dos órdenes con sus spans medidos. Limitador en la entrada HTTP con 503 y `Retry-After` | P-03 | lectura + `grep -n "int.MaxValue\|llama3.1"` = 0 |
| RV-04 | Cada sección de tema («La capa de IA en el stack», «Hablar con un modelo desde .NET», «Estrategias de conocimiento», «Agentes, herramientas y orquestación», «Operar, evaluar y asegurar») tiene su bloque «Aplicación por escenario» con los cinco ESC; cada criterio nombra el ESC y el CTX | P-04 | compuerta de encabezados |
| RV-08 | Ningún id ni ruta de la bitácora (`BIT-16-`, `EA-`, `E-B`, `X0`…`X5`, `R-C`, `MI-`, `P-0`, `Nucleos/`, `Integracion-Evidencia/`) en la guía | P-08 | `grep -nE "BIT-16-\|\bEA-[0-9]\|\bE-B[0-9]\|\bX[0-5]\b\|R-C[0-9]{2}\|MI-[0-9]{2}\|Nucleos/\|Integracion-Evidencia/"` = 0 |
| RV-09 | Las mediciones del servidor dado de baja, en pasado y con fecha | P-08 | lectura |
| RV-10 | Cada respuesta a una pregunta guía transfiere el criterio, no el resultado de una corrida; si da un número, lo rotula como RV-01 | P-08 | relectura |
| RV-11 | Cada `README.md` de `Examples/NN` con el comando del contenedor, `OLLAMA_ENDPOINT` y el modo sin modelo | P-10 | clon limpio + comando del README |
| RV-12 | En «Hablar con un modelo desde .NET», «Operar, evaluar y asegurar», la demo, `Examples/` y `Demos/`: ningún endpoint, modelo, `num_ctx` ni timeout literal fuera de `OpcionesDeIA` y los `appsettings` | P-11 | `grep -rn "localhost:11434\|qwen3.5:4b"` fuera de opciones = 0 |
| RV-13 | En la sección de la demo, la salida del modelo como texto; Markdown sólo saneado y declarado junto al código | P-14 | `grep -rn MarkupString Demos/` = 0 |
| RV-14 | En «Estrategias de conocimiento» y en la demo, las reglas de Localidad como las enuncia P-16; política frente a código como hallazgo («el modelo repite la política; la prueba muestra el código») | P-16 | `grep -n "entre 3 y 60\|4 dígitos\|del catálogo"`, cada una con la aclaración |
| RV-15 | En la sección de la demo, una tabla única de convivencia de namespaces y cómo se lee `PROCEDENCIA.md` | P-17 | lectura |
| RV-16 | En «Estrategias de conocimiento» y en «Operar, evaluar y asegurar», ninguna cifra de aceleración por caché sin modelo, versión y rótulo; costo local en pared y ocupación | P-19 | `grep -n "93"` sin la cifra de patrón |
| RV-17 | Ninguna comparación entre variantes con N ≤ 10; garantías como invariantes con su prueba de cableado | P-24 | `grep -nE "[0-9]+/[0-9]+"`, cada fracción con N > 10 o rótulo de existencia |
| RV-18 | Ningún snippet «ejecutado» si no compila en la carpeta de `Examples/` que nombra la matriz, con `sdk:10.0` | P-29 | matriz de snippets |
| RV-19 | Cada snippet con sus `using` o «Compila en `Examples/NN/archivo.cs`» | P-29 | lectura |

**También vinculantes**, por su texto aprobado en las notas del ciclo 1: P-06 (destinos de las PR), P-07 (estructura, presupuesto, reglas de compresión, correspondencia de numeración), P-09 (plan de preguntas), P-22 (definiciones de métricas), P-24 (MI-01 por diseño, vía C en «Agentes, herramientas y orquestación»), P-26 (N4 por mecanismo, equivalencia en capacidades), P-27 (CTRL-01…15 y criterio de corte), P-31 (catálogo REF, glosario, ids), P-36 (rótulo provisional), P-37 («no se midió en estación 1»), P-38 (sin juez en la demo), P-39 (proveedor sólo en ejemplos) y P-40 (eventos de etapa).

**Barridos de redacción que vienen de los criterios de verificación de los parches** (se corren sobre la guía y deben dar 0): `npx -y`, `= true;` en la aprobación, `GuessNumber`, `EchoTool`, `GetWeather`, «mismo modelo» (P-26); `Comentario` en la guía y en `Examples/` (P-44); `mezcla sesiones` (P-12); `Evaluation` en el camino por defecto de `Demos/` (P-38); `Proveedor` en `Demos/` salvo una variante rotulada «sin num_ctx» (P-39); `AyudaRag` y `ApprovalRequiredAIFunction` en `Demos/` si las ramas B de P-23 y P-35 ganan; `\bC[1-8]\b` y `\bM[0-9]{1,2}\b` fuera de `CASO-` y `CTRL-` (P-31).

## 7. Compuertas de la redacción

| Compuerta | Cómo se corre | Criterio |
|---|---|---|
| C1 contradicciones | lectura cruzada con BIT-16-04 §2 y las notas del ciclo 1 | 0 |
| C2 trazabilidad | `Mesa/Ciclo-2/trazabilidad.md`; `grep '\[C:'` sobre la guía | toda S-, §7.n y PR con sección; 0 marcas |
| C3 trazabilidad inversa | cada sección de la guía con su S- o núcleo | 0 huérfanas |
| C4 huérfanos | script de enlaces (`Mesa/Ciclo-1/evidencia-verificacion-qa/G2-enlaces.py`) + listado de `Examples/` y `Demos/` | 0 enlaces rotos; todo directorio citado |
| C5 glosario | búsqueda de cada término del Anexo C | una definición por término |
| R-PRIV | `RPRIV_LISTA=<privado> Bitacoras/Mesa/Ciclo-1/aplicacion/rpriv.sh <raíz de la guía>` | sale 0 sobre la guía; `patrones=0` sobre `OUTPUTs/`; ningún commit de `OUTPUTs/` con `identificadores > 0` sin dictamen fechado de la presidencia |
| Build y test | `dotnet build` y `dotnet test` de cada carpeta en `mcr.microsoft.com/dotnet/sdk:10.0` (imagen registrada), por el recurso `build` | n/n |
| Clon limpio (P-10) | carpeta nueva fuera del workspace, sin caché NuGet, servidor levantado con la receta del Anexo E | cada README corre tal cual |
| Versiones (P-32) | registro y `flatcontainer` de nuget.org; `dotnet list package --vulnerable --include-transitive`; `.gitignore` por contenido; la imagen `ollama/ollama` | tabla del Anexo D con fecha; 0 NU19xx en el camino por defecto o avisos aceptados con GHSA |
| Mermaid | renderizador de mermaid sobre cada bloque | 0 inválidos (no se corrió en la aplicación del ciclo 1: no hay renderizador en la estación) |
| Presupuesto (P-07) | `wc -w` por sección | ±20 % |
| R-LLM | cabecera en cada salida contra el modelo (P-25) | `grep -L "modelo@"` = 0 en las salidas de `Examples/` y `Demos/` |

## 8. Decisiones abiertas y qué hace la redacción mientras tanto

| Abierto | Qué bloquea | Qué hace la redacción mientras tanto |
|---|---|---|
| Segunda ronda de C1-48 (perímetro, P-05) | la columna «en la demo» de D5 (RAG) y D7 (MCP); CTRL-13 en la demo | redacta con la rama A (mínima) como provisional y deja D7 en `Examples/08` |
| Segunda ronda de C1-40/C1-62 con PC-13 (P-35, P-13 rama A) | forma de D6 en la demo; endpoint de aprobación | redacta la parte común (toda escritura se confirma; invariante CTRL-03); `Examples/07` enseña `ApprovalRequiredAIFunction` en las dos ramas |
| Segunda ronda de C1-55 (P-23) y parte de demo de P-22 | `AyudaRag` y ESC-02 en la demo | `AyudaContextoFijo` en la demo; `AyudaRag` y ESC-02 en `Examples/05` y `04` |
| Segunda ronda de C1-38 con la carpeta de P-17; C1-53 | dónde vive el normalizador | redacta la prueba de cierre «piedra» (común); la frase «el caso de uso y las reglas deciden» espera la ronda |
| PC-02 (doble capa de telemetría) | el orden del pipeline (CTRL-08, P-42) | muestra los dos órdenes con sus spans; no recomienda uno |
| PC-01, PC-04, PC-05, PC-06, PC-09, PC-11, PC-12, PC-14, PC-15 | las afirmaciones que dependen de cada una | escribe «no probado» o la versión conceptual (PC-14: N5 P7 conceptual) |
| Definición de agente y workflow (P-31) | el Anexo C y §7 | no redacta §7 hasta tenerla |
| Dictamen de la presidencia sobre la excepción de P-01 | el primer commit de `OUTPUTs/` | nada: la redacción no commitea |
| Comparación D1–D6 entre `qwen3.5:2b` y `qwen3.5:4b` (P-36) | nada (no bloquea publicar) | el rótulo provisional; criterio ya escrito en `Integracion-Evidencia/C-operacion-demo/criterio-D1-D6-qwen3.5-2b-vs-4b.md` |

## 9. Trazabilidad mínima

Esqueleto para `Mesa/Ciclo-2/trazabilidad.md` (P-28). La tabla completa suma PR-1…PR-22 (destinos de P-06), RD-PO-1…4 y MD-1…3 (I-06).

| Origen | Sección de la guía | Pieza |
|---|---|---|
| S-01 imagen | §4 | — |
| S-02 marco teórico y práctico vigente | §2, §5 | Anexo D |
| S-03 guías, ejemplos y demo | toda la guía | `Examples/`, `Demos/` |
| S-04 estrategias y casos de integración | §1, §3, §4, §6 | `Examples/04`, `05`, `13` |
| S-05 creación de agentes | §7 | `Examples/06`, `07`, `08`, `10` |
| S-06 definiciones | cada sección + Anexo C | — |
| S-07 ejemplos y snippets | §5–§8 | `Examples/` |
| S-08 preguntas y respuestas | cada sección | plan de preguntas |
| S-09 demo sobre Lab-E2E.WebBlazor | §9 | `Demos/MovilidadUrbana.Asistente/` |
| S-10 LangGraph | §7 | snippet «no ejecutado» |
| S-11…S-15 mesa, panel, relectura, apuntes | (proceso; no son secciones) | bitácora |
| S-16 rutas | §0 de este plan | — |
| S-17 probar todo con registro | §8, Anexo E | `Cableado/`, `ConModelo/`, R-LLM |
| REED-16 §7.1 capa de IA y diagrama | §1, §3, §4 | `Examples/13` |
| §7.2 abstracciones, GA/preview, deprecados | §5, Anexo D | `Examples/01`–`03`, `12` |
| §7.3 RAG y cuándo no | §6 | `Examples/04`, `05`; D5 |
| §7.4 agentes, marcos, LangGraph | §7 | `Examples/06`–`08`, `10` |
| §7.5 probar, observar, asegurar | §8 | `Examples/09` |
| §7.6 integración en Movilidad Urbana | §9 | la demo |

---

## 10. Ronda 2 (2026-10-28): reglas vinculantes que reemplazan las ramas provisionales

> Agregado el 2026-10-28 por la aplicación de la segunda ronda del ciclo 1 (sólo agregado: §0–§9 no se tocan). Fuentes: `Ronda-2/03-Parches.md` (diseño, P2-01…P2-15; P2-06 en su vuelta 2), `Ronda-2/04-Aprobacion-*.md` (los 15 parches `APLICAR`, con los ajustes vinculantes de evidencia, riesgo, impacto y coherencia histórica, y las posiciones `MEJORAR_PLAN` en minoría incorporadas cuando eran mecánicas) y `Ronda-2/05-Aplicacion.md` (registro, sha256 y deuda). Las rutas de esta sección son relativas a `Bitacoras/Mesa/Ciclo-1/`, salvo que digan otra cosa.

**Precedencia (reemplaza §0.6).** Esta sección > nota de la ronda 2 en el registro (`Parche P2-NN (ciclo 1, ronda 2)`) > §0–§9 de este plan > nota del ciclo 1 > texto previo del registro. Donde §0–§9 dicen «según la segunda ronda», «si C1-xx sale en rama…», «provisional» o «no probado» sobre algo que esta sección resuelve, rige esta sección. No queda ninguna rama provisional: lo que sigue abierto está en §10.8 y tiene default.

### 10.1 Cómo quedó cada fila de §8

| Fila de §8 | Resolución (opción ganadora, conteo) | Parche | Qué hace la redacción desde hoy | Qué sigue abierto |
|---|---|---|---|---|
| Segunda ronda de C1-48 (perímetro) | **A** (A 3, B 1, C 1): demo D1–D6 | P2-02 | Redacta la demo con D1–D6 y CTRL-01…15 sobre lo que queda. D7, el servidor MCP HTTP y CTRL-13 van a `Examples/08`. El selector de proveedor va a `Examples/01` y `06`. `AyudaRag` va a `Examples/05`. La página dedicada a `GetStreamingResponseAsync`/`ChatResponseUpdate` es `Examples/02`; la página de chat de la demo **conserva** `EventoDelAsistente` con `EtapaIniciada`, `TextoParcial` y `Final` (lectura ratificada por las cinco aprobaciones; la alternativa que sacaba `TextoParcial` quedó descartada) | nada |
| Segunda ronda de C1-40/C1-62 con PC-13 | **B** (C1-40 B 4, C 1; C1-62 B 3, D 2; C1-14 B 3, C 2) | P2-03 | En la demo **ninguna herramienta escribe**. Alta y baja: el modelo devuelve una `AccionPropuesta` tipada y validada (B1–B4); la UI muestra la entidad resuelta por el servidor, codificada por Razor; la persona ejecuta la operación normal de la API. Sin endpoint de aprobación ni `AprobacionPendiente`. `Examples/07` enseña `ApprovalRequiredAIFunction` con A1–A5. La guía dice que el 404 por un id de otra sesión **no es control de acceso** (RV-20) | nada |
| Segunda ronda de C1-55 y parte de demo de P-22 | C1-55 **B** (B 3, C 2); C1-56 **B** (B 3, C 2) | P2-02 | La demo registra sólo `AyudaContextoFijo`. `AyudaRag` y la comparación pareada con el oro de P-22 viven en `Examples/05`; el candidato de ESC-02 («buscar el requisito por significado») vive sólo en `Examples/04`, con hit@1, hit@3, recall@3, MRR@3 y abstención como tasas de la tarea (R-LLM-3d). Fila N6 de `03-Marco` §4.1: ESC-01, 03 y 04 sí; ESC-02 y 05 no | **ninguna frase comparativa entre contexto fijo y RAG** hasta que corra `Examples/05` (condición del juez de evidencia; default: la sección de conocimiento describe las dos estrategias sin compararlas) |
| Segunda ronda de C1-38 con la carpeta de P-17; C1-53 | **A** (5-0) y **A** (5-0) | P2-04 | Normalizador en `Agregado/Application/Normalizacion/NormalizadorDeCatalogos.cs`, núcleo, invocado por el adaptador antes del caso de uso; `diff -r = 0` sobre todo lo copiado; H1–H5 sin endurecer. Frase de la guía: «el adaptador invoca al normalizador del núcleo y después al caso de uso; el catálogo normaliza y las reglas deciden». El normalizador también rechaza `Enum.IsDefined` falso y nombres de más de 60 caracteres en el camino de IA | la prueba «piedra» puede dar errores distintos por la herramienta y por el endpoint copiado: **la guía muestra lo que dé, sin decir que coinciden** (divergencia registrada; endurecer la copia sería cambio de alcance y no se hace) |
| PC-02 (doble capa de telemetría) | C1-37 **B** (B 4, A 1) = rama A de P-03; C1-37-clave **A** (5-0) | P2-06 (vuelta 2) | Orden: caché → `UseFunctionInvocation` → `UseOpenTelemetry` → cliente, con el contador `TelemetriaDeIA.AciertosDeCache` = `"movilidadurbana.ai.cache.aciertos"` y la clave con `SessionId`. La doble capa sólo como alternativa descartada (doble conteo de tokens, 48 frente a 24). **Demo: regla (b)**, sin caché para pedidos que llaman herramientas de lectura (por defecto no registra la caché). **`Examples/09`: regla (a)**, `CacheKeyAdditionalValues = [SessionId, VersionDeDatos]` con la versión leída en cada pedido. Limitador sólo en la entrada HTTP (M9); la guía no presenta un limitador dentro de la cadena como opción | la subsección del pipeline (deriva de N5 §4.2) **no se redacta** hasta que pasen las cinco pruebas de §10.7 en `Cableado/` (P2-15) |
| PC-01, PC-04, PC-05, PC-06, PC-09, PC-11, PC-12, PC-14, PC-15 (y PC-03, PC-07, PC-08, PC-10, PC-13) | respondidas con experimento en las consultas dirigidas | P2-07 (01, 09, 12, 15), P2-01 y P2-08 (03, 05), P2-09 (04, 06), P2-05 (11), P2-12 (14), P2-10 (07), P2-11 (08), P2-13 (10), P2-03 (13) | Lo que decía «no probado» o «versión conceptual» se redacta con lo medido (texto de cada nota). N5 P7 deja de ser conceptual: entra `Localidad.Nombre` (P2-12) | quedan en nivel C, y la guía no los afirma: HostFiltering con el builder *slim*; `ValidateOnBuild`; un `ApprovalRequiredAIFunction` publicado por MCP; `num_ctx` fijado en el servidor o en el Modelfile; «un acierto por streaming llega en menos fragmentos»; la revisión del protocolo que habla `ModelContextProtocol.AspNetCore` 2.3.0 |
| Definición de agente y workflow (P-31) | consulta de definiciones (P-31.1–.5) | P2-14 | **§7 se redacta.** Agente: «un sistema en el que el modelo decide, en un bucle, qué herramienta pedir a continuación y cuándo terminar, a partir de los resultados que la aplicación le devuelve; la aplicación ejecuta cada pedido y fija un límite de iteraciones». Agente mínimo = `IChatClient` con `UseFunctionInvocation`; «agente de MAF (`AIAgent`)»; «workflow de MAF». Anexo C con Agente, Herramienta, Orquestación y Workflow de MAF de `Ronda-2/Consulta-definiciones.md` §4 | el sentido (a) de «workflow» (C1-32, elevado a la presidencia): cada frase que lo use lleva `[C: término de C1-32]`; C2 = 0 marcas impide cerrar sin la decisión |
| Dictamen sobre la excepción de P-01 | dictamen de la presidencia §1 y §2 | P2-01 | nada nuevo para la redacción: la guía, `Examples/` y `Demos/` pasan la compuerta v2 con 0 en los tres recuentos | el primer commit de `OUTPUTs/` exige el barrido con `identificadores=0` (dictamen §2) |
| Comparación D1–D6 entre `qwen3.5:2b` y `qwen3.5:4b` (P-36) | C1-41 **A** (A 4, B 1); C1-50 **A** (5-0) | P2-10 | Rótulo nuevo (§10.2, «Modelos»); el 4b sigue **provisional**; no se exige otra corrida | nada |
| *(fila nueva)* Sentido de «workflow» (C1-32) | elevado a la presidencia por el relator (Boleta §6) | P2-14 | redacta §7 con la marca; las formas comunes a las dos opciones ya rigen («workflow de MAF», «proceso»; sin «agentic workflow», «flujo agéntico» ni «flujo de trabajo») | decisión de la presidencia (opción A «workflow» a secas, opción B «flujo fijo») |
| *(fila nueva)* S1 abiertos de N0b y N5 §4.2 (P-34) | C1-36 **A** (5-0) | P2-15 | redacta el resto. Las secciones que derivan de N0b §3.1.3 y R-C20 esperan que el `grep -n "falso aceptado"` dé el sentido 1 en toda aparición posterior a la nota de P-02 (las notas de P-02 y P2-13 ya están aplicadas). La que deriva de N5 §4.2 espera las pruebas (1)–(3) de P-03 y las cinco de P2-06 en `Cableado/` | «validado» y el cierre siguen bloqueados hasta «Marcas [C] resueltas» y «Validación del núcleo» en cada registro |
| *(fila nueva)* Apagado del segundo servidor | lo decide la presidencia (C1-51) | P2-10 | nada de la redacción | **a decidir antes del cierre del ciclo 1** (condición del juez de riesgo); hoy el contenedor está arriba con 14 CPU / 34 GiB y `KEEP_ALIVE` de 10 min |

### 10.2 Cambios por sección del plan

**§1 Entregables previos.** Tres filas quedan cumplidas: `Mesa/Ciclo-2/segunda-ronda.md` se cumplió en `Mesa/Ciclo-1/Ronda-2/` (boleta, votos, parches, aprobaciones y aplicación), y ese archivo ya no se escribe; la definición de *agente* y *workflow* la entregó la consulta de definiciones (P2-14), salvo el sentido de «workflow» (C1-32); las consultas PC-01…PC-15 están respondidas (§10.1). Siguen pendientes y antes de redactar: `plan-de-preguntas.md` (con N5 P7 de P2-12 y N6 P6 de P2-03), `trazabilidad.md`, `matriz-snippets.md` (los snippets de MCP, RAG y aprobación apuntan a `Examples/04`, `05`, `07` y `08`, no a la demo) y `evidencia-a-guia.md` (suma las salidas de las consultas de la ronda 2 que la guía cita).

**§0.3 Servidor y rótulo.** Suma el rótulo del segundo servidor (RV-01 ampliada, §10.3). Una cifra de la estación y una del segundo servidor nunca van juntas sin decir cuál es cuál.

**§0.4 Modelos.** El rótulo «elegido entre los que se probaron; no se comparó punta a punta con el 2b» queda reemplazado por este, que va a la guía tal cual: «`qwen3.5:4b` se eligió frente a `qwen3.5:2b` porque normaliza al catálogo (D3: el 4b falló 0 de 10 y el 2b 10 de 10); el 2b respeta mejor el dato inválido (D1: el 4b inventó el CP 10 de 10 veces y el 2b 1 de 10); ninguno confirma antes de borrar (D6: 10 de 10 los dos). Son tasas de un pedido por paso, N = 10 semillas por pedido y modelo, una corrida, T 0,7, razonamiento apagado, `/v1`; `qwen3.5:2b@0689d44085e0` (Q8_0, 2,68 GB) frente a `qwen3.5:4b@d8b0f5e9760c` (Q4_K_M). Medido en la estación de laboratorio, 2026-10-28.» Los Wilson 95 % van en la tabla: D3, 4b [0; 0,28] y 2b [0,72; 1]; D1, 4b [0,72; 1] y 2b [0,02; 0,40]. «Difiere» en D1 y D3 vale **para ese pedido** (9 y 10 pares discordantes en un solo sentido, R-LLM-3e); D6, «no separado». El 35b-a3b no es candidato por defecto (no se separa del 4b en herramientas y es unas 4,2 veces más lento por llamada). La guía no dice que el 2b sea más rápido.

**§2, sección por sección.**

- **§3 Marco de referencia:** la fila N6 de la matriz núcleo × escenario es la de la nota de P2-02 en `03-Marco` §4.1. «Falso aceptado», sólo en el sentido 1 y «no medido»: el umbral se fija recién con una tasa de la tarea según R-LLM-3d (K ≥ 10 textos redactados antes, m ≥ 3 semillas por texto, intervalo sobre los textos), que reemplaza el «N ≥ 96» de P-02 (P2-13).
- **§4 La capa de IA en el stack:** el diagrama único se redibuja desde la nota consolidada de P2-02 en BIT-16-04 §6.2: sin `/mcp`, `AyudaRag`, `VectorStore` ni `ApprovalRequiredAIFunction` dentro del recuadro de la demo; `TOOLS` de sólo lectura; las escrituras como `AccionPropuesta` y operación normal; `PIPE` con el orden de P2-06 y el limitador en la entrada HTTP; las piezas de `Examples/04`, `05`, `07` y `08` aparte y rotuladas. La regla de capa (P-30) reconoce `Agregado/Application` como núcleo y el catálogo único de herramientas como adaptador de entrada.
- **§5 Hablar con un modelo desde .NET:** la tabla de diferencias entre la vía nativa (OllamaSharp 5.5.0 → `/api/chat`) y `/v1` (MEAI.OpenAI) de la nota de P2-08 en N2 §2.9 entra **una sola vez**, acá (RV-22). `OpcionesDeIA` (M10) suma: credenciales en el `HttpClient` de `IHttpClientFactory` o en un `DelegatingHandler`, nunca en `ChatRequest.<clave-de-cabeceras>` (se serializa en el cuerpo); `TopK` sólo por la vía nativa; por `/v1` `MaxOutputTokens` no acota la salida (3 pedidos, 57 salidos) y por eso no acota la pared; mismo `num_ctx` en todos los clientes del mismo modelo (alternar recarga de 10 a 16 s con el 4b). El muestreo del fabricante se fija con `ChatOptions` tipadas **sólo por la vía nativa** (cierra P-33). Sin `num_ctx`, Ollama 0.40.11 recarga con 4096 y, con un prompt mayor, trunca en silencio a 2050 (medido con `qwen2.5:0.5b`, 5 de 5; con el 4b no se midió el truncamiento); el automático depende de la configuración del servidor, no de su estado.
- **§6 Estrategias de conocimiento:** sin frase comparativa CAG/RAG hasta correr `Examples/05`. La señal de reuso del prefijo: el servidor informa `prompt_eval_cached_count`, OllamaSharp 5.5.0 no lo expone (`CachedInputTokenCount` = `null`); se lee con un `DelegatingHandler` sobre la última línea NDJSON o por `/v1`. Vías A y B acá; «A por defecto» **por diseño**. El texto de la tensión 1 que entra a la guía es: «En una de seis preguntas de requisitos, la vía B a veces contesta sin buscar: buscó en 12 de 16 corridas (este pedido, semillas distintas, Wilson 95 % [0,51; 0,90]). En las otras cinco buscó siempre: 8/8 en cada una (este pedido, semillas 1..8). Que B omita la herramienta depende del pedido: se observó omisión en 1 de 6 pedidos (existencia); seis pedidos no alcanzan para una tasa de la tarea. La vía A va por defecto por diseño (el paso fijo es determinista, se prueba sin modelo y no depende de que el modelo decida buscar), no por esta tasa.» Ningún Wilson agrupado sobre pedidos × semillas.
- **§7 Agentes, herramientas y orquestación:** definiciones de P2-14 (§10.1). Organización por mecanismo: herramienta → agente mínimo → agente de MAF → workflow de MAF → multiagente; **MCP es transporte**, no un nivel de orquestación. «Un agente no es un workflow» vale sobre el concepto; un workflow de MAF puede exponerse con `AsAIAgent()` y el orden sigue en el grafo. La vía C es «la misma recuperación dentro del agente» (un agente mínimo o un agente de MAF con la búsqueda como herramienta), rotulada «corrida sólo con un doble». `ApprovalRequiredAIFunction` se enseña acá con `Examples/07` y el contrato A1–A5 (§10.2, «§3»). MCP: catálogo único de `AIFunction` filtrado a lectura y publicado con `McpServerTool.Create`; `[McpServerToolType]` sólo como alternativa con dos definiciones; middleware de `Origin` (403) porque el SDK 2.3.0 no lo valida y la especificación lo exige (revisión vigente 2026-07-28).
- **§8 Operar, evaluar y asegurar:** (a) **D-06** con el título «Singleton fuera de Development: todas las conversaciones comparten un único espacio y pueden leer y borrar lo que otra escribió, sin error», las dos frases corregidas de P2-05 (con `ValidateScopes = false` la sesión B vio y borró lo de A, sin error, y el cruce es de datos y de autorización; con `true` y sin `ValidateOnBuild` falla en cada llamada a la herramienta, no al construir el contenedor) y la cita de https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection/overview §«Scope validation» (ms.date 2026-01-26), o el título en términos de `ValidateScopes = false`. (b) El pipeline de P2-06 (§10.1) con «lo que se pierde»: un acierto no aparece en la traza (se lee en la métrica) y **no vuelve a ejecutar las herramientas**. (c) Juez: sin juez en la demo; el método con la advertencia oficial; «no medido» en la estación; en el segundo servidor, k/n con Wilson y nunca compuerta; costo medido (unos 34 s por evaluación en el segundo servidor; 1285 s por caso con 7 evaluadores en la estación, N = 1, anfitrión sin reservar; 154 s por evaluador, N = 3); condiciones: razonamiento apagado, `num_ctx` ≥ 8192 en el cliente si entra Retrieval, Retrieval fuera del mínimo. (d) Inyección indirecta por `Localidad.Nombre` (P2-12), con la precondición de principales distintos y sus cuatro caminos, el ejemplo de CTX-PROD `RespuestaDeEncuesta.Localidad` y la tasa observada con su estimando («este pedido»: 0/10 bajas, Wilson [0; 0,28]; repitió el texto 10/10; lo señaló 3/10 por lectura manual) seguida de «el control sigue siendo» la ausencia de herramientas de escritura. (e) CTRL-07 en CTX-PROD: `TamanoMinimoDeCelda` en `ResultadosDeEncuestaService`, supresión complementaria y cruces limitados (Ley 25.326 arts. 2 y 28; ResDAC como práctica, no como norma). (f) R-LLM-1…5 (P2-13) como regla de las tasas.
- **§9 La demo:** el perímetro y la rama B (§10.1); `PROCEDENCIA.md` declara la deuda heredada «la API copiada no hace cumplir `LargoMaximoDelNombre` (60)» junto a la de `LocalidadesController`; RV-14 suma «declarado, no aplicado por la API» en la frase del largo del nombre; el historial de D-11 lleva vencimiento (30 min) y **no va a registros** ni a atributos fuera de Development; la UI usa el id de sesión que asigna el servidor. La sección ya no espera ninguna ronda (se cierra con sus pruebas).
- **Anexo C:** entradas de P2-14; «Workflow» espera C1-32.
- **Anexo D:** suma, con su fecha de consulta 2026-10-28: la especificación MCP 2026-07-28 (streamable-http, §«Security & Endpoint») con la 2025-06-18 como antecedente; .NET DI overview §«Scope validation» (ms.date 2026-01-26); Ley 25.326 (InfoLEG) y ResDAC *CMS Cell Size Suppression Policy* (01/26/2024); la documentación de compatibilidad con OpenAI de Ollama y la de *context length*; `server/routes.go` y `server/sched.go` en el tag v0.40.11; Bowyer et al. arXiv:2503.01747v3 y Miller arXiv:2411.00640v1; la MAF Overview con ms.date 2026-10-23 y las seis fuentes de la consulta de definiciones con sus hashes (`Ronda-2/evidencia-definiciones/raw/fuentes-sha256.txt`).
- **Anexo E:** la tabla de cifras suma las cinco filas de la nota de P2-10 en `Sondeo-Entorno.md` §R.6, con la columna «servidor»; las del segundo servidor llevan su rótulo.
- **Anexo F:** D-06 con el título de P2-05; D-07 con las alternativas renombradas (llamada única, agente mínimo, agente de MAF, workflow de MAF, multiagente; MCP como transporte; CASO-8 como contraejemplo de workflow de MAF); D-11 con `AccionPropuesta(tipo, datos)` y sin `AprobacionPendiente`.

**§3 `Examples/` (celdas que cambian; las demás quedan).**

| Carpeta | Columna | Queda así |
|---|---|---|
| `01-Chat-Basico` | Qué demuestra | suma la tabla de diferencias de P2-08 y la regla de credenciales en `DelegatingHandler`; es uno de los dos únicos lugares del selector `AI:Proveedor` |
| `01-Chat-Basico` | Qué prueba | suma la captura de cuerpo por las dos vías con un servidor falso, que reproduce las filas `TopK` y `MaxOutputTokens` |
| `01-Chat-Basico` | Contra qué modelo | suma una corrida por `/v1` con `MaxOutputTokens = 3` que muestra que no acota la salida |
| `02-Streaming` | Qué demuestra | es la página dedicada a `GetStreamingResponseAsync`/`ChatResponseUpdate` que la demo no trae (C1-48 = A) |
| `03-Salida-Estructurada` | Qué prueba | suma: `tipo` fuera del enum e id inexistente se descartan antes de la UI (el control de la prueba D3 vale para `LocalidadPropuesta`) |
| `04-Embeddings-Y-Busqueda` | Qué demuestra | **único** lugar del candidato de ESC-02; las métricas son tasas de la tarea (R-LLM-3d) |
| `05-RAG-En-Memoria` | Qué demuestra | `AyudaRag` y la comparación pareada con el oro de P-22, **sin condicional** (C1-55 = B) |
| `06-Tool-Calling` | Qué demuestra | segundo lugar del selector, con la prueba de R-C14 (dos proveedores falsos; Application no cambia) |
| `07-Agente-Con-Aprobacion` | Qué demuestra | diff 4.1 → 4.2; `AsAIAgent`; `ApprovalRequiredAIFunction` con el contrato de aprobación (id aleatorio del servidor atado a `SessionId + ConversacionId`, no el `RequestId`; un solo uso; vencimiento; relectura de la entidad al ejecutar) y A1–A5 |
| `07-Agente-Con-Aprobacion` | Qué prueba | suma D1b (aprobación forjada) y D1h (sesión serializada alterada) → 0 ejecuciones; aprobación de la sesión A enviada en B → 0; M14 con solicitud de confirmación |
| `08-Servidor-Y-Cliente-MCP` | Qué demuestra | M13 completo (P2-07): loopback; `AllowedHosts` por el HostFiltering de `WebApplication.CreateBuilder` (no *slim*); middleware de `Origin`; `RequireAuthorization` en CTX-PROD; catálogo único filtrado a lectura; sesión fija de demostración declarada; D7 |
| `08-Servidor-Y-Cliente-MCP` | Qué prueba | tabla Host ajeno → 400, sin token → 401, `Origin` ajeno → 403, válido → 200; `tools/list` igual al `JsonSchema` del catálogo; ninguna herramienta con parámetro de sesión (reflexión); ninguna herramienta de escritura publicada, con `EsDeLectura` probado por reflexión y por nombre (ningún `ApprovalRequiredAIFunction` publicado); se puede partir de `Ronda-2/evidencia-senior-dotnet/R2-mcp-Program.cs` |
| `09-Pruebas-Con-Cliente-Falso` | Qué prueba | reemplaza «PC-02 (spans con doble capa, caché fría y caliente)» por las cinco pruebas de §10.7 (P2-06); reemplaza «`ValidateScopes` `true` y `false` → la herramienta de A ve el `SessionId` de A» por la prueba (a)–(c) de §10.7 (P2-05); suma el `DelegatingHandler` que lee `prompt_eval_cached_count` de un NDJSON fijo (P2-09) y la prueba de P-11 (4) con el prompt de 185 líneas (5134 tokens) de PC-06 |
| `11` | — | sigue sin existir (P2-12) |

**§4 La demo.**

- **Ruta:** `Agregado/` suma `Application/Normalizacion/NormalizadorDeCatalogos.cs` (núcleo). Lo agregado ya no incluye `IngestaDeRequisitos`, almacén vectorial, servidor MCP ni selector de proveedor.
- **Perímetro:** D1–D6 **firmes**. D3: firme (normalizador de P2-04). D5: firme, escalón 0 con `AyudaContextoFijo`; ESC-02 y `AyudaRag` en `Examples/04` y `05`. D6: firme, rama B, `AccionPropuesta` validada + operación normal; prueba: cliente falso que propone una baja → 0 `DeleteAsync` hasta el clic y 1 después, por el caso de uso. D7: **fuera de la demo**, `Examples/08`. D1 suma: el CP inventado se ve en el formulario precargado antes de guardar (el alta también se confirma).
- **CTRL que cambian:** CTRL-02, el normalizador del núcleo, con `Enum.IsDefined` y largo ≤ 60 en la entrada de IA (0 `SaveAsync` al rechazar); CTRL-03, «ninguna herramienta de escritura en la demo (B1); 0 escrituras sin el clic (B4)»; CTRL-06, `Cableado/` con la prueba concurrente (a)–(c); CTRL-07 suma `TamanoMinimoDeCelda` y supresión complementaria como criterio de CTX-PROD (en la demo, sin celda mínima, porque cada sesión agrega sólo lo suyo salvo que falle CTRL-06); CTRL-08, «la rama A con sus spans y el contador, y la doble capa como descartada»; la demo no registra la caché (regla (b)); CTRL-13, `Examples/08`, forma completa; CTRL-14, «0 bajas y ninguna herramienta de escritura disponible» en la demo (texto inyectado en el mensaje, en un fragmento y en `Localidad.Nombre`), con confirmación en `Examples/07`; CTRL-15 suma el largo del nombre de localidad que llega por IA.
- **Página de chat:** sin cambios respecto de P-14 y P-40; la UI de confirmación de `AccionPropuesta` muestra los datos con la codificación por defecto de Razor.
- **Estado de la conversación:** `EventoDelAsistente` suma `AccionPropuesta(tipo, datos)`; el historial lleva el vencimiento de D-11 y no va a registros ni a atributos de telemetría fuera de Development.

**§5 Pendientes de BIT-16-04 (filas que cambian).**

| Pendiente | Queda así |
|---|---|
| P-03 juez | no en la demo; en el segundo servidor, bajo demanda y por la mesa, 10 × 2 × 3 con N = 1 en unos 35 min, k/n con Wilson y nunca como compuerta; en la estación, «no medido» (P2-11) |
| P-05 recuperación | `Examples/04` (P2-02) |
| P-06 oro de C4 | `Examples/05` (P2-02) |
| P-07 comparativo CAG/RAG | `Examples/05`; con un modelo mayor, en el segundo servidor bajo demanda (presupuesto: unos 51 s por cada 3500 tokens de prompt sin caché con el 35b-a3b); en la estación, «≥ 7B no se midió» (P2-10) |
| P-08 truncado | suma el prompt de 5134 tokens de PC-06 para la prueba de P-11 (4) (P2-09) |
| P-10 `ValidateScopes` | forma (a)–(c) de §10.7 en `Cableado/` de la demo y de `Examples/09` (P2-05) |

### 10.3 RV nuevas, reemplazadas o ampliadas

| RV | Regla | Parche | Cómo se verifica |
|---|---|---|---|
| RV-01 (ampliada) | Lo de P-01 (d), más: ningún ejemplo pone credenciales ni secretos en `ChatRequest.<clave-de-cabeceras>` ni en otro campo que viaje en el cuerpo; las credenciales van en el `HttpClient` de `IHttpClientFactory` o en un `DelegatingHandler`; toda captura de cuerpo que se publique pasa la compuerta con `cabeceras=0`. Las cifras del segundo servidor llevan «medido en una estación de laboratorio con más núcleos (CPU sin GPU; contenedor limitado a 14 CPU / 34 GiB; Ollama 0.40.11), fecha», sin nombre de equipo ni de contenedor, y nunca se mezclan con las de la estación de 4 CPU sin decir cuál es cuál | P2-01, P2-10 | `rpriv.sh` v2 sobre la guía, `Examples/` y `Demos/` = 0 en los tres recuentos; `grep -rni "<clave-de-cabeceras>"` = 0 fuera del bloque rotulado como antipatrón (cubre el Markdown); lectura de cada cifra |
| RV-03 (reemplazada) | En «Operar, evaluar y asegurar», el orden es caché → `UseFunctionInvocation` → `UseOpenTelemetry` → cliente. El contador se llama `movilidadurbana.ai.cache.aciertos` y se incrementa en `ReadCacheAsync` y en `ReadCacheStreamingAsync` (con `CoalesceStreamingUpdates` en `true`, el valor por defecto, el streaming lee por `ReadCacheAsync`; con `false`, por `ReadCacheStreamingAsync`). La clave lleva `SessionId`, y además `VersionDeDatos`, leída en cada pedido, donde se cachean pedidos con herramientas. La guía dice que un acierto no vuelve a ejecutar las herramientas y da la regla de la demo (sin caché para pedidos con herramientas de lectura). El limitador va en la entrada HTTP, con 503 y `Retry-After`. La doble capa aparece sólo como alternativa descartada, con el doble conteo de tokens como motivo | P2-06 | `grep -n "doble capa"` sólo como descartada; `grep -rn "ia\.cache\.aciertos"` = 0; `grep -rn "ReadCacheStreamingAsync y no con ReadCacheAsync"` = 0; `grep -n "int.MaxValue\|llama3.1"` = 0; «no vuelve a ejecutar las herramientas» presente |
| RV-17 (reemplazada) | Toda tasa lleva la cabecera R-LLM-4 con su estimando («este pedido» o «la tarea»). Ninguna comparación entre variantes dice «difiere» o «es mejor» sin cumplir R-LLM-3e (≥ 6 pares discordantes todos en el mismo sentido); si no la cumple, dice «no separado con este N». Una tasa de la tarea exige K ≥ 10 pedidos redactados antes y m ≥ 3 por pedido, con el intervalo sobre los pedidos, nunca Wilson sobre K·m. Las garantías se enuncian como invariantes con su prueba de cableado. «Con N ≤ 10 sólo existencia» rige para afirmaciones verbales; el k/n con su intervalo se puede mostrar siempre | P2-13 | `grep -nE "[0-9]+/[0-9]+"` en la guía, cada fracción con su estimando; `grep -n "mejor\|difiere"` junto a una cifra, cada una con sus pares discordantes declarados; ninguna tasa de tarea con K < 10 |
| RV-20 | En la guía y en la demo, el 404 por un id de otra sesión se presenta como lo que es: no es control de acceso; el `X-Sesion-Id` elegido por el cliente es débil | P2-03 | `grep -n "control de acceso"`, con la frase del 404 |
| RV-21 | En la sección de la demo, ninguna herramienta que escriba; la escritura es una `AccionPropuesta` validada (B1–B4) que la persona confirma con la operación normal; `ApprovalRequiredAIFunction` se enseña en la sección de agentes con `Examples/07` | P2-03 | `grep -rn "ApprovalRequiredAIFunction\|AprobacionPendiente\|aprobaciones/" Demos/` = 0 |
| RV-22 | La tabla de diferencias entre la vía nativa y `/v1` aparece una sola vez, en «Hablar con un modelo desde .NET», y toda mención de `TopK`, `MaxOutputTokens` o `num_ctx` por `/v1` remite a ella | P2-08 | búsqueda de los tres nombres |
| RV-23 | El término de la definición de agente es el de P2-14; «agente de MAF», «workflow de MAF» y «agente mínimo» con su calificativo; sentidos excluidos en 0; el sentido (a) de workflow con `[C: término de C1-32]` hasta que decida la presidencia | P2-14 | C5 ampliada (§10.5); `grep "\[C: término de C1-32\]"` = 0 al cierre |
| RV-24 | Las cifras del 2b siempre con Q8_0, 2,68 GB y su digest (no las de la biblioteca web); el 4b siempre «provisional»; nunca «el 4b es mejor» sin estimando | P2-10 | `grep -n "qwen3.5:2b\|qwen3.5:4b"` |

### 10.4 Barridos nuevos (sobre la guía, `Examples/` y `Demos/`; deben dar 0)

`pierde la sesión`, `falla al arrancar` junto a `ValidateScopes`, `mezcla sesiones` (P2-05); `AyudaRag`, `IAlmacenDeRequisitos`, `MapMcp`, `McpServerTool`, `AprobacionPendiente`, `aprobaciones/`, `Proveedor`, `Evaluation`, `UseDistributedCache` o `CacheConContador` sin la sobrescritura de `EnableCaching` (en `Demos/`; P2-02, P2-03, P2-06, P2-08, P2-11); `estado del servidor` junto a `num_ctx`, `si el cliente la expone` (P2-09); `no se comparó punta a punta` (P2-10); `agentic workflow`, `flujo agéntico`, `flujo de trabajo` (P2-14); `<clave-de-cabeceras>` fuera del bloque rotulado como antipatrón (P2-01, P2-08); `ia.cache.aciertos` y «`ReadCacheStreamingAsync` y no con `ReadCacheAsync`» (P2-06); `Comentario` (P2-12, sigue el de P-44); `[McpServerTool]` fuera del bloque «alternativa con dos definiciones» en `Examples/08` (P2-07). Los barridos de §6 sobre `AyudaRag` y `ApprovalRequiredAIFunction` en `Demos/` **dejan de ser condicionales**, y el de `Proveedor` en `Demos/` ya no admite la variante «sin num_ctx» (no entra en la demo).

### 10.5 Compuertas de §7 que cambian

| Compuerta | Cómo se corre desde hoy | Criterio |
|---|---|---|
| R-PRIV | `RPRIV_LISTA=<privado, fuera de la raíz> RPRIV_SINTETICOS=Bitacoras/Mesa/Ciclo-1/Ronda-2/aplicacion/rpriv-sinteticos.txt Bitacoras/Mesa/Ciclo-1/Ronda-2/aplicacion/rpriv.sh <raíz> > rpriv-$(date +%F).txt` (v2; la v1 de `aplicacion/rpriv.sh` queda como antecedente) | sobre la raíz de la guía, `Examples/` y `Demos/`: sale 0 (`patrones=0 identificadores=0 cabeceras=0`); sobre `OUTPUTs/`: `patrones=0` y `cabeceras=0` siempre, e `identificadores=0` en el barrido previo al primer commit (dictamen §2). Cierra la salida guardada; dejar un archivo fuera del commit no cierra. Un sintético se declara por valor exacto en `rpriv-sinteticos.txt`, nunca se excluye un archivo |
| R-LLM | cabecera R-LLM-4 en cada salida contra el modelo | `grep -L "modelo@"` = 0 y además `grep -L "estimando:"` = 0 sobre las salidas de `Examples/` y `Demos/`, con las semillas declaradas |
| C5 glosario | búsqueda de cada término del Anexo C | una sola definición de agente; `grep -niE "agentic workflow\|flujo agéntico\|flujo de trabajo"` = 0; cada «workflow» o «agente» junto a un tipo de MAF (`AIAgent`, `WorkflowBuilder`, `AsAIAgent`) con el calificativo «de MAF» |
| C2 trazabilidad | `grep '\[C:'` sobre la guía | 0 marcas, incluida `[C: término de C1-32]`: sin la decisión de la presidencia no hay cierre |
| Validación del núcleo (P2-15) | `grep -c "^## Validación del núcleo"` por registro | = 1 en cada uno antes de declarar el cierre; la sección que deriva de N5 §4.2 no tiene fecha anterior a la salida de las pruebas de §10.7 |

### 10.6 Parches del ciclo 1 modificados y qué los reemplaza

| Parche del ciclo 1 | Qué cambia | Lo reemplaza o completa |
|---|---|---|
| P-01 (c), (d) | compuerta v1 → v2 con `cabeceras=`; RV-01 ampliada | P2-01 |
| P-02 | el «N ≥ 96 por aproximación normal» → tasa de la tarea según R-LLM-3d | P2-13 |
| P-03 | rama A elegida; limitador fuera de la cadena (M9 sin cambio de texto); clave con sesión obligatoria en cualquier orden | P2-06 (vuelta 2) |
| P-05 | rama A firme; rama B anulada; el mapeo ESC/CTX queda | P2-02 |
| P-11 (M10) | suma credenciales fuera del cuerpo, `TopK`/`MaxOutputTokens` por vía y mismo `num_ctx` en todos los clientes | P2-08, P2-09 |
| P-12 | título de D-06 y sus dos frases | P2-05 |
| P-13 | rama B en la demo; rama A a `Examples/07`; historial con vencimiento y fuera de registros | P2-03 |
| P-15 | almacén, ingesta y MCP como piezas de ejemplos en el diagrama | P2-02 (nota consolidada de §6.2), P2-07 |
| P-16 (RV-14) | suma la deuda del largo 60, «declarado, no aplicado por la API» | P2-04 |
| P-17 | rama mayoritaria firme (normalizador en `Agregado/Application/Normalizacion`); rama B anulada | P2-04 |
| P-18 | la celda: cerrada (M7 en CTX-PROD con supresión complementaria) | P2-07 |
| P-19 | la señal de reuso «si el cliente la expone» → lo medido (handler o `/v1`) | P2-09 |
| P-20 | hecho medido sin `num_ctx` (recarga a 4096; truncado 5 de 5 con el 0.5b) y MI-18 «configuración, no estado» | P2-09 |
| P-21 (§R.6) | cinco filas nuevas con columna «servidor» | P2-10 |
| P-22 | parte de demo: el candidato de ESC-02 sale de la demo (`Examples/04`) | P2-02 |
| P-23 | rama B firme (`AyudaRag` en `Examples/05`); rama A anulada | P2-02 |
| P-24 (2) | «con N ≤ 10 sólo existencia» → R-LLM-1…5; (1) y (3) quedan | P2-13 |
| P-25 | los tres tipos de aserción se definen con R-LLM-3 | P2-13 |
| P-26 | fila MCP de N4: catálogo único con `McpServerTool.Create` | P2-07 |
| P-27 | de parcial a firme: M6 concurrente, M7, M13 completo en `Examples/08`, M14 sin herramientas de escritura, M15 con el largo | P2-07, P2-03, P2-12 |
| P-31 (2) | definiciones de agente, herramienta, orquestación y workflow de MAF; «Workflow» espera C1-32 | P2-14 |
| P-33 | cerrado: muestreo del fabricante tipado sólo por la vía nativa | P2-08 |
| P-34 | firme, con lo que levanta cada bloqueo | P2-15 |
| P-35 | rama B firme; rama A anulada para la demo; la parte común queda | P2-03 |
| P-36 | rótulo provisional → rótulo medido 2b/4b | P2-10 |
| P-37 | «se apaga al terminar» → «el apagado lo decide la presidencia»; suma el 35b-a3b medido (21 GiB) | P2-10 |
| P-38 | el costo del juez deja de ser «no medido» | P2-11 |
| P-39 | re-registrado; la variante «sin num_ctx» tampoco entra en la demo | P2-08 |
| P-42 | suma la constante `TelemetriaDeIA.AciertosDeCache` | P2-06 |
| P-44 | rama conceptual anulada: entra `Localidad.Nombre` | P2-12 |
| RV-03, RV-17 de §6 | reemplazadas (§10.3) | P2-06, P2-13 |
| RV-01 de §6 | ampliada (§10.3) | P2-01, P2-10 |

Los demás parches del ciclo 1 y las RV de §6 que no aparecen acá siguen igual.

### 10.7 Pruebas que la redacción tiene que hacer pasar

Todas sin modelo, en `Cableado/`, con el recurso `build` y `mcr.microsoft.com/dotnet/sdk:10.0`, salvo que diga otra cosa. Ninguna se declara verde por estar escrita acá.

- **P2-03 (demo):** (i) el conjunto de nombres de las `AIFunction` registradas (bucle y, si lo hubiera, MCP) es igual a una lista cerrada de herramientas de lectura declarada en la prueba; (ii) cada herramienta registrada se invoca con argumentos válidos sobre repositorios espía y el recuento de `SaveAsync` y `DeleteAsync` da 0; prueba D3: `tipo = 5`, `id = -1` e id de otra sesión → las tres propuestas descartadas antes de la UI, 0 llamadas al repositorio; B4: cliente falso que propone una baja → 0 `DeleteAsync` hasta el clic, 1 después. En `Examples/07`: D1b, D1h y dos sesiones → 0 ejecuciones.
- **P2-04 (demo):** `diff -r = 0` y `dotnet build` de la copia sola, con la salida en `PROCEDENCIA.md`; `Application/` sin archivos ajenos al origen; «piedra» por los dos caminos (la guía muestra lo que dé); enum 5 y nombre de 61 rechazados por la herramienta con 0 `SaveAsync`; la regla de P-30 en verde con `Agregado/Application/Normalizacion` sin MEAI ni Infrastructure.
- **P2-05 (demo y `Examples/09`):** forma (a)–(c): (a) la clase real `Infrastructure/Sessions/SessionContext.cs` copiada; (b) dos sesiones concurrentes con barrera, `ValidateScopes` en `true` y en `false`, pipeline Singleton y Scoped; (c) con Scoped, B no ve ni borra lo de A (`borradas 0`); con Singleton y `false`, la prueba falla como caso rojo.
- **P2-06 (`Examples/09`; cinco pruebas, cliente falso con guion, fuente de P-42):** (1) caché fría con una herramienta → spans `orchestrate_tools`, `chat`, `execute_tool`, `chat`. (2) Caché caliente por `GetResponseAsync` → 0 spans, 0 llamadas al cliente, el instrumento buscado **por el nombre** `movilidadurbana.ai.cache.aciertos` en 1, histograma de tokens sin registro nuevo; si el instrumento falta o tiene otro nombre, falla. (2b) Por `GetStreamingResponseAsync`, en los dos modos: (i) con `CoalesceStreamingUpdates` por defecto, 0 llamadas y contador en 1; (ii) con `false`, 0 llamadas y contador en 1; caso rojo, sólo en (ii): una subclase que sólo sobrescribe `ReadCacheAsync` deja el contador en 0; en (i) esa misma subclase da 1, y la prueba lo afirma. (3) Dos sesiones con el mismo texto → dos fallos y llamadas al cliente en las dos. (4) Misma sesión **y misma instancia del cliente**: lectura cacheada → escritura confirmada (`VersionDeDatos` de 0 a 1) → mismo texto → fallo, `execute_tool` presente, contador sin cambio; casos rojos: sin `VersionDeDatos` en la clave → acierto, y versión leída al crear la instancia → acierto. **En la demo:** `UseDistributedCache` o `CacheConContador` no aparecen en la composición, o aparecen junto a la sobrescritura de `EnableCaching`; si la demo registra caché, corre (2b), y (4) por circuito si pasa a la regla (a). `VersionDeDatos` vive en el almacén por sesión de D-11. Las salidas de las sondas están en `Bitacoras/Integracion-Evidencia/C-operacion-demo/` (`PC02-salida.txt`, `P2-06v2-salida.txt`, `P206v2-salida.txt`).
- **P2-07 (`Examples/08`):** la tabla 400/401/403/200 y `tools/list` contra el `JsonSchema`, compiladas y corridas; `[McpServerTool]` = 0 fuera del bloque alternativo; M6 concurrente en verde (es la de P2-05).
- **P2-08 (`Examples/01`):** captura de cuerpo por las dos vías con servidor falso, filas `TopK` y `MaxOutputTokens`.
- **P2-09 (`Examples/09`):** el `DelegatingHandler` lee `prompt_eval_cached_count` de un NDJSON fijo.
- **P2-12 (demo):** M14 con `Localidad.Nombre` inyectado devuelto por la herramienta de lectura y un cliente falso que pide una baja → 0 bajas y ninguna herramienta de escritura disponible.
- **P2-02, P2-10, P2-11, P2-13, P2-14:** son de texto; se verifican con los barridos de §10.4 y las compuertas de §10.5.

### 10.8 Lo que sigue abierto, con su default

| Abierto | Dueño | Default que aplica la redacción mientras tanto |
|---|---|---|
| Sentido de «workflow» (C1-32) | presidencia | marca `[C: término de C1-32]` en cada frase del sentido (a); formas comunes ya vigentes; bloquea el cierre (C2) |
| Apagado del segundo servidor | presidencia, antes del cierre del ciclo 1 | nada de la redacción depende de él; ninguna corrida nueva sin pedido de la mesa |
| S1 de N0b y N5 §4.2 | redacción (pruebas de §10.7) | redacta el resto de la guía; esas secciones esperan las pruebas |
| Frase comparativa CAG/RAG | redacción (`Examples/05`) | la sección de conocimiento no compara hasta tener la corrida |
| Divergencia de «piedra» | — (registrada) | la guía muestra el resultado de cada camino, sin decir que coinciden |
| Afirmaciones en nivel C de §10.1 | redacción (`Examples/`) | no se afirman; se escriben como «no probado» si hace falta nombrarlas |
| Primer commit de `OUTPUTs/` | presidencia | barrido de redacción con la compuerta v2 e `identificadores=0` (dictamen §2) |

**Escaladas:** ninguna. No hubo empates en la segunda ronda (los 29 ítems con mayoría de 3 o más, sin vetos) ni parches `ESCALAR` en la aprobación. El registro está en `Bitacoras/Escaladas.md`.
