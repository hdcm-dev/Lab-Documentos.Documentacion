| Campo | Valor |
|---|---|
| Tipo | dictamen |
| Fecha | 2026-10-31 |
| Autor | Mesa de estándares, experiencia de usuario y diseño |
| Expediente | 0001 · Framework Concept |
| Sigue a | 049–054 |
| Estado | propuesta para que el PO confirme |

> **Rutas.** FC = `Lab-Documentos/Concepts/Framework-Concept`; demo = `FC/Demo`; src = `FC/Demo/src`; ACT = `Lab-Documentos.Documentacion/PROMPTs/Concepts/01-Framework-Concept/OUTPUTs/Expedientes/0001-Framework-Concept-Maui-Autoactualizable/actuaciones`; E04 = `Lab-Documentos.Documentacion/PROMPTs/Concepts/01-Framework-Concept/OUTPUTs/Ensayos/E04-Arranque-Superpuesto`. «07» es `FC/07-Red-Y-Autenticacion.md`.
>
> **Cómo se hizo.** Hubo cuatro investigaciones con fuentes: rendimiento, seguridad e identidad, UX y flujo, y diseño estético. Después vino una propuesta del arquitecto y tres jurados: campo, seguridad y estándares, y costo y coherencia con la norma. Este dictamen ya trae incorporados los ajustes de los jurados. Lo que no se pudo confirmar en la fuente va marcado **no verificado**. No se modificó ningún repo.

# Arranque, versión, PIN y sesión sin conexión: propuesta para las cinco decisiones abiertas

## Lo que pidió el PO

El PO pidió que la mesa elabore una propuesta para las cinco decisiones que le quedaban abiertas, a partir de los estándares y las recomendaciones de la industria y de especialistas en experiencia de usuario, flujo y diseño estético:

1. Si la primera corrida después de instalar cuenta para el umbral de arranque (P1).
2. Si V1 (arranque superpuesto) pasa a `main`.
3. Si la app tiene un PIN propio para los teléfonos sin bloqueo de pantalla.
4. Cuánto dura la sesión sin conexión.
5. Las cinco decisiones del dictamen de UX (ACT/054, «Lo que decide el PO»).

## Hallazgos que cambian el punto de partida

Los jurados encontraron tres cosas al leer el código y el expediente. Las tres condicionan las decisiones:

- **El outbox no está cifrado.** El cascarón usa EF Core SQLite común, sin clave (`src/FrameworkConcept.Shell/Data/DbSqlite.cs`, `src/FrameworkConcept.Shell/FrameworkConcept.Shell.csproj:131`). El único cifrado es el del refresh, en `CofreDeSesion`. La frase «el outbox usa otra clave» de la propuesta inicial era falsa y se retira.
- **La copia de seguridad está permitida.** `android:allowBackup="true"` está en `src/FrameworkConcept.Shell/Platforms/Android/AndroidManifest.xml:11` y no hay reglas de exclusión. El propio cofre ya prevé que el sellado se restaure en otro teléfono (`src/FrameworkConcept.Shell/Auth/CofreDeSesion.cs:79-81`).
- **El desbloqueo del SO exige API ≥ 30** (`src/FrameworkConcept.Core/Auth/Oidc.cs:245-246`), y el cascarón soporta desde la API 24 (`FrameworkConcept.Shell.csproj:28`). Entre la API 24 y la 29 no hay desbloqueo local aunque el teléfono tenga bloqueo de pantalla.

Lo que ya estaba resuelto y no se reabre:

- `KeyPermanentlyInvalidatedException` ya se atrapa: borra la clave y pasa a `Revocada` (`CofreDeSesion.cs:83,89-94`, `src/FrameworkConcept.Core/Auth/Sesion.cs:105`).
- `offline_access` ya figuraba como pendiente («en producción se evalúa», 07:97 y 07:150). D4 cierra esa evaluación.
- El hallazgo de la pantalla en blanco de más de 30 s en V1 se cita en ACT/053:26 y :31 como «052, revisión», pero el texto de esa revisión no está en 052. Hay que asentarlo con su número de folio antes de fusionar (ver D2).

## Resumen de la propuesta

| | Decisión | Valor |
|---|---|---|
| **D1** | La primera corrida después de instalar **no cuenta** para los 5 000 ms. Se agrega un tope de primer uso y un TTID de control | Régimen ≤ 5 000 ms (máximo de 5 corridas en frío, sin cambios). Primer uso ≤ 10 000 ms (máximo de 3, con V1S). TTID ≤ 5 000 ms en todas las corridas |
| **D2** | **V1 pasa a `main`**, reimplementada en limpio junto con V1S y con una salvaguarda | El saludo se retiene como máximo 2 000 ms. Capa con acciones a los 10 000 ms. Solo se difiere «hay versión nueva», nunca una revocación ni un rollback. Se rotula «mejora: P1 sigue sin cumplirse» |
| **D3** | **Sí al PIN propio**, como segundo escalón y solo si la vía del Keystore no está disponible | 6 dígitos con lista de rechazo. 10 intentos, con esperas desde el 6.º y deshabilitado al 10.º. PBKDF2-HMAC-SHA256 con 600 000 iteraciones atado a una clave del Keystore |
| **D4** | Tres relojes. **Al vencer el plazo sin conexión se sigue cargando**, con lo cargado marcado | R1: desbloqueo local a los 15 min en segundo plano. R2: aviso a los 7 días (72 h en la vía del PIN). R3: a los 30 días (7 en la vía del PIN) se borran las credenciales locales; el outbox se conserva cifrado |
| **D5.1** | **No** se recarga en el login, y **no** se aplica la versión al suspender | Tarjeta según R7 (una vez por versión) y chip persistente en la cabecera |
| **D5.2** | **Sí** a la variante L solo para la obligatoria | Barra determinada de 8 dp. Salida a los 10 s si la causa es compatibilidad; sin salida con red si es revocación |
| **D5.3** | **Sí** se vuelve a pedir la autenticación después de «Reiniciar ahora», avisado antes | El texto cambia según la vía: huella o patrón, o PIN de la app |
| **D5.4** | **ADR propio** «Presentación y tokens compartidos», con referencia cruzada desde P2 | Única fuente de los tokens: `app.css:4-33`. Prueba en Gate de paridad con el cascarón |
| **D5.5** | **En paralelo, con la percepción primero** | Splash, esqueleto (que es la capa de V1), leyenda pasado 1 s, fundido de 150 ms |

Además entran tres puntos transversales que pidió el jurado de seguridad: **T1**, cifrar el outbox; **T2**, cerrar la copia de seguridad; **T3**, un procedimiento para revocar un teléfono perdido. D3 y D4 dependen de T1 y T2.

---

## D1. ¿La primera corrida después de instalar cuenta para el umbral de P1?

**Decisión: no cuenta para los 5 000 ms.** El primer uso tiene un tope propio.

| Métrica | Condición | Estadístico | Umbral |
|---|---|---|---|
| TPR de régimen (P1) | En frío, con el contenido instalado | Máximo de 5 corridas | ≤ 5 000 ms |
| TPR de primer uso (nueva) | Instalación limpia | Máximo de 3 instalaciones | ≤ 10 000 ms, **atado a V1S** |
| TPR después de una OTA (nueva) | Primer arranque después de una OTA que cambia `dotnet.native.wasm` | Máximo de 3 corridas, obligatorio | ≤ 10 000 ms, **provisorio hasta medirlo** |
| TTID de control (nueva) | `TotalTime` de `am start -W`, todas las corridas, también la recién instalada | Máximo | ≤ 5 000 ms (línea de vitals) |

Condición de presentación: toda espera de más de 1 s muestra una leyenda («Preparando la app…», o «Aplicando la versión X.Y.Z…» después de una OTA), y a los 10 s aparece una salida (R1 de ACT/054:241).

**Fundamento:**
- P1 ya dice «con el contenido ya instalado» (ACT/035:325-337).
- XCTest hace «one throwaway launch attempt» y después mide 5 iteraciones (WWDC19 423). Es el mismo método de P1, sin la primera corrida.
- Google admite que el primer uso después de instalar o actualizar es subóptimo «until new code paths are optimized» (Baseline Profiles).
- Android vitals no excluye el primer arranque, pero mide el TTID con línea de 5 s. El cascarón ya da entre 1 074 y 2 240 ms (`E04/e04-V1-am-start.txt:3-19`, `E04/e04-V1S-am-start.txt`).
- En el contenido, el costo es estructural. V8 guarda el código wasm compilado recién después de la primera carga, y la caché se invalida si cambia el `.wasm` (V8, *WebAssembly code caching*). Coincide con E04/INFORME.md:64.
- Los 10 s son el límite de atención de NN/g. Pasado ese punto hacen falta un indicador de avance y una forma de interrumpir.

**Ajustes de los jurados que entran:**
- **Costo y coherencia:** no se presenta como «aclaración». El expediente midió con la primera corrida dentro (049, 052; `E04/INFORME.md:39`: «Ninguna variante cumple el umbral con R1 incluido»). Es una **interpretación nueva** y se asienta en la constancia, que corrige la lectura de `INFORME.md:39` y de ACT/053:22-24 sin reescribirlas.
- **Costo y coherencia:** el tope de 10 s solo tiene margen con V1S (7 930–8 783 ms). La base da 9 152 ms y V1 sola 9 648 ms (`E04/INFORME.md:24`), a 352 ms del tope. Por eso el tope queda atado a la semilla.
- **Campo:** el primer uso que de verdad sufre el usuario es el posterior a una OTA. Ocurre en el campo y sin aviso, mientras que la instalación limpia la suele hacer un capacitador con red. Por eso la medida después de una OTA es obligatoria (3 corridas) y lleva su leyenda.
- **Seguridad:** se mide con el **mismo APK de release firmado** que va a producción, no con uno de depuración.
- El cascarón llama a `reportFullyDrawn` en «Listo», como ya pedía ACT/035:922. Así el TPR pasa a ser un TTFD con nombre propio y se ve en Perfetto (*App startup time*).

**Desacuerdos:** ninguno.

**Descartado:**
- Contar la primera corrida dentro de los 5 s: ninguna variante cumpliría, la causa está en el motor y ninguna referencia mide así.
- No medir el primer uso: lo esconde, y se repite en cada OTA que cambia el `.wasm`.
- Un tope de 8 s: no tiene fuente que lo respalde.

---

## D2. ¿V1 pasa a `main`?

**Decisión: sí, reimplementada en limpio como una sola ruta (V1 + V1S + salvaguarda).** No se fusionan las ramas de ensayo. **Aun así, P1 sigue sin cumplirse**: el peor régimen es 5 199 ms, o 5 554 ms en la serie V1S. La fusión se rotula «mejora; a P1 le faltan 200–600 ms».

**Salvaguarda:**
1. El cascarón retiene el saludo como máximo **2 000 ms** después de que llega.
2. Si en ese tiempo el actualizador no decidió, el cascarón suelta el saludo con la versión verificada que está sirviendo, sea la instalada o la semilla. Esa versión se **reverifica al servirla**, con firma y hash del manifiesto.
3. **Solo se difiere «hay versión nueva»**: se aplica en el próximo arranque en frío, como manda P2. Cuando la decisión es **una revocación o un rollback por seguridad**, se corta igual: la capa pasa a una pantalla de bloqueo y se vuelve a la última versión verificada que no esté revocada.
4. **No se sirve por adelantado** una versión que tenga cargas fallidas registradas. En ese caso se espera al actualizador, con la capa y la leyenda de R1.
5. **Piso contra el rollback:** el cascarón guarda la versión mínima aceptable más alta que vio, y nunca sirve la semilla ni otra versión por debajo de ese piso.
6. La capa nativa se retira solo con «Listo». Si a los **10 000 ms** no llegó, la capa muestra **[Seguir esperando] [Reiniciar la app]**, la frase «Lo pendiente se conserva» y el enlace «Ver detalle», que lleva a Diagnóstico.

**Fundamento:**
- V1 es la única palanca medida que baja el régimen: de 6,9–7,3 s a 4,8–5,2 s (`E04/INFORME.md:31`). V2 empeora (`E04/INFORME.md:37-38`).
- Una pantalla en blanco de más de 30 s viola el límite de 10 s de NN/g y la regla R1 de ACT/054:241.
- V1S hace falta para que siempre haya una versión verificada para servir, también en una instalación limpia, y además baja el primer uso a 7,9–8,8 s (ACT/053). Si `main` sin semilla puede servir algo verificado en una instalación limpia: **no verificado**.

**Ajustes de los jurados que entran:**
- **Seguridad:** los puntos 2, 3 y 5 (revocación y rollback no se difieren, reverificación al servir, piso). Si P2 ya prevé interrumpir la sesión por una revocación queda **no verificado**. Si no lo prevé, entra como renglón aditivo en P2.
- **Costo:** el punto 4. Además, la reimplementación saca los interruptores `-p:FcE04=V1|V2|V1S` y todo el código de V2. La rama `e64f4fd` no es ancestro de `main`, y `main` ya trae 6 commits que la rama no tiene, entre ellos el login nuevo. La capa opaca de V1 es el mismo esqueleto de D5.5, en un único cambio sobre `ArranquePage`.
- **Costo:** se borra la promesa de que la salvaguarda baja el primer uso a unos 6,5 s. En V1S el saludo llega a los 6,4–7,7 s y el actualizador decide a los 7,5–8,3 s (`E04/INFORME.md:65-67`), así que la retención real ya es menor a 2 s. El tope solo actúa en el caso patológico.
- **Campo:** «Reintentar» pasa a llamarse «Reiniciar la app», junto con la frase sobre los datos (R5, ACT/054:245) y «Ver detalle» (R3, ACT/054:243).
- **Costo:** el hallazgo de los 30 s se asienta con su folio antes de fusionar.

**Palancas para el margen, en este orden:**
1. Globalización invariante en el contenido (decisión 3 de 052, pendiente).
2. Confirmar que la caché de código wasm funciona con `shouldInterceptRequest`. El cascarón ya sirve `application/wasm` (`src/FrameworkConcept.Shell/Hosting/ServidorDeContenido.cs:93`), pero falta la prueba: **no verificado**.
3. Carga diferida de ensamblados.

El AOT del contenido queda fuera (ACT/035; `src/FrameworkConcept.Content/FrameworkConcept.Content.csproj:18`). Baseline Profiles y Cloud Profiles no se usan como base: el costo está en el WebView y en Mono-wasm, no en el DEX (inferencia, **no verificado**).

**Desacuerdos:** ninguno.

---

## D3. PIN propio para teléfonos sin bloqueo de pantalla

**Decisión: sí, como segundo escalón.** Sigue el modelo de Intune «App PIN when device PIN is set = Not required».

**Cuándo se ofrece.** La vía del Keystore con autenticación no está disponible cuando el teléfono tiene **API < 30 o `!IsDeviceSecure`**:
- **Escalón 1**, solo con API ≥ 30 y sin bloqueo: «Configurar bloqueo» abre `Settings.ACTION_BIOMETRIC_ENROLL` con `BIOMETRIC_STRONG|DEVICE_CREDENTIAL`. Al volver, la app revisa `IsDeviceSecure` en `OnResume` y sigue sola.
- **Escalón 2:** «Usar un PIN de la app», con el mismo peso visual (botón secundario delineado, no un enlace).
- En API < 30 se ofrece directamente el PIN: aunque el teléfono tenga bloqueo, la app no puede usar el Keystore con autenticación.

**Momento.** La puerta aparece en el **primer ingreso con servidor, mientras hay red**. No se descarta sin elegir. «Ahora no» la vuelve a mostrar en cada ingreso con red, y la banda avisa: «Sin bloqueo: si cerrás la app sin conexión no vas a poder volver a entrar». Hoy es un «Entendido» que se muestra una sola vez (`src/FrameworkConcept.Content/Auth/PuertaDeSesion.razor:195-205`).

| Parámetro | Valor | Fuente |
|---|---|---|
| Tipo y largo | Numérico, **6 dígitos** fijos, confirmación automática al sexto | NIST 800-63B-4 §3.2.10 (mínimo 4 SHALL, 6 SHOULD, numérico MAY) |
| Rechazados (lista cerrada y testeable) | Los 6 dígitos iguales; las corridas ascendentes y descendentes de 6; los patrones ABABAB y ABCABC; los 20 PIN de 6 dígitos más comunes, en una lista versionada en el repo | NIST §3.2.10 (lista de bloqueo); Intune |
| Intentos | **10** seguidos. Del 1.º al 5.º sin espera; después del 6.º, 30 s; del 7.º, 1 min; del 8.º y el 9.º, 5 min. Al **10.º** se deshabilita | NIST §3.2.10 (como máximo 10, después «SHALL be disabled») |
| Al deshabilitarse | Se borran el refresh sellado y la clave del cofre. Queda solo el login con servidor. El outbox se conserva | ACT/054:144 |
| Derivación | Clave del cofre = HKDF(PBKDF2-HMAC-SHA256(PIN, sal, **600 000** iteraciones) ‖ HMAC con una clave del Keystore sin autenticación de usuario) | OWASP Password Storage; NIST §3.2.10 (derivar la clave en AAL2 sin hardware protegido) |
| Costo | Meta ≤ 800 ms en el g42. Si se pasa, se acepta hasta 1 500 ms con un indicador. **Nunca menos de 600 000 iteraciones** | **No verificado**: hay que medir |
| Contador de intentos | Firmado con HMAC de la clave del Keystore y fuera de la copia de seguridad. Límite declarado: con root se puede reponer | Jurado de seguridad |
| Biometría en esta vía | No hay: sin credencial del teléfono no puede haber huella | MASTG-KNOW-0001 |
| Si después se configura un bloqueo (API ≥ 30) | Se migra al desbloqueo del SO y se deja de pedir el PIN | Intune «Not required» |
| Nivel declarado | La vía del PIN es de menor nivel que la del SO. Lleva relojes más cortos (D4) | ADR aditivo de D-03 |
| Opción | `auth.pinDeRespaldo`, activada por defecto en el producto de campo | — |

**Fundamento:**
- Hoy un teléfono sin bloqueo no puede trabajar sin red después de un reinicio de proceso: queda en `SinCuenta` (`demo/DISENO-RED-Y-AUTENTICACION.md:185-189, 270-271`).
- MASVS-AUTH-2 admite expresamente «a local PIN code».
- MASTG-TEST-0247 dice que la app «cannot force» al usuario a configurar el bloqueo del sistema.
- La guía de biometría de Android lleva a `ACTION_BIOMETRIC_ENROLL` cuando no hay credencial.

**Ajustes de los jurados que entran:**
- **Costo:** PBKDF2 en lugar de Argon2id. Viene con .NET (`Rfc2898DeriveBytes.Pbkdf2`), no suma dependencias y OWASP lo admite con 600 000 iteraciones. El HMAC del Keystore ya ata la fuerza bruta al dispositivo. Con esto, la objeción de seguridad sobre bajar Argon2id a t=1 deja de aplicar.
- **Costo:** el alcance incluye API 24–29. Se elimina la rama `ACTION_SET_NEW_PASSWORD`, y con ella el permiso `REQUEST_PASSWORD_COMPLEXITY`. Que `ACTION_BIOMETRIC_ENROLL` no requiera ese permiso queda **no verificado**.
- **Costo:** el texto de propósito promete solo lo cierto: «Protege el acceso a la app en este teléfono. No necesita conexión.» Mientras no esté T1, el PIN no protege el outbox.
- **Campo:** la puerta va en el primer ingreso con red y no se descarta sin elegir; la vuelta desde Ajustes es automática; el texto de «Olvidé mi PIN» sin red queda definido; se sacan las letras ABC del teclado para agrandar los dígitos (guantes).
- **Seguridad:** relojes más cortos para la vía del PIN (D4); procedimiento T3; el contador y el cofre quedan fuera de la copia (T2).

**Desacuerdo que queda: cantidad de intentos.**
- **Postura adoptada por la mesa:** 10 con esperas, como pidió el jurado de campo. Sin red, perder el PIN corta la jornada o varios días. Con el HMAC del Keystore, la diferencia entre 5 y 10 intentos sobre 10⁶ combinaciones es despreciable, y NIST permite 10.
- **En contra:** los jurados de seguridad y de costo preferían 5 sin esperas (Intune, bancos de 3 a 6). Hay que tener presente que con root el contador se puede reponer de todos modos, así que la mitigación real es T3.
- El PO lo confirma en la pregunta 7.

---

## D4. Cuánto dura la sesión sin conexión y qué pasa al vencer

**Decisión: tres relojes con valores fijos. El trabajo nunca se pierde, y vencer el plazo sin conexión no frena la carga.**

| Reloj | Vía del SO | Vía del PIN | Al vencer |
|---|---|---|---|
| **R1. Desbloqueo local** | En cada arranque en frío y al volver de **15 min** en segundo plano (hoy son 5: `src/FrameworkConcept.Core/Auth/Oidc.cs:249`) | Igual | Se pide el desbloqueo local, sin red |
| **R2. Plazo sin conexión**, desde el último contacto exitoso con el emisor | **7 días** | **72 h** | **Se sigue cargando.** Lo nuevo queda marcado «Se envía cuando ingreses con tu cuenta», y el servidor lo valida al sincronizar |
| **R3. Corte local**, desde el último contacto | **30 días** | **7 días** | Se borran las credenciales locales y la caché de referencia. Queda solo el ingreso con servidor. **El outbox se conserva cifrado (T1)** y se envía después de ingresar |
| **Emisor** (Keycloak) | `openid profile offline_access`; Client Offline Session Idle **14 días**; «Offline Session Max Limited» **activado**, con Client Offline Session Max **30 días** desde el ingreso; access token de 5 min | Igual | Ingreso completo, con su aviso propio: «Tu ingreso mensual vence el <fecha>» |

**Presentación:**
- La frase «Podés trabajar sin conexión hasta el <fecha>» está siempre visible en el perfil, junto con la acción **«Renovar ahora»** (con red).
- La renovación es silenciosa cuando hay red.
- Cuando faltan 24 h o menos para R2, se suma una segunda línea a la banda con la fecha absoluta. La cuenta regresiva aparece solo en las últimas 2 h.
- Al reconectar, la banda verde se retira a los **4 000 ms** (Short de Compose). Hay que corregir los 3 s de ACT/054:143 para que no queden dos valores.

**Integridad del reloj.**
- Junto al cofre se persisten el último contacto, el máximo reloj de pared visto (en UTC) y `SystemClock.ElapsedRealtime`.
- Si el reloj de pared retrocede más de 5 min respecto del máximo visto, el plazo se calcula desde el valor más conservador.
- Entre reinicios del teléfono se suma el tiempo transcurrido según `ElapsedRealtime`.

**Del lado del servidor.** Las filas creadas después de que se revocó la cuenta no se aplican en silencio: van a **cuarentena** para que las revise un supervisor, y no se borran (ACT/054:144). Las pantallas no dicen «lo pendiente se conserva» de una fila que quedó en cuarentena.

**Fundamento:**
- **Hoy no hay límite** (07:97), y el refresh muere con la sesión SSO de 30 min sin uso o 10 h máximo (`demo/DISENO-RED-Y-AUTENTICACION.md:590`). Por eso al volver de una salida sin red siempre hay que reingresar. `offline_access` lo resuelve (Keycloak, *Offline access*).
- **NIST 800-63B-4**, reautenticación:
  - AAL1: tope total de 30 días (SHOULD).
  - AAL2: 24 h, con inactividad de 1 h (SHOULD).
  - AAL3: 12 h (SHALL), con inactividad de 15 min (SHOULD).
  - R3 de 30 días cae justo en AAL1. **La sesión sin conexión se declara AAL1**, no AAL2 compensado: no hay texto de NIST que habilite esa compensación.
  - R1 de 15 min cumple incluso el SHOULD de AAL3.
- **Intune:** bloqueo a las 24 h sin conexión y borrado a los 90 días. No se adopta: 24 h corta jornadas de campo, y el borrado del outbox viola ACT/054:144.
- **Seguir cargando al vencer R2** respeta ACT/054:144 («se trabaja contra el outbox con la sesión local desbloqueada») y 07:97 («el trabajo local no depende de que el refresh siga vigente»). Evita el patrón que se critica de ArcGIS Field Maps: usuarios bloqueados en el campo (comunidad de Esri).
- **WCAG 2.2.1, 2.2.5 y 2.2.6:** aviso antes del vencimiento, ninguna pérdida de datos al reautenticar y aviso de cuánto dura. Coinciden con la regla R5 de ACT/054.

**Ajustes de los jurados que entran:**
- **Campo y costo:** se reemplaza el «modo consulta» del día 7 de la propuesta inicial, que contradecía 054:144 y 07:97, por «sigue la carga, marcada». Se suma «Renovar ahora» con la fecha siempre visible. Si al ingresar se borró la caché de referencia, se avisa: «Al ingresar se vuelven a descargar los datos de referencia (necesita conexión)».
- **Seguridad:** relojes más cortos en la vía del PIN, porque la fuerza bruta con root se estima en unos 6 días como máximo (estimación **no verificada**); reloj resistente a cambios de fecha; cuarentena del lado del servidor; AAL1 declarado; el outbox se conserva **solo si está cifrado** (T1).
- **Costo:** el Max de Keycloak se cuenta desde la creación de la sesión offline, no desde el último contacto. Por eso lleva un aviso aparte. Es una semántica tomada de la investigación, sin lectura directa: **no verificado**. La X abierta de los 5 min (`Oidc.cs:248`) era del borrador, no de la norma.

**Desacuerdos que quedan:**
- **Coherencia con la norma:** el corte de R3 reemplaza el «sin red se opera sin límite» de 07:97. Es una **reapertura de P4 en ese punto** y la confirma el PO (pregunta 9). Si el PO no la acepta, queda R2 solo como aviso y R3 sin corte. En ese caso la exposición de un teléfono abandonado depende únicamente de T1 y T3.
- **Campo:** las 72 h y los 7 días de la vía del PIN son cortos para salidas largas. La salida que se le ofrece al usuario es configurar el bloqueo del teléfono, que vuelve a 7 y 30 días.
- El valor por defecto de «Offline Session Max Limited» (apagado) y que el valor del cliente no pueda superar al del realm quedan **no verificados**. Se activa de forma explícita en el realm de ensayo.

---

## D5. Las cinco decisiones del dictamen ACT/054 (líneas 297-304)

### D5.1. ¿Recargar en el login sin preguntar?

**Decisión: no.** Tampoco se aplica la versión en silencio al suspender.
- La tarjeta «Hay una versión nueva» sigue la regla R7: «Más tarde» no se repite hasta el próximo login o arranque (ACT/054:161, :247).
- Mientras la versión siga lista, queda en la cabecera un **chip persistente y discreto**: «Versión 1.4.0 lista · Reiniciar». Así se cumple el «at all app entry points» de Android sin insistir.

**Fundamento:**
- Ninguna referencia aplica la versión normal al entrar:
  - Android flexible pide «request confirmation before restarting» (*In-app updates*).
  - CodePush usa `ON_NEXT_RESTART` y no muestra diálogo por defecto.
  - Expo aplica la versión «on the next app cold start».
  - El service worker espera una acción del usuario.
- Un modal al comienzo de una tarea con mucho en juego va contra NN/g (*Modal and nonmodal dialogs*).
- Interrumpir en los límites de una tarea reduce la molestia (Iqbal y Bailey, CHI 2005).

**Ajuste de los jurados:** campo y costo rechazaron la aplicación al suspender después de 15 min que traía la propuesta inicial:
- Es justo la «segunda regla» que ACT/054:270 dejó fuera.
- Cambia la versión sin que el usuario la elija.
- Depende de un autoguardado que no está especificado y de cómo MAUI restaura la Activity después de que muere el proceso (**no verificado**).

Si el PO la quiere igual, va en un expediente aparte, con su ADR y la medida en el g42.

**Desacuerdos:** ninguno que quede.

### D5.2. ¿Variante L solo para la obligatoria?

**Decisión: sí, en dos tipos.**
- **Obligatoria por compatibilidad:** pantalla completa con barra lineal determinada por bytes, de 8 dp. Con el corte, el texto de ACT/054:209: «Se cortó la descarga. Seguís con la 1.3.2…» y [Reintentar] [Seguir con la 1.3.2]. A los 10 s aparece la salida. Sin red no bloquea (ACT/054:79).
- **Obligatoria por revocación de seguridad:** con red no hay salida y la versión se aplica. Sin red se puede consultar, pero no se carga trabajo nuevo con la versión revocada hasta que vuelva la conexión.

**Fuentes:**
- Modo IMMEDIATE de Play.
- `mandatoryInstallMode = IMMEDIATE` de CodePush.
- NN/g: avance con porcentaje pasados los 10 s.
- M3: indicador determinado solo cuando se conoce el total.

**Ajuste:** la separación por revocación la agregó el jurado de seguridad.

### D5.3. ¿Volver a pedir la autenticación del SO después de «Reiniciar ahora»?

**Decisión: sí, avisado en la tarjeta.**
- Con la clave en timeout 0 (`demo/DISENO-RED-Y-AUTENTICACION.md:265-266`), el refresh sellado no se abre sin el prompt.
- Evitarlo obligaría a dejar un token sin sellar o a usar una clave con timeout mayor que 0. MASTG-BEST-0036 pide `CryptoObject` con autenticación en cada uso, y NIST §5.1 pide que los secretos de sesión no persistan en lugares inseguros.

**Ajustes:**
- **Seguridad:** `setConfirmationRequired(false)` solo saca la confirmación de la biometría pasiva. Con patrón o PIN el diálogo sigue apareciendo, así que no se promete «un solo toque».
- **Campo:** el texto cambia según la vía. Dice «Después te pedimos tu huella o patrón», o bien «Después te pedimos tu PIN de la app».
- Después de desbloquear, la app vuelve al inicio con los pendientes visibles (NN/g, *Designing for waits and interruptions*).

**Desacuerdo descartado:** el especialista de diseño proponía no pedir la autenticación dentro de la ventana de inactividad. Se descarta por lo de arriba.

### D5.4. ¿El ADR de presentación va propio o como anexo de P2?

**Decisión: ADR propio del Framework Concept, «Presentación y tokens compartidos», con referencia cruzada desde P2.** R1 a R9 rigen también para el login, el bloqueo, el PIN y la banda de red (ACT/054:237-249).

Lo que incluye:
- **Tokens:**
  - Una sola fuente, `src/FrameworkConcept.Content/wwwroot/css/app.css:4-33`: marca #0F6E56, tinte #E1F5EE, aviso #854F0B sobre #FAEEDA, error #A03030, radio 8 y 12, controles de 48 px, teclas de 64 dp y escala de 4.
  - Una prueba en Gate compara los valores hex de `app.css` con el ResourceDictionary del cascarón.
- **Movimiento de M3:**
  - Fundido de entrada en 150 ms y de salida en 75 ms.
  - Entrada con `cubic-bezier(0.05,0.7,0.1,1)` y salida con `cubic-bezier(0.3,0,0.8,0.15)`.
  - Todo se apaga con «reducir movimiento».
- **Texto fijo para las pantallas de seguridad** (PIN, bloqueo, vencimiento y revocación). Nunca afirma «lo pendiente se conserva» de una fila que quedó en cuarentena.
- **Cláusula de tienda:** la OTA nunca toca código nativo del cascarón. La política de Play prohíbe descargar código ejecutable fuera de Play, salvo el que corre «in a virtual machine or an interpreter» con acceso indirecto a las API. Que la revisión de Play clasifique así los DLL de Mono-wasm queda **no verificado**, igual que App Store 2.5.2.

**Fundamento:**
- Hoy `ArranquePage.xaml:8-12` dice «Framework Concept» mientras el contenido dice «Movilidad urbana».
- `DesbloqueoPage.xaml:9-18` es una pila sin tarjeta, con el error en #9a3412.
- `ContenidoPage.xaml:12,16` usa un ámbar #FFF4E5/#7A4100 distinto del token de aviso.

Es una decisión de gobernanza, sin fuente industrial que la fije.

### D5.5. Prioridad

**Decisión: en paralelo, con la percepción primero porque es barata.**
- Declarar `MauiSplashScreen` con fondo #F7F6F4 y el emblema verde dentro del círculo de 160 dp, sin texto y sin animación (guía de splash de Android; HIG *Launching*). El splash actual no está visto en el g42: **no verificado**.
- `ArranquePage` pasa a ser el esqueleto de la primera pantalla: cabecera verde y dos tarjetas #F1F1EF de radio 12. **Es la misma capa de V1** y va en el mismo PR (D2).
- Leyenda pasado 1 s, salida a los 10 s y fundido de 150 ms hacia el contenido, en lugar de los 200 ms de 054.
- **Fondo:** las palancas de D2, en su orden.

**Ajuste de campo:** se suma a la prueba con 5 usuarios de 054 la tarea «abrir sin red en el día 8 y cargar una encuesta», que valida D4.

---

## Pantallas

Todas usan los tokens de `app.css:4-33`. La tarjeta es blanca, de radio 12. El emblema es un círculo de 56 px con tinte #E1F5EE y el ícono en #0F6E56. Los títulos van en 22 px semibold y el texto secundario en #5C5C57.

```
D2/D5.5-a  Arranque (esqueleto = capa de V1; reemplaza a ArranquePage)
┌──────────────────────────────────────┐
│ ████████ Movilidad urbana ██████████ │  cabecera #0F6E56
│ ┌──────────────────────────────────┐ │
│ │ ░░░░░░░░░░░░░                    │ │  tarjetas #F1F1EF, radio 12
│ │ ░░░░░░░                          │ │  shimmer apagado con «reducir
│ └──────────────────────────────────┘ │  movimiento»
│ ┌──────────────────────────────────┐ │
│ │ ░░░░░░░░░░                       │ │
│ └──────────────────────────────────┘ │
│  Preparando la app…                   │  aparece a 1 s; tras una OTA:
│                                       │  «Aplicando la versión 1.4.0…»
└──────────────────────────────────────┘
 Se retira solo con «Listo», con un fundido de 150 ms.

D2-b  La capa a los 10 s sin «Listo»
┌──────────────────────────────────────┐
│  Está tardando más de lo normal.      │
│  Lo pendiente se conserva.            │
│ ┌────────────────┐ ┌───────────────┐ │
│ │Seguir esperando│ │Reiniciar la app│ │  delineado / relleno verde, 48 px
│ └────────────────┘ └───────────────┘ │
│  Ver detalle                          │  → Diagnóstico (R3)
└──────────────────────────────────────┘

D3-a  Puerta sin bloqueo (primer ingreso con red; API ≥ 30)
┌──────────────────────────────────────┐
│              ( 🔒 )                   │
│  Tu teléfono no tiene bloqueo         │
│  de pantalla                          │
│  Para abrir la app sin conexión       │
│  necesitás un bloqueo de pantalla     │
│  o un PIN de la app.                  │
│ ┌──────────────────────────────────┐ │
│ │       Configurar bloqueo         │ │  relleno verde, 48 px
│ └──────────────────────────────────┘ │
│ ┌──────────────────────────────────┐ │
│ │      Usar un PIN de la app       │ │  delineado, mismo tamaño
│ └──────────────────────────────────┘ │
│  Ahora no                             │  vuelve en cada ingreso con red
└──────────────────────────────────────┘
 Al volver de Ajustes: se revisa IsDeviceSecure en OnResume y sigue solo.
 En API < 30 se pasa directo a D3-b.

D3-b  Alta del PIN (paso 1 de 2; el paso 2 dice «Repetí tu PIN»)
┌──────────────────────────────────────┐
│              ( 🔒 )                   │
│  Elegí un PIN de 6 números            │
│  Lo vas a usar para abrir la app sin  │
│  conexión. Es distinto del de tu      │
│  teléfono.                            │
│       ○   ○   ○   ○   ○   ○           │  12 px, separados 16; borde #767670
│                                       │
│     [ 1 ]     [ 2 ]     [ 3 ]         │  teclas de 64 dp, dígitos de 32 px
│     [ 4 ]     [ 5 ]     [ 6 ]         │  sin letras ABC (guantes)
│     [ 7 ]     [ 8 ]     [ 9 ]         │  sin eco del dígito
│               [ 0 ]     [ ⌫ ]         │
└──────────────────────────────────────┘
 Débil: «Elegí uno menos fácil de adivinar.» (#A03030)
 Paso 2 distinto: «Los PIN no coinciden. Probá de nuevo.»

D3-c  Desbloqueo con PIN (error)
┌──────────────────────────────────────┐
│              ( 🔒 )                   │
│  Ingresá tu PIN de la app             │
│  Protege el acceso a la app en este   │
│  teléfono. No necesita conexión.      │
│       ●   ●   ○   ○   ○   ○           │  llenos #0F6E56
│  PIN incorrecto. Te quedan 4 intentos.│  #A03030; sacudida de 8 px en 300 ms
│  Lo pendiente se conserva.            │  (solo texto con «reducir movimiento»)
│        [ teclado 3×4 ]                │
│  Olvidé mi PIN                  [ ⌫ ] │
└──────────────────────────────────────┘
 Desde el 6.º error: «Esperá 30 s para volver a probar» con un contador
 en la misma tarjeta.
 «Olvidé mi PIN» sin red: «Para crear un PIN nuevo necesitás conexión
 e ingresar con tu cuenta. Tus pendientes se conservan.»

D3-d  PIN deshabilitado (10.º error)
┌──────────────────────────────────────┐
│              ( 🔒 )                   │
│  Ingresá con tu cuenta                │
│  Por seguridad se desactivó el PIN.   │
│  Lo pendiente se conserva y se envía  │
│  cuando ingreses.  Por enviar: 3      │
│ ┌──────────────────────────────────┐ │
│ │     Ingresar con mi cuenta       │ │  sin red: deshabilitado, con
│ └──────────────────────────────────┘ │  «Necesitás conexión para ingresar.»
└──────────────────────────────────────┘

D4  Banda única (siempre en el mismo lugar; aviso #854F0B sobre #FAEEDA, 5,87:1)

 a) Sin red y con plazo
 │ ☁̸  Sin conexión · Por enviar: 2                                    │

 b) Quedan 24 h o menos de R2
 │ ☁̸  Sin conexión · Por enviar: 2                                    │
 │    Conectate antes del jue 18:00 para renovar tu sesión.           │
 │    Tus pendientes se conservan.                                    │
   (en las últimas 2 h: «Conectate en 1 h 40 min…»)

 c) R2 vencido (se sigue cargando)
 │ ⚠  Volvé a conectarte para renovar tu sesión · Por enviar: 3       │  texto de 054:153
 │    Lo que cargues se envía cuando ingreses con tu cuenta.          │
   En la lista, cada fila nueva muestra la marca «Se envía al ingresar».

 d) R3 vencido (corte local)
 │ ⚠  Ingresá con tu cuenta para seguir · Por enviar: 3               │
 │    Al ingresar se vuelven a descargar los datos de referencia      │
 │    (necesita conexión).            [ Ingresar ]                    │

 e) Reconexión
 │ ✓  Conectado · enviando 3…                                         │  verde #0F6E56 sobre #E1F5EE
   → «Todo enviado» y se retira a los 4 000 ms.

 Perfil: «Podés trabajar sin conexión hasta el jue 7 nov 18:00» [ Renovar ahora ]
         «Tu ingreso mensual vence el 30 nov»

D5-a  Tarjeta de versión lista (bottom sheet de M3, descartable, según R7)
┌──────────────────────────────────────┐
│  Hay una versión nueva (1.4.0)        │
│  Se aplica al reiniciar (unos 5 s).   │
│  Después te pedimos tu huella o       │  vía del PIN: «tu PIN de la app»
│  patrón. Lo pendiente se conserva.    │
│            Más tarde  [Reiniciar ahora]│  texto / relleno verde a la derecha
└──────────────────────────────────────┘  entra en 300 ms decelerate, sale en 200 ms
 Después de «Más tarde», el chip de la cabecera: [ Versión 1.4.0 lista · Reiniciar ]

D5-b  Obligatoria (variante L, pantalla completa)
┌──────────────────────────────────────┐
│              ( ↻ )                    │
│  Actualización necesaria              │
│  Descargando la versión 1.4.0         │
│  ████████████░░░░░░░░  62 % · 3,1 MB  │  barra determinada de 8 dp
│  de 5,0 MB                            │
│  Se cortó la descarga. Seguís con la  │  solo por compatibilidad
│  1.3.2 y la bajamos cuando vuelva     │  (con revocación y red: sin salida)
│  la red.  [Reintentar] [Seguir con la 1.3.2] │
└──────────────────────────────────────┘
```

## Qué cambia en la norma y en la demo

**Norma (FC):**
- **P1 (ACT/035):** apartado aditivo «Primer uso», con el tope de 10 s atado a V1S, la medida obligatoria después de una OTA, el TTID de control y el APK de release firmado. Constancia que asienta la interpretación y corrige la lectura de `E04/INFORME.md:39` y de ACT/053:22-24.
- **P2:**
  - Renglón aditivo: la decisión tardía de «versión nueva» se difiere al próximo arranque en frío, mientras que una revocación o un rollback cortan la sesión.
  - Piso contra el rollback.
  - Referencia cruzada al ADR de presentación.
- **P4 / 07:97:** **reapertura**. Pasa de «sin red se opera sin límite» a los relojes R1, R2 y R3. 07:150 cierra la evaluación de `offline_access`.
- **D-03:** ADR aditivo del PIN de respaldo, de menor nivel. La sesión sin conexión se declara AAL1.
- **ACT/054:143:** pasa de 3 s a 4 000 ms.
- **ADR nuevo «Presentación y tokens compartidos»:** tokens, movimiento, textos de seguridad y la cláusula de que la OTA no toca código nativo.
- **Operación:** procedimiento T3 para un teléfono perdido, que revoca las sesiones offline del usuario en Keycloak.

**Demo (src):**
- **Cascarón:**
  - Salvaguarda de 2 000 ms, reverificación al servir, piso y capa a los 10 s.
  - Se sacan los interruptores de E04 y el código de V2.
  - `reportFullyDrawn` en «Listo».
  - `MauiSplashScreen`.
  - `ArranquePage` pasa a ser el esqueleto.
- **`DesbloqueoPage.xaml`:** se rehace con la tarjeta y el emblema, y el error pasa a #A03030. `ContenidoPage.xaml` se alinea con el token de aviso. ResourceDictionary con los tokens.
- **Auth:**
  - `PinPage` nativa, sin pasar por el WebView.
  - Segunda vía de clave en `CofreDeSesion`.
  - Puerta de dos escalones en `PuertaDeSesion.razor`.
  - `BloqueoTrasSegundoPlano` pasa a 15 min.
  - Reloj de último contacto resistente a cambios de fecha.
  - Estados R2 y R3 en la máquina de sesión, con la marca en las filas nuevas.
  - «Renovar ahora».
- **Datos:**
  - T1: outbox cifrado con una clave AES del AndroidKeyStore sin autenticación de usuario (nunca con la clave del PIN).
  - T2: `allowBackup="false"`, o `dataExtractionRules` y `fullBackupContent` que excluyan la base, el cofre, el contador y el reloj.
- **Keycloak de ensayo:** `offline_access`, Idle de 14 días, Max Limited activado y Max de 30 días.
- **Receptor:** cuarentena para las filas de cuentas revocadas.

## Orden de implementación

Va en un expediente nuevo, con un PR por paso:

1. **ADR «Presentación y tokens compartidos» (D5.4)**, con la cláusula de que la OTA no toca código nativo. Es la base de todas las pantallas.
2. **T2 y T1:** copia de seguridad cerrada y outbox cifrado. D3 y D4 se apoyan en esto.
3. **Medida de D1:** script de primer uso, régimen, OTA y TTID, más `reportFullyDrawn`. Primera constancia con la base actual.
4. **D2 junto con D5.5, en un solo PR sobre `ArranquePage`:** V1, V1S y la salvaguarda reimplementadas; esqueleto igual a la capa; splash; pruebas en Gate. Antes, el hallazgo de los 30 s se asienta con su folio.
5. **Palancas de margen:** globalización invariante, caché de código wasm y carga diferida. Se mide hasta que el máximo de 5 corridas quede en ≤ 5 000 ms.
6. **D4,** después de que el PO confirme la reapertura de P4. Si no la confirma, va la alternativa sin corte.
7. **D3:** puerta, `PinPage`, PBKDF2 con su medida en el g42, contador firmado y migración al SO.
8. **D5.1 a D5.3:** tarjeta según R7 con chip, variante L en sus dos tipos y textos por vía.
9. **Constancia final en el g42 y prueba con 5 usuarios**, incluida la tarea del día 8.

## Cómo se verifica

| Decisión | Prueba | Criterio |
|---|---|---|
| D1 | En el g42, con el APK de release: `adb uninstall` + `install` + `am start -W`, 3 veces; 5 corridas en frío; 3 corridas después de una OTA con otro `.wasm` | Primer uso ≤ 10 000 ms; régimen ≤ 5 000 ms (o el margen que falte, declarado); TTID ≤ 5 000 ms en todas |
| D2 | Gate con el actualizador simulado, una captura cada 500 ms: (a) versión nueva a los 31 s; (b) revocación a los 31 s; (c) rollback a los 31 s con una versión marcada; (d) «Listo» que nunca llega | (a) Contenido en ≤ 2 000 ms más el render, sin cuadro en blanco. (b) El contenido revocado se retira en ≤ 2 000 ms. (c) No se sirve la versión marcada. (d) La capa con acciones es visible a los ≤ 10 s |
| D3 | Unitarias: derivación, lista de rechazo, contador firmado, esperas y deshabilitado al 10.º. En el emulador sin bloqueo y con API 29: alta, errores, desbloqueo y deshabilitado. En el g42: configurar un patrón y migrar; quitarlo y llegar a `Revocada` | El outbox queda intacto en todos los caminos; PBKDF2 ≤ 1 500 ms en el g42 |
| D4 | Unitarias con reloj inyectado: aviso en el día 6 + 1 s; en el día 7 + 1 s, carga aceptada y marcada; en el día 30, credenciales borradas y outbox intacto; con la hora atrasada 3 días no se gana plazo; vía del PIN con 72 h y 7 días. En el g42, con Keycloak a valores comprimidos: modo avión → aviso → vencido → reconexión → ingreso → envío | Ningún dato perdido. Las filas de una cuenta revocada llegan a cuarentena |
| T1/T2 | Copiar la `.db` fuera del teléfono; `adb backup` o la transferencia de dispositivo | No hay texto legible; la base, el cofre y el contador no viajan |
| D5 | Paridad de tokens en Gate; R7 (la tarjeta aparece una vez por versión); prueba con 5 usuarios | Sin hex divergentes; la tarea del día 8 se completa sin ayuda |

## Lo que confirma el PO

1. ¿La primera corrida después de instalar queda fuera de los 5 000 ms de P1, con un tope de primer uso de 10 000 ms atado a V1S? **Sí / No**
2. ¿La medida del primer arranque después de una OTA que cambia el `.wasm` es obligatoria para cerrar la constancia de D1? **Sí / No**
3. ¿V1 + V1S pasan a `main` reimplementadas en limpio, con la salvaguarda de 2 000 ms, rotuladas «mejora; P1 sigue sin cumplirse»? **Sí / No**
4. ¿Una revocación o un rollback por seguridad pueden cortar una sesión en curso (renglón aditivo en P2)? **Sí / No**
5. ¿La app ofrece un PIN propio de 6 dígitos cuando no hay vía del Keystore (API < 30 o sin bloqueo), después de ofrecer «Configurar bloqueo»? **Sí / No**
6. ¿La puerta del PIN aparece en el primer ingreso con red y no se descarta sin elegir? **Sí / No**
7. ¿10 intentos con esperas desde el 6.º, como propone la mesa, en lugar de 5 sin esperas? **Sí (10) / No (5)**
8. ¿El desbloqueo local pasa de 5 a 15 min en segundo plano? **Sí / No**
9. ¿Se reabre P4 (07:97) para poner un corte local a los 30 días (7 en la vía del PIN), con el outbox conservado y cifrado? **Sí / No** (con «No», R2 y R3 quedan solo como aviso)
10. ¿Al vencer los 7 días (72 h en la vía del PIN) se sigue cargando, con lo cargado marcado y validado por el servidor? **Sí / No**
11. ¿Se piden `offline_access` y en Keycloak Idle de 14 días, Max Limited activado y Max de 30 días? **Sí / No**
12. ¿Se cifra el outbox (T1) y se cierra la copia de seguridad (T2) antes de D3 y D4? **Sí / No**
13. ¿No se recarga en el login, y la aplicación al suspender queda fuera de esta entrega? **Sí / No**
14. ¿Variante L solo para la obligatoria, con salida por compatibilidad y sin salida por revocación? **Sí / No**
15. ¿Se vuelve a pedir la autenticación después de «Reiniciar ahora», avisado en la tarjeta? **Sí / No**
16. ¿El ADR «Presentación y tokens compartidos» va como ADR propio? **Sí / No**
17. ¿Percepción y fondo van en paralelo, en el orden de implementación de arriba? **Sí / No**

## Pase

- **Al PO:** las 17 confirmaciones de la sección anterior. Las preguntas 7 y 9 son las únicas con desacuerdo dentro de la mesa.
- **Después de su sí:** al arquitecto del Framework Concept, para abrir el expediente de implementación con los 9 pasos, un PR por paso.
- **Al expediente 0001:**
  - Asentar con su folio el hallazgo de los 30 s de la revisión de 052.
  - La constancia de D1, que corrige la lectura de `E04/INFORME.md:39` y de ACT/053:22-24.
  - La prueba en el g42 que sigue pendiente del 054: ingreso, «Bloquear» y desbloqueo con el patrón.
- **A la mesa de medición:** el costo de PBKDF2 en el g42, la caché de código wasm con `shouldInterceptRequest` y el primer uso después de una OTA. Las cifras estimadas no se citan como medidas hasta tener esa corrida.
- **Pendientes de verificar:**
  - La semántica del Max de Keycloak y su valor por defecto.
  - La clasificación de Play y de App Store para los DLL de Mono-wasm.
  - Que `ACTION_BIOMETRIC_ENROLL` no requiera `REQUEST_PASSWORD_COMPLEXITY`.
  - La restauración de la Activity de MAUI.
  - Si MAUI lee «reducir movimiento».
  - El splash actual en el g42.
  - Cómo marca hoy el puntero las cargas fallidas.
  - La estimación de unos 6 días de fuerza bruta con root.
  - Los textos de m3.material.io y de Apple HIG *Launching*.
  - Si `main` sin V1S sirve algo verificado en una instalación limpia.

## Fuentes

**Rendimiento y arranque**
- Play Console, Android vitals, tiempo de arranque: https://support.google.com/googleplay/android-developer/answer/9844486
- Android vitals, launch time: https://developer.android.com/google/play/vitals/launch-time
- App startup time (TTID, TTFD, `reportFullyDrawn`): https://developer.android.com/topic/performance/vitals/launch-time
- Baseline Profiles: https://developer.android.com/topic/performance/baselineprofiles/overview
- ART, configuración: https://source.android.com/docs/core/runtime/configure
- WWDC19 423, *Optimizing App Launch*: https://developer.apple.com/videos/play/wwdc2019/423/
- V8, *WebAssembly code caching*: https://v8.dev/blog/wasm-code-caching
- .NET MAUI, rendimiento: https://learn.microsoft.com/en-us/dotnet/maui/deployment/performance
- xamarin-android PR #6171 (AOT con perfil; no verificado para MAUI 10): https://github.com/xamarin/xamarin-android/pull/6171

**Seguridad e identidad**
- NIST SP 800-63B-4 (§2.x reautenticación, §3.2.10, §5.1): https://pages.nist.gov/800-63-4/sp800-63b.html
- OWASP MASVS-AUTH-2: https://raw.githubusercontent.com/OWASP/masvs/master/controls/MASVS-AUTH-2.md
- OWASP MASTG-TEST-0247: https://raw.githubusercontent.com/OWASP/mastg/master/tests-beta/android/MASVS-RESILIENCE/MASTG-TEST-0247.md
- OWASP MASTG-KNOW-0001: https://raw.githubusercontent.com/OWASP/mastg/master/knowledge/android/MASVS-AUTH/MASTG-KNOW-0001.md
- OWASP MASTG-BEST-0036: https://mas.owasp.org/MASTG/best-practices/MASTG-BEST-0036/
- OWASP Password Storage Cheat Sheet: https://cheatsheetseries.owasp.org/cheatsheets/Password_Storage_Cheat_Sheet.html
- Android, `KeyGenParameterSpec.Builder`: https://developer.android.com/reference/android/security/keystore/KeyGenParameterSpec.Builder
- Android, autenticación biométrica: https://developer.android.com/identity/sign-in/biometric-auth
- Android, copia de seguridad automática (no abierta en esta corrida): https://developer.android.com/identity/data/autobackup
- Microsoft Intune, protección de apps en Android: https://learn.microsoft.com/en-us/intune/intune-service/apps/app-protection-policy-settings-android
- Keycloak, offline access: https://www.keycloak.org/docs/latest/server_admin/index.html#_offline-access
- Red Hat build of Keycloak 26.4, sesiones: https://docs.redhat.com/en/documentation/red_hat_build_of_keycloak/26.4/html/server_administration_guide/managing-user-sessions
- Política de Play sobre abuso de dispositivos y redes: https://support.google.com/googleplay/android-developer/answer/9888379
- Comunidad de Esri, Field Maps sin conexión: https://community.esri.com/t5/arcgis-field-maps-questions/how-do-i-log-into-field-maps-when-offline/td-p/1179441/page/2

**Experiencia de usuario y flujo**
- Android, actualizaciones dentro de la app: https://developer.android.com/guide/playcore/in-app-updates
- CodePush, API: https://github.com/microsoft/react-native-code-push/blob/master/docs/api-js.md
- Expo Updates: https://docs.expo.dev/versions/latest/sdk/updates/
- Ciclo de vida del service worker: https://web.dev/articles/service-worker-lifecycle
- NN/g, tiempos de respuesta: https://www.nngroup.com/articles/response-times-3-important-limits/
- NN/g, pantallas esqueleto: https://www.nngroup.com/articles/skeleton-screens/
- NN/g, esperas e interrupciones: https://www.nngroup.com/articles/designing-for-waits-and-interruptions/
- NN/g, diálogos modales y no modales: https://www.nngroup.com/articles/modal-nonmodal-dialog/
- Iqbal y Bailey, CHI 2005: https://www.interruptions.net/literature/Iqbal-CHI05-p1489-iqbal.pdf
- WCAG 2.2.1: https://www.w3.org/WAI/WCAG22/Understanding/timing-adjustable.html
- WCAG 2.2.5: https://www.w3.org/WAI/WCAG22/Understanding/re-authenticating.html
- WCAG 2.2.6: https://www.w3.org/WAI/WCAG22/Understanding/timeouts.html

**Diseño estético**
- Android, splash screen: https://developer.android.com/develop/ui/views/launch/splash-screen
- Apple HIG, Launching (texto no verificado): https://developer.apple.com/design/human-interface-guidelines/launching
- Apple HIG, Alerts: https://developer.apple.com/design/human-interface-guidelines/alerts
- Apple HIG, Digit entry views: https://developer.apple.com/design/human-interface-guidelines/digit-entry-views
- M3, indicadores de progreso: https://github.com/material-components/material-components-android/blob/master/docs/components/ProgressIndicator.md
- M3, diálogos: https://github.com/material-components/material-components-android/blob/master/docs/components/Dialog.md
- M3, movimiento: https://github.com/material-components/material-components-android/blob/master/docs/theming/Motion.md
- Compose, `SnackbarHost`: https://raw.githubusercontent.com/androidx/androidx/androidx-main/compose/material3/material3/src/commonMain/kotlin/androidx/compose/material3/SnackbarHost.kt
- Material, banners: https://material.io/components/banners
- SAP Fiori, banner: https://www.sap.com/design-system/fiori-design-android/v26-4/components/feedback/banner/usage

**Repos (rutas relativas)**
- ACT/035, 049, 050, 052, 053, 054
- `E04/INFORME.md`, `E04/e04-V1-am-start.txt`, `E04/e04-V1S-am-start.txt`
- `FC/07-Red-Y-Autenticacion.md`, `demo/DISENO-RED-Y-AUTENTICACION.md`
- `src/FrameworkConcept.Shell/Auth/CofreDeSesion.cs`, `src/FrameworkConcept.Shell/Auth/DesbloqueoPage.xaml`, `src/FrameworkConcept.Shell/Pages/ArranquePage.xaml`, `src/FrameworkConcept.Shell/Pages/ContenidoPage.xaml`, `src/FrameworkConcept.Shell/Hosting/ServidorDeContenido.cs`, `src/FrameworkConcept.Shell/Data/DbSqlite.cs`, `src/FrameworkConcept.Shell/FrameworkConcept.Shell.csproj`, `src/FrameworkConcept.Shell/Platforms/Android/AndroidManifest.xml`
- `src/FrameworkConcept.Core/Auth/Oidc.cs`, `src/FrameworkConcept.Core/Auth/Sesion.cs`
- `src/FrameworkConcept.Content/Auth/PuertaDeSesion.razor`, `src/FrameworkConcept.Content/wwwroot/css/app.css`, `src/FrameworkConcept.Content/FrameworkConcept.Content.csproj`