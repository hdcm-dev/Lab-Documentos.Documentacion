| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-10-25 |
| Autor | Análisis de decisiones (ronda 2) |
| Corrige | — |

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Rol | Análisis de decisiones (Mesa-De-Expertos-A-Pedido §2.1, paso 6 bis) · **Ronda 2**. **No vota ni emite hallazgos** (§8) |
| Ronda | 2 |
| Fecha | 2026-10-25 |
| Carta | `evidencia/026-carta-r2-analisis-de-decisiones.md` (guardada verbatim antes de empezar, con sus tres líneas de cabecera) |
| Norma | `<base de conocimiento>/Knowledges/Knowledge-Mesa-De-Expertos-A-Pedido.md` 3.1 |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | Cabecera y §0 (líneas 1–111). Por la fila «Hacés el análisis de decisiones (paso 6 bis)» del Mapa de carga: §2.2 (con su subsección), §3.3, §4 y §8 |
| Documentos cargados con versión | `Excepcion-A-Un-Conocimiento` 2.0, entero · `Cadena-De-Consecuencias` 2.0, entero · `Escalas-De-Juicio` 1.0, §3.3 y §3.4 (por respaldo: Excepcion §5.3 manda marcar el puntaje que sólo se apoya en `C`, que define esa §3.3) · `Versionado-Producto-Integral` 2.0 (VPI), §2.6 líneas 248–252 y §3.2 líneas 338–348 y 362 (por respaldo: dos de mis matrices dependen de si una alternativa cumple VPI, y esas líneas son las que las comisiones citan) |
| No cargados | `Rule-Mesa` (la carta la lista como relacionada; mi fila no la da y ningún texto de mi acto la remite: no voto, no compongo y no escalo) |
| Insumos leídos | Pedido (evidencia 001 desde la línea 4); folios 004, 005, 006, 007 y 023; dictamen 021, «Premisas», P1 y P2 (líneas 292–425); análisis r1 020, §0, §2 y §3 P1–P2; folio 018 §3.1–§3.2; folio 012 §7 (E02-B y E02-R). Ronda 2: `r2-refutador.md` entero; `r2-analista-sistemas-y-decisiones.md` entero; `r2-arquitecto-maui-hibrido.md` §1–§3 P3; hallazgos y §3 de `r2-devops-integracion-y-pruebas.md` y `r2-formal-umbrales.md`; tablas de hallazgos de `r2-seguridad-canal-y-tiendas.md`, `r2-verificacion.md`, `r2-requisitos.md` y `r2-lector-sin-contexto.md`. Investigación: I0 «Resumen ejecutivo» (líneas 28–70); I1 §1–§2, §3.1 y §3.4; I2 §2 y §3.1; I3 §1–§2, §3.6, §4.2 y §5; I6 §2 y §3.1 |
| Medios propios | Lectura del árbol con `sed`, `grep`, `wc` y `ls` sobre el expediente, los ensayos y `~/fc-work/arq-e02r/` (sólo lectura). Ningún dispositivo, ningún compilado, ninguna fuente externa nueva, ningún commit. No dejé intermedios fuera del scratchpad |
| Rótulo | No nombra el repositorio privado de la app de referencia del PO, ni hosts, direcciones o series de dispositivos |

# Análisis de decisiones — ronda 2 del expediente 0001

## Índice

0. [Qué hace este folio y cómo se lee](#0-qué-hace-este-folio-y-cómo-se-lee)
1. [Parte (a): fichas admitidas por el refutador r2](#1-parte-a-fichas-admitidas-por-el-refutador-r2)
2. [Parte (b): criterios y pesos, fijados antes de puntuar](#2-parte-b-criterios-y-pesos-fijados-antes-de-puntuar)
3. [Parte (b): análisis por pregunta con disenso](#3-parte-b-análisis-por-pregunta-con-disenso)
4. [Filas del mapa sin alternativas en pie](#4-filas-del-mapa-sin-alternativas-en-pie)
5. [Dependencias entre decisiones](#5-dependencias-entre-decisiones)
6. [Obstáculos y medidas que faltan](#6-obstáculos-y-medidas-que-faltan)
7. [Resumen para el jurado](#7-resumen-para-el-jurado)

---

## 0. Qué hace este folio y cómo se lee

**Abreviaturas.** Las del refutador r2: `021:n` es la línea n del dictamen r1; `F00n`, los folios de `actuaciones/`;
`EV001`, el pedido. Comisiones r2: `REQ`, `VER`, `LSC`, `ARQ`, `ANA`, `SEG`, `DEV`, `FOR`; `REF` es el refutador r2 y
`R2-n` sus hallazgos. `I0[n]` es la fuente n de la síntesis; `I1:n`, la línea n del dossier.

**Marcas.** `[CP]`: criterio propio de este análisis, sin fuente externa; el jurado lo puede descartar sin contradecir
evidencia. `[AG]`: alternativa agregada por este análisis, que ninguna comisión propuso; va marcada para que el jurado
la vea como agregado y no como posición de la ronda. «sin medir» va donde nadie midió y no hay cifra
(`Cadena-De-Consecuencias` §3): no pongo una cifra supuesta. Una celda que sólo se apoya en `C` (`Escalas-De-Juicio`
§3.3) lo dice y no desempata (Excepcion §5.3).

**Qué no hace.** No vota, no emite hallazgos, no asigna niveles P0–P3 (la disputa P0/P1 de P12 es del jurado) y no
reabre lo que el PO aprobó en el folio 023: P6 en I1 implantado, XC-1 = C-1, iOS como diseño sin ensayo, y VPI rige.
Ninguna de mis matrices lo contradice.

**Qué preguntas.** Las que el «Mapa de disenso r2» de `REF` §7 muestra con más de una posición en pie, más las dos
subpreguntas de P1 que ese mapa separa (canal y umbral). Las que el mapa muestra con una sola posición van en §4, sin
matriz. Es la lectura que menos deja afuera y la declaro.

**Medidas propias de este folio (E1).**

| Id | Comando | Salida | Uso |
| --- | --- | --- | --- |
| M-1 | `ls despacho \| grep -i ficha` | sin salida (`exit=1`) | §1: no hay fichas nuevas |
| M-2 | `grep -rn reportFullyDrawn` sobre `E01/src` y `~/fc-work/arq-e02r/src` | `0` | §3.3 |
| M-3 | `cat ~/fc-work/arq-e02r/evidencia/logcat-2-v1-relanzar.txt` | `t=944ms recuperar` → `t=1345ms actualizador: al día (v1)` → `t=1606ms hybridwebview-agregado` → `t=3692ms js-marca 'primer-render v1'` → `t=3749ms puente Listo` | §3.3: el manifiesto ocupa 401 ms antes del WebView; `Listo` llega 57 ms después del primer render |
| M-4 | `ls -l ~/fc-work/arq-e02r/servidor` | `contenido-v1.zip` 3 395 072 B; `contenido-v3-roto.zip` 3 395 076 B | §3.2: dos versiones que difieren en 4 B de zip se bajan enteras |
| M-5 | `sed -n 292,911p 021 \| grep -c -i -E 'wasm\|webassembly\|hybridwebview\|webresourcerequested\|puente\|AOT\|16\.4\|WebView ≥ 94'` | `42` de 620 líneas del dictamen P1–P13 | §3.1: cuánto del dictamen depende sólo de A |
| M-6 | `wc -l` de los fuentes de E01 (`*.cs`, `*.razor`, `*.js`, `*.xaml`, `*.csproj`, `*.sh`, sin `obj` ni `bin`) | 1 124 líneas en total. Sólo de A: `ServidorDeContenido.cs` 55, `PuenteNativo.cs` 28, `bridge.js` 21, `Program.cs` 11, `Contenido.csproj` 24, `empaquetar.sh` 27 = **166**. `Actualizador.cs` 89, que sirve a cualquier modelo | §3.1: la parte del prototipo que se pierde si la respuesta es (a) |
| M-7 | `grep -n 'R13' VPI` y `sed -n 342,343p VPI` | R13 «Detectar un cambio de API pública …» rige desde **`candidata`**; «en una fase anterior la regla es recomendación y su compuerta corre en modo aviso» | §3.7 y §3.8 |

---

## 1. Parte (a): fichas admitidas por el refutador r2

**No hay ninguna, y por eso no hay análisis del camino de compromiso en esta ronda** (Excepcion §2, acto 3: «Sin ficha
admitida, no se convoca»; la carta me convocó igual por la parte (b)).

| Ficha | Estado según `REF` §6 | Qué hago |
| --- | --- | --- |
| XC-1 (r1) | **Cerrada**: el PO eligió C-1 (folio 023, ítem 2) | Nada. No se reabre |
| Fichas nuevas r2 | Ninguna presentada. Lo confirmo con M-1 | Nada |
| `ARQ` H-04: contrato como interfaces C# con «miembro nuevo = menor» | Propuesta que **necesitaría** ficha y no la trae (`REF` R2-09) | No la convierto en ficha: nadie escribe una en nombre de quien no la escribió (Excepcion §4, «Una excepción ya ejecutada sin ficha»). La trato como alternativa **descartada antes de ponderar** en §3.7, con su ancla |
| Clave exacta derivada por hash (I7, I0) | No propuesta | Igual: descartada antes de ponderar en §3.7 |

---

## 2. Parte (b): criterios y pesos, fijados antes de puntuar

Los escribo **antes** de la primera matriz y valen para todas. **Son los siete de 020 §2, con los mismos pesos y las
mismas fuentes, sin cambiarlos.** Lo hago así por dos razones: 020 los fijó antes de su primera matriz y `ANA` los
volvió a usar en r2, de modo que el jurado puede comparar las tres matrices; y `REF` R2-03 pide repuntuar P1 «con los
pesos de 020 §2, sin cambiarlos». Cambiarlos ahora, después de leer los informes, sería puntuar al revés.

| Id | Criterio | Peso | Fuente | Qué mide (escala 0–3) |
| --- | --- | --- | --- | --- |
| K-S | Simplicidad | 2 | EV001:39 «ventajas de simplicidad y practicidad, escalibilidad»; ISO/IEC 25010:2023, mantenibilidad, sin apartado | Piezas y conceptos propios que hay que sostener. 3 = ninguno nuevo |
| K-P | Practicidad | 2 | Misma frase; MEDIOS del contrato (F003) | Se construye y se ensaya con lo disponible (contenedores Linux, runner `i7infra-dev`, g42, sin Mac). 3 = medido |
| K-E | Escalabilidad | 2 | Misma frase | Más pantallas, encuestas, apps o usuarios sin cambiar el cascarón ni pasar por la tienda. 3 = sin límite estructural |
| K-D | Enseñabilidad | 2 | EV001:33 «guía … enfocada a un desarrollador sin experiencia»; Diátaxis, *Tutorials* | Conceptos y términos nuevos para el lector. 3 = un concepto por paso, sin términos contradictorios |
| K-R | Riesgo | 1 `[CP]` | Lectura P0 del contrato («mecanismo que una tienda prohíbe»); OWASP MASVS | Probabilidad e impacto de una falla en campo, en una tienda o en terceros. 3 = sin riesgo identificado; 0 = documentado sin mitigación |
| K-C | Costo de aplicar | 1 | Mesa-De-Expertos-A-Pedido §2.2, clase «diseño de una norma»: «El refutador ataca el costo de aplicarla» | Trabajo de quien aplica hasta tenerlo construido y verificado. 3 = existe o es trivial |
| K-V | Reversibilidad | 1 | `Cadena-De-Consecuencias` §2, paso 4, y §4 | Qué cuesta volver, con terceros. 3 = un parámetro; 0 = alcanza a terceros que ya lo tomaron. **Además es regla**: entre una reversible y una irreversible no hay empate (Cadena §4) |

**Máximo:** 2·(3+3+3+3) + 3 + 3 + 3 = **33**.

**Reglas de uso** (las de 020 §2, que declaro antes de puntuar):

- **Compuertas, no pesos.** Una alternativa que viola una restricción dura, una regla o una convención que rige sin
  ficha se descarta antes de ponderar, con su ancla. Una compuerta que depende de algo no resuelto se marca
  **condicional** y la alternativa se puntúa igual.
- **La suma ordena, no decide.** Una diferencia de **3 puntos o menos es empate** y la decide la cadena `[CP]`.
- **Lo que mide la escala es absoluto**, no relativo entre alternativas: la misma celda no cambia de valor porque
  aparezca otra alternativa.

---

## 3. Parte (b): análisis por pregunta con disenso

### 3.1 P1 — Qué se actualiza: A+datos, C-min y B pura

#### Las tres alternativas, con nombre

| Nombre | Qué es | Origen |
| --- | --- | --- |
| **A+datos** | Pantallas Razor compiladas a Blazor WebAssembly, bajadas por el canal y servidas por `HybridWebView`; la definición de la encuesta como datos versionados, dibujada por páginas genéricas del contenido | Dictamen r1 (021:307–318). Es la «C» de I0 salvo el canal (`ANA` §0, `REQ` H-03) |
| **C-min** | La definición de la encuesta como datos versionados, dibujada por componentes Razor **compilados en el cascarón** (`BlazorWebView`). Las demás pantallas, compiladas. Lo que cambia sin tienda es la encuesta | Análisis r1 (020 §3 P1); «B» del ensayo E02-B |
| **B pura** | Toda la interfaz como datos (*server-driven UI*): el cascarón trae un catálogo fijo de componentes y un renderizador genérico, y el servidor manda qué pantallas, en qué orden y con qué acciones. Un componente nuevo exige versión nueva del cliente | La carta la nombra sin definirla. **Mi lectura, declarada:** «B» es la del contrato («UI por datos», F003, P1) y «pura» la distingue de C-min, que es B acotada a la encuesta. La definición es la de I3 §1 [F12, F31]. Ninguna comisión r2 la propone: es `[AG]` como alternativa en pie |

**Descartada antes de ponderar: D, sitio remoto** (el caso de referencia tal cual). Compuerta: F005 «el encuestador
podria tomar las encuestas perfectamente sin internet»; sin red la referencia cancela toda navegación (E2, 018 §3.1,
`ConnectionManagerService.cs:25-33`). Es una premisa del dictamen (021, «Operación sin red») que `REQ` H-01 pide asentar
en el objetivo; mientras sea premisa, D no se puntúa.

#### Frente al escenario y la evidencia (no ponderado: es la compuerta)

| Lo que hay que cubrir | Origen | A+datos | C-min | B pura |
| --- | --- | --- | --- | --- |
| Tomar encuestas sin red y sincronizar después | F005 (a) | Sí, por diseño (contenido local) | Sí, medido el render desde JSON (E02-B) | Sí por diseño; SDUI de pantalla completa es «harder to support offline apps» (Netflix, I3 F11), salvable empaquetando el JSON (I3 §5, P5) |
| «si la encuesta **cambia** … o actualiza» sin tienda | F005 (b) | Sí: definición nueva | Sí: definición nueva | Sí: definición nueva |
| «si la encuesta … **se arregla**», arreglo **en la definición** (una pregunta, una opción, un salto) | F005; en la familia de encuestas, arreglar es publicar una definición nueva (I1:40-41; ODK «the `version` must change», I1[2]) | Sí | Sí | Sí |
| «se arregla», arreglo **en el código que dibuja** (un defecto de un componente o de una validación) | La misma frase, segunda lectura. **El sujeto gramatical de «se arregla» es «la encuesta»**, no «la pantalla»: esta fila es lectura, no literal | Sí, sin tienda | **No**: release del cascarón (Microsoft, «After the app is built, the .NET code Web View content sources can't change», I4[3]) | **En parte**: la composición sí; el componente no (I3 §1) |
| Pantalla o lógica **nueva** sin tienda | Lectura (b) de R-01: F004 «una actualizacion del contenido solo es cambiar la aplicación web server» (clasificado por la presidencia como **dato** de un caso que funciona, no como requisito) | Sí | No | Composición sí; lógica no |
| Forzar al iniciar (F006) | F006 | Igual en las tres: depende del canal (§3.4), no del modelo | Igual | Igual |
| Actualizar al iniciar sesión (F004) | F004 | Igual en las tres (P2, P4) | Igual | Igual |

| Familia de la investigación | Qué baja sin tienda | Analogía | Fuente |
| --- | --- | --- | --- |
| **I1**, encuestas en campo (ODK, Kobo, SurveyCTO, CommCare, Survey123) | Definiciones que un motor instalado interpreta; «no descargan código de pantallas». Una capacidad nueva del lenguaje exige motor nuevo por tienda (Central 2024.3 exige Collect 2024.3) | **C-min**. La familia vive con el límite de C-min y lo declara | I1:40-41; I1 §2; I0 «Resumen», punto 1; Dimagi [29], abierta por `REF` |
| **I6**, empresariales de campo (Power Apps canvas, SAP MDK, Salesforce FS) | Power Apps canvas: «pantallas y fórmulas Power Fx»; MDK: «páginas, acciones, reglas JS»; Salesforce: «diseños, **LWC**, configuración» | **A+datos** en Salesforce y MDK (lógica interpretada dentro de un motor de tienda); **B pura con lenguaje de fórmulas** en Power Apps canvas | I6 §2, filas Power Apps, MDK y Salesforce |
| **I2**, OTA de código interpretado (Expo, Capgo, Capawesome, Shorebird) | La capa JS/HTML/Dart; lo nativo y los permisos, sólo por tienda | **A** (el g42 pertenece a esta familia: I0 «Resumen», punto 2) | I2 §2 |

**Lectura de la evidencia.** El escenario que el PO describe (F005) es el de I1, y en I1 domina C-min. El caso que el PO
cita (F004) es el de I6 y el de su propia app, y ahí hay pantallas y lógica. `REF` R2-02 lo dice bien: **la
industria no decide entre (a) y (b)**. Lo que sí muestra la tabla de encaje es que **las tres alternativas cumplen F005
en su lectura literal** (el sujeto de «se arregla» es la encuesta), y que la diferencia aparece sólo en la segunda
lectura de «se arregla» y en la lectura (b) de F004.

#### Matriz

| Alt. | K-S ×2 | K-P ×2 | K-E ×2 | K-D ×2 | K-R ×1 | K-C ×1 | K-V ×1 | Total |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| **A+datos** | **0.** Dos runtimes, interceptor y puente (E01 §7, 021:311-315), esquema y renderizador dentro del contenido, **más los 10 grupos de agregados que existen sólo por bajar código** (`REF` R2-03, tabla, filas 1–10: AOT, detección del contrato, contenido sobre el piso, índice por mayor, `requires` con rango, `Permissions-Policy`, rama iOS 4.7, salto de MAUI en el transporte, `EmccMaximumHeapSize`, definición como clase propia). `ANA` le daba 1 sin esos 10 | **2.** v1→v2 sin reinstalar y adulterado rechazado en el g42 (E01 §6.2); rollback por marca (E02-R). El renderizador de la definición dentro del WASM: sin construir ni medir. El TTFD declarado no se midió en su condición (M-2, M-3; §3.3) | **3.** Cualquier página Razor y cualquier encuesta sin tienda (E01 §6.2). El único límite es el manifiesto, igual para las tres (I0 «Resumen», punto 4) | **0.** «Blazor Hybrid» de Microsoft dice lo contrario de lo que hace A (I4[3]; `LSC` H-02, `REQ` H-03: la misma arquitectura se llama A y C según el folio); más los conceptos de los 10 grupos para un lector que «no conoce MAUI, Blazor WebAssembly, firma ni integración continua» (021:737). `ANA` le daba 1 sin esos 10 | **1.** `.wasm` NO VERIFICADO en las dos tiendas (I0 «Resumen», último punto; `LSC` H-06 corrige que Play no está despejado); WebView ≥ 94; iOS ≥ 16.4; AOT puede cambiar la clase del código sin decisión (`VER` H-02, `SEG` H-04). Con mitigaciones propuestas: no es 0 | **0.** E01 existe; falta firma de producción, renderizador en el contenido y los 10 grupos. `ANA` le daba 1 sin ellos | **2.** Sin base instalada se reduce a C-min con un cascarón nuevo; la definición como datos se conserva (`ANA` §1.1). El retrabajo, sin medir (`REF` R2-11) | **13** |
| **C-min** | **2.** Un runtime (`BlazorWebView`), sin WASM ni interceptor; suma esquema y renderizador propios (E02-B). Los 9 grupos de r2 que «valen con cualquier modelo» (R2-03, filas 13–21) los paga igual | **3.** E02-B dibujó la encuesta desde un JSON en el g42: 1 615–1 723 ms (012 §7.1, corridas 2–4). El canal firmado se midió con un zip (E01 §6.2) y es indiferente a lo que lleva | **2.** Encuestas nuevas o corregidas sin tienda (F005; ODK). Pantalla o lógica nueva: cascarón por tienda (I4[3]). Mismo límite que I1 declara (Central 2024.3 → Collect 2024.3, I1 §2) | **3.** Es Blazor Hybrid en el sentido de Microsoft (I4[3]); un runtime; precedente ODK documentado que el lector encuentra | **2.** No baja código: `.wasm` e iOS ≥ 16.4 desaparecen; 4.7 no aplica sin software descargado (R2-03, fila 7). Los datos que dirigen la UI son entrada no confiable y van firmados (`SEG` P1). Sin rechazo documentado por bajar formularios: «ausencia de evidencia» (I0) | **2.** Prototipo E02-B; esquema y renderizador por construir | **2.** Pasar a A exige un cascarón nuevo (`BlazorWebView` → `HybridWebView`); sin base instalada, se revierte (`ANA` §1.1) | **26** |
| **B pura** `[AG]` | **1.** Un runtime, pero un protocolo de pantallas, navegación y acciones por datos para toda la app, además del esquema de encuesta. Thoughtworks lo recomienda para «highly dynamic areas», no para toda la UI, y advierte de «horrendous, overly configurable messes» (I3 §3.6, F12, **OPINIÓN de consultora**) | **1.** De SDUI sólo se midió un subconjunto: una encuesta desde JSON (E02-B). Pantallas, navegación y acciones por datos: sin construir ni medir. En .NET no se encontró un estándar maduro (I3 §5, P11, **criterio propio de I3**) | **2.** Composición de pantallas y encuestas sin tienda; componente nuevo = cliente nuevo (I3 §1, [F12][F31]) | **2.** Un runtime y Blazor Hybrid en sentido de Microsoft; pero el protocolo SDUI es un concepto con modos de falla documentados (I3 §4.2, opiniones) | **2.** Como C-min frente a tiendas: no baja código (Apple 2.5.2 habla de código). Sin red, salvable empaquetando el JSON (I3 §5, P5) | **1.** Renderizador general, catálogo y acciones por construir | **2.** Como C-min | **17** |

**Sensibilidad.** Con K-E de peso `w` y el resto igual: C-min = 22 + 2w; A+datos = 7 + 3w. **A+datos pasa delante sólo con
w ≥ 15**, siete veces y media cada uno de los otros dos criterios que el pedido enumera sin jerarquía (EV001:39). En r1 el
umbral era 8 (020) y en `ANA` 10; con el precio de r2 se aleja. B pura no alcanza a C-min con ningún cambio razonable
de un solo peso: queda por debajo en K-S, K-P, K-D y K-C a la vez.

**B pura queda dominada por C-min en este escenario.** C-min es justamente «SDUI acotado a la captura de datos» (I3
§1, «formularios dinámicos») y la acotación es lo que recomienda la única fuente con criterio de uso (Thoughtworks,
OPINIÓN). B pura sólo ganaría en la fila «se arregla, en el código que dibuja», y ahí cubre la composición pero no el
componente: no resuelve el caso que la separa de C-min.

#### Qué decide P1: no la suma, sino la lectura, y las dos reglas citadas apuntan en sentidos opuestos

El dictamen r1 decide por compuerta (lectura (b)), no por suma; `ANA` H-02 y `REF` R2-01 lo confirman y piden declararlo.
Para el **default del lote**, la ronda trae dos fundamentos, y los cotejo con su letra:

| Fundamento del default (b) | Quién | Qué dice la letra | Lectura del análisis |
| --- | --- | --- | --- |
| «El retrabajo de equivocarse es menor con A+datos» | `ANA` §3, P1, paso 3 | Cadena §2, paso 2: «"Un montón" y "apenas" no son medidas» | **No se sostiene como está**: no se midió, y la propia matriz de `ANA` puntúa igual la reversibilidad de las dos (R2-11) |
| «Decide la regla: el renglón 3 de §0 manda igualar primero la pieza que difiere del caso de referencia, y eso da (b)» | `REF` R2-01 y §3 | §0, renglón 3: «Si hay un caso que funciona, tomarlo de referencia y armar la tabla diferencial antes de diseñar; la primera salida es igualar la pieza que difiere». §3.3, misma fila: «cualquier otra [salida] dice, con E1 o E2, por qué la referencia no sirve» | La tabla de 018 §3.1 marca **una** columna que cambia, la 2 («dónde vive lo que se ejecuta»), y su primera salida, igualarla a «remoto», **cae por E2** (sin red no opera). Después de eso, la letra sólo pide decir por qué la referencia no sirve; **no elige entre A y C-min**. «A iguala todas las demás columnas» es una extensión razonable del renglón 3, no su letra |
| — (nadie lo invoca) | — | §0, renglón 1: «Una frase con dos lecturas se escribe con las dos y se toma **la que menos agrega**, declarada» | Es la regla de la norma **para este caso**: una frase del pedido con dos lecturas. (b) agrega «código de pantallas sin tienda», que no tiene literal unívoco: EV001:21 admite las dos (R2-01), F004 está clasificado como dato (F004, «Clasificación») y el sujeto de «se arregla» en F005 es «la encuesta». Además, un testimonio no es E4 por sí mismo (`Escalas-De-Juicio` §3.3). **Por la letra, el renglón 1 da (a)** |

Conclusión para el jurado: **ninguna regla da (b) por su letra**; la única regla escrita para «una frase con dos
lecturas» da (a), y el renglón 3 da (b) sólo en una lectura extendida. Eso no hace inválida la decisión r1: la hace
**una elección del jurado entre dos lecturas**, que tiene que escribirse así, y **refuerza que la pregunta al PO es
imprescindible** (en eso coinciden `ANA`, `REF` y este análisis).

#### Recomendación del análisis para P1

1. **La pregunta va al lote**, con las dos lecturas y su precio, como piden `ANA` H-02 y `REF` R2-01 y R2-03.
2. **Orden de construcción: primero el núcleo común a las dos ramas** `[AG]`. Las piezas que A+datos y C-min comparten
   no dependen de la respuesta: canal firmado y actualizador del cascarón (M-6: `Actualizador.cs` sirve a cualquier
   modelo), esquema y versión de la definición, P13, outbox y sincronización (P5), entrada (P4), procedimiento de PR
   (P6) y los 9 grupos de r2 que «valen con cualquier modelo» (R2-03, filas 13–21). La bifurcación toca el anfitrión
   del renderizador (`BlazorWebView` o `HybridWebView`) y los 10 grupos de A. Construir el núcleo primero hace que el
   default sólo importe si el PO no contesta antes de llegar a la bifurcación; el folio 023 muestra que el lote r1 se
   contestó el mismo día.
3. **Default, si al llegar a la bifurcación no hay respuesta** (`SI NO RESPONDÉS`):
   - **C-1 (recomendado): (a), C-min, con A documentada como extensión** (E01, E02-R). Lo deciden la regla de la
     norma para una frase con dos lecturas (renglón 1) y la suma (26 frente a 13), que no es empate.
   - **C-2: (b), A+datos.** Pasa primero si el jurado toma F004 y el caso de referencia como fuente de intención
     suficiente para (b), es decir, si adopta la lectura extendida del renglón 3 de `REF` R2-01. Es lo que votó r1 y lo
     que proponen `ANA` y `REF`.

**Cadena de consecuencias de C-1, default (a) C-min** (Cadena §2):

| Paso | C-min por defecto (recomendado) | A+datos por defecto (C-2) |
| --- | --- | --- |
| 1. ¿Dónde cae? | En el cascarón: toda pantalla o lógica nueva va por tienda (I4[3]); y en el PO, si quería (b) | En el arranque de cada teléfono, en los pisos de WebView e iOS, en la revisión de Apple, y en quien aplica y en el lector, por los 10 grupos de A; y en el PO, si quería (a) |
| 2. ¿Cuánto pesa? | Primer render 1 615–1 723 ms (E02-B). APK 18 862 370 B (012 §7.1). El costo de cada pantalla por tienda no se mide desde acá: es el ciclo que EV001:21 quiere evitar | Primer render 3 692–4 871 ms con el manifiesto bloqueando (E02-R; M-3). 9,13 MB por versión retenida (021:366, heredado). 10 grupos de agregados (R2-03). En el dictamen, 42 de 620 líneas dependen sólo de A (M-5); en el prototipo, 166 de 1 124 líneas (M-6). `.wasm` ante Apple: sin medida posible |
| 3. ¿Qué pierde la otra? | Si el PO responde (b): faltan las pantallas actualizables y hay que sumar A, cuyo trabajo **no se pierde** porque hacía falta igual; se mueve el anfitrión del renderizador (sin medir) | Si el PO responde (a): se construyeron los 10 grupos y el anfitrión `HybridWebView` sin necesitarlos; ese trabajo **sí se pierde** |
| 4. ¿Reversible? | Sí, sin base instalada | Sí, sin base instalada |

Las dos son reversibles, así que el paso 4 no decide; **deciden la regla del renglón 1 y el paso 3**: con el núcleo
común construido primero, el default C-min no tira trabajo en ninguna rama, y el default A+datos lo tira en una.

**Qué pierde la descartada (si el jurado elige C-1):** la corrección de **código** de pantallas sin tienda, que es lo
que hace la app de referencia del PO (F004) y la familia I6. **Si elige C-2:** unos 2 s de arranque, el término
«Blazor Hybrid» en el sentido de Microsoft y la enseñabilidad (K-D 0 frente a 3).

**Condición de revisión (comprobable):**

- (i) El PO responde en el lote. Con (b), P1 pasa a A+datos sobre el núcleo ya construido; con (a), se confirma.
- (ii) Con C-min vigente: un PR toca el renderizador del cascarón para corregir **una encuesta** (no para agregar un
  tipo de pregunta). Ese día la definición no alcanzó para la lectura literal de F005, y se revisa el esquema.
- (iii) Con A+datos vigente: las tres del dictamen (021:372-377), con la de iOS reemplazada por una comprobable dentro del
  alcance (`VER` H-10).

---

### 3.2 P1 — Canal de la definición (sólo si P1 es A+datos)

Con C-min o B pura la pregunta no existe: la definición es el único artefacto que viaja. Las tres alternativas:

- **K1, dentro del paquete** (021:316-317): un índice, un artefacto; la definición viaja en el zip del contenido.
- **K2, un índice, dos clases** (`ARQ` H-01, `SEG` H-05, `REQ` H-04): mismo índice firmado y misma verificación; entradas
  `contenido` y `definicion`, aceptables por separado; la definición se activa al empezar la próxima encuesta.
- **K3, dos líneas** («C de I0», I0:146-147, 159-160, 416): segunda línea de publicación con índice propio.

Nadie había puntuado K2 (`REF` R2-06: la matriz de `ANA` comparó K1 con K3).

| Alt. | K-S ×2 | K-P ×2 | K-E ×2 | K-D ×2 | K-R ×1 | K-C ×1 | K-V ×1 | Total |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| **K1** | **3.** Nada nuevo | **2.** Canal medido con zip (E01); renderizador de la definición sin medir | **1.** Cada corrección de encuesta es un paquete de contenido entero: dos versiones que difieren en 4 B de zip pesan 3 395 072 y 3 395 076 B y se bajan enteras (M-4); 9,13 MB por versión retenida (021:366, heredado). Pasa por la compuerta de código del PR (`ANA` H-01) | **2.** «Un paquete, una versión», pero con dos líneas de versión en un artefacto sin regla de qué sube (`REQ` H-04) | **1.** Cada corrección de datos es una publicación de código ante Apple 2.5.2, NO VERIFICADO; la condición «iOS pasa a B» no tiene camino (`SEG` H-05, `ARQ` H-01) | **3.** Es el dictamen | **1.** Separar después cuesta un release del cascarón por tienda y convivir con los que no actualizan, porque el actualizador vive en el cascarón (`ARQ` §3, P1, paso 4) | **21** |
| **K2** | **2.** Un tipo de entrada más y una regla de activación | **2.** Mismo canal medido; la definición sola, sin medir | **3.** Una corrección de encuesta publica sólo la definición | **2.** Un concepto más (dos clases de entrada), con precedente ODK (I0) | **2.** La definición sobrevive a apagar el `.wasm` en iOS (`SEG` H-05) | **2.** Un tipo, una regla y un caso en la suite del actualizador (`REF` R2-06) | **3.** Volver a K1 es que el contenido ignore la entrada separada (`ARQ` §3, P1) | **25** |
| **K3** | **1.** Segunda línea firmada con índice propio y la regla «definición exige motor ≥ X» (`ANA` §1.1) | **1.** Sin construir ni medir | **3.** Igual que K2 | **1.** Dos líneas de publicación que explicar | **2.** Igual que K2 en iOS; suma riesgo de compatibilidad definición–motor (Survey123 BUG-000144445, I1[34]) | **1.** Los costos de K2 más un segundo canal | **3.** Fundir es borrar un índice (`ANA` §1.1) | **18** |

**Recomendación: K2.** Le gana a K1 por 4 (no es empate) y a K3 por 7. La cadena lo confirma por el paso 4: K1 es la
única que se vuelve cara de revertir cuando haya cascarones instalados.

**Cadena de K2.**

1. **Dónde cae:** en el esquema del índice, en el actualizador del cascarón y en un concepto más para el lector.
2. **Cuánto pesa:** una entrada y una regla; la suite, un caso (`REF` R2-06). El peso de una definición sola bajada por el
   canal: **sin medir** (obstáculo O-1, §6). Lo que K2 ahorra por corrección sí está medido: el paquete entero de
   3 395 072 B que K1 obliga a bajar (M-4).
3. **Qué pierde K1, la descartada:** la unidad «un paquete, una versión» y la ausencia de una relación de compatibilidad
   definición → motor (que K2 tiene que declarar: `compatible-con-contenido`, `ARQ` §3 P1).
4. **Reversible:** sí, y barato (el contenido ignora la entrada separada). K1 no lo es después de instalar.

**Condición de revisión:** la de `ARQ`: si durante las corridas de la compuerta de la demo ninguna definición se publica
sin un contenido nuevo, la separación no se usó y se vuelve a evaluar.

---

### 3.3 P1 — Umbral de arranque: qué instrumento

El valor (5 000 ms, criterio del jurado anclado en Android vitals) no está en disenso. Sí lo está la definición: `FOR`
H-01/H-02 y `VER` H-01 muestran que el dictamen nombra un instrumento que nadie usó y una condición que no se midió. Lo
confirmo con M-2 (`reportFullyDrawn`: 0 coincidencias) y M-3 (el manifiesto ocupa de 944 a 1 345 ms, antes de crear el
WebView, en la corrida que el dictamen cita como «sin bloquear»).

Dos instrumentos en pie (`FOR` H-02, dirección (1)):

| Alt. | K-S ×2 | K-P ×2 | K-E ×2 | K-D ×2 | K-R ×1 | K-C ×1 | K-V ×1 | Total |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| **U1: `reportFullyDrawn` llamado desde `Listo(version)`** (TTFD de Android) | **2.** Una llamada por el puente | **1.** Sin medir (`FOR` S-4) | 2 | **3.** Término estándar de Android (folio 010:49) | **2.** Mide «interactivo», que es lo que Android define | **2** | **3** | **23** |
| **U2: marca JS `primer-render`, sin llamarla TTFD** | **3.** Existe (`bridge.js`) | **3.** Medida en E02-R | 2 | **2.** Marca propia que el lector tiene que aprender | **1.** Mide primer render, no interactividad: subestima | **3** | **3** | **27** |

**Recomendación: U2 para el dictamen y la demo**, con su nombre propio y sin llamarla TTFD. La diferencia es 4 y la
cadena no la invierte: las dos son reversibles (un instrumento se cambia sin tocar a terceros).

**Cadena de U2.** (1) Cae en el nombre: la guía no puede decir «TTFD». (2) Pesa poco: según M-3, `Listo` llega 57 ms
después del primer render en la corrida 2, así que la distancia entre U1 y U2 en esa corrida es de ese orden; con una
sola corrida no hay estadístico (`FOR` H-02). (3) Pierde la equivalencia con Android vitals, que es la fuente del valor.
(4) Reversible.

**Sobre «lo medido lo cumple».** Las cifras 3 692–4 871 ms se tomaron con el manifiesto bloqueando 401 ms (M-3). Con
N = 0 esa espera sale del camino crítico, así que las cifras **son una cota pesimista** de la condición declarada. Que
la condición declarada también cumpla es una inferencia, `C` y no medida: la corrida con el manifiesto fuera del camino
crítico, `force-stop` y k corridas es el obstáculo O-2 (§6). Mientras tanto, el dictamen r2 puede escribir «medido con el
manifiesto en el camino crítico; la condición declarada, sin medir».

**Condición de revisión:** llega la corrida de O-2 con `reportFullyDrawn` desde `Listo`; si U1 queda dentro del umbral
en el estadístico que fije `FOR`, se pasa a U1 y a la palabra TTFD.

El dispositivo («g42 como dispositivo de medida del laboratorio», `FOR` H-01, `VER` H-01) no tiene alternativas en
pie: las dos comisiones proponen lo mismo, y el conjunto de soporte es un valor de producto que va al lote (`FOR` S-3).

---

### 3.4 P2 — Forzado: cuándo se activa una obligatoria, y dónde bloquean los rechazos

Las alternativas en pie:

- **F1, dictamen y `ANA` CU-6:** «en el próximo punto seguro: un arranque en frío, o el fin de la encuesta en curso»
  (021:418).
- **F2, `ARQ` H-02 y `REF` R2-07:** sólo en el próximo arranque en frío, **antes de mostrar**, si ya está bajada y
  verificada; sin activación en caliente.
- **F3, `FOR` (ii):** espera acotada al abrir, sólo cuando se sabe que hay obligatoria (Shiny, `CheckTimeout` 5 s).
- **F4, `ARQ` H-02, rama condicional:** F1 más la marca pendiente extendida a cada recarga del WebView.

| Alt. | K-S ×2 | K-P ×2 | K-E ×2 | K-D ×2 | K-R ×1 | K-C ×1 | K-V ×1 | Total |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| **F1** | **1.** Dos reglas de activación (021:411 y 418); «punto seguro» no es lista cerrada (`FOR` H-03) | **2.** La activación en frío medida (E02-R); la de fin de encuesta, sin medir | 2 | **1.** Dos momentos y una lista abierta | **0.** Contraejemplo E3 de `ARQ` H-02: una obligatoria rota activada al terminar la encuesta deja al encuestador sin rollback hasta matar la app; la marca se revisa «el arranque siguiente» (021:398) | **2** | **2.** Vive en el cascarón (`FOR` §3) | **16** |
| **F2** | **3.** Una sola regla de activación para todo el contenido | **3.** Es el camino de E02-R: `Recuperar()` y activación antes del WebView, con marca | 2 | **3.** «Lo nuevo se ve en el próximo arranque» | **2.** Latencia de un arranque en frío; sin cota temporal si el proceso vive en segundo plano (E3 de `FOR` H-03). La marca cubre todos los caminos | **3.** Quita una ruta (`REF` R2-07) | **2** | **29** |
| **F3** | **1.** Espera, tope, rama sin red y umbral propio fuera del TTFD | **2.** Descarga y descompresión medidas (E01 §6.2) | 2 | **2** | **1.** 5 146–5 675 ms en ese arranque, por encima del umbral de P1 (`FOR` §3, con E02-R y E01) | **1** | **2** | **18** |
| **F4** | **1.** Dos reglas más la extensión de la marca | **1.** Sin medir | 2 | **1** | **2.** La marca cubre el caliente | **1** | **2** | **15** |

**Recomendación: F2.** Gana por 11 o más a cada una. La cadena no la invierte: las cuatro viven en el cascarón y ninguna
es más irreversible que otra (`FOR` §3, paso 4).

**Cadena de F2.**

1. **Dónde cae:** en el tiempo que tarda una obligatoria en llegar al encuestador.
2. **Cuánto pesa:** un arranque en frío después de quedar verificada. La frecuencia de arranques en frío del usuario: sin
   medir (`ARQ` §3, P2). «Code push adoption ≈ user cold-start frequency» es OPINIÓN de un equipo en producción
   (I0[56]).
3. **Qué pierde F1, la descartada:** la activación al terminar la encuesta, que es más inmediata en una jornada larga sin
   cerrar la app. **Qué gana el encuestador:** nunca queda con contenido roto y sin salida durante la sesión.
4. **Reversible:** sí, en el sentido de `FOR`: cambiar la regla es un release del cascarón, igual para todas.

**Frente a F006** («se puede forzar a que el usuario cuando inicie la apliación actualice»): F2 cumple «al iniciar» en
su letra, **un inicio después de la descarga** (`ANA` CU-5 lo declara). F3 lo cumpliría en el mismo inicio, al precio
de romper el umbral de P1.

**Los dos bloqueos van al mismo punto que F2.** El rechazo de la versión de contenido en uso y el cascarón bajo el
mínimo bloquean **en el próximo arranque en frío o en el próximo ingreso**, nunca a mitad de una captura (`ANA` H-03 y
CU-9/CU-10, `REQ` H-08, `FOR` H-03). `ANA` H-03 proponía además «o al terminar la encuesta en curso»; con F2 ese punto
ya no existe y no lo agrego. Rechazar una versión de contenido no rechaza las respuestas tomadas con ella (`ANA` H-03).

**Condición de revisión:** una obligatoria tarda en llegar al g42 más que la cota que fije el producto, medida en
arranques en frío o en tiempo (`FOR` H-03 pide declararla en una unidad contable; el valor va al lote, `FOR` S-3).

---

### 3.5 P2 — `expires` y claves

**`expires`.** El dictamen lo tiene sin valor (021:396, 400); eso no es una alternativa, es la ausencia del valor
(`SEG` H-09, `FOR` H-04), y no la pondero. Las alternativas:

- **X1** (`SEG` H-09 (a), `REF` R2-10): valor declarado, renovado por un job programado en el mismo *environment*, sin
  revisor humano en la renovación.
- **X2** (`SEG` H-09 (b)): firma de vigencia separada, con una clave de poder acotado que sólo extiende `expires`.
- **X3** `[AG]`: sin `expires`. Es la más cercana a la industria leída: «No documentado» en Expo, Shorebird,
  Capgo/Capawesome y Shiny (`SEG` §1.2).

| Alt. | K-S ×2 | K-P ×2 | K-E ×2 | K-D ×2 | K-R ×1 | K-C ×1 | K-V ×1 | Total |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| **X1** | **2.** Un job | **2.** El runner existe; el job, sin construir | 2 | **2** | **2.** Ataque de congelamiento acotado por el período; si el job falla, la base deja de aceptar contenido nuevo (`SEG` H-09) | **2** | **3.** El valor es del servidor | **23** |
| **X2** | **1.** Una clave y un rol más | **1.** Sin construir | 2 | **1** | **2** | **1** | **2.** El cascarón tiene que conocer la clave de vigencia | **15** |
| **X3** `[AG]` | **3** | **3** | 2 | **3** | **0.** El congelamiento que TUF §5.5 nombra (citado por el dictamen, 021:434) queda sin cota ni mitigación | **3** | **1.** Agregar `expires` después exige que lo compruebe el cascarón: un release por tienda que sólo alcanza a quien actualice (Cadena §2, paso 4) | **26** |

**La suma pone primero a X3 (26 frente a 23), pero no decide: X3 es irreversible frente a X1, que es reversible**
(con X1, volver a X3 es poner un `expires` muy lejano, del lado del servidor). Por Cadena §4 no hay empate que resolver:
**se recomienda X1**, y la sensibilidad lo muestra: sólo la regla de reversibilidad la pone delante.

**Cadena de X1.** (1) Cae en el pipeline, que tiene que re-firmar antes del vencimiento aunque no haya release. (2)
Pesa un job programado; su tiempo, sin medir. El valor del período: lo fija `FOR` con TUF como fuente, y depende del
intervalo máximo entre publicaciones, que es dato de producto (al lote). (3) X3, la descartada, pierde la cota al
congelamiento; X2 pierde simplicidad. (4) Reversible.

**Condición de revisión:** el job de renovación falla una vez en el runner y la base deja de aceptar contenido: se mide
cuánto tardó en verse, y si es más que el margen, se alarga el período o se pasa a X2.

**Revocación de claves.** Las alternativas:

- **R0, el dictamen tal cual:** el cliente acepta cualquier clave del conjunto. `SEG` H-08 muestra que así la reserva no
  protege contra el compromiso de la activa.
- **R1, `SEG` H-08:** revocación firmada por la reserva, implantada en la demo.
- **R2, `REF` R2-10:** el cliente acepta sólo claves no revocadas y la suite tiene el rojo provocado; la publicación de la
  revocación se enseña como diseño, no implantado.

| Alt. | K-S ×2 | K-P ×2 | K-E ×2 | K-D ×2 | K-R ×1 | K-C ×1 | K-V ×1 | Total |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| **R0** | **3** | **3** | 2 | **1.** La guía promete más de lo que el diseño da (`SEG` H-08) | **0.** Con la activa comprometida no hay salida sin cascarón nuevo | **3** | **1.** Un cascarón que acepta cualquier clave sólo se corrige por tienda (`SEG` H-08: irreversible para terceros) | **22** |
| **R1** | **1** | **1.** Sin construir | 2 | **1.** Un concepto de TUF más | **3** | **1** | **2** | **16** |
| **R2** | **2** | **2.** Un caso en la suite | 2 | **2.** Se enseña como diseño | **2.** En producción falta publicar la revocación: declarado | **2** | **3.** El cliente ya rechaza las revocadas: publicar la revocación es del servidor | **23** |

**R2 frente a R0 es empate (1 punto)** y lo decide el paso 4: R0 es irreversible para terceros y R2 no. **Se recomienda
R2.** La lista firmada de versiones retiradas (`SEG` H-10) no tiene disenso (`REF` la acepta): va en §4.

---

### 3.6 P2 — Estado terminal: `current` y `previous` fallidas

`VER` H-04: el dictamen no dice qué hace el cascarón cuando las dos versiones locales fallan, o cuando no hay `previous`
(el primer update después de la semilla). Nadie propuso una forma; `VER` S-1 lo pide a quien tenga P2. Las dos que la
industria y el árbol dan:

- **T1** `[AG]`: pantalla propia del cascarón (XAML, como «actualizá el WebView», 021:320), que dice que no hay
  contenido sano, muestra la versión y reintenta la descarga cuando haya red.
- **T2:** volver a la semilla, como Expo («o con el bundle embebido», I0:104) y Shiny («the newer of the bundled and
  installed builds», I4:61).

| Alt. | K-S ×2 | K-P ×2 | K-E ×2 | K-D ×2 | K-R ×1 | K-C ×1 | K-V ×1 | Total |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| **T1** | **2.** Una pantalla más del cascarón, que ya tiene pantallas XAML | **1.** Sin medir (no hay corrida con dos fallidas) | 2 | **3.** «No hay contenido sano: conectate» | **1.** Sin red, el encuestador queda sin app hasta tener red: va contra F005. Los pendientes no se tocan | **2** | **3.** No deja rastro | **22** |
| **T2** | **2.** El camino existe: la semilla está en el APK | **2.** El primer arranque desde la semilla se midió (E01) | 2 | **2.** Contradice «la semilla no es destino de rollback» (021:402) | **1.** La semilla puede no leer los datos que escribieron versiones nuevas (`ASD` H-07 de r1, retomado en 020 §3 P2) | **2** | **1.** Si la semilla escribe con un esquema viejo sobre datos nuevos, la pérdida puede no volver: sin medir | **20** |

**Empate (2 puntos); lo decide el paso 4: T1 es reversible y T2 puede no serlo.** **Se recomienda T1.** Pierde la
operación sin red en el peor caso: dos versiones rotas seguidas y sin red, que E02-R no midió.

**Condición de revisión:** la corrida que pide `VER` (dos versiones fallidas sin red) muestra que la semilla lee y escribe
la base local sin pérdida; entonces T2 pasa a ser una opción con esa condición comprobada en el arranque.

---

### 3.7 P3 — Cómo se detecta que el contrato del puente cambió

**Descartadas antes de ponderar, con su ancla:**

- **Clave exacta derivada por hash como decisor** (I7 §5, I0 §7). VPI §2.6 exige el rango `>=A.B.C <D.0.0`; no seguirlo
  necesita ficha y una contradicción, y nadie la sostiene (`ARQ` §3 P3, `DEV` §3 P7, `FOR` §3 P3; `REF` §4). E4: VPI
  §2.6, aprobado por el PO (folio 023, ítem 4).
- **Contrato como interfaces C# con «miembro nuevo = menor»** (`ARQ` H-04). VPI §2.6: «todo miembro nuevo en un tipo
  interfaz es cambio mayor». Declararlo menor es no seguir la convención sin ficha (`REF` R2-09). E4: VPI §2.6.

Con esos dos fuera, el contrato es **la tabla de métodos de `Call(sobre)` y el catálogo**, que el dictamen ya fija
(021:474), y la clasificación se declara como hueco de VPI §2.6 para ese objeto (`DEV` H-03).

**Una precisión que condiciona las alternativas (M-7).** Detectar el cambio de API es la regla R13 de VPI, que **rige
desde `candidata`**, y VPI §3.2 dice: «en una fase anterior la regla es recomendación y su compuerta corre en modo
aviso». El producto está en `diseño` (021). Por eso **no detectar es admisible hoy** y entra en la matriz como D3.

- **D1** (`REF` R2-08): prueba de instantánea: la tabla de métodos y el catálogo se serializan y se comparan con un
  `contrato.json` versionado; rojo si difieren y la versión no subió, o si subió y no difieren.
- **D2** (`DEV` H-02, `ARQ` H-05): archivo de contrato generado desde el código, su SHA-256, dos reglas y una línea base
  por marco.
- **D3** (dictamen): versión del puente como constante a mano, sin detección.

| Alt. | K-S ×2 | K-P ×2 | K-E ×2 | K-D ×2 | K-R ×1 | K-C ×1 | K-V ×1 | Total |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| **D1** | **2.** Una prueba y un archivo | **2.** Tiempo en el runner: sin medir | **3** | **3.** Un concepto: la «foto» del contrato | **2.** No ve cambios de semántica que no cambien la tabla | **2** | **3.** Un archivo de CI | **27** |
| **D2** | **1.** Generador, hash y línea base por marco | **1.** El generador, sin construir | **3** | **1.** Tres conceptos de CI para un lector que «no conoce … integración continua» (021:737) | **2.** La misma cobertura que D1: «la instantánea es la huella» (`REF` R2-08) | **1** | **3** | **18** |
| **D3** | **3** | **3** | **1.** Cada cambio del contrato depende de que alguien se acuerde | **2.** Simple, pero hay que enseñar «acordate de subirla» | **0.** Falla documentada: «runtimeVersion is a hand-maintained string» (I0[58], OPINIÓN) y el bucle de caídas (I0 §6.1, OPINIÓN); la marca no la atrapa si el contenido falla después de `Listo` (`ARQ` H-05) | **3** | **3** | **24** |

**D1 frente a D3 es empate (3 puntos).** Lo decide el paso 4, aplicado a lo que cada una deja pasar: con D3 un paquete
incompatible llega a teléfonos que ya lo bajaron, irreversible para ellos (`DEV` §3 P6, paso 4); D1 es un archivo de
CI. **Se recomienda D1.** D2 queda tercera por 9: cubre lo mismo que D1 con tres piezas más.

**Cadena de D1.** (1) Cae en quien cambia el puente: tiene que regenerar la instantánea y clasificar el cambio. (2) Dos
archivos por cambio, bajo el techo de 5 de VPI §3.3 (`DEV` §3 P6); tiempo de pared, sin medir (obstáculo O-3). (3) D2, la
descartada, pierde nada de cobertura y gana un hash que no agrega información; D3 pierde la detección. (4) Reversible.

**Condición de revisión:** la de `ARQ`: un rojo provocado con un contrato cambiado y la versión sin subir **no** falla
con la instantánea. Ese día se reevalúa, y la clave exacta sólo con ficha.

---

### 3.8 P6 y P8 — ¿La compuerta del contrato bloquea o avisa? ¿Y «contenido sobre el piso»?

**Bloquear o avisar.** `DEV` lo dice de las dos formas en el mismo informe (H-02: aviso en `diseño`; §3 P6: suite
obligatoria de `fw-ok`), y `REF` R2-08 propone «bloquea, y se dice».

- **G1:** la instantánea corre dentro de `fw-ok` y bloquea, **como prueba propia del producto en la suite del puente**.
- **G2:** corre en modo aviso hasta `candidata` (VPI §3.2, letra de M-7).

| Alt. | K-S ×2 | K-P ×2 | K-E ×2 | K-D ×2 | K-R ×1 | K-C ×1 | K-V ×1 | Total |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| **G1** | **3.** Una regla: rojo no se fusiona | **2.** Sin medir el tiempo | 2 | **3.** Es la lección que la guía enseña: EV001:17 («al no dispararse pruebas automatizadas puede romper funcionaldiades») | **2.** Un falso rojo frena fusiones; su frecuencia, sin medir | **3** | **3** | **28** |
| **G2** | **2.** Dos modos | **2** | 2 | **1.** Un aviso que no frena enseña lo contrario de P6 | **1.** Un contrato cambiado pasa en verde a `main` protegido (folio 023) | **3** | **3** | **21** |

**Recomendación: G1, con una condición de escritura.** VPI dice que **su** compuerta R13 corre en aviso antes de
`candidata`. Ser más estricto que una recomendación no es dejar de seguirla, **siempre que lo que bloquea sea una prueba
del producto y no se presente como la compuerta R13 de VPI**, que sigue rotulada «aviso hasta `candidata`» en la tabla de
gobierno. Si el jurado lee VPI §3.2 como mandato de modo aviso (y no como mínimo), G1 necesitaría ficha, y como el motivo
sería conveniencia, no se admitiría (Excepcion §3): entonces rige G2. **C-2: G2**, la más cercana a la letra de VPI.

**Cadena de G1.** (1) Cae en quien abre un PR que toca el puente. (2) Tiempo de pared: sin medir (O-3). (3) G2 pierde la
única detección antes de `main`; G1 pierde fusiones por un falso rojo. (4) Las dos son configuración del workflow:
reversibles.

**Contenido N sobre el piso declarado** (`DEV` H-04 frente a `REF` R2-08, «al tramo siguiente salvo medida»):

- **N1** (`DEV` H-04): compilar y correr el contenido contra el contrato del piso, con un puente simulado generado.
- **N2** (`REF` R2-08): al tramo siguiente; mientras tanto el piso se rotula «compatible en teoría con» (VPI §2.6, que
  `DEV` H-04 cita: «sin quién lo revalide, la frase correcta es "compatible en teoría con"»).
- **N3** `[AG]`: comprobar que cada nombre de método que el contenido pasa a `Call` está en el `contrato.json` del piso
  (D1). No mira la forma de los parámetros.

| Alt. | K-S ×2 | K-P ×2 | K-E ×2 | K-D ×2 | K-R ×1 | K-C ×1 | K-V ×1 | Total |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| **N1** | **1** | **1.** Sin medir | **3** | **1** | **3** | **1** | **3** | **19** |
| **N2** | **3** | **3** | **1.** El piso no lo revalida nada | **2.** Con el rótulo de VPI | **1.** El método faltante aparece en el `handshake`, ya activado | **3** | **3** | **25** |
| **N3** `[AG]` | **2** | **2.** Sin medir | **2** | **2** | **2.** Detecta el método faltante, no la forma | **2** | **3** | **23** |

**Empate N2–N3 (2 puntos).** El paso 4 no lo decide (las tres son reversibles en la demo, sin base instalada). **Se
recomienda N2**, por la regla de VPI que la hace conforme con el rótulo, y **N3 queda como la forma barata** si el jurado
quiere detección ya: su costo, sin medir, va como obstáculo O-3. **Condición de revisión:** el primer contenido que use
un método ausente en su piso declarado y llegue al `handshake` en una corrida de la demo.

La compuerta de publicación (`DEV` H-07) no la pondero: su parte (1), construir sólo desde una etiqueta de `main`, es el
invariante 1 de `Release-Y-Despliegue-Versionado` que `DEV` cita, y si esa convención rige no es una elección sino un
cumplimiento; su parte (2) sigue el destino de N2.

---

### 3.9 P12 — Declaración y uso de una capacidad nueva

El nivel (P0 de `SEG` H-02, P1 de `REF` R2-05) es del jurado. La dirección está en disenso de forma:

**Descartada antes de ponderar: C1, la letra del dictamen leída como «permiso antes que función»** (021:855-856). Un
binario que declara un permiso para una función que no tiene choca con dos textos que `REF` abrió: Play, «necessary to
implement current features … undisclosed, unimplemented», y Apple 2.5.19, «Don't include any hidden, dormant, or
undocumented features». E2 (citas en `REF` §1, fila P12). Es la lectura P0 del contrato: «mecanismo que una tienda
prohíbe».

- **C2** (`SEG` H-02, `REF` R2-05): la capacidad entra con el release del cascarón **y** con la semilla de ese release,
  que trae la función visible y descripta en las notas de revisión.
- **C3** (`VER` H-06): la capacidad es ejercible en el binario revisado por una pantalla del cascarón (XAML).

| Alt. | K-S ×2 | K-P ×2 | K-E ×2 | K-D ×2 | K-R ×1 | K-C ×1 | K-V ×1 | Total |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| **C2** | **3.** La semilla ya es «una versión completa» (021:402) | **2.** La semilla de E01 es un `index.html` mínimo, no un release (`ARQ` H-10 r1): sin medir como release | **3** | **3.** Una regla: «el binario trae lo que declara» | **2.** iOS 4.7, NO VERIFICADO (`SEG` H-07) | **3.** «Casi nada» (`REF` R2-05) | **3** | **30** |
| **C3** | **1.** Una segunda interfaz en XAML por capacidad | **2** | **1.** Cada capacidad, una pantalla nativa | **1.** Dos tecnologías de interfaz | **2** | **1** | **3** | **16** |

**Recomendación: C2.** No hay empate (14 puntos). Con C-min (§3.1) el problema casi desaparece: el uso se compila en el
cascarón con su pantalla (`REF` R2-05). **Condición de revisión:** una revisión de Play o de Apple observa la función
como no ejercible en el binario revisado. La rama iOS por 4.7.2/4.7.3 (`SEG` H-07) no tiene posición contraria y va a §4.

---

### 3.10 P13.7 — Una obligatoria con respuestas sin enviar

- **S1, dictamen:** el forzado no espera a vaciar el outbox (021:891-892).
- **S2, I0:** «con pendientes, sincronizar primero» (I0:428). Es «[criterio del sintetizador]: ninguna plataforma leída
  la documenta» (I0:240-242, citado por `ANA` H-07).
- **S3, `ANA` H-07:** S1 más un intento de envío oportunista antes de activar, que no condiciona la activación (forma de
  SAP `OnWillUpdate`, I6:123).

| Alt. | K-S ×2 | K-P ×2 | K-E ×2 | K-D ×2 | K-R ×1 | K-C ×1 | K-V ×1 | Total |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| **S1** | **3** | **2.** Outbox idempotente medido en r1 (E-ASD-1); la regla, de diseño | 2 | **2.** Hay que explicar por qué no I0 (`LSC` H-07) | **2.** El servidor tiene que aceptar versiones viejas (P13.4; en ODK, OPINIÓN autorizada, NO VERIFICADO en la doc) | **3** | **3** | **26** |
| **S2** | **1** | **1** | 2 | **2** | **0.** El encuestador con una fila rechazada no recibe nunca la obligatoria (E3 de `ANA` H-07); F006 queda sin cumplir | **1** | **3** | **16** |
| **S3** | **2** | **2** | 2 | **2** | **2** | **2** | **3** | **23** |

**Empate S1–S3 (3 puntos), y la cadena lo resuelve contra S3 por coherencia con §3.4.** Con F2 la activación ocurre en
el arranque en frío, **antes de mostrar**: un envío «antes de activar» se haría en el camino crítico del arranque y
rompería N = 0. Y si se mueve al momento en que la obligatoria queda verificada, con red, ya lo hace la sincronización
de P5, que envía el outbox cuando hay red. **S3 no agrega nada que P5 no haga, salvo en el instante que F2 prohíbe
bloquear.** **Se recomienda S1**, con la línea que pide `ANA` H-07: por qué no es la regla de I0. **Condición de
revisión:** una corrida en la que un pendiente quede sin enviar teniendo red entre la verificación de la obligatoria y
el arranque siguiente; eso sería un defecto de P5, no de P13.7.

---

## 4. Filas del mapa sin alternativas en pie

| Fila del mapa (`REF` §7) | Por qué no hay matriz | Qué queda |
| --- | --- | --- |
| P1, AOT | `VER` H-02 y `SEG` H-04 proponen lo mismo; nadie sostiene AOT | Contenido sin AOT, con comprobación. Con C-min (§3.1) no aplica |
| P2, retención | El número y su unidad no tienen posiciones opuestas (`FOR` H-05); el estado terminal sí, y va en §3.6 | Unidad y consumidor declarados (`FOR` H-05) |
| P2, retirados | `SEG` H-10 sin posición contraria (`REF` R2-10 la acepta) | Lista firmada de retiradas |
| P2, índice por mayor del puente | `ARQ` H-03, aceptado por `REF` (§3, P2) | Un índice por canal y por mayor. Sólo con A+datos |
| P4 | `ANA` H-05 y `REQ` H-07 coinciden: los pendientes no se borran al cerrar sesión. La cadena de `ANA` (P4) ya eligió la reversible | Confirmado con las dos reglas |
| P6, dos formas de merge | `DEV` H-01 y `REF` coinciden; F007 lo funda | Manual por default; automática con delegación |
| P7 | `FOR` H-07/H-08 y la fecha de MAUI (2027-05-11) sin posiciones opuestas | Confirmado con los agregados |
| P9 | Aprobado por el PO (folio 023) | No se toca |
| P10 | Las precisiones de `LSC` no tienen posición contraria; la convocatoria del académico es de la presidencia | — |
| P11 | Sin disenso | — |
| P12, iOS 4.7 y «sólo por el puente» | `SEG` H-07 y `ARQ` H-06 / `VER` H-05, sin posición contraria | Condicionado mientras siga NO VERIFICADO |
| P13, evolución y retenciones | `ANA` H-06, `REQ` H-05, `DEV` H-05 y `FOR` H-06/H-07 coinciden | Regla de evolución, retenciones separadas, roll-forward que no baja versiones |
| Objetivo, cláusula sin red | Es acto de la presidencia (`REQ` H-01) | — |

---

## 5. Dependencias entre decisiones

| Decisión | Depende de | Qué cambia si la otra cambia |
| --- | --- | --- |
| §3.2 canal de la definición (K2) | §3.1 | Con C-min o B pura, la pregunta desaparece |
| §3.3 umbral | §3.1 y §3.4 | Con C-min, el umbral pierde casi toda su presión (1,6–1,7 s medidos); con F3 haría falta un umbral propio para el arranque que espera |
| §3.4 forzado (F2) | — | Es la base de §3.10: S3 se descarta porque F2 activa antes de mostrar |
| §3.7 detección (D1) y §3.8 (G1, N2) | §3.1 | Con C-min no hay puente hacia código descargado; el contrato es el esquema de la definición, y D1 se aplica a ese esquema (`DEV` H-05) |
| §3.9 P12 (C2) | §3.1 | Con C-min, el uso se compila en el cascarón y C2 se cumple solo |
| Los 10 grupos de R2-03 | §3.1 | Existen sólo con A+datos; por eso el orden «núcleo común primero» (§3.1, punto 2) |

---

## 6. Obstáculos y medidas que faltan

Preguntas de una línea, hechas en este folio el 2026-10-25 (Cadena §3). No uso el g42 ni el emulador.

| Id | A quién | Pregunta | Destraba |
| --- | --- | --- | --- |
| O-1 | Presidencia, que tiene el teléfono de referencia | «Medir el peso de una definición de encuesta sola bajada por el canal firmado, frente al paquete entero de 3 395 072 B» | K-E y K-C de K2 (§3.2) |
| O-2 | Presidencia | «Correr la medida de `FOR` S-4: arranque en frío con `force-stop`, manifiesto fuera del camino crítico, `reportFullyDrawn` desde `Listo`, k corridas» | §3.3: el paso de U2 a U1 y el «lo medido lo cumple» |
| O-3 | Quien aplica | «Tomar el tiempo de pared de la instantánea del contrato (D1) y, si se quiere N3, de la comprobación de nombres de método, en el runner, con su primer rojo provocado» | §3.7 y §3.8 |
| O-4 | Quien pidió, por el lote (`REF` §3, P1) | «¿Las correcciones sin tienda incluyen pantallas y lógica (código), o alcanza con encuestas y datos?», con el precio de R2-03 y las dos lecturas escritas | §3.1. El default lo propone §3.1 y lo vota el jurado |
| O-5 | Quien pidió, por el lote (`FOR` S-3) | Valores de producto: cota del forzado, período de `expires` (intervalo máximo entre publicaciones) y conjunto de dispositivos soportados | §3.3, §3.4 y §3.5 |

Mientras O-1 a O-3 no lleguen, las celdas que dependen de ellas quedan «sin medir» y ninguna recomendación de este folio
depende sólo de esas celdas: cada una dice qué paso la decidió.

---

## 7. Resumen para el jurado

| Pregunta | Recomendación | Total (de 33) | Decidió | C-2 o segunda |
| --- | --- | --- | --- | --- |
| **P1, modelo** | Lote obligatorio; **núcleo común primero** `[AG]`; default sin respuesta: **(a) C-min** con A como extensión | C-min 26 · B pura 17 · A+datos 13 | La regla de la norma para una frase con dos lecturas (renglón 1) y el paso 3; el paso 4 no separa | **C-2: (b) A+datos**, si el jurado toma F004 como fuente de intención suficiente (lectura extendida del renglón 3, R2-01). Ninguna regla da (b) por su letra |
| P1, canal (sólo con A+datos) | **K2**, un índice y dos clases | 25 · 21 · 18 | Suma (4 de diferencia) y paso 4 | K1, si nunca se publica una definición sin contenido |
| P1, umbral | **U2**, marca propia, sin llamarla TTFD; las cifras son cota pesimista | 27 · 23 | Suma (4) | U1 cuando llegue O-2 |
| P2, forzado | **F2**, sólo arranque en frío, antes de mostrar si está verificado; los bloqueos, al mismo punto | 29 · 18 · 16 · 15 | Suma (11) | F3, si el PO exige el mismo arranque y acepta otro umbral |
| P2, `expires` | **X1**, valor y renovación sin revisor | 23 · 26 (X3) · 15 | **Paso 4**: X3 suma más y es irreversible | X2 |
| P2, revocación | **R2**, el cliente rechaza las revocadas; publicar la revocación es diseño | 23 · 22 · 16 | Paso 4 (empate con R0) | R1 en producción |
| P2, estado terminal | **T1**, pantalla del cascarón | 22 · 20 | Paso 4 (empate) | T2, con la corrida de `VER` |
| P3, detección | **D1**, instantánea | 27 · 24 · 18 | Paso 4 (empate con D3) | D3, admisible por VPI en `diseño` |
| P6/P8, bloquear | **G1**, como prueba del producto y no como la compuerta R13 de VPI | 28 · 21 | Suma (7) | **G2**, si el jurado lee VPI §3.2 como mandato |
| P8, piso | **N2**, «compatible en teoría con» | 25 · 23 · 19 | Regla de VPI (empate con N3) | N3 `[AG]`, si cuesta una prueba |
| P12 | **C2**, mismo binario; C1 descartada por las citas de Play y Apple | 30 · 16 | Suma (14) | — |
| P13.7 | **S1**; S3 se disuelve en P5 por coherencia con F2 | 26 · 23 · 16 | Cadena (empate) | — |

**Tres cosas que este folio agrega y que el jurado no tenía:**

1. **P1:** las dos reglas que se citaron para el default apuntan en sentidos opuestos, y la única escrita para este caso
   (renglón 1) da (a). Con el precio de r2 la suma separa 26 de 13, y A+datos sólo pasa delante con la escalabilidad a
   peso 15.
2. **P1, orden:** construir primero el núcleo común a A+datos y C-min hace que el default casi no importe y no tira
   trabajo en ninguna rama.
3. **P3/P6:** VPI pone la detección del contrato (R13) en `candidata` y su compuerta en modo aviso antes de esa fase
   (M-7). Bloquear es posible sin ficha sólo como prueba del producto, y hay que escribirlo así.

Sigue: jurado de veredicto de la ronda 2, con este folio entre sus insumos · presidencia · Cierra con: folio informe del jurado de veredicto r2

Sigue: incorporación del siguiente informe y resolución · presidencia
