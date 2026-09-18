# Ciclo 2 — Informe del especialista en Requisitos (núcleo)

**Fecha:** 2026-09-18
**Objeto:** `LAB/Lab-Documentos/Guides/Arquitectura/Dot-NET-Arquitectura-Guide.md` v2.0.0 (1309 líneas) y `Dot-NET-Arquitectura-Lab/` (lab.sh 835 líneas, 34 capturas, `aserciones.log` 68 PASS / 1 FAIL provocado).
**Vara:** `Bitacora/02-Requisitos.md` (R-01..R-17), `Mesa/02-Ciclo1-Veredictos.md` §5 (índice aprobado), §6 (mapa Lnn) y §7 (DR-01..DR-30). DC-1..DC-4 y DA-1..DA-4 no se reabren.
**Método:** un chequeo mecánico por requisito (grep, script de anclas, conteo de `####`, contraste literal de cada extracto contra su captura) más la traza F-01..F-12. Trabajé a ciegas respecto de los otros informes del ciclo 2.

---

## 1. Matriz de cumplimiento R-01..R-17

| ID | Criterio (Bitácora 02) | Chequeo ejecutado | Resultado | Estado |
|---|---|---|---|---|
| R-01 | Fuente archivada; F-01..F-12 trazadas a § existentes | Bitácora 00 leída; cada destino buscado en la guía (§2 de este informe) | 12/12 trazan a secciones que existen y dicen lo que la fuente afirma | **Cumple** |
| R-02 | §7.2 con 7 `####`, cada uno con respuesta, porqué, ✅/❌ y remisión Lnn | `awk` sobre §7.2: 7 `####`, 7 `**Respuesta`, 7 tablas ✅/❌; remisión Lnn: a=2, b=1, c=**0**, d=1, e=**0**, f=1, g=1 | 5/7 completos | **Parcial** → H-05 |
| R-03 | Sección vigente con destino; sin remisiones a la versión anterior | Bitácora 03 §2: 14 secciones con destino; `grep -i "versión anterior\|guía vigente"` = **1** (l. 1128) | Inventario completo; una mención | **Cumple con observación** → H-06 |
| R-04 | Términos definidos antes de su uso; palabras prohibidas = 0; voseo solo en reglas/preguntas | grep DR-18: 3 coincidencias de «fundamental», todas dentro de URLs del Anexo E; voseo hallado solo en reglas prácticas («leé», «pasá», l. 212) y en «Qué puede cambiar en tu equipo» | 0 fuera de URL | **Cumple** |
| R-05 | Cada capítulo §1–§6: prerrequisitos → definiciones → decisiones → práctica → cierre | Checklist por capítulo: los seis tienen línea de prerrequisitos, `n.1 Definiciones`, decisiones como pregunta con `**Respuesta`, práctica con Lnn y `n.k Pregunta de cierre` | 6/6 | **Cumple** (el detalle ✅/❌ de DR-15 va como solicitud a Didáctica, §5) |
| R-06 | Cada Lnn: objetivo, comando, salida registrada, cómo leerla, qué confirma, qué puede cambiar; Anexo A completo; capturas existen | 29/29 marcas apuntan a archivos existentes; Anexo A tiene columnas Paso/§/Qué se hace/Qué confirma, **sin comando ni captura** (el índice aprobado §5 promete «sección, comando, qué confirma y captura»); 12 pasos sin comando en la guía (L06, L07, L09, L11, L12, L16, L18, L19, L20, L21, L23, L24); dos extractos no coinciden con su captura (L11, L12) | Salidas: 27/29 literales | **Parcial** → H-01, H-02 |
| R-07 | Cada Lnn aparece en la § de su concepto (mapa §6 del veredicto) | Tabla §↔Lnn del Anexo A contrastada con §6 del veredicto, paso por paso | 25/25 coinciden (L00→0.6 … L24→9.4) | **Cumple** |
| R-08 | §9 legible aislada: mapa §9.1, escalera, señales, caso resuelto §9.5 | Lectura de §9 sin los anteriores: 9.1 mapa por escenario, 9.2 escalera, 9.3 señales, 9.5 problema resuelto, 9.6 criterio | Presente | **Cumple** |
| R-09 | Cada capítulo cierra con pregunta de aplicabilidad en términos E-A..E-D; grep «¿Cuándo no» ≥ 1 por capítulo | grep: §1 l.216, §2 l.352, §3 l.450, §4 l.550, §5 l.737, §6 l.849; **§7, §8, §9 = 0** | 6/9 | **Parcial** → H-04 |
| R-10 | 6 diagramas con leyenda; ninguna flecha continua hacia afuera | 6 bloques `mermaid`; leyendas en los 6 (el 4 sin convención de línea: solicitud a Edición); flechas continuas: diagramas 1, 2 y 5 todas hacia adentro; 3 punteadas; 6 son señales declaradas | 6/6 | **Cumple** |
| R-11 | `##` 0–9 + anexos A–E; índice con glosa; anclas 100 % | Script: `##` = Índice, 0–9, A–E; `#####` = 0; 58 enlaces internos, 0 rotos; índice con glosa por capítulo | 100 % | **Cumple** |
| R-12 | Todo bloque `csharp` rotulado | 11 bloques: 9 rotulados antes; 2 (l. 167, l. 422) rotulados **después** del bloque (DR-09 dice «precedido») | 11/11 rotulados | **Cumple** (forma: solicitud a Edición) |
| R-13 | Salidas con marca de captura; versiones/licencias con cita; criterio propio rotulado | 14 bloques `text` de salida, todos con marca; DR-07: CS0234, CS0246, MSB4006, CS0200 con captura; DR-24/25: `MediatR|AutoMapper|CQRS` solo en §4.4, §4.5, §9.4, Anexos C/D/E; «Criterio de esta guía» en §4.5, §5.6, §7.5, §9.2, §9.4; **L11/L12 con duraciones que no están en la captura**; «10.0.12» (l. 653) sin marca; L24 no muestra «RPL-1.5» sino `LICENSE.md` | 3 desvíos acotados | **Cumple con observación** → H-01, H-03, H-07 |
| R-14 | Registro de convocatoria con AH-001 | `Mesa/01-Registro-Convocatoria.md` existe; `id: AH-001` en l. 46 | Presente | **Cumple** |
| R-15 | Informe del ciclo 2 + parches aplicados y verificados | Es el resultado de este ciclo | En curso | **Pendiente** (por diseño) |
| R-16 | `Bitacora/`, `Nucleos/`, `Mesa/`, `Laboratorio/` en `06-Arquitectura/OUTPUTs` | `ls` | 4/4 | **Cumple** |
| R-17 | NC-00..NC-10 + Bitácora 03 con trazabilidad núcleo → § | Bitácora 03 §1: 10 filas NC-01..NC-10 con secciones; frontmatter `traces` lista NC-01..NC-10 y R-01..R-17 | Presente | **Cumple** |

Resumen: 11 cumplen, 2 cumplen con observación, 3 parciales, 1 pendiente por diseño. Ninguno sin cumplir. No hay S1.

---

## 2. Traza F-01..F-12 (Bitácora 00) → documento

| # | Afirmación | Destino declarado | Verificación en la guía (línea) | Resultado |
|---|---|---|---|---|
| F-01 | La página recibe DTOs, no entidades | §6.2, §7.2 d | §7.2 d l. 912–917; §7.3 l. 971 «La entidad nunca sale del backend: el cliente trabaja con el contrato y con sus propios modelos». En §6.2 está solo en el diagrama 5 (l. 765–766), no en la prosa | Trazada (§7.3 es el destino más claro; ver «revisado» 1) |
| F-02 | Se parecen y se separan porque cambian por motivos distintos | §7.1 «cambia cuando» | l. 857 (intro de §7) y columna «Cambia cuando…» l. 861 | Trazada |
| F-03 | Tabla de siete objetos, con nombres DR-12 | §7.1 + «Existe solo si…» | l. 861–869: siete filas, `ProductoResponse`, `ProductoFormModel`; `CrearProductoRequest` en §5.1 y §7.3 | Trazada |
| F-04 | Recorrido de lectura y escritura, con `ProductoDto` | §7.3, diagrama 3 | l. 955–967: `ProductoDto` entre `Producto` y `ProductoResponse` (DA-2) | Trazada |
| F-05 | La entidad nunca sale del backend, condicionado a E-A | §7.3, §8.3 | l. 971 «La excepción está en el §7.5»; §8.3 fila «Cliente en el mismo proceso, único (E-A)» l. 1052 | Trazada |
| F-06 | Mapeo desde afuera con Fluent API | §5.4 | l. 664–683, `ProductoConfiguration` compilado | Trazada |
| F-07 | `ProductoDbModel` solo con base heredada | §7.2 g, E-C | l. 941–951; §0.4 E-C l. 72 | Trazada |
| F-08 | Setters públicos vs. privados, evidencia L10 | §3.3, §7.4 | l. 416–440 (CS0200, captura verificada); l. 977 | Trazada |
| F-09 | El contrato filtra campos; WASM no tiene el ensamblado de dominio | §5.2 (L15), §7.4 | l. 629 «no trae `activo`» (captura L15 verificada: `{"id","nombre","precio"}`); l. 977 | Trazada |
| F-10 | Blazor Server + CRUD de pocas reglas = Transaction Script válido, atribuido a Fowler | §7.5, §9.2, E-A | l. 983 con `[Fowler, 2002]`; §3.4 l. 446; Bitácora 04 §3 declara la verificación en el catálogo | Trazada |
| F-11 | Señales: segundo cliente; reglas repetidas | §9.3 | l. 1115 y l. 1117 | Trazada |
| F-12 | Término medio | §7.5, §9.2 escalón 2 | l. 985 (rotulado «Criterio de esta guía»); diagrama 6 S2 l. 1102 | Trazada |

Voz: la fuente en segunda persona quedó reescrita en impersonal («el esquema página → servicio → EF Core», l. 983), como pide DR-18.

---

## 3. Hallazgos

### H-01 — Los extractos de L11 y L12 no son literales de las capturas citadas

- **Ubicación:** §4.3, l. 513–514 y l. 520–525.
- **Evidencia:** E2. La guía muestra `Duration: 71 ms` y `Duration: 44 ms` (l. 513–514); `capturas/L11-tests.txt` l. 26 y 28 dicen `Duration: 111 ms` y `Duration: 94 ms`. La guía muestra `[11 ms]` y `[19 ms]` (l. 520, 524); `capturas/L12-regresion.txt` l. 23 y 34 dicen `[9 ms]` y `[46 ms]`. Además la guía omite `Duration: 301 ms` / `206 ms` de las líneas `Failed!` (captura l. 32, 42). §0.5 define la marca como «extracto literal de una ejecución real» y §0 (l. 20) promete que «todo lo que la guía muestra como salida de un comando fue ejecutado y está registrado». Los números provienen con toda probabilidad de una corrida anterior (Bitácora 04 §1 registra cuatro).
- **Severidad:** S2. No cambia la lección (las duraciones están declaradas como variables), pero rompe la restricción dura R-13 en el único lugar donde un lector puede comprobarla: si compara con la captura, no encuentra lo que la guía dice que está ahí.
- **Reemplazar** (l. 513–514):
  ```
  Passed!  - Failed:     0, Passed:     3, Skipped:     0, Total:     3, Duration: 71 ms - MyProject.Domain.Tests.dll (net10.0)
  Passed!  - Failed:     0, Passed:     2, Skipped:     0, Total:     2, Duration: 44 ms - MyProject.Application.Tests.dll (net10.0)
  ```
  **por:**
  ```
  Passed!  - Failed:     0, Passed:     3, Skipped:     0, Total:     3, Duration: 111 ms - MyProject.Domain.Tests.dll (net10.0)
  Passed!  - Failed:     0, Passed:     2, Skipped:     0, Total:     2, Duration: 94 ms - MyProject.Application.Tests.dll (net10.0)
  ```
- **Reemplazar** (l. 520–525):
  ```
    Failed MyProject.Domain.Tests.ProductoTests.Create_con_precio_negativo_lanza_DomainException [11 ms]
    Error Message:
     Assert.Throws() Failure: No exception was thrown
  Failed!  - Failed:     1, Passed:     2, Skipped:     0, Total:     3 - MyProject.Domain.Tests.dll (net10.0)
    Failed MyProject.Application.Tests.CrearProductoHandlerTests.Handle_con_precio_negativo_no_guarda_nada [19 ms]
  Failed!  - Failed:     1, Passed:     1, Skipped:     0, Total:     2 - MyProject.Application.Tests.dll (net10.0)
  ```
  **por:**
  ```
    Failed MyProject.Domain.Tests.ProductoTests.Create_con_precio_negativo_lanza_DomainException [9 ms]
    Error Message:
     Assert.Throws() Failure: No exception was thrown
  Failed!  - Failed:     1, Passed:     2, Skipped:     0, Total:     3, Duration: 301 ms - MyProject.Domain.Tests.dll (net10.0)
    Failed MyProject.Application.Tests.CrearProductoHandlerTests.Handle_con_precio_negativo_no_guarda_nada [46 ms]
  Failed!  - Failed:     1, Passed:     1, Skipped:     0, Total:     2, Duration: 206 ms - MyProject.Application.Tests.dll (net10.0)
  ```
- **Verificación:** `grep -F "Duration: 111 ms" capturas/L11-tests.txt` y `grep -F "[46 ms]" capturas/L12-regresion.txt` devuelven una línea cada uno. Recomendación adicional para el cuerpo auditor: agregar a `lab.sh` (o a un guion aparte) un chequeo que confirme que cada línea de un bloque `text` con marca «Salida registrada» aparece literalmente en su captura; hoy los chequeos de Bitácora 04 §4 solo verifican que el archivo exista.

### H-02 — El Anexo A no trae comando ni captura por paso; doce pasos no tienen comando en la guía

- **Ubicación:** Anexo A, l. 1159–1191; §2.2 (L06, L07), §3.2 (L09), §4.3 (L11, L12), §5.3 (L16), §5.5 (L18), §5.6 (L19–L21), §8.1 (L23), §9.4 (L24).
- **Evidencia:** E2 + E4. El índice aprobado (veredicto §5, fila A) fija: «L00..L24 con sección, **comando**, qué confirma y **captura**; los comandos reunidos para la consulta». El Anexo A publicado tiene las columnas Paso, §, Qué se hace, Qué confirma (l. 1163). R-06 exige «comando» por paso y su chequeo es «Anexo A completo». En la prosa, estos pasos no muestran el comando que produjo su salida: L06/L07 (l. 270, solo descripción), L09 (l. 414), L11/L12 (l. 496–528: no aparece `dotnet test`), L16 (l. 653 menciona `dotnet build -v n` entre paréntesis, sin el `dotnet add package`), L18 (l. 689–691), L19–L21 (l. 707–711: se muestran los cuerpos, no el `curl`), L23 (l. 1026), L24 (l. 1128: «Dos comprobaciones se pueden hacer desde la terminal», sin mostrar ninguna). Los comandos existen en el encabezado `# comando:` de cada captura y en `lab.sh`, pero el lector que sigue la guía —el destinatario del pedido «pruebe comandos»— no los encuentra sin salir del documento.
- **Severidad:** S2. El pedido del PO es que el lector pruebe los comandos; sin comando reproducible en la guía, doce de veinticinco pasos solo se pueden leer.
- **Reemplazar** (l. 1161):
  ```
  El guion `Dot-NET-Arquitectura-Lab/lab.sh` ejecuta todos los pasos dentro del contenedor del SDK, guarda cada salida en `capturas/` y verifica lo que no cambia entre equipos en `aserciones.log`. El código final está en `Dot-NET-Arquitectura-Lab/MyProject/`.
  ```
  **por:**
  ```
  El guion `Dot-NET-Arquitectura-Lab/lab.sh` ejecuta todos los pasos dentro del contenedor del SDK, guarda cada salida en `capturas/` y verifica lo que no cambia entre equipos en `aserciones.log`. El código final está en `Dot-NET-Arquitectura-Lab/MyProject/`. La columna «Comando» resume el que produjo la captura; el comando completo, con sus rutas, está en la primera línea `# comando:` de cada archivo de `capturas/`. Todos los comandos se ejecutan desde la carpeta `MyProject/` salvo L00 y L24.
  ```
- **Reemplazar** la tabla (l. 1163–1189) **por:**
  ```
  | Paso | § | Comando | Qué confirma | Captura |
  | --- | --- | --- | --- | --- |
  | L00 | 0.6 | `dotnet --info` | El SDK disponible | `L00-entorno` |
  | L01 | 1.2 | `dotnet new sln -n MyProject`; `dotnet new globaljson …` | La solución se crea como `.slnx` | `L01-nueva-solucion` |
  | L02 | 1.2 | `dotnet new classlib …` ×2; `dotnet sln add …`; `dotnet add … reference …`; `dotnet build` | La referencia es una flecha | `L02-dos-proyectos` |
  | L03 ⚠ | 1.4 | `dotnet build src/Backend/MyProject.Domain` con un `using` sin referencia | CS0234 y CS0246: el espacio de nombres no crea dependencias | `L03-using-sin-referencia` |
  | L04 ⚠ | 1.5 | `dotnet add src/Backend/MyProject.Domain reference src/Backend/MyProject.Infrastructure`; `dotnet build` | Se agrega con código 0; MSB4006 al compilar | `L04-ciclo-agregar`, `L04-ciclo-compilar` |
  | L05 | 1.5 | `dotnet remove … reference <carpeta>`; después `… reference <ruta>.csproj` | Con la carpeta falla en silencio; con el `.csproj` funciona | `L05-quitar-con-carpeta`, `L05-quitar-con-csproj` |
  | L06 | 2.2 | `dotnet build` en `TodoJunto` | Nada impide mezclar | `L06-todo-junto` |
  | L07 ⚠ | 2.2 | `dotnet build src/Backend/MyProject.Domain` con el mismo código separado | La separación hace cumplir la regla | `L07-separado` |
  | L08 | 2.6 | `dotnet new classlib`; `dotnet new webapi --use-controllers --no-https`; referencias; `dotnet list … reference`; `dotnet build` | `Domain` sin referencias | `L08-esqueleto` |
  | L09 | 3.2 | `dotnet build src/Backend/MyProject.Domain` | `Domain` compila solo | `L09-domain` |
  | L10 ⚠ | 3.3 | `dotnet build src/Backend/MyProject.Application` con `producto.Precio = -1m` | CS0200: el setter privado protege la invariante | `L10-setter-privado` |
  | L11 | 4.3 | `dotnet new xunit …` ×2; referencias; `dotnet test` | La regla se prueba sin base ni HTTP | `L11-tests` |
  | L12 ⚠ | 4.3 | Quitar las dos líneas de validación; `dotnet test` | Las pruebas la detectan | `L12-regresion` |
  | L13 | 5.2 | `ASPNETCORE_ENVIRONMENT=Development dotnet run --no-launch-profile --urls http://127.0.0.1:5180` | Composition root en marcha | `L13-build-compilar-api`, `L13-arranque` |
  | L14 | 5.2 | `curl -s -i -X POST …/api/productos -H 'Content-Type: application/json' -d '{"nombre":"Yerba 1 kg","precio":4500}'` | 201 con `Location` | `L14-post` |
  | L15 | 5.2 | `curl -s -i …/api/productos`; `curl -s …/openapi/v1.json` | El contrato filtra `Activo` | `L15-get` |
  | L16 | 5.3 | `dotnet add src/Backend/MyProject.Infrastructure package Microsoft.EntityFrameworkCore.Sqlite`; `dotnet build -v n` | `Domain.dll` idéntico | `L16-paquete-agregar-efcore`, `L16-compilar-con-efcore` |
  | L17 | 5.3 | Repetir L14 y L15; `grep -rn Infrastructure src/Backend/MyProject.WebAPI --include=*.cs` | Mismo contrato; `Infrastructure` solo en `Program.cs` | `L17-mismo-contrato` |
  | L18 ⚠ | 5.5 | Quitar `SaveChangesAsync`; repetir L14 y L15; restituir; repetir | 201 y lista vacía; después, el producto presente | `L18-sin-savechanges`, `L18-corregido-con-savechanges` |
  | L19 ⚠ | 5.6 | `curl … -d '{"nombre":"Mate","precio":}'` | 400 automático | `L19-json-mal-formado` |
  | L20 ⚠ | 5.6 | `curl … -d '{"nombre":"Mate","precio":-5}'` | 500 | `L20-regla-sin-traducir` |
  | L21 | 5.6 | Registrar `DomainExceptionHandler`; `dotnet build src/Backend/MyProject.WebAPI`; repetir L20 | 400 con ProblemDetails | `L21-build-compilar-manejador`, `L21-regla-traducida` |
  | L22 | 6.3 | `dotnet new classlib -n MyProject.Contracts …`; mover los DTO; `dotnet new console …`; `dotnet list … reference`; `dotnet build`; `dotnet run --project src/Clients/MyProject.ConsoleClient -- http://127.0.0.1:5180` | Un cliente remoto vive con el contrato | `L22-contracts-nace-contracts`, `L22-build-compilar-solucion`, `L22-cliente-consola` |
  | L23 | 8.1 | `dotnet sln list` | La estructura física | `L23-estructura` |
  | L24 | 9.4 | `dotnet add package AutoMapper --version 14.0.0`; `dotnet list package --vulnerable`; `curl -s https://api.nuget.org/v3-flatcontainer/<paquete>/<versión>/<paquete>.nuspec` | Evaluar una dependencia antes de adoptarla | `L24-evaluar-dependencia` |
  ```
  Los nombres de la columna «Captura» son los archivos de `Dot-NET-Arquitectura-Lab/capturas/` sin la extensión `.txt`; los 34 existen. Si el cuerpo auditor prefiere no tocar la prosa de §2.2, §3.2, §4.3, §5.5 y §5.6, esta tabla alcanza para cerrar R-06: cada paso queda con comando y captura en un solo lugar de consulta.

### H-03 — §9.4 y el Anexo C atribuyen a L24 un dato que la captura no muestra, y §9.4 no muestra los comandos

- **Ubicación:** §9.4, l. 1128 y l. 1137; Anexo C, l. 1222–1223 (columna «Fuente», «L24»).
- **Evidencia:** E2. `capturas/L24-evaluar-dependencia.txt` l. 26–33 muestra: `automapper/14.0.0` → `<license type="expression">MIT</license>`; `automapper/15.0.0` → `<license type="file">LICENSE.md</license>`; `mediatr/12.5.0` → `Apache-2.0`; `mediatr/13.0.0` → `<license type="file">LICENSE.md</license>`. La captura **no contiene** la cadena «RPL» ni «comercial». La guía (l. 1137) dice «La misma captura muestra el campo de licencia de cada versión leído de nuget.org», lo cual es cierto, pero el lector que abra la captura esperando ver la licencia dual verá `LICENSE.md`. El Anexo C cita «L24» como fuente de «desde 13.0.0 RPL-1.5 o comercial» y «desde 15.0.0 RPL-1.5 o comercial»: para ese dato la fuente es solo Bogard (2025). Además, l. 1128 anuncia «dos comprobaciones desde la terminal» y no muestra ninguno de los dos comandos (`dotnet list package --vulnerable`, `curl … .nuspec`), contra R-06.
- **Severidad:** S3. El dato de licencia está bien citado (Bogard, 2025); el desvío es de atribución de evidencia, no de contenido.
- **Reemplazar** (l. 1128):
  ```
  **Paquetes.** Dos comprobaciones se pueden hacer desde la terminal. El paso L24 las aplica a AutoMapper, la biblioteca de mapeo que la versión anterior de esta guía recomendaba:
  ```
  **por:**
  ```
  **Paquetes.** Dos comprobaciones se pueden hacer desde la terminal, en un proyecto descartable: `dotnet list package --vulnerable` consulta la base de avisos de seguridad de nuget.org, y `curl -s https://api.nuget.org/v3-flatcontainer/automapper/14.0.0/automapper.nuspec` descarga el archivo de metadatos del paquete, donde el elemento `<license>` declara la licencia. El paso L24 las aplica a AutoMapper, una biblioteca de mapeo de uso extendido:
  ```
- **Reemplazar** (l. 1137):
  ```
  La versión 14.0.0 es la última con licencia MIT; desde la 15.0.0 la licencia es dual, RPL-1.5 o comercial ([Bogard, 2025](#ref-bogard-2025)), y la vulnerabilidad está corregida en versiones de esa rama. La misma captura muestra el campo de licencia de cada versión leído de nuget.org.
  ```
  **por:**
  ```
  La versión 14.0.0 es la última con licencia MIT; desde la 15.0.0 la licencia es dual, RPL-1.5 o comercial ([Bogard, 2025](#ref-bogard-2025)), y la vulnerabilidad está corregida en versiones de esa rama. La misma captura muestra el elemento `<license>` de cada versión leído de nuget.org: en 14.0.0 es la expresión `MIT`; en 15.0.0 pasa a ser un archivo, `LICENSE.md`, cuyo contenido es la licencia dual que describe Bogard. Lo mismo ocurre con MediatR entre 12.5.0 (`Apache-2.0`) y 13.0.0 (`LICENSE.md`).
  ```
- **Reemplazar** en el Anexo C (l. 1222–1223) la celda `[Bogard, 2025](#ref-bogard-2025); L24` **por** `[Bogard, 2025](#ref-bogard-2025); L24 (cambio de expresión a archivo)` en ambas filas.
- **Nota:** este reemplazo también elimina la mención «la versión anterior de esta guía» (H-06).

### H-04 — §7, §8 y §9 no cierran con una pregunta «¿Cuándo no…?»

- **Ubicación:** §7 (termina en 7.5, l. 979–993), §8 (termina en 8.5, l. 1077–1081), §9 (termina en 9.6, l. 1153–1155).
- **Evidencia:** E2 + E4. R-09: «Cada capítulo cierra con una pregunta de aplicabilidad en términos E-A..E-D; chequeo: grep de «¿Cuándo no» por capítulo ≥ 1». DR-15: «Cada capítulo del cuerpo sigue: … cierre con al menos una pregunta de aplicabilidad («¿cuándo no…?»)». `grep -n "¿Cuándo no"` da seis coincidencias, todas en §1–§6 (l. 216, 352, 450, 550, 737, 849); §7, §8 y §9 tienen cero. §7.5 («¿Cuándo la clase única es la correcta…?», respondida en términos de E-A) y §9.3 («¿Cuándo subir un escalón y cuándo es sobreingeniería?») cumplen la intención, aunque no la forma. §8 no tiene ninguna pregunta de aplicabilidad: 8.5 decide cuándo nace `Contracts`, pero no cuándo la estructura de §8 no aplica.
- **Severidad:** S3. §7 y §9 solo fallan el chequeo mecánico; §8 falla el criterio.
- **Insertar** después de l. 1081 (fin de §8.5) y antes de la línea `---`:
  ```

  ### 8.6 Pregunta de cierre

  **¿Cuándo no hace falta el árbol completo de §8.1?** Cuando la solución tiene un solo proyecto (escenario E-A, escalón 1 de §9.2): no hay `src/Backend/` ni `src/Clients/` porque no hay nada que se despliegue por separado. El árbol crece con la solución: `tests/` aparece en L11, `src/Contracts/` y `src/Clients/` en L22. La tabla de §8.3 sigue siendo la referencia para cualquier proyecto que se agregue.
  ```
- **Para §7 y §9,** dos opciones para el cuerpo auditor: (a) registrar en `Bitacora/02-Requisitos.md` que el chequeo de R-09 acepta §7.5 y §9.3 como cierre de aplicabilidad, sin tocar la guía; o (b) renombrar el encabezado l. 979 a `### 7.5 ¿Cuándo no hacen falta los siete objetos, y cuál es el término medio?` (la respuesta en l. 981 ya contesta eso) y dejar §9 como está, porque §9 es en sí el capítulo de criterio y §9.3 formula el «cuándo no» con la palabra «sobreingeniería». Recomiendo (a) para §9 y (b) para §7.

### H-05 — En §7.2, las respuestas c (Command/Query) y e (ViewModel) no remiten a ningún paso Lnn

- **Ubicación:** §7.2 c, l. 896–906; §7.2 e, l. 919–928.
- **Evidencia:** E2. DR-19: «§7.2 tiene exactamente siete `####`, cada uno con la respuesta en una línea, el porqué, el contraste ✅/❌ y la remisión al paso Lnn donde se vio». R-02 (chequeo: «cada uno con respuesta, porqué, ✅/❌ y remisión Lnn»). Conteo de `L[0-9][0-9]` por `####`: a=2, b=1, c=0, d=1, e=0, f=1, g=1. En c hay remisión a §5.2 (l. 900) pero no al paso; en e no hay remisión porque el ViewModel no se ejercitó en el laboratorio (§6.5 lo declara ilustrativo), y eso debe decirse en la respuesta para que el lector no lo busque.
- **Severidad:** S3.
- **Reemplazar** (l. 900):
  ```
  `CrearProductoCommand(Nombre, Precio)` no tiene `Id` ni `Activo`, porque quien crea un producto no los decide. El mensaje cambia cuando cambia el caso de uso, y no cuando cambia la API: el controller lo construye a partir de `CrearProductoRequest` (§5.2).
  ```
  **por:**
  ```
  `CrearProductoCommand(Nombre, Precio)` no tiene `Id` ni `Activo`, porque quien crea un producto no los decide. El mensaje cambia cuando cambia el caso de uso, y no cuando cambia la API: el controller lo construye a partir de `CrearProductoRequest` (§5.2, L14), y el handler lo recibe sin saber que existe HTTP (L11, donde la prueba lo construye a mano).
  ```
- **Reemplazar** (l. 923):
  ```
  Una lista puede necesitar `PrecioFormateado` («$ 4.500,00») o la clase de estilo de una etiqueta «Inactivo»; nada de eso pertenece al contrato ni al dominio. El ViewModel cambia cuando cambia el diseño.
  ```
  **por:**
  ```
  Una lista puede necesitar `PrecioFormateado` («$ 4.500,00») o la clase de estilo de una etiqueta «Inactivo»; nada de eso pertenece al contrato ni al dominio. El ViewModel cambia cuando cambia el diseño. Es el único objeto de la tabla que el laboratorio no construye: el cliente de consola de L22 imprime `ProductoResponse` directamente porque no tiene pantalla; el ViewModel aparece con el cliente Blazor de §6.5, que es ilustrativo.
  ```

### H-06 — Mención a «la versión anterior de esta guía» (chequeo R-03 ≠ 0)

- **Ubicación:** §9.4, l. 1128.
- **Evidencia:** E2. R-03, chequeo: «grep «versión anterior\|guía vigente» = 0». Resultado: 1 coincidencia. Es una mención, no una remisión (no pide leer nada), pero el chequeo aprobado es mecánico y la reedición se declaró autocontenida.
- **Severidad:** S4.
- **Reemplazar:** `la biblioteca de mapeo que la versión anterior de esta guía recomendaba` **por** `una biblioteca de mapeo de uso extendido` (ya incluido en el texto de H-03).

### H-07 — Versión `10.0.12` sin marca de captura, aunque la captura existe

- **Ubicación:** §5.3, l. 653.
- **Evidencia:** E2. DR-10: «grep de números de versión: cada uno tiene cita». La guía dice «(se resolvió la versión `10.0.12`)» sin marca. `capturas/L16-paquete-agregar-efcore.txt` l. 27–28 muestra la resolución de `microsoft.entityframeworkcore.sqlite/10.0.12`; la guía no cita ese archivo en ningún lugar (solo `L16-compilar-con-efcore.txt`).
- **Severidad:** S4.
- **Reemplazar** (l. 653): `(se resolvió la versión `10.0.12`)` **por** `(se resolvió la versión `10.0.12`; *salida registrada: `capturas/L16-paquete-agregar-efcore.txt`*)`.

---

## 4. Revisado y correcto

1. **R-01, traza completa.** Las doce afirmaciones de la fuente tienen destino existente y el contenido coincide; las tres con «ajuste por decisión de la mesa» (F-03 nombres DR-12, F-04 `ProductoDto`, F-05 condición E-A) están aplicadas como el veredicto las fijó. Una nota sin hallazgo: F-01 en §6.2 vive solo en el diagrama 5; la prosa que lo afirma está en §7.3 l. 971, que la Bitácora 00 no lista. Sugiero agregar «§7.3» a la fila F-01 de la Bitácora 00.
2. **R-11 y R-07.** 58 enlaces internos resuelven al 100 % (script propio, incluidas las anclas `ref-*`); `##` = 0–9 + A–E; `#####` = 0; índice con glosa. Los 25 pasos del Anexo A están en la sección que el mapa §6 del veredicto les asignó, sin excepción; el diagrama 2 (§2.6) coincide con el listado de L08 (verificado contra `capturas/L08-esqueleto.txt`, l. 34–48).
3. **R-13, contraste literal de salidas.** Comparé cada extracto con su captura: L00, L02, L03, L04 (ambas), L05 (ambas), L08, L10 (CS0200, que corrige el CS0272 previsto por el veredicto §6, como declara Bitácora 04 §2), L13, L14, L15 (incluido `"openapi": "3.1.1"` y la ausencia de `activo`), L16 (hash idéntico), L17 (`4500.0` y las dos líneas de `Program.cs`), L18 (`[]`), L21 (`title` y `detail`), L22, L23 (ocho proyectos), L24 (tabla de vulnerabilidad). Los únicos desvíos son los de H-01. DR-07 (códigos CS/MSB/NU con captura), DR-12 (alias = 0), DR-24 y DR-25 (grep dentro de las secciones permitidas) y DR-18 (palabras prohibidas = 0 fuera de URL) pasan.

---

## 5. Solicitudes de convocatoria (fuera de mi mandato)

1. **Didáctica (DR-15, contraste ✅/❌).** De 25 secciones-decisión, 14 no tienen tabla ✅/❌ ni tabla de escenarios: §1.3, §1.4, §2.3, §2.4, §3.4, §4.3, §4.5, §5.3, §5.4, §6.2, §6.3, §7.4, §8.2, §8.5. R-05 (mi vara) solo exige el orden del capítulo, que se cumple; si el contraste es obligatorio en cada decisión o solo donde hay una alternativa que descartar, lo decide Didáctica.
2. **Edición (DR-09, DR-22).** (a) Dos rótulos «[Fragmento ilustrativo …]» van después del bloque de código (l. 181 y l. 427) y DR-09 pide «precedido». (b) Los diagramas se numeran según la lista de DR-22 y no por orden de aparición: el 3 (l. 969) aparece después del 4 (l. 647) y el 5 (l. 769). (c) El diagrama 4 (secuencia) es el único sin la convención de línea en su leyenda.
3. **QA / verificación (DR-05).** Los chequeos de Bitácora 04 §4 verifican que las capturas existan, no que el extracto sea literal; H-01 pasó por ese hueco. Conviene un chequeo por línea (cada línea de un bloque `text` con marca debe hallarse en la captura, admitiendo `...` como comodín). Además, el extracto de L16 (l. 656) muestra una línea `Skipping target "CoreCompile"` sin decir de qué proyecto es; en la captura esa línea aparece también para `Application` (l. 17), y la que identifica a `Domain` es la siguiente, `6>Done Building Project ".../MyProject.Domain.csproj" (default targets)`. Incluirla haría la prueba legible sin abrir la captura.
