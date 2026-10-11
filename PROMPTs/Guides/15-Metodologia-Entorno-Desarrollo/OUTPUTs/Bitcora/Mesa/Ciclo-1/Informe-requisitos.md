# Mesa · Ciclo 1 · Informe de Requisitos

> Fecha: 2026-10-07. Rol: Requisitos (núcleo permanente). Marco: `IA/PROMPTs/IA.Prompts/Base/Mesa-Evaluadora.md`.
> Artefacto: `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (1.0.0-borrador, 3060 líneas). «L*n*» = línea de ese archivo en esta fecha.
> Revisión a ciegas: no se leyeron informes de otros especialistas de este ciclo. Sí se leyeron el prompt del PO, el Profile, el RuleSet, las reglas, la convocatoria (00) y `Bitcora/04-Integracion.md` (para la matriz de trazas).

## 1. Matriz solicitud → sección

### 1.1 Pedidos de contenido del PO (Contexto y Solicitudes)

| ID | Pedido (prompt del PO) | Sección de la guía | Estado |
|---|---|---|---|
| P-01 | Caso: cp1252 leído como UTF-8 en Linux, falla de compilación y acentos con `?`; en Windows funciona | §1.1–§1.4 (L98–L162), §4.2.1–§4.2.2, E1-01 | Cumple |
| P-02 | Desarrollo simultáneo con Visual Studio en Windows, Linux y devcontainers | §2.1 (ESC-01…ESC-05), §8.2.4 | Cumple |
| P-03 | Criterio unificado de codificación, sin commits de cambios de BOM | §5 completo, §10.2.2, A.1, A.2, A.15 | Cumple |
| P-04 | Congelar paquetes NuGet | §7 (§7.2.1), A.5, A.6 | Cumple |
| P-05 | Congelar versiones de compilador y SDK | §6 (§6.2.2), A.3 | Cumple |
| P-06 | ¿Se puede con contenedores? | §3.5, §8 | Cumple |
| P-07 | Integración con herramientas en Windows y Linux | §8.2.4, §8.2.5, §10.4, §12 | Cumple (con rótulos [no verificado] por falta de Windows, declarados en Anexo F) |
| P-08 | Saber con qué entorno se ensambló cada pieza | §3.2 (capa 6), §9, §9.6 | Cumple |
| P-09 | Estrategias de la industria para .NET, Node.js, Python | §4.3–§10.3 («Qué propone la industria») | Cumple por capa; **sin comparación de enfoques de entorno completo** (ver requisitos-04) |
| P-10 | Qué pasa al integrarlos en una única solución | §11 | Cumple |

### 1.2 Reglas del PO y del Profile

| Regla | Exigencia | Sección / evidencia | Estado |
|---|---|---|---|
| R-PO-1 | Secciones jerárquicas con índices | Índice L28–L51; encabezados sin saltos; 0 anclas rotas, 0 títulos duplicados (chequeo E1, §3) | Cumple |
| R-PO-1 | Definiciones | §3.1 y n.1 de cada capítulo 4–11; Anexo C | Cumple con huecos de glosario (requisitos-02) |
| R-PO-1 | Mermaid cuando sea necesario | 11 diagramas (L137, L260, L429, L614, L689, L850, L1028, L1200, L1398, L1616, L1985) | Cumple |
| R-PO-2 | Autocontenida, no delta | Toda la guía; glosario | Cumple salvo `traces` del front matter (requisitos-05) |
| R-PO-3 | Ejemplos, explicaciones, snippets representativos | n.5 «Ejemplos concretos» en §4–§11, con experimento | Cumple |
| R-PO-3 | Preguntas guía con respuesta | n.6 en §3–§11: 57 preguntas, todas con respuesta | Cumple |
| R-PO-3 | …que permitan identificar en qué caso se aplica cada concepto | Rótulo *Aplica* en 20 de 57 | **Parcial** (requisitos-01) |
| R-PO-4 | Descomposición en núcleos, cohesión, integración | `Bitcora/01`, `02`, `03`, `04`, `Nucleos/N0…N8` | Cumple (en bitácora; no es materia de la guía) |
| Profile | Marco de referencia (escenarios, contextos, actores) | §2.1–§2.3 | Cumple |
| Profile | Mapa conceptual por escenario, **por contexto** y por artefacto | §3.6: por síntoma, por escenario, por artefacto | **Falta la entrada por contexto** (requisitos-03) |
| Profile | Estructura temática común (definición, aplicación, ejemplos, preguntas, criterios, anexo) | §4–§11, subsecciones n.1–n.8 idénticas | Cumple |
| Profile | Aplicación por escenario **y qué cambia según el contexto** | §4.4, §9.4, §10.4, §11.4 lo dicen; §5.4, §6.4, §7.4, §8.4 no | Parcial (requisitos-03) |
| Profile | Métodos y marcos: enfoques alternativos y criterio para elegir | No hay pieza que compare enfoques de entorno completo | **Falta o falta declarar fuera de alcance** (requisitos-04) |
| Profile | Anexos: plantillas comentadas con preguntas por campo, listas de verificación, glosario | Anexo A (16 plantillas, cada una con «Preguntas…»), B, C | Cumple |
| Profile | README con ruta de lectura | Índice + §0.2 (DC-01 lo materializa así) | Cumple por decisión de contrato |
| Rule-Dual-Audience | Resumen ejecutivo | L22–L26 | Cumple |
| Rule-Dual-Audience | Front matter, IDs estables | L1–L18; ESC-, CTX-, ACT-, E*n*-*m*, B*nn* | Cumple; `traces` sin resolver (requisitos-05) |
| Rule-Dual-Audience | Término definido en su primer uso **y registrado en el glosario** | Anexo C | **Parcial** (requisitos-02) |
| Rule-Dual-Audience | Bloques `entradas`/`salidas`/`validaciones` en procesos ejecutables | §5.2.6, §10.2.2, §12 sin bloque | **Falta** (requisitos-06) |
| Rule-Indexing | Sincronizar la ia-db con documentos nuevos | ia-db de `Lab-Documentos.Documentacion` no menciona la guía | **Falta y queda fuera del alcance de escritura** (requisitos-07) |
| Rule-Evidences | Fuente con fecha o experimento; criterio rotulado | §0.3 marcas; Anexo D (fechas), Anexo E, Anexo F | Cumple (el fondo lo juzga verificación-evidencia) |
| R-PRIV | Sin identificadores privados | `grep -rn -i -E "GDA|SGM|Notions|BotonPanico|oordenadaExtacta"` sobre guía y `Examples/` → 0 líneas | Cumple |

### 1.3 Pedidos de proceso (no son materia de la guía)

S-03 reedición del prompt → `OUTPUTs/Metodlogia-Entorno-Desarrollo.md` (existe, 534 líneas). S-04/S-05 panel y experto adicional → `Mesa/Ciclo-1/00-Convocatoria.md`. S-06 relectura integral y correcciones → pendiente (la guía declara `status: borrador (pendiente de relectura integral de la mesa)`, L6). S-07 apuntes y borradores → `Bitcora/`. S-08 ruta del entregable → cumple.

## 2. Hallazgos

### requisitos-01 · Preguntas guía sin criterio de aplicación explícito — S2 · E1 + E4

- **Ubicación**: §3.7 (L375), §4.6 (L553), §6.6 (L973), §7.6 (L1128), §8.6 (L1343), §9.6 (L1562), §10.6 (L1802), §11.6 (L2124).
- **Ancla**: regla del PO: «preguntas guías acompañadas de respuestas explicativas … que permitan o sirvan al lector identificar en que caso se aplica cada concepto». La guía fija su propio patrón en §3.7 (L378: «*Aplica* a todo artefacto que salga de la CI…»), pero el conteo por sección da:

  ```text
  $ awk '…cuenta preguntas en negrita y rótulos *Aplica* por sección n.6…' Metodologia-Entorno-Desarrollo-Guide.md
  3.7 q=5 aplica=2 | 4.6 q=6 aplica=2 | 5.6 q=7 aplica=5 | 6.6 q=7 aplica=2 | 7.6 q=6 aplica=2
  8.6 q=6 aplica=2 | 9.6 q=6 aplica=1 | 10.6 q=7 aplica=1 | 11.6 q=7 aplica=3
  ```

  20 de 57 preguntas dicen cuándo aplica lo que responden. Ejemplos sin criterio: §9.6 «¿SBOM o procedencia?» (L1568), §11.6 preguntas 3–6 (L2132–L2141), §10.6 seis de siete.
- **Impacto**: el pedido formativo central del PO (identificar el caso de aplicación) queda a criterio del lector en dos tercios de las preguntas; patrón inconsistente entre capítulos.
- **Dirección**: cerrar cada respuesta con una línea *Aplica* que nombre escenario (ESC-), contexto (CTX-) o actor (ACT-) en que vale, o «siempre» con su motivo; donde la respuesta ya lo dice en prosa, sólo rotularlo.
- **Confianza**: 0,85.

### requisitos-02 · Glosario incompleto y un término de glosario con tres sentidos — S2 · E1 + E2

- **Ubicación**: Anexo C (L2687–L2752); definiciones en §5.1, §6.1, §7.1, §8.1, §9.1, §10.1, §11.1; «índice» en L28, L370, L1143, L1451, L1915, L2726.
- **Ancla**: Rule-Dual-Audience: «Definir cada término en su primer uso y registrarlo en el glosario». Script que cruza las filas en negrita de las tablas de definición con las entradas del Anexo C (E1): quedan fuera del glosario, entre otros, **Política de texto** (L599, título de §5), **Archivo nativo de versión** (L1849, base de §11.2.3 y de B.1), **Orquestador** (L1847), **Grafo resuelto** (L1016), **Resolución libre** (L1019), **Integridad** (L1020), **Imagen multi-runtime** (L1848), **Imagen de desarrollo / de CI / de ejecución** (L1181), **Metadatos embebidos** (L1386), **Dueño del código** (L1607), **Runtime** (L839), **Monorepo** (L1845), **Aislar de `blame`** (L604), **`devcontainer-lock.json`** (L1180).
  Además, el glosario define «Índice / working tree | Lo que git guarda» (L2726), pero el texto usa «índice» también como registro de paquetes («índices de uv», L370 y L1915; «cambios de origen (`resolved`, `source`, índice)», L1143; «índices privados», L1451) y como tabla de contenidos («## Índice», L28). El marco (§3, «todo término del glosario se usa con un solo sentido») lo trata como falla de coherencia chequeable; se propone S2 y no S1 porque no vuelve inconsistente a la guía, sólo ambigua para un lector nuevo.
- **Dirección**: agregar al Anexo C los términos listados (definición breve + sección); en el glosario, distinguir «Índice (git)» de «Índice de paquetes (registro)» como alias del término canónico «registro», y usar «índice de paquetes» o «registro» en L370, L1143, L1451, L1915.
- **Confianza**: 0,8.

### requisitos-03 · El mapa conceptual no tiene entrada por contexto, y cuatro capítulos no dicen qué cambia por contexto — S3 · E2 + E4

- **Ubicación**: §3.6 (L335–L373); §5.4 (L736), §6.4 (L923), §7.4 (L1081), §8.4 (L1307).
- **Ancla**: Profile, «Mapa conceptual | Tablas de entrada por escenario, por contexto y por artefacto»; estructura temática: «Aplicación por escenario — … y qué cambia según el contexto». §3.6 abre con «Tres puertas de entrada» (L337): **Por síntoma**, **Por escenario**, **Por artefacto**; no hay tabla por CTX-NET / CTX-NODE / CTX-PY / CTX-POLI. §4.4 (L513), §9.4 (L1520), §10.4 (L1759) cierran con un párrafo «Por contexto» o «En CTX-POLI»; §5.4, §6.4, §7.4 y §8.4 no mencionan ningún CTX- (los IDs CTX- aparecen fuera de §2.2 sólo en L513, L1520, L1759, L1844, L2048).
- **Impacto**: el lector que llega por «tengo sólo un proyecto Python» o «tengo los tres» no tiene puerta de entrada; los contextos del marco quedan definidos y casi sin uso (Profile: «Un tema que no se cruza con ningún escenario ni contexto sobra o está mal delimitado»).
- **Dirección**: agregar en §3.6 una tabla «Por contexto» (CTX → capítulos y archivos mínimos); en §5.4–§8.4, un párrafo «Por contexto» como el de §4.4, que puede remitir a la subsección n.3 por ecosistema.
- **Confianza**: 0,8.

### requisitos-04 · Falta la pieza «Métodos y marcos» o su exclusión declarada — S3 · E2 + E4

- **Ubicación**: §0.1 (L59–L61); §3.4 (L309–L320); §11.3 (L2020–L2044).
- **Ancla**: Profile, «Métodos y marcos | Enfoques alternativos del dominio: en qué consiste cada uno, en qué se diferencian, criterios para elegir»; PO: «Analizar las estrategias de lo que propone la industria actual». La guía compara mecanismos **por capa** (§3.3, n.3 de cada capítulo) y elige un enfoque —archivos nativos + compuerta + imagen por digest— pero no lo contrasta con enfoques de entorno completo. La única mención a un sistema de build hermético es la definición tomada de Bazel [B04] (L251) y una fila de §3.4 (L320); `grep -i -w -c nix` sobre la guía → 0. §0.1 enumera lo que queda fuera (despliegue, Java/Go/Rust, comparativas de CI, «herramienta única para todo») sin nombrar entornos declarativos completos ni sistemas de build herméticos.
- **Impacto**: un arquitecto (ACT-ARQ) no puede saber si esas alternativas se evaluaron y descartaron o no se consideraron.
- **Dirección**: o bien una subsección (en §3 o §12) que compare, con fuente oficial y fecha, los enfoques: (a) archivos nativos + compuerta (el de la guía), (b) contenedor como fuente del entorno, (c) gestor multi-runtime (mise/asdf), (d) sistema de build hermético, (e) gestor de entornos declarativo, con criterio de elección por escenario; o bien declararlos fuera de alcance en §0.1 con el motivo. La existencia y estado de (d) y (e) los verifica quien escriba, no este informe (nivel C sobre su vigencia).
- **Confianza**: 0,65.

### requisitos-05 · Las trazas del front matter no se resuelven dentro de la guía — S3 · E2

- **Ubicación**: front matter L15; §1.1 (L104–L110).
- **Ancla**: L15: `traces: [P-01, P-02, …, P-10, R-01, R-02, R-03, R-06, R-07, R-PROF, R-PRIV]`. Ninguno de esos IDs aparece en el cuerpo de la guía (grep → sólo L15); se definen en `Bitcora/04-Integracion.md` L220–L233, que la guía no enlaza ni debe enlazar (R-PO-2, autocontenida). Rule-Dual-Audience: «los enlaces y las trazas apuntan al ID».
- **Impacto**: un agente o un lector no puede verificar qué pedido cubre cada sección; la trazabilidad pedida por el Profile («Trazable») queda en la bitácora y no en el entregable.
- **Dirección**: rotular las cuatro preguntas de §1.1 con sus IDs y agregar en §0 o en el Anexo F una tabla breve «pedido → sección» (la de `04-Integracion` L220–L233, sin referencias a la bitácora); o quitar `traces` del front matter.
- **Confianza**: 0,75.

### requisitos-06 · Procedimientos ejecutables sin bloque `entradas` / `salidas` / `validaciones` — S3 · E1 + E4

- **Ubicación**: §5.2.6 «Migrar un código heredado» (L685–L720); §10.2.2 «La compuerta única» (L1657); §12 «Hoja de ruta» (L2166–L2185).
- **Ancla**: Rule-Dual-Audience, cara agente: «Bloques para agentes (`entradas` / `salidas` / `validaciones`) en los documentos que definan un proceso que un agente deba ejecutar o verificar». `grep -n -i 'entradas:\|salidas:\|validaciones'` sobre la guía → sin salida. §5.2.6 es un procedimiento de seis pasos con scripts y un criterio de aceptación (`0 con cambio de contenido`); §12 es un plan de diez pasos con «Lo que queda verificable».
- **Dirección**: agregar a §5.2.6 y §12 (y opcionalmente §10.2.2) un bloque YAML breve con entradas (repo, política, codificación de origen), salidas (commits, archivos) y validaciones (comando + resultado esperado), tomando los datos que ya están en la prosa.
- **Confianza**: 0,7.

### requisitos-07 · Rule-Indexing sin atender: la ia-db no registra la guía, y escribirla está fuera del alcance — S3 · E1 + E4

- **Ubicación**: `LAB/Lab-Documentos.Documentacion/ia-db/indexes/` (00_MASTER-INDEX.md, 07_DevOps-Agiles-SDD-UX.md); `Bitcora/00-Contrato-De-Entrada.md` L60.
- **Ancla**: RuleSet-Study-Guide incluye Rule-Indexing: «Si la ejecución genera documentos nuevos … actualizar la ia-db antes de finalizar». `grep -rn -i 'Metodologia-Entorno\|Entorno-Desarrollo' LAB/Lab-Documentos.Documentacion/ia-db` → sin salida. El contrato lista Rule-Indexing (L60) pero no dice cómo se cumple, y la restricción de esta corrida prohíbe escribir fuera de bitácora, guía, laboratorio y prompt reeditado.
- **Impacto**: la guía nace sin punto de entrada en la base de conocimiento de la colección; la regla queda incumplida en silencio.
- **Dirección**: no escribir la ia-db en esta corrida; registrar el apartamiento en el bloque de cierre de la mesa como pendiente para el PO (con la entrada propuesta para `07_DevOps-Agiles-SDD-UX.md` y el master index ya redactada en la bitácora), conforme a la práctica de avisar al PO todo apartamiento de una regla del marco.
- **Confianza**: 0,7.

## 3. Revisado y bien

1. **Estructura temática homogénea**: los capítulos 4 a 11 tienen exactamente las ocho subsecciones que promete §0.2 (L70) —Definición, Cómo funciona, Qué propone la industria, Aplicación, Ejemplos, Preguntas guía, Criterios de calidad, Plantilla— en el mismo orden y numeración (n.1–n.8), lo que satisface el patrón del Profile y el parseo por estructura de Rule-Dual-Audience.
2. **Navegación y forma**: 0 anclas internas rotas, 0 enlaces relativos rotos y 0 títulos duplicados (script de validación con slugs estilo GitHub, ignorando bloques de código; E1); índice inicial con ruta de lectura (§0.2) y 11 diagramas mermaid distribuidos donde hay flujo o capas.
3. **Plantillas comentadas con preguntas por campo**: las 16 plantillas del Anexo A abren con «Preguntas…» que guían sus campos (p. ej. A.1 L2193, A.3 L2261, A.6) y remiten al experimento EA-1 que las verifica juntas, como pide el Profile («plantilla comentada, con las preguntas que guían cada campo»).

## 4. Solicitudes de convocatoria

Ninguna. Lo observado fuera de mandato (tablas con celdas largas en §2.3 y §3.1 frente a Rule-Markdown) corresponde a edición bibliográfica, ya en el panel; no se opina.
