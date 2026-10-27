| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-10-25 |
| Autor | Comisión Integración, PR, versionado y pruebas (ronda 2) |
| Corrige | — |

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-10-25 |
| Autor | Comisión Integración continua, PR, versionado y pruebas (ronda 2) |
| Corrige | — |

# Informe de comisión, ronda 2: integración continua, PR, versionado y pruebas

| Campo | Valor |
| --- | --- |
| Rol | Comisión «Integración continua, PR, versionado y pruebas» · **Ronda 2** · preguntas P6, P7 y P8 |
| Fecha | 2026-10-25 |
| Carta | `evidencia/023-carta-r2-devops-integracion-y-pruebas.md` |
| Clase de objeto | Diseño de una norma o decisión. Objeto de esta ronda: el dictamen de la ronda 1 (folio 021) frente a I0–I7 |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | Líneas 1–111 (cabecera y §0 con el «Mapa de carga»). Por la fila «Sos una comisión»: la carta (§5.2), §2.2 (con su subsección), §3.2, §3.3 y §4 |
| Documentos cargados con versión | `Cadena-De-Consecuencias` 2.0: §2 y §3 · `Escalas-De-Juicio` 1.0: §3.3 · `Versionado-Producto-Integral` 2.0 (VPI): cabecera, §0, §2.6, §3.2 y §5.7, por respaldo, porque el dictamen la invoca en P3, P7 y P8 y mis hallazgos la citan · `Rule-Mesa` 1.0: no la cargué (ninguna remisión de mi acto la pide) · `Excepcion-A-Un-Conocimiento` 2.0: **no la cargué**. No propongo dejar de seguir ninguna convención; ver la opción (b) de P7 en §3, que descarto justamente porque exigiría una ficha |
| Insumos leídos | Evidencia 001 desde la línea 4. Folios 003 a 007 y 022. Del folio 021: cabecera, §1, §2.6, las premisas de §5, P2, P3, P6, P7, P8, P11, P12, P13, §6 y §7. Folio 015 (mi informe de la ronda 1), líneas 1–120. R4 §5.1–§5.5. I0 entero. I2 §3.2 y §5. I3 §6. I4 §3.5 y §6. I5 §6. I6 §5. I7 §3 (Expo y Capacitor), §5 y §6 |
| Fuentes primarias releídas hoy (WebFetch, 2026-10-25) | Expo, «Error recovery» (I0[37]); Expo, «Fingerprint» (I0[38]); Capgo, «Compatibility» (I0[46]) |
| Medios propios | Un contenedor efímero `fc-r2-dev-*` sobre la imagen del runner (`runner-github-dev/dotnet-maui:2.338.1`). Los intermedios quedaron en `~/fc-work/r2-dev` y se borraron al terminar. **API de GitHub: no la usé.** No toqué el g42 ni el emulador. No hubo commits |

## Medición propia de esta ronda (E1)

| Id | Comando (resumido) | Salida |
| --- | --- | --- |
| M2-1 | `docker run fc-r2-dev-probe … runner-github-dev/dotnet-maui:2.338.1`: `uname -sm; dotnet --version; dotnet workload list; python3 --version; dotnet new maui -n Probe` | `Linux x86_64`. SDK `10.0.402`. Un solo workload instalado: `maui-android 10.0.110/10.0.100`. `Python 3.12.3`. La plantilla trae `Platforms/iOS/Info.plist` y `Platforms/Android/AndroidManifest.xml` |
| M2-2 | `fc-r2-dev-gate`: `python3 check_catalog.py catalogo.json AndroidManifest.xml Info.plist`. Un guion de 20 líneas (`plistlib` + `ElementTree`) con un catálogo de dos entradas (`network.status`; `camera.capture` → `android.permission.CAMERA` y `NSCameraUsageDescription`), corrido sobre la plantilla sin tocar | **Rojo provocado:** `ROJO android camera.capture: falta android.permission.CAMERA` · `ROJO ios camera.capture: falta NSCameraUsageDescription en Info.plist` · `exit=1` |
| M2-3 | Igual que M2-2, después de agregar las dos declaraciones | `rc 0` · `exit=0` |
| M2-4 | Igual contenedor: `dotnet workload search ios` · `dotnet build -f net10.0-ios` | La búsqueda de `ios` vuelve vacía. El build da `error NETSDK1178: … workload packs that do not exist … Microsoft.iOS.Sdk.net10.0_27.1 … You may need to build the project on another operating system` |

Lectura: en el runner Linux, la comprobación del Info.plist **fuente** corre y se pone en rojo. Lo que no corre es
compilar `net10.0-ios`, y con eso todo lo que depende de esa compilación (ver H-06).

---

## 1. Qué del dictamen r1 confirma la investigación y qué contradice

### P6. Procedimiento de PR e integración

| Punto del dictamen (F021, P6) | Investigación | Primaria | Lectura |
| --- | --- | --- | --- |
| Piezas 1–4: protección de `main`, un único check `fw-ok`, sin `paths`, el runner con guardas | Ningún dossier trata la protección de rama, los checks requeridos ni los runners. I3 §6 lo dice expresamente («Este ángulo no aporta») | — | **Ni confirma ni contradice.** Siguen en pie con el fundamento de la ronda 1 (doc de GitHub, E1 M-1 a M-13). No hay nada nuevo que las refute |
| Qué gobierna la compuerta | I7 §6, P6: «Compuerta de CI que falla si el contrato nativo cambió sin cambiar la clave (`--fail-on-incompatible`, fingerprint)». I5 §6, P6–P8: «La falla de producción más contada es contenido que llama algo que el cascarón instalado no tiene» (HECHO + OPINIÓN) | Capgo, *Compatibility* (I0[46], releída hoy): «the upload fails with a non-zero exit and nothing is shipped»; «Keep the flag on everyday OTA CI»; «Gate your release pipeline on this». Expo, *Fingerprint* (I0[38], releída hoy): un hash «derived from hashing app dependencies, custom native code, native project files, and configuration», «for use in determining compatibility between the native layer and JavaScript layer» | **Contradice por omisión.** Las seis piezas de P6 cuidan que nada rompa `main`. Ninguna cuida lo que la industria pone en la compuerta: que el contrato entre cascarón y contenido no cambie sin cambiar su clave. Hallazgos H-02, H-03 y H-07 |
| Merge humano, Manual 2.0 (pieza 5) | Sin aporte de I* | — | Choca con un folio del propio caso (F007), no con la investigación. Hallazgo H-01 |
| Fijar la versión de MAUI | I4 §6, P6/P8: hay regresiones entre service releases de MAUI 10 y conviene fijar la versión (OPINIÓN → criterio de I4, discusión `dotnet/maui#34171`, I0[114]) | Discusión #34171 (I0[114], OPINIÓN) | **Confirma** P11 (`global.json`, `workloadVersion` y `MauiVersion` fijados). Falta decir qué pasa cuando se sube esa versión: H-08 |

### P7. Líneas de versión

| Punto del dictamen (F021, P7) | Investigación | Primaria | Lectura |
| --- | --- | --- | --- |
| Líneas separadas: cascarón, puente, contenido, definición | I2 §5, P7: Expo y Shorebird separan «versión del binario, clave de compatibilidad (runtimeVersion/versionCode) y id del update/patch» [1][5][29]. I3 §6, P7: la definición tiene «su propia línea» (ODK). I6 §5, P7: tres líneas independientes | Expo, *Runtime versions* (I0[33]). ODK XForms, `orx:version` (I0[7]) | **Confirma** |
| El canal no es una línea de versión: es un puntero | I2 §5, P2: canales y ramas que promueven, rollout gradual | Expo (I0[33]) | **Confirma** |
| Definición: `encuestaId` + `version`, entero monótono | I0 §7, P7: `yyyymmddrr` como en XLSForm [8]. ODK sólo exige que la versión cambie en cada publicación [6] | ODK, *Managing Forms in Central* (I0[6]) | **Confirma.** Las dos gramáticas son monótonas; ODK no exige una forma en particular. El entero es más simple |
| Puente: SemVer, con «fuente única: una constante del cascarón» | I7 §6, P3/P7: «la clave se deriva del código, no se escribe a mano»; «En Expo, `appVersion` vs. `fingerprint` muestra el riesgo de atarlas a mano». I5 §3: la política `appVersion` «depende de que alguien se acuerde de subir la versión» (HECHO [1]). I2 §3.2: issue emberglow #399, «OTA safety: runtimeVersion is a hand-maintained string» (OPINIÓN, 2026-08-06) | Expo, *Fingerprint* (I0[38]), releída | **Contradice.** La industria deriva la clave del código o la ata a él con una compuerta. El dictamen la deja escrita a mano, sin nada que la ate. Hallazgos H-02 y H-03 |
| Rango con techo, `>=A.B.C <(A+1).0.0` (P3, por VPI §2.6) | I7 §5, punto 2: «la evidencia de Expo y Capgo favorece la coincidencia exacta o el piso calculado, no un rango a mano» (criterio propio de I7) | Expo `runtimeVersion` es exacta (I0[33]) | **Tensión, no contradicción.** Lo que la evidencia castiga es el número **a mano**, no el rango. Un rango con techo que se escribe a mano y no se comprueba repite la falla de emberglow. El mismo rango, comprobado contra una huella del contrato, cumple VPI y la lección. Propuesta en §3 |
| Las líneas que no controlamos | I0 §7, P7: «WebView del sistema [101] y soporte de MAUI hasta 2027-05-11 [104]» | Microsoft, *.NET MAUI Support Policy* (I0[104]) | El WebView ya está en el predicado de P3 (**confirma**). El fin de soporte de MAUI 10 y la línea de la cadena de herramientas no están en el dictamen: H-08 |

### P8. Qué se prueba en cada capa y qué es compuerta

| Punto del dictamen (F021, P8) | Investigación | Primaria | Lectura |
| --- | --- | --- | --- |
| El dispositivo y el emulador quedan fuera de la compuerta; cuarentena; rojo provocado | Sin evidencia de industria en contra | — | **Confirma** por falta de contradicción. Sigue en pie con E1 (no hay KVM, E01 §6.3) |
| «Contrato del puente … con puente simulado», en el **tramo siguiente** | I7 §6, P8: «Probar el contenido nuevo contra el cascarón **viejo** publicado». I6 §5, P6/P8 (criterio propio): «contenido N sobre cascarón mínimo declarado». I0 §7, P8: compuerta con «contenido sobre el cascarón mínimo» | Expo, *Error recovery* (I0[37]), releída: «test in a staging environment that emulates an end user's device state as closely as possible … to load the broken update and then roll back». **No habla de builds viejos ni de `runtimeVersion`** (H-09) | **Contradice el orden.** La investigación pone en la compuerta justo lo que el dictamen deja para después. La fuente primaria que se cita lo respalda menos de lo que dicen los dossiers, así que el fundamento pasa a VPI R12 (H-04) |
| Las definiciones de encuesta no figuran en la tabla de capas | I3 §6, P8 (criterio propio): «cada definición nueva se valida contra el esquema y se renderiza con el renderizador de la versión mínima soportada». I0 §3: «Central exige cambiarla [`version`] en cada publicación; tipo de campo publicado no cambia (salvo a texto)» (HECHO [6][7]) | ODK, *Managing Forms in Central* (I0[6]) | **Contradice por omisión.** Hallazgo H-05 |
| «Catálogo frente a AndroidManifest: Sí. iOS: sin compuerta». P12 descarta la prueba sobre Info.plist porque «no tiene dónde correr en el runner Linux» | Sin aporte de I* | — | **E1 en contra** (M2-2, M2-3): el Info.plist fuente se comprueba en el runner Linux. Hallazgo H-06 |

---

## 2. Hallazgos

| Id | Nivel | Ancla (E1–E4 o C) con cita | Hallazgo | Impacto | Dirección de la corrección |
| --- | --- | --- | --- | --- | --- |
| H-01 | **P2** | **E2.** F021, P6, pieza 5: «**Merge humano** según Conformacion-Pull-Request-Manual 2.0: lo hace alguien que no escribió el cambio». F007: la delegación asentada «los pull requests de esta corrida se conforman con `Conformacion-Pull-Request-Automatico` 2.0. El agente … fusiona». F021, P6, D: «desproporcionado para un **equipo chico**»; EV001:17 dice «el equipo», sin tamaño | **Lo que el dictamen da por fijo sin origen** (primer hallazgo de la carta). (a) Fija el merge humano como **única** forma, pero el expediente ya tiene la otra forma vigente y asentada: el PR que entrega la demo lo fusiona el agente. La primera historia real del repositorio contradice el procedimiento que la guía enseña. (b) «Equipo chico» descarta la merge queue sin una frase de quien pidió | El lector de la guía ve en el historial de la demo un merge que la guía prohíbe. Lecturas divergentes, de alcance acotado: el control (G3 exige al menos una corrida verde) es el mismo en las dos formas | P6, pieza 5: dos formas con un mismo control. Manual por defecto; automática sólo con delegación asentada (F007), con la guarda G1–G4 de `Conformacion-Pull-Request-Automatico` §3.3 y `fw-ok` como la corrida que G3 exige. La guía cita el PR de la demo como ejemplo de la segunda forma. «Equipo chico» sale; queda la condición de revisión medible que ya está escrita («más de N PR por día con choques de base») |
| H-02 | **P1** | **E2.** F021, P7, fila Puente: «Fuente única: **Una constante del cascarón**». La tabla de capas de P8 no tiene ninguna fila que compare el contrato con su versión. **E4.** VPI §2.6: «Detectar … Comparar la superficie declarada contra la línea base versionada en el repositorio»; R13: «`gate: línea base` para detectar». **Industria (HECHO, primaria releída):** Capgo, «the upload fails with a non-zero exit and nothing is shipped», «Keep the flag on everyday OTA CI» (I0[46]); Expo, *Fingerprint* (I0[38]). **OPINIÓN:** emberglow #399, «runtimeVersion is a hand-maintained string» (I2[33]) | La versión del puente, que es la clave de compatibilidad, se escribe a mano y **ninguna compuerta la ata al contrato**. Un PR que cambia un método o el catálogo sin subir la versión pasa `fw-ok` en verde | El predicado de P3 da por compatibles a un paquete y un cascarón que no lo son. La falla aparece en el teléfono, que es la falla de producción que más se cuenta (I5 §6). La compuerta de P6 no protege lo que el framework agrega sobre una app común | La compuerta **contrato** entra a P8 y a P6. El cascarón emite, generado desde el código, un archivo de contrato (métodos del puente con su forma, más el catálogo de P12) y su huella SHA-256. Ese archivo es la línea base versionada (VPI §2.6), una por marco (R14). Reglas: **huella distinta y versión del puente igual → rojo**; **versión distinta y huella igual → rojo** (subida vacía). Se entrega con su rojo provocado: cambiar la forma de un método sin subir la versión. En fase `diseño` corre como aviso (R13 rige desde `candidata`), y se dice |
| H-03 | **P1** | **E2.** F021, P3: «Un único método `Call(sobre)`», «Sobre con forma JSON-RPC 2.0». **E4.** VPI §2.6, «Clasificar: … **todo miembro nuevo en un tipo interfaz** es cambio mayor», y lo medido en su origen: «una línea base que no leía los miembros … dio verde ante el borrado de un miembro de la interfaz principal» | Con un puente de un solo método, la superficie pública **C#** del cascarón no cambia cuando se agrega, se quita o se reforma un método JSON-RPC. La línea base de API que VPI manda por defecto (analizador de API pública por marco) queda **ciega por diseño**: da verde siempre. Y la regla de clasificación de VPI, pensada para interfaces que el consumidor implementa, no dice nada de una tabla de métodos que el contenido sólo llama | Si se implanta VPI tal cual, la compuerta existe y nunca se pone en rojo: la compuerta de adorno de VPI §3.3 | La superficie que se pone en línea base es **la tabla de métodos del puente** (H-02), no las firmas C#. La clasificación se declara para esa tabla como un hueco de la convención, igual que T-4, sin apartarse de ella: método nuevo o campo opcional nuevo en la respuesta → menor; método quitado, parámetro obligatorio nuevo o cambio de tipo → mayor. Esta tabla es diseño del puente: va como solicitud S-1 al arquitecto |
| H-04 | **P1** | **E2.** F021, P8: «Componentes Razor (bUnit), contrato del puente y contenido WASM con Playwright y **puente simulado**: **Tramo siguiente**». P3: el predicado acepta todo cascarón con puente `>=A.B.C <(A+1).0.0`. **E4.** VPI §2.6: «“Verificado contra X” sólo se escribe si algo lo revalida; sin quién lo revalide, la frase correcta es “compatible en teoría con”»; R12. **Criterio de I6 e I7** (no es práctica medida): «contenido N sobre cascarón mínimo declarado» | El piso `A.B.C` que declara cada paquete **no lo revalida nada**. Ninguna prueba del PR compila ni corre el contenido contra el contrato de esa versión. El predicado que el teléfono evalúa promete una compatibilidad que nadie probó | Un paquete que usa un método nuevo y declara un piso viejo se activa en cascarones que no tienen ese método. El `handshake` lo detecta tarde, con el contenido ya activado: es la razón por la que P3 lo descartó como único decisor | La prueba **«contenido N sobre el piso declarado»** sube del tramo siguiente a la compuerta, en su forma barata, que corre en Linux: compilar y correr las pruebas del contenido contra el **archivo de contrato de la versión del piso** (H-02), sacado de la etiqueta del cascarón correspondiente, con un puente simulado generado desde ese archivo. bUnit y Playwright siguen en el tramo siguiente. Rojo provocado: usar un método que no existe en el piso declarado |
| H-05 | **P1** | **E2.** F021, P13, punto 1: «La definición lleva `encuestaId` y `version` propios, **que cambian en cada publicación**». La tabla de capas de P8 no tiene ninguna fila para definiciones. **Industria (HECHO):** ODK Central exige cambiar `version` en cada publicación, y el tipo de un campo publicado no cambia, salvo a texto (I0 §3, [6][7]). **Criterio de I3 §6:** validar contra el esquema y renderizar con el motor mínimo | La regla de P13 no tiene quién la haga cumplir. Tampoco hay compuerta para la forma de la definición, para la versión que tiene que subir ni para los cambios destructivos (I0 §3: borrar o renombrar campos, cambiar tipos) | Una definición editada sin subir `version` llega a los teléfonos como si fuera la misma. Las respuestas pendientes quedan atadas a un `{encuestaId, version}` que significa dos cosas distintas: es la falla P13 que el dictamen quiere evitar (Kobo, I0 §3: no se puede «distinguish a form whether it's using the old version or the updated version») | Compuerta **definiciones** en P8, sobre las definiciones versionadas de `Demo/`: (1) son válidas contra su esquema; (2) si el contenido cambió respecto de la base del PR, `version` es estrictamente mayor; (3) no hay cambio de tipo ni borrado de un campo publicado. Rojo provocado: cambiar el texto de una pregunta sin subir `version`. La misma validación corre en el servidor al publicar, como ODK. Renderizar con el motor mínimo queda en el tramo siguiente, con bUnit |
| H-06 | **P1** | **E1** M2-2 y M2-3: la comprobación del Info.plist **fuente** corre en la imagen del runner (`exit=1` en rojo, `exit=0` en verde). **E1** M2-4: `net10.0-ios` no compila (`NETSDK1178`). **E2.** F021, P12, descarte: «la prueba sobre Info.plist **no tiene dónde correr en el runner Linux**»; P8: «iOS: — No: “iOS: sin compuerta”» | El dictamen junta en un único «sin compuerta» dos cosas que el runner separa. Lo que **corre** en Linux: catálogo frente a Info.plist fuente (claves `NS*UsageDescription`) y frente a AndroidManifest. Lo que **no corre**: compilar `net10.0-ios`, el Info.plist **combinado** que produce ese build, la firma, el perfil, el analizador de API del marco iOS (Versionado-Paquetes-NuGet §2.7) y cualquier ejecución en WebKit | Hoy queda fuera la falla que P12 cita como la más dura en iOS: una clave de uso que falta y «the system terminates your app». Y se puede cubrir gratis | P8 y P12: la fila «Catálogo frente a manifiestos» cubre AndroidManifest **e Info.plist fuente**, con su rojo provocado (M2-2). «iOS: sin compuerta» pasa a decir qué queda afuera, una por una: build, plist combinado, firma, API pública del marco iOS y ejecución. La condición de revisión de P9 (job `macos-*`) sigue igual para esas |
| H-07 | **P1** | **E2.** F021, P6 y P8 sólo ponen compuertas al **PR**. P2: la firma «corre en un job aparte con *environment* protegido», sin compuerta de compatibilidad antes de publicar. **E4.** `Release-Y-Despliegue-Versionado` inv. 1 (R4 §5.2): «construido una sola vez desde un commit etiquetado». **Industria (HECHO, proveedor):** Capgo compara al subir y «Gate your release pipeline on this» (I0[46]). **OPINIÓN:** emberglow #399, `eas update` «empaqueta desde el árbol local y no desde el commit» (I2 §3.2) | La industria pone la compuerta en la **publicación** del contenido, no sólo en el PR. El dictamen no dice que el paquete se construya sólo desde una etiqueta de `main`, ni que publicar vuelva a correr el predicado contra los cascarones que están en el campo | Un paquete publicado desde una máquina, o publicado después de que cambió el conjunto de cascarones soportados, llega a teléfonos donde no puede activarse. Si no rompe nada, queda inerte; si se activa, cae en el rollback por marca. Ninguna de las dos cosas se ve antes de publicar | El job de publicación (P2) lleva su compuerta **antes de firmar**. (1) Corre sólo desde una etiqueta alcanzable desde `main` (inv. 1). (2) Recalcula el predicado de P3 contra la lista de cascarones soportados (versión del puente y catálogo de cada release del cascarón). Si **ninguno** lo puede activar, sale con código distinto de cero y no publica nada. Firmar es de Seguridad: ver S-2 |
| H-08 | **P2** | **E2.** F021, P7 no tiene una línea para la cadena de herramientas. P11 fija `global.json`, `workloadVersion` y `MauiVersion`, pero no dice cómo se sube esa versión. **HECHO:** MAUI 10 termina su soporte el 2027-05-11 (I0[104]); .NET 11 «expected in November 2026» (I0[121]). **OPINIÓN:** regresiones entre service releases de MAUI 10 (I0[114]) | Subir el SDK o MAUI cambia el **cascarón** (un release por tienda) y puede cambiar el transporte, que P3 declara parte del contrato. El dictamen no dice qué compuerta pide ese PR ni cuándo hay que hacerlo | Una migración obligada antes del 2027-05-11 sale por un PR común, con la compuerta en verde y sin probar en un dispositivo | P7: la versión de la cadena de herramientas se nombra como **atributo del cascarón**, no como línea propia. P6: un PR que cambia `global.json`, `workloadVersion` o `MauiVersion` exige una prueba en dispositivo `manual: con registro` (VPI §3.2) antes de fusionar, y la compuerta contrato (H-02) en rojo si cambió el transporte. Condición de revisión con fecha: 2027-05-11 |
| H-09 | **P3** | **E1** (WebFetch 2026-10-25 de I0[37]): Expo, *Error recovery*, habla de un staging «that emulates an end user's device state … to load the broken update and then roll back». «The page doesn't mention `runtimeVersion`», y se refiere a updates viejos, no a builds viejos. I0 §7, P8, e I7 §6, P8, lo citan como «Probar el contenido nuevo contra el cascarón viejo publicado» | La investigación le atribuye a Expo una práctica (contenido nuevo contra binario viejo) que su página no dice. La práctica es criterio de I6 e I7 | Si la guía o el dictamen citan a Expo para H-04, citan una fuente que no lo sostiene: va contra «Toda afirmación debe estar respaldada» (EV001, Reglas) | H-04 se funda en VPI R12 y se rotula «criterio de I6 e I7». La cita de Expo queda sólo para «probar el rollback en un staging que emule el estado del dispositivo», que es lo que la página dice y que el dictamen ya cubre con la prueba del corte provocado |

No hay P0: nada de lo encontrado viola una restricción dura ni hace imposible el objetivo. Son 9 hallazgos (tope: 10).

---

## 3. Propuesta por pregunta

### P6. **MODIFICAR**

Se conservan las seis piezas. Cambian dos cosas.

1. **Pieza 5 (H-01):** dos formas de merge con un mismo control. Manual por defecto; automática con delegación
   asentada y guarda G1–G4, con `fw-ok` como la corrida que G3 exige. Sale «equipo chico».
2. **Pieza 7, nueva: dos compuertas propias del framework.**
   - **Contrato**, en el PR (H-02, H-03): huella del contrato frente a la versión del puente.
   - **Publicación**, en el job de publicar (H-07): sólo desde una etiqueta de `main`, con el predicado contra los
     cascarones soportados y antes de firmar.

   Las dos entran a `fw-ok` como suites obligatorias, cada una con su rojo provocado (VPI §5.7: el flujo recorre la
   carpeta de compuertas entera).

**Cadena de consecuencias (§2) para la pieza 7, frente a dejarla en el tramo siguiente**

| Paso | Pieza 7 ahora | Tramo siguiente (dictamen) |
| --- | --- | --- |
| ¿Dónde cae? | En quien cambia el puente: un archivo generado más en el PR | En el teléfono del encuestador: un paquete activado contra un cascarón sin el método |
| ¿Cuánto pesa ahí? | Medida de tiempo: **sin medir** (pido al aplicador que la tome con el primer rojo provocado). Archivos que el cambio más frecuente obliga a tocar: el contrato generado y, si cambia, la versión del puente. Son 2, bajo el techo de 5 de VPI §3.3 | Sin medir en este caso. La industria la cuenta como la falla más común (I5 §6, OPINIÓN) |
| ¿Qué pierde la alternativa? | Un generador más que explicar al novato | La única detección antes de llegar al dispositivo |
| ¿Es reversible? | Sí: es un archivo y un paso del workflow | Un paquete publicado alcanza a terceros que ya lo bajaron: irreversible para ellos (`Cadena-De-Consecuencias` §2, paso 4) |

Decide el paso 4: entra ahora. Condición de revisión: si en N corridas ningún PR pone la compuerta contrato en rojo
salvo los rojos provocados, se revisa su costo con la medida de tiempo.

**Qué corre en el runner Linux `[self-hosted, i7infra-dev]` y qué no.** Corren: el build sin MAUI, las
unitarias, el actualizador, contrato, definiciones, catálogo frente a AndroidManifest **e Info.plist fuente**, y el
APK con el empaquetado. No corren: el build `net10.0-ios` (M2-4, `NETSDK1178`), el Info.plist combinado, la firma
iOS, la API pública del marco iOS, emulador y dispositivo (no hay KVM, R2) ni ejecución en WebKit. Cada una se
escribe `nada` o `manual: con registro` en la tabla de gobierno.

### P7. **MODIFICAR**

Opciones para la fuente de la versión del puente:

| Opción | ¿Dónde cae? | ¿Cuánto pesa? | ¿Qué pierde? | ¿Reversible? |
| --- | --- | --- | --- | --- |
| (a) Constante a mano (dictamen) | En el dispositivo, cuando alguien se olvida de subirla | Sin medir en este caso. La falla está documentada como opinión (emberglow #399) y como advertencia del proveedor (Expo, `appVersion`) | Nada en el pipeline. La detección, entera | Un paquete mal clasificado y publicado: no |
| (b) Huella exacta como clave, como `runtimeVersion`/`fingerprint` | En todo el contenido publicado: cualquier cambio del contrato, aunque sea aditivo, invalida todos los paquetes para ese cascarón | Un release de contenido por cada cascarón en el campo, en cada cambio | El rango con techo de VPI §2.6, decisión cerrada del contrato: exigiría una ficha, **y no hay contradicción que la funde** | Sí, mientras la fase sea `diseño` |
| (c) SemVer a mano **más** huella como control (H-02) | En quien cambia el puente: tiene que clasificar el cambio (menor o mayor) | 2 archivos por cambio (§3, P6) | La comodidad de no clasificar | Sí |

Propongo **(c)**. Cumple VPI §2.6 y R13 sin ficha y toma de la industria lo que la evidencia sostiene: que la clave
no quede suelta del código. Entre (b) y (c) decide el paso 3: (b) pierde el rango y pide una excepción por conveniencia,
que `Mesa-De-Expertos-A-Pedido` §4 no admite. Además, P7 suma la cadena de herramientas como atributo del cascarón,
con fecha de revisión el 2027-05-11 (H-08). El resto de la tabla de P7 se confirma.

### P8. **MODIFICAR**

Filas que se agregan o cambian en la tabla de capas, todas en la compuerta y todas con su rojo provocado:

| Capa | Rojo provocado | Hallazgo |
| --- | --- | --- |
| Contrato: huella frente a la versión del puente, por marco | Cambiar la forma de un método sin subir la versión | H-02, H-03 |
| Contenido N compilado y probado contra el contrato del **piso** declarado, con un puente simulado generado | Usar un método que no existe en el piso | H-04 |
| Definiciones: esquema, versión estrictamente mayor si cambió el contenido, sin cambios destructivos | Editar una pregunta sin subir `version` | H-05 |
| Catálogo frente a AndroidManifest **e Info.plist fuente** (reemplaza la fila actual) | M2-2 | H-06 |

«iOS: sin compuerta» pasa a la lista explícita de §3, P6. El resto de P8 se confirma (dispositivo y emulador
afuera, cuarentena, bUnit y Playwright en el tramo siguiente).

---

## 4. Lo que revisé y está bien

1. **`fw-ok` estricto, con `skipped` en rojo salvo omisiones con motivo** (F021, P6, pieza 3). Coincide con VPI §5.7
   («Un paso que no pudo correr no deja verde») y con el invariante 13. La investigación no trae nada en contra.
2. **Dispositivo y emulador fuera del check requerido** (F021, P8). Se apoya en E1 (sin KVM; WebView 83 en el
   emulador API 30) y ninguna fuente de I0–I7 lo contradice. Lo que la industria pide en dispositivo, el staging de
   Expo (I0[37]), es manual y al etiquetar, como ya está.
3. **Líneas separadas para cascarón, puente, contenido y definición, con el canal como puntero** (F021, P7). Coincide
   con Expo y Shorebird (I2 §5, P7) y con ODK (I0[7]).

---

## 5. Solicitudes de convocatoria

| Id | A quién | Señal | Ubicación |
| --- | --- | --- | --- |
| S-1 | Arquitecto MAUI | Con un puente de un solo método `Call(sobre)`, la superficie que se pone en línea base y la regla que clasifica un cambio como menor o mayor no están definidas. VPI clasifica tipos interfaz C# y no alcanza a la tabla de métodos JSON-RPC. Hace falta que el cascarón **genere** el archivo de contrato (métodos con su forma, más el catálogo) que las compuertas H-02 y H-04 leen | F021, P3, «Puente»; VPI §2.6, «Clasificar»; H-03 de este folio |
| S-2 | Seguridad del canal y tiendas | La compuerta de publicación (H-07) tiene que correr **antes** del job de firma con *environment* protegido, y el job de firma sólo debe aceptar artefactos de una etiqueta de `main`. El orden entre «verificar compatibilidad» y «firmar» no está escrito | F021, P2, «Custodia de la clave», «Producción» |

**Obstáculos de una línea** (no son escaladas):

- Para quien aplica: medir el tiempo de pared de las compuertas contrato y definiciones en `i7infra-runner-dev`
  cuando corra su primer rojo provocado. Hasta entonces, el paso 2 de la cadena de P6 queda «sin medir».
- Sigue pendiente lo de la ronda 1: que un administrador de `hdcm-dev` lea el grupo del runner (`DEV` M-7, 403).

Sigue: refutador y jurado de la ronda 2 · presidencia · Cierra con: folio informe del jurado de veredicto r2

Sigue: incorporación del siguiente informe y resolución · presidencia
