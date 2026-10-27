| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-10-25 |
| Autor | Jurado de composición |
| Corrige | — |

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-10-25 |
| Autor | Jurado de composición (paso 4 de `Mesa-De-Expertos-A-Pedido` §2.1) |
| Corrige | — |
| Norma | `<base de conocimiento>/Knowledges/Knowledge-Mesa-De-Expertos-A-Pedido.md` 3.1 |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | cabecera y §0 (líneas 1–111); §2 (2.1, 2.2 con su subsección, 2.3), §3 (3.1 a 3.4), §4, §7, §8 — fila «Sos el jurado (componés el panel…)» del Mapa de carga |
| Otros documentos cargados | `Mesa` 1.0 (`Rules/Rule-Mesa.md`): §3.4 entera (3.4.1–3.4.5) y §3.5.2 por remisión del paso 4 · `Cadena-De-Consecuencias` 2.0: §0 a §7 y §8–§9 · `Excepcion-A-Un-Conocimiento` 2.0: §0 a §8 |
| No cargado | `Escalas-De-Juicio` (este acto no emite hallazgos ni asigna niveles: usa la lectura P0–P3 tal como la fija el folio 003) |

# Informe del jurado de composición — panel de la mesa del expediente 0001

## Índice

1. [Qué se vota y con qué insumos](#1-qué-se-vota-y-con-qué-insumos)
2. [Lectura de la frase del pedido que nombra perfiles](#2-lectura-de-la-frase-del-pedido-que-nombra-perfiles)
3. [Votación por candidato](#3-votación-por-candidato)
4. [Panel resultante](#4-panel-resultante)
5. [Cobertura de las preguntas P1–P11](#5-cobertura-de-las-preguntas-p1p11)
6. [Descartes con motivo](#6-descartes-con-motivo)
7. [Mandatos comunes a todo el panel](#7-mandatos-comunes-a-todo-el-panel)

## 1. Qué se vota y con qué insumos

Clase de objeto: **diseño de una norma o decisión** (folio 003, `CLASE DE OBJETO`). Por `Mesa-De-Expertos-A-Pedido`
§2.2, las comisiones de dominio **citan fuentes externas y no inventan cláusulas**, y el dictamen responde cada
pregunta por separado. Las señales se ubican **en el objeto o en una frase del pedido** (§2.2, último párrafo): el
pedido es `evidencia/001-prompt-crear-framework-concept.md` (en adelante `EV001`, líneas desde la 4); el borrador
`Framework-APP.md` (en adelante `FAPP`) es insumo e hipótesis a refutar, y se cita como corroboración, no como
fuente de la señal.

Techo: núcleo + cinco variables o ad hoc (`Mesa` §3.4.5). Empate convoca. El refutador es núcleo y lo despacha la
presidencia aparte; no figura en esta lista. La composición no se eleva al PO (`Mesa` §3.5.2; `Mesa-De-Expertos-A-Pedido` §7).

## 2. Lectura de la frase del pedido que nombra perfiles

Frase literal (`EV001:39`): «inclui analistas en sistemas y arquitectos en aplicaciones moviles en MAUI .NET,
especialistas en analisis el cúal se le pida criterios de decisión y analisis de las decisiones, cita tambien
academicos en edición de material bibliografico para consultar y crear ejemplos y material de consulta».

Tiene dos lecturas (§3.1, «Todo pedido que plantea un problema»):

| Lectura | Perfiles | Comisiones |
| --- | --- | --- |
| (a) | analistas en sistemas · arquitectos MAUI · especialistas en análisis de decisiones · académicos editores | 4 |
| (b) | «especialistas en análisis el cual se le pida criterios de decisión…» es aposición de «analistas en sistemas»: el analista es quien aporta los criterios de decisión y el análisis de las decisiones · arquitectos MAUI · académicos editores | 3 |

Se toma **(b), la que menos agrega**, declarada. Lo que el pedido pide de ese perfil —criterios de decisión y
análisis de las decisiones— **entra entero** al mandato de la comisión de analistas: no se pierde, se concentra.
Con (b) el panel cumple el techo sin postergar ninguna señal de severidad P0 (§3, fila «Seguridad»).

**¿Hace falta además una comisión de criterios de decisión durante la ronda?** No, por tres razones:

1. El rol de análisis de decisiones del paso 6 bis **sólo se convoca por ficha de excepción admitida** («Sin ficha
   admitida, no se convoca», §2.1) y no emite hallazgos (§8): no cubre las decisiones del caso (D-01…D-07, P1–P11).
   Esa carencia la cubre la comisión de analistas con el mandato de criterios; el 6 bis queda para las fichas, que
   este caso probablemente tenga (T-2 retención N=2 y T-3 migraciones al arrancar, `R4-Convenciones-Que-Rigen.md:477-478`).
2. Una sexta comisión rompe el techo de `Mesa` §3.4.5, y la que tendría que salir para hacerle lugar es Seguridad,
   cuya señal es la de mayor severidad esperada (la lectura P0 del folio 003 nombra «mecanismo que una tienda prohíbe»).
3. Toda comisión recomienda con `Cadena-De-Consecuencias` §2 (los cuatro pasos, incluida la reversibilidad): el
   razonamiento de decisión ya es obligación de cada una; lo que agrega la comisión de analistas es **la matriz de
   criterios con peso, fijada antes de puntuar y con fuente citada**, transversal a P1–P11.

Condición de revisión (`Cadena-De-Consecuencias` §2, paso 4): si en la refutación o el veredicto la matriz de
criterios resulta insuficiente (hallazgo `PROCEDE` del refutador sobre criterios sin fuente o sin peso), la
comisión separada de criterios de decisión entra en el ciclo 2 por señal nueva.

## 3. Votación por candidato

| Candidato | Voto | Fundamento |
| --- | --- | --- |
| Arquitecto de aplicaciones móviles .NET MAUI (catálogo: Arquitectura) | `CONVOCAR` | Pedido lo nombra (`EV001:39`). Señal de catálogo: restricción dura de tecnología «paginas .net blazor hibridas en .NET MAUI» (`EV001:15`) y más de una unidad de entrega (cascarón por tienda, contenido por servidor: `EV001:21`; `FAPP:43-47`) |
| Analista de sistemas con criterios y análisis de decisiones (catálogo: Datos y dominio, con mandato del pedido) | `CONVOCAR` | Pedido lo nombra (`EV001:39`, lectura (b) del §2). Señal de catálogo: persistencia, estados y migraciones en P5 (folio 003, `PREGUNTAS DEL CASO`, P5; corrobora `FAPP:279-292`) |
| Académico editor de material bibliográfico (didáctica, guía para principiantes, bibliografía) | `INSTANCIAR_AD_HOC` | Pedido lo nombra (`EV001:39`) y pide la guía «enfocada a un desarrollador sin experiencia» (`EV001:33`). Ningún rol del catálogo de `Mesa` §3.4.2 cubre didáctica: ad hoc con carta de mandato (§3.1, «Hacé una mesa de expertos en…»; `Mesa` §3.4.4) |
| Integración continua, PR y versionado (DevOps) (catálogo: Operación y entrega) | `CONVOCAR`, fusionado con QA | Señal: «al introducir un PR sobre una rama estable … puede romper» y «prodicimientos claros en los PR y en los conceptos de integración y versionado» (`EV001:17`); runner prescripto (`EV001:35`). Severidad esperada P0: es el problema declarado del equipo |
| Estrategia de pruebas (QA) | `NO_CONVOCAR` como comisión aparte: **se fusiona** con la anterior | Su señal es la misma frase (`EV001:17`, «al no dispararse pruebas automatizadas»). El contrato N4→N3 de la cohesión global es «las suites que la compuerta del PR exige en verde» (`Bitacoras/02-Cohesion-Global.md`, §2): separar quien define la compuerta de quien define qué corre en ella parte una sola decisión en dos y deja el borde sin dueño. Fusionar libera el cupo para Seguridad |
| Seguridad del canal de actualización y políticas de tiendas (catálogo: Seguridad + Cumplimiento, un solo rol) | `CONVOCAR` | Señal: el pedido manda saltar «el ciclo de actualización rigido que imponen los store … play store de google o app connect de apple» (`EV001:21`): descarga de contenido ejecutable desde un servidor (exposición pública, integridad) bajo obligaciones contractuales de dos tiendas. La lectura P0 del folio 003 nombra «mecanismo que una tienda prohíbe». Corroboran `FAPP:40` (guideline 2.5.2), `FAPP:137` (firma), `FAPP:146-194` (login y biometría). Hay ítems `NO VERIFICADO` sobre tiendas en `Bitacoras/Nucleos/N1-Actualizacion-Dinamica-Sin-Tienda.md:119,129,177` |
| Criterios de decisión (comisión separada) | `NO_CONVOCAR` | Cubierto por la comisión de analistas (§2, lectura (b)); el 6 bis queda para fichas. Condición de revisión escrita en §2 |
| Formal (convocatoria automática si hay señal) | `NO_CONVOCAR`: **señal ausente** | El pedido no trae umbrales, pesos ni cuantificadores sobre el objeto. Los «X segundos»/«N segundos» de `FAPP:139,141` son variables sin valor en un insumo que no es el objeto; «N ≥ 3» y los rangos de versión son convenciones que rigen (`decisiones_cerradas`), no el objeto. Si el dictamen fija umbrales (timeout de arranque, retención, rangos de compatibilidad), la señal aparece y Formal entra automáticamente en el ciclo 2 |

## 4. Panel resultante

Núcleo (3, sin el refutador) + 5 (4 variables + 1 ad hoc) = 8 comisiones. Techo cumplido.

### 4.1 Núcleo permanente

| Slug | Rol | Pregunta | Preguntas del caso |
| --- | --- | --- | --- |
| `requisitos` | Requisitos | ¿Cada afirmación del contrato de entrada, del borrador y de las recomendaciones preliminares de los dossiers es unívoca, atómica y verificable? ¿Qué falta para responder cada pregunta sin «depende»? | P1–P11 |
| `verificacion` | Verificación | ¿Cómo se prueba cada decisión que el dictamen va a tomar? ¿Qué ensayo, comando o fuente la sostiene, y qué queda declarado sin criterio de aceptación posible (iOS)? | P1–P11, con foco en P2, P8, P9 |
| `lector-sin-contexto` | Lector sin contexto | ¿Un desarrollador sin experiencia (el lector que fija el pedido, `EV001:33`) puede trabajar con el contrato, el borrador y la estructura propuesta de la guía sin preguntar? Cada pregunta que necesita hacer es un hallazgo | P10, P11 (y toda pregunta cuya respuesta no esté en el árbol) |

### 4.2 Variables y ad hoc

| Slug | Rol | Tipo | Competencia | No-competencia | Preguntas |
| --- | --- | --- | --- | --- | --- |
| `arquitecto-maui-hibrido` | Arquitecto de aplicaciones móviles .NET MAUI | variable (Arquitectura) | Modelo de contenido actualizable (A/B/C), separación cascarón/contenido, puente JS↔C# y su contrato versionado (`bridgeVersion`, `minShellVersion` como rango), mecánica del canal (manifiesto, staging, activación atómica, rollback, paquete semilla), librería de SQLite (D-05) y migraciones en el teléfono como pieza técnica, y lo que iOS permite técnicamente | Políticas de tiendas como obligación contractual y firma criptográfica (Seguridad); gramática y líneas de versión del producto y la compuerta del PR (DevOps); criterios con peso entre opciones (analista); estructura didáctica (académico) | P1, P2, P3, P5, P7, P9 |
| `analista-sistemas-y-decisiones` | Analista de sistemas con criterios de decisión y análisis de las decisiones | variable (Datos y dominio, con mandato del pedido) | Modelo de datos local y trabajo sin red (outbox, idempotencia, conflictos por acción, migraciones como requisito), flujos de entrada del usuario como casos de uso (D-03, D-07), alcance funcional mínimo de la demo; y la **matriz de criterios de decisión** para D-01…D-07: criterios del pedido (simplicidad, practicidad, escalabilidad, `EV001:39`) más los fijos de reversibilidad, con fuente citada y pesos escritos antes de puntuar | Hechos técnicos de cada opción (los toma de arquitecto/dossiers/ensayos como dato, no los produce); seguridad criptográfica y de tiendas; el análisis del camino de compromiso de fichas (6 bis); estructura de la guía | P1, P2, P4, P5, P11 |
| `devops-integracion-y-pruebas` | Integración continua, PR, versionado y estrategia de pruebas | variable (Operación y entrega; absorbe QA) | Procedimiento de PR y compuerta que **impida** fusionar en rojo con `runs-on: [self-hosted, i7infra-dev]`; líneas de versión (cascarón, contenido, puente) con gramática y relación; qué se prueba en cada capa y qué conjunto es compuerta obligatoria; dónde compila y firma iOS; dónde vive el workflow de la demo | Arquitectura interna del puente y del canal; firma del paquete de contenido como control de seguridad; didáctica | P6, P7, P8, P9, P11 |
| `seguridad-canal-y-tiendas` | Seguridad del canal de actualización y políticas de tiendas | variable (Seguridad + Cumplimiento) | Integridad y autenticidad del paquete (firma, clave embebida, rotación, anti-rollback), amenazas al canal, entrada del usuario (cuenta + desbloqueo local con Keystore/Keychain, D-03), y conformidad del mecanismo con Google Play Developer Program Policies y App Store Review Guidelines / Apple Developer Program License Agreement | Elección A/B/C por otros criterios que no sean seguridad o tiendas; procedimiento de PR; datos sin red; didáctica | P1 (restricción de tiendas), P2, P4, P9 (firma iOS) |
| `academico-editor-didactico` | Académico editor de material bibliográfico (didáctica y bibliografía) | ad hoc | Estructura de la guía para un desarrollador sin experiencia (marco de referencia: escenarios, contextos, actores; recorrido; documentos), progresión de ejemplos, relación guía↔demo, bibliografía y material de consulta citables, cumplimiento de las reglas de documentación del pedido y del perfil Study-Guide (R3) | Decidir la arquitectura, el canal, la compuerta o la seguridad: enseña lo que las otras comisiones decidan y marca dónde una decisión es inenseñable o ambigua (eso sí es hallazgo suyo) | P10, P11 |

## 5. Cobertura de las preguntas P1–P11

| Pregunta | Comisiones |
| --- | --- |
| P1 modelo de contenido (D-01) | arquitecto · analista (criterios) · seguridad (tiendas) · requisitos · verificación |
| P2 canal de actualización (D-02) | arquitecto · seguridad · analista (D-02) · verificación |
| P3 cascarón, puente y contrato | arquitecto · requisitos |
| P4 entrada del usuario (D-03, D-07) | seguridad · analista |
| P5 datos locales y sin red (D-04, D-05) | analista · arquitecto |
| P6 procedimiento de PR e integración | devops |
| P7 líneas de versión | devops · arquitecto |
| P8 pruebas por capa y compuerta | devops · verificación |
| P9 iOS (D-06) | devops · arquitecto · seguridad · verificación |
| P10 estructura de la guía | académico · lector sin contexto |
| P11 alcance de la demo y su workflow | académico · analista · devops · lector sin contexto |

Toda pregunta queda cubierta por al menos una comisión, y cada comisión tiene señal ubicada (§3).

## 6. Descartes con motivo

| Rol | Motivo |
| --- | --- |
| Criterios de decisión (comisión separada) | Lectura (b) de `EV001:39`: su mandato lo lleva `analista-sistemas-y-decisiones`. El 6 bis cubre fichas. Condición de revisión en §2 |
| Estrategia de pruebas (QA) separada | Fusionada en `devops-integracion-y-pruebas`: misma señal (`EV001:17`) y un solo borde N4→N3. Si P8 desborda el tope de hallazgos de la comisión fusionada, entra separada en el ciclo 2 |
| Formal | Señal ausente en el objeto y en el pedido (§3). Entra automáticamente en el ciclo 2 si el dictamen fija umbrales |
| Concurrencia y tiempo | Outbox, reintentos e idempotencia (`FAPP:279-284`) son parte de P5 y los toma el analista; no hay procesos concurrentes del lado servidor en el objeto |
| Rendimiento y costo | El pedido no declara volumen ni latencia. El peso del primer arranque WASM es un dato de P1 que mide el arquitecto (E01 ya lo trae) |
| Interfaz externa | El único contrato es el puente cascarón↔contenido (P3), interno al framework: lo cubre el arquitecto. La API del negocio real está fuera de alcance (folio 003) |
| Uso y accesibilidad | La clase es diseño de una norma, no interfaz en ejecución; la demo se juzga por alcance (P11), no por intuitividad. Por lo mismo no se suman los tres roles de §2.2 de la clase «interfaz en ejecución» |
| Trazabilidad documental | Índices, enlaces y citas de la guía los cubren el académico (obligaciones de R3) y el lector sin contexto |
| Mesa-Consulta-A-Un-Tercero (el pedido la cita, `EV001:39`) | No es un rol del panel: es un medio de consulta que la presidencia usa si una comisión lo solicita; el folio 003 ya fijó que el único interlocutor nombrado es el PO |

## 7. Mandatos comunes a todo el panel

- **Fuentes**: cada comisión de dominio cita fuente externa (norma con número, publicación con autor, documentación
  oficial con URL y fecha de consulta); **una cláusula cuyo apartado no se verificó se cita sin apartado**.
- **Ensayos** (autorizados por `EV001:39`, «Los investigadores especializados pueden ensayar»): en contenedores Docker
  con prefijo `fc-`, intermedios fuera de `/vm/claude-tmp`; el teléfono g42 por
  `adb -H 203.0.113.30 -P 5037 -s <serie-del-g42>`, **sólo con paquetes `com.frameworkconcept.*`**, sin tocar otras apps
  ni ajustes (folio 002); el emulador `fc-android-emu` está corriendo pero su WebView 83 **no ejecuta Blazor .NET 10**
  (E01 §1): un ensayo de contenido Blazor se mide en el g42. iOS no es observable: se declara, no se supone.
- **Nada irreversible**: ningún push, merge, etiqueta ni publicación; si un ensayo necesita el runner real o la API de
  GitHub con escritura, es un obstáculo de una línea a la presidencia.
- **E01 es dato**: no se repite; se construye sobre él.
- Tope de 12 hallazgos por comisión, «lo que revisé y está bien» hasta tres ítems, sin opinar fuera de mandato
  (solicitud de convocatoria en su lugar), `Cadena-De-Consecuencias` §2 antes de recomendar, y ficha de
  `Excepcion-A-Un-Conocimiento` §5.1 si se propone no seguir una convención que rige (candidatas T-2, T-3).

### 7.1 Mandatos específicos

| Slug | Extra |
| --- | --- |
| `requisitos` | Revisar el contrato (folio 003), las recomendaciones preliminares de los dossiers N1–N5 y las decisiones abiertas D-01…D-07 de `FAPP`; señalar toda cláusula que no se pueda responder sin «depende». Sin ensayos |
| `verificacion` | Por cada pregunta, el criterio de aceptación y el medio (ensayo E0n, comando, fuente). Puede reproducir E01 en el g42 si necesita comprobar una afirmación. Declarar lo no verificable (iOS, trimming completo, `NO VERIFICADO` de N1) |
| `lector-sin-contexto` | Lee sólo el pedido, el contrato, `FAPP` y la propuesta de estructura de N5 (no los dossiers técnicos): cada pregunta que necesite es hallazgo. Puede intentar seguir los pasos de `R1` para compilar el caso base en un contenedor `fc-` y anotar dónde se traba |
| `arquitecto-maui-hibrido` | Construye sobre E01 (HybridWebView + `WebResourceRequested` en .NET 10, g42). Ensayos posibles: opción B (UI por datos) frente a A en tamaño y tiempo de primer arranque; activación atómica y rollback ante paquete que no avisa «arranqué»; versionado del puente con rango. Fuentes: Microsoft Learn (.NET MAUI HybridWebView, BlazorWebView), documentación de Android WebView. Puede proponer ficha sobre T-3 sólo con contradicción medida |
| `analista-sistemas-y-decisiones` | Matriz de criterios por decisión D-01…D-07, pesos fijados antes de puntuar, fuente por criterio (p. ej. ISO/IEC 25010 para características de calidad, sin apartado si no se verificó); reversibilidad por `Cadena-De-Consecuencias` §2 paso 4. Ensayo posible en `fc-` o en el g42: outbox con clave de idempotencia y migración de SQLite al arrancar (E1 para T-3). Base: R1 (EF Core SQLite 10.0.11 en el caso base) |
| `devops-integracion-y-pruebas` | Runner medido en folio 003 (`i7infra-runner-dev`, etiquetas `i7infra,i7infra-dev,dotnet,maui-android`, efímero, Linux). Medir con la API de GitHub **en lectura** si el repositorio público `hdcm-dev/Lab-Documentos` admite protección de rama o rulesets (T-6, NV-1 de R4). Puede correr en `fc-` los tests del caso base (18/18 en R1) y la compilación del APK; E2E de contenido sólo en el g42. Tensiones T-1, T-4, T-6, T-7 de R4 §7 son suyas |
| `seguridad-canal-y-tiendas` | Fuentes: Google Play Developer Program Policies (abuso de dispositivo y red), Apple App Store Review Guidelines y Apple Developer Program License Agreement (sobre código descargado), OWASP MASVS, The Update Framework (TUF); cerrar o confirmar los `NO VERIFICADO` de N1 (líneas 119, 129, 177). Ensayo posible en el g42: paquete con hash o firma alterados rechazado sin activar; verificación Ed25519 en .NET 10 Android. T-5 (manifiesto interno vs índice de canal) es suya junto con arquitecto |
| `academico-editor-didactico` | Carta de mandato (ad hoc): señal `EV001:33` y `EV001:39`; pregunta única: «¿cómo se estructura y se ilustra una guía que un desarrollador sin experiencia pueda seguir hasta correr la demo?»; disolución: al foliar su informe. Insumos: R3 (obligaciones OB-*, decisión H-06 de un archivo vs conjunto), N5, reglas de documentación del pedido (`EV001:43-64`). Fuentes didácticas citables con autor (p. ej. marco Diátaxis de Daniele Procida; taxonomía de Bloom revisada, Anderson y Krathwohl, 2001), sólo si las verifica. Ensayo posible: seguir en un contenedor `fc-` limpio los pasos que la guía propondría para correr la demo |

Sigue: incorporación del siguiente informe y resolución · presidencia
