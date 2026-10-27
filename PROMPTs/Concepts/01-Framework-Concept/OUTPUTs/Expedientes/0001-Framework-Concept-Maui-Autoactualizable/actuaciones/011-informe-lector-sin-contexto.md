| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-10-25 |
| Autor | Comisión Lector sin contexto (núcleo) |
| Corrige | — |

| Campo | Valor |
| --- | --- |
| Rol | Lector sin contexto (núcleo permanente) |
| Fecha | 2026-10-25 |
| Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas | Cabecera y §0 (líneas 1–111); §2.2; §3.2; §3.3; §3.4; §4; §5.2 |
| Otros documentos cargados | Cadena-De-Consecuencias 2.0 (§2); Escalas-De-Juicio 1.0 (§3.3 y §3.4) |
| No cargados | Excepcion-A-Un-Conocimiento (no propongo dejar de seguir ninguna convención); Mesa |
| Insumos leídos | Pedido (evidencia 001 desde la línea 4); folios 001, 002 y 003; borrador `Framework-APP.md`; bitácoras 00, 01 y 02; R1, R3 y R4 §7; dossier N5; informe E01 (§1, §4, §5, §7, §8); perfil Study-Guide-Documentation. **No leí N1–N4**, como manda la carta |
| Medición propia | Compilé el APK del caso base en un contenedor `fc-lsc-build` (ver §4) |

# Informe del lector sin contexto — expediente 0001

## 1. Lectura del objetivo: lo que da por fijo sin origen

Leí el OBJETIVO del folio 003 (líneas 46–51) contra el pedido, frase por frase, como lo leería alguien que llega sin
contexto. Tres cosas quedan fijas sin una frase del pedido que las respalde, y forman el primer hallazgo (H-01):

| Cláusula del objetivo | Qué dice el pedido | Lo que se agregó |
| --- | --- | --- |
| «ilustrada por una demo … **con su workflow** en [self-hosted, i7infra-dev]» (003:50) | «Configura el wofklow con este runner de github» (evidencia 001:35). No dice de qué es el workflow ni en qué repositorio | Que el workflow es **de la demo**. Hay otras lecturas posibles: el workflow de la compuerta de PR de la línea del producto, o el de verificación de la guía. El ENUNCIADO (003:27) lo clasifica como REQUISITO sin escribir las dos lecturas, como pide §3.1 |
| «procedimientos de PR, integración y versionado que **impidan romper la rama estable**» (003:48-49) | «La necesidad pasa por tener prodicimientos claros en los PR y en los conceptos de integración y versionado» (001:17) | «Impedir» es más fuerte que «procedimientos claros». Y no dice **de qué repositorio** es la rama estable: el del equipo, que el pedido no nombra, el de la demo o Lab-Documentos |
| «dejar decidida, **con fuentes y ensayos**» (003:46) | «Los investigadores especializados **pueden** ensayar» (001:39) | El mismo contrato lo clasifica como DATO, es decir como autorización (003:31-32). El objetivo lo vuelve una obligación |

## 2. Hallazgos

| Id | Nivel | Ancla | Hallazgo | Impacto si no se corrige | Dirección de la corrección |
| --- | --- | --- | --- | --- | --- |
| H-01 | P1 | E2: `003-providencia-contrato-de-entrada.md:46-51` contra `evidencia/001…:17,35,39` (tabla de §1) | El objetivo fija tres cosas sin origen: que el workflow es de la demo, que la rama estable es una rama sin nombrar y que los procedimientos la «impiden» romper, y que hay que ensayar (en el pedido es una autorización) | Cada implementador y cada lector de la guía arma una compuerta distinta, en un repositorio distinto. La demo puede quedar con un workflow que no protege nada que el equipo use | Escribir las dos lecturas de «Configura el workflow» y de «rama estable», tomar la que menos agrega y declararla; marcar «impidan» y «con ensayos» como agregados o devolverlos a la letra del pedido |
| H-02 | P1 | E2: restricción dura «.NET MAUI + Blazor híbrido» (003:73); título del borrador «MAUI + Blazor Hybrid» (`Framework-APP.md:1`) frente a la opción A, «se publican como **Blazor WASM**» (`Framework-APP.md:86`), y E01, que ensayó `Microsoft.AspNetCore.Components.WebAssembly` 10.0.11 en `HybridWebView` (`E01/INFORME.md:101`, `:35`). Fuente externa: Microsoft Learn, *ASP.NET Core Blazor Hybrid*, https://learn.microsoft.com/en-us/aspnet/core/blazor/hybrid/?view=aspnetcore-10.0 (consultada el 2026-10-25, `ms.date` 2025-11-11): «In a Blazor Hybrid app, Razor components run natively on the device … Components don't run in the browser, and WebAssembly isn't involved.» | «Blazor híbrido» tiene dos lecturas: el término de Microsoft (`BlazorWebView`, Razor compilado y ejecutado como .NET nativo) y «app híbrida» en sentido general (contenido web dentro de un cascarón nativo). Con la primera lectura, las páginas de negocio de la opción A **no** son Blazor Hybrid. El contrato las trata como la misma cosa | Con la lectura de Microsoft, elegir la opción A viola una restricción dura (P0). Un principiante que busca «Blazor Hybrid» en la documentación oficial encuentra lo contrario de lo que hace la demo | El contrato escribe las dos lecturas y declara la que toma. La guía define el término con su «qué NO es» y nombra la diferencia entre `BlazorWebView` y Blazor WebAssembly servido en `HybridWebView` |
| H-03 | P1 | E2: «enfocada a un desarrollador sin experiencia» (`evidencia/001…:33`); E1: `grep -n -i 'prerrequisit\|conocimiento previo\|perfil del lector' N5-…md` solo devuelve prerrequisitos **por etapa** (`:363`, `:435-436`) y ninguna definición de qué sabe el lector | Nadie definió qué significa «sin experiencia»: sin experiencia en programación, en C#, en Razor, en MAUI, en git o en Android. N5 calcula la carga intrínseca a partir del «conocimiento previo del lector» (`N5:71`, `:141`), pero ese conocimiento no está escrito | La guía sale con un nivel de entrada distinto según quién la escriba. La carga cognitiva no se puede dosificar, y no se puede elegir un lector novato real para probarla (pregunta 10 de N5) | Declarar el perfil de entrada del lector, con lo que sabe y lo que no, en el contrato o en `Developer-Guide.md` §Cómo usar. Tomar como default la lectura que menos agrega y marcarla |
| H-04 | P1 | E2: MEDIOS del contrato «emulador propio fc-android-emu (API 30)» (003:87); E01: «**No** se cumple en el emulador API 30 con WebView 83» (`E01/INFORME.md:33`) y condición C-3, WebView ≥ 94 (`:243`); N5 propone para Android «se ensaya en el g42 o en emulador» sin esa condición (`N5:319`) | El único medio reproducible que el contrato declara no puede correr la opción A. El teléfono que sí la corre se alcanza por un adb remoto a la PC del PO y por un túnel efímero `trycloudflare.com` (`E01/INFORME.md:104-105`). Un lector de la guía no tiene ninguno de los dos | Un principiante que sigue la guía con un emulador recién creado de una imagen vieja ve la app en blanco. Además, la demo no puede pasar la regla «cada paso produce un resultado» | Que la demo declare un medio de ejecución **medido** que un tercero pueda reproducir: imagen de emulador o WebView mínimo, con la corrida como evidencia. Mientras no esté medido, se rotula NO VERIFICADO en la guía |
| H-05 | P1 | E2: restricciones duras «rutas de entrega (Concepts/Framework-Concept…)» y «runs-on» (003:72-73); E1: `git -C Lab-Documentos ls-files .github` → vacío (el repositorio no tiene workflows); GitHub Docs, *Workflows*, https://docs.github.com/en/actions/concepts/workflows-and-actions/workflows (consultada el 2026-10-25): «Workflows are defined in the `.github/workflows` directory in a repository.»; N5 deja `Demo/workflows/` sin ejecutar (`N5:420`, `:429-431`) | El contrato no resuelve la contradicción entre «toda la documentación en Framework-Concept» y un workflow que tiene que vivir en `.github/workflows` de la raíz para correr. N5 se contradice además: descarta V1 porque `Demo/` no es repositorio propio (`N5:269`, `:271`), pero la etapa E08 exige abrir un PR y ver un check rojo (`N5:450`) | La etapa E08, que es la que muestra el problema del pedido (`evidencia/001…:17`), no la puede ejecutar ningún lector. Y «Configura el workflow» queda cumplido solo en papel | Resolver dónde vive el workflow ejecutable (respuesta a P11) y fijar en qué repositorio y con qué permiso abre su PR el lector de E08 |
| H-06 | P1 | E2: el sujeto «Android e iOS» (003:14-16); MEDIOS «Sin observar: iOS» (003:88); E01 C-6: «En iOS no se pueden interceptar `http/https`, sólo esquemas propios; no se pudo probar» (`E01/INFORME.md:246`); regla del pedido «Toda afirmación debe estar respaldada por evidencia verificable» (`evidencia/001…:64`) | El objetivo promete iOS, y la regla del pedido prohíbe enseñar como cierto lo que no se observó. El contrato no dice cómo trata la guía esa parte (es la pregunta 5 de N5, abierta) | Un lector termina la guía sin saber si lo aprendido sirve para iPhone. Si alguien escribe la parte de iOS «por documentación», viola la regla de evidencia | Declarar en el contrato el alcance verificado por plataforma y la forma en que la guía rotula lo no observado («teoría sin ejecución, NO VERIFICADO») |
| H-07 | P1 | E2: el contexto del pedido manda leer el borrador (`evidencia/001…:15`); el borrador enumera siete capacidades: cámara, red, login con biometría, SQLite, política sin red (`Framework-APP.md:25-33`); el contrato las hace preguntas P4 y P5 (003:57-58) pero el OBJETIVO no las nombra (003:46-51) y dice «Agregados de la presidencia: ninguno» (003:51) | No se sabe si login, cámara, SQLite y outbox son parte del framework que se enseña o hipótesis del borrador. El contrato llama al borrador «insumo e hipótesis a refutar» (003:40-41) y a la vez pregunta por ellas | El alcance de la guía y de la demo diverge entre implementadores: uno escribe cinco familias de temas (N5 `40-Cascaron-y-Puente/`, `:370`) y otro ninguna | Decidir si las capacidades del borrador entran al objetivo, con su origen (la frase del contexto que remite al borrador), o quedan fuera del alcance mínimo, y declararlo |
| H-08 | P2 | E1: `grep -n 'T-[0-9]'` → R4 §7 usa T-1…T-7 (`R4:476-482`; T-3 = migraciones al arrancar) y N5 usa T-1…T-5 con otro significado (`N5:228-232`; T-3 = workflow fuera de la raíz). El contrato cita «Tensiones T-1…T-7 de R4 §7» (003:82) y N5 pregunta «T-3: ¿`Demo/` se publica…?» (`N5:486`) | El mismo identificador nombra dos tensiones distintas en dos insumos de la misma mesa | Un lector, o el jurado, que cruza «T-3» entre folios junta migraciones con workflow | Prefijar las tensiones por documento (por ejemplo R4-T-3 y N5-T-3) o renumerar una de las dos series |
| H-09 | P2 | E2: `02-Cohesion-Global.md:36` «Ninguna registrada todavía» en §3 «Contradicciones abiertas»; `N5:509` registra una «Contradicción candidata para `02-Cohesion-Global.md` §3: T-3»; R3 H-06 deja abierta la de un archivo frente a un conjunto (`R3:365`) | El documento de cohesión que exige el pedido (`evidencia/001…:52`) no recoge las contradicciones que ya señalaron los núcleos | La fase de integración arranca de un mapa que dice que no hay nada que resolver | Volcar en la bitácora 02 las contradicciones candidatas de los núcleos y de los relevamientos antes de la integración |
| H-10 | P2 | E1: `ls Framework-Concept/Cascaron-Aplicacion-Maui.md` → «No existe el fichero»; `head -1 Framework-APP.md` → `# Framework APP …` (no tiene frontmatter); el borrador remite a ese archivo (`Framework-APP.md:4`); N5 propone dejarlo «no se toca; se cita como antecedente» **dentro** de la carpeta de entrega (`N5:357`); el verificador de R3 recorre todo `.md` menos `Demo/` (`R3:292`) | El borrador queda en la carpeta de la guía con un enlace roto, sin frontmatter y con «Estado: borrador», «Recomendación inicial» y decisiones abiertas que la mesa va a cerrar de otra forma | El conjunto falla V-01 y V-11 por un archivo que nadie va a editar, y el principiante encuentra en la carpeta dos textos que se contradicen sin saber cuál manda | Decidir el estatus del borrador: moverlo fuera de la carpeta, envolverlo como antecedente con frontmatter y un aviso de que fue superado, o exceptuarlo por nombre en el verificador |
| H-11 | P2 | E2: R1 manda compilar con `dev.sh build` (`R1:266`); `dev.sh up` apaga el adb de otro contenedor (`.devcontainer/dev.sh:15-18`, `:39-41`) y monta el repositorio con escritura (`:46`); la imagen `lab-e2e-maui-dev:net10` es local y su Dockerfile se presenta como «Entorno de build/depuracion de una app híbrida de referencia de la organización» (`.devcontainer/Dockerfile:2`); el borrador remite a «como se hace hoy con una app híbrida de referencia de la organización en el devcontainer» (`Framework-APP.md:329`) | El camino de compilación del caso base depende de recursos y nombres de otro proyecto que un lector de fuera no tiene. Seguido al pie de la letra, además, le quita el teléfono a otro entorno | Si la demo hereda ese procedimiento, «cómo se corre» no se puede reproducir fuera de i7infra y tiene efectos sobre terceros | Que la demo construya su propio entorno desde un archivo versionado dentro de `Demo/` y no dependa de imágenes locales ni de `dev.sh` |
| H-12 | P2 | E2: `runs-on: [self-hosted, i7infra-dev]` (`evidencia/001…:35`); el runner es de la organización `hdcm-dev` (003:98-99); R3 OB-MD-12 prohíbe rutas del host en los documentos finales (`R3:153`) | La etiqueta `i7infra-dev` es propia del laboratorio. Un lector que copie el workflow a su repositorio deja el job en espera para siempre, sin ningún error que lo explique | La guía enseña un YAML que solo corre en una máquina, y el principiante no sabe por qué no arranca | Que la guía explique la etiqueta como dato del entorno (qué es un runner, quién lo provee, qué reemplazar) y que la demo diga qué pasa sin él |

## 3. Respuestas a las preguntas del caso

### P10. ¿Cómo se estructura la guía: marco de referencia, documentos y recorrido?

**Alternativas consideradas** (las de N5 §5.1, que leí como principiante):

| Opción | Qué es |
| --- | --- |
| O1 | Un solo archivo, `Developer-Guide.md`, con partes y anexos |
| O2 | Conjunto Study-Guide puro, con `Developer-Guide.md` como índice |
| O3 | Conjunto Study-Guide con una familia Tutorial y una Cómo hacer declaradas como variantes, y `Developer-Guide.md` como índice y ruta de lectura |

**Cadena de consecuencias** (Cadena-De-Consecuencias §2):

| Paso | O1 | O2 | O3 |
| --- | --- | --- | --- |
| ¿Dónde cae? | En el lector, que busca su lugar en un archivo largo. También en el pedido: el perfil exige marco en documentos propios y README («Los ejes se definen una sola vez, en documentos propios», `Study-Guide-Documentation.md:33`) | En el principiante, que entra por «Definición» de temas abstractos antes de ver algo funcionar | En quien escribe (es la opción que más escribe) y en el verificador V-03, que tiene que exceptuar las variantes por nombre |
| ¿Cuánto pesa? | Sin medir (no hay borrador de un solo archivo) | Contado sobre la propuesta de árbol de N5 §6.2 (`N5:365-374`): 19 documentos temáticos (3 + 4 + 5 + 4 + 3). Con 7 escenarios, 19 × 7 = 133 subsecciones «Aplicación por escenario». Con 5 escenarios, 95 | Lo mismo que O2, más 10 etapas del tutorial y 6 «cómo hacer» (`N5:364`, `:376-377`) |
| ¿Qué pierde la alternativa? | Pierde el marco de escenarios y el mapa conceptual que exige el perfil | Pierde la entrada segura del principiante: Diátaxis dice que un tutorial no es el lugar para la explicación y que «Every step the learner follows should produce a comprehensible result, however small» (Procida, *Diátaxis — Tutorials*, https://diataxis.fr/tutorials/, consultada el 2026-10-25) | Pierde simplicidad de mantenimiento |
| ¿Es reversible? | Partirlo después cuesta reescribir todo | Agregar después la familia tutorial es barato | Fundir las familias después también es barato |

**Propuesta: O3, con tres condiciones que salen de mis hallazgos.**

1. `Developer-Guide.md` (que es lo que pide el pedido, `evidencia/001…:33`) se puede leer solo: dice para quién es, con el perfil de entrada del lector (H-03); da la ruta «aprender → hacerlo → evaluar»; y declara qué plataformas están verificadas (H-06).
2. El primer documento que lee el principiante es la etapa 0 del tutorial, no un tema.
3. Los términos que hoy aparecen sin definir para un lector nuevo, como «Blazor Hybrid» (H-02), cascarón, contenido, manifiesto, canal, compuerta y runner (H-12), se definen en el glosario con su «qué NO es».

Sobre el número de escenarios, tomo la opción reversible. Arrancar con los cinco que N5 permite (`N5:312-313`) ahorra 38 subsecciones medidas sobre el árbol. Condición para revisarlo: si al escribir un tema la fila fundida pierde el caso de rollback o de promoción, se separa.

### P11. ¿Cuál es el alcance mínimo de la demo, cómo se corre y dónde vive su workflow?

**Alcance mínimo, leído desde el pedido.** El pedido pide tres cosas observables:

1. La actualización al abrir, sin la tienda (`evidencia/001…:21`).
2. Procedimientos de PR, integración y versionado que eviten romper lo que funcionaba (`:17`).
3. Tomar como base `MovilidadUrbana.MAUI` (`:33`).

El mínimo que lo muestra entonces es: arranque con el paquete semilla, una versión nueva tomada al reabrir, un paquete adulterado rechazado y un PR que pone el check en rojo y otro que lo pone en verde, todo sobre las pantallas de Movilidad Urbana. Cámara, login y outbox no tienen frase en el pedido fuera del borrador (H-07). Hasta que el contrato los incorpore con origen, no forman parte del mínimo.

**Cómo se corre.** La guía no puede depender del g42 ni de un túnel (H-04), ni de imágenes locales o de `dev.sh` (H-11). La demo trae su entorno versionado y declara un medio de ejecución medido: emulador con WebView mínimo, o teléfono propio del lector. También incluye una compuerta rápida sin teléfono, con el mismo patrón que hoy pasa 18/18 en el caso base (R1 §12.1). Lo que no esté medido sale NO VERIFICADO.

**Dónde vive el workflow.** Alternativas:

| Opción | Qué es |
| --- | --- |
| W1 | `Demo/` pasa a ser un repositorio propio, con su `.github/workflows/` |
| W2 | El YAML va en `.github/workflows/` de la raíz de Lab-Documentos, filtrado por `paths: Concepts/Framework-Concept/Demo/**` |
| W3 | YAML de referencia en `Demo/workflows/`, sin ejecutar (la propuesta actual de N5, `N5:420`) |

| Paso | W1 | W2 | W3 |
| --- | --- | --- | --- |
| ¿Dónde cae? | Crear un repositorio nuevo en la organización, fuera de la ruta que el pedido nombra | Un archivo fuera de `Concepts/Framework-Concept`. Pero la restricción del pedido dice «Toda la **documentación**» (`evidencia/001…:37`), y un workflow no es documentación: es la lectura que menos agrega | En el pedido («Configura el workflow» sin que corra nunca) y en la etapa E08, que nadie puede ejecutar (H-05) |
| ¿Cuánto pesa? | Sin medir | Un archivo. Medido: hoy Lab-Documentos no tiene ningún workflow (`git ls-files .github` → vacío) | Cero archivos, y la etapa E08 queda perdida |
| ¿Qué pierde la alternativa? | Separa la demo de la guía (los enlaces relativos de la guía a `Demo/` dejan de resolver) | Mezcla en Lab-Documentos un workflow de código | Pierde la única prueba ejecutable del problema que origina el pedido |
| ¿Es reversible? | Caro: un repositorio público ya clonado alcanza a terceros (Cadena-De-Consecuencias §2, paso 4) | Barato: se borra un archivo | Reversible, pero no cumple |

**Propuesta: W2.** Es la reversible y la única que deja correr E08 sin crear nada nuevo. Condición para revisarla: si `Demo/` pasa a repositorio propio, el YAML se muda con ella.

Esta propuesta tiene una consecuencia que no me toca juzgar: Lab-Documentos es **público** (003:101-102), y GitHub recomienda «only use self-hosted runners with private repositories», porque «forks of your public repository can potentially run dangerous code on your self-hosted runner machine» (GitHub Docs, *Adding self-hosted runners*, https://docs.github.com/en/actions/how-tos/manage-runners/self-hosted-runners/add-runners, consultada el 2026-10-25). Va como solicitud de convocatoria (§5, S-1).

## 4. Lo que revisé y está bien

| # | Qué | Evidencia |
| --- | --- | --- |
| 1 | El caso base compila hoy, siguiendo el comando de R1 §11 (sin `dev.sh`, en un contenedor propio y sobre una copia del commit relevado) | `git archive 8fb4c3a` a una copia en el scratchpad; `docker run --name fc-lsc-build --rm -v <copia>:/work lab-e2e-maui-dev:net10 bash -lc 'dotnet build src/MovilidadUrbana.MAUI/MovilidadUrbana.MAUI.csproj -c Debug -f net10.0-android -p:AndroidPackageFormat=apk -p:RuntimeIdentifier=android-arm -p:EmbedAssembliesIntoApk=true'` → «Compilación correcta. 0 Advertencia(s) 0 Errores», 2 min 3 s, `ar.lab.movilidadurbana-Signed.apk`. Avisa «Se encontró un problema al comprobar las cargas de trabajo» sin fallar. Esto cierra el NO VERIFICADO de R1 §17, fila 1 |
| 2 | El pedido literal está conservado con su huella, su canal y la clasificación de cada frase. Desde ahí pude reconstruir el origen de cada cláusula del objetivo | Folio 001 y evidencia 001 |
| 3 | R3 tradujo el perfil en obligaciones comprobables, con verificador ensayado. Un principiante sabe qué tiene que cumplir cada documento | `R3:96-153`, `:263-312` |

## 5. Solicitudes de convocatoria

| # | Señal | Ubicación |
| --- | --- | --- |
| S-1 | Un workflow disparado por `pull_request` en un repositorio público corre en el runner autoalojado del laboratorio. Ya ocurre en Lab-E2E.WebBlazor: `ci.yml` se dispara con `pull_request` (`.github/workflows/ci.yml`, bloque `on:`) y llama a `e2e.yml`, cuyo job `publicar` corre en `[self-hosted, i7infra-dev]` (`e2e.yml:89`). P11/W2 lo repetiría en Lab-Documentos. Corresponde a seguridad de CI | `Lab-E2E.WebBlazor/.github/workflows/ci.yml`, `e2e.yml:89`; folio 003:98-102 |
| S-2 | El borrador nombra un proyecto ajeno, «una app híbrida de referencia de la organización», en un archivo que se va a publicar en un repositorio público | `Framework-APP.md:329`; folio 003:101-102 |

## 6. Fichas de excepción

Ninguna. No propongo dejar de seguir ninguna convención que rige.

Sigue: incorporación del siguiente informe y resolución · presidencia
