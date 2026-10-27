| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-10-25 |
| Autor | Refutador (ronda 2) |
| Corrige | — |

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Rol | Refutador (núcleo permanente) · **Ronda 2**. Entra último y es el único rol que lee los informes de la ronda |
| Ronda | 2 |
| Fecha | 2026-10-25 |
| Carta | `evidencia/025-carta-r2-refutador.md` (guardada verbatim antes de empezar, con sus tres líneas de cabecera) |
| Norma | `<base de conocimiento>/Knowledges/Knowledge-Mesa-De-Expertos-A-Pedido.md` 3.1 |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | Cabecera y §0 (líneas 1–111). Por la fila «Sos el refutador» del Mapa de carga, que da lo del presidente: §1, §2 (2.1, 2.2 con su subsección, 2.3), §3 (3.1 a 3.4), §4, §5 (5.1 a 5.4), §6, §7 y §8 |
| Documentos cargados con versión | `Cadena-De-Consecuencias` 2.0, entero · `Excepcion-A-Un-Conocimiento` 2.0, §0 a §7 enteros y §8 hasta «Dentro de una mesa» (§9 y §10 no) · `Escalas-De-Juicio` 1.0: §3.3 y §3.4, por remisión de la carta («clase de ancla») · `Mesa` 1.0: §3.5.4 (votación, quórum y homogeneidad), por remisión de mi acto (la carta me manda atacar la sospecha de homogeneidad) |
| Insumos leídos | Pedido (evidencia 001 desde la línea 4); folios 003, 004, 005, 006, 007, 022 y 023; dictamen 021 entero; refutador r1 019 §1–§3 (P1–P5); análisis r1 020 §2, §3 P1, §5–§7; folio 018 §3.1–§3.2; los nueve archivos de `despacho/` de la ronda 2 (composición y ocho comisiones). Investigación: I0 líneas 1–120 y lo que cito; I1 §2 y §3.1; I6 §2; I2 y I4 en las líneas que cito |
| Medios propios | Lectura del árbol con `sed`, `grep`, `wc`. Relectura de la evidencia local de E02-R (sólo lectura). Cuatro fuentes externas abiertas con WebFetch el 2026-10-25: Apple *App Review Guidelines*; Google Play *Permissions and APIs that Access Sensitive Information*; Dimagi *Ways to Update an Application* y *Manage Application Versions*. Ningún dispositivo, ningún compilado, ningún commit |
| Rótulo | No nombra el repositorio privado de la app de referencia del PO, ni hosts, direcciones o series de dispositivos |

# Informe del refutador — ronda 2 del expediente 0001

## Índice

0. [Objetivo y lo que se dio por fijo sin pedido](#0-objetivo-y-lo-que-se-dio-por-fijo-sin-pedido)
1. [Qué del dictamen r1 confirma la investigación y qué contradice](#1-qué-del-dictamen-r1-confirma-la-investigación-y-qué-contradice)
2. [Hallazgos](#2-hallazgos)
3. [Propuesta por pregunta](#3-propuesta-por-pregunta)
4. [Lo que revisé y está bien](#4-lo-que-revisé-y-está-bien)
5. [Solicitudes de convocatoria y obstáculos](#5-solicitudes-de-convocatoria-y-obstáculos)
6. [Fichas: admitidas / no admitidas](#6-fichas-admitidas--no-admitidas)
7. [Mapa de disenso r2](#7-mapa-de-disenso-r2)

**Abreviaturas.** `021:n` es la línea n del dictamen r1; `F00n`, los folios de `actuaciones/`; `EV001`, el pedido.
Las comisiones r2 se citan por slug: `REQ`, `VER`, `LSC`, `ARQ`, `ANA` (analista), `SEG`, `DEV`, `FOR` (formal);
`JC2` es la composición r2. `I0[n]` es la fuente n de la síntesis. `VPI` es `Versionado-Producto-Integral` 2.0.

**Aprobaciones del PO que no reabro** (folio 023): P6 pasa a I1 implantado; XC-1 = C-1; iOS = diseño sin ensayo; VPI
rige. Ningún hallazgo de este folio las contradice con E1 o E2.

---

## 0. Objetivo y lo que se dio por fijo sin pedido

| Lo que se da por fijo | Quién | Origen real | Lectura |
| --- | --- | --- | --- |
| **Se actualiza el código de las pantallas** (lectura (b)) | 021:298, «Premisas»; `ARQ`, `SEG`, `VER`, `REQ` lo toman como dato en r2 | El jurado r1 lo funda en tres «literales» (021:230). Uno es genérico (EV001:21 admite las dos lecturas). Otro, F004, la propia presidencia lo clasificó como «Afirmación sobre el estado de un sistema: conjetura hasta medirla. Señala un **caso que funciona**» (F004, «Clasificación»), no como requisito. El tercero, F005 «si la encuesta cambia **o se arregla**», en la familia de encuestas es publicar una definición nueva (I1:40-41) | No es un literal: es la primera salida de §3.3 aplicada al caso de referencia del PO. Funda la decisión por otra vía, que el dictamen no escribe (R2-01) |
| **La definición viaja dentro del paquete de código** | 021:316-317 | Ninguna frase del pedido ni decisión cerrada | Ya lo señalan `ARQ` H-01, `SEG` H-05, `REQ` H-04 y `ANA` H-01, con direcciones opuestas (R2-06) |
| **Todo lo que la ronda 2 agrega es costo inevitable del framework** | Lectura implícita del conjunto de r2: cada comisión confirma A en su competencia y le suma mecanismos | Diez de los veintiún grupos de agregados existen sólo porque se baja código (§2, R2-03) | Nadie volvió a pesar P1 con ese precio |

**La solución más chica que cumple el pedido literal** sigue siendo la que el refutador r1 y el análisis r1 pusieron
sobre la mesa (C-min): Blazor Hybrid en el sentido de Microsoft —que es como EV001:15 lo nombra—, definiciones como
datos firmadas por el canal, sin red y con forzado. Cumple EV001:15, EV001:21, F005 y F006. Lo único que no cumple es
lo que el caso de referencia de F004 hace y el PO no pidió con una frase: actualizar pantallas y lógica. Esa
diferencia es una pregunta de una línea al PO, que el lote r1 no hizo (021 §6 no la trae; 020 §7 la había puesto
como condición de revisión).

---

## 1. Qué del dictamen r1 confirma la investigación y qué contradice

Sólo las preguntas que me tocan por la carta (P1, la homogeneidad y el costo de aplicar) más las que tienen disenso
entre comisiones r2. Lo demás lo cotejaron las comisiones y lo mapeo en §7.

| Pregunta | Dictamen r1 | Investigación (dossier → fuente primaria) | Lectura del refutador |
| --- | --- | --- | --- |
| **P1, la lectura (a)** | «(a) vacía el requisito», porque una app ya baja datos sin tienda (021:230) | I1:40-41: las plataformas de campo «no descargan código de pantallas: descargan **definiciones** que un motor ya instalado interpreta». CommCare separa la «aplicación» del programa: abrí Dimagi *Ways to Update an Application* (I1[29]): «The app checks for updates in the background immediately after the user logs in», «The updates are applied the next time the user logs in»; la página trata la versión de CommCare aparte | **Contradice el fundamento.** (a) es una lectura con práctica de industria detrás, no un requisito vacío. Matiz verificado: la página [29] **no** dice que la «aplicación» sean formularios, flujos y multimedia; eso lo atribuye I1:55 a [17][28][29][30], y [28] llegó truncada. Queda verificada en parte |
| **P1, la lectura (b)** | «Las pantallas y su comportamiento, además de los datos» (021:298) | I6:56-60 (HECHO): Power Apps canvas baja «la app canvas publicada (pantallas y fórmulas Power Fx)»; SAP MDK, «metadatos de la app (páginas, acciones, reglas JS)»; Salesforce FS, «diseños, **LWC**, configuración». I0, «Resumen»: «SAP MDK es la excepción parcial: baja reglas JS dentro del *bundle*» | **Confirma que (b) también tiene práctica**, en la familia empresarial que actualiza «al iniciar sesión», que es justo la que alude F004. La premisa de la carta («I1/I6 muestran que la familia de encuestas usa sólo definiciones») es cierta para I1 y **no para I6**. La industria no decide entre (a) y (b) (R2-02) |
| **P1, el modelo adoptado** | A + definición como datos, en un solo paquete (021:307-318) | I0 «Resumen» y §7 proponen «C», que es la misma pieza con la definición aparte (criterio del sintetizador, no evidencia) | **Convergencia de criterio, no verificación.** `VER` §1.1 lo dice igual. Cinco comisiones r2 leyeron la misma síntesis: su coincidencia en «definición aparte» y en «huella del contrato» viene en parte de ese insumo común (§3.2 de la norma: «la coincidencia se lee como verificación sin serlo») |
| **P1, costo de A** | +~2 s y 9,13 MB por versión; WebView ≥ 94; iOS ≥ 16.4; `.wasm` NO VERIFICADO (021:365-370) | I4 §3.6: no hay mediciones publicadas de Blazor WASM en WebView móvil; I0 «Resumen»: ninguna política nombra WebAssembly [1][2][3] | Confirma el rótulo NO VERIFICADO. La ronda 2 **sube** el costo (R2-03) |
| **P1, umbral de arranque** | «Lo medido lo cumple: 3 692–4 871 ms» con «contenido ya instalado y manifiesto sin bloquear», marcado con `reportFullyDrawn` (021:324-330) | La investigación no trata umbrales (`VER` §1.1) | **Contradice el dictamen por E1**, no por la investigación: reabrí la corrida 2 de E02-R. La consulta del manifiesto ocurre antes de crear el WebView (`t=944ms recuperar…`, `t=1345ms actualizador: al día (v1)`, `t=1606ms hybridwebview-agregado`, `t=3692ms js-marca 'primer-render v1'`) y `grep -rn reportFullyDrawn` sobre `src` de E01 y E02-R → 0. Coincide con `FOR` H-02 (R2-04) |
| **P2, forzado** | Activación en «un arranque en frío, o el fin de la encuesta en curso» (021:418) | I2:69 y I2:80-81: Capgo aplica **por defecto al pasar a segundo plano** y con `always` «aplica aun en uso activo»; I6:64: el service worker con `skipWaiting()` se activa ya | La industria **sí** activa a mitad de sesión. Contradice la frase de `ARQ` H-02 «ninguna fuente leída activa a mitad de sesión». El contraejemplo E3 de `ARQ` (la marca pendiente no cubre una activación en caliente) se sostiene igual (R2-07) |
| **P12, dos tiempos** | Capacidad nueva: release del cascarón con la declaración; después contenido que la usa (021:855-856) | Abrí las dos fuentes de `SEG` H-02. Play, *Permissions and APIs that Access Sensitive Information*: «You may only request permissions and APIs that access sensitive information that are necessary to implement current features…» y «…undisclosed, unimplemented, or disallowed features or purposes». Apple 2.5.19: «Don't include any hidden, dormant, or undocumented features in your app» | **Las citas existen y dicen eso.** Lo que no dicen: la consecuencia que `SEG` cita («grounds for removal … and termination») 2.5.19 la ata a «Attempting to hide undocumented features in your app binary, such as through code obfuscation». Es sobrelectura acotada (R2-05) |

---

## 2. Hallazgos

| Id | P0–P3 | Ancla (E1–E4 o C) con cita | Hallazgo | Impacto | Dirección de la corrección |
| --- | --- | --- | --- | --- | --- |
| **R2-01** | P1 | **E2** 021:230 (R-01 «no procede»: «la lectura (a) vacía el requisito»; F004 y F005 como literales de (b)); F004, «Clasificación»: el pasaje de la app de referencia es «Afirmación sobre el estado de un sistema … Señala un caso que funciona»; I1:40-41 y Dimagi [29] (abierta). **E4** Mesa-De-Expertos-A-Pedido 3.1 §0, renglón 1 («Una frase con dos lecturas se escribe con las dos y se toma la que menos agrega, declarada») y renglón 3 («Si hay un caso que funciona, tomarlo de referencia … la primera salida es igualar la pieza que difiere») | **El dictamen acierta la lectura por la razón equivocada.** Sus tres literales no la sostienen: EV001:21 admite las dos, F004 es un dato clasificado como caso que funciona, y F005 «se arregla» es, en la industria que el PO describe, publicar una definición. Lo que sí la sostiene es la tabla diferencial del folio 018 §3.1 contra ese caso: la columna que cambia es «dónde vive lo que se ejecuta»; A la iguala a «local» y conserva «qué se publica: la aplicación web»; C-min cambia además qué se publica y quién dibuja. Eso es la primera salida del renglón 3, que el dictamen nombra (021:340-342) pero no pone como fundamento de la premisa | Quien lea el dictamen o la guía hereda un fundamento refutable (`ANA` H-02 ya lo refutó). Si el PO dice (a), nadie le preguntó; si dice (b), la decisión estaba bien pero mal escrita | Reescribir la premisa «Qué se actualiza»: las dos lecturas con su literal; (b) se toma **por la primera salida del renglón 3** (caso de referencia del folio 004) y no por literales; se retira «vacía el requisito». La pregunta va al lote (§3, P1) con el precio de R2-03 |
| **R2-02** | P1 | **E2** I6:56-60 (Power Apps canvas: «pantallas y fórmulas Power Fx»; SAP MDK: «reglas JS»; Salesforce FS: «LWC»); I0, «Resumen» («SAP MDK es la excepción parcial»); I1:40-41. **E2** `ANA` §1.2, fila P1: «La industria llama "actualizar la aplicación" a bajar definiciones» citando sólo la familia de encuestas; carta de este despacho: «la investigación I1/I6 muestra que la familia de encuestas usa sólo definiciones como datos» | La lectura dominante de r2 sobre la industria (y la premisa de mi propia carta) vale para I1, no para I6. La familia empresarial, la que el PO alude en F004 («se actualizan internamente al iniciar un logueo nuevo»), baja pantallas y lógica interpretada dentro de un motor de tienda. **La investigación no decide entre (a) y (b)**: hay práctica documentada para las dos | Si el jurado r2 cree que la industria respalda sólo (a), vuelve a C-min por un argumento incompleto; si cree que respalda sólo (b), descarta (a) por el mismo error que el r1 | Que el dictamen r2 diga: (a) es la forma de la familia de encuestas (ODK, CommCare); (b), la de la familia empresarial (Power Apps, MDK, Salesforce) y la de las OTA. La guía presenta las dos familias como ya hace I0, «Resumen». La elección queda en la lectura del PO, no en la industria |
| **R2-03** | P1 | **E2** sobre los ocho informes r2 (tabla de abajo). **E2** `ANA` §1.1: la matriz de P1 se puntuó con los costos de r1 (A+datos 18, C-min 26). **E4** Mesa-De-Expertos-A-Pedido §2.2, clase «diseño de una norma»: «El refutador ataca el costo de aplicarla»; §7: «el defecto más caro es una ceremonia que nadie completa» | La ronda 2 confirma A en cada competencia y le **suma** mecanismos. De 21 grupos de agregados, **10 existen sólo porque se baja código** (tabla), 2 mayormente por eso y 9 valen con cualquier modelo. Ninguna comisión volvió a pesar P1 con ese precio, y la matriz que lo pesa (`ANA`) no los tiene. Para el lector del perfil de 021:737 («No conoce MAUI, Blazor WebAssembly, firma ni integración continua»), cada mecanismo es un concepto más | El jurado r2 vota P1 con un precio de r1 y los parches de r2 con el de r2: el plan sale con más ceremonia de la que se pesó. Si el PO hubiera querido (a), paga los diez grupos sin necesitarlos | (1) El jurado r2 vuelve a puntuar K-S, K-D y K-C de A+datos con estos agregados antes de votar P1 (pesos de 020 §2, sin cambiarlos). (2) La pregunta del lote lleva el precio: «(b) suma estos diez mecanismos». (3) Lo que sólo sirve a producción (revocación, `expires`, publicación) entra a la demo como «diseño, no implantado», como el dictamen ya hizo con la custodia de producción (021:428-429) |
| **R2-04** | P1 | **E4** `Mesa` §3.5.4: «Quórum de cinco. Con menos, no hay veredicto» y «Homogeneidad: si el jurado vota cinco a cero en más del 80 % de los ítems … el refutador revisa los `NO_PROCEDE`». **E2** 021:46-49 («un solo agente que aplica las cinco funciones; no son cinco agentes independientes»). **E1** corrida 2 de E02-R (extracto en §1) y `grep -rn reportFullyDrawn` → 0 frente a 021:324-330. **E2** `VER` §1.1 (021:451 «pierde la entrada en curso» es criterio, no hecho de esas fuentes); `LSC` H-06 (Play tratado como cerrado, 021:348) | **La sospecha de homogeneidad tiene evidencia.** El veredicto r1 lo dio un agente, sin quórum de jueces. Entre sus 117 `PROCEDE` hay afirmaciones adoptadas sin abrir su fuente: el «lo medido lo cumple» bajo una condición y un instrumento que la medida no tuvo (lo reabrí: el manifiesto bloqueaba y no se llamó `reportFullyDrawn`), un criterio presentado como hecho de Capawesome y CodePush, y Play dado por despejado. **Revisión de los tres `NO PROCEDE`:** R-01 debió proceder **en parte**: el defecto de declaración era real (R2-01), aunque la elección sobreviva; R-02 sigue a R-01 (con (a), la lectura de Microsoft cumple el objetivo; con (b), no); `ARQ` H-10 no procede, bien votado, pero el estado terminal con `current` y `previous` fallidas quedó sin decidir (`VER` H-04) | Un veredicto r2 hecho igual repite el patrón: lo que una comisión afirma pasa al dictamen sin contraste | Que el veredicto r2 lo voten cinco jueces despachados por separado, cada uno con su función (`Mesa` §3.5.4), o que el folio declare que no hay quórum. Que el juez de evidencia abra la fuente de cada ítem que pasa al dictamen con cifra o con cita externa. Corregir en el dictamen r2 la fila del umbral (`FOR` H-02) |
| **R2-05** | P1 (`SEG` lo declara P0) | **E2** 021:855-856 frente a 021:402 («Semilla: una versión **completa** del contenido»). **E2** fuentes abiertas: Play («necessary to implement current features», «undisclosed, unimplemented»); Apple 2.5.19 («hidden, dormant, or undocumented features»; la baja de la app se ata a «Attempting to hide … such as through code obfuscation»). **E4** `Escalas-De-Juicio` §3.4, regla 1 | **El P0 de `SEG` H-02 no sobrevive como P0.** Las citas son exactas, pero el texto del dictamen **no manda** un binario con permisos dormidos: el release del cascarón lleva su semilla, que es una versión completa del contenido y puede traer la función que usa la capacidad nueva. El dictamen admite la implementación conforme y la no conforme: es una lectura divergente, P1. Además, la consecuencia que `SEG` cita (baja y fin de la cuenta) Apple la ata a esconder funciones, no a tenerlas dormidas | Sin corregir, un implementador puede publicar el permiso antes que la función, que es lo que Play y Apple prohíben | **Se adopta la dirección de `SEG`** («declaración y uso en el mismo binario»: la semilla del release trae la función visible, descripta en las notas de revisión). **¿Cuánto cuesta cumplir?** Casi nada: una regla, y la semilla ya es completa (021:402). Con C-min el problema casi desaparece: el uso se compila en el cascarón con su pantalla |
| **R2-06** | P1 | **E2** `ANA` H-01 y §1.1: confirma «un solo canal» porque A+datos (1 canal) 18 > C de I0 (2 líneas) 14, y «C de I0» se puntuó como «una segunda línea de publicación firmada» con índice propio. **E2** `ARQ` H-01, `SEG` H-05, `REQ` H-04: proponen **mismo índice firmado, dos clases de entrada** (`contenido` y `definicion`). **E2** 021:376 («iOS pasa a B») | **Disenso sin pesar.** La matriz de `ANA` compara el paquete único con una segunda línea, pero la alternativa que tres comisiones proponen es otra (un índice, dos clases) y nadie la puntuó. `ARQ` da el argumento que decide: el actualizador vive en el cascarón, así que separar después cuesta un release por tienda y convivir con los que no actualizan (Cadena §2, paso 4), y la condición de revisión de iOS sólo tiene camino si la definición ya es entrada propia | El jurado r2 recibe dos «confirmaciones» opuestas (una de `ANA`, tres en contra) y puede votar por conteo | Adoptar «un índice, dos clases» (`ARQ` §3 P1; `SEG` §3 P1). **¿Cuánto cuesta cumplir?** Un tipo de entrada más en el índice y una regla de activación (la definición, al empezar la próxima encuesta; P13.2 ya lo dice); la suite del actualizador, un caso. Condición de revisión de `SEG`: si en la demo ninguna definición se publica sin contenido, se vuelve a juntar. La celda de peso de una definición sola sigue «sin medir» (obstáculo, §5) |
| **R2-07** | P1 | **E2** 021:411, 418 y 398 (dos reglas de activación; la marca se revisa «el arranque siguiente»). **E3** de `ARQ` H-02 (v5 obligatoria rota activada al terminar la encuesta: sin rollback hasta matar la app). **E2** I2:69, I2:80-81 e I6:64 frente a `ARQ` H-02 («Ninguna fuente leída activa a mitad de sesión»). **E2** F006 («cuando inicie la apliación actualice») | **Solución más chica para F006:** el forzado de contenido se activa **en el próximo arranque en frío, antes de mostrar, si ya está bajado y verificado**, y no hay activación en caliente (`ARQ` §3 P2). Es una sola regla de activación para todo el contenido, conserva N = 0 y el TTFD, deja la marca pendiente cubriendo todos los caminos y cumple F006 al pie de la letra («al iniciar»), un inicio después de bajarla (`ANA` CU-5 lo declara). `ANA` CU-6 y el dictamen conservan la activación al terminar la encuesta, que es la única que la marca no protege. Lo que `ARQ` afirma de la industria es falso (Capgo y el service worker sí activan en sesión), pero su contraejemplo no depende de eso | Dos implementaciones del forzado; una deja al encuestador con contenido roto y sin rollback | Quitar «o el fin de la encuesta en curso» (021:418). El bloqueo por versión rechazada y por cascarón bajo el mínimo va al mismo punto: próximo arranque en frío o próximo ingreso, nunca a mitad de una captura (`ANA` H-03, `REQ` H-08, `FOR` H-03). **¿Cuánto cuesta?** Menos que lo actual: se quita una ruta |
| **R2-08** | P1 | **E2** `DEV` H-02: «En fase `diseño` corre como aviso (R13 rige desde `candidata`)», frente a `DEV` §3 P6: las compuertas contrato y publicación «entran a `fw-ok` como suites obligatorias». **E2** folio 023, ítem 1: `fw-ok` es el único check requerido, «sin excepción para administradores». **E2** `REQ` H-06, `VER` H-03, `FOR` H-10, `ARQ` H-05, `DEV` H-02/H-04 (cinco comisiones piden detectar el cambio del contrato) | Las cinco comisiones coinciden en el **qué** (detectar que el contrato cambió sin subir la versión) y divergen en el **cuánto**: `DEV` pide un archivo de contrato **generado** desde el código, su SHA-256, dos reglas, una línea base por marco y, además, compilar el contenido contra el contrato del piso con un puente simulado generado. Y el mismo informe la deja como aviso y como obligatoria a la vez; con `main` protegido (023), una suite dentro de `fw-ok` bloquea | Lectura divergente sobre si la compuerta bloquea; y un generador más un puente simulado generado para un lector que «no conoce … integración continua» (021:737) | **La forma más chica que cumple VPI §2.6 «Detectar»:** una prueba de instantánea. La tabla de métodos del despachador de `Call(sobre)` y el catálogo se serializan y se comparan con un `contrato.json` versionado; si difieren y la versión del puente no subió, rojo; si la versión subió y no difieren, rojo. No hace falta generador ni hash propio: la instantánea es la huella. Una sola decisión sobre si bloquea: con `main` protegido (023), **bloquea**, y se dice. «Contenido N sobre el piso» queda en el tramo siguiente, salvo que su costo medido sea el de una prueba más (obstáculo de `DEV`, «sin medir») |
| **R2-09** | P1 | **E4** VPI §2.6 («todo miembro nuevo en un tipo interfaz es cambio mayor»). **E2** `ARQ` H-04 (se apoya en I7 §5, punto 1: contrato como interfaces C#, `IUbicacion`, `ICamara`) y propone declarar «agregar un método o una entrada del catálogo es menor», **sin ficha** (`ARQ` §3 P3: «No escribo ficha»). **E2** `DEV` H-03: con un solo `Call(sobre)` la superficie C# no cambia y la regla de VPI «queda ciega»; declara la clasificación de la tabla «como un hueco de la convención … sin apartarse de ella» | Las dos comisiones llegan a la misma regla de clasificación por caminos que no son equivalentes. Si el contrato se escribe como **interfaces C#** (`ARQ`, siguiendo a I7), VPI §2.6 rige al pie de la letra y declarar «menor» un miembro nuevo es **dejar de seguir una convención que rige**: exige ficha (Excepcion §3). Si el contrato es la **tabla de métodos JSON-RPC** que el dictamen ya fija (021:474), no es un tipo interfaz y la regla se completa como hueco, sin ficha (`DEV`) | Un implementador escribe interfaces C# y clasifica contra VPI sin ficha; otro, la tabla. La guía enseña una excepción no foliada | Fijar que el contrato es la tabla de métodos de `Call(sobre)` y el catálogo, **no** interfaces C# expuestas al contenido; la clasificación (método o entrada nueva = menor; quitar o cambiar forma = mayor) se declara como hueco de VPI §2.6 para ese objeto. Si alguien sostiene que hacen falta interfaces C#, escribe la ficha. **¿Cuánto cuesta cumplir?** Nada: es lo que el dictamen ya dice |
| **R2-10** | P2 | **E2** `SEG` §1.2, fila `expires`: «No documentado» en Expo, Shorebird, Capgo/Capawesome y Shiny; `SEG` H-09 (si nadie re-firma, todos los teléfonos dejan de aceptar contenido nuevo) y H-08 (revocación firmada por la reserva). **E2** 021:428 (firma con revisor obligatorio) | `SEG` encuentra bien que `expires` sin valor congela la base instalada, pero el defecto lo crea el propio dictamen con una pieza que **ningún producto leído usa**. Su corrección suma un job programado o una segunda firma de vigencia; la revocación suma un documento firmado y su lógica. Para la demo, todo eso es costo de producción | El principiante implementa una re-firma programada y una revocación antes de tener la demo andando; si falla la re-firma, la demo deja de actualizar | En la demo, `expires` con un valor declarado y renovado por un job sin revisor humano (opción (a) de `SEG` H-09); la revocación por la reserva se enseña como **diseño, no implantado**, con su rojo provocado en la suite del actualizador si cuesta un caso. La lista de retirados de `SEG` H-10 sí entra: es la misma lógica que la marca pendiente. El valor lo fija `FOR` con TUF como fuente |
| **R2-11** | P2 | **E2** `ANA` §3 P1, paso 3: «el retrabajo de equivocarse es menor con A+datos»; frente a 020 §3, P1, paso 4: «A se suma después sin tocar el canal», y a la propia celda K-V de `ANA` §1.1 (C-min 2, A+datos 2). **E4** `Cadena-De-Consecuencias` §2, paso 2 («"Un montón" y "apenas" no son medidas») | `ANA` decide el default del lote por una asimetría de retrabajo que no midió y que su propia matriz no muestra (puntúa igual la reversibilidad de las dos) | El default del lote queda fundado en una afirmación sin medida | Fundar el default en el renglón 3 de §0 (R2-01), que es regla, y dejar la asimetría de retrabajo como «sin medir». El default no cambia: (b), A+datos |
| **R2-12** | P2 | **E2** 021:197 (`ACA` H-01 r1 `PROCEDE`: «"sin experiencia" tiene dos lecturas») frente a 021:737-738 (el perfil se fija sin escribir las dos lecturas ni declarar la elegida); `LSC` H-01 r2 vuelve a encontrarlo | Un hallazgo votado `PROCEDE` en r1 no llegó al dictamen. Es otra marca del mismo patrón de R2-04: votar no es aplicar | La guía se escribe para un lector cuya elección no se declaró; si el PO quiso «sin experiencia en programación», se rehace | Aplicar `ACA` H-01 / `LSC` H-01: las dos lecturas, la elegida declarada; y el cuerpo de parches r2 coteja cada `PROCEDE` de r1 contra el texto del dictamen |

**Cuenta:** 12 hallazgos. P0: 0 · P1: 9 · P2: 3. Ninguno heredado sin abrir: lo que tomo de las comisiones lo
contrasté en su línea o en su fuente (§1). El único P0 de la ronda (`SEG` H-02) no sobrevive como P0 (R2-05).

**Tabla de R2-03: agregados de la ronda 2 y si existen sin código descargado**

| # | Agregado r2 | Comisiones | ¿Sólo por A? |
| --- | --- | --- | --- |
| 1 | Contenido sin AOT y su comprobación | `VER` H-02, `SEG` H-04 | Sí |
| 2 | Detección del cambio del contrato del puente y su clasificación | `ARQ` H-04/H-05, `DEV` H-02/H-03, `VER` H-03, `FOR` H-10, `REQ` H-06 | Sí: con C-min no hay puente hacia código descargado; el contrato es el esquema de la definición |
| 3 | Contenido N contra el contrato del piso, con puente simulado | `DEV` H-04 | Sí |
| 4 | Índice por mayor del puente | `ARQ` H-03 | Sí |
| 5 | `requires` con rango por capacidad | `ARQ` H-09, `FOR` H-09 | Sí |
| 6 | Capacidades sólo por el puente, `Permissions-Policy` y su prueba | `ARQ` H-06, `VER` H-05 | Sí |
| 7 | Rama iOS de P12 por Apple 4.7.2 y 4.7.3 | `SEG` H-07 | Sí: sin software descargado, 4.7 no aplica |
| 8 | El salto de MAUI como cambio del transporte | `ARQ` H-08 | Sí en el transporte (la fecha vale para todos) |
| 9 | `EmccMaximumHeapSize` en iOS | `VER` H-09 | Sí |
| 10 | La definición como clase propia de entrada | `ARQ` H-01, `SEG` H-05, `REQ` H-04 | Sí: con C-min la definición ya es el único artefacto |
| 11 | Dispositivo de referencia e instrumento del TTFD | `VER` H-01, `FOR` H-01/H-02 | Mayormente: el umbral existe porque A arranca en 3,7–4,9 s; C-min midió 1,6–1,7 s (021:355) |
| 12 | Declaración y uso de una capacidad en el mismo binario | `SEG` H-02 | Mayormente |
| 13–21 | Notas de revisión; revocación, `expires` y retirados; forzado y bloqueo en punto seguro; evolución de definiciones y su compuerta; pendientes al cerrar sesión; compuerta de publicación; Info.plist fuente; Data safety; retención y roll-forward de definiciones, pre-release | `SEG` H-03/H-06/H-08–H-10; `ARQ` H-02; `ANA` H-03–H-06; `REQ` H-02/H-05/H-07/H-08; `DEV` H-05–H-07; `FOR` H-03–H-08 | No: valen con cualquier modelo |

---

## 3. Propuesta por pregunta

| Pregunta | Propuesta | Cómo y con qué fundamento |
| --- | --- | --- |
| **P1** | **MODIFICAR** | (1) Premisa reescrita por R2-01: (b) por el renglón 3 de §0, no por literales; las dos lecturas escritas. (2) **Pregunta al lote**, una línea, con su precio: «¿Las correcciones sin tienda incluyen pantallas y lógica (código), o alcanza con encuestas y datos? Con (b) el framework suma los diez mecanismos de la tabla de R2-03.» **SI NO RESPONDÉS: (b), A+datos**, por el renglón 3. **Condición de revisión:** el PO responde (a), y P1 pasa a C-min con la matriz de `ANA`, A documentada como extensión con E01 y E02-R. (3) Definición como clase propia en el mismo índice (R2-06). (4) Contenido sin AOT (`VER` H-02, `SEG` H-04). (5) Fila del umbral corregida (`FOR` H-01/H-02; R2-04). (6) Nombre único y tabla de equivalencias (`REQ` H-03, `LSC` H-02, `ANA` H-09) |
| **P2** | **MODIFICAR** | Forzado: una sola regla de activación (R2-07). Bloqueos en el próximo arranque o ingreso (`ANA` H-03, `REQ` H-08). `expires` con valor y renovación sin revisor; revocación como diseño; lista de retirados (R2-10). Estado terminal con `current` y `previous` fallidas, decidido y probado (`VER` H-04). Tabla diferencial contra Shiny en la guía (`VER` H-08, `ARQ` H-07). Índice por mayor del puente (`ARQ` H-03): lo acepto, porque la ruta la lee el cascarón y cambiarla después cuesta un release |
| **P3** | **MODIFICAR** | Rango con techo confirmado (VPI §2.6; nadie propuso ficha para la clave exacta y las cinco comisiones la descartan). Detección por instantánea (R2-08). Contrato = tabla de métodos, no interfaces C# (R2-09). `requires` con rango por capacidad y un solo esquema del catálogo (`ARQ` H-09, `FOR` H-09) |
| **P4** | **MODIFICAR** | Pendientes al cerrar sesión: no se borran, quedan con su dueño (`ANA` H-05, `REQ` H-07). Versión mínima del cascarón evaluada al ingresar (`REQ` H-08). Demo sin IdP confirmada; el ingreso de dispositivo de `ANA` H-08 sólo si su costo medido es una etapa |
| **P5** | **CONFIRMAR** | Sin contradicción de la investigación (`ANA` §3, `VER` §1.2). Suma la retención de pendientes de P4 |
| **P6** | **CONFIRMAR** con lo aprobado en 023 | I1 implantado. Dos formas de merge con el mismo control (`DEV` H-01): la delegación de F007 vale para los PR de esta corrida; la guía enseña la manual como default y la automática con delegación asentada. «Equipo chico» sale. `fw-ok` bloquea: toda suite que entra a él es obligatoria (R2-08) |
| **P7** | **MODIFICAR** | Contenido sin pre-release (`FOR` H-08). Roll-forward que nunca baja la versión de una definición (`FOR` H-07). La cadena de herramientas como atributo del cascarón, con la condición 2027-05-11 (`DEV` H-08, `REQ` H-10, `VER` H-07; I4:90) |
| **P8** | **MODIFICAR** | Suman: instantánea del contrato (R2-08); definiciones contra esquema y versión mayor si cambiaron (`DEV` H-05); catálogo frente a AndroidManifest **e Info.plist fuente** (`DEV` H-06, medido en el runner); doble falla en la suite del actualizador (`VER` H-04). Contenido N sobre el piso, en el tramo siguiente salvo medida (R2-08) |
| **P9** | **CONFIRMAR** (aprobado en 023) | Suman a los riesgos nombrados: `EmccMaximumHeapSize` (`VER` H-09), 2.3.1(a) y 2.5.19 (`SEG` H-03), 4.7.3 (`SEG` H-07). Condición de revisión de iOS comprobable dentro del alcance (`VER` H-10) |
| **P10** | **MODIFICAR** | Las precisiones de `LSC` (perfil con dos lecturas, R2-12; «manifiesto» en tres términos; un lugar para la industria y para login y forzado; Play como NO VERIFICADO). La tabla de precio de R2-03 entra a la guía como «qué cuesta cada familia» |
| **P11** | **CONFIRMAR** | M2, C3 y W2 en pie; prerrequisitos de `LSC` H-09 y H-10 |
| **P12** | **MODIFICAR** | Declaración y uso en el mismo binario (R2-05). Capacidades sólo por el puente (`ARQ` H-06). Rama iOS condicionada por 4.7.2/4.7.3 mientras siga NO VERIFICADO (`SEG` H-07) |
| **P13** | **MODIFICAR** | Regla de evolución de la definición y su compuerta (`ANA` H-06, `REQ` H-05, `DEV` H-05). Retención de definiciones separada de la de paquetes: la limpieza nunca retira (`FOR` H-06). Retiro con plazo de aviso en días, valor al lote (`FOR` H-06, `REQ` H-09). Rechazar una versión de contenido no rechaza las respuestas tomadas con ella (`ANA` H-03). P13.7 se conserva con su porqué frente a I0 (`ANA` H-07, `LSC` H-07) |

**Cadena de consecuencias del default del lote en P1** (`Cadena-De-Consecuencias` §2):

| Paso | (b) A+datos por defecto | (a) C-min por defecto |
| --- | --- | --- |
| 1. ¿Dónde cae? | En el arranque, en los pisos de WebView e iOS, en la revisión de Apple y en los diez mecanismos de R2-03, que caen en quien aplica y en el lector | En el cascarón: cada pantalla o lógica nueva va por tienda (Microsoft, I4[3]) |
| 2. ¿Cuánto pesa? | TTFD 3 692–4 871 ms (E02-R) contra 1 615–1 723 ms de C-min (E02-B), 9,13 MB por versión retenida (021:366); diez grupos de agregados (contados en la tabla de R2-03). `.wasm` ante Apple: sin medida posible | El costo de una pantalla por tienda no se mide desde acá. El retrabajo de pasar de una a otra: **sin medir** en las dos direcciones (R2-11) |
| 3. ¿Qué pierde la otra? | Si el PO dice (a): pagó los diez mecanismos sin necesitarlos | Si el PO dice (b): no hay pantallas actualizables y hay que sumar A |
| 4. ¿Reversible? | Sí, sin base instalada | Sí, sin base instalada |

Las dos son reversibles y el paso 2 no tiene la medida que decidiría. **Decide la regla, no la cadena:** el
renglón 3 de §0 manda igualar primero la pieza que difiere del caso de referencia, y eso da (b). La pregunta del
lote cuesta una línea y el PO respondió el lote anterior en el mismo día (folio 023): el obstáculo es preguntar, no
decidir.

---

## 4. Lo que revisé y está bien

| Ítem | Por qué está bien |
| --- | --- |
| Rango con techo en P3, sin clave exacta | Las cinco comisiones que lo tratan (`ARQ`, `DEV`, `VER`, `FOR`, `REQ`) llegan por separado a lo mismo: la evidencia de Expo y Capgo castiga el número escrito a mano, no el rango (I7 §5 lo marca como criterio propio; Capawesome usa un rango, I2:58). Cumple VPI §2.6 sin ficha |
| N = 0 y «bajar no es aplicar» | Expo `fallbackToCacheTimeout` 0 y `ON_LOAD` (I2:50), Shorebird y Capawesome (I2:66-69), CommCare «applied the next time the user logs in» (Dimagi [29], abierta). La medida propia lo respalda: el manifiesto en el camino crítico agrega ~400 ms antes de crear el WebView (corrida 2 de E02-R) |
| `DEV` H-06, Info.plist fuente en el runner Linux | Es E1 propio (M2-2 rojo, M2-3 verde) y corrige un descarte del dictamen (021:872) con costo nulo: es la clase de hallazgo que esta ronda necesitaba, una medida que baja el costo en lugar de subirlo |

---

## 5. Solicitudes de convocatoria y obstáculos

| A quién | Señal | Ubicación |
| --- | --- | --- |
| **Jurado de veredicto r2** (presidencia, al despacharlo) | Cinco jueces despachados por separado, o declarar que no hay quórum (`Mesa` §3.5.4). Repuntuar P1 con la tabla de R2-03 antes de votar | R2-03, R2-04 |
| **Académico editor didáctico**, en caliente | Su condición de entrada se cumplió: `LSC` emitió seis P1/P2 sobre P10 y pidió su convocatoria (`LSC` §5, S-1; `JC2` §6: «entra … si `lector-sin-contexto` … emite una solicitud con un hallazgo P1 sobre P10») | `LSC` H-01–H-05; R2-12 |
| **Cuerpo de parches r2** | Cotejar cada `PROCEDE` de r1 contra el texto del dictamen: hay al menos uno votado y no aplicado (R2-12) | 021 §2 frente a §5 |

**Obstáculos de una línea** (no uso el g42 ni el emulador):

- Para quien tiene el teléfono de referencia: «medir el peso de un paquete en el que sólo cambió la definición, y el
  de una definición sola bajada por el canal firmado» (destraba R2-06 y la celda «sin medir» de `ANA` §1.1).
- Para quien tiene el teléfono de referencia: la corrida de `FOR` S-4 (arranque en frío, manifiesto fuera del camino
  crítico, `reportFullyDrawn` desde `Listo`, k corridas).
- Para quien aplica: el tiempo de pared de la instantánea del contrato y de la compuerta de definiciones en
  `i7infra-runner-dev` con su primer rojo provocado (R2-08).

---

## 6. Fichas: admitidas / no admitidas

| Ficha | Estado | Motivo |
| --- | --- | --- |
| XC-1 (r1, migración al abrir frente a VPI §2.7 cláusula 2) | **Cerrada** | El PO eligió C-1, sobre fijo, cumplir (folio 023, ítem 2): la excepción decae. No se reabre |
| Fichas nuevas de la ronda 2 | **Ninguna presentada** | `grep` de `despacho/*ficha*` → sin archivos. Las ocho comisiones declaran no proponer excepciones |
| Admitidas | Ninguna | — |
| No admitidas | Ninguna | — |
| **Propuesta que necesitaría ficha y no la trae** | `ARQ` H-04, si el contrato se escribe como interfaces C# | VPI §2.6 rige al pie de la letra sobre tipos interfaz; declarar «menor» un miembro nuevo es no seguirla. Con la tabla de métodos de `Call(sobre)` no hace falta (R2-09). **¿Cuánto cuesta cumplir?** Nada: quedarse con la tabla que el dictamen ya fija |
| Clave exacta derivada por hash (I7, I0) | No propuesta | Ninguna comisión la sostiene; `DEV` §3 P7 la descarta justamente porque exigiría una ficha sin contradicción que la funde |

---

## 7. Mapa de disenso r2

| Pregunta | Dictamen r1 | Posiciones r2 | Lo que sobrevive |
| --- | --- | --- | --- |
| **P1, qué se actualiza** | (b), por tres literales; C-min descartada | `ANA`: (b) por compuerta, fundamento refutado, al lote con default (b) por retrabajo. `ARQ`, `SEG`, `VER`, `REQ`: confirman A. Refutador r1 y análisis r1: C-min | **(b), A+datos, por el renglón 3 de §0** (R2-01), con la pregunta al lote y su precio (R2-03). El fundamento r1 no sobrevive; la decisión sí, provisoria |
| **P1, canal de la definición** | Dentro del paquete | `ANA`: un solo canal (18 > 14, contra otra alternativa). `ARQ`, `SEG`, `REQ`: mismo índice, dos clases. `VER`: lo eleva sin elegir | **Un índice, dos clases** (R2-06) |
| **P1, umbral de arranque** | TTFD ≤ 5 000 ms en el g42, «lo medido lo cumple» | `FOR` y `VER`: dispositivo sin origen, instrumento y condición no medidos | El valor como criterio del jurado; la fila se corrige (R2-04) |
| **P1, AOT** | Sin decir | `VER`, `SEG`: contenido sin AOT | Sin AOT, con comprobación |
| **P2, forzado** | Arranque en frío o fin de la encuesta | `ARQ`: sólo arranque en frío, antes de mostrar si ya está verificado. `ANA`: conserva el fin de la encuesta. `REQ`, `FOR`: tabla y cota | **Sólo arranque en frío** (R2-07). La cota en arranques: un inicio después de la descarga |
| **P2, `expires` y claves** | `expires` sin valor; reserva sin semántica | `SEG`: valor, renovación, revocación, retirados. `FOR`: valor con TUF | Valor con renovación sin revisor; revocación como diseño; retirados sí (R2-10) |
| **P2, retención** | Servidor N ≥ 3; teléfono `current` + `previous` | `FOR`: unidad y consumidor de N; `VER`: estado terminal | Confirmada con unidad declarada; estado terminal a decidir (`VER` S-1) |
| **P3, clave** | Rango con techo; constante a mano | `REQ`, `VER`, `FOR`, `ARQ`, `DEV`: rango + detección. Nadie, clave exacta | **Rango + instantánea del contrato** (R2-08); tabla de métodos, no interfaces (R2-09) |
| **P4** | Entrada y sesión separadas; demo sin IdP | `ANA`, `REQ`: pendientes al cerrar sesión; mínimo del cascarón al ingresar | Confirmado con las dos reglas |
| **P6** | Procedimiento B; merge humano; I2 por default | 023: I1 implantado. `DEV`: dos formas de merge; compuertas propias | I1 + dos formas de merge; `fw-ok` bloquea |
| **P7** | Líneas separadas | `FOR`: pre-release, roll-forward; `DEV`, `REQ`, `VER`: fecha de MAUI | Confirmadas con esos agregados |
| **P8** | Compuerta mínima | `DEV`: contrato, piso, definiciones, Info.plist, publicación; `VER`: AOT, doble falla | Instantánea, definiciones, Info.plist, doble falla; piso y publicación al tramo siguiente salvo medida |
| **P9** | Diseño sin ensayo (aprobado en 023) | `VER`, `SEG`: riesgos nuevos | Aprobado; con los riesgos sumados |
| **P10** | O3-m-r | `LSC`: cinco precisiones; académico postergado | O3-m-r con las precisiones; convocar al académico |
| **P12** | Dos tiempos | `SEG`: P0, mismo binario. `ARQ`, `VER`: sólo por el puente | **Mismo binario, P1** (R2-05); sólo por el puente |
| **P13** | Siete reglas | `ANA`, `REQ`, `DEV`: evolución; `FOR`: retenciones, roll-forward; I0: «sincronizar primero» | Las siete reglas más evolución y retenciones separadas; P13.7 se conserva frente a I0 |
| **Objetivo** | Sin cláusula sin red | `REQ` H-01: sigue sin asentar (E1) | La presidencia la asienta con F004 y F005 y su instrumento |

Sigue: jurado de veredicto de la ronda 2, con este folio entre sus insumos · presidencia · Cierra con: folio informe del jurado de veredicto r2

Sigue: incorporación del siguiente informe y resolución · presidencia
