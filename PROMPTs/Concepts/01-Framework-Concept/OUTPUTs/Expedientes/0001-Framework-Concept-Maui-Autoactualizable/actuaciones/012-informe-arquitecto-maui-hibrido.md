| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-10-25 |
| Autor | Comisión Arquitectura .NET MAUI |
| Corrige | — |

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Rol | Arquitecto de aplicaciones móviles .NET MAUI (comisión, a ciegas) |
| Fecha | 2026-10-25 |
| Norma | `<base de conocimiento>/Knowledges/Knowledge-Mesa-De-Expertos-A-Pedido.md` 3.1 |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | cabecera y §0 (líneas 1–111); fila «Sos una comisión» del Mapa de carga: carta (§5.2), §2.2 con su subsección, §3.2, §3.3, §4 |
| Otros documentos cargados | `Cadena-De-Consecuencias` 2.0: §2 · `Escalas-De-Juicio` 1.0: §3.3 y §3.4 · `Versionado-Producto-Integral` 2.0: §2.3, §2.6, §2.7 (por remisión de T-1/T-3) · `Release-Y-Despliegue-Versionado` 2.0: §2.2 invariantes 5 a 12 (líneas 125–150) |
| No cargado | `Excepcion-A-Un-Conocimiento` (no propongo dejar de seguir ninguna convención; no hay ficha) · `Mesa` |
| Carta | `evidencia/005-carta-arquitecto-maui-hibrido.md` |

# Informe del Arquitecto MAUI — modelo de contenido, cascarón y puente, canal, base local, iOS

## Índice

1. [Lectura del objetivo](#1-lectura-del-objetivo)
2. [Hallazgos](#2-hallazgos)
3. [Respuesta a las preguntas P1, P2, P3, P5, P7, P9](#3-respuesta-a-las-preguntas)
4. [Lo que revisé y está bien](#4-lo-que-revisé-y-está-bien)
5. [Solicitudes de convocatoria](#5-solicitudes-de-convocatoria)
6. [Fichas de excepción](#6-fichas-de-excepción)
7. [Ensayos propios: E02-B y E02-R](#7-ensayos-propios-e02-b-y-e02-r)
8. [Fuentes](#8-fuentes)

## 1. Lectura del objetivo

Objetivo leído: folio 003, líneas 46–51. Cada cláusula tiene origen en el pedido, salvo lo que sigue.

| Lo que da por fijo | Origen | Lectura |
| --- | --- | --- |
| «apps .NET MAUI con páginas Blazor híbridas [prompt, Contexto] **que bajan sus actualizaciones** del servidor» | `EV001:15` («paginas .net blazor hibridas en .NET MAUI») + `EV001:21` | Las dos cláusulas tienen origen, pero **juntas son imposibles en la lectura técnica de «Blazor Hybrid»**: Microsoft define que en Blazor Hybrid «Razor components run natively on the device … Components don't run in the browser, and WebAssembly isn't involved» [D3]. Un componente de Blazor Hybrid es código del APK y no se baja. El ENUNCIADO del folio 003 (líneas 14–16) tiene una sola lectura y no registra las dos. **Primer hallazgo: H-01** |
| Las preguntas P4 y P5 (login, biometría, SQLite, outbox, conflictos, migraciones) | Folio 003, líneas 57–58: «(D-03, D-07)», «(D-04, D-05)», que salen del borrador `Framework-APP.md` | El prompt no nombra login, SQLite, offline ni outbox (`grep -n -i -E 'sqlite|offline|login|outbox' EV001` → sin coincidencias en las líneas 4–71). Su origen es el borrador, que el contrato declara «insumo e hipótesis a refutar» (línea 41). El contrato dice «Agregados de la presidencia: ninguno» (línea 51). **H-02** |

## 2. Hallazgos

| Id | Nivel | Ancla | Hallazgo | Impacto si no se corrige | Dirección de la corrección |
| --- | --- | --- | --- | --- | --- |
| H-01 | P1 | E2: folio 003:46–48 («páginas Blazor híbridas … que bajan sus actualizaciones»); [D3] cita literal arriba; `Framework-APP.md:39`: «En Blazor Hybrid (`BlazorWebView`) los componentes Razor **se compilan a la DLL de la app**» | El objetivo junta «Blazor híbridas» y «se bajan del servidor» sin decir cuál de las dos lecturas toma: (a) Blazor Hybrid, el término de Microsoft (`BlazorWebView`, no descargable), o (b) una app híbrida (nativa más web) cuyas páginas se escriben en Blazor. El modelo A que validó E01 es **Blazor WebAssembly** dentro de `HybridWebView`, no Blazor Hybrid | Quien implemente o lea la guía con la lectura (a) concluye que A no cumple el pedido, o pone pantallas de negocio en `BlazorWebView` y pierde la actualización sin tienda. Las lecturas se separan entre el refutador, el académico y la demo | En el ENUNCIADO, escribir las dos lecturas y tomar la (b), que es la que menos agrega, declarándola. Fijar en el glosario de la guía: «página actualizable = Blazor WebAssembly servido en `HybridWebView`; `BlazorWebView` sólo si la pantalla es del cascarón» |
| H-02 | P2 | E2: folio 003:51 y 57–58; E1: `grep -n -i -E 'sqlite\|offline\|login\|outbox'` sobre `EV001` → sin coincidencias | P4 y P5 entran como preguntas del caso con origen en el borrador, no en el pedido, y el contrato no las marca como agregado | La demo y la guía pueden crecer a login con biometría, outbox y conflictos sin que el PO lo haya pedido, a costa del núcleo pedido (actualización y PR) | Marcar P4 y P5 como agregados con origen en el borrador, salir al PO en el lote de cierre y acotar la demo a lo que el pedido nombra, dejando P4 y P5 como capítulos de la guía |
| H-03 | P1 | E1: `dotnet new maui-blazor` (SDK 10.0.400, Maui 10.0.20) → `E02B.csproj:44`: `SupportedOSPlatformVersion … 'ios'">15.0`. E1: MDN BCD `classes.json` (sha256 `9b9318aa…6dad`) → `static.initialization_blocks`: chrome `94`, safari `16.4`, `safari_ios`/`webview_ios`: `mirror`. E01 §6.3: el runtime JS de Blazor .NET 10 usa esa sintaxis | El modelo A exige un WKWebView que entienda bloques de inicialización estáticos (Safari ≥ 16.4). La plantilla de MAUI 10 declara iOS 15.0 como mínimo. En Android la falta se repara actualizando «Android System WebView» (E01, C-3), pero en iOS **WKWebView va con el sistema operativo**: no hay pantalla de «actualizá el WebView» posible, sólo «actualizá iOS». Ejecución en iPhone: **NO VERIFICADO** (no hay Mac). Tampoco se verificó si la publicación iOS por defecto dispara la restricción de `HybridWebView` con trimming completo [D1] | Una demo o un producto con iOS 15.0–16.3 instala el cascarón y muestra el contenido en «Loading» para siempre, igual que el emulador de E01 | Poner el piso de iOS del cascarón en 16.4 cuando el contenido es A, o rendir la semilla en una pantalla del cascarón para iOS < 16.4. Que el cascarón verifique la capacidad del motor antes de cargar el contenido (prueba de sintaxis o versión), igual que C-3 de E01 en Android |
| H-04 | P1 | E1: E02-R (§7.2), corridas 3 y 4 en el g42. E2: `Framework-APP.md:139`: «si el contenido no avisa "arranqué bien" … en X segundos, volver al anterior» | Un rollback por temporizador «X segundos» no tiene de dónde fijar X: en el g42 el primer render del contenido llegó entre 3,7 y 8,5 s desde el inicio del proceso (E02-R corridas 1–5; E01 §6.2: 4,4–6,3 s) y en gama baja no se midió. Lo que sí funcionó, medido: una **marca «pendiente»** al activar, que el contenido borra con `Listo(version)` por el puente. Si el arranque siguiente la encuentra, vuelve al anterior y anota la versión como fallida (E02-R corrida 4: `ROLLBACK: v3-roto no avisó 'arranqué' … vuelve a v1`; corrida 5: `IGNORADA v3-roto`). Costo medido: **una sesión rota** (captura 3: «Ocurrió un error no controlado») | Con un X corto se hace rollback de un contenido sano en un teléfono lento. Con un X largo el usuario queda trabado. Sin lista de fallidas, el contenido roto se vuelve a bajar en cada arranque (corrida 5 lo evita) | Mecanismo base: marca pendiente + rollback en el arranque siguiente + lista local de fallidas. Opcional: un vigilante dentro de la sesión que recarga la versión anterior, con un X calibrado sobre un piso medido en el teléfono de gama más baja que se soporte. La industria hace lo mismo: Capgo usa `notifyAppReady()` con `appReadyTimeout` (por defecto 10 000 ms) [D9] |
| H-05 | P2 | E2: `E01-…/src/Cascaron/E01/Actualizador.cs:83-85` (`Directory.Delete(DirPrevious)`; `Move(DirCurrent, DirPrevious)`; `Move(destinoStaging, DirCurrent)`) frente a `Framework-APP.md:123,138` («cambio atómico de puntero») | La activación de E01 no es atómica. Borra `previous` antes de que la nueva versión arranque, y entre los dos renombres no existe `current`. Si el proceso muere ahí, queda la semilla y se pierde la versión anterior. E02-R midió que la alternativa anda: versiones en `versions/vN` y un `puntero.json` escrito a `.tmp` y renombrado con `File.Move(…, overwrite: true)` | La guía y la demo enseñan una «activación atómica» que no lo es, y el rollback del H-04 no tiene a qué volver | Directorios inmutables por versión más un puntero que se cambia con un solo `rename`. El borrado de versiones viejas sale de la activación y va a la retención (H-10) |
| H-06 | P1 | E4: `Versionado-Producto-Integral` §2.6, línea 225: «**Nunca un piso a secas**». E2: `Framework-APP.md:134,302` (`minShellVersion`: versión mínima del cascarón) | `minShellVersion` es un piso sin techo (T-1). Además ata el contenido a la **versión del cascarón**, cuando el contrato real entre los dos es el **puente**: un cascarón puede subir de versión sin tocar el puente, o romperlo. Expo resuelve el mismo problema con `runtimeVersion` e igualdad («builds … would think the incoming update with the same runtime version was compatible») [D7] | Un contenido con `minShellVersion: 1.4.0` corre sobre un cascarón 2.0.0 que cambió el puente, y el error aparece en el teléfono del usuario | El contenido declara un **rango sobre el contrato del puente** (`>=MAYOR.MENOR <MAYOR+1`). El cascarón declara el `bridgeVersion` que implementa, y el `handshake` resuelve las capacidades opcionales. Quitar `minShellVersion` o derivarlo del rango. La gramática y la forma canónica son de DevOps (solicitud S-2) |
| H-07 | P2 | E2: `E01-…/INFORME.md:46` («en .NET 10 el script es `_framework/hybridwebview.js` y la llamada viaja como request a `…/__hwvInvokeDotNet`»), `:178-180` (esas requests quedan «sin manejar», o sea las sirve el cascarón). E2: `src/Contenido/wwwroot/index.html` carga `_framework/hybridwebview.js` | El puente tiene dos mitades JS con distinto dueño: `bridge.js` viaja en el contenido, y el transporte (`hybridwebview.js` + `__hwvInvokeDotNet`) lo pone la versión de MAUI del cascarón. N2 §6.1 versiona el sobre, no el transporte | Subir MAUI en el cascarón cambia el transporte bajo un contenido ya publicado, sin ninguna señal de versión. La rotura aparece en producción y no en la compuerta | Declarar el transporte como parte del contrato del puente, a cargo del cascarón, y sumar una prueba de contrato del transporte (N4) que corra contra el cascarón nuevo con el contenido publicado |
| H-08 | P2 | E1: E02-B (§7.1) frente a E01 §6.2 y E02-R, mismo g42 | Costo medido de A frente a B. Primer render con el contenido ya instalado: **B 1,6–1,7 s** desde el proceso (2,7 s en frío); **A 3,7–4,9 s**, de los que 2,1–2,7 s son del motor WASM. Disco: APK de B 18,86 MB; A 18,49 MB más **9,13 MB por versión** de contenido plano (3,39 MB de descarga) | Si la guía calla el costo, el lector elige A sin saber que paga unos 2 s por arranque y unos 9 MB por versión retenida | Escribir el costo medido en la guía y en la matriz del analista (solicitud S-3). Dejar como mejora medible `InvariantGlobalization`, que E01 estima en ~2,6 MB menos (NO VERIFICADO) |
| H-09 | P1 | E2: `EV001:21` («cuando el usuario abre la aplicación esta aplicación **solicita bajar** las actualizaciones»). E1: E02-R corrida 1, `actualizador: instalada v1` en t=5764 ms y `hybridwebview-agregado` en t=6095 ms: el render esperó la descarga. E01 §6.2: 1,2 s de espera del manifiesto aun «al día» | El diseño de E01, y el flujo del borrador (`Framework-APP.md:113-125`), bloquea el render hasta consultar el manifiesto y, si hay versión nueva, hasta descargarla. El pedido dice que la app **pide** bajar al abrir, no que **aplique** al abrir. La lectura que menos agrega es: consultar y bajar al abrir, aplicar en el arranque siguiente. Es el comportamiento por defecto de Expo: `checkAutomatically: ON_LOAD`, `fallbackToCacheTimeout` 0 por defecto, y lo que se baja durante la espera «will be applied upon the next app launch» [D6] | Arranques de 4 a 6 s en red móvil cada vez que hay versión nueva, o una «política de espera de N s» sin piso medido | Render inmediato de lo instalado; consulta y descarga en segundo plano; activación en el arranque siguiente. Sólo bloquea cuando el contenido instalado no satisface el rango del puente (H-06) |
| H-10 | P2 | E4: `Release-Y-Despliegue-Versionado`, invariante 10 (línea 142): retención «con un número escrito (N ≥ 3)». E2: `Framework-APP.md:138` («Conservar `vN-1`») | El borrador retiene N = 2 en el teléfono (T-2). Se cumple N = 3 sin costo extra de disco si la **semilla** embebida en el APK es el mismo artefacto del release, byte a byte (pregunta 10 de N1), en lugar de una página distinta. E01 usa como semilla un `index.html` mínimo (`Resources/Raw/semilla/index.html`), que no es un release | Con N = 2 y una semilla que no es release, un defecto descubierto dos versiones después no tiene a dónde volver | current + previous + semilla = 3 artefactos de release. La semilla se produce en el mismo pipeline que el paquete OTA. **No hace falta ficha:** se cumple |
| H-11 | P1 | E2: `Framework-APP.md:291` («scripts numerados que corre el cascarón al arrancar») y `:293` («no SQL libre desde JS») | Con A, las entidades del negocio viven en el contenido, que cambia sin tienda, pero las migraciones viven en el cascarón, que cambia por tienda. Si una versión de contenido necesita una tabla nueva, o espera un release del cascarón (y se pierde el objetivo) o manda DDL por el puente (y se viola la línea 293). N2 §6.4 lo esquiva con colecciones de documentos JSON, pero no dice cómo se versiona la forma de esos documentos | El primer cambio de datos de una pantalla obliga a pasar por la tienda, o abre SQL libre desde el contenido | Dos líneas de esquema separadas. (1) Tablas del cascarón: entero monótono, `Versionado-Producto-Integral` §2.7. (2) Datos del contenido: colecciones de documentos con `schemaVersion` por documento y migración en el contenido al leer. Lo que la cláusula 2 de §2.7 dice de las migraciones al arrancar queda como señal a la presidencia (S-2) |
| H-12 | P3 | E2: `E01-…/INFORME.md:45` y `:263` («en iOS el mismo código **no** necesariamente aplica»; «el origen fijo `https://0.0.0.1` de Android no tiene por qué valer allí») | Esta duda de E01 la resuelve la fuente de MAUI: en iOS el origen es `app://0.0.0.1/` («`AppHostScheme` … `#if IOS \|\| MACCATALYST "app"`») [D8]. `app` es un esquema propio y la tabla de [D1] marca iOS con «Intercept Custom Schemes ✅». El mismo `WebResourceRequested` tendría que andar en iOS. Ejecución: **NO VERIFICADO** | La guía puede presentar como bloqueo de iOS algo que la documentación ya contesta | Reescribir C-6 de E01 en la guía como «documentado, sin ejecutar», con [D1] y [D8], y dejar el ensayo en iPhone como lo único pendiente |

## 3. Respuesta a las preguntas

### P1 — Modelo de contenido: A, B o C

| Opción | ¿Dónde cae el costo? | ¿Cuánto pesa? | ¿Qué pierde? | ¿Es reversible? |
| --- | --- | --- | --- | --- |
| **A**: Blazor WASM en `HybridWebView` | Arranque del usuario; disco del teléfono; piso de iOS; dos runtimes | +~2 s por arranque en el g42 (H-08, medido); 9,13 MB por versión retenida (medido); iOS ≥ 16.4 (H-03, documental); gama baja **sin medir** | Arranque y tamaño | Sí, mientras el puente sea la frontera: la misma lógica de canal sirve a A′ (SPA JS) o a B, cambiando sólo lo que se descarga |
| **B**: pantallas por datos, renderizadas en el cascarón | La cadencia de entrega: toda lógica nueva pasa por la tienda (`Framework-APP.md:95`) | 1,6–1,7 s de render (medido, E02-B); paquetes de KB (sin medir) | Cumple sólo en parte «aplicar actualizaciones desde el servidor» (`EV001:21`) para cambios de comportamiento | Sí, pero el esquema de pantallas que se publica queda como contrato a mantener |
| **C**: A + B | Los dos costos juntos, más dos modelos mentales para un principiante | Suma de los anteriores (sin medir) | Simplicidad, que el pedido pone como criterio (`EV001:39`) | Sí |

**Propuesta: A.** Las pantallas del cascarón (arranque, error, «actualizá») van en XAML, que es lo que trae el caso base («XAML nativo y MVVM», N1:281), y no en `BlazorWebView`: así hay una tecnología menos que enseñar. B queda como caída prevista si se mide gama baja y no alcanza. C queda como evolución, fuera de la demo. Fundamento: el pedido exige Razor y actualización sin tienda; `BlazorWebView` no es descargable [D3]; `HybridWebView` con `WebResourceRequested` sirve contenido descargado [D1] [D2] y anduvo en el g42 (E01, E02-R). El patrón de la industria es actualizar sólo la capa no nativa [D6] [D9]. Condición para revisar la elección: medir A en el teléfono de gama más baja que se quiera soportar; si el primer render con lo instalado pasa de un umbral que fije el analista, caer a B.

### P2 — Canal de actualización

| Pieza | Propuesta | Base |
| --- | --- | --- |
| Servidor | Estático (nginx o blob) con un `manifest.json` por canal | `Framework-APP.md:144`; E01 y E02-R anduvieron así |
| Momento | Consulta y descarga al abrir, en segundo plano; activación en el arranque siguiente; bloqueo sólo cuando el contenido instalado no satisface el rango del puente | H-09; [D6] |
| Staging y verificación | Descarga a `staging/`, verificación del resumen **antes** de descomprimir, extracción a `versions/vN` | Invariante 12; E01 corrida 4 (sha adulterado → rechazado) |
| Activación | `puntero.json` con `rename` atómico; directorios inmutables por versión | H-05; E02-R |
| Rollback | Marca pendiente + `Listo(version)` por el puente + rollback en el arranque siguiente + lista local de fallidas; vigilante en sesión opcional | H-04; E02-R corridas 3–5; invariante 5 («el artefacto se declara a sí mismo») |
| Retención | current + previous + semilla, que es el mismo artefacto del release (N = 3) | H-10; invariante 10 |
| Firma y canales | Fuera de mi competencia (seguridad y DevOps) | S-1 y S-2 |

Cadena de consecuencias. Bloquear el render al abrir pone el costo en cada arranque con versión nueva: +4,7 s medidos en E02-R corrida 1, en Wi-Fi y a través del túnel. No bloquear lo pone en una versión de retraso, que es reversible y es lo que hace la industria [D6]. Rollback por temporizador contra rollback por arranque: el temporizador falla en teléfonos lentos (sin medir en gama baja); el arranque cuesta una sesión rota (medido). Se toma el arranque, que es determinista, y se revisa la decisión cuando haya una medición de gama baja que permita fijar un X.

### P3 — Cascarón y puente: arquitectura y versionado del contrato

- **Cascarón:** app MAUI con servicios nativos, actualizador, servidor de contenido (`WebResourceRequested`), puente y pantallas propias en XAML. Un solo `HybridWebView` aloja el contenido.
- **Puente:** un único método `Call(sobre)` registrado con `SetInvokeJavaScriptTarget`; sobre con forma JSON-RPC 2.0 más `v`; eventos por `InvokeJavaScriptAsync("bridge.emit")`; `bridge.handshake` y `Listo(version)` al cargar. Coincido con N2 §6.1 (revisado en §4).
- **Contrato versionado:** `bridgeVersion` MAYOR.MENOR lo declara el cascarón. El contenido declara el rango que acepta (`>=2.1 <3.0`), que el actualizador evalúa **antes de descargar**, y el `handshake` resuelve lo opcional. El transporte `hybridwebview.js` forma parte del contrato y su dueño es el cascarón (H-07).
- **Cadena de consecuencias.** Un `minShellVersion` como piso pone el costo en el teléfono del usuario (H-06), y es irreversible una vez que el contenido llegó a los teléfonos. El rango sobre el puente lo pone en la compuerta del PR (DevOps), donde es barato y reversible. Se toma el rango. Fuentes: Expo ata la actualización al binario por igualdad de `runtimeVersion` [D7]; la convención exige piso y techo (`Versionado-Producto-Integral` §2.6).

### P5 — Datos locales y trabajo sin red: SQLite y migraciones como pieza técnica

- **Librería:** `sqlite-net-pcl`, que es la que usa la documentación oficial de MAUI [D10], para las tablas del cascarón (`Outbox`, `RegistroRed`, `ContenidoVersion`, `Config`) y para un almacén de documentos por colección que usa el contenido a través del puente (`db.query/save`, sin SQL libre). Coincido con N2 §6.4.
- **Migraciones:** son dos líneas (H-11). La del cascarón es un entero monótono que exige el binario (`Versionado-Producto-Integral` §2.7, cláusulas 1, 3 y 4). La del contenido es `schemaVersion` por documento, migrado al leer.
- **Tensión T-3:** en un teléfono el único actor que puede migrar la base del cascarón es el propio cascarón, y la cláusula 2 rechaza aplicar migraciones al arrancar. No la mido (**sin medir**) y no escribo ficha: la carta pide contradicción medida. Propongo un ensayo de una variable: copiar el archivo de la base y migrar en el arranque del g42, midiendo el tiempo y la vuelta atrás por la copia. Lo derivo como señal (S-2).
- **Cadena de consecuencias.** EF Core cae en la continuidad con el caso base, pero ata el modelo al cascarón (H-11) y su NativeAOT es «highly experimental» (N2 §4.9, [F35] de N2). `sqlite-net-pcl` con documentos cae en el LINQ tipado que se pierde. Las dos son reversibles mientras la base se vea sólo a través del puente. Se toma `sqlite-net-pcl`, y la decisión se revisa si EF Core 10 se mide en un iPhone real.
- **Sin red:** la semilla y lo instalado alcanzan para arrancar sin red. Que el contenido arranque sin red: **NO VERIFICADO** como corrida (E01 §8; tampoco lo corté en E02-R).

### P7 — Líneas de versión y su relación (sin gramática: es de DevOps)

| Línea | Dónde se distribuye | Relación |
| --- | --- | --- |
| Cascarón | Tienda | Implementa un `bridgeVersion` y exige un número exacto de esquema del cascarón |
| Contenido | Servidor propio | Declara un rango sobre `bridgeVersion`; su clase de artefacto no tiene fila en §2.3 (T-4, S-2) |
| Contrato del puente | Constante del cascarón | MAYOR.MENOR; el MAYOR cambia ante cualquier quiebre del sobre **o del transporte** (H-07) |
| Esquema local del cascarón | Constante del cascarón | Entero monótono (§2.7) |
| `schemaVersion` de los documentos | Contenido | Interna del contenido; no cruza el puente |

Para atribuir un error a versiones exactas, las tres primeras se muestran en una pantalla de diagnóstico del cascarón.

### P9 — iOS: dónde se compila y firma, y qué queda verificado

- **Dónde:** compilar iOS exige macOS con Xcode [D4]. La plantilla de MAUI 10 en Linux ni siquiera declara el marco iOS (E1: `E02B.csproj:5`, `Condition="!$([MSBuild]::IsOSPlatform('linux'))"`). El runner prescripto `[self-hosted, i7infra-dev]` es Linux, así que el marco iOS **no queda cubierto en el PR y se declara** (T-7). Opción: un runner macOS alojado por GitHub, gratis en repositorios públicos [D5] (los tres repos se midieron públicos, folio 003:101). Como el pedido fija un runner, ese job sería un **agregado** que sale marcado al PO.
- **Verificado por documentación:** el origen `app://0.0.0.1` es interceptable [D1] [D8] (H-12); el contenido A necesita iOS ≥ 16.4 (H-03).
- **NO VERIFICADO:** cualquier ejecución en iPhone; la política de App Review sobre `.wasm` (seguridad); el trimming de `HybridWebView` en Release iOS; el límite de memoria de WASM en WKWebView (N1 §4.7).

## 4. Lo que revisé y está bien

1. **El mecanismo de E01** (`HybridWebView` + `WebResourceRequested`, no `HybridRoot`). Lo reproduje en E02-R con otro paquete (`com.frameworkconcept.arq.e02r`) y anduvo igual: 43 o más requests servidas desde la carpeta de versión, puente operativo.
2. **El puente P2 de N2** (§6.1: un `Call(sobre)`, sobre JSON-RPC 2.0, `handshake`) es la forma que validé al sumar `Listo(version)` sin cambiar la superficie expuesta.
3. **Verificar el resumen antes de descomprimir** (E01 `Actualizador.cs:63-72`) cumple el invariante 12 de `Release-Y-Despliegue-Versionado`.

## 5. Solicitudes de convocatoria

| Id | A quién | Señal | Ubicación |
| --- | --- | --- | --- |
| S-1 | Seguridad | La lista de fallidas de E02-R es local y no está firmada: un manifiesto no firmado puede forzar descargas en bucle de versiones nuevas. Falta el estado de `.wasm` frente a App Review 2.5.2 | E02-R `Actualizador.cs` (copia local, §7.2); N1:425 |
| S-2 | DevOps y presidencia | Gramática del rango del puente y forma canónica (H-06); clase y gramática del paquete de contenido (T-4); job iOS en un runner macOS como agregado (P9); T-3, migraciones del cascarón al arrancar, para un ensayo y una posible ficha | R4:476–482 |
| S-3 | Analista | La matriz de criterios tiene que usar los costos medidos de A y B (H-08) y un umbral de primer render que haga caer A a B | §7.1 de este folio |
| S-4 | Académico | La guía tiene que separar «Blazor Hybrid» de «Blazor WebAssembly en `HybridWebView`» (H-01); el lector principiante va a encontrar el primero en la documentación de Microsoft | [D3]; folio 003:46 |

## 6. Fichas de excepción

Ninguna. T-1 (rango, H-06) y T-2 (N = 3 con la semilla, H-10) se cumplen. T-3 no tiene contradicción medida (P5).

## 7. Ensayos propios: E02-B y E02-R

Teléfono de juicio: moto g42 `<serie-del-g42>`, Android 13, WebView 155. Compilación en contenedores `lab-e2e-maui-dev:net10` (SDK 10.0.400, Maui 10.0.20). Intermedios en `~/fc-work/arq-e02r/`, fuera de `{tmp-de-sesiones}`. Las corridas de E02-R van bajo el candado `escenarios.lock`. E02-B se corrió **antes** de que llegara la regla del candado.

### 7.1 E02-B: línea base del modelo B (`BlazorWebView` compilado que renderiza un formulario desde JSON)

`dotnet new maui-blazor`, `Home.razor` arma «Encuesta de movilidad» desde un JSON embebido. Release android-arm64. APK `com.frameworkconcept.arq.e02b-Signed.apk` de 18 862 370 B, sha256 `b7691e88…c0f9`.

| Corrida | `am start` TotalTime | `primer-render B` desde el proceso |
| --- | --- | --- |
| 1 (datos limpios) | 2 364 ms | 2 719 ms |
| 2 | 1 241 ms | 1 723 ms |
| 3 | 1 072 ms | 1 615 ms |
| 4 | 1 094 ms | 1 621 ms |

Desinstalado al terminar. Logcat transcrito arriba; capturas: no se tomaron.

### 7.2 E02-R: rollback de un paquete que no avisa «arranqué»

Fuente: E01 con cuatro cambios. (1) `Actualizador`: `versions/vN`, `puntero.json` con `rename` atómico, marca pendiente, `Recuperar()` antes del WebView, lista de fallidas. (2) `PuenteNativo.Listo(version)`. (3) El contenido llama a `e01.listo` después del primer render. (4) `v3-roto` lanza una excepción en `OnInitialized`. Servidor `nginx:alpine` detrás de un túnel efímero `cloudflared`, bajado al terminar. APK sha256 `2fa29e17…24eb`.

| Corrida | Manifiesto | Resultado (logcat) | Primer render desde el proceso |
| --- | --- | --- | --- |
| 1 | v1 | `instalada v1 (antes semilla), PENDIENTE` → `puente Listo → CONFIRMADO v1` | 8 430 ms (render bloqueado por la descarga, H-09) |
| 2 | v1 | `al día (v1)` | 3 692 ms |
| 3 | v3-roto | `instalada v3-roto (antes v1), PENDIENTE`; nunca llega `Listo`; pantalla «Ocurrió un error no controlado» | — |
| 4 | v3-roto | `ROLLBACK: v3-roto no avisó 'arranqué' en el arranque anterior; vuelve a v1; fallidas=[v3-roto]` → `IGNORADA v3-roto` | 4 665 ms |
| 5 | v3-roto | `IGNORADA v3-roto: marcada fallida en este teléfono; sigue v1` | 4 871 ms |

Evidencia local en `~/fc-work/arq-e02r/evidencia/` (`SHA256SUMS.txt`): `corrida.log` `164d0bb7…4196`; `logcat-3-v3-roto.txt` `fd680cc9…d123`; `logcat-4-tras-roto.txt` `2119cda1…5216`; `captura-3-v3-roto.png` `b8884c34…cf77`; paquetes `contenido-v1.zip` `bfad3bcb…e457` y `contenido-v3-roto.zip` `0421ec40…c8e0`. Fuentes modificados en `~/fc-work/arq-e02r/src/`.

**Incidente.** El primer contenedor de compilación (`fc-arq-e02b`) fue destruido desde afuera a mitad de una compilación (`docker events`: `kill`, `die`, `destroy`; no fue una orden de este rol). Lo recreé como `fc-arq-maui-build`, con el fuente montado desde el host, y repetí la compilación. Los paquetes ya estaban copiados afuera.

**Estado final del g42.** Mis dos paquetes (`com.frameworkconcept.arq.e02b` y `…arq.e02r`) quedaron detenidos con `force-stop` y desinstalados. Quedan instalados `com.frameworkconcept.ensayo01` y `com.frameworkconcept.seguridad01`, que no son míos. No toqué otras apps ni ajustes. Contenedores, red y túnel de este rol: eliminados.

## 8. Fuentes

Todas las URL se consultaron el 2026-10-25.

| Id | Fuente |
| --- | --- |
| D1 | Microsoft Learn, *HybridWebView — .NET MAUI* (ms.date 2026-07-08): <https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/hybridwebview?view=net-maui-10.0>. §«Implementation Restrictions»: iOS «do not allow interception of `http` and `https` requests», tabla iOS «Intercept Custom Schemes ✅»; trimming: «won't be available when full trimming or Native AOT is enabled» |
| D2 | Microsoft Learn, *What's new in .NET MAUI for .NET 10*: <https://learn.microsoft.com/en-us/dotnet/maui/whats-new/dotnet-10?view=net-maui-10.0> (citada por E01) |
| D3 | Microsoft Learn, *ASP.NET Core Blazor Hybrid*: <https://learn.microsoft.com/en-us/aspnet/core/blazor/hybrid/?view=aspnetcore-10.0> (cita textual en E01 §2 y N1 §4.5) |
| D4 | Microsoft Learn, *Build an iOS app on macOS with .NET CLI* (ms.date 2024-09-30): <https://learn.microsoft.com/en-us/dotnet/maui/ios/cli?view=net-maui-10.0> |
| D5 | GitHub Docs, *GitHub Actions billing*: <https://docs.github.com/en/billing/concepts/product-billing/github-actions>: «GitHub Actions usage is free for self-hosted runners and for public repositories that use standard GitHub-hosted runners» |
| D6 | Expo, *app.json / app.config — updates*: <https://docs.expo.dev/versions/latest/config/app/>: `checkAutomatically` «`ON_LOAD` (default value)»; `fallbackToCacheTimeout` «Defaults to 0»; «any update downloaded during the check will be applied upon the next app launch» |
| D7 | Expo, *Runtime versions*: <https://docs.expo.dev/eas-update/runtime-versions/>: compatibilidad por igualdad de runtime version; políticas `appVersion` y `fingerprint` |
| D8 | Código fuente de .NET MAUI, `src/Core/src/Handlers/HybridWebView/HybridWebViewHandler.cs` (rama `main`): <https://raw.githubusercontent.com/dotnet/maui/main/src/Core/src/Handlers/HybridWebView/HybridWebViewHandler.cs>: `AppHostAddress = "0.0.0.1"`, `AppHostScheme` `"app"` en iOS y Mac Catalyst, `"https"` en el resto |
| D9 | Capgo (plugin de terceros para Capacitor), *Rollbacks*: <https://capgo.app/docs/live-updates/rollbacks/>: rollback si hay error antes de `notifyAppReady()`; `appReadyTimeout` por defecto 10 000 ms. Es documentación del proveedor, no del núcleo de Capacitor |
| D10 | Microsoft Learn, *.NET MAUI local databases* (vía N2 [F32]): `sqlite-net-pcl` |
| D11 | MDN browser-compat-data, `javascript/classes.json`: <https://raw.githubusercontent.com/mdn/browser-compat-data/main/javascript/classes.json> (sha256 de la descarga `9b9318aad64e3ba044cd7c63762d04f3d212a8103fa2e8f766ff382c40f66dad`) |

Sigue: incorporación del siguiente informe y resolución · presidencia
