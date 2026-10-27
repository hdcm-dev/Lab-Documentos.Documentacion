# E01 — Blazor WebAssembly descargado, servido en el WebView de un cascarón .NET 10 MAUI

> Ensayo pericial de la mesa del expediente 0001 (Framework-Concept). Riesgo que resuelve: D-01 del borrador
> `/LAB/Lab-Documentos/Lab-Documentos/Concepts/Framework-Concept/Framework-APP.md` (§2 y §12).
> Fecha de ejecución y de consulta de todas las URL: **2026-10-25**. Perito: subagente de ensayo del workflow 1.
> Convención: **[Dn]** documentación oficial (§9.1), **[Cn]** comando o archivo de evidencia (§9.2).
> Lo que es opinión del perito dice **Criterio propio**. Lo que no se pudo comprobar dice **NO VERIFICADO**.

## Índice

1. [Hipótesis y resultado en una línea](#1-hipótesis-y-resultado-en-una-línea)
2. [Qué ofrece .NET 10 MAUI según la documentación oficial](#2-qué-ofrece-net-10-maui-según-la-documentación-oficial)
3. [Diseño del ensayo](#3-diseño-del-ensayo)
4. [Entorno exacto](#4-entorno-exacto)
5. [Procedimiento reproducible](#5-procedimiento-reproducible)
6. [Resultados](#6-resultados)
7. [Conclusión sobre D-01](#7-conclusión-sobre-d-01)
8. [Lo que queda sin verificar](#8-lo-que-queda-sin-verificar)
9. [Fuentes y evidencia](#9-fuentes-y-evidencia)
10. [Incidentes de la corrida](#10-incidentes-de-la-corrida)

---

## 1. Hipótesis y resultado en una línea

**Hipótesis H1.** Un cascarón .NET 10 MAUI en Android puede cargar en su WebView un paquete Blazor WebAssembly que
**no** viene en el APK sino que se descargó a `FileSystem.AppDataDirectory/content/current/`, servirlo localmente, y la
página puede llamar a un servicio nativo (`device.info`) por un puente JS↔C#. Al publicar una versión nueva, el
próximo arranque la toma.

**Resultado.** H1 **se cumple en el teléfono de juicio (moto g42, Android 13, WebView 155)**: descarga, verificación
sha256, activación, arranque de Blazor WASM, puente y cambio v1→v2 funcionan sin un solo error de consola [C6][C7].
**No** se cumple en el emulador API 30 con WebView 83: todo el circuito nativo anda, pero el runtime JS de Blazor
para .NET 10 usa sintaxis que ese WebView no entiende [C5][D5]. Mecanismo que funcionó: `HybridWebView` +
evento `WebResourceRequested` (.NET 10); **no** `HybridRoot`, que sólo apunta a recursos empaquetados [D1].

---

## 2. Qué ofrece .NET 10 MAUI según la documentación oficial

| Pieza | Qué dice la documentación | Fuente | Consecuencia para el ensayo |
| --- | --- | --- | --- |
| `HybridWebView.HybridRoot` | «the path within the app's raw asset resources that contain the web app's contents. The default value is *wwwroot*, which maps to *Resources/Raw/wwwroot*» | [D1] | **No** sirve una carpeta arbitraria del disco: sólo assets empaquetados en el APK. Se usa sólo para una página semilla |
| `WebResourceRequested` (nuevo en .NET 10) | «You can now intercept and respond to web requests made from `BlazorWebView` and `HybridWebView` … supplying local responses»; se responde con `e.Handled = true` y `e.SetResponse(status, desc, contentType, stream)`; el manejador «MUST be synchronous» | [D2], [D1] §Intercept web requests | Es la API que permite servir `content/current/` desde el disco |
| Restricciones por plataforma | Android: intercepta HTTPS ✅, esquemas propios ❌, «does not directly allow intercept-and-continue». iOS/Mac Catalyst: «do not allow interception of `http` and `https` requests»; sí esquemas propios | [D1] tabla «Implementation Restrictions» | En Android sirve; en iOS el mismo código **no** necesariamente aplica (ver §8) |
| Puente JS→C# | `window.HybridWebView.InvokeDotNet('Metodo', [args])` sobre el objeto fijado con `SetInvokeJavaScriptTarget`; en .NET 10 el script es `_framework/hybridwebview.js` y la llamada viaja como request a `${window.location.origin}/__hwvInvokeDotNet` | [D1] | El paquete descargado debe incluir `<script src="_framework/hybridwebview.js">`; el interceptor **no** debe atrapar `__hwv*` ni ese script |
| Trimming | «By default, the `HybridWebView` control won't be available when full trimming or Native AOT is enabled» (.NET 9/10) | [D1] | Con el `Release` por defecto de la plantilla anduvo (§6); trimming completo **NO VERIFICADO** |
| `BlazorWebView` (Blazor Hybrid) | «Razor components run natively on the device … Components don't run in the browser, and WebAssembly isn't involved» | [D3] | Confirma el §2 del borrador: los componentes de Blazor Hybrid se compilan en la DLL del APK; no son descargables. Por eso el contenido es Blazor **WASM** dentro de `HybridWebView` |
| Origen de la página | En las corridas, las requests llegan como `https://0.0.0.1/...` | [C6] | El origen es fijo: el contenido debe usar `<base href="/" />` |

---

## 3. Diseño del ensayo

```mermaid
sequenceDiagram
    participant S as Servidor estático (nginx en contenedor)
    participant C as Cascarón MAUI (C#)
    participant D as AppDataDirectory/content
    participant W as HybridWebView (Chromium)
    participant P as Página Blazor WASM
    C->>S: GET manifest.json
    S-->>C: {version, archivo, sha256, tamano}
    alt versión distinta de la instalada
        C->>S: GET contenido-vN.zip
        C->>D: staging/vN.zip → sha256 → descomprimir staging/vN
        C->>D: current → previous ; staging/vN → current
    end
    C->>W: crear HybridWebView (HybridRoot = semilla)
    W->>C: WebResourceRequested https://0.0.0.1/...
    C-->>W: SetResponse(stream de content/current/...)
    W->>P: arranca Blazor WASM (dotnet.native.wasm)
    P->>C: InvokeDotNet('DeviceInfo') vía __hwvInvokeDotNet
    C-->>P: {"fabricante":"motorola","modelo":"moto g42",...}
```

| Pieza | Archivo | Qué hace |
| --- | --- | --- |
| Contenido | `src/Contenido/` (`dotnet new blazorwasm --empty`) | `Home.razor` muestra «Contenido vN» (versión inyectada al publicar con `-p:ContenidoVersion=vN`) y llama al puente al primer render y con el botón `device.info` |
| Envoltorio del puente | `src/Contenido/wwwroot/bridge.js` | `e01.deviceInfo()` → `HybridWebView.InvokeDotNet('DeviceInfo')`; `e01.marca()` deja marcas de tiempo en consola y en logcat |
| Cascarón | `src/Cascaron/` (`dotnet new maui`, sólo `net10.0-android`, `ApplicationId=com.frameworkconcept.ensayo01`) | `MainPage` corre el actualizador **antes** de crear el `HybridWebView` |
| Actualizador | `src/Cascaron/E01/Actualizador.cs` | Manifiesto → zip a `staging/` → sha256 → descomprime → `current`→`previous`, `staging/vN`→`current` (renombres de directorio) |
| Servidor de contenido | `src/Cascaron/E01/ServidorDeContenido.cs` | Manejador de `WebResourceRequested`: si el archivo existe en `content/current/` lo devuelve con su tipo MIME; si no (o si es `__hwv*`), deja pasar al comportamiento por defecto. Controla que la ruta no salga de `current/` |
| Puente nativo | `src/Cascaron/E01/PuenteNativo.cs` | `DeviceInfo()` con `Microsoft.Maui.Devices.DeviceInfo`; `Marca()` registra tiempos |
| Semilla | `src/Cascaron/Resources/Raw/semilla/index.html` | Página mínima embebida, para cuando no hay nada descargado |
| Empaquetador | `src/tools/empaquetar.sh` | `dotnet publish` → zip **sin** los `.br/.gz` precomprimidos → sha256 → `manifest.json` |
| Corrida | `src/tools/correr-ensayo.sh emu|g42`, `src/tools/pruebas-extra-g42.sh` | 3 arranques (limpio con v1, relanzar, publicar v2) + sha adulterado + toque real |

Fuera de alcance de E01 (lo cubre el diseño de N1): firma del paquete, rollback automático por «arranqué bien»,
política de espera de red, `minShellVersion`.

---

## 4. Entorno exacto

| Elemento | Valor | Evidencia |
| --- | --- | --- |
| Host | i7infra (i7-3770K), Linux 6.12.111+deb13; sin dotnet en el host | — |
| Imagen de compilación | `lab-e2e-maui-dev:net10` (`sha256:9cd6103e…1797`, creada 2026-09-13) | [C1] |
| SDK | .NET SDK 10.0.400; workload `maui-android` 10.0.20/10.0.100; **sin** `wasm-tools` | [C1] |
| Paquetes | `Microsoft.Maui.Controls` 10.0.20; `Microsoft.AspNetCore.Components.WebAssembly` 10.0.11 | [C1] |
| Emulador | contenedor propio `fc-android-emu` desde `android-emu-<privado>:local`, emulator 32.1.15 (build 10696886), AVD `fcensayo30` Android 11 / API 30, x86_64, SDK montado de sólo lectura | [C1] |
| WebView del emulador | `com.google.android.webview` **83.0.4103.106** | [C4] |
| Teléfono de juicio | moto g42 (`<serie-del-g42>`), Android 13 / API 33, arm64-v8a, WebView **155.0.8059.43**; por adb remoto `-H 203.0.113.30 -P 5037` | [C3], R2 |
| Servidor de contenido | `nginx:alpine` (`fc-e01-srv`, puerto 8099). Emulador: `http://172.17.0.1:8099`. g42: túnel efímero `cloudflared` (quick tunnel `trycloudflare.com`), porque el g42 está en otra red (§10) | [C2] |

---

## 5. Procedimiento reproducible

Todo corre en contenedores. `$E` es la carpeta de este ensayo.

```bash
# 0) Contenedor de compilación con el ensayo montado
docker run -d --name fc-e01-build -v $E:/work -w /work --entrypoint sleep lab-e2e-maui-dev:net10 infinity

# 1) Contenido v1 y v2 (publica, zip sin .br/.gz, sha256, manifest-vN.json)
docker exec fc-e01-build bash -lc 'for v in v1 v2; do bash /work/src/tools/empaquetar.sh $v; \
  cp /work/evidencia/local/servidor/manifest.json /work/evidencia/local/servidor/manifest-$v.json; done'

# 2) Servidor estático
docker run -d --name fc-e01-srv -p 8099:80 -v $E/evidencia/local/servidor:/usr/share/nginx/html:ro nginx:alpine

# 3) Cascarón: x64 para el emulador, arm64 para el g42 (la URL del servidor va por propiedad MSBuild)
docker exec fc-e01-build bash -lc 'cd /work/src/Cascaron && dotnet build -c Release -f net10.0-android \
  -p:RuntimeIdentifier=android-x64 -p:AndroidPackageFormat=apk -p:ServidorContenido=http://172.17.0.1:8099'
docker exec fc-e01-build bash -lc 'cd /work/src/Cascaron && dotnet build -c Release -f net10.0-android \
  -p:RuntimeIdentifier=android-arm64 -p:AndroidPackageFormat=apk -p:ServidorContenido=<URL alcanzable por el g42>'

# 4) Emulador propio (el gid 993 es el grupo kvm del host; sin él: «doesn't have permissions to use KVM»)
docker run -d --name fc-android-emu --device /dev/kvm --group-add 993 -e EMU_API=30 -e EMU_AVD=fcensayo30 \
  -e EMU_RAM_MB=3072 -e EMU_BUILD=10696886 -e EMU_SDK=/opt/emu-sdk -e VNC_PASSWORD=<8 caracteres> \
  -v fc-android-emu-home:/home/dev/.android -v android-emu-<privado>-sdk:/opt/emu-sdk:ro \
  -v $E:/work android-emu-<privado>:local

# 5) Corridas (install, pm clear SÓLO del paquete del ensayo, 3 arranques, logcat y capturas)
bash $E/src/tools/correr-ensayo.sh emu
bash $E/src/tools/correr-ensayo.sh g42
bash $E/src/tools/pruebas-extra-g42.sh
```

Cada arranque hace `am force-stop` + `logcat -c` + `am start -W`, espera 30–45 s, guarda `evidencia/logcat-<disp>-<n>.txt`
y una captura `adb exec-out screencap -p` en `evidencia/local/`.

---

## 6. Resultados

### 6.1 Tamaño del paquete de contenido

Publicación `Release` **sin** `wasm-tools` (el SDK avisa «Publishing without optimizations… we strongly recommend
using `wasm-tools`») [C2].

| Medida | Bytes | MB (10⁶) |
| --- | --- | --- |
| Paquete sin comprimir (46 archivos, sin `.br/.gz`) | 9 125 729 | 9,13 |
| Zip descargado (v1 / v2) | 3 394 811 / 3 394 807 | 3,39 |
| Sólo los `.br` que genera el publish (45 archivos), como referencia | 2 735 736 | 2,74 |
| `wwwroot` completo tal como lo deja el publish (con `.br` y `.gz`) | 15 375 370 | 15,38 |

Los seis más pesados: `dotnet.native.wasm` 3,00 MB; `System.Private.CoreLib.wasm` 1,60 MB; tres `icudt_*.dat`
1,11 + 0,96 + 0,55 MB; `System.Text.Json.wasm` 0,37 MB [C1]. **Criterio propio:** la globalización invariante
(`InvariantGlobalization`) eliminaría ~2,6 MB de ICU sin comprimir; queda para medir.

APK del cascarón: x64 18 607 649 B; arm64 18 492 132 B [C1].

### 6.2 Teléfono de juicio: moto g42

| Corrida | Qué pasa | `am start` TotalTime | Descarga (zip 3,39 MB) | Descomprimir | Proceso → primer render Blazor | `perf.now` del WebView al primer render | Puente |
| --- | --- | --- | --- | --- | --- | --- | --- |
| 1 — datos limpios, manifiesto v1 | «instalada v1 (antes ninguna)» | 1 686 ms | 1 262 ms | 392 ms | **6 277 ms** | 2 216 ms | ✅ |
| 2 — relanzar con v1 | «al día (v1)», sin descarga | 973 ms | — | — | **4 366 ms** | 2 241 ms | ✅ |
| 3 — publicar v2 y relanzar | «instalada v2 (antes v1)», pantalla «Contenido v2» | 954 ms | 1 198 ms | 256 ms | **5 116 ms** | 2 067 ms | ✅ |
| 4 — manifiesto con sha256 adulterado | «RECHAZADO: sha256 no coincide», sigue v2 | 943 ms | 1 591 ms | — | 5 901 ms | 1 998 ms | ✅ |
| 5 — toque real en el botón | segunda llamada al puente | — | — | — | — | — | ✅ |

`t` se mide desde el arranque del proceso (`SystemClock.ElapsedRealtime − Process.StartElapsedRealtime`).
En todas las corridas: **43** requests servidas desde `content/current/` y 5 sin manejar (las esperadas:
`_framework/hybridwebview.js`, `favicon.ico` y tres `POST __hwvInvokeDotNet` del puente); **cero** líneas
`Uncaught` o `FATAL` [C6].

Extracto de la corrida 3 (`evidencia/logcat-g42-3-v2-publicada.txt`):

```text
I/E01 (17819): t=675ms manifiesto: GET https://regulation-ideal-california-protocols.trycloudflare.com/manifest.json
I/E01 (17819): t=2565ms descarga contenido-v2.zip 3394807 bytes en 1198 ms, sha256=b7fb650c6b9fd81901c01a71daa59acb76609386c5959ed8c9bf01fdbee253a3
I/E01 (17819): t=2826ms activada v2 (antes v1); descomprimir 256 ms
I/E01 (17819): t=3063ms hybridwebview-agregado
I/E01 (17819): t=3363ms js-marca 'index-html-cargado' perf.now=226ms
I/E01 (17819): t=5116ms js-marca 'primer-render v2' perf.now=2067ms
I/E01 (17819): t=5181ms puente DeviceInfo → {"modulo":"device.info","fabricante":"motorola","modelo":"moto g42","plataforma":"Android","version":"13","contenido":"v2"}
```

Extracto de la corrida 4 (sha adulterado):

```text
I/E01 (18120): t=3684ms actualizador: RECHAZADO: sha256 no coincide (esperado 0000…0000, obtenido b7828d72…4416)
I/E01 (18120): t=5901ms js-marca 'primer-render v2' perf.now=1998ms
```

Lectura de las cifras (**criterio propio**): con el contenido ya instalado, el costo de Blazor WASM dentro del WebView
es ~2,0–2,2 s desde que el WebView empieza a navegar hasta el primer render, en un equipo de gama media de 2022. El resto
del arranque es el cascarón (~0,7 s hasta `OnAppearing`) y la **espera del manifiesto** (1,2 s en la corrida 2 sólo
por ir a buscarlo a través del túnel). En el diseño final el manifiesto no debería bloquear el render del contenido
ya instalado (política de espera del §3 del borrador).

### 6.3 Emulador API 30 (WebView 83)

| Paso | Resultado | Evidencia |
| --- | --- | --- |
| Descarga, sha256, activación v1 y luego v2 | ✅ «descarga contenido-v2.zip 3394807 bytes en 3409 ms», «activada v2 (antes v1); descomprimir 378 ms» | [C5] |
| Intercepción `WebResourceRequested` sirviendo `content/current/` | ✅ `index.html`, `css/app.css`, `bridge.js`, `blazor.webassembly.js` salen de `content/current/` | [C5] |
| Puente JS→C# | ✅ `js-marca 'index-html-cargado'` llega a C# por `InvokeDotNet` | [C5] |
| Arranque de Blazor WASM | ❌ `Uncaught SyntaxError: Unexpected token '{'` en `blazor.webassembly.w3qd1tpl0e.js`; la pantalla queda en «Loading» | [C5], captura `captura-emu-3-v2-publicada.png` |

Causa: el archivo contiene un bloque de inicialización estático de clase (`class T{static{this.nextEventDelegatorId=0}…`,
byte 15 424) [C5]; esa sintaxis la soportan Chrome/WebView **desde la versión 94** según los datos de compatibilidad de
MDN [D5]. El WebView 83 del emulador no la parsea. No es un fallo del mecanismo de descarga ni del interceptor.

**Consecuencia de diseño:** el cascarón tiene que exigir una versión mínima de WebView (≥ 94 medida acá; el valor real
que exige .NET 10 en conjunto **NO VERIFICADO**: puede haber otra sintaxis más nueva más adelante en los archivos) y, si
no la cumple, mostrar la pantalla propia «actualizá Android System WebView» en vez del contenido. El emulador de banco
del laboratorio (API 30, imagen sin Play) no sirve como dispositivo de prueba E2E para el contenido WASM.

### 6.4 Alternativas probadas y descartadas

| Intento | Resultado |
| --- | --- |
| 1. `HybridRoot` apuntando a la carpeta descargada | Descartado por documentación sin probarlo: la propiedad es una ruta dentro de los raw assets [D1] |
| 2. `HybridWebView` + `WebResourceRequested` sirviendo `AppDataDirectory/content/current` | **Funciona** en el g42 (§6.2). No hizo falta un servidor HTTP en loopback |
| 3. Servidor HTTP en loopback dentro de la app | No se probó: el intento 2 ya resolvió. **Criterio propio:** suma un puerto abierto en el teléfono y un ciclo de vida que administrar, sin beneficio frente al 2 en Android |

---

## 7. Conclusión sobre D-01

**Opción A (Blazor WASM descargado y servido localmente en el WebView): VIABLE CON CONDICIONES en Android.**

| Condición | Por qué | Origen |
| --- | --- | --- |
| C-1. Usar `HybridWebView` + `WebResourceRequested` (.NET 10), no `HybridRoot` | `HybridRoot` sólo ve assets del APK | [D1], §6.4 |
| C-2. El paquete incluye `_framework/hybridwebview.js` y `<base href="/">`; el interceptor no atrapa `__hwv*` | El puente viaja como request al mismo origen | [D1], [C6] |
| C-3. Versión mínima de Android System WebView (≥ 94 medido) con pantalla propia de «actualizá el WebView» | WebView 83 no arranca el runtime de Blazor .NET 10 | §6.3, [D5] |
| C-4. Servir archivos planos (sin `.br/.gz`) o agregar manejo de `Content-Encoding` | El interceptor responde el archivo tal cual; se empaquetó sólo lo plano y anduvo | §6.1 |
| C-5. Firma del paquete, rollback y política de espera de red (no ensayados acá) | El sha256 del manifiesto sólo detecta corrupción si el manifiesto es confiable; la corrida 4 muestra que el rechazo deja la versión anterior | Borrador §3, [C7] |
| C-6. iOS se decide aparte | En iOS no se pueden interceptar `http/https`, sólo esquemas propios; no se pudo probar | [D1], §8 |

Cifras que respaldan la viabilidad en el teléfono de juicio: paquete 3,39 MB comprimido / 9,13 MB plano; descarga
~1,2–1,6 s; descompresión 0,26–0,39 s; primer render a ~2,1 s del inicio del WebView y a 4,4–6,3 s del inicio del
proceso; cambio de versión tomado en el arranque siguiente sin reinstalar.

**Alternativa si A no conviniera** (**criterio propio**): la opción B del borrador (interfaz dirigida por datos con un
renderizador Razor compilado en el cascarón y `BlazorWebView`) evita el segundo runtime, los ~9 MB y la dependencia de
la versión del WebView; a cambio, toda lógica nueva exige release por tienda. El ensayo no encontró un bloqueo que
obligue a caer a B en Android.

---

## 8. Lo que queda sin verificar

| Tema | Estado | Motivo |
| --- | --- | --- |
| iOS (WKWebView, interceptación por esquema propio, App Store 2.5.2) | **NO VERIFICADO** | No hay Mac ni runner macOS en el laboratorio. La doc dice que iOS sólo intercepta esquemas propios [D1]; el origen fijo `https://0.0.0.1` de Android no tiene por qué valer allí |
| Publicación con `wasm-tools` (AOT/relink) y su efecto en tamaño y arranque | **NO VERIFICADO** | Se probó primero sin el workload, como pedía el despacho, y funcionó; no hubo tiempo de medir la variante |
| `InvariantGlobalization` / quitar ICU | **NO VERIFICADO** | Ahorro estimado ~2,6 MB plano, no medido |
| Estado de `content/current` y `previous` en disco | Verificado **indirectamente** (log del actualizador y etiqueta en pantalla). La lectura directa con `run-as` falló: «package not debuggable» (APK Release) | [C6] |
| Arranque del contenido sin red (paquete ya instalado) | **NO VERIFICADO** como corrida propia; el código usa lo instalado si el manifiesto falla, pero no se cortó la red | — |
| Versión mínima exacta de WebView para todo el runtime de Blazor .NET 10 | **NO VERIFICADO**: 94 es la cota que impone el primer error encontrado | §6.3 |
| Gama baja real | **NO VERIFICADO**: el único teléfono disponible es el g42 (gama media) | — |
| Trimming completo / Native AOT con `HybridWebView` | **NO VERIFICADO** | La doc advierte que por defecto no está disponible [D1] |

---

## 9. Fuentes y evidencia

### 9.1 Documentación oficial (consultada el 2026-10-25)

| Id | Fuente |
| --- | --- |
| D1 | HybridWebView — .NET MAUI: <https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/hybridwebview?view=net-maui-10.0> (ms.date 2026-07-08) |
| D2 | What's new in .NET MAUI for .NET 10, §HybridWebView e «Intercept Web Requests»: <https://learn.microsoft.com/en-us/dotnet/maui/whats-new/dotnet-10?view=net-maui-10.0> |
| D3 | ASP.NET Core Blazor Hybrid: <https://learn.microsoft.com/en-us/aspnet/core/blazor/hybrid/?view=aspnetcore-10.0> |
| D4 | Static initialization blocks — MDN: <https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Classes/Static_initialization_blocks> |
| D5 | Datos de compatibilidad de MDN, `javascript.classes.static.initialization_blocks`: chrome `version_added: "94"`, `chrome_android` y `webview_android`: `mirror`: <https://raw.githubusercontent.com/mdn/browser-compat-data/main/javascript/classes.json> |

### 9.2 Evidencia del ensayo (rutas relativas a esta carpeta)

| Id | Archivo | Contenido |
| --- | --- | --- |
| C1 | `evidencia/entorno-y-hashes.txt` | Versiones (SDK, workloads, paquetes, emulador), sha256 y tamaños de APK, zips y capturas, cinco archivos más pesados |
| C2 | `evidencia/empaquetar-v1.log`, `evidencia/empaquetar-v2.log` | Salida del publish y del empaquetado |
| C3 | `evidencia/local/g42-red.txt`, `evidencia/local/alcance.txt` | Red del g42 y pruebas de alcance (§10) |
| C4 | `evidencia/webview-emu.txt` | `dumpsys webviewupdate` del emulador |
| C5 | `evidencia/corrida-emu.log`, `evidencia/logcat-emu-*.txt` | Corridas en el emulador |
| C6 | `evidencia/corrida-g42.log`, `evidencia/logcat-g42-{1,2,3}-*.txt` | Corridas en el g42 |
| C7 | `evidencia/corrida-g42-extra.log`, `evidencia/logcat-g42-{4,5}-*.txt` | sha adulterado y toque real |

Piezas crudas en `evidencia/local/` (no versionables):

| Pieza | sha256 | Bytes |
| --- | --- | --- |
| `apk/ensayo01-android-x64-Signed.apk` | `3a7d2e351b585d1ddb013655d170039a4f1412a536de4689b284c08b0baf6628` | 18 607 649 |
| `apk/ensayo01-android-arm64-Signed.apk` | `eb6250e06de4585b76edab2c7858cc4c64cc2a47a278d262369993848b264f9c` | 18 492 132 |
| `servidor/contenido-v1.zip` | `b7828d721900ad3a689cfff5e6b22a89f4b52f934290c3cc4bd982939cfa4416` | 3 394 811 |
| `servidor/contenido-v2.zip` | `b7fb650c6b9fd81901c01a71daa59acb76609386c5959ed8c9bf01fdbee253a3` | 3 394 807 |
| `captura-g42-1-v1-limpio.png` | `5dd7eb22c19fefd5a137fcc596944f41c8f889a316c6c2cff56fd626322acd55` | 124 040 |
| `captura-g42-2-v1-relanzar.png` | `ebfdc9fb5eedfee444515101b86f878f85929408424ae6c2c6565c72853f7425` | 117 812 |
| `captura-g42-3-v2-publicada.png` (muestra «Contenido v2» y la respuesta del puente) | `8c784a3d89e949c6568a16dfc4217f3b8f7dc58a2775c5ced7b5f8505835d648` | 121 345 |
| `captura-g42-4-sha-adulterado.png` | `9a407790167b67d9fc0b95e72a9a4ddd8ba1f650059b3ff64ef093e0966f78f3` | 173 845 |
| `captura-emu-1-v1-limpio.png` (queda en «Loading») | `c11aed22525b336a33b2d366dd5cff67dd90c86c791b76aa83ef367b0c2d367c` | 23 549 |
| `captura-emu-2-v1-relanzar.png` | `fba43ec72ce50591c9d7508aee238002c740603621f36db0ec2b525ad24a734c` | 23 570 |
| `captura-emu-3-v2-publicada.png` | `9f9bd4b23ffad525730bbfaeb7508eb6f0227dc8bac1bbb81b4adf1ad51182cf` | 24 072 |
| `salida/contenido-v{1,2}/` | publicación completa de cada versión | — |

---

## 10. Incidentes de la corrida

| Incidente | Qué pasó | Cómo se resolvió |
| --- | --- | --- |
| /vm sin inodos | /vm llegó al 100 % de inodos (691 200/691 200, 531 GB libres) por scratchpads de otras sesiones; la herramienta de comandos no podía crear su archivo de salida | Avisado a la presidencia; se siguió por otra vía hasta que liberaron (518 mil libres al cierre). El ensayo nunca escribió en /vm |
| KVM en el emulador | Primer `fc-android-emu` sin permiso sobre `/dev/kvm` | Se recreó con `--group-add 993` (mismo valor que `android-emu-banco`); booteó en 74 s |
| Red del g42 | El g42 está en 192.0.2.0/24; desde él no responden 198.51.100.9 ni 203.0.113.10 (ping 100 % perdido), sí Internet (1.1.1.1) [C3] | Túnel efímero `cloudflared` hacia el nginx del ensayo; se bajó al terminar. **Criterio propio:** expone el contenido del ensayo (sin secretos) durante ~10 min |
| Toque en el botón | Las coordenadas del primer `input tap` no caían sobre el botón (la etiqueta de rechazo era más larga) | Una variable: se ubicó el botón con `uiautomator dump` (bounds `[27,1518][364,1609]`) y el toque en (195,1563) disparó el puente [C7] |

Estado final: contenedores `fc-e01-build`, `fc-e01-srv` y `fc-e01-tunel` eliminados; `fc-android-emu` queda corriendo
(con la app del ensayo instalada); en el g42 queda instalado **sólo** `com.frameworkconcept.ensayo01` (no se tocó
ninguna otra app ni ajuste); intermedios `bin/obj` borrados.
