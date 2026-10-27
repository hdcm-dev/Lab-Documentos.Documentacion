| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-10-25 |
| Autor | Comisión Analista de sistemas y decisiones (ronda 2) |
| Corrige | — |

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Rol | Analista de sistemas con criterios y análisis de las decisiones · comisión de la ronda 2 |
| Ronda | 2 |
| Fecha | 2026-10-25 |
| Carta | `evidencia/021-carta-r2-analista-sistemas-y-decisiones.md` (guardada verbatim antes de empezar) |
| Norma | `<base de conocimiento>/Knowledges/Knowledge-Mesa-De-Expertos-A-Pedido.md` 3.1 |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | Cabecera y §0 (líneas 1–111). Por la fila «Sos una comisión…» del Mapa de carga: la carta (§5.2, entera), §2.2 con su subsección, §3.2, §3.3 y §4 |
| Documentos cargados | `Cadena-De-Consecuencias` 2.0: §2 (la carta lo pide antes de recomendar entre opciones) · `Escalas-De-Juicio` 1.0: §3.2, §3.3 y §3.4, por remisión de la carta («la escala está en Escalas-De-Juicio §3.3») |
| No cargados | `Excepcion-A-Un-Conocimiento` (no propongo dejar de seguir ninguna convención: no hay ficha) · `Mesa` (ninguna remisión del texto de mi acto la pide) |
| Insumos leídos | Evidencia 001 desde la línea 4; folios 003, 004, 005, 006, 007, 008 §2, 022; dictamen 021 (cabecera, §1, §2.5, §2.10, §5 «Premisas», P1, P2, P4, P5, P13, §6, §7); 020 §2, §3 P1/P4/P5, §5–§7; 019 fila R-15; 018 fila H-09 y §3.2; 013 (mi informe r1) matriz y P1/P4/P5. Investigación: I0 entero; I1 y I6 por `grep` en las filas que cito; I2 fila Expo y Shorebird; I5 fila de conflictos |
| Medios propios | Lectura y `grep -n`/`grep -c` sobre el árbol del expediente y de la investigación. Ningún dispositivo, ningún compilado, ninguna fuente externa nueva: toda afirmación de industria sale de un dossier I* y de la fuente primaria que ese dossier cita |
| Limitación declarada | Esta comisión escribió la matriz de r1 que R-15 objetó (folio 013). Rehacerla acá absorbe la condición de 008 §2 por decisión de la presidencia; no voto nada y cada celda nueva lleva su evidencia para que el jurado la pueda contrastar sin confiar en mí |
| Rótulo | No nombra repositorios privados, hosts, direcciones ni series de dispositivos |

# Informe de la comisión de análisis de sistemas y decisiones — ronda 2, expediente 0001

## Índice

0. [Objetivo con origen, condición de 008 §2 y nomenclatura](#0-objetivo-con-origen-condición-de-008-2-y-nomenclatura)
1. [Qué del dictamen r1 confirma la investigación y qué contradice](#1-qué-del-dictamen-r1-confirma-la-investigación-y-qué-contradice)
2. [Hallazgos](#2-hallazgos)
3. [Propuesta por pregunta](#3-propuesta-por-pregunta)
4. [Lo que revisé y está bien](#4-lo-que-revisé-y-está-bien)
5. [Solicitudes de convocatoria y obstáculos](#5-solicitudes-de-convocatoria-y-obstáculos)

---

## 0. Objetivo con origen, condición de 008 §2 y nomenclatura

**Objetivo (folio 003, campo OBJETIVO).** Cada cláusula tiene origen en el prompt. Lo único que el dictamen trata como
fijo y el objetivo todavía no trae es la operación sin red [F005]; ya es R-03 (`PROCEDE`) y la presidencia tiene la
señal (021 §7, «Enunciado»). No lo cuento de nuevo. Lo que **el dictamen** da por fijo sin origen es mi primer hallazgo
(H-01: «un solo canal» para la definición).

**Condición de 008 §2.** El jurado de composición escribió (008:72-74): si «la matriz de criterios resulta
insuficiente (hallazgo `PROCEDE` del refutador sobre criterios sin fuente o sin peso), la comisión separada de
criterios de decisión entra en el ciclo 2». En r1 procedieron R-15 (P1, celda apoyada en el borrador; 021:244) y
`ASD` H-11 (P2, tablas sin pesos ni fuente; 021:153). **La condición se cumplió.** La presidencia no convocó una
comisión aparte y la absorbe esta carta. Lo hago así: los pesos se fijan **antes** de puntuar y con fuente (§1.1);
ninguna celda se apoya en el borrador `Framework-APP.md`; cada celda lleva su evidencia.

**Nomenclatura que uso** (comprobada con `grep -c` sobre 019, 020, 021 e I0; ver H-09):

| Nombre en este informe | Qué es | Cómo la llama cada folio |
| --- | --- | --- |
| **C-min** | Definición de la encuesta como datos versionados, dibujada por componentes Razor **compilados en el cascarón** (`BlazorWebView`). Las pantallas no se actualizan sin tienda | «C mínima» en 019 (10 veces); «C-min» en 020 (15) y 021 (5); «B» en `ARQ` E02-B |
| **A+datos (1 canal)** | Pantallas Blazor WASM descargadas y servidas por `HybridWebView`; la definición viaja como archivo de datos con versión propia **dentro del paquete de contenido** | Lo que adopta 021 (P1, líneas 305-318); «C-full» en 020 (3 veces), que 021 dice corregir |
| **C de I0 (2 líneas)** | Lo mismo, pero la definición se publica **aparte** del contenido, con su propia línea de publicación: «Definiciones de encuesta (datos, con versión propia)» como pieza separada del zip de contenido en el servidor (I0:146-147, 159-160) y «staging de definiciones como el borrador de Central» (I0:416) | «opción **C**» en I0:67 y I0:415 |
| C de N1 | A más un renderizador en el **cascarón**: dos runtimes de UI | 021 la descarta (líneas 362-363) |

---

## 1. Qué del dictamen r1 confirma la investigación y qué contradice

### 1.1 Matriz de P1 rehecha

**Pesos, fijados antes de puntuar.** Tomo los siete criterios de 020 §2 **sin cambiarlos**, porque ese folio los fijó
antes de su primera matriz y cada uno trae fuente (el pedido, EV001:39 y :33; Diátaxis; la lectura P0 del contrato;
§2.2 de la norma; Cadena §2 paso 4). No agrego ninguno: un criterio inventado después de ver los datos sería
puntuar al revés. Escala 0–3. K-S, K-P, K-E y K-D pesan 2; K-R, K-C y K-V pesan 1. Máximo 33. Una diferencia de 3
puntos o menos es empate y la decide la cadena (020 §2, «Cómo uso la suma»).

**Descartes antes de puntuar, con su ancla.**

- **D, sitio remoto:** compuerta F005. La referencia «cancela toda navegación» sin red (E2, `CRC` §3.1, que el
  dictamen recoge en 021:341-342). Mientras F005 sea premisa del dictamen (021, «Premisas»), D no se puntúa.
- **A pura, con la encuesta como código:** dominada por A+datos en P13. La versión de la encuesta queda atada a la del
  código (`CRC` H-09, 018:49), y la industria versiona la definición aparte: ODK exige cambiar `version` en cada
  publicación (I0:250; fuente primaria: ODK Docs, «Managing Forms in Central», I1[2]).
- **C de N1:** dos renderizadores (021:359). No la vuelvo a abrir.

**Matriz.** Celdas con evidencia; ninguna cita el borrador.

| Alt. | K-S ×2 | K-P ×2 | K-E ×2 | K-D ×2 | K-R ×1 | K-C ×1 | K-V ×1 | Total |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| **C-min** | **2.** Un solo runtime (`BlazorWebView`), sin WASM ni interceptor. Suma un esquema y un renderizador propios (E02-B, `ARQ` §7.1). Es la forma de toda la familia de encuestas: «motor genérico» de tienda más «definiciones como datos» (I0:34-38; ODK Docs [5], Dimagi [20][21]) | **3.** E02-B dibujó la encuesta desde un JSON en el g42 en 1,6–1,7 s (E1, `ARQ` §7.1, dato). El canal firmado se midió con un zip (E01 §6.2; E-SEG-1) y es indiferente a lo que lleva | **2.** Encuestas nuevas o corregidas sin tienda (F005; ODK). Pantalla o lógica nueva = cascarón por tienda: Microsoft, «After the app is built, the .NET code Web View content sources can't change» (I0:184; Microsoft Learn, «ASP.NET Core Blazor Hybrid», I4[3]). Límite análogo en la industria: ODK Central 2024.3 exige Collect 2024.3 para *Entities* (I0:283; foro ODK, Sadiq_Khoja, I1[14]). **Reemplaza la celda que R-15 objetó** (FAPP:95) por estas dos fuentes externas | **3.** Es «Blazor Hybrid» en el sentido de Microsoft (I4[3]); un runtime; precedente ODK que el lector encuentra documentado | **2.** No baja código: desaparecen `.wasm` frente a Apple 2.5.2 (NO VERIFICADO, I0:64-65) e iOS ≥ 16.4. No se encontró rechazo de tienda por bajar formularios o metadatos, «ausencia de evidencia, no evidencia de ausencia» (I0:334). Los datos que dirigen la UI son entrada no confiable y van firmados (`SEG` P1, dato) | **2.** Prototipo E02-B; esquema y renderizador por construir | **2.** Pasar a A después exige un cascarón nuevo por tienda (cambia de `BlazorWebView` a `HybridWebView`); sin base instalada hoy, se revierte. La definición como datos se conserva igual | **26** |
| **A+datos (1 canal)** | **1.** Dos runtimes, interceptor `WebResourceRequested`, puente (E01 §7, C-1…C-4, en 021:311-315), más esquema y renderizador genérico dentro del contenido | **2.** A medida en el g42: v1→v2 sin reinstalar, sha adulterado rechazado (E01 §6.2); TTFD 3 692–4 871 ms (E02-R, 021:330). El renderizador genérico de la definición dentro del WASM: **sin construir ni medir** | **3.** Cualquier página Razor y cualquier encuesta sin tienda (E01 §6.2). El único límite es el manifiesto, que alcanza a las tres alternativas por igual (I0:272-277; Expo «Changes to the Info.plist cannot be updated over-the-air», I7[5]) | **1.** «Blazor Hybrid» de Microsoft dice lo contrario de lo que hace A (I4[3]); el dictamen lo mitiga con glosario (021, «Premisas»), pero el lector igual encuentra la documentación oficial en contra. La postura oficial es tratar el contenido del WebView como no confiable y empaquetarlo (I0:192-195; Microsoft Learn, «Blazor Hybrid security considerations», I4[22]) | **1.** `.wasm` descargado: ninguna política nombra WebAssembly, NO VERIFICADO (I0:64-65, 336; Apple App Review Guidelines [1], DPLA 3.3.1(B) [2]). WebView ≥ 94; iOS ≥ 16.4; unos 2 s más que C-min (021:365-370) | **1.** E01 existe; firma y activación atómica diseñadas (E-SEG-1, E02-R); falta el renderizador en el contenido | **2.** Se reduce a C-min con un cascarón nuevo; sin base instalada, reversible. Pasar luego a dos líneas exige que el cascarón acepte un segundo índice: hoy cada canal es un índice y «el cliente rechaza el de otro canal» (021:387) | **18** |
| **C de I0 (2 líneas)** | **0.** Todo lo de A+datos, más una segunda línea de publicación firmada y la regla «definición exige motor ≥ X», que la industria necesita (CommCare *Compatibility Map*, I1[31]; ODK [9]) | **1.** Cada pieza medida por separado; la segunda línea, sin construir ni medir | **3.** Igual que A+datos | **1.** Igual que A+datos, más un concepto (la línea propia de definiciones) que tiene precedente enseñable (ODK publica formularios sin tocar Collect, I0:106) | **1.** Los de A+datos. Suma riesgo de compatibilidad definición↔motor (Survey123 BUG-000144445, I1[34]) y le saca riesgo de código a cada corrección de encuesta | **0.** Los costos de A+datos más el segundo canal | **3.** Fundir las dos líneas en una es borrar un índice | **14** |

**Lectura.**

- **Por suma, C-min queda primera (26 frente a 18).** A+datos pasaría delante sólo si K-E pesara más de 10, cinco
  veces cada uno de los otros criterios del pedido (C-min = 22 + 2w; A+datos = 12 + 3w; iguales en w = 10). El pedido
  enumera simplicidad, practicidad y escalabilidad sin jerarquía (EV001:39).
- **El dictamen no elige A+datos por la matriz, sino por la compuerta de su premisa:** la lectura (b) de R-01, «las
  pantallas y su comportamiento, además de los datos» (021:298). C-min la incumple. Es correcto que una compuerta
  mande sobre la suma, pero el dictamen no lo declara así. Además, el fundamento de esa compuerta tiene un error
  refutable (H-02).
- **Dentro de la lectura (b), A+datos (1 canal) le gana a C de I0 por 4 puntos.** No es empate. **Confirmo «un solo
  canal»**, pero con origen y costo declarados (H-01), porque el dictamen lo da por fijo.
- **Reversibilidad (Cadena §2, paso 4).** Las tres son reversibles mientras no haya base instalada, así que el paso 4
  no desempata. Lo que sí separa es el **paso 3, qué pierde cada una frente a la lectura que el PO no confirmó**
  (§3, P1).

### 1.2 Por pregunta

| Pregunta | Qué dice el dictamen r1 | Qué confirma la investigación (dossier → fuente primaria) | Qué contradice o no cubre |
| --- | --- | --- | --- |
| **P1** | A con la definición como datos, en un solo paquete (021:305-318). Funda la lectura (b) en que «una app ya baja datos sin tienda, así que la lectura (a) vacía el requisito» (021:230) | Que la definición vaya como datos versionados es la práctica documentada: «el único patrón documentado que junta "definición por datos + sin red + sincronización + versión vieja" es el del formulario versionado» (I0:110-113, criterio del sintetizador sobre ODK [5][6], CommCare [20][21]). Que exista una familia OTA que baja código interpretado (Expo, Capgo, Shorebird) y deja lo nativo a la tienda (I0:39-41; Expo «Runtime versions», I2[1]) | **Contradice el fundamento de 021:230.** La industria llama «actualizar la aplicación» a bajar definiciones sin tienda: en CommCare la «aplicación» son «formularios, flujos de casos, multimedia», publicada aparte del programa (I1:55), y la página que lo documenta se llama «Ways to Update an Application» (Dimagi, I1[29]). Por lo tanto (a) no vacía el requisito: es una lectura con práctica de industria (H-02). **No cubre** la separación de líneas que propone I0 (H-01) |
| **P4** | Entrada local y sesión separadas; sin período de gracia; outbox con dueño; demo sin IdP (021:514-545) | Que el login sea el momento del chequeo y de la primera sincronización: CommCare «checks for updates in the background immediately after the user logs in … applied the next time the user logs in» (I1:70; Dimagi [29]); D365 FS, primera sincronización al loguear (I0:206; Microsoft Dynamics 365 Blog [128]). Bloquear sólo el **ingreso nuevo** por cascarón viejo y dejar la sesión en curso: ServiceMax (I6:62; PTC «Managing Login Settings», I6[27]). Que lo pendiente no venza: Survey123 *Outbox* sin vencimiento (I1:56; Esri, ZacharySutherby, I1[38], OPINIÓN) | **No cubre** qué pasa con los pendientes del usuario que cierra sesión y no los envía. La industria registra el riesgo: ServiceNow Zurich pierde lo guardado en caché si vence sin sincronizar (I0:252; ServiceNow Docs [138]); SAP MDK borraría almacenes al cerrar sesión, NO VERIFICADO (I6[17]) (H-05). **No cubre**: ODK usa un QR de App User como autenticación sin contraseña y configuración a la vez (I1:264; ODK Docs, «Importing and exporting settings», I1[4]), un «logueo» sin IdP que la demo podría ejercitar (H-08) |
| **P5** | Outbox transaccional, idempotente, con dueño y versiones; orden por entidad; carta muerta visible; C2 + «último gana» declarado por acción; EF Core (021:547-584) | Conflictos por registro con política configurable: D365 FS (I0:419; Microsoft Learn, «Configure offline data synchronization» [127]). Cola de errores visible: SAP `ErrorArchive` (I6:59; SAP Help «App Update» [129], tutorial [130]). Arrancar siempre con lo local: Expo, Shiny (I0:419) | Opiniones en ambos sentidos sobre «último gana»: kobieps, «sufficient for 95% of use cases», que I5 marca como percepción y no medición (I5:170, 174); LAC-Tech: «washing your hands of it» (I5:171). Ninguna contradice C2. La idempotencia de la cola como práctica queda NO VERIFICADA en la investigación (I0:419); el dictamen la tiene **medida** (E-ASD-1), así que la investigación no la debilita |
| **P13** | Versión propia de la definición; respuesta atada a su versión desde que empieza; copia local de definiciones con pendientes; servidor acepta versiones publicadas no retiradas; carta muerta; sincronización idempotente; ningún forzado descarta pendientes ni espera el outbox (021:878-892) | Los ítems 1, 2, 4 y 5: ODK `orx:version` en la instancia (I0:250; XForms Spec, I1[5]); envíos previos «remain unchanged» (ODK Docs [6]); borradores atados a su versión (ODK, Kobo; foro ODK, LN 2025-03-24 [11], OPINIÓN autorizada); el servidor acepta versiones publicadas no borradas (foro ODK, LN 2021-04-20 [10], **OPINIÓN, NO VERIFICADO en la documentación oficial**). ServiceMax: la *Config Sync* «preserves the synchronized and yet-to-be synchronized data» (I6:62; PTC [28]) | **No cubre** la regla de evolución entre versiones: lo aditivo convive y lo destructivo rompe; «tipo de campo publicado no cambia (salvo a texto)» (I0:250, 258-261; ODK Docs [6]; Kobo [17]) (H-06). **Diverge de I0** en P13.7: I0 propone «con pendientes, sincronizar primero» (I0:428), pero la rama F–H de su diagrama es «[criterio del sintetizador]: ninguna plataforma leída la documenta» (I0:240-242). Mantengo el dictamen (H-07). Y el ítem de I0 «el servidor no retira una versión mientras haya respuestas pendientes» (I0:264-265) no es implementable: el servidor no ve lo pendiente en teléfonos sin red. La forma del dictamen (retiro explícito y anunciado, carta muerta) es mejor |
| **Folio 006 / momento** | N = 0; consulta en segundo plano al arrancar en frío, al reanudar y al loguear; activación en el próximo arranque en frío; `mandatory` en el próximo punto seguro; sin red no se fuerza; bloqueo sólo si el servidor rechaza la versión en uso (021:405-423) | N = 0 y aplicar en el próximo arranque: Expo `ON_LOAD` con `fallbackToCacheTimeout` 0 por defecto (I2:50; Expo, «app.json» [2]); Shorebird y Capawesome aplican en el siguiente inicio (I2:58-59). «Bajar no es aplicar» (I0:211-214). Forzar sólo con red: CommCare *Forced* «Under ideal conditions (proper internet connectivity…)» y al reloguear (I1:161; Dimagi [28]). Descartar IMMEDIATE: CodePush `mandatoryInstallMode` IMMEDIATE por defecto (I2:51) | **No cubre** cuándo se aplica el bloqueo por versión rechazada ni el del cascarón: la industria bloquea **al ingreso nuevo** y tolera la sesión en curso (ServiceMax, I6:62, 79; Oracle [142]); SAP deja postergar con `OnWillUpdate` (I6:123) (H-03). **No declara** que con N = 0 el «forzar al iniciar» de F006 se cumple recién en el inicio siguiente a la descarga, ni evalúa la espera acotada solo para la obligatoria: Shiny bloquea antes de mostrar si la versión instalada es menor que `minimumVersion` (I0:204; README de shinyorg/appdevicebridge [106]); Expo admite hasta 300 000 ms (I2:50) (H-04) |

---

## 2. Hallazgos

| Id | P0–P3 | Ancla (E1–E4 o C) con cita | Hallazgo | Impacto | Dirección de la corrección |
| --- | --- | --- | --- | --- | --- |
| **H-01** | P2 | **E2** 021:316-317: la definición «viaja **dentro del paquete de contenido** (un solo canal)», sin fuente ni alternativa evaluada. **E2** 018:49 y 018:88: `CRC` H-09, que el dictamen cita como origen, separó los ejes justamente porque con la encuesta como código «cada corrección de la encuesta es un release del paquete WASM (zip de 3,39 MB, E01 l. 157)». **E2** I0:146-147, 159-160, 416: la C de I0 publica las definiciones como pieza aparte | Lo que el dictamen da por fijo sin origen. Con un solo canal, la versión de la encuesta queda separada de la del código (bien para P13), pero **el costo de corregirla no**: cada corrección es una versión nueva del contenido, baja el paquete entero al teléfono del encuestador y pasa por la compuerta de código del PR | El jurado lee un costo de campo que no está escrito. Un lector de la guía puede implementar las dos líneas, porque I0 (que el PO pidió y leyó) las recomienda: lecturas divergentes acotadas | Declarar en P1 que «un solo canal» lo decide la matriz de §1.1 (18 frente a 14), con su costo por corrección (paquete completo comprimido, compuerta de código) y la **condición de revisión**: (i) la primera corrección de encuesta que no puede salir porque la compuerta de contenido está en rojo por un cambio de código ajeno, o (ii) medir que el paquete con sólo la definición cambiada pesa lo mismo que uno completo y que eso traba la adopción en campo. Si el índice por archivo con `sha256` (021:388) permitiera bajar sólo los archivos cambiados, el costo baja a la definición: hoy queda NO VERIFICADO (el dictamen dice «descomprimir en `staging/`», 021:396) |
| **H-02** | P1 | **E2** 021:230: «una app ya baja datos sin tienda, así que la lectura (a) vacía el requisito». **E2** externa: I1:55, en CommCare la «aplicación» son formularios, flujos de casos y multimedia, publicada aparte del programa; I1:70 y Dimagi «Ways to Update an Application» (I1[29]): la industria llama «actualizar la aplicación» a bajar esa definición sin tienda. **E4** Mesa-De-Expertos-A-Pedido 3.1 §0, renglón 1: «Una frase con dos lecturas se escribe con las dos y se toma la que menos agrega, declarada» | El fundamento con que el dictamen descarta la lectura (a) no resiste la investigación: (a) es una lectura con práctica de industria detrás, no un requisito vacío. Hay dos lecturas con literal del PO: (a) F005 «si la encuesta cambia o se arregla» (en ODK, arreglar la encuesta es publicar una definición nueva); (b) F004 «cambiar la aplicación web server». P1 queda decidida por esa lectura y no por la matriz, que favorece a C-min 26 a 18 (§1.1). Además el lote (021 §6) no se la pregunta al PO, aunque 020 §7 la había puesto como condición de revisión («lectura (b) de R-01») | Si el PO quería (a), la guía y la demo se construyen sobre A+datos y cargan unos 2 s de arranque, 9,13 MB por versión retenida, `.wasm` frente a Apple (NO VERIFICADO) e iOS ≥ 16.4, sin necesidad. Si el dictamen hubiera elegido C-min y el PO quería (b), habría que reescribir pantallas, guía y demo. P1, P3, P8, P9 y P13 dependen juntas de esta lectura (020 §5) | Corregir el fundamento de la premisa: retirar «vacía el requisito»; escribir las dos lecturas con su literal y decir que **P1 la decide la compuerta (b), no la suma**. Sumar al lote (021 §6) la pregunta de una línea: «¿Las correcciones sin tienda incluyen pantallas y lógica nuevas (código), o alcanza con encuestas y datos?». **SI NO RESPONDÉS: (b), A+datos**, por la cadena de §3 (P1): A+datos cumple las dos lecturas y C-min sólo una. Condición de revisión: el PO responde (a), y entonces P1 pasa a C-min con esta matriz |
| **H-03** | P1 | **E2** 021:421: «Bloqueo · Sólo bloquea si el servidor **rechaza** la versión de contenido en uso», sin momento. **E2** 021:451: se descarta «Forzado `IMMEDIATE`: pierde la entrada en curso». **E2** 021:422 (cascarón): «Sin red no bloquea», sin momento con red. **E3**: el encuestador está a mitad de una encuesta con red; la consulta de reanudación (021:410) devuelve «versión rechazada»; el bloqueo inmediato es, de hecho, un IMMEDIATE y pierde la entrada en curso | Los dos caminos que bloquean (contenido rechazado y cascarón bajo el mínimo) no tienen punto seguro, aunque el forzado sí lo tiene (021:418). Tampoco se dice si «rechazar una versión de **contenido**» rechaza las respuestas tomadas con ella, que llevan esa versión desde que se encolan (021:557, P5 «Outbox»). La industria bloquea **al ingreso nuevo** y tolera la sesión en curso con un aviso: ServiceMax (I6:62, 79; PTC [27]); Oracle (I0:206; [142]). SAP deja postergar con `OnWillUpdate` (I6:123; SAP Help [129]) | Dos implementadores hacen cosas distintas: uno corta la encuesta en curso y otro la deja terminar. Uno rechaza en el servidor las respuestas encoladas con la versión rechazada (las pierde o las manda a carta muerta) y otro no | Para los dos bloqueos, el mismo **punto seguro** del forzado: se bloquea al próximo arranque en frío o al terminar la encuesta en curso, con aviso, y nunca a mitad de una captura. Declarar que rechazar una versión de contenido **no** rechaza las respuestas tomadas con ella: sólo las afecta retirar una versión de **definición** (P13.4–5). Precedente: ServiceMax, alerta descartable durante la sesión y bloqueo al reingresar |
| **H-04** | P2 | **E2** F006: «se puede forzar a que el usuario cuando inicie la apliación actualice la apps». **E2** 021:409, 411 y 418: N = 0, activación en el próximo arranque en frío y obligatoria en el próximo punto seguro. **E2** 021:330: TTFD medido de 3 692 a 4 871 ms frente al umbral de 5 000 ms (021:328). **E2** I0:204 (Shiny: obligatoria «antes de mostrar»; [106]) e I2:50 (Expo `fallbackToCacheTimeout` hasta 300 000 ms) | Con N = 0, el «forzar al iniciar» de F006 se cumple en dos tiempos: el arranque que descubre la obligatoria la baja, y la aplica en el punto seguro siguiente. El dictamen no lo dice y no evalúa la alternativa de la industria (esperar un tiempo acotado sólo para la obligatoria). Además, el login (F004) no figura como punto seguro de activación, aunque CommCare aplica «the next time the user logs in» (I1:70; [29]) | El PO puede leer que su ventaja (F006) quedó cumplida «al iniciar» cuando se cumple un inicio después. La guía no tiene la tabla de casos de uso del momento (§3, «Folio 006») | Escribir la tabla de casos de uso de §3 en P2 y en la guía. Descartar la espera acotada por cadena: cae en el arranque de **todos** los usuarios con red. La única medida del costo es 1,1 s con servidor que responde error (`VER` H-06, que el jurado votó como E1 en 021:98, dato), y 4 871 + 1 100 = 5 971 ms > 5 000 rompe el umbral del propio dictamen en la corrida medida más lenta. Sumar el login con cuenta como punto seguro de activación **si** ocurre antes de cargar el contenido (condicional a P4) |
| **H-05** | P1 | **E2** 021:526: «Al cerrar sesión con pendientes se avisa y se ofrece enviar primero. Nunca se envía con otra identidad»; no dice qué pasa si el usuario no acepta o no hay red. **E3**: A tiene 3 encuestas encoladas sin red y cierra sesión rechazando «enviar primero»; entra B en el mismo teléfono. Las filas de A pueden quedar (¿visibles para B? ¿se envían cuando A vuelva?) o borrarse | La retención de los pendientes del usuario que sale no está decidida. La industria registra justamente esta pérdida como riesgo: ServiceNow Zurich pierde lo guardado en caché si vence sin sincronizar (I0:252, 391-392; ServiceNow Docs [138]); SAP MDK borraría almacenes al cerrar sesión (NO VERIFICADO, I6[17]); JessicaCelis (Esri, 2017, OPINIÓN): «all of my drafts were missing … You can imagine my horror» (I0:392; [29]) | Un implementador borra la base al cerrar sesión (la forma corriente de «cerrar sesión = limpiar») y pierde datos de campo sin aviso. Otro los conserva y se los muestra a B | Decidir en P4 y P5: cerrar sesión **no borra** filas pendientes; quedan con su dueño, invisibles para otra identidad, y salen cuando ese dueño vuelve a autenticarse con red. Borrarlas es un acto explícito del dueño, con confirmación que dice cuántas se pierden. Así lo que el dictamen ya decidió («nunca se envía con otra identidad») se extiende a la retención |
| **H-06** | P1 | **E2** 021:878-892: P13 versiona la definición y acepta versiones viejas, pero no dice qué puede cambiar entre versiones. **E2** externa: «tipo de campo publicado no cambia (salvo a texto)» (I0:250; ODK Docs, «Managing Forms in Central» [6]); aditivo convive, destructivo rompe la unión de datos (I0:258-261; criterio de I1 sobre [6][16][28]); Kobo: cambiar nombres de opciones puede «make data inconsistent across form versions» ([17]) | Con P13.4 (el servidor acepta v1 y v2 a la vez) y sin regla de evolución, la v2 puede renombrar o cambiar el tipo de un campo, y el receptor no sabe unir las respuestas de v1 y v2 | Dos implementadores (o dos autores de encuestas) divergen: uno renombra campos y el receptor rompe la exportación, otro no. La guía enseña P13 sin la mitad que evita el defecto que ODK ya documentó | Sumar a P13 la regla de evolución: dentro de un mismo `encuestaId`, el nombre y el tipo de un campo publicado no cambian; agregar preguntas y aflojar restricciones sí. Un cambio destructivo es un `encuestaId` nuevo o una migración explícita en el servidor. La compuerta del PR puede validarlo comparando el esquema de la definición nueva con el de la publicada (solicitud a integración y pruebas, §5) |
| **H-07** | P3 | **E2** I0:428: «Forzar contenido al iniciar **con red y sin pendientes**; con pendientes, sincronizar primero». **E2** I0:240-242: esa rama es «[criterio del sintetizador]: ninguna plataforma leída la documenta». **E2** 021:891-892 (P13.7): «El forzado no espera a vaciar el outbox» | El dictamen y la síntesis que el PO leyó dicen lo contrario y el dictamen no lo explica. **Mantengo P13.7**, por cadena: con «sincronizar primero», el costo cae en el encuestador que tiene una fila rechazada (412 o carta muerta), porque el forzado no se aplica nunca o queda esperando al servidor. Con P13.7, el costo cae en el servidor, que tiene que aceptar versiones viejas, y eso ya lo decide P13.4. SAP, lo más cercano que documenta la industria, usa `OnWillUpdate` para **guardar o cerrar almacenes antes de aplicar**, no para vaciar la cola (I6:123; [129][130]) | Un lector que tome la síntesis como guía implementa el bloqueo que P13.7 descarta | Agregar en P13.7 una línea con el porqué y con la diferencia frente a I0. Agregar un **intento de envío oportunista** antes de activar, que no condiciona la activación: es la forma de `OnWillUpdate` |
| **H-08** | P2 | **E2** 021:529-530: «Sin IdP: la sesión por dispositivo del caso base. Login, desbloqueo y el disparador "al iniciar sesión" van a la guía, rotulados "no ejecutado en la demo"». **E2** externa: ODK usa un QR de App User como autenticación sin contraseña y configuración del dispositivo a la vez (I1:264; ODK Docs, «Importing and exporting settings», I1[4]) | La señal del PO de F004 («se actualizan internamente al iniciar un logueo nuevo») queda sin ejercitar en la demo. Para ejercitarla no hace falta un IdP: la industria tiene un inicio de sesión de dispositivo sin contraseña ni proveedor | La demo no muestra uno de los tres momentos que el PO nombró (abrir, logueo, forzado). Es una pérdida acotada: queda en la guía como «no ejecutado» | Evaluar, como etapa opcional de la demo, un «inicio de sesión de dispositivo» por código o QR contra el receptor didáctico, que dispare la consulta de F004 y sea punto seguro (H-04). Costo sin medir: es un obstáculo de una línea a la presidencia (§5). Condición: si cuesta más que una etapa de la guía, queda como está |
| **H-09** | P2 | **E1** `grep -c` sobre el expediente y la investigación: «C mínima» 10 veces en 019; «C-min» 15 en 020 y 5 en 021; «C-full» 3 en 020 y 1 en 021; «C de N1» 2 en 021; «opción **C**» en I0:67 y I0:415; «híbrido (C)» en 003 (P1). **E2** 021:359-362: el dictamen descarta «C de N1» y corrige «C-full», y adopta lo que I0 llama «C» con el nombre «A, con la definición de la encuesta como datos» | La misma letra nombra al menos cuatro cosas: la C del contrato (híbrido), la de N1 (dos renderizadores), C-min (sin pantallas actualizables) y la C de I0 (que es, salvo el canal, lo que el dictamen adopta) | El PO lee en I0 «recomendamos C» y en el dictamen «se descarta C». El lector de la guía hereda los nombres | Un nombre único para el modelo adoptado, en el dictamen y en el glosario de la guía, y una tabla de equivalencias como la de §0 de este informe |

**Conteo:** 9 hallazgos. P0: 0. P1: 4 (H-02, H-03, H-05, H-06). P2: 4 (H-01, H-04, H-08, H-09). P3: 1 (H-07). Ninguno
heredado sin abrir: cada cita de un informe anterior se usa como dato técnico, que la carta me manda tomar así, o se
abrió en su línea.

---

## 3. Propuesta por pregunta

### P1 — **MODIFICAR** (la decisión se mantiene; cambian el fundamento, el lote y lo que se declara)

**Cómo.**

1. La premisa «Qué se actualiza» escribe las dos lecturas con su literal (H-02), retira «vacía el requisito» y
   declara que **P1 la decide la compuerta (b)**. La matriz de §1.1 (C-min 26, A+datos 18, C de I0 14) va como
   constancia de lo que pierde la compuerta.
2. El lote suma el ítem 5 de H-02, con **SI NO RESPONDÉS: (b), A+datos**.
3. «Un solo canal» queda decidido por la matriz (18 frente a 14), con su costo por corrección y su condición de
   revisión (H-01).
4. Nombre único y tabla de equivalencias (H-09).

**Cadena de consecuencias** (Cadena §2) del default en el lote:

| Paso | A+datos por defecto | C-min por defecto |
| --- | --- | --- |
| 1. Dónde cae | En el arranque de cada teléfono, en el piso de WebView e iOS y en la revisión de Apple (`.wasm`) | En el cascarón: cada pantalla o lógica nueva va por tienda (I4[3]) |
| 2. Cuánto pesa | Unos 2 s más que C-min, 9,13 MB por versión retenida, TTFD 3 692–4 871 ms ≤ 5 000 (021:330, 366). `.wasm` frente a Apple: sin medida posible, NO VERIFICADO | Primer render de 1,6–1,7 s (E02-B). El costo de cada pantalla nueva por tienda no se puede medir desde acá: es el ciclo de revisión que el pedido quiere evitar (EV001:21) |
| 3. Qué pierde si el PO responde lo otro | Si responde (a): pagó los costos de arriba sin necesitarlos. Se puede reducir a C-min con un cascarón nuevo, y la definición como datos se conserva igual | Si responde (b): no hay pantallas actualizables. Hay que reescribir el cascarón, la guía (P10), la demo (P11) y P3, P8, P9 y P13 juntas (020 §5) |
| 4. Reversible | Sí, mientras no haya base instalada | Sí, mientras no haya base instalada, con más retrabajo |

Las dos son reversibles, así que el paso 4 no decide. **Decide el paso 3:** A+datos cumple las dos lecturas y C-min
sólo una, y el retrabajo de equivocarse es menor con A+datos. Por eso el default es A+datos aunque la suma favorezca a
C-min. La condición de revisión es un hecho comprobable: **el PO responde (a) en el lote**. Se suman las tres
condiciones que el dictamen ya tiene (021:372-377).

### P4 — **MODIFICAR**

- La decisión del framework (entrada local y sesión separadas, T1, I1, sin período de gracia) **se confirma**.
  Coincide con la industria: el login como momento de chequeo y primera sincronización (CommCare [29], D365 [128]);
  lo pendiente sin vencimiento (Survey123 [38], OPINIÓN). Y evita el riesgo documentado de ServiceNow [138].
- Se agrega la regla de retención de pendientes al cerrar sesión (H-05).
- La demo sigue sin IdP. Se evalúa como etapa opcional el inicio de sesión de dispositivo al estilo ODK App User
  (H-08).
- **Cadena de H-05.** (1) Dónde cae: en el almacenamiento del teléfono y en la privacidad entre usuarios del mismo
  dispositivo. (2) Cuánto pesa: lo que ocupen las filas retenidas (sin medir; en E-ASD-1 son 3 filas). (3) Qué
  pierde la otra opción: borrar al cerrar sesión pierde datos de campo, que es irreversible para quien los tomó.
  (4) Retener es reversible (se borra después con confirmación del dueño); borrar no. Se toma retener (Cadena §2,
  paso 4).

### P5 — **CONFIRMAR**

La investigación no contradice ninguna fila (§1.2). H-05 se asienta en la fila «Outbox» de P4 y de P5 sin cambiar lo
decidido.

### P13 — **MODIFICAR**

- Se agrega la regla de evolución entre versiones de la definición (H-06).
- Se aclara que rechazar una versión de contenido no rechaza las respuestas tomadas con ella (H-03).
- P13.7 se conserva con su porqué frente a I0, y se le suma el intento de envío oportunista (H-07).
- **Cadena de H-06.** (1) Dónde cae: en quien edita la definición, que pierde la libertad de renombrar. (2) Cuánto
  pesa: una regla y, si la compuerta lo valida, una comparación de esquemas por PR (sin medir). (3) Qué pierde la
  otra opción: sin regla, la exportación del servidor mezcla versiones incompatibles; es el defecto que ODK y Kobo
  documentan ([6][17]; Marco 2020, «still save but leave the new questions blank», [12], OPINIÓN). (4) Reversible:
  aflojar la regla después es borrar una validación.

### Folio 006 y momento de actualización — **MODIFICAR** (P2, filas «Momento» y «Forzado»)

N = 0 **se confirma**: lo sostiene la industria (Expo, Shorebird, Capawesome, Shiny cuando no hay obligatoria) y el
umbral del propio dictamen no deja margen para esperar (H-04). P13.7 **se confirma** (H-07). El momento se escribe como
casos de uso:

| Caso de uso | Qué hace el framework | Precedente (dossier → fuente) | Estado frente a 021 |
| --- | --- | --- | --- |
| CU-1 Abrir con red, sin versión nueva | Arranca lo instalado (N = 0); consulta en segundo plano | Expo `ON_LOAD`, `fallbackToCacheTimeout` 0 (I2:50; [2]) | Igual |
| CU-2 Abrir con red, versión nueva no obligatoria | Baja y verifica en segundo plano; activa en el próximo arranque en frío | Expo, Shorebird, Capawesome (I0:203; I2:58-59) | Igual |
| CU-3 Abrir sin red | Arranca lo instalado; no fuerza nada; la consulta se reintenta en el próximo disparador | Shiny: la obligatoria fallida «is treated as offline» (I0:204; [106]); CommCare «will try again on a future login» (I1:70) | Igual |
| CU-4 Login con cuenta exitoso (F004) | Consulta; si el login ocurre antes de cargar el contenido, es punto seguro de activación | CommCare aplica en el login siguiente (I1:70; [29]); D365, primera sincronización al loguear ([128]) | **Se agrega** el punto seguro (H-04), condicional a P4 |
| CU-5 Obligatoria, con red, sin encuesta en curso | Se activa en el primer punto seguro después de bajarla. **El forzado «al iniciar» de F006 se cumple, a más tardar, en el inicio siguiente a la descarga** | Shiny la aplica antes de mostrar ([106]); se descarta esa espera porque rompe el TTFD ≤ 5 000 ms (H-04) | **Se declara** |
| CU-6 Obligatoria con encuesta en curso | La encuesta termina con su versión; aviso; se activa al terminar | SAP `OnWillUpdate` (I6:123); ServiceMax tolera la sesión (I6:62) | Igual |
| CU-7 Obligatoria con pendientes sin enviar | Intento de envío oportunista; se activa sin esperar al outbox (P13.7) | SAP guarda o cierra almacenes antes de aplicar ([129][130]); ODK acepta versiones viejas ([10], OPINIÓN) | **Se agrega** el intento (H-07) |
| CU-8 Obligatoria sin red | No se fuerza; se trabaja con lo instalado y se marca la versión | CommCare *Forced* sólo «with proper internet connectivity» (I1:161; [28]) | Igual |
| CU-9 El servidor rechaza la versión de contenido en uso | Bloquea **en el próximo punto seguro**, nunca a mitad de una captura; las respuestas tomadas con esa versión no se rechazan por eso | ServiceMax: aviso en la sesión, bloqueo al reingresar (I6:62; [27]) | **Se corrige** (H-03) |
| CU-10 Cascarón bajo el mínimo soportado | Igual que CU-9: aviso durante la sesión; bloqueo en el próximo punto seguro con red; flujo de Play o pantalla de tienda | Oracle y ServiceMax al ingresar (I6:79, 163; [27][142]) | **Se corrige** (H-03) |

**Cadena de N = 0 frente a la espera acotada para la obligatoria.**

1. **Dónde cae.** Con N = 0, en un arranque más de atraso para la obligatoria. Con espera acotada, en el arranque de
   todos los usuarios con red, porque para saber si hay obligatoria hay que preguntar.
2. **Cuánto pesa.** N = 0: un ciclo de arranque, que limita la adopción («Code push adoption ≈ user cold-start
   frequency», Kikoff, I0:218-219, OPINIÓN de un equipo en producción) y que CU-5 y CU-6 achican con el punto seguro.
   Espera acotada: 1,1 s medidos con servidor en error (dato), que llevan la corrida más lenta a 5 971 ms, por encima
   del umbral.
3. **Qué pierde cada una.** N = 0 pierde la aplicación en el mismo arranque. La espera acotada pierde el umbral de
   arranque y el trabajo inmediato del encuestador con red mala.
4. **Reversible.** Las dos son un parámetro. Se toma N = 0. **Condición de revisión:** el TTFD medido con el
   contenido final queda por debajo de 5 000 ms menos la espera que se quiera agregar, o el PO dice en el lote que el
   forzado tiene que aplicarse en el mismo arranque.

---

## 4. Lo que revisé y está bien

| Qué | Por qué está bien |
| --- | --- |
| P5, D-04 = C2 con «último gana» declarado por acción | Es la forma que documenta Microsoft para D365 FS, política de conflicto por registro configurable ([127]). La investigación sólo trae opiniones en ambos sentidos sobre «último gana» (I5:170-174), sin cifras contadas: ninguna contradice declararlo por acción |
| P4, «No hay período de gracia local» y outbox con dueño | Cubre el riesgo que la industria registra como pérdida (ServiceNow Zurich, [138]) y coincide con el *Outbox* sin vencimiento de Survey123 ([38], OPINIÓN) |
| P13, ítems 1, 2, 4 y 5 | Coinciden punto por punto con ODK (`orx:version` [7]; envíos previos intactos [6]; borradores atados a su versión [11]) y con lo que ServiceMax documenta para la *Config Sync* ([28]). La forma «retiro explícito y anunciado» es más implementable que la de I0 (§1.2) |

---

## 5. Solicitudes de convocatoria y obstáculos

**Solicitudes de convocatoria (fuera de mi competencia; señal y ubicación, no hallazgo).**

| Para | Señal | Ubicación |
| --- | --- | --- |
| Seguridad y tiendas | Si la condición de H-01 lleva algún día a dos líneas, la segunda línea (definiciones) necesita su propia firma y su propia política de canal. Y la decisión por versión debe «limitarse a forzar o avisar, no a encender capacidades»: hay técnicas para esconder funciones a la revisión (layer8, HN 2024-08-04, OPINIÓN) y un rechazo por «hidden features» (Expo #1865) | I0:298-301; [154]; [55] |
| Integración, versionado y pruebas | Validar en la compuerta del PR la regla de evolución de H-06, comparando el esquema de la definición nueva con el de la publicada. Precedente: la compuerta de Capgo que falla ante incompatibilidad (`--fail-on-incompatible`) | I0:166-168, 420; [46] |
| Guía (académico editor y lector sin contexto) | La tabla de casos de uso del momento (§3) y la tabla de equivalencias de nombres (§0) son material para la guía. El escenario «encuestador, coordinador que publica, servidor» que propone I0 | I0:424 |

**Obstáculos de una línea** (Cadena §3; no uso el g42 ni el emulador).

| Para | Pregunta de una línea | Destraba |
| --- | --- | --- |
| Presidencia (quien tiene el g42) | «Medir en el g42 el TTFD de A con la definición de la encuesta dibujada por el renderizador genérico del contenido, y el peso de un paquete en el que sólo cambió la definición» | Celdas K-P y K-C de A+datos (§1.1) y condición (ii) de H-01 |
| Presidencia | «Estimar el costo de un inicio de sesión de dispositivo por código contra el receptor didáctico» | H-08 |
| Quien pidió (por el lote) | «¿Las correcciones sin tienda incluyen pantallas y lógica nuevas (código), o alcanza con encuestas y datos?» SI NO RESPONDÉS: (b), A+datos | P1 (H-02) |

**Fichas de excepción:** ninguna. No propongo dejar de seguir ninguna convención que rige.

Sigue: incorporación al conjunto de la ronda 2, refutador y jurado · presidencia · Cierra con: folio de veredicto de la ronda 2

Sigue: incorporación del siguiente informe y resolución · presidencia
