| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-10-25 |
| Autor | Comisión Requisitos (núcleo) |
| Corrige | — |

| Campo | Valor |
| --- | --- |
| Rol | Requisitos (núcleo permanente) — comisión a ciegas |
| Fecha | 2026-10-25 |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | Cabecera y §0 (líneas 1–111); por el «Mapa de carga», fila «comisión»: la carta (§5.2), §2.2, §3.2, §3.3 y §4 |
| Documentos cargados con versión | Cadena-De-Consecuencias 2.0 (§2 y §3); Escalas-De-Juicio 1.0 (§3.3 y §3.4, remitidas por la carta); Versionado-Producto-Integral 2.0 (cabecera, §2.6 fila «Rango», §3.3 punto 1: sólo para verificar citas); Release-Y-Despliegue-Versionado 2.0 (§2.2 invariante 13: sólo para verificar la cita). Excepcion-A-Un-Conocimiento: **no cargado** (no propongo dejar de seguir ninguna convención) |
| Clase de objeto | Diseño de una norma o decisión |
| Fichas de excepción | Ninguna |

**Rutas abreviadas en las anclas** (todas bajo `/LAB/Lab-Documentos/`):
`PROMPT` = `Lab-Documentos.Documentacion/PROMPTs/Concepts/01-Framework-Concept/OUTPUTs/Expedientes/0001-Framework-Concept-Maui-Autoactualizable/evidencia/001-prompt-crear-framework-concept.md` (las líneas se cuentan en esta pieza, con sus tres líneas de cabecera);
`F003` = `…/0001-…/actuaciones/003-providencia-contrato-de-entrada.md`;
`BORR` = `Lab-Documentos/Concepts/Framework-Concept/Framework-APP.md`;
`N1`…`N5` = `…/OUTPUTs/Bitacoras/Nucleos/N*.md`; `R2`, `R3`, `R4` = `…/OUTPUTs/Bitacoras/Relevamientos/R*.md`;
`E01` = `…/OUTPUTs/Ensayos/E01-WASM-Descargado-En-WebView/INFORME.md`.

---

## 1. Lectura del objetivo: lo que da por fijo sin origen

El `OBJETIVO` de F003:46-51 cierra con «Agregados de la presidencia: ninguno». La lectura cláusula por cláusula
encuentra **tres agregados sin marcar y una cláusula que depende de una condición no asentada**:

| Cláusula del objetivo | Origen que declara | Lo que dice el pedido | Lectura |
| --- | --- | --- | --- |
| «dejar decidida, **con fuentes y ensayos**» (F003:46) | [prompt, Solicitudes] | «Los investigadores especializados **pueden** ensayar y realizar todas las pruebas que sean necesarias» (PROMPT:39). El propio `ENUNCIADO` lo clasifica como «DATO (autorización de ensayos)» (F003:31-32) | **Agregado**: una autorización pasa a obligación. Choca con `MEDIOS`: «Sin observar: iOS» (F003:88) y con el sujeto «Android e iOS» (F003:15-16): «decidida con ensayos» es inalcanzable para iOS con los medios declarados → H-01 |
| «procedimientos de PR, integración y versionado **que impidan** romper la rama estable» (F003:48-49) | [prompt, Contexto] | «La necesidad pasa por tener **prodicimientos claros** en los PR y en los conceptos de integración y versionado» (PROMPT:17). «Impedir» no está en el prompt | El verbo viene de `Versionado-Producto-Integral` §3.3 punto 1 («Aviso no es impedimento»), no del prompt. Es un origen mal rotulado y, además, esa convención se carga por una condición conjuntiva que el contrato no asentó → H-02 |
| «para apps .NET MAUI con páginas Blazor híbridas» con sujeto «Android e iOS» (F003:15-16) | Framework-APP.md §1 | El prompt nombra «play store de google o app connect de apple» (PROMPT:21): iOS tiene origen en el prompt, pero el contrato cita el borrador, al que a la vez declara «insumo e hipótesis a refutar» (F003:40-41) | El estatus del borrador queda doble: fuente de requisitos para el sujeto, hipótesis para todo lo demás → H-03 |
| «una demo derivada de MovilidadUrbana.MAUI» | [prompt, Solicitudes] | «Tomar base para la construcción de la demo al proyecto `MovilidadUrbana.MAUI`» (PROMPT:33) | Con origen, pero sin criterio de cumplimiento verificable («tomar base» de qué: dominio, capas, persistencia, pruebas, workflow) → H-10 |

**Primer hallazgo:** H-01 (con H-02 y H-03 como los otros dos agregados).

---

## 2. Hallazgos

| Id | Nivel | Ancla | Hallazgo | Impacto si no se corrige | Dirección de la corrección |
| --- | --- | --- | --- | --- | --- |
| H-01 | P1 | E2 — F003:31-32 «"Los investigadores especializados pueden ensayar…" → DATO (autorización de ensayos)» frente a F003:46 «dejar decidida, con fuentes y ensayos»; F003:88 «Sin observar: iOS (no hay Mac ni runner macOS medidos)»; F003:15-16 «Android e iOS» | El objetivo convierte en obligación una autorización (agregado sin marcar) y, sumado al sujeto «Android e iOS», exige ensayos que los medios declarados no pueden producir. P1 (D-01) y P9 (D-06) no tienen respuesta sin «depende» para iOS: E01 concluye «VIABLE CON CONDICIONES en Android» y «C-6. iOS se decide aparte» (E01:237, E01:246) | Dos lecturas divergentes del cierre: una comisión da D-01 por decidida con E01 (Android); otra la da por abierta porque el objetivo exige ensayos y el riesgo mayor del borrador es iOS (BORR:40-43). Retrabajo en la guía (`CTX-IOS`) y en el dictamen | Rotular «con ensayos» como agregado de la presidencia y que quien pidió lo confirme o lo retire; declarar en el objetivo qué grado de verificación vale por plataforma (Android ensayado; iOS «diseñado, NO VERIFICADO» o ensayado) y asentar como obstáculo de una línea al PO si hay cuenta Apple Developer y Mac/runner macOS (N3 §7 pregunta 8) |
| H-02 | P1 | E2 — F003:48-49 «que impidan romper la rama estable [prompt, Contexto]» frente a PROMPT:17 «tener prodicimientos claros»; E1 — `grep -c -i 'atribu' F003` → `0`; E2 — R4 §5.1 «La presidencia lo declara en el contrato» y R4 §10 NV-4; E4 — `Versionado-Producto-Integral` 2.0, cabecera, `Condicion-de-carga`: «… **y** declara la necesidad de atribuir un error de producción a versiones exactas» | (a) «Impidan» tiene origen en una convención (VPI §3.3 punto 1), no en el prompt: origen mal rotulado. (b) Esa convención rige sólo si se declara la necesidad de atribución a versiones exactas; R4 dejó esa declaración a cargo del contrato y el contrato no la hace (0 coincidencias). La convención que más pesa sobre P6 y P7 rige hoy por un «criterio propio» del relevador (R4 §5.1, segunda rama) | Quien aplica puede sostener que VPI no rige (condición de carga incumplida) y leer «procedimientos claros» como documentación sin control de fusión; otro lo lee como protección de rama obligatoria. P6 y P7 salen con dos lecturas | Corregir el origen de la cláusula a [convención VPI §3.3] y asentar en el contrato la condición conjuntiva (o la rama de §1 por la que rige), con su ancla; si no se asienta, mover VPI a «condicionales» y decirlo |
| H-03 | P1 | E2 — F003:40-41 «el borrador Framework-APP.md es insumo e hipótesis a refutar, no el objeto» frente a F003:57-58 (P4 login/biometría, P5 SQLite/outbox/conflictos/migraciones) y F003:46-51 (el objetivo no menciona login, cámara, red, SQLite ni trabajo sin red); BORR:23-33 «Un framework … donde: … 3. cámara … 4. estado de la red … 5. Login … 6. base local SQLite … 7. política de acciones según haya red» | Las preguntas P4 y P5 (y el módulo de cámara, que ninguna pregunta nombra) no tienen cláusula del objetivo que las sostenga. No está dicho si la lista de BORR §1 es **requisito del PO** (lo escribió quien pide, y el prompt manda leerlo: PROMPT:15) o **hipótesis** como el resto del borrador | Una comisión puede responder P4/P5 «fuera del objetivo»; otra diseña login OIDC, Keycloak y outbox (N2 §6.2–6.3). La demo y la guía crecen o se recortan según quien lea | Declarar en el `ENUNCIADO` la función de BORR §1 (líneas 23-33), ítem por ítem: requisito (con su literal, autor PO, fecha 2026-10-03) o hipótesis; y que el objetivo nombre los que entran. Separar «requisito del borrador» de «solución propuesta en el borrador» (D-01…D-07) |
| H-04 | P1 | E2 — PROMPT:37 «Toda la **documentación** generarla en `/LAB/…/Framework-Concept`» frente a F003:72 «RESTRICCIONES DURAS: rutas de **entrega** (Concepts/Framework-Concept, Developer-Guide.md, Demo/)» y N5:429 «copiar el YAML a la raíz de Lab-Documentos (fuera de la ruta autorizada [L1 l.34])»; E1 — `ls Lab-Documentos/.github/workflows` → «No existe el fichero o el directorio»; fuente: GitHub Docs, *About workflows* (N5 [F27]): los workflows se leen de `.github/workflows` en la raíz | El contrato ensancha una restricción del prompt: el literal limita la **documentación**, no los archivos de CI. Con la lectura ensanchada, el workflow pedido («Configura el wofklow…», PROMPT:35) no puede ejecutarse nunca (N5 T-3, N5:230) y P11 («dónde vive su workflow») queda sin respuesta sin «depende» | Se diseña un `Demo/workflows/` de referencia que no corre (N5:420), o se propone sacar `Demo/` a otro repositorio: retrabajo y un requisito del prompt (configurar el workflow) incumplido por una restricción que el prompt no puso | Reescribir la restricción con el literal del prompt (documentación ≠ workflow) y declarar explícitamente si escribir `.github/workflows/` en la raíz de Lab-Documentos está permitido; si la presidencia quiere la lectura amplia, marcarla como agregado y elevarla a quien pidió |
| H-05 | P1 | E2 — PROMPT:35 «Configura **el** wofklow con este runner de github: `runs-on: [self-hosted, i7infra-dev]`»; N3:351-353 (jobs de APK/emulador en el runner propio, en PR); N4:326 «Build de la solución **sin** el proyecto MAUI» en el PR y N4:338 APK + Appium en emulador sólo en la nocturna; N3 §7 pregunta 2 (abierta); E1 heredado y medido en R2:44 «Sin `/dev/kvm` en el contenedor del runner: **no puede correr un emulador** · Medido»; E01:220-223 (emulador API 30 / WebView 83 no arranca Blazor .NET 10) | «El workflow» no tiene referente (no hay ninguno en el destino) ni alcance: no se sabe qué workflow, qué jobs ni qué eventos deben correr en el runner. N3 y N4 lo resuelven distinto (APK en el PR vs. en la nocturna), y la nocturna de N4 (Appium en emulador) **no es ejecutable** en ese runner por una medición que N4 todavía lista como NO VERIFICADO (N4 §9.4) | El requisito puede darse por cumplido con un solo job trivial en `i7infra-dev` o exigir que toda la compuerta corra allí; la suite E2E de dispositivo queda sin lugar de ejecución. P6, P8 y P11 salen con tres respuestas | Fijar en el contrato la lectura que menos agrega del literal (cuál es «el» workflow y qué jobs, como mínimo, llevan ese `runs-on`), y exigir que cada suite recomendada declare **dónde corre** contra los hechos medidos de R2 y E01 |
| H-06 | P1 | E2 — F003:48-49 «impidan romper la rama estable» (sin repositorio); F003:100-102 (destino `hdcm-dev/Lab-Documentos`, PÚBLICO, HEAD 5d5c2b4); N3 §7 pregunta 1 «¿El repo del framework y la demo es público … o privado …?»; N5:450 (E08) «fusión deshabilitada sólo si hay protección de rama»; E4 — VPI 2.0 §3.3 punto 1: «El documento nombra la configuración que convierte el rojo en impedimento, quién la puede tocar y dónde está la evidencia» | No está fijado **sobre qué rama de qué repositorio** se implanta el procedimiento, ni si implantarlo (rojo provocado, botón deshabilitado) es parte del entregable o sólo se enseña. N3 trata como abierta la visibilidad del repositorio cuando el contrato ya fijó la ruta en un repositorio medido como público | Sin repositorio y sin «implantado/enseñado», la guía promete un botón deshabilitado (ESC-6) que nadie verifica, o alguien activa protección sobre el `main` de Lab-Documentos, que también aloja `Guides/` (efecto sobre terceros no medido) | Declarar en el contrato el repositorio y la rama objetivo del procedimiento y el grado exigido (diseñado / implantado con prueba de implantación de VPI §3.4 T1). Cerrar N3 §7 pregunta 1 con el dato ya medido en F003:101-102, o justificar por qué sigue abierta |
| H-07 | P1 | E2 — N1:391-393 `"version": "2026.10.25.3"`, `"bridgeVersion": "2"`; N2:438 «Versión del puente `MAYOR.MENOR`»; N3:363 «Paquete de contenido: SemVer + metadatos de build con el commit (`3.7.2+a1b2c3d`)» y N3:230 `bridgeVersion 2.1.0`; N1:366 «El cliente rechaza `version` ≤ la instalada»; E4 — SemVer 2.0.0 §10: «Build metadata MUST be ignored when determining version precedence. Thus two versions that differ only in the build metadata, have the same precedence» (https://semver.org/spec/v2.0.0.html, consultada 2026-10-25) | Tres gramáticas para el paquete de contenido (fecha, SemVer+build) y tres para el puente (entero, `MAYOR.MENOR`, SemVer). La regla anti-rollback (≤) no es decidible con la gramática de N3: dos builds `3.7.2+a` y `3.7.2+b` tienen la misma precedencia | Implementadores distintos comparan versiones distinto en el actualizador, en el manifiesto y en la compuerta; un paquete reconstruido con el mismo número puede quedar rechazado o aceptado según la lectura (y Release-Y-Despliegue inv. 2 prohíbe reutilizar la identidad) | Una gramática por línea (cascarón, contenido, puente, NuGet) con su regla de comparación escrita y un ejemplo que la ejercite; la regla anti-rollback debe nombrar sobre qué campo ordena |
| H-08 | P1 | E2 — BORR:134 «`minShellVersion`: versión mínima del cascarón»; E4 — VPI 2.0 §2.6 (línea 225): «**Nunca un piso a secas**»; N1 §7 pregunta 5 (mínimo vs coincidencia exacta); N2:438 (MAYOR sube `minShellVersion`) y N2 §4.2 (`handshake` además); N3:204-221 (rango del puente con techo «además, o en lugar») | Tres mecanismos de compatibilidad (piso de cascarón, rango del puente, `handshake`) sin regla de precedencia cuando discrepan, y uno de ellos (piso a secas) contraría una convención que rige | P3 no se responde sin «depende»: un contenido puede ser aceptado por el manifiesto y rechazado por el `handshake`, o al revés; la prueba de contrato (N4) no sabe qué fijar | Que el dictamen nombre **un** mecanismo que decide la compatibilidad, en forma verificable por expresión regular (VPI §2.6), y el papel subordinado de los otros (p. ej. degradación de funciones opcionales) |
| H-09 | P1 | E2 — N2:488 «**D-05 → S1 (`sqlite-net-pcl`) para el framework**» con colecciones JSON por el puente, frente a N5:413 «`Movilidad.Shell/` … Infrastructure/ EF Core SQLite del caso base, con migraciones en vez de EnsureCreated»; E2 — R4 §7 T-3 (migraciones al arrancar vs VPI §2.7 cláusula 2, «se rechaza»); R4 §5.9 (EF-Layer condicional a D-05) | Dos dossiers recomiendan persistencias incompatibles para la misma demo, y ninguno dice **cuándo** corren las migraciones; la condicional EF-Layer rige o no según cuál gane | P5 tiene dos respuestas; la demo y la guía (`SQLite-y-Migraciones.md`) se escriben dos veces; una migración al arrancar sin ficha deja de seguir VPI §2.7 en silencio | Exigir una sola decisión D-05 para framework **y** demo, con el momento de aplicación de las migraciones; si es «al arrancar», que quien lo propone tramite la ficha (R4 T-3) |
| H-10 | P1 | E2 — N2 §6.5 tabla: «Login OIDC + PKCE contra Keycloak en contenedor · Sí» (N2:502), «Desbloqueo local · Sí en Android», «edición de localidad con 412 · Sí» (N2:504); N5:442-451 (etapas E00–E09: ninguna de login ni de desbloqueo); N5:217 «No tiene red, servidor, login…» (el caso base); F003:84 «FUERA DE ALCANCE: … la API del negocio real»; PROMPT:33 «Tomar base … `MovilidadUrbana.MAUI`» | El alcance de la demo no es único: N2 incluye login, desbloqueo y conflicto 412; N5 no los tiene en ninguna etapa. Ningún insumo dice qué servidor de API responde al outbox y al 412 ni dónde vive (la API real está fuera de alcance; la de demo no está ni dentro ni fuera). «Tomar base» no tiene criterio comprobable | P11 sin respuesta sin «depende»; la demo puede no compilar un flujo que la guía enseña (o al revés); la base mecánica no tiene con qué medir «derivada de MovilidadUrbana.MAUI» | Que el dictamen de P11 dé una lista cerrada de capacidades de la demo con su etapa y su evidencia, declare el servidor de demo (qué es, dónde vive, qué emula) y defina «tomar base» como una lista de piezas del caso base que se conservan, comprobable por archivo |
| H-11 | P1 | E2 — N1:468-470 «o (b) el primer arranque en el g42 es **inaceptable para la mesa**»; N1:450-451 «R1. … una función nueva **de peso** se publica también por tienda»; BORR:362 «Si pasa → seguir con A. Si no → B»; E01:248-250 (4,4–6,3 s del proceso al primer render en el g42) | Los criterios que deciden D-01 y la regla R1 no son verificables: no hay umbral numérico de arranque ni instrumento, ni criterio ni responsable para «de peso». Hay una medición (E01) sin umbral contra el cual juzgarla | El cierre de P1 depende del gusto de quien vote; la regla R1, que es la defensa de política ante Apple (N1 §4.3), queda sin aplicar o se aplica distinto en cada PR | Pedir umbrales con su instrumento y su dispositivo (el que mide E01), declarados **antes** de juzgar el resultado, y un criterio operativo de «función nueva de peso» con el actor que lo decide (N5 `ACT-03`/`ACT-04`) y el lugar donde se registra |
| H-12 | P2 | E2 — N4:237 `ci-ok` «falla si alguno no es `success` ni `skipped`»; N3:347 `ci-ok`, N4:334 `fw-ok`; fuente: GitHub Docs, *About protected branches*: «Required status checks must have a `successful`, `skipped`, or `neutral` status before collaborators can make changes» (https://docs.github.com/en/repositories/configuring-branches-and-merges-in-your-repository/managing-protected-branches/about-protected-branches, consultada 2026-10-25); E4 por analogía — Release-Y-Despliegue 2.0 inv. 13 «"Saltado" nunca pinta verde en un release» (rige el release, no el PR) | El agregador recomendado acepta `skipped` como verde, y la guarda de forks de N3 (jobs que no corren según el origen del PR) produce justamente saltos. No está escrito qué job puede saltarse y cuál no. Además, el mismo check se llama `ci-ok` en N3/N5 y `fw-ok` en N4 | Un PR puede pasar la compuerta con la suite que importa saltada: el problema que originó el prompt (PROMPT:17) reaparece con el check en verde. Nombres distintos para el único check requerido rompen la regla de protección si se copia de un dossier a otro | Que P6/P8 enumeren qué jobs del agregador pueden terminar en `skipped` y con qué condición, y fijen un único nombre del check requerido |

**Cuenta:** 12 hallazgos; P0: 0; P1: 11; P2: 1. Ninguno llega a P0: los dos candidatos (H-01, iOS inalcanzable; H-04,
workflow no ejecutable) se corrigen leyendo el pedido sin agregados, así que no hacen imposible el objetivo **del
prompt**, sólo el del contrato tal como quedó escrito.

---

## 3. Respuesta a cada pregunta del caso (P1–P11)

Mi competencia no elige entre opciones técnicas. Para cada pregunta digo **qué falta para responderla sin
«depende»** y propongo **la forma verificable** que debe tener la respuesta. Donde recomiendo entre opciones de
forma, corro Cadena-De-Consecuencias §2. Fuente transversal: ISO/IEC/IEEE 29148:2018 (*Systems and software
engineering — Life cycle processes — Requirements engineering*) caracteriza el requisito individual bien formado
como, entre otras cosas, **no ambiguo, singular y verificable** (se cita la norma sin apartado: no se leyó su texto,
que es de pago; la caracterización se tomó de fuentes secundarias halladas por búsqueda el 2026-10-25 —p. ej. el
extracto de VDE-Verlag https://www.vde-verlag.de/iec-normen/preview-pdf/info_isoiecieee29148%7Bed2.0%7Den.pdf—:
**NO VERIFICADO** en la fuente primaria).

**Forma propuesta común a todas las respuestas** (alternativas: F-a «dictamen en prosa con recomendaciones», F-b
«dictamen con una decisión atómica por pregunta, cada una con criterio de aceptación y comprobación»).
Cadena: (1) dónde cae — en quien aplica (la presidencia) y en el lector novato de la guía, que hereda la ambigüedad;
(2) cuánto pesa — medido: en los cinco dossiers hay al menos cinco pares contradictorios para la misma decisión
(H-07, H-08, H-09, H-10, H-12), cada uno un punto de retrabajo; el costo de F-b no se midió (sin medir: líneas extra
del dictamen); (3) qué pierde la alternativa — F-a conserva matices y alternativas pero deja la elección al que
aplica; F-b pierde matiz y obliga a declarar umbrales que pueden revisarse; (4) reversibilidad — F-b es reversible
(una decisión atómica se reemplaza por otra con su folio); F-a no se revierte porque no fijó nada. **Propuesta: F-b.**

| P | Qué falta para responder sin «depende» | Forma verificable que debe tener la respuesta |
| --- | --- | --- |
| **P1** (D-01, modelo de contenido) | (a) Umbral de arranque y de tamaño, con instrumento y dispositivo (H-11); (b) grado de verificación exigido para iOS (H-01); (c) criterio operativo de R1 «de peso» (H-11). Hecho disponible: E01 Android viable con C-1…C-6 (E01:237-246) | Una opción, con sus condiciones C-n como requisitos atómicos y verificables (p. ej. «WebView ≥ N; si no, pantalla X»), y la condición de revisión como hecho comprobable (Cadena §2 punto 4): «si el ensayo iOS da Y, se revisa». iOS rotulado «NO VERIFICADO» si no hay medio |
| **P2** (canal: manifiesto, firma, canales, staging, rollback, retención) | Gramática y orden de `version` (H-07); retención N=2 del borrador vs N≥3 de Release-Y-Despliegue inv. 10 (R4 T-2: cumplir o ficha); dónde vive el manifiesto interno del paquete (R4 T-5) | Esquema del manifiesto con cada campo obligatorio/opcional y su regla de validación; tabla de los casos del actualizador (N4 §3.6) como criterios de aceptación; retención con número escrito |
| **P3** (cascarón, puente, compatibilidad) | Un único mecanismo decisor de compatibilidad (H-08); gramática del puente (H-07) | Regla de compatibilidad expresable como rango `>=A.B.C <D.0.0` (VPI §2.6) con la precedencia explícita respecto de `handshake` |
| **P4** (login y seguridad del teléfono; qué entra en la demo) | Si login/biometría es requisito o hipótesis (H-03); alcance de la demo (H-10); API mínima de Android (N2 §7 pregunta 3) | Decisión D-03 y D-07 atómicas; lista «en la demo / sólo en la guía» por plataforma |
| **P5** (datos locales y sin red) | Si SQLite/outbox es requisito (H-03); una sola D-05 para framework y demo, y el momento de las migraciones (H-09); servidor de demo para conflictos (H-10) | D-04 y D-05 atómicas; tabla de clases de acción con su comportamiento comprobable sin red y con red sin servidor |
| **P6** (procedimiento de PR con i7infra-dev) | Repositorio y rama objetivo, implantado vs enseñado (H-06); referente y alcance de «el workflow» (H-05); condición de carga de VPI asentada (H-02); restricción de ruta leída con su literal (H-04) | Procedimiento en pasos con el control que impide (configuración, quién la toca, evidencia: VPI §3.3 punto 1) y, si es implantado, la prueba de implantación (rojo provocado) |
| **P7** (líneas de versión) | Gramática única por línea y regla de comparación (H-07); clase del paquete de contenido, que VPI §2.3 no tiene (R4 T-4) | Tabla línea → gramática → fuente única → regla de orden → ejemplo |
| **P8** (pruebas por capa y compuerta) | Lugar de ejecución de cada suite contra lo medido (H-05: runner sin KVM; emulador API 30 inservible para WASM); qué puede quedar `skipped` (H-12) | Tabla suite → capa → evento (PR/nocturna/etiqueta) → runner → puede saltarse sí/no; un único nombre del check requerido |
| **P9** (D-06, iOS) | Hecho que sólo tiene el PO: cuenta Apple Developer, certificados y Mac o runner macOS (N3 §7 pregunta 8). Es un **obstáculo**, no una decisión (Cadena §3): pregunta de una línea a quien pidió | Respuesta con dos ramas declaradas por el hecho que falta, y la rama por defecto mientras no llegue; lo no verificado rotulado |
| **P10** (estructura de la guía) | Precedencia entre dos restricciones duras del contrato: «Developer-Guide.md» (un archivo, PROMPT:33) y «perfil Study-Guide» (conjunto) (F003:72-75; R3:365 H-06; N5 T-2) | Árbol de archivos cerrado, con el rol de `Developer-Guide.md` y la lista de variantes declaradas frente al perfil |
| **P11** (alcance mínimo de la demo, cómo corre, dónde vive su workflow) | Alcance único (H-10); criterio de «tomar base» (H-10); permiso de escribir `.github/workflows/` en la raíz o repositorio aparte (H-04) | Lista cerrada de capacidades con etapa y evidencia; comando de corrida; ruta del workflow que GitHub ejecuta, con su `runs-on` |

---

## 4. Lo que revisé y está bien

1. **El enunciado clasifica cada frase del pedido por su función** (requisito, deseable, dato) y declara la lectura
   que menos agrega en las frases de doble lectura (F003:13-36); los errores que señalo (H-01, H-02) están en el paso
   al objetivo, no en el enunciado.
2. **E01 separa con rigor lo medido de lo no verificado**: hipótesis única, condiciones C-1…C-6 atómicas y una tabla de
   lo que queda sin verificar con motivo (E01:24-35, 237-270). Es la forma que pido para los dictámenes.
3. **N1 contrasta las políticas de Apple y Google con texto literal fechado** y rotula como «Criterio propio» cada
   inferencia (N1 §4.1–4.3), lo que hace auditable la tensión 2.5.2 / §3.3.1 B.

---

## 5. Solicitudes de convocatoria (fuera de mi competencia)

| Señal | Ubicación | A quién |
| --- | --- | --- |
| Si un `.wasm` ejecutado por WebKit es «interpreted code» para Apple y si el puente cae en la guía 4.7.2 | N1:118-131, N1:175-178 | Comisión de dominio de políticas de tiendas / plataforma iOS |
| Exposición del runner autoalojado de org a PR de forks en repos públicos (`first_time_contributors`) | N3 §4.5; R2:44 | Comisión de seguridad de CI |
| El túnel `cloudflared` expuso contenido del ensayo por ~10 min; criterio para ensayos futuros | E01:323 | Presidencia / seguridad |
| Versión mínima real de WebView para Blazor .NET 10 (94 es cota del primer error) | E01:220-223, E01:268 | Perito / arquitectura MAUI |

---

## 6. Fichas de excepción

Ninguna: no propongo dejar de seguir ninguna convención que rige. Señalo dos lugares donde **otro** rol deberá
tramitar una si sostiene lo que el borrador dice: migraciones al arrancar (R4 T-3, H-09) y retención N=2 (R4 T-2, P2).

Sigue: incorporación del siguiente informe y resolución · presidencia
