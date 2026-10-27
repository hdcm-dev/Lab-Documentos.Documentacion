---
doc_id: EXP0002-F011
doc_type: informe
title: Informe de la comisión C-VERIFICACION — cómo se prueba cada cláusula y con qué criterio pasa cada compuerta
status: vigente
origin: agent
confidence: high
owner: comisión C-VERIFICACION (núcleo permanente) de la mesa de Replanteo y análisis DocAsCode
last_review: 2026-10-26
audience: [presidencia, comisiones, refutador, jurado de veredicto, PO]
traces: [TP:20, TP:30, TP:32, TP:34, TP:36, TP:61, N07:152, EXP0002-F001, EXP0002-F002, EXP0002-F003, EXP0002-F004]
---

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-10-26 |
| Autor | Comisión C-VERIFICACION (a ciegas: leyó sólo los folios 001–004 y los informes 0060/0070 de este expediente) |
| Corrige | — |

**Mandato.** Cómo se prueba cada cláusula, con qué criterio de aceptación pasa cada compuerta y qué compuertas se pueden automatizar con prueba negativa (`N07:152`, V3). **No-competencia:** esta comisión no decide qué bloquea y qué avisa. Lo mide y lo propone. Donde un dictamen toca esa frontera, la clasificación va rotulada «propuesta a C-DECISIONES y la presidencia».

## Índice

1. [Definiciones y alias](#1-definiciones-y-alias)
2. [Resumen de dictámenes](#2-resumen-de-dictámenes)
3. [Dictámenes por pregunta](#3-dictámenes-por-pregunta)
4. [Propuesta de método: la suite de verificación documental](#4-propuesta-de-método-la-suite-de-verificación-documental)
5. [Ensayos corridos](#5-ensayos-corridos)
6. [Excepciones a conocimientos](#6-excepciones-a-conocimientos)
7. [No verificado](#7-no-verificado)
8. [Inventario de lo creado y lo borrado](#8-inventario-de-lo-creado-y-lo-borrado)
9. [Pase](#9-pase)

## 1. Definiciones y alias

| Término | Definición en este informe |
| --- | --- |
| **Cláusula** | Afirmación de la metodología que puede ser verdadera o falsa sobre un artefacto: «todo documento tiene `doc_id`», «toda traza resuelve». |
| **Validador** | Programa que lee artefactos y termina con código 0 (verde) o distinto de 0 (rojo). |
| **Compuerta** | Validador al que se le asigna un efecto: **bloquea** (el PR no pasa G3) o **avisa** (rojo informado, sin impedir el merge). |
| **Prueba negativa** | Se planta **un** defecto en un corpus que pasa. El validador debe dar rojo con el defecto y verde sin él. Una sola variable por corrida (`R01:277`). |
| **Línea de base** | Cuántos rojos da un validador sobre el corpus real de hoy. Mide el costo de adoptarlo y sus falsos positivos. |
| **Determinista** | Mismo insumo, mismo resultado, sin red ni reloj. |
| **Escalón / compuerta de escalón** | E1, E2 y E3 de la decisión D1 (`EXP0002-F001`, fila D1). La compuerta de escalón es el dictamen que habilita el escalón siguiente. Es distinta de la compuerta de CI. |
| **Ancla de versión** | Identificador del commit del código que la documentación declara describir. |

Alias de cita (como en los folios 001–004): `TP` es el tool-prompt. `N0n`, `R0n`, `I0n` y `C00` son las bitácoras de fase 1 en `/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/DEVs/Enchacement/01-Replanteo-Y-Analisis/OUTPUTs/Bitacoras/`. `GUIA` es `/LAB/Lab-Documentos/Lab-Documentos/Guides/Documentacion-Tecnica/Sistema-De-Documentacion-E-Integracion/Sistema-Documentador-Tecnico-Guide.md`. `KPRA` es `KB-privada/Knowledges/Knowledge-Conformacion-Pull-Request-Automatico.md`. Los ensayos `E01`…`E10` están en `../evidencia/C-VERIFICACION/` y las herramientas en `../evidencia/C-VERIFICACION/herramientas/`.

## 2. Resumen de dictámenes

| Q | Dictamen (una línea) | Ensayo que lo sostiene |
| --- | --- | --- |
| Q02 | **Sí.** La unidad U0 asienta la delegación y crea el control `Verificar` en `[self-hosted, i7infra-dev]`. Lo acepta una prueba negativa en el propio PR. Su merge vuelve al PO. | E04, E09 |
| Q04 | **SHA del código indexado** como ancla obligatoria. El tag es un alias legible, sólo donde existe. Se descarta «ninguna». | E09 |
| Q06 | **Las dos cosas, separadas por determinismo.** En el PR: enlaces internos más prohibición de rutas relativas que salen del repo. Programado: resolución de citas desde la raíz y entre repos con `--root-dir` sobre el árbol del workspace. | E01, E03, E10 |
| Q14 | Esquema JSON del frontmatter con los 9 campos obligatorios de la carta común, `confidence` si `origin≠human`, y registro cerrado de prefijos. **Dos perfiles de `traces`**: ID@versión para el cuerpo, `alias:línea` para los folios. | E04, E05 |
| Q16 | **Dos controles automáticos.** Filtro de comentarios HTML y caracteres ocultos o bidi sobre lo publicado para agentes, y lista permitida de fuentes MCP. Línea de base 0. | E04, E05 |
| Q23 | Se adoptan CQ-01…14 y PE-01…12 como anexo. **Son automatizables CQ-03, 05, 11, 13 y 14 y PE-03**, con prueba negativa cada uno. Va una tabla de mediciones y una regla de clasificación propuesta. | E04, E05, E06 |
| Q24 | Va **en el runner propio** (`TP:34`), con **grupo de concurrencia propio** que cancela lo viejo, `timeout-minutes: 5` y una suite de 5,25 s. No comparte grupo con la E2E. | E09 |
| Q27 | **Sí para OpenAPI en build** en las ApiWeb, con diff de contrato. **Sí para XML** en ApiWeb/Api, **no** en MAUI. | E07 |
| Q35 | **Copia vendorizada por `git archive`** de IA.SDD en un commit fijo, con MANIFIESTO (sha256) y un aviso programado de deriva. Se descartan el submódulo y la copia de sólo `Rules/`. | E08 |
| Q37 | Cada escalón demuestra **una afirmación nueva con su validador y su prueba negativa**. La tabla está en §3.10. | E06, E07, E08, E09 |
| Q38 | `traces: [ID@versión]`. **Pantallas → `CU-100NN`** (unidad Web). **Reglas → `RN-<UNIDAD>-NN`.** `CU-000NN` sólo para comportamiento de API. Lo verifica `traces-resolve`. | E06 |
| Q40 | **Sí, como unidad U1 previa**, con criterio medido: 8 enlaces rotos reales a 0, traza duplicada a 0, y conservar el defecto plantado del ejemplo. | E01, E05, E10 |
| Q41 | **Paquete de evidencia fijo por compuerta**: corrida verde en el SHA, corrida roja con defecto plantado y tabla de criterios fijada antes. Va **en este expediente**. Lo del SDD-B entra redactado. | E04 |
| Q44 | **Sí.** APA 7 en castellano, siempre con fecha de consulta, y GUIA como piloto. Es medible: 6 URL sin fecha y 44 citas por dominio que convertir. | E02, E04, E05 |

## 3. Dictámenes por pregunta

### 3.1 Q02 — Unidad de arranque con delegación y control `Verificar`

**Respuesta.** Sí. La fase de escritura del escalón 1 empieza con la unidad **U0 «arranque»**, una por cada repositorio donde se vaya a escribir: Lab-Documentos y Lab-Documentos.Documentacion. U0 contiene sólo:

- el asiento de la delegación del merge (CHANGELOG y README);
- `.github/workflows/verificar.yml` con un job `Verificar` en `runs-on: [self-hosted, i7infra-dev]`, guarda de forks y `timeout-minutes`;
- la suite de §4 en su forma mínima: enlaces, esquema, ocultos y mermaid.

**Criterio de aceptación de U0** (todo medible en el propio PR):

1. El check `Verificar` aparece en el `head.sha` del PR y termina en `success` (G3, `KPRA:128`).
2. Un commit de prueba en la misma rama que planta un enlace roto deja `Verificar` en `failure`. Revertirlo lo vuelve a `success`. Ese par de corridas queda citado en el informe del PR.
3. **El merge de U0 lo hace el PO.** La delegación todavía no está en la rama principal: el ciclo automático «sólo vale si la delegación del merge está asentada» (`KPRA:27`, `KPRA:92`).

**Alternativas consideradas.** (a) Escribir primero y agregar los controles después. Se descarta: cada PR sin controles cae en G3 «Ninguna: reserva» (`KPRA:128`) y fuerza el ciclo manual (`R01:490`). (b) Un solo PR que trae la delegación y también trabajo de fondo. Se descarta porque mezcla dos variables: si `Verificar` falla, no se sabe si falla el control o el contenido.

**Fundamento.** `Lab-Documentos.Documentacion` no tiene `.github/` (E09: `ls … → No existe`; `C00` fila 28). No hay delegación asentada en ningún repo (`R01:643`, H-06). La suite completa corre en 5,25 s (E09) y cada validador ya tiene prueba negativa (E04).

**Ventajas.** Simplicidad: un PR chico con una sola variable. Practicidad: el resto del escalón ya puede usar el ciclo automático. Escalabilidad: U0 es la plantilla que repiten E2 y E3 en sus repos.

**Riesgos.** El runner es único: si está ocupado por la E2E, `Verificar` espera (ver Q24). Un repo público con runner propio necesita la guarda de forks (`R06:141`, R5 en `R06:247`).

### 3.2 Q04 — Ancla de versión por par código ↔ `.Documentacion`

**Respuesta.** El ancla obligatoria es el **SHA completo del repositorio de código**. Se escribe en un campo `source: {repo, commit}`, sea en el índice de la ia-db, sea en el frontmatter de cada pieza que describe código. Cuando el repo de código publica versiones (Lab-Geometria con MinVer), se agrega `tag` como alias legible, y el validador comprueba que el tag apunta al mismo SHA. Se descarta la opción «ninguna».

**Cómo se prueba.**

- **Existencia:** `git rev-parse --verify -q '<sha>^{commit}'`. Da 0 si existe y 1 si no (E09: `v1.2.0` da 0, `v9.9.9` da 1).
- **Pertenencia:** `git merge-base --is-ancestor <sha> origin/main`. Da 0 si el SHA es ancestro y 128 si es inexistente (E09).
- **Desfase:** `git diff --stat <sha>..origin/main -- <rutas documentadas>`. Una salida no vacía significa que la doc describe un código que cambió. Esta medición es la que pide `TP:20` (c).

**Alternativas.** (a) Sólo el tag del código. Hoy es impracticable: Lab-Documentos, Lab-Documentos.Documentacion y Lab-E2E.WebBlazor tienen **0 tags** y sólo Lab-Geometria los tiene (E09). (b) Ninguna ancla («follows», `I02:123-125`). No deja ninguna cláusula verificable, y entonces el desfase de `TP:20` (c) no se puede detectar.

**Ventajas.** El SHA existe siempre, no depende de la política de releases y se verifica con git sin red. El tag queda opcional, así que la regla escala a los repos sin releases.

**Riesgos.** Un rebase o un force-push en la rama del código deja huérfano un SHA anclado. La prueba de pertenencia lo detecta. Clasificar ese rojo como bloqueo o aviso es propuesta a C-DECISIONES; esta comisión propone **bloqueo para existencia** y **aviso para desfase**, porque el desfase es esperable entre releases.

### 3.3 Q06 — Enlaces rotos entre repositorios

**Respuesta.** Dos mecanismos, separados por determinismo:

1. **En cada PR (determinista, sin red):**
   - `lychee --offline --include-fragments` sobre el repo, que cubre enlaces relativos internos y anclas;
   - una regla que **prohíbe enlaces relativos que salen del repositorio** (`../` por encima de la raíz del repo).

   Hacia otros repos, el texto usa la cita desde la raíz del workspace (D6) o un permalink con SHA.
2. **Programado (aviso, diario):** un job en el runner, donde están los repos hermanos, que corre `lychee --offline --root-dir <raíz del workspace>` sobre todos los `.md`. Además resuelve los permalinks por HTTP.

**Fundamento medido.**

- En un checkout aislado de Lab-E2E.WebBlazor.Documentacion hay **3 destinos que resuelven sólo con el repo hermano al lado** y **29 rotos en ambos casos**, porque la ruta relativa supone una topología que ya no existe (E03). La ruta relativa entre repos es frágil por diseño.
- La cita desde la raíz (`/IA/...`) **no resuelve** en un checkout («Cannot resolve root-relative link … provide a root dir», E03).
- **Resuelve con `--root-dir`** cuando el árbol del workspace está montado: 26 errores pasan a 25 y desaparece ese error. La prueba negativa da `ok` 0 y `roto` 2. **Sin el workspace, un enlace bueno da 2** (E10). Por eso esa resolución no puede bloquear en un checkout de CI: tiene que ser programada, o correr donde está el árbol.

**Alternativas.** (a) Sólo la compuerta en el PR. Da falsos rojos para toda cita D6 en un checkout (E10). (b) Sólo el aviso programado. Deja pasar los rotos internos, que son baratos y deterministas (0,78 s, E09).

**Ventajas.** El PR queda rápido y sin falsos positivos. Lo que depende de la topología se mide donde la topología existe.

**Riesgos.** El aviso programado se puede ignorar. Mitigación propuesta: el job abre o actualiza un issue único por repo. El costo de mantener el runner al día con los repos hermanos (`git fetch` previo) está **no verificado** (§7).

### 3.4 Q14 — Frontmatter y prefijos de ID

**Respuesta.** Un esquema JSON (`herramientas/cuerpo.schema.json`), validado con `remark-lint-frontmatter-schema` en modo `--frail`:

- **Obligatorios:** `doc_id`, `doc_type`, `title`, `status`, `origin`, `owner`, `last_review`, `audience` y `traces`. Son los de la carta común.
- **Condicional:** `confidence` es obligatorio si `origin` es `agent` o `mixed`, lo que cubre CQ-14 como metadato.
- `status` va en {draft, review, vigente, superseded, deprecated}.
- `last_review` con formato `AAAA-MM-DD`.
- `traces` con `uniqueItems`.

Patrón de `doc_id`: `^[A-Z][A-Z0-9]*(-[A-Z0-9]+)+$`. **Registro cerrado de prefijos**, en un archivo `ids.yml` del cuerpo, que el validador también contrasta:

| Prefijo | Para |
| --- | --- |
| `GUIA-` | documento del cuerpo de una guía |
| `NUC-` | documento de núcleo |
| `EXP<nnnn>-F<nnn>` | folio de expediente |
| `DOC-` | ya en uso (`GUIA:2`, `DOC-SDT-0001`) |
| `CU-`, `RN-` | trazas a especificación (ver Q38) |
| `ADR-` | decisiones de arquitectura |

**Dos perfiles de `traces`**, hallazgo de este ensayo:

- el **cuerpo** traza a IDs (`CU-10005@1.2`);
- los **folios** de este expediente trazan a `alias:línea` (`TP:18`, `R01:227-262`; `EXP0002-F004`, frontmatter).

El patrón de IDs del esquema rechazaría los folios. Por eso el esquema se selecciona por `doc_type` (`informe`, `providencia`… frente a `study-note`, `guia`…), o `traces` acepta las dos formas.

**Prueba.** E04, variante v2 (sin `doc_id`): esquema en 1, el resto en 0. El corpus limpio queda en 0. Línea de base sobre GUIA (E05): **1 aviso real**, `traces` con `DOC-ADR` duplicado (`GUIA:11`).

**Alternativas.** (a) Seguir sin esquema (hoy el Profile no lo define, `R07:366`). No se puede verificar CQ-13. (b) `check-jsonschema` sobre frontmatter extraído. Es equivalente, pero suma un paso de extracción. Se prefiere remark, que ya parsea Markdown para mermaid y lint.

**Ventajas.** Un solo archivo de contrato que leen humanos, agentes y CI. El costo de adopción es medido y casi nulo (1 aviso).

**Riesgos.** Un registro de prefijos sin dueño crece sin control. Propuesta: que lo cambie sólo un PR que toque `ids.yml`, con revisión.

### 3.5 Q16 — Controles contra inyección indirecta

**Respuesta.** Se exigen dos controles, los dos automáticos:

1. **Filtro de contenido oculto** (`herramientas/ocultos.mjs`). Da rojo si en lo que se publica para agentes (`.md` por página, `llms.txt`) aparece cualquiera de estos:
   - un comentario HTML;
   - un carácter de ancho cero (U+200B…U+200D, U+2060, U+FEFF);
   - un control bidireccional (U+202A…U+202E, U+2066…U+2069);
   - una etiqueta Unicode (U+E0000…U+E007F).

   En las **fuentes** se admite una lista permitida de comentarios de herramienta (`<!-- markdownlint-… -->`) y el build los quita antes de publicar.
2. **Lista permitida de fuentes MCP y externas**: un archivo declarativo. Toda cita a una fuente externa lleva URL y fecha de consulta (lo verifica `url-fecha`, Q44). Responde a R19 y R20 de `I03:290-291`.

**Prueba.** E04, variante v4 (comentario HTML con instrucción más carácter de ancho cero): `ocultos` en 1, el resto en 0. **Línea de base 0** en GUIA, Examples/ y las bitácoras, y 0 en los folios 001–004 (E05). Bloquear no cuesta nada hoy.

**Alternativas.** (a) Marcar en vez de filtrar (R19 lo admite). Un agente igual lee la marca. Filtrar es más simple de verificar: la cuenta es 0 o no es 0. (b) Revisión humana sola. No escala y no es reproducible.

**Ventajas.** Determinista, sin red, con una línea de base nula. Cubre el escenario de OWASP LLM01:2025 que verificó `C00` (fila 34).

**Riesgos.** No detecta instrucciones en texto visible: eso es R18, tratar el contenido como datos no confiables (`I03:289`), y es cuestión de diseño del agente, no de la compuerta. Lo declaro como límite del control.

### 3.6 Q23 — Qué bloquea, qué avisa, y CQ/PE como compuertas

**Respuesta.** Se adoptan **CQ-01…CQ-14 y PE-01…PE-12 como anexo** de listas de verificación de la guía. **Son automatizables con prueba negativa:**

| Criterio | Validador | Prueba negativa (E04/E06) | Línea de base hoy (E05) | Determinista | Costo |
| --- | --- | --- | --- | --- | --- |
| CQ-03 Actualidad | `traces-resolve.sh` + `cita-linea.mjs` + lychee | desfase y traza inexistente en 1; v3 en 1; v1 en 2 | trazas de Examples **9/9 rojas** (E06); citas sin línea: 1 en GUIA, 27/44 en bitácoras, 19/19 en folios | sí | <1 s |
| CQ-05 Encontrabilidad | lychee `--include-fragments` + markdownlint MD001 | v6 ancla en 2; v7 salto de nivel en 1 | 8 enlaces reales rotos en GUIA (E10); 2 hallazgos de lint con la configuración ajustada | sí | 0,78 s |
| CQ-11 Trazabilidad de fuentes | `url-fecha.mjs` + `cita-linea.mjs` | v5 en 1; v3 en 1 | GUIA 6/6 URL sin fecha; bitácoras 225/227 | sí | <1 s |
| CQ-13 Doble audiencia | esquema de frontmatter + `mermaid-parse.mjs` | v2 en 1; v8 en 1 | 1 aviso (traza duplicada); **1 mermaid inválido real**, `I03:210` | sí | ~2 s |
| CQ-14 Revisión según origen | esquema (`confidence` si `origin≠human`) | variante de v2 | 0 | sí (sólo metadato) | — |
| PE-03 Ejemplo con procedencia | diff de la salida generada (`git diff --exit-code`) | E07: cambio de ruta en 1, revertido en 0 | — | sí | 15,8 s (build) |

No son automatizables: CQ-02, 04, 08 y 09, y PE-09 (*play testing*). Corresponden a C-LECTOR y a la revisión humana (`I05:231`).

**Regla de clasificación propuesta a C-DECISIONES y la presidencia** (esta comisión no la decide). Un validador **bloquea** sólo si cumple las cuatro condiciones:

1. es determinista y no usa red;
2. tiene prueba negativa en verde y rojo;
3. su línea de base sobre el corpus que vigila es 0, o llega a 0 dentro de U1 (Q40);
4. no da falsos positivos conocidos.

Si falla alguna, **avisa**. Aplicada a las mediciones:

- **Bloquean desde E1:** enlaces internos, esquema, ocultos, mermaid y lint estructural.
- **Avisan:** enlaces externos y entre repos (Q06), y `url-fecha` y `cita-linea` sobre el corpus heredado. Pasan a bloquear en los documentos nuevos del cuerpo cuando la conversión de Q44 deje su línea de base en 0.
- **MD013 (largo de línea) se apaga:** son 332 de los 349 hallazgos por defecto (E05), y tiene costo sin beneficio para el lector.

**Alternativas.** (a) Bloquear todo desde el día 1. Hoy daría rojo por 225 URL sin fecha que no son de esta corrida. (b) Avisar todo. Una compuerta que no bloquea nada no es compuerta.

**Ventajas.** La regla es mecánica: un validador nuevo se clasifica solo, midiendo, sin otra mesa.

**Riesgos.** La lista de excepciones (como el respaldo de cultura, E10 §2) tiene que ser explícita. Si no, el equipo se acostumbra al rojo.

### 3.7 Q24 — Concurrencia con la E2E en el único runner

**Respuesta.** Todo en el runner propio, como fija `TP:34` (decisión 1 de la presidencia). El workflow documental lleva:

- `concurrency: { group: docs-${{ github.workflow }}-${{ github.ref }}, cancel-in-progress: true }`;
- `timeout-minutes: 5`;
- la suite liviana de §4.

**No** usa el grupo `e2e-laboratorio`.

**Fundamento.**

- La E2E de Lab-Geometria usa `concurrency: group: e2e-laboratorio, cancel-in-progress: false` (E09, `e2e.yml:59-61`).
- Según GitHub, el grupo de concurrencia tiene **alcance de repositorio** («another job or workflow using the same concurrency group in the repository», consultado el 2026-10-26, E09). Compartir el nombre de grupo entre repos no serializa nada.
- La serialización real entre repos la impone el runner, que es uno solo (`R06:143`) y ejecuta un job por vez. Esto último es comportamiento general de los runners self-hosted y no se midió en esta corrida.
- Un grupo propio con cancelación descarta las corridas viejas del mismo PR, así que la cola no crece por pushes sucesivos.
- La suite tarda **5,25 s** (E09). Ocupa al runner un tiempo despreciable frente a una E2E.

**Alternativas.** (a) Validaciones en `ubuntu-latest`. Contradice `TP:34` y la decisión 1. (b) Compartir `e2e-laboratorio`. Pondría la doc detrás de cada E2E pendiente, sin cancelar.

**Ventajas.** No compite con la E2E en grupos y su costo está medido. La regla escala: cada repo instancia el mismo bloque.

**Riesgos.** Si una E2E ocupa el runner, `Verificar` espera en cola. La espera máxima depende de la duración de la E2E, que está **no verificada** (§7). `timeout-minutes` limita la ejecución, no la espera en cola.

### 3.8 Q27 — OpenAPI y XML en build

**Respuesta.** **Sí, OpenAPI en build** en las ApiWeb de los escalones (MovilidadUrbana.ApiWeb en E1, GeometriaFactory.Api en E2):

- `Microsoft.Extensions.ApiDescription.Server` con `PrivateAssets=all` y `OpenApiDocumentsDirectory`;
- el JSON se versiona;
- la compuerta de contrato es `git diff --exit-code -- '*/openapi/*.json'` después del build.

**XML docs (`GenerateDocumentationFile`) sí en ApiWeb y Api**, porque OpenAPI toma los `summary` de ahí, y **no en MAUI**: compilar MAUI exige el workload android (`R05:189`).

**Prueba (E07).**

- `dotnet build -c Release -warnaserror` termina en **0 advertencias y 0 errores** (14,1 s) y emite `openapi/MovilidadUrbana.ApiWeb.json` (16 883 bytes, OpenAPI 3.1.1, 8 operaciones).
- **Prueba negativa:** cambiar `[HttpPost]` por `[HttpPost("alta")]` da un diff de 98 líneas y `exit=1`. Revertir da `exit=0`, así que **la salida es determinista**.

**Hallazgo.** `X-Sesion-Id presente: False` (E07), igual que H3 en `R05:268`. El diff de contrato **no** detecta lo que el contrato nunca declaró. Hace falta una aserción explícita, por ejemplo una prueba que lea el JSON y exija el parámetro de cabecera.

**Alternativas.** (a) Seguir con el OpenAPI de runtime (`I02:334`). Sin artefacto versionado no hay diff ni compuerta. (b) Swashbuckle CLI. Suma una herramienta, y el paquete oficial ya funciona en net10 (E07).

**Ventajas.** Una fuente generada reduce la deriva entre código y referencia. Hay compuerta con prueba negativa, y el costo de build está medido (15,8 s con caché fría, E09).

**Riesgos.** En Lab-Geometria hoy `GenerateDocumentationFile=false` (`I02:333`). Encenderlo con `-warnaserror` puede producir CS1591 en masa, y eso está **no verificado** (§7). Propuesta: encenderlo con `NoWarn` de CS1591 al principio y medir.

### 3.9 Q35 — Dependencia no vendorizada de IA.SDD en el SDD-B

**Respuesta.** Una **copia vendorizada por `git archive`** de IA.SDD en un commit fijo (`SDD/`, `Templates/`, `Conocimiento/` y `README.md`), con un `MANIFIESTO` que registra origen, commit y sha256 por archivo, y un **aviso programado de deriva** (`deriva-vendor.sh`) contra el upstream. Las citas del SDD-B pasan de «nombre de archivo y §» a **ruta más versión** dentro de la copia.

**Prueba (E08).** Se probaron tres alternativas, cambiando una sola variable: cómo llega la dependencia.

| Alternativa | Resultado |
| --- | --- |
| A, submódulo | 0/14 nombres resueltos sin `--recurse-submodules`; 14/14 con él; 21 MB en `.git/modules` |
| B, sólo `SDD/Devs/Rules` | 14/14, pero el cierre de dependencias falla: 15 o más de las 36 referencias internas caen fuera |
| C, `git archive` | 125 archivos, 3,6 MB; **14/14 sin red**; cierre 27/36, con las 9 restantes explicadas (7 son artefactos del proyecto destino y 2 plantillas que tampoco existen upstream, `Rules-Plan-Sprint.md:59`, `:174`) |

Prueba negativa de la deriva: verde con `exit=0`. Después de tocar `Root-Rules.md`: «DERIVA … Root-Rules.md» con `exit=1`.

**Hallazgo.** `Root-Rules.md` tiene **73 homónimos** en IA.SDD (1 vigente y 72 en `_legacy/`). Una cita por nombre es ambigua aun con IA.SDD al lado (E08 §2). Por eso la cita tiene que llevar la ruta.

**Alternativas.** Además de A y B: un permalink HTTP. IA.SDD es público (API `private=false`, HTTP 200, E08). Sirve como **forma de cita**, no como dependencia de operación: un agente sin red no la resuelve.

**Ventajas.** Un clon limpio funciona solo, la deriva queda medida, y la copia sólo se actualiza con un PR que cambia el MANIFIESTO.

**Riesgos.** Son 3,6 MB de copia. El aviso de deriva puede ignorarse. La copia tiene que actualizarse con el escalón 3 (mejora de orquestadores), si no queda vieja de entrada.

### 3.10 Q37 — Qué demuestra cada escalón que el anterior no demostró

**Respuesta.** Se acepta la propuesta de `N07:139`. Cada escalón se formula como **afirmación verificable más validador más prueba negativa**:

| Escalón | Afirmación nueva | Cómo se prueba | Prueba negativa | Estado medido hoy |
| --- | --- | --- | --- | --- |
| E0 (PoC existente) | Roles y confidencialidad en el servidor | `curl` sin rol da `401`; una página de otro rol da `404` | Validador de la consola: 3 fallas plantadas o halladas, `exit=1` (`Examples/Prueba-Ayuda-Por-Rol/README.md:55-61`) | `401` verificado (`C00` fila 26) |
| E1 MovilidadUrbana.MAUI + CI | Audiencias, **fuente generada** y cliente sin servidor; **suite en el runner** | OpenAPI en build con diff (Q27); `Verificar` verde en el SHA | E07 (98 líneas, `exit=1`); E04 (8 variantes, cada una roja en su validador) | build y diff verificados en una copia; el workflow todavía no existe |
| E2 piloto Geometría | Integración con un **SDD real** y su CI | `traces-resolve.sh` en `exit=0` sobre la ayuda contra `SDD/` de Lab-Geometria | Traza desfasada e inexistente en `exit=1` (E06) | **9/9 trazas rojas hoy** (unidad Api, no pantalla, E06): E2 no pasa sin Q38 |
| E3 SDD-B | **Dos repos y versionado de varias piezas** | ancla SHA (Q04), deriva del vendor (Q35), enlaces entre repos (Q06) | `v9.9.9` en 1, SHA inexistente en 128 (E09); deriva en 1 (E08); enlace roto desde la raíz en 2 (E10) | mecanismos probados sobre copias; nada aplicado |

**Alternativas.** Que los escalones demuestren «más volumen» del mismo tipo. Se descarta: no da criterio para la compuerta.

**Ventajas.** Cada compuerta tiene una afirmación nueva y una herramienta ya probada, así que el dictamen sale sin «depende».

**Riesgos.** E1 no demuestra roles (X6, `R05:266`). La tabla lo hace explícito: los roles se demostraron en E0.

### 3.11 Q38 — Contrato de `traces`

**Respuesta.** El contrato es `traces: [<ID>@<MAJOR.MINOR>]`:

- una **página de ayuda de pantalla** traza a **`CU-100NN`**, de la unidad Web;
- una **regla** traza a **`RN-<UNIDAD>-NN`**, por ejemplo `RN-LOC-01` en MovilidadUrbana;
- **`CU-000NN`** traza sólo comportamiento de API.

El validador `traces-resolve.sh` comprueba tres cosas:

1. el ID existe **una sola vez** fuera de `_legacy/`;
2. la versión coincide con la cabecera `**Versión:**` del CU;
3. una página de ayuda de pantalla traza a la unidad de pantalla.

**Prueba (E06).** Sobre la ayuda de Examples/ contra Lab-Geometria `4b114d7`: **9 de 9 trazas en rojo**, por «unidad no es de pantalla» (`CU-00022`…`CU-00029` son de la unidad Api, igual que X7 y `R06:193`). Sobre una página sintética: `CU-10005@1.2` da 0, `@0.9` da 1 y `CU-19999` da 1.

**Para MovilidadUrbana**, que no tiene IDs (`R05:272`, H7): asignar `RN-LOC-01`… en lugar de trazar a `ruta:constante`. La forma `ruta:constante` se verifica con `grep`, pero se rompe con un renombre y no tiene versión. El ID con versión se resuelve igual en los dos sistemas.

**Alternativas.** (a) Mantener `CU-000NN` para pantallas. El validador lo rechaza, y con razón. (b) Trazar sin versión. Entonces no se detecta frescura (CQ-03).

**Ventajas.** Un solo validador sirve para E1, E2 y E3, y el contrato se lee igual en humanos y agentes.

**Riesgos.** Asignar `RN-` en MovilidadUrbana es trabajo en un repo de código que no es de esta comisión. La decisión de hacerlo es de C-ARQ-NET o de la presidencia.

### 3.12 Q40 — Deuda inmediata como unidad separada

**Respuesta.** Sí: la unidad **U1 «saneamiento»** va después de U0 y antes del enriquecimiento. Criterio de aceptación medido:

| Ítem | Hoy (medido) | Aceptación |
| --- | --- | --- |
| Enlaces de GUIA hacia `../Documentacion-Tecnica/…` | **8 rotos** (E01; líneas 189, 203×3, 432, 590, 625, 633) | `lychee --offline` en 0 sobre GUIA |
| Rotos de Examples/ | 3, pero **no son deuda**: 1 está plantado a propósito (`README.md:59`) y 2 son respaldo de cultura (`GUIA:455`) (E10) | Se conservan. El defecto plantado queda en la lista de exclusiones de lychee con su motivo. Los de respaldo se excluyen o el validador del catálogo los contempla |
| Traza duplicada `DOC-ADR` | 1 (`GUIA:11`, E05) | esquema sin avisos |
| Lint estructural | 2 (MD032 en `Lanzar-Example.md:4`, MD028 en `GUIA:87`) | 0 |
| URL sin fecha en GUIA | 6/6 (E05) | 0 (se cruza con Q44) |
| Recuento, `translation_of`, ACT-10, `$P`, devcontainer, `302`/`401` | Listados en `R02:339-343`; esta comisión no los midió (§7) | cada uno con su verificación en el PR de U1 |

**Fundamento.** La deuda no depende de las decisiones de la mesa (`N00:243`). Sin U1, la línea de base de los validadores de §4 no es 0, y por la regla de Q23 no podrían bloquear.

**Alternativas.** Corregir la deuda dentro del enriquecimiento. Mezcla variables: un rojo no dice si viene de la deuda o de lo nuevo.

**Ventajas.** Al terminar U1, toda la suite puede bloquear sobre GUIA.

**Riesgos.** Que U1 «corrija» el defecto plantado del ejemplo y rompa la demostración del validador. El criterio de aceptación lo prohíbe expresamente.

### 3.13 Q41 — Evidencia, ensayos y criterio en cada compuerta de escalón

**Respuesta.** Cada compuerta de escalón (E1, E2, E3) se dictamina **en este expediente (0002)**, en un folio `informe` por escalón, con un **paquete de evidencia fijo**:

1. La **tabla de criterios de aceptación** del escalón, foliada **antes** de construir (la de §3.10, más los umbrales de Q40 y Q23).
2. Una **corrida verde** del workflow en el SHA del merge, citada con URL de la corrida y SHA.
3. Una **corrida roja** con un defecto plantado por validador (V3, `N07:152`), en una rama de prueba que no se fusiona, citada igual.
4. Los ensayos locales en formato `E0n` (comando, salida recortada, fecha y quién), como en `../evidencia/C-VERIFICACION/`.
5. El **barrido S2**: `grep` sin ruta del host en lo versionable (D6).

**Criterio de paso.** Todos los criterios del punto 1 en verde, y cada validador con su par rojo y verde. Si falta un par, el veredicto es `INSUFICIENTE`, no `PROCEDE`.

**Dónde vive cada cosa.** El dictamen va en 0002, porque D1 es un único alcance escalonado de esta corrida. Los artefactos de CI quedan en el repo del escalón. Del **SDD-B (privado)** se cita sólo el SHA y el nombre del check, sin URL ni nombre del repo. Las salidas quedan en `evidencia/local/`, como se hizo con E08.

**Alternativas.** (a) Un expediente propio por repo de escalón. Fragmenta el dictamen de un mismo D1, aunque se justifica si el escalón abre un cambio de norma en ese repo, por ejemplo una vía normativa del SDD-B. En ese caso se cita calificado desde 0002 (`R01:433-436`). (b) Criterios fijados después de construir. Es lo que `Q41` quiere evitar («sin criterio fijado de antemano, el dictamen sale "depende"»).

**Ventajas.** Es reproducible: cualquiera vuelve a correr el comando citado. Separa lo público de lo privado sin perder la verificabilidad.

**Riesgos.** Las URL de corridas de Actions expiran con la retención del repo. Mitigación: el folio copia la salida recortada en `evidencia/`.

### 3.14 Q44 — APA 7 en castellano con fecha de consulta

**Respuesta.** Sí. APA 7 en castellano, **siempre** con «consultado el AAAA-MM-DD», y **GUIA como piloto** de conversión.

**Por qué es verificable.**

- `url-fecha.mjs` da rojo ante toda URL fuera de un bloque de código que no tenga fecha en la línea (E04 v5: 1; corpus limpio: 0).
- Línea de base de GUIA: **6 URL, las 6 sin fecha**, más **44 citas por dominio dentro de code spans** (``docusaurus.io/…``) que `url-fecha` no ve (E02).

**Por lo tanto el validador tiene que ampliarse** para detectar dominios desnudos en citas. Si no, la conversión de GUIA pasaría verde sin haberse hecho. Queda como trabajo de la suite, no verificado (§7).

**Medición del piloto.** El piloto termina cuando sobre GUIA quedan en 0 las URL sin fecha y las citas por dominio sin referencia completa. En las bitácoras (225/227 sin fecha, E05) el validador **avisa**, porque son de fase 1 y no forman parte del cuerpo.

**Alternativas.** (a) Mantener las citas por dominio. No cumple CQ-11, y GUIA es «la que menos cumple su propio tema» (`I05:352`). (b) Otro estilo, como ISO 690. APA ya es la propuesta de `I05:360` y no hay evidencia a favor de cambiar.

**Ventajas.** Una regla mecánica y medible, que se puede convertir a bloqueo en cuanto la línea de base llega a 0.

**Riesgos.** La fecha de consulta no prueba que la fuente siga diciendo lo mismo. Eso lo cubre el aviso programado de enlaces externos (Q06), no esta compuerta.

## 4. Propuesta de método: la suite de verificación documental

Una **suite única**, la misma en el equipo del autor y en CI, con dos carriles:

```mermaid
flowchart LR
  subgraph PR["Carril PR — job Verificar en self-hosted i7infra-dev, grupo propio, timeout 5 min"]
    A1[lychee --offline<br/>enlaces internos y anclas] --> R{¿algún rojo<br/>que bloquea?}
    A2[esquema frontmatter<br/>+ registro de prefijos] --> R
    A3[ocultos.mjs<br/>HTML, ancho cero, bidi] --> R
    A4[mermaid-parse] --> R
    A5[markdownlint<br/>MD013 off] --> R
    A6[traces-resolve<br/>ID@versión] --> R
    A7[build -warnaserror<br/>+ diff openapi/*.json] --> R
    A8[cita-linea · url-fecha<br/>avisa en corpus heredado] -.aviso.-> S[Resumen del job]
    R -->|no| V[success → G3]
    R -->|sí| F[failure → reserva]
  end
  subgraph CRON["Carril programado — diario, en el runner con los repos hermanos"]
    B1[lychee --root-dir raíz del workspace<br/>citas D6 y entre repos] --> I[issue único por repo]
    B2[lychee con externos<br/>permalinks y URL] --> I
    B3[deriva-vendor.sh<br/>IA.SDD vendorizado] --> I
    B4[desfase de ancla SHA<br/>git diff sha..main] --> I
  end
  N[Prueba negativa por validador<br/>corpus limpio + 1 defecto] -.verifica.-> PR
  N -.verifica.-> CRON
```

Principios (criterio propio, sostenido por E04, E05 y E09):

1. **Todo validador nace con su prueba negativa** en un corpus mínimo versionado junto a la suite (`herramientas/` de este ensayo es el prototipo). Un validador sin rojo demostrado no entra.
2. **La clasificación se mide** con la regla de Q23. No se debate.
3. **Costo acotado**: la suite del carril PR tarda 5,25 s (sin build) y el build con OpenAPI 15,8 s (E09). No compite con la E2E.
4. **Equivalencia local**: el mismo comando en contenedor (`lycheeverse/lychee:0.24.2`, `node:24`, `mcr.microsoft.com/dotnet/sdk:10.0`), con versiones fijadas.

## 5. Ensayos corridos

Todos en contenedores `--rm`, con intermedios en la carpeta de trabajo de la comisión (§8). Las salidas recortadas están en `../evidencia/C-VERIFICACION/`.

| Id | Qué | Comando (resumen) | Resultado |
| --- | --- | --- | --- |
| E01 | lychee offline sobre GUIA y Examples/ | `lychee:0.24.2 --offline --include-fragments "…/**/*.md"` | 27 enlaces, 11 errores, exit 2 (8 reales, ver E10) |
| E02 | lychee con externos | igual sin `--offline` | 1,9 s; 11 errores, todos locales; 1 URL extraída, 44 citas por dominio |
| E03 | Enlaces entre repos: checkout aislado frente al workspace | montar el repo o `LAB/` | 33 frente a 30 errores; 3 resuelven sólo con el hermano; 29 rotos en ambos |
| E04 | Matriz de pruebas negativas | 8 variantes de un defecto × 7 validadores | diagonal roja, resto verde; limpio en 0 |
| E05 | Línea de base sobre el corpus real | los 7 validadores | MD013 332; 1 traza duplicada; 1 mermaid inválido en `I03:210`; ocultos 0 |
| E06 | Trazas contra Lab-Geometria `4b114d7` | `traces-resolve.sh` | 9/9 rojas; negativas 0/1/1 |
| E07 | OpenAPI en build (copia de MovilidadUrbana.ApiWeb) | `dotnet build -warnaserror` + `git diff --exit-code` | 0 advertencias; 8 operaciones; negativa en 1, revertida en 0 |
| E08 | Vendor de IA.SDD en un clon limpio del SDD-B | alternativas A, B y C | C: 14/14 sin red; deriva en 1 al tocar |
| E09 | Anclas, concurrencia y costo | `git rev-parse`, `merge-base`; GitHub Docs | 0/1, 0/128; grupo por repo; suite 5,25 s |
| E10 | `--root-dir` y falsos positivos | lychee con y sin `--root-dir` | ok 0, roto 2, sin workspace 2; 3 rotos de Examples/ explicados |

## 6. Excepciones a conocimientos

| Conocimiento y § | Qué se propone en su lugar | Impacto operativo |
| --- | --- | --- |
| `KPRA` §3.1 (`KPRA:27`, `:92`): el ciclo automático exige la delegación asentada | **No es excepción.** U0 (Q02) la asienta y su merge vuelve al PO, como manda la regla | Ninguno: se declara para que nadie lea U0 como un salto del §3.1 |
| Cita «por nombre de archivo y §» en la norma del SDD-B (`_convenciones_comunes.md:74-75` del SDD-B, E08 §1) | Cita con **ruta y versión** dentro de la copia vendorizada (Q35) | Hay que reescribir las citas de 14 nombres de reglas (de 202 a 2 apariciones por nombre, E08 §1). Pasa por vía normativa del SDD-B en E3; esta comisión no la decide |
| Profile `Study-Guide-Documentation` (sin frontmatter definido, `R07:366`) | Esquema de Q14 como **complemento**, no como cambio del Profile | Ninguno sobre el Profile. Si el PO quiere incorporarlo, va como propuesta al dueño (`I05:361`) |

No se detectó otro apartamiento de KB-privada, IA.SDD/Conocimiento ni de los Conocimientos del SDD-B.

## 7. No verificado

| Afirmación | Motivo |
| --- | --- |
| Espera en cola de `Verificar` cuando la E2E ocupa el runner (Q24) | No se midió la duración de una E2E de Lab-Geometria. Se mide en E1 con la primera corrida concurrente |
| Costo de mantener los repos hermanos al día en el runner para el carril programado (Q06) | No se probó un `git fetch` programado en el runner, para no tocar el runner compartido en esta fase |
| Cuántas CS1591 produce `GenerateDocumentationFile=true` con `-warnaserror` en Lab-Geometria (Q27) | El ensayo E07 se hizo en MovilidadUrbana; Geometría no se compiló |
| Ítems de Q40 que no son enlaces ni frontmatter (recuento, `translation_of`, ACT-10, `$P`, devcontainer, `302`/`401`) | Están en `R02:339-343`; esta comisión no los volvió a medir |
| Detección de citas por dominio desnudo en `url-fecha` (Q44) | El validador del ensayo sólo detecta `http(s)://`; la ampliación no se escribió |
| Comportamiento de la guarda de forks del workflow nuevo | No hay workflow todavía; se replica `e2e.yml:70-76` en U0 y se prueba allí |

## 8. Inventario de lo creado y lo borrado

**Creado y conservado** (versionable, sin rutas del host; barrido S2 con `grep` de la ruta del host y del usuario: sin coincidencias):

- `../evidencia/C-VERIFICACION/E01`…`E10` (10 archivos).
- `../evidencia/C-VERIFICACION/herramientas/`: `cuerpo.schema.json`, `ayuda.schema.json`, `cita-linea.mjs`, `ocultos.mjs`, `url-fecha.mjs`, `mermaid-parse.mjs`, `traces-resolve.sh`, `deriva-vendor.sh`, `fm.sh`, `remarkrc.json` y `markdownlint-cli2.jsonc`. Son prototipos de la suite de §4.
- Este folio.

**Creado en la carpeta de intermedios de la comisión** (fuera del workspace, `…/docascode/C-VERIFICACION/`, 1,3 GB) y **borrado al terminar**:

- `corpus/`: copias de GUIA y Examples/, corpus mínimo y variantes.
- `tools/`: `node_modules` de remark, markdownlint, mermaid y jsdom.
- `q27/`: copia de MovilidadUrbana.ApiWeb con el cambio de `.csproj`.
- `q35/`: clon del SDD-B y alternativas A, B y C.
- `rootdir/`: archivos sintéticos de E10.
- `dockercfg/` y salidas `*.txt`.

**Contenedores:** todos `--rm`. No queda ninguno de esta comisión (`docker ps -a` sin contenedores lychee, node ni sdk).

**Imagen** `lycheeverse/lychee:0.24.2`: queda en la caché local de Docker. No se puede determinar si la descargó esta comisión, y la necesita la suite de E1. Se deja y se declara.

No se tocó ningún repo, no hubo commits, push ni PR, y no se escribió nada en `PROMPTs/` fuera de esta carpeta `OUTPUTs/`.

## 9. Pase

Sigue: análisis de decisiones · presidencia.
