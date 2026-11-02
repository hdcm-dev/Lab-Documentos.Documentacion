# Terminología formal para el «cascarón»

> Bitácora del Prompt 02 de la guía 16 (IA Layer). Fecha de consulta de todas las fuentes: **2026-11-01**.
> Se usan solo citas textuales leídas en las fuentes. Lo que dice «inferencia» es redacción propia y no cita.

## Índice

1. [Contexto](#1-contexto)
2. [Términos recomendados](#2-términos-recomendados)
3. [Definición formal propuesta](#3-definición-formal-propuesta)
4. [Términos descartados](#4-términos-descartados)
5. [Implicancias de las políticas de tiendas](#5-implicancias-de-las-políticas-de-tiendas)
6. [Pendientes de verificación](#6-pendientes-de-verificación)
7. [Bibliografía](#7-bibliografía)
8. [Verificación](#8-verificación)

---

## 1. Contexto

El PO llamó «cascarón», de forma coloquial, a un tipo de aplicación móvil .NET MAUI con tres piezas:

- **App instalada:** un contenedor nativo que se publica en las tiendas.
- **Contenido dinámico:** la UI y la lógica web (HTML/JS/WASM) se descargan del servidor.
- **Puente:** un canal JS↔nativo (versión 1.3.0; los eventos llegan por `window.puenteRecibirEvento`).

**Conclusión:** ningún término formal cubre las tres piezas a la vez. La designación formal se obtiene **combinando** un término para cada pieza.

## 2. Términos recomendados

| Pieza | Español (recomendado) | Inglés (recomendado) | Ancla principal |
|---|---|---|---|
| App instalada (concepto) | **aplicación híbrida** | **hybrid app** | Biørn-Hansen et al. 2018; Heitkötter et al. 2013 |
| App instalada (componente del contenedor) | **contenedor nativo** con **vista web embebida** | **native wrapper** / **embedded Web View** (en MAUI: `HybridWebView`) | Biørn-Hansen et al. 2018; Microsoft Learn |
| Contenido descargado | **contenido web remoto**, cargado por **carga dinámica de código**; su distribución, **actualización OTA** | **dynamic code loading**; **over-the-air (OTA) update**; para Apple, **software not embedded in the binary** | Poeplau et al. 2014; Expo; Apple 4.7 |
| Puente | **puente** (bridging) / **canal de interoperabilidad JS↔.NET** | **bridge / bridging**, **local interop channel** | Biørn-Hansen et al. 2018; Microsoft Learn |

### 2.1 Definiciones de apoyo (citas)

**Hybrid app**
- «an Hybrid app is a website presented inside a Native app through the use of a WebView component» [B1].
- «Their runtime environment largely consists of a Web rendering engine, wrapped in a native engine.» [B2]
- «Hybrid apps are packaged natively and thus can be (and have to be) installed on the device» [B2].
- *Límite:* en [B1] los archivos web «are included as part of the app bundle together with the Native app project». La definición académica supone contenido **empaquetado**, no descargado.

**Native wrapper**
- «the Hybrid approach is also referred to as Native-wrapper [101], as it wraps web assets into a publishable, deployable Native app» [B1].
- «All calls to hardware APIs are relegated to the native wrapper.» [B2]
- Apache Cordova: la app corre «in a WebView within the native application wrapper» [W1].

**HybridWebView (.NET MAUI)**
- «enables hosting arbitrary HTML/JS/CSS content in a web view, and enables communication between the code in the web view (JavaScript) and the code that hosts the web view (C#/.NET).» [M2]
- Es el ancla del mismo ecosistema del proyecto, aunque la página no trata la descarga del contenido desde un servidor.

**Embedded Web View / Blazor Hybrid**
- «Components render to an embedded Web View control through a local interop channel. Components don't run in the browser, and WebAssembly isn't involved.» [M1]
- *Límite:* en Blazor Hybrid los componentes van en el paquete y corren de forma nativa. Por eso no describe la UI descargada.

**Bridging**
- «Such communication, referred to as bridging [1], allows developers to communicate with platform-specific Native code from within a non-native environment, such as a JavaScript context.» [B1]
- «this technique of executing code between distinct programming languages is also called Foreign Function Interface (FFI)» [B1].
- Avala que el proyecto ya diga «puente».

**Dynamic code loading**
- «techniques that allow applications to load code at runtime» [B3].
- «by loading code from the Internet at runtime an attacker can circumvent the checks imposed by the Bouncer» [B3].
- *Advertencia:* en [B3] el término se refiere sobre todo a código Dalvik/DEX, no a contenido web.

**OTA / Live Updates**
- Expo actualiza «its own non-native pieces (such as JS, styling, and images) over-the-air». No cubre «Change to native code or native dependencies» [W2].
- Ionic: «The Live Updates feature only works on binary compatible changes (HTML, CSS, and JS)» [W3].
- *Nota:* «Live Updates» es nombre de producto, de proveedor. «OTA» es el término neutral.

## 3. Definición formal propuesta

> *Inferencia propia, apoyada en las citas de §2.*

**Español.** Una *aplicación híbrida con contenido web remoto* es una aplicación móvil que:

- se instala como binario nativo (*contenedor nativo*, *native wrapper*);
- aloja una vista web embebida (en .NET MAUI, `HybridWebView`);
- carga en tiempo de ejecución, desde un servidor, la capa de interfaz y lógica web (HTML, CSS, JS y, en su caso, WASM);
- distribuye esa capa por actualización OTA, separada del ciclo de publicación del binario;
- expone a esa capa capacidades de la plataforma mediante un *puente* (bridging) JS↔.NET versionado.

**Inglés.** *A hybrid app with remotely loaded web content: a natively packaged wrapper hosting an embedded web view (.NET MAUI `HybridWebView`) whose web layer is loaded at runtime from a server and updated over-the-air, communicating with native code through a versioned JS↔.NET bridge.*

**Forma corta para la documentación del proyecto:** «aplicación híbrida .NET MAUI (contenedor nativo con `HybridWebView`) con capa web remota actualizada OTA y puente JS↔nativo v1.3.0».

## 4. Términos descartados

| Término | Tipo | Motivo |
|---|---|---|
| **cascarón** | coloquial | No aparece en ninguna fuente leída. Es el término que se reemplaza. |
| **shell app** | coloquial | No encontré ninguna definición formal en las fuentes leídas. |
| **app shell / application shell** | formal, pero de otra cosa | Google lo define como «the minimal HTML, CSS, and JavaScript powering a user interface» [W4]: la cáscara es web, no nativa. Es un falso amigo de «cascarón». |
| **wrapper / webview wrapper** (suelto) | semiformal / jerga | Solo vale calificado como «native wrapper», que tiene aval académico [B1][B2]. Suelto es jerga y no nombra el contenido remoto. |
| **container app** | impreciso | Ninguna fuente leída lo define. Se prefiere «contenedor nativo» como glosa de «native wrapper». |
| **sitio empaquetado / repackaged website / web clippings** | formal, peyorativo | Apple los usa como causa de rechazo (guías 4.2 y 4.2.2) [A1]. No conviene describir la app así. |
| **Blazor Hybrid** (para este caso) | formal, impreciso | Los componentes van en el paquete y corren de forma nativa, «WebAssembly isn't involved» [M1]. No es el modelo de UI descargada. |
| **server-driven UI** | formal, impreciso | No verificado: la fuente devolvió 403. Además, ese patrón descarga una descripción de la UI, no código. |
| **Live Updates** | marca de proveedor | Es el nombre de una función de Ionic. Se usa «OTA» como término neutral. |

## 5. Implicancias de las políticas de tiendas

### Apple: App Store Review Guidelines [A1]

**2.5.2 (prohibición).** «Apps should be self-contained in their bundles [...] nor may they download, install, or execute code which introduces or changes features or functionality of the app».
Si lo descargado cambia la funcionalidad de la app, entra en conflicto con esta regla.

**4.7 (vía permitida).** «Apps may offer certain software that is not embedded in the binary, specifically HTML5 and JavaScript mini apps and mini games, streaming games, chatbots, and plug-ins. [...] You are responsible for all such software offered in your app».
Es la categoría formal de Apple para el contenido HTML/JS remoto.

**4.7.2.** «Your app may not extend or expose native platform APIs or technologies to the software without prior permission from Apple.» Esto **afecta directamente al puente**.

**4.2 / 4.2.2.** «Your app should include features, content, and UI that elevate it beyond a repackaged website.»
El contenedor tiene que aportar valor nativo propio.

### Google Play: Device and Network Abuse [G1]

- «an app may not download executable code (such as dex, JAR, .so files) from a source other than Google Play».
- La restricción no alcanza al código interpretado «(such as JavaScript in a webview or browser)».
- Figura como infracción «a webview with added JavaScript Interface that loads untrusted web content».

**Implicancia:** el JS descargado está permitido. Un puente expuesto a contenido no confiable es una infracción. Por eso el contenido remoto tiene que venir **solo de un origen confiable y controlado** (dominio propio, TLS, lista de orígenes permitidos en el puente).

> Texto re-verificado en la página el 2026-11-01 (ver §8).

### Síntesis

| Tienda | Vía permitida | Límite |
|---|---|---|
| Apple | 4.7 | 2.5.2 y 4.7.2 |
| Google | JS interpretado en WebView | puente expuesto a contenido no confiable |

En las dos tiendas, todo cambio de código **nativo** obliga a publicar un binario nuevo; coincide con [W2] y [W3].

## 6. Pendientes de verificación

- Páginas de Apple `WKWebView` y de Google Trusted Web Activity, que no leí.
- Fuentes no consultadas: ISO/IEC/IEEE 24765, «hosted web app», «thin client», CodePush, Capacitor Live Updates (la última devolvió 404).

## 7. Bibliografía

Todas las fuentes se consultaron el 2026-11-01.

**Académicas**

- **[B1]** Biørn-Hansen, A.; Grønli, T.-M.; Ghinea, G. «A Survey and Taxonomy of Core Concepts and Research Challenges in Cross-Platform Mobile Development». *ACM Computing Surveys* 51(5), 2018. DOI 10.1145/3241739. https://bura.brunel.ac.uk/bitstream/2438/16569/1/Fulltext.pdf
- **[B2]** Heitkötter, H.; Hanschke, S.; Majchrzak, T. A. «Evaluating Cross-Platform Development Approaches for Mobile Applications». LNBIP 140, Springer, 2013, págs. 120–138. DOI 10.1007/978-3-642-36608-6_8. Copia leída: https://users.cs.fiu.edu/~cpoellab/teaching/cse40814_fall14/crossplatform.pdf
- **[B3]** Poeplau, S.; Fratantonio, Y.; Bianchi, A.; Kruegel, C.; Vigna, G. «Execute This! Analyzing Unsafe and Malicious Dynamic Code Loading in Android Applications». NDSS 2014. https://www.ndss-symposium.org/wp-content/uploads/2017/09/10_5_0.pdf

**Microsoft**

- **[M1]** Microsoft Learn. «ASP.NET Core Blazor Hybrid». https://learn.microsoft.com/en-us/aspnet/core/blazor/hybrid/
- **[M2]** Microsoft Learn. «HybridWebView - .NET MAUI» (ms.date 2026-07-08). https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/hybridwebview

**Tiendas**

- **[A1]** Apple. «App Store Review Guidelines» (2.5.2, 4.2, 4.2.2, 4.7, 4.7.2). https://developer.apple.com/app-store/review/guidelines/
- **[G1]** Google. «Device and Network Abuse», Google Play policy. https://support.google.com/googleplay/android-developer/answer/9888379

**Documentación de frameworks y proveedores**

- **[W1]** Apache Cordova. «Overview». https://cordova.apache.org/docs/en/latest/guide/overview/
- **[W2]** Expo. «EAS Update introduction». https://docs.expo.dev/eas-update/introduction/
- **[W3]** Ionic. «Deploy / Live Updates». https://ionic.io/docs/appflow/deploy/intro
- **[W4]** Chrome for Developers. «Instant Loading Web Apps with an Application Shell Architecture». https://developer.chrome.com/blog/app-shell

## 8. Verificación

Revisión adversarial del 2026-11-01: se reabrió cada URL y se buscó cada cita textual (los PDF, extrayendo el texto con `pdftotext`).

| Fuente | Estado | Resultado |
|---|---|---|
| [B1] Biørn-Hansen et al. 2018 (PDF Brunel) | Confirmada | Las cinco citas están literalmente: «Hybrid app is a website presented inside a Native app…», «included as part of the app bundle together with the Native app project», «Native-wrapper [101]», «referred to as bridging [1]», «Foreign Function Interface (FFI)». |
| [B2] Heitkötter et al. 2013 (copia FIU) | Confirmada | Las tres citas están literalmente. Es una copia de curso, no la editorial: citar por el DOI. |
| [B3] Poeplau et al. NDSS 2014 | Confirmada | Las dos citas están literalmente. |
| [M1] Blazor Hybrid | Confirmada | Cita literal. ms.date 2025-11-11. |
| [M2] HybridWebView | Confirmada | Cita literal; ms.date 2026-07-08 correcto. |
| [A1] Apple 2.5.2, 4.2, 4.7, 4.7.2 | Confirmada | Citas literales; se sumó el texto de 4.7.2, que faltaba. La cita de 4.2.2 no se transcribe; solo se menciona. |
| [G1] Google Play | Confirmada | Las tres citas están literalmente; queda resuelta la advertencia anterior. |
| [W1] Cordova | Confirmada | «The app executes in a WebView within the native application wrapper…». |
| [W2] Expo | Confirmada | «Change to native code or native dependencies» es una fila de tabla, no una oración. |
| [W3] Ionic | Confirmada | Cita literal. |
| [W4] Chrome app shell | Confirmada | «An application shell is the minimal HTML, CSS, and JavaScript powering a user interface.» |

**Fuentes caídas:** ninguna de las citadas. Siguen sin leer las que figuran como no consultadas en §6 (server-driven UI, que dio 403, y Capacitor Live Updates, que dio 404); no se citan.

**Inventadas o mal atribuidas:** no se encontró ninguna. La conclusión de §1 y la definición de §3 son inferencia propia y así están marcadas.
