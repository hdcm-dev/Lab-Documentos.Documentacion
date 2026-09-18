# Mesa, ciclo 1 — AH-001: ecosistema .NET, versionado y licenciamiento

**Rol:** agente ad hoc AH-001 (carta de mandato en `Mesa/01-Registro-Convocatoria.md`).
**Objeto:** `/LAB/Lab-Documentos/Guides/Arquitectura/Dot-NET-Arquitectura-Guide.md`, commit `063f4e9` (1003 líneas).
**Fecha de consulta de todas las fuentes:** 2026-09-18.
**Mandato:** qué versiones y dependencias puede recomendar la guía sin inducir a error, con fuente primaria. No opino sobre didáctica, redacción ni diseño de capas.
**Trabajo a ciegas:** no leí otros informes de `Ciclo-1/`.

---

## 0. Método y evidencia reunida

Tres tipos de fuente, en este orden de preferencia:

1. **Ejecución propia (E1)** con las imágenes oficiales `mcr.microsoft.com/dotnet/sdk:8.0` (SDK 8.0.424), `9.0` (SDK 9.0.317) y `10.0` (SDK 10.0.400).
2. **Metadatos de NuGet** leídos del índice oficial (`https://api.nuget.org/v3-flatcontainer/<paquete>/<versión>/<paquete>.nuspec`): campo `<license>` de cada versión.
3. **Páginas oficiales** del fabricante o del proyecto, citadas con URL.

### 0.1 Salidas ejecutables

**Plantilla `webapi` en cada SDK** (`dotnet new webapi -o A`, sin red):

```text
== sdk 8.0.424
    <TargetFramework>net8.0</TargetFramework>
    <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="8.0.30" />
    <PackageReference Include="Swashbuckle.AspNetCore" Version="6.6.2" />
== sdk 9.0.317
    <TargetFramework>net9.0</TargetFramework>
    <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="9.0.19" />
== sdk 10.0.400
    <TargetFramework>net10.0</TargetFramework>
    <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="10.0.11" />
```

En 9 y 10, `Program.cs` contiene `builder.Services.AddOpenApi();` y `app.MapOpenApi();`, sin `UseSwagger` ni `UseSwaggerUI`. Lo mismo con `--use-controllers`.

**Últimas versiones libres de MediatR y AutoMapper sobre .NET 10** (`dotnet new classlib`, `dotnet add package MediatR 12.5.0`, `dotnet add package AutoMapper 14.0.0`, `dotnet build`, `dotnet list package --vulnerable`):

```text
/tmp/L/L.csproj : warning NU1903: Package 'AutoMapper' 14.0.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-rvv3-g6hj-g44x
Build succeeded.
Project `L` has the following vulnerable packages
   [net10.0]:
   Top-level Package      Requested   Resolved   Severity   Advisory URL
   > AutoMapper           14.0.0      14.0.0     High       https://github.com/advisories/GHSA-rvv3-g6hj-g44x
```

### 0.2 Licencias por versión (campo `<license>` del `.nuspec` en nuget.org)

| Paquete | Versión | Licencia declarada |
|---|---|---|
| MediatR | 12.5.0 | `Apache-2.0` (expresión) |
| MediatR | 13.0.0 / 14.2.0 (última estable) | `LICENSE.md` (archivo): RPL-1.5 o licencia comercial de Lucky Penny Software |
| AutoMapper | 14.0.0 | `MIT` (expresión) |
| AutoMapper | 15.0.0 / 16.2.0 (última estable) | `LICENSE.md` (archivo): mismo esquema dual |
| FluentValidation | 12.1.1 (última estable) | `Apache-2.0` |
| Refit | 15.2.0 (última estable) | `MIT` |

El `LICENSE.md` dentro de `mediatr.14.2.0.nupkg` dice, literal: «Your license to Lucky Penny Software source code and/or binaries is governed by the Reciprocal Public License 1.5 (RPL1.5) […] If you do not wish to release the source of software you build […] you may use […] under the License Agreement described here: https://luckypennysoftware.com/license».

### 0.3 Fuentes web consultadas (2026-09-18)

| # | Fuente | Qué respalda |
|---|---|---|
| F1 | https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-core | .NET 10 LTS, fin 2028-11-14; .NET 9 STS, fin 2026-11-10; .NET 8 LTS, fin 2026-11-10. «LTS releases are supported for three years», «the support period for STS is two years». |
| F2 | https://learn.microsoft.com/en-us/ef/core/what-is-new/ | EF Core 10 → .NET 10, soporte hasta 2028-11-10; EF Core 9 → **.NET 8**, hasta 2026-11-10; «EF Core releases and support are aligned with .NET releases and support». |
| F3 | https://www.jimmybogard.com/automapper-and-mediatr-commercial-editions-launch-today/ (2025-07-02) | Ediciones comerciales desde AutoMapper 15.0 y MediatR 13.0; esquema dual RPL-1.5 + comercial; versiones previas conservan su licencia. |
| F4 | https://luckypennysoftware.com/license (PDF, «License document version 2.0») | «This Agreement applies to AutoMapper version 15.0.0 and later, and to MediatR version 13.0.0 and later». Community License: ingresos brutos anuales < USD 5 000 000; nunca más de USD 10 000 000 de capital externo; ONG con presupuesto < USD 5 000 000; no disponible para organismos de gobierno; §4.2.g.3.3: estudiantes y docentes pueden usarla «for genuine educational purposes», pero las universidades no para sistemas institucionales. |
| F5 | https://github.com/advisories/GHSA-rvv3-g6hj-g44x | AutoMapper, severidad alta (DoS por recursión no controlada), publicado 2026-03-13; afectadas `< 15.1.1` y `>= 16.0.0, < 16.1.1`; parches 15.1.1 y 16.1.1. |
| F6 | https://github.com/FluentValidation/FluentValidation/blob/main/License.txt | Apache License 2.0. |
| F7 | https://raw.githubusercontent.com/reactiveui/refit/main/README.md y `docs/breaking-changes.md` | «The `Refit` package ships Roslyn source generators»; Refit 6 exige SDK 5.0.100+ y PackageReference porque `packages.config` no soporta «analyzers/source generators»; V14 mueve el constructor por reflexión al paquete opcional `Refit.Reflection`. |
| F8 | https://github.com/advisories/GHSA-3hxg-fxwm-8gf7 | Refit: CRLF injection en `[Header]`, CVSS 10, afectadas `< 7.2.22`. |
| F9 | https://learn.microsoft.com/en-us/aspnet/core/fundamentals/openapi/aspnetcore-openapi (ms.date 2026-09-04) | «Interactive UIs such as Swagger UI or Scalar are not included by default and must be added separately». |

---

## 1. Hallazgos

### H-01 — La guía fija .NET 9, que sale de soporte en 53 días

- **Ubicación:** línea 4 («Stack: .NET 9, Blazor, MAUI Hybrid…»); línea 993 («.NET 9 Class Library»); línea 997 («EF Core 9»).
- **Afirmación:** la guía toma como base un runtime STS cuyo soporte termina el 2026-11-10 (F1). Una persona que la use para diseñar hoy una solución arranca sobre una versión que queda sin parches de seguridad antes de terminar el primer desarrollo. .NET 8, la otra candidata obvia, termina el mismo día (F1). La única versión con soporte más allá de noviembre de 2026 es .NET 10 LTS, hasta 2028-11-14. El SDK 10.0.400 ya está disponible como imagen oficial y genera proyectos `net10.0` (§0.1).
- **Evidencia:** E2 (cita de la guía) + E1 (plantillas corridas con los tres SDK) + fuente primaria F1.
- **Severidad:** S2. La guía sigue siendo legible, pero lleva al lector a un stack sin soporte y hace que queden viejas todas las salidas de laboratorio que se capturen con el SDK 9.
- **Propuesta de dirección:** ver DA-3 (§3). Declarar .NET 10 LTS en el encabezado. Enseñar la regla de elección («par = LTS, 3 años; impar = STS, 2 años; lanzamiento cada noviembre»), citando F1, en lugar de dejar un número de versión sin justificar. Cada salida del laboratorio debe decir con qué `dotnet --version` se capturó.

### H-02 — Recomienda «MediatR 12» sin mencionar que desde la 13 la licencia es dual (RPL-1.5 o comercial)

- **Ubicación:** línea 994 («Casos de uso | CQRS | MediatR 12»); línea 377 (dependencias de Application: `MediatR`, sin versión); líneas 160-162 y 386-387 (MediatR presentado como pieza estándar del pipeline).
- **Afirmación:** desde la versión 13.0.0, MediatR se distribuye bajo RPL-1.5 o bajo la licencia comercial de Lucky Penny Software (F3, F4, §0.2). La última versión Apache-2.0 es la 12.5.0. Hay dos lecturas de la guía que inducen a error:
  1. Si el lector obedece «MediatR 12», queda en una rama congelada: el repositorio de la versión libre se archivó (F3) y la 12.5.0 declara `net6.0` como destino (nuspec). Compila sobre .NET 10 (§0.1), pero ya no recibe mantenimiento.
  2. Si el lector hace `dotnet add package MediatR` sin indicar versión, recibe la 14.2.0 (RPL-1.5/comercial) sin que la guía le haya avisado. RPL-1.5 obliga a publicar el código de la solución, y la licencia Community solo cubre a quien cumple las condiciones de F4. Una empresa con ingresos anuales de USD 5 millones o más, o un organismo de gobierno, necesita licencia paga.
- **Evidencia:** E2 (cita de la guía) + metadatos de NuGet (§0.2) + F3/F4.
- **Severidad:** S2. La guía se presenta como base para diseñar «desde cero una solución para un problema real». Si no advierte la licencia, el lector puede terminar con una dependencia incompatible con su organización, y corregirlo implica rehacer todos los handlers.
- **Propuesta de dirección:** ver DA-4 (§3).

### H-03 — AutoMapper: la última versión MIT tiene una vulnerabilidad alta y el parche solo existe en versiones comerciales

- **Ubicación:** línea 98 («Se mapean a/desde entidades usando AutoMapper o mapeo manual»); línea 377 (dependencia `AutoMapper` de Application); línea 392 (`MappingProfile.cs ← Perfiles AutoMapper globales`); línea 996 («AutoMapper o Mapeo manual (records)»).
- **Afirmación:** AutoMapper 15.0.0 y posteriores son RPL-1.5/comerciales (F3, F4). La última versión MIT es la 14.0.0, y está afectada por GHSA-rvv3-g6hj-g44x, de severidad alta, cuyo parche existe solo en 15.1.1 y 16.1.1 (F5). La corrida de §0.1 lo confirma: `dotnet build` emite `warning NU1903` y `dotnet list package --vulnerable` la informa como **High**. Hoy no hay ninguna versión de AutoMapper que sea a la vez gratuita para cualquier organización y esté libre de vulnerabilidades conocidas. La guía ofrece AutoMapper en pie de igualdad con el mapeo manual.
- **Evidencia:** E1 (build y listado de vulnerabilidades) + metadatos de NuGet (§0.2) + F5.
- **Severidad:** S2. Una recomendación de la guía, seguida al pie de la letra, lleva a elegir entre una dependencia vulnerable y una licencia paga.
- **Propuesta de dirección:** ver DA-4 (§3). El mapeo manual pasa a ser la opción por defecto. Si se nombra AutoMapper, que sea en el capítulo de criterios, como ejemplo de dependencia evaluada por licencia, mantenimiento, alternativa nativa y costo de salida (el criterio de NC-10), mostrando la salida real de `NU1903`.

### H-04 — «Swagger» como documentación de la API: desde .NET 9 la plantilla no trae Swashbuckle ni ninguna interfaz visual

- **Ubicación:** línea 524 (`ServiceCollectionExtensions.cs ← Registro de servicios, Swagger, CORS, etc.`); línea 998 («ASP.NET Core + Scalar/Swagger»).
- **Afirmación:** la plantilla `webapi` de .NET 8 incluía `Swashbuckle.AspNetCore` 6.6.2. Las de .NET 9 y .NET 10 solo incluyen `Microsoft.AspNetCore.OpenApi` y generan el documento con `AddOpenApi()` / `MapOpenApi()` (E1, §0.1). Ninguna interfaz interactiva viene por defecto (F9). Un lector sin experiencia que espere encontrar «Swagger» en el proyecto recién creado (una página `/swagger`) no la va a encontrar, y como la guía no le muestra el resultado esperado, tampoco puede darse cuenta de que el comportamiento es el correcto.
- **Evidencia:** E1 (plantillas generadas con los tres SDK) + E2 (cita de la guía) + F9.
- **Severidad:** S3. Confunde, pero no hace retrabajar la arquitectura.
- **Propuesta de dirección:** el laboratorio muestra `dotnet new webapi` y su `.csproj`, y ejercita `GET /openapi/v1.json` (ruta por defecto de `MapOpenApi`) como resultado esperado. Scalar o Swagger UI quedan como paquete agregado aparte, con una línea que diga por qué no viene incluido. El nombre del archivo de registro no debería prometer «Swagger».

### H-05 — La versión de EF Core se escribe suelta en vez de derivarse del runtime

- **Ubicación:** línea 997 («Persistencia | ORM Code-First | EF Core 9»).
- **Afirmación:** EF Core sigue el ciclo de soporte de .NET (F2). Hay un detalle que el lector no puede deducir: EF Core 9 apunta a **.NET 8**, no a .NET 9, y termina su soporte el 2026-11-10. EF Core 10 exige .NET 10 y tiene soporte hasta 2028-11-10 (F2). Si se adopta .NET 10 (H-01) y se conserva «EF Core 9», el resultado es una combinación válida que compila, pero que queda sin soporte en noviembre. La última versión del paquete `Microsoft.EntityFrameworkCore` en nuget.org es la 10.0.12.
- **Evidencia:** E2 (cita de la guía) + F2 + índice de NuGet.
- **Severidad:** S3.
- **Propuesta de dirección:** escribir «EF Core de la misma versión mayor que el runtime (EF Core 10 con .NET 10)» y enseñar el criterio con F2: la versión de EF Core sigue a la del runtime, igual que su soporte.

---

## 2. Revisado y correcto

1. **Refit genera la implementación «en tiempo de compilación»** (línea 683). Es correcto. El paquete trae generadores de código Roslyn desde la versión 6, que exige SDK 5.0.100+ y PackageReference porque `packages.config` no soporta generadores (F7). Desde V14 el camino por reflexión pasó a ser un paquete opcional (`Refit.Reflection`) (F7). La licencia es MIT (§0.2). Un matiz para la reedición: las versiones anteriores a 7.2.22 tienen una vulnerabilidad crítica de inyección de cabeceras (F8). Si la guía fija alguna versión de Refit, tiene que ser una actual.
2. **FluentValidation** (líneas 377, 401, 995). Licencia Apache-2.0 en la versión estable vigente, 12.1.1 (F6, §0.2). No tiene restricciones comerciales ni avisos de seguridad en GitHub Advisory para NuGet (consulta a `api.github.com/advisories?affects=FluentValidation&ecosystem=nuget`: 0 resultados). Se puede recomendar sin reservas de licencia.
3. **«Scalar/Swagger» como opciones de interfaz para la documentación** (línea 998). Nombrarlas como alternativas es coherente con la documentación oficial, que presenta Swagger UI y Scalar como interfaces que se agregan por separado (F9). Lo que hay que corregir es que la plantilla no las incluye (H-04), no la elección de nombres.

---

## 3. Propuestas para las decisiones abiertas

### DA-3 — Versión de .NET de la guía

**Propuesta: .NET 10 (LTS), con EF Core 10 y ASP.NET Core 10. La guía enseña el criterio y no solo el número.**

Fundamentos:

- Es la única versión con soporte más allá del 2026-11-10: hasta 2028-11-14 (F1). Tanto .NET 9 como .NET 8 terminan dentro de 53 días.
- El SDK oficial (`sdk:10.0`, 10.0.400) ya está en el entorno del laboratorio y genera `net10.0` (§0.1). Las salidas capturadas van a seguir valiendo durante toda la vida útil de la guía.
- En noviembre de 2026 sale .NET 11, que será STS según la regla de F1 («odd numbered releases are STS»). No conviene cambiar a esa versión: la guía debería explicar que para una solución que tiene que vivir años se elige la LTS vigente, y que una STS solo se justifica si se necesita algo que únicamente trae esa versión.
- Hay que vigilar el costo de MAUI: el alcance ya excluye validar sus workloads (contrato, fuera de alcance), así que el cambio de versión no suma trabajo de verificación en esa parte.

### DA-4 — MediatR y AutoMapper

**Propuesta: la guía no los usa en el ejemplo conductor. Los presenta en el capítulo de criterios como caso de estudio de evaluación de dependencias.**

1. **Ejemplo conductor sin MediatR.** Los casos de uso se modelan como handlers comunes (una interfaz o una clase por Command o Query) que se inyectan con el contenedor nativo de `Microsoft.Extensions.DependencyInjection`. La separación Command/Query/Handler, que es lo que la guía enseña, se mantiene sin agregar ninguna dependencia de terceros. La guía debe decir explícitamente que CQRS es un patrón y que MediatR es solo una de sus implementaciones. Los *pipeline behaviors* (validación y logging, líneas 386-387) se explican como decoradores y se mencionan como la función que MediatR resuelve.
2. **Ejemplo conductor sin AutoMapper.** El mapeo es manual (métodos de extensión o constructores en los records de DTO). Motivo decisivo, verificado en E1: ninguna versión gratuita para cualquier organización está libre de la vulnerabilidad alta GHSA-rvv3-g6hj-g44x (H-03).
3. **Recuadro de licencias en el capítulo de criterios (NC-10)**, con estos datos y sus fuentes:
   - MediatR ≥ 13.0.0 y AutoMapper ≥ 15.0.0: RPL-1.5 o licencia comercial de Lucky Penny Software, desde el 2025-07-02 (F3, F4).
   - Condiciones de la licencia Community (F4): ingresos brutos anuales < USD 5 M; capital externo recibido ≤ USD 10 M; ONG con presupuesto < USD 5 M; excluidos los organismos de gobierno; el uso educativo individual de estudiantes y docentes está permitido, pero no los sistemas institucionales de universidades.
   - Últimas versiones con licencia permisiva: MediatR 12.5.0 (Apache-2.0) y AutoMapper 14.0.0 (MIT, con vulnerabilidad alta sin parche libre).
   - Criterio general, que es lo formativo: toda dependencia se evalúa por licencia (y por la versión desde la que rige), mantenimiento, alternativa nativa y costo de salida. `dotnet list package --vulnerable` y el campo de licencia de NuGet son las dos comprobaciones que el lector puede correr por su cuenta, y la guía debe mostrar la salida real de ambas.
4. Esta propuesta no reabre DC-1..DC-4. DC-2 fija nombres como `Handler`, `Command` y `CrearProductoCommand`, y todos se conservan sin MediatR.

---

## 4. Solicitudes de convocatoria (fuera de mi mandato)

- **Seguridad / autenticación:** la línea 1003 asocia «JWT + Bearer» con «ASP.NET Core Identity». No verifiqué esa afirmación porque está fuera de mi competencia. Pido que un especialista en seguridad confirme si los endpoints de Identity emiten JWT o tokens propietarios, y qué debería recomendar la guía.
- **Diseño / didáctica:** si la mesa acepta DA-4 sin MediatR, el diseño de los handlers y de los decoradores de validación y logging le corresponde al especialista en arquitectura o diseño de capas, no a mí.
