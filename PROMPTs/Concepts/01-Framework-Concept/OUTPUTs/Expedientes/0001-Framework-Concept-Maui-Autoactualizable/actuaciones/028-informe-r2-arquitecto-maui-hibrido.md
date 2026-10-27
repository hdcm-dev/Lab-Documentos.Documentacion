| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-10-25 |
| Autor | Comisión Arquitectura .NET MAUI (ronda 2) |
| Corrige | — |

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Rol | Arquitecto de aplicaciones móviles .NET MAUI (comisión, ronda 2). Refuta el dictamen de la ronda 1 frente a la investigación I0–I7 |
| Ronda | 2 |
| Fecha | 2026-10-25 |
| Carta | `evidencia/020-carta-r2-arquitecto-maui-hibrido.md` |
| Norma | `<base de conocimiento>/Knowledges/Knowledge-Mesa-De-Expertos-A-Pedido.md` 3.1 |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | Cabecera y §0 (líneas 1–111). Por la fila «Sos una comisión» del Mapa de carga: la carta (§5.2), §2.2 con su subsección, §3.2, §3.3 y §4. §3.4 quedó leída en la misma salida de lectura; no la uso para fundar nada |
| Otros documentos cargados | `Cadena-De-Consecuencias` 2.0: §2, antes de recomendar (la carta lo pide). `Escalas-De-Juicio` 1.0: §3.2, §3.3 y §3.4, por remisión de la carta. `Versionado-Producto-Integral` 2.0: §2.6 entero, por respaldo, porque el dictamen funda P3 en esa sección y la carta pregunta si el rango con techo se reemplaza. `Excepcion-A-Un-Conocimiento` 2.0: **no se cargó**, porque no propongo dejar de seguir ninguna convención (ver §3, P3). `Mesa` 1.0: sólo la cabecera, para tomar la versión |
| Insumos leídos | Pedido (evidencia 001, desde la línea 4); folios 003, 004, 005 y 006; dictamen 021 (cabecera, §2.4, premisas, P1, P2, P3, P7, P12, P13, §6 y §7); análisis 020 (P1 y P3); constancia 022; I0 entero; I7 §3.1, §3.2, §3.9, §4.3, §5, §6 y §7; I4 §2, §3.1 a §3.6, §5 y §6 (fuentes 1 a 11); I2 §3.2 y lecciones P2 y P3; I1 e I3, búsquedas puntuales |
| No leídos | Informes de comisiones de la ronda 1 (009 a 018), el ensayo E01, R1–R4 y N1–N5: lo que el dictamen toma de ellos lo trato como texto del objeto (E2 sobre el folio 021). Lo que el folio 021 reporta de una medición entra como **heredado** cuando lo uso para pesar |
| Medios propios | Lectura del árbol con `sed -n`, `grep -n` y `wc -l` sobre los folios y los dossiers. Ningún dispositivo, ninguna compilación, ninguna fuente externa nueva: las fuentes de industria se citan por el dossier que las verificó |
| Rótulo | No nombra el repositorio privado de la app de referencia del PO, ni hosts, direcciones o series de dispositivos |

# Ronda 2 — Arquitecto MAUI híbrido: el dictamen de la ronda 1 frente a la investigación

## Índice

1. [Qué del dictamen confirma la investigación y qué contradice](#1-qué-del-dictamen-confirma-la-investigación-y-qué-contradice)
2. [Hallazgos](#2-hallazgos)
3. [Propuesta por pregunta](#3-propuesta-por-pregunta)
4. [Lo que revisé y está bien](#4-lo-que-revisé-y-está-bien)
5. [Solicitudes de convocatoria](#5-solicitudes-de-convocatoria)

Las citas de línea del folio 021 son de `actuaciones/021-informe-jurado-veredicto.md` y se tomaron con
`grep -n` el 2026-10-25. Los dossiers se citan como `I<n> §<sección>` y la fuente primaria con el número que
le da ese dossier o la síntesis I0 §8 (por ejemplo `I0[106]` es el README de Shiny.AppDeviceBridge).

---

## 1. Qué del dictamen confirma la investigación y qué contradice

### 1.1 P1 — Modelo de contenido

| Punto del dictamen (folio 021) | La investigación | Fuente primaria | Lectura |
| --- | --- | --- | --- |
| A más la definición de la encuesta como datos (l. 307–318) | I0 §7, fila P1, propone **C**: «el motor de encuestas en el contenido Blazor (A) y las encuestas como datos versionados (B)». I7 §6 (P1) y I1 llegan a lo mismo | ODK Central «Managing Forms in Central» (I0[6]); Dimagi «Ways to Update an Application» (I0[21]) | **Confirma** la composición. La forma adoptada y la C de I0 son la misma pieza en pantallas y en el motor |
| La definición «viaja **dentro del paquete de contenido** (un solo canal)» (l. 316–317) | I0 §1.2, punto 6: definiciones como datos «**con su propia línea de versión**», que resuelven la encuesta «**sin tocar el canal de código**». En la familia de encuestas, la definición se publica aparte del motor: el formulario se publica en Central y el motor se instala desde la tienda (I0 §1.1, fila «Formulario versionado tipo ODK») | ODK Central (I0[6]); XLSForm `version` (I0[8]); CommCare (I0[20][21]) | **Contradice.** Es la única columna en la que el dictamen se aparta de la C de I0 (H-01) |
| Descarta C-min porque pierde la corrección de pantallas sin tienda (l. 357–359) | I4 §5, fila P1: el ecosistema oficial no actualiza código de pantallas sin tienda. A sólo existe con `HybridWebView` y `WebResourceRequested` o con un tercero | Microsoft Learn, Blazor Hybrid: «After the app is built, the .NET code Web View content sources can't change» (I4[3], I0[100]) | **Confirma** que C-min no cumple la lectura (b) |
| La revisión «una revisión real de Apple rechaza el `.wasm`: iOS pasa a B» (l. 376) | I0 §5: «Ninguna política de Apple ni de Google nombra WebAssembly»; la definición como datos «queda fuera de la discusión de código». I4 §3.5: tratar el WASM AOT con más cautela que el IL interpretado (criterio de I4) | Apple App Review 2.5.2 y DPLA 3.3.1(B) (I0[1][2]); Microsoft, Blazor WASM IL interpretado (I0[102]) | **Confirma el riesgo** y muestra un costo de la forma adoptada: si la definición va dentro del paquete WASM, caer a B en iOS obliga a separarla después (H-01) |
| El precio de A: unos 2 s de arranque, 9,13 MB por versión (l. 365–370) | I4 §3.6: no hay mediciones publicadas de Blazor WASM en WebView móvil; «lo único medido es nuestro g42» | — (ausencia, NO VERIFICADO en I4) | Ni confirma ni contradice: la investigación no trae otra medida. La cifra es heredada del folio 021 |

### 1.2 P2 — Canal, momento y activación

| Punto del dictamen | La investigación | Fuente primaria | Lectura |
| --- | --- | --- | --- |
| No esperar la red al abrir (N = 0), consultar en segundo plano y **activar en el próximo arranque en frío** (l. 409–411) | I0 §2: por defecto, Expo, Shorebird y Capawesome revisan al abrir sin bloquear y aplican en el próximo arranque. Shorebird da la razón: «the patch cannot be hot-swapped into memory dynamically on that launch» | Expo «Download updates» (I0[35]); Shorebird «Code Push» (I0[50]); Capawesome (I0[48]) | **Confirma** |
| Tres disparadores de una misma rutina, uno de ellos el login con cuenta (l. 410) | I0 §2: CommCare chequea tras el login y **aplica en el login siguiente**; D365 FS hace la primera sincronización al loguear; Salesforce baja la agenda «at login» | Dimagi (I0[21]); Microsoft D365 FS (I0[128]); Salesforce Help (I0[134]) | **Confirma**: bajar al loguear y aplicar después |
| Forzado de contenido: se activa «en el próximo **punto seguro**: un arranque en frío, **o el fin de la encuesta en curso** con un aviso» (l. 418) | Todas las plataformas OTA leídas aplican en el próximo arranque. En Shiny, la obligatoria se instala **antes de mostrar** la app, no a mitad de sesión. CommCare aplica en el login siguiente | Shiny README (I0[106]); I4 §3.1; Shorebird (I0[50]); Dimagi (I0[21]) | **Contradice en parte.** Ninguna fuente leída activa contenido a mitad de sesión, y la activación a mitad de sesión choca con el rollback por marca del propio dictamen (H-02) |
| Rollback local por marca «pendiente» y `Listo(version)` (l. 398) | Expo recupera sólo errores tempranos, en los primeros 10 s. Capawesome vuelve al último bundle sano. Shiny **no tiene rollback**: «Old releases are never reinstalled» | Expo «Error recovery» (I0[37]); Capawesome (I0[48]); Shiny README (I0[106]) | **Confirma**, y además el dictamen cubre más que Expo: la marca no depende de un plazo |
| Servidor estático con un índice firmado por canal; acepta sólo una versión «estrictamente mayor que la instalada en ese canal» (l. 387, 396) | En el protocolo de Expo, el cliente envía `expo-runtime-version` y el servidor responde «el update más reciente **para ese runtime**» | Expo Updates v1 (I2 §3.2, I2[5]; I0[36]) | **Contradice por omisión.** Con un solo índice por canal, un cascarón que quedó en el mayor anterior del puente no recibe más correcciones (H-03) |
| Canal propio y autoalojable | Tras el retiro de CodePush el 2025-03-31 y el fin de ventas de Appflow, depender de un servicio ajeno es un riesgo real | Microsoft, App Center Retirement (I0[42]); Ionic, 2025-02-11 (I0[44]) | **Confirma** |

### 1.3 P3 — Cascarón, puente y clave de compatibilidad

| Punto del dictamen | La investigación | Fuente primaria | Lectura |
| --- | --- | --- | --- |
| Un predicado evaluado antes de activar: rango con techo sobre el puente, `requires ⊆ catálogo` y motor mínimo (l. 487–498) | I7 §5, punto 2, y I0 §7, fila P3: «clave de compatibilidad **exacta** derivada del código» (`runtimeVersion`/`fingerprint`). «La evidencia de Expo y Capgo favorece la coincidencia exacta o el piso calculado, no un rango a mano» | Expo «Runtime versions» y «Fingerprint» (I7[1][3]); Capgo «Compatibility» (I7[15]) | **Contradicción aparente.** I7 marca esa frase como **criterio propio**. Las fuentes muestran tres familias, no una; y Capawesome usa un **rango** de versionCode mínimo y máximo (I2 §3.2, I2[23][24]). Lo que sí falta en el dictamen es **detectar** el cambio de contrato sin depender de quien sube la versión a mano (H-05). La clave exacta como decisor no pasa (§3, P3) |
| El transporte (`hybridwebview.js`, `__hwvInvokeDotNet`) es parte del contrato y su dueño es el cascarón (l. 479–480) | MAUI 10 deja de tener soporte el **2027-05-11**. En .NET 11, la interop JS→.NET apta para trimming exige registrarse con `JsonSerializerContext` | Microsoft «.NET MAUI Support Policy» (I4[20], I0[104]); «HybridWebView — .NET MAUI» (I4[1]) | **Confirma** que es contrato, y agrega un evento fechado que el dictamen no prevé (H-08) |
| `minShellVersion` no es piso; si el servidor filtra, es derivado del predicado y con techo (l. 496–497) | Shiny usa `minimumHostVersion`, que es un **piso**. Capgo usa `--auto-min-update-version`, un piso calculado | Shiny README (I0[106]); Capgo (I7[15]) | La industria usa pisos. El dictamen se aparta por VPI §2.6 («Nunca un piso a secas»), una decisión cerrada del contrato (folio 003, l. 77). La divergencia está declarada. **Confirma** |

### 1.4 P7 — Líneas de versión (sólo la relación entre líneas; la gramática no es de mi competencia)

| Punto del dictamen | La investigación | Fuente primaria | Lectura |
| --- | --- | --- | --- |
| Líneas separadas: cascarón, puente, contenido, definición, catálogo y esquema (l. 641–650) | I0 §7, fila P7: al menos cuatro líneas (cascarón, clave de contrato, contenido y definición). En encuestas, al menos tres: definición, motor y servidor | ODK XForms `orx:version` (I0[7]); Dimagi (I0[22]); Expo y Shorebird (I0[33][54]) | **Confirma** la separación |
| La definición tiene `encuestaId` y `version` propios, **pero viaja en el paquete de contenido** (l. 316–317, l. 647) | Una definición que usa una capacidad nueva del lenguaje exige un motor nuevo: Central 2024.3 exige Collect 2024.3 para Entities; Survey123 lee `appversion` en un `constraint` | Foro ODK, anuncio de Central v2024.3 (I1[14], I0[9]); idea de Esri «Minimum field app version requirement», *Implemented* (I0[26]) | **Contradice por omisión**: falta la relación declarada entre la definición y el motor (H-01) |
| «Catálogo de capacidades: se versiona junto con el puente» (l. 648) | Expo y Capacitor separan la clave del binario de la versión de la app. Adaptive Cards declara `requires` con **capacidad y versión mínima** por elemento | Expo (I7[1]); Adaptive Cards «FactSet» (I3 F14, I0[90]) | Confirma que el catálogo pertenece al contrato. **Contradice por omisión** en la regla de clasificación (H-04) y en la versión por capacidad (H-09) |

### 1.5 P12 — Capacidades del dispositivo y el manifiesto

| Punto del dictamen | La investigación | Fuente primaria | Lectura |
| --- | --- | --- | --- |
| Catálogo constante en el cascarón; el manifiesto declara sólo lo que el catálogo implementa (l. 838–845) | «El manifiesto es frontera dura en todas las fuentes leídas.» Shiny: «Keep native capabilities in the binary (bridges ship with the app), ship a complete baseline» | Expo «Permissions»: «Changes to the Info.plist cannot be updated over-the-air» (I0[39]); Shiny README (I0[106]) | **Confirma** |
| Descubrimiento por `bridge.handshake`; el permiso se consulta en el uso (l. 847–849) | Capacitor `isPluginAvailable`; React Native `get` → `null`; Shiny `GET /_bridge/host`, `501` y `403 access_denied` | Capacitor (I0[69]); React Native (I0[66]); Shiny (I0[106]) | **Confirma** el patrón |
| Cómo pide el contenido: «verificar, pedir en contexto, rationale y salida a ajustes» (l. 848–849) | En HybridWebView Android, interceptar los pedidos de permiso del WebView sigue abierto (#25784, en Backlog; #30847, `p/0`). I4 propone, como criterio propio, que el contenido pida por el puente C# | `dotnet/maui#25784` y `#30847` (I4[24a][24b], I0[111][112]) | **Contradice por omisión**: el dictamen no prohíbe al contenido pedir por las API web del WebView (H-06) |
| Capacidad nueva en dos tiempos, como `optional` hasta que la base se actualice (l. 855–856) | Capgo y Expo atan el contenido a la clave del binario; Adaptive Cards usa `requires` y `fallback` | Capgo (I7[15]); Adaptive Cards (I0[90]) | **Confirma**, con una condición: que una entrada nueva del catálogo sea un cambio **menor** del puente (H-04). Una clave exacta lo haría imposible (§3, P3) |

### 1.6 Tabla diferencial (§3.3): P1 del dictamen, C-min, la C de I0 y Shiny.AppDeviceBridge

Una fila por camino y una columna por cada cosa que pasa entre «hay que corregir una encuesta o una pantalla» y
«el encuestador la ve». Cada celda lleva su ancla. Shiny no lo midió la mesa: es la documentación del proveedor
(HECHO de lo que declara hacer, I0 §0) y sirve de **referencia**. No es un «caso que funciona» medido.

| Camino | Quién dibuja las pantallas | Qué se publica para corregir una **encuesta** | Qué se publica para corregir una **pantalla** | Línea de versión de la definición | Artefacto y canal de la definición | Runtimes en el teléfono | Compatibilidad contenido ↔ cascarón | Rollback | Riesgo de tienda en iOS |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| **P1 del dictamen** | Páginas Razor genéricas en Blazor WASM descargado (021 l. 307–317) | **Un paquete de contenido completo**: código y definición, 9,13 MB por versión, cifra heredada (021 l. 316–317, 366) | El mismo paquete (021 l. 309–311) | `encuestaId` + `version` (021 l. 647) | **Dentro del paquete de contenido, un solo canal** (021 l. 316–317) | Dos: MAUI y WASM (020, matriz P1, fila A) | Rango con techo, catálogo y motor (021 l. 490–492) | Marca «pendiente» → `previous` (021 l. 398) | Cada corrección de encuesta es una publicación de **código** `.wasm`, NO VERIFICADO (I0 §5) |
| **C-min** (análisis r1) | Componentes Razor compilados en el cascarón, en `BlazorWebView` (020 l. 232–233) | Sólo la definición, con tamaño sin medir (020 l. 247) | **Release del cascarón por tienda** (020 l. 273) | Propia | Por el canal, como dato | Uno (020 l. 247) | Esquema de la definición y puente (020 l. 369) | El canal (P2) | Datos: «fuera de la discusión de código» (I0 §5) |
| **C de I0** | Motor de encuestas en el contenido Blazor actualizable (I0 §7, fila P1) | **Sólo la definición** (I0 §1.2, punto 6: «sin tocar el canal de código») | Contenido (A) | Propia, como ODK: `orx:version` / `yyyymmddrr` (I0[7][8]) | **Separada del código** (I0 §1.2, punto 6), sin canal definido | Dos | Clave exacta derivada por hash (I0 §7, fila P3) | Al embebido, como Expo (I0 §1.2, punto 5) | Datos fuera; código en zona gris (I0 §5) |
| **Shiny.AppDeviceBridge** | Cualquier web estática servida desde el zip por **HTTP loopback** (I4 §2, I0[106]) | No distingue: un release completo del zip (I4 §3.2) | Un release completo del zip (I4 §3.2) | — | — | Lo que traiga la web (I4 §2) | `minimumHostVersion`, un **piso** (I4 §3.2) | **No hay**: «Old releases are never reinstalled» (I0[106]) | El proveedor argumenta con «HTML and JavaScript», no con WASM (I4 §3.5) |

**Columna que cambia entre P1 del dictamen y la C de I0: el artefacto que lleva la definición** (y, por eso, qué se
publica para corregir una encuesta). Las otras diferencias, la clave exacta y el rollback al embebido, se tratan en
P3 y en §4. Siguiendo §3.3, la primera salida es **igualar esa columna a la de la C de I0**: la definición como
artefacto propio. La forma concreta va en §3, P1.

**Diferencias declaradas frente a Shiny**, cada una con por qué no se iguala:

| Columna | Shiny | Dictamen | Por qué no se iguala |
| --- | --- | --- | --- |
| Cómo se sirve el contenido | HTTP loopback (I0[106]) | `HybridWebView` + `WebResourceRequested` (021 l. 309–311) | E1 heredado: E01 lo midió en el g42 (021 l. 345). Un servidor en loopback agrega un puerto abierto en el teléfono, y nadie lo midió aquí |
| Compatibilidad con el cascarón | Piso `minimumHostVersion` | Rango con techo | E4: VPI §2.6, «Nunca un piso a secas», decisión cerrada en el folio 003 (l. 77–82) |
| Rollback | No hay | Marca y `previous` | E1 heredado: E02-R, corridas 3 a 5 (021 §2.4, H-04) |
| Obligatoria | Se instala antes de mostrar, con un tope de 5 s (`CheckTimeout`) y la falla tratada como sin red (I4 §3.1) | No espera la red: N = 0 (021 l. 409) | F005: sin red se trabaja (021, premisa «Operación sin red»). E1 heredado: en E02-R, corrida 1, el render esperó la descarga (021 §2.4, H-09) |
| Capacidades | Bridges HTTP, `501` y `403`, `GET /_bridge/host` (I4 §3.4) | `bridge.handshake` y catálogo (021 l. 847) | Es el mismo patrón por otro transporte. Ninguna diferencia de fondo |
| Producto o pieza propia | Tercero MIT, beta desde el 2026-09-18, de 1.0.0 a 2.1.0 en 15 días, 1 581 descargas (I4 §2, I4[7]) | Pieza propia de la guía | I0 §1.3 lo trata como «único producto de tercero», en beta. El pedido pide una **guía** que enseñe la técnica (folio 003, l. 24–26). Depender de un servicio ajeno es un riesgo documentado (I0[42][44]). Shiny queda como referencia en la guía (H-07) |

---

## 2. Hallazgos

| Id | P0–P3 | Ancla (E1–E4 o C) con cita | Hallazgo | Impacto | Dirección de la corrección |
| --- | --- | --- | --- | --- | --- |
| H-01 | P1 | **E2**: 021 l. 316–317, «viaja **dentro del paquete de contenido** (un solo canal)». La única fuente literal del PO sobre el tema es F005: «si la encuesta cambia o se arregla o actualiza, es simplemente una actualización interna sin pasar por el appstore» (folio 005, l. 13), que no dice cómo viaja. Contra el dictamen: I0 §1.2, punto 6, «sin tocar el canal de código»; ODK publica el formulario aparte del motor (I0[6]) | **Lo que el dictamen da por fijo sin origen** (primer hallazgo de la carta): el acoplamiento de la definición al paquete de código no sale de ninguna frase del pedido ni de una decisión cerrada. Es la columna en que el dictamen se aparta de la C de I0 y de la práctica de las plataformas de encuestas. Además, el dictamen no declara qué versión del motor necesita cada definición, cosa que ODK y Survey123 sí declaran (I1[14], I0[26]) | Cada corrección de una encuesta pasa a ser una publicación de **código**. Tamaño heredado: 9,13 MB por versión (021 l. 366); el de una definición sola, sin medir. La corrección espera al próximo arranque en frío y pasa por el rollback de código. En iOS la superficie frente a 2.5.2 crece con cada corrección de datos. Y la condición de revisión «iOS pasa a B» (021 l. 376) obliga a separar la definición **después**, en el actualizador, que vive en el cascarón y sólo cambia por tienda | La definición pasa a ser un **artefacto propio** dentro del **mismo índice firmado** (un solo canal y una sola firma, pero dos clases de artefacto). Lleva su `version` y una línea `compatible-con-contenido: >=A.B.C <D.0.0` en la forma de VPI §2.6. Se activa al empezar la **próxima encuesta**: la que está en curso termina con la suya (P13, punto 2). Ver §3, P1, con su cadena |
| H-02 | P1 | **E3** construido sobre el texto: 021 l. 418 («se activa … en el próximo punto seguro: un arranque en frío, **o el fin de la encuesta en curso**»), l. 411 («Activación: en el próximo arranque en frío») y l. 398 («Si **el arranque siguiente** la encuentra, vuelve a `previous`») | Contraejemplo: llega un contenido v5 `mandatory` con un defecto que hace fallar el arranque del contenido antes de `Listo`. Se activa al terminar la encuesta en curso y el WebView recarga v5, que falla. La marca «pendiente» se revisa recién en el **próximo arranque en frío**, así que el encuestador queda con un contenido roto hasta que mata la app. El texto no dice si sin encuesta en curso el forzado activa en el momento o espera, y eso da dos lecturas entre implementadores. Ninguna fuente leída activa a mitad de sesión (I0 §2: Expo, Shorebird, Capawesome, CommCare y Shiny aplican en el próximo arranque, en el próximo login o antes de mostrar) | El camino forzado, que es justamente el que más alcance tiene, es el único que puede dejar al usuario sin salida en la sesión. Dos lecturas de «punto seguro» | El forzado **se activa en el próximo arranque en frío, igual que el resto**. Lo que cambia con `mandatory` es otra cosa: al abrir, el cascarón activa **antes de mostrar** el `mandatory` que ya estaba **bajado y verificado** en `staging/` desde la sesión anterior, sin esperar la red (patrón de CommCare, I0[21]). Se quita «o el fin de la encuesta en curso». Si la presidencia quiere conservar la activación en sesión, cada recarga del WebView tiene que contar como un arranque a efectos de la marca |
| H-03 | P1 | **E2**: 021 l. 387 (un índice por canal), l. 396 (versión «estrictamente mayor que la instalada en ese canal») y l. 490 (el predicado rechaza otro mayor del puente), frente a l. 855–856 (la capacidad nueva va como `optional` «hasta que la base instalada se actualice»). Contra el dictamen: Expo Updates v1 responde «el update más reciente **para ese runtime**» (I2 §3.2, I2[5]) | Con un único índice por canal que lista una sola versión, cuando el puente sube de mayor **todo cascarón del mayor anterior rechaza el índice nuevo y no vuelve a recibir correcciones** hasta que se actualice por tienda. El dictamen supone que las dos poblaciones conviven (l. 856), pero el canal que fija no puede servir a las dos | Después de cada mayor del puente, una parte de la base instalada queda congelada. En iOS el cascarón no se puede forzar (021 l. 422; el cascarón en iOS sólo se bloquea y se manda a la ficha). Es el problema de los «clientes que no se pueden actualizar», documentado como deuda (thamer, OPINIÓN, I0[158]; Netflix, I0[87]) | **Un índice por canal y por mayor del puente**, en una ruta estática (por ejemplo `/{canal}/puente-{mayor}/indice.json`). El cascarón lee el de su mayor. Así el servidor sigue estático y cumple lo que Expo resuelve del lado del servidor. Publicar una corrección para el mayor anterior es una decisión del producto, que la guía enseña |
| H-04 | P1 | **E4 + E2**: VPI §2.6, «Clasificar: … **todo miembro nuevo en un tipo interfaz es cambio mayor**; sólo lo aditivo en clases y registros es menor». 021 l. 648, «Catálogo de capacidades: se versiona junto con el puente». 021 l. 855–856, la capacidad nueva entra como `optional`. I7 §5, punto 1, propone escribir el contrato como interfaces C# (`IUbicacion`, `ICamara`) | Si el contrato del puente se escribe como interfaces C#, que es el patrón que I7 recomienda copiar, la regla de VPI clasifica **cada capacidad nueva como cambio mayor**. Entonces el rango con techo del contenido instalado rechaza al cascarón nuevo, y el ingreso en dos tiempos de P12 no funciona. El dictamen no dice qué es menor y qué es mayor para el puente. La regla de VPI piensa en quien **implementa** una interfaz; acá el cascarón implementa y el contenido consume | Cada capacidad nueva obligaría a republicar todo el contenido para el mayor nuevo, y la semilla quedaría como único contenido del cascarón nuevo hasta entonces. Implementadores distintos clasificarían distinto | Declarar en P3 y P7 que, **para el puente**, agregar un método o una entrada del catálogo es **menor**, y que quitar o cambiar la forma de un sobre es **mayor**, con el fundamento de que la superficie la consume el contenido y no la implementa. Que la regla de la compuerta lo refleje es de Integración: va como solicitud (§5) |
| H-05 | P1 | **E2 + E4**: 021 l. 645, la versión del puente es «una constante del cascarón». VPI §2.6: «Detectar un cambio de API y clasificarlo son dos actos distintos. El que sólo detecta deja el incremento en manos de quien regenera la línea base». Industria: Expo advierte el desajuste de `appVersion` cuando no se sube a mano y ofrece `fingerprint` (I2 §3.2, I2[1]; I7[3]). Opinión: «runtimeVersion is a hand-maintained string» (tommyshellberg, 2026-08-06, I0[58]) | El dictamen fija **qué** compara el predicado, pero no **cómo se detecta** que el contrato cambió sin que nadie subiera la constante. Es la falla que la industria cubre con una huella calculada. La investigación (I7 §5, I0 §7, fila P3) propone que esa huella sea la clave misma; eso lo trato en §3, P3 | Un cambio del contrato con la constante sin subir activa contenido incompatible. La marca lo atrapa sólo si el contenido falla antes de `Listo` (021 l. 398). Si falla después, no hay rollback | El build del cascarón **calcula una huella del contrato**: un hash de los esquemas de los sobres y del catálogo. La compuerta falla si la huella cambió y la versión del puente no subió según la clasificación de H-04. Esto es «Detectar» de VPI §2.6. El `handshake` devuelve también la huella, sólo para la pantalla de diagnóstico. **La huella no decide la activación**: decide el rango |
| H-06 | P1 | **E2**: 021 l. 848–849 dice cómo pide el contenido, pero no por **qué vía**. HECHO: en HybridWebView Android, interceptar los pedidos de permiso del WebView está abierto (`dotnet/maui#25784`, Backlog; `#30847`, `p/0`, I4[24a][24b]). I4 §3.4 propone el puente C# (criterio de I4) | Un implementador puede pedir ubicación o cámara con las API web del WebView (`navigator.geolocation`, `getUserMedia`) y saltear el catálogo. En Android ese camino depende de un manejo de permisos que MAUI tiene abierto, y en Apple una descripción de uso que falta cierra la app (Shiny, I0[106]) | El catálogo deja de ser la frontera: aparece una capacidad que el `handshake` no informa y el predicado no compara. Habría lecturas divergentes del mismo P12 | Escribir en P12: **toda capacidad del dispositivo pasa por el puente**. El contenido no usa las API web que piden permisos, y su política del documento (CSP y `Permissions-Policy`) las niega. Que haya una prueba de eso en la compuerta va como solicitud a Integración (§5) |
| H-07 | P2 | **E2**: el folio 021 no nombra a Shiny.AppDeviceBridge. I4 §2 lo describe como el «**único** producto de tercero» del ecosistema que «implementa justo el patrón del borrador» (I0 §1.3; fuentes I0[105][106][107]) | El dictamen se escribió antes de la investigación, así que no tiene la tabla diferencial contra la única referencia .NET. Las cuatro diferencias de fondo (transporte, piso contra rango, rollback y obligatoria antes de mostrar) están justificadas en el árbol (tabla de §1.6), pero no declaradas | Un lector que encuentre Shiny no va a saber por qué la guía hace otra cosa | La guía incluye la tabla diferencial de §1.6, con Shiny rotulado «referencia documentada por el proveedor, no medida». **No se adopta Shiny como dependencia**: es beta, pasó de 1.0.0 a 2.1.0 en 15 días (I4 §2) y una dependencia ajena para el canal es un riesgo documentado (I0[42][44]) |
| H-08 | P2 | **E2**: 021 l. 479–480 (el transporte es parte del contrato) y l. 511–512 (la única condición de revisión de P3 es «una de las tres dimensiones nunca rechaza un paquete»). HECHO: MAUI 10 sin soporte desde el 2027-05-11 (I4 §3.2, I4[20]); en .NET 11 cambia el registro de la interop (I4[1]) | Hay una fecha que obliga a publicar un cascarón nuevo por tienda, con un MAUI nuevo que puede cambiar el transporte. Si cambia, el puente sube de mayor. P3 no lo prevé como evento | El salto de MAUI cae sin plan: o se sube el mayor del puente sin índice para el mayor anterior (H-03), o no se sube y el transporte cambia sin rojo | Agregar a P3 un evento de revisión comprobable: **«un PR sube el mayor de MAUI del cascarón»**. Ese PR compara la huella del transporte (H-05) y, si cambió, sube el mayor del puente y publica el índice del mayor nuevo, con la semilla compatible (021 l. 402) |
| H-09 | P2 | **E2**: 021 l. 841–843, cada entrada del catálogo lleva «la versión de su contrato en el puente», pero `capabilities: { requires, optional }` (l. 850) y el predicado `requires ⊆ catálogo` (l. 491) comparan sólo **identificadores**. HECHO: Adaptive Cards declara `requires` con «features … with corresponding minimum version» (I3 F14, I0[90]) | Si `camera.capture` cambia su sobre, un contenido que la exige con la forma vieja pasa el predicado | La capacidad está, pero con otra forma. La falla aparece en el uso, después de `Listo`, donde ya no hay rollback (021 l. 398) | Cada ítem de `requires` y `optional` lleva su id y un rango con techo sobre la versión de esa entrada del catálogo, en la forma de VPI §2.6. El predicado compara id y rango |

Nueve hallazgos: P0 = 0, P1 = 6, P2 = 3, P3 = 0. Ninguno es heredado de un informe anterior sin abrir: las cifras
medidas que uso para pesar (9,13 MB, E01, E02-R) son heredadas del folio 021 y así se rotulan. No fundan ningún
hallazgo.

---

## 3. Propuesta por pregunta

### P1 — **MODIFICAR**

**Cómo.** Se mantiene A más la definición como datos, con las condiciones C-1 a C-4, iOS ≥ 16.4 y el umbral de
arranque. Cambia una pieza: la definición sale del paquete de código y pasa a ser **un artefacto propio en el mismo
índice firmado** (H-01), con:

- `encuestaId` y `version`;
- `compatible-con-contenido: >=A.B.C <D.0.0`, que es la versión del motor de encuestas que necesita;
- `sha256` y `size`, como los demás archivos del índice.

El actualizador verifica la definición con la misma firma y la misma cadena (021 l. 396). Las páginas Razor del
contenido la toman al empezar una encuesta nueva; la que está en curso termina con su versión (021, P13, punto 2).

**Fundamento.** H-01. I0 §1.2, punto 6, y §7, fila P1. Práctica de ODK y CommCare: definición publicada aparte y
versión mínima del motor (I0[6][21], I1[14]). La condición de revisión de iOS del propio dictamen (l. 376).

**Cadena de consecuencias (`Cadena-De-Consecuencias` §2):**

1. **Dónde cae.**
   - Si la definición va en el paquete (el dictamen): en cada corrección de encuesta, que pasa a ser un release de
     código, y en el día en que iOS caiga a B.
   - Si es un artefacto propio (esta propuesta): en el esquema del índice (una clase de artefacto más), en el
     actualizador del cascarón y en un concepto más para la guía, la compatibilidad definición → motor.
2. **Cuánto pesa.**
   - Paquete de contenido: 9,13 MB por versión retenida, heredado del folio 021 (l. 366).
   - Una definición sola: **sin medir**. Es la misma medida que el análisis ya había pedido (020 l. 659: E02-B con la
     definición bajada por el canal firmado). Queda asentada como falta.
   - Código del actualizador: sin medir.
3. **Qué pierde cada rama.**
   - El dictamen pierde que una corrección de datos no toque el código, y paga retrabajo en el cascarón si iOS cae
     a B.
   - La propuesta pierde la unidad de «un paquete, una versión» y suma una relación de compatibilidad.
4. **¿Es reversible?**
   - **No igual de barato después.** El actualizador vive en el **cascarón**, que sólo cambia por tienda. Separar
     la definición después de tener cascarones instalados cuesta un release por tienda y convivir con los que no
     actualicen (Cadena §2, paso 4: se juzga por lo que cuesta volver).
   - Juntarlas otra vez, en cambio, es barato: el contenido puede ignorar el artefacto separado.
   - Por eso se decide ahora y en esta dirección.
   - **Condición de revisión:** si en la demo ninguna definición se publica sin un paquete de contenido nuevo durante
     las corridas de la compuerta, la separación no se usó y se vuelve a evaluar.

**Lo que no cambia.** C-min sigue descartada por la lectura (b) (§1.1). Shiny no cambia P1: es un transporte de
contenido, no un modelo (tabla de §1.6).

### P2 — **MODIFICAR**

**Cómo.**

- **Forzado (H-02):** `mandatory` se activa en el próximo arranque en frío, **antes de mostrar**, siempre que ya esté
  bajado y verificado en `staging/` desde una sesión anterior. Nunca se espera la red al abrir; N = 0 no cambia. Se
  quita «o el fin de la encuesta en curso».
- **Índice por mayor del puente (H-03):** un índice firmado por canal y por mayor del puente, en ruta estática.
- **Dos clases de artefacto (H-01):** contenido y definición, con la misma firma y verificación. El contenido se
  activa en el arranque en frío y la definición al empezar una encuesta.

**Fundamento.** H-01, H-02 y H-03. Expo, Shorebird, Capawesome y CommCare aplican en el próximo arranque o login
(I0 §2). En Expo Updates v1 el servidor responde por runtime (I2[5]).

**Cadena de consecuencias (forzado, H-02):**

1. **Dónde cae.** En el tiempo que tarda en llegar una corrección forzada.
2. **Cuánto pesa.** Un arranque en frío más, en el peor caso. La frecuencia de arranques en frío del usuario no está
   medida. La opinión de Kikoff es que la adopción ≈ frecuencia de arranques en frío (OPINIÓN, I0[56]).
3. **Qué pierde cada rama.**
   - Sin activación en sesión se pierde la activación «al terminar la encuesta».
   - Con ella, se pierde el rollback en ese camino (contraejemplo de H-02).
4. **¿Es reversible?** Sí, las dos ramas. Se toma la que no deja al usuario sin salida.

**Condición de revisión:** una medición de arranques en frío por día en el teléfono de juicio que muestre que el
forzado tarda más de lo que el producto tolera. Ese valor lo fija Formal, no esta comisión.

**Cadena de consecuencias (índice por mayor, H-03):**

1. **Dónde cae.** En la ruta del servidor y en el cascarón, que lee la ruta de su mayor.
2. **Cuánto pesa.** Un segmento de ruta y un índice firmado más por cada mayor vivo. Se cuenta por mayores, y hoy hay
   uno.
3. **Qué pierde cada rama.**
   - Sin índice por mayor se pierde la posibilidad de corregir a los cascarones viejos.
   - Con él, se pierde un poco de simplicidad del servidor.
4. **¿Es reversible?** No barato después: la ruta la lee el cascarón instalado. Se decide ahora.

### P3 — **MODIFICAR** (el rango con techo **no** pasa a clave exacta)

**Decisión que pide la carta: el rango con techo de P3 no pasa a clave exacta derivada por hash. La huella del
contrato entra como detección en la compuerta y como dato de diagnóstico.**

**Por qué la clave exacta no pasa.**

1. **Contra la convención que rige.** VPI §2.6 exige la forma `>=A.B.C <D.0.0` y dice que la compuerta cuenta como
   ausente lo que no la tenga (E4, VPI 2.0 §2.6). Una clave exacta como decisor obligaría a dejar de seguir VPI §2.6,
   y para eso hace falta una contradicción (Mesa-De-Expertos-A-Pedido §4, «Sólo por contradicción»). No la hay: lo
   que la clave exacta cubre se cubre con «Detectar» de la misma §2.6.
2. **Rompe P12.** Con clave exacta, un contenido que usa una capacidad nueva lleva la clave del cascarón nuevo y
   **no llega nunca** a los cascarones viejos, ni siquiera como `optional`. El ingreso en dos tiempos (021 l. 855–856)
   desaparece, y cada release del cascarón exige republicar el contenido para su clave. Es el costo que Expo declara
   para `fingerprint`: «cambia ante cualquier cambio que afecte lo nativo; más builds» (I2 §3.2, I2[1]).
3. **La industria no es unánime.** Hay tres familias (I7 §3.9). Capawesome usa un rango de versionCode mínimo y
   máximo (I2[23][24]). La preferencia por la clave exacta es **criterio propio de I7** (I7 §5, punto 2).

**Qué cambia en P3.**

- **Huella calculada (H-05).** El build del cascarón calcula la huella del contrato: los esquemas de los sobres, el
  catálogo y la versión de cada entrada, y el transporte. La compuerta falla si la huella cambia sin que suba la
  versión del puente según la clasificación de H-04.
- **Clasificación del puente (H-04).** Agregar un método o una entrada del catálogo es menor; quitar o cambiar la
  forma de un sobre, o cambiar el transporte, es mayor.
- **`requires` con versión (H-09).** Cada ítem de `requires` lleva id y rango sobre la versión de la entrada.
- **Evento de revisión (H-08).** Se suma «un PR sube el mayor de MAUI del cascarón».
- **Índice por mayor (H-03)**, como en P2.

**Qué cambia en el `handshake`.** Devuelve:

- `puente` (SemVer, como hoy);
- `catálogo`, con la versión de cada entrada (H-09);
- `huella`, nueva y sólo informativa: se muestra en la pantalla de diagnóstico (021 l. 654–655) y no decide nada.

La decisión de activar sigue siendo del actualizador **antes** de activar, con el predicado. El `handshake` resuelve
lo opcional, como hoy.

**Qué cambia en P12.** Nada en su forma: se conserva el ingreso en dos tiempos, que la clave exacta habría roto. Se
suman H-06 (sólo por el puente) y H-09 (versión por capacidad).

**Cadena de consecuencias (rango con huella frente a clave exacta):**

1. **Dónde cae.**
   - Con la clave exacta: en cada release del cascarón, que exige republicar el contenido para su clave, y en los
     cascarones viejos, que no reciben capacidades opcionales.
   - Con el rango y la huella: en una compuerta que compara la huella contra la versión, y en una regla de
     clasificación que alguien tiene que escribir (Integración).
2. **Cuánto pesa.** Con la clave exacta, un build y una publicación de contenido por cada clave viva; con el rango,
   uno por cada **mayor** vivo. El número de releases del cascarón por año no está medido. El piso conocido es uno
   por año, por la fecha de soporte de MAUI (I4 §3.2, criterio de I4).
3. **Qué pierde cada rama.**
   - El rango pierde la garantía mecánica de igualdad exacta. La huella en la compuerta lo compensa del lado de quien
     publica.
   - La clave exacta pierde el ingreso en dos tiempos y la convención que rige.
4. **¿Es reversible?** Las dos se pueden revertir antes de que haya cascarones instalados; después, la forma de la
   declaración la leen los cascarones. Se toma la que cumple la convención y conserva P12.

**Condición de revisión:** en la compuerta, un rojo provocado con un contrato cambiado y la versión sin subir **no**
falla con la huella. Ese día la detección no sirve y se vuelve a evaluar la clave exacta, con ficha
(`Excepcion-A-Un-Conocimiento`).

No escribo ficha porque no propongo dejar de seguir ninguna convención.

### P7 — **MODIFICAR** (sólo la relación entre líneas; la gramática es de Integración)

**Cómo.**

- La fila «Definición de encuesta» (021 l. 647) suma su relación: «declara `compatible-con-contenido` con techo; se
  publica como artefacto propio» (H-01).
- La fila «Catálogo de capacidades» (l. 648) suma: «cada entrada tiene versión propia; agregar una entrada es menor
  del puente» (H-04, H-09).
- La **huella del contrato** no es una línea de versión: es un dato derivado y de diagnóstico (H-05), como el canal,
  que el dictamen ya declara puntero y no línea (l. 653).

**Fundamento.** H-01, H-04, H-05 y H-09. La gramática de cada línea y la regla de la compuerta quedan para Integración
(§5).

### P12 — **MODIFICAR**

**Cómo.** Se mantiene lo decidido: catálogo constante, `handshake`, permiso en el uso, `requires`/`optional`, ingreso
en dos tiempos y compuerta del AndroidManifest. Se suman dos cosas:

- **Sólo por el puente (H-06).** Toda capacidad del dispositivo pasa por el puente C#. El contenido no usa las API web
  que piden permisos y su política del documento las niega.
- **Versión por capacidad (H-09).** `requires` y `optional` llevan id y rango sobre la versión de la entrada.

**Fundamento.**

- `dotnet/maui#25784` y `#30847` (I4[24a][24b]).
- Shiny: una descripción de uso faltante en Apple cierra la app (I0[106]).
- Adaptive Cards `requires` con versión (I0[90]).
- Todas las fuentes leídas coinciden en que el manifiesto es frontera dura (I0 §4).

**Cadena de consecuencias.**

1. **Dónde cae.** En lo que el contenido tiene prohibido, y en el formato de `requires`.
2. **Cuánto pesa.** Una regla de política del documento y un campo de rango por ítem.
3. **Qué pierde la alternativa.** Sin H-06, aparece una vía de permisos fuera del catálogo y apoyada en un manejo que
   MAUI tiene abierto. Con H-06, se pierde la comodidad de usar la API web directa.
4. **¿Es reversible?** Sí: es contenido y una regla de la guía.

---

## 4. Lo que revisé y está bien

| Ítem | Por qué está bien |
| --- | --- |
| El rollback local por marca «pendiente», `Listo(version)` y la lista de fallidas (021 l. 398) | Cubre más que la referencia: Expo sólo recupera errores tempranos dentro de los 10 s (I0[37]) y Shiny no tiene rollback (I0[106]). La marca no depende de un plazo, así que no hay umbral X que fijar sin fuente. Es la respuesta documentada al «the app never runs long enough to fetch it» (Mason Roy, OPINIÓN, I0[57]) |
| No esperar la red al abrir (N = 0) y activar en el próximo arranque en frío (021 l. 409–411) | Es el comportamiento por defecto de Expo (`fallbackToCacheTimeout` 0), Shorebird y Capawesome (I0 §2; I0[34][35][48][50]), y la condición de F005: sin red se trabaja |
| Catálogo cerrado en el cascarón, que el contenido descubre (021 l. 838–847) | Coincide con lo que dicen igual todas las fuentes de I0 §4 y con los mecanismos de descubrimiento de Capacitor, React Native y Shiny (I0[66][69][106]). La lista de capacidades concedidas al contenido es lo que I7 propone copiar de Tauri y Portals (I7 §5, punto 4) |

---

## 5. Solicitudes de convocatoria

| A quién | Señal | Ubicación |
| --- | --- | --- |
| **Integración** (compuerta CI y gramática de versiones) | Hace falta una regla de clasificación del cambio del **puente** distinta de la de VPI §2.6 para interfaces C#: agregar un método o una entrada del catálogo es menor, quitar o cambiar la forma de un sobre es mayor (H-04). Hace falta también la compuerta que calcula la huella del contrato y falla si cambió sin subir la versión (H-05). Y la gramática de la línea nueva `compatible-con-contenido` de la definición (H-01) | Este folio, H-01, H-04 y H-05; VPI 2.0 §2.6, tabla «Detectar / Clasificar»; folio 021 l. 645–648 |
| **Integración** (pruebas de la compuerta) | Una prueba que falle si el contenido usa una API web que pide permisos o si su política del documento no la niega (H-06). Y la validación de cada definición contra su esquema y contra el motor mínimo que declara (propuesta de I3 citada en I0 §7, fila P6) | Este folio, H-01 y H-06; I0 §7, filas P6 y P8 |
| **Seguridad** (tiendas y firma) | Apple 4.7.2, «Your app may not extend or expose native platform APIs or technologies to the software without prior permission from Apple»: si alcanza al contenido propio que usa el puente está NO VERIFICADO (I0 §4; I0[1]). Tampoco está verificado si una capacidad `optional` que el contenido «enciende» después de la revisión puede leerse como «hidden features» (Expo #1865, I0[55]; layer8, OPINIÓN, I0[154]). Y si la definición como artefacto propio cambia la superficie de 2.5.2 en iOS (H-01) | I0 §4, «Lo específico de nuestro stack», y §5; folio 021 l. 855–856 |
| **Formal** (valores de umbral) | Si se conserva una activación del forzado en otro momento que no sea el arranque en frío (H-02), hace falta el plazo tolerado de llegada de una corrección forzada, medido en arranques en frío por día. Esta comisión no fija valores | Este folio, H-02 y §3, P2 |

Sigue: incorporación del siguiente informe y resolución · presidencia
