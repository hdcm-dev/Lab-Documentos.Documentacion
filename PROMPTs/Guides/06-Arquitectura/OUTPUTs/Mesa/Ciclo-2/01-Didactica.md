# Ciclo 2 — E-Didáctica

**Objeto:** `LAB/Lab-Documentos/Guides/Arquitectura/Dot-NET-Arquitectura-Guide.md` v2.0.0 (1308 líneas) y `Dot-NET-Arquitectura-Lab/`.
**Mandato:** orden de construcción de conceptos, términos antes de su definición (DR-16), práctica intercalada y cierres «cuándo no» (DR-15), R-02 (§7.2) y el pedido HC-25 del ciclo 1.
**Vara:** R-01..R-17 (Bitácora 02), DR-15, DR-16, DR-19 (Veredictos §7). No reabro DC-1..DC-4 ni DA-1..DA-4.
**Trabajo a ciegas:** no leí informes de otros integrantes del ciclo 2.

## Resumen

| ID | § / línea | Evidencia | Severidad | Tema |
|---|---|---|---|---|
| DID2-01 | §9.2 l.1102, §9.3 l.1116, §9.5 l.1151, Anexo B l.1200 | E2 | S2 | La señal «probar la regla» sube al escalón 2 en un lugar y al 3 en otro |
| DID2-02 | §0.4 l.75; «escalón» aparece por primera vez en l.1091 | E2 | S3 | HC-25: el lector del recorrido no sabe que está construyendo el escalón 4 ni por qué; el escalón 2 no tiene capítulo |
| DID2-03 | §7 l.855; §7.2 c (l.896–906) y e (l.919–928) | E2 | S3 | R-02 incompleto: c y e sin remisión a Lnn; la frase de l.855 afirma algo falso para e y f |
| DID2-04 | §5.2 l.613–617 | E2 | S3 | `curl` y sus opciones nunca se definen, y L13–L21 dependen de ellos |
| DID2-05 | §2.1 l.237–240, §2.3 l.282, §2.4 l.288, §2.6 l.314, §9.1 l.1093 | E2 | S3 | DR-16: EF Core, controller, caso de uso, value object, repositorio, SQLite y ASP.NET Core se usan antes de definirse; ASP.NET Core y CRUD no se definen nunca |
| DID2-06 | §5.3 l.653–662 | E1 (cabecera de la captura) | S3 | El comando que se muestra para L16 no es el que produjo la salida: quien lo ejecuta no ve las huellas SHA-256 |
| DID2-07 | §0.3 l.60 contra §1.3–§1.5, §2.3, §2.4, §5.4, §6.2, §6.3, §7.4, §8.2, §8.5; §3.5 l.450; §8 | E2 | S3 | DR-15: la guía promete ✅/❌ en cada decisión y no lo cumple; §3.5 cierra sin escenario; §8 no tiene cierre |

---

## DID2-01 — La señal «probar la regla» apunta a dos escalones distintos (S2, E2)

**Afirmación.** La misma señal lleva a escalones distintos según dónde se lea:

- §9.2, l.1102 (diagrama 6): `S1 -->|"una regla se repite<br/>o se necesita probarla"| S2["2. Término medio…"]`
- §9.5, l.1151: «con el término medio (escalón 2) desde que la regla del precio se quiere probar».
- §9.3, l.1116: «Se quiere probar una regla y hace falta levantar la base | Falta separar Domain (escalón 3)».
- Anexo B, l.1200: «¿Hay reglas de negocio que se repiten o que conviene probar sin base de datos? | `Domain` y `Application` separados (E-D)».

Además, l.1115 manda «La misma validación aparece en dos pantallas» a «escalón 2 o 3», sin criterio para elegir. Quien entra por consulta (§0.3 lo manda a §9.1) recibe dos respuestas incompatibles para la misma situación. Esta es la pregunta central de HC-25 (por qué existe cada escalón), así que la reporto desde Didáctica.

**Contraejemplo (E3).** Una aplicación Blazor en el servidor (E-A) quiere probar la regla del precio. Por el diagrama 6 y §9.5, pasa al escalón 2 (entidad + form model, un proyecto). Por §9.3 y el Anexo B, separa Domain y Application (escalón 3). Dos lectores del mismo documento terminan con estructuras distintas: eso cumple la definición de S2.

**Corrección propuesta.** Se toma como verdadera la versión del diagrama y de §9.5, que es la que produce una escalera sin saltos. En el escalón 2 la regla vive en la entidad, y `Producto.Create` se prueba sin base de datos (L11 lo hace así).

- l.1116: reemplazar `| Se quiere probar una regla y hace falta levantar la base | Falta separar Domain (escalón 3) |` por `| Se quiere probar una regla y hace falta levantar la base | Falta una entidad que contenga la regla (escalón 2); si además hay que impedir con el compilador que la regla dependa de EF Core, falta separar Domain (escalón 3) |`
- l.1115: reemplazar `| La misma validación aparece en dos pantallas | Falta una entidad con comportamiento (escalón 2 o 3) |` por `| La misma validación aparece en dos pantallas | Falta una entidad con comportamiento (escalón 2); si las reglas son muchas y se repiten en varios casos de uso (E-D), escalón 3 |`
- l.1200: reemplazar `¿Hay reglas de negocio que se repiten o que conviene probar sin base de datos?` por `¿Hay reglas de negocio ricas que se repiten en varios casos de uso? (Si es una sola regla que se quiere probar, alcanza el término medio del §7.5.)`

Pido al Arquitecto .NET que confirme la parte técnica: que en el escalón 2 la entidad se pueda probar sin base de datos (ver solicitudes).

## DID2-02 — HC-25: el recorrido no dice qué escalón se está construyendo ni por qué (S3, E2; asciende HC-25 de C a E2)

**Pedido del jurado (Veredictos §4, HC-25):** decir en qué capítulo entiende el lector por qué existe cada escalón.

**Respuesta, escalón por escalón:**

| Escalón (§9.2) | Dónde se entiende su porqué | Observación |
|---|---|---|
| 1. Página → EF Core, un proyecto | §1.6 (l.216), §2.7 (l.352), §3.4 (l.446, Transaction Script) | Se entiende, pero como «cuándo no», nunca con el nombre de escalón |
| 2. Término medio | Solo §7.4–§7.5 (l.977, l.985) | **No tiene capítulo en Partes I–II ni práctica.** El form model se define en §6.1 con una remisión adelante («§7.2 e y f») |
| 3. Domain + Application | §2.2 (L06/L07), §3.3 (L10), §4.3 (L11/L12) | Bien construido y con práctica |
| 4. + WebAPI + Contracts | §5.7 (l.737), §6.3 (L22), §6.4 | Bien construido. Pero el esqueleto del escalón 4 se arma en §2.6 (L08, `dotnet new webapi`) tres capítulos antes de que se defina HTTP (§5.1) |

**Evidencia E2.** La palabra «escalón» aparece por primera vez en l.1091 (§9.1). Ningún cierre de §1–§6 nombra la escalera. La explicación de por qué la guía construye el escalón 4 está en §9.5 (l.1151: «La guía la construye en el escalón 4 porque el enunciado incluye "otras aplicaciones que consumen el catálogo"»). El lector del recorrido la encuentra recién después de haber construido todo. §0.4 (l.75) termina con «El problema se resuelve en §9.5» sin adelantar esa razón. Esto es el efecto que D-07 del ciclo 1 conjeturaba: con la ubicación ya citada, deja de ser C.

**Corrección propuesta.**

- l.75: reemplazar `El problema se resuelve en [§9.5](#95-el-problema-conductor-resuelto).` por `La guía construye la versión más completa de la solución —cuatro proyectos de backend, un contrato compartido y un cliente remoto— porque el enunciado incluye otras aplicaciones que consumen el catálogo, que es la señal del escenario E-B. No es la estructura que conviene siempre: cada capítulo cierra con la pregunta de cuándo lo construido no hace falta, y el [§9.2](#92-la-escalera-de-opciones) ordena esas respuestas en una escalera de cuatro escalones, desde un solo proyecto hasta la API con clientes remotos. El problema se resuelve en [§9.5](#95-el-problema-conductor-resuelto).`
- §7.5, l.985: reemplazar `sin montar las cuatro capas. **Criterio de esta guía.**` por `sin montar las cuatro capas. Es el escalón 2 de la escalera del [§9.2](#92-la-escalera-de-opciones). **Criterio de esta guía.**`
- §2.7, l.352, al final: agregar `En la escalera del §9.2, eso es subir del escalón 1 al 3.` §5.7, l.737, al final: agregar `Es la diferencia entre los escalones 3 y 4 del §9.2.`

## DID2-03 — R-02: dos de las siete respuestas no remiten a un paso de laboratorio (S3, E2)

**Criterio (R-02 / DR-19).** «§7.2 con 7 `####`, cada uno con respuesta en una línea, porqué, ✅/❌ y remisión Lnn».

**Chequeo.** Hay 7 `####` (a–g) y cada uno tiene `**Respuesta`: eso se cumple. La remisión a un paso Lnn falta en dos:
- **c. Command / Query** (l.896–906): remite a §5.2, a ningún Lnn.
- **e. ViewModel** (l.919–928): no remite a ninguno. En el laboratorio no hay ViewModel (grep de `ViewModel|FormModel` en `MyProject/`: 0 archivos).
- **f. Form model** remite a L10, que muestra el lado de la entidad y no el form model. Es aceptable como «paso que muestra la necesidad».

Además, l.855 afirma: «Para la consulta, cada respuesta remite al paso de laboratorio donde el objeto se vio funcionando». Para e y f es falso: ninguno de los dos objetos se ejecutó. En f, `@bind-Value` (l.934) se usa sin definirse (DR-16).

**Corrección propuesta.**
- l.855: reemplazar `Para la consulta, cada respuesta remite al paso de laboratorio donde el objeto se vio funcionando.` por `Para la consulta, cada respuesta remite al paso de laboratorio donde el objeto se vio funcionando. El ViewModel y el form model no se construyeron en el laboratorio (§6.5); sus respuestas remiten al paso que muestra la necesidad que resuelven.`
- l.900: reemplazar `el controller lo construye a partir de `CrearProductoRequest` (§5.2).` por `el controller lo construye a partir de `CrearProductoRequest` (§5.2), y el `201 Created` de L14 es la respuesta a ese mensaje, atendido por su handler.`
- l.923, al final del párrafo de e: agregar `El laboratorio no construye un ViewModel, pero L22 muestra la necesidad: el cliente de consola imprime el precio como `12000.0`, y ese formato depende de la cultura regional del equipo. Mostrar «$ 12.000,00» es trabajo de la pantalla, no del contrato.` (Verificado: `capturas/L22-cliente-consola.txt` contiene `Mate de calabaza        12000.0`.)
- l.934: reemplazar `El enlace de datos de Blazor (`@bind-Value`) necesita` por `El enlace de datos de Blazor —la sintaxis `@bind-Value`, que copia lo que el usuario escribe en un campo a una propiedad del objeto— necesita`

## DID2-04 — `curl` se usa sin definirse (S3, E2)

**Afirmación.** §5.2 (l.613–617) introduce `curl -s -i -X POST … -H 'Content-Type: application/json' -d '…'`. Es la herramienta de práctica de L13–L21 (nueve pasos). Ni el programa ni sus opciones se definen en el cuerpo ni en el Anexo D (grep «curl»: l.614, 616 y 633, las tres de uso). El lector que pide el PO («sin conocimientos, pruebe comandos y entienda sus resultados») no sabe por qué la salida trae `HTTP/1.1 201 Created` y encabezados: eso lo produce `-i`. También incumple DR-16 (verbo y encabezado se definen en §5.1, pero la herramienta con la que se ejercitan, no).

**Corrección propuesta.** Después del bloque de l.613–617, insertar:

> `curl` es un programa de línea de comandos que envía una petición HTTP y muestra la respuesta. Las opciones usadas: `-s` oculta la barra de progreso; `-i` muestra la línea de estado (`HTTP/1.1 201 Created`) y los encabezados de la respuesta además del cuerpo; `-X POST` fija el verbo (sin `-X`, `curl` envía `GET`); `-H` agrega un encabezado, en este caso `Content-Type: application/json`, que avisa que el cuerpo es JSON; `-d` envía el cuerpo.

Fuente: manual de curl, https://curl.se/docs/manpage.html (opciones `-s`, `-i`, `-X`, `-H`, `-d`). Agregar al Anexo D: `| curl | Programa de línea de comandos que envía peticiones HTTP y muestra la respuesta | 5.2 |`.

## DID2-05 — DR-16: términos usados en la Parte I antes de su definición (S3, E2)

**Afirmación.** DR-16: «Ningún término antes de su definición». Primeras apariciones (grep sobre la guía):

| Término | Primer uso en el cuerpo | Definición |
|---|---|---|
| EF Core | l.239–240 (tabla de §2.1), l.282 («implementa esa interfaz con EF Core») | l.567 (§5.1) |
| controller | l.239, l.288, l.314 («clases controller») | l.564 (§5.1) |
| caso de uso | l.238, l.288 | l.460 (§4.1) |
| value object, repositorio, mensaje, modelo de lectura | l.237–238 | §3.1, §4.1 |
| SQLite | l.240 | l.567 |
| ASP.NET Core | l.230, l.240, l.255 | **nunca** |
| CRUD | l.1093 (§9.1) | **nunca** (§0.4 l.70 dice «alta, baja, modificación y consulta» sin la sigla) |
| doble de prueba | l.758 | **nunca** |

La tabla de §2.1 funciona como adelanto y es útil. El problema es que no avisa que esos términos se definen después, así que el novato no sabe si debería conocerlos.

**Corrección propuesta.**
- Después de la tabla de l.235–240, insertar: `Los términos de la columna «Contiene» se definen en el capítulo de su proyecto: entidad y value object en §3.1; caso de uso, mensaje, modelo de lectura y repositorio en §4.1; controller y EF Core en §5.1. Por ahora alcanza con saber que **EF Core** es la biblioteca de Microsoft que guarda objetos de C# en una base de datos, y que **ASP.NET Core** es el marco de Microsoft para construir aplicaciones web y API HTTP en .NET.`
- l.1093: reemplazar `CRUD con pocas reglas` por `alta, baja, modificación y consulta (CRUD) con pocas reglas`.
- l.758: reemplazar `recibe una implementación real o un doble de prueba.` por `recibe una implementación real o un doble de prueba: una implementación falsa, escrita para las pruebas, como el repositorio falso de §4.3.`
- Anexo D: agregar ASP.NET Core (2.1) y EF Core (5.1).

## DID2-06 — El comando de L16 que muestra la guía no produce la salida que muestra (S3, E1)

**Afirmación.** §5.3 (l.653) dice «Al compilar con detalle (`dotnet build -v n`):» y muestra, entre otras, las líneas `sha256 Domain.dll antes : 7ce9…` y `… despues: 7ce9…`. La cabecera de `capturas/L16-compilar-con-efcore.txt` registra otro comando: `dotnet build -v n 2>&1 | grep -E "…CoreCompile…" ; echo "sha256 Domain.dll antes : $(cat /tmp/work/domain-antes.sha)"; … sha256sum …`. La huella «antes» se calculó en `lab.sh` l.576, antes de agregar EF Core. Quien ejecuta `dotnet build -v n` ve cientos de líneas y ninguna huella. Además, la guía no explica cómo leer `Skipping target "CoreCompile"`. En la captura, esa línea precede a `Done Building Project …MyProject.Domain.csproj`, pero el extracto de l.656 no dice de qué proyecto es. Esto rompe «pruebe comandos y entienda sus resultados» en el paso que demuestra la inversión de dependencias.

**Corrección propuesta.** l.653: reemplazar `Al compilar con detalle (`dotnet build -v n`):` por:

> El paso guarda primero la huella SHA-256 de `MyProject.Domain.dll` con `sha256sum src/Backend/MyProject.Domain/bin/Debug/net10.0/MyProject.Domain.dll`. Después agrega EF Core, compila con detalle (`dotnet build -v n`) y vuelve a calcular la huella. La compilación con detalle imprime cientos de líneas; el extracto conserva la que corresponde a `Domain` y las dos huellas (el comando completo figura en la cabecera de la captura):

Y en l.662, antes de «`Domain.dll` es el mismo archivo»: `La línea `Skipping target "CoreCompile"` dice que MSBuild no volvió a compilar `Domain` porque ninguno de sus archivos cambió. La huella SHA-256 es un número calculado a partir del contenido del archivo: si coincide, el archivo es el mismo.`

## DID2-07 — DR-15: el contraste ✅/❌ que promete §0.3 falta en la mitad de las decisiones; §3.5 y §8 sin cierre conforme (S3, E2)

**Afirmación.** §0.3 (l.60) promete que en cada capítulo cada decisión trae «ejemplos que cumplen (✅) y que no cumplen (❌)». DR-15 pide ✅/❌ (1 ✅ y 2-3 ❌) o una tabla de escenarios. Decisiones sin ninguno de los dos: §1.3, §1.4, §1.5 (el capítulo 1 no tiene ninguno), §2.3, §2.4, §5.3, §5.4, §6.2, §6.3, §7.4, §8.2 y §8.5. En §1.4, §1.5 y §5.3 el contraste lo da la salida del laboratorio, y eso es didácticamente válido. En §2.3, §2.4, §6.2 y §8.5, que son decisiones de diseño, falta. Además:
- §3.5 (l.450) responde el «¿cuándo no?» sin nombrar ningún escenario E-A..E-D (DR-15: «respondida en términos de E-A..E-D»).
- §8 no tiene pregunta de cierre (R-09: «cada capítulo cierra con una pregunta de aplicabilidad»).

**Corrección propuesta.**
- l.60: reemplazar `su porqué y ejemplos que cumplen (✅) y que no cumplen (❌)—, práctica` por `su porqué y, cuando la pregunta admite más de una manera de resolverla, ejemplos que cumplen (✅) y que no cumplen (❌); cuando se responde con un experimento, el contraste lo da la salida registrada—, práctica`
- §6.2, después del diagrama 5 (l.769), agregar:

  | | |
  | --- | --- |
  | ✅ | La página pide `IProductoApiService`; en las pruebas recibe un doble que devuelve una lista fija |
  | ❌ | La página crea un `HttpClient` y arma la URL `api/productos` en su propio código |
  | ❌ | Cada página repite la lectura del JSON y el manejo del código de estado |

- §2.3, después de l.282, agregar:

  | | |
  | --- | --- |
  | ✅ | `IProductoRepository` en `Domain`, `ProductoRepository` en `Infrastructure` |
  | ❌ | `IProductoRepository` en `Infrastructure`: `Domain` tendría que referenciarlo para usarla y se forma el ciclo de L04 |
  | ❌ | `Producto.Guardar(ConexionSql)`, como en L03: la entidad conoce la base |

- l.450: reemplazar `un `Nombre` que solo es texto no necesita un tipo propio.` por `un `Nombre` que solo es texto no necesita un tipo propio. En el escenario E-A, con pocas reglas, un value object rara vez tiene comportamiento que proteger; en E-D es el lugar donde una regla sobre un valor se escribe una sola vez. **Criterio de esta guía.**`
- §8: agregar `### 8.6 Pregunta de cierre` con el texto `**¿Cuándo no hacen falta las carpetas `Backend/`, `Clients/` y `Contracts/`?** En el escenario E-A hay una sola unidad de despliegue y ningún contrato compartido: un solo proyecto, o los proyectos de backend sin más nivel, alcanzan. Las tres carpetas empiezan a decir algo cuando aparece el primer cliente remoto (E-B).`

---

## Revisado y correcto

1. **Práctica intercalada (R-07, DR-04).** Cada paso L00–L24 aparece en la § de su concepto. El Anexo A (l.1163–1189) coincide con el mapa §6 del veredicto. Parte II sigue el orden Domain → Application → Infrastructure/WebAPI → clientes, y la prueba del handler (§4.3) llega antes de EF Core, como se pidió en el ciclo 1.
2. **Una prueba vista fallar (§4.3, L11/L12).** La regresión de L12 está explicada: fallan exactamente las dos pruebas que dependen de la regla, y se dice qué se esperaba y qué pasó. Verificado contra `capturas/L12-regresion.txt`.
3. **Cierres «¿Cuándo no…?» en §1–§6 (R-09).** §1.6, §2.7, §4.6, §5.7 y §6.6 responden en términos de E-A..E-D. §3.5 es la excepción (DID2-07).

## Solicitudes de convocatoria

- **Arquitecto .NET:** validar la corrección técnica de DID2-01. En el escalón 2 (entidad + form model en un solo proyecto), ¿se puede probar la regla de la entidad sin levantar la base? ¿Y qué razón técnica justifica el paso al escalón 3?
- **Verificación / QA:** en §5.2 la salida se presenta como extracto único de L14+L15, sin marcar que se omitieron líneas (`Content-Length`, `Date`, `Server: Kestrel` están en `capturas/L14-post.txt`). Revisar si DR-05 exige marcar la omisión con `...`, como hace §0.6.
