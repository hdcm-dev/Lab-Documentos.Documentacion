| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-10-25 |
| Autor | Comisión en caliente Caso de referencia y capacidades |
| Corrige | — |

# Informe de comisión — Caso de referencia, actualización al iniciar sesión y capacidades del manifiesto

| Campo | Valor |
| --- | --- |
| Rol | Comisión ad hoc convocada en caliente: caso de referencia, actualización al iniciar sesión y capacidades del manifiesto (carta: evidencia 013) |
| Fecha | 2026-10-25 |
| Expediente | 0001-Framework-Concept-Maui-Autoactualizable |
| Clase de objeto | Diseño de una norma o decisión |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | Cabecera y §0 (l. 1–111), §2.2, §3.2, §3.3, §4; la carta (§5.2) |
| Documentos cargados con versión | Cadena-De-Consecuencias 2.0 (§2) · Escalas-De-Juicio 1.0 (§3.3) |
| Insumos leídos | Evidencia 001 (prompt, desde l. 4); folios 003, 004, 005 y 006 (este último por ampliación de la presidencia); Framework-APP.md (borrador, 382 l.); E01/INFORME.md; N1 §4.2–§6; N2 §4.2; R1 (encuesta) |
| Caso de referencia | «La app híbrida de referencia del PO»: repositorio privado, leído en sólo lectura en su HEAD local del 2026-10-23 (`4472ac7`) y por su base de conocimiento (README + índices 02 y 03). Las rutas se citan relativas al repositorio, con `<proyecto>/` en lugar del nombre de su único proyecto MAUI. Regla S2: no se asientan hosts, URL, claves, identificadores de paquete ni nombres de clientes |
| Medios | Lectura de código y documentación; consultas web a documentación oficial (fecha de consulta de todas: 2026-10-25). No se usó ningún dispositivo |
| Hallazgos | 11 (tope 12) |

**Convención de fuentes.** [Fn] es documentación externa (lista en §7). «E1 web» significa una consulta reproducible con WebFetch o `curl` a la URL indicada, con la salida citada. Todo lo que es criterio de la comisión dice **criterio propio**. Lo que no se pudo comprobar dice **NO VERIFICADO**.

---

## 1. Lectura del objetivo: lo que da por fijo sin origen

El OBJETIVO del folio 003 (l. 46–50) tiene origen en cada cláusula. El problema es lo que **le falta** y lo que **da por fijo** en los campos que lo rodean:

1. **La operación sin red no está en el objetivo.** El folio 004 (l. 32) dice que «la operación sin red ya estaba en el objeto», pero el objeto es el borrador (Framework-APP.md §1 ítem 7), que el mismo contrato declara «insumo e hipótesis a refutar». Desde el folio 005, quien pidió la fija como lo esperado: «el encuestador podria tomar las encuestas perfectamente sin internet y luego sincronizar». Con el objetivo como está, la opción D (sitio remoto) y el propio caso de referencia lo cumplen al pie de la letra y son los más simples. Es el hallazgo H-01.
2. **El «caso que funciona» del contrato no es el del mecanismo pedido.** El contrato (003 l. 37) nombra a MovilidadUrbana.MAUI, que «no tiene contenido actualizable ni Blazor». Para la actualización sin tienda, el caso que funciona es el que señaló el PO (folio 004, l. 25). Es el hallazgo H-02.
3. **«Blazor híbrido» figura como restricción dura** (003 l. 73). Leída con el término de Microsoft (BlazorWebView), vuelve imposible el objetivo, porque esos componentes no se descargan. Es el hallazgo H-03.

---

## 2. Hallazgos

| Id | Nivel | Ancla | Hallazgo | Impacto si no se corrige | Dirección de la corrección |
| --- | --- | --- | --- | --- | --- |
| H-01 | P1 | **E2** folio 003 l. 46–50 (OBJETIVO, sin cláusula sin red) frente a folio 005, testimonio: «el encuestador podria tomar las encuestas perfectamente sin internet y luego sincronizar con el servidor cuando consigue internet»; folio 004 l. 32: «La operación sin red ya estaba en el objeto» (el objeto es el borrador, hipótesis a refutar) | El objetivo no exige operar sin red. El único lugar donde figura es el borrador, que no es vinculante. Quien pidió ya lo dijo como lo esperado (folio 005) | El jurado puede puntuar D, o el patrón del caso de referencia, como «cumple y es lo más simple». Además, P5 se dictaminaría sin un criterio de aceptación del objetivo | Rehacer el enunciado (Mesa-De-Expertos-A-Pedido §2.1, paso 2) y sumar al objetivo la cláusula «operación completa sin red entre sesiones y sincronización al recuperarla [folio 005]», con su origen. La presidencia decide si eso obliga a relanzar algo |
| H-02 | P1 | **E2** folio 003 l. 37: «Caso que funciona: MovilidadUrbana.MAUI … No tiene contenido actualizable ni Blazor»; folio 004 l. 25: el PO «señala un caso que funciona» | El caso que funciona declarado en el contrato no ejerce el mecanismo en discusión. La tabla diferencial de §3.3 tiene que armarse contra la app de referencia del PO, que es la de este informe (§3.1) | Sin la tabla, la primera salida de §3.3 («igualar la columna que cambia») no se evalúa, y nadie deja escrito por qué la referencia no sirve tal cual | El contrato declara dos referencias, cada una con su alcance: base de la demo (MovilidadUrbana.MAUI) y caso que funciona para la actualización (la app de referencia del PO). El motivo para no igualarla queda anclado en E2 (§3.1: sin red cancela toda navegación) |
| H-03 | P1 | **E2** folio 003 l. 73: «.NET MAUI + Blazor híbrido» como restricción dura; E01 l. 48, cita oficial [D3 del E01]: «Razor components run natively on the device … WebAssembly isn't involved»; E01 l. 241: el mecanismo que funcionó es `HybridWebView`, no `BlazorWebView` | «Blazor híbrido» es un término de Microsoft con un significado preciso: componentes Razor compilados en el binario, que no se descargan. La opción A no es Blazor Hybrid sino Razor publicado como WASM y servido en `HybridWebView` | Lecturas divergentes. Un implementador o un lector de la guía puede descartar A por violar la restricción, o concluir que el objetivo es imposible | El contrato define el término así: Razor en el contenido actualizable (A: WASM; B/C: renderizador), y BlazorWebView sólo en las pantallas propias del cascarón. Va al glosario de la guía |
| H-04 | P1 | **E3**, contraejemplo sobre Framework-APP.md l. 136: «`obligatorio` (bloquea hasta actualizar)», y l. 113–117 (el flujo consulta el manifiesto antes de cargar). Fuentes: [F4] reload(): «The in-memory state of the app (e.g. unsaved user input) is lost»; [F3] `mandatoryInstallMode` por defecto `IMMEDIATE`: «install the update and restart the app immediately» | El contraejemplo: el encuestador tiene 12 encuestas sin sincronizar y está en la tercera pantalla de la número 13. Recupera una red débil. El manifiesto marca obligatoria una versión nueva y la descarga falla o tarda. El borrador no dice si bloquea, cuándo bloquea ni qué pasa con la encuesta en curso y las pendientes. Si se aplica como el `IMMEDIATE` de la industria, la entrada sin guardar se pierde | Encuestadores bloqueados en el campo, lo contrario del folio 005; o pérdida de respuestas a medio cargar; o cada implementador elige su semántica | Fijar la semántica de «obligatorio» del contenido: se activa en el **próximo punto seguro** (arranque en frío o fin de la tarea en curso) apenas está descargado y verificado. Nunca bloquea si no se pudo bajar. Nunca descarta pendientes (P13). Detalle en §4 |
| H-05 | P2 | **E1 web** [F3]: `isMandatory` («Indicates whether the update is considered mandatory») y `mandatoryInstallMode` en la API de CodePush; [F2]: «There is no first-class support for critical/mandatory updates in the `expo-updates` library … you can implement your own logic». Objeto: N1 l. 380: «`obligatorio` — No se encontró equivalente directo en las fuentes» | El dossier N1 afirma que no hay equivalente, pero la industria sí lo tiene. CodePush lo traía de primera clase, con modo de instalación propio, aunque el producto se retiró (N1 §4.4). Expo dice expresamente que no lo trae y que se implementa a mano | El jurado decide P2 creyendo que «obligatorio» es invento del borrador, sin precedente ni semántica de referencia | Corregir la fila de N1 §4.10 con las dos fuentes. Tomar de CodePush la separación «modo de instalación de lo opcional / de lo obligatorio» como forma del campo |
| H-06 | P2 | **E2** Framework-APP.md l. 113–125: arranque → ¿red? → bajar manifiesto → … → cargar; l. 141, espera de N segundos. **E2** E01 l. 203–205: «la espera del manifiesto (1,2 s en la corrida 2 …) … el manifiesto no debería bloquear el render». **E1 web** [F1]: `checkAutomatically` «ON_LOAD (default)», `fallbackToCacheTimeout` «Defaults to 0»; [F2]: «the end user will only load the update when they cold boot the app after an update has been published»; [F3] `installMode` de lo opcional: por defecto `ON_NEXT_RESTART` | El borrador pone la consulta del manifiesto en el camino crítico del arranque. El default de la industria es el contrario: se arranca con lo instalado, se consulta y descarga en paralelo, y se aplica en el próximo arranque en frío | Arranque más lento en cada apertura (en E01 se midió 1,2 s de espera sólo por el manifiesto), y peor sin red o con red débil, justo el caso del encuestador | Default «no bloquea»: arranca lo instalado, consulta y descarga en segundo plano, y activa en el próximo arranque en frío. La espera con tope (fallbackToCacheTimeout > 0) sólo para lo marcado obligatorio y sólo si hay red |
| H-07 | P1 | **E2** Framework-APP.md l. 150–153: «Primer ingreso: … su cuenta», «Ingresos siguientes: … autenticación del sistema», con renovación de sesión contra el servidor. **E2** folio 004, testimonio: «se actualizan internamente al iniciar un logueo nuevo». **E1 web** [F3] `CheckFrequency.MANUAL`: «only check when codePush.sync() is called in app code»; [F1] `checkAutomatically: NEVER`, más `checkForUpdateAsync` / `fetchUpdateAsync` / `reloadAsync` [F2] | «Al iniciar sesión» tiene dos lecturas en este diseño: el **login con cuenta** (siempre con red) y el **desbloqueo local** con la seguridad del teléfono (puede ser sin red). Entre las fuentes relevadas, ningún producto ofrece «al iniciar sesión» como modo con nombre: los productos traen «al arrancar», «al reanudar» y «manual», y «al login» se arma con el modo manual. Que «muchas aplicaciones» lo hagan es una afirmación sobre la industria que queda **NO VERIFICADA**: no se encontró fuente que la documente como patrón | Dos implementadores hacen dos cosas distintas: uno consulta en cada desbloqueo (y falla sin red), el otro sólo tras un login con cuenta | Modelar los momentos como **disparadores** de una misma rutina de consulta: arranque en frío (requisito del prompt), reanudación y login con cuenta exitoso. El login con cuenta se **suma** a «al abrir» y no lo reemplaza: el objetivo manda «al abrir» (folio 004 l. 32). El desbloqueo local no dispara nada que exija red |
| H-08 | P1 | **E2** caso de referencia: `<proyecto>/Services/Printing/BluetoothPermissions.cs:16-17` pide `BluetoothScan` y `BluetoothConnect`; `<proyecto>/Platforms/Android/AndroidManifest.xml` no los declara (`grep -c BLUETOOTH` → `0`), y su base de conocimiento dice que faltan en los 36 manifiestos de variante (índice 03 §9.2). **E1 web** [F10]: «if your app requests app permissions, you must declare these permissions in your app's manifest file»; [F15]: la app debe tener la clave en su Info.plist «before it requests authorization or attempts to use a capture device. Otherwise, the system terminates your app». **E2** Framework-APP.md l. 134: `minShellVersion` sólo «si la API del puente cambia» | Una actualización de contenido no puede sumar un permiso, una clave de uso ni un entitlement: los tres viven en el binario firmado [F10][F13][F16]. El borrador ata la compatibilidad sólo a la versión del puente, no a las capacidades. El caso de referencia muestra el riesgo en producción: un código que usa una capacidad que el manifiesto no declara | Un contenido nuevo que usa una capacidad ausente falla en el campo. En Android el permiso no se concede. En iOS, sin la clave de uso, el sistema termina la app [F15] | Catálogo de capacidades en el cascarón, y requisitos de capacidades en el manifiesto del paquete de contenido, validados por el actualizador antes de activar y por la CI antes de publicar. Diseño en §3.4 (P12) |
| H-09 | P1 | **E2** R1 l. 92–96: las reglas de la encuesta (pasos, edad, distancia, minutos) son constantes en `EncuestaRules.cs`; folio 005: «si la encuesta cambia o se arregla o actualiza, es simplemente una actualización interna»; P1 del contrato (003 l. 54) sólo pregunta por el modelo de contenido de las **pantallas** | En el escenario guía, lo que cambia seguido es la **definición** de la encuesta (preguntas, opciones, validaciones), no el código de las pantallas. P1, tal como está planteada, mezcla dos ejes: qué código se actualiza y qué datos de definición se actualizan | Si la definición viaja como código (A puro), cada corrección de la encuesta es un release del paquete WASM (zip de 3,39 MB, E01 l. 157). Además la versión de la encuesta queda atada a la del código, lo que complica P13 | El jurado evalúa P1 en dos ejes: (a) canal del código de pantallas (A, o ninguno), y (b) definición de la encuesta como datos versionados, con su propio id y versión, renderizada por pantallas genéricas. Precedente de la industria: ODK baja formularios como definiciones desde el servidor y trabaja sin red [F19][F20] |
| H-10 | P1 | **E3**, contraejemplo sobre Framework-APP.md l. 281: la tabla `Outbox` (id, acción, payload, clave de idempotencia…) no guarda la versión de la definición; l. 291: las migraciones las corre el cascarón. Las providencias tampoco responden P13 (folio 005 l. 27) | El contraejemplo: una respuesta tomada con la versión 3 de la encuesta (campo «Motivo» obligatorio) queda pendiente. Llega la versión 4, que quita «Motivo» y agrega «Costo». Al sincronizar, si el servidor valida contra la vigente rechaza la respuesta, o pierde datos en silencio | Respuestas pendientes rechazadas o corrompidas después de una actualización, el peor caso del escenario del folio 005 | Cada respuesta lleva `{encuestaId, versionDefinicion}`. El cliente conserva las definiciones que tengan respuestas pendientes. El servidor acepta las versiones publicadas no retiradas. Ninguna actualización, tampoco una obligatoria, descarta pendientes. Detalle en §3.5 (P13) |
| H-11 | P2 | **E2** Framework-APP.md l. 331: «Android por APK/Play interno»; l. 142: «Android puede usar la API In-App Updates de Play». **E1 web** [F8]: Play Core es «your app's runtime interface with the Google Play Store»; [F9] remite los requisitos de instalación a otra página | El flujo inmediato de Play [F8] supone que la app se actualiza desde Play. Para un APK distribuido por fuera de Play, el forzado del cascarón queda **NO VERIFICADO**: la página consultada no dice expresamente que haga falta instalar desde Play | La pantalla «actualizá el cascarón» no funciona en la distribución por APK que el mismo borrador prevé | La pantalla de cascarón obsoleto tiene una salida independiente de Play Core: un enlace a la ficha de la tienda, o a la descarga del APK en la distribución interna. In-App Updates se usa sólo cuando está disponible |

---

## 3. Respuesta a las preguntas del caso

### 3.1 Caso de referencia y tabla diferencial (P1, P2)

**Qué es el contenido del caso de referencia.** Es una app MAUI con un único `WebView` nativo: no usa BlazorWebView ni HybridWebView (`<proyecto>/Pages/MainPage.xaml:27`). Al abrir, carga un **portal remoto en vivo**: `Navegador.Source = Config.urlLogin` o la última URL visitada (`<proyecto>/Services/UrlManagerService.cs:31-48`). La URL de entrada lleva concatenada la versión de la app (`<proyecto>/Config.cs:18-22`, uso en `:38`). El portal pide funciones nativas navegando a URL con marcadores, y la app las intercepta (índice 02 §1 de su base de conocimiento).

**Cómo se actualiza hoy.** El contenido se actualiza cambiando el servidor web. No hay paquete, manifiesto, versión de contenido ni caché propia: `grep` de `CacheMode|LOAD_CACHE|serviceWorker` sólo encuentra un script de protección cuya única llamada está comentada (índice 02 §10.2). El cascarón se actualiza por tienda. **No hay forzado de actualización**: `grep -iE 'itms-apps|apps\.apple\.com|market://|play\.google|InAppUpdate|AppUpdateManager|VersionTracking|minVersion|ForceUpdate'` sobre el proyecto → sin coincidencias. Lo único que hay es que la app informa su versión al servidor en la URL de login (`Config.cs:38`; `Services/RetornoDeLogin.cs:20`). Si el portal la usa para bloquear versiones viejas queda **NO VERIFICADO**: el portal no es parte de este repositorio.

**Qué hace sin red.** Cada navegación sin `NetworkAccess.Internet` se cancela y se muestra el overlay «DESCONEXION» (`<proyecto>/Services/ConnectionManagerService.cs:25-33`, llamado en `Pages/MainPage.xaml.cs:125`). El refresco sin red hace lo mismo (índice 02 §11). No hay base local (`grep -i sqlite` en el `.csproj` → sin coincidencias). Sin red, la app no opera.

**Permisos.** Se declaran en el manifiesto Android: ubicación, cámara, micrófono, llamada, notificaciones, más `<uses-feature required="false">` y `<queries>` para `DIAL tel` e `IMAGE_CAPTURE` (`Platforms/Android/AndroidManifest.xml:19-46`, `:32-38`, `:54-62`). En iOS se declaran claves `NS*UsageDescription` y `UIBackgroundModes` `fetch`/`remote-notification` (`Platforms/iOS/Info.plist:62-79`), y entitlements en `Entitlements*.plist`. Se piden en tiempo de ejecución, en contexto, con Check → Request → rationale y salida a ajustes (`Services/LocationPermissionService.cs:11-34`; `Services/Devices/CameraCustomDevice.cs:89`; `Services/Pages/MyMediaPickerPage.xaml.cs:112`), que es el flujo oficial [F11]. **El catálogo de lo que el portal puede pedir está congelado en el binario**: es la lista cerrada de URL-comandos (índice 02 §2). El portal sólo usa lo que el cascarón ya sabe hacer, y eso es, sin nombre, el catálogo de capacidades de P12.

**Tabla diferencial** (§3.3 de la norma). Una fila por camino y una columna por cada cosa que pasa entre «hay contenido nuevo» y «el usuario lo ve». Escenario guía: corregir la encuesta (folio 005). ⟵ marca **la columna que cambia**.

| Camino | 1. Qué se publica | 2. Dónde vive lo que se ejecuta ⟵ | 3. Cuándo se entera el cliente | 4. Verificación | 5. Cuándo se activa | 6. Arranque sin red | 7. Tomar encuestas sin red | 8. Forzado | 9. Capacidad nueva |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| **R** · app de referencia del PO | El sitio, en su servidor (índice 02 §1) | **Remoto**: el WebView navega al portal (`UrlManagerService.cs:31-48`) | En cada navegación (no hay versión de contenido) | TLS del sitio; nada propio (sin manifiesto: E1 `grep`, §3.1) | Inmediato, en la próxima carga de página | Overlay «DESCONEXION» (`ConnectionManagerService.cs:25-33`) | **No**: se cancela toda navegación (ídem) | Contenido: siempre el vigente cuando hay red. Cascarón: no hay (E1 `grep` sin coincidencias); la versión viaja al servidor (`Config.cs:38`) | Sólo por tienda: catálogo cerrado de URL-comandos (índice 02 §2) |
| **A** · E01 (WASM en HybridWebView) | Paquete zip + `manifest.json` (E01 l. 82, 86) | **Local**: `content/current/` servido por `WebResourceRequested` (E01 l. 83) | Al arrancar, antes de crear el WebView (E01 l. 81) | sha256 del manifiesto; un hash adulterado se rechaza y sigue la versión anterior (E01 l. 174). Firma: no ensayada (E01 l. 245) | En el mismo arranque, bloqueando (E01 l. 171–173, 203–205) | Usa lo instalado si el manifiesto falla: **NO VERIFICADO**, no se cortó la red (E01 l. 267) | Posible por diseño (contenido local); **sin medir** | No ensayado (E01 l. 89–90) | Sólo por tienda (H-08); `minShellVersion` no ensayado (E01 l. 90) |
| **D** · borrador, sitio remoto | El sitio | **Remoto** (Framework-APP.md l. 101) | Como R | Como R | Como R | «sin red no hay app» (l. 101) | No (l. 101) | Como R | Como R; además, riesgo 4.2 de Apple (N1 §4.3) |
| **A-login** · A actualizada al iniciar sesión | Como A | **Local**, como A | Arranque en frío y login con cuenta exitoso (H-07). Diseño, **sin medir** | Como A, más firma (C-5 de E01) | Próximo arranque en frío o punto seguro (H-04, H-06). **C**, sin medir | Arranca lo instalado sin esperar (diseño; [F1] `fallbackToCacheTimeout` 0) | Sí, por diseño; **sin medir** | Contenido: por manifiesto, en punto seguro (§4). Cascarón: §4 | Como A, con requisitos de capacidades (§3.4) |
| *B · definición de encuesta como datos* (**agregado** de la comisión, marcado para quien pidió) | Definición JSON de la encuesta, con id y versión | **Local**: definición en SQLite; renderizador en el contenido o en el cascarón | Igual que A-login | Firma de la definición (criterio propio) | Al terminar la encuesta en curso, o en el próximo arranque | Sí | Sí, el patrón de ODK Collect [F20] | Igual que A-login | Igual que A |

**Columna que cambia: la 2, dónde vive lo que se ejecuta.** R y D ejecutan contenido remoto. A, A-login y B ejecutan contenido local. Las columnas 6 y 7, sin red, son consecuencia directa de la 2.

**Primera salida de §3.3: igualar la columna 2 a la del caso que funciona (remoto).** **No sirve**, y el motivo queda en E2: con contenido remoto, la referencia cancela toda navegación sin red (`ConnectionManagerService.cs:25-33`), y eso contradice el folio 005. Lo que sí se iguala de la referencia: (a) el **momento**, «el usuario ve lo nuevo sin hacer nada»; (b) el **catálogo cerrado de capacidades** en el cascarón, pedidas en contexto con rationale y salida a ajustes, y (c) el envío de la versión del cliente al servidor (`Config.cs:38`), que en A-login pasa a ser el insumo del forzado del cascarón (§4b).

**Historia.** El `git log -S` que pide §3.3 se aplica a invariantes de un caso que funciona. Acá la columna 2 no se trata como invariante: se descarta por E2 con la cita de arriba. No hace falta.

### 3.2 P1 — modelo de contenido actualizable (en lo que toca a esta comisión)

| Alternativa | Dónde cae el costo | Cuánto pesa | Qué pierde | Reversibilidad |
| --- | --- | --- | --- | --- |
| **D / patrón de la referencia** (remoto) | En el usuario sin red | Operación sin red nula, por E2 (§3.1) | El requisito del folio 005 | Alta en código, pero no cumple |
| **A pura** (todo, definición incluida, como código WASM) | En el canal y en P13 | 3,39 MB por release (E01 l. 157); primer render ~2,1 s después de iniciado el WebView (E01 l. 249) | La versión de la encuesta queda atada a la del código (H-09) | Media |
| **A + definición como datos** (C en su forma mínima) | En diseñar un esquema de encuesta y su renderizador | **Sin medir**. Una definición JSON pesa KB (criterio propio, sin medir) | Un modelo más que A pura | Alta: la definición puede volver a código |
| **B** (sólo datos, renderizador en el cascarón) | En la expresividad: «Lógica nueva = release del cascarón» (Framework-APP.md l. 95) | Sin medir | Cambios de pantalla sin tienda | Media |

**Propuesta (no es la elección, que hace el jurado):** evaluar P1 en los dos ejes de H-09. Para el escenario guía, la definición de la encuesta viaja **como datos versionados**, que es la práctica establecida de recolección sin red: ODK «downloads blank forms from and submits filled forms to a server» y «is designed to work well offline» [F20]. El código de pantallas viaja por A si el jurado la elige. La opción reversible y barata es la definición como datos: un esquema se puede abandonar, mientras que A ata la versión de la encuesta a cada release del paquete.

### 3.3 P2 — momento de actualización y operación sin red entre sesiones

**Lo que hace la industria (cada fila, con su fuente):**

| Producto / estándar | Cuándo consulta | Cuándo aplica | Obligatorio | Fuente |
| --- | --- | --- | --- | --- |
| Expo EAS Update | `checkAutomatically` «ON_LOAD (default)»; también `ON_ERROR_RECOVERY`, `WIFI_ONLY`, `NEVER` | «any update downloaded during the check will be applied upon the next app launch» si tarda más que `fallbackToCacheTimeout` («Defaults to 0») | «There is no first-class support for critical/mandatory updates»; se arma con `checkForUpdateAsync` / `fetchUpdateAsync` / `reloadAsync` | [F1][F2] |
| CodePush (retirado, N1 §4.4) | `ON_APP_START` (default), `ON_APP_RESUME`, `MANUAL` | Lo opcional, `ON_NEXT_RESTART` por defecto; también `ON_NEXT_RESUME` y `ON_NEXT_SUSPEND` | `isMandatory`; `mandatoryInstallMode` por defecto `IMMEDIATE` | [F3] |
| Capawesome Live Update (Capacitor) | Con `background`: «at app startup and when the app resumes» | Con `reload()`; advierte que se pierde el estado en memoria | No hay forzado documentado en la página | [F4] |
| Ionic Appflow Deploy | `updateMethod` (`background`, `auto`, `none`) | «Whether the update should be applied immediately or on the next app start» | — | [F5] |
| Service worker (PWA) | Al navegar | El worker nuevo «delays activating until the existing service worker is no longer controlling clients»; `skipWaiting()` lo adelanta | — | [F6], Jake Archibald |
| Offline-first en Android | — | La fuente local es «the canonical source of truth»; escrituras perezosas: «Write to the local data source first, then queue the write» | — | [F7] |
| ODK (recolección sin red) | Collect puede configurarse para «exactly match the forms provided by the server» | La edición de un envío usa «the version of the form that was active when the form was originally filled» | — | [F21] |

**Patrón común (criterio propio, cada pieza con su fuente).** Se consulta al arrancar o al reanudar. Se aplica en el próximo arranque o cuando no hay clientes activos, sin interrumpir [F1][F3][F6]. Lo obligatorio se aplica antes, pero siempre después de haberlo descargado [F3]. Sin red se opera con lo instalado y con la base local como fuente de verdad [F7].

**Propuesta para P2 (momento):**

1. **Disparadores** de una sola rutina de consulta: arranque en frío (requisito del prompt), reanudación después de N minutos y login con cuenta exitoso (señal del folio 004). El desbloqueo local no dispara nada que exija red (H-07).
2. **No bloquea** el arranque: arranca lo instalado, consulta y descarga en segundo plano, y activa en el próximo arranque en frío o en el próximo punto seguro (H-06).
3. **Sin red entre sesiones:** la app opera completa con contenido, definiciones y sesión locales. La sesión local se rige por P4 (desbloqueo con la seguridad del teléfono, N2). La salida queda en el outbox [F7].

Cadena de consecuencias: el costo de no bloquear cae en que el usuario ve lo nuevo un arranque más tarde (pesa una apertura, sin medir en días). Lo que pierde la alternativa bloqueante es 1,2 s por apertura (E01 l. 203) y la operación con red débil. Es reversible: es un parámetro, como el `fallbackToCacheTimeout` de Expo.

### 3.4 P12 — capacidades del dispositivo y el manifiesto

**Lo que se fija en la instalación y no cambia con una actualización de contenido** (documentación oficial):

| Plataforma | Qué | Fuente |
| --- | --- | --- |
| Android | `<uses-permission>`: «if your app requests app permissions, you must declare these permissions in your app's manifest file» | [F10] |
| Android | `<uses-feature android:required="false">` más `hasSystemFeature()` en tiempo de ejecución: «If the hardware isn't available, gracefully disable that feature» | [F10] |
| Android | `<queries>`: si la app apunta a API 30 o más y «needs to interact with apps other than the ones that are visible automatically» | [F12] |
| Android | Permisos de tiempo de ejecución: declarar, pedir en contexto, verificar en cada uso, rationale; después de dos rechazos el diálogo ya no aparece | [F11] |
| iOS | `NSCameraUsageDescription`: «This key is required if your app uses APIs that access the device's camera»; ídem ubicación con `NSLocationWhenInUseUsageDescription` | [F13][F14] (E1: `curl` al JSON de la documentación de Apple) |
| iOS | Sin la clave de uso, «the system terminates your app» | [F15] |
| iOS | Entitlements: «embedded in the code signature of its binary executable» | [F16] |
| iOS | `UIBackgroundModes`: se agrega habilitando la capacidad Background Modes en Xcode | [F17] |

**Qué puede y qué no puede cambiar una actualización de contenido:**

- **Puede:** cuándo y cómo se pide una capacidad que ya está declarada (el momento, el rationale propio, la pantalla). Puede dejar de usar una capacidad. Puede degradar una función cuando falta el hardware o el permiso.
- **No puede:** declarar un permiso, una clave de uso, un entitlement, un modo de fondo ni una entrada de `<queries>` [F10][F12][F13][F16][F17]. Tampoco puede cambiar el texto del diálogo del sistema en iOS, porque es el string de Info.plist (criterio propio, derivado de [F13]).

**Propuesta de diseño (criterio propio, apoyada en las fuentes citadas):**

| Pieza | Qué es | Precedente |
| --- | --- | --- |
| **Catálogo de capacidades del cascarón** | Una lista generada en el build del cascarón, con una entrada por capacidad: id estable (`camera.capture`, `location.whenInUse`, `bt.print`…), versión de su contrato en el puente y lo que declara en cada plataforma (permiso, clave de uso, feature, query). Una prueba de CI verifica que cada entrada tenga su declaración en AndroidManifest e Info.plist | El caso de referencia: catálogo cerrado de URL-comandos; su falla de Bluetooth sin declarar (H-08) es lo que esa prueba evita |
| **Descubrimiento por el puente** | `bridge.handshake` devuelve `{shellVersion, bridgeVersion, capacidades: [{id, version, estado}]}`, con `estado` ∈ `disponible`, `sin-hardware` (`hasSystemFeature`), `permiso-denegado`, `permiso-sin-pedir` y `no-declarada`. El permiso se pide en el uso, nunca en el handshake | N2 l. 142 (handshake con capacidades); [F10] `hasSystemFeature`; [F11] verificar en cada uso |
| **Requisitos en el manifiesto del contenido** | `capabilities: { requires: [...], optional: [...] }`. **`requires`** es lo que el contenido no puede funcionar sin tener: el actualizador **no activa** un paquete cuyo `requires` no esté en el catálogo, y se queda con el instalado. **`optional`** es lo que el contenido degrada si falta | `<uses-feature android:required>` [F10]: la misma distinción entre requerido y opcional, pero entre el contenido y el cascarón |
| **Relación con la compatibilidad** | `minShellVersion` se **calcula** en el pipeline a partir de `requires` y de la versión del puente: es la primera versión del cascarón cuyo catálogo cubre lo requerido. Hay un solo origen de verdad, para que el número y la lista no diverjan. En el teléfono manda el catálogo; `minShellVersion` sirve al servidor para no ofrecer el paquete | Expo `runtimeVersion` (N1 §4.10); que se derive de la lista es criterio propio |
| **Capacidad nueva** | Siempre en dos tiempos: (1) release del cascarón por tienda, con la declaración y la entrada nueva del catálogo; (2) contenido que la pone en `requires` u `optional`. Hasta que la base instalada se actualice, `optional` con degradación | [F10][F13]; la regla R1 de N1 §6 (función de peso, por tienda) |

**Qué hace el contenido cuando falta una capacidad:** si está en `requires`, el contenido ni se activa (queda el anterior). Si está en `optional`, oculta la función o explica por qué no está, y no pide nada. Si el estado es `permiso-denegado`, muestra el rationale con salida a ajustes, como el caso de referencia (`LocationPermissionService.cs:11-34`) y la guía oficial [F11].

Cadena de consecuencias: el costo cae en el pipeline (generar y validar el catálogo) y en el cascarón (un handshake). Pesa **sin medir**. La alternativa, sin catálogo, pierde la detección antes de activar: el fallo aparece en el campo, y en iOS como cierre de la app [F15]. Es reversible: es un campo más del manifiesto.

### 3.5 P13 — encuestas tomadas con una versión cuando llega otra

| Regla | Por qué | Fuente |
| --- | --- | --- |
| La definición tiene `encuestaId` y `version` propios, que cambian en cada publicación | El cliente se entera de que hay algo nuevo por el cambio de versión | ODK: «the `version` must change in order for data collection clients to understand that they should update» [F19] |
| Cada respuesta guarda `{encuestaId, versionDefinicion}` desde que se empieza a cargar | Se valida e interpreta con la definición con la que se tomó | ODK: los envíos y su edición quedan atados a «the version of the form that was active when the form was originally filled» [F21]; «all the previous submissions remain unchanged» [F19] |
| El cliente conserva toda definición que tenga respuestas pendientes o en curso | La encuesta en curso se termina con su versión; la nueva aplica a la próxima | Criterio propio; mismo principio que el service worker que espera a sus clientes [F6] |
| El servidor acepta las versiones publicadas y no retiradas; retirar una versión es un acto explícito y anunciado | Una respuesta tomada sin red puede llegar días después | Que ODK Central acepte versiones anteriores lo dice sólo un foro, no la documentación oficial: **NO VERIFICADO** |
| La sincronización es idempotente y no depende de la versión de la app | Reintentos sin duplicar | Framework-APP.md l. 281–282; [F7] |
| Ninguna actualización, tampoco una obligatoria, descarta, migra en silencio o invalida pendientes | El folio 005 | H-04, H-10 |

### 3.6 P3 (en lo que toca) y P4/P5 (sin red al iniciar sesión)

- **P3:** el contrato del puente se versiona **junto con** el catálogo de capacidades (§3.4). El handshake es el punto único de compatibilidad en el teléfono y `minShellVersion` el punto en el servidor. El cascarón le informa al servidor, en cada consulta, su versión y el resumen del catálogo, como la referencia informa hoy su versión (`Config.cs:38`).
- **P4/P5:** «iniciar sesión» sin red sólo puede ser el desbloqueo local (N2). Por eso la consulta de actualización no puede depender de él (H-07). La sesión local habilita operar, y el outbox guarda la salida [F7]. El login con cuenta, que exige red, es una buena oportunidad extra para consultar, nunca una condición para operar.

---

## 4. Actualización forzada (ampliación de la presidencia, folio 006)

### 4a. Contenido: forzable por el propio canal

| Aspecto | Propuesta | Fundamento |
| --- | --- | --- |
| Cómo se marca | En el manifiesto: `mandatory: true` en la versión, o `minContentVersion` (todo lo instalado por debajo es obligatorio de reemplazar) | El `isMandatory` de CodePush [F3]; Expo lo deja a lógica propia [F2] |
| Cuándo se activa | Apenas está **descargado y verificado**, en el próximo **punto seguro**: arranque en frío, o al terminar la encuesta en curso con un aviso «hay una versión obligatoria: se aplica al terminar esta encuesta». Nunca en mitad de una carga | El reload pierde «unsaved user input» [F4]; el `IMMEDIATE` de CodePush reinicia en el acto [F3]: acá se descarta como default |
| Sin red | **No se puede forzar lo que no se puede bajar.** Se opera con lo instalado y el obligatorio se aplica en la próxima consulta con red. No hay bloqueo sin red | Folio 006: «no se puede forzar lo que no se puede bajar»; folio 005 |
| Con encuestas sin sincronizar | El obligatorio **no** espera a vaciar el outbox para activarse: las pendientes se conservan con su versión (§3.5). Opcional: si hay red, se intenta sincronizar antes de activar | §3.5 |
| Bloqueo verdadero | Sólo si el servidor **rechaza** la versión de contenido en uso, por ejemplo por un error de seguridad. Aun así, las pendientes quedan guardadas y se sincronizan en cuanto se activa la versión nueva | Criterio propio. El `expires` anti-freeze de N1 §4.10 cruza con esto: solicitud 5.3 |

### 4b. Cascarón: depende de la tienda

| Plataforma | Qué se puede forzar | Fuente |
| --- | --- | --- |
| Android (Play) | Flujo **inmediato** de In-App Updates: «fullscreen UX flows that require the user to update and restart the app in order to continue using it … After a user accepts an immediate update, Google Play handles the update installation and app restart». Requiere Android 5.0 (API 21) o superior. La urgencia se marca con `inAppUpdatePriority` de 0 a 5, sólo al lanzar el release, y se lee con `updatePriority()`; también hay `clientVersionStalenessDays()`. Si el usuario cancela: «If your app can't function without the update, consider displaying an informative message before restarting the update flow or prompting the user to close the app». Al volver a primer plano hay que retomar `DEVELOPER_TRIGGERED_UPDATE_IN_PROGRESS` | [F8][F9] |
| Android (APK fuera de Play) | **NO VERIFICADO** que In-App Updates funcione; lo prudente es la salida propia (H-11) | [F8] |
| iOS | No se encontró una API de actualización dentro de la app equivalente a la de Play. Que no exista queda **NO VERIFICADO** en sentido fuerte, porque una ausencia no se prueba. Lo documentado es presentar la ficha de la App Store dentro de la app con `SKStoreProductViewController`, «a page where customers can purchase media from the App Store», a la que se le pasa el identificador del producto. El forzado es: bloquear con una pantalla propia y llevar a la ficha | [F18] |
| Cómo se entera el cascarón | El servidor publica `minShellVersion` (o una política aparte del cascarón). El cascarón compara contra su propia versión en cada consulta con red. Sin red no bloquea por esto: el cascarón instalado sigue operando con el contenido compatible que ya tiene | Framework-APP.md l. 116–117; §3.4 |
| Caso de referencia | **No lo hace**: no hay código de forzado (E1 `grep` sin coincidencias, §3.1). Sí manda su versión al servidor en la URL de login (`Config.cs:38`), que es el gancho donde un servidor podría bloquear. Que el portal lo haga queda **NO VERIFICADO** | §3.1 |

**Ventaja que pidió el PO, en una línea:** el contenido se puede forzar por el propio canal, en un punto seguro y nunca sin red. El cascarón se fuerza con el flujo inmediato de Play en Android, y en iOS sólo bloqueando y llevando a la ficha de la tienda.

Cadena de consecuencias del forzado: el costo cae en el encuestador que tiene que esperar un punto seguro (pesa una encuesta, sin medir). La alternativa del reinicio inmediato pierde la entrada en curso [F4]. Es reversible: es un modo de instalación del manifiesto, que se puede cambiar.

---

## 5. Lo que revisé y está bien

1. **E01 deja la versión anterior cuando la verificación falla** (E01 l. 174, corrida 4): es la base correcta para que «obligatorio» nunca deje al usuario sin contenido.
2. **El paquete semilla y la política de espera del borrador** (Framework-APP.md l. 140–141) van en la dirección de la industria: operar con lo embebido o lo instalado [F1][F4].
3. **El handshake con capacidades de N2** (N2 l. 142–144) es el punto de enganche correcto para el descubrimiento de P12. Esta comisión le suma `requires`/`optional` en el manifiesto del contenido y el cálculo de `minShellVersion`.

## 6. Solicitudes de convocatoria (fuera de la competencia de esta comisión)

| # | Señal | Ubicación | A quién |
| --- | --- | --- | --- |
| 6.1 | La validación «`requires` del contenido ⊆ catálogo del cascarón de `minShellVersion`», y «cada entrada del catálogo tiene su declaración en AndroidManifest e Info.plist», son candidatas a la compuerta del PR | §3.4 de este informe; H-08 | Compuerta de PR / pruebas (N3, N4) |
| 6.2 | El escenario de la encuesta (tomar sin red, sincronizar, corrección que llega en el medio) como escenario guía de la guía y de la demo | Folio 005; §3.5 | Didáctica (N5) |
| 6.3 | El `expires` anti-freeze del manifiesto (N1 §4.10) contra la operación sin red: ¿un manifiesto vencido sin red bloquea? Hay que conciliarlo con la regla «nunca bloquear sin red» | §4a, fila «Bloqueo verdadero» | Seguridad del canal |
| 6.4 | Ensayo de una variable pendiente: en E01, arrancar con la red cortada después de instalar v2 (E01 l. 267). Es la celda 6 de la fila A, sin medir. No se corrió: el g42 está ocupado | §3.1, tabla | Perito / presidencia |

## 7. Fuentes externas (consultadas el 2026-10-25)

| Id | Fuente |
| --- | --- |
| F1 | Expo. *app.json / app.config.js*, `updates.checkAutomatically`, `updates.fallbackToCacheTimeout`. https://docs.expo.dev/versions/latest/config/app/ |
| F2 | Expo. *Download updates* (EAS Update). https://docs.expo.dev/eas-update/download-updates/ |
| F3 | Microsoft. *react-native-code-push — API Reference (JavaScript)*. https://github.com/microsoft/react-native-code-push/blob/master/docs/api-js.md (producto retirado; ver N1 §4.4) |
| F4 | Capawesome. *Live Update plugin*. https://capawesome.io/plugins/live-update/ |
| F5 | Ionic. *Appflow Deploy — Plugin API*. https://ionic.io/docs/appflow/deploy/api |
| F6 | Archibald, J. *The service worker lifecycle*. web.dev. https://web.dev/articles/service-worker-lifecycle |
| F7 | Google. *Build an offline-first app*. Android Developers. https://developer.android.com/topic/architecture/data-layer/offline-first |
| F8 | Google. *In-app updates*. Android Developers. https://developer.android.com/guide/playcore/in-app-updates |
| F9 | Google. *Support in-app updates (Kotlin or Java)*. https://developer.android.com/guide/playcore/in-app-updates/kotlin-java |
| F10 | Google. *Declare app permissions*. https://developer.android.com/training/permissions/declaring |
| F11 | Google. *Request runtime permissions*. https://developer.android.com/training/permissions/requesting |
| F12 | Google. *Declare package visibility needs*. https://developer.android.com/training/package-visibility/declaring |
| F13 | Apple. *NSCameraUsageDescription*. https://developer.apple.com/documentation/bundleresources/information-property-list/nscamerausagedescription (leído por su JSON: `https://developer.apple.com/tutorials/data/documentation/bundleresources/information-property-list/nscamerausagedescription.json`) |
| F14 | Apple. *NSLocationWhenInUseUsageDescription*. https://developer.apple.com/documentation/bundleresources/information-property-list/nslocationwheninuseusagedescription (ídem, por JSON) |
| F15 | Apple. *Requesting authorization to capture and save media*. https://developer.apple.com/documentation/avfoundation/requesting-authorization-to-capture-and-save-media (ídem, por JSON) |
| F16 | Apple. *Entitlements*. https://developer.apple.com/documentation/bundleresources/entitlements (ídem, por JSON) |
| F17 | Apple. *UIBackgroundModes*. https://developer.apple.com/documentation/bundleresources/information-property-list/uibackgroundmodes (ídem, por JSON) |
| F18 | Apple. *SKStoreProductViewController*. https://developer.apple.com/documentation/storekit/skstoreproductviewcontroller (ídem, por JSON) |
| F19 | ODK. *Managing Forms in Central*. https://docs.getodk.org/central-forms/ |
| F20 | ODK. *ODK Collect* (introducción). https://docs.getodk.org/collect-intro/ |
| F21 | ODK. *Managing Forms in Collect*. https://docs.getodk.org/collect-forms/ |

## 8. Fichas de excepción

Ninguna. Esta comisión no propone dejar de seguir ninguna convención que rige.

## 9. Lo no verificado, junto

- Si el portal de la app de referencia bloquea versiones viejas con el `appVersion` que recibe (§3.1, §4b).
- Arranque de A sin red (E01 l. 267; solicitud 6.4).
- In-App Updates fuera de Play (H-11).
- Que no exista una API de actualización dentro de la app en iOS: no se prueba una ausencia (§4b).
- «Al iniciar sesión» como patrón con nombre en la industria (H-07).
- Que ODK Central acepte envíos de versiones anteriores publicadas: lo dice un foro, no la documentación oficial (§3.5).
- Peso de una definición de encuesta como datos y costo del catálogo de capacidades: sin medir.

Sigue: incorporación del siguiente informe y resolución · presidencia
