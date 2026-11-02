---
doc_id: BIT-16-MESA-C3-02-ARQ
doc_type: informe-de-especialista
title: Ciclo 3 · Informe de Arquitectura de software (pedido del PO)
version: v1
status: entregado
origin: agent (especialista; a ciegas respecto de los demás informes del ciclo 3)
last_review: 2026-10-26
traces: [BIT-16-04 v2, BIT-16-03, BIT-16-MESA-C2-06, BIT-16-MESA-C2-08, BIT-16-MESA-C2-09, M§4, M§5]
---

# Ciclo 3 · Arquitectura de software

**Objeto**: `04-Plan-De-Integracion.md` (ESTRUCTURA APROBADA v2). **Mandato**: recorte de la demo (H2-054, H2-056) sin perder la ilustración de capas; par CTX-NUEVA / CTX-EXISTENTE; DEP-12 huérfana y ADR-13. Las líneas citadas son del plan v2 salvo que se diga otra cosa.

## 0. Un dato que cambia el tablero: DEP-14 está resuelta (E1)

`<gestor-de-turnos> estado` (2026-10-26) lista `[[recurso-modelo-propio]] cupo 1`, y `<gestor-de-turnos> salud [recurso-modelo-propio]` devuelve `{"version":"0.40.11"}` con `qwen2.5:0.5b` y `qwen3-embedding:0.6b`, este último `con_capacidad_embedding=True`. `PROTOCOLO.md` l. 10 lo da de alta con ttl 60 y l. 34 dice que corre **en otra máquina** que la de `build` («Son máquinas distintas»). Consecuencias: rige **EMB-B**, no EMB-C; la lista «no ejecutado» de TURNO-3 deja de aplicarse por esa causa; y la mitigación de R-02 (l. 962: «no mitiga CPU…») queda vieja. La presidencia lo registra en el cierre (09-Respuestas §3). Las direcciones no se escriben: el plan usa `<gestor-de-turnos> url [recurso-modelo-propio]` y la variable de entorno.

## 1. Posiciones sobre la agenda de mi mandato

### 1.1 Recorte de la demo (H2-054, habilitado por la respuesta 1 de la presidencia)

**Opción: RC-1, «un humo con modelo por cruce de capas»; PD-7 sale (ESC-05 por 13).**

Fundamento. La ilustración de capas no vive en las corridas con modelo: vive en el código, en el diagrama de §F.3 y en `Cableado/`, que ya tiene «cliente guionado para PD-1…PD-7» (§F.8, l. 914). La corrida de humo con modelo prueba otra cosa: que **un camino entre capas** funciona con un modelo real. El diagrama de §F.3 (l. 828–864) tiene cuatro caminos distintos, no siete:

| Cruce (§F.3) | Pasos que lo recorren | Humo con modelo propuesto |
|---|---|---|
| (a) controller → caso de uso → puerto de IA → adaptador → modelo (`UC -->|extracción| PT`) | PD-3, PD-4 | **PD-3** |
| (b) controller → puerto directo, excepción de lectura (`EP -->|ayuda| PT`) + RAG | PD-2 | **PD-2** (K, 80 s) |
| (c) página Blazor → `IChatClient` → herramientas = casos de uso, con estado del circuito (`BZ --> CH --> UC`) | PD-1, PD-5, PD-6 | **PD-6** (cubre herramientas por circuito, aprobación, estado entre dos peticiones y resolución del id en la sesión: ADR-12) |
| (d) MCP → caso de uso (`MCPS --> UC`) | PD-7 | ninguno (sin modelo); sale de la demo, lo muestra 13 |

PD-1, PD-4 y PD-5 **siguen en la demo** como código y con su prueba de cableado guionada; lo que pierden es la corrida de humo contra `<recurso-compartido>`. Costo medido con las cifras del plan (§E.5, TURNO-1): los seis humos suman 950 + 80 + 80 + 80 + 950 + 1.425 = **3.565 s, el 28,7 % de TURNO-1** (12.400 s). RC-1 ahorra PD-1 + PD-4 + PD-5 = **1.980 s**: TURNO-1 baja a 10.420 s (2,89 h) y, con el tope vigente de 4 h, TURNO-2 entra hasta «04, extensión» (13 + 17 + 12 + 03 ext. + 04 ext. = 2.640 s ≤ 3.980 s). Cifras E3 (derivadas de los pesimistas del plan), sujetas a DEP-13.

Por qué PD-7 sale: 13 ya monta `MapMcp` sobre `LocalidadService` de `_Comun` (§E.1: Persistencia «la usan 08, 09, 11, 12, 13 y 16»), así que el renglón «Third-Party Integrations → adaptador de entrada, igual que un controller» de §B.1 queda ilustrado por 13 sobre los mismos casos de uso. Lo que PD-7 agrega es la tercera entrada en el mismo host, que es justo la fuente de los diez hallazgos de H2-055 (Ciclo-2/03-Consolidacion l. 185). Sacarla elimina la sesión fija `demo-mcp`, su middleware, el filtro de Host y `Origin` en la demo, las pruebas (3) de §F.5 y la verificación con `curl` de H-04 (abajo). La validación de `Origin` (MUST de MCP 2025-06-18) **pasa a 13**, que hoy sólo declara `AllowedHosts` (fila 13 de §E.2). §14.6 dice qué haría falta para exponer `/mcp` en la demo.

Alternativas: RC-2, sólo PD-7 fuera (ahorra complejidad, 0 s); RC-3, mantener y declarar el costo. Las dos dejan los 3.565 s.

Parches derivados: §F.1 (tabla y «Recorre los cinco escenarios con siete pasos» → «recorre los cruces de capas; la cobertura de ESC-01…05 se comprueba sobre guía + ejemplos + demo»), §E.5 TURNO-1, AC-3b («PD-1…PD-6» → «PD-2, PD-3, PD-6; PD-1, PD-4 y PD-5 cierran con cableado y el registro del ejemplo hermano»), §C §3.5 y §14.3, la fila «Escenarios» de §14 y P-03. El contenido escrito para el ejemplo que usan PD-1 y PD-4 sigue en el repo: **DEP-15 no se libera** por el recorte, sólo deja de bloquear corridas con modelo.

### 1.2 Fusiones de H2-056

- **F1 (01 + 02): no.** 01 corre en TURNO-1 contra `<recurso-compartido>`; 02, en TURNO-3 contra el Ollama propio, porque por `/v1` no llega `num_ctx` (fila 02 de §E.2). Un ejemplo fusionado tendría dos regímenes de cierre en AC-3b y dos turnos en un mismo proyecto. Además separa dos lecciones de capa distintas: el cliente (01) y la raíz de composición (02, ADR-02).
- **F2 (06 + 07): no.** §B.1 separa «RAG Pipeline; Retrieval · Embeddings · Vector DB» de «LLM / Generative Models»: 06 mide la recuperación sola (hit rate, MRR, líneas base) y 07 la generación con cita. Fusionarlas borra en el código la frontera que la tabla de capas dibuja, y 06 deja de ser la única pieza de ESC-02 (ver H-03).
- **F3 (14 opcional): sí.** 0 llamadas, ya es «ruta fuera de la secuencia principal» (X-001); no cruza ninguna capa de la solución.

### 1.3 Par CTX-NUEVA / CTX-EXISTENTE (respuesta 2 de la presidencia)

**Opción: APLICAR como parche, con tres enmiendas.**

Fundamento (E2). La definición de BIT-16-03 §2 exige que el par «cambie la respuesta correcta dentro de un mismo escenario». El plan ya muestra cinco respuestas que cambian, y conviene que el parche las nombre, porque sin ellas el par es un rótulo: (1) ADR-11 elige carpetas «fiel al caso base»; en una app nueva, proyectos separados son una respuesta igual de válida; (2) T2: en CTX-EXISTENTE las reglas del caso base tienen huecos (H1–H5) y se **endurecen** (§F.2, fila `Domain/`); en CTX-NUEVA se diseñan con el catálogo; (3) `EncuestaService.RegistrarAsync` **no se expone** porque no valida (§F.4); (4) ADR-13 nace de la estructura de dos hosts heredada; (5) la tabla de delta (§F.2) sólo existe en CTX-EXISTENTE.

Enmiendas: (a) **un solo nombre**: P-05 (l. 998) dice «CTX-EXIST/CTX-NUEVA» y la presidencia «CTX-EXISTENTE»; queda CTX-EXISTENTE y P-05 se cierra. (b) **El polo CTX-NUEVA no tiene artefacto**: todos los ejemplos usan `_Comun`, copiado de `8fb4c3a`, así que también son CTX-EXISTENTE. Se trata como CTX-NUBE: «qué cambiaría», sin ejecución, declarado. (c) Lugares que el parche toca: BIT-16-03 §2 (tabla y el párrafo final «CTX-LOCAL × CTX-PROTO es la de esta guía y su demo» → «× CTX-EXISTENTE») y §4.2 (una columna nueva; celda N6 = CTX-EXISTENTE); en el plan, §F.1 («Corre en CTX-LOCAL × CTX-PROTO»), la ficha §14 (Propósito), la ficha §2 y §3.3 de §C, y el campo «deja de valer» de ADR-11 y ADR-13.

### 1.4 DEP-12 huérfana y ADR-13

**Opción: partir DEP-12 y darle a ADR-13 su propio criterio (ver H-01).** DEP-12 queda como «`dotnet list package --include-transitive` con el pinning de transitivos activo (cierra X-005)», bloquea **sólo AC-6**; la mitad SSE sale (no hay ruta de chat por la API: §F.1, l. 792) y PD-1 deja de figurar. ADR-13 pasa de «Confianza media hasta la primera compilación (DEP-12)» a «hasta AC-11» (nuevo).

### 1.5 §B.4, «Agente por código» en el escalón 3 (objeción de la verificación de PAR2-16)

**Opción: cambiar la celda a «1–3: el artefacto no define el escalón (§B.3)».** El plan se contradice: §B.3 (l. 282) dice que «11 usa un `AIAgent` y sigue en el 1 con estado: el artefacto no define el escalón», y la tabla de §B.4 pone `AsAIAgent` en el 3 y da el estado como motivo («Conviene si hace falta estado de conversación»), cuando §B.3 (c) dice que el estado no sube el escalón. Es la misma forma que ya usa la fila «Agente declarativo» («2–3»).

## 2. Hallazgos nuevos

### H-01 · ADR-13 ancla su confianza en una dependencia que no verifica nada de lo suyo, y su único fallo silencioso no tiene criterio de aceptación (S2)

**Ubicación**: §C §13.14 (ADR-13, l. 508); §G.3 DEP-12 (l. 985); §F.8; §F.10.
**Afirmación**: ADR-13 dice «Confianza media hasta la primera compilación (DEP-12)», pero DEP-12 verifica el pinning de transitivos y un `TypedResults.ServerSentEvents` en un controller, y ninguna de las dos cosas toca los riesgos de ADR-13. Los riesgos que el propio ADR nombra (la hoja `@Assets[…styles.css]` con el ensamblado nuevo, que «si queda mal falla en silencio»; `UseStatusCodePages` acotado a `/api`; `SessionMiddleware` sólo en documentos) se derivan a «la prueba de humo de la página», que **no figura** en la lista de `Cableado/` de §F.8 ni en AC-1…AC-10. La verificación de PAR2-12 la deja «diferida a la construcción» (Ciclo-2/07 l. 56) sin criterio.
**Evidencia**: E1 sobre el texto (`grep -c ServerSentEvents` = 1, sólo en DEP-12; «prueba de humo de la página» aparece sólo dentro de ADR-13).
**Propuesta**: AC-11 «humo del host» en `Cableado/` (WebApplicationFactory): (1) `GET /` → 200 y el HTML enlaza `MovilidadUrbana.Asistente.styles.css`, que responde 200; (2) `GET /api/v1/inexistente` → página de estado de `/api`, y `GET /inexistente` → la página de no encontrado de Blazor, no la de estado; (3) la cookie `sesion-movilidad` sólo en documentos. DEP-12 sin la mitad SSE y sin PD-1. Pregunta para la construcción: si el layout mínimo no tiene ningún `.razor.css`, ¿se genera el paquete `{ensamblado}.styles.css`? Si no se genera, el enlace se quita en lugar de verificarse.

### H-02 · El plan afirma que la demo recorre los cinco escenarios y exige un humo con modelo por paso, cuando la composición se prueba por cruce de capas (S2)

**Ubicación**: §F.1 (l. 790, 792); §E.5 TURNO-1; AC-3b; ficha §14 («Escenarios: ESC-01…ESC-05»); §C §3.5.
**Afirmación**: después de la respuesta 1 de la presidencia, el texto conserva «Recorre los cinco escenarios con siete pasos» y la pregunta ya respondida. AC-3b cierra PD-1…PD-6 cada uno con su humo, aunque tres pasos repiten un cruce de capas que otro paso ya prueba con modelo y que `Cableado/` prueba con guion. Esos humos repetidos cuestan 1.980 s de TURNO-1 (E3, con los pesimistas de §E.5).
**Evidencia**: E2 (09-Respuestas §1; §F.3, cuatro caminos en el diagrama; §F.8, cliente guionado para PD-1…PD-7).
**Propuesta**: RC-1 (§1.1): humo con modelo en PD-2, PD-3 y PD-6; PD-1, PD-4 y PD-5 en cableado; PD-7 fuera y ESC-05 por 13; una tabla de cobertura ESC × {guía, ejemplo, demo} en §C §3.3 reemplaza la afirmación de «los cinco escenarios».

### H-03 · PD-2 se rotula ESC-02, pero ESC-02 se define sin generación (S3)

**Ubicación**: §F.1, fila PD-2 («ESC-01 / ESC-02»).
**Afirmación**: BIT-16-03 §1 define ESC-02 como «Nada: sólo se usan embeddings; no hay generación». PD-2 genera una respuesta con cita (C4, ejemplo hermano 07). La demo no tiene ninguna pieza de ESC-02; la única es 06.
**Evidencia**: E2 (BIT-16-03 §1, fila ESC-02; §E.2, fila 06).
**Propuesta**: PD-2 = ESC-01; ESC-02 cubierto por 06 en la tabla de cobertura de H-02. Refuerza el «no» a F2: si 06 se fusiona con 07, ESC-02 se queda sin pieza.

### H-04 · La topología de EMB-B del plan no es la que quedó montada, y la verificación de la frontera de `/mcp` depende de un contenedor que no va a existir (S3)

**Ubicación**: §F.5 (`curl` desde `ollama-embed` a `http://demo:8080/mcp`); §F.9 (`OLLAMA_EMBED_ENDPOINT=http://ollama-embed:11434`); §F.3 (nodo `OE`); R-02.
**Afirmación**: el plan supone el Ollama de embeddings como servicio `ollama-embed` del compose de la demo, en su misma red `bridge`. El recurso que montó el gestor corre en otra máquina y se alcanza por `<gestor-de-turnos> url [recurso-modelo-propio]` (PROTOCOLO l. 10, l. 34). En la corrida del laboratorio no hay contenedor `ollama-embed` en la red de la demo, así que la verificación «`curl` desde `ollama-embed` es rechazado» no tiene desde dónde correr. El default de §F.9 también queda desalineado.
**Evidencia**: E1 (`<gestor-de-turnos> estado` y `salud [recurso-modelo-propio]`, 2026-10-26; PROTOCOLO.md).
**Propuesta**: si PD-7 sale (RC-1), la verificación desaparece de la demo y la de Host y `Origin` va a 13 como prueba en proceso. Si PD-7 queda, se usa un contenedor efímero de imagen fijada en la misma red. En los dos casos, §F.9 deja `OLLAMA_EMBED_ENDPOINT` sin valor en el archivo, como `OLLAMA_ENDPOINT`, y el servicio `ollama-embed` del compose pasa a ser el camino del lector (quien no tiene el recurso del gestor). R-02 se reescribe según PROTOCOLO l. 34–38.

### H-05 · ADR-11 reemplaza al compilador por una prueba que sólo mira Domain (S3)

**Ubicación**: ADR-11 (l. 508); §F.3, «Reglas que la demo cumple y prueba» (l. 866); AC-5.
**Afirmación**: ADR-11 (a) acepta que «el compilador no impide la violación y la prueba lo reemplaza». Pero la prueba de AC-5 sólo verifica `…Domain`. Las otras dos reglas de capa que la demo declara quedan sin prueba ejecutable: «el SDK del proveedor sólo en `Infrastructure/AI/` y `Program.cs`», y que Application (los puertos y los servicios nuevos `AltaDesdeTextoService` y `EncuestaDesdeTextoService`) no referencie tipos de `…Infrastructure`. «Herramientas sin `I*Repository`» queda en un `grep`. Con carpetas en un solo ensamblado, una referencia de Application a un adaptador compila sin aviso, y es justo la inversión que §F.3 dibuja (`AI -. implementa .-> PT`).
**Evidencia**: E2 (texto de ADR-11, §F.3 y AC-5).
**Propuesta**: ampliar la prueba de reflexión de AC-5 con tres reglas: ningún tipo de `…Application` referencia `…Infrastructure*`, `OllamaSharp` ni `OpenAI`; ningún tipo fuera de `…Infrastructure.AI` y `Program` referencia `OllamaSharp` ni `OpenAI`; ninguna clase de herramienta (`Infrastructure.AI` y `Mcp`) recibe un `I*Repository`. Cada regla con «al menos un tipo encontrado», como H2-008.

### H-06 · El par CTX-NUEVA / CTX-EXISTENTE llega a votación sin la respuesta que cambia ni el polo que se ejerce (S3)

**Ubicación**: 09-Respuestas §2; §G.4 P-05; BIT-16-03 §2 y §4.2.
**Afirmación**: la propuesta define el par por su nombre, pero no dice qué respuesta cambia, que es lo que BIT-16-03 §2 exige para que algo sea un contexto. Tampoco dice que ningún artefacto de la guía está en CTX-NUEVA. Además, P-05 usa otro identificador (CTX-EXIST).
**Evidencia**: E2 (definición de contexto en BIT-16-03 §2; §E.1 `_Comun` con procedencia `8fb4c3a`; l. 998).
**Propuesta**: las enmiendas (a)–(c) de §1.3: cinco respuestas que cambian, con su lugar en el plan; CTX-NUEVA declarado sin ejecución, como CTX-NUBE; un solo nombre; la lista de lugares que toca.

## 3. Revisado y bien

- §F.2, tabla de delta en tres columnas, con criterio E1 de procedencia y AC-10 que la contrasta con `diff -r`: es la forma correcta de enseñar CTX-EXISTENTE.
- §F.4 y ADR-12: el pedido de aprobación se arma en el servidor desde el pedido guardado, y las herramientas se arman por circuito sobre un `IChatClient` base singleton. El cruce (c) queda bien delimitado.
- §B.1 separa Vector DB como uso (Infrastructure/AI) y como almacenamiento (Persistence). Con eso F2 se puede decidir sin ambigüedad.
