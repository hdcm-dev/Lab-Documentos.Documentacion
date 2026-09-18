# Mesa evaluadora — Ciclo 2 — Informe 07: Abogado del diablo

**Fecha:** 2026-09-18
**Rol:** Abogado del diablo (núcleo permanente, §4.1.1 del marco)
**Mandato:** atacar el documento final v2.0.0. ¿Sigue induciendo sobreingeniería? ¿Los rótulos «Criterio de esta guía» están fundados o son dogma disfrazado? ¿Se colaron afirmaciones sin evidencia? ¿§9 sirve a quien diseña desde cero? Revisar HC-25/HC-26/HC-27 archivados en el ciclo 1.
**Trabajo a ciegas:** no leí los otros informes de `Ciclo-2/`.
**Material leído:** guía v2.0.0 (1308 líneas), `Dot-NET-Arquitectura-Lab/` (lab.sh, `aserciones.log`, capturas L00–L24, `MyProject/`), Bitácoras 00/01/02/04, veredicto del ciclo 1 (§2 HC-25..27, §3, §4 DA-1..4, §7 DR-01..30), prompt 03, marco §3 y §4.1.4, mi informe del ciclo 1.

**Verificaciones propias (2026-09-18):**

| Id | Qué | Resultado |
|---|---|---|
| V1 | `grep -rn Application MyProject/src/Backend/MyProject.Infrastructure --include=*.cs` | Sin resultados: ningún `.cs` de Infrastructure usa un tipo de Application; solo existe la `<ProjectReference>` en el `.csproj` |
| V2 | `grep -rn "IEmailService\|ICurrentUserService" MyProject/src` | Sin resultados: las interfaces de servicio técnico que justifican la referencia no existen en el laboratorio |
| V3 | `https://api.nuget.org/v3-flatcontainer/automapper/index.json` | Versiones 14.x: solo `14.0.0`; luego `15.0.0`…`15.1.3`. «14.0.0 es la última MIT» se sostiene |
| V4 | `https://api.github.com/advisories/GHSA-rvv3-g6hj-g44x` | Rango vulnerable `< 15.1.1`, primera versión corregida `15.1.1` (y `>= 16.0.0, < 16.1.1` → `16.1.1`) |
| V5 | `https://luckypennysoftware.com/license` (PDF, «License document version 2.0») | §4.2.g.1: no disponible para agencias de gobierno o cuasi gubernamentales; §4.2.g.3.1: ingresos brutos < USD 5 M; §4.2.g.3.2: nunca haber recibido > USD 10 M de capital externo; §4.2.g.3.3: universidades no elegibles para software institucional u operativo, con excepción para estudiantes y docentes con fines educativos genuinos |
| V6 | Capturas L00, L05, L10, L13, L15, L16, L17, L22, L24 contra la prosa | Coinciden (códigos, hashes, cuerpos JSON, `curl 8.5.0`, `Hosting environment: Development`) |

---

## 0. La tesis, en una línea

**La guía ya no practica la sobreingeniería que atacaba el ciclo 1: cada escalón nace después de un comando que muestra su necesidad, y lo que no se ejecutó está rotulado.** Lo que queda por atacar es más fino: un rótulo de escenario (E-A) que nombra dos estructuras distintas, una referencia del esqueleto que la propia guía llamaría «por las dudas», un mapa de consulta al que le falta el caso más común de quien diseña desde cero, y tres afirmaciones que se colaron sin la evidencia o sin el rótulo que la guía promete en §0.5.

---

## 1. Hallazgos

### H-01 — «E-A» nombra dos estructuras incompatibles: la de un proyecto sin handlers y la de un Blazor Server que inyecta los handlers de Application

- **Ubicación:** §0.4 l.70; §1.6 l.216; §2.7 l.352; §4.6 l.550; §5.7 l.737; §6.4 l.808 y l.814; §6.6 l.849; §8.3 l.1052 y l.1055; §9.1 l.1093.
- **Evidencia:** E2 (contradicción interna) + E3.
- **Severidad:** S2.
- **Confianza:** 0,85.

**Afirmación.** §0.4 define E-A como situación («una sola aplicación Blazor que corre en el servidor; … pocas reglas»). Después la guía usa el rótulo para dos estructuras que se excluyen:

1. **Escalón 1, un proyecto, sin casos de uso.** §9.1 l.1093: «**E-A** … | Un proyecto: página → servicio → EF Core». §4.6 l.550: «en el escenario E-A: ahí el handler solo reenvía la llamada al repositorio, y una capa que solo reenvía es costo sin beneficio». §2.7 l.352: «el esquema página → servicio → EF Core en un único proyecto».
2. **Escalón 3 sin API: cuatro proyectos, la página inyecta los handlers.** §6.4 l.808: «en ese caso se puede, y es el escenario E-A»; l.814: «✅ Blazor en el servidor, único cliente, inyecta `CrearProductoHandler`». §5.7 l.737: «en el escenario E-A la aplicación Blazor en el servidor llama a los casos de uso dentro del mismo proceso». §8.3 l.1052: «Cliente en el mismo proceso, único (E-A) | `Application`».

**Contraejemplo.** Un lector en consulta entra por §9.1, lee que E-A es «un proyecto», y al llegar a §8.3 encuentra que en E-A su cliente «puede referenciar `Application`»: en un proyecto único no hay `Application` que referenciar. Al revés, quien viene de §6.4 con handlers inyectados lee en §4.6 que en su escenario el handler «sobra». Son dos lectores que salen con estructuras distintas del mismo rótulo. Es la condición de coherencia del marco §3 («todo término del glosario se usa con un solo sentido»): E-A no está en el glosario, pero DR-17 lo fija como rótulo único de todo el documento.

**Qué no toca.** No reabre DC-1..DC-4 ni HC-23/DR-23 (la condición «mismo proceso y único cliente» sigue igual). Solo pide que el rótulo de la fila 2 sea el correcto: según §9.1 l.1096, «Domain y Application separados, aunque haya un solo cliente» es la fila **E-D**, y según §9.2 el escalón 3 se sube por «reglas ricas (E-D)».

**Reemplazo propuesto (cuatro lugares; el resto queda como está).**

- §6.4 l.808, reemplazar: «**Respuesta: en ese caso se puede, y es el escenario E-A; la condición deja de cumplirse cuando aparece un cliente remoto.**» por: «**Respuesta: en ese caso se puede; es un cliente único en el mismo proceso (E-D sin cliente remoto, o E-A que subió al escalón 3), y la condición deja de cumplirse cuando aparece un cliente remoto.**»
- §5.7 l.737, reemplazar: «en el escenario E-A la aplicación Blazor en el servidor llama a los casos de uso dentro del mismo proceso, sin HTTP ni contrato (§8.3).» por: «cuando el único cliente corre en el mismo proceso que el backend (E-A en el escalón 1, o E-D sin cliente remoto), la aplicación Blazor en el servidor llama a su servicio o a los casos de uso sin HTTP ni contrato (§8.3).»
- §6.6 l.849, reemplazar: «en el escenario E-A la página inyecta los casos de uso directamente (§6.4)» por: «con un único cliente en el mismo proceso (§6.4) la página inyecta el servicio o los casos de uso directamente».
- §8.3 l.1052, reemplazar: «| Cliente en el mismo proceso, único (E-A) |» por: «| Cliente en el mismo proceso, único (E-D sin cliente remoto; E-A en el escalón 3) |».

---

### H-02 — La referencia `Infrastructure → Application` del esqueleto es exactamente lo que §9.3 llama «por las dudas»: no la usa ningún archivo del laboratorio y lo que la justifica no existe

- **Ubicación:** §2.6 l.309 y l.348; Diagrama 2 l.341; §9.3 l.1120; §9.6 l.1155. Captura `L08-esqueleto.txt`; V1 y V2.
- **Evidencia:** E1 (V1, V2 sobre `MyProject/`) + E2.
- **Severidad:** S2.
- **Confianza:** 0,8.

**Afirmación.** §2.6 l.348: «`Infrastructure` referencia también a `Application` porque ahí se declaran las interfaces de servicios técnicos (correo, usuario actual) que Infrastructure implementa.» En el código publicado no hay ninguna interfaz de servicio técnico (V2) y ningún `.cs` de Infrastructure nombra un tipo de Application (V1). La referencia se agrega en L08 y llega a L24 sin un solo consumidor. La guía cierra con «Cada capa y cada clase se agrega cuando aparece la señal que la justifica» (§9.6 l.1155) y lista como señal de sobreingeniería «Se agregó un repositorio encima de EF Core "por las dudas"» (§9.3 l.1120). Una referencia de proyecto sin uso es el mismo defecto en el nivel de las flechas, y es el lector principiante quien la copia sin poder explicarla.

**Por qué es S2 y no S4.** El §1.3 enseña que «decidir quién puede conocer a quién se reduce a decidir hacia dónde apuntan las flechas». Una flecha que la guía dibuja «porque ahí se declaran» interfaces que no están es una afirmación que el laboratorio no respalda (R-13) y que dos lectores van a resolver distinto: uno agrega la referencia a ciegas; otro, siguiendo §9.6, no la agrega y después no entiende por qué el Diagrama 2 la tiene.

**Qué no toca.** No reabre DC-3 (las interfaces técnicas viven en Application; eso sigue). Solo pide honestidad sobre el momento en que la flecha se justifica.

**Reemplazo propuesto (§2.6 l.348).** Reemplazar: «`Infrastructure` referencia también a `Application` porque ahí se declaran las interfaces de servicios técnicos (correo, usuario actual) que Infrastructure implementa.» por: «`Infrastructure` referencia también a `Application` para implementar las interfaces de servicios técnicos que Application declara (§4.1: `IEmailService`, `ICurrentUserService`). En el laboratorio todavía no existe ninguna: la referencia se adelanta en el esqueleto para que el Diagrama 2 muestre el grafo de la solución completa, y queda sin uso hasta que aparezca la primera (se comprueba con `grep -rn Application src/Backend/MyProject.Infrastructure --include=*.cs`, que no devuelve nada). Con el criterio del §9.6, en una solución real esa flecha se agrega recién cuando aparece la interfaz que la necesita.»

Alternativa más cara y más honesta: un paso de laboratorio que agregue `ICurrentUserService` en Application y su implementación en Infrastructure, para que la referencia tenga consumidor capturado. La decido a favor del reemplazo de texto por DR-08.

---

### H-03 — El mapa de entrada §9.1 no tiene fila para el caso más común de quien diseña desde cero: una API cuyos clientes no son .NET

- **Ubicación:** §9.1 l.1091–1096; §0.4 l.71; §8.5 l.1079–1081; Anexo B l.1202.
- **Evidencia:** E3 (contraejemplo) + E2.
- **Severidad:** S2.
- **Confianza:** 0,75.

**Afirmación.** §0.3 promete que la consulta entra «directo a §9.1 (mapa de entrada) y de ahí al capítulo que corresponda». Las cuatro filas son E-A (Blazor en el servidor), E-B («una API con clientes .NET remotos», §0.4 l.71), E-C (base heredada) y E-D (reglas ricas).

**Contraejemplo.** Un equipo diseña un backend .NET para un frontend en JavaScript y una app móvil nativa. No es E-A (no hay Blazor), no es E-B por definición (los clientes no son .NET), no es E-C ni E-D. La respuesta existe en la guía (§8.5: «sin clientes .NET, el contrato es el documento OpenAPI»; Anexo B, pregunta 4), pero el mapa que la guía declara como puerta no lleva a ella. Quien consulta lee que E-B exige «`Contracts` + clientes» y monta un proyecto `Contracts` que nadie va a referenciar: sobreingeniería inducida por omisión del mapa. Lo mismo pasa con el backend sin interfaz (un servicio que solo expone la API o procesa lotes): ninguna fila lo nombra.

**Qué no toca.** DR-17 fija cuatro rótulos; no propongo un quinto. Propongo una fila sin rótulo, que remite a E-B y a §8.5.

**Reemplazo propuesto (§9.1, insertar después de la fila E-B l.1094).** Agregar la fila: «| Una API cuyos clientes no son .NET (navegador con JavaScript, móvil nativo, otro equipo) | La de E-B sin `Contracts`: el contrato es el documento OpenAPI que publica la API | Entidad, mensaje, modelo de lectura, DTOs de la WebAPI | §5, §8.5 | Aparece el primer cliente .NET: nace `Contracts` (§6.3) |».

Y en §0.4 l.71, reemplazar: «| **E-B** | Una API HTTP con uno o más clientes .NET remotos (web, móvil, consola) |» por: «| **E-B** | Una API HTTP con uno o más clientes .NET remotos (web, móvil, consola); si los clientes no son .NET, la estructura es la misma sin `Contracts` (§8.5, §9.1) |».

---

### H-04 — §9.2 y §9.3 responden distinto a la misma señal: «quiero probar la regla sin base» sube al escalón 2 en el diagrama y al 3 en la tabla

- **Ubicación:** §9.2 l.1102 (flecha «una regla se repite o se necesita probarla» → escalón 2); §9.3 l.1116 («Se quiere probar una regla y hace falta levantar la base | Falta separar Domain (escalón 3)»); §9.5 l.1151 («con el término medio (escalón 2) desde que la regla del precio se quiere probar»).
- **Evidencia:** E2.
- **Severidad:** S3.
- **Confianza:** 0,8.

**Afirmación.** La misma señal manda a dos escalones. §9.2 y §9.5 dicen escalón 2 (entidad + form model, un proyecto); §9.3 dice escalón 3 (proyecto `Domain` separado). Para quien consulta §9.3 aislada, «probar sin base» exige un proyecto nuevo; para quien mira el diagrama, no. Es una de las cinco filas de la tabla que forma el criterio de «cuándo es sobreingeniería», y se contradice con el diagrama de arriba.

**Reemplazo propuesto (§9.3 l.1116).** Reemplazar: «| Se quiere probar una regla y hace falta levantar la base | Falta separar Domain (escalón 3) |» por: «| Se quiere probar una regla y hace falta levantar la base | Falta una entidad con comportamiento que se pruebe sola (escalón 2); si además hace falta que el compilador impida que la entidad toque la persistencia (§2.2), un proyecto `Domain` (escalón 3) |».

---

### H-05 — La explicación de `4500.0` es una interpretación sin verificar y no lleva el rótulo que la Bitácora 04 dice que lleva

- **Ubicación:** §5.3 l.662; §6.3 l.801 y l.804. Bitácora 04 §2, fila «SQLite devuelve `4500.0` … interpretación rotulada». Capturas `L17-mismo-contrato.txt`, `L22-cliente-consola.txt`.
- **Evidencia:** E2.
- **Severidad:** S3.
- **Confianza:** 0,8.

**Afirmación.** §5.3 l.662: «el tipo `decimal` conserva la escala con la que el proveedor de SQLite lo devuelve». Las capturas muestran solo el efecto (`4500` en memoria en L15, `4500.0` con SQLite en L17). Ninguna captura ni paso del laboratorio muestra la causa (cómo guarda el proveedor el `decimal`, con qué escala lo lee, quién lo serializa). La Bitácora 04 registra que la interpretación quedó «rotulada», pero en la guía la frase está en indicativo, sin «Criterio de esta guía», sin cita y sin «probable». Es una afirmación de causa sin evidencia, en el capítulo que más insiste en «cómo leer la salida». Además, §6.3 l.804 atribuye una variación posible del número a «la cultura regional del equipo», que es otra causa distinta para el mismo `12000.0`; el lector recibe dos explicaciones para un mismo síntoma y ninguna verificada.

**Reemplazo propuesto (§5.3 l.662).** Reemplazar: «El precio llega como `4500.0` en lugar de `4500`: el valor numérico es igual, pero el tipo `decimal` conserva la escala con la que el proveedor de SQLite lo devuelve. Un cliente que compare textos en lugar de números notaría la diferencia, y por eso la prueba de un contrato compara valores.» por: «El precio llega como `4500.0` en lugar de `4500`. El valor numérico es el mismo; lo que cambió es la representación. La causa probable es que el proveedor de SQLite devuelve el `decimal` con otra escala y el serializador JSON la conserva; el laboratorio no lo verificó, así que queda como interpretación de esta guía. Lo que sí muestra la captura: un cliente que compare textos en lugar de números notaría la diferencia, y por eso la prueba de un contrato compara valores.»

---

### H-06 — El Anexo C esconde en «con otras condiciones» las dos exclusiones de la licencia Community que más afectan al lector de esta guía, y deja impreciso desde qué versión está corregida la vulnerabilidad de AutoMapper

- **Ubicación:** Anexo C l.1223 (AutoMapper) y l.1224 (licencia comunitaria); §9.4 l.1137 («la vulnerabilidad está corregida en versiones de esa rama»). V4 y V5.
- **Evidencia:** E2 (cita literal del PDF de la licencia, §4.2.g.1 y §4.2.g.3.3) + E1 (V4, advisory de GitHub).
- **Severidad:** S3.
- **Confianza:** 0,9.

**Afirmación 1.** Anexo C l.1224: «Gratuita para organizaciones con ingresos brutos anuales menores a USD 5 millones, con otras condiciones». El documento de licencia (V5) dice, literalmente: «Community Licenses are not available to any government agency or any quasi-government agency regardless of the size of such agency or its budget» (§4.2.g.1) y «Universities and other higher-education institutions are not eligible for the Community License for institutional or operational software … individual students, faculty, instructors, and other educators may use the Licensed Product under the Community License for genuine educational purposes» (§4.2.g.3.3). Para una guía cuya audiencia declarada es «quien diseña una solución .NET desde cero» y que vive en un laboratorio de documentación de uso académico, la exclusión de gobierno y de sistemas institucionales de universidades es el dato que decide, no una «otra condición». DR-29 pedía «condiciones de la licencia Community»; «con otras condiciones» no es verificable (R-13).

**Afirmación 2.** §9.4 l.1137 y Anexo C l.1223 dicen que la vulnerabilidad «está corregida en versiones de esa rama», sin decir cuál. El advisory (V4) fija el rango vulnerable en `< 15.1.1`: las versiones `15.0.0`, `15.0.1` y `15.1.0`, ya con licencia dual, siguen siendo vulnerables. Un lector que pague la licencia comercial y elija `15.0.0` queda vulnerable creyendo lo contrario.

**Reemplazos propuestos.**

- Anexo C l.1224, reemplazar: «| Licencia comunitaria de Lucky Penny Software | Gratuita para organizaciones con ingresos brutos anuales menores a USD 5 millones, con otras condiciones |» por: «| Licencia comunitaria de Lucky Penny Software | Gratuita para personas y para organizaciones con ingresos brutos anuales menores a USD 5 millones que nunca recibieron más de USD 10 millones de capital externo (§4.2.g.3). No disponible para agencias de gobierno ni cuasi gubernamentales (§4.2.g.1) ni para universidades en software institucional u operativo; estudiantes y docentes pueden usarla con fines educativos (§4.2.g.3.3) |».
- §9.4 l.1137, reemplazar: «y la vulnerabilidad está corregida en versiones de esa rama.» por: «y la vulnerabilidad está corregida desde la 15.1.1 (el aviso fija el rango vulnerable en `< 15.1.1`, [GitHub, 2026](#ref-github-2026)).»
- Anexo C l.1223, reemplazar: «14.0.0 MIT con vulnerabilidad alta GHSA-rvv3-g6hj-g44x; desde 15.0.0 RPL-1.5 o comercial» por: «14.0.0 MIT, última versión MIT, con vulnerabilidad alta GHSA-rvv3-g6hj-g44x (rango vulnerable `< 15.1.1`, corregida en 15.1.1); desde 15.0.0 RPL-1.5 o comercial».

---

### H-07 — Dos «Criterio de esta guía» se apoyan en algo que no está: la alternativa 422 sin cita (DR-28 la exige) y un orden de preguntas «en ese orden» sin fundamento

- **Ubicación:** §5.6 l.733; §9.4 l.1124; DR-28 (veredicto §7.4).
- **Evidencia:** E4 (DR-28: «se menciona 422 como alternativa válida con su cita») + E2.
- **Severidad:** S3.
- **Confianza:** 0,7.

**Afirmación.** Los cinco rótulos «Criterio de esta guía» (§4.5, §5.6, §7.5, §9.2, §9.4) cumplen DR-10 en la forma: la recomendación propia queda marcada. Dos de ellos, sin embargo, se sostienen con un apoyo que no está:

1. §5.6 l.733: «responder `422 Unprocessable Content` a las reglas de negocio es otra convención posible». El código y su nombre vienen de un estándar y DR-28 pedía la cita. Sin ella, el lector no puede verificar que 422 exista con ese nombre ni qué significa; el criterio «400 para las dos clases» se contrasta contra una alternativa sin fuente, y el contraste es lo que lo funda.
2. §9.4 l.1124: «**Respuesta: soporte, licencia, vulnerabilidades conocidas, alternativa nativa y costo de salida, en ese orden.**» El orden es una afirmación normativa que nada en el capítulo justifica: la tabla de l.1139 las presenta como cinco preguntas paralelas y el caso AutoMapper no muestra que una decida antes que otra. «En ese orden» es dogma; sin él, la respuesta sigue siendo un criterio válido.

**Reemplazos propuestos.**

- §5.6 l.733, reemplazar: «responder `422 Unprocessable Content` a las reglas de negocio es otra convención posible.» por: «responder `422 Unprocessable Content` (definido en RFC 9110, §15.5.21, [IETF, 2022](#ref-ietf-2022)) a las reglas de negocio es otra convención posible.» Y agregar en el Anexo E: «<a id="ref-ietf-2022"></a>IETF. (2022). *RFC 9110: HTTP Semantics*, §15.5.21. https://www.rfc-editor.org/rfc/rfc9110.html#section-15.5.21 (consultado el 2026-09-18).»
- §9.4 l.1124, reemplazar: «**Respuesta: soporte, licencia, vulnerabilidades conocidas, alternativa nativa y costo de salida, en ese orden.**» por: «**Respuesta: soporte, licencia, vulnerabilidades conocidas, alternativa nativa y costo de salida; las cinco antes de agregar la primera línea que dependa del paquete.**»

---

## 2. HC-25, HC-26 y HC-27: revisión encomendada por el veredicto del ciclo 1 (§10.2)

| Ítem | Estado en el ciclo 1 | Qué muestra el documento final | Resolución que propongo |
|---|---|---|---|
| **HC-25** «Empezar por la solución máxima dificulta ver cuándo aplica cada escalón» (C, S3) | INSUFICIENTE; vuelve a Didáctica: el novato debe decir en qué capítulo entendió por qué existe cada escalón; si no asciende a E2, se archiva | La guía ahora hace nacer cada escalón después de una necesidad capturada: escalón 3 en L06/L07 (§2.2), L10–L12 (§3.3, §4.3); escalón 4 en L22 (§6.3); cada capítulo cierra con «¿cuándo no…?». El único escalón que no se ve ni se ejecuta es el 2 (término medio, §7.5), y está rotulado «Criterio de esta guía» conforme a DR-10 y a la resolución CT-01 («no se ejecuta») | **Archivar.** No asciende de C en dos ciclos (regla dura del marco §3). El residuo (escalón 2 sin evidencia de laboratorio) está declarado y no funda corrección |
| **HC-26** «`curl` podría faltar en la imagen» (C, S3) | NO_PROCEDE; refutado por E1 del jurado | `capturas/L00-entorno.txt` registra `curl 8.5.0 (x86_64-pc-linux-gnu)` con código de salida 0 dentro de la imagen `sdk:10.0@sha256:e1ffd2a9…` (V6) | **Cerrado y correcto.** Nada que corregir |
| **HC-27** «Sin perfil de lanzamiento, el entorno es Production» (C, S3) | INSUFICIENTE; se resuelve si L13 registra el entorno | `capturas/L13-arranque.txt`: `Hosting environment: Development`; `aserciones.log`: `PASS L13 entorno Development`. La receta de §5.2 l.602 fija `ASPNETCORE_ENVIRONMENT=Development` y §5.6 l.713 explica que la traza del 500 de L20 depende de ese entorno | **Cerrado y correcto.** La conjetura quedó resuelta por captura |

---

## 3. Revisado y correcto

1. **DA-4 se aplicó sin trampa, y los datos volátiles resisten una segunda verificación.** MediatR y AutoMapper aparecen solo en §4.5, §9.4 y el Anexo C (DR-24). L24 muestra `NU1903`, el `dotnet list package --vulnerable` y las licencias leídas de los `.nuspec`; mi reverificación (V3, V4) confirma que `14.0.0` es la única 14.x y la última MIT, y que la vulnerabilidad es real. El razonamiento de §9.4 («el caso no necesita lo que aportan») está antes que la licencia, como pidió mi H-03 del ciclo 1: la licencia refuerza, no funda.
2. **Los errores que enseñan son reales y las capturas dicen lo que la prosa dice.** L05 (falla silenciosa de `remove reference` con carpeta, código 0, la referencia sigue en el `.csproj`), L10 (`CS0200`, no `CS0272`: la Bitácora 04 registra la corrección y la guía la lleva), L16 (mismo `sha256` de `Domain.dll` y `Skipping target "CoreCompile"`), L18 (201 y lista vacía sin `SaveChangesAsync`). Ninguna salida mostrada difiere de su captura (V6). Es lo contrario de la guía v1.x, que predecía errores que no ocurrían.
3. **La sobreingeniería del ciclo 1 (21 tipos para una regla, CQRS y MediatR por defecto, repositorio obligatorio, front que nunca referencia Application) está desmontada.** §4.4 nombra lo que hace y reserva «CQRS» con Fowler citado; §5.5 presenta el repositorio como opcional con Microsoft citado y el ejemplo lo conserva sin reabrir DC-3; §7.1 tiene la columna «Existe solo si…»; §7.5 y §9.2 dan la clase única y el término medio como opciones legítimas; §8.3 condiciona la regla del front. Mi ataque del ciclo 1 no tiene ya objeto en el cuerpo del documento; lo que queda (H-01..H-07) es de precisión, no de dirección.

---

## 4. Solicitudes de convocatoria (fuera de mandato)

1. **E-Arquitecto .NET.** Verificar la causa técnica del `4500.0` de L17 (H-05): cómo guarda y lee el `decimal` el proveedor `Microsoft.EntityFrameworkCore.Sqlite` 10.0.12 con `HasPrecision(18, 2)` y si es el serializador o el proveedor quien conserva la escala. Si se puede capturar en un paso (por ejemplo, `SELECT typeof(Precio), Precio FROM Productos`), la interpretación asciende a E1 y el rótulo sobra.
2. **AH-001 (ecosistema y licencias), reconvocatoria acotada.** El veredicto §8 lo disolvió con la cláusula «se reconvoca solo si el ciclo 2 detecta una señal de versión o licencia». H-06 es esa señal: confirmar las cláusulas §4.2.g.1 y §4.2.g.3.3 del documento de licencia versión 2.0 y la primera versión corregida de GHSA-rvv3-g6hj-g44x, y decidir si «FluentValidation 12.1.1 Apache-2.0» y «Refit < 7.2.22» (DR-29) faltan en el Anexo C a propósito o por omisión: la guía menciona Refit en §6.5 con licencia pero sin el aviso de versión que DR-29 pedía.
3. **E-Didáctica.** Juzgar si la fila nueva de §9.1 (H-03) y el rótulo doble de E-A (H-01) conviene resolverlos con una nota en §0.4 («E-A describe una situación; su estructura va del escalón 1 al 3 según las reglas») en lugar de los cuatro reemplazos puntuales. La cuestión de qué forma enseña mejor es de su competencia.
