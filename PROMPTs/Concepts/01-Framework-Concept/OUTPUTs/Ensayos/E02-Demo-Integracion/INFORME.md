# E02 — Integración de la demo (tramo A3)

Fecha: 2026-10-26. Tramo: integrador (plan A1–A5, folio 037). Decisiones que rigen: dictamen de la ronda 2
(folio 035, §3, P1–P13) y aprobaciones del PO (folios 023 y 036).
Raíz de la demo: `LAB/Lab-Documentos/Lab-Documentos/Concepts/Framework-Concept/Demo/`.

Este tramo retomó dos intentos anteriores que se cortaron: uno por el límite de sesión y otro, duplicado, que paró la
presidencia hacia las 08:00. Se conservó su trabajo. Ese trabajo incluye el arreglo UTF-8 del puente, la variante
`sin-listo` y una corrida parcial en el moto g42 que llegó hasta la encuesta en el outbox. En esta sesión el g42
quedó reservado para otra sesión del PO y no se usó. El dispositivo de esta integración fue el emulador
`fc-android-emu-hpdev`.

## 1. Hipótesis

H1. Las piezas de A1 y A2 (núcleo, actualizador, cascarón, contenido, herramientas, receptor, compuerta) compilan
juntas y la compuerta local queda en verde.

H2. En un dispositivo con WebView ≥ 94, el cascarón real hace el recorrido de P11:

- arranca con la semilla y la muestra;
- guarda en el outbox una encuesta tomada sin red;
- con v2 publicada, la baja sin esperar y la activa en el próximo arranque en frío, antes de mostrar;
- la respuesta tomada con v1 se acepta con `versionDefinicion = 1` (P13);
- rechaza un índice con firma inválida;
- vuelve a `previous` si un contenido no avisa «Listo» (P2).

H3. Ese recorrido corre con un solo camino de red, sin túnel público (P11) y sólo por HTTPS (P2).

## 2. Entorno exacto

| Pieza | Valor |
| --- | --- |
| Máquina | i7infra (Debian, kernel 6.12.111), sin dotnet ni adb en el host |
| Compilación | contenedor `lab-e2e-maui-dev:net10` (`sha256:9cd6103e…`, 2026-09-13): SDK 10.0.400, `maui-android` 10.0.20, JDK 17; volumen NuGet `fc-nuget`; usuario 1000:1000 |
| Navegador | `mcr.microsoft.com/playwright:v1.62.1-noble` (Chromium headless), puente simulado |
| Dispositivo | `fc-android-emu-hpdev`: Android 13 (API 33), x86_64, Google APIs, 4 GB, KVM; WebView `com.google.android.webview` 155.0.8059.43; pantalla 540×1200 a 420 dpi (≈ 205 dp de ancho) |
| adb | `docker exec adb-contenedor adb -H 203.0.113.20 -P 5042 -s emulator-5554` (servidor adb del emulador por Tailscale; ni `connect`, ni `kill-server`, ni `start-server`) |
| Red | el emulador llega a `https://203.0.113.10:8099`, la IP de Tailscale de i7infra, sin túnel |
| Receptor | `fc-demo-receptor` (Kestrel en HTTPS, `0.0.0.0:8099`), certificado de la CA de demostración con SAN `localhost`, `127.0.0.1`, `203.0.113.10` |
| APK | Debug, `android-x64`, `com.frameworkconcept.demo`, cascarón 1.0.0 (build 1), puente 1.0.0, `FcCanalUrl=https://203.0.113.10:8099` |
| Commit corto con el que se empaquetó | `5d5c2b4` (HEAD de Lab-Documentos; la demo todavía no está versionada) |

## 3. Pasos reproducibles

Todo desde la raíz de la demo. Los comandos de adb son los de la tabla de arriba, y `emu.sh` es el ayudante del tramo
(fuera del repositorio, en `~/fc-work/demo/a3/emu.sh`): arranque en frío con `am force-stop` + `am
start -W`, captura, logcat del pid y `force-stop` al final.

```bash
# (1) compilación y compuerta
FC_NOMBRE=fc-a3-sln scripts/contenedor.sh env CI=true dotnet build FrameworkConcept.Demo.sln -c Debug
scripts/ci-local.sh
scripts/guion.sh humo
src/FrameworkConcept.Content/Testing/probar-en-navegador.sh <carpeta-de-capturas>

# (2) recorrido sin dispositivo
scripts/guion.sh claves
scripts/guion.sh publicar v1 && scripts/guion.sh definicion v1 && scripts/guion.sh firmar && scripts/guion.sh verificar
scripts/guion.sh semilla
FC_TLS_IPS=203.0.113.10 scripts/guion.sh tls --forzar
scripts/guion.sh servir
FC_RID=android-x64 FC_URL_CANAL=https://203.0.113.10:8099 scripts/guion.sh apk

# (3) recorrido en el dispositivo
export FC_ADB_CONTENEDOR=adb-contenedor FC_RID=android-x64
scripts/guion.sh dispositivo -H 203.0.113.20 -P 5042 -s emulator-5554
scripts/guion.sh instalar    -H 203.0.113.20 -P 5042 -s emulator-5554
emu.sh frio 01-primer-arranque-semilla 30
scripts/guion.sh parar                     # sin receptor
#   encuesta completa por adb input (pasos 1 a 3, «Registrar la encuesta») → «Por enviar: 1»
scripts/guion.sh publicar v2; scripts/guion.sh definicion v2; scripts/guion.sh firmar; scripts/guion.sh servir
emu.sh frio 05-arranque-baja-v2-y-sincroniza 60
scripts/guion.sh respuestas
emu.sh abrir 06-arranque-activa-v2 '…'     # Inicio + pestaña Encuesta
scripts/guion.sh firma-invalida; emu.sh frio 08-indice-con-firma-invalida 50
scripts/guion.sh publicar sin-listo; scripts/guion.sh firmar
emu.sh frio 09-sin-listo-a-baja-1.2.0 50; emu.sh frio 10-sin-listo-b-activa-1.2.0 50; emu.sh frio 11-sin-listo-c-vuelve-a-previous 50
emu.sh abrir 12-diagnostico '…'            # pantalla Diagnóstico
scripts/guion.sh parar
```

`scripts/guion.sh demo` hace este mismo recorrido como un solo comando, con un paso manual para la encuesta. Se
reescribió en este tramo y **no se corrió entero** (ver §6).

## 4. Resultados

### 4.1 Compilación y compuerta (H1: se cumple)

| Corrida | Resultado |
| --- | --- |
| `FrameworkConcept.Demo.sln`, Debug, `CI=true` (los 8 proyectos, con el cascarón) | 0 avisos, 0 errores (1 min 11 s) |
| `ci-local.sh` (dos veces, antes y después de los arreglos de esta sesión) | verde: build sin MAUI 0/0, Core.Tests 65/65, Update.Tests 96/96, Gate.Tests 46/46, contenido 1.0.0 empaquetado, APK arm64 0/0 |
| APK `android-x64` con la CA de demostración | 0/0; el APK lleva `res/xml/network_security_config.xml`, `res/raw/ca_demo_tls.crt`, `assets/semilla/…` (sólo 1.0.0 y v1) y `assets/claves/publica-demo.pem` |
| APK `android-x64` sin la CA (`-p:_CaDeDemo=/no/existe.crt`, `CI=true`) | 0/0 (variante `Red/SinCa/`; no se inspeccionó el contenido del APK) |
| `guion.sh humo` | 46 OK, 0 MAL, después de los cambios de `servir` |
| Contenido en Chromium headless con el puente simulado | 40 de 40; las 10 capturas están en `local/navegador/` con su `.txt` |

### 4.2 Recorrido en el dispositivo (H2: se cumple en el emulador)

| # | Paso | Evidencia | Resultado |
| --- | --- | --- | --- |
| 1 | Primer arranque en frío, receptor arriba con el índice v1 | `hpdev-01-…` | `activada la semilla 1.0.0+5d5c2b4` y Listo(1.0.0). La consulta da `AlDia`. **La semilla ya era v1**: `semilla/` se regeneró desde el canal con sólo 1.0.0 y v1, como pedía A2 (b) |
| 2 | Receptor apagado; encuesta de tres pasos (Ana Perez, 34, Corrientes; bicicleta y tren, a diario; 12.5 km, 45 min, trabajo) | `hpdev-02a…04-…`, `logcat-hpdev-02-…` | «Encuesta guardada en el teléfono», «Por enviar: 1», definición v1, clave `06ddabf6…`. `outbox: intento 1 → Pendiente (Connection failure)`. La consulta del canal da `SinRed`, sin bloquear |
| 3 | Se publican la definición v2 y el contenido 1.1.0, vuelve el receptor y se abre en frío | `hpdev-05-…`, `receptor-respuestas-tras-sincronizar.json` | Se ve 1.0.0 (N = 0). `outbox: intento 2 → Enviada (HTTP 201)`. Consulta `Preparado`: 1.1.0 queda en staging y la definición v2 guardada |
| 4 | Arranque en frío | `hpdev-06-…`, `hpdev-07-…` | `activada 1.1.0+5d5c2b4 (desde staging)` antes de mostrar: cabecera azul y «Novedades de esta versión». La encuesta nueva dice «Se está tomando con la definición v2» |
| 5 | Respuestas en el receptor | `receptor-respuestas-final.json` | 1 aceptada: `versionDefinicion: 1`, `versionContenido: 1.0.0+5d5c2b4`, `definicion {encuesta-movilidad, 1}`, valores con su tipo. Carta muerta vacía, 0 duplicados (**P13**) |
| 6 | `firma-invalida` y arranque en frío | `hpdev-08-…` | `Rechazado FirmaInvalida — firma rechazada (keyId «demo-2026»)`. Sigue 1.1.0. Después se volvió a firmar |
| 7a | `publicar sin-listo` (1.2.0) y arranque | `hpdev-09-…` | Se ve 1.1.0 y la consulta da `Preparado`: 1.2.0 queda en staging |
| 7b | Arranque | `hpdev-10-…` | `activada 1.2.0 (desde staging)` y `retención: borrada 1.0.0`. Se dibuja 1.2.0 y **no hay `puente Listo`** en todo el proceso |
| 7c | Arranque | `hpdev-11-…` | `rollback: 1.2.0 no confirmó Listo; queda como fallida`, `vuelve a previous 1.1.0`. La consulta siguiente da `Rechazado FallidaLocal — no se reinstala` |
| 8 | Diagnóstico | `hpdev-12-…`, `hpdev-12b-…` | Cascarón 1.0.0 (build 1), puente 1.0.0, contenido 1.1.0, definición v2 (guardadas v1 y v2), canal `dev — https://203.0.113.10:8099/`, huella del contrato, `current/previous 1.1.0 / —`, fallidas: 1.2.0 |

Cada captura está en `local/hpdev-*.png` con su `.txt` de tres líneas al lado del informe (`hpdev-*.txt`), y cada
paso tiene su logcat filtrado en `logcat-hpdev-*.txt`. El filtro es el pid de la app con las etiquetas `FC`,
`chromium`/`CONSOLE`, `AndroidRuntime` y `DOTNET`. Las capturas intermedias de navegación están en
`local/hpdev-navegacion/`.

**H3 se cumple**: hubo un solo camino de red (la IP de Tailscale de i7infra), sin túnel y en HTTPS, con la CA de
demostración aceptada sólo por el APK depurable. El reenvío inverso de puertos de adb no se usó y sigue NO VERIFICADO.

### 4.3 Primer render (TPR) en cada paso

TPR = la hora del `FC-MARCA primer-render` en el logcat menos el inicio del proceso. El inicio se calcula con la
primera línea `FC` y su `t=`. `am` es el `TotalTime` de `am start -W`, que mide hasta la pantalla de arranque del
cascarón. Los tiempos están en ms.

| Paso | am | Pantalla del cascarón | Contenido listo para cargar | WebView agregado | **TPR** | Listo |
| --- | --- | --- | --- | --- | --- | --- |
| 01 semilla (primer arranque) | 4 414 | 2 710 | 28 074 | 29 375 | **36 118** | 36 169 |
| 02 encuesta sin red | — | 1 098 | 20 788 | 23 507 | **34 525** | 34 588 |
| 05 baja v2 y sincroniza | 2 636 | 1 038 | 14 296 | 18 098 | **29 145** | 29 219 |
| 06 activa v2 | 2 584 | 1 328 | 18 777 | 22 054 | **31 095** | 31 155 |
| 08 firma inválida | 2 316 | 1 160 | 16 686 | 20 460 | **31 627** | 31 673 |
| 09 baja 1.2.0 | 2 229 | 1 096 | 17 763 | 21 470 | **33 707** | 33 778 |
| 10 activa 1.2.0 (sin Listo) | 2 348 | 1 214 | 21 501 | 24 706 | **34 271** | — |
| 11 vuelve a previous | 2 432 | 1 283 | 17 313 | 20 097 | **29 396** | 29 449 |
| 12 diagnóstico | 2 126 | 926 | 20 910 | 23 833 | **33 579** | 33 622 |

En este emulador, TPR va de 29 a 36 s. **No sirve para el umbral de P1**, que se fija en el moto g42 (≤ 5 000 ms,
máximo de 5 corridas). El emulador es varias veces más lento: entre `claves` y `semilla` pasan de 8 a 13 s, contra
0,7 s en el g42.

Dato del intento anterior en el **moto g42**, con el mismo contenido 1.0.0 y la consulta fuera del camino crítico:
TPR de 8 176, 8 212, 8 254 y 8 741 ms en arranques con la semilla ya instalada, y 10 206 ms en el primero. Los logcats
están en `logcat-g42-intento-anterior-*.txt`. Son **más de 5 000 ms**. El desglose del g42 es: pantalla del cascarón
a 1,3 s, base 2,9 s, claves 3,2 s, semilla 3,9 s, contenido listo para cargar 4,2 s, WebView agregado 4,6 s y primer
render 8,2 s. Antes de agregar el WebView se van 4,6 s en pasos que corren uno detrás de otro (base, claves y
semilla). Este tramo no lo corrigió: es una decisión de diseño del arranque. Queda como hallazgo para la presidencia
(§5, H-A).

## 5. Hallazgos para la presidencia

- **H-A (P1, umbral).** El TPR del g42 medido por el intento anterior, 8,2–8,7 s, supera el umbral de 5 000 ms.
  `SemillaEmbebida.CargarAsync` lee y verifica la semilla en **cada** arranque en frío, aun con contenido instalado,
  y corre antes de mostrar, igual que la base y las claves. No es la corrida de 5 en la condición declarada, así que
  el estado de P1 sigue «sin medir». El orden de magnitud sí está fuera. **Corregido en parte** (§9): la semilla ya
  no se carga después del primer arranque, pero en el g42 costaba unos 0,7 s, y el TPR estimado (~7,5 s) seguiría
  fuera del umbral. Falta medirlo en el g42.
- **H-B (contenido, ancho).** A 205 dp de ancho, el emulador muestra la cabecera y las tarjetas del contenido más
  anchas que la pantalla (scroll horizontal; los valores de la tarjeta «Versiones» se parten letra por letra). La
  demo se pudo recorrer igual. Un teléfono real tiene 360 dp o más, y en el g42 (432 dp) no se vio.
- **H-C (retención).** Después del rollback de 1.2.0 queda `current 1.1.0 / previous —`. La 1.0.0 se borró al
  activar la 1.2.0 (current + previous) y la 1.2.0 se borró al fallar. Una falla siguiente de 1.1.0 llevaría al
  estado terminal. Coincide con P2 («Teléfono: current + previous»), pero conviene que la guía lo diga.
- **H-D (evidencia del g42).** La captura `local/01-primer-arranque-semilla.png` del intento anterior en el g42 se
  sobrescribió por error con la primera captura del emulador, que después se renombró a `hpdev-01-…`. Las demás
  capturas del g42 se movieron a `local/g42-intento-anterior/`, y sus logcats están en
  `logcat-g42-intento-anterior-*.txt`.

## 6. Arreglos de integración (anotados)

| Archivo | Cambio | Por qué |
| --- | --- | --- |
| `src/FrameworkConcept.Content/wwwroot/js/puente.js` (intento anterior) | El sobre viaja en ASCII, con los caracteres no ASCII escapados como `\uXXXX` | En Android, `hybridwebview.js` (MAUI 10.0.20) manda el cuerpo en el encabezado `X-Maui-Request-Body`, que no admite UTF-8. En el g42, «¿Qué» llegaba como «�Qu�» |
| `src/FrameworkConcept.Content/FrameworkConcept.Content.csproj`, `Bridge/BridgeSession.cs`, `scripts/guion.sh` (intento anterior) | `-p:ContenidoSinListo=true` y `guion.sh publicar sin-listo` (1.2.0) | Demo del rollback por marca (P2, P11) |
| `scripts/guion.sh` | `tls [--forzar]`: CA y certificado ECDSA P-256 de 30 días, con openssl dentro del contenedor, en `claves/tls/`. `servir` levanta Kestrel en HTTPS si existe `claves/tls/receptor.crt`. Suma el subcomando `respuestas` | P2 «sólo HTTPS» sin túnel público (P11). El receptor no cambia de código: Kestrel lee el PEM por configuración |
| `src/FrameworkConcept.Shell/FrameworkConcept.Shell.csproj`, `Platforms/Android/AndroidManifest.xml`, `Platforms/Android/Red/{ConCaDeDemo,SinCa}/network_security_config.xml` | `android:networkSecurityConfig`: sin tráfico en claro. En Debug, si existe la CA de demostración, la acepta dentro de `debug-overrides` | El APK de Release ignora `debug-overrides`. Android exige nombres de recurso `[a-z0-9_.]`, y el primer intento con guiones dio `APT0003` |
| `.gitignore` | `claves/tls/` | No se versiona ninguna clave privada (P2) |
| `scripts/guion.sh` (humo) | La prueba de humo usa `TLS=salida/humo/sin-tls` | Para que siga probando el receptor en HTTP aunque la demo tenga su certificado |
| `scripts/guion.sh` (demo, arrancar) | `demo` hace el recorrido completo, exige `FC_URL_CANAL` y llama a `tls`. El logcat de `arrancar` filtra `I/FC` y `FC-MARCA` | El filtro anterior (`frameworkconcept`) no capturaba la bitácora `FC` |
| `semilla/` | Se regeneró desde el canal con sólo 1.0.0 y v1 | Aviso (b) de A2: con 1.1.0 y v2 en la semilla, la demo v1 → v2 no se veía |
| `README.md` | Cómo se corre, el recorrido, la CA de demostración y el estado A2/A3 | Encargo (4) |

No se tocó el workflow. En el runner no hay `claves/tls/`, así que el APK sale con `Red/SinCa/`.

## 7. NO VERIFICADO

- La corrida en el **moto g42** (reservado) y, con ella, el umbral TPR ≤ 5 000 ms en la condición declarada (P1),
  también después de las correcciones (§9). Con el g42, el único medio de red es el túnel de laboratorio: es un
  desvío declarado de P11.
- `guion.sh demo` de punta a punta como **un solo comando**. Se corrieron sus subcomandos uno por uno, y la encuesta
  y la navegación, con `emu.sh`.
- Un sobre con caracteres **no ASCII** en el dispositivo después del arreglo del puente. La encuesta de esta corrida
  fue ASCII (Ana Perez, Corrientes).
- El contenido del APK compilado sin la CA. Compiló con 0/0, pero no se abrió el APK para ver qué configuración de
  red lleva.
- La corrida del workflow en el runner (`i7infra-runner-dev`) y el riesgo de `workloadVersion` 10.0.400.1 contra el
  workload 10.0.110 del runner.
- El reenvío inverso de puertos de adb como camino de red (P11, candidato del dictamen).
- La corrida con red cortada en el **dispositivo**, que P11 pide como criterio de aceptación (3). Acá se cortó el
  receptor, no la red del dispositivo («Con red» siguió visible).

## 9. Correcciones de la revisión adversarial (2026-10-26, después de A3)

El detalle de cada brecha (brecha → archivo → verificación) está en `correcciones.md`, y sus logs en
`correcciones-evidencia/`. En resumen:

| Brecha | Corrección | Verificación |
| --- | --- | --- |
| P0 · sin receta de contenedor (P11) | `Demo/contenedor/Dockerfile` (SDK 10.0.400 por digest, workload set 10.0.400.1, JDK 17, Android SDK, python3, openssl); `scripts/imagen.sh` la construye si falta | Construida desde cero (rc 0); copia limpia de 185 archivos: `humo` 47/0, `ci-local.sh --hasta 4` rc 0 |
| P1 · TPR: semilla en cada arranque | `IFuenteDeSemilla` y `PunteroDeContenido.SemillaRevisada`: la semilla se carga sólo en el primer arranque o con otro APK | `Update.Tests` 102/102 con su rojo; emulador: 15 arranques seguidos sin cargar la semilla. **TPR del g42 NO VERIFICADO** |
| P1 · camino de red del g42 (P11) | Desvío declarado en README y `guion.sh`; `tunel` en HTTPS hacia el receptor con TLS | `bash -n`; túnel y g42 NO VERIFICADOS |
| P1 · rojos de P8 | `Demo/etapas/`: M-13, aviso promovido a error y error de compilación del cascarón | M-13: `Core.Tests` 6 en rojo; aviso: error con `CI=true`; APK: CS0029 |
| P1 · rojo local con M-13 | `ci-local.sh --hasta 4` con M-13 | rc 1 en `Core.Tests`; el PR en el runner queda para A5 |
| P1 · plantilla de PR (P6.6) | `Lab-Documentos/.github/pull_request_template.md` | Revisión del archivo; en un PR real, NO VERIFICADO |
| P1 · rollback de versiones sanas | Evidencia de carga (`_framework/dotnet.js`) + `CargasSinListoParaFallar = 2` (criterio de este tramo, para ratificar); staging en espera mientras hay pendiente | `Update.Tests` con su rojo; emulador: un corte antes de cargar no cuenta, dos cargas sin Listo vuelven a previous |
| P1 · `claves`/`humo` pisaban la pública | `claves` pide `--forzar`; `humo` con claves propias; `Gate.Tests/Semilla` | Huella `b6833f20…` intacta; rojo de Gate con otra clave |

Compuerta después de las correcciones: `ci-local.sh` en verde (build 0/0, Core.Tests 65/65, Update.Tests 102/102,
Gate.Tests 47/47, contenido empaquetado, APK arm64 0/0), en el contenedor de la receta.

Un hallazgo nuevo para la presidencia: **H-E**. El criterio «2 cargas sin Listo» modifica la lectura literal de P2
(«si el arranque siguiente la encuentra, vuelve a previous»). No agrega temporizador. Como valor, hay que ratificarlo
o cambiarlo.

## 8. Limpieza

Al terminar se bajó `fc-demo-receptor`. Se borraron `bin/` y `obj/` de la demo, y también `salida/`, porque son
regenerables. Se conservaron `semilla/` (v1) y `claves/` (la privada y `tls/` están en el `.gitignore`). Los logs del
tramo quedaron en `~/fc-work/demo/a3/`. En el emulador, `com.frameworkconcept.demo` quedó instalada y
detenida (`force-stop`), sin foco.
