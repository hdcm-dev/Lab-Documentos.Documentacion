| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-10-25 |
| Autor | Jurado de composición (ronda 2) |
| Corrige | — |

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-10-25 |
| Autor | Jurado de composición, ronda 2 (paso 4 de `Mesa-De-Expertos-A-Pedido` §2.1) |
| Corrige | — |
| Norma | `<base de conocimiento>/Knowledges/Knowledge-Mesa-De-Expertos-A-Pedido.md` 3.1 |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | cabecera y §0 (líneas 1–111); §2 (2.1, 2.2 con su subsección, 2.3), §3 (3.1 a 3.4), §4, §7, §8 — fila «Sos el jurado (componés el panel…)» del Mapa de carga |
| Otros documentos cargados | `Mesa` 1.0 (`Rules/Rule-Mesa.md`): §3.4 entera (3.4.1–3.4.5) y §3.5.2 por remisión del paso 4 · `Cadena-De-Consecuencias` 2.0: entero (§0–§10) · `Excepcion-A-Un-Conocimiento` 2.0: §0 a §7 |
| No cargado | `Escalas-De-Juicio` 1.0 (este acto no emite hallazgos ni asigna niveles: usa la lectura P0–P3 del folio 003 para priorizar por severidad esperada) |

# Informe del jurado de composición — ronda 2 del expediente 0001

## Índice

1. [Qué se vota y con qué insumos](#1-qué-se-vota-y-con-qué-insumos)
2. [Formal entra por su señal y ocupa cupo](#2-formal-entra-por-su-señal-y-ocupa-cupo)
3. [Votación por candidato](#3-votación-por-candidato)
4. [Panel resultante](#4-panel-resultante)
5. [Cobertura de P1–P13](#5-cobertura-de-p1p13)
6. [Descartes y postergaciones con motivo](#6-descartes-y-postergaciones-con-motivo)
7. [Mandatos comunes y específicos](#7-mandatos-comunes-y-específicos)

## 1. Qué se vota y con qué insumos

- **Objeto de la ronda:** el dictamen de la ronda 1 (folio 021), con el refutador (019), el análisis (020) y la
  cuenta (022). Clase: **diseño de una norma o decisión** (folio 003): las comisiones de dominio citan fuentes
  externas, no inventan cláusulas y el dictamen responde cada pregunta por separado (§2.2).
- **Señal de la ronda** (folio 022, «Resultado de la ronda 1»): (i) la investigación I0–I7, llegada después de
  cerrarse las comisiones r1; (ii) la sospecha de homogeneidad del jurado r1 (021 §1.1 y §7); (iii) P1 del dictamen
  se aparta de C-min, que recomendaron el refutador (019 §7, fila P1) y el análisis (020 §3, P1, «Recomendación del
  análisis: C-min»).
- **Dato nuevo que pesa en la composición:** la síntesis propone para P1 la opción **C** «motor de encuestas en el
  contenido Blazor actualizable y las encuestas como datos versionados» (I0, «Resumen ejecutivo», «Lo que la síntesis
  propone»; §7, fila P1), que coincide en sustancia con la decisión del jurado r1 (021 §5, P1: «opción A, con la
  definición de la encuesta como datos versionados») y no con C-min. Es **criterio del sintetizador**, no evidencia:
  entra a las comisiones como hipótesis a refutar, no como lectura previa (§2.1, paso 2).
- **Techo:** núcleo + cinco variables o ad hoc (`Mesa` §3.4.5). Empate convoca. El refutador lo despacha la
  presidencia aparte. La composición no se eleva al PO (`Mesa` §3.5.2; §7).
- **No reconvocatoria** (`Mesa` §3.4.5): no alcanza a ningún candidato; todas las comisiones r1 tuvieron hallazgos
  `PROCEDE` (021 §3: entre 11 y 12 cada una).

## 2. Formal entra por su señal y ocupa cupo

`Mesa` §3.4.2: «El rol formal es de convocatoria automática: si su señal aparece, entra sin votación». La señal está
en el objeto de esta ronda, con ubicación:

- 021:328 «**Umbral: ≤ 5 000 ms.**» (TTFD, criterio del jurado anclado en Android vitals);
- 021:401 retención «Servidor: N ≥ 3 artefactos del release (inv. 10). Teléfono: `current` + `previous`»;
- 021:409 «Espera al abrir | **N = 0**»;
- 021:645 rango del puente «con techo (P3)»;
- 021:957, fila «Formal en el ciclo 2»: «La condición de `JUR` para Formal se cumple si hay otra ronda»; y la
  solicitud de convocatoria del refutador (019 §5, primera fila), dirigida a «Jurado, ciclo 2»;
- la condición que el jurado de composición r1 dejó escrita (008 §3, fila Formal; §6).

Formal es un rol del catálogo variable, así que **ocupa uno de los cinco cupos**. Con cinco candidatos de la carta
más Formal hay seis señales para cinco cupos: se prioriza por **severidad esperada** (`Mesa` §3.4.5) con la lectura
P0–P3 del folio 003 (líneas 66–70) y se registra la postergada (§6).

| Candidato | Severidad esperada | Por qué |
| --- | --- | --- |
| Seguridad y tiendas | P0 posible | La lectura P0 del contrato nombra «mecanismo que una tienda prohíbe»; I0 §5 deja el WASM descargado NO VERIFICADO e I0 §4 trae Apple 4.7.2 y el riesgo de «hidden features» por capacidades encendidas desde el servidor |
| Arquitectura .NET MAUI | P1 | P1 del dictamen en disputa (folio 022); I7 trae la clave exacta derivada por hash que cambia P3 y P7 |
| Analista y decisiones | P1 | La matriz que decidió P1 fue impugnada (R-15 procede, 021:247) y la síntesis empuja C; I6 trae el login como momento documentado (P4) y el forzado choca con N = 0 |
| Integración y pruebas | P1 | I7 trae una compuerta de CI que falla ante incompatibilidad del contrato (P6, P8): el problema declarado del equipo (EV001:17) |
| Formal | P1 | Un umbral mal leído da lecturas divergentes entre implementadores (P1 del contrato) |
| Académico editor | P2 | Su señal (I0 §7, fila P10; I5 §4.3; I3 §4) mejora los ejemplos de la guía: «un ejemplo pobre» es P2 en la lectura del folio 003 |

## 3. Votación por candidato

| Candidato | Voto | Señal ubicada y fundamento |
| --- | --- | --- |
| Arquitectura .NET MAUI (`arquitecto-maui-hibrido`) | `CONVOCAR` | I4 §3.6 (Blazor WebAssembly dentro de un WebView móvil) y §5; I2 §3.8 («¿Existe algo equivalente para .NET MAUI?»: Shiny.AppDeviceBridge, I0 §1.3 [105][106]); I7 §3.9, §5 (I7:364–366: clave del contrato por hash, «como `fingerprint`»; `minShellVersion` como «la misma idea») y §6 (I7:387, P3: «la clave se deriva del código, no se escribe a mano»; I7:391, P7); I0 §4 (catálogo cerrado de capacidades, HybridWebView Android con permisos del WebView abiertos, `dotnet/maui#25784`). Toca P1 (disputa del folio 022), P3, P7 y P12 |
| Analista de sistemas y decisiones (`analista-sistemas-y-decisiones`) | `CONVOCAR` | I6 §3.1 (login como momento: D365 FS, Salesforce, Oracle, ServiceMax) y §3.3 (P13 en empresariales); I1 §3.3 (datos tomados con versión vieja) y §3.4 (forzado sólo con red); I0 §2 (diagrama con rama «sincronizar primero», marcada criterio del sintetizador) y §3. Más el punto (iii) del folio 022: P1 apartado de 019 y 020, con R-15 procedente sobre la matriz (021:247). Toca P1 (criterios), P4, P5, P13 y el forzado (folio 006) frente a N = 0 (021:409). **Absorbe** la condición de revisión de 008 §2 (comisión separada de criterios): ver §6 |
| Seguridad del canal y tiendas (`seguridad-canal-y-tiendas`) | `CONVOCAR` | I2 §3.5 (firma e integridad) y §3.7 (rechazos y advertencias); I5 §3.5 (rechazos y problemas con las tiendas); I4 §3.5; I0 §5 (Apple 2.5.2, DPLA 3.3.1(B), 4.7, Play: «code that runs in a virtual machine or an interpreter»; WASM NO VERIFICADO; Expo #1865) y I0 §4 (Apple 4.7.2, «hidden features»). Toca P1 (tiendas), P2, P9 y P12. Severidad esperada más alta del ciclo |
| Integración, versionado y pruebas (`devops-integracion-y-pruebas`) | `CONVOCAR` | I7 §6, fila P6 (I7:390: «Compuerta de CI que falla si el contrato nativo cambió sin cambiar la clave (`--fail-on-incompatible`, fingerprint)») e I7:140 (Capgo: «the upload fails with a non-zero exit and nothing is shipped»); I0 §7, filas P6 y P8 (probar contenido N sobre el cascarón mínimo; validación de definiciones contra esquema; regresiones entre service releases de MAUI 10 [114]). Toca P6, P7 y P8 |
| Formal (`formal-umbrales`) | `CONVOCAR` (automática, sin votación; ocupa cupo) | §2 de este folio |
| Académico editor (`academico-editor-didactico`) | `NO_CONVOCAR` en esta ronda: **postergado por techo** | Señal presente: I0 §7, fila P10 («cada regla de la guía con su historia de falla»), I5 §4.3, I3 §4. Es la de menor severidad esperada (P2). Ver §6 |
| Caso de referencia y capacidades (ad hoc en caliente r1, folio 018) | `NO_CONVOCAR` | Su carta se disolvió al foliar. Lo que la investigación trae de su dominio tiene dueño: P12 → arquitectura y seguridad; login y P13 → analista. Una ad hoc sólo entra si una señal no tiene comisión (`Mesa` §3.4.4) |
| Criterios de decisión, comisión separada | `NO_CONVOCAR` | Condición de 008 §2: entra si el refutador tiene un `PROCEDE` sobre «criterios sin fuente o sin peso». R-15 procede (021:247), pero ataca la **evidencia de una celda** («puntuó B sin E02-B y la celda que separaba se apoyaba en el borrador»), no la falta de fuente o de peso de un criterio: la condición, leída por su letra, no se cumple. Lo que R-15 sí pide lo carga el mandato del analista (§7.2) |
| Comisión ad hoc nueva | `NO_CONVOCAR` | Ninguna señal de I0–I7 queda sin comisión (§5). I3 (interfaz definida desde el servidor) la cubren analista (P1, criterios) y arquitectura (P1, técnica) |

## 4. Panel resultante

Núcleo (3, sin el refutador) + 5 variables = 8 comisiones. Techo cumplido.

### 4.1 Núcleo permanente

| Slug | Rol | Pregunta | Preguntas del caso |
| --- | --- | --- | --- |
| `requisitos` | Requisitos | ¿Cada decisión del dictamen 021 §5 es unívoca, atómica y verificable, y responde su pregunta sin «depende»? ¿Qué agrega la investigación que el dictamen no contesta? | P1–P13 |
| `verificacion` | Verificación | ¿Cómo se prueba cada decisión del dictamen y cada afirmación de I0–I7 que la ronda 2 use? ¿Qué sigue NO VERIFICADO (iOS, WASM ante Apple, 4.7.2)? | P1–P13, foco P1, P2, P8, P9, P12 |
| `lector-sin-contexto` | Lector sin contexto | ¿Un desarrollador sin experiencia puede seguir el dictamen y la estructura de guía que decide (P10, P11) sin preguntar? | P10, P11 y toda pregunta sin respuesta en el árbol |

### 4.2 Variables

| Slug | Rol | Tipo | Competencia | No-competencia | Preguntas |
| --- | --- | --- | --- | --- | --- |
| `arquitecto-maui-hibrido` | Arquitecto de aplicaciones móviles .NET MAUI | variable (Arquitectura) | Modelo de contenido como pieza técnica (A + definición como datos frente a C-min y a la C de I0), contrato del puente y su clave de compatibilidad (rango con techo frente a clave exacta derivada por hash), catálogo de capacidades y su descubrimiento, aplicar en el próximo arranque, comparación con Shiny.AppDeviceBridge | Tiendas y firma como obligación (seguridad); compuerta de CI y gramática de versiones (integración); pesos entre opciones (analista); valores de umbral como objeto formal (formal) | P1, P2, P3, P7, P12 |
| `analista-sistemas-y-decisiones` | Analista de sistemas con criterios y análisis de las decisiones | variable (Datos y dominio, con mandato del pedido) | Matriz de criterios de P1 rehecha con evidencia por celda (E02-B, E01, I0–I7) y pesos antes de puntuar; momento de actualización (al abrir, al iniciar sesión, forzado) como caso de uso; P13 y pendientes sin red; tensión forzado (folio 006) ↔ N = 0 ↔ «sincronizar primero» | Hechos técnicos (los toma como dato); seguridad y tiendas; análisis del camino de compromiso de fichas (6 bis); guía | P1, P4, P5, P13 (y folio 006) |
| `seguridad-canal-y-tiendas` | Seguridad del canal de actualización y políticas de tiendas | variable (Seguridad + Cumplimiento) | Conformidad de A + datos con Apple 2.5.2, DPLA 3.3.1(B), 4.7/4.7.2 y Play; diferencia de riesgo entre datos y código WASM (IL interpretado frente a AOT); capacidades encendidas desde el servidor como «hidden features»; firma, clave y rollback a la luz de Expo/Shorebird/Shiny | Elección de modelo por criterios que no sean seguridad o tiendas; compuerta de CI; didáctica | P1 (tiendas), P2, P9, P12 |
| `devops-integracion-y-pruebas` | Integración continua, PR, versionado y pruebas | variable (Operación y entrega; absorbe QA) | Compuerta que falla ante incompatibilidad del contrato (patrón fingerprint / `--fail-on-incompatible`) traducida a `[self-hosted, i7infra-dev]`; prueba «contenido N sobre el cascarón mínimo»; validación de definiciones contra esquema; líneas de versión con la clave de contrato y la de definición | Diseño interno del puente y de la clave (arquitecto); firma como control (seguridad) | P6, P7, P8 |
| `formal-umbrales` | Formal: umbrales, cuantificadores y rangos | variable (Formal, automática) | Cada umbral, cuantificador y rango del dictamen: TTFD ≤ 5 000 ms, N = 0, N ≥ 3 / `current` + `previous`, rangos con techo, «ninguna actualización … descarta» (P13.7); ¿está definido (métrica, condición, dispositivo, unidad), es consistente con los demás y con I0 (Shiny «tope de 5 s», «at best every 15 minutes»), es verificable? | Elegir el valor por criterios de producto o de UX; decidir el modelo; fuentes de tiendas | P1 (TTFD), P2 (N, retención), P3 (rangos), P7 (gramáticas), P13 (cuantificadores) |

## 5. Cobertura de P1–P13

| Pregunta | Comisiones | Señal nueva |
| --- | --- | --- |
| P1 modelo | arquitecto · analista · seguridad · formal (TTFD) · requisitos · verificación | I0 §7 P1 (C), I3 §3.6, I4 §3.6, folio 022 (iii) |
| P2 canal | arquitecto · seguridad · formal (N, retención) · verificación | I2 §3.5–3.6, I0 §7 P2 |
| P3 puente y compatibilidad | arquitecto · formal (rangos) · requisitos | I7 §3.9, §5 |
| P4 entrada | analista | I6 §3.1, I0 §7 P4 |
| P5 sin red | analista | I0 §7 P5, I6 §3.3 |
| P6 PR | integración | I7:390 |
| P7 versiones | integración · arquitecto · formal | I7:391, I0 §7 P7 |
| P8 pruebas | integración · verificación | I0 §7 P8 |
| P9 iOS | seguridad · verificación | I0 §5, I0 §7 P9 |
| P10 guía | lector sin contexto (académico postergado) | I0 §7 P10 |
| P11 demo | lector sin contexto · integración · analista | I0 §7 P11 |
| P12 capacidades | arquitecto · seguridad · verificación | I0 §4 |
| P13 versión vieja | analista · formal | I1 §3.3, I6 §3.3, I0 §3 |

## 6. Descartes y postergaciones con motivo

| Rol | Motivo | Condición de revisión |
| --- | --- | --- |
| Académico editor | **Postergado por techo** (`Mesa` §3.4.5): seis señales para cinco cupos, y su severidad esperada es la menor (P2). La investigación le sirve a la guía como fuente de ejemplos de falla (I0 §7, fila P10), y eso lo puede usar quien aplica al construir la guía sin que el panel lo dictamine | Entra en el ciclo siguiente si lo hay, o en esta ronda por convocatoria en caliente si `lector-sin-contexto` o `requisitos` emiten una solicitud con un hallazgo P1 sobre P10 o P11 |
| Caso de referencia y capacidades | Ad hoc r1 disuelta; su dominio tiene comisión (§3) | Señal nueva sobre una app híbrida de referencia de la organización |
| Criterios de decisión separada | La condición de 008 §2 no se cumple por su letra (§3); R-15 va al mandato del analista | Un `PROCEDE` del refutador r2 sobre criterios sin fuente o sin peso |
| Concurrencia y tiempo, Rendimiento y costo, Interfaz externa, Uso y accesibilidad, Trazabilidad documental | Los motivos de 008 §6 siguen valiendo: I0–I7 no traen volumen, latencia de servidor, API pública ni interfaz en ejecución. La latencia de arranque la lee formal como umbral | La misma de 008 §6 |

**Homogeneidad (folio 022, punto ii).** No se resuelve con la composición del panel: el panel ya es a ciegas y en
paralelo. Es una señal para el despacho del jurado de veredicto r2 (cinco funciones independientes, `Mesa` §3.5.4),
que es de la presidencia.

## 7. Mandatos comunes y específicos

### 7.1 Comunes

- Objeto: el dictamen 021 §5 y §6. Insumos: I0–I7 (citar por dossier y número de fuente), E01, R1–R4, N1–N5. Los
  informes r1 (009–018) se leen sólo para el fundamento de un ítem, y un hallazgo heredado entra como `C` (§3.2).
- La recomendación de I0 es **criterio del sintetizador**: hipótesis a refutar, no ancla. Lo que I0 marca HECHO se
  cita con su fuente; OPINIÓN funda a lo sumo una pregunta; NO VERIFICADO sigue así salvo que la comisión lo verifique.
- Fuentes externas con autor o número; una cláusula cuyo apartado no se verificó se cita sin apartado.
- Tope de 12 hallazgos, «lo que revisé y está bien» hasta tres, solicitud de convocatoria fuera de mandato,
  `Cadena-De-Consecuencias` §2 antes de recomendar, ficha de `Excepcion-A-Un-Conocimiento` §5.1 si se propone no
  seguir una convención que rige.
- Ensayos sólo en contenedores `fc-` con intermedios fuera de `/vm/claude-tmp`, borrados al terminar. **Sin g42 ni
  emulador** en esta ronda: si hace falta medir en un dispositivo, obstáculo de una línea a la presidencia. Nada
  irreversible.

### 7.2 Específicos

| Slug | Extra |
| --- | --- |
| `requisitos` | Cotejar cada decisión de 021 §5 contra I0 §7: dónde la investigación contradice, completa o deja sin cambios. Señalar la cláusula del objetivo que la operación sin red (R-03) todavía no tiene |
| `verificacion` | Por cada decisión, el criterio de aceptación y su medio. Clasificar las afirmaciones de I0 que el dictamen tome (HECHO/OPINIÓN/NO VERIFICADO) y declarar las que la ronda no puede verificar sin dispositivo |
| `lector-sin-contexto` | Lee el pedido, el contrato, el dictamen 021 y I0 «Resumen ejecutivo» (no los dossiers): cada pregunta que necesite para entender qué se actualiza y cuándo es hallazgo. Puede solicitar la convocatoria del académico (§6) |
| `arquitecto-maui-hibrido` | Tabla diferencial (§3.3, «Caso que funciona antes que diseño») entre el P1 del dictamen, C-min y la C de I0, y contra Shiny.AppDeviceBridge (I0 [105][106]). Decir si el rango con techo de P3 debe pasar a clave exacta derivada por hash (I7 §5) y qué cambia en el handshake y en P12 |
| `analista-sistemas-y-decisiones` | Rehacer la matriz de P1 con pesos escritos antes de puntuar y evidencia por celda, sin celdas apoyadas en el borrador (R-15), con C-min, A + datos y la C de I0 como alternativas en pie. Decidir el momento de actualización (al abrir, al iniciar sesión, forzado con red y sin pendientes) y su relación con N = 0 (021:409) y con P13.7 |
| `seguridad-canal-y-tiendas` | Distinguir el riesgo de tienda de la definición como datos y del código WASM (IL frente a AOT, I4); leer 4.7.2 contra P12 (catálogo y «hidden features», I0 §4); cotejar firma y rollback del dictamen con Expo, Shorebird y Shiny (I2 §3.5–3.6). Lo NO VERIFICADO de I0 §5 se mantiene salvo fuente primaria leída |
| `devops-integracion-y-pruebas` | Diseñar la compuerta tipo fingerprint / `--fail-on-incompatible` en `[self-hosted, i7infra-dev]` (Linux) y decir qué parte no corre ahí (Info.plist, iOS). Prueba «contenido N sobre cascarón mínimo» y validación de definición contra esquema como capas de P8. Medición de la API de GitHub sólo en lectura |
| `formal-umbrales` | Una fila por umbral, cuantificador o rango de 021 §5: definición completa (métrica, condición, dispositivo, unidad), consistencia entre preguntas (N = 0 frente al forzado; retención servidor/teléfono; rangos con techo frente a clave exacta) y medio de verificación. No elige valores por preferencia: si falta un valor, dice qué fuente o medida lo fija |

Sigue: despacho de las ocho comisiones a ciegas y del refutador · presidencia · Cierra con: folios informe de cada comisión, del refutador y del jurado de veredicto r2

Sigue: incorporación del siguiente informe y resolución · presidencia
