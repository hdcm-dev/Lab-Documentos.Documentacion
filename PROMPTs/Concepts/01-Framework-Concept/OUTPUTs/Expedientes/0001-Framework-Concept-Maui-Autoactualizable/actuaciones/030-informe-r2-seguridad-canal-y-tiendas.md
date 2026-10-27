| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-10-25 |
| Autor | Comisión Seguridad del canal y tiendas (ronda 2) |
| Corrige | — |

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-10-25 |
| Autor | Comisión Seguridad del canal de actualización y políticas de tiendas (ronda 2) |
| Corrige | — |

| Campo | Valor |
| --- | --- |
| Rol | Seguridad del canal de actualización y políticas de tiendas · comisión variable · **Ronda 2** |
| Fecha | 2026-10-25 |
| Carta | `evidencia/022-carta-r2-seguridad-canal-y-tiendas.md` |
| Norma | `<base de conocimiento>/Knowledges/Knowledge-Mesa-De-Expertos-A-Pedido.md` 3.1 |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | Cabecera y §0 (líneas 1–111). Por la fila «Sos una comisión» del Mapa de carga: la carta (§5.2), §2.2 (con su subsección), §3.2, §3.3 y §4 |
| Documentos cargados | `Cadena-De-Consecuencias` 2.0: §2 (la carta lo pide antes de recomendar) · `Escalas-De-Juicio` 1.0: §3.3 y §3.4, por remisión de la carta y de §3.2 · `Excepcion-A-Un-Conocimiento` 2.0: **no cargado** (no propongo dejar de seguir ninguna convención; no hay fichas) · `Mesa` 1.0: no cargado (sólo citado por los textos que leí) |
| Objeto | Dictamen de la ronda 1 (folio 021), puesto frente a I0–I7 |
| Insumos leídos | Pedido (evidencia 001 desde la línea 4); folios 003, 004, 005, 006, 007, 021 entero, 022; `despacho/r2-jurado-composicion.md`; I0 entero; I2 entero; I4 §2, §3.4, §3.5 y §5; I5 §3.4–§3.5 y §5 (por `grep`); I7 §3.8; folio 016 (informe r1 de esta comisión) §2–§3, sólo para el fundamento de ítems que el dictamen dejó caer; E01 `INFORME.md` (por `grep`, líneas 47, 100, 151–152, 264, 270) |
| Medios propios | Descarga de fuentes primarias con `curl -sL -A 'Mozilla/5.0'` el 2026-10-25 (20:40–20:41 -03:00), texto extraído con `python3 -I` (quitar etiquetas): Apple *App Review Guidelines* («Last Updated: October 16, 2026», 240 818 bytes, sha256 `a13a190c3438900e6e1ece0e3236ba5f2ef2a46c5fbfd5e15b07f30aff91df24`); Google Play Console Help 9888379 *Device and Network Abuse* (sha256 `68c2e417cfa5616beed99e58cd9220f234569cdc5cd42cc215434e66ea6174c3`), 9888170 *Permissions and APIs that Access Sensitive Information* (sha256 `4f129d2cf3aa7ca2cae8e02f0986d467f2255619fe12acccfa795c24b6a87a88`) y 10787469 *Provide information for Google Play's Data safety section* (sha256 `064770c4008814cb1cb22f5a986d8c865293386555aa854db3bc71e39bf95d74`). Volcados en `~/fc-work/r2-seg/`, **borrados al terminar** (la carta lo pide); quedan las huellas y los extractos citados abajo. `grep -c` sobre el folio 021. Ningún dispositivo, ningún emulador |
| Rótulo | No nombra el repositorio privado de la app de referencia, hosts, direcciones ni series de dispositivos |

# Informe de Seguridad del canal y tiendas — ronda 2 del expediente 0001

## Índice

1. [Qué del dictamen r1 confirma la investigación y qué contradice](#1-qué-del-dictamen-r1-confirma-la-investigación-y-qué-contradice)
2. [Hallazgos](#2-hallazgos)
3. [Propuesta por pregunta](#3-propuesta-por-pregunta)
4. [Lo que revisé y está bien](#4-lo-que-revisé-y-está-bien)
5. [Solicitudes de convocatoria](#5-solicitudes-de-convocatoria)

Abreviaturas: `021:n` = línea n del folio 021 (dictamen r1); `EV001:n` = línea n de la evidencia 001 (pedido);
`F003:n` = línea n del folio 003. `[Apple-RG]` = Apple, *App Review Guidelines*, «Last Updated: October 16, 2026»,
https://developer.apple.com/app-store/review/guidelines/ (leída por esta comisión, huella arriba). `[Play-DNA]`,
`[Play-PERM]`, `[Play-DS]` = las tres páginas de Play Console Help de la cabecera, leídas por esta comisión.
`I0[n]` = fuente n de la lista consolidada de I0 §8.

**Datos E1 sobre el objeto** (`grep -c -- <término> 021-informe-jurado-veredicto.md`): `AOT` → 0; `rotar` → 0;
`revoc` → 0; `Revoc` → 0; `Shiny` → 0; `Data safety` → 0; `privacidad` → 0; `expires` → 2 (líneas 396 y 400);
`4\.7` → 1 (línea 714, sólo en P9).

---

## 1. Qué del dictamen r1 confirma la investigación y qué contradice

### 1.1 P1 (tiendas)

| Punto del dictamen | Qué dice la investigación | Fuente primaria | Lectura |
| --- | --- | --- | --- |
| A se apoya en la excepción de Play (021:348-349) | I0 §5 e I4 §3.5 transcriben la excepción «code that runs in a virtual machine or an interpreter … (such as JavaScript in a webview or browser)» **y su continuación**: el código interpretado cargado en ejecución «must not allow potential violations of Google Play policies» | `[Play-DNA]`, leída: las dos oraciones están, en ese orden | **Confirma** la excepción; **agrega** una obligación que el dictamen no recoge (H-06) |
| Regla «función nueva de peso» con fuente «Apple DPLA §3.3.1 y App Review 2.5.2» (021:331-335) | I0 §5: 2.5.2 prohíbe código que «introduces or changes features or functionality»; DPLA 3.3.1(B) permite código interpretado si «does not change the primary purpose». I4 §3.5: Shiny funda su lectura en las dos a la vez, como proveedor interesado | `[Apple-RG]` 2.5.2, leída: «nor may they download, install, or execute code which introduces or changes features or functionality of the app». DPLA: no la leí; la tomo de I0[2] | **Contradice en parte**: 2.5.2 no dice «propósito»; la regla operativa es la del DPLA, y como lectura de 2.5.2 es la de la industria (H-03) |
| El código WASM descargado es riesgo NO VERIFICADO en iOS (021:369) | I0 §5: ninguna política nombra WebAssembly; sin casos documentados de rechazo ni de aprobación de Blazor WASM descargado [64][98] | `[Apple-RG]` leída entera por búsqueda: no nombra WebAssembly | **Confirma**. Se mantiene NO VERIFICADO: no hay fuente primaria que lo resuelva |
| IL interpretado como argumento de «interpreted code» | I0 §5 (HECHO): sin AOT, Blazor WASM corre en «a .NET Intermediate Language (IL) interpreter implemented in WebAssembly» [102]; I4 §3.5, criterio propio: tratar AOT-WASM con más cautela que IL | Microsoft Learn, *Blazor WebAssembly build tools and AOT compilation* (I0[102]; no la reabrí) | **Contradice por omisión**: el dictamen no fija «sin AOT» (E1: 0 ocurrencias), aunque el folio 016 §3, condición 4, y N1 R4 lo traían (H-04) |
| Definición de encuesta como datos, **dentro del paquete de contenido** (021:316-318) | I0 §5, implicancia (criterio del sintetizador): «la definición como datos queda fuera de la discusión de código»; I0 §1.1: las plataformas de campo bajan definiciones como datos sobre un motor de tienda y no registran rechazos (ausencia de evidencia, no evidencia de ausencia) | ODK, Dimagi (I0[5][6][20][21]), no reabiertas | **Confirma** separar datos de código; **contradice** el empaquetado conjunto (H-05) |
| Capacidades y 4.7.2 sólo como riesgo de P9 (021:714) | I0 §4: «si alcanza al contenido propio de la app es NO VERIFICADO»; riesgo de «hidden features» (I5, criterio propio a partir de Expo #1865) | `[Apple-RG]` 4.7, 4.7.2 y 4.7.3, leídas (ver §1.4) | **Confirma** que es NO VERIFICADO; **contradice** que P12 lo ignore (H-07) |

### 1.2 P2 (canal: firma, clave, rollback) frente a I2 §3.5–3.6 y Shiny

| Pieza del dictamen | Expo | Shorebird | Capgo / Capawesome / CodePush | Shiny.AppDeviceBridge | Lectura |
| --- | --- | --- | --- | --- | --- |
| Firma **obligatoria** del índice, ECDSA P-256 (021:388-389) | X.509 embebido, RSA PKCS#1 v1.5 + SHA-256; **sólo planes Production/Enterprise** (I2 §3.5, [2][5][35]) | **Opcional**, RSA (I2 [28]) | Capawesome RSA en todos los planes; Capgo híbrido RSA+AES, página inconsistente; CodePush NO VERIFICADO (I2 §3.5) | **ECDSA P-256** con clave pública compilada en el binario; «GitHub releases are not signed» (I4 §3.2, [5][6]) | **Confirma**: el algoritmo tiene precedente .NET (Shiny); hacerla obligatoria es más estricto que Expo y Shorebird |
| Conjunto de claves con `keyId` (021:390) | Un certificado | Una clave por release | — | **Una** clave | **Confirma** que nadie de la industria leída trae reserva. El dictamen **perdió** la semántica de rotación y revocación que el folio 016 H-06 proponía (H-08) |
| `expires` en el índice (021:396, 400) | No documentado en I2 | No documentado | No documentado | No documentado | Sin precedente en la industria leída; viene de TUF §5.5 (folio 016). Falta valor y quién re-firma (H-09) |
| Rollback local por marca y `Listo(version)` (021:398) | Recuperación sólo si «content appeared» no se disparó; errores después de 10 s no se capturan (I2 §3.6 [6]) | Cae a la última patch verificada (I2 [28]) | `notifyAppReady`; CodePush revierte en el reinicio y saltea las fallidas (I2 [11][21]) | **Sin rollback**: «Old releases are never reinstalled» (I4 §3.2) | **Confirma**: es el patrón `notifyAppReady` de CodePush/Capgo, más fuerte que Shiny |
| Sin rollback remoto; sólo hacia adelante (021:399) | Republicar uno anterior o `rollBackToEmbedded` (I2 [4]) | **El servidor informa patches retiradas** y el dispositivo vuelve a la anterior (I2 [29]) | CodePush `sync` saltea fallidas | Sin rollback; corregir con una versión mayor es criterio de I4, no del README | **Confirma** la monotonía de aceptación (Shiny igual). **Contradice** en un punto: Shorebird retira sin rebajar la monotonía de lo nuevo, y el dictamen, en su lugar, **bloquea** (021:421) (H-10) |
| Semilla completa, firmada igual (021:402) | Embebido en el build (I2 §2) | Release base | — | Zip base en el binario (I4 §2) | **Confirma** |

### 1.3 P9 (iOS)

| Punto | Investigación | Lectura |
| --- | --- | --- |
| iOS «diseño sin ensayo, NO VERIFICADO» (021:707) | I0 §7, P9: «Declarar iOS como riesgo abierto: datos sí, código WASM descargado en zona gris; sin observación propia (no hay Mac)» | **Confirma** |
| Riesgos nombrados: `.wasm`, 4.7.2, 4.2.3(ii), EF Core (021:712-716) | I0 §2: CodePush advierte sobre alertas en iOS (I2 §3.7 [11]); I0 §5: «no tell the user the app is updating» de Capgo es lectura de proveedor [47]; Apple 2.3.1(a) y 2.5.19 (leídas por esta comisión) | **Contradice por omisión**: falta el riesgo de divulgación ante la revisión (H-03) y 4.7.3 (H-07) |
| Cascarón en iOS: bloquear y llevar a la ficha (021:422) | I0 §1.3 [108]: «en iOS, abrir la ficha» | **Confirma** |

### 1.4 P12 (capacidades) — 4.7.2 leída contra el catálogo

| Pieza del dictamen | Texto primario leído | Lectura |
| --- | --- | --- |
| El cascarón declara en AndroidManifest e Info.plist **sólo** lo que su catálogo implementa (021:846) | `[Play-PERM]`: «You may only request permissions … that are necessary to implement current features or services in your app that are promoted in your Google Play listing. You may not use permissions … for undisclosed, unimplemented, or disallowed features or purposes.» | El catálogo es **implementación del puente**, no «feature» visible: la regla de 021:846 no basta por sí sola |
| «Una capacidad nueva entra siempre en dos tiempos: (1) release del cascarón … (2) contenido que la usa» (021:855-856) | `[Apple-RG]` 2.5.19: «Don't include any hidden, dormant, or undocumented features in your app; your app's functionality should be clear to end users and App Review.» `[Apple-RG]` 5.1.1(iii): «Apps should only request access to data relevant to the core functionality of the app» | **Contradice**: entre el tiempo 1 y el 2, el binario revisado declara un permiso para una función que todavía no existe (H-02) |
| El puente expone el catálogo al contenido descargado (021:847, 474) | `[Apple-RG]` 4.7: «Apps may offer certain software that is not embedded in the binary, specifically HTML5 and JavaScript mini apps and mini games …»; 4.7.2: «Your app may not extend or expose native platform APIs or technologies to the software without prior permission from Apple.»; 4.7.3: «Your app may not share data or privacy permissions to any individual software offered in your app without explicit user consent in each instance.» | Si 4.7 alcanza al contenido propio (NO VERIFICADO, I0 §4; se mantiene), el catálogo **es** lo que 4.7.2 condiciona y el pedido «en el uso» no es el consentimiento «in each instance» de 4.7.3 (H-07) |
| Nada se «enciende» desde el servidor | I0 §4, criterio del sintetizador: «nada se "enciende" desde el servidor si la revisión no lo vio en el binario»; I5 §5 (criterio propio a partir de OPINIÓN de layer8, HN 2024-08-04): el chequeo de versión es también la técnica para esconder funciones a la revisión | Opinión y criterio: fundan una pregunta, no un hallazgo; **el ancla del hallazgo H-02 es el texto de Apple y Play**, no esta opinión |
| Lista de capacidades por contenido | I7 §3.8 (HECHO): en Tauri, por defecto, «the API is only accessible to bundled code shipped with the Tauri App» | Precedente de un modelo que separa lo empaquetado de lo remoto; sirve a la dirección de H-07 |

---

## 2. Hallazgos

Lectura de niveles: la de la carta (F003:66-70). Anclas: `Escalas-De-Juicio` §3.3. Ningún hallazgo es heredado sin
verificar: lo que tomé del folio 016 lo abrí y lo contrasté con el folio 021 por `grep` (E1 de la cabecera).

| Id | Nivel | Ancla con cita | Hallazgo | Impacto | Dirección de la corrección |
| --- | --- | --- | --- | --- | --- |
| H-01 | P3 | **E2**: 021:302 funda la premisa «Conformidad con las tiendas» en «La lectura P0 del contrato ya la usa (F003:67)», que es texto de la presidencia; el literal del pedido está en EV001:21: «el ciclo de actualización rigido que imponen los store o distribuidores de aplicaciones como play store de google o app connect de apple» | **Lo que el dictamen da por fijo sin el origen correcto** (primer hallazgo que pide la carta): la condición de diseño se apoya en un ejemplo de lectura de la presidencia, no en la frase de quien pidió, que sí la trae | Un lector que audite el origen encuentra un círculo (la mesa se cita a sí misma) y puede leer la conformidad como agregado de la mesa y descartarla | Reanclar la premisa en EV001:21 (las apps se distribuyen por Play y App Store y el pedido quiere evitar su ciclo, no salir de ellas); F003:67 queda como lectura de nivel, no como origen |
| H-02 | **P0** | **E2** sobre el objeto: 021:855-856 «Una capacidad nueva entra siempre en dos tiempos: (1) release del cascarón por tienda, con la declaración y la entrada del catálogo; (2) contenido que la usa». **E4** por la premisa de 021:302 (condición de diseño). Contra `[Play-PERM]`: «You may only request permissions … necessary to implement **current** features … You may not use permissions … for undisclosed, **unimplemented** … features or purposes» y `[Apple-RG]` 2.5.19: «Don't include any hidden, **dormant**, or undocumented features» (más 5.1.1(iii), minimización) | El mecanismo que el dictamen prescribe publica un binario que declara un permiso (y en iOS su descripción de uso) para una función que **no existe** en lo que la revisión ve; la función aparece después, encendida por contenido descargado. Es la forma literal de «unimplemented» (Play) y «dormant» (Apple). Contraste de la regla 1 de §3.4: abrí las dos páginas y el texto del dictamen; el observable es el diseño mismo | Viola una restricción dura (lectura P0 de F003:67: «mecanismo que una tienda prohíbe»). Apple: «grounds for removal of your app from the App Store and termination of your developer account» (2.5.19); Play: acción sobre la app. El costo cae sobre terceros que ya instalaron: irreversible en el sentido de `Cadena-De-Consecuencias` §2, paso 4 | **Declaración y uso viajan juntos en el binario**: la capacidad nueva entra con el release del cascarón **y** con la semilla de ese release (que ya es «una versión completa del contenido», 021:402) que trae la función visible, descripta en la ficha y en las notas de revisión. El contenido OTA posterior sólo la evoluciona. `optional` queda para que el contenido nuevo degrade en cascarones viejos, no para anticipar permisos. Cadena en §3, P12 |
| H-03 | P1 | **E2**: 021:331-335 funda la regla operativa («cambie el propósito declarado») en «Apple DPLA §3.3.1 y App Review 2.5.2», pero `[Apple-RG]` 2.5.2 dice «introduces or changes features or functionality», no «propósito». **E2**: `[Apple-RG]` 2.3.1(a): «All new features, functionality, and product changes must be described with specificity in the Notes for Review section of App Store Connect … and accessible for review» y 2.5.19 (arriba); frente a I2 §3.7 (HECHO del proveedor Capgo, [21]): «do not mention updates, live updates, or remote updates anywhere in the app» | (a) La guía enseñaría como texto de Apple lo que es lectura: la de DPLA 3.3.1(B)(a) aplicada a 2.5.2, que es también la del proveedor interesado (Shiny, I4 §3.5, OPINIÓN de proveedor). (b) El dictamen calla sobre **divulgar** el mecanismo ante la revisión, y la práctica de un proveedor leída en la investigación es ocultarlo | Lecturas divergentes entre implementadores: uno oculta el canal siguiendo a Capgo, otro lo declara; un lector cree que 2.5.2 permite cambiar funciones sin cambiar el propósito | La guía separa las dos reglas como hizo el folio 016 H-02 con Play: 2.5.2 al pie de la letra; DPLA 3.3.1(B) como la condición que hace tolerable el código interpretado; la regla operativa rotulada **lectura** (de la industria), y iOS sigue NO VERIFICADO. Agregar al procedimiento: las **notas de revisión** describen el canal de contenido, el catálogo y el forzado (2.3.1(a)); el consejo de Capgo se cita como lo que **no** se hace |
| H-04 | P1 | **E1**: `grep -c AOT 021-informe-jurado-veredicto.md` → 0. **E2**: folio 016 §3, P1, condición 4: «Sin AOT en el contenido (N1 R4)»; I0 §5 (HECHO, I0[102]): sin AOT, Blazor WASM corre en un intérprete de IL; I4 §3.5 (criterio propio): AOT-WASM con más cautela; E01 `INFORME.md` l.151-152: el SDK avisa «we strongly recommend using `wasm-tools`» y l.264: publicación con `wasm-tools` (AOT/relink) NO VERIFICADO | El argumento de conformidad de A (Play «interpreter», DPLA «interpreted code») descansa en que lo descargado es IL interpretado. El dictamen no lo fija como condición, y el SDK empuja a instalar `wasm-tools`, que habilita AOT. Su condición de revisión de P1 (TTFD > 5 000 ms, 021:374) invita a optimizar el arranque, y AOT es la optimización conocida | Un implementador que active AOT para cumplir el umbral cambia la clase del código descargado sin que nadie lo decida, y la guía seguiría diciendo «interpretado» | Condición de P1: **contenido sin AOT** (`RunAOTCompilation` falso o ausente), comprobada por el empaquetador; cambiarla es una decisión con su propia revisión de conformidad, no una optimización. La comprobación en CI va por convocatoria (§5) |
| H-05 | P1 | **E2**: 021:316-318: la definición «viaja **dentro del paquete de contenido** (un solo canal)»; 021:376: «una revisión real de Apple rechaza el `.wasm`. iOS pasa a B». I0 §5, implicancia (criterio del sintetizador): «la definición como **datos** queda fuera de la discusión de código»; I0 §1.1: plataformas de campo con definiciones como datos sin rechazos registrados (ausencia de evidencia) | Empaquetar la definición con el código ata el riesgo de datos al de código: cada corrección de una encuesta sale como **paquete de código** nuevo, indistinguible para un revisor, y la condición de revisión de iOS («pasa a B») no tiene camino, porque las definiciones no tienen canal propio que sobreviva a apagar el `.wasm` | Retrabajo de P2 y P13 justo en el momento de un rechazo de Apple, bajo presión; mientras tanto, más publicaciones de código de las necesarias | Mismo índice firmado y mismo verificador, pero **dos clases de entrada**: `contenido` (código) y `definicion` (datos), aceptables por separado; una corrección de encuesta publica sólo `definicion`. En iOS, el día que el código se apague, el canal de definiciones sigue. Cadena en §3, P1 |
| H-06 | P1 | **E1**: `grep -c 'Data safety'` → 0 y `grep -c privacidad` → 0 en 021. **E2**: `[Play-DNA]`: el código interpretado cargado en ejecución «must not allow potential violations of Google Play policies»; `[Play-DS]`: «Your Data safety form responses must remain accurate and complete at all times» y «You should update your Data safety section when there are relevant changes to the data practices of the app»; `[Apple-RG]` 2.3: «make sure all your app metadata, including **privacy information** … accurately reflect the app's core experience and remember to keep them up-to-date with new versions» | El único control del dictamen sobre lo que cambia sin tienda es el campo «¿cambia el propósito declarado?» de la plantilla de PR (021:331-335). Un contenido o **una definición de encuesta** (que no pasa por PR de código) puede empezar a recoger un dato nuevo —ubicación, foto, salud— sin que nadie actualice la sección Data safety ni la información de privacidad de App Store Connect | Divergencia silenciosa entre lo declarado en las tiendas y lo que la app recoge; en Play, la propia política hace responsable al desarrollador («You alone are responsible for making complete and accurate declarations») | Sumar a la plantilla de PR **y** al acto de publicar una definición un campo «¿cambia los datos que se recogen o comparten?»; si es sí, la declaración de la tienda se actualiza **antes** de promover a `prod`. La definición de encuesta tiene que pasar por ese acto aunque no sea código |
| H-07 | P1 | **E2**: 021:836-876 (P12) no menciona 4.7.2 ni 4.7.3; 021:714 nombra «el puente frente a 4.7.2» sólo como riesgo de iOS. `[Apple-RG]` 4.7.2 y 4.7.3 (texto en §1.4). I0 §4: alcance sobre contenido propio NO VERIFICADO (se mantiene) | El catálogo de P12 **es** una exposición de APIs nativas a software descargado, y su forma de pedir permiso («en el uso», 021:848-849) no es el consentimiento «in each instance» de 4.7.3. Si 4.7 alcanza al contenido propio, P12 en iOS necesita permiso previo de Apple, y P12 no lo condiciona | Un implementador de iOS aplica P12 tal cual; otro, leyendo P9, lo frena: lecturas divergentes sobre la misma pieza | P12 declara su rama iOS condicionada: mientras 4.7 no se descarte para contenido propio, en iOS el catálogo se expone **sólo** al contenido que viaja en el binario (la semilla), como el default de Tauri («only accessible to bundled code», I7 §3.8), o el permiso previo de Apple se pide y se asienta. Evento de cierre: respuesta de App Review o consulta a Apple, asentada en el expediente |
| H-08 | P1 | **E1**: `grep -c rotar` → 0, `revoc` → 0 en 021. **E2**: 021:390 «Conjunto embebido con `keyId`: la activa y una de reserva fuera de línea», sin regla de uso; el folio 016 H-06 proponía rotar «firmando con la de reserva y publicando una lista nueva» y declarar que «Revocar una clave sí exige un release del cascarón». I2 §3.5: ninguno de los productos leídos trae reserva (Expo un certificado; Shorebird y Shiny una clave) | Si el cliente acepta **cualquier** clave del conjunto, una reserva no protege contra el **compromiso** de la activa: el atacante sigue firmando índices válidos hasta que cada teléfono instale un cascarón nuevo. La reserva sólo cubre la **pérdida**. El dictamen no dice cuál de las dos cosas compra | Lecturas divergentes de implementación (aceptar cualquiera / aceptar sólo la activa / revocar por índice) y una guía que promete más de lo que el diseño da. Para teléfonos que no actualizan el cascarón el costo alcanza a terceros: irreversible (`Cadena` §2, paso 4) | Fijar la semántica: el cliente acepta sólo las claves **no revocadas**; una **revocación firmada por la reserva** retira la activa sin tienda (subconjunto de TUF §5.3, ya citado por el dictamen en 021:434); el caso «ambas comprometidas» exige cascarón y se declara. Suite del actualizador: un índice firmado con una clave revocada se rechaza (convocatoria §5) |
| H-09 | P1 | **E2**: 021:396 («Firma → `expires` → …») y 021:400 («`expires` vencido: No se acepta contenido nuevo») sin valor ni responsable; 021:428 «La firma corre en un job aparte con *environment* protegido y revisor obligatorio» | Un `expires` exige re-firmar el índice antes de que venza aunque no haya release. Con revisor humano obligatorio en cada firma, o el vencimiento es largo y no protege del congelamiento (la razón de TUF §5.5), o es corto y cada re-firma necesita una persona. Sin valor fijado, los dos extremos son lecturas válidas | Si nadie re-firma a tiempo, **todos** los teléfonos dejan de aceptar contenido nuevo —incluido un arreglo urgente o un `mandatory`— sin error visible; o el control es nominal | Fijar el valor y quién lo renueva; dos formas compatibles con el dictamen: (a) vencimiento ≥ intervalo máximo declarado entre publicaciones + margen, renovado por un job programado en el mismo *environment*; (b) separar, como TUF, una firma de «vigencia» con clave de poder acotado (sólo extiende `expires` del índice ya firmado). El valor lo cuantifica la comisión formal (convocatoria §5) |
| H-10 | P2 | **E2**: 021:399 «Rollback remoto: No existe» y 021:421 «Bloqueo: Sólo bloquea si el servidor **rechaza** la versión de contenido en uso». I2 §3.6 (HECHO del proveedor): Shorebird, «el servidor informa patches retiradas; el dispositivo las borra y vuelve a la anterior en el próximo inicio» [29]; CodePush saltea las fallidas [11]. I0 §6.1 (OPINIÓN, Mason Roy, 2026-09-30): «Rollback isn't a button.» | Un contenido que dijo `Listo` y falla después (I2 §3.6: Expo no captura errores pasados 10 s) sólo tiene dos salidas: esperar un roll-forward con firma y revisor, o **bloquear** al usuario. Falta la intermedia que la industria usa: un **retiro firmado** de esa versión, que el cliente trata como una fallida local (vuelve a `previous`, ya verificada, y la anota) sin rebajar la monotonía de lo nuevo | Pérdida acotada: horas de contenido roto o un encuestador bloqueado (contra F005) mientras se arma el roll-forward | Sumar al índice una lista firmada de versiones retiradas; efecto en el cliente = el de la marca pendiente (021:398). El «bloqueo» queda para versiones retiradas **sin** `previous` sana, y nunca sin red |

**Severidad:** un P0 (H-02), siete P1 (H-03 a H-09), un P2 (H-10), un P3 (H-01).

---

## 3. Propuesta por pregunta

### P1 (tiendas) — **MODIFICAR**

A se mantiene desde seguridad y tiendas (§4, ítem 1), con cuatro condiciones nuevas en la decisión:

1. **Contenido sin AOT** (H-04).
2. **Definición en una clase de entrada propia del índice** (H-05).
3. **Notas de revisión que describen el canal** y la regla operativa rotulada como lectura (H-03).
4. **Campo de prácticas de datos** en el PR y en la publicación de definiciones (H-06).

Cadena de consecuencias (`Cadena-De-Consecuencias` §2) de la condición 2, la única que elige entre opciones:

| Paso | Definición dentro del paquete (dictamen) | Definición como entrada propia del mismo índice |
| --- | --- | --- |
| ¿Dónde cae? | En cada corrección de encuesta, que sale como paquete de código; y en el día del rechazo de iOS, que obliga a rediseñar el canal | En el empaquetador y el cliente: una clase más de entrada, con el mismo verificador y la misma firma |
| ¿Cuánto pesa? | Sin medida propia: no hay rechazo medido. Sí medido: cada paquete de contenido pesa 9,13 MB por versión retenida (021:366, E1 de `ARQ`), contra un archivo de definición | Sin medir. Es una regla más en el orden de verificación de 021:396; la suite del actualizador la cubre con un caso |
| ¿Qué pierde la alternativa? | Pierde la separación de riesgo datos/código que la investigación marca (I0 §5) | Pierde «un solo canal» como frase simple para el principiante; el canal sigue siendo uno (un índice), con dos clases |
| ¿Es reversible? | Sí, pero su reversión llega en el peor momento (bajo un rechazo) | Sí; se puede volver a empaquetar junto sin tocar teléfonos |

Recomendación: la entrada propia, con condición de revisión comprobable: si en el primer año de la demo **ninguna**
publicación de definición ocurre sin una de contenido (API de corridas del pipeline), se vuelve a empaquetar junto.

### P2 — **MODIFICAR**

Se confirman: firma obligatoria ECDSA P-256 del índice, orden de verificación, activación atómica, rollback local por
marca, monotonía, semilla completa, sólo HTTPS (§1.2). Se agregan:

- semántica de la reserva: revocación firmada por la reserva; ambas comprometidas = cascarón (H-08);
- valor de `expires` y responsable de renovarlo (H-09);
- lista firmada de versiones retiradas; el bloqueo sólo sin `previous` sana (H-10).

Cadena de H-08, la que elige entre opciones:

| Paso | (a) Revocación firmada por la reserva | (b) Declarar que compromiso = release del cascarón |
| --- | --- | --- |
| ¿Dónde cae? | Cliente: un documento más y una regla; suite: un rojo provocado más | En los teléfonos durante la revisión de tienda y en los que nunca actualizan el cascarón |
| ¿Cuánto pesa? | Sin medir; la verificación ECDSA ya medida cuesta 1,5–8 ms (021:433) | Sin medir: el tiempo de revisión de tienda no se mide desde acá (no hay cuenta, 021:933) |
| ¿Qué pierde la alternativa? | Simplicidad para el principiante | La respuesta a un compromiso sin pasar por la tienda, que es el ciclo que el pedido quiere evitar (EV001:21) |
| ¿Es reversible? | Sí | El daño no: alcanza a quien ya instaló (`Cadena` §2, paso 4) |

Recomendación: (a). Condición de revisión: si la suite del actualizador no puede provocar el rojo «clave revocada»
en el runner pedido, se cae a (b) declarado.

### P9 — **MODIFICAR** (agregar riesgos; la decisión se confirma)

Se confirma «no se compila iOS, y se declara». La lista de riesgos de 021:712-716 suma:

- divulgación en las notas de revisión (2.3.1(a)) y funciones latentes (2.5.19) (H-02, H-03);
- 4.7.3, consentimiento por instancia (H-07);
- AOT (H-04).

Lo NO VERIFICADO de I0 §5 (WASM ante Apple, alcance de 4.7.2) **se mantiene**: leí las guías de Apple y no lo
resuelven.

### P12 — **MODIFICAR**

1. Se reemplaza «dos tiempos» por **«declaración y uso en el mismo binario»** (H-02).
2. La rama iOS queda condicionada por 4.7.2 y 4.7.3 (H-07).
3. Se confirma el resto: catálogo, `handshake`, pedido en el uso, `requires`/`optional` para degradar.

Cadena de H-02:

| Paso | Dos tiempos (dictamen) | Declaración y uso juntos (semilla con la función) |
| --- | --- | --- |
| ¿Dónde cae? | En la revisión y en la política de permisos de cada tienda; en la cuenta de desarrollador | En el calendario: la primera versión de la función nueva tiene que estar lista para el release del cascarón |
| ¿Cuánto pesa? | Texto literal: 2.5.19 prevé baja de la app y fin de la cuenta; Play prohíbe permisos para funciones «unimplemented». Sin casos medidos | Sin medir. La industria ya paga ese costo: las cinco plataformas OTA leídas dejan permisos y lo nativo a la tienda (I2 §3.4); OPINIÓN, Bret Cameron (2026-06-05): «only genuinely native changes (a new plugin, a permission, an SDK bump) need to go through the app stores» (I0 §6.1) |
| ¿Qué pierde la alternativa? | Pierde la conformidad | Pierde la posibilidad de encender una capacidad desde el servidor, que es justo lo que las dos tiendas leídas prohíben |
| ¿Es reversible? | No: un retiro de la app o de la cuenta alcanza a todos los instalados | Sí |

---

## 4. Lo que revisé y está bien

1. **A no se descarta por tiendas en Android.** `[Play-DNA]` leído: la excepción nombra «code that runs in a
   virtual machine or an interpreter», y con «sin AOT» (H-04) lo descargado es IL en un intérprete (I0[102]). La
   decisión de 021:307 se sostiene desde mi competencia, con las condiciones de §3.
2. **Firma obligatoria, ECDSA P-256, verificada antes de desempaquetar.** Es más estricta que Expo (sólo planes
   pagos) y que Shorebird (opcional), y coincide en algoritmo con el único precedente .NET (Shiny, ECDSA P-256 con
   clave en el binario) (§1.2). Servir por `WebResourceRequested`, y no por un servidor *loopback* como Shiny
   (I4 §2), deja fuera de alcance a las demás apps del teléfono.
3. **Rollback local por marca y sin rebaja remota.** Coincide con `notifyAppReady` de CodePush y Capgo
   (I2 §3.6) y con la monotonía de Shiny («Old releases are never reinstalled»). La advertencia de Expo sobre
   estado persistente (I2 §3.3) ya la cubre 021:556 («El rollback no revierte datos»).

---

## 5. Solicitudes de convocatoria

| A quién | Señal | Ubicación |
| --- | --- | --- |
| Integración, versionado y pruebas | Compuerta que falle si el contenido se publica con AOT (H-04). Rojos provocados nuevos en la suite del actualizador: clave revocada, índice vencido, versión retirada (H-08, H-09, H-10). Prueba de que cada permiso del manifiesto tenga una función en la semilla (H-02), más fuerte que la de 021:857 | 021:677, 021:857 |
| Formal (umbrales) | `expires` sin valor ni unidad; su relación con el intervalo de publicación y con el revisor obligatorio | 021:396, 400, 428 |
| Arquitectura MAUI | Dos clases de entrada en el índice (`contenido`/`definicion`) y su efecto en P3 y P13; la semilla como portadora de la primera versión de cada función que usa una capacidad nueva | 021:316-318, 402, 855-856 |
| Presidencia, para el académico editor (postergado por techo) o el lector sin contexto | La guía enseña 2.5.2 y DPLA 3.3.1(B) como una sola regla, y no enseña las notas de revisión (H-03). Es didáctica, no me corresponde | 021:331-335 |

Sigue: refutador y jurado de veredicto de la ronda 2 · presidencia · Cierra con: folio del veredicto r2

Sigue: incorporación del siguiente informe y resolución · presidencia
