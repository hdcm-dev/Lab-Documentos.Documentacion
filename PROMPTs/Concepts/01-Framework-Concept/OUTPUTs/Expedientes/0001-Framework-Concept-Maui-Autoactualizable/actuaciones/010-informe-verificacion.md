| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-10-25 |
| Autor | Comisión Verificación (núcleo) |
| Corrige | — |

| Campo | Valor |
| --- | --- |
| Rol | Verificación (núcleo permanente). Competencia: criterio de aceptación y medio de prueba de cada decisión; lo declarado sin criterio posible |
| Fecha | 2026-10-25 |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | Líneas 1–111 (cabecera y §0 con el «Mapa de carga»); después, por la fila «comisión»: §2.2, §3.2, §3.3, §4 y §5.2 (la carta) |
| Documentos cargados con versión | Cadena-De-Consecuencias 2.0 (§2) · Escalas-De-Juicio 1.0 (§3.3 y §3.4, remitidas por la carta y por §3.2) · Versionado-Producto-Integral 2.0 (§2.8, §3.4, §5.7: remitidas por el texto de mis hallazgos) · Release-Y-Despliegue-Versionado 2.0 (§2.2, invariantes 10 y 13) · Versionado-Paquetes-NuGet 2.0 (§2.7, líneas 220–226). **No cargado:** Excepcion-A-Un-Conocimiento (no propongo dejar de seguir ninguna convención); Rule-Mesa (ninguna remisión del texto de mi acto la exige) |
| Medios propios de esta corrida | API pública y autenticada de sólo lectura de GitHub; `docker exec` de sólo lectura sobre `runner-github-dev`; reproducción de E01 en el moto g42 (`com.frameworkconcept.ensayo01`, un arranque, sin instalar ni tocar otra cosa); lectura de fuentes oficiales (WebFetch, consultadas el 2026-10-25) |

# Informe de Verificación — expediente 0001

## 1) Lectura del objetivo: lo que da por fijo sin origen

El `OBJETIVO` del folio 003 (líneas 117–122) lleva origen en cada cláusula, pero hay tres cosas que da por fijas sin
el origen correcto o sin criterio que permita comprobarlas:

1. **«dejar decidida, con fuentes y ensayos, una arquitectura … para apps .NET MAUI»**, con sujeto «Android e iOS»
   tomado de `Framework-APP.md §1` (folio 003, líneas 86–87). El borrador es, por el mismo contrato, «insumo e
   hipótesis a refutar, no el objeto» (líneas 111–112). iOS sí tiene origen en el pedido (evidencia 001, línea 21:
   «app connect de apple»), pero el contrato cita la fuente equivocada. Además, `MEDIOS` declara «Sin observar: iOS»
   (línea 159). **Para la mitad iOS, «decidida con ensayos» no tiene un criterio que se pueda cumplir.** Es H-01.
2. **«procedimientos … que impidan romper la rama estable»**: el pedido pide «procedimientos claros» (evidencia 001,
   línea 17). «Impedir» viene de `Versionado-Producto-Integral` §3.3/§3.4 («aviso no es impedimento»). Es una
   convención que rige (E4), así que la cláusula se sostiene, pero el objetivo la atribuye a «[prompt, Contexto]» y
   declara «Agregados de la presidencia: ninguno». Lo corrijo dentro de H-01 (P3).
3. **La fase del producto no figura en ningún campo.** Según `Versionado-Producto-Integral` §2.8, «una fase sin
   declarar se lee `operativa`». El objetivo arrastra así, en silencio, las obligaciones de la fase más exigente.
   Es H-02.

## 2) Hallazgos

| Id | Nivel | Ancla | Hallazgo | Impacto si no se corrige | Dirección de la corrección |
| --- | --- | --- | --- | --- | --- |
| H-01 | **P1** | **E2** folio 003 l.86-87 («Sujeto: … Android e iOS (Framework-APP.md §1)»), l.117 («decidida, con fuentes y ensayos»), l.159 («Sin observar: iOS»); evidencia 001 l.21 | El objetivo exige decidir «con ensayos» un sujeto con dos plataformas, y el contrato declara que una de ellas no tiene medio de observación. Además, el origen del sujeto iOS se atribuye al borrador no vinculante y no al pedido. No hay ningún criterio que diga cuándo la parte iOS queda «decidida» | Cada comisión y quien aplica va a leer de forma distinta qué vale como cierre de P1, P2, P3 y P9 en iOS: «decidido por fuente», «diferido» o «pendiente». La guía puede presentar como decidido algo que nadie ensayó | Reescribir la cláusula con dos regímenes declarados. **Android**: decidido con fuente y ensayo. **iOS**: decidido por fuente, marcado NO VERIFICADO, con el ensayo diferido atado a un evento de cierre comprobable (Cadena-De-Consecuencias §2, paso 4: «la condición para revisarla es un hecho que se puede comprobar»; por ejemplo, «primer job verde en `macos-*` con firma»). Citar el pedido (l.21) como origen de iOS. Anotar que «impidan» viene de VPI §3.3 (E4) |
| H-02 | **P1** | **E4** `Versionado-Producto-Integral` §2.8: «Una fase sin declarar se lee **`operativa`**»; §3.4: «Los tramos se exigen desde la fase en que rigen sus reglas». **E2**: el folio 003 no tiene la clave `fase` (l.81-176) | Sin fase declarada, la demo hereda roll-forward, expandir/contraer, respaldo antes de migrar y los tramos T0–T5 completos. N3 lo dejó como pregunta 10, todavía abierta | Lecturas divergentes del alcance de P5 (migraciones) y de P7 (gramática y pre-release). Retrabajo si la mesa diseña para `diseño` y la convención exige `operativa` | La presidencia declara la fase en el contrato, con su origen (pedido o decisión del PO) y el sufijo de pre-release que la marca (§2.8). La lectura que menos agrega es `diseño`, porque el pedido no menciona datos reales que alguien reclame; si es así, se dice |
| H-03 | **P1** | **E4** `Versionado-Producto-Integral` §5.7: «Un paso que no pudo correr **no deja verde**»; `Release-Y-Despliegue-Versionado` §2.2 inv. 13. **E2** `Lab-E2E.WebBlazor/.github/workflows/ci.yml:178` (`success\|skipped) ;;`), patrón que N3 §6.2 y N4 §5.1 punto 7 proponen copiar como `ci-ok`/`fw-ok` | El agregador del caso base pinta verde los jobs salteados. N3 §6.3 enruta además los PR de forks con un job condicionado, que queda `skipped` en la otra rama. Copiado así, la compuerta contradice una convención que rige | Un job que no corrió (secreto faltante, condición mal escrita) deja la fusión habilitada, que es el defecto que el pedido describe (evidencia 001, l.17) | El agregador trata `skipped` como rojo, salvo los jobs que figuren en una lista declarada de omisiones legítimas. El ruteo fork/propio se hace eligiendo el runner del **mismo** job (expresión en `runs-on`), no salteando jobs. **Criterio de aceptación:** un PR de ensayo con un job forzado a `skipped` deja el check requerido en rojo (rojo provocado de VPI §3.4) |
| H-04 | **P1** | **E1** `curl …/repos/hdcm-dev/Lab-E2E.WebBlazor/actions/runs/40176198598/jobs` → `Publicar la aplicación  success  i7infra-runner-dev  self-hosted,i7infra-dev` (repo público). `docker exec runner-github-dev cat /actions-runner/.runner` → `"poolName": "Default"`, `ephemeral: true`; `id -un` → `root`. API autenticada de `hdcm-dev/Lab-Documentos`: `fork-pr-contributor-approval` → `first_time_contributors`; `branches/main/protection` → `404 Branch not protected`. **E4** GitHub, *Secure use reference*: «self-hosted runners should almost never be used for public repositories on GitHub» (https://docs.github.com/en/actions/reference/security/secure-use, consultada el 2026-10-25) | N3 §4.5 y §10.4 dejaron NO VERIFICADO si el grupo del runner admite repos públicos. **Lo admite**: el grupo `Default` ya ejecuta jobs de un repo público de la org. El riesgo que N3 deja «condicionado» es **actual**, y el repo destino de la demo (público) tiene la aprobación de forks que la documentación califica de débil | Si el workflow de la demo corre `pull_request` en `[self-hosted, i7infra-dev]` sin guarda, el código de un fork aprobado una vez se ejecuta como root en el contenedor del runner de i7infra. Atenuante medido: desde ese contenedor el adb del PO no responde (`</dev/tcp/203.0.113.30/5037` → «no alcanzable»), y R2 §5 midió que no hay socket de Docker ni `/dev/kvm` | Separar en el plan de N3 la **dirección** (eso decide la mesa) del **criterio de aceptación**, que pido declarar así: (a) un PR desde un fork de ensayo no tiene ningún job con `runner_name = i7infra-runner-dev` (medio: API `actions/runs/{id}/jobs`); (b) `approval_policy` medida igual a la adoptada; (c) el grupo del runner acotado a repos nombrados, medido por un admin de la org (este rol no tiene permiso: «You must be an org admin», N3 [C4]) |
| H-05 | **P1** | **E2** `Ensayos/E01-…/src/Cascaron/E01/Actualizador.cs:83-85` (`Directory.Delete(DirPrevious…)`; `Directory.Move(DirCurrent, DirPrevious)`; `Directory.Move(destinoStaging, DirCurrent)`) frente a `Framework-APP.md:123` y `:138` («cambio atómico de puntero») | La activación que el informe E01 da como funcionando son tres operaciones: un corte entre la segunda y la tercera deja el arranque sin `current`. Además, la anterior se borra antes de tener la nueva, así que la retención real es 1 (`previous`) contra N ≥ 3 de `Release-Y-Despliegue-Versionado` inv. 10 (tensión T-2 de R4). El caso «corte durante la activación» de N4 §3.6 no dice cómo se provoca | La guía va a enseñar como «atómico» un código que no lo es. Una actualización interrumpida en el teléfono puede dejar al usuario en la semilla o sin contenido. Nadie lo ve fallar, porque la prueba no tiene medio | Declarar para la activación un **criterio con medio**: inyección de fallo determinista entre cada paso (un punto de corte configurable en el actualizador `net10.0`), y la aserción «al reiniciar, `current` resuelve a una versión completa y verificada». Debe verse **en rojo** contra el código de E01 antes de darse por cumplido (Mesa-De-Expertos-A-Pedido §3.3, «Una prueba que no se vio fallar no cierra»). La retención en el teléfono se decide contra inv. 10 con medida, no por defecto |
| H-06 | **P1** | **E2** `Framework-APP.md:139` («en X segundos») y `:141` («no trabar el arranque más de N segundos»); `Actualizador.cs:33` (`Timeout = TimeSpan.FromSeconds(30)`). **E1** (esta corrida, g42, servidor de E01 ya dado de baja): `t=1069ms manifiesto: GET …` → `t=2170ms … (530) se usa lo instalado` → `t=4832ms 'primer-render v2'`; 43 interceptadas, 5 sin manejar, 0 `Uncaught`. Logcat `sha256 4da5ad1a…0a8e`, captura `sha256 7b85c109…a8e`, en `~/fc-work/verificacion/` | X y N están declarados sin valor: no hay criterio posible. Medí que el manifiesto está en el camino crítico: con un servidor que **responde** error, el render espera 1,1 s. Con un servidor que **no responde**, el código del ensayo esperaría hasta 30 s (inferencia del timeout leído: el caso «sin respuesta» y el modo avión siguen NO VERIFICADOS) | P2 y la guía quedan con una política de espera imposible de comprobar. La demo puede trabar el arranque hasta 30 s en redes malas (Red-Movil-Problematica 2.0 rige) | Fijar N y X como números, con la métrica nombrada (ms desde el inicio del proceso), y dos ensayos de una variable en el g42: servidor que acepta y no contesta, y modo avión (este segundo pide permiso del PO porque toca un ajuste del teléfono). Aceptación: primer render ≤ N + render medido, con el contenido instalado |
| H-07 | **P1** | **E2** INFORME E01 §6.2 corrida 4 («manifiesto con sha256 adulterado») y §7 C-5 («firma … no ensayados»). **E4** TUF Specification 1.0.37 §4.3: «Clients MUST NOT trust an expired file» y «MUST NOT replace a metadata file with a version number less than the one currently trusted» (https://theupdateframework.github.io/specification/latest/, consultada el 2026-10-25) | La única prueba de rechazo hecha cambia el hash **del manifiesto no firmado**. Prueba la comparación, no la amenaza: quien controla el servidor cambia hash y paquete a la vez. P2 no tiene todavía ningún rojo visto contra los ataques que N1 §4.9 usa para justificar el diseño | Si P2 se da por decidido con esta evidencia, la guía enseña «firma + hash» como protegido sin que ningún caso haya fallado. Ed25519 no está en .NET 10 (N1 §4.9, #63174), así que el algoritmo sigue abierto y la prueba no se puede escribir | Que P2 se declare decidido sólo con estos **cuatro rojos vistos** sobre el actualizador `net10.0` y el paquete producido por la herramienta real: manifiesto firmado con otra clave; versión menor firmada válida (anti-rollback); `expires` vencido (anti-freeze); archivo alterado después de firmar. Algoritmo y formato de firma fijados antes de escribirlos |
| H-08 | **P1** | **E1** `docker exec runner-github-dev … </dev/tcp/203.0.113.30/5037` → «adb-remoto: no alcanzable»; R2 §5 (medido): «sin `/dev/kvm`», «daemon inaccesible». **E2** N4 §5.2 («Nocturna: … Appium en emulador»; «Al etiquetar: Appium en un teléfono Android real») | Ninguna de las capas de dispositivo de N4 (emulador nocturno, teléfono al etiquetar, actualización punta a punta en `beta`) puede correr en el único runner que el pedido nombra. N4 no dice dónde corren ni quién las corre | La pirámide de P8 queda con escalones superiores que nadie ejecuta: «diseñado, no implantado» (VPI §3.4 T5). La guía va a prometer una nocturna que no existe | P8 declara, por suite: dónde corre (runner y evento), quién la dispara y qué evidencia deja. El escalón de dispositivo se declara **manual, con captura y logcat versionados** (forma de E01), o se pide un cambio de entorno (decisión de N3/N4, no mía). Lo que no corre antes de fusionar se declara así, como manda Versionado-Paquetes-NuGet §2.7 para un marco que no compila en el runner |
| H-09 | **P0** | **E1** `ls -la Lab-Documentos/Lab-Documentos/` → no hay `.github` (`ls: no se puede acceder a '.github'`); `git status` → `?? Concepts/`. **E2** N5 §6.3: `workflows/  # YAML de referencia … (ver T-3)` y «la carpeta se llama `workflows/` y no `.github/workflows/` a propósito, porque ahí GitHub no la ejecutaría». **E4** restricción dura del folio 003 l.143-145 (`runs-on: [self-hosted, i7infra-dev]`) y evidencia 001 l.35 («Configura el wofklow») | El plan de N5 para la demo deja el workflow en una carpeta que GitHub no ejecuta. Un YAML que nunca corre no es un workflow configurado, y no hay compuerta que impida nada (P6) | Con el plan tal como está, la solicitud «Configura el workflow» no se cumple y P6 no tiene objeto donde verificarse | Que la mesa resuelva dónde vive el workflow (raíz de Lab-Documentos o repo propio de la demo: decisión de N3/N5) y que el criterio de aceptación de P11 sea **una corrida real** del workflow, con su `run_id`, sus jobs en `i7infra-runner-dev` (API `actions/runs/{id}/jobs`) y el rojo provocado de la etapa E08. Si va en la raíz de un repo de guías, ningún check requerido puede estar detrás de un filtro `paths` (N3 §4.2: queda «Pending» y bloquea), así que el filtrado va dentro del job |
| H-10 | **P1** | **E2** N1 §6, condición de corte (b): «el primer arranque en el g42 es **inaceptable para la mesa**»; E01 §6.2: proceso → primer render 4 366–6 277 ms; esta corrida, 4 832 ms. **Fuente**: Android vitals considera excesivo un «Cold startup [that] takes 5 seconds or longer» y mide con TTID (https://developer.android.com/google/play/vitals/launch-time, consultada el 2026-10-25); TTFD «is the time it takes for an app to become interactive» y se reporta con `reportFullyDrawn` (https://developer.android.com/topic/performance/vitals/launch-time, misma fecha) | La condición que decide entre A, A′ y B (P1) depende de un juicio sin umbral. La cifra relevante no es la que mide Vitals: el TTID del ensayo es 943–1 686 ms (`am start` TotalTime) y está bien, pero el contenido usable llega a 4,4–6,3 s, que es un TTFD. No hay un umbral público de TTFD | D-01 se puede «decidir» en cualquier sentido con los mismos números. La mitad de las corridas de E01 superan los 5 s si alguien les aplica (mal) el umbral de TTID | Declarar la métrica (TTFD con `reportFullyDrawn` en el primer render del contenido), el dispositivo de referencia y un umbral numérico decidido por la mesa con su motivo. Agregar al plan la medición con `InvariantGlobalization`, que N1 §10 dejó en BLOQUEO y R2 §2.4 midió sólo en tamaño |
| H-11 | **P2** | **E2** folio 003 l.148-149: «Restricciones del caso base en su ia-db: las tres apps … no comparten proyectos; convención "arquitectura en inglés, dominio en español"» bajo `DECISIONES CERRADAS` | Son reglas de Lab-E2E.WebBlazor para sus tres apps. La demo vive en otro repositorio y el pedido sólo dice «Tomar base … MovilidadUrbana.MAUI» (evidencia 001, l.33). Se tratan como fijas sin una frase del PO que las extienda (§3.3, «Comportamiento no es restricción»). La de no compartir proyectos choca con la estructura de N5 §6.3 (`Framework.*` compartidos por cascarón y contenido) | La mesa puede descartar la estructura de bibliotecas compartidas del framework por una regla que no la alcanza, o al revés, y nadie puede citar por qué | Tratarlas como precedente del caso base (dato), o anclarlas en una frase del PO o en una regla que mande eso **para la demo**, con E2. La convención de nombres puede tener otra fuente válida: si existe, se cita esa |

Total: 11 hallazgos. **P0: 1** (H-09) · **P1: 9** · **P2: 1**.

## 3) Respuesta a cada pregunta del caso (foco P2, P8, P9)

Doy, por pregunta, el **criterio de aceptación** y el **medio de prueba** con el que la mesa puede darla por
respondida. La opción no la elijo yo: eso es de las comisiones de dominio y del jurado. Antes de recomendar entre
formas de verificar corrí Cadena-De-Consecuencias §2.

### P2 (foco) — canal de actualización

| Alternativa de verificación | Dónde cae el costo | Cuánto pesa | Qué pierde | Reversible |
| --- | --- | --- | --- | --- |
| V-a. Dar P2 por decidido con E01 + fuentes | En el usuario y en la guía: firma y anti-rollback sin ningún rojo visto | Sin medir: no hay prueba | Se ahorra escribir el actualizador `net10.0` ahora | No: lo que la guía enseña alcanza a terceros (Cadena §2.4, «alcanza a terceros») |
| V-b. Suite del actualizador `net10.0` con los diez casos de N4 §3.6 + los cuatro de H-07, cada uno visto en rojo | En CI: segundos (N4 §3.9, «milisegundos vs segundos») | Medido por analogía: la suite de ViewModels del caso base corre 18/18 en 3 s (N5 §4.7, R1) | Obliga a abstraer FS/HTTP/reloj (N4 §5.3) | Sí |
| V-c. V-b + la corrida E01 extendida en el g42 (servidor mudo, versión menor firmada) | Una sesión con el teléfono (~10 min por corrida en E01 §10) | Medido: 5 corridas en E01 | Hace falta el teléfono del PO | Sí |

**Propuesta:** V-b como condición para cerrar P2 y V-c como prueba de implantación de la guía (etapas E04/E05 de
N5). Criterios: H-05, H-06 y H-07. Fuentes: TUF Specification 1.0.37 (URL arriba); Expo Updates v1 (N1 [F8],
`runtimeVersion`, `rollBackToEmbedded`). Retención: medida contra `Release-Y-Despliegue-Versionado` inv. 10;
si no se cumple N ≥ 3, la vía es una ficha por contradicción medida, no el silencio (T-2 de R4).

### P8 (foco) — qué se prueba en cada capa y qué es compuerta

| Alternativa | Dónde cae | Cuánto pesa | Qué pierde | Reversible |
| --- | --- | --- | --- | --- |
| O2 de N4 (sin dispositivo en el PR) con el agregador del caso base | En la rama estable: los `skipped` pasan (H-03) | E2 `ci.yml:178` | Nada en tiempo | Sí, pero el defecto llega a `main` |
| O2 con agregador estricto + rojo provocado por suite | En el autor del PR: un rojo más visible | Sin medir el tiempo total de la compuerta; dato del caso base: `compilacion` con tope de 15 min (N4 §6.5) | Comodidad ante jobs opcionales | Sí |
| O3 (emulador en el PR) | En el runner | **Imposible hoy en `i7infra-dev`**: sin KVM (R2 §5, medido) | Obligaría a otro runner, contra la restricción dura | — |

**Propuesta:** O2 con agregador estricto. Criterio de aceptación de cada suite de la compuerta: (1) su rojo provocado
documentado, a la manera de VPI §3.4 («el mecanismo detecta»), y (2) su presencia en el agregador, comprobada por
ausencia, como manda VPI §5.7 («el conjunto de lo que hay es igual al conjunto de lo que se invoca»). Criterio de la
compuerta entera: captura del botón de fusionar deshabilitado con E08 en rojo (VPI §3.4 T1). Ese paso necesita un
admin de `hdcm-dev` para configurar la protección: lo declaro como prerrequisito, no como algo que la presidencia
pueda hacer sola. El escalón de dispositivo es manual y con evidencia (H-08). La única norma de proceso que cito es
ISO/IEC/IEEE 29119 (*Software and systems engineering — Software testing*), sin apartado. La pirámide es la de
Vocke, «The Practical Test Pyramid», martinfowler.com, 2018-02-26 (N4 [1], verificada en ese dossier).

### P9 (foco) — dónde se compila y firma iOS; qué queda verificado

| Alternativa | Dónde cae | Cuánto pesa | Qué pierde | Reversible |
| --- | --- | --- | --- | --- |
| Afirmar en la guía el camino iOS como decidido | En el lector: un camino nunca corrido | Sin medir | — | No (alcanza a lectores) |
| Workflow iOS escrito en `macos-*` y **no ejecutado**, declarado así | En el plan: deuda declarada | `macos-latest` es gratis en repo público (N3 [F15]); sin cuenta Apple Developer no hay firma (N3 §10.4) | Ninguna evidencia de iOS | Sí |
| Ensayo del contenido en iOS por esquema propio | En una Mac que no existe | Imposible hoy (folio 003 l.159) | — | — |

**Respuesta de Verificación:** queda **NO VERIFICADO** todo iOS: la intercepción, que según la documentación de
`HybridWebView` sólo admite esquemas propios en iOS (E01 [D1]); el trato de Apple a `.wasm` (N1 §10); el desbloqueo
con Keychain; la compilación y la firma. El origen fijo `https://0.0.0.1` medido en Android no se puede trasladar a
iOS (E01 §8). Criterio de cierre propuesto, como evento comprobable: un `run_id` de un job `macos-*` verde que
produzca el `.ipa` firmado, y una corrida en dispositivo con captura equivalente a la corrida 3 de E01. Hasta
entonces la guía marca iOS como «diseñado, no verificado» (H-01). Fuente: Microsoft, *Publish a .NET MAUI app for
iOS using the command line* (https://learn.microsoft.com/en-us/dotnet/maui/ios/deployment/publish-cli, citada y
verificada en N3 [F27] el 2026-10-25): compilar iOS requiere una Mac.

### P1, P3–P7, P10, P11 — criterio de aceptación por pregunta

| Pregunta | Criterio de aceptación | Medio de prueba | Estado de la evidencia hoy |
| --- | --- | --- | --- |
| P1 (D-01) | Umbral de TTFD numérico y declarado, alcanzado en el dispositivo de referencia, y WebView mínimo comprobado con su pantalla de «actualizá el WebView» | `reportFullyDrawn` + logcat (forma de E01); emulador API 30 con WebView 83 como rojo conocido (E01 §6.3) | Android: medido y viable con condiciones (E01; reproducido en esta corrida). Umbral: ausente (H-10). iOS: NO VERIFICADO |
| P3 | Contrato del puente fijado por prueba de consumidor y de proveedor, más compatibilidad con N-1; regla de versión con piso **y techo** (VPI §2.6, T-1 de R4) | Suite de contrato `net10.0`; rojo provocado: quitar el techo del rango (VPI §3.4 T3) | Diseño en N2/N3; sin ensayo de PactNet (N4 §9.4) |
| P4 | Primer ingreso OIDC y desbloqueo con la seguridad del teléfono, ensayados en el g42 | Ensayos E-N2-1 y E-N2-3 | No ejecutados (N2 §10). E-N2-2 no se puede hacer en el g42 sin tocar sus ajustes |
| P5 | Encolable sin red pasa a enviada, sin duplicados (idempotencia) | Prueba de integración del outbox; etapa E07 | Sin ensayo. El régimen de migraciones depende de la fase (H-02, T-3 de R4) |
| P6 | Botón de fusionar deshabilitado ante rojo provocado; ningún job de fork en `i7infra-dev` | Captura versionada (VPI §3.4 T1); API `jobs` (H-04) | Hoy: `main` sin proteger en Lab-Documentos (E1). Configurarlo requiere admin |
| P7 | Una línea por pieza con un acto que la incrementa; versión visible del cascarón numérica de tres enteros (N3 §4.7, [F21b]) | Compuerta de identidad sobre el artefacto (VPI §4, «sobre el artefacto producido») | Diseño en N3; depende de la fase (H-02) |
| P10 | Cada etapa con salida esperada y captura; mapa guía↔demo comprobado por guion | `lab.sh` y las aserciones de N5 §6.4 | Plan en N5; nada construido |
| P11 | La demo corre desde cero en contenedor y su workflow tiene al menos una corrida real en `i7infra-runner-dev` | `run_id` + API `jobs` + capturas de E00–E09 | Bloqueado por la ubicación del workflow (H-09) |

## 4) Lo que revisé y está bien

1. **La evidencia de E01 es íntegra y su medio puede dar rojo.** Los sha256 de los dos APK, de los dos zip y de la
   captura de la corrida 3 coinciden con la tabla §9.2 del INFORME (`sha256sum` en `evidencia/local/`). El filtro de
   logcat de `correr-ensayo.sh:39` captura `chromium|Console`, y en el emulador sí registró
   `Uncaught SyntaxError` (`logcat-emu-*.txt`). El «cero Uncaught» del g42 es, por lo tanto, una medición, no la
   ausencia de un medio.
2. **E01 es reproducible y se extiende con una variable.** Esta corrida relanzó la app instalada con el servidor
   dado de baja: usó lo instalado (v2), hubo primer render y puente, 43 respuestas servidas y 0 errores. Esto cierra
   como medido el ítem de E01 §8 «arranque del contenido sin red» **en su variante «servidor que responde error»**.
   La variante modo avión sigue NO VERIFICADA.
3. **El hecho de plataforma de N3 está bien medido.** Lab-Documentos es público y `main` está sin proteger (404
   «Branch not protected», reconfirmado con la API autenticada), así que la protección de rama está disponible en el
   plan Free de la org. El P6 que pide «impedir» es alcanzable en ese repositorio.

## 5) Solicitudes de convocatoria (fuera de mi competencia)

| Señal | Ubicación | Para quién |
| --- | --- | --- |
| Dónde vive el workflow de la demo: raíz de Lab-Documentos (repo de guías, con filtros de ruta) o repo propio | N5 §4.8 T-3 y §6.3; H-09 | N3 / N5 (arquitectura del repositorio) |
| Ruteo de jobs fork/propio con el mandato `runs-on: [self-hosted, i7infra-dev]` en un repo público | N3 §6.3; H-04 | N3 (seguridad de CI) |
| Atomicidad y retención de la activación en el teléfono | `Actualizador.cs:83-85`; T-2 de R4 | N1 |
| Configurar la protección de rama y el grupo del runner necesita un admin de `hdcm-dev`; `QUIÉN APLICA` (folio 003, l.163) no lo tiene | folio 003 l.163; N3 [C4] | Presidencia (lote al PO: es un acto sobre un repositorio compartido con las guías) |

## 6) Fichas de excepción

Ninguna. No propongo dejar de seguir ninguna convención: H-03 y H-05 piden **cumplir** VPI §5.7 y
Release-Y-Despliegue-Versionado inv. 10 y 13.

### Evidencia cruda de esta corrida (local, no versionada)

| Pieza | Ruta | sha256 |
| --- | --- | --- |
| Logcat del relanzamiento con el servidor caído | `~/fc-work/verificacion/logcat-g42-6-servidor-caido.txt` | `4da5ad1a583546e110d624b61c5f48fc116e2a2140124259bbe9ec363e950a8e` |
| Captura del mismo arranque | `~/fc-work/verificacion/captura-g42-6-servidor-caido.png` | `7b85c10925d5b7be26030d101f2a180bb240f0414a6e4b8acbe370cb06ea60c1` |

Comando: un `docker run --rm --name fc-verif-adb … lab-e2e-maui-dev:net10` con `adb -H 203.0.113.30 -P 5037 -s
<serie-del-g42>`, que hizo `am force-stop`, `logcat -c`, `am start -W` (COLD, TotalTime 1543 ms), esperó 35 s y guardó
logcat y `screencap`. Sólo se tocó `com.frameworkconcept.ensayo01`, y quedó detenido al terminar.

Sigue: incorporación del siguiente informe y resolución · presidencia
