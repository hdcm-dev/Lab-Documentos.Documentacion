| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-10-25 |
| Autor | Comisión Seguridad del canal y tiendas |
| Corrige | — |

| Campo | Valor |
| --- | --- |
| Rol | Seguridad del canal de actualización y políticas de tiendas (comisión, a ciegas) |
| Fecha | 2026-10-25 |
| Expediente | 0001-Framework-Concept-Maui-Autoactualizable · carta en `evidencia/008-carta-seguridad-canal-y-tiendas.md` |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | Cabecera y §0 (líneas 1–111); por el «Mapa de carga», fila «Sos una comisión»: la carta (§5.2), §2.2, §3.2, §3.3 y §4 |
| Documentos cargados con versión | Cadena-De-Consecuencias 2.0 (§2 y §3); Escalas-De-Juicio 1.0 (§3.1–§3.5); Release-Y-Despliegue-Versionado 2.0 (§2.2–§2.4, §3.2, §5.1: remisión de la carta y del contrato); Versionado-Producto-Integral 2.0 (sólo la fila de §2.6, línea 225). Excepcion-A-Un-Conocimiento **no** se cargó: no propongo dejar de seguir ninguna convención (§6) |
| Medios | Lectura de los insumos; textos oficiales descargados con `curl` el 2026-10-25; un ensayo propio en el moto g42 (`<serie-del-g42>`) bajo la regla de candado de la presidencia (`flock …/escenarios.lock`, tramos cortos, `am force-stop` al terminar, paquete propio desinstalado) |

# Informe — Seguridad del canal de actualización y políticas de tiendas

## 0. Ensayo propio (E-SEG-1), para que los hallazgos tengan ancla E1

**Qué mide.** Si un cascarón .NET 10 en Android verifica, con lo que trae la plataforma, la firma de un manifiesto
producido fuera del teléfono (como en el pipeline), y si rechaza **sin activar** cada alteración. También mide si
Ed25519 anda en Android con una biblioteca de terceros, que es un NO VERIFICADO de N1 (§10).

**Diseño.** Una app Android mínima (`net10.0-android`, paquete propio `com.frameworkconcept.segcanal08`, sin red)
trae embebidos un paquete de 1 MiB, cuatro manifiestos y sus firmas. Los vectores los generó `openssl` 3.0.13 en un
contenedor `lab-e2e-maui-dev:net10`: ECDSA P-256 con SHA-256 (firma DER) y Ed25519. Las claves privadas se borraron
después de firmar. El orden de verificación es el que propongo para el framework: **firma sobre los bytes del
manifiesto → vencimiento → monotonía de versión → hash del paquete → recién ahí activaría**. Para Ed25519 se usa
`BouncyCastle.Cryptography` 2.6.2, porque .NET 10 no lo trae.

**Comando de la corrida (con el candado):**

```text
flock -w 300 …/escenarios.lock bash -c "adb -H 203.0.113.30 -P 5037 -s <serie-del-g42> install -r fc-segcanal08.apk;
  … am start -W -n com.frameworkconcept.segcanal08/crc64ab7e0cc8de684654.MainActivity; sleep 8;
  … logcat -d -v time FCSEG:I '*:S' > logcat-g42-segcanal08.txt; … am force-stop com.frameworkconcept.segcanal08"
```

**Salida (logcat del g42, 2026-10-25 17:35, extracto literal):**

```text
I/FCSEG (26851): runtime=.NET 10.0.11 os=Android (API level 33) rid=android-arm64
I/FCSEG (26851): ECDsa.Create()=System.Security.Cryptography.ECDsaImplementation+ECDsaAndroid
I/FCSEG (26851): Ed25519 nativo .NET: ausente
I/FCSEG (26851): C01 ecdsa valido -> ACTIVA 1.0.1 (antes 1.0.0) | esperado ACTIVA | OK | 360,9 ms
I/FCSEG (26851): C02 ecdsa manifiesto alterado -> RECHAZA firma invalida | esperado RECHAZA | OK | 6,4 ms
I/FCSEG (26851): C03 ecdsa firma alterada -> RECHAZA firma invalida | esperado RECHAZA | OK | 2,3 ms
I/FCSEG (26851): C04 ecdsa otra clave -> RECHAZA firma invalida | esperado RECHAZA | OK | 2,5 ms
I/FCSEG (26851): C05 ecdsa paquete alterado -> RECHAZA sha256 del paquete no coincide | esperado RECHAZA | OK | 3,7 ms
I/FCSEG (26851): C06 ecdsa version vieja (rollback) -> RECHAZA version 1.0.0 <= instalada 1.0.1 | esperado RECHAZA | OK | 2,3 ms
I/FCSEG (26851): C07 ecdsa misma version (replay) -> RECHAZA version 1.0.1 <= instalada 1.0.1 | esperado RECHAZA | OK | 2,5 ms
I/FCSEG (26851): C08 ecdsa vencido (freeze) -> RECHAZA manifiesto vencido 2026-01-01T00:00:00.0000000+00:00 | esperado RECHAZA | OK | 7,9 ms
I/FCSEG (26851): C09 ed25519 valido -> ACTIVA 1.0.1 (antes 1.0.0) | esperado ACTIVA | OK | 221,2 ms
I/FCSEG (26851): C10 ed25519 manifiesto alterado -> RECHAZA firma invalida | esperado RECHAZA | OK | 2,1 ms
I/FCSEG (26851): C11 ed25519 firma alterada -> RECHAZA firma invalida | esperado RECHAZA | OK | 1,5 ms
I/FCSEG (26851): RESUMEN 11/11 casos como se esperaba
```

**Lectura.** 11 de 11 casos dieron lo esperado. La verificación ECDSA P-256 la hace la implementación de plataforma
(`ECDsaAndroid`), sin dependencias. El primer caso de cada algoritmo carga más (361 ms en ECDSA y 221 ms en Ed25519:
incluyen el arranque del tipo y el SHA-256 de 1 MiB). Los siguientes tardan entre 1,5 y 8 ms. `openssl` confirmó los
vectores fuera del teléfono: `Verified OK` para el manifiesto válido y `Verification failure` para el alterado.

**Límites (NO VERIFICADO).** No se ensayó iOS. No se probó un paquete real descargado por red. El SHA-256 se calculó
en memoria sobre 1 MiB, no en streaming sobre los 3,39 MB de E01. Tampoco se midió el peso que BouncyCastle suma al
APK.

**Huellas y rutas locales** (scratchpad de esta sesión; la evidencia cruda queda local):

| Pieza | Ruta | sha256 |
| --- | --- | --- |
| Log de la corrida | `…/scratchpad/seg/ens/logcat-g42-segcanal08.txt` | `a15a17ad4a89c7eb9adb303ea2f28aad186516eae74d24c58c58eb9620d05e08` |
| Código de la sonda | `…/scratchpad/seg/ens/App/MainActivity.cs` | `501997d57cb6bb755f6379d28006f2616feaae37137fdcf87b2b03e5c3a17c3e` |
| Generador de vectores | `…/scratchpad/seg/ens/vec/gen.sh` | `e38ccffc1d493134636d6dca4c553168d3296c3b2642ecb403ebc4774f2189c5` |
| APK probado | (borrado con `bin/obj`) | `c4b90d02760ab2f60d13e21f7d0bd1fab9557f8a24d1861030b67612e01d1d30` |

(`…` = `{tmp-de-sesiones}/<proyecto>/6e043f4a-ac59-44a7-a89a-8b2093f94f90`)

**Incidentes que declaro.**

1. **Choque de nombre de paquete con otra sesión.** El primer APK se llamó `com.frameworkconcept.seguridad01`. Al
   abrirlo, la pantalla mostraba otra app («SegEnsayo», 16 casos, otro código). `dumpsys package` dio
   `firstInstallTime=2026-10-25 17:29:21`: otra sesión instaló un APK con el mismo `applicationId`. No toqué ese
   paquete, porque ya no es mío. Cambié a un nombre propio (`segcanal08`) y descarto esa primera corrida.
2. **Intermedios en `/vm`.** R2 §8 pide los intermedios fuera de `/vm` (R2 línea 489), y los dejé en el scratchpad,
   que vive en `/vm`. El pico fue de 60 MB y 472 archivos; borré `bin/obj` y quedan 4,3 MB en 48 archivos. Tampoco
   usé el prefijo `fc-` en los contenedores, que fueron efímeros (`--rm`).

## 1. Lectura del objetivo: lo que da por fijo sin origen

El OBJETIVO del folio 003 (líneas 46–51) tiene origen en cada cláusula. Lo que se da por fijo sin origen está en el
**sujeto** del enunciado y en una **omisión**:

- **«Android e iOS» toma su origen del borrador, que el mismo contrato declara no vinculante.** El folio 003, líneas
  15–16, fija el sujeto «apps .NET MAUI con páginas Blazor híbridas, Android e iOS (Framework-APP.md §1)». Las
  líneas 40–41 del mismo folio dicen que el borrador es «insumo e hipótesis a refutar, no el objeto». El prompt
  nombra «play store de google o app connect de apple» sólo como el ciclo rígido que se quiere evitar (evidencia
  001, línea 21), y la lectura que menos agrega no los obliga a soportar ambas plataformas. Para mi competencia esto
  pesa: la viabilidad de la opción A en iOS es justo lo que no se puede verificar (§3, P1 y P9).
- **Al objetivo le falta la cláusula de conformidad con las tiendas.** La lectura de P0 la usa como restricción dura
  («mecanismo que una tienda prohíbe», folio 003, línea 67), pero no figura en RESTRICCIONES DURAS (líneas 72–75), y
  FUERA DE ALCANCE excluye «publicar en tiendas» (línea 84). Un juicio P0 se apoya entonces en una restricción que el
  contrato no asienta. Es el hallazgo H-01.

## 2. Hallazgos

Marca de detectabilidad (Escalas-De-Juicio §3.5) al final de cada hallazgo: `[enum]` = enumerable,
`[interp]` = interpretativo.

| Id | Nivel | Ancla | Hallazgo | Impacto si no se corrige | Dirección de la corrección |
| --- | --- | --- | --- | --- | --- |
| H-01 | P1 | **E2**, folio 003, l.67: «P0: … mecanismo que una tienda prohíbe», contra l.72–75 (RESTRICCIONES DURAS, sin tiendas) y l.84 («FUERA DE ALCANCE: publicar en tiendas»); l.15–16 contra l.40–41 (sujeto «Android e iOS» tomado del borrador declarado no vinculante) | El contrato juzga P0 contra la conformidad con las tiendas sin asentarla como restricción. El sujeto «iOS» sale de un insumo que el mismo contrato declara hipótesis `[interp]` | Las comisiones leen distinto qué es P0 en materia de tiendas. La guía podría prometer iOS con una base que nadie pidió con su literal | Asentar la conformidad con Play y App Store como restricción del contrato (lo que se diseña tiene que poder distribuirse por tienda, aunque no se publique). Preguntar al PO, en una línea, si iOS entra en el objetivo o queda como diseño declarado sin ensayo |
| H-02 | P1 | **E2**, política de Google Play *Device and Network Abuse* (texto descargado [S3]): «An app distributed via Google Play may not modify, replace, or update itself using any method other than Google Play's update mechanism. Likewise, an app may not download executable code (such as dex, JAR, .so files) … This restriction does not apply to code that runs in a virtual machine or an interpreter …»; contra N1 §4.3 (l.161–167) y §6, razón 2 (l.442), que leen la excepción como cobertura total de la OTA | «This restriction» viene después de «Likewise…» y, leído al pie de la letra, exceptúa la descarga de código ejecutable; **no** dice que exceptúe la primera oración («update itself»). N1 lo trata como resuelto `[interp]` | La guía enseñaría como «permitido por Play» algo que el texto sólo tolera en una lectura. Un revisor de Play que lea la primera oración choca con el modelo entero | La guía distingue las dos oraciones. El argumento de conformidad se arma así: (a) el binario sólo se actualiza por Play (In-App Updates); (b) lo que baja es contenido que corre en el WebView, el caso que nombra la excepción; (c) dentro del propósito declarado (regla R1 de N1). Se asienta como **lectura**, no como hecho; NO VERIFICADO un pronunciamiento de Google que cubra la OTA de contenido |
| H-03 | P1 | **E2**, App Review Guidelines 4.2.3(ii) [S1]: «If your app needs to download additional resources in order to function on initial launch, disclose the size of the download and prompt users before doing so.»; contra Framework-APP.md l.140 (semilla sin contenido definido), E01 `INFORME.md` l.85 («Página mínima embebida, para cuando no hay nada descargado») y el pedido «de forma automatica» (evidencia 001, l.21) | Si la semilla es una página mínima, el primer arranque **necesita** descargar para funcionar. En iOS eso obliga a mostrar el tamaño y pedir conformidad, y entra en tensión con «automática» `[interp]` | Rechazo en revisión de Apple, o un primer arranque que se cuelga sin red. Las lecturas divergen entre «semilla = página de espera» y «semilla = contenido completo» | La semilla es **una versión completa del contenido**, construida en el mismo pipeline que el paquete OTA y firmada igual (coincide con N1 §7, pregunta 10). Las descargas posteriores son actualizaciones de algo que ya funciona. Si alguna vez la semilla no alcanza, el primer arranque pide conformidad con el tamaño |
| H-04 | P1 | **E2**, E01 `src/Cascaron/E01/Actualizador.cs` l.50: `if (instalada == m.version) return "al día …"` (acepta cualquier versión distinta, también una menor); Framework-APP.md l.118 «¿Paquete nuevo?» sin criterio; N1 l.366 («rechaza `version` ≤ la instalada») contra N1 l.384 (directiva `rollBackToEmbedded` que el servidor ordena). **E1**: E-SEG-1, casos C06/C07 rechazan el downgrade y el replay con firma válida | El diseño junta dos cosas que se contradicen: anti-rollback del lado del cliente y una vuelta atrás que ordena el servidor. La pieza ensayada no tiene anti-rollback `[interp]` | Quien controle el servidor, o tenga un manifiesto viejo firmado, reinstala una versión vulnerable: es el «rollback attack» de TUF [S6, §5.5] | Monotonía estricta por canal en el cliente. La vuelta atrás **ordenada por el servidor** se hace **hacia adelante**: se republica el contenido bueno con una versión mayor (Release-Y-Despliegue inv. 2, l.115: identidad «no se reutiliza jamás»; inv. 15, l.156). La vuelta atrás **local** (falló el «arranqué bien») va sólo a `previous`, que ya se había verificado, y marca la versión mala como bloqueada para no reinstalarla en bucle. `rollBackToEmbedded` sale del manifiesto o se reduce a «contenido mayor que reproduce la semilla» |
| H-05 | P1 | **E1**: `grep -n 'custodia\|rotaci' N3-PR-Integracion-Y-Versionado.md \| wc -l` → `0`; **E2**: N1 l.503 («Qué necesita N1 de vuelta: Custodia y rotación de la clave de firma») contra N3 l.355 («nada de secretos en el runner») y folio 003 l.101–102 (repos **PÚBLICOS**) | Nadie es dueño de la **clave privada de firma del contenido**. N1 se la pasa a N3, N3 no la trata y prohíbe secretos en el runner autoalojado que el pedido manda usar `[interp]` | Lecturas divergentes: la clave termina en el repo público, en el runner `i7infra-dev` o en la máquina de alguien. Robada la clave, «quien controle el servidor o la red controla la app» (Framework-APP.md l.380) | Fijar una custodia: la firma corre en un job aparte, en un runner **hospedado por GitHub**, que referencia un *environment* con revisor obligatorio. GitHub: «a job cannot access environment secrets until one of the required reviewers approves it» y, en Free, «environment secrets are only available in public repositories» [S9]. El repo es público según el despacho, así que está disponible. La clave de la demo se rotula **clave de demostración** en la guía y nunca se reutiliza. Solicitud a DevOps por el procedimiento (§5) |
| H-06 | P1 | **E2**, Framework-APP.md l.137: «el cascarón trae la **clave pública embebida**» (singular); TUF 1.0.37 §5.3 «Update the root role» [S6]: cada versión nueva de root la firman umbrales de la clave vieja y de la nueva | Con una sola clave embebida y sin procedimiento de rotación, comprometida la clave, la única salida es un release del cascarón por tienda. La parte «Robo de clave» que N1 marca parcial (l.368) queda sin diseño `[interp]` | Una clave filtrada obliga a esperar la revisión de la tienda, justo el ciclo que el pedido quiere evitar. Mientras tanto, el atacante sigue firmando | El cascarón embebe un **conjunto de claves con `keyId`**: la activa y una de reserva, guardada fuera de línea. El manifiesto lleva `keyId`. Rotar es firmar con la de reserva y publicar una lista nueva firmada por la vieja y la nueva (subconjunto de TUF §5.3). Revocar una clave sí exige un release del cascarón, y se declara |
| H-07 | P1 | **E2**, Play *Device and Network Abuse*, ejemplo de violación [S3]: «containing a webview with added JavaScript Interface that loads untrusted web content (for example, http:// URL) or unverified URLs …»; **E1**: `grep -ci 'Content-Security' E01/src/Contenido/wwwroot/index.html` → `0`; E01 `ServidorDeContenido.cs` l.118–122: lo que no está en `current/` «sigue al comportamiento por defecto»; OWASP MASVS-PLATFORM-2 «The app uses WebViews securely» [S5] | La firma protege los bytes del paquete, pero nada impide que un paquete firmado cargue un `<script src="https://…">` o navegue a un origen externo con el puente expuesto. El contenido no tiene CSP y la navegación no está acotada `[interp]` | Código **sin firma** con acceso al puente: anula la integridad del canal y es la violación que Play pone de ejemplo | Tres controles en el cascarón y en el contenido: (1) CSP en el `index.html` del contenido, partiendo de la recomendada para Blazor cliente: `default-src 'self'; script-src 'self' 'wasm-unsafe-eval'; connect-src` acotado a la API propia; `object-src 'none'` [S8]. (2) El cascarón sirve sólo el origen local y bloquea la navegación a otros orígenes. (3) El puente atiende sólo llamadas del origen local. Una prueba de N4 provoca la carga de un script externo y la ve fallar |
| H-08 | P2 | **E2**, E01 `Platforms/Android/AndroidManifest.xml` l.2: `android:usesCleartextTraffic="true"`; `Cascaron.csproj` l.35: servidor por defecto `http://10.0.2.2:8099`; E01 `INFORME.md` l.245 (C-5: el sha256 «sólo detecta corrupción si el manifiesto es confiable») | El ensayo que sirve de base baja el manifiesto **por HTTP y sin firma**. Si la demo hereda esa configuración, el hash no protege nada `[enum]` | Pérdida acotada: el ensayo lo declara. El riesgo está en que la demo lo copie | La demo prohíbe el tráfico en claro (sin `usesCleartextTraffic`, o una *network security config* que lo niegue) y exige HTTPS **y** firma. Es MASVS-NETWORK-1 [S5]. El túnel `trycloudflare` de E01 (INFORME l.105) no entra en la guía como receta |
| H-09 | P2 | **E2**, Framework-APP.md l.300: módulos del puente «`auth`, … `db`, `storage`»; N2 §6.1–§6.2 (l.435–467): no dice qué secreto puede cruzar el puente. **E1**: `grep -n -i 'auth\.\|token' N2-…md` no devuelve ninguna regla sobre qué recibe el contenido | El contenido OTA es la superficie que cambia sin revisión de tienda. El diseño no fija que el **refresh token** quede siempre en el cascarón `[interp]` | Si el módulo `auth` entrega tokens al JS, un contenido defectuoso o un XSS los saca del proceso, y se pierde lo que da el desbloqueo con Keystore/Keychain | El contrato del puente declara: el refresh token **nunca** cruza el puente. El contenido llama a la API por el cascarón (que agrega el token, borrador l.238) o recibe, a lo sumo, un access token corto. MASVS-STORAGE-1 y MASVS-AUTH-2 [S5] |
| H-10 | P2 | **E2**, App Review Guidelines 2.1(a) [S1]: «include demo account info (and turn on your back-end service!) if your app includes a login»; 5.1.1(v): «If your app supports account creation, you must also offer account deletion within the app»; Google Play: «provide users with an in-app path to delete their app accounts … provide a web link resource …» [S10]; contra N2 §6.2 y §6.5 (login OIDC + Keycloak, sin estos puntos) | El modelo de entrada no prevé lo que las tiendas exigen a toda app con login: cuenta de prueba para la revisión y, si la app crea cuentas, borrado de cuenta dentro de la app y por la web `[interp]` | Un rechazo en revisión de cada tienda, con retrabajo acotado | La guía, en la sección de entrada del usuario, lista lo que piden las tiendas: cuenta de demostración para la revisión. Si la cuenta se crea **dentro** de la app, también el borrado dentro de la app y el enlace web. Si la cuenta la crea el proveedor de identidad fuera de la app, se declara así |
| H-11 | P1 | **E2**, folio 003 l.88: «Sin observar: iOS (no hay Mac ni runner macOS medidos)»; E01 `INFORME.md` l.246 (C-6: iOS sólo intercepta esquemas propios) y l.263; N1 l.607–608 (dos NO VERIFICADO de Apple); App Review Guidelines 4.7.2 [S1]: «Your app may not extend or expose native platform APIs or technologies to the software without prior permission from Apple.» | En iOS no hay nada verificado: ni el mecanismo (otro esquema y otro origen), ni el CSP con `wasm-unsafe-eval` en `WKWebView`, ni la lectura de Apple sobre `.wasm` (2.5.2, DPLA §3.3.1 B) y sobre el puente (4.7.2) `[interp]` | Una guía que trate iOS como «igual que Android» se rompe en lecturas divergentes, y la conformidad con Apple se descubre en la revisión | iOS sale en la guía y en la decisión como **diseño sin ensayo**, con sus tres riesgos nombrados (2.5.2/§3.3.1 B por `.wasm`, 4.7.2 por el puente, 4.2.3(ii) por la semilla). No se afirma conformidad. Ver P9 |
| H-12 | P3 | **E2**, Release-Y-Despliegue inv. 3 (l.119) y §5.1: campo `canal: "oficial \| desconocido"`, que pone el flujo; Framework-APP.md l.132 (manifiesto **en el servidor**); T-5 de R4 l.480 | En un paquete descargado, un `canal: oficial` escrito dentro del artefacto no prueba nada: cualquiera escribe ese campo. Lo que prueba el origen es la firma del índice del canal que lista el hash del paquete `[interp]` | Claridad: el lector de la guía puede creer que el campo es un control | La guía dice que el manifiesto interno es **información**, cubierto por el hash del índice firmado, y que «oficial» lo decide la verificación de firma. Detalle en §3, P2 (T-5) |

## 3. Respuesta a las preguntas del caso que me tocan

### P1 (D-01): modelo de contenido, mirado desde seguridad y tiendas

**Alternativas consideradas:** A (Blazor WASM en `HybridWebView`), A′ (SPA JS en WebView), B (UI por datos), C (A+B).

**Cadena de consecuencias (§2):**

| Paso | A | A′ | B |
| --- | --- | --- | --- |
| ¿Dónde cae el costo? | En la revisión de Apple (`.wasm` no nombrado) y en el puente (4.7.2) | En el puente (4.7.2) | En el cascarón: toda lógica nueva va por tienda |
| ¿Cuánto pesa? | Android: **medido** que funciona (E01, g42), y la excepción de Play nombra «code that runs in a virtual machine or an interpreter» [S3]. iOS: **sin medir**; sólo se mediría con un envío a App Review, que exige cuenta de Apple Developer. La pregunta va al PO (§5) | iOS: sin medir; es el caso que cita la industria (Expo/Capawesome, N1 [F7][F9], dicho por los proveedores) | Riesgo de política mínimo: baja datos. Pero los datos que dirigen la UI **también** son entrada no confiable y van firmados igual (MASVS-CODE-4 [S5]) |
| ¿Qué pierde la alternativa? | Elegir B pierde la actualización de comportamiento, que es el centro del pedido (evidencia 001, l.21) | Elegir A′ pierde Razor en el contenido (evidencia 001, l.15) | Elegir A gana expresividad y paga la incógnita de Apple |
| ¿Es reversible? | El canal firmado es **el mismo** para A, A′ y B: cambiar de modelo de contenido no toca la seguridad del canal. Pasar de A a B cuesta reescribir pantallas, pero no deja nada en los teléfonos que no se pueda reemplazar con una actualización | Ídem | Ídem |

**Propuesta (sin «depende»).** Desde seguridad y tiendas **no hay motivo para descartar A**. En Android queda
soportada por la letra de Play [S3] y por E01. La seguridad del canal no depende de la elección (H-04 a H-07 valen
para las tres). A se adopta con cuatro condiciones de mi competencia:

1. Contenido firmado y servido sólo desde el origen local, con CSP (H-07).
2. Ninguna API nativa nueva aparece por OTA. El puente expone sólo lo que el cascarón declara, que es la regla R2 de
   N1 y la prudencia ante 4.7.2 [S1].
3. OTA dentro del propósito declarado; una función nueva de peso también por tienda (2.5.2 y DPLA §3.3.1 C, N1 l.98–102).
4. Sin AOT en el contenido (N1 R4).

**iOS queda como diseño sin ensayo** (H-11).

**Cierre de los NO VERIFICADO de N1 en mi competencia** (búsqueda del 2026-10-25 [S11] y textos descargados [S1]):

| Ítem de N1 §10 | Resultado |
| --- | --- |
| Si Apple trata `.wasm` como «interpreted code» | **Sigue NO VERIFICADO.** Confirmado: las guías vigentes («Last Updated: October 16, 2026», [S1]) no nombran WebAssembly, y la búsqueda no encontró ningún pronunciamiento de Apple, sólo hilos de foro sin resolución [S11] |
| Si 4.7.2 alcanza a contenido propio | **Sigue NO VERIFICADO.** El texto de 4.7 habla de «software that is not embedded in the binary, specifically HTML5 and JavaScript mini apps and mini games, streaming games, chatbots, and plug-ins» [S1]; no aclara si incluye la interfaz propia |
| Biblioteca Ed25519 en MAUI 10 Android/iOS | **Cerrado para Android** (E1, E-SEG-1, C09–C11: `BouncyCastle.Cryptography` 2.6.2 verifica y rechaza en el g42). **iOS sigue NO VERIFICADO** |
| Ed25519 de serie en .NET 10 | **Confirmado ausente** en el runtime de Android (E-SEG-1: «Ed25519 nativo .NET: ausente»); la página oficial de criptografía multiplataforma no lo lista [S7] |

### P2 (D-02): canal de actualización

**Alternativas consideradas.** (a) Servidor estático con un índice de canal firmado (el subconjunto de TUF que
propone N1). (b) TUF completo (root/targets/snapshot/timestamp). (c) Sigstore o firma sin clave verificada en el
teléfono. (d) Sólo HTTPS + sha256 (lo que hace E01).

**Cadena de consecuencias:**

| Paso | (a) estático + índice firmado | (b) TUF completo | (c) Sigstore en el teléfono | (d) HTTPS + sha256 |
| --- | --- | --- | --- | --- |
| Dónde cae | Pipeline: un paso de firma; cascarón: verificar y aplicar las reglas | Pipeline y cliente: cuatro roles, umbrales, una biblioteca TUF para .NET móvil (NO VERIFICADO que exista una apta para MAUI) | Arranque del teléfono: necesita red y a Fulcio/Rekor (N1 l.357–359) | En la red y el servidor: quien los controla controla la app (Framework-APP.md l.380) |
| Cuánto pesa | **Medido**: verificar cuesta 2–8 ms en el g42 después del primer uso, 361 ms en el primero (E-SEG-1) | Sin medir | Choca con el arranque sin red: incompatible con la semilla y con el uso offline | Cero, y no protege nada contra un servidor comprometido |
| Qué pierde | Umbrales y separación de roles: lo compensan el conjunto de claves (H-06) y la custodia (H-05) | Simplicidad para una guía de principiantes | Arranque sin red | Integridad frente al servidor |
| Reversible | Sí: `alg` y `keyId` en el manifiesto permiten pasar a (b) o a otro algoritmo sin romper cascarones viejos que conocen la clave | Más caro de deshacer | — | — |

**Propuesta.** El canal es **(a)**, con estas piezas:

| Pieza | Decisión | Fundamento |
| --- | --- | --- |
| Servidor | Estático (D-02 = estático, como se inclina el borrador), un índice `manifest.json` por canal | Borrador l.144; N1 §6 |
| Qué se firma | El **índice del canal** (bytes tal cual), que lista cada archivo con `size` y `sha256`. No se firma el zip | TUF *targets* [S6]; Expo firma el manifiesto, no cada archivo (N1 l.379) |
| Algoritmo | **ECDSA P-256 con SHA-256**, de la plataforma, sin dependencias | Soportado en Android **e iOS** según Microsoft [S7]; **medido** en el g42 (E-SEG-1). Ed25519 queda como alternativa con dependencia: funciona en Android (E1) y en iOS no está verificado |
| Orden en el cliente | Firma → `expires` → monotonía → hash por archivo sobre lo descargado → descomprimir en `staging/` → activar | E-SEG-1 (11/11); Release-Y-Despliegue inv. 12 (l.148: verificar «sobre el descargado, antes de desempaquetar») |
| Anti-rollback | `version` estrictamente mayor que la instalada **en ese canal**; nunca rollback remoto | H-04; TUF §5.5 [S6]; Release inv. 2 |
| Anti-freeze | `expires` en el índice firmado. Vencido = **no se acepta contenido nuevo**, pero lo instalado sigue funcionando sin red | TUF §5.5 paso 6 [S6]. Que lo vencido no bloquee lo instalado es criterio propio, por el uso sin red |
| Canales | `dev`/`beta`/`prod` como **índices distintos firmados**; el canal va dentro del índice y el cliente rechaza un índice de otro canal | El mismo paquete se promueve sin recompilar (Release inv. 1) |
| Staging y activación | Staging → verificación → cambio atómico `current`/`previous` (E01, medido) | E01 §6.2 |
| Rollback local | Sólo a `previous`, que ya se había verificado, cuando falta el «arranqué bien». La versión mala queda bloqueada | H-04 |
| Retención | Servidor: N ≥ 3 artefactos (Release inv. 10). Teléfono: `current` + `previous` (T-2 de R4; es tema del arquitecto, no lo juzgo) | Release l.142 |
| Claves | Conjunto embebido (activa y de reserva fuera de línea) con `keyId`; firma en un job con *environment* protegido; la clave de la demo, rotulada | H-05, H-06; GitHub [S9] |
| Transporte | Sólo HTTPS; sin tráfico en claro | H-08; MASVS-NETWORK-1 [S5] |
| Actualización forzada del cascarón | `minShellVersion` (con techo, T-1) → pantalla «actualizá desde la tienda»; en Android, In-App Updates | MASVS-CODE-2 «The app has a mechanism for enforcing app updates» [S5]; N1 l.156–157 |

**T-5, compartida con el arquitecto (vista de seguridad).** Las dos piezas no compiten. El **índice del canal**
(servidor) es lo que se firma y lo que decide la confianza. El **manifiesto mecánico** (Release inv. 3, adentro del
artefacto) viaja dentro del paquete y queda cubierto por el hash que lista el índice firmado. Su campo `canal`
informa, pero no controla (H-12). No hace falta una segunda firma.

### P4 (D-03, D-07): entrada del usuario, y qué entra en la demo

**Alternativas para D-03 (teléfono sin bloqueo):** T1, no ofrecer desbloqueo local; T2, guardar el refresh token
sin atarlo a la autenticación; T3, un PIN propio de la app (las tres de N2 §5.3).

**Cadena de consecuencias:**

| Paso | T1 | T2 | T3 |
| --- | --- | --- | --- |
| Dónde cae | En la persona: login con cuenta en cada arranque | En la cuenta: cualquiera que tome el teléfono entra | En el código: un secreto propio que hay que proteger contra fuerza bruta |
| Cuánto pesa | Lo impone la plataforma. Android: «The key can only be generated if secure lock screen is set up» [S12]; en iOS, N2 lo cita (C para mí: no abrí la fuente) | Pierde lo que da el modelo del borrador (l.155: «la biometría … es la llave que abre el secreto») | Sin medir |
| Qué pierde | La comodidad, en teléfonos sin bloqueo | La protección del token | Simplicidad. Además rodea lo que la plataforma ya resuelve |
| Reversible | Sí: ofrecerlo cuando el usuario configura un bloqueo | — | — |

**Propuesta: D-03 → T1** (coincide con N2 §6.2; mi verificación propia es [S12] en Android). El resto de la entrada,
desde mi competencia:

- **Login con cuenta:** OIDC con *authorization code* + PKCE en el navegador externo (RFC 8252 §5 y RFC 9700 §2.1.1,
  citados por N2; C para mí). No hay formulario propio de usuario y clave.
- **Desbloqueo local:** clave en Keystore con `setUserAuthenticationParameters`, que existe «Added in API level 30»
  [S12]. En iOS, Keychain con `userPresence` (N2).
- **El refresh token nunca cruza el puente** (H-09).
- **Biometría por rostro en iOS:** sólo con LocalAuthentication, como pide la guía 2.5.13 [S1].
- **Lo que piden las tiendas a toda app con login:** H-10.
- **D-07 (proveedor):** cualquier *issuer* OIDC. Desde seguridad no hay motivo para preferir uno.
- **La demo:** login OIDC contra un Keycloak en contenedor y desbloqueo con Keystore en el g42 (API 33 ≥ 30). iOS
  sólo en la guía, como diseño. Antes de prometerlo, la demo tiene que **medir** en el g42 la reescritura del token
  rotado (ensayo E-N2-1 de N2, sin correr).
- **Android mínimo:** el caso base declara API 23 (N2 l.511–512). Para tener caída a PIN o patrón con una sola
  clave, el desbloqueo local exige API 30. Propongo que en API < 30 el desbloqueo local **no se ofrezca** (T1
  extendido), en vez de subir el mínimo de la app. Es reversible, y el costo cae sólo en esos equipos.

### P9 (D-06): dónde se compila y firma iOS, y qué queda verificado

**Alternativas:** las de N3 §5.5: A, `macos-latest` de GitHub; B, una Mac propia como runner; C, postergar la
ejecución de iOS.

**Cadena de consecuencias (seguridad y tiendas):**

| Paso | A | B | C |
| --- | --- | --- | --- |
| Dónde cae | Certificado y perfil de Apple como secretos de un *environment* protegido en un runner efímero hospedado [S9] | Una máquina propia con secretos, en un repo público. N3 lo desaconseja para runners autoalojados (N3 l.355) | En la guía: iOS queda declarado sin verificar |
| Cuánto pesa | Sin medir: exige una cuenta de Apple Developer que no existe en el despacho (folio 003, l.88) | Sin medir; no hay hardware | Cero en el pipeline. El riesgo de rechazo de Apple sigue sin conocerse |
| Qué pierde | — | — | La verificación de iOS antes de fusionar (R4 T-7) |
| Reversible | Sí | Cara (hardware) | Sí: pasar a A cuando exista la cuenta |

**Propuesta: C ahora, A como camino declarado.** La condición para revisarla es comprobable: «existe una cuenta de
Apple Developer con su custodia asentada». Sea cual sea el camino, rigen dos separaciones:

- La **clave de firma del contenido** (H-05) y el **certificado de Apple** son secretos distintos, con custodios
  distintos.
- La conformidad con Apple (2.5.2, DPLA §3.3.1 B, 4.7.2, 4.2.3(ii)) **sólo** se verifica en una revisión real. Un
  primer build de TestFlight para un grupo pasa por revisión: «When you add the first build of your app to a group,
  the build gets sent to App Review … A review is required only for the first build» [S13].

**Qué queda verificado y qué no, en iOS:** nada verificado. NO VERIFICADO: mecanismo de servido (esquema propio),
CSP en `WKWebView`, ECDSA en iOS (soportado según [S7], no ensayado), Ed25519 con BouncyCastle, Keychain
`userPresence`, la lectura de Apple sobre `.wasm` y sobre el puente.

## 4. Lo que revisé y está bien

1. **Separar cascarón y contenido** (Framework-APP.md l.43–48) es lo que hacen las dos tiendas al pie de la letra:
   Apple prohíbe bajar «executable code» y permite código interpretado con condiciones (DPLA §3.3.1 B, N1 l.91–96,
   verificado palabra por palabra), y Play prohíbe dex/JAR/.so [S3]. Que `BlazorWebView` no sea descargable
   (N1 l.237–239) obliga a esa separación.
2. **Activación atómica con staging**: verificar antes de descomprimir y activar con un renombre. E01 la midió en el
   g42 (corrida 4: el hash adulterado deja v2 activa), y coincide con Release-Y-Despliegue inv. 12.
3. **«HTTPS solo no alcanza»** (Framework-APP.md l.137) y la firma con clave pública embebida: E-SEG-1 muestra que
   la plataforma Android la verifica en milisegundos y rechaza las cuatro alteraciones.

## 5. Solicitudes de convocatoria (fuera de mi competencia)

| Señal | Ubicación | A quién |
| --- | --- | --- |
| El procedimiento de PR no prevé el paso de firma del contenido (un job con *environment* y revisor obligatorio, separado de los jobs en `i7infra-dev`). La compuerta de N3 tendría que exigir «no se publica un índice sin firma» | N3 l.355 y §8 (l.412); N1 l.503 | DevOps / integración y pruebas |
| Retención en el teléfono N = 2 frente a la convención N ≥ 3 (T-2) | Framework-APP.md l.138; R4 l.477 | Arquitecto |
| La prueba de N4 que provoca un script externo y la ve fallar (H-07), y los casos C02–C08 de E-SEG-1 como suite del actualizador | N1 l.504 (casos de N4) | Integración y pruebas |
| **Choque de `applicationId` entre sesiones en el g42**: otra sesión instaló `com.frameworkconcept.seguridad01` a las 17:29:21 sobre el nombre que yo había usado. Hace falta un registro de nombres de paquete por rol | g42, `dumpsys package com.frameworkconcept.seguridad01` | Presidencia (medios y teléfono) |
| Pregunta de una línea para quien tenga la llave: «¿hay cuenta de Apple Developer para el laboratorio, y quién custodia certificados y perfiles?». Sin ella, P9 queda en C | N3 l.402; folio 003 l.88 | Al PO, por la presidencia |

## 6. Fichas de excepción

Ninguna. No propongo dejar de seguir ninguna convención que rige. Lo que propongo para el canal cumple
Release-Y-Despliegue inv. 2, 3, 10, 12 y 15, y lo refuerza: la firma va además del resumen del inv. 12.

## Fuentes

Consultadas el 2026-10-25.

| Id | Fuente |
| --- | --- |
| S1 | Apple. *App Review Guidelines* (2.1, 2.5.2, 2.5.6, 2.5.13, 2.5.19, 4.2, 4.2.3, 4.7, 4.7.2, 5.1.1). «Last Updated: October 16, 2026». https://developer.apple.com/app-store/review/guidelines/ — `curl` → 240 818 bytes, sha256 `ce0a7056…f996eb` |
| S2 | Apple. *Apple Developer Program License Agreement* §3.3.1 B y C. https://developer.apple.com/support/terms/apple-developer-program-license-agreement/ — texto tomado de N1 (verificado palabra por palabra en N1 §11.3; para mí, C confirmado por esa verificación) |
| S3 | Google. *Device and Network Abuse*. Play Console Help. https://support.google.com/googleplay/android-developer/answer/9888379?hl=en — `curl` → 1 658 640 bytes, sha256 `4e026cd6…ff996eb`… (archivo `play.html` del scratchpad) |
| S5 | OWASP. *MASVS* controles MASVS-CODE-1, CODE-2, CODE-4, PLATFORM-2, AUTH-2, STORAGE-1, NETWORK-1, RESILIENCE-2. https://mas.owasp.org/MASVS/controls/ (enunciados leídos de cada página; versión del MASVS NO VERIFICADO: la página no la muestra en el texto leído) |
| S6 | The Update Framework. *Specification* 1.0.37 (última modificación 2026-10-08), §5.3 «Update the root role», §5.5 pasos 5 y 6. https://theupdateframework.github.io/specification/latest/ |
| S7 | Microsoft. *Cross-platform cryptography* (ms.date 2026-08-03): ECDSA NIST P-256 ✔️ en iOS, tvOS, MacCatalyst y Android; Ed25519 no figura. https://learn.microsoft.com/en-us/dotnet/standard/security/cross-platform-cryptography |
| S8 | Microsoft. *Enforce a Content Security Policy for ASP.NET Core Blazor* (ms.date 2026-08-18): `wasm-unsafe-eval` «to permit the client-side Blazor Mono runtime to function». https://learn.microsoft.com/en-us/aspnet/core/blazor/security/content-security-policy?view=aspnetcore-10.0 |
| S9 | GitHub. *Deployments and environments*. https://docs.github.com/en/actions/reference/workflows-and-actions/deployments-and-environments — citas de revisores obligatorios y de la disponibilidad en Free. NO VERIFICADO: la disponibilidad de *required reviewers* por plan |
| S10 | Google. *Understanding Google Play's app account deletion requirements*. https://support.google.com/googleplay/android-developer/answer/13327111?hl=en |
| S11 | Búsqueda web «App Store review guideline 2.5.2 WebAssembly downloaded WKWebView» (2026-10-25): sin pronunciamiento de Apple; hilos de foro, p. ej. https://developer.apple.com/forums/thread/823129 y https://developer.apple.com/forums/thread/826166 |
| S12 | Android Developers. *KeyGenParameterSpec.Builder*: «The key can only be generated if secure lock screen is set up»; `setUserAuthenticationParameters` «Added in API level 30». https://developer.android.com/reference/android/security/keystore/KeyGenParameterSpec.Builder |
| S13 | Apple. *TestFlight overview*. App Store Connect Help. https://developer.apple.com/help/app-store-connect/test-a-beta-version/testflight-overview/ |

Sigue: incorporación del siguiente informe y resolución · presidencia
