| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-10-25 |
| Autor | Comisión Verificación (ronda 2) |
| Corrige | — |

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Rol | Verificación (comisión del núcleo) · criterio de aceptación y medio de cada decisión; clasificación HECHO/OPINIÓN/NO VERIFICADO |
| Ronda | 2 |
| Fecha | 2026-10-25 |
| Carta | `evidencia/018-carta-r2-verificacion.md` |
| Objeto | Dictamen de la ronda 1 (folio 021) frente a la investigación I0–I7 |
| Clase de objeto | Diseño de una norma o decisión |
| Norma | `<base de conocimiento>/Knowledges/Knowledge-Mesa-De-Expertos-A-Pedido.md` 3.1 |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | Cabecera y §0 (líneas 1–111). Por la fila «Sos una comisión» del Mapa de carga: la carta (§5.2), §2.2 (con su subsección), §3.2, §3.3 y §4 |
| Documentos cargados | `Cadena-De-Consecuencias` 2.0, §2 (antes de recomendar entre opciones) · `Escalas-De-Juicio` 1.0, §3.3 (por remisión de la carta: escala de ancla). `Excepcion-A-Un-Conocimiento` **no** se cargó: no propongo dejar de seguir ninguna convención; no hay fichas |
| Insumos leídos | Evidencia 001 desde la línea 4; folios 003, 004, 005, 006 y 022; folio 021 entero; I0 entero; pasajes de I2, I4, I6 e I7 por `grep -n` (líneas citadas abajo); E01 `INFORME.md` por `grep -n` (líneas 47, 163, 264–270) |
| No leídos | Folios 009–020 (no necesité el fundamento de un ítem por fuera de lo que el 021 cita); I1, I3, I5 sólo a través de I0; N1–N5 y R1–R4 |
| Medios | Lectura y `grep -n`/`grep -c` sobre el árbol. Ningún dispositivo, ningún emulador, ninguna fuente externa nueva |
| Rótulo | No nombra el repositorio privado de la app de referencia del PO, ni hosts, direcciones o series de dispositivos |

# Verificación — ronda 2: el dictamen r1 frente a la investigación de industria

## Índice

1. [Qué confirma y qué contradice la investigación, por pregunta](#1-qué-confirma-y-qué-contradice-la-investigación-por-pregunta)
2. [Hallazgos](#2-hallazgos)
3. [Propuesta por pregunta](#3-propuesta-por-pregunta)
4. [Lo que revisé y está bien](#4-lo-que-revisé-y-está-bien)
5. [Solicitudes de convocatoria](#5-solicitudes-de-convocatoria)
6. [Lo que esta ronda no puede verificar sin dispositivo](#6-lo-que-esta-ronda-no-puede-verificar-sin-dispositivo)

Abreviaturas: `F021:n` = folio 021, línea n; `I0:n` = síntesis, línea n; `I2:n`, `I4:n`, `I6:n`, `I7:n` = dossier y
línea; `[n]` = fuente de I0 §8. Clases de I0 §0 (I0:79-81): **HECHO**, **OPINIÓN**, **NV** (no verificado),
**criterio** (inferencia del sintetizador o del dossier, no práctica medida).

**Nota de método.** El dictamen r1 es anterior a la investigación: no toma nada de I0. Lo que sigue clasifica **las
afirmaciones de industria del dictamen** según la clase que I0 les da, y marca dónde el dictamen se apoya en algo que
I0 rotula de otra clase, o donde I0 trae un HECHO que el dictamen no tuvo.

---

## 1. Qué confirma y qué contradice la investigación, por pregunta

### 1.1 Foco: P1, P2, P8, P9, P12

| Pregunta | Lo que dice el dictamen r1 | Lo que dice la investigación (dossier · fuente primaria) | Clase en I0 | Efecto |
| --- | --- | --- | --- | --- |
| P1 | A + definición de la encuesta como datos versionados, dentro del paquete (F021:307, 316-318) | I0 propone «C»: motor de encuestas en el contenido Blazor y encuestas como datos versionados (I0:67-70, 415). Es la misma forma que el dictamen; el nombre cambia | criterio del sintetizador | **Confirma** la forma; no es evidencia, es convergencia de criterio |
| P1 | Las plataformas de encuestas bajan definiciones, no código (implícito en el descarte de «A pura», F021:358) | ODK, Kobo, SurveyCTO, CommCare, Survey123: motor de tienda + definiciones como datos; «No descargan código de pantallas» (I0:34-38 · [5][6][20][21]) | HECHO | **Confirma** separar la definición del código |
| P1 | Play: excepción para «code that runs in a virtual machine or an interpreter» (F021:348-349) | Texto literal de Play (I0:319-322 · [3]); y **Blazor WASM sin AOT corre sobre «a .NET Intermediate Language (IL) interpreter implemented in WebAssembly»**, con JIT parcial (I0:323-324; I4:117 · [102] Microsoft Learn) | HECHO | **Completa** el fundamento: la lectura «intérprete» vale **sin AOT**. El dictamen no fija esa condición (H-02) |
| P1 | `.wasm` frente a App Review 2.5.2: NO VERIFICADO (F021:369) | «Ninguna política de Apple ni de Google nombra WebAssembly; no se encontró caso documentado de rechazo ni de aprobación» (I0:64-65; I4:119 · [1][2][3][64]) | NV | **Confirma** el rótulo |
| P1 | Umbral TTFD ≤ 5 000 ms, criterio del jurado anclado en Android vitals (F021:323-330) | La investigación no trata umbrales de arranque. Opinión sobre lentitud del WebView en ambos sentidos (I0:377 · [95][163][164]) | OPINIÓN (controversia) | Ni confirma ni contradice; el criterio sigue siendo del jurado |
| P2 | N = 0, consulta en segundo plano, activación en el próximo arranque en frío (F021:409-411) | Expo, Shorebird, Capawesome chequean al abrir sin bloquear y aplican en el próximo arranque; Expo `fallbackToCacheTimeout` 0 por defecto (I0:104, 203, 211-214 · [34][35][48][50]); CommCare baja tras el login y aplica en el siguiente [21] | HECHO | **Confirma** |
| P2 | Disparador «login con cuenta exitoso» (F021:410); el r1 dejó «muchas aplicaciones» como NO VERIFICADO (F021:220) | Al iniciar sesión: CommCare [21], D365 FS [128], Salesforce [134], Oracle y ServiceMax para el cascarón [140][142] (I0:45-48, 92) | HECHO para plataformas de campo y empresariales; **no** como modo de las OTA (Shorebird sólo lo sugiere [51]) | **Confirma y sube de clase**: lo que r1 dejó NV queda HECHO para esas dos familias |
| P2 | Rollback local por marca «pendiente» que el contenido borra con `Listo(version)` (F021:398) | `notifyAppReady` y vuelta al anterior (I0:220-222 · [43][47]); Expo «attempt to roll back to the previously working update» y sólo errores tempranos (I7:97-99 · [37]) | HECHO | **Confirma** |
| P2 | Semilla: «No es destino de rollback» (F021:402); qué pasa si `current` y `previous` fallan: sólo como condición de revisión (F021:455) | Expo arranca con lo último descargado **o con el embebido** (I0:104 · [34]); Shiny: «Offline or server down: the newer of the bundled and installed builds is served» y «Old releases are never reinstalled» (I4:61, 88 · [105][106]) | HECHO (Shiny: HECHO del proveedor) | **Omite**: la industria define el estado terminal; el dictamen no (H-04) |
| P2 | Rollback remoto: no existe, se vuelve hacia adelante (F021:399) | Shiny: sin rollback; corregir subiendo la mínima es **criterio propio** de I4 (I4:88). «Rollback isn't a button» (Mason Roy, 2026-09-30 · [57]) | HECHO (Shiny) + OPINIÓN | **Confirma** la dirección |
| P2 | «Forzado `IMMEDIATE`: pierde la entrada en curso (Capawesome, CodePush)» (F021:451) | CodePush `mandatory`+`IMMEDIATE` existe (I0:203 · [43]); que «pierde la entrada en curso» es inferencia: Capgo `always` «aplica aun en uso activo» (I2:80-81 · [45]) | El mecanismo: HECHO. La pérdida: **criterio** | **Reclasificar** la frase del dictamen como criterio, no como hecho de esas fuentes |
| P2 | Sin red no se fuerza (F021:419) | CommCare *Forced* «Under ideal conditions (proper internet connectivity…)» [20]; Shiny trata la descarga obligatoria fallida «as offline» [106] (I0:49-51, 204) | HECHO | **Confirma** |
| P2 | El dictamen no menciona Shiny.AppDeviceBridge (`grep -c -i shiny` sobre el folio 021 → 0) | Único producto .NET que implementa el patrón: zip base, ECDSA P-256, `minimumVersion`, `minimumHostVersion`, segundo plano y próximo arranque; beta del 2026-09-18 (I0:59-61, 186; I4:61, 88, 187 · [105][106][107]) | HECHO (proveedor) | **Omite** el precedente .NET (H-08) |
| P8 | Compuerta mínima: build, unitarias, actualizador (incluye «el predicado de P3»), catálogo frente a AndroidManifest, APK y empaquetado; contrato del puente y WASM con Playwright en el tramo siguiente (F021:673-686) | Compuerta que falla si el contrato nativo cambió sin cambiar la clave: Expo `fingerprint` («derived from hashing app dependencies, custom native code…») y Capgo `--fail-on-incompatible` («the upload fails with a non-zero exit and nothing is shipped») (I7:94-95, 139-141 · [38][46]). Falla real por clave escrita a mano: issue emberglow #399 (I2:326 · [58]) | HECHO (Expo, Capgo) + OPINIÓN (issue) | **Contradice en parte**: el dictamen prueba el predicado, no que lo declarado sea cierto (H-03) |
| P8 | — | «Probar el contenido nuevo contra el cascarón viejo publicado» (I7:392, paráfrasis de Expo *Error recovery* [37], sin cita literal); «contenido N sobre cascarón mínimo» (I6:228) y «definición válida contra esquema» (I0:420, 422) | Paráfrasis de HECHO (I7) + **criterio** (I6, I3) | Señal para H-03; no funda por sí sola una corrección |
| P9 | iOS «diseño sin ensayo, NO VERIFICADO», riesgos 2.5.2, DPLA 3.3.1(B), 4.7.2, 4.2.3(ii), EF con trimming (F021:707-716) | Apple 2.5.2 y DPLA 3.3.1(B) literales (I0:314-317 · [1][2]); alcance de 4.7.2 sobre contenido propio: NV (I0:295-297); WKWebView puede requerir bajar `EmccMaximumHeapSize` (I0:423; I4:125 · [103]); sin actualización in-app del cascarón en iOS (I0:51 · [108]) | HECHO + NV | **Confirma** el rótulo; **omite** el riesgo de memoria (H-09) |
| P9 | Condición de revisión de P1: «una revisión real de Apple rechaza el `.wasm`» (F021:376) | No hay caso documentado en ningún sentido (I0:336); publicar en tiendas está fuera de alcance (F003:84) | NV | El evento no puede ocurrir dentro del alcance (H-10) |
| P12 | Catálogo cerrado en el cascarón, `handshake`, `requires`/`optional`, capacidad nueva en dos tiempos, compuerta catálogo↔AndroidManifest (F021:840-860) | Frontera dura del manifiesto en todas las fuentes leídas: Expo «Changes to the Info.plist cannot be updated over-the-air» [39], Capacitor, Tauri, Shiny, SAP MDK (I0:272-277); descubrimiento `isPluginAvailable`, `get`→null, `501` [66][69][106]; `requires`/`fallback` de Adaptive Cards [90] (I0:279-286) | HECHO | **Confirma** |
| P12 | «El estado del permiso se consulta en el uso … verificar, pedir en contexto» (F021:848-849); no dice por dónde | En HybridWebView Android, interceptar los pedidos de permiso del WebView está abierto: `dotnet/maui#25784` (Backlog) y `#30847` (`p/0`, hito .NET 10 SR13) (I0:290-292; I4:103-104 · [111][112]); pedir foto o GPS **por el puente C#** es criterio de I4 (I4:108) | HECHO (issues) + criterio | **Omite** el camino: deja abierta la API web del WebView (H-05) |
| P12 | Capacidad nueva «en dos tiempos»: release del cascarón con la declaración, después contenido que la usa (F021:855-856) | Riesgo de «hidden features» ante la revisión: Expo #1865 (rechazo 2.5.2; HECHO del issue [55]); que un chequeo por versión es técnica para esconder funciones (layer8 [154], OPINIÓN); «nada se enciende desde el servidor si la revisión no lo vio» (I0:298-306) | HECHO (texto 2.5.2 y el issue) + OPINIÓN + **criterio** | **Tensión** no tratada por el dictamen (H-06) |

### 1.2 Las demás preguntas (P3–P7, P10, P11, P13), en una línea cada una

| Pregunta | Confirma / contradice | Cita |
| --- | --- | --- |
| P3 | Contrato con versión y puente tipado: **confirma** (TurboModules, Capacitor; I0:165 · [66][68]). La **forma** de la clave contradice en parte: I7 «favorece la coincidencia exacta o el piso calculado, no un rango a mano» (I7:363-367, criterio de I7 sobre HECHO de Expo y Capgo); el dictamen fija un rango con techo escrito a mano (F021:489-498). Se trata en H-03 sin tocar VPI §2.6 | I7:94, 140, 367 |
| P4 | Login como momento de chequeo y versión mínima del cascarón al ingresar, con la sesión en curso tolerada (ServiceMax [140]): **confirma** la separación entrada local / sesión (F021:520) | I0:418 |
| P5 | Cola de salida sin vencimiento y estado visible de pendientes (Survey123 [28], Power Apps, SAP `ErrorArchive` [122][130]): **confirma**. Idempotencia de la cola como práctica: NV en I0 (I0:419), medida en este expediente (E-ASD-1, F021:557) | I0:419 |
| P6 | Sin contradicción. La compuerta de contrato que I0 pone en P6 (I0:420) la trato en P8 | I0:420 |
| P7 | Tres o cuatro líneas (motor, definición, servidor; binario, clave, update) [7][22][33][54]: **confirma**. I0 agrega líneas fuera de control: WebView del sistema [101] y **soporte de MAUI 10 hasta el 2027-05-11** [104] (H-07) | I0:421; I4:90 |
| P10 | Sin contradicción. I0 aporta historias de falla con fuente para la guía (I0:424) | I0:424 |
| P11 | Camino .NET 10 más corto `WebResourceRequested` [98]: **confirma**. Shiny como tabla diferencial (I0:425): **omite** (H-08). SDK fijado sin fecha de fin de soporte (H-07) | I0:425 |
| P13 | Versión en la instancia [7] y borradores atados a su versión (ODK, Kobo) [11][16][17]: **confirma** F021:882-884. Que el servidor acepte versiones publicadas no borradas es **OPINIÓN autorizada** (LN, foro [10]) y NV en la doc oficial (I0:250, 632): el dictamen ya lo rotula NO VERIFICADO para ODK Central (F021:906-907) | I0:250, 427 |

---

## 2. Hallazgos

Lectura P0–P3 de la carta: **P0** viola una restricción dura o hace imposible el objetivo; **P1** retrabajo o lecturas
divergentes entre implementadores o lectores de la guía; **P2** pérdida acotada; **P3** claridad.

| Id | Nivel | Ancla con cita | Hallazgo | Impacto | Dirección de la corrección |
| --- | --- | --- | --- | --- | --- |
| H-01 | P1 | **E2** · F021:327 «Dispositivo de referencia: el teléfono de juicio, moto g42» · F021:374-375 «o en el de gama más baja que el producto declare soportar» · F021:802-803 «Dispositivo de referencia: Android con WebView ≥ 94, comprobado por comando» · F003:46-50 (OBJETIVO: «enseñada en Developer-Guide.md para un desarrollador sin experiencia») | **Primer hallazgo: lo que el dictamen da por fijo sin origen.** El criterio de aceptación de P1 (TTFD ≤ 5 000 ms) se mide en un teléfono de laboratorio que ni el pedido ni el objetivo nombran, y que el lector de la guía no tiene. P11 define otro «dispositivo de referencia» para el mismo producto. La condición de revisión remite a una gama mínima que nadie declara | Dos lecturas del mismo umbral: el implementador lo mide en el g42; el lector de la guía, en su Android. El umbral no se puede reproducir desde la guía y la condición de revisión no tiene cómo dispararse | Un solo «dispositivo de referencia» para P1 y P11, con origen declarado (agregado del jurado marcado, si lo es). El umbral dice en qué dispositivo y con qué comando se mide, y la guía enseña ese comando. Declarar la gama mínima soportada o quitar esa rama de la condición |
| H-02 | P1 | **E2** · F021:348-349 (Play: «code that runs in a virtual machine or an interpreter») y F021:364-370 (costos, sin condición de compilación) · **HECHO** I4:117 · [102] Microsoft Learn: «Without enabling AOT compilation, Blazor WebAssembly apps run on the browser using a .NET Intermediate Language (IL) interpreter» · E01 `INFORME.md`:264 «Publicación con `wasm-tools` (AOT/relink) … NO VERIFICADO» · criterio I4:119 (AOT con más cautela) | El fundamento de tienda de P1 vale para **IL interpretado**, y las cifras medidas (E01, E02-R) son de una publicación sin AOT. El dictamen no fija «publicar sin AOT» ni lo verifica. Su condición de revisión (TTFD > 5 000 ms) invita a activar AOT para ganar arranque, que es justo lo que saca al contenido de la lectura «intérprete» | Un implementador que active `RunAOTCompilation` cambia la clase de código que se descarga sin que nadie lo decida, invalida las mediciones y apoya el canal en una lectura de tienda que ya no corresponde | Fijar en P1 la condición de compilación del contenido (sin AOT), con su fuente, y su comprobación en la compuerta (P8) con rojo provocado. AOT entra sólo con medición y con una fuente de tienda que lo cubra |
| H-03 | P1 | **E2** · F021:489-498 (predicado con rango `>=A.B.C <(A+1).0.0` escrito en el manifiesto) · F021:677 («el predicado de P3» en la suite del actualizador) · F021:680 (contrato del puente: «Tramo siguiente») · **HECHO** I7:94-95 · [38] Expo *Fingerprint* y I7:139-141 · [46] Capgo `--fail-on-incompatible` · **OPINIÓN** I2:326 · [58] emberglow #399 «runtimeVersion is a hand-maintained string» | La compuerta prueba que el predicado **evalúa bien** lo declarado, pero nada prueba que lo declarado **sea cierto**: el rango de puente del contenido, el número de versión del puente en el cascarón y la definición de encuesta salen escritos a mano y entran sin verificación. La industria cierra ese hueco en CI: la clave se deriva del código y la publicación falla si el contrato cambió sin cambiar la clave | Un cambio del puente sin subir el mayor, o un rango optimista en el contenido, pasa el predicado y se activa en teléfonos donde falla: el caso que el canal dice impedir. Retrabajo cuando aparezca en campo | Agregar a la compuerta mínima de P8 una verificación de la declaración: (a) que un cambio en la superficie del puente sin cambio de su versión ponga `fw-ok` en rojo; (b) que la definición publicada valide contra su esquema. Cada una con su rojo provocado. Es compatible con VPI §2.6: no cambia la forma del rango, verifica su verdad |
| H-04 | P1 | **E2** · F021:398 (vuelve a `previous`) · F021:402 (semilla «No es destino de rollback») · F021:455 (la doble falla aparece sólo como condición de revisión) · **HECHO** I0:104 · [34] Expo arranca con lo descargado «o con el bundle embebido» · I4:61 · [106] Shiny «the newer of the bundled and installed builds is served» | El dictamen no dice qué hace el cascarón cuando `current` y `previous` fallan (o `previous` no existe, como en el primer update después de la semilla). Las dos referencias de industria lo definen; el dictamen deja el estado terminal sin criterio de aceptación | Dos implementadores pueden resolverlo distinto (pantalla de error del cascarón, volver a la semilla, bucle de arranque). La demo no lo prueba y la guía no lo enseña | Declarar el estado terminal y entregarlo con su prueba (rojo provocado: dos versiones fallidas sin red). Qué estado es lo decide quien tenga P2 (solicitud S-1) |
| H-05 | P1 | **E2** · F021:848-849 («El estado del permiso se consulta en el uso … verificar, pedir en contexto») · F021:483-484 (la CSP no restringe APIs del dispositivo) · **HECHO** I4:103-104 · [111][112] `dotnet/maui#25784` y `#30847`, abiertos · criterio I4:108 (pedir por el puente C#) | P12 no dice **por dónde** pide el contenido una capacidad. Deja abierta la API web del WebView (geolocalización, cámara por `<input capture>` o `getUserMedia`), cuyo pedido de permiso HybridWebView Android hoy no puede interceptar | Un implementador usa la API web, el catálogo y su compuerta (que miran sólo el puente) no lo ven, y el permiso falla en el teléfono. Lecturas divergentes entre «capacidad = entrada del catálogo» y «capacidad = lo que el WebView ofrezca» | Declarar en P12 que el contenido accede a capacidades del dispositivo **sólo por el puente**, y darle un criterio de aceptación comprobable (rojo provocado: contenido que usa la API web del WebView). Condición de revisión: el cierre de `#30847` |
| H-06 | P2 | **E2** · F021:855-856 («Una capacidad nueva entra siempre en dos tiempos … Hasta que la base instalada se actualice, va como `optional`») · **HECHO** I0:314-315 · [1] Apple 2.5.2 «introduces or changes features or functionality» · [55] Expo #1865 · **OPINIÓN** [154] layer8 · **criterio** I0:298-306 | El primer tiempo publica un binario con el permiso o la descripción de uso de una función que el revisor no puede ejercer; el segundo la «enciende» por contenido. Es el patrón que I0 señala como riesgo de «hidden features». El dictamen no le pone criterio | Riesgo de rechazo o de retiro acotado a la release que sume capacidades; no rompe el canal | Agregar a la regla de dos tiempos un criterio de aceptación: en la release del cascarón, la capacidad es ejercible en el binario revisado (aunque sea por una pantalla del cascarón), o se declara el riesgo en la guía. Decidir cuál, por S-4 |
| H-07 | P2 | **E2** · F021:800 (`global.json` con SDK y `workloadVersion` fijados, `MauiVersion` fijada) · F021:831-834 (condiciones de revisión de P11, sin fecha) · **HECHO** I4:90 · [104] «.NET MAUI Support Policy»: MAUI 10 termina soporte el **2027-05-11** · [121] .NET 11 GA «expected in November 2026» | El framework fija el cascarón en MAUI 10 sin condición de revisión por la fecha de fin de soporte, que cae a seis meses y medio de hoy. I4 deriva (criterio) que el cascarón pasa por la tienda al menos una vez por año y que el contrato tiene que sobrevivir ese salto | La guía queda desactualizada en una fecha conocida y el salto de mayor de MAUI no está previsto en P7 ni en P3 | Sumar a P11 (y a P7) la condición de revisión «2027-05-11, fin de soporte de MAUI 10», que es un hecho comprobable (`Cadena-De-Consecuencias` §2, paso 4), y nombrar en P3 que el salto de MAUI es un release del cascarón que debe conservar el mayor del puente o subirlo |
| H-08 | P2 | **E1** · `grep -c -i shiny` sobre los folios 019, 020 y 021 → 0, 0, 0 · **HECHO (proveedor)** I4:61, 88, 187 · [105][106][107] | El dictamen decide P2 sin la tabla diferencial contra el único producto .NET que implementa el mismo patrón y estaba publicado antes de la mesa (beta 2026-09-18; NuGet 2.1.0 del 2026-10-15). Difiere en al menos tres columnas: servido por *loopback* frente a `WebResourceRequested`; sin rollback frente a marca pendiente; `minimumVersion` bloqueante frente a N = 0 | La guía no puede explicar por qué el framework construye su propio actualizador ni qué toma o descarta de la referencia; la decisión de P2 queda sin el medio que su propia norma prefiere | Que P2 y P11 lleven la tabla diferencial Shiny ↔ dictamen, columna por columna, con cada divergencia declarada. Adoptar, descartar o imitar es decisión del canal (S-3) |
| H-09 | P3 | **E2** · F021:712-716 (riesgos de iOS nombrados) · **HECHO** I4:125 · [103] Microsoft Learn: «especially Safari on iOS, decreasing the maximum memory for the app with the MSBuild property `EmccMaximumHeapSize` may be required» · criterio I4:125 (aplica a WKWebView) | La lista de riesgos de iOS omite el de memoria del runtime WASM, que tiene fuente oficial | Un lector de la guía no lo ve venir el día que exista un build iOS | Sumarlo a la lista de P9 como «documentado, sin ejecutar», con su fuente |
| H-10 | P2 | **E2** · F021:376 («una revisión real de Apple rechaza el `.wasm`. iOS pasa a B») · F003:84 («FUERA DE ALCANCE: publicar en tiendas») · **NV** I0:336 (ningún caso documentado de rechazo ni de aprobación) | La condición de revisión de P1 para iOS depende de un evento que el alcance no permite producir y que la industria no documenta. No se puede comprobar dentro de este framework (`Cadena-De-Consecuencias` §2, paso 4). Además, con la definición dentro del paquete de código (F021:316-318), pasar iOS a B también obliga a sacar la definición a otro canal | iOS queda sin disparador para el cambio de modelo. Si el disparador llega, el retrabajo es mayor del que el dictamen anota | Reemplazar o completar el evento por uno comprobable dentro del alcance (por ejemplo, la condición de P9: cuenta de Apple Developer asentada o un `run_id` `macos-*` verde) y anotar el costo de separar la definición. Si el canal de la definición cambia, es S-2 |

**Cuenta:** 10 hallazgos · P0: 0 · P1: 5 · P2: 4 · P3: 1. Ninguno heredado sin verificar: ninguno entra como `C`.

---

## 3. Propuesta por pregunta

| Pregunta | Propuesta | Cómo y por qué |
| --- | --- | --- |
| **P1** | **MODIFICAR** | (1) Un solo dispositivo de referencia con origen, y el comando de medida en la guía (H-01). (2) Condición de compilación «contenido sin AOT», con fuente [102] y comprobación en la compuerta (H-02). (3) Condición de revisión de iOS comprobable dentro del alcance (H-10). La elección del modelo (A + definición como datos) **no** la toco: la investigación la confirma como convergencia de criterio (I0:67-70), no la contradice |
| **P2** | **MODIFICAR** | (1) Declarar el estado terminal ante la doble falla, con su prueba (H-04; la elección va a S-1). (2) Tabla diferencial con Shiny.AppDeviceBridge (H-08; la adopción va a S-3). (3) Reclasificar «forzado `IMMEDIATE` pierde la entrada» como criterio (§1.1). (4) Subir de NV a HECHO el disparador «al iniciar sesión» para plataformas de campo y empresariales (I0:45-48) |
| P3 | **MODIFICAR** | Sin cambiar la forma del rango (VPI §2.6 rige): verificar en CI que la versión del puente cambia cuando cambia su superficie (H-03). Nombrar el salto de MAUI como release del cascarón (H-07) |
| P4 | CONFIRMAR | I0:418 respalda separar entrada local y sesión, y el chequeo al ingresar |
| P5 | CONFIRMAR | I0:419 respalda cola sin vencimiento y pendientes visibles; la idempotencia está medida en el expediente |
| P6 | CONFIRMAR | La compuerta de contrato que I0 sugiere para P6 se resuelve en P8 |
| P7 | CONFIRMAR, con un agregado | Anotar la fecha de fin de soporte de MAUI 10 como dato de la línea «cascarón» (H-07) |
| **P8** | **MODIFICAR** | Sumar a la compuerta mínima dos verificaciones de declaración —superficie del puente contra su versión, definición contra su esquema— y la de «contenido sin AOT», cada una con rojo provocado (H-02, H-03). Sumar el rojo provocado de la doble falla a la suite del actualizador (H-04) y el de «capacidad pedida por la API web» (H-05) |
| **P9** | **MODIFICAR** | Sumar el riesgo `EmccMaximumHeapSize` (H-09). El rótulo «diseño sin ensayo, NO VERIFICADO» se confirma |
| P10 | CONFIRMAR | Las historias de falla con fuente de I0:424 pueden entrar como ejemplos; no cambian la estructura |
| P11 | **MODIFICAR** | Condición de revisión con fecha (2027-05-11) (H-07); tabla diferencial con Shiny en el Mapa guía↔demo (H-08) |
| **P12** | **MODIFICAR** | (1) Capacidades sólo por el puente, con criterio de aceptación (H-05). (2) Criterio para la release del primer tiempo (H-06; la elección va a S-4). La frontera del manifiesto, el catálogo y el descubrimiento se confirman (§4) |
| P13 | CONFIRMAR | La regla de versión en cada respuesta y de borradores atados a su versión tiene HECHO (ODK [7], Kobo [17]); la aceptación del servidor ya está rotulada NO VERIFICADO |

**Cadena de consecuencias (`Cadena-De-Consecuencias` §2) para la única elección entre opciones que propongo, H-02
(«contenido sin AOT» frente a «AOT permitido»):**

| Paso | Sin AOT, fijado | AOT permitido |
| --- | --- | --- |
| 1. ¿Dónde cae? | En el arranque y el tamaño del contenido, que no aprovechan AOT | En la lectura de tienda de P1 (pasa de «intérprete» a código compilado) y en las mediciones de E01/E02-R, que dejan de valer |
| 2. ¿Cuánto pesa ahí? | Lo medido: TTFD 3 692–4 871 ms en el g42, bajo el umbral (F021:330). La ganancia de AOT **falta medirla** (E01:264, NO VERIFICADO): se asienta como falta | Sin medida: no hay fuente de tienda que cubra WASM compilado (I0:64-65, NV) ni medición de AOT |
| 3. ¿Qué pierde la alternativa? | Pierde la mejora de arranque que AOT pueda dar | Pierde el fundamento de P1 en Play [3] + [102] y las cifras que sostienen el umbral |
| 4. ¿Es reversible? | Sí: se habilita AOT después, con medición y fuente | No del todo: un contenido compilado ya distribuido alcanza a terceros que lo instalaron |

Se toma la reversible. **Condición para revisarla:** una medición de TTFD con `wasm-tools`/AOT en el dispositivo de
referencia, más una fuente de tienda que cubra WebAssembly compilado. Las demás direcciones no eligen entre opciones:
piden declarar o probar lo que el dictamen ya decidió.

---

## 4. Lo que revisé y está bien

| Ítem | Por qué está bien |
| --- | --- |
| P2, momento: N = 0, consulta en segundo plano y activación en el próximo arranque en frío (F021:409-411) | Coincide con lo que documentan Expo, Shorebird, Capawesome y CommCare (I0:104, 203, 211-214 · [34][35][48][50][21]): HECHO. La razón explícita, «the patch cannot be hot-swapped into memory dynamically on that launch» [50], es la misma que dio el ensayo E02-R |
| P12, frontera del manifiesto: catálogo cerrado, descubrimiento por `handshake`, `requires`/`optional`, prueba catálogo↔AndroidManifest (F021:840-860) | Todas las fuentes leídas declaran que permisos y código nativo sólo cambian por binario (I0:272-277 · [39][47][48][50][67][81][106][132]), y los cuatro mecanismos de I0:279-286 están representados. HECHO |
| P13, versión de la definición en cada respuesta desde que se empieza a cargar, y ningún forzado descarta pendientes (F021:882-893) | Es la regla de ODK (`orx:version` en la instancia, [7]) y de Kobo (borradores atados a su versión, [17]); el riesgo contrario está documentado en campo (JessicaCelis [29], OPINIÓN). El dictamen no cuantifica lo que no se contó |

---

## 5. Solicitudes de convocatoria

No me corresponde decidir el modelo ni el canal. Señales y ubicación:

| Id | Señal | Ubicación | A quién |
| --- | --- | --- | --- |
| S-1 | Estado terminal cuando `current` y `previous` fallan: ¿semilla, pantalla del cascarón u otro? La industria vuelve al embebido (Expo [34]) o sirve el más nuevo entre embebido e instalado (Shiny [106]); el dictamen excluye la semilla por «versión vieja contra datos nuevos» (F021:446), mientras P5 adopta lector tolerante y versión de forma (F021:556) | F021:398, 402, 446, 455 · I0:104 · I4:61 | Quien decide P2 (Arquitectura, Seguridad) |
| S-2 | Canal de la definición: dentro del paquete de código (F021:316-318) o por un canal de datos aparte, como las plataformas de encuestas (I0:34-38). Pesa sobre la ruta de iOS a B (H-10) y sobre la lectura de tienda de la definición como datos (I0:345-348, criterio) | F021:316-318, 376 · I0:34-38, 345-348 | Quien decide P1 |
| S-3 | Adoptar, imitar o descartar Shiny.AppDeviceBridge como base del actualizador | F021 P2 (sin mención) · I4:61, 88, 187 | Quien decide P2 y P11 |
| S-4 | Regla de dos tiempos para capacidades nuevas frente al riesgo de «hidden features» | F021:855-856 · I0:298-306 | Quien decide P12 (Seguridad y tiendas) |

---

## 6. Lo que esta ronda no puede verificar sin dispositivo

Obstáculos de una línea a la presidencia (no usé el g42 ni el emulador):

- Medir el TTFD en el dispositivo de referencia que se fije (H-01) y, si se decide, con AOT (H-02).
- Correr en un Android con WebView ≥ 94 el caso «`current` y `previous` fallidas, sin red» y registrar qué hace el cascarón de E01/E02-R (H-04).
- Medir en un Android con HybridWebView qué pasa cuando el contenido pide geolocalización o cámara por la API web del WebView (H-05).
- Todo iOS: sin Mac ni runner `macos-*` medidos (F003:88); incluye `EmccMaximumHeapSize` en WKWebView (H-09).

Sigue: veredicto de la ronda 2 con este folio entre los informes de comisión · presidencia · Cierra con: folio informe del jurado de veredicto

Sigue: incorporación del siguiente informe y resolución · presidencia
