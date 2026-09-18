# Ciclo 2 — Informe del rol Verificación / QA (núcleo)

**Fecha:** 2026-09-18
**Objeto:** `Guides/Arquitectura/Dot-NET-Arquitectura-Guide.md` v2.0.0 (1308 líneas) y `Dot-NET-Arquitectura-Lab/` (lab.sh 835 líneas, 33 capturas + 6 logs de la API, aserciones.log 68 PASS / 1 FAIL provocado).
**Mandato:** toda salida mostrada coincide literalmente con su captura (salvo recortes marcados); todo código de error/estado tiene captura (DR-07); las aserciones de `lab.sh` prueban lo que la guía afirma; no hay afirmaciones de laboratorio sin paso.
**Método:** lectura completa de la guía; `cat` de las 33 capturas y del `aserciones.log`; lectura íntegra de `lab.sh`; `diff` mental bloque a bloque entre los 9 rótulos **[Compilado]** y los archivos de `MyProject/`; `grep` DR-07 sobre la guía; una ejecución propia en `mcr.microsoft.com/dotnet/sdk:10.0` (directorio temporal, sin tocar el objeto) para verificar la explicación del `4500.0` de §5.3. No leí los informes de otros roles.

---

## 1. Hallazgos (7)

### QA-01 — §4.3, líneas 513–514 y 520–525: las duraciones mostradas no son las de la captura, y un recorte no está marcado

- **Evidencia:** E2. La guía muestra `Duration: 71 ms` y `Duration: 44 ms` (l.513–514); `capturas/L11-tests.txt` registra `Duration: 111 ms` y `Duration: 94 ms`. La guía muestra `[11 ms]` y `[19 ms]` (l.520, 524); `capturas/L12-regresion.txt` registra `[9 ms]` y `[46 ms]`. Además las dos líneas `Failed!  - …` de l.523 y l.525 omiten `, Duration: 301 ms` y `, Duration: 206 ms` sin la marca `...` que §0.5 y el mandato exigen para un recorte.
- **Por qué importa:** §0.5 promete «extracto literal de una ejecución real» y la portada dice «Todo lo que la guía muestra como salida de un comando fue ejecutado y está registrado». Un lector que compare (el Anexo A lo invita a hacerlo) encuentra números que no existen en ninguna captura; es exactamente el «inventar» que el PO prohíbe, aunque sea en un dato irrelevante. La advertencia «las duraciones pueden cambiar» (l.528) explica por qué varían entre equipos, no por qué la guía muestra valores distintos de su propia captura.
- **Severidad:** S2 (rompe la promesa de literalidad; retrabajo de confianza sobre todas las demás salidas).
- **Reemplazar** (l.513–514):
  ```
  Passed!  - Failed:     0, Passed:     3, Skipped:     0, Total:     3, Duration: 71 ms - MyProject.Domain.Tests.dll (net10.0)
  Passed!  - Failed:     0, Passed:     2, Skipped:     0, Total:     2, Duration: 44 ms - MyProject.Application.Tests.dll (net10.0)
  ```
  **por:**
  ```
  Passed!  - Failed:     0, Passed:     3, Skipped:     0, Total:     3, Duration: 111 ms - MyProject.Domain.Tests.dll (net10.0)
  Passed!  - Failed:     0, Passed:     2, Skipped:     0, Total:     2, Duration: 94 ms - MyProject.Application.Tests.dll (net10.0)
  ```
- **Reemplazar** (l.520–525):
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
  ...
  Failed!  - Failed:     1, Passed:     2, Skipped:     0, Total:     3, Duration: 301 ms - MyProject.Domain.Tests.dll (net10.0)
    Failed MyProject.Application.Tests.CrearProductoHandlerTests.Handle_con_precio_negativo_no_guarda_nada [46 ms]
  ...
  Failed!  - Failed:     1, Passed:     1, Skipped:     0, Total:     2, Duration: 206 ms - MyProject.Application.Tests.dll (net10.0)
  ```
- **Verificación del parche:** `grep -c "Duration: 111 ms\|Duration: 94 ms" Dot-NET-Arquitectura-Guide.md` = 2; cada línea del bloque de L12 aparece textualmente en `capturas/L12-regresion.txt` (`grep -F -f`).

### QA-02 — `lab.sh` línea 827: la aserción «licencia de AutoMapper 15 no es MIT» no prueba lo que dice

- **Evidencia:** E2. `ok L24 "licencia de AutoMapper 15 no es MIT" 'automapper/15\.0\.0'`. El patrón coincide con la línea de encabezado `== automapper/15.0.0`, que el bucle `for v in …; do echo "== $v"` imprime **siempre**, aunque `curl` falle o nuget.org devuelva `MIT`. La aserción pasa por construcción. Lo que la guía afirma con apoyo en L24 (§9.4 l.1137 «La misma captura muestra el campo de licencia de cada versión»; Anexo C l.1222–1223) queda sin aserción real. `aserciones.log` presenta 68 PASS como «lo que no cambia entre equipos» (Anexo A l.1191) y este PASS es vacío.
- **Severidad:** S2 (una aserción que no puede fallar contradice DR-06 y el propósito declarado de `aserciones.log`; el mismo defecto de PASS falso que la bitácora 04 corrigió en la corrida 1).
- **Reemplazar** (`lab.sh` l.827):
  ```
  ok L24 "licencia de AutoMapper 15 no es MIT" 'automapper/15\.0\.0'
  ```
  **por:**
  ```
  lic() { body "$LAST" | grep -A1 -F "== $1" | tail -1; }   # línea <license …> que sigue al encabezado
  if lic automapper/14.0.0 | grep -q 'expression">MIT<';        then echo "PASS L24 AutoMapper 14.0.0 es MIT" >> "$LAB/aserciones.log"; else echo "FAIL L24 AutoMapper 14.0.0 no muestra MIT" >> "$LAB/aserciones.log"; fi
  if lic automapper/15.0.0 | grep -q 'type="file"';              then echo "PASS L24 AutoMapper 15.0.0 declara licencia por archivo (no MIT)" >> "$LAB/aserciones.log"; else echo "FAIL L24 AutoMapper 15.0.0 no muestra licencia por archivo" >> "$LAB/aserciones.log"; fi
  if lic mediatr/12.5.0    | grep -q 'expression">Apache-2.0<'; then echo "PASS L24 MediatR 12.5.0 es Apache-2.0" >> "$LAB/aserciones.log"; else echo "FAIL L24 MediatR 12.5.0 no muestra Apache-2.0" >> "$LAB/aserciones.log"; fi
  ```
  Con la captura actual las tres pasan (`<license type="expression">MIT</license>`, `<license type="file">LICENSE.md</license>`, `<license type="expression">Apache-2.0</license>`). Nota de alcance: el nuspec dice «licencia por archivo», no «RPL-1.5»; «RPL-1.5 o comercial» sigue apoyado sólo en [Bogard, 2025], como ya está citado. Por eso la aserción se llama «declara licencia por archivo», no «es RPL».
- **Verificación del parche:** relanzar `lab.sh` (o sólo el bloque L24 sobre la captura existente) y ver 70 PASS / 1 FAIL; forzar un fallo cambiando `MIT` por `MIX` en el patrón y ver el FAIL.

### QA-03 — `lab.sh` línea 441: la aserción de L12 no verifica «fallan exactamente las dos pruebas que dependen de la regla, una por proyecto» (§4.3 l.528)

- **Evidencia:** E2. `ok L12 "las pruebas detectan la regla faltante" '(Failed!|failed)'` pasa si falla **cualquier** prueba por **cualquier** motivo (un error de compilación en los tests también imprime `failed`). La guía afirma algo más fuerte y más útil para el lector: que fallan las dos pruebas nombradas y sólo esas (`Failed: 1, Passed: 2` y `Failed: 1, Passed: 1`), y la captura lo respalda, pero ninguna aserción lo fija.
- **Severidad:** S3.
- **Reemplazar** (`lab.sh` l.441):
  ```
  ok L12 "las pruebas detectan la regla faltante" '(Failed!|failed)'
  ```
  **por:**
  ```
  ok L12 "falla la prueba de Domain que depende de la regla" 'Failed MyProject\.Domain\.Tests\.ProductoTests\.Create_con_precio_negativo_lanza_DomainException'
  ok L12 "falla la prueba de Application que depende de la regla" 'Failed MyProject\.Application\.Tests\.CrearProductoHandlerTests\.Handle_con_precio_negativo_no_guarda_nada'
  ok L12 "en Domain falla exactamente una de tres" 'Failed! +- Failed: +1, Passed: +2, Skipped: +0, Total: +3'
  ok L12 "en Application falla exactamente una de dos" 'Failed! +- Failed: +1, Passed: +1, Skipped: +0, Total: +2'
  ```
  Las cuatro pasan contra `capturas/L12-regresion.txt` (verificado con `grep -E` sobre el archivo).
- **Verificación del parche:** `aserciones.log` con cuatro líneas `PASS L12 …` en lugar de una.

### QA-04 — §5.6, líneas 715–731: el bloque rotulado **[Compilado: …/DomainExceptionHandler.cs]** no es el texto que compiló

- **Evidencia:** E2. La guía (l.728) muestra `ProblemDetails = { Status = 400, Title = "Regla de negocio incumplida", Detail = exception.Message },`. El archivo `MyProject/src/Backend/MyProject.WebAPI/ExceptionHandlers/DomainExceptionHandler.cs` (l.24–29) y el heredoc de `lab.sh` (l.~735) tienen `Status = StatusCodes.Status400BadRequest,` en un inicializador de varias líneas. Es equivalente en semántica, pero DR-09 define el rótulo como «extraído del código que compiló», y §0.5 lo promete al lector. Los otros ocho bloques **[Compilado]** sí coinciden con sus archivos (verificado uno por uno: `Producto.cs`, `Dinero.cs`, `CrearProductoCommand`/`Handler`, `CrearProductoHandlerTests.cs`, `ProductosController.cs`, `ProductoConfiguration.cs`, `ConsoleClient/Program.cs`).
- **Severidad:** S3.
- **Reemplazar** (l.724–729):
  ```
      return await _problemDetails.TryWriteAsync(new ProblemDetailsContext
      {
          HttpContext = httpContext,
          Exception = exception,
          ProblemDetails = { Status = 400, Title = "Regla de negocio incumplida", Detail = exception.Message },
      });
  ```
  **por:**
  ```
      return await _problemDetails.TryWriteAsync(new ProblemDetailsContext
      {
          HttpContext = httpContext,
          Exception = exception,
          ProblemDetails =
          {
              Status = StatusCodes.Status400BadRequest,
              Title = "Regla de negocio incumplida",
              Detail = exception.Message,
          },
      });
  ```
- **Verificación del parche:** `diff <(sed -n 13,30p MyProject/src/Backend/MyProject.WebAPI/ExceptionHandlers/DomainExceptionHandler.cs) <(bloque de la guía)` vacío.

### QA-05 — §5.1, línea 561: `404 Not Found` aparece sin captura (DR-07)

- **Evidencia:** E2 + E4. `grep -nE 'CS[0-9]{4}|MSB[0-9]{4}| [2-5][0-9]{2} |`[2-5][0-9]{2}'` sobre la guía: todos los códigos tienen captura (CS0234/CS0246 L03 y L07, MSB4006 L04, CS0200 L10, 201 L14, 200 L15/L17, 400 L19/L21, 500 L20), salvo `404 Not Found` (l.561) y `422` (l.733). El 422 está autorizado por DR-28 como alternativa citada; el 404 no está autorizado por ninguna directiva y ningún paso lo ejercita, aunque el código que lo produce existe (`GetById` devuelve `NotFound()`, `ProductosController.cs` l.28) y bastaría un `curl` a un `Guid` inexistente.
- **Severidad:** S3.
- **Reemplazar** (l.561):
  ```
  `4xx` el cliente pidió algo inválido (`400 Bad Request`, `404 Not Found`), `5xx` falló el servidor (`500 Internal Server Error`).
  ```
  **por** (opción mínima, sin relanzar el laboratorio):
  ```
  `4xx` el cliente pidió algo inválido (`400 Bad Request`; `404 Not Found` cuando el recurso no existe, un caso que el laboratorio no ejercita), `5xx` falló el servidor (`500 Internal Server Error`).
  ```
  **Opción completa** (si se relanza el laboratorio por otro motivo): en `lab.sh` l.568 agregar al final del comando de L15 `; echo; echo; curl -s -i $API/api/productos/00000000-0000-0000-0000-000000000000 | head -1` y en l.572 `ok L15 "404 para un id inexistente" 'HTTP/1.1 404'`; en §5.2 l.629 agregar «Un `GET` con un `Guid` que no existe responde `404 Not Found` (misma captura).» y quitar la salvedad de §5.1.
- **Verificación del parche:** el grep de DR-07 no devuelve ningún código sin remisión Lnn o salvedad explícita.

### QA-06 — §5.3, líneas 655–662: la salida de L16 muestra un hash sin «Qué puede cambiar en tu equipo» (DR-11), y el hash sí cambia

- **Evidencia:** E4 (DR-11: «cada paso con salida variable lleva “Qué puede cambiar”») + E2 (l.658–659 muestran `7ce966b2…` dos veces; ni §5.3 ni el Anexo A l.1191 —que enumera «rutas absolutas, Guid, fechas, duraciones y parche del SDK»— mencionan el hash). El SHA-256 de `MyProject.Domain.dll` depende del directorio de compilación (el ensamblado guarda la ruta del `.pdb` en su directorio de depuración) y de la versión exacta del compilador; quien reproduzca el laboratorio fuera de `/tmp/work` con otro parche del SDK obtendrá otro valor y puede creer que hizo algo mal. Lo invariante es la **igualdad** entre antes y después, que es lo que verifica `lab.sh` (l.700–701), no el valor.
- **Severidad:** S3.
- **Reemplazar** (l.662, primera oración):
  ```
  *Salida registrada: `capturas/L16-compilar-con-efcore.txt`, SDK 10.0.400.* `Domain.dll` es el mismo archivo, byte por byte, antes y después de cambiar la base de datos.
  ```
  **por:**
  ```
  *Salida registrada: `capturas/L16-compilar-con-efcore.txt`, SDK 10.0.400.* `Domain.dll` es el mismo archivo, byte por byte, antes y después de cambiar la base de datos. **Qué puede cambiar en tu equipo:** el valor del hash, que depende del directorio y del parche exacto del compilador; lo que no cambia es que las dos líneas sean iguales entre sí.
  ```
  Y en el Anexo A l.1191, **reemplazar** «rutas absolutas, identificadores `Guid`, fechas, duraciones y el número de parche del SDK» **por** «rutas absolutas, identificadores `Guid`, fechas, duraciones, el valor del hash de L16 y el número de parche del SDK».
- **Verificación del parche:** grep de «Qué puede cambiar» en §5.3 ≥ 1.

### QA-07 — Tres frases de prosa que contradicen en detalle a su captura (S4, lote)

- **Evidencia:** E2.
  1. **Anexo A l.1170** «Con la carpeta falla en silencio»: `capturas/L05-quitar-con-carpeta.txt` muestra el mensaje `Project reference … could not be found.` con código 0. No es silencio; es un mensaje con código de salida engañoso, que es justamente la lección de §1.5 l.212 («leé el mensaje, no solo el código de salida»). La tabla contradice al capítulo.
  2. **§5.5 l.689** «L18 quita del repositorio la llamada a `SaveChangesAsync` y deja solo `_db.Productos.Add(producto)`»: `capturas/L18-sin-savechanges.txt` l.20–21 muestra que la línea se reemplazó por `await Task.CompletedTask; // (L18) falta confirmar la escritura` (necesario para que el método `async` compile sin advertencia). «Deja solo» no es lo que se ve.
  3. **§1.4 l.184–187**: cada error de `capturas/L03-using-sin-referencia.txt` ocupa una línea; la guía los parte en dos con sangría, sin marca. El texto es el mismo pero la forma no es «literal», y el lector que busque la segunda línea en la captura no la encuentra.
- **Severidad:** S4 (aplicar en lote).
- **Reemplazar** (1) «Con la carpeta falla en silencio; con el `.csproj` funciona» **por** «Con la carpeta avisa que no la encuentra pero devuelve 0; con el `.csproj` la quita».
- **Reemplazar** (2) «L18 quita del repositorio la llamada a `SaveChangesAsync` y deja solo `_db.Productos.Add(producto)`:» **por** «L18 reemplaza en el repositorio la llamada a `SaveChangesAsync` por un `await Task.CompletedTask` que no confirma nada, y deja `_db.Productos.Add(producto)` como única operación sobre la base:».
- **Reemplazar** (3) las cuatro líneas l.184–187 **por** las dos líneas de la captura sin el prefijo de ruta ni el sufijo `[…csproj]`, cada una en una sola línea:
  ```
  Producto.cs(1,17): error CS0234: The type or namespace name 'Infrastructure' does not exist in the namespace 'MyProject' (are you missing an assembly reference?)
  Producto.cs(9,25): error CS0246: The type or namespace name 'ConexionSql' could not be found (are you missing a using directive or an assembly reference?)
  ```
  y, si se quiere dejar declarado el criterio de recorte una sola vez, agregar en §0.5 tras la fila «Salida registrada»: «Los extractos omiten líneas, prefijos de ruta y encabezados HTTP sin marcarlo; nunca alteran el texto de una línea mostrada; un `...` marca líneas quitadas dentro de un bloque.»

---

## 2. Revisado y correcto (3)

1. **DR-07 y literalidad de las salidas de error/estado.** CS0234 y CS0246 (§1.4, §2.2), MSB4006 y los códigos de salida 0/1 (§1.5), CS0200 (§3.3), `201 Created` + `Location` (§5.2), `200 OK` con el JSON sin `activo` (§5.2, §7.2 d), `"openapi": "3.1.1"` (§5.2), `[]` de L18, `400`/`application/problem+json`/`"errors"` de L19, `500` con `DomainException: El precio debe ser mayor a cero.` de L20, `400` + `"title":"Regla de negocio incumplida"` de L21, la salida del cliente de consola (§6.3) y el bloque de `dotnet list package --vulnerable` (§9.4) coinciden textualmente con sus capturas. L17: `grep -rn Infrastructure` devuelve exactamente dos líneas de `Program.cs`, como dice §5.3. L16: las dos líneas del SHA-256 son iguales y la captura contiene `Skipping target "CoreCompile"`, como pide DR-06. L23: `dotnet sln list` devuelve los ocho proyectos del árbol de §8.1. Aserción provocada: existe (`FAIL L02-provocada`), y `PASS: 68 FAIL: 1` coincide con el conteo (`grep -c '^PASS L'` = 68).
2. **La explicación del `4500.0` (§5.3 l.662) es correcta — verificada E1.** Ejecuté en `mcr.microsoft.com/dotnet/sdk:10.0` un programa con `Microsoft.Data.Sqlite 10.0.12` que inserta `4500m` en una columna y la relee: SQLite guarda el texto `'4500.0'` (`typeof = text`); el `decimal` original se serializa como `4500` y el leído como `4500.0`; `4500m == leido` es `True`. La frase «el valor numérico es igual, pero el tipo `decimal` conserva la escala con la que el proveedor de SQLite lo devuelve» describe exactamente lo observado. Sugerencia no vinculante: citar la tabla de tipos de Microsoft.Data.Sqlite (decimal → TEXT), https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/types, para que el enunciado no quede como interpretación sin fuente (la bitácora 04 lo llama «interpretación rotulada», pero en la guía no lleva rótulo).
3. **Cobertura paso ↔ aserción.** Los 25 pasos del Anexo A tienen captura y al menos una aserción (`aserciones.log` tiene líneas L00..L24 sin huecos); los rótulos «Salida registrada» remiten a 29 archivos existentes; la receta DR-20 se usa en L13–L22 (`start_api`); `Domain.dll idéntico` se verifica por hash de archivo, no por texto; `ok`/`nok` leen sólo el cuerpo de la captura (`body()`), lo que evita el PASS falso de la corrida 1. La aserción de L10 acepta `CS0(200|272)` y la guía y el Anexo A dicen CS0200, que es lo capturado: coherente con la bitácora 04 §2.

---

## 3. Solicitudes de convocatoria (fuera de mi mandato)

- **Arquitectura — §2.6 l.348.** «`Infrastructure` referencia también a `Application` porque ahí se declaran las interfaces de servicios técnicos (correo, usuario actual) que Infrastructure implementa.» El laboratorio crea la referencia (L08) pero `MyProject.Application` no declara ninguna interfaz de servicio técnico y `MyProject.Infrastructure` no usa ningún tipo de `Application` (`grep -rn "using MyProject.Application" MyProject/src/Backend/MyProject.Infrastructure` = 0). La justificación es de diseño y no de laboratorio; que Arquitectura decida si se rotula «en el laboratorio esa referencia queda sin uso» o si el ejemplo la ejercita. No emito hallazgo porque no es una salida ni una aserción.
- **Edición — §0.5.** Convendría declarar una sola vez la política de recorte de los extractos (ver QA-07, último párrafo) para que la mesa no tenga que juzgar recorte por recorte. Es criterio de redacción, no de verificación.

---

## 4. Nota de método

- No modifiqué ningún archivo del objeto. El programa de verificación E1 vive en el scratchpad de esta sesión (`…/scratchpad/dec/`).
- Dejo constancia de que no relancé `lab.sh` completo: las comparaciones son contra las capturas publicadas (corrida 4 de la bitácora 04), que es lo que el lector recibe.
