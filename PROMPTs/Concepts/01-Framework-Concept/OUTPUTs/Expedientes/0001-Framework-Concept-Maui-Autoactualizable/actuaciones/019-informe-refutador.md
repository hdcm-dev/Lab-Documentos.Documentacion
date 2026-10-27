| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-10-25 |
| Autor | Refutador (núcleo) |
| Corrige | — |

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Rol | Refutador (núcleo permanente). Entra último y es el único rol que lee los informes |
| Fecha | 2026-10-25 |
| Carta | `evidencia/014-carta-refutador.md` |
| Norma | `<base de conocimiento>/Knowledges/Knowledge-Mesa-De-Expertos-A-Pedido.md` 3.1 |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | Cabecera y §0 (líneas 1–111). Después, la fila «Sos el refutador» del Mapa de carga, que da lo mismo que al presidente: §1, §2 (2.1, 2.2 con su subsección, 2.3), §3 (3.1 a 3.4), §4, §5 (5.1 a 5.4), §6, §7 y §8 |
| Documentos cargados con versión | `Excepcion-A-Un-Conocimiento` 2.0, entero · `Cadena-De-Consecuencias` 2.0, entero · `Versionado-Producto-Integral` 2.0: cabecera, §2.6, §2.7, §2.8, §3.3 y §3.4, cargadas por respaldo para comprobar las citas de las comisiones y de la ficha · `Release-Y-Despliegue-Versionado` 2.0: §2.2, invariantes 1 a 16, por el mismo motivo |
| No cargados | `Escalas-De-Juicio` y `Mesa`. Uso la lectura P0–P3 del folio 003 y las clases de ancla E1–E4/C tal como las nombra la carta. No juzgo la composición ni el veredicto |
| Insumos leídos | Pedido (evidencia 001, desde la línea 4); folios 001 a 006; los nueve informes de `despacho/` (incluidos el de composición del jurado y el de la comisión en caliente) y la ficha `analista-sistemas-y-decisiones-ficha-1.md`; `Actualizador.cs` y el INFORME de E01. **No leí la evidencia 012**, como manda la carta |
| Medios propios | Lectura del árbol con `wc`, `sed`, `grep`, `git ls-files`. Cuatro fuentes externas abiertas con WebFetch el 2026-10-25 (§2, R-02, R-06, P1, P2). No usé ningún dispositivo |

# Informe del refutador — expediente 0001

**Abreviaturas.** `EV001` es la evidencia 001 (pedido). `F003`…`F006` son los folios de `actuaciones/`. `FAPP` es
`Framework-APP.md`. Los informes se citan por su slug: `REQ` (requisitos), `VER` (verificación), `LSC` (lector sin contexto),
`ARQ` (arquitecto), `ASD` (analista), `DEV` (devops), `SEG` (seguridad), `ACA` (académico), `CRC` (caso de referencia y
capacidades), `JUR` (composición del jurado). `XC-1` es la ficha del analista: el número lo asigna la presidencia al
incorporarla, y uso `XC-1` sólo para poder nombrarla.

## 1. Lectura del objetivo: lo que da por fijo sin origen

El objetivo (F003:46-51) y la lectura dominante de las comisiones dan por fijas cuatro cosas que el pedido no dice.

| Lo que se da por fijo | Quién lo sostiene | Qué dice el pedido | Lectura |
| --- | --- | --- | --- |
| **Se actualiza el código de las pantallas.** El «comportamiento» de la app cambia sin tienda | `ASD` P1: «elegir B pierde la actualización de comportamiento sin tienda, que es el núcleo del pedido». `SEG` P1 dice lo mismo. `ARQ` P1 propone A | `EV001:21`: «aplicar actualizaciones desde el servidor». En ninguna parte dice «comportamiento» ni «código». Los dos ejemplos que dio quien pidió son de **contenido**: «una actualizacion del contenido solo es cambiar la aplicación web server» (F004) y «si la encuesta cambia o se arregla o actualiza» (F005) | **Agregado sin marcar.** Es mi primer hallazgo, **R-01** |
| **Con la lectura de Microsoft, «Blazor híbrido» hace imposible el objetivo** | `ARQ` §1 («juntas son imposibles»), `CRC` H-03, `LSC` H-02 | `EV001:15`: «paginas .net blazor hibridas en .NET MAUI» | Es imposible **sólo para la opción A**. Con definiciones como datos que dibujan componentes Razor dentro de `BlazorWebView`, la lectura de Microsoft se cumple al pie de la letra. Es **R-02** |
| **El objetivo no exige operar sin red** | F005, «Clasificación y efecto»: «No cambia el objetivo» | F005, testimonio: «el encuestador podria tomar las encuestas perfectamente sin internet y luego sincronizar» | Quien pidió fijó lo que espera, y el objetivo no lo recoge. Coincido con `CRC` H-01. Es **R-03** |
| **`Versionado-Producto-Integral` rige** y, con él, «que impidan» | F003:80-82 (decisiones cerradas) | Su condición de carga es conjuntiva y su segunda mitad («declara la necesidad de atribuir un error de producción a versiones exactas», cabecera, línea 7) no tiene frase en el pedido | Coincido con `REQ` H-02, `VER` H-02 y `ASD` H-02, y le agrego el peso. De esta condición dependen P5, P6, P7 y la ficha XC-1. Es **R-04** |

**La solución más chica que cumple el pedido literal y los folios 004 y 005**, y que nadie puso sobre la mesa entera:

- La encuesta se publica como **definición versionada** (datos).
- La dibujan componentes Razor del cascarón en `BlazorWebView`, que es Blazor Hybrid en el sentido de Microsoft.
- La definición baja por el mismo canal firmado al abrir la app o al iniciar sesión.
- Las respuestas se toman sin red y salen por un outbox.

`SEG` P1 dice que el canal firmado es el mismo para A y para B, así que esta solución no pierde nada de la seguridad
del canal. Ya está **medida**: E02-B de `ARQ` dibujó «Encuesta de movilidad» desde un JSON en el g42, con el primer
render a 1,6–1,7 s. Con la opción A, el mismo primer render tarda 3,7–4,9 s (`ARQ` §7.1, H-08).

## 2. Hallazgos

| Id | Nivel | Ancla con su cita | Hallazgo | Impacto si no se corrige | Dirección de la corrección |
| --- | --- | --- | --- | --- | --- |
| R-01 | P1 | **E2** `EV001:21` («aplicar actualizaciones desde el servidor»); F004 testimonio («una actualizacion del contenido solo es cambiar la aplicación web server»); F005 testimonio («si la encuesta cambia o se arregla o actualiza»); `ASD:109` («elegir B pierde la actualización de comportamiento sin tienda, que es el núcleo del pedido»). **E1** de `ARQ` §7.1 y H-08: B 1 615–1 723 ms, A 3 692–4 871 ms, 9,13 MB por versión de A | La propuesta dominante (A) se apoya en que lo que se actualiza es código. Ni el pedido ni los dos ejemplos de quien pidió lo dicen | Se elige el modelo más caro y con más riesgo: +~2 s por arranque y 9,13 MB por versión (medido); WebView ≥ 94 (E01 C-3); iOS ≥ 16.4 (`ARQ` H-03); `.wasm` frente a App Review 2.5.2, NO VERIFICADO (`SEG` P1). Todo eso para cubrir un requisito que no está escrito | El dictamen de P1 escribe las dos lecturas de «actualizaciones»: (a) contenido y definiciones; (b) también código de pantallas. Toma la que menos agrega, que es (a), y la declara. A pasa a ser una extensión del framework con su evidencia (E01, E02-R), no el piso de la demo. Si quien pidió quiere (b), lo dice en el lote |
| R-02 | P1 | **E3** web, Microsoft Learn, *ASP.NET Core Blazor Hybrid* (abierta 2026-10-25): «In a Blazor Hybrid app, Razor components run natively on the device … Components don't run in the browser, and WebAssembly isn't involved». **E2** `ARQ:31` («juntas son imposibles en la lectura técnica»); `CRC:26` («vuelve imposible el objetivo»); `LSC` H-02 («elegir la opción A viola una restricción dura (P0)») | La cita es exacta: la abrí. La conclusión no se sigue de ella. Con la lectura de Microsoft, lo que no se puede bajar es el **código** de los componentes. Una definición que esos componentes dibujan sí se baja. La imposibilidad depende del agregado de R-01 | Tres comisiones le llevan al jurado un falso dilema: o se adopta la lectura amplia, o el objetivo es imposible. Con eso, la lectura de Microsoft queda descartada sin que nadie evalúe B ni C | El dictamen declara cuál lectura de «Blazor híbrido» toma y dice que con la de Microsoft el objetivo **se cumple** con definiciones como datos. Si toma la amplia (`ARQ` H-01), lo declara como lectura y no como única salida |
| R-03 | P1 | **E2** F003:46-51 (el objetivo no tiene cláusula sin red) frente a F005, testimonio (sin red y sincronizar); F005 «No cambia el objetivo»; `CRC` H-01 | Quien pidió escribió mientras la mesa corría, y lo que escribió toca lo que el objetivo da por fijo. Rige el renglón 2 de §0: se rehace el enunciado. La providencia lo trató como escenario | Con el objetivo como está, la opción D (sitio remoto) y el caso de referencia lo cumplen y son lo más simple (`CRC` §3.1, columna 7). P5 y P13 no tienen criterio de aceptación en el objetivo | La presidencia suma la cláusula «toma de encuestas sin red y sincronización al recuperarla [F005]» con su origen. Según el paso 2 de §2.1, decide qué despachos llevan una cláusula que cambió. Este informe ya la usa |
| R-04 | P1 | **E2** `Knowledge-Versionado-Producto-Integral.md:7` («… **y** declara la necesidad de atribuir un error de producción a versiones exactas»); `:292` («Una fase sin declarar se lee **`operativa`**»); `:261` (§2.7, «vigentes desde la fase `diseño`»). **E1** `grep -c -i 'atribu'` sobre F003 → 0 (medido por `REQ`; lo repetí: 0) | Cuatro comisiones lo señalan por separado, pero ninguna dice el peso. De esa única condición dependen el «impidan» de P6, la gramática de P7, la fase de P5 y la existencia misma de XC-1 | Si VPI rige sin fase declarada, la demo carga todo lo de `operativa` (roll-forward, expandir y contraer, tramos T0 a T5). Si no rige, «impidan» pierde su origen y XC-1 no tiene objeto. El jurado votaría P5, P6, P7 y XC-1 sobre una premisa que no está resuelta | La presidencia toma una de dos salidas y la declara: (a) asienta la condición con su origen o como agregado marcado al PO; o (b) pasa VPI a condicional. En los dos casos declara `fase: diseño` (`VER` H-02, `DEV` H-10). XC-1 queda atada a esa salida (§6) |
| R-05 | P1 | **E1** `git -C Lab-Documentos ls-files \| cut -d/ -f1 \| sort \| uniq -c` → `807 Guides`, 1 `README.md`, 1 `CHANGELOG.md`; `git log --oneline -5` → PR #9 «guía de arquitectura v2.5.0, taller…». **E2** `DEV` H-02 (P0: «Implantar T1 antes que cualquier otra compuerta: protección clásica de `main`») y P11 W2; `EV001:17` («el equipo tiene problemas al introducir un PR sobre una rama estable») | La protección de `main` de Lab-Documentos se propone como P0 del diseño. No sobrevive como P0. (1) Que `main` esté sin proteger es estado del repositorio, no un defecto del plan. (2) La «rama estable» del pedido es la del equipo, no la de un repositorio de guías. (3) Protegerla alcanza a quien escribe las 807 piezas de `Guides/`: es un efecto sobre terceros que nadie pidió | Quien aplique puede cambiar la regla de fusión de un repositorio compartido apoyado en un P0 del panel. O, al revés, la guía enseña «impedir» sin que se haya implantado en ninguna parte | El plan **diseña** T1 con su rojo provocado y su prueba de implantación (VPI §3.4). **Dónde** se implanta (el `main` de Lab-Documentos o un repositorio propio de la demo) es una pregunta del lote al PO, con `SI NO RESPONDÉS`: T1 queda declarado «diseñado, no implantado». Baja a P1 |
| R-06 | P1 | **E3** web, GitHub Docs, *Secure use reference* (abierta 2026-10-25): «Self-hosted runners should almost never be used for public repositories on GitHub … because any user can open pull requests against the repository and compromise the environment». **E1** de `VER` H-04 (el grupo `Default` ya corre jobs de un repositorio público; el runner corre como `root`). **E2** `EV001:35`; `DEV` W2; `LSC` W2 | La salida que domina para el workflow (W2: `.github/workflows/` en la raíz de Lab-Documentos, con el runner propio) junta el mandato del runner con un repositorio público. La guarda «mismo repositorio» de `DEV` H-04 atenúa el riesgo, pero no lo cancela: un colaborador con escritura corre como `root` en i7infra. Además, un único check requerido en un repositorio de guías obliga a que el agregador responda verde a cada PR que no toca la demo | Cada PR de `Guides/` pasa por un workflow de código. Queda abierto un riesgo de host que la doc oficial desaconseja, y quien aplica no tiene registro de que alguien lo haya aceptado | P11 se dictamina con W1, W2 y W3 medidos. El riesgo residual de W2 se asienta como **aceptado por quien pidió**, en el lote, no por el panel. Mientras tanto, el YAML se escribe en la ruta ejecutable y el check no se marca como requerido (aviso, no impedimento, VPI §3.3 punto 1, declarado) |
| R-07 | P1 | **E2** `E01/src/Cascaron/E01/Actualizador.cs:83-85`: `if (Directory.Exists(DirPrevious)) Directory.Delete(DirPrevious, true); if (Directory.Exists(DirCurrent)) Directory.Move(DirCurrent, DirPrevious); Directory.Move(destinoStaging, DirCurrent);` frente a `SEG:181` («cambio atómico `current`/`previous` (E01, medido)») y `SEG:258-259` («lo que revisé y está bien» 2: activación atómica) | Hay contradicción entre comisiones. `ARQ` H-05 y `VER` H-05 muestran con el código que la activación **no** es atómica: borra `previous` antes de tener la nueva, y entre los dos renombres no existe `current`. `SEG` la da por medida. El código le da la razón a `ARQ` y a `VER` | El jurado puede votar P2 con la versión de `SEG` y enseñar una atomicidad que no existe | Para P2 queda en pie la versión de `ARQ`, medida en E02-R: directorios inmutables por versión y un `puntero.json` cambiado con un solo `rename`. Más el criterio de `VER` H-05: un corte provocado entre cada paso, visto en rojo contra E01 |
| R-08 | P2 | **E1** `wc -l actuaciones/003-providencia-contrato-de-entrada.md` → `107`. **E2** `VER`: «folio 003 l.86-87», «l.117», «l.143-145», «l.148-149», «l.159», «l.163» | Las anclas E2 de `VER` sobre el folio 003 apuntan a líneas que no existen. El contenido coincide con anclas correctas de `REQ` (F003:46, 88) | Un jurado o un aplicador no puede comprobar esas citas. La de H-09 (su P0) queda con un E4 que no resuelve | Las citas de `VER` al folio 003 se degradan a C. Los hallazgos sobreviven por las anclas equivalentes de `REQ`, `LSC` y `DEV`, y el jurado los vota por esas |
| R-09 | P1 | **E2** `VPI:225` («Nunca un piso a secas»); `CRC:138` (`minShellVersion` «se calcula … es la primera versión del cascarón cuyo catálogo cubre lo requerido»); `ARQ` H-06 (quitarlo y usar un rango sobre el puente); `DEV` H-09 (rango + `webview-minimo`); `REQ` H-08 (tres mecanismos sin precedencia) | Después de la comisión en caliente hay **cuatro** dimensiones de compatibilidad: puente, capacidades, WebView y cascarón. El `minShellVersion` calculado de `CRC` sigue siendo un piso sin techo y no trae ficha | Tres implementaciones del predicado de compatibilidad. Una de ellas deja de seguir VPI §2.6 en silencio (Excepcion §3: si no hay contradicción, se cumple) | **Un solo predicado**, que el actualizador evalúa antes de activar: `puente ∈ [>=A.B <A+1]` ∧ `requires ⊆ catálogo` ∧ `webview ≥ min`. `minShellVersion` sale del teléfono. Si queda como filtro del servidor, se declara derivado y con techo |
| R-10 | P2 | **E2** `CRC:135` (catálogo «generado en el build», con una prueba de CI que verifica cada entrada en AndroidManifest **e** Info.plist); `CRC:136` (cinco estados); `DEV:28` y R2 (el runner es Linux y no compila iOS) | El costo de P12 para un desarrollador sin experiencia no se midió. La prueba sobre Info.plist no tiene dónde correr en el runner pedido | La guía enseña una prueba que la compuerta no puede ejecutar, o la pone en un job que no corre | Para P12 queda en pie una versión más chica: una lista constante en el cascarón, expuesta por el `handshake`; `requires`/`optional` en el manifiesto del contenido, validado antes de activar; y la prueba de CI sólo sobre AndroidManifest, con iOS declarado «sin compuerta» (`DEV` H-12) |
| R-11 | P1 | **E2** `ASD:145` (demo sin IdP: «la sesión por dispositivo del caso base») frente a `SEG:218` («La demo: login OIDC contra un Keycloak en contenedor y desbloqueo con Keystore en el g42»); F004 («se actualizan internamente al iniciar un logueo nuevo»); E01:323 (el g42 necesitó un túnel público para llegar al laboratorio) | Dos comisiones fijan dos demos distintas. La señal del folio 004 suma «al iniciar sesión» como disparador, pero `CRC` H-07 deja NO VERIFICADO que sea un patrón con nombre en la industria | O la demo carga un IdP alcanzable desde el teléfono, sin medir y con exposición por túnel, o la guía enseña un disparador que la demo no ejecuta | Queda en pie la demo **sin IdP** (`ASD` F3). El disparador «login con cuenta» se enseña en la guía como un evento más de la misma rutina de consulta (`CRC` §3.3), y la demo ejercita sólo el arranque en frío. Se revisa si quien pidió toma la lectura L1 de `ASD` H-01 |
| R-12 | P2 | **E2** `Knowledge-Release-Y-Despliegue-Versionado.md`, invariante 10: «La retención de artefactos anteriores … (N ≥ 3) … Lo que se conserva es **el artefacto del release**, no una copia del estado vivo del destino»; `ARQ` H-10 (current + previous + semilla = 3 **en el teléfono**); `SEG:183` (servidor N ≥ 3; teléfono current + previous); `ASD` H-07 (el rollback vuelve el código, no los datos) | El invariante 10 habla de los artefactos del release y no dice que se guarden en el dispositivo. El servidor con N ≥ 3 lo cumple al pie de la letra. Usar la semilla como tercer destino de rollback lleva a una versión vieja contra datos escritos por versiones nuevas | La tensión T-2 se resuelve con lo que más cuesta en el teléfono: disco, más un rollback a la semilla que puede no leer los datos | Retención N ≥ 3 en el servidor (cumple). En el teléfono, `current` + `previous`. La semilla sirve sólo para el primer arranque y no es destino de rollback. Sin ficha |
| R-13 | P2 | **E2** `DEV` P8 (siete capas como compuerta: build, unitarias, bUnit, contrato, actualizador, Playwright y APK, cada una con su rojo provocado); `VPI:404` («Los tramos se exigen desde la fase en que rigen sus reglas»). **E1** de `DEV` M-11: 18 pruebas en 28 s; APK ~2 min (R2) | La compuerta dominante es la completa. En fase `diseño` (R-04), los tramos no se exigen todos. bUnit, el contrato y Playwright no tienen tiempo medido en el runner | El primer PR de la demo arrastra siete suites, cada una con su rojo provocado: es la «ceremonia que nadie completa» de §7 | Compuerta mínima obligatoria: build `-warnaserror`, unitarias de dominio y del actualizador (con los casos C02–C08 de `SEG`) y APK, con el agregador estricto (`DEV` H-05). bUnit, el contrato y Playwright entran como el tramo siguiente, con su condición: la fase o el primer contenido publicado |
| R-14 | P2 | **E2** `LSC` P10 y `ACA` H-06 (19 temas; 133 subsecciones con 7 escenarios); `ACA` O3-m (19 tablas de 5 filas, tutorial, cómo hacer, inicio rápido, marco, mapa y anexos); `EV001:33` («una guía … en `Developer-Guide.md`») | O3-m recorta las subsecciones, pero conserva los 19 temas del árbol de N5. Ningún informe los deriva de las preguntas decididas | La guía para alguien sin experiencia sale con más temas que decisiones tomadas. El costo cae en quien escribe y en el lector | O3-m queda en pie con una condición: cada tema responde a una pregunta P1–P13 decidida, o sale. El número de temas lo da el dictamen, no el árbol previo |
| R-15 | P1 | **E2** `ASD:79` (fila B de D-01: «sin ensayo»; K-P = 2; K-E = 1 «"lógica nueva = release del cascarón" (FAPP:95)»); E02-B de `ARQ` §7.1 (B medido en el g42) | La matriz se puntuó a ciegas, antes de E02-B y del folio 005. Con E02-B, K-P de B pasa a 3 y el total queda A 7 frente a B 6. La única celda que separa a las dos es K-E de B, y su evidencia es el borrador, que es hipótesis a refutar: una celda apoyada en C, que según Excepcion §5.3 «no desempata» | D-01 parece decidida por la matriz, y la decide una celda C | El análisis vuelve a puntuar D-01 con E02-B y con el escenario del folio 005. K-E de B se mide sobre lo que cambia en ese escenario, que es la definición de la encuesta. Si el resultado sigue empatado, decide la reversibilidad (P1, §3) |

**Cuenta:** 15 hallazgos. P0: 0 · P1: 10 · P2: 5. Ninguno llega a P0. Los dos P0 de `DEV` y el de `VER` no sobreviven
como P0: el de `DEV` H-02 baja a P1 por R-05; `DEV` H-01 y `VER` H-09 son el mismo defecto que `REQ` H-04, que es P1 y se
corrige leyendo la restricción con su literal. El P0 de `ASD` H-03 sobrevive **condicionado** a R-04 (§6).

## 3. Respuesta a cada pregunta del caso

Cadena-De-Consecuencias §2 por pregunta: dónde cae el costo, cuánto pesa, qué pierde la alternativa y si es
reversible. Primero va la propuesta dominante entre las comisiones; después, lo que queda en pie.

### P1 — Modelo de contenido actualizable

- **Dominante:** A, Blazor WASM en `HybridWebView` (`ARQ`, `ASD`, `SEG`).
- **Alternativas:** A; B en `BlazorWebView`, con la definición como datos; C mínima (B ahora y A como extensión); D, remoto.

| | Dónde cae | Cuánto pesa | Qué pierde la otra | Reversible |
| --- | --- | --- | --- | --- |
| A | Arranque, disco, WebView del sistema, iOS, revisión de Apple | Medido: +~2 s, 9,13 MB por versión (`ARQ` H-08); WebView ≥ 94 (E01 C-3). Documental: iOS ≥ 16.4 (`ARQ` H-03). NO VERIFICADO: 2.5.2 | Si se elige B: los cambios de código sin tienda, que el pedido no nombra (R-01) | Sí, mientras el puente sea la frontera (`ARQ`) |
| C mínima | Esquema de la encuesta y su renderizador | Medido: primer render 1,6–1,7 s; APK 18,86 MB (E02-B). El esquema, sin medir | Si se elige A: un modelo con menos piezas para el principiante | Sí: el canal es el mismo (`SEG` P1), y A se suma sin tocarlo |
| D | El usuario sin red | Operación sin red nula (`CRC` §3.1, E2) | — | Sí, pero contradice F005 |

**Queda en pie: C mínima.** La definición de la encuesta viaja como datos versionados, la dibujan componentes Razor en
`BlazorWebView`, y A queda como extensión documentada con E01 y E02-R. La decide el **paso 4** de la cadena: las dos son
reversibles, y C mínima es la más barata medida y la que no depende de un requisito agregado. Fuentes:

- Microsoft Learn, *ASP.NET Core Blazor Hybrid*, que abrí.
- ODK: las definiciones de formulario bajan del servidor y la toma de datos funciona sin red (`CRC` [F19][F20]).

**Condición para revisarla:** que quien pidió diga que también hay que actualizar código de pantallas (lectura (b) de
R-01). En ese caso se suma A, y el umbral de TTFD de `VER` H-10 se fija antes de juzgar.

### P2 — Canal de actualización

- **Dominante, sin disenso de fondo:** servidor estático; índice de canal firmado con ECDSA P-256 (medido 11/11 en el
  g42, `SEG` E-SEG-1); monotonía; `expires`; staging; no bloquea el arranque; se activa en el arranque siguiente.
- **Ataque:** atomicidad (R-07) y retención (R-12).
- **Momento:** el pedido dice que la app «solicita bajar … al abrir» (`EV001:21`). Consultar y bajar al abrir, y aplicar
  después, lo cumple (`ARQ` H-09). Abrí la fuente de Expo: `checkAutomatically` «`ON_LOAD` (default value)»;
  `fallbackToCacheTimeout` «Defaults to 0»; «any update downloaded during the check will be applied upon the next app
  launch» (https://docs.expo.dev/versions/latest/config/app/, 2026-10-25).
- **Forzado (F006):** queda en pie el de `CRC` §4a. Se aplica en un punto seguro, nunca sin red, y nunca descarta pendientes.

**Queda en pie** lo dominante, con la activación de E02-R y la retención de R-12. El paso 4 decide: no bloquear es un
parámetro y es reversible.

### P3 — Cascarón, puente y compatibilidad

- **Dominante:** un `Call(sobre)` JSON-RPC más `handshake` (`ARQ`, N2).
- **Disenso:** cómo se decide la compatibilidad (R-09).
- **Queda en pie:** un solo predicado en el actualizador. El transporte `hybridwebview.js` forma parte del contrato (`ARQ`
  H-07) **sólo si se adopta A**. Con C mínima, el contrato es el esquema de la definición más el puente de servicios.
- **Fuente:** VPI §2.6, forma canónica `compatible-con-<x>: >=A.B.C <D.0.0`.

### P4 — Entrada del usuario y qué entra en la demo

- **Disenso:** R-11.
- **Queda en pie:**
  - Para el framework: F2 de `ASD`. La entrada local va separada de la sesión con el servidor, y la renovación no
    bloquea la entrada. D-03 = T1 (`SEG`, Android KeyGenParameterSpec [S12]).
  - Para la demo: sin IdP.
- **Cadena:** el IdP cae en la red del teléfono, que hoy pide un túnel público (E01:323). Su costo está sin medir. Sumar la
  etapa después es reversible.

### P5 — Datos locales y trabajo sin red

- **Disenso de librería:** `sqlite-net-pcl` (N2, `ARQ`) frente a EF Core SQLite (`ASD`, N5). Empatan 7-7-7 en la matriz de `ASD`.
- **Queda en pie:** EF Core SQLite para las tablas del cascarón y una tabla genérica de documentos para el contenido.
  Desempata la restricción literal «Tomar base … `MovilidadUrbana.MAUI`» (`EV001:33`; EF Core 10.0.11 en R1) y la
  migración medida (E-ASD-1). Es reversible detrás de `IDb`.
- **Outbox:** dueño, versión de payload y orden por entidad (`ASD` H-05, H-06, H-08).
- **Migraciones:** van por XC-1 (§6).

### P6 — Procedimiento de PR e integración

- **Dominante:** B de `DEV` (protección de `main`, un check único, no permitir saltear, guarda de forks).
- **Ataque:** R-05 y R-06.
- **Queda en pie:** el **procedimiento** B tal como lo escribe `DEV`, con T1 diseñado, más el rojo provocado de M-13 (no
  el de M-12). La **implantación**, es decir, en qué repositorio, va al PO.
- **Cadena:** proteger `main` de Lab-Documentos cae sobre 807 piezas de `Guides/` (medido) y se revierte con una
  configuración. Quién la decide no es el panel.
- **Fuente:** GitHub Docs, *Secure use reference*, que abrí.

### P7 — Líneas de versión

- **Queda en pie** la tabla de `DEV` P7: cascarón con tres enteros, puente SemVer con el mayor como contrato, contenido
  como paquete SemVer más el commit, y fase en `rutas.json`.
- **Con C mínima** se suma la línea **definición de encuesta** (`encuestaId` + versión entera monótona, ODK [F19]).
- **La regla de orden anti-rollback** compara sobre la versión sin metadatos de build (`REQ` H-07, SemVer 2.0.0 §10).
- **Todo esto depende de R-04.**

### P8 — Qué se prueba y qué es compuerta

**Queda en pie** la compuerta mínima de R-13. Lo de dispositivo es manual, con logcat y captura (`VER` H-08, `DEV` H-08).
Fuente: Vocke, «The Practical Test Pyramid», 2018, verificada en N4.

### P9 — iOS

Hay consenso entre `DEV`, `SEG`, `VER` y `ARQ`: no se compila iOS y se declara; un job `macos-*` queda como agregado para
el PO. **Queda en pie.** Con C mínima desaparecen dos de los riesgos de iOS (iOS ≥ 16.4 y `.wasm` frente a 2.5.2). El
puente frente a 4.7.2 sigue NO VERIFICADO.

### P10 — Estructura de la guía

**Queda en pie** O3-m de `ACA`, con el recorte de R-14 y el inicio rápido de `ACA` H-07.

### P11 — Alcance mínimo de la demo, cómo corre y dónde vive su workflow

- **Alcance:** queda en pie M2 de `ASD`, ajustado a C mínima:
  - encuesta v1 → v2 como definición, vista al reabrir;
  - un paquete adulterado que se rechaza;
  - rollback;
  - un PR en rojo;
  - una encuesta sin red que sale por el outbox hacia un receptor didáctico (`ASD` H-10).
- **Cómo corre:** C3 de `ACA`, con la receta dentro de `Demo/` (medido: el camino público no llegó a un APK).
- **Dónde vive el workflow:** R-06. W2 depende de que el PO acepte el riesgo del runner en un repositorio público.

### P12 — Capacidades del dispositivo

Queda en pie la versión de R-10. Si falta una capacidad de `requires`, el paquete no se activa; si falta una de
`optional`, el contenido degrada la función. Fuentes: Android, *Declare app permissions* (`CRC` [F10]); Apple, claves de
uso (`CRC` [F13][F15]). El catálogo se versiona junto al puente.

### P13 — Encuestas tomadas con una versión cuando llega otra

- **Hay convergencia** entre `CRC` §3.5 y `ASD` H-06:
  - cada respuesta lleva `{encuestaId, versionDefinicion}`;
  - el cliente conserva las definiciones que tienen pendientes;
  - ninguna actualización descarta pendientes.
- **Ataque por aplicación:** «el servidor acepta las versiones no retiradas» necesita un servidor, y en la demo eso es el
  receptor didáctico. Que ODK Central lo haga queda NO VERIFICADO (`CRC` §9).
- **Queda en pie** con el receptor didáctico como pieza obligatoria de la demo.

## 4. Lo que revisé y está bien

1. **Las cuatro citas externas que sostienen hallazgos P1 dicen lo que se afirma.** Abrí las cuatro el 2026-10-25:
   - Microsoft Learn, *Blazor Hybrid*.
   - GitHub, *Secure use reference*.
   - Google Play, *Device and Network Abuse*. Su excepción nombra «JavaScript in a webview or browser», y la lectura
     cuidadosa de `SEG` H-02 se sostiene.
   - Expo, `checkAutomatically` y `fallbackToCacheTimeout`.
2. **E-SEG-1 y E-ASD-1 traen comando, salida y huella**, y su eje no fijado está declarado. E-SEG-1 se corrió en el g42;
   E-ASD-1, en Linux.
3. **La tabla diferencial de `CRC` §3.1 cumple «Caso que funciona antes que diseño»:** marca la columna que cambia (dónde
   vive lo que se ejecuta) y descarta igualarla con E2.

## 5. Solicitudes de convocatoria

| Señal | Ubicación | A quién |
| --- | --- | --- |
| El dictamen va a fijar umbrales: TTFD, la espera X/N, la retención y los rangos. La condición de `JUR` §3 para Formal se cumple | `VER` H-06 y H-10; `REQ` H-11; `JUR` §3, fila Formal | Jurado, ciclo 2 |
| Barrido antes de versionar: aparecen el host y la serie del teléfono (`203.0.113.30`, `<serie-del-g42>`) en folios que van a un repositorio público, y el nombre del repositorio privado de referencia en el testimonio de F004 y en `FAPP:329` | `grep -l` → `actuaciones/002…`, `despacho/jurado-composicion.md`, `verificacion.md`, `seguridad-canal-y-tiendas.md`, `arquitecto-maui-hibrido.md`, `evidencia/003…`; `LSC` S-2 | Presidencia (§2.3, barrido) |
| R-01, R-03 y R-04 tocan el objetivo y lo que da por fijo. Por el renglón 2 de §0 los resuelve la presidencia, no el panel | §1 de este folio | Presidencia |

## 6. Fichas: admitidas / no admitidas

| Ficha | Veredicto del refutador | Motivo |
| --- | --- | --- |
| XC-1 (`analista-sistemas-y-decisiones-ficha-1.md`): migrar la base local al abrir, frente a VPI 2.0 §2.7, cláusula 2 | **Admitida, condicionada a R-04** | Es una contradicción, no conveniencia, y está anclada en E1 (código de salida 3; 3 → 0 pendientes) y en E2 (Android: «Other apps cannot access files stored within internal storage»). En el teléfono no existe el «otro acto» que la cláusula supone. Si la presidencia pasa VPI a condicional, la ficha **decae**: no hay convención a la que exceptuar |

**«¿Cuánto cuesta realmente cumplir?»** La ficha mide dos formas de cumplir: (a) no arrancar, y (b) recrear. Falta la
alternativa más cercana a cumplir, que el análisis tiene que enumerar (Excepcion §5.3): **un esquema sobre fijo en el
cascarón**.

- **Qué es:** tablas con columnas estables (id, tipo, versión de forma, clave de idempotencia única, JSON). El cambio de
  E-ASD-1 (`VersionPayload`) viaja dentro del JSON.
- **Qué logra:** mientras el sobre no cambie, el número de esquema no cambia, y la cláusula 2 se cumple sin migrar. Es el
  mismo diseño que `ASD` ya propone para el contenido (P5, punto 1).
- **Costo:** **sin medir**. Lo mediría repetir E-ASD-1 con el campo dentro del JSON; se le pide al análisis de decisiones.
- **Lo que no resuelve:** posterga la contradicción hasta el primer cambio del sobre, y por eso no la elimina.

**Apoyo de otra regla al camino propuesto.** Release-Y-Despliegue 2.0, invariante 4: «El almacén llega al estado que el
artefacto exige **antes** de que el artefacto arranque, y entre los dos pasos hay una verificación cuya salida esperada es
literal». Migrar en el cascarón antes de crear el WebView, con compuerta de esquema, es esa forma, con el contenido como
artefacto. Rama de §4 de Excepcion: **reversibilidad, camino reversible** (hoy no hay terceros instalados): se avanza
como provisorio, sin aprobar, y nada irreversible se apoya en él.

**No admitidas:** ninguna, porque no hay otras fichas. Señalo una excepción **propuesta sin ficha**: el `minShellVersion`
calculado de `CRC`, que es un piso a secas frente a VPI §2.6 (R-09). No hay contradicción, así que se cumple: con techo,
o fuera del teléfono.

## 7. Mapa de disenso

| Pregunta | Posiciones | Lo que sobrevive |
| --- | --- | --- |
| P1 | `ARQ`, `ASD` y `SEG`: A · `CRC`: dos ejes (código y definición) · `LSC`: con la lectura de Microsoft, A es P0 | **C mínima**: la definición como datos en `BlazorWebView`, con A como extensión (R-01, R-02, R-15) |
| P2 | Coinciden en el canal. `SEG`: activación atómica medida · `ARQ` y `VER`: no lo es · `ARQ`: retención con semilla · `SEG`: current + previous | Canal de `SEG`; activación de E02-R; retención de R-12 |
| P3 | `ARQ`: rango sobre el puente, sin `minShellVersion` · `DEV`: rango + WebView · `CRC`: catálogo + `minShellVersion` derivado | Un solo predicado (R-09) |
| P4 | `ASD`: demo sin IdP · `SEG`: demo con Keycloak y Keystore | Framework F2 + T1; demo sin IdP (R-11) |
| P5 | `ARQ` y N2: `sqlite-net-pcl` · `ASD` y N5: EF Core · `ASD`: migrar al abrir (XC-1) | EF Core en el cascarón y documentos para el contenido; XC-1 condicionada |
| P6 | `DEV`: B con T1 implantado en `main` de Lab-Documentos (P0) · `VER`: lo mismo, como prerrequisito de admin | El procedimiento B; la implantación va al PO (R-05) |
| P7 | `DEV`: tabla de líneas · `REQ`: tres gramáticas en los dossiers | La tabla de `DEV` + la línea de definición; depende de R-04 |
| P8 | `DEV` y `VER`: O2 con siete capas obligatorias | O2 con la compuerta mínima de R-13 |
| P9 | Consenso: C + job macOS como agregado | Sin cambios |
| P10 | `LSC`: O3 · `ACA`: O3-m | O3-m con los temas atados a las preguntas (R-14) |
| P11 | Workflow: `LSC` y `DEV` W2 · `ACA` no opina · N5 W3 (no corre). Alcance: `ASD` M2 · `ACA` cuatro hechos · `SEG` con login | M2 sobre C mínima; W2 sólo con el riesgo aceptado por el PO (R-06) |
| P12 | Sólo `CRC` | La versión reducida de R-10 |
| P13 | `CRC` y `ASD` convergen | Sin cambios, con el receptor didáctico como pieza obligatoria |

Sigue: incorporación del siguiente informe y resolución · presidencia
