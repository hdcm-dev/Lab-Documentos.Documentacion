# 09 · Capa de IA en .NET y diseño conversacional

> **Propósito**: inventario y destilado de la familia `Guides/IA/Dot-Net-Integration-AI-Layer-Guide/`:
> dos libros (integración de una capa de IA en .NET y diseño conversacional), el puntero a los ocho
> Conocimientos para agentes (K1–K8, mudados el 2026-11-19 a la base de conocimientos, privado), una lámina de arquitectura,
> el arnés de verificación (`tools/`, `Compuertas/`), diecisiete ejemplos compilables y una demo. 479 archivos
> versionados (`git ls-files` en la base del índice, descontados los ocho Conocimientos mudados).
> **Fuente primaria**: frontmatter YAML de los dos libros, cabeceras en negrita de los Conocimientos
> (en `8791fb1`; hoy en la base de conocimientos), `Conocimientos/README.md` (hoy, puntero de la mudanza), `Examples/README.md`, `Demos/MovilidadUrbana.Asistente/README.md`,
> `Laminas/LEEME.md` y `Compuertas/README.md`.
> **Base**: `Lab-Documentos` en `origin/main` 34929f2. Todas las rutas son relativas a
> `Lab-Documentos/`; dentro de las tablas, `<G>/` abrevia `Guides/IA/Dot-Net-Integration-AI-Layer-Guide/`.
> **Novedad frente a la ia-db v1.x (2026-10-29)**: esta familia no tenía índice propio; entró con
> acfb9bd (2026-11-02, «Guía 16: AI Layer en .NET (0.12.0, en revisión)») y suma 31 commits hasta la base.

## Advertencias de lectura

- **Los Conocimientos K1–K8 se mudaron** el 2026-11-19 a la base de conocimientos (privado), carpeta `Knowledges/`, archivos
  `Knowledge-AI-Layer-*.md`, en versión 2.0 y con las secciones renumeradas a la forma de la base. En
  `<G>/Conocimientos/` queda sólo el `README.md` puntero, con la correspondencia de secciones. Hoy se citan por alias
  y sección (`` `<Alias>` §N ``); una cita `K<n> §x`, `K<n> Rx.y` o por alias y versión 1.x se lee contra
  `Lab-Documentos` `8791fb1`. Los identificadores de regla (`R2.6b`, `CD-8`, `K5-AP-8`, `E1`…`E9`) no cambiaron.
- **Dos aparatos de metadatos conviven**: los libros llevan frontmatter YAML con `doc_id`
  (`GUIA-NET-IA`, `GUIA-DISENO-CONVERSACIONAL`); los Conocimientos (hoy en la base) **no** tienen `doc_id` ni
  YAML: usan cabecera en negrita (`**Alias:**`, `**Versión:**`, `**Estado:**`, `**Fecha:**`…) y se citan por
  alias; el Id K1–K8 queda como nombre histórico.
- **Los Id se repiten entre libros con distinto significado**: `P-1…P-10` del libro .NET (principios
  de arquitectura) ≠ `P-1…P-9` del libro conversacional (principios de proceso). Citar siempre con el
  libro: «Guía .NET P-6» frente a «Diseño conversacional P-3».
- Los encabezados de nivel 1 dividen Partes **a propósito**; por eso la carpeta trae su propio
  `.markdownlint.jsonc` que desactiva MD025 respecto de `scripts/docs-guard.markdownlint-cli2.jsonc`.
- Anclas estables: `cN`/`cN-k` (capítulo/sección) y, en el libro .NET, también `sM`/`sM-k` con
  M = N − 1 por compatibilidad (`<G>/Dot-Net-Integration-AI-Layer-Guide.md` §0.7). Los Conocimientos usaban
  `kN-…` hasta `8791fb1`; en la base no llevan anclas propias.
- Rótulos de evidencia obligatorios en ambos libros: `[REF-nn]`, «criterio de la guía»,
  «experiencia propia medida» (sólo el conversacional), **NO VERIFICADO**, **NO EJECUTADO**.

## Inventario de piezas

| Pieza | Ruta | Líneas | Versión · estado · fecha | Propósito |
|---|---|---|---|---|
| Libro .NET | `<G>/Dot-Net-Integration-AI-Layer-Guide.md` | 4 909 | 1.2.0 · vigente · 2026-11-11 | Sumar una capa de IA a una app .NET existente (Movilidad Urbana) |
| Referencias (sidecar) | `<G>/Dot-Net-Integration-AI-Layer-Guide.md.refs` | 187 | — | Lista corta `[REF-nn] Autor` (ver hallazgos) |
| Libro conversacional | `<G>/Conversational-Design-Framework-Guide.md` | 4 249 | 1.6.0 · vigente · 2026-11-15 | Diseñar la conversación de un asistente de producto por anillos de competencia |
| Puntero de Conocimientos | `<G>/Conocimientos/README.md` | — | — | Aviso de la mudanza: alias de K1–K8 en la base, cómo leer las citas anteriores (contra `8791fb1`) y correspondencia de secciones |
| K1–K8 | Base de conocimientos (privado), `Knowledges/Knowledge-AI-Layer-*.md` | — | 2.0 · Vigente · 2026-11-19 (ver tabla K) | Destilado imperativo de los libros para agentes |
| Lámina LD-01 | `<G>/Laminas/LD-01-arquitectura-conversacional.{def.json,svg,jpg}` + `LEEME.md` | 54 (LEEME) | — | Arquitectura de referencia de una app conversacional en A3 |
| Generadores | `<G>/Laminas/Generadores/ld01.py`, `verificar_ld01.py` | — | — | Componen el SVG desde el `.def.json` y lo verifican |
| Compuertas | `<G>/Compuertas/README.md`, `ac6.excepciones` | 28 | — | Formato de las listas privadas de AC-7/AC-8/R-PRIV (viven fuera del repo) |
| Arnés | `<G>/tools/` (15 scripts + `oraculos/` con 24 `.jq`) | — | — | Build, corridas con/sin modelo, compuertas, oráculos, conteo de palabras |
| Ejemplos | `<G>/Examples/` (17 carpetas + `_Comun/`) | 151 (README) | — | Consolas `net10.0` compilables por carpeta |
| Demo | `<G>/Demos/MovilidadUrbana.Asistente/` | — | — | App existente + capa de IA, recorrido PD-1…PD-6 |
| Lint local | `<G>/.markdownlint.jsonc` | — | — | Excepción MD025 |

## Orden de lectura

```text
Para personas                                 Para agentes (base: K4 §0, «Orden de carga»)
──────────────                                 ──────────────────────────────────────
Libro .NET cap. 0 (rutas por actor §0.2)       K4 §0 y §3.1.1 → K1 → K5 → K2 → K8 → K6 → K3 → K7
  └─ tronco común caps. 0–4, §5.2–5.3 …        K4 gobierna; K5 §2.1 es la norma del turno
Libro conversacional cap. 0 → Base B → …       K6 detalla K2 · K7 detalla K3 · K8 dibuja K2+K5
  └─ cap. 17 lo ata al libro .NET              si hijo y padre chocan, rige el padre
Lámina LD-01 como panorama de una hoja         el libro es fuente del K (§8 y §9 de cada K)
```

Las secciones de la columna de agentes son las de la versión 2.0 en la base; el alias de cada Id está en la tabla
de Conocimientos.

## Libro .NET — `GUIA-NET-IA`

Frontmatter (`<G>/Dot-Net-Integration-AI-Layer-Guide.md`): `doc_type: guia-de-estudio`,
`origin: ia-assisted`, `confidence: media`, `tope_palabras: 60000`,
`audience: [desarrollo, analista, devops, qa]`, `sdk_validado: .NET SDK 10.0.403` en
`mcr.microsoft.com/dotnet/sdk:10.0`, `related` → `Guides/Dot-NET-Arquitectura-Guide/Dot-NET-Arquitectura-Guide.md`
y K1. Caso conductor: **Movilidad Urbana** (ABM de `Localidad` + encuesta `RespuestaDeEncuesta`).

### Estructura

| Parte | Capítulos | Tema |
|---|---|---|
| Prólogo | 0 | Cómo usar el libro: OA, rutas por actor, evidencia, mapa de ejemplos (§0.5 → Anexo E.1), Conocimiento de especificación (§0.6), anclas (§0.7) |
| I · Fundamentos | 1 | Diez principios P-1…P-10 |
| II · Marco | 2–4 | Tesis «IA ya es parte del stack», escenarios/contextos/actores (§3.7 frontera de lo preguntable), mapa conceptual: capas, dos escaleras, tablas de entrada |
| III · Arquitectura y SDK | 5–6 | La capa en la arquitectura (puerto propio vs `IChatClient`, §5.4); hablar con un modelo desde .NET |
| IV · Conocimiento | 7–8 | Escalera de conocimiento (contexto fijo → contexto completo con prefijo → RAG → RAG agéntico); RAG en .NET |
| V · Agencia | 9–10 | Herramientas, agentes, orquestación, MCP (§9.9); marcos comparados (M.E.AI, MAF, SK como migración §10.7) |
| VI · Producción | 11–13 | Probar y evaluar (k de M, Clopper-Pearson, LLM juez); asegurar (OWASP LLM); operar y desplegar (OpenTelemetry, local/compartido/nube) |
| VII · Integración | 14–16 | 13 ADR; la demo; caso aplicado Geometría (§16.8 Docs as Code) |
| Cierre | 17 | Autoevaluación |
| Anexos | A–H | Plantillas, listas por actor, glosario, referencias, laboratorio, versiones, lecturas, procedencia |

Patrón de cada capítulo temático (5–9, 11–13, 16; §0.4): Definición `cN-k` → Aplicación por escenario
`cN-escenarios` → Ejemplo `cN-ejemplos` → Decisión `cN-decision` → Preguntas guía `cN-preguntas` →
Criterios de calidad `cN-calidad`. «Estás en» ubica la sección en escaleras y capas.

### Principios P-1…P-10 (§1.2, ancla `p-n`)

| Id | Regla (destilada) | Capítulo |
|---|---|---|
| P-1 | Contrato antes que modelo: el núcleo define sus interfaces; el modelo detrás de un adaptador | 5, 14 |
| P-2 | Proveedor reemplazable, elegido sólo en la raíz de composición | 6 |
| P-3 | Dónde corre el modelo lo deciden los datos, la concurrencia y el costo | 13 |
| P-4 | El dato exacto se consulta por caso de uso, nunca por parecido | 7 |
| P-5 | Usar (capa de IA) no es almacenar (capa de datos); cambiar embeddings obliga a reindexar | 8 |
| P-6 | Actuar sólo por casos de uso, con mínimo privilegio; toda escritura pide aprobación con argumentos armados por el código | 9, 12 |
| P-7 | Mínima agencia: función → llamada → con herramientas → workflow → agente, subiendo sólo si no alcanza | 9, 10 |
| P-8 | La salida del modelo es una propuesta; las reglas viven en el código | 6 |
| P-9 | Una sola cadena transversal de opciones y telemetría, en orden declarado | 6, 13 |
| P-10 | Evidencia del tipo correcto: garantía de código en cada build; conducta del modelo como k de M con rótulo | 11 |

### Objetivos de aprendizaje y actores (§0.1–§0.2)

- Prefijos de OA: `OA-0.x` (comunes), `OA-D` (ACT-DEV, D1–D9), `OA-A` (ACT-ARQ, A1–A7), `OA-O`
  (ACT-OPS, O1–O4), `OA-S` (ACT-SEC, S1–S4), `OA-SK1` (quien viene de Semantic Kernel). La tabla de
  §0.1 es «la única fuente de los objetivos»; cada ejemplo existe por un OA.
- Contextos de uso del libro: `CTX-EXISTENTE × CTX-LOCAL × CTX-PROTO` (§3.2). Escenarios `ESC-01…`
  (los de la demo: ESC-01, ESC-03, ESC-04).

### ADR de la capa (cap. 14, §14.2–§14.14)

| ADR | Decisión | ADR | Decisión |
|---|---|---|---|
| 01 | Dónde vive la llamada al modelo | 08 | La salida del modelo es una propuesta |
| 02 | Contrato de acceso y adaptador del proveedor | 09 | Pipeline transversal |
| 03 | Local, servidor de varias apps o nube | 10 | Pruebas y evaluación |
| 04 | Herramienta, contexto fijo, contexto completo o RAG | 11 | Capas como carpetas o como proyectos |
| 05 | Almacén vectorial | 12 | Estado del pedido de aprobación y ciclo de vida del cliente |
| 06 | Herramientas sobre casos de uso y aprobación | 13 | Un host para la demo |
| 07 | Escalón de agencia | — | §14.15: decisiones que el registro no toma |

El caso Geometría (cap. 16) lleva su propio registro `ADR-IA-01…06` mapeado a estas ADR
(p. ej. ADR-IA-06 «V2 es un borrador que el docente firma» → ADR-07/ADR-08).

### Evidencia y medición (§0.4, §11, Anexos E, F, H)

- **Conducta ≠ tasa**: una salida mostrada pasó una vez; una tasa es k de M entradas distintas con
  IC95 de Clopper-Pearson; con M ≤ 12 la tasa es descriptiva (§11.4).
- **Cliente guionado / `--fake`**: muestra conducta del código, nunca del modelo; **prueba de
  cableado** (sin red) vs **prueba de humo** (una entrada contra el modelo).
- Extensión medida con `tools/contar.sh`: 59 325 palabras el 2026-11-01 (99 % del tope; Anexo E).
- Anexo H: procedencia de observaciones de la v0.11.0 (servidor retirado, `qwen2.5:0.5b`,
  `qwen3.5:4b`) que el cuerpo cita sin repetir.

## Libro de diseño conversacional — `GUIA-DISENO-CONVERSACIONAL`

Frontmatter (`<G>/Conversational-Design-Framework-Guide.md`): `version: 1.6.0`, `last_review: 2026-11-15`,
`tope_palabras: 67000`, `audience: [estudiante, docente, po, desarrollo, qa]`, `related` → el libro .NET.
Guía académica y general: aplica a cualquier sistema, existente o por desarrollar. Tres casos
ilustrativos: Movilidad Urbana, Geometría y PushDispatch (cap. 18, «diseñado desde cero»); el Anexo H
declara a los dos primeros como laboratorios públicos y al tercero como experiencia propia.

### Estructura

| Parte | Capítulos | Pregunta |
|---|---|---|
| Base · Criterio y juicio | B (ancla `cj`) | ¿Con qué criterio se decide un turno y con qué juicio se dice si el diseño es bueno? |
| I · Fundamentos | 1–2 | Qué es diseñar una conversación de producto; principios P-1…P-9 |
| II · Marco | 3–6 | Anillos de competencia; vocabulario del inexperto; destinos y enlace profundo; «el código elige, el modelo redacta» |
| III · Método por etapas | 7–14 | Flujo E0→E7: E0 compuerta de ajuste, E1 inventario, E2 mapa de anillos, E3 glosario, E4 destinos y herramientas, E5 batería, E6 maqueta y crítica |
| IV · Producción y medición | 15–16 | E7 plan de medición; mover la frontera y cuándo abandonar |
| V · Integración | 17–18 | Relación con el libro .NET; caso PushDispatch |
| Cierre | 19 | Autoevaluación |
| Anexos | A–I | Plantillas A.1–A.7, listas por rol, glosario, referencias, recorrido del novato, versiones, lecturas, procedencia, rúbrica de juicio (I) |

### Conceptos clave

| Concepto | Destilado | Fuente |
|---|---|---|
| Anillos de competencia | 1 Operar el producto (datos reales + enlace profundo) · 2 Entender el dominio (corpus con cita) · 3 Lo de al lado (derivar, lista cerrada) · Afuera (rechazo amable con ejemplos). Se asigna por lo que el usuario logra, no por el tema | §3.1, Tabla 3.1 |
| Frontera | Borde entre lo que se responde y lo que se deriva/rechaza; se mueve sólo midiendo | §3.1, §16 |
| Mapa de anillos | Contrato: cada intención de la batería en un anillo único con riesgo, rol y salida; lo que no está no se construye | §3.1, Anexo A.2 |
| Principios del turno T-1…T-8 | Responder lo preguntado; preguntar sólo lo que cambia la respuesta; el código decide lo verificable; nunca un callejón; llevar a la acción; la forma la decide el dato; honestidad sobre límites; la mejora se juzga donde la ve el usuario | Cap. B, ancla `t-n` |
| Principios de proceso P-1…P-9 | Tres familias: qué abarca (P-1, P-2, P-6), cómo responde (P-3, P-4, P-5), cómo se acepta (P-7, P-8, P-9) | §2, Tabla 2.1 |
| Aceptación | Por tasa, no por conducta (P-7), en el sitio real (P-8), midiendo sin guardar el texto (P-9) | §2 |
| Rúbrica de juicio | Criterios R1–R14 con vetos (las rondas de PushDispatch citan vetos R12 y R3) | Anexo I; `AI-Layer-Conversational-Design` §2.1.6 (en la base) |

## Conocimientos K1–K8 (mudados a la base de conocimientos)

Destilan los libros en imperativos «con su porqué y su prueba». Desde el 2026-11-19 viven en la base de conocimientos (privado),
`Knowledges/Knowledge-<Alias>.md`, en versión 2.0, con la forma de esa base (`Compatible-con:
Rule-Forma-De-Conocimiento.md 1.3`); los libros .NET 1.2.0 y conversacional 1.6.0 pasaron a «Fuentes» de su §9 y
se citan como `[Guía §x]` y `[GDC §x]`, sin enlace. Antipatrones prefijados `K2-AP-n`, `K3-AP-n`, `K5-AP-n`…`K8-AP-n`
o `E1–E9` (K4 §7 en la base; §8 en `8791fb1`). En `<G>/Conocimientos/` queda el puntero.

| Id | Alias en la base (`Knowledge-<Alias>.md`) | Ver. · estado (en `8791fb1`) | Para qué |
|---|---|---|---|
| K1 | `AI-Layer-Integration-Designing-Specification` | 2.0 Vigente (1.6 Vigente) | Decidir si hace falta IA y especificarla: anillos, ARQ-1…ARQ-6, `REQ-IA-nn` con prueba, matriz OWASP por agencia, plantilla arc42 reducida |
| K2 | `AI-Layer-Console-Assistant-Building` | 2.0 Vigente, aviso de borrador en §0 (1.7 Borrador) | Construir la consola en un panel Blazor: pipeline del turno, corpus, destinos, votos, despliegue con un modelo cargado |
| K3 | `AI-Layer-Verification-And-Acceptance` | 2.0 Vigente (1.9 Vigente) | Aceptar con evidencia: batería ×3 ≥ 90 %, crítico ≥ 8, capturas 1280/390, sitio real por rol, cifras contra SQL; plantilla MEDIDO/INFORME |
| K4 | `AI-Layer-Integration-Working-Method` | 2.0 Vigente (1.5 Vigente) | Forma de trabajo: fases K1→K2→K3 con K5 transversal, mesa con refutador, brecha sin marca, PRs por choque, antipatrones E1–E9 |
| K5 | `AI-Layer-Conversational-Design` | 2.0 Vigente (1.2 Vigente) | §2.1 (antes §M) marco normativo del turno (T-1…T-8, prueba de anillo, árbol, aclaración, rúbrica R1–R14) y formas de respuesta F1–F8 |
| K6 | `AI-Layer-Retrieval-Corpus-Functions-And-Deeplinks` | 2.0 Vigente, aviso de borrador en §0 (1.9 Borrador) | Detalle de K2 en tres partes: A corpus (frontmatter `preguntas:`/`destinos:`, recall@3), B funciones con `AIFunctionFactory` y validador de cifras, C catálogo de destinos y deeplinks |
| K7 | `AI-Layer-Testing-Strategy` | 2.0 Vigente (1.7 Vigente) | Detalle de K3: pirámide, unitarias sin modelo, bUnit, adversas, mutación, E2E Playwright, batería ×3, compuertas de CI |
| K8 | `AI-Layer-Chat-Console-Interface` | 2.0 Vigente, aviso de borrador en §0 (1.0 Borrador) | La consola como interfaz: anatomía, estados, teléfono, accesibilidad, historial, cambios sin guardar, voto, persistencia; §3.10 (antes §13) variante multi-participante (propuesta rotulada) |

Condición que traían K2, K6 y K8 para pasar de Borrador a Vigente: ser aceptados por K3/K7 aplicados sobre un
**segundo sistema**. La base no admite el estado Borrador: salen como Vigente con ese aviso en §0 y en `Tema`.
El README de `8791fb1` (hoy puntero) registraba cuatro retroalimentaciones, que siguen en el control de cambios de cada K
(2026-11-12 ×3 y 2026-11-15): banco de diálogo sobre Lab-Geometria, marco del turno, proveedores/consumo/MCP,
interfaz de la consola y rondas del juicio de PushDispatch (3/28 → 10/28 → 11/28).
Regla de repo público del README de `8791fb1`: no se nombran producto de referencia, clientes, servidores,
direcciones, usuarios, claves ni el modelo de IA.

## Lámina LD-01 (`<G>/Laminas/`)

- Una hoja A3 apaisada: «Aplicación conversacional — arquitectura de referencia». Definición en
  `LD-01-arquitectura-conversacional.def.json`: 29 partes, 8 zonas (Z1 Usuario … Z7 Proveedores de IA,
  Z8 Gobierno transversal), 36 conexiones rotuladas y tabla de preguntas.
- Regla: se corrige el `.def.json`, el SVG nunca a mano; el JPG se exporta del SVG (calidad 95) en
  contenedor efímero `python:3.12-slim` con cairosvg; verificación de numeración, referencias,
  ≤ 25 palabras por respuesta y no solapamiento (`LEEME.md`).
- Genérica: no nombra productos, proveedores ni modelos.

## Examples/ (inventario por carpeta)

Contrato común (`<G>/Examples/README.md`): carpeta `NN-Nombre/` con un único `.csproj` `net10.0`,
`README.md` (qué muestra, OA, comando, salida esperada), `ejemplo.json` (recurso, turno, fase,
entradas con SHA-256, comando) y entradas congeladas `entradas.v1.json` (cambiar una entrada crea `v2`).
Cliente siempre por `FabricaDeClientes`; argumentos `--fake`, `--verificar`, `--plazo-s`.

| Carpeta | Tema | Capítulo · OA |
|---|---|---|
| `01-Chat-Y-Streaming` | `IChatClient` y streaming | §6 · OA-D1 |
| `02-Cambio-De-Adaptador` | Cambiar de proveedor tocando sólo la composición | §6 · OA-D1 |
| `03-Salida-Estructurada` | `TryGetResult`, campos anulables, reglas antes de guardar (vía `extension`) | §6.3 · OA-D2 |
| `04-Normalizacion-Contra-Catalogo` | Normalizar contra `Catalogos` (vía `extension`) | §6.3 · OA-D2 |
| `05-Contexto-Completo-Con-Prefijo` | Contexto completo con prefijo estable (`corpus/`) | §7 · OA-D3 |
| `06-Embeddings-Y-Busqueda-Semantica` | Embeddings, hit rate@k contra `oro/` | §8 · OA-D4 |
| `07-RAG-Con-Citas` | RAG con citas validadas en código (vías `estabilidad`, `embeddings`) | §8 · OA-D4 |
| `08-Primera-Herramienta-Solo-Lectura` | Herramienta de lectura, pruebas negativas (vía `extension`) | §9.2 · OA-D5 |
| `09-Caso-De-Uso-Como-Herramienta` | Caso de uso expuesto, sesión puesta por el código | §9.3–9.5 · OA-D5, OA-S2 |
| `10-Workflow-Y-Contraejemplo` | Workflow frente a función | §9.6 · OA-D6 |
| `11-Agente-Con-Aprobacion` | Agente con aprobación armada por el código | §9.5–9.7 · OA-D6, OA-S4 |
| `12-Uno-O-Varios-Agentes` | Costo de varios agentes con métricas deterministas | §9.8 · OA-D7 |
| `13-Servidor-Y-Cliente-MCP` | MCP en loopback, validación de Host/`Origin` | §9.9, §12.5 · OA-D8 |
| `14-Anotaciones-SK-vs-MEAI` | `[KernelFunction]` → `[Description]` + `AIFunctionFactory` | §10.7 · OA-SK1 |
| `15-Pruebas-Y-Evaluacion` | Cableado vs corridas con modelo, LLM juez | §11 · OA-D9, OA-O3 |
| `16-Inyeccion-Indirecta` | Inyección indirecta y su control | §12.7 · OA-S1, OA-S2 |
| `17-Observabilidad-Y-Pipeline` | `UseOpenTelemetry`, `EnableSensitiveData` | §13.1–13.2 · OA-O1 |
| `_Comun/` (52 archivos) | `MovilidadUrbana.Dominio`, `.Persistencia` (EF Core SQLite, `SessionSeeder`), `.Asistente.Comun` (opciones, fábrica, cliente guionado, embeddings FNV-1a, registro R-LLM), `.Comun.Pruebas`, `Humo/` (plantilla) | — |
| Raíz | `Directory.Packages.props` (versiones centralizadas, sin `Version` en `.csproj`), `Directory.Build.props/.targets` (SHA-256 de paquetes en cada ensamblado), `.gitignore` | — |

Variables (todas del entorno, ninguna dirección en el repo): `OLLAMA_ENDPOINT`/`OLLAMA_MODEL`
(servidor de chat, default `qwen3.5:4b`), `OLLAMA_PROPIO_*` (segundo servidor; «el nombre es histórico»),
`OLLAMA_EMBED_*` (`qwen3-embedding:0.6b`), `OLLAMA_NUM_CTX` 8192, `EMB_PLAN` (EMB-A/B/C), `RLLM_DIR`,
`RLLM_MAQUINA` (un **rol**, nunca el nombre del equipo), `TURNO_CMD` (turnos por papel: `build`,
`modelo-propio`, `modelo-compartido`).

## Demo `Demos/MovilidadUrbana.Asistente/`

App .NET 10 que **ya existía** (API de Movilidad Urbana de Lab-E2E.WebBlazor, commit `8fb4c3a`) a la
que se suma la capa sin reescribir casos de uso (CTX-EXISTENTE). Un solo host (ADR-13): API `/api/v1`
+ página Blazor de chat; capas como carpetas (ADR-11) con prueba de arquitectura; puertos
`IExtractorDeLocalidad`, `IExtractorDeEncuesta`, `IAyuda` en `Application/`, adaptadores en
`Infrastructure/AI/`; sin `/mcp` (está en `Examples/13`).

| Paso | Escenario | Qué muestra |
|---|---|---|
| PD-1 | ESC-01 | Chat pide `contar_localidades` / `resumir_encuesta`; la cifra sale del caso de uso |
| PD-2 | ESC-01 | `POST /api/v1/ayuda`: RAG sobre 12 requisitos de `*Policy`, el código valida la cita |
| PD-3 | ESC-03 | `desde-texto`: `Habitantes` `null` → la regla lo rechaza y pide el dato |
| PD-4 | ESC-03 | Normalizador de encuesta lleva «bondi» a `colectivo`; lo ajeno al catálogo no se convierte |
| PD-5 | ESC-03/04 | El dominio rechaza el CP antes de preguntar; el pedido de aprobación muestra lo que resolvió el código |
| PD-6 | ESC-04 | `eliminar_localidad` resuelta en la sesión y aprobación armada por el código |

Estructura: `src/` (Domain, Application, Infrastructure/{Persistence,Sessions,AI}, Controllers,
Components, Concurrencia `LimitadorDelModelo`, Sessions) — 76 archivos; `tests/` (`Cableado/` sin red,
`ConModelo/` `[Category("LLM")]`) — 28; `tools/demo.sh`, `tools/diff-base.sh`; `compose.yaml`, `MovilidadUrbana.Asistente.slnx`, `README.md`, `ejemplo.json`, `entradas.v1.json` (111 archivos en total). En `Demos/` raíz: `Directory.Build.props`, `Directory.Packages.props`, `.gitignore`.

## Arnés y compuertas (`<G>/tools/`, `<G>/Compuertas/`)

| Script | Función |
|---|---|
| `verificar.sh` | Arnés: `build`, `correr`, `--con-modelo` (fases build → 3a → chat → 3b), `extension`, `estabilidad`, `embeddings`, `medidor`, `tasa k M` |
| `recalcular-oraculos.sh` + `oraculos/*.jq` (24) | Recalcula oráculos desde el registro de una corrida (p. ej. `rag-con-citas.jq`, `demo-pd6-pedido.jq`) |
| `compuerta-ac7.sh`, `compuerta-ac8.sh`, `compuerta-rpriv.sh` | Privacidad y dominio ajeno; leen listas de `COMPUERTAS_DIR` **fuera del repo**; informan `ruta:línea`, nunca el texto |
| `compuerta-cabeceras.sh`, `compuerta-intervalos.py`/`.tsv`, `compuerta-referencias.sh` (+ `.excepciones`) | Cabeceras, intervalos declarados y referencias |
| `comparar-ac9.py`, `diff-dominio.sh`, `contar.sh`, `verificar-markdown.py` (+ `.excepciones`) | Comparador, delta de dominio, conteo de palabras por parte, lint propio |

## Relaciones con otras guías

| Relación | Ruta |
|---|---|
| `related` del libro .NET (arquitectura en capas que se presupone) | `Guides/Dot-NET-Arquitectura-Guide/Dot-NET-Arquitectura-Guide.md` |
| Caso base de la demo y de `_Comun` (commit `8fb4c3a`) | Lab-E2E.WebBlazor (repo externo; sin verificar en este corpus) |
| Caso aplicado cap. 16 y banco de diálogo de K1–K7 | Lab-Geometria (repo externo, enlazado por URL pública) |
| Guía de docs-guard (esquema y lista de dominios; commit 7cb7949) | `scripts/docs-guard.markdownlint-cli2.jsonc` y afines |
| Otras guías de IA del repo (SDD, IA-Model) | ver índice de `Guides/IA/` de esta ia-db |
| Único referente externo dentro del corpus | `CHANGELOG.md` (raíz) |

## Hallazgos del corpus

| # | Hallazgo | Evidencia |
|---|---|---|
| H1 | El sidecar `.refs` está **desactualizado**: lista 187 Id y termina en `[REF-213]`, mientras el Anexo D cita `REF-214…REF-233` (Docs as Code, Copilot Studio…). Tampoco existe `REF-02` (el Anexo D declara números «estables y no correlativos», así que el salto puede ser deliberado) | `<G>/Dot-Net-Integration-AI-Layer-Guide.md.refs`; Anexo D, líneas ~4547–4572 |
| H2 | Ruta absoluta de equipo en READMEs públicos: «Desde la carpeta de la guía (`/LAB/Lab-Documentos/Lab-Documentos/Guides/IA/…`)» | `<G>/Examples/README.md` l. 22 y los README de 03, 04, 05, 07, 08, 09, 10, 11, 12, 13, 14, 15, 16 (13 de 17) |
| H3 | La lámina LD-01 declara fuentes «K1–K7» tomadas de `1403c46`; K8 (2026-11-15) no está reflejado | `<G>/Laminas/LEEME.md` |
| H4 | Fechas desfasadas: el libro .NET sigue en 1.2.0 / `last_review` 2026-11-11 mientras los K y el conversacional se revisaron el 2026-11-15; la medición de palabras es del 2026-11-01 | frontmatter; Anexo E (l. 4744) |
| H5 | Colisión de Id de principios entre los dos libros (P-1…P-10 vs P-1…P-9) | §1.2 libro .NET; §2 conversacional |
| H6 | Variable con nombre histórico: `OLLAMA_PROPIO_*` designa el «segundo servidor», no necesariamente propio | `<G>/Examples/README.md` §Variables |
| H7 | Conocimientos sin `doc_id`/YAML, a diferencia de los libros. **Cerrado (2026-11-19): mudados** a la base de conocimientos, que valida su cabecera con su propia compuerta; en LD queda el puntero | cabeceras de `<G>/Conocimientos/*.md` en `8791fb1` |
| H8 | Enlaces relativos de los `.md` de la familia: 0 rotos (comprobación con script sobre `](ruta)` locales) | 34929f2 |

## Fuentes

- `Guides/IA/Dot-Net-Integration-AI-Layer-Guide/Dot-Net-Integration-AI-Layer-Guide.md` (frontmatter, §0–§1, §14, Anexos D, E, H) y `.md.refs`
- `Guides/IA/Dot-Net-Integration-AI-Layer-Guide/Conversational-Design-Framework-Guide.md` (frontmatter, §0, B, §2, §3, Anexo H)
- `Guides/IA/Dot-Net-Integration-AI-Layer-Guide/Conocimientos/README.md` y cabeceras/índices de K1–K8 en `8791fb1`;
  cabeceras de `Knowledges/Knowledge-AI-Layer-*.md` 2.0 en la base de conocimientos (sin medidas: repositorio privado)
- `Guides/IA/Dot-Net-Integration-AI-Layer-Guide/Examples/README.md` y primera línea de cada `Examples/NN-*/README.md`
- `Guides/IA/Dot-Net-Integration-AI-Layer-Guide/Demos/MovilidadUrbana.Asistente/README.md`
- `Guides/IA/Dot-Net-Integration-AI-Layer-Guide/Laminas/LEEME.md`, `Compuertas/README.md`, `.markdownlint.jsonc`
- `git log` de la carpeta (31 commits, desde acfb9bd 2026-11-02)

Vigencia: 2026-11-16 · fuente `origin/main` 34929f2.
