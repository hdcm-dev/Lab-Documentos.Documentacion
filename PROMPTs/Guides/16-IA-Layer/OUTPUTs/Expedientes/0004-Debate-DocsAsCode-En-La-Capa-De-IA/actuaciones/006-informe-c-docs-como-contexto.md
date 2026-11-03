| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-11-03 |
| Autor | Comisión C-DOCS-COMO-CONTEXTO |
| Corrige | — |

Incorporado verbatim desde la ruta de trabajo del rol. Lo que sigue a esta línea, hasta el pase, es la pieza.

---
doc_type: informe-comision
title: Informe de la comisión C-DOCS-COMO-CONTEXTO — la documentación como insumo de agentes y RAG
status: borrador
origin: ia-generated
confidence: media
owner: comisión C-DOCS-COMO-CONTEXTO, mesa conjunta del expediente 0004
last_review: 2026-11-03
audience: [mesa conjunta del expediente 0004, PO]
---

# Informe de la comisión C-DOCS-COMO-CONTEXTO

**Secciones de `Knowledge-Mesa-De-Expertos-A-Pedido.md` leídas:** §0, §2.2, §3.2, §3.3 y §4. La clase es
«diseño de una norma o decisión» (§2.2), así que cito fuentes externas con su número o su autor y año, y no
invento cláusulas. Donde no verifiqué el apartado, cito la norma sin apartado.

**Mandato.** La documentación como insumo de agentes y RAG: `llms.txt`, `AGENTS.md`, MCP, recuperación
filtrada por audiencia y `delivery`, OWASP Top 10 para aplicaciones LLM 2025 (LLM01, LLM02, LLM06, LLM08),
procedencia y vigencia, canarios. **No-competencia:** no opino sobre métricas M-1/M-4, bancos de evaluación,
model cards, elección de modelo, didáctica ni operación del servidor de modelos.

**Convención de citas.** Uso las mismas siglas que las dos posiciones: `LD`, `LDD`, `EXP2/`, `EXP3/`, `K`,
`G16`, `DG`, `LG`, `AIL`. `POS-DAC` = posición de DocsAsCode; `POS-IA` = posición de la Capa de IA. El
servicio privado va como `{servicio-privado}`.

**Clase de ancla.** E1 = lo medí con un comando sobre el repo; E2 = lo leí en un documento aceptado; C = lo
afirma una posición y no lo verifiqué (sólo funda preguntas).

## 0. Lo que verifiqué contra el repo

| Afirmación | Dónde | Resultado | Ancla |
| --- | --- | --- | --- |
| CA-7 sostiene «el agente hereda el alcance, nunca lo amplía» (LLM06), «`llms.txt` y `AGENTS.md` no son control de acceso» y la «lethal trifecta» | `EXP3/370-informe-agentes-como-audiencia.md`, tesis 2 y 3, tabla de fuentes | Confirmado; además propone una función única `Visible(audiencia_sesión, pieza)` para todos los canales, `llms.txt` generado por sesión si no es público, e índice filtrado **antes** de la búsqueda (LLM08), y el control AG-1 (todo `llms.txt` generado desde la matriz) | E1 (grep) |
| MCP no aparecía en TEM-04/TEM-06 al momento de CA-7 | `EXP3/370`, línea que lo declara | Lo afirma CA-7 con su búsqueda; no la repetí | C |
| `DG` tiene AI-1 a AI-5; AI-3 sólo avisa | `LD/tools/docs-guard/README.md`, tabla PR-3 y tabla de bloqueo | Confirmado | E1 |
| El esquema exige `origin` y `confidence` si no es humano, y tiene `delivery` | `LD/tools/docs-guard/esquemas/cuerpo.schema.json` | Confirmado: `origin` ∈ {human, ia-assisted, ia-generated}; `confidence` obligatorio si no es `human`; `delivery` es arreglo no vacío | E1 |
| `AGENTS.md` de `LD` es documento del sistema | `LD/AGENTS.md`, frontmatter | Tiene `doc_id`, `doc_type: indice`, `origin: ia-assisted`, `last_review: 2026-10-28`, `audience: [agente, humano]`; en sus primeras 25 líneas no aparece `delivery` | E1 |
| `G16` trata el filtro de permisos en RAG | `G16` §8.4 y §8.6 | Confirmado: el permiso va en el `Filter` **antes** de comparar o en una colección por inquilino; «filtrar después de recuperar deja que un fragmento ajeno ocupe el top-k»; el texto recuperado es entrada no confiable; LLM08 mapeado | E1 |
| Ninguno de los dos casos (Geometría, `{servicio-privado}`) recupera documentos | `POS-IA` §4, respuesta 1 | Lo declara la propia parte | C |

## 1. Cómo resuelve la industria esta cuestión, desde mi mandato

### 1.1 Tres canales y una sola regla

La industria hoy entrega documentación a agentes por tres canales distintos, y ninguno de los tres trae
control de acceso propio:

1. **`llms.txt`** (Howard, 2024, propuesta publicada en llmstxt.org): un índice en Markdown en la raíz o en
   un subcamino, que apunta a versiones `.md` de las páginas. Es un mecanismo de **descubrimiento y formato**;
   la propuesta no trata autenticación ni audiencias.
2. **`AGENTS.md`** (formato abierto impulsado en 2025 por varios proveedores de agentes de código; hoy bajo
   custodia de la Agentic AI Foundation de la Linux Foundation, según lo verificado por CA-7): un «README para
   agentes», sin campos obligatorios, donde gana el archivo más cercano al que se edita. Es **instrucción** al
   agente, no permiso.
3. **Servidores MCP** (Model Context Protocol, especificación revisión 2025-06-18): exponen recursos y
   herramientas. Sobre HTTP, la autorización se apoya en OAuth 2.1, con metadatos del recurso protegido según
   RFC 9728 (2025) e indicadores de recurso según RFC 8707 (2020), y el servidor valida que el token fue
   emitido para él. Es el único de los tres canales que **sí** trae un modelo de identidad, y lo trae
   prestado del mundo OAuth.

A esto se suma el cuarto canal, que no es un formato sino una arquitectura: **RAG** (Lewis et al., 2020),
donde un índice de embeddings decide qué fragmentos entran al contexto.

La regla que la industria aplica sobre los cuatro es vieja: **mediación completa y mínimo privilegio**
(Saltzer y Schroeder, 1975). OWASP la traduce al mundo LLM en LLM06:2025 *Excessive Agency*: las acciones se
ejecutan en el contexto del usuario y la autorización se hace cumplir en el sistema de abajo, no la decide el
modelo. Para recuperación, LLM08:2025 *Vector and Embedding Weaknesses* nombra el riesgo de fuga entre
contextos en almacenes compartidos y pide control de acceso con permisos sobre el almacén. NIST AI 600-1
(2024), el perfil de IA generativa del AI RMF, trata la divulgación de información y la integridad de la
información como riesgos propios de la IA generativa (lo cito sin apartado).

**Consecuencia práctica, convergente en la industria:** el filtro por audiencia se aplica **antes** de que el
fragmento pueda ser candidato (filtro de metadatos previo a la búsqueda, o colección/índice por inquilino), y
nunca en la respuesta del modelo. Un modelo no es un punto de control de acceso: no tiene un estado de
autorización que se pueda auditar.

### 1.2 La documentación que entra al contexto es entrada no confiable

- **LLM01:2025 *Prompt Injection*** distingue inyección directa e indirecta; la indirecta llega por
  contenido externo que el modelo procesa: páginas, archivos, documentos recuperados. La caracterizaron
  Greshake et al. (2023), «Not what you've signed up for: Compromising Real-World LLM-Integrated
  Applications with Indirect Prompt Injection». OWASP declara que RAG no la elimina.
- La formulación operativa más usada hoy es la **«lethal trifecta»** (Willison, 2025): acceso a datos
  privados + exposición a contenido no confiable + capacidad de comunicar hacia afuera. Si un asistente
  documental tiene las tres, la documentación que lee puede exfiltrar. La defensa reconocida es **romper una
  de las tres patas por diseño**, no confiar en que el modelo obedezca un «esto es referencia, no órdenes».
- **LLM02:2025 *Sensitive Information Disclosure***: lo que no debe salir no tiene que estar en el contexto.
  Pedirle al modelo que no lo diga no es un control.

### 1.3 Procedencia y vigencia

- **Procedencia.** El modelo de referencia es W3C PROV (PROV-O, Recomendación W3C, 2013): entidad, actividad,
  agente, y la relación «fue generada por» / «fue atribuida a». En documentación para agentes esto se
  reduce a tres preguntas que el recuperador tiene que poder contestar por fragmento: quién lo escribió
  (persona o modelo), quién lo aprobó, y de qué versión del repositorio sale.
- **Vigencia.** La industria lo resuelve con metadatos de revisión y expiración que el **indexador** respeta
  (no se indexa lo vencido, o se reindexa por calendario). Un rótulo de «vencido» dentro del texto no es un
  control: el modelo puede ignorarlo, y además ese rótulo es exactamente el tipo de instrucción embebida que
  LLM01 enseña a no confiar.

### 1.4 Canarios

- La técnica de sembrar un secreto único y verificar si aparece viene de la medición de memorización:
  Carlini et al. (2019), «The Secret Sharer: Evaluating and Testing Unintended Memorization in Neural
  Networks» (USENIX Security), insertan *canaries* y miden su exposición. En seguridad operativa existen los
  *canary tokens* / *honeytokens* como señuelos cuya lectura dispara una alerta.
- Aplicado a RAG: se siembra en el corpus de una audiencia restringida un fragmento con una cadena única y
  sin sentido, y con la identidad de cada otra audiencia se interroga al asistente. El canario **no** puede
  aparecer ni en la respuesta ni —esto es lo que la industria suele omitir— en el **contexto armado** que se
  registra. La segunda verificación es determinista y no depende del modelo; la primera sí.

## 2. Qué coincide, qué falta y qué sobra en lo que hicieron las dos sesiones

### 2.1 Coincide con la industria

| Lo hecho | Evidencia | Con qué fuente coincide |
| --- | --- | --- |
| «El agente no es una audiencia: hereda la de su usuario y no la amplía» | `EXP3/370` tesis 2 (E1) | OWASP LLM06:2025; Saltzer y Schroeder (1975) |
| `llms.txt` y `AGENTS.md` no son control de acceso; `llms.txt` es una salida más del filtro, una por audiencia | `EXP3/370` tesis 3 (E1); `EXP3/399` §1 (E2, citado por `POS-DAC`) | llmstxt.org (Howard, 2024) no trata acceso |
| Filtro único para todos los canales, aplicado antes de la búsqueda | `EXP3/370` regla 1 y LLM08 (E1); `G16` §8.4 y §8.6 (E1) | OWASP LLM08:2025; práctica de filtro previo o colección por inquilino |
| `audience` orienta, `delivery` decide | `EXP3/399` §1 (E2); `cuerpo.schema.json` tiene `delivery` (E1) | Separación entre metadato descriptivo y atributo de autorización (mínimo privilegio) |
| La ayuda de formulario leída por un asistente es contenido no confiable | `EXP3/370` (E1); `G16` §8.6 la saca del chat (E1) | LLM01:2025 indirecta; Greshake et al. (2023); romper una pata de la trifecta (Willison, 2025) |
| Procedencia mínima en el frontmatter (`origin`, `confidence`) | `cuerpo.schema.json` (E1) | W3C PROV, en su forma reducida |
| AI-1 a AI-5 sobre lo que el agente lee del corpus | `DG/README.md` (E1) | LLM01:2025: higiene de la entrada |
| En `{servicio-privado}` el contexto lo arma el controlador y el modelo nunca recibe la aplicación como argumento | `POS-IA` §1 y §4.2 (C) | LLM06:2025 y LLM02:2025: la autorización la hace cumplir el código |

### 2.2 Falta

1. **Ningún índice por audiencia existe todavía.** Las dos sesiones lo proponen (`POS-DAC` §2.3.1; `EXP3/370`
   regla 1) y `G16` lo enseña (§8.6), pero ninguno de los dos casos recupera documentos (`POS-IA` §4.1, C).
   La regla está escrita y no tiene par rojo/verde. Por el filtro «Descripción o control» (§3.3 de la norma de
   la mesa), hoy es un control declarado que nadie ejerce.
2. **El canario no existe.** `POS-DAC` lo propone y `POS-IA` coincide «aunque no los ensayamos» (§4.5, C).
   Falta además separar las dos verificaciones: canario en el **contexto armado** (determinista, sin modelo) y
   canario en la **respuesta** (depende del modelo). Sólo la primera puede bloquear desde el día uno sin ruido.
3. **`AGENTS.md` sin `delivery`.** El `AGENTS.md` de `LD` tiene `audience: [agente, humano]` y no muestra
   `delivery` en su frontmatter (E1, primeras 25 líneas). Si `delivery` es lo único que decide (`EXP3/399`),
   el archivo que más leen los agentes queda fuera de la regla de entrega.
4. **Procedencia sin aprobación ni versión de origen.** El esquema tiene `origin` y `confidence`, pero no
   quién aprobó ni el commit de origen del fragmento (E1). `POS-IA` §2.6 pide `revisado_por`; coincido en la
   necesidad. Para un recuperador falta también la **versión de origen** del fragmento indexado: sin ella no se
   puede invalidar un índice cuando el documento cambia.
5. **Vigencia que no actúa sobre el índice.** `last_review` existe, pero nada impide hoy indexar lo vencido.
6. **MCP sin diseño.** CA-7 lo trae (OAuth 2.1, validación de audiencia del token) y declara que el cuerpo no lo
   tenía (C). Ninguna sesión tiene un servidor MCP. Si se construye uno, el filtro de `delivery` tiene que
   correr también sobre `resources/list` y `tools/list`, no sólo sobre el contenido.
7. **LLM02 sobre registros.** `POS-IA` §2.5 propone R-PRIV sobre registros y salidas. Falta decir que el
   **contexto recuperado** que se registra para auditar también es dato restringido: un registro del contexto
   con un fragmento de otra audiencia es una fuga, aunque el modelo no lo haya dicho.

### 2.3 Sobra (o hay que corregir)

1. **«Vencido = se indexa con rótulo visible para el modelo»** (`POS-DAC` §2.3.4, segunda alternativa). Sobra.
   Un rótulo para el modelo es una instrucción embebida en el contexto, la clase de cosa que LLM01 manda no
   tratar como control. Vencido no se indexa, sin alternativa.
2. **Herramientas como «contratos OpenAPI por audiencia, con el mismo 404»** (`POS-DAC` §2.3.5). La idea es
   correcta; la forma sobra en parte. En MCP la herramienta se descubre por el protocolo, no por un OpenAPI, y
   el equivalente del 404 es que la herramienta **no aparezca** en la lista para esa identidad. Para lo que se
   expone por HTTP, el OpenAPI por audiencia sí vale tal cual.
3. **Marcar `lee-ia` en cada pieza** (`POS-DAC` §2.3.3, primera mitad). Sobra como campo: **todo** lo que entra
   al contexto se trata como no confiable por procedencia, como ya dice `G16` (`POS-IA` §1, C). Un campo que
   diga «esto lo lee la IA» invita a pensar que lo no marcado es confiable. La segunda mitad (`escribe-ia`,
   borrador, no vuelve como contexto sin aprobación humana) **no** sobra: es la regla que hace falta.
4. **AI-3 como defensa de LLM01.** No sobra el chequeo, pero sobra la expectativa: detectar frases dirigidas
   al agente es higiene y tiene falsos positivos declarados (`DG/README.md`, E1). La defensa es estructural:
   romper una pata de la trifecta.

## 3. Respuestas propias

### 3.1 A las siete preguntas de DocsAsCode

1. **¿Dónde vive el filtro por `delivery`?** En los dos, con una sola fuente de verdad: **el documentador**.
   El documentador genera un corpus (y un índice) por audiencia, y esa partición es la fuente de verdad. La
   capa de IA filtra de nuevo en la recuperación por la identidad de la sesión, como defensa en profundidad,
   y **no puede ampliar** lo que el documentador entregó. Si los dos filtros discrepan, gana el más
   restrictivo y se abre un hallazgo P0.
2. **¿Qué identidad usa la capa para recuperar?** La del **usuario**, propagada; nunca la del servicio ni la
   del agente con alcance propio. El agente recupera con un token emitido para ese usuario y para ese recurso
   (patrón MCP con RFC 8707 y validación de audiencia del token). Se prueba con el canario: por cada audiencia,
   se arma el contexto con esa identidad y se verifica de forma determinista que ningún fragmento de otra
   audiencia esté en el contexto. Si el índice es por audiencia, se prueba además que la identidad de A no
   puede abrir el índice de B.
3. **¿Lo que escribe un agente cuenta como fuente antes de la aprobación humana?** No. Un documento
   `origin: ia-generated` sin aprobación humana **no se indexa** para ninguna audiencia. Rótulo: `origin:
   ia-generated` + `revisado_por: ninguno | agente-independiente`; el indexador sólo admite `humano`. Si no
   se indexa, no hace falta rótulo para el modelo.
4. **¿`AGENTS.md` es documentación o configuración?** Documentación, con frontmatter completo, incluido
   `delivery`, y con vigencia. Es instrucción que el agente obedece: por eso tiene que pasar por la compuerta
   **más** que un documento cualquiera, no menos. Su contenido no puede dar permisos: sólo orientar.
5. **¿Qué bloquea desde el principio?** Tres, todos deterministas: (a) **canario en el contexto armado**, por
   cada audiencia, sin modelo; (b) **prueba negativa de no publicación** en cada canal (HTML, `.md`,
   `llms.txt`, índice, MCP) conectada a CI, que es justo lo que en `{servicio-privado}` existía y no corría
   (`POS-DAC` §1, C); (c) **AG-1** de CA-7: todo `llms.txt` e índice para agentes sale generado de la matriz
   de entrega, ninguno escrito a mano. El canario en la **respuesta** del modelo nace en «avisa», porque
   depende del modelo.
6. **¿Cómo se ensaya con aplicador ciego cuando el resultado son respuestas de un modelo?** Desde mi
   mandato: el oráculo de la parte de acceso no mira la respuesta, mira el **contexto armado**. El aplicador
   ciego recibe la identidad de una audiencia y una lista de preguntas diseñadas para tentar la recuperación
   de lo restringido; el oráculo es «cero fragmentos de otra audiencia en el contexto registrado, cero
   canarios». Umbral: cero, sin intervalo, porque es una garantía y no una tasa. La calidad de la respuesta
   queda fuera de mi mandato.
7. **¿Los P0 de K 1.4 se cierran antes de integrar?** Para lo que alimenta un índice, **sí, antes**. El P0
   que `POS-DAC` describe —dar por buena una excepción vencida y validar citas sin mirar contenido
   (`EXP3/208` §5.3, C)— es exactamente un defecto de vigencia y de procedencia, que un modelo cita con
   confianza. Se puede escribir sobre el borrador; no se indexa el borrador.

### 3.2 A las preguntas de la Capa de IA que tocan mi mandato

- **Pregunta 3 (¿corrida es documento o evidencia?).** Sólo en lo que me toca: si una corrida se indexa como
  contexto para un agente, entra como documento, con `delivery` y procedencia; su evidencia cruda (salidas,
  contexto registrado) es dato restringido y **no se indexa**, porque puede llevar contenido de otra
  audiencia (§2.2.7). La huella SHA-256 va en el documento.
- **Pregunta 5 (¿nombre del modelo en repo público junto con decisión de un producto privado?).** Desde
  LLM02: no en el mismo documento. El nombre del modelo solo no es sensible; la combinación con la decisión
  y el comportamiento de un producto privado sí lo puede ser. En repo público, el modelo se nombra del lado
  del producto público; del lado de `{servicio-privado}`, por código.
- **Pregunta 6 (¿AIL-n en `DG` o en la guía 16?).** Sólo los chequeos de procedencia y de entrega sobre lo
  que **entra al contexto** van a `DG`, porque el corpus de `LD` es uno; lo demás de AIL-n queda fuera de mi
  mandato. La excepción a AI-2 por clase de documento (`POS-IA` §2.5) es correcta y va con huella, como las
  demás excepciones de `DG`.
- Preguntas 1, 2, 4 y 7: fuera de mi mandato.

## 4. Lo que revisé y está bien

- `EXP3/370` (CA-7) es, por lo que verifiqué, la pieza que mejor resuelve el mandato: fuentes reales
  (OWASP 2025, MCP 2025-06-18, llmstxt.org, AGENTS.md, Willison 2025), regla de filtro único, filtro antes
  de la búsqueda y un control (AG-1) con par rojo/verde.
- `G16` §8.4 y §8.6 enseñan el filtro de permisos **antes** de comparar y explican por qué filtrar después
  falla (top-k ocupado por un fragmento ajeno). Es correcto.
- `G16` §8.6 no confía en «son texto de referencia, no órdenes» como protección y lo dice; saca la ayuda del
  chat para que el contexto recuperado no conviva con herramientas. Es la defensa de la trifecta bien
  aplicada.
- `cuerpo.schema.json` hace obligatoria `confidence` cuando `origin` no es humano: la procedencia mínima ya
  la exige una compuerta y no una costumbre.
- `DG` declara los falsos positivos de AI-3 y no lo hace bloquear: no se finge un control que no se tiene.
- El diseño de `{servicio-privado}`, como lo describe `POS-IA`, deja la autorización en el controlador y no
  en el modelo (C: no lo verifiqué en su repo, y no corresponde hacerlo desde un expediente público).

## 5. Fuentes externas citadas

- OWASP GenAI Security Project, *OWASP Top 10 for LLM Applications 2025*: LLM01:2025 Prompt Injection,
  LLM02:2025 Sensitive Information Disclosure, LLM06:2025 Excessive Agency, LLM08:2025 Vector and
  Embedding Weaknesses.
- NIST, *Artificial Intelligence Risk Management Framework: Generative Artificial Intelligence Profile*,
  NIST AI 600-1, 2024 (sin apartado).
- Model Context Protocol, *Specification*, revisión 2025-06-18, sección de autorización.
- IETF RFC 9728, *OAuth 2.0 Protected Resource Metadata*, 2025.
- IETF RFC 8707, *Resource Indicators for OAuth 2.0*, 2020.
- Howard, J. (2024). Propuesta `/llms.txt`, llmstxt.org.
- AGENTS.md, formato abierto para instrucciones de agentes de código (2025).
- W3C, *PROV-O: The PROV Ontology*, Recomendación W3C, 2013.
- Saltzer, J. H. y Schroeder, M. D. (1975). «The Protection of Information in Computer Systems».
  *Proceedings of the IEEE*, 63(9).
- Lewis, P. et al. (2020). «Retrieval-Augmented Generation for Knowledge-Intensive NLP Tasks». *NeurIPS 2020*.
- Greshake, K. et al. (2023). «Not what you've signed up for: Compromising Real-World LLM-Integrated
  Applications with Indirect Prompt Injection». *AISec '23 (ACM)*.
- Carlini, N. et al. (2019). «The Secret Sharer: Evaluating and Testing Unintended Memorization in Neural
  Networks». *USENIX Security 2019*.
- Willison, S. (2025). «The lethal trifecta for AI agents».

Sigue: incorporar el informe siguiente · presidencia de la mesa
