Método: informe del refutador de la corrida descartada (ronda 1, despacho de las 19:41), movido sin editar desde despacho/refutador.md
Fecha-hora: 2026-10-25T19:47-03:00
Quién: refutador (corrida descartada; incorporado por la presidencia)
| Campo | Valor |
| --- | --- |
| Rol | Refutador (núcleo permanente). Entra último y es el único que lee los informes |
| Fecha | 2026-10-25 |
| Carta | `evidencia/010-carta-refutador.md` |
| Clase de objeto | Diseño de una norma o decisión |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | Cabecera y §0 (líneas 1–111); después, por la fila «Sos el refutador» del Mapa de carga, lo del presidente: §1, §2 (2.1, 2.2 con su subsección, 2.3), §3 (3.1 a 3.4), §4, §5 (5.1 a 5.4), §6, §7, §8 |
| Documentos cargados con versión | `Excepcion-A-Un-Conocimiento` 2.0 (entero) · `Cadena-De-Consecuencias` 2.0 (entero) · `Escalas-De-Juicio` 1.0 §3.1–§3.4, por respaldo: §3.2 de la norma remite a ella para la clase de ancla y la regla de contraste de un P0 · `Versionado-Producto-Integral` 2.0: cabecera, §0, §2.6, §2.7, §2.8, §3.3, §3.4, para verificar las citas que sostienen P0/P1 y la ficha · `Release-Y-Despliegue-Versionado` 2.0 §2.2 (invariantes 1 a 16), por la misma razón |
| No cargado | `Mesa` (ninguna remisión del texto de mi acto lo exige: no compongo ni voto) |
| Informes leídos | Los nueve `.md` de `despacho/`: `jurado-composicion`, `requisitos`, `verificacion`, `lector-sin-contexto`, `arquitecto-maui-hibrido`, `analista-sistemas-y-decisiones`, `devops-integracion-y-pruebas`, `seguridad-canal-y-tiendas`, `academico-editor-didactico`, y la ficha `analista-sistemas-y-decisiones-ficha-1.md` |
| Mediciones propias | Historia de `main` de Lab-Documentos (git, sólo lectura); `grep` sobre el folio 003; lectura de siete fuentes oficiales con WebFetch el 2026-10-25. No usé el g42, no ensayé, no hice commits |

# Informe del refutador — expediente 0001

**Abreviaturas.** `EV001` = `evidencia/001-prompt-crear-framework-concept.md` (líneas contadas en esa pieza, con
sus tres de cabecera). `F003` = `actuaciones/003-providencia-contrato-de-entrada.md`. `VPI` =
`Knowledge-Versionado-Producto-Integral.md` 2.0. `RYD` = `Knowledge-Release-Y-Despliegue-Versionado.md` 2.0.
Comisiones: `REQ` requisitos, `VER` verificación, `LSC` lector sin contexto, `ARQ` arquitecto, `ANA` analista,
`DEV` devops, `SEG` seguridad, `ACA` académico. `XC-a` = la ficha del analista, hasta que la presidencia le dé
número.

## 1. Lectura del objetivo: lo que da por fijo sin origen

Siete de las ocho comisiones atacaron el objetivo y encontraron los mismos tres agregados sin marcar: «con
ensayos», «que impidan» e «iOS» tomado del borrador. Además, P4 y P5 tienen origen en el borrador y no en el
pedido (REQ H-01 a H-03, VER H-01, LSC H-01, ANA H-01, ARQ H-02, ACA H-01). Sobre esos tres no repito nada:
están bien vistos. Lo que **nadie atacó** es lo que esa lectura arrastra hacia la solución:

| Lo que se dio por fijo | Origen | Lo que dice el pedido | Lectura |
| --- | --- | --- | --- |
| **La «rama estable» es `main` de `hdcm-dev/Lab-Documentos`**, y el procedimiento se implanta ahí con «no permitir saltear», también a los administradores (DEV H-02, H-03 y P6; VER P6 y P8) | Ninguno: es la consecuencia de ubicar la demo en Lab-Documentos | «el equipo tiene problemas al introducir un PR sobre una rama estable» (EV001:17). El pedido habla de **la rama del equipo**, que no nombra. De Lab-Documentos sólo dice dónde va la documentación (EV001:37) | **Agregado.** Implantar una protección sobre el `main` del repositorio de guías del PO cambia cómo trabaja el PO en **todas** sus guías. Medido: 15 de los 18 commits de primer padre de `main` desde el 2026-09-01 son push directos (§2, R-01). Hay una solución más chica que cumple el pedido: la demo enseña e implanta el procedimiento sobre **su** rama estable, y el PO decide si `main` de Lab-Documentos se protege |
| **El tamaño de la guía** (unos 52 documentos más 6 proyectos de la demo; ACA y LSC proponen O3 u O3-m sobre ese árbol) | El perfil Study-Guide y N5 §6.2 | «Desarrollar una guía instructiva … enfocada a un desarrollador sin experiencia … en `…/Developer-Guide.md`» (EV001:33); «ventajas de simplicidad y practicidad» (EV001:39) | El perfil sí rige (restricción dura del contrato). Lo que nadie pidió es que la guía cubra los temas que salen del borrador (login, outbox, SQLite). Esos temas son agregados (P4 y P5), y el costo de aplicarlos cae en el lector novato (R-09) |

Primer hallazgo: **R-01**.

## 2. Hallazgos

| Id | Nivel | Ancla con su cita | Hallazgo | Impacto si no se corrige | Dirección de la corrección |
| --- | --- | --- | --- | --- | --- |
| R-01 | **P1** | **E1** `git -C Lab-Documentos rev-list --count --first-parent --no-merges --since=2026-09-01 HEAD` → `15`; `… --merges …` → `3`; `git log --first-parent` muestra push directos del PO a `main` (p. ej. `c6e3163`, `dade777`, `fc8f9fa`, `e4f110d`). **E3** GitHub, *About protected branches*: «By default, the restrictions of a branch protection rule don't apply to people with admin permissions» y «You can enable this setting to apply the restrictions to admins» (https://docs.github.com/en/repositories/configuring-branches-and-merges-in-your-repository/managing-protected-branches/about-protected-branches, consultada 2026-10-25). **E2** EV001:17 («una rama estable» del equipo) | La propuesta dominante para P6 (DEV B + H-03, VER P6) protege `main` de Lab-Documentos con PR obligatorio, un check requerido y sin excepción para administradores. Desde ese momento, 15 de cada 18 escrituras que el PO hizo en `main` este trimestre quedarían rechazadas. El costo cae en un tercero: el flujo de trabajo del PO sobre `Guides/`. Ninguna comisión lo midió. Además, DEV M-5 midió `admin: true` **con la credencial del PO**: configurar la protección es un acto del PO, no de quien aplica | El plan sale con una fase que cambia un repositorio compartido sin que el PO la haya elegido, o sale sin compuerta real. Lecturas divergentes: «la demo demuestra la protección» o «Lab-Documentos queda protegido» | Separar las dos cosas. (1) Lo que el pedido exige —un procedimiento claro y una compuerta que se vea en rojo— se implanta sobre una rama estable de la **demo**. Sirve una rama dedicada protegida por ruleset en el mismo repositorio, o el repositorio propio (W3) si el PO lo elige. (2) Proteger `main` de Lab-Documentos sale al PO como agregado marcado, con el número medido. La prueba T1 (botón deshabilitado) vale igual sobre la rama dedicada |
| R-02 | **P1** | **E1** `grep -c -i 'atribu' F003` → `0`; `grep -n -i 'fase' F003` → sin salida. **E4** VPI 2.0, cabecera, `Condicion-de-carga`: «… más de un artefacto por separado **y** declara la necesidad de atribuir un error de producción a versiones exactas»; VPI §2.8: «Una fase sin declarar se lee **`operativa`**». **E2** R4:162-163 y NV-4 (R4:555): «lo tiene que declarar la presidencia en el contrato» | Tres comisiones lo vieron (REQ H-02, VER H-02, ANA H-02) y lo confirmo con E1. Pero nadie sacó la consecuencia: **todo lo que más pesa en la mesa cuelga de VPI**. Son el «impedir» de P6 (los P0 de DEV H-02), el rango con techo de P3 y P7, y el objeto de la ficha XC-a. Si VPI no rige, la ficha no tiene a qué exceptuar y «impedir» pierde su único E4 | La mesa puede votar una excepción a una norma que no está cargada, y el jurado puede votar P0 sobre una regla que no rige. El orden de las decisiones queda invertido | La primera decisión del plan es asentar en el contrato la condición conjuntiva (con su origen, o marcada como agregado de la presidencia) y la **fase** (`diseño` para la demo, como proponen DEV H-10, VER H-02 y ANA H-02). Recién después se juzgan la ficha y los P0 que se apoyan en VPI |
| R-03 | **P1** | **E2** ficha XC-a, «Lo que sigue rigiendo»: «migración en una sola transacción»; ANA P5 punto 2: «D-05 = S2 … EF Core SQLite 10.0.11». **E3** Microsoft Learn, *Applying Migrations — EF Core* (ms.date 2026-08-05, consultada 2026-10-25): «Wrapping MigrateAsync in an explicit transaction is not supported» y «the SQLite provider uses a lock table that can become abandoned if the process terminates unexpectedly … On SQLite, abandoned migration locks can block subsequent migrations» (https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/applying) | El camino que la ficha usa para compensar la premisa «ninguna vuelta atrás» de VPI §2.7 descansa en una transacción que la librería elegida no admite. Además, si Android mata el proceso a mitad de la migración, el bloqueo abandonado puede impedir las migraciones siguientes. El modo de falla queda igual al de cumplir: la app no abre. ANA lo dejó NO VERIFICADO; la ficha no lo trae | El análisis 6 bis pondera un camino cuya ventaja principal no existe tal como está escrita, y la guía enseña una garantía falsa | Sacar «una sola transacción» del camino, o medirla con la API real. Lo único que sostiene la vuelta atrás es la copia del archivo antes de migrar. Sumar un ensayo de una variable en el g42: matar el proceso durante `MigrateAsync` y reabrir. Que el camino diga cómo se limpia un bloqueo abandonado |
| R-04 | **P1** | **E1** ficha XC-a, «Costo de cumplir»: «v2-recrear: … pendientes=0 (antes: pendientes=3)». **E2** VPI §2.8, fila `diseño`: «El almacén de datos se puede recrear: no hay datos que alguien reclame … Se recrea el almacén». **E2** LSC P11, ARQ H-02, ANA P11 (M2 con receptor didáctico) y REQ H-03: el outbox de la demo no tiene frase en el pedido | «¿Cuánto cuesta realmente cumplir?» **en la demo**: en fase `diseño`, cumplir es recrear el almacén. Sólo pierde las acciones encoladas, y eso pasa sólo si la demo tiene outbox, que es un agregado. Sin outbox, cumplir cuesta cero datos reclamables. La contradicción medida vale **para las apps que el framework enseña a construir**, cuando lleguen a `candidata` u `operativa` | Si se admite la ficha para la demo, se vota una excepción donde cumplir es barato: es exceptuar por conveniencia (`Excepcion-A-Un-Conocimiento` §3) | Acotar la ficha: la excepción rige para la norma que la guía enseña en `candidata`/`operativa`. En la demo, en `diseño`, se cumple (se recrea), o se drena el outbox antes de recrear si la presidencia lo incorpora. Ver «Fichas: admitidas / no admitidas» |
| R-05 | **P1** | **E2** la ficha XC-a lista como alternativas de cumplir sólo (a) «no arranca» y (b) «recrear». **E4** RYD §2.2 inv. 4: «El almacén llega al estado que el artefacto exige **antes** de que el artefacto arranque, y entre los dos pasos hay una verificación cuya **salida esperada es literal**» | Falta la alternativa más cercana a cumplir, que `Excepcion-A-Un-Conocimiento` §5.3 obliga a enumerar: **separar los actos dentro del proceso**. El cascarón migra (acto 1), una compuerta exigido/leído con salida literal corta la secuencia, y recién entonces arranca el contenido (acto 2). Cumple RYD inv. 4 entera y VPI §2.7 cláusulas 1, 3 y 4. Sólo se aparta de la frase «aplicar migraciones al arrancar» | El análisis de compromiso pierde la alternativa que más convención conserva; el PO no la ve | Que el 6 bis la enumere como Alt-1, y que la ficha diga qué parte de la cláusula 2 queda afuera: sólo el rechazo literal, porque las tres premisas (instancias concurrentes, permisos de DDL, sin respaldo) se compensan o no existen en un teléfono |
| R-06 | **P1** | **E4** `Escalas-De-Juicio` §3.4 regla 1: «Un P0 anclado en una fuente declarativa se contrasta antes de proceder». **E2** DEV H-01 y VER H-09 (P0) se apoyan en N5 §6.3 («`workflows/` … a propósito»), una **fila de plan**; los mismos informes proponen W2, que lo resuelve con un archivo (DEV P11; LSC P11) | El P0 «el workflow no puede correr» no hace imposible el objetivo. Lo que no corre es el plan de N5, y la corrección cabe en una línea del contrato: la restricción de ruta alcanza a la **documentación** (EV001:37), no al workflow. REQ ya lo había rebajado a P1 (H-04), con el mismo argumento | El jurado detendría por P0 algo que se corrige leyendo el pedido sin agregados. Lo mismo pasa con DEV H-02, que es P0 sólo si «impedir» rige (R-02) | Votar DEV H-01 y VER H-09 como P1. DEV H-02 queda P1 hasta que se resuelva R-02, y su corrección es la de R-01 |
| R-07 | **P1** | **E4** `Escalas-De-Juicio` §3.4 regla 1. **E2** ficha XC-a y ANA H-03 (P0): «con la convención tal cual … no abre (objetivo imposible)» | ANA H-03 sería P0 sólo con tres condiciones a la vez: que VPI rija (R-02, sin asentar), que la fase sea `operativa` (la que se propone es `diseño`) y que haya datos que se reclaman (el outbox, un agregado). Para el objeto del caso (la demo y la guía, hoy en `diseño`), no hace imposible el objetivo | Una detención por P0 donde hay una ficha que, por norma, **no detiene la mesa** (`Excepcion-A-Un-Conocimiento` §4, «La mesa ante una excepción») | P1. Se tramita por la ficha (acotada por R-04 y R-05), no por detención |
| R-08 | **P1** | **E3** Microsoft Learn, *ASP.NET Core Blazor Hybrid* (ms.date 2025-11-11, consultada 2026-10-25): «In a Blazor Hybrid app, Razor components run natively on the device … Components don't run in the browser, and WebAssembly isn't involved» (https://learn.microsoft.com/en-us/aspnet/core/blazor/hybrid/?view=aspnetcore-10.0). **E2** F003:144 (restricción dura «.NET MAUI + Blazor híbrido»); ANA, matriz D-01 (A′ descartada por esa restricción) | Verifiqué la cita de LSC H-02 y ARQ H-01: dice lo que afirman. La propuesta dominante en P1 (A, en las cinco comisiones de dominio) **viola la restricción dura con la lectura de Microsoft**. Y la matriz del analista usa la misma restricción para descartar A′. Con la lectura (a), A cae; con la (b), A′ (SPA JS) no se puede descartar «por compuerta», porque «híbrida» deja de exigir Razor | Lecturas divergentes del resultado central de la mesa. El descarte de A′ queda sin fundamento | El contrato escribe las dos lecturas y toma la (b) declarada, con el literal «paginas .net blazor hibridas» (EV001:15) como lo que exige Razor. A′ se descarta por «páginas .net blazor», no por «híbridas» |
| R-09 | **P1** | **E2** N5 §6.2: árbol de unos 52 documentos (conteo propio del bloque: 3 en la raíz, 4 + 1 de marco y mapa, 11 de tutorial, 19 temas, 6 de cómo hacer, 1 de comparación, 7 de anexos). LSC P10: 19 × 7 = 133 subsecciones; ACA H-06. **E2** temas `Politica-de-Red-y-Outbox.md`, `SQLite-y-Migraciones.md`, `Login-y-Biometria.md` (N5 §6.2, `40-`), sin frase en el pedido (REQ H-03, ANA H-01, ARQ H-02) | El costo de aplicar la guía, para quien la escribe y para el novato que la sigue, se midió sólo en subsecciones de escenario (ACA O3-m, de 133 a 95). Nadie lo midió en materia: 3 de los 19 temas y las etapas que los ejercitan salen del borrador, no del pedido | La guía crece por agregados y compite con el núcleo pedido (actualización sin tienda y PR); la «simplicidad» que el pedido pone como criterio (EV001:39) se pierde sin decidirlo | Que P10 cierre el árbol con origen por tema: lo que cita el pedido entra, lo que viene del borrador sale como agregado marcado al PO (con default: capítulo de «trabajo futuro», sin etapa de demo). Mantener O3-m de ACA como forma |
| R-10 | **P1** | **E2** ARQ H-09 y P2: «Render inmediato … activación en el arranque siguiente»; VER H-06: «Fijar N y X como números … primer render ≤ N + render medido»; REQ P2 y SEG P2 no fijan el momento. **E3** Expo, *app.json — updates* (consultada 2026-10-25): `checkAutomatically` «`ON_LOAD` (default value)»; `fallbackToCacheTimeout` «Defaults to 0»; «any update downloaded during the check will be applied upon the next app launch» (https://docs.expo.dev/versions/latest/config/app/) | Hay dos lecturas del momento de aplicar. ARQ dice consultar al abrir y aplicar en el arranque siguiente; VER (y el borrador) piden una espera bloqueante con tope. Verifiqué la fuente de ARQ: dice lo que afirma. Con la lectura de ARQ, el «N segundos» de VER sólo hace falta en un caso: cuando lo instalado no satisface el rango del puente | El actualizador y la guía se escriben dos veces. VER pide ensayos (servidor mudo, modo avión con permiso del PO) cuyo resultado deja de decidir algo | P2 adopta la lectura de ARQ, que es la que menos agrega frente a EV001:21 («solicita bajar»). La medición de VER se acota al único caso bloqueante |
| R-11 | **P1** | **E2** ARQ H-10: «current + previous + semilla = 3 artefactos de release … **No hace falta ficha**»; SEG H-04: «La vuelta atrás **local** … va sólo a `previous`»; SEG P2: «Teléfono: `current` + `previous` (T-2 de R4; … no lo juzgo)»; VER H-05: «la retención real es 1». **E4** RYD inv. 10: «Lo que se conserva es **el artefacto del release**» | La retención N ≥ 3 de ARQ cuenta la semilla como tercer artefacto. Para que sirva de vuelta atrás, la semilla tiene que ser un destino posible del rollback local, y la regla de monotonía de SEG lo prohíbe tal como está escrita. Las dos propuestas son compatibles sólo si la monotonía se escribe sobre **manifiestos remotos** («`version` > la mayor instalada en el canal») y no sobre el destino del rollback local, que es un artefacto ya verificado | T-2 se da por cumplida en un informe y por abierta en otro. El actualizador implementa una de las dos y la otra queda violada | Una sola regla, escrita: anti-rollback sobre lo que llega del servidor; rollback local en orden `previous` → semilla, nunca a una versión marcada fallida. Con eso, T-2 se cumple sin ficha |
| R-12 | **P2** | **E2** SEG H-05: la firma «corre en un job aparte, en un runner **hospedado por GitHub**, que referencia un *environment* con revisor obligatorio»; [S9] de SEG: «NO VERIFICADO: la disponibilidad de *required reviewers* por plan». **E2** EV001:35 (mandato del runner) | El job de firma en un runner hospedado es un **agregado** frente al mandato del runner, del mismo tipo que el job iOS que DEV, ARQ y ANA sí marcaron como agregado. SEG no lo marca. La razón que da (secretos en un runner propio expuesto a PR de forks) vale para los disparos `pull_request`, no para un flujo disparado por etiqueta en el mismo repositorio | Un mandato del pedido se rodea sin elevarlo | Alternativa más chica, que conserva el mandato: firma en un flujo por etiqueta (nunca `pull_request`) en `[self-hosted, i7infra-dev]`, con el secreto en un *environment*. Si SEG sostiene el runner hospedado, sale marcado al PO como agregado |
| R-13 | **P2** | **E2** SEG H-06: conjunto de claves embebidas con `keyId`, de reserva fuera de línea, y rotación firmada por las dos (subconjunto de TUF §5.3); ACA H-01: el lector «no conoce … firma ni CI» | El costo de aplicar la rotación (dos claves, una fuera de línea, un procedimiento de lista firmada) cae en el novato y en un equipo que hoy no tiene custodio. Lo que la hace reversible después es sólo el campo `keyId` del manifiesto (SEG P2, «Reversible») | La guía enseña una ceremonia que la demo no ejercita | La demo lleva **una** clave y el campo `keyId` desde el primer manifiesto; la rotación va a «Cómo hacer», como procedimiento declarado. Condición para revisarlo: el primer producto en `candidata` |
| R-14 | **P2** | **E2** ANA, matriz D-01: «B UI por datos … K-P 2 … sin ensayo»; ARQ §7.1 E02-B: B medido en el g42, 1,6–1,7 s del proceso al primer render | La matriz se puntuó a ciegas con evidencia vieja: B ya está medido en el teléfono de juicio. Con K-P de B en 3, los totales quedan A 7 y B 6. **No cambia el orden**, pero el margen que la matriz declara («B sólo gana si la simplicidad pesa más de tres veces…») ya no vale | El jurado vota sobre una sensibilidad mal calculada | Re-puntuar la fila B con E02-B y recalcular la sensibilidad antes del veredicto |

**Cuenta:** 14 hallazgos. P0: 0 · P1: 11 · P2: 3. No sostengo ningún P0 propio. Rebajo cuatro P0 de comisiones
(DEV H-01, DEV H-02, VER H-09 y ANA H-03) a P1, con R-06 y R-07.

## 3. Respuesta a cada pregunta del caso (P1–P11)

Por cada pregunta: la propuesta dominante entre las comisiones, mi ataque, la cadena de consecuencias
(`Cadena-De-Consecuencias` §2) y la alternativa que queda en pie.

### P1 — Modelo de contenido (D-01)

- **Dominante:** A, Blazor WASM en `HybridWebView` (ARQ, ANA, SEG; VER y REQ sin oponerse).
- **Ataque:** (1) Con la lectura de Microsoft, A viola la restricción dura (R-08, cita verificada). (2) El criterio
  de caída a B no tiene umbral: ARQ y N1 dicen «un umbral que fije el analista», y el analista no lo fija (REQ H-11,
  VER H-10). (3) El costo medido de A no está en la matriz: +2,1 a 2,7 s de motor WASM por arranque y 9,13 MB por
  versión retenida (ARQ H-08). (4) En iOS, el piso real es 16.4 (ARQ H-03, documental).
- **Cadena.** *Dónde cae:* A cae en el arranque del usuario y en el disco; B, en la cadencia de entrega (lógica
  nueva por tienda). *Cuánto pesa:* A, 3,7–4,9 s al primer render con lo instalado y 9,13 MB por versión; B,
  1,6–1,7 s (los dos medidos en el g42, ARQ §7). Gama baja: sin medir. *Qué pierde la alternativa:* con B se pierde
  la actualización de comportamiento sin tienda (EV001:21). *Reversible:* sí, mientras el puente sea la frontera
  (ARQ y SEG coinciden en que el canal es el mismo para A y B).
- **Queda en pie:** **A**, pero sólo con dos condiciones escritas antes del veredicto: la lectura (b) de «híbridas»
  asentada (R-08) y un umbral numérico de TTFD con su dispositivo, declarado **antes** de medir. Para la métrica:
  Android define TTFD como «the time it takes for an app to become interactive for the user»
  (https://developer.android.com/topic/performance/vitals/launch-time, consultada 2026-10-25). El umbral numérico de
  Vitals que cita VER (5 s) está en otra página, que no abrí: **NO VERIFICADO** por mí.

### P2 — Canal (D-02)

- **Dominante:** servidor estático con índice de canal firmado (SEG, ANA, ARQ), ECDSA P-256 de plataforma (SEG,
  medido 11/11 en el g42), anti-rollback y `expires`.
- **Ataque:** el momento de aplicar (R-10) y la retención y el rollback (R-11) tienen dos lecturas. La rotación de
  claves es cara para el novato (R-13).
- **Cadena.** *Dónde cae:* un bloqueo al abrir cae en cada arranque con versión nueva (+4,7 s medidos en E02-R
  corrida 1); aplicar en el arranque siguiente cae en una versión de retraso. *Reversible:* las dos. Se toma la que
  no bloquea, con la condición de revisión de ARQ (medición en gama baja).
- **Fuentes verificadas por mí:** TUF 1.0.37 §4.3, «Clients MUST NOT trust an expired file» y «Clients MUST NOT
  replace a metadata file with a version number less than the one currently trusted»
  (https://theupdateframework.github.io/specification/latest/); Expo (R-10).
- **Queda en pie:** el canal de SEG con el momento de ARQ, la regla única de R-11 y una sola clave con `keyId`
  (R-13).

### P3 — Cascarón, puente y contrato

- **Dominante:** puente `Call(sobre)` JSON-RPC más `handshake`; el contenido declara un rango con techo sobre el
  **puente**; `minShellVersion` se deriva o desaparece (ARQ H-06; DEV H-09; REQ H-08).
- **Ataque:** el rango con techo se apoya en VPI §2.6. Verifiqué la cita: «Nunca un piso a secas» está en VPI:225.
  Pero VPI rige sólo si se resuelve R-02. Si no se asienta, el techo queda como criterio propio fundado en SemVer
  2.0.0 §4 y §11, citado por VPI y no abierto por mí.
- **Cadena.** Un piso pone el costo en el teléfono del usuario, y no se puede deshacer una vez que el contenido
  llegó (ARQ P3). El rango lo pone en la compuerta, que es barata y reversible.
- **Queda en pie:** el rango sobre el puente, con el transporte `hybridwebview.js` dentro del contrato (ARQ H-07).
  Nadie lo atacó y tiene la evidencia de E01.

### P4 — Entrada del usuario (D-03, D-07)

- **Dominante en la guía:** OIDC con PKCE más desbloqueo con Keystore, D-03 = T1 (SEG, ANA). **En la demo**, las
  comisiones divergen: SEG pone login con Keycloak; ANA y LSC no ponen login (F3).
- **Ataque:** todo P4 es agregado (R-09; REQ H-03). La demo con login necesita un IdP alcanzable por HTTPS desde el
  g42, que está en otra red. Ese costo está **sin medir**: E01 necesitó un túnel público, y ACA y REQ lo señalan como
  riesgo.
- **Cadena.** *Dónde cae:* con login, en la infraestructura del ensayo y en la extensión de la guía. *Qué pierde:*
  sin login, la demo no ejercita la biometría. *Reversible:* sumar la etapa después sí lo es.
- **Queda en pie:** ANA F3 para la demo, sin IdP. La guía lleva P4 como capítulo marcado «agregado del borrador,
  sin ejecutar», con el contraejemplo de ANA H-04 (entrar sin red) resuelto con F2. Sale al PO en el lote.

### P5 — Datos locales y sin red (D-04, D-05)

- **Dominante:** el contenido no hace DDL (documentos JSON por el puente: ARQ, ANA, N2). Hay disenso en la
  librería: S1 `sqlite-net-pcl` (ARQ, N2) contra S2 EF Core (ANA, N5). La migración al abrir va con ficha (ANA).
- **Ataque:** con S2, la «transacción» del camino de la ficha no existe (R-03, cita verificada). Con S1, la
  migración es a mano y sin bloqueo abandonado. Eso **invierte el desempate por reversibilidad** que ANA usó para S2.
- **Cadena.** *Dónde cae:* S2 cae en la migración del teléfono (bloqueo de SQLite, AOT en iOS, NO VERIFICADO); S1,
  en escribir migraciones a mano. *Cuánto pesa:* S2 migró 3 filas en 349 ms en Linux (E-ASD-1). El caso «proceso
  muerto a mitad» está sin medir. *Reversible:* las dos, detrás de `IDb`.
- **Queda en pie:** S1 de ARQ y N2 para la demo, que no carga el modo de falla del bloqueo. La condición para
  revisarlo: que el ensayo de R-03 en el g42 muestre que EF Core se recupera de un proceso muerto. La migración al
  abrir sigue por la ficha, acotada (R-04, R-05).

### P6 — Procedimiento de PR con `[self-hosted, i7infra-dev]`

- **Dominante:** DEV B (GitHub Flow, protección clásica, un check agregador sin `paths` que no acepta `skipped`,
  sin excepción para administradores, guarda de mismo repositorio).
- **Ataque:** dónde se implanta (R-01, medido). El agregador y la guarda están bien fundados: verifiqué que GitHub
  cuenta `skipped` como satisfecho («Required status checks must have a `successful`, `skipped`, or `neutral`
  status», misma URL de R-01). También verifiqué que un workflow filtrado por ruta deja el check «Pending» y
  recomienda «Avoid requiring workflows that can be skipped»
  (https://docs.github.com/en/pull-requests/collaborating-with-pull-requests/collaborating-on-repositories-with-code-quality-features/troubleshooting-required-status-checks,
  consultada 2026-10-25).
- **Cadena.** *Dónde cae:* proteger `main` de Lab-Documentos cae en 15 de 18 escrituras recientes del PO (E1);
  proteger una rama dedicada de la demo, en ningún tercero. *Qué pierde:* la rama dedicada no está en el `main` que
  muestra GitHub. *Reversible:* las dos son configuración; la de `main` alcanza a otro flujo de trabajo.
- **Queda en pie:** DEV B entero, **implantado sobre una rama estable de la demo**. Proteger `main` sale al PO como
  agregado con el número medido. La guarda de forks se mantiene: GitHub dice que los runners propios «should almost
  never be used for public repositories» (https://docs.github.com/en/actions/reference/security/secure-use, cita
  verificada por mí).

### P7 — Líneas de versión

- **Dominante:** DEV (c): cascarón de tres enteros; puente SemVer; contenido como «paquete» SemVer más commit;
  fase en `rutas.json`.
- **Ataque:** REQ H-07 sigue en pie. Con `+commit`, dos paquetes con el mismo número tienen la misma precedencia
  (SemVer §10, citado por REQ). Eso sólo es seguro si RYD inv. 2 («no se reutiliza jamás») tiene compuerta. DEV
  lo propone sin la compuerta de monotonía para el contenido.
- **Queda en pie:** DEV (c), más la compuerta de monotonía estricta sobre el número del contenido (RYD inv. 2,
  «la compuerta de monotonía exige **mayor estricto**»).

### P8 — Pruebas por capa y compuerta

- **Dominante:** O2, la pirámide sin dispositivo en el PR, con rojo provocado por suite (DEV, VER).
- **Ataque:** el costo de aplicar «cada suite con su rojo provocado medido» y los catorce casos de VER (diez de N4
  más cuatro de firma) antes de cerrar P2. SEG ya midió 11 casos en el g42 y DEV un rojo (M-13). El resto está
  sin medir.
- **Cadena.** *Dónde cae:* en el autor del framework, una vez. *Cuánto pesa:* las suites unitarias corren en 28 s
  de pared (DEV M-11). *Reversible:* sí.
- **Queda en pie:** O2 tal como lo proponen. La capa de dispositivo queda manual con evidencia (VER H-08, DEV
  H-08). No hay alternativa más chica que cumpla «impedir».

### P9 — iOS (D-06)

- **Dominante:** C (no compilar, declarado), con A (`macos-*`) como camino declarado y job no requerido (DEV, SEG,
  VER). ANA puntuó el runner macOS 7 contra 6, pero lo dejó para otra comisión.
- **Ataque:** ninguno de fondo. La condición de revisión es comprobable: existe una cuenta de Apple Developer. La
  pregunta al PO es un **obstáculo de una línea**, no una escalada (`Cadena-De-Consecuencias` §3).
- **Queda en pie:** C, con todo iOS rotulado NO VERIFICADO en la guía. La guía 4.2.3(ii) de Apple, que verifiqué
  («If your app needs to download additional resources in order to function on initial launch, disclose the size of
  the download and prompt users before doing so», https://developer.apple.com/app-store/review/guidelines/), obliga
  a que la semilla sea una versión completa (SEG H-03). Coincide con ARQ H-10.

### P10 — Estructura de la guía

- **Dominante:** O3-m de ACA (inicio rápido, tutorial, temas con tabla por escenario, cinco escenarios), con
  `Developer-Guide.md` como único índice. LSC propone O3 con cinco escenarios.
- **Ataque:** el tamaño por materia (R-09). Las comprobaciones de R3 buscan el índice en `README.md` (ACA H-09).
- **Queda en pie:** O3-m, sin los tres temas del borrador (login, outbox, SQLite), que van a «trabajo futuro»
  marcado, y con las comprobaciones apuntando a `GUIA-INDICE`.

### P11 — Demo: alcance, cómo se corre, dónde vive el workflow

- **Dominante:** alcance M2 de ANA (con outbox y receptor didáctico) o el mínimo de LSC y ACA (sin outbox). Entorno
  C3: receta versionada en `Demo/` (ACA, medido que el camino público no llega al APK). Workflow W2 (DEV, LSC).
- **Ataque:** el outbox es un agregado (R-04, R-09). W2 sólo en el `.github/workflows/` del repositorio, sin
  proteger `main` (R-01).
- **Cadena.** *Dónde cae:* M2 con outbox suma un receptor y una etapa; sin outbox, el pedido queda igual de
  cubierto (EV001:17, 21, 33). *Reversible:* sumar la etapa después sí lo es.
- **Queda en pie:** el mínimo de LSC y ACA: semilla, v1 → v2 al reabrir, paquete rechazado, llamada al puente, PR
  rojo y PR verde. C3 para el entorno. W2 con protección de una rama dedicada.

## 4. Lo que revisé y está bien

1. **Las citas que sostienen los P1 de seguridad y CI resisten la verificación.** Política de Play: «An app
   distributed via Google Play may not modify, replace, or update itself using any method other than Google Play's
   update mechanism» y la excepción «code that runs in a virtual machine or an interpreter where either provides
   indirect access to Android APIs (such as JavaScript in a webview or browser)»
   (https://support.google.com/googleplay/android-developer/answer/9888379?hl=en). La excepción nombra el WebView, y
   eso refuerza a A en Android; la cautela de SEG H-02 sobre la primera oración es correcta. También resisten la
   cita de EF Core que trae la ficha («applications that prefer simple deployment and can tolerate startup migration
   behavior») y las de GitHub de DEV H-03, H-05 y H-07.
2. **La ficha XC-a cumple la forma de `Excepcion-A-Un-Conocimiento` §5.1**: trae el texto literal de VPI §2.7, la
   alternativa de cumplir concreta, el costo medido con comando y huella, la contradicción con E1 y E2, la
   reversibilidad y «Aprobó: pendiente». Comprobé el texto citado contra VPI:262-266.
3. **El panel distinguió obstáculos de decisiones.** El administrador de la organización para leer el grupo de
   runners, la cuenta de Apple Developer y la medición en el runner real salen como preguntas de una línea, no como
   escaladas (DEV §5, SEG §5, REQ P9).

## 5. Solicitudes de convocatoria

| Señal | Ubicación | A quién |
| --- | --- | --- |
| Sin cargar, las dos decisiones de R-02 (condición de VPI y fase) dejan sin base a la ficha y a dos P0. Hay que resolverlas antes del veredicto | F003 (campos `DECISIONES CERRADAS` y `CONVENCIONES QUE RIGEN`) | Presidencia |
| Ensayo de una variable: matar el proceso durante `MigrateAsync` en el g42 y reabrir (R-03) | Ficha XC-a; ANA P5 | Perito (paso 7), si el 6 bis lo necesita para puntuar |
| La credencial que DEV usó para la API tiene `admin: true` sobre un repositorio compartido. Ningún rol del panel la usa para escribir; configurar la protección es del PO (R-01) | DEV M-4, M-5 | Presidencia |
| Tres sesiones distintas instalaron paquetes `com.frameworkconcept.*` en el g42, y hubo un choque de `applicationId` (SEG, incidente 1) | SEG §0; ARQ §7.2 | Presidencia (medios) |

## 6. Fichas de excepción

Ninguna propia: no propongo dejar de seguir ninguna convención.

## Fichas: admitidas / no admitidas

| Ficha | Veredicto del refutador | Motivo |
| --- | --- | --- |
| **XC-a** (`analista-sistemas-y-decisiones-ficha-1.md`): VPI 2.0 §2.7 cláusula 2, migración de la base local al abrir | **Admitida con alcance acotado y condicionada** | **Contradicción, no conveniencia.** E2: en Android ningún otro proceso puede tocar la base («Other apps cannot access files stored within internal storage», fuente citada por la ficha; no la abrí: heredada, la doy por la cita literal con URL). E1: con cumplir literal, «NO ARRANCA … codigo_salida=3». **¿Cuánto cuesta realmente cumplir?** En la **demo**, en `diseño` y sin outbox: cero datos reclamables (R-04), así que **ahí se cumple**. En las apps que la guía enseña, en `candidata`/`operativa`: imposible sin perder datos o sin abrir; ahí rige la excepción. **Condiciones:** (1) si la presidencia no asienta la condición de carga de VPI (R-02), la ficha decae por falta de objeto; (2) el camino sale sin «una sola transacción» (R-03); (3) el 6 bis enumera como Alt-1 la separación de actos de RYD inv. 4 (R-05). **Rama de §4:** reversibilidad, camino reversible (no hay apps en teléfonos de terceros): provisorio y sin aprobar, sin nada irreversible apoyado en él |
| No admitidas | — | Ninguna otra ficha llegó. T-1, T-2, T-4, T-6 y T-7 se resuelven cumpliendo (ARQ, DEV, SEG), y lo confirmo; T-2 con la regla única de R-11 |

## Mapa de disenso

| Pregunta | Posiciones de las comisiones | Lo que sobrevive a la refutación |
| --- | --- | --- |
| P1 | ARQ, ANA y SEG: A. REQ y VER: falta umbral. LSC y ARQ: «híbrida» con dos lecturas | A, con la lectura (b) asentada y un umbral de TTFD previo a medir (R-08) |
| P2 momento | ARQ: aplicar en el arranque siguiente. VER y el borrador: espera bloqueante con N y X | ARQ (Expo verificado); el N de VER sólo para el caso de rango incompatible (R-10) |
| P2 retención y rollback | ARQ: N = 3 con la semilla. SEG: rollback sólo a `previous`, teléfono N = 2 sin juzgar. VER: retención real 1 | Una regla: anti-rollback sobre lo remoto; local `previous` → semilla; T-2 cumplida (R-11) |
| P2 claves | SEG: conjunto con rotación y firma en runner hospedado | Una clave más `keyId`; firma por etiqueta en el runner pedido o agregado marcado (R-12, R-13) |
| P3 | ARQ, DEV y REQ: rango con techo sobre el puente | Se sostiene, condicionado a R-02 |
| P4 | SEG: login en la demo. ANA y LSC: sin login en la demo, F2 en la guía | Sin login en la demo; P4 como agregado marcado al PO |
| P5 librería | ARQ y N2: S1. ANA y N5: S2 | S1, porque R-03 quita el desempate de S2 |
| P5 migración | ANA: ficha, migrar al abrir. ARQ: sin medir, señal | Ficha admitida acotada a `candidata`/`operativa`; la demo cumple recreando (R-04) |
| P6 | DEV: protección de `main` de Lab-Documentos sin bypass. VER: T1 con admin | DEV B sobre una rama estable de la demo; `main` al PO con el 15/18 medido (R-01) |
| P7 | DEV (c). REQ: tres gramáticas en los dossiers | DEV (c) más compuerta de monotonía del contenido |
| P8 | DEV y VER: O2 con rojo provocado; dispositivo manual | Se sostiene |
| P9 | DEV, SEG y VER: C, más A declarado. ANA: runner macOS 7–6 | C; la cuenta de Apple es un obstáculo de una línea |
| P10 | ACA: O3-m. LSC: O3 con cinco escenarios | O3-m sin los tres temas del borrador (R-09) |
| P11 workflow | DEV y LSC: W2. N5: `Demo/workflows/`. DEV, VER y ACA: W3 como alternativa del PO | W2 sin proteger `main` (R-01, R-06) |
| P11 alcance | ANA: M2 con outbox. LSC y ACA: mínimo sin outbox. SEG: con login | El mínimo sin outbox ni login |
| Severidades | DEV H-01, DEV H-02, VER H-09 y ANA H-03 como P0 | Los cuatro, P1 (R-06, R-07) |
