| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-10-25 |
| Autor | Comisión Integración, PR, versionado y pruebas |
| Corrige | — |

# Informe de comisión — Integración continua, PR, versionado y estrategia de pruebas (absorbe QA)

| Campo | Valor |
| --- | --- |
| Rol | Comisión «Integración continua, PR, versionado y estrategia de pruebas (absorbe QA)» |
| Fecha | 2026-10-25 |
| Expediente | 0001-Framework-Concept-Maui-Autoactualizable |
| Clase de objeto | Diseño de una norma o decisión |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | Líneas 1–111 (cabecera y §0 con el «Mapa de carga»); fila «Sos una comisión»: §5.2 (la carta), §2.2, §3.2, §3.3, §4 |
| Documentos cargados con versión | Cadena-De-Consecuencias 2.0 (§2); Escalas-De-Juicio 1.0 (§3.3); Versionado-Producto-Integral 2.0 (§2.3–§2.6, §2.8, §3.3, §3.4, §5.7); Release-Y-Despliegue-Versionado 2.0 (§2.2, invariantes 1, 2, 10, 13); Versionado-Paquetes-NuGet 2.0 (§2.7); Conformacion-Pull-Request-Manual 2.0 (§0, tabla «Qué queda explícitamente afuera»). Excepcion-A-Un-Conocimiento **no se cargó**: no propongo dejar de seguir ninguna convención (§6) |
| Insumos leídos | Evidencia 001 (pedido, desde la línea 4); folios 001, 002 y 003; borrador Framework-APP.md; bitácoras 01 y 02; dossiers N3 y N4 enteros; N5 §4.8, §6.3, §6.4 y §7; R1 §10–§15; R2 §1, §2.4, §3.1 y §5; R4 §5, §7, §9 y §10; E01 §1, §2 y §6–§8 |
| g42 | **No se usó** (ni adb ni instalación). La regla de la presidencia sobre `flock` no me alcanza en este despacho |

## Mediciones propias de esta comisión (E1)

Todas son de sólo lectura sobre GitHub o se corrieron en contenedores efímeros con el prefijo `fc-`, sobre un volumen que se borró al terminar. No hubo push, merge, etiquetas ni publicación.

| Id | Comando (resumido) | Salida | Hora |
| --- | --- | --- | --- |
| M-1 | `curl https://api.github.com/repos/hdcm-dev/Lab-Documentos` (sin credenciales) | `"private": false`, `"visibility": "public"`, `"default_branch": "main"` | 2026-10-25T20:20Z |
| M-2 | `curl …/Lab-Documentos/branches/main` | `"protected": false` | ídem |
| M-3 | `curl …/Lab-Documentos/rulesets` y `…/rules/branches/main` | `HTTP 200`, `[]` y `[]` | ídem |
| M-4 | Con la credencial de git en memoria, sin guardarla, `GET …/branches/main/protection` | `HTTP 404 "Branch not protected"` (no es un 403 que pida cambiar de plan) | ídem |
| M-5 | Igual, `GET /repos/hdcm-dev/Lab-Documentos` → `permissions` | `"admin": true, "maintain": true, "push": true` | ídem |
| M-6 | Igual, `GET …/actions/permissions` y `…/actions/permissions/fork-pr-contributor-approval` | `enabled: true, allowed_actions: "all", sha_pinning_required: false`; `approval_policy: "first_time_contributors"` | ídem |
| M-7 | Igual, `GET /orgs/hdcm-dev/actions/runner-groups` | `HTTP 403` «You must be an org admin or have the runners and runner groups fine-grained permission» | ídem |
| M-8 | `ls -a` en el clon de Lab-Documentos; `git status --short` | No hay `.github/`; `?? Concepts/` (la carpeta no está versionada); HEAD `5d5c2b4` | ídem |
| M-9 | `docker exec <runner> cat .runner` + `printenv LABELS RUNNER_SCOPE` en los tres runners del host | `i7infra-runner-dev` → `https://github.com/hdcm-dev`, `ephemeral: true`, etiquetas `i7infra,i7infra-dev,dotnet,maui-android`, `org`. Los runners `-ng` y `-ap25` son de otras organizaciones | ídem |
| M-10 | `GET /repos/hdcm-dev/Lab-E2E.WebBlazor/actions/runs/40176198598/jobs` (corrida nocturna de `e2e.yml`) | El job «Publicar la aplicación» corrió en `i7infra-runner-dev` `['self-hosted','i7infra-dev']` (2 min 15 s); las cuatro «Pruebas (…)» corrieron en `ubuntu-latest` | ídem |
| M-11 | `git archive 8fb4c3a src/MovilidadUrbana.MAUI tests/MovilidadUrbana.MAUI.Tests` → imagen del runner `runner-github-dev/dotnet-maui:2.338.1`, `dotnet test … -c Release -warnaserror` | SDK `10.0.402`; `Passed! - Failed: 0, Passed: 18, Skipped: 0, Total: 18, Duration: 2 s`; **28 s de pared** con restore en frío | ídem |
| M-12 | Igual que M-11, cambiando `DigitosDelCodigoPostal = 4` → `5` (`LocalidadRules.cs:16`) | `Passed! … 18/18`, `rc=0`: **queda en verde** | ídem |
| M-13 | Igual que M-11, cambiando `[GeneratedRegex(@"^\d{4}$")]` → `\d{5}` (`LocalidadRules.cs:34`) | `Failed GuardarNuevaAvisaYVuelve`, `Failed ModificarActualiza`; `Failed! - Failed: 2, Passed: 16`; `rc=1`: **queda en rojo** | ídem |

---

## 1. Lectura del objetivo: lo que da por fijo sin origen

El OBJETIVO del folio 003 (líneas 46–51) tiene origen en cada cláusula. La que lo pierde en el camino es la **restricción dura** que se apoya en él: «rutas de entrega (Concepts/Framework-Concept, Developer-Guide.md, Demo/)» (folio 003:72). El pedido dice «Toda la **documentación** generarla en `/LAB/…/Concepts/Framework-Concept`» (evidencia 001:37). No dice «todo el entregable» ni «el workflow». En cambio, «Configura el wofklow con este runner» (evidencia 001:35) no fija una ruta.

Leer la ruta de la documentación como ruta obligatoria del workflow es un **agregado**. Ese agregado produce el callejón T-3 de N5: un YAML en `Demo/workflows/` que GitHub nunca ejecuta (N5 §6.3; GitHub ejecuta sólo `.github/workflows` de la raíz, N5 [F27]). Es el hallazgo H-01.

Hay un segundo dato fijo sin origen. El contrato presenta el caso base como el «caso que funciona … con workflow android.yml» (folio 003:37–38). Ese workflow corre en `ubuntu-latest` (`android.yml:37`), no en `[self-hosted, i7infra-dev]`, y está filtrado por `paths` (`android.yml:12-19`). Como referencia del **runner** y de la **compuerta**, no funciona: va en H-07.

---

## 2. Hallazgos

| Id | Nivel | Ancla con su cita | Hallazgo | Impacto si no se corrige | Dirección de la corrección |
| --- | --- | --- | --- | --- | --- |
| H-01 | **P0** | E2 evidencia 001:37 «Toda la documentación generarla en …/Concepts/Framework-Concept» frente a folio 003:72 «RESTRICCIONES DURAS (del pedido): rutas de entrega (Concepts/Framework-Concept, Developer-Guide.md, Demo/)»; E1 M-8 (no hay `.github/` en Lab-Documentos); E2 N5 §6.3 «la carpeta se llama `workflows/` y no `.github/workflows/` a propósito, porque ahí GitHub no la ejecutaría» | El contrato extiende a **todo** el entregable una restricción que el pedido pone sólo sobre la **documentación**. Con esa lectura, el workflow pedido (evidencia 001:35) no puede ejecutarse en ningún lado: es un YAML de referencia. Entonces no existe la compuerta que el objetivo exige («que impidan romper la rama estable», folio 003:48–49) | El objetivo es imposible tal como lo lee el contrato: la demo no tendría CI real y la guía enseñaría un procedimiento que nunca corrió (Versionado-Producto-Integral §3.4, T5: «diseñado, no implantado») | Releer la restricción con la lectura que menos agrega: documentación en `Framework-Concept/`; el workflow, donde GitHub lo ejecuta (`.github/workflows/` de la raíz del repositorio que aloje la demo), con un filtro de alcance a `Concepts/Framework-Concept/Demo/**`. Si la presidencia duda, la frase tiene dos lecturas y se escribe con las dos (Mesa-De-Expertos-A-Pedido §0, punto 1). Ver P11 |
| H-02 | **P0** | E1 M-2, M-3, M-4 (`protected: false`, rulesets `[]`, `404 Branch not protected`); E4 Versionado-Producto-Integral §3.3, punto 1: «Un flujo que se pone rojo sin un mecanismo que bloquee la fusión es un aviso, no una compuerta»; §3.4, T1 | Hoy `main` de `hdcm-dev/Lab-Documentos` no tiene ningún control que impida fusionar en rojo. El 404 (y no un 403) más el `admin: true` (M-5) prueban que **sí se puede** configurar: el repositorio es público (M-1) y la credencial del PO es administradora. La falla que dio origen al pedido (evidencia 001:17) seguiría intacta aunque exista el workflow | Cualquier workflow que se escriba es un aviso; la guía enseñaría «la compuerta impide» y sería falso en la propia demo | Implantar T1 **antes** que cualquier otra compuerta: protección clásica de `main` (o un ruleset) con PR obligatorio y **un único** check requerido (el agregador). La prueba de implantación es la captura del botón deshabilitado ante un rojo provocado (M-13 sirve de rojo). Configurarlo es una fase irreversible para el panel: lo hace quien aplica, con permiso del PO |
| H-03 | **P1** | E3 (doc oficial, *About protected branches*, consultada 2026-10-25: las restricciones «don't apply to people with admin permissions» salvo que se active «Do not allow bypassing the above settings»); E1 M-5 (el PO es `admin`) | En un equipo donde quien fusiona es administrador, la protección por defecto **no lo frena**: el «impedir» del objetivo depende de una casilla que el borrador, N3 y N4 no nombran | La compuerta vuelve a ser un aviso justo para la persona que fusiona; se reproduce el problema del pedido con la protección «puesta» | Exigir en el procedimiento «no permitir saltear» (aplicar también a administradores), y que la prueba de implantación se haga **con la cuenta administradora** |
| H-04 | **P1** | E3 (doc oficial *Secure use reference*, 2026-10-25: «self-hosted runners should almost never be used for public repositories on GitHub»); E1 M-6 (`first_time_contributors`), M-9 (runner de **organización**), R2:383 (usuario `root`); E2 evidencia 001:35 (mandato del runner) | El pedido fija el runner propio, y el repositorio que lo alojaría es público. La política de aprobación es la que la doc califica de débil, el runner corre como root y sirve a toda la organización. No se pudo leer si el grupo del runner admite repos públicos (M-7: 403) | Un PR desde un fork, de alguien con un aporte previo aceptado, ejecuta MSBuild arbitrario en i7infra (la ejecución por MSBuild es NO VERIFICADO por ensayo, N3 §4.5). El costo cae en el host compartido con otros escenarios | Cumplir el mandato y acotarlo, sin ficha porque no se aparta de nada: los jobs del runner propio con guarda `github.event.pull_request.head.repo.full_name == github.repository` (patrón ya usado en `ci.yml:113-116` del caso base); aprobación de forks en «todos los colaboradores externos»; grupo de runners limitado al repositorio; `permissions: contents: read`; nada de secretos en jobs de PR. Que la presidencia pida a un administrador de la org leer el grupo (obstáculo, no bloqueo) |
| H-05 | **P1** | E2 `ci.yml:178` del caso base (`success|skipped) ;;` dentro del agregador `ci-ok`); E4 Versionado-Producto-Integral §5.7: «Un paso que no pudo correr no deja verde»; Release-Y-Despliegue-Versionado §2.2 inv. 13 | El agregador que N3 y N4 proponen copiar acepta `skipped` como verde. Si una suite obligatoria se saltea (por condición, por un `needs` fallido o porque faltó un recurso), `ci-ok` queda verde y el check requerido habilita la fusión | Verde falso en la única compuerta exigida; la guía enseñaría el anti-patrón | En el agregador del framework, `skipped` cuenta como **rojo** para las suites obligatorias. Sólo se admite para un job que se saltea por diseño y con motivo escrito (p. ej. `draft`). La regla tiene un rojo provocado propio: forzar que una suite se saltee y ver el check en rojo |
| H-06 | **P1** | E1 M-12 (cambiar `DigitosDelCodigoPostal` 4→5 deja **18/18 en verde**) y M-13 (cambiar el patrón deja 2 en rojo); E2 `LocalidadRules.cs:15-16` «El patrón de `CodigoPostal` lo espeja» | En el caso base, la constante y el patrón dicen lo mismo en dos lugares y ninguna prueba los ata: el ejemplo de E08 («PR que rompe», N5 §6.4) depende de qué línea toque el alumno para verse en rojo. Además muestra el riesgo general: una suite verde no prueba que mira lo que dice mirar (Versionado-Producto-Integral §3.4, T2: el rojo provocado es obligatorio) | El tutorial E08 puede salir en verde según el cambio que haga el lector, y la guía enseñaría que «la compuerta atrapa» sin evidencia | Cada suite que la compuerta exige se entrega con **su rojo provocado medido** (un parche que la pone en rojo, guardado en `etapas/`). Para E08, fijar el parche de M-13 (patrón), no el de M-12. Sumar al caso portado una prueba que ate constante y patrón (es materia de la demo, no del caso base, que no se cambia: folio 003:84) |
| H-07 | **P1** | E2 `android.yml:12-19` (`paths:`) y `android.yml:37` (`runs-on: ubuntu-latest`); E3 doc oficial *Troubleshooting required status checks* (2026-10-25): un workflow salteado por filtro deja su check «Pending» y bloquea, «Avoid requiring workflows that can be skipped» | El «caso que funciona» no sirve de referencia para la compuerta en dos ejes: corre en otro runner y está filtrado por `paths`. Copiado como check requerido, deja el PR en «Pending» cada vez que no toca esas rutas; copiado tal cual, no cumple el mandato del runner | Dos lecturas divergentes entre implementadores: unos exigen `android.yml` y otros `ci-ok` | Tabla diferencial explícita en la guía (caso base → demo): runner, filtro y agregador. El único check requerido es el agregador, en un workflow **sin** `paths` sobre el disparo de PR. El filtro de alcance a `Demo/**` va dentro del job (un paso que decide), no en el `on:` |
| H-08 | **P1** | E2 R2:390 (sin `/dev/kvm` en el runner), R2:397 (sin emulador ni iOS); E2 E01 §6.3 (emulador API 30, WebView 83: `Uncaught SyntaxError` y «Loading» para siempre); E2 N4 §5.2 («Appium en emulador» en la nocturna) | El plan de N4 pone Appium en emulador en la nocturna sin fijar la imagen. El único emulador del laboratorio (API 30, WebView 83) **no puede arrancar** el contenido Blazor .NET 10, y el runner pedido no tiene KVM | La nocturna de emulador sería un rojo permanente o, peor, se sacaría de la CI «porque falla», y se enseñaría a ignorarla | La capa de dispositivo no entra en la compuerta. Si va a la nocturna, se declara la precondición medible: imagen con WebView ≥ 94 (cota de E01 C-3) en un host con KVM fuera del contenedor del runner. Si no, queda manual en el g42 al etiquetar, con resultado «k de n». Lo que no corre se escribe como `nada` en la tabla de gobierno (Versionado-Producto-Integral §3.2) |
| H-09 | **P1** | E4 Versionado-Producto-Integral §2.6, línea 225 «Nunca un piso a secas»; E2 Framework-APP.md:134 (`minShellVersion`), :299 (`bridgeVersion`); E2 E01 §7, C-3 (versión mínima de WebView) | Las líneas de versión del borrador atan contenido → cascarón con un piso (T-1) y omiten una dimensión de compatibilidad que el ensayo **midió**: la versión del WebView del sistema. El contenido depende de tres cosas que no controla: puente, cascarón y WebView | Un paquete para el puente v1 se activa en un cascarón con puente v2 incompatible; o un paquete válido queda en «Loading» en un WebView viejo, sin pantalla propia | Ver P7: el manifiesto declara el rango con techo contra el **puente** (`compatible-con-puente: >=A.B.C <D.0.0`, forma canónica de §2.6) y la versión mínima de WebView. `minShellVersion` se deriva (no es una fuente) o desaparece; lo decide la comisión del puente (convocatoria S-1) |
| H-10 | **P2** | E4 Versionado-Producto-Integral §2.3 (sin fila para un paquete de contenido; T-4) y §2.8 («El sufijo de pre-release marca la fase»); E2 N3 §4.7, [F21b] (`CFBundleShortVersionString` sólo admite tres enteros) | El cascarón no puede llevar sufijo de pre-release en su versión visible. Por eso la fase del producto **no se puede inferir del número del cascarón**, y §2.8 la inferiría como `operativa` si no se declara | La demo nace leída como `operativa` y carga obligaciones (roll-forward, expandir/contraer) que no le sirven | Declarar la fase en `versionado/rutas.json` (Versionado-Producto-Integral §3.1) desde el primer commit de la demo (`diseño`). El paquete de contenido se trata como **paquete**: SemVer 2.0.0 completo, con metadatos de commit |
| H-11 | **P2** | E2 R2:384 (runner: SDK 10.0.402, workload 10.0.110) frente a R2:37 y R1 §10 (imagen local: SDK 10.0.400, manifiesto 10.0.20); E2 R1:424 («SDK y `MauiVersion` sin fijar (sin `global.json`)») | Local y CI resuelven SDK y MAUI distintos; `$(MauiVersion)` depende del workload de la máquina | «En mi máquina compila» contra el rojo de CI, o al revés; diferencias no reproducibles entre alumno y compuerta | `global.json` con SDK y `rollForward` declarado, y `MauiVersion` fijada en un archivo de propiedades importado explícitamente (Versionado-Producto-Integral §2.4); la guía enseña a leer las dos versiones en el log de la corrida |
| H-12 | **P2** | E4 Versionado-Paquetes-NuGet §2.7 (línea 225: un marco que compila sólo en otro sistema operativo «no queda cubierto antes de fusionar si la integración corre en uno solo. Eso se declara»); E1 M-9 y R2:397 (runner Linux, sólo `maui-android`) | Ni N3 ni N4 escriben qué del marco `net10.0-ios` queda **sin** compuerta. N3 §6.5 lo deja como «transición» | La guía permite suponer que iOS está cubierto por la misma compuerta | Declaración explícita en el procedimiento de PR y en la guía: «iOS: sin compilar antes de fusionar», con la condición que la levanta (ver P9) |

**Lo que no es hallazgo y queda como pregunta (C).** Que el `dotnet publish` común de Blazor WASM ande dentro del runner sin `wasm-tools` está medido en `lab-e2e-base-dev`, no en el runner (R2:399-401, NO VERIFICADO allí). El empaquetado del contenido en la compuerta se apoya en ese supuesto y conviene medirlo en el runner real (obstáculo de una línea abajo).

---

## 3. Respuestas a las preguntas del caso

### P6 — Procedimiento de PR e integración que impide fusionar algo que rompe la rama estable, con runner i7infra-dev

**Alternativas consideradas.**

| Id | Alternativa |
| --- | --- |
| A | Workflow en el runner propio sin protección de rama (como hoy) |
| B | GitHub Flow + protección clásica de `main` con PR obligatorio, un único check agregador requerido, modo estricto y «no permitir saltear»; jobs del runner propio con guarda de mismo repositorio |
| C | B con rulesets en vez de protección clásica |
| D | B + merge queue |
| E | Repositorio privado con el runner propio |

**Cadena de consecuencias (Cadena-De-Consecuencias §2).**

| Opción | Dónde cae el costo | Cuánto pesa | Qué pierde | Reversibilidad |
| --- | --- | --- | --- | --- |
| A | En la rama estable: el rojo no frena | Medido: hoy `protected: false` (M-2, M-4). Es exactamente el problema del pedido | Pierde el objetivo | Reversible, pero no resuelve nada |
| B | En quien abre el PR: espera el check. En el administrador: una configuración | Medido: 18 pruebas en 28 s de pared en la imagen del runner (M-11). El build y el APK del cascarón rondan los 2 min con NuGet tibio (R2:44, 112–167 s) | Frente a C, la protección no se apila; frente a D, la rama tiene que estar al día (más corridas) | Reversible: una configuración del repositorio |
| C | Igual que B | Documentado como disponible en repos públicos Free (N3 [F5b]); **no ensayado** | Más piezas que explicar a un novato; la página oficial se contradice sobre el plan (N3 §4.2) | Reversible |
| D | En el workflow: tiene que escuchar `merge_group` o el check nunca se reporta (N3 [F12]) | Sin medir; la propia doc la recomienda para ramas con muchos PR por día de muchos autores | Simplicidad, en un equipo chico | Reversible |
| E | En el bloqueo: en Free con repositorio privado no hay protección (403 medido en otro repositorio, Versionado-Producto-Integral §3.3, punto 1) | Medido en el origen de la convención | Pierde el «impedir» | Cambiar de visibilidad alcanza a terceros: costoso |

**Propuesta.** **B**. Rama estable única `main`, ramas cortas y PR obligatorio (GitHub Flow, doc oficial https://docs.github.com/en/get-started/using-github/github-flow, consultada 2026-10-25). El procedimiento escrito tiene seis piezas:

1. **T1 primero** (Versionado-Producto-Integral §3.4): protección de `main` con PR obligatorio, check requerido único (`fw-ok`), modo estricto y «Do not allow bypassing the above settings» (H-03; doc *About protected branches*, URL de N3 [F4], consultada 2026-10-25). Prueba de implantación: el parche de M-13 en un PR, con el botón deshabilitado y la captura versionada.
2. **Un solo workflow de PR sin `paths` en el `on:`** (H-07; doc *Troubleshooting required status checks*, N3 [F8]). El alcance a `Demo/**` lo decide un paso del job.
3. **Agregador que no acepta «saltado»** en las suites obligatorias (H-05).
4. **Runner**: los jobs van a `runs-on: [self-hosted, i7infra-dev]` (cumple el pedido; el arreglo empieza por `self-hosted`, como recomienda la doc *Choosing the runner for a job*, consultada 2026-10-25). Llevan guarda de mismo repositorio; los PR de forks no corren en el runner propio y el agregador los marca rojo hasta que un mantenedor los traiga a una rama propia (H-04; doc *Secure use reference*, consultada 2026-10-25).
5. **Merge humano** según Conformacion-Pull-Request-Manual 2.0: «el merge es el punto donde alguien que no escribió el cambio lo mira». La guarda automática (Conformacion-Pull-Request-Automatico) **no rige** mientras no haya delegación asentada (R4 NV-2).
6. **Plantilla de PR** con la unidad declarada y «qué sigue después del merge» (Conformacion-Pull-Request-Manual §2).

Merge queue (D) se pospone. Condición para revisarlo, comprobable: más de N PR por día con choques de base, medido con la API de corridas.

### P7 — Líneas de versión, gramática y relación

**Alternativas.** (a) Un número único. (b) Tres líneas con `minShellVersion` como piso (borrador). (c) Líneas separadas con rangos con techo y la versión mínima de WebView como dimensión de compatibilidad.

| Opción | Dónde cae | Cuánto pesa | Qué pierde | Reversibilidad |
| --- | --- | --- | --- | --- |
| (a) | En el soporte: no se puede atribuir un error a una combinación | Sin medir; el contenido sale varias veces por cada cascarón (borrador §2) | Toda compatibilidad | Cambiarlo después alcanza a dispositivos instalados: irreversible en la práctica |
| (b) | En el teléfono del usuario: un piso lo satisface un mayor incompatible | E4 §2.6 («nunca un piso a secas») | El techo | Igual que (a), una vez que hay paquetes publicados |
| (c) | En el pipeline: una línea parseable más y una compuerta que la valide | Una línea por manifiesto | Simplicidad mínima | Reversible mientras la fase sea `diseño` |

**Propuesta (c)**, con esta gramática:

| Línea | Gramática | Fuente única | Relación |
| --- | --- | --- | --- |
| Cascarón (tienda) | `ApplicationDisplayVersion` = `MAYOR.MENOR.PARCHE` numérico, sin sufijo (exigencia de `CFBundleShortVersionString`, doc Apple, N3 [F21b]); `ApplicationVersion` = entero monótono (Android `versionCode`, doc https://developer.android.com/studio/publish/versioning; iOS `CFBundleVersion`) | Un archivo de propiedades importado (§2.4) | Implementa un mayor del puente |
| Puente | SemVer 2.0.0 (https://semver.org/); el **mayor** es la identidad del contrato (§2.6, «el `vN` … es el número mayor») | Una constante por pieza, comparada por una compuerta | Lo implementa el cascarón y lo consume el contenido |
| Contenido (paquete) | SemVer 2.0.0 completo + `+<commit>` (T-4: se le asigna la clase «paquete») | El proyecto del contenido | Declara `compatible-con-puente: >=A.B.C <D.0.0` y `webview-minimo: <n>` en el manifiesto **interno** del paquete (Release-Y-Despliegue inv. 3) |
| Paquetes NuGet del framework (si los hay) | Mismo número para todos (Versionado-Paquetes-NuGet §2.1), etiqueta `nuget-v<x>` | Archivo de propiedades | Independiente del cascarón de la demo |
| Fase | `versionado/rutas.json` → `diseño` (H-10) | — | Fija qué reglas rigen |

El canal (`dev`/`beta`/`prod`) **no** es una línea de versión: es un puntero que promueve el mismo artefacto (Release-Y-Despliegue inv. 1). Si `minShellVersion` sobrevive, lo decide la comisión del puente (S-1); para N3 alcanza con que no sea la única declaración.

### P8 — Qué se prueba en cada capa y qué conjunto es compuerta obligatoria del PR

**Alternativas**: las O1–O4 de N4 §4.

| Opción | Dónde cae | Cuánto pesa | Qué pierde | Reversibilidad |
| --- | --- | --- | --- | --- |
| O1 (sólo unitarias) | En el contenido y el actualizador, sin cobertura | Rápida (28 s, M-11) | Lo nuevo y riesgoso del framework | Reversible |
| O2 (pirámide sin dispositivo) | En el diseño: obliga a abstraer FS, HTTP y reloj, y a generar el puente simulado del contrato | Sin medir en conjunto; las piezas medidas son de segundos o minutos (M-11; R2:39 publish WASM 19 s) | Fallas que sólo aparecen en el WebView real (las ve la nocturna o la etiqueta) | Reversible |
| O3 (+ emulador en PR) | En la compuerta: KVM ausente en el runner (R2:390) y emulador API 30 incapaz (E01 §6.3) | Medido como **imposible hoy** en el runner pedido | El mandato del runner, o la compuerta | Requiere cambiar la infraestructura |
| O4 (dispositivo en PR) | En el g42, compartido con otra sesión del PO (regla de `flock` de la presidencia) | Una pantalla, sin paralelismo | Disponibilidad de la compuerta | Reversible, pero inviable como check requerido |

**Propuesta: O2**, con tres ajustes a N4:

| Capa | Herramienta | ¿Compuerta del PR? | Rojo provocado que se entrega |
| --- | --- | --- | --- |
| Build sin el proyecto MAUI, avisos como error | `dotnet build -warnaserror` | Sí | Un `CS1574` o similar (precedente del caso base, N3 §4.11) |
| Unitarias de dominio, servicios del cascarón y ViewModels (`net10.0`) | NUnit/xUnit | Sí | Parche de M-13 (medido: 2 en rojo) |
| Componentes Razor del contenido | bUnit | Sí | Parche en una página |
| Contrato del puente (consumidor, proveedor, N-1) | Esquema y ejemplos versionados (o PactNet, por decidir con un ensayo) | Sí | Quitar un miembro sin subir el mayor |
| Actualizador (los diez casos de N4 §3.6) | Servidor local de la corrida y clave **de prueba** | Sí | Paquete con un byte cambiado |
| Contenido WASM en navegador con puente simulado | Playwright Chromium (caché presente en el runner, R2:388) | Sí | Ruptura visible en una página |
| Compilación del APK del cascarón | `dotnet publish -f net10.0-android` en el runner | Sí, porque el runner lo hace (R2:396; ~2 min, R2:44) | Error de compilación del cascarón |
| Dispositivo Android | Appium o manual en el g42 | No: al etiquetar, resultado «k de n» | — |
| Emulador | — | No: sólo con la precondición de H-08 | — |
| iOS | Ver P9 | No | — |

Ajustes: (1) el agregador no acepta `skipped` (H-05); (2) **cada suite obligatoria entra con su rojo provocado medido** (H-06; Versionado-Producto-Integral §3.4, T2); (3) las pruebas intermitentes van a cuarentena con expediente, no a reintentos (Luo, Hariri, Eloussi y Marinov, «An empirical analysis of flaky tests», FSE 2014, doi:10.1145/2635868.2635920, citado y leído en N4).

La forma de pirámide se apoya en Vocke, H., «The Practical Test Pyramid», martinfowler.com, 2018 (https://martinfowler.com/articles/practical-test-pyramid.html, consultada por N4 el 2026-10-25). Cobertura mínima como compuerta: no, al principio (el caso base no la exige, N4 §6.4), porque un umbral no ve si la suite mira lo que dice mirar. Lo que sí lo ve es el rojo provocado.

### P9 — Dónde se compila y firma iOS, y qué queda verificado y qué no

**Alternativas.** (A) Runner `macos-*` hospedado por GitHub. (B) Mac propia como runner autoalojado. (C) Sin compilar iOS, declarado.

| Opción | Dónde cae | Cuánto pesa | Qué pierde | Reversibilidad |
| --- | --- | --- | --- | --- |
| A | En los secretos de firma guardados en GitHub, y en minutos si el repositorio fuera privado | Gratis en repos públicos; USD 0,062/min en privados (doc de facturación, N3 [F15]) | El mandato literal del runner **para ese job** | Reversible |
| B | En hardware a mantener, más el riesgo de un runner propio en un repositorio público (H-04) | Sin medir (no hay Mac) | Simplicidad | Compra irreversible |
| C | En el riesgo mayor del borrador (iOS, §2), que queda sin ver | — | Toda evidencia iOS | Reversible |

**Propuesta: C como estado declarado de la demo**, más A como **job no requerido** para compilar contra el simulador (sin firma) cuando se decida.

- La doc de Microsoft confirma que hace falta una Mac y la versión de Xcode que pide la versión de MAUI («Build an iOS app on macOS with .NET CLI», https://learn.microsoft.com/en-us/dotnet/maui/ios/cli, consultada 2026-10-25). Para un dispositivo exige aprovisionamiento («A device must be provisioned before you can deploy an iOS app to it»).
- Las etiquetas `macos-latest`, `macos-15`, `macos-26` y `xcode-27` existen (doc *Choosing the runner for a job*, consultada 2026-10-25).
- El mandato «runs-on: [self-hosted, i7infra-dev]» se cumple para el workflow de la demo (Android). El pedido no pide compilar iOS. Un job iOS en `macos-*` es un **agregado**: sale marcado a la presidencia para que el PO decida, no lo impone esta comisión.
- **Firma**: dónde viven el certificado y el perfil, y quién los rota, es materia de seguridad (convocatoria S-2).

**Queda verificado**: nada de iOS. El runner pedido no compila iOS (R2:397, medido) y no hay Mac (folio 003:88).

**Queda NO VERIFICADO**:

- Que `dotnet build -f net10.0-ios` contra el simulador corra en `macos-latest` sin pasos extra.
- Qué versión de Xcode exige MAUI 10.0.x: la wiki «Release-Versions» de dotnet/maui no lo dice y remite a https://github.com/dotnet/macios/releases (consultada 2026-10-25).
- El build firmado.
- La interceptación por esquema propio en WKWebView (E01 §8).

Todo eso entra en la guía y en el procedimiento de PR como «iOS: sin compuerta» (H-12). La condición para revisarlo es comprobable: existe una cuenta de Apple Developer asentada en el expediente, o hay un runner macOS medido.

### P11 — Alcance mínimo de la demo, cómo se corre y dónde vive su workflow

En el alcance didáctico (qué etapas) no opino. Es de la comisión de guía y demo: va a la convocatoria S-3. Me toca **dónde vive y cómo corre el workflow**.

**Alternativas.**

| Id | Alternativa | Dónde cae | Cuánto pesa | Qué pierde | Reversibilidad |
| --- | --- | --- | --- | --- | --- |
| W1 | YAML de referencia en `Demo/workflows/` (N5 §6.3) | En el objetivo: no hay compuerta | Medido: GitHub no lo ejecuta (N5 [F27]) | Todo el «impedir» | Reversible |
| W2 | `.github/workflows/framework-concept.yml` en la raíz de `hdcm-dev/Lab-Documentos`, con alcance por paso a `Concepts/Framework-Concept/Demo/**`, y protección de `main` de ese repositorio | En el repositorio de documentos: su `main` pasa a estar protegido para todos los PR (también los de guías) | Un archivo fuera de `Framework-Concept/` que no es documentación (H-01); M-5 muestra que hay permisos de administrador | Un repo mezcla documentos y código con CI | Reversible: se borra el archivo y la regla |
| W3 | Repositorio propio para la demo (`hdcm-dev/Framework-Concept-Demo`, público), con su `.github/workflows/` y la guía apuntando a él | En el pedido: la ruta de entrega `…/Concepts/Framework-Concept/Demo` (evidencia 001:33) dejaría de ser donde vive el código | Crear un repositorio público es una publicación: fase irreversible, va al PO | Literalidad de la ruta pedida | Irreversible frente a terceros que clonen |

**Propuesta: W2.** Es la que menos agrega:

- Mantiene el código en la ruta pedida (evidencia 001:33).
- Mantiene la documentación en `Framework-Concept/` (evidencia 001:37).
- Pone el workflow donde GitHub lo ejecuta, con el runner pedido (evidencia 001:35).

El YAML se **cita** desde la guía; no se copia (si se copia, son dos fuentes; Versionado-Producto-Integral §2.4). Como el agregador y la protección quedan sobre el `main` de Lab-Documentos, el agregador **no se saltea** cuando el PR no toca la demo: responde verde por decisión escrita en el paso, y ese verde no lo da un `skipped` (H-05, H-07).

Cómo se corre localmente: el mismo conjunto de la compuerta en la imagen del runner (`runner-github-dev/dotnet-maui`, M-11). Así, la diferencia entre lo que corre el alumno y lo que corre la CI es vacía y se puede declarar.

W3 queda como alternativa a decidir por el PO, con su costo de publicación.

---

## 4. Lo que revisé y está bien

1. **La medición de N3 sobre el plan y la disponibilidad** se sostiene: repetida hoy, el 404 «Branch not protected» y `admin: true` (M-4, M-5) confirman que en `hdcm-dev` (Free) la protección **se puede** poner en un repositorio público. T-6 y NV-1 de R4 quedan resueltos: el plan la admite; hoy no está puesta.
2. **El caso base pasa 18/18 en la imagen del runner pedido** (SDK 10.0.402, M-11), no sólo en la imagen local de R1. Su técnica de archivos enlazados en `net10.0` sirve para la capa unitaria de la compuerta, a 28 s de pared.
3. **El patrón de agregador único con `always()`** (`ci.yml:161-181`) es el que recomienda la doc oficial para checks requeridos con `needs` (N3 [F8], reconfirmado hoy). Hay que corregirle sólo el tratamiento de `skipped` (H-05).

## 5. Solicitudes de convocatoria (fuera de mi competencia)

| Id | Señal | Ubicación | A quién |
| --- | --- | --- | --- |
| S-1 | `minShellVersion` frente a un rango del puente: cuál es la fuente y cuál se deriva; si el puente es SemVer o un entero | Framework-APP.md:134, :299–302; N3 §4.8; R4 T-1 | Arquitectura del puente y del canal |
| S-2 | Dónde viven y quién custodia la clave de firma del contenido y los certificados de iOS; la compuerta del PR sólo usa una clave **de prueba**, y la firma de release queda fuera del PR | Framework-APP.md:137; N4 §3.6; P9 | Seguridad (firma como control) |
| S-3 | E08 («PR que rompe») tiene que usar un parche que la suite pone en rojo (M-13), no uno que queda verde (M-12); y la guía tiene que enseñar que la fusión deshabilitada depende de la configuración de T1 | N5 §6.4, fila E08 | Didáctica (guía y demo) |
| S-4 | El contenido Blazor .NET 10 no arranca en WebView 83: la versión mínima de WebView es un requisito del cascarón, con su pantalla propia | E01 §6.3, §7 C-3 | Arquitectura del cascarón |

**Obstáculos de una línea a la presidencia.**

- Hace falta un administrador de la org `hdcm-dev` que lea el grupo de runners de `i7infra-runner-dev`, y si admite repositorios públicos (M-7: 403).
- Hace falta una corrida en el runner real que mida el `dotnet publish` de Blazor WASM sin `wasm-tools` dentro de ese contenedor (hoy medido sólo en `lab-e2e-base-dev`).

## 6. Fichas de excepción

Ninguna. No propongo dejar de seguir ninguna de las convenciones que rigen. Las tensiones T-1, T-4, T-6 y T-7 se resuelven **cumpliéndolas**: T-1 con rango y techo (P7), T-4 asignando la clase «paquete» (H-10), T-6 implantando T1 (H-02, H-03) y T-7 declarando la falta de cobertura de iOS (H-12).

Sigue: incorporación del siguiente informe y resolución · presidencia
