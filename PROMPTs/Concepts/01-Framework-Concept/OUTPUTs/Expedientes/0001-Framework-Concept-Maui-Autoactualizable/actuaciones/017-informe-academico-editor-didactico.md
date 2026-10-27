| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-10-25 |
| Autor | Comisión ad hoc Académico editor |
| Corrige | — |

| Campo | Valor |
| --- | --- |
| Rol | Académico editor de material bibliográfico (didáctica y bibliografía). Comisión a ciegas |
| Fecha | 2026-10-25 |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | Cabecera y §0 (l. 1–111); carta (§5.2); §2.2; §3.2; §3.3; §4 |
| Documentos cargados con versión | Cadena-De-Consecuencias 2.0 (cabecera y §2); Escalas-De-Juicio 1.0 (§3.3 y §3.4, por remisión de la carta); Excepcion-A-Un-Conocimiento: **no cargado** (no propongo dejar de seguir ninguna convención) |
| Insumos leídos | evidencia/001 entero; folios 001, 002, 003; R3 entero; N5 entero; R2 §1, §2.2–2.4, §4, §5; E01 §1–§7 y §10; Framework-APP.md §2 (opciones), §10–§14; 02-Cohesion-Global entero; perfil `Study-Guide-Documentation` entero |
| Pregunta única del mandato | ¿Cómo se estructura y se ilustra una guía que un desarrollador sin experiencia pueda seguir hasta correr la demo? |
| Preguntas del caso que respondo | P10, P11 |

## 1) Lectura del objetivo: lo que da por fijo sin origen

El `OBJETIVO` (folio 003, l. 46–51) es fiel al pedido en cada cláusula que cita. Lo que el contrato fija **sin origen
en el pedido**, o deja sin fijar teniendo dos lecturas:

| Qué | Dónde | Por qué es hallazgo |
| --- | --- | --- |
| «FUERA DE ALCANCE: … cambiar Lab-E2E.WebBlazor» | folio 003 l. 84 | El prompt no lo dice (evidencia/001 l. 13–64: sólo «Tomar base … `MovilidadUrbana.MAUI`» y «Toda la documentación generarla en …»). Es un agregado y el contrato declara «Agregados de la presidencia: ninguno» (l. 51). Pesa en mi competencia: la receta del único entorno que compiló el ensayo vive en ese repositorio (`.devcontainer/Dockerfile`, R2 §2.2) |
| «desarrollador sin experiencia» | evidencia/001 l. 33; folio 003 l. 49 | Dos lecturas: sin experiencia **en la técnica** (sabe C# y .NET) o sin experiencia **en general**. El contrato no declara cuál toma. Cambia los prerrequisitos de la guía y el largo de la etapa 0 |
| Dónde «corre» la demo | folio 003 l. 67 («demo que no corre» es P0) | No dice si alcanza con que corra en el laboratorio (i7infra, g42 por adb remoto) o si tiene que correr **en la máquina del lector** siguiendo la guía. Sin eso, el P0 no se puede juzgar |

Va como H-01.

## 2) Hallazgos

| Id | Nivel | Ancla | Hallazgo | Impacto si no se corrige | Dirección de la corrección |
| --- | --- | --- | --- | --- | --- |
| H-01 | P1 | E2: folio 003 l. 84 vs evidencia/001 l. 33–37; folio 003 l. 49 y l. 67 | El contrato agrega «no cambiar Lab-E2E.WebBlazor» sin origen, no declara qué lectura de «sin experiencia» toma ni dónde tiene que correr la demo para que «corre» se cumpla | Quien escribe la guía y quien la juzga leen prerrequisitos y criterio de aceptación distintos (retrabajo); el P0 «demo que no corre» queda sin poder juzgarse | Marcar el agregado como agregado o quitarlo. Declarar la lectura que menos agrega para «sin experiencia» (propongo: sabe C#/.NET básico y git, no conoce MAUI, Blazor WASM, firma ni CI) y fijar como criterio de aceptación de la guía que **la demo corre en la máquina del lector siguiendo sólo la guía**, con el entorno que la guía declara |
| H-02 | P1 | E1, ensayo propio (§3, P11, «Ensayo»): `docker image inspect lab-e2e-maui-dev:net10 --format '{{.RepoDigests}}'` → `[]`; en `mcr.microsoft.com/dotnet/sdk:10.0` limpio, `dotnet workload install maui-android` + `dotnet build -f net10.0-android` → `error XA5300: The Android SDK directory could not be found`; `java: command not found`. Con `-t:InstallAndroidDependencies` (comando de la doc oficial) la corrida no instala el Android SDK (`/opt/android-sdk` vacío) y el build vuelve a dar XA5300 | La demo planificada (N5 l. 401–423) dice «`lab.sh` corre cada etapa en contenedor» (l. 421) y «Entorno reproducible» en E00 (l. 442), pero **no dice con qué imagen ni dónde vive su receta**. La única imagen medida (`lab-e2e-maui-dev:net10`, R2 §2.2; E01 §4) es local: no está en ningún registro y su receta vive en otro repositorio. Por el camino público obvio, un novato no llega a un APK | Un lector que sólo tiene `Framework-Concept/` no puede pasar la etapa 0: la guía deja de ser autocontenida (evidencia/001 l. 45) y la demo «no corre» para su lector | El entorno se versiona **dentro de `Demo/`** (receta de contenedor o devcontainer propia, copiada con su cierre de dependencias, no referida al otro repositorio) y E00 termina en un resultado visible medido desde un clon limpio. La guía no delega el entorno a «instalá el workload» |
| H-03 | P1 | E2: E01 INFORME l. 207–223 («WebView del emulador 83 … `Uncaught SyntaxError` … el emulador de banco del laboratorio (API 30) no sirve») y l. 220; N5 l. 442–443 (E00–E01 sin requisito de dispositivo) | La ruta de etapas no declara el **requisito del dispositivo** (Android System WebView ≥ 94 medido) ni cómo lo comprueba el lector. El único emulador del laboratorio no lo cumple | El novato que sigue la guía con un emulador viejo ve una pantalla «Loading» sin explicación: el tutorial «sale mal», contra la regla de confiabilidad de Diátaxis («so well constructed that things can't go wrong», https://diataxis.fr/tutorials/, consultada 2026-10-25) | Los prerrequisitos de la guía nombran el dispositivo de referencia (versión de Android, versión mínima de WebView) con el comando que la comprueba, y la etapa 1 empieza con esa comprobación. El cascarón muestra su pantalla propia cuando no se cumple (lo decide N1/N2: lo enseña la guía) |
| H-04 | P1 | E2: E01 INFORME l. 105 y l. 323 (el g42 está en otra red; se necesitó un túnel `cloudflared` público) | El tutorial supone que el teléfono alcanza `servidor/` (N5 l. 445, E03), pero el ensayo mostró que con un teléfono real fuera de la red del servidor eso no pasa y hubo que exponer el contenido a Internet | Cada lector resuelve la red a su manera: lecturas divergentes, y un paso del tutorial que depende del entorno del lector; la variante del túnel además expone contenido (ver §5) | El tutorial fija **un solo camino** de red que no dependa de la topología del lector (por ejemplo, servidor alcanzado por el canal de depuración o emulador en la misma máquina; a medir antes de escribirlo) y deja los demás para una guía «cómo hacer». **NO VERIFICADO** cuál camino funciona con el adb remoto del laboratorio |
| H-05 | P1 | E4: evidencia/001 l. 35 (`runs-on: [self-hosted, i7infra-dev]`); E1 del despacho, folio 003 l. 98–102 (runner de la org `hdcm-dev`; Lab-Documentos **público**); E2: N5 l. 450 (E08 «PR que rompe» con check rojo en el runner) | La etapa E08 sólo se puede reproducir con el runner de la organización. Un lector del repositorio público no lo tiene; su fork no lo alcanza | Una etapa del recorrido que el lector no puede ejecutar convierte el tutorial en lectura de capturas justo en el punto que motiva el pedido (romper la rama estable, evidencia/001 l. 17) | La etapa enseña la compuerta con su **equivalente local** (el mismo guion de verificación que corre el workflow, que el lector ve fallar en rojo en su máquina) y presenta el check en GitHub como salida registrada y rotulada. Dónde vive y cómo se protege el workflow es de otra comisión (§5) |
| H-06 | P1 | E2: N5 l. 311–313 (siete escenarios, «cada documento temático recorra todos los escenarios»); R3 l. 125 (OB-TEM-02: «la fila de un escenario que no aplica se conserva y se explica»; cuenta `### ESC-` por tema); R3 l. 143 (OB-MD-02 «Sin secciones vacías ni decorativas») y l. 186 (OB-VOZ-06 «ningún párrafo borrable sin pérdida"). E1: el árbol de N5 §6.2 (l. 365–374) da 19 temas; 19 × 7 = **133** subsecciones de escenario | La forma propuesta obliga a 133 subsecciones, muchas de «no aplica» (p. ej. `ESC-4` puente incompatible en el tema de la plantilla de PR), y a la vez dos obligaciones de R3 prohíben secciones decorativas o borrables | Retrabajo y lecturas divergentes: unos autores escriben relleno para pasar V-03, otros lo omiten y fallan la comprobación. Carga extrínseca para el novato | El perfil exige «qué aporta en cada escenario» (perfil l. 59), no una subsección por escenario: la aplicación por escenario va en **una tabla por tema** (una fila por escenario, «no aplica» en una celda con motivo) y la comprobación cuenta filas, no encabezados. Reducir a cinco escenarios como ofrece N5 (l. 312–313) |
| H-07 | P2 | E2: N5 l. 440–451 (el primer cambio de contenido visible aparece en E03, después del entorno, la app y el puente). Fuente: GitHub Docs, *Tutorial content type*: «Products with tutorials must already have a quickstart»; *Quickstart content type*: «in about five minutes or 600 words» (https://docs.github.com/en/contributing/style-guide-and-content-model/tutorial-content-type y …/quickstart-content-type, consultadas 2026-10-25) | La ruta no tiene **inicio rápido**: el lector no ve la capacidad que motiva todo (la app cambia sin tienda al reabrirla) hasta la tercera etapa | El novato invierte tres etapas sin ver el resultado prometido; Diátaxis pide mostrar desde el comienzo adónde va el aprendiz (N5 l. 85, verificado por su verificador) | Antes de las etapas, un inicio rápido que corre la demo **terminada** y muestra v1 → v2 en el dispositivo; las etapas reconstruyen después lo que el lector ya vio funcionar |
| H-08 | P2 | E1, ensayo propio: en el contenedor limpio `dotnet workload --version` → `10.0.403` y el pack es `Microsoft.Android.Sdk.Linux/36.1.118`; en la imagen del laboratorio, manifiesto `10.0.20/10.0.100` y pack `36.1.69` (R2 l. 36 y §2.2). N5 l. 404: «`global.json` # SDK fijado» | Fijar el SDK no fija el workload: el lector compila con otro pack que el que produjo las capturas | Salidas registradas de la guía que no coinciden con lo que ve el lector (deriva guía↔demo que `lab.sh` no detecta) | Fijar también la versión del conjunto de workloads (`"sdk": { "workloadVersion": … }` en `global.json`, Microsoft Learn, *.NET SDK workload sets*, https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-workload-sets, `ms.date` 2024-08-02, consultada 2026-10-25) y que cada captura lleve en su encabezado SDK, workload y pack |
| H-09 | P2 | E2: R3 l. 102 (OB-EST-01, el índice y su comprobación están en `README.md`) y l. 110 (OB-EST-09, `traces` de `README.md`); N5 l. 354–355 y l. 387 (`Developer-Guide.md` es el índice; `README.md`, portada mínima) | La forma propuesta mueve el índice a `Developer-Guide.md`, pero las comprobaciones de R3 lo buscan en `README.md` | Con una portada de tres líneas, OB-EST-01 y OB-EST-09 fallan, o se «corrigen» engordando la portada y quedan dos índices | Las comprobaciones apuntan al documento que tiene el rol de índice (`doc_id: GUIA-INDICE`), no a un nombre de archivo; `README.md` remite a él y no repite la tabla |
| H-10 | P2 | E2: N5 l. 509 («Contradicción candidata para `02-Cohesion-Global.md` §3: T-3») vs 02-Cohesion-Global l. 36 («Ninguna registrada todavía») | El documento de cohesión que exige la regla del pedido (evidencia/001 l. 52) no registra la contradicción que N5 le derivó | Se pierde la trazabilidad que la regla de descomposición pide para la fase de integración: T-3 decide si la guía puede enseñar un workflow que corre | Registrar T-3 (y T-4, CHANGELOG fuera de la ruta) en §3 de la cohesión con su estado |
| H-11 | P2 | E2: N5 l. 466 («Andamiaje decreciente … [F17] (NO VERIFICADO el método)»), l. 132–133, l. 136–139 (4C/ID y Carroll sólo por registro) | Reglas de diseño de la guía apoyadas en fuentes cuyo contenido no se leyó | Si pasan a la guía, violan «No inventar» y «toda afirmación … evidencia verificable» (evidencia/001 l. 62–64) | La bibliografía de la guía cita sólo lo leído (Diátaxis; la revisión pública del NSW CESE 2017; GitHub y Microsoft Learn); lo demás se lee antes o se rotula como criterio propio |
| H-12 | P3 | E1: `ls /IA/PROMPTs/IA.Prompts/PromptFramework/Profiles/Study-Guide-Documentation.md` existe; la ruta que da el prompt (evidencia/001 l. 71) no. E2: el perfil remite a `/IA/IA.Prompts/PromptFramework/RuleSets/RuleSet-Study-Guide.md` (perfil l. 17), que tampoco existe en esa ruta | Las dos rutas al marco de la guía omiten el segmento `PROMPTs/` | Si la guía o sus `Convenciones.md` las copian, quedan referencias rotas (V-11) | Citar el marco con su ruta real desde la raíz del espacio de trabajo, en código y no como enlace (criterio de R3 H-03) |

## 3) Respuesta a las preguntas del caso

### P10 — ¿Cómo se estructura la guía: marco de referencia, documentos y recorrido?

**Alternativas consideradas** (las de N5 §5.1 más una mía):

| Opción | Qué es |
| --- | --- |
| O1 | Un solo archivo `Developer-Guide.md` (modelo de la guía .NET del repositorio) |
| O2 | Conjunto Study-Guide puro (modelo IS), sin tutorial |
| O3 | Propuesta de N5: Study-Guide + familias Tutorial y Cómo hacer (Diátaxis) como variantes declaradas; 7 escenarios; unos 53 documentos |
| O3-m | O3 recortado: inicio rápido + tutorial por etapas + temas con aplicación por escenario **en tabla** + cómo hacer + anexos; 5 escenarios |

**Cadena de consecuencias (Cadena-De-Consecuencias §2):**

| Opción | ¿Dónde cae el costo? | ¿Cuánto pesa? | ¿Qué pierde? | ¿Reversible? |
| --- | --- | --- | --- | --- |
| O1 | En el lector: un archivo de miles de líneas sin marco de escenarios | Sin medir el largo; el modelo .NET no tiene marco de escenarios (N5 l. 196) | Incumple el perfil (marco en documentos propios, perfil l. 33) | Caro de partir después |
| O2 | En el novato: entra por definiciones, sin una sola línea segura | Sin medir | El tutorial y el resultado visible que piden Diátaxis y los tutoriales OTA relevados (N5 l. 160–162) | Reversible (se agrega un tutorial) |
| O3 | En los autores y el verificador: 133 subsecciones de escenario (H-06), dos índices (H-09) | Medido sobre el árbol de N5: 19 temas × 7 escenarios | Simplicidad pedida (evidencia/001 l. 39) | Reversible, pero se paga en retrabajo |
| O3-m | En `Convenciones.md`: declarar dos variantes y la forma tabular de la aplicación por escenario | 19 tablas de 5 filas en lugar de 133 subsecciones | Algo de prosa por escenario | Reversible: una tabla se despliega en subsecciones si hace falta |

**Propuesta: O3-m.** Estructura, de lo general a lo particular (perfil l. 35):

1. `Developer-Guide.md`: único índice (`GUIA-INDICE`). Lleva resumen, **prerrequisitos medidos** (H-01, H-03),
   «Cómo usar esta guía» con tres entradas (aprender, hacerlo ahora, evaluar) y la ruta de lectura en Mermaid.
   `README.md` sólo remite a él (H-09).
2. `00-Marco-de-Referencia/`: Escenarios (5: primer arranque, actualización incluido el fallo y el rollback, puente
   incompatible, sin red, PR y release), Contextos y Actores tal como los instancia N5 §6.1. El lector se ubica primero
   como `ACT-01`.
3. `01-Mapa-Conceptual/`: «estoy en ESC-x → leo este tema → corro esta etapa».
4. `05-Inicio-Rapido/`: la demo terminada corre y muestra v1 → v2 en el dispositivo (H-07). Es el criterio de
   aceptación de la guía: un desarrollador sin experiencia llega acá **sólo con la guía**.
5. `10-Tutorial/` (variante declarada): etapas con un concepto nuevo cada una, ejemplo trabajado y ejercicio. Esto
   sigue a Diátaxis: «Every step the learner follows should produce a comprehensible result, however small» y «A
   tutorial is not the place for explanation» (https://diataxis.fr/tutorials/, consultada 2026-10-25).
6. `20-`…`60-`: temas del perfil con sus seis apartados más el resumen ejecutivo. La aplicación por escenario va en
   tabla (H-06).
7. `70-Como-Hacer/` (variante declarada): procedimientos para el lector ya competente.
8. `99-Anexos/`: Glosario, Referencias, Plantillas, Lista de verificación, Pendientes, Revisión de consistencia y
   `Mapa-Guia-Demo`.

**Ilustración.** Todo bloque de código sale de la demo con su procedencia (OB-DA-06) y toda salida es «salida
registrada», con SDK, workload y pack en el encabezado (H-08). Diátaxis pide probar el tutorial con usuarios: «The only
way to learn what they are is by finding out what actually happens when users do the tutorial» (misma URL). La guía
se cierra con una corrida desde un clon limpio en contenedor, el mismo ensayo de §3, P11.

**Referencias.** Catálogo por ID con entrada bibliográfica y fecha de consulta (R3 de N5): estable para agentes
(OB-DA-02) y legible para el lector académico. Cada objetivo de etapa se escribe con un verbo observable. El marco que
lo funda es la revisión de Bloom: Anderson, L. W., y Krathwohl, D. R. (eds.) (2001), *A taxonomy for learning,
teaching, and assessing: A revision of Bloom's taxonomy of educational objectives*, Longman, ISBN 0-321-08405-5. El
registro bibliográfico está verificado en catálogos (p. ej. https://eduq.info/xmlui/handle/11515/18824?show=full,
consultado 2026-10-25). **NO VERIFICADO** su contenido: no se leyó el libro, y por eso no se cita ninguna de sus
categorías.

### P11 — ¿Cuál es el alcance mínimo de la demo, cómo se corre y dónde vive su workflow?

**Alcance mínimo**, en lo que toca a la guía. Una app Android, cascarón y contenido, derivada de
`MovilidadUrbana.MAUI`, con lo siguiente:

- un cambio de contenido v1 → v2 visible al reabrir la app;
- un paquete rechazado que deja la versión anterior;
- una llamada al puente;
- un cambio que rompe la compuerta, visto en rojo **en la máquina del lector**.

Son los cuatro hechos que E01 ya midió en el g42 (E01 §6.2), salvo el último. iOS va sólo como teoría rotulada: E01 C-6
no lo pudo probar. Sobre las etapas que dependen de D-01, ver §5.

**Alternativas para «cómo se corre»:**

| Opción | ¿Dónde cae el costo? | ¿Cuánto pesa? | ¿Qué pierde? | ¿Reversible? |
| --- | --- | --- | --- | --- |
| C1. El lector instala SDK, workload, JDK y Android SDK a mano | En el novato | E1: por el camino público no llegó a un APK en tres corridas (H-02) | Confiabilidad del tutorial | Sí |
| C2. Se usa la imagen del laboratorio `lab-e2e-maui-dev:net10` | En el lector, que no la puede obtener | E1: `RepoDigests=[]`; receta en otro repositorio; 6,83 GB | La autocontención (evidencia/001 l. 45) | Sí |
| C3. Receta de contenedor versionada dentro de `Demo/`, con SDK y workload fijados, y un guion único que compila, sirve el contenido e instala | En la demo: una receta más que mantener | Sin medir: la receta de referencia tiene 97 líneas (`wc -l` del Dockerfile de Lab-E2E) | Nada de lo pedido; cuesta tiempo de imagen | Sí |

**Propuesta: C3**, con el criterio de aceptación de H-01: un clon limpio, siguiendo sólo la guía, llega al inicio
rápido. El dispositivo de referencia y su comprobación están en H-03, y el camino de red único en H-04.

**Dónde vive el workflow.** No me corresponde decidirlo (§5). Lo que exige la enseñanza es esto:

- La guía muestra el YAML que de verdad corre.
- La compuerta tiene un equivalente local que el lector ejecuta (H-05).
- La ubicación de GitHub sale de su documentación oficial: «the `.github/workflows` directory in the root of your
  repository» (cita verificada por el verificador de N5, l. 672; para mí, heredada).

**Ensayo** (el que permite la carta). Un contenedor `fc-` limpio desde `mcr.microsoft.com/dotnet/sdk:10.0`
(`sha256:cf3e50b7…956f`), siguiendo los pasos que una guía ingenua propondría:

| Paso | Resultado | Tiempo |
| --- | --- | --- |
| `dotnet new blazorwasm` + `publish` | ✅ 27 141 480 B en `wwwroot`, con el aviso de `wasm-tools` | 61 s |
| `dotnet workload install maui-android` | ✅ workload 10.0.403, pack 36.1.118 | 54 s |
| `dotnet new maui` + `build -f net10.0-android` | ❌ XA5300; sin `java` | 5 s |
| `-t:InstallAndroidDependencies` (doc oficial, https://learn.microsoft.com/en-us/dotnet/android/getting-started/installation/dependencies, `ms.date` 2026-03-06, consultada 2026-10-25) | Sin APK. Segunda corrida, con una variable cambiada (directorios creados antes): instala el JDK, el Android SDK queda vacío y el build repite XA5300 | 57 s y 27 s |

Salidas en `/vm/claude-tmp/claude-1000/-home-fernando-workspaces-workspace-dev/6e043f4a-ac59-44a7-a89a-8b2093f94f90/scratchpad/ensayo-novato/`
(locales; no viajan):

| Archivo | SHA-256 |
| --- | --- |
| `salida.txt` | `e2022566…740ab1` |
| `salida2.txt` | `e24a7a4a…7a348` |
| `salida3.txt` | `66ae9092…1a933` |

Contenedores `--rm`, sin montajes. **NO VERIFICADO** si una tercera variable completaría la instalación del SDK de
Android. No lo perseguí porque la lectura para la guía no cambia: el camino público, sin receta propia, no es «seguro»
para un novato. No es un `BLOQUEO`: no falló un paso prescripto por el pedido.

## 4) Lo que revisé y está bien

1. N5 §6.4–6.5: un concepto nuevo por etapa, código pegado al texto con procedencia y ejercicio tras cada ejemplo
   trabajado. Está apoyado en una fuente pública que se leyó (NSW CESE 2017, citada en la verificación de N5, l. 661–662).
2. R3 §13: la plantilla de documento temático pasa el propio verificador. La copia canónica de `verificar.sh` está en el
   documento (R3 l. 286–314 y l. 520–522).
3. La copia (no referencia) de `Domain/` y `Application/` en la demo respeta la regla del caso base de no compartir
   proyectos (N5 l. 425–426; folio 003 l. 77–78).

## 5) Solicitudes de convocatoria (fuera de mi competencia)

| Señal | Ubicación | A quién |
| --- | --- | --- |
| Runner self-hosted de la org asociado a un repositorio **público**. GitHub Docs: «self-hosted runners should almost never be used for public repositories on GitHub … because any user can open pull requests against the repository and compromise the environment» (https://docs.github.com/en/actions/reference/security/secure-use, consultada 2026-10-25) | folio 003 l. 98–102; evidencia/001 l. 35 | Seguridad / DevOps |
| T-3: el workflow en `Demo/` no lo ejecuta GitHub; la ruta autorizada impide ponerlo en la raíz | N5 l. 230 y l. 429–431 | DevOps / análisis de decisiones |
| Túnel público `cloudflared` como forma de que el teléfono alcance el servidor: no se puede enseñar como paso del tutorial | E01 l. 105 y l. 323 | Seguridad del canal |
| D-01 abierta: las etapas E02–E06 se reescriben si cambia la opción. Mientras no se cierre, no se pueden enseñar | N5 l. 438 y l. 478; Framework-APP.md §13 | Arquitectura |
| iOS no intercepta `http/https` (E01 C-6): `CTX-IOS` no se puede enseñar con ejemplo ejecutado | E01 l. 246 | Arquitectura / iOS |

## 6) Fichas de excepción

Ninguna. No propongo dejar de seguir ninguna convención que rige.

Sigue: incorporación del siguiente informe y resolución · presidencia
