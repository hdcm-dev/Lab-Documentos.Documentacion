---
doc_id: BIT-16-C1-INF-CAT-operacion-entrega-rendimiento
doc_type: informe-de-especialista
title: Informe a ciegas — Operación y entrega, con Rendimiento y costo fusionado (ciclo 1)
status: hecho
origin: agent
owner: especialista CAT-OP (catálogo convocado, BIT-16-C1-00 §5.1)
last_review: 2026-10-28
audience: [mesa-evaluadora, presidencia, relator, jurado]
traces: [BIT-16-C1-00 §5.1, REED-16 §8, §9.1, §9.2, §12, §13, BIT-16-00 §3, BIT-16-04 §1–§7, Sondeo-Entorno §R, Nucleos/N0b, N3, N3b, N5, N6, M§8]
---

# Informe CAT-OP: Operación y entrega, con Rendimiento y costo

**Pregunta del mandato** (BIT-16-C1-00 §5.1): ¿se sostiene lo que la guía afirma sobre latencia, ventana de contexto, concurrencia, observabilidad, ciclo de vida del cliente y costo? ¿Lleva cada cifra la marca «medido en estación 1» o «no medido»?

**Respuesta corta.** Las reglas de diseño se sostienen en general. Las **cifras** no se sostienen. Hay cuatro mal derivadas de su propia salida cruda y ninguna lleva rótulo. Además, dos controles mínimos (M9 y M10) están escritos de forma que el ejemplo falla en estación 1. Un tercero (M6) se apoya en una prueba que sólo vale en Development. La guía no existe todavía, así que todo nace en la integración o en los núcleos y se repara ahí.

Trabajé a ciegas: no leí ningún otro `Informe-*.md` de este ciclo. La evidencia propia (O1…O5) está en [`evidencia-CAT-operacion-entrega-rendimiento/`](evidencia-CAT-operacion-entrega-rendimiento/README.md). Corrí con turno `<recurso-compartido>` y `build`, con el endpoint sólo por variable de entorno (R-PRIV) y sin bin/obj al terminar.

## Índice

- [1. Evidencia producida](#1-evidencia-producida)
- [2. Hallazgos](#2-hallazgos)
- [3. Lo que revisé y está bien](#3-lo-que-revisé-y-está-bien)
- [4. Posición sobre los MI de mi mandato](#4-posición-sobre-los-mi-de-mi-mandato)
- [5. Qué entra en el turno de 45 minutos](#5-qué-entra-en-el-turno-de-45-minutos)
- [6. MI-03: mesa o escalada](#6-mi-03-mesa-o-escalada)
- [7. Solicitudes de convocatoria](#7-solicitudes-de-convocatoria)

## 1. Evidencia producida

| Id | Qué | Nivel | Resultado |
|---|---|---|---|
| O1 | Re-consulta de las 24 versiones de X0 (2026-10-28 09:57 -03) | E1 | Sin cambios respecto de X0 (08:56) |
| O2 | Registro de NuGet: deprecaciones y cadencia de MAF | E1 | `Microsoft.Extensions.AI.Ollama` deprecado (14 versiones; alternativa `OllamaSharp`). `Microsoft.Agents.AI`: 7 estables en 62 días (1.19.0 el 08-22 … 1.26.0 el 10-23) |
| O3 | `/api/chat`: caché de prefijo, `prompt_eval`, cola | E1, R-LLM | `prompt_eval_count` da el largo total también con caché. `qwen3.5:4b` con 1469 tokens sin caché: **111,7 s** con el modelo cargado; repetido idéntico: 0,7 s. Dos pedidos simultáneos: 9,2 s y 17,4 s (serializa) |
| O4 | X1 [B] con `ValidateScopes=false` (P-10) | E1 | Cliente Singleton: la herramienta **no falla** y ve el `SessionContext` raíz `(vacío)` en las dos sesiones |
| O5 | Contexto fijo de unos 1540 tokens: otra pregunta y pedido intercalado | E1, R-LLM | En frío: 71,7 s. Otra pregunta con el mismo sistema: 26,0 s. Después de intercalar otro pedido: 27,6 s. Reuso **parcial** |
| E4 | Docs de Agent Framework *Background responses* (ms.date 2026-09-24) y .NET DI *Scope validation* (ms.date 2026-01-26), consultadas el 2026-10-28 | E4 | «only agents that use the OpenAI Responses API support background responses»; la validación de scopes corre «when an app runs in the development environment» |

Todas son mediciones de **una estación CPU-only en banco exclusivo**, con N de 1 a 3. Sirven para decidir qué cabe y qué falla en estación 1. No son propiedades del patrón.

## 2. Hallazgos

### CAT-OP-01 — El timeout por defecto no alcanza en estación 1 y la decisión «sincrónico o en segundo plano» no puede seguir abierta

- **Ubicación**: `04-Integracion.md` §6.3, M10 (l. 336) y §5, MI-24 (l. 183); `Nucleos/N3-RAG-En-NET.md` §6.2 A7 (l. 396); `Nucleos/N0b-Producto-Datos-Y-Perfil.md` §3.4.11 (l. 314), §9.8 (l. 455) y R18 (l. 540).
- **Severidad**: S2. Un ejemplo que el implementador no puede reproducir: con el valor por defecto, en estación 1, falla.
- **Evidencia (E1 + E4)**:
  - Un prompt de 1469 tokens, chico frente a la ventana de 4096, tardó **111,7 s** de `prompt_eval` con el modelo ya cargado (O3b). El `HttpClient` por defecto de `OllamaApiClient` corta a 100 s (N3 V1/V3).
  - Una operación .NET con herramientas llegó a **91,8 s** (E-B1, `Integracion-Evidencia/B-abstracciones-agentes/sonda/salidas/01-b1-b2.jsonl`, corrida 3, vía ollama). El 0.5b con un prompt truncado tardó 80,9 s y 157,9 s (X3).
  - **Ninguna sonda E1 usó el valor por defecto.** `A-arquitectura/exp-capas/Experimento/Program.cs` l. 55 fija 5 min, y `B-abstracciones-agentes/sonda/Program.cs` l. 28 fija 10 min. M10 dice «timeout por configuración» sin valor ni regla.
  - Con `OLLAMA_NUM_PARALLEL=1` (X4), el segundo de dos pedidos simultáneos espera todo el servicio del primero (O3c: 9,2 s frente a 17,4 s). La pared de un endpoint sincrónico suma la cola, que el limitador de M9 no acota (ver CAT-OP-03).
  - N0b R18 y §3.4.11 dejan «sincrónico o en segundo plano» sin fuente. La doc vigente cierra la vía del proveedor: «Currently, only agents that use the OpenAI Responses API support background responses» (Agent Framework, *Background responses*, ms.date 2026-09-24, consultada el 2026-10-28). `AllowBackgroundResponses` no aplica a OllamaSharp ni a `/v1/chat/completions`.
- **Propuesta**:
  - M10 tiene que enunciar una **regla** como propiedad del patrón: el timeout del cliente tiene que superar la peor pared esperada más la cola, se propaga `CancellationToken` desde `HttpContext.RequestAborted` y el valor sale de configuración. En estación 1 se fija un valor rotulado «elegido a partir de lo medido en estación 1». Las sondas ya usaron 5 y 10 min.
  - MI-24 se resuelve así: la demo es **sincrónica con streaming** en la página de chat (el ejemplo 02 de N6 ya lo cubre) y con cancelación. El «segundo plano» de aplicación (`BackgroundService` con cola, 202 y consulta) va a CTX-PROD sin implementar, como criterio propio con fuente de ASP.NET Core.
  - R18 se cierra con la cita E4: la vía del proveedor no está disponible con Ollama.
- **Capa**: integración (M10, MI-24). Nace en los núcleos N3 (A7) y N0b (R18).

### CAT-OP-02 — Cuatro cifras de latencia están mal derivadas de su salida cruda y ninguna lleva rótulo

- **Ubicación**: `Sondeo-Entorno.md` §R.5, puntos 1 (l. 301) y 6 (l. 306); `04-Integracion.md` §5, MI-24 (l. 183), y §6.3, M5 (l. 331); `00-Convocatoria.md` B-14.
- **Severidad**: S2. Si alguna pasa a la guía tal como está, es S1: afirmación técnica falsa.
- **Evidencia (E1, sumas sobre los `.jsonl` crudos)**:
  1. §R.5.6 dice que «una suite de 10 llamadas a herramientas con el 4b tarda menos de un minuto». `04-tools.jsonl` suma **76,72 s** y `05-tools-apie.jsonl` suma **63,55 s**. Esa frase es la base del alcance de estación 1 y de MI-03.
  2. §R.5.1 dice «entre 5 y 19 s por respuesta corta o llamada a herramienta con el modelo caliente». Los 18,90 s de §R.2 **incluyen 10,48 s de carga**: en caliente, el chat da unos 8,4 s y las herramientas 4,65–4,96 s.
  3. MI-24 dice «paredes 13–58 s» (X2). La serie D2 empieza con **75,63 s** (`seed 1`, `cached_tokens 0`) y el rango la omite sin decirlo. El rango real es 12,93–75,63 s, y el total de las 30 llamadas es de 688 s.
  4. M5 dice «paredes de 5–92 s por iteración» sin fuente. El 5 sale de una llamada HTTP sola (§R.4: 4,65 s) y el 92 de una **operación** .NET completa con el bucle de herramientas (E-B1: 91,8 s, dos llamadas al modelo). No es «por iteración».
  - Ninguna de las cuatro, ni las de §R.2–R.4, lleva «medido en estación 1». El perfil del entorno (README, nota del 2026-10-28, l. 92; BIT-16-04 §0) dice «30 GB» y no menciona el límite del contenedor (X4: `NanoCpus=4000000000`, `Memory=5368709120`, es decir 4 CPU y 5 GB), que es lo que efectivamente acota la carga de modelos.
- **Propuesta**: una sola tabla de cifras de estación 1, anclada en BIT-16-04 o en el Anexo E, con fuente, N, frío o caliente, unidad (por llamada HTTP o por operación) y límites del contenedor. La guía cita rangos sólo con el rótulo «medido en estación 1 (CPU de 4 núcleos, contenedor de 4 CPU / 5 GB, Ollama 0.40.11, fecha)». Las afirmaciones de patrón no llevan números: «en CPU, la carga en frío y la evaluación del prompt dominan la pared». Corregir §R.5.1 y §R.5.6 con una nota fechada (sólo agregado).
- **Capa**: integración (MI-24, M5). Nace en el registro de sondeo.

### CAT-OP-03 — El snippet de limitación de N5 contradice el orden de R-C07 y su cola no tiene límite

- **Ubicación**: `Nucleos/N5-Operacion-Calidad-Seguridad.md` §4.2 (l. 246–272), frente a §4.1 (l. 244), `04-Integracion.md` R-C07 (l. 110), M8 y M9 (l. 334–335).
- **Severidad**: S1 por el contrato (contradicción entre secciones), aunque se repara barato.
- **Evidencia (E2 + E1)**:
  - El §4.2 arma `UseDistributedCache` → limitador → `UseOpenTelemetry` (la telemetría **queda adentro**). El §4.1 del mismo núcleo y R-C07 fijan «`UseOpenTelemetry` (afuera) → caché → limitador → `UseFunctionInvocation`». La nota «Reparación de integración» de N5 (l. 742 y siguientes) no menciona el §4.2.
  - El limitador es `new ConcurrencyLimiter(new() { PermitLimit = 1, QueueLimit = int.MaxValue })`, y el texto dice que «Responde a LLM10 Unbounded Consumption». Con una cola sin límite y sin timeout, la espera crece sin cota: cada pedido encolado suma un servicio completo (O3c), de 9 a 112 s en estación 1 (O3b, X2). El límite de consumo pasa del servidor de modelos a la memoria y al tiempo de espera de la API.
  - El snippet además fija `"llama3.1"`, un literal que R-C11 ya mandó a `OLLAMA_MODEL`.
- **Propuesta**: reescribir el §4.2 con el orden de R-C07. M9 tiene que exigir `QueueLimit` acotado, configurable y chico, con respuesta explícita al saturarse (por ejemplo 503 o 429 con `Retry-After`), y cancelación. El número queda «elegido, no medido». Agregar una prueba de cableado: con un cliente falso lento, el pedido N+1 se rechaza.
- **Capa**: núcleo (N5 §4.2). La integración no lo reparó.

### CAT-OP-04 — El ciclo de vida del cliente se probó sólo como en Development: en Production el error no salta y mezcla sesiones

- **Ubicación**: `04-Integracion.md` R-C04 (l. 105: «Sin `ValidateScopes` no se probó»), §6.3 M6, §5 MI-23 (l. 182), §7 P-10 (l. 355, «Opcional»); `Integracion-Evidencia/C-operacion-demo/X1-sonda-otel-t1-salida.txt` (nota final).
- **Severidad**: S2. La evidencia que respalda M6 sólo vale en Development, y nada lo dice.
- **Evidencia (E1 + E4)**:
  - O4 repite X1 [B] con `ValidateScopes=false`: con el cliente Singleton, la herramienta **no lanza excepción**. Ve `SessionId=(vacío)` en sesion-A y en sesion-B, es decir el `SessionContext` de la raíz, compartido.
  - La doc de .NET dice que la validación corre sólo «when an app runs in the development environment» y que un Scoped resuelto desde la raíz queda «effectively promoted to singleton» (*Dependency injection — Scope validation*, ms.date 2026-01-26, consultada el 2026-10-28).
  - El `InvalidOperationException` de X1 sólo aparece en Development. Fuera de Development, el mismo error de registro se ve como una herramienta que corre con el contexto de sesión equivocado.
- **Propuesta**:
  - P-10 deja de ser opcional: queda cerrado con O4.
  - M6 se enuncia como regla («herramientas con `SessionContext` exigen cliente Scoped o herramientas por petición»), con una **prueba de cableado que construye el proveedor con `ValidateScopes=false`** y verifica aislamiento entre dos scopes, y además `ValidateOnBuild`/`ValidateScopes` explícitos en la demo.
  - MI-23 va dentro de D-06 con este contenido (ver §4).
- **Capa**: integración (R-C04, P-10). Lo que esto implica para la seguridad lo pido a AH-01 en §7.

### CAT-OP-05 — Al plan del turno de 45 min y a MI-03 les faltan números, y la causa de «≥ 7B no corre» no está medida

- **Ubicación**: `04-Integracion.md` §5 MI-03 (l. 162), §7 P-01, P-03, P-07 (l. 346–352), R-C09 (l. 112); `Nucleos/N3b-CAG-Y-Estrategias-De-Conocimiento.md` nota de integración (l. 605: «no corre en estación 1 (4 núcleos, sin GPU)»); `Sondeo-Entorno.md` §R.5.6.
- **Severidad**: S2. La asignación de corridas se decide con una premisa falsa («menos de un minuto», CAT-OP-02) y sin costo estimado.
- **Evidencia (E1)**:
  - Con lo medido, el juez de P-03 (10–20 casos, varios evaluadores, N corridas sin caché) son llamadas con contexto de 1–1,5 k tokens, de **70–112 s cada una sin caché** (O3b, O5). Entre 90 y 180 llamadas dan 2–5,5 h: no entra en un turno.
  - P-01 (cuatro pedidos ×10 por la vía .NET): X2 tardó 688 s para 30 llamadas HTTP, y la vía .NET con bucle de herramientas hace al menos dos llamadas por operación (E-B1). Son unos 30–60 min, o sea dos turnos.
  - «≥ 7B no corre en estación 1» no está medido, y la causa citada (4 núcleos) no impide correr un modelo: lo hace lento. Lo que sí acota es el contenedor de 5 GB con `OLLAMA_MAX_LOADED_MODELS=2` (X4), y eso no figura en ningún perfil del entorno.
- **Propuesta**: adoptar la tabla de §5 de este informe como plan de turnos y rotular «no medido» lo que quede afuera. MI-03 va por la mesa, con las condiciones de §6. La razón de «≥ 7B en otra estación» se reescribe: «no se midió en estación 1; el contenedor está limitado a 4 CPU / 5 GB».
- **Capa**: integración (§7, MI-03). Nace en el registro de sondeo y en N3b.

### CAT-OP-06 — La compuerta de versiones de §9.1 compara contra la guía, no contra nuget.org, y DC-08 no tiene chequeo de contenido

- **Ubicación**: `Crear-IA-Layer-Guide-Reedicion.md` §9.1, compuertas adicionales (l. 361); `04-Integracion.md` §7 P-13 (l. 358) y tensión 8; `00-Contrato-De-Entrada.md` DC-08 (l. 80).
- **Severidad**: S3.
- **Evidencia (E1 + E2)**:
  - §9.1 pide «versiones de los `PackageReference` iguales a las que cita la guía». Eso detecta una incoherencia interna, pero no una guía vieja.
  - MAF publicó 7 estables en 62 días (O2), así que la 1.26.0 del 2026-10-28 seguramente no sea la vigente al publicar.
  - P-13 vive en «pendientes» y no en la compuerta.
  - DC-08 pide `.gitignore` «presentes», y la compuerta sólo verifica eso. No exige que excluya las bases SQLite ni los almacenes vectoriales generados. `Examples/` y `Demos/` hoy están vacíos, así que no hay nada que correr todavía.
- **Propuesta**: la compuerta mecánica de §9.1 suma tres chequeos:
  1. `X0-nuget-consultar.sh` (o el de O1) con el listado del Anexo D, el mismo día de la publicación, y diferencia vacía o tabla actualizada con fecha.
  2. Consulta de `deprecation` en el registro (script de O2) para cada paquete citado.
  3. `git check-ignore` de rutas testigo (`bin/`, `obj/`, `*.db`, `*.sqlite*` y la carpeta del almacén vectorial) en cada proyecto de `Examples/` y `Demos/`.
- **Capa**: pedido (REED-16 §9.1), con P-13 de la integración.

### CAT-OP-07 — El costo en un servidor local se mide en tiempo, la entrada domina en CPU y el reuso de prefijo es parcial con el modelo propuesto

- **Ubicación**: `Nucleos/N5-Operacion-Calidad-Seguridad.md` G4 (l. 29) y §4.1 (l. 244); `04-Integracion.md` §6.3, diagrama (escalón 1, «prefijo estable cacheado (CAG)»), y MI-07.
- **Severidad**: S3. Es la lectura de costo y latencia. El concepto de CAG queda fuera de mi mandato.
- **Evidencia (E1)**:
  - En estación 1, la evaluación del prompt del 4b corre a 13–22 tok/s (O3b, O5; N = 1 cada una) y la generación a unos 7 tok/s (§R.2). Con un contexto fijo o un RAG de unos 1500 tokens, **la entrada domina la pared**.
  - Un prompt idéntico se reusa casi gratis (0,7 s, O3b), pero cambiar sólo la pregunta con el mismo sistema bajó de 71,7 s a 26,0 s, no a menos de 1 s (O5).
  - `UseDistributedCache` sólo ayuda con pedidos idénticos (R-C07). N5 G4 presenta «tokens como unidad de costo» sin decir que, en local, el costo es tiempo de CPU y cola (O3c).
- **Propuesta**: en §7 de la guía, que el costo local se exprese como pared y ocupación del único hueco (`NUM_PARALLEL=1`), medido en estación 1, y el costo por token como dimensión de la nube, citada con fuente. El escalón 1 se rotula «beneficio dependiente del modelo y del servidor; en estación 1 con `qwen3.5:4b`, reuso parcial (O5)», sin cifra de patrón. Para MI-07, `AyudaContextoFijo` por defecto paga unos 25–70 s por pregunta en estación 1: es un dato de decisión, no un veto.
- **Capa**: núcleo (N5 G4) e integración (§6.3).

## 3. Lo que revisé y está bien

1. **MI-18 es viable en 0.40.11.** `prompt_eval_count` de `/api/chat` informa el largo total aunque haya caché de prefijo (O3a: 1787 en las tres repeticiones con 30 s, 0,52 s y 0,46 s; O5: 1541, 1538 y 1540). `usage.prompt_tokens` de `/v1` también da el total (X2: 576 con `cached_tokens` 572). La comparación con el largo esperado no se rompe por la caché. Queda pendiente el mapeo a `UsageDetails.InputTokenCount` por OllamaSharp, que no corrí.
2. **R-C06/MI-15 está bien sostenido.** O4 reprodujo X1 [A] en los dos modos de validación: con nombres distintos, 0 spans; con nombres iguales, 1. Está bien explicada la presencia del medidor por defecto en la segunda línea.
3. **La base de P-13 y de la tensión 8 está vigente.** Las 24 versiones de X0 no cambiaron entre las 08:56 y las 09:57 (O1). `Microsoft.Extensions.AI.Ollama` figura deprecado en el registro con alternativa `OllamaSharp`, como afirma N5 (O2). La cadencia de MAF (7 estables en 62 días, cada 7–11 días) respalda la advertencia «una estable por semana» como aproximación.

## 4. Posición sobre los MI de mi mandato

| MI | Posición | Fundamento |
|---|---|---|
| MI-03 | **otra** | Va por la mesa, no por escalada (§6). Se aprueba un Ollama en estación 2 **sólo** para P-03 (juez) y P-07 (≥ 7B) si la mesa los mantiene. La concurrencia y el contexto grande se miden en estación 1 dentro del turno: O3c entra en menos de 1 min y P-08 en unos 3 min. Entran como «medido en estación 1», con la regla de diseño como propiedad del patrón. Lo que mida estación 2 se rotula «medido en estación 2». Si estación 2 es CPU-only, es una segunda estación de la misma clase y tampoco funda propiedades del patrón |
| MI-12 | **propuesta** | GA por defecto: las versiones están vigentes a las 09:57 (O1) y no hay deprecaciones en el camino GA (O2). Condición: la compuerta re-consulta nuget.org el día de la publicación (CAT-OP-06), porque MAF cambia cada 7–11 días |
| MI-15 | **propuesta** | Un nombre propio como constante única para `sourceName`, `AddSource` y `AddMeter`. Con nombres distintos se pierden todos los spans (X1, O4), y el nombre por defecto lleva «Experimental» en la cadena, lo que acopla la configuración del SDK a un detalle de la biblioteca |
| MI-18 | **propuesta** | Viable (§3.1). Precisión que pido para la redacción: «largo esperado» necesita una definición operativa. Las razones caracteres/token de este mismo banco varían de 3,07 (X3) a unos 4,8 (O3b), así que la guía no debe dar una constante de caracteres por token como patrón. El límite «contexto/2 + 2» se rotula «medido en Ollama 0.40.11». La validez de esa ley se la dejo al rol formal |
| MI-23 | **otra** | Dentro de D-06, no como ADR aparte, pero con contenido obligatorio: la regla, la diferencia entre Development y Production (O4 + E4) y la prueba de cableado con `ValidateScopes=false` (CAT-OP-04) |
| MI-24 | **propuesta** (sobre la parte «sincrónico o en segundo plano») | Hay que investigarla y queda resuelta en CAT-OP-01: sincrónico con streaming y cancelación en la demo, segundo plano de aplicación en CTX-PROD, y la vía del proveedor descartada con E4. Sobre el umbral de la métrica de C2, que es la otra mitad del MI, **me abstengo**: es de AH-02 y del rol formal |

Sobre M5, M8, M9 y M10 (votados dentro de MI-11, que no es mío): M8 se sostiene (X1, O4). M9 y M10 se sostienen como intención, pero necesitan la reformulación de CAT-OP-03 y CAT-OP-01. M5 necesita un valor explícito chico, elegido y rotulado «no medido». Con el valor por defecto de 40 iteraciones y las paredes de estación 1, el peor caso de una sola petición son decenas de minutos.

## 5. Qué entra en el turno de 45 minutos

Estimaciones derivadas de paredes medidas en estación 1, con banco exclusivo. Son de planificación: **no van a la guía**.

| Pendiente | Costo unitario medido | Estimación | Decisión |
|---|---|---|---|
| P-05 recuperación de `*Policy` (recall@k, MRR) | Embedding en caliente 0,12–0,13 s (§R.3) | < 2 min | **Turno estación 1** |
| P-08 truncado con el 4b | `prompt_eval` 13–22 tok/s sobre 2050 tokens truncados | unos 2–3 min por corrida | **Turno estación 1** |
| P-11 `tool_choice` por `/v1` | 5–35 s por llamada (§R.4) | < 5 min | **Turno estación 1** |
| Cola con `NUM_PARALLEL=1` (parte de MI-03) | O3c | < 1 min, ya medido | **Hecho** (O3c); no se reconfigura el contenedor en este ciclo |
| P-06 conjunto de oro de C4 con los dos adaptadores | 26–72 s por pregunta con contexto fijo (O5) | 10 preguntas × 2: unos 10–25 min | **Un turno estación 1** |
| P-01 D1, D2, D3 y D6 ×10 por .NET | X2: 688 s / 30 llamadas; .NET hace 2 o más llamadas por operación | unos 30–60 min | **Dos turnos estación 1** (dos pedidos por turno) |
| P-02 suite `ConModelo/` con N mayor | 5–92 s por operación (R.4, E-B1) | según N | Turno estación 1 con N ≤ 10 por caso; si no, por partes |
| P-03 juez calibrado | 70–112 s por llamada sin caché (O3b, O5) | 2–5,5 h | **No entra.** [host-ia] (MI-03) o versión reducida en estación 1 (un evaluador, N = 1, unos 20–40 min) rotulada como tal |
| P-07 comparativo con ≥ 7B | No medido; el contenedor tiene 5 GB (X4) | — | **Otra estación** (estación 2) o queda «no medido» |

## 6. MI-03: mesa o escalada

**Va por la mesa.** El ejemplo de REED-16 §12 fila 4 y el ítem de `fuera_de_alcance` se refieren al **servidor Ollama de la LAN del laboratorio**, que era del PO y está dado de baja. Un contenedor propio en estación 2 es infraestructura propia y reversible, y el PO dejó la decisión a la mesa por escrito: «levantar un Ollama en estación 2 (15 vCPU) y decidirlo con la mesa» (`Reanudar.md` §3). Hay precedente: `qwen3.5:4b` se bajó al contenedor de estación 1 sin escalar (Sondeo §R.0). Tampoco hay consecuencia externa (fila 5): no hay nube y los datos no salen del laboratorio.

Condiciones:

1. R-PRIV: la dirección de estación 2 nunca va a un archivo; se usa sólo por variable.
2. Contenedor bajo demanda: se apaga fuera de los turnos, porque estación 2 es el respaldo de contingencia de estación 1 (Plan-Operativo-{estación-1}, decisión del operador) y no tiene que quedar ocupado.
3. Se registran la versión, los digests y los límites del contenedor, y se corre `sondeo.py` antes de adoptarlo.
4. Lo medido allí se rotula «medido en estación 2» y no se generaliza.
5. Se borra o se declara en `deuda_declarada` al cierre.

Si la mesa no aprueba MI-03, P-03 y P-07 quedan «no medido» en la guía, con el protocolo escrito.

## 7. Solicitudes de convocatoria

- **AH-01 (seguridad)**: O4 muestra que, fuera de Development, un cliente Singleton con herramientas que leen `SessionContext` comparte la instancia raíz entre sesiones sin que nada falle. Pido que juzgue el riesgo de que datos o autorización crucen entre sesiones y si M6 alcanza como control.
- **Experto en IA (N3b, CAG)**: con `qwen3.5:4b` en 0.40.11 el reuso de prefijo fue parcial (O5: de 71,7 s a 26,0 s cambiando sólo la pregunta) y pleno sólo con un prompt idéntico (O3b). Pido que revise si la caracterización del escalón 1 («prefijo estable cacheado») se sostiene con el modelo propuesto, y su causa. Yo sólo juzgo la cifra.
- **Formal / matemático**: hay que definir operativamente el «largo esperado» de MI-18 (razones de 3,07 a unos 4,8 caracteres/token en este banco) y decidir si la ley «límite = contexto/2 + 2», sacada de dos puntos de una sola versión, se puede enunciar.
